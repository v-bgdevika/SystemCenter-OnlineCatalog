// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WindowsService.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	Windows Service Base Class.
// </summary>
// <history>
// 	[ruhim]             Created
//  [ruhim] 13-MAR-06   Adding Parameters sub class and some core methods 
//                      for Windows Service templates
//  [faizalk] 27MAR06   Change TaskPane to ActionsPane
//  [v-brucec] 11SEP09   Change NotRunningOpState, RunningOpState
// </history>
// ---------------------------------------------------------------------------
#region Using directives
using Maui.Core;
using Maui.Core.WinControls;
using Maui.Core.Utilities;
using System;
using System.ComponentModel;
using Mom.Test.UI.Core.Console;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.Console.Dialogs;
using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
using Mom.Test.UI.Core.Console.MonitoringConfiguration.WindowsService.Dialogs;
using Microsoft.EnterpriseManagement.Mom.Internal;
#endregion


namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.WindowsService
{
    /// <summary>
    /// Class to add general methods for Windows Service Monitor/Template
    /// </summary>
    /// <history> 	
    ///   [ruhim]  Created
    /// </history>
    public class WindowsService
    {
        #region Private Constants
        //Column position for the actual ServiceName in Select Windows Service dialog
        private const int actualServiceNameColPos = 1;

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
        /// cachedTargetGroupAndServiceDialog
        /// </summary>
        private TargetGroupAndServiceDialog cachedTargetGroupAndServiceDialog;

        /// <summary>
        /// cachedGroupSearchDialog
        /// </summary>
        private GroupSearchDialog cachedGroupSearchDialog;

        /// <summary>
        /// cachedSelectWindowsServiceDialog
        /// </summary>
        private SelectWindowsServiceDialog cachedSelectWindowsServiceDialog;

        /// <summary>
        /// cachedPerformanceDataDialog
        /// </summary>
        private PerformanceDataDialog cachedPerformanceDataDialog;

        /// <summary>
        /// cachedSettingsSummaryDialog 
        /// </summary>
        private SettingsSummaryDialog cachedSettingsSummaryDialog;

        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp;

        #endregion

        #region Enumerators section

        /// <summary>
        /// Types of Windows Service Template
        /// </summary>
        public enum WindowsServiceType
        {
            /// <summary>
            /// Windows Service with Shared Process
            /// </summary>
            SharedProcess,

            /// <summary>
            /// Windows Service with Standalone Process
            /// </summary>
            StandaloneProcess,
        }

        #endregion	// Enumerators section

        #region Constructor
        /// <summary>
        /// Windows Service Constructor
        /// </summary>
        public WindowsService()
        {
            this.consoleApp = CoreManager.MomConsole;
        }
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
                    this.cachedComponentTypeDialog.ScreenElement.WaitForReady();
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
                    this.cachedGeneralPropertiesDialog.ScreenElement.WaitForReady();
                    Utilities.LogMessage("Setting Focus on the General Properties Dialog was successful");
                }

                return this.cachedGeneralPropertiesDialog;
            }
        }

        /// <summary>
        /// Select TargetGroupAndServiceDialog
        /// The third screen of the Create Component wizard.
        /// </summary>
        public TargetGroupAndServiceDialog targetGroupAndServiceDialog
        {
            get
            {
                if (this.cachedTargetGroupAndServiceDialog == null)
                {
                    this.cachedTargetGroupAndServiceDialog = new TargetGroupAndServiceDialog(CoreManager.MomConsole);
                    this.cachedTargetGroupAndServiceDialog.ScreenElement.WaitForReady();
                    Utilities.LogMessage("Setting Focus on the Target Group and Service Dialog was successful");
                }
                return this.cachedTargetGroupAndServiceDialog;
            }
        }

        /// <summary>
        /// Select GroupSearchDialog
        /// The group search screen of the Create Component wizard.
        /// </summary>
        public GroupSearchDialog groupSearchDialog
        {
            get
            {
                if (this.cachedGroupSearchDialog == null)
                {
                    this.cachedGroupSearchDialog = new GroupSearchDialog(CoreManager.MomConsole);
                    this.cachedGroupSearchDialog.ScreenElement.WaitForReady();
                    Utilities.LogMessage("Setting Focus on the Group Search Dialog was successful");
                }
                return this.cachedGroupSearchDialog;
            }
        }

        /// <summary>
        /// Select SelectWindowsServiceDialog
        /// The service search screen of the Create Component wizard.
        /// </summary>
        public SelectWindowsServiceDialog selectWindowsServiceDialog
        {
            get
            {
                if (this.cachedSelectWindowsServiceDialog == null)
                {
                    this.cachedSelectWindowsServiceDialog = new SelectWindowsServiceDialog();
                    this.cachedSelectWindowsServiceDialog.ScreenElement.WaitForReady();
                    Utilities.LogMessage("Setting Focus on the Select Windows Service Dialog was successful");
                }
                return this.cachedSelectWindowsServiceDialog;
            }
        }

        /// <summary>
        /// Select PerformanceDataDialog
        /// The fourth screen of the Create Component wizard.
        /// </summary>
        public PerformanceDataDialog performanceDataDialog
        {
            get
            {
                if (this.cachedPerformanceDataDialog == null)
                {
                    this.cachedPerformanceDataDialog = new PerformanceDataDialog(CoreManager.MomConsole);
                    this.cachedPerformanceDataDialog.ScreenElement.WaitForReady();
                    Utilities.LogMessage("Setting Focus on the Performance Data Dialog was successful");
                }
                return this.cachedPerformanceDataDialog;
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
                    this.cachedSettingsSummaryDialog.ScreenElement.WaitForReady();
                    Utilities.LogMessage("Setting Focus on the Settings Summary Dialog was successful");
                }

                return this.cachedSettingsSummaryDialog;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to select a rule/monitor/task name row and bring up its context menu
        /// based on the rule/monitor/task name and the context menu item
        /// passed as parameters.
        /// </summary>
        /// <param name="columnName">Column Header Name</param>
        /// <param name="name">rule/monitor/task name to find</param>
        /// <param name="contextMenuText">Context Menu Item Text</param>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">DataGridViewRowNotFoundException</exception>
        public void ExecuteContextMenuForRow(string columnName, string name, string contextMenuText)
        {
            //Create instance of the Grid Control
            MomControls.GridControl viewGrid =
            new MomControls.GridControl(CoreManager.MomConsole,
            MomControls.GridControl.ControlIDs.ViewPaneGrid);
            if (viewGrid != null)
            {
                Utilities.LogMessage("WindowsService.ExecuteContextMenuForRow:: viewGrid found, select user roles");

                // Get the Index position of the ColumnName                   
                int colpos = viewGrid.GetColumnTitlePosition(columnName);
                Utilities.LogMessage("WindowsService.ExecuteContextMenuForRow::success getcolumntitleposition");

                //calculating the index position of the row where user role name match is found
                int rowpos = -1;
                bool rowfound = false;
                foreach (Maui.Core.WinControls.DataGridViewRow row in viewGrid.Rows)
                {
                    rowpos++;
                    foreach (Maui.Core.WinControls.DataGridViewCell cell in row.Cells)
                    {
                        if (String.Compare(cell.GetValue(), name, false) == 0)
                        {
                            //rowpos = viewGrid.Rows.IndexOf(cell.Row);//this always returns -1
                            Utilities.LogMessage("value of rowpos: " + rowpos);
                            rowfound = true;
                            break;
                        }
                    }
                    if (rowfound)
                        break;
                }
                if (rowfound == false)
                {
                    Utilities.LogMessage("WindowsService.ExecuteContextMenuForRow::"
                        + name + " not found in user role view grid");
                    throw new Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException("Name : "
                        + name + " not found in results View");
                }

                Utilities.LogMessage("WindowsService.ExecuteContextMenuForRow:: RowPosition: " + rowpos);
                Utilities.LogMessage("WindowsService.ExecuteContextMenuForRow::ColumnPosition: " + colpos);
                Utilities.LogMessage("WindowsService.ExecuteContextMenuForRow::Cell Value: " + viewGrid.GetCellValue(rowpos, colpos));
                viewGrid.ClickCell(rowpos, colpos);
                Utilities.LogMessage("WindowsService.ExecuteContextMenuForRow:: success in clicking cell");

                // Bring up the Context Menu for the Selected row
                viewGrid.SendKeys(KeyboardCodes.ShiftF10);

                Menu myUserRoleContextMenu = new Maui.Core.WinControls.Menu(Constants.OneSecond * 5);
                Utilities.LogMessage("WindowsService.ExecuteContextMenuForRow:: Constructor for Menu called");
                myUserRoleContextMenu.ExecuteMenuItem(contextMenuText);
                Utilities.LogMessage("WindowsService.ExecuteContextMenuForRow::Successfully clicked on the context menu: " + contextMenuText);

            }
            else
            {
                Utilities.LogMessage("WindowsService.ExecuteContextMenuForRow::viewGrid not found.");
            }
        }

        /// <summary>
        /// Create a new WindowsService component
        /// It adds the actual service name as the display name as well
        /// </summary>
        /// <param name="type">WindowsServiceType</param>
        /// <param name="serviceName">Name of service to be monitored</param>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [ruhim] 13MAR06 - Created        
        /// </history>
        public void CreateComponent(WindowsServiceType type, string serviceName)
        {
            WindowsServiceParameters parameters = new WindowsServiceParameters();
            parameters.type = type;
            parameters.name = serviceName;
            parameters.serviceName = serviceName;
            this.CreateComponent(parameters);
        }

        /// <summary>
        /// Create a new WindowsService component
        /// </summary>
        /// <param name="parameters">WindowsServiceParameters</param>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [ruhim] 13MAR06 - Created   
        ///     [faizalk] 27MAR06 Change TaskPane to ActionsPane
        /// </history>
        public void CreateComponent(WindowsServiceParameters parameters)
        {
            Utilities.LogMessage("WindowsService.CreateComponent::" +
                "Launch Create Component Wizard");

            #region Navigate to Wizard
            //Get Reference to Actions Pane. And select the wizard from the actions pane.
            ActionsPane actionsPane = CoreManager.MomConsole.ActionsPane;
            string monitoredComponentsPath = NavigationPane.Strings.MonitoringConfiguration
                + Mom.Test.UI.Core.Common.Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewMonitoredComponents;
            actionsPane.ClickLink(NavigationPane.WunderBarButton.MonitoringConfiguration, monitoredComponentsPath,
                ActionsPane.Strings.ActionsPaneMonitoredComponents, Templates.Strings.LaunchComponentWizardTask);

            Utilities.LogMessage("WindowsService.CreateComponent:: Selected "
                + Templates.Strings.LaunchComponentWizardTask);

            //Based on the Type parameter; Select the component Type 
            //the resource string for the profile
            string typeSelected = null;

            switch (parameters.type)
            {
                case WindowsServiceType.SharedProcess:
                    typeSelected = SelectComponentTypeDialog.Strings.WindowsServiceSharedProcessTemplate;
                    break;

                case WindowsServiceType.StandaloneProcess:
                    typeSelected = SelectComponentTypeDialog.Strings.WindowsServiceStandaloneProcessTemplate;
                    break;

                default:
                    Utilities.LogMessage("WindowsService.CreateComponent:: Type parameter: '" +
                        parameters.type + "' is invalid");
                    throw new InvalidEnumArgumentException("Invalid Type selected");
            }

            #endregion

            #region Navigate through all the screens of the Wizard

            #region Select Component Type Page

            Maui.Core.WinControls.TreeNode myNode = null;
            myNode = this.componentTypeDialog.Controls.SelectComponentTypeTreeView.Find(typeSelected);
            Utilities.LogMessage("WindowsService.CreateComponent:: Found component type");

            myNode.Select();
            Utilities.LogMessage("WindowsService.CreateComponent:: Successfully selected component type" +
                typeSelected);
            myNode.Click();
            Utilities.LogMessage("WindowsService.CreateComponent:: Successfully clicked on component type");

            this.componentTypeDialog.ScreenElement.WaitForReady();


            if (!consoleApp.Waiters.WaitForWizardNavigationItemCount(this.componentTypeDialog, 3, Core.Common.Constants.OneSecond * 30))
            {
                Utilities.LogMessage("WindowsService.CreateComponent:: NavigationItemCount not expected value");
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.componentTypeDialog.Controls.NextButton, Core.Common.Constants.OneSecond);
            Utilities.LogMessage("WindowsService.CreateComponent:: Clicking Next");
            this.componentTypeDialog.ClickNext();

            #endregion

            #region General Properties Page
            //Enter the General Properties

            Utilities.LogMessage("WindowsService.CreateComponent:: Name to be set is '" +
                parameters.name + "'");
            this.generalPropertiesDialog.NameText = parameters.name;

            int attempt = 0;
            int MaxTry = 3;

            while ((attempt < MaxTry) && !(this.generalPropertiesDialog.NameText.Equals(parameters.name)))
            //((generalPropertiesDialog.NameText = parameters.name) != 0))
            {
                Sleeper.Delay(Constants.OneSecond);
                Utilities.LogMessage("WindowsService.CreateComponent:: Failed to set Template name retry");
                attempt++;
            }

            Utilities.LogMessage("WindowsService.CreateComponent:: Set display name '" +
                this.generalPropertiesDialog.NameText + "'");


            //Trying to set the description if its null throws System.ArgumentNullException
            if (parameters.description != null)
            {
                this.generalPropertiesDialog.DescriptionText = parameters.description;
                Utilities.LogMessage("WindowsService.CreateComponent:: Set description '"
                + this.generalPropertiesDialog.DescriptionText + "'");
            }

            if (parameters.managementPack != null)
            {
                this.generalPropertiesDialog.Controls.SelectDestinationManagementPackComboBox.SelectByText(parameters.managementPack);
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.generalPropertiesDialog.Controls.NextButton, Core.Common.Constants.OneSecond);
            Utilities.LogMessage("WindowsService.CreateComponent:: Clicking Next");
            this.generalPropertiesDialog.ClickNext();

            #endregion

            #region Target Group and Service Page
            //Page 3 - Target Group and Service Page

            #region Group Search Dialog Box

            ListViewItemCollection groupToSelect;
            if (parameters.groupName == null)
            {
                throw new ArgumentNullException("WindowsService:: Group name cannot be null");
            }

            this.targetGroupAndServiceDialog.ClickGroupSearch();
            Utilities.LogMessage("WindowsService.CreateComponent:: Clicked Group Search button");
            if (parameters.filters != null)
                this.groupSearchDialog.TextFilterText = parameters.filters;

            if (parameters.MPFilter != null)
                this.groupSearchDialog.MPFilterText = parameters.MPFilter;
            

            this.groupSearchDialog.ClickSearch();

            int retries = 0;
            int maxRetries = 60;

            while (this.groupSearchDialog.Controls.GroupsListView.Count == 0 && retries < maxRetries)
            {
                retries++;
                Utilities.LogMessage("WindowsService.CreateComponent:: Waiting for Group List to populate.");
                Utilities.LogMessage("WindowsService.CreateComponent:: Attempt " + retries + " of " + maxRetries);
                Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
            }

            retries = 0;
            maxRetries = 5;
            bool foundGroup = false;
            this.groupSearchDialog.Controls.GroupsListView.WaitForResponse();
            while (retries < maxRetries && foundGroup == false)
            {
                groupToSelect = this.groupSearchDialog.Controls.GroupsListView.FindAllByText(parameters.groupName);
                if (groupToSelect.Count > 0)
                {
                    groupToSelect[0].Click();
                    foundGroup = true;
                    break;
                }
                retries++;
                Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond * 3);
            }
            if (foundGroup == false)
            {
                Utilities.LogMessage("WindowsService.CreateComponent:: Failed to find " + parameters.groupName + " in the groups list.");
                throw new Exception("WindowsService.CreateComponent:: Failed to find " + parameters.groupName + " in the groups list.");
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.groupSearchDialog.Controls.OKButton, Core.Common.Constants.OneSecond);
            this.groupSearchDialog.ClickOK();
            CoreManager.MomConsole.WaitForDialogClose(this.groupSearchDialog, Core.Common.Constants.DefaultDialogTimeout *2 / Core.Common.Constants.OneSecond);

            #endregion

            #region Automatic Service CheckBox

            if (parameters.automaticService)
            {
                Utilities.LogMessage("WindowsService.CreateComponent:: Automatic Service Selected");
                if (this.targetGroupAndServiceDialog.Controls.AutomaticServiceCheckBox.ButtonState != ButtonState.Checked)
                {
                    this.targetGroupAndServiceDialog.Controls.AutomaticServiceCheckBox.Click();
                }
                Utilities.LogMessage("WindowsService.CreateComponent:: Automatic Service check box checked");
            }

            #endregion

            #region Service Search Dialog Box

            if (parameters.browseService)
            {
                Utilities.LogMessage("WindowsService.CreateComponent:: Clicking Service Search");
                this.targetGroupAndServiceDialog.ClickServiceSearch();
                Utilities.LogMessage("WindowsService.CreateComponent:: Clicked Windows Service search button");

                bool serviceSelected = false;
                serviceSelected = CoreManager.MomConsole.SelectListViewItems(parameters.serviceName, actualServiceNameColPos, this.selectWindowsServiceDialog.Controls.ServiceNameListView, true);

                if (serviceSelected == true)
                {
                    this.selectWindowsServiceDialog.ScreenElement.WaitForReady();
                    this.selectWindowsServiceDialog.ClickOK();
                }
                else
                {
                    Utilities.LogMessage("WindowsService.CreateComponent:: Failed to select the windows service : " + parameters.serviceName);
                    throw new ListView.Exceptions.ItemNotFoundException("Failed to select the windows service in browse window");
                }
            }
            else
            {
                this.targetGroupAndServiceDialog.ServiceNameText = parameters.serviceName;
            }

            #endregion

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.targetGroupAndServiceDialog.Controls.NextButton, Core.Common.Constants.OneSecond
 / Core.Common.Constants.OneSecond);
            Utilities.LogMessage("WindowsService.CreateComponent:: Clicking Next");
            this.targetGroupAndServiceDialog.ClickNext();
            
            #endregion

            #region Performance Data Page
            //Page 5 - Performance Data
            Utilities.LogMessage("WindowsService.CreateComponent:: PerformanceData");
            this.performanceDataDialog.ScreenElement.WaitForReady();

            //% Processor Time Alert selected
            if (parameters.processorTimeAlert)
            {
                Utilities.LogMessage("WindowsService.CreateComponent:: Alert on % Processor Time selected");
                if (this.performanceDataDialog.Controls.ProcessorTimeThresholdCheckBox.ButtonState != ButtonState.Checked)
                {
                    this.performanceDataDialog.Controls.ProcessorTimeThresholdCheckBox.Click();
                }
                if (parameters.percentProcessorTimeThreshold != null)
                {
                    this.performanceDataDialog.Controls.PercentProcTimeComboBox.Text = parameters.percentProcessorTimeThreshold;
                    Utilities.LogMessage("WindowsService.CreateComponent:: % Processor Time Threshold set to " + this.performanceDataDialog.Controls.PercentProcTimeComboBox.Text);
                }
                else
                    Utilities.LogMessage("WindowsService.CreateComponent:: % Processor Time Threshold set to default");
            }
            //Private Bytes Alert selected
            if (parameters.bytesAlert)
            {
                if (this.performanceDataDialog.Controls.PrivateBytesThresholdCheckBox.ButtonState != ButtonState.Checked)
                    this.performanceDataDialog.Controls.PrivateBytesThresholdCheckBox.Click();
                Utilities.LogMessage("WindowsService.CreateComponent:: Alert on Private Bytes(MB) selected");

                if (parameters.numBytesThreshold != null)
                {
                    this.performanceDataDialog.Controls.NumBytesComboBox.Text = parameters.numBytesThreshold;
                    Utilities.LogMessage("WindowsService.CreateComponent:: Private Bytes(MB) Threshold set to " + this.performanceDataDialog.Controls.NumBytesComboBox.Text);
                }
                else
                    Utilities.LogMessage("WindowsService.CreateComponent:: Private Bytes(MB) Threshold set to default");
            }
            if (parameters.bytesAlert || parameters.processorTimeAlert)
            {
                if (parameters.numSamples != null)
                {
                    this.performanceDataDialog.Controls.NumSamplesComboBox.Text = parameters.numSamples;
                    Utilities.LogMessage("WindowsService.CreateComponent:: Number of Samples set to " + this.performanceDataDialog.Controls.NumSamplesComboBox.Text);
                }
                else
                    Utilities.LogMessage("WindowsService.CreateComponent:: Number of Samples set to default");
                if (parameters.counterThresholdInterval != null)
                {
                    this.performanceDataDialog.Controls.IntervalThresholdComboBox.Text = parameters.counterThresholdInterval;
                    Utilities.LogMessage("WindowsService.CreateComponent:: Threshold Interval set to " + this.performanceDataDialog.Controls.IntervalThresholdComboBox.Text);
                }
                if (parameters.counterThresholdIntervalUnit != null)
                {
                    this.performanceDataDialog.Controls.IntervalUnitComboBox.SelectByText(parameters.counterThresholdIntervalUnit);
                    Utilities.LogMessage("WindowsService.CreateComponent:: Threshold Interval Unit set to " + this.performanceDataDialog.Controls.IntervalUnitComboBox.Text);
                }
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.performanceDataDialog.Controls.NextButton, Core.Common.Constants.OneSecond);
            Utilities.LogMessage("WindowsService.CreateComponent:: Clicking Next");
            this.performanceDataDialog.ClickNext();

            #endregion

            #region Summary Page
            //Page 6 - Setting Summary

            Utilities.LogMessage("WindowsService.CreateComponent:: Clicking Create");
            this.settingsSummaryDialog.ScreenElement.WaitForReady();
            this.settingsSummaryDialog.ClickCreate();

            CoreManager.MomConsole.WaitForDialogClose(componentTypeDialog, Core.Common.Constants.OneMinute * 2 / Core.Common.Constants.OneSecond);

            CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();

            if (!CoreManager.MomConsole.MainWindow.Extended.IsForeground)
            {
                // Bring the mom console to foreground
                CoreManager.MomConsole.BringToForeground();
            }

            UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, Mom.Test.UI.Core.Common.Constants.DefaultDialogTimeout * 2);
            consoleApp.Waiters.WaitForStatusReady();
            Sleeper.Delay(Constants.OneSecond * 3);


            Utilities.LogMessage("WindowsService.CreateComponent:: Windows Service Monitoring Template Successfully Created!");

            #endregion
            #endregion

        }

        /// <summary>
        /// Method to delete a template created by Add Monitoring Wizard.
        /// </summary>
        public void DeleteWindowsServiceTemplate(string monitorName)
        {
            #region Navigate to the component

            Utilities.LogMessage("DeleteWindowsServiceTemplate(...)");
            Utilities.LogMessage("Method to delete Template created by running the Add Monitoring Wizard for Windows Service");

            string monitoredComponentsPath = NavigationPane.Strings.MonitoringConfiguration
                                + Mom.Test.UI.Core.Common.Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewMonitoredComponents;
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Authoring);
            navPane.SelectNode(monitoredComponentsPath, NavigationPane.NavigationTreeView.Authoring);
            navPane.SelectNode(SelectComponentTypeDialog.Strings.WindowsServiceStandaloneProcessTemplate, NavigationPane.NavigationTreeView.Authoring);
            
            consoleApp.Waiters.WaitForStatusReady();
            Templates.ComponentType type = Templates.ComponentType.WindowsServiceStandaloneProcess;

            //Verify the windows service added under Monitored Components 
            //template folder view
            Templates searchComponent = new Templates();
            if (searchComponent.ComponentExists(type, monitorName))
            {
                Utilities.LogMessage("DeleteWindowsServiceTemplate:: Found the component in Monitored Components view");
            }
            else
            {
                Utilities.LogMessage("DeleteWindowsServiceTemplate:: Failed to find the component : "
                    + monitorName
                    + "in Monitored Components View");
                throw new ListView.Exceptions.ItemNotFoundException("Failed to find the component in Monitored Components view.");
            }
            Maui.Core.WinControls.DataGridViewRow NTServiceRow = null;
            NTServiceRow = CoreManager.MomConsole.ViewPane.Grid.FindData(monitorName, Templates.Strings.ComponentCategoryColumnName, Core.Console.MomControls.GridControl.SearchStringMatchType.ExactMatch);
            
            if (NTServiceRow != null)
            {
                Utilities.LogMessage("DeleteWindowsServiceTemplate:: Windows Service Template " + monitorName
                    + " found under Management Pack Templates -> WindowsService");

                NTServiceRow.AccessibleObject.Click();

                #region Delete the Component
                ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;

                taskPane.ClickLink(ActionsPane.Strings.ActionsPaneMonitoredComponents, ActionsPane.Strings.ActionsPaneDeleteGroup);
                CoreManager.MomConsole.ConfirmChoiceDialog(true);

                #endregion
            }

            #endregion

           
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// WindowsService parameters structure.
        /// </summary>
        /// <param name="parameters">WindowsServiceParameters</param>
        /// <returns>Parameters</returns>
        /// <history>
        ///		[ruhim] 13MAR06 Created
        /// </history>
        private static WindowsServiceParameters UpdateParameters(WindowsServiceParameters parameters)
        {
            Utilities.LogMessage("WindowsService.UpdateParameters:: ");

            return parameters;
        }

        #endregion

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for windows service monitor dialogs
        /// </summary>
        /// <history> 	
        ///   [ruhim]  07Sep05: Added resource strings for windows service 
        ///                     monitor dialogs
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ComputerName environment variable
            /// </summary>        
            /// -----------------------------------------------------------------------------
            public static string ComputerName = Environment.GetEnvironmentVariable("COMPUTERNAME");

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the USERDNSDOMAIN environment variable
            /// </summary>       
            /// -----------------------------------------------------------------------------
            public static string UserDNSDomain = Environment.GetEnvironmentVariable("USERDNSDOMAIN");

            /// <summary>
            /// UI Test Group Node
            /// </summary>
            public static string UITestGroupNode = "UI Test Computer Group";

            /// <summary>
            /// UITestGroupPath
            /// </summary>
            public static string UITestGroupPath = Utilities.ManagementGroupName + "\\" + UITestGroupNode;

            /// <summary>
            /// Contains GUID for:  "Service is running" operational state
            /// </summary>
            private static Guid RunningOpStateGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName,
                                                                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                                                                    ManagementPackConstants.WindowsNTServiceStateName,
                                                                    ManagementPackConstants.MonitorTypeStateRunning);

            /// <summary>
            /// Contains GUID for:  "Service is not running" operational state
            /// </summary>
            private static Guid NotRunningOpStateGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName,
                                                                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                                                                    ManagementPackConstants.WindowsNTServiceStateName,
                                                                    ManagementPackConstants.MonitorTypeStateNotRunning);

            #endregion
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Service is running" operational state
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunningOpState;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Service is not running" operational state
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNotRunningOpState;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "General" tab control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralTabName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Service Details" tab control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceDetailsTabName;

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
            /// Exposes access to the "Service is running" operational state translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 25Aug05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunningOpState
            {
                get
                {
                    if ((cachedRunningOpState == null))
                    {
                        cachedRunningOpState = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.NTServiceMonitorGuid, RunningOpStateGuid);
                    }

                    return cachedRunningOpState;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Service is not running" operational state translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 25Aug05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotRunningOpState
            {
                get
                {
                    if ((cachedNotRunningOpState == null))
                    {
                        cachedNotRunningOpState = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.NTServiceMonitorGuid, NotRunningOpStateGuid);
                    }

                    return cachedNotRunningOpState;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "General" tab control translated resource string
            /// </summary>
            /// <history>
            /// 	[v-brucec] 27Jan10 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GeneralTabName
            {
                get
                {
                    if ((cachedGeneralTabName == null))
                    {
                        cachedGeneralTabName = Utilities.GetUIPageReferenceTabName(ManagementPackConstants.GUIDSystemCenterNTServiceLibraryMP,
                                                                ManagementPackConstants.NTServiceTemplatePageSet,
                                                                ManagementPackConstants.NTServiceTemplateTabGeneral,
                                                                ManagementPackConstants.NTServiceTemplateTabGeneralName);
                    }

                    return cachedGeneralTabName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Service Details" tab control translated resource string
            /// </summary>
            /// <history>
            /// 	[v-brucec] 27Jan10 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceDetailsTabName
            {
                get
                {
                    if ((cachedServiceDetailsTabName == null))
                    {
                        cachedServiceDetailsTabName = Utilities.GetUIPageReferenceTabName(ManagementPackConstants.GUIDSystemCenterNTServiceLibraryMP,
                                                                ManagementPackConstants.NTServiceTemplatePageSet,
                                                                ManagementPackConstants.NTServiceTemplateTabServiceDetails,
                                                                ManagementPackConstants.NTServiceTemplateTabServiceDetailsName);
                    }

                    return cachedServiceDetailsTabName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Performance Data" tab control translated resource string
            /// </summary>
            /// <history>
            /// 	[v-brucec] 27Jan10 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PerformanceDataTabName
            {
                get
                {
                    if ((cachedPerformanceDataTabName == null))
                    {
                        cachedPerformanceDataTabName = Utilities.GetUIPageReferenceTabName(ManagementPackConstants.GUIDSystemCenterNTServiceLibraryMP,
                                                                ManagementPackConstants.NTServiceTemplatePageSet,
                                                                ManagementPackConstants.NTServiceTemplateTabPerformanceData,
                                                                ManagementPackConstants.NTServiceTemplateTabPerformanceDataName);
                    }

                    return cachedPerformanceDataTabName;
                }
            }

            #endregion
        }
        #endregion

        #region WindowsServiceParameters Class
        /// <summary>
        /// Paramters Class for WindowsService constructors.
        /// </summary>
        /// <history>
        /// [bretlink] 26SEP08 Created
        /// </history>
        public class WindowsServiceParameters
        {
            #region Private Members
            private WindowsService.WindowsServiceType cachedType;
            private string cachedServiceName = null;
            private string cachedName = null;
            private string cachedDescription = null;
            private string cachedGroupName = null;
            private bool cachedAutomaticService = false;
            private string cachedFilters = null;
            private string cachedMPFilter = null;
            private bool cachedProcessorTimeAlert = false;
            private string cachedPercentProcessorTimeThreshold = null;
            private bool cachedBytesAlert = false;
            private string cachedNumBytesThreshold = null;
            private string cachedCounterThresholdInterval = null;
            private string cachedCounterThresholdIntervalUnit = null;
            private string cachedNumSamples = null;
            private string cachedManagementPack = null;
            private bool cachedBrowseService = false;
            #endregion

            #region Constructors

            /// <summary>
            /// Default Constructor - no need in ExePath etc. Inherited classes
            /// from Console set all required properties on parameter objects.
            /// </summary>
            public WindowsServiceParameters()
            {
            }
            #endregion

            #region Properties


            /// <summary>
            /// Windows Service Type
            /// </summary>
            public WindowsService.WindowsServiceType type
            {
                get
                {
                    return this.cachedType;
                }

                set
                {
                    this.cachedType = value;
                }
            }

            /// <summary>
            /// Name of the Service to monitor
            /// </summary>
            public string serviceName
            {
                get
                {
                    return this.cachedServiceName;
                }
                set
                {
                    this.cachedServiceName = value;
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
            /// True/False for whether to monitor manual/automatic service
            /// </summary>
            public bool automaticService
            {
                get
                {
                    return this.cachedAutomaticService;
                }
                set
                {
                    this.cachedAutomaticService = value;
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
            /// Boolean value indicating if you want to browse the servie name
            /// if value is false then you type in the service name
            /// </summary>
            public bool browseService
            {
                get
                {
                    return this.cachedBrowseService;
                }

                set
                {
                    this.cachedBrowseService = value;
                }
            }

            #endregion
        }
        #endregion

    } //end of class WindowsService

}//end of namespace