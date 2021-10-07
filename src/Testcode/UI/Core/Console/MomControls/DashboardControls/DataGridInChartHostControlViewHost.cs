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

    /// <summary>
    /// This interface lists the controls in the view that has a data grid in the 
    /// view based off the chart host control.
    /// </summary>
    public interface IDataGridInChartHostControlControls
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
    /// This class represents the view that has a data grid and a duration as the content
    /// </summary>
    public class DataGridInChartHostControlViewHost : ChartHostControlViewHost, IDataGridInChartHostControlControls
    {
        #region QIDs

        /// <summary>
        /// The default QIDs for the controls in this class
        /// </summary>
        new public class ControlQIDs
        {
            /// <summary>
            /// QID for the DataGrid
            /// </summary>
            public static QID DataGridQID = new QID(";[UIA]AutomationId = 'SCOMDataGrid';[UIA]AutomationId = 'InnerDataGrid'");
        }

        /// <summary>
        /// Gets the QID for the data grid in the voew
        /// </summary>
        /// <returns>QID for the data grid</returns>
        protected virtual QID GetDataGridQID()
        {
            return ControlQIDs.DataGridQID;
        }

        #endregion

        #region protected variables

        /// <summary>
        /// The data grid control
        /// </summary>
        protected DataGridControl dataGrid;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DataGridInChartHostControlView class
        /// </summary>
        /// <param name="knownWindow"></param>
        public DataGridInChartHostControlViewHost(Window knownWindow)
            : base(knownWindow)
        {
        }

        #endregion

        #region public properties

        /// <summary>
        /// The data grid control
        /// </summary>
        public DataGridControl DataGrid
        {
            get
            {
                if (this.dataGrid == null)
                {
                    this.dataGrid = new DataGridControl(this.Content, this.GetDataGridQID());
                }

                return this.dataGrid;
            }
        }

        #endregion
    }
}