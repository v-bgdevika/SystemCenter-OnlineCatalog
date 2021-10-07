// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GroupScopeProperties.cs">
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

    #region Interface Definition - IGroupScopePropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IGroupScopePropertiesControls, for GroupScopeProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IGroupScopePropertiesControls
    {
        /// <summary>
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
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
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Tab2TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab2TabControl
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
    public class GroupScopeProperties : Dialog, IGroupScopePropertiesControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;

        /// <summary>
        /// Cache to hold a reference to Tab2TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab2TabControl;

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
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of GroupScopeProperties of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GroupScopeProperties(ConsoleApp app)
            :
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region IGroupScopeProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IGroupScopePropertiesControls Controls
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
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupScopePropertiesControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, GroupScopeProperties.ControlIDs.ApplyButton);
                }
                return this.cachedApplyButton;
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
        Button IGroupScopePropertiesControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, GroupScopeProperties.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IGroupScopePropertiesControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, GroupScopeProperties.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab2TabControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IGroupScopePropertiesControls.Tab2TabControl
        {
            get
            {
                if ((this.cachedTab2TabControl == null))
                {
                    this.cachedTab2TabControl = new TabControl(this, GroupScopeProperties.ControlIDs.Tab2TabControl);
                }
                return this.cachedTab2TabControl;
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
        Toolbar IGroupScopePropertiesControls.ViewGroupMembersToolbar
        {
            get
            {
                if ((this.cachedViewGroupMembersToolbar == null))
                {
                    this.cachedViewGroupMembersToolbar = new Toolbar(this, GroupScopeProperties.ControlIDs.ViewGroupMembersToolbar);
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
        StaticControl IGroupScopePropertiesControls.ApproveGroupsStaticControl
        {
            get
            {
                if ((this.cachedApproveGroupsStaticControl == null))
                {
                    this.cachedApproveGroupsStaticControl = new StaticControl(this, GroupScopeProperties.ControlIDs.ApproveGroupsStaticControl);
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
        StaticControl IGroupScopePropertiesControls.GroupsStaticControl
        {
            get
            {
                if ((this.cachedGroupsStaticControl == null))
                {
                    this.cachedGroupsStaticControl = new StaticControl(this, GroupScopeProperties.ControlIDs.GroupsStaticControl);
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
        TreeView IGroupScopePropertiesControls.GroupsTreeView
        {
            get
            {
                //Add while loop to wait for the group tree view loaded, bug#213011
                int retryTimes=1;
                while(this.cachedGroupsTreeView==null && retryTimes<Common.Constants.DefaultMaxRetry)
                {
                    try
                    {
                        WindowParameters parameters = new WindowParameters();
                        parameters.UseLegacy = true;
                        parameters.StartWindow = this;
                        parameters.WinFormsID = GroupScopeProperties.ControlIDs.GroupsTreeView;
                        this.cachedGroupsTreeView = new TreeView(parameters);
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
        StaticControl IGroupScopePropertiesControls.MembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroupsStaticControl
        {
            get
            {
                if ((this.cachedMembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroupsStaticControl == null))
                {
                    this.cachedMembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroupsStaticControl = new StaticControl(this, GroupScopeProperties.ControlIDs.MembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroupsStaticControl);
                }
                return this.cachedMembersOfThisUserRoleCanSetOverridesAndMonitorObjectsInApprovedGroupsStaticControl;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
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

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
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
        /// 	[ruhim] 7/21/2006 Created
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
                "; - User Role Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;UserRolePropertiesTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.PropertyDialogForm;buttonApply.Text";

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
            /// Contains resource string for:  Tab2
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab2 = "Tab2";

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
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;

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
            /// Caches the translated resource string for:  Tab2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab2;

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
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Apply
            {
                get
                {
                    if ((cachedApply == null))
                    {
                        cachedApply = CoreManager.MomConsole.GetIntlStr(ResourceApply);
                    }
                    return cachedApply;
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
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
            /// Exposes access to the Tab2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab2
            {
                get
                {
                    if ((cachedTab2 == null))
                    {
                        cachedTab2 = CoreManager.MomConsole.GetIntlStr(ResourceTab2);
                    }
                    return cachedTab2;
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
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";

            /// <summary>
            /// Control ID for Tab2TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab2TabControl = "tabPages";

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
        }
        #endregion
    }
}
