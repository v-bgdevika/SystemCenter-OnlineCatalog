namespace Mom.Test.UI.Core.Console.MomControls.Dashboards
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
    using Mom.Test.UI.Core.Console.Views.StateWidget;
    using Mom.Test.UI.Core.Console.Views.PerformanceChart;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
    #endregion

    public class OMSummaryDashboard : Dashboard
    {
        [Resource(ID = "Title")]
        private string title;
        public static string expectedDashboardTitle;

        [Resource(ID = "TreeNode")]
        private string treeNode;
        public static string dashboardTreeNode;

        private const int TIME_OUT = 5000;

        public XDocument dashboardDocument = null;

        public string dashboardTreeNodePath = null;

        private ManagementGroupFunctionsStateWidget managementGroupFunctionsView = null;

        private ManagementGroupInfrastructureStateWidget managementGroupInfrastructureView = null;

        private AgentHealthStatePerfWidget agentHealthStateView = null;

        private AgentConfigurationStateWidget agentConfigurationView = null;

        private AgentVersionsStateWidget agentVersionsView = null;

        public class QIDs
        {
            public const string managementGroupFunctionsQID = ";[UIA]AutomationId='SCOMViewHost' && Instance = '1'";

            public const string managementGroupInfrastructureQID = ";[UIA]AutomationId='SCOMViewHost' && Instance = '2'";

            public const string agentHealthStateQID = ";[UIA]AutomationId='SCOMViewHost' && Instance = '3'";

            public const string agentConfigurationQID = ";[UIA]AutomationId='SCOMViewHost' && Instance = '4'";

            public const string agentVersionsQID = ";[UIA]AutomationId='SCOMViewHost' && Instance = '5'";
        }

        public class Strings
        {
            public static string dashboardTreeNodePath =
                NavigationPane.Strings.Monitoring +
                Core.Common.Constants.PathDelimiter +
                Utilities.GetFolderDisplayName(ManagementPackConstants.SystemCenterOperationsManager2007MPName, "Microsoft.SystemCenter.OperationsManager.ViewFolder.Root") +
                Core.Common.Constants.PathDelimiter +
                Utilities.GetDisplayStringForComponent("MainDashboard");

            //there's a known issue that MAUI fetches all column headers on entir UI no matter what window scope is set, therefore hardcode column header index for this dashboard
            public const int indexCHDisplayName = 0;
            public const int indexCHHealth = 1;
            public const int indexCHShow = 2;
            public const int indexCHColor = 3;
            public const int indexCHHealthState = 4;
            public const int indexCHCountOfAgents = 5;
            public const int indexCHConfiguration = 6;
            public const int indexCHCountOfAgnetsByConfig = 7;
            public const int indexCHVersion = 8;
            public const int indexCHCumulativeUpdate = 9;
            public const int indexCHCountOfAgentsByVersion = 10;
        }

        public OMSummaryDashboard(Window knownWindow)
            : base(knownWindow)
        {
            SDKConnectionManager.Init(((MachineInfo)Topology.MomServersInfo[0]).MachineName);
            ResourceLoader.Connection = Utilities.ConnectToManagementServer(((MachineInfo)Topology.MomServersInfo[0]).MachineName);
            var assembly = Assembly.GetExecutingAssembly();
            var stream = new StreamReader(assembly.GetManifestResourceStream("Mom.Test.UI.Core.Console.MomControls.Dashboards.OMSummaryDashboardResource.xml"));

            this.dashboardDocument = XDocument.Load(stream);
            XElement embeddedComponentResource = ResourceLoader.GetSection("MainDashboard", this.dashboardDocument);
            ResourceLoader.LoadResources(this, embeddedComponentResource);

            expectedDashboardTitle = title;
            dashboardTreeNode = treeNode;
        }

        #region Properties

        public ManagementGroupFunctionsStateWidget ManagementGroupFunctionsView
        {
            get
            {
                if (this.managementGroupFunctionsView == null)
                {
                    this.managementGroupFunctionsView = new ManagementGroupFunctionsStateWidget(
                        new Window(this, new QID(QIDs.managementGroupFunctionsQID), TIME_OUT),
                        this.dashboardDocument);
                    this.managementGroupFunctionsView.WaitForReady();
                }
                return this.managementGroupFunctionsView;
            }
        }

        public ManagementGroupInfrastructureStateWidget ManagementGroupInfrastructureView
        {
            get
            {
                if (this.managementGroupInfrastructureView == null)
                {
                    this.managementGroupInfrastructureView = new ManagementGroupInfrastructureStateWidget(
                        new Window(this, new QID(QIDs.managementGroupInfrastructureQID), TIME_OUT),
                        this.dashboardDocument);
                    this.managementGroupInfrastructureView.WaitForReady();
                }
                return this.managementGroupInfrastructureView;
            }
        }

        public AgentHealthStatePerfWidget AgentHealthStateView
        {
            get
            {
                if (this.agentHealthStateView == null)
                {
                    this.agentHealthStateView = new AgentHealthStatePerfWidget(
                        new Window(this, new QID(QIDs.agentHealthStateQID), TIME_OUT),
                        this.dashboardDocument);
                    this.agentHealthStateView.WaitForReady();
                }
                return this.agentHealthStateView;
            }
        }

        public AgentConfigurationStateWidget AgentConfigurationView
        {
            get
            {
                if (this.agentConfigurationView == null)
                {
                    this.agentConfigurationView = new AgentConfigurationStateWidget(
                        new Window(this, new QID(QIDs.agentConfigurationQID), TIME_OUT),
                        this.dashboardDocument);
                    this.agentConfigurationView.WaitForReady();
                }
                return this.agentConfigurationView;
            }
        }

        public AgentVersionsStateWidget AgentVersionsView
        {
            get
            {
                if (this.agentVersionsView == null)
                {
                    this.agentVersionsView = new AgentVersionsStateWidget(
                        new Window(this, new QID(QIDs.agentVersionsQID), TIME_OUT),
                        this.dashboardDocument);
                    this.agentVersionsView.WaitForReady();
                }
                return this.agentVersionsView;
            }
        }

        #endregion

        public bool VerifyDashboardTitle()
        {
            if (!(String.Equals(this.TitleText.Text.Trim(), expectedDashboardTitle)))
            {
                Utilities.LogMessage("OMSummaryDashboard.VerifyDashboardTitle :: Dashboard title mismatch.");
                return false;
            }
            return true;
        }

        public bool VerifyDashboardComponents()
        {
            return (this.ManagementGroupFunctionsView.VerifyTitle() &&
                this.ManagementGroupInfrastructureView.VerifyTitle() &&
                this.AgentHealthStateView.VerifyTitle() &&
                this.AgentConfigurationView.VerifyTitle() &&
                this.AgentVersionsView.VerifyTitle());
        }
    }

    public class ManagementGroupFunctionsStateWidget : StateWidget
    {
        [Resource(ID = "Title")]
        private string title;
        public static string expectedTitle;

        [Resource(ID = "DisplayNameColumnHeader")]
        private string displayName;
        public static string expectedDisplayNameColumnHeader;

        [Resource(ID = "HealthColumnHeader")]
        private string health;
        public static string expectedHealthColumnHeader;

        public ManagementGroupFunctionsStateWidget(Window knownWindow, XDocument dashboardDocument)
            : base(knownWindow)
        {
            XElement embeddedComponentResource = ResourceLoader.GetSection("ManagementGroupFunctions", dashboardDocument);
            ResourceLoader.LoadResources(this, embeddedComponentResource);

            expectedTitle = title;
            expectedDisplayNameColumnHeader = displayName;
            expectedHealthColumnHeader = health;
        }

        public bool VerifyTitle()
        {
            // StateWidget title has appended dynamic number which indicates the number of rows in the widget
            if (!(this.Title.Text.Contains(expectedTitle)))
            {
                Utilities.LogMessage("ManagementGroupFunctionsStateWidget.VerifyTitle :: Title mismatch");
                return false;
            }
            return true;
        }

        public bool VerifyColumnHeaders()
        {
            if (String.Equals(this.DataGrid.ColumnHeaders[OMSummaryDashboard.Strings.indexCHDisplayName].Trim(), expectedDisplayNameColumnHeader) &&
                String.Equals(this.DataGrid.ColumnHeaders[OMSummaryDashboard.Strings.indexCHHealth].Trim(), expectedHealthColumnHeader))
            {
                Utilities.LogMessage("ManagementGroupFunctionsStateWidget.VerifyColumnHeaders :: Successfully verified column headers");
                return true;
            }
            else
            {
                Utilities.LogMessage("ManagementGroupFunctionsStateWidget.VerifyColumnHeaders :: Failed in verifying column headers");
                return false;
            }
        }
    }

    public class ManagementGroupInfrastructureStateWidget : StateWidget
    {
        [Resource(ID = "Title")]
        private string title;
        public static string expectedTitle;

        [Resource(ID = "DisplayNameColumnHeader")]
        private string displayName;
        public static string expectedDisplayNameColumnHeader;

        [Resource(ID = "HealthColumnHeader")]
        private string health;
        public static string expectedHealthColumnHeader;

        public ManagementGroupInfrastructureStateWidget(Window knownWindow, XDocument dashboardDocument)
            : base(knownWindow)
        {
            XElement embeddedComponentResource = ResourceLoader.GetSection("ManagementGroupInfrastructure", dashboardDocument);
            ResourceLoader.LoadResources(this, embeddedComponentResource);

            expectedTitle = title;
            expectedDisplayNameColumnHeader = displayName;
            expectedHealthColumnHeader = health;
        }

        public bool VerifyTitle()
        {
            // StateWidget title has appended dynamic number which indicates the number of rows in the widget
            if (!(this.Title.Text.Contains(expectedTitle)))
            {
                Utilities.LogMessage("ManagementGroupInfrastructureStateWidget.VerifyTitle :: Title mismatch");
                return false;
            }
            return true;
        }

        public bool VerifyColumnHeaders()
        {
            if (String.Equals(this.DataGrid.ColumnHeaders[OMSummaryDashboard.Strings.indexCHDisplayName].Trim(), expectedDisplayNameColumnHeader) &&
                String.Equals(this.DataGrid.ColumnHeaders[OMSummaryDashboard.Strings.indexCHHealth].Trim(), expectedHealthColumnHeader))
            {
                Utilities.LogMessage("ManagementGroupInfrastructureStateWidget.VerifyColumnHeaders :: Successfully verified column headers");
                return true;
            }
            else
            {
                Utilities.LogMessage("ManagementGroupInfrastructureStateWidget.VerifyColumnHeaders :: Successfully verified column headers");
                return false;
            }
        }
    }

    public class AgentHealthStatePerfWidget : ViewHost //The Mom.Test.UI.Core.Console.Views.PerformanceChart.PerformanceChart class is not suitable for this case
    {
        [Resource(ID = "Title")]
        private string title;
        public static string expectedTitle;

        [Resource(ID = "HealthStateColumnHeader")]
        private string healthState;
        public static string expectedHealthStateColumnHeader;

        [Resource(ID = "CountOfAgentsColumnHeader")]
        private string countOfAgents;
        public static string expectedCountOfAgentsColumnHeader;

        [Resource(ID = "Total")]
        private string total;
        public static string totalCounterInstance;

        [Resource(ID = "Unavailable")]
        private string unavailable;
        public static string unavailableCounterInstance;

        [Resource(ID = "Unmonitored")]
        private string unmonitored;
        public static string unmonitoredCounterInstance;

        [Resource(ID = "Healthy")]
        private string healthy;
        public static string healthyCounterInstance;

        [Resource(ID = "Critical")]
        private string critical;
        public static string criticalCounterInstance;

        [Resource(ID = "Warning")]
        private string warning;
        public static string warningCounterInstance;

        private DataGridControl legendGrid = null;

        private Dictionary<string, int> healthStateCounters = null;

        public DataGridControl LegendGrid
        {
            get
            {
                if (this.legendGrid == null)
                {
                    this.legendGrid = this.GetLegendGrid();
                }
                return this.legendGrid;
            }
        }

        /// <summary>
        /// This is the dictionary that contains key value pair of perf counter instance name and value
        /// Key of the dictionary is string of perf counter instance name
        /// Value of the dictionary is integar of perf counter value
        /// </summary>
        public Dictionary<string, int> HealthStateCounters
        {
            get
            {
                if (this.healthStateCounters == null)
                {
                    this.LegendGrid.WaitForRowsLoaded();
                    this.healthStateCounters = new Dictionary<string, int>();
                    if (this.LegendGrid.RowsExtended.Count > 0)
                    {
                        for (int i = 0; i < this.LegendGrid.RowsExtended.Count; i++)
                        {
                            this.healthStateCounters.Add(this.LegendGrid.RowsExtended[i].CellsExtended[2].NameExtended,
                                Convert.ToInt32(this.LegendGrid.RowsExtended[i].CellsExtended[3].NameExtended));
                        }
                    }
                }
                return this.healthStateCounters;
            }
        }

        public AgentHealthStatePerfWidget(Window knownWindow, XDocument dashboardDocument)
            : base(knownWindow)
        {
            XElement embeddedComponentResource = ResourceLoader.GetSection("AgentHealthState", dashboardDocument);
            ResourceLoader.LoadResources(this, embeddedComponentResource);

            expectedTitle = title;
            expectedHealthStateColumnHeader = healthState;
            expectedCountOfAgentsColumnHeader = countOfAgents;
            totalCounterInstance = total;
            unavailableCounterInstance = unavailable;
            unmonitoredCounterInstance = unmonitored;
            healthyCounterInstance = healthy;
            criticalCounterInstance = critical;
            warningCounterInstance = warning;
        }

        private DataGridControl GetLegendGrid()
        {
            DataGridControl legendGrid = null;
            Exception lastException = null;
            Sleeper sleeper = new Sleeper(Mom.Test.UI.Core.Common.Constants.OneMinute);

            while (sleeper.IsNotExpired && legendGrid == null)
            {
                try
                {
                    legendGrid = new DataGridControl(this, DataGridViewHost.ControlQIDs.DataGridQID);
                }
                catch (Exception ex)
                {
                    lastException = ex;
                }
                sleeper.Sleep();
            }

            if (legendGrid != null)
            {
                legendGrid.WaitForRowsLoaded();
                return legendGrid;
            }
            else
            {
                throw lastException;
            }
        }

        public bool VerifyTitle()
        {
            if (!(String.Equals(this.Title.Text.Trim(), expectedTitle)))
            {
                Utilities.LogMessage("AgentHealthStatePerfWidget.VerifyTitle :: Title mismatch");
            }
            return true;
        }

        public bool VerifyColumnHeaders()
        {
            if (String.Equals(this.LegendGrid.ColumnHeaders[OMSummaryDashboard.Strings.indexCHHealthState].Trim(), expectedHealthStateColumnHeader) &&
                String.Equals(this.LegendGrid.ColumnHeaders[OMSummaryDashboard.Strings.indexCHCountOfAgents].Trim(), expectedCountOfAgentsColumnHeader))
            {
                Utilities.LogMessage("AgentHealthStatePerfWidget.VerifyColumnHeaders :: Successfully verified column headers");
                return true;
            }
            else
            {
                Utilities.LogMessage("AgentHealthStatePerfWidget.VerifyColumnHeaders :: Successfully verified column headers");
                return false;
            }
        }

        public bool VerifyLegendCounters()
        {
            if (this.HealthStateCounters.Count > 0)
            {
                if (this.HealthStateCounters.ContainsKey(criticalCounterInstance) &&
                    this.HealthStateCounters.ContainsKey(healthyCounterInstance) &&
                    this.HealthStateCounters.ContainsKey(unmonitoredCounterInstance) &&
                    this.HealthStateCounters.ContainsKey(totalCounterInstance) &&
                    this.HealthStateCounters.ContainsKey(unavailableCounterInstance) &&
                    this.HealthStateCounters.ContainsKey(warningCounterInstance))
                {
                    Utilities.LogMessage("AgentHealthStatePerfWidget.VerifyLegendCounters :: Successfully verified counters in Legend");
                    return true;
                }
                else
                {
                    Utilities.LogMessage("AgentHealthStatePerfWidget.VerifyLegendCounters :: Failed to verify counters in Legend");
                    return false;
                }
            }
            else
            {
                Utilities.LogMessage("AgentHealthStatePerfWidget.VerifyLegendCounters :: Legend rows are not loaded, this is because the DW procedure hasn't finished yet");
                return false;
            }
        }

        public bool VerifyAgentsCount()
        {
            if (this.HealthStateCounters[totalCounterInstance] ==
                this.HealthStateCounters[criticalCounterInstance] +
                this.HealthStateCounters[healthyCounterInstance] +
                this.HealthStateCounters[unmonitoredCounterInstance] +
                this.HealthStateCounters[unavailableCounterInstance] +
                this.HealthStateCounters[warningCounterInstance])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class AgentConfigurationStateWidget : StateWidget
    {
        [Resource(ID = "Title")]
        private string title;
        public static string expectedTitle;

        [Resource(ID = "ConfigurationColumnHeader")]
        private string configuration;
        public static string expectedConfigurationColumnHeader;

        [Resource(ID = "CountOfAgentsColumnHeader")]
        private string countOfAgents;
        public static string expectedCountOfAgentsColumnHeader;

        [Resource(ID = "ManualApproval")]
        private string manualApproval;
        public static string manualApprovalInstance;

        [Resource(ID = "PushInstall")]
        private string pushInstall;
        public static string pushInstallInstance;

        [Resource(ID = "UpdateAgent")]
        private string updateAgent;
        public static string updateAgentInstance;

        [Resource(ID = "RepairAgent")]
        private string repairAgent;
        public static string repairAgentInstance;

        [Resource(ID = "LicenseUpgrade")]
        private string licenseUpgrade;
        public static string licenseUpgradeInstance;

        [Resource(ID = "PushInstallFailed")]
        private string pushInstallFailed;
        public static string pushInstallFailedInstance;

        [Resource(ID = "UpdateFailed")]
        private string updateFailed;
        public static string updateFailedInstance;

        [Resource(ID = "RepairFailed")]
        private string repairFailed;
        public static string repairFailedInstance;

        [Resource(ID = "NoConfigurationData")]
        private string noConfigurationData;
        public static string noConfigurationDataInstance;

        public AgentConfigurationStateWidget(Window knownWindow, XDocument dashboardDocument)
            : base(knownWindow)
        {
            XElement embeddedComponentResource = ResourceLoader.GetSection("AgentConfiguration", dashboardDocument);
            ResourceLoader.LoadResources(this, embeddedComponentResource);

            expectedTitle = title;
            expectedConfigurationColumnHeader = configuration;
            expectedCountOfAgentsColumnHeader = countOfAgents;
            manualApprovalInstance = manualApproval;
            pushInstallInstance = pushInstall;
            updateAgentInstance = updateAgent;
            repairAgentInstance = repairAgent;
            licenseUpgradeInstance = licenseUpgrade;
            pushInstallFailedInstance = pushInstallFailed;
            updateFailedInstance = updateFailed;
            repairFailedInstance = repairFailed;
            noConfigurationDataInstance = noConfigurationData;
        }

        public bool VerifyTitle()
        {
            // StateWidget title has appended dynamic number which indicates the number of rows in the widget
            if (!(this.Title.Text.Contains(expectedTitle)))
            {
                Utilities.LogMessage("AgentConfigurationStateWidget.VerifyTitle :: Title mismatch");
                return false;
            }
            return true;
        }

        public bool VerifyColumnHeaders()
        {
            if (String.Equals(this.DataGrid.ColumnHeaders[OMSummaryDashboard.Strings.indexCHConfiguration].Trim(), expectedConfigurationColumnHeader) &&
                String.Equals(this.DataGrid.ColumnHeaders[OMSummaryDashboard.Strings.indexCHCountOfAgnetsByConfig].Trim(), expectedCountOfAgentsColumnHeader))
            {
                Utilities.LogMessage("AgentConfigurationStateWidget.VerifyColumnHeaders :: Successfully verified column headers");
                return true;
            }
            else
            {
                Utilities.LogMessage("AgentConfigurationStateWidget.VerifyColumnHeaders :: Successfully verified column headers");
                return false;
            }
        }
    }

    public class AgentVersionsStateWidget : StateWidget
    {
        [Resource(ID = "Title")]
        private string title;
        public static string expectedTitle;

        [Resource(ID = "VersionColumnHeader")]
        private string version;
        public static string expectedVersionColumnHeader;

        [Resource(ID = "CumulativeUpdateColumnHeader")]
        private string cumulativeUpdate;
        public static string expectedCumulativeUpdateColumnHeader;

        [Resource(ID = "CountOfAgentsColumnHeader")]
        private string countOfAgents;
        public static string expectedCountOfAgentsColumnHeader;

        [Resource(ID = "NoVersionData")]
        private string noVersionData;
        public static string noVersionDataInstance;

        [Resource(ID = "NoAgentsFound")]
        private string noAgentsFound;
        public static string noAgentsFoundInstance;

        public AgentVersionsStateWidget(Window knownWindow, XDocument dashboardDocument)
            : base(knownWindow)
        {
            XElement embeddedComponentResource = ResourceLoader.GetSection("AgentVersions", dashboardDocument);
            ResourceLoader.LoadResources(this, embeddedComponentResource);

            expectedTitle = title;
            expectedVersionColumnHeader = version;
            expectedCumulativeUpdateColumnHeader = cumulativeUpdate;
            expectedCountOfAgentsColumnHeader = countOfAgents;
            noVersionDataInstance = noVersionData;
            noAgentsFoundInstance = noAgentsFound;
        }

        public bool VerifyTitle()
        {
            // StateWidget title has appended dynamic number which indicates the number of rows in the widget
            if (!(this.Title.Text.Contains(expectedTitle)))
            {
                Utilities.LogMessage("AgentVersionsStateWidget.VerifyTitle :: Title mismatch");
                return false;
            }
            return true;
        }

        public bool VerifyColumnHeaders()
        {
            if (String.Equals(this.DataGrid.ColumnHeaders[OMSummaryDashboard.Strings.indexCHVersion].Trim(), expectedVersionColumnHeader) &&
                String.Equals(this.DataGrid.ColumnHeaders[OMSummaryDashboard.Strings.indexCHCumulativeUpdate].Trim(), expectedCumulativeUpdateColumnHeader) &&
                String.Equals(this.DataGrid.ColumnHeaders[OMSummaryDashboard.Strings.indexCHCountOfAgentsByVersion].Trim(), expectedCountOfAgentsColumnHeader))
            {
                Utilities.LogMessage("AgentVersionsStateWidget.VerifyColumnHeaders :: Successfully verified column headers");
                return true;
            }
            else
            {
                Utilities.LogMessage("AgentVersionsStateWidget.VerifyColumnHeaders :: Successfully verified column headers");
                return false;
            }
        }
    }
}
