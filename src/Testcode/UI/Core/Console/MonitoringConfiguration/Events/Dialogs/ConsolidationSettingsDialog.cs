// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConsolidationSettingsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[ruhim] 4/20/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Events.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Radio Group Enumeration - RadioGroup0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroup0
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/20/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroup0
    {
        /// <summary>
        /// BasedOnItemsOccurenceWithinATimeInterval = 0
        /// </summary>
        BasedOnItemsOccurenceWithinATimeInterval = 0,
        
        /// <summary>
        /// BasedOnFixedWeeklySchedule = 1
        /// </summary>
        BasedOnFixedWeeklySchedule = 1,
        
        /// <summary>
        /// BasedOnFixedSimpleRecurringSchedule = 2
        /// </summary>
        BasedOnFixedSimpleRecurringSchedule = 2,
    }
    #endregion
    
    #region Interface Definition - IConsolidationSettingsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IConsolidationSettingsDialogControls, for ConsolidationSettingsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/20/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IConsolidationSettingsDialogControls
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
        /// Read-only property to access MonitorTypeStaticControl
        /// </summary>
        StaticControl MonitorTypeStaticControl
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
        /// Read-only property to access EventLogNameStaticControl
        /// </summary>
        StaticControl EventLogNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EventExpressionStaticControl
        /// </summary>
        StaticControl EventExpressionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RepeatSettingsStaticControl
        /// </summary>
        StaticControl RepeatSettingsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureHealthStaticControl
        /// </summary>
        StaticControl ConfigureHealthStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureAlertsStaticControl
        /// </summary>
        StaticControl ConfigureAlertsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PeriodStaticControl
        /// </summary>
        StaticControl PeriodStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BasedOnItemsOccurenceWithinATimeIntervalRadioButton
        /// </summary>
        RadioButton BasedOnItemsOccurenceWithinATimeIntervalRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BasedOnFixedWeeklyScheduleRadioButton
        /// </summary>
        RadioButton BasedOnFixedWeeklyScheduleRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SynchronizeAtDateTimePicker
        /// </summary>
        DateTimePicker SynchronizeAtDateTimePicker
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Spinner3
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Spinner Spinner3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SynchronizeAtCheckBox
        /// </summary>
        CheckBox SynchronizeAtCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IntervalUnitComboBox
        /// </summary>
        ComboBox IntervalUnitComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PeriodComboBox
        /// </summary>
        EditComboBox PeriodComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PeriodUnitComboBox
        /// </summary>
        ComboBox PeriodUnitComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IntervalComboBox
        /// </summary>
        EditComboBox IntervalComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BasedOnFixedSimpleRecurringScheduleRadioButton
        /// </summary>
        RadioButton BasedOnFixedSimpleRecurringScheduleRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConsolidationSettingsStaticControl
        /// </summary>
        StaticControl ConsolidationSettingsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DataGridView1
        /// </summary>
        PropertyGridView DataGridView1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AddRemoveToolStrip
        /// </summary>
        Toolbar AddRemoveToolStrip
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IntervalStaticControl
        /// </summary>
        StaticControl IntervalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CompareCountComboBox
        /// </summary>
        EditComboBox CompareCountComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CompareCountStaticControl
        /// </summary>
        StaticControl CompareCountStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NotSpecifiedUseEditButtonToAddPropertiesStaticControl
        /// </summary>
        StaticControl NotSpecifiedUseEditButtonToAddPropertiesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CountingModeComboBox
        /// </summary>
        ComboBox CountingModeComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EditButton
        /// </summary>
        Button EditButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CountingModeStaticControl
        /// </summary>
        StaticControl CountingModeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PropertiesStaticControl
        /// </summary>
        StaticControl PropertiesStaticControl
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
        /// Read-only property to access ThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEventsStaticControl
        /// </summary>
        StaticControl ThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEventsStaticControl
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
    /// 	[ruhim] 4/20/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ConsolidationSettingsDialog : Dialog, IConsolidationSettingsDialogControls
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
        /// Cache to hold a reference to MonitorTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitorTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EventLogNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEventLogNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EventExpressionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEventExpressionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RepeatSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRepeatSettingsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureHealthStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureHealthStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureAlertsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureAlertsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PeriodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPeriodStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BasedOnItemsOccurenceWithinATimeIntervalRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedBasedOnItemsOccurenceWithinATimeIntervalRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to BasedOnFixedWeeklyScheduleRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedBasedOnFixedWeeklyScheduleRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to SynchronizeAtDateTimePicker of type ComboBox
        /// </summary>
        private DateTimePicker cachedSynchronizeAtDateTimePicker;
        
        /// <summary>
        /// Cache to hold a reference to Spinner3 of type Spinner
        /// </summary>
        private Spinner cachedSpinner3;
        
        /// <summary>
        /// Cache to hold a reference to SynchronizeAtCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedSynchronizeAtCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to IntervalUnitComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedIntervalUnitComboBox;
        
        /// <summary>
        /// Cache to hold a reference to PeriodComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedPeriodComboBox;
        
        /// <summary>
        /// Cache to hold a reference to PeriodUnitComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedPeriodUnitComboBox;
        
        /// <summary>
        /// Cache to hold a reference to IntervalComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedIntervalComboBox;
        
        /// <summary>
        /// Cache to hold a reference to BasedOnFixedSimpleRecurringScheduleRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedBasedOnFixedSimpleRecurringScheduleRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to ConsolidationSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConsolidationSettingsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DataGridView1 of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedDataGridView1;
        
        /// <summary>
        /// Cache to hold a reference to AddRemoveToolStrip of type Toolbar
        /// </summary>
        private Toolbar cachedAddRemoveToolStrip;
        
        /// <summary>
        /// Cache to hold a reference to IntervalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIntervalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CompareCountComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedCompareCountComboBox;
        
        /// <summary>
        /// Cache to hold a reference to CompareCountStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCompareCountStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NotSpecifiedUseEditButtonToAddPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNotSpecifiedUseEditButtonToAddPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CountingModeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedConfigureCorrelationComboBox;
        
        /// <summary>
        /// Cache to hold a reference to EditButton of type Button
        /// </summary>
        private Button cachedEditButton;
        
        /// <summary>
        /// Cache to hold a reference to CountingModeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCountingModeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEventsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEventsStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ConsolidationSettingsDialog of type App
        /// </param>
        /// <param name="windowCaption">Wizard dialog title.</param>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ConsolidationSettingsDialog(Mom.Test.UI.Core.Console.MomConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
            :
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroup0
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroup0 RadioGroup0
        {
            get
            {
                if ((this.Controls.BasedOnItemsOccurenceWithinATimeIntervalRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.BasedOnItemsOccurenceWithinATimeInterval;
                }
                
                if ((this.Controls.BasedOnFixedWeeklyScheduleRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.BasedOnFixedWeeklySchedule;
                }
                
                if ((this.Controls.BasedOnFixedSimpleRecurringScheduleRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.BasedOnFixedSimpleRecurringSchedule;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroup0.BasedOnItemsOccurenceWithinATimeInterval))
                {
                    this.Controls.BasedOnItemsOccurenceWithinATimeIntervalRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup0.BasedOnFixedWeeklySchedule))
                    {
                        this.Controls.BasedOnFixedWeeklyScheduleRadioButton.ButtonState = ButtonState.Checked;
                    }
                    else
                    {
                        if ((value == RadioGroup0.BasedOnFixedSimpleRecurringSchedule))
                        {
                            this.Controls.BasedOnFixedSimpleRecurringScheduleRadioButton.ButtonState = ButtonState.Checked;
                        }
                    }
                }
            }
        }
        #endregion
        
        #region IConsolidationSettingsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IConsolidationSettingsDialogControls Controls
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
        ///  Property to handle checkbox SynchronizeAt
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool SynchronizeAt
        {
            get
            {
                return this.Controls.SynchronizeAtCheckBox.Checked;
            }
            
            set
            {
                this.Controls.SynchronizeAtCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties              
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control IntervalUnitComboBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string IntervalUnitComboBoxText
        {
            get
            {
                return this.Controls.IntervalUnitComboBox.Text;
            }
            
            set
            {
                this.Controls.IntervalUnitComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Period
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PeriodText
        {
            get
            {
                return this.Controls.PeriodComboBox.Text;
            }
            
            set
            {
                this.Controls.PeriodComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control PeriodUnitComboBox
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PeriodUnitComboBoxText
        {
            get
            {
                return this.Controls.PeriodUnitComboBox.Text;
            }
            
            set
            {
                this.Controls.PeriodUnitComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Interval
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string IntervalText
        {
            get
            {
                return this.Controls.IntervalComboBox.Text;
            }
            
            set
            {
                this.Controls.IntervalComboBox.Text = value;
                //this.Controls.IntervalComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control CompareCount
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CompareCountText
        {
            get
            {
                return this.Controls.CompareCountComboBox.Text;
            }
            
            set
            {
                //this.Controls.CompareCountComboBox.SelectByText(value, true);
                this.Controls.CompareCountComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ConfigureCorrelation
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string CountingModeComboBoxText
        {
            get
            {
                return this.Controls.CountingModeComboBox.Text;
            }
            
            set
            {
                this.Controls.CountingModeComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConsolidationSettingsDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, ConsolidationSettingsDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConsolidationSettingsDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ConsolidationSettingsDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConsolidationSettingsDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, ConsolidationSettingsDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConsolidationSettingsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ConsolidationSettingsDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsolidationSettingsDialogControls.MonitorTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitorTypeStaticControl == null))
                {
                    this.cachedMonitorTypeStaticControl = new StaticControl(this, ConsolidationSettingsDialog.ControlIDs.MonitorTypeStaticControl);
                }
                return this.cachedMonitorTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsolidationSettingsDialogControls.GeneralStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGeneralStaticControl == null))
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
                    this.cachedGeneralStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedGeneralStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventLogNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsolidationSettingsDialogControls.EventLogNameStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedEventLogNameStaticControl == null))
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
                    this.cachedEventLogNameStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedEventLogNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EventExpressionStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsolidationSettingsDialogControls.EventExpressionStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedEventExpressionStaticControl == null))
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
                    this.cachedEventExpressionStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedEventExpressionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RepeatSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsolidationSettingsDialogControls.RepeatSettingsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedRepeatSettingsStaticControl == null))
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
                    this.cachedRepeatSettingsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedRepeatSettingsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureHealthStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsolidationSettingsDialogControls.ConfigureHealthStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureHealthStaticControl == null))
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
                    this.cachedConfigureHealthStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedConfigureHealthStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAlertsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsolidationSettingsDialogControls.ConfigureAlertsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureAlertsStaticControl == null))
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
                    for (i = 0; (i <= 5); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedConfigureAlertsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedConfigureAlertsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PeriodStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsolidationSettingsDialogControls.PeriodStaticControl
        {
            get
            {
                if ((this.cachedPeriodStaticControl == null))
                {
                    this.cachedPeriodStaticControl = new StaticControl(this, ConsolidationSettingsDialog.ControlIDs.PeriodStaticControl);
                }
                return this.cachedPeriodStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BasedOnItemsOccurenceWithinATimeIntervalRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IConsolidationSettingsDialogControls.BasedOnItemsOccurenceWithinATimeIntervalRadioButton
        {
            get
            {
                if ((this.cachedBasedOnItemsOccurenceWithinATimeIntervalRadioButton == null))
                {
                    this.cachedBasedOnItemsOccurenceWithinATimeIntervalRadioButton = new RadioButton(this, ConsolidationSettingsDialog.ControlIDs.BasedOnItemsOccurenceWithinATimeIntervalRadioButton);
                }
                return this.cachedBasedOnItemsOccurenceWithinATimeIntervalRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BasedOnFixedWeeklyScheduleRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IConsolidationSettingsDialogControls.BasedOnFixedWeeklyScheduleRadioButton
        {
            get
            {
                if ((this.cachedBasedOnFixedWeeklyScheduleRadioButton == null))
                {
                    this.cachedBasedOnFixedWeeklyScheduleRadioButton = new RadioButton(this, ConsolidationSettingsDialog.ControlIDs.BasedOnFixedWeeklyScheduleRadioButton);
                }
                return this.cachedBasedOnFixedWeeklyScheduleRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SynchronizeAtDateTimePicker control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DateTimePicker IConsolidationSettingsDialogControls.SynchronizeAtDateTimePicker
        {
            get
            {
                if ((this.cachedSynchronizeAtDateTimePicker == null))
                {
                    this.cachedSynchronizeAtDateTimePicker = new DateTimePicker(this, ConsolidationSettingsDialog.ControlIDs.SynchronizeAtDateTimePicker);
                }
                return this.cachedSynchronizeAtDateTimePicker;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Spinner3 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner IConsolidationSettingsDialogControls.Spinner3
        {
            get
            {
                if ((this.cachedSpinner3 == null))
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
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedSpinner3 = new Spinner(wndTemp);
                }
                return this.cachedSpinner3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SynchronizeAtCheckBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IConsolidationSettingsDialogControls.SynchronizeAtCheckBox
        {
            get
            {
                if ((this.cachedSynchronizeAtCheckBox == null))
                {
                    this.cachedSynchronizeAtCheckBox = new CheckBox(this, ConsolidationSettingsDialog.ControlIDs.SynchronizeAtCheckBox);
                }
                return this.cachedSynchronizeAtCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntervalUnitComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IConsolidationSettingsDialogControls.IntervalUnitComboBox
        {
            get
            {
                if ((this.cachedIntervalUnitComboBox == null))
                {
                    //The following call to window the window fails - there are 2 windows with the same name Strings.Interval
                    //Window constructor for some reason cannot find the second Interval window even though they both differ
                    //in the WindowClassName. Also found that trying to print the Window.Caption for the second Interval window
                    //prints blank while the first one has the caption. Hence I find the First Window and then just do next
                    
                    //Window wndTemp = new Window(Strings.Interval, WindowClassNames.WinForms10Window8, this, Constants.DefaultDialogTimeout);
                    //Window wndTemp = this.Extended.AccessibleObject.FindChild(Strings.Interval).Next.Window;

                    //following two lines of code work on x86 but fail on x64
                    //Window wndTemp = new Window(Strings.Interval, WindowClassNames.WinFormsStatic, this, Constants.DefaultDialogTimeout).Extended.AccessibleObject.Next.Window;
                    //this.cachedIntervalUnitComboBox = new ComboBox(wndTemp , ConsolidationSettingsDialog.ControlIDs.IntervalUnitComboBox);

                    ActiveAccessibilityCollection comboCollection = new ActiveAccessibilityCollection();
                    comboCollection = ActiveAccessibility.FindUIElements(this.Extended.AccessibleObject, NavigationFlags.FindAll, Strings.Interval, "*", (int)MsaaRole.Client);

                    this.cachedIntervalUnitComboBox = new ComboBox(comboCollection[0].Window, ConsolidationSettingsDialog.ControlIDs.IntervalUnitComboBox);
                           
                }
                return this.cachedIntervalUnitComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PeriodComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IConsolidationSettingsDialogControls.PeriodComboBox
        {
            get
            {
                if ((this.cachedPeriodComboBox == null))
                {
                    this.cachedPeriodComboBox = new EditComboBox(this, ConsolidationSettingsDialog.ControlIDs.PeriodComboBox);
                }
                return this.cachedPeriodComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PeriodUnitComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IConsolidationSettingsDialogControls.PeriodUnitComboBox
        {
            get
            {
                // The ID for this control (comboBoxUnit) is used multiple times in this dialog.
                if ((this.cachedPeriodUnitComboBox == null))
                {
                    //There are 2 windows with the same name Strings.Period; however the Window.Caption for the 
                    //second Period window that I need is blank. Hence I find the First Window and then just do next
                    
                    //Following 2 lines work fine on x86 but fail on x64 - bug 105194
                    //Window wndTemp = new Window(Strings.Period, WindowClassNames.WinFormsStatic, this, Constants.DefaultDialogTimeout).Extended.AccessibleObject.Next.Window;
                    //this.cachedPeriodUnitComboBox = new ComboBox(wndTemp, ConsolidationSettingsDialog.ControlIDs.PeriodUnitComboBox);

                    ActiveAccessibilityCollection comboCollection = new ActiveAccessibilityCollection();
                    comboCollection = ActiveAccessibility.FindUIElements(this.Extended.AccessibleObject, NavigationFlags.FindAll, Strings.Period, "*", (int)MsaaRole.Client);

                    this.cachedPeriodUnitComboBox = new ComboBox(comboCollection[0].Window, ConsolidationSettingsDialog.ControlIDs.PeriodUnitComboBox);

                }
                return this.cachedPeriodUnitComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntervalComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IConsolidationSettingsDialogControls.IntervalComboBox
        {
            get
            {
                if ((this.cachedIntervalComboBox == null))
                {
                    this.cachedIntervalComboBox = new EditComboBox(this, ConsolidationSettingsDialog.ControlIDs.IntervalComboBox);
                }
                return this.cachedIntervalComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BasedOnFixedSimpleRecurringScheduleRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IConsolidationSettingsDialogControls.BasedOnFixedSimpleRecurringScheduleRadioButton
        {
            get
            {
                if ((this.cachedBasedOnFixedSimpleRecurringScheduleRadioButton == null))
                {
                    this.cachedBasedOnFixedSimpleRecurringScheduleRadioButton = new RadioButton(this, ConsolidationSettingsDialog.ControlIDs.BasedOnFixedSimpleRecurringScheduleRadioButton);
                }
                return this.cachedBasedOnFixedSimpleRecurringScheduleRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConsolidationSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsolidationSettingsDialogControls.ConsolidationSettingsStaticControl
        {
            get
            {
                if ((this.cachedConsolidationSettingsStaticControl == null))
                {
                    this.cachedConsolidationSettingsStaticControl = new StaticControl(this, ConsolidationSettingsDialog.ControlIDs.ConsolidationSettingsStaticControl);
                }
                return this.cachedConsolidationSettingsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataGridView1 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IConsolidationSettingsDialogControls.DataGridView1
        {
            get
            {
                if ((this.cachedDataGridView1 == null))
                {
                    this.cachedDataGridView1 = new PropertyGridView(this, ConsolidationSettingsDialog.ControlIDs.DataGridView1);
                }
                return this.cachedDataGridView1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddRemoveToolStrip control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        ///     [a-joelj]   09OCT09 Maui 2.0 Required Change: Calling the Toolbar constructor with a QID.
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IConsolidationSettingsDialogControls.AddRemoveToolStrip
        {
            get
            {
                if ((this.cachedAddRemoveToolStrip == null))
                {
                    // [a-joelj] - Maui 2.0 Required Change: Calling the Toolbar constructor with 'this' being the only parameter 
                    // is returning the wrong toolbar. There is no caption/name defined for these toolbars therefore we cannot call the 
                    // constructor with the caption/name. Switching over to the UIA tree and using a QID with the AutomationId.

                    QID queryId = new QID(";[UIA]AutomationId=\'" + ConsolidationSettingsDialog.ControlIDs.AddRemoveToolStrip + "\' && Role='tool bar'");

                    // Try 20 times to find the tool bar widnow
                    Window toolbarWindow = CoreManager.MomConsole.Waiters.WaitForWindowAppeared(this, queryId, Constants.OneMinute);
                    if (toolbarWindow != null)
                    {
                        this.cachedAddRemoveToolStrip = new Toolbar(toolbarWindow);
                    }
                    else
                    {
                        throw new Maui.Core.WinControls.Toolbar.Exceptions.ToolbarItemNotFoundException("Could not find Toolbar");
                    }
                    
                }
                return this.cachedAddRemoveToolStrip;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntervalStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsolidationSettingsDialogControls.IntervalStaticControl
        {
            get
            {
                if ((this.cachedIntervalStaticControl == null))
                {
                    this.cachedIntervalStaticControl = new StaticControl(this, ConsolidationSettingsDialog.ControlIDs.IntervalStaticControl);
                }
                return this.cachedIntervalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CompareCountComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IConsolidationSettingsDialogControls.CompareCountComboBox
        {
            get
            {
                if ((this.cachedCompareCountComboBox == null))
                {
                    this.cachedCompareCountComboBox = new EditComboBox(this, ConsolidationSettingsDialog.ControlIDs.CompareCountComboBox);
                }
                return this.cachedCompareCountComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CompareCountStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsolidationSettingsDialogControls.CompareCountStaticControl
        {
            get
            {
                if ((this.cachedCompareCountStaticControl == null))
                {
                    this.cachedCompareCountStaticControl = new StaticControl(this, ConsolidationSettingsDialog.ControlIDs.CompareCountStaticControl);
                }
                return this.cachedCompareCountStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NotSpecifiedUseEditButtonToAddPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsolidationSettingsDialogControls.NotSpecifiedUseEditButtonToAddPropertiesStaticControl
        {
            get
            {
                if ((this.cachedNotSpecifiedUseEditButtonToAddPropertiesStaticControl == null))
                {
                    this.cachedNotSpecifiedUseEditButtonToAddPropertiesStaticControl = new StaticControl(this, ConsolidationSettingsDialog.ControlIDs.NotSpecifiedUseEditButtonToAddPropertiesStaticControl);
                }
                return this.cachedNotSpecifiedUseEditButtonToAddPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CountingModeComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IConsolidationSettingsDialogControls.CountingModeComboBox
        {
            get
            {
                if ((this.cachedConfigureCorrelationComboBox == null))
                {
                    this.cachedConfigureCorrelationComboBox = new ComboBox(this, ConsolidationSettingsDialog.ControlIDs.CountingModeComboBox);
                }
                return this.cachedConfigureCorrelationComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EditButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConsolidationSettingsDialogControls.EditButton
        {
            get
            {
                if ((this.cachedEditButton == null))
                {
                    this.cachedEditButton = new Button(this, ConsolidationSettingsDialog.ControlIDs.EditButton);
                }
                return this.cachedEditButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CountingModeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsolidationSettingsDialogControls.CountingModeStaticControl
        {
            get
            {
                if ((this.cachedCountingModeStaticControl == null))
                {
                    this.cachedCountingModeStaticControl = new StaticControl(this, ConsolidationSettingsDialog.ControlIDs.CountingModeStaticControl);
                }
                return this.cachedCountingModeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsolidationSettingsDialogControls.PropertiesStaticControl
        {
            get
            {
                if ((this.cachedPropertiesStaticControl == null))
                {
                    this.cachedPropertiesStaticControl = new StaticControl(this, ConsolidationSettingsDialog.ControlIDs.PropertiesStaticControl);
                }
                return this.cachedPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsolidationSettingsDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, ConsolidationSettingsDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEventsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConsolidationSettingsDialogControls.ThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEventsStaticControl
        {
            get
            {
                if ((this.cachedThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEventsStaticControl == null))
                {
                    this.cachedThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEventsStaticControl = new StaticControl(this, ConsolidationSettingsDialog.ControlIDs.ThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEventsStaticControl);
                }
                return this.cachedThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEventsStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
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
        /// 	[ruhim] 4/20/2007 Created
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
        /// 	[ruhim] 4/20/2007 Created
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
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SynchronizeAt
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSynchronizeAt()
        {
            this.Controls.SynchronizeAtCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Edit
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEdit()
        {
            this.Controls.EditButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>
        /// <param name="windowCaption">Wizard dialog title.</param>
        /// <history>
        /// 	[ruhim] 4/20/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
        {
            string DialogTitle = MonitoringConfiguration.GetWindowCaption(windowCaption);
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                                DialogTitle + "*", StringMatchSyntax.WildCard);

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
                        "Failed to find window with title:  '" + DialogTitle + "'");

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
        /// 	[ruhim] 4/20/2007 Created
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
            private const string ResourceDialogTitle = "Create a unit monitor";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;previousButt" +
                "on.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Mic" +
                "rosoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;nextButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";C&reate;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CreateMP" +
                "Action";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitorType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitorType = ";Monitor Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseMonitorTypePage;$thi" +
                "s.TabName";
            
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
            /// Contains resource string for:  EventLogName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventLogName = ";Event Log Name;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.EvtLogDataSource;$this.H" +
                "eaderText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EventExpression
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceEventExpression = "Event Expression";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RepeatSettings
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceRepeatSettings = "Repeat Settings";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureHealth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureHealth = ";Configure Health;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.OperationalStatesMappi" +
                "ngPage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureAlerts = ";Configure Alerts;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;$th" +
                "is.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Period
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePeriod = ";Peri&od:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.ConsolidatorConditionPage;labe" +
                "lPeriod.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BasedOnItemsOccurenceWithinATimeInterval
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBasedOnItemsOccurenceWithinATimeInterval = ";Based on items occurence &within a time interval.;ManagedString;Microsoft.Enterp" +
                "riseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Autho" +
                "ring.Pages.ConsolidatorConditionPage;radioButtonWithinTime.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BasedOnFixedWeeklySchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBasedOnFixedWeeklySchedule = ";Based on &fixed weekly schedule.;ManagedString;Microsoft.EnterpriseManagement.UI" +
                ".Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Consol" +
                "idatorConditionPage;radioButtonWeeklySchedule.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SynchronizeAt
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSynchronizeAt = ";S&ynchronize at:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SimpleRecurringControl" +
                ";checkBoxSync.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BasedOnFixedSimpleRecurringSchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBasedOnFixedSimpleRecurringSchedule = ";Based on fixed &simple recurring schedule.;ManagedString;Microsoft.EnterpriseMan" +
                "agement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pa" +
                "ges.ConsolidatorConditionPage;radioButtonSimpleReccurence.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConsolidationSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConsolidationSettings = ";Consolidation Settings;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring" +
                ".dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConsolidatorCond" +
                "itionPage;pageSectionLabelConsolidationSettings.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DataGridView1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDataGridView1 = ";dataGridView1;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micr" +
                "osoft.EnterpriseManagement.Internal.UI.Authoring.Pages.OperationalStatesMappingP" +
                "age;statesGridView.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Interval
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceInterval = ";&Interval:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConsolidatorConditionPage;la" +
                "belInterval.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CompareCount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCompareCount = ";Compare &Count:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mi" +
                "crosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConsolidatorConditionPa" +
                "ge;labelCompareCount.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NotSpecifiedUseEditButtonToAddProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotSpecifiedUseEditButtonToAddProperties = ";Not specified. Use Edit button to add properties.;ManagedString;Microsoft.Enterp" +
                "riseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Autho" +
                "ring.Pages.ConsolidatorCondition.ConsolidatorResource;ConsolidationPropertiesHas" +
                "NoData";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Edit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEdit = ";E&dit...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.RuleDetailsPage;editButton.Tex" +
                "t";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CountingMode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCountingMode = ";Counting &Mode:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mi" +
                "crosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConsolidatorConditionPa" +
                "ge;labelCountingMode.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Properties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProperties = ";Properties:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConsolidatorConditionPage;l" +
                "abelConsolidatorPropertiesStatus.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;HelpSubFold" +
                "erName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEvents
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEvents = "This page will guide you through the event detection configuration for repeated e" +
                "vents.";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Trigger on count
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTriggeronCount = 
                ";Trigger on count;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConsolidatorCondition.ConsolidatorResource;CountingModeOnNewItemTestOutputRestartOnTimerRestart";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Trigger on timer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTriggeronTimer =
                ";Trigger on timer;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConsolidatorCondition.ConsolidatorResource;CountingModeOnNewItemNOPOnTimerOutputRestart";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Trigger on count, sliding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTriggeronCountSliding =
                ";Trigger on count, sliding;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ConsolidatorCondition.ConsolidatorResource;CountingModeOnNewItemTestOutputRestartOnTimerSlideByOne";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Days Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDaysTimerUnit =
                ";Days;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Scheduler.SchedulerResources;TimeUnitDays";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Hours Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHoursTimerUnit =
                ";Hours;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Scheduler.SchedulerResources;TimeUnitHours";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Minutes Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMinutesTimerUnit =
                ";Minutes;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Scheduler.SchedulerResources;TimeUnitMinutes";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Seconds Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSecondsTimerUnit =
                ";Seconds;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Scheduler.SchedulerResources;TimeUnitSeconds";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tool Strip Button Add
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddToolStripButton =
                ";&Add...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WeeklyScheduleControl;toolStripButtonAdd.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tool Strip Button Edit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEditToolStripButton =
                ";&Edit...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WeeklyScheduleControl;toolStripButtonEdit.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tool Strip Button Remove
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRemoveToolStripButton =
                ";&Remove;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WeeklyScheduleControl;toolStripButtonRemove.Text";

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
            /// Caches the translated resource string for:  MonitorType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EventLogName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventLogName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EventExpression
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventExpression;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RepeatSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRepeatSettings;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureHealth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureHealth;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureAlerts;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Period
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPeriod;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BasedOnItemsOccurenceWithinATimeInterval
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBasedOnItemsOccurenceWithinATimeInterval;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BasedOnFixedWeeklySchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBasedOnFixedWeeklySchedule;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SynchronizeAt
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSynchronizeAt;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BasedOnFixedSimpleRecurringSchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBasedOnFixedSimpleRecurringSchedule;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConsolidationSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConsolidationSettings;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DataGridView1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDataGridView1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Interval
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInterval;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CompareCount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCompareCount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NotSpecifiedUseEditButtonToAddProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNotSpecifiedUseEditButtonToAddProperties;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Edit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEdit;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CountingMode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCountingMode;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Properties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProperties;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEvents
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEvents;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Trigger on count
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTriggeronCount;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Trigger on timer
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTriggeronTimer;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Trigger on count, sliding
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTriggeronCountSliding;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Days Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDaysTimerUnit;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Hours Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHoursTimerUnit;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Minutes Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMinutesTimerUnit;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Seconds Timer Unit
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSecondsTimerUnit;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add ToolStrip Button
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAddToolStripButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Edit ToolStrip Button
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEditToolStripButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Remove ToolStrip Button
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRemoveToolStripButton;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
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
            /// 	[ruhim] 4/20/2007 Created
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
            /// 	[ruhim] 4/20/2007 Created
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
            /// 	[ruhim] 4/20/2007 Created
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
            /// 	[ruhim] 4/20/2007 Created
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
            /// Exposes access to the MonitorType translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorType
            {
                get
                {
                    if ((cachedMonitorType == null))
                    {
                        cachedMonitorType = CoreManager.MomConsole.GetIntlStr(ResourceMonitorType);
                    }
                    return cachedMonitorType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
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
            /// Exposes access to the EventLogName translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventLogName
            {
                get
                {
                    if ((cachedEventLogName == null))
                    {
                        cachedEventLogName = CoreManager.MomConsole.GetIntlStr(ResourceEventLogName);
                    }
                    return cachedEventLogName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EventExpression translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventExpression
            {
                get
                {
                    if ((cachedEventExpression == null))
                    {
                        cachedEventExpression = CoreManager.MomConsole.GetIntlStr(ResourceEventExpression);
                    }
                    return cachedEventExpression;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RepeatSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RepeatSettings
            {
                get
                {
                    if ((cachedRepeatSettings == null))
                    {
                        cachedRepeatSettings = CoreManager.MomConsole.GetIntlStr(ResourceRepeatSettings);
                    }
                    return cachedRepeatSettings;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureHealth translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureHealth
            {
                get
                {
                    if ((cachedConfigureHealth == null))
                    {
                        cachedConfigureHealth = CoreManager.MomConsole.GetIntlStr(ResourceConfigureHealth);
                    }
                    return cachedConfigureHealth;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureAlerts translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureAlerts
            {
                get
                {
                    if ((cachedConfigureAlerts == null))
                    {
                        cachedConfigureAlerts = CoreManager.MomConsole.GetIntlStr(ResourceConfigureAlerts);
                    }
                    return cachedConfigureAlerts;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Period translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Period
            {
                get
                {
                    if ((cachedPeriod == null))
                    {
                        cachedPeriod = CoreManager.MomConsole.GetIntlStr(ResourcePeriod);
                    }
                    return cachedPeriod;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BasedOnItemsOccurenceWithinATimeInterval translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BasedOnItemsOccurenceWithinATimeInterval
            {
                get
                {
                    if ((cachedBasedOnItemsOccurenceWithinATimeInterval == null))
                    {
                        cachedBasedOnItemsOccurenceWithinATimeInterval = CoreManager.MomConsole.GetIntlStr(ResourceBasedOnItemsOccurenceWithinATimeInterval);
                    }
                    return cachedBasedOnItemsOccurenceWithinATimeInterval;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BasedOnFixedWeeklySchedule translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BasedOnFixedWeeklySchedule
            {
                get
                {
                    if ((cachedBasedOnFixedWeeklySchedule == null))
                    {
                        cachedBasedOnFixedWeeklySchedule = CoreManager.MomConsole.GetIntlStr(ResourceBasedOnFixedWeeklySchedule);
                    }
                    return cachedBasedOnFixedWeeklySchedule;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SynchronizeAt translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SynchronizeAt
            {
                get
                {
                    if ((cachedSynchronizeAt == null))
                    {
                        cachedSynchronizeAt = CoreManager.MomConsole.GetIntlStr(ResourceSynchronizeAt);
                    }
                    return cachedSynchronizeAt;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BasedOnFixedSimpleRecurringSchedule translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BasedOnFixedSimpleRecurringSchedule
            {
                get
                {
                    if ((cachedBasedOnFixedSimpleRecurringSchedule == null))
                    {
                        cachedBasedOnFixedSimpleRecurringSchedule = CoreManager.MomConsole.GetIntlStr(ResourceBasedOnFixedSimpleRecurringSchedule);
                    }
                    return cachedBasedOnFixedSimpleRecurringSchedule;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConsolidationSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConsolidationSettings
            {
                get
                {
                    if ((cachedConsolidationSettings == null))
                    {
                        cachedConsolidationSettings = CoreManager.MomConsole.GetIntlStr(ResourceConsolidationSettings);
                    }
                    return cachedConsolidationSettings;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DataGridView1 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DataGridView1
            {
                get
                {
                    if ((cachedDataGridView1 == null))
                    {
                        cachedDataGridView1 = CoreManager.MomConsole.GetIntlStr(ResourceDataGridView1);
                    }
                    return cachedDataGridView1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Interval translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Interval
            {
                get
                {
                    if ((cachedInterval == null))
                    {
                        cachedInterval = CoreManager.MomConsole.GetIntlStr(ResourceInterval);
                    }
                    return cachedInterval;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CompareCount translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CompareCount
            {
                get
                {
                    if ((cachedCompareCount == null))
                    {
                        cachedCompareCount = CoreManager.MomConsole.GetIntlStr(ResourceCompareCount);
                    }
                    return cachedCompareCount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotSpecifiedUseEditButtonToAddProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotSpecifiedUseEditButtonToAddProperties
            {
                get
                {
                    if ((cachedNotSpecifiedUseEditButtonToAddProperties == null))
                    {
                        cachedNotSpecifiedUseEditButtonToAddProperties = CoreManager.MomConsole.GetIntlStr(ResourceNotSpecifiedUseEditButtonToAddProperties);
                    }
                    return cachedNotSpecifiedUseEditButtonToAddProperties;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Edit translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Edit
            {
                get
                {
                    if ((cachedEdit == null))
                    {
                        cachedEdit = CoreManager.MomConsole.GetIntlStr(ResourceEdit);
                    }
                    return cachedEdit;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CountingMode translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CountingMode
            {
                get
                {
                    if ((cachedCountingMode == null))
                    {
                        cachedCountingMode = CoreManager.MomConsole.GetIntlStr(ResourceCountingMode);
                    }
                    return cachedCountingMode;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Properties translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Properties
            {
                get
                {
                    if ((cachedProperties == null))
                    {
                        cachedProperties = CoreManager.MomConsole.GetIntlStr(ResourceProperties);
                    }
                    return cachedProperties;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
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
            /// Exposes access to the ThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEvents translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEvents
            {
                get
                {
                    if ((cachedThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEvents == null))
                    {
                        cachedThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEvents = CoreManager.MomConsole.GetIntlStr(ResourceThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEvents);
                    }
                    return cachedThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEvents;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Trigger on count translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TriggeronCount
            {
                get
                {
                    if ((cachedTriggeronCount == null))
                    {
                        cachedTriggeronCount = CoreManager.MomConsole.GetIntlStr(ResourceTriggeronCount);
                    }
                    return cachedTriggeronCount;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Trigger on timer translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TriggeronTimer
            {
                get
                {
                    if ((cachedTriggeronTimer == null))
                    {
                        cachedTriggeronTimer = CoreManager.MomConsole.GetIntlStr(ResourceTriggeronTimer);
                    }
                    return cachedTriggeronTimer;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Trigger on count, Sliding translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/20/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TriggeronCountSliding
            {
                get
                {
                    if ((cachedTriggeronCountSliding == null))
                    {
                        cachedTriggeronCountSliding = CoreManager.MomConsole.GetIntlStr(ResourceTriggeronCountSliding);
                    }
                    return cachedTriggeronCountSliding;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Days translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DaysTimerUnit
            {
                get
                {
                    if ((cachedDaysTimerUnit == null))
                    {
                        cachedDaysTimerUnit = CoreManager.MomConsole.GetIntlStr(ResourceDaysTimerUnit);
                    }
                    return cachedDaysTimerUnit;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Hours translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HoursTimerUnit
            {
                get
                {
                    if ((cachedHoursTimerUnit == null))
                    {
                        cachedHoursTimerUnit = CoreManager.MomConsole.GetIntlStr(ResourceHoursTimerUnit);
                    }
                    return cachedHoursTimerUnit;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Minutes translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MinutesTimerUnit
            {
                get
                {
                    if ((cachedMinutesTimerUnit == null))
                    {
                        cachedMinutesTimerUnit = CoreManager.MomConsole.GetIntlStr(ResourceMinutesTimerUnit);
                    }
                    return cachedMinutesTimerUnit;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Seconds translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SecondsTimerUnit
            {
                get
                {
                    if ((cachedSecondsTimerUnit == null))
                    {
                        cachedSecondsTimerUnit = CoreManager.MomConsole.GetIntlStr(ResourceSecondsTimerUnit);
                    }
                    return cachedSecondsTimerUnit;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add ToolStrip Button translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddToolStripButton
            {
                get
                {
                    if ((cachedAddToolStripButton == null))
                    {
                        cachedAddToolStripButton = CoreManager.MomConsole.GetIntlStr(ResourceAddToolStripButton);
                    }
                    return cachedAddToolStripButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Edit ToolStrip Button translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EditToolStripButton
            {
                get
                {
                    if ((cachedEditToolStripButton == null))
                    {
                        cachedEditToolStripButton = CoreManager.MomConsole.GetIntlStr(ResourceEditToolStripButton);
                    }
                    return cachedEditToolStripButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Remove ToolStrip Button translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 18April07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RemoveToolStripButton
            {
                get
                {
                    if ((cachedRemoveToolStripButton == null))
                    {
                        cachedRemoveToolStripButton = CoreManager.MomConsole.GetIntlStr(ResourceRemoveToolStripButton);
                    }
                    return cachedRemoveToolStripButton;
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
        /// 	[ruhim] 4/20/2007 Created
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
            /// Control ID for MonitorTypeStaticControl
            /// </summary>
            public const string MonitorTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for EventLogNameStaticControl
            /// </summary>
            public const string EventLogNameStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for EventExpressionStaticControl
            /// </summary>
            public const string EventExpressionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for RepeatSettingsStaticControl
            /// </summary>
            public const string RepeatSettingsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureHealthStaticControl
            /// </summary>
            public const string ConfigureHealthStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureAlertsStaticControl
            /// </summary>
            public const string ConfigureAlertsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for PeriodStaticControl
            /// </summary>
            public const string PeriodStaticControl = "labelPeriod";
            
            /// <summary>
            /// Control ID for BasedOnItemsOccurenceWithinATimeIntervalRadioButton
            /// </summary>
            public const string BasedOnItemsOccurenceWithinATimeIntervalRadioButton = "radioButtonWithinTime";
            
            /// <summary>
            /// Control ID for BasedOnFixedWeeklyScheduleRadioButton
            /// </summary>
            public const string BasedOnFixedWeeklyScheduleRadioButton = "radioButtonWeeklySchedule";
            
            /// <summary>
            /// Control ID for SynchronizeAtDateTimePicker
            /// </summary>
            public const string SynchronizeAtDateTimePicker = "dateTimePickerHour";
            
            /// <summary>
            /// Control ID for SynchronizeAtCheckBox
            /// </summary>
            public const string SynchronizeAtCheckBox = "checkBoxSync";
            
            /// <summary>
            /// Control ID for IntervalUnitComboBox
            /// </summary>
            public const string IntervalUnitComboBox = "comboBoxUnit";
            
            /// <summary>
            /// Control ID for PeriodComboBox
            /// </summary>
            public const string PeriodComboBox = "numericUpDownInterval";
            
            /// <summary>
            /// Control ID for PeriodUnitComboBox
            /// </summary>
            public const string PeriodUnitComboBox = "comboBoxUnit";
            
            /// <summary>
            /// Control ID for IntervalComboBox
            /// </summary>
            public const string IntervalComboBox = "numericDropDown";
            
            /// <summary>
            /// Control ID for BasedOnFixedSimpleRecurringScheduleRadioButton
            /// </summary>
            public const string BasedOnFixedSimpleRecurringScheduleRadioButton = "radioButtonSimpleReccurence";
            
            /// <summary>
            /// Control ID for ConsolidationSettingsStaticControl
            /// </summary>
            public const string ConsolidationSettingsStaticControl = "pageSectionLabelConsolidationSettings";
            
            /// <summary>
            /// Control ID for DataGridView1
            /// </summary>
            public const string DataGridView1 = "dataGridView";
            
            /// <summary>
            /// Control ID for AddRemoveToolStrip
            /// </summary>
            public const string AddRemoveToolStrip = "toolStripBar";

            /// <summary>
            /// Control ID for IntermediateElementpagePanel
            /// </summary>
            public const string IntermediateElementPagePanel = "pagePanel";

            /// <summary>
            /// Control ID for IntermediateElementWeeklySchedule
            /// </summary>
            public const string IntermediateElementWeeklySchedule = "weeklySchedule";           

            
            /// <summary>
            /// Control ID for IntervalStaticControl
            /// </summary>
            public const string IntervalStaticControl = "labelInterval";
            
            /// <summary>
            /// Control ID for CompareCountComboBox
            /// </summary>
            public const string CompareCountComboBox = "numericUpDownCompareCount";
            
            /// <summary>
            /// Control ID for CompareCountStaticControl
            /// </summary>
            public const string CompareCountStaticControl = "labelCompareCount";
            
            /// <summary>
            /// Control ID for NotSpecifiedUseEditButtonToAddPropertiesStaticControl
            /// </summary>
            public const string NotSpecifiedUseEditButtonToAddPropertiesStaticControl = "labelConsolidatorProperties";
            
            /// <summary>
            /// Control ID for CountingModeComboBox
            /// </summary>
            public const string CountingModeComboBox = "comboBoxCountingMode";
            
            /// <summary>
            /// Control ID for EditButton
            /// </summary>
            public const string EditButton = "buttonConsolidatorProperties";
            
            /// <summary>
            /// Control ID for CountingModeStaticControl
            /// </summary>
            public const string CountingModeStaticControl = "labelCountingMode";
            
            /// <summary>
            /// Control ID for PropertiesStaticControl
            /// </summary>
            public const string PropertiesStaticControl = "labelConsolidatorPropertiesStatus";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEventsStaticControl
            /// </summary>
            public const string ThisPageWillGuideYouThroughTheEventDetectionConfigurationForRepeatedEventsStaticControl = "headerLabel";
        }
        #endregion
    }
}
