// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CreateNewFavoriteFolderDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	Favorites Create New Folder Dialog.
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
    
    #region Interface Definition - ICreateNewFavoriteFolderDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICreateNewFavoriteFolderDialogControls, for CreateNewFolderDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 01MAY06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICreateNewFavoriteFolderDialogControls
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
        /// Read-only property to access FolderNameTextBox
        /// </summary>
        TextBox FolderNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FolderNameStaticControl
        /// </summary>
        StaticControl FolderNameStaticControl
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
    public class CreateNewFavoriteFolderDialog : Dialog, ICreateNewFavoriteFolderDialogControls
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
        /// Cache to hold a reference to FolderNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedFolderNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to FolderNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFolderNameStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of CreateNewFolderDialog of type App
        /// </param>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateNewFavoriteFolderDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ICreateNewFolderDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICreateNewFavoriteFolderDialogControls Controls
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
        ///  Routine to set/get the text in control FolderName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string FolderNameText
        {
            get
            {
                return this.Controls.FolderNameTextBox.Text;
            }
            
            set
            {
                //this.Controls.FolderNameTextBox.Text = value;
                this.Controls.FolderNameTextBox.SendKeys(value);
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
        Button ICreateNewFavoriteFolderDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CreateNewFavoriteFolderDialog.ControlIDs.CancelButton);
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
        Button ICreateNewFavoriteFolderDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, CreateNewFavoriteFolderDialog.ControlIDs.OKButton);
                }

                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FolderNameTextBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateNewFavoriteFolderDialogControls.FolderNameTextBox
        {
            get
            {
                if ((this.cachedFolderNameTextBox == null))
                {
                    this.cachedFolderNameTextBox = new TextBox(this, CreateNewFavoriteFolderDialog.ControlIDs.FolderNameTextBox);
                }

                return this.cachedFolderNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FolderNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 01MAY06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateNewFavoriteFolderDialogControls.FolderNameStaticControl
        {
            get
            {
                if ((this.cachedFolderNameStaticControl == null))
                {
                    this.cachedFolderNameStaticControl = new StaticControl(this, CreateNewFavoriteFolderDialog.ControlIDs.FolderNameStaticControl);
                }

                return this.cachedFolderNameStaticControl;
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
            private const string ResourceDialogTitle = ";Create New Folder;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.NewFolderDlg;$this.Text";
            
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
            /// Contains resource string for:  FolderName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFolderName = ";&Folder name:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.Console.WunderBarPages.Favorites.NewFolderDlg;nameLab" +
                "el.Text";
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
            /// Caches the translated resource string for:  FolderName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFolderName;
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
            /// Exposes access to the FolderName translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FolderName
            {
                get
                {
                    if ((cachedFolderName == null))
                    {
                        cachedFolderName = CoreManager.MomConsole.GetIntlStr(ResourceFolderName);
                    }

                    return cachedFolderName;
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
            /// Control ID for FolderNameTextBox
            /// </summary>
            public const string FolderNameTextBox = "folderNameText";
            
            /// <summary>
            /// Control ID for FolderNameStaticControl
            /// </summary>
            public const string FolderNameStaticControl = "nameLabel";
        }
        #endregion
    }
}
