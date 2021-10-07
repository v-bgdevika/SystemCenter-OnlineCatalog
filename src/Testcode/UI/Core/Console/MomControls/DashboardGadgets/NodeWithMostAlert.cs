using System;
using System.Collections.Generic;
using Maui.Core;
//using DashboardHarness = Mom.Test.UI.Core.;
using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
using dataAccess = Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Microsoft.EnterpriseManagement.Monitoring;
using System.Xml.Linq;
using Mom.Test.UI.Core;
using System.Windows.Forms;
using Mom.Test.UI.Core.Common;
namespace Mom.Test.UI.Core.Console.MomControls.DashboardGadgets
{
    public class NodeWithMostAlert : DataGridViewHost//, IObservable<dataAccess.IDataObject>
    {
       // private IAlertDetailsDisplayStringQuery alertDetailsDisplayStringQuery;
       // private IAlertDetailsQuery alertDetailsQuery;
      //  private IEnumerable<dataAccess.IDataObject> alertDetails = null;
      //  private bool alertDetailsPresent = false;

       // [Resource(ID = "Title")]
       // public string expectedTitleText;

       // [Resource(ID = "ColumnMapping")]
       // private string columnMappings;

       // [Resource(ID = "ProjectionColumns")]
       // private List<string> projectionColumns;

      //  [Resource(ID = "FilterExpectedData")]
      //  private string filterExpected;

      //  [Resource(ID = "FilterActualData")]
      //  private string filterActual;
        public IEnumerable<dataAccess.IDataObject> AlertNodes = null;

        public NodeWithMostAlert(Window knownWindow, INodesWithMostAlerts nodesWithMostAlertprovider)
            : base(knownWindow)
        {


            // ResourceLoader.LoadResources(this, resource);
            this.AlertNodes = nodesWithMostAlertprovider.GetNodesWithMostAlert();

            ////Console.WriteLine("AlertDetails view is initialized");
        }
       

        public void SelectNode(int rowId)
         {
             Utilities.LogMessage("Looking For DataGrid RowId: " + rowId);
             this.ScreenElement.EnsureVisible();
             this.DataGrid.SelectRow(rowId);
            // this.SelectedAlert = rowId;

             Utilities.LogMessage("Selected row: " + rowId);
         }

        public void Verify()
        {
          //  this.WaitForReady();

            #region Verify Title

            //string actTitleText = this.Title.Text;
            //if (this.expectedTitleText != actTitleText)
            //{
            //    Utilities.LogMessage("Titles mismatch. " +
            //        "Expected: " + this.expectedTitleText +
            //        "Actual: " + actTitleText
            //    );
            //    //throw new Exception("Titles mismatch. " +
            //    //    "Expected: " + this.expectedTitleText +
            //    //    "Actual: " + actTitleText
            //    //);
            //}

          //  //Console.WriteLine("Title verified");

            #endregion

            #region Verify the content

            //string expectedAlertDetailsName = "ExpectedAlertDetails";
            //string filteredExpectedAlertDetailsName = "Filtered_ExpectedAlertDetails";

            //string actualAlertDetailsName = "ActualAlertDetails";
            //string filteredActualAlertDetailsName = "Filtered_ActualAlertDetails";
            
            // Get the data table form of the details from the data query

           /// var expectedDetails = ConvertToDataTable.GenerateTable(this.alertDetails, expectedAlertDetailsName);


           /// Comparer comparer = new Comparer();
           /// comparer.AddTable(expectedDetails);
           /// comparer.Filter(expectedAlertDetailsName, this.filterExpected, "", filteredExpectedAlertDetailsName);

            // Get the DataTable form of the details from the UI
           // var actualDetails = DetailsPaneReader.Read(this.Details);
           /// actualDetails.TableName = actualAlertDetailsName;

           /// comparer.AddTable(actualDetails);
           /// comparer.Filter(actualAlertDetailsName, this.filterActual, "", filteredActualAlertDetailsName);


            // Compare expected and actual

          ///  comparer.Compare(filteredExpectedAlertDetailsName, filteredActualAlertDetailsName, this.columnMappings);


            #endregion

           // //Console.WriteLine("Verified the alert details");
        }

        //#region IObserver members

        //public void OnCompleted() {}

        //public void OnError(Exception error) {}

        //public void OnNext(dataAccess.IDataObject alert)
        //{
        //    //Console.WriteLine("A new alert has been selected");
        //    this.alertDetailsPresent = true;

        //    // Get the alert details
        //    LoadExpectedAlertDetails(alert);

        //    //Console.WriteLine("Got the alert details");
        //}

        //private void LoadExpectedAlertDetails(dataAccess.IDataObject alert)
        //{
        //    this.alertDetailsDisplayStringQuery.AlertProperties = this.projectionColumns;
        //    this.alertDetailsQuery.PropertyNameAndDisplayNamePairs = this.alertDetailsDisplayStringQuery.GetPropertyNameAndDisplayNamePairs();
        //    this.alertDetailsQuery.AlertId = (Guid)alert["Id"];
        //    this.alertDetails = this.alertDetailsQuery.GetAlertDetails();
        //}

        //#endregion
    }
}
