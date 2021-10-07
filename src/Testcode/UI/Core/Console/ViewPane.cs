// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ViewPane.cs">
//  Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
//  MOMv3
// </project>
// <summary>
//  View Pane methods
// </summary>
// <history>
//  [mbickle] 10AUG05: Created
//  [kellymor]15AUG05: Added a Strings class with context menus for the 
//                     Administration grid views.
//  [kellymor]18AUG05: Added resource strings for confirmation dialog to stop
//                     Agentless management.
//  [kellymor]09SEP05: Moved SomDiagram from ConsoleApp to ViewPane
//  [kellymor]14SEP05: Updated resource for agentless delete dialog title
//  [barryw]  18SEP05: Added AdministrationContextMenuRefresh.
//  [kellymor]02MAR06: Modified resource string for confirm stop agentless
//                     monitoring
//  [kellymor]12APR06: Updated resource strings from IP Address column and
//                     Confirm Delete Network Device dialog
//  [kellymor]24APR06: Added resource string for FQDN column in Admin views
//  [kellymor]20JUN06: Added resource string for "Action Account" in
//                     "Run As Accounts" grid view
//  [kellymor]18OCT06: Added property for reports ListView control
//  [kellymor]26OCT06: Updated resource string for "Properties" context menu
//                     Updated resource string for "Refresh" context menu
//  [visnara] 27OCT06: Added support for changing console scope
//  [kellymor]17NOV06: Updated resource string for "Properties" context menu
//  [visnara] 26DEC2006: Added CtrlIDs for dashboard view support
//  [kellymor]01NOV2007: Fixed "off-by-one" error in GetViewPaneContextMenu
//  [kellymor]06NOV2007: Added Administration space resource strings for the
//                       Device Management view column headers
//                       Fixed StyleCop issues
//                       Modified resource string constant formatting for easy
//                       search and replace
//  [kellymor]08FEB08: Added separate string property for admin views Open
//                     context menu
//  [KellyMor]08APR08: Added context menu resources for Approve and Reject
//                     Added resources for task title and description
//  [v-liqluo]02SEP09: Added ControlID for Subscription ListView of Reporting
//  [rahsing] 08DEC15: Added ControlID for Updates and Recommendations List view
// </history>
// ----------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Common;
    #endregion

    #region Interfaces
    /// <summary>
    /// Console ViewPane Interface
    /// </summary>
    public interface IViewPane
    {
        /// <summary>
        /// Gets Read-only property to access ViewPaneTitleStaticControl
        /// </summary>
        StaticControl ViewPaneTitleStaticControl
        {
            get;
        }

        /// <summary>
        /// Gets Change Scope
        /// </summary>
        StaticControl ChangeScope
        {
            get;
        }

        /// <summary>
        /// Gets Controls
        /// </summary>
        IViewPane Controls
        {
            get;
        }

        /// <summary>
        /// Gets Find Bar
        /// </summary>
        MomControls.FindBar Find
        {
            get;
        }

        /// <summary>
        /// Gets Grid Control
        /// </summary>
        MomControls.GridControl GridControl
        {
            get;
        }

        /// <summary>
        /// Gets Html Document
        /// </summary>
        Maui.Core.HtmlDocument HtmlDocument
        {
            get;
        }

        /// <summary>
        /// Gets Is Visible
        /// </summary>
        bool IsVisible
        {
            get;
        }

        /// <summary>
        /// Gets Reports List View
        /// </summary>
        ListView ReportsListView
        {
            get;
        }

        /// <summary>
        /// Gets Splitter
        /// </summary>
        ActiveAccessibility Splitter
        {
            get;
        }

        /// <summary>
        /// Gets Title
        /// </summary>
        string Title
        {
            get;
        }
    }
    #endregion

    /// ------------------------------------------------------------------
    /// <summary>
    /// View Pane Class
    /// </summary>
    /// <history>
    /// 	[mbickle] 10AUG05 Created
    ///		[kellymor]15AUG05 Added a Strings class with context menus for the 
    ///						  Administration grid views.
    ///		[kellymor]18AUG05 Added resource strings for confirmation dialog to stop
    ///						  Agentless management.
    ///     [kellymor]09SEP05 Moved SomDiagram from ConsoleApp to ViewPane
    ///     [kellymor]14SEP05 Updated resource for agentless delete dialog title
    ///     [mbickle] 01MAY06 Added HtmlDocument property
    /// </history>
    /// ------------------------------------------------------------------
    public class ViewPane : Window, IViewPane
    {
        #region Private Members
        /// <summary>
        /// View Pane Console Window Handle
        /// </summary>
        private static IntPtr cachedViewPaneWindowHwnd;

        /// <summary>
        /// Cached Change Scope
        /// </summary>
        private StaticControl cachedChangeScope;

        /// <summary>
        /// Cached Som Diagram
        /// </summary>
        private MomControls.Diagram cachedSomDiagram;

        /// <summary>
        /// Cached Dash View 1
        /// </summary>
        private StaticControl cachedDashView1;

        /// <summary>
        /// Cached Dash View 2
        /// </summary>
        private StaticControl cachedDashView2;

        /// <summary>
        /// Cached Dash View 3
        /// </summary>
        private StaticControl cachedDashView3;

        /// <summary>
        /// Cached Dash View 4
        /// </summary>
        private StaticControl cachedDashView4;

        /// <summary>
        /// Cached Dash View 5
        /// </summary>
        private StaticControl cachedDashView5;

        /// <summary>
        /// Cached Dash View 6
        /// </summary>
        private StaticControl cachedDashView6;

        /// <summary>
        /// Cached Dash View 7
        /// </summary>
        private StaticControl cachedDashView7;

        /// <summary>
        /// Cached Dash View 8
        /// </summary>
        private StaticControl cachedDashView8;

        /// <summary>
        /// Cached Dash View 9
        /// </summary>
        private StaticControl cachedDashView9;

        //private const int timeout = 6000;

        #endregion // Private Members

        #region Constructor
        /// ------------------------------------------------------------------
        /// <summary>
        /// ViewPane Window
        /// </summary>
        /// <param name="app">ConsoleApp</param>
        /// ------------------------------------------------------------------
        public ViewPane(ConsoleApp app) :
            base(app.MainWindow, new QID(";[UIA, VisibleOnly]AutomationId = '" + ViewPane.ControlIDs.ViewPane + "'"), Core.Common.Constants.DefaultDialogTimeout)
        {
            Utilities.LogMessage("ViewPane:: Constructor");
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// ViewPane Window
        /// </summary>
        /// <param name="window">Window</param>
        /// ------------------------------------------------------------------
        public ViewPane(Window window) :
            base(GetWindowHwnd(window))
        {
            Utilities.LogMessage("ViewPane:: Constructor");
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// ViewPane Window
        /// </summary>
        /// <param name="queryId">QueryId</param>
        /// <param name="timeout">Timeout in milliseconds</param>
        /// ------------------------------------------------------------------
        public ViewPane(QID queryId, int timeout) :
            base(queryId, timeout)
        {
            Utilities.LogMessage("ViewPane:: Constructor");
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// ViewPane Window
        /// </summary>
        /// <param name="parentWindow">Parent Window</param>
        /// <param name="queryId">QueryId</param>
        /// <param name="timeout">Timeout in milliseconds</param>
        /// ------------------------------------------------------------------
        public ViewPane(Window parentWindow, QID queryId, int timeout) :
            base(parentWindow, queryId, timeout)
        {
            Utilities.LogMessage("ViewPane:: Constructor");
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
        /// Access to the ViewPane Splitter Bar NYI: Bug# 54684
        /// </summary>
        /// ------------------------------------------------------------------
        public ActiveAccessibility Splitter
        {
            get
            {
                return this.NextSibling.Extended.AccessibleObject;

                // Will need to change this when bug# 54624 is fixed.
                // return CoreManager.MomConsole.MainWindow.Extended.AccessibleObject.FindChild(ControlIDs.ViewPaneSplitter);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Get the ViewTitle of the currently loaded view.
        /// </summary>
        /// <returns>View Title String</returns>
        /// <history>
        /// [mbickle] 01AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public string Title
        {
            get
            {
                return CoreManager.MomConsole.GetStaticControlCaption(this.Controls.ViewPaneTitleStaticControl).Trim();
            }
        }
        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Reports ListView control
        /// </summary>
        /// ------------------------------------------------------------------
        public ListView ReportsListView
        {
            get
            {
                return new Maui.Core.WinControls.ListView(this, ControlIDs.ViewPaneListViewReports);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets reference to the GridControl in the View
        /// </summary>
        /// ------------------------------------------------------------------
        public MomControls.GridControl Grid
        {
            get
            {
                this.ScreenElement.WaitForReady();

                MomControls.GridControl grid =
                  new MomControls.GridControl(
                     this,
                     MomControls.GridControl.ControlIDs.ViewPaneGrid);

                int loop = 0;
                while (loop++ <= Constants.DefaultViewLoadTimeout)
                {
                    Sleeper.Delay(Constants.OneSecond);

                    if (!grid.ScreenElement.IsValid)
                        grid = new MomControls.GridControl(this, MomControls.GridControl.ControlIDs.ViewPaneGrid);

                    if (grid.ScreenElement.IsVisible)
                    {
                        return grid;
                    }
                }

                throw new Maui.GlobalExceptions.TimedOutException("Get GridControl timeout.");
            }
        }
        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets reference to the GridControl in the View
        /// </summary>
        /// ------------------------------------------------------------------
        public MomControls.GridControl GridControl
        {
            get
            {
                return new MomControls.GridControl(
                    this,
                    MomControls.GridControl.ControlIDs.ViewPaneGrid);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets refrence to the HtmlDocument in View Pane 
        /// For Overview Pages and URL View.
        /// </summary>
        /// ------------------------------------------------------------------
        public HtmlDocument HtmlDocument
        {
            get
            {
                Window wndTemp = new Window(
                    "",
                    StringMatchSyntax.WildCard,
                    WindowClassNames.InternetExplorerServer,
                    StringMatchSyntax.ExactMatch,
                    this.AccessibleObject.Window,
                    30000);

                HtmlDocument htmlDocument = new HtmlDocument(wndTemp);
                return htmlDocument;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets reference to the GridControl in the View
        /// </summary>
        /// ------------------------------------------------------------------
        public MomControls.FindBar Find
        {
            get
            {
                MomControls.FindBar findBar = null;
                int retryFind = 10;

                //Add retry logic to make sure FindBar is available in UI. 
                for (int i = 0; i < retryFind && findBar == null; i++)
                {
                    try
                    {
                        Utilities.LogMessage("Find::if the FindBar display in UI , return it.");
                        CoreManager.MomConsole.Waiters.WaitForWindowAppeared(CoreManager.MomConsole.MainWindow, new QID(";[UIA]Automation = '" + ControlIDs.ViewPaneFindBar + "'"),ConsoleConstants.DefaultDialogTimeout);
                        findBar = new MomControls.FindBar(this, ControlIDs.ViewPaneFindBar);
                        Utilities.TakeScreenshot("Before_click_FinBar_Attempt" + i);
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        try
                        {
                            MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;
                            Sleeper.Delay(Core.Common.Constants.OneSecond);

                            if (viewGrid != null)
                            {
                                viewGrid.Click();
                                viewGrid.WaitForResponse();
                            }

                            //Click Find button to show the FindBar
                            Utilities.LogMessage("Find:: Findbar does not display in UI, click Find Button in tool bar to make it show.");
                            Maui.Core.WinControls.Button findButton =
                            new Button(CoreManager.MomConsole.MainWindow, new Maui.Core.QID(";[UIA]Name = \'" + Core.Console.ConsoleApp.Strings.FindButtonText + "\' && Role = 'push button'"), 6000);

                            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(findButton);
                            findButton.Click();

                            Utilities.LogMessage("Find:: Sleep five second to wait FindNowButton Ready.");
                            Sleeper.Delay(Core.Common.Constants.OneSecond * 5);
                            Utilities.TakeScreenshot("After_click_FinBar_Attempt" + i);
                        }
                        catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                        {
                            Utilities.LogMessage("Find:: Failed to Find Button in tool bar.");
                        }
                        catch (Exception e)
                        {
                            Utilities.LogMessage("Find:: "+e.Message);                            
                        }
                    }
                    catch (System.InvalidOperationException)
                    {
                        Utilities.LogMessage("Find: UI is still in loading, will wait one second, and retry.");
                        Sleeper.Delay(Core.Common.Constants.OneSecond);
                    }
                    catch (Exception e)
                    {
                        Utilities.LogMessage("Find:: " + e.Message);
                    }
                }

                if (findBar == null)
                {
                    throw new Maui.Core.Window.Exceptions.WindowNotFoundException("Failed to find FindBar finally.");
                }
                return findBar;
            }
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the SOM Diagram control
        /// </summary>
        /// ------------------------------------------------------------------
        public MomControls.Diagram SomDiagram
        {
            get
            {
                if (this.cachedSomDiagram == null)
                {
                    this.cachedSomDiagram = new MomControls.Diagram(this, MomControls.Diagram.ControlIDs.Monitoring);
                }

                return this.cachedSomDiagram;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Workload ListView control
        /// </summary>
        /// ------------------------------------------------------------------
        public ListView ListViewWorkloads
        {
            get
            {
                return new Maui.Core.WinControls.ListView(this, ControlIDs.ViewPaneListViewWorkloads);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Reports ListView control
        /// </summary>
        /// ------------------------------------------------------------------
        public ListView ListViewReports
        {
            get
            {
                return new Maui.Core.WinControls.ListView(this, ControlIDs.ViewPaneListViewReports);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Subscription ListView control
        /// </summary>
        /// ------------------------------------------------------------------
        public ListView ListViewSubscriptionList
        {
            get
            {
                return new ListView(this, ControlIDs.ViewPaneListViewSubscriptionList);
            }
        }
        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Change Scope StaticControl
        /// </summary>
        /// ------------------------------------------------------------------
        public StaticControl ChangeScope
        {
            get
            {
                if (this.cachedChangeScope == null)
                {
                    this.cachedChangeScope = new StaticControl(this, ControlIDs.ChangeScopeStaticControl);
                }

                return this.cachedChangeScope;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Dashview1 StaticControl
        /// </summary>
        /// ------------------------------------------------------------------
        public StaticControl DashView1
        {
            get
            {
                if (this.cachedDashView1 == null)
                {
                    this.cachedDashView1 = new StaticControl(this, ControlIDs.ClickToAddAViewStaticControl);
                }

                return this.cachedDashView1;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Dashview2 StaticControl
        /// </summary>
        /// ------------------------------------------------------------------
        public StaticControl DashView2
        {
            get
            {
                if (this.cachedDashView2 == null)
                {
                    this.cachedDashView2 = new StaticControl(this, ControlIDs.ClickToAddAViewStaticControl2);
                }

                return this.cachedDashView2;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Dashview3 StaticControl
        /// </summary>
        /// ------------------------------------------------------------------
        public StaticControl DashView3
        {
            get
            {
                if (this.cachedDashView3 == null)
                {
                    this.cachedDashView3 = new StaticControl(this, ControlIDs.ClickToAddAViewStaticControl3);
                }

                return this.cachedDashView3;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Dashview4 StaticControl
        /// </summary>
        /// ------------------------------------------------------------------
        public StaticControl DashView4
        {
            get
            {
                if (this.cachedDashView4 == null)
                {
                    this.cachedDashView4 = new StaticControl(this, ControlIDs.ClickToAddAViewStaticControl4);
                }

                return this.cachedDashView4;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Dashview5 StaticControl
        /// </summary>
        /// ------------------------------------------------------------------
        public StaticControl DashView5
        {
            get
            {
                if (this.cachedDashView5 == null)
                {
                    this.cachedDashView5 = new StaticControl(this, ControlIDs.ClickToAddAViewStaticControl5);
                }

                return this.cachedDashView5;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Dashview6 StaticControl
        /// </summary>
        /// ------------------------------------------------------------------
        public StaticControl DashView6
        {
            get
            {
                if (this.cachedDashView6 == null)
                {
                    this.cachedDashView6 = new StaticControl(this, ControlIDs.ClickToAddAViewStaticControl6);
                }

                return this.cachedDashView6;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Dashview7 StaticControl
        /// </summary>
        /// ------------------------------------------------------------------
        public StaticControl DashView7
        {
            get
            {
                if (this.cachedDashView7 == null)
                {
                    this.cachedDashView7 = new StaticControl(this, ControlIDs.ClickToAddAViewStaticControl7);
                }

                return this.cachedDashView7;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Dashview8 StaticControl
        /// </summary>
        /// ------------------------------------------------------------------
        public StaticControl DashView8
        {
            get
            {
                if (this.cachedDashView8 == null)
                {
                    this.cachedDashView8 = new StaticControl(this, ControlIDs.ClickToAddAViewStaticControl8);
                }

                return this.cachedDashView8;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the Dashview9 StaticControl
        /// </summary>
        /// ------------------------------------------------------------------
        public StaticControl DashView9
        {
            get
            {
                if (this.cachedDashView9 == null)
                {
                    this.cachedDashView9 = new StaticControl(this, ControlIDs.ClickToAddAViewStaticControl9);
                }

                return this.cachedDashView9;
            }
        }

        #endregion

        #region IViewPane Controls Property

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the app. window's control properties together</value>
        /// <history>
        /// 	[mbickle] 10AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public virtual IViewPane Controls
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
        ///  Exposes access to the DetailPaneTitleStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        StaticControl IViewPane.ViewPaneTitleStaticControl
        {
            get
            {
                return new StaticControl(this, new QID(";[UIA]AutomationId='" + ControlIDs.ViewPaneTitleStaticControl + "'"));
            }
        }

        #endregion

        #region Public Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// This method uses defaults to search for a 
        /// specific value in a specific column in the view pane's
        /// grid and invokes the context menu for the cell in 
        /// which the said value resides.
        /// </summary>
        /// <param name="searchData">The value in the grid's cell to search for</param>
        /// <param name="columnName">The name of the column to search</param>
        /// <returns>Context menu for the cell in the grid</returns>
        /// <example>
        ///    // Example of deleting a Management Pack using the MP View.
        ///    ViewPane mpViewPane = new ViewPane(CoreManager.MomConsole);
        ///    Maui.Core.WinControls.Menu contextmenu =
        ///        mpViewPane.GetViewPaneContextMenu(
        ///        managementPackName,
        ///        ViewPane.Strings.AdministrationGridViewColumnName)
        ///    contextmenu.ExecuteMenuItem(
        ///        ViewPane.Strings.AdministrationContextMenuDelete);
        /// </example>
        /// ------------------------------------------------------------------
        public Menu GetViewPaneContextMenu(
            string searchData,
            string columnName)
        {
            const int OneSearchRetry = 1;
            Menu contextmenu = this.GetViewPaneContextMenu(
                searchData,
                columnName,
                OneSearchRetry,
                Constants.DefaultContextMenuTimeout);
            return contextmenu;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// This method searches for a specific value in a specific 
        /// column in the view pane's grid and invokes the context 
        /// menu for the cell in which the said value resides.
        /// </summary>
        /// <param name="searchData">The value in the grid's cell to search for</param>
        /// <param name="columnName">The name of the column to search</param>
        /// <param name="searchRetries">
        /// Number of times to retry the search through the list.</param>
        /// <param name="menuDisplayTimeout">The time, in millseconds, to wait
        ///  for the context menu to display</param>
        /// <returns>Context menu for the cell in the grid</returns>
        /// <example>
        ///    // Example of deleting a Management Pack using the MP View.
        ///    ViewPane mpViewPane = new ViewPane(CoreManager.MomConsole);
        ///    Maui.Core.WinControls.Menu contextmenu =
        ///        mpViewPane.GetViewPaneContextMenu(
        ///        managementPackName,
        ///        ViewPane.Strings.AdministrationGridViewColumnName,
        ///        OneSearchRetry,
        ///        Constants.DefaultContextMenuTimeout);
        ///    contextmenu.ExecuteMenuItem(
        ///        ViewPane.Strings.AdministrationContextMenuDelete);
        /// </example>
        /// <remarks>Replaced Maui.Core.Utilities.Sleeper because the timeout is 
        /// not working properly.</remarks>
        /// ------------------------------------------------------------------
        public Menu GetViewPaneContextMenu(
            string searchData,
            string columnName,
            int searchRetries,
            int menuDisplayTimeout)
        {
            bool refreshOnRetry = false;
            Menu contextmenu = this.GetViewPaneContextMenu(
                searchData,
                columnName,
                searchRetries,
                refreshOnRetry,
                Constants.DefaultContextMenuTimeout);
            return contextmenu;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// This method searches for a specific value in a specific 
        /// column in the view pane's grid and invokes the context 
        /// menu for the cell in which the said value resides.
        /// </summary>
        /// <param name="searchData">The value in the grid's cell to search for</param>
        /// <param name="columnName">The name of the column to search</param>
        /// <param name="searchRetries">
        /// Number of times to retry the search through the list.</param>
        /// <param name="refreshOnRetry">Refresh view for each retry</param>
        /// <param name="menuDisplayTimeout">The time, in millseconds, to wait
        ///  for the context menu to display</param>
        /// <returns>Context menu for the cell in the grid</returns>
        /// <example>
        ///    // Example of deleting a Management Pack using the MP View.
        ///    ViewPane mpViewPane = new ViewPane(CoreManager.MomConsole);
        ///    Maui.Core.WinControls.Menu contextmenu =
        ///        mpViewPane.GetViewPaneContextMenu(
        ///        managementPackName,
        ///        ViewPane.Strings.AdministrationGridViewColumnName,
        ///        OneSearchRetry,
        ///        ConsoleApp.TenSeconds
        ///        Constants.DefaultContextMenuTimeout);
        ///    contextmenu.ExecuteMenuItem(
        ///        ViewPane.Strings.AdministrationContextMenuDelete);
        /// </example>
        /// <remarks>Replaced Maui.Core.Utilities.Sleeper because the timeout is 
        /// not working properly.</remarks>
        /// ------------------------------------------------------------------
        public Menu GetViewPaneContextMenu(
            string searchData,
            string columnName,
            int searchRetries,
            bool refreshOnRetry,
            int menuDisplayTimeout)
        {
            Utilities.LogMessage("GetViewPaneContextMenu :: " +
                "Searching for: " + searchData +
                " in column: " + columnName + ".");

            bool itemExists = false;
            int loopIteration = 0;

            // Look for the row until it arrives or until it 
            // exceeds the number of retries.
            while (loopIteration < searchRetries && itemExists == false)
            {
                loopIteration += 1;
                Utilities.LogMessage("GetViewPaneContextMenu :: try number: " + loopIteration.ToString());
                DataGridViewRow gridViewRow =
                    this.Grid.FindData(
                        searchData,
                        columnName);

                // Once we have the row we can display the context menu.
                if (null != gridViewRow)
                {
                    Utilities.LogMessage("GetViewPaneContextMenu :: " +
                        "Found: " + searchData +
                        " in column: " + columnName + ".");
                    Utilities.LogMessage("GetViewPaneContextMenu :: Row index: " 
                        + gridViewRow.AccessibleObject.Index.ToString());
                    this.Grid.ClickCell(
                        gridViewRow.AccessibleObject.Index,
                        this.Grid.GetColumnTitlePosition(columnName), 
                        MouseFlags.RightButton);
                    itemExists = true;
                }
                else
                {
                    Utilities.LogMessage("GetViewPaneContextMenu :: " +
                        "Did NOT find: " + searchData +
                        " in column: " + columnName +
                        " on try number: " + loopIteration.ToString() + ".");
                    if (refreshOnRetry == true)
                    {
                        // Click on the view
                        this.Grid.Click();
                        CoreManager.MomConsole.Refresh();
                    }
                }
            }

            if (itemExists)
            {
                // Access the context menu.
                Utilities.LogMessage("GetViewPaneContextMenu :: " +
                    "Attempting to access the context menu");
                Menu contextmenu = new Menu(menuDisplayTimeout);
                Utilities.LogMessage("GetViewPaneContextMenu :: " +
                       "Returning the context menu for the selected cell.");

                return contextmenu;
            }
            else
            {
                throw new KeyNotFoundException("Unable to find the item in the view, try increasing the number of search retries.");
            }
        }
        
        /// ------------------------------------------------------------------
        /// <summary>
        /// This method changes console scope by clicking 'Change Scope' link in view pane. 
        /// It requires that the 'Change Scope' link is visible (i.e scoping already enabled) 
        /// Note: If same type is present in more than one MP, this method will include/exclude 
        /// all of those type(s) in scope as currently it doesn't check MP name for each of the types -TODO
        /// </summary>
        /// <param name="targets">Array of type ViewPane.TargetType </param>
        /// <param name="allTargets">True = Search in alltargets, False = search only in Common Targets</param>
        /// <param name="numRetries"> Number of times to retry while trying finding each target in the list.</param>
        /// ------------------------------------------------------------------
        public void ChangeConsoleScope(TargetType[] targets, bool allTargets, int numRetries)
        {
            Dialogs.ScopeMPObjectsDialog scopeDialog = null;
            try
            {
                Utilities.LogMessage("ChangeConsoleScope(...)");

                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);
                CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.OneMinute);


                if (null == targets || targets.Length < 1)
                {
                    Utilities.LogMessage("ChangeConsoleScope(...) :: Target(s) null or empty. Scope not changed.");
                    throw new NullReferenceException("ChangeConsoleScope :: Target(s) Null or empty");
                }

                Utilities.LogMessage("ChangeConsoleScope :: Clicking on Change Scope link in view pane ...");

                Maui.Core.Window infoBar =
                    new Window(CoreManager.MomConsole.MainWindow, new QID(";[UIA]AutomationId = 'InfoBar'"), 6000);
                       
                Maui.Core.WinControls.LinkLabel changeScopeLink = new LinkLabel(infoBar, new QID(";[UIA]AutomationId = 'linkLabel'"), 6000);
                //this.ChangeScope.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);

                changeScopeLink.Click();//(MouseClickType.SingleClick, MouseFlags.LeftButton);
                CoreManager.MomConsole.Waiters.WaitForStatusReady();                
                
                scopeDialog = new Dialogs.ScopeMPObjectsDialog(CoreManager.MomConsole);

                scopeDialog.Extended.SetFocus();
                Utilities.TakeScreenshot("ChangeConsoleScope_Launched");

                if (allTargets)
                {
                    Utilities.LogMessage("ChangeConsoleScope :: Selecting all targets option  ...");
                    scopeDialog.RadioGroupTargets = Mom.Test.UI.Core.Console.Dialogs.RadioGroupTargets.ViewAllTargets;
                    //UISynchronization.WaitForUIObjectReady(scopeDialog, 30000);
                    scopeDialog.ScreenElement.WaitForReady();
                    Utilities.TakeScreenshot("ChangeConsoleScope_ClickAllTargets");
                }

                foreach (TargetType t in targets)
                {
                    int retries = numRetries > 0 ? numRetries : 5;
                    int attempt = 1;
                    bool targetFound = false;
                    ////bool allTargetsFound = false;

                    while (!targetFound && (attempt <= retries))
                    {
                        Utilities.LogMessage("ChangeConsoleScope :: Attempt " + attempt + " to find target '" + t.TargetDisplayName + "' in list...");
                        Sleeper.Delay(1000);
                        foreach (ListViewItem item in scopeDialog.Controls.TypeListView.Items)
                        {
                            if (item.Text.StartsWith(t.TargetDisplayName, StringComparison.InvariantCultureIgnoreCase))
                            {
                                targetFound = true;
                                Utilities.LogMessage("ChangeConsoleScope :: Found Target '" + t.TargetDisplayName + "'");
                                if (item.Checked == t.IncludeTargetInScope)
                                {
                                    Utilities.LogMessage("ChangeConsoleScope :: Target '" + t.TargetDisplayName + "' already " + ((t.IncludeTargetInScope == true) ? "Included " : "Exclued ") + " in scope");
                                }
                                else
                                {
                                    Utilities.LogMessage("ChangeConsoleScope :: " + ((t.IncludeTargetInScope == true) ? "Including '" : "Excluding '") + t.TargetDisplayName + "' in scope");
                                    item.Select();
                                    item.Checked = t.IncludeTargetInScope;
                                }
                            }
                        }

                        attempt++;
                    }

                    if (!targetFound)
                    {
                        Utilities.LogMessage("ChangeConsoleScope :: Clicking cancel button...");
                        scopeDialog.ClickCancel();
                        CoreManager.MomConsole.WaitForDialogClose(scopeDialog, 30);
                        throw new KeyNotFoundException("Unable to find the target in scope dialog, try increasing the number of retries.");
                    }
                }

                Utilities.LogMessage("ChangeConsoleScope :: Clicking OK button...");
                scopeDialog.ClickOK();
                CoreManager.MomConsole.WaitForDialogClose(scopeDialog, 60);

                CoreManager.MomConsole.Waiters.WaitForStatusReady();
                CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.OneMinute * 2);
                UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, 30000);
                UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, 30000);

            }
            catch
            {
                throw;
            }

            /*finally
            {
                if (null != scopeDialog && scopeDialog.Extended.IsVisible)
                {
                    Utilities.LogMessage("ChangeConsoleScope... Finally clause :: Clicking cancel button...");
                    scopeDialog.ClickCancel();
                }

            }*/

        }
        #endregion
        #region Private Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// Get Hwnd for the View Pane Window.
        /// </summary>
        /// <param name="window">Window</param>
        /// <returns>Window Handle</returns>
        /// <history>
        /// [mbickle] 09APR08 - Created
        /// </history>
        /// ------------------------------------------------------------------
        private static IntPtr GetWindowHwnd(Window window)
        {
            cachedViewPaneWindowHwnd = window.ScreenElement.FindByPartialQueryId(Strings.ViewPane.ToString(), null).HWnd;

            return cachedViewPaneWindowHwnd;
        }
        #endregion

        #region Struct

        /// <summary>
        /// Target data type - struct, used in scoping
        /// </summary>
        /// <history>
        ///		[visnara] 27OCT06 Created
        /// </history>
        public struct TargetType
        {
            /// <summary>
            /// DisplayName for the Target
            /// </summary>
            public string TargetDisplayName;

            /// <summary>
            /// DisplayName for the Target MP. TODO - Currently not implemented
            /// </summary>
            public string TargetMPDisplayName;

            /// <summary>
            /// Include target in scoping? Default = false;
            /// </summary>
            public bool IncludeTargetInScope;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Overloaded constructor
            /// </summary>
            /// <history>
            /// 	[visnara] 27OCT06 Created
            /// </history>
            /// <param name="targetDisplayName">Target display name string</param>
            /// <param name="targetMPDisplayName">
            /// Target management pack display name string
            /// </param>
            /// <param name="includeTargetInScope">Include target in scope flag</param>
            /// -----------------------------------------------------------------------------
            public TargetType(string targetDisplayName, string targetMPDisplayName, bool includeTargetInScope)
            {
                this.TargetDisplayName = targetDisplayName;
                this.TargetMPDisplayName = targetMPDisplayName;
                this.IncludeTargetInScope = includeTargetInScope;
            }
        }

        #endregion // Struct

        #region Strings Class

        /// ------------------------------------------------------------------
        /// <summary>
        /// Updated string definitions.
        /// </summary>
        /// <history>
        /// 	[kellymor]15AUG05 Created
        ///						  Added resource strings for device managment views grid
        ///						  context menus.
        ///		[kellymor]18AUG05 Added resource strings for confirmation dialog to stop
        ///						  Agentless management.
        ///     [kellymor]14SEP05 Updated resource for agentless delete dialog title
        ///     [kellymor]12APR06 Updated resource for IP Address column name
        ///                       Added resource for Confirm Delete Network
        ///                       Device dialog
        ///     [kellymor]20JUN06 Added resource string for "Action Account" in
        ///                       "Run As Accounts" grid view
        /// </history>
        /// ------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewsContextMenu
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceContextMenuOpen =
                ";Views" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";ViewMenuItemText";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Event View ContextMenu
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceContextMenuViewsEventView =
                ";&Event View" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";CommandJumpToEventView";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Alert View ContextMenu
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceContextMenuViewsAlertView =
                ";&Alert View" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";CommandJumpToAlertView";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Performance View ContextMenu
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceContextMenuViewsPerformanceView =
                ";&Performance View" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";CommandJumpToPerformanceView";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Diagram View ContextMenu
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceContextMenuViewsDiagramView =
                ";&Diagram View" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";CommandJumpToDiagramView";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  State View ContextMenu
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceContextMenuViewsStateView =
                ";&State View" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";CommandJumpToStateView";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministrationContextMenuOpen
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceAdministrationContextMenuOpen =
                ";&Open" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources" +
                ";OpenMenuText";
            
            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministrationContextMenuRefresh
            /// </summary>
            /// <history>
            /// [KellyMor]  26OCT06 - ";Refresh;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ViewCommands;ViewRefreshViewMenuText";
            /// </history>
            /// ------------------------------------------------------------------
            private const string ResourceAdministrationContextMenuRefresh =
                ";R&efresh" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.ViewCommands" +
                ";ViewRefreshViewMenuText";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministrationContextMenuDelete
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceAdministrationContextMenuDelete =
                ";&Delete" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources" +
                ";DeleteMenuText";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministrationContextMenuProperties
            /// </summary>
            /// <history> 
            /// [KellyMor]  26OCT06 View->Properties - ";Properties;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ViewCommands;PropertiesMenuText";
            /// </history>
            /// ------------------------------------------------------------------
            private const string ResourceAdministrationContextMenuProperties =
                ";P&roperties" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.ViewCommands" +
                ";PropertiesMenuText";
                        
            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministrationContextMenuUninstall
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceAdministrationContextMenuUninstall =
                ";&Uninstall..." +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AgentUninstallMenuText";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministrationContextMenuRepair
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceAdministrationContextMenuRepair =
                ";R&epair..." +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AgentRepairMenuText";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministrationContextMenuApprove
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceAdministrationContextMenuApprove =
                ";&Approve" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";ApproveMenuText";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministrationContextMenuReject
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceAdministrationContextMenuReject =
                ";&Reject" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";RejectMenuText";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministrationConfirmStopAgentlessManagementDialogTitle
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceAdministrationConfirmStopAgentlessManagementDialogTitle =
                ";Confirm Stop Agentless Monitoring" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";AgentlessDeleteTitle";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministrationConfirmDeleteNetworkDeviceDialogTitle
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceAdministrationConfirmDeleteNetworkDeviceDialogTitle =
                ";Confirm Delete Network Device" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";NetworkDeviceDeleteTitle";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministrationGridViewColumnName
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceAdministrationGridViewColumnName =
                ";Name" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";ViewColumnName";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministrationGridViewColumnIpAddress
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceAdministrationGridViewColumnIpAddress =
                ";IP Address" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";ViewColumnIPAddress";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministrationGridViewColumnFqdnName
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceAdministrationGridViewColumnFqdnName =
                ";FQDN" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";ViewColumnFQDN";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministrationGridViewColumnActionAccount
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceAdministrationGridViewColumnActionAccount =
                ";Action Account" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";ViewColumnActionAccount";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministrationGridViewColumnViewName
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceAdministrationGridViewColumnViewName = 
                ";View Name" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";DeviceManagementNameColumn";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministrationGridViewColumnNumberOfItems
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceAdministrationGridViewColumnNumberOfItems =
                ";Number of Items" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";DeviceManagementCountColumn";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdminDetailsPaneRepairInProgress 
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceAdminDetailsPaneRepairInProgress = 
                ";Repair in Progress" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";PendingRepairAgent";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdminDetailsPaneRepairDescription 
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceAdminDetailsPaneRepairDescription = 
                ";The Operations Manager Agent on this computer is getting repaired. This may take several minutes depending on your network/computer speed." +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";PendingRepairStatus";

            /// <summary>
            /// Contains resource string for ViewPane query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewPane = ";[UIA, VisibleOnly]AutomationId = 'viewPanePanel'";
            #endregion

            #region Private Members

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewsContextMenu
            /// </summary>
            /// ------------------------------------------------------------------
            private static string cachedContextMenuOpen;

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Event View ContextMenu
            /// </summary>
            /// ------------------------------------------------------------------
            private static string cachedContextMenuViewsEventView;

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Alert View ContextMenu
            /// </summary>
            /// ------------------------------------------------------------------
            private static string cachedContextMenuViewsAlertView;

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Performance View ContextMenu
            /// </summary>
            /// ------------------------------------------------------------------
            private static string cachedContextMenuViewsPerformanceView;

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Diagram View ContextMenu
            /// </summary>
            /// ------------------------------------------------------------------
            private static string cachedContextMenuViewsDiagramView;

            /// ------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  State View ContextMenu
            /// </summary>
            /// ------------------------------------------------------------------
            private static string cachedContextMenuViewsStateView;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministrationContextMenuOpen
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationContextMenuOpen;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministrationContextMenuRefresh
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationContextMenuRefresh;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministrationContextMenuDelete
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationContextMenuDelete;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministrationContextMenuProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationContextMenuProperties;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministrationContextMenuUninstall
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationContextMenuUninstall;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministrationContextMenuRepair
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationContextMenuRepair;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministrationContextMenuApprove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationContextMenuApprove;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministrationContextMenuReject
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationContextMenuReject;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministrationConfirmStopAgentlessManagementDialogTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationConfirmStopAgentlessManagementDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministrationGridViewColumnName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationGridViewColumnName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministrationGridViewColumnIpAddress
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationGridViewColumnIpAddress;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministrationConfirmDeleteNetworkDeviceDialogTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationConfirmDeleteNetworkDeviceDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministrationGridViewColumnFqdnName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationGridViewColumnFqdnName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministrationGridViewColumnActionAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationGridViewColumnActionAccount;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministrationGridViewColumnViewName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationGridViewColumnViewName;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministrationGridViewColumnNumberOfItems
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationGridViewColumnNumberOfItems;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdminDetailsPaneRepairInProgress
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminDetailsPaneRepairInProgress;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdminDetailsPaneRepairDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdminDetailsPaneRepairDescription;

            #endregion

            #region Properties
            /// <summary>
            /// ViewPane ID
            /// </summary>
            public static string ViewPane
            {
                get
                {
                    return ResourceViewPane;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Views Context Menu translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 24APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuOpen
            {
                get
                {
                    if ((cachedContextMenuOpen == null))
                    {
                        cachedContextMenuOpen = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuOpen);
                    }

                    return cachedContextMenuOpen;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Views\Event View Context Menu translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 24APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuViewsEventView
            {
                get
                {
                    if ((cachedContextMenuViewsEventView == null))
                    {
                        cachedContextMenuViewsEventView = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuViewsEventView);
                    }

                    return cachedContextMenuViewsEventView;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Views\Alert View Context Menu translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 24APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuViewsAlertView
            {
                get
                {
                    if ((cachedContextMenuViewsAlertView == null))
                    {
                        cachedContextMenuViewsAlertView = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuViewsAlertView);
                    }

                    return cachedContextMenuViewsAlertView;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Views\Performance View Context Menu translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 24APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuViewsPerformanceView
            {
                get
                {
                    if ((cachedContextMenuViewsPerformanceView == null))
                    {
                        cachedContextMenuViewsPerformanceView = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuViewsPerformanceView);
                    }

                    return cachedContextMenuViewsPerformanceView;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Views\Diagram View Context Menu translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 24APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuViewsDiagramView
            {
                get
                {
                    if ((cachedContextMenuViewsDiagramView == null))
                    {
                        cachedContextMenuViewsDiagramView = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuViewsDiagramView);
                    }

                    return cachedContextMenuViewsDiagramView;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Views\State View Context Menu translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 24APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuViewsStateView
            {
                get
                {
                    if ((cachedContextMenuViewsStateView == null))
                    {
                        cachedContextMenuViewsStateView = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuViewsStateView);
                    }

                    return cachedContextMenuViewsStateView;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministrationContextMenuOpen translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 08FEB08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationContextMenuOpen
            {
                get
                {
                    if ((cachedAdministrationContextMenuOpen == null))
                    {
                        cachedAdministrationContextMenuOpen = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAdministrationContextMenuOpen);
                    }

                    return cachedAdministrationContextMenuOpen;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministrationContextMenuRefresh translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 18SEP05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationContextMenuRefresh
            {
                get
                {
                    if ((cachedAdministrationContextMenuRefresh == null))
                    {
                        cachedAdministrationContextMenuRefresh = CoreManager.MomConsole.GetIntlStr(ResourceAdministrationContextMenuRefresh);
                    }

                    return cachedAdministrationContextMenuRefresh;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministrationContextMenuDelete translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 15AUG05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationContextMenuDelete
            {
                get
                {
                    if ((cachedAdministrationContextMenuDelete == null))
                    {
                        cachedAdministrationContextMenuDelete = CoreManager.MomConsole.GetIntlStr(ResourceAdministrationContextMenuDelete);
                    }

                    return cachedAdministrationContextMenuDelete;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministrationContextMenuProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 15AUG05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationContextMenuProperties
            {
                get
                {
                    if ((cachedAdministrationContextMenuProperties == null))
                    {
                        cachedAdministrationContextMenuProperties = CoreManager.MomConsole.GetIntlStr(ResourceAdministrationContextMenuProperties);
                    }

                    return cachedAdministrationContextMenuProperties;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministrationContextMenuUninstall translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 15AUG05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationContextMenuUninstall
            {
                get
                {
                    if ((cachedAdministrationContextMenuUninstall == null))
                    {
                        cachedAdministrationContextMenuUninstall = CoreManager.MomConsole.GetIntlStr(ResourceAdministrationContextMenuUninstall);
                    }

                    return cachedAdministrationContextMenuUninstall;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministrationContextMenuRepair translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 15AUG05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationContextMenuRepair
            {
                get
                {
                    if ((cachedAdministrationContextMenuRepair == null))
                    {
                        cachedAdministrationContextMenuRepair = CoreManager.MomConsole.GetIntlStr(ResourceAdministrationContextMenuRepair);
                    }

                    return cachedAdministrationContextMenuRepair;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministrationContextMenuApprove translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 15AUG05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationContextMenuApprove
            {
                get
                {
                    if ((cachedAdministrationContextMenuApprove == null))
                    {
                        cachedAdministrationContextMenuApprove = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAdministrationContextMenuApprove);
                    }

                    return cachedAdministrationContextMenuApprove;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministrationContextMenuReject translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 15AUG05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationContextMenuReject
            {
                get
                {
                    if ((cachedAdministrationContextMenuReject == null))
                    {
                        cachedAdministrationContextMenuReject =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAdministrationContextMenuReject);
                    }

                    return cachedAdministrationContextMenuReject;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministrationConfirmStopAgentlessManagementDialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 18AUG05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationConfirmStopAgentlessManagementDialogTitle
            {
                get
                {
                    if ((cachedAdministrationConfirmStopAgentlessManagementDialogTitle == null))
                    {
                        cachedAdministrationConfirmStopAgentlessManagementDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceAdministrationConfirmStopAgentlessManagementDialogTitle);
                    }

                    return cachedAdministrationConfirmStopAgentlessManagementDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministrationGridViewColumnName translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 29AUG05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationGridViewColumnName
            {
                get
                {
                    if ((cachedAdministrationGridViewColumnName == null))
                    {
                        cachedAdministrationGridViewColumnName = CoreManager.MomConsole.GetIntlStr(ResourceAdministrationGridViewColumnName);
                    }

                    return cachedAdministrationGridViewColumnName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministrationGridViewColumnIpAddress translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 29AUG05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationGridViewColumnIpAddress
            {
                get
                {
                    if ((cachedAdministrationGridViewColumnIpAddress == null))
                    {
                        cachedAdministrationGridViewColumnIpAddress = CoreManager.MomConsole.GetIntlStr(ResourceAdministrationGridViewColumnIpAddress);
                    }

                    return cachedAdministrationGridViewColumnIpAddress;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministrationConfirmDeleteNetworkDeviceDialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 29AUG05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationConfirmDeleteNetworkDeviceDialogTitle
            {
                get
                {
                    if (cachedAdministrationConfirmDeleteNetworkDeviceDialogTitle == null)
                    {
                        cachedAdministrationConfirmDeleteNetworkDeviceDialogTitle = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAdministrationConfirmDeleteNetworkDeviceDialogTitle);
                    }

                    return cachedAdministrationConfirmDeleteNetworkDeviceDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministrationGridViewColumnFqdnName translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 29AUG05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationGridViewColumnFqdnName
            {
                get
                {
                    if (cachedAdministrationGridViewColumnFqdnName == null)
                    {
                        cachedAdministrationGridViewColumnFqdnName =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAdministrationGridViewColumnFqdnName);
                    }

                    return cachedAdministrationGridViewColumnFqdnName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministrationGridViewColumnActionAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 20JUN06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationGridViewColumnActionAccount
            {
                get
                {
                    if (cachedAdministrationGridViewColumnActionAccount == null)
                    {
                        cachedAdministrationGridViewColumnActionAccount =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAdministrationGridViewColumnActionAccount);
                    }

                    return cachedAdministrationGridViewColumnActionAccount;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministrationGridViewColumnViewName translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 20JUN06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationGridViewColumnViewName
            {
                get
                {
                    if (cachedAdministrationGridViewColumnViewName == null)
                    {
                        cachedAdministrationGridViewColumnViewName =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAdministrationGridViewColumnViewName);
                    }

                    return cachedAdministrationGridViewColumnViewName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministrationGridViewColumnNumberOfItemstranslated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 20JUN06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationGridViewColumnNumberOfItems
            {
                get
                {
                    if (cachedAdministrationGridViewColumnNumberOfItems == null)
                    {
                        cachedAdministrationGridViewColumnNumberOfItems =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAdministrationGridViewColumnNumberOfItems);
                    }

                    return cachedAdministrationGridViewColumnNumberOfItems;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminDetailsPaneRepairInProgress resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 08APR08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminDetailsPaneRepairInProgress
            {
                get
                {
                    if (cachedAdminDetailsPaneRepairInProgress == null)
                    {
                        cachedAdminDetailsPaneRepairInProgress =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAdminDetailsPaneRepairInProgress);
                    }

                    return cachedAdminDetailsPaneRepairInProgress;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdminDetailsPaneRepairDescription resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 08APR08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdminDetailsPaneRepairDescription
            {
                get
                {
                    if (cachedAdminDetailsPaneRepairDescription == null)
                    {
                        cachedAdminDetailsPaneRepairDescription =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAdminDetailsPaneRepairDescription);
                    }

                    return cachedAdminDetailsPaneRepairDescription;
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
        /// 	[mbickle]   10AUG05 Created
        ///     [a-joelj    28DEC09 Updated ViewPaneFindBar to correct Control ID instead of empty string ""
        /// </history>
        /// ------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ViewPane Window
            /// </summary>
            public const string ViewPane = "viewPanePanel";

            /// <summary>
            /// Control ID for ViewTitleStaticControl
            /// </summary>
            public const string ViewPaneTitleStaticControl = "ViewTitle";

            /// <summary>
            /// Control ID for ViewPaneSplitter
            /// </summary>
            public const string ViewPaneSplitter = "detailViewSplitter";

            /// <summary>
            /// Control ID for ViewPane FindBar
            /// </summary>
            public const string ViewPaneFindBar = "tableLayoutPanel1";

            /// <summary>
            /// Control ID for the Workloads ListView
            /// </summary>
            public const string ViewPaneListViewWorkloads = "UpdatesAndRecommendationsView";

            /// <summary>
            /// Control ID for the Reports ListView
            /// </summary>
            public const string ViewPaneListViewReports = "reportList";

            /// <summary>
            /// Control ID for the subscriptionList ListView
            /// </summary>
            public const string ViewPaneListViewSubscriptionList = "subscriptionList";

            /// <summary>
            /// Control ID for ChangeScopeStaticControl
            /// </summary>
            public const string ChangeScopeStaticControl = "linkLabel";

            /// <summary>
            /// Control ID for ClickToAddAViewStaticControl
            /// </summary>
            public const string ClickToAddAViewStaticControl = "setViewLinkLabel";

            /// <summary>
            /// Control ID for ClickToAddAViewStaticControl2
            /// </summary>
            public const string ClickToAddAViewStaticControl2 = "setViewLinkLabel";

            /// <summary>
            /// Control ID for ClickToAddAViewStaticControl3
            /// </summary>
            public const string ClickToAddAViewStaticControl3 = "setViewLinkLabel";

            /// <summary>
            /// Control ID for ClickToAddAViewStaticControl4
            /// </summary>
            public const string ClickToAddAViewStaticControl4 = "setViewLinkLabel";

            /// <summary>
            /// Control ID for ClickToAddAViewStaticControl5
            /// </summary>
            public const string ClickToAddAViewStaticControl5 = "setViewLinkLabel";

            /// <summary>
            /// Control ID for ClickToAddAViewStaticControl6
            /// </summary>
            public const string ClickToAddAViewStaticControl6 = "setViewLinkLabel";

            /// <summary>
            /// Control ID for ClickToAddAViewStaticControl7
            /// </summary>
            public const string ClickToAddAViewStaticControl7 = "setViewLinkLabel";

            /// <summary>
            /// Control ID for ClickToAddAViewStaticControl8
            /// </summary>
            public const string ClickToAddAViewStaticControl8 = "setViewLinkLabel";

            /// <summary>
            /// Control ID for ClickToAddAViewStaticControl9
            /// </summary>
            public const string ClickToAddAViewStaticControl9 = "setViewLinkLabel";
        }
        #endregion
    }
}
