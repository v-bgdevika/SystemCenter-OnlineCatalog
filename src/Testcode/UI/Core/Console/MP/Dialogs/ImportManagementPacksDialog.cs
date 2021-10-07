// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ImportManagementPacksDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 3/22/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MP.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IImportManagementPacksDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IImportManagementPacksDialogControls, for ImportManagementPacksDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 3/22/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IImportManagementPacksDialogControls
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
        /// Read-only property to access ImportButton
        /// </summary>
        Button ImportButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
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
        /// Read-only property to access ThereAreNoManagementPacksInTheListWhichCanBeImportedStaticControl
        /// </summary>
        StaticControl ThereAreNoManagementPacksInTheListWhichCanBeImportedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ImportManagementPacksToolbar
        /// </summary>
        Toolbar ImportManagementPacksToolbar
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
    /// 	[faizalk] 3/22/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ImportManagementPacksDialog : Dialog, IImportManagementPacksDialogControls
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
        /// Cache to hold a reference to ImportButton of type Button
        /// </summary>
        private Button cachedImportButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
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
        /// Cache to hold a reference to ThereAreNoManagementPacksInTheListWhichCanBeImportedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedThereAreNoManagementPacksInTheListWhichCanBeImportedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ImportManagementPacksToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedImportManagementPacksToolbar;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ImportManagementPacksDialog of type CoreManager.MomConsole
        /// </param>
        /// <history>
        /// 	[faizalk] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ImportManagementPacksDialog(Mom.Test.UI.Core.Console.MomConsoleApp app)
            : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IImportManagementPacksDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IImportManagementPacksDialogControls Controls
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
        /// 	[faizalk] 3/22/2006 Created
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
        /// 	[faizalk] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IImportManagementPacksDialogControls.ManagementPackListStaticControl
        {
            get
            {
                if ((this.cachedManagementPackListStaticControl == null))
                {
                    this.cachedManagementPackListStaticControl = new StaticControl(this, ImportManagementPacksDialog.ControlIDs.ManagementPackListStaticControl);
                }
                return this.cachedManagementPackListStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IImportManagementPacksDialogControls.HelpButton
        {
            get
            {
                if ((this.cachedHelpButton == null))
                {
                    this.cachedHelpButton = new Button(this, ImportManagementPacksDialog.ControlIDs.HelpButton);
                }
                return this.cachedHelpButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ImportButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IImportManagementPacksDialogControls.ImportButton
        {
            get
            {
                if ((this.cachedImportButton == null))
                {
                    this.cachedImportButton = new Button(this, ImportManagementPacksDialog.ControlIDs.ImportButton);
                }
                return this.cachedImportButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IImportManagementPacksDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ImportManagementPacksDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackListListView control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IImportManagementPacksDialogControls.ManagementPackListListView
        {
            get
            {
                if ((this.cachedManagementPackListListView == null))
                {
                    this.cachedManagementPackListListView = new ListView(this, ImportManagementPacksDialog.ControlIDs.ManagementPackListListView);
                }
                return this.cachedManagementPackListListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackDetailsTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IImportManagementPacksDialogControls.ManagementPackDetailsTextBox
        {
            get
            {
                if ((this.cachedManagementPackDetailsTextBox == null))
                {
                    this.cachedManagementPackDetailsTextBox = new TextBox(this, ImportManagementPacksDialog.ControlIDs.ManagementPackDetailsTextBox);
                }
                return this.cachedManagementPackDetailsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackDetailsStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IImportManagementPacksDialogControls.ManagementPackDetailsStaticControl
        {
            get
            {
                if ((this.cachedManagementPackDetailsStaticControl == null))
                {
                    this.cachedManagementPackDetailsStaticControl = new StaticControl(this, ImportManagementPacksDialog.ControlIDs.ManagementPackDetailsStaticControl);
                }
                return this.cachedManagementPackDetailsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThereAreNoManagementPacksInTheListWhichCanBeImportedStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IImportManagementPacksDialogControls.ThereAreNoManagementPacksInTheListWhichCanBeImportedStaticControl
        {
            get
            {
                if ((this.cachedThereAreNoManagementPacksInTheListWhichCanBeImportedStaticControl == null))
                {
                    this.cachedThereAreNoManagementPacksInTheListWhichCanBeImportedStaticControl = new StaticControl(this, ImportManagementPacksDialog.ControlIDs.ThereAreNoManagementPacksInTheListWhichCanBeImportedStaticControl);
                }
                return this.cachedThereAreNoManagementPacksInTheListWhichCanBeImportedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ImportManagementPacksToolbar control
        /// </summary>
        /// <history>
        /// 	[mbickle] 09DEC06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IImportManagementPacksDialogControls.ImportManagementPacksToolbar
        {
            get
            {
                if ((this.cachedImportManagementPacksToolbar == null))
                {
                    this.cachedImportManagementPacksToolbar = new Toolbar(this);
                }
                return this.cachedImportManagementPacksToolbar;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Help
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHelp()
        {
            this.Controls.HelpButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Import
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickImport()
        {
            this.Controls.ImportButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[faizalk] 3/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">CoreManager.MomConsole owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 3/22/2006 Created
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
                const int MaxTries = 10;
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
        /// 	[faizalk] 3/22/2006 Created
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
            /// Contains resource string for:  Import
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceImport = ";Imp&ort;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.MPInstall.MPInstallDial" +
                "og;importButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
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
            /// Contains resource string for:  ThereAreNoManagementPacksInTheListWhichCanBeImported
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThereAreNoManagementPacksInTheListWhichCanBeImported = ";There are no Management Packs in the list which can be imported .;ManagedString;" +
                "Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.A" +
                "dministration.Pages.MPInstall.MPInstallResources;NoSuccessMP";
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
            /// Caches the translated resource string for:  Import
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedImport;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementPackDetails
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPackDetails;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ThereAreNoManagementPacksInTheListWhichCanBeImported
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThereAreNoManagementPacksInTheListWhichCanBeImported;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/22/2006 Created
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
            /// 	[faizalk] 3/22/2006 Created
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
            /// 	[faizalk] 3/22/2006 Created
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
            /// Exposes access to the Import translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Import
            {
                get
                {
                    if ((cachedImport == null))
                    {
                        cachedImport = CoreManager.MomConsole.GetIntlStr(ResourceImport);
                    }
                    return cachedImport;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    if ((cachedCancel == null))
                    {
                        cachedCancel = CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                    }
                    return cachedCancel;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementPackDetails translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/22/2006 Created
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
            /// Exposes access to the ThereAreNoManagementPacksInTheListWhichCanBeImported translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 3/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThereAreNoManagementPacksInTheListWhichCanBeImported
            {
                get
                {
                    if ((cachedThereAreNoManagementPacksInTheListWhichCanBeImported == null))
                    {
                        cachedThereAreNoManagementPacksInTheListWhichCanBeImported = CoreManager.MomConsole.GetIntlStr(ResourceThereAreNoManagementPacksInTheListWhichCanBeImported);
                    }
                    return cachedThereAreNoManagementPacksInTheListWhichCanBeImported;
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
        /// 	[faizalk] 3/22/2006 Created
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
            /// Control ID for ImportButton
            /// </summary>
            public const string ImportButton = "importButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
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
            /// Control ID for ThereAreNoManagementPacksInTheListWhichCanBeImportedStaticControl
            /// </summary>
            public const string ThereAreNoManagementPacksInTheListWhichCanBeImportedStaticControl = "introLabel";
            
            /// <summary>
            /// Control ID for ImportManagementPacksToolbar
            /// </summary>
            public const string ImportManagementPacksToolbar = "mainToolStrip";
        }
        #endregion
    }
}
