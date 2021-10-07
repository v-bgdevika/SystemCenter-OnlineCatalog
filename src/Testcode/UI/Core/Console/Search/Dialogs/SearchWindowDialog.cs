// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SearchWindowDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	Search Window Dialog.
// </summary>
// <history>
// 	[mbickle] 01MAY06 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Search.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    #endregion
    
    #region Interface Definition - ISearchWindowDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISearchWindowDialogControls, for SearchWindowDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 01MAY06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISearchWindowDialogControls
    {
        /// <summary>
        /// Read-only property to access ToolStrip1
        /// </summary>
        Toolbar ToolStrip1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchTextBox
        /// </summary>
        TextBox SearchTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInPropertyGridView
        /// </summary>
        PropertyGridView EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInPropertyGridView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchStaticControl
        /// </summary>
        StaticControl SearchStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StaticControl5
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StaticControl StaticControl5
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SearchToolbar
        /// </summary>
        Toolbar SearchToolbar
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StatusBar6
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StatusBar StatusBar6
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[mbickle] 01MAY06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SearchWindowDialog : Dialog, ISearchWindowDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ToolStrip1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolStrip1;
        
        /// <summary>
        /// Cache to hold a reference to SearchTextBox of type TextBox
        /// </summary>
        private TextBox cachedSearchTextBox;
        
        /// <summary>
        /// Cache to hold a reference to EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInPropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedEnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to SearchStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSearchStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StaticControl5 of type StaticControl
        /// </summary>
        private StaticControl cachedStaticControl5;
        
        /// <summary>
        /// Cache to hold a reference to SearchToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedSearchToolbar;
        
        /// <summary>
        /// Cache to hold a reference to StatusBar6 of type StatusBar
        /// </summary>
        private StatusBar cachedStatusBar6;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SearchWindowDialog of type App
        /// </param>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SearchWindowDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISearchWindowDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISearchWindowDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Search
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SearchText
        {
            get
            {
                return this.Controls.SearchTextBox.Text;
            }
            
            set
            {
                this.Controls.SearchTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStrip1 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar ISearchWindowDialogControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this, SearchWindowDialog.ControlIDs.ToolStrip1);
                }

                return this.cachedToolStrip1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchTextBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISearchWindowDialogControls.SearchTextBox
        {
            get
            {
                if ((this.cachedSearchTextBox == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedSearchTextBox = new TextBox(wndTemp);
                }

                return this.cachedSearchTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInPropertyGridView control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView ISearchWindowDialogControls.EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInPropertyGridView
        {
            get
            {
                if ((this.cachedEnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInPropertyGridView == null))
                {
                    this.cachedEnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInPropertyGridView = new PropertyGridView(this, SearchWindowDialog.ControlIDs.EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInPropertyGridView);
                }

                return this.cachedEnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInPropertyGridView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISearchWindowDialogControls.SearchStaticControl
        {
            get
            {
                if ((this.cachedSearchStaticControl == null))
                {
                    this.cachedSearchStaticControl = new StaticControl(this, SearchWindowDialog.ControlIDs.SearchStaticControl);
                }

                return this.cachedSearchStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StaticControl5 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISearchWindowDialogControls.StaticControl5
        {
            get
            {
                if ((this.cachedStaticControl5 == null))
                {
                    this.cachedStaticControl5 = new StaticControl(this, SearchWindowDialog.ControlIDs.StaticControl5);
                }

                return this.cachedStaticControl5;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SearchToolbar control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar ISearchWindowDialogControls.SearchToolbar
        {
            get
            {
                if ((this.cachedSearchToolbar == null))
                {
                    this.cachedSearchToolbar = new Toolbar(this, SearchWindowDialog.ControlIDs.SearchToolbar);
                }

                return this.cachedSearchToolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StatusBar6 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StatusBar ISearchWindowDialogControls.StatusBar6
        {
            get
            {
                if ((this.cachedStatusBar6 == null))
                {
                    this.cachedStatusBar6 = new StatusBar(this, SearchWindowDialog.ControlIDs.StatusBar6);
                }

                return this.cachedStatusBar6;
            }
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
            }            
            catch (Exceptions.WindowNotFoundException ex)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 5;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                app.GetIntlStr(Strings.DialogTitle) + "*",
                                StringMatchSyntax.WildCard,
                                WindowClassNames.Dialog,
                                StringMatchSyntax.ExactMatch,
                                app,
                                Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }

            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Search;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SearchResource;SearchViewTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToolStrip1 = ";toolStrip1;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.Internal.UI.PageFrameworks.SheetFramework;stripTop.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSearch = ";Search;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;Microsoft.E" +
                "nterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.ReportMonitori" +
                "ngObjectSearchCriteria;searchButton.Text";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToolStrip1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Search
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSearch;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
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
            /// Exposes access to the ToolStrip1 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToolStrip1
            {
                get
                {
                    if ((cachedToolStrip1 == null))
                    {
                        cachedToolStrip1 = CoreManager.MomConsole.GetIntlStr(ResourceToolStrip1);
                    }

                    return cachedToolStrip1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Search translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Search
            {
                get
                {
                    if ((cachedSearch == null))
                    {
                        cachedSearch = CoreManager.MomConsole.GetIntlStr(ResourceSearch);
                    }

                    return cachedSearch;
                }
            }
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "toolStrip";
            
            /// <summary>
            /// Control ID for EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInPropertyGridView
            /// </summary>
            public const string EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInPropertyGridView = "momGrid";
            
            /// <summary>
            /// Control ID for SearchStaticControl
            /// </summary>
            public const string SearchStaticControl = "ViewTitle";
            
            /// <summary>
            /// Control ID for StaticControl5
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StaticControl5 = "rightLabel";
            
            /// <summary>
            /// Control ID for SearchToolbar
            /// </summary>
            public const string SearchToolbar = "header";
            
            /// <summary>
            /// Control ID for StatusBar6
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StatusBar6 = "consoleStatusBar";
        }
        #endregion
    }
}
