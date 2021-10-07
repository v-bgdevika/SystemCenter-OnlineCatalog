// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConfirmUserRoleDeleteDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[ruhim] 12-Aug-05 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.UserRole.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
        
    #region Interface Definition - IConfirmUserRoleDeleteDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IConfirmUserRoleDeleteDialogControls, for ConfirmUserRoleDeleteDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 12-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IConfirmUserRoleDeleteDialogControls
    {
        /// <summary>
        /// Read-only property to access YesButton
        /// </summary>
        Button YesButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NoButton
        /// </summary>
        Button NoButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AreYouSureYouWantToDeleteTheSelectedUserRolesStaticControl
        /// </summary>
        StaticControl AreYouSureYouWantToDeleteTheSelectedUserRolesStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the User Role Properties's
    /// "Confirm User Role Delete" screen. 
    /// </summary>
    /// <history>
    /// 	[ruhim] 12-Aug-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ConfirmUserRoleDeleteDialog : Dialog, IConfirmUserRoleDeleteDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to YesButton of type Button
        /// </summary>
        private Button cachedYesButton;
        
        /// <summary>
        /// Cache to hold a reference to NoButton of type Button
        /// </summary>
        private Button cachedNoButton;
        
        /// <summary>
        /// Cache to hold a reference to AreYouSureYouWantToDeleteTheSelectedUserRolesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAreYouSureYouWantToDeleteTheSelectedUserRolesStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ConfirmUserRoleDeleteDialog of type Maui.Core.App
        /// </param>
        /// <history>
        /// 	[ruhim] 12-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ConfirmUserRoleDeleteDialog(Maui.Core.App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IConfirmUserRoleDeleteDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 12-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IConfirmUserRoleDeleteDialogControls Controls
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
        ///  Exposes access to the YesButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 12-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfirmUserRoleDeleteDialogControls.YesButton
        {
            get
            {
                if ((this.cachedYesButton == null))
                {
                    this.cachedYesButton = new Button(this, ConfirmUserRoleDeleteDialog.ControlIDs.YesButton);
                }
                return this.cachedYesButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 12-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConfirmUserRoleDeleteDialogControls.NoButton
        {
            get
            {
                if ((this.cachedNoButton == null))
                {
                    this.cachedNoButton = new Button(this, ConfirmUserRoleDeleteDialog.ControlIDs.NoButton);
                }
                return this.cachedNoButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AreYouSureYouWantToDeleteTheSelectedUserRolesStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 12-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConfirmUserRoleDeleteDialogControls.AreYouSureYouWantToDeleteTheSelectedUserRolesStaticControl
        {
            get
            {
                if ((this.cachedAreYouSureYouWantToDeleteTheSelectedUserRolesStaticControl == null))
                {
                    this.cachedAreYouSureYouWantToDeleteTheSelectedUserRolesStaticControl = new StaticControl(this, ConfirmUserRoleDeleteDialog.ControlIDs.AreYouSureYouWantToDeleteTheSelectedUserRolesStaticControl);
                }
                return this.cachedAreYouSureYouWantToDeleteTheSelectedUserRolesStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Yes
        /// </summary>
        /// <history>
        /// 	[ruhim] 12-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickYes()
        {
            this.Controls.YesButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button No
        /// </summary>
        /// <history>
        /// 	[ruhim] 12-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNo()
        {
            this.Controls.NoButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">Maui.Core.App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 12-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                                Strings.DialogTitle + "*",
                                StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
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
                
        /// <history>
        /// 	[ruhim] 12-Aug-05 Created
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
            private const string ResourceDialogTitle = //"Confirm User Role Delete";
            ";Confirm User Role Delete;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;UserRoleDeleteTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Yes
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceYes = "&Yes";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  No
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceNo = "&No";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AreYouSureYouWantToDeleteTheSelectedUserRoles
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceAreYouSureYouWantToDeleteTheSelectedUserRoles = //"Are you sure you want to delete the selected user role(s)?";
                ";Are you sure you want to delete the selected user role(s)?;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;UserRoleDeleteDescription";
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
            /// Caches the translated resource string for:  Yes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYes;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  No
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNo;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AreYouSureYouWantToDeleteTheSelectedUserRoles
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAreYouSureYouWantToDeleteTheSelectedUserRoles;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 12-Aug-05 Created
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
            /// Exposes access to the Yes translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 12-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Yes
            {
                get
                {
                    if ((cachedYes == null))
                    {
                        cachedYes = CoreManager.MomConsole.GetIntlStr(ResourceYes);
                    }
                    return cachedYes;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the No translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 12-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string No
            {
                get
                {
                    if ((cachedNo == null))
                    {
                        cachedNo = CoreManager.MomConsole.GetIntlStr(ResourceNo);
                    }
                    return cachedNo;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AreYouSureYouWantToDeleteTheSelectedUserRoles translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 12-Aug-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AreYouSureYouWantToDeleteTheSelectedUserRoles
            {
                get
                {
                    if ((cachedAreYouSureYouWantToDeleteTheSelectedUserRoles == null))
                    {
                        cachedAreYouSureYouWantToDeleteTheSelectedUserRoles = CoreManager.MomConsole.GetIntlStr(ResourceAreYouSureYouWantToDeleteTheSelectedUserRoles);
                    }
                    return cachedAreYouSureYouWantToDeleteTheSelectedUserRoles;
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
        /// 	[ruhim] 12-Aug-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for YesButton
            /// </summary>
            public const int YesButton = 6;
            
            /// <summary>
            /// Control ID for NoButton
            /// </summary>
            public const int NoButton = 7;
            
            /// <summary>
            /// Control ID for AreYouSureYouWantToDeleteTheSelectedUserRolesStaticControl
            /// </summary>
            public const int AreYouSureYouWantToDeleteTheSelectedUserRolesStaticControl = 65535;
        }
        #endregion
    }
}
