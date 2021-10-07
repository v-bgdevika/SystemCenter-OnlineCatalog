namespace Mom.Test.UI.Core
{
    using System;
    using System.Data;
    using Infra.Frmwrk;
    using Microsoft.EnterpriseManagement.Test.ScCommon;

    public class SQLReader
    {
        /// <summary>
        /// Reads SQL data into a data table for use later
        /// This makes heavy use of DBUtil so as not to reinvent connection methods for the OM DB and DW
        /// </summary>
        /// <param name="sourceDB">either "DB" or "DW"</param>
        /// <param name="query">a sql query</param>
        /// <param name="resultTableName">the name of the resulting table</param>
        /// <param name="resultColumn">optional column name. We'll return the value in the first row of this column</param>
        /// <returns>the DataTable</returns>
        public static DataTable Read(DashboardHarness harness, string sourceDB, string query, string resultTableName)
        {
            if (String.IsNullOrEmpty(query))
                throw new VarAbort("SQLReader: the query param must not be empty");

            if (String.IsNullOrEmpty(resultTableName))
                throw new VarAbort("SQLReader: the resultTableName param must not be empty");

            if(sourceDB != "DW" && sourceDB != "DB")
                throw new VarAbort("SQLReader: the sourceDB param must be 'DW' or 'DB'");
            DBUtil.CurrentConnection = sourceDB == "DW"? DBUtil.DBConnection.MOMDW : DBUtil.DBConnection.MOMDB;

            DataView view = DBUtil.ExecuteQueryWithResults(query);

            DataTable resultTable = null;
            if (view != null)
            {
                resultTable = view.ToTable(resultTableName);                    
            }
            return resultTable;
        }

        
        public static string ReadFirstValue(DashboardHarness harness, string sourceDB, string query, string resultColumn)
        {
            string returnValue = null;
            DataTable resultTable = Read(harness, sourceDB, query, "TempTableName");
            //get the value of the resultColumn in the first row to return it
            if (resultTable.Rows.Count > 0)
            {
                if (resultTable.Columns.Contains(resultColumn))
                    returnValue = resultTable.Rows[0][resultColumn].ToString();
                else
                    throw new VarAbort("SQLReader: " + resultColumn + " column not found");
            }
            return returnValue;
        }
    }
}
