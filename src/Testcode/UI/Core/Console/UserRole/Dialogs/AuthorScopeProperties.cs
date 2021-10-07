// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AuthorScopeProperties.cs">
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

    #region Radio Group Enumeration - Tab1

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group Tab1
    /// </summary>
    /// <history>
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum Tab1
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

    #region Interface Definition - IAuthorScopePropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAuthorScopePropertiesControls, for AuthorScopeProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAuthorScopePropertiesControls
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
        /// Read-only property to access Tab1TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab1TabControl
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
        /// Read-only property to access TasksListView
        /// </summary>
        ListView TasksListView
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
    public class AuthorScopeProperties : Dialog, IAuthorScopePropertiesControls
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
        /// Cache to hold a reference to Tab1TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab1TabControl;

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
        /// Cache to hold a reference to TasksListView of type ListView
        /// </summary>
        private ListView cachedTasksListView;

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
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AuthorScopeProperties of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AuthorScopeProperties(ConsoleApp app)
            :
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group Tab1
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual Tab1 Tab1
        {
            get
            {
                if ((this.Controls.ExplicitlyApprovedTargetsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Tab1.OnlyTargetsExplicitlyAddedToTheApprovedTargetsGridAreApproved;
                }

                if ((this.Controls.AllTargetsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Tab1.AllTargetsAreAutomaticallyApprovedIncludingTargetsInManagementPacksImportedInTheFuture;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }

            set
            {
                if ((value == Tab1.OnlyTargetsExplicitlyAddedToTheApprovedTargetsGridAreApproved))
                {
                    this.Controls.ExplicitlyApprovedTargetsRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == Tab1.AllTargetsAreAutomaticallyApprovedIncludingTargetsInManagementPacksImportedInTheFuture))
                    {
                        this.Controls.AllTargetsRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion

        #region IAuthorScopeProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAuthorScopePropertiesControls Controls
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
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAuthorScopePropertiesControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, AuthorScopeProperties.ControlIDs.ApplyButton);
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
        Button IAuthorScopePropertiesControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AuthorScopeProperties.ControlIDs.CancelButton);
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
        Button IAuthorScopePropertiesControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AuthorScopeProperties.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab1TabControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IAuthorScopePropertiesControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, AuthorScopeProperties.ControlIDs.Tab1TabControl);
                }
                return this.cachedTab1TabControl;
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
        Toolbar IAuthorScopePropertiesControls.AddRemoveToolbar
        {
            get
            {
                if ((this.cachedAddRemoveToolbar == null))
                {
                    QID queryId = new QID(";[UIA]AutomationId =\'" + AuthorScopeProperties.ControlIDs.PanelApprovedTargets + "\';[UIA]AutomationId=\'" + AuthorScopeProperties.ControlIDs.AddRemoveToolbar + "\'");
                    this.cachedAddRemoveToolbar = new Toolbar(this, queryId, Core.Common.Constants.DefaultContextMenuTimeout);                    
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
        TextBox IAuthorScopePropertiesControls.TargetDescriptionTextBox
        {
            get
            {
                if ((this.cachedTargetDescriptionTextBox == null))
                {
                    this.cachedTargetDescriptionTextBox = new TextBox(this, AuthorScopeProperties.ControlIDs.TargetDescriptionTextBox);
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
        StaticControl IAuthorScopePropertiesControls.TargetDescriptionStaticControl
        {
            get
            {
                if ((this.cachedTargetDescriptionStaticControl == null))
                {
                    this.cachedTargetDescriptionStaticControl = new StaticControl(this, AuthorScopeProperties.ControlIDs.TargetDescriptionStaticControl);
                }
                return this.cachedTargetDescriptionStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TasksListView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView IAuthorScopePropertiesControls.TasksListView
        {
            get
            {
                if ((this.cachedTasksListView == null))
                {
                    this.cachedTasksListView = new ListView(this, AuthorScopeProperties.ControlIDs.TasksListView);
                }
                return this.cachedTasksListView;
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
        StaticControl IAuthorScopePropertiesControls.ApprovedTargetsStaticControl
        {
            get
            {
                if ((this.cachedApprovedTargetsStaticControl == null))
                {
                    this.cachedApprovedTargetsStaticControl = new StaticControl(this, AuthorScopeProperties.ControlIDs.ApprovedTargetsStaticControl);
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
        RadioButton IAuthorScopePropertiesControls.ExplicitlyApprovedTargetsRadioButton
        {
            get
            {
                if ((this.cachedExplicitlyApprovedTargetsRadioButton == null))
                {
                    this.cachedExplicitlyApprovedTargetsRadioButton = new RadioButton(this, AuthorScopeProperties.ControlIDs.ExplicitlyApprovedTargetsRadioButton);
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
        RadioButton IAuthorScopePropertiesControls.AllTargetsRadioButton
        {
            get
            {
                if ((this.cachedAllTargetsRadioButton == null))
                {
                    this.cachedAllTargetsRadioButton = new RadioButton(this, AuthorScopeProperties.ControlIDs.AllTargetsRadioButton);
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
        StaticControl IAuthorScopePropertiesControls.ApproveTargetsStaticControl
        {
            get
            {
                if ((this.cachedApproveTargetsStaticControl == null))
                {
                    this.cachedApproveTargetsStaticControl = new StaticControl(this, AuthorScopeProperties.ControlIDs.ApproveTargetsStaticControl);
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
        StaticControl IAuthorScopePropertiesControls.MembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargetsStaticControl
        {
            get
            {
                if ((this.cachedMembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargetsStaticControl == null))
                {
                    this.cachedMembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargetsStaticControl = new StaticControl(this, AuthorScopeProperties.ControlIDs.MembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargetsStaticControl);
                }
                return this.cachedMembersOfThisUserRoleCanCreateOrEditMonitorsRulesTasksOrViewsForApprovedTargetsStaticControl;
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
            /// Contains resource string for:  Tab1
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab1 = "Tab1";

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
            /// Contains resource string for:  Management Server class
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagmentServerClass = 
                ";Management Server" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";ManagementServerNoMnemonic";
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
            /// Caches the translated resource string for:  Tab1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab1;

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
            /// Caches the translated resource string for:  Management Server class
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagmentServerClass;
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
            /// Exposes access to the Tab1 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab1
            {
                get
                {
                    if ((cachedTab1 == null))
                    {
                        cachedTab1 = CoreManager.MomConsole.GetIntlStr(ResourceTab1);
                    }
                    return cachedTab1;
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
            /// Exposes access to the Management Server class translated resource string
            /// </summary>
            /// <history>
            /// 	[a-joelj] 13APR09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagmentServerClass
            {
                get
                {
                    if ((cachedManagmentServerClass == null))
                    {
                        cachedManagmentServerClass = CoreManager.MomConsole.GetIntlStr(ResourceManagmentServerClass);
                    }
                    return cachedManagmentServerClass;
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
            /// Control ID for Tab1TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab1TabControl = "tabPages";

            /// <summary>
            /// Control ID for AddRemoveToolbar
            /// </summary>
            public const string AddRemoveToolbar = "toolStripAddRemove";                     

            /// <summary>
            /// Control ID for PanelApprovedTargets
            /// </summary>
            public const string PanelApprovedTargets = "panelApprovedTargets";

            /// <summary>
            /// Control ID for TargetDescriptionTextBox
            /// </summary>
            public const string TargetDescriptionTextBox = "textBoxDescription";

            /// <summary>
            /// Control ID for TargetDescriptionStaticControl
            /// </summary>
            public const string TargetDescriptionStaticControl = "labelTargetDescription";

            /// <summary>
            /// Control ID for TasksListView
            /// </summary>
            public const string TasksListView = "sortingListViewTargets";

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
        }
        #endregion
    }
}
