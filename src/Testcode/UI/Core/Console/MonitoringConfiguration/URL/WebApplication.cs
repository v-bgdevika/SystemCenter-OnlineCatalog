// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WebApplication.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	Web Application Monitor Base Class.
// </summary>
// <history>
// 	[faizalk]   27MAR06     Created
//  [faizalk]   25APR06     Enable Test button support
//  [faizalk]   27APR06     Add resource strings
//  [faizalk]   01MAY06    Check for timeout dialog. Make sure Next button is enabled before clicking.
//                                Add support for Web Application Editor.
//  [faizalk]   17APR07     Check results of connection test
//  [v-eryon] 28JULY09    Add methords for Improvement#146284
// </history>
// ---------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL
{
    #region Using directives

using Maui.Core;
using Maui.Core.WinControls;
using Maui.Core.Utilities;

using System;
using System.ComponentModel;
using Mom.Test.UI.Core.Console;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.Console.MomControls;
using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
using Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs;
    using System.Reflection;

#endregion

    /// <summary>
    /// Class to add general methods for Web Application Monitor/Template
    /// </summary>
    /// <history> 	
    ///   [faizalk]  Created
    /// </history>
    public class WebApplication
    {
        #region Private Constants

        #endregion

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
        private URL.Dialogs.EnterAndTestWebAddressDialog cachedWebAddressDialogDialog;

        /// <summary>
        /// cachedRequestResultDetailsDialogDetailsTab
        /// </summary>
        private URL.Dialogs.RequestResultDetailsDialogDetailsTab cachedRequestResultDetailsDialogDetailsTab;

        /// <summary>
        /// cachedRequestResultDetailsDialogHttpRequestTab
        /// </summary>
        private URL.Dialogs.RequestResultDetailsDialogHttpRequestTab cachedRequestResultDetailsDialogHttpRequestTab;

        /// <summary>
        /// cachedRequestResultDetailsDialogHttpResponseTab
        /// </summary>
        private URL.Dialogs.RequestResultDetailsDialogHttpResponseTab cachedRequestResultDetailsDialogHttpResponseTab;

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

        #region Enumerators section

        /// <summary>
        /// Valid Protocols
        /// </summary>
        public enum UrlProtocol
        {
            /// <summary>
            /// Http
            /// </summary>
            Http,

            /// <summary>
            /// Https
            /// </summary>
            Https,
        }

        /// <summary>
        /// Insert extracted parameters types
        /// </summary>
        public enum ExtractType
        {
            /// <summary>
            /// Insert extracted parameters 
            /// in HTTP Url
            /// </summary>
            RequestUrl,

            /// <summary>
            /// Insert extracted parameters 
            /// in Request Header
            /// </summary>
            RequestHeader,
        }      

        #endregion	// Enumerators section

        #endregion

        #region Constructor
        /// <summary>
        /// URL
        /// </summary>
        public WebApplication()
        {
            this.consoleApp = CoreManager.MomConsole;
        }
        #endregion

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
        /// Enter and Test Web Address Dialog
        /// The third screen of the Create Component wizard.
        /// </summary>
        public URL.Dialogs.EnterAndTestWebAddressDialog enterAndTestWebAddressDialog
        {
            get
            {
                if (this.cachedWebAddressDialogDialog == null)
                {
                    this.cachedWebAddressDialogDialog = new EnterAndTestWebAddressDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Enter and Test Web Address Dialog was successful");
                }

                return this.cachedWebAddressDialogDialog;
            }
        }

        /// <summary>
        /// Request Result Details Dialog - Details Tab
        /// </summary>
        public URL.Dialogs.RequestResultDetailsDialogDetailsTab requestResultDetailsDialogDetailsTab
        {
            get
            {
                if (this.cachedRequestResultDetailsDialogDetailsTab == null)
                {
                    this.cachedRequestResultDetailsDialogDetailsTab = new RequestResultDetailsDialogDetailsTab(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the RequestResultDetailsDialogDetailsTab was successful");
                }

                return this.cachedRequestResultDetailsDialogDetailsTab;
            }
        }

        /// <summary>
        /// Request Result Details Dialog - Http Request Tab
        /// </summary>
        public URL.Dialogs.RequestResultDetailsDialogHttpRequestTab requestResultDetailsDialogHttpRequestTab
        {
            get
            {
                if (this.cachedRequestResultDetailsDialogHttpRequestTab == null)
                {
                    this.cachedRequestResultDetailsDialogHttpRequestTab = new RequestResultDetailsDialogHttpRequestTab(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the RequestResultDetailsDialogHttpRequestTab was successful");
                }

                return this.cachedRequestResultDetailsDialogHttpRequestTab;
            }
        }

        /// <summary>
        /// Request Result Details Dialog - Http Response Tab
        /// </summary>
        public URL.Dialogs.RequestResultDetailsDialogHttpResponseTab requestResultDetailsDialogHttpResponseTab
        {
            get
            {
                if (this.cachedRequestResultDetailsDialogHttpResponseTab == null)
                {
                    this.cachedRequestResultDetailsDialogHttpResponseTab = new RequestResultDetailsDialogHttpResponseTab(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the RequestResultDetailsDialogHttpResponseTab was successful");
                }

                return this.cachedRequestResultDetailsDialogHttpResponseTab;
            }
        }

        /// <summary>
        /// Choose Watcher Nodes Dialog
        /// The fourth screen of the Create Component wizard.
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
        /// The fifth screen of the Create Component wizard.
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
        /// Create a new Web Application Monitor component
        /// </summary>
        /// <param name="parameters">WebApplicationMonitorParameters</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [faizalk] 27MAR06 - Created   
        /// </history>
        public void CreateComponent(WebApplicationParameters parameters)
        {
            Utilities.LogMessage("WebApplication.CreateComponent::" +
                "Launch Create Component Wizard");

            #region Navigate to Web Application Wizard

            // Get Reference to Actions Pane. And select the wizard from the actions pane.
            ActionsPane actionsPane = CoreManager.MomConsole.ActionsPane;
            string monitoredComponentsPath = NavigationPane.Strings.MonitoringConfiguration
                + Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewMonitoredComponents;
            actionsPane.ClickLink(
                NavigationPane.WunderBarButton.MonitoringConfiguration,
                monitoredComponentsPath,
                ActionsPane.Strings.ActionsPaneMonitoredComponents,
                Templates.Strings.LaunchComponentWizardTask);

            Utilities.LogMessage("WebApplication.CreateComponent:: Selected "
                + Templates.Strings.LaunchComponentWizardTask);

            #endregion

            // Navigate through all the screens of the Wizard

            #region Component Type Dialog

            // Based on the Type parameter; Select the component Type 
            string typeSelected = SelectComponentTypeDialog.Strings.WebApplicationTemplate;

            Maui.Core.WinControls.TreeNode myNode = null;
            myNode = this.componentTypeDialog.Controls.SelectComponentTypeTreeView.Find(typeSelected);
            Utilities.LogMessage("WebApplication.CreateComponent:: Found component type '" + typeSelected + "'");

            myNode.Select();
            Utilities.LogMessage("WebApplication.CreateComponent:: Successfully selected component type '" +
                typeSelected + "'");
            myNode.Click();
            UISynchronization.WaitForProcessReady(this.componentTypeDialog);
            this.componentTypeDialog.WaitForResponse();

                      
            componentTypeDialog.ScreenElement.WaitForReady();

            if (!consoleApp.Waiters.WaitForWizardNavigationItemCount(this.componentTypeDialog, 5, 30000))

            {
                Utilities.LogMessage("WebApplication.CreateComponent:: NavigationItemCount not expected value");
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.componentTypeDialog.Controls.NextButton, Constants.OneMinute);

            Utilities.LogMessage("WebApplication.CreateComponent:: Successfully clicked on component type");

            this.componentTypeDialog.WaitForResponse();
            this.componentTypeDialog.ClickNext();

            #endregion

            #region General Properties Dialog

            this.generalPropertiesTemplateDialog.WaitForResponse();

            // Enter the General Properties
            // Trying to set the name -- if its null throws System.ArgumentNullException
            if (null != parameters.Name)
            {
                this.generalPropertiesTemplateDialog.NameText = parameters.Name;
                Utilities.LogMessage("WebApplication.CreateComponent:: Set display name '" +
                    this.generalPropertiesTemplateDialog.NameText + "'");
            }
            else
            {
                throw new System.ArgumentNullException("WebApplicationParameters.Name cannot be null!");
            }

            if (null != parameters.Description)
            {
                this.generalPropertiesTemplateDialog.DescriptionText = parameters.Description;
                Utilities.LogMessage("WebApplication.CreateComponent:: Set description '"
                + this.generalPropertiesTemplateDialog.DescriptionText + "'");
            }

            if (null != parameters.DestinationMP)
            {
                this.generalPropertiesTemplateDialog.Controls.SelectDestinationManagementPackComboBox.SelectByText(parameters.DestinationMP);
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.generalPropertiesTemplateDialog.Controls.NextButton, Constants.OneMinute);

            Utilities.TakeScreenshot("CreateComponent - General Properties Dialog before click Next");
            this.generalPropertiesTemplateDialog.WaitForResponse();
            this.generalPropertiesTemplateDialog.ClickNext();

            #endregion

            #region Web Address Dialog

            this.enterAndTestWebAddressDialog.WaitForResponse();

            // Based on the protocol parameter; Select the protocol Type 
            switch (parameters.Protocol)
            {
                case UrlProtocol.Http:
                    this.enterAndTestWebAddressDialog.Controls.URLComboBox.SelectByIndex((int)parameters.Protocol);
                    break;

                case UrlProtocol.Https:
                    this.enterAndTestWebAddressDialog.Controls.URLComboBox.SelectByIndex((int)parameters.Protocol);
                    break;

                default:
                    Utilities.LogMessage("WebApplication.CreateComponent:: Protocol parameter: '" +
                        parameters.Protocol + "' is invalid");
                    throw new InvalidEnumArgumentException("Invalid Type selected");
            }

            if (null != parameters.Url)
            {
                this.enterAndTestWebAddressDialog.EnterAndTestYourURLText = parameters.Url;
            }

            bool testComplete = true;
            bool testResultFailure = false;
            if (parameters.RunTest)
            {
                int timeWaited = 0;
                const int MaxTimeWaited = 60;
                int retry = 0;
                int maxtries = 30;

                this.enterAndTestWebAddressDialog.ClickTest();
                Sleeper.Delay(Constants.OneSecond);

                while (retry <= maxtries && !this.enterAndTestWebAddressDialog.Controls.TestButton.IsEnabled)
                {
                    Utilities.LogMessage("WebApplication.CreateComponent:: waiting for test to complete...");

                    try
                    {
                        CoreManager.MomConsole.ConfirmChoiceDialog(true, Templates.Strings.TimeoutDialogTitle);
                        Utilities.LogMessage("WebApplication.CreateComponent::Task timed out. Still waiting...");
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage("WebApplication.CreateComponent::No task timeout dialog found");
                    }

                    retry++;
                }

                // Wait for the test to finish
                this.enterAndTestWebAddressDialog.Controls.TestButton.ScreenElement.WaitForReady();
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.enterAndTestWebAddressDialog.Controls.TestButton, Constants.OneMinute);
                Utilities.LogMessage("WebApplication.CreateComponent:: waited for test to complete.");

                // verify connection test result
                Utilities.LogMessage("Returned status: " + this.enterAndTestWebAddressDialog.Controls.TheExecutionOfTheTaskReturnedAnErrorStaticControl.Text);
                Utilities.LogMessage("parameters.ExpectedTestSeccess:" + parameters.ExpectedTestSuccess);
                if (parameters.ExpectedTestSuccess)
                {
                    if (String.Compare(this.enterAndTestWebAddressDialog.Controls.TheExecutionOfTheTaskReturnedAnErrorStaticControl.Text, EnterAndTestWebAddressDialog.Strings.RequestProcessedSuccessfully) != 0)
                    {
                        // log failure
                        Utilities.LogMessage("Returned status does NOT match expected result!");
                        Utilities.TakeScreenshot("Connection status mismatch");
                        testResultFailure = true;
                    }
                }
                else
                {
                    //ExpectedTestSuccess == false (expect test failure)
                    if (String.Compare(this.enterAndTestWebAddressDialog.Controls.TheExecutionOfTheTaskReturnedAnErrorStaticControl.Text, EnterAndTestWebAddressDialog.Strings.RequestProcessedSuccessfully) == 0)
                    {
                        // log failure
                        Utilities.LogMessage("Returned status does NOT match expected result!");
                        Utilities.TakeScreenshot("Connection status mismatch");
                        testResultFailure = true;
                    }
                }


                // If testCompleted we can do this, otherwise it'll fail.
                if (testComplete)
                {
                    // Wait for Details to be visible/enabled
                    timeWaited = 0;
                    Utilities.LogMessage("WebApplication.CreateComponent:: waiting for Details button to appear...");

                    this.cachedWebAddressDialogDialog = null; // force reacquire of window
                    this.enterAndTestWebAddressDialog.WaitForResponse();

                    // we are checking for all these issues to prevent various timing issues
                    // that have been hit during BVTs
                    while (!this.enterAndTestWebAddressDialog.Controls.DetailsButton.IsVisible
                            && !this.enterAndTestWebAddressDialog.Controls.DetailsButton.IsEnabled
                            && !this.enterAndTestWebAddressDialog.Controls.EnterAndTestYourURLTextBox.IsEnabled
                            && !this.enterAndTestWebAddressDialog.Controls.ErrorResultsListView.IsVisible
                            && timeWaited < MaxTimeWaited)
                    {
                        // wait a second and try again
                        timeWaited++;
                        Sleeper.Delay(Constants.OneSecond);
                    }

                    Utilities.LogMessage("WebApplication.CreateComponent:: waited " + timeWaited + " seconds for Details button to be enabled");
                    this.enterAndTestWebAddressDialog.Controls.EnterAndTestYourURLTextBox.WaitForResponse();
                    this.enterAndTestWebAddressDialog.ClickDetails();

                    this.requestResultDetailsDialogHttpRequestTab.Controls.Tab1TabControl.Tabs[1].Click();
                    Sleeper.Delay(Constants.OneSecond);
                    this.requestResultDetailsDialogHttpRequestTab.Controls.Tab1TabControl.Tabs[2].Click();
                    Sleeper.Delay(Constants.OneSecond);
                    this.requestResultDetailsDialogHttpRequestTab.Controls.Tab1TabControl.Tabs[0].Click();
                    Sleeper.Delay(Constants.OneSecond);
                    
                    this.requestResultDetailsDialogDetailsTab.ClickClose();
                }
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.enterAndTestWebAddressDialog.Controls.NextButton, Constants.OneMinute);

            Utilities.TakeScreenshot("CreateComponent - Web Address Dialog before click Next");
            this.enterAndTestWebAddressDialog.WaitForResponse();
            this.enterAndTestWebAddressDialog.ClickNext();
            System.Threading.Thread.Sleep(Constants.OneSecond*15);

            #endregion

            #region Watcher Nodes Dialog

            this.chooseWatcherNodesDialog.WaitForResponse();

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
                case Templates.WatcherNodeQueryIntervalUnit.Seconds:
                    queryUnits = MonitoringConfiguration.Strings.RunThisQueryEverySeconds;
                    break;

                case Templates.WatcherNodeQueryIntervalUnit.Minutes:
                    queryUnits = MonitoringConfiguration.Strings.RunThisQueryEveryMinutes;
                    break;

                case Templates.WatcherNodeQueryIntervalUnit.Hours:
                    queryUnits = MonitoringConfiguration.Strings.RunThisQueryEveryHours;
                    break;

                case Templates.WatcherNodeQueryIntervalUnit.Days:
                    queryUnits = MonitoringConfiguration.Strings.RunThisQueryEveryDays;
                    break;

                default:
                    Utilities.LogMessage("WebApplication.CreateComponent:: QueryIntervalUnit parameter: '" +
                        parameters.QueryIntervalUnit + "' is invalid");
                    throw new InvalidEnumArgumentException("Invalid Type selected");
            }

            this.chooseWatcherNodesDialog.Controls.UnitsComboBox.SelectByText(queryUnits);

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.chooseWatcherNodesDialog.Controls.NextButton, Constants.OneMinute);

            this.chooseWatcherNodesDialog.WaitForResponse();
            this.chooseWatcherNodesDialog.ClickNext();

            #endregion

            #region  Summary Dialog

            this.settingsSummaryDialog.WaitForResponse();

            // Complete the wizard  
            if (parameters.ConfigureAdvancedSettings)
            {
                this.settingsSummaryDialog.ClickConfigureAdvancedMonitoringOrRecordABrowserSessionAfterTheWizardCloses();
                this.settingsSummaryDialog.WaitForResponse();
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.settingsSummaryDialog.Controls.CreateButton, Constants.OneMinute);
                this.settingsSummaryDialog.ClickCreate();
                Utilities.LogMessage("Create button clicked.");
                // wait a few seconds for things to settle
                Sleeper.Delay(Constants.OneSecond); 

                // try twice to get this window
                WebApplicationEditorDialog webAppEditor = null;
                int retries = 0;
                int maxRetry = 60;

                while (webAppEditor == null && retries < maxRetry)
                {
                    try
                    {
                        webAppEditor = new WebApplicationEditorDialog(CoreManager.MomConsole);
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        // do nothing since we will retry
                    }
                    retries++;
                    Sleeper.Delay(Constants.OneSecond);
                    Utilities.LogMessage(String.Format("Try {0} of {1} to get WebAppEditor. Sleeping 1 seconds", retries, maxRetry));
                }

                UISynchronization.WaitForProcessReady(webAppEditor);
                webAppEditor.WaitForResponse();
              
                webAppEditor.ScreenElement.WaitForReady();
                // click Start Capture
                /*webAppEditor.Controls.

                InternetExplorerWindow IeWindow = new InternetExplorerWindow(CoreManager.MomConsole);

                IeWindow.SendKeys("%d");
                IeWindow.SendKeys("www.live.com\n");
                Sleeper.Delay(7000);
                
                // click Stop Capture
                settingsSummaryDialog
                 * */

                int wait = 0;
                int maxWait = 180;

                while (wait < maxWait)
                {
                    try
                    {
                        webAppEditor.ClickStopProcessingTheSubsequentRequestsAnyErrorCriteriaIsMet();
                        break;
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        Sleeper.Delay(Constants.OneSecond);
                        Utilities.LogMessage(String.Format("Try {0} of {1} to click checkbox.", wait, maxWait));
                    }
                    wait++;
                }

                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(webAppEditor.Controls.VerifyButton, Constants.OneMinute);
                webAppEditor.ClickVerify();

                this.CloseEditorDialog(webAppEditor);
                
  
            }
            else
            {
                this.settingsSummaryDialog.WaitForResponse();
                this.settingsSummaryDialog.ClickCreate();
                Utilities.LogMessage("Create button clicked");
            }

            // putting a short delay for the wizard to complete
            Sleeper.Delay(Constants.TenSeconds);
            Utilities.LogMessage("WebApplication.CreateComponent:: Successfully completed Component Creation!!");

            #endregion
            //if test machine OS is WIN8 client , we won't to check test URL , this is an expected error
            if (!testComplete)
            {
                throw new TimeoutException("Connection test failed to complete!");
            }
            string OSVer = System.Environment.GetEnvironmentVariable("OSVer");
            string OSVersion = System.Environment.GetEnvironmentVariable("OSVersion");
            Utilities.LogMessage("OSVer = " + OSVer);
            Utilities.LogMessage("OSVersion = " + OSVersion);
            if (OSVer == "WIN8" && OSVersion == "ADS")
            {
                testResultFailure = false;
            }
            if (testResultFailure)
            {
                throw new MissingFieldException(String.Format("Expected connection test result: {0}",
                    parameters.ExpectedTestSuccess));
            }
        }

        /// <summary>
        ///  Add extraction rule
        /// </summary>
        /// <param name="templateName">Name of the template</param>
        /// <param name="parameters">Extraction Rule Parameters</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [v-eryon] 28JULY09 - Created   
        /// </history>
        public void AddExtractionRule(string templateName, ExtractionRuleParameters parameters)
        {
            Utilities.LogMessage("WebApplication.AddExtractionRule:: Add extraction rule.");

            #region Navigate to Web Application Editor

            WebApplicationEditorDialog webAppEditor = GetWebAppEditor(templateName);
            RequestPropertiesDialogGeneralTab generalTabDialog = GetPropertiesDialog(webAppEditor);

            #endregion

            #region Configure Monitoring Tab Dialog

            TabControlTab monitoringTab = new TabControlTab(generalTabDialog.Controls.Tab0TabControl,
                RequestPropertiesDialogGeneralTab.Strings.TabMonitoring);
            generalTabDialog.Controls.Tab0TabControl.Tabs[monitoringTab.Index].Click();
            RequestPropertiesDialogMonitoringTab monitoringTabDialog = new RequestPropertiesDialogMonitoringTab(CoreManager.MomConsole);

            Utilities.LogMessage("Setup Monitoring tab...");

            if (parameters.ProcessResponseBody)
            {
                Utilities.LogMessage("Process response body option enabled...");
                monitoringTabDialog.ProcessResponseBody = true;

                switch (parameters.CollectionOption)
                {
                    case UrlResourceStrings.Always:
                        Utilities.LogMessage("Selecting Always option.");
                        monitoringTabDialog.ResponseBodyCollectionText = UrlResourceStrings.AlwaysCollect;
                        break;
                    case UrlResourceStrings.Donot:
                        Utilities.LogMessage("Selecting Donot option.");
                        monitoringTabDialog.ResponseBodyCollectionText = UrlResourceStrings.DoNotCollect;
                        break;
                    default:
                        Utilities.LogMessage("Selecting MeetCriteria option.");                        
                        monitoringTabDialog.ResponseBodyCollectionText = UrlResourceStrings.MeetCriteria;
                        break;
                }
            }
            else
            {
                Utilities.LogMessage("Process response body option disabled...");
                monitoringTabDialog.ProcessResponseBody = false;
            }

            Utilities.LogMessage("Setting check box status for Additional Collection option...");
            //not use monitoringTabDialog.Controls.CollectHeadersCheckBox.Checked = true/false,because it's unstable
            if (monitoringTabDialog.Controls.CollectHeadersCheckBox.Checked != parameters.CollectHeader)
                monitoringTabDialog.Controls.CollectHeadersCheckBox.Click(); 

            if (monitoringTabDialog.Controls.CollectLinkHeadersCheckBox.Checked != parameters.CollectLink)
                monitoringTabDialog.Controls.CollectLinkHeadersCheckBox.Click();

            if (monitoringTabDialog.Controls.CollectResourceHeadersCheckBox.Checked != parameters.CollectResource)
                monitoringTabDialog.Controls.CollectResourceHeadersCheckBox.Click();
            
            monitoringTabDialog.WaitForResponse();

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(monitoringTabDialog.Controls.ApplyButton, Constants.OneSecond * 20);
            monitoringTabDialog.ClickApply();
           
            #endregion

            #region Configure Extraction Rule Dialog

            //Navigate to Extraction Rule Dialog
            TabControlTab ruleTab = new TabControlTab(generalTabDialog.Controls.Tab0TabControl,
                RequestPropertiesDialogGeneralTab.Strings.TabExtractionsRules);
            SelectTab(generalTabDialog.Controls.Tab0TabControl, ruleTab.Index);

            RequestPropertiesDialogExtraRuleTab extractionRuleTabDialog = new RequestPropertiesDialogExtraRuleTab(CoreManager.MomConsole);
            extractionRuleTabDialog.WaitForResponse();
            extractionRuleTabDialog.ClickAdd();

            AddExtractionRuleDialog addExtractionRuleDialog = new AddExtractionRuleDialog(CoreManager.MomConsole);
            Utilities.LogMessage("Add extraction rule through addExtractionRuleDialog.");
            addExtractionRuleDialog.WaitForResponse();
            addExtractionRuleDialog.ContextParameterNameText = parameters.ContextName;
            addExtractionRuleDialog.StartsWithText = parameters.StartString;
            addExtractionRuleDialog.EndsWithText = parameters.EndString;
            addExtractionRuleDialog.ClickHideAdvancedSettings();
            Sleeper.Delay(Constants.OneSecond);

            addExtractionRuleDialog.IndexText = parameters.NumericIndex;

            if (parameters.IgnoreCase)
            {
                Utilities.LogMessage("Clicking check box IgnoreCase...");
                addExtractionRuleDialog.ClickIgnoreCaseDuringSearchForMatchingText();
            }

            if (parameters.PerformURI)
            {
                Utilities.LogMessage("Clicking check box PerformURI...");
                addExtractionRuleDialog.ClickPerformURIEncodingOfExtractedStrings();
            }

         
            addExtractionRuleDialog.WaitForResponse();
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(addExtractionRuleDialog.Controls.OKButton, Constants.OneSecond * 10);
           
            Utilities.LogMessage("Click OK button to close addExtractionRuleDialog.");
            addExtractionRuleDialog.ClickOK();

            
            extractionRuleTabDialog.WaitForResponse();
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(extractionRuleTabDialog.Controls.ApplyButton, Constants.OneSecond * 10);
           
            Utilities.LogMessage("Click Apply button to on extractionRuleTabDialog.");
            extractionRuleTabDialog.ClickApply();
            extractionRuleTabDialog.WaitForResponse();


            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(extractionRuleTabDialog.Controls.OKButton, Constants.OneMinute);
            Utilities.LogMessage("Click OK button to exist properties dialog.");
            extractionRuleTabDialog.ClickOK();
            CoreManager.MomConsole.WaitForDialogClose(extractionRuleTabDialog,
                Constants.OneSecond / Constants.OneSecond);

            #endregion

            #region Complete Adding Extraction Rule
            
            // Invoke CloseEditorDialog to handle the following
            CloseEditorDialog(webAppEditor);

            #endregion
        }

        /// <summary>
        ///  Edit extraction rule
        /// </summary>
        /// <param name="templateName">Template Name</param>
        /// <param name="editProperty">Property Name to be edit</param>
        /// <param name="editValue">Edit value</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [v-eryon] 28JULY09 - Created   
        /// </history>
        public void EditExtractionRule(string templateName, string editProperty, string editValue)
        {
            Utilities.LogMessage("WebApplication.EditExtractionRule:: Edit extraction rule.");

            WebApplicationEditorDialog webAppEditor = GetWebAppEditor(templateName);
            RequestPropertiesDialogGeneralTab generalTabDialog = GetPropertiesDialog(webAppEditor);

            TabControlTab ruleTab = new TabControlTab(generalTabDialog.Controls.Tab0TabControl,
                RequestPropertiesDialogGeneralTab.Strings.TabExtractionsRules);
            SelectTab(generalTabDialog.Controls.Tab0TabControl, ruleTab.Index);

            RequestPropertiesDialogExtraRuleTab extractionRuleTabDialog = new RequestPropertiesDialogExtraRuleTab(CoreManager.MomConsole);
            extractionRuleTabDialog.WaitForResponse();

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(extractionRuleTabDialog.Controls.AddButton, Constants.OneSecond * 10);
            extractionRuleTabDialog.ClickEdit();

            AddExtractionRuleDialog addExtractionRuleDialog = new AddExtractionRuleDialog(CoreManager.MomConsole);
            addExtractionRuleDialog.WaitForResponse();

            switch (editProperty)
            {
                case UrlResourceStrings.RuleName:
                    addExtractionRuleDialog.ContextParameterNameText = editValue;
                    break;

                case UrlResourceStrings.StartString:
                    addExtractionRuleDialog.StartsWithText = editValue;
                    break;

                case UrlResourceStrings.EndString:
                    addExtractionRuleDialog.EndsWithText = editValue;
                    break;

                default:
                    Utilities.LogMessage(String.Format("Invalid property name::{0}", editProperty));
                    throw new InvalidEnumArgumentException(); 
            }

            addExtractionRuleDialog.WaitForResponse();
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(addExtractionRuleDialog.Controls.OKButton, Constants.OneMinute);
            addExtractionRuleDialog.ClickOK();
           
            extractionRuleTabDialog.WaitForResponse();

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(extractionRuleTabDialog.Controls.ApplyButton, Constants.OneSecond * 10);
            Utilities.LogMessage("Click Apply button to on extractionRuleTabDialog.");
            extractionRuleTabDialog.ClickApply();
            extractionRuleTabDialog.WaitForResponse();

            Utilities.LogMessage("Click OK button to exist properties dialog.");
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(extractionRuleTabDialog.Controls.OKButton, Constants.OneMinute);
            extractionRuleTabDialog.ClickOK();

            CoreManager.MomConsole.WaitForDialogClose(extractionRuleTabDialog,
               Constants.OneSecond / Constants.OneSecond);

            //Exist from web app editor 
            CloseEditorDialog(webAppEditor);
        }

        /// <summary>
        /// Delete the extraction rule according to template name
        /// </summary>
        /// <param name="templateName">Template Name</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [v-eryon] 28JULY09 - Created   
        /// </history>
        public void DeleteExtractionRule(string templateName)
        {
            Utilities.LogMessage("WebApplication.EditExtractionRule:: Delete extraction rule.");

            WebApplicationEditorDialog webAppEditor = GetWebAppEditor(templateName);
            RequestPropertiesDialogGeneralTab generalTabDialog = GetPropertiesDialog(webAppEditor);

            TabControlTab ruleTab = new TabControlTab(generalTabDialog.Controls.Tab0TabControl,
                RequestPropertiesDialogGeneralTab.Strings.TabExtractionsRules);
            SelectTab (generalTabDialog.Controls.Tab0TabControl, ruleTab.Index);

            RequestPropertiesDialogExtraRuleTab extractionRuleTabDialog = new RequestPropertiesDialogExtraRuleTab(CoreManager.MomConsole);
            extractionRuleTabDialog.WaitForResponse();

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(extractionRuleTabDialog.Controls.AddButton, Constants.OneSecond * 20);

            extractionRuleTabDialog.ClickDelete();
           
            extractionRuleTabDialog.WaitForResponse();

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(extractionRuleTabDialog.Controls.ApplyButton, Constants.OneSecond * 20);

            Utilities.LogMessage("Click Apply button to on extractionRuleTabDialog.");
            extractionRuleTabDialog.ClickApply();
            extractionRuleTabDialog.WaitForResponse();
             
            Utilities.LogMessage("Click OK button to exist properties dialog.");
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(extractionRuleTabDialog.Controls.OKButton, Constants.OneMinute);
            extractionRuleTabDialog.ClickOK();

            CoreManager.MomConsole.WaitForDialogClose(extractionRuleTabDialog,
                Constants.OneSecond / Constants.OneSecond);

            //Exist from web app editor 
            CloseEditorDialog(webAppEditor);
        }

        /// <summary>
        /// Apply Extraction Rule
        /// </summary>
        /// <param name="templateName">Template name</param>
        /// <param name="parameters">Extraction Rule Parameters</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [v-eryon] 28JULY09 - Created   
        /// </history>
        public void ApplyExtractionRule(string templateName, ExtractionRuleParameters parameters)
        {
            Utilities.LogMessage("WebApplication.ApplyExtractionRule:: Apply extraction rule.");

            WebApplicationEditorDialog webAppEditor = GetWebAppEditor(templateName);

            switch (parameters.ExtractType)
            {
                case ExtractType.RequestUrl: 
                    RequestPropertiesDialogGeneralTab generalTabDialogForUrl = GetNewRequstDialog(webAppEditor);
                    Utilities.LogMessage("Click Insert Request link to add second context Url.");
                    
                    generalTabDialogForUrl.WaitForResponse();
                    generalTabDialogForUrl.ClickInsertParameterUrl();

                    InsertParameterDialog insertUrlParameterDialog = new InsertParameterDialog(CoreManager.MomConsole);
                    insertUrlParameterDialog.WaitForResponse();
                    insertUrlParameterDialog.UrlStringBoxText = parameters.ContextUrl;
                    insertUrlParameterDialog.Controls.ParametersList.SelectItem(parameters.ContextName);
                    insertUrlParameterDialog.WaitForResponse();

                    Utilities.LogMessage("Insert the parameter extraction Url.");
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(insertUrlParameterDialog.Controls.InsertButton, Constants.OneMinute);
                    insertUrlParameterDialog.ClickInsert();
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(insertUrlParameterDialog.Controls.OKButton, Constants.OneMinute);
                    insertUrlParameterDialog.ClickOK();

                    generalTabDialogForUrl.WaitForResponse();
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(generalTabDialogForUrl.Controls.OKButton, Constants.OneMinute);
                    generalTabDialogForUrl.ClickOK();

                    CoreManager.MomConsole.WaitForDialogClose(generalTabDialogForUrl, Constants.OneMinute);
                    break;

                case ExtractType.RequestHeader:
                    RequestPropertiesDialogGeneralTab generalTabDialogForHeader = GetNewRequstDialog(webAppEditor);
                    Utilities.LogMessage("Input request Url to the RequestURL textbox.");

                    #region Navigate to HTTP header tab dialog

                    generalTabDialogForHeader.RequestURL2Text = parameters.ContextUrl;
                    generalTabDialogForHeader.WaitForResponse();

                    //generalTabDialogForHeader.Controls.Tab0TabControl.Tabs[1].Click();

                    TabControlTab headerTab = new TabControlTab(generalTabDialogForHeader.Controls.Tab0TabControl, 
                        RequestPropertiesDialogGeneralTab.Strings.TabHTTPHeader);
                    generalTabDialogForHeader.Controls.Tab0TabControl.Tabs[headerTab.Index].Click();

                    #endregion

                    #region Search and click row on the HTTP Header Property GridView

                    CreateNewRequestDialogHeaderTab headerTabDialog = new CreateNewRequestDialogHeaderTab(CoreManager.MomConsole);

                    int rowIndex = FindDataRow(parameters.HeaderProperty, headerTabDialog.Controls.ConfigureTheRequestHTTPHeadersPropertyGridView);
                    Maui.Core.WinControls.DataGridViewRow componentRow = new DataGridViewRow(
                        headerTabDialog.Controls.ConfigureTheRequestHTTPHeadersPropertyGridView.Rows[rowIndex].Cells[0].AccessibleObject);
                    Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
                    if (componentRow != null)
                    {
                        Utilities.LogMessage(String.Format("SearchComponent:: Found template {0}.", parameters.HeaderProperty));
                        componentRow.AccessibleObject.Click();
                    }
                    else
                    {
                        Utilities.LogMessage(String.Format("SearchComponent:: Did not find template {0}.", parameters.HeaderProperty));
                        throw new Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException(
                            String.Format("SearchComponent:: Did not find template {0}.", parameters.HeaderProperty));
                    }

                    #endregion

                    #region Configure the Header Properties Edit Dialog

                    headerTabDialog.ClickEdit();

                    HTTPHeaderPropertiesDialog headerPropertiesDialog = new HTTPHeaderPropertiesDialog(CoreManager.MomConsole);
                    headerPropertiesDialog.WaitForResponse();
                    headerPropertiesDialog.Controls.HTTPHeaderValueTextBox.Click();
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(headerPropertiesDialog.Controls.InsertParameterButton, Constants.OneMinute);
                    headerPropertiesDialog.ClickInsertParameter();

                    InsertParameterDialog insertHeaderParameterDialog = new InsertParameterDialog(CoreManager.MomConsole);
                    insertHeaderParameterDialog.WaitForResponse();
                    insertHeaderParameterDialog.Controls.ParametersList.SelectItem(parameters.ContextName);
                    insertHeaderParameterDialog.WaitForResponse();
                    Utilities.LogMessage("Insert the parameter extraction rule.");
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(insertHeaderParameterDialog.Controls.InsertButton, Constants.OneMinute);
                    insertHeaderParameterDialog.ClickInsert();
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(insertHeaderParameterDialog.Controls.OKButton, Constants.OneMinute);
                    insertHeaderParameterDialog.ClickOK();

                    headerPropertiesDialog.WaitForResponse();
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(headerPropertiesDialog.Controls.OKButton, Constants.OneMinute);
                    headerPropertiesDialog.ClickOK();

                    generalTabDialogForHeader.WaitForResponse();
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(generalTabDialogForHeader.Controls.OKButton, Constants.OneMinute);
                    generalTabDialogForHeader.ClickOK();

                    CoreManager.MomConsole.WaitForDialogClose(generalTabDialogForHeader,
                        Constants.OneSecond / Constants.OneSecond);
                    break;

                    #endregion

                default:
                    break;
            }

            //Exist from Web Application Dialog
            CloseEditorDialog(webAppEditor);
        }

        /// <summary>
        /// Get Extraction Rule Property Value after updating
        /// </summary>
        /// <param name="templateName">Template Name</param>
        /// <param name="property">
        /// Property Name, such as RuleName, StartString, EndString
        /// </param>
        /// <returns>Property Value</returns>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [v-eryon] 28JULY09 - Created   
        /// </history>
        public string GetExtractionRulePropertyValue(string templateName, string property)
        {
            Utilities.LogMessage("WebApplication.EditExtractionRule:: Edit extraction rule.");
            string contextValue = null;

            WebApplicationEditorDialog webAppEditor = GetWebAppEditor(templateName);
          
            RequestPropertiesDialogGeneralTab generalTabDialog = GetPropertiesDialog(webAppEditor);

            TabControlTab ruleTab = new TabControlTab(generalTabDialog.Controls.Tab0TabControl,
                RequestPropertiesDialogGeneralTab.Strings.TabExtractionsRules);
            SelectTab(generalTabDialog.Controls.Tab0TabControl, ruleTab.Index);
                     
            RequestPropertiesDialogExtraRuleTab extractionRuleTabDialog = new RequestPropertiesDialogExtraRuleTab(CoreManager.MomConsole);
            extractionRuleTabDialog.WaitForResponse();

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(extractionRuleTabDialog.Controls.AddButton, Constants.OneMinute);
            extractionRuleTabDialog.ClickEdit();

            AddExtractionRuleDialog addExtractionRuleDialog = new AddExtractionRuleDialog(CoreManager.MomConsole);

            switch (property)
            {
                case UrlResourceStrings.RuleName:
                    Utilities.LogMessage("WebApplication::GetExtractionRulePropertyValue: Retrieving rule name...");
                    contextValue = addExtractionRuleDialog.ContextParameterNameText;
                    break;
                case UrlResourceStrings.StartString:
                    Utilities.LogMessage("WebApplication::GetExtractionRulePropertyValue: Retrieving start string...");
                    contextValue = addExtractionRuleDialog.StartsWithText;
                    break;
                case UrlResourceStrings.EndString:
                    Utilities.LogMessage("WebApplication::GetExtractionRulePropertyValue: Retrieving end string...");
                    contextValue = addExtractionRuleDialog.EndsWithText;
                    break;
                default:
                    Utilities.LogMessage(String.Format("Invalid property::{0}", property));
                    throw new InvalidEnumArgumentException(); 
            }

            addExtractionRuleDialog.WaitForResponse();
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(addExtractionRuleDialog.Controls.OKButton, Constants.OneMinute);
            addExtractionRuleDialog.ClickOK();
                     
            Utilities.LogMessage("Click OK button to exist properties dialog.");
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(extractionRuleTabDialog.Controls.OKButton, Constants.OneMinute);
            extractionRuleTabDialog.ClickOK();

            //Exist from web app editor 
            CoreManager.MomConsole.WaitForDialogClose(extractionRuleTabDialog,
                Constants.OneSecond / Constants.OneSecond);

            CloseEditorDialog(webAppEditor);

            return contextValue;
        }


        /// <summary>
        /// Run end-to-end scenario and return the result
        /// Apply the parameters extraction rule and retrieve the value from UI
        /// </summary>
        /// <param name="templateName">Template Name</param>
        /// <param name="type">Type, Request Url/Request Header</param>
        /// <param name="extractionRuleContextUrl">The Rule Context Url</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [v-eryon] 28JULY09 - Created   
        /// </history>
        public string RunExtractionRule(string templateName, ExtractType type, string extractionRuleContextUrl)
        {
            Utilities.LogMessage("RunExtractionRule...");

            string result = null;
            WebApplicationEditorDialog webAppEditor = GetWebAppEditor(templateName);
            WebApplicationEditorActionPane actionPane = new WebApplicationEditorActionPane(webAppEditor);
            actionPane.WaitForResponse();

            Utilities.LogMessage("Click Run Test on right action pane.");
            actionPane.ClickLink(WebApplicationEditorActionPane.Strings.ActionsPaneLinkRunNowRunTest,
                WebApplicationEditorActionPane.Strings.ActionsPaneNodeRunNow);

            WaitEditorProcess(webAppEditor);

            RunNowResultsDialog runNowResultsDialog = new RunNowResultsDialog(CoreManager.MomConsole);
            //runNowResultsDialog.Controls.TreeView.SelectByIndex(2);
            runNowResultsDialog.SelectNode(extractionRuleContextUrl, false);
            runNowResultsDialog.ClickDetails();

            RequestResultDetailsDialogDetailsTab dialogDetailsTab = new RequestResultDetailsDialogDetailsTab(CoreManager.MomConsole);
            dialogDetailsTab.WaitForResponse();

            switch (type)
            {
                case ExtractType.RequestUrl:
                    result = dialogDetailsTab.URLText;
                    Utilities.LogMessage(String.Format("Result from RUN TEST::{0}", result));
                    dialogDetailsTab.WaitForResponse();
                    dialogDetailsTab.Controls.CloseButton.Extended.SetFocus();
                    dialogDetailsTab.ClickClose();
                    break;

                case ExtractType.RequestHeader:
                    dialogDetailsTab.Controls.Tab0TabControl[1].Click();
                    RequestResultDetailsDialogHttpRequestTab httpRequestTab = new RequestResultDetailsDialogHttpRequestTab(CoreManager.MomConsole);
                    httpRequestTab.WaitForResponse();

                    //Retrieve the result 
                    result = httpRequestTab.RequestProcessedSuccessfullyText;
                    Utilities.LogMessage(String.Format("Result from RUN TEST::{0}", result));
                    httpRequestTab.WaitForResponse();
                    httpRequestTab.Controls.CloseButton.Extended.SetFocus();
                    httpRequestTab.ClickClose();
                    break;

                default:
                    Utilities.LogMessage(String.Format("Invalid type::{0}", type));
                    throw new InvalidEnumArgumentException(); 
            }

            runNowResultsDialog.WaitForResponse();
            runNowResultsDialog.Controls.OKButton.Extended.SetFocus();
            runNowResultsDialog.ClickOK();

            CoreManager.MomConsole.WaitForDialogClose(runNowResultsDialog,
                Constants.OneSecond / Constants.OneSecond);
            CloseEditorDialog(webAppEditor);

            return result;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get web application editor dialog
        /// </summary>
        /// <param name="templateName">Template name</param>
        /// <returns>Form returned</returns>
        private WebApplicationEditorDialog GetWebAppEditor(string templateName)
        {
            Utilities.LogMessage("GetWebAppEditor...");

            string urlComponentsPath = NavigationPane.Strings.MonitoringConfiguration
                + Mom.Test.UI.Core.Common.Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewMonitoredComponents;
            Utilities.LogMessage(String.Format("GetWebAppEditor::{0}", urlComponentsPath));

            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Authoring);
            navPane.SelectNode(urlComponentsPath, NavigationPane.NavigationTreeView.Authoring);
            navPane.SelectNode(SelectComponentTypeDialog.Strings.WebApplicationTemplate, NavigationPane.NavigationTreeView.Authoring);

            //Delay 5 seconds wait loaded the Web Application Transaction Monitoring window
            Sleeper.Delay(Core.Common.Constants.OneSecond * 5);

            //Find url template in the grid view of main console
            SearchComponent(templateName);

            CoreManager.MomConsole.MainWindow.Extended.SetFocus();
            // Navigate to web application editor dialog     
            //Commands.Actions.Execute(CoreManager.MomConsole);
            //CoreManager.MomConsole.ExecuteContextMenu(ActionsPane.Strings.ActionsPaneCustomActions +
            //    Core.Common.Constants.PathDelimiter +
            //    Templates.Strings.EditWebApplicationTitle,
            //    false);
            ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
            taskPane.ClickLink(ActionsPane.Strings.ActionsPaneCustomActions, Templates.Strings.EditWebApplicationTitle);

            // try twice to get this window
            int retries = 0;
            int maxRetry = 30;
            WebApplicationEditorDialog webAppEditor = null;
            while (webAppEditor == null && retries < maxRetry)
            {
                try
                {
                    webAppEditor = new WebApplicationEditorDialog(CoreManager.MomConsole);
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    // do nothing since we will retry
                }
                retries++;
                Sleeper.Delay(Constants.OneSecond);
                Utilities.LogMessage(String.Format("Try {0} of {1} to get WebAppEditor.", retries, maxRetry));
            }
            webAppEditor.WaitForResponse();
            UISynchronization.WaitForProcessReady(webAppEditor, 120000);
            UISynchronization.WaitForUIObjectReady(webAppEditor, 120000);

            //Work-around bug#191775: wait for Web Application finished loading
            int retryMax=Core.Common.Constants.DefaultDialogTimeout/Core.Common.Constants.OneSecond;
            for (int i = 0; i < retryMax; i++)
            {
                try
                {
                    if (WebApplicationEditorDialog.Strings.WebApplicationLoadedSuccessfully.Equals
                        (webAppEditor.Controls.WebApplicationLoadedSuccessfullyStaticControl.Text))
                    {
                        Utilities.LogMessage("GetWebAppEditor::Web Application Loaded Successfully");
                        break;
                    }
                }
                catch (System.InvalidOperationException)
                {
                    Utilities.LogMessage("GetWebAppEditor::Web Application is loading, will retry, retry times: "+i);
                }
                Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
            }
            return webAppEditor;
        }

        /// <summary>
        /// Get URL properties dialog
        /// </summary>
        /// <param name="webAppEditor">Web Application Editor Dialog</param>
        /// <returns></returns>
        private RequestPropertiesDialogGeneralTab GetPropertiesDialog(WebApplicationEditorDialog webAppEditor)
        {
            Utilities.LogMessage("GetPropertiesDialog...");

            WebApplicationEditorActionPane actionPane = new WebApplicationEditorActionPane(webAppEditor);
            actionPane.WaitForResponse();
            Utilities.LogMessage("Click properties link on right action pane.");
            
            actionPane.ClickLink(WebApplicationEditorActionPane.Strings.ActionsPaneLinkWebRequestProperties,
                WebApplicationEditorActionPane.Strings.ActionsPaneNodeWebRequest);

            Utilities.LogMessage("Click extraction rule tab on properties dialog.");
            RequestPropertiesDialogGeneralTab extractionRuleTabDialog = new RequestPropertiesDialogGeneralTab(CoreManager.MomConsole, false);
            extractionRuleTabDialog.WaitForResponse();

            // Sleep a while for the status to be ready
            Sleeper.Delay(Constants.OneSecond);

            return extractionRuleTabDialog;
        }

        /// <summary>
        /// Get New Request Dialog
        /// </summary>
        /// <param name="webAppEditor">Web Application Editor Dialog</param>
        /// <returns></returns>
        private RequestPropertiesDialogGeneralTab GetNewRequstDialog(WebApplicationEditorDialog webAppEditor)
        {
            Utilities.LogMessage("GetNewRequstDialog...");

            WebApplicationEditorActionPane actionPane = new WebApplicationEditorActionPane(webAppEditor);
            actionPane.WaitForResponse();

            Utilities.LogMessage("Click properties link on right action pane.");
            actionPane.ClickLink(WebApplicationEditorActionPane.Strings.ActionsPaneNodeWebRequestInsert,
                WebApplicationEditorActionPane.Strings.ActionsPaneNodeWebRequest);

            Utilities.LogMessage("Click extraction rule tab on properties dialog.");
            RequestPropertiesDialogGeneralTab extractionRuleTabDialog = new RequestPropertiesDialogGeneralTab(CoreManager.MomConsole, true);
            extractionRuleTabDialog.WaitForResponse();

            // Sleep a while for the status to be ready
            Sleeper.Delay(Constants.OneSecond);

            return extractionRuleTabDialog;
        }

        /// <summary>
        /// Close current opened web application dialog
        /// </summary>
        /// <param name="webAppEditor">Web Application Editor Dialog</param>
        private void CloseEditorDialog(WebApplicationEditorDialog webAppEditor)
        {
                     
            Utilities.LogMessage("CloseEditorDialog...");
            try
            {
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(webAppEditor.Controls.ApplyButton, Constants.OneMinute);
                webAppEditor.ClickApply();
            }
            catch(TimeoutException)
            {
                Utilities.LogMessage("Couldn't click Apply button because of no change.");
            }
             
            WaitEditorProcess(webAppEditor);

            webAppEditor.Extended.CloseWindow();

            //Putting a short delay for the process to complete
            consoleApp.Waiters.WaitForStatusReady(5000);
            Utilities.LogMessage("Successfully completed adding parameter extraction.");
        }

        /// <summary>
        /// Wait for the background process to be completed
        /// </summary>
        /// <param name="webAppEditor">Web Application Editor Dialog</param>
        private void WaitEditorProcess(WebApplicationEditorDialog webAppEditor)
        {
            Utilities.LogMessage("WaitEditorProcess ::");

            CoreManager.MomConsole.Waiters.WaitForReady();

            int retries = 1;
            int maxRetry = 120;

            while (!webAppEditor.Controls.ContentMatchCheckBox.IsEnabled && retries < maxRetry)
            {
                retries++;
                Utilities.LogMessage(String.Format("[{0}] Wait one second for applying the changes.", retries));
                Sleeper.Delay(Constants.OneSecond);
            }

            if (!webAppEditor.Controls.ContentMatchCheckBox.IsEnabled)
            {
                throw new Control.Exceptions.ControlIsDisabledException("WaitEditorProcess :: the content match checkbox is still disabled after " + maxRetry.ToString() + " seconds.");
            }
        }


        /// <summary>
        /// Search the template according to the name
        /// </summary>
        /// <param name="componentName"></param>
        private void SearchComponent(string componentName)
        {
            Utilities.LogMessage("WebApplication.SearchComponent::" +
                "Search the created web application template.");

            Templates templates = new Templates();
            if (templates.ComponentExists(Templates.ComponentType.WebApplication, componentName))
            {
                Utilities.LogMessage(String.Format("WebApplication.SearchComponent:: Found {0} in Monitored Components view.", componentName));
            }
            else
            {
                throw new Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException(
                    String.Format("Failed to find {0} in Monitored Components view.", componentName));
            }

            Maui.Core.WinControls.DataGridViewRow componentRow = null;

            int retries = 0;
            int maxRetries = 5;
            while (componentRow == null && retries++ < maxRetries)
            {
                componentRow = CoreManager.MomConsole.ViewPane.Grid.FindData(componentName, Templates.Strings.ComponentCategoryColumnName,
                    Core.Console.MomControls.GridControl.SearchStringMatchType.ExactMatch);
                Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
                Utilities.LogMessage(String.Format("[{0}]::Retry to find the component row.", retries));
            }

            if (componentRow != null)
            {
                Utilities.LogMessage(String.Format("SearchComponent:: Found template {0}.", componentName));
                componentRow.AccessibleObject.Click();
            }
            else
            {
                Utilities.LogMessage(String.Format("SearchComponent:: Did not find template {0}.", componentName));
                throw new Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException(
                    String.Format("SearchComponent:: Did not find template {0}.", componentName));
            }
        }

        /// <summary>
        /// Method to search the rows and cells of a grid for the specified
        /// search string.
        /// </summary>
        /// <param name="searchData">String to find in grid cells</param>
        /// <param name="dataGrid">Grid to search</param>
        /// <returns>The index of the row containing the data</returns>
        private int FindDataRow(string searchData, Maui.Core.WinControls.DataGridView dataGrid)
        {
            ////Todo: Consider moving this method to the Grid control.
            ////Todo: Add 'Monitors.' class name to log messages.
            Core.Common.Utilities.LogMessage("Searching grid view for text:  '" +
                searchData + "'");

            // get the number of grid rows
            int rowCount = dataGrid.Rows.Count;
            Core.Common.Utilities.LogMessage("Number of grid rows:  " + rowCount);

            // get the number of cells per row
            int cellCount = 0;
            if (rowCount > 1)
            {
                cellCount = dataGrid.Rows[1].Cells.Count;
            }
            Core.Common.Utilities.LogMessage("Number of grid cells:  " + cellCount);

            // flag to indicate if search data is found
            bool foundSearchData = false;

            // placeholder row
            Maui.Core.WinControls.DataGridViewRow selectedRow = null;

            // placeholder for current cell's text data
            string currentCellText = null;
            int rowIndex = 1;

            // iterate through each row
            for (rowIndex = 1; rowIndex < rowCount; rowIndex++)
            {
                // click on the first cell in each row
                dataGrid.Rows[rowIndex].Cells[0].AccessibleObject.Click();

                // iterate through each cell
                for (int cellIndex = 0; cellIndex < cellCount; cellIndex++)
                {
                    currentCellText =
                        dataGrid.Rows[rowIndex].Cells[cellIndex].GetValue().ToLowerInvariant();
                    Core.Common.Utilities.LogMessage("Cell " + cellIndex + " contains '" +
                        currentCellText);

                    // match the current device name exactly
                    if (searchData.ToLowerInvariant().CompareTo(currentCellText) == 0)
                    {
                        Core.Common.Utilities.LogMessage("Found match:  '" +
                            currentCellText + "'");

                        selectedRow = dataGrid.Rows[rowIndex];
                        Utilities.LogMessage("row index: " + rowIndex);
                        foundSearchData = true;
                        break;
                    }
                }

                // check to see if we found the data
                if (foundSearchData == true)
                {
                    break;
                }
            }
            return rowIndex;
        }

        /// <summary>
        /// Select tab by specified tab index, it will scroll the tab item to view if it's not visible
        /// </summary>
        /// <param name="tabControl">tab control</param>
        /// <param name="tabItemIndex">tab item index</param>
        private static void SelectTab(TabControl tabControl, int tabItemIndex)
        {
            string currentMethodName = MethodBase.GetCurrentMethod().Name;

            if (!tabControl.Tabs[tabItemIndex].AccessibleObject.Visible)
            {
                Utilities.LogMessage(currentMethodName +":: Tab item with index  "+tabItemIndex+" is not visible");
                
                // Determine scroll direction
                if (tabItemIndex > tabControl.SelectedIndex)
                {
                    while (!tabControl.Tabs[tabItemIndex].AccessibleObject.Visible)
                    {
                        Utilities.LogMessage(currentMethodName + ":: Click right spinner button to scroll tabs");
                        tabControl.TabSpinner.ClickRight();
                    }
                }
                else
                {
                    while (!tabControl.Tabs[tabItemIndex].AccessibleObject.Visible)
                    {
                        Utilities.LogMessage(currentMethodName + ":: Click left spinner button to scroll tabs");
                        tabControl.TabSpinner.ClickLeft();
                    }
                }
            }

            Utilities.LogMessage(currentMethodName + ":: Select tab item with index " + tabItemIndex);
            tabControl.Tabs[tabItemIndex].Select();
        }
        #endregion
        
        #region WebApplicationParameters Class

        /// <summary>
        /// Parameters class for WebApplication constructors.
        /// </summary>
        /// <history>
        /// [faizalk] 27MAR06 Created
        /// </history>
        public class WebApplicationParameters : SynTxParameters
        {
            #region Private Members

            private WebApplication.UrlProtocol cachedProtocol = UrlProtocol.Http;
            private string cachedUrl = null;
            private bool cachedConfigureAdvancedSettings = false;
            #endregion

            #region Constructors

            /// <summary>
            /// Default Constructor - no need in ExePath etc. Inherited classes
            /// from Console set all required properties on parameter objects.
            /// </summary>
            public WebApplicationParameters()
            {
            }
            #endregion

            #region Properties

            /// <summary>
            /// Protocol for Web Application
            /// </summary>
            public WebApplication.UrlProtocol Protocol
            {
                get
                {
                    return this.cachedProtocol;
                }

                set
                {
                    this.cachedProtocol = value;
                }
            }

            /// <summary>
            /// URL for Web Application to be monitored
            /// </summary>
            public string Url
            {
                get
                {
                    return this.cachedUrl;
                }

                set
                {
                    this.cachedUrl = value;
                }
            }

            /// <summary>
            /// whether to configure advanced settings
            /// </summary>
            public bool ConfigureAdvancedSettings
            {
                get
                {
                    return this.cachedConfigureAdvancedSettings;
                }

                set
                {
                    this.cachedConfigureAdvancedSettings = value;
                }
            }

            #endregion
        }
        #endregion

        #region ExtractionRuleParameters Class

        /// <summary>
        /// Parameters class for WebApplication constructors.
        /// </summary>
        /// <history>
        /// [v-eryon] 27 JULY09 Created
        /// </history>
        public class ExtractionRuleParameters : SynTxParameters
        {
            #region Private Members

            private string cachedContextUrl = null;
            private string cachedContextName = null;
            private string cachedStart = null;
            private string cachedEnd = null;
            private string cachedNumericIndex = null;
            private string cachedCollectionOption = null;
            private string cachedHeaderProperty = null;
            private ExtractType cachedExtractType = ExtractType.RequestHeader;

            private bool cachedProcessResponseBody = false;
            private bool cachedIgnoreCase = false;
            private bool cachedPerformURI = false;
            private bool cachedCollectHeader = false;
            private bool cachedCollectLink = false;
            private bool cachedCollectResource = false;

            #endregion

            #region Constructors

            /// <summary>
            /// Extraction Rule Parameters
            /// </summary>
            public ExtractionRuleParameters()
            {
            }

            #endregion

            #region Properties

            /// <summary>
            /// Context Url
            /// </summary>
            public string ContextUrl
            {
                get { return this.cachedContextUrl; }
                set { this.cachedContextUrl = value; }
            }

            /// <summary>
            /// Context Parameter Name
            /// </summary>
            public string ContextName
            {
                get { return this.cachedContextName; }
                set { this.cachedContextName = value; }
            }

            /// <summary>
            /// Context parameter start string
            /// </summary>
            public string StartString
            {
                get { return this.cachedStart; }
                set { this.cachedStart = value; }
            }

            /// <summary>
            /// Context parameter end string
            /// </summary>
            public string EndString
            {
                get { return this.cachedEnd; }
                set { this.cachedEnd = value; }
            }

            /// <summary>
            /// Extract Type
            /// </summary>
            public ExtractType ExtractType
            {
                get { return this.cachedExtractType; }
                set { this.cachedExtractType = value; }
            }

            /// <summary>
            /// Numeric Index
            /// </summary>
            public string NumericIndex
            {
                get { return this.cachedNumericIndex; }
                set { this.cachedNumericIndex = value; }
            }

            /// <summary>
            /// Collection Option
            /// </summary>
            public string CollectionOption
            {
                get { return this.cachedCollectionOption; }
                set { this.cachedCollectionOption = value; }
            }

            /// <summary>
            /// Header Property
            /// </summary>
            public string HeaderProperty
            {
                get { return this.cachedHeaderProperty; }
                set { this.cachedHeaderProperty = value; }
            }

            /// <summary>
            /// Process Response Body
            /// </summary>
            public bool ProcessResponseBody
            {
                get { return this.cachedProcessResponseBody; }
                set { this.cachedProcessResponseBody = value; }
            }

            /// <summary>
            /// Ignore Case
            /// </summary>
            public bool IgnoreCase
            {
                get { return this.cachedIgnoreCase; }
                set { this.cachedIgnoreCase = value; }
            }

            /// <summary>
            /// Perform URI
            /// </summary>
            public bool PerformURI
            {
                get { return this.cachedPerformURI; }
                set { this.cachedPerformURI = value; }
            }

            /// <summary>
            /// Collect Header
            /// </summary>
            public bool CollectHeader
            {
                get { return this.cachedCollectHeader; }
                set { this.cachedCollectHeader = value; }
            }

            /// <summary>
            /// Collect Link
            /// </summary>
            public bool CollectLink
            {
                get { return this.cachedCollectLink; }
                set { this.cachedCollectLink = value; }
            }

            /// <summary>
            /// Collect Resource
            /// </summary>
            public bool CollectResource
            {
                get { return this.cachedCollectResource; }
                set { this.cachedCollectResource = value; }
            }

            #endregion
        }

        #endregion

        #region Url Strings

        /// <summary>
        /// Url Constant String
        /// </summary>
        /// <history>
        /// [v-eryon] 27 JULY09 Created
        /// </history>
        private class UrlResourceStrings
        {
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string of Always collect
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlwaysCollect;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string of Do not collect
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDoNotCollect;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string of Collect on content match criteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMeetCriteria;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Always collect translated string
            /// </summary>
            /// <history>
            /// 	[v-bire] 6/15/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlwaysCollect
            {
                get
                {
                    if (cachedAlwaysCollect == null)
                    {
                        cachedAlwaysCollect = CoreManager.MomConsole.GetIntlStr(ResourceAlwaysCollect);
                    }

                    return cachedAlwaysCollect;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Do not collect translated string
            /// </summary>
            /// <history>
            /// 	[v-bire] 6/15/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DoNotCollect
            {
                get
                {
                    if (cachedDoNotCollect == null)
                    {
                        cachedDoNotCollect = CoreManager.MomConsole.GetIntlStr(ResourceDoNotCollect);
                    }

                    return cachedDoNotCollect;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Collect on content match criteria translated string
            /// </summary>
            /// <history>
            /// 	[v-bire] 6/15/2011 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MeetCriteria
            {
                get
                {
                    if (cachedMeetCriteria == null)
                    {
                        cachedMeetCriteria = CoreManager.MomConsole.GetIntlStr(ResourceMeetCriteria);
                    }

                    return cachedMeetCriteria;
                }
            }

            #endregion

            #region Resource Id 

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the combo box item Always collect
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlwaysCollect = ";Always collect;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationResources;ResponseBodyCollectionAlways";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the combo box item Do not collect
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDoNotCollect = ";Do not collect;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationResources;ResponseBodyCollectionNever";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the combo box item Collect on content match criteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMeetCriteria = ";Collect on content match criteria;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationResources;ResponseBodyCollectionOnContent";
            #endregion

            /// <summary>
            /// Rule Name
            /// </summary>
            public const string RuleName = "RuleName";

            /// <summary>
            /// Start String
            /// </summary>
            public const string StartString = "StartString";

            /// <summary>
            /// End String
            /// </summary>
            public const string EndString = "EndString";

            /// <summary>
            /// Always
            /// </summary>
            public const string Always = "Always";

            /// <summary>
            /// Donot
            /// </summary>
            public const string Donot = "Donot";

        }

        #endregion
    }

} // end of namespace