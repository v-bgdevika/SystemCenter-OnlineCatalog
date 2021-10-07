//  -----------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Monitors.cs">
//     Copyright ?Microsoft 2005
// </copyright>
// <project>
//     Mom.Test.UI.Core.Console.MonitoringConfiguration
// </project>
// <summary>
//     This class contains helper functions for automation of the 
//     configuration of Monitors. 
// </summary>
// <history>
//      [barryw] 12/16/2005 15:33:41 Created
//      [ruhim]  13Jan06    Moved the file under Monitoring Configuration namespace  
//      [ruhim]  22Jun06    Added SelectMonitorType method
//      [ruhim]  19July06   Added overloaded SelectTargetMonitor method to take in a grid view refrence       
//      [ruhim]  19July06   Updated SelectTargetMonitor method to account for the fact 
//                          that if the monitor rows are collapsed then the initial row count 
//                          taken will be incorrect and needs to be updated as and when rows are expanded
// </history>
//  -----------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MonitoringConfiguration
{
    #region Using directives

    using System;
    using System.Text;
    using System.Xml;
    using System.Xml.XPath;
    using System.Xml.Schema;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Reflection;

    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
    using Microsoft.EnterpriseManagement.Configuration;
    using Mom.Test.UI.Core.Console.Views.HealthConfiguration;        
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs;
    using Microsoft.EnterpriseManagement.Mom.Internal;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Performance.Dialogs;
    #endregion

    /// <summary>
    /// Class to assist test automation related to Monitors.
    /// </summary>
    public class Monitors
    {
        #region Constants

        string monitorsPath = NavigationPane.Strings.MonitoringConfiguration
                   + Constants.PathDelimiter
                   + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects
                   + Constants.PathDelimiter
                   + Core.Console.Views.Views.Strings.HealthView;

        #region MonitorType Constants
        private const string WindowsEventsSimpleEventDetectionManualReset = "WindowsEventsSimpleEventDetectionManualReset";

        private const string WindowsEventsSimpleEventDetectionWindowsEventReset = "WindowsEventsSimpleEventDetectionWindowsEventReset";

        private const string WindowsEventsSimpleEventDetectionTimerReset = "WindowsEventsSimpleEventDetectionTimerReset";

        private const string WindowsEventsCorrelatedEventDetectionManualReset = "WindowsEventsCorrelatedEventDetectionManualReset";

        private const string WindowsEventsCorrelatedEventDetectionTimerReset = "WindowsEventsCorrelatedEventDetectionTimerReset";

        private const string WindowsEventsCorrelatedEventDetectionEventReset = "WindowsEventsCorrelatedEventDetectionEventReset";

        private const string WindowsEventsCorrelatedMissingEventDetectionManualReset = "WindowsEventsCorrelatedMissingEventDetectionManualReset";

        private const string WindowsEventsCorrelatedMissingEventDetectionTimerReset = "WindowsEventsCorrelatedMissingEventDetectionTimerReset";

        private const string WindowsEventsCorrelatedMissingEventDetectionEventReset = "WindowsEventsCorrelatedMissingEventDetectionEventReset";

        private const string WindowsEventsMissingEventDetectionManualReset = "WindowsEventsMissingEventDetectionManualReset";

        private const string WindowsEventsMissingEventDetectionTimerReset = "WindowsEventsMissingEventDetectionTimerReset";

        private const string WindowsEventsMissingEventDetectionEventReset = "WindowsEventsMissingEventDetectionEventReset";

        private const string WindowsEventsRepeatedEventDetectionManualReset = "WindowsEventsRepeatedEventDetectionManualReset";

        private const string WindowsEventsRepeatedEventDetectionTimerReset = "WindowsEventsRepeatedEventDetectionTimerReset";

        private const string WindowsEventsRepeatedEventDetectionEventReset = "WindowsEventsRepeatedEventDetectionEventReset";

        private const string WMIEventSingleManualReset = "WMIEventSingleManualReset";

        private const string WMIEventSingleTimerReset = "WMIEventSingleTimerReset";

        private const string WMIEventSingleWMIEventReset = "WMIEventSingleWMIEventReset";

        private const string WMIEventRepeatedManualReset = "WMIEventRepeatedManualReset";

        private const string WMIEventRepeatedTimerReset = "WMIEventRepeatedTimerReset";

        private const string WMIEventRepeatedWMIEventReset = "WMIEventRepeatedWMIEventReset";

        private const string WMIPerformanceAverageThreshold = "WMIPerformanceAverageThreshold";

        private const string WMIPerformanceConsecutiveSamplesoverThreshold = "WMIPerformanceConsecutiveSamplesoverThreshold";

        private const string WMIPerformanceDeltaThreshold = "WMIPerformanceDeltaThreshold";

        private const string WMIPerformanceSimpleThreshold = "WMIPerformanceSimpleThreshold";

        private const string WMIPerformanceDoubleThreshold = "WMIPerformanceDoubleThreshold";

        private const string WindowsPerformance2StateAboveThreshold = "WindowsPerformance2StateAboveThreshold";

        private const string WindowsPerformance2StateBaseliningThreshold = "WindowsPerformance2StateBaseliningThreshold";

        private const string WindowsPerformance2StateBelowThreshold = "WindowsPerformance2StateBelowThreshold";

        private const string WindowsPerformance3StateBaseliningThreshold = "WindowsPerformance3StateBaseliningThreshold";

        private const string WindowsPerformanceAverageThreshold = "WindowsPerformanceAverageThreshold";

        private const string WindowsPerformanceConsecutiveSamplesoverThreshold = "WindowsPerformanceConsecutiveSamplesoverThreshold";

        private const string WindowsPerformanceDeltaThreshold = "WindowsPerformanceDeltaThreshold";

        private const string WindowsPerformanceSimpleThreshold = "WindowsPerformanceSimpleThreshold";

        private const string WindowsPerformanceDoubleThreshold = "WindowsPerformanceDoubleThreshold";

        //Schema file for event monitor config XML file
        private const string EventMonitorSchema = "..\\Common\\EventMonitor_TestData.xsd";

        //Schema file for xml fragment for a single event monitor config
        private const string EventMonitorFragmentSchema = "..\\Common\\EventMonitor_TestDataFragment.xsd";

        private const string SDKCarriageReturn = "\n";

        //If SDK has \n in the alert description string then UI destrin text shows it as \r\n
        private const string UICarriageReturn = "\r\n";
        #endregion

        #endregion

        #region Member variables

        /// <summary>
        /// Events dialog automation helper object.
        /// </summary>
        private Events.Events events = new Events.Events();

        /// <summary>
        /// Generate Random String Based of User Local
        /// </summary>
        RandomStrings randomNames = new RandomStrings();

        /// <summary>
        /// Minimum length for Monitor Display Name
        /// </summary>
        private int minNameLength = 1;

        /// <summary>
        /// Minimum length for Monitor Description
        /// </summary>
        private int minDescriptionLength = 0;

        /// <summary>
        /// Maximum length for Monitor Display Name
        /// </summary>
        private int maxNameLength = 150; //TODO: Change maxlength as per the spec

        /// <summary>
        /// Maximum length for Monitor Description
        /// </summary>
        private int maxDescriptionLength = 450; //TODO: Change maxlength as per the spec 
        
        #endregion             

        #region  Constructors 

        /// <summary>
        /// Constructor for Monitors class.
        /// </summary>
        public Monitors()
        {
            // This prevents the creation of a default constructor
        }

        #endregion

        #region Properties

        #endregion             

        #region Public methods

        /// <summary>
        /// Method to select a particular Monitor row in the Monitors view
        /// for a specifed Target only. It will select the first matching Monitor row and return its row index
        /// </summary>
        /// <param name="targetName">Class where the monitor is targetted</param>                
        /// <param name="monitorName">Aggregate/Dependency/Unit monitor name that you want to select</param>                
        /// <returns>Row index</returns>
        /// <exception cref="Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException">DataGridViewRowNotFoundException</exception>
        /// <history>
        /// [ruhim] 20MAR06 - Created  
        /// [v-vijia] 29MAR11 - Edited
        /// </history>
        // <exception cref="Maui.Core.WinControls.DataGridView.Exceptions.WindowNotFoundException">WindowNotFoundException</exception> 
        public int SelectTargetMonitor(string targetName, string monitorName)
        {            
            #region Navigate to Monitors View

                Utilities.LogMessage("NavigateToMonitorsView(...)");
                CoreManager.MomConsole.BringToForeground();

                // Select the Monitoring Configuration wunderbar
                NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);

                // search the View
                Core.Console.MomControls.GridControl viewGrid = null;
                int retry = 0;
                int maxcount = 120;

                while (viewGrid == null && retry <= maxcount)
                {
                    try
                    {
                        // Select Monitors view
                        navPane.SelectNode(monitorsPath ,NavigationPane.NavigationTreeView.MonitoringConfiguration);

                        CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);

                        viewGrid = CoreManager.MomConsole.ViewPane.Grid;
                        //Wait for grid view loading ready, bug#211398
                        viewGrid.WaitForRowsLoaded();
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: Failed to get reference to ViewPane.Grid, lets navigate and try again.");
                        Utilities.TakeScreenshot("Monitors.SelectTargetMonitor_GridView_NotFound");
                    }
                    catch (System.NullReferenceException)
                    {
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: Got a null reference, lets try again.");
                        Utilities.TakeScreenshot("Monitors.SelectTargetMonitor_NullExpection");
                    }
                    retry++;
                }
                //Select Monitors under Management Pack Objects               
                Utilities.LogMessage("Monitors.SelectTargetMonitor:: Successfully selected Monitors View Grid under Monitoring Configuration space");                                           

                #endregion

                // Declaring variables for target and monitor row indexes                 
                int rowposMonitor = -1;

                try
                {
                    viewGrid = this.RetryViewGridReference(viewGrid, 3);
                    rowposMonitor = SelectTargetMonitor(viewGrid, targetName, monitorName);
                }
                catch (DataGridView.Exceptions.DataGridViewRowNotFoundException)
                {
                        CoreManager.MomConsole.ViewPane.ChangeConsoleScope(new ViewPane.TargetType[] { new ViewPane.TargetType(targetName, targetName, true) }, true, 3);
                        viewGrid = this.RetryViewGridReference(viewGrid, 3);
                        rowposMonitor = SelectTargetMonitor(viewGrid, targetName, monitorName);
                }

            
            return rowposMonitor;           
        }

        /// <summary>
        /// Method to select a particular Monitor row in the specified GridView
        /// for a specifed Target only. It will select the first matching Monitor row and return its row index
        /// </summary>
        /// <param name="viewGrid">Reference to the Grid Control</param>                
        /// <param name="targetName">Class where the monitor is targetted</param>                
        /// <param name="monitorName">Aggregate/Dependency/Unit monitor name that you want to select</param>                
        /// <returns>Row index</returns>
        /// <exception cref="Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException">DataGridViewRowNotFoundException</exception>
        /// <history>
        /// [ruhim] 20MAR06 - Created        
        /// </history>
        // <exception cref="Maui.Core.WinControls.DataGridView.Exceptions.WindowNotFoundException">WindowNotFoundException</exception> 
        public int SelectTargetMonitor(Core.Console.MomControls.GridControl viewGrid,string targetName, string monitorName)
        {
            // Declaring variables for target and monitor row indexes 
            int rowposTarget = -1;
            int rowposMonitor = -1;
            if (viewGrid != null)
            {
                Utilities.LogMessage(string.Format("Monitors.SelectTargetMonitor:: ViewGrid Found - Now Look up the Target '{0}', Monitor '{1}'", targetName, monitorName));
                //viewGrid = this.RetryViewGridReference(viewGrid, 3);
                int colpos = -1;
                Maui.Core.WinControls.DataGridViewRowCollection myRows = null;
                int rowCount = 0;
                string cellValue = null;
                int retry = 0;
                int maxcount = 10;
                bool foundValidRef = false;
                while (foundValidRef == false && retry <= maxcount)
                {
                    try
                    {
                        // Get the Index position of the Column of 'Name'
                        colpos = viewGrid.GetColumnTitlePosition(HealthConfigurationView.Strings.NameHeaderHealthView);
                        //Cache the rows to address timing issue
                        myRows = viewGrid.Rows;
                        rowCount = myRows.Count;
                        cellValue = null;

                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: Number of grid rows:  " + rowCount);
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: Column Position for Name header:  " + colpos);
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: Reseting grid scroll window to top...");
                        viewGrid.Click();
                        viewGrid.SendKeys(KeyboardCodes.F5);
                        viewGrid.SendKeys(KeyboardCodes.Ctrl + "(" + KeyboardCodes.Home + ")");
                        foundValidRef = true;
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: should not throw InvalidHWndException after this");
                    }
                    catch (Maui.Core.Window.Exceptions.InvalidHWndException)
                    {

                        CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);

                        viewGrid = CoreManager.MomConsole.ViewPane.Grid;
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: Failed to get valid reference to ViewGrid, lets navigate and try again.");
                        Utilities.TakeScreenshot("Monitors.SelectTargetMonitor_ViewGrid_HWndInvalid");
                    }
                    retry++;
                }

                #region Find the target row

                // iterate through each row

                //NOTE: Due to Maui ListView Get_item call rowIndex =0 and 
                //rowIndex = rowCount. Both throw ArgumentOutOfRange Exception
                //hence using this method the last row in the grid cannot be accessed
                for (int rowIndex = 1; rowIndex < rowCount; rowIndex++)
                {
                    #region Make Row And Cell Visible
                    //viewGrid.ScrollToRow(myRows[rowIndex], rowIndex, rowCount);

                    //Utilities.LogMessage("Monitors.SelectTargetMonitor:: rowIndex.StateText: " + myRows[rowIndex].AccessibleObject.StateText);
                    //if (myRows[rowIndex].AccessibleObject.StateText.Contains(MsaaStates.Collapsed.ToString().ToLowerInvariant()))
                    //{
                    //    Utilities.LogMessage("Monitors.SelectTargetMonitor:: Expand Row");
                    //    myRows[rowIndex].AccessibleObject.DoDefaultAction();
                    //}
                    #endregion // Make Row And Cell Visible

                    #region Perform Text Matching

                    int retryGet = 0;
                    int maxretry = 5;
                    bool getValue = false;

                    while (getValue == false && retryGet <= maxretry)
                    {
                        try
                        {
                            cellValue = myRows[rowIndex].Cells[colpos].GetValue(); //viewGrid.GetCellValue(rowIndex, colpos).ToString();
                            Utilities.LogMessage("Monitors.SelectTargetMonitor:: Current cellvalue : " + cellValue);
                            getValue = true;
                        }
                        catch (System.ArgumentOutOfRangeException)
                        {
                            Utilities.LogMessage("Monitors.SelectTargetMonitor:: Not get correct value, throw ArgumentOutOfRangeException here, try to get cell value again, retry times: " + retryGet.ToString());
                            getValue = false;

                            Sleeper.Delay(Core.Common.Constants.OneSecond);
                        }

                        retryGet++;
                    }

                    if (string.Compare(cellValue, targetName) == 0)
                    {
                        rowposTarget = rowIndex;
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: Target found at row index " + rowposTarget);
                        //dataGridRow = viewGrid.Rows[rowposTarget];

                        // Click the 2nd Cell.  Seems the only way to get the correct AA State out of the grid.
                        viewGrid.ScrollToRow(rowIndex);                        
                        myRows[rowIndex].Cells[1].AccessibleObject.DoDefaultAction();
                        
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: rowIndex.StateText: " + myRows[rowIndex].AccessibleObject.StateText);
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: MsaaResources.Strings.Collapsed: " + MsaaResources.Strings.Collapsed.ToLowerInvariant());
                        if (myRows[rowIndex].AccessibleObject.StateText.Contains(MsaaResources.Strings.Collapsed.ToLowerInvariant()))
                        {
                            Utilities.LogMessage("Monitors.SelectTargetMonitor:: Expand Row");
                            myRows[rowIndex].AccessibleObject.DoDefaultAction();
                        }
                        else
                        {
                            Utilities.LogMessage("Monitors.SelectTargetMonitor:: rowIndex.StateText doesn't contain MsaaResources.Strings.Collapsed");
                        }

                        break;
                    }
                    else
                    {
                        // move the highlight to the next row
                        viewGrid.SendKeys(KeyboardCodes.DownArrow);
                    }
                    #endregion // Perform Text Matching


                    //Utilities.LogMessage("Monitors.SelectTargetMonitor:: rowIndex.StateText: " + myRows[rowIndex].AccessibleObject.StateText);
                    //if (myRows[rowIndex].AccessibleObject.StateText.Contains(MsaaStates.Collapsed.ToString().ToLowerInvariant()))
                    //{
                    //    Utilities.LogMessage("Monitors.SelectTargetMonitor:: Expand Row");
                    //    myRows[rowIndex].AccessibleObject.DoDefaultAction();
                    //}

                    //If the rows are collapsed initially we get incorrect row count
                    if (rowIndex == (rowCount - 1))
                    {
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: Hit the last row count - Lets get the row count once more.");
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: Original row count: " + rowCount.ToString());
                        if (rowCount != viewGrid.Rows.Count)
                        {
                            rowCount = viewGrid.Rows.Count;
                            myRows = viewGrid.Rows;
                        }
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: New row count: " + rowCount.ToString());
                    }
                }

                #region Find Monitor row

                cellValue = null;
                //Once the target row is found find the monitor
                //if (dataGridRow != null)
                if (rowposTarget != -1)
                {
                    //This is only is the target is the last target in the monitors view
                    if (rowposTarget == (rowCount - 1))
                    {
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: Hit the last row count - Lets get the row count once more..");
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: Original row count: " + rowCount.ToString());
                        if (rowCount != viewGrid.Rows.Count)
                        {
                            rowCount = viewGrid.Rows.Count;
                            myRows = viewGrid.Rows;
                        }
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: New row count: " + rowCount.ToString());
                    }

                    //Count of the number of times "Entity Health Monitor" is found
                    int foundEntityHealth = 0;

                    //Keep looking for the monitor untill you reach the last row or you find 
                    //the next "Entity Health Monitor" indicating you hit the next target                        
                    while ((rowposTarget < rowCount) && (foundEntityHealth <= 1))
                    {
                        #region Make Row And Cell Visible
                        //viewGrid.ScrollToRow(myRows[rowposTarget], rowposTarget, rowCount);

                        //Bug#201923
                        int maxRetry = Constants.DefaultMaxRetry;
                        int retries = 0;
                        string stateText = myRows[rowposTarget].AccessibleObject.StateText;
                        while (retries < maxRetry && stateText.Contains(MsaaResources.Strings.Collapsed.ToLowerInvariant()))
                        {
                            Utilities.LogMessage("Monitors.SelectTargetMonitor:: Expand Row");
                            myRows[rowposTarget].AccessibleObject.DoDefaultAction();
                            viewGrid.ScreenElement.WaitForReady();

                            stateText = myRows[rowposTarget].AccessibleObject.StateText;
                            Utilities.LogMessage("Monitors.SelectTargetMonitor:: rowposTarget.StateText after DoDefaultAction: " + myRows[rowposTarget].AccessibleObject.StateText);

                            if (stateText.Contains(MsaaResources.Strings.Expanded.ToLowerInvariant()))
                            {
                                Utilities.LogMessage("Monitors.SelectTargetMonitor:: Row is expanded.");
                                break;
                            }
                            else
                            {
                                Utilities.LogMessage("Monitors.SelectTargetMonitor:: Not found '" + MsaaResources.Strings.Expanded.ToLowerInvariant() + "' in the state text.");
                                Sleeper.Delay(Constants.OneSecond);
                            }
                            retries++;
                        }

                        #endregion // Make Row And Cell Visible

                        //Go to the row        
                        Utilities.LogMessage("rowposTarget='" + rowposTarget + "'   colpos='" + colpos + "' ");
                        //If failed to get the cell value, retry it.
                        try
                        {
                            cellValue = myRows[rowposTarget].Cells[colpos].GetValue();
                        }
                        catch (System.ArgumentOutOfRangeException rex)
                        {

                            Utilities.LogMessage(string.Format("Monitors.SelectTargetMonitor::myRows.Count={0}, rowposTarget={1}", myRows.Count, rowposTarget));
                            Utilities.LogMessage("Monitors.SelectTargetMonitor::'"+rex.ToString()+"'. Failed to get cellvalue, retry it.");
                            Utilities.LogMessage("Monitors.SelectTargetMonitor::Update rowCount and myRows.");
                            if (myRows.Count != viewGrid.Rows.Count)
                            {
                                rowCount = viewGrid.Rows.Count;
                                myRows = viewGrid.Rows;
                            }

                            Sleeper.Delay(Constants.OneSecond);
                            cellValue = myRows[rowposTarget].Cells[colpos].GetValue();                       
                        }
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: Current cellvalue : " + cellValue);

                        if (string.Compare(cellValue, Monitors.Strings.EntityHealthMonitor) == 0)
                        {
                            foundEntityHealth++;
                            Utilities.LogMessage("Monitors.SelectTargetMonitor:: Entity Health count " + foundEntityHealth);
                        }

                        if (string.Compare(cellValue, monitorName) == 0)
                        {
                            rowposMonitor = rowposTarget;
                            Utilities.LogMessage("Monitors.SelectTargetMonitor:: Monitor found at row index " + rowposMonitor);
                            viewGrid.ClickCell(rowposMonitor, colpos);
                            break;
                        }
                        else
                        {
                            //bug#195925
                            viewGrid.ScreenElement.WaitForReady();
                            // move the highlight to the next row
                            viewGrid.SendKeys(KeyboardCodes.DownArrow);
                 
                        }

                        //Utilities.LogMessage("Monitors.SelectTargetMonitor:: rowposTarget.StateText: " + myRows[rowposTarget].AccessibleObject.StateText);
                        //if (myRows[rowposTarget].AccessibleObject.StateText.Contains(MsaaStates.Collapsed.ToString().ToLowerInvariant()))
                        //{
                        //    Utilities.LogMessage("Monitors.SelectTargetMonitor:: Expand Row");
                        //    myRows[rowposTarget].AccessibleObject.DoDefaultAction();
                        //}
                        rowposTarget++;

                        //If the rows are collapsed initially we get incorrect row count
                        if (rowposTarget == (rowCount - 1))
                        {
                            Utilities.LogMessage("Monitors.SelectTargetMonitor:: Hit the last row count - Lets get the row count once more...");
                            Utilities.LogMessage("Monitors.SelectTargetMonitor:: Original row count: " + rowCount.ToString());
                            if (rowCount != viewGrid.Rows.Count)
                            {
                                rowCount = viewGrid.Rows.Count;
                                myRows = viewGrid.Rows;
                            }
                            Utilities.LogMessage("Monitors.SelectTargetMonitor:: New row count: " + rowCount.ToString());
                        }
                    }

                    if (rowposMonitor == -1)
                    {
                        Utilities.LogMessage("Monitors.SelectTargetMonitor:: Monitor '"
                            + monitorName
                            + "' not found under target "
                            + targetName);
                        throw new DataGridView.Exceptions.DataGridViewRowNotFoundException("Monitor not found under the specified Target!!");
                    }
                #endregion
                }
                else
                {
                    Utilities.LogMessage("Monitors.SelectTargetMonitor:: Monitor Target '" + targetName + "' not found");
                    throw new DataGridView.Exceptions.DataGridViewRowNotFoundException("Target specified for the monitor not found!!");
                }
                #endregion
            }
            else
            {
                Utilities.LogMessage("Monitors.SelectTargetMonitor:: Monitors ViewGrid not found.");
                throw new DataGridView.Exceptions.WindowNotFoundException("Monitors ViewGrid not found");
            }

            viewGrid = null;
            return rowposMonitor;
        }

        /// <summary>
        /// Returns boolean indicating whether a particular Monitor for a specifed Target 
        /// is found in the Monitors view or not.
        /// </summary>
        /// <param name="targetName">Class where the monitor is targetted</param>                
        /// <param name="monitorName">Aggregate/Dependency/Unit monitor name that you want to select</param>                
        /// <returns>bool</returns>        
        /// <history>
        /// [ruhim] 23MAR06 - Created        
        /// </history>
        public bool TargetMonitorExists(string targetName, string monitorName)
        {
            bool foundMonitor = false;
            //If SelectTargetMonitor method does not throw an exceptiona nd return a row index value 
            //greater than -1 then the target monitor is found
            try
            {
                if (this.SelectTargetMonitor(targetName, monitorName) > -1)
                {
                    foundMonitor = true;
                }
            }
            catch (DataGridView.Exceptions.DataGridViewRowNotFoundException)
            {
                Utilities.LogMessage("Monitors.TargetMonitorExists:: Caught exception DataGridViewRowNotFoundException hence monitor not found");                                
            }
            return foundMonitor;
        }


        /// <summary>
        /// Delete a specific monitor
        /// </summary>
        /// <param name="monitorName">monitor name</param>       
        /// <param name="targetName">Class where the monitor is targetted</param>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">DataGridViewRowNotFoundException</exception>
        /// <history>
        ///     [ruhim] 05Sep06 - Created        
        ///     [v-vijia] 24MAR2011 - Edited 
        /// </history>
        public void Delete(string targetName, string monitorName)
        {
            string[] menuItems = { HealthConfigurationView.Strings.ContextMenuDelete };
            ExecuteContextMenuForTargetMontior(targetName, monitorName, menuItems);
            //select Yes on the delete confirmation dialog
            CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.Yes, Strings.ConfirmMonitorDeleteTitle, StringMatchSyntax.ExactMatch, MomConsoleApp.ActionIfWindowNotFound.Error);
            //Wait until cursor type changes from busy icon
            CoreManager.MomConsole.Waiters.WaitUntilCursorType(Maui.Core.NativeMethods.MouseCursorType.Wait, 240);
            Utilities.LogMessage("Monitors.Delete:: Succesfully deleted the Monitor");                                              
        }

        /// <summary>
        /// Selects a Monitor Type under the specified folder in Select a Monitor Type 
        /// Dialog of Create monitor wizard 
        /// </summary>
        /// <param name="folderName">Immediate Folder parent under which the Monitor Type resides</param>                
        /// <param name="monitorType">Monitor Type name that you want to select</param>                
        /// <returns>bool</returns>        
        /// <history>
        /// [ruhim] 22Jun06 - Created        
        /// </history>
        public void SelectMonitorType(Guid folderName, string monitorType)
        {
            string folderPath = Utilities.GetMonitorFolderHierarchy(folderName);
            
            //The Root folder is called "Monitor Types" in this hierarchy
            //that doesn't show up in the UI hence i have to update the folderPath
            //to get rid of that
            
            int indexOfDelimiter = folderPath.IndexOf(Constants.PathDelimiter);            
            int pathLength = folderPath.Length;            
            string newFolderPath = folderPath.Substring(indexOfDelimiter+1);
            Utilities.LogMessage("Monitors.SelectMonitorType :: Updated Folder path is : " 
                + newFolderPath);

            //Create an instance of the first screen of the monitor wizard
            MonitorTypeDialog monitorTypeWizard =
                new MonitorTypeDialog(CoreManager.MomConsole);
            monitorTypeWizard.ScreenElement.WaitForReady();
            
            TreeNode monitorNode = null;
            string monitorPath = newFolderPath + Constants.PathDelimiter + monitorType;
            monitorNode = CoreManager.MomConsole.ExpandTreePath(monitorPath, monitorTypeWizard.Controls.SelectAMonitorTypeBelowTreeView);

            if (null != monitorNode)
            {
                monitorNode.Click();
            } 
           
            //Wait for UI to settle after Monitor Type selection

             CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForWindowIdle(monitorTypeWizard, 60000);

        }

        /// <summary>
        /// Returns the display string for WeekDay Name depending on current machine locale settings 
        /// </summary>
        /// <param name="weekDayName">WeekDay Name in English</param>                
        /// <returns>string</returns>        
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <history>
        /// [ruhim] 27April07 - Created        
        /// </history>
        public string WeekDayLocalizedName(string weekDayName)
        {
            string localizedWeekDayName = null;

            switch (weekDayName.ToLowerInvariant())
            {
                case "sunday":
                    localizedWeekDayName = CultureInfo.CurrentCulture.DateTimeFormat.DayNames.GetValue(0).ToString();
                    break;

                case "monday":
                    localizedWeekDayName = CultureInfo.CurrentCulture.DateTimeFormat.DayNames.GetValue(1).ToString();
                    break;

                case "tuesday":
                    localizedWeekDayName = CultureInfo.CurrentCulture.DateTimeFormat.DayNames.GetValue(2).ToString();
                    break;

                case "wednesday":
                    localizedWeekDayName = CultureInfo.CurrentCulture.DateTimeFormat.DayNames.GetValue(3).ToString();
                    break;

                case "thursday":
                    localizedWeekDayName = CultureInfo.CurrentCulture.DateTimeFormat.DayNames.GetValue(4).ToString();
                    break;

                case "friday":
                    localizedWeekDayName = CultureInfo.CurrentCulture.DateTimeFormat.DayNames.GetValue(5).ToString();
                    break;

                case "saturday":
                    localizedWeekDayName = CultureInfo.CurrentCulture.DateTimeFormat.DayNames.GetValue(6).ToString();
                    break;

                default:
                    Utilities.LogMessage("Monitors.WeekDayLocalizedName:: Incorrect weekday name specified: " + weekDayName);
                    throw new InvalidEnumArgumentException("Monitors.WeekDayLocalizedName:: Incorrect Weekday name specified");                   
            }

            Utilities.LogMessage("Monitors.WeekDayLocalizedName:: Localized name corresponding to " + weekDayName 
                + " is: " + localizedWeekDayName);
            return localizedWeekDayName;
        }

        /// <summary>
        /// Enable/Disable a specific monitor from context menu/actions pane
        /// </summary>
        /// <param name="monitorName">monitor name</param>       
        /// <param name="targetName">Class where the monitor is targetted</param>
        /// <param name="enable">Boolean indicating if monitor needs to be enabled. 
        /// If set to false it will disable the monitor</param>
        /// <param name="contextMenu">Boolean indicating if you want to enable/disable the monitor 
        /// from context menu. If set to false it will enable/disable the monitor from actions pane</param>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">DataGridViewRowNotFoundException</exception>
        /// <history>
        ///     [ruhim] 25May07 - Created
        ///     [v-vijia] 24MAR2011 - Edited 
        /// </history>
        public void EnableDisableMonitor(string targetName, string monitorName, bool enable, bool contextMenu)
        {
            if (contextMenu)
            {
                if (enable)
                {
                    Utilities.LogMessage("Monitors.EnableDisableMonitor:: Executing the context menu: " + HealthConfigurationView.Strings.ContextMenuEnable);
                    string [] menuItems =  { HealthConfigurationView.Strings.ContextMenuEnable };
                    this.ExecuteContextMenuForTargetMontior(targetName, monitorName, menuItems);
                }
                else
                {
                    Utilities.LogMessage("Monitors.EnableDisableMonitor:: Executing the context menu: " + HealthConfigurationView.Strings.ContextMenuDisable);
                    string[] menuItems = { HealthConfigurationView.Strings.ContextMenuDisable };
                    this.ExecuteContextMenuForTargetMontior(targetName, monitorName, menuItems);
                }
                Utilities.LogMessage("Monitors.EnableDisableMonitor:: Successfully clicked on the context menu");
            }

            else
            {
                //Navigate and Select the specific Monitor under Monitors view
                SelectTargetMonitor(targetName, monitorName);

                //Launch Click actions pane link
                Utilities.LogMessage("Monitors.EnableDisableMonitor:: Executing Actions Pane Item");
                
                //Get Reference to Actions Pane and select the item from the actions pane.
                ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
                if (enable)
                {                    
                    Utilities.LogMessage("Monitors.EnableDisableMonitor:: Executing the Actions Pane Item: " + HealthConfigurationView.Strings.ActionsPaneEnable);
                    taskPane.ClickLink(HealthConfigurationView.Strings.MonitorActionsPaneHeader, HealthConfigurationView.Strings.ActionsPaneEnable);
                }
                else
                {                    
                    Utilities.LogMessage("Monitors.EnableDisableMonitor:: Executing the Actions Pane Item: " + HealthConfigurationView.Strings.ActionsPaneDisable);
                    taskPane.ClickLink(HealthConfigurationView.Strings.MonitorActionsPaneHeader, HealthConfigurationView.Strings.ActionsPaneDisable);
                }
                Utilities.LogMessage("Monitors.EnableDisableMonitor:: Successfully clicked on the Actions Pane item");
            }
        }
        
        /// <summary>
        /// Returns bool indicating whether the verification succeeded or not
        /// Verifies if the monitor is Enabled/Disabled by checking the checkbox 'Monitor is enabled' from monitor property page
        /// </summary>
        /// <param name="viewGrid">grid control</param>       
        /// <param name="monitorName">monitor name</param>       
        /// <param name="targetName">Class where the monitor is targetted</param>
        /// <param name="verifyEnabled">Boolean indicating what needs to be verified i.e. the monitor is disabled or enabled. 
        /// If set to false it will verify that the monitor is disabled i.e. the checkbox is unchecked</param>
        /// <returns>bool</returns>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">DataGridViewRowNotFoundException</exception>
        /// <history>
        ///     [ruhim] 30May07 - Created        
        /// </history>
        ///
        public bool VerifyEnableDisableMonitor(Core.Console.MomControls.GridControl viewGrid, string targetName, string monitorName, bool verifyEnabled)
        {
            bool monitorVerificationSuccess = false;

            //Launch the context menu
            //Utilities.LogMessage("Monitors.VerifyEnableDisableMonitor:: Launching the context menu");
            //Maui.Core.WinControls.Menu myMenuItem = new Maui.Core.WinControls.Menu(Maui.Core.WinControls.ContextMenuAccessMethod.ShiftF10);

            //Utilities.LogMessage("Monitors.VerifyEnableDisableMonitor:: Executing the context menu: " + HealthConfigurationView.Strings.ContextMenuProperties);
            //myMenuItem.ExecuteMenuItem(HealthConfigurationView.Strings.ContextMenuProperties);

            //Launch the General Properties Dialog
            //Bug#219553
            this.LaunchMonitorPropertiesDialog(targetName, monitorName);
            
            GeneralProperties generalProperties = new GeneralProperties(CoreManager.MomConsole);
            generalProperties.ScreenElement.WaitForReady();

            if (!verifyEnabled)
            {
                //verify that the monitor is disabled
                if (generalProperties.Controls.MonitorIsEnabledCheckBox.ButtonState != ButtonState.Checked)
                {
                    Utilities.LogMessage("Monitors.VerifyEnableDisableMonitor:: Successfully Verified monitor " + monitorName + " is disabled");
                    monitorVerificationSuccess = true;
                }
                else
                {
                    Utilities.LogMessage("Monitors.VerifyEnableDisableMonitor:: Monitor " + monitorName + " is not disabled - Verification failed");
                }
                generalProperties.ClickTitleBarClose();
            }
            else
            {
                if (generalProperties.Controls.MonitorIsEnabledCheckBox.ButtonState == ButtonState.Checked)
                {
                    Utilities.LogMessage("Monitors.VerifyEnableDisableMonitor:: Successfully Verified monitor " + monitorName + " is enabled");
                    monitorVerificationSuccess = true;
                }
                else
                {
                    Utilities.LogMessage("Monitors.VerifyEnableDisableMonitor:: Monitor " + monitorName + " is not enabled - Verification failed");
                }
                //verify that the monitor is enabled
                generalProperties.ClickTitleBarClose();
            }
            return monitorVerificationSuccess;
        }



        /// <summary>
        /// Returns bool indicating whether the verification succeeded or not
        /// Verifies if the monitor is Enabled/Disabled by checking the checkbox 'Monitor is enabled' from monitor property page
        /// </summary>
        /// <param name="monitorName">monitor name</param>       
        /// <param name="targetName">Class where the monitor is targetted</param>
        /// <param name="verifyEnabled">Boolean indicating what needs to be verified i.e. the monitor is disabled or enabled. 
        /// If set to false it will verify that the monitor is disabled i.e. the checkbox is unchecked</param>
        /// <returns>bool</returns>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">DataGridViewRowNotFoundException</exception>
        /// <history>
        ///     [ruhim] 30May07 - Created
        ///     [v-vijia] 24MAR2011 - Edited 
        /// </history>
        ///
        public bool VerifyEnableDisableMonitor(string targetName, string monitorName, bool verifyEnabled)
        {
            bool monitorVerificationSuccess = false;

            this.LaunchMonitorPropertiesDialog(targetName, monitorName);
            GeneralProperties generalProperties = new GeneralProperties(CoreManager.MomConsole);            

            if (!verifyEnabled)
            {
                //verify that the monitor is disabled
                if (generalProperties.Controls.MonitorIsEnabledCheckBox.ButtonState != ButtonState.Checked)
                {
                    Utilities.LogMessage("Monitors.VerifyEnableDisableMonitor:: Successfully Verified monitor " + monitorName + " is disabled");
                    monitorVerificationSuccess = true;
                }
                else
                {
                    Utilities.LogMessage("Monitors.VerifyEnableDisableMonitor:: Monitor " + monitorName + " is not disabled - Verification failed");
                }
                generalProperties.ClickTitleBarClose();
            }
            else
            {
                if (generalProperties.Controls.MonitorIsEnabledCheckBox.ButtonState == ButtonState.Checked)
                {
                    Utilities.LogMessage("Monitors.VerifyEnableDisableMonitor:: Successfully Verified monitor " + monitorName + " is enabled");
                    monitorVerificationSuccess = true;
                }
                else
                {
                    Utilities.LogMessage("Monitors.VerifyEnableDisableMonitor:: Monitor " + monitorName + " is not enabled - Verification failed");
                }
                //verify that the monitor is enabled
                generalProperties.ClickTitleBarClose();
            }

            return monitorVerificationSuccess;
        }


        /// <summary>
        /// Function to fetch Monitor alert WA datatype properties from test store
        /// </summary>
        /// <param name="monitorTypeName">monitorTypeName</param>
        /// <param name="recursive">true or false</param>
        /// <returns>Arraylist of properties</returns>
        public static ArrayList GetMonitorDataTypePropsFromTestStore(string monitorTypeName, bool recursive)
        {

            Utilities.LogMessage("GetMonitorDataTypePropsFromTestStore :: MonitorTypeName='" + monitorTypeName + "'");
            XPathDocument xmlDoc = new XPathDocument(@"..\common\Monitors.xml");
            String xpathExpr = @"/Monitors/Monitor[@TypeID='" + monitorTypeName + "']/DataTypes/*";
            XPathNavigator nav = xmlDoc.CreateNavigator();
            XPathNodeIterator nodeiter = nav.Select(xpathExpr);
            ArrayList testProperties = new ArrayList();
            

            string typeName, subTypeName;
            while (nodeiter.MoveNext())
            {
                switch (nodeiter.Current.Name.ToUpperInvariant())
                {
                    case "DATATYPE":
                        Utilities.LogMessage("Current Node is a Datatype. Getting propertied for the DataType '" + 
                            nodeiter.Current.GetAttribute("type", "") + "'");
                        typeName = nodeiter.Current.GetAttribute("type", "");
                        MonitoringConfiguration.GetDataTypePropsFromTestStore(typeName, ref testProperties, recursive);
                        break;
                    case "PROPERTY":
                        Utilities.LogMessage("Current Node is a Property. Adding property '" + nodeiter.Current.GetAttribute("name", "") + "'");
                        testProperties.Add(nodeiter.Current.GetAttribute("name", ""));

                        typeName = nodeiter.Current.GetAttribute("type", "");

                        if (typeName != null && typeName.Length > 0)
                        {
                            Utilities.LogMessage("Expanding 'type' for property '" + typeName + "' ...");
                            MonitoringConfiguration.GetDataTypePropsFromTestStore(typeName, ref testProperties, recursive);

                        }

                        subTypeName = nodeiter.Current.GetAttribute("subtype", "");

                        if (subTypeName != null && subTypeName.Length > 0)
                        {
                            Utilities.LogMessage("Expanding 'subtype' for property '" + subTypeName + "' ...");
                            MonitoringConfiguration.GetDataTypePropsFromTestStore(subTypeName, ref testProperties, recursive);
                        }
                        break;
                    default:
                        break;
                }
            }
            return testProperties;
        }

        /// <summary>
        /// Create a WMI Event Monitor reading configuration from the given XML.
        /// This method will navigate through the wizard to create a WMI Event Monitor
        /// </summary>
        /// <param name="testDataXml">Name string of test data xml file</param> 
        /// <history>
        /// [v-eryon] 25SEP08 - Created        
        /// </history>
        /// <exception cref="System.NullReferenceException">NullReferenceException</exception>
        public void CreateWMIEventMonitor(string testDataXml)
        {
            string selectedType = null;
            StringBuilder currentMethod = new StringBuilder(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            currentMethod.Append(".").Append(System.Reflection.MethodBase.GetCurrentMethod().Name);

            Utilities.LogMessage(currentMethod + ":: Starting method");

            //Load test data and select node related with current test case
            XPathNavigator xmlNavigator = LoadTestDataXml(testDataXml).SelectSingleNode(
            String.Format("//TestConfiguration/Var[@recmval='{0}']", Mcf.GetValueFromRecords("TestCases")));
            Utilities.LogMessage(currentMethod + ":: created navigator to the XML config data provided");

            #region Launch WMI Event Wizard

            LaunchCreateUnitMonitorWizard();
            Utilities.LogMessage(currentMethod + ":: Launched the Create WMI Monitor Wizard for Unit Monitor");

            #endregion

            if (!xmlNavigator.IsEmptyElement)
            {
                if (xmlNavigator.HasChildren)
                {
                    XPathNodeIterator monitorTypeIterator = xmlNavigator.SelectSingleNode("MonitorType").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(currentMethod + ": Monitor type element value " + monitorTypeIterator.Current.InnerXml);

                    #region Monitor Type Config

                    //Create an instance of the first screen of the monitor wizard
                    MonitorTypeDialog montiorTypeDialog = new MonitorTypeDialog(CoreManager.MomConsole);
                    montiorTypeDialog.ScreenElement.WaitForReady();

                    if (monitorTypeIterator == null || monitorTypeIterator.Count < 1)
                    {
                        throw new NullReferenceException(currentMethod + ":: Could not Create Iterator for General Config Elements");
                    }

                    do
                    {
                        Utilities.LogMessage("monitorTypeIterator.Current.Name: " + monitorTypeIterator.Current.Name);
                        if (string.Compare(monitorTypeIterator.Current.Name, "MonitorTypeID") == 0)
                        {
                            selectedType = monitorTypeIterator.Current.Value;
                            Utilities.LogMessage(currentMethod + ":: Monitor type specified in xml is: " + selectedType);
                            switch (selectedType)
                            {
                                case WMIEventSingleManualReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWMIEventSimpleGUID, MonitorTypeDialog.Strings.WMIEventSingleManualReset);
                                    break;

                                case WMIEventSingleTimerReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWMIEventSimpleGUID, MonitorTypeDialog.Strings.WMIEventSingleTimerReset);
                                    break;

                                case WMIEventSingleWMIEventReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWMIEventSimpleGUID, MonitorTypeDialog.Strings.WMIEventSingleEventReset);
                                    break;

                                case WMIEventRepeatedManualReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWMIEventRepeatedGUID, MonitorTypeDialog.Strings.WMIEventRepeatedManualReset);
                                    break;

                                case WMIEventRepeatedTimerReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWMIEventRepeatedGUID, MonitorTypeDialog.Strings.WMIEventRepeatedTimerReset);
                                    break;

                                case WMIEventRepeatedWMIEventReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWMIEventRepeatedGUID, MonitorTypeDialog.Strings.WMIEventRepeatedEventReset);
                                    break;

                                default:
                                    Utilities.LogMessage(currentMethod +
                                        ":: Monitor type specified in xml is: " + selectedType + "' is invalid");
                                    throw new InvalidEnumArgumentException("Invalid Monitor Type selected");
                            }
                        }
                        else
                        {
                            if (string.Compare(monitorTypeIterator.Current.Name, "DestinationMP") == 0)
                            {
                                Utilities.LogMessage(currentMethod + ":: Destination MP specified in xml is: " + monitorTypeIterator.Current.Value);
                                montiorTypeDialog.Controls.SelectDestinationManagementPackComboBox.SelectByText(monitorTypeIterator.Current.Value);
                            }
                        }
                    }
                    while (monitorTypeIterator.MoveNext());

                    //Navigate to the newxt page in the wizard
                    int attempt = 0;
                    int maxtries = 10;
                    while (attempt <= maxtries)
                    {
                        if (montiorTypeDialog.Controls.NextButton.IsEnabled)
                        {
                            montiorTypeDialog.ClickNext();
                            Utilities.LogMessage("Next button is enabled - Clicked on Next button");
                            montiorTypeDialog.WaitForResponse();
                            break;
                        }
                        else
                        {
                            Utilities.LogMessage("Next button not enabled - attemp no: " + attempt);
                            Sleeper.Delay(Constants.OneSecond);
                            attempt++;
                        }
                    }

                    #endregion

                    XPathNodeIterator generalIterator = xmlNavigator.SelectSingleNode("GeneralConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(currentMethod + ": General config element value " + generalIterator.Current.InnerXml);

                    #region General Config

                    if (generalIterator == null || generalIterator.Count < 1)
                    {
                        throw new NullReferenceException(currentMethod +
                            ": Could not Create Iterator for General Config Elements");
                    }

                    GeneralSetting(generalIterator, currentMethod);

                    #endregion

                    XPathNodeIterator wmiConfigIterator = xmlNavigator.SelectSingleNode("WMIEventConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(currentMethod + ": WMI event config element value " + wmiConfigIterator.Current.InnerXml);

                    #region WMI Event/Expression Config

                    ConfigureWMIEventExpression(wmiConfigIterator);

                    #endregion

                    if (selectedType.Contains("WMIEventReset"))
                    {
                        XPathNodeIterator secWMIConfigIterator = xmlNavigator.SelectSingleNode("SecondWMIEventConfig").SelectChildren(XPathNodeType.Element);
                        Utilities.LogMessage(currentMethod + ": Second WMI event config element value " + secWMIConfigIterator.Current.InnerXml);

                        #region Second WMI Event/Expression Config

                        ConfigureWMIEventExpression(secWMIConfigIterator);

                        #endregion
                    }

                    if (selectedType.Contains("Repeated"))
                    {
                        ConsolidationSettingsDialog consolidationDialog = new ConsolidationSettingsDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitorWizard);
                        consolidationDialog.ScreenElement.WaitForReady();
                        XPathNodeIterator consolidationIterator = xmlNavigator.SelectSingleNode("ConsolidationSettings").SelectChildren(XPathNodeType.Element);
                        Utilities.LogMessage(currentMethod + ": Consolidation settings element value " + consolidationIterator.Current.InnerXml);

                        #region Consolidation Settings

                        if (consolidationIterator == null)
                        {
                            throw new NullReferenceException(currentMethod + ":: Could not create Iterator for Consolidation Settings Elements");
                        }
                        else if (checked(consolidationIterator.Count < 1))
                        {
                            throw new NullReferenceException(string.Format(currentMethod +
                                ":: No. of Consolidation Settings Child Elements cannot be of count: {0} must be greater or equal to 1",
                                consolidationIterator.Count));
                        }

                        while (consolidationIterator.MoveNext())
                        {
                            switch (consolidationIterator.Current.Name)
                            {
                                case "CountingMode":
                                    //If value is not specified then go with the defaults on the page
                                    if (consolidationIterator.Current.Value != null)
                                    {
                                        switch (consolidationIterator.Current.Value.ToLowerInvariant())
                                        {
                                            case "trigger on count":
                                                consolidationDialog.CountingModeComboBoxText = ConsolidationSettingsDialog.Strings.TriggeronCount;
                                                consolidationDialog.CompareCountText = consolidationIterator.Current.GetAttribute("count", "");
                                                break;

                                            case "trigger on timer":
                                                consolidationDialog.CountingModeComboBoxText = ConsolidationSettingsDialog.Strings.TriggeronTimer;
                                                break;

                                            case "trigger on count, sliding":
                                                consolidationDialog.CountingModeComboBoxText = ConsolidationSettingsDialog.Strings.TriggeronCountSliding;
                                                consolidationDialog.CompareCountText = consolidationIterator.Current.GetAttribute("count", "");
                                                break;
                                        }
                                        Sleeper.Delay(Constants.OneSecond);
                                    }
                                    break;

                                case "TimeControl":
                                    XPathNodeIterator timeControlIterator = consolidationIterator.Current.SelectChildren(XPathNodeType.Element);
                                    Utilities.LogMessage(currentMethod + ":Time Control element value " + timeControlIterator.Current.InnerXml);

                                    if (timeControlIterator != null && (timeControlIterator.Count >= 1))
                                    {
                                        do
                                        {
                                            switch (timeControlIterator.Current.Name)
                                            {
                                                case "WithinTimeSchedule":
                                                    //select the radio button
                                                    if (consolidationDialog.Controls.BasedOnItemsOccurenceWithinATimeIntervalRadioButton.ButtonState != ButtonState.Checked)
                                                    {
                                                        consolidationDialog.Controls.BasedOnItemsOccurenceWithinATimeIntervalRadioButton.Click();
                                                    }

                                                    XPathNodeIterator withinTimeScheduleIterator = timeControlIterator.Current.SelectChildren(XPathNodeType.Element);
                                                    Utilities.LogMessage(currentMethod + ": WithinTimeSchedule element value " + withinTimeScheduleIterator.Current.InnerXml);

                                                    if (withinTimeScheduleIterator != null && (withinTimeScheduleIterator.Count >= 1))
                                                    {
                                                        while (withinTimeScheduleIterator.MoveNext())
                                                        {
                                                            if (string.Compare(withinTimeScheduleIterator.Current.Name, "Interval") == 0)
                                                            {
                                                                consolidationDialog.IntervalText = withinTimeScheduleIterator.Current.Value;

                                                                string timerUnit = null;
                                                                timerUnit = withinTimeScheduleIterator.Current.GetAttribute("unit", "");
                                                                //get the display string for timer unit
                                                                switch (timerUnit.ToLowerInvariant())
                                                                {
                                                                    case "seconds":
                                                                        consolidationDialog.IntervalUnitComboBoxText = AutoResetTimerDialog.Strings.SecondsTimerUnit;
                                                                        break;

                                                                    case "minutes":
                                                                        consolidationDialog.IntervalUnitComboBoxText = AutoResetTimerDialog.Strings.MinutesTimerUnit;
                                                                        break;

                                                                    case "hours":
                                                                        consolidationDialog.IntervalUnitComboBoxText = AutoResetTimerDialog.Strings.HoursTimerUnit;
                                                                        break;

                                                                    case "days":
                                                                        consolidationDialog.IntervalUnitComboBoxText = AutoResetTimerDialog.Strings.DaysTimerUnit;
                                                                        break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    break;

                                                case "WeeklySchedule":
                                                    //select the radio button
                                                    if (consolidationDialog.Controls.BasedOnFixedWeeklyScheduleRadioButton.ButtonState != ButtonState.Checked)
                                                    {
                                                        Sleeper.Delay(Constants.OneSecond);
                                                        consolidationDialog.Controls.BasedOnFixedWeeklyScheduleRadioButton.Extended.SetFocus();
                                                        consolidationDialog.Controls.BasedOnFixedWeeklyScheduleRadioButton.Click();
                                                    }

                                                    SelectTimeRangeDialog timeRangeDialog = null;
                                                    int retryTime = 0;
                                                    int maxRetrycount = 4;
                                                    while (timeRangeDialog == null && retryTime <= maxRetrycount)
                                                    {
                                                        try
                                                        {
                                                            //Launch the Select Time Range dialog
                                                            CoreManager.MomConsole.InvokeToolBarButton(consolidationDialog.Controls.AddRemoveToolStrip,
                                                                ConsolidationSettingsDialog.Strings.AddToolStripButton);

                                                            timeRangeDialog = new SelectTimeRangeDialog(CoreManager.MomConsole);
                                                            timeRangeDialog.ScreenElement.WaitForReady();

                                                            retryTime++;
                                                        }
                                                        catch(Maui.Core.WinControls.Toolbar.Exceptions.ToolbarItemNotFoundException)
                                                        {
                                                            Utilities.LogMessage("Failed to Launch the Select Time Range dialog, will retry" + retryTime);
                                                            retryTime++;
                                                        }
                                                    }
                                                    ////Launch the Select Time Range dialog
                                                    //CoreManager.MomConsole.InvokeToolBarButton(consolidationDialog.Controls.AddRemoveToolStrip,
                                                    //    ConsolidationSettingsDialog.Strings.AddToolStripButton);

                                                    //SelectTimeRangeDialog timeRangeDialog = new SelectTimeRangeDialog(CoreManager.MomConsole);
                                                    //timeRangeDialog.ScreenElement.WaitForReady();

                                                    XPathNodeIterator weeklyScheduleIterator = timeControlIterator.Current.SelectChildren(XPathNodeType.Element);
                                                    Utilities.LogMessage(currentMethod + ":WeeklySchedule element value " + weeklyScheduleIterator.Current.InnerXml);

                                                    if (weeklyScheduleIterator != null && (weeklyScheduleIterator.Count >= 1))
                                                    {
                                                        while (weeklyScheduleIterator.MoveNext())
                                                        {
                                                            switch (weeklyScheduleIterator.Current.Name)
                                                            {
                                                                case "Daily":
                                                                    if (timeRangeDialog.Controls.DailyRadioButton.ButtonState != ButtonState.Checked)
                                                                    {
                                                                        timeRangeDialog.Controls.DailyRadioButton.Click();
                                                                        Utilities.LogMessage(currentMethod + ":Daily Time Range selected");
                                                                    }
                                                                    XPathNodeIterator dailyIterator = weeklyScheduleIterator.Current.SelectChildren(XPathNodeType.Element);
                                                                    Utilities.LogMessage(currentMethod + ":Daily element value " + dailyIterator.Current.InnerXml);

                                                                    if (dailyIterator != null && (dailyIterator.Count >= 1))
                                                                    {
                                                                        while (dailyIterator.MoveNext())
                                                                        {
                                                                            switch (dailyIterator.Current.Name)
                                                                            {
                                                                                case "Start":
                                                                                    //Leave the default values if it's null
                                                                                    if (dailyIterator.Current.Value != null)
                                                                                    {
                                                                                        string time = dailyIterator.Current.Value;
                                                                                        timeRangeDialog.Controls.DailyStartDateTimePicker.Hour = int.Parse(time.Substring(0, 2));
                                                                                        timeRangeDialog.Controls.DailyStartDateTimePicker.Minute = int.Parse(time.Substring((time.IndexOf(':') + 1), 2));
                                                                                        timeRangeDialog.ScreenElement.WaitForReady();
                                                                                        Utilities.LogMessage(currentMethod + ":Set the Daily Start time to " + dailyIterator.Current.Value);
                                                                                    }
                                                                                    break;

                                                                                case "End":
                                                                                    //Leave the default values if it's null
                                                                                    if (dailyIterator.Current.Value != null)
                                                                                    {
                                                                                        string time = dailyIterator.Current.Value;
                                                                                        int maxRetry = 3;
                                                                                        int count = 0;
                                                                                        do
                                                                                        {
                                                                                            timeRangeDialog.Controls.DailyEndDateTimePicker.Hour = int.Parse(time.Substring(0, 2));
                                                                                            timeRangeDialog.Controls.DailyEndDateTimePicker.Minute = int.Parse(time.Substring((time.IndexOf(':') + 1), 2));
                                                                                            timeRangeDialog.ScreenElement.WaitForReady();
                                                                                            Utilities.LogMessage(currentMethod + ":Retry attempt in setting Daily End time is: " + count);
                                                                                            count++;
                                                                                        }
                                                                                        while ((timeRangeDialog.Controls.DailyEndDateTimePicker.Hour != int.Parse(time.Substring(0, 2))) && (count < maxRetry));
                                                                                        Utilities.LogMessage(currentMethod + ":Set the Daily End time to " + dailyIterator.Current.Value);
                                                                                    }
                                                                                    break;

                                                                                case "DaysOfWeek":
                                                                                    timeRangeDialog.Controls.DaysOfWeekListBox.SelectItem(WeekDayLocalizedName(dailyIterator.Current.Value));
                                                                                    break;
                                                                            }
                                                                        }
                                                                    }
                                                                    break;

                                                                case "MutipleDays":
                                                                    if (timeRangeDialog.Controls.SpanMultipleDaysRadioButton.ButtonState != ButtonState.Checked)
                                                                    {
                                                                        timeRangeDialog.Controls.SpanMultipleDaysRadioButton.Click();
                                                                        Utilities.LogMessage(currentMethod + ":Span multiple days Time Range selected");
                                                                    }
                                                                    XPathNodeIterator mutipleDaysIterator = weeklyScheduleIterator.Current.SelectChildren(XPathNodeType.Element);
                                                                    Utilities.LogMessage(currentMethod + ":MutipleDays element value " + mutipleDaysIterator.Current.InnerXml);

                                                                    if (mutipleDaysIterator != null && (mutipleDaysIterator.Count >= 1))
                                                                    {
                                                                        while (mutipleDaysIterator.MoveNext())
                                                                        {
                                                                            switch (mutipleDaysIterator.Current.Name)
                                                                            {
                                                                                case "Start":
                                                                                    string time = mutipleDaysIterator.Current.Value;
                                                                                    timeRangeDialog.Controls.MultipleStartDateTimePicker.Hour = int.Parse(time.Substring(0, 2));
                                                                                    timeRangeDialog.Controls.MultipleStartDateTimePicker.Minute = int.Parse(time.Substring((time.IndexOf(':') + 1), 2));
                                                                                    Utilities.LogMessage(currentMethod + ":Set the Multiple Days Start time to " + mutipleDaysIterator.Current.Value);

                                                                                    //Now select the day of the Week
                                                                                    timeRangeDialog.Controls.StartDayOfWeekComboBox.SelectByText(WeekDayLocalizedName(mutipleDaysIterator.Current.GetAttribute("day", "")));
                                                                                    break;

                                                                                case "End":
                                                                                    string endTime = mutipleDaysIterator.Current.Value;
                                                                                    timeRangeDialog.Controls.MultipleEndDateTimePicker.Hour = int.Parse(endTime.Substring(0, 2));
                                                                                    timeRangeDialog.Controls.MultipleEndDateTimePicker.Minute = int.Parse(endTime.Substring((endTime.IndexOf(':') + 1), 2));
                                                                                    Utilities.LogMessage(currentMethod + ":Set the Daily Start time to " + mutipleDaysIterator.Current.Value);

                                                                                    //Now select the day of the Week
                                                                                    timeRangeDialog.Controls.EndDayOfWeekComboBox.SelectByText(WeekDayLocalizedName(mutipleDaysIterator.Current.GetAttribute("day", "")));
                                                                                    break;
                                                                            }
                                                                        }
                                                                    }


                                                                    break;
                                                            }
                                                        }
                                                    }

                                                    //close the time range dialog
                                                    timeRangeDialog.Controls.OKButton.Extended.SetFocus();
                                                    timeRangeDialog.ClickOK();

                                                    break;

                                                case "SimpleReccuringSchedule":
                                                    //select the radio button
                                                    if (consolidationDialog.Controls.BasedOnFixedSimpleRecurringScheduleRadioButton.ButtonState != ButtonState.Checked)
                                                    {
                                                        consolidationDialog.Controls.BasedOnFixedSimpleRecurringScheduleRadioButton.Click();
                                                    }

                                                    XPathNodeIterator simpleReccuringScheduleIterator = timeControlIterator.Current.SelectChildren(XPathNodeType.Element);
                                                    Utilities.LogMessage(currentMethod + ":SimpleReccuringSchedule element value " + simpleReccuringScheduleIterator.Current.InnerXml);

                                                    if (simpleReccuringScheduleIterator != null && (simpleReccuringScheduleIterator.Count >= 1))
                                                    {
                                                        while (simpleReccuringScheduleIterator.MoveNext())
                                                        {
                                                            switch (simpleReccuringScheduleIterator.Current.Name)
                                                            {
                                                                case "Period":
                                                                    consolidationDialog.PeriodText = simpleReccuringScheduleIterator.Current.Value;

                                                                    string timerUnit = null;
                                                                    timerUnit = simpleReccuringScheduleIterator.Current.GetAttribute("unit", "");
                                                                    //get the display string for timer unit
                                                                    switch (timerUnit.ToLowerInvariant())
                                                                    {
                                                                        case "seconds":
                                                                            consolidationDialog.PeriodUnitComboBoxText = ConsolidationSettingsDialog.Strings.SecondsTimerUnit;
                                                                            break;

                                                                        case "minutes":
                                                                            consolidationDialog.PeriodUnitComboBoxText = ConsolidationSettingsDialog.Strings.MinutesTimerUnit;
                                                                            break;

                                                                        case "hours":
                                                                            consolidationDialog.PeriodUnitComboBoxText = ConsolidationSettingsDialog.Strings.HoursTimerUnit;
                                                                            break;

                                                                        case "days":
                                                                            consolidationDialog.PeriodUnitComboBoxText = ConsolidationSettingsDialog.Strings.DaysTimerUnit;
                                                                            break;
                                                                    }
                                                                    break;

                                                                case "SyncTime":
                                                                    if (simpleReccuringScheduleIterator.Current.Value != null)
                                                                    {
                                                                        if (consolidationDialog.Controls.SynchronizeAtCheckBox.ButtonState != ButtonState.Checked)
                                                                        {
                                                                            consolidationDialog.Controls.SynchronizeAtCheckBox.Click();
                                                                        }

                                                                        string time = simpleReccuringScheduleIterator.Current.Value;
                                                                        consolidationDialog.Controls.SynchronizeAtDateTimePicker.Hour = int.Parse(time.Substring(0, 2));
                                                                        consolidationDialog.Controls.SynchronizeAtDateTimePicker.Minute = int.Parse(time.Substring((time.IndexOf(':') + 1), 2));
                                                                    }
                                                                    break;
                                                            }
                                                        }
                                                    }

                                                    break;
                                            }
                                        } while (timeControlIterator.MoveNext());
                                    }//if

                                    break;
                            }
                        }
                        consolidationDialog.Controls.NextButton.Extended.SetFocus();
                        consolidationDialog.ClickNext();
                        consolidationDialog.WaitForResponse();

                        #endregion
                    }

                    if (selectedType.Contains("TimerReset"))
                    {
                        XPathNodeIterator autoResetTimerIterator = xmlNavigator.SelectSingleNode("AutoResetTimer").SelectChildren(XPathNodeType.Element);
                        Utilities.LogMessage(currentMethod + ": Auto reset timer element value " + autoResetTimerIterator.Current.InnerXml);

                        #region Auto Reset Timer Config

                        AutoResetTimerDialog autoResetTimer = new AutoResetTimerDialog(
                            CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitorWizard);

                        if (autoResetTimerIterator != null && autoResetTimerIterator.Count > 0)
                        {
                            while (autoResetTimerIterator.MoveNext())
                            {
                                //if the timer value is null then just go with the defaults
                                if ((string.Compare(autoResetTimerIterator.Current.Name, "Time") == 0)
                                    && (autoResetTimerIterator.Current.Value != null))
                                {
                                    autoResetTimer.SpecifyTheTimerWaitText = autoResetTimerIterator.Current.Value;

                                    string timerUnit = null;
                                    timerUnit = autoResetTimerIterator.Current.GetAttribute("unit", "");
                                    //get the display string for timer unit
                                    switch (timerUnit.ToLowerInvariant())
                                    {
                                        case "seconds":
                                            autoResetTimer.SpecifyTheWaitUnitsText = AutoResetTimerDialog.Strings.SecondsTimerUnit;
                                            break;

                                        case "minutes":
                                            autoResetTimer.SpecifyTheWaitUnitsText = AutoResetTimerDialog.Strings.MinutesTimerUnit;
                                            break;

                                        case "hours":
                                            autoResetTimer.SpecifyTheWaitUnitsText = AutoResetTimerDialog.Strings.HoursTimerUnit;
                                            break;

                                        case "days":
                                            autoResetTimer.SpecifyTheWaitUnitsText = AutoResetTimerDialog.Strings.DaysTimerUnit;
                                            break;
                                    }
                                }
                            }
                        }

                        autoResetTimer.ClickNext(); // This bypases AutoResetTimer page.
                        autoResetTimer.WaitForResponse();

                        #endregion
                    }

                    XPathNodeIterator healthConfigIterator = xmlNavigator.SelectSingleNode("HealthConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(currentMethod + ": Health config element value " + healthConfigIterator.Current.InnerXml);

                    #region Health Config

                    if (healthConfigIterator == null || healthConfigIterator.Count < 1)
                    {
                        throw new NullReferenceException(currentMethod + ": Could not create Iterator for Health Config Elements");
                    }

                    //Create an instance of Configure Health Dialog once
                    ConfigureHealthDialog healthDialog = new ConfigureHealthDialog(CoreManager.MomConsole);
                    healthDialog.ScreenElement.WaitForReady();

                    //Create instance of view pane
                    Core.Console.MomControls.GridControl viewGrid = new Core.Console.MomControls.GridControl(healthDialog,
                    ConfigureHealthDialog.ControlIDs.DataGridView1);
                    Utilities.LogMessage(currentMethod + ": Found Health Configuration Grid View");

                    while (healthConfigIterator.MoveNext())
                    {
                        switch (healthConfigIterator.Current.Name)
                        {
                            case "OperationalState":
                                int operationalRowPos = -1;

                                // Find row index according to configuration data
                                string text = healthConfigIterator.Current.GetAttribute("ID", "").ToLowerInvariant();
                                string operationalID= null;
                                switch (text)
                                {
                                    case "event raised":
                                        {
                                            switch (selectedType)
                                            {
                                                case WMIEventSingleManualReset:
                                                    operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIEventSingleManualResetGuid, Monitors.Strings.SingleWMIMonitorStateManualRaisedGuid);
                                                    break;

                                                case WMIEventSingleTimerReset:
                                                    operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIEventSingleTimerResetGuid, Monitors.Strings.SingleWMIMonitorStateEventRaisedGuid);
                                                    break;

                                                case WMIEventRepeatedWMIEventReset:
                                                    operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIEventRepeatedEventResetGuid, Monitors.Strings.RepeatedWMIMonitorStateEventRaisedGuid);
                                                    break;
                                            }
                                            Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Looking for Operational State: " + operationalID);
                                            operationalRowPos = FindDataRow(operationalID, viewGrid);
                                            break;
                                        }
                                    case "first event raised":
                                        operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIEventSingleEventResetGuid, Monitors.Strings.SingleWMIMonitorStateFirstEventRaisedGuid);
                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Looking for Operational State: " + operationalID);
                                        operationalRowPos = FindDataRow(operationalID, viewGrid);
                                        break;

                                    case "second event raised":
                                        operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIEventSingleEventResetGuid, Monitors.Strings.SingleWMIMonitorStateSecondEventRaisedGuid);
                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Looking for Operational State: " + operationalID);
                                        operationalRowPos = FindDataRow(operationalID, viewGrid);
                                        break;
                                    case "timer event raised":
                                        //Different monitor types have same operational state names but the Guids are different
                                        switch (selectedType)
                                        {
                                            case WMIEventSingleTimerReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIEventSingleTimerResetGuid, Monitors.Strings.SingleWMIMonitorStateTimerRaisedGuid);
                                                break;

                                            case WMIEventRepeatedTimerReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIEventRepeatedTimerResetGuid, Monitors.Strings.RepeatedWMIMonitorStateTimerRaisedGuid);
                                                break;
                                        }

                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Looking for Operational State: " + operationalID);
                                        operationalRowPos = FindDataRow(operationalID, viewGrid);
                                        break;

                                    case "repeated event raised":
                                        //Different monitor types have same operational state names but the Guids are different
                                        switch (selectedType)
                                        {
                                            case WMIEventRepeatedManualReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIEventRepeatedManualResetGuid, Monitors.Strings.RepeatedWMIMonitorStateManualRaisedGuid);
                                                break;

                                            case WMIEventRepeatedTimerReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIEventRepeatedTimerResetGuid, Monitors.Strings.RepeatedWMIMonitorStateTimerRaisedGuid);
                                                break;

                                            case WMIEventRepeatedWMIEventReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIEventRepeatedEventResetGuid, Monitors.Strings.RepeatedWMIMonitorStateEventRaisedGuid);
                                                break;
                                        }

                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Looking for Operational State: " + operationalID);
                                        operationalRowPos = FindDataRow(operationalID, viewGrid);
                                        break;
                                }

                                if (!String.IsNullOrEmpty(operationalID))
                                {
                                    operationalRowPos = FindDataRow(operationalID, viewGrid);
                                    Utilities.LogMessage(currentMethod + ": Operational ID" + operationalID);
                                }
                                else
                                {
                                    Utilities.LogMessage(currentMethod + ": Invalid health configuration data found.");
                                }

                                SetHealthState(healthConfigIterator, viewGrid, operationalRowPos);
                                break;
                        }
                    }
                    Utilities.LogMessage(currentMethod + ": Successfully set the health States");
                    healthDialog.ClickNext();
                    healthDialog.WaitForResponse();

                    #endregion

                    XPathNodeIterator alertConfigIterator = xmlNavigator.SelectSingleNode("AlertConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(currentMethod + "Event config element value " + healthConfigIterator.Current.InnerXml);

                    #region Alert Config

                    if (alertConfigIterator == null || alertConfigIterator.Count < 1)
                    {
                        throw new NullReferenceException(currentMethod + ":: Could not Create Iterator for Alert Config Elements");
                    }

                    ConfigureAlertSetting(alertConfigIterator, currentMethod);

                    #endregion

                    int retry = 0;
                    int maxcount = 120;
                    while (!CoreManager.MomConsole.MainWindow.Extended.IsForeground && retry <= maxcount)
                    {
                        Utilities.LogMessage(currentMethod + ":: MainWindow not Foreground, lets wait a moment.");
                        Sleeper.Delay(Constants.OneSecond);
                        retry++;
                    }
                    CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                    Utilities.LogMessage(currentMethod + ":: Completed the Create Monitor Wizard");
                }
                else
                {
                    Utilities.LogMessage(currentMethod + ":: XmlElement passed as input had no child elements, no methods were execute");
                }
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: Xmlelement passed as input is empty no methods execute");
            }
        }

        /// <summary>
        /// Create a WMI Performance Monitor reading configuration from the given XML.
        /// This method will navigate through the wizard to create a WMI Performance Monitor
        /// </summary>
        /// <param name="testDataXml">Name string of test data xml file</param> 
        /// <exception cref="System.NullReferenceException">NullReferenceException</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <history>
        /// [v-cheli] 23DEC08 - Created        
        /// </history>
        public void CreateWMIPerformanceMonitor(string testDataXml)
        {
            string selectedType = null;
            StringBuilder currentMethod = new StringBuilder(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            currentMethod.Append(".").Append(System.Reflection.MethodBase.GetCurrentMethod().Name);

            Utilities.LogMessage(currentMethod + "(...) Starting");

            //Load test data and select node related with current test case
            XPathNavigator xmlNavigator = LoadTestDataXml(testDataXml).SelectSingleNode(
            String.Format("//TestConfiguration/Var[@recmval='{0}']", Mcf.GetValueFromRecords("TestCases")));
            Utilities.LogMessage(currentMethod + ":: created navigator to the XML config data provided");

            #region Launch WMI Performance monitor

            LaunchCreateUnitMonitorWizard();
            Utilities.LogMessage(currentMethod + ":: Launched the Create WMI Performance Monitor Wizard for Unit Monitor");

            #endregion

            if (!xmlNavigator.IsEmptyElement)
            {
                if (xmlNavigator.HasChildren)
                {
                    XPathNodeIterator monitorTypeIterator = xmlNavigator.SelectSingleNode("MonitorType").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(currentMethod + "(...): Monitor type element value " + monitorTypeIterator.Current.InnerXml);

                    #region Monitor Type Config

                    //Create an instance for the monitor wizard
                    MonitorTypeDialog monitorTypeDialog = new MonitorTypeDialog(CoreManager.MomConsole);
                    monitorTypeDialog.ScreenElement.WaitForReady();

                    if (monitorTypeIterator == null || monitorTypeIterator.Count < 1)
                    {
                        throw new NullReferenceException(currentMethod + ":: Could not Create Iterator for General Config Elements");

                    }
                    do
                    {
                        Utilities.LogMessage(currentMethod + "monitorTypeIterator.Current.Name: " + monitorTypeIterator.Current.Name);
                        if (string.Compare(monitorTypeIterator.Current.Name, "MonitorTypeID") == 0)
                        {
                            #region Select the Monitor type

                            selectedType = monitorTypeIterator.Current.Value;
                            Utilities.LogMessage(currentMethod + ":: Monitor type specified in xml is: " + selectedType);
                            switch (selectedType)
                            {
                                case WMIPerformanceAverageThreshold:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWMIPerformanceStaticSingleGUID, MonitorTypeDialog.Strings.WMIPerformanceAverageThreshold);
                                    break;

                                case WMIPerformanceConsecutiveSamplesoverThreshold:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWMIPerformanceStaticSingleGUID, MonitorTypeDialog.Strings.WMIPerformanceConsecutiveThreshold);
                                    break;

                                case WMIPerformanceDeltaThreshold:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWMIPerformanceStaticSingleGUID, MonitorTypeDialog.Strings.WMIPerformanceDeltaThreshold);
                                    break;

                                case WMIPerformanceSimpleThreshold:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWMIPerformanceStaticSingleGUID, MonitorTypeDialog.Strings.WMIPerformanceSimpleThreshold);
                                    break;

                                case WMIPerformanceDoubleThreshold:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWMIPerformanceStaticDoubleGUID, MonitorTypeDialog.Strings.WMIPerformanceDoulbeThreshold);
                                    break;

                                default:
                                    Utilities.LogMessage(currentMethod +
                                        ":: Monitor type specified in xml is: " + selectedType + "' is invalid");
                                    throw new InvalidEnumArgumentException("Invalid Monitor Type selected");

                            }
                            #endregion
                        }
                        else
                        {
                            #region Select the MP

                            if (string.Compare(monitorTypeIterator.Current.Name, "DestinationMP") == 0)
                            {
                                Utilities.LogMessage(currentMethod + ":: Destination MP specified in xml is: " + monitorTypeIterator.Current.Value);
                                if (!String.IsNullOrEmpty(monitorTypeIterator.Current.Value))
                                {
                                    monitorTypeDialog.Controls.SelectDestinationManagementPackComboBox.SelectByText(monitorTypeIterator.Current.Value); 
                                }
                            }
                            #endregion
                        }

                    } while (monitorTypeIterator.MoveNext());

                    #region Go to the Properties page

                    //Navigate to the next page in the wizard
                    int attempt = 0;
                    int maxtries = 10;
                    while (attempt <= maxtries)
                    {
                        if (monitorTypeDialog.Controls.NextButton.IsEnabled)
                        {
	          Sleeper.Delay(Constants.OneSecond);
                            monitorTypeDialog.ClickNext();
                            Utilities.LogMessage(currentMethod + "(...)Next button is enabled - Clicked on Next button");
                            break;
                        }
                        else
                        {
                            Utilities.LogMessage(currentMethod + "(...)Next button not enabled - attemp no: " + attempt);
                            Sleeper.Delay(Constants.OneSecond);
                            attempt++;
                        }
                    }
                    #endregion

                    #endregion

                    XPathNodeIterator generalIterator = xmlNavigator.SelectSingleNode("GeneralConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(currentMethod + "(...): General config element value " + generalIterator.Current.InnerXml);

                    #region General Config

                    if (generalIterator == null || generalIterator.Count < 1)
                    {
                        throw new NullReferenceException(currentMethod +
                            ": Could not Create Iterator for General Config Elements");
                    }

                    GeneralSetting(generalIterator, currentMethod);

                    #endregion

                    XPathNodeIterator wmiConfigIterator = xmlNavigator.SelectSingleNode("WMIPerformaceConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(currentMethod + "(...): WMI Performance config element value " + wmiConfigIterator.Current.InnerXml);

                    #region WMI Performance Config

                    if ((wmiConfigIterator == null) || wmiConfigIterator.Count < 1)
                    {
                        throw new NullReferenceException(currentMethod + ": Could not create Iterator for Performance Config Elements");
                    }

                    while (wmiConfigIterator.MoveNext())
                    {
                        #region WMI Configuration

                        if (string.Compare(wmiConfigIterator.Current.Name, "WMIConfig") == 0)
                        {
                            XPathNodeIterator wmiPerformanceIterator = wmiConfigIterator.Current.SelectChildren(XPathNodeType.Element);
                            Utilities.LogMessage(currentMethod + "(...): WMI config element value " + wmiPerformanceIterator.Current.InnerXml);

                            WMIConfigurationDialog wmiConfigurationDialog = new WMIConfigurationDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitorWizard);
                            wmiConfigurationDialog.ScreenElement.WaitForReady();

                            if ((wmiPerformanceIterator != null) && (wmiPerformanceIterator.Count >= 1))
                            {
                                while (wmiPerformanceIterator.MoveNext())
                                {
                                    string currentWMIConfigValue = wmiPerformanceIterator.Current.SelectChildren(XPathNodeType.Element).Current.Value;
                                    if (currentWMIConfigValue != null)
                                    {
                                        switch (wmiPerformanceIterator.Current.Name.ToLowerInvariant())
                                        {
                                            case "wminamespace":
                                                wmiConfigurationDialog.NameSpaceText = currentWMIConfigValue;
                                                break;
                                            case "wmiquery":
                                                wmiConfigurationDialog.WMIQueryText = currentWMIConfigValue;
                                                break;
                                            case "frequency":
                                                wmiConfigurationDialog.FrequencyText = currentWMIConfigValue;
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        throw new NullReferenceException(currentMethod + ":: WMI configuration data is null.");

                                    }

                                }
                            }

                            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(wmiConfigurationDialog.Controls.NextButton, Constants.TenSeconds * 2);
                            wmiConfigurationDialog.ClickNext();
                            Utilities.LogMessage(currentMethod + "(...)Navigate to Performance Mapper page");

                        }

                        #endregion

                        #region Performance Mapper

                        else if (string.Compare(wmiConfigIterator.Current.Name, "Mapping") == 0)
                        {
                            XPathNodeIterator mapperIterator = wmiConfigIterator.Current.SelectChildren(XPathNodeType.Element);
                            Utilities.LogMessage(currentMethod + "(...): Performance Mapper element value " + mapperIterator.Current.InnerXml);

                            PerformanceMapperDialog performanceMapperDialog =
                                new PerformanceMapperDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitorWizard);
                            performanceMapperDialog.ScreenElement.WaitForReady();

                            if ((mapperIterator != null) && mapperIterator.Count >= 1)
                            {
                                while (mapperIterator.MoveNext())
                                {
                                    switch (mapperIterator.Current.Name.ToLowerInvariant())
                                    {
                                        case "object":
                                            performanceMapperDialog.ObjectText = mapperIterator.Current.Value;
                                            break;
                                        case "counter":
                                            performanceMapperDialog.CounterText = mapperIterator.Current.Value;
                                            break;
                                        case "instance":
                                            performanceMapperDialog.InstanceText = mapperIterator.Current.Value;
                                            break;
                                        case "value":
                                            performanceMapperDialog.ValueText = mapperIterator.Current.Value;
                                            break;
                                        default:
                                            Utilities.LogMessage(currentMethod + ":: Performance mapper Element specified in xml is: '" +
                                                mapperIterator.Current.Name + "' is invalid");
                                            throw new InvalidEnumArgumentException("Invalid Element selected");
                                    }

                                }
                            }
                            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(performanceMapperDialog.Controls.NextButton, Constants.TenSeconds * 2);
                            performanceMapperDialog.ClickNext();
                            Utilities.LogMessage(currentMethod + "(...)Navigate to Threshold setting page");
                        }

                        #endregion

                    }

                    #endregion

                    XPathNodeIterator thresholdSettingIterator = xmlNavigator.SelectSingleNode("ThresholdSetting").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(currentMethod + "(...): WMI Threshold Setting element value " + thresholdSettingIterator.Current.InnerXml);

                    #region Threshold Setting Config

                    //Create a new instance for Threshold setting dialog
                    ThresholdSettingsDialog thresholdSettingDialog =
                        new ThresholdSettingsDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitorWizard);
                    thresholdSettingDialog.ScreenElement.WaitForReady();

                    if ((thresholdSettingIterator == null) || thresholdSettingIterator.Count < 1)
                    {
                        throw new NullReferenceException(currentMethod +
                            ": Could not Create Iterator for Threshold Setting Elements");
                    }
                    switch (selectedType)
                    {
                        case WMIPerformanceAverageThreshold:

                            #region Average Threshold

                            while (thresholdSettingIterator.MoveNext())
                            {
                                if (string.Compare(thresholdSettingIterator.Current.Name, "ThresholdValue") == 0)
                                {
                                    Utilities.LogMessage(currentMethod +
                                    ":: Average Threshold Value specified in xml is: " + thresholdSettingIterator.Current.Value);
                                    thresholdSettingDialog.ThresholdValueText = thresholdSettingIterator.Current.Value;
                                }
                                else if (string.Compare(thresholdSettingIterator.Current.Name, "NumberOfSamples") == 0)
                                {
                                    Utilities.LogMessage(currentMethod +
                                    ":: Average Number Of Samples specified in xml is: " + thresholdSettingIterator.Current.Value);
                                    thresholdSettingDialog.NumberOfSamplesText = thresholdSettingIterator.Current.Value;
                                }
                            }
                            break;

                            #endregion

                        case WMIPerformanceConsecutiveSamplesoverThreshold:

                            #region Consecutive Samplesover Threshold

                            while (thresholdSettingIterator.MoveNext())
                            {
                                if (string.Compare(thresholdSettingIterator.Current.Name, "ThresholdValueComparator") == 0)
                                {
                                    string valueComparator = null;

                                    switch (thresholdSettingIterator.Current.Value.ToLowerInvariant())
                                    {
                                        case "greater than":
                                            valueComparator = BuildExpressionDialog.Strings.GreaterThan;
                                            break;

                                        case "greater than or equals":
                                            valueComparator = BuildExpressionDialog.Strings.GreaterThanOrEqualTo;
                                            break;

                                        case "less than":
                                            valueComparator = BuildExpressionDialog.Strings.LessThan;
                                            break;

                                        case "less than or equals":
                                            valueComparator = BuildExpressionDialog.Strings.LessThanOrEqualTo;
                                            break;
 
                                    }
                                    Utilities.LogMessage(currentMethod +
                                   ":: Consecutive Threshold Value Comparator specified in xml is: " + valueComparator);
                                    thresholdSettingDialog.Controls.Value.SelectByText(valueComparator);

                                }
                                else if (string.Compare(thresholdSettingIterator.Current.Name, "ThresholdValue") == 0)
                                {
                                    Utilities.LogMessage(currentMethod +
                                   ":: Consecutive Threshold Value specified in xml is: " + thresholdSettingIterator.Current.Value);
                                    thresholdSettingDialog.SpecifyTheNumberOfSamplesUsedToCompareWithTheThresholdText =
                                        thresholdSettingIterator.Current.Value;

                                }
                                else if (string.Compare(thresholdSettingIterator.Current.Name, "NumberOfSamples") == 0)
                                {
                                    Utilities.LogMessage(currentMethod +
                                   ":: Consecutive Number OfS amples specified in xml is: " + thresholdSettingIterator.Current.Value);
                                    thresholdSettingDialog.NumberOfSamplesText = thresholdSettingIterator.Current.Value;
                                }
                            }

                            break;

                            #endregion

                        case WMIPerformanceDeltaThreshold:

                            #region Delta Threshold

                            while (thresholdSettingIterator.MoveNext())
                            {
                                if (string.Compare(thresholdSettingIterator.Current.Name, "ThresholdValue") == 0)
                                {
                                    Utilities.LogMessage(currentMethod +
                                    ":: Delta Threshold Value specified in xml is: " + thresholdSettingIterator.Current.Value);
                                    thresholdSettingDialog.ThresholdValueText = thresholdSettingIterator.Current.Value;
                                }
                                else if (string.Compare(thresholdSettingIterator.Current.Name, "NumberOfSamples") == 0)
                                {
                                    Utilities.LogMessage(currentMethod +
                                    ":: Delta Number Of Samples specified in xml is: " + thresholdSettingIterator.Current.Value);
                                    thresholdSettingDialog.NumberOfSamplesText = thresholdSettingIterator.Current.Value;
                                }
                                else if (string.Compare(thresholdSettingIterator.Current.Name, "Percentage") == 0)
                                {
                                    Utilities.LogMessage(currentMethod +
                                    ":: Delta Percentage specified in xml is: " + thresholdSettingIterator.Current.Value);

                                    bool percentageEnabled = thresholdSettingIterator.Current.ValueAsBoolean;
                                    if ((percentageEnabled == true) && (thresholdSettingDialog.Controls.PercentageCheckBox.ButtonState != ButtonState.Checked))
                                    {
                                        thresholdSettingDialog.ClickPercentage();
                                    }
                                    else
                                    {
                                        if ((percentageEnabled == false) && (thresholdSettingDialog.Controls.PercentageCheckBox.ButtonState == ButtonState.Checked))
                                        {
                                            thresholdSettingDialog.ClickPercentage();
                                        }
                                    }
                                }
                            }
                            break;

                            #endregion

                        case WMIPerformanceSimpleThreshold:

                            #region Simple Threshold

                            while (thresholdSettingIterator.MoveNext())
                            {
                                if (string.Compare(thresholdSettingIterator.Current.Name, "ThresholdValue") == 0)
                                {
                                    Utilities.LogMessage(currentMethod +
                                    ":: Simple Threshold Value specified in xml is: " + thresholdSettingIterator.Current.Value);
                                    thresholdSettingDialog.SpecifyTheNumberOfSamplesUsedToCompareWithTheThresholdText =
                                        thresholdSettingIterator.Current.Value;
                                }
                            }

                            break;

                            #endregion

                        case WMIPerformanceDoubleThreshold:

                            #region Doulbe Threshold

                            while (thresholdSettingIterator.MoveNext())
                            {
                                if (string.Compare(thresholdSettingIterator.Current.Name, "LowValueOfThreshold") == 0)
                                {
                                    Utilities.LogMessage(currentMethod +
                                    ":: Double Threshold Low Value specified in xml is: " + thresholdSettingIterator.Current.Value);
                                    thresholdSettingDialog.LowValueOfThresholdText = thresholdSettingIterator.Current.Value;
                                }
                                else if (string.Compare(thresholdSettingIterator.Current.Name, "HighValueOfThreshold") == 0)
                                {
                                    Utilities.LogMessage(currentMethod +
                                    ":: Double Threshold High Value specified in xml is: " + thresholdSettingIterator.Current.Value);
                                    thresholdSettingDialog.HighValueOfThresholdText = thresholdSettingIterator.Current.Value;
                                }
                            }
                            Sleeper.Delay(Constants.OneSecond);
                            thresholdSettingDialog.SendKeys(KeyboardCodes.Tab);
                            break;

                            #endregion
                    }
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(thresholdSettingDialog.Controls.NextButton, Constants.TenSeconds * 2);
                    //Navigate to next page
                    thresholdSettingDialog.ClickNext();
                    Utilities.LogMessage(currentMethod + "(...)Navigate to Health Configuration page");

                    #endregion

                    XPathNodeIterator healthConfigIterator = xmlNavigator.SelectSingleNode("HealthConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(currentMethod + ": Health config element value " + healthConfigIterator.Current.InnerXml);

                    #region Health Config

                    if (healthConfigIterator == null || healthConfigIterator.Count < 1)
                    {
                        throw new NullReferenceException(currentMethod + ": Could not create Iterator for Health Config Elements");
                    }

                    //Create an instance of Configure Health Dialog 
                    ConfigureHealthDialog healthDialog = new ConfigureHealthDialog(CoreManager.MomConsole);
                    healthDialog.ScreenElement.WaitForReady();

                    //Create instance of view pane
                    MomControls.GridControl viewGrid = new MomControls.GridControl(healthDialog, 
                        ConfigureHealthDialog.ControlIDs.DataGridView1);
                    Utilities.LogMessage(currentMethod + ": Found Health Configuration Grid View");

                    while (healthConfigIterator.MoveNext())
                    {
                        switch (healthConfigIterator.Current.Name)
                        {
                            case "OperationalState":
                                int operationalRowPos = -1;

                                // Find row index according to configuration data
                                string operationalIDValue = healthConfigIterator.Current.GetAttribute("ID", "").ToLowerInvariant();
                                string operationalID = null;

                                switch (operationalIDValue)
                                {
                                    case "over threshold":
                                        //Different monitor types have same operational state names but the Guids are different
                                        switch (selectedType)
                                        {
                                            case WMIPerformanceAverageThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIPerformanceAverageThresholdGuid, Monitors.Strings.AverageWMIPerfMonitorStateOverThresholdGuid);
                                                break;
                                            case WMIPerformanceConsecutiveSamplesoverThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIPerformanceConsecutiveThresholdGuid, Monitors.Strings.ConsecutiveWMIPerfMonitorStateOverThresholdGuid);
                                                break;
                                            case WMIPerformanceDeltaThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIPerformanceDeltaThresholdGuid, Monitors.Strings.DeltaWMIPerfMonitorStateOverThresholdGuid);
                                                break;
                                            case WMIPerformanceSimpleThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIPerformanceSimpleThresholdGuid, Monitors.Strings.SimpleWMIPerfMonitorStateOverThresholdGuid);
                                                break;
                                           
                                        }
                                        break;
                                    case "under threshold":
                                        //Different monitor types have same operational state names but the Guids are different
                                        switch (selectedType)
                                        {
                                            case WMIPerformanceAverageThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIPerformanceAverageThresholdGuid, Monitors.Strings.AverageWMIPerfMnoitorStateUnderThresholdGuid);
                                                break;
                                            case WMIPerformanceConsecutiveSamplesoverThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIPerformanceConsecutiveThresholdGuid, Monitors.Strings.ConsecutiveWMIPerfMonitorStateUnderThresholdGuid);
                                                break;
                                            case WMIPerformanceDeltaThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIPerformanceDeltaThresholdGuid, Monitors.Strings.DeltaWMIPerfMonitorStateUnderThresholdGuid);
                                                break;
                                            case WMIPerformanceSimpleThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIPerformanceSimpleThresholdGuid, Monitors.Strings.SimpleWMIPerfMonitorStateUnderThresholdGuid);
                                                break;

                                        }
                                        break;
                                    case "between thresholds":
                                        operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIPerformanceDoulbeThresholdGuid, Monitors.Strings.DoubleWMIPerfMonitorStateBetweenThresholdGuid);
                                        break;
                                    case "over upper threshold":
                                        operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIPerformanceDoulbeThresholdGuid, Monitors.Strings.DoubleWMIPerfMonitorStateOverUpperThresholdGuid);
                                        break;
                                    case "under lower threshold":
                                        operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WMIPerformanceDoulbeThresholdGuid, Monitors.Strings.DoubleWMIPerfMonitorStateUnderLowerThresholdGuid);
                                        break;
                                }

                                Utilities.LogMessage(currentMethod + ":: Looking for Operational State: " + operationalID);
                                operationalRowPos = FindDataRow(operationalID, viewGrid);
                                SetHealthState(healthConfigIterator, viewGrid, operationalRowPos);
                                break;
                        }

                    }
                    Utilities.LogMessage(currentMethod + ": Successfully set the health States");
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(healthDialog.Controls.NextButton, Constants.TenSeconds * 2);

                    //Navigate to next page
                    healthDialog.Controls.NextButton.Extended.SetFocus();
                    healthDialog.ClickNext();
                    Utilities.LogMessage(currentMethod + "(...)Navigate to Alerts Configuration page");

                    #endregion

                    XPathNodeIterator alertConfigIterator = xmlNavigator.SelectSingleNode("AlertConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(currentMethod + "Alert config element value " + alertConfigIterator.Current.InnerXml);

                    #region Alert Config

                    if ((alertConfigIterator == null) || alertConfigIterator.Count < 1)
                    {
                        throw new NullReferenceException(currentMethod + ":: Could not Create Iterator for Alert Config Elements");
                    }

                    ConfigureAlertSetting(alertConfigIterator, currentMethod);

                    #endregion

                    int retry = 0;
                    int maxcount = 120;
                    while (!CoreManager.MomConsole.MainWindow.Extended.IsForeground && retry <= maxcount)
                    {
                        Utilities.LogMessage(currentMethod + ":: MainWindow not Foreground, lets wait a moment.");
                        Sleeper.Delay(Constants.OneSecond);
                        retry++;
                    }

                    CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                    Utilities.LogMessage(currentMethod + ":: Completed the Create Monitor Wizard");

                }
                else
                {
                    Utilities.LogMessage(currentMethod + ":: XmlElement passed as input had no child elements, no methods were execute");

                }
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: Xmlelement passed as input is empty no methods execute");

            }
        }


        /// <summary>
        /// Method to select the target monitor and execute context menu on it
        /// </summary>
        /// <param name="targetName">target name</param>
        /// <param name="monitorName">monitor name</param>
        /// <param name="contextMenuItems">menu items</param>
        /// <history>
        /// [v-vijia] 21MAR11 - Created
        /// </history> 
        /// <remarks>
        /// This method is to work around bug#194974. If the focus lost before executing context menu,
        /// It will select the monitor and execute context menu again.
        /// </remarks>
        public void ExecuteContextMenuForTargetMontior(string targetName, string monitorName, string[] contextMenuItems)
        {   
            int maxRetries = Constants.DefaultMaxRetry;
            int retries = 0;
            while (retries < maxRetries)
            {
                //select the monitoring wunderbar ,navigate to monitor view and will select the monitor from monitor view                
                this.SelectTargetMonitor(targetName, monitorName);

                try
                {
                    ExecuteContextMenu(contextMenuItems);
                    break;
                }
                catch (InvalidOperationException)
                {
                    retries++;
                    if (retries == maxRetries)
                    {
                        throw new Exception("Monitors.ExecuteContextMenuForTargetMonitor:: Failed to execute context menu");
                    }
                    Utilities.LogMessage("Monitors.ExecuteContextMenuForTargetMonitor:: Failed to execute context menu for monitor, try again");
                }
            }
        }

        /// <summary>
        /// Method to select target monitor and launch its Properties dialog.
        /// </summary>
        /// <param name="targetName">target name</param>
        /// <param name="monitorName">monitor name</param>
        /// <history>
        /// [v-vijia] 21MAR11 - Created
        /// </history> 
        public void LaunchMonitorPropertiesDialog(string targetName, string monitorName)
        {
            string[] menuItems = { HealthConfigurationView.Strings.ContextMenuProperties };
            ExecuteContextMenuForTargetMontior(targetName, monitorName, menuItems);

            Sleeper.Delay(Constants.OneSecond*10);
        }

        #region Windows Performance Monitor methods
        /// <summary>
        /// Enum monitor type threshold type.
        /// </summary>
        /// /// <history>
        /// [v-dayow] 19NOV09 - Created        
        /// </history>
        private enum MonitorThresholdType
        {
            StaticThreshold,
            SelfTuningThreshold
        }

        /// <summary>
        /// Create a Windows Performance Monitor reading configuration from the given XML.
        /// This method will navigate through the wizard to create a Windows Performance Monitor
        /// </summary>
        /// <param name="testDataXml">Name string of test data xml file</param> 
        /// <exception cref="System.NullReferenceException">NullReferenceException</exception>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <history>
        /// [v-dayow] 19NOV09 - Created        
        /// </history>
        public void CreateWindowsPerformanceMonitor(string testDataXml)
        {
            string selectedType = null;
            MonitorThresholdType monitorThresholdType =MonitorThresholdType.StaticThreshold;
            StringBuilder currentMethod = new StringBuilder(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            currentMethod.Append(".").Append(System.Reflection.MethodBase.GetCurrentMethod().Name);

            Utilities.LogMessage(currentMethod + ":: Starting");

            //Load test data and select node related with current test case
            XPathNavigator xmlNavigator = LoadTestDataXml(testDataXml).SelectSingleNode(
            String.Format("//TestConfiguration/Var[@recmval='{0}']", Mcf.GetValueFromRecords("TestCases")));
            Utilities.LogMessage(currentMethod + ":: created navigator to the XML config data provided");

            #region Launch Windows Performance monitor

            LaunchCreateUnitMonitorWizard();
            Utilities.LogMessage(currentMethod + ":: Launched the Create Windows Performance Monitor Wizard for Unit Monitor");

            #endregion

            if (!xmlNavigator.IsEmptyElement)
            {
                if (xmlNavigator.HasChildren)
                {
                    XPathNodeIterator monitorTypeIterator = xmlNavigator.SelectSingleNode("MonitorType").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(currentMethod + ":: Monitor type element value " + monitorTypeIterator.Current.InnerXml);

                    #region Monitor Type Config

                    //Create an instance for the monitor wizard
                    MonitorTypeDialog monitorTypeDialog = new MonitorTypeDialog(CoreManager.MomConsole);
                    monitorTypeDialog.ScreenElement.WaitForReady();

                    if (monitorTypeIterator == null || monitorTypeIterator.Count < 1)
                    {
                        throw new NullReferenceException(currentMethod + ":: Could not Create Iterator for General Config Elements");

                    }
                    do
                    {
                        Utilities.LogMessage(currentMethod + ":: monitorTypeIterator.Current.Name: " + monitorTypeIterator.Current.Name);
                        if (string.Compare(monitorTypeIterator.Current.Name, "MonitorTypeID") == 0)
                        {
                            #region Select the Monitor type

                            selectedType = monitorTypeIterator.Current.Value;
                            Utilities.LogMessage(currentMethod + ":: Monitor type specified in xml is: " + selectedType);
                            switch (selectedType)
                            {
                                case WindowsPerformance2StateAboveThreshold:
                                    monitorThresholdType = MonitorThresholdType.SelfTuningThreshold;
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsPerformanceSelfTuningGUID, MonitorTypeDialog.Strings.WindowsPerformance2StateAboveThreshold);
                                    break;

                                case WindowsPerformance2StateBaseliningThreshold:
                                    monitorThresholdType = MonitorThresholdType.SelfTuningThreshold;
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsPerformanceSelfTuningGUID, MonitorTypeDialog.Strings.WindowsPerformance2StateBaseliningThreshold);
                                    break;

                                case WindowsPerformance2StateBelowThreshold:
                                    monitorThresholdType = MonitorThresholdType.SelfTuningThreshold;
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsPerformanceSelfTuningGUID, MonitorTypeDialog.Strings.WindowsPerformance2StateBelowThreshold);
                                    break;

                                case WindowsPerformance3StateBaseliningThreshold:
                                    monitorThresholdType = MonitorThresholdType.SelfTuningThreshold;
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsPerformanceSelfTuningGUID, MonitorTypeDialog.Strings.WindowsPerformance3StateBaseliningThreshold);
                                    break;
 
                                case WindowsPerformanceAverageThreshold:
                                    monitorThresholdType = MonitorThresholdType.StaticThreshold;
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsPerformanceStaticSingleGUID, MonitorTypeDialog.Strings.WindowsPerformanceAverageThreshold);
                                    break;

                                case WindowsPerformanceConsecutiveSamplesoverThreshold:
                                    monitorThresholdType = MonitorThresholdType.StaticThreshold;
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsPerformanceStaticSingleGUID, MonitorTypeDialog.Strings.WindowsPerformanceConsecutiveThreshold);
                                    break;

                                case WindowsPerformanceDeltaThreshold:
                                    monitorThresholdType = MonitorThresholdType.StaticThreshold;
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsPerformanceStaticSingleGUID, MonitorTypeDialog.Strings.WindowsPerformanceDeltaThreshold);
                                    break;

                                case WindowsPerformanceSimpleThreshold:
                                    monitorThresholdType = MonitorThresholdType.StaticThreshold;
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsPerformanceStaticSingleGUID, MonitorTypeDialog.Strings.WindowsPerformanceSimpleThreshold);
                                    break;

                                case WindowsPerformanceDoubleThreshold:
                                    monitorThresholdType = MonitorThresholdType.StaticThreshold;
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsPerformanceStaticDoubleGUID, MonitorTypeDialog.Strings.WindowsPerformanceDoubleThreshold);
                                    break;

                                default:
                                    Utilities.LogMessage(currentMethod +
                                        ":: Monitor type specified in xml is: " + selectedType + "' is invalid");
                                    throw new InvalidEnumArgumentException("Invalid Monitor Type selected");

                            }
                            #endregion
                        }
                        else
                        {
                            #region Select the MP

                            if (string.Compare(monitorTypeIterator.Current.Name, "DestinationMP") == 0)
                            {
                                Utilities.LogMessage(currentMethod + ":: Destination MP specified in xml is: " + monitorTypeIterator.Current.Value);
                                if (!String.IsNullOrEmpty(monitorTypeIterator.Current.Value))
                                {
                                    monitorTypeDialog.Controls.SelectDestinationManagementPackComboBox.SelectByText(monitorTypeIterator.Current.Value);
                                }
                            }
                            #endregion
                        }

                    } while (monitorTypeIterator.MoveNext());

                    #region Go to the Properties page

                    //Navigate to the next page in the wizard
                    int attempt = 0;
                    int maxtries = 10;
                    while (attempt <= maxtries)
                    {
                        if (monitorTypeDialog.Controls.NextButton.IsEnabled)
                        {
                            Sleeper.Delay(Constants.OneSecond);
                            monitorTypeDialog.ClickNext();
                            Utilities.LogMessage(currentMethod + ":: Next button is enabled - Clicked on Next button");
                            break;
                        }
                        else
                        {
                            Utilities.LogMessage(currentMethod + ":: Next button not enabled - attemp no: " + attempt);
                            Sleeper.Delay(Constants.OneSecond);
                            attempt++;
                        }
                    }
                    #endregion

                    #endregion

                    XPathNodeIterator generalIterator = xmlNavigator.SelectSingleNode("GeneralConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(currentMethod + ":: General config element value " + generalIterator.Current.InnerXml);

                    #region General Config

                    if (generalIterator == null || generalIterator.Count < 1)
                    {
                        throw new NullReferenceException(currentMethod +
                            ": Could not Create Iterator for General Config Elements");
                    }

                    GeneralSetting(generalIterator, currentMethod);

                    #endregion

                    XPathNodeIterator winPerfConfigIterator = xmlNavigator.SelectSingleNode("WindowsPerformanceConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(currentMethod + ":: Windows Performance config element value " + winPerfConfigIterator.Current.InnerXml);

                    #region Windows Performance Config

                    if ((winPerfConfigIterator == null) || winPerfConfigIterator.Count < 1)
                    {
                        throw new NullReferenceException(currentMethod + ": Could not create Iterator for Performance Config Elements");
                    }

                    while (winPerfConfigIterator.MoveNext())
                    {
                        #region Windows Performance Counters Configuration

                        if (string.Compare(winPerfConfigIterator.Current.Name, "PerformanceCounterConfig") == 0)
                        {
                            XPathNodeIterator winPerformanceIterator = winPerfConfigIterator.Current.SelectChildren(XPathNodeType.Element);
                            Utilities.LogMessage(currentMethod + ":: Performance counter config element value " + winPerformanceIterator.Current.InnerXml);

                          Performance.Dialogs.PerformanceCounterDialog   perfCounterConfigurationDialog = new Performance.Dialogs.PerformanceCounterDialog(CoreManager.MomConsole,MonitoringConfiguration.WindowCaptions.MonitorWizard);
                          perfCounterConfigurationDialog.ScreenElement.WaitForReady();

                            if ((winPerformanceIterator != null) && (winPerformanceIterator.Count >= 1))
                            {
                                while (winPerformanceIterator.MoveNext())
                                {
                                    string currentWinConfigValue = winPerformanceIterator.Current.SelectChildren(XPathNodeType.Element).Current.Value;
                                    if (currentWinConfigValue != null)
                                    {
                                        switch (winPerformanceIterator.Current.Name.ToLowerInvariant())
                                        {
                                            case "object":
                                                Utilities.LogMessage(currentMethod + ":: Get Performance Object value: " + currentWinConfigValue);
                                                perfCounterConfigurationDialog.ObjectText = currentWinConfigValue;
                                                break;

                                            case "counter":
                                                Utilities.LogMessage(currentMethod + ":: Get Performance Counter value: " + currentWinConfigValue);
                                                perfCounterConfigurationDialog.CounterText = currentWinConfigValue;
                                                break;

                                            case "instance":
                                                if (winPerformanceIterator.Current.HasAttributes)
                                                {
                                                    XPathNavigator includeall = winPerformanceIterator.Current.SelectChildren(XPathNodeType.Attribute).Current;
                                                    if (includeall.Name.ToLowerInvariant() == "IncludeAll")
                                                        if (includeall.Value.ToLowerInvariant() == "true")
                                                        {
                                                            Utilities.LogMessage(currentMethod + ":: Include all instance.");
                                                            perfCounterConfigurationDialog.IncludeAllInstancesForTheSelectedCounter = true;
                                                            break;  
                                                        }
                                                }
                                                // set instance value if value of IncludeAll is false.
                                                Utilities.LogMessage(currentMethod + ":: Include value: " + currentWinConfigValue);
                                                perfCounterConfigurationDialog.InstanceText = currentWinConfigValue;
                                                break;

                                            //static thresholds monitor used only.
                                            case "intervallength":
                                                if (monitorThresholdType == MonitorThresholdType.StaticThreshold)
                                                {
                                                    Utilities.LogMessage(currentMethod + ":: Get interval length: " + currentWinConfigValue);
                                                    perfCounterConfigurationDialog.IntervalText = currentWinConfigValue;
                                                }
                                                break;

                                            //static thresholds monitor used only.
                                            case "intervalunit":
                                                if (monitorThresholdType == MonitorThresholdType.StaticThreshold)
                                                {
                                                    Utilities.LogMessage(currentMethod + ":: Get interval unit: " + currentWinConfigValue);
                                                    string valueComparator = null;
                                                    switch (currentWinConfigValue.ToLowerInvariant())
                                                    {
                                                        case "seconds":
                                                            valueComparator = PerformanceCounterDialog.Strings.Seconds; 
                                                            break;
                                                        case "minutes":
                                                            valueComparator = PerformanceCounterDialog.Strings.Minutes;
                                                            break;
                                                        case "hours":
                                                            valueComparator = PerformanceCounterDialog.Strings.Hours;
                                                            break;
                                                        case "days":
                                                            valueComparator = PerformanceCounterDialog.Strings.Seconds;
                                                            break;
                                                    }
                                                    perfCounterConfigurationDialog.IntervalUnitsText = valueComparator;
                                                }
                                                break;

                                            case "interval":
                                                //only used by self tuning thresholds monitor.
                                                if (monitorThresholdType == MonitorThresholdType.SelfTuningThreshold)
                                                {
                                                    Utilities.LogMessage(currentMethod + ":: Get interval time: " + currentWinConfigValue);
                                                    string valueComparator = null;
                                                    switch (currentWinConfigValue.ToLowerInvariant())
                                                    {
                                                        case "1 minute":
                                                            valueComparator = PerformanceCounterDialog.Strings.OneMinute;
                                                            break;
                                                        case "5 minutes":
                                                            valueComparator = PerformanceCounterDialog.Strings.FiveMinutes;
                                                            break;
                                                        case "15 minutes":
                                                            valueComparator = PerformanceCounterDialog.Strings.FifteenMinutes;
                                                            break;
                                                    }
                                                    perfCounterConfigurationDialog.STTrestrictedfrequenciesIntervalCtrlText = valueComparator;
                                                }
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        throw new NullReferenceException(currentMethod + ":: Windows configuration data is null.");
                                    }

                                }
                            }

                            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(perfCounterConfigurationDialog.Controls.NextButton, Constants.TenSeconds * 2);
                            perfCounterConfigurationDialog.ClickNext();
                            Utilities.LogMessage(currentMethod + ":: Navigate to Threshold Settings page");
                        }
                        #endregion
                    }
                    #endregion

                    XPathNavigator thresholdSetting = xmlNavigator.SelectSingleNode("ThresholdSetting");
                    if(thresholdSetting==null)
                        throw new InvalidDataException(currentMethod + ":: Could not get threshold type from Performance Config element 'ThresholdSetting'.");

                    XPathNodeIterator thresholdSettingIterator = thresholdSetting.SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(currentMethod + ":: Windows Performance Threshold Setting element value " + thresholdSettingIterator.Current.InnerXml);

                    #region Threshold Setting Config
                    switch (monitorThresholdType)
                    {
                        case MonitorThresholdType.StaticThreshold:
                            #region Static Thresholds
                            //Create a new instance for Threshold setting dialog
                            ThresholdSettingsDialog thresholdSettingDialog =
                                new ThresholdSettingsDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitorWizard);
                            thresholdSettingDialog.ScreenElement.WaitForReady();

                            if ((thresholdSettingIterator == null) || thresholdSettingIterator.Count < 1)
                            {
                                throw new NullReferenceException(currentMethod +
                                    ":: Could not Create Iterator for Threshold Setting Elements");
                            }
                            switch (selectedType)
                            {
                                case WindowsPerformanceAverageThreshold:

                                    #region Average Threshold

                                    while (thresholdSettingIterator.MoveNext())
                                    {
                                        if (string.Compare(thresholdSettingIterator.Current.Name, "ThresholdValue") == 0)
                                        {
                                            Utilities.LogMessage(currentMethod +
                                            ":: Average Threshold Value specified in xml is: " + thresholdSettingIterator.Current.Value);
                                            thresholdSettingDialog.ThresholdValueText = thresholdSettingIterator.Current.Value;
                                        }
                                        else if (string.Compare(thresholdSettingIterator.Current.Name, "NumberOfSamples") == 0)
                                        {
                                            Utilities.LogMessage(currentMethod +
                                            ":: Average Number Of Samples specified in xml is: " + thresholdSettingIterator.Current.Value);
                                            thresholdSettingDialog.NumberOfSamplesText = thresholdSettingIterator.Current.Value;
                                        }
                                    }
                                    break;
                                    #endregion

                                case WindowsPerformanceConsecutiveSamplesoverThreshold:

                                    #region Consecutive Samples over Threshold

                                    while (thresholdSettingIterator.MoveNext())
                                    {
                                        if (string.Compare(thresholdSettingIterator.Current.Name, "ThresholdValueComparator") == 0)
                                        {
                                            string valueComparator = null;

                                            switch (thresholdSettingIterator.Current.Value.ToLowerInvariant())
                                            {
                                                case "greater than":
                                                    valueComparator = ThresholdSettingsDialog.Strings.GreaterThan;
                                                    break;

                                                case "greater than or equals":
                                                    valueComparator = ThresholdSettingsDialog.Strings.GreaterThanOrEquals;
                                                    break;

                                                case "less than":
                                                    valueComparator = ThresholdSettingsDialog.Strings.LessThan;
                                                    break;

                                                case "less than or equals":
                                                    valueComparator = ThresholdSettingsDialog.Strings.LessThanOrEquals;
                                                    break;
                                            }
                                            Utilities.LogMessage(currentMethod +
                                           ":: Consecutive Threshold Value Comparator specified in xml is: " + valueComparator);
                                            thresholdSettingDialog.Controls.Value.SelectByText(valueComparator);

                                        }
                                        else if (string.Compare(thresholdSettingIterator.Current.Name, "ThresholdValue") == 0)
                                        {
                                            Utilities.LogMessage(currentMethod +
                                           ":: Consecutive Threshold Value specified in xml is: " + thresholdSettingIterator.Current.Value);
                                            thresholdSettingDialog.SpecifyTheNumberOfSamplesUsedToCompareWithTheThresholdText =
                                                thresholdSettingIterator.Current.Value;

                                        }
                                        else if (string.Compare(thresholdSettingIterator.Current.Name, "NumberOfSamples") == 0)
                                        {
                                            Utilities.LogMessage(currentMethod +
                                           ":: Consecutive Number Of Samples specified in xml is: " + thresholdSettingIterator.Current.Value);
                                            thresholdSettingDialog.NumberOfSamplesText = thresholdSettingIterator.Current.Value;
                                        }
                                    }

                                    break;

                                    #endregion

                                case WindowsPerformanceDeltaThreshold:

                                    #region Delta Threshold

                                    while (thresholdSettingIterator.MoveNext())
                                    {
                                        if (string.Compare(thresholdSettingIterator.Current.Name, "ThresholdValue") == 0)
                                        {
                                            Utilities.LogMessage(currentMethod +
                                            ":: Delta Threshold Value specified in xml is: " + thresholdSettingIterator.Current.Value);
                                            thresholdSettingDialog.ThresholdValueText = thresholdSettingIterator.Current.Value;
                                        }
                                        else if (string.Compare(thresholdSettingIterator.Current.Name, "NumberOfSamples") == 0)
                                        {
                                            Utilities.LogMessage(currentMethod +
                                            ":: Delta Number Of Samples specified in xml is: " + thresholdSettingIterator.Current.Value);
                                            thresholdSettingDialog.NumberOfSamplesText = thresholdSettingIterator.Current.Value;
                                        }
                                        else if (string.Compare(thresholdSettingIterator.Current.Name, "Percentage") == 0)
                                        {
                                            Utilities.LogMessage(currentMethod +
                                            ":: Delta Percentage specified in xml is: " + thresholdSettingIterator.Current.Value);

                                            bool percentageEnabled = thresholdSettingIterator.Current.ValueAsBoolean;
                                            if ((percentageEnabled == true) && (thresholdSettingDialog.Controls.PercentageCheckBox.ButtonState != ButtonState.Checked))
                                            {
                                                thresholdSettingDialog.ClickPercentage();
                                            }
                                            else
                                            {
                                                if ((percentageEnabled == false) && (thresholdSettingDialog.Controls.PercentageCheckBox.ButtonState == ButtonState.Checked))
                                                {
                                                    thresholdSettingDialog.ClickPercentage();
                                                }
                                            }
                                        }
                                    }
                                    break;

                                    #endregion

                                case WindowsPerformanceSimpleThreshold:

                                    #region Simple Threshold

                                    while (thresholdSettingIterator.MoveNext())
                                    {
                                        if (string.Compare(thresholdSettingIterator.Current.Name, "ThresholdValue") == 0)
                                        {
                                            Utilities.LogMessage(currentMethod +
                                            ":: Simple Threshold Value specified in xml is: " + thresholdSettingIterator.Current.Value);
                                            thresholdSettingDialog.SpecifyTheNumberOfSamplesUsedToCompareWithTheThresholdText =
                                                thresholdSettingIterator.Current.Value;
                                        }
                                    }

                                    break;

                                    #endregion

                                case WindowsPerformanceDoubleThreshold:

                                    #region Doulbe Threshold

                                    while (thresholdSettingIterator.MoveNext())
                                    {
                                        if (string.Compare(thresholdSettingIterator.Current.Name, "LowValueOfThreshold") == 0)
                                        {
                                            Utilities.LogMessage(currentMethod +
                                            ":: Double Threshold Low Value specified in xml is: " + thresholdSettingIterator.Current.Value);
                                            thresholdSettingDialog.LowValueOfThresholdText = thresholdSettingIterator.Current.Value;
                                        }
                                        else if (string.Compare(thresholdSettingIterator.Current.Name, "HighValueOfThreshold") == 0)
                                        {
                                            Utilities.LogMessage(currentMethod +
                                            ":: Double Threshold High Value specified in xml is: " + thresholdSettingIterator.Current.Value);
                                            thresholdSettingDialog.HighValueOfThresholdText = thresholdSettingIterator.Current.Value;
                                        }
                                    }
                                    Sleeper.Delay(Constants.OneSecond);
                                    thresholdSettingDialog.SendKeys(KeyboardCodes.Tab);
                                    break;

                                    #endregion
                            }
                            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(thresholdSettingDialog.Controls.NextButton, Constants.TenSeconds * 2);
                            //Navigate to next page
                            thresholdSettingDialog.ClickNext();
                            Utilities.LogMessage(currentMethod + ":: Navigate to Health Configuration page");

                            #endregion
                            break;

                        case MonitorThresholdType.SelfTuningThreshold:
                            #region SelfTuning Thresholds
                            //Create a new instance baselining setting dialog
                            BaseliningConfigurationDialog baseliningDialog =
                                new BaseliningConfigurationDialog(CoreManager.MomConsole);
                            baseliningDialog.ScreenElement.WaitForReady();

                            if ((thresholdSettingIterator == null) || thresholdSettingIterator.Count < 1)
                            {
                                throw new NullReferenceException(currentMethod +
                                    ": Could not Create Iterator for Threshold Setting Elements");
                            }
                            while (thresholdSettingIterator.MoveNext())
                            {
                                switch (thresholdSettingIterator.Current.Name.ToLowerInvariant())
                                {
                                    case "businesscyclelength":
                                        #region set business cycle length
                                        Utilities.LogMessage(currentMethod + ":: Business cycle number specified in xml is: " + thresholdSettingIterator.Current.Value);
                                        baseliningDialog.BusinessCycleLengthInGivenUnit = thresholdSettingIterator.Current.Value;
                                        break;
                                        #endregion

                                    case "businesscycleunit":
                                        #region set business cycle unit
                                        Utilities.LogMessage(currentMethod + ":: Business cycle unit specified in xml is: " + thresholdSettingIterator.Current.Value);
                                        string valueComparator = null;
                                        switch (thresholdSettingIterator.Current.Value.ToLowerInvariant())
                                        {
                                            case "week(s)":
                                                valueComparator = BaseliningConfigurationDialog.Strings.WeeksUnit;
                                                break;

                                            case "day(s)":
                                                valueComparator = BaseliningConfigurationDialog.Strings.DaysUnit;
                                                break;
                                        }
                                        baseliningDialog.BusinessCycleUnit = valueComparator;
                                        break;
                                        #endregion

                                    case "aftercyclelength":
                                        #region Generate Alerts after Business cycle length
                                        Utilities.LogMessage(currentMethod +
                                                                           ":: After Business Cycle Length specified in xml is: " + thresholdSettingIterator.Current.Value);
                                        baseliningDialog.BeginGeneratingAlertsAfterText = thresholdSettingIterator.Current.Value;
                                        break;
                                        #endregion

                                    case "sensitivity":
                                        #region Set Sensitivity
                                        Utilities.LogMessage(currentMethod +
                                                                        ":: Sensitivity specified in xml is: " + thresholdSettingIterator.Current.Value);
                                        int sensitivity = 0;
                                        if (!int.TryParse(thresholdSettingIterator.Current.Value, out sensitivity) || sensitivity <1 ||sensitivity >5)
                                            throw new InvalidDataException("Incorrect sensitivity specified. Valid value: 1~5");
                                        baseliningDialog.Controls.LowTrackBar.Position = sensitivity;
                                        break;
                                        #endregion

                                    case "advance":
                                        #region Advance baselining setting
                                        baseliningDialog.ClickAdvanced();
                                        Baselining_AdvancedDialog advanceDialog = new Baselining_AdvancedDialog(CoreManager.MomConsole);
                                        advanceDialog.ScreenElement.WaitForReady();

                                        XPathNodeIterator advanceSettings = thresholdSettingIterator.Current.SelectChildren(XPathNodeType.Element);
                                        while (advanceSettings.MoveNext())
                                        {
                                            switch (advanceSettings.Current.Name.ToLowerInvariant())
                                            {
                                                case "learningrate":
                                                    #region Set Learning Rate
                                                    Utilities.LogMessage(currentMethod +
                                                                                               ":: Learning rate specified in xml is: " + advanceSettings.Current.Value);
                                                    int learningRate = 0;
                                                    if (!int.TryParse(advanceSettings.Current.Value, out learningRate) || learningRate < 1 || learningRate > 5)
                                                        throw new InvalidDataException("Incorrect learningRate specified. Valid value: 1~5");
                                                    advanceDialog.Controls.LowTrackBar.Position = learningRate;
                                                    break;
                                                    #endregion

                                                case "timesensitivity":
                                                    #region Set Time Sensitivity
                                                    Utilities.LogMessage(currentMethod +
                                                                                                 ":: Time sensitivity specified in xml is: " + advanceSettings.Current.Value);
                                                    int timesensitivity = 0;
                                                    if (!int.TryParse(advanceSettings.Current.Value, out timesensitivity) || timesensitivity <1 || timesensitivity >5 )
                                                        throw new InvalidDataException("Incorrect learningRate specified. Valid value: 1~5");
                                                    advanceDialog.Controls.PerformanceCounterTrackBar.Position = timesensitivity;
                                                    break;
                                                    #endregion
                                            }
                                        }
                                        advanceDialog.ClickOk();
                                        break;
                                        #endregion
                                }
                            }
                            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(baseliningDialog.Controls.NextButton, Constants.TenSeconds * 2);
                            //Navigate to next page
                            baseliningDialog.ClickNext();
                            Utilities.LogMessage(currentMethod + ":: Navigate to Health Configuration page");
                            #endregion
                            break;
                    }
                    
                    #endregion

                    XPathNodeIterator healthConfigIterator = xmlNavigator.SelectSingleNode("HealthConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(currentMethod + ":: Health config element value " + healthConfigIterator.Current.InnerXml);

                    #region Health Config

                    if (healthConfigIterator == null || healthConfigIterator.Count < 1)
                    {
                        throw new NullReferenceException(currentMethod + ": Could not create Iterator for Health Config Elements");
                    }

                    //Create an instance of Configure Health Dialog 
                    ConfigureHealthDialog healthDialog = new ConfigureHealthDialog(CoreManager.MomConsole);
                    healthDialog.ScreenElement.WaitForReady();

                    //Create instance of view pane
                    MomControls.GridControl viewGrid = new MomControls.GridControl(healthDialog,
                        ConfigureHealthDialog.ControlIDs.DataGridView1);
                    Utilities.LogMessage(currentMethod + ":: Found Health Configuration Grid View");

                    while (healthConfigIterator.MoveNext())
                    {
                        switch (healthConfigIterator.Current.Name)
                        {
                            case "OperationalState":
                                int operationalRowPos = -1;

                                // Find row index according to configuration data
                                string operationalIDValue = healthConfigIterator.Current.GetAttribute("ID", "").ToLowerInvariant();
                                string operationalID = null;

                                switch (operationalIDValue)
                                {
                                    case "over threshold":
                                        //Different monitor types have same operational state names but the Guids are different
                                        switch (selectedType)
                                        {
                                            case WindowsPerformanceAverageThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformanceAverageThresholdGuid, Monitors.Strings.AverageThresholdWindowsPerfMonitorStateOverThresholdGuid);
                                                break;
                                            case WindowsPerformanceDeltaThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformanceDeltaThresholdGuid, Monitors.Strings.DeltaThresholdWindowsPerfMonitorStateOverThresholdGuid);
                                                break;
                                            case WindowsPerformanceSimpleThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformanceSimpleThresholdGuid, Monitors.Strings.SimpleThresholdWindowsPerfMonitorStateOverThresholdGuid);
                                                break;

                                        }
                                        break;
                                    case "under threshold":
                                        //Different monitor types have same operational state names but the Guids are different
                                        switch (selectedType)
                                        {
                                            case WindowsPerformanceAverageThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformanceAverageThresholdGuid, Monitors.Strings.AverageThresholdWindowsPerfMonitorStateUnderThresholdGuid);
                                                break;
                                            case WindowsPerformanceDeltaThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformanceDeltaThresholdGuid, Monitors.Strings.DeltaThresholdWindowsPerfMonitorStateUnderThresholdGuid);
                                                break;
                                            case WindowsPerformanceSimpleThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformanceSimpleThresholdGuid, Monitors.Strings.SimpleThresholdWindowsPerfMonitorStateUnderThresholdGuid);
                                                break;

                                        }
                                        break;
                                    case "between thresholds":
                                        operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformanceDoulbeThresholdGuid, Monitors.Strings.DoubleThresholdWindowsPerfMonitorStateBetweenThresholdGuid);
                                        break;
                                    case "over upper threshold":
                                        operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformanceDoulbeThresholdGuid, Monitors.Strings.DoubleThresholdWindowsPerfMonitorStateOverUpperThresholdGuid);
                                        break;
                                    case "under lower threshold":
                                        operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformanceDoulbeThresholdGuid, Monitors.Strings.DoubleThresholdWindowsPerfMonitorStateUnderLowerThresholdGuid);
                                        break;

                                    case "below envelope":
                                        switch (selectedType)
                                        {
                                            case WindowsPerformance2StateAboveThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformance2StateAboveSelfTuningThresholdGuid, Monitors.Strings.TwoStateAboveWindowsPerfMonitorStateBelowGuid);
                                                break;
                                            case WindowsPerformance2StateBelowThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformance2StateBelowSelfTuningThresholdGuid, Monitors.Strings.TwoStateBelowWindowsPerfMonitorStateBelowEnvelopeGuid);
                                                break;
                                            case WindowsPerformance3StateBaseliningThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformance3StateBaseliningSelfTuningThresholdGuid, Monitors.Strings.ThreeStateBaseliningWindowsPerfMonitorStateBelowEnvelopeGuid);
                                                break;
                                        }
                                        break;

                                    case "above envelope":
                                        switch (selectedType)
                                        {
                                            case WindowsPerformance2StateAboveThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformance2StateAboveSelfTuningThresholdGuid, Monitors.Strings.TwoStateAboveWindowsPerfMonitorStateAboveGuid);
                                                break;
                                            case WindowsPerformance2StateBaseliningThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformance2StateBaseliningSelfTuningThresholdGuid, Monitors.Strings.TwoStateBaseliningWindowsPerfMonitorStateAboveEnvelopeGuid);
                                                break;
                                            case WindowsPerformance2StateBelowThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformance2StateBelowSelfTuningThresholdGuid, Monitors.Strings.TwoStateBelowWindowsPerfMonitorStateAboveEnvelopeGuid);
                                                break;
                                            case WindowsPerformance3StateBaseliningThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformance3StateBaseliningSelfTuningThresholdGuid, Monitors.Strings.ThreeStateBaseliningWindowsPerfMonitorStateAboveEnvelopeGuid);
                                                break;
                                        }
                                        break;

                                    case "within envelope":
                                        switch (selectedType)
                                        {
                                            case WindowsPerformance2StateBaseliningThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformance2StateBaseliningSelfTuningThresholdGuid, Monitors.Strings.TwoStateBaseliningWindowsPerfMonitorStateWithinEnvelopeGuid);
                                                break;
                                            case WindowsPerformance3StateBaseliningThreshold:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformance3StateBaseliningSelfTuningThresholdGuid, Monitors.Strings.ThreeStateBaseliningWindowsPerfMonitorStateWithinEnvelopeGuid);
                                                break;
                                        } 
                                        break;

                                    case "condition false":
                                        operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformanceConsecutiveSamplesOverThresholdGuid, Monitors.Strings.ConsecutiveSamplesThresholdWindowsPerfMonitorStateConditionFalseGuid);
                                        break;

                                    case "condition true":
                                        operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.WindowsPerformanceConsecutiveSamplesOverThresholdGuid, Monitors.Strings.ConsecutiveSamplesThresholdWindowsPerfMonitorStateConditionTrueGuid);
                                        break;
                                }

                                Utilities.LogMessage(currentMethod + ":: Looking for Operational State: " + operationalID);
                                operationalRowPos = FindDataRow(operationalID, viewGrid);
                                SetHealthState(healthConfigIterator, viewGrid, operationalRowPos);
                                break;
                        }

                    }
                    Utilities.LogMessage(currentMethod + ":: Successfully set the health States");
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(healthDialog.Controls.NextButton, Constants.TenSeconds * 2);

                    //Navigate to next page
                    healthDialog.ClickNext();
                    Utilities.LogMessage(currentMethod + ":: Navigate to Alerts Configuration page");

                    #endregion

                    XPathNodeIterator alertConfigIterator = xmlNavigator.SelectSingleNode("AlertConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage(currentMethod + ":: Alert config element value " + alertConfigIterator.Current.InnerXml);

                    #region Alert Config

                    if ((alertConfigIterator == null) || alertConfigIterator.Count < 1)
                    {
                        throw new NullReferenceException(currentMethod + ":: Could not Create Iterator for Alert Config Elements");
                    }

                    ConfigureAlertSetting(alertConfigIterator, currentMethod);

                    #endregion

                    int retry = 0;
                    int maxcount = 120;
                    while (!CoreManager.MomConsole.MainWindow.Extended.IsForeground && retry <= maxcount)
                    {
                        Utilities.LogMessage(currentMethod + ":: MainWindow not Foreground, lets wait a moment.");
                        Sleeper.Delay(Constants.OneSecond);
                        retry++;
                    }

                    CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                    Utilities.LogMessage(currentMethod + ":: Completed the Create Monitor Wizard");

                }
                else
                {
                    Utilities.LogMessage(currentMethod + ":: XmlElement passed as input had no child elements, no methods were execute");

                }
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: Xmlelement passed as input is empty no methods execute");

            }
        }
        #endregion

        #region Windows Event Monitor methods

        /// <summary>
        /// This method is invoked when the XML does not match
        /// the XML Schema.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <exception cref="XmlSchemaException">XmlSchemaException</exception>
        /// <history>
        /// [ruhim] 30April07 - Created        
        /// </history>
        private void ValidationCallBack(object sender,
                                   ValidationEventArgs args)
        {
            // The xml does not match the schema.
            Utilities.LogMessage("Monitors.ValidationCallBack:: Invalid XML - XML does not match the XML Schema");
            throw new XmlSchemaException("Monitors.ValidationCallBack:: Invalid XML - XML does not match the XML Schema");
            //isValidXml = false;
            //this.ValidationError = args.Message;
        }

        /// <summary>
        /// This method is used to load the test data XML and returns 
        /// </summary>
        /// <param name="dataFileName">datafilename.xml</param>
        /// <returns>Retruns and XpathNavigator which will be used during automation</returns>
        /// <remarks> The root element for this data file is TestConfiguration</remarks>
        /// <exception cref="FileNotFoundException">FileNotFoundException</exception>
        /// <example>
        /// <TestConfiguration>
        ///     <Var/>
        /// </TestConfiguration>
        /// </example>
        /// <history>
        /// [ruhim] 30April07 - Created        
        /// </history>
        //  <exception cref="XPathException">XPathException</exception>
        public static XPathNavigator LoadTestDataXml(string dataFileName)
        {
            string currentMethod = MethodBase.GetCurrentMethod().Name;
           
            if (checked((dataFileName == null) || (dataFileName.Length < 1)))
            {
                Utilities.LogMessage(currentMethod + ":: TestData XML file name was not found.");
                throw new FileNotFoundException(currentMethod + ":: TestData XML file name was not found - " + dataFileName);
            }
            else
            {
                XPathNavigator testDataNavigator;
                XPathDocument testDataXml = new XPathDocument(@dataFileName);

                Utilities.LogMessage(currentMethod + ":: Creating Navigator into test data XML");
                testDataNavigator = testDataXml.CreateNavigator();

                if (!testDataNavigator.HasChildren || !testDataNavigator.MoveToChild(XPathNodeType.Element))
                {
                    throw new XPathException(string.Format("{0}: Test data navigator does not contain child Elements in {1}"
                        , currentMethod, dataFileName));
                }

                Utilities.LogMessage(currentMethod + ":: Finished creating Navigator into test data XML");
                return testDataNavigator;
            }
        }      

        /// <summary>
        /// Creates a Windows Event Monitor reading configuration from the given XML
        /// </summary>
        /// <param name="xmlInput">xml string or xml Data File Name contianing the monitor config</param>
        /// <param name="isXmlInputDataFile">Parameter to indicate if the string input is XML data file name or only XML content
        /// If it's data file Name then path to the file needs to be provided 
        /// </param>
        /// <param name="displayName">Return random string for display name - if the display name specified in 
        /// xml config is random then a random string is generated and returened 
        /// otherwise whatever name is supplied that will be used
        /// </param>
        /// <param name="description">Return random string for description - if the description specified in xml config is random
        /// then a random string is generated and returened otherwise whatever name is supplied that will be used
        /// </param>
        /// <exception cref="XPathException">XPathException</exception>
        /// <history>
        /// [ruhim] 12April07 - Created        
        /// </history>
        // <exception cref="System.NullReferenceException">NullReferenceException</exception>
        //  <exception cref="System.ComponentModel.InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        public void CreateWindowsEventMonitor(string xmlInput, bool isXmlInputDataFile, ref string displayName, ref string description)
        {
            XmlDocument xdoc = new XmlDocument();
            XPathNavigator xmlNavigator;

            if (isXmlInputDataFile)
            {
                Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Input provided is XML DataFile Name - " + xmlInput);

                //validate the xml document against the Schema            
                //Had 2 create 2 seperate Schema files - single one won't work for file input and only xml string input
                xdoc.Load(xmlInput);
                xdoc.Schemas.Add(null, EventMonitorSchema);
                ValidationEventHandler veh = new ValidationEventHandler(ValidationCallBack);
                xdoc.Validate(veh);
               
                xmlNavigator = LoadTestDataXml(xmlInput).SelectSingleNode(
                String.Format("//TestConfiguration/Var[@recmval='{0}']", Mcf.GetValueFromRecords("TestCases")));
                Utilities.LogMessage(string.Format("Starting execution of test case {0}", Mcf.GetValueFromRecords("TestCases")));
            }
            else
            {
                //validate the xml fragment against the Schema             
                xdoc.LoadXml(xmlInput);
                xdoc.Schemas.Add(null, EventMonitorFragmentSchema);
                ValidationEventHandler veh = new ValidationEventHandler(ValidationCallBack);
                xdoc.Validate(veh);            

                xmlNavigator = xdoc.CreateNavigator();

                if (!xmlNavigator.HasChildren || !xmlNavigator.MoveToChild(XPathNodeType.Element))
                {
                    throw new XPathException("Monitors.CreateWindowsEventMonitor:: Test data navigator does not contain child Elements");
                }
                Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Successfully Created Navigator to the XML config data provided");
            }

            CreateWindowsEventMonitor(xmlNavigator, ref displayName, ref description);
        }

        /// <summary>
        /// Creates a Windows Event Monitor reading configuration from the given XML
        /// </summary>
        /// <param name="xmlNavigator">XPathNavigator pointing to xml containing monitor config</param> 
        /// <param name="displayName">Return random string for display name</param>
        /// <param name="description">Return rnadom string for description</param>
        /// <exception cref="System.NullReferenceException">NullReferenceException</exception>
        /// <history>
        /// [ruhim] 12April07 - Created        
        /// </history>
        //  <exception cref="System.ComponentModel.InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        public void CreateWindowsEventMonitor(XPathNavigator xmlNavigator, ref string displayName, ref string description)
        {
            string selectedType = null;
            StringBuilder currentMethod = new StringBuilder(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            currentMethod.Append(".").Append(System.Reflection.MethodBase.GetCurrentMethod().Name);

            #region Launch Create wizard

            Utilities.LogMessage("CreateWindowsEventMonitor(...)");
    
            LaunchCreateUnitMonitorWizard();
            Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Successfully Launched the Create Monitor Wizard for Unit Monitor");             

            #endregion

            if (!xmlNavigator.IsEmptyElement)
            {
                if (xmlNavigator.HasChildren)
                {
                    XPathNodeIterator monitorTypeIterator = xmlNavigator.SelectSingleNode("MonitorType").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Monitor Type element value " + monitorTypeIterator.Current.InnerXml);

                    #region Monitor Type

                    //Create an instance of the first screen of the monitor wizard
                    MonitorTypeDialog montiorTypeDialog = new MonitorTypeDialog(CoreManager.MomConsole);
                    montiorTypeDialog.ScreenElement.WaitForReady();

                    if (monitorTypeIterator == null)
                    {
                        throw new NullReferenceException("Create: Could not Create Iterator for General Config Elements");
                    }
                    else if (checked(monitorTypeIterator.Count < 1))
                    {
                        throw new NullReferenceException(string.Format("Create: No. of General Config Child Elements cannot be of count: {0} must be greater or equal to 1", monitorTypeIterator.Count));
                    }
                    do 
                    {
                        Utilities.LogMessage("monitorTypeIterator.Current.Name: " + monitorTypeIterator.Current.Name);
                        if (string.Compare(monitorTypeIterator.Current.Name, "MonitorTypeID") == 0)
                        {                            
                            selectedType = monitorTypeIterator.Current.Value;
                            Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Monitor Type specified in xml is: " + selectedType);
                            switch (selectedType)
                            {
                                case WindowsEventsSimpleEventDetectionManualReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsEventLogSimpleGUID, MonitorTypeDialog.Strings.EventMonitorSingleManual);
                                    break;

                                case WindowsEventsSimpleEventDetectionWindowsEventReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsEventLogSimpleGUID, MonitorTypeDialog.Strings.EventMonitorSingleEventEventReset);
                                    break;

                                case WindowsEventsSimpleEventDetectionTimerReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsEventLogSimpleGUID, MonitorTypeDialog.Strings.EventMonitorSingleEventAutoReset);
                                    break;

                                case WindowsEventsCorrelatedEventDetectionManualReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsEventLogCorrelatedGUID, MonitorTypeDialog.Strings.CorrelatedEventManualReset);
                                    break;

                                case WindowsEventsCorrelatedEventDetectionTimerReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsEventLogCorrelatedGUID, MonitorTypeDialog.Strings.CorrelatedEventTimerReset);
                                    break;

                                case WindowsEventsCorrelatedEventDetectionEventReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsEventLogCorrelatedGUID, MonitorTypeDialog.Strings.CorrelatedEventEventReset);
                                    break;

                                case WindowsEventsCorrelatedMissingEventDetectionManualReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsEventLogMissingCorrelatedGUID, MonitorTypeDialog.Strings.CorrelatedMissingEventManualReset);
                                    break;

                                case WindowsEventsCorrelatedMissingEventDetectionTimerReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsEventLogMissingCorrelatedGUID, MonitorTypeDialog.Strings.CorrelatedMissingEventTimerReset);
                                    break;

                                case WindowsEventsCorrelatedMissingEventDetectionEventReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsEventLogMissingCorrelatedGUID, MonitorTypeDialog.Strings.CorrelatedMissingEventEventReset);
                                    break;

                                    case WindowsEventsMissingEventDetectionManualReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsEventLogMissingGUID, MonitorTypeDialog.Strings.MissingEventManualReset);
                                    break;

                                case WindowsEventsMissingEventDetectionTimerReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsEventLogMissingGUID, MonitorTypeDialog.Strings.MissingEventTimerReset);
                                    break;

                                case WindowsEventsMissingEventDetectionEventReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsEventLogMissingGUID, MonitorTypeDialog.Strings.MissingEventEventReset);
                                    break;

                                    case WindowsEventsRepeatedEventDetectionManualReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsEventLogRepeatedGUID, MonitorTypeDialog.Strings.RepeatedEventManualReset);
                                    break;

                                case WindowsEventsRepeatedEventDetectionTimerReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsEventLogRepeatedGUID, MonitorTypeDialog.Strings.RepeatedEventTimerReset);
                                    break;

                                case WindowsEventsRepeatedEventDetectionEventReset:
                                    SelectMonitorType(Monitors.Strings.MonitorTypeFolderWindowsEventLogRepeatedGUID, MonitorTypeDialog.Strings.RepeatedEventEventReset);
                                    break;

                                default:
                                    Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Monitor Type specified in xml is: " +
                                        selectedType + "' is invalid");
                                    throw new InvalidEnumArgumentException("Invalid Monitor Type selected");
                            }
                        }
                        else
                        {                            
                            if (string.Compare(monitorTypeIterator.Current.Name, "DestinationMP") == 0)
                            {                             
                                Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Destination MP specified in xml is: " + monitorTypeIterator.Current.Value);
                                montiorTypeDialog.Controls.SelectDestinationManagementPackComboBox.SelectByText(monitorTypeIterator.Current.Value);
                            }                            
                        }                       
                    }
                    while (monitorTypeIterator.MoveNext());

                    //Go to the newxt page in the wizard i.e. General Properties page
                    //int attempt = 0;
                    //int maxtries = 10;
                    //while (attempt <= maxtries)
                    //{
                    //    if (montiorTypeDialog.Controls.NextButton.IsEnabled)
                    //    {
                    //        montiorTypeDialog.ClickNext();
                    //        Utilities.LogMessage("Next button is enabled - Clicked on Next button");
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        Utilities.LogMessage("Next button not enabled - attemp no: " + attempt);
                    //        Sleeper.Delay(Constants.OneSecond);
                    //        attempt++;
                    //    }
                    //}
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(montiorTypeDialog.Controls.NextButton, Constants.TenSeconds * 2);
                    Utilities.LogMessage("Next button is enabled - Clicked on Next button");
                    montiorTypeDialog.ClickNext();

                    #endregion
                                        
                    XPathNodeIterator generalIterator = xmlNavigator.SelectSingleNode("GeneralConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: General Config element value " + generalIterator.Current.InnerXml);

                    #region General Config

                    if (generalIterator == null)
                    {
                        throw new NullReferenceException("Create: Could not Create Iterator for General Config Elements");
                    }
                    else if (checked(generalIterator.Count < 1))
                    {
                        throw new NullReferenceException(string.Format("Create: No. of General Config Child Elements cannot be of count: {0} must be greater or equal to 1", generalIterator.Count));
                    }

                    GeneralSetting(generalIterator, currentMethod, ref displayName, ref description);

                    #endregion

                    XPathNodeIterator eventConfigIterator = xmlNavigator.SelectSingleNode("EventConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Event Config element value " + eventConfigIterator.Current.InnerXml);
                    
                    #region Event Expression Config

                    if (eventConfigIterator == null)
                    {
                        throw new NullReferenceException("Monitors.CreateWindowsEventMonitor: Could not Create Iterator for Event Config Elements");
                    }
                    else if (checked(eventConfigIterator.Count < 1))
                    {
                        throw new NullReferenceException(string.Format("Monitors.CreateWindowsEventMonitor:: No. of Event Config Child Elements cannot be of count: {0} must be greater or equal to 1", eventConfigIterator.Count));
                    }                   

                    while (eventConfigIterator.MoveNext())
                    {                       
                        if (string.Compare(eventConfigIterator.Current.Name, "EventLogs") == 0)
                        {
                            int logCount = 0;
                            logCount = int.Parse(eventConfigIterator.Current.GetAttribute("count", ""));
                            Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Number of EventLogs specified is " + logCount.ToString());
                                                        
                            XPathNodeIterator eventLogIterator = eventConfigIterator.Current.SelectChildren(XPathNodeType.Element);
                            
                            #region LogName/Expression Config

                            if (eventLogIterator != null && (eventLogIterator.Count > 1))
                            {
                                while (eventLogIterator.MoveNext())
                                {
                                    switch (eventLogIterator.Current.Name)
                                    {
                                        case "LogName":
                                            //Create an instance of the LogName screen of the monitor wizard
                                            LogNameDialog logNameDialog =
                                                new LogNameDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitorWizard);
                                            logNameDialog.ScreenElement.WaitForReady();

                                            //Click on the browse button
                                            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(logNameDialog.Controls.Button1, Constants.OneMinute / 1000);
                                            logNameDialog.ClickButton1();

                                            //Create an instance of the select event log screen
                                            SelectEventLogDialog selectLog = new SelectEventLogDialog();
                                            selectLog.ScreenElement.WaitForReady();

                                            Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Log Name specified is " + eventLogIterator.Current.Value);
                                            int attemptNo = 0;
                                            int MaxAttempt = 3;
                                            while (attemptNo < MaxAttempt)
                                            {
                                                try
                                                {
                                                    selectLog.Extended.SetFocus();
                                                    selectLog.Controls.EventLogNameListView.MultiSelect(eventLogIterator.Current.Value);
                                                    Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Successfully selected Log Name " + eventLogIterator.Current.Value);
                                                    selectLog.ScreenElement.WaitForReady();
                                                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(selectLog.Controls.OKButton, Constants.OneMinute / 1000);
                                                    selectLog.ClickOK();
                                                    break;
                                                }
                                                catch (Window.Exceptions.UnknownActiveWinException)
                                                {
                                                    Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: failed to select log name in SelectEventLogDialog");
                                                    attemptNo++;                                                    
                                                }
                                            }

                                            logNameDialog.Extended.SetFocus();
                                            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(logNameDialog.Controls.NextButton, Constants.OneMinute / 1000);
                                            logNameDialog.ClickNext();

                                            //only decrement the log count once when the log name is found
                                            //logCount--;
                                            break;

                                        case "Expression":
                                            XPathNodeIterator expressionIterator = eventLogIterator.Current.SelectChildren(XPathNodeType.Element);
                                            Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Expression element value " + expressionIterator.Current.InnerXml);

                                            //Create an instance of Expression builder
                                            BuildExpressionDialog buildExpression =
                                                new BuildExpressionDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitorWizard);
                                            buildExpression.ScreenElement.WaitForReady();

                                            //Create instance of Formula Grid Control
                                            Core.Console.MomControls.GridControl formulaGrid = new Core.Console.MomControls.GridControl(buildExpression,
                                            Core.Console.MomControls.GridControl.ControlIDs.FormulaGrid);                                                                                      

                                            if (formulaGrid != null)
                                            {
                                                Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: FormulaGrid found");

                                                // Get the Index position of all the three Header Columns
                                                int colposParameterName = formulaGrid.GetColumnTitlePosition(BuildExpressionDialog.Strings.GridParameterNameColumn);
                                                int colposOperator = formulaGrid.GetColumnTitlePosition(BuildExpressionDialog.Strings.GridOperatorColumn);
                                                int colposValue = formulaGrid.GetColumnTitlePosition(BuildExpressionDialog.Strings.GridValueColumn);
                                                //Starting Row Index
                                                int rowIndex = 1;

                                                //Delete the existing expression then add new one
                                                formulaGrid.ClickCell(rowIndex, colposParameterName);
                                                CoreManager.MomConsole.InvokeToolBarButton(buildExpression.Controls.FormulaToolStrip,
                                                            BuildExpressionDialog.Strings.FormulaToolStripDelete);

                                                if (expressionIterator != null && (expressionIterator.Count > 1))
                                                {
                                                    while (expressionIterator.MoveNext())
                                                    {
                                                        switch (expressionIterator.Current.Name)
                                                        {
                                                            case "Parameter":
                                                                //Insert for new parameter
                                                                CoreManager.MomConsole.InvokeToolBarButton(buildExpression.Controls.FormulaToolStrip, BuildExpressionDialog.Strings.FormulaToolStripInsert);
                                                                Keyboard.SendKeys(KeyboardCodes.Tab);
                                                                Keyboard.SendKeys(KeyboardCodes.Enter);
                                                                formulaGrid.ClickCell(rowIndex, colposParameterName);
                                                                formulaGrid.InvokeCellButton(rowIndex, colposParameterName);
                                                                EventPropertyCellEditorFormDialog eventPropertyDialog = new EventPropertyCellEditorFormDialog(CoreManager.MomConsole);
                                                                eventPropertyDialog.ScreenElement.WaitForReady();

                                                                switch (expressionIterator.Current.Value.ToLowerInvariant())
                                                                {
                                                                    case "event id":
                                                                        eventPropertyDialog.EventPropertiesText = BuildExpressionDialog.Strings.EventID;
                                                                        break;

                                                                    case "event category":
                                                                        eventPropertyDialog.EventPropertiesText = BuildExpressionDialog.Strings.EventCategory;
                                                                        break;

                                                                    case "event level":
                                                                        eventPropertyDialog.EventPropertiesText = BuildExpressionDialog.Strings.EventLevel;
                                                                        break;

                                                                    case "full event number":
                                                                        eventPropertyDialog.EventPropertiesText = BuildExpressionDialog.Strings.FullEventNumber;
                                                                        break;

                                                                    case "logging computer":
                                                                        eventPropertyDialog.EventPropertiesText = BuildExpressionDialog.Strings.LoggingComputer;
                                                                        break;

                                                                    case "logname channel":
                                                                        eventPropertyDialog.EventPropertiesText = BuildExpressionDialog.Strings.LognameChannel;
                                                                        break;

                                                                    case "user":
                                                                        eventPropertyDialog.EventPropertiesText = BuildExpressionDialog.Strings.User;
                                                                        break;

                                                                    case "event source":
                                                                        eventPropertyDialog.EventPropertiesText = BuildExpressionDialog.Strings.EventSource;
                                                                        break;
                                                                }
                                                                
                                                                //Didn't find ClickOk button so sending enter
                                                                eventPropertyDialog.SendKeys(KeyboardCodes.Enter);                                                            
                                                                break;

                                                            case "Operator":
                                                                formulaGrid.ClickCell(rowIndex, colposOperator);
                                                                string setOperator = null;

                                                                switch (expressionIterator.Current.Value.ToLowerInvariant())
                                                                {
                                                                    case "equals":
                                                                        setOperator = BuildExpressionDialog.Strings.Equality;
                                                                        break;

                                                                    case "does not equal":
                                                                        setOperator = BuildExpressionDialog.Strings.NotEquals;
                                                                        break;

                                                                    case "greater than":
                                                                        setOperator = BuildExpressionDialog.Strings.GreaterThan;
                                                                        break;

                                                                    case "greater than or equal to":
                                                                        setOperator = BuildExpressionDialog.Strings.GreaterThanOrEqualTo;
                                                                        break;

                                                                    case "less than":
                                                                        setOperator = BuildExpressionDialog.Strings.LessThan;
                                                                        break;

                                                                    case "less than or equal to":
                                                                        setOperator = BuildExpressionDialog.Strings.LessThanOrEqualTo;
                                                                        break;

                                                                    case "contains":
                                                                        setOperator = BuildExpressionDialog.Strings.Contains;
                                                                        break;

                                                                    case "does not contain":
                                                                        setOperator = BuildExpressionDialog.Strings.NotContains;
                                                                        break;
                                                                }

                                                                // Set operator value in cell
                                                                formulaGrid.SetCellValue(formulaGrid, setOperator, DataGridViewCellType.ComboBox, Events.Events.Strings.OperatorComboBoxEditorWinFormsId);
                                                                break;

                                                            case "Value":
                                                                formulaGrid.ClickCell(rowIndex, colposValue);
                                                                
                                                                //Set Value in cell - need to special case Event Level since it's the only combo box
                                                                if (string.Compare(formulaGrid.GetCellValue(rowIndex, colposParameterName), "Event Level", true) == 0)
                                                                {
                                                                    throw new NotImplementedException("Can't access the combo box - need winforms ID - Bug 97555");
                                                                    //formulaGrid.SetCellValue(formulaGrid.Extended.AccessibleObject.Window, expressionIterator.Current.Value, DataGridViewCellType.ComboBox, "");
                                                                    //formulaGrid.SetCellValue(rowIndex, colposValue, expressionIterator.Current.Value, DataGridViewCellType.ComboBox);
                                                                }
                                                                else
                                                                {
                                                                    formulaGrid.SetCellValue(formulaGrid.Extended.AccessibleObject.Window, expressionIterator.Current.Value, DataGridViewCellType.TextBox, Events.Events.Strings.TextEditorWinFormsId);
                                                                }
                                                                //Need to special case when rowIndex is 1 because it adds a extra line for And Group
                                                                if (rowIndex == 1)
                                                                {
                                                                    rowIndex++;
                                                                }

                                                                rowIndex++;                                                                 
                                                                break;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    throw new NullReferenceException(string.Format("Monitors.CreateWindowsEventMonitor:: No. of Expression Child Elements cannot be of count: {0} must be greater or equal to 1", expressionIterator.Count));
                                                }
                                            }// end of if 

                                            buildExpression.Controls.NextButton.Extended.SetFocus();
                                            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(buildExpression.Controls.NextButton, Constants.OneMinute / 1000);
                                            buildExpression.ClickNext();
                                            break;
                                    }
                                }
                            }//end of if statement
                            else
                            {
                                throw new NullReferenceException(string.Format("Monitors.CreateWindowsEventMonitor:: No. of EventLogs Child Elements cannot be of count: {0} must be greater or equal to 1", eventLogIterator.Count));
                            }
                            #endregion
                        }                                                                      
                    }

                    #endregion

                    #region Code specific to Monitor Type

                    switch (selectedType)
                    {
                        case WindowsEventsCorrelatedEventDetectionManualReset:
                        case WindowsEventsCorrelatedEventDetectionTimerReset:
                        case WindowsEventsCorrelatedEventDetectionEventReset:
                        case WindowsEventsCorrelatedMissingEventDetectionManualReset:
                        case WindowsEventsCorrelatedMissingEventDetectionTimerReset:
                        case WindowsEventsCorrelatedMissingEventDetectionEventReset:
                            CorrelatedEventsConfigurationDialog correlationDialog = new CorrelatedEventsConfigurationDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitorWizard);
                            correlationDialog.ScreenElement.WaitForReady();

                            #region Correlation Config

                            XPathNodeIterator correlationConfigIterator = xmlNavigator.SelectSingleNode("CorrelationConfig").SelectChildren(XPathNodeType.Element);
                            Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Correlation Config element value " + correlationConfigIterator.Current.InnerXml);

                            if (correlationConfigIterator == null)
                            {
                                throw new NullReferenceException("Monitors.CreateWindowsEventMonitor:: Could not Create Iterator for Correlation Config Elements");
                            }
                            else if (checked(correlationConfigIterator.Count < 1))
                            {
                                throw new NullReferenceException(string.Format("Monitors.CreateWindowsEventMonitor:: No. of Correlation Config Child Elements cannot be of count: {0} must be greater or equal to 1", correlationConfigIterator.Count));
                            }

                            while (correlationConfigIterator.MoveNext())
                            {
                                switch (correlationConfigIterator.Current.Name)
                                {
                                    case "CorrelationInterval":
                                        //If value is not specified then go with the defaults on the page
                                        if (correlationConfigIterator.Current.Value != null)
                                        {
                                            correlationDialog.CorrelationIntervalText = correlationConfigIterator.Current.Value; 

                                            string timerUnit = null;
                                            timerUnit = correlationConfigIterator.Current.GetAttribute("unit", "");
                                            //get the display string for timer unit
                                            switch (timerUnit.ToLowerInvariant())
                                            {
                                                case "seconds":
                                                    correlationDialog.SpecifyCorrelationUnitsComboBoxText = AutoResetTimerDialog.Strings.SecondsTimerUnit;
                                                    break;

                                                case "minutes":
                                                    correlationDialog.SpecifyCorrelationUnitsComboBoxText = AutoResetTimerDialog.Strings.MinutesTimerUnit;
                                                    break;

                                                case "hours":
                                                    correlationDialog.SpecifyCorrelationUnitsComboBoxText = AutoResetTimerDialog.Strings.HoursTimerUnit;
                                                    break;

                                                case "days":
                                                    correlationDialog.SpecifyCorrelationUnitsComboBoxText = AutoResetTimerDialog.Strings.DaysTimerUnit;
                                                    break;
                                            }
                                        }
                                        break;

                                    case "CorrelateWhen":
                                        //If value is not specified then go with the defaults on the page
                                        if (correlationConfigIterator.Current.Value != null)
                                        {
                                            switch (correlationConfigIterator.Current.Value.ToLowerInvariant())
                                            {
                                                case "the first occurrence of a with the configured occurrence of b in chronological order":
                                                    correlationDialog.CorrelateWhenComboBoxText = CorrelatedEventsConfigurationDialog.Strings.FirstAChronologicalOrder;
                                                    break;

                                                case "the last occurrence of a with the configured occurrence of b in chronological order":
                                                    correlationDialog.CorrelateWhenComboBoxText = CorrelatedEventsConfigurationDialog.Strings.LastAChronologicalOrder;
                                                    break;

                                                case "the first occurrence of a with the configured occurrence of b, or vice versa":
                                                    correlationDialog.CorrelateWhenComboBoxText = CorrelatedEventsConfigurationDialog.Strings.FirstAViseVersa;
                                                    break;

                                                case "the last occurrence of a with the configured occurrence of b, or vice versa":
                                                    correlationDialog.CorrelateWhenComboBoxText = CorrelatedEventsConfigurationDialog.Strings.LastAViseVersa;
                                                    break;

                                                case "the first occurrence of a with the configured occurrence of b happens, enable interval restart":
                                                    correlationDialog.CorrelateWhenComboBoxText = CorrelatedEventsConfigurationDialog.Strings.FirstAEnableIntervalRestart;
                                                    break;

                                                default:
                                                    Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Correlate When ComboBox Text specified is " +
                                                        correlationConfigIterator.Current.Value.ToLowerInvariant());
                                                    throw new InvalidEnumArgumentException("Invalid Correlate When ComboBox Text specified");                                                   
                                            }
                                        }
                                        break;
                                }
                            }
                            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(correlationDialog.Controls.NextButton, Constants.OneMinute / 1000);
                            correlationDialog.ClickNext();
                           
                            #endregion
                            break;
                    }

                    switch (selectedType)
                    {
                        case WindowsEventsRepeatedEventDetectionManualReset:
                        case WindowsEventsRepeatedEventDetectionTimerReset:
                        case WindowsEventsRepeatedEventDetectionEventReset:
                        case WindowsEventsMissingEventDetectionManualReset:
                        case WindowsEventsMissingEventDetectionTimerReset:
                        case WindowsEventsMissingEventDetectionEventReset:
                            ConsolidationSettingsDialog consolidationDialog = new ConsolidationSettingsDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitorWizard);
                            consolidationDialog.ScreenElement.WaitForReady();

                        #region Consolidation Settings                            

                            XPathNodeIterator consolidationIterator = xmlNavigator.SelectSingleNode("ConsolidationSettings").SelectChildren(XPathNodeType.Element);
                            Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Consolidation Settings element value " + consolidationIterator.Current.InnerXml);

                            if (consolidationIterator == null)
                            {
                                throw new NullReferenceException("Monitors.CreateWindowsEventMonitor:: Could not Create Iterator for Consolidation Settings Elements");
                            }
                            else if (checked(consolidationIterator.Count < 1))
                            {
                                throw new NullReferenceException(string.Format("Monitors.CreateWindowsEventMonitor:: No. of Consolidation Settings Child Elements cannot be of count: {0} must be greater or equal to 1", consolidationIterator.Count));
                            }

                            while (consolidationIterator.MoveNext())
                            {
                                switch (consolidationIterator.Current.Name)
                                {
                                    case "CountingMode":
                                        //If value is not specified then go with the defaults on the page
                                        if (consolidationIterator.Current.Value != null)
                                        {
                                            switch (consolidationIterator.Current.Value.ToLowerInvariant())
                                            {
                                                case "trigger on count":
                                                    consolidationDialog.CountingModeComboBoxText = ConsolidationSettingsDialog.Strings.TriggeronCount;
                                                    consolidationDialog.CompareCountText = consolidationIterator.Current.GetAttribute("count", "");
                                                    break;

                                                case "trigger on timer":
                                                    consolidationDialog.CountingModeComboBoxText = ConsolidationSettingsDialog.Strings.TriggeronTimer;
                                                    break;

                                                case "trigger on count, sliding":
                                                    consolidationDialog.CountingModeComboBoxText = ConsolidationSettingsDialog.Strings.TriggeronCountSliding;
                                                    consolidationDialog.CompareCountText = consolidationIterator.Current.GetAttribute("count", "");
                                                    break;
                                            }
                                        }
                                        break;

                                    case "TimeControl":
                                        XPathNodeIterator timeControlIterator = consolidationIterator.Current.SelectChildren(XPathNodeType.Element);
                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Time Control element value " + timeControlIterator.Current.InnerXml);

                                        if (timeControlIterator != null && (timeControlIterator.Count >= 1))
                                        {                                            
                                            do
                                            {                                                
                                                switch (timeControlIterator.Current.Name)
                                                {
                                                    case "WithinTimeSchedule":
                                                        //select the radio button
                                                        if (consolidationDialog.Controls.BasedOnItemsOccurenceWithinATimeIntervalRadioButton.ButtonState != ButtonState.Checked)
                                                        {
                                                            consolidationDialog.Controls.BasedOnItemsOccurenceWithinATimeIntervalRadioButton.Click();
                                                        }

                                                        XPathNodeIterator withinTimeScheduleIterator = timeControlIterator.Current.SelectChildren(XPathNodeType.Element);
                                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: WithinTimeSchedule element value " + withinTimeScheduleIterator.Current.InnerXml);

                                                        if (withinTimeScheduleIterator != null && (withinTimeScheduleIterator.Count >= 1))
                                                        {
                                                            while (withinTimeScheduleIterator.MoveNext())
                                                            {                                                                
                                                                if (string.Compare(withinTimeScheduleIterator.Current.Name, "Interval") == 0)
                                                                {                                                                    
                                                                    consolidationDialog.IntervalText = withinTimeScheduleIterator.Current.Value;
                                                                   
                                                                    string timerUnit = null;
                                                                    timerUnit = withinTimeScheduleIterator.Current.GetAttribute("unit", "");
                                                                    //get the display string for timer unit
                                                                    switch (timerUnit.ToLowerInvariant())
                                                                    {
                                                                        case "seconds":
                                                                            consolidationDialog.IntervalUnitComboBoxText = AutoResetTimerDialog.Strings.SecondsTimerUnit;
                                                                            break;

                                                                        case "minutes":
                                                                            consolidationDialog.IntervalUnitComboBoxText = AutoResetTimerDialog.Strings.MinutesTimerUnit;
                                                                            break;

                                                                        case "hours":
                                                                            consolidationDialog.IntervalUnitComboBoxText = AutoResetTimerDialog.Strings.HoursTimerUnit;
                                                                            break;

                                                                        case "days":
                                                                            consolidationDialog.IntervalUnitComboBoxText = AutoResetTimerDialog.Strings.DaysTimerUnit;
                                                                            break;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        break;

                                                    case "WeeklySchedule":
                                                        //select the radio button
                                                        if (consolidationDialog.Controls.BasedOnFixedWeeklyScheduleRadioButton.ButtonState != ButtonState.Checked)
                                                        {
                                                            consolidationDialog.Controls.BasedOnFixedWeeklyScheduleRadioButton.Click();
                                                        }

                                                        //Launch the Select Time Range dialog
                                                        CoreManager.MomConsole.InvokeToolBarButton(consolidationDialog.Controls.AddRemoveToolStrip,
                                                            ConsolidationSettingsDialog.Strings.AddToolStripButton);

                                                        SelectTimeRangeDialog timeRangeDialog = new SelectTimeRangeDialog(CoreManager.MomConsole);
                                                        timeRangeDialog.ScreenElement.WaitForReady();

                                                        XPathNodeIterator weeklyScheduleIterator = timeControlIterator.Current.SelectChildren(XPathNodeType.Element);
                                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: WeeklySchedule element value " + weeklyScheduleIterator.Current.InnerXml);

                                                        if (weeklyScheduleIterator != null && (weeklyScheduleIterator.Count >= 1))
                                                        {
                                                            while (weeklyScheduleIterator.MoveNext())
                                                            {
                                                                switch (weeklyScheduleIterator.Current.Name)
                                                                {
                                                                    case "Daily":                                                                        
                                                                        if (timeRangeDialog.Controls.DailyRadioButton.ButtonState != ButtonState.Checked)
                                                                        {
                                                                            timeRangeDialog.Controls.DailyRadioButton.Click();
                                                                            Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Daily Time Range selected");
                                                                        }
                                                                        XPathNodeIterator dailyIterator = weeklyScheduleIterator.Current.SelectChildren(XPathNodeType.Element);
                                                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Daily element value " + dailyIterator.Current.InnerXml);

                                                                        if (dailyIterator != null && (dailyIterator.Count >= 1))
                                                                        {
                                                                            while (dailyIterator.MoveNext())
                                                                            {
                                                                                switch (dailyIterator.Current.Name)
                                                                                {
                                                                                    case "Start":
                                                                                        //Leave the default values if it's null
                                                                                        if (dailyIterator.Current.Value != null)
                                                                                        {
                                                                                            string time = dailyIterator.Current.Value;
                                                                                            timeRangeDialog.Controls.DailyStartDateTimePicker.Hour = int.Parse(time.Substring(0, 2));                                                                                            
                                                                                            timeRangeDialog.Controls.DailyStartDateTimePicker.Minute = int.Parse(time.Substring((time.IndexOf(':') + 1), 2));
                                                                                            timeRangeDialog.ScreenElement.WaitForReady();
                                                                                            Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Set the Daily Start time to " + dailyIterator.Current.Value);
                                                                                        }
                                                                                        break;

                                                                                    case "End":
                                                                                        //Leave the default values if it's null
                                                                                        if (dailyIterator.Current.Value != null)
                                                                                        {
                                                                                            string time = dailyIterator.Current.Value;
                                                                                            int maxRetry = 3;
                                                                                            int count = 0;
                                                                                            do
                                                                                            {
                                                                                                timeRangeDialog.Controls.DailyEndDateTimePicker.Hour = int.Parse(time.Substring(0, 2));
                                                                                                timeRangeDialog.Controls.DailyEndDateTimePicker.Minute = int.Parse(time.Substring((time.IndexOf(':') + 1), 2));
                                                                                                timeRangeDialog.ScreenElement.WaitForReady();
                                                                                                Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Retry attempt in setting Daily End time is: " + count);
                                                                                                count++;
                                                                                            }
                                                                                            while ((timeRangeDialog.Controls.DailyEndDateTimePicker.Hour != int.Parse(time.Substring(0, 2))) && (count < maxRetry));
                                                                                            Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Set the Daily End time to " + dailyIterator.Current.Value);
                                                                                        }
                                                                                        break;

                                                                                    case "DaysOfWeek":
                                                                                        timeRangeDialog.Controls.DaysOfWeekListBox.SelectItem(WeekDayLocalizedName(dailyIterator.Current.Value));                                                                                        
                                                                                        break;
                                                                                }
                                                                            }
                                                                        }
                                                                        break;

                                                                    case "MutipleDays":
                                                                        if (timeRangeDialog.Controls.SpanMultipleDaysRadioButton.ButtonState != ButtonState.Checked)
                                                                        {
                                                                            timeRangeDialog.Controls.SpanMultipleDaysRadioButton.Click();
                                                                            Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Span multiple days Time Range selected");
                                                                        }
                                                                        XPathNodeIterator mutipleDaysIterator = weeklyScheduleIterator.Current.SelectChildren(XPathNodeType.Element);
                                                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: MutipleDays element value " + mutipleDaysIterator.Current.InnerXml);

                                                                        if (mutipleDaysIterator != null && (mutipleDaysIterator.Count >= 1))
                                                                        {
                                                                            while (mutipleDaysIterator.MoveNext())
                                                                            {
                                                                                switch (mutipleDaysIterator.Current.Name)
                                                                                {
                                                                                    case "Start":
                                                                                        string time = mutipleDaysIterator.Current.Value;
                                                                                        timeRangeDialog.Controls.MultipleStartDateTimePicker.Hour = int.Parse(time.Substring(0, 2));
                                                                                        timeRangeDialog.Controls.MultipleStartDateTimePicker.Minute = int.Parse(time.Substring((time.IndexOf(':') + 1), 2));
                                                                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Set the Multiple Days Start time to " + mutipleDaysIterator.Current.Value);

                                                                                        //Now select the day of the Week
                                                                                        timeRangeDialog.Controls.StartDayOfWeekComboBox.SelectByText(WeekDayLocalizedName(mutipleDaysIterator.Current.GetAttribute("day", "")));
                                                                                        break;

                                                                                    case "End":
                                                                                        string endTime = mutipleDaysIterator.Current.Value;
                                                                                        timeRangeDialog.Controls.MultipleEndDateTimePicker.Hour = int.Parse(endTime.Substring(0, 2));
                                                                                        timeRangeDialog.Controls.MultipleEndDateTimePicker.Minute = int.Parse(endTime.Substring((endTime.IndexOf(':') + 1), 2));
                                                                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Set the Daily Start time to " + mutipleDaysIterator.Current.Value);

                                                                                        //Now select the day of the Week
                                                                                        timeRangeDialog.Controls.EndDayOfWeekComboBox.SelectByText(WeekDayLocalizedName(mutipleDaysIterator.Current.GetAttribute("day", "")));
                                                                                        break;
                                                                                }
                                                                            }
                                                                        }


                                                                        break;
                                                                }
                                                            }
                                                        }

                                                        //close the time range dialog
                                                        CoreManager.MomConsole.Waiters.WaitForButtonEnabled(timeRangeDialog.Controls.OKButton, Constants.OneMinute / 1000);
                                                        timeRangeDialog.ClickOK();

                                                        break;

                                                    case "SimpleReccuringSchedule":
                                                        //select the radio button
                                                        if (consolidationDialog.Controls.BasedOnFixedSimpleRecurringScheduleRadioButton.ButtonState != ButtonState.Checked)
                                                        {
                                                            consolidationDialog.Controls.BasedOnFixedSimpleRecurringScheduleRadioButton.Click();
                                                        }

                                                        XPathNodeIterator simpleReccuringScheduleIterator = timeControlIterator.Current.SelectChildren(XPathNodeType.Element);
                                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: SimpleReccuringSchedule element value " + simpleReccuringScheduleIterator.Current.InnerXml);

                                                        if (simpleReccuringScheduleIterator != null && (simpleReccuringScheduleIterator.Count >= 1))
                                                        {
                                                            while (simpleReccuringScheduleIterator.MoveNext())
                                                            {
                                                                switch (simpleReccuringScheduleIterator.Current.Name)
                                                                {
                                                                    case "Period":
                                                                    consolidationDialog.PeriodText = simpleReccuringScheduleIterator.Current.Value;

                                                                    string timerUnit = null;
                                                                    timerUnit = simpleReccuringScheduleIterator.Current.GetAttribute("unit", "");
                                                                    //get the display string for timer unit
                                                                    switch (timerUnit.ToLowerInvariant())
                                                                    {
                                                                        case "seconds":
                                                                            consolidationDialog.PeriodUnitComboBoxText = ConsolidationSettingsDialog.Strings.SecondsTimerUnit;
                                                                            break;

                                                                        case "minutes":
                                                                            consolidationDialog.PeriodUnitComboBoxText = ConsolidationSettingsDialog.Strings.MinutesTimerUnit;
                                                                            break;

                                                                        case "hours":
                                                                            consolidationDialog.PeriodUnitComboBoxText = ConsolidationSettingsDialog.Strings.HoursTimerUnit;
                                                                            break;

                                                                        case "days":
                                                                            consolidationDialog.PeriodUnitComboBoxText = ConsolidationSettingsDialog.Strings.DaysTimerUnit;
                                                                            break;
                                                                    }
                                                                    break;

                                                                case "SyncTime":
                                                                    if (simpleReccuringScheduleIterator.Current.Value != null)
                                                                        {
                                                                            if (consolidationDialog.Controls.SynchronizeAtCheckBox.ButtonState != ButtonState.Checked)
                                                                            {
                                                                                consolidationDialog.Controls.SynchronizeAtCheckBox.Click();
                                                                            }

                                                                            string time = simpleReccuringScheduleIterator.Current.Value;
                                                                            consolidationDialog.Controls.SynchronizeAtDateTimePicker.Hour = int.Parse(time.Substring(0, 2));
                                                                            consolidationDialog.Controls.SynchronizeAtDateTimePicker.Minute = int.Parse(time.Substring((time.IndexOf(':') + 1), 2));                                                                        
                                                                        }
                                                                        break;
                                                                }
                                                            }
                                                        }

                                                        break;
                                                }
                                            } while (timeControlIterator.MoveNext());
                                        }//if

                                        break;
                                }
                            }
                            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(consolidationDialog.Controls.NextButton, Constants.OneMinute / 1000);
                            consolidationDialog.ClickNext();

                        #endregion
                            break;
                    }

                    switch (selectedType)
                    {
                        case WindowsEventsSimpleEventDetectionTimerReset:
                        case WindowsEventsCorrelatedEventDetectionTimerReset:
                        case WindowsEventsCorrelatedMissingEventDetectionTimerReset:
                        case WindowsEventsMissingEventDetectionTimerReset:
                        case WindowsEventsRepeatedEventDetectionTimerReset:
                            AutoResetTimerDialog autoResetTimer = new AutoResetTimerDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitorWizard);
                            autoResetTimer.ScreenElement.WaitForReady();

                            #region Auto Reset Timer

                            XPathNodeIterator autoResetTimerIterator = xmlNavigator.SelectSingleNode("AutoResetTimer").SelectChildren(XPathNodeType.Element);
                            Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Auto Reset Timer element value " + autoResetTimerIterator.Current.InnerXml);

                            if (autoResetTimerIterator == null)
                            {
                                throw new NullReferenceException("Monitors.CreateWindowsEventMonitor:: Could not Create Iterator for Auto Reset Timer Elements");
                            }
                            else if (checked(autoResetTimerIterator.Count < 1))
                            {
                                throw new NullReferenceException(string.Format("Monitors.CreateWindowsEventMonitor:: No. of Auto Reset Timer Child Elements cannot be of count: {0} must be greater or equal to 1", autoResetTimerIterator.Count));
                            }

                            while (autoResetTimerIterator.MoveNext())
                            {
                                //if the timer value is null then just go with the defaults
                                if ((string.Compare(autoResetTimerIterator.Current.Name, "Time") == 0) 
                                    && (autoResetTimerIterator.Current.Value != null))
                                {
                                    autoResetTimer.SpecifyTheTimerWaitText = autoResetTimerIterator.Current.Value;
                                    
                                    string timerUnit = null;
                                    timerUnit = autoResetTimerIterator.Current.GetAttribute("unit", "");
                                    //get the display string for timer unit
                                    switch (timerUnit.ToLowerInvariant())
                                    {
                                        case "seconds":
                                            autoResetTimer.SpecifyTheWaitUnitsText = AutoResetTimerDialog.Strings.SecondsTimerUnit;
                                            break;

                                        case "minutes":
                                            autoResetTimer.SpecifyTheWaitUnitsText = AutoResetTimerDialog.Strings.MinutesTimerUnit;
                                            break;

                                        case "hours":
                                            autoResetTimer.SpecifyTheWaitUnitsText = AutoResetTimerDialog.Strings.HoursTimerUnit;
                                            break;

                                        case "days":
                                            autoResetTimer.SpecifyTheWaitUnitsText = AutoResetTimerDialog.Strings.DaysTimerUnit;
                                            break;
                                    }
                                }
                            }
                            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(autoResetTimer.Controls.NextButton, Constants.OneMinute / 1000);
                            autoResetTimer.ClickNext(); // This bypases AutoResetTimer page.
                            autoResetTimer.WaitForResponse();
                            
                            #endregion
                            break;
                    }
                    #endregion

                    XPathNodeIterator healthConfigIterator = xmlNavigator.SelectSingleNode("HealthConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Health Config element value " + healthConfigIterator.Current.InnerXml);

                    #region Health Config
                    if (healthConfigIterator == null)
                    {
                        throw new NullReferenceException("Monitors.CreateWindowsEventMonitor:: Could not Create Iterator for Health Config Elements");
                    }
                    else if (checked(healthConfigIterator.Count < 1))
                    {
                        throw new NullReferenceException(string.Format("Monitors.CreateWindowsEventMonitor:: No. of Health Config Child Elements cannot be of count: {0} must be greater or equal to 1", healthConfigIterator.Count));
                    }

                    //Create an instance of Configure Health Dialog once
                    ConfigureHealthDialog healthDialog = new ConfigureHealthDialog(CoreManager.MomConsole);
                    healthDialog.ScreenElement.WaitForReady();

                    //Create instance of view pane
                    Core.Console.MomControls.GridControl viewGrid = new Core.Console.MomControls.GridControl(healthDialog,
                    ConfigureHealthDialog.ControlIDs.DataGridView1);
                    Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Succesfully found Health Configuration Grid View");

                    while (healthConfigIterator.MoveNext())
                    {
                        switch (healthConfigIterator.Current.Name)
                        {
                            case "OperationalState":
                                int operationalRowPos = -1;
                                string operationalID = null;

                                //Get the display string for the OperationalStateID
                                switch (healthConfigIterator.Current.GetAttribute("ID", "").ToLowerInvariant())
                                {
                                    case "event raised":
                                        //Different monitor types have same operational state names but the Guids are different
                                        switch (selectedType)
                                        {
                                            case WindowsEventsSimpleEventDetectionManualReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.SingleEventManualResetGuid, Monitors.Strings.MonitorTypeStateEventRaisedGUID);
                                                break;

                                            case WindowsEventsSimpleEventDetectionTimerReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.EventMonitorSingleEventAutoResetGuid, Monitors.Strings.SingleAutoMonitorStateEventRaisedGUID);
                                                break;

                                            case WindowsEventsCorrelatedEventDetectionEventReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.CorrelatedEventEventResetGuid, Monitors.Strings.CorrelatedEventMonitorStateEventRaisedGUID);
                                                break;

                                            case WindowsEventsCorrelatedMissingEventDetectionEventReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.CorrelatedMissingEventEventResetGuid, Monitors.Strings.MissingCorrelatedEventMonitorStateEventRaisedGUID);
                                                break;

                                            case WindowsEventsRepeatedEventDetectionEventReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.RepeatedEventEventResetGuid, Monitors.Strings.RepeatedEventMonitorStateEventRaisedGUID);
                                                break;

                                            case WindowsEventsMissingEventDetectionEventReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.MissingEventEventResetGuid, Monitors.Strings.MissingEventMonitorStateEventRaisedGUID);
                                                break;
                                        }

                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Looking for Operational State: " + operationalID);
                                        operationalRowPos = FindDataRow(operationalID, viewGrid);
                                        break;

                                    case "first event raised":
                                        operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.EventMonitorSingleEventEventResetGuid, Monitors.Strings.MonitorTypeStateFirstEventRaisedGUID);
                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Looking for Operational State: " + operationalID);
                                        operationalRowPos = FindDataRow(operationalID, viewGrid);
                                        break;

                                    case "second event raised":
                                        operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.EventMonitorSingleEventEventResetGuid, Monitors.Strings.MonitorTypeStateSecondEventRaisedGUID);
                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Looking for Operational State: " + operationalID);
                                        operationalRowPos = FindDataRow(operationalID, viewGrid);
                                        break;

                                    case "timer event raised":
                                        //Different monitor types have same operational state names but the Guids are different
                                        switch (selectedType)
                                        {
                                            case WindowsEventsSimpleEventDetectionTimerReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.EventMonitorSingleEventAutoResetGuid, Monitors.Strings.SingleAutoMonitorStateTimerEventRaisedGUID);
                                                break;
                                            
                                            case WindowsEventsCorrelatedEventDetectionTimerReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.CorrelatedEventTimerResetGuid, Monitors.Strings.CorrelatedTimerMonitorStateTimerEventRaisedGUID);
                                                break;

                                            case WindowsEventsCorrelatedMissingEventDetectionTimerReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.CorrelatedMissingEventTimerResetGuid, Monitors.Strings.MissingCorrelatedTimerMonitorStateTimerEventRaisedGUID);
                                                break;

                                            case WindowsEventsRepeatedEventDetectionTimerReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.RepeatedEventTimerResetGuid, Monitors.Strings.RepeatedTimerMonitorStateTimerEventRaisedGUID);
                                                break;

                                            case WindowsEventsMissingEventDetectionTimerReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.MissingEventTimerResetGuid, Monitors.Strings.MissingTimerMonitorStateTimerEventRaisedGUID);
                                                break;
                                        }
                                        
                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Looking for Operational State: " + operationalID);
                                        operationalRowPos = FindDataRow(operationalID, viewGrid);
                                        break;

                                    case "correlated event raised":
                                        //Different monitor types have same operational state names but the Guids are different
                                        switch (selectedType)
                                        {
                                            case WindowsEventsCorrelatedEventDetectionManualReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.CorrelatedEventManualResetGuid, Monitors.Strings.CorrelatedManualMonitorStateCorrelatedEventRaisedGUID);
                                                break;

                                            case WindowsEventsCorrelatedEventDetectionTimerReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.CorrelatedEventTimerResetGuid, Monitors.Strings.CorrelatedTimerMonitorStateCorrelatedEventRaisedGUID);
                                                break;

                                            case WindowsEventsCorrelatedEventDetectionEventReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.CorrelatedEventEventResetGuid, Monitors.Strings.CorrelatedEventMonitorStateCorrelatedEventRaisedGUID);
                                                break;
                                        }
                               
                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Looking for Operational State: " + operationalID);
                                        operationalRowPos = FindDataRow(operationalID, viewGrid);
                                        break;

                                    case "missing correlated event raised":
                                        //Different monitor types have same operational state names but the Guids are different
                                        switch (selectedType)
                                        {
                                            case WindowsEventsCorrelatedMissingEventDetectionManualReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.CorrelatedMissingEventManualResetGuid, Monitors.Strings.MissingCorrelatedManualMonitorStateMissingCorrelatedEventRaisedGUID);
                                                break;

                                            case WindowsEventsCorrelatedMissingEventDetectionTimerReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.CorrelatedMissingEventTimerResetGuid, Monitors.Strings.MissingCorrelatedTimerMonitorStateMissingCorrelatedEventRaisedGUID);
                                                break;

                                            case WindowsEventsCorrelatedMissingEventDetectionEventReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.CorrelatedMissingEventEventResetGuid, Monitors.Strings.MissingCorrelatedEventMonitorStateMissingCorrelatedEventRaisedGUID);
                                                break;
                                        }
                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Looking for Operational State: " + operationalID);
                                        operationalRowPos = FindDataRow(operationalID, viewGrid);
                                        break;

                                    case "repeated event raised":
                                        //Different monitor types have same operational state names but the Guids are different
                                        switch (selectedType)
                                        {
                                            case WindowsEventsRepeatedEventDetectionManualReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.RepeatedEventManualResetGuid, Monitors.Strings.RepeatedManualMonitorStateRepeatedEventRaisedGUID);
                                                break;

                                            case WindowsEventsRepeatedEventDetectionTimerReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.RepeatedEventTimerResetGuid, Monitors.Strings.RepeatedTimerMonitorStateRepeatedEventRaisedGUID);
                                                break;   
                                                
                                            case WindowsEventsRepeatedEventDetectionEventReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.RepeatedEventEventResetGuid, Monitors.Strings.RepeatedEventMonitorStateRepeatedEventRaisedGUID);
                                                break;
                                        }

                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Looking for Operational State: " + operationalID);
                                        operationalRowPos = FindDataRow(operationalID, viewGrid);
                                        break;

                                    case "missing event raised":
                                        //Different monitor types have same operational state names but the Guids are different
                                        switch (selectedType)
                                        {
                                            case WindowsEventsMissingEventDetectionManualReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.MissingEventManualResetGuid, Monitors.Strings.MissingManualMonitorStateMissingEventRaisedGUID);
                                                break;

                                            case WindowsEventsMissingEventDetectionTimerReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.MissingEventTimerResetGuid, Monitors.Strings.MissingTimerMonitorStateMissingEventRaisedGUID);
                                                break;

                                            case WindowsEventsMissingEventDetectionEventReset:
                                                operationalID = Utilities.GetUnitMonitorOperationalStateName(MonitorTypeDialog.Strings.MissingEventEventResetGuid, Monitors.Strings.MissingEventMonitorStateMissingEventRaisedGUID);
                                                break;
                                                                                           
                                        }

                                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Looking for Operational State: " + operationalID);
                                        operationalRowPos = FindDataRow(operationalID, viewGrid);
                                        break;
                                }
                                                                
                                SetHealthState(healthConfigIterator, viewGrid, operationalRowPos);
                                break;
                        }                       
                    }
                    Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Successfully set the health States");
                    //Go to Next dialog
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(healthDialog.Controls.NextButton, Constants.OneMinute / 1000);
                    healthDialog.ClickNext();

                    #endregion

                    XPathNodeIterator alertConfigIterator = xmlNavigator.SelectSingleNode("AlertConfig").SelectChildren(XPathNodeType.Element);
                    Utilities.LogMessage("Monitors.CreateWindowsEventMonitor: Alert Config element value " + alertConfigIterator.Current.InnerXml);

                    #region Alert Config
                    if (alertConfigIterator == null)
                    {
                        throw new NullReferenceException("Monitors.CreateWindowsEventMonitor:: Could not Create Iterator for Alert Config Elements");
                    }
                    else if (checked(alertConfigIterator.Count < 1))
                    {
                        throw new NullReferenceException(string.Format("Monitors.CreateWindowsEventMonitor:: No. of Alert Config Elements cannot be of count: {0} must be greater or equal to 1", alertConfigIterator.Count));
                    }

                    ConfigureAlertSetting(alertConfigIterator, currentMethod);
                                       
                    #endregion

                    //Complete the wizard by clicking on Create
                    //alertsDialog.ClickCreate();

                    //CoreManager.MomConsole.WaitForDialogClose(alertsDialog, 60);

                    int retry = 0;
                    int maxcount = 120;
                    while (!CoreManager.MomConsole.MainWindow.Extended.IsForeground && retry <= maxcount)
                    {
                        Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: MainWindow not Foreground, lets wait a moment.");
                        Sleeper.Delay(Constants.OneSecond);
                        retry++;
                    }
                    CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

                    Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Successfully completed the Create Monitor Wizard");
                }
                else
                {
                    Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: XmlElement passed as input had no Child Elements, no methods were execute");
                }
            }
            else
            {
                Utilities.LogMessage("Monitors.CreateWindowsEventMonitor:: Xmlelement passed as input is Empty no methods execute");
            }
            
        }                   

        #endregion


        /// <summary>
        /// Works by checking if the alert description exists
        /// </summary>
        /// <param name="alertGuid">guid identifying the alert</param>
        /// <returns>true if the alert exists, false otherwise</returns>
        public bool DoesAlertExist(Guid alertGuid)
        {
            return (Utilities.GetAlertDescription(alertGuid) != null);
        }

        /// <summary>        
        ///  Method to verify Alert Desc from the Alert property page
        /// </summary>
        /// <param name="alertViewPath">string for alertView Path</param>
        /// <param name="momServer">string for momServer</param>
        /// <param name="alertDisplayName">string for alertDisplayName</param>
        /// <param name="AlertDescValues">ArrayList for AlertDescValues</param>
        /// <param name="alertGuid">Guid for alertGuid</param>
        /// <returns>bool</returns>
        /// <history>
        /// [v-lileo] 20July09 - Created        
        /// </history>
        public bool IsAlertDescValid(string alertViewPath, string momServer, string alertDisplayName, ArrayList AlertDescValues, Guid alertGuid)
        {
            string CurrentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(CurrentMethod + "::(...)");
            bool AlertDescription = false;
                       
            //Verify the description from the generated alert in alerts view
            int currentAttempt = 0;
            int maxRetry = 15;            
            while (currentAttempt < maxRetry)
            {
                try
                {
                    Core.Console.Views.Alerts.AlertsView alertView = new Mom.Test.UI.Core.Console.Views.Alerts.AlertsView();                    
                    alertView.GetAlertProperties(alertViewPath,
                                            Core.Console.Views.Alerts.AlertsView.Strings.SourceColumnTitle,
                                            Core.Console.Views.Alerts.AlertsView.Strings.AlertNameColumnTitle,
                                            momServer,
                                            alertDisplayName);

                    //need to stop looping once the alert property is launched
                    currentAttempt = maxRetry;

                }
                catch (DataGrid.Exceptions.DataGridRowNotFoundException)
                {
                    currentAttempt++;
                    Utilities.LogMessage(CurrentMethod + ":: " + " Alert not found in attempt " + currentAttempt.ToString());
                    if (currentAttempt >= maxRetry)
                    {                        
                        Utilities.LogMessage(CurrentMethod + ":: " + " Alert didn't get generated on firing the NT event");
                        return false;
                    }
                }
            }
            Utilities.LogMessage(CurrentMethod + ":: " + "New Alert generation verified");            
            string alertDescFromSDK = Utilities.GetAlertDescription(alertGuid);
            Utilities.LogMessage(CurrentMethod + ":: Alert Description for the generated alert from SDK is '" + alertDescFromSDK + "'");

            //Now match the alert description from SDK to what is displayed in UI
            Core.Console.Views.Alerts.AlertPropertiesGeneralDialog alertProperties = new Mom.Test.UI.Core.Console.Views.Alerts.AlertPropertiesGeneralDialog(CoreManager.MomConsole);
            alertProperties.ScreenElement.WaitForReady();

            //Removing all carraige return characters from the alert description string before comparision
            if (string.Compare(alertProperties.AlertDescriptionText.Trim('\n','\r',' '), alertDescFromSDK.Trim('\n','\r',' ')) == 0)
            {
                Utilities.LogMessage(CurrentMethod + ":: " + "Verified Alert description from UI Alert property page matched the alert description from SDK");
                AlertDescription = true;
                // Verify Alert Desc from the Alert property page contains the parameter values defined in the varmap                    
                foreach (string AlertDescValue in AlertDescValues)
                {
                    if (alertProperties.AlertDescriptionText.ToLower().Contains(AlertDescValue.ToLower()))
                    {
                        Utilities.LogMessage(CurrentMethod + "Successful found " + AlertDescValue + " in Alert description on active alert");
                        AlertDescription = true;
                    }
                    else
                    {
                        Utilities.LogMessage(CurrentMethod + "Alert description on active alert should have contained " + AlertDescValue);
                        Utilities.LogMessage(CurrentMethod + "Alert description on active alert was actually found in UI ¨C value of " + alertProperties.AlertDescriptionText);
                        AlertDescription = false;
                        break;
                    }

                }
                //alertProperties.ClickOK();
                alertProperties.ClickOK();
            }
            else
            {
                Utilities.LogMessage(CurrentMethod + ":: " + "Default alert description on active alert should have been '" + alertDescFromSDK + "'");
                Utilities.LogMessage(CurrentMethod + ":: " + "Default alert description on active alert found was '" + alertProperties.AlertDescriptionText + "'");
                AlertDescription = false;
                alertProperties.ClickOK();                    
            }
            return AlertDescription;
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Method to retry getting reference to view grid. Problem occurs if the viewGrid 
        /// reference was set while the view was still refreshing
        /// </summary>        
        /// <param name="viewGrid">Grid to Get reference to</param>  
        /// <param name="maxRetries">Maximun number of retry attempts to get reference</param> 
        /// <returns>Reference to the GridControl</returns>
        private Core.Console.MomControls.GridControl RetryViewGridReference(Core.Console.MomControls.GridControl viewGrid, int maxRetries)
        {             
            int attempt = 0;
            int headerCount = 0;
            while (viewGrid != null && attempt <= maxRetries)
            {
                try
                {
                    headerCount = viewGrid.ColumnHeaders.Count;
                    if (headerCount == 0)
                    {                    
                        Utilities.LogMessage("Monitors.RetryViewGridReference:: Column header count is " + headerCount);
                        Utilities.LogMessage("Monitors.RetryViewGridReference:: Attempt No. to get reference to viewgrid "
                            + attempt);

                        //Waiting as the view sometimes doesn't comeup imediately

                        CoreManager.MomConsole.Waiters.WaitForStatusReady();

                        //viewGrid = null;
                        Utilities.LogMessage("Monitors.RetryViewGridReference:: Try getting reference to the View grid again");
                        viewGrid = CoreManager.MomConsole.ViewPane.Grid;                    
                    
                        attempt++;
                    }
                    else
                    {
                        Utilities.LogMessage("Monitors.RetryViewGridReference:: Column header count is " + headerCount);
                        break;
                    }
                }
                catch (Maui.Core.Window.Exceptions.InvalidHWndException)
                {
                    Utilities.LogMessage("Monitors.RetryViewGridReference:: Caught InvalidHWndException; should be ok continue");

                    CoreManager.MomConsole.Waiters.WaitForStatusReady();

                    viewGrid = CoreManager.MomConsole.ViewPane.Grid;
                    attempt++;
                }                
            }
            return viewGrid;
        }

        /// <summary>
        /// Configure the WMI event expression according to the data in XML 
        /// It will setup the WMI Namespace and WMI Query 
        /// </summary>
        /// <param name="wmiConfigIterator">XPath Node iterator for WMI configuration</param>
        /// <history>
        /// [v-eryon] 25SEP08 - Created        
        /// </history>
        public void ConfigureWMIEventExpression(XPathNodeIterator wmiConfigIterator)
        {
            StringBuilder currentMethod = new StringBuilder(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            currentMethod.Append(".").Append(System.Reflection.MethodBase.GetCurrentMethod().Name);

            if (wmiConfigIterator == null || wmiConfigIterator.Count < 1)
            {
                throw new NullReferenceException(currentMethod + ": Could not create Iterator for Event Config Elements");
            }

            while (wmiConfigIterator.MoveNext())
            {
                if (string.Compare(wmiConfigIterator.Current.Name, "WMIEvent") == 0)
                {
                    XPathNodeIterator wmiEventIterator = wmiConfigIterator.Current.SelectChildren(XPathNodeType.Element);

                    #region WMI Event Config

                    WMIConfigurationDialog wmiConfigurationDialog = new WMIConfigurationDialog(
                        CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitorWizard);

                    if (wmiEventIterator != null && (wmiEventIterator.Count > 1))
                    {
                        while (wmiEventIterator.MoveNext())
                        {
                            string currentWMIConfigValue = wmiEventIterator.Current.SelectChildren(XPathNodeType.Element).Current.Value;
                            if (currentWMIConfigValue != null)
                            {
                                switch (wmiEventIterator.Current.Name)
                                {
                                    case "WMINameSpace":
                                        wmiConfigurationDialog.NameSpaceText = currentWMIConfigValue;
                                        break;
                                    case "WMIQuery":
                                        wmiConfigurationDialog.WMIQueryText = currentWMIConfigValue;
                                        break;
                                    case "PollInterval":
                                        wmiConfigurationDialog.IntervalText = currentWMIConfigValue;
                                        break;
                                }
                            }
                            else
                            {
                                throw new NullReferenceException(currentMethod + ":: WMI configuration data is null.");
                            }
                        }
                    }
                    wmiConfigurationDialog.Controls.NextButton.Extended.SetFocus();
                    wmiConfigurationDialog.ClickNext();
                    wmiConfigurationDialog.WaitForResponse();

                    #endregion
                }
                else if (string.Compare(wmiConfigIterator.Current.Name, "Expression") == 0)
                {
                    XPathNodeIterator expressionIterator = wmiConfigIterator.Current.SelectChildren(XPathNodeType.Element);

                    #region Expression Config

                    BuildExpressionDialog buildExpression = new BuildExpressionDialog(
                        CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitorWizard);

                    //Create instance of Formula Grid Control
                    Core.Console.MomControls.GridControl formulaGrid = new Core.Console.MomControls.GridControl(buildExpression,
                    Core.Console.MomControls.GridControl.ControlIDs.FormulaGrid);

                    if (formulaGrid != null)
                    {
                        Utilities.LogMessage(currentMethod + ": FormulaGrid found");

                        //Invoke tool bar button click to insert new expression row
                        CoreManager.MomConsole.InvokeToolBarButton(buildExpression.Controls.FormulaToolStrip, BuildExpressionDialog.Strings.FormulaToolStripInsert);
                        Keyboard.SendKeys(KeyboardCodes.Tab);
                        Keyboard.SendKeys(KeyboardCodes.Enter);
                        
                        CoreManager.MomConsole.InvokeToolBarButton(buildExpression.Controls.FormulaToolStrip, BuildExpressionDialog.Strings.FormulaToolStripInsert);
                        Keyboard.SendKeys(KeyboardCodes.Tab);
                        Keyboard.SendKeys(KeyboardCodes.Enter);

                        // Get the Index position of all the three Header Columns
                        int colposParameterName = formulaGrid.GetColumnTitlePosition(BuildExpressionDialog.Strings.GridParameterNameColumn);
                        int colposOperator = formulaGrid.GetColumnTitlePosition(BuildExpressionDialog.Strings.GridOperatorColumn);
                        int colposValue = formulaGrid.GetColumnTitlePosition(BuildExpressionDialog.Strings.GridValueColumn);

                        //Starting Row Index
                        int rowIndex = 2;

                        Utilities.LogMessage("colposParameterName: " + colposParameterName + colposOperator + colposValue);
                        if (expressionIterator != null && (expressionIterator.Count > 1))
                        {
                            while (expressionIterator.MoveNext())
                            {
                                switch (expressionIterator.Current.Name)
                                {
                                    case "Parameter":
                                        //Insert for new parameter
                                        formulaGrid.ClickCell(rowIndex, colposParameterName);
                                        formulaGrid.SetCellValue(formulaGrid.Extended.AccessibleObject.Window, expressionIterator.Current.Value,
                                            DataGridViewCellType.TextBox, Core.Console.MonitoringConfiguration.Events.Events.Strings.TextEditorWinFormsId);
                                        break;

                                    case "Operator":
                                        formulaGrid.ClickCell(rowIndex, colposOperator);
                                        string setOperator = null;

                                        switch (expressionIterator.Current.Value.ToLowerInvariant())
                                        {
                                            case "equals":
                                                setOperator = BuildExpressionDialog.Strings.Equality;
                                                break;

                                            case "does not equal":
                                                setOperator = BuildExpressionDialog.Strings.NotEquals;
                                                break;

                                            case "greater than":
                                                setOperator = BuildExpressionDialog.Strings.GreaterThan;
                                                break;

                                            case "greater than or equal to":
                                                setOperator = BuildExpressionDialog.Strings.GreaterThanOrEqualTo;
                                                break;

                                            case "less than":
                                                setOperator = BuildExpressionDialog.Strings.LessThan;
                                                break;

                                            case "less than or equal to":
                                                setOperator = BuildExpressionDialog.Strings.LessThanOrEqualTo;
                                                break;

                                            case "contains":
                                                setOperator = BuildExpressionDialog.Strings.Contains;
                                                break;

                                            case "does not contain":
                                                setOperator = BuildExpressionDialog.Strings.NotContains;
                                                break;
                                        }

                                        // Set operator value in cell
                                        formulaGrid.SetCellValue(formulaGrid, setOperator, DataGridViewCellType.ComboBox, Events.Events.Strings.OperatorComboBoxEditorWinFormsId);
                                        break;

                                    case "Value":
                                        formulaGrid.ClickCell(rowIndex, colposValue);
                                        formulaGrid.SetCellValue(formulaGrid.Extended.AccessibleObject.Window, expressionIterator.Current.Value, DataGridViewCellType.TextBox, Events.Events.Strings.TextEditorWinFormsId);
                                        //Need to special case when rowIndex is 1 because it adds a extra line for And Group
                                        if (rowIndex == 1)
                                        {
                                            rowIndex++;
                                        }

                                        rowIndex++;
                                        break;
                                }
                            }
                            formulaGrid.ClickCell(rowIndex++, colposValue);
                            CoreManager.MomConsole.InvokeToolBarButton(buildExpression.Controls.FormulaToolStrip,
                                    BuildExpressionDialog.Strings.FormulaToolStripDelete);

                        }
                    }
                    buildExpression.Controls.NextButton.Extended.SetFocus();
                    buildExpression.ClickNext();
                    buildExpression.WaitForResponse();

                    #endregion
                }
            }
        }

        /// <summary>
        /// Launch Create unit Monitor wizard for all the monitor creation
        /// </summary>
        /// <history>
        /// [v-cheli] 05Feb09 - Created        
        /// </history>
        private void LaunchCreateUnitMonitorWizard()
        {
            CoreManager.MomConsole.BringToForeground();

            // Make sure the UI is ready
            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

            // Select the Monitoring Configuration wunderbar
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.MonitoringConfiguration);

            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);


            // Select Monitors view
            navPane.SelectNode(monitorsPath, NavigationPane.NavigationTreeView.MonitoringConfiguration);

            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);


            // Select Add a Unit Monitor from the context menu
            Maui.Core.WinControls.Menu myMenuItem = new Maui.Core.WinControls.Menu(ContextMenuAccessMethod.ShiftF10);
            myMenuItem.ScreenElement.WaitForReady();
            myMenuItem.ExecuteMenuItem(HealthConfigurationView.Strings.ContextMenuCreateMonitor);
            myMenuItem.ScreenElement.WaitForReady();
            myMenuItem.ExecuteMenuItem(HealthConfigurationView.Strings.ContextMenuUnitMonitor);
        }

        /// <summary>
        /// Launch Create unit Monitor wizard for specific target.
        /// </summary>
        /// <param name="targetName">target name</param>
        /// <param name="parentMonitor">parent Monitor</param>
        /// <history>
        /// [v-vijia] 24MAR2011 - Created 
        /// </history>
        public void LaunchCreateUnitMonitorWizard(string targetName, string parentMonitor)
        {
            string[] menuItems = { HealthConfigurationView.Strings.ContextMenuCreateMonitor, HealthConfigurationView.Strings.ContextMenuUnitMonitor };
            this.ExecuteContextMenuForTargetMontior(targetName, parentMonitor, menuItems);
        }

        /// <summary>
        /// Launch Create dependency Monitor wizard for a specific monitor.
        /// </summary>
        /// <param name="targetName">target name</param>
        /// <param name="parentMonitor">parent Monitor</param>
        /// <history>
        /// [v-vijia] 24MAR2011 - Created 
        /// </history>
        public void LaunchCreateDependencyMonitorWizard(string targetName, string parentMonitor)
        {
            string[] menuItems = { HealthConfigurationView.Strings.ContextMenuCreateMonitor, HealthConfigurationView.Strings.ContextMenuDependencyRollupMonitor };
            this.ExecuteContextMenuForTargetMontior(targetName, parentMonitor, menuItems);

        }

        /// <summary>
        /// Launch Create aggregate Monitor wizard for a specific monitor.
        /// </summary>
        /// <param name="targetName">target name</param>
        /// <param name="parentMonitor">parent Monitor</param>
        /// <history>
        /// [v-vijia] 24MAR2011 - Created 
        /// </history>
        public void LaunchCreateAggregateMonitorWizard(string targetName, string parentMonitor)
        {
            string[] menuItems = { HealthConfigurationView.Strings.ContextMenuCreateMonitor, HealthConfigurationView.Strings.ContextMenuAggregateRollupMonitor };
            this.ExecuteContextMenuForTargetMontior(targetName, parentMonitor, menuItems);
        }

        /// <summary>
        /// Configure alert setting for all the monitor creation
        /// </summary>
        /// <param name="alertConfigIterator">XPath Node iterator for alert configuration</param>
        /// <param name="monitorMethod">Monitor method name</param>
        /// <history>
        /// [v-cheli] 05Feb09 - Created        
        /// </history>
        private void ConfigureAlertSetting(XPathNodeIterator alertConfigIterator, StringBuilder monitorMethod)
        {
           StringBuilder currentMethod = monitorMethod.Append("::").Append(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Create an new instance for Alert Configuration dialog
            ConfigureAlertsDialog alertsDialog =
                new ConfigureAlertsDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitorWizard);
            alertsDialog.ScreenElement.WaitForReady();

            while (alertConfigIterator.MoveNext())
            {
                if (string.Compare(alertConfigIterator.Current.Name, "GeneratesAlert") == 0)
                {
                    if (Boolean.Parse(alertConfigIterator.Current.GetAttribute("value", "")))
                    {
                        Utilities.LogMessage(currentMethod + ":: Generates Alert is true now configure Alert settings");
                        Sleeper.Delay(Constants.OneSecond);
                        if (alertsDialog.Controls.GenerateAlertsCheckBox.ButtonState != ButtonState.Checked)
                        {
                            alertsDialog.ClickGenerateAlerts();
                            Utilities.LogMessage(currentMethod + ":: Generates Alert check box checked");
                        }

                        //Need to set Alert settings only when generatesAlert is true
                        XPathNodeIterator alertSettingIterator = alertConfigIterator.Current.SelectChildren(XPathNodeType.Element);

                        #region Detail Alert Setting

                        if ((alertSettingIterator != null) && (alertSettingIterator.Count > 1))
                        {
                            while (alertSettingIterator.MoveNext())
                            {
                                switch (alertSettingIterator.Current.Name.ToLowerInvariant())
                                {
                                    case "autoresolve":

                                        #region AutoResolve

                                        //if this is null then the default settings won't be changed
                                        if (alertSettingIterator.Current.Value != null)
                                        {
                                            bool autoResolve = Boolean.Parse(alertSettingIterator.Current.Value);

                                            if ((autoResolve == true) &&
                                                (alertsDialog.Controls.AutomaticallyResolveAlertCheckBox.ButtonState != ButtonState.Checked))
                                            {
                                                alertsDialog.ClickAutomaticallyResolveAlert();
                                                Utilities.LogMessage(currentMethod + ":: Auto resolve the alerts checked");
                                            }
                                            else
                                            {
                                                if ((autoResolve == false) &&
                                                    (alertsDialog.Controls.AutomaticallyResolveAlertCheckBox.ButtonState == ButtonState.Checked))
                                                {
                                                    alertsDialog.ClickAutomaticallyResolveAlert();
                                                    Utilities.LogMessage(currentMethod + ":: Auto resolve the alerts unchecked");
                                                }
                                            }
                                        }
                                        break;

                                        #endregion

                                    case "alertname":

                                        #region Alert Name

                                        //if this is null then the default settings won't be changed
                                        if (alertSettingIterator.Current.Value != null)
                                        {
                                            alertsDialog.AlertNameText = alertSettingIterator.Current.Value;
                                            Utilities.LogMessage(currentMethod + ":: Setup the alert name.");
                                        }

                                        break;

                                        #endregion

                                    case "alertdesc":

                                        #region Alert Description

                                        //if this is null then the default settings won't be changed
                                        Utilities.LogMessage(currentMethod + ":: AlertDescription: " + alertSettingIterator.Current.Value);
                                        if (alertSettingIterator.Current.Value != null)
                                        {
                                            //First clear the default alert name and then set the new value
                                            if (alertSettingIterator.Current.Value == "")
                                            {
                                                Utilities.LogMessage(currentMethod + ":: Leaving the default alert description");

                                            }
                                            else
                                            {
                                                alertsDialog.AlertDescriptionText = alertSettingIterator.Current.Value;
                                            }

                                        }
                                        break;

                                        #endregion

                                    case "alertpriority":

                                        #region Alert Priority

                                        //if this is null then the default settings won't be changed
                                        if (alertSettingIterator.Current.Value != null)
                                        {
                                            switch (alertSettingIterator.Current.Value.ToLowerInvariant())
                                            {
                                                case "low":
                                                    alertsDialog.Controls.PriorityComboBox.SelectByText(Monitors.Strings.AlertPriorityLow);
                                                    Utilities.LogMessage(currentMethod + ":: Alert priority set to " + Monitors.Strings.AlertPriorityLow);
                                                    break;
                                                case "medium":
                                                    alertsDialog.Controls.PriorityComboBox.SelectByText(Monitors.Strings.AlertPriorityMedium);
                                                    Utilities.LogMessage(currentMethod + ":: Alert priority set to " + Monitors.Strings.AlertPriorityMedium);
                                                    break;
                                                case "high":
                                                    alertsDialog.Controls.PriorityComboBox.SelectByText(Monitors.Strings.AlertPriorityHigh);
                                                    Utilities.LogMessage(currentMethod + ":: Alert priority set to " + Monitors.Strings.AlertPriorityHigh);
                                                    break;
                                            }
                                        }
                                        break;

                                        #endregion

                                    case "alertseverity":

                                        #region Alert Severity

                                        //if this is null then the default settings won't be changed
                                        if (alertSettingIterator.Current.Value != null)
                                        {
                                            switch (alertSettingIterator.Current.Value.ToLowerInvariant())
                                            {
                                                case "warning":
                                                    alertsDialog.Controls.SeverityComboBox.SelectByText(Monitors.Strings.AlertSeverityWarning);
                                                    Utilities.LogMessage(currentMethod + ":: Alert Severity set to " + Monitors.Strings.AlertSeverityWarning);
                                                    break;
                                                case "information":
                                                    alertsDialog.Controls.SeverityComboBox.SelectByText(Monitors.Strings.AlertSeverityInformation);
                                                    Utilities.LogMessage(currentMethod + ":: Alert Severity set to " + Monitors.Strings.AlertSeverityInformation);
                                                    break;
                                                case "critical":
                                                    alertsDialog.Controls.SeverityComboBox.SelectByText(Monitors.Strings.AlertSeverityCritical);
                                                    Utilities.LogMessage(currentMethod + ":: Alert Severity set to " + Monitors.Strings.AlertSeverityCritical);
                                                    break;
                                                case "match monitor's health":
                                                    alertsDialog.Controls.SeverityComboBox.SelectByText(Monitors.Strings.AlertSeverityMatchMonitorHealth);
                                                    Utilities.LogMessage(currentMethod + ":: Alert Severity set to " + Monitors.Strings.AlertSeverityMatchMonitorHealth);
                                                    break;
                                            }
                                        }
                                        break;

                                        #endregion

                                }//switch

                            }//while
                        }//if
                        #endregion

                    }
                }

            }

            int retry = 0;
            int maxCount = 5;
            while (!CoreManager.MomConsole.MainWindow.Extended.IsForeground && retry <= maxCount)
            {
                CoreManager.MomConsole.BringToForeground();
                Sleeper.Delay(Constants.OneSecond);
                retry++;
            }
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(alertsDialog.Controls.CreateButton, Constants.OneMinute / 1000);
            alertsDialog.ClickCreate();
            CoreManager.MomConsole.WaitForDialogClose(alertsDialog, Constants.DefaultDialogTimeout * 8 / Constants.OneSecond);
 
        }

        /// <summary>
        /// General setting for WMIEvent/WMIPerfCounter monitor creation
        /// </summary>
        /// <param name="generalIterator">XPath Node iterator for alert configuration</param>
        /// <param name="monitorMethod">Monitor method name</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <history>
        /// [v-cheli] 12Feb09 - Created        
        /// </history>
        private void GeneralSetting(XPathNodeIterator generalIterator, StringBuilder monitorMethod)
        {
            StringBuilder currentMethod = monitorMethod.Append("::").Append(System.Reflection.MethodBase.GetCurrentMethod().Name);

            CoreManager.MomConsole.BringToForeground();

            //Create a new instance for General Properties dialog
            MonitorGeneralPropertiesDialog generalDialog = new MonitorGeneralPropertiesDialog(CoreManager.MomConsole);
            generalDialog.ScreenElement.WaitForReady();

            while (generalIterator.MoveNext())
            {
                switch (generalIterator.Current.Name.ToLowerInvariant())
                {
                    case "displayname":

                        #region Enter the Name

                        Utilities.LogMessage(currentMethod +
                            ":: Monitor Name specified in xml is: " + generalIterator.Current.Value);

                        switch (generalIterator.Current.Value.ToLowerInvariant())
                        {
                            case "random":

                                string displayName = randomNames.CreateRandomString(minNameLength, maxNameLength, Utilities.ExcludedCharacters());
                                Utilities.LogMessage(currentMethod + ":: RandomString for Name = " + displayName);
                                generalDialog.NameText = displayName;
                                break;

                            default:
                                //if user specifies any value other than random use that value as name
                                if (!String.IsNullOrEmpty(generalIterator.Current.Value))
                                {
                                    generalDialog.NameText = generalIterator.Current.Value;
                                    displayName = generalIterator.Current.Value;
                                }
                                else
                                {
                                    Utilities.LogMessage(currentMethod + ": Invalid name null or empty.");

                                }
                                break;

                        }

                        Utilities.LogMessage(currentMethod + ":: Successfully set the name to: '" + generalDialog.NameText + "'");
                        break;

                        #endregion

                    case "desc":

                        #region Enter the Desc

                        Utilities.LogMessage(currentMethod + ":: Monitor Desc specified in xml is: "
                            + generalIterator.Current.Value);

                        switch (generalIterator.Current.Value.ToLowerInvariant())
                        {
                            case "random":

                                string description = randomNames.CreateRandomString(minDescriptionLength, maxDescriptionLength, Utilities.ExcludedCharacters());
                                Utilities.LogMessage(currentMethod + ":: RandomString for Description = " + description);
                                generalDialog.DescriptionOptionalText = description;
                                break;

                            case "":
                                Utilities.LogMessage(currentMethod + ":: Leaving the default description");
                                break;

                            default:
                                //if user specifies any value other than random use that value as description
                                generalDialog.DescriptionOptionalText = generalIterator.Current.Value;
                                //description = generalIterator.Current.Value;
                                break;

                        }

                        Utilities.LogMessage(currentMethod + ":: Successfully set the desc to: '" + generalDialog.DescriptionOptionalText + "'");
                        break;

                        #endregion

                    case "target":

                        #region Select the target

                        string selectTarget = null;
                        selectTarget = generalIterator.Current.Value;

                        if (selectTarget != null)
                        {
                            generalDialog.ClickSelect();

                            //Create a new instance for Select target dialog
                            SelectTargetTypeDialog selectTargetDialog = new SelectTargetTypeDialog(CoreManager.MomConsole);
                            selectTargetDialog.ScreenElement.WaitForReady();

                            switch (selectTarget.ToLowerInvariant())
                            {
                                case "agent":
                                    selectTarget = Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDSystemCenterLibraryMP, ManagementPackConstants.AgentName);
                                    break;

                                case "computer":
                                    selectTarget = Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDSystemLibraryMP, ManagementPackConstants.SystemComputerName);
                                    break;

                                case "windows computer":
                                case "windowscomputer":
                                    selectTarget = Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDMicrosoftWindowsLibraryMP, ManagementPackConstants.WindowsComputerGroupName);
                                    break;
                                case "windowscomputerrole":
                                    selectTarget = Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDMicrosoftWindowsLibraryMP, ManagementPackConstants.WindowsComputerRoleName);
                                    break;
                            }
                            
                            try
                            {
                                // find item in the common targets view
                                Utilities.LogMessage(currentMethod + ":: Select Target: " + selectTarget);
                                selectTargetDialog.Controls.ListView0.MultiSelect(selectTarget);
                            }
                            catch (Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException)
                            {
                                // find item in the all targets view
                                selectTargetDialog.RadioGroup0 = Core.Console.MonitoringConfiguration.Dialogs.RadioGroup0.ViewAllTargets;
                                Utilities.LogMessage(currentMethod + ":: Click radio button 'view all targets'");

                                selectTargetDialog.Controls.ListView0.MultiSelect(selectTarget);
                            }

                            selectTargetDialog.ScreenElement.WaitForReady();
                            selectTargetDialog.ClickOK();
                            CoreManager.MomConsole.WaitForDialogClose(selectTargetDialog, Constants.DefaultDialogTimeout * 4 / Constants.OneSecond);
                        }
                        break;

                        #endregion

                    case "parentmonitor":

                        #region Select the Parent Monitor

                        if (generalIterator.Current.Value != null)
                        {
                            switch (generalIterator.Current.Value.ToLowerInvariant())
                            {
                                case "entity health":
                                    Utilities.LogMessage(currentMethod + ":: Parent Monitor specified is " + Strings.EntityHealthMonitor);
                                    generalDialog.ParentMonitorText = Strings.EntityHealthMonitor;
                                    break;

                                case "availability":
                                    Utilities.LogMessage(currentMethod + ":: Parent Monitor specified is " + Strings.AvailabilityMonitor);
                                    generalDialog.ParentMonitorText = Strings.AvailabilityMonitor;
                                    break;

                                case "configuration":
                                    Utilities.LogMessage(currentMethod + ":: Parent Monitor specified is " + Strings.ConfigurationMonitor);
                                    generalDialog.ParentMonitorText = Strings.ConfigurationMonitor;
                                    break;

                                case "performance":
                                    Utilities.LogMessage(currentMethod + ":: Parent Monitor specified is " + Strings.PerformanceMonitor);
                                    generalDialog.ParentMonitorText = Strings.PerformanceMonitor;
                                    break;

                                case "security":
                                    Utilities.LogMessage(currentMethod + ":: Parent Monitor specified is " + Strings.SecurityMonitor);
                                    generalDialog.ParentMonitorText = Strings.SecurityMonitor;
                                    break;

                                default:
                                    Utilities.LogMessage(currentMethod + ":: Parent Monitor specified is " + generalIterator.Current.Value);
                                    break;
                            }

                        }
                        break;

                        #endregion

                    case "enabled":

                        #region Check the enabled status

                        bool monitorEnabled = generalIterator.Current.ValueAsBoolean;

                        if ((monitorEnabled == true) && (generalDialog.Controls.MonitorIsEnabledCheckBox.ButtonState != ButtonState.Checked))
                        {
                            generalDialog.ClickMonitorIsEnabled();
                        }
                        else
                        {
                            if ((monitorEnabled == false) && (generalDialog.Controls.MonitorIsEnabledCheckBox.ButtonState == ButtonState.Checked))
                            {
                                generalDialog.ClickMonitorIsEnabled();
                            }
                        }
                        break;

                        #endregion

                    default:
                        Utilities.LogMessage(currentMethod + ":: General Config Element specified in xml is: '" +
                            generalIterator.Current.Name + "' is invalid");
                        throw new InvalidEnumArgumentException("Invalid Element selected");

                }

            }
            //Go the next dialog
            generalDialog.ClickNext();
            Utilities.LogMessage(currentMethod + "(...)Navigate to Configuration page");
 
        }

        /// <summary>
        /// General setting for Event monitor creation
        /// </summary>
        /// <param name="generalIterator">XPath Node iterator for alert configuration</param>
        /// <param name="monitorMethod">Monitor method name</param>
        /// <param name="displayName">Return random string for display name</param>
        /// <param name="description">Return rnadom string for description</param>
        /// <exception cref="System.ComponentModel.InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <history>
        /// [v-cheli] 12Feb09 - Created        
        /// </history>
        public void GeneralSetting(XPathNodeIterator generalIterator, StringBuilder monitorMethod, ref string displayName, ref string description)
        {
            StringBuilder currentMethod = monitorMethod.Append("::").Append(System.Reflection.MethodBase.GetCurrentMethod().Name);

            CoreManager.MomConsole.BringToForeground();

            //Create a new instance for General Properties dialog
            MonitorGeneralPropertiesDialog generalDialog = new MonitorGeneralPropertiesDialog(CoreManager.MomConsole);
            generalDialog.ScreenElement.WaitForReady();

            while (generalIterator.MoveNext())
            {
                switch (generalIterator.Current.Name.ToLowerInvariant())
                {
                    case "displayname":

                        #region Enter the Name

                        Utilities.LogMessage(currentMethod +
                            ":: Monitor Name specified in xml is: " + generalIterator.Current.Value);

                        switch (generalIterator.Current.Value.ToLowerInvariant())
                        {
                            case "random":

                                displayName = randomNames.CreateRandomString(minNameLength, maxNameLength, Utilities.ExcludedCharacters());
                                Utilities.LogMessage(currentMethod + ":: RandomString for Name = " + displayName);
                                generalDialog.NameText = displayName;
                                break;

                            default:
                                //if user specifies any value other than random use that value as name
                                if (!String.IsNullOrEmpty(generalIterator.Current.Value))
                                {
                                    generalDialog.NameText = generalIterator.Current.Value;
                                    displayName = generalIterator.Current.Value;
                                }
                                else
                                {
                                    Utilities.LogMessage(currentMethod + ": Invalid name null or empty.");

                                }
                                break;

                        }

                        Utilities.LogMessage(currentMethod + ":: Successfully set the name to: '" + generalDialog.NameText + "'");
                        break;

                        #endregion

                    case "desc":

                        #region Enter the Desc

                        Utilities.LogMessage(currentMethod + ":: Monitor Desc specified in xml is: "
                            + generalIterator.Current.Value);

                        switch (generalIterator.Current.Value.ToLowerInvariant())
                        {
                            case "random":

                                description = randomNames.CreateRandomString(minDescriptionLength, maxDescriptionLength, Utilities.ExcludedCharacters());
                                Utilities.LogMessage(currentMethod + ":: RandomString for Description = " + description);
                                generalDialog.DescriptionOptionalText = description;
                                break;

                            case "":
                                Utilities.LogMessage(currentMethod + ":: Leaving the default description");
                                break;

                            default:
                                //if user specifies any value other than random use that value as description
                                generalDialog.DescriptionOptionalText = generalIterator.Current.Value;
                                //description = generalIterator.Current.Value;
                                break;

                        }

                        Utilities.LogMessage(currentMethod + ":: Successfully set the desc to: '" + generalDialog.DescriptionOptionalText + "'");
                        break;

                        #endregion                    

                    case "target":

                        #region Select the target                        

                        string selectTarget = null;
                        selectTarget = generalIterator.Current.Value;

                        if (selectTarget != null)
                        {
                            generalDialog.ClickSelect();

                            //Create a new instance for Select target dialog
                            SelectTargetTypeDialog selectTargetDialog = new SelectTargetTypeDialog(CoreManager.MomConsole);
                            selectTargetDialog.ScreenElement.WaitForReady();

                            switch (selectTarget.ToLowerInvariant())
                            {
                                case "agent":
                                    selectTarget = Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDSystemLibraryMP, ManagementPackConstants.AgentName);
                                    break;

                                case "computer":
                                    selectTarget = Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDSystemLibraryMP, ManagementPackConstants.SystemComputerName);
                                    break;

                                case "windows computer":
                                case "windowscomputer":
                                    selectTarget = Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDMicrosoftWindowsLibraryMP, ManagementPackConstants.WindowsComputerGroupName);
                                    break;

                                case "windowscomputerrole":
                                    selectTarget = Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDMicrosoftWindowsLibraryMP, ManagementPackConstants.WindowsComputerRoleName);
                                    break;
                            }

                            try
                            {
                                // find item in the common targets view
                                Utilities.LogMessage(currentMethod + ":: Select Target: " + selectTarget);
                                selectTargetDialog.LookForText = selectTarget;
                                selectTargetDialog.WaitForResponse();
                                selectTargetDialog.Controls.ListView0.MultiSelect(selectTarget);
                                
                            }
                            catch (Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException)
                            {
                                // find item in the all targets view
                                selectTargetDialog.RadioGroup0 = Core.Console.MonitoringConfiguration.Dialogs.RadioGroup0.ViewAllTargets;
                                Utilities.LogMessage(currentMethod + ":: Click radio button 'view all targets'");

                                selectTargetDialog.Controls.ListView0.MultiSelect(selectTarget);
                            }

                            selectTargetDialog.ScreenElement.WaitForReady();
                            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(selectTargetDialog.Controls.OKButton, Constants.OneMinute / 1000);
                            selectTargetDialog.Controls.OKButton.Extended.SetFocus();
                            selectTargetDialog.ClickOK();
                            CoreManager.MomConsole.WaitForDialogClose(selectTargetDialog, Constants.DefaultDialogTimeout * 4 / Constants.OneSecond);
                        }
                        break;

                        #endregion

                    case "parentmonitor":

                        #region Select the Parent Monitor

                        if (generalIterator.Current.Value != null)
                        {
                            switch (generalIterator.Current.Value.ToLowerInvariant())
                            {
                                case "entity health":
                                    Utilities.LogMessage(currentMethod + ":: Parent Monitor specified is " + Strings.EntityHealthMonitor);
                                    generalDialog.ParentMonitorText = Strings.EntityHealthMonitor;
                                    break;

                                case "availability":
                                    Utilities.LogMessage(currentMethod + ":: Parent Monitor specified is " + Strings.AvailabilityMonitor);
                                    generalDialog.ParentMonitorText = Strings.AvailabilityMonitor;
                                    break;

                                case "configuration":
                                    Utilities.LogMessage(currentMethod + ":: Parent Monitor specified is " + Strings.ConfigurationMonitor);
                                    generalDialog.ParentMonitorText = Strings.ConfigurationMonitor;
                                    break;

                                case "performance":
                                    Utilities.LogMessage(currentMethod + ":: Parent Monitor specified is " + Strings.PerformanceMonitor);
                                    generalDialog.ParentMonitorText = Strings.PerformanceMonitor;
                                    break;

                                case "security":
                                    Utilities.LogMessage(currentMethod + ":: Parent Monitor specified is " + Strings.SecurityMonitor);
                                    generalDialog.ParentMonitorText = Strings.SecurityMonitor;
                                    break;

                                default:
                                    Utilities.LogMessage(currentMethod + ":: Parent Monitor specified is " + generalIterator.Current.Value);
                                    break;
                            }

                        }
                        break;

                        #endregion

                    case "enabled":

                        #region Check the enabled status

                        bool monitorEnabled = generalIterator.Current.ValueAsBoolean;

                        if ((monitorEnabled == true) && (generalDialog.Controls.MonitorIsEnabledCheckBox.ButtonState != ButtonState.Checked))
                        {
                            generalDialog.ClickMonitorIsEnabled();
                        }
                        else
                        {
                            if ((monitorEnabled == false) && (generalDialog.Controls.MonitorIsEnabledCheckBox.ButtonState == ButtonState.Checked))
                            {
                                generalDialog.ClickMonitorIsEnabled();
                            }
                        }
                        break;

                        #endregion

                    default:
                        Utilities.LogMessage(currentMethod + ":: General Config Element specified in xml is: '" +
                            generalIterator.Current.Name + "' is invalid");
                        throw new InvalidEnumArgumentException("Invalid Element selected");

                }

            }
            //Go the next dialog
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(generalDialog.Controls.NextButton, Constants.OneSecond * 2);
            generalDialog.ClickNext();
            Utilities.LogMessage(currentMethod + "(...)Navigate to Configuration page");

        }

        /// <summary>
        /// Set health state for all the monitor creation
        /// </summary>
        /// <param name="healthConfigIterator">XPath Node iterator for health configuration</param>
        /// <param name="viewGrid">MomCntrol viewGrid</param>
        /// <param name="operationalRowPos">operational state row position</param>
        /// <history>
        /// [v-cheli] 12Feb09 - Created        
        /// </history>
        private void SetHealthState(XPathNodeIterator healthConfigIterator, MomControls.GridControl viewGrid, int operationalRowPos)
        {
            int healthStateColPos = viewGrid.GetColumnTitlePosition(HealthConfigurationView.Strings.HealthStateHeader);
            viewGrid.Rows[operationalRowPos].Cells[healthStateColPos].Click();
            Utilities.LogMessage("Clicked the datagrid cell now call the combo box control on it");

            //DataGridViewComboBoxCell healthDropDown = new DataGridViewComboBoxCell(viewGrid.Rows[operationalRowPos].Cells[healthStateColPos].AccessibleObject);
            //Utilities.LogMessage("Found DataGridViewComboBoxCell");
            //healthDropDown.Click();
            //Utilities.LogMessage("combo box clicked ");

            ComboBox combo = new ComboBox(viewGrid.Rows[operationalRowPos].Cells[healthStateColPos].AccessibleObject.Window, null, StringMatchSyntax.WildCard, WindowClassNames.ComboBox, StringMatchSyntax.WildCard);
            Utilities.LogMessage("Found comboBox Cell");

            //Get the display string for Health State and set it
            switch (healthConfigIterator.Current.Value.ToLowerInvariant())
            {
                case "critical":
                case "error":
                    //healthDropDown.SetValue(Monitors.Strings.ErrorHealthState);
                    combo.SelectByText(Monitors.Strings.ErrorHealthState);
                    break;

                case "warning":
                    //healthDropDown.SetValue(Monitors.Strings.WarningHealthState);
                    combo.SelectByText(Monitors.Strings.WarningHealthState);
                    break;

                case "healthy":
                case "success":
                    //healthDropDown.SetValue(Monitors.Strings.SuccessHealthState);
                    combo.SelectByText(Monitors.Strings.SuccessHealthState);
                    break;
            }

            viewGrid.SendKeys(KeyboardCodes.Tab);
        }

        /// <summary> 
        /// Method to execute context menu in Monitors view. 
        /// </summary> 
        /// <param name="contextMenuItems">context menu items</param> 
        /// <history> 
        /// [v-vijia] 29MAR11 - Created         
        /// </history> 
        private void ExecuteContextMenu(string[] contextMenuItems)
        {
            CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();
            Menu contextMenu = new Menu(ContextMenuAccessMethod.ShiftF10);
            foreach (string menuItem in contextMenuItems)
            {
                MenuItem submenuitem = new MenuItem(contextMenu, menuItem);
                if (!submenuitem.Enabled)
                {
                    Utilities.LogMessage("Monitors.ExecuteContextMenu:: Menu item: " + menuItem + " is not enabled.");
                    Utilities.TakeScreenshot("Monitors.FailedToExecuteContextMenu");
                    Keyboard.SendKeys(KeyboardCodes.Esc);
                    throw new InvalidOperationException("Monitors.ExecuteContextMenu:: Failed to execute context menu");
                }

                Utilities.LogMessage("Monitors.ExecuteContextMenu:: Executing menu item: " + menuItem);
                submenuitem.Execute();
            }

            Utilities.LogMessage("Monitors.ExecuteContextMenu:: Executing context menu successfully.");
        } 


        #region private Event Monitoring methods

        /// <summary>
        /// Method to search the rows and cells of a grid for the specified
        /// search string.
        /// </summary>
        /// <param name="searchData">String to find in grid cells</param>
        /// <param name="dataGrid">Grid to search</param>
        /// <returns>The index of the row containing the data</returns>
        public int FindDataRow(string searchData, Maui.Core.WinControls.DataGridView dataGrid)
        {
            ////Todo: Consider moving this method to the Grid control.
            ////Todo: Add 'Monitors.' class name to log messages.
            Core.Common.Utilities.LogMessage("Searching grid view for text:  '" +
                searchData + "'");

            // get the number of grid rows
            int rowCount = dataGrid.Rows.Count;
            Core.Common.Utilities.LogMessage("Number of grid rows:  " + rowCount);

            // get the number of cells per row
            int cellCount = 0;
            if (rowCount > 1)
            {
                cellCount = dataGrid.Rows[1].Cells.Count;
            }
            Core.Common.Utilities.LogMessage("Number of grid cells:  " + cellCount);

            // flag to indicate if search data is found
            bool foundSearchData = false;

            // placeholder row
            Maui.Core.WinControls.DataGridViewRow selectedRow = null;

            // placeholder for current cell's text data
            string currentCellText = null;
            int rowIndex = 1;

            // iterate through each row
            for (rowIndex = 1; rowIndex < rowCount; rowIndex++)
            {
                // click on the first cell in each row
                dataGrid.Rows[rowIndex].Cells[0].AccessibleObject.Click();

                // iterate through each cell
                for (int cellIndex = 0; cellIndex < cellCount; cellIndex++)
                {
                    currentCellText =
                        dataGrid.Rows[rowIndex].Cells[cellIndex].GetValue().ToLowerInvariant();
                    Core.Common.Utilities.LogMessage("Cell " + cellIndex + " contains '" +
                        currentCellText);

                    // match the current device name exactly
                    if (searchData.ToLowerInvariant().CompareTo(currentCellText) == 0)
                    {
                        Core.Common.Utilities.LogMessage("Found match:  '" +
                            currentCellText + "'");

                        selectedRow = dataGrid.Rows[rowIndex];
                        Utilities.LogMessage("row index: " + rowIndex);
                        foundSearchData = true;
                        break;
                    }
                }

                // check to see if we found the data
                if (foundSearchData == true)
                {
                    break;
                }
            }

            ////return the row containing the data
            ////return selectedRow;
            // return the row index for the row containing the data
            return rowIndex;
        }

        /// <summary>
        /// Method to return a particular cell value corresponding to a column header and
        /// a particular row.
        /// </summary>
        /// <param name="viewGrid">grid</param>
        /// <param name="rowText">String to find in row</param>
        /// <param name="columnHeader">Column header</param> 
        /// <returns>cell value for the specified column header</returns>
        private string SelectCellFormRow(Core.Console.MomControls.GridControl viewGrid, string rowText, string columnHeader)
        {
            ////Todo: Consider moving this method to the Grid control, needs some cleanup of comments to make it generic.
            ////Todo: Add 'Monitors.' and class name to log messages.
            try
            {
                if (viewGrid != null)
                {
                    Utilities.LogMessage("viewGrid found");
                    
                    // initializing variables for row and column positions
                    int rowpos = -1;
                    int colpos = 0;

                    // Set the Health state for operational State = "Service is running"
                    rowpos = this.FindDataRow(rowText, viewGrid);
                    Utilities.LogMessage("Found row containing cell data : "
                        + rowText);

                    // Get the Index position of the Column Health State
                    colpos = viewGrid.GetColumnTitlePosition(columnHeader);
                    Utilities.LogMessage("ColumnPosition: " + colpos);
                    Utilities.LogMessage("RowPosition: " + rowpos);

                    // if either row or column position -1 then cell not found
                    if ((rowpos != -1) | (colpos != -1))
                    {
                        Utilities.LogMessage("cell value : " + viewGrid.GetCellValue(rowpos, colpos));
                        Utilities.LogMessage("Clicking Cell");
                        viewGrid.ClickCell(rowpos, colpos);
                        Utilities.LogMessage("success in clicking cell :" + viewGrid.GetCellValue(rowpos, colpos));
                        return (viewGrid.GetCellValue(rowpos, colpos));
                    }
                    else
                    {
                        ////Todo: throw more specific exception.
                        throw new Exception("unable to locate row/cell for : " + rowText);
                    }
                }   // end of if viewgrid != null
                else
                {
                    throw new Exception("unable to locate datagrid");
                }
            }   // try
            catch
            {
                Utilities.LogMessage("Monitors.SelectCellFormRow:: " +
                    "failure in Adding an Event Monitor!");
                throw;
            }
            finally
            {
                ////Todo: consider taking a snapshot.
            }
        }

        #endregion	// Event Monitoring methods

        #endregion       

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for Monitors
        /// </summary>
        /// <history> 	
        ///   [ruhim]  01NOV05: Added resource strings for Monitor Names
        ///   [a-joelj] 20FEB09 Added resource string for Monitors pivoted view window
        ///   [a-joelj] 19MAR09 Added resource string for NTService State Monitor and NT 
        ///                     Windows Service Stopped AlertMessage
        ///   [v-frma] 10Nov11 Added resource string for Node
        ///   [v-frma] 18Nov11 Removed resource string for Node
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the wizard dialog title.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle =
                ";Create Monitor Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateMonitorWizard";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Error Health State in health Configuration Dialog.
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceErrorHealthState =
                ";Error;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;Error";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Warning Health State in health Configuration Dialog.
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceWarningHealthState =
                ";Warning;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;Warning";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Success Health State in health Configuration Dialog.
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceSuccessHealthState =
                ";Success;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;Success";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Alert Priority Medium 
            /// in the Monitor wizard Configure Alert Dialog
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertPriorityMedium =
                ";Medium;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Alerting.AlertingResources;PriorityMedium";

            // -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Alert Priority Low 
            /// in the Monitor wizard Configure Alert Dialog
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertPriorityLow =
                ";Low;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Alerting.AlertingResources;PriorityLow";

            // -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Alert Priority High
            /// in the Monitor wizard Configure Alert Dialog
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertPriorityHigh =
                ";High;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Alerting.AlertingResources;PriorityHigh";

            // -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Confirm Monitor Delete Dialog Title
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceConfirmMonitorDeleteTitle =
                        ";Confirm Monitor Delete;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.HealthView.HealthViewResources;ConfirmDeleteCaption";

            // -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Alert Severity Match Monitor's Health
            /// in the Monitor wizard Configure Alert Dialog
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertSeverityMatchMonitorHealth =
                ";Match monitor's health;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Alerting.AlertingResources;SeverityMatchMonitorHealth";

            // -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Alert Severity Warning
            /// in the Monitor wizard Configure Alert Dialog
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertSeverityWarning =
                ";Warning;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Alerting.AlertingResources;SeverityWarning";

            // -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Alert Severity Information
            /// in the Monitor wizard Configure Alert Dialog    
            /// </summary>            
            private const string ResourceAlertSeverityInformation =
                ";Information;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Alerting.AlertingResources;SeverityInformation";

            // -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Alert Severity Critical
            /// in the Monitor wizard Configure Alert Dialog
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertSeverityCritical =
                ";Critical;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Alerting.AlertingResources;SeverityError";

            // -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Alerting Tab Title on Monitor Property Page
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceAlertingTabTitle =
                ";Alerting;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Alerting.AlertingResources;TabTitle";

            // -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Monitors pivoted view window
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitors =
                //";Monitors;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.HealthView.HealthViewResources;ViewName";
                ";System Center Operations Manager 2012;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources;ProductTitle";

            #region Monitor GUIDS

            /// <summary>
            /// Contains GUID for: System Entity Health Monitor
            /// </summary>            
            private static Guid EntityHealthMonitorGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemHealthLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.SystemHealthEntityStateMonitorName);//"FFEE43E2-9221-1DF8-3259-8835A93B42E8";

            /// <summary>
            /// Contains GUID for: System Availability Monitor
            /// </summary>            
            private static Guid AvailabilityMonitorGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemHealthLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.SystemHealthAvailabilityStateMonitorName);

            /// <summary>
            /// Contains GUID for: System Configuration Monitor
            /// </summary>            
            private static Guid ConfigurationMonitorGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemHealthLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.SystemHealthConfigurationStateMonitorName);

            /// <summary>
            /// Contains GUID for: System Performance Monitor
            /// </summary>            
            private static Guid PerformanceMonitorGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemHealthLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.SystemHealthPerformanceStateMonitorName);

            /// <summary>
            /// Contains GUID for: System Security Monitor
            /// </summary>            
            private static Guid SecurityMonitorGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemHealthLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.SystemHealthSecurityStateMonitorName);

            /// <summary>
            /// Contains GUID for: Simple Event Detection Monitor Folder
            /// </summary>            
            public static Guid MonitorTypeFolderWindowsEventLogSimpleGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.MonitorTypeFolderWindowsEventLogSimpleName);

            /// <summary>
            /// Contains GUID for: Correlated Event Detection Monitor Folder
            /// </summary>            
            public static Guid MonitorTypeFolderWindowsEventLogCorrelatedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.MonitorTypeFolderWindowsEventLogCorrelatedName);

            /// <summary>
            /// Contains GUID for: Missing Event Detection Monitor Folder
            /// </summary>            
            public static Guid MonitorTypeFolderWindowsEventLogMissingGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.MonitorTypeFolderWindowsEventLogMissingName);

            /// <summary>
            /// Contains GUID for: Repeated Event Detection Monitor Folder
            /// </summary>            
            public static Guid MonitorTypeFolderWindowsEventLogRepeatedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.MonitorTypeFolderWindowsEventLogRepeatedName);

            /// <summary>
            /// Contains GUID for: Correlated Missing Event Detection Monitor Folder
            /// </summary>            
            public static Guid MonitorTypeFolderWindowsEventLogMissingCorrelatedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.MonitorTypeFolderWindowsEventLogMissingCorrelatedName);

            /// <summary>
            /// Contains GUID for: WMI Event Simple Detection Monitor Folder
            /// </summary>            
            public static Guid MonitorTypeFolderWMIEventSimpleGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.MonitorTypeFolderWMIEventSimpleName);

            /// <summary>
            /// Contains GUID for: WMI Event Repeated Detection Monitor Folder
            /// </summary>            
            public static Guid MonitorTypeFolderWMIEventRepeatedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.MonitorTypeFolderWMIEventRepeatedName);

            /// <summary>
            /// Contains GUID for:WMI Performance Static Single Threshold Folder
            /// </summary>
            public static Guid MonitorTypeFolderWMIPerformanceStaticSingleGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.MonitorTypeFolderWMIPerformanceStaticSingleThresholdName);

            /// <summary>
            /// Contains GUID for:WMI Performance Static Double Threshold Folder
            /// </summary>
            public static Guid MonitorTypeFolderWMIPerformanceStaticDoubleGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.MonitorTypeFolderWMIPerformanceStaticDoulbeThresholdName);

            /// <summary>
            /// Contains GUID for:  Windows Performance Counters Monitor Folder
            /// </summary>            
            public static Guid MonitorTypeFolderWindowsPerformanceGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.MonitorTypeFolderWindowsPerformanceName);

            /// <summary>
            /// Contains GUID for: Self Tuning Threshold Monitor Folder
            /// </summary>            
            public static Guid MonitorTypeFolderWindowsPerformanceSelfTuningGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.MonitorTypeFolderWindowsPerformanceSelfTuningName);

            /// <summary>
            /// Contains GUID for:Windows Performance Static Threshold Folder
            /// </summary>
            public static Guid MonitorTypeFolderWindowsPerformanceStaticGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.MonitorTypeFolderWindowsPerformanceStaticThresholdName);

            /// <summary>
            /// Contains GUID for:Windows Performance Static Single Threshold Folder
            /// </summary>
            public static Guid MonitorTypeFolderWindowsPerformanceStaticSingleGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.MonitorTypeFolderWindowsPerformanceStaticSingleThresholdName);

            /// <summary>
            /// Contains GUID for:Windows Performance Static Double Threshold Folder
            /// </summary>
            public static Guid MonitorTypeFolderWindowsPerformanceStaticDoubleGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.MonitorTypeFolderWindowsPerformanceStaticDoubleThresholdName);

            /// <summary>
            /// Contains GUID for: Windows Service Monitor Folder
            /// </summary>            
            public static Guid MonitorTypeFolderWindowsServiceGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.MonitorTypeFolderWindowsServiceName);

            /// <summary> 
            /// Contains GUID for: Simple Trap Detection Folder 
            /// </summary> 
            public static Guid MonitorTypeFolderSNMPTrapSimpleGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.SimpleTrapSNMPMonitorName); 
  
            /// <summary> 
            /// Contains GUID for: Simple Event Detection Folder 
            /// </summary> 
            public static Guid MonitorTypeFolderSNMPProbeSimpleGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.SimpleProbeSNMPMonitorName); 
            
            /// <summary>
            /// Contains GUID for: NTService Service Running State Monitor
            /// </summary>            
            private static Guid NTServiceRunningMonitorGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterNTServiceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.NTServiceStateMonitorName);

            /// <summary>
            /// Contains GUID for: NTService Service State Monitor
            /// </summary>            
            private static Guid NTServiceStoppedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterNTServiceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsServiceStoppedAlert);

            /// <summary>
            /// Contains GUID for: System.Windows.OwnProcessNTService.MonitorPercentProcessorTime Monitor
            /// </summary>            
            private static Guid NTPercentProcessorTimeMonitorGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterNTServiceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.NTServicePercentProcessorTimeMonitorName);

            /// <summary>
            /// Contains GUID for: System.Windows.OwnProcessNTService.MonitorHandleCount Monitor
            /// </summary>            
            private static Guid NTHandleCountMonitorGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterNTServiceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.NTServiceHandleCountMonitorName);

            /// <summary>
            /// Contains GUID for: System.Windows.OwnProcessNTService.MonitorThreadCount Monitor
            /// </summary>            
            private static Guid NTThreadCountMonitorGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterNTServiceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.NTServiceThreadCountMonitorName);

            /// <summary>
            /// Contains GUID for: System.Windows.OwnProcessNTService.MonitorWorkingSet Monitor
            /// </summary>            
            private static Guid NTWorkingSetMonitorGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterNTServiceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.NTServiceWorkingSetMonitorName);

            /// <summary>
            /// Contains GUID for: Monitor Type State: EventRaised in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid MonitorTypeStateEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsSingleEventManualResetName, ManagementPackConstants.MonitorTypeStateEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: FirstEventRaised in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid MonitorTypeStateFirstEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsSingleEventEventResetName, ManagementPackConstants.MonitorTypeStateFirstEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: SecondEventRaised in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid MonitorTypeStateSecondEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsSingleEventEventResetName, ManagementPackConstants.MonitorTypeStateSecondEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: TimerEventRaised for Single Event Timer Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid SingleAutoMonitorStateTimerEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.EventMonitorSingleEventAutoResetName, ManagementPackConstants.MonitorTypeStateTimerEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: EventRaised for Single Event Auto Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid SingleAutoMonitorStateEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.EventMonitorSingleEventAutoResetName, ManagementPackConstants.MonitorTypeStateEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: CorrelatedEventRaised for Correlated Event Manual Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid CorrelatedManualMonitorStateCorrelatedEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsCorrelatedManualResetName, ManagementPackConstants.MonitorTypeStateCorrelatedEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: CorrelatedEventRaised for Correlated Event Timer Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid CorrelatedTimerMonitorStateCorrelatedEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsCorrelatedTimerResetName, ManagementPackConstants.MonitorTypeStateCorrelatedEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: TimerEventRaised for Correlated Event Timer Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid CorrelatedTimerMonitorStateTimerEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsCorrelatedTimerResetName, ManagementPackConstants.MonitorTypeStateTimerEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: EventRaised for Correlated Event Event Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid CorrelatedEventMonitorStateEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsCorrelatedEventResetName, ManagementPackConstants.MonitorTypeStateEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: CorrelatedEventRaised for Correlated Event Event Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid CorrelatedEventMonitorStateCorrelatedEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsCorrelatedEventResetName, ManagementPackConstants.MonitorTypeStateCorrelatedEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: MissingCorrelatedEventRaised for Missing Correlated Event Manual Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid MissingCorrelatedManualMonitorStateMissingCorrelatedEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsCorrelatedMissingManualResetName, ManagementPackConstants.MonitorTypeStateMissingCorrelatedEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: MissingCorrelatedEventRaised for Missing Correlated Event Timer Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid MissingCorrelatedTimerMonitorStateMissingCorrelatedEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsCorrelatedMissingTimerResetName, ManagementPackConstants.MonitorTypeStateMissingCorrelatedEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: MissingCorrelatedEventRaised for Missing Correlated Event Event Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid MissingCorrelatedEventMonitorStateMissingCorrelatedEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsCorrelatedMissingEventResetName, ManagementPackConstants.MonitorTypeStateMissingCorrelatedEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: TimerEventRaised for Missing Correlated Event Timer Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid MissingCorrelatedTimerMonitorStateTimerEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsCorrelatedMissingTimerResetName, ManagementPackConstants.MonitorTypeStateTimerEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: EventRaised for Missing Correlated Event Event Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid MissingCorrelatedEventMonitorStateEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsCorrelatedMissingEventResetName, ManagementPackConstants.MonitorTypeStateEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: RepeatedEventRaised for Repeated Event Manual Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid RepeatedManualMonitorStateRepeatedEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsRepeatedManualResetName, ManagementPackConstants.MonitorTypeStateRepeatedEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: RepeatedEventRaised for Repeated Event Timer Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid RepeatedTimerMonitorStateRepeatedEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsRepeatedTimerResetName, ManagementPackConstants.MonitorTypeStateRepeatedEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: RepeatedEventRaised for Repeated Event Event Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid RepeatedEventMonitorStateRepeatedEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsRepeatedEventResetName, ManagementPackConstants.MonitorTypeStateRepeatedEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: TimerEventRaised for Repeated Event Timer Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid RepeatedTimerMonitorStateTimerEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsRepeatedTimerResetName, ManagementPackConstants.MonitorTypeStateTimerEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: EventRaised for Repeated Event Event Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid RepeatedEventMonitorStateEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsRepeatedEventResetName, ManagementPackConstants.MonitorTypeStateEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: MissingEventRaised for Missing Event Manual Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid MissingManualMonitorStateMissingEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsMissingManualResetName, ManagementPackConstants.MonitorTypeStateMissingEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: MissingEventRaised for Missing Event Timer Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid MissingTimerMonitorStateMissingEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsMissingTimerResetName, ManagementPackConstants.MonitorTypeStateMissingEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: MissingEventRaised for Missing Event Event Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid MissingEventMonitorStateMissingEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsMissingEventResetName, ManagementPackConstants.MonitorTypeStateMissingEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: TimerEventRaised for Missing Event Timer Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid MissingTimerMonitorStateTimerEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsMissingTimerResetName, ManagementPackConstants.MonitorTypeStateTimerEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: EventRaised for Missing Event Event Reset Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid MissingEventMonitorStateEventRaisedGUID = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsEventsMissingEventResetName, ManagementPackConstants.MonitorTypeStateEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Manual Raise for Single WMI Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid SingleWMIMonitorStateManualRaisedGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIEventsSingleManualResetName, ManagementPackConstants.MonitorTypeStateEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Timer Raise for Single WMI Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid SingleWMIMonitorStateTimerRaisedGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIEventsSingleTimerResetName, ManagementPackConstants.MonitorTypeStateTimerEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Event Raise for Single WMI Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid SingleWMIMonitorStateEventRaisedGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIEventsSingleTimerResetName, ManagementPackConstants.MonitorTypeStateEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: First Event Raise for Single WMI Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid SingleWMIMonitorStateFirstEventRaisedGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIEventsSingleWMIEventResetName, ManagementPackConstants.MonitorTypeStateFirstEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Second Event Raise for Single WMI Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid SingleWMIMonitorStateSecondEventRaisedGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIEventsSingleWMIEventResetName, ManagementPackConstants.MonitorTypeStateSecondEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Manual Raise for Repeated WMI Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid RepeatedWMIMonitorStateManualRaisedGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIEventsRepeatedManualResetName, ManagementPackConstants.MonitorTypeStateRepeatedEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Timer Raise for Repeated WMI Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid RepeatedWMIMonitorStateTimerRaisedGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIEventsRepeatedTimerResetName, ManagementPackConstants.MonitorTypeStateTimerEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Event Raise for Repeated WMI Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid RepeatedWMIMonitorStateEventRaisedGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIEventsRepeatedWMIEventResetName, ManagementPackConstants.MonitorTypeStateRepeatedEventRaised);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Over Threshold for Single Average Threshold Monitor in Microsoft.Windows.Library MP
            /// </summary>            
            public static Guid AverageWMIPerfMonitorStateOverThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIPerformanceAverageThresholdName, ManagementPackConstants.MonitorTypeStateOverThreshold);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Under Threshold for Single Average Threshold Monitor in Microsoft.Windows.Library MP
            /// </summary>    
            public static Guid AverageWMIPerfMnoitorStateUnderThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIPerformanceAverageThresholdName, ManagementPackConstants.MonitorTypeStateUnderThreshold);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Over Threshold for Single Consecutive Threshold Monitor in Microsoft.Windows.Library MP
            /// </summary>    
            public static Guid ConsecutiveWMIPerfMonitorStateOverThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIPerformanceConsecutiveSamplesThresholdName, ManagementPackConstants.MonitorTypeStateConditionFalse);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Under Threshold for Single Consecutive Threshold Monitor in Microsoft.Windows.Library MP
            /// </summary>    
            public static Guid ConsecutiveWMIPerfMonitorStateUnderThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIPerformanceConsecutiveSamplesThresholdName, ManagementPackConstants.MonitorTypeStateConditionTrue);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Over Threshold for Single Delta Threshold Monitor in Microsoft.Windows.Library MP
            /// </summary>    
            public static Guid DeltaWMIPerfMonitorStateOverThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIPerformanceDeltaThresholdName, ManagementPackConstants.MonitorTypeStateOverThreshold);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Under Threshold for Single Delta Threshold Monitor in Microsoft.Windows.Library MP
            /// </summary>  
            public static Guid DeltaWMIPerfMonitorStateUnderThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIPerformanceDeltaThresholdName, ManagementPackConstants.MonitorTypeStateUnderThreshold);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Over Threshold for Single Simple Threshold Monitor in Microsoft.Windows.Library MP
            /// </summary>  
            public static Guid SimpleWMIPerfMonitorStateOverThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIPerformanceSimpleThresholdName, ManagementPackConstants.MonitorTypeStateOverThreshold);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Under Threshold for Single Simple Threshold Monitor in Microsoft.Windows.Library MP
            /// </summary> 
            public static Guid SimpleWMIPerfMonitorStateUnderThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIPerformanceSimpleThresholdName, ManagementPackConstants.MonitorTypeStateUnderThreshold);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Between Threshold for Double Threshold Monitor in Microsoft.Windows.Library MP
            /// </summary> 
            public static Guid DoubleWMIPerfMonitorStateBetweenThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIPerformanceDoulbeThresholdName, ManagementPackConstants.MonitorTypeStateBetweenThreshold);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Over Upper Threshold for Double Threshold Monitor in Microsoft.Windows.Library MP
            /// </summary> 
            public static Guid DoubleWMIPerfMonitorStateOverUpperThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIPerformanceDoulbeThresholdName, ManagementPackConstants.MonitorTypeStateOverUpperThreshold);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Under Lower Threshold for Double Threshold Monitor in Microsoft.Windows.Library MP
            /// </summary> 
            public static Guid DoubleWMIPerfMonitorStateUnderLowerThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.MicrosoftWindowsLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsWMIPerformanceDoulbeThresholdName, ManagementPackConstants.MonitorTypeStateUnderLowerThreshold);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Above Envelope for 2-state Above Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid TwoStateAboveWindowsPerfMonitorStateAboveGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformance2stateAboveThresholdName, ManagementPackConstants.MonitorTypeStateAbove);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Blow Envelope for 2-state Above Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid TwoStateAboveWindowsPerfMonitorStateBelowGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformance2stateAboveThresholdName, ManagementPackConstants.MonitorTypeStateBelow);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Above Envelope for 2-state Baselining Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid TwoStateBaseliningWindowsPerfMonitorStateAboveEnvelopeGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformance2stateBaseliningThresholdName, ManagementPackConstants.MonitorTypeStateOutsideEnvelope);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Winthin Envelope for 2-state Baselining Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid TwoStateBaseliningWindowsPerfMonitorStateWithinEnvelopeGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformance2stateBaseliningThresholdName, ManagementPackConstants.MonitorTypeStateWithinEnvelope);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Above Envelope for 2-state Below Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid TwoStateBelowWindowsPerfMonitorStateAboveEnvelopeGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformance2stateBelowThresholdName, ManagementPackConstants.MonitorTypeStateAbove);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Below Envelope for 2-state Below Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid TwoStateBelowWindowsPerfMonitorStateBelowEnvelopeGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformance2stateBelowThresholdName, ManagementPackConstants.MonitorTypeStateBelow);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Below Envelope for 3-state Baselining Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid ThreeStateBaseliningWindowsPerfMonitorStateBelowEnvelopeGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformance3stateBaseliningThresholdName, ManagementPackConstants.MonitorTypeStateBelowEnvelope);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Within Envelope for 3-state Baselining Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid ThreeStateBaseliningWindowsPerfMonitorStateWithinEnvelopeGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformance3stateBaseliningThresholdName, ManagementPackConstants.MonitorTypeStateWithinEnvelope);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Above Envelope for 3-state Baselining Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid ThreeStateBaseliningWindowsPerfMonitorStateAboveEnvelopeGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformance3stateBaseliningThresholdName, ManagementPackConstants.MonitorTypeStateAboveEnvelope);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Under Threshold for Average Threshold Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid AverageThresholdWindowsPerfMonitorStateUnderThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformanceAverageThresholdName, ManagementPackConstants.MonitorTypeStateUnderThreshold);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Over Threshold for Average Threshold Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid AverageThresholdWindowsPerfMonitorStateOverThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformanceAverageThresholdName, ManagementPackConstants.MonitorTypeStateOverThreshold);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Condition True for Consecutive Samples Threshold Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid ConsecutiveSamplesThresholdWindowsPerfMonitorStateConditionTrueGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformanceConsecutiveSamplesoverThresholdName, ManagementPackConstants.MonitorTypeStateConditionTrue);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Condition False for Consecutive Samples Threshold Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid ConsecutiveSamplesThresholdWindowsPerfMonitorStateConditionFalseGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformanceConsecutiveSamplesoverThresholdName, ManagementPackConstants.MonitorTypeStateConditionFalse);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Under Threshold for Delta Threshold Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid DeltaThresholdWindowsPerfMonitorStateUnderThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformanceDeltaThresholdName, ManagementPackConstants.MonitorTypeStateUnderThreshold);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Over Threshold for Delta Threshold Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid DeltaThresholdWindowsPerfMonitorStateOverThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformanceDeltaThresholdName, ManagementPackConstants.MonitorTypeStateOverThreshold);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Under Lower Threshold for Double Threshold Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid DoubleThresholdWindowsPerfMonitorStateUnderLowerThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformanceDoubleThresholdName, ManagementPackConstants.MonitorTypeStateUnderLowerThreshold);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Between Threshold for Double Threshold Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid DoubleThresholdWindowsPerfMonitorStateBetweenThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformanceDoubleThresholdName, ManagementPackConstants.MonitorTypeStateBetweenThreshold);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Over Upper Threshold for Double Threshold Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid DoubleThresholdWindowsPerfMonitorStateOverUpperThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformanceDoubleThresholdName, ManagementPackConstants.MonitorTypeStateOverUpperThreshold);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Under Threshold for Simple Threshold Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid SimpleThresholdWindowsPerfMonitorStateUnderThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformanceSimpleThresholdName, ManagementPackConstants.MonitorTypeStateUnderThreshold);

            /// <summary>
            /// Contains GUID for: Monitor Type State: Over Lower Threshold for Simple Threshold Monitor in System.Performance.Library MP
            /// </summary> 
            public static Guid SimpleThresholdWindowsPerfMonitorStateOverThresholdGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPSubObjectIdAsGuid(ManagementPackConstants.SystemPerformanceLibraryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.WindowsPerformanceSimpleThresholdName, ManagementPackConstants.MonitorTypeStateOverThreshold);

            /// <summary>
            /// Contains GUID for: System.Web.HttpUrlCertificate Monitor
            /// </summary>            
            private const string HttpUrlCertificateMonitorGUID = "E57E46E5-CB15-0EBA-88F4-806183F007E1";

            /// <summary>
            /// Contains GUID for: System.Web.HttpUrlContent Monitor
            /// </summary>            
            private const string HttpUrlContentMonitorGUID = "F82A377A-F1C4-CA4D-49D5-A5B3A9C4BEA7";

            /// <summary>
            /// Contains GUID for: System.Web.HttpUrlStatusCode Monitor
            /// </summary>            
            private const string HttpUrlStatusCodeMonitorGUID = "88088149-C4A0-C79E-4B15-97B40DFC4FFE";

            /// <summary>
            /// Contains GUID for: Microsoft.DistributedApplication.WebFarmHealth Monitor
            /// </summary>            
            private const string DAWebFarmHealthMonitorGUID = "CFD646E1-D0EC-2B2A-1FAD-ACCCDE57F279";

            /// <summary>
            /// Contains GUID for: Microsoft.DistributedApplication.WebSiteGroupHealth Monitor
            /// </summary>            
            private const string DAWebSiteGroupHealthMonitorGUID = "0B525AB7-0D10-7CAF-A17E-E59A8B464823";

            /// <summary>
            /// Contains GUID for: Microsoft.DistributedApplication.DatabaseGroupHealth Monitor
            /// </summary>            
            private const string DADatabaseGroupHealthMonitorGUID = "75EF53F2-2282-C9C0-187F-EB6408F37FF9";

            /// <summary>
            /// Contains GUID for: System.Hardware.GroupCheckInterfaceStatus Monitor
            /// </summary>            
            private const string GroupCheckInterfaceStatusMonitorGUID = "F0ED7933-1DE9-356D-C832-E845F3FB6D6B";

            /// <summary>
            /// Contains GUID for: System.Hardware.CheckInterfaceStatus Monitor
            /// </summary>            
            private const string CheckInterfaceStatusMonitorGUID = "EC97976C-26BD-C09E-74D8-406458BDA611";

            /// <summary>
            /// Contains GUID for: System.Mom.BackwardCompatibility.SoftwareInstallation.PerformanceHealth Monitor
            /// </summary>            
            private const string SWInstallationPerfHealthMonitorGUID = "BAEF518F-A5D4-AE8A-4AB6-17A703F3D660";

            /// <summary>
            /// Contains GUID for: System.Mom.BackwardCompatibility.SoftwareInstallation.EventHealth Monitor
            /// </summary>            
            private const string SWInstallationEventHealthMonitorGUID = "38739F3E-D12D-43D7-1B81-526FC6AB1EAC";

            /// <summary>
            /// Contains GUID for: ThresholdAlerter Monitor
            /// </summary>            
            private const string ThresholdAlerterMonitorGUID = "3F58EAA1-B1C6-11E1-A0A9-11843551116F";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.BasePage.Availability Monitor
            /// </summary>            
            private const string WebPageBasePageAvailabilityMonitorGUID = "2633574F-6FF9-998D-148C-139424FE2C97";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.BasePage Monitor
            /// </summary>            
            private const string WebPageBasePageMonitorGUID = "FBBF2011-A89E-24A4-7AA9-487E647068E2";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.BasePage.Content Monitor
            /// </summary>            
            private const string WebPageBasePageContentMonitorGUID = "2AFB2807-BF56-58D7-A9F3-BDFBCD6252B4";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.BasePage.Performance Monitor
            /// </summary>            
            private const string WebPageBasePagePerformanceMonitorGUID = "91C0E640-8D94-40FC-6FBA-B53CC964BBA4";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.BasePage.StatusCode Monitor
            /// </summary>            
            private const string WebPageBasePageStatusCodeMonitorGUID = "E31BD85F-7407-46F7-5E65-46982BF3D653";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.Resources Monitor
            /// </summary>            
            private const string WebPageResourcesMonitorGUID = "06D8AA8A-85FA-3E23-88E2-31F64312C45F";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.Resources.Performance Monitor
            /// </summary>            
            private const string WebPageResourcesPerformanceMonitorGUID = "E8F09766-F4E2-96BA-CF92-56BDAC6671FC";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.Resources.StatusCode Monitor
            /// </summary>            
            private const string WebPageResourcesStatusCodeMonitorGUID = "17327BC8-19F8-257B-ED46-8DFECE25A022";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.Resources.Availability Monitor
            /// </summary>            
            private const string WebPageResourcesAvailabilityMonitorGUID = "978A4A75-9DE4-53BD-FF96-94856A346246";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.Total Monitor
            /// </summary>            
            private const string WebPageTotalMonitorGUID = "9B7CB6F9-60B3-B1AA-F8FE-B6BD3E283EC5";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.Total.Performance Monitor
            /// </summary>            
            private const string WebPageTotalPerformanceMonitorGUID = "6A0A8A13-65E4-DEB0-23D9-B8F5CC900991";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.Total.StatusCode Monitor
            /// </summary>            
            private const string WebPageTotalStatusCodeMonitorGUID = "EA5044BF-011A-1AD8-7E76-20816D539D96";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.Total.Availability Monitor
            /// </summary>            
            private const string WebPageTotalAvailabilityMonitorGUID = "A6465789-BE72-D3B3-E9F6-305DEC118468";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.Links Monitor
            /// </summary>            
            private const string WebPageLinksMonitorGUID = "8E982464-6E95-4AAD-1BB1-144A1B457A0D";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.Links.Performance Monitor
            /// </summary>            
            private const string WebPageLinksPerformanceMonitorGUID = "25A47DCD-A496-49E8-4761-9B235688E532";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.Links.StatusCode Monitor
            /// </summary>            
            private const string WebPageLinksStatusCodeMonitorGUID = "73198C26-3577-FE27-4838-7C0AE4ECE83C";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.Links.Availability Monitor
            /// </summary>            
            private const string WebPageLinksAvailabilityMonitorGUID = "34D3DFCD-E4D9-C579-3C41-255F7F4D92A1";

            /// <summary>
            /// Contains GUID for: System.Web.WebPage.Overall Monitor
            /// </summary>            
            private const string WebPageOverallMonitorGUID = "73169304-83C2-0DA3-4918-9A6B9D74C370";
            #endregion

            #endregion //Constants

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Error Health State in health Configuration Dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedErrorHealthState;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Warning Health State in health Configuration Dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWarningHealthState;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Success Health State in health Configuration Dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSuccessHealthState;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Alert Priority Medium in the Monitor wizard Configure Alert Dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertPriorityMedium;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Alert Priority Low in the Monitor wizard Configure Alert Dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertPriorityLow;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Alert Priority High in the Monitor wizard Configure Alert Dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertPriorityHigh;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for for Confirm Monitor Delete Dialog Title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfirmMonitorDeleteTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Alert Severity Match Monitor's Health in the Monitor wizard Configure Alert Dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertSeverityMatchMonitorHealth;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Alert Severity Warning in the Monitor wizard Configure Alert Dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertSeverityWarning;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Alert Severity Information in the Monitor wizard Configure Alert Dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertSeverityInformation;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Alert Severity Critical in the Monitor wizard Configure Alert Dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertSeverityCritical;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Alerting Tab Title on Monitor Property Page
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertingTabTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for Monitors pivoted view window
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitors;

            #region Monitor GUIDS

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Entity Health Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEntityHealthMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Availability Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAvailabilityMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Configuration Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigurationMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Performance Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPerformanceMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Security Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSecurityMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: NTService Service Running Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTServiceRunningMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: NTService Service State Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTServiceStateMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Windows Service Stopped AlertMessage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTServiceStateMonitorAlertMessage;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.OwnProcessNTService.MonitorPercentProcessorTime Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTPercentProcessorTimeMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.OwnProcessNTService.MonitorHandleCount Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTHandleCountMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.OwnProcessNTService.MonitorThreadCount Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTThreadCountMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Windows.OwnProcessNTService.MonitorWorkingSet Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNTWorkingSetMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.HttpUrlCertificate Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHttpUrlCertificateMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.HttpUrlContent Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHttpUrlContentMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.HttpUrlStatusCode Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHttpUrlStatusCodeMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Microsoft.DistributedApplication.WebFarmHealth Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDAWebFarmHealthMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Microsoft.DistributedApplication.WebSiteGroupHealth Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDAWebSiteGroupHealthMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: Microsoft.DistributedApplication.DatabaseGroupHealth Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDADatabaseGroupHealthMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Hardware.GroupCheckInterfaceStatus Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGroupCheckInterfaceStatusMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Hardware.CheckInterfaceStatus Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCheckInterfaceStatusMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Mom.BackwardCompatibility.SoftwareInstallation.PerformanceHealth Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSWInstallationPerfHealthMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Mom.BackwardCompatibility.SoftwareInstallation.EventHealth Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSWInstallationEventHealthMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: ThresholdAlerter Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThresholdAlerterMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.BasePage.Availability Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageBasePageAvailabilityMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.BasePage Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageBasePageMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.BasePage.Content Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageBasePageContentMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.BasePage.Performance Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageBasePagePerformanceMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.BasePage.StatusCode Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageBasePageStatusCodeMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.Resources Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageResourcesMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.Resources.Performance Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageResourcesPerformanceMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.Resources.StatusCode Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageResourcesStatusCodeMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.Resources.Availability Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageResourcesAvailabilityMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.Total Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageTotalMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.Total.Performance Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageTotalPerformanceMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.Total.StatusCode Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageTotalStatusCodeMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.Total.Availability Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageTotalAvailabilityMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.Links Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageLinksMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.Links.Performance Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageLinksPerformanceMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.Links.StatusCode Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageLinksStatusCodeMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.Links.Availability Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageLinksAvailabilityMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated display name string for: System.Web.WebPage.Overall Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWebPageOverallMonitor;

            #endregion

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 19-Aug-05 Created
            ///     [barryw] 27DEC05 Moved from LogNameDialog.cs.
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }
                    return cachedDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Error Health State in health Configuration Dialog
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 23MAR06 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ErrorHealthState
            {
                get
                {
                    if ((cachedErrorHealthState == null))
                    {
                        cachedErrorHealthState = CoreManager.MomConsole.GetIntlStr(ResourceErrorHealthState);
                    }
                    return cachedErrorHealthState;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Success Health State in health Configuration Dialog
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 23MAR06 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SuccessHealthState
            {
                get
                {
                    if ((cachedSuccessHealthState == null))
                    {
                        cachedSuccessHealthState = CoreManager.MomConsole.GetIntlStr(ResourceSuccessHealthState);
                    }
                    return cachedSuccessHealthState;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Warning Health State in health Configuration Dialog
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 23MAR06 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WarningHealthState
            {
                get
                {
                    if ((cachedWarningHealthState == null))
                    {
                        cachedWarningHealthState = CoreManager.MomConsole.GetIntlStr(ResourceWarningHealthState);
                    }
                    return cachedWarningHealthState;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Priority Medium in the Monitor wizard 
            /// Configure Alert Dialog translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 13APR06 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertPriorityMedium
            {
                get
                {
                    if ((cachedAlertPriorityMedium == null))
                    {
                        cachedAlertPriorityMedium = CoreManager.MomConsole.GetIntlStr(ResourceAlertPriorityMedium);
                    }
                    return cachedAlertPriorityMedium;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Priority Low in the Monitor wizard 
            /// Configure Alert Dialog translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 13APR06 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertPriorityLow
            {
                get
                {
                    if ((cachedAlertPriorityLow == null))
                    {
                        cachedAlertPriorityLow = CoreManager.MomConsole.GetIntlStr(ResourceAlertPriorityLow);
                    }
                    return cachedAlertPriorityLow;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Priority High in the Monitor wizard 
            /// Configure Alert Dialog translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 13APR06 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertPriorityHigh
            {
                get
                {
                    if ((cachedAlertPriorityHigh == null))
                    {
                        cachedAlertPriorityHigh = CoreManager.MomConsole.GetIntlStr(ResourceAlertPriorityHigh);
                    }
                    return cachedAlertPriorityHigh;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the for Confirm Monitor Delete Dialog Title translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 05Sep06 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfirmMonitorDeleteTitle
            {
                get
                {
                    if ((cachedConfirmMonitorDeleteTitle == null))
                    {
                        cachedConfirmMonitorDeleteTitle = CoreManager.MomConsole.GetIntlStr(ResourceConfirmMonitorDeleteTitle);
                    }
                    return cachedConfirmMonitorDeleteTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Severity Match Monitor's Health in the Monitor wizard 
            /// Configure Alert Dialog translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 17APR07 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertSeverityMatchMonitorHealth
            {
                get
                {
                    if ((cachedAlertSeverityMatchMonitorHealth == null))
                    {
                        cachedAlertSeverityMatchMonitorHealth = CoreManager.MomConsole.GetIntlStr(ResourceAlertSeverityMatchMonitorHealth);
                    }
                    return cachedAlertSeverityMatchMonitorHealth;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Severity Warning in the Monitor wizard 
            /// Configure Alert Dialog translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 17APR07 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertSeverityWarning
            {
                get
                {
                    if ((cachedAlertSeverityWarning == null))
                    {
                        cachedAlertSeverityWarning = CoreManager.MomConsole.GetIntlStr(ResourceAlertSeverityWarning);
                    }
                    return cachedAlertSeverityWarning;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Severity Information in the Monitor wizard 
            /// Configure Alert Dialog translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 17APR07 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertSeverityInformation
            {
                get
                {
                    if ((cachedAlertSeverityInformation == null))
                    {
                        cachedAlertSeverityInformation = CoreManager.MomConsole.GetIntlStr(ResourceAlertSeverityInformation);
                    }
                    return cachedAlertSeverityInformation;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alert Severity Critical in the Monitor wizard 
            /// Configure Alert Dialog translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 17APR07 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertSeverityCritical
            {
                get
                {
                    if ((cachedAlertSeverityCritical == null))
                    {
                        cachedAlertSeverityCritical = CoreManager.MomConsole.GetIntlStr(ResourceAlertSeverityCritical);
                    }
                    return cachedAlertSeverityCritical;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alerting Tab Title on Monitor Property Page translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 26May08 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertingTabTitle
            {
                get
                {
                    if ((cachedAlertingTabTitle == null))
                    {
                        cachedAlertingTabTitle = CoreManager.MomConsole.GetIntlStr(ResourceAlertingTabTitle);
                    }
                    return cachedAlertingTabTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitors pivoted view window translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 19FEB09 Created                 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Monitors
            {
                get
                {
                    if ((cachedMonitors == null))
                    {
                        cachedMonitors = CoreManager.MomConsole.GetIntlStr(ResourceMonitors);
                    }
                    return cachedMonitors;
                }
            }

            #region Monitor GUIDS

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Entity Health Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EntityHealthMonitor
            {
                get
                {
                    if ((cachedEntityHealthMonitor == null))
                    {
                        cachedEntityHealthMonitor = Common.Utilities.GetMonitorName(Constants.GUIDEntityManagedType, EntityHealthMonitorGUID);
                    }

                    return cachedEntityHealthMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Availability Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AvailabilityMonitor
            {
                get
                {
                    if ((cachedAvailabilityMonitor == null))
                    {
                        cachedAvailabilityMonitor = Common.Utilities.GetMonitorName(Constants.GUIDEntityManagedType, AvailabilityMonitorGUID);
                    }

                    return cachedAvailabilityMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Configuration Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigurationMonitor
            {
                get
                {
                    if ((cachedConfigurationMonitor == null))
                    {
                        cachedConfigurationMonitor = Common.Utilities.GetMonitorName(Constants.GUIDEntityManagedType, ConfigurationMonitorGUID);
                    }

                    return cachedConfigurationMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Performance Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PerformanceMonitor
            {
                get
                {
                    if ((cachedPerformanceMonitor == null))
                    {
                        cachedPerformanceMonitor = Common.Utilities.GetMonitorName(Constants.GUIDEntityManagedType, PerformanceMonitorGUID);
                    }

                    return cachedPerformanceMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Security Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SecurityMonitor
            {
                get
                {
                    if ((cachedSecurityMonitor == null))
                    {
                        cachedSecurityMonitor = Common.Utilities.GetMonitorName(Constants.GUIDEntityManagedType, SecurityMonitorGUID);
                    }

                    return cachedSecurityMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: NTService Service Running Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTServiceRunningMonitor
            {
                get
                {
                    if ((cachedNTServiceRunningMonitor == null))
                    {
                        cachedNTServiceRunningMonitor = Common.Utilities.GetMonitorName(Constants.GUIDNTServiceManagedType, NTServiceRunningMonitorGUID);
                    }

                    return cachedNTServiceRunningMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: NTService State Monitor
            /// </summary>
            /// <history>
            /// 	[a-joelj] 18MAR09: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTServiceStateMonitor
            {
                get
                {
                    if ((cachedNTServiceStateMonitor == null))
                    {
                        cachedNTServiceStateMonitor = Common.Utilities.GetMonitorName(Constants.GUIDNTServiceManagedType, NTServiceRunningMonitorGUID);
                    }

                    return cachedNTServiceStateMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Windows Service Stopped
            /// </summary>
            /// <history>
            /// 	[a-joelj] 19MAR09: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTServiceStateMonitorAlertMessage
            {
                get
                {
                    if ((cachedNTServiceStateMonitorAlertMessage == null))
                    {
                        cachedNTServiceStateMonitorAlertMessage = Common.Utilities.GetMonitorAlertName(NTServiceRunningMonitorGUID);

                    }

                    return cachedNTServiceStateMonitorAlertMessage;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.OwnProcessNTService.MonitorPercentProcessorTime Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTPercentProcessorTimeMonitor
            {
                get
                {
                    if ((cachedNTPercentProcessorTimeMonitor == null))
                    {
                        cachedNTPercentProcessorTimeMonitor = Common.Utilities.GetMonitorName(Constants.GUIDOwnProcessNTServiceManagedType, NTPercentProcessorTimeMonitorGUID);
                    }

                    return cachedNTPercentProcessorTimeMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.OwnProcessNTService.MonitorHandleCount Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTHandleCountMonitor
            {
                get
                {
                    if ((cachedNTHandleCountMonitor == null))
                    {
                        cachedNTHandleCountMonitor = Common.Utilities.GetMonitorName(Constants.GUIDOwnProcessNTServiceManagedType, NTHandleCountMonitorGUID);
                    }

                    return cachedNTHandleCountMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.OwnProcessNTService.MonitorThreadCount Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTThreadCountMonitor
            {
                get
                {
                    if ((cachedNTThreadCountMonitor == null))
                    {
                        cachedNTThreadCountMonitor = Common.Utilities.GetMonitorName(Constants.GUIDOwnProcessNTServiceManagedType, NTThreadCountMonitorGUID);
                    }

                    return cachedNTThreadCountMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Windows.OwnProcessNTService.MonitorWorkingSet Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NTWorkingSetMonitor
            {
                get
                {
                    if ((cachedNTWorkingSetMonitor == null))
                    {
                        cachedNTWorkingSetMonitor = Common.Utilities.GetMonitorName(Constants.GUIDOwnProcessNTServiceManagedType, NTWorkingSetMonitorGUID);
                    }

                    return cachedNTWorkingSetMonitor;
                }
            }



            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.HttpUrlCertificate Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HttpUrlCertificateMonitor
            {
                get
                {
                    if ((cachedHttpUrlCertificateMonitor == null))
                    {
                        cachedHttpUrlCertificateMonitor = Common.Utilities.GetMonitorName(Constants.GUIDHttpUrlPerspectiveManagedType, HttpUrlCertificateMonitorGUID);
                    }

                    return cachedHttpUrlCertificateMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.HttpUrlContent Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HttpUrlContentMonitor
            {
                get
                {
                    if ((cachedHttpUrlContentMonitor == null))
                    {
                        cachedHttpUrlContentMonitor = Common.Utilities.GetMonitorName(Constants.GUIDHttpUrlPerspectiveManagedType, HttpUrlContentMonitorGUID);
                    }

                    return cachedHttpUrlContentMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.HttpUrlStatusCode Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HttpUrlStatusCodeMonitor
            {
                get
                {
                    if ((cachedHttpUrlStatusCodeMonitor == null))
                    {
                        cachedHttpUrlStatusCodeMonitor = Common.Utilities.GetMonitorName(Constants.GUIDHttpUrlPerspectiveManagedType, HttpUrlStatusCodeMonitorGUID);
                    }

                    return cachedHttpUrlStatusCodeMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.DistributedApplication.WebFarmHealth Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DAWebFarmHealthMonitor
            {
                get
                {
                    if ((cachedDAWebFarmHealthMonitor == null))
                    {
                        cachedDAWebFarmHealthMonitor = Common.Utilities.GetMonitorName(Constants.GUIDDAWebFarmManagedType, DAWebFarmHealthMonitorGUID);
                    }

                    return cachedDAWebFarmHealthMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.DistributedApplication.WebSiteGroupHealth Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DAWebSiteGroupHealthMonitor
            {
                get
                {
                    if ((cachedDAWebSiteGroupHealthMonitor == null))
                    {
                        cachedDAWebSiteGroupHealthMonitor = Common.Utilities.GetMonitorName(Constants.GUIDDAWebSiteServiceManagedType, DAWebSiteGroupHealthMonitorGUID);
                    }

                    return cachedDAWebSiteGroupHealthMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: Microsoft.DistributedApplication.DatabaseGroupHealth Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DADatabaseGroupHealthMonitor
            {
                get
                {
                    if ((cachedDADatabaseGroupHealthMonitor == null))
                    {
                        cachedDADatabaseGroupHealthMonitor = Common.Utilities.GetMonitorName(Constants.GUIDDADatabaseServiceManagedType, DADatabaseGroupHealthMonitorGUID);
                    }

                    return cachedDADatabaseGroupHealthMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Hardware.GroupCheckInterfaceStatus Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GroupCheckInterfaceStatusMonitor
            {
                get
                {
                    if ((cachedGroupCheckInterfaceStatusMonitor == null))
                    {
                        cachedGroupCheckInterfaceStatusMonitor = Common.Utilities.GetMonitorName(Constants.GUIDGenericSnmpDeviceGroupManagedType, GroupCheckInterfaceStatusMonitorGUID);
                    }

                    return cachedGroupCheckInterfaceStatusMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Hardware.CheckInterfaceStatus Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CheckInterfaceStatusMonitor
            {
                get
                {
                    if ((cachedCheckInterfaceStatusMonitor == null))
                    {
                        cachedCheckInterfaceStatusMonitor = Common.Utilities.GetMonitorName(Constants.GUIDGenericSnmpDeviceManagedType, CheckInterfaceStatusMonitorGUID);
                    }

                    return cachedCheckInterfaceStatusMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Mom.BackwardCompatibility.SoftwareInstallation.PerformanceHealth Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SWInstallationPerfHealthMonitor
            {
                get
                {
                    if ((cachedSWInstallationPerfHealthMonitor == null))
                    {
                        cachedSWInstallationPerfHealthMonitor = Common.Utilities.GetMonitorName(Constants.GUIDSoftwareInstallationManagedType, SWInstallationPerfHealthMonitorGUID);
                    }

                    return cachedSWInstallationPerfHealthMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Mom.BackwardCompatibility.SoftwareInstallation.EventHealth Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SWInstallationEventHealthMonitor
            {
                get
                {
                    if ((cachedSWInstallationEventHealthMonitor == null))
                    {
                        cachedSWInstallationEventHealthMonitor = Common.Utilities.GetMonitorName(Constants.GUIDSoftwareInstallationManagedType, SWInstallationEventHealthMonitorGUID);
                    }

                    return cachedSWInstallationEventHealthMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: ThresholdAlerter Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThresholdAlerterMonitor
            {
                get
                {
                    if ((cachedThresholdAlerterMonitor == null))
                    {
                        cachedThresholdAlerterMonitor = Common.Utilities.GetMonitorName(Constants.GUIDAEMFileShareManagedType, ThresholdAlerterMonitorGUID);
                    }

                    return cachedThresholdAlerterMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.BasePage.Availability Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageBasePageAvailabilityMonitor
            {
                get
                {
                    if ((cachedWebPageBasePageAvailabilityMonitor == null))
                    {
                        cachedWebPageBasePageAvailabilityMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageBasePageAvailabilityMonitorGUID);
                    }

                    return cachedWebPageBasePageAvailabilityMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.BasePage Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageBasePageMonitor
            {
                get
                {
                    if ((cachedWebPageBasePageMonitor == null))
                    {
                        cachedWebPageBasePageMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageBasePageMonitorGUID);
                    }

                    return cachedWebPageBasePageMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.BasePage.Content Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageBasePageContentMonitor
            {
                get
                {
                    if ((cachedWebPageBasePageContentMonitor == null))
                    {
                        cachedWebPageBasePageContentMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageBasePageContentMonitorGUID);
                    }

                    return cachedWebPageBasePageContentMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.BasePage.Performance Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageBasePagePerformanceMonitor
            {
                get
                {
                    if ((cachedWebPageBasePagePerformanceMonitor == null))
                    {
                        cachedWebPageBasePagePerformanceMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageBasePagePerformanceMonitorGUID);
                    }

                    return cachedWebPageBasePagePerformanceMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.BasePage.StatusCode Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageBasePageStatusCodeMonitor
            {
                get
                {
                    if ((cachedWebPageBasePageStatusCodeMonitor == null))
                    {
                        cachedWebPageBasePageStatusCodeMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageBasePageStatusCodeMonitorGUID);
                    }

                    return cachedWebPageBasePageStatusCodeMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.Resources Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageResourcesMonitor
            {
                get
                {
                    if ((cachedWebPageResourcesMonitor == null))
                    {
                        cachedWebPageResourcesMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageResourcesMonitorGUID);
                    }

                    return cachedWebPageResourcesMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.Resources.Performance Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageResourcesPerformanceMonitor
            {
                get
                {
                    if ((cachedWebPageResourcesPerformanceMonitor == null))
                    {
                        cachedWebPageResourcesPerformanceMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageResourcesPerformanceMonitorGUID);
                    }

                    return cachedWebPageResourcesPerformanceMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.Resources.StatusCode Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageResourcesStatusCodeMonitor
            {
                get
                {
                    if ((cachedWebPageResourcesStatusCodeMonitor == null))
                    {
                        cachedWebPageResourcesStatusCodeMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageResourcesStatusCodeMonitorGUID);
                    }

                    return cachedWebPageResourcesStatusCodeMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.Resources.Availability Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageResourcesAvailabilityMonitor
            {
                get
                {
                    if ((cachedWebPageResourcesAvailabilityMonitor == null))
                    {
                        cachedWebPageResourcesAvailabilityMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageResourcesAvailabilityMonitorGUID);
                    }

                    return cachedWebPageResourcesAvailabilityMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.Total Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageTotalMonitor
            {
                get
                {
                    if ((cachedWebPageTotalMonitor == null))
                    {
                        cachedWebPageTotalMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageTotalMonitorGUID);
                    }

                    return cachedWebPageTotalMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.Total.Performance Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageTotalPerformanceMonitor
            {
                get
                {
                    if ((cachedWebPageTotalPerformanceMonitor == null))
                    {
                        cachedWebPageTotalPerformanceMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageTotalPerformanceMonitorGUID);
                    }

                    return cachedWebPageTotalPerformanceMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.Total.StatusCode Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageTotalStatusCodeMonitor
            {
                get
                {
                    if ((cachedWebPageTotalStatusCodeMonitor == null))
                    {
                        cachedWebPageTotalStatusCodeMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageTotalStatusCodeMonitorGUID);
                    }

                    return cachedWebPageTotalStatusCodeMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.Total.Availability Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageTotalAvailabilityMonitor
            {
                get
                {
                    if ((cachedWebPageTotalAvailabilityMonitor == null))
                    {
                        cachedWebPageTotalAvailabilityMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageTotalAvailabilityMonitorGUID);
                    }

                    return cachedWebPageTotalAvailabilityMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.Links Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageLinksMonitor
            {
                get
                {
                    if ((cachedWebPageLinksMonitor == null))
                    {
                        cachedWebPageLinksMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageLinksMonitorGUID);
                    }

                    return cachedWebPageLinksMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.Links.Performance Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageLinksPerformanceMonitor
            {
                get
                {
                    if ((cachedWebPageLinksPerformanceMonitor == null))
                    {
                        cachedWebPageLinksPerformanceMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageLinksPerformanceMonitorGUID);
                    }

                    return cachedWebPageLinksPerformanceMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.Links.StatusCode Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageLinksStatusCodeMonitor
            {
                get
                {
                    if ((cachedWebPageLinksStatusCodeMonitor == null))
                    {
                        cachedWebPageLinksStatusCodeMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageLinksStatusCodeMonitorGUID);
                    }

                    return cachedWebPageLinksStatusCodeMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.Links.Availability Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageLinksAvailabilityMonitor
            {
                get
                {
                    if ((cachedWebPageLinksAvailabilityMonitor == null))
                    {
                        cachedWebPageLinksAvailabilityMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageLinksAvailabilityMonitorGUID);
                    }

                    return cachedWebPageLinksAvailabilityMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to display name string for: System.Web.WebPage.Overall Monitor
            /// </summary>
            /// <history>
            /// 	[ruhim] 01NOV05: Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageOverallMonitor
            {
                get
                {
                    if ((cachedWebPageOverallMonitor == null))
                    {
                        cachedWebPageOverallMonitor = Common.Utilities.GetMonitorName(Constants.GUIDWebPagePerspectiveManagedType, WebPageOverallMonitorGUID);
                    }

                    return cachedWebPageOverallMonitor;
                }
            }
            #endregion

            #endregion
        }
        #endregion
    }
}
