// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Port.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	Port Monitor Base Class.
// </summary>
// <history>
// 	[faizalk]   27MAR06     Created
//  [faizalk]   25APR06     Enable Test button support
//  [faizalk]   27APR06     Add resource strings
//  [faizalk]   01MAY06     Check for timeout dialog. Make sure Next button is enabled before clicking.
//  [faizalk]   16APR07     Check results of connection test
// </history>
// ---------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Port
{
#region Using directives
using Maui.Core;
using Maui.Core.WinControls;
using Maui.Core.Utilities;
using System;
using System.ComponentModel;
using Mom.Test.UI.Core.Console;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.Console.MonitoringConfiguration;
using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
using Mom.Test.UI.Core.Console.MonitoringConfiguration.Port.Dialogs;
using System.Net;
using System.Net.Sockets;
#endregion

    /// <summary>
    /// Class to add general methods for Port Monitor/Template
    /// </summary>
    /// <history> 	
    ///   [faizalk]  Created
    /// </history>
    public class Port
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
        private EnterAndTestPortSettingsDialog cachedEnterAndTestPortSettingsDialog;

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
        /// Port
        /// </summary>
        public Port()
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
        /// Enter and Test Port Settings Dialog
        /// The third screen of the Create Component wizard.
        /// </summary>
        public EnterAndTestPortSettingsDialog enterAndTestPortSettingsDialog
        {
            get
            {
                if (this.cachedEnterAndTestPortSettingsDialog == null)
                {
                    this.cachedEnterAndTestPortSettingsDialog = new EnterAndTestPortSettingsDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Enter and Test Port Settings Dialog was successful");
                }

                return this.cachedEnterAndTestPortSettingsDialog;
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
        /// Create a new Port Monitor component
        /// </summary>
        /// <param name="parameters">PortMonitorParameters</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [faizalk] 27MAR06 - Created   
        /// </history>
        public void CreateComponent(PortParameters parameters)
        {
            Utilities.LogMessage("Port.CreateComponent::" +
                "Launch Create Component Wizard");

            // Get Reference to Actions Pane. And select the wizard from the actions pane.
            ActionsPane actionsPane = CoreManager.MomConsole.ActionsPane;
            string monitoredComponentsPath = NavigationPane.Strings.MonitoringConfiguration
                + Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewMonitoredComponents;
            actionsPane.ClickLink(
                NavigationPane.WunderBarButton.MonitoringConfiguration, 
                monitoredComponentsPath,
                ActionsPane.Strings.ActionsPaneMonitoredComponents, 
                Templates.Strings.LaunchComponentWizardTask);

            Utilities.LogMessage("Port.CreateComponent:: Selected '"
                + Templates.Strings.LaunchComponentWizardTask + "'");

            // Based on the Type parameter; Select the component Type 
            string typeSelected = SelectComponentTypeDialog.Strings.PortTemplate;

            #region Navigate through all the screens of the Wizard

            Maui.Core.WinControls.TreeNode myNode = null;
            myNode = this.componentTypeDialog.Controls.SelectComponentTypeTreeView.Find(typeSelected);
            Utilities.LogMessage("Port.CreateComponent:: Found component type '" + typeSelected + "'");

            myNode.Select();
            Utilities.LogMessage("Port.CreateComponent:: Successfully selected component type '" +
                typeSelected + "'");
            myNode.Click();
            UISynchronization.WaitForProcessReady(this.componentTypeDialog);
            this.componentTypeDialog.WaitForResponse();
            UISynchronization.WaitForProcessReady(this.componentTypeDialog, 60000);
            UISynchronization.WaitForUIObjectReady(this.componentTypeDialog, 60000);

            if (!consoleApp.Waiters.WaitForWizardNavigationItemCount(this.componentTypeDialog, 5, 30000))
            {
                Utilities.LogMessage("Port.CreateComponent:: NavigationItemCount not expected value");
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.componentTypeDialog.Controls.NextButton, Constants.OneMinute);

            Utilities.LogMessage("Port.CreateComponent:: Successfully clicked on component type");

            this.componentTypeDialog.WaitForResponse();
            this.componentTypeDialog.ClickNext();
            this.generalPropertiesTemplateDialog.WaitForResponse();

            // Enter the General Properties
            // Trying to set the name -- if its null throws System.ArgumentNullException
            if (null != parameters.Name)
            {
                this.generalPropertiesTemplateDialog.NameText = parameters.Name;
                Utilities.LogMessage("Port.CreateComponent:: Set display name '" +
                    this.generalPropertiesTemplateDialog.NameText + "'");
            }
            else
            {
                throw new System.ArgumentNullException("PortParameters.Name cannot be null!");
            }
            
            if (null != parameters.Description)
            {
                this.generalPropertiesTemplateDialog.DescriptionText = parameters.Description;
                Utilities.LogMessage("Port.CreateComponent:: Set description '"
                + this.generalPropertiesTemplateDialog.DescriptionText + "'");
            }

            if (null != parameters.DestinationMP)
            {
                this.generalPropertiesTemplateDialog.Controls.SelectDestinationManagementPackComboBox.SelectByText(parameters.DestinationMP);
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.generalPropertiesTemplateDialog.Controls.NextButton, Constants.OneMinute);

            this.generalPropertiesTemplateDialog.WaitForResponse();
            this.generalPropertiesTemplateDialog.ClickNext();
            this.enterAndTestPortSettingsDialog.WaitForResponse();

            if (null != parameters.IpAddressOrDeviceName)
            {
                this.enterAndTestPortSettingsDialog.IPAddressOrDeviceNameText = parameters.IpAddressOrDeviceName;
            }

            if (null != parameters.PortNumber)
            {
                this.enterAndTestPortSettingsDialog.Controls.PortTextBox.Click();
                this.enterAndTestPortSettingsDialog.Controls.PortTextBox.SendKeys(parameters.PortNumber);
            }

            bool testComplete = true;
            bool testResultFailure = false;

            for (int i = 0; i < Constants.DefaultMaxRetry  && parameters.RunTest;i++ )
            {
                Utilities.LogMessage("Retry at " + (1 + i) + " / " + Constants.DefaultMaxRetry);

                testResultFailure = false;
                testComplete = false;
                int timeWaited = 0;
                const int MaxTimeWaited = 60;
                int retry = 0;
                int maxtries = 10;

                this.enterAndTestPortSettingsDialog.ClickTest();

                while (!testComplete && retry <= maxtries)
                {
                    Utilities.LogMessage("Port.CreateComponent:: waiting for test to complete...");

                    // set wait loop parameters
                    timeWaited = 0;

                    // Wait for the test to finish
                    while (this.enterAndTestPortSettingsDialog.Controls.TestButton.IsEnabled == false
                        && timeWaited < MaxTimeWaited)
                    {
                        // wait two seconds and try again
                        timeWaited++;
                        Sleeper.Delay(Constants.OneSecond);
                    }

                    Utilities.LogMessage("Port.CreateComponent:: waited " + timeWaited + " seconds for test to complete.");

                    try
                    {
                        CoreManager.MomConsole.ConfirmChoiceDialog(true, Templates.Strings.TimeoutDialogTitle);
                        Utilities.LogMessage("Port.CreateComponent::Task timed out. Still waiting...");
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage("Port.CreateComponent::No task timeout dialog found");
                        if (this.enterAndTestPortSettingsDialog.Controls.TestButton.IsEnabled)
                        {
                            testComplete = true;
                            Utilities.LogMessage("Port.CreateComponent::test complete = true");
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
                        Utilities.LogMessage("Port.CreateComponent::Task timed out. Stopped the Test.");
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage("Port.CreateComponent::No task timeout dialog found");
                        if (this.enterAndTestPortSettingsDialog.Controls.TestButton.IsEnabled)
                        {
                            testComplete = true;
                            Utilities.LogMessage("Port.CreateComponent::test complete = true");
                        }
                    }
                }

                // If testCompleted we can do this, otherwise it'll fail.
                if (testComplete)
                {
                    this.cachedEnterAndTestPortSettingsDialog = null; // force reacquire of window
                    this.enterAndTestPortSettingsDialog.WaitForResponse();
                }
                else
                {
                    Utilities.LogMessage("CONNECTION TEST FAILED");
                    Utilities.TakeScreenshot("Connection test failed");
                }

                // Wait for Next to be enabled
                timeWaited = 0;

                while (this.enterAndTestPortSettingsDialog.Controls.NextButton.IsEnabled == false
                        && timeWaited < MaxTimeWaited)
                {
                    // wait a second and try again
                    timeWaited++;
                    Sleeper.Delay(1000);
                }

                Utilities.LogMessage("Port.CreateComponent:: waited " + timeWaited + " seconds for Next button to be enabled");

                #region output the status of the special port
                //output the status of the special port 
                bool tcpListen = false;//TCP Listen Identify
                bool udpListen = false;//UDP Listen Identify
                System.Net.IPAddress myIpAddress = IPAddress.Parse("127.0.0.1");
                System.Net.IPEndPoint myIpEndPoint = new IPEndPoint(myIpAddress, int.Parse(parameters.PortNumber));
                try
                {
                    System.Net.Sockets.TcpClient tcpClient = new TcpClient();
                    tcpClient.Connect(myIpEndPoint);//TCP Connection request
                    tcpListen = true;
                }
                catch { }
                try
                {
                    System.Net.Sockets.UdpClient udpClient = new UdpClient();
                    udpClient.Connect(myIpEndPoint);//UDP Connection request
                    udpListen = true;
                }
                catch { }
                if (tcpListen == false && udpListen == false)
                {
                    Utilities.LogMessage("Port.CreateComponent:: " + parameters.PortNumber + " is close");
                }
                else
                {
                    Utilities.LogMessage("Port.CreateComponent:: " + parameters.PortNumber + " is open");
                }
                #endregion

                // verify connection test result
                Utilities.LogMessage("Returned status: " + this.enterAndTestPortSettingsDialog.Controls.RequestProcessedSuccessfullyStaticControl.Text);
                if (parameters.ExpectedTestSuccess)
                {
                    if (String.Compare(this.enterAndTestPortSettingsDialog.Controls.RequestProcessedSuccessfullyStaticControl.Text, EnterAndTestPortSettingsDialog.Strings.RequestProcessedSuccessfully) != 0)
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
                    if (String.Compare(this.enterAndTestPortSettingsDialog.Controls.RequestProcessedSuccessfullyStaticControl.Text, EnterAndTestPortSettingsDialog.Strings.RequestProcessedSuccessfully) == 0)
                    {
                        // log failure
                        Utilities.LogMessage("Returned status does NOT match expected result!");
                        Utilities.TakeScreenshot("Connection status mismatch");
                        testResultFailure = true;
                    }
                }

                if (!testResultFailure)
                    break;
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.enterAndTestPortSettingsDialog.Controls.NextButton, Constants.OneMinute);

            this.enterAndTestPortSettingsDialog.WaitForResponse();
            this.enterAndTestPortSettingsDialog.ClickNext();
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
                    Utilities.LogMessage("Port.CreateComponent:: QueryIntervalUnit parameter: '" +
                        parameters.QueryIntervalUnit + "' is invalid");
                    throw new InvalidEnumArgumentException("Invalid Type selected");
            }

            this.chooseWatcherNodesDialog.Controls.UnitsComboBox.SelectByText(queryUnits);

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.chooseWatcherNodesDialog.Controls.NextButton, Constants.OneMinute);

            this.chooseWatcherNodesDialog.WaitForResponse();
            this.chooseWatcherNodesDialog.ClickNext();
            this.settingsSummaryDialog.WaitForResponse();

            // Complete the wizard                
            this.settingsSummaryDialog.ClickCreate();
            CoreManager.MomConsole.WaitForDialogClose(this.settingsSummaryDialog, 120);

            // putting a short delay for the wizard to complete
            Sleeper.Delay(Constants.OneSecond * 3);
            Utilities.LogMessage("Port.CreateComponent:: Successfully completed Component Creation!!");

            #endregion

            #region Verify Component Created

            Templates templates = new Templates();
            if (templates.ComponentExists(Templates.ComponentType.TcpPort, parameters.Name))
            {
                Utilities.LogMessage("Port.CreateComponent:: Found " + parameters.Name + " in Monitored Components view");
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

        /// <summary>
        /// Verify Port Monitor component properties
        /// </summary>
        /// <param name="parameters">PortMonitorParameters</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [faizalk] 19APR2007 - Created   
        /// </history>
        public void VerifyComponentProperties(PortParameters parameters)
        {
            Utilities.LogMessage("Port.VerifyComponentProperties");

            Templates templates = new Templates();

            templates.VerifyComponentProperties(parameters, Templates.ComponentType.TcpPort);
        }

        /// <summary>
        /// Verify parameters for Port feature.  Properties dialog should already be visible.
        /// </summary>
        /// <history>
        /// [faizalk] 24JUN07 Created
        /// </history>
        public void VerifyPortProperties(PortParameters parameters, TargetAndPortPropertiesDialog portPropertiesDialog)
        {
            Utilities.LogMessage("Port.VerifyPortProperties..");

            if (null != parameters.IpAddressOrDeviceName)
            {
                if (String.Compare(portPropertiesDialog.MonitoringTypeText, parameters.IpAddressOrDeviceName) != 0)
                {
                    throw new Maui.Core.WinControls.TextBox.Exceptions.FailedToSetValueException("Dialog text '" + portPropertiesDialog.MonitoringTypeText + "' does not match expected '" + parameters.IpAddressOrDeviceName + "'");
                }
            }

            if (null != parameters.PortNumber)
            {
                if (String.Compare(portPropertiesDialog.ConnectionStringText, parameters.PortNumber) != 0)
                {
                    throw new Maui.Core.WinControls.TextBox.Exceptions.FailedToSetValueException("Dialog text '" + portPropertiesDialog.ConnectionStringText + "' does not match expected '" + parameters.PortNumber + "'");
                }
            }

            bool testComplete = true;
            bool testResultFailure = false;
            if (parameters.RunTest)
            {
                testComplete = false;
                int timeWaited = 0;
                const int MaxTimeWaited = 60;
                int retry = 0;
                int maxtries = 10;

                portPropertiesDialog.ClickTest();

                while (!testComplete && retry <= maxtries)
                {
                    Utilities.LogMessage("Port.VerifyPortProperties:: waiting for test to complete...");

                    // set wait loop parameters
                    timeWaited = 0;

                    // Wait for the test to finish
                    while (portPropertiesDialog.Controls.TestButton.IsEnabled == false
                        && timeWaited < MaxTimeWaited)
                    {
                        // wait two seconds and try again
                        timeWaited++;
                        Sleeper.Delay(Constants.OneSecond);
                    }

                    Utilities.LogMessage("Port.VerifyPortProperties:: waited " + timeWaited + " seconds for test to complete.");

                    try
                    {
                        CoreManager.MomConsole.ConfirmChoiceDialog(true, Templates.Strings.TimeoutDialogTitle);
                        Utilities.LogMessage("Port.VerifyPortProperties::Task timed out. Still waiting...");
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage("Port.VerifyPortProperties::No task timeout dialog found");
                        if (portPropertiesDialog.Controls.TestButton.IsEnabled)
                        {
                            testComplete = true;
                            Utilities.LogMessage("Port.VerifyPortProperties::test complete = true");
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
                        Utilities.LogMessage("Port.VerifyPortProperties::Task timed out. Stopped the Test.");
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage("Port.VerifyPortProperties::No task timeout dialog found");
                        if (portPropertiesDialog.Controls.TestButton.IsEnabled)
                        {
                            testComplete = true;
                            Utilities.LogMessage("Port.VerifyPortProperties::test complete = true");
                        }
                    }
                }

                if (testComplete)
                {
                    portPropertiesDialog.WaitForResponse();
                }
                else
                {
                    Utilities.LogMessage("CONNECTION TEST FAILED");
                    Utilities.TakeScreenshot("Connection test failed");
                }

                // Wait again for Test button to be enabled just in case
                timeWaited = 0;

                while (portPropertiesDialog.Controls.TestButton.IsEnabled == false
                        && timeWaited < MaxTimeWaited)
                {
                    // wait a second and try again
                    timeWaited++;
                    Maui.Core.Utilities.Sleeper.Delay(1000);
                }

                Utilities.LogMessage("Port.VerifyPortProperties:: waited another " + timeWaited + " seconds for Test button to be enabled");

                // verify connection test result
                Utilities.LogMessage("Returned status: " + portPropertiesDialog.Controls.RequestProcessedSuccessfullyStaticControl.Text);
                if (parameters.ExpectedTestSuccess)
                {
                    if (String.Compare(portPropertiesDialog.Controls.RequestProcessedSuccessfullyStaticControl.Text, TargetAndPortPropertiesDialog.Strings.RequestProcessedSuccessfully) != 0)
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
                    if (String.Compare(portPropertiesDialog.Controls.RequestProcessedSuccessfullyStaticControl.Text, TargetAndPortPropertiesDialog.Strings.RequestProcessedSuccessfully) == 0)
                    {
                        // log failure
                        Utilities.LogMessage("Returned status does NOT match expected result!");
                        Utilities.TakeScreenshot("Connection status mismatch");
                        testResultFailure = true;
                    }
                }
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(portPropertiesDialog.Controls.TestButton, Constants.OneMinute);
            portPropertiesDialog.ClickOK();
            CoreManager.MomConsole.WaitForDialogClose(portPropertiesDialog, 60);            

            if (!testComplete)
            {
                throw new TimeoutException("Connection test failed to complete!");
            }

            if (testResultFailure)
            {
                throw new MissingFieldException("Expected connection test result: " + parameters.ExpectedTestSuccess);
            }
        }       

        /// <summary>
        /// Edit parameters for Port feature.  Properties dialog should already be visible.
        /// </summary>
        /// <history>
        /// [faizalk] 18JUN07 Created
        /// </history>
        public void EditPortProperties(PortParameters parameters, TargetAndPortPropertiesDialog portPropertiesDialog)
        {
            Utilities.LogMessage("Port.EditPortProperties..");

            if (null != parameters.IpAddressOrDeviceName)
            {
                if (String.Compare(portPropertiesDialog.MonitoringTypeText, parameters.IpAddressOrDeviceName) != 0)
                {
                    portPropertiesDialog.Controls.MonitoringTypeTextBox.Click(MouseClickType.DoubleClick);
                    portPropertiesDialog.MonitoringTypeText = parameters.IpAddressOrDeviceName;
                }
            }

            if (null != parameters.PortNumber)
            {
                if (String.Compare(portPropertiesDialog.ConnectionStringText, parameters.PortNumber) != 0)
                {
                    portPropertiesDialog.Controls.ConnectionStringTextBox.Click(MouseClickType.DoubleClick);
                    portPropertiesDialog.Controls.ConnectionStringTextBox.SendKeys(parameters.PortNumber);
                }
            }

            bool testComplete = true;
            bool testResultFailure = false;
            if (parameters.RunTest)
            {
                testComplete = false;
                int timeWaited = 0;
                const int MaxTimeWaited = 60;
                int retry = 0;
                int maxtries = 10;

                portPropertiesDialog.ClickTest();

                while (!testComplete && retry <= maxtries)
                {
                    Utilities.LogMessage("Port.EditPortProperties:: waiting for test to complete...");

                    // set wait loop parameters
                    timeWaited = 0;

                    // Wait for the test to finish
                    while (portPropertiesDialog.Controls.TestButton.IsEnabled == false
                        && timeWaited < MaxTimeWaited)
                    {
                        // wait two seconds and try again
                        timeWaited++;
                        Sleeper.Delay(Constants.OneSecond);
                    }

                    Utilities.LogMessage("Port.EditPortProperties:: waited " + timeWaited + " seconds for test to complete.");

                    try
                    {
                        CoreManager.MomConsole.ConfirmChoiceDialog(true, Templates.Strings.TimeoutDialogTitle);
                        Utilities.LogMessage("Port.EditPortProperties::Task timed out. Still waiting...");
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage("Port.EditPortProperties::No task timeout dialog found");
                        if (portPropertiesDialog.Controls.TestButton.IsEnabled)
                        {
                            testComplete = true;
                            Utilities.LogMessage("Port.EditPortProperties::test complete = true");
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
                        Utilities.LogMessage("Port.EditPortProperties::Task timed out. Stopped the Test.");
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage("Port.EditPortProperties::No task timeout dialog found");
                        if (portPropertiesDialog.Controls.TestButton.IsEnabled)
                        {
                            testComplete = true;
                            Utilities.LogMessage("Port.EditPortProperties::test complete = true");
                        }
                    }
                }

                if (testComplete)
                {
                    portPropertiesDialog.WaitForResponse();
                }
                else
                {
                    Utilities.LogMessage("CONNECTION TEST FAILED");
                    Utilities.TakeScreenshot("Connection test failed");
                }

                // Wait again for Test button to be enabled just in case
                timeWaited = 0;

                while (portPropertiesDialog.Controls.TestButton.IsEnabled == false
                        && timeWaited < MaxTimeWaited)
                {
                    // wait a second and try again
                    timeWaited++;
                    Maui.Core.Utilities.Sleeper.Delay(1000);
                }

                Utilities.LogMessage("Port.EditPortProperties:: waited another " + timeWaited + " seconds for Test button to be enabled");

                // verify connection test result
                Utilities.LogMessage("Returned status: " + portPropertiesDialog.Controls.RequestProcessedSuccessfullyStaticControl.Text);
                if (parameters.ExpectedTestSuccess)
                {
                    if (String.Compare(portPropertiesDialog.Controls.RequestProcessedSuccessfullyStaticControl.Text, TargetAndPortPropertiesDialog.Strings.RequestProcessedSuccessfully) != 0)
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
                    if (String.Compare(portPropertiesDialog.Controls.RequestProcessedSuccessfullyStaticControl.Text, TargetAndPortPropertiesDialog.Strings.RequestProcessedSuccessfully) == 0)
                    {
                        // log failure
                        Utilities.LogMessage("Returned status does NOT match expected result!");
                        Utilities.TakeScreenshot("Connection status mismatch");
                        testResultFailure = true;
                    }
                }
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(portPropertiesDialog.Controls.TestButton, Constants.OneMinute);
            portPropertiesDialog.ClickOK();
            CoreManager.MomConsole.WaitForDialogClose(portPropertiesDialog, 60);

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

        #region PortParameters Class
        /// <summary>
        /// Parameters class for Port constructors.
        /// </summary>
        /// <history>
        /// [faizalk] 27MAR06 Created
        /// [faizalk] 25APR07 Extend SynTxParameters
        /// </history>
        public class PortParameters:Core.Console.MonitoringConfiguration.SynTxParameters
        {
            #region Private Members
            private string cachedIpAddressOrDeviceName = null;
            private string cachedPortNumber = null;
            #endregion

            #region Properties

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
            /// Port number to be monitored
            /// </summary>
            public string PortNumber
            {
                get
                {
                    return this.cachedPortNumber;
                }

                set
                {
                    this.cachedPortNumber = value;
                }
            }

            #endregion
        }
        #endregion
    } // end of class Port
} // end of namespace