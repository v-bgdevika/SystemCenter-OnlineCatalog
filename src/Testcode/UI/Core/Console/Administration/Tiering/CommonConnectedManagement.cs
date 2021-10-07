//-------------------------------------------------------------------
// <copyright file="CommonConnectedManagement.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//   Common method to connected management framework
// </summary>
//  <history>
//  [v-yoz] 24JUNE09:  Created
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Administration.Tiering
{
    #region Using directives

    using System;
    using Infra.Frmwrk;
    using Maui.GlobalExceptions;
    using Maui.Core;
    using Mom.Test.UI.Core;
    using Mom.Test.UI.Core.Console;
    using MomCommon = Mom.Test.UI.Core.Common;

    #endregion

    /// <summary>
    /// Class for CommonConnectedManagement
    /// </summary>
    public class CommonConnectedManagement
    {
        #region Member Variables

        #endregion

        #region Private Method

        #endregion

        #region Public Method

        /// <summary>
        /// Method to navigate to connected management groups View.
        /// </summary>
        /// <returns>
        /// Connected Management Groups Tree node.
        /// </returns> 
        public static Maui.Core.WinControls.TreeNode NavigateToConnectedManagementGroupsView()
        {
            Core.Common.Utilities.LogMessage("NavigateToConnectedManagementGroupsView::...");
            Core.Common.Utilities.LogMessage("NavigateToConnectedManagementGroupsView::Navigator to Administrator\\Connected Management Groups.");

            // Navigator to Connected Management Groups view in the Administrator space
            return CoreManager.MomConsole.NavigationPane.SelectNode(
                NavigationPane.Strings.Administration
                + Core.Common.Constants.PathDelimiter
                + Core.Console.NavigationPane.Strings.AdminTreeViewConnectedManagementGroups,
                NavigationPane.NavigationTreeView.Administration);
        }

        /// <summary>
        /// Method to navigate to Monitoring\UI Test\ View.
        /// </summary>
        /// <param name="alertView">
        /// The view that you want to navigate to 
        /// </param>
        /// <returns>
        /// Monitoring\UI Test\ Tree node.
        /// </returns>         
        public static Maui.Core.WinControls.TreeNode NavigateToUITestView(string alertView)
        {
            return NavigateToUITestView(alertView, MouseFlags.LeftButton);
        }

        /// <summary>
        /// Method to navigate to Monitoring\UI Test\ View.
        /// </summary>
        /// <param name="alertView">
        /// The view that you want to navigate to 
        /// </param>
        /// <param name="button">
        /// How to click the tree node 
        /// </param>
        /// <returns>
        /// Monitoring\UI Test\ Tree node.
        /// </returns> 
        public static Maui.Core.WinControls.TreeNode NavigateToUITestView(string alertView, MouseFlags button)
        {
            Core.Common.Utilities.LogMessage("NavigateToUITestView::...");
            Core.Common.Utilities.LogMessage("NavigateToUITestView::Navigator to Monitoring\\UI Test\\" + alertView);

            // Navigator to Connected Management Groups view in the Administrator space
            return CoreManager.MomConsole.NavigationPane.SelectNode(
                        NavigationPane.Strings.Monitoring
                        + Core.Common.Constants.PathDelimiter
                        + Core.Common.Constants.UITestViewFolder
                        + Core.Common.Constants.PathDelimiter
                        + alertView,
                        NavigationPane.NavigationTreeView.Monitoring,
                        button);
        }

        /// <summary>
        /// Method to start connected management group dialog.
        /// </summary>
        /// <param name="startPoint">
        /// The method that specify how to call out add connected management group dialog
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if both name
        /// is null or empty string.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Throws System.ArgumentOutOfRangeException if Startpoint is not surpport.
        /// </exception>
        public static void StartWizard(string startPoint)
        {
            Core.Common.Utilities.LogMessage("StartWizard::...");

            //Navigate to connected management groups view
            Maui.Core.WinControls.TreeNode connectedMGViewNode = NavigateToConnectedManagementGroupsView();

            switch (startPoint)
            {                
                case Constant.StartPoint.ViewContextMenu:
                    // R-click on alert and select context menu       

                    CoreManager.MomConsole.ViewPane.Grid.Click();

                    CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, 60000);

                    CoreManager.MomConsole.ExecuteContextMenu(
                        NavigationPane.Strings.ContextMenuAddManagementGroup, true);

                    Core.Common.Utilities.LogMessage("StartWizard :: " +
                        "LaunchAddManagementGroupDialogViaRightClick is done");

                    break;
                case Constant.StartPoint.MainToolsMenu:                                        
                    // Actions main menu - Alert actions - Add Management Group

                    CoreManager.MomConsole.ViewPane.Grid.Click();

                    Commands.Actions.Execute(CoreManager.MomConsole);

                    CoreManager.MomConsole.ExecuteContextMenu(
                        Core.Console.ActionsPane.Strings.ActionsPaneAdminViews +
                        Core.Common.Constants.PathDelimiter +
                        NavigationPane.Strings.ContextMenuAddManagementGroup,
                        false);

                    CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, 60000);

                    Core.Common.Utilities.LogMessage("StartWizard :: " +
                        "LaunchAddManagementGroupDialogViaMainMenuClick is done");

                    break;
                case Constant.StartPoint.TreeViewContextMenu:
                    // Tree View ContextMenu

                    // get the context menu
                    connectedMGViewNode.Click(
                        MouseFlags.RightButton);
                    Maui.Core.WinControls.Menu contextMenu =
                        new Maui.Core.WinControls.Menu(
                            Core.Common.Constants.DefaultContextMenuTimeout);

                    // select the create new channel menu item
                    contextMenu.ExecuteMenuItem(
                        NavigationPane.Strings.ContextMenuAddManagementGroup);

                    Core.Common.Utilities.LogMessage("StartWizard :: " +
                        "LaunchAddManagementGroupDialogViaTreeViewContextMenuClick is done");

                    break;
                case Constant.StartPoint.ActionsPaneLinkMenu:
                    // Actions - Alert Propertis in tasks pane

                    CoreManager.MomConsole.ViewPane.Grid.Click();

                    Core.Console.ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;

                    taskPane.ClickLink(
                        ActionsPane.Strings.ActionsPaneAdminViews,
                        Core.Common.Utilities.RemoveAcceleratorKeys(NavigationPane.Strings.ContextMenuAddManagementGroup));

                    CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, 60000);

                    Core.Common.Utilities.LogMessage("StartWizard :: " +
                        "LaunchAddManagementGroupDialogViaTasksPaneClick");

                    break;
                default:
                    throw new System.ArgumentOutOfRangeException(
                            "Unknown or undefined start point := '" +
                            startPoint +
                            "'");
                    
            }
        }

        /// <summary>
        /// Method to add a connected management group.
        /// It requires 2 management group topology
        /// </summary>
        /// <param name="managementGroupName">
        /// The name of management group that need be connected.
        /// </param>
        /// <param name="rootServerName">
        /// The name of Root management server that need be connected 
        /// </param>
        public static void AddConnectedManagementGroup(string managementGroupName, string rootServerName)
        {
            Core.Common.Utilities.LogMessage("AddConnectedManagementGroup::...");

            AddConnectedManagementGroup(managementGroupName, rootServerName, Constant.StartPoint.ViewContextMenu);
        }

        /// <summary>
        /// Method to add a connected management group.
        /// It requires 2 management group topology
        /// </summary>
        /// <param name="managementGroupName">
        /// The name of management group that need be connected.
        /// </param>
        /// <param name="rootServerName">
        /// The name of RMS that need be connected
        /// </param>
        /// <param name="startPoint">
        /// The action that specify how to call out add connected management group dialog
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if both name
        /// is null or empty string.
        /// </exception>
        public static void AddConnectedManagementGroup(string managementGroupName, string rootServerName, string startPoint)
        {
            Core.Common.Utilities.LogMessage("AddConnectedManagementGroup::...");

            // check for valid parameters
            if (String.IsNullOrEmpty(managementGroupName))
            {
                throw new System.ArgumentNullException(
                    "Management group name parameter must not be null or empty string!");
            }
            if (String.IsNullOrEmpty(rootServerName))
            {
                throw new System.ArgumentNullException(
                    "Root server name parameter must not be null or empty string!");
            }
            if (String.IsNullOrEmpty(startPoint))
            {
                throw new System.ArgumentNullException(
                    "Start point must not be null or empty string!");
            }

            // remove exist management group
            if (IsConnectedManagementGroupExist(managementGroupName, rootServerName) == true)
            {
                Core.Common.Utilities.LogMessage(string.Format("The management group {0} has been added, just remove it before test", managementGroupName));
                DeleteConnectedManagementGroup(managementGroupName, rootServerName);
            }

            //Call out add connected management group dialog
            //Add retry logic to fix test bug #497373
            int retryIndex = 0, maxRetry = 5;
            while (retryIndex < maxRetry)
            {
                retryIndex++;
                try
                {
                    StartWizard(startPoint);
                    break;
                }
                catch (Exception e)
                {
                    Core.Common.Utilities.LogMessage(string.Format("StartWizard failed, retryIndex={0},maxRetry={1},Exception:{2}",retryIndex,maxRetry,e.Message));
                    Core.Common.Utilities.TakeScreenshot("StartWizard failed retry times-"+retryIndex);
                    CoreManager.MomConsole.CloseChildDialogWindows();
                    CoreManager.MomConsole.SendKeys("ESC");
                    System.Threading.Thread.Sleep(TimeSpan.FromMinutes(3));

                    if (retryIndex == maxRetry)
                    {
                        Core.Common.Utilities.LogMessage("StartWizard failed reached max retry times.");
                        Core.Common.Utilities.LogMessage(e.StackTrace);
                        Core.Common.Utilities.TakeScreenshot("StartWizard failed reached max retry times");
                        throw e;
                    }
                }
            }

            //Get a add management group dialog
            Core.Console.Administration.Tiering.AddManagementGroupDialog addManagementGroupDialog =
                new Core.Console.Administration.Tiering.AddManagementGroupDialog(CoreManager.MomConsole);

            //Type in management group name
            addManagementGroupDialog.ManagementGroupNameText = managementGroupName;
            Core.Common.Utilities.LogMessage("AddConnectedManagementGroup :: ManagementGroupNameText := '" +
                        addManagementGroupDialog.ManagementGroupNameText +
                        "'");

            //Type in root management server name
            addManagementGroupDialog.RootManagementServerText = rootServerName;
            Core.Common.Utilities.LogMessage("AddConnectedManagementGroup :: RootManagementServerText := '" +
                        addManagementGroupDialog.RootManagementServerText +
                        "'");

            addManagementGroupDialog.RadioGroup0 = Mom.Test.UI.Core.Console.Administration.Tiering.RadioGroup0.OtherUserAccount;
            Core.Common.Utilities.LogMessage("AddConnectedManagementGroup :: RadioGroup0 := '" +
                        Mom.Test.UI.Core.Console.Administration.Tiering.RadioGroup0.OtherUserAccount.ToString() +
                        "'");

            addManagementGroupDialog.UserNameText = 
                Core.Common.Utilities.UserDomainName + 
                Core.Common.Constants.PathDelimiter + 
                Core.Common.Utilities.UserName;

            Core.Common.Utilities.LogMessage("AddConnectedManagementGroup :: UserNameText := '" +
                        addManagementGroupDialog.UserNameText +
                        "'");

            addManagementGroupDialog.PasswordText = 
                Core.Common.Utilities.GetDomainUserPassword(
                    Core.Common.Utilities.UserDomainName, 
                    Core.Common.Utilities.UserName);

            //Core.Common.Utilities.LogMessage("AddConnectedManagementGroup :: PasswordText := '" +
            //            addManagementGroupDialog.PasswordText +
            //            "'");

            //Click OK button and Close dialog
            addManagementGroupDialog.ClickAdd();

            // wait for the UI to settle
            CoreManager.MomConsole.Waiters.WaitForStatusReady(
                Core.Common.Constants.DefaultDialogTimeout);
        }

        /// <summary>
        /// Method to do delete action to a connected management group.
        /// </summary>
        /// <param name="row">
        /// The parameter that specify which row need be deleted.
        /// </param>
        /// <param name="deleteAction">
        /// The method that specify how to delete connected management group
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if both name
        /// is null or empty string.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Throws System.ArgumentOutOfRangeException if DeleteAction is not surpport.
        /// </exception>
        public static void DeleteAction(Maui.Core.WinControls.DataGridViewRow row, string deleteAction)
        {
            Core.Common.Utilities.LogMessage("DeleteAction::...");
            
            switch (deleteAction)
            {
                case Constant.DeleteAction.MainToolsMenu:
                    // Actions main menu - Alert actions - Delete

                    row.AccessibleObject.Click();

                    Commands.Actions.Execute(CoreManager.MomConsole);

                    CoreManager.MomConsole.ExecuteContextMenu(
                        Core.Console.ActionsPane.Strings.ActionsPaneAdminViews +
                        Core.Common.Constants.PathDelimiter +
                        Core.Console.ViewPane.Strings.AdministrationContextMenuDelete,
                        false);

                    CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, 60000);

                    Core.Common.Utilities.LogMessage("DeleteAction :: " +
                        "DeleteViaMainMenuClick is done");

                    break;
                case Constant.DeleteAction.ViewContextMenu:

                    #region Right-Click Item, Select Delete Context Menu

                    row.AccessibleObject.Click();

                    Core.Common.Utilities.LogMessage(
                        "DeleteAction::Using right-click, context menu...");

                    // right-click item, properties menu
                    row.AccessibleObject.Click(
                        MouseFlags.RightButton);

                    Core.Common.Utilities.LogMessage(
                        "DeleteAction::Looking for context menu...");

                    // get the context menu
                    Maui.Core.WinControls.Menu contextMenu =
                        new Maui.Core.WinControls.Menu(
                            Core.Common.Constants.DefaultContextMenuTimeout);

                    Core.Common.Utilities.LogMessage(
                        "DeleteAction::Selecting context menu '" +
                        Core.Console.ViewPane.Strings.AdministrationContextMenuDelete +
                        "'");

                    // select the 'Properties' menu
                    contextMenu.ExecuteMenuItem(
                        Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                    Core.Common.Utilities.LogMessage("DeleteAction :: " +
                        "DeleteViaViewContextMenuClick is done");

                    #endregion Right-Click Item, Select Delete Context Menu

                    break;
                case Constant.DeleteAction.ViewDeleteKey:

                    #region Left-Click Item, Press DELETE Key

                    // select item, press ENTER key
                    Core.Common.Utilities.LogMessage(
                        "DeleteAction::Using left-click, DELETE...");

                    // delay to prevent a previous click from becoming a double-click
                    Maui.Core.Utilities.Sleeper.Delay(
                        Core.Common.Constants.OneSecond);

                    // left-click item, properties menu
                    row.AccessibleObject.Click(
                        MouseFlags.LeftButton);

                    // display context menu using keyboard
                    row.AccessibleObject.Window.SendKeys(
                        Core.Common.KeyboardCodes.Delete);
                    
                    Core.Common.Utilities.LogMessage("DeleteAction :: " +
                       "DeleteViaViewDeleteKeyClick is done");

                    #endregion Left-Click Item, Press DELETE Key

                    break;
                case Constant.DeleteAction.ActionsPaneLinkMenu:

                    #region Actions Pane Properties Link

                    // left-click item
                    row.AccessibleObject.Click();

                    // remove accelerator keys from the resource string
                    string actionsPaneLinkText =
                        Core.Common.Utilities.RemoveAcceleratorKeys(
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                    Core.Common.Utilities.LogMessage(
                        "DeleteAction::Using link text := '" +
                        actionsPaneLinkText +
                        "'");

                    Core.Console.ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
                    taskPane.ClickLink(
                        Core.Console.ActionsPane.Strings.ActionsPaneAdminViews,
                        actionsPaneLinkText);

                    Core.Common.Utilities.LogMessage("DeleteAction :: " +
                       "DeleteViaActionsPaneLinkMenuClick is done");

                    #endregion Actions Pane Properties Link

                    break;
                default:
                    throw new System.ArgumentOutOfRangeException(
                            "Unknown or undefined delete action := '" +
                            deleteAction +
                            "'");
                    
            }
        }

        /// <summary>
        /// Method to Delete a connected management group.
        /// It requires 2 management group topology
        /// </summary>
        /// <param name="managementGroupName">
        /// The name of management group that need be connected.
        /// </param>
        /// <param name="rootServerName">
        /// The name of Root management server that need be connected   
        /// </param>
        public static void DeleteConnectedManagementGroup(string managementGroupName, string rootServerName)
        {
            Core.Common.Utilities.LogMessage("DeleteConnectedManagementGroup::...");

            DeleteConnectedManagementGroup(managementGroupName, rootServerName, Constant.DeleteAction.ViewContextMenu, true);
        }

        /// <summary>
        /// Method to Delete a connected management group.
        /// It requires 2 management group topology
        /// </summary>
        /// <param name="managementGroupName">
        /// The name of management group that need be connected.
        /// </param>
        /// <param name="rootServerName">
        /// The name of Root management server that need be connected 
        /// </param>
        /// <param name="deleteAction">
        /// The Action that specify how to delete a connected management group
        /// </param>
        public static void DeleteConnectedManagementGroup(string managementGroupName, string rootServerName, string deleteAction)
        {
            Core.Common.Utilities.LogMessage("DeleteConnectedManagementGroup::...");

            DeleteConnectedManagementGroup(managementGroupName, rootServerName, deleteAction, true);
        }

        /// <summary>
        /// Method to delete a connected management group.
        /// It requires 2 management group topology
        /// </summary>
        /// <param name="managementGroupName">
        /// The name of management group that need be connected.
        /// </param>
        /// <param name="rootServerName">
        /// The name of RMS that need be connected
        /// </param>
        /// <param name="deleteAction">
        /// The Action that specify how to delete a connected management group
        /// </param>
        /// <param name="confirmDeletion">
        /// Flag indicating if the deletion should be confirmed and committed.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if both name
        /// is null or empty string.
        /// </exception>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridCellNotFoundException">
        /// Throws Maui.Core.WinControls.DataGrid.Exceptions.DataGridCellNotFoundException if the connected management group item 
        /// that want to be deleted is not found in the view
        /// </exception>
        public static void DeleteConnectedManagementGroup(string managementGroupName, string rootServerName, string deleteAction, bool confirmDeletion)
        {
            Core.Common.Utilities.LogMessage("DeleteConnectedManagementGroup::...");

            // check for valid parameters
            if (String.IsNullOrEmpty(managementGroupName))
            {
                throw new System.ArgumentNullException(
                    "Management group name parameter must not be null or empty string!");
            }
            if (String.IsNullOrEmpty(rootServerName))
            {
                throw new System.ArgumentNullException(
                    "Root server name parameter must not be null or empty string!");
            }
            if (String.IsNullOrEmpty(deleteAction))
            {
                throw new System.ArgumentNullException(
                    "Start point must not be null or empty string!");
            }

            NavigateToConnectedManagementGroupsView();

            //find the connected management group
            Maui.Core.WinControls.DataGridViewRow row = null;
            Core.Common.Utilities.LogMessage("DeleteConnectedManagementGroup:: Found Alert View Grid");

            row = CoreManager.MomConsole.ViewPane.Grid.FindInstanceRow(
                       Strings.ManagementGroupName,
                       Strings.ManagementServer,
                       managementGroupName,
                       rootServerName,
                       10);

            if (row != null)
            {
                CoreManager.MomConsole.ViewPane.Grid.ScrollToRow(row.AccessibleObject.Index);

                //delete management group via delete action
                DeleteAction(row, deleteAction);

                #region Confirm Deletion

                Core.Common.Utilities.LogMessage(
                    "DeleteAction::Confirm deletion := '" +
                    confirmDeletion.ToString() +
                    "'");

                // confirm the delete
                CoreManager.MomConsole.ConfirmChoiceDialog(
                    confirmDeletion,
                    Strings.ConfirmDeleteManagementGroup);

                // wait for the UI to settle
                CoreManager.MomConsole.Waiters.WaitForStatusReady(
                    Core.Common.Constants.DefaultDialogTimeout);

                #endregion
            }
            else
            {
                throw new Maui.Core.WinControls.DataGrid.Exceptions.DataGridCellNotFoundException(
                    "Fail to find specify connected management group item");
            }             

        }

        /// <summary>
        /// Check if a specific connected management is exist
        /// It requires 2 management group topology
        /// </summary>
        /// <param name="managementGroupName">
        /// The name of management group that need be connected.
        /// </param>
        /// <param name="rootServerName">
        /// The name of RMS that need be connected
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if both name
        /// is null or empty string.
        /// </exception>
        public static bool IsConnectedManagementGroupExist(string managementGroupName, string rootServerName)
        {
            Core.Common.Utilities.LogMessage("IsConnectedManagementGroupExist::...");

            // check for valid parameters
            if (String.IsNullOrEmpty(managementGroupName))
            {
                throw new System.ArgumentNullException(
                    "Management group name parameter must not be null or empty string!");
            }
            if (String.IsNullOrEmpty(rootServerName))
            {
                throw new System.ArgumentNullException(
                    "Root server name parameter must not be null or empty string!");
            }

            // Navigate to connected management groups view
            NavigateToConnectedManagementGroupsView();

            //find the connected management group
            Maui.Core.WinControls.DataGridViewRow row = null;
            Core.Common.Utilities.LogMessage("IsConnectedManagementGroupExist:: Try to find Connected Management Group Grid MG Name := '" +
                managementGroupName +
                "' RMS := '" +
                rootServerName +
                "'");

            row = CoreManager.MomConsole.ViewPane.Grid.FindInstanceRow(
                       Strings.ManagementGroupName,
                       Strings.ManagementServer,
                       managementGroupName,
                       rootServerName,
                       10);

            if (row != null)
            {
                Core.Common.Utilities.LogMessage("IsConnectedManagementGroupExist:: Found Connected Management Group Grid MG Name := '" +
                    managementGroupName +
                    "' RMS := '" +
                    rootServerName +
                    "'");

                return true;
            }
            else
            {
                Core.Common.Utilities.LogMessage("IsConnectedManagementGroupExist:: Fail to find Connected Management Group Grid MG Name := '" +
                    managementGroupName +
                    "' RMS := '" +
                    rootServerName +
                    "'");
                return false;
            }
        }

        #endregion

        #region Strings Class
        /// <summary>
        /// Strings class
        /// </summary>
        public class Strings
        {
            #region Constants
            
            /// <summary>
            /// Contains resource string for the button "Show Connected Alerts"
            /// </summary>
            private const string ResourceShowConnectedAlerts =
                ";Show Connected Alerts;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;TieringButtonText";

            /// <summary>
            /// Contains resource string for the column header "Management Group Name"
            /// </summary>
            private const string ResourceManagementGroupName =
                ";Management Group Name;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ViewColumnManagementGroupName";

            /// <summary>
            /// Contains resource string for the column header "Management Server"
            /// </summary>
            private const string ResourceManagementServer =
                ";Management Server;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ViewColumnManagementServer";

            /// <summary>
            /// Contains resource string for the Dialog title "Confirm Delete Management Group"
            /// </summary>
            private const string ResourceConfirmDeleteManagementGroup =
                ";Confirm Delete Management Group;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GroupDeleteTitle";

            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the button "Show Connected Alerts"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowConnectedAlerts;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the column header "Management Group Name"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementGroupName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the column header "Root Management Server"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementServer;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Dialog title "Confirm Delete Management Group"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfirmDeleteManagementGroup;
            
            #endregion
            
            #region Properties
            
            /// <summary>
            /// Exposes access to the button "Show Connected Alerts" translated resource string
            /// </summary>
            public static string ShowConnectedAlerts
            {
                get
                {
                    if ((cachedShowConnectedAlerts == null))
                    {
                        cachedShowConnectedAlerts =
                            CoreManager.MomConsole.GetIntlStr(ResourceShowConnectedAlerts);
                    }

                    return cachedShowConnectedAlerts;
                }
            }

            /// <summary>
            /// Exposes access to the column header "Management Group Name" translated resource string
            /// </summary>
            public static string ManagementGroupName
            {
                get
                {
                    if ((cachedManagementGroupName == null))
                    {
                        cachedManagementGroupName =
                            CoreManager.MomConsole.GetIntlStr(ResourceManagementGroupName);
                    }

                    return cachedManagementGroupName;
                }
            }
            
            /// <summary>
            /// Exposes access to the the column header "Root Management Server" translated resource string
            /// </summary>
            public static string ManagementServer
            {
                get
                {
                    if ((cachedManagementServer == null))
                    {
                        cachedManagementServer =
                            CoreManager.MomConsole.GetIntlStr(ResourceManagementServer);
                    }

                    return cachedManagementServer;
                }
            }

            /// <summary>
            /// Exposes access to the Dialog title "Confirm Delete Management Group" translated resource string
            /// </summary>
            public static string ConfirmDeleteManagementGroup
            {
                get
                {
                    if ((cachedConfirmDeleteManagementGroup == null))
                    {
                        cachedConfirmDeleteManagementGroup =
                            CoreManager.MomConsole.GetIntlStr(ResourceConfirmDeleteManagementGroup);
                    }

                    return cachedConfirmDeleteManagementGroup;
                }
            }
            
            #endregion
        }
        #endregion       

        #region Constant Class
        /// <summary>
        /// Class to contain constants for the Connected framework
        /// </summary>
        public sealed class Constant
        {
            /// <summary>
            /// Class to contain constant values for var-map record StartPoint.
            /// </summary>
            public sealed class StartPoint
            {
                /// <summary>
                /// Constant for the value MainToolsMenu
                /// </summary>
                public const string MainToolsMenu = "MainToolsMenu";

                /// <summary>
                /// Constant for the value ViewContextMenu
                /// </summary>
                public const string ViewContextMenu = "ViewContextMenu";

                /// <summary>
                /// Constant for the value TreeViewContextMenu
                /// </summary>
                public const string TreeViewContextMenu = "TreeViewContextMenu";

                /// <summary>
                /// Constant for the value ActionsPaneLinkMenu
                /// </summary>
                public const string ActionsPaneLinkMenu = "ActionsPaneLinkMenu";
            }

            /// <summary>
            /// Class to contain constant values for var-map record Delete Action.
            /// </summary>
            public sealed class DeleteAction
            {
                /// <summary>
                /// Constant for the value MainToolsMenu
                /// </summary>
                public const string MainToolsMenu = "MainToolsMenu";

                /// <summary>
                /// Constant for the value ViewContextMenu
                /// </summary>
                public const string ViewContextMenu = "ViewContextMenu";

                /// <summary>
                /// Constant for the value ViewDeleteKey
                /// </summary>
                public const string ViewDeleteKey = "ViewDeleteKey";

                /// <summary>
                /// Constant for the value ActionsPaneLinkMenu
                /// </summary>
                public const string ActionsPaneLinkMenu = "ActionsPaneLinkMenu";
            }
            
            /// <summary>
            /// Class to contain constant values for var-map record Close Alert Action.
            /// </summary>
            public sealed class CloseAction
            {
                /// <summary>
                /// Constant for the value MainToolsMenu
                /// </summary>
                public const string MainToolsMenu = "MainToolsMenu";

                /// <summary>
                /// Constant for the value ViewContextMenu
                /// </summary>
                public const string ViewContextMenu = "ViewContextMenu";

                /// <summary>
                /// Constant for the value ActionsPaneLinkMenu
                /// </summary>
                public const string ActionsPaneLinkMenu = "ActionsPaneLinkMenu";
            }
        }
        #endregion

    }
}
