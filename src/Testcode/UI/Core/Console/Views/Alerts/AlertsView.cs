//-------------------------------------------------------------------
// <copyright file="AlertsView.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Alerts View
// </summary>
//  <history>
//   [mbickle] 02DEC04: Created
//   [ruhim]   17July06: Added GetAlertResolutionState 
//   [lucyra]  04OCT06: Added Custom Alert Resolution support   
//   [ruhim]   26May08: Added resource string for Alert Name Column Header   
//   [kellymor]29MAY08: Added resources for Overrides and Forward To
//                      context menu. 
//   [kellymor]28OCT08: Added resources for context menu 
//                      Notifications, Create..., and Modify... for
//                      subscriptions
//                      Many StyleCop fixes.
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Views.Alerts
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Mom.Test.UI.Core.Common;
    using Maui.Core.Utilities;
    using Maui.Core;    
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Console.GlobalSettings;
    #endregion

    #region Enumerators section Options

    /// <summary>
    /// Enum Options
    /// Contain options to launch Alert Properties
    /// Some other options will be added possibly
    /// </summary>
    /// <history>
    ///		[lucyra] 6SEP06 Created
    /// </history>
    public enum Options
    {
        /// <summary>
        /// 1. Right-click on item and select context menu
        /// </summary>
        RightClickContextMenuOption,

        /// <summary>
        /// 2. Double-click on item
        /// </summary>
        DoubleClickOption,

        /// <summary>
        /// 3. Main Menu actions
        /// </summary>
        MainMenuActionOption,

        /// <summary>
        /// 4. Actions in tasks pane
        /// </summary>
        TasksPaneActionOption
    }

    #endregion

    /// <summary>
    /// Alerts View
    /// </summary>
    public class AlertsView
    {
        #region Private Member Variables

        /// <summary>
        /// Timeout value
        /// </summary>
        private const int Timeout = 3000;

        /// <summary>
        /// Wait for a short amount of time
        /// </summary>
        private const int MaxWait = 60;

        #endregion

        #region Private Members

        /// <summary>
        /// cachedAlertPropertiesGeneralDialog
        /// </summary>
        private AlertPropertiesGeneralDialog cachedAlertPropertiesGeneralDialog;

        /// <summary>
        /// cachedAlertPropertiesProductKnowledgeDialog
        /// </summary>
        private AlertPropertiesProductKnowledgeDialog cachedAlertPropertiesProductKnowledgeDialog;

        /// <summary>
        /// cachedAlertPropertiesCompanyKnowledgeDialog
        /// </summary>
        private AlertPropertiesCompanyKnowledgeDialog cachedAlertPropertiesCompanyKnowledgeDialog;

        /// <summary>
        /// cachedAlertPropertiesHistoryDialog
        /// </summary>
        private AlertPropertiesHistoryDialog cachedAlertPropertiesHistoryDialog;

        /// <summary>
        /// cachedAlertPropertiesAlertContextDialog
        /// </summary>
        private AlertPropertiesAlertContextDialog cachedAlertPropertiesAlertContextDialog;

        /// <summary>
        /// cachedAlertPropertiesCustomFieldsDialog
        /// </summary>
        private AlertPropertiesCustomFieldsDialog cachedAlertPropertiesCustomFieldsDialog;

        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp; 

        #endregion

        #region Constructor

        /// <summary>
        /// Alerts View
        /// </summary>
        public AlertsView()
        {
            this.consoleApp = CoreManager.MomConsole; 
        }
        
        #endregion

        #region Properties

        /// <summary>
        /// Alert Properties Dialog
        /// General main tab.
        /// </summary>
        public AlertPropertiesGeneralDialog alertPropertiesGeneralDialog
        {
            get
            {
                //// if (this.cachedAlertPropertiesGeneralDialog == null)
                //// {
                    this.cachedAlertPropertiesGeneralDialog = new AlertPropertiesGeneralDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Alert Properties General Dialog was successful");
                //// }

                return this.cachedAlertPropertiesGeneralDialog;
            }
        }

        /// <summary>
        /// Alert Properties Dialog
        /// Product Knowledge tab.
        /// </summary>
        public AlertPropertiesProductKnowledgeDialog alertPropertiesProductKnowledgeDialog
        {
            get
            {
                if (this.cachedAlertPropertiesProductKnowledgeDialog == null)
                {
                    this.cachedAlertPropertiesProductKnowledgeDialog = 
                        new AlertPropertiesProductKnowledgeDialog(CoreManager.MomConsole);

                    Utilities.LogMessage("Setting Focus on the Alert Properties Dialog, " +
                        "Product Knowledge tab was successful");
                }

                return this.cachedAlertPropertiesProductKnowledgeDialog;
            }
        }

        /// <summary>
        /// Alert Properties Dialog
        /// Company Knowledge tab.
        /// </summary>
        public AlertPropertiesCompanyKnowledgeDialog alertPropertiesCompanyKnowledgeDialog
        {
            get
            {
                if (this.cachedAlertPropertiesCompanyKnowledgeDialog == null)
                {
                    this.cachedAlertPropertiesCompanyKnowledgeDialog = 
                        new AlertPropertiesCompanyKnowledgeDialog(
                        CoreManager.MomConsole);

                    Utilities.LogMessage("Setting Focus on the Alert Properties Dialog, " +
                        "Company Knowledge tab was successful");
                                    }

                return this.cachedAlertPropertiesCompanyKnowledgeDialog;
            }
        }

        /// <summary>
        /// Alert Properties Dialog
        /// History tab.
        /// </summary>
        public AlertPropertiesHistoryDialog alertPropertiesHistoryDialog
        {
            get
            {
                //if (this.cachedAlertPropertiesHistoryDialog == null)
                //{
                    this.cachedAlertPropertiesHistoryDialog = 
                        new AlertPropertiesHistoryDialog(CoreManager.MomConsole);

                    Utilities.LogMessage("Setting Focus on the Alert Properties Dialog, History tab was successful");
                //}

                return this.cachedAlertPropertiesHistoryDialog;
            }
        }

        /// <summary>
        /// Alert Properties Dialog
        /// Alert Context tab.
        /// </summary>
        public AlertPropertiesAlertContextDialog alertPropertiesAlertContextDialog
        {
            get
            {
                if (this.cachedAlertPropertiesAlertContextDialog == null)
                {
                    this.cachedAlertPropertiesAlertContextDialog = 
                        new AlertPropertiesAlertContextDialog(CoreManager.MomConsole);

                    Utilities.LogMessage("Setting Focus on the Alert Properties Dialog, " +
                        "Alert Context tab was successful");
                }

                return this.cachedAlertPropertiesAlertContextDialog;
            }
        }

        /// <summary>
        /// Alert Properties Dialog
        /// Custom Fields tab.
        /// </summary>
        public AlertPropertiesCustomFieldsDialog alertPropertiesCustomFieldsDialog
        {
            get
            {
                if (this.cachedAlertPropertiesCustomFieldsDialog == null)
                {
                    this.cachedAlertPropertiesCustomFieldsDialog = 
                        new AlertPropertiesCustomFieldsDialog(CoreManager.MomConsole);

                    Utilities.LogMessage("Setting Focus on the Alert Properties Dialog, " +
                        "Custom Fields tab was successful");
                }

                return this.cachedAlertPropertiesCustomFieldsDialog;
            }
        }

        #endregion

        #region Public Methods

        #region Alert Row Count

        /// <summary>
        /// Counts rows in the Alert rows in the grid (does not include title row)
        /// </summary>
        /// <param name="pathToAlertView">Path to Alerts view to count alerts in</param>
        /// <returns>Number of Alert rows without title row</returns>
        /// <history>
        /// [lucyra] 10May06 Created
        /// </history>
        public int AlertRowCount(string pathToAlertView)
        {
            int count = 1;
            int countWithoutTitleRow = 0;

            Utilities.LogMessage("AlertView.AlertRowCount:: Let's count rows in the grid ");

            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

            navPane.SelectNode(pathToAlertView, NavigationPane.NavigationTreeView.Monitoring);

            MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;

            count = viewGrid.Rows.Count;
            countWithoutTitleRow = count - 1;

            Utilities.LogMessage("Row count in the grid is " + count + " including Title Row");

            Utilities.LogMessage("Returning count without the title row, that is " + 
                countWithoutTitleRow);

            return countWithoutTitleRow;
        }

        #endregion

        #region Close Alert
        /// <summary>
        /// Close Alert from particular machine and current New resolution state
        /// </summary>
        /// <param name="pathToAlertView">Path to Alert view</param>
        /// <param name="alertResolutionState">Alert Resolution State(New)</param>
        /// <param name="computerPath">Computer Path(FQDN) on which Alert was generated</param>
        /// <param name="maxTries">Max number of tries</param>
        /// <returns>True/False</returns>
        /// <history>
        /// [lucyra] 10May06 Created
        /// </history>
        public bool CloseAlert(
            string pathToAlertView,
            string alertResolutionState,
            string computerPath,
            int maxTries)
        {
            Utilities.LogMessage("AlertView.CloseAlert:: alertResolutionState: " + alertResolutionState);
            Utilities.LogMessage("AlertView.CloseAlert:: computerPath: " + computerPath);

            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

            navPane.SelectNode(pathToAlertView, NavigationPane.NavigationTreeView.Monitoring);

            MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;

            bool alertClosed = false;
            bool foundInstance = false;
            int colposResolutionState = 0;
            int colposPath = 0;
            Maui.Core.WinControls.DataGridViewRow row = null;

            if (viewGrid != null)
            {
                Utilities.LogMessage("AlertView.CloseAlert:: Found Alert View Grid");

                colposPath = viewGrid.GetColumnTitlePosition(Strings.AlertPathColumnTitle);
                colposResolutionState = viewGrid.GetColumnTitlePosition(Strings.ResolutionStateColumnTitle);

                Utilities.LogMessage("AlertView.CloseAlert:: Path column position:" + colposPath.ToString());

                Utilities.LogMessage("AlertView.CloseAlert:: Resolution State column position:" + 
                    colposResolutionState.ToString());

                row = viewGrid.FindInstanceRow(
                    Strings.ResolutionStateColumnTitle,
                    Strings.AlertPathColumnTitle,
                    alertResolutionState,
                    computerPath,
                    5);

                if (row != null)
                {
                    foundInstance = true;
                }
                else
                {
                    Utilities.LogMessage("AlertView.CloseAlert :: " +
                        "Didn't find New alert of the machine specified");
                }
            }

            if (foundInstance)
            {
                Utilities.LogMessage("AlertView.CloseAlert:: Found instance: @ row: " + 
                    row.AccessibleObject.Index.ToString());

                // Click on cell in grid
                viewGrid.ClickCell(row.AccessibleObject.Index, colposResolutionState);

                Utilities.LogMessage("AlertView.CloseAlert:: Clicked cell");

                Utilities.LogMessage("AlertView.CloseAlert ::  Right clicking now");
                
                // Selecting ResolveThisAlert from the context menu
                Maui.Core.WinControls.Menu resolveAlertMenuItem = 
                    new Maui.Core.WinControls.Menu(
                    Maui.Core.WinControls.ContextMenuAccessMethod.ShiftF10);

                resolveAlertMenuItem.ScreenElement.WaitForReady();

                Utilities.LogMessage("AlertView.CloseAlert ::  Selecting '" + 
                    Strings.CloseAlertContextMenu + "' " + 
                    "from alert view context menu");

                resolveAlertMenuItem.ExecuteMenuItem(Strings.CloseAlertContextMenu);

                Utilities.LogMessage("AlertView.CloseAlert ::  Successfully clicked on '" + 
                    Strings.CloseAlertContextMenu + "' " + 
                    "context menu item in Alert view");

                // if clicked on the context menu, hopefully the alert got resolved
                alertClosed = true;

                Utilities.LogMessage("AlertView.CloseAlert ::  Set alertClosed to true");
            }

            if (!alertClosed)
            {
                Utilities.LogMessage("AlertView.CloseAlert ::  " +
                    "Problems launching 'Close Alert' context menu!");
            }

            return alertClosed;
        }

        #endregion

        #region Get Alert Resolution State

        /// <summary>
        /// Returns alert resolution state from particular machine and Service
        /// </summary>
        /// <param name="alertViewPath">Path to Alerts view</param>
        /// <param name="sourceName">Name of the Windows Service as seen in alerts view</param>
        /// <param name="computerPath">Computer Path(FQDN) on which Alert was generated</param>
        /// <param name="maxTries">Max number of tries</param>
        /// <returns>Alert Resolution State </returns>
        /// <history>
        /// [ruhim] 17July06 Created
        /// </history>
        public string GetAlertResolutionState(
            string alertViewPath,
            string sourceName,
            string computerPath,
            int maxTries)
        {
            string alertResolutionState = null;
            int colposResolutionState = -1;
            int attempt = 0;

            while ((alertResolutionState == null) && (attempt < maxTries))
            {
                Utilities.LogMessage("AlertView.GetAlertResolutionState:: computerPath: " + 
                    computerPath);

                NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

                navPane.SelectNode(
                    alertViewPath, 
                    NavigationPane.NavigationTreeView.Monitoring);

                Core.Console.MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;
                Maui.Core.WinControls.DataGridViewRow row = null;

                if (viewGrid != null)
                {
                    Utilities.LogMessage("AlertView.GetAlertResolutionState:: Found Alert View Grid");

                    colposResolutionState = viewGrid.GetColumnTitlePosition(
                        Core.Console.Views.Alerts.AlertsView.Strings.ResolutionStateColumnTitle);

                    Utilities.LogMessage("AlertView.GetAlertResolutionState:: Resolution State column position:" + 
                        colposResolutionState.ToString());

                    row = viewGrid.FindInstanceRow(
                        Core.Console.Views.Alerts.AlertsView.Strings.SourceColumnTitle,
                        Core.Console.Views.Alerts.AlertsView.Strings.AlertPathColumnTitle,
                        sourceName,
                        computerPath,
                        maxTries);

                    if (row != null)
                    {
                        row.AccessibleObject.Click();

                        Utilities.LogMessage("AlertView.GetAlertResolutionState:: Successfully selected the alert row");

                        alertResolutionState = row.Cells[colposResolutionState].GetValue();

                        Utilities.LogMessage("AlertView.GetAlertResolutionState:: Resolution State value for this row is "
                            + alertResolutionState);
                        break;
                    }
                    else
                    {
                        Utilities.LogMessage("AlertView.GetAlertResolutionState :: " +
                            "Didn't find New alert of the machine specified");

                        attempt++;

                        Utilities.LogMessage("AlertView.GetAlertResolutionState :: Attempt Number " + 
                            attempt.ToString());
                    }
                }
            }

            return alertResolutionState;
        }

        #endregion

        #region Close Alert Properties

        /// <summary>
        /// Method to Close alert properties dialog without saving changes if any
        /// </summary>
        /// <history>
        /// [lucyra] 7SEP06 Created
        /// </history>
        public void CloseAlertProperties()
        {
            bool saveChanges = false;
            Utilities.LogMessage("AlertsView.CloseAlertProperties :: " +
                "by default no changes to alert properties are saved!");

            this.CloseAlertProperties(saveChanges);
        }

        /// <summary>
        /// Method to Close alert properties dialog
        /// </summary>
        /// <param name="saveChanges">
        /// A flag indicating if any changes should be saved during the close
        /// operation.
        /// </param>
        public void CloseAlertProperties(bool saveChanges)
        {
            // set focus on the first screen
            this.alertPropertiesGeneralDialog.Extended.SetFocus();

            if (saveChanges == false)
            {
                // click Cancel button
                this.alertPropertiesGeneralDialog.ClickCancel();

                // TODO: figure out how to check if this dialog is even up
                // CoreManager.MomConsole.ConfirmChoiceDialog(true);

                Maui.Core.Utilities.Sleeper.Delay(1000);
                consoleApp.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
            }
            else
            {
                // click OK button
                this.alertPropertiesGeneralDialog.ClickOK();

                Maui.Core.Utilities.Sleeper.Delay(1000);
                consoleApp.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
            }
        }

        #endregion

        #region Get Alert Properties

        /// <summary>
        /// Method to launch Alert Properties dialog via option right click on Alert
        /// </summary>
        /// <param name="alertViewPath">Path to Alert view</param>
        /// <param name="column1title">Column Title 1</param>
        /// <param name="column2title">Column Title 2</param>
        /// <param name="column1">Column 1 value to search for</param>
        /// <param name="column2">Column 2 value to search for</param>
        /// <history>
        /// [lucyra] 18SEP06 Created
        /// </history>
        public void GetAlertProperties(
            string alertViewPath,
            string column1title,
            string column2title,
            string column1,
            string column2)
        {
            string alertOption = "RIGHTCLICKCONTEXTMENUOPTION";
            this.GetAlertProperties(
                alertViewPath,
                column1title,
                column2title,
                column1,
                column2,
                alertOption);
        }

        /// <summary>
        /// Method to launch Alert Properties dialog via option(string) specified
        /// </summary>
        /// <param name="alertViewPath">Path to Alert view</param>
        /// <param name="column1title">Column Title 1</param>
        /// <param name="column2title">Column Title 2</param>
        /// <param name="column1">Column 1 value to search for</param>
        /// <param name="column2">Column 2 value to search for</param>
        /// <param name="alertOptions">Option to launch dialog via R-click, D-clik, Main Manu or Tasks pane</param>
        /// <history>
        /// [lucyra] 18SEP06 Created
        /// </history>
        public void GetAlertProperties(
            string alertViewPath,
            string column1title,
            string column2title,
            string column1,
            string column2,
            string alertOptions)
        {
            this.GetAlertProperties(
                alertViewPath, 
                column1title, 
                column2title, 
                column1, 
                column2,
                this.GetOption(alertOptions));
        }

        /// <summary>
        /// Method to launch Alert Properties dialog via option specified
        /// </summary>
        /// <param name="alertViewPath">Path to Alert view</param>
        /// <param name="column1title">Column Title 1</param>
        /// <param name="column2title">Column Title 2</param>
        /// <param name="column1">Column 1 value to search for</param>
        /// <param name="column2">Column 2 value to search for</param>
        /// <param name="alertOptions">Option to launch dialog via R-click, D-clik, Main Manu or Tasks pane</param>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">
        /// if alert row is not found or if there's no alerts in the grid control
        /// </exception>
        /// <history>
        /// [lucyra] 7SEP06 Created
        /// </history>
        public void GetAlertProperties(
            string alertViewPath, 
            string column1title, 
            string column2title, 
            string column1, 
            string column2, 
            Options alertOptions)
        {
            Utilities.LogMessage("AlertsView.GetAlertProperties :: Create instance of grid control");

            // Create instance of Alert View Grid Control
            Mom.Test.UI.Core.Console.MomControls.GridControl viewGrid = null;
            int timeWaited = 0;
            bool foundInstance = false;
            int alertCount = 0;
            int colpos = 0;

            // Define a row
            Maui.Core.WinControls.DataGridViewRow row = null;
            Maui.Core.WinControls.DataGridViewRow SpoolerRow = null;
            // Check the alert count
            alertCount = this.AlertRowCount(alertViewPath);

            Utilities.LogMessage("AlertsView.GetAlertProperties :: Currently we have " + 
                alertCount.ToString() + 
                " rows");

            while (alertCount == 0 && timeWaited <= MaxWait)
            {
                alertCount = this.AlertRowCount(alertViewPath);

                Utilities.LogMessage("AlertsView.GetAlertProperties :: " +
                    "New count is next number of alerts " + 
                    alertCount.ToString());

                timeWaited = timeWaited + 1;

                if (alertCount == 0)
                {
                    // sleep for two seconds
                    Maui.Core.Utilities.Sleeper.Delay(2000);

                    CoreManager.MomConsole.Refresh();

                    consoleApp.Waiters.WaitForWindowIdle(this.consoleApp.MainWindow, Constants.OneMinute);
                }
            }

            // if there is still not Alerts, throw exception
            if (alertCount == 0)
            {
                Utilities.LogMessage("AlertsView.GetAlertProperties :: Didn't find an alert in the grid ");

                throw new DataGrid.Exceptions.DataGridRowNotFoundException(
                    "AlertsView.GetAlertProperties :: Failed to find row in the grid");
            }

            // Mom Console grid
            viewGrid = CoreManager.MomConsole.ViewPane.Grid;

            //Check if spooler diaplay in UI
            int SpoolerIndex = viewGrid.GetColumnTitlePosition(Strings.AlertNameColumnTitle);
           
            int i = 0;
            while (i <= 10)
            {
                try
                {
                     SpoolerRow = viewGrid.FindData(
                     "Spooler",
                      SpoolerIndex,
                      Core.Console.MomControls.GridControl.SearchStringMatchType.ExactMatch
               );
                    if (SpoolerRow != null)
                    {
                        Utilities.LogMessage(" Spooler displays in UI. Continues.");
                        break;
                    }
                   Utilities.LogMessage(" Spooler does not display in UI. Will check again in 30 seconds.");
                       
                }
                catch (Exception e)
                {
                    throw e;
                }
                i++;
                Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond * 30);
                    

            }
            // Now if we got some alert, search for specific alert
            row = viewGrid.FindInstanceRow(
                column1title,
                column2title,
                column1,
                column2,
                60);

            if (row != null)
            {
                foundInstance = true;
            }
            else
            {
                Utilities.LogMessage("AlertsView.GetAlertProperties :: Didn't find alert row for " + 
                    column1 + 
                    " and " + 
                    column2 + 
                    " specified");

                throw new DataGrid.Exceptions.DataGridRowNotFoundException(
                    "AlertsView.GetAlertProperties :: Failed to find specified alert row in the grid");
            }

            if (foundInstance == true)
            {
                colpos = viewGrid.GetColumnTitlePosition(column1title);

                Utilities.LogMessage("AlertView.LaunchAlertProperties :: column position:" +
                    colpos.ToString());

                // Wait one second before executing command
                Sleeper.Delay(Constants.OneSecond);

                // Switch options to launch Alert Properties
                switch (alertOptions)
                {
                    case Options.RightClickContextMenuOption:

                        // 1. R-click on alert and select context menu                             
                        // row.Click();

                        viewGrid.ClickCell(row.AccessibleObject.Index, colpos);

                        consoleApp.Waiters.WaitForWindowIdle(this.consoleApp.MainWindow, Constants.OneMinute);

                        CoreManager.MomConsole.ExecuteContextMenu(Strings.AlertPropertiesContextMenu, true);

                        Utilities.LogMessage("AlertView.LaunchAlertProperties :: " +
                            "LaunchAlertPropertiesViaRightClick is done");

                        break;

                    case Options.DoubleClickOption:

                        // 2. D-click on alert, Add Retry logic here                    
                        int numberOfTries = 0;
                        const int MaxTries = 5;
                        
                        while (numberOfTries < MaxTries)
                        {
                            numberOfTries++;

                            try
                            {
                                viewGrid.ClickCell(
                                    row.AccessibleObject.Index,
                                    colpos,
                                    MouseClickType.DoubleClick);

                                CoreManager.MomConsole.WaitForForegroundDialog(this.alertPropertiesGeneralDialog, 6000);                                

                                break;
                            }
                            catch (Window.Exceptions.WindowNotFoundException)
                            {
                                Utilities.LogMessage("AlertView.LaunchAlertProperties :: " +
                                    "PropertiesDialog not found, times of try: " + numberOfTries.ToString());
                            }
                        }                            

                        Utilities.LogMessage(
                            "AlertView.LaunchAlertProperties :: " +
                            "LaunchAlertPropertiesViaDoubleClick is done");

                        break;

                    case Options.MainMenuActionOption:

                        // Click on alert

                        viewGrid.ClickCell(row.AccessibleObject.Index, colpos);

                        // 3. Actions main menu - Alert actions - Properties
                        Commands.Actions.Execute(this.consoleApp);

                        CoreManager.MomConsole.ExecuteContextMenu(
                           Mom.Test.UI.Core.Console.ActionsPane.Strings.ActionsPaneTasks +
                            Constants.PathDelimiter + 
                            Mom.Test.UI.Core.Console.ActionsPane.Strings.ActionsPaneTasks +
                            Constants.PathDelimiter +
                             Utilities.RemoveAcceleratorKeys(Strings.AlertPropertiesTask), 
                            false);

                        this.consoleApp.Waiters.WaitForWindowIdle(this.consoleApp.MainWindow, Constants.OneMinute);

                        Utilities.LogMessage("AlertView.LaunchAlertProperties :: " +
                            "LaunchAlertPropertiesViaMainMenuClick is done");

                        break;

                    case Options.TasksPaneActionOption:

                        bool foundLink = false;
                        int maxRetry = 5;
                        int retries = 0;
                        int rowIndex = row.AccessibleObject.Index;

                        while (!foundLink)
                        {
                            try
                            {
                                // Click on alert
                                CoreManager.MomConsole.ViewPane.Grid.ClickCell(rowIndex, colpos);
                                Sleeper.Delay(Constants.OneSecond);
                                CoreManager.MomConsole.Waiters.WaitForStatusReady();

                                // 4. Actions - Alert Propertis in tasks pane
                                ActionsPane alertActionsPane = new ActionsPane(this.consoleApp);
                                alertActionsPane.ClickLink(Mom.Test.UI.Core.Console.ActionsPane.Strings.ActionsPaneTasks, Utilities.RemoveAcceleratorKeys(Strings.AlertPropertiesTask));
                                foundLink = true;
                            }
                            // Work around product issue: task pane link doesn't appear sometimes
                            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                            {
                                Utilities.LogMessage("AlertView.LaunchAlertProperties :: Failed to find actionPane link: "+ Strings.AlertPropertiesTask);
                                Utilities.TakeScreenshot("AlertView.LaunchAlertProperties.ActionPaneLinkNotFound");

                                retries++;
                                if (retries == maxRetry)
                                {
                                    throw;
                                }

                                // Select Monitoring node in Navigation pane and nav back

                                CoreManager.MomConsole.NavigationPane.SelectNode(NavigationPane.Strings.Monitoring, NavigationPane.NavigationTreeView.Monitoring);
                                CoreManager.MomConsole.NavigationPane.SelectNode(alertViewPath, NavigationPane.NavigationTreeView.Monitoring);
                            }
                        } 

                        consoleApp.Waiters.WaitForWindowIdle(this.consoleApp.MainWindow, Constants.OneMinute);

                        Utilities.LogMessage("AlertView.LaunchAlertProperties :: " +
                            "LaunchAlertPropertiesViaTasksPaneClick");

                        break;

                    default:

                        Utilities.LogMessage("AlertView.LaunchAlertProperties:: " +
                            "Invalid option to launch Alert Properties was passed");

                        break;
                } // end switch
               
                Sleeper.Delay(Constants.OneSecond);
                CoreManager.MomConsole.Waiters.WaitForStatusReady();
                // Now set focus on the 1st screen of the dialog
                this.alertPropertiesGeneralDialog.Extended.SetFocus();

                this.alertPropertiesGeneralDialog.Controls.GeneralTabControl[Strings.General].Select();

                // Take a screenshot
                Utilities.TakeScreenshot("LaunchedAlertPropertiesViaOptionProvided");
            } // end if 
        }

        /// <summary>
        /// Method to launch Properties dialog for selecting all alerts in view via option specified
        /// </summary>
        /// <param name="alertViewPath">Path to Alert view</param>
        /// <param name="alertOptions">Option to launch dialog via R-click, Main Menu or Tasks pane</param>        
        /// <history>
        /// [v-yoz] 22June09 Created
        /// </history>
        public void GetMultipleAlertsProperties(
            string alertViewPath,
            string alertOptions)
        {
            GetMultipleAlertsProperties(
                alertViewPath,
                this.GetOption(alertOptions));
        }

        /// <summary>
        /// Method to launch Properties dialog for selecting all alerts in view via option specified
        /// </summary>
        /// <param name="alertViewPath">Path to Alert view</param>
        /// <param name="alertOptions">Option to launch dialog via R-click, Main Menu or Tasks pane</param>        
        /// <history>
        /// [v-yoz] 22June09 Created
        /// </history>
        public void GetMultipleAlertsProperties(
            string alertViewPath,
            Options alertOptions)
        {
            Utilities.LogMessage("AlertsView.GetMultipleAlertsProperties :: Create instance of grid control");

            // Create instance of Alert View Grid Control
            Mom.Test.UI.Core.Console.MomControls.GridControl viewGrid = null;
            int timeWaited = 0;
            int alertCount = 0;

            // Check the alert count
            alertCount = this.AlertRowCount(alertViewPath);

            Utilities.LogMessage("AlertsView.GetMultipleAlertsProperties :: Currently we have " +
                alertCount.ToString() +
                " rows");

            while (alertCount == 0 && timeWaited <= MaxWait)
            {
                alertCount = this.AlertRowCount(alertViewPath);

                Utilities.LogMessage("AlertsView.GetMultipleAlertsProperties :: " +
                    "New count is next number of alerts " +
                    alertCount.ToString());

                timeWaited = timeWaited + 2;

                if (alertCount == 0)
                {
                    // sleep for two seconds
                    Maui.Core.Utilities.Sleeper.Delay(2000);

                    CoreManager.MomConsole.Refresh();

                    consoleApp.Waiters.WaitForWindowIdle(this.consoleApp.MainWindow, Constants.OneMinute);
                }
            }

            // if there is still not Alerts, throw exception
            if (alertCount == 0)
            {
                Utilities.LogMessage("AlertsView.GetMultipleAlertsProperties :: Didn't find an alert in the grid ");

                throw new DataGrid.Exceptions.DataGridRowNotFoundException(
                    "AlertsView.GetMultipleAlertsProperties :: Failed to find row in the grid");
            }

            // Mom Console grid
            viewGrid = CoreManager.MomConsole.ViewPane.Grid;

            Core.Common.Utilities.LogMessage("AlertsView.GetMultipleAlertsProperties ::Select All alerts in the view by using send key.");
            CoreManager.MomConsole.ViewPane.Grid.Click();      
            CoreManager.MomConsole.ViewPane.Grid.SendKeys(KeyboardCodes.Ctrl + 'a');

            // Switch options to launch Alert Properties
            switch (alertOptions)
            {
                case Options.RightClickContextMenuOption:

                    // 1. R-click on alert and select context menu            

                    consoleApp.Waiters.WaitForWindowIdle(this.consoleApp.MainWindow, Constants.OneMinute);

                    CoreManager.MomConsole.ExecuteContextMenu(Strings.AlertPropertiesContextMenu, true);

                    Utilities.LogMessage("AlertView.GetMultipleAlertsProperties :: " +
                        "LaunchAlertPropertiesViaRightClick is done");

                    break;                

                case Options.MainMenuActionOption:

                    // 3. Actions main menu - Alert actions - Properties
                    Commands.Actions.Execute(this.consoleApp);

                    CoreManager.MomConsole.ExecuteContextMenu(
                        Strings.AlertActions +
                        Constants.PathDelimiter +
                        Strings.AlertPropertiesContextMenu,
                        false);

                    consoleApp.Waiters.WaitForWindowIdle(this.consoleApp.MainWindow, Constants.OneMinute);

                    Utilities.LogMessage("AlertView.GetMultipleAlertsProperties :: " +
                        "LaunchAlertPropertiesViaMainMenuClick is done");

                    break;

                case Options.TasksPaneActionOption:

                    // 4. Actions - Alert Propertis in tasks pane
                    // ClickLink(string actionsPaneNode, string linkToClick)
                    ActionsPane alertActionsPane = new ActionsPane(this.consoleApp);
                    alertActionsPane.ClickLink(Strings.AlertActions, Utilities.RemoveAcceleratorKeys(Strings.AlertPropertiesTask));

                    consoleApp.Waiters.WaitForWindowIdle(this.consoleApp.MainWindow, Constants.OneMinute);

                    Utilities.LogMessage("AlertView.GetMultipleAlertsProperties :: " +
                        "LaunchAlertPropertiesViaTasksPaneClick");

                    break;

                default:

                    Utilities.LogMessage("AlertView.GetMultipleAlertsProperties:: " +
                        "Invalid option to launch Alert Properties was passed");

                    break;
            }

            // Take a screenshot
            Utilities.TakeScreenshot("GetMultipleAlertsProperties");
        }
        #endregion

        #region Get Alert Properties Tab

        /// <summary>
        /// Click on Alert Properties General Tab
        /// </summary>
        public void GetAlertPropertiesGeneralTab()
        {
            this.alertPropertiesGeneralDialog.Controls.GeneralTabControl[Strings.General].Select();

            this.alertPropertiesGeneralDialog.Controls.GeneralTabControl.Click();

            this.alertPropertiesGeneralDialog.Extended.SetFocus();

            consoleApp.Waiters.WaitForWindowIdle(this.consoleApp.MainWindow, Constants.OneSecond * 10);
        }

        /// <summary>
        /// Click on Alert Properties Product Knowledge Tab
        /// </summary>
        public void GetAlertPropertiesProductKnowledgeTab()
        {
            this.alertPropertiesProductKnowledgeDialog.Controls.Tab1TabControl[Strings.ProductKnowledge].Select();

            this.alertPropertiesProductKnowledgeDialog.Controls.Tab1TabControl.Click();

            this.alertPropertiesProductKnowledgeDialog.Extended.SetFocus();

            consoleApp.Waiters.WaitForWindowIdle(this.consoleApp.MainWindow, Constants.OneSecond * 10);
        }

        /// <summary>
        /// Click on Alert Properties Company Knowledge Tab
        /// </summary>
        public void GetAlertPropertiesCompanyKnowledgeTab()
        {
            this.alertPropertiesCompanyKnowledgeDialog.Controls.Tab2TabControl[Strings.CompanyKnowledge].Select();

            this.alertPropertiesCompanyKnowledgeDialog.Controls.Tab2TabControl.Click();

            this.alertPropertiesCompanyKnowledgeDialog.Extended.SetFocus();

            consoleApp.Waiters.WaitForWindowIdle(this.consoleApp.MainWindow, Constants.OneSecond * 10);
        }

        /// <summary>
        /// Click on Alert Properties History Tab
        /// </summary>
        public void GetAlertPropertiesHistoryTab()
        {
            this.alertPropertiesHistoryDialog.Controls.Tab3TabControl[Strings.History].Select();

            this.alertPropertiesHistoryDialog.Controls.Tab3TabControl.Click();

            this.alertPropertiesHistoryDialog.Extended.SetFocus();

            consoleApp.Waiters.WaitForWindowIdle(this.consoleApp.MainWindow, Constants.OneSecond * 10);
        }

        /// <summary>
        /// Click on Alert Properties Alert Context Tab
        /// </summary>
        public void GetAlertPropertiesAlertContextTab()
        {
            this.alertPropertiesAlertContextDialog.Controls.Tab4TabControl[Strings.AlertContext].Select();

            this.alertPropertiesAlertContextDialog.Controls.Tab4TabControl.Click();

            this.alertPropertiesAlertContextDialog.Extended.SetFocus();

            consoleApp.Waiters.WaitForWindowIdle(this.consoleApp.MainWindow, Constants.OneSecond * 10);
        }

        /// <summary>
        /// Click on Alert Properties Custom Fields Tab
        /// </summary>
        public void GetAlertPropertiesCustomFieldsTab()
        {
            this.alertPropertiesCustomFieldsDialog.Controls.Tab5TabControl[Strings.CustomFields].Select();

            this.alertPropertiesCustomFieldsDialog.Controls.Tab5TabControl.Click();

            this.alertPropertiesCustomFieldsDialog.Extended.SetFocus();

            consoleApp.Waiters.WaitForWindowIdle(this.consoleApp.MainWindow, Constants.OneSecond * 10);
        }

        #endregion

        #region Set Alert Owner

        /// <summary>
        /// Method to set Alert Owner in the Alert Properites dialog
        /// </summary>
        /// <param name="parameters">Alert Parameters</param>
        public void SetAlertOwner(AlertsViewParameters parameters)
        {
            this.alertPropertiesGeneralDialog.Controls.GeneralTabControl[Strings.General].Select();

            this.alertPropertiesGeneralDialog.Controls.GeneralTabControl.Click();

            this.alertPropertiesGeneralDialog.Extended.SetFocus();

            if ((parameters.AlertOwner != null) && (parameters.ChangeAlertOwner == true))
            {
                Utilities.LogMessage(
                    "AlertsView.SetAlertOwner:: Currently this does not work");

                // this.alertPropertiesGeneralDialog.ClickChange();
            }

            // set Alert Owner if passed
            else if (parameters.AlertOwner != null)
            {
                Utilities.LogMessage("AlertsView.SetAlertOwner:: setting Alert Owner");

                this.alertPropertiesGeneralDialog.OwnerContentText = parameters.AlertOwner;

                Maui.Core.Utilities.Sleeper.Delay(1000);

                Utilities.LogMessage("AlertsView.SetAlertOwner:: Owner field right after setting is: '"
                    + this.alertPropertiesGeneralDialog.OwnerContentText.ToString() + "'");
            }
            else
            {
                Utilities.LogMessage("AlertsView.SetAlertOwner:: " + 
                    "Something went not right here, possibly the value was null.");
            }
        }
        #endregion

        #region Set Ticket ID

        /// <summary>
        /// Method to set Ticket ID in the Alert Properites dialog
        /// </summary>
        /// <param name="parameters">Alert Parameters</param>
        public void SetTicketID(AlertsViewParameters parameters)
        {
            this.alertPropertiesGeneralDialog.Controls.GeneralTabControl[Strings.General].Select();

            this.alertPropertiesGeneralDialog.Controls.GeneralTabControl.Click();

            this.alertPropertiesGeneralDialog.Extended.SetFocus();

            // set ticket ID if passed
            if (parameters.TicketId != null)
            {
                Utilities.LogMessage("AlertsView.SetTicketID:: setting Ticket ID");

                this.alertPropertiesGeneralDialog.TicketIDText = parameters.TicketId;

                Maui.Core.Utilities.Sleeper.Delay(1000);

                Utilities.LogMessage("AlertsView.SetTicketID:: Ticket Id field right after setting is: '"
                    + this.alertPropertiesGeneralDialog.TicketIDText.ToString() + "'");
            }
        }

        #endregion

        #region Set History Comment

        /// <summary>
        /// Method to set History Comment in the Alert Properites dialog
        /// </summary>
        /// <param name="parameters">Alert Parameters</param>
        public void SetHistoryComment(AlertsViewParameters parameters)
        {
            GetAlertPropertiesHistoryTab();

            // set History Comment if passed
            if (parameters.HistoryComment != null)
            {
                Utilities.LogMessage("AlertsView.SetHistoryComment:: setting History Comment");

                this.alertPropertiesHistoryDialog.HistoryCommentText = parameters.HistoryComment;

                Maui.Core.Utilities.Sleeper.Delay(1000);

                Utilities.LogMessage("AlertsView.SetHistoryComment:: History Comment field right after setting is: '"
                    + this.alertPropertiesHistoryDialog.HistoryCommentText.ToString() + "'");
            }
            else
            {
                Utilities.LogMessage("AlertsView.SetHistoryComment:: " +
                    "Something went not right here, possibly the value was null.");
            }
        }
        #endregion

        #region Create and Delete Custom Alert Resolution
        /// <summary>
        /// Creates custom alert resolution under Administration
        /// NOTE: Check for the unique ID == -1, means there was a problem
        /// </summary>
        /// <param name="customResolution">Custom Resolution string value</param>
        /// <returns>
        /// An integer representing the new custom resolution state value.
        /// </returns>
        /// <history>
        ///     [lucyra] 05OCT06 - Created        
        /// </history>
        public int CreateCustomAlertResolution(string customResolution)
        {
            int uniqueID = -1;

            try
            {
                // Navigate to Alert Global Settings
                Core.Console.GlobalSettings.GlobalSettingsView.NavigateToAlertGlobalSettingsDialog();

                // Call GlobalSettingsView method and pass it string and int to add a new alert resolution
                uniqueID = 
                    Core.Console.GlobalSettings.GlobalSettingsView.AddNewAlertResolutionState(
                        customResolution);

                Utilities.LogMessage(
                    "Unique ID of this resolution state is " +
                    uniqueID);

                if (uniqueID == -1)
                {
                    Utilities.LogMessage("There were problems creating new resolution state!");
                }
            }
            catch (Maui.GlobalExceptions.MauiException)
            {
                throw;
            }

            return uniqueID;
        }

        /// <summary>
        /// Deletes custom alert resolution under Administration
        /// </summary>
        /// <param name="customResolution">Custom Resolution string value</param>
        /// <history>
        ///     [lucyra] 05OCT06 - Created        
        /// </history>
        public void DeleteCustomAlertResolution(string customResolution)
        {
            try
            {
                // Navigate to Alert Global Settings
                Core.Console.GlobalSettings.GlobalSettingsView.NavigateToAlertGlobalSettingsDialog();

                // Call GlobalSettingsView method and pass it string to delete a custom alert resolution
                Core.Console.GlobalSettings.GlobalSettingsView.DeleteCustomAlertResolutionState(customResolution);
            }
            catch (Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException)
            {
                throw;
            }
            catch (Maui.GlobalExceptions.MauiException)
            {
                throw;
            }
        }

        #endregion

        #endregion        

        #region Private Methods

        /// <summary>
        /// Method to convert varmap string option into enum option
        /// </summary>
        /// <param name="option">String oprion that is read from the varmap</param>
        /// <returns>enum option</returns>
        /// <history>
        /// [lucyra] 18SEP06 Created
        /// </history>
        private Options GetOption(string option)
        {
            switch (option.ToUpper())
            {
                case "RIGHTCLICKCONTEXTMENUOPTION":
                    {
                        return Options.RightClickContextMenuOption;
                    }

                case "DOUBLECLICKOPTION":
                    {
                        return Options.DoubleClickOption;
                    }

                case "MAINMENUACTIONOPTION":
                    {
                        return Options.MainMenuActionOption;
                    }

                case "TASKSPANEACTIONOPTION":
                    {
                        return Options.TasksPaneActionOption;
                    }

                default:
                    {
                        return Options.RightClickContextMenuOption;
                    }
            } // end switch
        }

        #endregion

        #region Alerts View Parameters Class

        /// <summary>
        /// Alerts View Parameters Class
        /// </summary>
        public class AlertsViewParameters
        {
            #region Private Members

            /// <summary>
            /// Cached string containing the owner of the alert
            /// </summary>
            private string cachedAlertOwner = null;
            
            /// <summary>
            /// Cached string containing the ticket ID of the alert
            /// </summary>
            private string cachedTicketId = null;

            /// <summary>
            /// Cached string containing the history comment of the alert
            /// </summary>
            private string cachedHistoryComment = null;

         
            /// <summary>
            /// Cached flag indicating if the owner of the alert should be
            /// changed.
            /// </summary>
            private bool cachedChangeAlertOwner = false;

            #endregion

            #region Constructors

            /// <summary>
            /// Default Constructor - no need in ExePath etc. Inherited classes
            /// from Console set all required properties on parameter objects.
            /// </summary>
            public AlertsViewParameters()
            {
            }

            #endregion

            #region Properties

            /// <summary>
            /// Alert Owner
            /// </summary>
            public string AlertOwner
            {
                get
                {
                    return this.cachedAlertOwner;
                }

                set
                {
                    this.cachedAlertOwner = value;
                }
            }

            /// <summary>
            /// Ticket Id
            /// </summary>
            public string TicketId
            {
                get
                {
                    return this.cachedTicketId;
                }

                set
                {
                    this.cachedTicketId = value;
                }
            }

            /// <summary>
            /// History Comment
            /// </summary>
            public string HistoryComment
            {
                get
                {
                    return this.cachedHistoryComment;
                }

                set
                {
                    this.cachedHistoryComment = value;
                }
            }

            /// <summary>
            /// Change Alert Owner
            /// </summary>
            public bool ChangeAlertOwner
            {
                get
                {
                    return this.cachedChangeAlertOwner;
                }

                set
                {
                    this.cachedChangeAlertOwner = value;
                }
            }

            #endregion
        }

        #endregion

        #region Strings Class

        /// <summary>
        /// Strings Class
        /// </summary>
        /// <history>
        ///     [a-joelj]   27JAN09 Added a resource for "New" alert resolution state and cleaned up some other resources
        ///                         for readability.
        ///     [a-joelj]   19MAR09 Updated AlertPropertiesTask resource to correct string w/o hotkey and
        ///                         also added Rule and Monitor resource for proper target selection
        /// </history>
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Contains resource string for:  Alert Resolution State: Closed string value
            /// </summary>   
            private const string ResourceAlertResolutionStateClosedString =
                ";Closed" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources" +
                ";ResolutionState255";
            
            /// <summary>
            /// Contains resource string for:  Alert Resolution State: New string value
            /// </summary>   
            private const string ResourceAlertResolutionStateNewString =
                ";New" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources" +
                ";ResolutionState0";

            /// <summary>
            /// Contains resource string for:  Set Resolution State Context Menu item.
            /// </summary>   
            private const string ResourceSetResolutionStateContextMenu = 
                ";Set Resolution State" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources" +
                ";SetResolutionState";

            /// <summary>
            /// Contains resource string for:  Alert Properties Context Menu item.
            /// </summary>   
            private const string ResourceAlertPropertiesContextMenu = 
                ";P&roperties" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.ViewCommands" +
                ";PropertiesMenuText";

            /// <summary>
            /// Contains resource string for:  Alert Actions item.
            /// </summary>   
            private const string ResourceAlertActions = 
                ";Alert Actions" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources" +
                ";ActionGroupText";

            /// <summary>
            /// Contains resource string for:  Alert Properties Task item.
            /// </summary>   
            private const string ResourceAlertPropertiesTask =
                ";Alert Properties" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.UI.AlertPropertyDialog" +
                ";$this.Text";

             /// <summary>
            /// Contains resource string for:  General tab title.
            /// </summary>   
            private const string ResourceGeneral = 
                ";General" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.UI.AlertPropertyDialog" +
                ";generalTab.Text";

            /// <summary>
            /// Contains resource string for:  Product Knowledge tab title.
            /// </summary>   
            private const string ResourceProductKnowledge = 
                ";Product Knowledge" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.UI.AlertPropertyDialog" +
                ";knowledgeTab.Text";

            /// <summary>
            /// Contains resource string for:  Company Knowledge tab title.
            /// </summary>   
            private const string ResourceCompanyKnowledge = 
                ";Company Knowledge" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.UI.AlertPropertyDialog" +
                ";companyKnowedgeTab.Text";

            /// <summary>
            /// Contains resource string for:  History tab title.
            /// </summary>   
            private const string ResourceHistory = 
                ";History;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.UI.AlertPropertyDialog;" +
                "historyTab.Text";

            /// <summary>
            /// Contains resource string for:  Alert Context tab title.
            /// </summary>   
            private const string ResourceAlertContext = 
                ";Alert Context;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.UI.AlertPropertyDialog;" +
                "contextTab.Text";

            /// <summary>
            /// Contains resource string for:  Custom Fields tab title.
            /// </summary>   
            private const string ResourceCustomFields = 
                ";Custom Fields;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.UI.AlertPropertyDialog;" +
                "customFieldTab.Text";

            /// <summary>
            /// Contains resource string for:  Monitor column title.
            /// </summary>   
            private const string ResourceMonitorColumnTitle = 
                ";Monitor;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;" +
                "MonitorName";

            /// <summary>
            /// Contains resource string for:  Close this Alert context menu item
            /// </summary>   
            private const string ResourceCloseAlertContextMenu =
                ";Resolve this Alert;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;" +
                "ResolveAlertText";

            /// <summary>
            /// Contains resource string for:  Alert "Path" Column Title
            /// </summary>   
            private const string ResourceAlertPathColumnTitle =
                ";Path;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;" +
                "Path";

            /// <summary>
            /// Contains resource string for:  Alert "Name" Column Title
            /// </summary>   
            private const string ResourceAlertNameColumnTitle =
                ";Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;AlertName";

            /// <summary>
            /// Contains resource string for:  Alert Resolution State: New
            /// </summary>   
            private const string ResourceAlertResolutionStateNew =
                "0"; // ";New;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;ResolutionState0";

            /// <summary>
            /// Contains resource string for:  Alert Resolution State: Closed
            /// </summary>   
            private const string ResourceAlertResolutionStateClosed =
                "255"; // ";Resolved;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;ResolutionState255";

            /// <summary>
            /// Contains resource string for:  Column title Source
            /// </summary>   
            private const string ResourceSourceColumnTitle =
                ";Source;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;" +
                "Source";

            /// <summary>
            /// Contains resource string for: Column Title Resolution State
            /// </summary>
            private const string ResourceResolutionStateColumnTitle =
                ";Resolution State;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;" +
                "ResolutionState";

            /// <summary>
            /// Contains resource string for: Context Menu Overrides
            /// </summary>
            private const string ResourceOverridesContextMenu =
                ";O&verrides" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Overrides.OverridesResources" +
                ";Overrides";

            /// <summary>
            /// Contains resource string for: Context Menu Forward To
            /// </summary>
            private const string ResourceForwardToContextMenu =
                ";Forward to" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources" +
                ";ForwardTo";

            /// <summary>
            /// Contains resource string for: Context Menu Forward To
            /// </summary>
            private const string ResourceNotificationsContextMenu =
                ";Notification subscription" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";CommandNotificationsRoot";

            /// <summary>
            /// Contains resource string for: Context Menu Forward To
            /// </summary>
            private const string ResourceCreateSubscriptionContextMenu =
                ";Create..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";CommandNotificationsCreate";

            /// <summary>
            /// Contains resource string for: Context Menu Forward To
            /// </summary>
            private const string ResourceModifySubscriptionContextMenu =
                ";Modify..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";CommandNotificationsModify";

            #region Alert View criteria dialog titles

            /// <summary>
            /// Contains resource string for: With Specific Alert Name Dialog Title
            /// </summary>
            private const string ResourceAlertNameDialogTitle =
                ";Alert Name;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "NameEditTitle";

            /// <summary>
            /// Contains resource string for: With Specific Alert Description Dialog Title
            /// </summary>
            private const string ResourceAlertDescriptionDialogTitle =
                ";Description;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "DescriptionEditTitle";

            /// <summary>
            /// Contains resource string for: Assigned To Specific Alert Owner Dialog Title
            /// </summary>
            private const string ResourceAlertOwnerDialogTitle =
                ";Owner;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "OwnerEditTitle";

            /// <summary>
            /// Contains resource string for: Alert Rased By Instance with Specific Name Dialog Title
            /// </summary>
            private const string ResourceAlertInstanceNameDialogTitle =
                ";Instance Name;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "InstanceEditTitle";

            /// <summary>
            /// Contains resource string for: Alert Last Modified By a specific user Dialog Title
            /// </summary>
            private const string ResourceAlertLastModifiedByDialogTitle =
                ";Last Modified By;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "LastModifiedTitle";

            /// <summary>
            /// Contains resource string for: Alert Resolved By a specific user Dialog Title
            /// </summary>
            private const string ResourceAlertResolvedByDialogTitle =
                ";Resolved By;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "ResolvedByTitle";

            /// <summary>
            /// Contains resource string for: Alert with a specific Ticket ID Dialog Title
            /// </summary>
            private const string ResourceAlertTicketIdDialogTitle =
                ";Ticket ID;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "TicketIDTitle";

            /// <summary>
            /// Contains resource string for: Alert from a specific Site Dialog Title
            /// </summary>
            private const string ResourceAlertSiteDialogTitle =
                ";Site;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "SiteTitle";

            /// <summary>
            /// Contains resource string for: Alert with specific text in Custom Field 1 Dialog Title
            /// </summary>
            private const string ResourceAlertCustomField1DialogTitle =
                ";Custom Field 1;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "CustomField1EditTitle";

            /// <summary>
            /// Contains resource string for: Alert with specific text in Custom Field 2 Dialog Title
            /// </summary>
            private const string ResourceAlertCustomField2DialogTitle =
                ";Custom Field 2;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "CustomField2EditTitle";

            /// <summary>
            /// Contains resource string for: Alert with specific text in Custom Field 3 Dialog Title
            /// </summary>
            private const string ResourceAlertCustomField3DialogTitle =
                ";Custom Field 3;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "CustomField3EditTitle";

            /// <summary>
            /// Contains resource string for: Alert with specific text in Custom Field 4 Dialog Title
            /// </summary>
            private const string ResourceAlertCustomField4DialogTitle =
                ";Custom Field 4;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "CustomField4EditTitle";

            /// <summary>
            /// Contains resource string for: Alert with specific text in Custom Field 5 Dialog Title
            /// </summary>
            private const string ResourceAlertCustomField5DialogTitle =
                ";Custom Field 5;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "CustomField5EditTitle";

            /// <summary>
            /// Contains resource string for: Alert with specific text in Custom Field 6 Dialog Title
            /// </summary>
            private const string ResourceAlertCustomField6DialogTitle =
                ";Custom Field 6;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "CustomField6EditTitle";

            /// <summary>
            /// Contains resource string for: Alert with specific text in Custom Field 7 Dialog Title
            /// </summary>
            private const string ResourceAlertCustomField7DialogTitle =
                ";Custom Field 7;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "CustomField7EditTitle";

            /// <summary>
            /// Contains resource string for: Alert with specific text in Custom Field 8 Dialog Title
            /// </summary>
            private const string ResourceAlertCustomField8DialogTitle =
                ";Custom Field 8;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "CustomField8EditTitle";

            /// <summary>
            /// Contains resource string for: Alert with specific text in Custom Field 9 Dialog Title
            /// </summary>
            private const string ResourceAlertCustomField9DialogTitle =
                ";Custom Field 9;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "CustomField9EditTitle";

            /// <summary>
            /// Contains resource string for: Alert with specific text in Custom Field 10 Dialog Title
            /// </summary>
            private const string ResourceAlertCustomField10DialogTitle =
                ";Custom Field 10;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "CustomField10EditTitle";

            /// <summary>
            /// Contains resource string for: Alert created in a specific time period Dialog Title
            /// </summary>
            private const string ResourceAlertDateAndTimeGeneratedDialogTitle =
                ";Date and Time Generated;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "TimeCreatedEditTitle";

            /// <summary>
            /// Contains resource string for: Alert last modified in a specific time period Dialog Title
            /// </summary>
            private const string ResourceAlertLastModifiedTimeDialogTitle =
                ";Last Modified Time;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "LastModifiedTimeTitle";

            /// <summary>
            /// Contains resource string for: Alert that had its resolution state changed in a specific time period Dialog Title
            /// </summary>
            private const string ResourceAlertResolutionStateLastModifiedDialogTitle =
                ";Resolution State Last Modified;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "ResolutionStateLastModifiedTitle";

            /// <summary>
            /// Contains resource string for: Alert that was resolved (Closed)in a specific time period Dialog Title
            /// </summary>
            private const string ResourceAlertTimeResolvedDialogTitle =
                ";Time Resolved;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "TimeResolvedTitle";

            /// <summary>
            /// Contains resource string for: Alert that was added to the DB in a specific time period Dialog Title
            /// </summary>
            private const string ResourceAlertTimeAddedDialogTitle =
                ";Time Added;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "TimeAddedTitle";

            #endregion

            #region Alert View criteria 

            /// <summary>
            /// Contains resource string for:  (Alert) Of a (specific) severity view criteria
            /// </summary>   
            private const string ResourceOfASeverity =
                ";{0} of a {1} severity;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "ServerityText";

            /// <summary>
            /// Contains resource string for:  (Alert) Of a (specific) priority view criteria
            /// </summary>   
            private const string ResourceOfAPriority =
                ";{0} of a {1} priority;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "PriorityText";

            /// <summary>
            /// Contains resource string for:  (Alert) created by (specific) sources
            /// </summary>   
            private const string ResourceCreatedBySources =
                ";{0} created by {1} sources;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "SourceText";

            /// <summary>
            /// Contains resource string for:  (Alert) With (Specific) Resolution State
            /// </summary>   
            private const string ResourceWithResolutionState =
                ";{0} with {1} resolution state;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "ResolutionStateText";

            /// <summary>
            /// Contains resource string for:  (Alert) With (Specific) Name
            /// </summary>   
            private const string ResourceWithName =
                ";{0} with a {1} name;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "NameText";

            /// <summary>
            /// Contains resource string for:  (Alert) With (Specific) text in Description
            /// </summary>   
            private const string ResourceWithDescription =
                ";{0} with {1} text in the description;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "DescriptionText";

            /// <summary>
            /// Contains resource string for:  Created 
            /// (for string 'Created in specific time period' Alert view criteria)
            /// Concatinate with InSpecificTimePeriod string
            /// </summary>   
            private const string ResourceCreated =
                ";{0} created {1};ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "TimeCreatedText";

            /// <summary>
            /// Contains resource string for:  InSpecificTimePeriod 
            /// (for string 'Created in specific time period' Alert view criteria)
            /// </summary>   
            private const string ResourceInSpecificTimePeriod =
                ";in specific time period;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "TimeCreatedLink";

            /// <summary>
            /// Contains resource string for:  (Alert) With (Specific) Owner
            /// </summary>   
            private const string ResourceWithOwner =
                ";{0} assigned to a {1} owner;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "AssignedToText";

            /// <summary>
            /// Contains resource string for:  (Alert) Rased By Instance With (Specific) Name
            /// </summary>   
            private const string ResourceRasedByInstanceWithName =
                ";{0} raised by an instance with a {1} name;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "InstanceName";

            /// <summary>
            /// Contains resource string for:  (Alert) Last Modified By A (Specific) User
            /// </summary>   
            private const string ResourceLastModifiedByUser =
                ";{0} last modified by a {1} user;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "LastModifiedByText";

            /// <summary>
            /// Contains resource string for:  (Alert) That was modified
            /// Concatinate with InASpecificTimePeriod string
            /// (for string 'That Was Modified In A Specific Time Period')
            /// </summary>   
            private const string ResourceThatWasModified =
                ";{0} that was modified {1};ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "LastModifiedTimeText";

            /// <summary>
            /// Contains resource string for:  InASpecificTimePeriod
            /// (for string 'That Was Modified In A Specific Time Period')
            /// </summary>   
            private const string ResourceInASpecificTimePeriod =
                ";in a specific time period;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "LastModifiedTimeLink";

            /// <summary>
            /// Contains resource string for:  (Alert) Had its resolution state changed
            /// Concatinate with InASpecificTimePeriod string
            /// (for string 'Had its resolution state changed In A Specific Time Period')
            /// </summary>   
            private const string ResourceHadItsResolutionStateChanged =
                ";{0} had its resolution state changed {1};ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "ResolutionStateLastModifiedText";

            /// <summary>
            /// Contains resource string for:  InASpecificTimePeriod
            /// (for string 'Had its resolution state changed In A Specific Time Period')
            /// </summary>   
            private const string ResourceInASpecificTimePeriodA =
                ";in a specific time period;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "ResolutionStateLastModifiedLink";

            /// <summary>
            /// Contains resource string for:  (Alert) That was resolved (Closed)
            /// Concatinate with InASpecificTimePeriod string
            /// (for string 'That Was Resolved In A Specific Time Period')
            /// </summary>   
            private const string ResourceThatWasResolved =
                ";{0} that was resolved {1};ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "TimeResolvedText";

            /// <summary>
            /// Contains resource string for:  InASpecificTimePeriod
            /// (for string 'That Was Resolved In A Specific Time Period')
            /// </summary>   
            private const string ResourceInASpecificTimePeriodB =
                ";in a specific time period;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "TimeResolvedLink";

            /// <summary>
            /// Contains resource string for:  (Alert) Resolved By (Specific) User
            /// </summary>   
            private const string ResourceResolvedByUser =
                ";{0} resolved by {1} user;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "ResolvedByText";

            /// <summary>
            /// Contains resource string for:  (Alert) With a (Specific) Ticket ID
            /// </summary>   
            private const string ResourceWithTicketID =
                ";{0} with a {1} ticket ID;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "TicketIDText";

            /// <summary>
            /// Contains resource string for:  (Alert) was added to the database
            /// Concatinate with InASpecificTimePeriod string
            /// (for string 'Was Added To The Database In A Specific Time Period')
            /// </summary>   
            private const string ResourceWasAddedToTheDatabase =
                ";{0} was added to the database {1};ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "TimeAddedText";

            /// <summary>
            /// Contains resource string for:  InASpecificTimePeriod
            /// (for string 'Was Added To The Database In A Specific Time Period')
            /// </summary>   
            private const string ResourceInASpecificTimePeriodC =
                ";in a specific time period;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "TimeAddedLink";

            /// <summary>
            /// Contains resource string for:  (Alert) from a (Specific) Site
            /// </summary>   
            private const string ResourceFromSite =
                ";{0} from a {1} site;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "SiteText";

            /// <summary>
            /// Contains resource string for:  (Alert) with (specific) text in (Custom Field)
            /// Concatinate with 'specific' string
            /// Concatinate with 'Custom Field' string
            /// Concatinate with number 1-10 depending on Custom Field
            /// (for string 'with (specific) text in (Custom Field)(1-10)')
            /// </summary>   
            private const string ResourceWithTextIn =
                ";{0} with {1} text in {2};ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "CustomFieldText";

            /// <summary>
            /// Contains resource string for:  Custom Field
            /// (for string 'with (specific) text in (Custom Field)(1-10)')
            /// </summary>   
            private const string ResourceCustomField =
                ";Custom Field;ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "CustomField";

            /// <summary>
            /// Contains resource string for:  (Rule) source format
            /// </summary> 
            private const string ResourceRuleSourceFormat =
                ";{0} (Rule);" +
                "ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "RuleSourceFormat";

            /// <summary>
            /// Contains resource string for:  (Monitor) source format
            /// </summary> 
            private const string ResourceMonitorSourceFormat =
                ";{0} (Monitor);" +
                "ManagedString;Microsoft.MOM.UI.Components.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertViewCriteriaResource;" +
                "MonitorSourceFormat";


            #endregion //end of Alert View criteria

            #endregion

            #region Member Variables

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedAlertResolutionStateNewString
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertResolutionStateNewString;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedAlertResolutionStateClosedString
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertResolutionStateClosedString;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedSetResolutionStateContextMenu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSetResolutionStateContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedAlertPropertiesContextMenu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertPropertiesContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedAlertActions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertActions;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedAlertPropertiesTask
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertPropertiesTask;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedGeneral
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedProductKnowledge
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProductKnowledge;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedCompanyKnowledge
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCompanyKnowledge;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedHistory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHistory;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedAlertContext
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertContext;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedCustomFields
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomFields;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedMonitorColumnTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorColumnTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Context Menu Close alert
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCloseAlertContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Alert "Path" Column Title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertPathColumnTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Alert "Name" Column Title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertNameColumnTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Alert Resolution State: New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertResolutionStateNew;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Alert Resolution State: Closed
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertResolutionStateClosed;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  View Column header for Source
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSourceColumnTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  View Column header for Resolution State
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResolutionStateColumnTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  View Context Menu Overrides
            /// </summary>
            /// -----------------------------------------------------------------------------            
            private static string cachedOverridesContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  View Context Menu Forward To
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedForwardToContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  View Context Menu Notifications
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNotificationsContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  View Context Menu Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreateSubscriptionContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  View Context Menu Modify
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedModifySubscriptionContextMenu;

            #region Alert View criteria dialog titles

            /// <summary>
            /// Caches the translated resource string for: Alert Name Dialog Title
            /// </summary>
            private static string cachedAlertNameDialogTitle;

            /// <summary>
            /// Caches the translated resource string for:  With Specific Alert Description Dialog Title
            /// </summary>
            private static string cachedAlertDescriptionDialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Assigned To Specific Alert Owner Dialog Title
            /// </summary>
            private static string cachedAlertOwnerDialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert Rased By Instance with Specific Name Dialog Title
            /// </summary>
            private static string cachedAlertInstanceNameDialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert Last Modified By a specific user Dialog Title
            /// </summary>
            private static string cachedAlertLastModifiedByDialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert Resolved By a specific user Dialog Title
            /// </summary>
            private static string cachedAlertResolvedByDialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert with a specific Ticket ID Dialog Title
            /// </summary>
            private static string cachedAlertTicketIdDialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert from a specific Site Dialog Title
            /// </summary>
            private static string cachedAlertSiteDialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert with specific text in Custom Field 1 Dialog Title
            /// </summary>
            private static string cachedAlertCustomField1DialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert with specific text in Custom Field 2 Dialog Title
            /// </summary>
            private static string cachedAlertCustomField2DialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert with specific text in Custom Field 3 Dialog Title
            /// </summary>
            private static string cachedAlertCustomField3DialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert with specific text in Custom Field 4 Dialog Title
            /// </summary>
            private static string cachedAlertCustomField4DialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert with specific text in Custom Field 5 Dialog Title
            /// </summary>
            private static string cachedAlertCustomField5DialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert with specific text in Custom Field 6 Dialog Title
            /// </summary>
            private static string cachedAlertCustomField6DialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert with specific text in Custom Field 7 Dialog Title
            /// </summary>
            private static string cachedAlertCustomField7DialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert with specific text in Custom Field 8 Dialog Title
            /// </summary>
            private static string cachedAlertCustomField8DialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert with specific text in Custom Field 9 Dialog Title
            /// </summary>
            private static string cachedAlertCustomField9DialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert with specific text in Custom Field 10 Dialog Title
            /// </summary>
            private static string cachedAlertCustomField10DialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert created in a specific time period Dialog Title
            /// </summary>
            private static string cachedAlertDateAndTimeGeneratedDialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert last modified in a specific time period Dialog Title
            /// </summary>
            private static string cachedAlertLastModifiedTimeDialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert that had its resolution state changed in a specific time period Dialog Title
            /// </summary>
            private static string cachedAlertResolutionStateLastModifiedDialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert that was resolved (Closed)in a specific time period Dialog Title
            /// </summary>
            private static string cachedAlertTimeResolvedDialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Alert that was added to the DB in a specific time period Dialog Title
            /// </summary>
            private static string cachedAlertTimeAddedDialogTitle;

            #endregion

            #region Alert View criteria

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OfASeverity view criteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOfASeverity;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OfAPriority view criteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOfAPriority;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CreatedBySources view criteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreatedBySources;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WithResolutionState view criteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWithResolutionState;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WithName view criteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWithName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WithDescription view criteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWithDescription;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Created
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreated;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: InSpecificTimePeriod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInSpecificTimePeriod;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: WithOwner
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWithOwner;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: RasedByInstanceWithName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRasedByInstanceWithName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: LastModifiedByUser
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLastModifiedByUser;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: ThatWasModified
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThatWasModified;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: InASpecificTimePeriod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInASpecificTimePeriod;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: HadItsResolutionStateChanged
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHadItsResolutionStateChanged;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: InASpecificTimePeriodA
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInASpecificTimePeriodA;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: ThatWasResolved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThatWasResolved;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: InASpecificTimePeriodB
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInASpecificTimePeriodB;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: ResolvedByUser
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResolvedByUser;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: WithTicketID
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWithTicketID;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: WasAddedToTheDatabase
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWasAddedToTheDatabase;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: InASpecificTimePeriodC
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInASpecificTimePeriodC;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: FromSite
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFromSite;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: WithTextIn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWithTextIn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: CustomField
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCustomField;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: (Rule)
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRuleSourceFormat;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: (Monitor)
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorSourceFormat;
            

            #endregion //end of Alert View criteria

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Resolution State "New" String
            /// </summary>
            /// <history>
            /// 	[a-joelj] 27JAN09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertResolutionStateNewString
            {
                get
                {
                    if ((cachedAlertResolutionStateNewString == null))
                    {
                        cachedAlertResolutionStateNewString =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertResolutionStateNewString);
                    }

                    return cachedAlertResolutionStateNewString;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Resolution State "Closed" String
            /// </summary>
            /// <history>
            /// 	[lucyra] 09OCT06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertResolutionStateClosedString
            {
                get
                {
                    if ((cachedAlertResolutionStateClosedString == null))
                    {
                        cachedAlertResolutionStateClosedString = 
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertResolutionStateClosedString);
                    }

                    return cachedAlertResolutionStateClosedString;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Set Resolution State Context Menu
            /// </summary>
            /// <history>
            /// 	[lucyra] 05OCT06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SetResolutionStateContextMenu
            {
                get
                {
                    if ((cachedSetResolutionStateContextMenu == null))
                    {
                        cachedSetResolutionStateContextMenu = 
                            CoreManager.MomConsole.GetIntlStr(ResourceSetResolutionStateContextMenu);
                    }

                    return cachedSetResolutionStateContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Properties Context Menu
            /// </summary>
            /// <history>
            /// 	[lucyra] 18SEP06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertPropertiesContextMenu
            {
                get
                {
                    if ((cachedAlertPropertiesContextMenu == null))
                    {
                        cachedAlertPropertiesContextMenu = 
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertPropertiesContextMenu);
                    }

                    return cachedAlertPropertiesContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Actions Context Menu
            /// </summary>
            /// <history>
            /// 	[lucyra] 18SEP06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertActions
            {
                get
                {
                    if ((cachedAlertActions == null))
                    {
                        cachedAlertActions = CoreManager.MomConsole.GetIntlStr(ResourceAlertActions);
                    }

                    return cachedAlertActions;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Properties Task
            /// </summary>
            /// <history>
            /// 	[lucyra] 18SEP06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertPropertiesTask
            {
                get
                {
                    if ((cachedAlertPropertiesTask == null))
                    {
                        cachedAlertPropertiesTask = 
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertPropertiesTask);
                    }

                    return cachedAlertPropertiesTask;
                }
            }

            #region Alert Properties dialog titles
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the General tab of Alert Properties dialog
            /// </summary>
            /// <history>
            /// 	[lucyra] 18SEP06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string General
            {
                get
                {
                    if ((cachedGeneral == null))
                    {
                        cachedGeneral = CoreManager.MomConsole.GetIntlStr(ResourceGeneral);
                    }

                    return cachedGeneral;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Product Knowledge tab of Alert Properties dialog
            /// </summary>
            /// <history>
            /// 	[lucyra] 18SEP06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProductKnowledge
            {
                get
                {
                    if ((cachedProductKnowledge == null))
                    {
                        cachedProductKnowledge = CoreManager.MomConsole.GetIntlStr(ResourceProductKnowledge);
                    }

                    return cachedProductKnowledge;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Company Knowledge tab of Alert Properties dialog
            /// </summary>
            /// <history>
            /// 	[lucyra] 18SEP06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CompanyKnowledge
            {
                get
                {
                    if ((cachedCompanyKnowledge == null))
                    {
                        cachedCompanyKnowledge = CoreManager.MomConsole.GetIntlStr(ResourceCompanyKnowledge);
                    }

                    return cachedCompanyKnowledge;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the History tab of Alert Properties dialog
            /// </summary>
            /// <history>
            /// 	[lucyra] 18SEP06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string History
            {
                get
                {
                    if ((cachedHistory == null))
                    {
                        cachedHistory = CoreManager.MomConsole.GetIntlStr(ResourceHistory);
                    }

                    return cachedHistory;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Context tab of Alert Properties dialog
            /// </summary>
            /// <history>
            /// 	[lucyra] 18SEP06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertContext
            {
                get
                {
                    if ((cachedAlertContext == null))
                    {
                        cachedAlertContext = CoreManager.MomConsole.GetIntlStr(ResourceAlertContext);
                    }

                    return cachedAlertContext;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Custom Fields tab of Alert Properties dialog
            /// </summary>
            /// <history>
            /// 	[lucyra] 18SEP06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomFields
            {
                get
                {
                    if ((cachedCustomFields == null))
                    {
                        cachedCustomFields = CoreManager.MomConsole.GetIntlStr(ResourceCustomFields);
                    }

                    return cachedCustomFields;
                }
            }
            #endregion //end of Alert Properties dialog titles

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitor Column Title item
            /// </summary>
            /// <history>
            /// 	[mbickle] 30APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorColumnTitle
            {
                get
                {
                    if ((cachedMonitorColumnTitle == null))
                    {
                        cachedMonitorColumnTitle = 
                            CoreManager.MomConsole.GetIntlStr(ResourceMonitorColumnTitle);
                    }

                    return cachedMonitorColumnTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Views Alert View item
            /// </summary>
            /// <history>
            /// 	[lucyra] 25APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CloseAlertContextMenu
            {
                get
                {
                    if ((cachedCloseAlertContextMenu == null))
                    {
                        cachedCloseAlertContextMenu = 
                            CoreManager.MomConsole.GetIntlStr(ResourceCloseAlertContextMenu);
                    }

                    return cachedCloseAlertContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert "Path" Column Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 25APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertPathColumnTitle
            {
                get
                {
                    if ((cachedAlertPathColumnTitle == null))
                    {
                        cachedAlertPathColumnTitle = 
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertPathColumnTitle);
                    }

                    return cachedAlertPathColumnTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert "Name" Column Title
            /// </summary>
            /// <history>
            /// 	[ruhim] 26May08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertNameColumnTitle
            {
                get
                {
                    if ((cachedAlertNameColumnTitle == null))
                    {
                        cachedAlertNameColumnTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertNameColumnTitle);
                    }

                    return cachedAlertNameColumnTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Resolution State : New
            /// </summary>
            /// <history>
            /// 	[lucyra] 25APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertResolutionStateNew
            {
                get
                {
                    if ((cachedAlertResolutionStateNew == null))
                    {
                        cachedAlertResolutionStateNew = 
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertResolutionStateNew);
                    }

                    return cachedAlertResolutionStateNew;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Resolution State : Closed
            /// </summary>
            /// <history>
            /// 	[lucyra] 25APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertResolutionStateClosed
            {
                get
                {
                    if ((cachedAlertResolutionStateClosed == null))
                    {
                        cachedAlertResolutionStateClosed = 
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertResolutionStateClosed);
                    }

                    return cachedAlertResolutionStateClosed;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Source Column Title item
            /// </summary>
            /// <history>
            /// 	[lucyra] 25APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SourceColumnTitle
            {
                get
                {
                    if ((cachedSourceColumnTitle == null))
                    {
                        cachedSourceColumnTitle = 
                            CoreManager.MomConsole.GetIntlStr(ResourceSourceColumnTitle);
                    }

                    return cachedSourceColumnTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Resolution State Column Title item
            /// </summary>
            /// <history>
            /// 	[lucyra] 25APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ResolutionStateColumnTitle
            {
                get
                {
                    if ((cachedResolutionStateColumnTitle == null))
                    {
                        cachedResolutionStateColumnTitle = 
                            CoreManager.MomConsole.GetIntlStr(ResourceResolutionStateColumnTitle);
                    }

                    return cachedResolutionStateColumnTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Overrides Context Menu item
            /// </summary>
            /// <history>
            /// 	[kellymor] 29MAY08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OverridesContextMenu
            {
                get
                {
                    if ((cachedOverridesContextMenu == null))
                    {
                        cachedOverridesContextMenu =
                            CoreManager.MomConsole.GetIntlStr(ResourceOverridesContextMenu);
                    }

                    return cachedOverridesContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Forward To Context Menu item
            /// </summary>
            /// <history>
            /// 	[kellymor] 29MAY08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ForwardToContextMenu
            {
                get
                {
                    if ((cachedForwardToContextMenu == null))
                    {
                        cachedForwardToContextMenu =
                            CoreManager.MomConsole.GetIntlStr(ResourceForwardToContextMenu);
                    }

                    return cachedForwardToContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Notifications Context Menu item
            /// </summary>
            /// <history>
            /// 	[kellymor] 28OCT08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotificationsContextMenu
            {
                get
                {
                    if ((cachedNotificationsContextMenu == null))
                    {
                        cachedNotificationsContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceNotificationsContextMenu);
                    }

                    return cachedNotificationsContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Create Context Menu item
            /// </summary>
            /// <history>
            /// 	[kellymor] 28OCT08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreateSubscriptionContextMenu
            {
                get
                {
                    if ((cachedCreateSubscriptionContextMenu == null))
                    {
                        cachedCreateSubscriptionContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCreateSubscriptionContextMenu);
                    }

                    return cachedCreateSubscriptionContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Modify Context Menu item
            /// </summary>
            /// <history>
            /// 	[kellymor] 28OCT08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ModifySubscriptionContextMenu
            {
                get
                {
                    if ((cachedModifySubscriptionContextMenu == null))
                    {
                        cachedModifySubscriptionContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceModifySubscriptionContextMenu);
                    }

                    return cachedModifySubscriptionContextMenu;
                }
            }

            #region Alert View criteria dialog titles

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Name Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertNameDialogTitle
            {
                get
                {
                    if ((cachedAlertNameDialogTitle == null))
                    {
                        cachedAlertNameDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertNameDialogTitle);
                    }

                    return cachedAlertNameDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Description Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertDescriptionDialogTitle
            {
                get
                {
                    if ((cachedAlertDescriptionDialogTitle == null))
                    {
                        cachedAlertDescriptionDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertDescriptionDialogTitle);
                    }

                    return cachedAlertDescriptionDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Owner Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertOwnerDialogTitle
            {
                get
                {
                    if ((cachedAlertOwnerDialogTitle == null))
                    {
                        cachedAlertOwnerDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertOwnerDialogTitle);
                    }

                    return cachedAlertOwnerDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Instance Name Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertInstanceNameDialogTitle
            {
                get
                {
                    if ((cachedAlertInstanceNameDialogTitle == null))
                    {
                        cachedAlertInstanceNameDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertInstanceNameDialogTitle);
                    }

                    return cachedAlertInstanceNameDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Last Modified By Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertLastModifiedByDialogTitle
            {
                get
                {
                    if ((cachedAlertLastModifiedByDialogTitle == null))
                    {
                        cachedAlertLastModifiedByDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertLastModifiedByDialogTitle);
                    }

                    return cachedAlertLastModifiedByDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Resolved By Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertResolvedByDialogTitle
            {
                get
                {
                    if ((cachedAlertResolvedByDialogTitle == null))
                    {
                        cachedAlertResolvedByDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertResolvedByDialogTitle);
                    }

                    return cachedAlertResolvedByDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Ticket Id Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertTicketIdDialogTitle
            {
                get
                {
                    if ((cachedAlertTicketIdDialogTitle == null))
                    {
                        cachedAlertTicketIdDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertTicketIdDialogTitle);
                    }

                    return cachedAlertTicketIdDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Site Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertSiteDialogTitle
            {
                get
                {
                    if ((cachedAlertSiteDialogTitle == null))
                    {
                        cachedAlertSiteDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertSiteDialogTitle);
                    }

                    return cachedAlertSiteDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Custom Field 1 Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertCustomField1DialogTitle
            {
                get
                {
                    if ((cachedAlertCustomField1DialogTitle == null))
                    {
                        cachedAlertCustomField1DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertCustomField1DialogTitle);
                    }

                    return cachedAlertCustomField1DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Custom Field 2 Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertCustomField2DialogTitle
            {
                get
                {
                    if ((cachedAlertCustomField2DialogTitle == null))
                    {
                        cachedAlertCustomField2DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertCustomField2DialogTitle);
                    }

                    return cachedAlertCustomField2DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Custom Field 3 Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertCustomField3DialogTitle
            {
                get
                {
                    if ((cachedAlertCustomField3DialogTitle == null))
                    {
                        cachedAlertCustomField3DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertCustomField3DialogTitle);
                    }

                    return cachedAlertCustomField3DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Custom Field 4 Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertCustomField4DialogTitle
            {
                get
                {
                    if ((cachedAlertCustomField4DialogTitle == null))
                    {
                        cachedAlertCustomField4DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertCustomField4DialogTitle);
                    }

                    return cachedAlertCustomField4DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Custom Field 5 Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertCustomField5DialogTitle
            {
                get
                {
                    if ((cachedAlertCustomField5DialogTitle == null))
                    {
                        cachedAlertCustomField5DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertCustomField5DialogTitle);
                    }

                    return cachedAlertCustomField5DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Custom Field 6 Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertCustomField6DialogTitle
            {
                get
                {
                    if ((cachedAlertCustomField6DialogTitle == null))
                    {
                        cachedAlertCustomField6DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertCustomField6DialogTitle);
                    }

                    return cachedAlertCustomField6DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Custom Field 7 Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertCustomField7DialogTitle
            {
                get
                {
                    if ((cachedAlertCustomField7DialogTitle == null))
                    {
                        cachedAlertCustomField7DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertCustomField7DialogTitle);
                    }

                    return cachedAlertCustomField7DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Custom Field 8 Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertCustomField8DialogTitle
            {
                get
                {
                    if ((cachedAlertCustomField8DialogTitle == null))
                    {
                        cachedAlertCustomField8DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertCustomField8DialogTitle);
                    }

                    return cachedAlertCustomField8DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Custom Field 9 Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertCustomField9DialogTitle
            {
                get
                {
                    if ((cachedAlertCustomField9DialogTitle == null))
                    {
                        cachedAlertCustomField9DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertCustomField9DialogTitle);
                    }

                    return cachedAlertCustomField9DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Custom Field 10 Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertCustomField10DialogTitle
            {
                get
                {
                    if ((cachedAlertCustomField10DialogTitle == null))
                    {
                        cachedAlertCustomField10DialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertCustomField10DialogTitle);
                    }

                    return cachedAlertCustomField10DialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Date And Time Generated Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertDateAndTimeGeneratedDialogTitle
            {
                get
                {
                    if ((cachedAlertDateAndTimeGeneratedDialogTitle == null))
                    {
                        cachedAlertDateAndTimeGeneratedDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertDateAndTimeGeneratedDialogTitle);
                    }

                    return cachedAlertDateAndTimeGeneratedDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Last Modified Time Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertLastModifiedTimeDialogTitle
            {
                get
                {
                    if ((cachedAlertLastModifiedTimeDialogTitle == null))
                    {
                        cachedAlertLastModifiedTimeDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertLastModifiedTimeDialogTitle);
                    }

                    return cachedAlertLastModifiedTimeDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Resolution State Last Modified Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertResolutionStateLastModifiedDialogTitle
            {
                get
                {
                    if ((cachedAlertResolutionStateLastModifiedDialogTitle == null))
                    {
                        cachedAlertResolutionStateLastModifiedDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertResolutionStateLastModifiedDialogTitle);
                    }

                    return cachedAlertResolutionStateLastModifiedDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Time Resolved Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertTimeResolvedDialogTitle
            {
                get
                {
                    if ((cachedAlertTimeResolvedDialogTitle == null))
                    {
                        cachedAlertTimeResolvedDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertTimeResolvedDialogTitle);
                    }

                    return cachedAlertTimeResolvedDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Time Added Dialog Title
            /// </summary>
            /// <history>
            /// 	[lucyra] 22MAR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertTimeAddedDialogTitle
            {
                get
                {
                    if ((cachedAlertTimeAddedDialogTitle == null))
                    {
                        cachedAlertTimeAddedDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlertTimeAddedDialogTitle);
                    }

                    return cachedAlertTimeAddedDialogTitle;
                }
            }

            #endregion

            #region Alert View criteria
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Of A Severity view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 12APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OfASeverity
            {
                get
                {
                    if ((cachedOfASeverity == null))
                    {
                        cachedOfASeverity = 
                            CoreManager.MomConsole.GetIntlStr(ResourceOfASeverity);
                    }

                    return cachedOfASeverity;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Of A Priority view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 17APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OfAPriority
            {
                get
                {
                    if ((cachedOfAPriority == null))
                    {
                        cachedOfAPriority = 
                            CoreManager.MomConsole.GetIntlStr(ResourceOfAPriority);
                    }

                    return cachedOfAPriority;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Created By Sources view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 17APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreatedBySources
            {
                get
                {
                    if ((cachedCreatedBySources == null))
                    {
                        cachedCreatedBySources = 
                            CoreManager.MomConsole.GetIntlStr(ResourceCreatedBySources);
                    }

                    return cachedCreatedBySources;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the '(Alert) With (Specific) Resolution State' view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WithResolutionState
            {
                get
                {
                    if ((cachedWithResolutionState == null))
                    {
                        cachedWithResolutionState = 
                            CoreManager.MomConsole.GetIntlStr(ResourceWithResolutionState);
                    }

                    return cachedWithResolutionState;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the '(Alert) With (Specific) Name' view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WithName
            {
                get
                {
                    if ((cachedWithName == null))
                    {
                        cachedWithName = CoreManager.MomConsole.GetIntlStr(ResourceWithName);
                    }

                    return cachedWithName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the '(Alert) With (Specific) text in Description' view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WithDescription
            {
                get
                {
                    if ((cachedWithDescription == null))
                    {
                        cachedWithDescription = 
                            CoreManager.MomConsole.GetIntlStr(ResourceWithDescription);
                    }

                    return cachedWithDescription;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the 'Created in specific time period' view criteria item
            /// (Concatinate with InSpecificTimePeriod string)
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Created 
            {
                get
                {
                    if ((cachedCreated == null))
                    {
                        cachedCreated = CoreManager.MomConsole.GetIntlStr(ResourceCreated);
                    }

                    return cachedCreated;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the 'Created in specific time period' view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InSpecificTimePeriod
            {
                get
                {
                    if ((cachedInSpecificTimePeriod == null))
                    {
                        cachedInSpecificTimePeriod = 
                            CoreManager.MomConsole.GetIntlStr(ResourceInSpecificTimePeriod);
                    }

                    return cachedInSpecificTimePeriod;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the '(Alert) With (Specific) Owner' view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WithOwner
            {
                get
                {
                    if ((cachedWithOwner == null))
                    {
                        cachedWithOwner = CoreManager.MomConsole.GetIntlStr(ResourceWithOwner);
                    }

                    return cachedWithOwner;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the '(Alert) Rased By Instance With (Specific) Name' view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RasedByInstanceWithName
            {
                get
                {
                    if ((cachedRasedByInstanceWithName == null))
                    {
                        cachedRasedByInstanceWithName = 
                            CoreManager.MomConsole.GetIntlStr(ResourceRasedByInstanceWithName);
                    }

                    return cachedRasedByInstanceWithName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the '(Alert) Last Modified By A (Specific) User' view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LastModifiedByUser
            {
                get
                {
                    if ((cachedLastModifiedByUser == null))
                    {
                        cachedLastModifiedByUser =
                            CoreManager.MomConsole.GetIntlStr(ResourceLastModifiedByUser);
                    }

                    return cachedLastModifiedByUser;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the 'That Was Modified In A Specific Time Period' view criteria item
            /// (Concatinate with InASpecificTimePeriod string)
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThatWasModified
            {
                get
                {
                    if ((cachedThatWasModified == null))
                    {
                        cachedThatWasModified =
                            CoreManager.MomConsole.GetIntlStr(ResourceThatWasModified);
                    }

                    return cachedThatWasModified;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the 'That Was Modified In A Specific Time Period' view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InASpecificTimePeriod
            {
                get
                {
                    if ((cachedInASpecificTimePeriod == null))
                    {
                        cachedInASpecificTimePeriod =
                            CoreManager.MomConsole.GetIntlStr(ResourceInASpecificTimePeriod);
                    }

                    return cachedInASpecificTimePeriod;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the 'Had its resolution state changed In A Specific Time Period' view criteria item
            /// (Concatinate with InASpecificTimePeriodA string)
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HadItsResolutionStateChanged
            {
                get
                {
                    if ((cachedHadItsResolutionStateChanged == null))
                    {
                        cachedHadItsResolutionStateChanged =
                            CoreManager.MomConsole.GetIntlStr(ResourceHadItsResolutionStateChanged);
                    }

                    return cachedHadItsResolutionStateChanged;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the 'Had its resolution state changed In A Specific Time Period' view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InASpecificTimePeriodA
            {
                get
                {
                    if ((cachedInASpecificTimePeriodA == null))
                    {
                        cachedInASpecificTimePeriodA =
                            CoreManager.MomConsole.GetIntlStr(ResourceInASpecificTimePeriodA);
                    }

                    return cachedInASpecificTimePeriodA;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the 'That Was Resolved(Closed) In A Specific Time Period' view criteria item
            /// (Concatinate with InASpecificTimePeriodB string)
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThatWasResolved
            {
                get
                {
                    if ((cachedThatWasResolved == null))
                    {
                        cachedThatWasResolved =
                            CoreManager.MomConsole.GetIntlStr(ResourceThatWasResolved);
                    }

                    return cachedThatWasResolved;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the 'That Was Resolved(Closed)In A Specific Time Period' view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InASpecificTimePeriodB
            {
                get
                {
                    if ((cachedInASpecificTimePeriodB == null))
                    {
                        cachedInASpecificTimePeriodB =
                            CoreManager.MomConsole.GetIntlStr(ResourceInASpecificTimePeriodB);
                    }

                    return cachedInASpecificTimePeriodB;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the '(Alert) Resolved By (Specific) User' view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ResolvedByUser
            {
                get
                {
                    if ((cachedResolvedByUser == null))
                    {
                        cachedResolvedByUser =
                            CoreManager.MomConsole.GetIntlStr(ResourceResolvedByUser);
                    }

                    return cachedResolvedByUser;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the '(Alert) With a (Specific) Ticket ID' view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WithTicketID
            {
                get
                {
                    if ((cachedWithTicketID == null))
                    {
                        cachedWithTicketID =
                            CoreManager.MomConsole.GetIntlStr(ResourceWithTicketID);
                    }

                    return cachedWithTicketID;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the 'Was Added To The Database In A Specific Time Period' view criteria item
            /// (Concatinate with InASpecificTimePeriodC string)
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WasAddedToTheDatabase
            {
                get
                {
                    if ((cachedWasAddedToTheDatabase == null))
                    {
                        cachedWasAddedToTheDatabase =
                            CoreManager.MomConsole.GetIntlStr(ResourceWasAddedToTheDatabase);
                    }

                    return cachedWasAddedToTheDatabase;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the 'Was Added To The Database In A Specific Time Period' view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InASpecificTimePeriodC
            {
                get
                {
                    if ((cachedInASpecificTimePeriodC == null))
                    {
                        cachedInASpecificTimePeriodC =
                            CoreManager.MomConsole.GetIntlStr(ResourceInASpecificTimePeriodC);
                    }

                    return cachedInASpecificTimePeriodC;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the '(Alert) from a (Specific) Site' view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FromSite
            {
                get
                {
                    if ((cachedFromSite == null))
                    {
                        cachedFromSite =
                            CoreManager.MomConsole.GetIntlStr(ResourceFromSite);
                    }

                    return cachedFromSite;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the 'with (specific) text in (Custom Field)(1-10)' view criteria item
            /// Concatinate with 'specific' string
            /// Concatinate with 'Custom Field' string
            /// Concatinate with number 1-10 depending on Custom Field
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WithTextIn
            {
                get
                {
                    if ((cachedWithTextIn == null))
                    {
                        cachedWithTextIn =
                            CoreManager.MomConsole.GetIntlStr(ResourceWithTextIn);
                    }

                    return cachedWithTextIn;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the 'with (specific) text in (Custom Field)(1-10)' view criteria item
            /// </summary>
            /// <history>
            /// 	[lucyra] 19APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CustomField
            {
                get
                {
                    if ((cachedCustomField == null))
                    {
                        cachedCustomField =
                            CoreManager.MomConsole.GetIntlStr(ResourceCustomField);
                    }

                    return cachedCustomField;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the '(Rule)' view criteria item
            /// </summary>
            /// <history>
            /// 	[a-joelj] 18MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RuleSourceFormat
            {
                get
                {
                    if ((cachedRuleSourceFormat == null))
                    {
                        cachedRuleSourceFormat =
                            CoreManager.MomConsole.GetIntlStr(ResourceRuleSourceFormat);
                    }

                    // Hack to remove the argument so it can be tacked onto the end of another string
                    return (cachedRuleSourceFormat.Replace("{0}", ""));

                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the '(Monitor)' view criteria item
            /// </summary>
            /// <history>
            /// 	[a-joelj] 18MAR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorSourceFormat
            {
                get
                {
                    if ((cachedMonitorSourceFormat == null))
                    {
                        cachedMonitorSourceFormat =
                            CoreManager.MomConsole.GetIntlStr(ResourceMonitorSourceFormat);
                    }

                    // Hack to remove the argument so it can be tacked onto the end of another string
                    return (cachedMonitorSourceFormat.Replace("{0}", ""));
                }
            }

            #endregion
            
            #endregion
        } // end of Strings

        #endregion
    } // end of AlertsView
}
