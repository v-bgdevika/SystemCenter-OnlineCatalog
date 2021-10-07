namespace Mom.Test.UI.Core
{
    using System;
    using System.Data;
    using Infra.Frmwrk;
    using System.Collections.Generic;
    using System.Threading;
    using System.Reflection;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.EnterpriseManagement.Presentation.Security;
    using Microsoft.EnterpriseManagement.Presentation.DataAccess;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    using System.IO;
    using System.Windows;
    using Microsoft.EnterpriseManagement.Test.ScCommon;
    using Maui.Core;
    using Mom.Test.UI.Core.Common;
    using Microsoft.EnterpriseManagement.Test.FrmwrkCommon.Topology;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
    using Microsoft.EnterpriseManagement.Test.FrmwrkCommon;
    /// <summary>
    ///  Converts a IDataObject tree into a single DataTable for use as a data warehouse
    /// </summary>
    public static class ConvertToDataTable
    {
        // The path column stores a leaf node's location in the IDataObject tree (for joins for example)
        public static string PathColumnName = "path";

        /// <summary>
        /// Generate Table with names column names based in the "." separated locations in the tree
        /// e.g. ServiceLevelObjective.ServiceLevelObjectiveGuid
        /// </summary>
        /// <param name="objs">A tree of IDataObjects and IDataCollections</param>
        /// <param name="tableName">Name of the table to return</param>
        /// <returns>a Datatable containing one row per leaf node in the objs</returns>
        public static DataTable GenerateTable(IEnumerable<IDataObject> objs, string tableName)
        {
            Dictionary<string, bool> columnNames = new Dictionary<string, bool>();
            DataTable table = new DataTable(tableName);

            // This holds the location in the tree
            DataColumn path = new DataColumn();
            path.ColumnName = PathColumnName;
            path.DataType = typeof(string);
            table.Columns.Add(path);


            foreach (IDataObject obj in objs)
                GenerateColumns(obj, new List<IDataObject>(), "", columnNames, table);
            int i = 0;
            foreach (IDataObject obj in objs)
                AddRows(obj, new List<IDataObject>(), "", new Dictionary<string, object>(), String.Format("{0}[{1}]", tableName, i++), table);

            Utilities.LogMessage("Generating table '" + tableName + "' with " + table.Columns.Count + " columns and " + table.Rows.Count + " rows.");
            return table;
        }

        // columnName holds the . separated current location in object tree
        private static void GenerateColumns(IDataObject obj, List<IDataObject> roots, string columnName, Dictionary<string, bool> columnNames, DataTable table)
        {
            //use this list to check recursive property to prevent stack over flow
            roots.Add(obj);

            foreach (IDataProperty property in obj.Type.Properties)
            {
                string propertyName;
                if (columnName == "")
                    propertyName = property.Name;
                else
                    propertyName = columnName + "." + property.Name;

                // Add a new column (if needed) for non-ICollections/IDataObjects
                if (obj[property.Name] is ICollection<IDataObject>)
                {
                    // Recursively search ICollections for columns to add
                    foreach (IDataObject subObj in obj[property.Name] as ICollection<IDataObject>)
                    {
                        GenerateColumns(subObj, roots, propertyName, columnNames, table);
                    }
                }
                else if (obj[property.Name] is IDataObject && (!roots.Contains(obj[property.Name] as IDataObject)))
                {
                    GenerateColumns(obj[property.Name] as IDataObject, roots, propertyName, columnNames, table);
                }
                else
                {
                    if (!columnNames.ContainsKey(propertyName))
                    {
                        Utilities.LogMessage("Adding new column " + propertyName);
                        columnNames[propertyName] = true;

                        var column = new DataColumn
                                         {
                                             DataType = MapIDataPropertyToDataTableSupportedType(property),
                                             ColumnName = propertyName,
                                             ReadOnly = true,
                                             Unique = false
                                         };

                        table.Columns.Add(column);
                    }
                }
            }
        }

        private static Type MapIDataPropertyToDataTableSupportedType(IDataProperty property)
        {
            var propertyType = property.Type;

            if (IsNullableType(propertyType))
            {
                propertyType = typeof(object); // DataTable does not support nullable types.
            }

            return propertyType;
        }

        private static bool IsNullableType(Type propertyType)
        {
            var isNullableType = false;

            if (propertyType.IsGenericType && 
                propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                isNullableType = true;
            }
            return isNullableType;
        }

        // Recursively gets the contents of a IDataObject similar to AddRows but does NOT include any collections within that object
        private static Dictionary<string, object> GetIDataObjectProperties(IDataObject obj, List<IDataObject> roots, string columnName, ref bool containsCollections)
        {
            //use this list to check recursive property to prevent stack over flow
            roots.Add(obj);

            Dictionary<string, object> propertyList = new Dictionary<string, object>();
            foreach (IDataProperty property in obj.Type.Properties)
            {
                string propertyName = columnName + "." + property.Name;

                if (obj[property.Name] is ICollection<IDataObject>)
                    containsCollections = true;
                else if (obj[property.Name] is IDataObject)
                {
                    if (!roots.Contains(obj[property.Name] as IDataObject))
                    {
                        foreach (KeyValuePair<string, object> kvp in GetIDataObjectProperties(obj[property.Name] as IDataObject, roots, propertyName, ref containsCollections))
                            propertyList[kvp.Key] = kvp.Value;
                    }
                    else
                    {
                        //a recursive value
                        propertyList[propertyName] = obj[property.Name];
                    }
                }
                else
                    propertyList[propertyName] = obj[property.Name];
            }
            return propertyList;
        }

        
        /// <summary>
        /// Helper function to recursively add IDataObjects to the DataTable
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="columnName"> holds the . separated hierarchy in object tree
        /// e.g. ServiceLevelObjective.ServiceLevelObjectiveGuid</param>
        /// <param name="parentData">the combined properties of ancestors and any contained IDataObjects.  ICollection contents are NOT included</param>
        /// <param name="path">similar to column name but also includes element numbers in the collections
        /// e.g. GetServiceLevels[1].ServiceLevelObjective[2]</param>
        /// <param name="table"></param>
        private static void AddRows(IDataObject obj, List<IDataObject> roots, string columnName, Dictionary<string, object> parentData, string path, DataTable table)
        {
            Dictionary<string, object> combinedData = new Dictionary<string, object>(parentData);
            List<string> collectionNames = new List<string>();
            List<string> objectsContainingCollections = new List<string>();

            //use this list to check recursive property to prevent stack over flow
            roots.Add(obj);

            // Store the properties values of non-collection properties
            // and the names of the collections for later processing
            foreach (IDataProperty property in obj.Type.Properties)
            {
                string propertyName;
                if (columnName == "")
                    propertyName = property.Name;
                else
                    propertyName = columnName + "." + property.Name;

                if (obj[property.Name] is ICollection<IDataObject>)
                    collectionNames.Add(property.Name);
                else if (obj[property.Name] is IDataObject)
                {
                    if (!roots.Contains(obj[property.Name] as IDataObject))
                    {
                        bool containsCollection = false;
                        Dictionary<string, object> properties = GetIDataObjectProperties(
                                                                    obj[property.Name] as IDataObject
                                                                    , roots 
                                                                    ,propertyName
                                                                    , ref containsCollection);
                        foreach (KeyValuePair<string, object> kvp in properties)
                            combinedData[kvp.Key] = kvp.Value;

                        if (containsCollection)
                            objectsContainingCollections.Add(property.Name);
                    }
                    else
                    {
                        combinedData[propertyName] = obj[property.Name];
                    }
                }
                else
                    combinedData[propertyName] = obj[property.Name];
            }

            if (collectionNames.Count > 0 || objectsContainingCollections.Count > 0)
            {
                // Recursively add all collections 
                // We do NOT do permutations if the object have multiple collections
                // i.e. Objects with multiple ICollections will add each leaf node only once, 
                // and put NULLs in the fields for objects in other collections in the same object
                // Permutations can be done later via SQL joins on a truncated "path" column
                foreach (string collectionName in collectionNames)
                {
                    string propertyName;
                    if (columnName == "")
                        propertyName = collectionName;
                    else
                        propertyName = columnName + "." + collectionName;
                    int i = 0;
                    foreach (IDataObject subObj in obj[collectionName] as ICollection<IDataObject>)
                    {
                        // Add collectionname with array index to path
                        string newPath = String.Format("{0}.{1}[{2}]", path, collectionName, i);

                        AddRows(subObj, roots, propertyName, combinedData, newPath, table);
                        i++;
                    }
                }

                foreach (string objectName in objectsContainingCollections)
                {
                    string propertyName;
                    if (columnName == "")
                        propertyName = objectName;
                    else
                        propertyName = columnName + "." + objectName;

                    // the combined data already contain the rows not part of the contained collection but since we are using a dictionary 
                    // adding it does not pose an issue.
                    AddRows(obj[objectName] as IDataObject, roots, propertyName, combinedData, path+"."+objectName, table);
                }
            }
            else // leaf node - create a row with the combined data from our parents and the current IDataObject
            {
                Utilities.LogMessage(path);
                string rowOutput = ""; //used to write out debugging string
                DataRow row = table.NewRow();

                // write the path to in the path field
                row[PathColumnName] = path;

                // write all the other fields
                foreach (KeyValuePair<string, object> kvp in combinedData)
                {
                    var value = kvp.Value;
                    if (value == null)
                    {
                        var columnType = table.Columns[kvp.Key];
                        if (columnType.DataType == typeof (DateTime))
                        {
                            value = DateTime.MinValue;
                        }
                        else if (columnType.DataType == typeof(Guid))
                        {
                            value = Guid.Empty;
                        }
                    }
                    row[kvp.Key] = (null == value ? DBNull.Value : value);

                    rowOutput += kvp.Key + "=" + (value == null ? "" : value.ToString()) + " \n";
                }
                System.Console.WriteLine("AddingRow: " + rowOutput);
                table.Rows.Add(row);
            }
        }

        #region unittest
        ///The unit test data has the following structure
        /// IDataObject ut =
        /// {   
        ///     int i=1
        ///     string s = "str1"
        ///     ICollection c1 =
        ///     {
        ///         IDataObject
        ///         {
        ///             int i=21  
        ///         }
        ///         IDataObject
        ///         {
        ///             int i=22 
        ///         }
        ///     }        
        ///     IDataObject d1 = 
        ///     {
        ///         int i = 3
        ///     }
        ///     IDataObject d2 =
        ///     {
        ///         int i = 4
        ///         ICollection c2
        ///         {
        ///             IDataObject 
        ///             {
        ///                 int i=51  
        ///             }
        ///             IDataObject
        ///             {
        ///                 int i=52 
        ///             }
        ///         }
        ///     }
        /// }
        ///    This should produce 4 rows per obj:
        ///    i    s       c1.i    d1.i    d2.i    d2.c2.i  path
        ///    1    str1    21      3       4       null     unittest[0].c1[0]
        ///    1    str1    22      3       4       null     unittest[0].c1[1] 
        ///    1    str1    null    3       4       51       unittest[0].d2.c2[0]
        ///    1    str1    null    3       4       52       unittest[0].d2.c2[1]
        /// ...
        /// 


        /// <summary>
        /// Create a IDataObject tree to test conversion to a table
        /// </summary>
        public static IDataObject GetUnitTestObject()
        {
            IDataModel dm = new SimpleDataModel();
            IDataType dt1 = dm.Types.Create("d1");
            dt1.Properties.Create("i", typeof(int));
            IDataType dt2 = dm.Types.Create("d2");
            dt2.Properties.Create("i", typeof(int));
            dt2.Properties.Create("c2", typeof(IDataObjectCollection));
            IDataType ut = dm.Types.Create("ut");
            ut.Properties.Create("i", typeof(int));
            ut.Properties.Create("s", typeof(string));
            ut.Properties.Create("d1", typeof(IDataObject));
            ut.Properties.Create("d2", typeof(IDataObject));
            ut.Properties.Create("c1", typeof(IDataObjectCollection));
            IDataObject unitTestObj = dm.CreateInstance(ut);
            unitTestObj["i"] = 1;
            unitTestObj["s"] = "str1";

            IDataObjectCollection c1 = dm.CreateCollection();
            IDataObject d21 = dm.CreateInstance(dt1);
            IDataObject d22 = dm.CreateInstance(dt1);
            d21["i"] = 21;
            d22["i"] = 22;
            c1.Add(d21);
            c1.Add(d22);
            unitTestObj["c1"] = c1;

            IDataObject d1 = dm.CreateInstance(dt1);
            d1["i"] = 3;
            unitTestObj["d1"] = d1;
            IDataObject d2 = dm.CreateInstance(dt2);
            d2["i"] = 4;
            unitTestObj["d2"] = d2;
            IDataObjectCollection c2 = dm.CreateCollection();
            IDataObject d51 = dm.CreateInstance(dt1);
            IDataObject d52 = dm.CreateInstance(dt1);
            d51["i"]=51;
            d52["i"]=52;
            c2.Add(d51);
            c2.Add(d52);
            d2["c2"] = c2;
            unitTestObj["d2"] = d2;
            return unitTestObj;
        }
        
        public static DataTable GetUnitTestTable(string tableName)
        {
            List<IDataObject> objs = new List<IDataObject>();
           
            objs.Add(GetUnitTestObject());
            return GenerateTable(objs, tableName);
        }
        #endregion unittest
    }
}

