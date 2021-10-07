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
    public class GetManagedEntityAvailabilityPercentageData : Mom.Test.UI.Core.GenericDataQuery.DataQuery
    {
        #region Property Names

        new public class PropertyNames
        {
            public const string TargetId = "TargetId";
            public const string StartDateTime = "StartDateTime";
            public const string EndDateTime = "EndDateTime";
            public const string GoodStates1 = "GoodStates1";
            public const string GoodStates2 = "GoodStates2";
            public const string GoodStates3 = "GoodStates3";
            public const string GoodStates4 = "GoodStates4";
            public const string GoodStates5 = "GoodStates5";
            public const string GoodStates6 = "GoodStates6";
            public const string GoodStates7 = "GoodStates7";
            public const string GoodStates8 = "GoodStates8";
            public const string Output = "Output";
        }

        #endregion

        #region private fields

        private Guid targetId;
        private DateTime startDateTime;
        private DateTime endDateTime;
        private int goodStates1;
        private int goodStates2;
        private int goodStates3;
        private int goodStates4;
        private int goodStates5;
        private int goodStates6;
        private int goodStates7;
        private int goodStates8;

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

        public DateTime EndDateTime
        {
            get { return endDateTime; }
            set { endDateTime = value; }
        }

        public int GoodStates1
        {
            get { return goodStates1; }
            set { goodStates1 = value; }
        }

        public int GoodStates2
        {
            get { return goodStates2; }
            set { goodStates2 = value; }
        }

        public int GoodStates3
        {
            get { return goodStates3; }
            set { goodStates3 = value; }
        }

        public int GoodStates4
        {
            get { return goodStates4; }
            set { goodStates4 = value; }
        }

        public int GoodStates5
        {
            get { return goodStates5; }
            set { goodStates5 = value; }
        }

        public int GoodStates6
        {
            get { return goodStates6; }
            set { goodStates6 = value; }
        }

        public int GoodStates7
        {
            get { return goodStates7; }
            set { goodStates7 = value; }
        }

        public int GoodStates8
        {
            get { return goodStates8; }
            set { goodStates8 = value; }
        }

        #endregion

        protected override bool ShouldWait
        {
            get { return true; }
        }

        protected override string QueryName
        {
            get { return "Microsoft.SystemCenter.Visualization.Network.Dashboard!MsScVsNtDb.GetManagedEntityAvailabilityPercentageData"; }
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
                        Utilities.LogMessage("Set GetManagedEntityAvailabilityPercentageData.TargetId: " + TargetId, true);
                        compRequest.SetParameter(PropertyNames.TargetId, TargetId);
                        break;
                    }
                case PropertyNames.StartDateTime:
                    {
                        StartDateTime = (DateTime)value;
                        Utilities.LogMessage("Set GetManagedEntityAvailabilityPercentageData.StartDateTime: " + StartDateTime, true);
                        compRequest.SetParameter(PropertyNames.StartDateTime, StartDateTime);
                        break;
                    }
                case PropertyNames.EndDateTime:
                    {
                        EndDateTime = (DateTime)value;
                        Utilities.LogMessage("Set GetManagedEntityAvailabilityPercentageData.EndDateTime: " + EndDateTime, true);
                        compRequest.SetParameter(PropertyNames.EndDateTime, EndDateTime);
                        break;
                    }
                case PropertyNames.GoodStates1:
                    {
                        GoodStates1 = (int)value;
                        Utilities.LogMessage("Set GetManagedEntityAvailabilityPercentageData.GoodStates1: " + GoodStates1, true);
                        compRequest.SetParameter(PropertyNames.GoodStates1, GoodStates1);
                        break;
                    }
                case PropertyNames.GoodStates2:
                    {
                        GoodStates2 = (int)value;
                        Utilities.LogMessage("Set GetManagedEntityAvailabilityPercentageData.GoodStates2: " + GoodStates2, true);
                        compRequest.SetParameter(PropertyNames.GoodStates2, GoodStates2);
                        break;
                    }
                case PropertyNames.GoodStates3:
                    {
                        GoodStates3 = (int)value;
                        Utilities.LogMessage("Set GetManagedEntityAvailabilityPercentageData.GoodStates3: " + GoodStates3, true);
                        compRequest.SetParameter(PropertyNames.GoodStates3, GoodStates3);
                        break;
                    }
                case PropertyNames.GoodStates4:
                    {
                        GoodStates4 = (int)value;
                        Utilities.LogMessage("Set GetManagedEntityAvailabilityPercentageData.GoodStates4: " + GoodStates4, true);
                        compRequest.SetParameter(PropertyNames.GoodStates4, GoodStates4);
                        break;
                    }
                case PropertyNames.GoodStates5:
                    {
                        GoodStates5 = (int)value;
                        Utilities.LogMessage("Set GetManagedEntityAvailabilityPercentageData.GoodStates5: " + GoodStates5, true);
                        compRequest.SetParameter(PropertyNames.GoodStates5, GoodStates5);
                        break;
                    }
                case PropertyNames.GoodStates6:
                    {
                        GoodStates6 = (int)value;
                        Utilities.LogMessage("Set GetManagedEntityAvailabilityPercentageData.GoodStates6: " + GoodStates6, true);
                        compRequest.SetParameter(PropertyNames.GoodStates6, GoodStates6);
                        break;
                    }
                case PropertyNames.GoodStates7:
                    {
                        GoodStates7 = (int)value;
                        Utilities.LogMessage("Set GetManagedEntityAvailabilityPercentageData.GoodStates7: " + GoodStates7, true);
                        compRequest.SetParameter(PropertyNames.GoodStates7, GoodStates7);
                        break;
                    }
                case PropertyNames.GoodStates8:
                    {
                        GoodStates8 = (int)value;
                        Utilities.LogMessage("Set GetManagedEntityAvailabilityPercentageData.GoodStates8: " + GoodStates8, true);
                        compRequest.SetParameter(PropertyNames.GoodStates8, GoodStates8);
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
                   PropertyNames.StartDateTime + " : " + this.StartDateTime + newLine +
                   PropertyNames.EndDateTime + " : " + this.EndDateTime + newLine +
                   PropertyNames.GoodStates1 + " : " + this.GoodStates1 + newLine +
                   PropertyNames.GoodStates2 + " : " + this.GoodStates2 + newLine +
                   PropertyNames.GoodStates3 + " : " + this.GoodStates3 + newLine +
                   PropertyNames.GoodStates4 + " : " + this.GoodStates4 + newLine +
                   PropertyNames.GoodStates5 + " : " + this.GoodStates5 + newLine +
                   PropertyNames.GoodStates6 + " : " + this.GoodStates6 + newLine +
                   PropertyNames.GoodStates7 + " : " + this.GoodStates7 + newLine +
                   PropertyNames.GoodStates8 + " : " + this.GoodStates8 + newLine;
        }

    }
}
