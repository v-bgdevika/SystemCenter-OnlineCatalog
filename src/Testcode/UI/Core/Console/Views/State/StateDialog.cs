// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="StateDialog.cs">
//   Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [a-mujtch] 6/2/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.State
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Maui.Core.HtmlControls;
    using Mom.Test.UI.Core.Common;
    //using Maui.InternetExplorer;
    
    #region Interface Definition - IStateDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IStateDialogControls, for StateDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [a-mujtch] 6/2/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IStateDialogControls
    {
        /// <summary>
        /// Read-only property to access PropertyGridView
        /// </summary>
        PropertyGridView PropertyGridView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HTMLDoc
        /// </summary>
        Maui.Core.HtmlDocument HTMLDoc
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LoadingToolbar
        /// </summary>
        Toolbar LoadingToolbar
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StatusBar
        /// </summary>
        StatusBar StatusBar
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
    ///   [a-mujtch] 6/2/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class StateDialog : Dialog, IStateDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to PropertyGridView of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedPropertyGridView;
        
        /// <summary>
        /// Cache to hold a reference to HTMLDoc of type HTMLDocument
        /// </summary>
        private Maui.Core.HtmlDocument cachedHTMLDoc;
        
        /// <summary>
        /// Cache to hold a reference to LoadingToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedLoadingToolbar;
        
        /// <summary>
        /// Cache to hold a reference to StatusBar of type StatusBar
        /// </summary>
        private StatusBar cachedStatusBar;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of StateDialog of type MomConsoleApp
        /// </param>
        /// <history>
        ///   [a-mujtch] 6/2/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public StateDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IStateDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [a-mujtch] 6/2/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IStateDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PropertyGridView control
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/2/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IStateDialogControls.PropertyGridView
        {
            get
            {
                if ((this.cachedPropertyGridView == null))
                {
                    this.cachedPropertyGridView = new PropertyGridView(this, StateDialog.ControlIDs.PropertyGridView);
                }
                
                return this.cachedPropertyGridView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Grid Control
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/2/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public MomControls.GridControl Grid
        {
            get
            {
                return new MomControls.GridControl(
                    this,
                    StateDialog.ControlIDs.PropertyGridView);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HTMLDoc control
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/2/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Maui.Core.HtmlDocument IStateDialogControls.HTMLDoc
        {
            get
            {
                if ((this.cachedHTMLDoc == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedHTMLDoc = new Maui.Core.HtmlDocument(wndTemp);
                }
                
                return this.cachedHTMLDoc;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LoadingToolbar control
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/2/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IStateDialogControls.LoadingToolbar
        {
            get
            {
                if ((this.cachedLoadingToolbar == null))
                {
                    this.cachedLoadingToolbar = new Toolbar(this, StateDialog.ControlIDs.LoadingToolbar);
                }
                
                return this.cachedLoadingToolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StatusBar control
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/2/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StatusBar IStateDialogControls.StatusBar
        {
            get
            {
                if ((this.cachedStatusBar == null))
                {
                    this.cachedStatusBar = new StatusBar(this, StateDialog.ControlIDs.StatusBar);
                }
                
                return this.cachedStatusBar;
            }
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        ///   [a-mujtch] 6/2/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow) 
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }
            
            return tempWindow;
        }
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/2/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for PropertyGridView
            /// </summary>
            public const string PropertyGridView = "momGrid";
            
            /// <summary>
            /// Control ID for LoadingToolbar
            /// </summary>
            public const string LoadingToolbar = "header";
            
            /// <summary>
            /// Control ID for StatusBar
            /// </summary>
            public const string StatusBar = "consoleStatusBar";
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/2/2009 Created
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
            private const string ResourceDialogTitle = ";State;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.StateView;State";
            
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;
            #endregion
            
            #region Properties

            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
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

            /// <summary>
            /// Exposes cell success value string
            /// </summary>
            public static string SuccessCellValue
            {
                get
                {
                    return Constants.SuccessState;
                }
            }

            /// <summary>
            /// Exposes cell error value string
            /// </summary>
            public static string ErrorCellValue
            {
                get
                {
                    return Constants.ErrorState;
                }
            }

            #endregion
        }
        #endregion
    }
}
