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
    #endregion

    public partial class ApplicationOverviewDashboard : Dashboard
    {
        [Resource(ID = "Title")]
        private string dashboardTitle;
        public static string expectedDashboardTitle;

        private const int TIME_OUT = 15000;
        private XDocument resourceDocument = null;

        private string distributedAppName = null;

        private DistributedApplicationWidget distributedApplication = null;
        private ComponentsWidget componentsState = null;
        private PerfChartWidget1 perfChart1 = null;
        private PerfChartWidget2 perfChart2 = null;
        private PerfChartWidget3 perfChart3 = null;
        private AllAlertsWidget allActiveAlerts = null;

        public class QIDs
        {
            public const string distributedApplicationQID = ";[UIA]AutomationId = 'DistributedApplicationStateRegion'";
            public const string componentsQID = ";[UIA]AutomationId = 'ComponentsWidgetRegion'";
            public const string perfChart1QID = ";[UIA]AutomationId = 'PerfChart1Region'";
            public const string perfChart2QID = ";[UIA]AutomationId = 'PerfChart2Region'";
            public const string perfChart3QID = ";[UIA]AutomationId = 'PerfChart3Region'";
            public const string activeAlertsQID = ";[UIA]AutomationId = 'AllAlertsWidgetRegion'";
        }

        public class Strings
        {
            // string for the navigation link text
            public static string dashboardNavigationLink = Utilities.GetDisplayStringForComponent("Microsoft.SystemCenter.ApplicationMonitoring.360.Template.Dashboards.ApplicationOverview");

            // string for the pivot window view pane title
            public static string dashboardViewPaneTitle = Utilities.GetDisplayStringForComponent("Microsoft.SystemCenter.ApplicationMonitoring.360.Template.Dashboards.ApplicationOverview");
        }

        #region Constructor

        public ApplicationOverviewDashboard(Window knownWindow, string distributedAppName)
            : base(knownWindow)
        {
            SDKConnectionManager.Init(((MachineInfo)Topology.MomServersInfo[0]).MachineName);
            ResourceLoader.Connection = Utilities.ConnectToManagementServer(((MachineInfo)Topology.MomServersInfo[0]).MachineName);
            var assembly = Assembly.GetExecutingAssembly();
            var stream = new StreamReader(assembly.GetManifestResourceStream("Mom.Test.UI.Core.Console.MomControls.Dashboards.App360Dashboard.360DashboardResource.xml"));

            this.resourceDocument = XDocument.Load(stream);
            XElement embeddedComponentResource = ResourceLoader.GetSection("ApplicationOverviewDashboard", this.resourceDocument);
            ResourceLoader.LoadResources(this, embeddedComponentResource);

            expectedDashboardTitle = dashboardTitle;

            this.distributedAppName = distributedAppName;
        }

        #endregion

        #region Properties

        public DistributedApplicationWidget DistributedApplication
        {
            get
            {
                if (this.distributedApplication == null)
                {
                    this.distributedApplication = new DistributedApplicationWidget(
                        new Window(this, new QID(QIDs.distributedApplicationQID), TIME_OUT),
                        ResourceLoader.GetSection("DistributedApplicationWidget", this.resourceDocument),
                        this.distributedAppName);
                    this.distributedApplication.WaitForReady();
                }
                return this.distributedApplication;
            }
        }

        public ComponentsWidget ComponentsState
        {
            get
            {
                if (this.componentsState == null)
                {
                    this.componentsState = new ComponentsWidget(
                        new Window(this, new QID(QIDs.componentsQID), TIME_OUT),
                        ResourceLoader.GetSection("ComponentsWidget", this.resourceDocument),
                        this.distributedAppName);
                    this.componentsState.WaitForReady();
                }
                return this.componentsState;
            }
        }

        public PerfChartWidget1 PerfChart1
        {
            get
            {
                if (this.perfChart1 == null)
                {
                    this.perfChart1 = new PerfChartWidget1(
                        new Window(this, new QID(QIDs.perfChart1QID), TIME_OUT),
                        ResourceLoader.GetSection("PerfChart1Widget", this.resourceDocument));
                    this.perfChart1.WaitForReady();
                }
                return this.perfChart1;
            }
        }

        public PerfChartWidget2 PerfChart2
        {
            get
            {
                if (this.perfChart2 == null)
                {
                    this.perfChart2 = new PerfChartWidget2(
                        new Window(this, new QID(QIDs.perfChart2QID), TIME_OUT),
                        ResourceLoader.GetSection("PerfChart2Widget", this.resourceDocument));
                    this.perfChart2.WaitForReady();
                }
                return this.perfChart2;
            }
        }

        public PerfChartWidget3 PerfChart3
        {
            get
            {
                if (this.perfChart3 == null)
                {
                    this.perfChart3 = new PerfChartWidget3(
                        new Window(this, new QID(QIDs.perfChart3QID), TIME_OUT),
                        ResourceLoader.GetSection("PerfChart3Widget", this.resourceDocument));
                    this.perfChart3.WaitForReady();
                }
                return this.perfChart3;
            }
        }

        public AllAlertsWidget AllActiveAlerts
        {
            get
            {
                if (this.allActiveAlerts == null)
                {
                    this.allActiveAlerts = new AllAlertsWidget(
                        new Window(this, new QID(QIDs.activeAlertsQID), TIME_OUT),
                        ResourceLoader.GetSection("AllAlertsWidget", this.resourceDocument));
                    this.allActiveAlerts.WaitForReady();
                }
                return this.allActiveAlerts;
            }
        }

        #endregion

        #region Public Methods

        public bool VerifyDashboardTitle()
        {
            if (String.Equals(this.TitleText.Text.Trim(), expectedDashboardTitle))
            {
                Utilities.LogMessage("ApplicationOverviewDashboard.VerifyDashboardTitle :: Dashboard title matches.");
                return true;
            }
            else
            {
                Utilities.LogMessage("ApplicationOverviewDashboard.VerifyDashboardTitle :: Dashboard title mismatches. Expected title: " +
                    expectedDashboardTitle +
                    ", actual title: " +
                    this.TitleText.Text.Trim());
                return false;
            }
        }

        public bool VerifyWidgetTitle()
        {
            string expectedTitle = null;
            string actualTitle = null;
            bool match = false;
            if (!String.Equals(this.DistributedApplication.Title.Text.Trim(), DistributedApplicationWidget.expectedWidgetTitle))
            {
                expectedTitle = DistributedApplicationWidget.expectedWidgetTitle;
                actualTitle = this.DistributedApplication.Title.Text.Trim();
            }
            else if (!String.Equals(this.ComponentsState.Title.Text.Trim(), ComponentsWidget.expectedWidgetTitle))
            {
                expectedTitle = ComponentsWidget.expectedWidgetTitle;
                actualTitle = this.ComponentsState.Title.Text.Trim();
            }
            else if (!String.Equals(this.PerfChart1.Title.Text.Trim(), PerfChartWidget1.expectedWidgetTitle))
            {
                expectedTitle = PerfChartWidget1.expectedWidgetTitle;
                actualTitle = this.PerfChart1.Title.Text.Trim();
            }
            else if (!String.Equals(this.PerfChart2.Title.Text.Trim(), PerfChartWidget2.expectedWidgetTitle))
            {
                expectedTitle = PerfChartWidget2.expectedWidgetTitle;
                actualTitle = this.PerfChart2.Title.Text.Trim();
            }
            else if (!String.Equals(this.PerfChart3.Title.Text.Trim(), PerfChartWidget3.expectedWidgetTitle))
            {
                expectedTitle = PerfChartWidget3.expectedWidgetTitle;
                actualTitle = this.PerfChart3.Title.Text.Trim();
            }
                //If there are some alerts in the alertwiget, actual alert widget title will contain alert count at the end
            else if (!(this.AllActiveAlerts.Title.Text.Trim().Contains(AllAlertsWidget.expectedWidgetTitle)))
            {
                expectedTitle = AllAlertsWidget.expectedWidgetTitle;
                actualTitle = this.AllActiveAlerts.Title.Text.Trim();
            }
            else
            {
                match = true;
            }

            if (match)
            {
                Utilities.LogMessage("ApplicationOverviewDashboard.VerifyWidgetTitle :: Titles of all contained widgets match.");
            }
            else
            {
                Utilities.LogMessage("ApplicationOverviewDashboard.VerifyWidgetTitle :: Title of widget mismatches. Expected title: " +
                    expectedTitle +
                    ", actual title: " +
                    actualTitle);
            }

            return match;
        }

        #endregion
    }
}
