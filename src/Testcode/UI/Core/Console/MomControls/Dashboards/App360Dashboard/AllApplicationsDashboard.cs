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

    public partial class AllApplicationsDashboard : Dashboard
    {
        [Resource(ID = "Title")]
        private string dashboardTitle;
        public static string expectedDashboardTitle;

        private const int TIME_OUT = 15000;
        private XDocument resourceDocument = null;

        private AllApplicationsStateWidget allApplicationsState = null;
        private AllApplicationsSLAWidget allApplicationsSLA = null;

        public class QIDs
        {
            public const string allApplicationsStateQID = ";[UIA]AutomationId = 'AllApplicationsStateRegion'";
            public const string allApplicationsSLAQID = ";[UIA]AutomationId = 'AllApplicationsSLARegion'";
        }

        public class Strings
        {
            // string for tree node path of dashboard
            public static string dashboardTreeNodePath =
                NavigationPane.Strings.Monitoring +
                Core.Common.Constants.PathDelimiter +
                Utilities.GetFolderDisplayName(ManagementPackConstants.ApplicationMonitoringLibraryMP, ManagementPackConstants.ApplicationMonitoringUIRootFolder) +
                Core.Common.Constants.PathDelimiter +
                Utilities.GetDisplayStringForComponent("Microsoft.SystemCenter.ApplicationMonitoring.360.Template.Dashboards.AllApplicationsSummary");
        }

        #region Constructor
        /// <summary>
        /// All ApplicationDashboardConstructor
        /// </summary>
        /// <param name="knownWindow"></param>
        public AllApplicationsDashboard(Window knownWindow)
            : base(knownWindow)
        {

            SDKConnectionManager.Init(((MachineInfo)Topology.MomServersInfo[0]).MachineName);
            ResourceLoader.Connection = Utilities.ConnectToManagementServer(((MachineInfo)Topology.MomServersInfo[0]).MachineName);
            var assembly = Assembly.GetExecutingAssembly();
            var stream = new StreamReader(assembly.GetManifestResourceStream("Mom.Test.UI.Core.Console.MomControls.Dashboards.App360Dashboard.360DashboardResource.xml"));

            this.resourceDocument = XDocument.Load(stream);
            XElement embeddedComponentResource = ResourceLoader.GetSection("AllApplicationsDashboard", this.resourceDocument);
            ResourceLoader.LoadResources(this, embeddedComponentResource);

            expectedDashboardTitle = dashboardTitle;
        }

        #endregion

        #region Properties

        public AllApplicationsStateWidget AllApplicationsState
        {
            get
            {
                if (this.allApplicationsState == null)
                {
                    this.allApplicationsState = new AllApplicationsStateWidget(
                        new Window(this, new QID(QIDs.allApplicationsStateQID), TIME_OUT),
                        ResourceLoader.GetSection("AllApplicationsStateWidget", this.resourceDocument));
                    this.allApplicationsState.WaitForReady();
                }
                return this.allApplicationsState;
            }
        }

        public AllApplicationsSLAWidget AllApplicationsSLA
        {
            get
            {
                if (this.allApplicationsSLA == null)
                {
                    this.allApplicationsSLA = new AllApplicationsSLAWidget(
                        new Window(this, new QID(QIDs.allApplicationsSLAQID), TIME_OUT),
                        ResourceLoader.GetSection("AllApplicationsSLAWidget", this.resourceDocument));
                    this.allApplicationsSLA.WaitForReady();
                }
                return this.allApplicationsSLA;
            }
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Verify All Application Dashboard Title
        /// </summary>
        /// <returns></returns>
        public bool VerifyDashboardTitle()
        {
            if (String.Equals(this.TitleText.Text.Trim(), expectedDashboardTitle))
            {
                Utilities.LogMessage("AllApplicationsDashboard.VerifyDashboardTitle :: Dashboard title matches.");
                return true;
            }
            else
            {
                Utilities.LogMessage("AllApplicationsDashboard.VerifyDashboardTitle :: Dashboard title mismatches. Expected title: " +
                    expectedDashboardTitle +
                    ", actual title: " +
                    this.TitleText.Text.Trim());
                return false;
            }
        }

        /// <summary>
        /// Verify the Widgets title defined in all application dashboard
        /// </summary>
        /// <returns></returns>
        public bool VerifyWidgetTitle()
        {
            Utilities.LogMessage("VerifyWidgetTitle::");
            string expectedTitle = null;
            string actualTitle = null;
            bool match = false;
            if (!String.Equals(this.AllApplicationsState.Title.Text.Trim(), AllApplicationsStateWidget.expectedWidgetTitle))
            {
                expectedTitle = AllApplicationsStateWidget.expectedWidgetTitle;
                actualTitle = this.AllApplicationsState.Title.Text.Trim();
            }
            else if (!String.Equals(this.AllApplicationsSLA.Title.Text.Trim(), AllApplicationsSLAWidget.expectedWidgetTitle))
            {
                Utilities.LogMessage("ActualTitle:: " + this.AllApplicationsSLA.Title.Text.Trim());
                Utilities.LogMessage("AllApplicationsSLAWidget.expectedWidgetTitle::" + AllApplicationsSLAWidget.expectedWidgetTitle.ToString());
                expectedTitle = AllApplicationsSLAWidget.expectedWidgetTitle;
                actualTitle = this.AllApplicationsSLA.Title.Text.Trim();

            }
            else
            {
                match = true;
            }

            if (match)
            {
                Utilities.LogMessage("AllApplicationsDashboard.VerifyWidgetTitle :: Titles of all contained widgets match.");
            }
            else
            {
                Utilities.LogMessage("AllApplicationsDashboard.VerifyWidgetTitle :: Title of widget mismatches. Expected title: " +
                    expectedTitle +
                    ", actual title: " +
                    actualTitle);
            }

            return match;
        }

        #endregion
    }
}
