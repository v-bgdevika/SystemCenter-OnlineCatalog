// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TasksDialog.cs">
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

    #region Radio Group Enumeration - RadioGroupTasks

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroupTasks
    /// </summary>
    /// <history>
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroupTasks
    {
        /// <summary>
        /// OnlyTasksExplicitlyAddedToTheApprovedTasksGridAreApproved = 0
        /// </summary>
        OnlyTasksExplicitlyAddedToTheApprovedTasksGridAreApproved = 0,

        /// <summary>
        /// AllTasksAreAutomaticallyApprovedIncludingTasksInManagementPacksImportedInTheFuture = 1
        /// </summary>
        AllTasksAreAutomaticallyApprovedIncludingTasksInManagementPacksImportedInTheFuture = 1,
    }
    #endregion

    #region Interface Definition - ITasksDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITasksDialogControls, for TasksDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITasksDialogControls
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
        /// Read-only property to access AddRemoveToolbar
        /// </summary>
        Toolbar AddRemoveToolbar
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TargetDescriptionTextBox
        /// </summary>
        TextBox TargetDescriptionTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TaskDescriptionStaticControl
        /// </summary>
        StaticControl TaskDescriptionStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ApprovedTargetsListView
        /// </summary>
        ListView ApprovedTargetsListView
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ApprovedTasksStaticControl
        /// </summary>
        StaticControl ApprovedTasksStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ExplicitlyApprovedTasksRadioButton
        /// </summary>
        RadioButton ExplicitlyApprovedTasksRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AllTasksRadioButton
        /// </summary>
        RadioButton AllTasksRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ApproveTasksStaticControl
        /// </summary>
        StaticControl ApproveTasksStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MembersOfThisUserRoleCanExecuteApprovedTasksStaticControl
        /// </summary>
        StaticControl MembersOfThisUserRoleCanExecuteApprovedTasksStaticControl
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
        /// Read-only property to access TasksStaticControl2
        /// </summary>
        StaticControl TasksStaticControl2
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
    public class TasksDialog : Dialog, ITasksDialogControls
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
        /// Cache to hold a reference to AddRemoveToolbar of type Toolbar
        /// </summary>
        private Toolbar cachedAddRemoveToolbar;

        /// <summary>
        /// Cache to hold a reference to TargetDescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedTargetDescriptionTextBox;

        /// <summary>
        /// Cache to hold a reference to TaskDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTaskDescriptionStaticControl;

        /// <summary>
        /// Cache to hold a reference to ApprovedTargetsListView of type ListView
        /// </summary>
        private ListView cachedApprovedTargetsListView;

        /// <summary>
        /// Cache to hold a reference to ApprovedTasksStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedApprovedTasksStaticControl;

        /// <summary>
        /// Cache to hold a reference to ExplicitlyApprovedTasksRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedExplicitlyApprovedTasksRadioButton;

        /// <summary>
        /// Cache to hold a reference to AllTasksRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAllTasksRadioButton;

        /// <summary>
        /// Cache to hold a reference to ApproveTasksStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedApproveTasksStaticControl;

        /// <summary>
        /// Cache to hold a reference to MembersOfThisUserRoleCanExecuteApprovedTasksStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMembersOfThisUserRoleCanExecuteApprovedTasksStaticControl;

        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;

        /// <summary>
        /// Cache to hold a reference to TasksStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedTasksStaticControl2;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of TasksDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TasksDialog(ConsoleApp app)
            :
                base(app, Init(app))
        {
            // this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion

        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroupTasks
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroupTasks RadioGroupTasks
        {
            get
            {
                if ((this.Controls.ExplicitlyApprovedTasksRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroupTasks.OnlyTasksExplicitlyAddedToTheApprovedTasksGridAreApproved;
                }

                if ((this.Controls.AllTasksRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroupTasks.AllTasksAreAutomaticallyApprovedIncludingTasksInManagementPacksImportedInTheFuture;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }

            set
            {
                if ((value == RadioGroupTasks.OnlyTasksExplicitlyAddedToTheApprovedTasksGridAreApproved))
                {
                    this.Controls.ExplicitlyApprovedTasksRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroupTasks.AllTasksAreAutomaticallyApprovedIncludingTasksInManagementPacksImportedInTheFuture))
                    {
                        this.Controls.AllTasksRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion

        #region ITasksDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITasksDialogControls Controls
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
        ///  Routine to set/get the text in control TargetDescription
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TargetDescriptionText
        {
            get
            {
                return this.Controls.TargetDescriptionTextBox.Text;
            }

            set
            {
                this.Controls.TargetDescriptionTextBox.Text = value;
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
        Button ITasksDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, TasksDialog.ControlIDs.PreviousButton);
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
        Button ITasksDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, TasksDialog.ControlIDs.NextButton);
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
        Button ITasksDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, TasksDialog.ControlIDs.CreateButton);
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
        Button ITasksDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, TasksDialog.ControlIDs.CancelButton);
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
        StaticControl ITasksDialogControls.GeneralStaticControl
        {
            get
            {
                if ((this.cachedGeneralStaticControl == null))
                {
                    this.cachedGeneralStaticControl = new StaticControl(this, TasksDialog.ControlIDs.GeneralStaticControl);
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
        StaticControl ITasksDialogControls.AuthorScopeStaticControl
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
        StaticControl ITasksDialogControls.GroupScopeStaticControl
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
        StaticControl ITasksDialogControls.TasksStaticControl
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
        StaticControl ITasksDialogControls.ViewsStaticControl
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
        StaticControl ITasksDialogControls.SummaryStaticControl
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
        ///  Exposes access to the AddRemoveToolbar control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// 	[nathd] 24SEP2009 Maui 2.0: Calling the Toolbar constructor with a QID.
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar ITasksDialogControls.AddRemoveToolbar
        {
            get
            {
                if ((this.cachedAddRemoveToolbar == null))
                {
                    // [nathd] - Maui 2.0: Calling the Toolbar constructor with 'this' being the only parameter is returning 
                    // the wrong toolbar. For example, it is returning the "View Group Members" toolbar rather than the
                    // "AddRemoveToolbar". There is no caption/name defined for these toolbars therefore we cannot call the 
                    // constructor with the caption/name. Switching over to the UIA tree and using a QID with the AutomationId.
                    QID queryId = new QID(";[UIA]AutomationId =\'" + TasksDialog.ControlIDs.PagePanel + "\' && Role = 'pane';[UIA]AutomationId=\'" + TasksDialog.ControlIDs.AddRemoveToolbar + "\'");
                    this.cachedAddRemoveToolbar = new Toolbar(this, queryId, Constants.DefaultContextMenuTimeout);
                }
                return this.cachedAddRemoveToolbar;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TargetDescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ITasksDialogControls.TargetDescriptionTextBox
        {
            get
            {
                if ((this.cachedTargetDescriptionTextBox == null))
                {
                    this.cachedTargetDescriptionTextBox = new TextBox(this, TasksDialog.ControlIDs.TargetDescriptionTextBox);
                }
                return this.cachedTargetDescriptionTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TaskDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITasksDialogControls.TaskDescriptionStaticControl
        {
            get
            {
                if ((this.cachedTaskDescriptionStaticControl == null))
                {
                    this.cachedTaskDescriptionStaticControl = new StaticControl(this, TasksDialog.ControlIDs.TaskDescriptionStaticControl);
                }
                return this.cachedTaskDescriptionStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApprovedTargetsListView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ITasksDialogControls.ApprovedTargetsListView
        {
            get
            {
                if ((this.cachedApprovedTargetsListView == null))
                {
                    this.cachedApprovedTargetsListView = new ListView(this, TasksDialog.ControlIDs.ApprovedTargetsListView);
                }
                return this.cachedApprovedTargetsListView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApprovedTasksStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITasksDialogControls.ApprovedTasksStaticControl
        {
            get
            {
                if ((this.cachedApprovedTasksStaticControl == null))
                {
                    this.cachedApprovedTasksStaticControl = new StaticControl(this, TasksDialog.ControlIDs.ApprovedTasksStaticControl);
                }
                return this.cachedApprovedTasksStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExplicitlyApprovedTasksRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ITasksDialogControls.ExplicitlyApprovedTasksRadioButton
        {
            get
            {
                if ((this.cachedExplicitlyApprovedTasksRadioButton == null))
                {
                    this.cachedExplicitlyApprovedTasksRadioButton = new RadioButton(this, TasksDialog.ControlIDs.ExplicitlyApprovedTasksRadioButton);
                }
                return this.cachedExplicitlyApprovedTasksRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllTasksRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ITasksDialogControls.AllTasksRadioButton
        {
            get
            {
                if ((this.cachedAllTasksRadioButton == null))
                {
                    this.cachedAllTasksRadioButton = new RadioButton(this, TasksDialog.ControlIDs.AllTasksRadioButton);
                }
                return this.cachedAllTasksRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApproveTasksStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITasksDialogControls.ApproveTasksStaticControl
        {
            get
            {
                if ((this.cachedApproveTasksStaticControl == null))
                {
                    this.cachedApproveTasksStaticControl = new StaticControl(this, TasksDialog.ControlIDs.ApproveTasksStaticControl);
                }
                return this.cachedApproveTasksStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MembersOfThisUserRoleCanExecuteApprovedTasksStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITasksDialogControls.MembersOfThisUserRoleCanExecuteApprovedTasksStaticControl
        {
            get
            {
                if ((this.cachedMembersOfThisUserRoleCanExecuteApprovedTasksStaticControl == null))
                {
                    this.cachedMembersOfThisUserRoleCanExecuteApprovedTasksStaticControl = new StaticControl(this, TasksDialog.ControlIDs.MembersOfThisUserRoleCanExecuteApprovedTasksStaticControl);
                }
                return this.cachedMembersOfThisUserRoleCanExecuteApprovedTasksStaticControl;
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
        StaticControl ITasksDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, TasksDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TasksStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITasksDialogControls.TasksStaticControl2
        {
            get
            {
                if ((this.cachedTasksStaticControl2 == null))
                {
                    this.cachedTasksStaticControl2 = new StaticControl(this, TasksDialog.ControlIDs.TasksStaticControl2);
                }
                return this.cachedTasksStaticControl2;
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
            /// Contains resource string for:  TaskDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTaskDescription = ";Task &description:;ManagedString;Microsoft.EnterpriseManagement.UI.Administratio" +
                "n.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.SelectTasksF" +
                "orm;labelTargetDescription.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ApprovedTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApprovedTasks = ";Approved &tasks:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.Console.Administration.TaskScope;labelApproved.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OnlyTasksExplicitlyAddedToTheApprovedTasksGridAreApproved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOnlyTasksExplicitlyAddedToTheApprovedTasksGridAreApproved = ";&Only tasks explicitly added to the \'Approved tasks\' grid are approved;ManagedSt" +
                "ring;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI" +
                ".Console.Administration.TaskScope;radioButtonSpecific.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AllTasksAreAutomaticallyApprovedIncludingTasksInManagementPacksImportedInTheFuture
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllTasksAreAutomaticallyApprovedIncludingTasksInManagementPacksImportedInTheFuture = ";A&ll tasks are automatically approved, including tasks in Management Packs impor" +
                "ted in the future;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpris" +
                "eManagement.Mom.Internal.UI.Console.Administration.TaskScope;radioButtonAll.Text" +
                "";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ApproveTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApproveTasks = ";Approve tasks;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.Internal.UI.Console.Administration.TaskScope;labelTitle.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MembersOfThisUserRoleCanExecuteApprovedTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMembersOfThisUserRoleCanExecuteApprovedTasks = ";Members of this user role can execute approved tasks.;ManagedString;Microsoft.MO" +
                "M.UI.Console.exe;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administ" +
                "ration.TaskScope;labelDescription.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Common.CommonResources;CommandHelp";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tasks2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTasks2 = ";Tasks;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.Common.CommonResources;SearchTasks";
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
            /// Caches the translated resource string for:  TaskDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskDescription;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ApprovedTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApprovedTasks;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OnlyTasksExplicitlyAddedToTheApprovedTasksGridAreApproved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOnlyTasksExplicitlyAddedToTheApprovedTasksGridAreApproved;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AllTasksAreAutomaticallyApprovedIncludingTasksInManagementPacksImportedInTheFuture
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAllTasksAreAutomaticallyApprovedIncludingTasksInManagementPacksImportedInTheFuture;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ApproveTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApproveTasks;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MembersOfThisUserRoleCanExecuteApprovedTasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMembersOfThisUserRoleCanExecuteApprovedTasks;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tasks2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTasks2;
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
            /// Exposes access to the TaskDescription translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskDescription
            {
                get
                {
                    if ((cachedTaskDescription == null))
                    {
                        cachedTaskDescription = CoreManager.MomConsole.GetIntlStr(ResourceTaskDescription);
                    }
                    return cachedTaskDescription;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ApprovedTasks translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ApprovedTasks
            {
                get
                {
                    if ((cachedApprovedTasks == null))
                    {
                        cachedApprovedTasks = CoreManager.MomConsole.GetIntlStr(ResourceApprovedTasks);
                    }
                    return cachedApprovedTasks;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OnlyTasksExplicitlyAddedToTheApprovedTasksGridAreApproved translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OnlyTasksExplicitlyAddedToTheApprovedTasksGridAreApproved
            {
                get
                {
                    if ((cachedOnlyTasksExplicitlyAddedToTheApprovedTasksGridAreApproved == null))
                    {
                        cachedOnlyTasksExplicitlyAddedToTheApprovedTasksGridAreApproved = CoreManager.MomConsole.GetIntlStr(ResourceOnlyTasksExplicitlyAddedToTheApprovedTasksGridAreApproved);
                    }
                    return cachedOnlyTasksExplicitlyAddedToTheApprovedTasksGridAreApproved;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AllTasksAreAutomaticallyApprovedIncludingTasksInManagementPacksImportedInTheFuture translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AllTasksAreAutomaticallyApprovedIncludingTasksInManagementPacksImportedInTheFuture
            {
                get
                {
                    if ((cachedAllTasksAreAutomaticallyApprovedIncludingTasksInManagementPacksImportedInTheFuture == null))
                    {
                        cachedAllTasksAreAutomaticallyApprovedIncludingTasksInManagementPacksImportedInTheFuture = CoreManager.MomConsole.GetIntlStr(ResourceAllTasksAreAutomaticallyApprovedIncludingTasksInManagementPacksImportedInTheFuture);
                    }
                    return cachedAllTasksAreAutomaticallyApprovedIncludingTasksInManagementPacksImportedInTheFuture;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ApproveTasks translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ApproveTasks
            {
                get
                {
                    if ((cachedApproveTasks == null))
                    {
                        cachedApproveTasks = CoreManager.MomConsole.GetIntlStr(ResourceApproveTasks);
                    }
                    return cachedApproveTasks;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MembersOfThisUserRoleCanExecuteApprovedTasks translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MembersOfThisUserRoleCanExecuteApprovedTasks
            {
                get
                {
                    if ((cachedMembersOfThisUserRoleCanExecuteApprovedTasks == null))
                    {
                        cachedMembersOfThisUserRoleCanExecuteApprovedTasks = CoreManager.MomConsole.GetIntlStr(ResourceMembersOfThisUserRoleCanExecuteApprovedTasks);
                    }
                    return cachedMembersOfThisUserRoleCanExecuteApprovedTasks;
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
            /// Exposes access to the Tasks2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tasks2
            {
                get
                {
                    if ((cachedTasks2 == null))
                    {
                        cachedTasks2 = CoreManager.MomConsole.GetIntlStr(ResourceTasks2);
                    }
                    return cachedTasks2;
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
            /// Control ID for PagePanel
            /// </summary>
            public const string PagePanel = "pagePanel";

            /// <summary>
            /// Control ID for AddRemoveToolbar
            /// </summary>
            public const string AddRemoveToolbar = "toolStripAddRemove";

            /// <summary>
            /// Control ID for TargetDescriptionTextBox
            /// </summary>
            public const string TargetDescriptionTextBox = "textBoxDescription";

            /// <summary>
            /// Control ID for TaskDescriptionStaticControl
            /// </summary>
            public const string TaskDescriptionStaticControl = "labelTargetDescription";

            /// <summary>
            /// Control ID for ApprovedTargetsListView
            /// </summary>
            public const string ApprovedTargetsListView = "sortingListViewTasks";

            /// <summary>
            /// Control ID for ApprovedTasksStaticControl
            /// </summary>
            public const string ApprovedTasksStaticControl = "labelApproved";

            /// <summary>
            /// Control ID for ExplicitlyApprovedTasksRadioButton
            /// </summary>
            public const string ExplicitlyApprovedTasksRadioButton = "radioButtonSpecific";

            /// <summary>
            /// Control ID for AllTasksRadioButton
            /// </summary>
            public const string AllTasksRadioButton = "radioButtonAll";

            /// <summary>
            /// Control ID for ApproveTasksStaticControl
            /// </summary>
            public const string ApproveTasksStaticControl = "labelTitle";

            /// <summary>
            /// Control ID for MembersOfThisUserRoleCanExecuteApprovedTasksStaticControl
            /// </summary>
            public const string MembersOfThisUserRoleCanExecuteApprovedTasksStaticControl = "labelDescription";

            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";

            /// <summary>
            /// Control ID for TasksStaticControl2
            /// </summary>
            public const string TasksStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
