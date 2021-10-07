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
    using Mom.Test.UI.Core.Console.MomControls.DashboardGadgets.AlertComponent;
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
        public class AllAlertsWidget : AlertsView
        {
            [Resource(ID = "Title")]
            private string widgetTitle;
            public static string expectedWidgetTitle;

            #region Constructor

            public AllAlertsWidget(Window knownWindow, XElement element)
                : base(knownWindow, element)
            {
                ResourceLoader.LoadResources(this, element);

                expectedWidgetTitle = widgetTitle;
            }

            #endregion
        }
    }
}
