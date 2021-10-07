//-------------------------------------------------------------------
// <copyright file="StateWidget.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   State View
// </summary>
//  <history>
 // [v-juli] 2/22/2011 Created
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Views.StateWidget
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MomCommon = Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Common;
    using MomConsole = Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Console.MomControls;
    using Maui.Core.WinControls;
    using Maui.Core;
    using Maui.Core.Utilities;
    using System.Xml.Linq;
    using Mom.Test.UI.Core.ResourceLoader;
    using System.Reflection;
    using System.IO;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
    using Mom.Test.UI.Core.Console.MomControls.DashboardControls;
    #endregion

    /// <summary>
    /// Enum Options
    /// Contain options to launch Entity Properties
    /// Some other options will be added possibly
    /// </summary>    
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
    /// Performance View
    /// </summary>
    public class StateWidget: DataGridViewHost
    {
        public static string DefaultMPName = MomConsole.ConsoleConstants.DefaultManagementPackName;

        private ObjectPropertiesDialog cachedObjectPropertiesDialog = null;
               
        [Resource(ID = "Healthy")]
        private string healthy;
        private static string healthyCheckbox;

        [Resource(ID = "Warning")]
        private string warning;
        private static string warningCheckbox;

        [Resource(ID = "Critical")]
        private string critical;
        private string criticalCheckbox;

        [Resource(ID = "NotMonitored")]
        private string notMonitored;
        private string notMonitoredCheckbox;

        [Resource(ID = "ShowMembers")]
        private string showMembers;

        [Resource(ID = "EntityProperties")]
        private string entityProperties;
        public string entityPropertiesMenu;

        [Resource(ID = "DisplayName")]
        private string displayName;
        public string displayNameColumn;

        [Resource(ID = "Health")]
        private string health;
        public string healthColumn;

        [Resource(ID = "Path")]
        private string path;
        public string pathColumn;

        [Resource(ID = "MaintenanceMode")]
        private string maintenanceMode;
        public string maintenanceModeColumn;

        public FilterControl filter;
       
        public ObjectPropertiesDialog objectPropertiesGeneralDialog
        {
            get
            {
                if (this.cachedObjectPropertiesDialog == null)
                {
                    this.cachedObjectPropertiesDialog = new ObjectPropertiesDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the  Properties General Dialog was successful");
                }

                return this.cachedObjectPropertiesDialog;
            }
        }

        #region Constructor
       
        /// <summary>
        /// State View
        /// </summary>
        public StateWidget(Window knownWindow)
            : base(knownWindow)
        {
            Mom.Test.UI.Core.Common.SDKConnectionManager.Init(((MachineInfo)Topology.MomServersInfo[0]).MachineName);
            Mom.Test.UI.Core.ResourceLoader.ResourceLoader.Connection = Mom.Test.UI.Core.Common.Utilities.ConnectToManagementServer(((MachineInfo)Topology.MomServersInfo[0]).MachineName);
            var assembly = Assembly.GetExecutingAssembly();
            
            var stream = new StreamReader(assembly.GetManifestResourceStream("Mom.Test.UI.Core.Console.Views.StateWidget.StateWidgetResource.xml"));
            
            //var stream = new StreamReader(assembly.GetManifestResourceStream("Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.StateWidgetResource.xml"));
            XDocument dashboardWizardDocument = XDocument.Load(stream);
            //XDocument dashboardWizardDocument1 = XDocument.Load(streamWizard);
            XElement EmbemdedStateWidgetComponentResource = ResourceLoader.GetSection("StateWidgetComponent", dashboardWizardDocument);
            //XElement EmbemdedStateWidgetComponentResource1 = ResourceLoader.GetSection("StateWidgetComponent", dashboardWizardDocument1);                        
            ResourceLoader.LoadResources(this, EmbemdedStateWidgetComponentResource);
            //ResourceLoader.LoadResources(this, EmbemdedStateWidgetComponentResource1);
              
            healthyCheckbox = healthy;
            warningCheckbox = warning;
            criticalCheckbox = critical;
            notMonitoredCheckbox = notMonitored;
            entityPropertiesMenu = entityProperties;
            //WI: 234771 Workaroud bug 228923
            displayNameColumn = Core.Console.Views.Views.Strings.DisplayNameColumnHeader;
            //displayNameColumn = displayName;
            healthColumn = health;
            pathColumn = path;
            maintenanceModeColumn = maintenanceMode;

            filter = new FilterControl(knownWindow);
        }
        #endregion

        #region Public Methods      

        public void SelectInstanceByID(int rowId)
        {
            if (rowId != null && rowId != -1)
            {
                Utilities.LogMessage("Looking For DataGrid RowId: " + rowId);
                this.ScreenElement.EnsureVisible();
                this.DataGrid.SelectRow(rowId);
                Utilities.LogMessage("Selected row: " + rowId);
            }
        }

        public void SelectStateProperties(
           Options alertOptions, int rowId)
        {            
            string currentMethod = MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod +" :: Create instance of grid control");

            // Create instance of State View Grid Control
            var viewGrid = this.DataGrid;

            
            if (this.DataGrid.RowsExtended.Count >= 1)
            {
                Utilities.LogMessage(currentMethod + " :: column position:");
               
                // Switch options to launch Entity Properties
                viewGrid.SelectRow(rowId);
                int i = 0;
                while (!viewGrid.RowsExtended[rowId].ScreenElementExtended.HasFocus && i < 5)
                {
                    viewGrid.SelectRow(rowId);
                    Sleeper.Delay(10000);
                    i++;
                }
                switch (alertOptions)
                {
                    case Options.RightClickContextMenuOption:                        
                        CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, MomCommon.Constants.OneMinute);
                        //WI:229131
                        i = 0;
                        while (i < 5)
                        {
                            i++;
                            try
                            {
                                CoreManager.MomConsole.ExecuteDashboardContextMenu(this.entityProperties, true);
                                break;
                            }
                            catch(Exception ex)
                            {
                                Utilities.LogMessage(ex.ToString());
                                Sleeper.Delay(10000);
                            }
                        }
                        //CoreManager.MomConsole.ExecuteContextMenu(this.entityProperties, true);                        
                        Utilities.LogMessage(currentMethod + " :: " +
                            "LaunchStatePropertiesViaRightClick is done");
                        break;
                    case Options.DoubleClickOption:                          
                        CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, MomCommon.Constants.OneMinute);
                        viewGrid.RowsExtended[rowId].ScreenElementExtended.DoubleClick(-1, -1, true, KeyboardFlags.NoFlag);
                        Utilities.LogMessage(currentMethod + " :: " +
                            "LaunchStatePropertiesViaDoubleClickOption is done");
                        break;
                    case Options.TasksPaneActionOption:
                        ActionsPane actionsPane = new ActionsPane(CoreManager.MomConsole);                        
                        actionsPane.ClickLink(Core.Console.Tasks.Tasks.Strings.TasksActionPane, this.entityProperties);
                        Utilities.LogMessage(currentMethod + " :: " +
                            "LaunchAlertPropertiesViaTasksPaneClick");

                        break;
                    default:
                        Utilities.LogMessage(currentMethod + " :: " +
                            "Invalid option to launch Entity Properties was passed");
                        break;
                } // end switch
                
                // Take a screenshot
                Utilities.TakeScreenshot("LaunchedStatePropertiesViaOptionProvided");
            } // end if 
        }

        /// <summary>
        /// Verify state properties contains correct object name
        /// </summary>
        /// <param name="columns">columns</param>
        /// <param name="selectedRow">selectedRow</param>
        /// <returns></returns>
        public bool VerifyStateProperties(List<string> columns, List<string> selectedRow)
        {
            // var selectedRow = this.DataGrid.GetSelectedRow();
            string currentMethod = MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + " :: Starting VerifyStateProperties");
            
            this.objectPropertiesGeneralDialog.Extended.SetFocus();
            
           

            int retryTime = 1;
            int maxRetry = 10;
            while (retryTime < maxRetry)
            {
                if (columns != null)
                {
                    Utilities.TakeScreenshot("SetFocusOnProperties...");
                    Utilities.LogMessage("columns count :" + columns.Count.ToString());
                    foreach (string column in columns)
                    {
                        Utilities.LogMessage("columns item :" + column);
                    }
                }
                Sleeper.Delay(3000);  //wait for properties dialog ready
                int index = columns.IndexOf(displayNameColumn);
                Utilities.LogMessage("index:" + index.ToString());
                if(index < 0)
                {
                    index = columns.IndexOf(displayName);
                    retryTime++;
                    continue;
                }
                Utilities.LogMessage("index after reset:" + index.ToString());
                if (selectedRow != null)
                {
                    Utilities.LogMessage("SelectRow.Count:" + selectedRow.Count.ToString());
                }
                if (!this.objectPropertiesGeneralDialog.Controls.HTMLDoc.Document2.body.innerText.Contains(selectedRow[index]))
                {
                    Utilities.LogMessage(currentMethod + ":: VerifyStateProperties failed.");
                    this.objectPropertiesGeneralDialog.ClickOK();
                    return false;
                }
                Utilities.LogMessage(currentMethod + ":: VerifyStateProperties successfully.");
                this.objectPropertiesGeneralDialog.ClickOK();
                break; 
            }
            if (retryTime >= maxRetry)
            {
                throw new ArgumentOutOfRangeException("VerifyStateProperties");
            }
            return true;
        }

        public List<string> GetColumnLocString(string[] columnName)
        {
            string currentMethod = MethodBase.GetCurrentMethod().Name;
            MomCommon.Utilities.LogMessage(currentMethod + "...");

            List<string> actualColumnString = new List<string>();
           
            foreach (string name in columnName)
            {
                switch (name)
                {
                    case "Display Name":
                        actualColumnString.Add(displayNameColumn);
                        break;
                    case "Path":
                        actualColumnString.Add(pathColumn);
                        break;
                    case "Health":
                        actualColumnString.Add(healthColumn);
                        break;
                    case "Maintenance Mode":
                        actualColumnString.Add(maintenanceModeColumn);
                        break;
                    case "Healthy":
                        actualColumnString.Add(healthyCheckbox);
                        break;
                    case "Warning":
                        actualColumnString.Add(warningCheckbox);
                        break;
                    case "Critical":
                        actualColumnString.Add(criticalCheckbox);
                        break;
                    case "NotMonitored":
                        actualColumnString.Add(notMonitoredCheckbox);
                        break;
                    case "All":
                        actualColumnString.Add("All");
                        break;
                    default:
                        MomCommon.Utilities.LogMessage("GetColumnLocString :: No matched local string for " + name);
                        throw new ArgumentException("No matched local string for " + name);
                        break;
                }
            }

            return actualColumnString;
        }

        #endregion      

    }
}
