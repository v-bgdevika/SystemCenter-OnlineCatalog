// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="BrowseForFolderDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[mbickle] 28-Feb-06 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IBrowseForFolderDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IBrowseForFolderDialogControls, for BrowseForFolderDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 28-Feb-06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IBrowseForFolderDialogControls
    {
        /// <summary>
        /// Read-only property to access StaticControl0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        StaticControl StaticControl0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TreeView
        /// </summary>
        TreeView TreeView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MakeNewFolderButton
        /// </summary>
        Button MakeNewFolderButton
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
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
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
    /// 	[mbickle] 28-Feb-06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class BrowseForFolderDialog : Dialog, IBrowseForFolderDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to StaticControl0 of type StaticControl
        /// </summary>
        private StaticControl cachedStaticControl0;
        
        /// <summary>
        /// Cache to hold a reference to TreeView of type TreeView
        /// </summary>
        private TreeView cachedTreeView;
        
        /// <summary>
        /// Cache to hold a reference to MakeNewFolderButton of type Button
        /// </summary>
        private Button cachedMakeNewFolderButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of BrowseForFolderDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[mbickle] 28-Feb-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public BrowseForFolderDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IBrowseForFolderDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 28-Feb-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IBrowseForFolderDialogControls Controls
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
        ///  Exposes access to the StaticControl0 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 28-Feb-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBrowseForFolderDialogControls.StaticControl0
        {
            get
            {
                if ((this.cachedStaticControl0 == null))
                {
                    this.cachedStaticControl0 = new StaticControl(this, BrowseForFolderDialog.ControlIDs.StaticControl0);
                }

                return this.cachedStaticControl0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TreeView control
        /// </summary>
        /// <history>
        /// 	[mbickle] 28-Feb-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView IBrowseForFolderDialogControls.TreeView
        {
            get
            {
                if ((this.cachedTreeView == null))
                {
                    this.cachedTreeView = new TreeView(this, BrowseForFolderDialog.ControlIDs.TreeView);
                }

                return this.cachedTreeView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MakeNewFolderButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 28-Feb-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBrowseForFolderDialogControls.MakeNewFolderButton
        {
            get
            {
                if ((this.cachedMakeNewFolderButton == null))
                {
                    this.cachedMakeNewFolderButton = new Button(this, BrowseForFolderDialog.ControlIDs.MakeNewFolderButton);
                }

                return this.cachedMakeNewFolderButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 28-Feb-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBrowseForFolderDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, BrowseForFolderDialog.ControlIDs.OKButton);
                }

                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 28-Feb-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBrowseForFolderDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, BrowseForFolderDialog.ControlIDs.CancelButton);
                }

                return this.cachedCancelButton;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button MakeNewFolder
        /// </summary>
        /// <history>
        /// 	[mbickle] 28-Feb-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMakeNewFolder()
        {
            this.Controls.MakeNewFolderButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[mbickle] 28-Feb-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[mbickle] 28-Feb-06 Created
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
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[mbickle] 28-Feb-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.Dialog,
                    StringMatchSyntax.ExactMatch,
                    app,
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException)
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
                        Core.Common.Utilities.LogMessage(
                            "BrowseForFolderDialog:: Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "BrowseForFolderDialog:: Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");

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
        /// 	[mbickle] 28-Feb-06 Created
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
            private const string ResourceDialogTitle = ";Browse For Folder;Win32DialogString;shell32.dll;1087";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MakeNewFolder
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMakeNewFolder = ";&Make New Folder;Win32DialogItemString;shell32.dll;1087;14150";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = "OK";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = "Cancel";
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
            /// Caches the translated resource string for:  MakeNewFolder
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMakeNewFolder;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 28-Feb-06 Created
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
            /// Exposes access to the MakeNewFolder translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 28-Feb-06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MakeNewFolder
            {
                get
                {
                    if ((cachedMakeNewFolder == null))
                    {
                        cachedMakeNewFolder = CoreManager.MomConsole.GetIntlStr(ResourceMakeNewFolder);
                    }

                    return cachedMakeNewFolder;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 28-Feb-06 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 28-Feb-06 Created
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
            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[mbickle] 28-Feb-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for StaticControl0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const int StaticControl0 = 14146;
            
            /// <summary>
            /// Control ID for TreeView
            /// </summary>
            public const int TreeView = 100;
            
            /// <summary>
            /// Control ID for MakeNewFolderButton
            /// </summary>
            public const int MakeNewFolderButton = 14150;
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const int OKButton = 1;
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const int CancelButton = 2;
        }
        #endregion
    }
}
