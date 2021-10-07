//  -----------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Events.cs">
//     Copyright ?Microsoft Corporation 2005
// </copyright>
// <project>
//     Mom.Test.UI.Core.Console.MonitoringConfiguration.Events
// </project>
// <summary>
//     This class contains helper fucntions for automation of the 
//     configuration of event monitors and rules 
// </summary>
// <history>
//      [barryw] 23NOV05 Created
//      [ruhim]  02/02/06   Adding Strings sub class   
// </history>
//  -----------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Events
{
    #region Using directives

    using System;
    using System.Collections.Generic;
    using System.Text;
    using Maui.Core;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs;
    using Maui.Core.Utilities;
    using System.Collections;
    using Maui.Core.WinControls;
    using System.Globalization;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;

    #endregion

    /// <summary>
    /// Class to assist test automation for monitoring/data collection
    /// configuration related to events.
    /// </summary>
    public class Events
    {
        #region Constants sections

        #endregion

        #region Member variables section

        /// <summary>
        /// Track position of cursor on the event property pop-up dialog.
        /// </summary>
        private FocusOn focusOn = FocusOn.PropertyRadioButton;

        /// <summary>
        /// Properties in the known event propertyies drop down list.
        /// </summary>
        private ArrayList properties = null;

        #endregion

        #region  Constructors section

        /// <summary>
        /// Constructor.
        /// </summary>
        public Events()
        {
            // This prevents the creation of a default constructor
        }

        #endregion

        #region Enumerators section

        /// <summary>
        /// Indicates which event property/parameter control has focus.
        /// </summary>
        private enum FocusOn
        {
            /// <summary>
            /// Property Radio Button
            /// </summary>
            PropertyRadioButton = 1,

            /// <summary>
            /// Parameter Radio Button
            /// </summary>
            ParameterRadioButton,

            /// <summary>
            /// Property ComboBox
            /// </summary>
            PropertyComboBox,

            /// <summary>
            /// Parameter TextBox
            /// </summary>
            ParameterTextBox
        }

        #endregion  // Enumerators section

        #region Properties section

        #endregion

        #region Methods section

        #region Public non-static methods section

        /// <summary>
        /// Provides access to an open instance of LogNameDialog
        /// </summary>
        /// <param name="title">Wizard dialog title.</param>
        /// <returns>LogNameDialog dialog.</returns>
        /// <remarks>Created using 'UI Get Class' snippet</remarks>
        public LogNameDialog GetLogNameDialog(MonitoringConfiguration.WindowCaptions title)
        {
            Utilities.LogMessage("Rules.GetLogNameDialog(...)");

            // Access the LogNameDialog dialog.
            LogNameDialog dialog = null;

            // Open the dialog
            try
            {
                dialog = new LogNameDialog(
                    CoreManager.MomConsole,
                    MonitoringConfiguration.WindowCaptions.MonitorWizard);

                // wait until application is ready
                UISynchronization.WaitForUIObjectReady(
                    dialog,
                    Constants.DefaultDialogTimeout);
                Utilities.LogMessage("Rules.GetLogNameDialog:: " +
                    "LogNameDialog Opened");

                // Make sure dialog is in Foreground.
                dialog.Extended.SetFocus();
                Utilities.LogMessage("Rules.GetLogNameDialog:: " +
                    "Focus set to LogNameDialog");

                return dialog;
            }
            catch
            {
                if (dialog != null)
                {
                    // On a failure try to close the dialog.
                    dialog.SendKeys(KeyboardCodes.Esc);
                    Utilities.LogMessage("Rules.GetLogNameDialog:: " +
                        "Clicked the Escape key on the LogNameDialog dialog.");

                    // Save an image of the screen for diagnostic information.
                    Utilities.TakeScreenshot("GetLogNameDialog_Confirmation");

                    // Respond Yes to the confirmation dialog
                    CoreManager.MomConsole.ConfirmChoiceDialog(
                        MomConsoleApp.ButtonCaption.Yes,
                        MomConsoleApp.Strings.DialogTitle,
                        StringMatchSyntax.ExactMatch,
                        MomConsoleApp.ActionIfWindowNotFound.Error);

                    // Save an image of the screen for diagnostic information.
                    Utilities.TakeScreenshot("GetLogNameDialog_Cleared");
                }
                throw;
            }
        }

        /// <summary>
        /// This method is designed to navigate the event log
        /// file configuration wizard dialogs when creating new
        /// objects such as monitors and data collection rules.
        /// </summary>
        /// <param name="logName">Short log file name.</param>
        /// <param name="title">Window caption.</param>
        /// <history>
        /// 	[barryw] 01JAN06 Created.
        /// </history>
        public void NavigateEventLogDialogs(string logName, MonitoringConfiguration.WindowCaptions title)
        {
            Utilities.LogMessage("Events.NavigateEventLogDialogs(...)");

            LogNameDialog secondScreen = new LogNameDialog(
                CoreManager.MomConsole,
                title);

            // Click on the browse button
            secondScreen.ClickButton1();
            Utilities.LogMessage("Events.NavigateEventLogDialogs:: " +
                "Clicked on the log file browse button.");

            // Create an instance of the select event log screen
            SelectEventLogDialog window = new SelectEventLogDialog();

            window.Controls.EventLogNameListView.MultiSelect(logName);
            UISynchronization.WaitForUIObjectReady(window, Constants.DefaultDialogTimeout);
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(window.Controls.OKButton, Constants.OneMinute);
            window.ClickOK();
            Utilities.LogMessage("Events.NavigateEventLogDialogs:: " +
                "Clicked OK to choose the event log.");

            CoreManager.MomConsole.WaitForDialogClose(window, 2);
            secondScreen.Extended.SetFocus();

            secondScreen.ScreenElement.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(secondScreen.Controls.NextButton, Constants.DefaultDialogTimeout);

            secondScreen.Controls.NextButton.Extended.SetFocus();
            secondScreen.ClickNext();
            Utilities.LogMessage("Events.NavigateEventLogDialogs:: " +
                "Clicked The 'Next' button.");
        }

        #region BuildExpressionDialog methods

        /// <summary>
        /// Provides access to an open instance of the Build Expression dialog.
        /// </summary>
        /// <param name="title">Window caption</param>
        /// <returns>Reference to BuildExpressionDialog</returns>
        public Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs.BuildExpressionDialog GetBuildExpressionDialog(
            MonitoringConfiguration.WindowCaptions title)
        {
            Utilities.LogMessage("Events.GetBuildExpressionDialog(...)");

            // Access the dialog.
            Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs.BuildExpressionDialog filterDialog = null;

            // Open the dialog
            try
            {
                filterDialog = new Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs.BuildExpressionDialog(
                    CoreManager.MomConsole, title);

                // wait until application is ready
                UISynchronization.WaitForUIObjectReady(
                    filterDialog,
                    Constants.DefaultDialogTimeout);
                Utilities.LogMessage("Events.GetBuildExpressionDialog:: " +
                    "events filter dialog Opened");

                // Make sure Dialog is in Foreground.
                filterDialog.Extended.SetFocus();
                Utilities.LogMessage("Events.GetBuildExpressionDialog:: Focus set to " +
                    "events filter dialog");

                return filterDialog;
            }
            catch
            {
                if (filterDialog != null)
                {
                    // On a failure try to close the dialog.
                    ////Todo: enhance to try different ways of closing the dialog.
                    // filterDialog.SendKeys(KeyboardCodes.Esc);

                    // Wait for the cancel button to be accessible.
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(filterDialog.Controls.CancelButton);

                    // Click the cancel button
                    filterDialog.ClickCancel();
                    Utilities.LogMessage("Events.GetBuildExpressionDialog:: " +
                        "Clicked the cancel button on the Create Rule Wizard Filter dialog.");

                    // Set dialog to null to prevent later handling from trying to access the dialog.
                    filterDialog = null;

                    // Save an image of the screen for diagnostic information.
                    Utilities.TakeScreenshot("GetBuildExpressionDialog_Confirmation");

                    // Respond Yes to the confirmation dialog
                    CoreManager.MomConsole.ConfirmChoiceDialog(
                        MomConsoleApp.ButtonCaption.Yes,
                        MomConsoleApp.Strings.DialogTitle,
                        StringMatchSyntax.ExactMatch,
                        MomConsoleApp.ActionIfWindowNotFound.Error);

                    // Save an image of the screen for diagnostic information.
                    Utilities.TakeScreenshot("GetBuildExpressionDialog_ClearedForMomConsole");
                }
                throw;
            }
        }

        /// <summary>
        /// This method is designed to edit a parameter cell directly
        /// in the specified grid.
        /// </summary>
        /// <param name="formulaGrid">Formula grid</param>
        /// <param name="rowIndex">row index</param>
        /// <param name="cellValue">value in cell</param>
        public void EditParameterCell(
            Core.Console.MomControls.GridControl formulaGrid,
            int rowIndex,
            string cellValue)
        {
            Utilities.LogMessage(
                "Events.EditParameterCell:: " +
                "Edit Parameter Cell: " + cellValue);

            // Get column position
            ////int columnIndex = formulaGrid.GetColumnTitlePosition(BuildExpressionDialog.Strings.GridValueColumn);
            ////Hack: Have to use this workaround to set the column index due to 
            ////duplicate column headers - bug 55060
            int columnIndex = 0;

            //// This click ia needed. 
            // Click in cell
            formulaGrid.ClickCell(rowIndex, columnIndex);
            //Utilities.LogMessage(
            //    "Events.EditValueCell:: " +
            //    "Sucessfully Clicked on the cell in row,column:" + rowIndex.ToString() + "," + columnIndex.ToString());

            // Set value in cell
            formulaGrid.SetCellValue(formulaGrid.Extended.AccessibleObject.Window, cellValue, DataGridViewCellType.TextBox, Events.Strings.TextEditorWinFormsId);
            Utilities.LogMessage(
                "Events.EditParameterCell:: " +
                "Successfully set value in row, column:" + rowIndex.ToString() + "," + columnIndex.ToString());
        }


        /// <summary>
        /// This method is designed to edit a value cell
        /// in the specified grid.
        /// </summary>
        /// <param name="formulaGrid">Formula grid</param>
        /// <param name="rowIndex">row index</param>
        /// <param name="cellValue">value in cell</param>
        public void EditValueCell(
            Core.Console.MomControls.GridControl formulaGrid,
            int rowIndex,
            string cellValue)
        {
            Utilities.LogMessage(
                "Events.EditValueCell:: " +
                "Edit Value Cell: " + cellValue);

            // Get column position
            ////int columnIndex = formulaGrid.GetColumnTitlePosition(BuildExpressionDialog.Strings.GridValueColumn);
            ////Hack: Have to use this workaround to set the column index due to 
            ////duplicate column headers - bug 55060
            int columnIndex = 2;

            //// This click ia needed. 
            // Click in cell
            formulaGrid.ClickCell(rowIndex, columnIndex);
            //Utilities.LogMessage(
            //    "Events.EditValueCell:: " +
            //    "Sucessfully Clicked on the cell in row,column:" + rowIndex.ToString() + "," + columnIndex.ToString());

            // Set value in cell
            formulaGrid.SetCellValue(formulaGrid.Extended.AccessibleObject.Window, cellValue, DataGridViewCellType.TextBox, Events.Strings.TextEditorWinFormsId);
            Utilities.LogMessage(
                "Events.EditValueCell:: " +
                "Successfully set value in row, column:" + rowIndex.ToString() + "," + columnIndex.ToString());
        }

        /// <summary>
        /// This method is designed to edit a value cell
        /// in the specified grid.
        /// </summary>
        /// <param name="formulaGrid">Formula grid</param>
        /// <param name="rowIndex">row index</param>
        /// <param name="cellValue">value in cell</param>
        /// <param name="comboBox">comboBox control containing value</param>
        /// <exception cref="Maui.Core.WinControls.ComboBox.Exceptions.TextNotFoundException">Unexpected Operator expression.</exception>
        public void EditOperatorCell(
            Core.Console.MomControls.GridControl formulaGrid,
            int rowIndex,
            string cellValue,
            DataGridViewCellType comboBox)
        {
            Utilities.LogMessage(
                "Events.EditOperatorCell:: " + "Edit Value of Cell: " + cellValue);

            const int columnNameDoesNotExist = -1;

            // initialize
            int columnIndex = columnNameDoesNotExist;
            try
            {
                Utilities.LogMessage(
                    "Events.EditOperatorCell:: " +
                    "Parameter value for rowIndex:=" + rowIndex.ToString());
                Utilities.LogMessage(
                    "Events.EditOperatorCell:: " +
                    "Parameter value for cellValue:=[" + cellValue + "]");

                // Get column position
                columnIndex = formulaGrid.GetColumnTitlePosition(BuildExpressionDialog.Strings.GridOperatorColumn);

                //// This click is needed.
                // Click in cell
                formulaGrid.ClickCell(rowIndex, columnIndex);
                Utilities.LogMessage(
                    "Events.EditOperatorCell:: " +
                    "Sucessfully Clicked on the cell in row,column:" + rowIndex.ToString() + "," + columnIndex.ToString());

                // [v-raienl] - No need to click the cell second time here even when inserting a row. On the contrary, clicking twice
                // on cell will cause test issue here because clicking twice on combo box will make the drop-down be displayed, but the
                // following method SetCellValue won't work correctly if the drop-down is shown.

                ////Hack: Extra click needed when Inserting a row.
                // Click in cell
                //formulaGrid.ClickCell(rowIndex, columnIndex);
                //Utilities.LogMessage(
                //    "Events.EditOperatorCell:: " +
                //    "Sucessfully Clicked on the cell in row,column:" + rowIndex.ToString() + "," + columnIndex.ToString());

                // Set value in cell
                formulaGrid.SetCellValue(formulaGrid, cellValue, DataGridViewCellType.ComboBox, Events.Strings.OperatorComboBoxEditorWinFormsId);
                Utilities.LogMessage(
                    "Events.EditOperatorCell:: " +
                    "Successfully set value in row, column:" + rowIndex.ToString() + "," + columnIndex.ToString());
            }
            catch (Maui.Core.WinControls.ComboBox.Exceptions.TextNotFoundException textNotFoundException)
            {
                Utilities.LogMessage(
                    "Events.EditOperatorCell:: " +
                    "<<<EXCEPTION>>> " + textNotFoundException.Message + textNotFoundException.StackTrace);
                Utilities.LogMessage(
                    "Events.EditOperatorCell:: " +
                    "verify the test data is appropriate for this row, some operator expressions may not apply to the property cell's value.");

                if (columnIndex != columnNameDoesNotExist)
                {
                    Utilities.LogMessage(
                        "Events.EditOperatorCell:: " +
                        "Debugging Info: Value in cell: " + formulaGrid.GetCellValue(rowIndex, columnIndex));
                }

                // re-throw
                throw;
            }
        }

        /// <summary>
        /// This method is designed to edit a Property cell
        /// in the specified grid with a parameter number.
        /// </summary>
        /// <param name="formulaGrid">Formula grid</param>
        /// <param name="rowIndex">row index</param>
        /// <param name="cellValue">value in cell</param>
        public void EditParameterItem(
            Core.Console.MomControls.GridControl formulaGrid,
            int rowIndex,
            string cellValue)
        {
            ////Todo: Create overwride method which accesses the 
            ////      ParameterTextBox control directly. 

            ////int columnIndex = formulaGrid.GetColumnTitlePosition(BuildExpressionDialog.Strings.GridPropertyColumn);
            ////Hack: Workaround for duplicate column name - hardcoded column number.
            int columnIndex = 0;

            this.PressChevronButton(formulaGrid, rowIndex, columnIndex);
            //Workaround since the focus is set to FocusOn.PropertyComboBox when the EditPropertyItem is called. 
            //This function is called before that, so we have the this.focusOn set to wrong value. 
            //Setting back to the right value. 
            this.focusOn = FocusOn.PropertyRadioButton;

            // Based on starting position move to parameter textBox + spinner.
            switch (this.focusOn)
            {
                case Events.FocusOn.PropertyRadioButton:
                    {
                        // first time use of row.
                        // Move to parameter radio button.
                        Keyboard.SendKeys(KeyboardCodes.DownArrow);
                        Utilities.LogMessage("Events.EditParameterItem:: " +
                            "Chose parameter radio button" + " using the DownArrow.");

                        // Tab to the parameter textBox + spinner, 
                        Keyboard.SendKeys(KeyboardCodes.Tab);
                        Utilities.LogMessage("Events.EditParameterItem:: " + "Tabbed.");
                        break;
                    }
                case Events.FocusOn.ParameterRadioButton:
                    {
                        // Tab to the parameter textBox + spinner, 
                        Keyboard.SendKeys(KeyboardCodes.Tab);
                        Utilities.LogMessage("Events.EditParameterItem:: " + "Tabbed.");
                        break;
                    }
                case Events.FocusOn.PropertyComboBox:
                    {
                        // Tab to the property radio boutton, 
                        Keyboard.SendKeys(KeyboardCodes.Tab);
                        Utilities.LogMessage("Events.EditParameterItem:: " + "Tabbed.");

                        // Move to parameter radio button.
                        Keyboard.SendKeys(KeyboardCodes.DownArrow);
                        Utilities.LogMessage("Events.EditParameterItem:: " +
                            "Chose parameter radio button" + " using the DownArrow.");

                        // Tab to the parameter textBox + spinner, 
                        Keyboard.SendKeys(KeyboardCodes.Tab);
                        Utilities.LogMessage("Events.EditParameterItem:: " + "Tabbed.");
                        break;
                    }
                case Events.FocusOn.ParameterTextBox:
                    {
                        break;
                    }
            }

            // Select the existing parameter number
            Keyboard.SendKeys(KeyboardCodes.Shift + KeyboardCodes.End);
            Utilities.LogMessage("Events.EditParameterItem:: " + "Selected the existing parameter number " + " using Shift + End.");

            // Set the parameter number
            Keyboard.SendKeys(cellValue);
            Utilities.LogMessage("Events.EditParameterItem:: " + "Parameter number is set.");

            // Put parameter in grid cell.
            Keyboard.SendKeys(KeyboardCodes.Enter);
            Utilities.LogMessage("Events.EditParameterItem:: " + "Parameter is in grid cell.");
            this.focusOn = Events.FocusOn.ParameterTextBox;
        }

        /// <summary>
        /// Provides access to an open instance of EventPropertyCellEditorFormDialog
        /// </summary>
        /// <returns>EventPropertyCellEditorFormDialog dialog.</returns>
        /// <remarks>Created using 'UI Get Class' snippet</remarks>
        public EventPropertyCellEditorFormDialog GetEventPropertyCellEditorFormDialog()
        {
            // Access the EventPropertyCellEditorFormDialog dialog.
            EventPropertyCellEditorFormDialog dialog = null;

            // Open the dialog
            try
            {
                dialog = new EventPropertyCellEditorFormDialog(
                    CoreManager.MomConsole);

                // wait until application is ready
                UISynchronization.WaitForUIObjectReady(
                    dialog,
                    Constants.DefaultDialogTimeout);
                Utilities.LogMessage("GetEventPropertyCellEditorFormDialog:: " +
                    "EventPropertyCellEditorFormDialog Opened");

                // Make sure dialog is in Foreground.
                dialog.Extended.SetFocus();
                Utilities.LogMessage("GetEventPropertyCellEditorFormDialog:: Focus set to " +
                    "EventPropertyCellEditorFormDialog");

                return dialog;
            }
            catch
            {
                if (dialog != null)
                {
                    // On a failure try to close the dialog.
                    dialog.SendKeys(KeyboardCodes.Esc);
                    Utilities.LogMessage("GetEventPropertyCellEditorFormDialog:: " +
                        "Clicked the Escape key on the EventPropertyCellEditorFormDialog dialog.");

                    // Save an image of the screen for diagnostic information.
                    Utilities.TakeScreenshot("GetEventPropertyCellEditorFormDialog_Cleared");
                }
                throw;
            }
        }

        #region EditPropertyItem

        /// <summary>
        /// This method is designed to edit a Property cell
        /// in the specified grid with a property name.
        /// </summary>
        /// <param name="formulaGrid">Formula grid</param>
        /// <param name="rowIndex">row index</param>
        /// <param name="localizedColumnName">localized column name</param>
        /// <param name="propertyName">property name</param>
        public void EditPropertyItem(
            Core.Console.MomControls.GridControl formulaGrid,
            int rowIndex,
            string localizedColumnName,
            string propertyName)
        {
            ////int columnIndex = formulaGrid.GetColumnTitlePosition(buildExpression.ColumnName);
            ////Hack: Workaround for duplicate column name - hardcoded column number.
            int columnIndex = 0;

            // On first time create a collection of the known event properties.
            if (null == this.properties)
            {
                Utilities.LogMessage(
                    "Events.EditPropertyItem:: " +
                    "Populating the property collection");
                this.properties = this.GetPropertyCollection(
                    formulaGrid,
                    rowIndex,
                    columnIndex,
                    ref this.focusOn);
            }

            #region Choose property name

            Utilities.LogMessage(
                "Events.EditPropertyItem:: " +
                "Selecting desired property: [" + propertyName + "]");

            int index = this.properties.IndexOf(propertyName);

            const int propertyNameNotFound = -1;
            if (index != propertyNameNotFound)
            {
                this.PressChevronButton(formulaGrid, rowIndex, columnIndex);

                /* testing code
                EventPropertyCellEditorFormDialog eventPropertyDialog = GetEventPropertyCellEditorFormDialog();
                eventPropertyDialog.EventPropertiesText = propertyName;
                */

                Utilities.LogMessage(
                    "Events.EditPropertyItem:: " +
                    "Desired cell value's index: [" + index.ToString() + "]");
                this.ChooseProperty(index, ref this.focusOn);
            }
            else
            {
                throw new ComboBox.Exceptions.TextNotFoundException(
                    "Events.EditPropertyItem:: " +
                    "Property name not found: " + propertyName +
                    " verify the resource id is correct.");
            }

            #endregion

            #region Verify property name is in the cell.

            Sleeper.Delay(1000);
            string effectiveCellValue = formulaGrid.GetCellValue(rowIndex, columnIndex);
            Utilities.LogMessage(
                "Events.EditPropertyItem:: " +
                "Resuting cell value: " + propertyName);
            if (String.Compare(effectiveCellValue, propertyName, false, CultureInfo.CurrentCulture) != 0)
            {
                throw new DataGrid.Exceptions.FailedToSetValueException(
                    "Events.EditPropertyItem:: " +
                    "Actual cell value: [" + effectiveCellValue +
                    "] does not equal expected cell value: [" + propertyName + "].");
            }

            #endregion
        }

        /// <summary>
        /// This method is designed to edit a Property cell
        /// in the specified grid with a property name.
        /// </summary>
        /// <param name="formulaGrid">Formula grid</param>
        /// <param name="rowIndex">row index</param>
        /// <param name="localaizedPropertyName">localized column name</param>
        /// <history>
        /// 	[barryw] 03JAN06 Removed unused creation of the BuildExpressionDialog from this method.
        /// </history>
        public void EditPropertyItem(
            Core.Console.MomControls.GridControl formulaGrid,
            int rowIndex,
            string localaizedPropertyName)
        {
            int columnIndex;

            // Get column position
            ////Hack: subtract one to get correct column index.
            ////int columnIndex = formulaGrid.GetColumnTitlePosition(BuildExpressionDialog.Strings.GridPropertyColumn);
            ////Hack: Workaround for duplicate column name - hardcoded column number.
            columnIndex = 0;
            // This click seems to be needed.
            // Click in cell.
            formulaGrid.ClickCell(rowIndex, columnIndex);
            UISynchronization.WaitForUIObjectReady(formulaGrid.Extended.AccessibleObject, 1000);
            UISynchronization.WaitForProcessReady(formulaGrid.Extended.AccessibleObject.Window, 1000);

            // Click chevon buuton in property cell.
            formulaGrid.InvokeCellButton(rowIndex, columnIndex);
            Utilities.LogMessage(
                "Events.EditPropertyItem:: " +
                "Sucessfully invoked the chevron button:" +
                rowIndex.ToString() + "," + columnIndex.ToString());

            EventPropertyCellEditorFormDialog eventPropertyDialog = this.GetEventPropertyCellEditorFormDialog();
            eventPropertyDialog.EventPropertiesText = localaizedPropertyName;

            // Choose the property name currently selected in the dropdown
            Keyboard.SendKeys(KeyboardCodes.Enter);

            // Save on which control the focus set on this dialog.
            this.focusOn = Events.FocusOn.PropertyComboBox;

            #region Verify property name is in the cell.

            Sleeper.Delay(1000);
            string effectiveCellValue = formulaGrid.GetCellValue(rowIndex, columnIndex);
            Utilities.LogMessage(
                "Events.EditPropertyItem:: " +
                "Resuting cell value: " + localaizedPropertyName);
            if (String.Compare(effectiveCellValue, localaizedPropertyName, false, CultureInfo.CurrentCulture) != 0)
            {
                throw new DataGrid.Exceptions.FailedToSetValueException(
                    "Events.EditPropertyItem:: " +
                    "Actual cell value: [" + effectiveCellValue +
                    "] does not equal expected cell value: [" + localaizedPropertyName + "].");
            }

            #endregion
        }

        #endregion  // EditPropertyItem

        /// -------------------------------------------------------------------
        /// <summary>
        /// Filter the 'dynamic' members to be in the group
        /// based on the test data.
        /// </summary>
        /// <param name="filterDialog">rule filter dialog</param>
        /// <param name="mcfvarmapRecords">test data</param>
        /// -------------------------------------------------------------------
        public void CreateFilterFormula(
            Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs.BuildExpressionDialog filterDialog,
            ArrayList mcfvarmapRecords)
        {
            Utilities.LogMessage("Events.CreateFilterFormula(...)");
            try
            {
                Core.Console.MomControls.GridControl formulaGrid = null;
                Mcf.BuildExpression buildExpression;
                foreach (string mcfvarmapRecord in mcfvarmapRecords)
                {
                    // Get test data for each grid action/row expression and
                    // loop through to process each row, usually a minimum of 2 rows.
                    Utilities.LogMessage(
                        "Events.CreateFilterFormula:: " +
                        "attempting to edit the expression row.");

                    #region Create instance of Grid Control

                    ////Todo: Why do we have GridControl.ControlIDs.FormulaGrid as 
                    ////       well as the public constant in the dialog used here.
                    if (null == formulaGrid)
                    {
                        formulaGrid = new Core.Console.MomControls.GridControl(
                        filterDialog,
                        Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs.BuildExpressionDialog.ControlIDs.FormulaGrid);
                    }

                    if (formulaGrid != null)
                    {
                        Utilities.LogMessage(
                            "Events.CreateFilterFormula:: " +
                            "FormulaGrid found");
                    }
                    else
                    {
                        throw new NullReferenceException(
                            "Events.CreateFilterFormula:: " +
                            "Unable to find FormulaGrid");
                    }

                    #endregion  // Create instance of Grid Control

                    #region row action

                    // Get the row action to perform.
                    ////Todo: Create buildExpression Action VarmapConstant.Values constants. 
                    buildExpression = Mcf.GetBuildExpressionFromXml(
                            mcfvarmapRecord);

                    Utilities.LogMessage(
                        "Events.CreateFilterFormula:: " +
                        "Number of rows currently in the grid: " + formulaGrid.Rows.Count.ToString() + ".");
                    Utilities.LogMessage(
                        "Events.CreateFilterFormula:: " +
                        "Current row index: " + formulaGrid.Rows.Count.ToString() + ".");

                    //move this validation to after row action
                    // validate row index.
                    //if (buildExpression.rowIndex > formulaGrid.Rows.Count)
                    //{
                     //   throw new ArgumentOutOfRangeException("The row index must not be greater than the number of existing rows.");
                    //}

                    Utilities.LogMessage(
                        "Events.CreateFilterFormula:: " +
                        "Processing reposition instruction:" + buildExpression.reposition + " for row:" + buildExpression.rowIndex);

                    // Reposition cursor
                    switch (buildExpression.reposition)
                    {
                        case "no":
                            {
                                // leave cursor where it currently is.
                                break;
                            }
                        case "rowheader":
                            {
                                // position cursor on the row selector column of the row.
                                if (String.Compare(buildExpression.action, Mcf.Values.Insert) == 0)
                                {
                                    // When inserting a new row position the cursor on the 
                                    // row above.
                                    formulaGrid.ClickCell(buildExpression.rowIndex - 1, 0);
                                }
                                else
                                {
                                    formulaGrid.ClickCell(buildExpression.rowIndex, 0);
                                }
                                break;
                            }
                        default:
                            {
                                throw new NotImplementedException("buildExpression.reposition: " + buildExpression.reposition);
                            }
                    }

                    Utilities.LogMessage(
                        "Events.CreateFilterFormula:: " +
                        "Processing action instruction: " + buildExpression.action);

                    // Perform action
                    switch (buildExpression.action)
                    {
                        case Mcf.Values.Edit:
                            {
                                Utilities.LogMessage(
                                    "Events.CreateFilterFormula:: " +
                                    "Row action is: " + buildExpression.action);
                                ////Todo: Verify the row (index) to edit exists.
                                break;
                            }
                        case Mcf.Values.Insert:
                            {
                                Utilities.LogMessage(
                                    "Events.CreateFilterFormula:: " +
                                    "Row action is: " + buildExpression.action);
                                switch (buildExpression.actionMethod)
                                {
                                    case "button":
                                        {
                                            switch (buildExpression.actionType)
                                            {
                                                case "default":
                                                    {
                                                        // Invoke default insert using Button click
                                                        ////Todo: or shortcut Alt+s, Shift+Alt+s
                                                        // Click default toolbar Insert button.
                                                        CoreManager.MomConsole.InvokeToolBarButton(
                                                            filterDialog.Controls.FormulaToolStrip,
                                                            BuildExpressionDialog.Strings.FormulaToolStripInsert);
                                                        //Tab so the focus moves to the Expression
                                                        Keyboard.SendKeys(KeyboardCodes.Tab);
                                                        Keyboard.SendKeys(KeyboardCodes.Enter);
                                                        // Insert results in the focus being on the property
                                                        // radio button due to product bug# ????
                                                        this.focusOn = Events.FocusOn.PropertyRadioButton;
                                                        break;
                                                    }
                                                case "Expression":
                                                    {
                                                        ////Todo: invoke insert expression using context menu
                                                        ////      or shortcut Alt+?, Shift+Alt+?
                                                        //// Insert results in the focus being on the property
                                                        //// radio button due to product bug# ????
                                                        ////this.focusOn = Events.FocusOn.PropertyRadioButton;
                                                        throw new NotImplementedException("buildExpression.actionType: " + buildExpression.actionType);
                                                    }
                                                case "AndGroup":
                                                    {
                                                        ////Todo: invoke insert 'And Group' using context menu
                                                        ////      or shortcut Alt+?, Shift+Alt+?
                                                        throw new NotImplementedException("buildExpression.actionType: " + buildExpression.actionType);
                                                    }
                                                case "OrGroup":
                                                    {
                                                        ////Todo: invoke insert 'Or Group' using context menu
                                                        ////      or shortcut Alt+?, Shift+Alt+?
                                                        throw new NotImplementedException("buildExpression.actionType: " + buildExpression.actionType);
                                                    }
                                                default:
                                                    {
                                                        throw new NotImplementedException("buildExpression.actionType: " + buildExpression.actionType);
                                                    }
                                            }
                                            break;
                                        }
                                    case "shortcut":
                                        {
                                            throw new NotImplementedException("buildExpression.actionMethod: " + buildExpression.actionMethod);
                                        }
                                    case "contextmenu":
                                        {
                                            switch (buildExpression.actionType)
                                            {
                                                case "Expression":
                                                    {
                                                        ////Todo: invoke insert expression using context menu
                                                        /////     or shortcut Alt+?, Shift+Alt+?
                                                        throw new NotImplementedException("buildExpression.actionType: " + buildExpression.actionType);
                                                    }
                                                case "AndGroup":
                                                    {
                                                        ////Todo: invoke insert 'And Group' using context menu
                                                        ////      or shortcut Alt+?, Shift+Alt+?
                                                        throw new NotImplementedException("buildExpression.actionType: " + buildExpression.actionType);
                                                    }
                                                case "OrGroup":
                                                    {
                                                        ////Todo: invoke insert 'Or Group' using context menu
                                                        ////      or shortcut Alt+?, Shift+Alt+?
                                                        throw new NotImplementedException("buildExpression.actionType: " + buildExpression.actionType);
                                                    }
                                                default:
                                                    {
                                                        throw new NotImplementedException("buildExpression.actionType: " + buildExpression.actionType);
                                                    }
                                            }
                                            ////break;
                                        }
                                    default:
                                        {
                                            throw new NotImplementedException("buildExpression.actionMethod: " + buildExpression.actionMethod);
                                        }
                                }
                                break;
                            }
                        case "Delete":
                            {
                                Utilities.LogMessage(
                                    "Events.CreateFilterFormula:: " +
                                    "Row action is: " + buildExpression.action);
                                switch (buildExpression.actionMethod)
                                {
                                    case "button":
                                        {
                                            Keyboard.SendKeys(KeyboardCodes.Tab);
                                            Keyboard.SendKeys(KeyboardCodes.Tab);
                                            // Invoke default delete using Button click
                                            ////Todo: or shortcut Alt+s, Shift+Alt+s
                                            // Click default toolbar delete button.
                                            CoreManager.MomConsole.InvokeToolBarButton(
                                                filterDialog.Controls.FormulaToolStrip,
                                                BuildExpressionDialog.Strings.FormulaToolStripDelete);
                                            break;
                                        }
                                    case "shortcut":
                                        {
                                            throw new NotImplementedException("buildExpression.actionMethod: " + buildExpression.actionMethod);
                                        }
                                    case "contextmenu":
                                        {
                                            throw new NotImplementedException("buildExpression.actionMethod: " + buildExpression.actionMethod);
                                        }
                                    default:
                                        {
                                            throw new NotImplementedException("buildExpression.actionMethod: " + buildExpression.actionMethod);
                                        }
                                }
                                break;
                            }
                        case "SwitchTo":
                            {
                                Utilities.LogMessage(
                                    "Events.CreateFilterFormula:: " +
                                    "Row action is: " + buildExpression.action);
                                switch (buildExpression.actionMethod)
                                {
                                    case "shortcut":
                                        {
                                            throw new NotImplementedException("buildExpression.actionMethod: " + buildExpression.actionMethod);
                                        }
                                    case "contextmenu":
                                        {
                                            switch (buildExpression.actionType)
                                            {
                                                case "AndGroup":
                                                    {
                                                        ////Todo: invoke SwitchTo 'And Group' using context menu
                                                        ////      or shortcut Alt+?, Shift+Alt+?
                                                        throw new NotImplementedException("buildExpression.actionType: " + buildExpression.actionType);
                                                    }
                                                case "OrGroup":
                                                    {
                                                        ////Todo: invoke SwitchTo 'Or Group' using context menu
                                                        ////      or shortcut Alt+?, Shift+Alt+?
                                                        throw new NotImplementedException("buildExpression.actionType: " + buildExpression.actionType);
                                                    }
                                                default:
                                                    {
                                                        throw new NotImplementedException("buildExpression.actionType: " + buildExpression.actionType);
                                                    }
                                            }
                                            ////break;
                                        }
                                    default:
                                        {
                                            throw new NotImplementedException("buildExpression.actionMethod: " + buildExpression.actionMethod);
                                        }
                                }
                                ////break;
                            }
                        case "Collapse":
                            {
                                Utilities.LogMessage(
                                    "Events.CreateFilterFormula:: " +
                                    "Row action is: " + buildExpression.action);
                                switch (buildExpression.actionMethod)
                                {
                                    case "shortcut":
                                        {
                                            throw new NotImplementedException("buildExpression.actionMethod: " + buildExpression.actionMethod);
                                        }
                                    case "contextmenu":
                                        {
                                            throw new NotImplementedException("buildExpression.actionMethod: " + buildExpression.actionMethod);
                                        }
                                    default:
                                        {
                                            throw new NotImplementedException("buildExpression.actionMethod: " + buildExpression.actionMethod);
                                        }
                                }
                                ////break;
                            }
                        default:
                            {
                                throw new ArgumentException(
                                    "Events.CreateFilterFormula:: " +
                                    "Unexpected action value: " +
                                    buildExpression.action);
                            }
                    }

                    // validate row index.
                    if (buildExpression.rowIndex > formulaGrid.Rows.Count)
                    {
                        throw new ArgumentOutOfRangeException("The row index must not be greater than the number of existing rows.");
                    }

                    #endregion  // row action

                    #region modify cell values

                    // For edit/insert modify cell values.
                    switch (buildExpression.action)
                    {
                        case Mcf.Values.Edit:
                        case Mcf.Values.Insert:
                            {
                                #region Edit Property Cell

                                Utilities.LogMessage(
                                    "Events.CreateFilterFormula:: " +
                                    "Edit Property Cell.");
                                buildExpression = Mcf.GetBuildExpressionFromXml(
                                    mcfvarmapRecord,
                                    Mcf.Values.PropertyColumnName);

                                if (String.Compare(buildExpression.columnName, Mcf.Values.PropertyColumnName) == 0)
                                {
                                    switch (buildExpression.dataType)
                                    {
                                        case Mcf.Values.DataTypeProperty:
                                            {
                                                string localizedPropertyName =
                                                    MonitoringConfiguration.GetEventPropertyName(buildExpression.editValue);
                                                Utilities.LogMessage(
                                                    "Events.EditPropertyItem:: " +
                                                    "localized property name is: " + localizedPropertyName);

                                                /*
                                                //// Todo: Add support for keyboard/menu actions, e.g.,
                                                ////       switch buildExpression.EditMethod
                                                ////           case "keyboard":
                                                ////           // Set the value in the Property column. 
                                                ////           this.events.EditPropertyItem(
                                                ////               formulaGrid,
                                                ////               buildExpression.RowIndex,
                                                ////               buildExpression.ColumnName,
                                                ////               localizedPropertyName);
                                                */

                                                // Set the value in the Property column. 
                                                this.EditPropertyItem(
                                                    formulaGrid,
                                                    buildExpression.rowIndex,
                                                    localizedPropertyName);
                                                break;
                                            }
                                        case Mcf.Values.DataTypeParameter:
                                            {
                                                Utilities.LogMessage(
                                                    "Events.EditParameterItem:: " +
                                                    "Parameter name is: " + buildExpression.editValue);
                                                // Set the value in the Property column. 
                                                this.EditParameterItem(
                                                    formulaGrid,
                                                    buildExpression.rowIndex,
                                                    buildExpression.editValue);
                                                break;
                                            }
                                        case "customer":
                                            {
                                                Utilities.LogMessage(
                                                    "Events.EditCustomerItem:: " +
                                                    "Parameter name is: " + buildExpression.editValue);
                                                // Set the value in the Property column. 
                                                // Set the value in the Value column. 
                                                this.EditParameterCell(
                                                    formulaGrid,
                                                    buildExpression.rowIndex,
                                                    buildExpression.editValue);
                                                break;
                                            }
                                        default:
                                            {
                                                string errorMessage = "Events.CreateFilterFormula:: " + "Unexpected formula data type: " + buildExpression.dataType;
                                                Utilities.LogMessage(errorMessage);
                                                throw new ArgumentException(errorMessage);
                                            }
                                    }
                                }
                                else
                                {
                                    Utilities.LogMessage(
                                        "Events.CreateFilterFormula:: " +
                                        "No test data provided for column: " +
                                        Mcf.Values.PropertyColumnName +
                                        " but this may be by design.");
                                }

                                #endregion

                                #region Edit Operator Cell

                                Utilities.LogMessage(
                                    "Events.CreateFilterFormula:: " +
                                    "Edit Operator Cell.");
                                buildExpression = Mcf.GetBuildExpressionFromXml(
                                    mcfvarmapRecord,
                                    Mcf.Values.OperatorColumnName);

                                // if we are editing the cell in this column,
                                if (String.Compare(buildExpression.columnName, Mcf.Values.OperatorColumnName) == 0)
                                {
                                    // Get the localized operator expression
                                    string localizedOperatorExpression =
                                        MonitoringConfiguration.GetOperatorValue(buildExpression.editValue);

                                    // set the value in the Operator column. 
                                    this.EditOperatorCell(
                                        formulaGrid,
                                        buildExpression.rowIndex,
                                        localizedOperatorExpression,
                                        DataGridViewCellType.ComboBox);
                                }
                                else
                                {
                                    // log a message.
                                    Utilities.LogMessage(
                                        "Events.CreateFilterFormula:: " +
                                        "No test data provided for column: " +
                                        Mcf.Values.OperatorColumnName +
                                        " but this may be by design.");
                                }

                                #endregion // Edit Operator Cell.

                                #region Edit Value Cell.

                                Utilities.LogMessage(
                                    "Events.CreateFilterFormula:: " +
                                    "Edit Value Cell.");
                                buildExpression = Mcf.GetBuildExpressionFromXml(
                                    mcfvarmapRecord,
                                    Mcf.Values.ValueColumnName);

                                if (String.Compare(buildExpression.columnName, Mcf.Values.ValueColumnName) == 0)
                                {
                                    // Set the value in the Value column. 
                                    this.EditValueCell(
                                        formulaGrid,
                                        buildExpression.rowIndex,
                                        buildExpression.editValue);
                                }
                                else
                                {
                                    Utilities.LogMessage(
                                        "Events.CreateFilterFormula:: " +
                                        "No test data provided for column: " +
                                        Mcf.Values.ValueColumnName +
                                        " but this may be by design.");
                                }

                                #endregion // Edit Value Cell.
                            }
                            break;
                    }

                    //Taking a screeshot of every Row added in the formula Builder. 
                    Utilities.TakeScreenshot("CreateFilterFormula");

                    #endregion
                }
            }
            catch (Maui.Core.WinControls.ComboBox.Exceptions.TextNotFoundException textNotFoundException)
            {
                Utilities.LogMessage(
                    "Events.CreateFilterFormula:: " +
                    "Exception occurred in: " + textNotFoundException.InnerException.TargetSite + " with message: " + textNotFoundException.Message);

                // Rethrow the exception.
                throw;
            }
            ////Todo: replace generic exception with specific exceptions.
            catch (Exception e)
            {
                Utilities.LogMessage(
                    "Events.CreateFilterFormula:: " +
                    "Exception: " + e.Message);

                // Rethrow the exception.
                throw;
            }

        }

        #endregion

        #endregion

        #region Private non-static methods section

        /// <summary>
        /// Choose an event property name by its index position 
        /// in the the dropdown list. 
        /// </summary>
        /// <param name="index">Zero based index</param>
        /// <param name="focusOn">current focus</param>
        private void ChooseProperty(int index, ref FocusOn focusOn)
        {
            Utilities.LogMessage("Events.ChooseProperty(...)");

            Utilities.LogMessage("Events.ChooseProperty:: " + "index:=" + index.ToString());

            // Based on starting position move to property comboBox.
            switch (focusOn)
            {
                case FocusOn.PropertyComboBox:
                    {
                        Utilities.LogMessage("Events.ChooseProperty:: " + "navigating from property comboBox.");

                        // do nothing.
                        break;
                    }
                case FocusOn.PropertyRadioButton:
                    {
                        Utilities.LogMessage("Events.ChooseProperty:: " + "navigating from property radio button.");

                        // First time the pop-up is displayed the focus is on the 
                        // radio button - bug ????.
                        // Tab to the known event property dropdown control, 
                        ////Hack: due to tab order bug ???? tab twice.
                        Keyboard.SendKeys(KeyboardCodes.Tab);
                        Utilities.LogMessage("Events.ChooseProperty:: " + "Tabbed.");

                        Keyboard.SendKeys(KeyboardCodes.Tab);
                        Utilities.LogMessage("Events.ChooseProperty:: " + "Tabbed.");
                        break;
                    }
                case FocusOn.ParameterRadioButton:
                    {
                        // Move to property radio button.
                        Keyboard.SendKeys(KeyboardCodes.UpArrow);
                        Utilities.LogMessage("Events.ChooseProperty:: " +
                            "Chose property radio button" + " using the UpArrow.");

                        // Tab to the parameter textBox + spinner, 
                        Keyboard.SendKeys(KeyboardCodes.Tab);
                        Utilities.LogMessage("Events.ChooseProperty:: " + "Tabbed.");
                        break;
                    }
                case FocusOn.ParameterTextBox:
                    {
                        // Tab to the parameter radio button. 
                        Keyboard.SendKeys(KeyboardCodes.Tab);
                        Utilities.LogMessage("Events.ChooseProperty:: " +
                            "Tabbed to the parameter radio button.");

                        // Move to property radio button.
                        Keyboard.SendKeys(KeyboardCodes.UpArrow);
                        Utilities.LogMessage("Events.ChooseProperty:: " +
                            "Chose property radio button" + " using the UpArrow.");

                        // Tab to the property comboBox. 
                        Keyboard.SendKeys(KeyboardCodes.Tab);
                        Utilities.LogMessage("Events.ChooseProperty:: " +
                            "Tabbed to the property comboBox.");
                        break;
                    }
            }

            // Expand the dropdown list
            Keyboard.SendKeys(KeyboardCodes.Alt + KeyboardCodes.DownArrow);
            Sleeper.Delay(500);
            Utilities.LogMessage("Events.ChooseProperty:: " + "Expanded the dropdown " + "using Alt + DownArrow.");

            // Position at top item
            Keyboard.SendKeys(KeyboardCodes.Ctrl + KeyboardCodes.Home);
            Sleeper.Delay(1000);
            Utilities.LogMessage("Events.ChooseProperty:: " + "Positioned at top item " + "using Ctrl + Home.");

            // Don't move from top if index is zero.
            if (index > 0)
            {
                // move to next unique value
                for (int i = 1; i <= index; i++)
                {
                    // Move one item down dropdown list.
                    Keyboard.SendKeys(KeyboardCodes.DownArrow);
                    Sleeper.Delay(500);
                    Utilities.LogMessage("Events.ChooseProperty:: " + "Moved one item down" + " using the DownArrow." + " Positioned at index:" + i.ToString());
                }
            }
            Utilities.LogMessage("Events.ChooseProperty:: " + "Positioned at specified index.");

            // Choose the property name currently selected in the dropdown
            Keyboard.SendKeys(KeyboardCodes.Enter);
            focusOn = FocusOn.PropertyComboBox;
        }

        /// <summary>
        /// This method is designed to populate an erray list
        /// with the values in the properties drop down list so
        /// that a particular property name may be efficiently 
        /// selected by its position in the array.
        /// </summary>
        /// <param name="formulaGrid">Formaula grid</param>
        /// <param name="rowIndex">Indxe of row</param>
        /// <param name="colIndex">Index of column</param>
        /// <param name="focusOn">current focus</param>
        /// <returns>Property names</returns>
        /// <remarks>Use properties.IndexOf({property name}) to determine the index.</remarks>
        private ArrayList GetPropertyCollection(
            Core.Console.MomControls.GridControl formulaGrid,
            int rowIndex,
            int colIndex,
            ref FocusOn focusOn)
        {
            Utilities.LogMessage("Events.GetPropertyCollection(...)");
            ArrayList properties = new ArrayList();
            int index = 0;
            const int loopMaximum = 20;
            string previousPropertyName = String.Empty;
            while (true)
            {
                if (index <= loopMaximum)
                {
                    this.PressChevronButton(formulaGrid, rowIndex, colIndex);

                    Utilities.LogMessage(
                        "Events.GetPropertyCollection:: " +
                        "Processing property at index: " + index.ToString());
                    this.ChooseProperty(index, ref focusOn);

                    // get the property name from the cell.
                    string currentPropertyName = formulaGrid.GetCellValue(rowIndex, colIndex);
                    Utilities.LogMessage(
                        "Events.GetPropertyCollection:: " +
                        "Cell value: " + currentPropertyName);

                    if (String.Compare(previousPropertyName, currentPropertyName, false, CultureInfo.CurrentCulture) != 0)
                    {
                        // Add the property namme to the array.
                        properties.Add(currentPropertyName);
                        Utilities.LogMessage(
                            "Events.GetPropertyCollection:: " +
                            "Added property: " + currentPropertyName + " at indexOf:" + properties.IndexOf(currentPropertyName).ToString());

                        // Save the property name
                        previousPropertyName = currentPropertyName;

                        // increment the position in the list
                        index++;
                    }
                    else
                    {
                        /* Previous and current values are the same we
                         * Must have reached the end of the list */
                        Utilities.LogMessage(
                            "Events.GetPropertyCollection:: " +
                            "Reached the end of the property list.");
                        break;
                    }
                }
                else
                {
                    throw new ComboBox.Exceptions.InstanceValueOutOfRangeException("Exceeded maximum expected number of moves to process list. Maximum: " + loopMaximum.ToString());
                }
            }   // while
            return properties;
        }

        /// <summary>
        /// Press the property cell chevron button using the keybaord
        /// </summary>
        /// <param name="formulaGrid">Formula grid</param>
        /// <param name="rowIndex">Index of row</param>
        /// <param name="columnIndex">Index of column</param>
        private void PressChevronButton(
            Core.Console.MomControls.GridControl formulaGrid,
            int rowIndex,
            int columnIndex)
        {
            // This click seems to be needed.
            // Click in cell.
            formulaGrid.ClickCell(rowIndex, columnIndex);
            UISynchronization.WaitForUIObjectReady(formulaGrid.Extended.AccessibleObject, 1000);
            UISynchronization.WaitForProcessReady(formulaGrid.Extended.AccessibleObject.Window, 1000);

            Utilities.LogMessage(
                "Events.PressChevronButton:: " +
                "Sucessfully clicked on the cell in row,column:" +
                rowIndex.ToString() + "," + columnIndex.ToString());

            // Click chevon button in property cell.
            formulaGrid.InvokeCellButton(rowIndex, columnIndex);
            Utilities.LogMessage(
                "Events.PressChevronButton:: " +
                "Sucessfully invoked the chevron button:" +
                rowIndex.ToString() + "," + columnIndex.ToString());
        }

        #endregion

        #endregion

        #region Structs section

        #endregion

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for windows service monitor dialogs
        /// </summary>
        /// <history> 	
        ///   [ruhim]  07Sep05: Added resource strings for windows service 
        ///                     monitor dialogs
        ///   [ruhim]  14NOV05: Upated the resource strings for operational states
        ///                     to call sdk method utilities.GetOperationalStateName
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Contains Guid for:  ManualResetEventRaised operational state from MonitorTypeState table
            /// </summary>
            private const string ManualResetOpStateGuid = "c9583b63-d8d4-6e2a-c757-95e2e71386ef";

            /// <summary>
            /// Contains Guid for: EventRaised operational state from MonitorTypeState table
            /// </summary>
            private const string EventRaisedOpStateGuid = "92189fe5-7ae5-5d20-dcf4-aabeeacc8b9a";

            /// <summary>
            /// Contains WinFormsId for the FormulaGrid third column
            /// </summary>
            public const string TextEditorWinFormsId = "TextEditor";

            /// <summary>
            /// Contains WinFormsId for the FormulaGrid second column
            /// </summary>
            public const string OperatorComboBoxEditorWinFormsId = "OperatorComboBoxEditor";

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManualResetEventRaised operational state
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManualResetOpState;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: EventRaised operational state
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventRaisedOpState;

            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to ManualResetEventRaised operational state translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 08Sep05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManualResetOpState
            {
                get
                {
                    if ((cachedManualResetOpState == null))
                    {
                        cachedManualResetOpState = Utilities.GetOperationalStateName(MonitorTypeDialog.Strings.SingleEventManualResetGuid, ManualResetOpStateGuid);
                    }

                    return cachedManualResetOpState;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to EventRaised operational state translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 08Sep05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventRaisedOpState
            {
                get
                {
                    if ((cachedEventRaisedOpState == null))
                    {
                        cachedEventRaisedOpState = Utilities.GetOperationalStateName(MonitorTypeDialog.Strings.SingleEventManualResetGuid, EventRaisedOpStateGuid);
                    }

                    return cachedEventRaisedOpState;
                }
            }

            #endregion
        }
        #endregion
    }
}
