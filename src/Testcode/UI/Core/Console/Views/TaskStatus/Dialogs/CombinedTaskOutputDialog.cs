// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CombinedTaskOutputDialog.cs">
//   Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-eachu] 9/11/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.TaskStatus.Dialogs
{
    #region Using directivew
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console;
    #endregion
    
    #region Interface Definition - ICombinedTaskOutputDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICombinedTaskOutputDialogControls, for CombinedTaskOutputDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-eachu] 9/11/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICombinedTaskOutputDialogControls
    {
        /// <summary>
        /// Read-only property to access HTMLDoc
        /// </summary>
        HtmlDocument HTMLDoc
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CloseButton
        /// </summary>
        Button CloseButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToolStrip1
        /// </summary>
        Toolbar ToolStrip1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FilterValueComboBox
        /// </summary>
        ComboBox FilterValueComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FilterValueComboBox2
        /// </summary>
        ComboBox FilterValueComboBox2
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
    ///   [v-eachu] 9/11/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class CombinedTaskOutputDialog : Dialog, ICombinedTaskOutputDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to HTMLDoc of type HTMLDocument
        /// </summary>
        private HtmlDocument cachedHTMLDoc;
        
        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        
        /// <summary>
        /// Cache to hold a reference to ToolStrip1 of type Toolbar
        /// </summary>
        private Toolbar cachedToolStrip1;
        
        /// <summary>
        /// Cache to hold a reference to FilterValueComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedFilterValueComboBox;
        
        /// <summary>
        /// Cache to hold a reference to FilterValueComboBox2 of type ComboBox
        /// </summary>
        private ComboBox cachedFilterValueComboBox2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of CombinedTaskOutputDialog of type App
        /// </param>
        /// <history>
        ///   [v-eachu] 9/11/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CombinedTaskOutputDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ICombinedTaskOutputDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-eachu] 9/11/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICombinedTaskOutputDialogControls Controls
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
        ///  Routine to set/get the text in control FilterValue
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-eachu] 9/11/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FilterValueText
        {
            get
            {
                return this.Controls.FilterValueComboBox.Text;
            }
            
            set
            {
                this.Controls.FilterValueComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control FilterValue2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-eachu] 9/11/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FilterValue2Text
        {
            get
            {
                return this.Controls.FilterValueComboBox2.Text;
            }
            
            set
            {
                this.Controls.FilterValueComboBox2.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HTMLDoc control
        /// </summary>
        /// <history>
        ///   [v-eachu] 9/11/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        HtmlDocument ICombinedTaskOutputDialogControls.HTMLDoc
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
                    this.cachedHTMLDoc = new HtmlDocument(wndTemp);
                }
                
                return this.cachedHTMLDoc;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        ///   [v-eachu] 9/11/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICombinedTaskOutputDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, CombinedTaskOutputDialog.ControlIDs.CloseButton);
                }
                
                return this.cachedCloseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToolStrip1 control
        /// </summary>
        /// <history>
        ///   [v-eachu] 9/11/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar ICombinedTaskOutputDialogControls.ToolStrip1
        {
            get
            {
                if ((this.cachedToolStrip1 == null))
                {
                    this.cachedToolStrip1 = new Toolbar(this, CombinedTaskOutputDialog.ControlIDs.ToolStrip1);
                }
                
                return this.cachedToolStrip1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FilterValueComboBox control
        /// </summary>
        /// <history>
        ///   [v-eachu] 9/11/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ICombinedTaskOutputDialogControls.FilterValueComboBox
        {
            get
            {
                if ((this.cachedFilterValueComboBox == null))
                {
                    this.cachedFilterValueComboBox = new ComboBox(this, CombinedTaskOutputDialog.ControlIDs.FilterValueComboBox);
                }
                
                return this.cachedFilterValueComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FilterValueComboBox2 control
        /// </summary>
        /// <history>
        ///   [v-eachu] 9/11/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ICombinedTaskOutputDialogControls.FilterValueComboBox2
        {
            get
            {
                if ((this.cachedFilterValueComboBox2 == null))
                {
                    this.cachedFilterValueComboBox2 = new ComboBox(this, CombinedTaskOutputDialog.ControlIDs.FilterValueComboBox2);
                }
                
                return this.cachedFilterValueComboBox2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        ///   [v-eachu] 9/11/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClose()
        {
            this.Controls.CloseButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        ///   [v-eachu] 9/11/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, 
                    StringMatchSyntax.ExactMatch, 
                    WindowClassNames.WinForms10Window8, 
                    StringMatchSyntax.ExactMatch, 
                    app, 
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                tempWindow = null;
                int numberofTries = 0;
                const int MaxTries = 10;
                while (tempWindow == null && numberofTries < MaxTries)
                {
                    numberofTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow = new Window(Strings.DialogTitle + "*",
                            StringMatchSyntax.WildCard,
                            WindowClassNames.WinForms10Window8,
                            StringMatchSyntax.WildCard,
                            app,
                            Timeout);

                        // wait for the window to report ready
                        app.Waiters.WaitForWindowIdle(tempWindow, 60000);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    { 
                        //log the unsuccessful attemp
                        Core.Common.Utilities.LogMessage("Attempt " + numberofTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    //log the failure
                    Core.Common.Utilities.LogMessage("Failed to find window with title: '" + Strings.DialogTitle + "'");

                    //throw the existing WindowNotFound exception
                    throw windowNotFound;
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
        ///   [v-eachu] 9/11/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Resource string for Combined Task Output
            /// </summary>
            public const string ResourceDialogTitle = ";Combined Task Output;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ent" +
                "erpriseManagement.Mom.UI.GroupedTaskResults;$this.Text";
            
            /// <summary>
            /// Resource string for Close
            /// </summary>
            public const string ResourceClose = ";Cl&ose;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.MPD" +
                "ownloadInstallResources;Close";
            
            /// <summary>
            /// Resource string for toolStrip1
            /// </summary>
            public const string ResourceToolStrip1 = ";toolStrip1;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall" +
                ".Wizards.Install.SelectInstallMPsPage;buttonsToolStrip.Text";

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for: Dialog Title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClose;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ToolStrip1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToolStrip1;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 9/14/2009 Created
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
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 9/14/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Close
            {
                get
                {
                    if ((cachedClose == null))
                    {
                        cachedClose = CoreManager.MomConsole.GetIntlStr(ResourceClose);
                    }
                    return cachedClose;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tool Strip1 translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eachu] 9/14/2009 Created
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

            #endregion

        }
        #endregion

        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        ///   [v-eachu] 9/11/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "btnClose";

            /// <summary>
            /// Control ID for ToolStrip1
            /// </summary>
            public const string ToolStrip1 = "toolStrip1";

            /// <summary>
            /// Control ID for FilterValueComboBox
            /// </summary>
            public const string FilterValueComboBox = "comboBoxGroupingColumn";

            /// <summary>
            /// Control ID for FilterValueComboBox2
            /// </summary>
            public const string FilterValueComboBox2 = "comboBoxValues";
        }
        #endregion
    }
}
