//  -----------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Templates.cs">
//     Copyright ?Microsoft 2005
// </copyright>
// <project>
//     Mom.Test.UI.Core.Console.MonitoringConfiguration
// </project>
// <summary>
//     This class contains helper functions for automation of the 
//     configuration of Templates 
// </summary>
// <history>
//      [ruhim]  13Jan06 Created
//      [ruhim]  03MAR06 Updated Resource string for Template wizard Title
//      [ruhim]  06MAR06 Adding Resource string for launching the wizard      
// </history>
//  -----------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MonitoringConfiguration
{
    #region Using directives
    using System;
    using System.Text;    
    using System.Globalization;
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.WinControls; 
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
    using Mom.Test.UI.Core.Console.Dialogs;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.WindowsService;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.WindowsService.Dialogs;

    #endregion

    /// <summary>
    /// Class to assist test automation related to Templates.
    /// </summary>
    /// <history> 	
    ///   [ruhim]  18Jan06: Created
    /// </history>
    public class Templates
    {  
        #region Private Constants
        private const int actualServiceNameColPos = 1;
        #endregion

        #region Private Members

        #endregion        

        /// <summary>
        /// Types of Monitored Compoenent Templates
        /// </summary>
        public enum ComponentType
        {
            /// <summary>
            /// Windows Service with Shared Process
            /// </summary>
            WindowsServiceSharedProcess,

            /// <summary>
            /// Windows Service with Standalone Process
            /// </summary>
            WindowsServiceStandaloneProcess,

            /// <summary>
            /// OLE DB Data Source
            /// </summary>
            OleDbDataSource,

            /// <summary>
            /// TCP Port
            /// </summary>
            TcpPort,

            /// <summary>
            /// Web Application
            /// </summary>
            WebApplication,

            /// <summary>
            /// Web Application Availability Monitoring for improvement branch 175851
            /// </summary>
            WebApplicationAvailabilityMonitoring,

            /// <summary>
            /// ASP.NET Application
            /// </summary>
            ASPNETApplication,

            /// <summary>
            /// ASP.NET Web Service
            /// </summary>
            ASPNETWebService,

            /// <summary>
            /// Process Monitor
            /// </summary>
            ProcessMonitor,

            /// <summary>
            /// Power Consumption 
            /// </summary>
            PowerConsumption,

        }

        /// <summary>
        /// Valid Query Interval Units
        /// </summary>
        public enum WatcherNodeQueryIntervalUnit
        {
            /// <summary>
            /// Seconds
            /// </summary>
            Seconds,

            /// <summary>
            /// Minutes
            /// </summary>
            Minutes,

            /// <summary>
            /// Hours
            /// </summary>
            Hours,

            /// <summary>
            /// Days
            /// </summary>
            Days,
        }

        #region Constructor

        /// <summary>
        /// Templates Constructor
        /// </summary>
        public Templates()
        {
            
        }
        #endregion

        #region Properties

        #endregion

        #region Public Methods
        /// <summary>
        /// Returns boolean indicating whether a particular component for a specifed Component 
        /// Type is found in the Monitored Components view or not.
        /// </summary>
        /// <param name="componentType">Enum defining the component type</param>                
        /// <param name="componentName">Component category name that you want to select</param>                
        /// <returns>bool</returns>        
        /// <history>
        /// [ruhim] 14APR06 - Created  
        /// [dialac] 26JAN09 - Adding supporting to the new Power Domain Template Type
        /// </history>
        public bool ComponentExists(ComponentType componentType, string componentName)
        {
            bool foundMonitor = false;
            Maui.Core.WinControls.DataGridViewRow monitoredCompoentRow = null;

            //Based on the Type parameter; Select the component Type resource string
            string typeSelected = null;
            switch (componentType)
            {
                case ComponentType.WindowsServiceSharedProcess:
                    typeSelected = SelectComponentTypeDialog.Strings.WindowsServiceSharedProcessTemplate;
                    break;

                case ComponentType.WindowsServiceStandaloneProcess:
                    typeSelected = SelectComponentTypeDialog.Strings.WindowsServiceStandaloneProcessTemplate;
                    break;

                case ComponentType.OleDbDataSource:
                    typeSelected = SelectComponentTypeDialog.Strings.OleDbTemplate;
                    break;

                case ComponentType.TcpPort:
                    typeSelected = SelectComponentTypeDialog.Strings.PortTemplate;
                    break;

                case ComponentType.WebApplication:
                    typeSelected = SelectComponentTypeDialog.Strings.WebApplicationTemplate;
                    break;

                case ComponentType.WebApplicationAvailabilityMonitoring:
                    typeSelected = SelectComponentTypeDialog.Strings.WebApplicationAvailabilityMonitoringTemplate;
                    break;

                case ComponentType.ASPNETApplication:
                    typeSelected = SelectComponentTypeDialog.Strings.ASPNETApplicationTemplate;
                    break;

                case ComponentType.ASPNETWebService:
                    typeSelected = SelectComponentTypeDialog.Strings.ASPNETWebServiceTemplate;
                    break;

		        case ComponentType.ProcessMonitor:
		            typeSelected = SelectComponentTypeDialog.Strings.ProcessMonitoringTemplate;
		        break;

                case ComponentType.PowerConsumption:
                    typeSelected = SelectComponentTypeDialog.Strings.PowerConsumptionTemplate;
                break;

                default:
                    Utilities.LogMessage("Templates.ComponentExists:: Component Type : '" +
                        componentType + "' is invalid");
                    throw new InvalidEnumArgumentException("Invalid Type selected");
            }
            
            //Go to Monitored coponent node in navigation pane
            string monitoredComponentsPath = NavigationPane.Strings.MonitoringConfiguration
                + "\\" 
                + NavigationPane.Strings.MonConfigTreeViewMonitoredComponents
                + "\\"
                + typeSelected;

            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            
            int maxTries = 0;
            //# retry attempts
            while(maxTries < 2)            
            {
                navPane.SelectNode(monitoredComponentsPath, NavigationPane.NavigationTreeView.MonitoringConfiguration);
                Utilities.LogMessage("Templates.ComponentExists:: Selected Node "
                    + componentType
                    + " in Navigation Pane");
                CoreManager.MomConsole.Waiters.WaitForStatusReady();
                monitoredCompoentRow = CoreManager.MomConsole.ViewPane.Grid.FindData(componentName, Core.Console.MomControls.GridControl.SearchStringMatchType.ExactMatch);
                if (monitoredCompoentRow != null)
                {
                    foundMonitor = true;
                    break;
                }                
                CoreManager.MomConsole.Refresh();
                CoreManager.MomConsole.Waiters.WaitForStatusReady();
                maxTries++;
            }  
            return foundMonitor;
        }

        /// <summary>
        /// Verify Synthetic Transaction component properties
        /// </summary>
        /// <param name="parameters">SynTxParameters</param>
        /// <param name="type">ComponentType</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [faizalk] 25APR2007 - Created   
        /// </history>
        public void VerifyComponentProperties(SynTxParameters parameters, ComponentType type)
        {
            Utilities.LogMessage("SynTx.VerifyComponentProperties");

            Templates templates = new Templates();

            // ComponentExists method handles the navigation
            if (!templates.ComponentExists(type, parameters.Name))
            {
                throw new Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException("could not find find SynTx component '" + parameters.Name + "'");
            }

            Maui.Core.WinControls.DataGridViewRow monitoredComponentRow = CoreManager.MomConsole.ViewPane.Grid.FindData(parameters.Name, Core.Console.MomControls.GridControl.SearchStringMatchType.ExactMatch);
            monitoredComponentRow.AccessibleObject.Click();
            Maui.Core.WinControls.Menu propertiesMenuItem = new Maui.Core.WinControls.Menu(ContextMenuAccessMethod.ShiftF10);
            //propertiesMenuItem.WaitContextMenuWithTimeOut(Constants.DefaultContextMenuTimeout*2);
            propertiesMenuItem.ScreenElement.WaitForReady();
            Utilities.LogMessage("Templates.VerifyComponentProperties :: Selecting '" + Views.Views.Strings.PropertiesContextMenu + "' menu item");
            propertiesMenuItem.ExecuteMenuItem(Views.Views.Strings.PropertiesContextMenu);

            Core.Console.MonitoringConfiguration.Dialogs.TemplateGeneralPropertiesDialog generalPropertiesDialog = new TemplateGeneralPropertiesDialog(CoreManager.MomConsole);

            // make sure controls are enabled correctly
            generalPropertiesDialog.Controls.Tab0TabControl.Tabs[0].Click();
            if (generalPropertiesDialog.Controls.SelectDestinationManagementPackComboBox.IsEnabled)
            {
                throw new Maui.Core.WinControls.ComboBox.Exceptions.ControlIsDisabledException("MP Destination combo box should be disabled but is not");
            }
            if (!generalPropertiesDialog.Controls.TargetAndPortTextBox.IsEnabled)
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Name textbox is disabled!");
            }
            if (!generalPropertiesDialog.Controls.SummaryTextBox.IsEnabled)
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Description textbox is disabled!");
            }

            // verify settings match parameters on General tab
            if (String.Compare(generalPropertiesDialog.TargetAndPortText, parameters.Name) != 0)
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.FailedToSetValueException("text '" + generalPropertiesDialog.TargetAndPortText + "' does not match '" + parameters.Name + "'");
            }
            if (String.Compare(generalPropertiesDialog.SummaryText, parameters.Description) != 0)
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.FailedToSetValueException("text '" + generalPropertiesDialog.SummaryText + "' does not match '" + parameters.Description + "'");
            }
            if (String.Compare(generalPropertiesDialog.SelectDestinationManagementPackText, parameters.DestinationMP) != 0)
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.FailedToSetValueException("text '" + generalPropertiesDialog.SelectDestinationManagementPackText + "' does not match '" + parameters.DestinationMP + "'");
            }

            // verify settings match parameters on Watcher Node tab
            generalPropertiesDialog.Controls.Tab0TabControl.Tabs[2].Click();
            Core.Console.MonitoringConfiguration.Dialogs.WatcherNodePropertiesDialog watcherPropertiesDialog = new WatcherNodePropertiesDialog(CoreManager.MomConsole);

            // make sure controls are enabled correctly
            if (!watcherPropertiesDialog.Controls.PortListView.IsEnabled)
            {
                throw new Maui.Core.WinControls.ListView.Exceptions.ControlIsDisabledException("Watcher node list view is disabled");
            }
            if (!watcherPropertiesDialog.Controls.RunThisQueryEveryComboBox.IsEnabled)
            {
                throw new Maui.Core.WinControls.ComboBox.Exceptions.ControlIsDisabledException("Run this query time unit combo box is disabled");
            }
            if (!watcherPropertiesDialog.Controls.ComboBox0.IsEnabled)
            {
                throw new Maui.Core.WinControls.ComboBox.Exceptions.ControlIsDisabledException("Run this query number spinner is disabled");
            }

            // verify properties match parameters
            if (null != parameters.WatcherNodes)
            {
                // find each watcher node in the listview (case insensitive)
                foreach (ListViewItem lvi in watcherPropertiesDialog.Controls.PortListView.Items)
                {
                    if (lvi.Checked)
                    {
                        if (Array.IndexOf(parameters.WatcherNodes, lvi.Text.Trim().ToLowerInvariant()) < 0)
                        {
                            throw new Maui.Core.WinControls.ListView.Exceptions.FailedToSetValueException(lvi.Text + " watcher node is checked but does not exist in parameters");
                        }
                    }
                    else // not checked so verify not in parameters
                    {
                        if (Array.IndexOf(parameters.WatcherNodes, lvi.Text.Trim().ToLowerInvariant()) > 0)
                        {
                            throw new Maui.Core.WinControls.ListView.Exceptions.FailedToSetValueException(lvi.Text + " watcher node is not checked but exists in parameters");
                        }
                    }
                }
            }
            else // all watcher nodes should be selected
            {
                foreach (ListViewItem lvi in watcherPropertiesDialog.Controls.PortListView.Items)
                {
                    if (!lvi.Checked)
                    {
                        throw new Maui.Core.WinControls.ListView.Exceptions.FailedToSetValueException(lvi.Text + " watcher node is not checked but all should be checked");
                    }
                }
            }

            if (null != parameters.QueryIntervalTime)
            {
                watcherPropertiesDialog.Controls.RunThisQueryEveryComboBox.Click();
                watcherPropertiesDialog.Controls.RunThisQueryEveryComboBox.WaitForResponse();
                Utilities.LogMessage("RunThisQueryEveryComboBox Selected Index = " + watcherPropertiesDialog.Controls.RunThisQueryEveryComboBox.SelectedIndex);

                // TODO : make this work -- for some reason it throws System.ArgumentException
                /*if (String.Compare(watcherPropertiesDialog.RunThisQueryEveryText, parameters.QueryIntervalTime) != 0)
                {
                    throw new Maui.Core.WinControls.ComboBox.Exceptions.TextNotFoundException(watcherPropertiesDialog.RunThisQueryEveryText + " does not match query text " + parameters.QueryIntervalTime);
                }*/
            }

            // Based on the query inteveral unit parameter; verify the time units 
            string queryUnits = null;
            switch (parameters.QueryIntervalUnit)
            {
                case Templates.WatcherNodeQueryIntervalUnit.Seconds:
                    queryUnits = MonitoringConfiguration.Strings.RunThisQueryEverySeconds;
                    break;

                case Templates.WatcherNodeQueryIntervalUnit.Minutes:
                    queryUnits = MonitoringConfiguration.Strings.RunThisQueryEveryMinutes;
                    break;

                case Templates.WatcherNodeQueryIntervalUnit.Hours:
                    queryUnits = MonitoringConfiguration.Strings.RunThisQueryEveryHours;
                    break;

                case Templates.WatcherNodeQueryIntervalUnit.Days:
                    queryUnits = MonitoringConfiguration.Strings.RunThisQueryEveryDays;
                    break;

                default:
                    Utilities.LogMessage("VerifyComponentParameters:: QueryIntervalUnit parameter: '" +
                        parameters.QueryIntervalUnit + "' is invalid");
                    throw new InvalidEnumArgumentException("Invalid Type selected");
            }

            if (String.Compare(watcherPropertiesDialog.ComboBox0Text, queryUnits) != 0)
            {
                throw new Maui.Core.WinControls.ComboBox.Exceptions.TextNotFoundException(watcherPropertiesDialog.ComboBox0Text + " does not match query units " + queryUnits);
            }

            // verify SynTx specific settings configuration tab
            watcherPropertiesDialog.Controls.Tab2TabControl.Tabs[1].Click();

            switch (type)
            {
                case ComponentType.TcpPort:
                    Port.Dialogs.TargetAndPortPropertiesDialog portDialog = new Port.Dialogs.TargetAndPortPropertiesDialog(CoreManager.MomConsole);
                    Port.Port myPort = new Port.Port();
                    myPort.VerifyPortProperties((Port.Port.PortParameters)parameters, portDialog);
                    break;
                case ComponentType.OleDbDataSource:

                    break;
                case ComponentType.WebApplication:

                    break;
                default:
                    throw new InvalidEnumArgumentException("Enum not valid: '" + type + "'");
            }
        }
        

        /// <summary>
        /// Edit Synthetic Transaction component properties
        /// </summary>
        /// <param name="parameters">SynTxParameters</param>
        /// <param name="componentName">String</param>
        /// <param name="type">ComponentType</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [faizalk] 22MAY2007 - Created   
        /// </history>
        public void EditComponentProperties(SynTxParameters parameters, String componentName, ComponentType type)
        {
            Utilities.LogMessage("SynTx.EditComponentProperties");

            Templates templates = new Templates();

            // ComponentExists method handles the navigation
            if (!templates.ComponentExists(type, componentName))
            {
                throw new Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException("could not find SynTx component to edit: '" + componentName + "'");
            }

            Maui.Core.WinControls.DataGridViewRow monitoredComponentRow = CoreManager.MomConsole.ViewPane.Grid.FindData(componentName, Core.Console.MomControls.GridControl.SearchStringMatchType.ExactMatch);
            monitoredComponentRow.AccessibleObject.Click();
            Maui.Core.WinControls.Menu propertiesMenuItem = new Maui.Core.WinControls.Menu(ContextMenuAccessMethod.ShiftF10);
            //propertiesMenuItem.WaitContextMenuWithTimeOut(Constants.DefaultContextMenuTimeout);
            propertiesMenuItem.ScreenElement.WaitForReady();
            Utilities.LogMessage("Templates.EditComponentProperties :: Selecting '" + Views.Views.Strings.PropertiesContextMenu + "' menu item");
            propertiesMenuItem.ExecuteMenuItem(Views.Views.Strings.PropertiesContextMenu);

            Core.Console.MonitoringConfiguration.Dialogs.TemplateGeneralPropertiesDialog generalPropertiesDialog = new TemplateGeneralPropertiesDialog(CoreManager.MomConsole);

            // make sure controls are enabled correctly
            generalPropertiesDialog.Controls.Tab0TabControl.Tabs[0].Click();
            if (generalPropertiesDialog.Controls.SelectDestinationManagementPackComboBox.IsEnabled)
            {
                throw new Maui.Core.WinControls.ComboBox.Exceptions.ControlIsDisabledException("MP Destination combo box should be disabled but is not");
            }
            if (!generalPropertiesDialog.Controls.TargetAndPortTextBox.IsEnabled)
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Name textbox is disabled!");
            }
            if (!generalPropertiesDialog.Controls.SummaryTextBox.IsEnabled)
            {
                throw new Maui.Core.WinControls.TextBox.Exceptions.ControlIsDisabledException("Description textbox is disabled!");
            }

            // edit settings as necessary on General tab
            if (String.Compare(generalPropertiesDialog.TargetAndPortText, parameters.Name) != 0)
            {
                Utilities.LogMessage("Templates.EditComponentProperties :: editing " + generalPropertiesDialog.TargetAndPortText + " to " + parameters.Name);
                generalPropertiesDialog.TargetAndPortText = parameters.Name;
            }
            if (String.Compare(generalPropertiesDialog.SummaryText, parameters.Description) != 0)
            {
                Utilities.LogMessage("Templates.EditComponentProperties :: editing " + generalPropertiesDialog.SummaryText + " to " + parameters.Description);
                generalPropertiesDialog.SummaryText = parameters.Description;
            }
            if (String.Compare(generalPropertiesDialog.SelectDestinationManagementPackText, parameters.DestinationMP) != 0)
            {
                Utilities.LogMessage("Templates.EditComponentProperties :: editing " + generalPropertiesDialog.Controls.SelectDestinationManagementPackComboBox.Text + " to " + parameters.DestinationMP);
                generalPropertiesDialog.Controls.SelectDestinationManagementPackComboBox.SelectByText(parameters.DestinationMP);
            }

            // edit settings as necessary on Watcher Node tab
            generalPropertiesDialog.Controls.Tab0TabControl.Tabs[2].Click();
            Core.Console.MonitoringConfiguration.Dialogs.WatcherNodePropertiesDialog watcherPropertiesDialog = new WatcherNodePropertiesDialog(CoreManager.MomConsole);

            // make sure controls are enabled correctly
            if (!watcherPropertiesDialog.Controls.PortListView.IsEnabled)
            {
                throw new Maui.Core.WinControls.ListView.Exceptions.ControlIsDisabledException("Watcher node list view is disabled");
            }
            if (!watcherPropertiesDialog.Controls.RunThisQueryEveryComboBox.IsEnabled)
            {
                throw new Maui.Core.WinControls.ComboBox.Exceptions.ControlIsDisabledException("Run this query time unit combo box is disabled");
            }
            if (!watcherPropertiesDialog.Controls.ComboBox0.IsEnabled)
            {
                throw new Maui.Core.WinControls.ComboBox.Exceptions.ControlIsDisabledException("Run this query number spinner is disabled");
            }

            // verify properties match parameters
            if (null != parameters.WatcherNodes)
            {
                Utilities.LogMessage("Templates.EditComponentProperties :: selecting appropriate Watcher Nodes");

                // find each watcher node in the listview (case insensitive)
                foreach (ListViewItem lvi in watcherPropertiesDialog.Controls.PortListView.Items)
                {
                    if (lvi.Checked)
                    {
                        Utilities.LogMessage("I found:" + lvi.Text.ToLowerInvariant());
                        Utilities.LogMessage("I found node:" + parameters.WatcherNodes[0]);
                        if (Array.IndexOf(parameters.WatcherNodes, lvi.Text.ToLowerInvariant()) < 0)
                        {
                            lvi[0].Select();
                            Utilities.LogMessage("Removing '" + lvi[0].Text + "' from selection");
                            int retries = 0;
                            int maxRetry = 10;
                            while (lvi.Checked && retries < maxRetry)
                            {
                                lvi[0].Click(MouseClickType.DoubleClick);
                                retries++;
                            }
                        }
                    }
                    else // not checked so verify not in parameters
                    {
                        if (Array.IndexOf(parameters.WatcherNodes, lvi.Text.ToLowerInvariant()) > 0)
                        {
                            lvi[0].Select();
                            Utilities.LogMessage("Adding '" + lvi[0].Text + "' to selection");
                            int retries = 0;
                            int maxRetry = 10;
                            while (!lvi.Checked && retries < maxRetry)
                            {
                                lvi[0].Click(MouseClickType.DoubleClick);
                                retries++;
                            }
                        }
                    }
                }
            }
            else // all watcher nodes should be selected
            {
                Utilities.LogMessage("Templates.EditComponentProperties :: selecting ALL watcher nodes");
                foreach (ListViewItem lvi in watcherPropertiesDialog.Controls.PortListView.Items)
                {
                    if (!lvi.Checked)
                    {
                        lvi[0].Select();
                        Utilities.LogMessage("Adding '" + lvi[0].Text + "' to selection");
                        int retries = 0;
                        int maxRetry = 10;
                        while (!lvi.Checked && retries < maxRetry)
                        {
                            lvi[0].Click(MouseClickType.DoubleClick);
                            retries++;
                        }
                    }
                }
            }

            if (null != parameters.QueryIntervalTime)
            {
                watcherPropertiesDialog.Controls.RunThisQueryEveryComboBox.Click();
                watcherPropertiesDialog.Controls.RunThisQueryEveryComboBox.WaitForResponse();
                Utilities.LogMessage("RunThisQueryEveryComboBox Selected Index = " + watcherPropertiesDialog.Controls.RunThisQueryEveryComboBox.SelectedIndex);

                // TODO : make this work -- for some reason it throws System.ArgumentException
                /*if (String.Compare(watcherPropertiesDialog.RunThisQueryEveryText, parameters.QueryIntervalTime) != 0)
                {
                    throw new Maui.Core.WinControls.ComboBox.Exceptions.TextNotFoundException(watcherPropertiesDialog.RunThisQueryEveryText + " does not match query text " + parameters.QueryIntervalTime);
                }*/
            }

            // Based on the query inteveral unit parameter; verify the time units 
            string queryUnits = null;
            switch (parameters.QueryIntervalUnit)
            {
                case Templates.WatcherNodeQueryIntervalUnit.Seconds:
                    queryUnits = MonitoringConfiguration.Strings.RunThisQueryEverySeconds;
                    break;

                case Templates.WatcherNodeQueryIntervalUnit.Minutes:
                    queryUnits = MonitoringConfiguration.Strings.RunThisQueryEveryMinutes;
                    break;

                case Templates.WatcherNodeQueryIntervalUnit.Hours:
                    queryUnits = MonitoringConfiguration.Strings.RunThisQueryEveryHours;
                    break;

                case Templates.WatcherNodeQueryIntervalUnit.Days:
                    queryUnits = MonitoringConfiguration.Strings.RunThisQueryEveryDays;
                    break;

                default:
                    Utilities.LogMessage("VerifyComponentParameters:: QueryIntervalUnit parameter: '" +
                        parameters.QueryIntervalUnit + "' is invalid");
                    throw new InvalidEnumArgumentException("Invalid Type selected");
            }

            if (String.Compare(watcherPropertiesDialog.ComboBox0Text, queryUnits) != 0)
            {
                watcherPropertiesDialog.Controls.ComboBox0.SelectByText(queryUnits);
            }

            // verify SynTx specific settings configuration tab
            watcherPropertiesDialog.Controls.Tab2TabControl.Tabs[1].Click();

            switch (type)
            {
                case ComponentType.TcpPort:
                    Port.Dialogs.TargetAndPortPropertiesDialog portDialog = new Port.Dialogs.TargetAndPortPropertiesDialog(CoreManager.MomConsole);
                    Port.Port myPort = new Port.Port();
                    myPort.EditPortProperties((Port.Port.PortParameters)parameters, portDialog);
                    break;
                case ComponentType.OleDbDataSource:

                    break;
                case ComponentType.WebApplication:

                    break;
                case ComponentType.ProcessMonitor:
                    break;
                default:
                    throw new InvalidEnumArgumentException("Enum not valid: '" + type + "'");
            }
        }

        /// <summary>
        /// Verify component properties
        /// </summary>
        /// <param name="parameters">WindowsServiceParameters</param>
        /// <param name="type">ComponentType</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [v-brucec] 16NOV2009 - Created   
        /// </history>
        public void VerifyComponentProperties(WindowsService.WindowsService.WindowsServiceParameters parameters, ComponentType type)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + " :: start");
            Templates templates = new Templates();

            // ComponentExists method handles the navigation
            if (!templates.ComponentExists(type, parameters.name))
            {
                throw new ListView.Exceptions.ItemNotFoundException(currentMethod + " :: Could not find Windows service component to edit: '" + parameters.name + "'");
            }

            DataGridViewRow monitoredComponentRow = CoreManager.MomConsole.ViewPane.Grid.FindData(parameters.name, Core.Console.MomControls.GridControl.SearchStringMatchType.ExactMatch);
            monitoredComponentRow.AccessibleObject.Click();
            Menu propertiesMenuItem = new Menu(ContextMenuAccessMethod.ShiftF10);
            //propertiesMenuItem.WaitContextMenuWithTimeOut(Constants.DefaultContextMenuTimeout);
            propertiesMenuItem.ScreenElement.WaitForReady();
            Utilities.LogMessage(currentMethod + " :: Selecting '" + Views.Views.Strings.PropertiesContextMenu + "' menu item");
            propertiesMenuItem.ExecuteMenuItem(Views.Views.Strings.PropertiesContextMenu);

            Core.Console.MonitoringConfiguration.Dialogs.TemplateGeneralPropertiesDialog generalPropertiesDialog = new TemplateGeneralPropertiesDialog(CoreManager.MomConsole);

            // make sure controls are enabled correctly
            int generalTabGeneralIndex = this.GetTabIndexByText(generalPropertiesDialog.Controls.Tab0TabControl.Tabs, WindowsService.WindowsService.Strings.GeneralTabName);
            if (generalPropertiesDialog.Controls.Tab0TabControl.Tabs.Count > 0 && generalPropertiesDialog.Controls.Tab0TabControl.Tabs[generalTabGeneralIndex] != null)
            {
                generalPropertiesDialog.Controls.Tab0TabControl.Tabs[generalTabGeneralIndex].Click();
            }
            else
            {
                throw new Maui.Core.WinControls.TabControl.Exceptions.TabNotFoundException(
                    "Could not find specified tab control. Tabs.Count=" + generalPropertiesDialog.Controls.Tab0TabControl.Tabs.Count);
            }

            if (generalPropertiesDialog.Controls.SelectDestinationManagementPackComboBox.IsEnabled)
            {
                throw new ComboBox.Exceptions.ControlIsDisabledException("MP Destination combo box should be disabled but is not");
            }
            if (!generalPropertiesDialog.Controls.TargetAndPortTextBox.IsEnabled)
            {
                throw new TextBox.Exceptions.ControlIsDisabledException("Name textbox is disabled!");
            }
            if (!generalPropertiesDialog.Controls.SummaryTextBox.IsEnabled)
            {
                throw new TextBox.Exceptions.ControlIsDisabledException("Description textbox is disabled!");
            }

            // verify settings match parameters on General tab
            if (String.Compare(generalPropertiesDialog.TargetAndPortText, parameters.name, true) != 0)
            {
                throw new TextBox.Exceptions.FailedToSetValueException("text '" + generalPropertiesDialog.TargetAndPortText + "' does not match '" + parameters.name + "'");
            }
            if (String.Compare(generalPropertiesDialog.SummaryText, parameters.description) != 0)
            {
                throw new TextBox.Exceptions.FailedToSetValueException("text '" + generalPropertiesDialog.SummaryText + "' does not match '" + parameters.description + "'");
            }
            if (String.Compare(generalPropertiesDialog.SelectDestinationManagementPackText, parameters.managementPack) != 0)
            {
                throw new TextBox.Exceptions.FailedToSetValueException("text '" + generalPropertiesDialog.SelectDestinationManagementPackText + "' does not match '" + parameters.managementPack + "'");
            }

            // verify settings match parameters on Performance Data Tab

            int generalTabPerformanceDataIndex = this.GetTabIndexByText(generalPropertiesDialog.Controls.Tab0TabControl.Tabs, WindowsService.WindowsService.Strings.PerformanceDataTabName);
            if (generalPropertiesDialog.Controls.Tab0TabControl.Tabs.Count > 0 && generalPropertiesDialog.Controls.Tab0TabControl.Tabs[generalTabPerformanceDataIndex] != null)
            {
                generalPropertiesDialog.Controls.Tab0TabControl.Tabs[generalTabPerformanceDataIndex].Click();
            }
            else
            {
                throw new Maui.Core.WinControls.TabControl.Exceptions.TabNotFoundException(
                    "Could not find specified tab control. Tabs.Count=" + generalPropertiesDialog.Controls.Tab0TabControl.Tabs.Count);
            }

            PerformanceDataPageDialog performanceDataPage = new PerformanceDataPageDialog(CoreManager.MomConsole);
 
            /* Comment this out for bug #168742
             * 
            if (!performanceDataPage.Controls.ProcessorTimeThresholdCheckBox.IsEnabled)
            {
                throw new CheckBox.Exceptions.ControlIsDisabledException("ProcessorTimeThresholdCheckBox is disabled");
            }

            if (!performanceDataPage.Controls.PrivateBytesThresholdCheckBox.IsEnabled)
            {
                throw new CheckBox.Exceptions.ControlIsDisabledException("PrivateBytesThresholdCheckBox is disabled");
            }

            if (performanceDataPage.ProcessorTimeThreshold != parameters.processorTimeAlert)
            {
                throw new CheckBox.Exceptions.FailedToSetValueException("text '" + performanceDataPage.ProcessorTimeThreshold + "' does not match '" + parameters.processorTimeAlert + "'");
            }

            if (String.Compare(performanceDataPage.PercentProcTimeText, parameters.percentProcessorTimeThreshold) != 0)
            {
                throw new CheckBox.Exceptions.FailedToSetValueException("text '" + performanceDataPage.PercentProcTimeText + "' does not match '" + parameters.percentProcessorTimeThreshold + "'");
            }

            if (performanceDataPage.PrivateBytesThreshold != parameters.bytesAlert)
            {
                throw new CheckBox.Exceptions.FailedToSetValueException("text '" + performanceDataPage.PrivateBytesThreshold + "' does not match '" + parameters.bytesAlert + "'");
            }

            if (String.Compare(performanceDataPage.NumBytesText, parameters.numBytesThreshold) != 0)
            {
                throw new CheckBox.Exceptions.FailedToSetValueException("text '" + performanceDataPage.NumBytesText + "' does not match '" + parameters.numBytesThreshold + "'");
            }

            if (String.Compare(performanceDataPage.NumSamplesText, parameters.numSamples) != 0)
            {
                throw new CheckBox.Exceptions.FailedToSetValueException("text '" + performanceDataPage.NumSamplesText + "' does not match '" + parameters.numSamples + "'");
            }

            if (String.Compare(performanceDataPage.IntervalThresholdText, parameters.counterThresholdInterval) != 0)
            {
                throw new CheckBox.Exceptions.FailedToSetValueException("text '" + performanceDataPage.IntervalThresholdText + "' does not match '" + parameters.counterThresholdInterval + "'");
            }
            */

            // verify service details configuration tab
            int performanceDataTabServiceDetailIndex = this.GetTabIndexByText(performanceDataPage.Controls.TabControlCollection.Tabs, WindowsService.WindowsService.Strings.ServiceDetailsTabName);
            if (performanceDataPage.Controls.TabControlCollection.Tabs.Count > 0 && performanceDataPage.Controls.TabControlCollection.Tabs[performanceDataTabServiceDetailIndex] != null)
            {
                performanceDataPage.Controls.TabControlCollection.Tabs[performanceDataTabServiceDetailIndex].Click();
            }
            else
            {
                throw new Maui.Core.WinControls.TabControl.Exceptions.TabNotFoundException(
                    "Could not find specified tab control. Tabs.Count=" + performanceDataPage.Controls.TabControlCollection.Tabs.Count);
            }

            ServiceDetailPageDialog serviceDetailPageDialog = new ServiceDetailPageDialog(CoreManager.MomConsole);

            if (!serviceDetailPageDialog.Controls.ServiceNameTextBox.IsEnabled)
            {
                throw new TextBox.Exceptions.ControlIsDisabledException("ServiceNameTextBox is disabled");
            }

            if (!serviceDetailPageDialog.Controls.ServiceSearchButton.IsEnabled)
            {
                throw new TextBox.Exceptions.ControlIsDisabledException("ServiceSearchButton is disabled");
            }

            if (!serviceDetailPageDialog.Controls.GroupSearchButton.IsEnabled)
            {
                throw new ComboBox.Exceptions.ControlIsDisabledException("GroupSearchButton is disabled");
            }

            if (!serviceDetailPageDialog.Controls.AutomaticServiceCheckBox.IsEnabled)
            {
                throw new CheckBox.Exceptions.ControlIsDisabledException("AutomaticServiceCheckBox is disabled");
            }

            if (serviceDetailPageDialog.AutomaticService != parameters.automaticService)
            {
                throw new CheckBox.Exceptions.FailedToSetValueException("text '" + serviceDetailPageDialog.AutomaticService + "' does not match '" + parameters.automaticService + "'");
            }

            if (String.Compare(serviceDetailPageDialog.ServiceNameText, parameters.serviceName) != 0)
            {
                throw new CheckBox.Exceptions.FailedToSetValueException("text '" + serviceDetailPageDialog.ServiceNameText + "' does not match '" + parameters.serviceName + "'");
            }

            if (String.Compare(serviceDetailPageDialog.GroupNameText, parameters.groupName) != 0)
            {
                throw new CheckBox.Exceptions.FailedToSetValueException("text '" + serviceDetailPageDialog.GroupNameText + "' does not match '" + parameters.groupName + "'");
            }

            serviceDetailPageDialog.ClickCancel();
            CoreManager.MomConsole.Waiters.WaitForStatusReady();
        }

        /// <summary>
        /// Edit component properties
        /// </summary>
        /// <param name="parameters">WindowsServiceParameters</param>
        /// <param name="componentName">String</param>
        /// <param name="type">ComponentType</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [v-brucec] 16NOV2009 - Created   
        /// </history>
        public void EditComponentProperties(WindowsService.WindowsService.WindowsServiceParameters parameters, String componentName, ComponentType type)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + " :: start");

            Templates templates = new Templates();

            // ComponentExists method handles the navigation
            if (!templates.ComponentExists(type, componentName))
            {
                throw new ListView.Exceptions.ItemNotFoundException("could not find Windows service component to edit: '" + componentName + "'");
            }

            DataGridViewRow monitoredComponentRow = CoreManager.MomConsole.ViewPane.Grid.FindData(componentName, Core.Console.MomControls.GridControl.SearchStringMatchType.ExactMatch);
            monitoredComponentRow.AccessibleObject.Click();
            Menu propertiesMenuItem = new Menu(ContextMenuAccessMethod.ShiftF10);
            //propertiesMenuItem.WaitContextMenuWithTimeOut(Constants.DefaultContextMenuTimeout);
            propertiesMenuItem.ScreenElement.WaitForReady();
            Utilities.LogMessage(currentMethod + " :: Selecting '" + Views.Views.Strings.PropertiesContextMenu + "' menu item");
            propertiesMenuItem.ExecuteMenuItem(Views.Views.Strings.PropertiesContextMenu);

            Core.Console.MonitoringConfiguration.Dialogs.TemplateGeneralPropertiesDialog generalPropertiesDialog = new TemplateGeneralPropertiesDialog(CoreManager.MomConsole);

            // make sure controls are enabled correctly
            int generalTabGeneralIndex = this.GetTabIndexByText(generalPropertiesDialog.Controls.Tab0TabControl.Tabs, WindowsService.WindowsService.Strings.GeneralTabName);
            if (generalPropertiesDialog.Controls.Tab0TabControl.Tabs.Count > 0 && generalPropertiesDialog.Controls.Tab0TabControl.Tabs[generalTabGeneralIndex] != null)
            {
                generalPropertiesDialog.Controls.Tab0TabControl.Tabs[generalTabGeneralIndex].Click();
            }
            else
            {
                throw new Maui.Core.WinControls.TabControl.Exceptions.TabNotFoundException(
                    "Could not find specified tab control. Tabs.Count=" + generalPropertiesDialog.Controls.Tab0TabControl.Tabs.Count);
            }

            if (generalPropertiesDialog.Controls.SelectDestinationManagementPackComboBox.IsEnabled)
            {
                throw new ComboBox.Exceptions.ControlIsDisabledException("MP Destination combo box should be disabled but is not");
            }
            if (!generalPropertiesDialog.Controls.TargetAndPortTextBox.IsEnabled)
            {
                throw new TextBox.Exceptions.ControlIsDisabledException("Name textbox is disabled!");
            }
            if (!generalPropertiesDialog.Controls.SummaryTextBox.IsEnabled)
            {
                throw new TextBox.Exceptions.ControlIsDisabledException("Description textbox is disabled!");
            }

            // edit settings as necessary on General tab
            if (String.Compare(generalPropertiesDialog.TargetAndPortText, parameters.name) != 0)
            {
                Utilities.LogMessage(currentMethod + " :: editing " + generalPropertiesDialog.TargetAndPortText + " to " + parameters.name);
                generalPropertiesDialog.TargetAndPortText = parameters.name;
            }
            if (String.Compare(generalPropertiesDialog.SummaryText, parameters.description) != 0)
            {
                Utilities.LogMessage(currentMethod + " :: editing " + generalPropertiesDialog.SummaryText + " to " + parameters.description);
                generalPropertiesDialog.SummaryText = parameters.description;
            }
            if (String.Compare(generalPropertiesDialog.SelectDestinationManagementPackText, parameters.managementPack) != 0)
            {
                Utilities.LogMessage(currentMethod + " :: editing " + generalPropertiesDialog.Controls.SelectDestinationManagementPackComboBox.Text + " to " + parameters.managementPack);
                generalPropertiesDialog.Controls.SelectDestinationManagementPackComboBox.SelectByText(parameters.managementPack);
            }

            // edit settings as necessary on Performance Data tab
            int generalTabPerformanceDataIndex = this.GetTabIndexByText(generalPropertiesDialog.Controls.Tab0TabControl.Tabs, WindowsService.WindowsService.Strings.PerformanceDataTabName);
            if (generalPropertiesDialog.Controls.Tab0TabControl.Tabs.Count > 0 && generalPropertiesDialog.Controls.Tab0TabControl.Tabs[generalTabPerformanceDataIndex] != null)
            {
                generalPropertiesDialog.Controls.Tab0TabControl.Tabs[generalTabPerformanceDataIndex].Click();
            }
            else
            {
                throw new Maui.Core.WinControls.TabControl.Exceptions.TabNotFoundException(
                    "Could not find specified tab control. Tabs.Count=" + generalPropertiesDialog.Controls.Tab0TabControl.Tabs.Count);
            }

            PerformanceDataPageDialog performanceDataPage = new PerformanceDataPageDialog(CoreManager.MomConsole);
            performanceDataPage.WaitForResponse();

            /* Comment this out for bug #168742
             * 
            if (!performanceDataPage.Controls.ProcessorTimeThresholdCheckBox.IsEnabled)
            {
                throw new ListView.Exceptions.ControlIsDisabledException("ProcessorTimeThresholdCheckBox is disabled");
            }

            if (!performanceDataPage.Controls.PrivateBytesThresholdCheckBox.IsEnabled)
            {
                throw new ListView.Exceptions.ControlIsDisabledException("PrivateBytesThresholdCheckBox is disabled");
            }

            Utilities.LogMessage(currentMethod + " :: editing " + performanceDataPage.ProcessorTimeThreshold + " to " + parameters.processorTimeAlert);
            performanceDataPage.ProcessorTimeThreshold = parameters.processorTimeAlert;

            if (null != parameters.percentProcessorTimeThreshold)
            {
                Utilities.LogMessage(currentMethod + " :: editing " + performanceDataPage.PercentProcTimeText + " to " + parameters.percentProcessorTimeThreshold);
                performanceDataPage.PercentProcTimeText = parameters.percentProcessorTimeThreshold;
            }

            Utilities.LogMessage(currentMethod + " :: editing " + performanceDataPage.PrivateBytesThreshold + " to " + parameters.bytesAlert);
            performanceDataPage.PrivateBytesThreshold = parameters.bytesAlert;

            if (null != parameters.numBytesThreshold)
            {
                Utilities.LogMessage(currentMethod + " :: editing " + performanceDataPage.NumBytesText + " to " + parameters.numBytesThreshold);
                performanceDataPage.NumBytesText = parameters.numBytesThreshold;
            }

            if (null != parameters.numSamples)
            {
                Utilities.LogMessage(currentMethod + " :: editing " + performanceDataPage.NumSamplesText + " to " + parameters.numSamples);
                performanceDataPage.NumSamplesText = parameters.numSamples;
            }

            if (null != parameters.counterThresholdInterval)
            {
                Utilities.LogMessage(currentMethod + " :: editing " + performanceDataPage.IntervalThresholdText + " to " + parameters.counterThresholdInterval);
                performanceDataPage.IntervalThresholdText = parameters.counterThresholdInterval;
            }
            */

            // edit settings as necessary on Service Detail tab
            int performanceDataTabServiceDetailIndex = this.GetTabIndexByText(performanceDataPage.Controls.TabControlCollection.Tabs, WindowsService.WindowsService.Strings.ServiceDetailsTabName);
            if (performanceDataPage.Controls.TabControlCollection.Tabs.Count > 0 && performanceDataPage.Controls.TabControlCollection.Tabs[performanceDataTabServiceDetailIndex] != null)
            {
                performanceDataPage.Controls.TabControlCollection.Tabs[performanceDataTabServiceDetailIndex].Click();
            }
            else
            {
                throw new Maui.Core.WinControls.TabControl.Exceptions.TabNotFoundException(
                    "Could not find specified tab control. Tabs.Count=" + performanceDataPage.Controls.TabControlCollection.Tabs.Count);
            }

            ServiceDetailPageDialog serviceDetailPageDialog = new ServiceDetailPageDialog(CoreManager.MomConsole);
            serviceDetailPageDialog.WaitForResponse();

            #region Group Search Dialog Box

            ListViewItemCollection groupToSelect;

            if (parameters.groupName == null)
            {
                throw new ArgumentNullException(currentMethod + " :: Group name cannot be null");
            }

            serviceDetailPageDialog.ClickGroupSearch();
            Utilities.LogMessage(currentMethod + " :: Clicked Group Search button");
            GroupSearchDialog groupSearchDialog = new GroupSearchDialog(CoreManager.MomConsole);

            if (parameters.filters != null)
                groupSearchDialog.TextFilterText = parameters.filters;

            if (parameters.MPFilter != null)
                groupSearchDialog.MPFilterText = parameters.MPFilter;

            groupSearchDialog.ClickSearch();

            int retries = 0;
            int maxRetries = 20;

            while (groupSearchDialog.Controls.GroupsListView.Count == 0 && retries < maxRetries)
            {
                retries++;
                Utilities.LogMessage(currentMethod + " :: Waiting for Group List to populate.");
                Utilities.LogMessage(currentMethod + " :: Attempt " + retries + " of " + maxRetries);
                Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond * 3);
            }

            retries = 0;
            maxRetries = 5;
            bool foundGroup = false;
            groupSearchDialog.Controls.GroupsListView.WaitForResponse();
            while (retries < maxRetries && foundGroup == false)
            {
                groupToSelect = groupSearchDialog.Controls.GroupsListView.FindAllByText(parameters.groupName);
                if (groupToSelect.Count > 0)
                {
                    groupToSelect[0].Click();
                    foundGroup = true;
                }
                retries++;
                Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond * 3);
            }
            if (foundGroup == false)
            {
                Utilities.LogMessage(currentMethod + " :: Failed to find " + parameters.groupName + " in the groups list.");
                throw new Exception(currentMethod + " :: Failed to find " + parameters.groupName + " in the groups list.");
            }

            groupSearchDialog.ClickOK();
            Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);

            #endregion

            #region Automatic Service CheckBox

            if (parameters.automaticService)
            {
                Utilities.LogMessage(currentMethod + " :: Automatic Service Selected");
                if (serviceDetailPageDialog.Controls.AutomaticServiceCheckBox.ButtonState != ButtonState.Checked)
                {
                    serviceDetailPageDialog.Controls.AutomaticServiceCheckBox.Click();
                    Utilities.LogMessage(currentMethod + " :: Automatic Service check box clicked.");
                }
                Utilities.LogMessage(currentMethod + " :: Automatic Service check box checked");
            }

            #endregion

            #region Service Search Dialog Box

            if (parameters.browseService)
            {
                Utilities.LogMessage(currentMethod + " :: Clicking Service Search");
                serviceDetailPageDialog.ClickServiceSearch();
                Utilities.LogMessage(currentMethod + " :: Clicked Windows Service search button");

                SelectWindowsServiceDialog selectWindowsServiceDialog = new SelectWindowsServiceDialog();
                Utilities.LogMessage(currentMethod + " :: Setting Focus on the Select Windows Service Dialog was successful");

                bool serviceSelected = false;
                serviceSelected = CoreManager.MomConsole.SelectListViewItems(parameters.serviceName, actualServiceNameColPos, selectWindowsServiceDialog.Controls.ServiceNameListView, true);

                if (serviceSelected == true)
                {
                    selectWindowsServiceDialog.ScreenElement.WaitForReady();
                    selectWindowsServiceDialog.ClickOK();
                }
                else
                {
                    throw new ListView.Exceptions.ItemNotFoundException("Failed to select the windows service in browse window");
                }
            }
            else
            {
                serviceDetailPageDialog.ServiceNameText = parameters.serviceName;
            }
            #endregion

            serviceDetailPageDialog.ClickOK();
            CoreManager.MomConsole.Waiters.WaitForStatusReady();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Return index by tab text
        /// </summary>
        /// <param name="tabs">Tab collection</param>
        /// <param name="targetText">tab text to find</param>
        /// <returns>tab index</returns>
        /// <history>
        ///     [v-brucec] 01FEB10 - Created        
        /// </history>
        private int GetTabIndexByText(TabControlTabCollection tabs, string targetText)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + " :: start");

            int tabIndex = -1;

            if (tabs == null || tabs.Count == 0)
            {
                throw new System.ArgumentNullException(currentMethod + " :: Tab collection is empty.");
            }

            if (string.IsNullOrEmpty(targetText))
            {
                throw new System.ArgumentNullException(currentMethod + " :: Tab text is null or empty.");
            }

            for (int i = 0; i < tabs.Count; i++)
            {
                string tabText = tabs[i].Text.Trim();
                Utilities.LogMessage(currentMethod + " :: Found tab text '" + tabText + "' at index #" + i + ", expecting '" + targetText + "'");
                if (string.Compare(targetText.Trim(), tabText) == 0)
                {
                    tabIndex = i;
                    break;
                }
            }

            Utilities.LogMessage(currentMethod + " :: Tab index is:" + tabIndex);
            Utilities.LogMessage(currentMethod + " :: end");
            return tabIndex;
        }

        #endregion

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for Monitors
        /// </summary>
        /// <history> 	
        ///   [ruhim]  18Jan06: Added resource strings for Dialog Title
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the "Create a Component" wizard dialog title.
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = 
                ";Create Component Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;TemplateWizard";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the component wizard link from overview page
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceLaunchComponentWizardFromOverview =
                ";Use a template to create a new monitored component;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.OverviewView;templateLink.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the component wizard task from Actions pane
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceLaunchComponentWizardTask = ";A&dd Monitoring Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.MonitorCompView.MonitorCompResources;CreateNewComponentTask";

                //Old Resource ";Create a new component;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.MonitorCompView.MonitorCompResources;CreateNewComponentTask";
                        
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Component category Column Name in Monitored Components view
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceComponentCategoryColumnName =
                ";Component Category;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.MonitorCompView.MonitorCompResources;NameColumn";

             /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Context Menu - View management pack objects...
            /// </summary>           
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuViewMPObjects = 
                ";View &management pack objects...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;ShowMPObjectContextMenu";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// TimeoutDialogTitle
            /// </summary>
            /// -----------------------------------------------------------------------------            
            public static string ResourceTimeoutDialogTitle = ";Task Results;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.TCPPortCheckTemplate.TCPPortCheckTemplateResource;TaskTimeOutCaption";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// PropertiesDialogTitle
            /// </summary>
            /// -----------------------------------------------------------------------------            
            public static string ResourcePropertiesDialogTitle = ";{0} Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;MPObjectFormatString";


            /// <summary>
            /// DeleteMonitoringDialogTitle
            /// Contains resource string for the Confirmation dialog title of Delete the "object being monitored"/Template.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfirmDeleteMonitoringTitle =
                @";Delete Monitoring;" +
                "ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.MonitorCompView.MonitorCompResources;" +
                "ConfirmDeleteCaption";

            private const string ResourceEditWebApplicationTitle =
                ";Edit web application settings;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;EditWebAppAction";


            

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
            /// Caches the translated resource the component wizard link from overview page
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLaunchComponentWizardFromOverview;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the component wizard task from Actions pane
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLaunchComponentWizardTask;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the component wizard task from Actions pane
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLaunchComponentWizardTaskToolbarButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Component category Column Name 
            /// in Monitored Components view
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComponentCategoryColumnName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Context Menu - View management pack objects...
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuViewMPObjects;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Task Results"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTimeoutDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "{0} Properties"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPropertiesDialogTitle;


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Delete Monitoring"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDeleteMonitoringDialogTitle;

            private static string cachedEditWebApplicationTitle;

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
            /// Exposes access to the component wizard link from overview page
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LaunchComponentWizardFromOverview
            {
                get
                {
                    if ((cachedLaunchComponentWizardFromOverview == null))
                    {
                        cachedLaunchComponentWizardFromOverview = CoreManager.MomConsole.GetIntlStr(ResourceLaunchComponentWizardFromOverview);
                    }
                    return cachedLaunchComponentWizardFromOverview;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the component wizard task from Actions pane
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 3/3/2006 Created
            /// 	[a-joelj] 07AUG08 Added code to remove ampersand when clicking Actions Pane option
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LaunchComponentWizardTask
            {
                get
                {
                    if ((cachedLaunchComponentWizardTask == null))
                    {
                        cachedLaunchComponentWizardTask = CoreManager.MomConsole.GetIntlStr(ResourceLaunchComponentWizardTask);

                        //Remove Ampersand from this string for Actions Pane
                        string removeAmp = String.Copy(cachedLaunchComponentWizardTask);
                        cachedLaunchComponentWizardTask = removeAmp.Replace("&", "");
                    }
                    return cachedLaunchComponentWizardTask;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the component wizard task from Toolbar menu without removing ampersand
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 07AUG08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LaunchComponentWizardTaskToolbarButton
            {
                get
                {
                    if ((cachedLaunchComponentWizardTaskToolbarButton == null))
                    {
                        cachedLaunchComponentWizardTaskToolbarButton = CoreManager.MomConsole.GetIntlStr(ResourceLaunchComponentWizardTask);
                    }
                    return cachedLaunchComponentWizardTaskToolbarButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Component category Column Name in 
            /// Monitored Components view translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 14/4/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ComponentCategoryColumnName
            {
                get
                {
                    if ((cachedComponentCategoryColumnName == null))
                    {
                        cachedComponentCategoryColumnName = CoreManager.MomConsole.GetIntlStr(ResourceComponentCategoryColumnName);
                    }
                    return cachedComponentCategoryColumnName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Context Menu - View management pack objects...
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18July06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuViewMPObjects
            {
                get
                {
                    if ((cachedContextMenuViewMPObjects == null))
                    {
                        cachedContextMenuViewMPObjects = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuViewMPObjects);
                    }
                    return cachedContextMenuViewMPObjects;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Task Results"
            /// </summary>
            /// <history>
            /// 	[faizalk] 30APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TimeoutDialogTitle
            {
                get
                {
                    if ((cachedTimeoutDialogTitle == null))
                    {
                        cachedTimeoutDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceTimeoutDialogTitle);
                    }

                    return cachedTimeoutDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "{0} Properties"
            /// </summary>
            /// <history>
            /// 	[faizalk] 03MAY07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PropertiesDialogTitle
            {
                get
                {
                    if ((cachedPropertiesDialogTitle == null))
                    {
                        cachedPropertiesDialogTitle = "*" + CoreManager.MomConsole.GetIntlStr(ResourcePropertiesDialogTitle).Replace("{0}", "") + "*";
                    }

                    return cachedPropertiesDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Delete Monitoring" confirmation dialog
            /// </summary>
            /// <history>
            /// 	[dialac] 27JAN09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DeleteMonitoringDialogTitle
            {
                get
                {
                    if ((cachedDeleteMonitoringDialogTitle == null))
                    {
                        cachedDeleteMonitoringDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceConfirmDeleteMonitoringTitle); 
                    }

                    return cachedDeleteMonitoringDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Web Application Editor" confirmation dialog
            /// </summary>
            /// <history>
            /// 	[v-eryon] 28JULY09 Created
            /// </history>
            public static string EditWebApplicationTitle
            {
                get
                {
                    if ((cachedEditWebApplicationTitle == null))
                    {
                        cachedEditWebApplicationTitle = CoreManager.MomConsole.GetIntlStr(ResourceEditWebApplicationTitle);
                    }

                    return cachedEditWebApplicationTitle;
                }
            }
            
            #endregion
        }
        #endregion
    }

    /// <summary>
    /// Parameters class for SynTx features
    /// </summary>
    /// <history>
    /// [faizalk] 25APR07 Created
    /// </history>
    public abstract class SynTxParameters
    {
        #region Private Members
        // typically wizard page 1    
        private string cachedName = null;
        private string cachedDescription = null;
        private string cachedDestinationMP = null;

        // typically wizard page 2
        private bool cachedRunTest = false;
        private bool cachedExpectedTestSuccess = false;
        
        // typically wizard page 3
        private string[] cachedWatcherNodes = null;
        private string cachedQueryIntervalTime = null;
        private Templates.WatcherNodeQueryIntervalUnit cachedQueryIntervalUnit = Templates.WatcherNodeQueryIntervalUnit.Minutes;
        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor - no need in ExePath etc. Inherited classes
        /// from Console set all required properties on parameter objects.
        /// </summary>
        public SynTxParameters()
        {
        }
        #endregion

        #region Properties

        /// <summary>
        /// Display Name of Port
        /// </summary>
        public string Name
        {
            get
            {
                return this.cachedName;
            }

            set
            {
                this.cachedName = value;
            }
        }

        /// <summary>
        /// Description for Component
        /// </summary>
        public string Description
        {
            get
            {
                return this.cachedDescription;
            }

            set
            {
                this.cachedDescription = value;
            }
        }

        /// <summary>
        /// Destination MP for Component
        /// </summary>
        public string DestinationMP
        {
            get
            {
                return this.cachedDestinationMP;
            }

            set
            {
                this.cachedDestinationMP = value;
            }
        }

        /// <summary>
        /// whether to click Test button for port to be monitored
        /// </summary>
        public bool RunTest
        {
            get
            {
                return this.cachedRunTest;
            }

            set
            {
                this.cachedRunTest = value;
            }
        }

        /// <summary>
        /// whether test should yield successful result
        /// </summary>
        public bool ExpectedTestSuccess
        {
            get
            {
                return this.cachedExpectedTestSuccess;
            }

            set
            {
                this.cachedExpectedTestSuccess = value;
            }
        }

        /// <summary>
        /// array of watcher nodes to select
        /// </summary>
        public string[] WatcherNodes
        {
            get
            {
                return this.cachedWatcherNodes;
            }

            set
            {
                this.cachedWatcherNodes = value;
            }
        }

        /// <summary>
        /// Run this query every 'QueryIntervalTime' Seconds/Minutes/Hours/Days
        /// </summary>
        public string QueryIntervalTime
        {
            get
            {
                return this.cachedQueryIntervalTime;
            }

            set
            {
                this.cachedQueryIntervalTime = value;
            }
        }

        /// <summary>
        /// Run this query every 'QueryIntervalTime' Seconds/Minutes/Hours/Days
        /// </summary>
        public Templates.WatcherNodeQueryIntervalUnit QueryIntervalUnit
        {
            get
            {
                return this.cachedQueryIntervalUnit;
            }

            set
            {
                this.cachedQueryIntervalUnit = value;
            }
        }
        #endregion

    }
}