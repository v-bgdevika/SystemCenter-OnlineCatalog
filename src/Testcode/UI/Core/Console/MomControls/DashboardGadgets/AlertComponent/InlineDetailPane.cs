using System;
using System.Collections.Generic;
using System.Data;
using Maui.Core;
using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
using dataAccess = Microsoft.EnterpriseManagement.Presentation.DataAccess;
using System.Xml.Linq;
using System.Linq;
using Mom.Test.UI.Core;
using System.Windows.Forms;
using Mom.Test.UI.Core.Common;
using Mom.Test.UI.Core.ResourceLoader;
using Mom.Test.UI.Core.GenericDataQuery;
namespace Mom.Test.UI.Core.Console.MomControls.DashboardGadgets.AlertComponent
{
    public class InlineDetailPane : InlineDetailsPaneHost, IObserver<dataAccess.IDataObject>
    {
        //private IAlertDetailsDisplayStringQuery alertDetailsDisplayStringQuery;
        //private IAlertDetailsQuery alertDetailsQuery;
        private IEnumerable<dataAccess.IDataObject> alertDetails = null;
        private bool alertDetailsPresent = false;
        
         [Resource(ID = "Title")]
        public string expectedTitleText;

         [Resource(ID = "ColumnMapping")]
        private string columnMappings;

          [Resource(ID = "FilterExpectedData")]
        private string filterExpected;

          [Resource(ID = "FilterActualData")]
        private string filterActual;

        //Replace the % with instanceID when ever required.
        public static string DetailsForTheSelectedAlertString = ";[UIA]ClassName = 'DataGridDetailsPresenter' && Instance='%'";


        public InlineDetailPane(Window knownWindow, Dictionary<string, object> properties, int selectedRow, XElement resource)
            : base(knownWindow)
        {
            //this.alertDetailsDisplayStringQuery = alertDetailsDisplayStringQuery;
            //this.alertDetailsQuery = alertDetailsQuery;
            DetailsForTheSelectedAlertString.Replace("%", (selectedRow + 1).ToString());
            alertDetails = this.GetAlertDetails(properties);
            ResourceLoader.ResourceLoader.LoadResources(this, resource);
        }
        private static DataTable PreparePropertiesTableForComparison(DataTable output, string tableName, List<string> includeProperties)
        {
            // We need a table where the Column values can be altered.
            var fixedOutput = new DataTable(tableName);
            foreach (DataColumn column in output.Columns)
            {
                var fixedColumn = new DataColumn(column.ColumnName, column.DataType) { ReadOnly = false };
                fixedOutput.Columns.Add(fixedColumn);
            }

            // Copy the data in it's entireity
            foreach (DataRow row in output.Rows)
            {
                fixedOutput.ImportRow(row);
            }

            // Fixup the output
            foreach (DataRow row in fixedOutput.Rows)
            {

                if (row["Value.Value"] != DBNull.Value)
                {
                    row["Value"] = row["Value.Value"];
                }
            }

            return RemovePropertiesThatCannotBeVerified(fixedOutput, tableName, includeProperties, "DisplayName");
        }
        private static DataTable RemovePropertiesThatCannotBeVerified(DataTable fixedOutput, string tableName, List<string> includeProperties, string searchColumnName)
        {
            // Some of the properties cannot be compared.
            // Find the rows that have those property values.
            var rowsThatCannotBeVerified = new List<DataRow>();
            foreach (DataRow row in fixedOutput.Rows)
            {
                var propertiesThatCannotBeVerified = from p in AlertProperty.PropertiesThatCannotBeVerified
                                                     where (p.PropertyName).StartsWith(row[searchColumnName] as string, StringComparison.OrdinalIgnoreCase)
                                                     select p;

                var canThisRowBeVerified = (propertiesThatCannotBeVerified.Count() == 0) ? true : false;

                if (!includeProperties.Contains(row[searchColumnName] as string))
                {
                    rowsThatCannotBeVerified.Add(row);
                }
            }

            // Remove the rows that cannot be verified
            foreach (var dataRow in rowsThatCannotBeVerified)
            {
                fixedOutput.Rows.Remove(dataRow);
            }

            // return the fixed output
            return fixedOutput;
        }

        public void Verify(List<string> VerifyProperties)
        {
            

            #region Verify the content

            string expectedAlertDetailsName = "ExpectedAlertDetails";
            string filteredExpectedAlertDetailsName = "Filtered_ExpectedAlertDetails";

            string actualAlertDetailsName = "ActualAlertDetails";
            string filteredActualAlertDetailsName = "Filtered_ActualAlertDetails";


            /// Get the data table form of the details from the data query
            var details = ConvertToDataTable.GenerateTable(this.alertDetails, expectedAlertDetailsName);
            Comparer comparer = new Comparer();
            var expectedDetails = PreparePropertiesTableForComparison(details, expectedAlertDetailsName, VerifyProperties);
            comparer.AddTable(expectedDetails);
            comparer.Filter(expectedAlertDetailsName, this.filterExpected, "", filteredExpectedAlertDetailsName);

            // Get the DataTable form of the details from the UI
            // remove the properties we can not verify
            var actualDetails = RemovePropertiesThatCannotBeVerified(DetailsPaneReader.Read(this.Details), actualAlertDetailsName, VerifyProperties, "PropertyName");
            actualDetails.TableName = actualAlertDetailsName;
            
            comparer.AddTable(actualDetails);
            comparer.Filter(actualAlertDetailsName, this.filterActual, "", filteredActualAlertDetailsName);

          //   Compare expected and actual
            comparer.Compare(filteredExpectedAlertDetailsName, filteredActualAlertDetailsName, this.columnMappings);

            #endregion

            // //Console.WriteLine("Verified the alert details");
        }

        #region IObserver members

        public void OnCompleted() { }

        public void OnError(Exception error) { }

        public void OnNext(dataAccess.IDataObject alert)
        {
            //Console.WriteLine("A new alert has been selected");
            this.alertDetailsPresent = true;

            // Get the alert details
            LoadExpectedAlertDetails(alert);

            //Console.WriteLine("Got the alert details");
        }
        public static IEnumerable<dataAccess.IDataObject> GetAlertDetails1(Dictionary<string, object> properties, List<string> includeProperties)
        {
            using (var query = new Mom.Test.UI.Core.GenericDataQuery.GetSingleAlertDetailsQuery())
            {
                //query.SetProperty("Id", alertId, true);

                foreach (var property in properties)
                {
                    query.SetProperty(property.Key.ToString(), property.Value, false);
                }
                query.WaitUntilReady();
                //To try catch for exception handling
                IEnumerable<dataAccess.IDataObject> idata = query.GetProperty("Output") as IEnumerable<dataAccess.IDataObject>;
                var datatable = PreparePropertiesTableForComparison(ConvertToDataTable.GenerateTable(idata, "test"), "test", includeProperties);
                return query.GetProperty("Output") as IEnumerable<dataAccess.IDataObject>;
            }
        }
        private IEnumerable<dataAccess.IDataObject> GetAlertDetails(Dictionary<string, object> properties)
        {
            using (var query = new Mom.Test.UI.Core.GenericDataQuery.GetSingleAlertDetailsQuery())
            {
                //query.SetProperty("Id", alertId, true);

                foreach (var property in properties)
                {
                    query.SetProperty(property.Key.ToString(), property.Value, false);
                }
                query.WaitUntilReady();
                //To try catch for exception handling
                return query.GetProperty("Output") as IEnumerable<dataAccess.IDataObject>;
            }
        }
        private void LoadExpectedAlertDetails(dataAccess.IDataObject alert)
        {
            //this.alertDetailsDisplayStringQuery.AlertProperties = this.projectionColumns;
            //this.alertDetailsQuery.PropertyNameAndDisplayNamePairs = this.alertDetailsDisplayStringQuery.GetPropertyNameAndDisplayNamePairs();
            // need to pass int he right AlertId selected From grid
            //this.alertDetailsQuery.AlertId = (Guid)alert["Id"];
           // this.alertDetails = this.GetAlertDetails((Guid)alert["Id"]);
        }

        #endregion
    }
}
