// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DiagramViewDialog.cs">
//   Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [a-mujtch] 6/4/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Diagram.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Maui.Core.HtmlControls;
    //using Maui.InternetExplorer;
    
    #region Interface Definition - IDiagramViewDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDiagramViewDialogControls, for DiagramViewDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [a-mujtch] 6/4/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDiagramViewDialogControls
    {
        /// <summary>
        /// Read-only property to access Button0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button2
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button3
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DetailViewEditComboBox
        /// </summary>
        EditComboBox DetailViewEditComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DetailViewTextBox
        /// </summary>
        TextBox DetailViewTextBox
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
        /// Read-only property to access DiagramViewToolbar
        /// </summary>
        Toolbar DiagramViewToolbar
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ViewToolbar
        /// </summary>
        Toolbar ViewToolbar
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DiagramViewEditComboBox
        /// </summary>
        EditComboBox DiagramViewEditComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DiagramViewTextBox
        /// </summary>
        TextBox DiagramViewTextBox
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
    ///   [a-mujtch] 6/4/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class DiagramViewDialog : Dialog, IDiagramViewDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Public Constants

        /// <summary>
        /// Toolbar position of Find button 
        /// </summary>
        public const int INDEX_BUTTON_FIND = 4;

        /// <summary>
        /// Toolbar position of Problem Path button
        /// </summary>
        public const int INDEX_BUTTON_PROBLEMPATH = 13;

        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to Button0 of type Button
        /// </summary>
        private Button cachedButton0;
        
        /// <summary>
        /// Cache to hold a reference to Button1 of type Button
        /// </summary>
        private Button cachedButton1;
        
        /// <summary>
        /// Cache to hold a reference to Button2 of type Button
        /// </summary>
        private Button cachedButton2;
        
        /// <summary>
        /// Cache to hold a reference to Button3 of type Button
        /// </summary>
        private Button cachedButton3;
        
        /// <summary>
        /// Cache to hold a reference to DetailViewEditComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedDetailViewEditComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DetailViewTextBox of type TextBox
        /// </summary>
        private TextBox cachedDetailViewTextBox;
        
        /// <summary>
        /// Cache to hold a reference to HTMLDoc of type HTMLDocument
        /// </summary>
        private Maui.Core.HtmlDocument cachedHTMLDoc;
        
        /// <summary>
        /// Cache to hold a reference to DiagramViewToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedDiagramViewToolbar;
        
        /// <summary>
        /// Cache to hold a reference to ViewToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedViewToolbar;
        
        /// <summary>
        /// Cache to hold a reference to DiagramViewEditComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedDiagramViewEditComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DiagramViewTextBox of type TextBox
        /// </summary>
        private TextBox cachedDiagramViewTextBox;
        
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
        /// Owner of DiagramViewDialog of type MomConsoleApp
        /// </param>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DiagramViewDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IDiagramViewDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDiagramViewDialogControls Controls
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
        ///  Routine to set/get the text in control DetailView
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DetailViewText
        {
            get
            {
                return this.Controls.DetailViewEditComboBox.Text;
            }
            
            set
            {
                this.Controls.DetailViewEditComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DetailView2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DetailView2Text
        {
            get
            {
                return this.Controls.DetailViewTextBox.Text;
            }
            
            set
            {
                this.Controls.DetailViewTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DiagramView
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DiagramViewText
        {
            get
            {
                return this.Controls.DiagramViewEditComboBox.Text;
            }
            
            set
            {
                this.Controls.DiagramViewEditComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DiagramView2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DiagramView2Text
        {
            get
            {
                return this.Controls.DiagramViewTextBox.Text;
            }
            
            set
            {
                this.Controls.DiagramViewTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button0 control
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagramViewDialogControls.Button0
        {
            get
            {
                if ((this.cachedButton0 == null))
                {
                    this.cachedButton0 = new Button(this, DiagramViewDialog.ControlIDs.Button0);
                }
                
                return this.cachedButton0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button1 control
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagramViewDialogControls.Button1
        {
            get
            {
                if ((this.cachedButton1 == null))
                {
                    this.cachedButton1 = new Button(this, DiagramViewDialog.ControlIDs.Button1);
                }
                
                return this.cachedButton1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button2 control
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagramViewDialogControls.Button2
        {
            get
            {
                if ((this.cachedButton2 == null))
                {
                    this.cachedButton2 = new Button(this, DiagramViewDialog.ControlIDs.Button2);
                }
                
                return this.cachedButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button3 control
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiagramViewDialogControls.Button3
        {
            get
            {
                if ((this.cachedButton3 == null))
                {
                    this.cachedButton3 = new Button(this, DiagramViewDialog.ControlIDs.Button3);
                }
                
                return this.cachedButton3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DetailViewEditComboBox control
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IDiagramViewDialogControls.DetailViewEditComboBox
        {
            get
            {
                if ((this.cachedDetailViewEditComboBox == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    this.cachedDetailViewEditComboBox = new EditComboBox(wndTemp);
                }
                
                return this.cachedDetailViewEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DetailViewTextBox control
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IDiagramViewDialogControls.DetailViewTextBox
        {
            get
            {
                if ((this.cachedDetailViewTextBox == null))
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
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedDetailViewTextBox = new TextBox(wndTemp);
                }
                
                return this.cachedDetailViewTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HTMLDoc control
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Maui.Core.HtmlDocument IDiagramViewDialogControls.HTMLDoc
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
        ///  Exposes access to the DiagramViewToolbar control
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IDiagramViewDialogControls.DiagramViewToolbar
        {
            get
            {
                if ((this.cachedDiagramViewToolbar == null))
                {
                    this.cachedDiagramViewToolbar = new Toolbar(this, DiagramViewDialog.ControlIDs.DiagramViewToolbar);
                }
                
                return this.cachedDiagramViewToolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewToolbar control
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IDiagramViewDialogControls.ViewToolbar
        {
            get
            {
                if ((this.cachedViewToolbar == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    this.cachedViewToolbar = new Toolbar(wndTemp);
                }
                
                return this.cachedViewToolbar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiagramViewEditComboBox control
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IDiagramViewDialogControls.DiagramViewEditComboBox
        {
            get
            {
                if ((this.cachedDiagramViewEditComboBox == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedDiagramViewEditComboBox = new EditComboBox(wndTemp);
                }
                
                return this.cachedDiagramViewEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiagramViewTextBox control
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IDiagramViewDialogControls.DiagramViewTextBox
        {
            get
            {
                if ((this.cachedDiagramViewTextBox == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedDiagramViewTextBox = new TextBox(wndTemp);
                }
                
                return this.cachedDiagramViewTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StatusBar control
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StatusBar IDiagramViewDialogControls.StatusBar
        {
            get
            {
                if ((this.cachedStatusBar == null))
                {
                    this.cachedStatusBar = new StatusBar(this, DiagramViewDialog.ControlIDs.StatusBar);
                }
                
                return this.cachedStatusBar;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button0
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton0()
        {
            this.Controls.Button0.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button1
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton1()
        {
            this.Controls.Button1.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button2
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton2()
        {
            this.Controls.Button2.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button3
        /// </summary>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton3()
        {
            this.Controls.Button3.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        ///   [a-mujtch] 6/4/2009 Created
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
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for Button0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button0 = "buttonStart";
            
            /// <summary>
            /// Control ID for Button1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button1 = "buttonLeft";
            
            /// <summary>
            /// Control ID for Button2
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button2 = "buttonRight";
            
            /// <summary>
            /// Control ID for Button3
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button3 = "buttonEnd";
            
            /// <summary>
            /// Control ID for DiagramViewToolbar
            /// </summary>
            public const string DiagramViewToolbar = "header";
            
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
        ///   [a-mujtch] 6/4/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Diagram View;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramViewResources;DiagramView";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ViewToolbar
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceViewToolbar = "ViewToolbar";
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
            /// Caches the translated resource string for:  ViewToolbar
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewToolbar;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [a-mujtch] 6/4/2009 Created
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
            /// Exposes access to the ViewToolbar translated resource string
            /// </summary>
            /// <history>
            ///   [a-mujtch] 6/4/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewToolbar
            {
                get
                {
                    if ((cachedViewToolbar == null))
                    {
                        cachedViewToolbar = CoreManager.MomConsole.GetIntlStr(ResourceViewToolbar);
                    }
                    
                    return cachedViewToolbar;
                }
            }
            #endregion
        }
        #endregion
    }
}
