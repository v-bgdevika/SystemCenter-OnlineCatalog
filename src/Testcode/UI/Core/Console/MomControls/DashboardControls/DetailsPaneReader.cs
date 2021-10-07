using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Maui.Core;
using System.Windows.Automation;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

namespace Mom.Test.UI.Core.Console.MomControls.DashboardControls
{
    public static class DetailsPaneReader
    {
        public static QID DetailsQID = new QID(";[UIA]ClassName = 'GenericPane';[UIA]ClassName = 'ScrollViewer'");

        public static DataTable Read(Dictionary<string, string> details)
        {
            DataTable retVal = new DataTable();

            string propertyNameColumn = "PropertyName";
            string propertyValueColumn = "PropertyValue";

            retVal.Columns.Add(new DataColumn(propertyNameColumn));
            retVal.Columns.Add(new DataColumn(propertyValueColumn));

            foreach (var item in details)
            {
                retVal.Rows.Add(item.Key, item.Value);
            }

            //foreach (var key in details.Keys)
            //{
            //    retVal.Columns.Add(key);
            //}

            //retVal.Rows.Add(details.Values);

            return retVal;
        }
    }
}
