namespace Mom.Test.UI.Core.Console.MomControls.Dashboards.App360Dashboard
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.IO;
    using System.Xml.Linq;
    using Maui.Core;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
    using Mom.Test.UI.Core.ResourceLoader;
    using Maui.Core.Utilities;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
    using Microsoft.EnterpriseManagement;
    using Microsoft.EnterpriseManagement.Common;
    using Microsoft.EnterpriseManagement.Configuration;
    using Microsoft.EnterpriseManagement.Monitoring;
    #endregion

    public partial class ApplicationOverviewDashboard : Dashboard
    {
        public class PerfChartWidgetCommon : ChartWithLegendViewHost
        {
            #region Constants

            // There is a know MAUI issue that it returns all column headers under the scope of the whole main window 
            // no matter what parent window you pass, hence we need to hardcode the index of each column header
            private const int chIndexTarget = 9;
            private const int chIndexPath = 10;
            private const int chIndexLastValue = 11;
            private const int chIndexMinValue = 12;
            private const int chIndexMaxValue = 13;
            private const int chIndexAvgValue = 14;

            #endregion

            #region Constructor

            public PerfChartWidgetCommon(Window knownWindow)
                : base(knownWindow)
            {
            }

            #endregion
        }
    }
}
