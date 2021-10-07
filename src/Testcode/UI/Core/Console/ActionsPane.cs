// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ActionsPane.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
//  MOMv3
// </project>
// <summary>
// 	Tasks Pane methods
// </summary>
// <history>
// 	[mbickle]  10AUG05 Created
//  [mbickle]  12AUG05 Added in TaskStrip support to get at the TaskWindows.
//  [faizalk]  20OCT05 Added ClickMonitoringLink and ClickTaskLink methods
//  [faizalk]  17NOV05 Refactored methods as per code review
//  [HainingW] 23MAR06 Added GroupTaskGroup related strings
//  [faizalk]  27MAR06 Rename TaskPane to ActionsPane
//  [KellyMor] 10APR08 Added resource for "Actions" group in the Admin actions
//                     Actions pane.
//  [KellyMor] 04OCT08 Added resources for new notifications groups: channel,
//                     subscriber, and subscription in Admin View Actions pane.
//  [KellyMor] 28OCT08 Added resources for "Create" and "Modify" for the Alerts
//                     view actions pane.
//  [rahsing]  12DEC15 Added method to click a Action Link using LeftButton in currently visible 
//                     TaskStrip area of Action Pane. This Will only work for Administration Space
// </history>
// ----------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Maui.Core;
    using Mom.Test.UI.Core.Common;
    #endregion

    #region Interfaces
    /// <summary>
    /// Console ActionsPane Interface
    /// </summary>
     public interface IActionsPane
    {
        /// <summary>
        /// Splitter Bar
        /// </summary>
        ActiveAccessibility Splitter
        {
            get;
        }
    }
    #endregion

    /// ------------------------------------------------------------------
    /// <summary>
    /// Actions Pane Class
    /// </summary>
    /// <history>
    ///     [mbickle] 10AUG05 Created
    ///     [faizalk] 27MAR06 Rename TaskPane to ActionsPane
    /// </history>
    /// ------------------------------------------------------------------
    public class ActionsPane : Window, IActionsPane
    {
        #region Constructor
        /// ------------------------------------------------------------------
        /// <summary>
        /// ActionsPane Window
        /// </summary>
        /// <param name="app">ConsoleApp</param>
        /// ------------------------------------------------------------------
        public ActionsPane(ConsoleApp app) :
            base(app.MainWindow, QueryIds.ActionsPaneQid, Core.Common.Constants.DefaultDialogTimeout)
        {
            Utilities.LogMessage("ActionsPane:: Constructor");
        }

        /// <summary>
        /// ActionsPane Window. 
        /// Maui4.0:[v-vijia] used to catch the task pane which is in new window.
        /// </summary>
        /// <param name="knownWindow">known window</param>
        public ActionsPane(Window knownWindow):
            base(knownWindow, QueryIds.ActionsPaneQid, Core.Common.Constants.DefaultDialogTimeout)
        {
            Utilities.LogMessage("ActionsPane:: Constructor");
        }

        #endregion

        #region Properties
        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns if Pane is Visible or Not.
        /// </summary>
        /// <history>
        /// 	[mbickle] 10AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public new bool IsVisible
        {
            get
            {
                return this.Extended.IsVisible;
            }
        }

          /// ------------------------------------------------------------------
          /// <summary>
          /// Access to the ActionsPane Splitter Bar
          /// </summary>
          /// ------------------------------------------------------------------
         public ActiveAccessibility Splitter
          {
              get
              {
                  return CoreManager.MomConsole.MainWindow.Extended.AccessibleObject.FindChild(ControlIDs.ActionsPaneSplitter);
              }
          }

        /// ------------------------------------------------------------------
        /// <summary>
        /// MyWorkspace Control - NYI
        /// </summary>
        /// <history>
        /// 	[mbickle] 11AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public MomControls.TaskStrip MyWorkspace
        {
            get
            {
                return new MomControls.TaskStrip(this, MomControls.TaskStrip.ControlIDs.MyWorkspace);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Tasks Control - NYI
        /// </summary>
        /// <history>
        /// 	[mbickle] 11AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public MomControls.TaskStrip Tasks
        {
            get
            {
                //[v-lileo] : MAUI 2.0 updated tasktrip caption to replace wonform id.  
                QID queryId = new QID(";[UIA]AutomationId=\'" + MomControls.TaskStrip.ControlIDs.Tasks + "\'");
                Maui.Core.Window win = new Maui.Core.Window(queryId, Core.Common.Constants.DefaultDialogTimeout);                
                return new MomControls.TaskStrip(this, win.Caption);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Related Tasks - NYI
        /// </summary>
        /// <history>
        /// 	[mbickle] 11AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public MomControls.TaskStrip RelatedTasks
        {
            get
            {
                return new MomControls.TaskStrip(this, MomControls.TaskStrip.ControlIDs.RelatedTasks);
            }
        }
        #endregion

        #region Public Methods

        /// ------------------------------------------------------------------
        /// <summary>
        /// Show Actions Pane if not Visible
        /// </summary>
        /// ------------------------------------------------------------------
        public void Show()
        {
            if (!this.IsVisible)
            {
                this.Show(CommandMethod.Default);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Show Actions Pane if not Visible
        /// </summary>
        /// <param name="method">CommandMehtod</param>
        /// ------------------------------------------------------------------
        public void Show(CommandMethod method)
        {
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    if (!this.IsVisible)
                    {
                        Commands.ViewActionsPane.Execute(CoreManager.MomConsole, method);
                    }
                    break;
                case ProductSkuLevel.Web:
                    // Currently the ActionsPane is always shown on web console, if the show/hide ActionsPane is implemented on web console in the future, update this section
                    Utilities.LogMessage("ActionsPane.Hide :: Currently there is no way to show/hide Actions Pane in Web Console, ignoring this step.");
                    break;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Hide Actions Pane if Visible
        /// </summary>
        /// ------------------------------------------------------------------
        public void Hide()
        {
            if (this.IsVisible)
            {
                this.Hide(CommandMethod.Default);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Hide Actions Pane if Visible
        /// </summary>
        /// <param name="method">CommandMethod</param>
        /// ------------------------------------------------------------------
        public void Hide(CommandMethod method)
        {
            switch (ProductSku.Sku)
            {
                case ProductSkuLevel.Mom:
                    if (this.IsVisible)
                    {
                        Commands.ViewActionsPane.Execute(CoreManager.MomConsole, method);
                    }
                    break;
                case ProductSkuLevel.Web:
                    // Currently the ActionsPane is always shown on web console, if the show/hide ActionsPane is implemented on web console in the future, update this section
                    Utilities.LogMessage("ActionsPane.Hide :: Currently there is no way to show/hide Actions Pane in Web Console, ignoring this step.");
                    break;
            }
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Click a particular Monitoring link on Actions Pane
        /// </summary>
        /// <param name="linkToClick">string</param>
        /// <exception cref="MomControls.TaskStrip.Exceptions.TaskStripItemNotFoundException"></exception>
        /// <history>
        ///     [faizalk] 20OCT05 created
        ///     [faizalk] 17NOV05 refactored as per code review
        ///     [faizalk] 27MAR06 Rename TaskPane to ActionsPane
        /// </history>
        /// ------------------------------------------------------------------
        [Obsolete("Use ActionsPane.ClickLink")]
        public void ClickMonitoringLink(string linkToClick)
        {      
            // Click Monitoring Configuration wunderbar button
            CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(
                NavigationPane.WunderBarButton.MonitoringConfiguration);

            this.ClickActionsPaneLink(linkToClick, NavigationPane.WunderBarButton.MonitoringConfiguration, null, MouseFlags.LeftButton);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Clicks a Link using LeftButton in currently visible TaskStrip area of Actions Pane
        /// This Will only work for monitoring Space
        /// </summary>
        /// <param name="actionsPaneNode">Task Node in Actions Pane</param>
        /// <param name="linkToClick">Task link to click</param>
        /// <exception cref="MomControls.TaskStrip.Exceptions.TaskStripItemNotFoundException"></exception>
        /// <history>
        ///     [mbickle] 06MAY06 created 
        /// </history>
        /// ------------------------------------------------------------------
        public void ClickLink(string actionsPaneNode, string linkToClick)
        {
            this.ClickActionsPaneLink(linkToClick, NavigationPane.WunderBarButton.Monitoring, actionsPaneNode, MouseFlags.LeftButton);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click a Actions Link using LeftButton in currently visible TaskStrip area of Actions Pane
        /// This Will only work for Administration Space
        /// </summary>
        /// <param name="actionsPaneNode">Task Node in Actions Pane</param>
        /// <param name="linkToClick">Task link to click</param>
        /// <exception cref="MomControls.TaskStrip.Exceptions.TaskStripItemNotFoundException"></exception>
        /// <history>
        ///     [rahsing] 12DEC15 created 
        /// </history>
        /// ------------------------------------------------------------------
        public void ClickActionsLink(string actionsPaneNode, string linkToClick)
        {
            this.ClickActionsPaneLink(linkToClick, NavigationPane.WunderBarButton.Administration, actionsPaneNode, MouseFlags.LeftButton);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Clicks a Link in currently visible TaskStrip area of Actions Pane
        /// This Will only work for monitoring Space
        /// </summary>
        /// <param name="actionsPaneNode">Task Node in Actions Pane</param>
        /// <param name="linkToClick">Task link to click</param>
        /// <param name="button">MouseFlags</param>
        /// <exception cref="MomControls.TaskStrip.Exceptions.TaskStripItemNotFoundException"></exception>
        /// <history>
        ///     [mbickle] 06MAY06 created 
        /// </history>
        /// ------------------------------------------------------------------
        public void ClickLink(string actionsPaneNode, string linkToClick, MouseFlags button)
        {
            this.ClickActionsPaneLink(linkToClick, NavigationPane.WunderBarButton.Monitoring, actionsPaneNode, button);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Navigate to the specified node in a particular Navigation Pane Tree View then
        /// Click a particular link in Actions Pane
        /// </summary>
        /// <param name="navigationSpace">NavigationPane.WunderBarButton</param>
        /// <param name="treeNodePath">Complete path to the Node in Tree View</param>
        /// <param name="actionsPaneNode">Task Node in Actions Pane</param>
        /// <param name="linkToClick">Task link to click</param>
        /// <exception cref="MomControls.TaskStrip.Exceptions.TaskStripItemNotFoundException"></exception>
        /// <history>
        ///     [ruhim] 07MAR06 created     
        /// </history>
        /// ------------------------------------------------------------------
        public void ClickLink(NavigationPane.WunderBarButton navigationSpace, string treeNodePath, string actionsPaneNode, string linkToClick)
        {
            this.ClickLink(navigationSpace, treeNodePath, actionsPaneNode, linkToClick, MouseFlags.LeftButton);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Navigate to the specified node in a particular Navigation Pane Tree View then
        /// Click a particular link in Actions Pane
        /// </summary>
        /// <param name="navigationSpace">NavigationPane.WunderBarButton</param>
        /// <param name="treeNodePath">Complete path to the Node in Tree View</param>
        /// <param name="actionsPaneNode">Task Node in Actions Pane</param>
        /// <param name="linkToClick">Task link to click</param>
        /// <param name="button">MouseFlags</param>
        /// <exception cref="MomControls.TaskStrip.Exceptions.TaskStripItemNotFoundException"></exception>
        /// <history>
        ///     [ruhim] 07MAR06 created  
        /// </history>
        /// ------------------------------------------------------------------
        public void ClickLink(NavigationPane.WunderBarButton navigationSpace, string treeNodePath, string actionsPaneNode, string linkToClick, MouseFlags button)
        {
            // Select the Tree View node first for the specified wunderbar to enable 
            // the appropriate actions pane
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

            switch (navigationSpace)
            {
                case NavigationPane.WunderBarButton.MonitoringConfiguration:
                    navPane.SelectNode(treeNodePath, NavigationPane.NavigationTreeView.MonitoringConfiguration, button, 10);
                    break;

                case NavigationPane.WunderBarButton.Monitoring:
                    navPane.SelectNode(treeNodePath, NavigationPane.NavigationTreeView.Monitoring, button, 10);
                    break;

                case NavigationPane.WunderBarButton.Administration:
                default:
                    navPane.SelectNode(treeNodePath, NavigationPane.NavigationTreeView.Administration, button, 10);
                    break;
            }

            Utilities.LogMessage("ActionsPane.ClickMonitoringConfigTask:: Successfully Selected Node in Tree View");

            this.ClickActionsPaneLink(linkToClick, navigationSpace, actionsPaneNode, button);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Navigate to the specified node in a particular Navigation Pane Tree View then
        /// Click a particular link in Actions Pane
        /// </summary>
        /// <param name="navigationSpace">NavigationPane.WunderBarButton</param>
        /// <param name="treeNodePath">Complete path to the Node in Tree View</param>
        /// <param name="actionsPaneNode">Task Node in Actions Pane</param>
        /// <param name="linkToClick">Task link to click</param>
        /// <exception cref="MomControls.TaskStrip.Exceptions.TaskStripItemNotFoundException"></exception>
        /// <history>
        ///     [v-kayu] 18Nov09 added  
        /// </history>
        /// ------------------------------------------------------------------
        public void ClickLink(string navigationSpace, string treeNodePath, string actionsPaneNode, string linkToClick)
        {
            this.ClickLink(navigationSpace, treeNodePath, actionsPaneNode, linkToClick, MouseFlags.LeftButton);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Navigate to the specified node in a particular Navigation Pane Tree View then
        /// Click a particular link in Actions Pane
        /// </summary>
        /// <param name="navigationSpace">NavigationPane.WunderBarButton</param>
        /// <param name="treeNodePath">Complete path to the Node in Tree View</param>
        /// <param name="actionsPaneNode">Task Node in Actions Pane</param>
        /// <param name="linkToClick">Task link to click</param>
        /// <param name="button">MouseFlags</param>
        /// <exception cref="MomControls.TaskStrip.Exceptions.TaskStripItemNotFoundException"></exception>
        /// <history>
        ///     [v-kayu] 18Nov09 added
        /// </history>
        /// ------------------------------------------------------------------
        public void ClickLink(string navigationSpace, string treeNodePath, string actionsPaneNode, string linkToClick, MouseFlags button)
        {
            // Select the Tree View node first for the specified wunderbar to enable 
            // the appropriate actions pane
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

            navPane.ClickWunderBarButton(navigationSpace);

            navPane.SelectNode(treeNodePath);

            Utilities.LogMessage("ActionsPane.ClickLink:: Successfully Selected Node in Tree View");

            this.ClickActionsPaneLink(linkToClick, navigationSpace, actionsPaneNode, button);
           
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click a particular task on Actions Pane
        /// </summary>
        /// <param name="taskName">string</param>
        /// <exception cref="MomControls.TaskStrip.Exceptions.TaskStripItemNotFoundException"></exception>
        ///  <history>
        ///     [faizalk] 20OCT05 created
        ///     [faizalk] 17NOV05 refactored as per code review
        ///     [faizalk] 27MAR06 Rename TaskPane to ActionsPane
        /// </history>
        /// ------------------------------------------------------------------
        [Obsolete("Use ActionsPane.ClickLink")]
        public void ClickTaskLink(string taskName)
        {
            this.ClickActionsPaneLink(taskName, NavigationPane.WunderBarButton.Monitoring, null, MouseFlags.LeftButton);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click one of the two ActionsPane tabs
        /// </summary>
        /// <param name="tab">ActionsPaneTab</param>
        /// <history>
        ///  [v-raienl] 24/8/2010 Created
        /// </history>
        /// ------------------------------------------------------------------
        public void ClickTab(ActionsPaneTab tab)
        {
            Maui.Core.WinControls.Control tabControl = null;
            switch (tab)
            {
                case ActionsPaneTab.Actions:
                    tabControl = new Maui.Core.WinControls.Control(this, QueryIds.ActionsTabQid, Constants.DefaultViewLoadTimeout);
                    break;
                case ActionsPaneTab.Resources:
                    tabControl = new Maui.Core.WinControls.Control(this, QueryIds.ResourcesTabQid, Constants.DefaultViewLoadTimeout);
                    break;
            }

            tabControl.Click();
        }

        #endregion

        #region Private Methods

        /// ------------------------------------------------------------------
        /// <summary>
        /// Generic method to click a link on Actions Pane
        /// </summary>
        /// <param name="linkName">string</param>
        /// <param name="navigationSpace">NavigationPane.WunderBarButton</param>
        /// <param name="actionsPaneNode">Task node in the actions pane</param>
        /// <param name="button">MouseFlags</param>
        /// <exception cref="MomControls.TaskStrip.Exceptions.TaskStripItemNotFoundException"></exception>
        /// <history>
        ///     [faizalk] 17NOV05 created
        ///     [ruhim]    07MAR06 Added actionsPaneNode and MouseFlagsparameter
        ///     [faizalk] 27MAR06 Rename TaskPane to ActionsPane
        /// </history>
        /// ------------------------------------------------------------------
        private void ClickActionsPaneLink(string linkName, NavigationPane.WunderBarButton navigationSpace, string actionsPaneNode, MouseFlags button)
        {
            Utilities.LogMessage("ClickActionsPaneLink:: entering method");
            Utilities.LogMessage("ClickActionsPaneLink:: Link Name: " + linkName);
            Utilities.LogMessage("ClickActionsPaneLink:: Navigation Space: " + navigationSpace);
            Utilities.LogMessage("ClickActionsPaneLink:: Actions Pane Node: " + actionsPaneNode);

            // Show Tasks Pane
            this.Show();
            UISynchronization.WaitForUIObjectReady(
                            this,
                            Constants.DefaultDialogTimeout);

            MomControls.TaskStrip taskStrip;

            // Get access to the Monitoring taskstrip
            switch (navigationSpace)
            {
                case NavigationPane.WunderBarButton.MonitoringConfiguration:
                    Utilities.LogMessage("ClickActionsPaneLink:: Clicking Monitoring link: \"" + linkName + "\"");
                    taskStrip = new MomControls.TaskStrip(this, actionsPaneNode);
                    taskStrip.ClickLink(linkName,button);
                    break;

                case NavigationPane.WunderBarButton.Monitoring:
                default:
                    Utilities.LogMessage("ClickActionsPaneLink:: Clicking Task link: \"" + linkName + "\"");
                    taskStrip = new MomControls.TaskStrip(this, actionsPaneNode);
                    // Click the Link
                    taskStrip.Expand();
                    taskStrip.ClickLink(linkName, button);
                    break;
            }

            Utilities.LogMessage("ClickActionsPaneLink:: leaving method");
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Generic method to click a link on Actions Pane
        /// </summary>
        /// <param name="linkName">string</param>
        /// <param name="navigationSpace">NavigationPane.WunderBarButton</param>
        /// <param name="actionsPaneNode">Task node in the actions pane</param>
        /// <param name="button">MouseFlags</param>
        /// <exception cref="MomControls.TaskStrip.Exceptions.TaskStripItemNotFoundException"></exception>
        /// <history>
        ///     [v-kayu] 18Nov09 added
        /// </history>
        /// ------------------------------------------------------------------
        [Obsolete("use  ClickTaskPaneLink(string linkName, string taskStripTitle, MouseFlags button, int timeout) ")]
        private void ClickActionsPaneLink(string linkName, string navigationSpace, string actionsPaneNode, MouseFlags button)
        {
            Utilities.LogMessage("ClickActionsPaneLink:: entering method");

            // Show Tasks Pane
            this.Show();
            UISynchronization.WaitForUIObjectReady(
                            this,
                            Constants.DefaultDialogTimeout);

            MomControls.TaskStrip taskStrip;

            // Get access to the Monitoring taskstrip
            Utilities.LogMessage("ClickActionsPaneLink:: Clicking Monitoring link: \"" + linkName + "\"");
            taskStrip = new MomControls.TaskStrip(this, actionsPaneNode);

            // Click the Link
            taskStrip.Expand();
            taskStrip.TaskStripItems[linkName].Click(button);

            Utilities.LogMessage("ClickActionsPaneLink:: leaving method");
        }

        #endregion //Private Methods

        #region Strings Class

        /// ------------------------------------------------------------------
        /// <summary>
        /// Resource string definitions.
        /// </summary>
        /// <history>
        /// 	[faizalk] 19-Oct-05 Created
        ///     [faizalk] 27MAR06 Rename TaskPane to ActionsPane
        ///     [a-joelj] 22DEC08 Changed Resource string for Delete key and removed accelerator char
        /// </history>
        /// ------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneMonitoring =
                ";Monitoring" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Commands.CommandResources" +
                ";MonitoringTasks";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Monitored Components in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneMonitoredComponents =
                ";Monitored Components" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.MonitorCompView.MonitorCompResources" +
                ";ComponentsTaskGroup";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Task in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneTask =
                ";Task" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.TasksView.TasksViewResources" +
                ";TaskTaskGroup";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Tasks in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneTasks = //";Tasks;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.Common.ViewResources;SearchTask";

               ";Tasks" +
                ";ManagedString" +
                //";Microsoft.MOM.UI.Console.exe" +
                //";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.SharedResources" +
                //";TasksPane.PaneTitleText";
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Tasks.TaskResources" +
                ";DefaultItemTasksTitle";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Create a new tasks in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneCreateANewTask =
                ";&Create a New Task" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.TasksView.TasksViewResources" +
                ";CreateTaskTask"; // Old Resource ";Create a new task;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.TasksView.TasksViewResources;CreateTaskTask";
         
            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Group in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneGroup =
                ";Group" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.GroupsView.GroupsResources" +
                ";GroupTaskGroup";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Create a new group in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneCreateANewGroup =
                ";Create a new group" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.GroupsView.GroupsResources" +
                ";GroupCreateTask";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Delete in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneDeleteGroup =
                ";&Delete" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.ServiceDesignerEditor.ServiceDesignerEditorForm" +
                ";deleteToolStripMenuItem.Text";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for View Group Members in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneViewGroupMembers =
                ";View group members" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.GroupsView.GroupsResources" +
                ";GroupViewMemebersTask";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Actions group in the Administration
            /// space Actions pane.
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneAdminViews = 
                ";Actions" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AdminViewGroup";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Channel group in the Administration
            /// space Actions pane.
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneChannel =
                ";Channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";ChannelsTaskGroup";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Subscriber group in the 
            /// Administration space Actions pane.
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneSubscriber =
                ";Subscriber" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscribersTaskGroup";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Subscription group in the 
            /// Administration space Actions pane.
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneSubscription =
                ";Subscription" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";SubscriptionsTaskGroup";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for "Create..." subscription link in  
            /// the Monitoring space, Alerts view Actions pane.
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneCreateSubscription =
                ";Create..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";CommandNotificationsCreate";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for "Modify..." subscription link in  
            /// the Monitoring space, Alerts view Actions pane.
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneModifySubscription =
                ";Modify..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";CommandNotificationsModify";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for "Modify..." subscription link in  
            /// the Monitoring space, Alerts view Actions pane.
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneCustomActions =
                ";Custom Actions" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.MonitorCompView.MonitorCompResources" +
                ";CustomActions";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for "Attribute" in 
            /// the Monitoring space, Attributes Actions pane.
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneAttribute =
            ";Attribute;ManagedString" +
            ";Microsoft.EnterpriseManagement.UI.Authoring.dll" +
            ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.AttributesView.AttributesViewResources" +
            ";AttributeTaskGroup";

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for "Create a New Attribute" in Attribute section in
            /// the Monitoring space, Attributes Actions pane.
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceActionsPaneCreateaNewAttribute =
            ";C&reate a New Attribute" + 
            ";ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" + 
            ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.AttributesView.AttributesViewResources" + 
            ";CreateAttributeTask";

            #endregion

            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneMonitoring;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Attribute in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneAttribute;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource CreateaNewAttribute in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneCreateaNewAttribute;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Monitored Components in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneMonitoredComponents;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Task in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneTask;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Tasks in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneTasks;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Create a new task in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneCreateANewTask;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Create a new task in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedCreateANewTaskToolbarButton;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Group in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneGroup;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Create a new group task in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneCreateANewGroup;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Delete task in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneDeleteGroup;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource View Group Members task in the actions pane
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneViewGroupMembers;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Actions group in the Administration
            /// space Actions pane.
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneAdminViews;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Channel group in the Administration
            /// space Actions pane.
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneChannel;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Subscriber group in the Administration
            /// space Actions pane.
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneSubscriber;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource Subscription group in the Administration
            /// space Actions pane.
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneSubscription;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource "Create..." subscription link 
            /// in the Monitoring space, Alerts view Actions pane.
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneCreateSubscription;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource "Modify..." subscription link 
            /// in the  Monitoring space, Alerts view Actions pane.
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneModifySubscription;

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource "Custom Action" 
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedActionsPaneCustomActions;

            #endregion

            #region Properties

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ravipr] 16-Aug-05 Created
            ///     [faizalk] 27MAR06 Rename TaskPane to ActionsPane
            /// </history>
            /// ---------------------------------------------------------------
            public static string ActionsPaneMonitoring
            {
                get
                {
                    if ((cachedActionsPaneMonitoring == null))
                    {
                        cachedActionsPaneMonitoring = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneMonitoring);
                    }

                    return cachedActionsPaneMonitoring;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitored Components in the actions pane translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 07MAR06 Created
            ///     [faizalk] 27MAR06 Rename TaskPane to ActionsPane
            /// </history>
            /// ---------------------------------------------------------------
            public static string ActionsPaneMonitoredComponents
            {
                get
                {
                    if ((cachedActionsPaneMonitoredComponents == null))
                    {
                        cachedActionsPaneMonitoredComponents = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneMonitoredComponents);
                    }

                    return cachedActionsPaneMonitoredComponents;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Task section in the actions pane translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 16MAR06 Created
            ///     [faizalk] 27MAR06 Rename TaskPane to ActionsPane
            /// </history>
            /// ---------------------------------------------------------------
            public static string ActionsPaneTask
            {
                get
                {
                    if ((cachedActionsPaneTask == null))
                    {
                        cachedActionsPaneTask = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneTask);
                    }

                    return cachedActionsPaneTask;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tasks section in the actions pane translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 16MAR06 Created
            ///     [faizalk] 27MAR06 Rename TaskPane to ActionsPane
            /// </history>
            /// ---------------------------------------------------------------
            public static string ActionsPaneTasks
            {
                get
                {
                    if ((cachedActionsPaneTasks == null))
                    {
                        cachedActionsPaneTasks = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneTasks);
                    }

                    return cachedActionsPaneTasks;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Attribute in the actions pane translated resource string
            /// </summary>
            /// <history>
            ///  [v-harl] 14Nov11 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string Attribute
            {
                get
                {
                    if ((cachedActionsPaneAttribute == null))
                    {
                        cachedActionsPaneAttribute = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneAttribute);
                    }

                    return cachedActionsPaneAttribute;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to Create a New Attribute in the Attribute in the actions pane translated resource string
            /// </summary>
            /// <history>
            ///  [v-harl] 14Nov11 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CreateaNewAttribute
            {
                get
                {
                    if ((cachedActionsPaneCreateaNewAttribute == null))
                    {
                        cachedActionsPaneCreateaNewAttribute = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneCreateaNewAttribute);
                    }

                    return cachedActionsPaneCreateaNewAttribute;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Create a new task link in the actions pane translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 17MAR06 Created
            ///     [faizalk] 27MAR06 Rename TaskPane to ActionsPane
            ///     [a-joelj] 07AUG08 Added code to remove ampersand when clicking Actions Pane option
            /// </history>
            /// ---------------------------------------------------------------
            public static string ActionsPaneCreateANewTask
            {
                get
                {
                    if ((cachedActionsPaneCreateANewTask == null))
                    {
                        cachedActionsPaneCreateANewTask = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneCreateANewTask);

                        // Remove Ampersand from this string for Actions Pane
                        string removeAmp = String.Copy(cachedActionsPaneCreateANewTask);
                        cachedActionsPaneCreateANewTask = removeAmp.Replace("&", "");
                    }

                    return cachedActionsPaneCreateANewTask;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Create a new task link in the Toolbar without stripping the ampersand
            /// </summary>
            /// <history>
            /// 	[a-joelj] 07AUG08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string CreateANewTaskToolbarButton
            {
                get
                {
                    if ((cachedCreateANewTaskToolbarButton == null))
                    {
                        cachedCreateANewTaskToolbarButton = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneCreateANewTask);
                    }

                    return cachedCreateANewTaskToolbarButton;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Group section in the actions pane translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 23MAR06 Created
            ///     [faizalk] 27MAR06 Rename TaskPane to ActionsPane
            /// </history>
            /// ---------------------------------------------------------------
            public static string ActionsPaneGroup
            {
                get
                {
                    if ((cachedActionsPaneGroup == null))
                    {
                        cachedActionsPaneGroup = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneGroup);
                    }

                    return cachedActionsPaneGroup;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Create a new group link in the actions pane translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 23MAR06 Created
            ///     [faizalk] 27MAR06 Rename TaskPane to ActionsPane
            /// </history>
            /// ---------------------------------------------------------------
            public static string ActionsPaneCreateANewGroup
            {
                get
                {
                    if ((cachedActionsPaneCreateANewGroup == null))
                    {
                        cachedActionsPaneCreateANewGroup = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneCreateANewGroup);
                    }

                    return cachedActionsPaneCreateANewGroup;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Delete link in the actions pane translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 25MAR06 Created
            ///     [faizalk] 27MAR06 Rename TaskPane to ActionsPane
            ///     [a-joelj] 22DEC08 Changed Resource string for Delete key and removed accelerator char
            /// </history>
            /// ---------------------------------------------------------------
            public static string ActionsPaneDeleteGroup
            {
                get
                {
                    if ((cachedActionsPaneDeleteGroup == null))
                    {
                        cachedActionsPaneDeleteGroup = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneDeleteGroup);
                        
                        // Remove Ampersand from this string for Actions Pane
                        string removeAmp = String.Copy(cachedActionsPaneDeleteGroup);
                        cachedActionsPaneDeleteGroup = removeAmp.Replace("&", "");
                    }

                    return cachedActionsPaneDeleteGroup;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the View Group Members... link in the actions pane translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 25MAR06 Created
            ///     [faizalk] 27MAR06 Rename TaskPane to ActionsPane
            /// </history>
            /// ---------------------------------------------------------------
            public static string ActionsPaneViewGroupMembers
            {
                get
                {
                    if ((cachedActionsPaneViewGroupMembers == null))
                    {
                        cachedActionsPaneViewGroupMembers = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneViewGroupMembers);
                    }

                    return cachedActionsPaneViewGroupMembers;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Actions group in the Administration space Actions pane.
            /// </summary>
            /// <history>
            /// 	[KellyMor]  10-Apr-08   Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ActionsPaneAdminViews
            {
                get
                {
                    if ((cachedActionsPaneAdminViews == null))
                    {
                        cachedActionsPaneAdminViews = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneAdminViews);
                    }

                    return cachedActionsPaneAdminViews;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Channel group in the Administration space Actions pane.
            /// </summary>
            /// <history>
            /// 	[KellyMor]  04-OCT-08   Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ActionsPaneChannel
            {
                get
                {
                    if ((cachedActionsPaneChannel == null))
                    {
                        cachedActionsPaneChannel = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceActionsPaneChannel);
                    }

                    return cachedActionsPaneChannel;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Subscriber group in the Administration space Actions
            /// pane.
            /// </summary>
            /// <history>
            /// 	[KellyMor]  04-OCT-08   Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ActionsPaneSubscriber
            {
                get
                {
                    if ((cachedActionsPaneSubscriber == null))
                    {
                        cachedActionsPaneSubscriber =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceActionsPaneSubscriber);
                    }

                    return cachedActionsPaneSubscriber;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Subscription group in the Administration space Actions
            /// pane.
            /// </summary>
            /// <history>
            /// 	[KellyMor]  04-OCT-08   Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ActionsPaneSubscription
            {
                get
                {
                    if ((cachedActionsPaneSubscription == null))
                    {
                        cachedActionsPaneSubscription =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceActionsPaneSubscription);
                    }

                    return cachedActionsPaneSubscription;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Create..." subscription link in  the 
            /// Monitoring space, Alerts view Actions pane.
            /// </summary>
            /// <history>
            /// 	[KellyMor]  28-OCT-08   Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ActionsPaneCreateSubscription
            {
                get
                {
                    if ((cachedActionsPaneCreateSubscription == null))
                    {
                        cachedActionsPaneCreateSubscription =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceActionsPaneCreateSubscription);
                    }

                    return cachedActionsPaneCreateSubscription;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Modify..." subscription link in the
            /// Monitoring space, Alerts view Actions pane.
            /// </summary>
            /// <history>
            /// 	[KellyMor]  28-OCT-08   Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ActionsPaneModifySubscription
            {
                get
                {
                    if ((cachedActionsPaneModifySubscription == null))
                    {
                        cachedActionsPaneModifySubscription =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceActionsPaneModifySubscription);
                    }

                    return cachedActionsPaneModifySubscription;
                }
            }

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Custom Actions..." subscription link in the
            /// Monitoring space, Alerts view Actions pane.
            /// </summary>
            /// <history>
            /// 	[v-eryon]  28-JULY-09   Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string ActionsPaneCustomActions
            {
                get
                {
                    if ((cachedActionsPaneCustomActions == null))
                    {
                        cachedActionsPaneCustomActions =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceActionsPaneCustomActions);
                    }

                    return cachedActionsPaneCustomActions;
                }
            }

            #endregion
        }
        #endregion

        #region ControlIDs
        /// ------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[mbickle] 10AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ActionsPane Window
            /// </summary>
            public const string ActionsPane = "TaskPane";

            /// <summary>
            /// Control ID for ActionsPane Splitter
            /// </summary>
            public const string ActionsPaneSplitter = "TaskSplitter";
        }
        #endregion

        #region QueryIDs
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class contains constants for QueryIds
        /// </summary>
        /// <history>
        ///  [v-raienl] 24/8/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class QueryIds
        {
            #region Constants
            /// <summary>
            /// Resource for desktop console actions pane
            /// </summary>
            private const string ResourceActionsPaneDesktop = ";[UIA]Name='TaskPane'";

            /// <summary>
            /// Resource for web console actions pane
            /// </summary>
            private const string ResourceActionsPaneWeb = ";[UIA]AutomationId='tcTasksPaneTabs'";

            /// <summary>
            /// Resource for desktop console actions pane Actions tab
            /// </summary>
            private const string ResourceActionsTabDesktop = ";[UIA]AutomationId='TasksTab' && Role='page tab'";

            /// <summary>
            /// Resource for desktop console actions pane Resources tab
            /// </summary>
            private const string ResourceResourcesTabDesktop = ";[UIA]AutomationId='HelpTab' && Role='page tab'";

            /// <summary>
            /// Resource for web console actions pane Actions tab
            /// </summary>
            private const string ResourceActionsTabWeb = ";[UIA]Name='Actions' && Role='page tab'";

            /// <summary>
            /// Resource for web console actions pane Resources tab
            /// </summary>
            private const string ResourceResourcesTabWeb = ";[UIA]Name='Resources' && Role='page tab'";
            #endregion

            #region Private members
            /// <summary>
            /// Cached actions pane
            /// </summary>
            private static QID cachedActionsPane;

            /// <summary>
            /// Cached actions pane Actions tab
            /// </summary>
            private static QID cachedActionsTab;

            /// <summary>
            /// Cached actions pane Resources tab
            /// </summary>
            private static QID cachedResourcesTab;
            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the actions pane of MOM console or Web console
            /// </summary>
            /// <history>
            ///  [v-raienl] 24/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ActionsPaneQid
            {
                get
                {
                    if (cachedActionsPane == null)
                    {
                        switch (ProductSku.Sku)
                        {
                            case ProductSkuLevel.Mom:
                                cachedActionsPane = new QID(ResourceActionsPaneDesktop);
                                break;
                            case ProductSkuLevel.Web:
                                cachedActionsPane = new QID(ResourceActionsPaneWeb);
                                break;
                        }
                    }

                    return cachedActionsPane;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the actions pane Actions tab of MOM console or Web console
            /// </summary>
            /// <history>
            ///  [v-raienl] 24/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ActionsTabQid
            {
                get
                {
                    if (cachedActionsTab == null)
                    {
                        switch (ProductSku.Sku)
                        {
                            case ProductSkuLevel.Mom:
                                cachedActionsTab = new QID(ResourceActionsTabDesktop);
                                break;
                            case ProductSkuLevel.Web:
                                cachedActionsTab = new QID(ResourceActionsTabWeb);
                                break;
                        }
                    }

                    return cachedActionsTab;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the actions pane Resources tab of MOM console or Web console
            /// </summary>
            /// <history>
            ///  [v-raienl] 24/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID ResourcesTabQid
            {
                get
                {
                    if (cachedResourcesTab == null)
                    {
                        switch (ProductSku.Sku)
                        {
                            case ProductSkuLevel.Mom:
                                cachedResourcesTab = new QID(ResourceResourcesTabDesktop);
                                break;
                            case ProductSkuLevel.Web:
                                cachedResourcesTab = new QID(ResourceResourcesTabWeb);
                                break;
                        }
                    }

                    return cachedResourcesTab;
                }
            }
            #endregion
        }
        #endregion

        /// <summary>
        /// Tabs in ActionsPane
        /// </summary>
        public enum ActionsPaneTab
        {
            /// <summary>
            /// Actions tab
            /// </summary>
            Actions,

            /// <summary>
            /// Resources tab
            /// </summary>
            Resources
        }
    }
}
