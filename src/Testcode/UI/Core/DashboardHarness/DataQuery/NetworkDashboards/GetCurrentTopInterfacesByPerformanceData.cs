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
    public class GetCurrentTopInterfacesByPerformanceData : GenericDataQuery.DataQuery
    {
        #region Property Names

        new public class PropertyNames
        {
            public const string Output = "Output";
            public const string StartDateTime = "StartDateTime";
            public const string ObjectNames = "ObjectNames";
            public const string CounterNames = "CounterNames";
        }

        #endregion

        #region private variables

        private DateTime startDateTime;
        private IList<string> objectNames = new List<string>();
        private IList<string> counterNames = new List<string>();

        #endregion

        #region public properties

        public DateTime StartDateTime
        {
            get { return startDateTime; }
            private set { startDateTime = value; }
        }

        public IList<string> ObjectNames
        {
            get { return objectNames; }
            private set { objectNames = value; }
        }

        public IList<string> CounterNames
        {
            get { return counterNames; }
            private set { counterNames = value; }
        }

        #endregion

        protected override bool ShouldWait
        {
            get { return true; }
        }

        protected override string QueryName
        {
            get { return "Microsoft.SystemCenter.Visualization.Network.Dashboard!MsScVsNtDb.GetCurrentTopInterfacesByPerformanceData"; }
        }

        protected override Dictionary<string, object> GetDefaultQueryParameters()
        {
            return new Dictionary<string, object>
                       {
                           {PropertyNames.StartDateTime, DateTime.Now},
                           {PropertyNames.ObjectNames, new List<string>()},
                           {PropertyNames.CounterNames, new List<string>()},
                           {PropertyNames.Output, GetDefaultOutput()},
                       };
        }

        protected override void SetPropertyInternal(string propertyName, object value)
        {
            switch (propertyName)
            {
                case PropertyNames.StartDateTime:
                    {
                        StartDateTime = (DateTime)value;
                        Utilities.LogMessage("Set GetCurrentTopInterfacesByPerformanceData.StartDateTime: " + StartDateTime, true);
                        compRequest.SetParameter(PropertyNames.StartDateTime, StartDateTime);
                        break;
                    }
                case PropertyNames.ObjectNames:
                    {
                        ObjectNames = value as IList<string>;
                        Utilities.LogMessage("Set GetCurrentTopInterfacesByPerformanceData.ObjectNames.Count: " + ObjectNames.Count(), true);
                        compRequest.SetParameter(PropertyNames.ObjectNames, ObjectNames);
                        break;
                    }
                case PropertyNames.CounterNames:
                    {
                        CounterNames = value as IList<string>;
                        Utilities.LogMessage("Set GetCurrentTopInterfacesByPerformanceData.CounterNames.Count: " + CounterNames.Count(), true);
                        compRequest.SetParameter(PropertyNames.CounterNames, CounterNames);
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
                   PropertyNames.StartDateTime + " : " + this.StartDateTime + newLine +
                   PropertyNames.ObjectNames + " : " + this.ObjectNames.ToString() + newLine +
                   PropertyNames.CounterNames + " : " + this.CounterNames.ToString() + newLine;
        }

    }
}
