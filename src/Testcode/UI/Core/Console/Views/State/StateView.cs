//-------------------------------------------------------------------
// <copyright file="StateView.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   State View
// </summary>
//  <history>
//   [mbickle]   02DEC04: Created
//   [lucyra]    28APR06: Added Maintenance Mode support
//   [lucyra]    22JUN06: Updated some Maintenance Mode code  
//   [a-mujtch]  22MAY09: Added methods to monitor Distributed Application
//   [v-brucec]  08DEC09: Added some retry logic to avoid timing issue
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Views.State
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.Views.Dialogs;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Maui.Core;
    using Microsoft.EnterpriseManagement;
    using Mom.Test.UI.Core.Console.ServiceDesigner;
    
    #endregion

    #region enum MaintenanceModeState
    ///// <summary>
    ///// Enum Maintenance Mode State
    ///// </summary>
    //public enum MaintenanceModeState
    //{
    //    /// <summary>
    //    /// StartMaintenanceMode
    //    /// </summary>
    //    StartMaintenanceMode,
    //    /// <summary>
    //    /// EditMaintenanceMode
    //    /// </summary>
    //    EditMaintenanceMode,
    //    /// <summary>
    //    /// EndMaintenanceMode
    //    /// </summary>
    //    EndMaintenanceMode
    //}
    #endregion

    /// <summary>
    /// State View
    /// </summary>
    public class StateView
    {
        #region Private Member Variables

        private static bool openPersonalizeView = true;

        /// <summary>
        /// 20 minutes
        /// </summary>
        private const int STATE_CHANGE_TIME_OUT = 20;

        #endregion

        #region Private Members
        /// <summary>
        /// cachedHealthExplorerDialog
        /// </summary>
        private HealthExplorerDialog cachedHealthExplorerDialog;

        /// <summary>
        /// cachedMaintenanceModeDialog
        /// </summary>
        private MaintenanceModeDialog cachedMaintenanceModeDialog;

        /// <summary>
        /// cachedConfirmChoiceMaintenanceModeDialog
        /// </summary>
        private ConfirmChoiceMaintenanceMode cachedConfirmChoiceMaintenanceMode;

        /// <summary>
        /// State Dialog
        /// </summary>
        private StateDialog cachedStateDialog;

        #endregion

        #region Constructor
        /// <summary>
        /// State View
        /// </summary>
        public StateView()
        {
            
        }
        #endregion

        #region Properties
        /// <summary>
        /// State View Dialog
        /// </summary>
        private StateDialog StateDialogWindow
        {
            get
            {
                if (this.cachedStateDialog == null)
                {
                    this.cachedStateDialog = new StateDialog(CoreManager.MomConsole);

                    this.cachedStateDialog.ScreenElement.WaitForReady();

                }

                return this.cachedStateDialog;
            }
            set
            {
                this.cachedStateDialog = value;
            }
        }

        /// <summary>
        /// Health Explorer Dialog
        /// </summary>
        public HealthExplorerDialog HealthExplorer
        {
            get
            {
                if (this.cachedHealthExplorerDialog == null)
                {
                    this.cachedHealthExplorerDialog = new HealthExplorerDialog(CoreManager.MomConsole);
                }
                return this.cachedHealthExplorerDialog;
            }
        }

        /// <summary>
        /// Maintenance Mode Dialog
        /// </summary>
        public MaintenanceModeDialog MaintenanceMode
        {
            get
            {
                if (this.cachedMaintenanceModeDialog == null)
                {
                    this.cachedMaintenanceModeDialog = new MaintenanceModeDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("StateView:: Success getting the Maintenance Mode dialog");
                    this.cachedMaintenanceModeDialog.ScreenElement.WaitForReady();
                    this.cachedMaintenanceModeDialog.Extended.SetFocus();
                }
                return this.cachedMaintenanceModeDialog;
            }
        }

        /// <summary>
        /// Confirm Choice Maintenance Mode Dialog
        /// </summary>
        public ConfirmChoiceMaintenanceMode ConfirmChoice
        {
            get
            {
                if (this.cachedConfirmChoiceMaintenanceMode == null)
                {
                    this.cachedConfirmChoiceMaintenanceMode = new ConfirmChoiceMaintenanceMode(CoreManager.MomConsole);
                    Utilities.LogMessage("StateView:: Success getting the Confirm Choice Maintenance Mode dialog");
                    this.cachedConfirmChoiceMaintenanceMode.ScreenElement.WaitForReady();
                    this.cachedConfirmChoiceMaintenanceMode.Extended.SetFocus();
                }
                return this.cachedConfirmChoiceMaintenanceMode;
            }
        }

        #endregion

        #region Public Member Variables

        //Holds value for Maintenance Mode
        bool isMaintenanceMode = false;

        #endregion

        #region Public Methods

        #region Check State
        /// -------------------------------------------------------------------
        /// <summary>
        /// CheckState
        /// </summary>
        /// <param name="pathToStateView">The TreeNode Path to the StateView</param>
        /// <param name="machineName">Machine Name to find.</param>
        /// <param name="serviceName">Service to Check</param>
        /// <param name="state">State you want to check for (ie: Error, Success, etc)</param>
        /// <param name="waitForStateChange">true: check state right now; false: wait for state change</param>
        /// <returns>True/False</returns>
        /// -------------------------------------------------------------------
        public bool CheckState(
            string pathToStateView,
            string machineName,
            string serviceName,
            string state,
            bool waitForStateChange)
        {
            return CheckState(pathToStateView, 
                machineName, 
                serviceName, 
                state,
                waitForStateChange, 
                Mom.Test.UI.Core.Console.MomControls.GridControl.SearchStringMatchType.ContainsMatch);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// CheckState
        /// </summary>
        /// <param name="pathToStateView">The TreeNode Path to the StateView</param>
        /// <param name="machineName">Machine Name to find.</param>
        /// <param name="serviceName">Service to Check</param>
        /// <param name="state">State you want to check for (ie: Error, Success, etc)</param>
        /// <param name="waitForStateChange">true: check state right now; false: wait for state change</param>
        /// <param name="matchType">Match Type: Exact, Contains or Prefix</param>
        /// <returns>True/False</returns>
        /// -------------------------------------------------------------------
        public bool CheckState(
            string pathToStateView,
            string machineName,
            string serviceName,
            string state,
            bool waitForStateChange,
            MomControls.GridControl.SearchStringMatchType matchType)
        {
            return CheckState(pathToStateView,
                machineName,
                serviceName,
                state,
                waitForStateChange,
                Mom.Test.UI.Core.Console.MomControls.GridControl.SearchStringMatchType.ContainsMatch,
                true);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// CheckState
        /// </summary>
        /// <param name="pathToStateView">The TreeNode Path to the StateView</param>
        /// <param name="machineName">Machine Name to find.</param>
        /// <param name="serviceName">Service to Check</param>
        /// <param name="state">State you want to check for (ie: Error, Success, etc)</param>
        /// <param name="waitForStateChange">true: check state right now; false: wait for state change</param>
        /// <param name="matchType">Match Type: Exact, Contains or Prefix</param>
        /// <param name="findText">Use findbar to look for the keyword first or not</param>
        /// <returns>True/False</returns>
        /// -------------------------------------------------------------------
        public bool CheckState(
            string pathToStateView,
            string machineName,
            string serviceName,
            string state,
            bool waitForStateChange,
            MomControls.GridControl.SearchStringMatchType matchType,
            bool findText)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: machineName: " + machineName);
            Utilities.LogMessage(currentMethod + ":: serviceName: " + serviceName);
            Utilities.LogMessage(currentMethod + ":: state: " + state);
            Utilities.LogMessage(currentMethod + ":: matchType: " + matchType);
            Utilities.LogMessage(currentMethod + ":: findText: " + findText);
            Utilities.LogMessage(currentMethod + ":: waitForStateChange: " + waitForStateChange);

            DateTime startCheckTime = DateTime.Now;
            bool stateChanged = false;

            //Get State view
            MomControls.GridControl viewGrid = GetStateView(pathToStateView);
            Utilities.LogMessage(currentMethod + ":: Found State view.");

            //Look for items in find bar
            if (findText)
            {
                CoreManager.MomConsole.ViewPane.Find.LookForItem(serviceName);
                Utilities.LogMessage(currentMethod + ":: Finish looking for '" + serviceName + "' in find bar.");
            }

            do
            {
                //Refresh state view
                viewGrid.SendKeys(KeyboardCodes.F5);

                //Delay 5 seconds.
                Sleeper.Delay(Constants.OneSecond * 5);

                //Look for items in State view
                DataGridViewRow dataRow = viewGrid.FindInstanceRow(Views.Strings.StateNameColumnHeader,
                                                                    Strings.PathColumn,
                                                                    serviceName,
                                                                    machineName,
                                                                    Constants.DefaultMaxRetry,
                                                                    matchType);

                if (dataRow != null)
                {
                    Utilities.LogMessage(currentMethod + ":: Found instance: @ row: " + dataRow.AccessibleObject.Index.ToString());
                    //Check if state is changed.
                    stateChanged = CheckStateChanged(viewGrid, dataRow.AccessibleObject.Index, state);
                }
                else
                {
                    Utilities.LogMessage(currentMethod + ":: Failed to find instance. ");
                }

            } while (waitForStateChange && !stateChanged && DateTime.Now < startCheckTime.AddMinutes(STATE_CHANGE_TIME_OUT));

            Utilities.LogMessage(currentMethod + string.Format(":: StateChanged: {0}, startCheckTime: {1}, endCheckTime {2}", stateChanged, startCheckTime, DateTime.Now));
 
            return stateChanged;
        }

        public MomControls.GridControl GetStateView(string pathToStateView)
        {
            MomControls.GridControl viewGrid = null;

            CoreManager.MomConsole.NavigationPane.SelectNode(pathToStateView, NavigationPane.NavigationTreeView.Monitoring);
            viewGrid = CoreManager.MomConsole.ViewPane.Grid;
            viewGrid.WaitForRowsLoaded();

            return viewGrid;
        }

        private bool CheckStateChanged(MomControls.GridControl stateView, int rowIndex, string expectedState)
        {
            string currentMethod = Utilities.GetCallingMethodNameAndLogIt();
            bool stateChanged = false;
            try
            {
                int colposState = stateView.GetColumnTitlePosition(Strings.StateColumn);
                string state = stateView.Rows[rowIndex].Cells[colposState].GetValue();
                Utilities.LogMessage(currentMethod + ":: Current State is " + state + ", expected state is " + expectedState);

                if (String.Compare(state, expectedState, false) == 0)
                {
                    stateChanged = true;
                }
            }
            catch (NullReferenceException e)
            {
                Utilities.LogMessage(currentMethod + ":: NullReferenceException " + e);
            }
            catch (ArgumentOutOfRangeException)
            {
                //Workaround for #194275:
                //OLEDB monitor watcher computers group and Check Group displayed double under state view beforeit is not ready been monitored after it is created
                Utilities.LogMessage(currentMethod + ":: ArgumentOutOfRangeException because the Row count changed because of product issue #194275");
            }

            return stateChanged;
        }

        #endregion

        #region Monitor Distributed Application
        /// <summary>
        /// Verify Distributed Application using State View
        /// </summary>
        /// <param name="name">name of distributed application</param>
        /// <param name="component">Group component name</param>
        /// <param name="focus">Test focus</param>
        /// <returns>True if success</returns>
        public bool MonitorDistributedApplication(
            string name, 
            string component, 
            TestFocus focus)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: (...)");

            if (null == name)
            {
                throw new ArgumentNullException("Distributed Application name cannot be null");
            }

            if (null == component)
            {
                throw new ArgumentNullException("Component name cannot be null");
            }

            Utilities.LogMessage(currentMethod + ":: DA name: " + name);
            Utilities.LogMessage(currentMethod + ":: component: " + component);
            Utilities.LogMessage(currentMethod + ":: focus: " + focus.ToString());

            bool returnValue = false;
            StateDialogWindow = null;

            int maxTries = 5, tries = 0;
            while (tries++ < maxTries)
            {
                Utilities.LogMessage(currentMethod + ":: try " + tries + " of " + maxTries + " to open state view window.");
                try
                {
                    OpenView(name, Core.Console.Views.Views.Strings.OpenStateViewContextMenu);
                    CoreManager.MomConsole.Waiters.WaitForWindowForeground(StateDialogWindow, Constants.OneSecond * 2);
                    if (StateDialogWindow == null)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                catch(Exception e)
                {
                    Utilities.LogMessage(currentMethod +":: Exception throw :" + e.Message + ", waiting 15 seconds to continue.");
                    if (tries == maxTries)
                    {
                        Utilities.LogMessage(currentMethod + ":: Exception reach max times.");
                        throw e;
                    }
                    System.Threading.Thread.Sleep(Constants.OneSecond * 15); 
                }  
            }
            returnValue = FindStatusInStateView(name, component, focus);

            Utilities.LogMessage(currentMethod + ":: return value: " + returnValue.ToString());
            Utilities.LogMessage(currentMethod + ":: end");
            return returnValue;
        }
        #endregion

        #region Start Maintenance Mode

        /// <summary>
        /// Start Maintenance Mode with defaults returns True if Started MaintenanceMode Successfully
        /// </summary>
        /// <param name="pathToStateView">Path To State View</param>
        /// <param name="machineName">Fully Qualified Machine Name</param>
        /// <returns>True/False</returns>
        public bool StartMaintenanceMode(string pathToStateView, string machineName)
        {
            isMaintenanceMode = this.StartMaintenanceMode(pathToStateView, machineName, null);
            return isMaintenanceMode;
        }

        /// <summary>
        /// Start Maintenance Mode with set Comment 
        /// </summary>
        /// <param name="pathToStateView">Path To State View</param>
        /// <param name="machineName">Fully Qualified Machine Name</param>
        /// <param name="comment">Comment</param>
        /// <returns>True/False</returns>
        public bool StartMaintenanceMode(string pathToStateView, string machineName, string comment)
        {
            MaintenanceModeParameters parameters = new MaintenanceModeParameters();
            parameters.PathToView = pathToStateView;
            parameters.MachineName = machineName;

            //parameters.MaintenanceModeDuration = MaintenanceModeDuration;
            parameters.Comment = comment;
            isMaintenanceMode = this.StartMaintenanceMode(parameters);
            return isMaintenanceMode;
        }

        /// <summary>
        /// Start Maintenance Mode with parameters
        /// </summary>
        /// <param name="parameters">Parameters</param>
        /// <returns>True/False</returns>
        public bool StartMaintenanceMode(MaintenanceModeParameters parameters)
        {
            Utilities.LogMessage("StateView.StartMaintenanceMode:: machineName: " + parameters.MachineName);

            //navigate to view
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Monitoring);

            TreeNode viewNode = null;

            if (parameters.PathToView != null)
            {
                Utilities.LogMessage("StateView.StartMaintenanceMode:: Selecting View: " + parameters.PathToView);
                viewNode = navPane.SelectNode(parameters.PathToView, NavigationPane.NavigationTreeView.Monitoring);
                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);

            }
            else
            {
                Utilities.LogMessage("StateView.StartMaintenanceMode:: Attempting to use current selected node");
                viewNode = navPane.Controls.MonitoringTreeView.SelectedItem;
            }

            MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;

            bool foundInstance = false;
            int colposDisplayName = 0;
            int colposMaintenanceMode = 0;
            int colposState = 0;
            string cellValue = null;
            Maui.Core.WinControls.DataGridViewRow row = null;
            int rowCount = 0;

            if (viewGrid != null)
            {
                Utilities.LogMessage("StateView.StartMaintenanceMode:: Found State View Grid");
                rowCount = viewGrid.Rows.Count;
                Utilities.LogMessage("StateView.StartMaintenanceMode:: RowCount: " + rowCount.ToString());

                colposDisplayName = viewGrid.GetColumnTitlePosition(Views.Strings.DisplayNameColumnHeader);
                colposMaintenanceMode = viewGrid.GetColumnTitlePosition(Strings.MaintenanceModeColumn);
                colposState = viewGrid.GetColumnTitlePosition(Strings.StateColumn);

                Utilities.LogMessage("StateView.StartMaintenanceMode:: DisplayName column position:" + colposDisplayName.ToString());
                Utilities.LogMessage("StateView.StartMaintenanceMode:: MaintenanceMode column position:" + colposMaintenanceMode.ToString());
                Utilities.LogMessage("StateView.StartMaintenanceMode:: State column position:" + colposState.ToString());

                //Click the Name column header to sort by Name. By default state view sort by State, it causes timing issue when getting the row index due to the maintenance mode changed.
                viewGrid.ClickColumnHeader(Views.Strings.DisplayNameColumnHeader);
        
                //Now find row with the proper computer name and not in MM 
                row = viewGrid.FindInstanceRow(
                    Views.Strings.DisplayNameColumnHeader,
                    Strings.MaintenanceModeColumn,
                    parameters.MachineName,
                    Strings.MaintenanceModeisFalse,
                    5);

                if (row != null)
                {
                    foundInstance = true;

                }
                else
                {
                    Utilities.LogMessage("StateView.StartMaintenanceMode:: Didn't find machine specified that is not in MaintenanceMode");

                }
            }
            if (foundInstance)
            {
                Utilities.LogMessage("StateView.StartMaintenanceMode:: Found instance: @ row: " + row.AccessibleObject.Index.ToString());

                // Click on cell in grid
                viewGrid.ClickCell(row.AccessibleObject.Index, colposDisplayName);
                Utilities.LogMessage("StateView.StartMaintenanceMode:: Clicked cell");

                if (rowCount != viewGrid.Rows.Count)
                {
                    Utilities.LogMessage("StateView.StartMaintenanceMode:: Row Count changed, getting row again.");
                    Utilities.TakeScreenshot("StateView.StartMaintenanceMode.RowCountDifferent");
                    row = null;
                    row = viewGrid.FindInstanceRow(
                        Strings.NameColumn,
                        Strings.MaintenanceModeColumn,
                        parameters.MachineName,
                        Strings.MaintenanceModeisFalse,
                        1);

                    viewGrid.ClickCell(row.AccessibleObject.Index, colposDisplayName);

                }

                // Selecting MaintenanceMode->Start MaintenanceMode from the context menu
                CoreManager.MomConsole.ExecuteContextMenu(Strings.MaintenanceModeContextMenu + Constants.PathDelimiter + Strings.StartMaintenanceModeContextMenu, true);

                Utilities.LogMessage("StateView.StartMaintenanceMode:: Launching MaintenanceMode dialog...");
                LaunchStartMaintenanceModeDialog(parameters);

                int loop=0;
                while (loop++ < 5 && cellValue != Strings.MaintenanceModeisTrue)
                {
                    Sleeper.Delay(Constants.OneSecond);
                    CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.OneMinute);

                    CoreManager.MomConsole.Waiters.WaitForStatusReady();

                    // Click on MaintenanceMode cell in grid
                    viewGrid.ClickCell(row.AccessibleObject.Index, colposMaintenanceMode);

                    CoreManager.MomConsole.Refresh();
                    CoreManager.MomConsole.Waiters.WaitForStatusReady();

                    //Verify that MaintenanceMode is true
                    cellValue = viewGrid.GetCellValue(row.AccessibleObject.Index, colposMaintenanceMode).ToString();
                    Utilities.LogMessage("StateView.StartMaintenanceMode:: my cell value is: " + cellValue + "  at loop:" + loop);
                }

                if (cellValue == Strings.MaintenanceModeisTrue)
                {
                    //If got to this point, then we are in MaintenanceMode
                    isMaintenanceMode = true;
                }
            }

            if (!isMaintenanceMode)
            {

                Utilities.LogMessage("StateView.StartMaintenanceMode::  Problems checking that the row is in MM!");

            }

            return isMaintenanceMode;
        }


        /// <summary>
        /// Verify Maintenance Mode with parameters
        /// </summary>
        /// <param name="parameters">Parameters</param>
        /// <returns>True/False</returns>
        public bool VerifyMaintenanceModeAgent(MaintenanceModeParameters parameters)
        {
            Utilities.LogMessage("StateView.VerifyMaintenanceModeAgent:: machineName: " + parameters.MachineName);

            //navigate to view
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Monitoring);
            TreeNode viewNode = null;

            if (parameters.PathToView != null)
            {
                Utilities.LogMessage("StateView.VerifyMaintenanceModeAgent:: Selecting View: " + parameters.PathToView);
                viewNode = navPane.SelectNode(parameters.PathToView, NavigationPane.NavigationTreeView.Monitoring);

                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);

            }
            else
            {
                Utilities.LogMessage("StateView.VerifyMaintenanceModeAgent:: Attempting to use current selected node");
                viewNode = navPane.Controls.MonitoringTreeView.SelectedItem;

            }
            //filter view reult with parameters.MachineName, escape ui refresh timing issue
            CoreManager.MomConsole.ViewPane.Find.LookForItem(parameters.MachineName);
            MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;

            bool foundInstance = false;
            int colposName = 0;
            int colposMaintenanceMode = 0;
            int colposState = 0;
            string cellValue = null;
            Maui.Core.WinControls.DataGridViewRow row = null;
            int rowCount = 0;

            if (viewGrid != null)
            {
                Utilities.LogMessage("StateView.VerifyMaintenanceModeAgent:: Found State View Grid");
                rowCount = viewGrid.Rows.Count;
                Utilities.LogMessage("StateView.VerifyMaintenanceModeAgent:: RowCount: " + rowCount.ToString());

                colposName = viewGrid.GetColumnTitlePosition(Views.Strings.DisplayNameColumnHeader);
                colposMaintenanceMode = viewGrid.GetColumnTitlePosition(Strings.MaintenanceModeColumn);
                colposState = viewGrid.GetColumnTitlePosition(Strings.StateColumn);

                Utilities.LogMessage("StateView.VerifyMaintenanceModeAgent:: DisplayName column position:" + colposName.ToString());
                Utilities.LogMessage("StateView.VerifyMaintenanceModeAgent:: MaintenanceMode column position:" + colposMaintenanceMode.ToString());
                Utilities.LogMessage("StateView.VerifyMaintenanceModeAgent:: State column position:" + colposState.ToString());

                //Now find row with the proper computer name and in MM 
                row = viewGrid.FindInstanceRow(
                    Views.Strings.DisplayNameColumnHeader,
                    Strings.MaintenanceModeColumn,
                    parameters.MachineName,
                    Strings.MaintenanceModeisTrue,
                    5);

                if (row != null)
                {
                    foundInstance = true;

                }
                else
                {
                    Utilities.LogMessage("StateView.VerifyMaintenanceModeAgent:: Didn't find machine specified that is not in MaintenanceMode");

                }
            }
            if (foundInstance)
            {
                Utilities.LogMessage("StateView.VerifyMaintenanceModeAgent:: Found instance: @ row: " + row.AccessibleObject.Index.ToString());

                // Click on cell in grid
                viewGrid.ClickCell(row.AccessibleObject.Index, colposName);
                Utilities.LogMessage("StateView.VerifyMaintenanceModeAgent:: Clicked cell");

                if (rowCount != viewGrid.Rows.Count)
                {
                    Utilities.LogMessage("StateView.VerifyMaintenanceModeAgent:: Row Count changed, getting row again.");
                    Utilities.TakeScreenshot("StateView.VerifyMaintenanceModeAgent.RowCountDifferent");
                    row = null;
                    row = viewGrid.FindInstanceRow(
                        Strings.NameColumn,
                        Strings.MaintenanceModeColumn,
                        parameters.MachineName,
                        Strings.MaintenanceModeisTrue,
                        1);

                    viewGrid.ClickCell(row.AccessibleObject.Index, colposName);

                }
                
                CoreManager.MomConsole.Refresh();
                CoreManager.MomConsole.Waiters.WaitForStatusReady();

                //Verify that MaintenanceMode is true
                cellValue = viewGrid.GetCellValue(row.AccessibleObject.Index, colposMaintenanceMode).ToString();
                Utilities.LogMessage("StateView.VerifyMaintenanceModeAgent:: my cell value is: " + cellValue);

                if (cellValue == Strings.MaintenanceModeisTrue)
                {
                    //If got to this point, then we are in MaintenanceMode
                    isMaintenanceMode = true;
                }
            }

            if (!isMaintenanceMode)
            {

                Utilities.LogMessage("StateView.VerifyMaintenanceModeAgent::  Problems checking that the row is in MM! for node: " + parameters.PathToView);

            }

            return isMaintenanceMode;
        }


        #endregion

        #region Stop Maintenance Mode

        /// <summary>
        /// Stop Maintenance Mode returns True if Stopped MaintenanceMode Successfully
        /// </summary>
        /// <param name="parameters">Maintenance Mode Parameters</param>
        /// <returns>True/False</returns>
        public bool StopMaintenanceMode(MaintenanceModeParameters parameters)
        {
            //MaintenanceMode should be true
            isMaintenanceMode = true;
            //To avoid confusion, having another var to indicate success stopping MaintenanceMode
            bool isVarSuccess = false;

            Utilities.LogMessage("StateView.StopMaintenanceMode:: machineName: " + parameters.MachineName);
            //navigate to view
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Monitoring);
            TreeNode viewNode = null;

            if (parameters.PathToView != null)
            {
                Utilities.LogMessage("StateView.StopMaintenanceMode:: Selecting View: " + parameters.PathToView);
                viewNode = navPane.SelectNode(parameters.PathToView, NavigationPane.NavigationTreeView.Monitoring);

                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);
            }
            else
            {
                Utilities.LogMessage("StateView.StopMaintenanceMode:: Attempting to use current selected node");
                viewNode = navPane.Controls.MonitoringTreeView.SelectedItem;
            }

            MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;

            bool foundInstance = false;
            int colposDisplayName = 0;
            int colposMaintenanceMode = 0;
            int colposState = 0;
            string cellValue = null;
            Maui.Core.WinControls.DataGridViewRow row = null;

            if (viewGrid != null)
            {
                Utilities.LogMessage("StateView.StopMaintenanceMode:: Found State View Grid");

                colposDisplayName = viewGrid.GetColumnTitlePosition(Views.Strings.DisplayNameColumnHeader);
                colposMaintenanceMode = viewGrid.GetColumnTitlePosition(Strings.MaintenanceModeColumn);
                colposState = viewGrid.GetColumnTitlePosition(Strings.StateColumn);

                Utilities.LogMessage("StateView.StopMaintenanceMode:: Name column position:" + colposDisplayName.ToString());
                Utilities.LogMessage("StateView.StopMaintenanceMode:: MaintenanceMode column position:" + colposMaintenanceMode.ToString());
                Utilities.LogMessage("StateView.StopMaintenanceMode:: State column position:" + colposState.ToString());

                //Click the Name column header to sort by Name. By default state view sort by State, it causes timing issue when getting the row index due to the maintenance mode changed.
                viewGrid.ClickColumnHeader(Views.Strings.DisplayNameColumnHeader);

                row = viewGrid.FindInstanceRow(
                    Views.Strings.DisplayNameColumnHeader,
                    Strings.MaintenanceModeColumn,
                    //Strings.StateColumn,
                    parameters.MachineName,
                    Strings.MaintenanceModeisTrue,
                    //Strings.StateNotMonitored,
                    60);

                if (row != null)
                {
                    foundInstance = true;
                }
                else
                {
                    Utilities.LogMessage("StateView.StopMaintenanceMode::" +
                        "Didn't find machine specified that is in MaintenanceMode and state Not Monitored");
                }
            }
            if (foundInstance)
            {
                Utilities.LogMessage("StateView.StopMaintenanceMode:: Found instance: @ row: " + row.AccessibleObject.Index.ToString());

                // Click on cell in grid
                viewGrid.ClickCell(row.AccessibleObject.Index, colposDisplayName);
                Utilities.LogMessage("StateView.StopMaintenanceMode:: Clicked cell");

                // Selecting MaintenanceMode->Stop MaintenanceMode from the context menu
                CoreManager.MomConsole.ExecuteContextMenu(Strings.MaintenanceModeContextMenu + Constants.PathDelimiter + Strings.StopMaintenanceModeContextMenu, true);

                Utilities.LogMessage("StateView.StopMaintenanceMode:: Confirm Stop MaintenanceMode...");
                ConfirmRemoveFromMaintenanceMode(parameters);

                //CoreManager.MomConsole.ConfirmChoiceDialog(true);
                int loop = 0;
                while (loop++ < 5 && cellValue != Strings.MaintenanceModeisFalse)
                {

                    Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);

                    CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.OneMinute);


                    // Click on MaintenanceMode cell in grid
                    viewGrid.ClickCell(row.AccessibleObject.Index, colposMaintenanceMode);

                    CoreManager.MomConsole.Refresh();
                    CoreManager.MomConsole.Waiters.WaitForStatusReady();

                    //Verify that MaintenanceMode is false
                    cellValue = viewGrid.GetCellValue(row.AccessibleObject.Index, colposMaintenanceMode).ToString();
                    Utilities.LogMessage("StateView.StopMaintenanceMode:: my cell value is: " + cellValue);
                }

                if (cellValue == Strings.MaintenanceModeisFalse)
                {
                    //If got to this point, then we are in MaintenanceMode
                    isMaintenanceMode = false;
                    isVarSuccess = true;
                }
            }

            if (isMaintenanceMode)
            {
                Utilities.LogMessage("StateView.StartMaintenanceMode::  Problems launching 'Stop Maintenance Mode' context menu!");
            }

            //returning success/failure
            return isVarSuccess;

        }
        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Finds status of group component in Status View
        /// </summary>
        /// <param name="distributedApplicationName">Distributed Application name</param>
        /// <param name="component">Component name</param>
        /// <param name="focus">Test focus</param>
        /// <returns>True if success</returns>
        /// <history>
        /// [v-brucec] 08DEC09 Add Try... Catch... logic to catch exception.
        /// </history>
        private bool FindStatusInStateView(string distributedApplicationName, string component, TestFocus focus)
        {
            bool result = false;
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                Utilities.LogMessage(currentMethod + ":: start");
                Utilities.LogMessage(currentMethod + ":: Finding State Dialog");
                Utilities.LogMessage(currentMethod + ":: Finding Grid in State Dialog");

                Sleeper.Delay(Constants.DefaultDialogTimeout);
                StateDialog stateDialog = this.StateDialogWindow;
                CoreManager.MomConsole.Waiters.WaitForWindowReady(stateDialog, Constants.OneMinute);
                Core.Console.MomControls.GridControl stateGrid = stateDialog.Grid;

                #region Personalize Columns

                try
                {
                    int maxTries = 5, tries = 0;
                    while(tries++<maxTries && stateGrid==null)
                    {
                        Sleeper.Delay(Constants.OneSecond * 2);
                        stateGrid = stateDialog.Grid;
                        Utilities.LogMessage(currentMethod + ":: retry "+tries +" of "+maxTries+" to find grid.");
                    }

                    if (stateGrid != null)
                    {
                        Sleeper.Delay(Constants.OneSecond * 5);

                        if ((stateGrid.Rows != null) && (stateGrid.Rows.Count > 0) && (stateGrid.Rows[0].AccessibleObject != null))
                        {
                            Utilities.LogMessage(currentMethod + ":: Try to click first row of state grid");
                            stateGrid.Rows[0].AccessibleObject.Click();
                        }
                        else
                        {
                            throw new Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException(currentMethod + ":: Failed to find data of grid view in 'State' view.");
                        }
                    }
                    else
                    {
                        throw new Maui.GlobalExceptions.MauiException(currentMethod + ":: Failed to find grid view in 'State' view.");
                    }

                    if (openPersonalizeView)
                    {
                        Utilities.LogMessage(currentMethod + ":: Launch personalize view settings");
                        stateDialog.WaitForResponse();

                        new Menu(ContextMenuAccessMethod.ShiftF10).ExecuteMenuItem(Core.Console.Views.Views.Strings.PersonalizeContextMenu);
                        Mom.Test.UI.Core.Console.Views.Dialogs.PersonalizeViewDialog PersonalizeTaskViewDialog = new Mom.Test.UI.Core.Console.Views.Dialogs.PersonalizeViewDialog(CoreManager.MomConsole);
                        CoreManager.MomConsole.Waiters.WaitForWindowReady(PersonalizeTaskViewDialog, Constants.OneMinute);
                        Utilities.LogMessage(currentMethod + ":: Personalize opened.");

                        #region For reducing the executing time
                        CheckedListBox.ListBoxItemCollection listCollection = PersonalizeTaskViewDialog.Controls.ColumnsToDisplayCheckBox.Items;
                        string listItemText = "";
                        PersonalizeTaskViewDialog.SendKeys(KeyboardCodes.Home);
                        foreach (CheckedListBoxItem listItem in listCollection)
                        {
                            listItemText = listItem.Text;
                            if (listItemText == component || StateView.Strings.StateColumn == listItemText ||
                               StateView.Strings.MaintenanceModeColumn == listItemText || StateView.Strings.NameColumn == listItemText ||
                               StateView.Strings.PathColumn == listItemText)
                            {
                                listItem.Checked = true;
                            }
                            else
                            {
                                listItem.Checked = false;
                            }
                            PersonalizeTaskViewDialog.SendKeys(KeyboardCodes.DownArrow);
                        }
                        #endregion
                        Utilities.TakeScreenshot(currentMethod + "_Personalize");

                        CoreManager.MomConsole.Waiters.WaitForButtonEnabled(PersonalizeTaskViewDialog.Controls.OKButton, Constants.OneSecond * 5);
                        Utilities.LogMessage(currentMethod + ":: Try to click button OK.");
                        PersonalizeTaskViewDialog.ClickOK();
                        Utilities.LogMessage(currentMethod + ":: Try to close Personalize Dialog.");
                        CoreManager.MomConsole.Waiters.WaitForWindowClose(PersonalizeTaskViewDialog, Constants.OneMinute);
                        PersonalizeTaskViewDialog = null;
                        openPersonalizeView = false;
                    }
                    else
                    {
                        openPersonalizeView = true;
                    }
                }
                catch (Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException ex)
                {
                    Utilities.LogMessage(currentMethod + ":: Could not find grid in 'State' view, message: '" + ex);
                    throw;
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException ex)
                {
                    Utilities.LogMessage(currentMethod + ":: Could not find dialog, message: '" + ex);
                    throw;
                }
                catch (Maui.GlobalExceptions.MauiException ex)
                {
                    Utilities.LogMessage(currentMethod + ":: Got Maui exception in 'State' view, message: '" + ex);
                    throw;
                }
                catch (Exception ex)
                {
                    Utilities.LogMessage(currentMethod + ":: Exception in PersonalizeTaskViewDialog, component:" + component + ", Message:" + ex.Message + ", Stack:" + ex.StackTrace + ", Source:" + ex.Source + ", InnerException:" + ex.InnerException);
                    throw;
                }
                #endregion

                DataGridViewRow distributedApplicationStateRow = stateGrid.FindData(distributedApplicationName, Core.Console.ViewPane.Strings.AdministrationGridViewColumnName);

                if (distributedApplicationStateRow != null)
                {
                    Utilities.LogMessage(currentMethod + ":: Found row with DA name: " + distributedApplicationName);
                    string value = string.Empty;
                    string expectedStateString;
                    int maxRetry = 10;
                    int retry = 0;

                    if (TestFocus.Positive == focus)
                    {
                        expectedStateString = StateDialog.Strings.SuccessCellValue;
                    }
                    else
                    {
                        expectedStateString = StateDialog.Strings.ErrorCellValue;
                    }

                    // Get cell index by title name
                    int cellIndex = -1;
                    if (stateGrid != null)
                    {
                        while (cellIndex == -1 && retry < maxRetry)
                        {
                            cellIndex = stateGrid.GetColumnTitlePosition(component);
                            Utilities.LogMessage(currentMethod + ":: Found cell index for component \"" + component + "\" to be: " + cellIndex.ToString() + " in retry # " + retry);
                            Sleeper.Delay(Constants.OneSecond * 10);
                            retry++;
                        }
                    }
                    else
                    {
                        throw new Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException(currentMethod + ":: Grid view became invalid during getting index of component '" + component + "'.");
                    }

                    // Get cell value and check status of component
                    if (cellIndex >= 0)
                    {
                        retry = 0;
                        while (retry < maxRetry && cellIndex < distributedApplicationStateRow.Cells.Count)
                        {
                            value = distributedApplicationStateRow.Cells[cellIndex].GetValue();
                            Utilities.LogMessage(currentMethod + ":: Found value for component \"" + component + "\" to be: " + value.ToLowerInvariant() + " in retry # " + retry + " expecting: " + expectedStateString);
                            if (string.Compare(value, expectedStateString, true) == 0)
                            {
                                result = true;
                                break;
                            }
                            else
                            {
                                stateGrid.SendKeys(KeyboardCodes.F5);
                                Sleeper.Delay(Constants.OneSecond * 10);
                            }
                            retry++;
                        }
                    }
                }
                else
                {
                    Utilities.LogMessage("Unable to find DA row with name: " + distributedApplicationName);
                }
            }
            catch (Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException ex)
            {
                Utilities.LogMessage(currentMethod + ":: Could not find gridview at 'State' view, message:" + ex);
            }
            catch (Maui.Core.Window.Exceptions.InvalidHWndException ex)
            {
                Utilities.LogMessage(currentMethod + ":: Exception in PersonalizeTaskViewDialog, component:" + component + ", Message:" + ex.Message + ", Stack:" + ex.StackTrace + ", Source:" + ex.Source + ", InnerException:" + ex.InnerException);
            }
            catch (Maui.GlobalExceptions.MauiException ex)
            {
                Utilities.LogMessage(currentMethod + ":: Failed to find grid view in 'State' view, message:" + ex);
            }
            catch (Exception ex)
            {
                Utilities.LogMessage(currentMethod + ":: Failed to find status in 'State' view, component:" + component + ", Message:" + ex.Message + ", Stack:" + ex.StackTrace + ", Source:" + ex.Source + ", InnerException:" + ex.InnerException);
            }
            finally
            {
                Utilities.TakeScreenshot(currentMethod + "_StatusCheck");
                this.CloseStateDialog();
            }
            return result;
        }

        /// <summary>
        /// Close state view dialog
        /// </summary>
        private void CloseStateDialog()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Sleeper.Delay(Constants.DefaultDialogTimeout);

            StateDialog stateDialog = new StateDialog(CoreManager.MomConsole);
            Utilities.LogMessage(currentMethod + ":: start");

            if (stateDialog != null)
            {
                //  [v-yoz] 15OCT09   Maui 2.0 Required change: ClickTitleBarClose() method does not 
                //                      work to close the pivoted window. Need to investigate further could be
                //                      an RPF bug - using it fails with:
                //                      "Internal failure: GetUIElementFromPoint didn't return S_OK The handle is invalid."
                //                      Changed this to close the open window with Extended.CloseWindow() method.
                stateDialog.Extended.CloseWindow(); //StateDialogWindow.ClickTitleBarClose();                
                CoreManager.MomConsole.WaitForDialogClose(stateDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
                stateDialog = null;
            }

            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Confirm remove from MaintenanceMode
        /// </summary>
        /// <param name="parameters">Parameters</param>
        private void ConfirmRemoveFromMaintenanceMode(MaintenanceModeParameters parameters)
        {
            Utilities.LogMessage("StateView.ConfirmRemoveFromMaintenanceMode:: RemoveContainedObjects: " + parameters.RemoveContainedObjects);
            Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond * 3);

            //Set focus on the dialog
            this.ConfirmChoice.Extended.SetFocus();

            //if (parameters.RemoveContainedObjects == true)
            //{
                //Check Remove contained objects check box
                //this.ConfirmChoice.ClickRemoveContainedObjects();
                this.ConfirmChoice.RemoveContainedObjects = parameters.RemoveContainedObjects;
            //}

            Utilities.LogMessage("StateView.ConfirmRemoveFromMaintenanceMode:: Confirm: " + parameters.Confirm);
            if (parameters.Confirm == true)
            {
                // use the "Yes" button
                this.ConfirmChoice.ClickYes();
            }
            else
            {
                // use the "No" button
                this.ConfirmChoice.ClickNo();
            }

            CoreManager.MomConsole.WaitForDialogClose(this.ConfirmChoice, 30);

          CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);

        }

        /// <summary>
        /// Start MaintenanceMode
        /// </summary>
        /// <param name="parameters">Parameters</param>
        private void LaunchStartMaintenanceModeDialog(MaintenanceModeParameters parameters)
        {
            Utilities.LogMessage("StateView.StartMaintenanceMode:: Comment: " + parameters.Comment);

            // Lets do a little wait for the dialog to come up.
            CoreManager.MomConsole.GetWizardDialog(MaintenanceModeDialog.Strings.DialogTitle, Constants.OneSecond * 3, true, true);

            // Set focus on the dialog
            this.MaintenanceMode.Extended.SetFocus();

            #region Apply to contained classes

            // if Apply To Contained Objects is set to true, then select radio button accordingly
            if (parameters.ApplyToContainedObjects == true)
            {
                // Put into Maintenance Mode recursively
                Utilities.LogMessage("StateView.StartMaintenanceMode:: select Objects and their contained classes radio button");
                this.MaintenanceMode.ApplyTo =  ApplyTo.TheSelectedObjectsAndAllTheirContainedObjects;
            }

            #endregion

            #region Planned Check Box and Maintenance Category

            // if check box is checked and needs to be unchecked
            if ((parameters.Planned == false) && (this.MaintenanceMode.Planned == true))
            {
                Utilities.LogMessage(string.Format("Original Check box status is {0}", this.MaintenanceMode.Planned.ToString()));
                Utilities.LogMessage("StateView.EditMaintenanceMode:: unchecking Planned check box");

                // Click Planned check box to uncheck it
                this.MaintenanceMode.ClickPlanned();
                Utilities.LogMessage("StateView.EditMaintenanceMode:: Planned check box value is '"
                    + this.MaintenanceMode.Planned.ToString() + "'");
            }

            // if check box is unchecked and needs to be checked
            if ((parameters.Planned == true) && (this.MaintenanceMode.Planned == false))
            {
                Utilities.LogMessage(string.Format("Original Check box status is {0}", this.MaintenanceMode.Planned.ToString()));
                Utilities.LogMessage("StateView.StartMaintenanceMode:: checking Planned check box");                
                // Click Planned check box to check it
                this.MaintenanceMode.ClickPlanned();
                Utilities.LogMessage("StateView.StartMaintenanceMode:: Planned check box value is '"
                    + this.MaintenanceMode.Planned.ToString() + "'");
            }

            // if Maintenance Category parameter is passed, then set it
            if (parameters.MaintenanceCategory != null)
            {
                Utilities.LogMessage("StateView.StartMaintenanceMode:: setting Maintenance Category");
                this.MaintenanceMode.MaintenanceCategoryText = parameters.MaintenanceCategory;
                Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);
                Utilities.LogMessage("StateView.StartMaintenanceMode:: Maintenance Category right after setting is '"
                    + this.MaintenanceMode.MaintenanceCategoryText.ToString() + "'");
            }
            #endregion

            #region Comment

            // if Comment parameter is passed, then set it
            if (parameters.Comment != null)
            {
                Utilities.LogMessage("StateView.StartMaintenanceMode:: setting comment");
                this.MaintenanceMode.CommentText = parameters.Comment;
                Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);
                Utilities.LogMessage("StateView.StartMaintenanceMode:: Comment right after setting is '"
                    + this.MaintenanceMode.CommentText.ToString() + "'");
            }
            #endregion

            #region Maintenance Mode Duration

            // if number of min parameter is more than 0, then set it
            if (parameters.NumberOfMinutes > 0) 
            {
                // make sure that NumberOfMinutesRadioButton is checked
                this.MaintenanceMode.MaintenanceModeDuration = MaintenanceModeDuration.NumberOfMinutes;

                Utilities.LogMessage("StateView.StartMaintenanceMode:: Number of Min in the NumderOfMinutes input box before setting is '"
                    + this.MaintenanceMode.MinuteSpinnerComboBoxText.ToString() + "'");

                // Set the value in the time spinner control for number of minutes
                this.MaintenanceMode.MinuteSpinnerComboBoxText = parameters.NumberOfMinutes.ToString();
                Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);
                Utilities.LogMessage("StateView.StartMaintenanceMode:: Number of Min in the NumderOfMinutes input box right after setting is '"
                    + this.MaintenanceMode.MinuteSpinnerComboBoxText.ToString() + "'");

            }
            #endregion

            // save the dialog
            this.MaintenanceMode.ClickOK();
            CoreManager.MomConsole.WaitForDialogClose(this.MaintenanceMode, 30);
            CoreManager.MomConsole.Waiters.WaitForStatusReady();
        }

        /// <summary>
        /// Open Distributed Application view in Monitoring Space
        /// </summary>
        /// <param name="distributedApplicationName">Distributed Application name</param>
        /// <param name="viewName">View name</param>
        private void OpenView(string distributedApplicationName, string viewName)
        {
            Sleeper.Delay(Constants.DefaultDialogTimeout);
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");

            //Check if existing unexcepted dialog
            int maxTries = 10, tries = 0;
            bool dialogFound = false;
            while (tries++ < maxTries && dialogFound == false)
            {
                //if existing, then closed
                dialogFound = CoreManager.MomConsole.CheckForExceptionErrorDialog();
                Sleeper.Delay(Constants.OneSecond * 5);
                CoreManager.MomConsole.BringToForeground();
            }

            //navigate to DA on monitoring space
            Utilities.LogMessage(currentMethod + ":: Navigating to DA in Monitoring Space");
            CoreManager.MomConsole.NavigationPane.SelectNode(
                NavigationPane.Strings.Monitoring
                + Constants.PathDelimiter
                + NavigationPane.Strings.MonConfigTreeViewServices,
                NavigationPane.NavigationTreeView.Monitoring);

            //right click on it and open diagram view
            Utilities.LogMessage(currentMethod + ":: Opening View: " + viewName);

            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);

            Core.Console.MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;
            DataGridViewRow distributedApplicationRow = viewGrid.FindData(distributedApplicationName, Core.Console.ViewPane.Strings.AdministrationGridViewColumnName);

            //retry incase grid is not populated in first attempt
            if (null == distributedApplicationRow)
            {
                Sleeper.Delay(Constants.OneSecond * 10);
                CoreManager.MomConsole.Refresh();
                distributedApplicationRow = viewGrid.FindData(distributedApplicationName, Core.Console.ViewPane.Strings.AdministrationGridViewColumnName);
            }

            //Right clicking first column in grid and opening view
            Utilities.LogMessage(currentMethod + ":: Clicking View");
            distributedApplicationRow.Cells[0].AccessibleObject.Click();

            //Retry to find and select <distributedApplicationName> to make sure the Navigation node of Task Pane appeared
            tries = 0;
            while (tries++ < maxTries)
            {
                try
                {
                    CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);
                    Window wndNav = new Window(new QID(";[UIA, VisibleOnly]Name = ~'" + Mom.Test.UI.Core.Console.Tasks.Tasks.Strings.NavigationActionsPane.Replace("'", "''") + "' && Role = 'grouping'"), Constants.OneMinute);
                    break;
                }
                catch
                {
                    Utilities.LogMessage(currentMethod + ":: Navigation window is not found, try again: "+tries+" of "+maxTries+".");

                    CoreManager.MomConsole.Refresh();
                    Utilities.LogMessage(currentMethod + ":: Clicking View");
                    Utilities.LogMessage(currentMethod + ":: Find and click 'Operations Manager Management Group'");
                    distributedApplicationRow = viewGrid.FindData(Core.Console.ServiceDesigner.Strings.MomMgmtGroup, Core.Console.ViewPane.Strings.AdministrationGridViewColumnName);
                    distributedApplicationRow.Cells[0].AccessibleObject.Click();

                    CoreManager.MomConsole.Refresh();
                    Utilities.LogMessage(currentMethod + ":: Find and click '" + distributedApplicationName + "'");
                    distributedApplicationRow = viewGrid.FindData(distributedApplicationName, Core.Console.ViewPane.Strings.AdministrationGridViewColumnName);
                    distributedApplicationRow.Cells[0].AccessibleObject.Click();
                }
            }
            
            //open view via Action Pane
            CoreManager.MomConsole.ActionsPane.ClickLink(Mom.Test.UI.Core.Console.Tasks.Tasks.Strings.NavigationActionsPane,
                viewName.Replace("&", ""));

            Utilities.LogMessage(currentMethod + ":: end");
        }

        #endregion

        #region MaintenanceMode Parameters Class
        /// <summary>
        /// Maintenance Mode Parameters Class
        /// </summary>
        public class MaintenanceModeParameters
        {
            #region Private Members
            private string cachedPathToView = null;
            private string cachedMachineName = null;
            private bool cachedPlanned = false;
            private string cachedMaintenanceCategory = null;
            private string cachedComment = null;
            private bool cachedApplyToContainedObjects = true;
            private bool cachedRemoveContainedObjects = true;
            private bool cachedConfirm = true;

            ////private bool cachedMaintenanceModeDuration = true;
            private int cachedNumberOfMinutes = 0;
            

            #endregion

            #region Constructors

            /// <summary>
            /// Default Constructor - no need in ExePath etc. Inherited classes
            /// from Console set all required properties on parameter objects.
            /// </summary>
            public MaintenanceModeParameters()
            {
            }
            #endregion

            #region Properties

            /// <summary>
            /// Path to view
            /// </summary>
            public string PathToView
            {
                get
                {
                    return this.cachedPathToView;
                }

                set
                {
                    this.cachedPathToView = value;
                }
            }

            /// <summary>
            /// Machine Name
            /// </summary>
            public string MachineName
            {
                get
                {
                    return this.cachedMachineName;
                }

                set
                {
                    this.cachedMachineName = value;
                }
            }

            /// <summary>
            /// Planned Check Box
            /// </summary>
            public bool Planned
            {
                get
                {
                    return this.cachedPlanned;
                }

                set
                {
                    this.cachedPlanned = value;
                }
            }

            /// <summary>
            /// Maintenance Category Combo Box
            /// </summary>
            public string MaintenanceCategory
            {
                get
                {
                    return this.cachedMaintenanceCategory;
                }

                set
                {
                    this.cachedMaintenanceCategory = value;
                }
            }

            /// <summary>
            /// MaintenanceMode Comment
            /// </summary>
            public string Comment
            {
                get
                {
                    return this.cachedComment;
                }

                set
                {
                    this.cachedComment = value;
                }
            }

            /// <summary>
            /// Maintenance Mode Number Of Minutes
            /// </summary>
            public int NumberOfMinutes
            {
                get
                {
                    return this.cachedNumberOfMinutes;
                }

                set
                {
                    this.cachedNumberOfMinutes = value;
                }
            }

            /// <summary>
            /// Maintenance Mode Apply To Contained Objects
            /// </summary>
            public bool ApplyToContainedObjects
            {
                get
                {
                    return this.cachedApplyToContainedObjects;
                }

                set
                {
                    this.cachedApplyToContainedObjects = value;
                }
            }

            /// <summary>
            /// Maintenance Mode Remove Contained Objects
            /// </summary>
            public bool RemoveContainedObjects
            {
                get
                {
                    return this.cachedRemoveContainedObjects;
                }

                set
                {
                    this.cachedRemoveContainedObjects = value;
                }
            }

            /// <summary>
            /// Maintenance Mode (remove) Confirm
            /// </summary>
            public bool Confirm
            {
                get
                {
                    return this.cachedConfirm;
                }

                set
                {
                    this.cachedConfirm = value;
                }
            }

            #endregion
        }
        #endregion

        /// <summary>
        /// Strings Class
        /// </summary>
        /// <history>
        ///     [a-joelj]   24MAR09 Updated Health explorer context resource
        /// </history>
        public class Strings
        {
            #region Constants
            /// <summary>
            /// Resource string for Show Health Hierarchy
            /// </summary>
            private const string ResourceContextMenuShowHealthExplorer = 
                ";Health Explorer for {0};ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.StateResources;ShowStateTreeFormat";

            /// <summary>
            /// Contains resource string for column: Name
            /// </summary>
            public const string ResourceNameColumn =
                ";Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.StateResources;Name";

            /// <summary>
            /// Contains resource string for column: State
            /// </summary>
            public const string ResourceStateColumn =
                ";State;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.StateResources;State";

            /// <summary>
            /// Contains resource string for column: Path
            /// </summary>
            public const string ResourcePathColumn =
                ";Path;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.StateResources;Path";

            /// <summary>
            /// Contains resource string for column: Maintenance Mode
            /// </summary>
            public const string ResourceMaintenanceModeColumn =
                ";Maintenance Mode;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;MaintenanceModeText";

            /// <summary>
            /// Contains resource string for:  Maintenance Mode context menu item
            /// </summary>   
            private const string ResourceMaintenanceModeContextMenu =
                ";&Maintenance Mode;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;CommandMaintenanceModePivot";

            /// <summary>
            /// Contains resource string for: Start Maintenance Mode... context menu item
            /// </summary>   
            private const string ResourceStartMaintenanceModeContextMenu =
                ";Start Maintenance Mode...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;CommandMaintenanceModeStart";

            /// <summary>
            /// Contains resource string for: Stop Maintenance Mode context menu item
            /// </summary>   
            private const string ResourceStopMaintenanceModeContextMenu =
                ";Stop Maintenance Mode;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;CommandMaintenanceModeEnd";

            /// <summary>
            /// Contains resource string for: Edit Maintenance Mode settings... context menu item
            /// </summary>   
            private const string ResourceEditMaintenanceModeContextMenu =
                ";Edit Maintenance Mode settings...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;CommandMaintenanceModeEdit";

            ///// <summary>
            ///// Contains resource string for: StateNotMonitored Cell Value
            ///// </summary>   
            //private const string ResourceStateNotMonitored =
                //";Not monitored;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;StateGray1Text";
                                
            /// <summary>
            /// Contains resource string for: MaintenanceMode True Cell Value
            /// </summary>   
            private const string ResourceMaintenanceModeisTrue =
                "True";

            /// <summary>
            /// Contains resource string for: MaintenanceMode False Cell Value
            /// </summary>   
            private const string ResourceMaintenanceModeisFalse =
                "False";

            /// <summary>
            /// Contains resource string for: MaintenanceMode Category "Other (Planned)"
            /// </summary>   
            private const string ResourceMaintenanceModeCategoryOtherPlanned =
                ";Other (Planned);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;MMReasonPlannedOther";

            /// <summary>
            /// Contains resource string for: MaintenanceMode Category "Hardware: Maintenance (Planned)"
            /// </summary>   
            private const string ResourceMaintenanceModeCategoryHardwareMaintenancePlanned =
                ";Hardware: Maintenance (Planned);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;MMReasonPlannedHardwareMaintenance";

            /// <summary>
            /// Contains resource string for: MaintenanceMode Category "Hardware: Installation (Planned)"
            /// </summary>   
            private const string ResourceMaintenanceModeCategoryHardwareInstallationPlanned =
                ";Hardware: Installation (Planned);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;MMReasonPlannedHardwareInstallation";

            /// <summary>
            /// Contains resource string for: MaintenanceMode Category "Operating System: Reconfiguration (Planned)"
            /// </summary>   
            private const string ResourceMaintenanceModeCategoryOperatingSystemReconfigurationPlanned =
                ";Operating System: Reconfiguration (Planned);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;MMReasonPlannedOperatingSystem";

            /// <summary>
            /// Contains resource string for: MaintenanceMode Category "Application: Maintenance (Planned)"
            /// </summary>   
            private const string ResourceMaintenanceModeCategoryApplicationMaintenancePlanned =
                ";Application: Maintenance (Planned);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;MMReasonPlannedApplicationMaintenance";

            /// <summary>
            /// Contains resource string for: MaintenanceMode Category "Application: Installation (Planned)"
            /// </summary>   
            private const string ResourceMaintenanceModeCategoryApplicationInstallationPlanned =
                ";Application: Installation (Planned);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;MMReasonPlannedApplicationInstallation";

            /// <summary>
            /// Contains resource string for: MaintenanceMode Category "Security issue" under Planned
            /// </summary>   
            private const string ResourceMaintenanceModeCategorySecurityIssue =
                ";Security issue;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;MMReasonSecurityIssue";

            /// <summary>
            /// Contains resource string for: MaintenanceMode Category "Other (Unplanned)"
            /// </summary>   
            private const string ResourceMaintenanceModeCategoryOtherUnplanned =
                ";Other (Unplanned);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;MMReasonUnplannedOther";

            /// <summary>
            /// Contains resource string for: MaintenanceMode Category "Hardware: Maintenance (Unplanned)"
            /// </summary>   
            private const string ResourceMaintenanceModeCategoryHardwareMaintenanceUnplanned =
                ";Hardware: Maintenance (Unplanned);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;MMReasonUnplannedHardwareMaintenance";

            /// <summary>
            /// Contains resource string for: MaintenanceMode Category "Hardware: Installation (Unplanned)"
            /// </summary>   
            private const string ResourceMaintenanceModeCategoryHardwareInstallationUnplanned =
                ";Hardware: Installation (Unplanned);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;MMReasonUnplannedHardwareInstallation";

            /// <summary>
            /// Contains resource string for: MaintenanceMode Category "Operating System: Reconfiguration (Unplanned)"
            /// </summary>   
            private const string ResourceMaintenanceModeCategoryOperatingSystemReconfigurationUnplanned =
                ";Operating System: Reconfiguration (Unplanned);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;MMReasonUnplannedOperatingSystem";

            /// <summary>
            /// Contains resource string for: MaintenanceMode Category "Application: Maintenance (Unplanned)"
            /// </summary>   
            private const string ResourceMaintenanceModeCategoryApplicationMaintenanceUnplanned =
                ";Application: Maintenance (Unplanned);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;MMReasonUnplannedApplicationMaintenance";

            /// <summary>
            /// Contains resource string for: MaintenanceMode Category "Application: Unresponsive" (under Unplanned)
            /// </summary>   
            private const string ResourceMaintenanceModeCategoryApplicationUnresponsive =
                ";Application: Unresponsive;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;MMReasonUnplannedApplicationUnresponsive";

            /// <summary>
            /// Contains resource string for: MaintenanceMode Category "Application: Unstable" (under Unplanned)
            /// </summary>   
            private const string ResourceMaintenanceModeCategoryApplicationUnstable =
                ";Application: Unstable;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;MMReasonUnplannedApplicationUnstable";

            /// <summary>
            /// Contains resource string for: MaintenanceMode Category "Loss of network connectivity (Unplanned)"
            /// </summary>   
            private const string ResourceMaintenanceModeCategoryLossOfNetworkConnectivityUnplanned =
                ";Loss of network connectivity (Unplanned);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;MMReasonUnplannedNoNetwork";

            #endregion

            #region Member Variables
            /// <summary>
            /// Cached refence for Context Menu Item: Show Health Hierarchy
            /// </summary>
            private static string cachedContextMenuShowHealthExplorer;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name Column
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNameColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  State column
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStateColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Path column
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPathColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode column
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMaintenanceModeColumn;

            /// <summary>
            /// Caches the translated resource string for:  Context Menu "Maintenance Mode"
            /// </summary>
            private static string cachedMaintenanceModeContextMenu;

            /// <summary>
            /// Caches the translated resource string for:  Context Menu "Start Maintenance Mode..."
            /// </summary>
            private static string cachedStartMaintenanceModeContextMenu;

            /// <summary>
            /// Caches the translated resource string for:  Context Menu "Stop Maintenance Mode"
            /// </summary>
            private static string cachedStopMaintenanceModeContextMenu;

            /// <summary>
            /// Caches the translated resource string for:  Context Menu "Edit Maintenance Mode settings..."
            /// </summary>
            private static string cachedEditMaintenanceModeContextMenu;

            /// <summary>
            /// Caches the translated resource string for:  State "Not monitored"
            /// </summary>
            private static string cachedStateNotMonitored;

            /// <summary>
            /// Caches the translated resource string for:  State "Healthy"
            /// </summary>
            private static string cachedStateHealthy;

            /// <summary>
            /// Caches the translated resource string for:  State "Critical"
            /// </summary>
            private static string cachedStateCritical;

            /// <summary>
            /// Caches the translated resource string for:  State "Warning"
            /// </summary>
            private static string cachedStateWarning;

            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode is True cell value
            /// </summary>
            private static string cachedMaintenanceModeisTrue;

            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode is False cell value
            /// </summary>
            private static string cachedMaintenanceModeisFalse;

            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode Category "Other (Planned)"
            /// </summary>
            private static string cachedMaintenanceModeCategoryOtherPlanned;

            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode Category "Hardware: Maintenance (Planned)"
            /// </summary>
            private static string cachedMaintenanceModeCategoryHardwareMaintenancePlanned;

            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode Category "Hardware: Installation (Planned)"
            /// </summary>
            private static string cachedMaintenanceModeCategoryHardwareInstallationPlanned;

            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode Category "Operating System: Reconfiguration (Planned)"
            /// </summary>
            private static string cachedMaintenanceModeCategoryOperatingSystemReconfigurationPlanned;

            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode Category "Application: Maintenance (Planned)"
            /// </summary>
            private static string cachedMaintenanceModeCategoryApplicationMaintenancePlanned;

            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode Category "Application: Installation (Planned)"
            /// </summary>
            private static string cachedMaintenanceModeCategoryApplicationInstallationPlanned;

            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode Category "Security issue" under Planned
            /// </summary>
            private static string cachedMaintenanceModeCategorySecurityIssue;

            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode Category "Other (Unplanned)"
            /// </summary>
            private static string cachedMaintenanceModeCategoryOtherUnplanned;

            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode Category "Hardware: Maintenance (Unplanned)"
            /// </summary>
            private static string cachedMaintenanceModeCategoryHardwareMaintenanceUnplanned;

            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode Category "Hardware: Installation (Unplanned)"
            /// </summary>
            private static string cachedMaintenanceModeCategoryHardwareInstallationUnplanned;

            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode Category "Operating System: Reconfiguration (Unplanned)"
            /// </summary>
            private static string cachedMaintenanceModeCategoryOperatingSystemReconfigurationUnplanned;

            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode Category "Application: Maintenance (Unplanned)"
            /// </summary>
            private static string cachedMaintenanceModeCategoryApplicationMaintenanceUnplanned;

            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode Category "Application: Unresponsive" (under Unplanned)
            /// </summary>
            private static string cachedMaintenanceModeCategoryApplicationUnresponsive;

            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode Category "Application: Unstable" (under Unplanned)
            /// </summary>
            private static string cachedMaintenanceModeCategoryApplicationUnstable;

            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode Category "Loss of network connectivity (Unplanned)"
            /// </summary>
            private static string cachedMaintenanceModeCategoryLossOfNetworkConnectivityUnplanned;

            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ShowHealthHeirarchy translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 06OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuShowHealthExplorer
            {
                get
                {
                    if ((cachedContextMenuShowHealthExplorer == null))
                    {
                        cachedContextMenuShowHealthExplorer = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuShowHealthExplorer);
                    }
                    
                    // Replace the argument character {0} with nothing
                    return (cachedContextMenuShowHealthExplorer.Replace("{0}", ""));
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name column translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 16NOV05 Created
            ///     [ruhim]  08MAR06 Moved to core   
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NameColumn
            {
                get
                {
                    if ((cachedNameColumn == null))
                    {
                        cachedNameColumn = CoreManager.MomConsole.GetIntlStr(ResourceNameColumn);
                    }

                    return cachedNameColumn;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the State column translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 16NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StateColumn
            {
                get
                {
                    if ((cachedStateColumn == null))
                    {
                        cachedStateColumn = CoreManager.MomConsole.GetIntlStr(ResourceStateColumn);
                    }

                    return cachedStateColumn;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Path column translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 16MAR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PathColumn
            {
                get
                {
                    if ((cachedPathColumn == null))
                    {
                        cachedPathColumn = CoreManager.MomConsole.GetIntlStr(ResourcePathColumn);
                    }

                    return cachedPathColumn;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MaintenanceMode column translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 27APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeColumn
            {
                get
                {
                    if ((cachedMaintenanceModeColumn == null))
                    {
                        cachedMaintenanceModeColumn = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeColumn);
                    }

                    return cachedMaintenanceModeColumn;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Maintenance Mode context menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 27APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeContextMenu
            {
                get
                {
                    if ((cachedMaintenanceModeContextMenu == null))
                    {
                        cachedMaintenanceModeContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeContextMenu);
                    }

                    return cachedMaintenanceModeContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Start Maintenance Mode... context menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 27APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StartMaintenanceModeContextMenu
            {
                get
                {
                    if ((cachedStartMaintenanceModeContextMenu == null))
                    {
                        cachedStartMaintenanceModeContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceStartMaintenanceModeContextMenu);
                    }

                    return cachedStartMaintenanceModeContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Stop Maintenance Mode context menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 27APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StopMaintenanceModeContextMenu
            {
                get
                {
                    if ((cachedStopMaintenanceModeContextMenu == null))
                    {
                        cachedStopMaintenanceModeContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceStopMaintenanceModeContextMenu);
                    }

                    return cachedStopMaintenanceModeContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Edit Maintenance Mode settings... context menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 27APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EditMaintenanceModeContextMenu
            {
                get
                {
                    if ((cachedEditMaintenanceModeContextMenu == null))
                    {
                        cachedEditMaintenanceModeContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceEditMaintenanceModeContextMenu);
                    }

                    return cachedEditMaintenanceModeContextMenu;
                }
            }
                       
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to State cell value 'Not monitored' translated resource string
            /// through SDK
            /// </summary>
            /// <history>
            /// 	[lucyra] 20SEP07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StateNotMonitored
            {
                get
                {
                    if ((cachedStateNotMonitored == null))
                    {
                        cachedStateNotMonitored = Microsoft.EnterpriseManagement.Configuration.HealthState.Uninitialized.ToString();
                    }

                    return cachedStateNotMonitored;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to State cell value 'Healthy' translated resource string
            /// through SDK
            /// </summary>
            /// <history>
            /// 	[lucyra] 20SEP07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StateHealthy
            {
                get
                {
                    if ((cachedStateHealthy == null))
                    {
                        cachedStateHealthy = Microsoft.EnterpriseManagement.Configuration.HealthState.Success.ToString();
                    }

                    return cachedStateHealthy;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to State cell value 'Critical' translated resource string
            /// through SDK
            /// </summary>
            /// <history>
            /// 	[lucyra] 20SEP07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StateCritical
            {
                get
                {
                    if ((cachedStateCritical == null))
                    {
                        cachedStateCritical = Microsoft.EnterpriseManagement.Configuration.HealthState.Error.ToString();
                    }

                    return cachedStateCritical;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to State cell value 'Warning' translated resource string
            /// through SDK
            /// </summary>
            /// <history>
            /// 	[lucyra] 20SEP07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StateWarning
            {
                get
                {
                    if ((cachedStateWarning == null))
                    {
                        cachedStateWarning = Microsoft.EnterpriseManagement.Configuration.HealthState.Warning.ToString();
                    }

                    return cachedStateWarning;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MaintenanceMode is True cell value translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 27APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeisTrue
            {
                get
                {
                    if ((cachedMaintenanceModeisTrue == null))
                    {
                        cachedMaintenanceModeisTrue = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeisTrue);
                    }

                    return cachedMaintenanceModeisTrue;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MaintenanceMode is False cell value translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 27APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeisFalse
            {
                get
                {
                    if ((cachedMaintenanceModeisFalse == null))
                    {
                        cachedMaintenanceModeisFalse = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeisFalse);
                    }

                    return cachedMaintenanceModeisFalse;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MaintenanceMode Category "Other (Planned)" combo box item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeCategoryOtherPlanned
            {
                get
                {
                    if ((cachedMaintenanceModeCategoryOtherPlanned == null))
                    {
                        cachedMaintenanceModeCategoryOtherPlanned = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeCategoryOtherPlanned);
                    }

                    return cachedMaintenanceModeCategoryOtherPlanned;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MaintenanceMode Category "Hardware: Maintenance (Planned)" combo box item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeCategoryHardwareMaintenancePlanned
            {
                get
                {
                    if ((cachedMaintenanceModeCategoryHardwareMaintenancePlanned == null))
                    {
                        cachedMaintenanceModeCategoryHardwareMaintenancePlanned = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeCategoryHardwareMaintenancePlanned);
                    }

                    return cachedMaintenanceModeCategoryHardwareMaintenancePlanned;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MaintenanceMode Category "Hardware: Installation (Planned)" combo box item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeCategoryHardwareInstallationPlanned
            {
                get
                {
                    if ((cachedMaintenanceModeCategoryHardwareInstallationPlanned == null))
                    {
                        cachedMaintenanceModeCategoryHardwareInstallationPlanned = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeCategoryHardwareInstallationPlanned);
                    }

                    return cachedMaintenanceModeCategoryHardwareInstallationPlanned;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MaintenanceMode Category "Operating System: Reconfiguration (Planned)" combo box item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeCategoryOperatingSystemReconfigurationPlanned
            {
                get
                {
                    if ((cachedMaintenanceModeCategoryOperatingSystemReconfigurationPlanned == null))
                    {
                        cachedMaintenanceModeCategoryOperatingSystemReconfigurationPlanned = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeCategoryOperatingSystemReconfigurationPlanned);
                    }

                    return cachedMaintenanceModeCategoryOperatingSystemReconfigurationPlanned;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MaintenanceMode Category "Application: Maintenance (Planned)" combo box item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeCategoryApplicationMaintenancePlanned
            {
                get
                {
                    if ((cachedMaintenanceModeCategoryApplicationMaintenancePlanned == null))
                    {
                        cachedMaintenanceModeCategoryApplicationMaintenancePlanned = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeCategoryApplicationMaintenancePlanned);
                    }

                    return cachedMaintenanceModeCategoryApplicationMaintenancePlanned;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MaintenanceMode Category "Application: Installation (Planned)" combo box item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeCategoryApplicationInstallationPlanned
            {
                get
                {
                    if ((cachedMaintenanceModeCategoryApplicationInstallationPlanned == null))
                    {
                        cachedMaintenanceModeCategoryApplicationInstallationPlanned = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeCategoryApplicationInstallationPlanned);
                    }

                    return cachedMaintenanceModeCategoryApplicationInstallationPlanned;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MaintenanceMode Category "Security issue" under Planned combo box item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeCategorySecurityIssue
            {
                get
                {
                    if ((cachedMaintenanceModeCategorySecurityIssue == null))
                    {
                        cachedMaintenanceModeCategorySecurityIssue = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeCategorySecurityIssue);
                    }

                    return cachedMaintenanceModeCategorySecurityIssue;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MaintenanceMode Category "Other (Unplanned)" combo box item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeCategoryOtherUnplanned
            {
                get
                {
                    if ((cachedMaintenanceModeCategoryOtherUnplanned == null))
                    {
                        cachedMaintenanceModeCategoryOtherUnplanned = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeCategoryOtherUnplanned);
                    }

                    return cachedMaintenanceModeCategoryOtherUnplanned;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MaintenanceMode Category "Hardware: Maintenance (Unplanned)" combo box item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeCategoryHardwareMaintenanceUnplanned
            {
                get
                {
                    if ((cachedMaintenanceModeCategoryHardwareMaintenanceUnplanned == null))
                    {
                        cachedMaintenanceModeCategoryHardwareMaintenanceUnplanned = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeCategoryHardwareMaintenanceUnplanned);
                    }

                    return cachedMaintenanceModeCategoryHardwareMaintenanceUnplanned;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MaintenanceMode Category "Hardware: Installation (Unplanned)" combo box item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeCategoryHardwareInstallationUnplanned
            {
                get
                {
                    if ((cachedMaintenanceModeCategoryHardwareInstallationUnplanned == null))
                    {
                        cachedMaintenanceModeCategoryHardwareInstallationUnplanned = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeCategoryHardwareInstallationUnplanned);
                    }

                    return cachedMaintenanceModeCategoryHardwareInstallationUnplanned;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MaintenanceMode Category "Operating System: Reconfiguration (Unplanned)" combo box item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeCategoryOperatingSystemReconfigurationUnplanned
            {
                get
                {
                    if ((cachedMaintenanceModeCategoryOperatingSystemReconfigurationUnplanned == null))
                    {
                        cachedMaintenanceModeCategoryOperatingSystemReconfigurationUnplanned = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeCategoryOperatingSystemReconfigurationUnplanned);
                    }

                    return cachedMaintenanceModeCategoryOperatingSystemReconfigurationUnplanned;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MaintenanceMode Category "Application: Maintenance (Unplanned)" combo box item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeCategoryApplicationMaintenanceUnplanned
            {
                get
                {
                    if ((cachedMaintenanceModeCategoryApplicationMaintenanceUnplanned == null))
                    {
                        cachedMaintenanceModeCategoryApplicationMaintenanceUnplanned = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeCategoryApplicationMaintenanceUnplanned);
                    }

                    return cachedMaintenanceModeCategoryApplicationMaintenanceUnplanned;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MaintenanceMode Category "Application: Unresponsive" (under Unplanned) combo box item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeCategoryApplicationUnresponsive
            {
                get
                {
                    if ((cachedMaintenanceModeCategoryApplicationUnresponsive == null))
                    {
                        cachedMaintenanceModeCategoryApplicationUnresponsive = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeCategoryApplicationUnresponsive);
                    }

                    return cachedMaintenanceModeCategoryApplicationUnresponsive;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MaintenanceMode Category "Application: Unstable" (under Unplanned) combo box item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeCategoryApplicationUnstable
            {
                get
                {
                    if ((cachedMaintenanceModeCategoryApplicationUnstable == null))
                    {
                        cachedMaintenanceModeCategoryApplicationUnstable = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeCategoryApplicationUnstable);
                    }

                    return cachedMaintenanceModeCategoryApplicationUnstable;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to MaintenanceMode Category "Loss of network connectivity (Unplanned)" combo box item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeCategoryLossOfNetworkConnectivityUnplanned
            {
                get
                {
                    if ((cachedMaintenanceModeCategoryLossOfNetworkConnectivityUnplanned == null))
                    {
                        cachedMaintenanceModeCategoryLossOfNetworkConnectivityUnplanned = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeCategoryLossOfNetworkConnectivityUnplanned);
                    }

                    return cachedMaintenanceModeCategoryLossOfNetworkConnectivityUnplanned;
                }
            }

            #endregion
        }
    }
}