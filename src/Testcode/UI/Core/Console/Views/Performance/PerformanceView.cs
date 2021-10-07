//-------------------------------------------------------------------
// <copyright file="PerformanceView.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Performance View
// </summary>
//  <history>
//   [mbickle] 02DEC04: Created
//   [mbickle] 30APR06: Added new resource strings and support methods.
//   [kellymor]29MAY08: Added resource for Rotate Chart context menu.
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Views.Performance
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MomControls;
    using Maui.Core.WinControls;
    using Maui.Core;
    using Maui.Core.Utilities;
    #endregion

    /// <summary>
    /// Look For Items By ComboBox options.
    /// </summary>
    public enum LookForItemsBy
    {
        /// <summary>
        /// All Items
        /// </summary>
        AllItems,

        /// <summary>
        /// Items in Chart
        /// </summary>
        ItemsInChart,

        /// <summary>
        /// Items not in Chart
        /// </summary>
        ItemsNotInChart,

        /// <summary>
        /// Items by text Search
        /// </summary>
        ItemsByTextSearch
    }

    /// <summary>
    /// Performance View
    /// </summary>
    public class PerformanceView
    {
        #region Constructor
        /// <summary>
        /// Performance View
        /// </summary>
        public PerformanceView()
        {
            
        }
        #endregion

        #region Public Methods
        /// -------------------------------------------------------------------
        /// <summary>
        /// Chart a counter.  This will try to find the counter you specify
        /// and then will check it to be graphed or remove it from being
        /// graphed, depending on the show value you specify.
        /// This method allow you to find the text to narrow the scope.
        /// </summary>
        /// <param name="counterName">Name of Counter</param>
        /// <param name="counterTarget">Target of Counter</param>
        /// <param name="show">True/False</param>
        /// <exception cref="Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException">Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException</exception>
        /// <history>
        /// [mbickle] 30APR06 Created
        /// </history>
        /// -------------------------------------------------------------------
        public void ChartCounter(string counterName, string counterTarget, bool show)
        {
            this.ChartCounter(counterName, counterTarget, show, false);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Chart a counter.  This will try to find the counter you specify
        /// and then will check it to be graphed or remove it from being
        /// graphed, depending on the show value you specify.
        /// </summary>
        /// <param name="counterName">Name of Counter</param>
        /// <param name="counterTarget">Target of Counter</param>
        /// <param name="show">True/False</param>
        /// <param name="findText">Wether search for the text</param>
        /// <exception cref="Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException">Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException</exception>
        /// <history>
        /// [v-brucec] 12APR10 Created
        /// </history>
        /// -------------------------------------------------------------------
        public void ChartCounter(string counterName, string counterTarget, bool show, bool findText)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: Start");
            Utilities.LogMessage(currentMethod + ":: counterName: " + counterName + " counterTarget: " + counterTarget);

            int retry = 0;
            int maxRetry = 5;
            if (findText) maxRetry = 10;
            DataGridViewRow rowPosition = null;
            ViewPane viewPane = CoreManager.MomConsole.ViewPane;
            GridControl detailGrid = CoreManager.MomConsole.DetailPane.GridControl;

            // This is to work around Refresh bug#67386
            while (rowPosition == null && retry <= maxRetry)
            {
                if (findText)
                {
                    Utilities.LogMessage(currentMethod + "::  Running LookForItem()... index #" + retry + " of " + maxRetry);
                    this.LookForItem(LookForItemsBy.ItemsByTextSearch, counterName);

                    detailGrid = CoreManager.MomConsole.DetailPane.GridControl; // refresh the detailGrid due to the GridControl rows changed.
                }

                Utilities.LogMessage(currentMethod + "::  Trying to get the DataGridViewRow attempt " + retry + " of " + maxRetry);
                rowPosition = detailGrid.FindInstanceRow(
                    Strings.NameColumn,
                    Strings.TargetColumn,
                    counterName,
                    counterTarget,
                    5);

                if (rowPosition == null || rowPosition.Cells.Count == 0)
                {
                    // Refresh
                    viewPane.Extended.Click();
                    CoreManager.MomConsole.Refresh();
                    CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

                    Utilities.LogMessage(currentMethod + "::  Row is null or empty.");
                    Sleeper.Delay(Constants.OneSecond);
                    rowPosition = null;
                }

                retry++;
            }

            // this is going to Show or Hide the counter in the PerfView graph
            this.ShowHideCounter(rowPosition, detailGrid, show);
            Utilities.LogMessage(currentMethod + ":: End");
        }


        /// -------------------------------------------------------------------
        /// <summary>
        /// Chart a counter.  This will try to find the counter you specify
        /// and then will check it to be graphed or remove it from being
        /// graphed, depending on the show value you specify.
        /// </summary>
        /// <param name="counterName">Name of Counter</param>
        /// <param name="counterPath">Path of Counter</param>
        /// <param name="counterTarget">Target of Counter</param>
        /// <param name="show">True/False</param>
        /// <exception cref="Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException">Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException</exception>
        /// <history>
        /// [dialac] 18JUL06 Created
        /// [ruhim]  11Nov06 Changed Instance Column to Target Column   
        /// </history>
        /// -------------------------------------------------------------------
        public void ChartCounter(string counterName, string counterPath, string counterTarget, bool show)
        {
            this.ChartCounter(counterName, counterPath, counterTarget, show, false);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Chart a counter.  This will try to find the counter you specify
        /// and then will check it to be graphed or remove it from being
        /// graphed, depending on the show value you specify.
        /// This method allow you to find the text to narrow the scope.
        /// </summary>
        /// <param name="counterName">Name of Counter</param>
        /// <param name="counterPath">Path of Counter</param>
        /// <param name="counterTarget">Target of Counter</param>
        /// <param name="show">True/False</param>
        /// <param name="findText">Wether search for the text</param>
        /// <exception cref="Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException">Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException</exception>
        /// <history>
        /// [v-brucec] 12APR10 Created
        /// </history>
        /// -------------------------------------------------------------------
        public void ChartCounter(string counterName, string counterPath, string counterTarget, bool show, bool findText)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: Start");
            Utilities.LogMessage(currentMethod + ":: counterName: " + counterName + ", counterPath: " + counterPath + ", counterTarget: " + counterTarget + ", show: " + show + ", findText:" + findText);

            int retry = 0;
            int maxRetry = 5;
            if (findText) maxRetry = 10;
            DataGridViewRow rowPosition = null;
            ViewPane viewPane = CoreManager.MomConsole.ViewPane;
            DetailPane detailPane = CoreManager.MomConsole.DetailPane;
            GridControl detailGrid = detailPane.GridControl;

            // This is to work around Refresh bug#67386
            while (rowPosition == null && retry <= maxRetry)
            {
                if (findText)
                {
                    Utilities.LogMessage(currentMethod + "::  Running LookForItem()... index #" + retry + " of " + maxRetry);
                    this.LookForItem(LookForItemsBy.ItemsByTextSearch, counterTarget);

                    detailGrid = CoreManager.MomConsole.DetailPane.GridControl; // refresh the detailGrid due to the GridControl rows changed.
                }
                detailPane.ScreenElement.WaitForReady();

                rowPosition = detailGrid.FindInstanceRow(
                    Strings.NameColumn,
                    Strings.PathColumn,
                    Strings.TargetColumn,
                    counterName,
                    counterPath,
                    counterTarget,
                    5);

                if (rowPosition == null)
                {
                    // Refresh
                    viewPane.Extended.Click();
                    CoreManager.MomConsole.Refresh();
                    detailGrid.ScreenElement.WaitForReady();
                    detailPane.ScreenElement.WaitForReady();

                }

                retry++;
            }

            // this is going to Show or Hide the counter in the PerfView graph
            this.ShowHideCounter(rowPosition, detailGrid, show);
            Utilities.LogMessage(currentMethod + ":: End");
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Show/Hide Baseline
        /// </summary>
        /// <param name="show">True/False</param>
        /// <history>
        /// [mbickle] 30APR06 Created
        /// </history>
        /// -------------------------------------------------------------------
        public void ShowBaseline(bool show)
        {
            Utilities.LogMessage("PerformanceView.ShowBaseline:: " + show.ToString());
            ViewPane viewPane = CoreManager.MomConsole.ViewPane;

            viewPane.Extended.Click(MouseClickType.SingleClick, MouseFlags.RightButton);
            viewPane.WaitForResponse();
            Menu contextMenu = new Menu(Constants.DefaultContextMenuTimeout);

            Utilities.LogMessage("PerformanceView.ShowBaseline:: Execute Menu ");
            contextMenu[Strings.ContextMenuShowBaseline].Checked = show;
            viewPane.WaitForResponse();
            
            // Send an escape incase the context menu is still up.
            Utilities.LogMessage("PerformanceView.ShowBaseline:: Sending ESC");
            viewPane.SendKeys(KeyboardCodes.Esc);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Show/Hide Alerts
        /// </summary>
        /// <param name="show">True/False</param>
        /// <history>
        /// [mbickle] 30APR06 Created
        /// </history>
        /// -------------------------------------------------------------------
        public void ShowAlerts(bool show)
        {
            Utilities.LogMessage("PerformanceView.ShowAlerts:: " + show.ToString());
            ViewPane viewPane = CoreManager.MomConsole.ViewPane;

            viewPane.Extended.Click(MouseClickType.SingleClick, MouseFlags.RightButton);
            Menu contextMenu = new Menu(Constants.DefaultContextMenuTimeout);

            contextMenu[Strings.ContextMenuShowAlerts].Checked = show;
            viewPane.WaitForResponse();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Show/Hide Maintenence Windows
        /// </summary>
        /// <param name="show">True/False</param>
        /// <history>
        /// [mbickle] 30APR06 Created
        /// </history>
        /// -------------------------------------------------------------------
        public void ShowMaintenanceWindows(bool show)
        {
            Utilities.LogMessage("PerformanceView.ShowMaintenanceWindows:: " + show.ToString());
            ViewPane viewPane = CoreManager.MomConsole.ViewPane;

            viewPane.Extended.Click(MouseClickType.SingleClick, MouseFlags.RightButton);
            Menu contextMenu = new Menu(Constants.DefaultContextMenuTimeout);

            contextMenu[Strings.ContextMenuShowMaintenanceWindows].Checked = show;
            viewPane.WaitForResponse();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Show/Hide 3D Mode
        /// </summary>
        /// <param name="show">True/False</param>
        /// <history>
        /// [mbickle] 30APR06 Created
        /// </history>
        /// -------------------------------------------------------------------
        public void Show3DMode(bool show)
        {
            Utilities.LogMessage("PerformanceView.Show3DMode:: " + show.ToString());
            ViewPane viewPane = CoreManager.MomConsole.ViewPane;

            viewPane.Extended.Click(MouseClickType.SingleClick, MouseFlags.RightButton);
            Menu contextMenu = new Menu(Constants.DefaultContextMenuTimeout);

            contextMenu[Strings.ContextMenu3DMode].Checked = show;
            viewPane.WaitForResponse();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Set Time Range
        /// </summary>
        /// <param name="parameters">TimeRangeParameters</param>
        /// <history>
        /// [mbickle] 30APR06 Created
        /// </history>
        /// -------------------------------------------------------------------
        public void SetTimeRange(TimeRangeParameters parameters)
        {
            Utilities.LogMessage("PerformanceView.SetTimeRange:: ");

            ViewPane viewPane = CoreManager.MomConsole.ViewPane;
           
            // Launch Time Range Dialog
            viewPane.Extended.Click(MouseClickType.SingleClick, MouseFlags.RightButton);
            Menu contextMenu = new Menu(Constants.DefaultContextMenuTimeout);
            contextMenu[Strings.ContextMenuSelectTimeRange].Execute();

            Dialogs.TimeRangeDialog timeRange = new Mom.Test.UI.Core.Console.Views.Performance.Dialogs.TimeRangeDialog(CoreManager.MomConsole);

            // Set Time Range Radio option.
            timeRange.TimeRangeRadioGroup = parameters.SelectTimeRange;

            switch (parameters.SelectTimeRange)
            {
                case Dialogs.TimeRangeRadioGroup.SpecificStartAndEndTimes:
                    timeRange.StartTimeDateTimePickerText = parameters.StartTime;
                    timeRange.EndTimeDateTimePickerText = parameters.EndTime;
                    break;
                case Dialogs.TimeRangeRadioGroup.SelectATimeRange:
                    timeRange.DynamicUnitTextBoxText = parameters.DynamicUnit;
                    timeRange.DynamicUnitsComboBoxText = parameters.DynamicUnits;
                    break;
                default:
                    break;
            }

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(timeRange.Controls.OKButton, Constants.OneMinute);
            timeRange.ClickOK();
            CoreManager.MomConsole.WaitForDialogClose(timeRange, 10);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Look For Items.
        /// </summary>
        /// <param name="lookforItemsBy">LookForItemsBy</param>
        /// <history>
        ///     [mbickle] 31MAY07 Created
        /// </history>
        /// -------------------------------------------------------------------
        public void LookForItem(LookForItemsBy lookforItemsBy)
        {
            this.LookForItem(lookforItemsBy, String.Empty);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Look For Items.
        /// </summary>
        /// <param name="lookforItemsBy">LookForItemsBy</param>
        /// <param name="lookforText">Text to search for.</param>
        /// <history>
        ///     [mbickle] 31MAY07 Created
        /// </history>
        /// -------------------------------------------------------------------
        public void LookForItem(LookForItemsBy lookforItemsBy, string lookforText)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");
            Utilities.LogMessage(currentMethod + ":: Looking for item '" + lookforText + "' by :: " + lookforItemsBy.ToString());

            DetailPane detailPane = CoreManager.MomConsole.DetailPane;
            ToolStrip toolbar = new ToolStrip(detailPane);
            // Create a tempWindow from toolbar HWnd
            Window tempWindow = new Window(toolbar.ScreenElement.HWnd);

            string lookForBy = String.Empty;

            // Get the correct resource string based on LookForItemsBy.
            switch (lookforItemsBy)
            {
                case LookForItemsBy.AllItems:
                    lookForBy = Strings.AllItems;
                    break;
                case LookForItemsBy.ItemsInChart:
                    lookForBy = Strings.ItemsInTheChart;
                    break;
                case LookForItemsBy.ItemsNotInChart:
                    lookForBy = Strings.ItemsNotInTheChart;
                    break;
                case LookForItemsBy.ItemsByTextSearch:
                    lookForBy = Strings.ItemsByTextSearch;
                    break;
                default:
                    lookForBy = Strings.AllItems;
                    break;
            }

            ComboBox lookforItems = null;
            TextBox searchText = null;            

            lookforItems = this.GetComboBoxAtOptionPane();   // To get the combo box
            lookforItems.SelectByText(lookForBy, false);

            lookforItems.SendKeys(KeyboardCodes.Esc);
            Utilities.LogMessage(currentMethod + ":: Set value of combo box as '" + lookForBy + "'");
            CoreManager.MomConsole.Waiters.WaitForStatusReady();
            CoreManager.MomConsole.Waiters.WaitForWindowIdle(detailPane, Constants.OneMinute);


            if (lookforItemsBy == LookForItemsBy.ItemsByTextSearch)
            {               
                int maxtry = 30;
                for (int i = 0; i < maxtry; i++)
                {
                    try
                    {
                        searchText = this.GetTextBoxAtOptionPane();   // Get the text box
                        searchText.Text = lookforText;
                        searchText.SendKeys(KeyboardCodes.Esc);      // Close the option pane

                        Utilities.LogMessage(currentMethod + ":: Set content of text box as '" + lookforText + "' in retry #" + i + " of " + maxtry);
                        CoreManager.MomConsole.Waiters.WaitForStatusReady();
                        break;
                    }
                    catch (Maui.Core.Window.Exceptions.CannotSetFocusException)
                    {
                        Utilities.LogMessage(currentMethod + ":: retry set search text.");
                        Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        throw;
                    }
                    catch (Maui.GlobalExceptions.MauiException)
                    {
                        throw;
                    }
                }

                CoreManager.MomConsole.Waiters.WaitForStatusReady();
                CoreManager.MomConsole.Waiters.WaitForWindowIdle(detailPane, Constants.OneMinute);

            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Clicks the Clear Search Button
        /// </summary>
        /// <history>
        ///     [mbickle] 31MAY07 Created.
        /// </history>
        /// -------------------------------------------------------------------
        public void ClickClearSearchButton()
        {
            ToolStrip toolbar = new ToolStrip(CoreManager.MomConsole.DetailPane);
            toolbar.ToolStripItems[4].Click();
        }
        
        #endregion

        #region Private Methods

        /// <summary>
        /// ShowHide Counter
        /// </summary>
        /// <param name="rowPosition">Row Position</param>
        /// <param name="detailGrid">Grid</param>
        /// <param name="show">Bool</param>
        private void ShowHideCounter(DataGridViewRow rowPosition, GridControl detailGrid, bool show)
        {
            int showColumn = detailGrid.GetColumnTitlePosition(Strings.ShowColumn);
            if (rowPosition != null)
            {
                Utilities.LogMessage("PerformanceView.ChartCounter:: Found Counter, lets show/hide it.");

                //int index = -5;
                //while (index < -1)
                //{
                //    try
                //    {
                //        index = rowPosition.AccessibleObject.Index;
                //    }
                //    catch (System.NullReferenceException ex)  //#181933
                //    {
                //        Utilities.LogMessage("PerformanceView.ChartCounter:: Got System.NullReferenceException when getting index:" + ex.Message);
                //        if (++index == -1)
                //        {
                //            throw ex;
                //        }
                //        detailGrid.ScreenElement.WaitForReady();
                //    }
                //}

                //Utilities.LogMessage("PerformanceView.ChartCounter:: rowPosition Index = " + index.ToString());

                if (show)
                {
                    Utilities.LogMessage("PerformanceView.ChartCounter:: Show - True");

                    // If not already selected, we'll select the counter to graph
                    if (rowPosition.Cells[showColumn].GetValue() == "False")
                    {
                        //detailGrid.ClickCell(index, showColumn);
                        rowPosition.Cells[showColumn].AccessibleObject.DoDefaultAction();

                        ////detailGrid.Rows[rowPosition.AccessibleObject.Index].Cells[showColumn].AccessibleObject.DoDefaultAction();
                    }
                }
                else
                {
                    Utilities.LogMessage("PerformanceView.ChartCounter:: Show - False");

                    // If already selected, we'll unselect the counter to graph
                    if (rowPosition.Cells[showColumn].GetValue() == "True")
                    {
                        //detailGrid.ClickCell(index, showColumn);
                        rowPosition.Cells[showColumn].AccessibleObject.DoDefaultAction();
                    }
                }

                CoreManager.MomConsole.Waiters.WaitForStatusReady();
                CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, 6000);
                detailGrid.ScreenElement.WaitForReady();
            }
            else
            {
                Utilities.LogMessage("PerformanceView.ChartCounter:: rowPosition == null");
                throw new DataGridView.Exceptions.DataGridViewRowNotFoundException("Performance.ChartCounter:: rowPostion == null, counter not found");
            }
        }

        /// <summary>
        /// Get Combo Box At Option Pane 
        /// </summary>
        /// <returns>Combo Box</returns>
        /// <exception cref="Maui.Core.Window.Exceptions.WindowNotFoundException">
        /// Maui.Core.Window.Exceptions.WindowNotFoundException
        /// </exception>
        /// <exception cref="Maui.GlobalExceptions.MauiException">
        /// Maui.GlobalExceptions.MauiException
        /// </exception>
        private ComboBox GetComboBoxAtOptionPane()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "...");

            ComboBox comboBox = null;
            DetailPane detailPane = CoreManager.MomConsole.DetailPane;
            ToolStrip toolbar = new ToolStrip(detailPane);
            Window tempWindow = new Window(toolbar.ScreenElement.HWnd);
            try
            {
                Utilities.LogMessage(currentMethod + ":: Searching for combo box to filt items.");
                detailPane.Extended.Click();

                // Create reference to the LookFor ComboBox
                // MAUI2.0 New a combo box that no caption and no WinformID
                comboBox = new ComboBox(tempWindow, "*", Maui.Core.Utilities.StringMatchSyntax.WildCard,
                    WindowClassNames.WinFormsComboBox, Maui.Core.Utilities.StringMatchSyntax.WildCard);

                Utilities.LogMessage(currentMethod + ":: Successfully found combo box.");
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
            {
                // The combo box is at option pane
                Utilities.LogMessage(currentMethod + ":: Could not find combo box, trying to find the combo box in option pane.");
                ToolStripItem optionButton = toolbar.get_ToolStripItem(ViewToolbar.Strings.ToolbarMenus.ToolbarOptions);
                if (optionButton != null)
                {
                    Utilities.LogMessage(currentMethod + ":: Clicking option button.");
                    optionButton.Click();
                    Window dropDownPane = new Window(string.Empty, Maui.Core.Utilities.StringMatchSyntax.ExactMatch);
                    CoreManager.MomConsole.Waiters.WaitForStatusReady();
                    try
                    {
                        Utilities.LogMessage(currentMethod + ":: Looking for combo box at option pane.");
                        comboBox = new ComboBox(dropDownPane, "*", Maui.Core.Utilities.StringMatchSyntax.WildCard,
                            WindowClassNames.WinFormsComboBox, Maui.Core.Utilities.StringMatchSyntax.WildCard);
                        Utilities.LogMessage(currentMethod + ":: Successfully found combo box at option pane.");
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage(currentMethod + ":: Could not find combo box in option pane.");
                        throw;
                    }
                }
                else
                {
                    throw new Maui.GlobalExceptions.MauiException(currentMethod + ":: Option button not found.");
                }
            }

            return comboBox;
        }

        /// <summary>
        /// Get Text Box At Option Pane 
        /// </summary>
        /// <returns>Text Box</returns>
        /// <exception cref="Maui.Core.Window.Exceptions.WindowNotFoundException">
        /// Maui.Core.Window.Exceptions.WindowNotFoundException
        /// </exception>
        /// <exception cref="Maui.GlobalExceptions.MauiException">
        /// Maui.GlobalExceptions.MauiException
        /// </exception>
        private TextBox GetTextBoxAtOptionPane()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "...");

            TextBox textBox = null;
            DetailPane detailPane = CoreManager.MomConsole.DetailPane;
            ToolStrip toolbar = new ToolStrip(detailPane);
            Window tempWindow = new Window(toolbar.ScreenElement.HWnd);

            try
            {
                Utilities.LogMessage(currentMethod + ":: Searching for text box to type in name.");
                detailPane.Extended.Click();

                // Create reference to the LookFor ComboBox
                // MAUI2.0 New a edit box that no caption and no WinformID
                textBox = new TextBox(tempWindow, "*", Maui.Core.Utilities.StringMatchSyntax.WildCard,
                     WindowClassNames.WinFormsEdit, Maui.Core.Utilities.StringMatchSyntax.WildCard);
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage(currentMethod + ":: Could not find text box, trying to find the combo box in option pane.");
                ToolStripItem optionButton = toolbar.get_ToolStripItem(ViewToolbar.Strings.ToolbarMenus.ToolbarOptions);

                if (optionButton != null)
                {
                    Utilities.LogMessage(currentMethod + ":: Clicking option button.");
                    optionButton.Click();

                    Window dropDownPane = new Window(string.Empty, Maui.Core.Utilities.StringMatchSyntax.ExactMatch);
                    CoreManager.MomConsole.Waiters.WaitForStatusReady();
                    try
                    {
                        Utilities.LogMessage(currentMethod + ":: Looking for text box in option pane.");
                        textBox = new TextBox(dropDownPane, "*", Maui.Core.Utilities.StringMatchSyntax.WildCard,
                            WindowClassNames.WinFormsEdit, Maui.Core.Utilities.StringMatchSyntax.WildCard);
                        Utilities.LogMessage(currentMethod + ":: Successfully found text box in option pane.");
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage(currentMethod + ":: Could not find text box in option pane.");
                        throw;
                    }
                }
                else
                {
                    throw new Maui.GlobalExceptions.MauiException(currentMethod + ":: Option button not found.");
                }
            }

            return textBox;
        }

        #endregion

        #region TimeRange Parameters
        /// <summary>
        /// TimeRange Parameters
        /// </summary>
        public class TimeRangeParameters
        {
            #region Private Members
            /// <summary>
            /// SelectTimeRange Default = true;
            /// </summary>
            private Dialogs.TimeRangeRadioGroup cachedSelectTimeRange = Dialogs.TimeRangeRadioGroup.SelectATimeRange;

            /// <summary>
            /// StartTime
            /// </summary>
            private string cachedStartTime;

            /// <summary>
            /// EndTime;
            /// </summary>
            private string cachedEndTime;

            /// <summary>
            /// Dynamic Units Day/Hour/Minutes
            /// </summary>
            private string cachedDynamicUnits = Performance.Dialogs.TimeRangeDialog.Strings.Days;

            /// <summary>
            /// Dynamic Unit
            /// </summary>
            private string cachedDynamicUnit = "1";
            #endregion

            #region Constructors
            /// ------------------------------------------------------------------
            /// <summary>
            /// TimeRangeParameters
            /// </summary>
            /// ------------------------------------------------------------------
            public TimeRangeParameters()
            {
            }
            #endregion

            #region Properties
            /// <summary>
            /// SelectTimeRange Default = true;
            /// </summary>
            public Dialogs.TimeRangeRadioGroup SelectTimeRange
            {
                get
                {
                    return this.cachedSelectTimeRange;
                }

                set
                {
                    this.cachedSelectTimeRange = value;
                }
            }

            /// <summary>
            /// StartTime
            /// </summary>
            public string StartTime
            {
                get
                {
                    return this.cachedStartTime;
                }

                set
                {
                    this.cachedStartTime = value;
                }
            }

            /// <summary>
            /// EndTime;
            /// </summary>
            public string EndTime
            {
                get
                {
                    return this.cachedEndTime;
                }

                set
                {
                    this.cachedEndTime = value;
                }
            }

            /// <summary>
            /// Dynamic Units Day/Hour/Minutes
            /// </summary>
            public string DynamicUnits
            {
                get
                {
                    return this.cachedDynamicUnits;
                }

                set
                {
                    this.cachedDynamicUnits = value;
                }
            }

            /// <summary>
            /// Dynamic Unit
            /// </summary>
            public string DynamicUnit
            {
                get
                {
                    return this.cachedDynamicUnit;
                }

                set
                {
                    this.cachedDynamicUnit = value;
                }
            }
            #endregion
        }
        #endregion

        #region Strings
        /// <summary>
        /// Strings Class
        /// </summary>
        public class Strings
        {
            #region Constants
            /// <summary>
            /// Contains resource string for Items by text search
            /// </summary>
            private const string ResourceItemsByTextSearch = ";Items by text search;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceDetailView;lookForComboBox.Items3";

            /// <summary>
            /// Contains resource string for Items not in the Chart
            /// </summary>
            private const string ResourceItemsNotInTheChart = ";Items not in the Chart;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceDetailView;lookForComboBox.Items2";

            /// <summary>
            /// Contains resource string for Items in the Chart
            /// </summary>
            private const string ResourceItemsInTheChart = ";Items in the Chart;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceDetailView;lookForComboBox.Items1";

            /// <summary>
            /// Contains resource string for All Items
            /// </summary>
            private const string ResourceAllItems = ";All Items;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceDetailView;lookForComboBox.Items";
            
            /// <summary>
            /// Contains resource string for 3D Mode context menu
            /// </summary>
            private const string ResourceSelectAllContextMenu = ";Select All;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;CommandSelectAll";

            /// <summary>
            /// Contains resource string for 3D Mode context menu
            /// </summary>
            private const string ResourceUnselectAllContextMenu = ";Unselect All;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;CommandUnselectAll";
            
            /// <summary>
            /// Contains resource string for 3D Mode context menu
            /// </summary>
            private const string Resource3DModeContextMenu = ";&3D Mode;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.PerformanceResources;Show3D";
            
            /// <summary>
            /// Contains resource string for Show Baseline context menu
            /// </summary>
            private const string ResourceShowBaselineContextMenu = ";Show Baseline;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.PerformanceResources;ShowBaselineText";

            /// <summary>
            /// Contains resource string for Show Alerts context menu
            /// </summary>
            private const string ResourceShowAlertsContextMenu = ";Show Alerts;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.PerformanceResources;ShowAlertsText";
            
            /// <summary>
            /// Contains resource string for Show Maintenance Windows context menu
            /// </summary>
            private const string ResourceShowMaintenanceWindowsContextMenu = ";Show Maintenance Windows;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.PerformanceResources;MaintenanceWindows";
            
            /// <summary>
            /// Contains resource string for Select Time Range context menu
            /// </summary>
            private const string ResourceSelectTimeRangeContextMenu = ";Select time range...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.PerformanceResources;ChooseTimes";

            /// <summary>
            /// Contains resource string for column: Show
            /// </summary>
            private const string ResourceShowColumn =
                ";Show;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceDetailView;showColumn.HeaderText";
            
            /// <summary>
            /// Contains resource string for column: Path
            /// </summary>
            private const string ResourcePathColumn =
                ";Path;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceDetailView;pathColumn.HeaderText";
            
            /// <summary>
            /// Contains resource string for column: Instance
            /// </summary>
            private const string ResourceInstanceColumn =
               ";Instance;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceDetailView;targetEntity.HeaderText";

            /// <summary>
            /// Contains resource string for column: Name
            /// </summary>
            private const string ResourceNameColumn =
                ";Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceDetailView;nameColumn.HeaderText";

            /// <summary>
            /// Contains resource string for column: Counter
            /// </summary>
            private const string ResourceCounterColumn =
                ";Counter;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceDetailView;counterColumn.HeaderText";

            /// <summary>
            /// Contains resource string for column: Scale
            /// </summary>
            private const string ResourceScaleColumn =
                ";Scale;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceDetailView;scaleColumn.HeaderText";

            /// <summary>
            /// Contains resource string for column: Baseline
            /// </summary>
            private const string ResourceBaselineColumn =
                ";Baseline;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceDetailView;baselineColumn.HeaderText";

            /// <summary>
            /// Contains resource string for column: Target
            /// </summary>
            private const string ResourceTargetColumn = 
                ";Target;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceDetailView;targetColumn.HeaderText";

            /// <summary>
            /// Contains resource string for column: Object
            /// </summary>
            private const string ResourceObjectColumn =
                ";Object;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.PerformanceDetailView;objectColumn.HeaderText";

            /// <summary>
            /// Contains resource string for context menu: Rotate Chart
            /// </summary>
            private const string ResourceRotateChartContextMenu =
                ";&Rotate Chart" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.PerformanceResources" +
                ";Rotate3D";

            #endregion

            #region Member Variables
            /// <summary>
            /// Contains resource string for Items by text search
            /// </summary>
            private static string cachedItemsByTextSearch;

            /// <summary>
            /// Contains resource string for Items not in the Chart
            /// </summary>
            private static string cachedItemsNotInTheChart;

            /// <summary>
            /// Contains resource string for Items in the Chart
            /// </summary>
            private static string cachedItemsInTheChart;

            /// <summary>
            /// Contains resource string for All Items
            /// </summary>
            private static string cachedAllItems;

            /// <summary>
            /// Contains resource string for Select All context menu
            /// </summary>
            private static string cachedSelectAllContextMenu;

            /// <summary>
            /// Contains resource string for Unselect All context menu
            /// </summary>
            private static string cachedUnselectAllContextMenu;
            
            /// <summary>
            /// Contains resource string for 3D Mode context menu
            /// </summary>
            private static string cached3DModeContextMenu;

            /// <summary>
            /// Contains cached string for Show Baseline context menu
            /// </summary>
            private static string cachedShowBaselineContextMenu;

            /// <summary>
            /// Contains cached string for Show Alerts context menu
            /// </summary>
            private static string cachedShowAlertsContextMenu;

            /// <summary>
            /// Contains cached string for Show Maintenance Windows context menu
            /// </summary>
            private static string cachedShowMaintenanceWindowsContextMenu;

            /// <summary>
            /// Contains cached string for Select Time Range context menu
            /// </summary>
            private static string cachedSelectTimeRangeContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Path column
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedShowColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Path column
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPathColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Instnace column
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInstanceColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name Column
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNameColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Counter column
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCounterColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Scale column
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedScaleColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Baseline column
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBaselineColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Target column
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTargetColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Object column
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedObjectColumn;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Rotate Chart
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRotateChartContextMenu;

            #endregion

            #region Properties
            /// <summary>
            /// Contains resource string for Items by text search
            /// </summary>
            public static string ItemsByTextSearch
            {
                get
                {
                    if ((cachedItemsByTextSearch == null))
                    {
                        cachedItemsByTextSearch = CoreManager.MomConsole.GetIntlStr(ResourceItemsByTextSearch);
                    }

                    return cachedItemsByTextSearch;
                }
            }

            /// <summary>
            /// Contains resource string for Items not in the Chart
            /// </summary>
            public static string ItemsNotInTheChart
            {
                get
                {
                    if ((cachedItemsNotInTheChart == null))
                    {
                        cachedItemsNotInTheChart = CoreManager.MomConsole.GetIntlStr(ResourceItemsNotInTheChart);
                    }

                    return cachedItemsNotInTheChart;
                }
            }

            /// <summary>
            /// Contains resource string for Items in the Chart
            /// </summary>
            public static string ItemsInTheChart
            {
                get
                {
                    if ((cachedItemsInTheChart == null))
                    {
                        cachedItemsInTheChart = CoreManager.MomConsole.GetIntlStr(ResourceItemsInTheChart);
                    }

                    return cachedItemsInTheChart;
                }
            }

            /// <summary>
            /// Contains resource string for All Items
            /// </summary>
            public static string AllItems
            {
                get
                {
                    if ((cachedAllItems == null))
                    {
                        cachedAllItems = CoreManager.MomConsole.GetIntlStr(ResourceAllItems);
                    }

                    return cachedAllItems;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Select All translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 30APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuSelectAll
            {
                get
                {
                    if ((cachedSelectAllContextMenu == null))
                    {
                        cachedSelectAllContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceSelectAllContextMenu);
                    }

                    return cachedSelectAllContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Unselect All translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 30APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuUnselectAll
            {
                get
                {
                    if ((cachedUnselectAllContextMenu == null))
                    {
                        cachedUnselectAllContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceUnselectAllContextMenu);
                    }

                    return cachedUnselectAllContextMenu;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the 3DMode translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 30APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenu3DMode
            {
                get
                {
                    if ((cached3DModeContextMenu == null))
                    {
                        cached3DModeContextMenu = CoreManager.MomConsole.GetIntlStr(Resource3DModeContextMenu);
                    }

                    return cached3DModeContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Show Baseline translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 30APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuShowBaseline
            {
                get
                {
                    if ((cachedShowBaselineContextMenu == null))
                    {
                        cachedShowBaselineContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceShowBaselineContextMenu);
                    }

                    return cachedShowBaselineContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Show Alerts translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 30APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuShowAlerts
            {
                get
                {
                    if ((cachedShowAlertsContextMenu == null))
                    {
                        cachedShowAlertsContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceShowAlertsContextMenu);
                    }

                    return cachedShowAlertsContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Show Maintenance Windows translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 30APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuShowMaintenanceWindows
            {
                get
                {
                    if ((cachedShowMaintenanceWindowsContextMenu == null))
                    {
                        cachedShowMaintenanceWindowsContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceShowMaintenanceWindowsContextMenu);
                    }

                    return cachedShowMaintenanceWindowsContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Select Time Range translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 30APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuSelectTimeRange
            {
                get
                {
                    if ((cachedSelectTimeRangeContextMenu == null))
                    {
                        cachedSelectTimeRangeContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceSelectTimeRangeContextMenu);
                    }

                    return cachedSelectTimeRangeContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Show column translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShowColumn
            {
                get
                {
                    if ((cachedShowColumn == null))
                    {
                        cachedShowColumn = CoreManager.MomConsole.GetIntlStr(ResourceShowColumn);
                    }

                    return cachedShowColumn;
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
            /// Exposes access to the Instance column translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14APR06 Created
            ///     [dialac]  19JUL06 Changing the name of the column from "Target" to "Instance"
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InstanceColumn
            {
                get
                {
                    if ((cachedInstanceColumn == null))
                    {
                        cachedInstanceColumn = CoreManager.MomConsole.GetIntlStr(ResourceInstanceColumn);
                    }

                    return cachedInstanceColumn;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name column translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 14APR06 Created
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
            /// Exposes access to the Counter column translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CounterColumn
            {
                get
                {
                    if ((cachedCounterColumn == null))
                    {
                        cachedCounterColumn = CoreManager.MomConsole.GetIntlStr(ResourceCounterColumn);
                    }

                    return cachedCounterColumn;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Scale column translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ScaleColumn
            {
                get
                {
                    if ((cachedScaleColumn == null))
                    {
                        cachedScaleColumn = CoreManager.MomConsole.GetIntlStr(ResourceScaleColumn);
                    }

                    return cachedScaleColumn;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Baseline column translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BaselineColumn
            {
                get
                {
                    if ((cachedBaselineColumn == null))
                    {
                        cachedBaselineColumn = CoreManager.MomConsole.GetIntlStr(ResourceBaselineColumn);
                    }

                    return cachedBaselineColumn;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Target column translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TargetColumn
            {
                get
                {
                    if ((cachedTargetColumn == null))
                    {
                        cachedTargetColumn = CoreManager.MomConsole.GetIntlStr(ResourceTargetColumn);
                    }

                    return cachedTargetColumn;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Object column translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ObjectColumn
            {
                get
                {
                    if ((cachedObjectColumn == null))
                    {
                        cachedObjectColumn = CoreManager.MomConsole.GetIntlStr(ResourceObjectColumn);
                    }

                    return cachedObjectColumn;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Rotate Chart context menu translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RotateChartContextMenu
            {
                get
                {
                    if ((cachedRotateChartContextMenu == null))
                    {
                        cachedRotateChartContextMenu = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceRotateChartContextMenu);
                    }

                    return cachedRotateChartContextMenu;
                }
            }

            #endregion
        }
        #endregion
    }
}
