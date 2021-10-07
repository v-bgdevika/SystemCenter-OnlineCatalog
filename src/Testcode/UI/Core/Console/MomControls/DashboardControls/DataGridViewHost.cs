namespace Mom.Test.UI.Core.Console.MomControls.DashboardControls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Automation;
    //using Dump;
    using Maui.Core;
    using Maui.Core.WinControls;
    using MomCommon = Mom.Test.UI.Core.Common;
    using System.Data;

    /// <summary>
    /// This interface defines a list of controls that are available in a 
    /// view that has only a data grid control
    /// </summary>
    public interface IDataGridViewHostControls
    {
        /// <summary>
        /// The data grid control
        /// </summary>
        DataGridControl DataGrid
        {
            get;
        }
    }

   
    /// <summary>
    /// The class represents the view that has only 1 data grid as the content
    /// </summary>
    public class DataGridViewHost : ViewHost, IDataGridViewHostControls
    {
        #region QIDs

        /// <summary>
        /// Thic contains the default QIDs for the controls
        /// </summary>
        new public class ControlQIDs
        {
            /// <summary>
            /// QID for the content
            /// </summary>
            public static QID ContentQID = new QID(";[UIA]AutomationId = 'SCOMDataGrid'");

            /// <summary>
            /// QID for the data grid
            /// </summary>
            public static QID DataGridQID;
        

        }

        /// <summary>
        /// The QID for the content
        /// </summary>
        /// <returns>QID for the content</returns>
        protected override QID GetContentQID()
        {
            return ControlQIDs.ContentQID;
        }

        /// <summary>
        /// The QID for the data grid
        /// </summary>
        /// <returns>QID for the data grid</returns>
        protected virtual QID GetDataGridQID()
        {
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    ControlQIDs.DataGridQID = new QID(";[UIA]AutomationId = 'InnerDataGrid'");
                    break;
                case ProductSkuLevel.Web:
                    ControlQIDs.DataGridQID = new QID(";[UIA]AutomationId = 'silverlightDataGrid'");
                    break;
                default:
                    break;
            } 
            return ControlQIDs.DataGridQID;
        }

        #endregion

        #region private variables

        /// <summary>
        /// The data grid control
        /// </summary>
        private DataGridControl dataGridControl;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DataGridViewHost class.
        /// </summary>
        /// <param name="knownWindow">Window that is the data grid view</param>
        public DataGridViewHost(Window knownWindow)
            : base(knownWindow)
        {
        }

        #endregion

        #region IDataGridViewHostControls Members

        /// <summary>
        /// The DataGridControl
        /// </summary>
        public DataGridControl DataGrid
        {
            get
            {
                if (this.dataGridControl == null)
                {
                    this.dataGridControl = new DataGridControl(this.Content, this.GetDataGridQID());
                }

                return this.dataGridControl;
            }
        }
        
        #endregion

        /// <summary>
        /// The assumption here is that the columns exist and 
        /// that the order of string in the input columns corresponds 
        /// to the order of the grid columns on the UI.
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public DataTable GetActualRowData(List<KeyValuePair<string, Type>> columns)
        {
            var table = new DataTable();

            foreach (var col in columns)
            {
                table.Columns.Add(new DataColumn(col.Key, col.Value));
            }

            var dataGridRows = DataGridControlExtensions.GetRowData(this.DataGrid);
            if (dataGridRows == null)
            {
                throw new Exception("Did not get the data grid rows");
            }

            for (int i = 0; i < dataGridRows.Count; i++)
            {
                var row = table.NewRow();

                var dataGridRow = dataGridRows[i];
                if (dataGridRow == null)
                {
                    throw new Exception("DataGrid row is null in the row: " + i);
                }

                for (var j = 0; j < dataGridRow.Count; j++)
                {
                    var colName = columns[j].Key;
                    var cellValue = dataGridRow[j];
                    row[colName] = cellValue;
                }

                table.Rows.Add(row);
            }

            return table;
        }

    }
}