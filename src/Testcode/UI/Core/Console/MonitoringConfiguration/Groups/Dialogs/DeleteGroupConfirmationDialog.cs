// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DeleteGroupConfirmationDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[HainingW] 3/25/2006 Created
//  [KellyMor] 12-Jun-08 Fixed missing delay bug in retry loop catch block 
//                       in Init method
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Groups.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IDeleteGroupConfirmationDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDeleteGroupConfirmationDialogControls, for DeleteGroupConfirmationDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[HainingW] 3/25/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDeleteGroupConfirmationDialogControls
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
        /// Read-only property to access AreYouSureYouWantToDeleteThisGroupStaticControl
        /// </summary>
        StaticControl AreYouSureYouWantToDeleteThisGroupStaticControl
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
    /// 	[HainingW] 3/25/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class DeleteGroupConfirmationDialog : Dialog, IDeleteGroupConfirmationDialogControls
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
        /// Cache to hold a reference to AreYouSureYouWantToDeleteThisGroupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAreYouSureYouWantToDeleteThisGroupStaticControl;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class constructor - with no dialog title passed in.
        /// </summary>
        /// <param name='app'>
        /// Owner of DeleteGroupConfirmationDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[HainingW] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DeleteGroupConfirmationDialog(MomConsoleApp app) 
            : base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Timeout);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class constructor - with dialog title passed in.
        /// </summary>
        /// <param name='app'>
        /// Owner of DeleteGroupConfirmationDialog of type MomConsoleApp
        /// </param>
        /// <param name="title">Alternative title of dialog</param>
        /// <history>
        /// 	[HainingW] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DeleteGroupConfirmationDialog(MomConsoleApp app, string title)
            : base(app, Init(app, title))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Timeout);
        }

        #endregion
        
        #region IDeleteGroupConfirmationDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[HainingW] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDeleteGroupConfirmationDialogControls Controls
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
        /// 	[HainingW] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDeleteGroupConfirmationDialogControls.YesButton
        {
            get
            {
                if ((this.cachedYesButton == null))
                {
                    this.cachedYesButton = new Button(this, DeleteGroupConfirmationDialog.ControlIDs.YesButton);
                }
                return this.cachedYesButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoButton control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDeleteGroupConfirmationDialogControls.NoButton
        {
            get
            {
                if ((this.cachedNoButton == null))
                {
                    this.cachedNoButton = new Button(this, DeleteGroupConfirmationDialog.ControlIDs.NoButton);
                }
                return this.cachedNoButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AreYouSureYouWantToDeleteThisGroupStaticControl control
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDeleteGroupConfirmationDialogControls.AreYouSureYouWantToDeleteThisGroupStaticControl
        {
            get
            {
                if ((this.cachedAreYouSureYouWantToDeleteThisGroupStaticControl == null))
                {
                    this.cachedAreYouSureYouWantToDeleteThisGroupStaticControl = new StaticControl(this, DeleteGroupConfirmationDialog.ControlIDs.AreYouSureYouWantToDeleteThisGroupStaticControl);
                }
                return this.cachedAreYouSureYouWantToDeleteThisGroupStaticControl;
            }
        }

        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Yes
        /// </summary>
        /// <history>
        /// 	[HainingW] 3/25/2006 Created
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
        /// 	[HainingW] 3/25/2006 Created
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
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[HainingW] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            Utilities.LogMessage("DeleteGroupConfirmationDialog :: Init(app)");
            Window tempWindow = Init(app, Strings.DialogTitle);
            return tempWindow;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <param name="title">Alternative title of dialog</param>
        /// <history>
        /// 	[HainingW] 3/25/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app, string title)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            Utilities.LogMessage("DeleteGroupConfirmationDialog :: Init(app, title)");

            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(title,
                                        StringMatchSyntax.ExactMatch,
                                        WindowClassNames.WinForms10Window8,
                                        StringMatchSyntax.WildCard,
                                        app.MainWindow,
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
                        tempWindow = new Window(title + "*", StringMatchSyntax.WildCard);
                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);

                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // Check for success
                if (tempWindow == null)
                {
                    // Log the failure
                    Utilities.LogMessage("Failed to find window with title:  '" + title + "'");
                    // Throw the existing WindowNotFound exception
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
        /// 	[HainingW] 3/25/2006 Created
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
            private const string ResourceDialogTitle = @";Confirm Group Delete;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.GroupsView.GroupsResources;ConfirmDeleteCaption";
            
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
            /// Contains resource string for:  AreYouSureYouWantToDeleteThisGroup
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceAreYouSureYouWantToDeleteThisGroup = "Are you sure you want to delete this group?";

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
            /// Caches the translated resource string for:  AreYouSureYouWantToDeleteThisGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAreYouSureYouWantToDeleteThisGroup;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/25/2006 Created
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
            /// 	[HainingW] 3/25/2006 Created
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
            /// 	[HainingW] 3/25/2006 Created
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
            /// Exposes access to the AreYouSureYouWantToDeleteThisGroup translated resource string
            /// </summary>
            /// <history>
            /// 	[HainingW] 3/25/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AreYouSureYouWantToDeleteThisGroup
            {
                get
                {
                    if ((cachedAreYouSureYouWantToDeleteThisGroup == null))
                    {
                        cachedAreYouSureYouWantToDeleteThisGroup = CoreManager.MomConsole.GetIntlStr(ResourceAreYouSureYouWantToDeleteThisGroup);
                    }

                    return cachedAreYouSureYouWantToDeleteThisGroup;
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
        /// 	[HainingW] 3/25/2006 Created
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
            /// Control ID for AreYouSureYouWantToDeleteThisGroupStaticControl
            /// </summary>
            public const int AreYouSureYouWantToDeleteThisGroupStaticControl = 65535;
        }

        #endregion
    }
}
