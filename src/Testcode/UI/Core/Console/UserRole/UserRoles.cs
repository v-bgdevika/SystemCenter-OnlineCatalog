// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="UserRoles.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	User Roles Base Class.
// </summary>
// <history>
// 	[ruhim] 14-Aug-05   Created
//  [ruhim] 03-Feb-06   Adding Parameters sub class and some core methods for user roles
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
using Mom.Test.UI.Core.Console.UserRole.Dialogs;
#endregion


namespace Mom.Test.UI.Core.Console.UserRole
{
    /// <summary>
    /// Class to add general methods for user roles 
    /// </summary>
    public class UserRoles
    {
        #region Private Constants

        //Toolbar position of Add button
        private const int IndexOfAddButton = 0;

        //Toolbar position of Remove button
        private const int IndexOfRemoveButton = 1;        

        #endregion

        #region Private Members
        /// <summary>
        /// cachedGeneralDialog
        /// </summary>
        private GeneralDialog cachedGeneralDialog;

        /// <summary>
        /// cachedAuthorScopeDialog
        /// </summary>
        private AuthorScopeDialog cachedAuthorScopeDialog;

        /// <summary>
        /// cachedAuthorScopeProperties
        /// </summary>
        private AuthorScopeProperties cachedAuthorScopeProperties;

        /// <summary>
        /// cachedGroupScopeDialog
        /// </summary>
        private GroupScopeDialog cachedGroupScopeDialog;

        /// <summary>
        /// cachedTasksDialog
        /// </summary>
        private TasksDialog cachedTasksDialog;

        /// <summary>
        /// cachedViewsDialog
        /// </summary>
        private ViewsDialog cachedViewsDialog;

        /// <summary>
        /// cachedSummaryDialog
        /// </summary>
        private SummaryDialog cachedSummaryDialog;

        /// <summary>
        /// cachedGeneralProperties
        /// </summary>
        private GeneralProperties cachedGeneralProperties;

        /// <summary>
        /// cachedViewsProperties
        /// </summary>
        private ViewsProperties cachedViewsProperties;

        /// <summary>
        /// cachedTasksProperties
        /// </summary>
        private TasksProperties cachedTasksProperties;

        /// <summary>
        /// cachedScopeMPObjectsDialog
        /// </summary>
        private Core.Console.Dialogs.ScopeMPObjectsDialog cachedScopeMPObjectsDialog;

        /// <summary>
        /// cachedSelectTasksDialog
        /// </summary>
        private Core.Console.Dialogs.SelectTasksDialog cachedSelectTasksDialog;
        /// <summary>
        /// cachedSelectTasksDialog
        /// </summary>
        private Core.Console.Dialogs.SelectTasksDialog cachedSelectDrillDownDashboardsDialog;
        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp;
        #endregion

        #region Enumerators section

        /// <summary>
        /// Types of UserRole Profiles
        /// </summary>
        public enum Profiles
        {
            /// <summary>
            /// Operator Profile
            /// </summary>
            Operator,

            /// <summary>
            /// Read Only Operator Profile
            /// </summary>
            ReadOnlyOperator,

            /// <summary>
            /// Author Profile
            /// </summary>
            Author,

            /// <summary>
            /// Advanced Operator/Overrider/Monitoring Policy Editor Profile
            /// </summary>
            MonitoringPolicyEditor,            
        }

        #endregion	// Enumerators section

        #region Constructor
        /// <summary>
        /// User Roles Constructor.
        /// </summary>
        public UserRoles()
        {
            this.consoleApp = CoreManager.MomConsole;            
        }
        #endregion

        #region Properties
        /// <summary>
        /// General Dialog
        /// The first screen of the User Roles wizard.
        /// </summary>
        public GeneralDialog generalDialog
        {
            get
            {
                if (this.cachedGeneralDialog == null)
                {
                    this.cachedGeneralDialog = new GeneralDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the General Dialog was successful");
                }
                return this.cachedGeneralDialog;
            }
        }

        /// <summary>
        /// Author Scope Dialog
        /// The second screen of the User Roles wizard
        /// </summary>
        public AuthorScopeDialog authorScopeDialog
        {
            get
            {
                if (this.cachedAuthorScopeDialog == null)
                {
                    this.cachedAuthorScopeDialog = new AuthorScopeDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Author Scope Dialog was successful");
                }
                return this.cachedAuthorScopeDialog;
            }
        }

        /// <summary>
        /// Author Scope Properties 
        /// </summary>
        public AuthorScopeProperties authorScopeProperties
        {
            get
            {
                if (this.cachedAuthorScopeProperties == null)
                {
                    this.cachedAuthorScopeProperties = new AuthorScopeProperties(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Author Scope Properties Dialog was successful");
                }
                return this.cachedAuthorScopeProperties;
            }
        }

        /// <summary>
        /// Group Scope Dialog
        /// The third screen of the User Roles wizard
        /// </summary>
        public GroupScopeDialog groupScopeDialog
        {
            get
            {
                if (this.cachedGroupScopeDialog == null)
                {
                    this.cachedGroupScopeDialog = new GroupScopeDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Group Scope Dialog was successful");
                }
                return this.cachedGroupScopeDialog;
            }
        }

        /// <summary>
        /// Tasks Dialog
        /// The fourth screen of the User Roles wizard
        /// </summary>
        public TasksDialog tasksDialog
        {
            get
            {
                if (this.cachedTasksDialog == null)
                {
                    this.cachedTasksDialog = new TasksDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Tasks Dialog was successful");
                }
                return this.cachedTasksDialog;
            }
        }

        /// <summary>
        /// Tasks Dialog on User Role Property page
        /// </summary>
        public TasksProperties tasksProperties
        {
            get
            {
                if (this.cachedTasksProperties == null)
                {
                    this.cachedTasksProperties = new TasksProperties(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Tasks Properties Dialog was successful");
                }
                return this.cachedTasksProperties;
            }
        }

        /// <summary>
        /// Views Dialog
        /// The fifth screen of the User Roles wizard
        /// </summary>
        public ViewsDialog viewsDialog
        {
            get
            {
                if (this.cachedViewsDialog == null)
                {
                    this.cachedViewsDialog = new ViewsDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Views Dialog was successful");
                }
                return this.cachedViewsDialog;
            }
        }

        /// <summary>
        /// Views Dialog on User Role Property page
        /// </summary>
        public ViewsProperties viewsProperties
        {
            get
            {
                if (this.cachedViewsProperties == null)
                {
                    this.cachedViewsProperties = new ViewsProperties(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Views Properties Dialog was successful");
                }
                return this.cachedViewsProperties;
            }
        }

        /// <summary>
        /// Summary Dialog
        /// The finish screen of the User Roles wizard
        /// </summary>
        public SummaryDialog summaryDialog
        {
            get
            {
                if (this.cachedSummaryDialog == null)
                {
                    this.cachedSummaryDialog = new SummaryDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Summary Dialog was successful");
                }
                return this.cachedSummaryDialog;
            }
        }

        /// <summary>
        /// General Properties        
        /// </summary>
        public GeneralProperties generalProperties
        {
            get
            {
                if (this.cachedGeneralProperties == null)
                {
                    this.cachedGeneralProperties = new GeneralProperties(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the General Properties Dialog was successful");
                }
                return this.cachedGeneralProperties;
            }
        }

        /// <summary>
        /// Scope by MP Objects Dialog
        /// </summary>
        public Core.Console.Dialogs.ScopeMPObjectsDialog scopeMPObjectsDialog
        {
            get
            {
                if (this.cachedScopeMPObjectsDialog == null)
                {
                    this.cachedScopeMPObjectsDialog = new Core.Console.Dialogs.ScopeMPObjectsDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on Scope by MP Objects Dialog was successful");
                }
                return this.cachedScopeMPObjectsDialog;
            }
        }

        /// <summary>
        /// Scope by MP Objects Dialog
        /// </summary>
        public Core.Console.Dialogs.SelectTasksDialog selectTasksDialog
        {
            get
            {
                if (this.cachedSelectTasksDialog == null)
                {
                    this.cachedSelectTasksDialog = new Core.Console.Dialogs.SelectTasksDialog(CoreManager.MomConsole,Console.Dialogs.SelectTasksDialog.enumTaskType.Tasks);
                    Utilities.LogMessage("Selecting Select Tasks Dialog was successful");
                }
                return this.cachedSelectTasksDialog;
            }
        }

        public Core.Console.Dialogs.SelectTasksDialog selectDrillDownDashboardsDialog
        {
            get
            {
                if (this.cachedSelectTasksDialog == null)
                {
                    this.cachedSelectDrillDownDashboardsDialog = new Core.Console.Dialogs.SelectTasksDialog(CoreManager.MomConsole,Console.Dialogs.SelectTasksDialog.enumTaskType.DrilDownDashboards);
                    Utilities.LogMessage("Selecting Select  Drill Down Dashboards Dialog was successful");
                }
                return this.cachedSelectDrillDownDashboardsDialog;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to select a particular user role row and bring up its context menu
        /// in the user role view based on the user role name and the context menu item
        /// passed as parameters.
        /// </summary>
        /// <param name="userName">The name of the user role to find</param>
        /// <param name="contextMenuText">Context Menu Item Text</param>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">DataGridViewRowNotFoundException</exception>
        public void ExecuteContextMenuForRow(string userName, string contextMenuText)
        {
            //Create instance of User Role Grid Control
            MomControls.GridControl viewGrid =
            new MomControls.GridControl(CoreManager.MomConsole,
            MomControls.GridControl.ControlIDs.ViewPaneGrid);
            if (viewGrid != null)
            {
                Utilities.LogMessage("UserRoles.ExecuteContextMenuForRow:: viewGrid found, select user roles");

                // Get the Index position of the ColumnName of "User Role"                    
                int colpos = viewGrid.GetColumnTitlePosition(UserRoles.Strings.UserRoleColumnName);
                Utilities.LogMessage("UserRoles.ExecuteContextMenuForRow::success getcolumntitleposition");

                //calculating the index position of the row where user role name match is found
                int rowpos = -1;
                bool rowfound = false;
                foreach (Maui.Core.WinControls.DataGridViewRow row in viewGrid.Rows)
                {
                    rowpos++;
                    foreach (Maui.Core.WinControls.DataGridViewCell cell in row.Cells)
                    {
                        if (String.Compare(cell.GetValue(), userName, false) == 0)
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
                    Utilities.LogMessage("UserRoles.ExecuteContextMenuForRow::"
                        + userName + " not found in user role view grid");
                    throw new Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException("User Role Name : "
                        + userName + " not found in User Role View");
                }

                Utilities.LogMessage("UserRoles.ExecuteContextMenuForRow:: RowPosition: " + rowpos);
                Utilities.LogMessage("UserRoles.ExecuteContextMenuForRow::ColumnPosition: " + colpos);
                Utilities.LogMessage("UserRoles.ExecuteContextMenuForRow::Cell Value: " + viewGrid.GetCellValue(rowpos, colpos));
                viewGrid.ClickCell(rowpos, colpos);

                ////Adding delay to address a timing issue here
                UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, 30000);
                Utilities.LogMessage("UserRoles.ExecuteContextMenuForRow:: success in clicking cell");

                // Bring up the Context Menu for the Selected row
                // viewGrid.SendKeys(KeyboardCodes.ShiftF10);

                // Menu myUserRoleContextMenu = new Maui.Core.WinControls.Menu(Constants.OneSecond * 5);
                Menu myUserRoleContextMenu = new Maui.Core.WinControls.Menu(ContextMenuAccessMethod.ShiftF10);
                myUserRoleContextMenu.ScreenElement.WaitForReady();

                Utilities.LogMessage("UserRoles.ExecuteContextMenuForRow:: Constructor for Menu called");
                myUserRoleContextMenu.ExecuteMenuItem(contextMenuText);
                Utilities.LogMessage("UserRoles.ExecuteContextMenuForRow::Successfully clicked on the context menu: " + contextMenuText);

            }
            else
            {
                Utilities.LogMessage("UserRoles.ExecuteContextMenuForRow::viewGrid not found.");
            }
        }
        
        /// <summary>
        /// Method to navigate to the user role dialog under Administration
        /// from anywhere in the MOMconsole
        /// </summary>        
        /// <history>
        ///     [ruhim] 03FEB06 - Created        
        /// </history>
        public void NavigateToUserRoles()
        {            
            Utilities.LogMessage("UserRoles.NavigateToUserRoles:: Navigate to and select the User Roles Dialog under Administration");            
            UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow,
                    Constants.DefaultDialogTimeout);
            Utilities.LogMessage("UserRoles.NavigateToUserRoles:: WaitForUIObjectReady returned");

            CoreManager.MomConsole.BringToForeground();
            Utilities.LogMessage("UserRoles.NavigateToUserRoles:: BringToForeground returned");
            // Select the Administration view
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Administration);
            Utilities.LogMessage("UserRoles.NavigateToUserRoles:: Successfully clicked on Administration Wunderbar");                       

            TreeNode selectedNode;
            int numberOfTries = 0;
            const int MaxTries = 7;
            do 
            {
                numberOfTries++;
                selectedNode = navPane.SelectNode(NavigationPane.Strings.AdminTreeViewUserRoles, NavigationPane.NavigationTreeView.Administration);
                Utilities.LogMessage("UserRoles.NavigateToUserRoles:: Navigated node is " + selectedNode.Text);
            }
            while ((string.Compare(selectedNode.Text, NavigationPane.Strings.AdminTreeViewUserRoles) !=0) 
                && numberOfTries < MaxTries);
            Utilities.LogMessage("UserRoles.NavigateToUserRoles:: Successfully clicked on User Roles under Administration Treeview");
        }

        /// <summary>
        /// Add a member to a particular user role
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="userRoleMember">userRoleMember</param>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">DataGridViewRowNotFoundException</exception>
        /// <history>
        ///     [ruhim] 03FEB06 - Created        
        /// </history>
        public void AddMember(string name, string userRoleMember)
        {
            //Navigate to the UserRoles Node under Administration
            NavigateToUserRoles();

            //Select the user Role in the result pane
            ExecuteContextMenuForRow(name, ViewPane.Strings.AdministrationContextMenuProperties);
            
            int MaxRetries = 5;
            int retry = 0;
            SelectUsersOrGroups myWindow = null;
            while ((retry < MaxRetries) && (myWindow == null))
            {
                try
                {
                    //Click on Add toolbar Button
                    int clickretry = 0;
                    while (clickretry < 10)
                    {
                        try
                        {
                            this.generalProperties.Extended.SetFocusWithinTimeout(5);
                            Utilities.LogMessage("UserRoles.AddMember:: Sucessfully set focus on the general properties dialog");
                            ClickToolbarButton(this.generalProperties.Controls.UserRoleMembersToolbar, IndexOfAddButton);
                            break;
                        }
                        catch
                        {
                            Utilities.LogMessage("UserRoles.AddMember:: Click Add member button fail, setting focus on parent dialog and click again.");
                            Utilities.LogMessage(string.Format("UserRoles.AddMember:: Try the {0} time/s", clickretry + 1));
                            this.generalProperties.Extended.SetFocusWithinTimeout(5);

                            clickretry++;
                            if (clickretry == 10)
                            {
                                Utilities.LogMessage("UserRoles.AddMember:: Click retry time match max count, please check screenshot and log message!");
                                Utilities.TakeScreenshot("RetryMatchMaxCount");
                                throw;
                            }
                        }
                    }
                    Utilities.LogMessage("UserRoles.AddMember:: Selecting Users or Groups window to add a user");
                    myWindow = new SelectUsersOrGroups();
                    myWindow.Extended.SetFocus();
                    myWindow.TextBox5Text = userRoleMember;
                    myWindow.ClickOK();
                    Utilities.LogMessage("UserRoles.AddMember:: Clicked OK on Selecting Users or Groups window");
                    this.generalProperties.Extended.SetFocus();
                    Utilities.LogMessage("UserRoles.AddMember:: Sucessfully set focus on the general properties dialog");
                    break;
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    retry++;
                    Sleeper.Delay(Constants.OneSecond);
                    Utilities.LogMessage("UserRoles.AddMember:: Failed to find Select Users or Groups window in attempt: " + retry);
                    Utilities.TakeScreenshot("WindowNotFound_SelectUsersorGroups");
                    Utilities.LogMessage("UserRoles.AddMember:: Close Select Users or Groups window");
                }
                catch (Maui.Core.Window.Exceptions.UnknownActiveWinException)
                {
                    retry++;
                    Sleeper.Delay(Constants.OneSecond);
                    Utilities.LogMessage("UserRoles.AddMember:: Ok button not enabled Select Users or Groups window in attempt: " + retry);
                    Utilities.TakeScreenshot("UnknownActiveWinException_SelectUsersorGroups");
                    try
                    {
                        myWindow.ClickTitleBarClose();
                        myWindow = null;
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage("UserRoles.AddMember:: Select Users or Groups window not found to close");
                    }
                    Utilities.LogMessage("UserRoles.AddMember:: Close Select Users or Groups window");
                }
                catch (Maui.Core.Window.Exceptions.CannotSetFocusException)
                {
                    retry++;
                    Utilities.LogMessage("UserRoles.AddMember:: Set Focus on User role properties dailog in attempt: " + retry);
                    Utilities.TakeScreenshot("WindowNotFound_CannotSetFocusException");
                    Sleeper.Delay(Constants.OneSecond * 3);
                    Utilities.LogMessage("UserRoles.AddMember:: Retry after sleeping for sometime");
                    this.generalProperties.Extended.SetFocus();
                    Utilities.LogMessage("UserRoles.AddMember:: Sucessfully set focus on the general properties dialog");
                }
            }

            Utilities.LogMessage("UserRoles.AddMember:: Apply and Close the properties page after adding member");
            //this.generalProperties.ClickApply();
            this.generalProperties.Controls.ApplyButton.Extended.AccessibleObject.DoDefaultAction();
            UISynchronization.WaitForUIObjectReady(this.generalProperties, Constants.DefaultDialogTimeout * 2);
            Utilities.LogMessage("UserRoles.AddMember::  :: User Role Property Saved");

            try
            {
                this.generalProperties.Controls.OKButton.Extended.AccessibleObject.DoDefaultAction();
                Utilities.LogMessage("RUserRoles.AddMember :: User Role Property page dismissed");
            }
            catch (Window.Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage("UserRoles.AddMember:: Caught WindowNotFoundException - First get the console to foregroud");
                CoreManager.MomConsole.BringToForeground();
                Utilities.LogMessage("UserRoles.AddMember:: BringToForeground returned");

                Sleeper.Delay(Constants.OneSecond * 5);

                this.generalProperties.ClickTitleBarClose();
                //select Yes on the save confirmation dialog
                CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.Yes,
                Core.Console.Dialogs.ExceptionErrorDialog.Strings.DialogTitle,
                StringMatchSyntax.ExactMatch,
                MomConsoleApp.ActionIfWindowNotFound.Error);

                Utilities.LogMessage("UserRoles.AddMember :: User Role Property page dismissed");
            }

            //After clicking OK wait for the property page to go away
            CoreManager.MomConsole.WaitForDialogClose(this.generalProperties, 60);

            int attempt = 0;
            int maxcount = 120;
            while (!CoreManager.MomConsole.MainWindow.Extended.IsForeground && attempt <= maxcount)
            {
                Utilities.LogMessage("UserRoles.AddMember :: MainWindow not Foreground, lets wait a moment.");
                Sleeper.Delay(1000);
                attempt++;
            }
            UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout * 2);
            consoleApp.Waiters.WaitForStatusReady();

            Utilities.LogMessage("UserRoles.AddMember:: Successfully closed propeties dialog after adding :"
                + userRoleMember); 
        }

        /// <summary>
        /// Remove a particular member from a particular user role
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="userRoleMember">userRoleMember</param>
        /// <exception cref="Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">DataGridViewRowNotFoundException</exception>
        /// <history>
        ///     [ruhim] 03FEB06 - Created        
        /// </history>
        public void RemoveMember(string name, string userRoleMember)
        {
            //Navigate to the UserRoles Node under Administration
            NavigateToUserRoles();

            //Select the user Role in the result pane
            ExecuteContextMenuForRow(name, ViewPane.Strings.AdministrationContextMenuProperties);

            //Select the Member from ListView and Remove it

            if (this.generalProperties.Controls.UserRoleMembersListView.Exists(userRoleMember,1,false))
            {
                ListViewItemCollection myCollection = this.generalProperties.Controls.UserRoleMembersListView.Items;
                Utilities.LogMessage("UserRoles.RemoveMember:: Successfully got the collection of all user role members");

                int attempt;
                int MaxTry = 3;
                bool MemberSelected = false;

                foreach (ListViewItem member in myCollection)
                {                                          
                    Utilities.LogMessage("UserRoles.RemoveMember:: Selected a user role member");
                    if (member.Text.ToLowerInvariant() == userRoleMember.ToLowerInvariant())
                    {
                        attempt = 0;
                        while (attempt < MaxTry)
                        {
                            try
                            {     
                                member.Select();
                                Utilities.LogMessage("UserRoles.RemoveMember:: found user role : " + userRoleMember);
                                ClickToolbarButton(this.generalProperties.Controls.UserRoleMembersToolbar, IndexOfRemoveButton);
                                Utilities.LogMessage("UserRoles.RemoveMember:: Successfully removed user role member");

                                Utilities.LogMessage("UserRoles.RemoveMember:: Apply and Close the properties page after removing member");
                                this.generalProperties.Extended.SetFocus();
                                //this.generalProperties.ClickApply();
                                
                                this.generalProperties.Controls.ApplyButton.Extended.AccessibleObject.DoDefaultAction();
                                //UISynchronization.WaitForUIObjectReady(this.generalProperties, Constants.DefaultDialogTimeout * 2);
                                consoleApp.Waiters.WaitForStatusReady(Constants.OneSecond * 15);
                                Utilities.LogMessage("UserRoles.RemoveMember::  :: User Role Property Saved");

                                try
                                {
                                    //this.generalProperties.ClickOK();
                                    this.generalProperties.Controls.OKButton.Extended.AccessibleObject.DoDefaultAction();
                                    Utilities.LogMessage("UserRoles.RemoveMember :: User Role Property page dismissed");
                                }
                                catch (Window.Exceptions.WindowNotFoundException)
                                {
                                    Utilities.LogMessage("UserRoles.RemoveMember:: Caught WindowNotFoundException - First get the console to foregroud");
                                    CoreManager.MomConsole.BringToForeground();
                                    Utilities.LogMessage("UserRoles.RemoveMember:: BringToForeground returned");

                                    Sleeper.Delay(Constants.OneSecond * 5);

                                    //// set the focus to the application
                                    //CoreManager.MomConsole.MainWindow.Extended.SetFocus();

                                    //// maximize the main window
                                    //CoreManager.MomConsole.MainWindow.Extended.State = WindowState.Maximize;

                                    this.generalProperties.ClickTitleBarClose();
                                    //select Yes on the save confirmation dialog
                                    CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.Yes,
                                    Core.Console.Dialogs.ExceptionErrorDialog.Strings.DialogTitle,
                                    StringMatchSyntax.ExactMatch,
                                    MomConsoleApp.ActionIfWindowNotFound.Error);

                                    Utilities.LogMessage("UserRoles.RemoveMember :: User Role Property page dismissed");
                                }

                                //After clicking OK wait for the property page to go away
                                CoreManager.MomConsole.WaitForDialogClose(this.generalProperties, 60);

                                //Set focus to Mom console
                                CoreManager.MomConsole.MainWindow.Extended.SetFocus();

                                int retry = 0;
                                int maxcount = 120;
                                while (!CoreManager.MomConsole.MainWindow.Extended.IsForeground && retry <= maxcount)
                                {
                                    Utilities.LogMessage("UserRoles.RemoveMember :: MainWindow not Foreground, lets wait a moment.");
                                    Sleeper.Delay(1000);
                                    retry++;
                                }
                                UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout * 2);
                                consoleApp.Waiters.WaitForStatusReady();
                                Utilities.LogMessage("UserRoles.RemoveMember:: Successfully closed propeties dialog after removing :"
                                    + userRoleMember);
                                MemberSelected = true;
                                break;
                            }
                            catch (System.NullReferenceException)
                            {
                                Utilities.LogMessage("UserRoles.RemoveMember:: NullReferenceException caught in Selecting a member - retry");
                                attempt++;
                            }
                        }                        
                    }//end of while

                    if (MemberSelected)
                    {
                        break;
                    }
                }
            }
            else
            {
                Utilities.LogMessage("UserRoles.RemoveMember:: Failed to find User Role Member :" +
                    userRoleMember + " in User Role Members ListView");
                this.generalProperties.Extended.SetFocus();                
                this.generalProperties.ClickOK();
                throw new ListView.Exceptions.ItemNotFoundException("Failed to find User Role Member in ListView");
            }            
        }

        /// <summary>
        /// Delete a particular user role
        /// </summary>
        /// <param name="name">name</param>       
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">DataGridViewRowNotFoundException</exception>
        /// <history>
        ///     [ruhim] 07FEB06 - Created        
        /// </history>
        public void Delete(string name)
        {
            //Navigate to the UserRoles Node under Administration
            NavigateToUserRoles();

            //Select the user Role in the result pane
            ExecuteContextMenuForRow(name, ViewPane.Strings.AdministrationContextMenuDelete);

            //select the instance of delete confirmation dialog
            Core.Console.UserRole.Dialogs.ConfirmUserRoleDeleteDialog myDeleteDialog =
                new Core.Console.UserRole.Dialogs.ConfirmUserRoleDeleteDialog(CoreManager.MomConsole);
            myDeleteDialog.Extended.SetFocus();
            // click yes to delete
            myDeleteDialog.ClickYes();
        }

        /// <summary>
        /// Create a new User Role
        /// </summary>
        /// <param name="profile">Profile of User Role</param>
        /// <param name="name">Name of User Role</param>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <history>
        ///     [ruhim] 03FEB06 - Created        
        /// </history>
        public void Create(UserRoles.Profiles profile, string name)
        {
            this.Create(profile, name, null);
        }

        /// <summary>
        /// Create new User Role
        /// </summary>
        /// <param name="profile">Profile of User Role</param>
        /// <param name="name">Name of User Role</param>
        /// <param name="members">Members of User Role</param>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <history>
        ///     [ruhim] 03FEB06 - Created        
        /// </history>
        public void Create(UserRoles.Profiles profile, string name, ArrayList members)
        {
            UserRoleParameters parameters = new UserRoleParameters();
            parameters.Profile = profile;
            parameters.Name = name;
            parameters.Members = members;
            this.Create(parameters);
        }

        /// <summary>
        /// Create new User Role
        /// </summary>
        /// <param name="parameters">UserRoleParameters</param>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <history>
        ///     [ruhim] 09FEB06 - Created        
        /// </history>
        public void Create(UserRoleParameters parameters)
        {
            NavigateToUserRoles();

            Utilities.LogMessage("UserRoles.Create :: Selecting '" + NavigationPane.Strings.ContextMenuNewUserRoles + "' " + "from context menu");
            // Select the Context Menu New for userroles in the administration tree
            CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView
                .Find(NavigationPane.Strings.AdminTreeViewUserRoles).Select();

            string menuPath = NavigationPane.Strings.ContextMenuNewUserRoles;

            //Based on the profile parameter; execute the menu item after fetching 
            //the resource string for the profile
            string profileSelected = null;
            switch (parameters.Profile)
            {
                case UserRoles.Profiles.Operator:
                    profileSelected = UserRoles.Strings.Operator;
                    break;

                case UserRoles.Profiles.ReadOnlyOperator:
                    profileSelected = UserRoles.Strings.ReadOnlyOperator;
                    break;

                case UserRoles.Profiles.Author:
                    profileSelected = UserRoles.Strings.Author;
                    break;

                case UserRoles.Profiles.MonitoringPolicyEditor:
                    profileSelected = UserRoles.Strings.MonitoringPolicyEditor;
                    break;

                default:
                    Utilities.LogMessage("UserRoles.Create :: Profile passed in as a parameter: '" +
                        parameters.Profile + "' is invalid");
                    throw new InvalidEnumArgumentException("Invalid Profile selected");
            }

            menuPath = menuPath + Constants.PathDelimiter + profileSelected + "...";
            Utilities.LogMessage("UserRoles.Create :: menuPath:" + menuPath);
            CoreManager.MomConsole.ExecuteContextMenu(menuPath, true);
            Utilities.LogMessage("UserRoles.Create :: Sucessfully selected Profile : '" + profileSelected + "'");
            Utilities.LogMessage("UserRoles.Create :: Launched the use role wizard");

            #region Navigate through all the screens of the Wizard

            this.generalDialog.NameTextBox = parameters.Name;
            Utilities.LogMessage("UserRoles.Create :: setting name on first screen was successful");
            Sleeper.Delay(Constants.OneSecond);
            Utilities.LogMessage("UserRoles.Create :: User role Name right after setting is '" 
                + this.generalDialog.NameTextBox + "'");

            //Trying to set the description if its null throws System.ArgumentNullException
            if (parameters.Description != null)
            {
            this.generalDialog.DescriptionTextBox = parameters.Description;
            Sleeper.Delay(Constants.OneSecond);
            Utilities.LogMessage("UserRoles.Create :: User role description right after setting is '"
                + this.generalDialog.DescriptionTextBox + "'");
            }
            //Add members to the user role
            if (parameters.Members.Count >= 1)
            {
                Utilities.LogMessage("UserRoles.Create:: Members Count: " + parameters.Members.Count.ToString());
                foreach (string member in parameters.Members)
                {
                //Add user role member
                ClickToolbarButton(this.generalDialog.Controls.UserRoleMembersToolbar, IndexOfAddButton);
                Utilities.LogMessage("UserRoles.Create :: Adding User Role Member '" 
                    + member + "'");
                Utilities.LogMessage("UserRoles.Create :: Index of user role member added was : '" 
                    + parameters.Members.IndexOf(member) + "'");                

                Utilities.LogMessage("UserRoles.Create :: Selecting Users or Groups window to add a user");
                SelectUsersOrGroups myWindow = new SelectUsersOrGroups();
                myWindow.Extended.SetFocus();
                myWindow.TextBox5Text = member;
                myWindow.ClickOK();
                Utilities.LogMessage("UserRoles.Create :: Successfully added the user role Member : " 
                    + member);
                //Sometimes there will be time out issue when clickOk button, add waiting time
                CoreManager.MomConsole.WaitForDialogClose(myWindow, 60);
                }
            }
            this.generalDialog.Extended.SetFocus();
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.generalDialog.Controls.NextButton, Constants.OneMinute);
            this.generalDialog.ClickNext();

            //Based on the profile selected you need to traverse different wizard screens               
            switch (parameters.Profile)
            {
                case UserRoles.Profiles.Author:
                    if (parameters.Targets == null || parameters.Targets.Count <= 0)
                    {
                        Utilities.LogMessage("UserRoles.Create :: All Classes selected for Author Scope");
                        this.authorScopeDialog.Controls.AllTargetsRadioButton.Click();
                        //Following is giving null refrence exception
                        //secondScreen.Controls.SummaryStaticControl.Click();
                        this.authorScopeDialog.ClickNext();
                                                
                        GroupsSelection(parameters.Groups);                        
                        this.groupScopeDialog.ClickNext();
                        //Click next for the tasks and views screen as well since all classes 
                        //are selected the tasks and views screen are disabled
                        this.tasksDialog.ClickNext();
                        this.viewsDialog.ClickNext();                                                
                    }
                    else
                    {
                        TargetsSelection(parameters.Targets, true);                    
                        this.authorScopeDialog.ClickNext();

                        GroupsSelection(parameters.Groups);                        
                        this.groupScopeDialog.ClickNext();

                        TasksSelection(parameters.Tasks, true);
                        this.tasksDialog.ClickNext();

                        ViewsSelection(parameters.ViewPaths,parameters.DrillDownDashboards, true);
                        this.viewsDialog.ClickNext();

                    }// end of class scope                   
                    break;

                case UserRoles.Profiles.ReadOnlyOperator:
                    GroupsSelection(parameters.Groups);                    
                    this.groupScopeDialog.ClickNext();

                    //If its RO operator the tasks dialog is not shown                   
                    ViewsSelection(parameters.ViewPaths,parameters.DrillDownDashboards, true);
                    this.viewsDialog.ClickNext();
                    break;

                case UserRoles.Profiles.Operator:
                case UserRoles.Profiles.MonitoringPolicyEditor:
                    GroupsSelection(parameters.Groups);                    
                    this.groupScopeDialog.ClickNext();

                    TasksSelection(parameters.Tasks, true);
                    this.tasksDialog.ClickNext();

                    ViewsSelection(parameters.ViewPaths,parameters.DrillDownDashboards, true);
                    this.viewsDialog.ClickNext();
                    break;

                default:
                    Utilities.LogMessage("UserRoles.Create :: Profile passed in as a parameter: '" +
                        parameters.Profile + "' is invalid");
                    throw new InvalidEnumArgumentException("Invalid Profile selected");
                }

                //******************************************
                //Changes due to DCR 94061
                //Dashboard view warning dialog
                if (parameters.ViewPaths != null && parameters.ViewPaths.Count >= 1)
                {
                    this.WaitForWarningDialog();
                }
                //******************************************

                //Complete the wizard                
                this.summaryDialog.ClickCreate();

                //Wait for wizard dialog to close
                CoreManager.MomConsole.WaitForDialogClose(this.summaryDialog, 90);
                Utilities.LogMessage("UserRoles.Create :: Successfully completed User Role Creation!!");
           
            #endregion
        }

        /// <summary>
        ///  Method to verify if the user calling this method can see a specific view in the UI or not
        /// </summary>
        /// <param name="nodePath">string to get nodePath</param>
        /// <param name="button">NavigationPane.WunderBarButton button</param>
        /// /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <history>
        ///     [v-lileo] 09JUNE25 - Created        
        /// </history>
        public void VerifyNodeViewRunAsUserRole(string nodePath, NavigationPane.WunderBarButton button)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            Utilities.LogMessage(currentMethod + "::(...)");
            // Navigate to WunderBar            
            navPane.ClickWunderBarButton(button);
            consoleApp.Waiters.WaitForStatusReady(Core.Common.Constants.OneSecond);
            Utilities.LogMessage(currentMethod + "::Successfully clicked on Authoring Wunderbar");
            TreeNode selectedNode = null;
            int Tries = 0;
            int MaxTries = 10;
            do
            {
                Utilities.LogMessage(currentMethod + ":: selecting Node...");
                selectedNode = navPane.SelectNode(nodePath, NavigationPane.NavigationTreeView.MonitoringConfiguration);
                Utilities.LogMessage(currentMethod + ":: Navigated node is " + selectedNode.Text);
                Sleeper.Delay(Core.Common.Constants.OneSecond);
            } while (selectedNode == null && Tries++ < MaxTries);
            if (selectedNode != null)
            {
                Utilities.LogMessage(currentMethod + ":: Successfully find " + nodePath + " under Authoring Treeview");
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: " + nodePath + " node not found");
               throw new InvalidEnumArgumentException(currentMethod + ":: " + nodePath + " node not found");
            }            
        }

        /// <summary>
        /// Method to select the classes based on the input parameter        
        /// </summary>
        /// <param name="targetsList">Lists to get classes from</param>
        /// <param name="wizardDialog">Boolean indicating whether its wizard or property page</param>
        /// <history>
        ///    [ruhim] 09FB06   Created
        ///    [a-joelj]   28OCT09 Maui 2.0: Added check for wizardDialog before waiting for enabled button
        /// </history>
        // <exception cref="Maui.Core.WinControls.Button.Exceptions.ControlIsDisabledException">ControlIsDisabledException</exception>
        public void TargetsSelection(ArrayList targetsList, bool wizardDialog)
        {
            if (targetsList.Count >= 1)
            {
                Utilities.LogMessage("UserRoles.TargetsSelection:: Number of Targets for Author Scope: "
                    + targetsList.Count.ToString());
                if (wizardDialog == true)
                {
                    this.authorScopeDialog.Controls.ExplicitlyApprovedTargetsRadioButton.Click();
                    ClickToolbarButton(this.authorScopeDialog.Controls.AddRemoveToolbar, IndexOfAddButton);
                }
                else
                {
                    this.authorScopeProperties.Controls.ExplicitlyApprovedTargetsRadioButton.Click();
                    ClickToolbarButton(this.authorScopeProperties.Controls.AddRemoveToolbar, IndexOfAddButton);
                }
                Utilities.LogMessage("UserRoles.TargetsSelection:: Successfully Clicked on the Add button");

                int targetHeaderColPos = -1;
                targetHeaderColPos = consoleApp.GeListViewtColumnPosition(Core.Console.Dialogs.ScopeMPObjectsDialog.Strings.TargetColumnHeader, this.scopeMPObjectsDialog.Controls.TypeListView);

                foreach (string target in targetsList)
                {
                    CoreManager.MomConsole.SelectListViewItems(target, targetHeaderColPos, this.scopeMPObjectsDialog.Controls.TypeListView,true);
                    this.scopeMPObjectsDialog.SendKeys(KeyboardCodes.Space);
                    Utilities.LogMessage("UserRoles.TargetsSelection:: sucess in selecting Target: " + target);

                }
                //Close the scopeMPObjectsDialog after target selection
                if (this.scopeMPObjectsDialog.Controls.OKButton.Extended.IsEnabled)
                {
                    Utilities.LogMessage("UserRoles.TargetsSelection:: Targets selected - close the dialog");
                    this.scopeMPObjectsDialog.ClickOK();
                }
                else
                {
                    Utilities.LogMessage("UserRoles.TargetsSelection:: No targets selected - close the dialog");
                    //this.scopeMPObjectsDialog.ClickTitleBarClose();
                    // [v-lileo]04Nov2009 Maui 2.0 Required change: ClickTitleBarClose() method does not 
                    //                    work to close the pivoted window. Need to investigate further could be
                    //                    an RPF bug - using it fails with:
                    //                    "Internal failure: GetUIElementFromPoint didn't return S_OK The handle is invalid."
                    //                    Changed this to close the open window with Extended.CloseWindow() method.
                    this.scopeMPObjectsDialog.Extended.CloseWindow();
                    throw new Maui.Core.WinControls.Button.Exceptions.ControlIsDisabledException("Scope by MP objects OK button is not enabled");
                }
            }
            // [a-joelj] Maui 2.0 Required Change: Due to Change# 141648 this Waiters.WaitForButtonEnabled was 
            // causing WindowNotFound exception if we aren't in a Wizard dialog (like User Role properties 
            // when Modifying a User Role). Now checking if wizardDialog == true before waiting for NextButton
            if (wizardDialog == true)
            {
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.authorScopeDialog.Controls.NextButton, Constants.OneMinute);    
            }
        }

        /// <summary>
        /// Method to select the groups based on the input parameter        
        /// </summary>
        /// <param name="groupsList">Lists to get groups from</param>        
        /// <history>
        ///    [ruhim] 09FB06   Created
        /// </history>
        public void GroupsSelection(ArrayList groupsList)
        {
            //bug#213573
            CoreManager.MomConsole.Waiters.WaitForStatusReady();

            if (groupsList == null)
            {
                Utilities.LogMessage("UserRoles.Create:: Group scope is set to default Root group");
                this.groupScopeDialog.Controls.GroupsTreeView.ExpandAll();
                this.groupScopeDialog.Controls.GroupsTreeView.Root.Checked = true;
            }
            else
            {
                if (groupsList.Count >= 1)
                {
                    Utilities.LogMessage("UserRoles.Create:: Groups Count : "
                    + groupsList.Count.ToString());
                    this.groupScopeDialog.Controls.GroupsTreeView.Root.ExpandAll();

                    this.groupScopeDialog.Controls.GroupsTreeView.Root.Click();
                    Utilities.LogMessage("UserRoles.Create:: clicked the root node");
                    //if (this.groupScopeDialog.Controls.GroupsTreeView.Root.Checked.Equals(true))
                    //{
                        this.groupScopeDialog.SendKeys(KeyboardCodes.Space);
                        Utilities.LogMessage("UserRoles.Create:: Unchecked the root node");
                    //}
                    foreach (string group in groupsList)
                    {
                        this.groupScopeDialog.Controls.GroupsTreeView.Find(group).Click();
                        this.groupScopeDialog.SendKeys(KeyboardCodes.Space);
                        Utilities.LogMessage("UserRoles.Create:: Success in selecting Group: " + group);
                    }
                }
            }//end of else groups

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.groupScopeDialog.Controls.NextButton, Constants.OneMinute);
        }

        /// <summary>
        /// Method to select the views based on the input parameter        
        /// </summary>
        /// <param name="DashboardsList">Lists to get views including the complete path to be selected</param>
        /// <param name="DrillDownDashboardsList">Lists to get views including the Drill Down Dashboards view to be selected</param>        
        /// <param name="wizardDialog">Boolean indicating whether its wizard or property page</param>
        /// <history>
        ///    [ruhim] 09FB06   Created
        ///    [a-joelj]   28OCT09 Maui 2.0: Added check for wizardDialog before waiting for enabled button
        /// </history>
        public void ViewsSelection(ArrayList DashboardsList, ArrayList DrillDownDashboardsList, bool wizardDialog)
        {
            this.ViewsSelection(DashboardsList, DrillDownDashboardsList, wizardDialog, false);
        }
        /// <summary>
        /// Method to select the dashboards views based on the input parameter 
        /// </summary>
        /// <param name="DashboardsList">Lists to get Dashboards views including the complete path to be selected</param>
        /// <param name="DrillDownDashboardsList">Lists to get Drill Down Dashboards views including the Drill Down Dashboards view to be selected</param>
        /// <param name="wizardDialog">Boolean indicating whether its wizard or property page</param>
        /// <param name="updateView">Boolean indicating whether its update or not update View</param>
        public void ViewsSelection(ArrayList DashboardsList, ArrayList DrillDownDashboardsList, bool wizardDialog, bool updateView)
        {
            if (DashboardsList == null && DrillDownDashboardsList ==null)
            {
                Utilities.LogMessage("UserRoles.Create :: Selecting all Views for View Scope");
                if (wizardDialog == true)
                {
                    this.viewsDialog.Controls.AllViewsRadioButton.Click();
                }
                else
                {
                    this.viewsProperties.Controls.AllViewsRadioButton.Click();
                }                 
                Utilities.LogMessage("UserRoles.Create :: All Views selected for View Scope");
            }
            else
            {
                #region Update ViewPath
                if (DashboardsList.Count >= 1)
                {
                    Utilities.LogMessage("UserRoles.ViewsSelection:: Number of Views for View Scope: "
                        + DashboardsList.Count.ToString());

                    MomControls.TreeView viewsTreeView = null;

                    if (wizardDialog == true)
                    {
                        this.viewsDialog.Controls.ExplicitlyApprovedViewsRadioButton.Click();
                        Maui.Core.WindowParameters windowsparameter = new WindowParameters(this.viewsDialog,
                            "",
                            StringMatchSyntax.WildCard,
                            WindowClassNames.WinFormsTreeView,
                            StringMatchSyntax.WildCard);
                        viewsTreeView = new MomControls.TreeView(windowsparameter);
                            //this.viewsDialog,
                            //"",
                            //StringMatchSyntax.WildCard,
                            //WindowClassNames.WinFormsTreeView,
                            //StringMatchSyntax.WildCard);
                    }
                    else
                    {
                        this.viewsProperties.Controls.ExplicitlyApprovedViewsRadioButton.Click();

                        Maui.Core.WindowParameters windowsparameter1 = new WindowParameters(this.viewsProperties,
                            "",
                            StringMatchSyntax.WildCard,
                            WindowClassNames.WinFormsTreeView,
                            StringMatchSyntax.WildCard);
                        viewsTreeView = new MomControls.TreeView(windowsparameter1);
                        //
                        //viewsTreeView = new TreeView(
                        //    this.viewsProperties,
                        //    "",
                        //    StringMatchSyntax.WildCard,
                        //    WindowClassNames.WinFormsTreeView,
                        //    StringMatchSyntax.WildCard);
                    }                     

                    if (viewsTreeView != null)
                    {
                        //Update View selection. First uncheck all treeNode if update view properties, and then check the update node
                        if (updateView)
                        {
                            viewsTreeView.Root.Click();
                            viewsTreeView.SendKeys(KeyboardCodes.Space);
                            CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.OK, "*",
                                StringMatchSyntax.WildCard, MomConsoleApp.ActionIfWindowNotFound.Error);
                            viewsTreeView.ScreenElement.WaitForReady();
                            viewsTreeView.Root.Checked = false;
                            viewsTreeView.ScreenElement.WaitForReady();
                        }

                        foreach (string viewPath in DashboardsList)
                        {
                            //This is a workaround to ignore folders listed as views because user
                            // role wizard does not list folders like System.UI.ViewFolders returned
                            //by the SDK method GetManagementPackViews
                            if (viewPath.Contains("System.UI.ViewFolders") == false)
                            {
                                TreeNode treeNode;
                                try
                                {
                                    //Workaround for Maui issue that when UITest folder appears half in UI, cannot expand it successfully.                                        
                                    if (viewsTreeView.VerticalScrollBar.IsVisible)
                                    {
                                        Utilities.LogMessage("UserRoles.ViewsSelection:: Scroll down to make UITest folder appear fully in Dialog and expand it again.");
                                        viewsTreeView.VerticalScrollBar.PageDown();
                                        viewsTreeView.ScreenElement.WaitForReady();
                                        viewsTreeView.VerticalScrollBar.PageDown();
                                    }

                                    treeNode = consoleApp.ExpandTreePath(viewPath, viewsTreeView);
                                }
                                catch (TreeNode.Exceptions.NodeNotFoundException ex) //fix bug# 168199                                 
                                {
                                    //Workaround for Maui issue that when TreeNode appears half in UI, cannot expand or select it successfully.
                                    Utilities.LogMessage("UserRoles.ViewsSelection:: Avoid not expanding the TreeNode that appears half in UI dialog, scroll down to make TreeNode appear fully and expand it again.");
                                    if (viewsTreeView.VerticalScrollBar.IsVisible)
                                        viewsTreeView.VerticalScrollBar.PageDown();
                                    else
                                        throw ex;

                                    treeNode = consoleApp.ExpandTreePath(viewPath, viewsTreeView);
                                }
                                treeNode.Click();
                                viewsTreeView.SendKeys(KeyboardCodes.Space);
                                Utilities.LogMessage("UserRoles.ViewsSelection:: Sucess in selecting View: " + viewPath);
                                CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.OK, Strings.WarningMessageTitle,
                                    StringMatchSyntax.WildCard, MomConsoleApp.ActionIfWindowNotFound.Ignore);
                            }
                        }
                    }
                    else
                    {
                        Utilities.LogMessage("UserRoles.ViewsSelection:: Unable to find Tree View on Views Dialog");
                        throw new Maui.Core.WinControls.TreeView.Exceptions.InvalidTreeViewException("UserRoles.ViewsSelection:: Unable to find Tree View");
                    }
                }
                #endregion

                #region Update Drill Down Dashboards
                //Call DrillDownSelection method to select Dril Down dashboards view
                this.DrillDownSelection(DrillDownDashboardsList, wizardDialog, updateView);

                #endregion
            }
            // [a-joelj] Maui 2.0 Required Change: Due to Change# 141648 this Waiters.WaitForButtonEnabled was 
            // causing WindowNotFound exception if we aren't in a Wizard dialog (like User Role properties 
            // when Modifying a User Role). Now checking if wizardDialog == true before waiting for NextButton
            if (wizardDialog == true)
            {
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.viewsDialog.Controls.NextButton, Constants.OneMinute);
            }
        }
        /// <summary>
        /// Method to select the Drill Down dashboards views based on the input parameter 
        /// </summary>
        /// <param name="DrillDownDashboardsList">Lists to get Drill Down Dashboards views including the Drill Down Dashboards view to be selected</param>
        /// <param name="wizardDialog">Boolean indicating whether its wizard or property page</param>
        /// <param name="updateView">Boolean indicating whether its update or not update View</param>
        private void DrillDownSelection(ArrayList DrillDownDashboardsList, bool wizardDialog, bool updateView)
        {
            #region Update Drill Down Dashboards
            //this code might change depending on the design change
            if (DrillDownDashboardsList.Count >= 1)
            {
                Utilities.LogMessage("UserRoles.ViewSelection :: Number of DrillDownDashboards for Task Scope: " + DrillDownDashboardsList.Count.ToString());
                if (wizardDialog == true)
                {
                    this.viewsDialog.Controls.ExplicitlyApprovedViewsRadioButton.Click();
                    TabControlTab dddTab = new TabControlTab(viewsDialog.Controls._TabControl, Console.Dialogs.SelectTasksDialog.Strings.TaskPaneTabPage);
                    this.viewsDialog.Controls._TabControl.Tabs[dddTab.Index].Select();

                    int retry = 0;
                    while (retry < 10)
                    {
                        try
                        {
                            ClickToolbarButton(this.tasksDialog.Controls.AddRemoveToolbar, IndexOfAddButton);
                            break;
                        }
                        catch
                        {
                            retry++;
                            Utilities.LogMessage(string.Format("UserRoles.ViewSelection :: Try to click Add button, retry time: {0}", retry));
                            this.viewsDialog.Controls.ExplicitlyApprovedViewsRadioButton.Click();
                            dddTab = new TabControlTab(viewsDialog.Controls._TabControl, Console.Dialogs.SelectTasksDialog.Strings.TaskPaneTabPage);
                            this.viewsDialog.Controls._TabControl.Tabs[dddTab.Index].Select();
                            Utilities.TakeScreenshot("AfterFixTime" + retry);
                            if (retry == 10)
                            {
                                Utilities.LogMessage("UserRoles.ViewSelection :: Try to click Add button match the max time...");
                                throw;
                            }
                        }
                    }
                }
                else
                {
                    this.viewsProperties.Controls.ExplicitlyApprovedViewsRadioButton.Click();
                    TabControlTab dddTab = new TabControlTab(viewsProperties.Controls._TabControl, Console.Dialogs.SelectTasksDialog.Strings.TaskPaneTabPage);
                    this.viewsProperties.Controls._TabControl.Tabs[dddTab.Index].Select();

                    int retry = 0;
                    while (retry < 10)
                    {
                        try
                        {
                            ClickToolbarButton(this.viewsProperties.Controls.AddRemoveToolbar, IndexOfAddButton);
                            break;
                        }
                        catch
                        {
                            retry++;
                            Utilities.LogMessage(string.Format("UserRoles.ViewSelection :: Try to click Add button, retry time: {0}", retry));
                            this.viewsProperties.Controls.ExplicitlyApprovedViewsRadioButton.Click();
                            dddTab = new TabControlTab(viewsProperties.Controls._TabControl, Console.Dialogs.SelectTasksDialog.Strings.TaskPaneTabPage);
                            this.viewsProperties.Controls._TabControl.Tabs[dddTab.Index].Select();
                            Utilities.TakeScreenshot("AfterFixTime" + retry);
                            if (retry == 10)
                            {
                                Utilities.LogMessage("UserRoles.ViewSelection :: Try to click Add button match the max time...");
                                throw;
                            }
                        }
                    }

                    //Update drill dashboards View selection. First clear all treeNode if update view properties, and then check the update node
                    if (updateView)
                    {
                        this.selectDrillDownDashboardsDialog.ClickClearAll();
                    }
                }

                int targetHeaderColPos = -1;
                targetHeaderColPos = consoleApp.GeListViewtColumnPosition(Core.Console.Dialogs.SelectTasksDialog.Strings.DashboardsColumnHeader, this.selectDrillDownDashboardsDialog.Controls.TasksListView);

                foreach (string DrillDownDashboard in DrillDownDashboardsList)
                {
                    int maxRetires = 5;
                    int retry = 0;
                    while (retry < maxRetires)
                    {
                        if (CoreManager.MomConsole.SelectListViewItems(DrillDownDashboard, targetHeaderColPos, this.selectDrillDownDashboardsDialog.Controls.TasksListView, false) == true)
                        {
                            this.selectDrillDownDashboardsDialog.SendKeys(KeyboardCodes.Space);
                            Sleeper.Delay(Constants.OneSecond);
                            if (!this.selectDrillDownDashboardsDialog.Controls.TasksListView.SelectedItem.Checked)
                            {
                                Utilities.LogMessage("UserRoles.TasksSelection :: Failed in selecting Task: " + DrillDownDashboard + " Retry...");
                                this.selectTasksDialog.SendKeys(KeyboardCodes.Space);
                                Sleeper.Delay(Constants.OneSecond);
                            }
                            Utilities.LogMessage("UserRoles.TasksSelection :: Sucess in selecting Task: " + DrillDownDashboard);
                            break;
                        }
                        else
                        {
                            Utilities.LogMessage("UserRoles.TasksSelection :: Task not found: " + DrillDownDashboard);
                            retry++;
                            Utilities.LogMessage("UserRoles.TasksSelection :: Attempt :" + retry);
                            Sleeper.Delay(Constants.OneSecond * 2);
                        }
                    }
                }
                //Close the selectTasksDialog after Task selection
                if (this.selectDrillDownDashboardsDialog.Controls.OKButton.Extended.IsEnabled)
                {
                    Utilities.LogMessage("UserRoles.TasksSelection :: Tasks selected - close the dialog");
                    this.selectDrillDownDashboardsDialog.ClickOK();
                }
                else
                {
                    Utilities.LogMessage("UserRoles.TasksSelection :: No Tasks selected - close the dialog");
                    this.selectDrillDownDashboardsDialog.ClickTitleBarClose();
                    throw new Maui.Core.WinControls.Button.Exceptions.ControlIsDisabledException("Select DrillDownDashboards Dialog - OK button is not enabled");
                }
            }
            #endregion
        }

        /// <summary>
        /// Method to select the tasks based on the input parameter        
        /// </summary>
        /// <param name="tasksList">Lists to get tasks from</param>
        /// <param name="wizardDialog">Boolean indicating whether its wizard or property page</param>
        /// <history>
        ///    [ruhim] 09FB06   Created
        ///    [a-joelj]   28OCT09 Maui 2.0: Added check for wizardDialog before waiting for enabled button
        /// </history>
        // <exception cref="Maui.Core.WinControls.Button.Exceptions.ControlIsDisabledException">ControlIsDisabledException</exception>
        public void TasksSelection(ArrayList tasksList, bool wizardDialog)
        {
            if (tasksList == null)
            {
                Utilities.LogMessage("UserRoles.TasksSelection :: Selecting all Tasks for Tasks Scope");
                if (wizardDialog == true)
                {                    
                    this.tasksDialog.Controls.AllTasksRadioButton.Click();                    
                }
                else
                {                    
                    this.tasksProperties.Controls.AllTasksRadioButton.Click();                 
                }
                Utilities.LogMessage("UserRoles.TasksSelection :: All Tasks selected for Tasks Scope");
            }
            else
            {
                if (tasksList.Count >= 1)
                {
                    Utilities.LogMessage("UserRoles.TasksSelection :: Number of Tasks for Task Scope: "
                        + tasksList.Count.ToString());
                    if (wizardDialog == true)
                    {
                        this.tasksDialog.Controls.ExplicitlyApprovedTasksRadioButton.Click();
                        int retry = 0;
                        while (retry < 10)
                        {
                            try
                            {
                                ClickToolbarButton(this.tasksDialog.Controls.AddRemoveToolbar, IndexOfAddButton);
                                break;
                            }
                            catch
                            {
                                retry++;
                                Utilities.LogMessage(string.Format("UserRoles.TasksSelection :: Try to click Add button, retry time: {0}", retry));
                                this.tasksDialog.Controls.ExplicitlyApprovedTasksRadioButton.Click();
                                Utilities.TakeScreenshot("AfterFixTime" + retry);
                                if (retry == 10)
                                {
                                    Utilities.LogMessage("UserRoles.TasksSelection :: Try to click Add button match the max time...");
                                    throw;
                                }
                            }
                        }
                    }
                    else
                    {
                        this.tasksProperties.Controls.ExplicitlyApprovedTasksRadioButton.Click();
                        int retry = 0;
                        while (retry < 10)
                        {
                            try
                            {
                                ClickToolbarButton(this.tasksProperties.Controls.AddRemoveToolbar, IndexOfAddButton);
                                break;
                            }
                            catch
                            {
                                retry++;
                                Utilities.LogMessage(string.Format("UserRoles.TasksSelection :: Try to click Add button, retry time: {0}", retry));
                                this.tasksProperties.Controls.ExplicitlyApprovedTasksRadioButton.Click();
                                Utilities.TakeScreenshot("AfterFixTime" + retry);
                                if (retry == 10)
                                {
                                    Utilities.LogMessage("UserRoles.TasksSelection :: Try to click Add button match the max time...");
                                    throw;
                                }
                            }
                        }
                    }

                    int targetHeaderColPos = -1;
                    targetHeaderColPos = consoleApp.GeListViewtColumnPosition(Core.Console.Dialogs.SelectTasksDialog.Strings.TasksColumnHeader, this.selectTasksDialog.Controls.TasksListView);

                    foreach (string task in tasksList)
                    {
                        int maxRetires = 5;
                        int retry = 0;
                        while (retry < maxRetires)
                        {
                            if (CoreManager.MomConsole.SelectListViewItems(task, targetHeaderColPos, this.selectTasksDialog.Controls.TasksListView,false) == true)
                            {
                                this.selectTasksDialog.SendKeys(KeyboardCodes.Space);
                                Sleeper.Delay(Constants.OneSecond);                                
                                if (!this.selectTasksDialog.Controls.TasksListView.SelectedItem.Checked)
                                {
                                    Utilities.LogMessage("UserRoles.TasksSelection :: Failed in selecting Task: " + task + " Retry...");
                                    this.selectTasksDialog.SendKeys(KeyboardCodes.Space);
                                    Sleeper.Delay(Constants.OneSecond);
                                }
                                Utilities.LogMessage("UserRoles.TasksSelection :: Sucess in selecting Task: " + task);
                                break;
                            }
                            else
                            {
                                Utilities.LogMessage("UserRoles.TasksSelection :: Task not found: " + task);
                                retry++;
                                Utilities.LogMessage("UserRoles.TasksSelection :: Attempt :" + retry);
                                Sleeper.Delay(Constants.OneSecond * 2);
                            }
                        }
                    }
                    //Close the selectTasksDialog after Task selection
                    if (this.selectTasksDialog.Controls.OKButton.Extended.IsEnabled)
                    {
                        Utilities.LogMessage("UserRoles.TasksSelection :: Tasks selected - close the dialog");
                        this.selectTasksDialog.ClickOK();
                    }
                    else
                    {
                        Utilities.LogMessage("UserRoles.TasksSelection :: No Tasks selected - close the dialog");
                        this.selectTasksDialog.ClickTitleBarClose();
                        throw new Maui.Core.WinControls.Button.Exceptions.ControlIsDisabledException("Select Tasks Dialog - OK button is not enabled");
                    }
                }
            }
            // [a-joelj] Maui 2.0 Required Change: Due to Change# 141648 this Waiters.WaitForButtonEnabled was 
            // causing WindowNotFound exception if we aren't in a Wizard dialog (like User Role properties 
            // when Modifying a User Role). Now checking if wizardDialog == true before waiting for NextButton
            if (wizardDialog == true)
            {
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.tasksDialog.Controls.NextButton, Constants.OneMinute);
            }
            
        }
                
        #endregion

        #region Private Methods
        
        /// <summary>
        /// Method to click a particular toolbar button (add/remove) based on
        /// index passed in
        /// </summary>
        /// <param name="myToolbar">Toolbar containing items to click</param>
        /// <param name="indexToClick">index of item to click</param>
        /// <history>
        ///    [faizalk] 08DEC2005   Created
        /// </history>
        private void ClickToolbarButton(Toolbar myToolbar, int indexToClick)
        {
            ToolbarItemCollection tbCollection = myToolbar.get_ToolbarItems(false);
            Utilities.LogMessage("UserRoles.ClickToolbarButton :: Creating ToolbarItem array of size " + tbCollection.Count);
            ToolbarItem[] tbArray = new ToolbarItem[tbCollection.Count];
            Utilities.LogMessage("UserRoles.ClickToolbarButton :: Copying ToolbarItemCollection to ToolbarItem array");
            tbCollection.CopyTo(tbArray, 0);
            foreach (ToolbarItem tbi in tbArray)
            {
                Utilities.LogMessage("UserRoles.ClickToolbarButton :: tbArray - " + tbi.Text);
            }
            Utilities.LogMessage("UserRoles.ClickToolbarButton :: clicking button at index " + indexToClick);
            tbArray[indexToClick].Click();
        }        

        /// <summary>
        /// UserRole parameters structure.
        /// </summary>
        /// <param name="parameters">UserRoleParameters</param>
        /// <returns>Parameters</returns>
        /// <history>
        ///		[ruhim] 03FEB06 Created
        /// </history>
        private static UserRoleParameters UpdateParameters(UserRoleParameters parameters)
        {
            Utilities.LogMessage("UserRoleApp.UpdateParameters:: ");

            return parameters;
        }

        /// <summary>
        /// Wait for Warning Dialog.
        /// </summary>
        /// <history>
        ///		[visnara] 11JUL07 Created
        /// </history>
        private void WaitForWarningDialog()
        {
            try
            {                    
                CoreManager.MomConsole.Waiters.WaitForWindowAppeared(
                    CoreManager.MomConsole.MainWindow, 
                    new QID(";[UIA]Name='" + Strings.WarningDialogTitle + "'"), 
                    Constants.DefaultDialogTimeout);

                CoreManager.MomConsole.ConfirmChoiceDialog(
                    MomConsoleApp.ButtonCaption.OK, 
                    Strings.WarningDialogTitle, 
                    StringMatchSyntax.WildCard, 
                    MomConsoleApp.ActionIfWindowNotFound.Error);
            }
            catch (Window.Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage("UserRoles.WaitForWarningDialog:: Warning dialog not found");  
            }
        }

        #endregion

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for User Role
        /// </summary>
        /// <history> 	
        ///   [ruhim]  06Sep05: Created. Added resource strings for user roles 
        ///                     specific views
        ///   [ruhim]  16Jan06: Adding strings to get Current Logged in Users name and Domain.
        ///                     And Deleting all the obsolete strings
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Contains GUID for:  "Operator" Profile
            /// </summary>            
            private const string GUIDOperatorProfile = "222DFDD1-F100-4763-A253-418A58AE6E42";

            /// <summary>
            /// Contains GUID for:  "Read only Operator" Profile
            /// </summary>            
            private const string GUIDReadOnlyOperatorProfile = "F15E9A46-8052-4867-9724-B69D0BC3B79E";

            /// <summary>
            /// Contains GUID for:  "Author" Profile
            /// </summary>            
            private const string GUIDAuthorProfile = "3E927DA5-3BA5-4CBE-94B3-D23FC0FC7575";

            /// <summary>
            /// Contains GUID for:  "MonitoringPolicyEditor" Profile
            /// </summary>            
            private const string GUIDMonitoringPolicyEditorProfile = "B0D29ED8-2B8E-4228-9545-E6EF48757AB6";

            /// <summary>
            /// Contains GUID for:  "Administrator" Profile
            /// </summary>            
            private const string GUIDAdministratorProfile = "25D0CD39-407F-4717-ADB9-8B824BC773E9";

            /// <summary>
            /// Contains GUID for:  "Operations Manager Operators" UserRoleId
            /// </summary>            
            private const string GUIDOperatorsUserRoleName = "3BF09528-6CFA-4E09-BF87-ECADE3373814";

            /// <summary>
            /// Contains GUID for:  "Operations Manager Read only Operators" UserRoleId
            /// </summary>            
            private const string GUIDReadOnlyOperatorsUserRoleName = "9F86F9A1-E2D4-4116-893A-F450F800F55D";

            /// <summary>
            /// Contains GUID for:  "Operations Manager Authors" UserRoleId
            /// </summary>            
            private const string GUIDAuthorsUserRoleName = "35B4A078-1F02-4988-9599-6824792722CE";

            /// <summary>
            /// Contains GUID for:  "Operations Manager Advanced Operators" UserRoleId
            /// </summary>            
            private const string GUIDAdvancedOperatorsUserRoleName = "489E12F0-6ADA-4647-91DB-65AB9FF0B40E";

            /// <summary>
            /// Contains GUID for:  "Operations Manager Administrators" UserRoleId
            /// </summary>            
            private const string GUIDAdministratorsUserRoleName = "597F9D98-356F-4186-8712-4F020F2D98B4";

            /// <summary>
            /// Contains Resource string for:  Save and Close button in the Toolstrip
            /// </summary>            
            private const string ResourceSaveandCloseToolStrip = 
                ";Save a&nd Close;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.SheetFramework;buttonSaveAndClose.Text";

            /// <summary>
            /// Contains Resource string for:  Column Name "User Role" in User Role View
            /// </summary>            
            private const string ResourceUserRoleColumnName =
                ";User Role;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;UserRolesViewRoleName";

            /// <summary>
            /// Contains Resource string for:  Warning Dialog Title "Approving specific views"
            /// </summary>            
            private const string ResourceWarningDialogTitle =
                ";Approving specific views;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RoleGivenDashboardAccessTitle";

            /// <summary>
            /// Contains Resource string for: Warning Dialog Title "Warning"
            /// </summary>
            private const string ResourceWarningMessageTitle =
                ";Warning;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Warning";
           
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets the network doamin name associated with the current user
            /// </summary>       
            /// -----------------------------------------------------------------------------
            public static string UserDNSDomain = Environment.UserDomainName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets the User Name of the person who started the cuurent thread
            /// </summary>       
            /// -----------------------------------------------------------------------------
            public static string Username = Environment.UserName;
            
            #endregion

            #region Private Members
                        
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Operator Profile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOperatorProfile;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Read Only Operator Profile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedReadOnlyOperatorProfile;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Author Profile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAuthorProfile;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Monitoring Policy Editor Profile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitoringPolicyEditorProfile;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Administrator Profile
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministratorProfile;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Save and Close button in the Toolstrip
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSaveandCloseToolStrip;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Column Name "User Role" in User Role View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUserRoleColumnName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Operations Manager Operators
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOperatorsUserRoleName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Operations Manager Read Only Operators
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedReadOnlyOperatorsUserRoleName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Operations Manager Authors
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAuthorsUserRoleName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Operations Manager Advanced Operators
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdvancedOperatorsUserRoleName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Operations Manager Administrators
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministratorsUserRoleName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Approving specific views
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWarningDialogTitle;

            /// <summary>
            /// Caches the translated resource string for: Warning
            /// </summary>
            private static string cachedWarningMessageTitle;

            private static string cachedNetWorkMonitoring;
            private static string cachedNetWorkSummaryDashboardName;

            private static string cachedNetWorkNodeDashboardName;

            private static string cachedNetWorkInterfaceDashboardName;

            private static string cachedVicinityDashboardName;

            //private static string cachedServiceLevelTrackingName;

            //private static string cachedServiceLevelDashboardLast7DaysName;

            //private static string cachedServiceLevelDashboardLast30DaysName;
            #endregion

            #region Properties            

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Operator Profile translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 29NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Operator
            {
                get
                {
                    if ((cachedOperatorProfile == null))
                    {
                        cachedOperatorProfile = Utilities.GetUserRoleProfileName(GUIDOperatorProfile);
                    }

                    return cachedOperatorProfile;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Read Only Operator Profile translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 29NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ReadOnlyOperator
            {
                get
                {
                    if ((cachedReadOnlyOperatorProfile == null))
                    {
                        cachedReadOnlyOperatorProfile = Utilities.GetUserRoleProfileName(GUIDReadOnlyOperatorProfile);
                    }

                    return cachedReadOnlyOperatorProfile;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Author Profile translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 29NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Author
            {
                get
                {
                    if ((cachedAuthorProfile == null))
                    {
                        cachedAuthorProfile = Utilities.GetUserRoleProfileName(GUIDAuthorProfile);
                    }

                    return cachedAuthorProfile;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Monitoring Policy Editor Profile translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 29NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitoringPolicyEditor
            {
                get
                {
                    if ((cachedMonitoringPolicyEditorProfile == null))
                    {
                        cachedMonitoringPolicyEditorProfile = Utilities.GetUserRoleProfileName(GUIDMonitoringPolicyEditorProfile);
                    }

                    return cachedMonitoringPolicyEditorProfile;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Administrator Profile translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 29NOV05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Administrator
            {
                get
                {
                    if ((cachedAdministratorProfile == null))
                    {
                        cachedAdministratorProfile = Utilities.GetUserRoleProfileName(GUIDAdministratorProfile);
                    }

                    return cachedAdministratorProfile;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Operations Manager Operators translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 12Mar075 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OperatorsUserRoleName
            {
                get
                {
                    if ((cachedOperatorsUserRoleName == null))
                    {
                        cachedOperatorsUserRoleName = Utilities.GetUserRoleName(GUIDOperatorsUserRoleName);
                    }

                    return cachedOperatorsUserRoleName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Operations Manager Read Only Operators translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 12Mar075 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ReadOnlyOperatorsUserRoleName
            {
                get
                {
                    if ((cachedReadOnlyOperatorsUserRoleName == null))
                    {
                        cachedReadOnlyOperatorsUserRoleName = Utilities.GetUserRoleName(GUIDReadOnlyOperatorsUserRoleName);
                    }

                    return cachedReadOnlyOperatorsUserRoleName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Operations Manager Authors translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 12Mar075 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AuthorsUserRoleName
            {
                get
                {
                    if ((cachedAuthorsUserRoleName == null))
                    {
                        cachedAuthorsUserRoleName = Utilities.GetUserRoleName(GUIDAuthorsUserRoleName);
                    }

                    return cachedAuthorsUserRoleName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Operations Manager Advanced Operators translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 12Mar075 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdvancedOperatorsUserRoleName
            {
                get
                {
                    if ((cachedAdvancedOperatorsUserRoleName == null))
                    {
                        cachedAdvancedOperatorsUserRoleName = Utilities.GetUserRoleName(GUIDAdvancedOperatorsUserRoleName);
                    }

                    return cachedAdvancedOperatorsUserRoleName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Operations Manager Administrators translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 12Mar075 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministratorsUserRoleName
            {
                get
                {
                    if ((cachedAdministratorsUserRoleName == null))
                    {
                        cachedAdministratorsUserRoleName = Utilities.GetUserRoleName(GUIDAdministratorsUserRoleName);
                    }

                    return cachedAdministratorsUserRoleName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Save and Close button in the Toolstrip
            /// </summary>
            /// <history>
            /// 	[ruhim] 09Jan06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SaveandCloseToolStrip
            {
                get
                {
                    if ((cachedSaveandCloseToolStrip == null))
                    {
                        cachedSaveandCloseToolStrip = CoreManager.MomConsole.GetIntlStr(ResourceSaveandCloseToolStrip);
                    }

                    return cachedSaveandCloseToolStrip;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Column Name "User Role" in User Role View
            /// </summary>
            /// <history>
            /// 	[ruhim] 13Jan06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UserRoleColumnName
            {
                get
                {
                    if ((cachedUserRoleColumnName == null))
                    {
                        cachedUserRoleColumnName = CoreManager.MomConsole.GetIntlStr(ResourceUserRoleColumnName);
                    }

                    return cachedUserRoleColumnName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to User Role Warning Dialog Title "Approving specific views"
            /// </summary>
            /// <history>
            /// 	[v-juli] 23June10 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WarningDialogTitle
            {
                get
                {
                    if ((cachedWarningDialogTitle == null))
                    {
                        cachedWarningDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceWarningDialogTitle);
                    }

                    return cachedWarningDialogTitle;
                }
            }

            /// <summary>
            /// Exposes access to User Role Warning Message Form Title "Warning"
            /// </summary>
            /// <history>
            ///  [v-johnx] 28/3/2011 Created
            /// </history>>
            public static string WarningMessageTitle
            {
                get
                {
                    if ((cachedWarningMessageTitle == null))
                    {
                        cachedWarningMessageTitle = CoreManager.MomConsole.GetIntlStr(ResourceWarningMessageTitle);
                    }

                    return cachedWarningMessageTitle;
                }
            }

            public static string NetWorkMonitoring
            {
                get
                {
                    if (cachedNetWorkMonitoring==null)
                    {
                        cachedNetWorkMonitoring = Utilities.GetFolderDisplayName(ManagementPackConstants.SystemNetworkManagementMonitoring,Constants.NetworkMonitoring);
                        Utilities.LogMessage("NetWorkMonitoring:: " + cachedNetWorkMonitoring);
                    }
                    return cachedNetWorkMonitoring;
                }
            }

            public static string NetWorkSummaryDashboard
            {
                get
                {
                    if (cachedNetWorkSummaryDashboardName==null)
                    {
                        cachedNetWorkSummaryDashboardName = Utilities.GetDisplayStringForComponent(Constants.NetWorkSummaryDashboardName);
                        Utilities.LogMessage("NetWorkSummaryDashboard:: " + cachedNetWorkSummaryDashboardName);
                    }
                    return cachedNetWorkSummaryDashboardName;
                }
            }
            
            public static string NetWorkNodeDashboard
            {
                get
                {
                    if (cachedNetWorkNodeDashboardName==null)
                    {
                        cachedNetWorkNodeDashboardName = Utilities.GetDisplayStringForComponent(Constants.NetWorkNodeDashboardName);
                        Utilities.LogMessage("NetWorkNodeDashboard:: " + cachedNetWorkNodeDashboardName);
                    }
                    return cachedNetWorkNodeDashboardName;
                }
            }

            public static string NetWorkInterfaceDashboard
            {
                get
                {
                    if (cachedNetWorkInterfaceDashboardName==null)
                    {
                        cachedNetWorkInterfaceDashboardName = Utilities.GetDisplayStringForComponent(Constants.NetWorkInterfaceDashboardName);

                        Utilities.LogMessage("NetWorkInterfaceDashboard:: " + cachedNetWorkInterfaceDashboardName);
                    }
                    return cachedNetWorkInterfaceDashboardName;
                }
            }

            public static string VicinityDashboard
            {
                get
                {
                    if (cachedVicinityDashboardName==null)
                    {
                        cachedVicinityDashboardName = Utilities.GetDisplayStringForComponent(Constants.NodeVicinityDashboardName);
                        Utilities.LogMessage("VicinityDashboard:: " + cachedVicinityDashboardName);
                    }
                    return cachedVicinityDashboardName;
                }
            }

            //public static string ServiceLevelTracking
            //{
            //    get
            //    {
            //        if (cachedServiceLevelTrackingName == null)
            //        {
            //            cachedServiceLevelTrackingName = Utilities.GetFolderDisplayName(ManagementPackConstants.MicrosoftSystemCenterVisualizationLibrary,Constants.ServiceLevelTrackingName);
            //            Utilities.LogMessage("ServiceLevelTracking:: " + cachedServiceLevelTrackingName);
            //        }
            //        return cachedServiceLevelTrackingName;
            //    }
            //}

            //public static string ServiceLevelDashboardLast7Days
            //{
            //    get
            //    {
            //        if (cachedServiceLevelDashboardLast7DaysName == null)
            //        {
            //            cachedServiceLevelDashboardLast7DaysName = Utilities.GetDisplayStringForComponent(Constants.ServiceLevelDashboardLast7DaysName);
            //            Utilities.LogMessage("ServiceLevelDashboardLast7Days:: " + cachedServiceLevelDashboardLast7DaysName);
            //        }
            //        return cachedServiceLevelDashboardLast7DaysName;
            //    }
            //}

            //public static string ServiceLevelDashboardLast30Days
            //{
            //    get
            //    {
            //        if (cachedServiceLevelDashboardLast30DaysName == null)
            //        {
            //            cachedServiceLevelDashboardLast30DaysName = Utilities.GetDisplayStringForComponent(Constants.ServiceLevelDashboardLast30DaysName);
            //            Utilities.LogMessage("ServiceLevelDashboardLast30Days:: " + cachedServiceLevelDashboardLast30DaysName);
            //        }
            //        return cachedServiceLevelDashboardLast30DaysName;
            //    }
            //}
            #endregion
        }
        #endregion

        #region UserRoleParameters Class
        /// <summary>
        /// Parameters class for UserRoles constructors.
        /// </summary>
        /// <history>
        /// [ruhim] 03FEB06 Created
        /// </history>
        public class UserRoleParameters
        {
            #region Private Members
            private UserRoles.Profiles cachedProfile;
            private string cachedName = null;
            private string cachedDescription = null;
            private ArrayList cachedMembers = new ArrayList();
            private ArrayList cachedTargets = new ArrayList();
            private ArrayList cachedGroups = new ArrayList();
            private ArrayList cachedTasks = new ArrayList();
            private ArrayList cachedViewPaths = new ArrayList();
            private ArrayList cachedDrillDownDashboards = new ArrayList();
            #endregion

            #region Constructors

            /// <summary>
            /// Default Constructor - no need in ExePath etc. Inherited classes
            /// from Console set all required properties on parameter objects.
            /// </summary>
            public UserRoleParameters()
            {
            }
            #endregion

            #region Properties

            /// <summary>
            /// Profile of User Role
            /// </summary>
            public UserRoles.Profiles Profile
            {
                get
                {
                    return this.cachedProfile;
                }

                set
                {
                    this.cachedProfile = value;
                }
            }

            /// <summary>
            /// Name of User Role
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
            /// Description of User Role
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
            /// Members of a User Role
            /// </summary>
            public ArrayList Members
            {
                get
                {
                    return this.cachedMembers;
                }

                set
                {
                    this.cachedMembers.Add(value);
                }
            }

            /// <summary>
            /// Groups for scoping
            /// </summary>
            public ArrayList Groups
            {
                get
                {
                    return this.cachedGroups;
                }

                set
                {
                    this.cachedGroups.Add(value);
                }
            }

            /// <summary>
            /// Targets to be selected for the Author Scope
            /// </summary>
            public ArrayList Targets
            {
                get
                {
                    return this.cachedTargets;
                }

                set
                {
                    this.cachedTargets.Add(value);
                }
            }

            /// <summary>
            /// Tasks to be selected for Task scope
            /// </summary>
            public ArrayList Tasks
            {
                get
                {
                    return this.cachedTasks;
                }

                set
                {
                    this.cachedTasks.Add(value);
                }
            }

            /// <summary>
            /// Views to be selected for View Scope. View Names should include
            /// the complete path using Constants.Delimiter as the seperator
            /// </summary>
            public ArrayList ViewPaths
            {
                get
                {
                    return this.cachedViewPaths;
                }

                set
                {
                    this.cachedViewPaths.Add(value);
                }
            }

            /// <summary>
            /// Views to be selected for View Scope. View Names should include
            /// the complete path using Constants.Delimiter as the seperator
            /// </summary>
            public ArrayList DrillDownDashboards
            {
                get
                {
                    return this.cachedDrillDownDashboards;
                }

                set
                {
                    this.cachedDrillDownDashboards.Add(value);
                }
            }
            #endregion
        }
        #endregion

    } //end of class UserRole

}//end of namespace