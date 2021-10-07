// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GroupScopeDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[ruhim] 7/21/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.UserRole.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;

    #region Interface Definition - IGroupScopeDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IGroupScopeDialogControls, for GroupScopeDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IGroupScopeDialogControls
    {
        /// <summary>
        /// Read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CreateButton
        /// </summary>
        Button CreateButton
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
        /// Read-only property to access GeneralStaticControl
        /// </summary>
        StaticControl GeneralStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AuthorScopeStaticControl
        /// </summary>
        StaticControl AuthorScopeStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access GroupScopeStaticControl
        /// </summary>
        StaticControl GroupScopeStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TasksStaticControl
        /// </summary>
        StaticControl TasksStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ViewsStaticControl
        /// </summary>
        StaticControl ViewsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SummaryStaticControl
        /// </summary>
        StaticControl SummaryStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ViewGroupMembersToolbar
        /// </summary>
        Toolbar ViewGroupMembersToolbar
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ApproveGroupsStaticControl
        /// </summary>
        StaticControl ApproveGroupsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access GroupsStaticControl
        /// </summary>
        StaticControl GroupsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access GroupsTreeView
        /// </summary>
        TreeView GroupsTreeView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroupsStaticControl
        /// </summary>
        StaticControl MembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroupsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access GroupScopeStaticControl2
        /// </summary>
        StaticControl GroupScopeStaticControl2
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
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class GroupScopeDialog : Dialog, IGroupScopeDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;

        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;

        /// <summary>
        /// Cache to hold a reference to CreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;

        /// <summary>
        /// Cache to hold a reference to AuthorScopeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAuthorScopeStaticControl;

        /// <summary>
        /// Cache to hold a reference to GroupScopeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGroupScopeStaticControl;

        /// <summary>
        /// Cache to hold a reference to TasksStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTasksStaticControl;

        /// <summary>
        /// Cache to hold a reference to ViewsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedViewsStaticControl;

        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;

        /// <summary>
        /// Cache to hold a reference to ViewGroupMembersToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedViewGroupMembersToolbar;

        /// <summary>
        /// Cache to hold a reference to ApproveGroupsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedApproveGroupsStaticControl;

        /// <summary>
        /// Cache to hold a reference to GroupsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGroupsStaticControl;

        /// <summary>
        /// Cache to hold a reference to GroupsTreeView of type TreeView
        /// </summary>
        private TreeView cachedGroupsTreeView;

        /// <summary>
        /// Cache to hold a reference to MembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroupsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroupsStaticControl;

        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;

        /// <summary>
        /// Cache to hold a reference to GroupScopeStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedGroupScopeStaticControl2;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of GroupScopeDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GroupScopeDialog(ConsoleApp app)
            :
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion

        #region IGroupScopeDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IGroupScopeDialogControls Controls
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
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupScopeDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, GroupScopeDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupScopeDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, GroupScopeDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupScopeDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, GroupScopeDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupScopeDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, GroupScopeDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupScopeDialogControls.GeneralStaticControl
        {
            get
            {
                if ((this.cachedGeneralStaticControl == null))
                {
                    this.cachedGeneralStaticControl = new StaticControl(this, GroupScopeDialog.ControlIDs.GeneralStaticControl);
                }
                return this.cachedGeneralStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AuthorScopeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupScopeDialogControls.AuthorScopeStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAuthorScopeStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedAuthorScopeStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedAuthorScopeStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupScopeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupScopeDialogControls.GroupScopeStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGroupScopeStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedGroupScopeStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedGroupScopeStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TasksStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupScopeDialogControls.TasksStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedTasksStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedTasksStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedTasksStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupScopeDialogControls.ViewsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedViewsStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedViewsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedViewsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupScopeDialogControls.SummaryStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSummaryStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedSummaryStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedSummaryStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewGroupMembersToolbar control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IGroupScopeDialogControls.ViewGroupMembersToolbar
        {
            get
            {
                if ((this.cachedViewGroupMembersToolbar == null))
                {
                    this.cachedViewGroupMembersToolbar = new Toolbar(this, GroupScopeDialog.ControlIDs.ViewGroupMembersToolbar);
                }
                return this.cachedViewGroupMembersToolbar;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApproveGroupsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupScopeDialogControls.ApproveGroupsStaticControl
        {
            get
            {
                if ((this.cachedApproveGroupsStaticControl == null))
                {
                    this.cachedApproveGroupsStaticControl = new StaticControl(this, GroupScopeDialog.ControlIDs.ApproveGroupsStaticControl);
                }
                return this.cachedApproveGroupsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupScopeDialogControls.GroupsStaticControl
        {
            get
            {
                if ((this.cachedGroupsStaticControl == null))
                {
                    this.cachedGroupsStaticControl = new StaticControl(this, GroupScopeDialog.ControlIDs.GroupsStaticControl);
                }
                return this.cachedGroupsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupsTreeView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView IGroupScopeDialogControls.GroupsTreeView
        {
            get
            {
                //Add while loop to wait for the group tree view loaded, bug#213011
                int retryTimes = 1;
                while (this.cachedGroupsTreeView == null && retryTimes < Common.Constants.DefaultMaxRetry)
                {
                    try
                    {
                        this.cachedGroupsTreeView = new TreeView(this, GroupScopeDialog.ControlIDs.GroupsTreeView);
                        break;
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        Common.Utilities.LogMessage("The GroupsTreeView not found, wait for one second and try again");
                        Sleeper.Delay(Common.Constants.OneSecond);
                    }
                }
                return this.cachedGroupsTreeView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroupsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupScopeDialogControls.MembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroupsStaticControl
        {
            get
            {
                if ((this.cachedMembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroupsStaticControl == null))
                {
                    this.cachedMembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroupsStaticControl = new StaticControl(this, GroupScopeDialog.ControlIDs.MembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroupsStaticControl);
                }
                return this.cachedMembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroupsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupScopeDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, GroupScopeDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupScopeStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IGroupScopeDialogControls.GroupScopeStaticControl2
        {
            get
            {
                if ((this.cachedGroupScopeStaticControl2 == null))
                {
                    this.cachedGroupScopeStaticControl2 = new StaticControl(this, GroupScopeDialog.ControlIDs.GroupScopeStaticControl2);
                }
                return this.cachedGroupScopeStaticControl2;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPrevious()
        {
            this.Controls.PreviousButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreate()
        {
            this.Controls.CreateButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
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
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            int index = Strings.DialogTitle.IndexOf("{0}");
            string newDialogTitle = Strings.DialogTitle.Remove(index);

            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(newDialogTitle, StringMatchSyntax.WildCard, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                                newDialogTitle + "*",
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
                        newDialogTitle + "'");

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
        /// 	[ruhim] 7/21/2006 Created
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
            private const string ResourceDialogTitle =
                ";Create User Role Wizard - {0} Profile;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;UserRoleWizardCaption";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFramework.WizardButtonsPanel" +
                ";previousButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Mic" +
                "rosoft.EnterpriseManagement.Mom.Internal.UI.PageFramework.WizardButtonsPanel;nex" +
                "tButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";C&reate;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;CreateMPAction" +
                "";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GeneralP" +
                "ropertyPageTabText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AuthorScope
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAuthorScope = ";Author Scope;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.Internal.UI.Console.Administration.AdminResources;UserRoleAuthorScope" +
                "Title";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GroupScope
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGroupScope = ";Group Scope;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManag" +
                "ement.Mom.Internal.UI.Console.Administration.AdminResources;UserRoleGroupScopeTi" +
                "tle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTasks = ";Tasks;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.Common.CommonResources;SearchTasks";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Views
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViews = ";Views;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ViewMenuIt" +
                "emText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary = ";Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;SummaryT" +
                "itle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ApproveGroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApproveGroups = ";Approve groups;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Console.Administration.GroupScope;labelTitle.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Groups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGroups = ";&Groups:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micr" +
                "osoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.Subscript" +
                "ionGroupsPage;groupsLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroups = ";Members of this user role can set overrides and monitor objects in approved grou" +
                "ps.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.Console.Administration.AdminResources;GroupScopeGeneralDescription" +
                "";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Common.CommonResources;CommandHelp";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GroupScope2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGroupScope2 = ";Group Scope;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManag" +
                "ement.Mom.Internal.UI.Console.Administration.AdminResources;UserRoleGroupScopeTi" +
                "tle";
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
            /// Caches the translated resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPrevious;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AuthorScope
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAuthorScope;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GroupScope
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGroupScope;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTasks;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Views
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViews;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ApproveGroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApproveGroups;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Groups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGroups;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroups
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroups;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GroupScope2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGroupScope2;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
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
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Previous
            {
                get
                {
                    if ((cachedPrevious == null))
                    {
                        cachedPrevious = CoreManager.MomConsole.GetIntlStr(ResourcePrevious);
                    }
                    return cachedPrevious;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Next
            {
                get
                {
                    if ((cachedNext == null))
                    {
                        cachedNext = CoreManager.MomConsole.GetIntlStr(ResourceNext);
                    }
                    return cachedNext;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Create translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Create
            {
                get
                {
                    if ((cachedCreate == null))
                    {
                        cachedCreate = CoreManager.MomConsole.GetIntlStr(ResourceCreate);
                    }
                    return cachedCreate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
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
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string General
            {
                get
                {
                    if ((cachedGeneral == null))
                    {
                        cachedGeneral = CoreManager.MomConsole.GetIntlStr(ResourceGeneral);
                    }
                    return cachedGeneral;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AuthorScope translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AuthorScope
            {
                get
                {
                    if ((cachedAuthorScope == null))
                    {
                        cachedAuthorScope = CoreManager.MomConsole.GetIntlStr(ResourceAuthorScope);
                    }
                    return cachedAuthorScope;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GroupScope translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GroupScope
            {
                get
                {
                    if ((cachedGroupScope == null))
                    {
                        cachedGroupScope = CoreManager.MomConsole.GetIntlStr(ResourceGroupScope);
                    }
                    return cachedGroupScope;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tasks translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tasks
            {
                get
                {
                    if ((cachedTasks == null))
                    {
                        cachedTasks = CoreManager.MomConsole.GetIntlStr(ResourceTasks);
                    }
                    return cachedTasks;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Views translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Views
            {
                get
                {
                    if ((cachedViews == null))
                    {
                        cachedViews = CoreManager.MomConsole.GetIntlStr(ResourceViews);
                    }
                    return cachedViews;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Summary
            {
                get
                {
                    if ((cachedSummary == null))
                    {
                        cachedSummary = CoreManager.MomConsole.GetIntlStr(ResourceSummary);
                    }
                    return cachedSummary;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ApproveGroups translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ApproveGroups
            {
                get
                {
                    if ((cachedApproveGroups == null))
                    {
                        cachedApproveGroups = CoreManager.MomConsole.GetIntlStr(ResourceApproveGroups);
                    }
                    return cachedApproveGroups;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Groups translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Groups
            {
                get
                {
                    if ((cachedGroups == null))
                    {
                        cachedGroups = CoreManager.MomConsole.GetIntlStr(ResourceGroups);
                    }
                    return cachedGroups;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroups translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroups
            {
                get
                {
                    if ((cachedMembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroups == null))
                    {
                        cachedMembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroups = CoreManager.MomConsole.GetIntlStr(ResourceMembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroups);
                    }
                    return cachedMembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroups;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
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
            /// Exposes access to the GroupScope2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GroupScope2
            {
                get
                {
                    if ((cachedGroupScope2 == null))
                    {
                        cachedGroupScope2 = CoreManager.MomConsole.GetIntlStr(ResourceGroupScope2);
                    }
                    return cachedGroupScope2;
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
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for PreviousButton
            /// </summary>
            public const string PreviousButton = "previousButton";

            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";

            /// <summary>
            /// Control ID for CreateButton
            /// </summary>
            public const string CreateButton = "commitButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for AuthorScopeStaticControl
            /// </summary>
            public const string AuthorScopeStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for GroupScopeStaticControl
            /// </summary>
            public const string GroupScopeStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for TasksStaticControl
            /// </summary>
            public const string TasksStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for ViewsStaticControl
            /// </summary>
            public const string ViewsStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for ViewGroupMembersToolbar
            /// </summary>
            public const string ViewGroupMembersToolbar = "toolStripShow";

            /// <summary>
            /// Control ID for ApproveGroupsStaticControl
            /// </summary>
            public const string ApproveGroupsStaticControl = "labelTitle";

            /// <summary>
            /// Control ID for GroupsStaticControl
            /// </summary>
            public const string GroupsStaticControl = "labelGroups";

            /// <summary>
            /// Control ID for GroupsTreeView
            /// </summary>
            public const string GroupsTreeView = "multiStateTreeView";

            /// <summary>
            /// Control ID for MembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroupsStaticControl
            /// </summary>
            public const string MembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroupsStaticControl = "labelDescription";

            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";

            /// <summary>
            /// Control ID for GroupScopeStaticControl2
            /// </summary>
            public const string GroupScopeStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
