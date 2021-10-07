using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Microsoft.EnterpriseManagement.CompositionEngine;
using Microsoft.EnterpriseManagement.Monitoring.DataProviders;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.DataQuery.SchemaTypes;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class GetSingleAlertDetailsQuery : DataQuery
    {
        #region property names

        new public class PropertyNames
        {
            public const string Id = "Id";
            public const string AlertProperties = "AlertProperties";
            public const string AlertPropertiesExclusion = "AlertPropertiesExclusion";
            public const string AlertPropertiesInclusion = "AlertPropertiesInclusion";
            public const string Refresh = "Refresh";
            public const string Output = "Output";
            public const string DisplayStrings = "DisplayStrings";
        }

        #endregion

        #region private fields

        private Guid alertId; // id of the alert whose details are retreived.
        private IEnumerable<ValueDefinitionType> alertProperties; // alert data source properties

        #endregion

        #region public properties

        public IEnumerable<ValueDefinitionType> AlertProperties
        {
            get { return alertProperties ?? (alertProperties = new List<ValueDefinitionType>(GetDefaultAlertProperties())); }
        }

        public Guid AlertId
        {
            get 
            { 
                return alertId; 
            }            
        }

        #endregion 

        #region protected methods

        /// <summary>
        /// Specific implementation of the SetProperty
        /// </summary>
        protected override void SetPropertyInternal(string propertyName, object value)
        {
            switch (propertyName)
            {
                case PropertyNames.Id:
                    {
                        alertId = (Guid)value;
                        Utilities.LogMessage("Set GetSingleAlertDetails.Id = " + alertId, true);
                        compRequest.SetParameter(PropertyNames.Id, alertId.ToString());
                        break;
                    }

                case PropertyNames.AlertPropertiesExclusion:
                    {
                        var propertiesToBeDeleted = AlertProperty.GetValueDefinitions(value as List<string>);
                        alertProperties = CalculateNewColumnList(alertProperties, propertiesToBeDeleted, false);
                        Utilities.LogMessage("Set GetSingleAlertDetails.AlertProperties = " + ValueDefinitionType.ToString(alertProperties), true);
                        compRequest.SetParameter(PropertyNames.AlertProperties, ValueDefinitionType.ToIDataObject(alertProperties));
                        break;
                    }

                case PropertyNames.AlertPropertiesInclusion:
                    {
                        var additionalProperties = AlertProperty.GetValueDefinitions(value as List<string>);
                        alertProperties = CalculateNewColumnList(alertProperties, additionalProperties, true);
                        Utilities.LogMessage("Set GetSingleAlertDetails.AlertProperties = " + ValueDefinitionType.ToString(alertProperties), true);
                        compRequest.SetParameter(PropertyNames.AlertProperties, ValueDefinitionType.ToIDataObject(alertProperties));
                        break;
                    }

                case PropertyNames.AlertProperties:
                    {
                        alertProperties = AlertProperty.GetValueDefinitions(value as List<string>);
                        Utilities.LogMessage("Set GetSingleAlertDetails.AlertProperties = " + ValueDefinitionType.ToString(alertProperties), true);
                        compRequest.SetParameter(PropertyNames.AlertProperties, ValueDefinitionType.ToIDataObject(alertProperties));
                        break;
                    }

                case PropertyNames.Refresh:
                    {
                        Utilities.LogMessage("Set GetSingleAlertDetails.Refresh = true", true);
                        compRequest.SetParameter(PropertyNames.Refresh, value);
                        break;
                    }

                default:
                    {
                        throw new Exception("Cannot set this property:" + propertyName);
                    }
            }
        }

        protected override bool ShouldWait
        {
            get
            {
                return (alertId != Guid.Empty) &&
                       (alertProperties != null);
            }
        }

        /// <summary>
        /// Id of the composition in the MP
        /// </summary>
        protected override string QueryName
        {
            get 
            { 
                return "Microsoft.SystemCenter.Visualization.Library!GetSingleAlertDetailsQuery"; 
            }
        }

        #endregion

        #region private methods

        protected override Dictionary<string, object> GetDefaultQueryParameters()
        {
            return new Dictionary<string, object>
                       {
                           {PropertyNames.Id, alertId},
                           {PropertyNames.AlertProperties, ValueDefinitionType.ToIDataObject(AlertProperties)},
                           {PropertyNames.Output, GetDefaultOutput()},
                           {PropertyNames.DisplayStrings, GetDefaultDisplayStrings()}
                       };
        }

        private static IEnumerable<ValueDefinitionType> GetDefaultAlertProperties()
        {
             return AlertProperty.ValueDefinitions.Values;
        }

        #endregion

        /// <summary>
        /// String form of the parameters that is to be used for logging.
        /// </summary>
        /// <returns></returns>
        public override string LogParameters()
        {
            var newLine = Environment.NewLine;

            return "Parameters: " + newLine +
                    PropertyNames.Id + " : " + this.alertId + newLine +
                   PropertyNames.AlertProperties + " : " + ValueDefinitionType.ToString(this.AlertProperties);
        }
    }
}
