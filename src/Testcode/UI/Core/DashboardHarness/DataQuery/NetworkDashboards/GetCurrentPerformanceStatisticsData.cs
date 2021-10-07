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
    public class GetCurrentPerformanceStatisticsData : Mom.Test.UI.Core.GenericDataQuery.DataQuery
    {
        #region Property Names

        new public class PropertyNames
        {
            public const string TargetId = "TargetId";
            public const string StartDateTime = "StartDateTime";
            public const string PerformanceCounterItem = "PerformanceCounterItem";
            public const string Output = "Output";
        }

        #endregion

        #region private fields

        private Guid targetId;
        private DateTime startDateTime;
        private PerformanceCounterItem performanceCounterItem;

        #endregion

        #region public properties

        public Guid TargetId
        {
            get { return targetId; }
            set { targetId = value; }
        }

        public DateTime StartDateTime
        {
            get { return startDateTime; }
            set { startDateTime = value; }
        }

        public PerformanceCounterItem PerformanceCounterItem
        {
            get { return performanceCounterItem; }
            set { performanceCounterItem = value; }
        }

        #endregion

        protected override bool ShouldWait
        {
            get { return true; }
        }

        protected override string QueryName
        {
            get { return "Microsoft.SystemCenter.Visualization.Network.Dashboard!MsScVsNtDb.GetCurrentPerformanceStatisticsData"; }
        }

        protected override Dictionary<string, object> GetDefaultQueryParameters()
        {
            return new Dictionary<string, object>
                       {
                           {PropertyNames.TargetId, Guid.Empty},
                           {PropertyNames.Output, GetDefaultOutput()},
                       };
        }

        protected override void SetPropertyInternal(string propertyName, object value)
        {
            switch (propertyName)
            {
                case PropertyNames.TargetId:
                    {
                        TargetId = (Guid) value;
                        Utilities.LogMessage("Set GetCurrentPerformanceStatisticsData.TargetId: " + TargetId, true);
                        compRequest.SetParameter(PropertyNames.TargetId, TargetId);
                        break;
                    }
                case PropertyNames.StartDateTime:
                    {
                        StartDateTime = (DateTime)value;
                        Utilities.LogMessage("Set GetCurrentPerformanceStatisticsData.StartDateTime: " + StartDateTime, true);
                        compRequest.SetParameter(PropertyNames.StartDateTime, StartDateTime);
                        break;
                    }
                case PropertyNames.PerformanceCounterItem:
                    {
                        PerformanceCounterItem = (PerformanceCounterItem)value;
                        Utilities.LogMessage("Set GetCurrentPerformanceStatisticsData.PerformanceCounterItem: " + PerformanceCounterItem.ToString(), true);
                        compRequest.SetParameter(PropertyNames.PerformanceCounterItem, PerformanceCounterItem.GetIDataObject());
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
                   PropertyNames.StartDateTime + " : " + this.StartDateTime;
        }

    }
}
