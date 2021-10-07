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
    public class GetNetworkNodeVicinityData : GenericDataQuery.DataQuery
    {
        #region Property Names

        new public class PropertyNames
        {
            public const string TargetId = "TargetId";
            public const string SelectedItem = "SelectedItem";
            public const string Hops = "Hops";
            public const string ShowComputers = "ShowComputers";
            public const string Refresh = "Refresh";
            public const string ItemsToGlobalSnapshot = "ItemsToGlobalSnapshot";
            public const string ItemsToMerge = "ItemsToMerge";
        }

        #endregion
        
        #region private variables

        private Guid targetId;
        private IDataObject selectedItem;
        private int hops;
        private bool showComputers;

        #endregion

        #region public properties

        public Guid TargetId
        {
            get { return targetId; }
            private set { targetId = value; }
        }

        public int Hops
        {
            get { return hops; }
            private set { hops = value; }
        }

        public bool ShowComputers
        {
            get { return showComputers; }
            private set { showComputers = value; }
        }

        #endregion

        protected override bool ShouldWait
        {
            get { return true; }
        }

        protected override string QueryName
        {
            get { return "Microsoft.SystemCenter.Visualization.Network.Dashboard!MsScVsNtDb.GetNetworkNodeVicinityData"; }
        }

        protected override Dictionary<string, object> GetDefaultQueryParameters()
        {
            return new Dictionary<string, object>
                       {
                           {PropertyNames.TargetId, Guid.Empty},
                           {PropertyNames.Hops, 0},
                           {PropertyNames.ShowComputers, false},
                           {PropertyNames.ItemsToGlobalSnapshot, GetDefaultOutput()},
                           {PropertyNames.ItemsToMerge, GetDefaultOutput()},
                       };
        }

        protected override void SetPropertyInternal(string propertyName, object value)
        {
            switch (propertyName)
            {
                case PropertyNames.TargetId:
                    {
                        TargetId = (Guid)value;
                        Utilities.LogMessage("Set GetNetworkNodeVicinityData.TargetId: " + TargetId, true);
                        compRequest.SetParameter(PropertyNames.TargetId, TargetId);
                        break;
                    }

                case PropertyNames.Hops:
                    {
                        Hops = (int)value;
                        Utilities.LogMessage("Set GetNetworkNodeVicinityData.Hops: " + Hops, true);
                        compRequest.SetParameter(PropertyNames.Hops, Hops);
                        break;
                    }

                case PropertyNames.ShowComputers:
                    {
                        ShowComputers = (bool)value;
                        Utilities.LogMessage("Set GetNetworkNodeVicinityData.ShowComputers: " + TargetId, true);
                        compRequest.SetParameter(PropertyNames.ShowComputers, ShowComputers);
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
                   PropertyNames.TargetId + " : " + this.TargetId + newLine +
                   PropertyNames.Hops + " : " + this.Hops + newLine +
                   PropertyNames.ShowComputers + " : " + this.ShowComputers + newLine;
        }
    }
}
