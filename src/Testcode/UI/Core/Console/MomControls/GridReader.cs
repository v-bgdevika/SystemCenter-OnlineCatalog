namespace  Mom.Test.UI.Core	
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;
    using System.Text.RegularExpressions;
    using Maui.Core;
    using Maui.Core.WinControls;

    public class GridReader
    {
        ///  <summary>
        /// Read the contents of a DataGridControl and converts to a DataTable of strings (converting groups into columns in table)
        ///  Only works on WPF/Silverlight grids, not winforms
        ///  </summary>
        ///  <param  name="Window">parent window</param>
        ///  <param  name="queryId">maui query id to identify the grid</param>
        ///  <param  name="tableName">name of the table to create, if null will be "Grid"+automationID</param>
        ///  <param  name="columnTypes">optional a collection of strings. The column name is the key and value is the type name</param>
        ///  <returns>grid  data  convert  to  a  DataTable</returns>
        ///  <history>
        ///          [Lisa]  20Jul10  -  Created          
        ///          [BillHodg] 20Jul10 - Modified to link to grid control and not take a Console dependency and added typed columns
        ///  </history>
        public static DataTable Read(Maui.Core.Window window, QID queryId, string tableName, Dictionary<string, Type> columnTypes)
        {
            Mom.Test.UI.Core.Console.MomControls.DataGridControl gridControl =
                new Mom.Test.UI.Core.Console.MomControls.DataGridControl(window, queryId);
            
            return Read(gridControl, tableName, columnTypes);
        }


        /// <summary>
        /// Read the contents of a GridControl and converts to a DataTable of strings (converting groups into columns in table)
        /// </summary>
        public static DataTable Read(Mom.Test.UI.Core.Console.MomControls.DataGridControl viewGrid, string tableName)
        {
            return Read(viewGrid, tableName, new Dictionary<string, Type>());
        }


        /// <summary>
        /// Read the contents of a GridControl and converts to a DataTable of strings (converting groups into columns in table)
        /// </summary>
        public static DataTable Read(Mom.Test.UI.Core.Console.MomControls.GridControl viewGrid, string tableName, Dictionary<string, Type> columnTypes)
        {
            //create rows
            List<List<string>> rows = new List<List<string>>();
            int maxCells = 0;
            foreach (var row in viewGrid.Rows)
            {                
                List<string> cells = new List<string>();
                foreach (var cell in row.Cells)
                    cells.Add(cell.GetValue());
                if(cells.Count > 0) //The first row may be empty (a spacer for the headings?)
                    rows.Add(cells);
                if(cells.Count > maxCells)
                    maxCells=cells.Count;
            }

            // create headings
            List<KeyValuePair<string, Type>> headers = new List<KeyValuePair<string, Type>>();
            int headerCount=0;
            foreach(var header in viewGrid.ColumnHeaders)
            {
                if (!String.IsNullOrWhiteSpace(header.Name))
                {
                    if (columnTypes.ContainsKey(header.Name))
                        headers.Add(new KeyValuePair<string,Type>(header.Name, columnTypes[header.Name]));
                    else
                        headers.Add(new KeyValuePair<string,Type>(header.Name, typeof(string)));
                }
                else
                {
                    headers.Add(new KeyValuePair<string,Type>("Column" + headerCount, typeof(string)));
                }
                headerCount++;
            }

            // handle missing headings
            while(headerCount < maxCells)
            {
                headers.Add(new KeyValuePair<string,Type>("Column" + headerCount, typeof(string)));
                headerCount++;
            }
            return CreateDataTableFromGridValues(headers, rows, tableName);
        }


        /// <summary>
        /// Read the contents of a DataGridControl and converts to a DataTable of strings (converting groups into columns in table)
        /// </summary>
        public static DataTable Read(Mom.Test.UI.Core.Console.MomControls.DataGridControl viewGrid, string tableName, Dictionary<string, Type> columnTypes)
        {
            //create rows
            List<List<string>> rows = new List<List<string>>();
            int maxCells = 0;
            foreach (var row in viewGrid.Rows)
            {                
                List<string> cells = new List<string>();
                foreach (var cell in row.Cells)
                    cells.Add(cell.Value);
                if(cells.Count > 0) //The first row may be empty (a spacer for the headings?)
                    rows.Add(cells);
                if(cells.Count > maxCells)
                    maxCells=cells.Count;
            }

            // create headings
            List<KeyValuePair<string, Type>> headers = new List<KeyValuePair<string, Type>>();
            int headerCount=0;
            foreach(string header in viewGrid.ColumnHeaders)
            {
                if (!String.IsNullOrWhiteSpace(header))
                {
                    if (columnTypes.ContainsKey(header))
                        headers.Add(new KeyValuePair<string,Type>(header, columnTypes[header]));
                    else
                        headers.Add(new KeyValuePair<string,Type>(header, typeof(string)));
                }
                else
                {
                    headers.Add(new KeyValuePair<string,Type>("Column" + headerCount, typeof(string)));
                }
                headerCount++;
            }

            // handle missing headings
            while(headerCount < maxCells)
            {
                headers.Add(new KeyValuePair<string,Type>("Column" + headerCount, typeof(string)));
                headerCount++;
            }
            return CreateDataTableFromGridValues(headers, rows, tableName);
        }

#region obsolete functions
        [System.Obsolete("use Dictionary<string, Type> instead of Dictionary<string, string>", false)]
        public static DataTable Read(Maui.Core.Window window, QID queryId, string tableName, Dictionary<string, string> columnTypes)
        {
            Dictionary<string, Type> convertedDictionary = new Dictionary<string,Type>();
            foreach(KeyValuePair<string, string> kvp in columnTypes)
            {
                convertedDictionary.Add(kvp.Key, System.Type.GetType(kvp.Value));
            }
            return Read(window, queryId, tableName, convertedDictionary);
        }

        [System.Obsolete("use Dictionary<string, Type> instead of Dictionary<string, string>", false)]
        public static DataTable Read(Mom.Test.UI.Core.Console.MomControls.DataGridControl gridControl, string tableName, Dictionary<string, string> columnTypes)
        {
            Dictionary<string, Type> convertedDictionary = new Dictionary<string,Type>();
            foreach(KeyValuePair<string, string> kvp in columnTypes)
            {
                convertedDictionary.Add(kvp.Key, System.Type.GetType(kvp.Value));
            }
            return Read(gridControl, tableName, convertedDictionary);
        }
#endregion


        /// <summary>
        /// converts labels from a datagrid to a DataTable of strings (converting groups into columns in table)
        /// All groups must be expanded before calling (they noramlly will be when the dashboard is opened)
        /// When the non-group rows are added to the DataTable an additional column per group is created to hold the group values
        /// </summary>
        /// <param name="headerNames">The # of header names must match the number of cells in each row</param>
        /// <param name="rowValues">Values in the cells of the table. Groups are formatted "Name: Value (#OfNonGroupDescendants)" in each of their cells</param>
        /// <returns></returns>
        public static DataTable CreateDataTableFromGridValues(List<KeyValuePair<string, Type>> headerNames, List<List<String>> rowValues, string tableName)
        {
            DataTable dtResult = new DataTable(tableName);
            for (int i = 0; i < headerNames.Count; i++)
            {
                dtResult.Columns.Add(headerNames[i].Key, headerNames[i].Value);
            }

            int? numGroups = null;
            int nextElementLevel = 0;

            List<String> groupNames = new List<String>(); 
            List<String> groupValues = new List<String>();
            List<int> elementsLeftInGroup = new List<int>();
            
            int rowNum = 0;
            foreach (List<string> row in rowValues)
            {
                rowNum++;
                String groupName, value;
                int numElements;
                if (numGroups == null)
                {
                    // All rows so far have parsed as groups - still looking for the first data row.
                    if (ParseGroupLabel(row, out groupName, out value, out numElements))
                    {
                        if (groupNames.Contains(groupName))
                            throw new ArgumentException("Repeated group name on different levels while finding first elements" + rowNum);

                        dtResult.Columns.Add(groupName, System.Type.GetType("System.String"));
                        groupNames.Add(groupName);
                        groupValues.Add(value);
                        elementsLeftInGroup.Add(numElements);
                        nextElementLevel++;
                        continue;
                    }
                    else
                    {
                        numGroups = nextElementLevel;
                        // We found the first data row -- Fall through to handling the row
                    }
                }

                bool isGroup = ParseGroupLabel(row, out groupName, out value, out numElements);
                if (numGroups == nextElementLevel) //datarow expected
                {
                    // Technically it would be legal to have all columns identical and formated like a group,
                    // but having a collapsed or missing row is far more likely
                    if (isGroup)
                        throw new ArgumentException("Got what appears to be a group row at row " + rowNum + " when expecting a DataRow - the groups must be expanded before calling");


                    if (headerNames.Count != row.Count)
                        throw new ArgumentException("Number of columns in row does not match the number of headers at row " + rowNum);

                    // Add the row to table 
                    DataRow dr = dtResult.NewRow();
                    int columnNum = 0;
                    foreach (String columnValue in row)
                        dr[columnNum++] = columnValue;
                    foreach (String columnValue in groupValues)
                        dr[columnNum++] = columnValue;
                    dtResult.Rows.Add(dr);

                    for (int i = 0; i < elementsLeftInGroup.Count; i++)
                        elementsLeftInGroup[i]--;

                    while (nextElementLevel > 0 && elementsLeftInGroup[nextElementLevel - 1] == 0)
                    {
                        nextElementLevel--;
                    }

                }
                else //group expected
                {
                    if (!isGroup) // could happen due to bad data
                        throw new ArgumentException("Expected a group of type '" + groupNames[nextElementLevel] + "' at row " + rowNum);

                    if (nextElementLevel > 0 && elementsLeftInGroup[nextElementLevel - 1] < 0) // Should never happen - bug in this function
                        throw new ApplicationException("Internal parsing error reading groups in table at row " + rowNum);

                    // groups on the same level should all have the same name - could happen due to bad data
                    if (nextElementLevel >= 0 && groupNames[nextElementLevel] != groupName)
                        throw new ArgumentException("Group name mismatch: found '" + groupName + "' expected '" + groupNames[nextElementLevel] + "' at row " + rowNum);

                    // update the counter and value
                    elementsLeftInGroup[nextElementLevel] = numElements;
                    groupValues[nextElementLevel] = value;
                    nextElementLevel++;
                }
            }
            return dtResult;
        }


        /// Expected Label format: GroupColumnName: Value (#subrows); repeated once per column
        /// <returns>true if the label in is the expected format</returns>
        static bool ParseGroupLabel(List<string> labels, out string column, out string value, out int numElements)
        {
            column = null;
            value = null;
            numElements = -1;

            if (labels.Count == 0)
                throw new ArgumentException("List of cell labels cannot be empty");

            // The labels are all identical in a groups
            foreach (String col in labels)
            {
                if (col != labels[0])
                    return false;
            }

            // match "Severity: Critical (2)" for example
            Regex parser = new Regex(@"^([^:]+):(.*)\(([0-9]+)\)$");
            MatchCollection matches = parser.Matches(labels[0]);

            if (matches.Count > 0 && matches[0].Groups.Count == 4)
            {
                column = matches[0].Groups[1].Value;
                value = matches[0].Groups[2].Value.Trim();
                try
                {
                    numElements = Convert.ToInt32(matches[0].Groups[3].Value);
                    return true;
                }
                catch { }
            }
            return false;
        }
    }
}

