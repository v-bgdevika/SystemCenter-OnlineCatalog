using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

// The extension name is different because it would give an opportunity to change this behavior
namespace Mom.Test.UI.Core.GenericDataQuery.DataQueryEntensions
{
    /// <summary>
    /// Set of useful data query extensions
    /// </summary>
    public static class DataQueryExtensions
    {
        /// <summary>
        /// Return the output of the query as a DataTable. If the query was in an error,
        /// the error is thrown as an exception.
        /// </summary>
        /// <param name="query">query component</param>
        /// <returns>output of the query as a DataTable</returns>
        public static DataTable GetOutput(this DataQuery query)
        {
            var actualException = query.LastError;
            if (actualException != null)
            {
                throw new Exception("Query execution failed.", actualException);
            }

            var output = query.GetProperty(DataQuery.PropertyNames.Output);
            if (output == null)
            {
                throw new Exception("Output of the query is null!");
            }

            var result = output as IEnumerable<IDataObject>;
            if (result == null)
            {
                throw new Exception("Unexpected Output type." +
                                    " Expected: " + typeof(IEnumerable<IDataObject>) +
                                    " Actual: " + output.GetType().Name);
            }

            return ConvertToDataTable.GenerateTable(result, "ActualData");
        }

        public static DataTable GetOutputItem(this CommonDataSourceInterface query)
        {
            var actualException = query.LastError;
            if (actualException != null)
            {
                throw new Exception("Query execution failed.", actualException);
            }

            var output = query.GetProperty(CommonDataSourceInterface.PropertyNames.OutputItem);
            if (output == null)
            {
                throw new Exception("Output of the query is null!");
            }

            var result = output as IDataObject;
            if (result == null)
            {
                throw new Exception("Unexpected Output type." +
                                    " Expected: " + typeof(IDataObject) +
                                    " Actual: " + output.GetType().Name);
            }

            var list = new List<IDataObject>();
            list.Add(result);
            return ConvertToDataTable.GenerateTable(list, "ActualDataOutputItem");
        }
    }
}