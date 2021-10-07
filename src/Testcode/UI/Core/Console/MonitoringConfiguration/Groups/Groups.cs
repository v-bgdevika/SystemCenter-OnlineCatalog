// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Groups.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	Groups Base Class.
// </summary>
// <history>
// 	[HainingW] 09-Mar-06   Created
// 	[HainingW] 26-Mar-06   Implemented a test variation which creates, verifies and deletes a Group
//  [faizalk]  27-MAR-06   Change TaskPane to ActionsPane
// 	[HainingW] 31-Mar-06   Moved the Object Picker Dialog out to Console\Dialogs directory
// 	[HainingW] 07-Apr-06   More automation implementation
//  [barryli]  26-Feb-07   Removed hardcoded english name with sdk calls to pass localization 
//  [v-cheli]  10-Dec-08   Add more automation implementation
// </history>
// ---------------------------------------------------------------------------
#region Using directives

using Maui.Core;
using Maui.Core.WinControls;
using Maui.Core.Utilities;
using System.ComponentModel;
using System;
using System.Collections;
using System.Collections.Specialized;
using Mom.Test.UI.Core.Console;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.Console.MomControls;
using Mom.Test.UI.Core.Console.Dialogs;
using Mom.Test.UI.Core.Console.MonitoringConfiguration.Groups.Dialogs;
using Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs;

#endregion // Using directives

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Groups
{
    /// <summary>
    /// Class to add general methods for Groups 
    /// </summary>
    public class GroupsUI
    {
        #region Private Members

        /// <summary>
        /// cachedGroupParameters
        /// </summary>
        private GroupParameters cachedGroupParams = null;

        /// <summary>
        /// cachedGroupWizGeneralPropertiesPage
        /// </summary>
        private GroupWizGeneralPropertiesPage cachedGeneralPropertiesPage = null;

        /// <summary>
        /// cachedGroupWizExplicitMembersPage
        /// </summary>
        private GroupWizExplicitMembersPage cachedExplicitMembersPage = null;

        /// <summary>
        /// cachedGroupWizDynamicMembersPage
        /// </summary>
        private GroupWizDynamicMembersPage cachedDynamicMembersPage = null;

        /// <summary>
        /// cachedGroupWizSubgroupsPage
        /// </summary>
        private GroupWizSubgroupsPage cachedSubgroupsPage = null;

        /// <summary>
        /// cachedExcludedMembersPage
        /// </summary>
        private GroupWizExcludedMembersPage cachedExcludedMembersPage = null;

        /// <summary>
        /// cachedQueryBuilderDialog
        /// </summary>
        private CreateGroupQueryBuilderDialog cachedQueryBuilderDialog = null;

        /// <summary>
        /// cachedSelectObjectDialog
        /// </summary>
        private ObjectPickerDialog cachedSelectObjectDialog = null;

        /// <summary>
        /// cachedSelectGroupDialog
        /// </summary>
        private ObjectPickerDialog cachedSelectGroupDialog = null;

        /// <summary>
        /// cachedExcludeObjectDialog
        /// </summary>
        private ObjectPickerDialog cachedExcludeObjectDialog = null;

        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp = null;

        NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

        #endregion // Private Members

        #region Enumerators section

        /// <summary>
        /// Mode of action on Create, Delete and View Group
        /// </summary>
        public enum ActionMode
        {
            /// <summary>
            /// Invoke action from Context Menu
            /// </summary>
            ContextMenu,

            /// <summary>
            /// Invoke action by clicking a hyper link in Actions pane
            /// </summary>
            ActionsLink,
        }

        #endregion	// Enumerators section

        #region Constructor

        /// <summary>
        /// GroupsUI Constructor.
        /// </summary>
        public GroupsUI()
        {
            consoleApp = CoreManager.MomConsole;
        }

        #endregion // Constructor

        #region Properties

        /// <summary>
        /// GroupParams - Stores info relavent to test variation.
        /// </summary>
        public GroupParameters GroupParams
        {
            get
            {
                if (cachedGroupParams == null)
                {
                    cachedGroupParams = new GroupParameters();
                    Utilities.LogMessage("Create GroupParams.");
                }

                return cachedGroupParams;
            }
        }

        /// <summary>
        /// GeneralPropertiesPage - The first screen of the Create Group Wizard.
        /// </summary>
        public GroupWizGeneralPropertiesPage GeneralPropertiesPage
        {
            get
            {
                if (cachedGeneralPropertiesPage == null)
                {
                    cachedGeneralPropertiesPage = new GroupWizGeneralPropertiesPage(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Create Group Wizard General Properties page was successful.");
                }

                return cachedGeneralPropertiesPage;
            }
        }

        /// <summary>
        /// ExplicitMembersPage - The second screen of the Create Group Wizard
        /// </summary>
        public GroupWizExplicitMembersPage ExplicitMembersPage
        {
            get
            {
                if (cachedExplicitMembersPage == null)
                {
                    cachedExplicitMembersPage = new GroupWizExplicitMembersPage(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Create Group Wizard Explicit Members page was successful.");
                }

                return cachedExplicitMembersPage;
            }
        }

        /// <summary>
        /// DynamicMembersPage - The third screen of the Create Group Wizard
        /// </summary>
        public GroupWizDynamicMembersPage DynamicMembersPage
        {
            get
            {
                if (cachedDynamicMembersPage == null)
                {
                    cachedDynamicMembersPage = new GroupWizDynamicMembersPage(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Create Group Wizard Dynamic Members Page was successful.");
                }

                return cachedDynamicMembersPage;
            }
        }

        /// <summary>
        /// SubgroupsPage - The fourth screen of the Create Group Wizard
        /// </summary>
        public GroupWizSubgroupsPage SubgroupsPage
        {
            get
            {
                if (cachedSubgroupsPage == null)
                {
                    cachedSubgroupsPage = new GroupWizSubgroupsPage(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Create Group Wizard Subgroups page was successful.");
                }

                return cachedSubgroupsPage;
            }
        }

        /// <summary>
        /// ExcludedMembersPage - The fifth screen of the Create Group Wizard
        /// </summary>
        public GroupWizExcludedMembersPage ExcludedMembersPage
        {
            get
            {
                if (cachedExcludedMembersPage == null)
                {
                    cachedExcludedMembersPage = new GroupWizExcludedMembersPage(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Create Group Wizard Excluded Members Page was successful.");
                }

                return cachedExcludedMembersPage;
            }
        }

        /// <summary>
        /// QueryBuilderDialog - Dialog invoked from the Create Group Wizard
        /// </summary>
        public CreateGroupQueryBuilderDialog QueryBuilderDialog
        {
            get
            {
                if (cachedQueryBuilderDialog == null)
                {
                    cachedQueryBuilderDialog = new CreateGroupQueryBuilderDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Create Group Wizard Query Builder Dialog was successful.");
                }

                return cachedQueryBuilderDialog;
            }
        }

        /// <summary>
        /// SelectObjectDialog - Dialog invoked from the Create Group Wizard
        /// </summary>
        public ObjectPickerDialog SelectObjectDialog
        {
            get
            {
                if (cachedSelectObjectDialog == null)
                {
                    cachedSelectObjectDialog = new ObjectPickerDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Create Group Wizard - Select Object Dialog was successful.");
                }

                return cachedSelectObjectDialog;
            }
        }

        /// <summary>
        /// SelectGroupDialog - Dialog invoked from the Create Group Wizard
        /// </summary>
        public ObjectPickerDialog SelectGroupDialog
        {
            get
            {
                if (cachedSelectGroupDialog == null)
                {
                    cachedSelectGroupDialog = new ObjectPickerDialog(CoreManager.MomConsole, Strings.GroupSelectionDialogTitle);
                    Utilities.LogMessage("Setting Focus on the Create Group Wizard - Select Group Dialog was successful.");
                }

                return cachedSelectGroupDialog;
            }
        }

        /// <summary>
        /// ExcludeObjectDialog - Dialog invoked from the Create Group Wizard
        /// </summary>
        public ObjectPickerDialog ExcludeObjectDialog
        {
            get
            {
                if (cachedExcludeObjectDialog == null)
                {
                    cachedExcludeObjectDialog = new ObjectPickerDialog(CoreManager.MomConsole, Strings.ObjectExclusionDialogTitle);
                    Utilities.LogMessage("Setting Focus on the Create Group Wizard - Exclude Object Dialog was successful.");
                }

                return cachedExcludeObjectDialog;
            }
        }

        #endregion // Properties

        #region Public Methods

        /// <summary>
        /// Method to navigate to the Groups view under Monitoring Configuration from anywhere in the MOMconsole.
        /// </summary>        
        public void NavigateToGroupsView()
        {
            Utilities.LogMessage("GroupsUI.NavigateToGroupsView :: Navigate to Monitoring Configuration - Groups view.");
            
            try
            {
                // Make sure the UI is ready
                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                Utilities.LogMessage("GroupsUI.NavigateToGroupsView :: WaitForUIObjectReady returned.");

                // Select Monitoring Configuration Wunderbar
                NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
                navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.MonitoringConfiguration);
                Utilities.LogMessage("GroupsUI.NavigateToGroupsView :: Successfully selected the MonitoringConfiguration Wunderbar");

                // Select Groups node in Treeview
                navPane.SelectNode(NavigationPane.Strings.MonConfigTreeViewGroups, NavigationPane.NavigationTreeView.MonitoringConfiguration);
                Utilities.LogMessage("GroupsUI.NavigateToGroupsView :: Successfully clicked on Groups node under MonitoringConfiguration Treeview");
            }
            catch (Exception ex)
            {
                Utilities.LogMessage("GroupsUI.NavigateToGroupsView :: Exception: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// ExecuteCreateGroupWizard - This method invokes the Create Group Wizard from either the Actions pane
        /// or the context menu.
        /// </summary>
        public void ExecuteCreateGroupWizard()
        {
            Utilities.LogMessage("GroupsUI.ExecuteCreateGroupWizard(...)");
            Utilities.LogMessage("GroupsUI.ExecuteCreateGroupWizard :: Launch Create Group Wizard from Actions pane.");

            try
            {
                // Navigate to Groups view
                NavigateToGroupsView();
                Utilities.LogMessage("GroupsUI.ExecuteCreateGroupWizard :: Navigate to Groups view.");

                if (GroupParams.CreateMode == ActionMode.ActionsLink)
                {
                    Utilities.LogMessage("GroupsUI.ExecuteCreateGroupWizard :: Launch Wizard through ActionsLink.");
                    //Get Reference to Actions Pane and click the action link.
                    ActionsPane actionsPane = CoreManager.MomConsole.ActionsPane;
                    string sGroupPath = NavigationPane.Strings.MonitoringConfiguration + Constants.PathDelimiter +
                                        NavigationPane.Strings.MonConfigTreeViewGroups;
                    actionsPane.ClickLink(NavigationPane.WunderBarButton.MonitoringConfiguration, sGroupPath,
                                          ActionsPane.Strings.ActionsPaneGroup, ActionsPane.Strings.ActionsPaneCreateANewGroup);
                    Utilities.LogMessage("GroupsUI.ExecuteCreateGroupWizard :: Launch Create Group Wizard through ActionsLink successful.");
                }
                else if (GroupParams.CreateMode == ActionMode.ContextMenu)
                {
                    Utilities.LogMessage("GroupsUI.ExecuteCreateGroupWizard :: Launch Wizard through ContextMenu.");
                    // Select the Context Menu to invoke Create Group Wizard
                    CoreManager.MomConsole.NavigationPane.Controls.MonitoringConfigurationTreeView
                        .Find(NavigationPane.Strings.MonConfigTreeViewGroups).ContextMenu
                        .ExecuteMenuItem(NavigationPane.Strings.ContextMenuCreateGroupWizard);
                    Utilities.LogMessage("GroupsUI.ExecuteCreateGroupWizard :: Launch Create Group Wizard through ContextMenu successful");

                }
                else
                {
                    throw new ApplicationException("GroupsUI.ExecuteCreateGroupWizard : Invalid CreateMode parameter: " +
                                       GroupParams.CreateMode);
                }
            }
            catch (Exception ex)
            {
                Utilities.LogMessage("GroupsUI.ExecuteCreateGroupWizard :: Exception: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// AddRemoveObjects - This method invokes the Object Selection dialog and performs actions on it.
        /// It closes the dialog when actions are done.
        /// </summary>
        public void AddRemoveObjects()
        {
            Utilities.LogMessage("GroupsUI.AddRemoveObjects(...)");
            Utilities.LogMessage("GroupsUI.AddRemoveObjects :: Object Selection dialog Launched from Explicit Members page");

            try
            {
                // Set Object Category dropdown
                SelectObjectDialog.SearchForText = GroupParams.ObjectCategory;
                Utilities.LogMessage("GroupsUI.AddRemoveObjects :: Set the Object Category as: " + GroupParams.ObjectCategory);

                // Make sure the UI is ready
                SelectObjectDialog.ScreenElement.WaitForReady();
                Utilities.LogMessage("GroupsUI.AddRemoveObjects :: WaitForUIObjectReady returned after Set Object Category");

                if (SelectObjectDialog.SearchForText == Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDSystemLibraryMP, ManagementPackConstants.SystemEntityName))
                {
                    // When search category is "Object", there are more than 1000 items present if we don't filter the search, this takes too much time, so we need to filter here
                    SelectObjectDialog.FilterByPartOfNameOptionalText = "Spooler";
                }

                // Click Search button
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(SelectObjectDialog.Controls.SearchButton, Constants.OneMinute);
                SelectObjectDialog.ClickSearch();
                Utilities.LogMessage("GroupsUI.AddRemoveObjects : SelectObjectDialog - Search button clicked");

                // Make sure the UI is ready
                SelectObjectDialog.Controls.AvailableItemsListView.ScreenElement.WaitForReady();
                Utilities.LogMessage("GroupsUI.AddRemoveObjects :: WaitForUIObjectReady returned after Click Search button");

                // Perform Add/Remove
                int nCount = SelectObjectDialog.Controls.AvailableItemsListView.Count;
                Utilities.LogMessage("GroupsUI.AddRemoveObjects : SelectObjectDialog - Available Item Count: " + nCount);

                int retry = 0;
                int maxtries = 30;

                //Add retry logic to make sure the item in the list view is ready
                while (nCount == 0 && retry < maxtries)
                {
                    Sleeper.Delay(Core.Common.Constants.OneSecond);
                    nCount = SelectObjectDialog.Controls.AvailableItemsListView.Count;
                    Utilities.LogMessage("GroupsUI.AddRemoveObjects : SelectObjectDialog - Available Item Count: " + nCount);
                    retry++;
                }

                if (nCount > 0)
                {
                    //if (GroupParams.ObjectCategory == "Entity") //It's going to select only the "Spooler" Object because of MP bug 65021
                    if (GroupParams.ObjectCategory == Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDSystemLibraryMP, ManagementPackConstants.SystemEntityName))
                    {
                        // First selecting Spooler item 
                        Utilities.LogMessage("GroupsUI.ExcludeObjects : ExcludeObjectDialog - Select Spooler item");
                        Mom.Test.UI.Core.Console.MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;
                        int nCol = viewGrid.GetColumnTitlePosition(Strings.GroupColumnName);
                        Utilities.LogMessage("GroupsUI.ExcludeObjects :: The column position is:" + nCol.ToString());
                        CoreManager.MomConsole.SelectListViewItems("Spooler", nCol, this.SelectObjectDialog.Controls.AvailableItemsListView,false);

                        // Make sure the UI is ready
                        SelectObjectDialog.ScreenElement.WaitForReady();
                        Utilities.LogMessage("GroupsUI.ExcludeObjects :: WaitForUIObjectReady returned after SelectSpooler");
                        nCount = 1; //Only Spooler is selected. 

                    }
                    else //If the Computer Object is used then we can select all instances. 
                    {
                        // Select all available items
                        Utilities.LogMessage("GroupsUI.AddRemoveObjects : SelectObjectDialog - Select all available items");
                        SelectObjectDialog.Controls.AvailableItemsListView.SelectAll();

                        // Make sure the UI is ready
                        SelectObjectDialog.ScreenElement.WaitForReady();
                        Utilities.LogMessage("GroupsUI.AddRemoveObjects :: WaitForUIObjectReady returned after SelectAll");

                    }
                    // Click Add button
                    Utilities.LogMessage("GroupsUI.AddRemoveObjects : SelectObjectDialog - Click Add button");
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
                        SelectObjectDialog.Controls.AddButton,
                        Core.Common.Constants.DefaultDialogTimeout);
                    SelectObjectDialog.ClickAdd();

                    // Make sure the UI is ready
                    SelectObjectDialog.ScreenElement.WaitForReady();
                    Utilities.LogMessage("GroupsUI.AddRemoveObjects :: WaitForUIObjectReady returned after Click Add button");

                    //wait for all selected available items added in selectedObjectsListView
                    CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccessSafe(delegate() 
                    {
                        return SelectObjectDialog.Controls.AvailableItemsListView.Count == SelectObjectDialog.Controls.SelectedObjectsListView.Count;
                    });

                    int nAddedCount = SelectObjectDialog.Controls.SelectedObjectsListView.Count;
                    Utilities.LogMessage("GroupsUI.AddRemoveObjects : SelectObjectDialog - Added item count: " + nAddedCount);

                    if (nAddedCount == nCount)
                    {
                        GroupParams.GroupMembers.Clear();
                        foreach (ListViewItem item in SelectObjectDialog.Controls.SelectedObjectsListView.Items)
                        {
                            GroupParams.GroupMembers.Add(item.Text);
                        }

                        // Close the dialog
                        CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
                            SelectObjectDialog.Controls.OKButton,
                            Core.Common.Constants.DefaultDialogTimeout);
                        SelectObjectDialog.ClickOK();
                        Utilities.LogMessage("&&&&&&&&&&&&&& Waiting for dialog to close &&&&&&&&&&&&&&&");
                        CoreManager.MomConsole.WaitForDialogClose(SelectObjectDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
                        //}
                    }
                    else
                    {
                        // Add button doesn't work properly
                        SelectObjectDialog.ClickCancel();
                        CoreManager.MomConsole.WaitForDialogClose(SelectObjectDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
                        throw new ApplicationException("GroupsUI.AddRemoveObjects : SelectObjectDialog - " + 
                                           "Add button doesn't add correct number of items");
                    }
                }
                else
                {
                    // Nothing to add, cancel the dialog
                    Utilities.LogMessage("GroupsUI.AddRemoveObjects : SelectObjectDialog - " + 
                                         "There is no available items to add");
                    SelectObjectDialog.ClickCancel();
                    CoreManager.MomConsole.WaitForDialogClose(SelectObjectDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
                }
            }
            catch (Exception ex)
            {
                Utilities.LogMessage("GroupsUI.AddRemoveObjects :: Exception: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// AddMoreObjects - Add all the objects returned by the passing object category for existing group
        /// </summary>
        /// <exception cref="Button.Exceptions.CheckFailedException">CheckFailedException</exception>
        /// <history>
        ///     [v-cheli] 10Dec08 - Created        
        /// </history>
        public void AddMoreObjects()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            ObjectPickerDialog addObjectDialog = new ObjectPickerDialog(CoreManager.MomConsole);
            addObjectDialog.ScreenElement.WaitForReady();

            //It is used for add another object on the existing
            int nExist = addObjectDialog.Controls.SelectedObjectsListView.Count;
            Utilities.LogMessage(currentMethod + "(...):: addObjectDialog - Existing selected item count: " + nExist);

            #region set the Ojbect Category and search

            // Set Object Category dropdown
            addObjectDialog.SearchForText = GroupParams.ObjectCategory;
            Utilities.LogMessage(currentMethod + "(...):: Set the Object Category as: " + GroupParams.ObjectCategory);

            // Make sure the UI is ready
            addObjectDialog.ScreenElement.WaitForReady();
            Utilities.LogMessage(currentMethod + "(...):: WaitForUIObjectReady returned after Set Object Category");

            // Click Search button
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(addObjectDialog.Controls.SearchButton, Constants.OneMinute);
            addObjectDialog.ClickSearch();
            Utilities.LogMessage(currentMethod + "(...):: addObjectDialog - Search button clicked");

            // Make sure the UI is ready
            addObjectDialog.ScreenElement.WaitForReady();
            Utilities.LogMessage(currentMethod + "(...)::WaitForUIObjectReady returned after Click Search button");

            #endregion

            #region Add the available items

            int nCount = addObjectDialog.Controls.AvailableItemsListView.Count;
            Utilities.LogMessage(currentMethod + "(...):: addObjectDialog - Available Item Count: " + nCount);

            int retry = 0;
            int maxtries = 10;

            //Add retry logic to make sure the item in the list view is ready
            while (nCount == 0 && retry < maxtries)
            {
                Sleeper.Delay(Core.Common.Constants.OneSecond);
                nCount = addObjectDialog.Controls.AvailableItemsListView.Count;
                Utilities.LogMessage(currentMethod + "(...):: addObjectDialog - Available Item Count: " + nCount);
                retry++;
            }

            //If there are something to be added
            if (nCount > 0)
            {
                #region Select the items to add
           
                // Select all available items
                Utilities.LogMessage(currentMethod + "(...):: addObjectDialog - Select all available items");
                addObjectDialog.Controls.AvailableItemsListView.SelectAll();

                // Make sure the UI is ready
                addObjectDialog.ScreenElement.WaitForReady();
                Utilities.LogMessage(currentMethod + "(...)::WaitForUIObjectReady returned after SelectAll");


                #endregion

                // Click Add button
                Utilities.LogMessage(currentMethod + "(...):: addObjectDialog - Click Add button");
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(addObjectDialog.Controls.AddButton, Constants.OneMinute);
                addObjectDialog.ClickAdd();

                // Make sure the UI is ready
                addObjectDialog.ScreenElement.WaitForReady();
                Utilities.LogMessage(currentMethod + "(...)::WaitForUIObjectReady returned after Click Add button");

                #region verify  and close dialog after Add

                int nAddedCount = addObjectDialog.Controls.SelectedObjectsListView.Count;
                Utilities.LogMessage(currentMethod + "(...):: addObjectDialog - Added item count: " + nAddedCount);

                retry = 0;

                //Add retry logic to make sure the item in the list view is ready
                while (nAddedCount != (nCount + nExist) && retry < maxtries)
                {
                    Sleeper.Delay(Core.Common.Constants.OneSecond);
                    nAddedCount = addObjectDialog.Controls.SelectedObjectsListView.Count;
                    Utilities.LogMessage(currentMethod + "(...):: addObjectDialog - Added item count: " + nAddedCount);
                    retry++;
                }

                if (nAddedCount == (nCount + nExist))
                {
                    GroupParams.GroupMembers.Clear();
                    foreach (ListViewItem item in addObjectDialog.Controls.SelectedObjectsListView.Items)
                    {
                        GroupParams.GroupMembers.Add(item.Text);
                    }

                    // Close the dialog
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
                        addObjectDialog.Controls.OKButton,
                        Core.Common.Constants.DefaultDialogTimeout);
                    addObjectDialog.ClickOK();
                    Utilities.LogMessage(currentMethod + "(...)::Waiting for dialog to close");
                    CoreManager.MomConsole.WaitForDialogClose(addObjectDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
                    
                }
                else
                {
                    // Add button doesn't work properly
                    addObjectDialog.ClickCancel();
                    CoreManager.MomConsole.WaitForDialogClose(addObjectDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
                    throw new Maui.Core.WinControls.Button.Exceptions.CheckFailedException(currentMethod + "(...):: addObjectDialog - " +
                                       "Add button doesn't add correct number of items");
                }

                #endregion
            }
            else
            {
                // Nothing to add, cancel the dialog
                Utilities.LogMessage(currentMethod + "(...):: addObjectDialog - " +
                                     "There is no available items to add");
                addObjectDialog.ClickCancel();
            }

            #endregion
 
        }
        
        /// <summary>
        /// CreateEditRules - This method invokes the Query Builder dialog and performs actions on it.
        /// It closes the dialog when actions are done.
        /// </summary>
        public void CreateEditRules()
        {
            Utilities.LogMessage("GroupsUI.CreateEditRules(...)");
            Utilities.LogMessage("GroupsUI.CreateEditRules :: Query Builder dialog Launched from Dynamic Members page.");
            
            try
            {
                // Select desired class
                switch (GroupParams.QueryClass.Trim().ToLowerInvariant())
                {
                    case "windows computer":
                        QueryBuilderDialog.DesiredClassText = Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDMicrosoftWindowsLibraryMP, ManagementPackConstants.WindowsComputerGroupName);
                        break;
                    case "windows computer role":
                        QueryBuilderDialog.DesiredClassText = Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDMicrosoftWindowsLibraryMP, ManagementPackConstants.WindowsComputerRoleName);
                        break;
                    default:
                        QueryBuilderDialog.DesiredClassText = GroupParams.QueryClass;
                        break;
                }

                // Make sure the UI is ready
                QueryBuilderDialog.ScreenElement.WaitForReady();
                Utilities.LogMessage("GroupsUI.CreateEditRules :: WaitForUIObjectReady returned after Select desired class");

                // Click Add button
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(QueryBuilderDialog.Controls.AddButton, Core.Common.Constants.DefaultDialogTimeout);
                QueryBuilderDialog.ClickAdd();
                Utilities.LogMessage("GroupsUI.CreateEditRules : QueryBuilderDialog - Add button clicked");

                // Make sure the UI is ready
                QueryBuilderDialog.ScreenElement.WaitForReady();
                Utilities.LogMessage("GroupsUI.CreateEditRules :: WaitForUIObjectReady returned after Click Add button");

                // Click Formula button in Grid Toolbar
                Utilities.LogMessage("GroupsUI.CreateEditRules :: Click Formula button in Grid Toolbar");
                QueryBuilderDialog.Controls.FormulaGridToolbar.ToolbarItems[1].Click();

                // Make sure the UI is ready
                QueryBuilderDialog.ScreenElement.WaitForReady();
                Utilities.LogMessage("GroupsUI.CreateEditRules :: WaitForUIObjectReady returned after Click Delete button");

                // Close the dialog
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(QueryBuilderDialog.Controls.OKButton, Core.Common.Constants.DefaultDialogTimeout);
                QueryBuilderDialog.ClickOK();
            }
            catch (Exception ex)
            {
                Utilities.LogMessage("GroupsUI.CreateEditRules :: Exception: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Create Rules - Add one rule at a time with Property, operator and Value
        /// </summary>
        /// <exception cref="DataGrid.Exceptions.DataGridCellNotFoundException">DataGridCellNotFoundException</exception>
        /// <history>
        ///     [v-cheli] 10Dec08 - Created        
        /// </history>
        public void CreateInclusionRules()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            #region Select the Query class and click add

            // Select desired class
            switch (GroupParams.QueryClass.Trim().ToLowerInvariant())
            {
                case "windows computer":
                    QueryBuilderDialog.DesiredClassText = Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDMicrosoftWindowsLibraryMP, ManagementPackConstants.WindowsComputerGroupName);
                    break;
                case "windows computer role":
                    QueryBuilderDialog.DesiredClassText = Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDMicrosoftWindowsLibraryMP, ManagementPackConstants.WindowsComputerRoleName);
                    break;
                default:
                    QueryBuilderDialog.DesiredClassText = GroupParams.QueryClass;
                    break;
            }

            // Make sure the UI is ready
            QueryBuilderDialog.ScreenElement.WaitForReady();
            Utilities.LogMessage(currentMethod + "(...):: WaitForUIObjectReady returned after Select desired class");

            // Click Add button
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(QueryBuilderDialog.Controls.AddButton, Constants.OneMinute);
            QueryBuilderDialog.ClickAdd();
            Utilities.LogMessage(currentMethod + "(...):: QueryBuilderDialog - Add button clicked");

            // Make sure the UI is ready
            QueryBuilderDialog.ScreenElement.WaitForReady();
            Utilities.LogMessage(currentMethod + "(...):: WaitForUIObjectReady returned after Click Add button");

            #endregion

            #region Set the value for the Formula grid

            //Create instance of Formula Grid Control
            Core.Console.MomControls.GridControl formulaGrid = new Core.Console.MomControls.GridControl(QueryBuilderDialog,
            Core.Console.MomControls.GridControl.ControlIDs.FormulaGrid);

            if (formulaGrid != null)
            {
                Utilities.LogMessage(currentMethod + ": FormulaGrid found");

                int colposPropertyName = formulaGrid.GetColumnTitlePosition(Strings.PropertyColumnName);
                int colposOperator = formulaGrid.GetColumnTitlePosition(BuildExpressionDialog.Strings.GridOperatorColumn);
                int colposValue = formulaGrid.GetColumnTitlePosition(BuildExpressionDialog.Strings.GridValueColumn);

                //The first item can be added from this row
                int rowIndex = 2;

                //Below is the simple work around for the WinForm ID missing bug(131683)

                formulaGrid.Extended.SetFocus();
                formulaGrid.ClickCell(rowIndex, colposPropertyName);

                //Set the value for the Property column
                Maui.Core.WinControls.Menu propertyMembersItem = new Maui.Core.WinControls.Menu();
                propertyMembersItem.ScreenElement.WaitForReady();

                StringCollection hostProperty = new StringCollection();
                hostProperty.Add(GroupParams.QueryHostClass);
                hostProperty.Add(GroupParams.QueryProperty);

                if (!string.IsNullOrEmpty(GroupParams.QueryHostClass))
                {
                    propertyMembersItem.ExecuteMenuItem(hostProperty);
                }
                else
                {
                    propertyMembersItem.ExecuteMenuItem(GroupParams.QueryProperty);
                }

                QueryBuilderDialog.SendKeys(KeyboardCodes.RightArrow);
                formulaGrid.ClickCell(rowIndex, colposOperator);

                //Set the first value for the Operator column
                QueryBuilderDialog.SendKeys(KeyboardCodes.DownArrow);
                QueryBuilderDialog.SendKeys(KeyboardCodes.Space);
                QueryBuilderDialog.SendKeys(KeyboardCodes.Enter);

                //Set the value for the Value column
                formulaGrid.ClickCell(rowIndex, colposValue);
                Keyboard.SendOfficeKeys(GroupParams.QueryValue);

                //formulaGrid.SetCellValue(formulaGrid.Extended.AccessibleObject.Window, GroupParams.QueryOperator, DataGridViewCellType.ComboBox, Core.Console.MonitoringConfiguration.Events.Events.Strings.OperatorComboBoxEditorWinFormsId);
                Utilities.LogMessage(currentMethod + "(...)::  WaitForUIObjectReady returned after add query");

            }
            else
            {
                Utilities.LogMessage(currentMethod + "(...)::  No formula grid can be found");
                throw new Maui.Core.WinControls.DataGrid.Exceptions.DataGridCellNotFoundException(currentMethod + "(...)::  No formula grid can be found");
            }

            #endregion

            // Make sure the UI is ready
            QueryBuilderDialog.ScreenElement.WaitForReady();
            Utilities.LogMessage(currentMethod + "(...)::  WaitForUIObjectReady returned after add query");

            // Close the dialog
            QueryBuilderDialog.ClickOK();

        }

        /// <summary>
        /// AddRemoveSubgroups - This method invokes the Group Selection dialog and performs actions on it.
        /// It closes the dialog when actions are done.
        /// </summary>
        public void AddRemoveSubgroups()
        {
            Utilities.LogMessage("GroupsUI.AddRemoveSubgroups(...)");
            Utilities.LogMessage("GroupsUI.AddRemoveSubgroups :: Group Selection dialog Launched from Subgroups page.");

            try
            {
                // Click Search button
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(SelectGroupDialog.Controls.SearchButton, Core.Common.Constants.DefaultDialogTimeout);
                SelectGroupDialog.ClickSearch();
                Utilities.LogMessage("GroupsUI.AddRemoveSubgroups : SelectGroupDialog - Search button clicked");

                // Make sure the UI is ready
                SelectGroupDialog.ScreenElement.WaitForReady();
                Utilities.LogMessage("GroupsUI.AddRemoveSubgroups :: WaitForUIObjectReady returned after Click Search button");

                // Perform Add/Remove
                int nCount = SelectGroupDialog.Controls.AvailableItemsListView.Count;
                Utilities.LogMessage("GroupsUI.AddRemoveSubgroups : SelectGroupDialog - Available Item Count: " + nCount);

                int retry = 0;
                int maxtries = 10;

                //Add retry logic to make sure the item in the list view is ready
                while (nCount == 0 && retry < maxtries)
                {
                    Sleeper.Delay(Core.Common.Constants.OneSecond);
                    nCount = SelectGroupDialog.Controls.AvailableItemsListView.Count;
                    Utilities.LogMessage("GroupsUI.AddRemoveObjects : SelectGroupDialog - Available Item Count: " + nCount);
                    retry++;
                }

                if (nCount > 0)
                {
                    // Select all available items
                    Utilities.LogMessage("GroupsUI.AddRemoveSubgroups : SelectGroupDialog - Select all available items");
                    Mom.Test.UI.Core.Console.MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;
                    int nCol = viewGrid.GetColumnTitlePosition(Strings.GroupColumnName);
                    Utilities.LogMessage("GroupsUI.AddRemoveSubgroups :: The column position is:" + nCol.ToString());
                    //Adding only UI Test Computer Group as the subgroup. 
                    CoreManager.MomConsole.SelectListViewItems("UI Test Computer Group", nCol, this.SelectGroupDialog.Controls.AvailableItemsListView, false);
                    nCount = 1; //Only UI Group Test is going to be selected. 

                    // Make sure the UI is ready
                    SelectGroupDialog.ScreenElement.WaitForReady();
                    Utilities.LogMessage("GroupsUI.AddRemoveSubgroups :: WaitForUIObjectReady returned after SelectAll");

                    // Click Add button
                    Utilities.LogMessage("GroupsUI.AddRemoveSubgroups : SelectGroupDialog - Click Add button");
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
                        SelectGroupDialog.Controls.AddButton,
                        Core.Common.Constants.DefaultDialogTimeout);
                    SelectGroupDialog.ClickAdd();

                    // Make sure the UI is ready
                    SelectGroupDialog.ScreenElement.WaitForReady();
                    Utilities.LogMessage("GroupsUI.AddRemoveSubgroups :: WaitForUIObjectReady returned after Click Add button");

                    int nAddedCount = SelectGroupDialog.Controls.SelectedObjectsListView.Count;
                    Utilities.LogMessage("GroupsUI.AddRemoveSubgroups : SelectGroupDialog - Added item count: " + nAddedCount);
                    if (nAddedCount == 1)
                    {
                        // TODO: Uncomment when Removing doesn't crash UI [mbickle]
                        // If more than one item, remove last item
                        //if (nAddedCount > 1)
                        //{
                        //    // Select last item
                        //    Utilities.LogMessage("GroupsUI.AddRemoveSubgroups : SelectGroupDialog - Remove last item added");
                        //    SelectGroupDialog.Controls.SelectedObjectsListView.Items[nAddedCount - 1].Select();

                        //    // Make sure the UI is ready
                        //    UISynchronization.WaitForUIObjectReady(SelectGroupDialog, Constants.DefaultDialogTimeout);
                        //    Sleeper.Delay(nOneSecond * 2);
                        //    Utilities.LogMessage("GroupsUI.AddRemoveSubgroups :: WaitForUIObjectReady returned after Select last item");

                        //    // Click Remove button
                        //    Utilities.LogMessage("GroupsUI.AddRemoveSubgroups : SelectGroupDialog - Click Add button");
                        //    SelectGroupDialog.ClickRemove();

                        //    // Make sure the UI is ready
                        //    UISynchronization.WaitForUIObjectReady(SelectGroupDialog, Constants.DefaultDialogTimeout);
                        //    Sleeper.Delay(nOneSecond * 2);
                        //    Utilities.LogMessage("GroupsUI.AddRemoveSubgroups :: WaitForUIObjectReady returned after Click Remove button");

                        //    // Verify that Remove button works properly
                        //    Utilities.LogMessage("GroupsUI.AddRemoveSubgroups : SelectGroupDialog - Verify Remove works");
                        //    int nSelectedCount = SelectGroupDialog.Controls.SelectedObjectsListView.Count;
                        //    if (nSelectedCount == nAddedCount - 1)
                        ////    {
                        //        Utilities.LogMessage("GroupsUI.AddRemoveSubgroups : SelectGroupDialog - " +
                        //                             "Selected Item Count after remove last item: " + nSelectedCount);
                        //        // Populate Subgroups ArrayList
                        //        GroupParams.Subgroups.Clear();
                        //        foreach (ListViewItem item in SelectGroupDialog.Controls.SelectedObjectsListView.Items)
                        //        {
                        //            GroupParams.Subgroups.Add(item.Text);
                        //        }

                        //        // Close the dialog
                        //        SelectGroupDialog.ClickOK();
                        //    }
                        //    else
                        //    {
                        //        // Remove button doesn't work properly
                        //        SelectGroupDialog.ClickCancel();
                        //        throw new VarAbort("GroupsUI.AddRemoveSubgroups : SelectGroupDialog - " +
                        //                           "Remove button doesn't remove correct number of items");
                        //    }
                        //}
                        //else // Only 1 item selected, don't do remove
                        //{
                        // Populate Subgroups ArrayList
                        GroupParams.Subgroups.Clear();
                        foreach (ListViewItem item in SelectGroupDialog.Controls.SelectedObjectsListView.Items)
                        {
                            GroupParams.Subgroups.Add(item.Text);
                        }

                        // Close the dialog
                        CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
                            SelectGroupDialog.Controls.OKButton,
                            Core.Common.Constants.DefaultDialogTimeout);
                        SelectGroupDialog.ClickOK();
                        Utilities.LogMessage("&&&&&&&&&&&&&& Waiting for dialog to close &&&&&&&&&&&&&&&");
                        CoreManager.MomConsole.WaitForDialogClose(SelectGroupDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
                        //}
                    }
                    else
                    {
                        // Add button doesn't work properly
                        SelectGroupDialog.ClickCancel();
                        CoreManager.MomConsole.WaitForDialogClose(SelectGroupDialog, Constants.DefaultDialogTimeout);
                        throw new ApplicationException("GroupsUI.AddRemoveSubgroups : SelectGroupDialog - " +
                                           "Add button doesn't add correct number of items");
                    }
                }
                else
                {
                    // Nothing to add, cancel the dialog
                    Utilities.LogMessage("GroupsUI.AddRemoveSubgroups : SelectGroupDialog - " +
                                         "There is no available items to add");
                    SelectGroupDialog.ClickCancel();
                }
            }
            catch (Exception ex)
            {
                Utilities.LogMessage("GroupsUI.AddRemoveSubgroups :: Exception: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// AddOrChangeSubgroupMember - remove all existing group members and add new members based on the new group search filter
        /// </summary>
        /// <exception cref="Button.Exceptions.CheckFailedException">CheckFailedException</exception>
        /// <history>
        ///     [v-cheli] 10Dec08 - Created        
        /// </history>
        public void AddOrChangeSubgroupMember()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            ObjectPickerDialog addSubgroupDialog = new ObjectPickerDialog(CoreManager.MomConsole, Strings.GroupSelectionDialogTitle);
            addSubgroupDialog.ScreenElement.WaitForReady();

            #region remove the existing member

            int nCounts = addSubgroupDialog.Controls.SelectedObjectsListView.Count;
            Utilities.LogMessage(currentMethod + "(...):: - Available Item Count: " + nCounts);

            int retry = 0;
            int maxtries = 10;

            //Add retry logic to make sure the item in the list view is ready
            while (nCounts == 0 && retry < maxtries)
            {
                Sleeper.Delay(Core.Common.Constants.OneSecond);
                nCounts = addSubgroupDialog.Controls.SelectedObjectsListView.Count;
                Utilities.LogMessage(currentMethod + "(...):: - Available Item Count: " + nCounts);
                retry++;
            }

            if (nCounts > 0)
            {
                addSubgroupDialog.Controls.SelectedObjectsListView.SelectAll();
                addSubgroupDialog.ScreenElement.WaitForReady();
                Utilities.LogMessage(currentMethod + "(...) :: WaitForUIObjectReady returned after select all Objects");

                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
                    addSubgroupDialog.Controls.RemoveButton,
                    Core.Common.Constants.DefaultDialogTimeout);
                addSubgroupDialog.ClickRemove();
                addSubgroupDialog.ScreenElement.WaitForReady();
                Utilities.LogMessage(currentMethod + "(...) :: WaitForUIObjectReady returned after Click Remove button");
            }

            #endregion

            #region search with the filter

            addSubgroupDialog.FilterByPartOfNameOptionalText = GroupParams.SubgroupFilter;

            //Make sure the UI is ready
            addSubgroupDialog.ScreenElement.WaitForReady();
            Utilities.LogMessage(currentMethod + "(...) :: WaitForUIObjectReady returned after set group search filter");

            // Click Search button
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(addSubgroupDialog.Controls.SearchButton, Core.Common.Constants.DefaultDialogTimeout);
            addSubgroupDialog.ClickSearch();
            Utilities.LogMessage(currentMethod + "(...) :: addSubgroupDialog - Search button clicked");

            // Make sure the UI is ready
            addSubgroupDialog.ScreenElement.WaitForReady();
            Utilities.LogMessage(currentMethod + "(...) :: WaitForUIObjectReady returned after Click Search button");

            #endregion

            #region select all available items and add

            // Perform Add
            int nCount = addSubgroupDialog.Controls.AvailableItemsListView.Count;
            Utilities.LogMessage(currentMethod + "(...) :: addSubgroupDialog - Available Item Count: " + nCount);

            retry = 0;
            maxtries = 10;

            //Add retry logic to make sure the item in the list view is ready
            while (nCount == 0 && retry < maxtries)
            {
                Sleeper.Delay(Core.Common.Constants.OneSecond);
                nCount = addSubgroupDialog.Controls.AvailableItemsListView.Count;
                Utilities.LogMessage(currentMethod + "(...) :: addSubgroupDialog - Available Item Count: " + nCount);
                retry++;
            }

            //if there are available item
            if (nCount > 0)
            {
                addSubgroupDialog.Controls.AvailableItemsListView.SelectAll();
                Utilities.LogMessage(currentMethod + "(...) :: addSubgroupDialog - Select all available items");

                // Make sure the UI is ready
                addSubgroupDialog.ScreenElement.WaitForReady();
                Utilities.LogMessage(currentMethod + "(...) :: WaitForUIObjectReady returned after select all");

                // Click Add button
                Utilities.LogMessage(currentMethod + "(...) :: addSubgroupDialog - Click Add button");
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(addSubgroupDialog.Controls.AddButton, Constants.OneMinute);
                addSubgroupDialog.ClickAdd();

                // Make sure the UI is ready
                addSubgroupDialog.ScreenElement.WaitForReady();
                Utilities.LogMessage(currentMethod + "(...) :: WaitForUIObjectReady returned after Click Add button");

                int nAddedCount = addSubgroupDialog.Controls.SelectedObjectsListView.Count;
                Utilities.LogMessage(currentMethod + "(...) ::addSubgroupDialog - Added item count: " + nAddedCount);

                retry = 0;

                //Add retry logic to make sure the item in the list view is ready
                while (nAddedCount != nCount && retry < maxtries)
                {
                    Sleeper.Delay(Core.Common.Constants.OneSecond);
                    nAddedCount = addSubgroupDialog.Controls.SelectedObjectsListView.Count;
                    Utilities.LogMessage(currentMethod + "(...) ::addSubgroupDialog - Added item count: " + nAddedCount);
                    retry++;
                }

                #region after perform add

                //if all the available items have been added
                if (nAddedCount == nCount)
                {

                    // Populate Subgroups ArrayList
                    GroupParams.Subgroups.Clear();
                    foreach (ListViewItem item in addSubgroupDialog.Controls.SelectedObjectsListView.Items)
                    {                        
                        GroupParams.Subgroups.Add(item.Text);
                    }

                    // Close the dialog
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
                        addSubgroupDialog.Controls.OKButton,
                        Core.Common.Constants.DefaultDialogTimeout / Constants.OneSecond);
                    addSubgroupDialog.ClickOK();
                    Utilities.LogMessage(currentMethod + "(...) :: Waiting for dialog to close");
                    CoreManager.MomConsole.WaitForDialogClose(addSubgroupDialog, Constants.DefaultDialogTimeout);
                }
                else
                {
                    // Add button doesn't work properly
                    addSubgroupDialog.ClickCancel();
                    CoreManager.MomConsole.WaitForDialogClose(addSubgroupDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
                    throw new Maui.Core.WinControls.Button.Exceptions.CheckFailedException(currentMethod + "(...) :: addSubgroupDialog - " +
                                       "Add button doesn't add correct number of items");
                }

                #endregion

            }
            else
            {
                // Nothing to add, cancel the dialog
                Utilities.LogMessage(currentMethod + "(...) :: addSubgroupDialog - " +
                                     "There is no available items to add");
                addSubgroupDialog.ClickCancel();

            }

            #endregion


        }

        /// <summary>
        /// RemoveExcludeObject - remove all the existing Excluded ojbects
        /// </summary>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [v-cheli] 10Dec08 - Created        
        /// </history>
        public void RemoveExcludeOjbect()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            ObjectPickerDialog excludedDialog = new ObjectPickerDialog(CoreManager.MomConsole, Strings.ObjectExclusionDialogTitle);
            excludedDialog.ScreenElement.WaitForReady();

            #region remove the existing member

            int nCount = excludedDialog.Controls.SelectedObjectsListView.Count;

            if (nCount > 0)
            {
                excludedDialog.Controls.SelectedObjectsListView.SelectAll();
                excludedDialog.ScreenElement.WaitForReady();
                Utilities.LogMessage(currentMethod + "(...) :: WaitForUIObjectReady returned after select all Objects");

                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
                    excludedDialog.Controls.RemoveButton,
                    Core.Common.Constants.DefaultDialogTimeout);
                excludedDialog.ClickRemove();
                excludedDialog.ScreenElement.WaitForReady();
                Utilities.LogMessage(currentMethod + "(...) :: WaitForUIObjectReady returned after Click Remove button");

                GroupParams.ExcludedObjects.Clear();

                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
                    excludedDialog.Controls.OKButton,
                    Core.Common.Constants.DefaultDialogTimeout);
                excludedDialog.ClickOK();
                Utilities.LogMessage(currentMethod + "(...) :: Waiting for dialog to close");
                CoreManager.MomConsole.WaitForDialogClose(excludedDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
            }
            else
            {
                Utilities.LogMessage(currentMethod + "(...):: There is no item to be removed");
                throw new Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException(currentMethod + "(...):: There is no item to be removed");
                
            }

            #endregion

        }
        
        /// <summary>
        /// ExcludeObjects - This method invokes the Object Exclusion dialog and performs actions on it.
        /// It closes the dialog when actions are done.
        /// </summary>
        public void ExcludeObjects()
        {
            Utilities.LogMessage("GroupsUI.ExcludeObjects(...)");
            Utilities.LogMessage("GroupsUI.ExcludeObjects :: Object Exclusion dialog Launched from Excluded Members page.");

            try
            {
                // Set Object Category dropdown
                //ExcludeObjectDialog.SearchForText = GroupParams.ObjectCategory;
                //Utilities.LogMessage("GroupsUI.ExcludeObjects :: Set the Object Category as: " + GroupParams.ObjectCategory);
                
                // Set Object Category dropdown
                if (GroupParams.ExcludeObjectCategory != "")
                {
                    ExcludeObjectDialog.SearchForText = GroupParams.ExcludeObjectCategory;
                    Utilities.LogMessage("GroupsUI.ExcludeObjects :: Set the Object Category as: " + GroupParams.ExcludeObjectCategory);
                }

                else
                {
                    ExcludeObjectDialog.SearchForText = GroupParams.ObjectCategory;
                    Utilities.LogMessage("GroupsUI.ExcludeObjects :: Set the Object Category as: " + GroupParams.ObjectCategory);
                }
                
                // Make sure the UI is ready
                ExcludeObjectDialog.ScreenElement.WaitForReady();
                Utilities.LogMessage("GroupsUI.ExcludeObjects :: WaitForUIObjectReady returned after Set Object Category");

                if (ExcludeObjectDialog.SearchForText == Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDSystemLibraryMP, ManagementPackConstants.SystemEntityName))
                {
                    // When search category is "Object", there are more than 1000 items present if we don't filter the search, this takes too much time, so we need to filter here
                    ExcludeObjectDialog.FilterByPartOfNameOptionalText = "Spooler";
                }

                // Click Search button
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(ExcludeObjectDialog.Controls.SearchButton, Core.Common.Constants.DefaultDialogTimeout);
                ExcludeObjectDialog.ClickSearch();
                Utilities.LogMessage("GroupsUI.ExcludeObjects : ExcludeObjectDialog - Search button clicked");

                // Make sure the UI is ready
                ExcludeObjectDialog.ScreenElement.WaitForReady();
                Utilities.LogMessage("GroupsUI.ExcludeObjects :: WaitForUIObjectReady returned after Click Search button");

                // Perform Add/Remove
                int nCount = ExcludeObjectDialog.Controls.AvailableItemsListView.Count;
                Utilities.LogMessage("GroupsUI.ExcludeObjects : ExcludeObjectDialog - Available Item Count: " + nCount);

                int retry = 0;
                int maxtries = 30;

                //Add retry logic to make sure the item in the list view is ready
                while (nCount == 0 && retry < maxtries)
                {
                    Sleeper.Delay(Core.Common.Constants.OneSecond);
                    nCount = ExcludeObjectDialog.Controls.AvailableItemsListView.Count;
                    Utilities.LogMessage("GroupsUI.ExcludeObjects : ExcludeObjectDialog - Available Item Count: " + nCount);
                    retry++;
                }

                if (nCount > 0)
                {
                    
                    //if (GroupParams.ObjectCategory == "Entity") //It's going to select only the "Spooler" Object -because of bug #65021
                    if (ExcludeObjectDialog.SearchForText == Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDSystemLibraryMP, ManagementPackConstants.SystemEntityName)) //It's going to select only the "Spooler" Object -because of bug #65021
                    {
                        // First selecting Spooler item 
                        Utilities.LogMessage("GroupsUI.ExcludeObjects : ExcludeObjectDialog - Select Spooler item");
                        Mom.Test.UI.Core.Console.MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;
                        int nCol = viewGrid.GetColumnTitlePosition(Strings.GroupColumnName);
                        Utilities.LogMessage("GroupsUI.ExcludeObjects :: The column position is:" + nCol.ToString());
                        CoreManager.MomConsole.SelectListViewItems("Spooler", nCol, this.ExcludeObjectDialog.Controls.AvailableItemsListView, false);
                        
                        // Make sure the UI is ready
                        ExcludeObjectDialog.ScreenElement.WaitForReady();
                        Utilities.LogMessage("GroupsUI.ExcludeObjects :: WaitForUIObjectReady returned after SelectSpooler");
                        nCount = 1; // Only Spooler is selected. 

                    }
                    else // Select all available Items
                    {

                        Utilities.LogMessage("GroupsUI.ExcludeObjects : ExcludeObjectDialog - Select all available items");
                        ExcludeObjectDialog.Controls.AvailableItemsListView.SelectAll();

                        // Make sure the UI is ready
                        ExcludeObjectDialog.ScreenElement.WaitForReady();
                        Utilities.LogMessage("GroupsUI.ExcludeObjects :: WaitForUIObjectReady returned after SelectAll");

                    }
                    // Click Add button
                    Utilities.LogMessage("GroupsUI.ExcludeObjects : ExcludeObjectDialog - Click Add button");
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
                        ExcludeObjectDialog.Controls.AddButton,
                        Core.Common.Constants.DefaultDialogTimeout);
                    ExcludeObjectDialog.ClickAdd();

                    // Make sure the UI is ready
                    ExcludeObjectDialog.ScreenElement.WaitForReady();
                    Utilities.LogMessage("GroupsUI.ExcludeObjects :: WaitForUIObjectReady returned after Click Add button");

                    int nAddedCount = ExcludeObjectDialog.Controls.SelectedObjectsListView.Count;
                    Utilities.LogMessage("GroupsUI.ExcludeObjects : ExcludeObjectDialog - Added item count: " + nAddedCount);
                    if (nAddedCount == nCount)
                    {
                        // If more than one item, remove last item
                        //if (nAddedCount > 1)
                        //{
                        //    // Select last item
                        //    Utilities.LogMessage("GroupsUI.ExcludeObjects : ExcludeObjectDialog - Remove last item added");
                        //    ExcludeObjectDialog.Controls.SelectedObjectsListView.Items[nAddedCount - 1].Select();

                        //    // Make sure the UI is ready
                        //    UISynchronization.WaitForUIObjectReady(ExcludeObjectDialog, Constants.DefaultDialogTimeout);
                        //    Sleeper.Delay(nOneSecond * 2);
                        //    Utilities.LogMessage("GroupsUI.ExcludeObjects :: WaitForUIObjectReady returned after Select last item");

                        //    // Click Remove button
                        //    Utilities.LogMessage("GroupsUI.ExcludeObjects : ExcludeObjectDialog - Click Add button");
                        //    ExcludeObjectDialog.ClickRemove();

                        //    // Make sure the UI is ready
                        //    UISynchronization.WaitForUIObjectReady(ExcludeObjectDialog, Constants.DefaultDialogTimeout);
                        //    Sleeper.Delay(nOneSecond * 2);
                        //    Utilities.LogMessage("GroupsUI.ExcludeObjects :: WaitForUIObjectReady returned after Click Remove button");

                        //    // Verify that Remove button works properly
                        //    Utilities.LogMessage("GroupsUI.ExcludeObjects : ExcludeObjectDialog - Verify Remove works");
                        //    int nSelectedCount = ExcludeObjectDialog.Controls.SelectedObjectsListView.Count;
                        //    if (nSelectedCount == nAddedCount - 1)
                        //    {
                        //        Utilities.LogMessage("GroupsUI.ExcludeObjects : ExcludeObjectDialog - " +
                        //                             "Selected Item Count after remove last item: " + nSelectedCount);
                        //        // Populate ExcludedObjects ArrayList
                        //        GroupParams.ExcludedObjects.Clear();
                        //        foreach (ListViewItem item in ExcludeObjectDialog.Controls.SelectedObjectsListView.Items)
                        //        {
                        //            GroupParams.ExcludedObjects.Add(item.Text);
                        //        }

                        //        // Close the dialog
                        //        ExcludeObjectDialog.ClickOK();
                        //    }
                        //    else
                        //    {
                        //        // Remove button doesn't work properly
                        //        ExcludeObjectDialog.ClickCancel();
                        //        throw new VarAbort("GroupsUI.ExcludeObjects : ExcludeObjectDialog - " +
                        //                           "Remove button doesn't remove correct number of items");
                        //    }
                        //}
                        //else // Only 1 item selected, don't do remove
                        //{
                        // Populate ExcludedObjects ArrayList
                        GroupParams.ExcludedObjects.Clear();
                        foreach (ListViewItem item in ExcludeObjectDialog.Controls.SelectedObjectsListView.Items)
                        {
                            GroupParams.ExcludedObjects.Add(item.Text);
                        }

                        // Close the dialog
                        CoreManager.MomConsole.Waiters.WaitForButtonEnabled(
                            ExcludeObjectDialog.Controls.OKButton,
                            Core.Common.Constants.DefaultDialogTimeout);
                        ExcludeObjectDialog.ClickOK();
                        Utilities.LogMessage("&&&&&&&&&&&&&& Waiting for dialog to close &&&&&&&&&&&&&&&");
                        CoreManager.MomConsole.WaitForDialogClose(ExcludeObjectDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
                        //}
                    }
                    else
                    {
                        // Add button doesn't work properly
                        ExcludeObjectDialog.ClickCancel();
                        CoreManager.MomConsole.WaitForDialogClose(ExcludeObjectDialog, Constants.DefaultDialogTimeout / Constants.OneSecond);
                        throw new ApplicationException("GroupsUI.ExcludeObjects : ExcludeObjectDialog - " +
                                           "Add button doesn't add correct number of items");
                    }
                }
                else
                {
                    // Nothing to add, cancel the dialog
                    Utilities.LogMessage("GroupsUI.ExcludeObjects : ExcludeObjectDialog - " +
                                         "There is no available items to add");
                    ExcludeObjectDialog.ClickCancel();
                }
            }
            catch (Exception ex)
            {
                Utilities.LogMessage("GroupsUI.ExcludeObjects :: Exception: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// DeleteGroupWithMatchingName - This method deletes the Group with sGroupName from the View panel.
        /// </summary>
        /// <param name='sGroupName'>
        /// Name of the Group to be deleted.
        /// </param>
        public void DeleteGroupWithMatchingName(string sGroupName)
        {
            // Should be in Groups view already
            Utilities.LogMessage("GroupsUI.DeleteGroupWithMatchingName(...)");

            try
            {
                // Make sure the grid control in Groups view is ready
                CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();
                Utilities.LogMessage("DeleteGroup :: WaitForUIObjectReady returned.");

                // Search and select the Group item with matching name
                bool bFound = GetGroupWithMatchingName(sGroupName);

                if (bFound)
                {
                    //Get Reference to Actions Pane and click the Delete link.
                    ActionsPane actionsPane = CoreManager.MomConsole.ActionsPane;
                    string sGroupPath = NavigationPane.Strings.MonitoringConfiguration + Constants.PathDelimiter +
                                        NavigationPane.Strings.MonConfigTreeViewGroups;
                    actionsPane.ClickLink(NavigationPane.WunderBarButton.MonitoringConfiguration, sGroupPath,
                                          ActionsPane.Strings.ActionsPaneGroup, ActionsPane.Strings.ActionsPaneDeleteGroup);
                    Utilities.LogMessage("GroupsUI.DeleteGroupWithMatchingName :: Delete Group link clicked.");

                    // Handle the confirmation dialog
                    DeleteGroupConfirmationDialog deleteDialog = new DeleteGroupConfirmationDialog(CoreManager.MomConsole);
                    deleteDialog.ScreenElement.WaitForReady();
                    deleteDialog.Extended.SetFocus();
                    deleteDialog.ClickYes();
                    CoreManager.MomConsole.WaitForDialogClose(deleteDialog, Core.Common.Constants.DefaultDialogTimeout / Constants.OneSecond);
                }
            }
            catch (Exception ex)
            {
                Utilities.LogMessage("GroupsUI.DeleteGroupWithMatchingName :: Exception: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// GetGroupWithMatchingName - This method searches the View panel for the Group named sGroupName.
        /// </summary>
        /// <param name='sGroupName'>
        /// Name of the Group to be searched.
        /// </param>
        /// <returns>
        /// (True/False) True if found, otherwise False.
        /// </returns>
        public bool GetGroupWithMatchingName(string sGroupName)
        {

            consoleApp.Waiters.WaitUntilCursorType(Maui.Core.NativeMethods.MouseCursorType.Arrow, 120);

            // Should be in Groups view already
            bool bFound = false;
            Utilities.LogMessage("GroupsUI.GetGroupWithMatchingName(...)");

            try
            {
                // Create instance of the Group view Grid Control
                GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;

                if (viewGrid == null)
                {
                    Utilities.LogMessage("GroupsUI.GetGroupWithMatchingName :: viewGrid not found.");
                    return false;
                }

                Utilities.LogMessage("GroupsUI.GetGroupWithMatchingName :: viewGrid found, select Group with matching name.");

                // Get the Index position of the ColumnName of "Name"                    
                int nCol = viewGrid.GetColumnTitlePosition(Strings.GroupColumnName);
                Utilities.LogMessage("GroupsUI.GetGroupWithMatchingName :: Succeed in GetColumnTitlePosition.");

                // Calculating the index position of the row where user role name match is found
                int nRow = 0;
                //int count = 0;
                int numberOfTries = 0;
                const int MaxTries = 5;
                while (bFound != true && numberOfTries < MaxTries)
                {
                    Utilities.LogMessage("GroupsUI.GetGroupWithMatchingName:: Attempt Number to find Group" + numberOfTries);
                    numberOfTries++;

                    //For every attempt, the row needs to be reset. 
                    nRow = 0;
                    foreach (DataGridViewRow row in viewGrid.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (String.Compare(cell.GetValue(), sGroupName, false) == 0)
                            {
                                bFound = true;
                                //Utilities.LogMessage("GroupsUI.GetGroupWithMatchingName:: The group was found!!!!!");
                                break;
                            }
                        }
                        if (bFound)
                        {
                            //Utilities.LogMessage("GroupsUI.GetGroupWithMatchingName:: The group was found!!!!!");
                            break;
                        }
                        nRow++;
                    }
                    Sleeper.Delay(Core.Common.Constants.OneSecond * 2);
                    Utilities.LogMessage("Sleeping 2 seconds ....");
                }

                if (bFound)
                {
                    Utilities.LogMessage("GroupsUI.GetGroupWithMatchingName :: Name column index: " + nCol);
                    Utilities.LogMessage("GroupsUI.GetGroupWithMatchingName :: Matching row index: " + nRow);
                    Utilities.LogMessage("GroupsUI.GetGroupWithMatchingName :: Name cell value: " + viewGrid.GetCellValue(nRow, nCol));

                    // Select the matching item
                    viewGrid.ClickCell(nRow, nCol);
                    Utilities.LogMessage("GroupsUI.GetGroupWithMatchingName :: succeed in clicking cell");
                }
                else
                {
                    Utilities.LogMessage("GroupsUI.GetGroupWithMatchingName :: Match not found in Groups view grid");
                }
            }
            catch (ActiveAccessibility.Exceptions.CantSelectElementException)
            {
                Utilities.LogMessage("GroupsUI.GetGroupWithMatchingName :: Failed to click the cell in Groups view grid");
                throw;
            }
            catch (Exception ex)
            {
                Utilities.LogMessage("GroupsUI.GetGroupWithMatchingName :: Exception: " + ex.Message);
                throw;
            }

            return bFound;
        }

        /// <summary>
        /// VerifyGroupExist - This method searches the View panel only once for the Group named sGroupName.
        /// </summary>
        /// <param name='sGroupName'>
        /// Name of the Group to be searched.
        /// </param>
        /// <returns>
        /// (True/False) True if found, otherwise False.
        /// </returns>
        public bool VerifyGroupExist(string sGroupName)
        {
            // Should be in Groups view already
            bool bFound = false;
            Utilities.LogMessage("GroupsUI.VerifyGroupExist(...)");

            try
            {
                // Create instance of the Group view Grid Control
                GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;

                if (viewGrid == null)
                {
                    Utilities.LogMessage("GroupsUI.VerifyGroupExist :: viewGrid not found.");
                    return false;
                }

                Utilities.LogMessage("GroupsUI.VerifyGroupExist :: viewGrid found, select Group with matching name.");

                // Get the Index position of the ColumnName of "Name"                    
                int nCol = viewGrid.GetColumnTitlePosition(Strings.GroupColumnName);
                Utilities.LogMessage("GroupsUI.VerifyGroupExist :: Succeed in GetColumnTitlePosition.");

                // Calculating the index position of the row where user role name match is found
                int nRow = 0;

                foreach (DataGridViewRow row in viewGrid.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (String.Compare(cell.GetValue(), sGroupName, false) == 0)
                        {
                            bFound = true;
                            break;
                        }
                    }
                    if (bFound)
                    {
                        break;
                    }
                    nRow++;
                }

                if (bFound)
                {
                    Utilities.LogMessage("GroupsUI.VerifyGroupExist :: Name column index: " + nCol);
                    Utilities.LogMessage("GroupsUI.VerifyGroupExist :: Matching row index: " + nRow);
                    Utilities.LogMessage("GroupsUI.VerifyGroupExist :: Name cell value: " + viewGrid.GetCellValue(nRow, nCol));
                }
                else
                {
                    Utilities.LogMessage("GroupsUI.VerifyGroupExist :: Match not found in Groups view grid");
                }
            }
            catch (Exception ex)
            {
                Utilities.LogMessage("GroupsUI.VerifyGroupExist :: Exception: " + ex.Message);
                throw;
            }

            return bFound;
        }

        #endregion // Public Methods

        #region Private Methods


        #endregion // Private Methods

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class with methods that return translated resource string for Groups
        /// </summary>
        /// <history> 	
        ///   [HainingW]  09Mar06: Created.
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Resource Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for the Create Group Wizard dialog title.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWizardTitle = ";Create Group Wizard;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal." + 
                "UI.Authoring.Views.Group.GroupResources;CreateGroupWizardCaption";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for the Object Selection dialog title.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceObjectSelectionDialogTitle = @";Create Group Wizard - Object Selection;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ObjectPickerDialog;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for the Object Exclusion dialog title.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceObjectExclusionDialogTitle = ";Create Group Wizard - Object Exclusion;" +
                "ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI." +
                "Authoring.Pages.ExclusionPickerDialog;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for the Group Selection dialog title.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGroupSelectionDialogTitle = @";Create Group Wizard - Group Selection;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.GroupPickerDialog;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for the Group Column Name in Groups View.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGroupColumnName = @";Name;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.GroupsView.GroupsResources;GroupNameColumn";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for the Explicit members tab.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExplicitTabName = ";Explicit Members;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.InstancesPage;$this.TabName";
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for the Dynamic members tab.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDynamicTabName = ";Dynamic Members;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MembershipFormulaPage;$this.TabName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for the Subgroup tab
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSubgroupTabName = ";Subgroups;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SubgroupsPage;$this.TabName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for the Excluded mebmers tab.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExcludedTabName = ";Excluded Members;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ExcludedMembersPage;$this.TabName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for the View Group members context menu.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewGroupMembersItem = ";View Group Members...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.GroupsView.GroupsResources;GroupViewMembersContextMenuTask";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for the View Group State context menu.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewGroupStateItem = ";View Grou&p State...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.GroupsView.GroupsResources;ViewStateContextMenuTask";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for the View Diagram context menu.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewDiagramItem = ";View &Diagram...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.GroupsView.GroupsResources;ViewDiagramContextMenuTask";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for the View Managed Objects Title.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewManagedObjectsTitle = ";Managed Objects;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.ManagedObjectView.ManagedObjectViewResource;ViewTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for the View Group State Title.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewGroupStateTitle = ";State;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.StateResources;State";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Resource string for the View Diagram Title.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewDiagramTitle = ";Diagram View;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramViewResources;DiagramView";

            /// <summary>
            /// Resource string for the formula grid property column name
            /// </summary>
            private const string ResourcePropertyColumnName = ";Property;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Group.GroupResources;lhsColumnText";
            
            #endregion // Resource Constants

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the wizard title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWizardTitle = null;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the Object Selection Dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjectSelectionDialogTitle = null;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the Object Exclusion Dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjectExclusionDialogTitle = null;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the Group Selection Dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGroupSelectionDialogTitle = null;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the Group Column Name in Groups View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGroupColumnName = null;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Explicit members tab
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExplicitTabName = null;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Dynamic members tab
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDynamicTabName = null;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Subgroup tab
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSubgroupTabName = null;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Excluded members tab
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExcludedTabName = null;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for View Group members context menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewGroupMembersItem = null;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for View Group State context menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewGroupStateItem = null;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for View Diagram context menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewDiagramItem = null;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the View Managed Ojbects title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewManagedObjectsTitle = null;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the View Group State title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewGroupStateTitle = null;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for View Diagram title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewDiagramTitle = null;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for formula grid property column name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPropertyColumnName = null;

            #endregion // Private Members

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WizardTitle translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string WizardTitle
            {
                get
                {
                    if (cachedWizardTitle == null)
                    {
                        cachedWizardTitle = CoreManager.MomConsole.GetIntlStr(ResourceWizardTitle);
                    }

                    return cachedWizardTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ObjectSelectionDialogTitle translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string ObjectSelectionDialogTitle
            {
                get
                {
                    if (cachedObjectSelectionDialogTitle == null)
                    {
                        cachedObjectSelectionDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceObjectSelectionDialogTitle);
                    }

                    return cachedObjectSelectionDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ObjectExclusionDialogTitle translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string ObjectExclusionDialogTitle
            {
                get
                {
                    if (cachedObjectExclusionDialogTitle == null)
                    {
                        cachedObjectExclusionDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceObjectExclusionDialogTitle);
                    }

                    return cachedObjectExclusionDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GroupSelectionDialogTitle translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string GroupSelectionDialogTitle
            {
                get
                {
                    if (cachedGroupSelectionDialogTitle == null)
                    {
                        cachedGroupSelectionDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceGroupSelectionDialogTitle);
                    }

                    return cachedGroupSelectionDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GroupColumnName (in Groups View) translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string GroupColumnName
            {
                get
                {
                    if (cachedGroupColumnName == null)
                    {
                        cachedGroupColumnName = CoreManager.MomConsole.GetIntlStr(ResourceGroupColumnName);
                    }

                    return cachedGroupColumnName;
                }
            }


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExplicitTabName translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string ExplicitTabName
            {
                get
                {
                    if (cachedExplicitTabName == null)
                    {
                        cachedExplicitTabName = CoreManager.MomConsole.GetIntlStr(ResourceExplicitTabName);
                    }

                    return cachedExplicitTabName;
                }
            }


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DynamicTabName translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string DynamicTabName
            {
                get
                {
                    if (cachedDynamicTabName == null)
                    {
                        cachedDynamicTabName = CoreManager.MomConsole.GetIntlStr(ResourceDynamicTabName);
                    }

                    return cachedDynamicTabName;
                }
            }


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SubgroupTabName translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string SubgroupTabName
            {
                get
                {
                    if (cachedSubgroupTabName == null)
                    {
                        cachedSubgroupTabName = CoreManager.MomConsole.GetIntlStr(ResourceSubgroupTabName);
                    }

                    return cachedSubgroupTabName;
                }
            }


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExcludedTabName translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string ExcludedTabName
            {
                get
                {
                    if (cachedExcludedTabName == null)
                    {
                        cachedExcludedTabName = CoreManager.MomConsole.GetIntlStr(ResourceExcludedTabName);
                    }

                    return cachedExcludedTabName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the View Groups Members Item translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string ViewGroupMembersItem
            {
                get
                {
                    if (cachedViewGroupMembersItem == null)
                    {
                        cachedViewGroupMembersItem = CoreManager.MomConsole.GetIntlStr(ResourceViewGroupMembersItem);
                    }

                    return cachedViewGroupMembersItem;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the View Groups State Item translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string ViewGroupStateItem
            {
                get
                {
                    if (cachedViewGroupStateItem == null)
                    {
                        cachedViewGroupStateItem = CoreManager.MomConsole.GetIntlStr(ResourceViewGroupStateItem);
                    }

                    return cachedViewGroupStateItem;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the View Groups Diagram Item translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string ViewDiagramItem
            {
                get
                {
                    if (cachedViewDiagramItem == null)
                    {
                        cachedViewDiagramItem = CoreManager.MomConsole.GetIntlStr(ResourceViewDiagramItem);
                    }

                    return cachedViewDiagramItem;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the View Managed Objects Title translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string ViewManagedObjectsTitle
            {
                get
                {
                    if (cachedViewManagedObjectsTitle == null)
                    {
                        cachedViewManagedObjectsTitle = CoreManager.MomConsole.GetIntlStr(ResourceViewManagedObjectsTitle);
                    }

                    return cachedViewManagedObjectsTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the View Groups State Title translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string ViewGroupStateTitle
            {
                get
                {
                    if (cachedViewGroupStateTitle == null)
                    {
                        cachedViewGroupStateTitle = CoreManager.MomConsole.GetIntlStr(ResourceViewGroupStateTitle);
                    }

                    return cachedViewGroupStateTitle;
                }
            }


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the View Groups Diagram Title translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string ViewGroupDiagramTitle
            {
                get
                {
                    if (cachedViewDiagramTitle == null)
                    {
                        cachedViewDiagramTitle = CoreManager.MomConsole.GetIntlStr(ResourceViewDiagramTitle);
                    }

                    return cachedViewDiagramTitle;
                }
            }


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the formula grid propety column name translated resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string PropertyColumnName
            {
                get
                {
                    if (cachedPropertyColumnName == null)
                    {
                        cachedPropertyColumnName = CoreManager.MomConsole.GetIntlStr(ResourcePropertyColumnName);
                    }

                    return cachedPropertyColumnName;
                }
            }

            #endregion // Properties
        }


        #endregion // Strings Class

        #region GroupParameters Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class that defines Group parameters.
        /// </summary>
        /// <history>
        ///   [HainingW]  09Mar06: Created.
        /// </history>
        /// -----------------------------------------------------------------------------
        /// 
        public class GroupParameters
        {
            #region Private Members

            /// <summary>
            /// Cached Group Name
            /// </summary>
            private string sCachedName = string.Empty;

            /// <summary>
            /// Cached Group Description
            /// </summary>
            private string sCachedDesc = string.Empty;

            /// <summary>
            /// Object Category name as shown in the Object Picker dialog dropdown list
            /// </summary>
            private string sObjectCategory = string.Empty;

            /// <summary>
            /// Query Class name as shown in the Query Builder dialog dropdown list
            /// </summary>
            private string sQueryClass = string.Empty;

            /// <summary>
            /// Query Host Class name as shown in the Query Builder dialog dropdown list
            /// </summary>
            private string sQueryHostClass = string.Empty;

            /// <summary>
            /// Query Property as shown in the Query Builder dialog grid control
            /// </summary>
            private string sQueryProperty = string.Empty;

            /// <summary>
            /// Query Operator as shown in the Query Builder dialog grid control
            /// </summary>
            private string sQueryOperator = string.Empty;

            /// <summary>
            /// Query Value as shown in the Query Builder dialog grid control
            /// </summary>
            private string sQueryValue = string.Empty;

            /// <summary>
            /// Subgroup search filter string used in Group Selection dialog
            /// </summary>
            private string sSubgroupFilter = string.Empty;

            /// <summary>
            /// New management pack to be imported for special cases
            /// </summary>
            private string sNewManagementPack = string.Empty;

            /// <summary>
            /// Exclude ojbect search filter string used in Exclude Selection dialog
            /// </summary>
            private string sExcludeObjectCategory = string.Empty;

            /// <summary>
            /// Create Group Mode
            /// </summary>
            private ActionMode enCreateMode = ActionMode.ActionsLink;

            /// <summary>
            /// Delete Group Mode
            /// </summary>
            private ActionMode enDeleteMode = ActionMode.ActionsLink;

            /// <summary>
            /// View Group Member Mode
            /// </summary>
            private ActionMode enViewMemberMode = ActionMode.ActionsLink;

            /// <summary>
            /// The array of object names added through Object Selection dialog
            /// </summary>
            private ArrayList aGroupMembers = new ArrayList();

            /// <summary>
            /// The Query Formula string set through Query Builder dialog
            /// </summary>
            private string sQueryFormula = string.Empty;

            /// <summary>
            /// The array of subgroup names added through Group Selection dialog
            /// </summary>
            private ArrayList aSubgroups = new ArrayList();

            /// <summary>
            /// The array of excluded object names added through Object Exclusion dialog
            /// </summary>
            private ArrayList aExcludedObjects = new ArrayList();

            #endregion // Private Members

            #region Constructor

            /// <summary>
            /// Default Constructor
            /// </summary>
            public GroupParameters()
            {
            }

            #endregion // Constructor

            #region Properties

            /// <summary>
            /// Name of Group
            /// </summary>
            public string Name
            {
                get { return sCachedName;  }
                set { sCachedName = value; }
            }

            /// <summary>
            /// Description of Group
            /// </summary>
            public string Description
            {
                get { return sCachedDesc;  }
                set { sCachedDesc = value; }
            }

            /// <summary>
            /// Object Category in Object Picker dialog
            /// </summary>
            public string ObjectCategory
            {
                get { return sObjectCategory; }
                set { sObjectCategory = value; }
            }

            /// <summary>
            /// Query Class in Query Builder dialog
            /// </summary>
            public string QueryClass
            {
                get { return sQueryClass; }
                set { sQueryClass = value; }
            }

            /// <summary>
            /// Query Host Class in Query Builder dialog
            /// </summary>
            public string QueryHostClass
            {
                get { return sQueryHostClass; }
                set { sQueryHostClass = value; }
            }

            /// <summary>
            /// Query Property in Query Builder dialog grid control
            /// </summary>
            public string QueryProperty
            {
                get { return sQueryProperty; }
                set { sQueryProperty = value; }
            }

            /// <summary>
            /// Query Operator in Query Builder dialog grid control
            /// </summary>
            public string QueryOperator
            {
                get { return sQueryOperator; }
                set { sQueryOperator = value; }
            }

            /// <summary>
            /// Query Value in Query Builder dialog grid control
            /// </summary>
            public string QueryValue
            {
                get { return sQueryValue; }
                set { sQueryValue = value; }
            }

            /// <summary>
            /// Subgroup search filter string in Group Selection dialog
            /// </summary>
            public string SubgroupFilter
            {
                get { return sSubgroupFilter; }
                set { sSubgroupFilter = value; }
            }

            /// <summary>
            /// Exclude object search filter string in Exclude Selection dialog
            /// </summary>
            public string ExcludeObjectCategory
            {
                get { return sExcludeObjectCategory; }
                set { sExcludeObjectCategory = value; }
            }

            /// <summary>
            /// New Management pack to be imported for special cases
            /// </summary>
            public string NewManagementPack
            {
                get { return sNewManagementPack; }
                set { sNewManagementPack = value; }
            }

            /// <summary>
            /// Create Group Mode
            /// </summary>
            public ActionMode CreateMode
            {
                get { return enCreateMode; }
                set { enCreateMode = value; }
            }

            /// <summary>
            /// Delete Group Mode
            /// </summary>
            public ActionMode DeleteMode
            {
                get { return enDeleteMode; }
                set { enDeleteMode = value; }
            }

            /// <summary>
            /// View Group Member Mode
            /// </summary>
            public ActionMode ViewMemberMode
            {
                get { return enViewMemberMode; }
                set { enViewMemberMode = value; }
            }

            /// <summary>
            /// The array of object names added through Object Selection dialog
            /// This property is read only
            /// </summary>
            public ArrayList GroupMembers
            {
                get { return aGroupMembers; }
            }

            /// <summary>
            /// The Query Formula string set through Query Builder dialog
            /// </summary>
            public string QueryFormula
            {
                get { return sQueryFormula; }
                set { sQueryFormula = value; }
            }

            /// <summary>
            /// The array of subgroup names added through Group Selection dialog
            /// This property is read only
            /// </summary>
            public ArrayList Subgroups
            {
                get { return aSubgroups; }
            }

            /// <summary>
            /// The array of excluded object names added through Object Exclusion dialog
            /// This property is read only
            /// </summary>
            public ArrayList ExcludedObjects
            {
                get { return aExcludedObjects; }
            }

            #endregion // Properties
        }

        #endregion // GroupParameters Class
    }
}