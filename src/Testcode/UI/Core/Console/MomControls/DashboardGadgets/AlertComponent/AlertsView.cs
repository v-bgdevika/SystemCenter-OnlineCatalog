using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.IO;
using Maui.Core;
using Microsoft.EnterpriseManagement.Monitoring;
using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
using Mom.Test.UI.Core.ResourceLoader;
using dataAccess = Microsoft.EnterpriseManagement.Presentation.DataAccess;
using System.Xml.Linq;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using Mom.Test.UI.Core.Common;
using System.Data;
using System.Reflection;
using Mom.Test.UI.Core.Console.Views.Alerts;
using Strings= Mom.Test.UI.Core.Console.Views.Alerts.AlertsView.Strings;
using Maui.Core.Utilities;
using Mom.Test.UI.Core.GenericDataQuery;

namespace Mom.Test.UI.Core.Console.MomControls.DashboardGadgets.AlertComponent
{

    /// <summary>
    /// Enum Options
    /// Contain options to launch Alert Properties
    /// Some other options will be added possibly
    /// </summary>
    /// <history>

    /// </history>
    public enum Options
    {
        /// <summary>
        /// 1. Right-click on item and select context menu
        /// </summary>
        RightClickContextMenuOption,

        /// <summary>
        /// 2. Double-click on item
        /// </summary>
        DoubleClickOption,

        /// <summary>
        /// 4. Actions in tasks pane
        /// </summary>
        TasksPaneActionOption
    }

    /// <summary>
    /// 
    /// </summary>
    public class AlertsView : DataGridViewHost, IObservable<dataAccess.IDataObject>
    {

        #region Private Members
        private Window content;
        private dataAccess.ObservableDataModel model = new dataAccess.ObservableDataModel();
        private int selectedAlert = -1;
        private List<string> selectedAlertRowData = null;
        //private IAlertsQuery query;
        private AlertPropertiesGeneralDialog cachedAlertPropertiesGeneralDialog = null;
        [Resource(ID = "ProjectionColumns")]
        private List<string> ProjectionColumns;
        #region AlertTask DisplayString
        [Resource(ID = "CloseAlertTask")]
        private string closeAlertTask;

        [Resource(ID = "SetResolutionTask")]
        private string setResolutionTask;

        [Resource(ID = "OpenHealthExporerTask")]
        private string openHealthExporerTask;

        [Resource(ID = "OpenAlertPropertyTask")]
        private string openAlertPropertyTask;
        # endregion
        #endregion

      
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<dataAccess.IDataObject> alerts = null;

        /// <summary>
        /// 
        /// </summary>
        public dataAccess.IDataObject displayStrings = null;

        /// <summary>
        /// 
        /// </summary>
        List<IObserver<dataAccess.IDataObject>> observers = new List<IObserver<dataAccess.IDataObject>>();
        /// <summary>
        /// 
        /// </summary>
        public FilterControl filter;
        /// <summary>
        /// 
        /// </summary>
        [Dependency]
        public dataAccess.IDataCommandContext DataContext { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> SelectedAlertRowData 
        {
            get
            {
                return this.DataGrid.GetSelectedRow();
            }          
        
        }
        /// <summary>
        /// 
        /// </summary>
        public int SelectedAlert
        {
            get
            {
                return selectedAlert;
            }
            private set
            {
                selectedAlert = value;
                this.Notify();
            }
        }

        //[Resource(ID = "GridHeaders")]
        //public string[] expectedColumnHeaders;

        [Resource(ID = "ColumnMapping")]
        public List<KeyValuePair<string, string>> columnMapping; // workaroundcolumn mapping
        
        /// <summary>
        /// Alert Properties Dialog
        /// General main tab.
        /// </summary>
        /// 
        public AlertPropertiesGeneralDialog alertPropertiesGeneralDialog
        {
            get
            {
                 if (this.cachedAlertPropertiesGeneralDialog == null)
                 {
                    this.cachedAlertPropertiesGeneralDialog = new AlertPropertiesGeneralDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Alert Properties General Dialog was successful");
                 }

                return this.cachedAlertPropertiesGeneralDialog;
            }
        }

      
        private IEnumerable<dataAccess.IDataObject> GetAlerts(Dictionary<string, object> properties)
        {
            using (var query = new Mom.Test.UI.Core.GenericDataQuery.GetAlertsForEntitiesQuery())
            {
                foreach (var property in properties)
                {
                    query.SetProperty(property.Key.ToString(), property.Value, false);
                }
                query.WaitUntilReady();

                // To get the localization string
                var value = query.GetProperty("DisplayStrings");
                int retry = 0;
                while (value == null && retry < 3)
                {
                    Sleeper.Delay(2000);
                    value = query.GetProperty("DisplayStrings");
                    retry++;
                }
                displayStrings = value as dataAccess.IDataObject;

                return query.GetProperty("Output") as IEnumerable<dataAccess.IDataObject>;
            }
        }

        public static dataAccess.IDataObject GetLocDisplayString(List<string> properties)
        {
            using (var query = new Mom.Test.UI.Core.GenericDataQuery.GetAlertsForEntitiesQuery())
            {
                query.SetProperty("AlertProperties", properties, false);

                /*int retries = 0;
                while (retries < Constants.DefaultMaxRetry * 25)
                {
                    try
                    {
                        query.WaitUntilReady();
                        Utilities.LogMessage("GetLocDisplayString::WaitUntilReady: Finished");
                        break;
                    }
                    catch (Exception)
                    {
                        Utilities.LogMessage("GetLocDisplayString::WaitUntilReady: Found exception. Try again.");
                        retries++;

                        if (retries == Constants.DefaultMaxRetry * 25)
                        {
                            throw;   
                        }
                    }
                }
                */
                // To get the localization string
                var value = query.GetProperty("DisplayStrings");
                int retry = 0;
                while (value == null && retry < 3)
                {
                    Sleeper.Delay(2000);
                    value = query.GetProperty("DisplayStrings");
                    retry++;
                }
                //displayStrings = value as dataAccess.IDataObject;

                return value as dataAccess.IDataObject;
            }
        }
        private string GetLocDisplayString(string key)
        {
            return displayStrings[key] as string;
        }

        //Temporary Method to API testing
        public static IEnumerable<dataAccess.IDataObject> GetAlerts1(Dictionary<string, object> properties)
        {
            using (var query = new Mom.Test.UI.Core.GenericDataQuery.GetAlertsForEntitiesQuery())
            {
                foreach (var property in properties)
                {
                    query.SetProperty(property.Key.ToString(), property.Value, false);
                }
                query.WaitUntilReady();
                // To get the localization string
                var value = query.GetProperty("DisplayStrings");
                var displayStrings = value as dataAccess.IDataObject;


                return query.GetProperty("Output") as IEnumerable<dataAccess.IDataObject>;
            }
        }
      
        /// <summary>
        /// Used while pivioting from summary dashboard to node/interface dashboard where Idataobject Id property
        /// is the Target context passed to the dashboards
        /// </summary>
        /// <param name="knownWindow"></param>
        /// <param name="query"></param>
        /// <param name="resource"></param>
        // To do "update this method to take in Idataobject target.id"
        public AlertsView(Window knownWindow, Dictionary<string, object> properties, XElement resource)
            : base(knownWindow)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var stream = new StreamReader(assembly.GetManifestResourceStream("Mom.Test.UI.Core.Console.MomControls.DashboardGadgets.AlertComponent.AlertComponentResource.xml"));
            XDocument AlertComponentxdocument = XDocument.Load(stream);
            XElement EmbemdedAlertComponentResource = ResourceLoader.ResourceLoader.GetSection("AlertComponentTask", AlertComponentxdocument);
            ResourceLoader.ResourceLoader.LoadResources(this, EmbemdedAlertComponentResource);

            ResourceLoader.ResourceLoader.LoadResources(this, resource);
           
            filter = new FilterControl(knownWindow);
            
            this.alerts = this.GetAlerts(properties);

            // update selected alert
            if (this.alerts != null && this.alerts.Count() > 0)
            {
                this.SelectedAlert = 0;
            }
        }

        /// <summary>
        /// used while pivioting from any of the network device view to node/interface dashboard
        /// Where monitoringObject is the target context passed to the dashboard
        /// </summary>
        /// <param name="knownWindow"></param>
        /// <param name="node"></param>
        /// <param name="query"></param>
        /// <param name="resource"></param>
        public AlertsView(Window knownWindow, MonitoringObject node, XElement resource)//IAlertsQuery query, )
            : base(knownWindow)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var stream = new StreamReader(assembly.GetManifestResourceStream("Mom.Test.UI.Core.Console.MomControls.DashboardGadgets.AlertComponent.AlertComponentResource.xml"));
            XDocument AlertComponentxdocument = XDocument.Load(stream);
            XElement EmbemdedAlertComponentResource = ResourceLoader.ResourceLoader.GetSection("AlertComponentTask", AlertComponentxdocument);
            ResourceLoader.ResourceLoader.LoadResources(this, EmbemdedAlertComponentResource);
            
            ResourceLoader.ResourceLoader.LoadResources(this, resource);
            filter = new FilterControl(knownWindow);
            
            //this.query = query;

            // Set the properties
            //this.query.ProjectionColumns = this.ProjectionColumns;
           // this.query.TargetId = node.Id;

            // To Do  Instead of this call into Query Compoment Method To Passing in the GetTargetdAlertData Query Compoment And Parameters
           // this.alerts = this.query.GetAlerts();

            // update selected alert
            //if (this.alerts.Count() > 0)
            //{
            //    this.SelectedAlert = 0;
            //}

            // //Console.WriteLine("Initialized the alerts view for the node: " + node.DisplayName);
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="knownWindow"></param>
        /// <param name="node"></param>
        /// <param name="query"></param>
        /// <param name="resource"></param>
        public AlertsView(Window knownWindow, XElement resource)
            : base(knownWindow)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var stream = new StreamReader(assembly.GetManifestResourceStream("Mom.Test.UI.Core.Console.MomControls.DashboardGadgets.AlertComponent.AlertComponentResource.xml"));
            XDocument AlertComponentxdocument = XDocument.Load(stream);
            XElement EmbemdedAlertComponentResource = ResourceLoader.ResourceLoader.GetSection("AlertComponentTask", AlertComponentxdocument);
            ResourceLoader.ResourceLoader.LoadResources(this, EmbemdedAlertComponentResource);
            ResourceLoader.ResourceLoader.LoadResources(this, resource);
            filter = new FilterControl(knownWindow);
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowId"></param>
        public void SelectHeathExplorer(Options alertOptions,int rowId)
        {
            // it assmumes that alert to close is already selected
            try
            {
                Utilities.LogMessage("AlertView.SelectHeathExplorer:: Close alert ");
                int selectRow = this.selectedAlert; ;
                if (this.DataGrid.RowsExtended.Count >= 1)
                {
                    Utilities.LogMessage("AlertView.LaunchAlertProperties :: column position:");

                    //if selected row is not same as row to close select that row
                    if (selectedAlert != rowId)
                        this.SelectAlert(rowId);
                    var viewGrid = this.DataGrid;

                    switch (alertOptions)
                    {
                        case Options.RightClickContextMenuOption:
                            viewGrid.SelectRow(selectRow);
                            CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
                            CoreManager.MomConsole.ExecuteContextMenu(openHealthExporerTask, true);

                            Utilities.LogMessage("AlertView.SelectHeathExplorer :: HeathExplorer link Successfully clicked ");

                            break;

                        case Options.TasksPaneActionOption:
                            
                            viewGrid.SelectRow(selectRow);
                            CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
                            ActionsPane alertActionsPane = new ActionsPane(CoreManager.MomConsole);
                            //alertActionsPane.ClickLink("Tasks", "Health Explorer");
                            alertActionsPane.ClickLink(Console.Tasks.Tasks.Strings.TasksActionPane, openHealthExporerTask);
                            CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, Constants.OneMinute);

                            Utilities.LogMessage("AlertView.SelectHeathExplorer :: HeathExplorer link Successfully clicked ");
                            break;

                        default:

                            Utilities.LogMessage("AlertView.SelectHeathExplorer :: " +
                                "Invalid option to open HealthExplorer was passed");

                            break;
                    }

                }
            }
            catch (Exception e)
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alertOptions"></param>
        /// <param name="rowId"></param>
        public void SelectCloseAlert(Options alertOptions, int rowId)
        {
            // it assmumes that alert to close is already selected
            try
            {
                Utilities.LogMessage("AlertView.CloseAlert:: Close alert ");

                int selectRow = this.selectedAlert;
                if (this.DataGrid.RowsExtended.Count >= 1)
                {
                    //if selected row is not same as row to close select that row
                    if (selectedAlert != rowId)
                        this.SelectAlert(rowId);

                    Utilities.LogMessage("AlertView.CloseAlert ::  Executing " + alertOptions + " to colse alert");

                var viewGrid = this.DataGrid;

                // Switch options to launch Alert Properties
                switch (alertOptions)
                {
                    case Options.RightClickContextMenuOption:
                        viewGrid.SelectRow(selectRow);
                        CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
                        CoreManager.MomConsole.ExecuteContextMenu(closeAlertTask, true);
                        Utilities.LogMessage("AlertView.SelectCloseAlert :: " +
                            "SelectCloseAlertPropertiesViaRightClick is done");

                        break;

                    case Options.TasksPaneActionOption:
                        viewGrid.SelectRow(selectRow);
                        CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
                        ActionsPane alertActionsPane = new ActionsPane(CoreManager.MomConsole);
                     //alertActionsPane.ClickLink("Tasks", "Close Alert");
                        alertActionsPane.ClickLink(Console.Tasks.Tasks.Strings.TasksActionPane, closeAlertTask);
                        CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
                        Utilities.LogMessage("AlertView.SelectCloseAlert :: " +
                            "SelectCloseAlertPropertiesViaTasksPaneClick");

                        break;

                    default:

                        Utilities.LogMessage("AlertView.SelectCloseAlert:: " +
                            "Invalid option to Close Alert Properties was passed");

                            break;
                    } // end switch
                    Utilities.LogMessage("AlertView.CloseAlert ::  Successfully clicked ");
                }
            }
            catch (Exception e)
            {
            }
        }

        /// <summary>
        /// Method to launch Alert Properties dialog via option specified
        /// </summary>
        /// <param name="alertOptions">Option to launch dialog via R-click, D-clik, Main Manu or Tasks pane</param>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">
        /// if alert row is not found or if there's no alerts in the grid control
        /// </exception>
        /// <history>
        /// </history>
        public void SelectAlertProperties(
            Options alertOptions, int rowId)
        {
            Utilities.LogMessage("AlertsView.GetAlertProperties :: Create instance of grid control");

            // Create instance of Alert View Grid Control
            var viewGrid = this.DataGrid;

            int selectRow = this.selectedAlert;
            if (this.DataGrid.RowsExtended.Count >= 1)
            {
                Utilities.LogMessage("AlertView.LaunchAlertProperties :: column position:");

                // Wait one second before executing command
                //if selected row is not same as row to close select that row
                if (selectedAlert != rowId)
                    this.SelectAlert(rowId);

                // Switch options to launch Alert Properties
                switch (alertOptions)
                {
                    case Options.RightClickContextMenuOption:
                        // 1. R-click on alert and select context menu                             
                        // row.Click();
                        viewGrid.SelectRow(selectRow);
                        CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
                        CoreManager.MomConsole.ExecuteContextMenu(openAlertPropertyTask.Replace(" ", ""), true);
                        //Add retry to work around test bug 553295
                        int retry = 1;
                        int maxRetry = Constants.DefaultMaxRetry;                        
                        while (retry < maxRetry)
                        {
                            try
                            {                                
                                if (this.alertPropertiesGeneralDialog.IsVisible && this.alertPropertiesGeneralDialog.IsEnabled)
                                {
                                    break;
                                }
                                retry++;
                                CoreManager.MomConsole.ExecuteContextMenu(openAlertPropertyTask.Replace(" ", ""), true);
                            }
                            catch (Exceptions.WindowNotFoundException ex)
                            {
                                if (retry == maxRetry)
                                {
                                    Utilities.LogMessage("AlertView.LaunchAlertProperties :: " +
                                "Failed LaunchAlertPropertiesViaRightClick after operate "+ maxRetry +" times");
                                    Utilities.TakeScreenshot("FailedLaunchAlertPropertiesViaRightClick");

                                    new Infra.Frmwrk.VarFail("Failed Launch Alert Properties By Right-Click. Exception Information:" + ex);
                                }
                            }
                        }
                        Utilities.TakeScreenshot("SuccessLaunchAlertPropertiesViaRightClick");
                        Utilities.LogMessage("AlertView.LaunchAlertProperties :: " +
                            "Success LaunchAlertPropertiesViaRightClick after operate " + retry + " times");
                        break;
                    case Options.DoubleClickOption:
                        //TODO implement double click
                        viewGrid.SelectRow(selectRow);
                        CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
                        viewGrid.RowsExtended[selectRow].ScreenElementExtended.DoubleClick(-1, -1, true, KeyboardFlags.NoFlag);
                        Utilities.LogMessage(
                            "AlertView.LaunchAlertProperties :: " +
                            "LaunchAlertPropertiesViaDoubleClick is done");
                        break;
                    case Options.TasksPaneActionOption:
                        viewGrid.SelectRow(selectRow);
                        ActionsPane alertActionsPane = new ActionsPane(CoreManager.MomConsole);
                       // alertActionsPane.ClickLink("Tasks", "Alert Properties");
                        alertActionsPane.ClickLink(Console.Tasks.Tasks.Strings.TasksActionPane, openAlertPropertyTask);
                        Utilities.LogMessage("AlertView.LaunchAlertProperties :: " +
                            "LaunchAlertPropertiesViaTasksPaneClick");

                        break;
                    default:
                        Utilities.LogMessage("AlertView.LaunchAlertProperties:: " +
                            "Invalid option to launch Alert Properties was passed");
                        break;
                } // end switch

                // Now set focus on the 1st screen of the dialog
                //this.alertPropertiesGeneralDialog.Extended.SetFocus();

                //this.alertPropertiesGeneralDialog.Controls.GeneralTabControl[Strings.General].Select();

                // Take a screenshot
                Utilities.TakeScreenshot("LaunchedAlertPropertiesViaOptionProvided");
            } // end if 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowId"></param>
        public void SelectAlert(int rowId)
        {
            if (rowId == -1)
            {
                throw new Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException("row id is -1");
            }

            if (rowId != null && rowId != -1)
            {
                Utilities.LogMessage("Looking For DataGrid RowId: " + rowId);
                this.ScreenElement.EnsureVisible();
                this.DataGrid.SelectRow(rowId);
                this.SelectedAlert = rowId;
                Utilities.LogMessage("Selected row: " + rowId);
            }
        }

        //public bool VerifyTitle() // add a bool incase filter is applied to datagrid for verify
        //{
        //   // this.WaitForReady();

        //    #region Verify Title

        //    string actTitleText = this.Title.Text;
        //    if (this.expectedTitleText != actTitleText)
        //    {
        //        Utilities.LogMessage("Titles mismatch. " +
        //            "Expected: " + this.expectedTitleText +
        //            "Actual: " + actTitleText);
        //        //throw new Exception("Titles mismatch. " +
        //        //    "Expected: " + this.expectedTitleText +
        //        //    "Actual: " + actTitleText
        //        //);
        //        return false ;
        //    }

        //    return true;
        //     #endregion
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool VerifyFilter() // add a bool incase filter is applied to datagrid for verify
        {
            List<List<string>> actRowData = DataGridControlExtensions.GetRowData(this.DataGrid);//this.DataGrid.GetRowData();
            DataGridControlExtensions.GetColumHeaders(this.DataGrid);
            string filter = "";// this.filter.FilterTextBox.Text.ToString().Trim();
            if (this.filter.FilterTextBox.IsVisible)
            {
                filter = this.filter.FilterTextBox.Text.ToString().Trim();
            }
            else
            {
                this.SendKeys(KeyboardCodes.Ctrl + "F");
                Sleeper.Delay(1000);
                filter = this.filter.FilterTextBox.Text.ToString().Trim();
            }
            if (filter != "" && filter != "Filter")
            { 
                // verify that atleast one column in each row has the value in filter.
                for (int i = 0; i < actRowData.Count(); i++)
                {
                    bool found = false;
                    List<string> actualValues = actRowData[i];
                    foreach(var columnValue in actualValues)
                    {
                        if (columnValue != null && columnValue.Contains(filter))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                        return false;
                    
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Verify()
        {
            string currentMethodName = MethodBase.GetCurrentMethod().Name;

            List<List<string>> actRowData = DataGridControlExtensions.GetRowData(this.DataGrid);//this.DataGrid.GetRowData();
            Utilities.LogMessage(currentMethodName + ":: Row count " + actRowData.Count);
            for (int i = 0; i < actRowData.Count(); i++)
            {
                dataAccess.IDataObject monitoringAlert = alerts.ElementAt(i);

                List<string> actualValues = actRowData[i];

                // Verify each row
                foreach (var entry in this.columnMapping)
                {
                    string expected = monitoringAlert[entry.Key] as string;
                    Utilities.LogMessage(expected);
                    // get loc value
                    string val = this.GetLocDisplayString(entry.Key);
                    Utilities.LogMessage(val);
                    int index = this.DataGrid.GetColumnIndex(val);
                    Utilities.LogMessage(index.ToString());

                    string actual = String.Empty; 
                    switch (ProductSku.Sku) 
                    { 
                        case ProductSkuLevel.Mom: 
                             actual = actualValues[index]; 
                             break; 
                        case ProductSkuLevel.Web: 
                             actual = actualValues[index - 1]; 
                             break; 
                        default: 
                            break; 
                    } 


                    Utilities.LogMessage(actual);

                    if (expected != actual)
                    {
                        Utilities.LogMessage(currentMethodName + ":: Data Error. Expected: " + expected + " Actual: " + actual);
                        return false;
                    }
                }
            }

            return true;
        }

        public bool VerifyAlertProperties(List<string> columns,List<string> selectedRow)
        {
           // var selectedRow = this.DataGrid.GetSelectedRow();
            Utilities.LogMessage("Starting VerifyAlertProperties ");
            this.alertPropertiesGeneralDialog.Extended.SetFocus();
            
            //AlertPropertiesGeneralDialog ag = new AlertPropertiesGeneralDialog(CoreManager.MomConsole);

            Utilities.LogMessage("Source Actual: " + this.alertPropertiesGeneralDialog.Controls.SourceContentStaticControl.Text + " expected " + selectedRow[columns.IndexOf("Name")]);
            if (this.alertPropertiesGeneralDialog.Controls.SourceContentStaticControl.Text != selectedRow[columns.IndexOf("Source")])
            {
                this.alertPropertiesGeneralDialog.ClickOK();
                return false;
            }

            if (this.alertPropertiesGeneralDialog.Controls.ServiceRunningStateStaticControl.Text != selectedRow[columns.IndexOf("Name")])
            {
                this.alertPropertiesGeneralDialog.ClickOK();
                return false;
            }


            this.alertPropertiesGeneralDialog.ClickOK();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>bool</returns>
        public bool VerifyHeathExplorer(string Source)
        {
            bool result = false;

            Utilities.LogMessage("VerifyHeathExplorer:: Source:" + Source);

            Core.Console.Views.State.HealthExplorerDialog healthDialog =
    new Mom.Test.UI.Core.Console.Views.State.HealthExplorerDialog(CoreManager.MomConsole);

            if (healthDialog.Caption.ToLower().Contains(Source.ToLower()))
            {
                result = true;
            }

            Utilities.TakeScreenshot("VerifyHeathExplorer");
            healthDialog.ClickTitleBarClose();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        public void VerifyResolutionState()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="verify"></param>
        /// <returns>bool</returns>
        public bool verifyCloseAlert(Dictionary<string, string> verify)
        {
            // neviage it again to refresh the screen
            if (this.DataGrid.GetRowIndex(verify) == -1)
            {
                return true;
            }

            return false;

        }


        
        private void Notify()
        {
            dataAccess.IDataObject currentAlert = this.alerts.ElementAt(this.SelectedAlert);
            foreach (var observer in this.observers)
            {
                observer.OnNext(currentAlert);
            }
        }

        #region IObservable members

        public IDisposable Subscribe(IObserver<dataAccess.IDataObject> observer)
        {
            
            this.observers.Add(observer);

            // notify of the current selection
            if (this.SelectedAlert != -1)
            {
                observer.OnNext(this.alerts.ElementAt(this.SelectedAlert));
            }

            return null;
        }

        #endregion
    }

}
