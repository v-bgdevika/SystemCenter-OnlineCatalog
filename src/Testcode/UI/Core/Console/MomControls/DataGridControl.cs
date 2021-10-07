// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DataGridControl.cs">
//  Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//  OM10
// </project>
// <summary>
//  DataGridExtended Wrapper class.
// </summary>
// <history>
//  [a-joelj]   15MAR10 Created
// </history>
// ---------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MomControls
{
    #region Using Directives
    using System;
    using Maui.Core;
    using Maui.Core.WinControls;
    using System.Collections.Generic;
    using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
    using Mom.Test.UI.Core.Common;
    using System.Linq;
    using System.Reflection;
    using Maui.Core.Utilities;
    #endregion

    #region Interface Definition
    /// ------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDataGridControlControls.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///     [a-joelj]   15MAR10 Created
    /// </history>
    /// ------------------------------------------------------------------
    public interface IDataGridControlControls
    {
        /// <summary>
        /// DataGridHeader Columns
        /// </summary>
        DataGridHeaderCollection Columns
        {
            get;
        }

        /// <summary>
        /// DataGridRow VisibleRows
        /// </summary>
        DataGridRowCollectionExtended VisibleRows
        {
            get;
        }
    }
    #endregion

    /// ------------------------------------------------------------------
    /// <summary>
    /// Data Grid Control Class for accessing the WPF Data Grid.
    /// </summary>
    /// <history>
    ///     [a-joelj]   15MAR10 Created
    ///     [a-joelj]   16MAR10 Made this a wrapper class around the
    ///                         DataGridExtended class.
    /// </history>
    /// ------------------------------------------------------------------
    public class DataGridControl : DataGridExtended, IDataGridControlControls
    {


        #region Private Members
        /// <summary>
        /// Active Acessibilty GridControl Object
        /// </summary>
        private ActiveAccessibility dataGridControlObject;

        /// <summary>
        /// Cached reference to Horizontal Bar
        /// </summary>
        //private Maui.Core.WinControls.HorizontalScrollBar cachedHorizontalScroll;

        /// <summary>
        /// Cached Reference to Vertical Bar
        /// </summary>
        //private Maui.Core.WinControls.VerticalScrollBar cachedVerticalScroll;


        #endregion

        #region Constructors
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Creates Instance of DataGridExtended control.
        /// </summary>
        /// <param name="queryId">Query ID</param>
        /// <param name="startWindow">Starting Window</param>
        /// <history>
        ///     [a-joelj]   15MAR10 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DataGridControl(Window startWindow, QID queryId)
            : base(startWindow, queryId)
        {
            this.dataGridControlObject = this.AccessibleObject;
            RefreshColumnHeaders();
        }

        private List<string> columnHeaders = new List<string>();

        private List<string> columnSLHeaders = new List<string>();

        private Dictionary<string, ActiveAccessibility> dictColumnHeaders = new Dictionary<string, ActiveAccessibility>();

        /// <summary>
        /// Get column headers via walk through all the UI elements under the DataGrid control, and filter the ones whose role text is "column header"
        /// </summary>
        /// <param name="activeAcc">ActiveAccessibility which represent the DataGrid control itself</param>
        private void GetColumnHeaders(ActiveAccessibility activeAcc)
        {
            if (activeAcc.Role == (int)ActiveAccessibilityRole.ColumnHeader)
            {
                if (!string.IsNullOrEmpty(activeAcc.Name) && !this.columnHeaders.Contains(activeAcc.Name))
                {
                    Common.Utilities.LogMessage("column header Name " + activeAcc.Name);

                    this.columnHeaders.Add(activeAcc.Name);

                    this.dictColumnHeaders.Add(activeAcc.Name, activeAcc);
                }
            }

            foreach (ActiveAccessibility child in activeAcc.Children)
            {
                GetColumnHeaders(child);
            }
        }

        private void GetSLColumnHeaders()
        {
            Utilities.LogMessage("Get column headers in WebConsole");
            IScreenElement parentElement = this.ScreenElement.FindByPartialQueryId(";[UIA, VisibleOnly]AutomationId = 'ColumnHeadersPresenter'", null);
            MauiCollection<IScreenElement> columnHeaders = parentElement.FindAllDescendants(3, ";[FindAll, UIA, VisibleOnly]AutomationId = 'SCOMDataGridCellContentControl'", null);

            Utilities.LogMessage("columnHeaders.count " + columnHeaders.Count);

            for (int i = 0; i < columnHeaders.Count; i++)
            {
                if (!String.IsNullOrEmpty(columnHeaders[i].Name))
                {
                    Utilities.LogMessage("columnHeaders[i].Name " + columnHeaders[i].Name);
                    this.columnSLHeaders.Add(columnHeaders[i].Name);
                }
            }
        }

        /// <summary>
        /// Clear all the cache related with column headers and find the column headers from current UI again
        /// </summary>
        public void RefreshColumnHeaders()
        {
            this.columnHeaders.Clear();
            this.dictColumnHeaders.Clear();
            this.columnSLHeaders.Clear();
            DateTime startTime = DateTime.Now;
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    GetColumnHeaders(this.AccessibleObject);
                    break;
                case ProductSkuLevel.Web:
                    GetSLColumnHeaders();
                    break;
                default:
                    break;
            }
            Utilities.LogMessage("Get column headers spent " + (DateTime.Now - startTime).TotalSeconds + " seconds");
        }

        /// <summary>
        /// Read-only property to access private field column headers
        /// </summary>
        public List<string> ColumnHeaders
        {
            get
            {
                if (ProductSku.Sku == ProductSkuLevel.Web)
                    return this.columnSLHeaders;

                return this.columnHeaders;
            }
        }

        /// <summary>
        /// Read-only property to access private field column headers
        /// </summary>
        public List<string> SLColumnHeaders
        {
            get
            {
                return this.columnSLHeaders;
            }
        }

        /// <summary>
        /// Gets the column index of the column given the column header name
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <returns>int</returns>
        public int GetColumnIndex(string columnName)
        {
            if (ProductSku.Sku == ProductSkuLevel.Mom)
            {
                for (int i = 0; i < this.ColumnHeaders.Count; i++)
                {
                    if (this.ColumnHeaders[i] == columnName)
                        return i;
                }
            }
            else
            {
                for (int i = 0; i < this.columnSLHeaders.Count; i++)
                {
                    if (this.SLColumnHeaders[i] == columnName)
                        return i;
                }
            }
            throw new DataGrid.Exceptions.DataGridHeaderNotFoundException(columnName);
        }

        /// <summary>
        /// Click column headers by specified column header index
        /// </summary>
        /// <param name="index">column header index</param>
        public void ClickColumnHeader(int index)
        {
            this.dictColumnHeaders[this.columnHeaders[index]].Click();
        }
        #endregion
        private DataGridRowExtended root = null;

        public DataGridRowExtended[] DataGridRowExtendedCollection
        {
            get
            {
                List<DataGridRowExtended> rowExtended = new List<DataGridRowExtended>();
                foreach (var dataGridRowExtended in new DataGridRowCollectionExtended(this))
                {
                    rowExtended.Add(dataGridRowExtended);
                }
                return rowExtended.ToArray<DataGridRowExtended>();
            }
        }

        public DataGridRowExtended LayeredDataGridRowExtended
        {
            get
            {
                if (root == null)
                {
                    root = new DataGridRowExtended(this.ScreenElement);
                    // Construct the tree
                    string[] groups = GetGroupNames(this.FirstLevelGroups);
                    DataGridRowExtended datagrid = new DataGridRowExtended(base.ScreenElement);
                    DataGridRowExtended currentRow = datagrid;

                    int startIndex = 0;
                    int nextStartIndex = 0;
                    DataGridRowExtended[] sub = null;

                    int offset = 1;
                    if (ProductSku.Sku == ProductSkuLevel.Web)
                        offset = 0;

                    while (startIndex < this.DataGridRowExtendedCollection.Length - offset)
                    {
                        sub = GetDepthFirstTraversal(this.DataGridRowExtendedCollection, groups[0], startIndex, out nextStartIndex);
                        startIndex = nextStartIndex;

                        AddDepthFirstChildren(root, sub, groups);
                    }
                }
                return root;
            }
        }

        public void AddDepthFirstChildren(DataGridRowExtended parent, DataGridRowExtended[] rows, string[] groups)
        {
            DataGridRowExtended currentRowExtended = parent;
            Dictionary<string, List<DataGridRowExtended>> dict = new Dictionary<string, List<DataGridRowExtended>>();

            foreach (DataGridRowExtended row in rows)
            {
                Utilities.LogMessage("AddDepthFirstChildren:: row name" + row.NameExtended);
                if (string.IsNullOrEmpty(row.NameExtended))
                {
                    currentRowExtended.Children.Add(row);
                }
                else
                {
                    if (row.NameExtended.Split(':')[0] != groups[0])
                    {
                        string parentGroupName = groups[IndexOf(groups, row.NameExtended.Split(':')[0]) - 1];
                        currentRowExtended = dict[parentGroupName][dict[parentGroupName].Count - 1];
                    }
                    currentRowExtended.Children.Add(row);
                    if (!dict.ContainsKey(row.NameExtended.Split(':')[0]))
                    {
                        dict[row.NameExtended.Split(':')[0]] = new List<DataGridRowExtended>();
                        dict[row.NameExtended.Split(':')[0]].Add(row);
                    }
                    currentRowExtended = row;
                }
            }
        }

        public int IndexOf(string[] array, string name)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (string.Equals(array[i], name))
                {
                    return i;
                }
            }
            throw new Exception();
        }

        public DataGridRowExtended[] GetDepthFirstTraversal(DataGridRowExtended[] rows, string groupName, int startIndex, out int nextStartIndex)
        {
            int groupIndex = GetGroupIndex(rows, groupName, startIndex);
            int nextGroupIndex = GetGroupIndex(rows, groupName, groupIndex + 1);

            nextStartIndex = nextGroupIndex;

            DataGridRowExtended[] subRows = new DataGridRowExtended[nextGroupIndex - groupIndex];

            for (int i = groupIndex; i < nextGroupIndex; i++)
            {
                subRows[i - groupIndex] = rows[i];
            }

            return subRows;
        }

        public int GetGroupIndex(DataGridRowExtended[] rows, string groupName, int startIndex)
        {

            for (int i = startIndex; i < rows.Length; i++)
            {
                if (string.Equals(rows[i].NameExtended.Split(':')[0], groupName))
                {
                    return i;
                }
            }

            return rows.Length;
        }

        public string[] GetGroupNames(DataGroupGroups groups)
        {
            List<string> groupNames = new List<string>();
            foreach (var group in groups)
            {
                string name = group.NameExtended.Split(':')[0];
                Utilities.LogMessage(">>>> " + group.NameExtended.Split(':')[0]);
                if (!groupNames.Contains(name))
                {
                    groupNames.Add(name);
                }
            }
            return groupNames.ToArray();
        }

        /// <summary>
        /// Method to wait for data grid rows loading
        /// </summary>
        /// <history>
        /// [v-bire]  24JUN2011 Created
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
                    Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);
                    if (this.RowsExtended.Count > 0)
                    {
                        return;
                    }
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Utilities.LogMessage("WaitForStateViewLoading:: Grid view is not ready ");
                }

                sleeper.Sleep();
            }
        }

        /// <summary>
        /// This method selects a row in Group of the data grid which is one level grouped
        /// </summary>
        /// <param name="GroupHeaderName">Group Header Name</param>
        /// <param name="rowId">index of the row in the Group to be selected</param>
        public void SelectRowInGroup(string GroupHeaderName, int rowIndex)
        {
            Utilities.LogMessage("SelectRowInGroup::...");
            if (!this.HasGroups)
            {
                Utilities.LogMessage("SelectRowInGroup:: Data grid view don't have Group");
                throw new Exception("SelectRowInGroup:: Data grid view don't have Group");
            }
            if (this.FirstLevelGroups[0].HasGroups)
            {
                Utilities.LogMessage("SelectRowInGroup:: Data grid view have more than one level group");
                throw new Exception("SelectRowInGroup:: Data grid view have more than one level group");
            }
            //Get Data Grid Group            
            DataGridGroup group = this.FirstLevelGroups.Item(GroupHeaderName);
            if (group != null)
            {
                //Expand Group
                group.Expand();
                Maui.Core.Utilities.Sleeper.Delay(3000);

                if (rowIndex <= group.Rows().Count)
                {
                    Utilities.LogMessage("SelectRowInGroup:: clicking the row");
                    DataGridRowExtended row = group.Rows()[rowIndex];
                    row.CellsExtended[1].Select();
                }
                else
                {
                    throw new Exception("SelectRowInGroup:: RowIndex is out of Range ");
                }
            }
            else
            {
                throw new Exception("SelectRowInGroup:: Can't found the group name " + GroupHeaderName + " in data grid");
            }
        }

        #region IDataGridControlControls Members

        /// ------------------------------------------------------------------
        /// <summary>
        /// Column Headers
        /// </summary>
        /// <history>
        ///     [a-joelj]   15MAR10 Created
        /// </history>
        /// ------------------------------------------------------------------
        DataGridHeaderCollection IDataGridControlControls.Columns
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Visible Rows
        /// </summary>
        /// <history>
        ///     [a-joelj]   15MAR10 Created
        /// </history>
        /// ------------------------------------------------------------------
        DataGridRowCollectionExtended IDataGridControlControls.VisibleRows
        {
            get
            {
                return this.RowsExtended;
            }
        }
        #endregion

        #region Public Properties
        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes the controls
        /// </summary>
        /// <history>
        ///     [a-joelj]   17MAR10 Created
        /// </history>
        /// ------------------------------------------------------------------
        public IDataGridControlControls Controls
        {
            get
            {
                return this;
            }
        }

        ///// <summary>
        ///// v-vijia: not test the generic pane yet, it maybe not wrok.
        ///// Sunita mentioned that she had an implementation of the GenericView class, 
        ///// if it can work on the datagrid, will use her code, if not, v-vijia will contiue to work on the generic pane
        ///// </summary>
        //public GenericPane GenericInlinePane
        //{
        //    get
        //    {
        //        return new GenericPane(this, new QID(";[UIA]AutomationId='" + AutomationIDs.DataGridRowDetailsContentControl + "'"), ConsoleConstants.DefaultControlTimeout);
        //    }
        //}


        #endregion


        /// ------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all Automation IDs
        /// </summary>
        /// <history>
        ///     [a-joelj]   15MAR10 Created
        /// </history>
        /// ------------------------------------------------------------------'
        public class AutomationIDs
        {
            /// <summary>
            /// AutomationId for the entire Data Grid
            /// </summary>
            public const string SCOMDataGrid = "SCOMDataGrid";

            /// <summary>
            /// AutomationId for the Silverlight Data Grid
            /// </summary>
            /// <remarks>
            /// TODO: This should be removed when they both have the same AutomationId
            /// </remarks>
            public const string SilverlightDataGrid = "silverlightDataGrid";

            /// <summary>
            /// AutomationId for the InnerDataGrid
            /// </summary>
            /// <remarks> 
            /// This probably doesn't ever need to be used
            /// </remarks>
            public const string InnerDataGrid = "InnerDataGrid";

            /// <summary>
            /// AutomationId for the Column Headers part of the Data Grid
            /// </summary>
            public const string ColumnHeadersPresenter = "PART_ColumnHeadersPresenter";

            /// <summary>
            /// AutomationId for the Rows part of the Data Grid
            /// </summary>
            public const string RowsPresenter = "PART_RowsPresenter";

            /// <summary>
            /// AutomationId for the Vertical Scrollbar of the Data Grid
            /// </summary>
            public const string VerticalScrollbar = "PART_VerticalScrollBar";

            /// <summary>
            /// AutomationId for the Horizontal Scrollbar of the Data Grid
            /// </summary>
            public const string HorizontalScrollbar = "PART_HorizontalScrollBar";

            /// <summary>
            /// AutomationId for the ContentControl in a cell
            /// </summary>
            public const string DataGridCellContentControl = "SCOMDataGridCellContentControl";

            /// <summary>
            /// AutomationId for the ContentControl in a Header
            /// </summary>
            public const string DataGridColumnHeaderContentControl = "SCOMDataGridColumnHeaderContentControl";

            /// <summary>
            /// AutomationId for the Generic Pane
            /// </summary>
            public const string DataGridRowDetailsContentControl = "SCOMDataGridRowDetailsContentControl";
        }
    }

    #region Data Grid Maui Extended Classes

    /// ------------------------------------------------------------------
    /// <summary>
    /// DataGridExtended Class Definition
    /// </summary>
    /// <history>
    ///     [a-joelj]   15MAR10 Created
    /// </history>
    /// ------------------------------------------------------------------
    public class DataGridExtended : Maui.Core.WinControls.DataGrid
    {
        #region Private Properties

        private const string WpfDataGridGroupRowClass = "DataGridRow";
        private const string WebDataGridGroupRowClass = "DataGridRowGroupHeader";
        private const string GroupRole = "grouping";

        #endregion

        #region Constructor

        DataGridRowCollectionExtended dataGridRow;
        /// <summary>
        /// Constructor
        /// Data Grid Extended
        /// </summary>
        /// <param name="knownWindow">Window</param>
        /// <param name="queryId">QID</param>
        public DataGridExtended(Window knownWindow, QID queryId)
            : base(knownWindow, queryId)
        {
            RefreshColumnHeaders();
        }

        private List<string> columnHeaders = new List<string>();

        private Dictionary<string, ActiveAccessibility> dictColumnHeaders = new Dictionary<string, ActiveAccessibility>();

        /// <summary>
        /// Get column headers via walk through all the UI elements under the DataGrid control, and filter the ones whose role text is "column header"
        /// </summary>
        /// <param name="activeAcc">ActiveAccessibility which represent the DataGrid control itself</param>
        private void GetColumnHeaders(ActiveAccessibility activeAcc)
        {
            if (activeAcc == null)
            {
                return;
            }

            if (activeAcc.Role == (int)ActiveAccessibilityRole.ColumnHeader)
            {

                if (!string.IsNullOrEmpty(activeAcc.Name) && !this.columnHeaders.Contains(activeAcc.Name))
                {
                    Common.Utilities.LogMessage("column header Name " + activeAcc.Name);

                    this.columnHeaders.Add(activeAcc.Name);

                    this.dictColumnHeaders.Add(activeAcc.Name, activeAcc);
                }
            }

            foreach (ActiveAccessibility child in activeAcc.Children)
            {
                GetColumnHeaders(child);
            }
        }

        private void GetColumnHeaders()
        {
            Utilities.LogMessage("Get column headers in WebConsole");
            IScreenElement parentElement = this.ScreenElement.FindByPartialQueryId(";[UIA, VisibleOnly]AutomationId = 'ColumnHeadersPresenter'", null);
            MauiCollection<IScreenElement> columnHeaders = parentElement.FindAllDescendants(3, ";[FindAll, UIA, VisibleOnly]AutomationId = 'SCOMDataGridCellContentControl'", null);

            Utilities.LogMessage("columnHeaders.count " + columnHeaders.Count);

            for (int i = 0; i < columnHeaders.Count; i++)
            {
                if (!String.IsNullOrEmpty(columnHeaders[i].Name))
                {
                    Utilities.LogMessage("columnHeaders[i+1].Name " + columnHeaders[i].Name);
                    this.columnHeaders.Add(columnHeaders[i].Name);
                }
            }
        }

        /// <summary>
        /// Clear all the cache related with column headers and find the column headers from current UI again
        /// </summary>
        public void RefreshColumnHeaders()
        {
            this.columnHeaders.Clear();
            this.dictColumnHeaders.Clear();
            DateTime startTime = DateTime.Now;

            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    GetColumnHeaders(this.AccessibleObject);
                    break;
                case ProductSkuLevel.Web:
                    GetColumnHeaders();
                    break;
            }

            Utilities.LogMessage("Get column headers spent " + (DateTime.Now - startTime).TotalSeconds + " seconds");
        }

        /// <summary>
        /// Read-only property to access private field column headers
        /// </summary>
        public List<string> ColumnHeaders
        {
            get
            {
                return this.columnHeaders;
            }
        }

        /// <summary>
        /// Gets the column index of the column given the column header name
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <returns>int</returns>
        public int GetColumnIndex(string columnName)
        {
            for (int i = 0; i < this.ColumnHeaders.Count; i++)
            {
                if (this.ColumnHeaders[i] == columnName)
                    return i;
            }

            throw new DataGrid.Exceptions.DataGridHeaderNotFoundException(columnName);
        }

        /// <summary>
        /// Click column headers by specified column header index
        /// </summary>
        /// <param name="index">column header index</param>
        public void ClickColumnHeader(int index)
        {
            this.dictColumnHeaders[this.columnHeaders[index]].Click();
        }

        #endregion Constructor

        #region Public Properties

        /// <summary>
        /// Data Grid Row Collection Extended Property
        /// </summary>
        public DataGridRowCollectionExtended RowsExtended
        {
            get
            {
                //if(dataGridRow == null)
                //   dataGridRow =  new DataGridRowCollectionExtended(this);
                //return dataGridRow;
                //If data grid has groups, cannot get data item directly, should get group fist.
                if (!HasGroups)
                {
                    return new DataGridRowCollectionExtended(this);
                }
                else
                {
                    return null;
                }

            }
        }

        /// <summary>
        /// Groups of next level
        /// </summary>
        public DataGroupGroups FirstLevelGroups
        {
            get
            {
                if (HasGroups)
                {
                    DataGroupGroups readOnlyFirstLevelGroups = new DataGroupGroups(this);
                    return readOnlyFirstLevelGroups;
                }
                else
                {
                    return null;
                }
            }
        }

        public Dictionary<int, List<DataGridGroup>> Groups
        {
            get
            {
                Dictionary<int, List<DataGridGroup>> AllGroups = new Dictionary<int, List<DataGridGroup>>();
                List<DataGridGroup> childGroups = new List<DataGridGroup>();
                if (this.FirstLevelGroups != null)
                {
                    int i = 0;
                    foreach (var group in this.FirstLevelGroups)
                    {
                        if (group.HasGroups)
                        {
                            childGroups.Add(group);
                        }
                        else
                        {
                            childGroups.Add(group);
                            AllGroups.Add(i, childGroups);
                            i++;
                        }
                    }
                    return AllGroups;
                }
                else
                {
                    return null;
                }

            }
        }

        /// <summary>
        /// if there is gourp of next level
        /// </summary>
        public bool HasGroups
        {
            get
            {
                //look for group rows of next level
                Maui.Core.MauiCollection<IScreenElement> rows = default(MauiCollection<IScreenElement>);
                switch (ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                        // Changed the filter from [FindAll, UIA, VisibleOnly] to [FindAll, UIA] as this filter was not giving all the list items to enumerator during State wizard creation.
                        // 'VisibleOnly' filter was hiding those elements which were hidden because of the window size.
                        rows = this.ScreenElement.FindAllDescendants(-1, ";[FindAll, UIA] Role = '" + GroupRole + "'", null);
                        break;
                    case ProductSkuLevel.Web:
                        rows = this.ScreenElement.FindAllDescendants(-1, ";[FindAll, UIA, VisibleOnly] ClassName='" + WebDataGridGroupRowClass + "' && Role = '" + GroupRole + "'", null);
                        break;
                    default:
                        break;
                }

                if (rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }





        /// <summary>
        /// GetSelectedRow
        /// </summary>
        /// <param name="ColumnName"></param>
        /// <returns>int</returns>
        public List<string> GetSelectedRowData(int rowId)
        {
            List<string> selectedRow = new List<string>();

            // if (dataRows[index].CellsExtended[columnIndex].NameExtended.ToString() == SearchString)
            DataGridRowCollectionExtended dataRows = this.RowsExtended;
            foreach (DataGridCellExtended cell in dataRows[rowId].CellsExtended)
            {
                selectedRow.Add(cell.NameExtended);
            }

            return selectedRow;
        }


        /// <summary>
        /// gets the rowindex of the row given the column name and Search string in the column
        /// </summary>
        /// <param name="Column"></param>
        /// <param name="SearchString"></param>
        /// <returns>int</returns>
        public int GetRowIndex(string Column, string SearchString)
        {
            // get the column index
            int columnIndex = GetColumnIndex(Column);
            int rowCount = this.RowsExtended.Count;
            DataGridRowCollectionExtended dataRows = this.RowsExtended;
            if (columnIndex != -1)
            {
                for (int index = 0; index < rowCount; index++)
                {
                    if (dataRows[index].CellsExtended[columnIndex].NameExtended.ToString() == SearchString)
                        return index;
                }
            }


            return -1;
        }

        /// <summary>
        /// gets the complete row data data given the column name and search text within the column
        /// </summary>
        /// <param name="Column"></param>
        /// <param name="SearchString"></param>
        /// <returns></returns>
        public DataGridRow GetRowFromColumn(string Column, string SearchString)
        {
            // get the column index
            int i = GetColumnIndex(Column);

            if (i != -1)
            {
                foreach (var val in this.RowsExtended)
                {
                    if (val.CellsExtended[i].ToString() == SearchString)
                        return val;
                }
            }


            return null;
        }

        public int GetRowIndex(Dictionary<string, string> Properties)
        {
            string currentMethodName = MethodBase.GetCurrentMethod().Name;

            // neviage it again to refresh the screen
            int GridRowCount = this.RowsExtended.Count;
            List<List<string>> actRowData = DataGridControlExtensions.GetRowData((DataGridControl)this);
            int columnIndex = -1;
            string filter = "";
            string columnName = "";
            int rtnIndex = -1;

            if (Properties.Keys.Count > 0)
            {
                if (GridRowCount != 0)
                {
                    Core.Common.Utilities.LogMessage(currentMethodName + ":: Refresh Column Headers");
                    this.RefreshColumnHeaders();
                    int columnOffset = this.RowsExtended[0].CellsExtended.Count - this.ColumnHeaders.Count;
                    Core.Common.Utilities.LogMessage(currentMethodName + ":: column offset is " + columnOffset);
                    for (int i = 0; i < actRowData.Count; i++)
                    {
                        bool found = true;
                        List<string> actualValues = actRowData[i];

                        foreach (var property in Properties.Keys)
                        {
                            columnName = property;
                            filter = Properties[property] == null ? "" : Properties[property];
                            columnIndex = this.GetColumnIndex(columnName) + columnOffset;
                            if (actualValues[columnIndex] != null && actualValues[columnIndex].ToLower() == filter.ToLower())//actualValues[columnIndex].IndexOf(filter,StringComparison.CurrentCultureIgnoreCase)!= -1)//Contains(filter))
                            {
                                //skip
                                rtnIndex = i;
                            }
                            else
                            {
                                found = false;
                                break;
                            }
                        }

                        if (found)
                            return rtnIndex;
                    }

                }
            }

            return -1;
        }


        public List<int> GetRowIndex(Dictionary<string, List<string>> Properties)
        {
            Utilities.LogMessage("GetRowIndex::...");
            List<int> RowIndex = new List<int>();
            // neviage it again to refresh the screen
            int GridRowCount = this.RowsExtended.Count;
            List<List<string>> actRowData = DataGridControlExtensions.GetRowData((DataGridControl)this);
            int columnIndex = -1;
            string filter = "";
            string columnName = "";
            int rtnIndex = -1;
            if (Properties.Keys.Count > 0)
            {
                if (GridRowCount != 0)
                {
                    Utilities.LogMessage("Properties[Properties.Keys.First()].Count is " + Properties[Properties.Keys.First()].Count);
                    for (int i = 0; i < Properties[Properties.Keys.First()].Count; i++)
                    {
                        bool Multifound = false;
                        int columnOffset = this.RowsExtended[0].CellsExtended.Count - this.ColumnHeaders.Count;
                        Core.Common.Utilities.LogMessage("GetRowIndex:: column offset is " + columnOffset);
                        for (int j = 0; j < actRowData.Count; j++)
                        {
                            bool found = true;
                            List<string> actualValues = actRowData[j];
                            foreach (var property in Properties.Keys)
                            {
                                columnName = property;
                                filter = Properties[property][i] == null ? "" : Properties[property][i];
                                Utilities.LogMessage("filter value is " + filter);
                                columnIndex = this.GetColumnIndex(columnName) + columnOffset;
                                Utilities.LogMessage("actualValues[columnIndex] value is " + actualValues[columnIndex]);
                                if (actualValues[columnIndex] != null && actualValues[columnIndex].ToLower() == filter.ToLower())//Contains(filter))
                                {
                                    //skip
                                    Utilities.LogMessage("Row index is " + j);
                                    rtnIndex = j;
                                }
                                else
                                {
                                    found = false;
                                    Utilities.LogMessage("GetRowIndex:: Not found, continue found next row");
                                    break;
                                }
                            }
                            if (found)
                            {
                                RowIndex.Add(rtnIndex);
                                Multifound = true;
                                break;
                            }
                        }
                        if (!Multifound)
                        {
                            RowIndex.Add(-1);
                        }
                    }
                }
            }

            return RowIndex;
        }

        #endregion Public Properties
    }



    public class DataGroupGroups : System.Collections.ObjectModel.ReadOnlyCollection<DataGridGroup>
    {
        private const string WpfDataGridGroupRowClass = "DataGridRow";
        private const string WebDataGridGroupRowClass = "DataGridRowGroupHeader";
        private const string GroupRole = "grouping";

        public DataGroupGroups(Window gridWindow)
            : base(new System.Collections.ObjectModel.Collection<DataGridGroup>())
        {
            Maui.Core.MauiCollection<IScreenElement> groupElements = default(MauiCollection<IScreenElement>);
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    groupElements = gridWindow.ScreenElement.FindAllDescendants(2, ";[FindAll, UIA] Role = '" + GroupRole + "'", null);
                    break;
                case ProductSkuLevel.Web:
                    groupElements = gridWindow.ScreenElement.FindAllDescendants(2, ";[FindAll, UIA, VisibleOnly] ClassName='" + WebDataGridGroupRowClass + "' && Role = '" + GroupRole + "'", null);
                    break;
                default:
                    break;
            }
            foreach (IScreenElement element in groupElements)
            {
                DataGridGroup group = new DataGridGroup(element);
                base.Items.Add(group);
            }

            //Example group:
            //ClassName:	"DataGridRow"
            //ControlType:	"ControlType.Group"
            //Culture:	"(null)"
            //AutomationId:	""
            //LocalizedControlType:	"group"
            //Name:	"Data Access Service - Windows Service"
        }

        public DataGridGroup Item(string name)
        {
            DataGridGroup result = null;
            foreach (DataGridGroup group in base.Items)
            {
                if (group.NameExtended == name)
                {
                    result = group;
                }
            }
            if (result == null)
            {
                throw new DataGrid.Exceptions.DataGridRowNotFoundException("Could not find group with name: " + name);
            }
            else
            {
                return result;
            }
        }
    }

    public class DataGridGroup : DataGridRowExtended
    {
        #region Constructor

        public DataGridGroup(IScreenElement screenElement)
            : base(screenElement)
        {
        }

        public DataGridGroup(ActiveAccessibility accessibleObject)
            : base(accessibleObject)
        {
        }

        #endregion

        #region Public Functions

        public void Expand()
        {
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    IScreenElement actualGroup = this.GetActualGroupFromRoot();
                    actualGroup.Expand();
                    break;
                case ProductSkuLevel.Web:
                    base.ScreenElement.Expand();
                    break;
                default:
                    break;
            }

            //delay 3 seconds to wait for operation done
            Maui.Core.Utilities.Sleeper.Delay(3000);
        }

        public void Collapse()
        {
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    IScreenElement actualGroup = this.GetActualGroupFromRoot();
                    actualGroup.Collapse();
                    break;
                case ProductSkuLevel.Web:
                    base.ScreenElement.Collapse();
                    break;
                default:
                    break;
            }

            //delay 3 seconds to wait for operation done
            Maui.Core.Utilities.Sleeper.Delay(3000);
        }

        public void Select()
        {
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    IScreenElement actualGroup = this.GetActualGroupFromRoot();
                    //using LeftButtonClick(x,y) rather than Select() because RPF is throwing following error:

                    //The most recent Playback failures were:

                    //[WARNING] Internal warning: Search failure: [FindAll, UIA, VisibleOnly] Role = 'grouping' | No elements that match the [FindAll] condition have been found
                    //{240} [FAILED] Function ElementFetcher::FindScreenElement failed to locate UI element (Searching: ;[FindAll, UIA, VisibleOnly] Role = 'grouping') The object specified was not found.
                    //[WARNING] Internal warning: Couldn't find descendants that match QueryId
                    //{241} [FAILED] Can't get parent for UI element
                    //{242} [FAILED] Select - "[FindAll, UIA, VisibleOnly] Role ='grouping'"  < Primitive "Select" did not set the state correctly > , See related internal warnings/failures for more information

                    //   at RecordPlaybackFramework.Utilities.ResultHandler.DefaultHRESULTHandler(Int32 hResult)
                    //   at RecordPlaybackFramework.Utilities.ResultHandler.HandleHRESULT(Int32 HRESULT)
                    //   at RecordPlaybackFramework.ScreenElement.Select()
                    //   at Maui.Core.RPFSupport.ScreenElementWrapper.Select() in d:\build\maui\suitesrc\maui\MAUI\Core\RPF\RPFSupport.vb:line 1522
                    //   at Mom.Test.UI.Core.Console.MomControls.DataGridGroup.Select() in d:\enlistments\om10\private\Testcode\UI\Core\Console\MomControls\DataGridControl.cs:line 835

                    System.Drawing.Point point = actualGroup.GetClickablePoint();
                    actualGroup.LeftButtonClick(point.X, point.Y);
                    break;
                case ProductSkuLevel.Web:
                    base.ScreenElement.Select();
                    break;
                default:
                    break;
            }

            //delay 3 seconds to wait for operation done
            Maui.Core.Utilities.Sleeper.Delay(3000);
        }

        public DataGridRowCollectionExtended Rows()
        {
            //If current group still has groups, cannot get data item directly, should get its sub group fist.
            if (!HasGroups)
            {
                DataGridRowCollectionExtended rows = new DataGridRowCollectionExtended(new Window(base.ScreenElement));
                return rows;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Public Properties


        /// <summary>
        /// Groups of next level
        /// </summary>
        public DataGroupGroups FirstLevelGroups
        {
            get
            {
                if (HasGroups)
                {
                    DataGroupGroups readOnlyFirstLevelGroups = new DataGroupGroups(new Window(base.ScreenElement));
                    return readOnlyFirstLevelGroups;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// if there is gourp of next level
        /// </summary>
        public bool HasGroups
        {
            get
            {
                //look for group rows of next level
                Maui.Core.MauiCollection<IScreenElement> rows = default(MauiCollection<IScreenElement>);
                switch (ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                        rows = this.ScreenElement.FindAllDescendants(-1, ";[FindAll, UIA] Role = '" + GroupRole + "'", null);
                        break;
                    case ProductSkuLevel.Web:
                        rows = this.ScreenElement.FindAllDescendants(-1, ";[FindAll, UIA, VisibleOnly] ClassName='" + WebDataGridGroupRowClass + "' && Role = '" + GroupRole + "'", null);
                        break;
                    default:
                        break;
                }

                if (rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        #endregion

        #region Private Properties

        private const string WpfDataGridGroupRowClass = "DataGridRow";
        private const string WebDataGridGroupRowClass = "DataGridRowGroupHeader";
        private const string GroupRole = "grouping";
        private const string WpfDataGridClassName = "InnerDataGrid";
        private const int DefaultMaxGroupLevel = 3;

        #endregion

        #region Private Functions

        /// <summary>
        /// Get the actual group from InnerDataGrid
        /// </summary>
        /// <returns></returns>
        private IScreenElement GetActualGroupFromRoot()
        {
            IScreenElement actualGroup = null;

            //Get the root
            //Assume that current group is at max level.
            int currentLevel = DefaultMaxGroupLevel;
            IScreenElement element = base.ScreenElement;
            while (element.ClassName != WpfDataGridClassName && currentLevel >= 0)
            {
                element = element.Parent;
                currentLevel--;
            }

            if (element.ClassName != WpfDataGridClassName)
            {
                Mom.Test.UI.Core.Common.Utilities.LogMessage("DataGridGroup:: InnerDataGrid cannot be found from current group.");
                return null;
            }

            //Get the actual group from the root
            MauiCollection<IScreenElement> elements = element.FindAllDescendants(2, ";[FindAll, UIA] Role ='" + GroupRole + "'", null);
            foreach (IScreenElement item in elements)
            {
                if (item.Name.Contains(base.ScreenElement.Name))
                {
                    actualGroup = item;
                    break;
                }
            }

            return actualGroup;
        }

        #endregion
    }

    /// ------------------------------------------------------------------
    /// <summary>
    /// DataGridRowExtended Class Definition
    /// </summary>
    /// <history>
    ///     [a-joelj]   15MAR10 Created
    /// </history>
    /// ------------------------------------------------------------------
    public class DataGridRowExtended : Maui.Core.WinControls.DataGridRow
    {
        #region Private Properties
        private IScreenElement m_se;
        private Window m_window;
        private const string LinkRoleText = "link";
        private const string RowHeaderRoleText = "row header";
        private const string WpfDataGridRowHeaderClassName = "DataGridRowHeader";
        private List<DataGridRowExtended> children = new List<DataGridRowExtended>();

        #endregion Private Properties

        #region Constructors
        /// <summary>
        /// Constructor
        /// Data Grid Row Extended
        /// </summary>
        /// <param name="accessibleObject"></param>
        public DataGridRowExtended(ActiveAccessibility accessibleObject)
            : base(accessibleObject)
        {
            new DataGridRowExtended(Maui.Core.RPFSupport.RPF.ScreenElementFromAccessibleObject(accessibleObject as Accessibility.IAccessible));
        }

        /// <summary>
        /// Constructor
        /// Data Grid Row Extended
        /// </summary>
        /// <param name="screenElement"></param>
        public DataGridRowExtended(IScreenElement screenElement)
            : base(screenElement)
        {
            new RemotingObject();
            m_se = screenElement;

            m_window = new Window(screenElement);
        }
        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// Row Name Extended Property
        /// </summary>
        public string NameExtended
        {
            get
            {
                switch (ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                        return this.ScreenElementExtended.Name;
                    case ProductSkuLevel.Web:
                        IScreenElement item = this.m_se.FindByPartialQueryId(-1, ";[UIA]AutomationId='RowHeader'", null);
                        if (item == null)
                            return string.Empty;
                        return item.Name;
                    default:
                        return this.ScreenElementExtended.Name;
                }
            }
        }

        /// <summary>
        /// Row Value Extended Property
        /// </summary>
        public string ValueExtended
        {
            get
            {
                return this.ScreenElementExtended.Value;
            }
        }

        /// <summary>
        /// Row Accessible Object Property
        /// </summary>
        public new ActiveAccessibility AccessibleObject
        {
            get
            {
                return new ActiveAccessibility(this.ScreenElementExtended.Accessible);
            }
        }

        /// <summary>
        /// Cell Collection Extended Property
        /// </summary>
        public DataGridCellCollectionExtended CellsExtended
        {
            get
            {
                return new DataGridCellCollectionExtended(this.ScreenElement);
            }
        }

        /// <summary>
        /// Screen Element Extended Property
        /// </summary>
        public IScreenElement ScreenElementExtended
        {
            get
            {
                return m_se;
            }
        }

        public List<DataGridRowExtended> Children
        {
            get
            {
                return this.children;
            }
        }

        public bool HasChildren
        {
            get
            {
                switch (ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                        return !string.IsNullOrEmpty(this.NameExtended);
                    case ProductSkuLevel.Web:
                        {
                            MauiCollection<IScreenElement> child = this.ScreenElement.FindAllDescendants(-1, ";[FindAll, UIA, VisibleOnly] ClassName='DataGridRowGroupHeader' && Role = 'grouping'", null);
                            if (child.Count > 0)
                                return true;
                            else
                                return false;
                        }
                    default:
                        return !string.IsNullOrEmpty(this.NameExtended);
                }
            }
        }

        #endregion Public Properties
    }


    /// ------------------------------------------------------------------
    /// <summary>
    /// DataGridRowCollectionExtended Class Definition
    /// </summary>
    /// <history>
    ///     [a-joelj]   15MAR10 Created
    /// </history>
    /// ------------------------------------------------------------------
    [Serializable]
    public class DataGridRowCollectionExtended : System.Collections.ObjectModel.ReadOnlyCollection<DataGridRowExtended>
    {
        #region Private Properties
        private const string RowRoleText = "row";
        private const string TopRowNameTextID = ";Top Row;ManagedString;System.Windows.Forms.dll;System.Windows.Forms;DataGridView_AccTopRow";
        private const string WpfDatGridRowClass = "DataGridRow";
        private const string WebDatGridRowClass = "SCOMDataGridCellContentControl";//"DataGridRowGroupHeader";
        private const string AddNewRowName = "{NewItemPlaceholder}";
        private const string DataGirdItemRowRole = "list item";
        #endregion Private Properties

        #region Constructor

        /// <summary>
        /// Constructor
        /// Data Grid Row Collection Extended
        /// </summary>
        /// <param name="parentWindow"></param>
        public DataGridRowCollectionExtended(Window parentWindow)
            : base(new System.Collections.ObjectModel.Collection<DataGridRowExtended>())
        {
            string topRowNameText = parentWindow.Extended.App.GetIntlStr(TopRowNameTextID);

            Maui.Core.MauiCollection<IScreenElement> rows = new MauiCollection<IScreenElement>(); //default(MauiCollection<IScreenElement>);

            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    // Changed the filter from [FindAll, UIA, VisibleOnly] to [FindAll, UIA] as this filter was not giving all the list items to enumerator during State wizard creation.
                    // 'VisibleOnly' filter was hiding those elements which were hidden because of the window size.
                    rows = parentWindow.ScreenElement.FindAllDescendants(3, ";[FindAll, UIA] ClassName = '" + WpfDatGridRowClass + "'", null);
                    break;
                case ProductSkuLevel.Web:
                    //IScreenElement parentElement = parentWindow.ScreenElement.FindByPartialQueryId(";[UIA, VisibleOnly]AutomationId = 'RowsPresenter'", null);
                    //rows = parentElement.FindAllDescendants(2, ";[FindAll, UIA, VisibleOnly]ClassName = '" + WpfDatGridRowClass + "'", null);

                    MauiCollection<IScreenElement> groups = parentWindow.ScreenElement.FindAllDescendants(-1, ";[FindAll, UIA, VisibleOnly] ClassName = 'DataGridRowGroupHeader' && Role = 'grouping'", null);
                    if (groups.Count == 0)
                    {
                        rows = parentWindow.ScreenElement.FindAllDescendants(2, ";[FindAll, UIA, VisibleOnly] ClassName = '" + WpfDatGridRowClass + "'", null);
                    }
                    else
                    {
                        foreach (var group in groups)
                        {
                            Utilities.LogMessage("Group ClassName:= " + group.ClassName);
                            rows.Add(group);
                            MauiCollection<IScreenElement> dataRows = group.FindAllDescendants(2, ";[FindAll, UIA, VisibleOnly] ClassName = '" + WpfDatGridRowClass + "'", null);
                            if (dataRows.Count > 0)
                            {
                                foreach (var dataRow in dataRows)
                                {
                                    Utilities.LogMessage("DataRow ClassName:= " + group.ClassName);
                                    rows.Add(dataRow);
                                }
                            }
                        }
                    }

                    break;
            }

            foreach (IScreenElement se in rows)
            {
                if (se.Name != topRowNameText && se.Name != AddNewRowName)
                {
                    Utilities.LogMessage("se.Name:= " + se.Name);
                    Items.Add(new DataGridRowExtended(se));
                }
            }
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Data Grid Row Extended Item
        /// </summary>
        /// <param name="name"></param>
        /// <returns>DataGridRowExtended</returns>
        public DataGridRowExtended Item(string name)
        {
            DataGridRowExtended result = null;
            foreach (DataGridRowExtended row in Items)
            {
                if (row.NameExtended == name)
                {
                    result = row;
                }
            }
            if (result == null)
            {
                throw new DataGrid.Exceptions.DataGridRowNotFoundException("Could not find row with name: " + name);
            }
            else
            {
                return result;
            }
        }

        #endregion Public Methods
    }

    /// ------------------------------------------------------------------
    /// <summary>
    /// DataGridCellExtended Class Definition
    /// </summary>
    /// <history>
    ///     [a-joelj]   15MAR10 Created
    /// </history>
    /// ------------------------------------------------------------------
    public class DataGridCellExtended : Maui.Core.WinControls.DataGridCell
    {
        #region Private Properties
        private IScreenElement m_se;
        private Window m_window;
        #endregion Private Properties

        #region Constructors

        /// <summary>
        /// Constructor
        /// Data Grid Cell Extended
        /// </summary>
        /// <param name="accessibleObject">ActiveAccessibility</param>
        public DataGridCellExtended(ActiveAccessibility accessibleObject)
            : base(accessibleObject)
        {
            new DataGridCellExtended(Maui.Core.RPFSupport.RPF.ScreenElementFromAccessibleObject(accessibleObject as Accessibility.IAccessible));
        }

        /// <summary>
        /// Constructor
        /// Data Grid Cell Extended
        /// </summary>
        /// <param name="screenElement">IScreenElement</param>
        public DataGridCellExtended(IScreenElement screenElement)
            : base(screenElement)
        {
            m_se = screenElement;
            m_window = new Window(screenElement);
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// Cell Name Extended Property
        /// </summary>
        public string NameExtended
        {
            get
            {
                return this.ScreenElementExtended.Name;
            }
        }

        /// <summary>
        /// Cell Value Extended Property
        /// </summary>
        public string ValueExtended
        {
            get
            {
                return this.ScreenElementExtended.Value;
            }
        }

        /// <summary>
        /// Cell Screen Element Extended Property
        /// </summary>
        public IScreenElement ScreenElementExtended
        {
            get
            {
                return m_se;
            }
        }

        #endregion Public Properties
    }

    /// ------------------------------------------------------------------
    /// <summary>
    /// DataGridCellCollectionExtended Class Definition
    /// </summary>
    /// <history>
    ///     [a-joelj]   15MAR10 Created
    /// </history>
    /// ------------------------------------------------------------------
    [Serializable]
    public class DataGridCellCollectionExtended : System.Collections.ObjectModel.ReadOnlyCollection<DataGridCellExtended>
    {
        #region Private Properties
        private const string CellRoleText = "cell";
        #endregion Private Properties

        #region Constructor

        /// <summary>
        /// Constructor
        /// Data Grid Cell Collection Extended
        /// </summary>
        /// <param name="parentSE">IScreenElement</param>
        public DataGridCellCollectionExtended(IScreenElement parentSE)
            : base(new System.Collections.ObjectModel.Collection<DataGridCellExtended>())
        {
            Maui.Core.MauiCollection<IScreenElement> cells = default(MauiCollection<IScreenElement>);
            Window parentWindow = new Window(parentSE);

            //if (parentWindow.IsWpfElement)
            //{
            // Changed the filter from [FindAll, UIA, VisibleOnly] to [FindAll, UIA] as this filter was not giving all the list items to enumerator during State wizard creation.
            // 'VisibleOnly' filter was hiding those elements which were hidden because of the window size.
            cells = parentWindow.ScreenElement.FindAllDescendants(-1, ";[FindAll, UIA] AutomationId = '" + DataGridControl.AutomationIDs.DataGridCellContentControl + "'", null);
            //}
            //else
            //{
            //    cells = parentWindow.ScreenElement.FindAllDescendants(-1, ";[FindAll, MSAA, VisibleOnly] Role = '" + CellRoleText + "'", null);
            //}

            foreach (IScreenElement screen in cells)
            {
                Items.Add(new DataGridCellExtended(screen));
            }
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Data Grid Cell Extended Item
        /// </summary>
        /// <param name="name"></param>
        /// <returns>DataGridCellExtended</returns>
        public DataGridCellExtended Item(string name)
        {
            DataGridCellExtended result = null;
            foreach (DataGridCellExtended cell in Items)
            {
                if (cell.NameExtended == name)
                {
                    result = cell;
                }
            }
            if (result == null)
            {
                throw new DataGrid.Exceptions.DataGridCellNotFoundException("Could not find cell with name: " + name);
            }
            else
            {
                return result;
            }
        }
        #endregion Public Methods
    }

    #endregion Data Grid Maui Extended Classes

    // get from oleacc.h, you could get more info like state value from that file
    public enum ActiveAccessibilityRole
    {
        TitleBar = 0x1,

        MenuBar = 0x2,

        ScrollBar = 0x3,

        Grip = 0x4,

        Sound = 0x5,

        Cursor = 0x6,

        Caret = 0x7,

        Alert = 0x8,

        Window = 0x9,

        Client = 0xa,

        MenuPopup = 0xb,

        MenuItem = 0xc,

        Tooltip = 0xd,

        Application = 0xe,

        Document = 0xf,

        Pane = 0x10,

        Chart = 0x11,

        Dialog = 0x12,

        Border = 0x13,

        Grouping = 0x14,

        Separator = 0x15,

        Toolbar = 0x16,

        StatusBar = 0x17,

        Table = 0x18,

        ColumnHeader = 0x19,

        RowHeader = 0x1a,

        Column = 0x1b,

        Row = 0x1c,

        Cell = 0x1d,

        Link = 0x1e,

        HelpBalloon = 0x1f,

        Character = 0x20,

        List = 0x21,

        ListItem = 0x22,

        Outline = 0x23,

        OutlineItem = 0x24,

        PageTab = 0x25,

        PropertyPage = 0x26,

        Indicator = 0x27,

        Graphic = 0x28,

        StaticText = 0x29,

        Text = 0x2a,

        PushButton = 0x2b,

        CheckButton = 0x2c,

        RadioButton = 0x2d,

        ComboBox = 0x2e,

        DropList = 0x2f,

        ProgressBar = 0x30,

        Dial = 0x31,

        HotkeyField = 0x32,

        Slider = 0x33,

        SpinButton = 0x34,

        Diagram = 0x35,

        Animation = 0x36,

        Equation = 0x37,

        ButtonDropdown = 0x38,

        ButtonMenu = 0x38,

        ButtonDropdownGrid = 0x3a,

        WhiteSpace = 0x3b,

        PageTableList = 0x3c,

        Clock = 0x3d,

        SplitButton = 0x3e,

        IpAddress = 0x3f,

        OutlineButton = 0x40
    }
}
