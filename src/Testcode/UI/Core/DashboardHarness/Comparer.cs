namespace Mom.Test.UI.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Infra.Frmwrk;
    using System.Xml;
    using MomCommon = Mom.Test.UI.Core.Common;

    /// <summary>
    /// The dashboad harness is designed to be called directly from a varmap
    /// It contains Readers and the Comparer 
    /// Because a var can only call methods in a single class all harness methods must be in the same class.
    /// </summary>
    public class Comparer
    {
        private const string dataSetName = "AllTables";

        /// <summary>
        /// the dataset is used to store all the data tables from the readers
        /// </summary>
        private DataSet dataset = new DataSet(dataSetName);

        /// <summary>
        /// Setup context for the var.
        /// This is only used when the class is called directly from a varmap
        /// It is not needed for methods
        /// </summary>
        public void Setup()
        {

        }

        /// <summary>
        /// Cleanup after the variation by removing all data 
        /// </summary>
        public void Cleanup()
        {
            RemoveAllTables();
        }

        /// <summary>
        /// Remove all data from the dataset, 
        /// can be called from within a var
        /// </summary>
        public void RemoveAllTables()
        {
            dataset.Dispose(); 
            dataset = null;
            dataset = new DataSet(dataSetName);
        }

        /// <summary>
        /// Removes one table. 
        /// </summary>
        /// <param name="tableName"></param>
        public void RemoveTable(string tableName)
        {
            dataset.Tables.Remove(tableName);
        }

        /// <summary>
        /// Gets a table so that test code could manipulate it with custom code
        /// </summary>
        /// <param name="tableName">table name</param>
        /// <returns>DataTable</returns>
        public DataTable GetTable(string tableName)
        {
            return dataset.Tables[tableName];
        }

        /// <summary>
        /// Returns the number of tables currently in the dataset
        /// </summary>
        public int NumberOfTables
        {
            get
            {
                return dataset.Tables.Count;
            }
        }

        /// <summary>
        /// Add a table to the dataset
        /// </summary>
        /// <param name="table">table to add</param>
        public void AddTable(DataTable table)
        {

            MomCommon.Utilities.LogMessage("Adding table " + table + " with " + table.Rows.Count.ToString() + " rows.", true);

            dataset.Tables.Add(table);
        }

        /// <summary>
        /// Compare the first two tables in the dataset
        /// </summary>
        /// <exception cref="VarAbort">less then two tables exist</exception>
        /// <exception cref="VarAbort">one of the first two tables is null</exception>
        /// <exception cref="VarFail">1) columns don't match, or 2) # rows don't match, or 3) row values don't match</exception>
        public void Compare()
        {
            Compare((string) null, (string) null, (SortedList<string, string>)null);
        }

        /// <summary>
        /// Compare the two named tables in the dataset
        /// </summary>
        /// <param name="table1">first table to compare</param>
        /// <param name="table2">second table to compare</param>
        /// <exception cref="VarAbort">less then two tables exist</exception>
        /// <exception cref="VarAbort">one of the first two tables is null</exception>
        /// <exception cref="VarFail">1) columns don't match, or 2) # rows don't match, or 3) row values don't match</exception>
        public void Compare(string table1, string table2)
        {
            Compare(table1, table2, (SortedList<string, string>)null);
        }

        /// <summary>
        /// Compare the two named tables in the dataset on the mapped columns
        /// Column mappings allow you compare two columns of different names
        /// Only the mapped columns are compared. Example:
        ///     <fnc name="Compare">
        ///     <recs table1="JoinedTable" table2="FilteredTable"/>
        ///     <rec key="xmlCompareData">
        ///         <![CDATA[
        ///         <ColumnMappings>
        ///             <column source="b" destination="c" />
        ///         </ColumnMappings>
        ///         ]]></rec>
        ///     </fnc>
        ///     Notes: 
        ///     The code ignores the header "ColumnMappings". Likewise the names "source" and "destination" are 
        ///     arbitrary and can actually be anything, but the order is important. The first is for the first table...
        /// </summary>
        /// <param name="table1">first table to compare</param>
        /// <param name="table2">second table to compare</param>
        /// <param name="xmlCompareData">a string of xml column mappings (see example)</param>
        /// <exception cref="VarAbort">less then two tables exist</exception>
        /// <exception cref="VarAbort">one of the first two tables is null</exception>
        /// <exception cref="VarFail">1) # rows don't match, or 2) row values don't match</exception>
        /// <exception cref="VarAbort">if a column mapping doesn't have two attributes</exception>
        public void Compare(string table1, string table2, string xmlCompareData)
        {
            SortedList<string, string> columnsMappings = ParseColumnMappings(xmlCompareData);
            Compare(table1, table2, columnsMappings);
        }

        public void Compare(DataTable table1, DataTable table2)
        {
            var columnsMappings = (SortedList<string, string>) null;
            Compare(table1, table2, columnsMappings);            
        }

        public void Compare(string table1, string table2, SortedList<string, string> columnsMappings)
        {
            if (dataset.Tables.Count <= 1)
                throw new VarAbort("Compare: there must be at least two dataset to compare");

            //Get the tables
            DataTable dt1 = null;
            if (String.IsNullOrEmpty(table1))
                dt1 = dataset.Tables[0];
            else
                dt1 = dataset.Tables[table1];

            DataTable dt2 = null;
            if (String.IsNullOrEmpty(table2))
                dt2 = dataset.Tables[1];
            else
                dt2 = dataset.Tables[table2];

            //check for nulls
            if (dt1 == null || dt2 == null)
                throw new VarAbort("Compare: one of the input data tables is null");

            Compare(dt1, dt2, columnsMappings);
        }

        /// <summary>
        /// Compare the two named tables in the dataset on the mapped columns
        /// Column mappings allow you compare two columns of different names
        /// Only the mapped columns are compared. 
        /// </summary>
        /// <param name="columnsMappings">
        /// The columns to compare e.g.
        /// SortedList<string, string> columnsMappings = new SortedList<string,string>{{"Column1","col1"},{"Column2","col3"}};
        /// </param>
        public void Compare(DataTable dt1, DataTable dt2, SortedList<string, string> columnsMappings)
        {
            //check for nulls
            if (dt1 == null || dt2 == null)
                throw new VarAbort("Compare: one of the input data tables is null");

            //compare columns
            if (dt1.Columns.Count != dt2.Columns.Count && columnsMappings == null)
            {
                MomCommon.Utilities.LogMessage(String.Format("Compare: {0} has {1} columns, while {2} has {3}",
                    dt1.TableName, dt1.Columns.Count, dt2.TableName, dt2.Columns.Count), true);
                MomCommon.Utilities.LogMessage(String.Format("Compare: {0} has columns {1}", dt1.TableName, ColumnList(dt1)), true);
                MomCommon.Utilities.LogMessage(String.Format("Compare: {0} has columns {1}", dt2.TableName, ColumnList(dt2)), true);

                throw new VarFail("Compare: DataTables do not a have matching number of columns");
            }

            if (dt1.Rows.Count != dt2.Rows.Count)
            {
                MomCommon.Utilities.LogMessage(String.Format("{0} has {1} Rows, while {2} has {3}",
                    dt1.TableName, dt1.Rows.Count, dt2.TableName, dt2.Rows.Count), true);

                //TODO: consider logging Row differences
                throw new VarFail("Compare: DataTables do not have matching number of Rows");
            }

            MomCommon.Utilities.LogMessage(String.Format("Compare: The number of colums = {0} and rows = {1}",
                dt1.Columns.Count, dt1.Rows.Count));

            //compare rows
            System.Collections.Comparer test = new System.Collections.Comparer(System.Globalization.CultureInfo.CurrentCulture);

            bool differenceFound = false;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (columnsMappings == null)
                {
                    MomCommon.Utilities.LogMessage("columnsMappings == null", true);
                    for (int j = 0; j < dt1.Columns.Count; j++)
                    {
                        if (test.Compare(dt1.Rows[i][j], dt2.Rows[i][j]) != 0)//!dt1.Rows[i][j].Equals(dt2.Rows[i][j]))
                        {
                            MomCommon.Utilities.LogMessage("Compare: non matching row " + i + " in " + dt1.TableName + ": " + RowToString(dt1.Rows[i]), true);
                            MomCommon.Utilities.LogMessage("Compare: non matching row " + i + " in " + dt2.TableName + ": " + RowToString(dt2.Rows[i]), true);
                            differenceFound = true;
                            break; //go to next row
                        }
                    }
                }
                else //if there are column mappings, restrict the comparison to them
                {
                    MomCommon.Utilities.LogMessage("columnsMappings != null", true);
                    foreach(KeyValuePair<string,string> pair in columnsMappings)
                    {
                        string sourceColumn = pair.Key;
                        string destColumn = pair.Value;
                        MomCommon.Utilities.LogMessage("sourceColumn: " + sourceColumn, true);
                        MomCommon.Utilities.LogMessage("destColumn: " + destColumn, true);
                        MomCommon.Utilities.LogMessage("dt1.Rows[i][sourceColumn] type: " + dt1.Rows[i][sourceColumn].GetType(), true);
                        MomCommon.Utilities.LogMessage("dt2.Rows[i][destColumn] type: " + dt2.Rows[i][destColumn].GetType(), true);
                        MomCommon.Utilities.LogMessage("dt1.Rows[i][sourceColumn]: " + dt1.Rows[i][sourceColumn].ToString(), true);
                        MomCommon.Utilities.LogMessage("dt2.Rows[i][destColumn]: " + dt2.Rows[i][destColumn].ToString(), true);
                        
                        if (test.Compare(dt1.Rows[i][sourceColumn], dt2.Rows[i][destColumn]) != 0)
                        {
                            MomCommon.Utilities.LogMessage("Compare: non matching row " + i + " from " + dt1.TableName + ": " + RowToString(dt1.Rows[i]), true);
                            MomCommon.Utilities.LogMessage("    comparing to " + dt2.TableName + ": " + RowToString(dt2.Rows[i]),true);
                            MomCommon.Utilities.LogMessage("    on column: " + sourceColumn, true);
                            differenceFound = true;
                            break; //go to next row
                        }
                    }
                }
            }
            if (differenceFound)
                throw new VarFail("Compare: DataTables do not have matching row values");
        }

        public void CheckContains(DataTable container, DataTable contained, string columnMappings)
        {
            var parsedColumnMappings = ParseColumnMappings(columnMappings);

            //check for nulls
            if (container == null || contained == null)
                throw new VarAbort("Compare: one of the input data tables is null");

            //compare columns
            if (container.Columns.Count != contained.Columns.Count && parsedColumnMappings == null)
            {
                MomCommon.Utilities.LogMessage(String.Format("Compare: {0} has {1} columns, while {2} has {3}",
                    container.TableName, container.Columns.Count, contained.TableName, contained.Columns.Count), true);
                MomCommon.Utilities.LogMessage(String.Format("Compare: {0} has columns {1}", container.TableName, ColumnList(container)), true);
                MomCommon.Utilities.LogMessage(String.Format("Compare: {0} has columns {1}", contained.TableName, ColumnList(contained)), true);

                throw new VarFail("Compare: DataTables do not a have matching number of columns");
            }

            if (container.Rows.Count < contained.Rows.Count)
            {
                MomCommon.Utilities.LogMessage(String.Format("{0} has {1} Rows, while {2} has {3}",
                    container.TableName, container.Rows.Count, contained.TableName, contained.Rows.Count), true);

                //TODO: consider logging Row differences
                throw new VarFail("Compare: DataTables do not have matching number of Rows");
            }

            MomCommon.Utilities.LogMessage(String.Format("Compare: The number of colums = {0} and rows = {1}",
                container.Columns.Count, container.Rows.Count));

            //compare rows
            System.Collections.Comparer test = new System.Collections.Comparer(System.Globalization.CultureInfo.CurrentCulture);

            // Take each row in the contained table
            foreach (DataRow containedRow in contained.Rows)
            {
                var containedRowFound = false;

                // Check if the container has the row.
                foreach (DataRow containerRow in container.Rows)
                {
                    var columnValuesMatch = true;

                    // Compare individual columns
                    foreach (var columnMapping in parsedColumnMappings)
                    {
                        string sourceColumn = columnMapping.Key;
                        string destColumn = columnMapping.Value;

                        var columnInContainerRow = containerRow[sourceColumn];
                        var columnInContainedRow = containedRow[destColumn];

                        if (test.Compare(columnInContainerRow, columnInContainedRow) != 0)
                        {
                            columnValuesMatch = false;
                            break;
                        }
                    }

                    if (columnValuesMatch)
                    {
                        containedRowFound = true;
                        break; 
                    }
                }

                if (!containedRowFound)
                {
                    throw new VarFail("Compare: Container does not have the Contained Table.");
                }
            }
        }

        /// <summary>
        /// converts the columns mappings as string of XML into a sorted list
        /// column names on the first table are assumed to be unique
        /// </summary>
        /// <param name="xmlMappings">
        /// Example:
        ///         <ColumnMappings>
        ///             <column source="b" destination="c" />
        ///         </ColumnMappings>
        /// </param>
        /// <returns>as sorted list - example: "b","c"</returns>
        /// <exception cref="VarAbort">if a column mapping doesn't have two attributes</exception>
        private static SortedList<string, string> ParseColumnMappings(string xmlMappings)
        {
            SortedList<string, string> columnsMappings = null;
            if (!String.IsNullOrEmpty(xmlMappings))
            {
                XmlDocument compareData = new XmlDocument();
                compareData.LoadXml(xmlMappings);
                XmlNodeList xmlColumnsMappings = compareData.SelectNodes("//column");
                
                if (xmlColumnsMappings.Count >= 0)
                {
                    columnsMappings = new SortedList<string,string>(xmlColumnsMappings.Count);
                    foreach (XmlNode column in xmlColumnsMappings)
                    {
                        if (column.Attributes.Count != 2)
                        {
                            throw new VarAbort("Compare: a column mapping must have two attributes." + xmlMappings);
                        }

                        if (!columnsMappings.ContainsKey(column.Attributes[0].Value))
                        {
                            columnsMappings.Add(column.Attributes[0].Value, column.Attributes[1].Value);
                        }
                    }
                }
            }

            return columnsMappings;
        }

        /// <summary>
        /// creates a comma delimted list of the columns in a single string
        /// </summary>
        /// <param name="dt">a data table</param>
        /// <returns></returns>
        private static string ColumnList(DataTable dt)
        {
            string dtColumns = "";
            foreach (DataColumn col in dt.Columns)
            {
                dtColumns += col.ColumnName + ", ";
            }
            if (dtColumns.Length > 0) dtColumns = dtColumns.TrimEnd(new char[] { ' ', ',' });
            return dtColumns;
        }

        /// <summary>
        /// Converts a row into a space delimited set of strings
        /// </summary>
        /// <param name="row">a DataRow</param>
        /// <returns>the string representing the row values</returns>
        private static string RowToString(DataRow row)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder(100);
            foreach (object value in row.ItemArray)
            {
                builder.Append("'");
                builder.Append(value.ToString());
                builder.Append("' ");
            }
            return builder.ToString();
        }

        //public static void FilterGreaterThan()
        //{
        //    string[] names = { "1", "2", "3", "4", "5" };
        //    string [] sub = (from i in names where i.Length <=4 select i).ToArray();
        //    foreach (var c in sub)
        //    {
        //        MomCommon.Utilities.LogMessage(c.ToString());
        //    }
        //}

        /// <summary>
        /// Filters a table using either a filter expression and/or a sort order
        /// It creates a new table with the filtered results
        /// </summary>
        /// <param name="table">table name of table to filter</param>
        /// <param name="filterCriteria">criteria expression of filter
        /// Examples:
        ///     AlertSeverity DESC
        ///     Date > '1/1/2010'
        ///     Avg (NodeResponse) 
        /// see http://msdn.microsoft.com/en-us/library/system.data.datacolumn.expression.aspx
        /// </param>
        /// <param name="sortOrder">sort order (optional)</param>
        /// <param name="newName">new table name</param>
        public void Filter(string table, string filterCriteria, string sortOrder, string newName)
        {
            if (String.IsNullOrEmpty(table) || String.IsNullOrEmpty(newName))
                throw new ArgumentNullException("Filter - table name arguments can't be null");

            if (String.IsNullOrEmpty(filterCriteria) && string.IsNullOrEmpty(sortOrder))
                throw new ArgumentNullException("Filter - either the filterCriteria or sortOrder must be non-Null");

            if (dataset.Tables[table] == null)
                throw new VarAbort("DashboardHarness.Filter - table could not be found");

            // clone the existing table structure
            DataTable copyTable = dataset.Tables[table].Clone();
            copyTable.TableName = newName;

            // Filter all the rows and add them to the copy
            DataRow[] rows = dataset.Tables[table].Select(filterCriteria,sortOrder);
            foreach (DataRow dr in rows)
            {
                copyTable.ImportRow(dr);
            }

            // add the table to the dataset
            dataset.Tables.Add(copyTable);
        }

        /// <summary>
        /// Compare table1, column1 to table2 column2. 
        /// Create a new table that contains the matching (or non-matching) rows
        /// Note: this can be fastest if the second table is the larger table
        /// </summary>
        /// <param name="table1">name of first table</param>
        /// <param name="column1">column to join on first table</param>
        /// <param name="table2">name of second table</param>
        /// <param name="column2">column to join on seconed table</param>
        /// <param name="newName">the name of the new table</param>
        /// <param name="same">"true" if the new table will contain the matching rows. "false" if the non-matching rows </param>
        /// <exception cref="ArgumentNullException">if a string input is null or empty</exception>
        /// <exception cref="VarAbort">if the tables or columns could not be found</exception>
        public void Join(string table1, string column1, string table2, string column2, string newName, bool same)
        {
            if (String.IsNullOrEmpty(table1) || String.IsNullOrEmpty(column1) || String.IsNullOrEmpty(table2) || String.IsNullOrEmpty(column2))
                throw new ArgumentNullException("DashboardHarness.Join parameters must not be null");

            DataTable dt1 = dataset.Tables[table1];
            DataTable dt2 = dataset.Tables[table2];

            if (dt1 == null || dt2 == null)
                throw new VarAbort("DashboardHarness.Join: a table was not found: " + table1 + " or " + table2);

            if (dt1.Columns[column1] == null || dt2.Columns[column2] ==null)
                throw new VarAbort("DashboardHarness.Join: columns could not be found in their tables: " + column1 + " or " + column2);

            //fill a hash table for table 2
            //System.Collections.Comparer test = new System.Collections.Comparer(System.Globalization.CultureInfo.CurrentCulture);
            System.Collections.Hashtable dt2Hash = new System.Collections.Hashtable(dt2.Rows.Count);
            foreach (DataRow row in dt2.Rows)
            {
                if (! dt2Hash.ContainsKey(row[column2]))
                    dt2Hash.Add(row[column2], row[column2]);
            }

            //create a new table of all (non-)matching rows in table1
            DataTable newTable = dataset.Tables[table1].Clone();
            newTable.TableName = newName;
            foreach (DataRow row in dt1.Rows)
            {
                if (dt2Hash.ContainsKey(row[column1]) == same)
                    newTable.ImportRow(row);
            }

            dataset.Tables.Add(newTable);
        }

        /// <summary>
        /// Used to log the values in any table so you can see what you've got
        /// This can be useful for debugging
        /// </summary>
        /// <param name="tableName">internal name of the table</param>
        /// <param name="numberOfRows">the max number of rows to log. 0 = all</param>
        public void LogTable(string tableName, int numberOfRows)
        {
            if (!dataset.Tables.Contains(tableName))
                throw new VarAbort("Table " + tableName + " could not be found");

            DataTable dt = dataset.Tables[tableName];

            //create column header
            string header = "";
            foreach (DataColumn col in dt.Columns)
            {
                header = header + "'" + col.ColumnName + "' ";
            }
            //remove the last ", "
            //if (header.Length > 1) header = header.Substring(0, header.Length - 2);

            MomCommon.Utilities.LogMessage("LogTable: logging table " + tableName, true);
            MomCommon.Utilities.LogMessage(header, true);

            //log rows
            foreach (DataRow row in dt.Rows)
            {
                MomCommon.Utilities.LogMessage(RowToString(row), true);
            }
        }
    }
}
