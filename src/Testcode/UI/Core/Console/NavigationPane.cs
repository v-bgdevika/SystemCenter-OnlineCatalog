// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="NavigationPane.cs">
//  Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
//  MOMv3
// </project>
// <summary>
//  Navigation Pane methods
// </summary>
// <history>
//  [mbickle] 10AUG05: Created
//  [mbickle] 14AUG05: Added ClickWunderBarButton method.
//                     Added Controls for the Different TreeViews.
//                     TreeView Controls will select appropropriate WunderBar Button, etc.
//                     Added SelectMonitoringConfigFilter() method
//  [kellymor]15AUG05: Added resource strings for device managment views and
//                     context menu for Discovery Wizard.
//  [lucyra] 23AUG05: Added SelectNode method.
//  [barryw] 30Aug05: Updated value of ResourceManagementPacks constant. 
//  [ruhim]  06Sep05: Added resource strings for user roles node and
//                     User Roles Context Menu New.
//  [ruhim]  07Sep05: Added resource strings for health view, windows system MP 
//                    and windows computer under Monitoring Configuration
//  [mbickle] 09SEP05: Added SelectView method for selecting the Views in Views section.
//                     Changed MonitoringViewsTreView and MonitoringConfigurationViewsTreeView to ListViews.
//  [mbickle] 18SEP05: Removed caching of the TreeView Controls.  Added a little extra logging.
//  [faizalk] 09NOV05: modified hard coded resource string property to use Core method
//  [ruhim]   21NOV05: Deleting obsolete string references   
//  [mbickle] 02FEB06: Renamed MonitoringConfigurationMPTreeView to MonitoringConfigurationTreeView
//                     Removed Obsolete NavigationTreeView Enum references.
//  [ruhim]   02MAR06: Updated resource string for new user role context menu 
//  [ruhim]   07MAR06: Adding resource string for Monitored Components node under MonitoringConfigTreeView
//  [ruhim]   19MAR06: Adding resource string for Management Pack Objects node under MonitoringConfigTreeView
//  [HainingW]23MAR06: Adding resource string for Groups node under MonitoringConfigTreeView
//  [mcorning] 27MAR06 Added ActionEditService
//  [kellymor] 17APR06 Added string resources for Settings tree view node
//  [kellymor] 19APR06 Added string resources for Notification nodes and menus
//  [ruhim]    20APR06 Added string resources for RunAsAccount nodes and menus
//  [ruhim]    20APR06 Added string resources for Security node
//  [ruhim]    25APR06 Added string resources for RunAsProfile node
//  [visnara]  12SEP06 Added string resources for Attributes node under MP Objects
//  [visnara]  18SEP06 Added string resources for MP Create context menu for Admin\MP Node
//  [kellymor] 12FEB07 Modified SelectNode method to minimize chance of hitting main window context menu
//  [kellymor] 08APR08 Added resource strings for Pending Management tree node
//                     Stylistic cleanup of Administration resource strings
//  [kellymor] 09APR08 Added resources for Connected Management Groups tree
//                     view node and Add Management Group context menu
//  [kellymor] 15APR08 Added public properties for resource strings above
//  [kellymor] 09MAY08 Added public property for Product Connectors view
//  [kellymor] 29MAY08 Added resource for Rename tree view context menu
//  [kellymor] 01AUG08 Modified to retrieve Administration tree view resources 
//                     from MP on OM and from product assembly on SCE
//                     Added Properties context menu for Monitoring space tree view
//  [kellymor] 13OCT08 Added additional retry logic to SelectNode to match
//                     currently selected node with specified node to handle
//                     case where treeview updates/refreshes during navigation
//                     due to MP import/delete operation.
//  [kellymor] 16OCT08 Added new resource for new channel and updated resource
//                     strings for new subscriber and new subscription.
//  [kellymor] 20OCT08 Updated resource for new channel
//  [rahsing]  01OCT15 Modified resource for Management Packs folder and Installed Management Packs view
//  [rahsing]  01DEC15 Added resource for Updates And Recommendations view
//  [rahsing]  15JAN16 Added resource for All the tasks for Updates and Recommendations view
//  [satim]    03MAR16 Added resources for Tune Management Packs,Tune Alerts view, Filterdata and View sources dialog
//  [rahsing]  25MAY16 Added resource for View Guide and View DLC Page
//</history>
// ----------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MomControls;
    using Microsoft.EnterpriseManagement.Configuration;
    using Mom.Test.UI.Core.ResourceLoader;
    using System.Xml.Linq;
    using System.Reflection;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
    #endregion

    #region Interfaces
    /// <summary>
    /// Console NavigationPane Interface
    /// </summary>
   public interface INavigationPane 
    {
        // <summary>
        /// Controls
        /// </summary>
        INavigationPane Controls
        {
            get;
        }

        /// <summary>
        /// Is Visible
        /// </summary>
        bool IsVisible
        {
            get;
        }

        /// <summary>
        /// Splitter
        /// </summary>
        ActiveAccessibility Splitter
        {
            get;
        }

        /// <summary>
        /// Title
        /// </summary>
        string Title
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NavPaneTitleStaticControl
        /// </summary>
        StaticControl NavigationPaneTitleStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access WunderBar
        /// </summary>
        MomControls.WunderBar WunderBar
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TreeView
        /// </summary>
        MomControls.TreeView NavigationTreeView
        {
            get;
        }

        /// <summary>
        /// ExpandCollapseButton
        /// </summary>
        Button ExpandCollapseButton
        {
            get;
        }

        /// <summary>
        /// Options Button
        /// </summary>
        Button OptionsButton
        {
            get;
        }

        /// <summary>
        /// Select Node
        /// </summary>
        /// <param name="nodePath">Node Path</param>
        /// <param name="wunderBarButton">Wunderbar Button to select</param>
        /// <param name="button">MouseFlags</param>
        /// <returns>TreeNode</returns>
        TreeNode SelectNode(string nodePath, string wunderBarButton, Maui.Core.MouseFlags button);

        /// <summary>
        /// Select Node
        /// </summary>
        /// <param name="nodePath">Node Path</param>
        /// <returns>TreeNode</returns>
        TreeNode SelectNode(string nodePath);

        /// <summary>
        /// Select Node
        /// </summary>
        /// <param name="nodePath">Node Path</param>
        /// <param name="wunderBarButton">Wunderbar Button to select</param>
        /// <returns>TreeNode</returns>
        TreeNode SelectNode(string nodePath, string wunderBarButton);

        /// <summary>
        /// Show
        /// </summary>
        void Show();

        /// <summary>
        /// Show
        /// </summary>
        /// <param name="method">CommandMethod</param>
        void Show(CommandMethod method);

        /// <summary>
        /// Hide
        /// </summary>
        void Hide();

        /// <summary>
        /// Hide
        /// </summary>
        /// <param name="method">CommandMethod</param>
        void Hide(CommandMethod method);

        /// <summary>
        /// Click Wunderbar Button
        /// </summary>
        /// <param name="button">Button Name</param>
        void ClickWunderBarButton(string button);

        /// <summary>
        /// Read-only property to access MonitoringTreeView
        /// </summary>
        MomControls.TreeView MonitoringTreeView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AdministrationTreeView
        /// </summary>
        MomControls.TreeView AdministrationTreeView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MonitoringConfigurationTreeView
        /// </summary>
        MomControls.TreeView MonitoringConfigurationTreeView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AuthoringTreeView
        /// </summary>
        MomControls.TreeView AuthoringTreeView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MyWorkspaceTreeView
        /// </summary>
        MomControls.TreeView MyWorkspaceTreeView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ReportingTreeView
        /// </summary>
        MomControls.TreeView ReportingTreeView
        {
            get;
        }

        /// <summary>
        /// Read-Only property to access ShowHideViewsLink
        /// </summary>
        LinkLabel ShowHideViewsLink
        {
            get;
        }

        /// <summary>
        /// Read-Only property to access NewViewsLink
        /// </summary>
        LinkLabel NewViewsLink
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MonitoringTreeView
        /// </summary>
        //[Obsolete("Use MonitoringTreeView")]
        //TreeView NavigationTreeView
        //{
        //    get;
        //}
    }
    #endregion

    /// ------------------------------------------------------------------
    /// <summary>
    /// Navigation Pane Class
    /// </summary>
    /// <history>
    /// 	[mbickle] 10AUG05 Created
    /// 	[a-joelj] 07MAY10 Changed constructor to use QID by default for the ConsoleApp
    /// </history>
    /// ------------------------------------------------------------------
    public class NavigationPane : Window, INavigationPane   
    {
        #region Private Constants
        /// <summary>
        /// StatusBarText Timeout Value: 60Seconds
        /// </summary>
        private const int StatusTimeout = 60000;

        /// <summary>
        /// WaitforNavigaiton Timeout Value: 10Seconds
        /// </summary>
        private const int WaitForNavigationTimeout = 10000;
        #endregion

        #region Private Member Variables
        /// <summary>
        /// Cache to hold a reference to AdministrationTreeView of type TreeView
        /// </summary>
        private MomControls.TreeView cachedMyWorkspaceTreeView;

        /// <summary>
        /// Cache to hold a reference to MonitoringTreeView of type TreeView
        /// </summary>
        private MomControls.TreeView cachedMonitoringTreeView;

        /// <summary>
        /// Cache to hold a reference to MonitoringConfigurationTreeView of type TreeView
        /// </summary>
        private MomControls.TreeView cachedMonitoringConfigurationTreeView;

        /// <summary>
        /// Cache to hold a reference to AuthoringTreeView of type TreeView
        /// </summary>
        private MomControls.TreeView cachedAuthoringTreeView;

        /// <summary>
        /// Cache to hold a reference to AdministrationTreeView of type TreeView
        /// </summary>
        private MomControls.TreeView cachedAdministrationTreeView;

        /// <summary>
        /// Cache to hold a reference to ReportingTreeView of type TreeView
        /// </summary>
        private MomControls.TreeView cachedReportingTreeView;

        /// <summary>
        /// Cache to hold a reference to ShowHideViewsLink
        /// </summary>
        private LinkLabel cachedShowHideViewsLink;

        /// <summary>
        /// Cache to hold a reference to NewViewsLink
        /// </summary>
        private LinkLabel cachedNewViewsLink;

        /// <summary>
        /// Cache to hold a reference to WunderBar of type StatusBar
        /// </summary>
        private MomControls.WunderBar cachedWunderBar;

        /// <summary>
        /// Cache to hold a reference to ExpandCollapseButton
        /// </summary>
        private Button cachedExpandCollapseButton;

        /// <summary>
        /// Cache to hold a reference to MonitoringTreeView of type TreeView
        /// </summary>
        private MomControls.TreeView cachedNavigationTreeView;

        #endregion

        #region Constructor
        /// ------------------------------------------------------------------
        /// <summary>
        /// NavigationPane Window
        /// </summary>
        /// <param name="app">ConsoleApp</param>
        /// ------------------------------------------------------------------
        public NavigationPane(ConsoleApp app) :
            base(app.MainWindow, new QID(Strings.NavigationPaneQID), Core.Common.Constants.DefaultDialogTimeout)
        {
            Utilities.LogMessage("NavigationPane:: Constructor");
        }
        #endregion

        #region Enum
        /// ------------------------------------------------------------------
        /// <summary>
        /// Monitoring Configuration Filter Options.
        /// </summary>
        /// ------------------------------------------------------------------
       [Obsolete]
        public enum MonitoringConfigFilter
        {
            /// <summary>
            /// Management Pack Filter
            /// </summary>
            ManagementPacks,

            /// <summary>
            /// Managed Entity Type Filter
            /// </summary>
            ManagedEntityType
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// WunderBarButton
        /// </summary>
        /// ------------------------------------------------------------------
        public enum WunderBarButton
        {
            /// <summary>
            /// Monitoring Button
            /// </summary>
            Monitoring,

            /// <summary>
            /// MonitoringConfiguration Button
            /// </summary>
            MonitoringConfiguration,

            /// <summary>
            /// Authoring Button
            /// </summary>
            Authoring,

            /// <summary>
            /// Admnistration Button
            /// </summary>
            Administration,

            /// <summary>
            /// MyWorkspace Button
            /// </summary>
            MyWorkspace,

            /// <summary>
            /// Reporting Button
            /// </summary>
            Reporting
        }
        
        /// <summary>
        /// Navigation Tree View 
        /// </summary>
        public enum NavigationTreeView
        {
            /// <summary>
            /// Administration Tree View
            /// </summary>
            Administration,

            /// <summary>
            /// MyWorkspace Tree View
            /// </summary>
            MyWorkspace,

            /// <summary>
            /// Monitoring Configuration TreeView
            /// </summary>
            MonitoringConfiguration,

            /// <summary>
            /// Authoring TreeView
            /// </summary>
            Authoring,

            /// <summary>
            /// Monitoring TreeView
            /// </summary>
            Monitoring,

            /// <summary>
            /// Reporting TreeView
            /// </summary>
            Reporting
        }

        /// <summary>
        /// Navigation Views List 
        /// </summary>
        [Obsolete]
        public enum ViewsList
        {
            /// <summary>
            /// Monitoring Configuration Views TreeView
            /// </summary>
            MonitoringConfiguration,

            /// <summary>
            /// Monitoring TreeView
            /// </summary>
            Monitoring,
        }
        #endregion

        #region Properties
        /// ------------------------------------------------------------------
        /// <summary>
        /// Get the Navigation Pane Title.
        /// </summary>
        /// <returns>String</returns>
        /// <history>
        /// [mbickle] 10AUG05 Created
        /// </history>*/
        /// ------------------------------------------------------------------        
        public string Title
        {
            get
            {
                return CoreManager.MomConsole.GetStaticControlCaption(this.Controls.NavigationPaneTitleStaticControl);
            }
        }

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
        /// Access to the NavigationPane Splitter Bar
        /// </summary>
        /// ------------------------------------------------------------------
        public ActiveAccessibility Splitter
        {
            get
            {
                return CoreManager.MomConsole.MainWindow.Extended.AccessibleObject.FindChild(ControlIDs.NavigationPaneSplitter);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExpandCollapse Button control
        /// </summary>
        /// <history>
        ///  [mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        Button INavigationPane.ExpandCollapseButton
        {
            get
            {
                ////if (this.cachedExpandCollapseButton == null)
                ////{
                this.cachedExpandCollapseButton = new Button(this, new QID(Strings.ExpandCollapseButton));
                ////}

                return this.cachedExpandCollapseButton;
            }
        }

        /// <summary>
        /// Exposes access to the Navigation Pane Options button
        /// </summary>
        Button INavigationPane.OptionsButton
        {
            get
            {
                return new Button(this, Strings.OptionsButton);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringTreeView control
        /// </summary>
        /// <history>
        ///  [mbickle] 13JUL05 Created
        ///  [mbickle] 29SEP08 Added timeout value for getting Tree Control.
        /// </history>
        /// ------------------------------------------------------------------
        [Obsolete("INavigationPane.NavigationTreeView shouldn't be used for web or Desktop console")]
        MomControls.TreeView INavigationPane.NavigationTreeView
        {
            get
            {
                switch(ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                    case ProductSkuLevel.Web:
                        {
                            this.cachedNavigationTreeView = new MomControls.TreeView(this, new QID(Strings.NavigationTreeView), ConsoleConstants.DefaultControlTimeout);

                            Utilities.LogMessage("TreeView:: FrameworkId = " + this.cachedNavigationTreeView.ScreenElement.FrameworkId.ToString());
                            Utilities.LogMessage("TreeView:: IsWpfElement = " + this.cachedNavigationTreeView.IsWpfElement.ToString());

                            // *** This seems to break automation in improvement branches, results in NodeNotFound. ***
                            // TODO: NathD to verify in momv3.main
                            // Need to use 'UseLegacy' on WinForms TreeView to avoid issues with selecting nodes on x64.
                            //if (!this.cachedNavigationTreeView.IsWpfElement)
                            if (false)
                            {
                                Utilities.LogMessage("TreeView:: IsWpfElement == false, reconstructing TreeView control with UseLegacy.");
                                WindowParameters param = new WindowParameters();
                                param.StartWindow = this;
                                param.UseLegacy = true;
                                param.ClassName = WindowClassNames.WinFormsTreeView;

                                this.cachedNavigationTreeView = new MomControls.TreeView(param);
                            }
                            else
                            {
                                // Replaced click with Select due to Maui issue on WPF TreeView
                                // Set UseRawSelect == true so it does a ScreenElement.Select() 
                                // Which seems to work much more reliably.
                                this.cachedNavigationTreeView.UseRawSelect = true;
                            }
                            break;
                        }
                    // DO NOT CHECKIN!! Testing code above to see if it works on the web console.
                    //case ProductSkuLevel.Web:
                    //    throw new NotImplementedException("Method not supported for web or sharepoint");
                          
                    default:
                        throw new NotImplementedException("Method not supported for web or sharepoint");
                }

                return this.cachedNavigationTreeView;
            }
        }
        #endregion

        #region INavigationPane Controls Property

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the control properties together</value>
        /// <history>
        /// 	[mbickle] 10AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public virtual INavigationPane Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Control Properties

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DetailViewTitleStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        StaticControl INavigationPane.NavigationPaneTitleStaticControl
        {
            get
            {
                //return new StaticControl(this, ControlIDs.NavigationPaneTitleStaticControl);
                return new StaticControl(this, new QID(";[UIA]AutomationId = '" + ControlIDs.NavigationPaneTitleStaticControl +"' && Role = 'text'"));
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ShowHideViewLink control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        LinkLabel INavigationPane.ShowHideViewsLink
        {
            get
            {
                if ((this.cachedShowHideViewsLink == null))
                {
                    this.cachedShowHideViewsLink = new LinkLabel(this.Extended.AccessibleObject.FindChild(Dialogs.ShowHideViewsDialog.Strings.ShowHideViews));
                        ////this.Extended.AccessibleObject.FindChild(Strings.Monitoring).Window, 
                        ////Dialogs.ShowHideViewsDialog.Strings.ShowHideViews, 
                        ////StringMatchSyntax.ExactMatch, 
                        ////WindowClassNames.WinFormsStatic, 
                        ////StringMatchSyntax.WildCard);
                }

                return this.cachedShowHideViewsLink;
               
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NewViewsLink control
        /// </summary>
        /// <history>
        /// 	[kellymor] 05APR07 Created
        /// </history>
        /// ------------------------------------------------------------------
        LinkLabel INavigationPane.NewViewsLink
        {
            get
            {
                if ((this.cachedNewViewsLink == null))
                {
                    this.cachedNewViewsLink = 
                        new LinkLabel(
                            this.Extended.AccessibleObject.FindChild(
                                NavigationPane.Strings.LinkLabelNewViews));
                }

                return this.cachedNewViewsLink;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WunderBar control
        /// </summary>
        /// <history>
        /// 	[mbickle] 10AUG05 Created
        ///     [nathd]   24MAR11 Added Web Console support
        /// </history>
        /// ------------------------------------------------------------------
        MomControls.WunderBar INavigationPane.WunderBar
        {
            get
            {
                if ((this.cachedWunderBar == null))
                {
                    // Switching on console type (web, desktop) because the NavigationPane 
                    // control is not a parent to the Wunderbar control in the web console.
                    // I'm still caching the control, but this could cause problems in 
                    // scenarios where we want to swap between a web and desktop console
                    // without first tearing down CoreManager... Beware...
                    switch (ProductSku.Sku)
                    {
                        case ProductSkuLevel.Web:
                            this.cachedWunderBar = new MomControls.WunderBar();
                            break;

                        default:
                            this.cachedWunderBar = new MomControls.WunderBar(this, MomControls.WunderBar.QueryIds.WunderBar, 5000);
                            break;
                    }
                }

                return this.cachedWunderBar;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringTreeView control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13JUL05 Created
        /// 	[nathd]   14SEP09 Upgraded to Maui 2.0. Reverted to
        /// 	          the original TreeView implementation by 
        /// 	          setting WindowParamaters.UseLegacy 
        ///               to true before attaching.
        /// </history>
        /// ------------------------------------------------------------------
        [Obsolete("INavigationPane.MonitoringTreeView shouldn't be used for web or Desktop console")]
        MomControls.TreeView INavigationPane.MonitoringTreeView
        {
            get
            {
                if (ProductSku.Sku != ProductSkuLevel.Mom)
                {
                    throw new NotImplementedException("Method not supported for web or sharepoint");
                }
                // Lets put us in the right place for getting the TreeControl.
                this.ClickWunderBarButton(WunderBarButton.Monitoring);
               


                // this.cachedMonitoringTreeView = new TreeView(
                //      this,
                //      "",
                //      StringMatchSyntax.WildCard,
                //      WindowClassNames.WinFormsTreeView,
                //      StringMatchSyntax.WildCard);

                // [nathd] Upgraded to Maui 2.0 and wasn't able to get the MonitoringTreeView any more.
                // Reverting to the original TreeView implementation by setting WindowParamaters.UseLegacy 
                // to true before attaching.
                //WindowParameters param = new WindowParameters();
                //param.StartWindow = CoreManager.MomConsole.NavigationPane;
                //param.UseLegacy = true;
                //param.ClassName = WindowClassNames.WinFormsTreeView;

                this.cachedMonitoringTreeView = this.Controls.NavigationTreeView;

                return this.cachedMonitoringTreeView;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MyWorkspaceTreeView control
        /// </summary>
        /// <history>
        /// 	[mbickle] 21JUL05 Created
        /// 	[nathd]   14SEP09 Upgraded to Maui 2.0. Reverted to
        /// 	          the original TreeView implementation by 
        /// 	          setting WindowParamaters.UseLegacy 
        ///               to true before attaching.
        /// </history>
        /// ------------------------------------------------------------------
      [Obsolete("INavigationPane.MyWorkspaceTreeView shouldn't be used for web or Desktop console")]
      MomControls.TreeView INavigationPane.MyWorkspaceTreeView
        {
            get
            {
                if (ProductSku.Sku != ProductSkuLevel.Mom)
                {
                    throw new NotImplementedException("Method not supported for web or sharepoint");
                }
                // Lets put us in the right place for getting the TreeControl.
                this.ClickWunderBarButton(WunderBarButton.MyWorkspace);

                // this.cachedMyWorkspaceTreeView = new TreeView(
                //    this,
                //    "", 
                //    StringMatchSyntax.WildCard, 
                //    WindowClassNames.WinFormsTreeView, 
                //    StringMatchSyntax.WildCard);

                // [nathd] Upgraded to Maui 2.0 and wasn't able to get the MyWorkspaceTreeView any more.
                // Reverting to the original TreeView implementation by setting WindowParamaters.UseLegacy 
                // to true before attaching.
                //WindowParameters param = new WindowParameters();
                //param.StartWindow = CoreManager.MomConsole.NavigationPane;
                //param.UseLegacy = true;
                //param.ClassName = WindowClassNames.WinFormsTreeView;
                this.cachedMyWorkspaceTreeView = this.Controls.NavigationTreeView;

                return this.cachedMyWorkspaceTreeView;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdministrationTreeView control
        /// </summary>
        /// <history>
        /// 	[barryw] 16JUL05 Created
        /// 	[nathd]  14SEP09 Upgraded to Maui 2.0. Reverted to
        /// 	         the original TreeView implementation by 
        /// 	         setting WindowParamaters.UseLegacy 
        ///              to true before attaching.
        /// </history>
        /// ------------------------------------------------------------------
      [Obsolete("INavigationPane.AdministrationTreeView shouldn't be used for web or Desktop console")]
      MomControls.TreeView INavigationPane.AdministrationTreeView
        {
            get
            {
                if (ProductSku.Sku != ProductSkuLevel.Mom)
                {
                    throw new NotImplementedException("Method not supported for web or sharepoint");
                }
                // Lets put us in the right place for getting the TreeControl.
                this.ClickWunderBarButton(WunderBarButton.Administration);
                
                // this.cachedAdministrationTreeView = new TreeView(
                //    this,
                //    "",
                //    StringMatchSyntax.WildCard,
                //    WindowClassNames.WinFormsTreeView,
                //    StringMatchSyntax.WildCard);

                // [nathd] Upgraded to Maui 2.0 and wasn't able to get the AdministrationTreeView any more.
                // Reverting to the original TreeView implementation by setting WindowParamaters.UseLegacy 
                // to true before attaching.
                
                //WindowParameters param = new WindowParameters();
                //param.StartWindow = CoreManager.MomConsole.NavigationPane;
                //param.UseLegacy = true;
                //param.ClassName = WindowClassNames.WinFormsTreeView;
                //TreeView treeView = new TreeView(param);

                this.cachedAdministrationTreeView = this.Controls.NavigationTreeView;

               return this.cachedAdministrationTreeView;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringConfigurationTreeView control
        /// </summary>
        /// <history>
        /// 	[mbickle] 26JUL05 Created
        /// 	[nathd]   14SEP09 Upgraded to Maui 2.0. Reverted to
        /// 	          the original TreeView implementation by 
        /// 	          setting WindowParamaters.UseLegacy 
        ///               to true before attaching.
        /// </history>
        /// <remarks>
        /// </remarks>
        /// ------------------------------------------------------------------
        [Obsolete("INavigationPane.MonitoringConfigurationTreeView shouldn't be used for web or Desktop console")]
        MomControls.TreeView INavigationPane.MonitoringConfigurationTreeView
        {
            get
            {
                if (ProductSku.Sku != ProductSkuLevel.Mom)
                {
                    throw new NotImplementedException("Method not support for web or sharepoint");
                }
                // Lets put us in the right place for getting the TreeControl.
                this.ClickWunderBarButton(WunderBarButton.MonitoringConfiguration);

                // this.cachedMonitoringConfigurationTreeView = new TreeView(
                //    this,
                //    "",
                //    StringMatchSyntax.WildCard,
                //    WindowClassNames.WinFormsTreeView,
                //    StringMatchSyntax.WildCard);

                // [nathd] Upgraded to Maui 2.0 and wasn't able to get the MonitoringConfigurationTreeView any more.
                // Reverting to the original TreeView implementation by setting WindowParamaters.UseLegacy 
                // to true before attaching.
                //WindowParameters param = new WindowParameters();
                //param.StartWindow = CoreManager.MomConsole.NavigationPane;
                //param.UseLegacy = true;
                //param.ClassName = WindowClassNames.WinFormsTreeView;
                //TreeView treeView = new TreeView(param);

                this.cachedMonitoringConfigurationTreeView = this.Controls.NavigationTreeView;

                return this.cachedMonitoringConfigurationTreeView;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringConfigurationTreeView control
        /// </summary>
        /// <history>
        /// 	[mbickle] 26JUL05 Created
        /// 	[nathd]   14SEP09 Upgraded to Maui 2.0. Reverted to
        /// 	          the original TreeView implementation by 
        /// 	          setting WindowParamaters.UseLegacy 
        ///               to true before attaching.
        /// </history>
        /// <remarks>
        /// </remarks>
        /// ------------------------------------------------------------------
        [Obsolete("INavigationPane.AuthoringTreeView shouldn't be used for web or Desktop console")]
        MomControls.TreeView INavigationPane.AuthoringTreeView
        {
            get
            {
                if (ProductSku.Sku != ProductSkuLevel.Mom)
                {
                    throw new NotImplementedException("Method not supported for web or sharepoint");
                }
                // Lets put us in the right place for getting the TreeControl.
                this.ClickWunderBarButton(WunderBarButton.Authoring);

                // this.cachedAuthoringTreeView = new TreeView(
                //    this,
                //    "",
                //    StringMatchSyntax.WildCard,
                //    WindowClassNames.WinFormsTreeView,
                //    StringMatchSyntax.WildCard);

                // [nathd] Upgraded to Maui 2.0 and wasn't able to get the AuthoringTreeView any more.
                // Reverting to the original TreeView implementation by setting WindowParamaters.UseLegacy 
                // to true before attaching.
                //WindowParameters param = new WindowParameters();
                //param.StartWindow = CoreManager.MomConsole.NavigationPane;
                //param.UseLegacy = true;
                //param.ClassName = WindowClassNames.WinFormsTreeView;
                //TreeView treeView = new TreeView(param);

                this.cachedAuthoringTreeView = this.Controls.NavigationTreeView;

                return this.cachedAuthoringTreeView;
            }
        }


        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ReportingTreeView control
        /// </summary>
        /// <history>
        /// 	[mbickle] 08JUN06 Created
        /// 	[nathd]   14SEP09 Upgraded to Maui 2.0. Reverted to
        /// 	          the original TreeView implementation by 
        /// 	          setting WindowParamaters.UseLegacy 
        ///               to true before attaching.
        /// </history>
        /// <remarks>
        /// </remarks>
        /// ------------------------------------------------------------------
       [Obsolete("INavigationPane.ReportingTreeView shouldn't be used for web or Desktop console")]
        MomControls.TreeView INavigationPane.ReportingTreeView
        {
            get
            {
                if (ProductSku.Sku != ProductSkuLevel.Mom)
                {
                    throw new NotImplementedException("Method not supported for web or sharepoint");
                }
                // Lets put us in the right place for getting the TreeControl.
                this.ClickWunderBarButton(WunderBarButton.Reporting);

                //this.cachedReportingTreeView = new TreeView(
                //    this,
                //    "",
                //    StringMatchSyntax.WildCard,
                //    WindowClassNames.WinFormsTreeView,
                //    StringMatchSyntax.WildCard);

                // [nathd] Upgraded to Maui 2.0 and wasn't able to get the ReportingTreeView any more.
                // Reverting to the original TreeView implementation by setting WindowParamaters.UseLegacy 
                // to true before attaching.
                WindowParameters param = new WindowParameters();
                param.StartWindow = CoreManager.MomConsole.NavigationPane;
                param.UseLegacy = true;
                param.ClassName = WindowClassNames.WinFormsTreeView;
                MomControls.TreeView treeView = new MomControls.TreeView(param);

               // this.cachedReportingTreeView = new MomControls.TreeView(param);
                this.cachedReportingTreeView = this.Controls.NavigationTreeView;
                return this.cachedReportingTreeView;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringTreeView control
        /// </summary>
        /// <history>
        /// 	[v-kayu] 18Nov09 added
        /// </history>
        /// ------------------------------------------------------------------
        //[Obsolete("Use MonitoringTreeView")]
        //TreeView INavigationPane.NavigationTreeView
        //{
        //    get
        //    {
        //        // Lets put us in the right place for getting the TreeControl.
        //        // this.ClickWunderBarButton(WunderBarButton.Monitoring);

        //        this.cachedNavigationTreeView = new TreeView(
        //        this,
        //        "",
        //        StringMatchSyntax.WildCard,
        //        WindowClassNames.WinFormsTreeView,
        //        StringMatchSyntax.WildCard);

        //        return this.cachedNavigationTreeView;
        //    }
        //}
        #endregion

        #region Public Methods

        /// ------------------------------------------------------------------
        /// <summary>
        /// Show Navigation Pane if not Visible
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
        /// Show Navigation Pane if not Visible
        /// </summary>
        /// <param name="method">CommandMethod</param>
        /// ------------------------------------------------------------------
        public void Show(CommandMethod method)
        {
            if (!this.IsVisible)
            {
                Commands.ViewNavigationPane.Execute(CoreManager.MomConsole, method);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Hide Navigation Pane if Visible
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
        /// Hide Navigation Pane if Visible
        /// </summary>
        /// <param name="method">CommandMethod</param>
        /// ------------------------------------------------------------------
        public void Hide(CommandMethod method)
        {
            if (this.IsVisible)
            {
                Commands.ViewNavigationPane.Execute(CoreManager.MomConsole, method);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click a Specified WunderBarButton
        /// </summary>
        /// <param name="button">MomControls.WunderBar.WunderBarButton</param>
        /// <history>
        /// [mbickle] 29SEP05 Changed to use String.Compare
        /// </history>
        /// ------------------------------------------------------------------
        public void ClickWunderBarButton(WunderBarButton button)
        {
            string translatedButton = button.ToString();
            switch (button)
            {
                case WunderBarButton.Monitoring:
                    translatedButton = Strings.Monitoring;
                    break;
                case WunderBarButton.MonitoringConfiguration:
                    translatedButton = Strings.MonitoringConfiguration;
                    break;
                case WunderBarButton.Authoring:
                    translatedButton = Strings.Authoring;
                    break;
                case WunderBarButton.Administration:
                    translatedButton = Strings.Administration;
                    break;
                case WunderBarButton.MyWorkspace:
                    translatedButton = Strings.MyWorkspace;
                    break;
                case WunderBarButton.Reporting:
                    translatedButton = Strings.Reporting;
                    break;
                default:
                    throw new System.ArgumentException("NavigationPane.ClickWunderBarButton:: Invalid WunderBarButton passed.");
            }

            //base.ClickWunderBarButton(translatedButton);
            CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(translatedButton);

            //int retry = 0;
            //int retryFind = 5;
            //while (retry < retryFind)
            //{
                //try
                //{
                    //base.ClickWunderBarButton(translatedButton);
                    //break;
                //}
                //catch (Window.Exceptions.WindowNotFoundException exWindow)
                //{
                    //Utilities.LogMessage("ClickWunderBarButton:: Not find WunderBar button: " + translatedButton + ", try again...retry times: " + retry.ToString());
                    //Sleeper.Delay(Core.Common.Constants.OneSecond);
                    //if (++retry == retryFind) throw exWindow;
                //}
                //catch (System.InvalidOperationException exInvalid)
                //{
                    //Utilities.LogMessage("ClickWunderBarButton:: Not find WunderBar button: " + translatedButton + ", try again...retry times: " + retry.ToString());
                    //Sleeper.Delay(Core.Common.Constants.OneSecond);
                    //if (++retry == retryFind) throw exInvalid;
                //}
                //retry++;
            //}
            

            // Wait for StatusBar Ready...
            CoreManager.MomConsole.Waiters.WaitForStatusReady();
            CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, 60000);

        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Click a Specified WunderBarButton
        /// </summary>
        /// <param name="button">MomControls.WunderBar.WunderBarButton</param>
        /// <history>
        /// [v-kayu] 18Nov09 Changed to use String.Compare
        /// </history>
        /// ------------------------------------------------------------------
        public void ClickWunderBarButton(string button)
        {
            switch (ProductSku.Sku)
            {
                 // Desktop Console
                case ProductSkuLevel.Mom:
                {
                    if (String.Compare(this.Title, button, false) != 0)
                    {
                        this.Controls.WunderBar.ClickButton(button);
                    }
                    break;
                }

                // Web Console
                case ProductSkuLevel.Web:
                {
                    // Click the WunderBar button.
                    this.Controls.WunderBar.ClickButton(button);

                    // Ensure the NavTree is visible by moving the mouse outside of the 
                    // WunderBar control. Leaving focus on this control fully expands the 
                    // control and hides the NavTree.
                    //Maui.Core.Mouse.Move(10, 10);
                    break;
                }
            }

            // Wait for StatusBar Ready...
            CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, 60000);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// ClickShowHideViewsLink
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickShowHideViewsLink()
        {
            // Make sure we are in the right space.
            this.ClickWunderBarButton(WunderBarButton.Monitoring);
            
            // Click the Link
            this.Controls.ShowHideViewsLink.Click();
        }

        /// <summary>
        /// ClickNewViewsLink
        /// </summary>
        public void ClickNewViewsLink()
        {
            // Default space is Monitoring
            ClickNewViewsLink(NavigationTreeView.Monitoring);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// ClickNewViewsLink
        /// </summary>
        /// ------------------------------------------------------------------
        public void ClickNewViewsLink(NavigationTreeView space)
        {
            // Default space is Monitoring.
            switch (space)
            {
                case NavigationTreeView.MyWorkspace:
                    this.ClickWunderBarButton(WunderBarButton.MyWorkspace);
                    break;
                
                default:
                    this.ClickWunderBarButton(WunderBarButton.Monitoring);
                    break;
            }

            // Click the Link
            this.Controls.NewViewsLink.Click();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Show Views
        /// </summary>
        /// <param name="viewNames">Name of MP that has Views to display</param>
        /// <param name="show">True = Show views, False = Hide views</param>
        /// ------------------------------------------------------------------
        public void ShowHideViews(System.Collections.ArrayList viewNames, bool show)
        {
            Utilities.LogMessage("NavigationPane.ShowHideViews:: show: " + show.ToString());

            // Click the Show/Hide Link
            this.ClickShowHideViewsLink();

            // Reference the dialog
            Dialogs.ShowHideViewsDialog showHideViewsDialog = 
                new Dialogs.ShowHideViewsDialog(CoreManager.MomConsole);

            Utilities.LogMessage("NavigationPane.ShowHideViews:: Looping through viewNames");
            foreach (string viewItem in viewNames)
            {
                Utilities.LogMessage("NavigationPane.ShowHideViews:: viewItem: " + viewItem);

                // Select the View Item you want to display or hide
                if (show)                    
                {
                    //if (showHideViewsDialog.Controls.ViewsListBox[viewItem].AccessibleObject.StateText.IndexOf(MsaaStates.Checked.ToString(), StringComparison.InvariantCultureIgnoreCase) == -1)
                    //Doing the contains mathc here because Listbox state text returned is solething like - state text is normal,checked,focusable,selectable
                    if (!(showHideViewsDialog.Controls.ViewsListBox[viewItem].AccessibleObject.StateText.Contains(Strings.MsaaStatesCheckedText)))
                    {
                        Utilities.LogMessage("NavigationPane.ShowHideViews:: state text is " + showHideViewsDialog.Controls.ViewsListBox[viewItem].AccessibleObject.StateText);
                        Utilities.LogMessage("NavigationPane.ShowHideViews:: Strings.MsaaStatesCheckedText " + Strings.MsaaStatesCheckedText);                        
                        Utilities.LogMessage("NavigationPane.ShowHideViews:: Checking View");
                        showHideViewsDialog.Controls.ViewsListBox[viewItem].Click();
                    }
                }
                else 
                {
                    //if (showHideViewsDialog.Controls.ViewsListBox[viewItem].AccessibleObject.StateText.IndexOf(MsaaStates.Checked.ToString(), StringComparison.InvariantCultureIgnoreCase) > -1)
                    if ((showHideViewsDialog.Controls.ViewsListBox[viewItem].AccessibleObject.StateText.Contains(Strings.MsaaStatesCheckedText)))
                    {
                        Utilities.LogMessage("NavigationPane.ShowHideViews:: UnChecking View");
                        showHideViewsDialog.Controls.ViewsListBox[viewItem].Click();
                    }
                }
            }

            showHideViewsDialog.ClickOK();            
        }
        
        /// ------------------------------------------------------------------
        /// <summary>
        /// Select node by the path - depends on parameters passed and does MouseFlag.LeftButton
        /// </summary>
        /// <param name="nodeName">
        /// Node that will be selected.  This can be just the node name or 
        /// include the full path and node name, for example: 
        /// {root node name}\{intermediate node name}\{target node name}.
        /// </param>
        /// <param name="treeView">NavigationTreeView to select</param>
        /// <exception cref=" System.ArgumentException">System.ArgumentException</exception>
        /// <returns>TreeNode</returns>
        /// ------------------------------------------------------------------
        public TreeNode SelectNode(string nodeName, NavigationTreeView treeView)
        {
            return this.SelectNode(nodeName, treeView, MouseFlags.LeftButton);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Select node by the path - depends on parameters passed
        /// </summary>
        /// <param name="nodeName">Node to select (full path)</param>
        /// <param name="treeView">NavigationTreeView to select</param>
        /// <param name="button">MouseFlag button to click</param>
        /// <exception cref="System.ArgumentException">System.ArgumentException</exception>
        /// <exception cref="TreeNode.Exceptions.NodeNotFoundException">TreeNode.Exceptions.NodeNotFoundException</exception>
        /// <returns>TreeNode</returns>
        /// ------------------------------------------------------------------
        public TreeNode SelectNode(string nodeName, NavigationTreeView treeView, MouseFlags button)
        {
            return this.SelectNode(nodeName, treeView, button, 3);  
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Select node by the path - depends on parameters passed
        /// </summary>
        /// <param name="nodeName">nodeName must be a full path to the node you wish to select</param>
        /// <param name="treeView">NavigationTreeView to select</param>
        /// <param name="button">MouseFlag button to click</param>
        /// <param name="maxRetry">number of retries</param>
        /// <exception cref="System.ArgumentException">System.ArgumentException</exception>
        /// <exception cref="TreeNode.Exceptions.NodeNotFoundException">TreeNode.Exceptions.NodeNotFoundException</exception>
        /// <returns>TreeNode</returns>
        /// ------------------------------------------------------------------
        public TreeNode SelectNode(string nodeName, NavigationTreeView treeView, MouseFlags button, int maxRetry)
        {
            string method = "NavigationPane.SelectNode :: ";
            Utilities.LogMessage(String.Format("{0} to select '{1}', Navigation TreeView is '{2}'... ", method, nodeName, treeView.ToString()));

            #region Separate Node Name Text from Path, If Present

            // placeholder for the specified node name text
            string nodeNameText = string.Empty;

            // get just the name of the node
            int indexOfLastPathSeparator =
                nodeName.LastIndexOf(Core.Common.Constants.PathDelimiter);

            // if the common path separator, "\\", is NOT present
            if (0 > indexOfLastPathSeparator)
            {
                // look for single \ character, the character is still escaped
                indexOfLastPathSeparator =
                    nodeName.LastIndexOf('\\');
                if (0 > indexOfLastPathSeparator)
                {
                    // use the node name as-is
                    nodeNameText = nodeName;
                }
                else
                {
                    // split off the last bit of the string as node name text
                    nodeNameText =
                        nodeName.Substring(
                            indexOfLastPathSeparator + 1);
                }
            }
            else
            {
                // found "\\", split off last bit of string as node name text
                nodeNameText =
                        nodeName.Substring(
                            (indexOfLastPathSeparator +
                            Core.Common.Constants.PathDelimiter.Length));
            }

            Utilities.LogMessage(
                "NavigationPane.SelectNode::Using node name text := '" +
                nodeNameText +
                "'");

            #endregion Separate Node Name Text from Path, If Present
            
            // set loop values
            TreeNode treeNode = null;
            int retry = 0;

            // Bring to foreground.
            //Maui4.0: Found System.ComponentModel.Win32Exception: Unknown error (0x4003).
            //CoreManager.MomConsole.MainWindow.Extended.SetFocus();
            if (CoreManager.MomConsole.MainWindow.Extended.IsForeground == false)
            {
                CoreManager.MomConsole.BringToForeground();
            }

            // Console Specific Check: Throw if the console type is Web and the Space is not Monitoring or My Workspace
            if (ProductSku.Sku == ProductSkuLevel.Web && (treeView != NavigationTreeView.Monitoring && treeView != NavigationTreeView.MyWorkspace))
            {
                throw new InvalidOperationException(String.Format("Console Space {0} does not exist in the Web Console", treeView.ToString()));
            }

            while (treeNode == null && retry <= maxRetry)
            {
                CoreManager.MomConsole.Waiters.WaitForStatusReady();
                CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, 60000);

                // Find node Name by the full path
                switch (treeView)
                {
                    case NavigationTreeView.Administration:
                        CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Administration);
                        break;
                    case NavigationTreeView.MyWorkspace:
                        CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(NavigationPane.WunderBarButton.MyWorkspace);
                        break;
                    case NavigationTreeView.MonitoringConfiguration:
                        CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(NavigationPane.WunderBarButton.MonitoringConfiguration);
                        break;
                    case NavigationTreeView.Authoring:
                        CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Authoring);
                        break;
                    case NavigationTreeView.Monitoring:
                        CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Monitoring);
                        break;

                    case NavigationTreeView.Reporting:
                        CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Reporting);
                        break;
                    default:
                        throw new System.ArgumentException("NavigationPane.SelectNode::Invalid NavigationTreeView passed.");
                }

                try
                {
                    treeNode = this.SelectNode(nodeName);
                }
                catch (Maui.GlobalExceptions.MauiException me)
                {
                    Utilities.LogMessage("NavigationPane.SelectNode::Got Exception: " + me);
                }
                catch (System.InvalidOperationException ex)
                {
                    Utilities.LogMessage("NavigationPane.SelectNode::Got Exception: " + ex);
                }

                retry++;

                if (treeNode == null)
                {
                    Utilities.LogMessage("NavigationPane.SelectNode::treeNode == null, will try again. Attempt: " + retry + " of " + maxRetry);
                }
                else
                {
                    // if the tree node is not null, is it the one specified?
                    if (treeNode.Text.Equals(nodeNameText) == false)
                    {
                        // no, log that this node does not match specified node
                        Utilities.LogMessage(
                            "NavigationPane.SelectNode::Selected node := '" +
                            treeNode.Text +
                            "'");
                        Utilities.LogMessage(
                            "NavigationPane.SelectNode::Doesn't match specified node := '" +
                            nodeNameText +
                            "'");

                        // set tree node to null to continue the search
                        treeNode = null;
                    }
                }
            }

            if (treeNode != null)
            {
                Utilities.LogMessage(
                    "NavigationPane.SelectNode::Node is not null:  '" +
                    (null != treeNode) +
                    "'");

                /* This is incase we get the main window context menu instead.
                    * It happens on some localized builds, e.g. French.
                    */
                Utilities.LogMessage("NavigationPane.SelectNode:: Send ESC");
                CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);

                // remove focus from the main tool/menu strip as well
                Utilities.LogMessage("NavigationPane.SelectNode:: Send ESC");
                CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);

                Utilities.LogMessage("NavigationPane.SelectNode:: Select() again");

                //workaround for #189122: treeNode.Select() throws InvalidOperationException sometimes
                bool nodeSelected = false;
                for (int i = 0; i < maxRetry; i++)
                {
                    try
                    {
                        treeNode.Select();
                        nodeSelected = true;
                        break;
                    }
                    catch (System.InvalidOperationException)
                    {
                        Sleeper.Delay(Core.Common.Constants.OneSecond * 3);
                        Utilities.LogMessage("NavigationPane.SelectNode::Got InvalidOperationException, will try again later.");
                    }
                }

                CoreManager.MomConsole.Waiters.WaitForReady();

                try
                {
                    /* This is to make sure there's no tooltip up to get in the way.
                        * If we find one, we'll just wait for it to go away.
                        * If one isn't found it throws a WindowNotFoundException.
                        */
                    Utilities.LogMessage(
                        "NavigationPane.SelectNode::Looking for ToolTip.");
                    Maui.Core.WinControls.ToolTip toolTip =
                        new Maui.Core.WinControls.ToolTip(1000, true);

                    Utilities.LogMessage(
                        "NavigationPane.SelectNode::ToolTip visible, wait for it.");
                    toolTip.WaitForInvisible(20000);
                }
                catch (Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage("NavigationPane.SelectNode:: No ToolTip found... WindowNotFoundException thrown...");
                }
                catch (NullReferenceException)
                {
                    Utilities.LogMessage("NavigationPane.SelectNode:: No ToolTip found... NullReferenceException thrown...");
                }
                catch (System.Runtime.InteropServices.InvalidComObjectException ex)
                {
                    Utilities.LogMessage("Exception occur: " + ex.Message);
                    Utilities.LogMessage("NavigationPane.SelectNode:: No tooltip,we are good, just move to next line of code.");
                }
                catch (Maui.GlobalExceptions.TimedOutException ex)
                {
                    Utilities.LogMessage("NavigationPane.SelectNode:: TimedOutException, waiting for tooltip to disappear after 20seconds. " + ex);
                }

                /* This is incase we get into an edit mode on the node.  
                    * Wish there was a better way to do this.
                    */
                Utilities.LogMessage("NavigationPane.SelectNode:: Send ESC");
                CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);

                // Now lets see if we should do a right click on it.
                if (nodeSelected && button == MouseFlags.RightButton)
                {
                    Utilities.LogMessage(
                        "NavigationPane.SelectNode:: Selected. Right-Click()");
                    treeNode.Click(button);
                }

                Utilities.LogMessage(
                    "NavigationPane.SelectNode:: WaitForReady");
                CoreManager.MomConsole.Waiters.WaitForReady();
            }
            else
            {
                throw new TreeNode.Exceptions.NodeNotFoundException(
                    "NavigationPane.SelectNode:: Failed to find node path:= " +
                    nodeName);
            }

            return treeNode;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Select node by the path - depends on parameters passed and does MouseFlag.LeftButton
        /// </summary>
        /// <param name="nodeName">Node that will be selected</param>
        /// <exception cref=" System.ArgumentException">System.ArgumentException</exception>
        /// <returns>TreeNode</returns>
        /// ------------------------------------------------------------------
        public TreeNode SelectNode(string nodeName)
        {
            return this.SelectNode(nodeName, null, MouseFlags.LeftButton);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Select node by the path - depends on parameters passed and does MouseFlag.LeftButton
        /// </summary>
        /// <param name="nodeName">Node that will be selected</param>
        /// <param name="wunderBarButton">WunderBarButton to select</param>
        /// <exception cref=" System.ArgumentException">System.ArgumentException</exception>
        /// <returns>TreeNode</returns>
        /// ------------------------------------------------------------------
        public TreeNode SelectNode(string nodeName, string wunderBarButton)
        {
            return this.SelectNode(nodeName, wunderBarButton, MouseFlags.LeftButton);
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Select node by the path - depends on parameters passed
        /// </summary>
        /// <param name="nodeName">Node to select (full path)</param>
        /// <param name="wunderBarButton">WunderBar Button to select</param>
        /// <param name="button">MouseFlag button to click</param>
        /// <exception cref="System.ArgumentException">System.ArgumentException</exception>
        /// <exception cref="TreeNode.Exceptions.NodeNotFoundException">TreeNode.Exceptions.NodeNotFoundException</exception>
        /// <returns>TreeNode</returns>
        /// ------------------------------------------------------------------
        public TreeNode SelectNode(string nodeName, string wunderBarButton, MouseFlags button)
        {
            Utilities.LogMessage("NavigationPane.SelectNode:: Node to select = " + nodeName +
                " , Navigation TreeView = " + wunderBarButton + " ...");
            TreeNode treeNode = null;
            int maxRetry = 1;

            // Bring to foreground.
            CoreManager.MomConsole.MainWindow.Extended.SetFocus();
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

            // Click the WunderBar Button
            if (wunderBarButton != null)
            {
                this.ClickWunderBarButton(wunderBarButton);
                CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, WaitForNavigationTimeout);
            }

            // Get the TreeNode
            treeNode = this.Controls.NavigationTreeView.ExpandTreePath(nodeName, maxRetry);

            if (treeNode != null)
            {
                Utilities.LogMessage("NavigationPane.SelectNode:: Node is not null:  '" + (null != treeNode) + "'");
                Utilities.LogMessage("NavigationPane.SelectNode:: treeNode.Text is :: " + treeNode.Text);
                
                // This is incase we get the main window context menu instead.
                // It happens on some localized builds, e.g. French.
                Utilities.LogMessage("NavigationPane.SelectNode:: Send ESC");
                CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);

                // remove focus from the main tool/menu strip as well
                Utilities.LogMessage("NavigationPane.SelectNode:: Send ESC");
                CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);

                    Utilities.LogMessage("NavigationPane.SelectNode:: TreeNode.EnsureVisible()");
                    CoreManager.MomConsole.BringToForeground();
                    treeNode.EnsureVisible();
                
                Utilities.LogMessage("NavigationPane.SelectNode:: TreeNode.Select()");
                switch (ProductSku.Sku)
                {
                    case ProductSkuLevel.Mom:
                        treeNode.Select();
                        break;
                    case ProductSkuLevel.Web:
                        Utilities.TakeScreenshot("TreeNode.Select_Before");
                        int retries = 0;
                        while (!treeNode.Selected && retries < Core.Common.Constants.DefaultMaxRetry * 20)
                        {
                            int x = (treeNode.Left + treeNode.Right) / 2;
                            int y = (treeNode.Bottom + treeNode.Top) / 2;
                            Mouse.Click(x, y);

                            Sleeper.Delay(Core.Common.Constants.OneSecond * 2);
                            retries++;
                        }
                        Utilities.LogMessage("NavigationPane.SelectNode:: treeNode.Selected:" + treeNode.Selected);
                        Utilities.TakeScreenshot("TreeNode.Select_After");
                        break;
                }

                try
                {
                    // This is to make sure there's no tooltip up to get in the way.
                    // If we find one, we'll just wait for it to go away.
                    // If one isn't found it throws a WindowNotFoundException.
                    Utilities.LogMessage("NavigationPane.SelectNode:: Looking for ToolTip.");
                    Maui.Core.WinControls.ToolTip toolTip =
                        new Maui.Core.WinControls.ToolTip(1000, true);

                    Utilities.LogMessage("NavigationPane.SelectNode:: ToolTip, visible, lets wait for it.");
                    toolTip.WaitForInvisible(20000);
                }
                catch (Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage("NavigationPane.SelectNode:: No ToolTip found... WindowNotFoundException thrown...");
                }
                catch (NullReferenceException)
                {
                    Utilities.LogMessage("NavigationPane.SelectNode:: No ToolTip found... NullReferenceException thrown...");
                }
                catch (Maui.GlobalExceptions.TimedOutException ex)
                {
                    Utilities.LogMessage("NavigationPane.SelectNode:: TimedOutException, waiting for tooltip to disappear after 20seconds. " + ex);
                }
                catch (System.Runtime.InteropServices.InvalidComObjectException)
                {
                    Utilities.LogMessage("NavigationPane.SelectNode:: InvalidComObjectException thrown...");
                }

                // This is incase we get into an edit mode on the node.  
                // Wish there was a better way to do this.
                Utilities.LogMessage("NavigationPane.SelectNode:: Send ESC");
                CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);

                // Now lets see if we should do a right click on it.
                if (treeNode.Selected && button == MouseFlags.RightButton)
                {
                    Utilities.LogMessage("NavigationPane.SelectNode:: Selected. Right-Click()");
                    treeNode.Click(button);
                }

                Utilities.LogMessage("NavigationPane.SelectNode:: WaitForStatusReady");
                CoreManager.MomConsole.Waiters.WaitForReady();
            }

            Utilities.LogMessage("NavigationPane.SelectNode:: return treeNode");
            return treeNode;
        }
	
        /// <summary>
        /// Determines whether the requested node exist in the NavTree.
        /// </summary>
        /// <param name="nodeName">Full Path to the view (including view name)</param>
        /// <exception cref="System.ArgumentException">throw System.ArgumentException if parameter nodeName is null or empty</exception>
        /// <returns>True if the nodes exists, False otherwise</returns>
        public bool NodeExists(string nodeName)
        {
            TreeNode treeNode = null;

            if (string.IsNullOrEmpty(nodeName))
            {
                throw new ArgumentException("Node name must be set","nodeName");
            }

            Utilities.LogMessage("Try to determine if node exists: "+nodeName);

         //Add try to find treeNode
            int i = 0;
          while (i < Core.Common.Constants.DefaultMaxRetry)
          {
              try
              {
                  // If node has a PathDelimiter we'll use GetNodeByPath
                  if (nodeName.Contains(Core.Common.Constants.PathDelimiter))
                  {
                      treeNode = this.Controls.NavigationTreeView.GetNodeByPath(nodeName, Core.Common.Constants.PathDelimiter, 1, false);
                  }

                  else
                  {
                      // No PathDelimiter in Node so using basic Find.
                      treeNode = this.Controls.NavigationTreeView.Find(nodeName.ToString(), 1, false);     
                  }
                  if (treeNode != null)
                  {
                      Utilities.LogMessage("Found treeNode");
                      break;
                  }
              }
              catch (TreeNode.Exceptions.InvalidFullPathException)
              {
                  // InvalidFullPathException will be thrown if the node does not exists
                  Utilities.LogMessage("InvalidFullPathException caught, tree node not found");
              }
              catch (TreeNode.Exceptions.NodeNotFoundException)
              {
                  Utilities.LogMessage("NodeNotFoundException caught, tree node not found");  
              }
              i++;
              Utilities.LogMessage("Try time  " + i);
          }

            return (null == treeNode) ? false : true;

        }
        #endregion

        #region Private Methods
        
        /// ------------------------------------------------------------------
        /// <summary>
        /// Expand the TreePath 
        /// </summary>
        /// <param name="nodeName">Node Name</param>
        /// <param name="treeView">TreeView name</param>
        /// <exception cref="Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException"></exception>
        /// <returns>TreeNode</returns>
        /// <history>
        /// [mbickle] 28SEP05 Using StringBuilder now.
        /// [mbickle] 12OCT05 Modified so if can't find node reset index and try again from the top.
        ///                   This was done because sometimes the nodes take a moment to become expandable.
        /// [a-joelj] 07MAY10 Updated some references to Core.Common.Constants to resolve ambiguity
        /// </history>
        /// ------------------------------------------------------------------
        private TreeNode ExpandTreePath(string nodeName, MomControls.TreeView treeView)
        {
           
            Utilities.LogMessage("NavigationPane.ExpandTreePath::");

            TreeNode treeNode = null;
            char[] delimiter = Mom.Test.UI.Core.Common.Constants.PathDelimiter.ToCharArray();
            StringBuilder nodes = new StringBuilder();
            string[] treeNodes = null;

            Utilities.LogMessage("NavigationPane.ExpandTreePath:: Split Path");
            treeNodes = nodeName.Split(delimiter);

            int retry = 0;
            int maxRetry = 3;
            int nodeFindRetry = 0;

            // Loop through the nodePath and expand the nodes
            for (int index = 0; index < treeNodes.Length; index++)
            {
                treeNode = null;
                nodes.Append(treeNodes[index]);
                Utilities.LogMessage("NavigationPane.ExpandTreePath:: Path: " + nodes);

                retry = 0;

                // Attempting to get NodeByPath and setting treeNode
                while (treeNode == null && retry < maxRetry)
                {
                    try
                    {
                        // If node has a PathDelimiter we'll use GetNodeByPath
                        if (nodes.ToString().Contains(Core.Common.Constants.PathDelimiter))
                        {
                            Utilities.LogMessage("NavigationPane.ExpandTreePath:: GetNodeByPath: " + nodes);
                            treeNode = treeView.GetNodeByPath(nodes.ToString(), Core.Common.Constants.PathDelimiter, 1, false);
                        }
                        else
                        {
                            // No PathDelimiter in Node so using basic Find.
                            Utilities.LogMessage("NavigationPane.ExpandTreePath:: Find node: " + nodes);
                            Utilities.LogMessage("NavigationPane.ExpandTreePath:: TreeView Root Node: " + treeView.Root.Text);
                            treeNode = treeView.Find(nodes.ToString(), 1, false);
                        }
                    }
                    catch (TreeNode.Exceptions.InvalidFullPathException ex)
                    {
                        // Only Log if hit maxRetry to cut down on noise.
                        if (retry == maxRetry)
                        {
                            Utilities.TakeScreenshot("NavigationPane_ExpandTreePath_InvalidFullPathException");
                            Utilities.LogMessage("NavigationPane.ExpandTreePath:: TreeNode.Exceptions.InvalidFullpathException: " + ex);
                            Utilities.LogMessage("NavigationPane.ExpandTreePath:: retry: " + retry.ToString());
                        }

                        Sleeper.Delay(1000);
                    }
                    catch (TreeNode.Exceptions.NodeNotFoundException ex)
                    {
                        // Only Log if hit maxRetry to cut down on noise.
                        if (retry == maxRetry)
                        {
                            Utilities.TakeScreenshot("NavigationPane_ExpandTreePath_NodeNotFoundException");
                            Utilities.LogMessage("NavigationPane.ExpandTreePath:: TreeNode.Exceptions.NodeNotFoundException: " + ex);
                            Utilities.LogMessage("NavigationPane.ExpandTreePath:: retry: " + retry.ToString());
                        }

                        Sleeper.Delay(1000);
                    }

                    retry++;
                }

                // Check to make sure TreeNode isn't null
                if (treeNode == null && nodeFindRetry <= maxRetry)
                {
                    // Tree Node is null, so increment retry count and try again.
                    nodeFindRetry++;
                    
                    // Reset Index
                    index = -1;
                    
                    // Clear what was already added.
                    nodes.Remove(0, nodes.Length);

                    if (nodeFindRetry == maxRetry)
                    {
                        Utilities.LogMessage("NavigationPane.ExandTreePath:: Node not found, hit max retry");
                        Utilities.TakeScreenshot("NavigationPane_NodeNotFound");
                    }
                }
                else
                {
                    if (treeNode == null)
                    {
                        throw new TreeNode.Exceptions.NodeNotFoundException("NavigationPane.ExpandTreePath:: treeNode was null after max nodeFindRetry");
                    }

                    Utilities.LogMessage("NavigationPane.ExpandTreePath:: Expand TreeNode.");
                    bool expanded = false;
                    retry = 0;

                    // Retry logic as sometimes we get a ChildNotFoundException here 
                    // when trying to expand tree node.
                    while (!expanded && retry < maxRetry)
                    {
                        try
                        {
                            if (treeNode.IsExpandable)
                            {
                                Utilities.LogMessage("Navigation.ExpandTreePath: Expanding TreeNode");
                                treeNode.Expand(true);
                                UISynchronization.WaitForUIObjectReady(treeNode.AccessibleObject, Core.Common.Constants.DefaultDialogTimeout);

                                if (treeNode.Expanded)
                                {
                                    Utilities.LogMessage("Navigation.ExpandTreePath: TreeNode Expanded");
                                    expanded = true;
                                }
                            }
                            else
                            {
                                expanded = true;
                            }
                        }
                        catch (Maui.Core.ActiveAccessibility.Exceptions.ChildNotFoundException ex)
                        {
                            // Only Log if hit maxRetry to cut down on noise.
                            if (retry == maxRetry)
                            {
                                Utilities.TakeScreenshot("NavigationPane_ExpandTree_ChildNotFoundException");
                                Utilities.LogMessage("NavigationPane.ExpandTreePath:: ActiveAccessibility.Exception.ChildNotFound: " + ex);
                            }
                        }

                        Sleeper.Delay(1000);
                        Utilities.LogMessage("NavigationPane.ExpandTreePath:: Expand Node retry: " + retry.ToString());
                        retry++;
                    }

                    Utilities.LogMessage("NavigationPane.ExpandTreePath:: Wait for UI to settle.");
                    this.WaitForResponse();

                    CoreManager.MomConsole.Waiters.WaitForWindowIdle(this, 60000);

                    nodes.Append(Core.Common.Constants.PathDelimiter);
                }
            }
            
            // Check to make sure TreeNode isn't null
            if (treeNode == null)
            {
                Utilities.TakeScreenshot("NavigationPane_NodeNotFound");
                throw new TreeNode.Exceptions.NodeNotFoundException("NavigationPane.ExpandTreePath:: Failed to find Node: " + nodeName);
            }

            return treeNode;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Expand the TreePath 
        /// </summary>
        /// <param name="nodeName">Node Name</param>
        /// <param name="treeView">TreeView name</param>
        /// <exception cref="Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException"></exception>
        /// <returns>TreeNode</returns>
        /// <history>
        /// [sunsingh] Call into SCUI Treeview Expand tree path
        /// </history>
        /// ------------------------------------------------------------------
        [Obsolete]
        private TreeNode ExpandTreePath(string nodename , MomControls.TreeView treeView , int Maxretry)
        {
           Utilities.LogMessage("NavigationPane.ExpandTreePath::");

           TreeNode treeNode = null;
           treeNode = treeView.ExpandTreePath(nodename, Maxretry);
           return treeNode;
        }
        #endregion

        #region Strings Class

        /// ------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[mbickle] 13JUL05 Created
        ///		[barryw]  19JUL05 Updated
        ///		[kellymor]15AUG05 Added resource strings for device managment views and
        ///						  context menu for Discovery Wizard.
        ///   [ruhim]  06Sep05: Added resource strings for user roles node and
        ///                     User Roles Context Menu New.
        ///     [kellymor] 01AUG08 Modified to retrieve Administration tree
        ///                        view resources from MP on OM and from
        ///                        product assembly on SCE
        ///     [a-joelj] 11DEC08 Fixed ResourceMonConfigTreeViewManagementPackObjects
        /// </history>
        /// ------------------------------------------------------------------
        public class Strings 
        {


            #region Constants

            /// <summary>
            /// Contains resource string for:  Operations
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitoring =
                ";Monitoring;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources;MonitoringSpaceWunderBarText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitoringConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitoringConfiguration =
                ";Authoring;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources;AuthoringSpaceWunderBarText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Authoring
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAuthoring =
                ";Authoring;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources;AuthoringSpaceWunderBarText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Monitoring Configuration 
            ///     Management Packs TreeView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitoringConfigurationTreeView =
                ";Types by Management Packs;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Monitoring.MonitoringPage;ServiceDefinitions";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Administration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdministration = ";Administration;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources;AdminSpaceWunderBarText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MyWorkspace
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMyWorkspace = ";My Workspace;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources;MyWorkspaceSpaceWunderBarText";

            /// <summary>
            /// Contains resource string for: Reporting
            /// </summary>
            private const string ResourceReporting = ";Reporting;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources;ReportingSpaceWunderBarText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementPacks
            /// </summary>
            /// <history>
            /// [mbickle] 14NOV05 Changed reference to be common with a SCE reference
            /// </history>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPacks = ";Management Packs;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AdminTreeViewLevelMPS";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  More Information.
            /// </summary>
            /// <history>
            ///		[rahsing]  09JAN16 Created
            /// </history>            
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuMoreInformation =
                ";&More Information;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI." +
                "Administration.AdminResources;MoreInformationMenuItem";      
      
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Get MP.
            /// </summary>
            /// <history>
            ///		[rahsing]  09JAN16 Created
            /// </history>            
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuGetMP =
                ";&Get MP;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI." +
                "Administration.AdminResources;GetMPMenuItem";  

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Get All MPs.
            /// </summary>
            /// <history>
            ///		[rahsing]  09JAN16 Created
            /// </history>            
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuGetAllMPs =
                ";Get &All MPs;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI." +
                "Administration.AdminResources;GetAllMPsMenuItem";  

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  View Guide.
            /// </summary>
            /// <history>
            ///		[rahsing]  09JAN16 Created
            /// </history>            
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuViewGuide =
                ";&View Guide;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI." +
                "Administration.AdminResources;ViewGuideMenuItem";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  View DLC Page.
            /// </summary>
            /// <history>
            ///		[rahsing]  25MAY16 Created
            /// </history>            
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuViewDLCPage =
                ";&View Guide;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI." +
                "Administration.AdminResources;ViewDLCPageMenuItem";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Filter Data.
            /// </summary>
            /// <history>
            ///		[satim]  06FEB16 Created
            /// </history>            
            /// -----------------------------------------------------------------------------
            private const string ResourceContextFilterData =
                ";Identify Management Packs To Tune;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI." +
                "Administration.views.TuneManagementPackView;FilterDataName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tune Alerts.
            /// </summary>
            /// <history>
            ///		[satim]  06FEB16 Created
            /// </history>            
            /// -----------------------------------------------------------------------------
            private const string ResourceContextTuneAlerts =
                ";Tune Alerts;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI." +
                "Administration.views.TuneManagementPackView;TuneAlerts";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tune Alerts.
            /// </summary>
            /// <history>
            ///		[satim]  06FEB16 Created
            /// </history>            
            /// -----------------------------------------------------------------------------
            private const string ResourceContextViewSourceDetail =
                ";View or Override Sources;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI." +
                "Administration.views.TuneAlertsView;ViewSorceDetail";
  
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Install Management Pack.
            /// </summary>
            /// <history>
            ///		[barryw]  11OCT05 Updated the resource string to pull from
            ///                       'Microsoft.MOM.UI.Components.dll'.
            /// </history>
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuInstallManagementPack =
                ";Install &Management Pack...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI." +
                "Administration.AdminResources;InstallMPMenuItem";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Monitor an Application Wizard
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuMonitorAnApplicationWizard = ";&Monitor an Application Wizard...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Commands.CommandResources;ApplicationMonitoringWizard";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Monitoring Configuration Filter Panel.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitoringConfigurationFilterPanel =
                ";filterPanel;ManagedString;Microsoft.MOM.UI.Console.exe;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Console." +
                "WunderBarPages.Monitoring.MonitoringPage;filterPanel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create Group Wizard.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuCreateGroupWizard =
                ";Create a new &Group...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Commands.CommandResources;CreateGroupWizardContextMenu";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create Group Wizard.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuCreateRuleWizard = ";Create &Rule Wizard...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Commands.CommandResources;CreateRuleWizard";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministrationTreeView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdministrationTreeView =
                ";Administration.TreeView" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdministrationTreeView" +
                ";$this.AccessibleName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdminTreeViewAdministrationRoot
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdminTreeViewAdministrationRoot =
                ";Administration" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AdminTreeViewAdministrationRoot";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdminTreeViewDeviceManagement
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdminTreeViewDeviceManagement =
                ";Device Management" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AdminTreeViewLevel1DeviceManagement";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdminTreeViewManagementServers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdminTreeViewManagementServers =
                ";Management Servers" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AdminTreeViewLevel3MS";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdminTreeViewAgentManagedComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdminTreeViewAgentManagedComputers =
                ";Agent-Managed Computers" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AdminTreeViewLevel3Agents";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdminTreeViewAgentlessManagedComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdminTreeViewAgentlessManagedComputers =
                ";Agentless Managed Computers" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AdminTreeViewLevel3Agentless";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdminTreeViewNetworkDevices
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdminTreeViewNetworkDevices =
                ";Network Devices/Other Computers" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AdminTreeViewLevel2OtherDevices";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdminTreeViewPendingManagement
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdminTreeViewPendingManagement = 
                ";Pending Management" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AdminTreeViewLevel3PendingManagement";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ContextMenuDiscoveryWizard
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdminTreeViewDiscoveryRules =
                ";Discovery Rules;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AdminTreeViewLevel3DiscoveryRules";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ContextMenuDiscoveryWizard
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuDiscoveryWizard =
                ";&Discovery Wizard" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";DiscoveryWizardMenuText";

            /// <summary>
            /// Contains resource string for:  AdminTreeViewUserRoles
            /// </summary>
            private const string ResourceAdminTreeViewUserRoles =
                ";User Roles;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AdminTreeViewLevel2UserRoles";

            /// <summary>
            /// Contains resource string for:  User Roles Context Menu New
            /// </summary>
            private const string ResourceContextMenuNewUserRoles =
                ";New User Role;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;NewUserRole";

            /// <summary>
            /// Contains resource string for Monitoring Configuration Root Node
            /// </summary>
            private const string ResourceMonConfigTreeViewMPRoot = ";Overview;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.Navigation.NavigationResources;MonitoringConfigOverview";

            /// <summary>
            /// Contains resource string for Monitoring Configuration Monitored Components Node
            /// </summary>
            private const string ResourceMonConfigTreeViewMonitoredComponents =
                ";Management Pack Templates;ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.MonitoringConfiguration.MonitoringConfigurationPageResources;MonitoredCompNode";

            /// <summary>
            /// Contains resource string for Monitoring Configuration Management Pack Objects Node
            /// </summary>
            private const string ResourceMonConfigTreeViewManagementPackObjects =
                ";Management Pack Objects;ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.MonitoringConfiguration.MonitoringConfigurationPageResources;MPObjectsNode";

            /// <summary>
            /// Contains resource string for Monitoring Configuration\Management Pack Objects\Tasks
            /// </summary>
            private const string ResourceMonConfigTreeViewTasks = ";Tasks;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TasksView;ViewName";
            
            ////";Tasks;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.TasksView.TasksViewResources;ViewName"

            /// <summary>
            /// Contains resource string for Monitoring Configuration\Management Pack Objects\Service Level Tracking
            /// </summary>
            private const string ResourceMonConfigTreeViewServiceLevelTracking = 
                ";Service Level Tracking" +  
                ";ManagedString" + 
                ";Microsoft.EnterpriseManagement.UI.Authoring.dll" + 
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.SlaView" + 
                ";ViewName";

            /// <summary>
            /// Contains resource string for Monitoring Configuration\Management Pack Objects\Performance
            /// </summary>
            private const string ResourceMonConfigTreeViewPerformance = ";Performance;ManagedString;Microsoft.MOM.UI.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.SharedResources;NavigationPane.PerformancePageNameText";

            /// <summary>
            /// Contains resource string for Monitoring Configuration\Management Pack Objects\Performance
            /// </summary>
            private const string ResourceMonConfigTreeViewGroups = ";Groups;ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.MonitoringConfiguration.MonitoringConfigurationPageResources;GroupsNode";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Settings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdminTreeViewSettings =
                ";Settings" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AdminTreeViewLevel1NewSettings";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Notifications
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdminTreeViewNotifications =
                ";Notifications" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AdminTreeViewLevel1Notifications";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Notification Recipients
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdminTreeViewRecipients =
                ";Notification Recipients" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AdminTreeViewLevel2Recipients";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Notification Subscriptions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdminTreeViewSubscriptions =
                ";Notification Subscriptions" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AdminTreeViewLevel2Subscriptions";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for conext menu New Channel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuNewChannel =
                ";New channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";NewChannels";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for conext menu New Subscriber
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuNewSubscriber =
                ";New subscriber..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";NewNotificationSubscriber";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for conext menu New Notification Subscription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuNewSubscription =
                ";New subscription..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";NewNotificationSubscription";

            /// <summary>
            /// Contains resource string for Run As Configuration node
            /// </summary>
            private const string ResourceAdminTreeViewRunAsConfiguration =
                ";Run As Configuration;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AdminTreeViewLevel1RunAsConfiguration";

            /// <summary>
            /// Contains resource string for Run As Accounts node
            /// </summary>
            private const string ResourceAdminTreeViewRunAsAccounts =
                ";Accounts;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AdminTreeViewLevel2RunAsAccounts";

            /// <summary>
            /// Contains resource string for conext menu Create Run As Account
            /// </summary>
            private const string ResourceContextMenuCreateRunAsAccount =
                ";&Create Run As Account...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CreateRunAsAccountMenu";

            /// <summary>
            /// Contains resource string for Security node in Administration Tree view
            /// </summary>
            private const string ResourceAdminTreeViewSecurity =
                ";Security;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AdminTreeViewLevel1Security";

            /// <summary>
            /// Contains resource string for Run As Profiles node
            /// </summary>
            private const string ResourceAdminTreeViewRunAsProfiles =
                ";Profiles;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AdminTreeViewLevel2RunAsProfiles";

            /// <summary>
            /// Contains resource string for Create a new distributed application context menu.
            /// </summary>
            private const string ResourceContextMenuCreateNewDistributedApplication = ";Create a new distr&uted application...;ManagedString;Microsoft.Mom.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Commands.CommandResources;LaunchDistributedAppContextMenu";

            /// <summary>
            /// Contains resource string for ContextMenu Add to favorites...
            /// </summary>
            private const string ResourceContextMenuAddToFavorites =
                ";Add to favorites...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Monitoring.MonitoringPageResources;AddToFavorites";

            /// <summary>
            /// Contains resource string for: Saved Searches node
            /// </summary>
            private const string ResourceSavedSearchesNode = ";Saved Searches;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.FavoritesResources;SearchesNodeText";

            /// <summary>
            /// Contains resource string for: Favorite Views node
            /// </summary>
            private const string ResourceFavoriteViewsNode = ";Favorite Views;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.FavoritesResources;FavoriteViewsNodeText";

            /// <summary>
            /// Contains resource string for Monitoring Configuration\Management Pack Objects\Attributes
            /// </summary>
            private const string ResourceMonConfigTreeViewAttributes = ";Attributes;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.AttributesView.AttributesViewResources;ViewName";

            /// <summary>
            /// Contains resource string for Administration\Management Packs \Create Management Pack ctx menu
            /// </summary>
            private const string ResourceContextMenuCreateManagementPack = ";Create Managemen&t Pack;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CreateMPMenuItem";

            /// <summary>
            /// Contains resource string for Monitoring space "New view" link label
            /// </summary>
            private const string ResourceLinkLabelNewViews = ";New view;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Monitoring.MonitoringPageResources;CreateNewViewText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for tree view item Connected Management Groups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdminTreeViewConnectedManagementGroups = 
                ";Connected Management Groups" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AdminTreeViewLevelTiering";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for context menu Add Management Groups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceContextMenuAddManagementGroup = 
                ";Add Management Group" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AddManagementGroup";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Product Connectors tree view node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdminTreeViewProductConnectors =
                ";Product Connectors" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AdminTreeViewLevelConnectors";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Rename context menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRenameContextMenu =
                ";Rena&me" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources" +
                ";RenameMenuText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Properties context menu in Monitoring space
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitoringContextMenuProperties =
                ";Propert&ies" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.ViewCommands" +
                ";ViewProperties.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Node Discovered Inventory in Monitoring space
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitoringDiscoveredInventory =
                ";Discovered Inventory ({0});ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;InventoryViewTitleFormat";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for MsaaStates.Checked text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMsaaStatesChecked = ";checked;Win32String;oleaccrc.dll;1005";

            /// --------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ExpandCollapseButton query id
            /// </summary>
            /// --------------------------------------------------------------
            private const string ResourceExpandCollapseButton = ";[UIA]ClassName = 'Button' && AutomationId = 'PART_ExpandCollapseButton'";

            /// <summary>
            /// Contains resource string for Options Button
            /// </summary>
            private const string ResourceOptionsButton = ";[UIA]AutomationId='OverflowButton'";

            /// --------------------------------------------------------------
            /// <summary>
            /// Contains resource string for DeskTop TreeView query id
            /// </summary>
            /// --------------------------------------------------------------
            private const string ResourceNavigationTreeViewDeskTop = ";[UIA]AutomationId='outlookBarControl';[UIA, VisibleOnly]Role = 'outline'";

            // --------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Web Console TreeView query id
            /// </summary>
            /// --------------------------------------------------------------
            private const string ResourceNavigationTreeViewWeb = ";[UIA]AutomationId = 'MainNavigationTree'";
                //";[UIA, VisibleOnly]Role = 'outline'";

            // --------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Web Console Navigation Pane query id
            /// </summary>
            /// --------------------------------------------------------------
            private const string ResourceNavPaneForWeb = ";[UIA]AutomationId ='MainNavigationTree'";

            // --------------------------------------------------------------
            /// <summary>
            /// Contains resource string for DeskTop Navigation Pane query id
            /// </summary>
            /// --------------------------------------------------------------
            private const string ResourceNavPaneForDeskTop = ";[UIA]Name = '" + ControlIDs.NavigationPanel + "'";

            #endregion

            #region Private Members

         
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Operations
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitoring;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Monitoring
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitoringConfiguration;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Authoring
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAuthoring;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MonitoringConfigurationTreeView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitoringConfigurationTreeView;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Administration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministration;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministrationTreeView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationTreeView;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Reporting
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedReporting;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdminTreeViewAdministrationRoot
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewAdministrationRoot;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MyWorkspace
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMyWorkspace;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementPacks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPacks;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  InstalledManagementPacks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInstalledManagementPacks;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UpdateAndRecommendations
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUpdatesAndRecommendations;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TuneManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTuneManagementPack;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceMapNode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceMapNode;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TuneAlertsView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTuneAlerts;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextMenuMoreInformation
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuMoreInformation;  

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextMenuGetMP
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuGetMP;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextMenuGetAllMPs
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuGetAllMPs;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextMenuViewGuide
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuViewGuide;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextMenuViewDLCPage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuViewDLCPage;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextFilterData
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextFilterData;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextTuneAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextTuneAlerts;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextViewSourceDetail
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextViewSourceDetail;
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextMenuInstallManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuInstallManagementPack;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextMenuCreateRuleWizard
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuCreateRuleWizard;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextMenuMonitorAnApplicationWizard
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuMonitorAnApplicationWizard;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedContextMenuCreateGroupWizard
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuCreateGroupWizard;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedAdminTreeViewDeviceManagement
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewDeviceManagement;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedAdminTreeViewManagementServers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewManagementServers;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedAdminTreeViewAgentManagedComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewAgentManagedComputers;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedAdminTreeViewAgentlessManagedComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewAgentlessManagedComputers;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedAdminTreeViewDiscoveryRules
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewDiscoveryRules;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedAdminTreeViewNetworkDevices
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewNetworkDevices;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedAdminTreeViewNetworkDevicesPendingManagament
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewNetworkDevicesPendingManagement;
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  cachedContextMenuDiscoveryWizard
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuDiscoveryWizard;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UserRoles
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewUserRoles;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Context Menu New for UserRoles
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuNewUserRoles;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Monitoring Configuration MP Root Node.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonConfigTreeViewMPRoot = "Overview";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Monitoring Configuration Monitored Components Node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonConfigTreeViewMonitoredComponents;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Monitoring Configuration Management Pack Objects Node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonConfigTreeViewManagementPackObjects;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Monitoring Configuration Groups Node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonConfigTreeViewGroups;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Monitoring Configuration Tasks Node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonConfigTreeViewTasks;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Monitoring Configuration ServiceLevelTracking Node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonConfigTreeViewServiceLevelTracking;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Monitoring Configuration Performance Node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonConfigTreeViewPerformance;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdminTreeViewSettings Node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewSettings;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdminTreeViewNotifications Node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewNotifications;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdminTreeViewRecipients Node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewRecipients;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdminTreeViewSubscriptions Node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewSubscriptions;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextMenuNewChannel Node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuNewChannel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextMenuNewSubscriber Node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuNewSubscriber;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextMenuNewSubscription Node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuNewSubscription;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Run As Accounts node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewRunAsAccounts;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Run As Configuration node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewRunAsConfiguration;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  conext menu Create Run As Account
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuCreateRunAsAccount;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Security node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewSecurity;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Network Management node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewNetworkManagement;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Run As Profiles node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewRunAsProfiles;

            /// <summary>
            /// Caches the translated resource string for: Create a new distributed application context menu.
            /// </summary>
            private static string cachedContextMenuCreateNewDistributedApplication;

            /// <summary>
            /// Cached resource string for ContextMenu Add to favorites...
            /// </summary>
            private static string cachedContextMenuAddToFavorites;

            /// <summary>
            /// Contains resource string for: Saved Searches node
            /// </summary>
            private static string cachedSavedSearchesNode;

            /// <summary>
            /// Contains resource string for: Favorite Views node
            /// </summary>
            private static string cachedFavoriteViewsNode;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Monitoring Configuration Attributes Node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonConfigTreeViewAttributes;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextMenuCreateManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuCreateManagementPack;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains translated string for LinkLabelNewViews
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLinkLabelNewViews;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdminTreeViewPendingManagement
            /// Node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewPendingManagement;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// AdminTreeViewConnectedManagementGroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewConnectedManagementGroups;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ContextMenuAddManagementGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuAddManagementGroup;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// AdminTreeViewProductConnectors
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewProductConnectors;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Rename
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRenameContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Properties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitoringContextMenuProperties;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// AdminTreeViewChannelsView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewChannelsView;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// AdminTreeViewResourcePoolView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminTreeViewResourcePoolsView;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  
            /// MonitoringDiscoveredInventory

            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitoringDiscoveredInventory;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MsaaStates.Checked text
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMsaaStatesChecked;

            // -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Navigation Pane
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNavPaneQID;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TreeView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNavigationTreeView;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Operations translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13JUL05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Monitoring 
            {
                get 
                {
                    if ((cachedMonitoring == null)) 
                    {
                        cachedMonitoring = CoreManager.MomConsole.GetIntlStr(ResourceMonitoring);
                    }

                    return cachedMonitoring;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MonitoringConfiguration translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13JUL05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitoringConfiguration 
            {
                get 
                {
                    if ((cachedMonitoringConfiguration == null))
                    {
                        cachedMonitoringConfiguration = CoreManager.MomConsole.GetIntlStr(ResourceMonitoringConfiguration);
                    }

                    return cachedMonitoringConfiguration;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Authoring translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 08JUN06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Authoring
            {
                get
                {
                    if ((cachedAuthoring == null))
                    {
                        cachedAuthoring = CoreManager.MomConsole.GetIntlStr(ResourceAuthoring);
                    }

                    return cachedAuthoring;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MonitoringConfigurationTreeView 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 28JUL05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitoringConfigurationTreeView 
            {
                get 
                {
                    if ((cachedMonitoringConfigurationTreeView == null)) 
                    {
                        cachedMonitoringConfigurationTreeView =
                            CoreManager.MomConsole.GetIntlStr(ResourceMonitoringConfigurationTreeView);
                    }

                    return cachedMonitoringConfigurationTreeView;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Administration translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13JUL05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Administration 
            {
                get
                {
                    if ((cachedAdministration == null))
                    {
                        // use resource from product assembly
                        cachedAdministration =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAdministration);
                    }

                    return cachedAdministration;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Administration TreeView translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 19JUL05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationTreeView
            {
                get 
                {
                    if ((cachedAdministrationTreeView == null))
                    {
                        cachedAdministrationTreeView = CoreManager.MomConsole.GetIntlStr(ResourceAdministrationTreeView);
                    }

                    return cachedAdministrationTreeView;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MyWorkspace translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13JUL05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MyWorkspace
            {
                get
                {
                    if (ProductSku.Sku == ProductSkuLevel.Mom)
                    {
                        if ((cachedMyWorkspace == null))
                        {
                            cachedMyWorkspace = CoreManager.MomConsole.GetIntlStr(ResourceMyWorkspace);
                        }

                        return cachedMyWorkspace;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Reporting translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 08JUN06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Reporting
            {
                get
                {
                    if ((cachedReporting == null))
                    {
                        cachedReporting = CoreManager.MomConsole.GetIntlStr(ResourceReporting);
                    }

                    return cachedReporting;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementPacks translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 13JUL05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementPacks 
            { 
                get 
                {
                    
                    if ((cachedManagementPacks == null))
                    {
                        //if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedManagementPacks =
                                Core.Common.Utilities.GetMonitoringFolderName(Core.Console.Views.Views.Strings.ResourceManagementPacksViewTitle);
                        }
                    }

                    return cachedManagementPacks;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the InstalledManagementPacks translated resource string
            /// </summary>
            /// <history>
            /// 	[rahsing] 01OCT15 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InstalledManagementPacks
            {
                get
                {
                    
                    if ((cachedInstalledManagementPacks == null))
                    {
                        //if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedInstalledManagementPacks =
                                Core.Common.Utilities.GetViewName(Core.Console.Views.Views.Strings.ResourceInstalledManagementPacksViewTitle);
                        }
                    }
                    return cachedInstalledManagementPacks;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UpdatesAndRecommendations translated resource string
            /// </summary>
            /// <history>
            /// 	[rahsing] 13OCT15 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UpdatesAndRecommendations
            {
                get
                {

                    if ((cachedUpdatesAndRecommendations == null))
                    {
                        //if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedUpdatesAndRecommendations =
                                Core.Common.Utilities.GetViewName(Core.Console.Views.Views.Strings.ResourceUpdatesAndRecommendationsViewTitle);
                        }
                    }
                    return cachedUpdatesAndRecommendations;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TuneManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[satim] 28JAN16 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TuneManagementPack
            {
                get
                {

                    if ((cachedTuneManagementPack == null))
                    {
                        //if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedTuneManagementPack =
                                Core.Common.Utilities.GetViewName(Core.Console.Views.Views.Strings.ResourceTuneManagementPackViewTitle);
                        }
                    }
                    return cachedTuneManagementPack;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TuneAlerts translated resource string
            /// </summary>
            /// <history>
            /// 	[satim] 28JAN16 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TuneAlerts
            {
                get
                {

                    if ((cachedTuneAlerts == null))
                    {
                        //if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedTuneAlerts =
                                Core.Common.Utilities.GetViewName(Core.Console.Views.Views.Strings.ResourceTuneAlertsViewTitle);
                        }
                    }
                    return cachedTuneAlerts;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TuneManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[satim] 28JAN16 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceMapNode
            {
                get
                {

                    if ((cachedServiceMapNode == null))
                    {
                        //if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedServiceMapNode =
                                Core.Common.Utilities.GetViewName(Core.Console.Views.Views.Strings.ResourceServiceMapNodeTitle);
                        }
                    }
                    return cachedServiceMapNode;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextMenuMoreInformation translated resource string
            /// </summary>
            /// <history>
            /// 	[rahsing] 09JAN16 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuMoreInformation
            {
                get
                {
                    if ((cachedContextMenuMoreInformation == null))
                    {
                        cachedContextMenuMoreInformation = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuMoreInformation);
                    }

                    return cachedContextMenuMoreInformation;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextMenuGetMP translated resource string
            /// </summary>
            /// <history>
            /// 	[rahsing] 09JAN16 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuGetMP
            {
                get
                {
                    if ((cachedContextMenuGetMP == null))
                    {
                        cachedContextMenuGetMP = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuGetMP);
                    }

                    return cachedContextMenuGetMP;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextMenuGetAllMPs translated resource string
            /// </summary>
            /// <history>
            /// 	[rahsing] 09JAN16 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuGetAllMPs
            {
                get
                {
                    if ((cachedContextMenuGetAllMPs == null))
                    {
                        cachedContextMenuGetAllMPs = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuGetAllMPs);
                    }

                    return cachedContextMenuGetAllMPs;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextMenuViewGuide translated resource string
            /// </summary>
            /// <history>
            /// 	[rahsing] 09JAN16 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuViewGuide
            {
                get
                {
                    if ((cachedContextMenuViewGuide == null))
                    {
                        cachedContextMenuViewGuide = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuViewGuide);
                    }

                    return cachedContextMenuViewGuide;
                }
            }

                        /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextMenuViewDLCPage translated resource string
            /// </summary>
            /// <history>
            /// 	[rahsing] 25MAY16 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuViewDLCPage
            {
                get
                {
                    if ((cachedContextMenuViewDLCPage == null))
                    {
                        cachedContextMenuViewDLCPage = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuViewDLCPage);
                    }

                    return cachedContextMenuViewDLCPage;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the cachedContextFilterData  translated resource string
            /// </summary>
            /// <history>
            /// 	[satim] 06FEB16 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextFilterData
            {
                get
                {
                    if ((cachedContextFilterData == null))
                    {
                        cachedContextFilterData = CoreManager.MomConsole.GetIntlStr(ResourceContextFilterData);
                    }

                    return cachedContextFilterData;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the cachedContextTuneAlerts  translated resource string
            /// </summary>
            /// <history>
            /// 	[satim] 06FEB16 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextTuneAlerts
            {
                get
                {
                    if ((cachedContextTuneAlerts == null))
                    {
                        cachedContextTuneAlerts = CoreManager.MomConsole.GetIntlStr(ResourceContextTuneAlerts);
                    }

                    return cachedContextTuneAlerts;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the cachedContextViewSourceDetail translated resource string
            /// </summary>
            /// <history>
            /// 	[satim] 06FEB16 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextViewSourceDetail
            {
                get
                {
                    if ((cachedContextViewSourceDetail == null))
                    {
                        cachedContextViewSourceDetail = CoreManager.MomConsole.GetIntlStr(ResourceContextViewSourceDetail);
                    }

                    return cachedContextViewSourceDetail;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextMenuInstallManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 19JUL05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuInstallManagementPack 
            {
                get 
                {
                    if ((cachedContextMenuInstallManagementPack == null))
                    {
                        cachedContextMenuInstallManagementPack = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuInstallManagementPack);
                    }

                    return cachedContextMenuInstallManagementPack;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextMenuCreateRuleWizard translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 04OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuCreateRuleWizard 
            {
                get 
                {
                    if ((cachedContextMenuCreateRuleWizard == null)) 
                    {
                        cachedContextMenuCreateRuleWizard = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuCreateRuleWizard);
                    }

                    return cachedContextMenuCreateRuleWizard;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextMenuInstallManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 19JUL05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuMonitorAnApplicationWizard 
            {
                get 
                {
                    if ((cachedContextMenuMonitorAnApplicationWizard == null)) 
                    {
                        cachedContextMenuMonitorAnApplicationWizard = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuMonitorAnApplicationWizard);
                    }

                    return cachedContextMenuMonitorAnApplicationWizard;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextMenuCreateGroupWizard translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 19JUL05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuCreateGroupWizard 
            {
                get 
                {
                    if ((cachedContextMenuCreateGroupWizard == null)) 
                    {
                        cachedContextMenuCreateGroupWizard = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuCreateGroupWizard);
                    }

                    return cachedContextMenuCreateGroupWizard;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminTreeViewAdministrationRoot translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw]  19JUL05 Created
            ///     [kellymor]01AUG08 Modified to retrieve resource from MP on OM and from
            ///                       product assembly on SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewAdministrationRoot 
            {
                get
                {
                    if ((cachedAdminTreeViewAdministrationRoot == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use the dynamic tree view resource from management pack
                            cachedAdminTreeViewAdministrationRoot =
                                Core.Common.Utilities.GetMonitoringFolderName(
                                    Core.Console.Views.Views.Strings.ResourceAdministrationRootFolderTitle);
                        }
                    }

                    return cachedAdminTreeViewAdministrationRoot;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminTreeViewDeviceManagement translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 15AUG05 Created
            ///     [kellymor] 01AUG08 Modified to retrieve resource from MP on OM and from
            ///                        product assembly on SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewDeviceManagement 
            {
                get
                {
                    if ((cachedAdminTreeViewDeviceManagement == null)) 
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use the dynamic tree view resource from management pack
                            cachedAdminTreeViewDeviceManagement =
                                Core.Common.Utilities.GetMonitoringFolderName(
                                    Core.Console.Views.Views.Strings.ResourceDeviceManagementFolderTitle);
                        }
                    }

                    return cachedAdminTreeViewDeviceManagement;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminTreeViewManagementServers translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 15AUG05 Created
            ///     [kellymor] 01AUG08 Modified to retrieve resource from MP on OM and from
            ///                        product assembly on SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewManagementServers 
            {
                get 
                {
                    if ((cachedAdminTreeViewManagementServers == null)) 
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedAdminTreeViewManagementServers =
                                Core.Common.Utilities.GetViewName(
                                    Core.Console.Views.Views.Strings.ResourceManagementServersViewTitle);
                        }
                     }

                    return cachedAdminTreeViewManagementServers;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminTreeViewAgentManagedComputers translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 15AUG05 Created
            ///     [kellymor] 01AUG08 Modified to retrieve resource from MP on OM and from
            ///                        product assembly on SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewAgentManagedComputers 
            {
                get
                {
                    if ((cachedAdminTreeViewAgentManagedComputers == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedAdminTreeViewAgentManagedComputers =
                                Core.Common.Utilities.GetViewName(
                                    Core.Console.Views.Views.Strings.ResourceAgentManagedViewTitle);
                        }
                    }

                    return cachedAdminTreeViewAgentManagedComputers;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminTreeViewAgentlessManagedComputers translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 15AUG05 Created
            ///     [kellymor] 01AUG08 Modified to retrieve resource from MP on OM and from
            ///                        product assembly on SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewAgentlessManagedComputers 
            {
                get 
                {
                    if ((cachedAdminTreeViewAgentlessManagedComputers == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedAdminTreeViewAgentlessManagedComputers =
                                Core.Common.Utilities.GetViewName(
                                    Core.Console.Views.Views.Strings.ResourceAgentlessManagedViewTitle);
                        }
                    }

                    return cachedAdminTreeViewAgentlessManagedComputers;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminTreeViewDiscoveryRules translated resource string
            /// </summary>
            /// <history>
            /// 	[v-lileo] 2011/7/22 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewDiscoveryRules
            {
                get
                {
                    if ((cachedAdminTreeViewDiscoveryRules == null))
                    {
                        // use resource from management pack
                        cachedAdminTreeViewDiscoveryRules = CoreManager.MomConsole.GetIntlStr(ResourceAdminTreeViewDiscoveryRules);
                    }

                    return cachedAdminTreeViewDiscoveryRules;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminTreeViewNetworkDevices translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 15AUG05 Created
            ///     [kellymor] 01AUG08 Modified to retrieve resource from MP on OM and from
            ///                        product assembly on SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewNetworkDevices 
            {
                get 
                {
                    if ((cachedAdminTreeViewNetworkDevices == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedAdminTreeViewNetworkDevices =
                                Core.Common.Utilities.GetViewName(
                                    Core.Console.Views.Views.Strings.ResourceNetworkDeviceViewTitle);
                        }
                    }

                    return cachedAdminTreeViewNetworkDevices;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminTreeViewPendingNetworkDevices translated resource string
            /// </summary>
            /// <history>
            /// 	[shreedp] APR2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewNetworkDevicesPendingManagement
            {
                get
                {
                    if ((cachedAdminTreeViewNetworkDevicesPendingManagement == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedAdminTreeViewNetworkDevicesPendingManagement =
                                Core.Common.Utilities.GetViewName(
                                    Core.Console.Views.Views.Strings.ResourceNetworkDevicesPendingManagementViewTitle);
                        }
                    }

                    return cachedAdminTreeViewNetworkDevicesPendingManagement;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminTreeViewPendingManagement translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[kellymor] 08APR08 Created
            ///     [kellymor] 01AUG08 Modified to retrieve resource from MP on OM and from
            ///                        product assembly on SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewPendingManagement
            {
                get
                {
                    if ((cachedAdminTreeViewPendingManagement == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedAdminTreeViewPendingManagement =
                                Core.Common.Utilities.GetViewName(
                                    Core.Console.Views.Views.Strings.ResourcePendingManagementViewTitle);
                        }
                    }

                    return cachedAdminTreeViewPendingManagement;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextMenuDiscoveryWizard translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 15AUG05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuDiscoveryWizard
            {
                get 
                {
                    if ((cachedContextMenuDiscoveryWizard == null))
                    {
                        cachedContextMenuDiscoveryWizard = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuDiscoveryWizard);
                    }

                    return cachedContextMenuDiscoveryWizard;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminTreeViewUserRoles translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim]    20JUL05 Created
            ///     [kellymor] 01AUG08 Modified to retrieve resource from MP on OM and from
            ///                        product assembly on SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewUserRoles 
            {
                get 
                {
                    if ((cachedAdminTreeViewUserRoles == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedAdminTreeViewUserRoles =
                                Core.Common.Utilities.GetViewName(
                                    Core.Console.Views.Views.Strings.ResourceUserRolesViewTitle);
                        }
                    }

                    return cachedAdminTreeViewUserRoles;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UserRoles ContextMenu New translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 20JUL05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuNewUserRoles
            {
                get 
                {
                    if ((cachedContextMenuNewUserRoles == null))
                    {
                        cachedContextMenuNewUserRoles = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuNewUserRoles);
                    }

                    return cachedContextMenuNewUserRoles;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitoring Configuration MP Root Node translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 14OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonConfigTreeViewMPRoot 
            {
                get 
                {
                    if ((cachedMonConfigTreeViewMPRoot == null))
                    {
                        cachedMonConfigTreeViewMPRoot = CoreManager.MomConsole.GetIntlStr(ResourceMonConfigTreeViewMPRoot);
                    }

                    return cachedMonConfigTreeViewMPRoot;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitoring Configuration Monitored Components Node translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 07MAR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonConfigTreeViewMonitoredComponents 
            {
                get 
                {
                    if ((cachedMonConfigTreeViewMonitoredComponents == null))
                    {
                        cachedMonConfigTreeViewMonitoredComponents = CoreManager.MomConsole.GetIntlStr(ResourceMonConfigTreeViewMonitoredComponents);
                    }

                    return cachedMonConfigTreeViewMonitoredComponents;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitoring Configuration Groups Node translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 23MAR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonConfigTreeViewGroups
            {
                get
                {
                    if ((cachedMonConfigTreeViewGroups == null))
                    {
                        cachedMonConfigTreeViewGroups = CoreManager.MomConsole.GetIntlStr(ResourceMonConfigTreeViewGroups);
                    }

                    return cachedMonConfigTreeViewGroups;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitoring Configuration Management Pack Objects Node translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 19MAR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonConfigTreeViewManagementPackObjects 
            {
                get 
                {
                    if ((cachedMonConfigTreeViewManagementPackObjects == null))
                    {
                        cachedMonConfigTreeViewManagementPackObjects = CoreManager.MomConsole.GetIntlStr(ResourceMonConfigTreeViewManagementPackObjects);
                    }

                    return cachedMonConfigTreeViewManagementPackObjects;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitoring Configuration Management Packs Tasks Node translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 16MAR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonConfigTreeViewTasks 
            {
                get 
                {
                    if ((cachedMonConfigTreeViewTasks == null)) 
                    {
                        cachedMonConfigTreeViewTasks = CoreManager.MomConsole.GetIntlStr(ResourceMonConfigTreeViewTasks);
                    }

                    return cachedMonConfigTreeViewTasks;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitoring Configuration Management Packs ServiceLevelTracking Node translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 12OCT08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonConfigTreeViewServiceLevelTracking 
            {
                get 
                {
                    if ((cachedMonConfigTreeViewServiceLevelTracking == null)) 
                    {
                        cachedMonConfigTreeViewServiceLevelTracking = CoreManager.MomConsole.GetIntlStr(ResourceMonConfigTreeViewServiceLevelTracking);
                    }

                    return cachedMonConfigTreeViewServiceLevelTracking;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitoring Configuration Management Packs Performance Node translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 16MAR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonConfigTreeViewPerformance 
            {
                get 
                {
                    if ((cachedMonConfigTreeViewPerformance == null)) 
                    {
                        cachedMonConfigTreeViewPerformance = CoreManager.MomConsole.GetIntlStr(ResourceMonConfigTreeViewPerformance);
                    }

                    return cachedMonConfigTreeViewPerformance;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminTreeViewSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 15AUG05 Created
            ///     [kellymor] 01AUG08 Modified to retrieve resource from MP on OM and from
            ///                        product assembly on SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewSettings
            {
                get
                {
                    if ((cachedAdminTreeViewSettings == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedAdminTreeViewSettings =
                                Core.Common.Utilities.GetViewName(
                                    Core.Console.Views.Views.Strings.ResourceSettingsViewTitle);
                        }
                    }

                    return cachedAdminTreeViewSettings;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminTreeViewNotifications translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 19APR06 Created
            ///     [kellymor] 01AUG08 Modified to retrieve resource from MP on OM and from
            ///                        product assembly on SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewNotifications
            {
                get
                {
                    if ((cachedAdminTreeViewNotifications == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use the dynamic tree view resource from management pack
                            cachedAdminTreeViewNotifications =
                                Core.Common.Utilities.GetMonitoringFolderName(
                                    Core.Console.Views.Views.Strings.ResourceNotificationsFolderTitle);
                        }
                   }

                    return cachedAdminTreeViewNotifications;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminTreeViewRecipients translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 19APR06 Created
            ///     [kellymor] 01AUG08 Modified to retrieve resource from MP on OM and from
            ///                        product assembly on SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewRecipients
            {
                get
                {
                    if ((cachedAdminTreeViewRecipients == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedAdminTreeViewRecipients =
                                Core.Common.Utilities.GetViewName(
                                    Core.Console.Views.Views.Strings.ResourceRecipientsViewTitle);
                        }
                    }

                    return cachedAdminTreeViewRecipients;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminTreeViewSubscriptions translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 19APR06 Created
            ///     [kellymor] 01AUG08 Modified to retrieve resource from MP on OM and from
            ///                        product assembly on SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewSubscriptions
            {
                get
                {
                    if ((cachedAdminTreeViewSubscriptions == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedAdminTreeViewSubscriptions =
                                Core.Common.Utilities.GetViewName(
                                    Core.Console.Views.Views.Strings.ResourceSubscriptionsViewTitle);
                        }
                    }

                    return cachedAdminTreeViewSubscriptions;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextMenuNewChannel translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 19APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuNewChannel
            {
                get
                {
                    if ((cachedContextMenuNewChannel == null))
                    {
                        cachedContextMenuNewChannel = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceContextMenuNewChannel);
                    }

                    return cachedContextMenuNewChannel;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextMenuNewSubscriber translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 19APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuNewSubscriber
            {
                get
                {
                    if ((cachedContextMenuNewSubscriber == null))
                    {
                        cachedContextMenuNewSubscriber = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuNewSubscriber);
                    }

                    return cachedContextMenuNewSubscriber;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextMenuNewSubscription translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 19APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuNewSubscription
            {
                get
                {
                    if ((cachedContextMenuNewSubscription == null))
                    {
                        cachedContextMenuNewSubscription = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuNewSubscription);
                    }

                    return cachedContextMenuNewSubscription;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Run As Accounts node translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim]    19APR06 Created
            ///     [kellymor] 01AUG08 Modified to retrieve resource from MP on OM and from
            ///                        product assembly on SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewRunAsAccounts
            {
                get
                {
                    if ((cachedAdminTreeViewRunAsAccounts == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedAdminTreeViewRunAsAccounts =
                                Core.Common.Utilities.GetViewName(
                                    Core.Console.Views.Views.Strings.ResourceRunAsAccountsViewTitle);
                        }
                    }

                    return cachedAdminTreeViewRunAsAccounts;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Context Menu Create Run As Account translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 19APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuCreateRunAsAccount
            {
                get
                {
                    if ((cachedContextMenuCreateRunAsAccount == null))
                    {
                        cachedContextMenuCreateRunAsAccount = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuCreateRunAsAccount);
                    }

                    return cachedContextMenuCreateRunAsAccount;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Security node translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim]    20APR06 Created
            ///     [kellymor] 01AUG08 Modified to retrieve resource from MP on OM and from
            ///                        product assembly on SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewSecurity
            {
                get
                {
                    if ((cachedAdminTreeViewSecurity == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use the dynamic tree view resource from management pack
                            cachedAdminTreeViewSecurity =
                                Core.Common.Utilities.GetMonitoringFolderName(
                                    Core.Console.Views.Views.Strings.ResourceSecurityFolderTitle);
                        }
                    }

                    return cachedAdminTreeViewSecurity;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Network Management node translated resource string
            /// </summary>
            /// <history>
            /// 	[shreedp]    06-07-2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewNetworkManagement
            {
                get
                {
                    if ((cachedAdminTreeViewNetworkManagement == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use the dynamic tree view resource from management pack
                            cachedAdminTreeViewNetworkManagement =
                                Core.Common.Utilities.GetMonitoringFolderName(
                                    Core.Console.Views.Views.Strings.ResourceNetworkManagementFolderTitle);
                        }
                    }

                    return cachedAdminTreeViewNetworkManagement;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Run As Configuration node translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 08AUG08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewRunAsConfiguration
            {
                get
                {
                    if ((cachedAdminTreeViewRunAsConfiguration == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use the dynamic tree view resource from management pack
                            cachedAdminTreeViewRunAsConfiguration =
                                Core.Common.Utilities.GetMonitoringFolderName(
                                    Core.Console.Views.Views.Strings.ResourceRunAsConfigurationFolderTitle);
                        }
                    }

                    return cachedAdminTreeViewRunAsConfiguration;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Run As Profiles node translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim]    19APR06 Created
            ///     [kellymor] 01AUG08 Modified to retrieve resource from MP on OM and from
            ///                        product assembly on SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewRunAsProfiles
            {
                get
                {
                    if ((cachedAdminTreeViewRunAsProfiles == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedAdminTreeViewRunAsProfiles =
                                Core.Common.Utilities.GetViewName(
                                    Core.Console.Views.Views.Strings.ResourceRunAsProfilesViewTitle);
                        }
                    }

                    return cachedAdminTreeViewRunAsProfiles;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Create a new distributed application... translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 18MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuCreateNewDistributedApplication
            {
                get
                {
                    if ((cachedContextMenuCreateNewDistributedApplication == null))
                    {
                        cachedContextMenuCreateNewDistributedApplication = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuCreateNewDistributedApplication);
                    }

                    return cachedContextMenuCreateNewDistributedApplication;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add to favorites... translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuAddToFavorites
            {
                get
                {
                    if ((cachedContextMenuAddToFavorites == null))
                    {
                        cachedContextMenuAddToFavorites = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuAddToFavorites);
                    }

                    return cachedContextMenuAddToFavorites;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Saved Searches node translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SavedSearchesNode
            {
                get
                {
                    if ((cachedSavedSearchesNode == null))
                    {
                        cachedSavedSearchesNode = CoreManager.MomConsole.GetIntlStr(ResourceSavedSearchesNode);
                    }

                    return cachedSavedSearchesNode;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Favorite Views node translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FavoriteViewsNode
            {
                get
                {
                    if ((cachedFavoriteViewsNode == null))
                    {
                        cachedFavoriteViewsNode = CoreManager.MomConsole.GetIntlStr(ResourceFavoriteViewsNode);
                    }

                    return cachedFavoriteViewsNode;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monitoring Configuration-->Management Pack Objects--> Attributes Node translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 12APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonConfigTreeViewAttributes
            {
                get
                {
                    if ((cachedMonConfigTreeViewAttributes == null))
                    {
                        cachedMonConfigTreeViewAttributes = CoreManager.MomConsole.GetIntlStr(ResourceMonConfigTreeViewAttributes);
                    }

                    return cachedMonConfigTreeViewAttributes;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextMenuCreateManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 18SEP06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuCreateManagementPack
            {
                get
                {
                    if ((cachedContextMenuCreateManagementPack == null))
                    {
                        cachedContextMenuCreateManagementPack = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuCreateManagementPack);
                    }

                    return cachedContextMenuCreateManagementPack;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LinkLabelNewViews translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 05APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LinkLabelNewViews
            {
                get
                {
                    if ((cachedLinkLabelNewViews == null))
                    {
                        cachedLinkLabelNewViews = CoreManager.MomConsole.GetIntlStr(ResourceLinkLabelNewViews);
                    }

                    return cachedLinkLabelNewViews;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Connected Management Groups node translated
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15APR08 Created
            ///     [kellymor] 01AUG08 Modified to retrieve resource from MP on OM and from
            ///                        product assembly on SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewConnectedManagementGroups
            {
                get
                {
                    if ((cachedAdminTreeViewConnectedManagementGroups == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedAdminTreeViewConnectedManagementGroups =
                                Core.Common.Utilities.GetViewName(
                                    Core.Console.Views.Views.Strings.ResourceConnectedManagementGroupsViewTitle);
                        }
                    }

                    return cachedAdminTreeViewConnectedManagementGroups;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextMenuAddManagementGroup translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 15APR08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuAddManagementGroup
            {
                get
                {
                    if ((cachedContextMenuAddManagementGroup == null))
                    {
                        cachedContextMenuAddManagementGroup = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceContextMenuAddManagementGroup);
                    }

                    return cachedContextMenuAddManagementGroup;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Product Connectors node translated
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 09MAY08 Created
            ///     [kellymor] 01AUG08 Modified to retrieve resource from MP on OM and from
            ///                        product assembly on SCE
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewProductConnectors
            {
                get
                {
                    if ((cachedAdminTreeViewProductConnectors == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedAdminTreeViewProductConnectors =
                                Core.Common.Utilities.GetViewName(
                                    Core.Console.Views.Views.Strings.ResourceProductConnectersViewTitle);
                        }
                    }

                    return cachedAdminTreeViewProductConnectors;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Rename cntext menu translated
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 09MAY08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RenameContextMenu
            {
                get
                {
                    if ((cachedRenameContextMenu == null))
                    {
                        cachedRenameContextMenu = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceRenameContextMenu);
                    }

                    return cachedRenameContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Properties context menu in the Monitoring 
            /// space translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 01AUG08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitoringContextMenuProperties
            {
                get
                {
                    if ((cachedMonitoringContextMenuProperties == null))
                    {
                        cachedMonitoringContextMenuProperties = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceMonitoringContextMenuProperties);
                    }

                    return cachedMonitoringContextMenuProperties;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminTreeViewChannelsView translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 07AUG08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewChannelsView
            {
                get
                {
                    if ((cachedAdminTreeViewChannelsView == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedAdminTreeViewChannelsView =
                                Core.Common.Utilities.GetViewName(
                                    Core.Console.Views.Views.Strings.ResourceChannelsViewTitle);
                        }
                    }

                    return cachedAdminTreeViewChannelsView;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminTreeViewResourcePoolView translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 07AUG08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminTreeViewResourcePoolsView
            {
                get
                {
                    if ((cachedAdminTreeViewResourcePoolsView == null))
                    {
                        // if product is Operations Manager
                        if (ProductSku.Sku == ProductSkuLevel.Mom)
                        {
                            // use resource from management pack
                            cachedAdminTreeViewResourcePoolsView =
                                Core.Common.Utilities.GetViewName(
                                    Core.Console.Views.Views.Strings.ResourceResourcePoolsViewTitle);
                        }
                    }

                    return cachedAdminTreeViewResourcePoolsView;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Properties context menu in the Monitoring 
            /// space translated resource string
            /// </summary>
            /// <history>
            /// 	[v-yoz] 25DEC08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitoringDiscoveredInventory
            {
                get
                {
                    if ((cachedMonitoringDiscoveredInventory == null))
                    {
                        cachedMonitoringDiscoveredInventory = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceMonitoringDiscoveredInventory);
                    }

                    return cachedMonitoringDiscoveredInventory;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MsaaStates.Checked state text translated resource string
            /// </summary>
            /// <history>
            /// 	[Ruhim] 16Feb09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MsaaStatesCheckedText
            {
                get
                {
                    if ((cachedMsaaStatesChecked == null))
                    {
                        cachedMsaaStatesChecked = CoreManager.MomConsole.GetIntlStr(ResourceMsaaStatesChecked);
                    }

                    return cachedMsaaStatesChecked;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public static string ExpandCollapseButton
            {
                get
                {
                    return ResourceExpandCollapseButton;
                }
            }

            /// <summary>
            /// OptionsButton String
            /// </summary>
            public static string OptionsButton
            {
                get { return ResourceOptionsButton; }
            } 


            /// <summary>
            /// NavigationTreeView string
            /// </summary>
            public static string NavigationTreeView
            {
                get 
                {
                    switch (ProductSku.Sku)
                    {
                        case ProductSkuLevel.Mom:
                            cachedNavigationTreeView = CoreManager.MomConsole.GetIntlStr(ResourceNavigationTreeViewDeskTop);
                            break;
                        case ProductSkuLevel.Web:
                            cachedNavigationTreeView = CoreManager.MomConsole.GetIntlStr(ResourceNavigationTreeViewWeb);
                            break;
                        default:
                            break;
                    }
                    return cachedNavigationTreeView;
                }
            }

            /// <summary>
            /// NavigationPane string
            /// </summary>
            public static string NavigationPaneQID
            {
                get
                {
                    if ((cachedNavPaneQID == null))
                    {
                        //if product is Operations Manager
                        switch (ProductSku.Sku)
                        {

                            case ProductSkuLevel.Mom:
                                cachedNavPaneQID = CoreManager.MomConsole.GetIntlStr(ResourceNavPaneForDeskTop);
                                break;
                            case ProductSkuLevel.Web:
                                cachedNavPaneQID = CoreManager.MomConsole.GetIntlStr(ResourceNavPaneForWeb);
                                break;
                            default:
                                break;
                        }

                    }
                    return cachedNavPaneQID;
                }
            }
            #endregion

            #region ServiceDesigner
            #region Constants
            /// <summary>
            /// Contains resource string for Monitoring Configuration Services Node
            /// </summary>
            private const string ResourceMonConfigTreeViewServices =
                ";Distributed Applications;ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.MonitoringConfiguration.MonitoringConfigurationPageResources;ServicesNode";

            /// <summary>
            /// Contains resource string for Service Actions node
            /// </summary>
            private const string ResourceActionServices =
                ";Service;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.ServicesView.ServicesResources;ServicesTaskGroup";

            /// <summary>
            /// Contains resource string for Action node that creates a new service
            /// </summary>
            private const string ResourceActionCreateANewService =
                ";Create a new service;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.ServicesView.ServicesResources;ServiceCreateTask";

            /// <summary>
            /// Edit option on the Action pane
            /// </summary>
            private const string ResourceActionEditService =
                ";Edit;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.ServicesView.ServicesResources;ServiceEditTask";

            /// <summary>
            /// Edit option on the grid's context menu
            /// </summary>
            private const string ResourceEditServiceContextMenu =
                ";&Edit...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.ServicesView.ServicesResources;ServiceEditTask";
                // TODO: The resource below appears to no longer exist... replacing with the above resource. Remove when we are sure this is no longer necessary.
                // ";E&dit...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.ServicesView.ServicesResources;ServiceEditContextMenuTask";
            
            #endregion

            #region Private members
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Monitoring Configuration Services Node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonConfigTreeViewServices;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Services Actions node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedActionServices;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Create a new service Actions node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedActionCreateANewService;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Edit a service Actions node
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedActionEditService;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Edit a service using the context menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEditServiceContextMenu;

            /// <summary>
            /// Cache to hold a reference to ExpandCollapseButton
            /// </summary>
            private Button cachedExpandCollapseButton;
            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 15MAR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonConfigTreeViewServices
            {
                get 
                {
                    if ((Strings.cachedMonConfigTreeViewServices == null)) 
                    {
                        cachedMonConfigTreeViewServices = CoreManager.MomConsole.GetIntlStr(
                            ResourceMonConfigTreeViewServices);
                    }

                    return Strings.cachedMonConfigTreeViewServices;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 15MAR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ActionServices 
            {
                get 
                {
                    if ((Strings.cachedActionServices == null)) 
                    {
                        cachedActionServices = CoreManager.MomConsole.GetIntlStr(
                            ResourceActionServices);
                    }

                    return Strings.cachedActionServices;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 15MAR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ActionCreateANewService 
            {
                get 
                {
                    if ((Strings.cachedActionCreateANewService == null)) 
                    {
                        cachedActionCreateANewService = CoreManager.MomConsole.GetIntlStr(
                            ResourceActionCreateANewService);
                    }

                    return Strings.cachedActionCreateANewService;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the translated resource string
            /// </summary>
            /// <history>
            /// 	[mcorning] 27MAR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ActionEditService 
            {
                get 
                {
                    if ((Strings.cachedActionEditService == null)) 
                    {
                        cachedActionEditService = CoreManager.MomConsole.GetIntlStr(
                            ResourceActionEditService);
                    }

                    return Strings.cachedActionEditService;
                }
            }

            /// <summary>
            /// Context menu Edit service option
            /// </summary>
            public static string EditServiceContextMenu
            {
                get 
                {
                    if ((Strings.cachedEditServiceContextMenu == null))
                    {
                        cachedEditServiceContextMenu = CoreManager.MomConsole.GetIntlStr(
                            ResourceEditServiceContextMenu);
                    }

                    return Strings.cachedEditServiceContextMenu;
                }
            }       
                                
            #endregion
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
            /// Control ID for NavigationPanel 
            /// </summary>
            public const string NavigationPanel = "NavigationPanel";
            
            /// <summary>
            /// Control ID for NavigationPaneTitleStaticControl
            /// </summary>
            public const string NavigationPaneTitleStaticControl = "ViewTitle";

            /// <summary>
            /// Control ID for NavigationPaneSplitter
            /// </summary>
            public const string NavigationPaneSplitter = "NavigationSplitter";

            /// <summary>
            /// Control ID for WunderBar
            /// </summary>
            public const string WunderBarControl = "outlookBarControl";

            /// <summary>
            /// Control ID for  Monitoring TreeView
            /// </summary>
            public const string MonitoringTreeView = "treeView";

            /// <summary>
            /// Control ID for  Monitoring Configuration TreeView
            /// </summary>
            public const string MonitoringConfigurationTreeView = "folderTreeView";

            /// <summary>
            /// Control ID for Software TreeView
            /// </summary>
            public const string SoftwareTreeView = "viewsTree";

            /// <summary>
            /// Control ID for Updates TreeView
            /// </summary>
            public const string UpdatesTreeView = "viewsTree";
            
            /// <summary>
            /// Control ID for Computers TreeView
            /// </summary>
            public const string ComputersTreeView = "computerGroupsTreeView";
        }
        #endregion
    }
}
