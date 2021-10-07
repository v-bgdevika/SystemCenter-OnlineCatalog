// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="OleDb.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	OleDb Monitor Base Class.
// </summary>
// <history>
// 	[faizalk]   30MAR06     Created
//  [faizalk]   25APR06     Enable Test button support
//  [faizalk]   27APR06     Add resource strings
//  [faizalk]   01MAY06     Check for timeout dialog. Make sure Next button is enabled before clicking.
//  [faizalk]   16APR07     Check results of connection test
//  [dialac ]   28JUL08     Changing CreateComponents based on new wizard dialogs - improvement 118275.
// </history>
// ---------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.OleDb
{

#region Using directives
using Maui.Core;
using Maui.Core.WinControls;
using Maui.Core.Utilities;
using System;
using System.ComponentModel;
using Mom.Test.UI.Core.Console;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
using Mom.Test.UI.Core.Console.MonitoringConfiguration.OleDb.Dialogs;
#endregion

    /// <summary>
    /// Class to add general methods for OleDb Monitor/Template
    /// </summary>
    /// <history> 	
    ///   [faizalk]  Created
    /// </history>
    public class OleDb
    {
        #region Private Members

        /// <summary>
        /// cachedComponentTypeDialog
        /// </summary>
        private SelectComponentTypeDialog cachedComponentTypeDialog;

        /// <summary>
        /// cachedgeneralPropertiesTemplateDialog
        /// </summary>
        private GeneralPropertiesDialog cachedgeneralPropertiesTemplateDialog;

        /// <summary>
        /// cachedWebAddressDialogDialog
        /// </summary>
        private EnterAndTestOleDbSettingsDialog cachedEnterAndTestOleDbSettingsDialog;

         /// <summary>
        /// cachedbuildConnectionStringDialog
        /// </summary>
        private BuildConnectionStringDialog cachedbuildConnectionStringDialog;
        
        /// <summary>
        /// cachedSetQueryPerformanceThresholdsDialog
        /// </summary>
        private SetQueryPerformanceThresholdsDialog cachedSetQueryPerformanceThresholdsDialog;
        
        /// <summary>
        /// cachedChooseWatcherNodesDialog
        /// </summary>
        private ChooseWatcherNodesDialog cachedChooseWatcherNodesDialog;

        /// <summary>
        /// cachedSettingsSummaryDialog
        /// </summary>
        private SettingsSummaryDialog cachedSettingsSummaryDialog;

        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp;

        #endregion

        #region Constructor
        /// <summary>
        /// OleDb
        /// </summary>
        public OleDb()
        {
            this.consoleApp = CoreManager.MomConsole;
        }
        #endregion

        #region Enumerators section

        /// <summary>
        /// Valid Query Interval Units
        /// </summary>
        public enum WatcherNodeQueryIntervalUnit
        {
            /// <summary>
            /// Seconds
            /// </summary>
            Seconds,

            /// <summary>
            /// Minutes
            /// </summary>
            Minutes,

            /// <summary>
            /// Hours
            /// </summary>
            Hours,

            /// <summary>
            /// Days
            /// </summary>
            Days,
        }

        #endregion	// Enumerators section

        #region Properties

        /// <summary>
        /// Select Component Type Dialog
        /// The first screen of the Create Component wizard.
        /// </summary>
        public SelectComponentTypeDialog componentTypeDialog
        {
            get
            {
                if (this.cachedComponentTypeDialog == null)
                {
                    this.cachedComponentTypeDialog = new SelectComponentTypeDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Select Component Type Dialog was successful");
                }
                
                return this.cachedComponentTypeDialog;
            }
        }

        /// <summary>
        /// General Properties Dialog
        /// The Second screen of the Create Component wizard.
        /// </summary>
        public GeneralPropertiesDialog generalPropertiesTemplateDialog
        {
            get
            {
                if (this.cachedgeneralPropertiesTemplateDialog == null)
                {
                    this.cachedgeneralPropertiesTemplateDialog = new GeneralPropertiesDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitoringTemplateWizard);
                    Utilities.LogMessage("Setting Focus on the General Properties Dialog was successful");
                }

                return this.cachedgeneralPropertiesTemplateDialog;
            }
        }

        /// <summary>
        /// Enter and Test OleDb Settings Dialog
        /// The third screen of the Create Component wizard.
        /// </summary>
        public EnterAndTestOleDbSettingsDialog enterAndTestOleDbSettingsDialog
        {
            get
            {
                if (this.cachedEnterAndTestOleDbSettingsDialog == null)
                {
                    this.cachedEnterAndTestOleDbSettingsDialog = new EnterAndTestOleDbSettingsDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Enter and Test OleDb Settings Dialog was successful");
                }

                return this.cachedEnterAndTestOleDbSettingsDialog;
            }
        }

        /// <summary>
        /// Enter the parameters in the build connection String Dialog
        /// One optional screen of the Create Component wizard.
        /// </summary>
        public BuildConnectionStringDialog buildConnectionStringDialog
        {
            get
            {
                if (this.cachedbuildConnectionStringDialog == null)
                {
                    this.cachedbuildConnectionStringDialog = new BuildConnectionStringDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Build Connection String Dialog was successful");
                }

                return this.cachedbuildConnectionStringDialog;
            }
        }

        /// <summary>
        /// Query Performance Thresholds Dialog
        /// The fourth screen of the Create Component wizard.
        /// </summary>
        public SetQueryPerformanceThresholdsDialog setQueryPerformanceThresholdsDialog
        {
            get
            {
                if (this.cachedSetQueryPerformanceThresholdsDialog == null)
                {
                    this.cachedSetQueryPerformanceThresholdsDialog = new SetQueryPerformanceThresholdsDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Set Query Performance Thresholds Dialog was successful");
                }

                return this.cachedSetQueryPerformanceThresholdsDialog;
            }
        }


        /// <summary>
        /// Choose Watcher Nodes Dialog
        /// The fifth screen of the Create Component wizard.
        /// </summary>
        public ChooseWatcherNodesDialog chooseWatcherNodesDialog
        {
            get
            {
                if (this.cachedChooseWatcherNodesDialog == null)
                {
                    this.cachedChooseWatcherNodesDialog = new ChooseWatcherNodesDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Choose Watcher Nodes Dialog was successful");
                }

                return this.cachedChooseWatcherNodesDialog;
            }
        }

        /// <summary>
        /// Settings Summary Dialog
        /// The sixth screen of the Create Component wizard.
        /// </summary>
        public SettingsSummaryDialog settingsSummaryDialog
        {
            get
            {
                if (this.cachedSettingsSummaryDialog == null)
                {
                    this.cachedSettingsSummaryDialog = new SettingsSummaryDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Settings Summary Dialog was successful");
                }

                return this.cachedSettingsSummaryDialog;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Create a new OleDb Monitor component
        /// </summary>
        /// <param name="parameters">OleDbMonitorParameters</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [faizalk] 27MAR06 - Created   
        /// </history>
        public void CreateComponent(OleDbParameters parameters)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

            // Check parameters first to save time
            if (string.IsNullOrEmpty(parameters.Name))
            {
                throw new System.ArgumentNullException("OleDbParameters.Name cannot be null!");
            }

            // Check database parameters
            if (string.IsNullOrEmpty(parameters.ConnectionString))
            {
                if (string.IsNullOrEmpty(parameters.Provider))
                {
                    throw new Exception("The Provider was not provided. Can not create connection string witout provider.");
                }

                if (string.IsNullOrEmpty(parameters.IpAddressOrDeviceName))
                {
                    throw new Exception("The IPAddressDevicename was not provided. Can not create connection string witout IPAddressDevicename.");
                }

                if (string.IsNullOrEmpty(parameters.Database))
                {
                    throw new Exception("The Database was not provided. Can not create connection string witout Database.");
                }
            }

            Utilities.LogMessage(currentMethod + ":: Launch Create Component Wizard");

            // Get Reference to Actions Pane. And select the wizard from the actions pane.
            ActionsPane actionsPane = CoreManager.MomConsole.ActionsPane;
            string monitoredComponentsPath = NavigationPane.Strings.MonitoringConfiguration
                + Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewMonitoredComponents;
            actionsPane.ClickLink(NavigationPane.WunderBarButton.MonitoringConfiguration, 
                monitoredComponentsPath,
                ActionsPane.Strings.ActionsPaneMonitoredComponents, 
                Templates.Strings.LaunchComponentWizardTask);

            Utilities.LogMessage(currentMethod + ":: Selected " + Templates.Strings.LaunchComponentWizardTask);

            // Based on the Type parameter; Select the component Type 
            string typeSelected = SelectComponentTypeDialog.Strings.OleDbTemplate;

            #region Navigate through all the screens of the Wizard

            Maui.Core.WinControls.TreeNode myNode = this.componentTypeDialog.Controls.SelectComponentTypeTreeView.Find(typeSelected);
            Utilities.LogMessage(currentMethod + ":: Found component type '" + typeSelected + "'");

            myNode.Select();
            Utilities.LogMessage(currentMethod + ":: Successfully selected component type '" + typeSelected + "'");
            myNode.Click();
            this.componentTypeDialog.ScreenElement.WaitForReady();

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.componentTypeDialog.Controls.NextButton, Constants.OneMinute);
            Utilities.LogMessage(currentMethod + ":: Successfully clciked on component type");

            this.componentTypeDialog.ClickNext();
            this.componentTypeDialog.ScreenElement.WaitForReady();
            this.generalPropertiesTemplateDialog.ScreenElement.WaitForReady();

            // Enter the General Properties
            this.generalPropertiesTemplateDialog.NameText = parameters.Name;
            Utilities.LogMessage(currentMethod + ":: Set display name '" + this.generalPropertiesTemplateDialog.NameText + "'");
            
            if (null != parameters.Description)
            {
                this.generalPropertiesTemplateDialog.DescriptionText = parameters.Description;
                Utilities.LogMessage(currentMethod + ":: Set description '" + this.generalPropertiesTemplateDialog.DescriptionText + "'");
            }

            if (null != parameters.DestinationMP)
            {
                this.generalPropertiesTemplateDialog.Controls.SelectDestinationManagementPackComboBox.SelectByText(parameters.DestinationMP);
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.generalPropertiesTemplateDialog.Controls.NextButton, Constants.OneMinute);

            this.generalPropertiesTemplateDialog.ScreenElement.WaitForReady();
            this.generalPropertiesTemplateDialog.ClickNext();
            this.enterAndTestOleDbSettingsDialog.ScreenElement.WaitForReady();

            #region Type or Buid DB connection string 

            if (!String.IsNullOrEmpty(parameters.ConnectionString))
            {
                this.enterAndTestOleDbSettingsDialog.ConnectionStringText = parameters.ConnectionString;
            }
            else
            {
                // We are going to use the Build dialog as helper to create the connection String
                this.enterAndTestOleDbSettingsDialog.Controls.BuildButton.Click();
                this.buildConnectionStringDialog.ScreenElement.WaitForReady();

                Utilities.LogMessage(currentMethod + ":: The Build Connection String dialog should be opened. "); 

                this.buildConnectionStringDialog.Controls.ProviderComboBox.SelectByText(parameters.Provider);
                this.buildConnectionStringDialog.IPAddressOrDeviceNameText = parameters.IpAddressOrDeviceName;                
                this.buildConnectionStringDialog.DataBaseText = parameters.Database;

                // Save and back to the EnterAndTestOLEDBDataSourceSettings Dialog
                this.buildConnectionStringDialog.ClickOK();
                this.enterAndTestOleDbSettingsDialog.ScreenElement.WaitForReady();
                Utilities.LogMessage(currentMethod + ":: The Build Connection String dialog is closed"); 
            }
            #endregion
            
            #region Add query text 
            //Checking to see if the test is going to type a query 
            if (parameters.TypeQuery)
            {
                //Checking the query to execute. 
                if (this.enterAndTestOleDbSettingsDialog.TypeInTheQueryToExecute == false)
                {
                    Utilities.LogMessage(currentMethod + ":: checking query to execute checkbox");
                    this.enterAndTestOleDbSettingsDialog.ClickTypeInTheQueryToExecute();
                }
                //Typing a query in the box. 
                this.enterAndTestOleDbSettingsDialog.QueryToExecuteText = parameters.QueryString;
            }
                                   
            #endregion
            
            bool testComplete = true;
            bool testResultFailure = false;
            if (parameters.RunTest)
            {
                testComplete = false;
                int timeWaited = 0;
                const int MaxTimeWaited = 60;
                int retry = 0;
                int maxtries = 10;

                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.enterAndTestOleDbSettingsDialog.Controls.TestButton, 60);
                this.enterAndTestOleDbSettingsDialog.Extended.SetFocus();
                this.enterAndTestOleDbSettingsDialog.ClickTest();
                //Click Test button failed, try once again
                if (this.enterAndTestOleDbSettingsDialog.Controls.TestButton.IsEnabled == true)
                    this.enterAndTestOleDbSettingsDialog.ClickTest();

                while (!testComplete && retry <= maxtries)
                {
                    Utilities.LogMessage(currentMethod + ":: waiting for test to complete...");

                    // set wait loop parameters
                    timeWaited = 0;

                    // Wait for the test to finish
                    while (this.enterAndTestOleDbSettingsDialog.Controls.TestButton.IsEnabled == false
                        && timeWaited < MaxTimeWaited)
                    {
                        // wait two seconds and try again
                        timeWaited++;
                        Sleeper.Delay(Constants.OneSecond);
                    }

                    Utilities.LogMessage(currentMethod + ":: waited " + timeWaited + " seconds for test to complete.");

                    try
                    {
                        CoreManager.MomConsole.ConfirmChoiceDialog(true, Templates.Strings.TimeoutDialogTitle);
                        Utilities.LogMessage(currentMethod + "::Task timed out. Still waiting...");
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage(currentMethod + "::No task timeout dialog found");
                        if (this.enterAndTestOleDbSettingsDialog.Controls.TestButton.IsEnabled)
                        {
                            testComplete = true;
                            Utilities.LogMessage(currentMethod + "::test complete = true");
                        }
                    }

                    retry++;
                }

                // Lets check if we actually completed.  If not, check for Timeout Dialog and dismiss.
                if (!testComplete)
                {
                    try
                    {
                        CoreManager.MomConsole.ConfirmChoiceDialog(false, Templates.Strings.TimeoutDialogTitle);
                        Utilities.LogMessage(currentMethod + "::Task timed out. Stopped the Test.");
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage(currentMethod + "::No task timeout dialog found");
                        if (this.enterAndTestOleDbSettingsDialog.Controls.TestButton.IsEnabled)
                        {
                            testComplete = true;
                            Utilities.LogMessage(currentMethod + "::test complete = true");
                        }
                    }
                }

                // If testCompleted we can do this, otherwise it'll fail.
                if (testComplete)
                {
                    this.cachedEnterAndTestOleDbSettingsDialog = null; // force reacquire of window
                    this.enterAndTestOleDbSettingsDialog.ScreenElement.WaitForReady();
                }
                else
                {
                    Utilities.LogMessage("CONNECTION TEST FAILED");
                    Utilities.TakeScreenshot("Connection test failed");
                }

                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.enterAndTestOleDbSettingsDialog.Controls.NextButton, Constants.OneMinute);

                string actualText = string.Empty;
                //if Expected result is different from actual result then set "testResultFailure" as true
                if (parameters.ExpectedTestSuccess ^ consoleApp.Waiters.WaitForObjectPropertyChangedSafe(
                        this.enterAndTestOleDbSettingsDialog.Controls.RequestProcessedSuccessfullyStaticControl,
                        "@Text",
                        PropertyOperator.Equals,
                        EnterAndTestOleDbSettingsDialog.Strings.RequestProcessedSuccessfully,
                        Constants.OneMinute))
                {
                    // log failure
                    Utilities.LogMessage("Expected test result: " + parameters.ExpectedTestSuccess.ToString());
                    Utilities.LogMessage("Actual text on UI: " + actualText);
                    Utilities.LogMessage("Expected text: " + EnterAndTestOleDbSettingsDialog.Strings.RequestProcessedSuccessfully);
                    Utilities.TakeScreenshot("Connection status mismatch");
                    testResultFailure = true;
                }
            }


            this.enterAndTestOleDbSettingsDialog.ScreenElement.WaitForReady();
            this.enterAndTestOleDbSettingsDialog.ClickNext();
            this.setQueryPerformanceThresholdsDialog.ScreenElement.WaitForReady();
            

            #region ImprovementQueryPerformancePage

            //The connection Time Threshold needs to be entered in any case. So, entering the values here
            this.setQueryPerformanceThresholdsDialog.Controls.ConnectionTimeInMillisecondsCheckBox.Click();
            Utilities.LogMessage("CreateComponent:: In the SetQueryPerformance Threshold dialog");
            this.setQueryPerformanceThresholdsDialog.ConnectionWarningThresholdText = parameters.ConWarnTime;
            this.setQueryPerformanceThresholdsDialog.ConnectionErrorThresholdText = parameters.ConErrorTime;

            //If the Query was ran, then we need to setup the other 2 threshold options
            if (parameters.TypeQuery == true)
            {
                this.setQueryPerformanceThresholdsDialog.Controls.FetchTimeInMillisecondsCheckBox.Click();
                this.setQueryPerformanceThresholdsDialog.FetchErrorThresholdText = parameters.FetchErrorTime;
                this.setQueryPerformanceThresholdsDialog.FetchWarningThresholdText = parameters.FetchWarnTime;
                this.setQueryPerformanceThresholdsDialog.Controls.QueryTimeInMillisecondsCheckBox.Click();
                this.setQueryPerformanceThresholdsDialog.QueryErrorThresholText = parameters.QueryErrorTime;
                this.setQueryPerformanceThresholdsDialog.QueryWarningThresholdText = parameters.QueryWarnTime;
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(setQueryPerformanceThresholdsDialog.Controls.NextButton);
            this.setQueryPerformanceThresholdsDialog.ClickNext();
            this.chooseWatcherNodesDialog.ScreenElement.WaitForReady();
            #endregion
            
            int attempt = 0;
            int maxAttempts = 10;

            // Wait for watcher nodes to appear
            while ((this.chooseWatcherNodesDialog.Controls.ManagementPackDetailsListView == null
                || this.chooseWatcherNodesDialog.Controls.ManagementPackDetailsListView.Count <= 0)
                && attempt < maxAttempts)
            {
                // wait a second and try again
                attempt++;
                Sleeper.Delay(Constants.OneSecond);
            }

            if (null != parameters.WatcherNodes)
            {
                // find each watcher node in the listview (case insensitive)
                foreach (string watcherNode in parameters.WatcherNodes)
                {
                    ListViewItemCollection lvic = this.chooseWatcherNodesDialog.Controls.ManagementPackDetailsListView.FindAllByText(watcherNode, false);
                    if (null != lvic && lvic.Count > 0)
                    {
                        
                        Utilities.LogMessage("Adding '" + lvic[0].Text + "' to selection");

                        int retries = 0;
                        int maxRetries = 10;
                        while (!lvic[0].Checked && retries < maxRetries)
                        {
                            retries++;
                            Utilities.LogMessage("Attempt " + retries + " of " + maxRetries + " to add '" + lvic[0].Text + "' to selection");
                            lvic[0].Select();
                            Sleeper.Delay(Constants.OneSecond);
                            lvic[0].Click(MouseClickType.DoubleClick);
                        }
                    }
                }
            }
            else
            {
                // just select all watcher nodes
                foreach (ListViewItem lvi in this.chooseWatcherNodesDialog.Controls.ManagementPackDetailsListView.Items)
                {
                    lvi.Select();
                    lvi.Click(MouseClickType.DoubleClick);
                    Utilities.LogMessage("Adding '" + lvi.Text + "' to selection");
                }
            }

            if (null != parameters.QueryIntervalTime)
            {
                this.chooseWatcherNodesDialog.RunThisQueryEveryText = parameters.QueryIntervalTime;
            }

            // Based on the query inteveral unit parameter; Select the time units 
            string queryUnits = null;
            switch (parameters.QueryIntervalUnit)
            {
                case WatcherNodeQueryIntervalUnit.Seconds:
                    queryUnits = MonitoringConfiguration.Strings.RunThisQueryEverySeconds;
                    break;

                case WatcherNodeQueryIntervalUnit.Minutes:
                    queryUnits = MonitoringConfiguration.Strings.RunThisQueryEveryMinutes;
                    break;

                case WatcherNodeQueryIntervalUnit.Hours:
                    queryUnits = MonitoringConfiguration.Strings.RunThisQueryEveryHours;
                    break;

                case WatcherNodeQueryIntervalUnit.Days:
                    queryUnits = MonitoringConfiguration.Strings.RunThisQueryEveryDays;
                    break;

                default:
                    Utilities.LogMessage(currentMethod + ":: QueryIntervalUnit parameter: '" +
                        parameters.QueryIntervalUnit + "' is invalid");
                    throw new InvalidEnumArgumentException("Invalid Type selected");
            }

            this.chooseWatcherNodesDialog.Controls.UnitsComboBox.SelectByText(queryUnits);

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.chooseWatcherNodesDialog.Controls.NextButton, Constants.OneMinute);

            this.chooseWatcherNodesDialog.ScreenElement.WaitForReady();
            this.chooseWatcherNodesDialog.ClickNext();
            this.settingsSummaryDialog.ScreenElement.WaitForReady();

            // Complete the wizard                
            this.settingsSummaryDialog.ClickCreate();
            CoreManager.MomConsole.WaitForDialogClose(this.settingsSummaryDialog, Constants.OneMinute * 5 / Constants.OneSecond);

            // putting a short delay for the wizard to complete
            Sleeper.Delay(Constants.OneSecond * 3);
            Utilities.LogMessage(currentMethod + ":: Successfully completed Component Creation!!");

            #endregion

            #region Verify Component Created
            
            Templates templates = new Templates();
            
            CoreManager.MomConsole.Waiters.WaitForReady();
            if (templates.ComponentExists(Templates.ComponentType.OleDbDataSource, parameters.Name))
            {
                Utilities.LogMessage(currentMethod + ":: Found " + parameters.Name + " in Monitored Components view");
            } 
            else
            {
                throw new Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException("Failed to find " + parameters.Name + " in Monitored Components view");
            }

            #endregion

            if (!testComplete)
            {
                throw new TimeoutException("Connection test failed to complete!");
            }

            if (testResultFailure)
            {
                throw new MissingFieldException("Expected connection test result: " + parameters.ExpectedTestSuccess);
            }
        }

        #endregion

        #region OleDbParameters Class
        /// <summary>
        /// Parameters class for OleDb constructors.
        /// </summary>
        /// <history>
        /// [faizalk] 27MAR06 Created
        /// </history>
        public class OleDbParameters
        {
            #region Private Members
            
            private string cachedName = null;
            private string cachedDescription = null;
            private string cachedDestinationMP = null;
            private string cachedProvider = null;
            private string cachedIpAddressOrDeviceName = null;           
            private string cachedDatabase = null;
            private string cachedConnectionString = null;
            private bool cachedRunTest = false;
            private bool cachedExpectedTestSuccess = false;
            private bool cachedTypeQuery = false;
            private string cachedQueryString = null;
            private string cachedConErrorTime = null;
            private string cachedConWarnTime = null;
            private string cachedFetchErrorTime = null;
            private string cachedFetchWarnTime = null;
            private string cachedQueryErrorTime = null;
            private string cachedQueryWarnTime = null;
            private string[] cachedWatcherNodes = null;
            private string cachedQueryIntervalTime = null;
            private OleDb.WatcherNodeQueryIntervalUnit cachedQueryIntervalUnit = WatcherNodeQueryIntervalUnit.Minutes;
            #endregion

            #region Constructors

            /// <summary>
            /// Default Constructor - no need in ExePath etc. Inherited classes
            /// from Console set all required properties on parameter objects.
            /// </summary>
            public OleDbParameters()
            {
            }
            #endregion

            #region Properties

            /// <summary>
            /// Display Name of OleDb
            /// </summary>
            public string Name
            {
                get
                {
                    return this.cachedName;
                }

                set
                {
                    this.cachedName = value;
                }
            }

            /// <summary>
            /// Description for OleDb
            /// </summary>
            public string Description
            {
                get
                {
                    return this.cachedDescription;
                }

                set
                {
                    this.cachedDescription = value;
                }
            }

            /// <summary>
            /// Destination MP for OleDb
            /// </summary>
            public string DestinationMP
            {
                get
                {
                    return this.cachedDestinationMP;
                }

                set
                {
                    this.cachedDestinationMP = value;
                }
            }

            /// <summary>
            /// Provider 
            /// </summary>
            public string Provider
            {
                get
                {
                    return this.cachedProvider;
                }

                set
                {
                    this.cachedProvider = value;
                }
            }

            /// <summary>
            /// Ip Address Or Device Name 
            /// </summary>
            public string IpAddressOrDeviceName
            {
                get
                {
                    return this.cachedIpAddressOrDeviceName;
                }

                set
                {
                    this.cachedIpAddressOrDeviceName = value;
                }
            }

            /// <summary>
            /// Database
            /// </summary>
            public string Database
            {
                get
                {
                    return this.cachedDatabase;
                }

                set
                {
                    this.cachedDatabase = value;
                }
            }

            /// <summary>
            /// ConnectionString
            /// </summary>
            public string ConnectionString
            {
                get
                {
                    return this.cachedConnectionString;
                }

                set
                {
                    this.cachedConnectionString = value;
                }
            }

            /// <summary>
            /// whether to click Test button for URL to be monitored
            /// </summary>
            public bool RunTest
            {
                get
                {
                    return this.cachedRunTest;
                }

                set
                {
                    this.cachedRunTest = value;
                }
            }

            /// <summary>
            /// whether test should yield successful result
            /// </summary>
            public bool ExpectedTestSuccess
            {
                get
                {
                    return this.cachedExpectedTestSuccess;
                }

                set
                {
                    this.cachedExpectedTestSuccess = value;
                }
            }

            /// <summary>
            /// whether to type a Query 
            /// </summary>
            public bool TypeQuery
            {
                get
                {
                    return this.cachedTypeQuery;
                }

                set
                {
                    this.cachedTypeQuery = value;
                }
            }

            /// <summary>
            /// Query string 
            /// </summary>
            public string QueryString 
            {
                get
                {
                    return this.cachedQueryString;
                }

                set
                {
                    this.cachedQueryString = value;
                }
            }

            /// <summary>
            /// Connection Error Threshold Time string 
            /// </summary>
            public string ConErrorTime
            {
                get
                {
                    return this.cachedConErrorTime;
                }

                set
                {
                    this.cachedConErrorTime = value;
                }
            }

             /// <summary>
            /// Connection Warning Threshold Time string 
            /// </summary>
            public string ConWarnTime
            {
                get
                {
                    return this.cachedConWarnTime;
                }

                set
                {
                    this.cachedConWarnTime = value;
                }
            }

            /// <summary>
            /// Fetch Error Threshold Time string 
            /// </summary>
            public string FetchErrorTime
            {
                get
                {
                    return this.cachedFetchErrorTime;
                }

                set
                {
                    this.cachedFetchErrorTime = value;
                }
            }

            /// <summary>
            /// Fetch Warning Threshold Time string 
            /// </summary>
            public string FetchWarnTime
            {
                get
                {
                    return this.cachedFetchWarnTime;
                }

                set
                {
                    this.cachedFetchWarnTime = value;
                }
            }


            /// <summary>
            /// Query Error Threshold Time string 
            /// </summary>
            public string QueryErrorTime
            {
                get
                {
                    return this.cachedQueryErrorTime;
                }

                set
                {
                    this.cachedQueryErrorTime = value;
                }
            }

            /// <summary>
            /// Query Waning Threshold Time string 
            /// </summary>
            public string QueryWarnTime
            {
                get
                {
                    return this.cachedQueryWarnTime;
                }

                set
                {
                    this.cachedQueryWarnTime = value;
                }
            }


            /// <summary>
            /// array of watcher nodes to select
            /// </summary>
            public string[] WatcherNodes
            {
                get
                {
                    return this.cachedWatcherNodes;
                }

                set
                {
                    this.cachedWatcherNodes = value;
                }
            }

            /// <summary>
            /// Run this query every 'QueryIntervalTime' Seconds/Minutes/Hours/Days
            /// </summary>
            public string QueryIntervalTime
            {
                get
                {
                    return this.cachedQueryIntervalTime;
                }

                set
                {
                    this.cachedQueryIntervalTime = value;
                }
            }

            /// <summary>
            /// Run this query every 'QueryIntervalTime' Seconds/Minutes/Hours/Days
            /// </summary>
            public OleDb.WatcherNodeQueryIntervalUnit QueryIntervalUnit
            {
                get
                {
                    return this.cachedQueryIntervalUnit;
                }

                set
                {
                    this.cachedQueryIntervalUnit = value;
                }
            }

            #endregion
        }

        #endregion

    } // end of class OleDb

} // end of namespace