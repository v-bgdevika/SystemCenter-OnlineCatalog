// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DiagnosticAndRecovery.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	Diagnostic And Recovery Base Class.
// </summary>
// <history>
// 	[Sunsingh] 28-Aug-08   Created
//  [v-eachu]  09-Nov-09   Add method to verify if Diagnostic and Recovery task can run automatically                
// </history>
// ---------------------------------------------------------------------------
#region Using directives
using Maui.Core;
using Maui.Core.WinControls;
using Maui.Core.Utilities;
using System.ComponentModel;
using System;
using System.Collections;
using Mom.Test.UI.Core.Console;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.Console.MonitoringConfiguration.DiagnosticAndRecovery;
using Mom.Test.UI.Core.Console.MonitoringConfiguration.DiagnosticAndRecovery.Dialogs;
using Mom.Test.UI.Core.Console.Views.HealthConfiguration;
using Mom.Test.UI.Core.Console.MomControls;
using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
using Microsoft.EnterpriseManagement.Configuration;
using Mom.Test.UI.Core.Console.Views;

#endregion

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.DiagnosticAndRecovery
{
    /// <summary>
    /// Class to add general methods for DiagnosticAndRecovery
    /// </summary>
    /// <history> 	
    ///  [sunsingh]  Created 07/29/08
    /// </history>
    public class DiagnosticAndRecovery
    {
        /// <summary>
        ///  Private Time Constant Method
        /// </summary>
        #region Constants
        private const int OneSecond = Constants.OneSecond;
        #endregion

        #region Private Members
        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp;


        #endregion

        #region Enumerators section

        #endregion	// Enumerators section

        #region Constructor
        /// <summary>
        /// Run As DiagnosticAndRecovery constructor.
        /// </summary>
        public DiagnosticAndRecovery()
        {
            this.consoleApp = CoreManager.MomConsole;
        }
        #endregion

        #region Properties


        #endregion

        #region Public Methods

        /// <summary>
        ///  Method to verify the parameter value
        /// </summary>
        /// <param name="parameters">DiagnosticAndRecoveryParameters</param>
        /// <exception cref="System.ArgumentNullException">System.ArgumentNullException</exception>
        /// <history>
        /// [sunsingh] 31july08 - Created           
        /// </history>

        private void VerifyInputParameters(DiagnosticAndRecoveryParameters parameters)
        {

            if (parameters.FileName == null)
                throw new System.ArgumentNullException("Filename can not be null");
            if (parameters.FilePath == null)
                throw new System.ArgumentNullException("FilePath can not be null");
            if (parameters.Name == null)
                throw new System.ArgumentNullException("Name can not be null");
            if (parameters.Script == null)
                throw new System.ArgumentNullException("Script can not be null");
            if (parameters.Description == null)
                throw new System.ArgumentNullException("Description can not be null");


        }

        /// <summary>
        ///  Method for Navigation To Specific Monitor's Diagnostic And Recovery Tab window
        /// </summary>
        /// <param name="targetName">Target Name</param>
        /// <param name="monitorName">Monitor Name</param>
        /// <history>
        /// [sunsingh] 31july08 - Created
        /// [v-eachu]  27Oct09 - Updated to Allow Navigate to Diagnostic and Recovery on Monitor We Created            
        /// </history>

        public void NavigateToDiagnosticAndRecovery(string targetName, string monitorName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: Start ...");

            //select the monitoring wunderbar ,navigate to monitor view and will select the monitor from monitor view
            Core.Console.MonitoringConfiguration.Monitors monitor = new Monitors();
            monitor.LaunchMonitorPropertiesDialog(targetName, monitorName);

            // property dialog is opened, 
            // code to shift to diagonstic tab.
            MonitorPropertiesDialog generalPropertiesDialog = new MonitorPropertiesDialog(CoreManager.MomConsole);

            UISynchronization.WaitForProcessReady(generalPropertiesDialog);
            generalPropertiesDialog.WaitForResponse();

            // get a handle to DnR property dialog.
            Utilities.LogMessage(currentMethod + ":: Click tab 3 :" + currentMethod + " count " + generalPropertiesDialog.Controls.Tab0TabControl.Tabs.Count);
            TabControlTab dnrTab = new TabControlTab(generalPropertiesDialog.Controls.Tab0TabControl, MonitorPropertiesDialog.Strings.DiagnosticAndRecoveryTabTitle);
            Utilities.LogMessage(currentMethod + ":: " + MonitorPropertiesDialog.Strings.DiagnosticAndRecoveryTabTitle + dnrTab.Index);
            generalPropertiesDialog.Controls.Tab0TabControl.Tabs[dnrTab.Index].Click();
            Utilities.LogMessage(currentMethod + ":: After Click tab 3 :" + currentMethod);
        }

        /// <summary>
        ///  Method To Create a new Diagnostic And Recovery Task on specific monitor using Command or Script Task Type
        /// </summary>
        /// <param name="parameters">Diagnostic And Recovery Parameters</param>
        /// <param name="targetName">Target Name</param>
        /// <param name="monitorName">Monitor Name</param>
        /// <history>
        /// [sunsingh] 29july08 - Created 
        /// [v-eachu]  27Oct09 - Updated to Create Diagnostic and Recovery Tasks on Monitor We Created     
        /// </history>

        public void Create(DiagnosticAndRecoveryParameters parameters, string targetName, string monitorName)
        {
            #region NavigateToDiagnosticAndRecovery
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: validate input " + currentMethod);
            VerifyInputParameters(parameters);
            NavigateToDiagnosticAndRecovery(targetName, monitorName);
            #endregion

            Utilities.LogMessage(currentMethod + ":: Getting handle to DiagnosticAndRecoveryDialog :" + currentMethod);
            DiagnosticAndRecoveryDialog dnrPropertyDialog = new DiagnosticAndRecoveryDialog(CoreManager.MomConsole);

            Maui.Core.WinControls.Menu myMenuItem;
            DiagnosticAndRecoveryTaskTypeDialog taskTypeWizard = null;
            switch (parameters.ConfigurationType)
            {
                case DiagnosticAndRecoveryParameters.enumConfigrationType.Diagonostic:
                    {
                        Utilities.LogMessage(currentMethod + ":: ClickDiagnosticAddButton :" + currentMethod);
                        dnrPropertyDialog.ClickDiagnosticAdd();
                        Utilities.LogMessage(currentMethod + ":: Create menuItem  :" + currentMethod);
                        myMenuItem = new Maui.Core.WinControls.Menu();

                        Utilities.LogMessage(currentMethod + ":: Click StateTypemenuItem  :" + currentMethod);
                        switch (parameters.State)
                        {
                            case DiagnosticAndRecoveryParameters.enumState.Warning:
                                {
                                    myMenuItem.ExecuteMenuItem(DiagnosticAndRecovery.Strings.DiagnosticWarningHealthState);
                                    Utilities.LogMessage(currentMethod + ":: Successfully clicked on the  Warning State Type context menu: "
                                + DiagnosticAndRecovery.Strings.DiagnosticWarningHealthState);
                                    break;
                                }
                            case DiagnosticAndRecoveryParameters.enumState.Critical:
                                {
                                    myMenuItem.ExecuteMenuItem(DiagnosticAndRecovery.Strings.DiagnosticCriticalHealthState);
                                    Utilities.LogMessage(currentMethod + ":: Successfully clicked on the Critical State Type context menu: "
                                + DiagnosticAndRecovery.Strings.DiagnosticCriticalHealthState);
                                    break;
                                }
                        }
                        taskTypeWizard = new DiagnosticAndRecoveryTaskTypeDialog(CoreManager.MomConsole, parameters.ConfigurationType);
                        Utilities.LogMessage(currentMethod + ":: Successfully DiagnosticAndRecoveryTaskTypeDialog ");
                        //Based on type parameter select TaskType
                        switch (parameters.TaskType)
                        {
                            case DiagnosticAndRecoveryParameters.enumTaskType.CommandLine:
                                Utilities.LogMessage(currentMethod + ":: Selecting CommandLine  :" + currentMethod);

                                Utilities.LogMessage(currentMethod + ":: RunCommandTask: GUID  :" + DiagnosticAndRecoveryTaskTypeDialog.Strings.RunCommandTask);
                                taskTypeWizard.Controls.MonitorTargetTreeView.Find(DiagnosticAndRecoveryTaskTypeDialog.Strings.RunCommandTask).Click();
                                Utilities.LogMessage(currentMethod + ":: Diagnostic '" + parameters.TaskType + "'");
                                break;
                            case DiagnosticAndRecoveryParameters.enumTaskType.Script:
                                Utilities.LogMessage(currentMethod + ":: Selecting Script  :" + currentMethod);
                                Utilities.LogMessage(currentMethod + ":: ScriptTask: GUID  :" + DiagnosticAndRecoveryTaskTypeDialog.Strings.ScriptTask);
                                taskTypeWizard.Controls.MonitorTargetTreeView.Find(DiagnosticAndRecoveryTaskTypeDialog.Strings.ScriptTask).Click();
                                Utilities.LogMessage(currentMethod + ":: '" + parameters.TaskType + "'");
                                break;

                        }
                        break;
                    }
                case DiagnosticAndRecoveryParameters.enumConfigrationType.Recovery:
                    {
                        Utilities.LogMessage(currentMethod + ":: Click AddRecovery Command :" + currentMethod);
                        dnrPropertyDialog.ClickRecoveryAdd();
                        Utilities.LogMessage(currentMethod + ":: Create  context menuItem  :" + currentMethod);
                        myMenuItem = new Maui.Core.WinControls.Menu();
                        Utilities.LogMessage(currentMethod + ":: Click  State Type menuItem  :" + currentMethod);
                        switch (parameters.State)
                        {
                            case DiagnosticAndRecoveryParameters.enumState.Warning:
                                {
                                    myMenuItem.ExecuteMenuItem(DiagnosticAndRecovery.Strings.RecoveryWarningHealthState);
                                    Utilities.LogMessage(currentMethod + ":: Successfully clicked on the  Warning context menu: "
                                + DiagnosticAndRecovery.Strings.RecoveryWarningHealthState);
                                    break;
                                }
                            case DiagnosticAndRecoveryParameters.enumState.Critical:
                                {
                                    myMenuItem.ExecuteMenuItem(DiagnosticAndRecovery.Strings.RecoveryCriticalHealthState);
                                    Utilities.LogMessage(currentMethod + ":: Successfully clicked on the  Critical context menu: "
                                + DiagnosticAndRecovery.Strings.RecoveryCriticalHealthState);
                                    break;
                                }
                        }
                        taskTypeWizard = new DiagnosticAndRecoveryTaskTypeDialog(CoreManager.MomConsole, parameters.ConfigurationType);
                        Utilities.LogMessage(currentMethod + ":: Successfully DiagnosticAndRecoveryTaskTypeDialog  :" + currentMethod);
                        //Based on type parameter select TaskType
                        switch (parameters.TaskType)
                        {
                            case DiagnosticAndRecoveryParameters.enumTaskType.CommandLine:
                                Utilities.LogMessage(currentMethod + ":: Selecting CommandLine  :" + currentMethod);
                                taskTypeWizard.Controls.AdditionalSettingsTreeView.Find(DiagnosticAndRecoveryTaskTypeDialog.Strings.RunCommandTask).Click();
                                Utilities.LogMessage(currentMethod + ":: '" + parameters.TaskType + "' :" + currentMethod);
                                break;
                            case DiagnosticAndRecoveryParameters.enumTaskType.Script:
                                Utilities.LogMessage(currentMethod + ":: Selecting Script  :" + currentMethod);
                                taskTypeWizard.Controls.AdditionalSettingsTreeView.Find(DiagnosticAndRecoveryTaskTypeDialog.Strings.ScriptTask).Click();
                                Utilities.LogMessage(currentMethod + ":: '" + parameters.TaskType + "' :" + currentMethod);
                                break;
                        }
                        break;
                    }
            }
            #region Launch WizardPage and Complete it

            // get control on task type wizard
            #region TaskType Command OR Script
            if (string.IsNullOrEmpty(parameters.DestinationMP))
            {
                parameters.DestinationMP = Core.Console.ConsoleConstants.DefaultManagementPackName;
            }
            Utilities.LogMessage(currentMethod+ ":: " + parameters.DestinationMP);
            taskTypeWizard.SelectDestinationManagementPackText = parameters.DestinationMP;

            // click next to nevigate to General wizard
            int attempt = 0;
            int maxtries = 10;
            while (attempt <= maxtries)
            {
                if (taskTypeWizard.Controls.NextButton.IsEnabled)
                {
                    taskTypeWizard.ClickNext();
                    Utilities.LogMessage(currentMethod + ":: Next button is enabled - Clicked on Next button");
                    break;
                }
                else
                {
                    Utilities.LogMessage(currentMethod + ":: Next button not enabled - attemp no: " + attempt);
                    Sleeper.Delay(OneSecond);
                    attempt++;
                }
            }


            Utilities.LogMessage(currentMethod + ":: Clicked Next on General Properties Dialog for '" + parameters.ConfigurationType + "':" + currentMethod);
            #endregion

            #region General Properties
            // get control on general wizard

            DiagnosticAndRecoveryTaskGeneralDialog taskGeneralWizard = null;
            Utilities.LogMessage(currentMethod + ":: Successfully selected DiagnosticAndRecoveryTaskGeneralDialog for '" + parameters.TaskType + "' :" + currentMethod);
            // set values in name and scription field.
            //Retry logic to set Name as it sometimes takes long time to go to the next screen
            int retry = 0;
            int maxcount = 10;
            bool setName = false;
            while (setName == false && retry <= maxcount)
            {
                try
                {
                    taskGeneralWizard = new DiagnosticAndRecoveryTaskGeneralDialog(CoreManager.MomConsole, parameters.ConfigurationType);
                    Utilities.LogMessage(currentMethod + ":: Setting the name to: '" + parameters.Name + "'");
                    taskGeneralWizard.SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingText = parameters.Name;
                    setName = true;
                    Utilities.LogMessage(currentMethod + ":: Successfully set the name to: '" + taskGeneralWizard.SpecifyTheNameAndDescriptionForTheMonitorYouAreCreatingText + "'");

                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    Sleeper.Delay(OneSecond);
                    Utilities.LogMessage(currentMethod + ":: Failed to get reference to Name Text Box, lets navigate and try again." + currentMethod);
                    Utilities.TakeScreenshot("DiagnosticRecovery.Create_NameTextBox_NotFound");
                }
                retry++;
            }

            taskGeneralWizard.DescriptionOptionalText = parameters.Description;

            //First Check If RunAutomatically check box is selected

            if (parameters.RunAutomatically == false)
            {
                if (taskGeneralWizard.Controls.RunDiagnosticAutomaticallyCheckBox.ButtonState == ButtonState.Checked)
                    taskGeneralWizard.ClickRunDiagnosticAutomatically();// uncheck if already checked
            }
            else
            {
                if (taskGeneralWizard.Controls.RunDiagnosticAutomaticallyCheckBox.ButtonState != ButtonState.Checked)
                    taskGeneralWizard.ClickRunDiagnosticAutomatically(); // check 
            }
            Utilities.LogMessage(currentMethod + ":: RunAutomatically is set properly'" + currentMethod);
            //First Check if Reovery Recalculate check box is selected
            if (parameters.ConfigurationType == DiagnosticAndRecoveryParameters.enumConfigrationType.Recovery)
            {
                if (parameters.RecoveryRecalculate == false)
                {
                    if (taskGeneralWizard.Controls.RecalculateMonitorStateAfterRecoveryFinishesCheckBox.ButtonState == ButtonState.Checked)
                        taskGeneralWizard.ClickRecalculateMonitorStateAfterRecoveryFinishes();// uncheck if already checked
                }
                else
                {
                    if (taskGeneralWizard.Controls.RecalculateMonitorStateAfterRecoveryFinishesCheckBox.ButtonState != ButtonState.Checked)
                        taskGeneralWizard.ClickRecalculateMonitorStateAfterRecoveryFinishes();
                }
            }
            Utilities.LogMessage(currentMethod + ":: RecoveryRecalculate is set properly'" + currentMethod);

            attempt = 0;
            maxtries = 10;
            while (attempt <= maxtries)
            {
                if (taskGeneralWizard.Controls.NextButton.IsEnabled)
                {
                    taskGeneralWizard.ClickNext();
                    Utilities.LogMessage(currentMethod + ":: Next button is enabled - Clicked on Next button");
                    break;
                }
                else
                {
                    Utilities.LogMessage(currentMethod + ":: Next button not enabled - attemp no: " + attempt);
                    Sleeper.Delay(OneSecond);
                    attempt++;
                }
            }
            #endregion
            // get control on commandline wizard
            #region commandline or scriptdetail page
            //select command line wizard or script

            switch (parameters.TaskType)
            {
                case DiagnosticAndRecoveryParameters.enumTaskType.CommandLine:
                    {
                        DiagnosticAndRecoveryTaskCommandLineDialog taskCommandLineWizard = new DiagnosticAndRecoveryTaskCommandLineDialog(CoreManager.MomConsole, parameters.ConfigurationType);
                        taskCommandLineWizard.FullPathToFileText = parameters.FilePath;
                        taskCommandLineWizard.ParametersText = parameters.Parameters;
                        taskCommandLineWizard.ClickCreate();
                        CoreManager.MomConsole.WaitForDialogClose(taskCommandLineWizard, OneSecond * 20 / Constants.OneSecond);
                        break;
                    }
                case DiagnosticAndRecoveryParameters.enumTaskType.Script:
                    {
                        DiagnosticAndRecoveryTaskScriptDialog taskScriptWizard = new DiagnosticAndRecoveryTaskScriptDialog(CoreManager.MomConsole, parameters.ConfigurationType);
                        taskScriptWizard.FileNameText = parameters.FileName;
                        taskScriptWizard.AdditionalSettingsText = parameters.Script;
                        taskScriptWizard.ClickCreate();
                        CoreManager.MomConsole.WaitForDialogClose(taskScriptWizard, OneSecond * 20 / Constants.OneSecond);
                        break;
                    }

            }


            #endregion
            consoleApp.Waiters.WaitForStatusReady();
            Utilities.LogMessage(currentMethod + ":: Successfully closed the Wizard after creation :" + currentMethod);
            // closing the dnr window
            //new MonitorPropertiesDialog(CoreManager.MomConsole).ClickClose();
            dnrPropertyDialog.ClickClose();
            // Added From Ruhi After clicking OK wait for the wizard to close

            // If there is confirm window popping up, we need to click OK to save the creation
            try
            {
                //select Yes on the save confirmation dialog
                CoreManager.MomConsole.ConfirmChoiceDialog(
                        MomConsoleApp.ButtonCaption.Yes,
                        "",
                        StringMatchSyntax.WildCard,
                        MomConsoleApp.ActionIfWindowNotFound.Ignore);
                //Wait until cursor type changes from busy icon
                consoleApp.Waiters.WaitUntilCursorType(Maui.Core.NativeMethods.MouseCursorType.Wait, Constants.OneMinute * 4);
                Utilities.LogMessage(currentMethod + ":: Succesfully Save the DianosticAndRecovery Tasks");
            }
            catch (Window.Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage(currentMethod + ":: No confirm window pop up, just ignore");
                CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);
            }
            CoreManager.MomConsole.WaitForDialogClose(dnrPropertyDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
            #endregion
        }

        /// <summary>
        ///  Method To Launch HealthExplorer Dialog From ActionPane
        /// </summary>
        /// <param name="treeNodePath">Path to Tree Node</param>
        /// <param name="searchItem">Search Item</param>
        /// <param name="searchColumnIndex">Seacrch Column Index</param>
        /// <history> 
        /// [v-eachu] 05Nov09 - Created     
        /// </history>
        public void LaunchHealthExplorerDialogFromActionPane(string treeNodePath, string searchItem, int searchColumnIndex)
        {
            Utilities.LogMessage("LaunchHealthExplorerDialogFromActionPane:: NavigateToMonitorsView...");
            CoreManager.MomConsole.BringToForeground();

            // Select the Monitoring Configuration wunderbar
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            ViewPane viewPane = CoreManager.MomConsole.ViewPane;
            consoleApp.Waiters.WaitForStatusReady(Constants.OneMinute);

            try
            {
                // Select Monitors view
                navPane.SelectNode(treeNodePath, NavigationPane.NavigationTreeView.Monitoring);
                consoleApp.Waiters.WaitForStatusReady(Constants.OneMinute);
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage("LaunchHealthExplorerDialogFromActionPane:: Failed to get reference to ViewPane.Grid, lets navigate and try again.");
                Utilities.TakeScreenshot("LaunchHealthExplorerDialogFromActionPane.SelectComputer_GridView_NotFound");
            }

            // search the View
            Core.Console.MomControls.GridControl viewGrid = null;

            int retry = 0;
            int maxcount = 10;

            DataGridViewRow row = null;

            while (row == null && retry <= maxcount)
            {
                try
                {
                    // Need to increment retry at the beginning, in case we throw WindowNotFoundException
                    // and then the retry increment is skipped
                    retry++;

                    viewPane.Find.ClickClear();
                    UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
                    UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
                    consoleApp.Waiters.WaitForStatusReady(Constants.OneMinute);

                    int retryFind = 0;
                    int maxretry = 5;

                    while (viewPane.Find.LookForText != searchItem && retryFind <= maxretry)
                    {
                        viewPane.Find.LookForText = searchItem;
                        retryFind++;
                    }

                    viewPane.Find.WaitForResponse(Constants.OneMinute);

                    viewPane.Find.ClickFindNow();
                    UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
                    UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
                    consoleApp.Waiters.WaitForStatusReady(Constants.OneMinute);

                    viewGrid = CoreManager.MomConsole.ViewPane.Grid;
                    row = viewGrid.FindData(searchItem, searchColumnIndex);

                    Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage("LaunchHealthExplorerDialogFromActionPane:: Failed to get reference to ViewPane.Grid, lets navigate and try again.");
                    Utilities.TakeScreenshot("LaunchHealthExplorerDialogFromActionPane.LaunchComputer_GridView_NotFound");
                }
                catch (System.NullReferenceException)
                {
                    Utilities.LogMessage("LaunchHealthExplorerDialogFromActionPane:: Got a null reference, lets try again.");
                    Utilities.TakeScreenshot("LaunchHealthExplorerDialogFromActionPane.Computer_NullException");
                }
            }

            if (row != null)
            {
                viewGrid.ClickCell(row.AccessibleObject.Index, 0);
            }
            else
            {
                throw new DataGrid.Exceptions.DataGridRowNotFoundException("LaunchHealthExplorerDialogFromActionPane:: Failed to find computer Name: " + searchItem);
            }
            ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
            taskPane.ClickLink(Strings.StateActionsPane, Strings.HealthExplorer);
            Utilities.LogMessage("LaunchHealthExplorerDialogFromActionPane:: Click HealthExplorer Link");
        }

        /// <summary>
        /// Method to select the monitor item from tree view on Health Explorer dialog
        /// </summary>
        /// <param name="healthDialog">Health Explorer Dialog</param>
        /// <param name="searchedMonitorName">Searched Monitor Name</param>
        /// <history>
        ///   [v-eachu] 20Nov09 - Created
        /// </history>
        private void SelectTreeViewItem(Core.Console.Views.State.HealthExplorerDialog healthDialog, string searchedMonitorName)
        {
            string methodName = "SelectTreeViewItem::" + System.Reflection.MethodBase.GetCurrentMethod().Name;

            //Get all nodes text for the tree view
            string[] nodeName = healthDialog.Controls.HealthMonitorsForTreeView.GetAllNodesText();

            for (int i = 0; i < nodeName.Length; i++)
            {
                Utilities.LogMessage(methodName + ":: Node Text: " + nodeName[i]);
                Utilities.LogMessage(methodName + ":: Node Index: " + i.ToString());
                //Get the correct one
                if (nodeName[i].Contains(searchedMonitorName))
                {
                    healthDialog.Controls.HealthMonitorsForTreeView.SelectByIndex(i);
                    Utilities.LogMessage(searchedMonitorName + ":: Successfully select the item ");
                    break;
                }
            }

            UISynchronization.WaitForUIObjectReady(healthDialog, Core.Common.Constants.DefaultDialogTimeout);

        }

        /// <summary>
        ///  Method To Verify if Diagnostic and Recovery Task Run
        /// </summary>
        /// <param name="treeNodePath">Path to Tree Node</param>
        /// <param name="searchItem">Search Item</param>
        /// <param name="searchColumnIndex">Search Column Index</param>
        /// <param name="searchedMonitorName">Search Monitor Name</param>
        /// <history> 
        /// [v-eachu] 05Nov09 - Created     
        /// </history>
        public string VerifyTaskRun(string treeNodePath, string searchItem, int searchColumnIndex, string searchedMonitorName)
        {
            Utilities.LogMessage("VerifyTaskRun:: Started ...");

            LaunchHealthExplorerDialogFromActionPane(treeNodePath, searchItem, searchColumnIndex);
            Mom.Test.UI.Core.Console.Views.State.HealthExplorerDialog healthExplorerDialog = null;
            healthExplorerDialog = new Mom.Test.UI.Core.Console.Views.State.HealthExplorerDialog(CoreManager.MomConsole);

            //Go the State Change Events tab
            TabControlTab stateChangeTab = new TabControlTab(healthExplorerDialog.Controls.MainTabControl,
              Core.Console.Views.State.HealthExplorerDialog.Strings.StateEventChangeTabName);
            healthExplorerDialog.Controls.MainTabControl.Tabs[stateChangeTab.Index].Select();
            Utilities.LogMessage("VerifyTaskRun:: Go to the State Change Events page");

            SelectTreeViewItem(healthExplorerDialog, searchedMonitorName);
            Utilities.LogMessage("VerifyTaskRun:: Select the Node whose state had changed");

            Sleeper.Delay(Core.Common.Constants.OneSecond * 10);

            string taskRunOutputText = healthExplorerDialog.Controls.HtmlDoc.Document2.body.innerText;
            Utilities.LogMessage("VerifyTaskRun:: " + taskRunOutputText);

            healthExplorerDialog.ClickTitleBarClose();
            return taskRunOutputText;
        }

        /// <summary>
        /// Create a new Diagnostic And Recovery Task
        /// </summary>
        ///<param name="parameters">DiagnosticAndRecoveryParameters</param>
        ///<param name="targetName">Target Name</param>
        ///<param name="monitorName">Monitor Name</param>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridCellNotFoundException">DatagridcellNotFoundException</exception>         
        /// <history>
        /// [sunsingh] 29july08 - Created
        /// [v-eachu]  04Dec09 - Add parameter targetName and monitorName
        /// </history>
        public bool VerifyCreate(DiagnosticAndRecoveryParameters parameters, string targetName, string monitorName)
        {
            #region NavigateToDiagnosticAndRecovery
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            VerifyInputParameters(parameters);
            Utilities.LogMessage("VerifyCreate :: " + currentMethod);
            NavigateToDiagnosticAndRecovery(targetName, monitorName);
            #endregion

            # region Verify Diagnostic and Recovery Task

            Utilities.LogMessage("VerifyCreate :: getting control of datagrid :" + currentMethod);
            DiagnosticAndRecoveryDialog dnrPropertyDialog = new DiagnosticAndRecoveryDialog(CoreManager.MomConsole);
            Mom.Test.UI.Core.Console.MomControls.GridControl dataGrid = dnrPropertyDialog.GetDataGrid(parameters.ConfigurationType);
            Utilities.LogMessage("VerifyCreate :: Successfully got control of datagrid :" + currentMethod);


            DataGridViewRow searchNameRow = null;

            switch (parameters.ConfigurationType)
            {
                case DiagnosticAndRecoveryParameters.enumConfigrationType.Diagonostic:
                    {
                        searchNameRow = dataGrid.FindData(parameters.Name, DiagnosticAndRecoveryDialog.Strings.DiagnosticTaskNameGrid);
                        break;
                    }
                case DiagnosticAndRecoveryParameters.enumConfigrationType.Recovery:
                    {
                        searchNameRow = dataGrid.FindData(parameters.Name, DiagnosticAndRecoveryDialog.Strings.RecoveryTaskNameGrid);
                        break;
                    }
            }

            if (searchNameRow == null)
            {
                Utilities.LogMessage("VerifyCreate :: Unable to find Saved Search '" + parameters.Name + " Grid " + DiagnosticAndRecoveryDialog.Strings.RecoveryTaskNameGrid + "  :" + currentMethod);
                throw new DataGrid.Exceptions.DataGridCellNotFoundException(currentMethod);
            }

            // new MonitorPropertiesDialog(CoreManager.MomConsole).ClickClose();
            dnrPropertyDialog.ClickClose();
            CoreManager.MomConsole.WaitForDialogClose(dnrPropertyDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);

            #endregion
            return true;
        }

        /// <summary>
        /// Delete Diagnostic And Recovery Task
        /// </summary>
        /// <param name="parameters">DiagnosticAndRecoveryParameters</param>
        /// <param name="targetName">Target Name</param>
        /// <param name="monitorName">Monitor Name</param>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridCellNotFoundException">DatagridcellNotFoundException</exception>         
        /// <history>
        ///     [sunsingh] 29july08 - Created 
        ///     [v-eachu]  04Dec09 - Add parameter targetName and monitorName
        /// </history>
        public void Delete(DiagnosticAndRecoveryParameters parameters, string targetName, string monitorName)
        {
            #region NavigateToDiagnosticAndRecovery
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            VerifyInputParameters(parameters);
            NavigateToDiagnosticAndRecovery(targetName, monitorName);
            #endregion

            # region Delete Diagnostic and Recovery Task
            Utilities.LogMessage("Delete :: getting control of datagrid :" + currentMethod);
            DiagnosticAndRecoveryDialog dnrPropertyDialog = new DiagnosticAndRecoveryDialog(CoreManager.MomConsole);
            Mom.Test.UI.Core.Console.MomControls.GridControl dataGrid = dnrPropertyDialog.GetDataGrid(parameters.ConfigurationType);
            Utilities.LogMessage("Delete :: Successfully got control of datagrid :" + currentMethod);


            DataGridViewRow searchNameRow = null;
            int colIndex = 0;
            switch (parameters.ConfigurationType)
            {
                case DiagnosticAndRecoveryParameters.enumConfigrationType.Diagonostic:
                    {
                        searchNameRow = dataGrid.FindData(parameters.Name, DiagnosticAndRecoveryDialog.Strings.DiagnosticTaskNameGrid);
                        colIndex = dataGrid.GetColumnTitlePosition(DiagnosticAndRecoveryDialog.Strings.DiagnosticTaskNameGrid);
                        break;
                    }
                case DiagnosticAndRecoveryParameters.enumConfigrationType.Recovery:
                    {
                        searchNameRow = dataGrid.FindData(parameters.Name, DiagnosticAndRecoveryDialog.Strings.RecoveryTaskNameGrid);
                        colIndex = dataGrid.GetColumnTitlePosition(DiagnosticAndRecoveryDialog.Strings.RecoveryTaskNameGrid);
                        break;
                    }
            }

            if (searchNameRow == null)
            {
                Utilities.LogMessage("Delete :: Unable to find Saved Search '" + parameters.Name + " Grid " + DiagnosticAndRecoveryDialog.Strings.RecoveryTaskNameGrid + " :" + currentMethod);
                throw new DataGrid.Exceptions.DataGridCellNotFoundException(currentMethod);
            }

            Utilities.LogMessage("Delete :: Found Saved Search '" + parameters.Name + " Grid " + DiagnosticAndRecoveryDialog.Strings.DiagnosticTaskNameGrid + "  :" + currentMethod);

            searchNameRow.Cells[colIndex].AccessibleObject.Click(MouseClickType.SingleClick, MouseFlags.RightButton);

            switch (parameters.ConfigurationType)
            {
                case DiagnosticAndRecoveryParameters.enumConfigrationType.Diagonostic:
                    {
                        dnrPropertyDialog.ClickDiagonosticRemove();
                        break;
                    }
                case DiagnosticAndRecoveryParameters.enumConfigrationType.Recovery:
                    {
                        dnrPropertyDialog.ClickRecoveryRemove();
                        break;
                    }
            }
            consoleApp.Waiters.WaitForStatusReady(60000);

            //new MonitorPropertiesDialog(CoreManager.MomConsole).ClickClose();
            dnrPropertyDialog.ClickClose();
            CoreManager.MomConsole.WaitForDialogClose(dnrPropertyDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
            #endregion
        }
        /// <summary>
        /// Verify Delete Diagnostic And Recovery Task
        /// </summary>
        /// <param name="parameters">DiagnosticAndRecoveryParameters</param>
        /// <param name="targetName">Target Name</param>
        /// <param name="monitorName">Monitor Name</param>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridCellNotFoundException">DatagridcellNotFoundException</exception>         
        /// <history>
        /// [sunsingh] 29july08 - Created
        /// [v-eachu]  04Dec09 - Add paremeter targetName and monitorName
        /// </history>
        public bool VerifyDelete(DiagnosticAndRecoveryParameters parameters, string targetName, string monitorName)
        {
            bool returnValue = false;
            #region NavigateToDiagnosticAndRecovery
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            VerifyInputParameters(parameters);
            NavigateToDiagnosticAndRecovery(targetName, monitorName);
            #endregion

            # region verify Diagnostic and Recovery Task
            #endregion

            Utilities.LogMessage("VerifyDelete :: getting control of datagrid :" + currentMethod);
            DiagnosticAndRecoveryDialog dnrPropertyDialog = new DiagnosticAndRecoveryDialog(CoreManager.MomConsole);
            Mom.Test.UI.Core.Console.MomControls.GridControl dataGrid = dnrPropertyDialog.GetDataGrid(parameters.ConfigurationType);
            Utilities.LogMessage("VerifyDelete :: Successfully got control of datagrid :" + currentMethod);


            DataGridViewRow searchNameRow = null;

            switch (parameters.ConfigurationType)
            {
                case DiagnosticAndRecoveryParameters.enumConfigrationType.Diagonostic:
                    {
                        searchNameRow = dataGrid.FindData(parameters.Name, DiagnosticAndRecoveryDialog.Strings.DiagnosticTaskNameGrid);
                        break;
                    }
                case DiagnosticAndRecoveryParameters.enumConfigrationType.Recovery:
                    {
                        searchNameRow = dataGrid.FindData(parameters.Name, DiagnosticAndRecoveryDialog.Strings.RecoveryTaskNameGrid);
                        break;
                    }
            }


            if (searchNameRow == null)
            {
                Utilities.LogMessage("VerifyDelete :: Unable to find Saved Search '" + parameters.Name + " Grid " + DiagnosticAndRecoveryDialog.Strings.RecoveryTaskNameGrid + " :" + currentMethod);
                returnValue = true;
            }

            dnrPropertyDialog.ClickClose();
            CoreManager.MomConsole.WaitForDialogClose(dnrPropertyDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
            return returnValue;
        }

        #endregion

        #region Private Methods
        #endregion

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for Monitors
        /// </summary>
        /// <history> 	
        ///   [sunsingh]  30july08: created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for DiagnosticAndRecoveryTabTitle link from Properties page
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceDiagnosticAndRecoveryTabTitle =
                ";Use a template to create a new monitored component;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverviewView;templateLink.Text";
            // add resource string
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// 
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceDiagnosticWarningHealthState =
                ";Diagnostic for warning health state;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;DiagnosticForWarning";
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// 
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceRecoveryWarningHealthState =
                ";Recovery for warning health state;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;RecoveryForWarning";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// 
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceDiagnosticCriticalHealthState =
                ";Diagnostic for critical health state;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;DiagnosticForError";
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// 
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceRecoveryCriticalHealthState =
                ";Recovery for critical health state;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;RecoveryForError";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for State Actions Pane
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceStateActionsPane =
                ";State Actions;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.StateResources;ActionGroupText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for State Action Pane
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceHealthExplorer =
                ";Health Explorer for {0};ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;HealthExplorerTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Diagnostic Task Run Result
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceDiagnosticTaskRunResult =
                ";Diagnostic task ran successfully:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;DiagnosticSucceededText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Recovery Task Run Result
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceRecoveryTaskRunResult =
                ";Recovery task ran successfully:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;RecoverySucceededText";
            
            #endregion //Constants

            #region Private Members
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the DiagnosticAndRecoveryTabTitle from properties page
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiagnosticAndRecoveryTabTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// 
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiagnosticWarningHealthState;
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// 
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRecoveryWarningHealthState;
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// 
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiagnosticCriticalHealthState;
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// 
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRecoveryCriticalHealthState;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the StateAction from Action Pane
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStateActionsPane;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the HealthExplorer from Action Pane
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHealthExplorer;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Diagnostic Task Run Result
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiagnosticTaskRunResult;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Recovery Task Run Result
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRecoveryTaskRunResult;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DiagnosticAndRecoveryTabTitle link from properties page
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 3/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiagnosticAndRecoveryTabTitle
            {
                get
                {
                    if ((cachedDiagnosticAndRecoveryTabTitle == null))
                    {
                        cachedDiagnosticAndRecoveryTabTitle = CoreManager.MomConsole.GetIntlStr(ResourceDiagnosticAndRecoveryTabTitle);
                    }
                    return cachedDiagnosticAndRecoveryTabTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// 
            /// </summary>
            /// <history>
            /// 	[sunsingh] 3/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiagnosticWarningHealthState
            {
                get
                {
                    if ((cachedDiagnosticWarningHealthState == null))
                    {
                        cachedDiagnosticWarningHealthState = CoreManager.MomConsole.GetIntlStr(ResourceDiagnosticWarningHealthState);
                    }
                    return cachedDiagnosticWarningHealthState;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// 
            /// </summary>
            /// <history>
            /// 	[sunsingh] 3/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiagnosticCriticalHealthState
            {
                get
                {
                    if ((cachedDiagnosticCriticalHealthState == null))
                    {
                        cachedDiagnosticCriticalHealthState = CoreManager.MomConsole.GetIntlStr(ResourceDiagnosticCriticalHealthState);
                    }
                    return cachedDiagnosticCriticalHealthState;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// 
            /// </summary>
            /// <history>
            /// 	[sunsingh] 3/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RecoveryWarningHealthState
            {
                get
                {
                    if ((cachedRecoveryWarningHealthState == null))
                    {
                        cachedRecoveryWarningHealthState = CoreManager.MomConsole.GetIntlStr(ResourceRecoveryWarningHealthState);
                    }
                    return cachedRecoveryWarningHealthState;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// 
            /// </summary>
            /// <history>
            /// 	[sunsingh] 3/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RecoveryCriticalHealthState
            {
                get
                {
                    if ((cachedRecoveryCriticalHealthState == null))
                    {
                        cachedRecoveryCriticalHealthState = CoreManager.MomConsole.GetIntlStr(ResourceRecoveryCriticalHealthState);
                    }
                    return cachedRecoveryCriticalHealthState;
                }
            }
            #endregion

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the State Action Pane
            /// </summary>
            /// <history>
            /// 	[v-eachu] 11/2/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StateActionsPane
            {
                get
                {
                    if ((cachedStateActionsPane == null))
                    {
                        cachedStateActionsPane = CoreManager.MomConsole.GetIntlStr(ResourceStateActionsPane);
                    }
                    return cachedStateActionsPane;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HealthExplorer on State Action Pane
            /// </summary>
            /// <history>
            /// 	[v-eachu] 11/2/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HealthExplorer
            {
                get
                {
                    if ((cachedHealthExplorer == null))
                    {
                        cachedHealthExplorer = CoreManager.MomConsole.GetIntlStr(ResourceHealthExplorer).Replace("{0}", Utilities.MomServerName);
                    }
                    return cachedHealthExplorer;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DiagnosticTaskRunResult
            /// </summary>
            /// <history>
            /// 	[v-eachu] 12/17/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiagnosticTaskRunResult
            {
                get
                {
                    if ((cachedDiagnosticTaskRunResult == null))
                    {
                        cachedDiagnosticTaskRunResult = CoreManager.MomConsole.GetIntlStr(ResourceDiagnosticTaskRunResult);
                    }
                    return cachedDiagnosticTaskRunResult;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RecoveryTaskRunResult
            /// </summary>
            /// <history>
            /// 	[v-eachu] 12/17/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RecoveryTaskRunResult
            {
                get
                {
                    if ((cachedRecoveryTaskRunResult == null))
                    {
                        cachedRecoveryTaskRunResult = CoreManager.MomConsole.GetIntlStr(ResourceRecoveryTaskRunResult);
                    }
                    return cachedRecoveryTaskRunResult;
                }
            }
        }
        #endregion
        #region DiagnosticAndRecoveryParameters Class

        /// <summary>
        /// Parameters class for DiagnosticAndRecovery
        /// </summary>
        /// <history>
        /// [sunsingh] 28july2008 Created
        /// </history>
        public class DiagnosticAndRecoveryParameters
        {
            #region enum
            /// <summary>
            /// Types of ConfigrationType
            /// </summary>
            public enum enumConfigrationType
            {
                /// <summary>
                /// 
                /// </summary>
                Diagonostic,

                /// <summary>
                /// 
                /// </summary>
                Recovery,

            }
            /// <summary>
            /// Types of ConfigrationType state
            /// </summary>
            public enum enumState
            {
                /// <summary>
                /// 
                /// </summary>
                Warning,

                /// <summary>
                /// 
                /// </summary>
                Critical,

            }
            /// <summary>
            /// Types of ConfigrationType Task
            /// </summary>
            public enum enumTaskType
            {
                /// <summary>
                /// 
                /// </summary>
                CommandLine,
                /// <summary>
                /// 
                /// </summary>
                Script,

            }
            #endregion

            #region Private Members
            private string cachedName = null;
            private string cachedDescription = null;

            // private string cachedMonitorState = null;
            private string cachedDestinationMP = null;
            private string cachedFileName = null;
            private string cachedFilePath = null;
            private string cachedParameters = null;
            private string cachedScript = null;
            private enumConfigrationType cachedConfigurationType; // default to
            private enumState cachedState; // default to
            private enumTaskType cachedTaskType; // default to
            private bool cachedRunAutomatically = true;
            private bool cachedRecoveryRecalculate = true;
            #endregion

            #region Constructors
            /// <summary>
            /// Default Constructor - For The Diagnostic and Recovery Parameter Class.
            /// This Constructor requires two minium parameter to be passed
            /// </summary>
            public DiagnosticAndRecoveryParameters(enumConfigrationType configType, string name)
            {
                this.ConfigurationType = configType;
                this.Name = name;
                this.RunAutomatically = false;
                this.Script = "Testscript.cs";
                this.State = enumState.Critical;
                this.TaskType = enumTaskType.Script;
                this.RecoveryRecalculate = true;
            }
            #endregion

            #region Properties
            /// <summary>
            /// 
            /// </summary>
            public enumConfigrationType ConfigurationType
            {
                get
                {
                    return this.cachedConfigurationType;
                }

                set
                {
                    this.cachedConfigurationType = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public enumState State
            {
                get
                {
                    return this.cachedState;
                }

                set
                {
                    this.cachedState = value;
                }
            }
            /// <summary>
            /// 
            /// </summary>
            public enumTaskType TaskType
            {
                get
                {
                    return this.cachedTaskType;
                }

                set
                {
                    this.cachedTaskType = value;
                }
            }
            /// <summary>
            /// Class where the monitor is targetted
            /// </summary>
            public string FileName
            {
                get
                {
                    return this.cachedFileName;
                }

                set
                {
                    this.cachedFileName = value;
                }
            }
            /// <summary>
            /// Class where the monitor is targetted
            /// </summary>
            public string FilePath
            {
                get
                {
                    return this.cachedFilePath;
                }

                set
                {
                    this.cachedFilePath = value;
                }
            }
            /// <summary>
            /// Class where the monitor is targetted
            /// </summary>
            public string Parameters
            {
                get
                {
                    return this.cachedParameters;
                }

                set
                {
                    this.cachedParameters = value;
                }
            }
            /// <summary>
            /// Class where the monitor is targetted
            /// </summary>
            public string Script
            {
                get
                {
                    return this.cachedScript;
                }

                set
                {
                    this.cachedScript = value;
                }
            }

            /// <summary>
            /// Name of Rollup Monitor
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
            /// Description of Rollup Monitor
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
            /// Bool indicating the runs automatically
            /// </summary>
            public bool RunAutomatically
            {
                get
                {
                    return this.cachedRunAutomatically;
                }

                set
                {
                    this.cachedRunAutomatically = value;
                }
            }
            /// <summary>
            /// Bool indicating whether the 
            /// </summary>
            public bool RecoveryRecalculate
            {
                get
                {
                    return this.cachedRecoveryRecalculate;
                }
                set
                {
                    this.cachedRecoveryRecalculate = value;
                }
            }

            /// <summary>
            /// Destination Management Pack
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

            #endregion
        }

        #endregion
    }//end of class DiagnosticAndRecovery
}//end of namespace