// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AddToMyWorkspaceDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[dialac] 6/4/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.DashView
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IAddToMyWorkspaceDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAddToMyWorkspaceDialogControls, for AddToMyWorkspaceDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 6/4/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddToMyWorkspaceDialogControls
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
    /// 	[dialac] 6/4/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AddToMyWorkspaceDialog : Dialog, IAddToMyWorkspaceDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
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
        /// Owner of AddToMyWorkspaceDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 6/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AddToMyWorkspaceDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAddToMyWorkspaceDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 6/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAddToMyWorkspaceDialogControls Controls
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
        /// 	[dialac] 6/4/2008 Created
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
                this.Controls.NameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddToMyWorkspaceDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AddToMyWorkspaceDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddToMyWorkspaceDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AddToMyWorkspaceDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddToMyWorkspaceDialogControls.EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl
        {
            get
            {
                if ((this.cachedEnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl == null))
                {
                    this.cachedEnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl = new StaticControl(this, AddToMyWorkspaceDialog.ControlIDs.EnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl);
                }
                
                return this.cachedEnterANameForThisViewAndSelectWhichFolderYouWantToStoreThisViewInStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NewFolderButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddToMyWorkspaceDialogControls.NewFolderButton
        {
            get
            {
                if ((this.cachedNewFolderButton == null))
                {
                    this.cachedNewFolderButton = new Button(this, AddToMyWorkspaceDialog.ControlIDs.NewFolderButton);
                }
                
                return this.cachedNewFolderButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateInTreeView control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView IAddToMyWorkspaceDialogControls.CreateInTreeView
        {
            get
            {
                if ((this.cachedCreateInTreeView == null))
                {
                    this.cachedCreateInTreeView = new TreeView(this, AddToMyWorkspaceDialog.ControlIDs.CreateInTreeView);
                }
                
                return this.cachedCreateInTreeView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateInStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddToMyWorkspaceDialogControls.CreateInStaticControl
        {
            get
            {
                if ((this.cachedCreateInStaticControl == null))
                {
                    this.cachedCreateInStaticControl = new StaticControl(this, AddToMyWorkspaceDialog.ControlIDs.CreateInStaticControl);
                }
                
                return this.cachedCreateInStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateInButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddToMyWorkspaceDialogControls.CreateInButton
        {
            get
            {
                if ((this.cachedCreateInButton == null))
                {
                    this.cachedCreateInButton = new Button(this, AddToMyWorkspaceDialog.ControlIDs.CreateInButton);
                }
                
                return this.cachedCreateInButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddToMyWorkspaceDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, AddToMyWorkspaceDialog.ControlIDs.NameTextBox);
                }
                
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 6/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddToMyWorkspaceDialogControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, AddToMyWorkspaceDialog.ControlIDs.NameStaticControl);
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
        /// 	[dialac] 6/4/2008 Created
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
        /// 	[dialac] 6/4/2008 Created
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
        /// 	[dialac] 6/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNewFolder()
        {
            this.Controls.NewFolderButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button CreateIn2
        /// </summary>
        /// <history>
        /// 	[dialac] 6/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreateIn2()
        {
            this.Controls.CreateInButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[dialac] 6/4/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                //tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
                tempWindow = new Window(Strings.DialogTitle,
                                        StringMatchSyntax.ExactMatch,
                                        WindowClassNames.Dialog,
                                        StringMatchSyntax.ExactMatch,
                                        app.MainWindow,
                                        Timeout);

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
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);

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
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[dialac] 6/4/2008 Created
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
            //private const string ResourceDialogTitle = "Add To My Workspace";
            private const string ResourceDialogTitle = ";Add To My Workspace;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.AddToFavoritesDialog;$this.Text";

            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
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
            /// Contains resource string for:  CreateIn2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreateIn2 = ";&Create In <<;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.Console.WunderBarPages.Favorites.AddToFavoritesDialog" +
                ";createInBtn.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceName = ";&Name:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.EditRegistryProbeDialog;idLabelN" +
                "ame.Text";
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
            /// Caches the translated resource string for:  CreateIn2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreateIn2;
            
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
            /// 	[dialac] 6/4/2008 Created
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
            /// 	[dialac] 6/4/2008 Created
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
            /// 	[dialac] 6/4/2008 Created
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
            /// 	[dialac] 6/4/2008 Created
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
            /// 	[dialac] 6/4/2008 Created
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
            /// 	[dialac] 6/4/2008 Created
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
            /// Exposes access to the CreateIn2 translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/4/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreateIn2
            {
                get
                {
                    if ((cachedCreateIn2 == null))
                    {
                        cachedCreateIn2 = CoreManager.MomConsole.GetIntlStr(ResourceCreateIn2);
                    }
                    
                    return cachedCreateIn2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 6/4/2008 Created
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
        /// 	[dialac] 6/4/2008 Created
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
