using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.EnterpriseManagement.Monitoring.UnitComponents.Data;
using Mom.Test.UI.Core.Common;

namespace Mom.Test.UI.Core.GenericDataQuery
{
    public class GetAlertDetailsQuery : DataQuery
    {
        #region private fields

        private IEnumerable<ValueDefinitionType> properties;
        private object input;
        private bool singleObject = true;
        private object displayStrings;

        #endregion

        #region public properties

        private object Input
        {
            get { return input ?? (input = GetDefaultInput()); }
            set { input = value; }
        }

        public IEnumerable<ValueDefinitionType> Properties
        {
            get { return properties ?? (properties = new List<ValueDefinitionType>(GetDefaultProperties())); }
            set { properties = value; }
        }

        public bool SingleObject
        {
            get { return singleObject; }
            set { singleObject = value; }
        }

        public object DisplayStrings
        {
            get { return displayStrings; }
            set { displayStrings = value; }
        }

        #endregion

        #region Overridden properties

        protected override Dictionary<string, object> QueryParameters
        {
            get { return queryParameters ?? (queryParameters = GetDefaultQueryParameters()); }
        }

        protected override bool ShouldWait
        {
            get { return (input != null) && (properties != null); }
        }

        protected override string QueryName
        {
            get { return "Microsoft.SystemCenter.Visualization.Library!GetAlertDetails"; }
        }

        #endregion        

        #region default values

        private Dictionary<string, object> GetDefaultQueryParameters()
        {
            return new Dictionary<string, object>
                       {
                           {"Properties", ValueDefinitionType.ToIDataObject(Properties)},
                           {"Input", Input},
                           {"Output", GetDefaultOutput()},
                           {"SingleObject", SingleObject},
                           {"DisplayStrings", DisplayStrings},
                           {"ConnectionSessionTicket", UnityContainerHelpers.GetConnectionSessionTicket()}
                       };
        }

        internal static IEnumerable<ValueDefinitionType> GetDefaultProperties()
        {
            return AlertProperty.ValueDefinitions.Values;
        }

        #endregion

        #region Overridden methods

        protected override void SetPropertyInternal(string propertyName, object value)
        {
            switch (propertyName)
            {
                case "Properties_Inclusion":
                    {
                        Properties = GetColumns(Properties, value as List<ValueDefinitionType>, true);
                        compRequest.SetParameter("Properties", ValueDefinitionType.ToIDataObject(Properties));
                        break;
                    }

                case "Properties_Exclusion":
                    {
                        Properties = GetColumns(Properties, value as List<ValueDefinitionType>, false);
                        compRequest.SetParameter("Properties", ValueDefinitionType.ToIDataObject(Properties));
                        break;
                    }

                case "Input":
                    {
                        Input = value;
                        compRequest.SetParameter("Input", Input as IEnumerable<object>);
                        break;
                    }

                case "SingleObject":
                    {
                        SingleObject = (bool) value;
                        compRequest.SetParameter("SingleObject", SingleObject);
                        break;
                    }

                default:
                    {
                        throw new Exception("Cannot set this property:" + propertyName);
                    }
            }
        }

        #endregion
    }
}
