// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AuthorScopeDialog.cs">
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

    #region Radio Group Enumeration - RadioGroupClasses

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroupClasses
    /// </summary>
    /// <history>
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroupClasses
    {
        /// <summary>
        /// OnlyTargetsExplicitlyAddedToTheApprovedTargetsGridAreApproved = 0
        /// </summary>
        OnlyTargetsExplicitlyAddedToTheApprovedTargetsGridAreApproved = 0,

        /// <summary>
        /// AllTargetsAreAutomaticallyApprovedIncludingTargetsInManagementPacksImportedInTheFuture = 1
        /// </summary>
        AllTargetsAreAutomaticallyApprovedIncludingTargetsInManagementPacksImportedInTheFuture = 1,
    }
    #endregion

    #region Interface Definition - IAuthorScopeDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAuthorScopeDialogControls, for AuthorScopeDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAuthorScopeDialogControls
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
        /// Read-only property to access TargetDescriptionStaticControl
        /// </summary>
        StaticControl TargetDescriptionStaticControl
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
        /// Read-only property to access ApprovedTargetsStaticControl
        /// </summary>
        StaticControl ApprovedTargetsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ExplicitlyApprovedTargetsRadioButton
        /// </summary>
        RadioButton ExplicitlyApprovedTargetsRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AllTargetsRadioButton
        /// </summary>
        RadioButton AllTargetsRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ApproveTargetsStaticControl
        /// </summary>
        StaticControl ApproveTargetsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargetsStaticControl
        /// </summary>
        StaticControl MembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargetsStaticControl
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
        /// Read-only property to access AuthorScopeStaticControl2
        /// </summary>
        StaticControl AuthorScopeStaticControl2
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
    public class AuthorScopeDialog : Dialog, IAuthorScopeDialogControls
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
        /// Cache to hold a reference to TargetDescriptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTargetDescriptionStaticControl;

        /// <summary>
        /// Cache to hold a reference to ApprovedTargetsListView of type ListView
        /// </summary>
        private ListView cachedApprovedTargetsListView;

        /// <summary>
        /// Cache to hold a reference to ApprovedTargetsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedApprovedTargetsStaticControl;

        /// <summary>
        /// Cache to hold a reference to ExplicitlyApprovedTargetsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedExplicitlyApprovedTargetsRadioButton;

        /// <summary>
        /// Cache to hold a reference to AllTargetsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAllTargetsRadioButton;

        /// <summary>
        /// Cache to hold a reference to ApproveTargetsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedApproveTargetsStaticControl;

        /// <summary>
        /// Cache to hold a reference to MembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargetsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargetsStaticControl;

        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;

        /// <summary>
        /// Cache to hold a reference to AuthorScopeStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedAuthorScopeStaticControl2;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AuthorScopeDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AuthorScopeDialog(ConsoleApp app)
            :
                base(app, Init(app))
        {
            //this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout); 
        }
        #endregion

        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroupClasses
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroupClasses RadioGroupClasses
        {
            get
            {
                if ((this.Controls.ExplicitlyApprovedTargetsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroupClasses.OnlyTargetsExplicitlyAddedToTheApprovedTargetsGridAreApproved;
                }

                if ((this.Controls.AllTargetsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroupClasses.AllTargetsAreAutomaticallyApprovedIncludingTargetsInManagementPacksImportedInTheFuture;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }

            set
            {
                if ((value == RadioGroupClasses.OnlyTargetsExplicitlyAddedToTheApprovedTargetsGridAreApproved))
                {
                    this.Controls.ExplicitlyApprovedTargetsRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroupClasses.AllTargetsAreAutomaticallyApprovedIncludingTargetsInManagementPacksImportedInTheFuture))
                    {
                        this.Controls.AllTargetsRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion

        #region IAuthorScopeDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAuthorScopeDialogControls Controls
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
        Button IAuthorScopeDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, AuthorScopeDialog.ControlIDs.PreviousButton);
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
        Button IAuthorScopeDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, AuthorScopeDialog.ControlIDs.NextButton);
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
        Button IAuthorScopeDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, AuthorScopeDialog.ControlIDs.CreateButton);
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
        Button IAuthorScopeDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AuthorScopeDialog.ControlIDs.CancelButton);
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
        StaticControl IAuthorScopeDialogControls.GeneralStaticControl
        {
            get
            {
                if ((this.cachedGeneralStaticControl == null))
                {
                    this.cachedGeneralStaticControl = new StaticControl(this, AuthorScopeDialog.ControlIDs.GeneralStaticControl);
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
        StaticControl IAuthorScopeDialogControls.AuthorScopeStaticControl
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
        StaticControl IAuthorScopeDialogControls.GroupScopeStaticControl
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
        StaticControl IAuthorScopeDialogControls.TasksStaticControl
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
        StaticControl IAuthorScopeDialogControls.ViewsStaticControl
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
        StaticControl IAuthorScopeDialogControls.SummaryStaticControl
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
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IAuthorScopeDialogControls.AddRemoveToolbar
        {
            get
            {
                if ((this.cachedAddRemoveToolbar == null))
                {
                    this.cachedAddRemoveToolbar = new Toolbar(this /*, AuthorScopeDialog.ControlIDs.AddRemoveToolbar*/);
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
        TextBox IAuthorScopeDialogControls.TargetDescriptionTextBox
        {
            get
            {
                if ((this.cachedTargetDescriptionTextBox == null))
                {
                    this.cachedTargetDescriptionTextBox = new TextBox(this, AuthorScopeDialog.ControlIDs.TargetDescriptionTextBox);
                }
                return this.cachedTargetDescriptionTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TargetDescriptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAuthorScopeDialogControls.TargetDescriptionStaticControl
        {
            get
            {
                if ((this.cachedTargetDescriptionStaticControl == null))
                {
                    this.cachedTargetDescriptionStaticControl = new StaticControl(this, AuthorScopeDialog.ControlIDs.TargetDescriptionStaticControl);
                }
                return this.cachedTargetDescriptionStaticControl;
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
        ListView IAuthorScopeDialogControls.ApprovedTargetsListView
        {
            get
            {
                if ((this.cachedApprovedTargetsListView == null))
                {
                    this.cachedApprovedTargetsListView = new ListView(this, AuthorScopeDialog.ControlIDs.ApprovedTargetsListView);
                }
                return this.cachedApprovedTargetsListView;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApprovedTargetsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAuthorScopeDialogControls.ApprovedTargetsStaticControl
        {
            get
            {
                if ((this.cachedApprovedTargetsStaticControl == null))
                {
                    this.cachedApprovedTargetsStaticControl = new StaticControl(this, AuthorScopeDialog.ControlIDs.ApprovedTargetsStaticControl);
                }
                return this.cachedApprovedTargetsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExplicitlyApprovedTargetsRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAuthorScopeDialogControls.ExplicitlyApprovedTargetsRadioButton
        {
            get
            {
                if ((this.cachedExplicitlyApprovedTargetsRadioButton == null))
                {
                    this.cachedExplicitlyApprovedTargetsRadioButton = new RadioButton(this, AuthorScopeDialog.ControlIDs.ExplicitlyApprovedTargetsRadioButton);
                }
                return this.cachedExplicitlyApprovedTargetsRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllTargetsRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAuthorScopeDialogControls.AllTargetsRadioButton
        {
            get
            {
                if ((this.cachedAllTargetsRadioButton == null))
                {
                    this.cachedAllTargetsRadioButton = new RadioButton(this, AuthorScopeDialog.ControlIDs.AllTargetsRadioButton);
                }
                return this.cachedAllTargetsRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApproveTargetsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAuthorScopeDialogControls.ApproveTargetsStaticControl
        {
            get
            {
                if ((this.cachedApproveTargetsStaticControl == null))
                {
                    this.cachedApproveTargetsStaticControl = new StaticControl(this, AuthorScopeDialog.ControlIDs.ApproveTargetsStaticControl);
                }
                return this.cachedApproveTargetsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargetsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAuthorScopeDialogControls.MembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargetsStaticControl
        {
            get
            {
                if ((this.cachedMembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargetsStaticControl == null))
                {
                    this.cachedMembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargetsStaticControl = new StaticControl(this, AuthorScopeDialog.ControlIDs.MembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargetsStaticControl);
                }
                return this.cachedMembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargetsStaticControl;
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
        StaticControl IAuthorScopeDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, AuthorScopeDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AuthorScopeStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAuthorScopeDialogControls.AuthorScopeStaticControl2
        {
            get
            {
                if ((this.cachedAuthorScopeStaticControl2 == null))
                {
                    this.cachedAuthorScopeStaticControl2 = new StaticControl(this, AuthorScopeDialog.ControlIDs.AuthorScopeStaticControl2);
                }
                return this.cachedAuthorScopeStaticControl2;
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
            /// Contains resource string for:  TargetDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTargetDescription = ";Target &description:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.Console.Administration.AuthorScope;labelTargetDes" +
                "cription.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ApprovedTargets
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApprovedTargets = ";Approved &targets:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpri" +
                "seManagement.Mom.Internal.UI.Console.Administration.AuthorScope;labelApproved.Te" +
                "xt";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OnlyTargetsExplicitlyAddedToTheApprovedTargetsGridAreApproved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOnlyTargetsExplicitlyAddedToTheApprovedTargetsGridAreApproved = ";&Only targets explicitly added to the \'Approved targets\' grid are approved;Manag" +
                "edString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Interna" +
                "l.UI.Console.Administration.AuthorScope;radioButtonSpecific.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AllTargetsAreAutomaticallyApprovedIncludingTargetsInManagementPacksImportedInTheFuture
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllTargetsAreAutomaticallyApprovedIncludingTargetsInManagementPacksImportedInTheFuture = ";A&ll targets are automatically approved, including targets in Management Packs i" +
                "mported in the future;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enter" +
                "priseManagement.Mom.Internal.UI.Console.Administration.AuthorScope;radioButtonAl" +
                "l.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ApproveTargets
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApproveTargets = ";Approve targets;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Console.Administration.AuthorScope;labelTitle.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargets
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargets = ";Members of this user role can create or edit monitors, rules, tasks, or views fo" +
                "r approved targets.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.Console.Administration.AuthorScope;labelDescriptio" +
                "n.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Common.CommonResources;CommandHelp";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AuthorScope2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAuthorScope2 = ";Author Scope;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.Internal.UI.Console.Administration.AdminResources;UserRoleAuthorScope" +
                "Title";
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
            /// Caches the translated resource string for:  TargetDescription
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTargetDescription;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ApprovedTargets
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApprovedTargets;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OnlyTargetsExplicitlyAddedToTheApprovedTargetsGridAreApproved
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOnlyTargetsExplicitlyAddedToTheApprovedTargetsGridAreApproved;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AllTargetsAreAutomaticallyApprovedIncludingTargetsInManagementPacksImportedInTheFuture
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAllTargetsAreAutomaticallyApprovedIncludingTargetsInManagementPacksImportedInTheFuture;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ApproveTargets
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApproveTargets;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargets
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargets;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AuthorScope2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAuthorScope2;
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
            /// Exposes access to the TargetDescription translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TargetDescription
            {
                get
                {
                    if ((cachedTargetDescription == null))
                    {
                        cachedTargetDescription = CoreManager.MomConsole.GetIntlStr(ResourceTargetDescription);
                    }
                    return cachedTargetDescription;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ApprovedTargets translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ApprovedTargets
            {
                get
                {
                    if ((cachedApprovedTargets == null))
                    {
                        cachedApprovedTargets = CoreManager.MomConsole.GetIntlStr(ResourceApprovedTargets);
                    }
                    return cachedApprovedTargets;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OnlyTargetsExplicitlyAddedToTheApprovedTargetsGridAreApproved translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OnlyTargetsExplicitlyAddedToTheApprovedTargetsGridAreApproved
            {
                get
                {
                    if ((cachedOnlyTargetsExplicitlyAddedToTheApprovedTargetsGridAreApproved == null))
                    {
                        cachedOnlyTargetsExplicitlyAddedToTheApprovedTargetsGridAreApproved = CoreManager.MomConsole.GetIntlStr(ResourceOnlyTargetsExplicitlyAddedToTheApprovedTargetsGridAreApproved);
                    }
                    return cachedOnlyTargetsExplicitlyAddedToTheApprovedTargetsGridAreApproved;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AllTargetsAreAutomaticallyApprovedIncludingTargetsInManagementPacksImportedInTheFuture translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AllTargetsAreAutomaticallyApprovedIncludingTargetsInManagementPacksImportedInTheFuture
            {
                get
                {
                    if ((cachedAllTargetsAreAutomaticallyApprovedIncludingTargetsInManagementPacksImportedInTheFuture == null))
                    {
                        cachedAllTargetsAreAutomaticallyApprovedIncludingTargetsInManagementPacksImportedInTheFuture = CoreManager.MomConsole.GetIntlStr(ResourceAllTargetsAreAutomaticallyApprovedIncludingTargetsInManagementPacksImportedInTheFuture);
                    }
                    return cachedAllTargetsAreAutomaticallyApprovedIncludingTargetsInManagementPacksImportedInTheFuture;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ApproveTargets translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ApproveTargets
            {
                get
                {
                    if ((cachedApproveTargets == null))
                    {
                        cachedApproveTargets = CoreManager.MomConsole.GetIntlStr(ResourceApproveTargets);
                    }
                    return cachedApproveTargets;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargets translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargets
            {
                get
                {
                    if ((cachedMembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargets == null))
                    {
                        cachedMembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargets = CoreManager.MomConsole.GetIntlStr(ResourceMembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargets);
                    }
                    return cachedMembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargets;
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
            /// Exposes access to the AuthorScope2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AuthorScope2
            {
                get
                {
                    if ((cachedAuthorScope2 == null))
                    {
                        cachedAuthorScope2 = CoreManager.MomConsole.GetIntlStr(ResourceAuthorScope2);
                    }
                    return cachedAuthorScope2;
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
            /// Control ID for AddRemoveToolbar
            /// </summary>
            public const string AddRemoveToolbar = "toolStripAddRemove";

            /// <summary>
            /// Control ID for TargetDescriptionTextBox
            /// </summary>
            public const string TargetDescriptionTextBox = "textBoxDescription";

            /// <summary>
            /// Control ID for TargetDescriptionStaticControl
            /// </summary>
            public const string TargetDescriptionStaticControl = "labelTargetDescription";

            /// <summary>
            /// Control ID for ApprovedTargetsListView
            /// </summary>
            public const string ApprovedTargetsListView = "sortingListViewTargets";

            /// <summary>
            /// Control ID for ApprovedTargetsStaticControl
            /// </summary>
            public const string ApprovedTargetsStaticControl = "labelApproved";

            /// <summary>
            /// Control ID for ExplicitlyApprovedTargetsRadioButton
            /// </summary>
            public const string ExplicitlyApprovedTargetsRadioButton = "radioButtonSpecific";

            /// <summary>
            /// Control ID for AllTargetsRadioButton
            /// </summary>
            public const string AllTargetsRadioButton = "radioButtonAll";

            /// <summary>
            /// Control ID for ApproveTargetsStaticControl
            /// </summary>
            public const string ApproveTargetsStaticControl = "labelTitle";

            /// <summary>
            /// Control ID for MembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargetsStaticControl
            /// </summary>
            public const string MembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargetsStaticControl = "labelDescription";

            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";

            /// <summary>
            /// Control ID for AuthorScopeStaticControl2
            /// </summary>
            public const string AuthorScopeStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
