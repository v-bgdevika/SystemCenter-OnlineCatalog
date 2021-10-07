// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ViewsDialog.cs">
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

    #region Radio Group Enumeration - RadioGroupViews

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroupViews
    /// </summary>
    /// <history>
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroupViews
    {
        /// <summary>
        /// OnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved = 0
        /// </summary>
        OnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved = 0,

        /// <summary>
        /// AllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture = 1
        /// </summary>
        AllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture = 1,
    }
    #endregion

    #region Interface Definition - IViewsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IViewsDialogControls, for ViewsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IViewsDialogControls
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
        /// Read-only property to access TargetDescriptionTreeView
        /// </summary>
        TreeView TargetDescriptionTreeView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ApprovedViewsStaticControl
        /// </summary>
        StaticControl ApprovedViewsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ExplicitlyApprovedViewsRadioButton
        /// </summary>
        RadioButton ExplicitlyApprovedViewsRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AllViewsRadioButton
        /// </summary>
        RadioButton AllViewsRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ApproveViewsStaticControl
        /// </summary>
        StaticControl ApproveViewsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt
        /// </summary>
        StaticControl MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt
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
        /// Read-only property to access ViewsStaticControl2
        /// </summary>
        StaticControl ViewsStaticControl2
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TabControl
        /// </summary>
        TabControl _TabControl
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
    public class ViewsDialog : Dialog, IViewsDialogControls
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
        /// Cache to hold a reference to TargetDescriptionTreeView of type TreeView
        /// </summary>
        private TreeView cachedTargetDescriptionTreeView;

        /// <summary>
        /// Cache to hold a reference to ApprovedViewsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedApprovedViewsStaticControl;

        /// <summary>
        /// Cache to hold a reference to ExplicitlyApprovedViewsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedExplicitlyApprovedViewsRadioButton;

        /// <summary>
        /// Cache to hold a reference to AllViewsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAllViewsRadioButton;

        /// <summary>
        /// Cache to hold a reference to ApproveViewsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedApproveViewsStaticControl;

        /// <summary>
        /// Cache to hold a reference to MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt of type StaticControl
        /// </summary>
        private StaticControl cachedMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt;

        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;

        /// <summary>
        /// Cache to hold a reference to ViewsStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedViewsStaticControl2;

        /// <summary>
        /// Cache to hold a reference to Tab0TabControl of type TabControl
        /// </summary>
        private TabControl cachedTabControl;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ViewsDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ViewsDialog(ConsoleApp app)
            :
                base(app, Init(app))
        {
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
            // Sometimes, not always, the Views page loaded slowly and cause control not found exception, we wait for a significant control safely here to make sure the whole page loaded completely
            app.Waiters.WaitForWindowAppeared(this, new QID(string.Format(";[UIA]AutomationId='{0}'", ViewsDialog.ControlIDs.ExplicitlyApprovedViewsRadioButton)), Window.DefaultWaitTimeout * 3);
        }
        #endregion

        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroupViews
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroupViews RadioGroupViews
        {
            get
            {
                if ((this.Controls.ExplicitlyApprovedViewsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroupViews.OnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved;
                }

                if ((this.Controls.AllViewsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroupViews.AllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }

            set
            {
                if ((value == RadioGroupViews.OnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved))
                {
                    this.Controls.ExplicitlyApprovedViewsRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroupViews.AllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture))
                    {
                        this.Controls.AllViewsRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion

        #region IViewsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IViewsDialogControls Controls
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
        Button IViewsDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ViewsDialog.ControlIDs.PreviousButton);
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
        Button IViewsDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ViewsDialog.ControlIDs.NextButton);
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
        Button IViewsDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, ViewsDialog.ControlIDs.CreateButton);
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
        Button IViewsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ViewsDialog.ControlIDs.CancelButton);
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
        StaticControl IViewsDialogControls.GeneralStaticControl
        {
            get
            {
                if ((this.cachedGeneralStaticControl == null))
                {
                    this.cachedGeneralStaticControl = new StaticControl(this, ViewsDialog.ControlIDs.GeneralStaticControl);
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
        StaticControl IViewsDialogControls.AuthorScopeStaticControl
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
        StaticControl IViewsDialogControls.GroupScopeStaticControl
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
        StaticControl IViewsDialogControls.TasksStaticControl
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
        StaticControl IViewsDialogControls.ViewsStaticControl
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
        StaticControl IViewsDialogControls.SummaryStaticControl
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
        ///  Exposes access to the TargetDescriptionTreeView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TreeView IViewsDialogControls.TargetDescriptionTreeView
        {
            get
            {
                if ((this.cachedTargetDescriptionTreeView == null))
                {
                    Window wndTemp = this.App.MainWindow;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedTargetDescriptionTreeView = new TreeView(wndTemp);
                }
                return this.cachedTargetDescriptionTreeView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApprovedViewsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IViewsDialogControls.ApprovedViewsStaticControl
        {
            get
            {
                if ((this.cachedApprovedViewsStaticControl == null))
                {
                    this.cachedApprovedViewsStaticControl = new StaticControl(this, ViewsDialog.ControlIDs.ApprovedViewsStaticControl);
                }
                return this.cachedApprovedViewsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExplicitlyApprovedViewsRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IViewsDialogControls.ExplicitlyApprovedViewsRadioButton
        {
            get
            {
                if ((this.cachedExplicitlyApprovedViewsRadioButton == null))
                {
                    this.cachedExplicitlyApprovedViewsRadioButton = new RadioButton(this, ViewsDialog.ControlIDs.ExplicitlyApprovedViewsRadioButton);
                }
                return this.cachedExplicitlyApprovedViewsRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllViewsRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IViewsDialogControls.AllViewsRadioButton
        {
            get
            {
                if ((this.cachedAllViewsRadioButton == null))
                {
                    this.cachedAllViewsRadioButton = new RadioButton(this, ViewsDialog.ControlIDs.AllViewsRadioButton);
                }
                return this.cachedAllViewsRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApproveViewsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IViewsDialogControls.ApproveViewsStaticControl
        {
            get
            {
                if ((this.cachedApproveViewsStaticControl == null))
                {
                    this.cachedApproveViewsStaticControl = new StaticControl(this, ViewsDialog.ControlIDs.ApproveViewsStaticControl);
                }
                return this.cachedApproveViewsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IViewsDialogControls.MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt
        {
            get
            {
                if ((this.cachedMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt == null))
                {
                    this.cachedMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt = new StaticControl(this, ViewsDialog.ControlIDs.MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt);
                }
                return this.cachedMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt;
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
        StaticControl IViewsDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ViewsDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ViewsStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IViewsDialogControls.ViewsStaticControl2
        {
            get
            {
                if ((this.cachedViewsStaticControl2 == null))
                {
                    this.cachedViewsStaticControl2 = new StaticControl(this, ViewsDialog.ControlIDs.ViewsStaticControl2);
                }
                return this.cachedViewsStaticControl2;
            }
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TabControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 1/26/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IViewsDialogControls._TabControl
        {
            get
            {
                if ((this.cachedTabControl == null))
                {
                    this.cachedTabControl = new TabControl(this, ViewsDialog.ControlIDs.TabControl);
                }
                return this.cachedTabControl;
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
            /// Contains resource string for:  ApprovedViews
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApprovedViews = ";Approved &views:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.Console.Administration.ViewScope;labelViews.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved = ";&Only views explicitly added to the \'Approved views\' grid are approved;ManagedSt" +
                "ring;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI" +
                ".Console.Administration.ViewScope;radioButtonSpecific.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture = ";A&ll views are automatically approved, including views in Management Packs impor" +
                "ted in the future;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpris" +
                "eManagement.Mom.Internal.UI.Console.Administration.ViewScope;radioButtonAll.Text" +
                "";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ApproveViews
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApproveViews = ";Approve views;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.Internal.UI.Console.Administration.ViewScope;labelTitle.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData = @";Members of this user role can see approved views. Limiting access to views does not limit access to the underlying data.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.ViewScope;titleLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Common.CommonResources;CommandHelp";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Views2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceViews2 = ";Views;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ViewMenuIt" +
                "emText";

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
            /// Caches the translated resource string for:  ApprovedViews
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApprovedViews;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ApproveViews
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApproveViews;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Views2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViews2;

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
            /// Exposes access to the ApprovedViews translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ApprovedViews
            {
                get
                {
                    if ((cachedApprovedViews == null))
                    {
                        cachedApprovedViews = CoreManager.MomConsole.GetIntlStr(ResourceApprovedViews);
                    }
                    return cachedApprovedViews;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved
            {
                get
                {
                    if ((cachedOnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved == null))
                    {
                        cachedOnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved = CoreManager.MomConsole.GetIntlStr(ResourceOnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved);
                    }
                    return cachedOnlyViewsExplicitlyAddedToTheApprovedViewsGridAreApproved;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture
            {
                get
                {
                    if ((cachedAllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture == null))
                    {
                        cachedAllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture = CoreManager.MomConsole.GetIntlStr(ResourceAllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture);
                    }
                    return cachedAllViewsAreAutomaticallyApprovedIncludingViewsInManagementPacksImportedInTheFuture;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ApproveViews translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ApproveViews
            {
                get
                {
                    if ((cachedApproveViews == null))
                    {
                        cachedApproveViews = CoreManager.MomConsole.GetIntlStr(ResourceApproveViews);
                    }
                    return cachedApproveViews;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData
            {
                get
                {
                    if ((cachedMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData == null))
                    {
                        cachedMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData = CoreManager.MomConsole.GetIntlStr(ResourceMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData);
                    }
                    return cachedMembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingData;
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
            /// Exposes access to the Views2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Views2
            {
                get
                {
                    if ((cachedViews2 == null))
                    {
                        cachedViews2 = CoreManager.MomConsole.GetIntlStr(ResourceViews2);
                    }
                    return cachedViews2;
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
            /// Control ID for ApprovedViewsStaticControl
            /// </summary>
            public const string ApprovedViewsStaticControl = "labelViews";

            /// <summary>
            /// Control ID for ExplicitlyApprovedViewsRadioButton
            /// </summary>
            public const string ExplicitlyApprovedViewsRadioButton = "radioButtonSpecificSelect";

            /// <summary>
            /// Control ID for AllViewsRadioButton
            /// </summary>
            public const string AllViewsRadioButton = "radioButtonAllSelect";

            /// <summary>
            /// Control ID for ApproveViewsStaticControl
            /// </summary>
            public const string ApproveViewsStaticControl = "labelTitle";

            /// <summary>
            /// Control ID for MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt
            /// </summary>
            public const string MembersOfThisUserRoleCanSeeApprovedViewsLimitingAccessToViewsDoesNotLimitAccessToTheUnderlyingDataSt = "titleLabel";

            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";

            /// <summary>
            /// Control ID for ViewsStaticControl2
            /// </summary>
            public const string ViewsStaticControl2 = "headerLabel";

            /// <summary>
            /// Control ID for Tab0TabControl
            /// </summary>
            public const string TabControl = "tabControl1";
        }
        #endregion
    }
}
