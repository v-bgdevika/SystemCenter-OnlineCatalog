// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WindowsService.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	Process Monitoring Base Class.
// </summary>
// <history>
// 	[bretlink] 26-SEP-08   Created
// </history>
// ---------------------------------------------------------------------------

#region Using directives
using System;
using Maui.Core;
using Maui.Core.Utilities;
using Maui.Core.WinControls;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.Console;
using Mom.Test.UI.Core.Console.Dialogs;
using Mom.Test.UI.Core.Console.MonitoringConfiguration;
using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
using Mom.Test.UI.Core.Console.MonitoringConfiguration.ProcessMonitor.Dialogs;
#endregion

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.ProcessMonitor
{
    /// <summary>
    /// Class to add general methods for Process Monitor Template
    /// </summary>
    /// <history>
    ///   [bretlink]  Created
    /// </history>
    public class ProcessMonitor
    {
        #region Private Constants

        #endregion

        #region Private Members

        /// <summary>
        /// cachedComponentTypeDialog
        /// </summary>
        private SelectComponentTypeDialog cachedComponentTypeDialog;

        /// <summary>
        /// cachedGeneralPropertiesDialog
        /// </summary>
        private GeneralPropertiesDialog cachedGeneralPropertiesDialog;

        /// <summary>
        /// cachedTargetGroupAndProcessDialog
        /// </summary>
        private TargetGroupAndProcessDialog cachedTargetGroupAndProcessDialog;

        /// <summary>
        /// cachedRunningProcessesDialog
        /// </summary>
        private RunningProcessesDialog cachedRunningProcessesDialog;

        /// <summary>
        /// cachedPerformanceDataDialog 
        /// </summary>
        private PerformanceDataDialog cachedPerformanceDataDialog;

        /// <summary>
        /// cachedSettingsSummaryDialog 
        /// </summary>
        private SettingsSummaryDialog cachedSettingsSummaryDialog;

        #endregion

        #region Properties

        /// <summary>
        /// Select ComponentTypeDialog
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
        public GeneralPropertiesDialog generalPropertiesDialog
        {
            get
            {
                if (this.cachedGeneralPropertiesDialog == null)
                {
                    this.cachedGeneralPropertiesDialog = new GeneralPropertiesDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitoringTemplateWizard);
                    Utilities.LogMessage("Setting Focus on the General Properties Dialog was successful");
                }

                return this.cachedGeneralPropertiesDialog;
            }
        }

        /// <summary>
        /// Select TargetGroupAndProcessDialog
        /// The third screen of the Create Component wizard.
        /// </summary>
        public TargetGroupAndProcessDialog targetGroupAndProcessDialog
        {
            get
            {
                if (this.cachedTargetGroupAndProcessDialog == null)
                {
                    this.cachedTargetGroupAndProcessDialog = new TargetGroupAndProcessDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Select Component Type Dialog was successful");
                }
                return this.cachedTargetGroupAndProcessDialog;
            }
        }

        /// <summary>
        /// Select RunningProcessesDialog
        /// The fourth screen of the Create Component wizard.
        /// </summary>
        public RunningProcessesDialog runningProcessesDialog
        {
            get
            {
                if (this.cachedRunningProcessesDialog == null)
                {
                    this.cachedRunningProcessesDialog = new RunningProcessesDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Select Component Type Dialog was successful");
                }
                return this.cachedRunningProcessesDialog;
            }
        }

        /// <summary>
        /// Select PerformanceDataDialog
        /// The fifth screen of the Create Component wizard.
        /// </summary>
        public PerformanceDataDialog performanceDataDialog
        {
            get
            {
                if (this.cachedPerformanceDataDialog == null)
                {
                    this.cachedPerformanceDataDialog = new PerformanceDataDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Select Component Type Dialog was successful");
                }
                return this.cachedPerformanceDataDialog;
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
        /// Method to navigate through the screens of the Process Monitoring Wizard.
        /// </summary>
        /// 
        //Mom.Test.UI.Core.Common.Constants.UITestMPDisplayName;
        public void CreateComponent(ProcessMonitorParameters parameters)
        {
            Utilities.LogMessage("ProcessMonitor.CreateComponent(...)");
            Utilities.LogMessage("Go through the wizard to create a new Process Monitor Template");

            #region Navigate to Wizard

            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Authoring);

            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
            Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond * 3);

            ActionsPane actionsPane = CoreManager.MomConsole.ActionsPane;
            string monitoredComponentsPath = NavigationPane.Strings.MonitoringConfiguration
                + Mom.Test.UI.Core.Common.Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewMonitoredComponents
                + Mom.Test.UI.Core.Common.Constants.PathDelimiter + SelectComponentTypeDialog.Strings.OleDbTemplate;
            actionsPane.ClickLink(NavigationPane.WunderBarButton.MonitoringConfiguration,
                monitoredComponentsPath,
                ActionsPane.Strings.ActionsPaneMonitoredComponents,
                Templates.Strings.LaunchComponentWizardTask);

            #endregion

            #region Navigate through the wizard screens

            #region Select Component Type Page
            //Page 1 - Click on Process Monitor

            SelectComponentTypeDialog componentTypeDialog = new SelectComponentTypeDialog(CoreManager.MomConsole);

            Maui.Core.WinControls.TreeNode PMNode = null;

            PMNode = componentTypeDialog.Controls.SelectComponentTypeTreeView.Find(SelectComponentTypeDialog.Strings.ProcessMonitoringTemplate);
            
            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Select Monitor type");
            PMNode.Select();

            //PMNode.Click();
            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Navigate to Process Monitor");

            componentTypeDialog.Controls.NextButton.Click();

            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Clicking Next");

            #endregion

            #region General Properties Page
            //Page 2 - General Properties Page

            GeneralPropertiesDialog PropertiesPage = null;

            int retry = 0;
            int maxCount = 10;
            bool setName = false;

            while (setName == false && retry <= maxCount)
            {
                try
                {
                    //Setting the friendly name of the template.
                    PropertiesPage = new GeneralPropertiesDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitoringTemplateWizard);
                    Utilities.LogMessage("ProcessMonitor.CreateComponent:: Setting the name to: '" + parameters.name + "'");
                    PropertiesPage.NameText = parameters.name;
                    setName = true;
                    Utilities.LogMessage("ProcessMonitor.CreateComponent:: Successfully set the name to: '" + PropertiesPage.NameText + "'");
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    Sleeper.Delay(Core.Common.Constants.OneSecond);
                    Utilities.LogMessage("ProcessMonitor.CreateComponent:: Failed to get reference to Name Text Box, let's navigate and try again.");
                    Utilities.TakeScreenshot("ProcessMonitor.CreateComponent_NameTextBox_NotFound");
                }
                retry++;
            }

            //Setting the description for the template.
            if (parameters.description != null)
            {
                Utilities.LogMessage("ProcessMonitor.CreateComponent:: Setting the description to: '" + parameters.description + "'");
                PropertiesPage.DescriptionText = parameters.description;
                Utilities.LogMessage("ProcessMonitor.CreateComponent:: Successfully set the description to: '" + PropertiesPage.DescriptionText + "'");
            }
            //Select Management Pack
            if (parameters.managementPack != null)
            {
                PropertiesPage.Controls.SelectDestinationManagementPackComboBox.SelectByText(parameters.managementPack);
                Utilities.LogMessage("ProcessMonitor.CreateComponent:: Setting Management Pack To UI Test Management Pack");
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(PropertiesPage.Controls.NextButton, Constants.OneMinute);
            PropertiesPage.ClickNext();
            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Clicking Next");

            #endregion

            #region Target Group and Process Page
            //Page 3 - Target Group and Process Page

            TargetGroupAndProcessDialog targetPage = new TargetGroupAndProcessDialog(CoreManager.MomConsole);

            targetPage.ProcessNameText = parameters.processName;

            targetPage.ClickGroupSearch();


            #region Group Search Dialog Box

            GroupSearchDialog groupSearchPage = new GroupSearchDialog(CoreManager.MomConsole);

            ListViewItemCollection groupToSelect;

            if (parameters.groupName == null)
            {
                throw new ArgumentNullException("WindowsService:: Group name cannot be null");
            }

            if (parameters.filters != null)
                groupSearchPage.TextFilterText = parameters.filters;

            if (parameters.MPFilter != null)
                groupSearchPage.MPFilterText = parameters.MPFilter;

            groupSearchPage.ClickSearch();

            int retries = 0;
            int maxRetries = 20;

            while (groupSearchPage.Controls.GroupsListView.Count == 0 && retries < maxRetries)
            {
                retries++;
                Utilities.LogMessage("ProcessMonitor.CreateComponent:: Waiting for Group List to populate.");
                Utilities.LogMessage("ProcessMonitor.CreateComponent:: Attempt " + retries + " of " + maxRetries);
                Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond * 3);
            }

            retries = 0;
            maxRetries = 5;

            bool foundGroup = false;
            groupSearchPage.Controls.GroupsListView.WaitForResponse();
            while (retries < maxRetries && foundGroup == false)
            {
                groupToSelect = groupSearchPage.Controls.GroupsListView.FindAllByText(parameters.groupName);
                if (groupToSelect.Count > 0)
                {
                    int retriesClick = 0;
                    while (false == groupSearchPage.Controls.OKButton.IsEnabled && retriesClick < maxRetries)
                    {
                        groupToSelect[0].Select();
                        Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
                        retriesClick++;
                    }
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(groupSearchPage.Controls.OKButton, Constants.DefaultDialogTimeout);

                    foundGroup = true;
                }
                retries++;
                Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond * 3);
            }
            if (foundGroup == false)
            {
                Utilities.LogMessage("ProcessMonitor.CreateComponent:: Failed to find " + parameters.groupName + " in the groups list.");
                throw new Exception("ProcessMonitor.CreateComponent:: Failed to find " + parameters.groupName + " in the groups list.");
            }
            Utilities.LogMessage("Trying To Click OK");
            Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
            groupSearchPage.ClickOK();
            Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);

            Utilities.LogMessage("OK Clicked");
            #endregion


            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Process and Group Selected");
            if (parameters.unwantedProcess)
            {
                targetPage.Controls.UnwantedProcessRadioButton.Click();
                Utilities.LogMessage("ProcessMonitor.CreateComponent:: Unwanted Process Button Clicked");
            }
            else
            {
                targetPage.Controls.ProcessMonitorRadioButton.Click();
                Utilities.LogMessage("ProcessMonitor.CreateComponent:: Process Monitor Button Clicked");
            }
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(targetPage.Controls.NextButton, Constants.OneMinute);
            targetPage.ClickNext();

            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Clicking Next");

            #endregion

            #region Running Processes Page
            //Page 4 - Running Processes Page

            RunningProcessesDialog runningProcesses = new RunningProcessesDialog(CoreManager.MomConsole);

            //Set values if alert generated when instances fall outside of range
            if (!parameters.unwantedProcess)
            {
                //Adding retries. Bug#188793.
                retries = 1;
                maxRetries = Constants.DefaultDialogTimeout / Constants.OneSecond;
                while (retries <= maxRetries)
                {
                    Utilities.LogMessage("ProcessMonitor.CreateComponent:: Attempt " + retries + " of " + maxRetries);
                    try
                    {
                        if (parameters.minMax)
                        {
                            runningProcesses.Controls.NumInstancesRadioButton.Click();
                            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Alert when instances is out of range selected.");

                            runningProcesses.Controls.MinimumInstancesComboBox.Text = parameters.numMinInstances;
                            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Minimum instances threshold set to " + runningProcesses.Controls.MinimumInstancesComboBox.Text);

                            runningProcesses.Controls.MaximumInstancesComboBox.Text = parameters.numMaxInstances;
                            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Maximum instances threshold set to " + runningProcesses.Controls.MaximumInstancesComboBox.Text);

                            runningProcesses.Controls.DurationValNumInstancesComboBox.Text = parameters.instanceDuration;
                            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Duration Value set to " + runningProcesses.Controls.DurationValNumInstancesComboBox.Text);

                            runningProcesses.Controls.DurationUnitNumInstancesComboBox.SelectByText(parameters.instanceDurationUnit);
                            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Duration unit set to " + runningProcesses.Controls.DurationUnitNumInstancesComboBox.Text);
                        }
                        //Set values for alert generated if instance has been running too long
                        else
                        {
                            runningProcesses.Controls.DurationRadioButton.Click();
                            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Alert when an instance has been running too long selected");

                            runningProcesses.Controls.DurationValRuntimeComboBox.Text = parameters.instanceDuration;
                            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Duration limit value set to " + runningProcesses.Controls.DurationValRuntimeComboBox.Text);
                            runningProcesses.Controls.DurationUnitRuntimeComboBox.SelectByText(parameters.instanceDurationUnit);
                            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Duration limit unit set to " + runningProcesses.Controls.DurationUnitRuntimeComboBox.Text);
                        }

                        break;
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        if (retries == maxRetries)
                        {
                            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Failed to set values.");
                            throw;
                        }

                        Sleeper.Delay(Constants.OneSecond);
                        retries++;
                    }
                }
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(runningProcesses.Controls.NextButton, Constants.OneMinute);
            runningProcesses.ClickNext();

            #endregion

            #region Performance Data Page
            //Page 5 - Performance Data
            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Clicking Next");

            PerformanceDataDialog performanceData = new PerformanceDataDialog(CoreManager.MomConsole);
            if (!parameters.unwantedProcess)
            {
                //% Processor Time Alert selected
                if (parameters.processorTimeAlert)
                {
                    if (performanceData.Controls.ProcessorTimeThresholdCheckBox.ButtonState != ButtonState.Checked)
                    {
                        performanceData.Controls.ProcessorTimeThresholdCheckBox.Click();
                    }
                    Utilities.LogMessage("ProcessMonitor.CreateComponent:: Alert on % Processor Time selected");

                    performanceData.Controls.PercentProcTimeComboBox.Text = parameters.percentProcessorTimeThreshold;
                    Utilities.LogMessage("ProcessMonitor.CreateComponent:: % Processor Time Threshold set to " + this.performanceDataDialog.Controls.PercentProcTimeComboBox.Text);
                }
                //Private Bytes Alert selected
                if (parameters.bytesAlert)
                {
                    if (performanceData.Controls.PrivateBytesThresholdCheckBox.ButtonState != ButtonState.Checked)
                        performanceData.Controls.PrivateBytesThresholdCheckBox.Click();
                    Utilities.LogMessage("ProcessMonitor.CreateComponent:: Alert on Private Bytes(MB) selected");

                    performanceData.Controls.NumBytesComboBox.Text = parameters.numBytesThreshold;
                    Utilities.LogMessage("ProcessMonitor.CreateComponent:: Private Bytes(MB) Threshold set to " + this.performanceDataDialog.Controls.NumBytesComboBox.Text);
                }
                if (parameters.bytesAlert || parameters.processorTimeAlert)
                {
                    performanceData.Controls.NumSamplesComboBox.Text = parameters.numSamples;
                    Utilities.LogMessage("ProcessMonitor.CreateComponent:: Number of Samples set to " + performanceData.Controls.NumSamplesComboBox.Text);

                    performanceData.Controls.IntervalThresholdComboBox.Text = parameters.counterThresholdInterval;
                    Utilities.LogMessage("ProcessMonitor.CreateComponent:: Threshold Interval set to " + parameters.counterThresholdInterval);

                    performanceData.Controls.IntervalUnitComboBox.SelectByText(parameters.counterThresholdIntervalUnit);
                    Utilities.LogMessage("ProcessMonitor.CreateComponent:: Threshold Interval Unit set to " + performanceData.Controls.IntervalUnitComboBox.Text);
                }
            }
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(performanceData.Controls.NextButton, Constants.OneMinute);
            performanceData.ClickNext();

            #endregion

            #region Summary Page
            //Page 6 - Setting Summary
            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Clicking Next");

            SettingsSummaryDialog summaryPage = new SettingsSummaryDialog(CoreManager.MomConsole);
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(summaryPage.Controls.CreateButton, Constants.OneMinute / Constants.OneSecond);
            summaryPage.ClickCreate();
            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Clicking Create");

            CoreManager.MomConsole.WaitForDialogClose(componentTypeDialog, 120);

            retry = 0;
            maxCount = 120;
            while (!CoreManager.MomConsole.MainWindow.Extended.IsForeground && retry <= maxCount)
            {
                Utilities.LogMessage("ProcessMonitor.CreateComponent:: MainWindow not Foreground, let's wait a moment.");
                Sleeper.Delay(Constants.OneSecond);
                retry++;
            }

            UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout * 2);
            CoreManager.MomConsole.Waiters.WaitForStatusReady();
            Sleeper.Delay(3000);


            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
            Utilities.LogMessage("ProcessMonitor.CreateComponent:: Process Monitoring Template Successfully Created!");

            #endregion

            #endregion
        }

        /// <summary>
        /// Method to create a number of instances of a process.
        /// </summary>
        public void CreateProcessInstances(string allocatebool, string numbytes, string processName)
        {
            Utilities.LogMessage("CreateProcessInstances(...)");
            Utilities.LogMessage("Create instances of a process and allocate bytes to them if desired.");

            string path = Environment.CurrentDirectory + @"\" + processName;
            string privateMemory = allocatebool + " " + numbytes;
            System.Diagnostics.Process.Start(path, privateMemory);
            Utilities.LogMessage("CreateProcessInstances:: Successfully started " + processName + " on the local machine.");
        }

        /// <summary>
        /// Edit component properties
        /// </summary>
        /// <param name="parameters">ProcessMonitorParameters</param>
        /// <param name="componentName">String</param>
        /// <param name="type">ComponentType</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [v-brucec] 28APR2010 - Created   
        /// </history>
        public void EditComponentProperties(ProcessMonitorParameters parameters, String componentName, Templates.ComponentType type)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + " :: Start...");
            Utilities.LogMessage(currentMethod + " :: Editing dialog controls' properties.");

            this.VerifyEditPropertyDialogControls(parameters, componentName, type, true);

            CoreManager.MomConsole.Waiters.WaitForStatusReady();
            Utilities.LogMessage(currentMethod + " :: End.");
        }

        /// <summary>
        /// Verify component properties
        /// </summary>
        /// <param name="parameters">ProcessMonitorParameters</param>
        /// <param name="type">ComponentType</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [v-brucec] 28APR2010 - Created   
        /// </history>
        public void VerifyComponentProperties(ProcessMonitorParameters parameters, Templates.ComponentType type)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + " :: Start...");
            Utilities.LogMessage(currentMethod + " :: Verifying dialog controls' properties.");

            this.VerifyEditPropertyDialogControls(parameters, parameters.name, type, false);

            CoreManager.MomConsole.Waiters.WaitForStatusReady();
            Utilities.LogMessage(currentMethod + " :: End.");
        }

        /// <summary>
        /// Method to kill a number of instances of a process.
        /// </summary>
        public void StopProcessInstances(int numStopped, string processFriendlyName)
        {
            Utilities.LogMessage("StopProcessInstances(...)");
            Utilities.LogMessage("Stops a set number of instances of a process");
            System.Diagnostics.Process[] processObj = System.Diagnostics.Process.GetProcessesByName(processFriendlyName);
            if (numStopped <= processObj.Length)
            {
                for (int i = 0; i <= numStopped - 1; i++)
                {
                    processObj[i].Kill();
                }
            }
        }

        /// <summary>
        /// Method to kill all instances of a process.
        /// </summary>
        public void StopAllProcessInstances(string processFriendlyName)
        {
            Utilities.LogMessage("StopAllProcessInstances(...)");
            Utilities.LogMessage("Stops all instances of a process");
            System.Diagnostics.Process[] processObj = System.Diagnostics.Process.GetProcessesByName(processFriendlyName);
            for (int i = 0; i < processObj.Length; i++)
            {
                processObj[i].Kill();
            }
        }

        /// <summary>
        /// Method to delete a template created by Add Monitoring Wizard.
        /// </summary>
        public void DeleteProcessMonitor(string monitorName)
        {
            Utilities.LogMessage("DeleteProcessMonitor(...)");
            Utilities.LogMessage("Method to delete Monitors addded by running the Add Monitoring Wizard for Process Monitor");

            this.NavigateToPMTab();

            CoreManager.MomConsole.Waiters.WaitForStatusReady();
            Templates.ComponentType type = Templates.ComponentType.ProcessMonitor;

            //Verify the windows service added under Monitored Components 
            //template folder view
            try
            {
                Templates searchComponent = new Templates();
                if (searchComponent.ComponentExists(type, monitorName))
                {
                    Utilities.LogMessage("DeleteProcessMonitor:: Found the component in Monitored Components view");
                }
                else
                {
                    Utilities.LogMessage("DeleteProcessMonitor:: Failed to find the component : "
                        + monitorName
                        + "in Monitored Components View");
                    throw new ListView.Exceptions.ItemNotFoundException("DeleteProcessMonitor:: Failed to find the component in Monitored Components view");
                }
                Maui.Core.WinControls.DataGridViewRow processMonitorRow = null;
                processMonitorRow = CoreManager.MomConsole.ViewPane.Grid.FindData(monitorName, Templates.Strings.ComponentCategoryColumnName, Core.Console.MomControls.GridControl.SearchStringMatchType.ExactMatch);
                Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);
                if (processMonitorRow != null)
                {
                    Utilities.LogMessage("DeleteProcessMonitor:: Process Monitor Template " + monitorName
                        + " found under Management Pack Templates -> Process Monitoring");

                    processMonitorRow.AccessibleObject.Click();

                    #region Delete the Component
                    ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
                    taskPane.ClickLink(ActionsPane.Strings.ActionsPaneMonitoredComponents, ActionsPane.Strings.ActionsPaneDeleteGroup);
                    CoreManager.MomConsole.ConfirmChoiceDialog(true);

                    #endregion
                }
            }
            catch (ListView.Exceptions.ItemNotFoundException ex)
            {
                Utilities.LogMessage("DeleteProcessMonitor:: Failed to find object to delete.");
                throw ex;
            }
        }

        /// <summary>
        /// Method to verify Monitors added by process monitor template
        /// </summary>
        /// <returns>bool</returns>
        public bool VerifyProcessMonitor(ProcessMonitorParameters parameters)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            bool result = false;

            Maui.Core.Window monitorsView = this.OpenMonitorsViewWindow(currentMethod, parameters.name);

            if (monitorsView != null)
            {
                int retry = 0;
                int maxtries = 3;
                monitorsView.ScreenElement.WaitForReady();
                Core.Console.MomControls.GridControl viewGrid = null;

                while ((viewGrid == null) && retry <= maxtries)
                {
                    try
                    {
                        viewGrid = new Mom.Test.UI.Core.Console.MomControls.GridControl(monitorsView, Core.Console.MomControls.GridControl.ControlIDs.ViewPaneGrid);
                        //Bug#210134
                        viewGrid.WaitForRowsLoaded();
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        if (retry == maxtries)
                        {
                            Utilities.LogMessage(currentMethod + ":: Window not found.");
                            return result;
                        }
                        else
                        {
                            Utilities.LogMessage(currentMethod + ":: Failed to find window, retry");
                        }
                    }
                    retry++;
                }

                if (viewGrid != null)
                {
                    viewGrid.Click();
                    Utilities.LogMessage(currentMethod + ":: Clicked on grid view");
                }
                else
                {
                    Utilities.LogMessage(currentMethod + ":: Failed to find grid view in Monitors View");
                    return result;
                }

                #region Verify Monitors

                Core.Console.MonitoringConfiguration.Monitors monitor = new Monitors();

                #region Verify Default Enable Parameter For All Monitors

                int retryCount = 0;
                int maxCount = 3;
                int row = -1;

                #region Verify CPU Usage Monitor

                while (retryCount <= maxCount && row == -1)
                {
                    try
                    {
                        row = monitor.SelectTargetMonitor(viewGrid, parameters.name, parameters.CPUMonitorName);

                        if (row != -1)
                        {
                            Utilities.LogMessage("VerifyProcessMonitor:: Successfully verified Monitor " + parameters.CPUMonitorName + " was created.");

                            bool expected = false;
                            if (parameters.unwantedProcess == false && parameters.processorTimeAlert == true) expected = true;
                            Utilities.LogMessage("VerifyProcessMonitor:: The expected value is " + expected.ToString());

                            bool correctlyEnabled = monitor.VerifyEnableDisableMonitor(viewGrid, parameters.name, parameters.CPUMonitorName, expected);

                            if (correctlyEnabled == true)
                            {
                                Utilities.LogMessage("VerifyProcessMonitor:: Successfully verified the enabled status of " + parameters.CPUMonitorName);
                            }
                            else
                            {
                                return result;
                            }
                        }
                        else if (retryCount == maxCount)
                        {
                            return result;
                        }
                    }
                    catch (Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException)
                    {
                        Utilities.LogMessage("VerifyProcessMonitor:: Failed to select the Monitor - retry");
                        //In case of MCF Exection Window popped up cause lost the focus
                        Utilities.LogMessage(currentMethod + ":: Set the focus to the monitors view window");
                        monitorsView.Extended.SetFocus();
                    }

                    Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
                    retryCount++;
                }

                #endregion

                #region Verify Memory Usage Monitor

                retryCount = 0;
                row = -1;

                while (retryCount <= maxCount && row == -1)
                {
                    try
                    {
                        row = monitor.SelectTargetMonitor(viewGrid, parameters.name, parameters.memoryMonitorName);

                        if (row != -1)
                        {
                            Utilities.LogMessage("VerifyProcessMonitor:: Successfully verified Monitor " + parameters.memoryMonitorName + " was created.");

                            bool expected = false;
                            if (parameters.unwantedProcess == false && parameters.bytesAlert == true) expected = true;
                            bool correctlyEnabled = monitor.VerifyEnableDisableMonitor(viewGrid, parameters.name, parameters.memoryMonitorName, expected);

                            if (correctlyEnabled == true)
                            {
                                Utilities.LogMessage("VerifyProcessMonitor:: Successfully verified the enabled status of " + parameters.memoryMonitorName);
                            }
                            else
                            {
                                return result;
                            }
                        }
                        else if (retryCount == maxCount)
                        {
                            return result;
                        }
                    }
                    catch (Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException)
                    {
                        Utilities.LogMessage("VerifyProcessMonitor:: Failed to select the Monitor - retry");
                    }

                    Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
                    retryCount++;
                }

                #endregion

                #region Verify Unwanted Process Monitor

                retryCount = 0;
                row = -1;

                while (retryCount <= maxCount && row == -1)
                {
                    try
                    {
                        row = monitor.SelectTargetMonitor(viewGrid, parameters.name, parameters.unwantedMonitorName);

                        if (row != -1)
                        {
                            Utilities.LogMessage("VerifyProcessMonitor:: Successfully verified Monitor " + parameters.unwantedMonitorName + " was created.");

                            bool expected = false;
                            if (parameters.unwantedProcess == true) expected = true;
                            bool correctlyEnabled = monitor.VerifyEnableDisableMonitor(viewGrid, parameters.name, parameters.unwantedMonitorName, expected);

                            if (correctlyEnabled == true)
                            {
                                Utilities.LogMessage("VerifyProcessMonitor:: Successfully verified the enabled status of " + parameters.unwantedMonitorName);
                            }
                            else
                            {
                                return result;
                            }
                        }
                        else if (retryCount == maxCount)
                        {
                            return result;
                        }
                    }
                    catch (Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException)
                    {
                        Utilities.LogMessage("VerifyProcessMonitor:: Failed to select the Monitor - retry");
                    }

                    Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
                    retryCount++;
                }

                #endregion

                #region Verify Instance Count Monitor

                retryCount = 0;
                row = -1;

                while (retryCount <= maxCount && row == -1)
                {
                    try
                    {
                        row = monitor.SelectTargetMonitor(viewGrid, parameters.name, parameters.instanceCountMonitorName);

                        if (row != -1)
                        {
                            Utilities.LogMessage("VerifyProcessMonitor:: Successfully verified Monitor " + parameters.instanceCountMonitorName + " was created.");

                            bool expected = false;
                            if (parameters.unwantedProcess == false && parameters.minMax == true) expected = true;
                            bool correctlyEnabled = monitor.VerifyEnableDisableMonitor(viewGrid, parameters.name, parameters.instanceCountMonitorName, expected);

                            if (correctlyEnabled == true)
                            {
                                Utilities.LogMessage("VerifyProcessMonitor:: Successfully verified the enabled status of " + parameters.instanceCountMonitorName);
                            }
                            else
                            {
                                return result;
                            }
                        }
                        else if (retryCount == maxCount)
                        {
                            return result;
                        }
                    }
                    catch (Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException)
                    {
                        Utilities.LogMessage("VerifyProcessMonitor:: Failed to select the Monitor - retry");
                    }

                    Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
                    retryCount++;
                }

                #endregion

                #region Verify Process Runtime Monitor

                retryCount = 0;
                row = -1;

                while (retryCount <= maxCount && row == -1)
                {
                    try
                    {
                        row = monitor.SelectTargetMonitor(viewGrid, parameters.name, parameters.runtimeMonitorName);

                        if (row != -1)
                        {
                            Utilities.LogMessage("VerifyProcessMonitor:: Successfully verified Monitor " + parameters.runtimeMonitorName + " was created.");

                            bool expected = false;
                            if (parameters.unwantedProcess == false && parameters.minMax == false) expected = true;
                            bool correctlyEnabled = monitor.VerifyEnableDisableMonitor(viewGrid, parameters.name, parameters.runtimeMonitorName, expected);

                            if (correctlyEnabled == true)
                            {
                                Utilities.LogMessage("VerifyProcessMonitor:: Successfully verified the enabled status of " + parameters.runtimeMonitorName);
                            }
                            else
                            {
                                return result;
                            }
                        }
                        else if (retryCount == maxCount)
                        {
                            return result;
                        }
                    }
                    catch (Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException)
                    {
                        Utilities.LogMessage("VerifyProcessMonitor:: Failed to select the Monitor - retry");
                    }

                    Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
                    retryCount++;
                }

                #endregion

                #endregion Verify Default Enable Parameter For All Monitors

                #endregion Verify Monitors

                result = true;

                Utilities.LogMessage(currentMethod + ":: Verified Monitors for the Process Monitor - now close the window");

                CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccessSafe(delegate()
                {
                    monitorsView.Extended.SetFocus();
                    monitorsView.Extended.CloseWindow();
                    bool dialogClosed = CoreManager.MomConsole.WaitForDialogClose(monitorsView, Constants.DefaultDialogTimeout);
                    Utilities.LogMessage(currentMethod + ":: dialogClosed: " + dialogClosed);
                    return dialogClosed;
                },
                Constants.OneMinute);

                CoreManager.MomConsole.BringToForeground();
                CoreManager.MomConsole.Waiters.WaitForWindowForeground(CoreManager.MomConsole.MainWindow, Core.Common.Constants.TenSeconds);

                Utilities.LogMessage(currentMethod + ":: Management Pack Objects - Monitors view closed");
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: Failed to find Monitors View Window!");
            }

            return result;
        }

        /// <summary>
        /// Method to verify deleted Process Monitor
        /// </summary>
        /// <param name="processMonitorName">Name of the process monitor created by template</param>
        /// <returns>bool</returns>
        public bool VerifyDeleteProcessMonitor(string processMonitorName)
        {
            Utilities.LogMessage("VerifyDeleteProcessMonitor(...)");
            Utilities.LogMessage("VerifyDeleteProcessMonitor:: Method to verify the deletion of a Process Monitoring Template");

            this.NavigateToPMTab();

            CoreManager.MomConsole.Waiters.WaitForStatusReady();
            Templates.ComponentType type = Templates.ComponentType.ProcessMonitor;

            bool verifyResult = false;
            Templates searchComponent = new Templates();
            int numRetries = 0;
            int maxRetries = 3;

            while (numRetries < maxRetries && verifyResult == false)
            {
                verifyResult = !searchComponent.ComponentExists(type, processMonitorName);
                if (verifyResult == false) Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond * 5);
                numRetries++;
            }

            return verifyResult;
        }

        /// <summary>
        /// Method to navigate to Process Monitoring template view
        /// </summary>
        public void NavigateToPMTab()
        {
            //Navigate to Process Monitoring Tab
            string monitoredComponentsPath = NavigationPane.Strings.MonitoringConfiguration
                + Mom.Test.UI.Core.Common.Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewMonitoredComponents;
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Authoring);
            navPane.SelectNode(monitoredComponentsPath, NavigationPane.NavigationTreeView.Authoring);
            navPane.SelectNode(SelectComponentTypeDialog.Strings.ProcessMonitoringTemplate, NavigationPane.NavigationTreeView.Authoring);
        }

        /// <summary>
        /// Method to open Monitors View of a process monitor
        /// </summary>
        /// <param name="methodName">Name of method calling this method</param>
        /// <param name="processMonitorName">Name of the process monitor created by template</param>
        /// <returns>Monitors View pivot window</returns>
        public Maui.Core.Window OpenMonitorsViewWindow(string methodName, string processMonitorName)
        {
            Maui.Core.Window monitorsView = null;

            this.NavigateToPMTab();

            Templates.ComponentType type = Templates.ComponentType.ProcessMonitor;
            Templates searchComponent = new Templates();

            if (searchComponent.ComponentExists(type, processMonitorName))
            {
                Utilities.LogMessage(methodName + ":: Found the component in Monitored Components view");
            }
            else
            {
                Utilities.LogMessage(methodName + ":: Failed to find the component : " + processMonitorName + " in Monitored Components View");
                return monitorsView;
            }

            Maui.Core.WinControls.DataGridViewRow processMonitorRow = null;
            processMonitorRow = CoreManager.MomConsole.ViewPane.Grid.FindData(processMonitorName, Templates.Strings.ComponentCategoryColumnName, Core.Console.MomControls.GridControl.SearchStringMatchType.ExactMatch);
            Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);

            ViewPane processMonitorViewPane = CoreManager.MomConsole.ViewPane;

            if (processMonitorRow != null)
            {
                Utilities.LogMessage(methodName + ":: Process Monitor " + processMonitorName
                    + " found under Management Pack Templates -> Process Monitoring");
                int retry = 0;
                int maxRetry = 5;
                while(retry < maxRetry)
                {                    
                    if(processMonitorViewPane.IsVisible)
                    {
                        Utilities.TakeScreenshot("Loaded Monitored Components view");
                        processMonitorRow.AccessibleObject.Click();
                        Utilities.LogMessage(methodName + ":: Clicked on Process Monitor " + processMonitorName);
                        break;
                    }
                    else                    
                    {
                        retry++;
                        Utilities.TakeScreenshot("Loading Monitored Components view, retry " + retry);
                        Utilities.LogMessage(methodName + ":: Delay 6 seconds wait load the Monitored Components view, retry " + retry + "of" + maxRetry);
                        Sleeper.Delay(Constants.OneSecond * 6);                      
                    }
                }

                if (retry == maxRetry)
                {
                    Utilities.TakeScreenshot("Failed to load Monitored Components view even though delayed 30 seconds");
                    throw new Infra.Frmwrk.VarFail("Failed to load Monitored Components view even though delayed 30 seconds");
                }

                CoreManager.MomConsole.ExecuteContextMenu(Templates.Strings.ContextMenuViewMPObjects
                    + Core.Common.Constants.PathDelimiter
                    + Core.Console.Views.Views.Strings.HealthView, true);
                Utilities.LogMessage(methodName + ":: " + Core.Console.Views.Views.Strings.HealthView);

                //In case in select the Main Console Window instead of Monitor View Window,see bug #181286 
                CoreManager.MomConsole.Waiters.WaitForStatusReady();
                Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond * 5);


                monitorsView = GetWindowReference(Core.Console.MonitoringConfiguration.Monitors.Strings.Monitors);
                monitorsView.ScreenElement.WaitForReady();

                return monitorsView;
            }
            else
            {
                Utilities.LogMessage(methodName + ":: Failed to find process monitor instnace!");
                return monitorsView;
            }
        }

        /// <summary>
        /// Method to check the current health state of the local computer and compare to an expected value
        /// </summary>
        /// <param name="computerName">Name of computer verified with health state</param>
        /// <param name="expectedState">Expected health state</param>
        /// <param name="processMonitorName">Name of the process monitor created by template</param>
        /// <returns>bool</returns>
        public static bool VerifyProcessMonitorHealthState(string computerName, string expectedState, string processMonitorName)
        {
            bool correctState = false;

            Utilities.LogMessage("VerifySystemHealthState(...)");
            Utilities.LogMessage("Method to verify health state is the expected value.");

            string path = NavigationPane.Strings.Monitoring
                + Core.Common.Constants.PathDelimiter
                + Core.Common.Constants.UITestViewFolder
                + Core.Common.Constants.PathDelimiter
                + Core.Console.Views.Views.Strings.StateView;

            Core.Console.Views.State.StateView stateView = new Core.Console.Views.State.StateView();
            correctState = stateView.CheckState(path, computerName, processMonitorName, expectedState, true);

            //take screenshot before clicking clear
            Utilities.TakeScreenshot("ProcessMonitor.VerifyProcessMonitorHealthState");
            CoreManager.MomConsole.ViewPane.Find.ClickClear();
            CoreManager.MomConsole.ViewPane.ScreenElement.WaitForReady();
            return correctState;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method to get refrence to a new window based on dialog title 
        /// </summary>
        /// <param name="dialogTitle">Dialog Title for the window</param>
        /// <returns>A reference to the dialog's Window</returns>
        private static Window GetWindowReference(string dialogTitle)
        {
            Window expectedWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                expectedWindow = new Window(dialogTitle, StringMatchSyntax.WildCard);//, WindowClassNames.Dialog, Maui.Core.Utilities.StringMatchSyntax.ExactMatch, CoreManager.MomConsole.MainWindow, OneSecond * 3);
            }

            catch (Maui.Core.Dialog.Exceptions.WindowNotFoundException ex)
            {
                expectedWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 20;
                while (expectedWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        expectedWindow =
                            new Window(dialogTitle, StringMatchSyntax.WildCard);//, WindowClassNames.Dialog, Maui.Core.Utilities.StringMatchSyntax.ExactMatch, CoreManager.MomConsole.MainWindow, OneSecond * 3);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            expectedWindow,
                            Core.Common.Constants.OneSecond * 3);
                    }
                    catch (Maui.Core.Dialog.Exceptions.WindowNotFoundException)
                    {
                        Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (expectedWindow == null)
                {
                    // log the failure
                    Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                        dialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return expectedWindow;
        }

        /// <summary>
        /// Verify properties of dialog controls
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="type"></param>
        private void VerifyEditPropertyDialogControls(ProcessMonitorParameters parameters, string componentName, Templates.ComponentType type, bool isEditing)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + " :: Start");
            Utilities.LogMessage(currentMethod + " :: Editing Mode:" + isEditing);

            string operationString = currentMethod + " :: Verified";
            if (isEditing) operationString = currentMethod + " :: Edited ";

            #region Open property dialog

            Templates templates = new Templates();

            // ComponentExists method handles the navigation
            if (!templates.ComponentExists(type, componentName))
            {
                throw new ListView.Exceptions.ItemNotFoundException("could not find windows process component: '" + componentName + "'");
            }

            DataGridViewRow monitoredComponentRow = CoreManager.MomConsole.ViewPane.Grid.FindData(componentName, Core.Console.MomControls.GridControl.SearchStringMatchType.ExactMatch);
            monitoredComponentRow.AccessibleObject.Click();
            Menu propertiesMenuItem = new Menu(ContextMenuAccessMethod.ShiftF10);
            //propertiesMenuItem.WaitContextMenuWithTimeOut(Constants.DefaultContextMenuTimeout);
            propertiesMenuItem.ScreenElement.WaitForReady();
            Utilities.LogMessage(currentMethod + " :: Selecting '" + Views.Views.Strings.PropertiesContextMenu + "' menu item");
            propertiesMenuItem.ExecuteMenuItem(Views.Views.Strings.PropertiesContextMenu);

            #endregion

            #region General Tab

            TemplateGeneralPropertiesDialog generalPropertiesDialog = new TemplateGeneralPropertiesDialog(CoreManager.MomConsole);
            generalPropertiesDialog.WaitForResponse();

            // Check controls' accessibility
            this.CheckControlAccessibility(generalPropertiesDialog.Controls.TargetAndPortTextBox, "Name Textbox");
            this.CheckControlAccessibility(generalPropertiesDialog.Controls.SummaryTextBox, "Description Textbox");

            // Check or edit control values on General tab
            this.ChangeVerifyControlValue(generalPropertiesDialog.TargetAndPortText, parameters.name, isEditing, generalPropertiesDialog.Controls.TargetAndPortTextBox);
            this.ChangeVerifyControlValue(generalPropertiesDialog.SummaryText, parameters.description, isEditing, generalPropertiesDialog.Controls.SummaryTextBox);

            Utilities.LogMessage(operationString + "general tab controls.");

            #endregion

            #region Process to Monitor Tab

            // Verify process monitor configuration tab
            this.ClickTabItemByText(generalPropertiesDialog.Controls.Tab0TabControl.Tabs, Strings.ProcessMonitorTabName);
            ProcessToMonitorTabDialog processToMonitorTab = new ProcessToMonitorTabDialog(CoreManager.MomConsole);
            processToMonitorTab.WaitForResponse();

            this.CheckControlAccessibility(processToMonitorTab.Controls.ProcessMonitorRadioButton, "Process Monitor Radio Button");
            this.CheckControlAccessibility(processToMonitorTab.Controls.UnwantedProcessRadioButton, "Unwanted Process Radio Button");
            this.CheckControlAccessibility(processToMonitorTab.Controls.ProcessSearchButton, "Process Search Button");
            this.CheckControlAccessibility(processToMonitorTab.Controls.GroupSearchButton, "Group Search Button");
            this.CheckControlAccessibility(processToMonitorTab.Controls.ProcessNameTextBox, "Process Name TextBox");

            this.ChangeVerifyControlValue(processToMonitorTab.ProcessNameText, parameters.processName, isEditing, processToMonitorTab.Controls.ProcessNameTextBox);

            if (isEditing)
            {
                if (parameters.unwantedProcess)
                {
                    processToMonitorTab.ButtonEnum = ButtonEnum.UnwantedProcess;
                }

                #region Group Search Dialog Box

                ListViewItemCollection groupToSelect;

                if (parameters.groupName == null)
                {
                    throw new ArgumentNullException(currentMethod + " :: Group name cannot be null");
                }

                if (string.Compare(processToMonitorTab.GroupNameText, parameters.groupName, true) != 0)
                {
                    processToMonitorTab.ClickGroupSearch();
                    Utilities.LogMessage(currentMethod + " :: Clicked Group Search button");
                    GroupSearchDialog groupSearchDialog = new GroupSearchDialog(CoreManager.MomConsole);

                    if (parameters.filters != null)
                        groupSearchDialog.TextFilterText = parameters.filters;

                    if (parameters.MPFilter != null)
                        groupSearchDialog.MPFilterText = parameters.MPFilter;

                    groupSearchDialog.ClickSearch();

                    int retries = 0;
                    int maxRetries = 20;

                    while (groupSearchDialog.Controls.GroupsListView.Count == 0 && retries < maxRetries)
                    {
                        retries++;
                        Utilities.LogMessage(currentMethod + " :: Waiting for Group List to populate.");
                        Utilities.LogMessage(currentMethod + " :: Attempt " + retries + " of " + maxRetries);
                        Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond * 3);
                    }

                    retries = 0;
                    maxRetries = 5;
                    bool foundGroup = false;
                    groupSearchDialog.Controls.GroupsListView.WaitForResponse();
                    while (retries < maxRetries && foundGroup == false)
                    {
                        groupToSelect = groupSearchDialog.Controls.GroupsListView.FindAllByText(parameters.groupName);
                        if (groupToSelect.Count > 0)
                        {
                            groupToSelect[0].Click();
                            foundGroup = true;
                        }
                        retries++;
                        Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond * 3);
                    }
                    if (foundGroup == false)
                    {
                        Utilities.LogMessage(currentMethod + " :: Failed to find " + parameters.groupName + " in the groups list.");
                        throw new Exception(currentMethod + " :: Failed to find " + parameters.groupName + " in the groups list.");
                    }

                    groupSearchDialog.ClickOK();
                    Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
                }
                #endregion
            }
            else
            {
                if (string.Compare(processToMonitorTab.GroupNameText, parameters.groupName, true) != 0)
                {
                    throw new ArgumentException(currentMethod + ":: text '" + processToMonitorTab.ProcessNameText + "' does not match '" + parameters.groupName + "'");
                }

                if ((processToMonitorTab.ButtonEnum == ButtonEnum.UnwantedProcess) != parameters.unwantedProcess)
                {
                    throw new ArgumentException("text '" + processToMonitorTab.ButtonEnum.ToString() + "' does not match '" + parameters.unwantedProcess + "'");
                }
            }

            Utilities.LogMessage(operationString + "Process to Monitor tab controls.");

            #endregion

            #region Running Process Tab

            // Verify Running Process configuration tab
            this.ClickTabItemByText(processToMonitorTab.Controls.Tab1TabControl.Tabs, Strings.RunningProcessesTabName);
            RunningProcessesTabDialog runningProcessesTab = new RunningProcessesTabDialog(CoreManager.MomConsole);
            runningProcessesTab.WaitForResponse();

            if (!parameters.unwantedProcess)
            {
                this.CheckControlAccessibility(runningProcessesTab.Controls.NumInstancesRadioButton, "Num Instances Radio Button");
                this.CheckControlAccessibility(runningProcessesTab.Controls.DurationRadioButton, "Duration Radio Button");

                if (isEditing)
                {
                    Utilities.LogMessage(currentMethod + " :: editing " + runningProcessesTab.Controls.NumInstancesRadioButton.ButtonState + " to " + parameters.minMax);
                    if (parameters.minMax)
                    {
                        runningProcessesTab.Controls.NumInstancesRadioButton.Click();
                    }
                    else
                    {
                        runningProcessesTab.Controls.DurationRadioButton.Click();
                    }
                }
                else
                {
                    if (parameters.minMax != (runningProcessesTab.Previous == Previous.NumInstancesRadioButton))
                    {
                        throw new ArgumentException("MinMax parameter is not correct!");
                    }
                }

                if (runningProcessesTab.Controls.NumInstancesRadioButton.ButtonState == ButtonState.Checked)
                {
                    this.CheckControlAccessibility(runningProcessesTab.Controls.MinimumInstancesComboBox, "Minimum Instances Combo Box");
                    this.CheckControlAccessibility(runningProcessesTab.Controls.MaximumInstancesComboBox, "Maximum Instances Combo Box");
                    this.CheckControlAccessibility(runningProcessesTab.Controls.DurationValNumInstancesComboBox, "Duration Val Num Instances Combo Box");
                    this.CheckControlAccessibility(runningProcessesTab.Controls.DurationUnitNumInstancesComboBox, "Duration Unit Num Instances Combo Box");

                    this.ChangeVerifyControlValue(runningProcessesTab.MaximumInstancesText, parameters.numMaxInstances, isEditing, runningProcessesTab.Controls.MaximumInstancesComboBox);
                    this.ChangeVerifyControlValue(runningProcessesTab.MinimumInstancesText, parameters.numMinInstances, isEditing, runningProcessesTab.Controls.MinimumInstancesComboBox);
                    this.ChangeVerifyControlValue(runningProcessesTab.DurationValNumInstancesText, parameters.instanceDuration, isEditing, runningProcessesTab.Controls.DurationValNumInstancesComboBox);
                    this.ChangeVerifyControlValue(runningProcessesTab.DurationUnitNumInstancesText, parameters.instanceDurationUnit, isEditing, runningProcessesTab.Controls.DurationUnitNumInstancesComboBox);
                }
                else
                {
                    this.CheckControlAccessibility(runningProcessesTab.Controls.DurationValRuntimeComboBox, "Duration Val Runtime Combo Box");
                    this.CheckControlAccessibility(runningProcessesTab.Controls.DurationUnitRuntimeComboBox, "Duration Unit Runtime Combo Box");

                    this.ChangeVerifyControlValue(runningProcessesTab.DurationValRuntimeText, parameters.instanceDurationUnit, isEditing, runningProcessesTab.Controls.DurationValRuntimeComboBox);
                    this.ChangeVerifyControlValue(runningProcessesTab.DurationUnitRuntimeText, parameters.instanceDuration, isEditing, runningProcessesTab.Controls.DurationUnitRuntimeComboBox);
                }
            }
            #endregion

            #region Performance Data Tab

            // Verify settings match parameters on Performance Data Tab
            this.ClickTabItemByText(runningProcessesTab.Controls.Tab2TabControl.Tabs, Strings.PerformanceDataTabName);
            WindowsService.Dialogs.PerformanceDataPageDialog performanceDataTab = new WindowsService.Dialogs.PerformanceDataPageDialog(CoreManager.MomConsole);
            performanceDataTab.WaitForResponse();

            if (!parameters.unwantedProcess)
            {
                this.CheckControlAccessibility(performanceDataTab.Controls.ProcessorTimeThresholdCheckBox, "Processor Time Threshold Check Box");
                this.CheckControlAccessibility(performanceDataTab.Controls.PrivateBytesThresholdCheckBox, "Private Bytes Threshold Check Box");

                this.ChangeVerifyControlValue(performanceDataTab.PercentProcTimeText, parameters.percentProcessorTimeThreshold, isEditing, performanceDataTab.Controls.PercentProcTimeComboBox);
                if (performanceDataTab.PrivateBytesThreshold != parameters.bytesAlert)
                {
                    if (isEditing)
                    {
                        Utilities.LogMessage(currentMethod + " :: editing " + performanceDataTab.PrivateBytesThreshold + " to " + parameters.bytesAlert);
                        performanceDataTab.PrivateBytesThreshold = parameters.bytesAlert;
                    }
                    else
                    {
                        throw new ArgumentException(currentMethod + ":: text '" + performanceDataTab.PrivateBytesThreshold + "' does not match '" + parameters.bytesAlert + "'");
                    }
                }

                if (parameters.bytesAlert)
                {
                    this.CheckControlAccessibility(performanceDataTab.Controls.NumBytesComboBox, "Num Bytes Combo Box");
                    this.ChangeVerifyControlValue(performanceDataTab.NumBytesText, parameters.numBytesThreshold, isEditing, performanceDataTab.Controls.NumBytesComboBox);
                }

                if (parameters.processorTimeAlert || parameters.bytesAlert)
                {
                    this.CheckControlAccessibility(performanceDataTab.Controls.NumSamplesComboBox, "Num Samples Combo Box");
                    this.CheckControlAccessibility(performanceDataTab.Controls.IntervalThresholdComboBox, "Interval Threshold Combo Box");
                    this.CheckControlAccessibility(performanceDataTab.Controls.IntervalUnitComboBox, "Interval Unit Combo Box");

                    this.ChangeVerifyControlValue(performanceDataTab.NumSamplesText, parameters.numSamples, isEditing, performanceDataTab.Controls.NumSamplesComboBox);
                    this.ChangeVerifyControlValue(performanceDataTab.IntervalThresholdText, parameters.counterThresholdInterval, isEditing, performanceDataTab.Controls.IntervalThresholdComboBox);
                    this.ChangeVerifyControlValue(performanceDataTab.IntervalUnitText, parameters.counterThresholdIntervalUnit, isEditing, performanceDataTab.Controls.IntervalUnitComboBox);
                }
            }
            #endregion

            #region Close dialog
            if (isEditing)
            {
                // Update data and close dialog.
                performanceDataTab.ClickOK();
            }
            else
            {
                performanceDataTab.ClickCancel();
                // TODO: Use confirm dialog to work around bug #173835
                CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.No, string.Empty, StringMatchSyntax.WildCard, MomConsoleApp.ActionIfWindowNotFound.Ignore);
            }

            CoreManager.MomConsole.WaitForDialogClose(performanceDataTab, Core.Common.Constants.OneMinute / Core.Common.Constants.OneSecond);
            #endregion

            Utilities.LogMessage(currentMethod + " :: End");
        }

        /// <summary>
        /// Change or edit control's value
        /// </summary>
        /// <param name="controlValue">Control's property value</param>
        /// <param name="expectedValue">expected value</param>
        /// <param name="isEditing">Editing or not</param>
        /// <param name="controlName">Control's name</param>
        private void ChangeVerifyControlValue(string controlValue, string expectedValue, bool isEditing, Maui.Core.WinControls.Control controlName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            if (String.Compare(controlValue, expectedValue, true) != 0)
            {
                if (isEditing)
                {
                    Utilities.LogMessage(currentMethod + " :: editing " + controlValue + " to " + expectedValue);

                    if (controlName is Maui.Core.WinControls.TextBox)
                    {
                        Utilities.LogMessage(currentMethod + " :: Type is TextBox.");
                        ((Maui.Core.WinControls.TextBox)controlName).Text = expectedValue;
                    }
                    else if (controlName is Maui.Core.WinControls.EditComboBox)
                    {
                        Utilities.LogMessage(currentMethod + " :: Type is EditComboBox.");
                        ((Maui.Core.WinControls.EditComboBox)controlName).Text = expectedValue;
                    }
                    else if (controlName is Maui.Core.WinControls.ComboBox)
                    {
                        Utilities.LogMessage(currentMethod + " :: Type is ComboBox.");
                        ((Maui.Core.WinControls.ComboBox)controlName).SelectByText(expectedValue);
                    }
                    else if (controlName is Maui.Core.WinControls.CheckBox)
                    {
                        Utilities.LogMessage(currentMethod + " :: Type is CheckBox.");
                        ((Maui.Core.WinControls.CheckBox)controlName).Checked = true;
                    }
                    else if (controlName is Maui.Core.WinControls.RadioButton)
                    {
                        Utilities.LogMessage(currentMethod + " :: Type is RadioButton.");
                        ((Maui.Core.WinControls.RadioButton)controlName).Click();
                    }
                    else
                    {
                        controlValue = expectedValue;
                    }
                }
                else
                {
                    throw new ArgumentException(currentMethod + ":: text '" + controlValue + "' does not match '" + expectedValue + "'");
                }
            }
        }

        /// <summary>
        /// Check Control Accessibility
        /// </summary>
        /// <param name="control">Control instance</param>
        /// <param name="name">Control's friendly name</param>
        private void CheckControlAccessibility(Control control, string name)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + " :: Checking accessibility of control '" + name + "'.");
            if (!control.IsEnabled)
            {
                throw new ComboBox.Exceptions.ControlIsDisabledException(name + " is disabled");
            }
        }

        /// <summary>
        /// Click specified tab item by text
        /// </summary>
        /// <param name="tabs">Tab collection</param>
        /// <param name="tabText">item text</param>
        private void ClickTabItemByText(TabControlTabCollection tabs, string tabText)
        {
            int tabIndex = Utilities.GetTabIndexByText(tabs, tabText);
            if (tabs.Count > 0 && tabs[tabIndex] != null)
            {
                tabs[tabIndex].Click();
            }
            else
            {
                throw new Maui.Core.WinControls.TabControl.Exceptions.TabNotFoundException("Could not find specified tab control. Tabs count=" + tabs.Count);
            }
        }

        #endregion

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for process monitoring dialogs
        /// </summary>
        /// <history> 	
        ///   [v-bruce]  29Apr10: Added resource strings for process monitoring dialogs
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Process to Monitor" tab control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProcessMonitorTabName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Running Processes" tab control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunningProcessesTabName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Performance Data" tab control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPerformanceDataTabName;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Process to Monitor" tab control translated resource string
            /// </summary>
            /// <history>
            /// 	[v-brucec] 29APR10 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProcessMonitorTabName
            {
                get
                {
                    if ((cachedProcessMonitorTabName == null))
                    {
                        cachedProcessMonitorTabName = Utilities.GetUIPageReferenceTabName(ManagementPackConstants.GUIDSystemCenterProcessMonitoringLibraryMP,
                                                                ManagementPackConstants.ProcessMonitorPageSet,
                                                                ManagementPackConstants.ProcessMonitorTabGroupProcess,
                                                                ManagementPackConstants.ProcessMonitorTabGroupProcessName);
                    }

                    return cachedProcessMonitorTabName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Service Details" tab control translated resource string
            /// </summary>
            /// <history>
            /// 	[v-brucec] 29APR10 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunningProcessesTabName
            {
                get
                {
                    if ((cachedRunningProcessesTabName == null))
                    {
                        cachedRunningProcessesTabName = Utilities.GetUIPageReferenceTabName(ManagementPackConstants.GUIDSystemCenterProcessMonitoringLibraryMP,
                                                                ManagementPackConstants.ProcessMonitorPageSet,
                                                                ManagementPackConstants.ProcessMonitorTabRunningProcess,
                                                                ManagementPackConstants.ProcessMonitorTabRunningProcessName);
                    }

                    return cachedRunningProcessesTabName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Performance Data" tab control translated resource string
            /// </summary>
            /// <history>
            /// 	[v-brucec] 29APR10 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PerformanceDataTabName
            {
                get
                {
                    if ((cachedPerformanceDataTabName == null))
                    {
                        cachedPerformanceDataTabName = Utilities.GetUIPageReferenceTabName(ManagementPackConstants.GUIDSystemCenterProcessMonitoringLibraryMP,
                                                                ManagementPackConstants.ProcessMonitorPageSet,
                                                                ManagementPackConstants.ProcessMonitorTabPerformanceData,
                                                                ManagementPackConstants.ProcessMonitorTabPerformanceDataName);
                    }

                    return cachedPerformanceDataTabName;
                }
            }

            #endregion
        }
        #endregion

        #region ProcessMonitorParameters Class
        /// <summary>
        /// Paramters Class for ProcessMonitor constructors.
        /// </summary>
        /// <history>
        /// [bretlink] 26SEP08 Created
        /// </history>
        public class ProcessMonitorParameters
        {
            #region Private Members

            private string cachedProcessName = null;
            private string cachedProcessFriendlyName = null;
            private string cachedName = null;
            private string cachedDescription = null;
            private string cachedGroupName = null;
            private bool cachedUnwantedProcess = false;
            private string cachedFilters = null;
            private string cachedMPFilter = null;
            private bool cachedMinMax = false;
            private string cachedNumMinInstances = null;
            private string cachedNumMaxInstances = null;
            private string cachedInstanceDuration = null;
            private string cachedInstanceDurationUnit = null;
            private bool cachedProcessorTimeAlert = false;
            private string cachedPercentProcessorTimeThreshold = null;
            private bool cachedBytesAlert = false;
            private string cachedNumBytesThreshold = null;
            private string cachedCounterThresholdInterval = null;
            private string cachedCounterThresholdIntervalUnit = null;
            private string cachedNumSamples = null;
            private string cachedManagementPack = null;
            private string[] cachedWatcherNodes = null;
            private string cachedCPUMonitorName = null;
            private string cachedMemoryMonitorName = null;
            private string cachedInstanceCountMonitorName = null;
            private string cachedUnwantedMonitorName = null;
            private string cachedRuntimeMonitorName = null;
            #endregion

            #region Constructors

            /// <summary>
            /// Default Constructor - no need in ExePath etc. Inherited classes
            /// from Console set all required properties on parameter objects.
            /// </summary>
            public ProcessMonitorParameters()
            {
            }
            #endregion

            #region Properties

            /// <summary>
            /// Name of the Process to monitor
            /// </summary>
            public string processName
            {
                get
                {
                    return this.cachedProcessName;
                }
                set
                {
                    this.cachedProcessName = value;
                }
            }

            /// <summary>
            /// Friendly name of Monitored Process
            /// </summary>
            public string processFriendlyName
            {
                get
                {
                    return this.cachedProcessFriendlyName;
                }
                set
                {
                    this.cachedProcessFriendlyName = value;
                }
            }

            /// <summary>
            /// Name of Template Created
            /// </summary>
            public string name
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
            /// Description of Template Created
            /// </summary>
            public string description
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
            /// Group to monitor process on
            /// </summary>
            public string groupName
            {
                get
                {
                    return this.cachedGroupName;
                }
                set
                {
                    this.cachedGroupName = value;
                }
            }

            /// <summary>
            /// True/False for whether to alert on Unwanted Process
            /// </summary>
            public bool unwantedProcess
            {
                get
                {
                    return this.cachedUnwantedProcess;
                }
                set
                {
                    this.cachedUnwantedProcess = value;
                }
            }

            /// <summary>
            /// Group Name Search filter strings
            /// </summary>
            public string filters
            {
                get
                {
                    return this.cachedFilters;
                }
                set
                {
                    this.cachedFilters = value;
                }
            }

            /// <summary>
            /// Group Name MP Filter string
            /// </summary>
            public string MPFilter
            {
                get
                {
                    return this.cachedMPFilter;
                }
                set
                {
                    this.cachedMPFilter = value;
                }
            }

            /// <summary>
            /// True/False for whether to alert on instance range or running time
            /// </summary>
            public bool minMax
            {
                get
                {
                    return this.cachedMinMax;
                }
                set
                {
                    this.cachedMinMax = value;
                }
            }

            /// <summary>
            /// Minimum range of instances
            /// </summary>
            public string numMinInstances
            {
                get
                {
                    return this.cachedNumMinInstances;
                }
                set
                {
                    this.cachedNumMinInstances = value;
                }
            }

            /// <summary>
            /// Maximum range of instances
            /// </summary>
            public string numMaxInstances
            {
                get
                {
                    return this.cachedNumMaxInstances;
                }
                set
                {
                    this.cachedNumMaxInstances = value;
                }
            }

            /// <summary>
            /// Duration of instance runtime
            /// </summary>
            public string instanceDuration
            {
                get
                {
                    return this.cachedInstanceDuration;
                }
                set
                {
                    this.cachedInstanceDuration = value;
                }
            }

            /// <summary>
            /// Unit used for prorcess duration value
            /// </summary>
            public string instanceDurationUnit
            {
                get
                {
                    return this.cachedInstanceDurationUnit;
                }
                set
                {
                    this.cachedInstanceDurationUnit = value;
                }
            }

            /// <summary>
            /// True/False for whether to alert on processor time percentage
            /// </summary>
            public bool processorTimeAlert
            {
                get
                {
                    return this.cachedProcessorTimeAlert;
                }
                set
                {
                    this.cachedProcessorTimeAlert = value;
                }
            }

            /// <summary>
            /// Threshold for percent processor time alert
            /// </summary>
            public string percentProcessorTimeThreshold
            {
                get
                {
                    return this.cachedPercentProcessorTimeThreshold;
                }
                set
                {
                    this.cachedPercentProcessorTimeThreshold = value;
                }
            }

            /// <summary>
            /// True/False for whether to alert on number of private bytes
            /// </summary>
            public bool bytesAlert
            {
                get
                {
                    return this.cachedBytesAlert;
                }
                set
                {
                    this.cachedBytesAlert = value;
                }
            }

            /// <summary>
            /// Threshold for Private Bytes alert
            /// </summary>
            public string numBytesThreshold
            {
                get
                {
                    return this.cachedNumBytesThreshold;
                }
                set
                {
                    this.cachedNumBytesThreshold = value;
                }
            }

            /// <summary>
            /// Interval for Performance Counter collection
            /// </summary>
            public string counterThresholdInterval
            {
                get
                {
                    return this.cachedCounterThresholdInterval;
                }
                set
                {
                    this.cachedCounterThresholdInterval = value;
                }
            }

            /// <summary>
            /// Unit for Perf Counter Interval
            /// </summary>
            public string counterThresholdIntervalUnit
            {
                get
                {
                    return this.cachedCounterThresholdIntervalUnit;
                }
                set
                {
                    this.cachedCounterThresholdIntervalUnit = value;
                }
            }

            /// <summary>
            /// Number of samples to compare against threshold values
            /// </summary>
            public string numSamples
            {
                get
                {
                    return this.cachedNumSamples;
                }
                set
                {
                    this.cachedNumSamples = value;
                }
            }

            /// <summary>
            /// Management Pack to store Template in
            /// </summary>
            public string managementPack
            {
                get
                {
                    return this.cachedManagementPack;
                }
                set
                {
                    this.cachedManagementPack = value;
                }
            }

            /// <summary>
            /// array of watcher nodes to select
            /// </summary>
            public string[] watcherNodes
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
            /// monitor name of CPU Usage Monitor
            /// </summary>
            public string CPUMonitorName
            {
                get
                {
                    return this.cachedCPUMonitorName;
                }

                set
                {
                    this.cachedCPUMonitorName = value;
                }
            }

            /// <summary>
            /// monitor name of Memory Usage Monitor
            /// </summary>
            public string memoryMonitorName
            {
                get
                {
                    return this.cachedMemoryMonitorName;
                }

                set
                {
                    this.cachedMemoryMonitorName = value;
                }
            }

            /// <summary>
            /// monitor name of Instance Count Monitor
            /// </summary>
            public string instanceCountMonitorName
            {
                get
                {
                    return this.cachedInstanceCountMonitorName;
                }

                set
                {
                    this.cachedInstanceCountMonitorName = value;
                }
            }

            /// <summary>
            /// monitor name of Unwanted Process Monitor
            /// </summary>
            public string unwantedMonitorName
            {
                get
                {
                    return this.cachedUnwantedMonitorName;
                }

                set
                {
                    this.cachedUnwantedMonitorName = value;
                }
            }

            /// <summary>
            /// monitor name of Process Runtime Monitor
            /// </summary>
            public string runtimeMonitorName
            {
                get
                {
                    return this.cachedRuntimeMonitorName;
                }

                set
                {
                    this.cachedRuntimeMonitorName = value;
                }
            }

            #endregion
        }
        #endregion
    }
}