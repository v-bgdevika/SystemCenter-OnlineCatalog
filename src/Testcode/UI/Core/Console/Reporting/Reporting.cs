//\-----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Reporting.cs">
// Copyright (c) Microsoft Corporation 2006
// </copyright>
//
// <project>
// MOMv3 UI Test Automation
// </project>
//
// <summary>
// Open the Reporting Console and verify the UI
// </summary>
// 
// <note>
// This is work in progress
// </note>
// 
// <history>
//    [cdelthon]   03OCT06 Created.
//    [cdelthon] 13DEC06 Changed all references from UI to ReportingConsole 
//    [a-omkasi] 02JUL08 Added common methods for ReportingConsole UI automation
//    [Sunsingh] 11Sep08 Added common methods for SLA Parameter controls UI automation
// </history>
//\-----------------------------------------------------------------------------

using System;
using System.Text;
using System.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading;
using System.Data.SqlClient;

using Infra.Frmwrk; // Infra.Frmwrk.Types.dll
using Mom.Test.UI.Core;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.Console;
using Mom.Test.UI.Core.Console.Reporting.Dialogs;
using Maui.Core;
using Maui.Core.WinControls;
using Maui.Core.Utilities;
using Maui.GlobalExceptions;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Test.ScCommon;

namespace Mom.Test.UI.Core.Console.Reporting
{
    /// <summary>
    /// Class to add general methods for Reporting 
    /// </summary>
    public class Reporting
    {
        #region Enumerator Section
        /// <summary>
        /// SearchTypeName for various search options from UI
        /// </summary>
        public enum enumSearchTypeName
        {
            /// <summary>
            /// Contains
            /// </summary>
            Contains,

            /// <summary>
            /// BeginsWith
            /// </summary>
            BeginsWith,
            /// <summary>
            /// EndsWith
            /// </summary>
            EndsWith
        }


        /// <summary>
        /// Reports: - enumeration
        /// </summary>
        /// <history>
        ///     [a-omkasi] 02JUL08 Created
        ///     [sunsingh] 11Sep08 Added SLA Reports
        /// </history>
        public enum Reports
        {
            /// <summary>
            /// AlertLoggingLatency -- Alert Logging Latency Report
            /// </summary>
            AlertLoggingLatency,

            /// <summary>
            /// Alerts -- Alerts Report
            /// </summary>
            Alerts,

            /// <summary>
            /// Availability -- Availability Report
            /// </summary>
            Availability,

            /// <summary>
            /// ConfigurationChanges -- Configuration Changes Report
            /// </summary>
            ConfigurationChanges,

            /// <summary>
            /// CustomConfiguration -- Custom Configuration Report
            /// </summary>
            CustomConfiguration,

            /// <summary>
            /// CustomEvent -- Custom Event Report
            /// </summary>
            CustomEvent,

            /// <summary>
            /// EventAnalysis -- Event Analysis Report
            /// </summary>
            EventAnalysis,

            /// <summary>
            /// Health -- Health Report
            /// </summary>
            Health,

            /// <summary>
            /// Licenses -- Licenses Report
            /// </summary>
            Licenses,

            /// <summary>
            /// MostCommonAlerts -- Most Common Alerts Report
            /// </summary>
            MostCommonAlerts,

            /// <summary>
            /// MostCommonEvents -- Most Common Events Report
            /// </summary>
            MostCommonEvents,

            /// <summary>
            /// Overrides -- Overrides Report
            /// </summary>
            Overrides,

            /// <summary>
            /// Performance -- Performance Report
            /// </summary>
            Performance,

            /// <summary>
            /// PerformanceDetail -- PerformanceDetail Report
            /// </summary>
            PerformanceDetail,

            /// <summary>
            /// PerformanceTopInstances -- Performance Top Instances Report
            /// </summary>
            PerformanceTopInstances,

            /// <summary>
            /// PerformanceTopObjects -- Performance Top Objects Report
            /// </summary>
            PerformanceTopObjects,

            /// <summary>
            /// ReportingUITestLinkedAlerts -- Reporting UI Test Linked Alerts Reports
            /// </summary>

            ReportingUITestLinkedAlerts,

            //Improvement 121370  SLA new reports

            /// <summary>
            /// SLASummary -- Reporting UI Test Sla Summary Reports
            /// </summary>

            SlaSummary,


            /// <summary>
            /// SlaDashboard -- Reporting UI Test Sla Dashboard Reports
            /// </summary>

            SlaDashboard,
            /// <summary>
            /// SlaConfiguration -- Reporting UI Test Sla Configuration Reports
            /// </summary>

            SlaConfiguration

        }
        #endregion

        #region Private Constants

        /// <summary>
        /// General Timeout Value = 6000
        /// </summary>
        private int timeOut = 6000;

        /// <summary>
        /// Timeout value used to introduce delay
        /// </summary>
        private const int nOneSecond = 1000;

        /*      /// <summary>
              /// The maximum number of retries to find the ReportingConsole
              /// </summary>
          //    private int ReportingConsoleNodeMaxNumberOfRetries = 15;
         */
        #endregion

        #region Private Members

        ///<summary>
        /// Cache to hold Management Group
        ///</summary>
        private static ManagementGroup cachedManagementGroup;

        ///<summary>
        /// Private consoleApp Reference
        ///</summary>
        private MomConsoleApp consoleApp;
        #endregion

        #region Public Members
        ///<summary>
        /// private string to Hold the ReportName displyed in the UI
        ///</summary>
        public static string ReportDisplayName = null;
        #endregion

        #region Properties

        /// <summary>
        /// Return a ManagementGroup from the MOM SDK Service.
        /// <exception cref="InvalidOperationException"></exception>
        /// </summary>
        [Obsolete("Please use Utilities.ConnectToManagementServer()")]
        public static ManagementGroup MomSdkManagementGroup
        {
            get
            {
                if ((null != cachedManagementGroup) && (cachedManagementGroup.IsConnected))
                {
                    Utilities.LogMessage("Already connected to MOM SDK Service.");
                    return cachedManagementGroup;
                }

                cachedManagementGroup = ManagementGroup.Connect(System.Windows.Forms.SystemInformation.ComputerName);
                if (!cachedManagementGroup.IsConnected)
                {
                    Utilities.LogMessage("Exception: Could not connect to SDK Service!");
                    throw new InvalidOperationException("Not connected to an SDK Service");
                }

                Utilities.LogMessage("Connected to SDK Service");
                return cachedManagementGroup;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Reporting Constructor.
        /// </summary>
        public Reporting()
        {
            this.consoleApp = CoreManager.MomConsole;
        }
        #endregion

        ///-------------------------------------------------------------------------------
        /// <summary>
        /// Used to click on Reporting WunderBar and navigate to a node.
        /// </summary>
        /// <param name="nodeName">Name of the node you want to navigate to.</param>
        /// <returns>Returns true or false indicating success or failure respectively.</returns>
        /// <history>
        ///     [cdelthon]   03OCT06 Created.
        ///     [a-omkasi]   26JUL08 Edited to make it generic for all reports.
        ///     [sunsingh]   11Sep08 Added code for NavigateTo SLA report
        /// </history>
        /// ------------------------------------------------------------------------------
        public bool NavigateToReportingUiNode(string nodeName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "_Start Navigate to reporting node: " + nodeName);
            bool foundNode = false;
            string node = null;

            Utilities.LogMessage(currentMethod + "Select Reporting nodename: " + nodeName);
            switch (nodeName.ToLowerInvariant())
            {
                case Constants.MicrosoftGenericReportLibraryName:
                    node = Strings.MicrosoftGenericReportLibrary;
                    break;
                case Constants.ReportingUITestLibraryDisplayName:
                    node = Strings.ReportingUITestLibraryDisplayName;
                    break;
                case Constants.ServiceLevelReportLibrary:
                    node = SlmReportParameterControlDialog.Strings.SlmReportingMPDisplayName;
                    break;
                default:
                    Utilities.LogMessage(currentMethod + "_Invalid Argument:" + nodeName + "passed.");
                    break;
            }

            foundNode = IsReportingUiNodeThere(node);

            if (foundNode == false)
            {
                Utilities.LogMessage(currentMethod +
                    "_Failed to select the node " + nodeName + " in the reporting console.");
            }
            else
            {
                Utilities.LogMessage(currentMethod + "_Successfully Selected Node in Tree View.");
            }
            return foundNode;
        }


        ///-------------------------------------------------------------------------------
        /// <summary>
        /// Verify if a particular node is under the Reporting Navigation Pane.
        /// </summary>
        /// <param name="node" value= "">Node which you want to check if exists</param>
        /// <returns>Returns bool indicating if the node is present.</returns>
        /// <history>
        ///     [cdelthon]   03OCT06 Created.
        /// </history>
        ///-------------------------------------------------------------------------------
        public bool IsReportingUiNodeThere(string node)
        {
            bool nodeFound = false;
            int nOfTries = 1;
            int maxTries = 30;

            if (null == this.consoleApp)
            {
                Utilities.LogMessage("Reporting.IsReportingUiNodeThere :: IsReportingUiNodeThere parameter app was null.");
                return nodeFound;
            }
            Utilities.LogMessage("Reporting.IsReportingUiNodeThere :: app is not null.");
            Utilities.LogMessage("Reporting.IsReportingUiNodeThere :: app's caption is " + this.consoleApp.MainWindow.Caption.ToString());

            if (0 == node.Length)
            {
                Utilities.LogMessage("Reporting.IsReportingUiNodeThere :: IsReportingUiNodeThere parameter node was the empty string.");
                return nodeFound;
            }

            // Click on the Reporting wunderbar
            Utilities.LogMessage("Reporting.IsReportingUiNodeThere :: Reporting Before Clicking the Reporting wunderbar.");
            this.consoleApp.NavigationPane.ClickWunderBarButton(Mom.Test.UI.Core.Console.NavigationPane.WunderBarButton.Reporting);
            this.consoleApp.Waiters.WaitForStatusReady(timeOut);

            while (nodeFound == false && nOfTries <= maxTries)
            {
                try
                {
                    Utilities.LogMessage("Reporting.IsReportingUiNodeThere :: Trying to select the node: " + node);
                    this.consoleApp.NavigationPane.SelectNode(node, NavigationPane.NavigationTreeView.Reporting);
                    Utilities.LogMessage("Reporting.IsReportingUiNodeThere :: Reporting node Found: " + nodeFound.ToString());
                    nodeFound = true;
                    break;
                }
                catch (Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException)
                {
                    Utilities.LogMessage(
                        "Reporting.NavigateToReportingUINode :: The node" + node +
                        " is not there! Sleep one minute and try again. Attempt " +
                        nOfTries + " of " + maxTries);
                    Sleeper.Delay(Constants.OneMinute);
                }

                // Select the Root Node for Reporting TreeNode and refresh it using F5
                Utilities.LogMessage("Reporting.IsReportingUiNodeThere :: Select the Root Node for Reporting TreeNode and refresh it.");
                this.consoleApp.NavigationPane.SelectNode(Strings.ReportingRootFolderName, NavigationPane.NavigationTreeView.Reporting);
                this.consoleApp.NavigationPane.SendKeys(KeyboardCodes.F5);
                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);
                nOfTries++;
            }

            return nodeFound;
        }


        ///-------------------------------------------------------------------------------
        /// <summary>
        /// Method to select a Report and Open it.
        /// </summary>
        /// <param name="ReportName"> Name of the Report to open</param>
        /// <param name="context">FrameWork context variable</param>
        /// <param name="consoleApp">MomConsoleApp</param>
        /// <exception cref ="Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException"></exception>
        /// <history>
        ///     [a-omkasi] 02JUL08 Created
        /// </history>
        ///-------------------------------------------------------------------------------
        public void LaunchReportDialog(Reports ReportName, MomConsoleApp consoleApp, IContext context)
        {
            // Find the required report in the list of reports
            string reportName = null;
            int currentListViewItemNumber = 0;
            int numberOfReports = 0;
            int nOfTries = 1;
            int maxRetries = 40;
            bool found = false;
            string mpName = Strings.DwManagementPack;
            Utilities.LogMessage("Reporting.LaunchReportDialog :: Started...");

            switch (ReportName)
            {
                case Reporting.Reports.AlertLoggingLatency:

                    reportName = Constants.AlertLoggingLatencyReportName;
                    break;

                #region Other Reports
                case Reporting.Reports.Alerts:// "alerts":
                    reportName = Constants.AlertsReportName;
                    break;

                case Reporting.Reports.Availability:// "availability":
                    reportName = Constants.AvailabilityReportName;
                    break;

                case Reporting.Reports.ConfigurationChanges:// "configurationchanges":
                    reportName = Constants.ConfigurationChangesReportName;
                    break;

                case Reporting.Reports.CustomConfiguration:// "customconfiguration":
                    reportName = Constants.CustomConfigurationReportName;
                    break;

                case Reporting.Reports.CustomEvent:// "customevent":
                    reportName = Constants.CustomEventReportName;
                    break;

                case Reporting.Reports.EventAnalysis:// "eventanalysis":
                    reportName = Constants.EventAnalysisReportName;
                    break;

                case Reporting.Reports.Health:// "health":
                    reportName = Constants.HealthReportName;
                    break;

                case Reporting.Reports.Licenses:// "licenses":
                    reportName = Constants.LicensesReportName;
                    break;

                case Reporting.Reports.MostCommonAlerts:// "mostcommonalerts":
                    reportName = Constants.MostCommonAlertsReportName;
                    break;

                case Reporting.Reports.MostCommonEvents:// "mostcommonevents":
                    reportName = Constants.MostCommonEventsReportName;
                    break;

                case Reporting.Reports.Overrides:// "overrides":
                    reportName = Constants.OverridesReportName;
                    break;

                case Reporting.Reports.Performance:// "performance":
                    reportName = Constants.PerformanceReportName;
                    break;

                case Reporting.Reports.PerformanceDetail:// "performancedetail":
                    reportName = Constants.PerformanceDetailReportName;
                    break;

                case Reporting.Reports.PerformanceTopInstances:// "performancetopinstances":
                    reportName = Constants.PerformanceTopInstancesReportName;
                    break;

                case Reporting.Reports.PerformanceTopObjects:// "performancetopobjects":
                    reportName = Constants.PerformanceTopObjectsReportName;
                    break;
                case Reporting.Reports.ReportingUITestLinkedAlerts:// "reportinguitestlinkedalerts":
                    // Get the Display name on the UI for the report.
                    reportName = Constants.ReportingUITestDisplayName;
                    break;
                case Reporting.Reports.SlaSummary:
                    mpName = SlmReportParameterControlDialog.Strings.SlmReportingMPDisplayName;
                    reportName = Constants.SlaSummary;
                    break;
                case Reporting.Reports.SlaDashboard:
                    mpName = Strings.SLAManagementPack;
                    reportName = Constants.SlaDashboard;
                    break;
                case Reporting.Reports.SlaConfiguration:
                    mpName = Strings.SLAManagementPack;
                    reportName = Constants.SlaConfiguration;
                    break;
                #endregion
                default:
                    Utilities.LogMessage("Reporting.LaunchReportDialog :: ReportName passed in as a parameter: '" +
                    reportName + "' is invalid");
                    break;
            } //switch 

            // Access the List of reports in the ListView
            Maui.Core.WinControls.ListView listView = consoleApp.ViewPane.ListViewReports;
            Utilities.LogMessage("Reporting.LaunchReportDialog :: Reporting ListView Count = " + listView.Items.Count);

            while (nOfTries <= maxRetries && found == false)
            {
                currentListViewItemNumber = 0;
                numberOfReports = listView.Items.Count;
                try
                {
                    while (numberOfReports > 0 &&
                        currentListViewItemNumber < numberOfReports)
                    {
                        // Get the display name for all the reports except for the Reporting UI test Report.
                        if (reportName != Constants.ReportingUITestDisplayName)
                        {
                            if (ReportName == Reporting.Reports.SlaSummary)
                                ReportDisplayName = SlmReportParameterControlDialog.Strings.SLAReportDisplayString;//"Service Level Agreement Summary Report";//to do get through SDK
                            else
                                ReportDisplayName = GetReportDisplayName(reportName, context, mpName);

                        }
                        else if (reportName == Constants.ReportingUITestDisplayName)
                        {
                            // Since it is the Reporting UI test report, its display name wont change
                            ReportDisplayName = reportName;
                        }

                        if (ReportDisplayName == listView.Items[currentListViewItemNumber].Text)
                        {
                            // if item found in the list
                            found = true;
                            break;
                        }
                        currentListViewItemNumber++;
                    }
                }
                catch (ListView.Exceptions.ItemNotFoundException)
                {
                    Utilities.LogMessage("reporting.LaunchReportDialog :: " + ReportDisplayName + " not Foud in list view.");
                }

                if (found == false)
                {
                    // Refresh list view and wait before retry, only if not found.
                    Utilities.LogMessage("reporting.LaunchReportDialog :: " + ReportDisplayName + " not Foud in list view.");
                    Utilities.LogMessage("reporting.LaunchReportDialog :: refresh the ListView , sleep one minute and try again. Attempt "
                        + nOfTries + " of " + maxRetries);
                    listView.SendKeys(KeyboardCodes.F5);
                    CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneSecond * 60);
                    Sleeper.Delay(Constants.OneSecond * 60);
                }

                nOfTries++;
            } // While close

            if (found == false)
            {
                // After max number of retries, if still report is not found in listview
                Utilities.LogMessage("reporting.LaunchReportDialog :: <<Exception>>" + ReportDisplayName + " Report still not found in the ListView after maximum retries");
                throw new ListView.Exceptions.ItemNotFoundException("Reporting.LaunchReportDialog :: Failed to find '" +
                    reportName + "' in the ListView");
            }

            // Select the report
            listView.Items[currentListViewItemNumber].Select();
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneSecond * 5);
            //listView.Items[currentListViewItemNumber].ContextMenu.ExecuteMenuItem(Strings.Open);

            //[v-liqluo] Using double-click the report as a replacement of Execution menu
            listView.Items[currentListViewItemNumber].Click(MouseClickType.DoubleClick, MouseFlags.LeftButton);
            Utilities.LogMessage("Reporting.LaunchReportDialog :: Opening " + reportName + " Dialog");

            this.consoleApp.Waiters.WaitForStatusReady(Constants.OneSecond * 120);
            Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);

            // Make sure consoleApp is not null
            if (null == consoleApp)
            {
                throw new Maui.Core.Window.Exceptions.WindowNotFoundException("Reporting.LaunchReportDialog :: Couldn't find the Mom Console. consoleApp is null");
            }
        }
        ///-------------------------------------------------------------------------------
        /// <summary>
        /// Method to run a report. it clicks run button on toolbar
        /// </summary>        
        /// <history>
        ///     [sunsingh] 11Sep08 Created
        /// </history>
        ///-------------------------------------------------------------------------------
        public bool RunReport()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage("Click Run report" + currentMethod);

            SlmReportParameterControlDialog slaReportDialog = new SlmReportParameterControlDialog(CoreManager.MomConsole);
            UISynchronization.WaitForProcessReady(slaReportDialog, Constants.OneSecond * 60);
            UISynchronization.WaitForUIObjectReady(slaReportDialog, Constants.OneSecond * 60);
            Utilities.LogMessage("Created object of slaReportDialog" + currentMethod);

            CoreManager.MomConsole.InvokeToolBarButton(slaReportDialog.Controls.Toolbar1, Strings.RunMenu);

            UISynchronization.WaitForProcessReady(slaReportDialog, Constants.OneSecond * 60);
            UISynchronization.WaitForUIObjectReady(slaReportDialog, Constants.OneSecond * 60);

            Utilities.LogMessage("Run Report finished successfully : " + currentMethod);
            return true;
        }

        ///-------------------------------------------------------------------------------
        /// <summary>
        /// Method to verify a report.
        /// </summary>    
        /// <exception cref ="Maui.Core.Window.Exceptions.WindowNotFoundException"></exception>
        /// <history>
        ///     [sunsingh] 11Sep08 Created
        /// </history>
        ///-------------------------------------------------------------------------------
        public bool VerifyRunSLAReport()
        {
            int retrycount = 0;
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

            SlmReportParameterControlDialog slaReportDialog = new SlmReportParameterControlDialog(CoreManager.MomConsole);
            UISynchronization.WaitForProcessReady(slaReportDialog, Constants.OneSecond * 60);
            UISynchronization.WaitForUIObjectReady(slaReportDialog, Constants.OneSecond * 60);

            Utilities.LogMessage("Witing for report Report to render control " + currentMethod);
            try
            {
                Utilities.LogMessage("ReportGeneratingStaticControl control visible " + slaReportDialog.Controls.ReportGeneratingStaticControl.IsVisible.ToString() + " enabled " + slaReportDialog.Controls.ReportGeneratingStaticControl.IsEnabled.ToString());

                while (slaReportDialog.Controls.ReportGeneratingStaticControl.IsVisible == true && retrycount <= 10)
                {
                    Utilities.LogMessage("Waiting for the report to rander " + currentMethod);
                    Sleeper.Delay(Constants.OneSecond * 5);
                    retrycount++;
                }
                if (slaReportDialog.Controls.ReportGeneratingStaticControl.IsVisible)
                    return false;
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException e)
            {
                // if this exception happens on ReportGeneratingStaticControl is not available on UI that means report is rendered.
                Sleeper.Delay(Constants.OneSecond * 5);
                if (CoreManager.MomConsole.CheckForExceptionErrorDialog())
                {
                    Utilities.LogMessage("Exception Box found, Report Render Failed :: " + currentMethod +
                        " with error: " + e);
                    throw;
                }
            }

            Utilities.LogMessage("VerifyRunSLAReport finished successfully : " + currentMethod);
            return true;
        }
        ///-------------------------------------------------------------------------------
        /// <summary>
        /// Method to click ShowOrHideParameters.
        /// </summary>
        /// <exception cref ="Maui.Core.Window.Exceptions.WindowNotFoundException"></exception>
        /// <history>
        ///     [sunsingh] 11Sep08 Created
        /// </history>
        ///-------------------------------------------------------------------------------
        public void ShowOrHideParameters(bool showParameters)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage("Click Show or hide parameters report" + currentMethod);

            SlmReportParameterControlDialog slaReportDialog = new SlmReportParameterControlDialog(CoreManager.MomConsole);
            UISynchronization.WaitForProcessReady(slaReportDialog, Constants.OneSecond * 60);
            UISynchronization.WaitForUIObjectReady(slaReportDialog, Constants.OneSecond * 60);
            Utilities.LogMessage("Created object of slaReportDialog" + currentMethod);
            try
            {
                if (showParameters == true && slaReportDialog.Controls.AddSLAButton.IsVisible == false)// visiable it
                    consoleApp.ExecuteWindowMenuItem(slaReportDialog, SlmReportParameterControlDialog.Strings.MenuBarViewOption, SlmReportParameterControlDialog.Strings.ViewMenuParameterOption);
                if (showParameters == false && slaReportDialog.Controls.AddSLAButton.IsVisible == true) // hide it
                    consoleApp.ExecuteWindowMenuItem(slaReportDialog, SlmReportParameterControlDialog.Strings.MenuBarViewOption, SlmReportParameterControlDialog.Strings.ViewMenuParameterOption);
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException e)
            {
                Utilities.LogMessage("WindowNotFoundException handle  : " + e.ToString() + " : " + currentMethod);
                // if handle to AddSLAButton not found. some times it failes with this exception if button is not visible.
                if (showParameters == true)// visiable it
                    consoleApp.ExecuteWindowMenuItem(slaReportDialog, SlmReportParameterControlDialog.Strings.MenuBarViewOption, SlmReportParameterControlDialog.Strings.ViewMenuParameterOption);
            }

            Utilities.LogMessage("ShoworHideParameter Report finished successfully : " + currentMethod);
            UISynchronization.WaitForProcessReady(slaReportDialog, Constants.OneSecond * 60);
            UISynchronization.WaitForUIObjectReady(slaReportDialog, Constants.OneSecond * 60);
        }

        ///-------------------------------------------------------------------------------
        /// <summary>
        /// Get the Display Name for the Report
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="context"></param>
        /// <returns>Returns a string with Display name of the report.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <history>
        ///      [Sunsingh]   11sup08 Created
        /// </history>
        ///-------------------------------------------------------------------------------
        public static string GetReportDisplayName(string reportName, IContext context)
        {
            return GetReportDisplayName(reportName, context, Strings.DwManagementPack);
        }


        ///-------------------------------------------------------------------------------
        /// <summary>
        /// Get the Display Name for the Report
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="context"></param>
        ///  <param name="mpName"></param>
        /// <returns>Returns a string with Display name of the report.</returns>
        /// <exception cref="System.Exception"></exception>
        /// <history>
        ///     [cdelthon]   03OCT06 Created. 
        ///     [a-omkasi]   01AUG08 Edited to make the sql Query generic and work
        ///                  for all reports
        ///     [Sunsingh]   11sup08 Change it to have additional prameter 
        /// </history>
        ///-------------------------------------------------------------------------------
        public static string GetReportDisplayName(string reportName, IContext context, string mpName)
        {
            try
            {
                Utilities.LogMessage("Reporting.GetReportDisplayName :: GetReportingDisplayName called!");

                // Get the GUID of the Report from the datawarehouse.
                Mom.Test.UI.Core.Common.Topology.Initialize();
                DBUtil.ConnectToMOMDW(Topology.RootMomSdkServerName);

                string sqlQuery = "select ReportGuid from Report where ReportSystemName = 'Microsoft.SystemCenter.DataWarehouse.Report." + reportName + "'";

                Utilities.LogMessage("Reporting.GetReportDisplayName :: sqlQuery: " + sqlQuery + "");
                Guid ReportGuid = (Guid)DBUtil.ExecuteScalarQuery(sqlQuery);
                Utilities.LogMessage("Reporting.GetReportDisplayName :: ReportGuid: " + ReportGuid);
                Utilities.LogMessage("Reporting.GetReportDisplayName :: " + reportName + "Report Guid is " + ReportGuid.ToString());

                // Get the Management Pack the report is in.
                ManagementGroup mg = Utilities.ConnectToManagementServer();
                ManagementPack datawarehouseMP = null;

                System.Collections.Generic.IList<ManagementPack> mps = mg.ManagementPacks.GetManagementPacks();
                foreach (ManagementPack mp in mps)
                {
                    if (mpName == mp.Name)
                    {
                        datawarehouseMP = mp;
                    }
                }
                if (null == datawarehouseMP)
                {
                    throw new Exception("Reporting.GetReportDisplayName :: Could not find " +
                        Strings.DwManagementPack +
                        " Management Pack in list of Management Packs");
                }
                Utilities.LogMessage("Reporting.GetReportDisplayName :: MPName is: " + datawarehouseMP.Name);

                // Get the Report display name from the management pack
                ManagementPackElementCollection<ManagementPackReport> mpReports = datawarehouseMP.GetReports();
                foreach (ManagementPackReport mpReport in mpReports)
                {
                    Utilities.LogMessage("Reporting.GetReportDisplayName :: checking for: " + mpReport.DisplayName + " : " + ReportGuid + " : " + mpReport.Id);
                    if (ReportGuid == mpReport.Id)
                    {
                        ReportDisplayName = mpReport.DisplayName;
                    }
                }
                Utilities.LogMessage("Reporting.GetReportDisplayName :: ReportDisplayName is: " + ReportDisplayName);
                return ReportDisplayName;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        ///-------------------------------------------------------------------------------
        /// <summary>
        /// Method to close a dialog
        /// </summary>
        /// <param name="ReportName">The dialog which needs to be closed.</param>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.Exception">if null reference is passed as parameter.</exception>
        /// <history>
        ///     [a-omkasi] 02JUL08 Created
        /// </history>
        ///-------------------------------------------------------------------------------
        public void CloseReportingDialog(Window ReportName)
        {
            bool closed = false;
            int retry = 0;
            int maxTries = 15;

            ////close Report Dialog
            Utilities.LogMessage("Reporting.CloseReportingDialog :: Closing Report dialog: " + ReportName.ToString());

            if (ReportName == null)
            {
                throw new NullReferenceException("Reporting.CloseReportingDialog :: Null reference passed!");
            }
            ReportName.Extended.SetFocus();
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneSecond * 180);
            //UISynchronization.WaitForProcessReady(ReportName, 3000);

            while (!closed && (retry <= maxTries))
            {
                ReportName.Extended.SetFocus();
                //  [v-yoz] 21OCT09   Maui 2.0 Required change: ClickTitleBarClose() method does not 
                //                      work to close the pivoted window. Need to investigate further could be
                //                      an RPF bug - using it fails with:
                //                      "Internal failure: GetUIElementFromPoint didn't return S_OK The handle is invalid."
                //                      Changed this to close the open window with Extended.CloseWindow() method.

                ReportName.Extended.CloseWindow(); //ReportName.ClickTitleBarClose();

                closed = CoreManager.MomConsole.WaitForDialogClose(ReportName, Constants.OneSecond * 2 / Constants.OneSecond);

                if (!closed)
                {
                    // log the unsuccessful attempt
                    Utilities.LogMessage(
                        "Reporting.CloseReportingDialog :: Trying to close Reporting Dialog " + ReportName.ToString() + "_" +
                        "Attempt " + retry + " of " + maxTries);
                    retry++;
                    Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond * 5);
                }
            }//while
            Utilities.LogMessage("Reporting.CloseReportingDialog :: Unable to close Reporting Dialog: " + ReportName.ToString());
        }
        ///-------------------------------------------------------------------------------
        /// <summary>
        /// Method to check if the Management Packs are transferred to the data warehouse
        /// </summary>
        /// <param name="context">MCF context</param>
        /// <exception cref="System.Exception"></exception>
        /// <history>
        ///     [sunsingh]   11Sep08 created
        /// </history>
        ///-------------------------------------------------------------------------------
        public static bool IsMPTransferredToDW(IContext context)
        {
            return IsMPTransferredToDW("Microsoft.SystemCenter.DataWarehouse.Report.Library", context);
        }
        ///-------------------------------------------------------------------------------
        /// <summary>
        /// Method to check if the Management Packs are transferred to the data warehouse
        /// </summary>
        /// <param name="managementPackSystemName">management Pack Name</param>
        /// <param name="context">MCF context</param>
        /// <exception cref="System.Exception"></exception>
        /// <history>
        ///     [cdelthon]   03OCT06 Created.
        ///     [a-omkasi]   Modified to not throw Group abort if MP's not transfered to DataWarehouse.
        ///     [sunsingh]   11Sep08 Added overload
        /// </history>
        ///-------------------------------------------------------------------------------
        public static bool IsMPTransferredToDW(String managementPackSystemName, IContext context)
        {
            Utilities.LogMessage("Reporting.IsMPTransferredToDW :: Check whether the datawarehouse report MP is imported..... MPName" + managementPackSystemName);
            try
            {
                Mom.Test.UI.Core.Common.Topology.Initialize();
                DBUtil.ConnectToMOMDW(Topology.RootMomSdkServerName);

                //string testMPSysName = "System Center DataWarehouse Report Library";
                string sqlQuery = "select * from managementpack where ManagementPackSystemName = '" + managementPackSystemName + "'";
                //check whether MP transfered to the DW. Try for maximum 10 minutes.
                bool mpTransfered = false;
                for (int i = 0; i <= 30; i++)
                {
                    if (DBUtil.IsDataExists(sqlQuery))
                    {
                        Utilities.LogMessage(managementPackSystemName + " got transfered to DW");
                        mpTransfered = true;
                        break;
                    }
                    Utilities.LogMessage(managementPackSystemName + " did not reach the DW. Will check again in 30 seconds.");
                    Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond * 30);
                    //Thread.Sleep(30000);

                }
                return mpTransfered;
                /*if (!mpTransfered)
                {
                    throw new GroupAbort(testMPSysName + " did not reach DW.");
                }
                 * */
            }
            catch (Exception e)
            {
                Utilities.LogMessage("<<Exception>>: " + e.Message);
                throw new Exception("Check for DataWarehouse Report Library MP transferd to DW failed");
            }
            finally
            {
                DBUtil.CloseMOMDWConnection();
                //return mpTransfered;
            }
        }
        /// ------------------------------------------------------------------
        /// <summary>
        /// sets search parameter for the report
        /// </summary>
        /// ------------------------------------------------------------------
        public bool SetSLAReportParameters(bool selectDaily, bool selectbusinesshr)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage("Set inputparaments for report" + currentMethod);

            SlmReportParameterControlDialog slmReportingDialog = new SlmReportParameterControlDialog(CoreManager.MomConsole);
            Utilities.LogMessage("Setting StartDate for report" + currentMethod);
            UISynchronization.WaitForProcessReady(slmReportingDialog, Constants.OneSecond * 60);
            UISynchronization.WaitForUIObjectReady(slmReportingDialog, Constants.OneSecond * 60);
            Utilities.LogMessage("Setting Aggregationtype for report" + currentMethod);

            if (selectDaily)
            {
                Utilities.LogMessage("Selecting Daily Aggregationtype for report" + currentMethod);
                slmReportingDialog.Controls.TimeZoneComboBox.SelectByIndex(1); // TODO get resourse string, currently not used
            } //TODO go setting for hourly also
            Utilities.LogMessage("Setting BusinessHours clickbox for report" + currentMethod);

            if (selectbusinesshr)
            {
                Utilities.LogMessage("Busineshr status : " + slmReportingDialog.Controls.UseBusinessHoursCheckBox.Checked.ToString());
                if (!slmReportingDialog.Controls.UseBusinessHoursCheckBox.Checked)
                    slmReportingDialog.Controls.UseBusinessHoursCheckBox.Click();
            }
            else
            {
                if (slmReportingDialog.Controls.UseBusinessHoursCheckBox.Checked)
                    slmReportingDialog.Controls.UseBusinessHoursCheckBox.Click();

            }
            Utilities.LogMessage("Finished setting inputparaments for report" + currentMethod);
            return true;
        }
        /// ------------------------------------------------------------------
        /// <summary>
        /// sets search parameter and clicks 'search' in AddSLAObjectDialog
        /// <param name="objectNameComboBox"> enumSearchTypeName</param>
        /// <param name="searchString">search string</param>
        /// <param name="withoptions">set to true if option needs to set</param>
        /// <param name="SLAStartDate">To Set optional StartDate</param>
        /// <param name="SLAEndDate">To Set optional EndDate</param>
        /// </summary>
        /// ------------------------------------------------------------------
        public bool DoSLASearch(enumSearchTypeName objectNameComboBox, String searchString, bool withoptions, DateTime SLAStartDate, DateTime SLAEndDate)
        {


            int maxTries = 10;
            int nCount = 0;
            int nOfTries = 1;

            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage("Selecting values in ::" + currentMethod);
            // get variation parameters from varmap records

            if (searchString == null)
            {
                Utilities.LogMessage("Failed to get variation parameters from varmap records! ::" + currentMethod);
                return false;
            }

            string objectNameComboBoxTextToSelect = null;//point to appriopiate resourcestring depending on locale


            switch (objectNameComboBox)
            {
                case enumSearchTypeName.BeginsWith:
                    objectNameComboBoxTextToSelect = AddObjectDialog.Strings.SearchPatternBeginsWith;
                    break;

                case enumSearchTypeName.EndsWith:
                    objectNameComboBoxTextToSelect = AddObjectDialog.Strings.SearchPatternEndsWith;
                    break;

                case enumSearchTypeName.Contains:
                    objectNameComboBoxTextToSelect = AddObjectDialog.Strings.SearchPatternContains;
                    break;
                default:
                    Utilities.LogMessage(" Invalid objectname combo box option name: string >> " + objectNameComboBox);
                    return false;
            }
            Utilities.LogMessage("Setting combo box Object Name: " + objectNameComboBoxTextToSelect.ToString());
            AddSLAObjectDialog addSLADialog = new AddSLAObjectDialog(CoreManager.MomConsole);
            UISynchronization.WaitForProcessReady(addSLADialog, Constants.OneSecond * 60);
            UISynchronization.WaitForUIObjectReady(addSLADialog, Constants.OneSecond * 60);

            if (addSLADialog == null)
            {
                Utilities.LogMessage("ReportingConsole.DoSlaSearch :: Couldn't find the Add Object Dialog");
                throw new NullReferenceException("ReportingConsole.DoSlaSearch :: Couldn't find the Add SLA Dialog in ");
            }
            addSLADialog.Controls.ObjectsComboBox.SelectByText(objectNameComboBoxTextToSelect);
            UISynchronization.WaitForUIObjectReady(addSLADialog, Constants.DefaultDialogTimeout);
            Utilities.LogMessage("Selected item from ObjectsComboBox  ::" + currentMethod);

            if (withoptions)
            {
                Utilities.LogMessage("Click options button  ::" + currentMethod);
                addSLADialog.ClickOptions();
                Sleeper.Delay(Constants.OneSecond * 5);

                Utilities.LogMessage("Sla DateTimeString " + SLAStartDate.ToLongDateString() + " EndDate :" + SLAEndDate.ToLongDateString() + " ::" + currentMethod);
                addSLADialog.Controls.SlaintervalStartDatePicker.DateTimeString = SLAStartDate.ToLongDateString();// DateTime.Now.AddDays(-7).ToLongDateString();
                addSLADialog.Controls.SlaintervalStartDatePicker.WaitForResponse();
                addSLADialog.Controls.SlaintervalEndDatePicker.DateTimeString = SLAEndDate.ToLongDateString(); //= DateTime.Now.ToLongDateString();
                addSLADialog.Controls.SlaintervalEndDatePicker.WaitForResponse();
                Utilities.LogMessage("Finish options setting  ::" + currentMethod);
            }

            //input the search String
            addSLADialog.Controls.ObjectsTextBox.Text = searchString;
            UISynchronization.WaitForProcessReady(addSLADialog, Constants.DefaultDialogTimeout);

            while (nCount == 0
                && addSLADialog.Controls.SearchButton.IsEnabled
                && nOfTries <= maxTries)
            {
                // Click Search button
                addSLADialog.ClickSearch();
                Utilities.LogMessage("ValidateSearchInAddObjectDialog :: AddSLAObjectDialog - Search button clicked");

                // Make sure the UI is ready
                UISynchronization.WaitForProcessReady(addSLADialog, Constants.DefaultDialogTimeout);
                UISynchronization.WaitForUIObjectReady(addSLADialog, Constants.DefaultDialogTimeout);
                Sleeper.Delay(Constants.OneSecond * 5);
                Utilities.LogMessage("ValidateSearchInAddObjectDialog :: WaitForUIObjectReady returned after Click Search button");
                nCount = addSLADialog.Controls.AvailableItemsListView.Count;
                nOfTries++;
            }
            if (nCount == 0)
                return false;
            return true;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click on add SLA button on AddSLAdialog
        /// </summary>
        /// ------------------------------------------------------------------
        public bool ClickOkOnAddSLADialog()
        {
            AddSLAObjectDialog addSLADialog = new AddSLAObjectDialog(CoreManager.MomConsole);
            UISynchronization.WaitForProcessReady(addSLADialog, Constants.OneSecond * 60);
            UISynchronization.WaitForUIObjectReady(addSLADialog, Constants.OneSecond * 60);
            if (addSLADialog.Controls.OKButton.IsEnabled)
            {
                Utilities.LogMessage("ClickOkOnAddSLADialog ::  Ok button is enabled");
                addSLADialog.ClickOK();
                CoreManager.MomConsole.WaitForDialogClose(addSLADialog, Constants.OneSecond * 20 / Constants.OneSecond);
            }
            else
            {
                Utilities.LogMessage("ClickOkOnAddSLADialog ::  Ok button is not enabled");
                return false;
            }
            return true;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click on Cancle SLA button on AddSLAdialog
        /// </summary>
        /// ------------------------------------------------------------------
        public bool ClickCancelOnAddSLADialog()
        {
            AddSLAObjectDialog addSLADialog = new AddSLAObjectDialog(CoreManager.MomConsole);
            UISynchronization.WaitForProcessReady(addSLADialog, Constants.OneSecond * 60);
            UISynchronization.WaitForUIObjectReady(addSLADialog, Constants.OneSecond * 60);
            Utilities.LogMessage("ClickOkOnAddSLADialog ::  Checking CancelButton :" + addSLADialog.Controls.CancelButton.IsEnabled.ToString());
            if (addSLADialog.Controls.CancelButton.IsEnabled)
            {
                Utilities.LogMessage("ClickOkOnAddSLADialog ::  Cancel button is enabled");
                addSLADialog.ClickCancel();
                CoreManager.MomConsole.WaitForDialogClose(addSLADialog, Constants.OneSecond * 20 / Constants.OneSecond);
            }
            else
            {
                Utilities.LogMessage("ClickOkOnAddSLADialog ::  Cancel button is not enabled");
                return false;
            }
            return true;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click on add SLA button on SlmReportParameterControlDialog
        /// </summary>
        /// 
        /// ------------------------------------------------------------------
        public bool ClickAddSLAOnSlmReportParameterControlDialog()
        {
            SlmReportParameterControlDialog slaDialog = new SlmReportParameterControlDialog(CoreManager.MomConsole);
            UISynchronization.WaitForProcessReady(slaDialog, Constants.OneSecond * 60);
            UISynchronization.WaitForUIObjectReady(slaDialog, Constants.OneSecond * 60);
            if (slaDialog.Controls.AddSLAButton.IsEnabled)
            {
                Utilities.LogMessage("ClickAddSLAOnSlmReportParameterControlDialog ::  ClickAddSLA button is enabled");
                slaDialog.ClickAddSLA();
            }
            else
            {
                Utilities.LogMessage("ClickAddSLAOnSlmReportParameterControlDialog ::  Ok button is not enabled");
                return false;
            }
            return true;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click remove on SlmReportParameterControlDialog
        /// </summary>
        /// 
        /// ------------------------------------------------------------------
        public bool ClickRemoveOnSlmReportParameterControlDialog()
        {
            SlmReportParameterControlDialog slaDialog = new SlmReportParameterControlDialog(CoreManager.MomConsole);
            UISynchronization.WaitForProcessReady(slaDialog, Constants.OneSecond * 60);
            UISynchronization.WaitForUIObjectReady(slaDialog, Constants.OneSecond * 60);
            if (slaDialog.Controls.RemoveSLAButton.IsEnabled)
            {
                Utilities.LogMessage("ClickRemoveOnSlmReportParameterControlDialog ::  Ok button is enabled");
                slaDialog.ClickSLARemove();
            }
            else
            {
                Utilities.LogMessage("ClickRemoveOnSlmReportParameterControlDialog ::  Ok button is not enabled");
                return false;
            }
            return true;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Close SlmReportParameterControlDialog
        /// </summary>
        /// 
        /// ------------------------------------------------------------------
        public bool ClickCloseSlmReportParameterControlDialog()
        {
            SlmReportParameterControlDialog slaDialog = new SlmReportParameterControlDialog(CoreManager.MomConsole);
            UISynchronization.WaitForProcessReady(slaDialog, Constants.OneSecond * 60);
            UISynchronization.WaitForUIObjectReady(slaDialog, Constants.OneSecond * 60);
            //  [v-yoz] 21OCT09   Maui 2.0 Required change: ClickTitleBarClose() method does not 
            //                      work to close the pivoted window. Need to investigate further could be
            //                      an RPF bug - using it fails with:
            //                      "Internal failure: GetUIElementFromPoint didn't return S_OK The handle is invalid."
            //                      Changed this to close the open window with Extended.CloseWindow() method.

            slaDialog.Extended.CloseWindow(); //slaDialog.ClickTitleBarClose();            
            CoreManager.MomConsole.WaitForDialogClose(slaDialog, Constants.OneSecond * 20 / Constants.OneSecond);
            return true;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// select and add item from AvilableList to selected list
        /// </summary>
        /// <param name="searchstring">Item to select</param>
        /// <param name="selectall">select all items from AvilableList</param>
        public bool SelectItemsFromAvilableList(string searchstring, bool selectall)
        {
            AddSLAObjectDialog addSLADialog = new AddSLAObjectDialog(CoreManager.MomConsole);
            // Click Add button
            // Make sure the UI is ready
            UISynchronization.WaitForUIObjectReady(addSLADialog, Constants.DefaultDialogTimeout);
            Sleeper.Delay(Constants.OneSecond * 5);

            //Utilities.LogMessage("SelectItemsFromAvilableList ::   AddSLAObjectDialog - Added item count: " + nAddedCount);

            if (selectall)
                addSLADialog.Controls.AvailableItemsListView.SelectAll();
            else
            {
                int index = consoleApp.GeListViewtColumnPosition(SlmReportParameterControlDialog.Strings.ServiceLevelAggrementColumn
                    , addSLADialog.Controls.AvailableItemsListView) - 1;
                consoleApp.SelectListViewItems(searchstring, index,
                addSLADialog.Controls.AvailableItemsListView, true);
            }

            Utilities.LogMessage("SelectItemsFromAvilableList ::  AddSLAObjectDialog - Click add button");
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(addSLADialog.Controls.AddButton, Constants.OneMinute);
            addSLADialog.ClickAdd();

            // Make sure the UI is ready
            UISynchronization.WaitForUIObjectReady(addSLADialog, Constants.DefaultDialogTimeout);
            Utilities.LogMessage("SelectItemsFromAvilableList :: WaitForUIObjectReady returned after Clicking add button");

            return true;
        }
        /// <summary>
        /// Validate the Search in AvailableItemsListView or SelectedObjectsListView of Add Object Dialog.
        /// </summary>
        /// <param name="objectNameComboBox"></param>
        /// <param name="searchString"></param>
        /// <param name="verifyinselectview">SelectedObjectsListView / AvailableItemsListView</param>
        public bool ValidateSLASearchInListItem(enumSearchTypeName objectNameComboBox, string searchString, bool verifyinselectview)
        {

            AddSLAObjectDialog addSLADialog = new AddSLAObjectDialog(CoreManager.MomConsole);
            ListView listview;
            if (verifyinselectview)
                listview = addSLADialog.Controls.AvailableItemsListView;
            else
                listview = addSLADialog.Controls.SelectedObjectsListView;

            int nCount = listview.Count;
            int objectCount = 0;
            if (nCount > 0)
            {
                // Count no.Of valid search results 
                switch (objectNameComboBox)
                {
                    case enumSearchTypeName.BeginsWith:
                        objectCount = consoleApp.GetMatchingListViewItemsCount(searchString, ConsoleApp.StringMatchAt.BeginsWith, 0, listview);
                        break;

                    case enumSearchTypeName.Contains:
                        objectCount = consoleApp.GetMatchingListViewItemsCount(searchString, ConsoleApp.StringMatchAt.Constains, 0, listview);
                        break;

                    case enumSearchTypeName.EndsWith:
                        objectCount = consoleApp.GetMatchingListViewItemsCount(searchString, ConsoleApp.StringMatchAt.EndsWith, 0, listview);
                        break;
                    default:
                        Utilities.LogMessage("ValidateSLASearchInListItem :: Invalid objectname: string >> " + objectNameComboBox);
                        return false;
                }

                if (objectCount != nCount) //  && consoleApp.GetMatchingListViewItemsCount(searchString, ConsoleApp.StringMatchAt.Constains, 0, listview) == 0
                {
                    // The search returns incorrect results
                    Utilities.LogMessage("ValidateSLASearchInListItem :: Search failed to retrive correct results.");
                    return false;
                }
            }
            else
            {
                Utilities.LogMessage("ValidateSLASearchInListItem :: Search could not retrieve any objects.");
                return false;
            }
            return true;

        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// VerifySLASearchAdd : verify search results in Add servicelevel grid
        /// </summary>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridCellNotFoundException">DataGridCellNotFoundException</exception>        
        /// <param name="searchString">searchString</param>
        /// ------------------------------------------------------------------
        public bool VerifySLASearchAdd(string searchString)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage("Verify search results : " + currentMethod);

            SlmReportParameterControlDialog slaReportDialog = new SlmReportParameterControlDialog(CoreManager.MomConsole);
            UISynchronization.WaitForProcessReady(slaReportDialog, Constants.OneSecond * 60);
            UISynchronization.WaitForUIObjectReady(slaReportDialog, Constants.OneSecond * 60);

            Utilities.LogMessage("Created object of SlmReportParameterControlDialog" + currentMethod);

            // get the gridview

            DataGridViewRow searchNameRow = slaReportDialog.GetDataGrid().FindData(searchString, SlmReportParameterControlDialog.Strings.ServiceLevelAggrementColumn);

            if (searchNameRow == null)
            {
                Utilities.LogMessage("Unable to verify results in AddServiceLevel Grid : verifying string " + searchString + "  :" + currentMethod);
                throw new DataGrid.Exceptions.DataGridCellNotFoundException(currentMethod);
            }
            return true;

        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// remove input searchstring from servicelevel grid
        /// </summary>
        /// <param name="searchstring"> Search item</param>
        /// ------------------------------------------------------------------
        public bool RemoveItemsFromSelectedListInSlmReporDialog(string searchstring)
        {
            SlmReportParameterControlDialog slmReportDialog = new SlmReportParameterControlDialog(CoreManager.MomConsole);
            UISynchronization.WaitForUIObjectReady(slmReportDialog, Constants.DefaultDialogTimeout);
            MomControls.GridControl selectedSLA = slmReportDialog.GetDataGrid();

            int nAddedCount = selectedSLA.Rows.Count;
            Utilities.LogMessage("RemoveItemsFromSelectedListInSlmReporDialog :: current item count: " + nAddedCount);

            if (nAddedCount == 0) return true; // nothing to remove

            selectedSLA.FindData(searchstring).Click();

            Utilities.LogMessage("RemoveItemsFromSelectedListInSlmReporDialog ::  - Click Remove button");
            slmReportDialog.ClickSLARemove();

            // Make sure the UI is ready
            UISynchronization.WaitForUIObjectReady(slmReportDialog, Constants.DefaultDialogTimeout);
            Utilities.LogMessage("RemoveItemsFromSelectedListInSlmReporDialog :: WaitForUIObjectReady returned after Clicking Remove button");

            return true;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// remove input searchstring from SelectedList in AddSLADialog
        /// </summary>
        /// <param name="searchstring"> Search item</param>
        /// <param name="removeall">remove all items from </param>
        /// ------------------------------------------------------------------
        public bool RemoveItemsFromSelectedList(string searchstring, bool removeall)
        {
            AddSLAObjectDialog addSLADialog = new AddSLAObjectDialog(CoreManager.MomConsole);

            UISynchronization.WaitForUIObjectReady(addSLADialog, Constants.DefaultDialogTimeout);
            Sleeper.Delay(Constants.OneSecond * 5);

            int nAddedCount = addSLADialog.Controls.SelectedObjectsListView.Count;
            Utilities.LogMessage("RemoveItemsFromSelectedList ::   AddObjectDialog - current item count: " + nAddedCount);

            if (removeall)
                addSLADialog.Controls.SelectedObjectsListView.SelectAll();
            else
            {
                int index = consoleApp.GeListViewtColumnPosition(SlmReportParameterControlDialog.Strings.ServiceLevelAggrementColumn
                    , addSLADialog.Controls.SelectedObjectsListView) - 1;
                consoleApp.SelectListViewItems(searchstring, index,
                addSLADialog.Controls.SelectedObjectsListView, true);
            }

            Utilities.LogMessage("RemoveItemsFromSelectedList ::  addDialogButton - Click Remove button");
            addSLADialog.ClickRemove();

            // Make sure the UI is ready
            UISynchronization.WaitForUIObjectReady(addSLADialog, Constants.DefaultDialogTimeout);
            Utilities.LogMessage("RemoveItemsFromSelectedList :: WaitForUIObjectReady returned after Clicking Remove button");

            if (addSLADialog.Controls.SelectedObjectsListView.Count != 0 && removeall == true)
            {
                //Remove Button does not function properly
                Utilities.LogMessage("RemoveItemsFromSelectedList :: Remove button failed to Remove all objects.");
                return false;
            }
            return true;
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Selects  Additional TimeInterval ListBox in SlmReportParameterControlDialog
        /// </summary>
        /// <param name="ArrayofItemsToSelect">list of items to select</param>
        /// ------------------------------------------------------------------
        public void SelectItemsInAdditionalTimeIntervalListBox(string[] ArrayofItemsToSelect)
        {

            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage("Entering method :: " + currentMethod);
            SlmReportParameterControlDialog slaDialog = new SlmReportParameterControlDialog(CoreManager.MomConsole);
            UISynchronization.WaitForUIObjectReady(slaDialog, Constants.DefaultDialogTimeout);

            //MAUI2.0 dont suport UnselectAll method, comment it. 
            //slaDialog.Controls.AdditionalTimeIntervalsListBox.UnselectAll();
            //Utilities.LogMessage("Unselect All items in AdditionalTimeIntervalsListBox listbox in:: " + currentMethod);

            foreach (string checkListBoxItem in ArrayofItemsToSelect)
            {
                Utilities.LogMessage("Selecting item " + checkListBoxItem + " in AdditionalTimeIntervalsListBox :: " + currentMethod);
                if (slaDialog.Controls.AdditionalTimeIntervalsListBox[checkListBoxItem, true].Checked != true)
                {
                    slaDialog.Controls.AdditionalTimeIntervalsListBox.SelectItem(checkListBoxItem, true);
                    Utilities.LogMessage("Checked item " + checkListBoxItem + " in AdditionalTimeIntervalsListBox :: " + currentMethod);
                    UISynchronization.WaitForProcessReady(slaDialog, Constants.DefaultDialogTimeout);
                    UISynchronization.WaitForUIObjectReady(slaDialog, Constants.DefaultDialogTimeout);
                }
            }
        }
        /// ------------------------------------------------------------------
        /// <summary>
        /// Verify Selected Items In Additional TimeInterval ListBox in SlmReportParameterControlDialog
        /// </summary>
        /// <param name="ArrayofItemsToSelect">list of items to select</param>
        /// ------------------------------------------------------------------
        public bool VerifySelectItemsInAdditionalTimeIntervalsListBox(string[] ArrayofItemsToSelect)
        {
            bool found = true;
            SlmReportParameterControlDialog slaDialog = new SlmReportParameterControlDialog(CoreManager.MomConsole);

            foreach (string checkListBoxItem in ArrayofItemsToSelect)
            {
                found = false;
                for (int i = 0; i < slaDialog.Controls.AdditionalTimeIntervalsListBox.Count; i++)
                {

                    if (slaDialog.Controls.AdditionalTimeIntervalsListBox[i].Text == checkListBoxItem && slaDialog.Controls.AdditionalTimeIntervalsListBox[i].Checked != true)
                    {
                        found = true;
                        break; //item found so break
                    }

                }
                if (!found)
                    break;
            }
            return found;
        }

        #region IsReportsDeployed
        /// <summary>
        /// Check whether Reports are Deployed.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>Returns bool with true or false stating whether reports are deployed.</returns>
        /// <exception cref="Exception"></exception>
        /// [cdelthon]   03OCT06 Created.
        public static bool IsReportsDeployed(IContext context)
        {
            Utilities.LogMessage("Check whether the reports deployed.....");
            try
            {
                Mom.Test.UI.Core.Common.Topology.Initialize();
                DBUtil.ConnectToMOMDW(Topology.RootMomSdkServerName);

                string AlertReportName = "Alerts";
                string AlertLatencyReportName = "Alert Logging Latency";
                string AvailabilityReportName = "Availability";
                string ConfigurationChangesReportName = "Configuration Changes";
                string EventAnalysisReportName = "Event Analysis";
                //string ServiceLevelReportName = "Event Analysis";

                string sqlAlertQuery = "select * from dbo.Report where ReportDefaultName = '" + AlertReportName + "'";
                string sqlAlertLatencyQuery = "select * from dbo.Report where ReportDefaultName = '" + AlertLatencyReportName + "'";
                string sqlAvailabilityQuery = "select * from dbo.Report where ReportDefaultName = '" + AvailabilityReportName + "'";
                string sqlConfigurationChangesQuery = "select * from dbo.Report where ReportDefaultName = '" + ConfigurationChangesReportName + "'";
                string sqlEventAnalysisReportNameQuery = "select * from dbo.Report where ReportDefaultName = '" + EventAnalysisReportName + "'";
                //check whether MP transfered to the DW. Try for maximum 10 minutes.
                bool reportDeployed = false;
                for (int i = 0; i <= 60; i++)
                {
                    if (DBUtil.IsDataExists(sqlAlertQuery)
                        && DBUtil.IsDataExists(sqlAlertLatencyQuery)
                        && DBUtil.IsDataExists(sqlAvailabilityQuery)
                        && DBUtil.IsDataExists(sqlConfigurationChangesQuery)
                        && DBUtil.IsDataExists(sqlEventAnalysisReportNameQuery))
                    {
                        context.Trc("All reports shown in DW");
                        reportDeployed = true;
                        break;
                    }
                    context.Alw("not all reports reach the DW. Will check again in 30 seconds...");
                    Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond * 30);

                }
                /*if (!reportDeployed)
                {
                    throw new GroupAbort("Reports not deployed in 30 minutes");
                }*/
                return reportDeployed;
            }
            catch (Exception e)
            {
                throw new Exception("Check for reports deployment failed", e);
            }
            finally
            {
                DBUtil.CloseMOMDWConnection();
                //return mpTransfered;
            }
        }
        #endregion

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to save a report to a management pack.
        /// The report to be saved must be listed in Favorite reports folder
        /// </summary>
        /// <param name="reportName">Which report to be saved.</param>
        /// <param name="mpReportName">Report name in MP</param>
        /// <returns>True if save succeed, otherwise False</returns>
        /// <history>
        /// [v-liqluo] 04/05/2010 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static bool SaveReportToManagementPack(string reportName, string reportNameInMP)
        {
            //Save to Default Management Pack
            string defaultManagmentPackName = CoreManager.MomConsole.GetIntlStr(
                ManagementPackConstants.ResourceDefaultManagementPackName);

            if (defaultManagmentPackName == null)
            {
                throw new ArgumentNullException("Failed to extract display name for 'Default Management Pack'.");
            }

            return SaveReportToManagementPack(reportName, reportNameInMP, defaultManagmentPackName, string.Empty);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to save a report to a management pack.
        /// The report to be saved must be listed in Favorite reports folder
        /// </summary>
        /// <param name="reportName">Which report to be saved.</param>
        /// <param name="mpReportName">Report name in MP</param>
        /// <param name="mpName">Save the report to which MP</param>
        /// <returns>True if save succeed, otherwise False</returns>
        /// <history>
        /// [v-liqluo] 04/05/2010 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static bool SaveReportToManagementPack(string reportName, string reportNameInMP, string mpName)
        {
            return SaveReportToManagementPack(reportName, reportNameInMP, mpName, string.Empty);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to save a report to a management pack.
        /// The report to be saved must be listed in Favorite reports folder
        /// </summary>
        /// <param name="reportName">Which report to be saved</param>
        /// <param name="mpReportName">Report name in MP</param>
        /// <param name="mpName">Save the report to the MP mpName</param>
        /// <param name="reportDescription">Report description</param>
        /// <returns>True if save succeed, otherwise False</returns>
        /// <history>
        /// [v-liqluo] 04/05/2010 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static bool SaveReportToManagementPack(string reportName, string reportNameInMP, string mpName, string reportDescription)
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethodName + "_Started...");
            bool saveSucceed = false;

            if (string.IsNullOrEmpty(reportName) || 
                string.IsNullOrEmpty(reportNameInMP) || 
                string.IsNullOrEmpty(mpName))
            {
                throw new ArgumentNullException("reportName or reportNameInMP or mpName cannot be null or empty.");
            }

            #region Navigate to Favorite Reports folder
            //Make sure mom console is foreground.
            if (!CoreManager.MomConsole.MainWindow.Extended.IsForeground)
            {
                Utilities.LogMessage(currentMethodName + "_Bring to foreground.");
                CoreManager.MomConsole.BringToForeground();
                CoreManager.MomConsole.MainWindow.Extended.SetFocus();
            }
            Utilities.LogMessage(currentMethodName + "_Clicking the Reporting wunderbar.");
            CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(Mom.Test.UI.Core.Console.NavigationPane.WunderBarButton.Reporting);

            //Select Favorite Reports folder
            TreeNode favoriteReportsTreeNode = CoreManager.MomConsole.NavigationPane.SelectNode(
                Strings.FavoriteReports,
                NavigationPane.NavigationTreeView.Reporting,
                MouseFlags.LeftButton);
            #endregion

            #region Find report and Save to Management pack.
            if (CoreManager.MomConsole.ViewPane.ListViewReports != null &&
                CoreManager.MomConsole.ViewPane.ListViewReports.Count > 0)
            {
                //find the report and select it.
                foreach (ListViewItem item in CoreManager.MomConsole.ViewPane.ListViewReports.Items)
                {
                    if (item != null && item.Text == reportName)
                    {
                        item.Select();
                        Utilities.LogMessage(currentMethodName + "_report is found and selected.");
                        break;
                    }
                    else
                    {
                        Utilities.LogMessage(currentMethodName + "_Current ListView item's text is:" +
                            item.Text);
                    }
                }

                //Save report to management pack if found report
                Utilities.LogMessage(currentMethodName + "_SelectedIndex: " +
                    CoreManager.MomConsole.ViewPane.ListViewReports.SelectedIndex);
                if (CoreManager.MomConsole.ViewPane.ListViewReports.SelectedIndex >= 0)
                {
                    CoreManager.MomConsole.ExecuteContextMenu(Strings.SaveToManagementPackContextMenuText, true);

                    SaveReportToManagementPackWizardGeneralDialog saveReportToManagementPackWizardGeneralDialog =
                        new SaveReportToManagementPackWizardGeneralDialog(CoreManager.MomConsole);
                    saveReportToManagementPackWizardGeneralDialog.ScreenElement.WaitForReady();

                    saveSucceed = SaveReportToManagementPack(saveReportToManagementPackWizardGeneralDialog,
                        reportNameInMP,
                        mpName,
                        reportDescription);
                }
                else
                {
                    Utilities.LogMessage(currentMethodName + "_Don't find report: " + reportName);
                }
            }
            else
            {
                Utilities.LogMessage(currentMethodName + "_ListViewReports is null or empty.");
            }
            #endregion

            return saveSucceed;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to save report to management pack
        /// </summary>
        /// <param name="saveReportToManagementPackWizardGeneralDialog">save report to management pack wizard dialog</param>
        /// <param name="mpReportName">Report name in MP</param>
        /// <param name="mpName">Save the report to the MP mpName</param>
        /// <param name="reportDescription">Report description</param>
        /// <returns>True if save succeed, otherwise False</returns>
        /// <history>
        /// [v-liqluo] 04/05/2010 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static bool SaveReportToManagementPack(
            SaveReportToManagementPackWizardGeneralDialog saveReportToManagementPackWizardGeneralDialog,
            string reportNameInMP, 
            string mpName, 
            string reportDescription)
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            bool saveSucceed = false;

            if (saveReportToManagementPackWizardGeneralDialog == null ||
                string.IsNullOrEmpty(reportNameInMP) ||
                string.IsNullOrEmpty(mpName))
            {
                throw new ArgumentNullException(currentMethodName + "_saveReportToManagementPackWizardGeneralDialog or " +
                    "reportNameInMP or mpName cannot be null or empty.");
            }

            saveReportToManagementPackWizardGeneralDialog.NameText = reportNameInMP;
            Utilities.LogMessage(currentMethodName + "_Report name is set to: " + reportNameInMP);
            saveReportToManagementPackWizardGeneralDialog.DescriptionText = reportDescription;
            Utilities.LogMessage(currentMethodName + "_Report description is set to: " + reportDescription);
            saveReportToManagementPackWizardGeneralDialog.SelectDestinationManagementPackText = mpName;
            Utilities.LogMessage(currentMethodName + "_MP is set to: " + mpName);
            saveReportToManagementPackWizardGeneralDialog.ClickFinish();
            Utilities.LogMessage(currentMethodName + "_Finish button clicked.");

            //Check text of ResultLable to see whether save succeed.
            SaveReportToManagementPackWizardCompletionDialog saveReportToManagementPackWizardCompletionDialog =
                new SaveReportToManagementPackWizardCompletionDialog(CoreManager.MomConsole);
            saveReportToManagementPackWizardCompletionDialog.ScreenElement.WaitForReady();
            if (saveReportToManagementPackWizardCompletionDialog.Controls.ResultLable != null)
            {
                if (saveReportToManagementPackWizardCompletionDialog.Controls.ResultLable.Text.Equals(
                    SaveReportToManagementPackWizardCompletionDialog.Strings.SavedSucceedText))
                {
                    saveSucceed = true;
                    Utilities.LogMessage(currentMethodName + "_Save report to management pack succeed.");
                }
                else
                {
                    Utilities.LogMessage(currentMethodName + "_Result text is: " +
                    saveReportToManagementPackWizardCompletionDialog.Controls.ResultLable.Text);
                }
            }
            else
            {
                Utilities.LogMessage(currentMethodName + "_ResultLable is NULL.");
            }

            saveReportToManagementPackWizardCompletionDialog.ClickClose();
            CoreManager.MomConsole.WaitForDialogClose(saveReportToManagementPackWizardCompletionDialog, 5);
            Utilities.LogMessage(currentMethodName + "_Click Close button.");

            return saveSucceed;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to check if report present in management pack folder
        /// </summary>
        /// <param name="reportDisplayName">Report display name</param>
        /// <param name="mpDisplayName">MP display name</param>
        /// <returns>True if report present in the management pack folder, otherwise False</returns>
        /// <history>
        /// [v-liqluo] 04/05/2010 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static bool IsReportPresentInManagementPack(string reportDisplayName, string mpDisplayName)
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethodName + "_Started...");
            bool reportFound = false;

            if (string.IsNullOrEmpty(reportDisplayName) || string.IsNullOrEmpty(mpDisplayName))
            {
                throw new ArgumentNullException(currentMethodName + "_reportDisplayName or mpDisplayName " +
                    "cannot be null or empty.");
            }

            Reporting reporting=new Reporting();

            if (reporting.IsReportingUiNodeThere(mpDisplayName))
            {
                int nOfTries = 1;
                int maxTries = 15;
                while (CoreManager.MomConsole.ViewPane.ListViewReports != null && 
                    !reportFound && nOfTries <= maxTries)
                {
                    //Refresh listview first
                    CoreManager.MomConsole.ViewPane.ListViewReports.Click();
                    CoreManager.MomConsole.ViewPane.ListViewReports.Click(MouseClickType.SingleClick,MouseFlags.RightButton);
                    Menu contextMenu = new Menu(Constants.DefaultContextMenuTimeout);
                    contextMenu.ExecuteMenuItem(Strings.Refresh);
                    CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneSecond * 5);

                    if (CoreManager.MomConsole.ViewPane.ListViewReports.Count > 0)
                    {
                        foreach (ListViewItem item in CoreManager.MomConsole.ViewPane.ListViewReports.Items)
                        {
                            if (item.Text.Equals(reportDisplayName))
                            {
                                Utilities.LogMessage(currentMethodName + "_Report present in the Management Pack: " +
                                    mpDisplayName + " Folder after " + nOfTries + " minutes.");
                                reportFound = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        Utilities.LogMessage(currentMethodName + "_ListViewReports is null or empty.");
                    }

                    if (!reportFound && nOfTries < maxTries)
                    {
                        Utilities.LogMessage(currentMethodName + "_Don't find report " + reportDisplayName +
                            ", sleep one minute and retry again. Attempt " + nOfTries + " of " + maxTries);
                        Sleeper.Delay(Constants.OneMinute);
                        nOfTries++;
                    }
                }
            }

            return reportFound;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to delete report from management pack folder
        /// </summary>
        /// <param name="reportDisplayName">Report display name</param>
        /// <param name="mpDisplayName">MP display name</param>
        /// <returns>True if report present in the management pack folder, otherwise False</returns>
        /// <history>
        /// [v-liqluo] 04/05/2010 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static bool DeleteReportFromManagementPack(string reportDisplayName, string mpDisplayName)
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethodName + "_Started...");
            bool reportDeleted = false;
            bool needVerify = false;

            if (string.IsNullOrEmpty(reportDisplayName) || string.IsNullOrEmpty(mpDisplayName))
            {
                throw new ArgumentNullException(currentMethodName + "_reportDisplayName or mpDisplayName " +
                    "cannot be null or empty.");
            }
            
            Reporting reporting = new Reporting();

            if (reporting.IsReportingUiNodeThere(mpDisplayName))
            {
                if (CoreManager.MomConsole.ViewPane.ListViewReports != null &&
                    CoreManager.MomConsole.ViewPane.ListViewReports.Count > 0)
                {
                    Utilities.LogMessage(currentMethodName + "_ListViewReports.Count is: " + 
                        CoreManager.MomConsole.ViewPane.ListViewReports.Count);

                    //If the report to be deleted is the last report of the management pack,
                    //will verify the management pack folder disappeared after deleting the report.
                    if (CoreManager.MomConsole.ViewPane.ListViewReports.Count == 1)
                    {
                        needVerify = true;
                        Utilities.LogMessage(currentMethodName + "_Set needVerify to True, " +
                            "will verify the management pack folder disappear after deleting the last report.");
                    }

                    //Find the report to be deleted and then delete it.
                    foreach (ListViewItem item in CoreManager.MomConsole.ViewPane.ListViewReports.Items)
                    {
                        if (item.Text.Equals(reportDisplayName))
                        {
                            Utilities.LogMessage(currentMethodName + "_Find report " + reportDisplayName +
                                " in the Management Pack: " + mpDisplayName + " Folder.");
                            item.Click(MouseClickType.SingleClick, MouseFlags.RightButton);

                            Utilities.LogMessage(currentMethodName + "_Get context menu and execute Delete menu item.");
                            Menu contextMenu = new Menu(Constants.DefaultContextMenuTimeout);
                            MauiCollection<MenuItem> menuItems = contextMenu.get_MenuItems(false);
                            Utilities.LogMessage(currentMethodName + "_menuList count: " + menuItems.Count);

                            foreach (MenuItem menuItem in menuItems)
                            {
                                Utilities.LogMessage(currentMethodName + "_MenuItem: " + menuItem.Text);

                                if (menuItem != null && menuItem.Text.Equals(Strings.Delete))
                                {
                                    if (menuItem.Enabled)
                                    {
                                        menuItem.Execute();
                                        Utilities.LogMessage(currentMethodName + "_MenuItem is executed.");
                                        CoreManager.MomConsole.ConfirmChoiceDialog(ConsoleApp.ButtonCaption.Yes,
                                            Mom.Test.UI.Core.Console.Dialogs.ExceptionErrorDialog.Strings.DialogTitle,
                                            StringMatchSyntax.ExactMatch,
                                            ConsoleApp.ActionIfWindowNotFound.Ignore);
                                        CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneSecond * 10);
                                        Utilities.LogMessage(currentMethodName + "_Delete report succeefully.");
                                        reportDeleted = true;
                                        break;
                                    }
                                    else
                                        throw new MauiException("Menu Item " + Strings.Delete + " is not executable.");
                                }
                                else
                                {
                                    Utilities.LogMessage(currentMethodName + "_Current menu time " +
                                        "is not \'" + Strings.Delete + "\', value is: " + menuItem.Text);
                                }
                            }

                            break;
                        }
                        else
                        {
                            Utilities.LogMessage(currentMethodName + "_Current report name is not " + reportDisplayName
                                + " report is: " + item.Text);
                        }
                    }
                }
                else
                {
                    Utilities.LogMessage(currentMethodName + "_ListViewReports is null or empty.");
                }
            }

            //Verify the management pack node disappeared after deleting the last report in it.
            if (reportDeleted && needVerify)
            {
                if (IsUINodeDisappeared(mpDisplayName, 30))
                {
                    Utilities.LogMessage(currentMethodName + "_Management pack folder disappeared.");
                }
                else
                {
                    Utilities.LogMessage(currentMethodName + "_Management pack folder is still there after max " +
                        "wait time: 30 minutes. Set reportDeleted back to False.");
                    reportDeleted = false;
                }

            }
            return reportDeleted;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to verify if the UI node disappeared(don't present on UI).
        /// </summary>
        /// <param name="nodeName">node name</param>
        /// <param name="maxMinutes">max minutes to wait node to disappeare from UI</param>
        /// <returns>True if disappeared, otherwise False</returns>
        /// <history>
        /// [v-liqluo] 04/05/2010 Created
        /// </history>        
        /// -----------------------------------------------------------------------------
        private static bool IsUINodeDisappeared(string nodeName, int maxMinutes)
        {
            bool nodeDisappered = false;
            int nOfTries = 1;
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethodName + "_Started...");

            while (!nodeDisappered && nOfTries <= maxMinutes)
            {
                try
                {
                    // Select the Root Node for Reporting TreeNode and refresh it using F5
                    Utilities.LogMessage(currentMethodName + "_Select the Root Node for Reporting TreeNode and refresh it.");
                    CoreManager.MomConsole.NavigationPane.SelectNode(Strings.ReportingRootFolderName, NavigationPane.NavigationTreeView.Reporting);
                    CoreManager.MomConsole.NavigationPane.SendKeys(KeyboardCodes.F5);
                    CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneSecond * 10);

                    //Trying to select the node, if succeed, then the node is still there.
                    Utilities.LogMessage(currentMethodName + "_Trying to select the node: " + nodeName);
                    CoreManager.MomConsole.NavigationPane.SelectNode(nodeName, NavigationPane.NavigationTreeView.Reporting);
                    Utilities.LogMessage(currentMethodName + "_Node " + nodeName + " is still there. " +
                        "Sleep one minute and try again. Attempt " + nOfTries + " of " + maxMinutes);
                    Sleeper.Delay(Constants.OneMinute);
                }
                catch (Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException)
                {
                    //Catch expected exception, then the node disappeared
                    Utilities.LogMessage(currentMethodName + "_The node " + nodeName +
                        " disappeared after " + nOfTries + " minutes.");
                    nodeDisappered = true;
                }

                nOfTries++;
            }

            return nodeDisappered;
        }

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for Reporting Add Object Dialog
        /// ComboBox options
        /// </summary>
        /// <history> 	
        ///   [a-omkasi]  01Jul08: Created. Added resource strings for Reporting Addd Objects
        /// Dialog ComboBox options 
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SearchPatternContains
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearchPatternContains = ";Contains;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringObjectPickerResources;SearchPattern_Contains";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SearchPatternBeginsWith
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearchPatternBeginsWith = ";Begins with;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringObjectPickerResources;SearchPattern_BeginsWith";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SearchPatternEndsWith
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearchPatternEndsWith = ";Ends with;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.Monitoring.ReportMonitoringObjectPickerResources;SearchPattern_EndsWith";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Open
            /// Which is used to open a report.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOpen = ";Open;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Views.ReportsView.ReportsViewResources;RunReportCommandText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Refresh
            /// Which is Used to Refresh UI Console
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRefresh = ";Refresh;ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ReportForm;refreshContextToolStripMenuItem.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for: Schedule
            /// Which is used to schedule a report.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSchedule = ";Schedule;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Reporting.resources.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Views." +
                "ReportsView.ReportsViewresources;ScheduleReportCommandText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource for the Reporting pane's name.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceReportingPane = ";Reporting;" +
                "ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting." +
                "WunderBar.ReportingPageResources;WunderBarPageName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// DwManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string DwManagementPack = Mom.Test.UI.Core.Common.ManagementPackConstants.SystemCenterOperationsManagerDataWarehouseLibraryMPName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// SLAManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string SLAManagementPack = Mom.Test.UI.Core.Common.ManagementPackConstants.SystemCenterOperationsManagerDataWarehouseSLAMPName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains ReportingUITestLibrary Display Name 
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string ReportingUITestLibraryDisplayName = "ReportingUI.Test.Library";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains ReportingUITestLibrary Display Name 
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string ResourceReportingRootFolderName = ";Reporting;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.ReportResources;ReportsRootFolderName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains ResourceReportingRunMenu 
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string ResourceReportingRunMenu = ";Run;ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ReportForm;runToolStripButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains ResourceReportingShoworHideParameter 
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string ResourceReportingShoworHideParameter = ";Show or Hide Parameter Area;ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ReportForm;parametersToolStripButton.ToolTipText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains ResourceSaveToManagementPackContextMenuText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string ResourceSaveToManagementPackContextMenuText = ";Save to management pack;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Views.ReportsView.ReportsViewResources;SaveReportCommandText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Delete(MenuItem of context menu)
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDelete = ";Delete;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.TaskPanePages.Tasks.TasksPage;deleteFavoriteTaskMenuItem.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel Schedule(MenuItem of context menu)
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancelSchedule = ";Cancel Schedule;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Views.ReportSubscriptionsView.ReportSubscriptionsViewResources;DeleteReportScheduleCommandText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Yesterday(MenuItem of popup menu in performance dialog)
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceYesterdayMenu = ";Yesterday;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.RelativeDateResources;DateMenuText_Yesterday";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Scheduled Reports Folder
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceScheduledReports = ";Scheduled Reports;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.WunderBar.ReportingPageResources;SubscriptionNodeText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Favorite Reports Folder
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFavoriteReports = ";Favorite Reports;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.WunderBar.ReportingPageResources;FavoritesNodeText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// File Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFileMenu = ";&File;ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ReportForm;fileToolStripMenuItem.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Save to favorites Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSaveToFavoritesMenu = ";Save &to favorites...;ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ReportForm;favoriteToolStripMenuItem.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Schedule Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceScheduleMenu = ";Sc&hedule...;ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ReportForm;scheduleToolStripMenuItem.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Save to management pack Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSaveToManagementPackMenu = ";Save to &management pack...;ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.ReportForm;saveToolStripMenuItem.Text";
            #endregion

            #region Private Members
            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Catches the translated resource string for: Schedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSchedule;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Reporting
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedReportingPane;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ResourceSearchPatternContains
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearchPatternContains;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ResourceSearchPatternBeginsWith
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearchPatternBeginsWith;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ResourceSearchPatternEndsWith
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearchPatternEndsWith;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// cache to hold Microsoft Generic Report Library string
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMicrosoftGenericReportLibrary;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// cache to hold Reporting Root Folder Name string
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedReportingRootFolderName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// cache to hold Refresh string
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRefresh;

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Catches the translated resource string for: Open
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOpen;

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Catches the translated resource string for: Run
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            ///  Catches the translated resource string for: ShoworHideParameter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShoworHideParameter;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Catches the translated resource string for:  SaveToManagementPackContextMenuText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSaveToManagementPackContextMenuText;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Delete
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDelete;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CancelSchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancelSchedule;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  YesterdayMenu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYesterdayMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AuthoredReports
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedScheduledReports;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FavoriteReports
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFavoriteReports;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  FileMenu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFileMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SaveToFavoritesMenu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSaveToFavoritesMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ScheduleMenu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedScheduleMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SaveToManagementPackMenu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSaveToManagementPackMenu;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the run reporting menu string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 11/11/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunMenu
            {
                get
                {
                    if ((cachedRunMenu == null))
                    {
                        cachedRunMenu = CoreManager.MomConsole.GetIntlStr(ResourceReportingRunMenu);
                    }

                    return cachedRunMenu;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ResourceReportingShoworHideParameter menu string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 11/11/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShoworHideParameter
            {
                get
                {
                    if ((cachedShoworHideParameter == null))
                    {
                        cachedShoworHideParameter = CoreManager.MomConsole.GetIntlStr(ResourceReportingShoworHideParameter);
                    }

                    return cachedShoworHideParameter;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Reporting translated resource string
            /// </summary>
            /// <history>
            /// 	[cdelthon] 02/07/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ReportingPane
            {
                get
                {
                    if ((cachedReportingPane == null))
                    {
                        cachedReportingPane = CoreManager.MomConsole.GetIntlStr(ResourceReportingPane);
                    }

                    return cachedReportingPane;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SearchPatternContains translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 6/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SearchPatternContains
            {
                get
                {
                    if (cachedSearchPatternContains == null)
                    {
                        cachedSearchPatternContains = CoreManager.MomConsole.GetIntlStr(ResourceSearchPatternContains);
                    }

                    return cachedSearchPatternContains;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SearchPatternBeginsWith translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 6/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SearchPatternBeginsWith
            {
                get
                {
                    if (cachedSearchPatternBeginsWith == null)
                    {
                        cachedSearchPatternBeginsWith = CoreManager.MomConsole.GetIntlStr(ResourceSearchPatternBeginsWith);
                    }

                    return cachedSearchPatternBeginsWith;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SearchPatternEndsWith translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 6/30/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SearchPatternEndsWith
            {
                get
                {
                    if (cachedSearchPatternEndsWith == null)
                    {
                        cachedSearchPatternEndsWith = CoreManager.MomConsole.GetIntlStr(ResourceSearchPatternEndsWith);
                    }

                    return cachedSearchPatternEndsWith;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Connect to the MOM SDK and get the display name for 
            /// Microsoft.SystemCenter.DataWarehouse.Report.Library management
            /// pack.
            /// </summary>
            /// <history>
            ///    [cdelthon] 01/02/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MicrosoftGenericReportLibrary
            {
                get
                {
                    Utilities.LogMessage("Get MicrosoftGenericReportLibrary name");
                    if (cachedMicrosoftGenericReportLibrary == null)
                    {
                        ManagementGroup mg = Utilities.ConnectToManagementServer();

                        System.Collections.Generic.IList<ManagementPack> mps = mg.ManagementPacks.GetManagementPacks();
                        int index = 0;
                        foreach (ManagementPack mp in mps)
                        {
                            index++;
                            if (DwManagementPack == mp.Name)
                            {
                                cachedMicrosoftGenericReportLibrary = mp.DisplayName;

                                Utilities.LogMessage("ManagementPack # " + index.ToString());
                                Utilities.LogMessage("ManagementPack DisplayName is " + mp.DisplayName);
                                Utilities.LogMessage("ManagementPack FriendlyName is " + mp.FriendlyName);
                                Utilities.LogMessage("ManagementPack Id is " + mp.Id.ToString());
                                Utilities.LogMessage("ManagementPack Name is " + mp.Name);
                            }
                        }
                    }
                    return cachedMicrosoftGenericReportLibrary;
                }
            }

            #region GetGenericReportString
            /// <summary>
            /// Get Generic Report Display String
            /// </summary>
            /// <param name="context"></param>
            /// <param name="mpSysName"></param>
            /// <returns></returns>
            /// <exception cref="System.Exception"></exception>
            /// <history>
            ///     [cdelthon] 01/02/2007 Created
            /// </history>
            public static string GetGenericReportString(IContext context, string mpSysName)
            {
                string genericReportName;
                try
                {
                    Mom.Test.UI.Core.Common.Topology.Initialize();
                    DBUtil.ConnectToMOMDW(Topology.RootMomSdkServerName);

                    string sqlQuery = "select ManagementPackDefaultName from managementpack where ManagementPackSystemName = '" + mpSysName + "'";
                    genericReportName = (string)DBUtil.ExecuteScalarQuery(sqlQuery);

                    /*
                    string returnAllMPNames = "select ManagementPackDefaultName from managementpack";
                    string [] allMPNames = (string []) DBUtil.ExecuteScalarQuery(returnAllMPNames);
                    if (0 == allMPNames.Length)
                    {
                        context.Framework.Trc("Did not find any management packs in database");
                    }
                    else
                    {
                        for (int mp = 0; mp < allMPNames.Length; mp++)
                        {
                            context.Framework.Trc("Management Pack #" + mp + "'s name is " + allMPNames[mp].ToString());
                        }
                    }

                     */
                    return genericReportName;
                }
                catch (Exception e)
                {
                    throw new Exception("Could not find ManagementPackeDefaultName in managementpack", e);
                }
                finally
                {
                    DBUtil.CloseMOMDWConnection();
                }
            }
            #endregion

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Schedule translated resource string
            /// </summary>
            /// <history>
            /// 	[cdelthon] 01/02/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Schedule
            {
                get
                {
                    if ((cachedSchedule == null))
                    {
                        cachedSchedule = CoreManager.MomConsole.GetIntlStr(ResourceSchedule);
                    }

                    return cachedSchedule;
                }
            }


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Open translated resource string
            /// </summary>
            /// <history>
            /// 	[cdelthon] 01/02/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Open
            {
                get
                {
                    if ((cachedOpen == null))
                    {
                        cachedOpen = CoreManager.MomConsole.GetIntlStr(ResourceOpen);
                    }

                    return cachedOpen;
                }
            }

            /// <summary>
            /// Exposes access to the Reporting Root Folder translated resource string
            /// </summary>
            /// <history>
            /// 	[a-omkasi] 01/02/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ReportingRootFolderName
            {
                get
                {
                    if ((cachedReportingRootFolderName == null))
                    {
                        cachedReportingRootFolderName = CoreManager.MomConsole.GetIntlStr(ResourceReportingRootFolderName);
                    }

                    return cachedReportingRootFolderName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Refresh translated resource string
            /// </summary>
            /// <history>
            /// 	[cdelthon] 01/02/2007 Created
            /// 	[v-liqluo] 04/07/2010 Edited, un-comment it.
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Refresh
            {
                get
                {
                    if ((cachedRefresh == null))
                    {
                        cachedRefresh = CoreManager.MomConsole.GetIntlStr(ResourceRefresh);
                    }

                    return cachedRefresh;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SaveToManagementPackContextMenuText translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 23/3/2010 Add
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SaveToManagementPackContextMenuText
            {
                get
                {
                    if (cachedSaveToManagementPackContextMenuText == null)
                        cachedSaveToManagementPackContextMenuText = CoreManager.MomConsole.GetIntlStr(ResourceSaveToManagementPackContextMenuText);
                    return cachedSaveToManagementPackContextMenuText;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Delete translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Add
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Delete
            {
                get
                {
                    if (cachedDelete == null)
                        cachedDelete = CoreManager.MomConsole.GetIntlStr(ResourceDelete);
                    return cachedDelete;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CancelSchedule translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Add
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CancelSchedule
            {
                get
                {
                    if (cachedCancelSchedule == null)
                        cachedCancelSchedule = CoreManager.MomConsole.GetIntlStr(ResourceCancelSchedule);
                    return cachedCancelSchedule;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the YesterdayMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 8/26/2009 Add
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string YesterdayMenu
            {
                get
                {
                    if (cachedYesterdayMenu == null)
                        cachedYesterdayMenu = CoreManager.MomConsole.GetIntlStr(ResourceYesterdayMenu);
                    return cachedYesterdayMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AuthoredReports translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 11/6/2009 Add
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ScheduledReports
            {
                get
                {
                    if (cachedScheduledReports == null)
                        cachedScheduledReports = CoreManager.MomConsole.GetIntlStr(ResourceScheduledReports);
                    return cachedScheduledReports;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AuthoredReports translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 11/6/2009 Add
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FavoriteReports
            {
                get
                {
                    if (cachedFavoriteReports == null)
                        cachedFavoriteReports = CoreManager.MomConsole.GetIntlStr(ResourceFavoriteReports);
                    return cachedFavoriteReports;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the FileMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 6/9/2010 Add
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FileMenu
            {
                get
                {
                    if (cachedFileMenu == null)
                        cachedFileMenu = CoreManager.MomConsole.GetIntlStr(ResourceFileMenu);
                    return cachedFileMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SaveToFavoritesMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 6/9/2010 Add
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SaveToFavoritesMenu
            {
                get
                {
                    if (cachedSaveToFavoritesMenu == null)
                        cachedSaveToFavoritesMenu = CoreManager.MomConsole.GetIntlStr(ResourceSaveToFavoritesMenu);
                    return cachedSaveToFavoritesMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ScheduleMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 6/9/2010 Add
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ScheduleMenu
            {
                get
                {
                    if (cachedScheduleMenu == null)
                        cachedScheduleMenu = CoreManager.MomConsole.GetIntlStr(ResourceScheduleMenu);
                    return cachedScheduleMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SaveToManagementPackMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[v-liqluo] 6/9/2010 Add
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SaveToManagementPackMenu
            {
                get
                {
                    if (cachedSaveToManagementPackMenu == null)
                        cachedSaveToManagementPackMenu = CoreManager.MomConsole.GetIntlStr(ResourceSaveToManagementPackMenu);
                    return cachedSaveToManagementPackMenu;
                }
            }

            #endregion

        }
        #endregion

    }
}