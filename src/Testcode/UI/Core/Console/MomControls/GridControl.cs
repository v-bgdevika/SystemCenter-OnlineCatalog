// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GridControl.cs">
//  Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
//  MOMv3
// </project>
// <summary>
//  DataGridView base class.
// </summary>
// <history>
//  [mbickle] 26JUL05: Created
//  [mbickle] 13AUG05: Added SetCellValue method.
//                     Refactored ClickCell methods, added MakeVisible to main 
//                     method.
//  [mbickle] 15AUG05: Implemented private version of MakeVisible because Maui
//                     was causing problems.  There are issues with current 
//                     grid too where there are no AA Names for the ScrollBars 
//                     so have to use some Keyboard commands to scroll properly.
//                     Hopefully new version of grid will have some of these 
//                     issues fixed.
//  [kellymor]29AUG05: Added FindData methods for searching the grid for text
//  [kellymor]01SEP05: Added public enumeration for string match types in
//                     search method FindData.
//                     Added overloads for FindData to use match criteria.
//                     Modified FindData to use match criteria.
//                     Modified FindData to use ClickCell method.
//  [mbickle] 02SEP05: Addressed FxCop Issues.
//                     Made CellVisible static.  
//                     Changed System.Exception to use an Exception from 
//                     DataGridView.
//  [kellymor]09SEP05: Modified ClickCell to use 1/3 the width of
//                     the cell instead of 1/4.
//  [kellymor]14SEP05: Added FindDataRows method to return a list
//                     of rows that match specified search criteria
//  [kellymor]19SEP05: Modified Find* methods to avoid using the
//                     ClickCell method, now just clicks the row
//  [kellymor]23SEP05: Modified Find* methods to get the updated
//                     row count every time through the search loop
//  [kellymor]30SEP05: Added private methods to wait for the row
//                     count to become non-zero
//                     Modified Find* methods to wait for row count
//                     to become non-zero.
//                     Modified Find* methods to expand all rows if
//                     row count changes during search
//  [kellymor]12OCT05: Added private methods for ExpandAllRows and
//                     ScrollToRow to refactor Find* methods.
//                     Added try/catch block to ExpandAllRows to
//                     handle case where menu item does not exist.
//  [ruhim]   21MAR06: Making ScrollToRow Public method and marking ExpandAllRows as obsolete
//  [faizalk] 18JUL06: Caching DataGridRows collection and retrying FindData if this.Rows.count changes
//  [ruhim]   18Sep06: Updating SetCellValue method to no call MakeVisible since MakeVisible was
//                     throwing an exception on Override Properties dialog
//  [nathd]   25NOV08: Overloaded the FindInstanceRow() methods to accept a SearchStringMatchType param.

//  [billhodg]10MAR10: Rewrote MakeVisible, ScrollToRow, and CellClick to use RPF methods.
//                       

//   [sunsingh] 24Feb10 Marking this Class and all it's member as obselete So the We Use SCUI SControl FindBar Class                    
//   [sunsingh] 27Apr10 Reverting the changes as we don't want to inherit from Scui Grid Control as Scui Winform Grid Control is not updated with the 
//                       latest changes as we have , also Scui WPF grid control is not the grid control that we will be using 
// </history>
// ---------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MomControls
{
    #region Using directives

    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Common;

    #endregion

    #region Interface Definition - IGridControlControls

    /// ------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IGridControlControls.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 26JUL05 Created
    /// </history>
    /// ------------------------------------------------------------------
   
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IGridControlControls
    {
        /// <summary>
        /// DataGridViewHeader Columns
        /// </summary>
        DataGridViewHeaderCollection Columns 
        { 
            get; 
        }
    }
    #endregion

    /// ------------------------------------------------------------------
    /// <summary>
    /// Grid Control Class for accessing the grid control in views.
    /// </summary>
    /// <history>
    /// 	[mbickle] 26JUL05 Created
    ///     [kellymor]09SEP05 Modified ClickCell to use 1/3 the width of
    ///                       the cell instead of 1/4.
    ///     [kellymor]14SEP05 Added FindDataRows method to return a list
    ///                       of rows that match specified search criteria
    ///     [kellymor]19SEP05 Modified Find* methods to avoid using the
    ///                       ClickCell method, now just clicks the row
    ///     [kellymor]23SEP05 Modified Find* methods to get the updated
    ///                       row count every time through the search loop
    ///     [kellymor]30SEP05 Added private methods to wait for the row
    ///                       count to become non-zero
    ///                       Modified Find* methods to wait for row count
    ///                       to become non-zero.
    ///                       Modified Find* methods to expand all rows if
    ///                       row count changes during search
    ///     [kellymor]12OCT05 Added private methods for ExpandAllRows and
    ///                       ScrollToRow to refactor Find* methods.
    ///                       Added try/catch block to ExpandAllRows to
    ///                       handle case where menu item does not exist.
    ///    [sunsingh] 24feb10 Inheriting From SCUI GridControl
    /// </history>
    /// ------------------------------------------------------------------
       public class GridControl : DataGridView, IGridControlControls
    {
        #region Private Members
        /// <summary>
        /// Active Acessibilty GridControl Object
        /// </summary>
        private ActiveAccessibility gridControlObject;
        
        /// <summary>
        /// Cached reference to Horizontal Bar
        /// </summary>
        private Maui.Core.WinControls.HorizontalScrollBar cachedHorizontalScroll;

        /// <summary>
        /// Cached Reference to Vertical Bar
        /// </summary>
        private Maui.Core.WinControls.VerticalScrollBar cachedVerticalScroll;
        
        #endregion

        #region Constructors
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Creates Instance of DataGridView control.
        /// Uses a built in timeout of Core.Common.Constants.ViewLoadTimeout
        /// </summary>
        /// <param name="app">Console App</param>
        /// <param name="gridId">Grid ControlID</param>
        /// <history>
        /// [mbickle] 26JUL005 Created
        /// [billhodg] 05MAR10 Added Timeout
        /// </history>
        /// -----------------------------------------------------------------------------
        public GridControl(ConsoleApp app, string gridId)
            : base(app.MainWindow, gridId, true, Core.Common.Constants.DefaultViewLoadTimeout)
        {

            this.gridControlObject = this.AccessibleObject;           

        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Overloaded constructor to creates an instance
        /// of the DataGridView control for use with Wizard dialogs.
        /// Uses a built in timeout of Core.Common.Constants.ViewLoadTimeout
        /// </summary>
        /// <param name="startWindow">Dialog on which Grid control appears.</param>
        /// <param name="gridId">Grid control Id.</param>
        /// <history>
        /// [mbickle] 26JUL005 Created
        /// [billhodg] 05MAR10 Added Timeout
        /// </history>
        /// ------------------------------------------------------------------
        public GridControl(Window startWindow, string gridId)
            : base(startWindow, gridId, true, Core.Common.Constants.DefaultViewLoadTimeout)
        {


            this.gridControlObject = this.AccessibleObject; 
        }

        /// <summary>
        /// Creates Instance of DataGridView control if it exists within the timeout (in milliseconds)
        /// </summary>
        /// <param name="app">Console App</param>
        /// <param name="gridId">Grid ControlID</param>
        /// <param name="timeout">constructor timeout in milliseconds</param>
        /// <history>
        /// [billhodg] 05MAR10 Created
        /// </history>
        public GridControl(ConsoleApp app, string gridId, int timeout)
            : base(app.MainWindow, gridId, true, timeout)
        {
            this.gridControlObject = this.AccessibleObject;

        }

        /// <summary>
        /// Creates Instance of DataGridView control if it exists within the timeout (in milliseconds)
        /// </summary>
        /// <param name="startWindow">Dialog on which Grid control appears.</param>
        /// <param name="gridId">Grid ControlID</param>
        /// <param name="timeout">constructor timeout in milliseconds</param>
        /// <history>
        /// [billhodg] 05MAR10 Created
        /// </history>
        public GridControl(Window startWindow, string gridId, int timeout)
            : base(startWindow, gridId, true, timeout)
        {
            this.gridControlObject = this.AccessibleObject;
        }

        #endregion

        #region Enumerations

        /// <summary>
        /// Enumerations used by search methods to indicate what
        /// matching criteria should be used for text data
        /// </summary>
        
        public enum SearchStringMatchType
        {
            /// <summary>
            /// Exactly match the search string
            /// </summary>
            ExactMatch = 0,

            /// <summary>
            /// Match if the text begins with the search string
            /// </summary>
            PrefixMatch = 1,

            /// <summary>
            /// Match if the text contains the search string
            /// </summary>
            ContainsMatch = 2
        }

        #endregion // Enumerations

        #region "Properties"
        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes the controls
        /// </summary>
        /// <history>
        /// 	[mbickle] 26JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        
        public IGridControlControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion

        #region "IGridControlControls Implementation"
        /// ------------------------------------------------------------------
        /// <summary>
        /// Column Headers
        /// </summary>
        /// <history>
        /// 	[mbickle] 26JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
      
        DataGridViewHeaderCollection IGridControlControls.Columns
        {
            get
            {
                return this.ColumnHeaders;
            }
        }

        /// <summary>
        /// Vertical Scroll
        /// </summar
        Maui.Core.WinControls.VerticalScrollBar VerticalScroll
        {
            get
            {
                if ((cachedVerticalScroll == null))
                {
                    cachedVerticalScroll = new Maui.Core.WinControls.VerticalScrollBar(this.AccessibleObject.FindChild(MsaaResources.Strings.VerticalScrollBar, (int)MsaaRole.ScrollBar).Window);
                }

                return cachedVerticalScroll;
            }
        }

        /// <summary>
        /// Horizontal Scroll
        /// </summary>
        
        Maui.Core.WinControls.HorizontalScrollBar HorizontalScroll
        {
            get
            {
                if ((cachedHorizontalScroll == null))
                {
                    cachedHorizontalScroll = new Maui.Core.WinControls.HorizontalScrollBar(this.AccessibleObject.FindChild(MsaaResources.Strings.HorizontalScrollBar, (int)MsaaRole.ScrollBar).Window);
                }

                return cachedHorizontalScroll;
            }
        }
        #endregion

        #region Public Static Methods

        /// <summary>
        /// Returns true or false depending on whether or not the cell is visible.
        /// </summary>
        /// <param name="cell">AcctiveAccessiblity Cell Object</param>
        /// <returns>True/False</returns>
        public static Boolean CellVisible(ActiveAccessibility cell)
        {
            bool cellVisible = false;

            // If it is visible then the index of Invisible will be -1. 
            // If I looked for Visible, it would be found in In(Visible).
            if (cell.StateText.IndexOf(MsaaResources.Strings.Offscreen) == -1)
            {
                cellVisible = true;
            }

            Utilities.LogMessage("GridControl.CellVisible:: " + cellVisible.ToString());
            return cellVisible;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to scroll the grid view down to make the specified row 
        /// visible.
        /// </summary>
        /// <param name="rowIndex">Index of the row to make visible</param>

        public void ScrollToRow(int rowIndex)
        {
            Utilities.LogMessage("GridControl::ScrollToRow::Making current row visible, row index:  " + rowIndex);

            //not doing a check for of range index, because rowcount can be very slow
            try
            {
                DataGridViewRow row = this.Rows[rowIndex];
                ActiveAccessibility rowObject = row.AccessibleObject;
                IScreenElement rowElement = rowObject.Window.ScreenElement;

                //EnsureVisible will fail in loc OS sometimes, fix for #185259
                rowElement.EnsureVisible();
            }
            catch (System.InvalidOperationException ex)
            {
                Utilities.LogMessage("GridControl::ScrollToRow:: Got InvalidOperationException when calling EnsureVisible(), " +
                    "Exception message is: " + ex.Message);

                //scroll to top firstly
                if (this.HasHorizontalScrollbar())
                {
                    this.VerticalScrollbar.ScrollTop();
                    int currentRow = 0;
                    bool cellVisible = CellVisible(this.Rows[rowIndex].Cells[0].AccessibleObject);

                    while (cellVisible == false && currentRow < this.Rows.Count)
                    {
                        cellVisible = CellVisible(this.Rows[rowIndex].Cells[0].AccessibleObject);
                        // scroll down
                        this.VerticalScrollbar.PageDown();
                        currentRow++;
                    }   
                }
            }
        }

        /// <summary>
        /// Method to scroll the grid view down to make the specified row 
        /// visible. Adding the overloaded method which takes row count this is 
        /// because if the view has many rows (like monitors row) call to Rows.Count
        /// introduces significant delay
        /// </summary>
        /// <param name="dataRow">Row to make visible</param>
        /// <param name="rowIndex">Row Index</param>
        /// <param name="rowCount">Number of rows in the view</param>
         
        public void ScrollToRow(DataGridViewRow dataRow, int rowIndex, int rowCount)
        {
            Core.Common.Utilities.LogMessage("GridControl::ScrollToRow::Making current row visible, row index:  " + rowIndex);
            if (rowIndex >= this.Rows.Count)
                throw new IndexOutOfRangeException("Row index " + rowIndex.ToString() + " is equal to or exceeds the # of rows " + this.Rows.Count.ToString());

            ActiveAccessibility rowObject = dataRow.AccessibleObject;
            IScreenElement rowElement = RPFSupport.RPF.ScreenElementFromAccessibleObject(rowObject.IAccessible, null);
            rowElement.EnsureVisible();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Column Header Button
        /// </summary>
        /// <param name="columnHeader">Column Header you want to Select via String</param>
        /// <history>
        /// 	[mbickle] 26JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
         
        public void ClickColumnHeader(string columnHeader)
        {
            this.ColumnHeaders[columnHeader].Click();
        }

        /// <summary>
        /// This method is designed to invoke (Click, or Keyboard access) the button
        /// in a cell.
        /// </summary>
        /// <param name="row">Row Index</param>
        /// <param name="cell">Cell Index</param>
        /// <history>
        /// 	[barryw] 08NOV05 Created
        /// </history>
        /// <remarks>Method overrides to be added later to support click mouse click
        /// and keyboard options</remarks>
       
        public void InvokeCellButton(int row, int cell)
        {
            Utilities.LogMessage("InvokeCellButton(...)");
            ActiveAccessibility cellAAObject = this.Rows[row].Cells[cell].AccessibleObject;
            
            ////Todo: Make sure cell is visible.
            ////cellAAObject.MakeVisible(cellAAObject.Parent.Parent, -1, true);
            Button button = new Button(
                cellAAObject.Window,
                null,
                StringMatchSyntax.ExactMatch,
                WindowClassNames.WinFormsButton,
                StringMatchSyntax.WildCard);
            if (null != button)
            {
                Utilities.LogMessage("InvokeCellButton :: ClassName: " + button.ClassName);
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(button); 
                button.Click();
                button.WaitForResponse();
                Utilities.LogMessage(
                    "InvokeCellButton :: " +
                    "Sucessfully Clicked on the button in row, column:" +
                    row.ToString() + "," + cell.ToString());
            }
            else
            {
                Utilities.LogMessage(
                    "InvokeCellButton :: " +
                    "Unable to find the button in the cell.");
                throw new DataGrid.Exceptions.WindowNotFoundException(
                    "InvokeCellButton :: " + 
                    "Unable to find the button in the cell.");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// GetColumnTitlePosition
        /// Returns the 0 based index of the column in the view based on the column name
        /// </summary>
        /// <param name="columnName">Column Name</param>
        /// <returns>0 based index of column</returns>
        /// <history>
        /// [mbickle] 26JUL05 Created
        /// [mbickle] 03NOV05 Commented out For Loop and just use the ColumnHeaders[name] option.
        /// [mbickle] 23NOV05 Added back loop to check if ColumnHeader is TopLeftHeader and 
        ///                   if it is, subtract 1 from index.  This was needed to handle
        ///                   some grid references where there was a rowheader column throwing 
        ///                   the index off by 1.
        /// </history>
        /// ------------------------------------------------------------------
         
        public int GetColumnTitlePosition(string columnName)
        {
            int columnCount = 0;
            int columnNamePosition = -1; // Does not exist.

            DataGridViewHeaderCollection columnHeaders = this.ColumnHeaders;
            
            // Get the Count of Columns.
            columnCount = columnHeaders.Count;
            Utilities.LogMessage("GridControl.GetColumnTitlePosition:: Column Header Count: " + 
                columnCount.ToString());

            for (int i = 0; i < columnCount; i++)
            {
                Utilities.LogMessage("GridControl.GetColumnTitlePosition:: Column Header: " +
                    columnHeaders[i].Name);

                // Checks if ColumnHeader Name is what we are looking for.
                // Will only find first instance, so if there is a dupe it won't find it.
                if (String.Compare(columnHeaders[i].Name, columnName, true) == 0)
                {
                    if (String.Compare(columnHeaders[0].Name, MsaaResources.Strings.TopLeftHeaderCell, true) == 0)
                    {
                        // This is to handle when we have a rowheader column that throws our 
                        // count off by one when selecting cell.
                        columnNamePosition = i - 1;
                    }
                    else
                    {
                        columnNamePosition = i;
                    }

                    break; // break out of for loop if found.
                }
            }

            Utilities.LogMessage("GridControl.GetColumnTitlePosition:: This column name is in position : " + 
                columnNamePosition.ToString());

            return columnNamePosition;
        }

        #region ClickCell Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Cell via Row/Cell
        /// </summary>
        /// <param name="row">Row Index</param>
        /// <param name="cell">Cell Index</param>
        /// <history>
        /// 	[mbickle] 26JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        
         public void ClickCell(int row, int cell)
         {
             this.ClickCell(row, cell, MouseClickType.SingleClick, MouseFlags.LeftButton);
         }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Cell via Row/Cell using specific Mouse Button
        /// </summary>
        /// <param name="row">Row Index</param>
        /// <param name="cell">Cell Index</param>
        /// <param name="button">MouseFlags Button</param>
        /// <history>
        /// 	[mbickle] 26JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
      
        public void ClickCell(int row, int cell, MouseFlags button)
        {
            this.ClickCell(row, cell, MouseClickType.SingleClick, button);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Cell via Row/Cell using MouseClickType (double clicks).
        /// </summary>
        /// <param name="row">Row Index</param>
        /// <param name="cell">Cell Index</param>
        /// <param name="clickType">MouseClickType</param>
        /// <history>
        /// 	[mbickle] 26JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
       
        public void ClickCell(int row, int cell, MouseClickType clickType)
        {
            this.ClickCell(row, cell, clickType, MouseFlags.LeftButton);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click Cell via Row/Cell using MouseClickType (double clicks).
        /// </summary>
        /// <param name="row">Row Index</param>
        /// <param name="cell">Cell Index</param>
        /// <param name="clickType">MouseClickType</param>
        /// <param name="button">MouseFlags</param>
        /// <history>
        /// 	[mbickle] 26JUL05 Created
        ///     [mbickle] 15AUG05 Added call to private MakeVisible Method
        ///                       Changed click to use Mouse.Click().
        ///     [ruhim]   14MAR06 Adding retry logic to verify click cell 
        ///                       actually clicked the cell.
        ///     [mbickle] 21APR06 Modified the Retry Logic to look at if Cell is Selected 
        ///                       This seems to solve the problem in views where only a Cell gets 
        ///                       selected and works the same if the row is selected.
        ///     [nathd]   02FEB09 Moved the OneSecond delay to the top of the retry while loop. In some cases the
        ///                       single click before the loop combined with the first single click in the loop
        ///                       was being interpreted as a double-click. Also note that in these cases 
        ///                       cellObject.Selected was false even though we had clicked on the cell before 
        ///                       evaluating.
        ///     [v-raienl]12JAN10 Added throwing exception when cellObject is still not selected after max retries
        ///                       Replaced cellObject.Selected with cellObject.Window.ScreenElement.HasFocus because
        ///                       cellObject.Selected does not work correctly for cells which contain other controls
        ///                       in it.
        ///     [billhodg]10MAR10 Rewrote CellClick to use RPF methods to correct for a problem where the cell was mostly scrolled offscreen
        /// </history>
        /// ------------------------------------------------------------------
         public void ClickCell(int row, int cell, MouseClickType clickType, MouseFlags button)
        {
            var expectedRow = this.Rows[row];
            var expectedCell = expectedRow.Cells[cell];
            var cellObject = expectedCell.AccessibleObject;
            var columnObject = this.ColumnHeaders[cell].AccessibleObject;

            // The CellVisible will take it as true even if only 1 pixel of a cell is visible, but at least this makes the privous
            // row completely visible, which might be used for select the expected row later
            if (!CellVisible(cellObject))
            {
                this.ScrollToRow(row);
                this.MakeVisible(cellObject, columnObject);
            }

            int xAxis = 0;
            int yAxis = 0;
            if (row == 1)
            {
                // For the 1st row in a grid, click point should be lower
                xAxis = cellObject.X + (cellObject.Width / 3);
                yAxis = cellObject.Y + (cellObject.Height / 3);
            }
            else
            {
                // For other rows, clickpoint should be close to it's top in case it's partly hidden by scrollbar
                xAxis = cellObject.X + (cellObject.Width / 3);
                yAxis = cellObject.Y + (cellObject.Height / 10);
            }

            CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();
            // Try to click the expected cell for 1st time
            Utilities.LogMessage("GridControl.ClickCell:: Attempt to click cell for the 1st time...");
            if (button == MouseFlags.RightButton)
            {
                // If the RightButton is being passed as parameter here, we need to click on cell using LeftButton first
                // to make sure the cellObject.Window.ScreenElement.HasFocus will have correct value
                Mouse.Click(clickType, MouseFlags.LeftButton, xAxis, yAxis);
            }
            Mouse.Click(clickType, button, xAxis, yAxis);

            // The retry logic here to make sure the expected cell is being selected correctly.
            int retry = 0;
            while (retry < Constants.DefaultMaxRetry)
            {
                if (cellObject.Window.ScreenElement.HasFocus)
                {
                    Utilities.LogMessage("GridControl:: Expected cell has the focus now, continueing automation test");
                    break;
                }
                else
                {
                    Utilities.LogMessage("GridControl.ClickCell:: Attempt Number " + retry + " of " + Constants.DefaultMaxRetry + " to Click Cell");
                    Utilities.TakeScreenshot("Cell not focus retry-"+retry);
                    Utilities.LogMessage("GridControl.ClickCell:: Not selected yet.  Sleeping for a second");
                    
                    Sleeper.Delay(Constants.OneSecond);
                    retry++;
                    CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();
                }

                // If the cell is in 1st row, just try to click it again
                if (row == 1)
                {
                    if (button == MouseFlags.RightButton)
                    {
                        // If the RightButton is being passed as parameter here, we need to click on cell using LeftButton first
                        // to make sure the cellObject.Window.ScreenElement.HasFocus will have correct value
                        Mouse.Click(clickType, MouseFlags.LeftButton, xAxis, yAxis);
                    }
                    Mouse.Click(clickType, button, xAxis, yAxis);
                }
                // #If the cell is not in 1st row, try clicking the prvious row and move down by arrow key
                // If the cell is not in 1st row, try to move up and move down by arrow key, then click again.
                else
                {
                    //Utilities.LogMessage("GridControl:: The expected cell does not have focus, and it's not in 1st row, so switch to click the cell in previous row and move down");
                    Utilities.LogMessage("GridControl:: The expected cell does not have focus, and it's not in 1st row, so switch to move up row and move down row, then continue to click.");

                    Keyboard.SendKeys(KeyboardCodes.UpArrow);
                    Sleeper.Delay(Constants.OneSecond * 3);
                    Keyboard.SendKeys(KeyboardCodes.DownArrow);
                    Sleeper.Delay(Constants.OneSecond * 3);

                    // #Get the accessible object of cell in previous row
                    // Get the accessible object of cell in current row
                    //var previousRow = this.Rows[row-1];
                    var previousRow = this.Rows[row];
                    var cellToBeClicked = previousRow.Cells[cell];
                    var accessibleObject = cellToBeClicked.AccessibleObject;

                    xAxis = accessibleObject.X + (accessibleObject.Width / 3);
                    yAxis = accessibleObject.Y + (accessibleObject.Height / 10);

                    if (button == MouseFlags.RightButton)
                    {
                        // If the RightButton is being passed as parameter here, we need to click on cell using LeftButton first
                        // to make sure the cellObject.Window.ScreenElement.HasFocus will have correct value
                        Mouse.Click(clickType, MouseFlags.LeftButton, xAxis, yAxis);
                    }
                    Mouse.Click(clickType, button, xAxis, yAxis);

                    //Keyboard.SendKeys(KeyboardCodes.DownArrow);
                }
            }

            if (!cellObject.Window.ScreenElement.HasFocus)
            {
                //If after max attempt times the cellObject is still not selected, should throw exception here.
                throw new ActiveAccessibility.Exceptions.CantSelectElementException("GridControl.ClickCell:: Failed to select cell even in Max retries");
            }
        }

        #endregion

        /// ------------------------------------------------------------------
        /// <summary>
        /// Get Cell Value via Row/Cell
        /// </summary>
        /// <param name="row">Row Index</param>
        /// <param name="cell">Cell Index</param>
        /// <returns>Cell Value String</returns>
        /// <history>
        /// 	[mbickle] 26JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
      
        public string GetCellValue(int row, int cell)
        {
            return this.Rows[row].Cells[cell].GetValue();
        }
        
        /// ------------------------------------------------------------------
        /// <summary>
        /// Get text from the cell, but first ensure the grid is stable
        /// and no new rows are showing up (making the cells collection 
        /// temporarily empty).
        /// </summary>
        /// <param name="rowIndex">Row Index</param>
        /// <param name="columnIndex">Cell Index</param>
        /// <returns>Cell Value String</returns>
        /// <history>
        /// 	[mcorning] 12.12.5 Created
        /// </history>
        /// ------------------------------------------------------------------
      
          public string GetCellText(int rowIndex, int columnIndex)
        {
            string currentCellText = null;
            Core.Common.Utilities.LogMessage("GridControl::GetCellText::Getting text from cell " + columnIndex + " in row " + rowIndex + "...");

            if (this.Rows[rowIndex].Cells.Count > columnIndex - 1)
            {
                currentCellText = this.Rows[rowIndex].Cells[columnIndex].GetValue();
                Core.Common.Utilities.LogMessage("GridControl::GetCellText::Cell " + columnIndex + " contains '" + currentCellText + "' in row " + rowIndex + "...");
            }
            else
            {
                Core.Common.Utilities.TakeScreenshot("GridIsAddingRows");
                Core.Common.Utilities.LogMessage("GridControl::GetCellText:: Cell count is presently " + this.Rows[rowIndex].Cells.Count + ", but we need column index, " + columnIndex + ".");
            }

            return currentCellText;
        }

        #region SetCellValue
        /// ------------------------------------------------------------------
        /// <summary>
        /// Sets Value in a TextBox Cell.
        /// </summary>
        /// <param name="row">Row Index</param>
        /// <param name="cell">Cell Index</param>
        /// <param name="value">Text Value</param>
        /// <history>
        /// 	[mbickle] 13AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public void SetCellValue(int row, int cell, string value)
        {
            this.SetCellValue(row, cell, value, DataGridViewCellType.TextBox);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Sets Value in a Text Cell.
        /// </summary>
        /// <param name="row">Row Index</param>
        /// <param name="cell">Cell Index</param>
        /// <param name="value">Text Value</param>
        /// <param name="cellType">DataGridViewCellType (TextBox/ComboBox)</param>
        /// <exception cref="System.ArgumentException">System.ArgumentException</exception>
        /// <history>
        /// 	[mbickle] 13AUG05 Created
        /// 	[nathd]   28JUL09 Added support for textbox with up/down control. In order to set the
        /// 	                  cell value we first need to select the current value so we overwrite 
        /// 	                  it. Since we do not have a DataGridViewCellType.UpDown cell type or 
        /// 	                  something similar I used DataGridViewCellType.Other in the switch below.
        /// </history>
        /// ------------------------------------------------------------------
        public void SetCellValue(int row, int cell, string value, DataGridViewCellType cellType)
        {            
            Utilities.LogMessage("GridControl.SetCellValue:: " + "row: " + row + " cell: " + cell + " value: " + value);

            ActiveAccessibility cellAAObject = this.Rows[row].Cells[cell].AccessibleObject;
            

            switch (cellType)
            {
                case DataGridViewCellType.TextBox:                   
                    try
                    {
                        this.Rows[row].Cells[cell].AccessibleObject.DoDefaultAction();
                        
                    }
                    catch (ActiveAccessibility.Exceptions.NoDefaultActionException)
                    {
                        Utilities.LogMessage("GridControl.SetCellValue:: Caught NoDefaultActionException - Now set the value");
                    }
                    EditComboBox textBox = new EditComboBox(this.Rows[row].Cells[cell].AccessibleObject.Window, null, StringMatchSyntax.WildCard, WindowClassNames.WinFormsEdit, StringMatchSyntax.WildCard);
                    textBox.SendKeys(value);  
                    break;
                case DataGridViewCellType.ComboBox:
                    try
                    {
                        this.Rows[row].Cells[cell].AccessibleObject.DoDefaultAction();
                    }
                    catch (ActiveAccessibility.Exceptions.NoDefaultActionException)
                    {
                        Utilities.LogMessage("GridControl.SetCellValue:: Caught NoDefaultActionException - Now set the value");
                    }
                    ComboBox combo = null;
                    CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccessSafe(delegate(){
                    combo = new ComboBox(this.Rows[row].Cells[cell].AccessibleObject.Window, null, StringMatchSyntax.WildCard, WindowClassNames.ComboBox, StringMatchSyntax.WildCard);
                    return null != combo;
                    });
                    
                    combo.SelectByText(value);                                                                             
                    break;
                case DataGridViewCellType.Other:
                    try
                    {
                        this.Rows[row].Cells[cell].AccessibleObject.DoDefaultAction();

                    }
                    catch (ActiveAccessibility.Exceptions.NoDefaultActionException)
                    {
                        Utilities.LogMessage("GridControl.SetCellValue:: Caught NoDefaultActionException - Now set the value");
                    }
                    EditComboBox textBoxWithUpDown = new EditComboBox(this.Rows[row].Cells[cell].AccessibleObject.Window, null, StringMatchSyntax.WildCard, WindowClassNames.WinFormsEdit, StringMatchSyntax.WildCard);
                    textBoxWithUpDown.SendKeys(KeyboardCodes.Ctrl + "A");
                    textBoxWithUpDown.SendKeys(value);
                    break;
                default:
                    throw new System.ArgumentException("GridControl.SetCellValue:: Invalid CellType passed.");
            }
        }

        /// <summary>
        /// Set value to data grid cell
        /// </summary>
        /// <param name="targetCell">data grid cell</param>
        /// <param name="value">text to set</param>
        public void SetCellValue(DataGridViewCell targetCell, string value)
        {
            if (targetCell == null)
            {
                throw new ArgumentNullException("targetCell");
            }

            int i = 0;
            bool textNotEquals = true;

            for (targetCell.AccessibleObject.Click(), Keyboard.SendKeys(value); (textNotEquals = !string.Equals(targetCell.GetValue(), value, StringComparison.InvariantCulture)) && i < 3; Keyboard.SendKeys(value), i++)
            {
                Keyboard.SendKeys(KeyboardCodes.SelectAll);
                Keyboard.SendKeys(KeyboardCodes.Backspace);
            }

            if (textNotEquals)
            {
                throw new Exception("Cannot set text to: " + value);
            }
        }

        /// <summary>
        /// Select option from data grid cell
        /// </summary>
        /// <param name="targetCell">data grid cell</param>
        /// <param name="option">item name to select</param>
        public void SetCellOption(DataGridViewCell targetCell, string option)
        {
            if (targetCell == null)
            {
                throw new ArgumentNullException("targetCell");
            }

            // This will make ComboBox available
            targetCell.AccessibleObject.Click();

            ComboBox combobox = new ComboBox(targetCell.AccessibleObject.Window);

            string firstLetter = option[0].ToString();
            string firstMatch = null;
            string cellValue = null;

            do
            {
                // This will make all options visible
                combobox.ClickDropDown();
                Keyboard.SendKeys(firstLetter);
                Sleeper.Delay(600);
                cellValue = targetCell.GetValue();

                if (firstMatch == null)
                {
                    firstMatch = cellValue;
                }
                else
                {
                    if (string.Equals(firstMatch, cellValue))
                    {
                        throw new Exception("Cannot find combobox item: " + option);
                    }
                }

                if (string.Equals(cellValue, option))
                {
                    break;
                }

            } while (!string.Equals(cellValue, option));
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Sets Value in a Text Cell - search based on WinFormsId.
        /// </summary>        
        /// <param name="parentWindow">parentWindow</param>
        /// <param name="value">Text Value</param>
        /// <param name="cellType">DataGridViewCellType (TextBox/ComboBox)</param>
        /// <param name="winFormsId">winFormsId of the control</param>
        /// <exception cref="System.ArgumentException">System.ArgumentException</exception>
        /// <history>
        /// 	[ruhim/dialac] 18Jan07 Created
        /// </history>
        /// ------------------------------------------------------------------
        //public void SetCellValue(int row, int cell, string value, DataGridViewCellType cellType, string winFormsId)
      
        public void SetCellValue(Window parentWindow, string value, DataGridViewCellType cellType, string winFormsId)
        {
            Utilities.LogMessage("GridControl.SetCellValue:: " + " value: " + value + " winFormsId: " + winFormsId);

            //ActiveAccessibility cellAAObject = this.Rows[row].Cells[cell].AccessibleObject;

            switch (cellType)
            {
                case DataGridViewCellType.TextBox:
                    try
                    {
                       // this.Rows[row].Cells[cell].AccessibleObject.DoDefaultAction();
                    }
                    catch (ActiveAccessibility.Exceptions.NoDefaultActionException)
                    {
                        Utilities.LogMessage("GridControl.SetCellValue:: Caught NoDefaultActionException - Now set the value");
                    }                    
                    EditComboBox textBox = new EditComboBox(parentWindow, winFormsId);
                    textBox.SendKeys(value);
                    break;
                case DataGridViewCellType.ComboBox:
                    try
                    {
                        //this.Rows[row].Cells[cell].AccessibleObject.DoDefaultAction();
                    }
                    catch (ActiveAccessibility.Exceptions.NoDefaultActionException)
                    {
                        Utilities.LogMessage("GridControl.SetCellValue:: Caught NoDefaultActionException - Now set the value");
                    }
                    ComboBox combo = new ComboBox(parentWindow, winFormsId);
                    combo.SelectByText(value);
                    break;
                default:
                    throw new System.ArgumentException("GridControl.SetCellValue:: Invalid CellType passed.");
            }
        }
           /// <summary>
        /// This method is designed to navigate the dropdown list using
        /// the keyboard, do a case sensitive match to the item specified
        /// and set the cell value to the located item value.
        /// </summary>
        /// <param name="row">row index</param>
        /// <param name="cell">cell index</param>
        /// <param name="value">value in the dropdown list</param>
        /// <exception cref="Maui.Core.WinControls.DataGridView.Exceptions">.FailedToSetValueException - Value not found in dropdown</exception>
        /// <remarks>Overloads for this method will be added to
        /// allow the selection of an item by index number.
        /// Exceptions that would not cross-reference:
        ///     cref="FailedToSetValueException" Value not found in dropdown.
        /// </remarks>
        /// <history>
        /// 	[ruhim] 23MAR06 Updated the original method written by Barry.But doesn't work
        /// </history>
        [Obsolete("Non-functional")]
        public void SetCellValueUsingDropDown(int row, int cell, string value)
        {
            //// Collapse the dropdown so the items may be 
            //// navigated using the left and right cursor keys.
            ////this.SendKeys(KeyboardCodes.Alt + KeyboardCodes.UpArrow);

            this.ClickCell(row, cell);

            // Get the First element in the drop down
            this.SendKeys(KeyboardCodes.UpArrow);

            ////string value = "Equals";
            string previousCellValue = "";
            string currentCellValue = "";
            bool foundTheValue = false;

            #region Position to top of list

            // Position to top of dropdown list.
            while (foundTheValue == false)
            {                
                currentCellValue = this.GetCellValue(row, cell);
                
                // select next value using arrow key.
                this.SendKeys(KeyboardCodes.DownArrow);
                if (string.Compare(currentCellValue, value) == 0)
                {
                    foundTheValue = true;
                }

                if (currentCellValue == previousCellValue)
                {
                    // reached the beginning of the list of values.
                    break;
                }

                previousCellValue = currentCellValue;
            }

            #endregion  // Position to top of list.

            ////#region Locate item

            ////while (foundTheValue == false)
            ////{
            ////    previousCellValue = currentCellValue;
            ////    currentCellValue = this.GetCellValue(row, cell);
            ////    if (currentCellValue == value)
            ////    {
            ////        // The value wanted is now in the cell. 
            ////        foundTheValue = true;
            ////        break;
            ////    }
            ////    else
            ////    {
            ////        // select next value using arrow key.
            ////        this.SendKeys(KeyboardCodes.RightArrow);
            ////    }

            ////    if (currentCellValue == previousCellValue)
            ////    {
            ////        // reached the end of the list of values.
            ////        break;
            ////    }
            ////}
            ////#endregion  // Locate item.

            if (foundTheValue == false)
            {
                // we didn't find the value, so throw exception.
                throw new DataGridView.Exceptions.FailedToSetValueException("Value not found in dropdown: " + value);
            }            
        }

        #endregion

        #region Search Methods

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to search the rows and specified column of a grid for the 
        /// specified search string using the specified match criteria.
        /// </summary>
        /// <param name="searchData">String to find in grid cells</param>
        /// <param name="columnIndex">Index of the column to search</param>
        /// <param name="matchType">
        /// The type of match to perform with the search data
        /// </param>
        /// <returns>DataGridViewRow or null if no match was found</returns>
        /// <history>
        /// [mbickle] 03NOV05 Changed Rows to start at 1 due to the way the RTM Grid Control works.
        ///                   Row0 is the Header and you can't click/get values from it.
        /// [mcorning] 03DEC05 Because populating the grid fully can take time (especially when
        ///                    MOM starts), we double check for a valid reference to the current
        ///                    row's Cell collection.
        /// [mbickle] 23MAR06 Caching the Rows collection to make traversing much quicker.
        /// [faizalk] 18JUL06 Really caching the Rows collection and retrying if this.Rows.count changes
        /// </history>
        /// ------------------------------------------------------------------
        
        public Maui.Core.WinControls.DataGridViewRow FindData(
            string searchData,
            int columnIndex,
            SearchStringMatchType matchType)
        {
            // count tracking variables
            int thisRowsCount;
            int updatedRowsCount;
            
            // placeholder row
            Maui.Core.WinControls.DataGridViewRow selectedRow = null;

            // we wrap this in a do/while loop because the this.Rows.Count can
            // change out from under us during a view refresh or moments after
            // the Find bar has been used
            do
            {
                // cache Row Collection to rowArray

                thisRowsCount = this.Rows.Count;
                DataGridViewRow[] rowArray = new DataGridViewRow[thisRowsCount];
                try
                {
                    this.Rows.CopyTo(rowArray, 0);    //If Rows count change now, case will fail due to an ArgumentException, try to catch it for fixing bug #532487
                }
                catch (System.ArgumentException)
                {
                    updatedRowsCount = this.Rows.Count;
                    Utilities.LogMessage(string.Format("GridControl::FindData::Row current count maybe changed from {0} to {1}, need re-run logic again:  ", thisRowsCount, updatedRowsCount));
                    continue;
                }

                if (thisRowsCount <= 1)
                {
                    this.WaitForRowCount();
                    thisRowsCount = this.Rows.Count;
                    rowArray = new DataGridViewRow[thisRowsCount];
                    this.Rows.CopyTo(rowArray, 0);
                }

                // reset the grid to the very top
                // Core.Common.Utilities.LogMessage("GridControl::FindData::Resetting grid scroll window to top...");
                ////this.Click();
                ////this.SendKeys(KeyboardCodes.Ctrl + "(" + KeyboardCodes.Home + ")");

                #region Diagnostic Logging

                Core.Common.Utilities.LogMessage("GridControl::FindData::Searching grid view for text:  '" +
                    searchData + "'");

                Core.Common.Utilities.LogMessage("GridControl::FindData::Number of grid rows:  " + thisRowsCount);

                // get the number of cells per row
                int cellCount = 0;
                if (thisRowsCount > 1)
                {
                    cellCount = rowArray[1].Cells.Count;
                    if (cellCount == 0)
                    {
                        Utilities.LogMessage("GridControl::FindData:: cellCount == 0, get Rows again");

                        // Lets get the Rows again, we shouldn't have 0 Cells.
                        thisRowsCount = this.Rows.Count;
                        rowArray = new DataGridViewRow[thisRowsCount];
                        this.Rows.CopyTo(rowArray, 0);
                        cellCount = rowArray[1].Cells.Count;
                    }
                }

                Core.Common.Utilities.LogMessage("GridControl::FindData::Number of grid cells:  " + cellCount);

                #endregion // Diagnostic Logging

                #region Variables

                // placeholder for current cell's text data
                string currentCellText = null;

                // count for number of search tries
                int searchTries = 0;

                #endregion // Variables

                // if there is at least one row in the grid
                ////if (rowCollection.Count > 1)
                ////{
                ////    // select it
                ////    rowCollection[1].AccessibleObject.Click();
                ////}

                searchTries++;
                Utilities.LogMessage("GridControl::FindData::Performing full array search #" + searchTries);


                // iterate through each row
                for (int rowIndex = 1; rowIndex < rowArray.Length; rowIndex++)
                {
                    try
                    {
                        #region Make Row And Cell Visible

                        #region Check For Grid Refresh In Progress

                        ////Core.Common.Utilities.LogMessage("GridControl::FindData::Checking for grid refresh...");

                        // check for the row count dropping to zero or below
                        ////if (this.Rows.Count <= 1)
                        ////{
                        ////    // wait for the row count to return
                        ////    this.WaitForRowCount();
                        ////}

                        #endregion // Check For Grid Refresh In Progress

                        ////this.ExpandAllRows(rowCount);

                        ////this.ScrollToRow(rowIndex);

                        #endregion // Make Row And Cell Visible

                        #region Get Cell Text
                        //// currentCellText = this.GetCellText(rowIndex, columnIndex);
                        currentCellText = rowArray[rowIndex].Cells[columnIndex].GetValue();
                        #endregion // Get Cell Text

                        #region Perform Text Matching

                        Core.Common.Utilities.LogMessage("GridControl::FindData::Row " + rowIndex + ", matching search text:  '" + searchData + "' to cell text:  '" + currentCellText + "'");

                        // match the current device name exactly
                        if (matchType == SearchStringMatchType.ExactMatch
                            && currentCellText.CompareTo(searchData) == 0)
                        {
                            Core.Common.Utilities.LogMessage("GridControl::FindData::Found exact match:  '" +
                                currentCellText + "'");

                            // match exact 
                            selectedRow = rowArray[rowIndex];
                            break;
                        }
                        else if (matchType == SearchStringMatchType.PrefixMatch
                            && currentCellText.ToLowerInvariant().StartsWith(searchData.ToLowerInvariant()))
                        {
                            Core.Common.Utilities.LogMessage("GridControl::FindData::Found prefix match:  '" +
                                currentCellText + "'");

                            // match prefix
                            selectedRow = rowArray[rowIndex];
                            break;
                        }
                        else if (matchType == SearchStringMatchType.ContainsMatch
                            && currentCellText.ToLowerInvariant().Contains(searchData.ToLowerInvariant()))
                        {
                            Core.Common.Utilities.LogMessage("GridControl::FindData::Found contains match:  '" +
                                currentCellText + "'");

                            // match contains
                            selectedRow = rowArray[rowIndex];
                            break;
                        }

                        #endregion // Perform Text Matching

                        // move the highlight to the next row
                        //// this.SendKeys(KeyboardCodes.DownArrow);
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        Utilities.LogMessage("GridControl::FindData::Grid Rows count changed, need go to search rows again...");
                        rowIndex = rowArray.Length;
                    }
                }

                updatedRowsCount = this.Rows.Count;
                Utilities.LogMessage("GridControl::FindData::If " + thisRowsCount + " != " + updatedRowsCount + " then we're going to search rows again...");
            } while (thisRowsCount != updatedRowsCount);

            // If selectedRow found, lets make it visible.
            // Currently commented out because this can take some time.
            ////if (selectedRow != null)
            ////{
            ////    this.MakeVisible(
            ////        selectedRow.Cells[0].AccessibleObject,
            ////        this.ColumnHeaders[0].AccessibleObject);
                
            ////    selectedRow.AccessibleObject.Click();
            ////}

            // return the row contaning the data
            return selectedRow;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to search the rows and specified column of a grid for the 
        /// specified search string using widest possible match criteria:  
        /// contains string.
        /// </summary>
        /// <param name="searchData">String to find in grid cells</param>
        /// <param name="columnIndex">Index of the column to search</param>
        /// <returns>DataGridViewRow or null if no match was found</returns>
        /// ------------------------------------------------------------------
       
        public Maui.Core.WinControls.DataGridViewRow FindData(
            string searchData,
            int columnIndex)
        {
            // call FindData and use widest possible match criteria
            return this.FindData(searchData, columnIndex, SearchStringMatchType.ContainsMatch);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to search the rows and and named column of a grid for the 
        /// specified search string using widest possible match criteria:  
        /// contains string.
        /// </summary>
        /// <param name="searchData">String to find in grid cells</param>
        /// <param name="columnName">Name of the column to search</param>
        /// <returns>DataGridViewRow or null if no match was found</returns>
        /// ------------------------------------------------------------------
        
        public Maui.Core.WinControls.DataGridViewRow FindData(
            string searchData,
            string columnName)
        {
            #region Diagnostic Logging

            Core.Common.Utilities.LogMessage("GridControl::FindData::Listing columnName data for grid...");
            foreach (DataGridViewHeader header in this.ColumnHeaders)
            {
                Core.Common.Utilities.LogMessage("GridControl::FindData::" +
                    "Header '" + header.Name +
                    "' has text '" +
                    header.AccessibleObject.Value +
                    "' at index " +
                    header.AccessibleObject.Index);
            }
            #endregion // Diagnostic Logging

            // get the index number of the column to search
            Core.Common.Utilities.LogMessage("GridControl::FindData::Looking for column index of column named:  '" + columnName + "'");
            int columnIndex = this.ColumnHeaders[columnName].AccessibleObject.Index;
            Core.Common.Utilities.LogMessage("GridControl::FindData::Column index of column:  " + columnIndex);

            // return the data found based on column index
            return this.FindData(searchData, columnIndex, SearchStringMatchType.ContainsMatch);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to search the rows and and named column of a grid for the 
        /// specified search string using the specified match criteria.
        /// </summary>
        /// <param name="searchData">String to find in grid cells</param>
        /// <param name="columnName">Name of the column to search</param>
        /// <param name="matchType">
        /// The type of match to perform with the search data
        /// </param>
        /// <returns>DataGridViewRow or null if no match was found</returns>
        /// ------------------------------------------------------------------
        
        public Maui.Core.WinControls.DataGridViewRow FindData(
            string searchData,
            string columnName,
            SearchStringMatchType matchType)
        {
            #region Diagnostic Logging

            Core.Common.Utilities.LogMessage("GridControl::FindData::Listing columnName data for grid...");
            foreach (DataGridViewHeader header in this.ColumnHeaders)
            {
                Core.Common.Utilities.LogMessage("GridControl::FindData::" +
                    "Header '" + header.Name +
                    "' has text '" +
                    header.AccessibleObject.Value +
                    "' at index " +
                    header.AccessibleObject.Index);
            }
            #endregion // Diagnostic Logging

            // get the index number of the column to search
            Core.Common.Utilities.LogMessage("GridControl::FindData::Looking for column index of column named:  '" + columnName + "'");
            int columnIndex = this.ColumnHeaders[columnName].AccessibleObject.Index;
            Core.Common.Utilities.LogMessage("GridControl::FindData::Column index of column:  " + columnIndex);

            // return the data found based on column index
            return this.FindData(searchData, columnIndex, matchType);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to search the rows and cells of a grid for the specified
        /// search string using widest possible match criteria:  
        /// contains string.
        /// </summary>
        /// <param name="searchData">String to find in grid cells</param>
        /// <returns>DataGridViewRow or null if no match was found</returns>
        /// ------------------------------------------------------------------
       
        public Maui.Core.WinControls.DataGridViewRow FindData(
            string searchData)
        {
            // call FindData with the widest match criteria
            return this.FindData(searchData, SearchStringMatchType.ContainsMatch);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to search the rows and cells of a grid for the specified
        /// search string using the specified match criteria.
        /// </summary>
        /// <param name="searchData">String to find in grid cells</param>
        /// <param name="matchType">
        /// The type of match to perform with the search data
        /// </param>
        /// <returns>DataGridViewRow or null if no match was found</returns>
        /// ------------------------------------------------------------------
       
        public Maui.Core.WinControls.DataGridViewRow FindData(
            string searchData,
            SearchStringMatchType matchType)
        {
            // placeholder row
            Maui.Core.WinControls.DataGridViewRow selectedRow = null;

            //Bug#201897: Timing issue. Sometimes the filter resule won't appear in Rules view immediately.
            //Bug#209619: Timing issue. filter result is not correct after the filter is done, so it also needs to retry even if there are instances in Rules view.
            int maxRetry = Constants.DefaultMaxRetry;
            int retries = 0;
            while (retries < maxRetry)
            {
                // get the row header collection
                foreach (DataGridViewHeader columnHeader in this.ColumnHeaders)
                {
                    // get the first row that matches for this column
                    selectedRow = this.FindData(searchData, columnHeader.AccessibleObject.Index, matchType);

                    // check for a match in this column
                    if (null != selectedRow)
                    {
                        // found a match
                        break;
                    }
                }

                if (selectedRow != null)
                {
                    break;
                }
                else
                {
                    Utilities.TakeScreenshot("FindData.RowNotFound");
                    Sleeper.Delay(Constants.OneSecond * 2);
                }

                retries++;
            }

            // return the row
            return selectedRow;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to search the rows and specified column of a grid for the 
        /// specified search string using the specified match criteria.
        /// </summary>
        /// <param name="searchData">String to find in grid cells</param>
        /// <param name="columnIndex">Index of the column to search</param>
        /// <param name="matchType">
        /// The type of match to perform with the search data
        /// </param>
        /// <returns>
        /// DataGridViewRowCollection or null if no match was found
        /// </returns>
        /// <history>
        /// 12.12.5     MCorning use save cell access helper method.
        /// </history>
        /// ------------------------------------------------------------------
         public List<Maui.Core.WinControls.DataGridViewRow> FindDataRows(
            string searchData,
            int columnIndex,
            SearchStringMatchType matchType)
        {
            // Caching the Row Collection to speed things up.
            DataGridViewRowCollection rowCollection = this.Rows;

            // reset the grid to the very top
            Core.Common.Utilities.LogMessage("GridControl::FindDataRows::Resetting grid scroll window to top...");
            ////this.Click();
            ////this.SendKeys(KeyboardCodes.Ctrl + "(" + KeyboardCodes.Home + ")");

            #region Diagnostic Logging

            Core.Common.Utilities.LogMessage("GridControl::FindDataRows::Searching grid view for text:  '" +
                searchData + "'");

            // get the number of grid rows
            int rowCount = rowCollection.Count;
            Core.Common.Utilities.LogMessage("GridControl::FindDataRows::Number of grid rows:  " + rowCount);

            // get the number of cells per row
            int cellCount = 0;
            if (rowCount > 0)
            {
                cellCount = this.ColumnHeaders.Count;
            }

            Core.Common.Utilities.LogMessage("GridControl::FindDataRows::Number of grid cells:  " + cellCount);

            #endregion // Diagnostic Logging

            #region Variables

            // placeholder row
            List<Maui.Core.WinControls.DataGridViewRow> selectedRows =
                new List<DataGridViewRow>();

            // placeholder for current cell's text data
            string currentCellText = null;

            #endregion // Variables

            // if there is at least one row in the grid
            ////if (rowCollection.Count > 1)
            ////{
            ////    // select it
            ////    rowCollection[1].AccessibleObject.Click();
            ////}
            try
            {
            // iterate through each row
            for (int rowIndex = 1; rowIndex < rowCollection.Count; rowIndex++)
            {
                #region Make Row And Cell Visible

                #region Check For Grid Refresh In Progress

                ////Core.Common.Utilities.LogMessage("GridControl::FindData::Checking for grid refresh...");

                // check for the row count dropping to zero or below
                ////if (this.Rows.Count <= 1)
                ////{
                ////    // wait for the row count to return
                ////    this.WaitForRowCount();
                ////}

                #endregion // Check For Grid Refresh In Progress

                ////this.ExpandAllRows(rowCount);

                ////this.ScrollToRow(rowIndex);

                #endregion // Make Row And Cell Visible

                #region Get Cell Text
                // currentCellText = this.GetCellText(rowIndex, columnIndex);
                currentCellText = rowCollection[rowIndex].Cells[columnIndex].GetValue();
                #endregion // Get Cell Text

                #region Perform Text Matching

                Core.Common.Utilities.LogMessage("GridControl::FindDataRows::Matching search text:  '" + searchData + "' to cell text:  '" + currentCellText + "' rowIndex: " + rowIndex.ToString());

                // match the current device name exactly
                if (matchType == SearchStringMatchType.ExactMatch
                    && currentCellText.CompareTo(searchData) == 0)
                {
                    Core.Common.Utilities.LogMessage("GridControl::FindDataRows::Found exact match:  '" +
                            currentCellText + "' at row" + rowIndex);

                    // match exact 
                    selectedRows.Add(rowCollection[rowIndex]);
                }
                else if (matchType == SearchStringMatchType.PrefixMatch
                    && currentCellText.ToLowerInvariant().StartsWith(searchData.ToLowerInvariant()))
                {
                    Core.Common.Utilities.LogMessage("GridControl::FindDataRows::Found prefix match:  '" +
                        currentCellText + "'");

                    // match prefix
                    selectedRows.Add(rowCollection[rowIndex]);
                }
                else if (matchType == SearchStringMatchType.ContainsMatch
                    && currentCellText.ToLowerInvariant().Contains(searchData.ToLowerInvariant()))
                {
                    Core.Common.Utilities.LogMessage("GridControl::FindDataRows::Found contains match:  '" +
                        currentCellText + "'");

                    // match contains
                    selectedRows.Add(rowCollection[rowIndex]);
                }
                #endregion // Perform Text Matching

                // move the highlight to the next row
                ////this.SendKeys(KeyboardCodes.DownArrow);
                }
            }
            catch (System.ArgumentOutOfRangeException aoore)
            {
                Mcf.FrameworkContext.Trc("FindDataRows::TRC.DEBUG:: count reported inaccurately, hit " + aoore.ToString());
            }

            // if there are no matches in the list
            if (selectedRows.Count <= 0)
            {
                Mcf.FrameworkContext.Trc("FindDataRows: Failed to find any rows.");
                // set the list to null
                selectedRows = null;
            }

            // return the selected rows
            return selectedRows;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Find Instance in Grid and return Row Index.
        /// </summary>
        /// <param name="columnNameOne">First Column to search</param>
        /// <param name="columnNameTwo">Second Column to search</param>
        /// <param name="compareValueOne">First Value to Find to be compared</param>
        /// <param name="compareValueTwo">Second Value to find to be compared</param>
        /// <param name="maxTries">Number of Tries to Find Instance</param>
        /// <returns>DataGridViewRow</returns>
        /// <history>
        /// [mbickle] 18APR06: Created
        /// [nathd]   25NOV08: Moved the core of this method to an overloaded method 
        ///                    that accepts a SearchStringMatchType.
        /// </history>
        /// -------------------------------------------------------------------
        public DataGridViewRow FindInstanceRow(
            string columnNameOne,
            string columnNameTwo,
            string compareValueOne,
            string compareValueTwo,
            int maxTries)
        {
            return FindInstanceRow(columnNameOne,
                columnNameTwo,
                compareValueOne,
                compareValueTwo,
                maxTries,
                SearchStringMatchType.ContainsMatch);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Find Instance in Grid and return Row Index.
        /// </summary>
        /// <param name="columnNameOne">First Column to search</param>
        /// <param name="columnNameTwo">Second Column to search</param>
        /// <param name="compareValueOne">First Value to Find to be compared</param>
        /// <param name="compareValueTwo">Second Value to find to be compared</param>
        /// <param name="maxTries">Number of Tries to Find Instance</param>
        /// <param name="matchType">Match Type: Exact, Contains or Prefix</param>
        /// <returns>DataGridViewRow</returns>
        /// <history>
        /// [mbickle] 18APR06: Created
        /// [nathd]   25NOV08: Overloaded method to accept a SearchStringMatchType.
        /// </history>
        /// -------------------------------------------------------------------
        public DataGridViewRow FindInstanceRow(
            string columnNameOne,
            string columnNameTwo,
            string compareValueOne,
            string compareValueTwo,
            int maxTries,
            SearchStringMatchType matchType)
        {
            bool foundInstance = false;
            int timeout = 60000;
            int loopCount = 0;
            int colposOne = 0;
            int colposTwo = 0;
            int rowpos = 0;
            DataGridViewRow instanceRow = null;
            GridControl grid = this;
            compareValueTwo = compareValueTwo.ToLowerInvariant();

            if (grid != null)
            {
                Utilities.LogMessage("GridControl.FindInstanceRow:: Found View Grid");

                colposOne = grid.GetColumnTitlePosition(columnNameOne);
                colposTwo = grid.GetColumnTitlePosition(columnNameTwo);

                Utilities.LogMessage("GridControl.FindInstanceRow:: columnNameOne: " + columnNameOne + ", position: " + colposOne + ", compareValueOne:" + compareValueOne);
                Utilities.LogMessage("GridControl.FindInstanceRow:: columnNameTwo: " + columnNameTwo + ", position: " + colposTwo + ", compareValueTwo:" + compareValueTwo);
                List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();

                // Looking for Discovered Instance Name in Name column for State View Grid
                loopCount = 0;
                while (!foundInstance && loopCount <= maxTries)
                {
                    try
                    {
                        selectedRows = grid.FindDataRows(
                            compareValueOne,
                            colposOne,
                            matchType);

                        if (selectedRows != null && selectedRows.Count != 0)
                        {
                            foreach (Maui.Core.WinControls.DataGridViewRow dataGridRow in selectedRows)
                            {
                                Utilities.LogMessage("GridControl.FindInstanceRow:: Found the counter name " + compareValueOne);
                                instanceRow = dataGridRow;
                                rowpos = dataGridRow.AccessibleObject.Index;

                                string cellValueTwo = grid.GetCellValue(rowpos, colposTwo).ToLowerInvariant();
                                Utilities.LogMessage("GridControl::FindInstanceRow :: Matching search text:  '" + columnNameTwo + "' to cell text:  '" + cellValueTwo + "' rowIndex: " + rowpos.ToString());
                                
                                switch (matchType)
                                {
                                    case SearchStringMatchType.ContainsMatch:
                                        foundInstance = cellValueTwo.Contains(compareValueTwo);
                                        break;

                                    case SearchStringMatchType.ExactMatch:
                                        foundInstance = cellValueTwo.Equals(compareValueTwo);
                                        break;

                                    case SearchStringMatchType.PrefixMatch:
                                        foundInstance = cellValueTwo.StartsWith(compareValueTwo);
                                        break;
                                }
                                
                                if (foundInstance)
                                {
                                    Utilities.LogMessage("GridControl.FindInstanceRow:: Successfully matched instance: " + compareValueTwo);
                                    break;
                                }
                            }
                        }
                    }
                    catch (System.NullReferenceException)
                    {
                        Utilities.LogMessage("GridControl.FindInstanceRow:: NullReferenceException, lets just ignore and try again.");
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        Utilities.LogMessage("GridControl.FindInstanceRow:: ArgumentOutOfRangeException, lets just ignore and try again.");
                    }

                    if (!foundInstance)
                    {
                        Utilities.TakeScreenshot("Search Result");
                        Utilities.LogMessage("GridControl.FindInstanceRow:: Matching Instance not found, try again.");

                        // refresh the view
                        grid.Click();
                        CoreManager.MomConsole.Refresh();
                        // Delay one second to ensure every retry time is one second
                        Sleeper.Delay(Constants.OneSecond);
                        UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, timeout);
                        UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, timeout);
                        CoreManager.MomConsole.Waiters.WaitForStatusReady(timeout);
                    }

                    Utilities.LogMessage("GridControl.FindInstanceRow:: Loop Count: " + loopCount.ToString());
                    loopCount++;
                }
            }

            if (!foundInstance)
            {
                // Setting this to null since we didn't find it.
                instanceRow = null;
            }

            return instanceRow;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Find Instance in Grid and return Row Index.
        /// </summary>
        /// <param name="columnNameOne">First Column to search</param>
        /// <param name="columnNameTwo">Second Column to search</param>
        /// <param name="columnNameThree">Third Column to search</param>
        /// <param name="compareValueOne">First Value to Find to be compared</param>
        /// <param name="compareValueTwo">Second Value to find to be compared</param>
        /// <param name="compareValueThree">Third Value to find to be compared</param>
        /// <param name="maxTries">Number of Tries to Find Instance</param>
        /// <returns>DataGridViewRow</returns>
        /// <history>
        /// [dialac] 18JUL06: Created
        /// [nathd]  25NOV08: Moved the core of this method to an overloaded method 
        ///                   that accepts a SearchStringMatchType.
        /// </history>
        /// -------------------------------------------------------------------
          public DataGridViewRow FindInstanceRow(
            string columnNameOne,
            string columnNameTwo,
            string columnNameThree,
            string compareValueOne,
            string compareValueTwo,
            string compareValueThree,
            int maxTries)
        {
            return FindInstanceRow(columnNameOne,
                columnNameTwo,
                columnNameThree,
                compareValueOne,
                compareValueTwo,
                compareValueThree,
                maxTries,
                SearchStringMatchType.ContainsMatch);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Find Instance in Grid and return Row Index.
        /// </summary>
        /// <param name="columnNameOne">First Column to search</param>
        /// <param name="columnNameTwo">Second Column to search</param>
        /// <param name="columnNameThree">Third Column to search</param>
        /// <param name="compareValueOne">First Value to Find to be compared</param>
        /// <param name="compareValueTwo">Second Value to find to be compared</param>
        /// <param name="compareValueThree">Third Value to find to be compared</param>
        /// <param name="maxTries">Number of Tries to Find Instance</param>
        /// <param name="matchType">Match Type: Exact, Contains or Prefix</param>
        /// <returns>DataGridViewRow</returns>
        /// <history>
        /// [dialac] 18JUL06: Created
        /// [nathd]  25NOV08: Overloaded method to accept a SearchStringMatchType.
        /// </history>
        /// -------------------------------------------------------------------
        public DataGridViewRow FindInstanceRow(
            string columnNameOne,
            string columnNameTwo,
            string columnNameThree,
            string compareValueOne,
            string compareValueTwo,
            string compareValueThree,
            int maxTries,
            SearchStringMatchType matchType)
        {
            bool foundInstance = false;
            int timeout = 60000;
            int loopCount = 0;
            int colposOne = 0;
            int colposTwo = 0;
            int colposThree = 0;
            int rowpos = 0;
            DataGridViewRow instanceRow = null;
            GridControl grid = this;
            compareValueTwo = compareValueTwo.ToLowerInvariant();
            compareValueThree = compareValueThree.ToLowerInvariant();

            if (grid != null)
            {
                Utilities.LogMessage("GridControl.FindInstanceRow:: Found View Grid");

                colposOne = grid.GetColumnTitlePosition(columnNameOne);
                colposTwo = grid.GetColumnTitlePosition(columnNameTwo);
                colposThree = grid.GetColumnTitlePosition(columnNameThree);

                Utilities.LogMessage("GridControl.FindInstanceRow:: columnNameOne: " + columnNameOne + ", position: " + colposOne + ", compareValueOne:" + compareValueOne);
                Utilities.LogMessage("GridControl.FindInstanceRow:: columnNameTwo: " + columnNameTwo + ", position: " + colposTwo + ", compareValueTwo:" + compareValueTwo);
                Utilities.LogMessage("GridControl.FindInstanceRow:: columnNameThree: " + columnNameThree + ", position: " + colposThree + ", compareValueThree:" + compareValueThree);
                List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();

                // Looking for Discovered Instance Name in Name column for State View Grid
                loopCount = 0;
                while (!foundInstance && loopCount <= maxTries)
                {
                    try
                    {
                        selectedRows = grid.FindDataRows(
                            compareValueOne,
                            colposOne,
                            matchType);

                        if (selectedRows != null && selectedRows.Count != 0)
                        {
                            foreach (Maui.Core.WinControls.DataGridViewRow dataGridRow in selectedRows)
                            {
                                Utilities.LogMessage("GridControl.FindInstanceRow:: Found the counter name " + compareValueOne);
                                instanceRow = dataGridRow;
                                rowpos = dataGridRow.AccessibleObject.Index;
                                string cellValueTwo = grid.GetCellValue(rowpos, colposTwo).ToLowerInvariant();
                                Utilities.LogMessage("GridControl::FindInstanceRow :: Matching search text:  '" + columnNameTwo + "' to cell text:  '" + cellValueTwo + "' rowIndex: " + rowpos.ToString());

                                string cellValueThree = grid.GetCellValue(rowpos, colposThree).ToLowerInvariant();
                                Utilities.LogMessage("GridControl::FindInstanceRow :: Matching search text:  '" + columnNameThree + "' to cell text:  '" + cellValueThree + "' rowIndex: " + rowpos.ToString());

                                switch (matchType)

                                {

                                    case SearchStringMatchType.ContainsMatch:

                                        foundInstance = cellValueTwo.Contains(compareValueTwo) && cellValueThree.Contains(compareValueThree);

                                        break;

                                    case SearchStringMatchType.ExactMatch:
                                        foundInstance = cellValueTwo.Equals(compareValueTwo) && cellValueThree.Equals(compareValueThree);
                                        break;

                                    case SearchStringMatchType.PrefixMatch:
                                        foundInstance = cellValueTwo.StartsWith(compareValueTwo) && cellValueThree.StartsWith(compareValueThree);
                                        break;

                                }

                                if (foundInstance)
                                {
                                    Utilities.LogMessage("GridControl.FindInstanceRow:: Successfully matched instance. Path: " + compareValueTwo + " Instance: " + compareValueThree);
                                    break;
                                }
                            }
                        }
                    }
                    catch (System.NullReferenceException)
                    {
                        Utilities.LogMessage("GridControl.FindInstanceRow:: NullReferenceException, lets just ignore and try again.");
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        Utilities.LogMessage("GridControl.FindInstanceRow:: ArgumentOutOfRangeException, lets just ignore and try again.");
                    }

                    if (!foundInstance)
                    {
                        Utilities.LogMessage("GridControl.FindInstanceRow:: Matching Instance not found, try again.");

                        // refresh the view
                        grid.Click();
                        CoreManager.MomConsole.Refresh();
                        // Delay one second to ensure every retry time is one second
                        Sleeper.Delay(Constants.OneSecond);
                        UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, timeout);
                        UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, timeout);
                        CoreManager.MomConsole.Waiters.WaitForStatusReady(timeout);
                    }

                    Utilities.LogMessage("GridControl.FindInstanceRow:: Loop Count: " + loopCount.ToString());
                    loopCount++;
                }
            }

            if (!foundInstance)
            {
                // Setting this to null since we didn't find it.
                instanceRow = null;
            }

            return instanceRow;
        }
        #endregion // Search Methods

        /// <summary>
        /// Method to wait for grid view loading
        /// </summary>
        /// <history>
        /// [v-vijia] 17MAY2011 Created
        /// [v-bire]  24JUN2011 Modified
        /// </history>
        public void WaitForRowsLoaded()
        {
            CoreManager.MomConsole.Waiters.WaitForReady(Constants.OneMinute / 2); // 30 seconds 
            this.WaitForResponse();

            Sleeper sleeper = new Sleeper(Constants.OneMinute * 5); // 5 mins
            while (sleeper.IsNotExpired)
            {
                try
                {
                    sleeper.Sleep();
                    //There is 1 row at least in R2 views. This row is column row.
                    if (this.Rows.Count > 1)
                    {
                        Utilities.LogMessage("WaitForStateViewLoading:: Grid view loading is done, now Rows count := " + this.Rows.Count);
                        return;
                    }
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Utilities.LogMessage("WaitForStateViewLoading:: Grid view is not ready ");
                }
            }
        }

        /// <summary>
        /// Makes the current cell visible.
        /// </summary>
        /// <param name="gridControlCellObject">Cell ActiveAccessibility Object</param>
        /// <param name="gridControlColumnObject">Column ActiveAccessibility Object</param>
        /// <exception cref="DataGridView.Exceptions.DataGridViewHeaderNotFoundException">
        /// DataGridView.Exceptions.DataGridViewHeaderNotFoundException
        /// </exception>
        /// <exception cref="DataGridView.Exceptions.DataGridViewRowNotFoundException">
        /// DataGridView.Exceptions.DataGridViewRowNotFoundException
        /// </exception>
        /// <history>
        /// [mbickle] 15AUG05 Created
        /// [mbickle] 24MAR06 Fixed the Vertical/Horizontal Scrolling to really make Cell visible.
        ///                   Getting ColumnHeaders and Rows collection only once to speed things up.
        /// </history>
        /// <remarks>
        /// Maui's AA.MakeVisible wasn't working reliably.  So implemented this.  
        /// </remarks>
        [Obsolete("This overload uses internal grid structures and is bad practice, use MakeCellVisible instead")]
        public void MakeVisible(
            ActiveAccessibility gridControlCellObject, 
            ActiveAccessibility gridControlColumnObject)
        {
            ActiveAccessibility gridControlTableObject = gridControlCellObject.Parent.Parent;
            ActiveAccessibility gridControlChildAtIndex = null;

            int minLoop = 0;
            int maxLoop = 10;
            while (!CellVisible(gridControlCellObject) && minLoop <= maxLoop)
            {
                #region column not visible
                // If the parent (column) isn't visible, then we need to move either left or right.
                if (gridControlColumnObject.StateText.IndexOf(MsaaResources.Strings.Offscreen) != -1)
                {
                    Utilities.LogMessage("GridControl.MakeVisible:: Column: Column not Visible");
                    Boolean columnFound = false;
                    Boolean columnVisible = false;

                    // Get the ColumnHeaders once to speed things up.
                    DataGridViewHeaderCollection columnHeaders = this.ColumnHeaders;

                    // We need to figure out if it's left or right here. 
                    // Start from 2 to account for horizontal and vertical scroll bars.
                    for (Int32 i = columnHeaders.Count - 1; i > -1; i--)
                    {
                        gridControlChildAtIndex = columnHeaders[i].AccessibleObject;
                        if (gridControlChildAtIndex == null)
                        {
                            throw new DataGridView.Exceptions.DataGridViewHeaderNotFoundException("GridControl.MakeVisible:: Expected to find: " + i.ToString());
                        }

                        if (gridControlChildAtIndex.Name == gridControlColumnObject.Name)
                        {
                            Utilities.LogMessage("GridControl.MakeVisible:: Column: columnFound: true");
                            columnFound = true;
                        }

                        // Check if the column is visible.
                        if (gridControlChildAtIndex.StateText.IndexOf(MsaaResources.Strings.Offscreen) == -1)
                        {
                            Utilities.LogMessage("GridControl.MakeVisible:: Column: columnVisible: true");
                            columnVisible = true;
                        }
                        else
                        {
                            Utilities.LogMessage("GridControl.MakeVisible:: Column: columnVisible: false");
                            columnVisible = false;
                        }

                        ////ActiveAccessibility horizontalObject = new ActiveAccessibility(gridControlTableObject.FindChild(MsaaResources.Strings.HorizontalScrollBar, (int)MsaaRole.ScrollBar));

                        Maui.Core.WinControls.HorizontalScrollBar horizontalObject = this.HorizontalScroll;

                        if (horizontalObject == null)
                        {
                            throw (new Exception("GridControl.MakeVisible:: Column: can't find Horizontal"));
                        }

                        // If the column was not found yet and the column is visible 
                        // then it means that we need to move to the left.
                        if (!columnFound && columnVisible)
                        {
                            Utilities.LogMessage("GridControl.MakeVisible:: Column: Column not found, but column visible.");

                            int loopTimes = 0;
                            while (gridControlColumnObject.StateText.IndexOf(MsaaResources.Strings.Offscreen) != -1 && loopTimes <= 60)
                            {
                                Utilities.LogMessage("GridControl.MakeVisible:: Column: Offscreen != -1, PageLeft() : loopTimes: " + loopTimes.ToString());
                                horizontalObject.PageLeft();

                                ////ActiveAccessibility pageRightPushButtonObject =
                                ////    horizontalObject.FindChild(MsaaResources.Strings.PageLeftName, (int)MsaaRole.PushButton);
                                ////pageRightPushButtonObject.DoDefaultAction();

                                loopTimes++;
                            }

                            break;
                        }
                        else if (columnFound)
                        {
                            Utilities.LogMessage("GridControl.MakeVisible:: Column: Column Found - Making visible");

                            // We are forcing view back to left.
                            horizontalObject.PageLeft();

                            ////ActiveAccessibility pageRightPushButtonObject =
                            ////   horizontalObject.FindChild(MsaaResources.Strings.PageLeftName, (int)MsaaRole.PushButton);
                            ////pageRightPushButtonObject.DoDefaultAction();

                            int loopTimes = 0;
                            while (gridControlColumnObject.StateText.IndexOf(MsaaResources.Strings.Offscreen) != -1 && loopTimes <= 60)
                            {
                                Utilities.LogMessage("GridControl.MakeVisible:: Column: InvisibleStateText != -1, PageRight() : loopTimes: " + loopTimes.ToString());
                                horizontalObject.PageRight();

                                // ActiveAccessibility pageLeftPushButtonObject = 
                                //    horizontalObject.FindChild(this.PageRightName, (int)MsaaRole.PushButton);

                                // pageLeftPushButtonObject.DoDefaultAction();

                                loopTimes++;
                            }

                            break;
                        }
                    }
                }
            
                #endregion
                #region row not visibile
                // If we are still here and the column is visible 
                // this means that the row is not visible.
                else
                {
                    // Get the Row Collection once to speed things up.
                    DataGridViewRowCollection rows = this.Rows;

                    // We might be able to get stuck in an infinite loop here.
                    minLoop = 0;
                    maxLoop = 10;

                    while (!CellVisible(gridControlCellObject) && minLoop <= maxLoop)
                    {
                        Utilities.LogMessage("GridControl.MakeVisible:: Row: Row not visible.");
                        Boolean cellFound = false;
                        Boolean cellVisible = false;

                        Utilities.LogMessage("GridControl.MakeVisible:: Row: Rows Count: " + rows.Count.ToString());

                        for (Int32 i = rows.Count - 1; i > -1; i--)
                        {
                            gridControlChildAtIndex = rows[i].AccessibleObject;
                            if (gridControlChildAtIndex == null)
                            {
                                throw new DataGridView.Exceptions.DataGridViewRowNotFoundException("GridControl.MakeVisible:: Expected to find: " + i.ToString());
                            }

                            if (gridControlChildAtIndex.Name == gridControlCellObject.Parent.Name)
                            {
                                Utilities.LogMessage("GridControl.MakeVisible:: Row: cellFound: True");
                                cellFound = true;
                            }

                            // Check if the column is visible.
                            if (gridControlChildAtIndex.StateText.IndexOf(MsaaResources.Strings.Offscreen) == -1)
                            {
                                Utilities.LogMessage("GridControl.MakeVisible:: Row: cellVisible: true");
                                cellVisible = true;
                            }
                            else
                            {
                                Utilities.LogMessage("GridControl.MakeVisible:: Row: cellVisible: false");
                                cellVisible = false;
                            }

                            ////ActiveAccessibility verticalObject = 
                            ////   gridControlTableObject.FindChild(MsaaResources.Strings.VerticalScrollBar, (int)MsaaRole.ScrollBar);

                            Maui.Core.WinControls.VerticalScrollBar verticalObject = this.VerticalScroll;

                            if (verticalObject == null)
                            {
                                throw (new Exception("GridControl.MakeVisible:: Row: Expected to find a vertical scroll bar."));
                            }

                            // If the cell was not found yet and the cell is visible 
                            // then it means that we need to move up.
                            if (!cellFound && cellVisible)
                            {
                                Utilities.LogMessage("GridControl.MakeVisible:: Row: Cell not found, but cell visible.");

                                int loopTimes = 0;
                                while (gridControlCellObject.StateText.IndexOf(MsaaResources.Strings.Offscreen) != -1 && loopTimes <= 60)
                                {
                                    Utilities.LogMessage("GridControl.MakeVisible:: Row: Offscreen != -1, PageUp() : loopTimes: " + loopTimes.ToString());

                                    try
                                    {
                                        verticalObject.SendKeys(KeyboardCodes.PageUp);
                                    }
                                    catch (Window.Exceptions.CannotSetFocusException)
                                    {
                                        Utilities.LogMessage("GridControl.MakeVisible:: CannotSetFocusException, when sending pageup.  We'll just catch it and try again.");
                                    }

                                    ////ActiveAccessibility pageDownPushButtonObject =
                                    ////    verticalObject.FindChild(MsaaResources.Strings.PageUpName, (int)MsaaRole.PushButton);
                                    ////pageDownPushButtonObject.DoDefaultAction();

                                    loopTimes++;
                                }

                                break;
                            }
                            else if (cellFound)
                            {
                                Utilities.LogMessage("GridControl.MakeVisible:: Row: Cell Found - Making visible");

                                // Lets push back to the Top
                                // verticalObject.PageUp();

                                // ActiveAccessibility pageDownPushButtonObject = 
                                //     verticalObject.FindChild(PageUpName, (int)MsaaRole.PushButton);
                                // pageDownPushButtonObject.DoDefaultAction();

                                verticalObject = this.VerticalScroll;

                                int loopTimes = 0;
                                while (gridControlCellObject.StateText.IndexOf(MsaaResources.Strings.Offscreen) != -1 && loopTimes <= 60)
                                {
                                    Utilities.LogMessage("GridControl.MakeVisible:: Row: Offscreen != -1, PageDown() : loopTimes: " + loopTimes.ToString());
                                    try
                                    {
                                        verticalObject.SendKeys(KeyboardCodes.PageDown);
                                    }
                                    catch (Window.Exceptions.CannotSetFocusException)
                                    {
                                        Utilities.LogMessage("GridControl.MakeVisible:: CannotSetFocusException, when sending pagedown.  We'll just catch it and try again.");
                                    }

                                    loopTimes++;
                                }

                                break;
                            }
                        }

                        minLoop++; // Increment Counter to prevent endless loop
                    }
                }
                #endregion

                minLoop++; // Increment Counter to prevent endless loop
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Method to expand all rows in a grid
        /// </summary>
        /// <param name="previousRowCount">Number of rows previously in the grid</param>
        [Obsolete("Control No Longer Exists.")]
        private void ExpandAllRows(int previousRowCount)
        {
            Core.Common.Utilities.LogMessage("GridControl::ExpandAllRows::Checking for collapsed child rows...");

            // if the current row count does not match the initial row count
            if (this.Rows.Count != previousRowCount && this.Rows.Count > 0)
            {
                Core.Common.Utilities.LogMessage("GridControl::ExpandAllRows::One or more child rows may have collapsed!");

                Core.Common.Utilities.LogMessage("GridControl::ExpandAllRows::Getting the context menu for the grid...");

                // get the context menu for the grid
                Menu contextMenu = new Menu(ContextMenuAccessMethod.ShiftF10);
                //contextMenu.WaitContextMenuWithTimeOut(15000);
                contextMenu.ScreenElement.WaitForReady();

                Core.Common.Utilities.LogMessage("GridControl::ExpandAllRows::Creating menu item for 'Expand All'...");

                // try to find the "Expand All" context menu item
                MenuItem expandAll = null;
                try
                {
                    expandAll =
                        new MenuItem(
                            contextMenu,
                            Core.Console.Views.HealthConfiguration.HealthConfigurationView.Strings.ContextMenuExpandAll);
                }
                catch (MenuItem.Exceptions.MenuItemNotFoundException)
                {
                    Core.Common.Utilities.LogMessage("GridControl::ExpandAllRows::Menu item not found, may not be implemented in this grid.");
                }

                Core.Common.Utilities.LogMessage("GridControl::ExpandAllRows::Checking for the 'Expand All' context menu item...");
                Core.Common.Utilities.LogMessage("GridControl::ExpandAllRows::Variable expandAll := " + (null != expandAll ? "MenuItem" : "NULL"));
                Core.Common.Utilities.LogMessage("GridControl::ExpandAllRows::Index of 'Expand All' := " + contextMenu.MenuItems.IndexOf(expandAll));

                // check for the existence of the "Expand All" menu item
                if (null != expandAll && contextMenu.MenuItems.IndexOf(expandAll) > -1)
                {
                    Core.Common.Utilities.LogMessage("GridControl::ExpandAllRows::Expanding all rows...");

                    // execute the menu item
                    contextMenu.ExecuteMenuItem(Core.Console.Views.HealthConfiguration.HealthConfigurationView.Strings.ContextMenuExpandAll);
                }
                else
                {
                    Core.Common.Utilities.LogMessage("GridControl::ExpandAllRows::Clearing the context menu...");

                    // the menu item was not found, clear the context menu
                    this.SendKeys(Core.Common.KeyboardCodes.Esc);
                }
            }
        }

        #region Wait For UI Object Ready Methods

        /// <summary>
        /// Method to wait for the row count to become non-zero.  The default
        /// wait time is five seconds.
        /// </summary>
        
        private void WaitForRowCount()
        {
            // wait for five seconds
            this.WaitForRowCount(5000);
        }

        /// <summary>
        /// Method to wait for the row count to become non-zero.  The maximum
        /// wait time is passed as a parameter measured in milliseconds,
        /// i.e. 1 second = 1000 milliseconds.
        /// </summary>
        /// <param name="maxWaitTime">Max wait time in milliseconds</param>
        
        private void WaitForRowCount(int maxWaitTime)
        {
            // check for invalid max wait time
            if (maxWaitTime <= 0)
            {
                // set to default value
                maxWaitTime = 5000;
            }

            Core.Common.Utilities.LogMessage("GridControl::WaitForRowCount::Waiting up to " + (maxWaitTime / 1000) + " seconds for row count");
            
            // initialize the current wait time
            int waitTime = 0;
            while (this.Rows.Count <= 0 && waitTime < maxWaitTime)
            {
                // increment the wait time
                waitTime += 1000;

                // sleep for one second
                Sleeper.Delay(1000);
            }

            Core.Common.Utilities.LogMessage("GridControl::WaitForRowCount::Waited " + (waitTime / 1000) + " seconds for row count");
        }

        #endregion // Wait For UI Object Ready Methods

        #endregion // Private Methods

        #region Control ID's

        /// ------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[mbickle] 26JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for View Grid
            /// </summary>
            public const string ViewPaneGrid = "momGrid";

            /// <summary>
            /// Control ID for Details Pane Grid
            /// </summary>
            public const string DetailPaneGrid = "gridControl";

            /// <summary>
            /// Control ID for Formula Grids (Query Builder)
            /// </summary>
            public const string FormulaGrid = "formulaGrid";
        }
        #endregion
    }
}
