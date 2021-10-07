namespace Mom.Test.UI.Core
{
	using System;
    using System.Data;
    using Infra.Frmwrk;

    /// <summary>
    /// The dashboad harness is designed to be called directly from a varmap
    /// It contains Readers and the Comparer 
    /// Because a var can only call methods in a single class all harness methods must be in the same class.
    /// </summary>
    public class VarmapReader
    {
        /// <summary>
        /// Reads data from the varmap fnc recs into a DataTable
        /// </summary>
        /// <param name="ctx">MCF Ctx used for logging</param>
        /// <exception cref="VarAbort">if rows are jagged</exception>
        public static DataTable Read(DashboardHarness harness, IContext ctx, string Id)
        {
            DataTable table = new DataTable(Id);
            
            //create the columns
            string [] colNames = ctx.FncRecords.GetKeys();
            foreach (string name in colNames)
            {
                if (!name.EndsWith("_type"))
                {
                    Type colType = System.Type.GetType("System.String");
                    if (ctx.FncRecords.HasKey(name + "_type"))
                    {
                        string typeName = ctx.FncRecords.GetValue(name + "_type");
                        colType = Type.GetType(typeName);
                    }

                    if (name != "TableName")
                        table.Columns.Add(name, colType);
                }
            }
        
            //add the rows
            if (table.Columns.Count > 0)
            {
                int numberOfRows = ctx.FncRecords.FindValues(table.Columns[0].ColumnName).Length;

                //we need to transpose the cols and rows, so create a table in memory
                string [,] memtable = new string [table.Columns.Count,numberOfRows];

                //read in all the columns and add them, filling the in-memory table
                for(int col = 0; col < table.Columns.Count; col++)
                {
                    string [] colValues = ctx.FncRecords.GetValues(table.Columns[col].ColumnName);
// This was requiring the # of columns and rows to be equal 
// TODO: add the correct validation in
//                    if (colValues.Length != table.Columns.Count)
//                        throw new VarAbort("VarmapReader: every row must provide data for all columns");

                    for(int row = 0; row < numberOfRows; row++)
                    {
                        memtable[col,row] = colValues[row];
                    }
                }

                //read from the in-memory table into the datatable
                for(int i = 0; i < numberOfRows ; i++)
                {
                    string [] rowValues = new string [table.Columns.Count];
                    //create each row
                    for(int j = 0; j < table.Columns.Count; j++)
                    {
                        rowValues[j] = memtable[j,i];
                    }
                    table.Rows.Add(rowValues);
                }
            }
            //add table to Comparer
//            harness.AddTable(table);
            return table;
        }
    }
}
