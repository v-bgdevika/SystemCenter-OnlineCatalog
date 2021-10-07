using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EnterpriseManagement.Monitoring.DataProviders;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.DataQuery.SchemaTypes;
using Mom.Test.UI.Core.GenericDataQuery;

namespace Mom.Test.UI.Core.DataQuery.NetworkDashboards
{
    public class GenericPaneEntityQuery : GenericDataQuery.DataQuery
    {
        #region Property Names

        new public class PropertyNames
        {
            public const string ManagedEntityId = "ManagedEntityId";
            public const string Output = "Output";
            public const string Properties = "PropertyNames";
        }

        #endregion

        #region private variables

        private Guid managedEntityId;
        private List<string> properties = new List<string>();

        #endregion

        #region public properties

        public Guid ManagedEntityId
        {
            get { return managedEntityId; }
            private set { managedEntityId = value; }
        }

        public List<string> Properties
        {
            get { return this.properties; }
            private set { properties = value; }
        }

        #endregion

        protected override Dictionary<string, object> GetDefaultQueryParameters()
        {
            return new Dictionary<string, object>
                       {
                           {PropertyNames.ManagedEntityId, Guid.Empty},
                           {PropertyNames.Properties, new List<string>() },
                           {PropertyNames.Output, GetDefaultOutput()},
                       };
        }

        protected override bool ShouldWait
        {
            get { return true; }
        }

        protected override string QueryName
        {
            get { return "Microsoft.SystemCenter.Visualization.Network.Dashboard!Microsoft.SystemCenter.Visualization.GenericPaneEntityQuery"; }
        }

        protected override void SetPropertyInternal(string propertyName, object value)
        {
            switch (propertyName)
            {
                case PropertyNames.ManagedEntityId:
                    {
                        ManagedEntityId = (Guid)value;
                        Utilities.LogMessage("Set GenericPaneEntityQuery.ManagedEntityId: " + ManagedEntityId, true);
                        compRequest.SetParameter(PropertyNames.ManagedEntityId, ManagedEntityId);
                        break;
                    }

                case PropertyNames.Properties:
                    {
                        Properties = value as List<string>;
                        Utilities.LogMessage("Set GenericPaneEntityQuery.PropertyNames: " + Properties.Count(), true);
                        compRequest.SetParameter(PropertyNames.Properties, Properties);
                        break;
                    }
                default:
                    {
                        throw new Exception("Cannot set this property:" + propertyName);
                    }
            }
        }

        public override string LogParameters()
        {
            var newLine = Environment.NewLine;

            return "Parameters: " + newLine +
                   PropertyNames.ManagedEntityId + " : " + this.ManagedEntityId + newLine +
                   PropertyNames.Properties + " : " + this.Properties.Count() + newLine;
        }
    }
}
