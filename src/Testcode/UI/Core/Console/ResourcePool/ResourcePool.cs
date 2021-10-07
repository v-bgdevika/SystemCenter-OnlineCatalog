// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ResourcePool.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	Om10 UI Test Automation
// </project>
// <summary>
// 	ResourcePool Base Class.
// </summary>
// <history>
// 	[v-yoz] 28-July-10   Created
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
using System.Collections.Generic;
#endregion


namespace Mom.Test.UI.Core.Console.ResourcePool
{
    /// <summary>
    /// Class to add general methods for ResourcePool 
    /// </summary>
    public class ResourcePool
    {
        #region Private Constants

        //Toolbar position of Add button
        private const int IndexOfAddButton = 0;

        //Toolbar position of Remove button
        private const int IndexOfRemoveButton = 1;        

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
        /// AgentPool Constructor.
        /// </summary>
        public ResourcePool()
        {
            this.consoleApp = CoreManager.MomConsole;            
        }
        #endregion

        #region Properties
        //Dialog

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to start a resource pool wizard from the specified start point
        /// in the Administration space of the UI using the specified context
        /// menu item text.
        /// </summary>
        /// <param name="startPoint">
        /// The start point in the Administration UI.  Valid values are defined
        /// in the Constants.StartPoint class.
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Throws System.ArgumentOutOfRangeException if the start point passed
        /// is not among the defined types in the Constants.StartPoint class.
        /// </exception>
        public static void StartWizard(
            string startPoint)
        {
            // start the wizard from the specified start point
            switch (startPoint)
            {
                case Constants.StartPoint.ViewContextMenu:
                    {
                        #region View Pane Context Menu

                        NavigateToView(
                            NavigationPane.Strings.AdminTreeViewResourcePoolsView);

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Selecting the view pane grid...");

                        // select the view pane
                        CoreManager.MomConsole.ViewPane.Grid.Click();

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Looking for context menu...");

                        // right-click and display context menu
                        CoreManager.MomConsole.ViewPane.Grid.Click(
                            MouseFlags.RightButton);

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Selecting context menu := '" +
                            Strings.CreateNewResourcePoolContextMenu +
                            "'");

                        // display channels sub-menu
                        contextMenu.ExecuteMenuItem(
                            Strings.CreateNewResourcePoolContextMenu);                        

                        #endregion View Pane Context Menu
                    }
                    break;
                case Constants.StartPoint.ActionsPaneLinkMenu:
                    {
                        #region Actions Pane Links

                        NavigateToView(
                            NavigationPane.Strings.AdminTreeViewResourcePoolsView);

                        // remove accelerator keys from the resource string
                        string actionsPaneLinkText =
                            Core.Common.Utilities.RemoveAcceleratorKeys(
                                Strings.CreateNewResourcePoolContextMenu);

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Using link text := '" +
                            actionsPaneLinkText +
                            "'");

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Clicking actions pane link...");

                        string pathToView =
                            Core.Console.NavigationPane.Strings.AdminTreeViewAdministrationRoot +
                            Core.Common.Constants.PathDelimiter +
                            NavigationPane.Strings.AdminTreeViewResourcePoolsView;

                        CoreManager.MomConsole.ActionsPane.ClickLink(
                            NavigationPane.WunderBarButton.Administration,
                            pathToView,
                            Core.Console.ActionsPane.Strings.ActionsPaneAdminViews,
                            actionsPaneLinkText);                        

                        #endregion
                    }
                    break;
                case Constants.StartPoint.ViewShiftF10MenuHotKey:
                    {
                        #region Left-Click Item, SHIFT-F10 pop context menu

                        NavigateToView(
                            NavigationPane.Strings.AdminTreeViewResourcePoolsView);

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Selecting the view pane grid...");

                        // select the view pane
                        CoreManager.MomConsole.ViewPane.Grid.Click();

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Looking for context menu...");

                        // display context menu using keyboard
                        CoreManager.MomConsole.ViewPane.Grid.SendKeys(
                            Core.Common.KeyboardCodes.ShiftF10);

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "StartWizard::Selecting context menu '" +
                            Strings.PropertiesContextMenu +
                            "'");

                        // select the 'Properties' menu
                        contextMenu.ExecuteMenuItem(
                            Strings.CreateNewResourcePoolContextMenu);

                        #endregion Left-Click Item, SHIFT-F10, Select Properties Context Menu
                    }
                    break;
                default:
                    {
                        throw new System.ArgumentOutOfRangeException(
                            "Unknown or undefined start point := '" +
                            startPoint +
                            "'");
                    }
            }
        }

        /// <summary>
        /// Method to launch a resource pool properties
        /// </summary>
        /// <param name="poolName">pool name</param>
        /// <param name="startPoint">launch start point</param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if pool name parameters are null or empty string.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Throws System.ArgumentException if method fails to find the 
        /// specified pool in the view, assumes pool name was incorrect.
        /// </exception>
        public static void LaunchProperties(string poolName, string startPoint)
        {
            #region Validate Parameters

            if (String.IsNullOrEmpty(poolName))
            {
                throw new System.ArgumentNullException(
                    "LaunchProperties:: Pool name parameter cannot be null or empty string!");
            }
            #endregion Validate Parameters

            #region Select Pool

            Maui.Core.WinControls.DataGridViewRow poolRow = null;
            poolRow = FindPoolRow(poolName);

            // check for valid row
            if (null == poolRow)
            {
                throw new System.ArgumentException(
                    "Failed to find the pool in the view with name := '" +
                    poolRow +
                    "'");
            }

            Core.Common.Utilities.LogMessage(
                "LaunchProperties:: Clicking the row...");

            // select the channel row
            poolRow.AccessibleObject.Click();

            Core.Common.Utilities.LogMessage(
                "LaunchProperties:: Waiting for the tooltip to disappear...");

            // wait for the tooltip to disappear
            Maui.Core.Utilities.Sleeper.Delay(
                Core.Common.Constants.DefaultContextMenuTimeout);

            #endregion Select Pool

            #region Execute properties menu/action pane
            switch (startPoint)
            {
                case Constants.StartPoint.ViewContextMenu:
                    {
                        #region Right-Click Item, Select Properties Context Menu

                        // put focus back on the row in case tooltip appeared
                        poolRow.AccessibleObject.Click();

                        Core.Common.Utilities.LogMessage(
                            "LaunchProperties::Using right-click, context menu...");

                        // right-click item, properties menu
                        poolRow.AccessibleObject.Click(
                            MouseFlags.RightButton);

                        Core.Common.Utilities.LogMessage(
                            "LaunchProperties::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "LaunchProperties::Selecting context menu '" +
                            Strings.PropertiesContextMenu +
                            "'");

                        // select the 'Properties' menu
                        contextMenu.ExecuteMenuItem(
                            Strings.PropertiesContextMenu);

                        #endregion Right-Click Item, Select Properties Context Menu
                    }

                    break;
                case Constants.StartPoint.ActionsPaneLinkMenu:
                    {
                        #region Actions Pane Properties Link

                        // remove accelerator keys from the resource string
                        string actionsPaneLinkText =
                            Core.Common.Utilities.RemoveAcceleratorKeys(
                                Strings.PropertiesContextMenu);

                        Core.Common.Utilities.LogMessage(
                            "LaunchProperties::Using link text := '" +
                            actionsPaneLinkText +
                            "'");

                        ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
                        taskPane.ClickLink(
                            Core.Console.ActionsPane.Strings.ActionsPaneAdminViews,
                            actionsPaneLinkText);

                        Core.Common.Utilities.LogMessage(
                            "LaunchProperties::Clicking actions pane link...");

                        #endregion Actions Pane Properties Link
                    }

                    break;
                case Constants.StartPoint.ViewShiftF10MenuHotKey:
                    {
                        #region Left-Click Item, SHIFT-F10, Select Properties Context Menu

                        Core.Common.Utilities.LogMessage(
                            "LaunchProperties::Using left-click, SHIFT-F10...");

                        // delay to prevent a previous click from becoming a double-click
                        Maui.Core.Utilities.Sleeper.Delay(
                            Core.Common.Constants.OneSecond);

                        // right-click item, properties menu
                        poolRow.AccessibleObject.Click(
                            MouseFlags.LeftButton);

                        // display context menu using keyboard
                        poolRow.AccessibleObject.Window.SendKeys(
                            Core.Common.KeyboardCodes.ShiftF10);

                        Core.Common.Utilities.LogMessage(
                            "LaunchProperties::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "LaunchProperties::Selecting context menu '" +
                            Strings.PropertiesContextMenu +
                            "'");

                        // select the 'Properties' menu
                        contextMenu.ExecuteMenuItem(
                            Strings.PropertiesContextMenu);

                        #endregion Left-Click Item, SHIFT-F10, Select Properties Context Menu
                    }

                    break;                
                default:
                    {
                        throw new System.ArgumentOutOfRangeException(
                            "Unknown or undefined start point := '" +
                            startPoint +
                            "'");
                    }
                    break;
            }
            #endregion Execute properties menu/action pane

        }

        /// <summary>
        /// Method to create a resource pool
        /// </summary>
        /// <param name="parameter">
        /// Contain pool name description and members
        /// </param>
        /// <returns>true or false</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if pool name or members parameters are null or empty string.
        /// </exception>
        public static bool CreateResourcePool(ResourcePoolParameter parameter)
        {
            Core.Common.Utilities.LogMessage(
                            "CreateResourcePool...");

            #region Validate Parameters
            if (String.IsNullOrEmpty(parameter.poolName))
            {
                throw new System.ArgumentNullException(
                    "CreateResourcePool::Pool name parameter cannot be null or empty string!");
            }

            if (parameter.poolMembers.Count == 0)
            {
                throw new System.ArgumentNullException(
                    "CreateResourcePool::Pool members number cannot be null or empty string!");
            }
            #endregion Validate Parameters

            #region General Properties dialog
            Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::General Properties dialog");
            GeneralProperties generalProertiesDialog = new GeneralProperties(CoreManager.MomConsole, true);
            
            generalProertiesDialog.NameTextBoxText = parameter.poolName;
            Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::Set pool name := " + generalProertiesDialog.NameTextBoxText);

            generalProertiesDialog.DescriptionTextboxText = parameter.poolDescription;
            Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::Set pool description := " + generalProertiesDialog.DescriptionTextboxText);

            Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::Click General Properties dialog Next button.");
            generalProertiesDialog.ClickNext();

            #endregion General Properties dialog

            #region Pool Membership dialog
            Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::Pool Membership dialog");
            PoolMembership poolMembershipDialog = new PoolMembership(CoreManager.MomConsole, true);

            Maui.Core.MauiCollection<IScreenElement> groupElements = poolMembershipDialog.Controls.PoolMembersList.ScreenElement.FindAllDescendants(-1, ";[FindAll, UIA, VisibleOnly]Role = 'list item'", null);

            if (groupElements.Count != 0)
            {
                Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::Pool Membership list is not empty when creat a new resource pool. the count := " + poolMembershipDialog.Controls.PoolMembersList.Rows.Count);

                return false;
            }

            Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::Click Add button.");
            poolMembershipDialog.SendKeys(Core.Common.KeyboardCodes.Alt + 'a');
            
            #region Member selection
            MemberSelectionDialog memberSelectionDialog = new MemberSelectionDialog(CoreManager.MomConsole, true);
            foreach (string member in parameter.poolMembers)
            {
                Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::Try to find member := " + member);
                memberSelectionDialog.SelectManagementServersOrGatewayServersForThisResourcePoolText = member;

                Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::Click search button.");
                memberSelectionDialog.ClickSearch();
                Sleeper.Delay(30000);
                
                Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::Click available item.");
                memberSelectionDialog.Controls.AvailableItems.Click();
                memberSelectionDialog.SendKeys(Core.Common.KeyboardCodes.Ctrl + Core.Common.KeyboardCodes.Shift + Core.Common.KeyboardCodes.Home);

                Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::Click Add button.");
                memberSelectionDialog.ClickAdd();

            }
            Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::Click OK button.");
            memberSelectionDialog.ClickOK();
            #endregion Member selection

            Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::Click Pool Membership dialog Next button.");
            poolMembershipDialog.ClickNext();

            #endregion Pool Membership dialog

            #region Summary dialog
            Summary summaryDialog = new Summary(CoreManager.MomConsole, true);            

            if (!summaryDialog.NameText.Contains(parameter.poolName))
            {
                Core.Common.Utilities.LogMessage("CreateResourcePool:: " + summaryDialog.NameText);
                Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::The pool Name is not match in summary.");
                return false;
            }
            
            if (!summaryDialog.DescriptionText.Contains(parameter.poolDescription))
            {
                Core.Common.Utilities.LogMessage("CreateResourcePool:: " + summaryDialog.DescriptionText);
                Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::The pool Description is not match in summary.");
                return false;
            }

            //the members verify on summary
            if (summaryDialog.Controls.Members.Rows.Count != parameter.poolMembers.Count)
            {
                Core.Common.Utilities.LogMessage("CreateResourcePool:: Members count ;= " + summaryDialog.Controls.Members.Rows.Count.ToString());
                Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::The pool members count is not match in summary.");
                return false;
            }
            bool find = false;
            foreach (string member in parameter.poolMembers)
            {
                foreach (DataGridRow row in summaryDialog.Controls.Members.Rows)
                {
                    Core.Common.Utilities.LogMessage(
                        "VerifyResourcePoolProperties::Try find pool member, one is := " + row.Cells[0].Value
                         + " another is := " + member);
                    if (row.Cells[0].Value == member)
                    {
                        find = true;
                    }
                }
                if (find == false)
                {
                    Core.Common.Utilities.LogMessage(
                                "CreateResourcePool::The pool member is not match in summary.");
                    return false;
                }
                find = false;
            }

            Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::Click Create button.");
            summaryDialog.ClickCreate();

            #endregion Summary dialog

            #region Completion dialog
            Completion completionDialog = new Completion(CoreManager.MomConsole, true);

            Core.Common.Utilities.LogMessage(
                            "CreateResourcePool::Click Close button.");
            WaitForButtonEnable(completionDialog.Controls.CloseButton, 60);
            completionDialog.ClickClose();
            #endregion Completion dialog
            return true;
        }

        /// <summary>
        /// Method to update a resource pool
        /// </summary>
        /// <param name="parameter">
        /// Contain pool name description and members
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if pool name or members parameters are null or empty string.
        /// </exception>
        public static bool UpdateResourcePool(ResourcePoolParameter parameter)
        {
            Core.Common.Utilities.LogMessage(
                            "UpdateResourcePool...");

            #region Validate Parameters
            if (String.IsNullOrEmpty(parameter.poolName))
            {
                throw new System.ArgumentNullException(
                    "UpdateResourcePool::Pool name parameter cannot be null or empty string!");
            }

            #endregion Validate Parameters

            #region General Properties dialog
            Core.Common.Utilities.LogMessage(
                            "UpdateResourcePool::General Properties dialog");
            GeneralProperties generalProertiesDialog = new GeneralProperties(CoreManager.MomConsole, false, parameter.poolName);

            generalProertiesDialog.NameTextBoxText = parameter.poolName;
            Core.Common.Utilities.LogMessage(
                            "UpdateResourcePool::Set pool name := " + generalProertiesDialog.NameTextBoxText);

            generalProertiesDialog.DescriptionTextboxText = parameter.poolDescription;
            Core.Common.Utilities.LogMessage(
                            "UpdateResourcePool::Set pool description := " + generalProertiesDialog.DescriptionTextboxText);

            Core.Common.Utilities.LogMessage(
                            "UpdateResourcePool::Click General Properties dialog Next button.");
            generalProertiesDialog.ClickNext();

            #endregion General Properties dialog

            #region Pool Membership dialog
            PoolMembership poolMembershipDialog = new PoolMembership(CoreManager.MomConsole, false, parameter.poolName);
            Core.Common.Utilities.LogMessage(
                            "UpdateResourcePool::Pool Membership dialog");

            if (parameter.poolMembers.Count != 0)
            {
                Maui.Core.MauiCollection<IScreenElement> groupElements = poolMembershipDialog.Controls.PoolMembersList.ScreenElement.FindAllDescendants(-1, ";[FindAll, UIA, VisibleOnly]Role = 'list item'", null);

                if (groupElements.Count == 0)
                {
                    Core.Common.Utilities.LogMessage(
                                "UpdateResourcePool::Pool Membership list is empty when open a resource pool roerties, throw exception.");

                    return false;
                }

                for (int i = groupElements.Count; i > 0; i--)
                {
                    poolMembershipDialog.Controls.PoolMembersList.Click();

                    poolMembershipDialog.SendKeys(Core.Common.KeyboardCodes.Ctrl + Core.Common.KeyboardCodes.Shift + Core.Common.KeyboardCodes.Home);

                    poolMembershipDialog.SendKeys(Core.Common.KeyboardCodes.Alt + 'r');

                    Sleeper.Delay(1000);
                }

                Core.Common.Utilities.LogMessage(
                            "UpdateResourcePool::Click Add button.");
                poolMembershipDialog.SendKeys(Core.Common.KeyboardCodes.Alt + 'a');

                #region Member selection
                MemberSelectionDialog memberSelectionDialog = new MemberSelectionDialog(CoreManager.MomConsole, false, parameter.poolName);
                foreach (string member in parameter.poolMembers)
                {
                    Core.Common.Utilities.LogMessage(
                                "UpdateResourcePool::Try to find member := " + member);
                    memberSelectionDialog.SelectManagementServersOrGatewayServersForThisResourcePoolText = member;

                    Core.Common.Utilities.LogMessage(
                                "UpdateResourcePool::Click search button.");
                    memberSelectionDialog.ClickSearch();
                    Sleeper.Delay(5000);

                    Core.Common.Utilities.LogMessage(
                                "UpdateResourcePool::Click available item.");
                    memberSelectionDialog.Controls.AvailableItems.Click();
                    memberSelectionDialog.SendKeys(Core.Common.KeyboardCodes.Ctrl + Core.Common.KeyboardCodes.Shift + Core.Common.KeyboardCodes.Home);


                    Core.Common.Utilities.LogMessage(
                                "UpdateResourcePool::Click Add button.");
                    memberSelectionDialog.ClickAdd();

                }
                Core.Common.Utilities.LogMessage(
                                "UpdateResourcePool::Click OK button.");
                memberSelectionDialog.ClickOK();
                #endregion Member selection

                Core.Common.Utilities.LogMessage(
                                "UpdateResourcePool::Click Pool Membership dialog Next button.");
                poolMembershipDialog.ClickNext();
            }

            #endregion Pool Membership dialog

            #region Summary dialog
            Summary summaryDialog = new Summary(CoreManager.MomConsole, false, parameter.poolName);

            if (!summaryDialog.NameText.Contains(parameter.poolName))
            {
                Core.Common.Utilities.LogMessage("CreateResourcePool:: " + summaryDialog.NameText);
                Core.Common.Utilities.LogMessage(
                            "UpdateResourcePool::The pool Name is not match in summary.");
                return false;
            }
            if (!summaryDialog.DescriptionText.Contains(parameter.poolDescription))
            {
                Core.Common.Utilities.LogMessage("CreateResourcePool:: " + summaryDialog.DescriptionText);
                Core.Common.Utilities.LogMessage(
                            "UpdateResourcePool::The pool Description is not match in summary.");
                return false;
            }
            if (summaryDialog.Controls.Members.Rows.Count != parameter.poolMembers.Count)
            {
                Core.Common.Utilities.LogMessage("CreateResourcePool:: Members count ;= " + summaryDialog.Controls.Members.Rows.Count.ToString());
                Core.Common.Utilities.LogMessage(
                            "UpdateResourcePool::The pool members count is not match in summary.");
                return false;
            }
            bool find = false;
            foreach (string member in parameter.poolMembers)
            {
                foreach (DataGridRow row in summaryDialog.Controls.Members.Rows)
                {
                    Core.Common.Utilities.LogMessage(
                        "UpdateResourcePool::Try find pool member, one is := " + row.Cells[0].Value
                         + " another is := " + member);
                    if (row.Cells[0].Value == member)
                    {
                        find = true;
                    }
                }
                if (find == false)
                {
                    Core.Common.Utilities.LogMessage(
                                "UpdateResourcePool::The pool member is not match in summary.");
                    return false;
                }
                find = false;
            }
            Core.Common.Utilities.LogMessage(
                            "UpdateResourcePool::Click Save button.");
            summaryDialog.ClickCreate();

            #endregion Summary dialog

            #region Completion dialog
            Completion completionDialog = new Completion(CoreManager.MomConsole, false, parameter.poolName);

            Core.Common.Utilities.LogMessage(
                            "UpdateResourcePool::Click Close button.");

            WaitForButtonEnable(completionDialog.Controls.CloseButton, 60);

            completionDialog.ClickClose();
            #endregion Completion dialog

            return true;
        }

        /// <summary>
        /// Method to verify a resource pool created/updated
        /// </summary>
        /// /// <param name="parameter">
        /// Contain pool name description and members
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if pool name or members parameters are null or empty string.
        /// </exception>
        public static bool VerifyResourcePoolProperties(ResourcePoolParameter parameter)
        {
            Core.Common.Utilities.LogMessage(
                           "VerifyResourcePoolProperties...");

            #region Validate Parameters
            if (String.IsNullOrEmpty(parameter.poolName))
            {
                throw new System.ArgumentNullException(
                    "VerifyResourcePoolProperties::Pool name parameter cannot be null or empty string!");
            }

            #endregion Validate Parameters

            #region General Properties dialog
            Core.Common.Utilities.LogMessage(
                            "VerifyResourcePoolProperties::General Properties dialog");
            GeneralProperties generalProertiesDialog = new GeneralProperties(CoreManager.MomConsole, false, parameter.poolName);

            if (generalProertiesDialog.NameTextBoxText != parameter.poolName)
            {
                Core.Common.Utilities.LogMessage(
                            "VerifyResourcePoolProperties::pool name mismatch, one is := " + generalProertiesDialog.NameTextBoxText
                            + "another is := " + parameter.poolName);
                return false;
            }

            if (generalProertiesDialog.DescriptionTextboxText != parameter.poolDescription)
            {
                Core.Common.Utilities.LogMessage(
                            "VerifyResourcePoolProperties::pool description mismatch, one is := " + generalProertiesDialog.DescriptionTextboxText
                            + "another is := " + parameter.poolDescription);
                return false;
            }

            Core.Common.Utilities.LogMessage(
                            "VerifyResourcePoolProperties::General Properties dialog verify pass.");

            Core.Common.Utilities.LogMessage(
                            "VerifyResourcePoolProperties::Click General Properties dialog Next button.");
            generalProertiesDialog.ClickNext();

            #endregion General Properties dialog

            #region Pool Membership dialog
            PoolMembership poolMembershipDialog = new PoolMembership(CoreManager.MomConsole, false, parameter.poolName);
            Core.Common.Utilities.LogMessage(
                            "VerifyResourcePoolProperties::Pool Membership dialog");

            Maui.Core.MauiCollection<IScreenElement> groupElements = poolMembershipDialog.Controls.PoolMembersList.ScreenElement.FindAllDescendants(-1, ";[FindAll, UIA, VisibleOnly]Role = 'list item'", null);            
            
            if (groupElements.Count != parameter.poolMembers.Count)
            {
                Core.Common.Utilities.LogMessage(
                    "VerifyResourcePoolProperties::Pool members number mismatch, one is := " + (groupElements.Count).ToString() 
                            + " another is := " + parameter.poolMembers.Count.ToString());
                return false;
            }

            //
            //Verify membership list
            //
            bool find = false;
            foreach (var item in groupElements)
            {
                foreach (string member in parameter.poolMembers)
                {
                    Core.Common.Utilities.LogMessage(
                        "VerifyResourcePoolProperties::Try find pool member, one is := " + item.Name
                         + " another is := " + member);                    
                    if (item.Name.ToLowerInvariant() == member.ToLowerInvariant())
                    {
                        find = true;
                    }
                }

                if (find == false)
                {
                    Core.Common.Utilities.LogMessage(
                    "VerifyResourcePoolProperties::Pool members mismatch.");
                    return false;
                }

                find = false;
            }
            
            Core.Common.Utilities.LogMessage(
                                "VerifyResourcePoolProperties::Click Pool Membership dialog Next button.");
            poolMembershipDialog.ClickNext();
            #endregion Pool Membership dialog

            #region Summary dialog
            Summary summaryDialog = new Summary(CoreManager.MomConsole, false, parameter.poolName);
            if (!summaryDialog.NameText.Contains(parameter.poolName))
            {
                Core.Common.Utilities.LogMessage("VerifyResourcePoolProperties:: " + summaryDialog.NameText);
                Core.Common.Utilities.LogMessage(
                            "VerifyResourcePoolProperties::The pool Name is not match in summary.");
                return false;
            }
            if (!summaryDialog.DescriptionText.Contains(parameter.poolDescription))
            {
                Core.Common.Utilities.LogMessage("CreateResourcePool:: " + summaryDialog.DescriptionText);
                Core.Common.Utilities.LogMessage(
                            "VerifyResourcePoolProperties::The pool Description is not match in summary.");
                return false;
            }
            if (summaryDialog.Controls.Members.Rows.Count != parameter.poolMembers.Count)
            {
                Core.Common.Utilities.LogMessage("VerifyResourcePoolProperties:: Members count ;= " + summaryDialog.Controls.Members.Rows.Count.ToString());
                Core.Common.Utilities.LogMessage(
                            "VerifyResourcePoolProperties::The pool members count is not match in summary.");
                return false;
            }
            find = false;
            foreach (string member in parameter.poolMembers)
            {
                foreach (DataGridRow row in summaryDialog.Controls.Members.Rows)
                {
                    Core.Common.Utilities.LogMessage(
                        "VerifyResourcePoolProperties::Try find pool member, one is := " + row.Cells[0].Value
                         + " another is := " + member);
                    if (row.Cells[0].Value == member)
                    {
                        find = true;
                    }
                }
                if (find == false)
                {
                    Core.Common.Utilities.LogMessage(
                                "VerifyResourcePoolProperties::The pool member is not match in summary.");
                    return false;
                }
                find = false;
            }
            Core.Common.Utilities.LogMessage(
                               "VerifyResourcePoolProperties::Click Summary dialog Cancel button.");
            summaryDialog.ClickCancel();

            CoreManager.MomConsole.ConfirmChoiceDialog(true);                

            #endregion Summary dialog

            return true;
        }

        /// <summary>
        /// Method to delete a resource pool
        /// </summary>
        /// <param name="poolName">
        /// Pool name
        /// </param>
        /// <param name="deleteMethod">
        /// Delete Method
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if pool name or members parameters are null or empty string.
        /// </exception>
        public static void DeleteResourcePool(string poolName, string deleteMethod)
        {
            Core.Common.Utilities.LogMessage(
                           "DeleteResourcePool...");

            #region Validate Parameters

            if (String.IsNullOrEmpty(poolName))
            {
                throw new System.ArgumentNullException(
                    "Pool name parameter cannot be null or empty string!");
            }

            if (String.IsNullOrEmpty(deleteMethod))
            {
                throw new System.ArgumentNullException(
                    "Delete pool method parameter cannot be null or empty string!");
            }

            #endregion Validate Parameters

            #region Select Pool

            Maui.Core.WinControls.DataGridViewRow poolRow = null;
            poolRow = FindPoolRow(poolName);

            // check for valid row
            if (null == poolRow)
            {
                throw new System.ArgumentException(
                    "Failed to find the pool in the view with name := '" +
                    poolName +
                    "'");
            }

            Core.Common.Utilities.LogMessage(
                "DeleteResourcePool::Clicking the row...");

            // select the channel row
            poolRow.AccessibleObject.Click();

            Core.Common.Utilities.LogMessage(
                "DeleteResourcePool::Waiting for the tooltip to disappear...");

            // wait for the tooltip to disappear
            Maui.Core.Utilities.Sleeper.Delay(
                Core.Common.Constants.DefaultContextMenuTimeout);

            #endregion Select Channel

            #region Choose Delete Method

            Core.Common.Utilities.LogMessage(
                "DeleteResourcePool::Using deletion method := '" +
                deleteMethod +
                "'");

            switch (deleteMethod)
            {
                case Constants.DeleteMethod.ViewContextMenu:
                    {
                        #region Right-Click Item, Select Delete Context Menu

                        // put focus back on the row in case tooltip appeared
                        poolRow.AccessibleObject.Click();

                        Core.Common.Utilities.LogMessage(
                            "DeleteResourcePool::Using right-click, context menu...");

                        // right-click item, properties menu
                        poolRow.AccessibleObject.Click(
                            MouseFlags.RightButton);

                        Core.Common.Utilities.LogMessage(
                            "DeleteResourcePool::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "DeleteResourcePool::Selecting context menu '" +
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete +
                            "'");

                        // select the 'Delete' menu
                        contextMenu.ExecuteMenuItem(
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                        #endregion Right-Click Item, Select Delete Context Menu
                    }

                    break;
                case Constants.DeleteMethod.ActionsPaneLinkMenu:
                    {
                        #region Actions Pane Properties Link

                        // remove accelerator keys from the resource string
                        string actionsPaneLinkText =
                            Core.Common.Utilities.RemoveAcceleratorKeys(
                                Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                        Core.Common.Utilities.LogMessage(
                            "DeleteResourcePool::Using link text := '" +
                            actionsPaneLinkText +
                            "'");

                        ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
                        taskPane.ClickLink(
                            Core.Console.ActionsPane.Strings.ActionsPaneAdminViews,
                            actionsPaneLinkText);

                        Core.Common.Utilities.LogMessage(
                            "DeleteResourcePool::Clicking actions pane link...");

                        #endregion Actions Pane Properties Link
                    }

                    break;
                case Constants.DeleteMethod.ViewShiftF10MenuHotKey:
                    {
                        #region Left-Click Item, SHIFT-F10, Select Delete Context Menu

                        Core.Common.Utilities.LogMessage(
                            "DeleteResourcePool::Using left-click, SHIFT-F10...");

                        // delay to prevent a previous click from becoming a double-click
                        Maui.Core.Utilities.Sleeper.Delay(
                            Core.Common.Constants.OneSecond);

                        // right-click item, properties menu
                        poolRow.AccessibleObject.Click(
                            MouseFlags.LeftButton);

                        // display context menu using keyboard
                        poolRow.AccessibleObject.Window.SendKeys(
                            Core.Common.KeyboardCodes.ShiftF10);

                        Core.Common.Utilities.LogMessage(
                            "DeleteResourcePool::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "DeleteResourcePool::Selecting context menu '" +
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete +
                            "'");

                        // select the 'Properties' menu
                        contextMenu.ExecuteMenuItem(
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                        #endregion Left-Click Item, SHIFT-F10, Select Delete Context Menu
                    }

                    break;
                case Constants.DeleteMethod.ViewDeleteKey:
                    {
                        #region Left-Click Item, Press DELETE Key

                        // select item, press ENTER key
                        Core.Common.Utilities.LogMessage(
                            "DeleteResourcePool::Using left-click, DELETE...");

                        // delay to prevent a previous click from becoming a double-click
                        Maui.Core.Utilities.Sleeper.Delay(
                            Core.Common.Constants.OneSecond);

                        // right-click item, properties menu
                        poolRow.AccessibleObject.Click(
                            MouseFlags.LeftButton);

                        // display context menu using keyboard
                        poolRow.AccessibleObject.Window.SendKeys(
                            Core.Common.KeyboardCodes.Delete);

                        #endregion Left-Click Item, Press DELETE Key
                    }

                    break;
                default:
                    {
                        #region Right-Click Item, Select Delete Context Menu

                        // put focus back on the row in case tooltip appeared
                        poolRow.AccessibleObject.Click();

                        Core.Common.Utilities.LogMessage(
                            "DeleteResourcePool::Using right-click, context menu...");

                        // right-click item, properties menu
                        poolRow.AccessibleObject.Click(
                            MouseFlags.RightButton);

                        Core.Common.Utilities.LogMessage(
                            "DeleteResourcePool::Looking for context menu...");

                        // get the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "DeleteResourcePool::Selecting context menu '" +
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete +
                            "'");

                        // select the 'Properties' menu
                        contextMenu.ExecuteMenuItem(
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                        #endregion Right-Click Item, Select Delete Context Menu
                    }

                    break;
            }

            #endregion

            #region Confirm Deletion

            Core.Common.Utilities.LogMessage(
                "DeleteResourcePool::Confirm deletion");

            // confirm the delete
            CoreManager.MomConsole.ConfirmChoiceDialog(
                true,
                Strings.ConfirmPoolDeleteDialogTitle);

            // wait for the UI to settle
            CoreManager.MomConsole.Waiters.WaitForStatusReady(
                Core.Common.Constants.DefaultDialogTimeout);

            #endregion
        }

        /// <summary>
        /// Method to verify a resource pool deleted
        /// </summary>
        /// <param name="poolName">
        /// Pool name
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if pool name or members parameters are null or empty string.
        /// </exception>
        public static bool VerifyResourcePoolDeleted(string poolName)
        {
            Core.Common.Utilities.LogMessage(
                           "VerifyResourcePoolDeleted...");

            #region Validate Parameters

            if (String.IsNullOrEmpty(poolName))
            {
                throw new System.ArgumentNullException(
                    "Pool name parameter cannot be null or empty string!");
            }

            #endregion Validate Parameters

            #region Check Pool if exist

            Maui.Core.WinControls.DataGridViewRow poolRow = null;

            poolRow = FindPoolRow(poolName);

            // check for valid row
            if (null == poolRow)
            {
                Core.Common.Utilities.LogMessage(
                    "VerifyResourcePoolDeleted::The Pool '" +
                    poolName +
                    "' is not exist.");
                return true;
            }

            Core.Common.Utilities.LogMessage(
                    "VerifyResourcePoolDeleted::The Pool '" +
                    poolName +
                    "' is exist.");
            return false;

            #endregion Check Channel if exist
        }

        /// <summary>
        /// Method to verify a resource pool in view
        /// </summary>
        /// <param name="poolName">
        /// Pool name
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if pool name or members parameters are null or empty string.
        /// </exception>
        public static bool VerifyResourcePoolInView(string poolName)
        {
            Core.Common.Utilities.LogMessage(
                                      "VerifyResourcePoolInView...");

            #region Validate Parameters

            if (String.IsNullOrEmpty(poolName))
            {
                throw new System.ArgumentNullException(
                    "Pool name parameter cannot be null or empty string!");
            }

            #endregion Validate Parameters

            Maui.Core.WinControls.DataGridViewRow poolRow = null;
            poolRow = FindPoolRow(poolName);

            // check for valid row
            if (null == poolRow)
            {
                Core.Common.Utilities.LogMessage(
                    "VerifyResourcePoolInView::The Pool '" +
                    poolName +
                    "' is not exist.");
                return false;
            }

            int columnPos = CoreManager.MomConsole.ViewPane.Grid.GetColumnTitlePosition(Views.Views.Strings.StateNameColumnHeader);
            if (poolRow.Cells[columnPos].GetValue() != poolName)
            {
                Core.Common.Utilities.LogMessage(
                                   "VerifyResourcePoolInView::The Pool name in view is mismatch");
                return false;
            }

            columnPos = CoreManager.MomConsole.ViewPane.Grid.GetColumnTitlePosition(Views.Alerts.AlertsView.Strings.SourceColumnTitle);
            if (poolRow.Cells[columnPos].GetValue() != Strings.PoolsViewColumnValueAdministrator)
            {
                Core.Common.Utilities.LogMessage(
                                   "VerifyResourcePoolInView::The Pool source in view is mismatch");
                return false;
            }

            columnPos = CoreManager.MomConsole.ViewPane.Grid.GetColumnTitlePosition(Strings.MembershipColumnHeader);
            if (poolRow.Cells[columnPos].GetValue() != Strings.PoolsViewColumnValueManual)
            {
                Core.Common.Utilities.LogMessage(
                                   "VerifyResourcePoolInView::The Pool membership in view is mismatch");
                return false;
            }

            return true;
        }

        
        /// <summary>
        /// Method to verify resource pool members in new windows
        /// </summary>
        /// <param name="parameter">
        /// ResourcePoolParameter
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if pool name or members parameters are null or empty string.
        /// </exception>
        public static bool VerifyResourcePoolMembersInView(ResourcePoolParameter parameter)
        {
            Core.Common.Utilities.LogMessage(
                                      "VerifyResourcePoolMembersInView...");

            #region Validate Parameters

            if (String.IsNullOrEmpty(parameter.poolName))
            {
                throw new System.ArgumentNullException(
                    "Pool name parameter cannot be null or empty string!");
            }

            #endregion Validate Parameters

            Maui.Core.WinControls.DataGridViewRow poolRow = null;
            poolRow = FindPoolRow(parameter.poolName);

            // check for valid row
            if (null == poolRow)
            {
                Core.Common.Utilities.LogMessage(
                    "VerifyResourcePoolMembersInView::The Pool '" +
                    parameter.poolName +
                    "' is not exist.");
                return false;
            }

            #region Click view resource pool member 

            // put focus back on the row in case tooltip appeared
            poolRow.AccessibleObject.Click();

            Core.Common.Utilities.LogMessage(
                "VerifyResourcePoolMembersInView::Using right-click, context menu...");

            // right-click item, properties menu
            poolRow.AccessibleObject.Click(
                MouseFlags.RightButton);

            Core.Common.Utilities.LogMessage(
                "VerifyResourcePoolMembersInView::Looking for context menu...");

            // get the context menu
            Maui.Core.WinControls.Menu contextMenu =
                new Maui.Core.WinControls.Menu(
                    Core.Common.Constants.DefaultContextMenuTimeout);

            Core.Common.Utilities.LogMessage(
                "VerifyResourcePoolMembersInView::Selecting context menu '" +
                Strings.ViewResourcePoolMembersContextMenu +
                "'");

            // select the "View Resource Pool Members..." menu
            contextMenu.ExecuteMenuItem(
                Strings.ViewResourcePoolMembersContextMenu);

            // waiting view loading
            Sleeper.Delay(Core.Common.Constants.DefaultViewLoadTimeout);

            #endregion

            #region Verify pool member in object view

            Window managedObjects = new Window(new QID(";[UIA]AutomationId=\'ConsoleWindow\'"), 5000);

            DataGrid grid = new DataGrid(managedObjects, new QID(";[UIA]AutomationId=\'momGrid\'"));

            if (grid.Rows.Count != parameter.poolMembers.Count)
            {
                Core.Common.Utilities.LogMessage(
                       "VerifyResourcePoolMembersInView::The Pool members' count in object view is mismatch, the one is " + grid.Rows.Count +
                       "another is " + parameter.poolMembers.Count);
                return false;
            }

            bool find = false;
            foreach (string member in parameter.poolMembers)
            {
                foreach (DataGridRow row in grid.Rows)
                {
                    Core.Common.Utilities.LogMessage(
                        "VerifyResourcePoolProperties::Try find pool member in objects view, one is := " + row.Cells[0].Value
                         + " another is := " + member);
                    if (row.Cells[0].Value == member)
                    {
                        find = true;
                    }
                }
                if (find == false)
                {
                    Core.Common.Utilities.LogMessage(
                                "VerifyResourcePoolProperties::The pool member is not match in objects view.");
                    managedObjects.ClickTitleBarClose();
                    return false;
                }
                find = false;
            }

            managedObjects.ClickTitleBarClose();
            #endregion

            return true;
        }

        /// <summary>
        /// Method to verify default all management servers resource pool
        /// </summary>
        public static bool VerifyAllManagementServersResourcePool()
        {
            Core.Common.Utilities.LogMessage(
                                      "VerifyAllManagementServersResourcePool...");

            string allManagementServersPool = Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDSystemCenterLibraryMP, ManagementPackConstants.AllManagementServersPool);
            Maui.Core.WinControls.DataGridViewRow poolRow = null;
            poolRow = FindPoolRow(allManagementServersPool);

            // check for valid row
            if (null == poolRow)
            {
                Core.Common.Utilities.LogMessage(
                    "VerifyResourcePoolMembersInView::The Pool '" +
                    allManagementServersPool +
                    "' is not exist.");
                return false;
            }

            LaunchProperties(allManagementServersPool, Constants.StartPoint.ViewContextMenu);

            try
            {
                GeneralProperties generalProertiesDialog = new GeneralProperties(CoreManager.MomConsole, false, allManagementServersPool);

                Core.Common.Utilities.LogMessage(
                    "VerifyResourcePoolMembersInView::The Pool '" +
                    allManagementServersPool +
                    "' is not readonly.");

                generalProertiesDialog.ClickCancel();
                CoreManager.MomConsole.ConfirmChoiceDialog(true);
            }
            catch (Maui.Core.Dialog.Exceptions.WindowNotFoundException)
            {
                Core.Common.Utilities.LogMessage(
                    "VerifyResourcePoolMembersInView::The Pool '" +
                    allManagementServersPool +
                    "' is readonly.");

                return true;            	
            }             

            return false;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Method to navigate to the specified view in the Administration 
        /// space.
        /// </summary>
        /// <param name="viewName">
        /// The name of the view to search for and select.
        /// </param>
        /// <returns>
        /// A reference to the specified view tree node.
        /// </returns>
        /// <exception cref="Maui.Core.WinControls.TreeView.Exceptions.NodeNotFoundException">
        /// Throws 
        /// Maui.Core.WinControls.TreeView.Exceptions.NodeNotFoundException if
        /// the code fails to find and select the specified view.
        /// </exception>
        private static Maui.Core.WinControls.TreeNode NavigateToView(
            string viewName)
        {
            Core.Common.Utilities.LogMessage(
                "NavigateToView::Looking for tree view node := '" +
                viewName +
                "'");
            // navigate to the specified view
            Maui.Core.WinControls.TreeNode specifiedViewNode = null;

            try
            {
                // navigate to the specified view
                specifiedViewNode =
                    CoreManager.MomConsole.NavigationPane.SelectNode(
                        viewName,
                        NavigationPane.NavigationTreeView.Administration);
                CoreManager.MomConsole.Waiters.WaitForStatusReady(
                    Core.Common.Constants.DefaultDialogTimeout);
            }
            catch (Maui.Core.WinControls.TreeNode.Exceptions.InvalidItemHandleException)
            {
                Core.Common.Utilities.LogMessage(
                    "NavigateToView:: Got InvalidItemHandleException; " +
                    " re-trying SelectNode...");

                // navigate to the specified view
                specifiedViewNode =
                    CoreManager.MomConsole.NavigationPane.SelectNode(
                        viewName,
                        NavigationPane.NavigationTreeView.Administration);
                CoreManager.MomConsole.Waiters.WaitForStatusReady(
                    Core.Common.Constants.DefaultDialogTimeout);

            }

            Core.Common.Utilities.LogMessage(
                "NavigateToView::Checking that current node is requested node...");
            Core.Common.Utilities.LogMessage(
                "NavigateToView::Current node := '" +
                specifiedViewNode.Text +
                "'");
            Core.Common.Utilities.LogMessage(
                "NavigateToView::Requested node := '" +
                viewName +
                "'");

            // check that the requested view is really the current view
            if (specifiedViewNode != null &&
                specifiedViewNode.Text.Equals(viewName) == false)
            {
                Core.Common.Utilities.LogMessage(
                    "NavigateToView::2nd chance, looking for tree view node := '" +
                    viewName +
                    "'");

                // try to navigate again
                specifiedViewNode =
                    CoreManager.MomConsole.NavigationPane.SelectNode(
                        viewName,
                        NavigationPane.NavigationTreeView.Administration);
                CoreManager.MomConsole.Waiters.WaitForStatusReady(
                    Core.Common.Constants.DefaultDialogTimeout);

                Core.Common.Utilities.LogMessage(
                    "NavigateToView::Checking that current node is requested node...");
                Core.Common.Utilities.LogMessage(
                    "NavigateToView::Current node := '" +
                    specifiedViewNode.Text +
                    "'");

                // check again
                if (specifiedViewNode != null &&
                specifiedViewNode.Text.Equals(viewName) == false)
                {
                    throw new Maui.Core.WinControls.TreeView.Exceptions.NodeNotFoundException(
                        "Failed to select the '" +
                        viewName +
                        "' tree view node!");
                }
            }

            return specifiedViewNode;
        }

        /// <summary>
        /// Method to navigate to the specified row in the pool view 
        /// space.
        /// </summary>
        /// <param name="poolName">
        /// The name of the pool to search for and select.
        /// </param>
        /// <returns>
        /// A reference to the specified view tree node.
        /// </returns>
        private static Maui.Core.WinControls.DataGridViewRow FindPoolRow(string poolName)
        {
            NavigateToView(
                NavigationPane.Strings.AdminTreeViewResourcePoolsView);

            int maxRetry = 5;
            Maui.Core.WinControls.DataGridViewRow poolRow = null;
            int loopNumber = 0;
            while (null == poolRow && loopNumber++ < maxRetry)
            {
                // refresh the view
                CoreManager.MomConsole.ViewPane.Grid.Click();
                CoreManager.MomConsole.ViewPane.Grid.SendKeys(
                    Core.Common.KeyboardCodes.F5);

                // wait for the UI to settle
                CoreManager.MomConsole.Waiters.WaitForStatusReady(
                    Core.Common.Constants.DefaultDialogTimeout);

                Core.Common.Utilities.LogMessage(
                    "FindPoolRow::Selecting channel row with name := '" +
                    poolName +
                    "'" +
                    " Retry times := " +
                    loopNumber);

                // select the channel in the grid view
                poolRow = CoreManager.MomConsole.ViewPane.Grid.FindData(
                    poolName, MomControls.GridControl.SearchStringMatchType.ExactMatch);

                Maui.Core.Utilities.Sleeper.Delay(
                        Core.Common.Constants.OneSecond);
            }

            return poolRow;
        }

        /// <summary>
        /// Method to wait for some button enable 
        /// space.
        private static void WaitForButtonEnable(Maui.Core.WinControls.Button button, int timeoutSeconds)
        {
            int loop = 0;
            //button.IsEnabled is always true, so just sleep 30 sec to work around
            Sleeper.Delay(30000);
            while (button.IsEnabled != true && loop++ < timeoutSeconds)
            {                
                Sleeper.Delay(Core.Common.Constants.OneSecond);                
            }
        }
                
        #endregion

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for User Role
        /// </summary>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants
            /// <summary>
            /// Contains Resource string for: "Create New Resource Pool..."
            /// </summary>            
            private const string ResourceCreateNewResourcePoolContextMenu =		                        
                 ";&Create Resource Pool...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Pools_Wizard_Action_MenuItemText";

            /// <summary>
            /// Contains Resource string for: "Properties"
            /// </summary>            
            private const string ResourcePropertiesContextMenu = 
		        ";Propertie&s;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPInstall.RulesDialog;propertiesButton.Text";

            /// <summary>
            /// Contains Resource string for: "View Resource Pool Members..."
            /// </summary>            
            private const string ResourceViewResourcePoolMembersContextMenu =
		        ";&View Resource Pool Members...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Pools_View_Actions_ViewPoolResources_MenuItemText";

            /// <summary>
            /// Contains Resource string for: "Delete"
            /// </summary>            
            private const string ResourceDeleteContextMenu =
                ";&Delete;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.ProfileAccounts;toolStripButtonDelete.Text";

            /// <summary>
            /// Contains Resource string for: "Delete Resource Pool"
            /// </summary>            
            private const string ResourceConfirmPoolDeleteDialogTitle =
                ";Delete Resource Pool;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Pools_View_Message_ConfirmDelete_Title";

            /// <summary>
            /// Contains Resource string for: "Membership"
            /// </summary>
            private const string ResourceMembershipColumnHeader =
                ";Membership;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Pools_View_Column_Header_Membership";

            /// <summary>
            /// Contains Resource string for: "Administrator"
            /// </summary>
            private const string ResourcePoolsViewColumnValueAdministrator =
                ";Administrator;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Pools_View_Column_Value_CreatedBy_Admin";

            /// <summary>
            /// Contains Resource string for: "Manual"
            /// </summary>
            private const string ResourcePoolsViewColumnValueManual =
                ";Manual;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Pools_View_Column_Value_Membership_Manual";

            #endregion

            #region Private Members            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Create New Resource Pool..."
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreateNewResourcePoolContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Properties"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPropertiesContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "View Resource Pool Members..."
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewResourcePoolMembersContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Delete"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDeleteContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Delete Resouce Pool"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfirmPoolDeleteDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Membership"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMembershipColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Administrator"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPoolsViewColumnValueAdministrator;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Manual"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPoolsViewColumnValueManual;


            #endregion

            #region Properties  
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to "Create New Resource Pool..."
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string CreateNewResourcePoolContextMenu
            {
                get
                {
                    if ((cachedCreateNewResourcePoolContextMenu == null))
                    {
                        cachedCreateNewResourcePoolContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceCreateNewResourcePoolContextMenu);
                    }

                    return cachedCreateNewResourcePoolContextMenu;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to "Properties"
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string PropertiesContextMenu
            {
                get
                {
                    if ((cachedPropertiesContextMenu == null))
                    {
                        cachedPropertiesContextMenu = CoreManager.MomConsole.GetIntlStr(ResourcePropertiesContextMenu);
                    }

                    return cachedPropertiesContextMenu;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to "View Resource Pool Members..."
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string ViewResourcePoolMembersContextMenu
            {
                get
                {
                    if ((cachedViewResourcePoolMembersContextMenu == null))
                    {
                        cachedViewResourcePoolMembersContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceViewResourcePoolMembersContextMenu);
                    }

                    return cachedViewResourcePoolMembersContextMenu;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to "Delete"
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string DeleteContextMenu
            {
                get
                {
                    if ((cachedDeleteContextMenu == null))
                    {
                        cachedDeleteContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceDeleteContextMenu);
                    }

                    return cachedDeleteContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to "Delete Confirm"
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string ConfirmPoolDeleteDialogTitle
            {
                get
                {
                    if ((cachedConfirmPoolDeleteDialogTitle == null))
                    {
                        cachedConfirmPoolDeleteDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceConfirmPoolDeleteDialogTitle);
                    }

                    return cachedConfirmPoolDeleteDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to "Membership"
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string MembershipColumnHeader
            {
                get
                {
                    if ((cachedMembershipColumnHeader == null))
                    {
                        cachedMembershipColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceMembershipColumnHeader);
                    }

                    return cachedMembershipColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to "Administrator"
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string PoolsViewColumnValueAdministrator
            {
                get
                {
                    if ((cachedPoolsViewColumnValueAdministrator == null))
                    {
                        cachedPoolsViewColumnValueAdministrator = CoreManager.MomConsole.GetIntlStr(ResourcePoolsViewColumnValueAdministrator);
                    }

                    return cachedPoolsViewColumnValueAdministrator;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to "Manual"
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string PoolsViewColumnValueManual
            {
                get
                {
                    if ((cachedPoolsViewColumnValueManual == null))
                    {
                        cachedPoolsViewColumnValueManual = CoreManager.MomConsole.GetIntlStr(ResourcePoolsViewColumnValueManual);
                    }

                    return cachedPoolsViewColumnValueManual;
                }
            }
                        
            #endregion
        }
        #endregion

        #region Constants Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constants class
        /// </summary>
        /// -----------------------------------------------------------------------------
        public sealed class Constants
        {
            /// <summary>
            /// Class to contain constant values for var-map record StartPoint.
            /// </summary>
            public sealed class StartPoint
            {
                /// <summary>
                /// Constant for the value ViewContextMenu
                /// </summary>
                public const string ViewContextMenu = "ViewContextMenu";

                /// <summary>
                /// Constant for the value ActionsPaneLinkMenu
                /// </summary>
                public const string ActionsPaneLinkMenu = "ActionsPaneLinkMenu";

                /// <summary>
                /// Constant for the value ActionsPaneLinkMenu
                /// </summary>
                public const string ViewShiftF10MenuHotKey = "ViewShiftF10MenuHotKey";
            }

            /// <summary>
            /// Class to contain constant values for var-map record StartPoint.
            /// </summary>
            public sealed class DeleteMethod
            {
                /// <summary>
                /// Constant for the value ViewContextMenu
                /// </summary>
                public const string ViewContextMenu = "ViewContextMenu";

                /// <summary>
                /// Constant for the value ActionsPaneLinkMenu
                /// </summary>
                public const string ActionsPaneLinkMenu = "ActionsPaneLinkMenu";

                /// <summary>
                /// Constant for the value ActionsPaneLinkMenu
                /// </summary>
                public const string ViewShiftF10MenuHotKey = "ViewShiftF10MenuHotKey";

                /// <summary>
                /// Constant for the value ViewDeleteKey
                /// </summary>
                public const string ViewDeleteKey = "ViewDeleteKey";
                
            }
        }
        #endregion
    } //end of class ResourcePool

    /// <summary>
    /// Class to add general methods for ResourcePoolParameter 
    /// </summary>
    public class ResourcePoolParameter
    {
        /// <summary>
        /// pool Name
        /// </summary>
        public string poolName;

        /// <summary>
        /// pool Description
        /// </summary>
        public string poolDescription;

        /// <summary>
        /// pool Members
        /// </summary>
        public List<string> poolMembers = new List<string>();
    }

}//end of namespace