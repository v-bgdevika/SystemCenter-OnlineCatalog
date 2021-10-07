// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AccountUsageDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[sharatja] 8/7/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.RunAsAccount.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Interface Definition - IAccountUsageDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAccountUsageDialogControls, for AccountUsageDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[sharatja] 8/7/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAccountUsageDialogControls
    {
        /// <summary>
        /// Read-only property to access CloseButton
        /// </summary>
        Button CloseButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunAsProfilesStaticControl
        /// </summary>
        StaticControl RunAsProfilesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunAsProfilesListView
        /// </summary>
        ListView RunAsProfilesListView
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HeaderTextStaticControl
        /// </summary>
        StaticControl HeaderTextStaticControl
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
    /// 	[sharatja] 8/7/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AccountUsageDialog : Dialog, IAccountUsageDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CloseButton of type Button
        /// </summary>
        private Button cachedCloseButton;
        
        /// <summary>
        /// Cache to hold a reference to RunAsProfilesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRunAsProfilesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RunAsProfilesListView of type ListView
        /// </summary>
        private ListView cachedSelectedComputersListView;
        
        /// <summary>
        /// Cache to hold a reference to HeaderTextStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHeaderTextStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AccountUsageDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AccountUsageDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region IAccountUsageDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAccountUsageDialogControls Controls
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
        ///  Exposes access to the CloseButton control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAccountUsageDialogControls.CloseButton
        {
            get
            {
                if ((this.cachedCloseButton == null))
                {
                    this.cachedCloseButton = new Button(this, AccountUsageDialog.ControlIDs.CloseButton);
                }
                return this.cachedCloseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunAsProfilesStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAccountUsageDialogControls.RunAsProfilesStaticControl
        {
            get
            {
                if ((this.cachedRunAsProfilesStaticControl == null))
                {
                    this.cachedRunAsProfilesStaticControl = new StaticControl(this, AccountUsageDialog.ControlIDs.RunAsProfilesStaticControl);
                }
                return this.cachedRunAsProfilesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunAsProfilesListView control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAccountUsageDialogControls.RunAsProfilesListView
        {
            get
            {
                if ((this.cachedSelectedComputersListView == null))
                {
                    this.cachedSelectedComputersListView = new ListView(this, AccountUsageDialog.ControlIDs.SelectedComputersListView);
                }
                return this.cachedSelectedComputersListView;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HeaderTextStaticControl control
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAccountUsageDialogControls.HeaderTextStaticControl
        {
            get
            {
                if ((this.cachedHeaderTextStaticControl == null))
                {
                    this.cachedHeaderTextStaticControl = new StaticControl(this, AccountUsageDialog.ControlIDs.HeaderTextStaticControl);
                }
                return this.cachedHeaderTextStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Close
        /// </summary>
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
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
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                tempWindow = new Window(Strings.DialogTitle
                    + "*",
                    StringMatchSyntax.WildCard);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MAXTRIES = 7;
                Core.Common.Utilities.LogMessage("Looking for window with title:  '"
                    + Strings.DialogTitle + "'");

                while (tempWindow == null && numberOfTries < MAXTRIES)
                {
                    // log the attempt
                    numberOfTries++;

                    try
                    {
                        // look for the dialogue again using wildcard matching
                        tempWindow = new Window(
                            Strings.DialogTitle + "*",
                            StringMatchSyntax.WildCard);
                        // If the window is not found then this wait is never called
                        // Hence added the sleep call in catch block
                        // Wait for the window to report that is ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("Attempt "
                            + numberOfTries
                            + " of "
                            + MAXTRIES
                            + "...");
                    }
                }
                // check for success
                if (tempWindow == null)
                {
                    throw new Window.Exceptions.WindowNotFoundException(
                        "Init function could not find or bring up the window"
                        + "with a title of '" + Strings.DialogTitle
                        + "'.\n\n" + ex.Message);
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
        /// 	[sharatja] 8/7/2008 Created
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
            private const string ResourceDialogTitle = ";Account Usage;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsAccount.WhereUsedDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClose = ";Close;ManagedString;Corgent.Diagramming.Toolbox.dll;Corgent.Diagramming.Toolbox." +
                "Properties.Resources;Close";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RunAsProfiles
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunAsProfiles = ";&Run As Profiles:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration" +
                ".dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsAccount." +
                "WhereUsedAccount;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HeaderText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHeaderText = ";The following Run As Profiles use this Run As Account.;ManagedString;Microsoft.E" +
                "nterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Int" +
                "ernal.UI.Administration.RunAsAccount.WhereUsedAccount;labelTitle1.Text";
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
            /// Caches the translated resource string for:  Close
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClose;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RunAsProfiles
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunAsProfiles;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HeaderText
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHeaderText;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
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
            /// 	[sharatja] 8/7/2008 Created
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
            /// Exposes access to the RunAsProfiles translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunAsProfiles
            {
                get
                {
                    if ((cachedRunAsProfiles == null))
                    {
                        cachedRunAsProfiles = CoreManager.MomConsole.GetIntlStr(ResourceRunAsProfiles);
                    }
                    return cachedRunAsProfiles;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HeaderText translated resource string
            /// </summary>
            /// <history>
            /// 	[sharatja] 8/7/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HeaderText
            {
                get
                {
                    if ((cachedHeaderText == null))
                    {
                        cachedHeaderText = CoreManager.MomConsole.GetIntlStr(ResourceHeaderText);
                    }
                    return cachedHeaderText;
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
        /// 	[sharatja] 8/7/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CloseButton
            /// </summary>
            public const string CloseButton = "closeButton";
            
            /// <summary>
            /// Control ID for RunAsProfilesStaticControl
            /// </summary>
            public const string RunAsProfilesStaticControl = "label1";
            
            /// <summary>
            /// Control ID for RunAsProfilesListView
            /// </summary>
            public const string SelectedComputersListView = "listViewProfiles";
            
            /// <summary>
            /// Control ID for HeaderTextStaticControl
            /// </summary>
            public const string HeaderTextStaticControl = "labelTitle1";
        }
        #endregion
    }
}
