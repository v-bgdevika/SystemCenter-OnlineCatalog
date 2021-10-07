// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ImportManagementPacksCloseDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 3/25/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MP.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IImportManagementPacksCloseDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IImportManagementPacksCloseDialogControls, for ImportManagementPacksCloseDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 3/25/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IImportManagementPacksCloseDialogControls
    {
        /// <summary>
        /// Read-only property to access ManagementPackListStaticControl
        /// </summary>
        StaticControl ManagementPackListStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HelpButton
        /// </summary>
        Button HelpButton
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
        /// Read-only property to access ManagementPackListListView
        /// </summary>
        ListView ManagementPackListListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementPackDetailsTextBox
        /// </summary>
        TextBox ManagementPackDetailsTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementPackDetailsStaticControl
        /// </summary>
        StaticControl ManagementPackDetailsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AllManagementPacksSucessfullyImportedStaticControl
        /// </summary>
        StaticControl AllManagementPacksSucessfullyImportedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AllManagementPacksSucessfullyImportedToolbar
        /// </summary>
        Toolbar AllManagementPacksSucessfullyImportedToolbar
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
    /// 	[faizalk] 3/25/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ImportManagementPacksCloseDialog : Dialog, IImportManagementPacksCloseDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ManagementPackListStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPackListStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpButton of type Button
        /// </summary>
        private Button cachedHelpButton;
        
        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackListListView of type ListView
        /// </summary>
        private ListView cachedManagementPackListListView;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackDetailsTextBox of type TextBox
        /// </summary>
        private TextBox cachedManagementPackDetailsTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackDetailsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPackDetailsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AllManagementPacksSucessfullyImportedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAllManagementPacksSucessfullyImportedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AllManagementPacksSucessfullyImportedToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedAllManagementPacksSucessfullyImportedToolbar;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ImportManagementPacksCloseDialog of type Mom.Test.UI.Core.Console.MomConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ImportManagementPacksCloseDialog(Mom.Test.UI.Core.Console.MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IImportManagementPacksCloseDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IImportManagementPacksCloseDialogControls Controls
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
        ///  Routine to set/get the text in control ManagementPackDetails
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ManagementPackDetailsText
        {
            get
            {
                return this.Controls.ManagementPackDetailsTextBox.Text;
            }
            
            set
            {
                this.Controls.ManagementPackDetailsTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackListStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IImportManagementPacksCloseDialogControls.ManagementPackListStaticControl
        {
            get
            {
                if ((this.cachedManagementPackListStaticControl == null))
                {
                    this.cachedManagementPackListStaticControl = new StaticControl(this, ImportManagementPacksCloseDialog.ControlIDs.ManagementPackListStaticControl);
                }
                return this.cachedManagementPackListStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IImportManagementPacksCloseDialogControls.HelpButton
        {
            get
            {
                if ((this.cachedHelpButton == null))
                {
                    this.cachedHelpButton = new Button(this, ImportManagementPacksCloseDialog.ControlIDs.HelpButton);
                }
                return this.cachedHelpButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IImportManagementPacksCloseDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, ImportManagementPacksCloseDialog.ControlIDs.CloseButton);
                }
                return this.cachedCloseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackListListView control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IImportManagementPacksCloseDialogControls.ManagementPackListListView
        {
            get
            {
                if ((this.cachedManagementPackListListView == null))
                {
                    this.cachedManagementPackListListView = new ListView(this, ImportManagementPacksCloseDialog.ControlIDs.ManagementPackListListView);
                }
                return this.cachedManagementPackListListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackDetailsTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IImportManagementPacksCloseDialogControls.ManagementPackDetailsTextBox
        {
            get
            {
                if ((this.cachedManagementPackDetailsTextBox == null))
                {
                    this.cachedManagementPackDetailsTextBox = new TextBox(this, ImportManagementPacksCloseDialog.ControlIDs.ManagementPackDetailsTextBox);
                }
                return this.cachedManagementPackDetailsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackDetailsStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IImportManagementPacksCloseDialogControls.ManagementPackDetailsStaticControl
        {
            get
            {
                if ((this.cachedManagementPackDetailsStaticControl == null))
                {
                    this.cachedManagementPackDetailsStaticControl = new StaticControl(this, ImportManagementPacksCloseDialog.ControlIDs.ManagementPackDetailsStaticControl);
                }
                return this.cachedManagementPackDetailsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllManagementPacksSucessfullyImportedStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IImportManagementPacksCloseDialogControls.AllManagementPacksSucessfullyImportedStaticControl
        {
            get
            {
                if ((this.cachedAllManagementPacksSucessfullyImportedStaticControl == null))
                {
                    this.cachedAllManagementPacksSucessfullyImportedStaticControl = new StaticControl(this, ImportManagementPacksCloseDialog.ControlIDs.AllManagementPacksSucessfullyImportedStaticControl);
                }
                return this.cachedAllManagementPacksSucessfullyImportedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllManagementPacksSucessfullyImportedToolbar control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IImportManagementPacksCloseDialogControls.AllManagementPacksSucessfullyImportedToolbar
        {
            get
            {
                if ((this.cachedAllManagementPacksSucessfullyImportedToolbar == null))
                {
                    this.cachedAllManagementPacksSucessfullyImportedToolbar = new Toolbar(this, ImportManagementPacksCloseDialog.ControlIDs.AllManagementPacksSucessfullyImportedToolbar);
                }
                return this.cachedAllManagementPacksSucessfullyImportedToolbar;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Help
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHelp()
        {
            this.Controls.HelpButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
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
        ///  <param name="app">Mom.Test.UI.Core.Console.MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Mom.Test.UI.Core.Console.MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            
            catch (Exceptions.WindowNotFoundException)
            {
                // TODO:  Uncomment the following code and apply the appropriate command for invoking the dialog.
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
                                WindowClassNames.WinForms10Window8,
                                StringMatchSyntax.WildCard,
                                app,
                                Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure

                    // throw the existing WindowNotFound exception
                    throw;
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
        /// 	[faizalk] 3/25/2006 Created
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
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Import Management Packs;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPInstall.MPInstallDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementPackList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPackList = ";Management Pac&k List :;ManagedString;Microsoft.EnterpriseManagement.UI.Administ" +
                "ration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPInsta" +
                "ll.MPInstallDialog;mpListLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Administration.MPInstall.MPInstallDialog;" +
                "helpButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClose = ";Clo&se;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.MPInstall.MPInstallDialo" +
                "g;closeButton.Text";
                        
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementPackDetails
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPackDetails = ";      Management Pack Details : ;ManagedString;Microsoft.EnterpriseManagement.UI" +
                ".Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administratio" +
                "n.MPInstall.MPInstallResources;MPDetails";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AllManagementPacksSucessfullyImported
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllManagementPacksSucessfullyImported = ";All Management Packs sucessfully imported.;ManagedString;Microsoft.EnterpriseMan" +
                "agement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Adm" +
                "inistration.MPInstall.MPInstallResources;AllMPsImported";
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
            /// Caches the translated resource string for:  ManagementPackList
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPackList;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClose;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementPackDetails
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPackDetails;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AllManagementPacksSucessfullyImported
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAllManagementPacksSucessfullyImported;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
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
            /// Exposes access to the ManagementPackList translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementPackList
            {
                get
                {
                    if ((cachedManagementPackList == null))
                    {
                        cachedManagementPackList = CoreManager.MomConsole.GetIntlStr(ResourceManagementPackList);
                    }
                    return cachedManagementPackList;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Help
            {
                get
                {
                    if ((cachedHelp == null))
                    {
                        cachedHelp = CoreManager.MomConsole.GetIntlStr(ResourceHelp);
                    }
                    return cachedHelp;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Close translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
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
            /// Exposes access to the ManagementPackDetails translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementPackDetails
            {
                get
                {
                    if ((cachedManagementPackDetails == null))
                    {
                        cachedManagementPackDetails = CoreManager.MomConsole.GetIntlStr(ResourceManagementPackDetails);
                    }
                    return cachedManagementPackDetails;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AllManagementPacksSucessfullyImported translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AllManagementPacksSucessfullyImported
            {
                get
                {
                    if ((cachedAllManagementPacksSucessfullyImported == null))
                    {
                        cachedAllManagementPacksSucessfullyImported = CoreManager.MomConsole.GetIntlStr(ResourceAllManagementPacksSucessfullyImported);
                    }
                    return cachedAllManagementPacksSucessfullyImported;
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
        /// 	[faizalk] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ManagementPackListStaticControl
            /// </summary>
            public const string ManagementPackListStaticControl = "mpListLabel";
            
            /// <summary>
            /// Control ID for HelpButton
            /// </summary>
            public const string HelpButton = "helpButton";
            
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "closeButton";
            
            /// <summary>
            /// Control ID for ManagementPackListListView
            /// </summary>
            public const string ManagementPackListListView = "mpListView";
            
            /// <summary>
            /// Control ID for ManagementPackDetailsTextBox
            /// </summary>
            public const string ManagementPackDetailsTextBox = "detailsRTB";
            
            /// <summary>
            /// Control ID for ManagementPackDetailsStaticControl
            /// </summary>
            public const string ManagementPackDetailsStaticControl = "detailsLabel";
            
            /// <summary>
            /// Control ID for AllManagementPacksSucessfullyImportedStaticControl
            /// </summary>
            public const string AllManagementPacksSucessfullyImportedStaticControl = "introLabel";
            
            /// <summary>
            /// Control ID for AllManagementPacksSucessfullyImportedToolbar
            /// </summary>
            public const string AllManagementPacksSucessfullyImportedToolbar = "mainToolStrip";
        }
        #endregion
    }
}
