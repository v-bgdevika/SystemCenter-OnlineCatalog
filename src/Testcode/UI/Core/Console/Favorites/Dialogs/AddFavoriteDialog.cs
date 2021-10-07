// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AddFavoriteDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	Add Favorite Dialog
// </summary>
// <history>
// 	[mbickle] 01MAY06 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Favorites.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    #endregion

    #region Interface Definition - IAddFavoriteDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAddFavoriteDialogControls, for AddFavoriteDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 01MAY06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddFavoriteDialogControls
    {
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl
        /// </summary>
        StaticControl EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NewFolderButton
        /// </summary>
        Button NewFolderButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CreateInTreeView
        /// </summary>
        TreeView CreateInTreeView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CreateInStaticControl
        /// </summary>
        StaticControl CreateInStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CreateInButton
        /// </summary>
        Button CreateInButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NameTextBox
        /// </summary>
        TextBox NameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NameStaticControl
        /// </summary>
        StaticControl NameStaticControl
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
    public class AddFavoriteDialog : Dialog, IAddFavoriteDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 10000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NewFolderButton of type Button
        /// </summary>
        private Button cachedNewFolderButton;
        
        /// <summary>
        /// Cache to hold a reference to CreateInTreeView of type TreeView
        /// </summary>
        private TreeView cachedCreateInTreeView;
        
        /// <summary>
        /// Cache to hold a reference to CreateInStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCreateInStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CreateInButton of type Button
        /// </summary>
        private Button cachedCreateInButton;
        
        /// <summary>
        /// Cache to hold a reference to NameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to NameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNameStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AddFavoriteDialog of type App
        /// </param>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AddFavoriteDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAddFavoriteDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAddFavoriteDialogControls Controls
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
        ///  Routine to set/get the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NameText
        {
            get
            {
                return this.Controls.NameTextBox.Text;
            }
            
            set
            {
                //this.Controls.NameTextBox.Text = value;
                this.Controls.NameTextBox.SendKeys(value);

            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddFavoriteDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AddFavoriteDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddFavoriteDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AddFavoriteDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddFavoriteDialogControls.EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl
        {
            get
            {
                if ((this.cachedEnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl == null))
                {
                    this.cachedEnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl = new StaticControl(this, AddFavoriteDialog.ControlIDs.EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl);
                }
                return this.cachedEnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NewFolderButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddFavoriteDialogControls.NewFolderButton
        {
            get
            {
                if ((this.cachedNewFolderButton == null))
                {
                    this.cachedNewFolderButton = new Button(this, AddFavoriteDialog.ControlIDs.NewFolderButton);
                }
                return this.cachedNewFolderButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateInTreeView control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView IAddFavoriteDialogControls.CreateInTreeView
        {
            get
            {
                if ((this.cachedCreateInTreeView == null))
                {
                    this.cachedCreateInTreeView = new TreeView(this, AddFavoriteDialog.ControlIDs.CreateInTreeView);
                }
                return this.cachedCreateInTreeView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateInStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddFavoriteDialogControls.CreateInStaticControl
        {
            get
            {
                if ((this.cachedCreateInStaticControl == null))
                {
                    this.cachedCreateInStaticControl = new StaticControl(this, AddFavoriteDialog.ControlIDs.CreateInStaticControl);
                }
                return this.cachedCreateInStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateInButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddFavoriteDialogControls.CreateInButton
        {
            get
            {
                if ((this.cachedCreateInButton == null))
                {
                    this.cachedCreateInButton = new Button(this, AddFavoriteDialog.ControlIDs.CreateInButton);
                }
                return this.cachedCreateInButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddFavoriteDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, AddFavoriteDialog.ControlIDs.NameTextBox);
                }
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddFavoriteDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, AddFavoriteDialog.ControlIDs.NameStaticControl);
                }
                return this.cachedNameStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button NewFolder
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNewFolder()
        {
            this.Controls.NewFolderButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button CreateInExpanded
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreateIn()
        {
            this.Controls.CreateInButton.Click();
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
                        tempWindow = new Window(
                            Strings.DialogTitle,
                            StringMatchSyntax.ExactMatch,
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
            private const string ResourceDialogTitle = ";Add Favorite;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.AddToFavoritesDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;DC01.bT;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewIn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewIn = ";Enter a name for this view and select which folder you want to store this view i" +
                "n.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement." +
                "Mom.Internal.UI.Console.WunderBarPages.Favorites.AddToFavoritesDialog;descriptio" +
                "n.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NewFolder
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNewFolder = ";N&ew Folder...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpris" +
                "eManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.AddToFavoritesDialo" +
                "g;newFolderBtn.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CreateIn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreateIn = ";Create &in:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.AddToFavoritesDialog;c" +
                "reateInLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CreateInExpanded
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreateInExpanded = ";&Create In <<;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.AddToFavoritesResources;CreateInButtonExpanded";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CreateInCollapsed
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreateInCollapsed = ";&Create In >>;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.AddToFavoritesResources;CreateInButtonShrunk";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceName = ";&Name:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Internal.UI.Authoring.Pages.EditRegistryProbeDialog;idLabelName.Text";
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
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewIn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewIn;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NewFolder
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNewFolder;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CreateIn
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreateIn;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CreateInExpanded
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreateInExpanded;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CreateInCollapsed
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreateInCollapsed;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedName;
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    return cachedOK;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewIn translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewIn
            {
                get
                {
                    if ((cachedEnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewIn == null))
                    {
                        cachedEnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewIn = CoreManager.MomConsole.GetIntlStr(ResourceEnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewIn);
                    }
                    return cachedEnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewIn;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NewFolder translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NewFolder
            {
                get
                {
                    if ((cachedNewFolder == null))
                    {
                        cachedNewFolder = CoreManager.MomConsole.GetIntlStr(ResourceNewFolder);
                    }
                    return cachedNewFolder;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CreateIn translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreateIn
            {
                get
                {
                    if ((cachedCreateIn == null))
                    {
                        cachedCreateIn = CoreManager.MomConsole.GetIntlStr(ResourceCreateIn);
                    }
                    return cachedCreateIn;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CreateInExpanded translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreateInExpanded
            {
                get
                {
                    if ((cachedCreateInExpanded == null))
                    {
                        cachedCreateInExpanded = CoreManager.MomConsole.GetIntlStr(ResourceCreateInExpanded);
                    }
                    return cachedCreateInExpanded;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CreateInCollapsed translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreateInCollapsed
            {
                get
                {
                    if ((cachedCreateInCollapsed == null))
                    {
                        cachedCreateInCollapsed = CoreManager.MomConsole.GetIntlStr(ResourceCreateInCollapsed);
                    }
                    return cachedCreateInCollapsed;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Name
            {
                get
                {
                    if ((cachedName == null))
                    {
                        cachedName = CoreManager.MomConsole.GetIntlStr(ResourceName);
                    }
                    return cachedName;
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
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelBtn";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okBtn";
            
            /// <summary>
            /// Control ID for EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl
            /// </summary>
            public const string EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl = "description";
            
            /// <summary>
            /// Control ID for NewFolderButton
            /// </summary>
            public const string NewFolderButton = "newFolderBtn";
            
            /// <summary>
            /// Control ID for CreateInTreeView
            /// </summary>
            public const string CreateInTreeView = "treeView1";
            
            /// <summary>
            /// Control ID for CreateInStaticControl
            /// </summary>
            public const string CreateInStaticControl = "createInLabel";
            
            /// <summary>
            /// Control ID for CreateInButton
            /// </summary>
            public const string CreateInButton = "createInBtn";
            
            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "favoriteName";
            
            /// <summary>
            /// Control ID for NameStaticControl
            /// </summary>
            public const string NameStaticControl = "nameLabel";
        }
        #endregion
    }
}
