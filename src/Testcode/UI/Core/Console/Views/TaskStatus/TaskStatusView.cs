// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TaskStatusView.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	Task Status View
// </summary>
// <history>
// 	[zhihaoq] 04/01/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.TaskStatus
{

    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;
    using Infra.Frmwrk;

    using TaskStatusDialog = Mom.Test.UI.Core.Console.Views.TaskStatus.Dialogs;

    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Task Status View
    /// </summary>
    /// <history>
    /// 	[zhihaoq] 04/01/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class TaskStatusView
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        //Navigation Pane
        NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

        /// <summary>
        /// New task status view
        /// </summary>
        Core.Console.Views.Views newTaskStatusView = new Mom.Test.UI.Core.Console.Views.Views();

        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Task Status View
        /// </summary>
        /// -----------------------------------------------------------------------------
        public TaskStatusView()
        {
        }
        #endregion

        #region Public Methods

        #region CreateTaskStatusView
        /// <summary>
        ///  Create a new Task Status View
        /// </summary>
        /// <param name="parameters">instance of task status view parameters class</param>
        /// <history>
        ///     [zhihaoq]   04/25/08 - Created
        /// </history>
        public bool CreateTaskStatusView(TaskStatusViewParameters parameters)
        {
            Utilities.LogMessage("TaskStatusView.CreateTaskStatusView...");
            Utilities.LogMessage("TaskStatusView.CreateTaskStatusView :: Task Status View Name = " + parameters.TaskStatusViewName);
            Utilities.LogMessage("TaskStatusView.CreateTaskStatusView :: Task Status View Description = " + parameters.TaskStatusViewDescription);
            Utilities.LogMessage("TaskStatusView.CreateTaskStatusView :: Task Status View is created under " + parameters.TaskStatusViewFolderName);

            Utilities.LogMessage("TaskStatusView.CreateTaskStatusView :: Launching Create View wizard for Task Status View");
            newTaskStatusView.Create(Core.Console.Views.ViewType.TaskStatusView, parameters.TaskStatusViewName, parameters.TaskStatusViewDescription, parameters.TaskStatusViewFolderName);
            Utilities.TakeScreenshot("TaskStatusView.CreateTaskStatusView - View created");

            return this.VerifyTaskStatusViewCreated(parameters);
        }
        #endregion


        #region PersonalizeTaskStatusView
        /// <summary>
        /// Method to personalize a Task Status view
        /// </summary>
        /// <param name="parameters">instance of task status view parameters</param>
        /// <history>
        ///     [zhihaoq]   04/25/08 - Created
        /// </history>
        public void PersonalizeTaskStatusView(TaskStatusViewParameters parameters)
        {
            //Navigate to Task Status View to personalize
            Utilities.LogMessage("TaskStatusView.PersonalizeTaskStatusView :: Bring Console to foreground (...)");
            CoreManager.MomConsole.BringToForeground();

            Utilities.LogMessage("TaskStatusView.PersonalizeTaskStatusView :: Navigate to Task Status View(...)");
            //Select Task Status View 
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            Maui.Core.WinControls.TreeNode selectedNode = navPane.SelectNode(NavigationPane.Strings.Monitoring +
                Constants.PathDelimiter + parameters.TaskStatusViewFolderName +
                Constants.PathDelimiter + parameters.TaskStatusViewName, NavigationPane.NavigationTreeView.Monitoring);
            Utilities.LogMessage("TaskStatusView.PersonalizeTaskStatusView :: Successfully found and clicked on view " +
                parameters.TaskStatusViewName + " under " + parameters.TaskStatusViewFolderName);

            //Select Personalize menu item and Launch the Personalize Dialog
            CoreManager.MomConsole.ExecuteContextMenu(Core.Console.Views.Views.Strings.PersonalizeContextMenu, true);
            Utilities.LogMessage("TaskStatusView.PersonalizeTaskStatusView :: Launch Personalize Task Status View dialog");

            this.LaunchPersonalizeViewDialog();
            Utilities.TakeScreenshot("TaskStatusView.PersonalizeTaskStatusView - Launched TaskStatusView property dialog to personalize");
        }

        #endregion

        #region LaunchPersonalizeViewDialog
        /// <summary>
        /// Method to launch personalize dialog of Task Status view
        /// </summary>
        public Window LaunchPersonalizeViewDialog()
        {
            Mom.Test.UI.Core.Console.Views.Dialogs.PersonalizeViewDialog PersonalizeTaskStatusViewDialog = null;

            PersonalizeTaskStatusViewDialog = new Mom.Test.UI.Core.Console.Views.Dialogs.PersonalizeViewDialog(CoreManager.MomConsole);
            UISynchronization.WaitForUIObjectReady(PersonalizeTaskStatusViewDialog, Constants.DefaultDialogTimeout);
            Utilities.LogMessage("TaskStatusView.LaunchPersonalizeViewDialog :: Successfully get the Personalize view dialog");
            PersonalizeTaskStatusViewDialog.Extended.SetFocus();

            int count = 0;
            bool isCheckedItem = true;
            string value = null;
            // Get the available columns count
            count = PersonalizeTaskStatusViewDialog.Controls.ColumnsToDisplayListBox.Items.Count;
            Utilities.LogMessage("TaskStatusView.LaunchPersonalizeViewDialog :: Available columns count is " + count);

            // Is the column checked to start with
            isCheckedItem = PersonalizeTaskStatusViewDialog.Controls.ColumnsToDisplayListBox[0].Selected;
            Utilities.LogMessage("TaskStatusView.LanunchPersonalizeViewDialog :: The column is checked as " + isCheckedItem);

            // Remove the first selected column by unchecking it
            PersonalizeTaskStatusViewDialog.Controls.ColumnsToDisplayListBox[0].Click();
            // Get value of the first item
            value = PersonalizeTaskStatusViewDialog.Controls.ColumnsToDisplayListBox[0].Text;
            Utilities.LogMessage("TaskStatusView.LaunchPersonalizeViewDialog :: Column text is " + value);
            isCheckedItem = PersonalizeTaskStatusViewDialog.Controls.ColumnsToDisplayListBox[0].Selected;
            Utilities.LogMessage("TaskStatusView.LaunchPersonalizeViewDialog :: The column is checked as " + isCheckedItem);
            // PersonalizeTaskStatusViewDialog.Controls.ColumnsToDisplayListBox.UnselectItem(value, true);
            Utilities.LogMessage("TaskStatusView.LaunchPersonalizeViewDialog :: Unselected item " + value);

            Maui.Core.UISynchronization.WaitForUIObjectReady(PersonalizeTaskStatusViewDialog, Constants.DefaultDialogTimeout);
            // Try to Save and Close
            PersonalizeTaskStatusViewDialog.ClickOK();
            Utilities.LogMessage("TaskStatusView.LaunchPersonalizeViewDialog :: Success in saving and closing Personalize dialog");

            return PersonalizeTaskStatusViewDialog;
        }
        #endregion

        #region VerifyPersonalizeTaskView

        /// <summary>
        /// Method to verify that the view is Personalized
        /// </summary>
        public void VerifyPersonalizeTaskView(TaskStatusViewParameters parameters)
        {

            //Navigate to task status view to verify personalize
            CoreManager.MomConsole.BringToForeground();
            Utilities.LogMessage("TaskView.VerifyPersonalizeTaskView :: Navigate to Task View(...)");
            Maui.Core.WinControls.TreeNode selectedNode = navPane.SelectNode(
                NavigationPane.Strings.Monitoring + Constants.PathDelimiter + Constants.UITestViewFolder + Constants.PathDelimiter + parameters.TaskStatusViewName,
                NavigationPane.NavigationTreeView.Monitoring);
            Utilities.LogMessage("TaskView.VerifyPersonalizeTaskView :: Successfully found and clicked on View " + parameters.TaskStatusViewName + " under " + Constants.UITestViewFolder);

            Utilities.LogMessage("TaskView.VerifyPersonalizeTaskView :: Create instance of grid control");

            //Create instance of Task Status View Grid Control
            Mom.Test.UI.Core.Console.MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;

            if (viewGrid != null)
            {
                Utilities.LogMessage("TaskView.VerifyPersonalizeTaskView :: Clicking in the Grid");
                viewGrid.Click();
                Utilities.LogMessage("TaskView.VerifyPersonalizeTaskView :: Right clicking now");
                // Selecting Personalize from the context menu
                //Select Personalize menu item and Launch the Personalize dialog
                CoreManager.MomConsole.ExecuteContextMenu(Core.Console.Views.Views.Strings.PersonalizeContextMenu, true);
                Utilities.LogMessage("TaskView.VerifyPersonalizeTaskView :: Successfully clicked on Personalize context menu item in Task view");

                //Launch VerifyAddRemoveColumnDialog to check if the view is Personalized
                Utilities.LogMessage("TaskView.VerifyPersonalizeTaskView :: Launching Personalize Task Status view dialog to verify");
                LaunchVerifyPersonalizeViewDialog();
            }
            else
            {
                Utilities.LogMessage("TaskView.VerifyPersonalizeTaskView :: viewGrid not found.");
            }

            Utilities.TakeScreenshot("VerifyPersonalizeTaskView");

        }

        #endregion

        #region LaunchVerifyPersonalizeViewDialog

        /// <summary>
        /// Method to launch personalize dialog of Task Status view
        /// </summary>
        public Window LaunchVerifyPersonalizeViewDialog()
        {
            //Mom.Test.UI.Core.Console.Views.Dialogs.PersonalizeViewDialog
            Mom.Test.UI.Core.Console.Views.Dialogs.PersonalizeViewDialog PersonalizeTaskViewDialog = null;

            PersonalizeTaskViewDialog = new Mom.Test.UI.Core.Console.Views.Dialogs.PersonalizeViewDialog(CoreManager.MomConsole);
            UISynchronization.WaitForUIObjectReady(PersonalizeTaskViewDialog, Constants.DefaultDialogTimeout);
            Utilities.LogMessage("TaskView.LaunchVerifyPersonalizeViewDialog :: Success getting the Personalize view dialog");
            PersonalizeTaskViewDialog.Extended.SetFocus();

            bool isCheckedItem = true;
            string value = null;

            //Get value of the first item.
            value = PersonalizeTaskViewDialog.Controls.ColumnsToDisplayListBox[0].Text;
            Utilities.LogMessage("TaskView.LaunchVerifyPersonalizeViewDialog :: First column value is " + value);
            isCheckedItem = PersonalizeTaskViewDialog.Controls.ColumnsToDisplayListBox[0].Selected;
            Utilities.LogMessage("TaskView.LaunchVerifyPersonalizeViewDialog :: First column is " + isCheckedItem);

            if (!isCheckedItem)
            {
                Utilities.LogMessage("TaskView.LaunchVerifyPersonalizeViewDialog :: We are Personalized, the item is unchecked");
                //Clean up after the var
                PersonalizeTaskViewDialog.Controls.ColumnsToDisplayListBox[0].Click();
                //Check if cleaned up
                isCheckedItem = PersonalizeTaskViewDialog.Controls.ColumnsToDisplayListBox[0].Selected;
                Utilities.LogMessage("TaskView.LaunchVerifyPersonalizeViewDialog :: First column is " + isCheckedItem + " now as a part of clean up");
                //PersonalizeTaskViewDialog.Controls.ColumnsToDisplayListBox.SelectItem(value, true);
                Utilities.LogMessage("TaskView.LaunchVerifyPersonalizeViewDialog :: Check the item back on");
            }
            else
            {
                Utilities.LogMessage("TaskView.LaunchVerifyPersonalizeViewDialog :: Failed to Personalize in the dialog");
                Utilities.LogMessage("TaskView.LaunchVerifyPersonalizeViewDialog :: The column " + value + " was not unchecked, therefor UI was not personalized");
                throw new VarFail("TaskView.LaunchVerifyPersonalizeViewDialog :: Failed to Personalize Task view");
            }

            //Close dialog by clicking OK button
            PersonalizeTaskViewDialog.ClickOK();
            CoreManager.MomConsole.Waiters.WaitForStatusReady();
            Utilities.LogMessage("TaskView.LaunchVerifyPersonalizeViewDialog :: Success in clean up - saving and closing PersonalizeTaskViewDialog");

            return PersonalizeTaskViewDialog;
        }
        #endregion

        #region DeleteTaskStatusView
        /// <summary>
        /// Method to delete custom Task Status view
        /// </summary>
        public bool DeleteTaskStatusView(TaskStatusViewParameters parameters)
        {
            Utilities.LogMessage("TaskStatusView.DeleteTaskStatusView :: Delete newly created Task Status View...");
            Utilities.LogMessage("TaskStatusView.DeleteTaskStatusView :: Bring Console to foreground(...)");
            CoreManager.MomConsole.BringToForeground();

            bool isViewDeleted = false;

            // Select Task Status view under UITest MP and Delete
            Utilities.LogMessage("TaskStatusView.DeleteTaskStatusView :: Delete...");
            isViewDeleted = newTaskStatusView.Delete(parameters.TaskStatusViewName, Constants.UITestViewFolder);
            Utilities.TakeScreenshot("DeleteTaskStatusView");
            return isViewDeleted;
        }
        #endregion

        #region ShowCombinedTask
        /// <summary>
        /// Method to show combined task
        /// </summary>
        public bool ShowCombinedTask(int rowsSelectInGridView)
        {
            Utilities.LogMessage("TaskStatusView.ShowCombinedTask :: Show CombinedTask ...");
            Utilities.LogMessage("TaskStatusView.ShowCombinedTask :: Bring Console to foreground(...)");
            CoreManager.MomConsole.BringToForeground();

            bool isCombinedTaskShowed = true;

            int colposStatus = 0;
            int colposTaskName = 0;
            int colposStartTime = 0;

            // 1. Find the navigation to Task Status
            Utilities.LogMessage("TaskStatusView.ShowCombinedTask :: Navigate to Task View(...)");
            Maui.Core.WinControls.TreeNode selectedNode = navPane.SelectNode(
                NavigationPane.Strings.Monitoring + Constants.PathDelimiter + Constants.UITestViewFolder + Constants.PathDelimiter + Views.Strings.TaskStatusView,
                NavigationPane.NavigationTreeView.Monitoring);
            Utilities.LogMessage("TaskStatusView.ShowCombinedTask :: Successfully found and clicked on View " + " under " + Constants.UITestViewFolder);

            // 2. Find the task status grid view
            Utilities.LogMessage("TaskStatusView.ShowCombinedTask :: Create instance of grid control");

            // Create instance of Task Status View Grid Control
            Mom.Test.UI.Core.Console.MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;

            // Click the first row and then choose the next two rows
            int rowIndex = 1;
            if (viewGrid != null)
            {
                Utilities.LogMessage("TaskStatusView.ShowCombinedTask :: Clicking in the Grid");
                viewGrid.Rows[rowIndex].Click();
            }
            else
            {
                Utilities.LogMessage("TaskStatusView.ShowCombinedTask :: viewGrid not found");
            }

            // 3. Select tasks status
            for (int i = 0; i < rowsSelectInGridView - 1; i++)
            {
                viewGrid.SendKeys(KeyboardCodes.Shift + "(" + KeyboardCodes.DownArrow + ")");
            }

            // get the three columns values of each task status for the next verifing
            colposStatus = CoreManager.MomConsole.ViewPane.Grid.GetColumnTitlePosition(Strings.StatusColumnHeader);
            colposTaskName = CoreManager.MomConsole.ViewPane.Grid.GetColumnTitlePosition(Strings.TaskNameColumnHeader);
            colposStartTime = CoreManager.MomConsole.ViewPane.Grid.GetColumnTitlePosition(Strings.StartTimeColumnHeader);

            TaskStatusGridViewFields[] taskStatusGridView = new TaskStatusGridViewFields[rowsSelectInGridView];
            //Wait for grid view ready
            viewGrid.ScreenElement.WaitForReady();
            for (int i = 0; i < rowsSelectInGridView; i++)
            {
                taskStatusGridView[i] = new TaskStatusGridViewFields();
                taskStatusGridView[i].TaskStatusStatus = viewGrid.GetCellValue(rowIndex + i, colposStatus);
                taskStatusGridView[i].TaskStatusTaskName = viewGrid.GetCellValue(rowIndex + i, colposTaskName);
                taskStatusGridView[i].TaskStatusStartTime = viewGrid.GetCellValue(rowIndex + i, colposStartTime);
                if (taskStatusGridView[i].TaskStatusStartTime == Strings.NullString)
                {
                    taskStatusGridView[i].TaskStatusStartTime = string.Empty;
                }
            }
            // 4. Click combined link
            ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
            taskPane.ClickLink(Strings.TaskActionHeader, Views.Strings.ShowCombinedTaskOutputActionItem);
            
            // 5. Verify the result
            // get the combined task output dialog
            Mom.Test.UI.Core.Console.Views.TaskStatus.Dialogs.CombinedTaskOutputDialog CombinedTaskOutputDialog = null;

            CombinedTaskOutputDialog = new Mom.Test.UI.Core.Console.Views.TaskStatus.Dialogs.CombinedTaskOutputDialog(CoreManager.MomConsole);

            Utilities.LogMessage("TaskStatusView.ShowCombinedTask :: Get HTMLDoc from the Combined Task Output Dialog");
            string combinedTaskOutputInnerText = CombinedTaskOutputDialog.Controls.HTMLDoc.Document2.body.innerText;

            // Verifying
            for (int i = 0; i < taskStatusGridView.Length; i++)
            {
                if (combinedTaskOutputInnerText.Contains(taskStatusGridView[i].TaskStatusTaskName)
                    && combinedTaskOutputInnerText.Contains(taskStatusGridView[i].TaskStatusStartTime))
                {
                    combinedTaskOutputInnerText = combinedTaskOutputInnerText.Substring(combinedTaskOutputInnerText.IndexOf("Task Output") + 1);
                }
                else
                {
                    Utilities.LogMessage("TaskStatusView.ShowCombinedTask :: Verify failed! Please check out the log file!");
                    isCombinedTaskShowed = false;
                    break;
                }
            }
            CombinedTaskOutputDialog.ClickClose();
            CoreManager.MomConsole.WaitForDialogClose(CombinedTaskOutputDialog, Constants.OneMinute / 1000);

            return isCombinedTaskShowed;
        }
        #endregion

        #region rowsInTaskStatusGridView
        /// <summary>
        /// Method to count the rows in task status gridview
        /// </summary>
        public int rowsInTaskStatusGridView()
        {
            Utilities.LogMessage("TaskStatusView.rowsInTaskStatusGridView :: rowsInTaskStatusGridView ...");
            Utilities.LogMessage("TaskStatusView.rowsInTaskStatusGridView :: Bring Console to foreground(...)");
            CoreManager.MomConsole.BringToForeground();

            TaskStatusViewParameters parameters = new TaskStatusViewParameters();
            parameters.TaskStatusViewFolderName = Constants.UITestViewFolder;
            parameters.TaskStatusViewName = Views.Strings.TaskStatusView;

            return rowsInTaskStatusGridView(parameters);
        }

        /// <summary>
        /// Method to count the rows in task status gridview
        /// <param name="parameters">instance of task status view parameters</param>
        /// </summary>
        public int rowsInTaskStatusGridView(TaskStatusViewParameters parameters)
        {
            Utilities.LogMessage("TaskStatusView.rowsInTaskStatusGridView :: rowsInTaskStatusGridView ...");
            Utilities.LogMessage("TaskStatusView.rowsInTaskStatusGridView :: Bring Console to foreground(...)");
            CoreManager.MomConsole.BringToForeground();

            Utilities.LogMessage("TaskStatusView.rowsInTaskStatusGridView :: Navigate to Task View(...)");
            Maui.Core.WinControls.TreeNode selectedNode = navPane.SelectNode(NavigationPane.Strings.Monitoring +
                Constants.PathDelimiter + parameters.TaskStatusViewFolderName +
                Constants.PathDelimiter + parameters.TaskStatusViewName, NavigationPane.NavigationTreeView.Monitoring);
            Utilities.LogMessage("TaskStatusView.rowsInTaskStatusGridView :: Successfully found and clicked on View " + " under " + Constants.UITestViewFolder);

            Utilities.LogMessage("TaskStatusView.rowsInTaskStatusGridView :: Create instance of grid control");
            // Create instance of Task Status View Grid Control
            Mom.Test.UI.Core.Console.MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;

            int rowsCount = 0;
            if (viewGrid != null)
            {
                Utilities.LogMessage("TaskStatusView.rowsInTaskStatusGridView :: Clicking in the Grid");
                rowsCount = viewGrid.Rows.Count - 1;
            }
            else
            {
                Utilities.LogMessage("TaskStatusView.rowsInTaskStatusGridView :: viewGrid not found");
            }

            return rowsCount;
        }

        #endregion

        #region VerifyTaskStatusViewCreatedCriteria
        /// <summary>
        ///  Verify the newly created TaskStatusView's name and property and other criteria matches the ones in its property dialog
        /// </summary>
        /// <param name="parameters">the newly created task status view parameters</param>
        /// <history>
        ///     [v-eachu]   09/30/09 - Created
        /// </history>
        public bool VerifyTaskStatusViewCreatedCriteria(Core.Console.Views.Views.CreateViewParameters viewCriteriaParams)
        {
            Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreatedCriteria :: Verify the new Task Status View was created properly ...");
            Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreatedCriteria :: Bring Console to foreground(...)");
            CoreManager.MomConsole.BringToForeground();

            Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreatedCriteria :: Navigate(...)");

            //Select Task Status view specified in the instance of TaskStatusViewParameters
            Maui.Core.WinControls.TreeNode selectedNode = navPane.SelectNode(
                NavigationPane.Strings.Monitoring + Constants.PathDelimiter + viewCriteriaParams.FolderName +
                Constants.PathDelimiter + viewCriteriaParams.Name, NavigationPane.NavigationTreeView.Monitoring);
            Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreated :: Successfully found and clicked on View " + viewCriteriaParams.Name
                + " under " + viewCriteriaParams.FolderName);

            //Launch view Properties
            CoreManager.MomConsole.ExecuteContextMenu(Core.Console.Views.Views.Strings.PropertiesContextMenu, true);

            //current task status view properties dialog
            Core.Console.Views.TaskStatus.Dialogs.TaskStatusViewPropertiesDialog taskStatusViewPropertiesDialog = null;
            taskStatusViewPropertiesDialog = new Core.Console.Views.TaskStatus.Dialogs.TaskStatusViewPropertiesDialog(CoreManager.MomConsole);
            //Launch properties dialog to verify description
            UISynchronization.WaitForUIObjectReady(taskStatusViewPropertiesDialog, Constants.DefaultDialogTimeout);
            Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreated :: Success getting the properties view dialog for selected task status view");
            taskStatusViewPropertiesDialog.Extended.SetFocus();

            bool viewPropertiesMatchNameAndDescription = false;
            if ((String.Compare(taskStatusViewPropertiesDialog.NameText, viewCriteriaParams.Name, false) == 0) &&
                (String.Compare(taskStatusViewPropertiesDialog.DescriptionText, viewCriteriaParams.Description, false) == 0))
            {
                Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreated :: Name of Task Status View matches " + taskStatusViewPropertiesDialog.NameText);
                Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreated :: Description of Task Status View matches: " + taskStatusViewPropertiesDialog.DescriptionText);
                viewPropertiesMatchNameAndDescription = true;
            }

            //close the dialog
            taskStatusViewPropertiesDialog.ClickCancel();

            // Verify Task Status and Task Target Class
            Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreated :: Create instance of grid control");

            // Create instance of Task Status View Grid Control
            Mom.Test.UI.Core.Console.MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;

            // Click the row 
            int rowIndex = 1;
            if (viewGrid != null)
            {
                Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreated :: Clicking in the Grid");
                viewGrid.Rows[rowIndex].Click();
            }
            else
            {
                Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreated :: viewGrid not found");
            }

            // get columns values of the task status for the next verifing
            int colposStatus = 0;
            int colposTaskTargetClass = 0;

            colposStatus = CoreManager.MomConsole.ViewPane.Grid.GetColumnTitlePosition(Strings.StatusColumnHeader);
            colposTaskTargetClass = CoreManager.MomConsole.ViewPane.Grid.GetColumnTitlePosition(Core.Console.Views.Views.Strings.TaskTargetClassColumnHeader);

            TaskStatusGridViewFields taskStatusGridView = new TaskStatusGridViewFields();
            taskStatusGridView.TaskStatusStatus = viewGrid.GetCellValue(rowIndex, colposStatus);
            taskStatusGridView.TaskTargetClass = viewGrid.GetCellValue(rowIndex, colposTaskTargetClass);

            // convert english value to Resource String
            if (taskStatusGridView.TaskStatusStatus.Equals("Succeeded"))
                taskStatusGridView.TaskStatusStatus = TaskStatusDialog.TaskSelectionWithSpecificStatusDialog.Strings.Succeeded;

            Utilities.LogMessage("TaskTargetClass  Get From GridView  :: " + taskStatusGridView.TaskTargetClass);
            Utilities.LogMessage("TaskTargetClass  Get From Varmap    :: " + viewCriteriaParams.Target);
            Utilities.LogMessage("TaskStatusStatus Get From GridView  :: " + taskStatusGridView.TaskStatusStatus);
            Utilities.LogMessage("TaskStatusStatus Get From Varmap    :: " + viewCriteriaParams.TaskSpecificStatusValues[0].ToString());

            bool viewPropertiesMachStatusAndTarget = false;
            if ((String.Compare(taskStatusGridView.TaskTargetClass, viewCriteriaParams.Target, false) == 0) &&
                (String.Compare(taskStatusGridView.TaskStatusStatus, viewCriteriaParams.TaskSpecificStatusValues[0].ToString(), false) == 0))
            {
                Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreated :: Status of Task Status View matches " + taskStatusGridView.TaskStatusStatus);
                Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreated :: Target Class of Task Status View matches: " + taskStatusGridView.TaskTargetClass);
                viewPropertiesMachStatusAndTarget = true;
            }

            bool viewPropertiesMatch = viewPropertiesMatchNameAndDescription && viewPropertiesMachStatusAndTarget;

            return viewPropertiesMatch;
        }
        #endregion

        #endregion

        #region private methods
        #region VerifyTaskStatusViewCreated
        /// <summary>
        ///  Verify the newly created TaskStatusView's name and property matches the ones in its property dialog
        /// </summary>
        /// <param name="parameters">the newly created task status view parameters</param>
        /// <history>
        ///     [zhihaoq]   04/25/08 - Created
        /// </history>
        private bool VerifyTaskStatusViewCreated(TaskStatusViewParameters parameters)
        {
            Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreated :: Verify the new Task Status View was created properly ...");
            Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreated :: Bring Console to foreground(...)");
            CoreManager.MomConsole.BringToForeground();

            Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreated :: Navigate(...)");

            //Select Task Status view specified in the instance of TaskStatusViewParameters
            Maui.Core.WinControls.TreeNode selectedNode = navPane.SelectNode(
                NavigationPane.Strings.Monitoring + Constants.PathDelimiter + parameters.TaskStatusViewFolderName +
                Constants.PathDelimiter + parameters.TaskStatusViewName, NavigationPane.NavigationTreeView.Monitoring);
            Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreated :: Successfully found and clicked on View " + parameters.TaskStatusViewName
                + " under " + parameters.TaskStatusViewFolderName);

            //Launch view Properties
            CoreManager.MomConsole.ExecuteContextMenu(Core.Console.Views.Views.Strings.PropertiesContextMenu, true);

            //current task status view properties dialog
            Core.Console.Views.TaskStatus.Dialogs.TaskStatusViewPropertiesDialog taskStatusViewPropertiesDialog = null;
            taskStatusViewPropertiesDialog = new Core.Console.Views.TaskStatus.Dialogs.TaskStatusViewPropertiesDialog(CoreManager.MomConsole);
            //Launch properties dialog to verify description
            UISynchronization.WaitForUIObjectReady(taskStatusViewPropertiesDialog, Constants.DefaultDialogTimeout);
            Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreated :: Success getting the properties view dialog for selected task status view");
            taskStatusViewPropertiesDialog.Extended.SetFocus();

            bool viewPropertiesMatch = false;
            if ((String.Compare(taskStatusViewPropertiesDialog.NameText, parameters.TaskStatusViewName, false) == 0) &&
                (String.Compare(taskStatusViewPropertiesDialog.DescriptionText, parameters.TaskStatusViewDescription, false) == 0))
            {
                Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreated :: Name of Task Status View matches " + taskStatusViewPropertiesDialog.NameText);
                Utilities.LogMessage("TaskStatusView.VerifyTaskStatusViewCreated :: Description of Task Status View matches: " + taskStatusViewPropertiesDialog.DescriptionText);
                viewPropertiesMatch = true;
            }

            //close the dialog
            taskStatusViewPropertiesDialog.ClickCancel();

            return viewPropertiesMatch;
        }
        #endregion
        #endregion

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for Task Status View
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 04/01/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Contains resource string for: Status Column header under Task Status View        
            /// </summary>
            private const string ResourceStatusColumnHeader =
            ";Status;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnStatus";

            /// <summary>
            /// Contains resource string for: Task Name Column header under Task Status View        
            /// </summary>
            private const string ResourceTaskNameColumnHeader =
            ";Task Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnTaskName";

            /// <summary>
            /// Contains resource string for: Start Time Column header under Task Status View        
            /// </summary>
            private const string ResourceStartTimeColumnHeader =
            ";Start Time;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnStartTime";

            /// <summary>
            /// Contains resource string for: Submitted By Column header under Task Status View        
            /// </summary>
            private const string ResourceSubmittedByColumnHeader =
            ";Submitted By;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnSubmittedBy";

            /// <summary>
            /// Contains resource string for: Run As Column header under Task Status View        
            /// </summary>
            private const string ResourceRunAsColumnHeader =
            ";Run As;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnRunAs";

            /// <summary>
            /// Contains resource string for: Run Location Column header under Task Status View        
            /// </summary>
            private const string ResourceRunLocationColumnHeader =
            ";Run Location;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnRunLocation";

            /// <summary>
            /// Contains resource string for: Task Target Column header under Task Status View        
            /// </summary>
            private const string ResourceTaskTargetColumnHeader =
            ";Task Target;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnTargetedType";

            /// <summary>
            /// Contains resource string for: Category Column header under Task Status View        
            /// </summary>
            private const string ResourceCategoryColumnHeader =
            ";Category;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnCategory";
           
            /// <summary>
            /// Contains resource string for: Task Actions header on Action pane        
            /// </summary>
            private const string ResourceTaskActionHeader =
            ";Task Actions;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ActionGroupText";

            #region Task Status View criteria

            /// <summary>
            /// Contains resource string for:  (Task Status) With a (specific) status view criteria
            /// </summary>   
            private const string ResourceWithStatus =
                ";{0} with {1} status;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusCriteriaResource;StatusText";

            /// <summary>
            /// Contains resource string for (null) string
            /// </summary>
            private const string ResourceNull = ";(null);ManagedString;System.Windows.Forms.dll;System.Windows.Forms;DataGridNullText";

            #endregion

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Status Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStatusColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Task Name Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskNameColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Start Time Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStartTimeColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Submitted By Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSubmittedByColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Run As Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunAsColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Run Location Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunLocationColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Task Target Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskTargetColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Category Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCategoryColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Task Action header on Action pane
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskActionHeader;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for (null) string
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedResourceNull;

            #region Task Status View criteria

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WithStatus view criteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWithStatus;

            #endregion

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Status Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StatusColumnHeader
            {
                get
                {
                    if ((cachedStatusColumnHeader == null))
                    {
                        cachedStatusColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceStatusColumnHeader);
                    }

                    return cachedStatusColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Task Name Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskNameColumnHeader
            {
                get
                {
                    if ((cachedTaskNameColumnHeader == null))
                    {
                        cachedTaskNameColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceTaskNameColumnHeader);
                    }

                    return cachedTaskNameColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Start Time Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StartTimeColumnHeader
            {
                get
                {
                    if ((cachedStartTimeColumnHeader == null))
                    {
                        cachedStartTimeColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceStartTimeColumnHeader);
                    }

                    return cachedStartTimeColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Submitted By Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SubmittedByColumnHeader
            {
                get
                {
                    if ((cachedSubmittedByColumnHeader == null))
                    {
                        cachedSubmittedByColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceSubmittedByColumnHeader);
                    }

                    return cachedSubmittedByColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Run As Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunAsColumnHeader
            {
                get
                {
                    if ((cachedRunAsColumnHeader == null))
                    {
                        cachedRunAsColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceRunAsColumnHeader);
                    }

                    return cachedRunAsColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Run Location Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunLocationColumnHeader
            {
                get
                {
                    if ((cachedRunLocationColumnHeader == null))
                    {
                        cachedRunLocationColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceRunLocationColumnHeader);
                    }

                    return cachedRunLocationColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Task Target Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskTargetColumnHeader
            {
                get
                {
                    if ((cachedTaskTargetColumnHeader == null))
                    {
                        cachedTaskTargetColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceTaskTargetColumnHeader);
                    }

                    return cachedTaskTargetColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Category Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CategoryColumnHeader
            {
                get
                {
                    if ((cachedCategoryColumnHeader == null))
                    {
                        cachedCategoryColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceCategoryColumnHeader);
                    }

                    return cachedCategoryColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Category Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 09/18/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskActionHeader
            {
                get
                {
                    if ((cachedTaskActionHeader == null))
                    {
                        cachedTaskActionHeader = CoreManager.MomConsole.GetIntlStr(ResourceTaskActionHeader);
                    }

                    return cachedTaskActionHeader;
                }
            }

            #region Task Status View criteria

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the '(Task Status) With (Specific) Status' view criteria item
            /// </summary>
            /// <history>
            /// 	[v-eachu] 29SEP09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WithStatus
            {
                get
                {
                    if ((cachedWithStatus == null))
                    {
                        cachedWithStatus = CoreManager.MomConsole.GetIntlStr(ResourceWithStatus);
                    }

                    return cachedWithStatus;
                }
            }

            #endregion

            /// ---------------------------------------------------------------
            /// <summary>
            /// Resource (null) Sting
            /// </summary> 
            /// <history>
            /// [v-lileo] 03/16/2010 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string NullString
            {
                get
                {
                    if ((cachedResourceNull == null))
                    {
                        cachedResourceNull = CoreManager.MomConsole.GetIntlStr(ResourceNull);
                    }

                    return cachedResourceNull;
                }
            }

            #endregion
        }

        #endregion

        #region TaskStatusViewParameters Class
        /// <summary>
        /// Parameters class for CreateTaskStatusView method.
        /// </summary>
        /// <history>
        /// [zhihaoq] 4/25/08 Created
        /// </history>
        public class TaskStatusViewParameters
        {
            #region Private Members
            /// <summary>
            /// Cached name of task status view to create
            /// </summary>
            private string cachedTaskStatusViewName = null;

            /// <summary>
            /// Cached description of task status view to create
            /// </summary>
            private string cachedTaskStatusViewDescription = null;

            /// <summary>
            /// Cached view folder name under which the task status view is created
            /// </summary>
            private string cachedTaskStatusViewFolderName = null;
            #endregion

            #region Constructors
            /// <summary>
            /// Default Constructor
            /// </summary>
            public TaskStatusViewParameters()
            {
            }
            #endregion

            #region Properties
            /// <summary>
            /// name of task status view to create
            /// </summary>
            public string TaskStatusViewName
            {
                get
                {
                    return this.cachedTaskStatusViewName;
                }

                set
                {
                    this.cachedTaskStatusViewName = value;
                }
            }

            /// <summary>
            /// description of task status view to create
            /// </summary>
            public string TaskStatusViewDescription
            {
                get
                {
                    return this.cachedTaskStatusViewDescription;
                }

                set
                {
                    this.cachedTaskStatusViewDescription = value;
                }
            }

            /// <summary>
            /// view folder name under which the task status view is created
            /// </summary>
            public string TaskStatusViewFolderName
            {
                get
                {
                    return this.cachedTaskStatusViewFolderName;
                }

                set
                {
                    this.cachedTaskStatusViewFolderName = value;
                }
            }

            #endregion
        }
        #endregion

        #region TaskStatusGridViewFields Class
        /// <summary>
        /// Parameters class for CreateTaskStatusGrid method.
        /// </summary>
        /// <history>
        /// [v-eachu] 9/14/09 Created
        /// </history>
        public class TaskStatusGridViewFields
        {
            #region Private Members
            /// <summary>
            /// Cached status of task status
            /// </summary>
            private string cachedTaskStatusStatus = null;

            /// <summary>
            /// Cached task name of task status
            /// </summary>
            private string cachedTaskStatusTaskName = null;

            /// <summary>
            /// Cached start time that task began to run
            /// </summary>
            private string cachedTaskStatusStartTime = null;

            /// <summary>
            /// Cached Task Target Class of task status
            /// </summary>
            private string cachedTaskTargetClass = null;

            #endregion

            #region Constructors
            /// <summary>
            /// Default Constructor
            /// </summary>
            public TaskStatusGridViewFields()
            {
            }
            #endregion

            #region Properties
            /// <summary>
            /// status of task status
            /// </summary>
            public string TaskStatusStatus
            {
                get
                {
                    return this.cachedTaskStatusStatus;
                }

                set
                {
                    this.cachedTaskStatusStatus = value;
                }
            }

            /// <summary>
            /// task name of task status
            /// </summary>
            public string TaskStatusTaskName
            {
                get
                {
                    return this.cachedTaskStatusTaskName;
                }

                set
                {
                    this.cachedTaskStatusTaskName = value;
                }
            }

            /// <summary>
            /// start time that task began to run
            /// </summary>
            public string TaskStatusStartTime
            {
                get
                {
                    return this.cachedTaskStatusStartTime;
                }

                set
                {
                    this.cachedTaskStatusStartTime = value;
                }
            }

            /// <summary>
            /// task target class of task status
            /// </summary>
            public string TaskTargetClass
            {
                get
                {
                    return this.cachedTaskTargetClass;
                }

                set
                {
                    this.cachedTaskTargetClass = value;
                }
            }

            #endregion
        }
        #endregion

    }
}
