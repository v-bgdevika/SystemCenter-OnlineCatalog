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
        public class DistributedApplicationWidget : DataGridViewHost
        {
            [Resource(ID = "Title")]
            private string widgetTitle;
            public static string expectedWidgetTitle;

            [Resource(ID = "ColumnHealth")]
            private string columnHealth;
            public static string expectedColumnHealth;

            [Resource(ID = "ColumnDisplayName")]
            private string columnDisplayName;
            public static string expectedColumnDisplayName;

            [Resource(ID = "ColumnMonitoredRequestsPerSecond")]
            private string columnMonitoredRequestsPerSecond;
            public static string expectedColumnMonitoredRequestsPerSecond;

            [Resource(ID = "ColumnAverageResponseTimeFromPOPs")]
            private string columnAverageResponseTimeFromPOPs;
            public static string expectedColumnAverageResponseTimeFromPOPs;

            [Resource(ID = "ColumnActiveCriticalAlerts")]
            private string columnActiveCriticalAlerts;
            public static string expectedColumnActiveCriticalAlerts;

            private string distributedAppName = null;

            #region Constants

            // There is a know MAUI issue that it returns all column headers under the scope of the whole main window 
            // no matter what parent window you pass, hence we need to hardcode the index of each column header
            private const int chIndexHealth = 0;
            private const int chIndexDisplayName = 1;
            private const int chIndexMonitoredRequestsPerSecond = 2;
            private const int chIndexAverageResponseTimeFromPOPs = 3;
            private const int chIndexActiveCriticalAlerts = 4;

            #endregion

            #region Constructor

            public DistributedApplicationWidget(Window knownWindow, XElement element, string distributedAppName)
                : base(knownWindow)
            {
                ResourceLoader.LoadResources(this, element);

                expectedWidgetTitle = widgetTitle;
                expectedColumnHealth = columnHealth;
                expectedColumnDisplayName = columnDisplayName;
                expectedColumnMonitoredRequestsPerSecond = columnMonitoredRequestsPerSecond;
                expectedColumnAverageResponseTimeFromPOPs = columnAverageResponseTimeFromPOPs;
                expectedColumnActiveCriticalAlerts = columnActiveCriticalAlerts;

                this.distributedAppName = distributedAppName;
            }

            #endregion

            #region Public Methods

            public bool VerifyColumHeaders()
            {
                if (String.Equals(this.DataGrid.ColumnHeaders[chIndexHealth].Trim(), expectedColumnHealth)
                    && String.Equals(this.DataGrid.ColumnHeaders[chIndexDisplayName].Trim(), expectedColumnDisplayName)
                    && String.Equals(this.DataGrid.ColumnHeaders[chIndexMonitoredRequestsPerSecond].Trim(), expectedColumnMonitoredRequestsPerSecond)
                    && String.Equals(this.DataGrid.ColumnHeaders[chIndexAverageResponseTimeFromPOPs].Trim(), expectedColumnAverageResponseTimeFromPOPs)
                    && String.Equals(this.DataGrid.ColumnHeaders[chIndexActiveCriticalAlerts].Trim(), expectedColumnActiveCriticalAlerts))
                {
                    Utilities.LogMessage("DistributedApplicationWidget.VerifyColumHeaders :: All column headers in widget match.");
                    return true;
                }
                else
                {
                    Utilities.LogMessage("DistributedApplicationWidget.VerifyColumHeaders :: There is column header in widget mismatches.");
                    return false;
                }
            }

            #endregion
        }
    }
}
