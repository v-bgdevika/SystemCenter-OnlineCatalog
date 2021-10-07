// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TasksProperties.cs">
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

    #region Radio Group Enumeration - Tab3

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group Tab3
    /// </summary>
    /// <history>
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum Tab3
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

    #region Interface Definition - ITasksPropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITasksPropertiesControls, for TasksProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 7/21/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITasksPropertiesControls
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
        /// Read-only property to access Tab3TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab3TabControl
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
        /// Read-only property to access SummaryListView
        /// </summary>
        ListView SummaryListView
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
    public class TasksProperties : Dialog, ITasksPropertiesControls
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
        /// Cache to hold a reference to Tab3TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab3TabControl;

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
        /// Cache to hold a reference to SummaryListView of type ListView
        /// </summary>
        private ListView cachedSummaryListView;

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
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of TasksProperties of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TasksProperties(ConsoleApp app)
            :
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group Tab3
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual Tab3 Tab3
        {
            get
            {
                if ((this.Controls.ExplicitlyApprovedTasksRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Tab3.OnlyTasksExplicitlyAddedToTheApprovedTasksGridAreApproved;
                }

                if ((this.Controls.AllTasksRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Tab3.AllTasksAreAutomaticallyApprovedIncludingTasksInManagementPacksImportedInTheFuture;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }

            set
            {
                if ((value == Tab3.OnlyTasksExplicitlyAddedToTheApprovedTasksGridAreApproved))
                {
                    this.Controls.ExplicitlyApprovedTasksRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == Tab3.AllTasksAreAutomaticallyApprovedIncludingTasksInManagementPacksImportedInTheFuture))
                    {
                        this.Controls.AllTasksRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion

        #region ITasksProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITasksPropertiesControls Controls
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
        Button ITasksPropertiesControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, TasksProperties.ControlIDs.ApplyButton);
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
        Button ITasksPropertiesControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, TasksProperties.ControlIDs.CancelButton);
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
        ///     [a-joelj]   28OCT09 Maui 2.0: Modified to use QID in Button constructor
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITasksPropertiesControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    // [a-joelj] - Maui 2.0 Required Change: Calling the Button constructor using 'this' and the 
                    // ControlId instead of using a QID is returning the wrong Button or no Button at all. 
                    // Modified to use a QID in the UIA tree for matching with the Button AutomationId.
                    QID queryId = new QID(";[UIA]AutomationId='" + TasksProperties.ControlIDs.OKButton + "' && Role='push button'");

                    this.cachedOKButton = new Button(this, queryId, Common.Constants.DefaultContextMenuTimeout);
                }
                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab3TabControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl ITasksPropertiesControls.Tab3TabControl
        {
            get
            {
                if ((this.cachedTab3TabControl == null))
                {
                    this.cachedTab3TabControl = new TabControl(this, TasksProperties.ControlIDs.Tab3TabControl);
                }
                return this.cachedTab3TabControl;
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
        Toolbar ITasksPropertiesControls.AddRemoveToolbar
        {
            get
            {
                if ((this.cachedAddRemoveToolbar == null))
                {
                    // [nathd] - Maui 2.0: Calling the Toolbar constructor with 'this' being the only parameter is returning 
                    // the wrong toolbar. For example, it is returning the "View Group Members" toolbar rather than the
                    // "AddRemoveToolbar". There is no caption/name defined for these toolbars therefore we cannot call the 
                    // constructor with the caption/name. Switching over to the UIA tree and using a QID with the AutomationId.
                    QID queryId = new QID(";[UIA]AutomationId=\'" + TasksProperties.ControlIDs.AddRemoveToolbar + "\'");
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
        TextBox ITasksPropertiesControls.TargetDescriptionTextBox
        {
            get
            {
                if ((this.cachedTargetDescriptionTextBox == null))
                {
                    this.cachedTargetDescriptionTextBox = new TextBox(this, TasksProperties.ControlIDs.TargetDescriptionTextBox);
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
        StaticControl ITasksPropertiesControls.TaskDescriptionStaticControl
        {
            get
            {
                if ((this.cachedTaskDescriptionStaticControl == null))
                {
                    this.cachedTaskDescriptionStaticControl = new StaticControl(this, TasksProperties.ControlIDs.TaskDescriptionStaticControl);
                }
                return this.cachedTaskDescriptionStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryListView control
        /// </summary>
        /// <history>
        /// 	[ruhim] 7/21/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListView ITasksPropertiesControls.SummaryListView
        {
            get
            {
                if ((this.cachedSummaryListView == null))
                {
                    this.cachedSummaryListView = new ListView(this, TasksProperties.ControlIDs.SummaryListView);
                }
                return this.cachedSummaryListView;
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
        StaticControl ITasksPropertiesControls.ApprovedTasksStaticControl
        {
            get
            {
                if ((this.cachedApprovedTasksStaticControl == null))
                {
                    this.cachedApprovedTasksStaticControl = new StaticControl(this, TasksProperties.ControlIDs.ApprovedTasksStaticControl);
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
        RadioButton ITasksPropertiesControls.ExplicitlyApprovedTasksRadioButton
        {
            get
            {
                if ((this.cachedExplicitlyApprovedTasksRadioButton == null))
                {
                    this.cachedExplicitlyApprovedTasksRadioButton = new RadioButton(this, TasksProperties.ControlIDs.ExplicitlyApprovedTasksRadioButton);
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
        RadioButton ITasksPropertiesControls.AllTasksRadioButton
        {
            get
            {
                if ((this.cachedAllTasksRadioButton == null))
                {
                    this.cachedAllTasksRadioButton = new RadioButton(this, TasksProperties.ControlIDs.AllTasksRadioButton);
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
        StaticControl ITasksPropertiesControls.ApproveTasksStaticControl
        {
            get
            {
                if ((this.cachedApproveTasksStaticControl == null))
                {
                    this.cachedApproveTasksStaticControl = new StaticControl(this, TasksProperties.ControlIDs.ApproveTasksStaticControl);
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
        StaticControl ITasksPropertiesControls.MembersOfThisUserRoleCanExecuteApprovedTasksStaticControl
        {
            get
            {
                if ((this.cachedMembersOfThisUserRoleCanExecuteApprovedTasksStaticControl == null))
                {
                    this.cachedMembersOfThisUserRoleCanExecuteApprovedTasksStaticControl = new StaticControl(this, TasksProperties.ControlIDs.MembersOfThisUserRoleCanExecuteApprovedTasksStaticControl);
                }
                return this.cachedMembersOfThisUserRoleCanExecuteApprovedTasksStaticControl;
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
            /// Contains resource string for:  Tab3
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab3 = "Tab3";

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
            /// Caches the translated resource string for:  Tab3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab3;

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
            /// Exposes access to the Tab3 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 7/21/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab3
            {
                get
                {
                    if ((cachedTab3 == null))
                    {
                        cachedTab3 = CoreManager.MomConsole.GetIntlStr(ResourceTab3);
                    }
                    return cachedTab3;
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
            /// Control ID for Tab3TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab3TabControl = "tabPages";

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
            /// Control ID for SummaryListView
            /// </summary>
            public const string SummaryListView = "sortingListViewTasks";

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
        }
        #endregion
    }
}
