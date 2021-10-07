#region Using directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Maui.Core;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.Console.MomControls;
using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
using Mom.Test.UI.Core.Console.Views.PerformanceChart;
#endregion


namespace Mom.Test.UI.Core.Console.Views.TopNPerformanceWidget
{
    public class TopNPerformanceWidget
    {
        #region Constants

        const string DataGridQID = ";[UIA]AutomationId='InnerDataGrid'";

        #endregion

        #region Constructor

        public TopNPerformanceWidget()
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to verify the columns in the grid
        /// </summary>
        /// <param name="viewHost">The view host which contains the grid to be verified</param>
        /// <param name="expectedColumns">expecnted columns</param>
        /// <returns>true/false</returns>
        public static bool VerifyColumns(ViewHost viewHost, List<string> expectedColumns)
        {
            Utilities.LogMessage("TopNPerformanceWidget.VerifyColumns...");

            bool result = true;

            //Get data grid
            DataGridControl gridControl = new DataGridControl(viewHost, new QID(DataGridQID));

            //Get columns from data grid
            List<string> actualColumns = gridControl.GetColumHeaders();

            //Print columns which is get from data grid
            foreach (string column in actualColumns)
            {
                Utilities.LogMessage("TopNPerformanceWidget.VerifyColumns:: Data grid has column:'" + column + "'");
            }

            //Check if column count is as expected
            if (actualColumns.Count == expectedColumns.Count)
            {
                Utilities.LogMessage("TopNPerformanceWidget.VerifyColumns:: Column count is as expected.");
            }
            else
            {
                Utilities.LogMessage("TopNPerformanceWidget.VerifyColumns:: Column count is not as expected.");
                //if more than one datagrid on screen, all of column headers on those datagrid will be catch in actualColumns
                //result = false;
            }

            //Check each column
            IEnumerable<string> columns = expectedColumns.Where(c => !actualColumns.Contains(c));
            if (columns.Count() > 0)
            {
                //Print columns which cannot be found
                foreach (string c in columns)
                {
                    Utilities.LogMessage("TopNPerformanceWidget.VerifyColumns:: Failed to find column:" + c);
                }
                result = false;
            }
            else
            {
                Utilities.LogMessage("TopNPerformanceWidget.VerifyColumns:: All the columns can be found.");
            }

            return result;
        }

        #endregion
    }
}