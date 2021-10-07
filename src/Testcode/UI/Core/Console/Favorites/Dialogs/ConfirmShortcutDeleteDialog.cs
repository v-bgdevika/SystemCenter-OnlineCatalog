// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConfirmShortcutDeleteDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[sunsingh] 2/18/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Favorites.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IConfirmShortcutDeleteDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IConfirmShortcutDeleteDialogControls, for ConfirmShortcutDeleteDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[sunsingh] 2/18/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IConfirmShortcutDeleteDialogControls
    {
        /// <summary>
        /// Read-only property to access ToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenuStaticControl
        /// </summary>
        StaticControl ToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenuStaticControl
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
        /// Read-only property to access DeleteShortcutButton
        /// </summary>
        Button DeleteShortcutButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheViewStaticControl
        /// </summary>
        StaticControl DeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheViewStaticControl
        {
            get;
        }
        
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[sunsingh] 2/18/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ConfirmShortcutDeleteDialog : Dialog, IConfirmShortcutDeleteDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenuStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenuStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to DeleteShortcutButton of type Button
        /// </summary>
        private Button cachedDeleteShortcutButton;
        
        /// <summary>
        /// Cache to hold a reference to DeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheViewStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheViewStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StaticControl0 of type StaticControl
        /// </summary>
        private StaticControl cachedStaticControl0;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ConfirmShortcutDeleteDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[sunsingh] 2/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ConfirmShortcutDeleteDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IConfirmShortcutDeleteDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[sunsingh] 2/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IConfirmShortcutDeleteDialogControls Controls
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
        ///  Exposes access to the ToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenuStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 2/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfirmShortcutDeleteDialogControls.ToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenuStaticControl
        {
            get
            {
                if ((this.cachedToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenuStaticControl == null))
                {
                    this.cachedToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenuStaticControl = new StaticControl(this, ConfirmShortcutDeleteDialog.ControlIDs.ToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenuStaticControl);
                }
                return this.cachedToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenuStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 2/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfirmShortcutDeleteDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ConfirmShortcutDeleteDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DeleteShortcutButton control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 2/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfirmShortcutDeleteDialogControls.DeleteShortcutButton
        {
            get
            {
                if ((this.cachedDeleteShortcutButton == null))
                {
                    this.cachedDeleteShortcutButton = new Button(this, ConfirmShortcutDeleteDialog.ControlIDs.DeleteShortcutButton);
                }
                return this.cachedDeleteShortcutButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DeletingTheShortcutÄÅoOnlyRemovesTheShortcutItDoesNotDeleteTheViewStaticControl control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 2/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfirmShortcutDeleteDialogControls.DeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheViewStaticControl
        {
            get
            {
                if ((this.cachedDeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheViewStaticControl == null))
                {
                    this.cachedDeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheViewStaticControl = new StaticControl(this, ConfirmShortcutDeleteDialog.ControlIDs.DeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheViewStaticControl);
                }
                return this.cachedDeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheViewStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StaticControl0 control
        /// </summary>
        /// <history>
        /// 	[sunsingh] 2/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfirmShortcutDeleteDialogControls.StaticControl0
        {
            get
            {
                if ((this.cachedStaticControl0 == null))
                {
                    this.cachedStaticControl0 = new StaticControl(this, ConfirmShortcutDeleteDialog.ControlIDs.StaticControl0);
                }
                return this.cachedStaticControl0;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[sunsingh] 2/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button DeleteShortcut
        /// </summary>
        /// <history>
        /// 	[sunsingh] 2/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDeleteShortcut()
        {
            this.Controls.DeleteShortcutButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[sunsingh] 2/18/2009 Created
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
        /// 	[sunsingh] 2/18/2009 Created
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
            private const string ResourceDialogTitle = ";Confirm Shortcut Delete;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.DeleteShortcutConfirmDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenu = ";To delete the view, go to Monitoring and select Delete View from the context men" +
                "u.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement." +
                "Mom.Internal.UI.Console.WunderBarPages.Favorites.DeleteShortcutConfirmDialog;lin" +
                "e2Label.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DeleteShortcut
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDeleteShortcut = ";&Delete Shortcut;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.DeleteShortcutCon" +
                "firmDialog;deleteShortcutButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheView
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheView = "Deleting the shortcut ÄÅo only removes the shortcut, it does not delete the view." +
                "";
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
            /// Caches the translated resource string for:  ToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenu;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DeleteShortcut
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDeleteShortcut;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheView
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheView;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 2/18/2009 Created
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
            /// Exposes access to the ToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 2/18/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenu
            {
                get
                {
                    if ((cachedToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenu == null))
                    {
                        cachedToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenu);
                    }
                    return cachedToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenu;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 2/18/2009 Created
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
            /// Exposes access to the DeleteShortcut translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 2/18/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DeleteShortcut
            {
                get
                {
                    if ((cachedDeleteShortcut == null))
                    {
                        cachedDeleteShortcut = CoreManager.MomConsole.GetIntlStr(ResourceDeleteShortcut);
                    }
                    return cachedDeleteShortcut;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheView translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 2/18/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheView
            {
                get
                {
                    if ((cachedDeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheView == null))
                    {
                        cachedDeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheView = CoreManager.MomConsole.GetIntlStr(ResourceDeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheView);
                    }
                    return cachedDeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheView;
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
        /// 	[sunsingh] 2/18/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenuStaticControl
            /// </summary>
            public const string ToDeleteTheViewGoToMonitoringAndSelectDeleteViewFromTheContextMenuStaticControl = "line2Label";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for DeleteShortcutButton
            /// </summary>
            public const string DeleteShortcutButton = "deleteShortcutButton";
            
            /// <summary>
            /// Control ID for DeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheViewStaticControl
            /// </summary>
            public const string DeletingTheShortcutOnlyRemovesTheShortcutItDoesNotDeleteTheViewStaticControl = "line1Label";
            
            /// <summary>
            /// Control ID for StaticControl0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string StaticControl0 = "shortcutImageLabel";
        }
        #endregion
    }
}
