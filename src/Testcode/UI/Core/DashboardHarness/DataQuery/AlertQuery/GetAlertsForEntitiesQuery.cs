using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EnterpriseManagement.Monitoring.DataProviders;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.DataQuery.SchemaTypes;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class GetAlertsForEntitiesQuery : DataQuery
    {
        #region Property Names

        new public class PropertyNames
        {
            public const string ManagedEntities = "ManagedEntities";
            public const string AlertProperties = "AlertProperties";
            public const string AlertPropertiesExclusion = "AlertPropertiesExclusion";
            public const string AlertPropertiesInclusion = "AlertPropertiesInclusion";
            public const string CriteriaString = "CriteriaString";
            public const string SortProperties = "SortProperties";
            public const string Refresh = "Refresh";
            public const string Output = "Output";
            public const string DisplayStrings = "DisplayStrings";
        }

        #endregion

        #region private fields

        private IEnumerable<IDataObject> managedEntities; // list of managed entities for which the alerts are to be retreived.
        private IEnumerable<ValueDefinitionType> alertProperties; // alert properties
        private IEnumerable<SortValueDefinitionType> sortProperties; // properties by which the output will be sorted
        private string criteriaString; // criteria used to select the alert

        #endregion

        #region Overridden properties

        /// <summary>
        /// Id of the query in the MP
        /// </summary>
        protected override string QueryName
        {
            get { return "Microsoft.SystemCenter.Visualization.Library!GetAlertsForEntitiesQuery"; }
        }

        #endregion

        #region public properties

        /// <summary>
        /// criteria used to select the alert
        /// </summary>
        public string CriteriaString
        {
            get 
            { 
                return criteriaString ?? (criteriaString = null); 
            }
            
            set 
            { 
                criteriaString = value; 
            }
        }

        /// <summary>
        /// Alert properties
        /// </summary>
        public IEnumerable<ValueDefinitionType> AlertProperties
        {
            get 
            { 
                return alertProperties ?? (alertProperties = new List<ValueDefinitionType>(GetDefaultAlertProperties())); 
            }
        }

        /// <summary>
        /// list of managed entities for which the alerts are to be retreived.
        /// </summary>
        public IEnumerable<IDataObject> ManagedEntities
        {
            get 
            { 
                return managedEntities ?? (managedEntities = GetDefaultInput()); 
            }
            
            set 
            { 
                managedEntities = value; 
            }
        }

        /// <summary>
        /// properties by which the output will be sorted
        /// </summary>
        public IEnumerable<SortValueDefinitionType> SortProperties
        {
            get 
            {
                return sortProperties ?? (sortProperties = GetDefaultSortProperties()); 
            }
            
            set 
            { 
                sortProperties = value; 
            }
        }

        #endregion

        #region default values

        /// <summary>
        /// Default values used in the creation of the composition
        /// </summary>
        /// <returns></returns>
        protected override Dictionary<string, object> GetDefaultQueryParameters()
        {
            return new Dictionary<string, object>
                       {
                           {PropertyNames.ManagedEntities, ManagedEntities},
                           {PropertyNames.CriteriaString, CriteriaString},
                           {PropertyNames.SortProperties, SortValueDefinitionType.ToObservableCollection(SortProperties)},
                           {PropertyNames.AlertProperties, ValueDefinitionType.ToIDataObject(AlertProperties)},
                           {PropertyNames.Output, GetDefaultOutput()},
                           {PropertyNames.DisplayStrings, GetDefaultDisplayStrings()},
                       };
        }

        private static IEnumerable<ValueDefinitionType> GetDefaultAlertProperties()
        {
            return new List<ValueDefinitionType>(AlertProperty.ValueDefinitions.Values);
        }

        #endregion

        #region Overriden methods

        /// <summary>
        /// Specific implementation of the SetProperty
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        protected override void SetPropertyInternal(string propertyName, object value)
        {
            switch (propertyName)
            {
                case PropertyNames.ManagedEntities:
                    {
                        ManagedEntities = value as IEnumerable<IDataObject>;
                        Utilities.LogMessage("Set GetAlertsForEntitiesQuery.ManagedEntities: # of entities: " + ManagedEntities.Count(), true);
                        compRequest.SetParameter(PropertyNames.ManagedEntities, ManagedEntities);
                        break;
                    }

                case PropertyNames.AlertPropertiesExclusion:
                    {
                        var propertiesToBeDeleted = AlertProperty.GetValueDefinitions(value as List<string>);
                        alertProperties = CalculateNewColumnList(alertProperties, propertiesToBeDeleted, false);
                        Utilities.LogMessage("Set GetAlertsForEntitiesQuery.AlertProperties: " + ValueDefinitionType.ToString(alertProperties), true);
                        compRequest.SetParameter(PropertyNames.AlertProperties, ValueDefinitionType.ToIDataObject(alertProperties));
                        break;
                    }

                case PropertyNames.AlertPropertiesInclusion:
                    {
                        var additionalProperties = AlertProperty.GetValueDefinitions(value as List<string>);
                        alertProperties = CalculateNewColumnList(alertProperties, additionalProperties, true);
                        Utilities.LogMessage("Set GetAlertsForEntitiesQuery.AlertProperties: " + ValueDefinitionType.ToString(alertProperties), true);
                        compRequest.SetParameter(PropertyNames.AlertProperties, ValueDefinitionType.ToIDataObject(alertProperties));
                        break;
                    }

                case PropertyNames.AlertProperties:
                    {
                        alertProperties = AlertProperty.GetValueDefinitions(value as List<string>);
                        Utilities.LogMessage("Set GetAlertsForEntitiesQuery.AlertProperties: " + ValueDefinitionType.ToString(alertProperties), true);
                        compRequest.SetParameter(PropertyNames.AlertProperties, ValueDefinitionType.ToIDataObject(alertProperties));
                        break;
                    }

                case PropertyNames.CriteriaString:
                    {
                        CriteriaString = value as string;
                        Utilities.LogMessage("Set GetAlertsForEntitiesQuery.CriteriaString: " + CriteriaString, true);
                        compRequest.SetParameter(PropertyNames.CriteriaString, CriteriaString);
                        break;
                    }

                case PropertyNames.SortProperties:
                    {
                        SortProperties = AlertProperty.GetSortProperties(value as List<string>);
                        Utilities.LogMessage("Set GetAlertsForEntitiesQuery.SortProperties: " + SortValueDefinitionType.ToString(SortProperties), true);
                        compRequest.SetParameter(PropertyNames.SortProperties, SortValueDefinitionType.ToObservableCollection(SortProperties));
                        break;
                    }

                case PropertyNames.Refresh:
                    {
                        Utilities.LogMessage("Set GetAlertsForEntitiesQuery.Refresh = true ", true);
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
                return (managedEntities != null) && 
                       (managedEntities.Count() > 0) &&
                       (alertProperties != null);
            }
        }

        #endregion

        #region public methods

        /// <summary>
        /// String form of the parameters that is to be used for logging.
        /// </summary>
        /// <returns></returns>
        public override string LogParameters()
        {
            var newLine = Environment.NewLine;

            return "Parameters: " + newLine +
                   PropertyNames.AlertProperties + " : " + ValueDefinitionType.ToString(this.AlertProperties) + newLine +
                   PropertyNames.SortProperties + " : " + SortValueDefinitionType.ToString(this.SortProperties) + newLine +
                   PropertyNames.CriteriaString + " : " + this.CriteriaString;
        }

        #endregion
    }
}
