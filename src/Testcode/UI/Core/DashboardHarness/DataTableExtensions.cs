using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Mom.Test.UI.Core.Common;

namespace Mom.Test.UI.Core
{
    /// <summary>
    /// Extension methods to sort the content of the DataTable
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        /// The input data table is unaltered
        /// </summary>
        /// <param name="table"></param>
        /// <param name="sortCriteria"></param>
        /// <returns></returns>
        public static IEnumerable<DataRow> OneLevelSort(this DataTable table, string sortCriteria)
        {
            string prefix = "DataTableExtensions::OneLevelSort ";
            Utilities.LogMessage(prefix + "Start");
            try
            {
                if (table == null)
                {
                    throw new ArgumentNullException("table");
                }

                if (string.IsNullOrEmpty(sortCriteria))
                {
                    throw new ArgumentException("SortCriteria cannot be null or empty");
                }

                if (table.Rows.Count == 0)
                {
                    Utilities.LogMessage(prefix + "Table has no rows.");
                    return new List<DataRow>();
                }

                // get the rows
                IEnumerable<DataRow> unsortedList = table.Rows.Cast<object>().Cast<DataRow>().ToList();

                IEnumerable<DataRow> sortedRows;

                // get the criteria
                var splitString = sortCriteria.Split(" ".ToCharArray());
                var sortColumnName = splitString[0];
                var order = splitString[1];

                Utilities.LogMessage(prefix + "Sorting the table in " + order + " order.");

                // use linq to sort
                if (order.Equals("DESC"))
                {
                    sortedRows = from r in unsortedList
                                 orderby r[sortColumnName] descending
                                 select r;
                }
                else
                {
                    sortedRows = from r in unsortedList
                                 orderby r[sortColumnName] ascending
                                 select r;
                }

                return sortedRows;
            }
            finally
            {
                Utilities.LogMessage(prefix + "End");
            }
        }

        /// <summary>
        /// The input data table is unaltered
        /// </summary>
        /// <param name="table"></param>
        /// <param name="sortCriteria1"></param>
        /// <param name="sortCriteria2"></param>
        /// <returns></returns>
        public static IEnumerable<DataRow> TwoLevelSort(this DataTable table, string sortCriteria1, string sortCriteria2)
        {
            var prefix = "DataTableExtensions::TwoLevelSort ";
            Utilities.LogMessage(prefix + "Start");

            try
            {
                if (table == null)
                {
                    throw new ArgumentNullException("table");
                }

                if (string.IsNullOrEmpty(sortCriteria1))
                {
                    throw new ArgumentException("SortCriteria1 cannot be null or empty");
                }

                if (string.IsNullOrEmpty(sortCriteria2))
                {
                    throw new ArgumentException("SortCriteria2 cannot be null or empty");
                }

                if (table.Rows.Count == 0)
                {
                    Utilities.LogMessage(prefix + "Table has no rows.");
                    return new List<DataRow>();
                }

                // get the rows
                IEnumerable<DataRow> unsortedList = table.Rows.Cast<object>().Cast<DataRow>().ToList();

                IEnumerable<DataRow> sortedRows = unsortedList;

                // get th criteria
                var splitString1 = sortCriteria1.Split(" ".ToCharArray());
                var sortColumnName1 = splitString1[0];
                var order1 = splitString1[1];

                var splitString2 = sortCriteria2.Split(" ".ToCharArray());
                var sortColumnName2 = splitString2[0];
                var order2 = splitString2[1];

                // use LINQ to sort
                if (order1.Equals("DESC") && order2.Equals("DESC"))
                {
                    sortedRows = from r in unsortedList
                                 orderby r[sortColumnName1] descending, r[sortColumnName2] descending
                                 select r;
                }

                if (order1.Equals("DESC") && order2.Equals("ASC"))
                {
                    sortedRows = from r in unsortedList
                                 orderby r[sortColumnName1] descending, r[sortColumnName2] ascending
                                 select r;
                }

                if (order1.Equals("ASC") && order2.Equals("ASC"))
                {
                    sortedRows = from r in unsortedList
                                 orderby r[sortColumnName1] ascending, r[sortColumnName2] ascending
                                 select r;
                }

                if (order1.Equals("ASC") && order2.Equals("DESC"))
                {
                    sortedRows = from r in unsortedList
                                 orderby r[sortColumnName1] ascending, r[sortColumnName2] descending
                                 select r;
                }

                return sortedRows;
            }
            finally
            {
                Utilities.LogMessage(prefix + "End");
            }
        }

        /// <summary>
        /// Input data table is unaltered
        /// </summary>
        /// <param name="table"></param>
        /// <param name="sortCriteria1"></param>
        /// <param name="sortCriteria2"></param>
        /// <param name="sortCriteria3"></param>
        /// <returns></returns>
        public static IEnumerable<DataRow> ThreeLevelSort(this DataTable table, string sortCriteria1, string sortCriteria2, string sortCriteria3)
        {
            var prefix = "DataTableExtensions::ThreeLevelSort ";
            Utilities.LogMessage(prefix + "Start");

            try
            {
                if (table == null)
                {
                    throw new ArgumentNullException("table");
                }

                if (string.IsNullOrEmpty(sortCriteria1))
                {
                    throw new ArgumentException("SortCriteria1 cannot be null or empty");
                }

                if (string.IsNullOrEmpty(sortCriteria2))
                {
                    throw new ArgumentException("SortCriteria2 cannot be null or empty");
                }

                if (string.IsNullOrEmpty(sortCriteria3))
                {
                    throw new ArgumentException("SortCriteria3 cannot be null or empty");
                }

                if (table.Rows.Count == 0)
                {
                    Utilities.LogMessage(prefix + "Table has no rows.");
                    return new List<DataRow>();
                }

                // get the rows
                IEnumerable<DataRow> unsortedList = table.Rows.Cast<object>().Cast<DataRow>().ToList();

                IEnumerable<DataRow> sortedRows = unsortedList;

                // get the sort criteria
                var splitString1 = sortCriteria1.Split(" ".ToCharArray());
                var sortColumnName1 = splitString1[0];
                var order1 = splitString1[1];

                var splitString2 = sortCriteria2.Split(" ".ToCharArray());
                var sortColumnName2 = splitString2[0];
                var order2 = splitString2[1];

                var splitString3 = sortCriteria3.Split(" ".ToCharArray());
                var sortColumnName3 = splitString3[0];
                var order3 = splitString3[1];

                // use LINQ to sort
                if (order1.Equals("DESC") && order2.Equals("DESC") && order3.Equals("DESC"))
                {
                    sortedRows = from r in unsortedList
                                 orderby r[sortColumnName1] descending , r[sortColumnName2] descending ,
                                     r[sortColumnName3] descending
                                 select r;
                }

                if (order1.Equals("DESC") && order2.Equals("DESC") && order3.Equals("ASC"))
                {
                    sortedRows = from r in unsortedList
                                 orderby r[sortColumnName1] descending , r[sortColumnName2] descending ,
                                     r[sortColumnName3] ascending
                                 select r;
                }

                if (order1.Equals("DESC") && order2.Equals("ASC") && order3.Equals("ASC"))
                {
                    sortedRows = from r in unsortedList
                                 orderby r[sortColumnName1] descending , r[sortColumnName2] ascending ,
                                     r[sortColumnName3] ascending
                                 select r;
                }

                if (order1.Equals("DESC") && order2.Equals("ASC") && order3.Equals("DESC"))
                {
                    sortedRows = from r in unsortedList
                                 orderby r[sortColumnName1] descending , r[sortColumnName2] ascending ,
                                     r[sortColumnName3] descending
                                 select r;
                }

                if (order1.Equals("ASC") && order2.Equals("DESC") && order3.Equals("DESC"))
                {
                    sortedRows = from r in unsortedList
                                 orderby r[sortColumnName1] ascending , r[sortColumnName2] descending ,
                                     r[sortColumnName3] descending
                                 select r;
                }

                if (order1.Equals("ASC") && order2.Equals("DESC") && order3.Equals("ASC"))
                {
                    sortedRows = from r in unsortedList
                                 orderby r[sortColumnName1] ascending , r[sortColumnName2] descending ,
                                     r[sortColumnName3] ascending
                                 select r;
                }

                if (order1.Equals("ASC") && order2.Equals("ASC") && order3.Equals("ASC"))
                {
                    sortedRows = from r in unsortedList
                                 orderby r[sortColumnName1] ascending , r[sortColumnName2] ascending ,
                                     r[sortColumnName3] ascending
                                 select r;
                }

                if (order1.Equals("ASC") && order2.Equals("ASC") && order3.Equals("DESC"))
                {
                    sortedRows = from r in unsortedList
                                 orderby r[sortColumnName1] ascending , r[sortColumnName2] ascending ,
                                     r[sortColumnName3] descending
                                 select r;
                }

                return sortedRows;
            }
            finally
            {
                Utilities.LogMessage(prefix + "End");
            }
        }

        /// <summary>
        /// Writes the content of the data table to an excel readable file
        /// </summary>
        /// <param name="table"></param>
        /// <param name="fileName"></param>
        public static void WriteToTabSeparatedFile(this DataTable table, string fileName)
        {
            var prefix = "DataTableExtensions::WriteToTabSeparatedFile ";
            Utilities.LogMessage(prefix + "Start");

            try
            {
                using (var file = File.Create(fileName))
                {
                    var sr = new StreamWriter(file);
                    var columnBuilder = new StringBuilder();

                    if (table != null)
                    {
                        // write the header
                        foreach (DataColumn col in table.Columns)
                        {
                            columnBuilder.Append("\t");
                            columnBuilder.Append(col.ColumnName);
                        }
                        sr.WriteLine(columnBuilder.ToString());

                        // write the values
                        foreach (DataRow row in table.Rows)
                        {
                            var builder = new System.Text.StringBuilder(100);
                            foreach (object value in row.ItemArray)
                            {
                                builder.Append("\t");
                                builder.Append(value.ToString());
                            }

                            sr.WriteLine(builder.ToString());
                        }
                    }

                    sr.Flush();
                    sr.Close();
                    file.Close();
                }
            }

            finally
            {
                Utilities.LogMessage(prefix + "End");
            }
        }

        /// <summary>
        /// Log some statistics of the data table
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="name"></param>
        public static void PrintDataTable(this DataTable dataTable, string name)
        {
            Utilities.LogMessage("Printing the contents of: " + name);

            if (dataTable == null)
            {
                Utilities.LogMessage("The table is null!!");
                return;
            }

            Utilities.LogMessage("Number of rows: " + dataTable.Rows.Count);
            Utilities.LogMessage("Number of columns: " + dataTable.Columns.Count);
        }

        /// <summary>
        /// Transpose a datatable with one row to a data table having two columns (DisplayName and Value).
        /// THis is used for details verification
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static DataTable TransposeToDisplayNameValuePairs(this DataTable dataTable)
        {
            // Build the table
            var retVal = new DataTable();

            var displayNameColumn = "DisplayName";
            var valueColumn = "Value";

            // Add the columns
            retVal.Columns.Add(new DataColumn(displayNameColumn, typeof (string)));
            retVal.Columns.Add(new DataColumn(valueColumn, typeof (object)));

            // Only 1 row supported for now
            if (dataTable.Rows.Count < 1)
            {
                return retVal;
            }

            if (dataTable.Rows.Count > 1)
            {
                throw new Exception("Multiple rows not supported!");
            }

            // Add the data
            var row = dataTable.Rows[0];

            foreach (DataColumn column in dataTable.Columns)
            {
                var columnName = column.ColumnName;
                var columnValue = row[column];

                var displayNameValuePair = retVal.NewRow();
                displayNameValuePair[displayNameColumn] = columnName;
                displayNameValuePair[valueColumn] = columnValue;

                retVal.Rows.Add(displayNameValuePair);
            }

            // return the transposed table
            return retVal;
        }

        /// <summary>
        /// Makes it easier to sort the DataTable. 
        /// Creates a new DataTable with sorted data
        /// </summary>
        public static DataTable SortDataTable(this DataTable allData, string[] sortBy)
        {
            IEnumerable<DataRow> sortedRows = null;

            #region sort the table

            if (sortBy.Count() == 1)
            {
                sortedRows = allData.OneLevelSort(sortBy[0]);
            }
            else if (sortBy.Count() == 2)
            {
                sortedRows = allData.TwoLevelSort(sortBy[0], sortBy[1]);
            }
            else if (sortBy.Count() == 3)
            {
                sortedRows = allData.ThreeLevelSort(sortBy[0], sortBy[1], sortBy[2]);
            }
            else
            {
                throw new Exception("Cannot support the sort level: " + sortBy.Count());
            }

            #endregion

            #region Create the sortedTable

            //var filteredData = new DataTable();
            //foreach (DataColumn column in allData.Columns)
            //{
            //    filteredData.Columns.Add(new DataColumn(column.ColumnName, column.DataType));
            //}

            var filteredData = allData.Clone();

            foreach (DataRow row in sortedRows)
            {
                filteredData.ImportRow(row);
            }

            #endregion

            return filteredData;
        }

    }
}
