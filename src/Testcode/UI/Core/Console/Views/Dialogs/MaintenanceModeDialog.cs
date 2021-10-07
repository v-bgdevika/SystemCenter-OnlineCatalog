// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="MaintenanceModeDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[lucyra] 7/15/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Radio Group Enumeration - ApplyTo

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group ApplyTo
    /// </summary>
    /// <history>
    /// 	[lucyra] 7/15/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum ApplyTo
    {
        /// <summary>
        /// TheSelectedObjectsAndAllTheirContainedObjects = 0
        /// </summary>
        TheSelectedObjectsAndAllTheirContainedObjects = 0,

        /// <summary>
        /// TheSelectedObjectsOnly = 1
        /// </summary>
        TheSelectedObjectsOnly = 1,
    }
    #endregion

    #region Radio Group Enumeration - MaintenanceModeDuration

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group MaintenanceModeDuration
    /// </summary>
    /// <history>
    /// 	[lucyra] 7/15/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum MaintenanceModeDuration
    {
        /// <summary>
        /// SpecificEndTime = 0
        /// </summary>
        SpecificEndTime = 0,

        /// <summary>
        /// NumberOfMinutes = 1
        /// </summary>
        NumberOfMinutes = 1,
    }
    #endregion

    #region Interface Definition - IMaintenanceModeDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IMaintenanceModeDialogControls, for MaintenanceModeDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[lucyra] 7/15/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMaintenanceModeDialogControls
    {
        /// <summary>
        /// Read-only property to access TheSelectedObjectsAndAllTheirContainedObjectsRadioButton
        /// </summary>
        RadioButton TheSelectedObjectsAndAllTheirContainedObjectsRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TheSelectedObjectsOnlyRadioButton
        /// </summary>
        RadioButton TheSelectedObjectsOnlyRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access SpecificEndTimeRadioButton
        /// </summary>
        RadioButton SpecificEndTimeRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access NumberOfMinutesRadioButton
        /// </summary>
        RadioButton NumberOfMinutesRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TimePickerComboBox
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox TimePickerComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MinuteSpinnerComboBox
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        EditComboBox MinuteSpinnerComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CommentTextBox
        /// </summary>
        TextBox CommentTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MaintenanceCategoryComboBox
        /// </summary>
        ComboBox MaintenanceCategoryComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PlannedCheckBox
        /// </summary>
        CheckBox PlannedCheckBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access RulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlertsStaticControl
        /// </summary>
        StaticControl RulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlertsStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceModeStaticControl
        /// </summary>
        StaticControl TheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceModeStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access CommentStaticControl
        /// </summary>
        StaticControl CommentStaticControl
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
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access MaintenanceCategoryStaticControl
        /// </summary>
        StaticControl MaintenanceCategoryStaticControl
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
    /// 	[lucyra] 7/15/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class MaintenanceModeDialog : Dialog, IMaintenanceModeDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 15000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to TheSelectedObjectsAndAllTheirContainedObjectsRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedTheSelectedObjectsAndAllTheirContainedObjectsRadioButton;

        /// <summary>
        /// Cache to hold a reference to TheSelectedObjectsOnlyRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedTheSelectedObjectsOnlyRadioButton;

        /// <summary>
        /// Cache to hold a reference to SpecificEndTimeRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedSpecificEndTimeRadioButton;

        /// <summary>
        /// Cache to hold a reference to NumberOfMinutesRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedNumberOfMinutesRadioButton;

        /// <summary>
        /// Cache to hold a reference to TimePickerComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedTimePickerComboBox;

        /// <summary>
        /// Cache to hold a reference to MinuteSpinnerComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedMinuteSpinnerComboBox;

        /// <summary>
        /// Cache to hold a reference to CommentTextBox of type TextBox
        /// </summary>
        private TextBox cachedCommentTextBox;

        /// <summary>
        /// Cache to hold a reference to MaintenanceCategoryComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedMaintenanceCategoryComboBox;

        /// <summary>
        /// Cache to hold a reference to PlannedCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedPlannedCheckBox;

        /// <summary>
        /// Cache to hold a reference to RulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlertsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlertsStaticControl;

        /// <summary>
        /// Cache to hold a reference to TheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceModeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceModeStaticControl;

        /// <summary>
        /// Cache to hold a reference to CommentStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCommentStaticControl;

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;

        /// <summary>
        /// Cache to hold a reference to MaintenanceCategoryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMaintenanceCategoryStaticControl;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of MaintenanceModeDialog of type App
        /// </param>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public MaintenanceModeDialog(ConsoleApp app)
            :
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion

        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group ApplyTo
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ApplyTo ApplyTo
        {
            get
            {
                if ((this.Controls.TheSelectedObjectsAndAllTheirContainedObjectsRadioButton.ButtonState == ButtonState.Checked))
                {
                    return ApplyTo.TheSelectedObjectsAndAllTheirContainedObjects;
                }

                if ((this.Controls.TheSelectedObjectsOnlyRadioButton.ButtonState == ButtonState.Checked))
                {
                    return ApplyTo.TheSelectedObjectsOnly;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }

            set
            {
                if ((value == ApplyTo.TheSelectedObjectsAndAllTheirContainedObjects))
                {
                    this.Controls.TheSelectedObjectsAndAllTheirContainedObjectsRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == ApplyTo.TheSelectedObjectsOnly))
                    {
                        this.Controls.TheSelectedObjectsOnlyRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group MaintenanceModeDuration
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual MaintenanceModeDuration MaintenanceModeDuration
        {
            get
            {
                if ((this.Controls.SpecificEndTimeRadioButton.ButtonState == ButtonState.Checked))
                {
                    return MaintenanceModeDuration.SpecificEndTime;
                }

                if ((this.Controls.NumberOfMinutesRadioButton.ButtonState == ButtonState.Checked))
                {
                    return MaintenanceModeDuration.NumberOfMinutes;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }

            set
            {
                if ((value == MaintenanceModeDuration.SpecificEndTime))
                {
                    this.Controls.SpecificEndTimeRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == MaintenanceModeDuration.NumberOfMinutes))
                    {
                        this.Controls.NumberOfMinutesRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion

        #region IMaintenanceModeDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IMaintenanceModeDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion

        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox Planned
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Planned
        {
            get
            {
                return this.Controls.PlannedCheckBox.Checked;
            }

            set
            {
                this.Controls.PlannedCheckBox.Checked = value;
            }
        }
        #endregion

        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TimePickerComboBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TimePickerComboBoxText
        {
            get
            {
                return this.Controls.TimePickerComboBox.Text;
            }

            set
            {
                this.Controls.TimePickerComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MinuteSpinnerComboBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MinuteSpinnerComboBoxText
        {
            get
            {
                return this.Controls.MinuteSpinnerComboBox.Text;
            }

            set
            {
                this.Controls.MinuteSpinnerComboBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Comment
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CommentText
        {
            get
            {
                return this.Controls.CommentTextBox.Text;
            }

            set
            {
                this.Controls.CommentTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MaintenanceCategory
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MaintenanceCategoryText
        {
            get
            {
                return this.Controls.MaintenanceCategoryComboBox.Text;
            }

            set
            {
                this.Controls.MaintenanceCategoryComboBox.SelectByText(value, true);
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TheSelectedObjectsAndAllTheirContainedObjectsRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IMaintenanceModeDialogControls.TheSelectedObjectsAndAllTheirContainedObjectsRadioButton
        {
            get
            {
                if ((this.cachedTheSelectedObjectsAndAllTheirContainedObjectsRadioButton == null))
                {
                    this.cachedTheSelectedObjectsAndAllTheirContainedObjectsRadioButton = new RadioButton(this, MaintenanceModeDialog.ControlIDs.TheSelectedObjectsAndAllTheirContainedObjectsRadioButton);
                }
                return this.cachedTheSelectedObjectsAndAllTheirContainedObjectsRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TheSelectedObjectsOnlyRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IMaintenanceModeDialogControls.TheSelectedObjectsOnlyRadioButton
        {
            get
            {
                if ((this.cachedTheSelectedObjectsOnlyRadioButton == null))
                {
                    this.cachedTheSelectedObjectsOnlyRadioButton = new RadioButton(this, MaintenanceModeDialog.ControlIDs.TheSelectedObjectsOnlyRadioButton);
                }
                return this.cachedTheSelectedObjectsOnlyRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecificEndTimeRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IMaintenanceModeDialogControls.SpecificEndTimeRadioButton
        {
            get
            {
                if ((this.cachedSpecificEndTimeRadioButton == null))
                {
                    this.cachedSpecificEndTimeRadioButton = new RadioButton(this, MaintenanceModeDialog.ControlIDs.SpecificEndTimeRadioButton);
                }
                return this.cachedSpecificEndTimeRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NumberOfMinutesRadioButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IMaintenanceModeDialogControls.NumberOfMinutesRadioButton
        {
            get
            {
                if ((this.cachedNumberOfMinutesRadioButton == null))
                {
                    this.cachedNumberOfMinutesRadioButton = new RadioButton(this, MaintenanceModeDialog.ControlIDs.NumberOfMinutesRadioButton);
                }
                return this.cachedNumberOfMinutesRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimePickerComboBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IMaintenanceModeDialogControls.TimePickerComboBox
        {
            get
            {
                if ((this.cachedTimePickerComboBox == null))
                {
                    this.cachedTimePickerComboBox = new ComboBox(this, MaintenanceModeDialog.ControlIDs.TimePickerComboBox);
                }
                return this.cachedTimePickerComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MinuteSpinnerComboBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IMaintenanceModeDialogControls.MinuteSpinnerComboBox
        {
            get
            {
                if ((this.cachedMinuteSpinnerComboBox == null))
                {
                    this.cachedMinuteSpinnerComboBox = new EditComboBox(this, MaintenanceModeDialog.ControlIDs.MinuteSpinnerComboBox);
                }
                return this.cachedMinuteSpinnerComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CommentTextBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IMaintenanceModeDialogControls.CommentTextBox
        {
            get
            {
                if ((this.cachedCommentTextBox == null))
                {
                    this.cachedCommentTextBox = new TextBox(this, MaintenanceModeDialog.ControlIDs.CommentTextBox);
                }
                return this.cachedCommentTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MaintenanceCategoryComboBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IMaintenanceModeDialogControls.MaintenanceCategoryComboBox
        {
            get
            {
                if ((this.cachedMaintenanceCategoryComboBox == null))
                {
                    this.cachedMaintenanceCategoryComboBox = new ComboBox(this, MaintenanceModeDialog.ControlIDs.MaintenanceCategoryComboBox);
                }
                return this.cachedMaintenanceCategoryComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PlannedCheckBox control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IMaintenanceModeDialogControls.PlannedCheckBox
        {
            get
            {
                if ((this.cachedPlannedCheckBox == null))
                {
                    this.cachedPlannedCheckBox = new CheckBox(this, MaintenanceModeDialog.ControlIDs.PlannedCheckBox);
                }
                return this.cachedPlannedCheckBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlertsStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMaintenanceModeDialogControls.RulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlertsStaticControl
        {
            get
            {
                if ((this.cachedRulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlertsStaticControl == null))
                {
                    this.cachedRulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlertsStaticControl = new StaticControl(this, MaintenanceModeDialog.ControlIDs.RulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlertsStaticControl);
                }
                return this.cachedRulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlertsStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceModeStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMaintenanceModeDialogControls.TheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceModeStaticControl
        {
            get
            {
                if ((this.cachedTheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceModeStaticControl == null))
                {
                    this.cachedTheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceModeStaticControl = new StaticControl(this, MaintenanceModeDialog.ControlIDs.TheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceModeStaticControl);
                }
                return this.cachedTheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceModeStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CommentStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMaintenanceModeDialogControls.CommentStaticControl
        {
            get
            {
                if ((this.cachedCommentStaticControl == null))
                {
                    this.cachedCommentStaticControl = new StaticControl(this, MaintenanceModeDialog.ControlIDs.CommentStaticControl);
                }
                return this.cachedCommentStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMaintenanceModeDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, MaintenanceModeDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IMaintenanceModeDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, MaintenanceModeDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MaintenanceCategoryStaticControl control
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IMaintenanceModeDialogControls.MaintenanceCategoryStaticControl
        {
            get
            {
                if ((this.cachedMaintenanceCategoryStaticControl == null))
                {
                    this.cachedMaintenanceCategoryStaticControl = new StaticControl(this, MaintenanceModeDialog.ControlIDs.MaintenanceCategoryStaticControl);
                }
                return this.cachedMaintenanceCategoryStaticControl;
            }
        }
        #endregion

        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Planned
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPlanned()
        {
            if (this.Controls.PlannedCheckBox.Checked)
            {
                this.Controls.PlannedCheckBox.Checked = false;
            }
            else
            {
                this.Controls.PlannedCheckBox.Checked = true;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
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
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException)
            {
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);

                if (tempWindow != null)
                {
                    return tempWindow;
                }

                throw new Window.Exceptions.WindowNotFoundException("Init function could not find or bring up the dialog with a title of " + Strings.DialogTitle + ".");
            }
            return tempWindow;
        }

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[lucyra] 7/15/2006 Created
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
            private const string ResourceDialogTitle = ";Maintenance Mode;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.MaintenanceModeDialog;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TheSelectedObjectsAndAllTheirContainedObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTheSelectedObjectsAndAllTheirContainedObjects = ";The selected objects and &all their contained objects;ManagedString;Microsoft.MO" +
                "M.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.MaintenanceModeDialog;" +
                "containedObjectRadioButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TheSelectedObjectsOnly
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTheSelectedObjectsOnly = ";The selected objects &only;ManagedString;Microsoft.MOM.UI.Components.dll;Microso" +
                "ft.EnterpriseManagement.Mom.UI.MaintenanceModeDialog;singleObjectRadioButton.Tex" +
                "t";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecificEndTime
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecificEndTime = ";&Specific end time:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ente" +
                "rpriseManagement.Mom.UI.MaintenanceModeDialog;endTimeRadioButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NumberOfMinutes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNumberOfMinutes = ";&Number of minutes:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ente" +
                "rpriseManagement.Mom.UI.MaintenanceModeDialog;minutesRadioButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Planned
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePlanned = ";&Planned;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManag" +
                "ement.Mom.UI.MaintenanceModeDialog;plannedCheckBox.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlerts = ";- Rules and monitors\r\n- Notifications\r\n- Automatic responses\r\n- State changes\r\n-" +
                " New alerts;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.UI.MaintenanceModeDialog;descriptionLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceMode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceMode = ";These features are temporarily suspended for objects in Maintenance Mode:;Manage" +
                "dString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.Ma" +
                "intenanceModeDialog;label1.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Comment
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComment = ";Comment;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.UI.MaintenanceModeDialog;commentLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MaintenanceCategory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMaintenanceCategory = ";&Category;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Mom.UI.MaintenanceModeDialog;reasonLabel.Text";
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
            /// Caches the translated resource string for:  TheSelectedObjectsAndAllTheirContainedObjects
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTheSelectedObjectsAndAllTheirContainedObjects;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TheSelectedObjectsOnly
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTheSelectedObjectsOnly;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecificEndTime
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecificEndTime;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NumberOfMinutes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNumberOfMinutes;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Planned
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPlanned;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlerts;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceMode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceMode;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Comment
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComment;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MaintenanceCategory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMaintenanceCategory;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/15/2006 Created
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
            /// Exposes access to the TheSelectedObjectsAndAllTheirContainedObjects translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/15/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TheSelectedObjectsAndAllTheirContainedObjects
            {
                get
                {
                    if ((cachedTheSelectedObjectsAndAllTheirContainedObjects == null))
                    {
                        cachedTheSelectedObjectsAndAllTheirContainedObjects = CoreManager.MomConsole.GetIntlStr(ResourceTheSelectedObjectsAndAllTheirContainedObjects);
                    }
                    return cachedTheSelectedObjectsAndAllTheirContainedObjects;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TheSelectedObjectsOnly translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/15/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TheSelectedObjectsOnly
            {
                get
                {
                    if ((cachedTheSelectedObjectsOnly == null))
                    {
                        cachedTheSelectedObjectsOnly = CoreManager.MomConsole.GetIntlStr(ResourceTheSelectedObjectsOnly);
                    }
                    return cachedTheSelectedObjectsOnly;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecificEndTime translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/15/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecificEndTime
            {
                get
                {
                    if ((cachedSpecificEndTime == null))
                    {
                        cachedSpecificEndTime = CoreManager.MomConsole.GetIntlStr(ResourceSpecificEndTime);
                    }
                    return cachedSpecificEndTime;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NumberOfMinutes translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/15/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NumberOfMinutes
            {
                get
                {
                    if ((cachedNumberOfMinutes == null))
                    {
                        cachedNumberOfMinutes = CoreManager.MomConsole.GetIntlStr(ResourceNumberOfMinutes);
                    }
                    return cachedNumberOfMinutes;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Planned translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/15/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Planned
            {
                get
                {
                    if ((cachedPlanned == null))
                    {
                        cachedPlanned = CoreManager.MomConsole.GetIntlStr(ResourcePlanned);
                    }
                    return cachedPlanned;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlerts translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/15/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlerts
            {
                get
                {
                    if ((cachedRulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlerts == null))
                    {
                        cachedRulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlerts = CoreManager.MomConsole.GetIntlStr(ResourceRulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlerts);
                    }
                    return cachedRulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlerts;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceMode translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/15/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceMode
            {
                get
                {
                    if ((cachedTheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceMode == null))
                    {
                        cachedTheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceMode = CoreManager.MomConsole.GetIntlStr(ResourceTheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceMode);
                    }
                    return cachedTheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceMode;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Comment translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/15/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Comment
            {
                get
                {
                    if ((cachedComment == null))
                    {
                        cachedComment = CoreManager.MomConsole.GetIntlStr(ResourceComment);
                    }
                    return cachedComment;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/15/2006 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/15/2006 Created
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
            /// Exposes access to the MaintenanceCategory translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 7/15/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceCategory
            {
                get
                {
                    if ((cachedMaintenanceCategory == null))
                    {
                        cachedMaintenanceCategory = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceCategory);
                    }
                    return cachedMaintenanceCategory;
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
        /// 	[lucyra] 7/15/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for TheSelectedObjectsAndAllTheirContainedObjectsRadioButton
            /// </summary>
            public const string TheSelectedObjectsAndAllTheirContainedObjectsRadioButton = "containedObjectRadioButton";

            /// <summary>
            /// Control ID for TheSelectedObjectsOnlyRadioButton
            /// </summary>
            public const string TheSelectedObjectsOnlyRadioButton = "singleObjectRadioButton";

            /// <summary>
            /// Control ID for SpecificEndTimeRadioButton
            /// </summary>
            public const string SpecificEndTimeRadioButton = "endTimeRadioButton";

            /// <summary>
            /// Control ID for NumberOfMinutesRadioButton
            /// </summary>
            public const string NumberOfMinutesRadioButton = "minutesRadioButton";

            /// <summary>
            /// Control ID for TimePickerComboBox
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string TimePickerComboBox = "endTimePicker";

            /// <summary>
            /// Control ID for MinuteSpinnerComboBox
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string MinuteSpinnerComboBox = "minuteSpinner";

            /// <summary>
            /// Control ID for CommentTextBox
            /// </summary>
            public const string CommentTextBox = "commentTextbox";

            /// <summary>
            /// Control ID for MaintenanceCategoryComboBox
            /// </summary>
            public const string MaintenanceCategoryComboBox = "reasonComboBox";

            /// <summary>
            /// Control ID for PlannedCheckBox
            /// </summary>
            public const string PlannedCheckBox = "plannedCheckBox";

            /// <summary>
            /// Control ID for RulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlertsStaticControl
            /// </summary>
            public const string RulesAndMonitorsNotificationsAutomaticResponsesStateChangesNewAlertsStaticControl = "descriptionLabel";

            /// <summary>
            /// Control ID for TheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceModeStaticControl
            /// </summary>
            public const string TheseFeaturesAreTemporarilySuspendedForObjectsInMaintenanceModeStaticControl = "label1";

            /// <summary>
            /// Control ID for CommentStaticControl
            /// </summary>
            public const string CommentStaticControl = "commentLabel";

            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for MaintenanceCategoryStaticControl
            /// </summary>
            public const string MaintenanceCategoryStaticControl = "reasonLabel";
        }
        #endregion
    }
}
