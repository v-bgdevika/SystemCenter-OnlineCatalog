namespace Mom.Test.UI.Core.Console.MomControls.DashboardControls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Automation;
    using Maui.Core;
    using Maui.Core.WinControls;
    using MomCommon = Mom.Test.UI.Core.Common;

    /// <summary>
    /// This is a list of extension methods for the DataGridControl
    /// </summary>
    public static class DataGridControlExtensions
    {
        /// <summary>
        /// This method returns the list of headers of the data grid
        /// </summary>
        /// <param name="dataGrid">the data grid</param>
        /// <returns>list of headers for the data grid</returns>
        public static List<string> GetColumHeaders(this DataGridControl dataGrid)
        {
            return dataGrid.ColumnHeaders;
        }

        /// <summary>
        /// This method returns the content of the data grid
        /// </summary>
        /// <param name="dataGrid">the data grid</param>
        /// <returns>the content of the data grid</returns>
        public static List<List<string>> GetRowData(this DataGridControl dataGrid)
        {
            List<List<string>> rows = new List<List<string>>();
            foreach (DataGridRowExtended row in dataGrid.RowsExtended)
            {
                List<string> r = new List<string>();
                foreach (DataGridCellExtended cell in row.CellsExtended)
                {
                    r.Add(cell.NameExtended);
                }

                rows.Add(r);
            }

            return rows;
        }

        /// <summary>
        /// This method return the data of the selected row
        /// </summary>
        /// <param name="dataGrid">the data grid</param>
        /// <returns>data of the selected row</returns>
        public static List<string> GetSelectedRow(this DataGridControl dataGrid)
        {
            List<string> selectedRow = new List<string>();

            DataGridRowExtended currentRow = dataGrid.RowsExtended.Where(row => row.ScreenElementExtended.HasFocus).FirstOrDefault();

            foreach (DataGridCellExtended cell in currentRow.CellsExtended)
            {
                selectedRow.Add(cell.NameExtended);
            }

            return selectedRow;
        }

        /// <summary>
        /// This method selects a row in the data grid
        /// </summary>
        /// <param name="dataGrid">the data grid</param>
        /// <param name="rowId">index of the row to be selected.</param>
        public static void SelectRow(this DataGridControl dataGrid, int rowId)
        {
            CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccess(delegate()
            {
                try
                {
                    dataGrid.ReAttachTo(dataGrid.ScreenElement);
                    dataGrid.RowsExtended[rowId].CellsExtended[0].Select();
                    return true;
                }
                catch
                {
                    return false;
                }
            }, 
            Core.Common.Constants.OneMinute / 2);
        }

        /// <summary>
        /// This method selects a row in the data grid
        /// </summary>
        /// <param name="dataGrid">the data grid</param>
        /// <param name="rowId">index of the row to be selected.</param>
        public static int GetColumnIndex(this DataGridControl dataGrid, string columnName)
        {
            List<string> ColumnHeaders = GetColumHeaders(dataGrid);

            if (ColumnHeaders.Contains(columnName))
                return ColumnHeaders.IndexOf(columnName);
            
            return -1;
        }
    }

    /// <summary>
    /// This is a list of extension methods for the Diagram control
    /// </summary>
    public static class DiagramControlExtensions
    {
        /// <summary>
        /// This method returns the list of nodes in a diagram control
        /// </summary>
        /// <param name="diagramControl">the diagram control</param>
        /// <returns>list of nodes</returns>
        public static List<Nitro.DiagramControl.NodeControl> GetAllNodes(this Nitro.DiagramControl diagramControl)
        {
            return diagramControl.GetAllVisibleNodes();
        }

        /// <summary>
        /// This method returns the list of edges in a diagram control
        /// </summary>
        /// <param name="diagramControl">the diagram control</param>
        /// <returns>list of edgs</returns>
        public static List<Nitro.DiagramControl.EdgeControl> GetAllEdges(this Nitro.DiagramControl diagramControl)
        {
            return diagramControl.GetAllVisibleEdges();
        }
    }
}