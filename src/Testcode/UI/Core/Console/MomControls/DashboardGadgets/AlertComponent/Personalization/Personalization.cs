//  -----------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Personalization.cs">
//     Copyright ?Microsoft 2005
// </copyright>
// <project>
//     Mom.Test.UI.Core.Console.Personalization
// </project>
// <summary>
//     A class containing Personalization test code utility functions.
// </summary>
// <history>
//   [v-lileo] 9/27/2010 Created
// </history>
//  -----------------------------------------------------------------------


namespace Mom.Test.UI.Core.Console.MomControls.DashboardGadgets.AlertComponent.Personalization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MomControls.DashboardControls;

    /// <summary>
    /// Helper methods for Personalization.
    /// </summary>
    public class Personalization
    {
        #region Private Members
        /// <summary>
        /// Get updatePersonalizationDialog
        /// </summary>
        private AlertPersonalizationDialog cachedupdatePersonalizationDialog;
        private string DialogTitle;
        public AlertPersonalizationDialog updatePersonalizationDialog
        {
            get
            {
                cachedupdatePersonalizationDialog = new AlertPersonalizationDialog(this.consoleApp, Constants.DefaultDialogTimeout, DialogTitle);
                return cachedupdatePersonalizationDialog;
            }
        }

        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp;
        #endregion

        #region Constructor

        /// <summary>
        /// Personalization
        /// </summary>
        public Personalization(String wizardTitle)
        {
            this.consoleApp = CoreManager.MomConsole;
            DialogTitle = wizardTitle;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Method to Update Alerts view Personalization
        /// </summary>
        /// <param name="DisplayColumnsName">List string for show columns in alert Name</param>
        /// <param name="ColumnsDisplayIndex">Columns Position where to sort in Alerts view</param>
        /// <param name="ShowAllColumnsToDisplay">bool if ture, select all columns to display</param>
        /// <param name="sortColumnsName">List string for show columns in sort view</param>
        /// <param name="ColumnsSortIndex">Columns Position where to sort in sort view</param>
        /// <param name="SortType">List RadioGroup type to should sort columns by Ascending or Descending</param>
        /// <param name="GroupColumnsName">List string for show columns in group view</param>
        /// <param name="ColumnsGroupIndex">Columns Position where to sort in Group view</param>
        /// <param name="GroupType">List RadioGroup type to show group columns by Ascending or Descending</param>
        public void updatePersonalization(List<string> DisplayColumnsName, List<int> ColumnsDisplayIndex, bool ShowAllColumnsToDisplay, bool NeedUpdateSortBy, List<string> sortColumnsName, List<int> ColumnsSortIndex, List<string> SortType, bool NeedUpdateGroupBy, List<string> GroupColumnsName, List<int> ColumnsGroupIndex, List<string> GroupType)
        {
            this.updatePersonalization(true, DisplayColumnsName, ColumnsDisplayIndex, ShowAllColumnsToDisplay, NeedUpdateSortBy, sortColumnsName, ColumnsSortIndex, SortType, NeedUpdateGroupBy, GroupColumnsName, ColumnsGroupIndex, GroupType); 
        }

        /// <summary>
        /// Method to Update Alerts view Personalization, add a new parameter as a flag to determine whether or not to launch the Personalize dialog
        /// </summary>
        /// <param name="launchedDialog">bool if true, launch the Personalize dialog</param>
        /// <param name="DisplayColumnsName">List string for show columns in alert Name</param>
        /// <param name="ColumnsDisplayIndex">Columns Position where to sort in Alerts view</param>
        /// <param name="ShowAllColumnsToDisplay">bool if ture, select all columns to display</param>
        /// <param name="NeedUpdateSortBy">bool if true, update the SortBy config</param>
        /// <param name="sortColumnsName">List string for show columns in sort view</param>
        /// <param name="ColumnsSortIndex">Columns Position where to sort in sort view</param>
        /// <param name="SortType">List RadioGroup type to should sort columns by Ascending or Descending</param>
        /// <param name="NeedUpdateGroupBy">bool if true, update the GroupBy config</param>
        /// <param name="GroupColumnsName">List string for show columns in group view</param>
        /// <param name="ColumnsGroupIndex">Columns Position where to sort in Group view</param>
        /// <param name="GroupType">List RadioGroup type to show group columns by Ascending or Descending</param>
        public void updatePersonalization(bool launchDialog, List<string> DisplayColumnsName, List<int> ColumnsDisplayIndex, bool ShowAllColumnsToDisplay, bool NeedUpdateSortBy, List<string> sortColumnsName, List<int> ColumnsSortIndex, List<string> SortType, bool NeedUpdateGroupBy, List<string> GroupColumnsName, List<int> ColumnsGroupIndex, List<string> GroupType)
        {
            Utilities.LogMessage("updatePersonlization:: updatePersonlization...");

            if (launchDialog)
            {
                this.LaunchPersonalizationDialog();
            }

            if (DisplayColumnsName != null || ShowAllColumnsToDisplay == true)
            {
                this.UpdateDisplayColumns(DisplayColumnsName, ColumnsDisplayIndex, ShowAllColumnsToDisplay);
            }

            if (NeedUpdateSortBy)
            {
                this.UpdateSortByColumns(sortColumnsName, ColumnsSortIndex, SortType);
            }

            if (NeedUpdateGroupBy)
            {
                this.UpdateGroupByColumns(GroupColumnsName, ColumnsGroupIndex, GroupType);
            }

            this.updatePersonalizationDialog.ClickCreate();
            CoreManager.MomConsole.WaitForDialogClose(this.updatePersonalizationDialog, Constants.OneMinute / 1000);
        }

        /// <summary>
        /// The method to Luanch Personalization Dialog
        /// </summary>
        public void LaunchPersonalizationDialog()
        {
            Utilities.LogMessage("LuanchPersonalizationDialog:: LuanchPersonalizationDialog...");

            //Button PersonalizationButton = new Button(CoreManager.MomConsole.ViewPane, new QID(";[UIA]Name='Personalize'"));
            Button PersonalizationButton = null;
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    PersonalizationButton = new Button(CoreManager.MomConsole.ViewPane, new QID(";[UIA]AutomationId='button'"));
                    break;
                case ProductSkuLevel.Web:
                    PersonalizationButton = new Button(CoreManager.MomConsole.MainWindow, new QID(";[UIA]AutomationId='button'"));
                    break;
                default:
                    break;
            } 

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(PersonalizationButton, Constants.DefaultContextMenuTimeout);
            PersonalizationButton.Click();
            CoreManager.MomConsole.ExecuteDashboardContextMenu(MomControls.DashboardControls.Strings.Personalize);
            Sleeper.Delay(2000);
            CoreManager.MomConsole.Waiters.WaitForReady();
        }

        #region taks display columns
        /// <summary>
        /// The method to update Display Columns
        /// </summary>
        /// <param name="DisplayColumnsName">List string for show columns Display Name</param>
        /// <param name="ColumnsDisplayIndex">Columns Position where to sort in display view</param>
        /// <param name="ShowAllColumnsToDisplay">bool if ture, select all columns to display</param>
        public void UpdateDisplayColumns(List<string> DisplayColumnsName,List<int>ColumnsDisplayIndex, bool ShowAllColumnsToDisplay)
        {
            Utilities.LogMessage("UpdateDisplayColumns:: UpdateDisplayColumns...");            
            
            if (ShowAllColumnsToDisplay == true)
            {
                Utilities.LogMessage("UpdateDisplayColumns:: Show all Columns to Display...");
                updatePersonalizationDialog.ClickColumnsToDisplay();
                updatePersonalizationDialog.WaitForResponse();
            }
            else
            {
                if (DisplayColumnsName.Count < 1)
                {
                    Utilities.LogMessage("UpdateDisplayColumns:: At least have one columns to display");
                    throw new Exception("UpdateDisplayColumns:: At least have one columns to display");
                }
                if (DisplayColumnsName.Count > updatePersonalizationDialog.Controls.ColumnsDisplayListView.Items.Count)
                {
                    Utilities.LogMessage("UpdateDisplayColumns:: DisplayColumnsName count is not greater than Columns Display List View items ");
                    throw new Exception("UpdateDisplayColumns:: DisplayColumnsName count is not greater than Columns Display List View items");
                }                

                for (int i = 0; i < DisplayColumnsName.Count; i++)
                {
                    bool ItemFound = false;                    
                    foreach (ListViewItem item in updatePersonalizationDialog.Controls.ColumnsDisplayListView.Items)
                    {
                        string listItemName = GetColumnListItemName(item);

                        if (listItemName == DisplayColumnsName[i])
                        {
                            Utilities.LogMessage("UpdateDisplayColumns: Found the column " + DisplayColumnsName[i]);
                            ItemFound = true;
                            if (item.Checked)
                            {
                                Utilities.LogMessage("UpdateDisplayColumns:: the Column Name: " + DisplayColumnsName[i] + " has been selected, Ignore it");                                
                            }
                            else
                            {
                                Utilities.LogMessage("UpdateDisplayColumns:: Selecting the Column name: " + DisplayColumnsName[i]);
                                item.Checked = true;
                                Utilities.LogMessage("UpdateDisplayColumns:: Selected the Column name: " + DisplayColumnsName[i]);
                            }
                        }
                        else
                        {
                            //Hide the Invalid column from Display view
                            if (item.Checked && !DisplayColumnsName.Contains(listItemName))
                            {
                                Utilities.LogMessage("UpdateDisplayColumns:: Hide the Invalid column: " + listItemName + " from Display view");                                
                                item.Checked = false;
                            }
                        }                        
                    }
                    if (ItemFound == false)
                    {
                        Utilities.LogMessage("UpdateDisplayColumns:: Columns Display list view does not contain " + DisplayColumnsName[i].ToString());
                        throw new Exception("UpdateDisplayColumns:: Columns Display list view does not contain " + DisplayColumnsName[i].ToString());
                    }
                }
            }
            if (ColumnsDisplayIndex != null)
            {
                for (int i = 0; i < DisplayColumnsName.Count; i++)
                {
                    this.UpdateColumnsDisplayOrder(DisplayColumnsName[i], ColumnsDisplayIndex[i]);
                }
            }  
        }

        /// <summary>
        /// Method to update columns display order
        /// </summary>
        /// <param name="columnName">string for show column Name</param>
        /// <param name="index">Column Position where to sort in display view</param>
        public void UpdateColumnsDisplayOrder(string columnName, int index )
        {
            Utilities.LogMessage("UpdateColumnsDisplayOrder:: UpdateColumnsDisplayOrder...");

            if (index > updatePersonalizationDialog.Controls.ColumnsDisplayListView.Count || columnName ==null)
            {
                Utilities.LogMessage("UpdateColumnsDisplayOrder:: The index " + index + "out of List View count" + updatePersonalizationDialog.Controls.ColumnsDisplayListView.Count);
                throw new IndexOutOfRangeException("UpdateColumnsDisplayOrder:: The index " + index + "out of List View count" + updatePersonalizationDialog.Controls.ColumnsDisplayListView.Count);
            }
            else
            {
                if (index == -1)
                {
                    Utilities.LogMessage("UpdateColumnsDisplayOrder:: The column doesn't need to change sort");
                }
                else
                {                    
                    bool itemFound =false;
                    updatePersonalizationDialog.Controls.ColumnsDisplayListView.Click();
                    foreach (ListViewItem item in updatePersonalizationDialog.Controls.ColumnsDisplayListView.Items)
                    {
                        string listItemName = GetColumnListItemName(item);

                        if (columnName == listItemName)
                        {
                            Utilities.LogMessage("UpdateColumnsDisplayOrder:: Found the column "+ columnName);
                            itemFound = true;
                            item.Select();
                            if (item.Index >= index)
                            {
                                for (int i = 0; i < item.Index - index + 1; i++)
                                {
                                    updatePersonalizationDialog.ClickColumnsDisplayMoveUp();
                                }
                            }
                            else
                            {
                                for (int i = 0; i < index - item.Index - 1; i++)
                                {
                                    updatePersonalizationDialog.ClickColumnsDisplayMoveDown();
                                }
                            }
                            break;
                        }                        
                    }
                    if(itemFound ==false)
                    {
                        Utilities.LogMessage("UpdateColumnsDisplayOrder:: Can not found the cloumn : " + columnName);
                         throw new Exception("UpdateColumnsDisplayOrder:: Can not found the cloumn : " + columnName);
                    }                    
                }
            }
        }

        /// <summary>
        /// Method to Show column in Alert view Throw Show Button
        /// </summary>
        /// <param name="columnName">string for show column Name</param>
        public void ShowColumnToDisplay(string ColumnName)
        {
            if (ColumnName != null)
            {
                bool ItemFound = false;
                foreach (ListViewItem item in updatePersonalizationDialog.Controls.ColumnsDisplayListView.Items)
                {
                    string listItemName = GetColumnListItemName(item);
                    if(listItemName == ColumnName)
                    {
                        Utilities.LogMessage("ShowColumnToDisplay: Found the column " + ColumnName);
                        ItemFound = true;
                        if (item.Checked)
                        {
                            Utilities.LogMessage("ShowColumnToDisplay:: the Column Name: " + ColumnName + " has been selected, Ignore it");
                        }
                        else
                        {
                            Utilities.LogMessage("ShowColumnToDisplay:: Selecting the Column name: " + ColumnName);
                            item.Select();
                            //CoreManager.MomConsole.Waiters.WaitForButtonEnabled(updatePersonalizationDialog.Controls.ColumnsDisplayShowButton, Constants.OneMinute / 1000);
                            //updatePersonalizationDialog.ClickColumnsDisplayShow();
                            item.Checked = true;
                            Utilities.LogMessage("ShowColumnToDisplay:: Selected the Column name: " + ColumnName);
                        }
                        break;
                    }
                }
                if (ItemFound == false)
                {
                    Utilities.LogMessage("ShowColumnToDisplay:: Columns Display list view does not contain " + ColumnName);
                    throw new Exception("ShowColumnToDisplay:: Columns Display list view does not contain " + ColumnName);
                }
            }
        }
        /// <summary>
        /// Method to Hide column in Alert view
        /// </summary>
        /// <param name="columnName">string for hide column Name</param>
        public void HideColumnToDisplay(string ColumnName)
        {
            if (ColumnName != null)
            {
                bool ItemFound = false;
                foreach (ListViewItem item in updatePersonalizationDialog.Controls.ColumnsDisplayListView.Items)
                {
                    string listItemName = GetColumnListItemName(item);
                    if(listItemName == ColumnName)
                    {
                        Utilities.LogMessage("HideColumnToDisplay: Found the column " + ColumnName);
                        ItemFound = true;
                        if (item.Checked)
                        {
                            Utilities.LogMessage("HideColumnToDisplay:: Hiding the Column name: " + ColumnName);
                            item.Select();
                            //CoreManager.MomConsole.Waiters.WaitForButtonEnabled(updatePersonalizationDialog.Controls.ColumnsDisplayHideButton,Constants.OneMinute/1000);
                            //updatePersonalizationDialog.ClickColumnsDisplayHide();
                            item.Checked = false;
                            Utilities.LogMessage("HideColumnToDisplay:: the Column Name: " + ColumnName + " has been hided");
                        }
                        else
                        {
                            Utilities.LogMessage("HideColumnToDisplay:: the Column Name: " + ColumnName + " has been hided, ingnore it");
                        }
                        break;
                    }
                }
                if (ItemFound == false)
                {
                    Utilities.LogMessage("HideColumnToDisplay:: Columns Display list view does not contain " + ColumnName);
                    throw new Exception("HideColumnToDisplay:: Columns Display list view does not contain " + ColumnName);
                }
            }
        }
        
        #endregion

        #region Take Columns to sort by
        /// <summary>
        /// Method to update sort by columns in alert view
        /// </summary>
        /// <param name="sortColumnsName">List string for sort column name</param>
        /// <param name="ColumnsSortIndex">Column Position where to sort in sort view</param>
        /// <param name="SortType">List RadioGroup type to should sort columns by Ascending or Descending</param>
        public void UpdateSortByColumns(List<string> sortColumnsName, List<int> ColumnsSortIndex, List<string> SortType)
        {
            Utilities.LogMessage("UpdateSortByColumns:: UpdateSortByColumns..."); 
            if (sortColumnsName.Count > 3)
            {
                Utilities.LogMessage("SortColumns:: Can not sort columns greater than 3 columns");
                throw new Exception("SortColumns:: Can not sort columns greater than 3 columns");
            }
            if (sortColumnsName.Count == 0)
            {
                Utilities.LogMessage("SortColumns:: None columns need sort");
                if (updatePersonalizationDialog.Controls.SortByListView.Items.Count != 0)
                {
                    Utilities.LogMessage("Removing all of items in sort by list view");
                    foreach (ListViewItem item in updatePersonalizationDialog.Controls.SortByListView.Items)
                    {
                        item.Select();
                        updatePersonalizationDialog.ClickSortByRemove();
                        updatePersonalizationDialog.WaitForResponse();
                    }
                    Utilities.LogMessage("SortColumns:: Removed the Column from List view");
                }
            }
            else
            {
                List<string> sortNames = new List<string>();
                foreach (string sortName in sortColumnsName)
                {
                    sortNames.Add(sortName);
                }
                //Remove Column from Group by list if the column in group by list
                foreach (var item in updatePersonalizationDialog.Controls.GroupByListView.Items)
                {
                    MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]AutomationId='userControl'", null);
                    if (sortNames.Contains(listItem[0].Name))
                    {
                        item.Select();
                        updatePersonalizationDialog.ClickGroupByRemove();
                    }
                }
                //Verify items in sort List view, don't need add the column from display view if the column in sort list view
                // and remove Invalid columns from sort list view
                foreach (ListViewItem item in updatePersonalizationDialog.Controls.SortByListView.Items)
                {
                    MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]AutomationId='userControl'", null);
                    if (sortNames.Contains(listItem[0].Name))
                    {
                        Utilities.LogMessage("SortByColumns:: the Colunm name " + listItem[0].Name + " has been in Sort List view, ignore it");
                        sortNames.Remove(listItem[0].Name);
                    }
                    else
                    {
                        Utilities.LogMessage("SortByColumns:: Should remove the column " + listItem[0].Name + " from the sort list view");
                        item.Select();
                        updatePersonalizationDialog.ClickSortByRemove();
                    }
                }
                for (int i = 0; i < sortNames.Count; i++)
                {
                    bool itemFound = false;
                    foreach (ListViewItem item in updatePersonalizationDialog.Controls.ColumnsDisplayListView.Items)
                    {
                        string listItemName = GetColumnListItemName(item);
                        if(listItemName  == sortNames[i])
                        {
                            itemFound = true;
                            item.Select();
                            if (!item.Checked)
                            {
                                //updatePersonalizationDialog.ClickColumnsDisplayShow();
                                item.Checked = true;
                            }
                            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(updatePersonalizationDialog.Controls.SortByButton, Constants.OneMinute / 1000);
                            updatePersonalizationDialog.ClickSortBy();
                            break;
                        }
                    }
                    if (itemFound == false)
                    {
                        Utilities.LogMessage("UpdateSortByColumns:: Can not found the cloumn : " + sortNames[i]);
                        throw new Exception("UpdateSortByColumns:: Can not found the cloumn : " + sortNames[i]);
                    }
                }
            }
            if(ColumnsSortIndex!=null)
            {
                for(int i=0; i<ColumnsSortIndex.Count;i++)
                {
                    this.UpdateSortColumnsOrder(sortColumnsName[i], ColumnsSortIndex[i], SortType[i]);
                }
            }
        }

        /// <summary>
        /// Method to udpate sort columns order in alerts view
        /// </summary>
        /// <param name="sortColumnName">string for sort column name</param>
        /// <param name="index">Column Position where to sort in sort view</param>
        /// <param name="RadioType">RadioGroup type to should sort column by Ascending or Descending</param>
        public void  UpdateSortColumnsOrder(string sortColumnName, int index, string RadioType)
        {
            Utilities.LogMessage("UpdateSortColumnsOrder:: UpdateSortColumnsOrder...");
            if (index > updatePersonalizationDialog.Controls.SortByListView.Count || sortColumnName == null)
            {
                Utilities.LogMessage("UpdateColumnsDisplayOrder:: The index " + index + "out of List View count" + updatePersonalizationDialog.Controls.SortByListView.Count);
                throw new IndexOutOfRangeException("UpdateColumnsDisplayOrder:: The index " + index + "out of List View count" + updatePersonalizationDialog.Controls.SortByListView.Count);
            }
            else
            {
                bool itemFound = false;
                foreach (ListViewItem item in updatePersonalizationDialog.Controls.SortByListView.Items)
                {
                    MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]AutomationId='userControl'", null);
                    if (listItem[0].Name == sortColumnName)
                    {
                        Utilities.LogMessage("Found the column Name " + listItem[0].Name);
                        itemFound = true;
                        item.Click();
                        switch (RadioType)
                        {
                            case "Ascending":
                                updatePersonalizationDialog.SortByRadioGroup = RadioGroup.Ascending;
                                break;
                            case "Descending":
                                updatePersonalizationDialog.SortByRadioGroup = RadioGroup.Descending;
                                break;
                            default:
                                updatePersonalizationDialog.SortByRadioGroup = RadioGroup.Ascending;
                                break;
                        }
                        if (index != -1)
                        {
                            item.Click();
                            Utilities.LogMessage("Updating the Column Name: " + listItem[0].Name + "Order in sort by listView");
                            if (item.Index >= index)
                            {                                
                                for (int i = 0; i < item.Index - index+1; i++)
                                {
                                    updatePersonalizationDialog.ClickSortByMoveUp();
                                }
                            }
                            else
                            {
                                for (int i = 0; i < index - item.Index-1; i++)
                                {
                                    updatePersonalizationDialog.ClickSortByMoveDown();
                                }
                            }
                            Utilities.LogMessage("Updated the Column Name: " + listItem[0].Name + "Order in sort by listView");
                        }
                        else
                        {
                            Utilities.LogMessage("UpdateSortColumnsOrder:: The column doesn't need to change sort, ignore it");
                        }
                        break;
                    }
                }
                if (itemFound == false)
                {
                    Utilities.LogMessage("UpdateSortColumnsOrder:: Can not found the column: " + sortColumnName + "In Sort view");
                    throw new Exception("UpdateSortColumnsOrder:: Can not found the column: " + sortColumnName + "In sort view"); 
                }
            }
        }

        /// <summary>
        /// Method to add column to by sort
        /// </summary>
        /// <param name="SortColumnName">string for sort column name</param>
        public void AddColumnToSortBy(string SortColumnName)
        {
            Utilities.LogMessage("AddColumnToSortBy:: AddColumnToSortBy...");
            //Remove item from Group by
            foreach (var item in updatePersonalizationDialog.Controls.GroupByListView.Items)
            {
                MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]AutomationId='userControl'", null);
                if (listItem[0].Name == SortColumnName)
                {
                    item.Select();
                    updatePersonalizationDialog.ClickGroupByRemove();
                    break;
                }
            }
            bool itemInSortBy = false;
            foreach (ListViewItem item in updatePersonalizationDialog.Controls.SortByListView.Items)
            {
                MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]AutomationId='userControl'", null);
                if (listItem[0].Name == SortColumnName)
                {
                    itemInSortBy = true;
                    Utilities.LogMessage("SortByColumns:: the Colunm name " + listItem[0].Name + " has been in Sort List view, ignore it");
                    break;
                }
            }
            //Remove first item if the sort by list have 3 items
            if (updatePersonalizationDialog.Controls.SortByListView.Items.Count == 3)
            {
                updatePersonalizationDialog.Controls.SortByListView.Items[0].Select();
                updatePersonalizationDialog.ClickSortByRemove();
            }
            if (!itemInSortBy)
            {
                bool itemFound = false;
                foreach (ListViewItem item in updatePersonalizationDialog.Controls.ColumnsDisplayListView.Items)
                {
                    string listItemName = GetColumnListItemName(item);
                    if(listItemName == SortColumnName)
                    {
                        itemFound = true;
                        item.Select();
                        this.updatePersonalizationDialog.ClickSortBy();
                        break;
                    }
                }
                if (itemFound == false)
                {
                    Utilities.LogMessage("AddColumnToSortBy:: Can not found the column: " + SortColumnName + "In Display view");
                    throw new Exception("AddColumnToSortBy:: Can not found the column: " + SortColumnName + "In Display view");
                }
            }
        }

        /// <summary>
        /// Method to remove column to by sort
        /// </summary>
        /// <param name="SortColumnName">tring for sort column name</param>
        public void RemoveSortByColumn(string SortColumnName)
        {
            Utilities.LogMessage("RemoveSortByColumn:: RemoveSortByColumn...");
            bool itemFound = false;
            foreach (ListViewItem item in updatePersonalizationDialog.Controls.SortByListView.Items)
            {
                MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]AutomationId='userControl'", null);
                if (listItem[0].Name == SortColumnName)
                {
                    itemFound = true;
                    item.Select();
                    this.updatePersonalizationDialog.ClickSortByRemove();
                    break;
                }
            }
            if (itemFound == false)
            {
                Utilities.LogMessage("RemoveSortByColumn:: Can not found the column: " + SortColumnName + "In Display view");
                throw new Exception("RemoveSortByColumn:: Can not found the column: " + SortColumnName + "In Display view");
            }            
        }

        #endregion

        #region Take Columns to Group by
        /// <summary>
        /// Method to update Columns Group by in alerts view
        /// </summary>
        /// <param name="GroupColumnsName">List string for show columns in group view</param>
        /// <param name="ColumnsGroupIndex">Columns Position where to sort in Group view</param>
        /// <param name="GroupType">List RadioGroup type to show group columns by Ascending or Descending</param>
        public void UpdateGroupByColumns(List<string> GroupColumnsName, List<int> ColumnsGroupIndex, List<string> GroupType)
        {
            Utilities.LogMessage("UpdateGroupByColumns:: UpdateGroupByColumns...");
            Utilities.LogMessage("UpdateGroupByColumns:: GroupColumnsName count is " + GroupColumnsName.Count);
            if (GroupColumnsName.Count > 3)
            {
                Utilities.LogMessage("UpdateGroupByColumns:: Can not Group columns greater than 3 columns");
                throw new Exception("UpdateGroupByColumns:: Can not Group columns greater than 3 columns");
            }
            if (GroupColumnsName.Count == 0)
            {
                Utilities.LogMessage("UpdateGroupByColumns:: None columns need sort");
                if (updatePersonalizationDialog.Controls.GroupByListView.Items != null)
                {
                    Utilities.LogMessage("UpdateGroupByColumns:: Remove all of items in sort by list view");
                    foreach (ListViewItem item in updatePersonalizationDialog.Controls.GroupByListView.Items)
                    {
                        Utilities.LogMessage("UpdateGroupByColumns:: Removing the Column from Group List view");
                        item.Select();
                        updatePersonalizationDialog.ClickGroupByRemove();
                        updatePersonalizationDialog.WaitForResponse();
                        Utilities.LogMessage("UpdateGroupByColumns:: Removed the Column from Group List view");
                    }
                }
            }
            else
            {
                List<string> GroupNames = new List<string>();
                foreach (string groupName in GroupColumnsName)
                {
                    GroupNames.Add(groupName);
                }
                //Remove Column from List by list if the column in Sort by list
                foreach (ListViewItem item in updatePersonalizationDialog.Controls.SortByListView.Items)
                {
                    MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]AutomationId='userControl'", null);
                    if (GroupColumnsName.Contains(listItem[0].Name))
                    {
                        item.Select();
                        updatePersonalizationDialog.ClickSortByRemove();
                    }
                }
                foreach (ListViewItem item in updatePersonalizationDialog.Controls.GroupByListView.Items)
                {
                    MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]AutomationId='userControl'", null);
                    if (GroupNames.Contains(listItem[0].Name))
                    {
                        Utilities.LogMessage("UpdateGroupByColumns:: the Colunm name " + listItem[0].Name + " has been in Sort List view, ignore it");
                        GroupNames.Remove(listItem[0].Name);
                    }
                    else
                    {
                        Utilities.LogMessage("UpdateGroupByColumns:: Should remove the column " + listItem[0].Name + " from the Group list view");
                        item.Select();
                        updatePersonalizationDialog.ClickGroupByRemove();
                    }
                }
                for (int i = 0; i < GroupNames.Count; i++)                    
                {
                    bool itemFound = false;
                    foreach (ListViewItem item in updatePersonalizationDialog.Controls.ColumnsDisplayListView.Items)
                    {
                        string listItemName = GetColumnListItemName(item);
                        if (listItemName == GroupNames[i])
                        {
                            itemFound = true;
                            item.Select();
                            if (item.Checked == false)
                            {
                                //updatePersonalizationDialog.ClickColumnsDisplayShow();
                                item.Checked = true;
                            }
                            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(updatePersonalizationDialog.Controls.GroupByButton, Constants.OneMinute / 1000);
                            updatePersonalizationDialog.ClickGroupBy();
                            break;
                        }
                    }
                    if (itemFound == false)
                    {
                        Utilities.LogMessage("UpdateSortByColumns:: Can not found the cloumn : " + GroupNames[i]);
                        throw new Exception("UpdateSortByColumns:: Can not found the cloumn : " + GroupNames[i]);
                    }
                }
            }
            if (ColumnsGroupIndex != null)
            {
                for (int i = 0; i < ColumnsGroupIndex.Count;i++)
                {
                    this.UpdateGroupColumnsOrder(GroupColumnsName[i], ColumnsGroupIndex[i], GroupType[i]);
                }
            }            
        }

        /// <summary>
        /// Method to Update Group columns order in alerts view
        /// </summary>
        /// <param name="GroupColumnsName">string for Group column name</param>
        /// <param name="index">Column Position where to sort in Group view</param>
        /// <param name="RadioType">RadioGroup type to should Group column by Ascending or Descending</param>
        public void UpdateGroupColumnsOrder(string GroupColumnName, int index, string RadioType)
        {
            Utilities.LogMessage("UpdateGroupColumnsOrder:: UpdateGroupColumnsOrder...");
            if (index > updatePersonalizationDialog.Controls.GroupByListView.Count || GroupColumnName == null)
            {
                Utilities.LogMessage("UpdateColumnsDisplayOrder:: The index " + index + "out of Group View count" + updatePersonalizationDialog.Controls.GroupByListView.Count);
                throw new IndexOutOfRangeException("UpdateColumnsDisplayOrder:: The index " + index + "out of List View count" + updatePersonalizationDialog.Controls.GroupByListView.Count);
            }
            else
            {
                //ListViewItem column = updatePersonalizationDialog.Controls.GroupByListView.FindSingleItem(GroupColumnName, true, true, true, 1);
                bool itemFound = false;
                foreach (ListViewItem item in updatePersonalizationDialog.Controls.GroupByListView.Items)
                {
                    MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]AutomationId='userControl'", null);
                    if (listItem[0].Name == GroupColumnName)
                    {
                        itemFound = true;
                        item.Select();
                        switch (RadioType)
                        {
                            case "Ascending":
                                updatePersonalizationDialog.GroupByRadioGroup = RadioGroup.Ascending;
                                break;

                            case "Descending":
                                updatePersonalizationDialog.GroupByRadioGroup = RadioGroup.Descending;
                                break;

                            default:
                                updatePersonalizationDialog.GroupByRadioGroup = RadioGroup.Ascending;
                                break;
                        }
                        if (index != -1)
                        {
                            item.Select();
                            if (item.Index >= index)
                            {
                                for (int i = 0; i < item.Index - index+1; i++)
                                {
                                    updatePersonalizationDialog.ClickGroupByMoveUp();
                                }
                            }
                            else
                            {
                                for (int i = 0; i < index - item.Index-1; i++)
                                {
                                    updatePersonalizationDialog.ClickGroupByMoveDown();
                                }
                            }
                        }
                        else
                        {
                            Utilities.LogMessage("UpdateGroupColumnsOrder:: The column doesn't need to change sort,ignore it");
                        }
                        break;
                    }
                }
                if(itemFound==false)
                {
                    Utilities.LogMessage("AddColumnToGroupBy:: Can not found the column: " + GroupColumnName + "In Group view");
                    throw new Exception("AddColumnToGroupBy:: Can not found the column: " + GroupColumnName + "In Group view");
                }
            }
        }

        /// <summary>
        /// Method to add column to by group
        /// </summary>
        /// <param name="GroupColumnName">string for Group column name</param>
        public void AddColumnToGroupBy(string GroupColumnName)
        {
            Utilities.LogMessage("AddColumnToGroupBy:: AddColumnToGroupBy...");

            foreach (ListViewItem item in updatePersonalizationDialog.Controls.SortByListView.Items)
            {
                MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]AutomationId='userControl'", null);
                if (listItem[0].Name ==GroupColumnName)
                {
                    item.Select();
                    updatePersonalizationDialog.ClickSortByRemove();
                    break;
                }
            }
            bool itemInGroup = false;
            foreach (ListViewItem item in updatePersonalizationDialog.Controls.GroupByListView.Items)
            {
                MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]AutomationId='userControl'", null);
                if (listItem[0].Name == GroupColumnName)
                {
                    itemInGroup = true;
                    Utilities.LogMessage("UpdateGroupByColumns:: the Colunm name " + listItem[0].Name + " has been in Sort List view, ignore it");
                    break;
                }
            }
            if (updatePersonalizationDialog.Controls.GroupByListView.Items.Count == 3)
            {
                updatePersonalizationDialog.Controls.GroupByListView.Items[0].Select();
                updatePersonalizationDialog.ClickGroupByRemove();
            }
            if (!itemInGroup)
            {
                bool itemFound = false;
                foreach (ListViewItem item in updatePersonalizationDialog.Controls.ColumnsDisplayListView.Items)
                {
                    string listItemName = GetColumnListItemName(item);
                    if(listItemName == GroupColumnName)
                    {
                        itemFound = true;
                        item.Select();
                        this.updatePersonalizationDialog.ClickGroupBy();
                        break;
                    }
                }
                if (itemFound == false)
                {
                    Utilities.LogMessage("AddColumnToSortBy:: Can not found the column: " + GroupColumnName + "In Display view");
                    throw new Exception("AddColumnToSortBy:: Can not found the column: " + GroupColumnName + "In Display view");
                }
            }
        }

        /// <summary>
        /// Method to Remove column to by group
        /// </summary>
        /// <param name="GroupColumnName">string for Group column name</param>
        public void RemoveGroupByColumn(string GroupColumnName)
        {
            Utilities.LogMessage("RemoveGroupByColumn:: RemoveGroupByColumn...");
            bool itemFound = false;
            foreach (ListViewItem item in updatePersonalizationDialog.Controls.GroupByListView.Items)
            {
                MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]AutomationId='userControl'", null);
                if (listItem[0].Name == GroupColumnName)
                {
                    itemFound = true;
                    item.Select();
                    this.updatePersonalizationDialog.ClickGroupByRemove();
                    break;
                }
            }
            if (itemFound == false)
            {
                Utilities.LogMessage("RemoveGroupByColumn:: Can not found the column: " + GroupColumnName + "In Display view");
                throw new Exception("RemoveGroupByColumn:: Can not found the column: " + GroupColumnName + "In Display view");
            }
        }
        #endregion

        /// <summary>
        /// Method to Verify Personalization settings
        /// </summary>
        /// <param name="DisplayColumnsName">List string for show columns in alert Name</param>
        /// <param name="ColumnsDisplayIndex">Columns Position where to sort in display view</param>
        /// <param name="ShowAllColumnsToDisplay">bool if ture, select all columns to display</param>
        /// <param name="NeedUpdateSortBy">bool if true, update the SortBy config</param>
        /// <param name="SortColumnsName">List string for show columns in sort view</param>
        /// <param name="ColumnsSortIndex">Columns Position where to sort in sort view</param>
        /// <param name="SortType">List RadioGroup type to should sort columns by Ascending or Descending</param>
        /// <param name="NeedUpdateGroupBy">bool if true, update the GroupBy config</param>
        /// <param name="GroupColumnsName">List string for show columns in group view</param>
        /// <param name="ColumnsGroupIndex">Columns Position where to sort in Group view</param>
        /// <param name="GroupType">List RadioGroup type to show group columns by Ascending or Descending</param>
        public bool VerifyPersonalizationSetting(List<string> DisplayColumnsName, List<int> ColumnsDisplayIndex, bool ShowAllColumnsToDisplay, bool NeedUpdateSortBy, List<string> SortColumnsName, List<int> ColumnsSortIndex, List<string> SortType, bool NeedUpdateGroupBy, List<string> GroupColumnsName, List<int> ColumnsGroupIndex, List<string> GroupType)
        {
            Utilities.LogMessage("VerifyPersonalizationSetting::...");
            //this.LaunchPersonalizationDialog();
            bool result = false;
            if (DisplayColumnsName != null || ShowAllColumnsToDisplay != false)
            {
                result = this.VerifyColumnsDisplaySettings(DisplayColumnsName, ColumnsDisplayIndex, ShowAllColumnsToDisplay);
                if (!result)
                {
                    return result;
                }
            }
            if (NeedUpdateSortBy == true)
            {
                result = this.VerifyColumnsSortBySettings(SortColumnsName, ColumnsSortIndex, SortType);
                if (!result)
                {
                    return result;
                }
            }
            if (NeedUpdateGroupBy == true)
            {
               result = this.VerifyColumnsGroupBySettings(GroupColumnsName, ColumnsGroupIndex, GroupType);
               if (!result)
               {
                   return result;
               }
            }
            //updatePersonalizationDialog.ClickCreate();
            updatePersonalizationDialog.ClickCancel();
            CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.OK, 
                                                       ConsoleApp.Strings.CancelWizardDialogTitle, 
                                                       StringMatchSyntax.WildCard, 
                                                       MomConsoleApp.ActionIfWindowNotFound.Ignore);
            return result;
        }

        /// <summary>
        /// Verify columns diaplay settings in Personalization dialog
        /// </summary>
        /// <param name="DisplayColumnsName">List string for show columns in alert Name</param>
        /// <param name="ColumnsDisplayIndex">Columns Position where to sort in display view</param>
        /// <param name="ShowAllColumnsToDisplay">bool if ture, select all columns to display</param>
        public bool VerifyColumnsDisplaySettings(List<string> DisplayColumnsName, List<int> ColumnsDisplayIndex, bool ShowAllColumnsToDisplay)
        {
            Utilities.LogMessage("VerifyColumnsDisplaySettings::...");
            if(ShowAllColumnsToDisplay == true)
            {
                foreach(ListViewItem item in updatePersonalizationDialog.Controls.ColumnsDisplayListView.Items)
                {
                    if(!item.Checked)
                    {
                        Utilities.LogMessage("VerifyColumnsDisplaySettings:: The Item did not selected, return false");
                        return false;
                    }
                }
            }
            else
            {
                if(DisplayColumnsName.Count <1)
                {
                    Utilities.LogMessage("VerifyColumnsDisplaySettings:: Display Columns can not empty, return false");
                    return false;
                }
                if (DisplayColumnsName.Count > updatePersonalizationDialog.Controls.ColumnsDisplayListView.Items.Count)
                {
                    Utilities.LogMessage("VerifyColumnsDisplaySettings:: Display Columns count out of List view items Count, return false");
                    return false;
                }
                for (int i = 0; i < DisplayColumnsName.Count; i++)
                {
                    bool ItemFound = false;
                    int ItemIndex = 0;
                    foreach (ListViewItem item in updatePersonalizationDialog.Controls.ColumnsDisplayListView.Items)
                    {
                        ItemIndex++;
                        Utilities.LogMessage("VerifyColumnsDisplaySettings:: item.Index is " + item.Index);
                        string listItemName = GetColumnListItemName(item);
                        if (listItemName == DisplayColumnsName[i])
                        {                           
                            Utilities.LogMessage("VerifyColumnsDisplaySettings: Found the column " + DisplayColumnsName[i]);                            
                            ItemFound = true;    
                            if(!item.Checked)
                            {
                                Utilities.LogMessage("VerifyColumnsDisplaySettings:: The item did not selected, return false");
                                return false;
                            }

                            Utilities.LogMessage("VerifyColumnsDisplaySettings: ColumnDisplay Index ");
                            if (ColumnsDisplayIndex!= null)
                            {
                                if (ItemIndex != ColumnsDisplayIndex[i])
                                {
                                    Utilities.LogMessage("VerifyColumnsDisplaySettings:: The columns index is: " + ItemIndex + " in personzalization window, expect index is: " + ColumnsDisplayIndex[i] + ", return false");
                                    return false;
                                }
                            }
                            Utilities.LogMessage("VerifyColumnsDisplaySettings: Success, coutinue the next item ");
                        }
                        else if (item.Checked && !DisplayColumnsName.Contains(listItemName))
                        {
                            Utilities.LogMessage("VerifyColumnsDisplaySettings:: The item should not be selected, return false");
                            return false;
                        }
                    }
                    if (ItemFound == false)
                    {
                        Utilities.LogMessage("VerifyColumnsDisplaySettings:: Columns Display list view does not contain " + DisplayColumnsName[i].ToString());
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Verify Columns sort by settings in Personalization dialog
        /// </summary>
        /// <param name="SortColumnsName">List string for show columns in sort view</param>
        /// <param name="ColumnsSortIndex">Columns Position where to sort in sort view</param>
        /// <param name="SortType">List RadioGroup type to should sort columns by Ascending or Descending</param>
        public bool VerifyColumnsSortBySettings(List<string> SortColumnsName, List<int> ColumnsSortIndex, List<string> SortType)
        {
            Utilities.LogMessage("VerifyColumnsSortBySettings::...");
            if (SortColumnsName.Count > 3)
            {
                Utilities.LogMessage("VerifyColumnsSortBySettings:: out of count in sort by list view, just only allow 3 columns limit in sort by, return false");
                return false;
            }
            if (SortColumnsName.Count!= updatePersonalizationDialog.Controls.SortByListView.Items.Count)
            {
                Utilities.LogMessage("VerifyColumnsSortBySettings:: update Sort columns and Sort by items count do not match");
                return false;
            }
            //Verify SortColumnsName
            for (int i = 0; i < SortColumnsName.Count; i++)
            {
                bool ItemFound = false;
                foreach (ListViewItem item in updatePersonalizationDialog.Controls.SortByListView.Items)
                {
                    MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]AutomationId='userControl'", null);
                    if (SortColumnsName[i] == listItem[0].Name)
                    {
                        Utilities.LogMessage("VerifyColumnsSortBySettings:: Found the Column name: " + SortColumnsName[i]);
                        item.Select();
                        ItemFound = true;
                        if (ColumnsSortIndex!= null)
                        {
                            if (ColumnsSortIndex[i] != -1 && ColumnsSortIndex[i] != item.Index+1)
                            {
                                Utilities.LogMessage("VerifyColumnsSortBySettings:: The column in sort by index is wrong");
                                return false;
                            }
                        }
                        if (SortType!= null)
                        {
                            string SortByType = "Ascending";
                            if (updatePersonalizationDialog.SortByRadioGroup == RadioGroup.Descending)
                            {
                                SortByType = "Descending";
                            }
                            if (SortType[i] != SortByType)
                            {
                                Utilities.LogMessage("VerifyColumnsSortBySettings:: The sort by Column sort error, should be sort by " + SortByType[i]);
                                return false;
                            }
                        }
                    }
                }
                if (ItemFound == false)
                {
                    Utilities.LogMessage("VerifyColumnsSortBySettings:: Sort By list view does not contain " + SortColumnsName[i]);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Verify Columns Group by settings in personalization dialog
        /// </summary>
        /// <param name="GroupColumnsName">List string for show columns in group view</param>
        /// <param name="ColumnsGroupIndex">Columns Position where to sort in Group view</param>
        /// <param name="GroupType">List RadioGroup type to show group columns by Ascending or Descending</param>
        public bool VerifyColumnsGroupBySettings(List<string> GroupColumnsName,List<int> ColumnsGroupIndex, List<string> GroupType)
        {
            Utilities.LogMessage("VerifyColumnsGroupBySettings::...");
            if (GroupColumnsName.Count > 3)
            {
                Utilities.LogMessage("VerifyColumnsGroupBySettings:: out of count in Group by list view, just only allow 3 columns limit in Group by, return false");
                return false;
            }
            if (GroupColumnsName.Count != updatePersonalizationDialog.Controls.GroupByListView.Items.Count)
            {
                Utilities.LogMessage("VerifyColumnsGroupBySettings:: update Group columns and Group by items count do not match");
                return false;
            }
            for (int i = 0; i < GroupColumnsName.Count; i++)
            {
                bool ItemFound = false;
                foreach (ListViewItem item in updatePersonalizationDialog.Controls.GroupByListView.Items)
                {
                    MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]AutomationId='userControl'", null);
                    if (GroupColumnsName[i] == listItem[0].Name)
                    {
                        Utilities.LogMessage("VerifyColumnsGroupBySettings:: Found The Column Name: " + GroupColumnsName[i] );
                        item.Select();
                        ItemFound = true;
                        if (ColumnsGroupIndex!= null)
                        {
                            if (ColumnsGroupIndex[i] != -1 && ColumnsGroupIndex[i] != item.Index+1)
                            {
                                Utilities.LogMessage("VerifyColumnsGroupBySettings:: The Column in Group by index is wrong");
                                return false;
                            }
                        }
                        if (GroupType != null)
                        {
                            string GroupSort = "Ascending";
                            if (updatePersonalizationDialog.GroupByRadioGroup == RadioGroup.Descending)
                            {
                                GroupSort = "Descending";
                            }
                            if (GroupType[i] != GroupSort)
                            {
                                Utilities.LogMessage("VerifyColumnsGroupBySettings:: The group by column sort error, should be sort by " + GroupType[i]);
                                return false;
                            }
                        }
                    }
                }
                if (ItemFound == false)
                {
                    Utilities.LogMessage("VerifyColumnsGroupBySettings:: Sort By list view does not contain " + GroupColumnsName[i]);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Verify Personalization settings in alert view 
        /// </summary>
        /// <param name="DisplayColumnsName">List string for show columns in alert Name</param>
        /// <param name="ShowAllColumnsToDisplay">bool if ture, select all columns to display</param>
        /// <param name="NeedUpdateSortBy">bool if true, update the SortBy config</param>
        /// <param name="SortbyColumnsName">List string for show columns in sort view</param>
        /// <param name="SortType">List RadioGroup type to should sort columns by Ascending or Descending</param>
        /// <param name="NeedUpdateGroupBy">bool if true, update the GroupBy config</param>
        /// <param name="GroupbyColumnsName">List string for show columns in group view</param>
        /// <param name="GroupType">List RadioGroup type to show group columns by Ascending or Descending</param>
        public bool VerifyPersonalizationSettingsInAlertView(List<string> DisplayColumnsName,bool ShowAllColumnsToDisplay, bool NeedUpdateSortBy, List<string> SortbyColumnsName, List<string> SortType, bool NeedUpdateGroupBy, List<string> GroupbyColumnsName, List<string> GroupType)
        {
            Utilities.LogMessage("VerifyPersonalizationSettingsInAlertView::...");
            FilterControl filter = null;
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    filter = new FilterControl(CoreManager.MomConsole.ViewPane);
                    break;
                case ProductSkuLevel.Web:
                    filter = new FilterControl(CoreManager.MomConsole.MainWindow);
                    break;
            }    
                
            if (filter.FilterTextBox.Text != "" && filter.FilterTextBox.Text != "Filter")
            {
                filter.FilterCloseButton.Click();
            }
            DataGridControl DataGrid = null;
            switch(ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    DataGrid = new DataGridControl(CoreManager.MomConsole.ViewPane, new QID(";[UIA]AutomationId='InnerDataGrid'"));
                    break;
                case ProductSkuLevel.Web:
                    DataGrid = new DataGridControl(CoreManager.MomConsole.MainWindow, new QID(";[UIA]AutomationId='silverlightDataGrid'"));
                    break;
            }           
            
            bool result = false;
            if (DisplayColumnsName != null || ShowAllColumnsToDisplay != false)
            {
                result = VerifyColumnsDisplayInAlertView(DataGrid,DisplayColumnsName, ShowAllColumnsToDisplay);
                if (!result)
                {
                    return result;
                }
            }
            
            if (NeedUpdateSortBy ==true)
            {
                result = VerifyDataGridSortingByColumnsInAlertView(DataGrid,SortbyColumnsName, SortType);
                if (!result)
                {
                    return result;
                }
            }
            if (NeedUpdateGroupBy == true)
            {
                result = VerifyColumnsGroupByInAlertView(DataGrid,GroupbyColumnsName, GroupType);
                if (!result)
                {
                    return result;
                }
            }
            return result;
        }

        /// <summary>
        /// Verify columns display in alert view acorrding to presonalization settings
        /// </summary>
        /// <param name="DataGrid">DataGridControl tpype for data grid</param>
        /// <param name="DisplayColumnsName">List string for show columns in alert Name</param>
        /// <param name="ShowAllColumnsToDisplay">bool if ture, select all columns to display</param>
        private bool VerifyColumnsDisplayInAlertView(DataGridControl DataGrid,List<string> DisplayColumnsName, bool ShowAllColumnsToDisplay)
        {
            Utilities.LogMessage("VerifyColumnsDisplayInAlertView::...");
            if (ShowAllColumnsToDisplay == true)
            {
                //Get Column headers name in Alert view
                List<string> columnHeaders = DataGrid.GetColumHeaders();
                List<string> ColumnsNameInPersonalization = new List<string>();
                //Get Columns name in Personalization Window
                this.LaunchPersonalizationDialog();

                foreach (ListViewItem item in updatePersonalizationDialog.Controls.ColumnsDisplayListView.Items)
                {
                    string listItemName = GetColumnListItemName(item);
                    ColumnsNameInPersonalization.Add(listItemName);
                }
                updatePersonalizationDialog.ClickCancel();
                CoreManager.MomConsole.ConfirmChoiceDialog(
                        MomConsoleApp.ButtonCaption.OK,
                        ConsoleApp.Strings.CancelWizardDialogTitle,
                        StringMatchSyntax.WildCard,
                        MomConsoleApp.ActionIfWindowNotFound.Ignore);

                if (columnHeaders.Count != ColumnsNameInPersonalization.Count)
                {
                    Utilities.LogMessage("VerifyColumnsDisplayInAlertView:: Display Columns count and Column headers count do not match, columnHeaders.Count is " + columnHeaders.Count + " and DisplayColumnsName.Count is " + ColumnsNameInPersonalization.Count);
                    //throw new Exception("VerifyColumnsDisplayInAlertView:: Display Columns count and Column headers count do not match" + columnHeaders.Count + " DisplayColumnsName.Count is " + ColumnsNameInPersonalization.Count);
                    return false;
                }
                for (int i = 0; i < columnHeaders.Count; i++)
                {
                    if (ColumnsNameInPersonalization[i] != columnHeaders[i])
                    {
                        Utilities.LogMessage("VerifyColumnsDisplayInAlertView:: Display Column Name " + ColumnsNameInPersonalization[i] + " does not match Column Header Name " + columnHeaders[i]);
                        return false;
                    }
                }
            }
            else if (DisplayColumnsName != null)
            {
                List<string> columnHeaders = DataGrid.GetColumHeaders();
                if (columnHeaders.Count != DisplayColumnsName.Count)
                {
                    Utilities.LogMessage("VerifyColumnsDisplayInAlertView:: Display Columns count and Column headers count do not match, columnHeaders.Count is " + columnHeaders.Count + " and DisplayColumnsName.Count is " + DisplayColumnsName.Count);
                    //throw new Exception("VerifyColumnsDisplayInAlertView:: Display Columns count and Column headers count do not match");
                    return false;
                }
                for (int i = 0; i < DisplayColumnsName.Count; i++)
                {
                    if (DisplayColumnsName[i] != columnHeaders[i])
                    {
                        Utilities.LogMessage("VerifyColumnsDisplayInAlertView:: Display Column Name " + DisplayColumnsName[i] + " does not match Column Header Name " + columnHeaders[i]);
                        //throw new Exception("VerifyColumnsDisplayInAlertView:: Display Column Name " + DisplayColumnsName[i] + " does not match Column Header Name " + columnHeaders[i]);
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Verify data grid row sorting by column in alert view according to perosonlization dialog sorting by settings
        /// </summary>
        /// <param name="DataGrid">DataGridControl tpype for data grid</param>
        /// <param name="SortbyColumnsName">List string for show columns in sort view</param>
        /// <param name="SortType">List RadioGroup type to should sort columns by Ascending or Descending</param>
        private bool VerifyDataGridSortingByColumnsInAlertView(DataGridControl DataGrid, List<string> SortbyColumnsName, List<string> SortType)
        {
            Utilities.LogMessage("VerifyColumnsSortsByInAlertView::...");
            bool result = false;
            if (SortbyColumnsName == null)
            {
                Utilities.LogMessage("VerifyColumnsSortsByInAlertView:: SortbyColumnsName is null, we don't need to verify the columns sort by");
                return true;
            }
            else
            {
                List<int> columnsIndex = new List<int>();
                for (int i = 0; i < SortbyColumnsName.Count; i++)
                {
                    columnsIndex.Add(DataGrid.GetColumnIndex(SortbyColumnsName[i]));
                }
                if (!DataGrid.HasGroups)
                {
                    Utilities.LogMessage("VerifyColumnsSortsByInAlertView:: Verify the alert rows sorting in Un-grouping alert veiw");
                    result = VerifyRowsSort(DataGrid.RowsExtended, columnsIndex, SortType);
                }
                else
                {
                    Utilities.LogMessage("VerifyColumnsSortsByInAlertView:: Verify the alert rows sorting in Grouping alert veiw");
                    DataGridGroup FirstGroup = DataGrid.FirstLevelGroups[0];
                    while (FirstGroup.HasGroups)
                    {
                        Utilities.LogMessage("VerifyColumnsSortsByInAlertView:: Group has Groups, get child group");
                        FirstGroup = FirstGroup.FirstLevelGroups[1];
                    }
                    result = VerifyRowsSort(FirstGroup.Rows(), columnsIndex, SortType);
                }
            }
            return result;
        }

        /// <summary>
        /// Verify columns Group by in alert view according to personalization dialog settings
        /// </summary>
        /// <param name="DataGrid">DataGridControl tpype for data grid</param>
        /// <param name="GroupbyColumnsName">List string for show columns in group view</param>
        /// <param name="GroupType">List RadioGroup type to show group columns by Ascending or Descending</param>
        private bool VerifyColumnsGroupByInAlertView(DataGridControl DataGrid, List<string> GroupbyColumnsName, List<string> GroupType)
        {
            Utilities.LogMessage("VerifyColumnsGroupByInAlertView::...");
            bool result = false;
            if (GroupbyColumnsName == null)
            {
                if (DataGrid.HasGroups)
                {
                    Utilities.LogMessage("VerifyColumnsGroupByInAlertView:: The Data Grid has groups not match GroupbyColumns Name");
                    return false;
                }
            }
            else
            {
                if (!DataGrid.HasGroups)
                {
                    Utilities.LogMessage("VerifyColumnsGroupByInAlertView:: The Data Grid doesn't have groups not match GroupbyColumns Name");
                    return false;
                }
                else
                {
                    //Verify all Level Group Name
                    Utilities.LogMessage("VerifyColumnsGroupByInAlertView:: Verify Alert view Groups Name and Update Groups Name");
                    result = VerifyGroupName(DataGrid, GroupbyColumnsName);
                    if (!result)
                    {
                        return result;
                    }
                    //verify Group sort
                    Utilities.LogMessage("VerifyColumnsGroupByInAlertView:: Verify the Groups columns sorting");
                    result = VerifyGroupSort(DataGrid, GroupType);
                    if (!result)
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Verify Group name in data grid control
        /// </summary>
        /// <param name="DataGrid">DataGridControl for data grid</param>
        /// <param name="GroupbyColumnsName">List string for show columns in group view</param>
        private bool VerifyGroupName(DataGridControl DataGrid, List<string> GroupbyColumnsName)
        {
            Utilities.LogMessage("VerifyGroupName::..");            
            //Get Groups Level Name
            List<string> GroupLevelNames = new List<string>();
            DataGridRowExtended firstChildGroup = DataGrid.LayeredDataGridRowExtended.Children[0];

            if (ProductSku.Sku == ProductSkuLevel.Web)
            {
                GroupLevelNames.Add(firstChildGroup.NameExtended.Split(':')[0]);
            }

            while (firstChildGroup.HasChildren)
            {
                Utilities.LogMessage("VerifyColumnsSortsByInAlertView:: Group has Groups, get child group");
                Utilities.LogMessage("VerifyGroupName:: Group's name is " + firstChildGroup.NameExtended.Split(':')[0]);
                GroupLevelNames.Add(firstChildGroup.NameExtended.Split(':')[0]);
                firstChildGroup = firstChildGroup.Children[0];
            }

            //Verify Group Names
            if (GroupbyColumnsName.Count != GroupLevelNames.Count)
            {
                Utilities.LogMessage("VerifyColumnsSortsByInAlertView:: Alert view not grouping by updated Columns");
                return false;
            }
            else
            {
                for (int i = 0; i < GroupbyColumnsName.Count; i++)
                {
                    if (GroupbyColumnsName[i] != GroupLevelNames[i])
                    {
                        Utilities.LogMessage("VerifyColumnsSortsByInAlertView:: Group Column Name error");
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Verify group sort in data grid control
        /// </summary>
        /// <param name="DataGrid">DataGridControl for data grid</param>
        /// <param name="GroupType">List<string> show group columns by Ascending or Descending</param>
        private bool VerifyGroupSort(DataGridControl DataGrid, List<string> GroupType)
        {
            Utilities.LogMessage("VerifyGroupSort::...");
            List<DataGridRowExtended> firstChildGroups = DataGrid.LayeredDataGridRowExtended.Children;
            int groupTypeIndex = 0;            
            while (firstChildGroups[0].HasChildren)
            {
                Utilities.LogMessage("");
                int curGroupIndex = -1;
                if (firstChildGroups.Count > 1)
                {
                    foreach (var dataGridGroup in firstChildGroups)
                    {
                        curGroupIndex++;
                        if (curGroupIndex == 0)
                        {
                            continue;
                        }
                        string prevGroup = firstChildGroups[curGroupIndex - 1].NameExtended;
                        string curGroup = firstChildGroups[curGroupIndex].NameExtended;
                        if ((GroupType[groupTypeIndex] == "Ascending" && string.Compare(prevGroup, curGroup) > 0) ||
                            (GroupType[groupTypeIndex] == "Descending" && string.Compare(prevGroup, curGroup) < 0))
                        {
                            Utilities.LogMessage("VerifyGroupSort:: Group Names Sorting by Error, PrevGroup value is " + prevGroup + " and curGroup value is " + curGroup);
                            return false;
                        }
                    }
                }
                firstChildGroups = firstChildGroups[0].Children;
                groupTypeIndex++;

            }
            return true;
        }

        /// <summary>
        /// Verify data rows sort in data grid control
        /// </summary>
        /// <param name="rows">DataGridRowCollectionExtended type row in data grid </param>
        /// <param name="columnsIndex">List<int>Columns Position where to sort in grid view</param>
        /// <param name="SortType">List<string> Sort columns by Ascending or Descending</param>
        public static bool VerifyRowsSort(DataGridRowCollectionExtended rows, List<int> columnsIndex, List<string> SortType)
        {
            Utilities.LogMessage("VerifyRowsSort::...");
            int curRowIndex = -1;
            foreach (var row in rows)
            {
                curRowIndex++;

                if (curRowIndex == 0)
                {
                    continue;
                }
                DataGridRow prevRow = rows[curRowIndex - 1];
                DataGridRow curRow = rows[curRowIndex];
                string prevVal=null;
                string curVal =null;
                for (int curColumnIndex = 0; curColumnIndex < columnsIndex.Count; curColumnIndex++)
                {
                    prevVal = prevRow.Cells[columnsIndex[curColumnIndex]].Name;
                    curVal = curRow.Cells[columnsIndex[curColumnIndex]].Name;
                    if ((SortType[curColumnIndex] == "Ascending" && string.Compare(prevVal, curVal) > 0) ||
                            (SortType[curColumnIndex] == "Descending" && string.Compare(prevVal, curVal) < 0))
                    {
                        Utilities.LogMessage("VerifyRowsSort:: Rows sorting by error, prevVal value is " + prevVal + " and curVal value is " + curVal);
                        //throw new Exception("VerifyRowsSort:: Rows sorting by error");
                        return false;
                    }
                    if (prevVal == curVal)
                    {
                        Utilities.LogMessage("Two cells values are equal, Verify next level sorty by cloumn");
                    }
                    else
                    {
                        Utilities.LogMessage("Two cells sort right, continue to verify next row");
                        break;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Verify sort by and group by button status in personalization dialog
        /// </summary>
        /// <param name="ColumnsName">string Columns Name</param>
        /// <returns>true or false</returns>
        public bool VerifySortByANdGroupByButtonStatus(string ColumnsName)
        {
            bool result = false;
            if (ColumnsName != null)
            {
                bool itemFound = false;
                foreach (ListViewItem item in updatePersonalizationDialog.Controls.ColumnsDisplayListView.Items)
                {
                    string listItemName = GetColumnListItemName(item);
                    if (listItemName == ColumnsName)
                    {
                        itemFound = true;
                        item.Select();
                        if (updatePersonalizationDialog.Controls.SortByButton.IsEnabled || updatePersonalizationDialog.Controls.GroupByButton.IsEnabled)
                        {
                            Utilities.LogMessage("VerifySortByANdGroupByButtonStatus:: SortBy or GroupBy button is enabled");
                            result = true;
                        }
                        break;
                    }
                }
                if (itemFound == false)
                {
                    Utilities.LogMessage("VerifySortByANdGroupByButtonStatus:: Can not found the cloumn : " + ColumnsName);
                    throw new Exception("VerifySortByANdGroupByButtonStatus:: Can not found the cloumn : " + ColumnsName);
                }
            }
            return result;
        }

        /// <summary>
        /// Method for revert personalization setting to default
        /// </summary>
        public void RevertPersonalization()
        {
            this.LaunchPersonalizationDialog();
            this.updatePersonalizationDialog.ClickRevert();
            Dialogs.RevertToDefaultsDialog revertToDefaultDialog = new Dialogs.RevertToDefaultsDialog(CoreManager.MomConsole);
            revertToDefaultDialog.ClickOK();
        }

        /// <summary>
        /// Verify the personalization settings after revert
        /// </summary>
        /// <returns></returns>
        public bool VerifyRevertPeronalization()
        {
            Utilities.LogMessage("VerifyRevertPeronalization::...");
            List<string> ColumnsNameInPersonalization = new List<string>();
            //First reopening the personlization page and see the original setting got applied
            this.LaunchPersonalizationDialog();
            Utilities.LogMessage("VerifyRevertPeronalization:: Get the setting from personalization page");
            foreach (ListViewItem item in updatePersonalizationDialog.Controls.ColumnsDisplayListView.Items)
            {
                string listItemName = GetColumnListItemName(item);
                if (item.Checked)
                {
                    //MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]ClassName='CheckBox'", null);
                    Utilities.LogMessage("VerifyRevertPeronalization:: THe column " + listItemName + " is checked in personalization page");
                    ColumnsNameInPersonalization.Add(listItemName);
                }
            }
            updatePersonalizationDialog.ClickCancel();
            CoreManager.MomConsole.ConfirmChoiceDialog(
              MomConsoleApp.ButtonCaption.OK,
              ConsoleApp.Strings.CancelWizardDialogTitle,
              StringMatchSyntax.WildCard,
              MomConsoleApp.ActionIfWindowNotFound.Ignore);
            
            // Second Get Column from Alert view
            DataGridControl DataGrid = null;
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    DataGrid = new DataGridControl(CoreManager.MomConsole.ViewPane, new QID(";[UIA]AutomationId='InnerDataGrid'"));
                    break;
                case ProductSkuLevel.Web:
                    DataGrid = new DataGridControl(CoreManager.MomConsole.MainWindow, new QID(";[UIA]AutomationId='silverlightDataGrid'"));
                    break;
            } 
            List<string> columnHeaders = DataGrid.GetColumHeaders();
            if (columnHeaders.Count != ColumnsNameInPersonalization.Count)
            {
                Utilities.LogMessage("VerifyRevertPeronalization:: Display Columns count and Column headers count do not match, columnHeaders.Count is " + columnHeaders.Count + " and DisplayColumnsName.Count is " + ColumnsNameInPersonalization.Count);
                return false;
            }

            for (int i = 0; i < columnHeaders.Count; i++)
            {
                if (ColumnsNameInPersonalization[i] == columnHeaders[i])
                {
                    Utilities.LogMessage("VerifyRevertPeronalization:: Display Column Name " + ColumnsNameInPersonalization[i] + " match Column Header Name " + columnHeaders[i]);
                }
                if (ColumnsNameInPersonalization[i] != columnHeaders[i])
                {
                    Utilities.LogMessage("VerifyRevertPeronalization:: Display Column Name " + ColumnsNameInPersonalization[i] + " does not match Column Header Name " + columnHeaders[i]);
                    return false;
                }
            }
            return true;
        }

        private string GetColumnListItemName(ListViewItem item)
        {
            MauiCollection<IScreenElement> listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]ClassName='CheckBox'", null);
            // in webconsole, this method cannot found some items that are invisible, so send page down/up key to show them
            int loop = 0;
            int maxRetries = 20;
            while (listItem.Count == 0 && loop < maxRetries)
            {
                if (loop < maxRetries / 2)
                {
                    updatePersonalizationDialog.SendKeys(KeyboardCodes.PageDown);
                }
                else
                {
                    updatePersonalizationDialog.SendKeys(KeyboardCodes.PageUp);
                }
                listItem = item.ScreenElement.FindAllDescendants(-1, ";[UIA]ClassName='CheckBox'", null);
                loop++;
            }

            return listItem[0].Name;
        }
        #endregion
    }
}