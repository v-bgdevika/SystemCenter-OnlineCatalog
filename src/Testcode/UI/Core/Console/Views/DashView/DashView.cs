//-------------------------------------------------------------------
// <copyright file="DashView.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Dash View
// </summary>
//  <history>
//   [visnara]  26DEC06: Created   
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Views.DashView
{
    #region Using directives
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Mom.Test.UI.Core.Common;
    using Maui.Core.Utilities;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Console.GlobalSettings;
    #endregion

    #region enum
    /// <summary>
    /// Enum DashViewSize
    /// Contains options for number of views inside
    /// the dashboard view
    /// </summary>
    /// <history>
    ///		[visnara] 26DEC06 Created
    /// </history>
    public enum DashViewSize
    {
        /// <summary>
        /// 2 Views
        /// </summary>
        TwoViews,

        /// <summary>
        /// 3 Views
        /// </summary>
        ThreeViews,

        /// <summary>
        /// 4 Views
        /// </summary>
        FourViews,

        /// <summary>
        /// 5 Views
        /// </summary>
        FiveViews,

        /// <summary>
        /// 6 Views
        /// </summary>
        SixViews,

        /// <summary>
        /// 9 Views
        /// </summary>
        NineViews
    }
    #endregion

    #region DashViewParameters Class

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Dashboard View parameter class
    /// </summary>
    /// <history>
    /// 	[visnara] 12/26/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class DashViewParameters
    {
        #region private members

        /// <summary>
        /// DashView Name
        /// </summary>
        private string dashViewName = null;

        /// <summary>
        /// DashView Description
        /// </summary>
        private string dashViewDesc = null;

        /// <summary>
        /// Number of views inside DashView - enumeration
        /// </summary>
        private DashViewSize numViews;

        /// <summary>
        /// Integer containing numViews
        /// </summary>
        internal int numViewsInt = 0;

        /// <summary>
        /// Space (Monitoring/My Workspace)- enumeration
        /// </summary>
        private NavigationPane.WunderBarButton space;

        /// <summary>
        /// Path to create the dash view (including root, excluding view name)
        /// </summary>
        private string path = null;

        /// <summary>
        /// Arraylist containing the paths (from root including view name) for constituent views
        /// </summary>
        private ArrayList pathsForViewsToAdd = null;

        #endregion private members

        #region constructor

        /// <summary>
        /// Default Constructor 
        /// </summary>
        public DashViewParameters()
        {
        }

        #endregion

        #region properties

        /// <summary>
        /// DashView Name
        /// </summary>
        public string DashViewName
        {
            get
            {
                return this.dashViewName;
            }

            set
            {
                this.dashViewName = value;
            }
        }

        /// <summary>
        /// DashView Description
        /// </summary>
        public string DashViewDesc
        {
            get
            {
                return this.dashViewDesc;
            }

            set
            {
                this.dashViewDesc = value;
            }
        }

        /// <summary>
        /// Number of views inside DashView - enumeration
        /// </summary>
        public DashViewSize NumViews
        {
            get
            {
                return this.numViews;
            }

            set
            {
                this.numViews = value;
                switch (value)
                {
                    case DashViewSize.TwoViews:
                        this.numViewsInt = 2;
                        break;
                    case DashViewSize.ThreeViews:
                        this.numViewsInt = 3;
                        break;
                    case DashViewSize.FourViews:
                        this.numViewsInt = 4;
                        break;
                    case DashViewSize.FiveViews:
                        this.numViewsInt = 5;
                        break;
                    case DashViewSize.SixViews:
                        this.numViewsInt = 6;
                        break;
                    case DashViewSize.NineViews:
                        this.numViewsInt = 9;
                        break;
                }
            }
        }

        /// <summary>
        /// Space (Monitoring/My Workspace) to create dashview - enumeration
        /// </summary>
        public NavigationPane.WunderBarButton Space
        {
            get
            {
                return this.space;
            }

            set
            {
                this.space = value;
            }
        }

        /// <summary>
        /// Path to create the dash view (including root)in the specified space
        /// </summary>
        public string Path
        {
            get
            {
                return this.path;
            }

            set
            {
                this.path = value;
            }
        }

        /// <summary>
        /// Arraylist containing the paths for constituent views
        /// </summary>
        public ArrayList PathForViewsToAdd
        {
            get
            {
                return this.pathsForViewsToAdd;
            }

            set
            {
                this.pathsForViewsToAdd = value;
            }
        }

        #endregion
    }

    #endregion

    /// <summary>
    /// Dash View Helper class
    /// </summary>
    public class DashView
    {
        #region Private Members

        /// <summary>
        /// cachedCreateDashViewDialog
        /// </summary>
        private CreateDashViewDialog cachedCreateDashViewDialog;

        /// <summary>
        /// cachedSelectViewDialog
        /// </summary>
        private SelectViewDialog cachedSelectViewDialog;

        /// <summary>
        /// timeout value for dialog UIs to become ready 
        /// </summary>
        private int timeout = 20000;
        private int waitNodeTime = 10000;

        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp;

        #endregion


        #region Constructor
        /// <summary>
        /// Dash View
        /// </summary>
        public DashView()
        {
            this.consoleApp = CoreManager.MomConsole;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Create dashboard view dialog
        /// </summary>
        public CreateDashViewDialog CreateDashViewDialogWindow
        {
            get
            {
                if (this.cachedCreateDashViewDialog == null)
                {
                    this.cachedCreateDashViewDialog = new CreateDashViewDialog(CoreManager.MomConsole);
                    //UISynchronization.WaitForUIObjectReady(this.cachedCreateDashViewDialog, this.timeout);
                    this.cachedCreateDashViewDialog.WaitForResponse();
                    this.cachedCreateDashViewDialog.Extended.SetFocus();
                }

                return this.cachedCreateDashViewDialog;
            }
        }

        /// <summary>
        /// SelectView Dialog
        /// </summary>
        public SelectViewDialog SelectViewDialogWindow
        {
            get
            {
                //if (this.cachedSelectViewDialog == null)
                //{
                this.cachedSelectViewDialog = new SelectViewDialog(CoreManager.MomConsole);
                //UISynchronization.WaitForUIObjectReady(this.cachedSelectViewDialog, this.timeout);
                this.cachedSelectViewDialog.WaitForResponse();
                this.cachedSelectViewDialog.Extended.SetFocus();
                //}

                return this.cachedSelectViewDialog;
            }
        }

        #endregion

        #region Private Methods

        /// ------------------------------------------------------------------
        /// <summary>
        /// Navigate to the correct node
        /// </summary>
        /// ------------------------------------------------------------------
        public void NavigateToCorrectNode(DashViewParameters dvParams)
        {
            CoreManager.MomConsole.Waiters.WaitForStatusReady();
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

            switch (dvParams.Space)
            {
                case NavigationPane.WunderBarButton.Monitoring:
                    Utilities.LogMessage("NavigateToCorrectNode :: Clicking Monitoring Wunderbar button");
                    navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Monitoring);
                    break;
                case NavigationPane.WunderBarButton.MyWorkspace:
                    Utilities.LogMessage("NavigateToCorrectNode :: Clicking My Workspace Wunderbar button");
                    navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.MyWorkspace);
                    break;
            }

            //UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, this.timeout);
            //UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, this.timeout);
            CoreManager.MomConsole.Waiters.WaitForStatusReady(this.timeout);
            //CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, this.timeout);

            switch (dvParams.Space)
            {
                case NavigationPane.WunderBarButton.Monitoring:
                    navPane.SelectNode(dvParams.Path, NavigationPane.NavigationTreeView.Monitoring);
                    break;
                case NavigationPane.WunderBarButton.MyWorkspace:
                    navPane.SelectNode(dvParams.Path, NavigationPane.NavigationTreeView.MyWorkspace);
                    break;
            }

            CoreManager.MomConsole.Waiters.WaitForStatusReady(this.timeout);
            //UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, this.timeout);
            //UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, this.timeout);
            //CoreManager.MomConsole.Waiters.WaitForStatusReady(this.timeout);
            //CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, this.timeout);
        }

        /// <summary>
        /// Launch Create Wizard for dashview
        /// </summary>
        /// <param name="parameters">DashViewParameters</param>
        private void LaunchCreateWizard(DashViewParameters parameters)
        {
            //bool foundContextMenu = false;
            //int retry = 6;
            //int attempt = 0;
            try
            {
                Utilities.LogMessage("LaunchCreateWizard(...)");
                this.NavigateToCorrectNode(parameters);
                //while (false == foundContextMenu && attempt < retry)
                //{
                //try
                //{
                //CoreManager.MomConsole.Waiters.WaitForStatusReady(60000);

                Utilities.LogMessage("LaunchCreateWizard  :: right clicking in navtree to launch view creation wizard");
                //Maui.Core.WinControls.Menu ctxMenu = new Maui.Core.WinControls.Menu(Maui.Core.WinControls.ContextMenuAccessMethod.ShiftF10);
                //ctxMenu.WaitContextMenuWithTimeOut(this.timeout);
                Utilities.TakeScreenshot("LaunchCreateWizard_B4_Ctx_Menu");
                CoreManager.MomConsole.ExecuteContextMenu(Views.Strings.NewContextMenu + Constants.PathDelimiter + Views.Strings.DashboardViewContextMenu, true);
                Utilities.TakeScreenshot("LaunchCreateWizard_After_Ctx_Menu");
                CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, this.timeout);
                //ctxMenu.ExecuteMenuItem(Views.Strings.NewContextMenu + Constants.PathDelimiter + Views.Strings.DashboardViewContextMenu);
                //foundContextMenu = true;
                //CoreManager.MomConsole.Waiters.WaitForStatusReady(60000);
                //UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, 60000);
                //UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, 60000);
                Sleeper.Delay(this.timeout);
                //}
                //catch
                //{
                //// log the unsuccessful attempt
                //    Core.Common.Utilities.LogMessage(
                //        "LaunchCreateWizard :: Attempt " + attempt + " of " + retry + " to find ctx menu for launching create view dialog");
                //    attempt++;
                //    CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);
                //    Sleeper.Delay(this.timeout);
                // }
                // }
            }
            catch (Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException)
            {
                Utilities.LogMessage("LaunchCreateWizard :: Unable to find correct node in navpane");
                throw;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Navigates to Views view node under MPObjects in authoring space
        /// </summary>
        /// ------------------------------------------------------------------
        private void NavigateToViewsViewNode()
        {
            CoreManager.MomConsole.Waiters.WaitForStatusReady();
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            //Utilities.LogMessage("NavigateToViewsViewNode :: Clicking Authoring Wunder bar button");
            //navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Authoring);

            ////UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, this.timeout);
            ////UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, this.timeout);
            ////CoreManager.MomConsole.Waiters.WaitForStatusReady(this.timeout);
            ////CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, this.timeout);
            //CoreManager.MomConsole.Waiters.WaitForStatusReady();

            //Utilities.LogMessage("NavigateToViewsViewNode :: Clicking on MP Objects Node");
            //navPane.SelectNode(
            // NavigationPane.Strings.Authoring + Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects,
            // NavigationPane.NavigationTreeView.Authoring);

            ////UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, this.timeout);
            ////UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, this.timeout);
            ////CoreManager.MomConsole.Waiters.WaitForStatusReady(this.timeout);
            ////CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, this.timeout);
            //CoreManager.MomConsole.Waiters.WaitForStatusReady();

            Utilities.LogMessage("NavigateToViewsViewNode :: Selecting Views node under MP Objects node");
            //navPane.SelectNode(
            //  NavigationPane.Strings.Authoring + Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects +
            //  Constants.PathDelimiter + Core.Console.Views.Views.Strings.ViewDefinitionsView,
            //  NavigationPane.NavigationTreeView.Authoring,
            //  MouseFlags.LeftButton,
            //  15);
            // if Switch between monitoring and authoring is not properly rendering the navigation tree, click back to monitoring and then select authoring again

            Boolean selectNode = false;
            try
            {
                navPane.SelectNode(
                NavigationPane.Strings.Authoring + Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects +
                Constants.PathDelimiter + Core.Console.Views.Views.Strings.ViewDefinitionsView,
                NavigationPane.NavigationTreeView.Authoring,
                MouseFlags.LeftButton,
                5);
                selectNode = true;
            }
            catch (TreeNode.Exceptions.NodeNotFoundException)
            {
                Utilities.LogMessage("NavigationPane.SelectNode::Node is null click back to monitoring and select again");
                navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Monitoring);
                CoreManager.MomConsole.Waiters.WaitForStatusReady();
                if (navPane.SelectNode(
              NavigationPane.Strings.Authoring + Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewManagementPackObjects +
              Constants.PathDelimiter + Core.Console.Views.Views.Strings.ViewDefinitionsView,
              NavigationPane.NavigationTreeView.Authoring,
              MouseFlags.LeftButton,
              5) != null)
                {
                    selectNode = true;
                }

            }

            if (!selectNode)
            {
                throw new TreeNode.Exceptions.NodeNotFoundException("TreeView.ExpandTreePath:: treeNode was null after Click Back");
            }


            //UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, this.timeout);
            //UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, this.timeout);
            //CoreManager.MomConsole.Waiters.WaitForStatusReady(this.timeout);
            //CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, this.timeout);
            CoreManager.MomConsole.Waiters.WaitForStatusReady();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Create Dash View
        /// </summary>
        /// <param name="parameters">DashViewParameters</param>
        public void Create(DashViewParameters parameters)
        {
            this.LaunchCreateWizard(parameters);

            Utilities.LogMessage("Create(...)");

            this.CreateDashViewDialogWindow.Extended.SetFocus();
            this.CreateDashViewDialogWindow.WaitForResponse();
            //UISynchronization.WaitForProcessReady(this.CreateDashViewDialogWindow, this.timeout);
            //UISynchronization.WaitForUIObjectReady(this.CreateDashViewDialogWindow, this.timeout);

            //Name
            Utilities.LogMessage("Create :: Entering view name");
            this.CreateDashViewDialogWindow.NameText = parameters.DashViewName;

            //Description
            Utilities.LogMessage("Create :: Entering view desc");
            this.CreateDashViewDialogWindow.DescriptionText = parameters.DashViewDesc;

            //If there is no numViewsInt set, do not change it, leave it as default
            if (parameters.numViewsInt != 0)
            {
                //Num Views drop down
                Utilities.LogMessage("Create :: Picking # of views from dropdown");
                this.CreateDashViewDialogWindow.SpecifyTheNumberOfViewsToDisplayInTheDashboardText = Strings.NumViews.Replace("{0}", parameters.numViewsInt.ToString());
            }

            Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond);

            //Click OK
            Utilities.LogMessage("Create :: Clicking OK Button");
            this.CreateDashViewDialogWindow.ClickOK();


            //After clicking OK wait for the property page to go away
            CoreManager.MomConsole.WaitForDialogClose(
                CreateDashViewDialogWindow,
                60);


            CoreManager.MomConsole.Waiters.WaitForStatusReady(this.timeout);
            //UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, this.timeout);
            //UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, this.timeout);
        }

        /// <summary>
        /// Verify Create Dash View
        /// </summary>
        /// <param name="parameters">DashViewParameters</param>
        public void VerifyCreate(DashViewParameters parameters)
        {
            Utilities.LogMessage("VerifyCreate(...)");
            this.NavigateToCorrectNode(parameters);

            CoreManager.MomConsole.Waiters.WaitForStatusReady();
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            switch (parameters.Space)
            {
                case NavigationPane.WunderBarButton.Monitoring:
                    navPane.SelectNode(parameters.Path + Constants.PathDelimiter + parameters.DashViewName, NavigationPane.NavigationTreeView.Monitoring);
                    break;
                case NavigationPane.WunderBarButton.MyWorkspace:
                    try
                    {
                        navPane.SelectNode(parameters.Path + Constants.PathDelimiter + parameters.DashViewName, NavigationPane.NavigationTreeView.MyWorkspace);
                    }
                    catch (System.InvalidOperationException)
                    {
                        Utilities.LogMessage("VerifyCreate:: try to click node again");
                        navPane.SelectNode(parameters.Path + Constants.PathDelimiter + parameters.DashViewName, NavigationPane.NavigationTreeView.MyWorkspace);
                    }
                    break;
            }
            //navPane.SelectNode(dvParams.Path + Constants.PathDelimiter + parameters.DashViewName, dvParams.Space);

            //UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, this.timeout);
            //UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, this.timeout);
            //CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, this.timeout);
            CoreManager.MomConsole.Waiters.WaitForStatusReady();
        }

        /// <summary>
        /// Click on the Link to add a view: Click to add a view
        /// This method was created to work around in a test automation issue. Bug# 122044. 
        /// Sometimes, the click on the link is not working, is not opening the dialog. 
        /// We can not repro this problem manually. 
        /// </summary>
        /// <param name="dashView">AdddashView static Control link</param>
        private void ClickAddViewLink(StaticControl dashView)
        {
            int retry = 0;
            bool winOpened = false;
            int maxRetry = 5;

            //Retrying the Click on the Link 
            while (winOpened == false && retry < maxRetry)
            {
                Utilities.LogMessage("ClickAddViewLink:: attempt " + retry + " of " + maxRetry);
                try
                {
                    //dashView.Click(MouseClickType.SingleClick, MouseFlags.LeftButton); ---not work
                    //dashView.ScreenElement.LeftButtonClick(-1, -1); ---not work
                    dashView.ScreenElement.SendKeys(KeyboardCodes.Enter);

                    //UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, this.timeout);
                    //UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, this.timeout);
                    //CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, this.timeout);
                    CoreManager.MomConsole.Waiters.WaitForStatusReady();

                    this.SelectViewDialogWindow.Extended.SetFocus();
                    Utilities.LogMessage("ClickAddViewLink:: Select View Dialog should be opened now");
                    winOpened = true;
                    break;
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage("ClickAddViewLink:: Window not found yet");
                    Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);
                    retry++;
                }

            }
        }

        /// <summary>
        /// Add views to dashboard view
        /// </summary>
        /// <param name="parameters">DashViewParameters</param>
        public void AddViews(DashViewParameters parameters)
        {
            Utilities.LogMessage("AddViews(...)");
            //this.VerifyCreate(parameters);

            for (int i = 1; i <= parameters.numViewsInt; i++)
            {
                this.VerifyCreate(parameters);
                Utilities.LogMessage("Clicking on add view link for view #" + i);
                switch (i)
                {
                    case 1:
                        //CoreManager.MomConsole.ViewPane.DashView1.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView1);
                        break;
                    case 2:
                        //CoreManager.MomConsole.ViewPane.DashView1.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        //CoreManager.MomConsole.ViewPane.DashView1.Extended.AccessibleObject.DoDefaultAction();
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView2);
                        break;
                    case 3:
                        //CoreManager.MomConsole.ViewPane.DashView3.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView3);
                        break;
                    case 4:
                        //CoreManager.MomConsole.ViewPane.DashView4.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView4);
                        break;
                    case 5:
                        //CoreManager.MomConsole.ViewPane.DashView5.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView5);
                        break;
                    case 6:
                        //CoreManager.MomConsole.ViewPane.DashView6.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView6);
                        break;
                    case 7:
                        //CoreManager.MomConsole.ViewPane.DashView7.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView7);
                        break;
                    case 8:
                        //CoreManager.MomConsole.ViewPane.DashView8.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView8);
                        break;
                    case 9:
                        //CoreManager.MomConsole.ViewPane.DashView9.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView9);
                        break;
                }
                //UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, this.timeout);
                //UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, this.timeout);
                //CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, this.timeout);
                CoreManager.MomConsole.Waiters.WaitForStatusReady();

                this.SelectViewDialogWindow.Extended.SetFocus();
                this.SelectViewDialogWindow.WaitForResponse();
                //UISynchronization.WaitForProcessReady(this.SelectViewDialogWindow, this.timeout);
                //UISynchronization.WaitForUIObjectReady(this.SelectViewDialogWindow, this.timeout);

                //TreeView viewsTree = SelectViewDialogWindow.Controls.SpecifyTheNumberOfViewsToDisplayInTheDashboardTreeView;
                MomControls.TreeView viewsTree = SelectViewDialogWindow.Controls.LookForTreeView;
                //viewsTree.SelectByIndex(1);
                viewsTree.ExpandAll();

                TreeNode node = null;
                int retry = 0;
                int maxtry = 3;
                /*char[] delimiter = Constants.PathDelimiter.ToCharArray();
                string[] treeNodes = null;
                Utilities.LogMessage((parameters.PathForViewsToAdd[i - 1]).ToString());
                string view = (parameters.PathForViewsToAdd[i - 1]).ToString();
                treeNodes = view.Split(delimiter);
                //treeNodes = ((parameters.PathForViewsToAdd[i - 1]).ToString()).Split(delimiter);
                Utilities.LogMessage(" Trying to pick view = " + treeNodes[treeNodes.Length - 1]);*/

                while (node == null && retry <= maxtry)
                {
                    try
                    {
                        Utilities.LogMessage("Add Views:: Find Node '" + parameters.PathForViewsToAdd[i - 1] + "'");
                        node = CoreManager.MomConsole.ExpandTreePath(parameters.PathForViewsToAdd[i - 1].ToString(), viewsTree);
                        /*node = viewsTree.Find(
                             treeNodes[treeNodes.Length - 1],
                             1,
                             false,
                             SearchMode.DepthFirst,
                             true);*/
                    }
                    catch (TreeNode.Exceptions.NodeNotFoundException)
                    {

                        retry++;
                        Utilities.LogMessage("AddViews:: NodeNotFoundException. Node '" + parameters.PathForViewsToAdd[i - 1] + "' - Attempt # " + retry);
                        Utilities.TakeScreenshot("AddViews_NodeNotFoundException");
                        node = null;
                        Sleeper.Delay(10000);
                    }

                }

                Utilities.LogMessage("AddViews:: Select Node");
                try
                {
                    node.Select(KeyboardFlags.NoFlag, true);
                }
                catch (TreeNode.Exceptions.NodeNotFoundException) //fix bug# 166278 
                {
                    if (viewsTree.VerticalScrollBar.IsVisible)
                        viewsTree.VerticalScrollBar.LineDown();
                    else
                        throw;

                    node.Select(KeyboardFlags.NoFlag, true);
                }

                int loop = 0;
                while (loop++ < maxtry)
                {
                    if (this.SelectViewDialogWindow.Controls.OKButton.IsEnabled)
                    {
                        //Then Click OK to close the search dialog and the view is added to dashView. 
                        Utilities.LogMessage("AddViews :: Clicking OK Button");
                        this.SelectViewDialogWindow.ClickOK();
                        break;
                    }
                    else
                    {
                        if (loop == maxtry)
                        {
                            Utilities.LogMessage("AddViews :: Can't click OK button because it's not enabled.");
                            Utilities.TakeScreenshot("AddViews_CantClickOKBtn");
                            throw new Maui.Core.WinControls.Button.Exceptions.ControlIsDisabledException("Can't click OK button");
                        }
                    }
                }

                CoreManager.MomConsole.Waiters.WaitForStatusReady(this.timeout);
                //UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, this.timeout);
                //UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, this.timeout);
                //CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, this.timeout);
            }

        }

        /// <summary>
        /// Delete dashboard view
        /// </summary>
        /// <param name="parameters">DashViewParameters</param>
        public void Delete(DashViewParameters parameters)
        {
            this.VerifyCreate(parameters);
            Maui.Core.WinControls.Menu deleteViewMenuItem = new Maui.Core.WinControls.Menu(Maui.Core.WinControls.ContextMenuAccessMethod.ShiftF10);
            deleteViewMenuItem.ScreenElement.WaitForReady();
            Utilities.TakeScreenshot("Delete_Ctx_Menu");
            deleteViewMenuItem.ExecuteMenuItem(Mom.Test.UI.Core.Console.Views.Views.Strings.DeleteContextMenu);

            //confirmation dialog
            bool confirmDialogFound = false;
            int currentRetry = 0;
            while (!confirmDialogFound && currentRetry <= 30)
            {
                try
                {
                    CoreManager.MomConsole.ConfirmChoiceDialog(true);
                    Utilities.LogMessage("Delete:: Confirmed delete");
                    confirmDialogFound = true;
                }
                catch (Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage("Delete:: Delete confirmation dialog not found yet, continue to wait. Attempt - " + currentRetry);
                    Maui.Core.Utilities.Sleeper.Delay(1000);
                }

                currentRetry++;
            }

            // Keyboard.SendKeys(KeyboardCodes.Delete);

            CoreManager.MomConsole.Waiters.WaitForStatusReady(this.timeout);
            //UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, this.timeout);
            //UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, this.timeout);
            //CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, this.timeout);
        }

        /// <summary>
        /// Verify Delete dashboard view
        /// </summary>
        /// <param name="parameters">DashViewParameters</param>
        public void VerifyDelete(DashViewParameters parameters)
        {
            bool deleted = false;
            int loop = 0;
            int maxRetry = 5;
            while (loop++ < maxRetry)
            {
                try
                {
                    Utilities.LogMessage("VerifyDelete(...)");
                    this.VerifyCreate(parameters);
                }
                catch (TreeNode.Exceptions.NodeNotFoundException)
                {
                    deleted = true;
                    Utilities.LogMessage("Node Not found.");
                    break;
                }
                catch (System.InvalidOperationException)
                {
                    if (loop == maxRetry)
                        throw;
                }
                catch
                {
                    throw;
                }
            }
            if (!deleted)
                Utilities.LogMessage("Failed to Verify delete. ");
            else
                Utilities.LogMessage("Successfully verified delete. ");
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Verifies whether Views view contains a specific view 
        /// </summary>
        /// <param name="viewName">View Name</param>
        /// <returns>True/False</returns>
        /// ------------------------------------------------------------------
        public bool VerifyViewsView(string viewName)
        {
            int retry = 0;
            int maxTries = 30;
            bool found = false;
            DataGridViewRow resultTop = null;

            Utilities.LogMessage("VerifyViewsView(...)");
            this.NavigateToViewsViewNode();


            //Add retry logic to make sure FindBar is available in UI. 
            int retryFind = 10;
            for (int i = 0; i < retryFind; i++)
            {
                try
                {
                    if (!CoreManager.MomConsole.ViewPane.Find.IsEnabled)
                        CoreManager.MomConsole.ViewPane.Extended.Click();

                    if (CoreManager.MomConsole.ViewPane.Find.Controls.FindNowButton.Extended.IsVisible)
                    {
                        //clear first to get to the original state
                        CoreManager.MomConsole.ViewPane.Find.Controls.ClearButton.Click();
                        Utilities.LogMessage("VerifyViewsView:: FindNowButton is visible after " + i + " seconds.");
                        break;
                    }
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    //Workaround here for bug#172988
                    Core.Common.Utilities.LogMessage("VerifyViewsView:: Findbar does not display in UI, click Find Button in tool bar to make it show.");
                    Core.Common.Utilities.LogMessage("VerifyViewsView:: Click Find Button in ToolBar...");
                    Maui.Core.WinControls.Button findButton =
                        new Maui.Core.WinControls.Button(CoreManager.MomConsole.MainWindow, new Maui.Core.QID(";[UIA]Name = \'" + Core.Console.MonitoringConfiguration.Attributes.Attributes.Strings.FindButtonText + "\' && Role = 'push button'"), 6000);
                    findButton.Click();
                    Utilities.LogMessage("VerifyViewsView:: Sleep one second to wait FindNowButton Ready.");
                    Sleeper.Delay(Core.Common.Constants.OneSecond);
                }
            }

            CoreManager.MomConsole.ViewPane.Find.LookForText = viewName;
            CoreManager.MomConsole.ViewPane.Find.ClickFindNow();

            //UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, this.timeout);
            //UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, this.timeout);
            //CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, this.timeout);
            CoreManager.MomConsole.Waiters.WaitForStatusReady();
            Core.Common.Utilities.LogMessage("VerifyViewsView :: Find '" + viewName + "'");


            while ((resultTop == null) && (retry <= maxTries))
            {
                Utilities.TakeScreenshot("ViewsViewFind_Attempt_" + retry);
                //UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, this.timeout);
                //UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, this.timeout);
                CoreManager.MomConsole.Waiters.WaitForStatusReady();

                resultTop = CoreManager.MomConsole.ViewPane.Grid.FindData(viewName, 0);

                //// log unsuccessful attempt
                Core.Common.Utilities.LogMessage(
                    "ViewsViewFind :: Attempt " + retry + " of " + maxTries);
                retry++;
                Sleeper.Delay(5000); //5 seconds
            }


            if (resultTop == null)
            {
                Utilities.LogMessage("ViewsViewFind :: Unable to find '" + viewName + "'");
                Utilities.TakeScreenshot("ViewsViewFind_failure");
            }

            else
            {
                Utilities.LogMessage("ViewsViewFind :: Found '" + viewName + "'");
                found = true;
            }

            return found;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to Search for views given a text to look for 
        /// </summary>
        /// <param name="parameters">DashViewParameters</param>
        /// <param name="searchText">array with the view names to be search.</param>
        /// ------------------------------------------------------------------
        public void SearchViews(DashViewParameters parameters, string[] searchText)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Utilities.LogMessage(currentMethod + "(...)");
            //select the Dashboard View created. 
            //this.VerifyCreate(parameters); //This is going to select the right node of DashView

            for (int i = 1; i <= parameters.numViewsInt; i++)
            {
                this.VerifyCreate(parameters);
                //For each view in the dashboard view, it will click on AddViewsLink
                Utilities.LogMessage("Clicking on add view link for view #" + i);
                switch (i)
                {
                    case 1:
                        //CoreManager.MomConsole.ViewPane.DashView1.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView1);
                        break;
                    case 2:
                        //CoreManager.MomConsole.ViewPane.DashView2.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView2);
                        break;
                    case 3:
                        //CoreManager.MomConsole.ViewPane.DashView3.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView3);
                        break;
                    case 4:
                        //CoreManager.MomConsole.ViewPane.DashView4.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView4);
                        break;
                    case 5:
                        //CoreManager.MomConsole.ViewPane.DashView5.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView5);
                        break;
                    case 6:
                        //CoreManager.MomConsole.ViewPane.DashView6.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView6);
                        break;
                    case 7:
                        //CoreManager.MomConsole.ViewPane.DashView7.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView7);
                        break;
                    case 8:
                        //CoreManager.MomConsole.ViewPane.DashView8.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView8);
                        break;
                    case 9:
                        //CoreManager.MomConsole.ViewPane.DashView9.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        ClickAddViewLink(CoreManager.MomConsole.ViewPane.DashView9);
                        break;
                }

                //Wait for the Dialog (Select view) to open. 
                //UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, this.timeout);
                //UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, this.timeout);
                //CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, this.timeout);
                CoreManager.MomConsole.Waiters.WaitForStatusReady();

                this.SelectViewDialogWindow.Extended.SetFocus();
                this.SelectViewDialogWindow.WaitForResponse();
                //UISynchronization.WaitForProcessReady(this.SelectViewDialogWindow, this.timeout);
                //UISynchronization.WaitForUIObjectReady(this.SelectViewDialogWindow, this.timeout);

                Utilities.LogMessage(currentMethod + ":: Picker dialog is opened. ");
                Utilities.LogMessage(currentMethod + ":: Search for viewname:" + searchText[i - 1]);

                //Assigning the search field with the name/text to look for and then click FindNow button. 
                this.SelectViewDialogWindow.LookForText = searchText[i - 1];
                this.SelectViewDialogWindow.ClickFindNow();
                //UISynchronization.WaitForUIObjectReady(this.SelectViewDialogWindow, this.timeout);
                this.SelectViewDialogWindow.WaitForResponse();
                //Get the treeview - result of the search
                TreeView viewsTree = SelectViewDialogWindow.Controls.LookForTreeView;

                //Expand the result tree
                viewsTree.ExpandAll();

                TreeNode node = null;
                int retry = 0;
                int maxtry = 3;

                //Trying maxtry because we can not find the node imediately after the search. 
                while (node == null && retry <= maxtry)
                {
                    try
                    {
                        Utilities.LogMessage(currentMethod + ":: Find Node " + searchText[i - 1]);
                        node = viewsTree.Find(searchText[i - 1], 1, false, SearchMode.DepthFirst, true);
                    }
                    catch (TreeNode.Exceptions.NodeNotFoundException)
                    {
                        //If the node is not found, it's going to wait before try again. 
                        retry++;
                        Utilities.LogMessage(currentMethod + ":: NodeNotFoundException. Node '" + searchText[i - 1] + "' - Attempt # " + retry);
                        Utilities.TakeScreenshot(currentMethod + "_NodeNotFoundException");
                        node = null;
                        Sleeper.Delay(waitNodeTime);
                    }

                }

                //If after all the retries, the node is still null, then we should fail. 
                if (node == null)
                {
                    throw new TreeNode.Exceptions.NodeNotFoundException("Node not found in the result of the search"); ;
                }

                //If not, then we select the node 
                Utilities.LogMessage(currentMethod + ":: Select Node");
                try
                {
                    node.Select(KeyboardFlags.NoFlag, true);
                }
                catch (TreeNode.Exceptions.NodeNotFoundException) //fix bug# 163609 
                {
                    if (viewsTree.VerticalScrollBar.IsVisible)
                        viewsTree.VerticalScrollBar.LineDown();
                    else
                        throw;

                    node.Select(KeyboardFlags.NoFlag, true);
                }

                int loop = 0;
                while (loop++ < maxtry)
                {
                    if (this.SelectViewDialogWindow.Controls.OKButton.IsEnabled)
                    {
                        //Then Click OK to close the search dialog and the view is added to dashView. 
                        Utilities.LogMessage("AddViews :: Clicking OK Button");
                        this.SelectViewDialogWindow.ClickOK();
                        break;
                    }
                    else
                    {
                        if (loop == maxtry)
                        {
                            Utilities.LogMessage(currentMethod + ":: Can't click OK button because it's not enabled.");
                            Utilities.TakeScreenshot(currentMethod + "_CantClickOKBtn");
                            throw new Maui.Core.WinControls.Button.Exceptions.ControlIsDisabledException("Can't click OK button");
                        }
                    }
                }

                CoreManager.MomConsole.Waiters.WaitForStatusReady(this.timeout);
                //UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, this.timeout);
                //UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, this.timeout);
                //CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, this.timeout);

            }
        }



        #endregion

        #region Strings Class

        /// <summary>
        /// Strings Class
        /// </summary>
        public class Strings
        {
            #region Constants

            private const string ResourceNumViews = ";{0} views;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DashboardView.DashboardViewResources;ViewQueryFormatString";

            #endregion

            #region Member Variables

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NumViews
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNumViews;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Num views dropdown values
            /// </summary>
            /// <history>
            /// 	[visnara] 26DEC06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NumViews
            {
                get
                {
                    if ((cachedNumViews == null))
                    {
                        cachedNumViews = CoreManager.MomConsole.GetIntlStr(ResourceNumViews);
                    }

                    return cachedNumViews;
                }
            }

            #endregion

        }
        #endregion


    }


}
