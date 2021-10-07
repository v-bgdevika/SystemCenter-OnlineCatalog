// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DetailPane.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
//  MOMv3
// </project>
// <summary>
// 	Details Pane methods
// </summary>
// <history>
// 	[mbickle] 10AUG05: Created
// </history>
// ---------------------------------------------------------------------------
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
    /// Console DetailPane Interface
    /// </summary>
    public interface IDetailPane
    {
        /// <summary>
        /// Read-only property to access DetailPaneTitleStaticControl.
        /// </summary>
        StaticControl DetailPaneTitleStaticControl
        {
            get;
        }

        /// <summary>
        /// Controls
        /// </summary>
        IDetailPane Controls
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
        /// Html Document
        /// </summary>
        HtmlDocument HtmlDocument
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
        /// Hide
        /// </summary>
        /// <param name="method">Command Method</param>
        void Hide(Maui.Core.CommandMethod method);

        /// <summary>
        /// Hide
        /// </summary>
        void Hide();

        /// <summary>
        /// Show
        /// </summary>
        /// <param name="method">Command Method</param>
        void Show(Maui.Core.CommandMethod method);

        /// <summary>
        /// Show
        /// </summary>
        void Show();

        /// <summary>
        /// Read-only property to access SelectAnyNodeOrLineOnTheDiagramAboveToDisplayItsDetailsStaticControl
        /// </summary>
        StaticControl SelectAnyNodeOrLineOnTheDiagramAboveToDisplayItsDetailsStaticControl
        {
            get;
        }

    }

    #endregion

    /// ------------------------------------------------------------------
    /// <summary>
    /// Detail Pane Class
    /// </summary>
    /// <history>
    /// 	[mbickle] 10AUG05 Created
    /// 	[a-joelj] 07MAY10 Changed constructor to use QID by default for the ConsoleApp
    /// </history>
    /// ------------------------------------------------------------------
    //public class DetailPane : Window, IDetailPane
    public class DetailPane : Window, IDetailPane
    {
        #region Constructor
        /// ------------------------------------------------------------------
        /// <summary>
        /// DetailPane Window
        /// </summary>
        /// <param name="app">ConsoleApp</param>
        /// ------------------------------------------------------------------
        public DetailPane(ConsoleApp app) :
            base(app.MainWindow, new QID(";[UIA]Name='" + ControlIDs.DetailPane + "'"), Core.Common.Constants.DefaultDialogTimeout)
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Cache to hold a reference to SelectAnyNodeOrLineOnTheDiagramAboveToDisplayItsDetailsStaticControl of type StaticControl
        /// </summary>
        private  StaticControl cachedSelectAnyNodeOrLineOnTheDiagramAboveToDisplayItsDetailsStaticControl;

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectAnyNodeOrLineOnTheDiagramAboveToDisplayItsDetailsStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 3/7/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public  StaticControl SelectAnyNodeOrLineOnTheDiagramAboveToDisplayItsDetailsStaticControl
        {
            get
            {
                if ((this.cachedSelectAnyNodeOrLineOnTheDiagramAboveToDisplayItsDetailsStaticControl == null))
                {
                    this.cachedSelectAnyNodeOrLineOnTheDiagramAboveToDisplayItsDetailsStaticControl = new StaticControl(this, ControlIDs.SelectAnyNodeOrLineOnTheDiagramAboveToDisplayItsDetailsStaticControl);
                }
                return this.cachedSelectAnyNodeOrLineOnTheDiagramAboveToDisplayItsDetailsStaticControl;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Get the DetailPane Title of the currently loaded view.
        /// </summary>
        /// <returns>DetailPane Title String</returns>
        /// <history>
        /// [mbickle] 01AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public string Title
        {
            get
            {
                return CoreManager.MomConsole.GetStaticControlCaption(this.Controls.DetailPaneTitleStaticControl);
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
        /// Access to the DetailPane Splitter Bar.
        /// </summary>
        /// ------------------------------------------------------------------
        public ActiveAccessibility Splitter
        {
            get
            {
                return CoreManager.MomConsole.MainWindow.Extended.AccessibleObject.FindChild(ControlIDs.DetailPaneSplitter);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets reference to the GridControl in the Detail Pane
        /// </summary>
        /// ------------------------------------------------------------------
        public MomControls.GridControl GridControl
        {
            get
            {
                return new MomControls.GridControl(
                    this,
                    MomControls.GridControl.ControlIDs.DetailPaneGrid);
                
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets refrence to the HtmlDocument in Details Pane.
        /// </summary>
        /// ------------------------------------------------------------------
        public HtmlDocument HtmlDocument
        {
            get
            {
                HtmlDocument htmlDocument = null;
                int attempt = 0;
                while (attempt < Constants.DefaultMaxRetry)
                {
                    try
                    {
                        Window wndTemp = new Window(
                        "",
                        StringMatchSyntax.WildCard,
                        WindowClassNames.InternetExplorerServer,
                        StringMatchSyntax.ExactMatch,
                        this.AccessibleObject.Window,
                        Constants.DefaultDialogTimeout);

                        htmlDocument = new HtmlDocument(wndTemp);

                        break;
                    }
                    // Maui4.0: [v-vijia] Found intermittent failure: System.Exception: Unable to get IE DOM from window message result in getDOMFromHwnd()
                    catch (Exception e)
                    {
                        if (attempt == Constants.DefaultMaxRetry - 1)
                        {
                            throw e;
                        }

                        Sleeper.Delay(Constants.OneSecond);
                        Utilities.LogMessage("DetailPane.HtmlDocument:: Found exception: " + e);
                    }

                    attempt++;
                }

                return htmlDocument;
            }
        }

        #endregion

        #region IDetailPane Controls Property

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the app. window's control properties together</value>
        /// <history>
        /// 	[mbickle] 10AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public virtual IDetailPane Controls
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
        StaticControl IDetailPane.DetailPaneTitleStaticControl
        {
            get
            {
                return new StaticControl(this, ControlIDs.DetailPaneTitleStaticControl);
            }
        }
        #endregion

        #region Public Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// Show Details Pane if not Visible
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
        /// Show Details Pane if not Visible
        /// </summary>
        /// <param name="method">CommandMehtod</param>
        /// ------------------------------------------------------------------
        public void Show(CommandMethod method)
        {
            if (!this.IsVisible)
            {
                Commands.ViewDetailPane.Execute(CoreManager.MomConsole, method);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Hide Details Pane if Visible
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
        /// Hide Details Pane if Visible
        /// </summary>
        /// <param name="method">CommandMethod</param>
        /// ------------------------------------------------------------------
        public void Hide(CommandMethod method)
        {
            if (this.IsVisible)
            {
                Commands.ViewDetailPane.Execute(CoreManager.MomConsole, method);
            }
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
            /// Control ID for DetailPane Window
            /// </summary>
            [Obsolete]
            public const string DetailPane = "detailPane";

            /// <summary>
            /// Control ID for DetailViewTitleStaticControl
            /// </summary>
            [Obsolete]
            public const string DetailPaneTitleStaticControl = "DetailViewTitle";
            /// <summary>
            /// Control ID for SelectAnyNodeOrLineOnTheDiagramAboveToDisplayItsDetailsStaticControl
            /// </summary>
            public const string SelectAnyNodeOrLineOnTheDiagramAboveToDisplayItsDetailsStaticControl = "messageLabel";
            
            /// <summary>
            /// Control ID for DetailViewSplitter
            /// </summary>
            [Obsolete]
            public const string DetailPaneSplitter = "DetailViewSplitter";
        }
        #endregion
    }
}
