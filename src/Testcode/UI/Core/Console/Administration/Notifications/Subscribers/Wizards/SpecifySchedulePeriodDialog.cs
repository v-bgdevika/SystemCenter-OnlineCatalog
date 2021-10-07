// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SpecifySchedulePeriodDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor]  25-AUG-08   Created
//  [KellyMor]  29-SEP-08   Updated radio group enumerations.
//                          Converted StartTime and EndTime from ComboBox to
//                          DateTimePicker controls
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscribers.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - WeeklyOccurenceOptions

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group WeeklyOccurenceOptions
    /// </summary>
    /// <history>
    /// 	[KellyMor] 25-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum WeeklyOccurenceOptions
    {
        /// <summary>
        /// AllDay24Hours = 0
        /// </summary>
        AllDay24Hours = 0,
        
        /// <summary>
        /// WithinTimeRange = 1
        /// </summary>
        WithinTimeRange = 1,

        /// <summary>
        /// Exclude = 2
        /// </summary>
        Exclude = 2,
    }
    #endregion
    
    #region Radio Group Enumeration - DateRangeOptions

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group DateRangeOptions
    /// </summary>
    /// <history>
    /// 	[KellyMor] 25-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum DateRangeOptions
    {
        /// <summary>
        /// Always = 0
        /// </summary>
        Always = 0,
        
        /// <summary>
        /// WithinDateRange = 1
        /// </summary>
        WithinDateRange = 1,
    }
    #endregion
    
    #region Interface Definition - ISpecifySchedulePeriodDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISpecifySchedulePeriodDialogControls, for SpecifySchedulePeriodDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 25-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISpecifySchedulePeriodDialogControls
    {
        /// <summary>
        /// Read-only property to access TimeZoneComboBox
        /// </summary>
        ComboBox TimeZoneComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TimeZoneStaticControl
        /// </summary>
        StaticControl TimeZoneStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StartTimeTimePicker
        /// </summary>
        DateTimePicker StartTimeTimePicker
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TimeZoneSpinner
        /// </summary>
        Spinner TimeZoneSpinner
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AllDay24HoursRadioButton
        /// </summary>
        RadioButton AllDay24HoursRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TimeRangeRadioButton
        /// </summary>
        RadioButton TimeRangeRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ExcludeTimeRangeRadioButton
        /// </summary>
        RadioButton ExcludeTimeRangeRadioButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ExcludeStartTimeTimePicker
        /// </summary>
        DateTimePicker ExcludeStartTimeTimePicker
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ExcludeEndTimeTimePicker
        /// </summary>
        DateTimePicker ExcludeEndTimeTimePicker
        {
            get;
        }

        /// <summary>
        /// Read-only property to access EndTimeStaticControl
        /// </summary>
        StaticControl EndTimeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EndTimeTimePicker
        /// </summary>
        DateTimePicker EndTimeTimePicker
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TimeZoneSpinner2
        /// </summary>
        Spinner TimeZoneSpinner2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlwaysRadioButton
        /// </summary>
        RadioButton AlwaysRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DateRangeRadioButton
        /// </summary>
        RadioButton DateRangeRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StartDateDatePicker
        /// </summary>
        DateTimePicker StartDateDatePicker
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EndDateDatePicker
        /// </summary>
        DateTimePicker EndDateDatePicker
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EndDateStaticControl
        /// </summary>
        StaticControl EndDateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FridayCheckBox
        /// </summary>
        CheckBox FridayCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SaturdayCheckBox
        /// </summary>
        CheckBox SaturdayCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ThursdayCheckBox
        /// </summary>
        CheckBox ThursdayCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WednesdayCheckBox
        /// </summary>
        CheckBox WednesdayCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TuesdayCheckBox
        /// </summary>
        CheckBox TuesdayCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MondayCheckBox
        /// </summary>
        CheckBox MondayCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SundayCheckBox
        /// </summary>
        CheckBox SundayCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ForTheseTimesStaticControl
        /// </summary>
        StaticControl ForTheseTimesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WeeklyRecurrenceStaticControl
        /// </summary>
        StaticControl WeeklyRecurrenceStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DaysOfTheWeekStaticControl
        /// </summary>
        StaticControl DaysOfTheWeekStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DateRangeStaticControl
        /// </summary>
        StaticControl DateRangeStaticControl
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
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the schedule dialog for subscriber
    /// notifications.
    /// </summary>
    /// <history>
    /// 	[KellyMor]  25-AUG-08   Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SpecifySchedulePeriodDialog : Dialog, ISpecifySchedulePeriodDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to TimeZoneComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedTimeZoneComboBox;
        
        /// <summary>
        /// Cache to hold a reference to TimeZoneStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTimeZoneStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StartTimeTimePicker of type DateTimePicker
        /// </summary>
        private DateTimePicker cachedStartTimeTimePicker;
        
        /// <summary>
        /// Cache to hold a reference to TimeZoneSpinner of type Spinner
        /// </summary>
        private Spinner cachedTimeZoneSpinner;
        
        /// <summary>
        /// Cache to hold a reference to AllDay24HoursRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAllDay24HoursRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to TimeRangeRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedTimeRangeRadioButton;

        /// <summary>
        /// Cache to hold a reference to ExcludeTimeRangeRadioButton of type
        /// RadioButton.
        /// </summary>
        private RadioButton cachedExcludeTimeRangeRadioButton;

        /// <summary>
        /// Cache to hold a reference to ExcludeStartTimeTimePicker of type ComboBox
        /// </summary>
        private DateTimePicker cachedExcludeStartTimeTimePicker;

        /// <summary>
        /// Cache to hold a reference to ExcludeEndTimeTimePicker of type ComboBox
        /// </summary>
        private DateTimePicker cachedExcludeEndTimeTimePicker;

        /// <summary>
        /// Cache to hold a reference to EndTimeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEndTimeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EndTimeTimePicker of type DateTimePicker
        /// </summary>
        private DateTimePicker cachedEndTimeTimePicker;
        
        /// <summary>
        /// Cache to hold a reference to TimeZoneSpinner2 of type Spinner
        /// </summary>
        private Spinner cachedTimeZoneSpinner2;
        
        /// <summary>
        /// Cache to hold a reference to AlwaysRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAlwaysRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to DateRangeRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedDateRangeRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to StartDateDatePicker of type ComboBox
        /// </summary>
        private DateTimePicker cachedStartDateDatePicker;
        
        /// <summary>
        /// Cache to hold a reference to EndDateDatePicker of type ComboBox
        /// </summary>
        private DateTimePicker cachedEndDateDatePicker;
        
        /// <summary>
        /// Cache to hold a reference to EndDateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEndDateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FridayCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedFridayCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to SaturdayCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedSaturdayCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ThursdayCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedThursdayCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to WednesdayCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedWednesdayCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to TuesdayCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedTuesdayCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to MondayCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedMondayCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to SundayCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedSundayCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ForTheseTimesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedForTheseTimesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WeeklyRecurrenceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWeeklyRecurrenceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DaysOfTheWeekStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDaysOfTheWeekStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DateRangeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDateRangeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SpecifySchedulePeriodDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SpecifySchedulePeriodDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group WeeklyOccurenceOptions
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual WeeklyOccurenceOptions WeeklyOccurenceOption
        {
            get
            {
                if ((this.Controls.AllDay24HoursRadioButton.ButtonState == ButtonState.Checked))
                {
                    return WeeklyOccurenceOptions.AllDay24Hours;
                }
                
                if ((this.Controls.TimeRangeRadioButton.ButtonState == ButtonState.Checked))
                {
                    return WeeklyOccurenceOptions.WithinTimeRange;
                }

                if ((this.Controls.ExcludeTimeRangeRadioButton.ButtonState == ButtonState.Checked))
                {
                    return WeeklyOccurenceOptions.Exclude;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == WeeklyOccurenceOptions.AllDay24Hours))
                {
                    this.Controls.AllDay24HoursRadioButton.ButtonState = ButtonState.Checked;
                }
                
                if ((value == WeeklyOccurenceOptions.WithinTimeRange))
                {
                    this.Controls.TimeRangeRadioButton.ButtonState = ButtonState.Checked;
                }
                
                if ((value == WeeklyOccurenceOptions.Exclude))
                {
                    this.Controls.ExcludeTimeRangeRadioButton.ButtonState = ButtonState.Checked;
                }
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group DateRangeOptions
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual DateRangeOptions DateRangeOption
        {
            get
            {
                if ((this.Controls.AlwaysRadioButton.ButtonState == ButtonState.Checked))
                {
                    return DateRangeOptions.Always;
                }
                
                if ((this.Controls.DateRangeRadioButton.ButtonState == ButtonState.Checked))
                {
                    return DateRangeOptions.WithinDateRange;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == DateRangeOptions.Always))
                {
                    this.Controls.AlwaysRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == DateRangeOptions.WithinDateRange))
                    {
                        this.Controls.DateRangeRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }

        #endregion
        
        #region ISpecifySchedulePeriodDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISpecifySchedulePeriodDialogControls Controls
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
        ///  Property to handle checkbox Friday
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Friday
        {
            get
            {
                return this.Controls.FridayCheckBox.Checked;
            }
            
            set
            {
                this.Controls.FridayCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox Saturday
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Saturday
        {
            get
            {
                return this.Controls.SaturdayCheckBox.Checked;
            }
            
            set
            {
                this.Controls.SaturdayCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox Thursday
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Thursday
        {
            get
            {
                return this.Controls.ThursdayCheckBox.Checked;
            }
            
            set
            {
                this.Controls.ThursdayCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox Wednesday
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Wednesday
        {
            get
            {
                return this.Controls.WednesdayCheckBox.Checked;
            }
            
            set
            {
                this.Controls.WednesdayCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox Tuesday
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Tuesday
        {
            get
            {
                return this.Controls.TuesdayCheckBox.Checked;
            }
            
            set
            {
                this.Controls.TuesdayCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox Monday
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Monday
        {
            get
            {
                return this.Controls.MondayCheckBox.Checked;
            }
            
            set
            {
                this.Controls.MondayCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox Sunday
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool Sunday
        {
            get
            {
                return this.Controls.SundayCheckBox.Checked;
            }
            
            set
            {
                this.Controls.SundayCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TimeZone
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TimeZoneText
        {
            get
            {
                return this.Controls.TimeZoneComboBox.Text;
            }
            
            set
            {
                this.Controls.TimeZoneComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control StartTimeTimePicker
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string StartTimeTimePickerText
        {
            get
            {
                return this.Controls.StartTimeTimePicker.DateTimeString;
            }
            
            set
            {
                this.Controls.StartTimeTimePicker.DateTime = 
                    System.DateTime.Parse(value);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control EndTimeTimePicker
        /// </summary>
        /// <history>
        /// 	[KellyMor] 30-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EndTimeTimePickerText
        {
            get
            {
                return this.Controls.EndTimeTimePicker.DateTimeString;
            }
            
            set
            {
                System.DateTime testDate;
                if (System.DateTime.TryParse(value, out testDate))
                {
                    this.Controls.EndTimeTimePicker.DateTime =
                        testDate;
                }
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ExcludeStartTimeTimePicker
        /// </summary>
        /// <history>
        /// 	[KellyMor] 06-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ExcludeStartTimeTimePickerText
        {
            get
            {
                return this.Controls.ExcludeStartTimeTimePicker.DateTimeString;
            }
            
            set
            {
                this.Controls.ExcludeStartTimeTimePicker.DateTime = 
                    System.DateTime.Parse(value);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ExcludeEndTimeComboBox
        /// </summary>
        /// <history>
        /// 	[KellyMor] 06-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ExcludeEndTimeTimePickerText
        {
            get
            {
                return this.Controls.ExcludeEndTimeTimePicker.DateTimeString;
            }
            
            set
            {
                this.Controls.ExcludeEndTimeTimePicker.DateTime = 
                    System.DateTime.Parse(value);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control StartDateDatePicker
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string StartDateDatePickerText
        {
            get
            {
                return this.Controls.StartDateDatePicker.DateTimeString;
            }
            
            set
            {
                this.Controls.StartDateDatePicker.SendKeys(value);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control EndDateDatePicker
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string EndDateDatePickerText
        {
            get
            {
                return this.Controls.EndDateDatePicker.DateTimeString;
            }
            
            set
            {
                this.Controls.EndDateDatePicker.SendKeys(value);
            }
        }

        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeZoneComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISpecifySchedulePeriodDialogControls.TimeZoneComboBox
        {
            get
            {
                if ((this.cachedTimeZoneComboBox == null))
                {
                    this.cachedTimeZoneComboBox = new ComboBox(this, SpecifySchedulePeriodDialog.ControlIDs.TimeZoneComboBox);
                }
                
                return this.cachedTimeZoneComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeZoneStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISpecifySchedulePeriodDialogControls.TimeZoneStaticControl
        {
            get
            {
                if ((this.cachedTimeZoneStaticControl == null))
                {
                    this.cachedTimeZoneStaticControl = new StaticControl(this, SpecifySchedulePeriodDialog.ControlIDs.TimeZoneStaticControl);
                }
                
                return this.cachedTimeZoneStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StartTimeTimePicker control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DateTimePicker ISpecifySchedulePeriodDialogControls.StartTimeTimePicker
        {
            get
            {
                if ((this.cachedStartTimeTimePicker == null))
                {
                    this.cachedStartTimeTimePicker =
                        new DateTimePicker(
                            this, 
                            SpecifySchedulePeriodDialog.ControlIDs.StartTimeTimePicker);
                }

                return this.cachedStartTimeTimePicker;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeZoneSpinner control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner ISpecifySchedulePeriodDialogControls.TimeZoneSpinner
        {
            get
            {
                if ((this.cachedTimeZoneSpinner == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedTimeZoneSpinner = new Spinner(wndTemp);
                }
                
                return this.cachedTimeZoneSpinner;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllDay24HoursRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ISpecifySchedulePeriodDialogControls.AllDay24HoursRadioButton
        {
            get
            {
                if ((this.cachedAllDay24HoursRadioButton == null))
                {
                    this.cachedAllDay24HoursRadioButton = new RadioButton(this, SpecifySchedulePeriodDialog.ControlIDs.AllDay24HoursRadioButton);
                }
                
                return this.cachedAllDay24HoursRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeRangeRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ISpecifySchedulePeriodDialogControls.TimeRangeRadioButton
        {
            get
            {
                if ((this.cachedTimeRangeRadioButton == null))
                {
                    this.cachedTimeRangeRadioButton = new RadioButton(this, SpecifySchedulePeriodDialog.ControlIDs.TimeRangeRadioButton);
                }
                
                return this.cachedTimeRangeRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludeTimeRangeRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ISpecifySchedulePeriodDialogControls.ExcludeTimeRangeRadioButton
        {
            get
            {
                if ((this.cachedExcludeTimeRangeRadioButton == null))
                {
                    this.cachedExcludeTimeRangeRadioButton = 
                        new RadioButton(
                            this,
                            SpecifySchedulePeriodDialog.ControlIDs.ExcludeTimeRangeRadioButton);
                }

                return this.cachedExcludeTimeRangeRadioButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludeStartTimeComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DateTimePicker ISpecifySchedulePeriodDialogControls.ExcludeStartTimeTimePicker                                                                                                        
        {
            get
            {
                if ((this.cachedExcludeStartTimeTimePicker == null))
                {
                    this.cachedExcludeStartTimeTimePicker =
                        new DateTimePicker(
                            this,
                            SpecifySchedulePeriodDialog.ControlIDs.ExcludeStartTimePicker);
                }

                return this.cachedExcludeStartTimeTimePicker;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludeEndTimeComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DateTimePicker ISpecifySchedulePeriodDialogControls.ExcludeEndTimeTimePicker
        {
            get
            {
                if ((this.cachedExcludeEndTimeTimePicker == null))
                {
                    this.cachedExcludeEndTimeTimePicker = 
                        new DateTimePicker(
                            this, 
                            SpecifySchedulePeriodDialog.ControlIDs.ExcludeEndTimePicker);
                }

                return this.cachedExcludeEndTimeTimePicker;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EndTimeStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISpecifySchedulePeriodDialogControls.EndTimeStaticControl
        {
            get
            {
                if ((this.cachedEndTimeStaticControl == null))
                {
                    this.cachedEndTimeStaticControl = new StaticControl(this, SpecifySchedulePeriodDialog.ControlIDs.EndTimeStaticControl);
                }
                
                return this.cachedEndTimeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EndTimeTimePicker control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DateTimePicker ISpecifySchedulePeriodDialogControls.EndTimeTimePicker
        {
            get
            {
                if ((this.cachedEndTimeTimePicker == null))
                {
                    this.cachedEndTimeTimePicker = 
                        new DateTimePicker(
                            this, 
                            SpecifySchedulePeriodDialog.ControlIDs.EndTimeTimePicker);
                }

                return this.cachedEndTimeTimePicker;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeZoneSpinner2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner ISpecifySchedulePeriodDialogControls.TimeZoneSpinner2
        {
            get
            {
                if ((this.cachedTimeZoneSpinner2 == null))
                {
                    Window wndTemp = this;
                                         
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedTimeZoneSpinner2 = new Spinner(wndTemp);
                }
                
                return this.cachedTimeZoneSpinner2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlwaysRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ISpecifySchedulePeriodDialogControls.AlwaysRadioButton
        {
            get
            {
                if ((this.cachedAlwaysRadioButton == null))
                {
                    this.cachedAlwaysRadioButton = new RadioButton(this, SpecifySchedulePeriodDialog.ControlIDs.AlwaysRadioButton);
                }
                
                return this.cachedAlwaysRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DateRangeRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ISpecifySchedulePeriodDialogControls.DateRangeRadioButton
        {
            get
            {
                if ((this.cachedDateRangeRadioButton == null))
                {
                    this.cachedDateRangeRadioButton = new RadioButton(this, SpecifySchedulePeriodDialog.ControlIDs.DateRangeRadioButton);
                }
                
                return this.cachedDateRangeRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StartDateDatePicker control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DateTimePicker ISpecifySchedulePeriodDialogControls.StartDateDatePicker
        {
            get
            {
                if ((this.cachedStartDateDatePicker == null))
                {
                    this.cachedStartDateDatePicker = 
                        new DateTimePicker(
                            this, 
                            SpecifySchedulePeriodDialog.ControlIDs.StartDateDatePicker);
                }
                
                return this.cachedStartDateDatePicker;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EndDateDatePicker control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        DateTimePicker ISpecifySchedulePeriodDialogControls.EndDateDatePicker
        {
            get
            {
                if ((this.cachedEndDateDatePicker == null))
                {
                    this.cachedEndDateDatePicker = 
                        new DateTimePicker(
                            this, 
                            SpecifySchedulePeriodDialog.ControlIDs.EndDateDatePicker);
                }
                
                return this.cachedEndDateDatePicker;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EndDateStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISpecifySchedulePeriodDialogControls.EndDateStaticControl
        {
            get
            {
                if ((this.cachedEndDateStaticControl == null))
                {
                    this.cachedEndDateStaticControl = new StaticControl(this, SpecifySchedulePeriodDialog.ControlIDs.EndDateStaticControl);
                }
                
                return this.cachedEndDateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FridayCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ISpecifySchedulePeriodDialogControls.FridayCheckBox
        {
            get
            {
                if ((this.cachedFridayCheckBox == null))
                {
                    this.cachedFridayCheckBox = new CheckBox(this, SpecifySchedulePeriodDialog.ControlIDs.FridayCheckBox);
                }
                
                return this.cachedFridayCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SaturdayCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ISpecifySchedulePeriodDialogControls.SaturdayCheckBox
        {
            get
            {
                if ((this.cachedSaturdayCheckBox == null))
                {
                    this.cachedSaturdayCheckBox = new CheckBox(this, SpecifySchedulePeriodDialog.ControlIDs.SaturdayCheckBox);
                }
                
                return this.cachedSaturdayCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThursdayCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ISpecifySchedulePeriodDialogControls.ThursdayCheckBox
        {
            get
            {
                if ((this.cachedThursdayCheckBox == null))
                {
                    this.cachedThursdayCheckBox = new CheckBox(this, SpecifySchedulePeriodDialog.ControlIDs.ThursdayCheckBox);
                }
                
                return this.cachedThursdayCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WednesdayCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ISpecifySchedulePeriodDialogControls.WednesdayCheckBox
        {
            get
            {
                if ((this.cachedWednesdayCheckBox == null))
                {
                    this.cachedWednesdayCheckBox = new CheckBox(this, SpecifySchedulePeriodDialog.ControlIDs.WednesdayCheckBox);
                }
                
                return this.cachedWednesdayCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TuesdayCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ISpecifySchedulePeriodDialogControls.TuesdayCheckBox
        {
            get
            {
                if ((this.cachedTuesdayCheckBox == null))
                {
                    this.cachedTuesdayCheckBox = new CheckBox(this, SpecifySchedulePeriodDialog.ControlIDs.TuesdayCheckBox);
                }
                
                return this.cachedTuesdayCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MondayCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ISpecifySchedulePeriodDialogControls.MondayCheckBox
        {
            get
            {
                if ((this.cachedMondayCheckBox == null))
                {
                    this.cachedMondayCheckBox = new CheckBox(this, SpecifySchedulePeriodDialog.ControlIDs.MondayCheckBox);
                }
                
                return this.cachedMondayCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SundayCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ISpecifySchedulePeriodDialogControls.SundayCheckBox
        {
            get
            {
                if ((this.cachedSundayCheckBox == null))
                {
                    this.cachedSundayCheckBox = new CheckBox(this, SpecifySchedulePeriodDialog.ControlIDs.SundayCheckBox);
                }
                
                return this.cachedSundayCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ForTheseTimesStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISpecifySchedulePeriodDialogControls.ForTheseTimesStaticControl
        {
            get
            {
                if ((this.cachedForTheseTimesStaticControl == null))
                {
                    this.cachedForTheseTimesStaticControl = new StaticControl(this, SpecifySchedulePeriodDialog.ControlIDs.ForTheseTimesStaticControl);
                }
                
                return this.cachedForTheseTimesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WeeklyRecurrenceStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISpecifySchedulePeriodDialogControls.WeeklyRecurrenceStaticControl
        {
            get
            {
                if ((this.cachedWeeklyRecurrenceStaticControl == null))
                {
                    this.cachedWeeklyRecurrenceStaticControl = new StaticControl(this, SpecifySchedulePeriodDialog.ControlIDs.WeeklyRecurrenceStaticControl);
                }
                
                return this.cachedWeeklyRecurrenceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DaysOfTheWeekStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISpecifySchedulePeriodDialogControls.DaysOfTheWeekStaticControl
        {
            get
            {
                if ((this.cachedDaysOfTheWeekStaticControl == null))
                {
                    this.cachedDaysOfTheWeekStaticControl = new StaticControl(this, SpecifySchedulePeriodDialog.ControlIDs.DaysOfTheWeekStaticControl);
                }
                
                return this.cachedDaysOfTheWeekStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DateRangeStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISpecifySchedulePeriodDialogControls.DateRangeStaticControl
        {
            get
            {
                if ((this.cachedDateRangeStaticControl == null))
                {
                    this.cachedDateRangeStaticControl = new StaticControl(this, SpecifySchedulePeriodDialog.ControlIDs.DateRangeStaticControl);
                }
                
                return this.cachedDateRangeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISpecifySchedulePeriodDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SpecifySchedulePeriodDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISpecifySchedulePeriodDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, SpecifySchedulePeriodDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }

        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Friday
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFriday()
        {
            this.Controls.FridayCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Saturday
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSaturday()
        {
            this.Controls.SaturdayCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Thursday
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickThursday()
        {
            this.Controls.ThursdayCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Wednesday
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickWednesday()
        {
            this.Controls.WednesdayCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Tuesday
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickTuesday()
        {
            this.Controls.TuesdayCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Monday
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickMonday()
        {
            this.Controls.MondayCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Sunday
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSunday()
        {
            this.Controls.SundayCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
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
        /// 	[KellyMor] 25-AUG-08 Created
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
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = 
                    new Window(
                        Strings.DialogTitle, 
                        StringMatchSyntax.ExactMatch, 
                        WindowClassNames.WinForms10Window8, 
                        StringMatchSyntax.ExactMatch, 
                        app.MainWindow, 
                        Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow) 
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " +
                            numberOfTries +
                            " of " +
                            maxTries);

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find dialog with title '" +
                        Strings.DialogTitle +
                        "'");

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }
            
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
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
                ";Specify Schedule" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TimeZone
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTimeZone =
                ";Time zone:;ManagedString" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";timezoneLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AllDay24Hours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllDay24Hours =
                ";All &day (24 hours)" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";allDay.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  StartTime
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStartTime =
                ";F&rom:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";timeRange.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EndTime
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEndTime =
                ";T&o:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";timesToLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Always
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlways =
                ";&Always" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";always.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  StartDate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStartDate =
                ";&From:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";dateRange.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EndDate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEndDate =
                ";&To:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";dateToLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Friday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFriday =
                ";Fr&iday" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";friday.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Saturday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSaturday =
                ";Saturda&y" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";saturday.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Thursday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThursday =
                ";T&hursday" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";thursday.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Wednesday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWednesday =
                ";&Wednesday" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";wednesday.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tuesday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTuesday =
                ";T&uesday" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";tuesday.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Monday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonday =
                ";&Monday" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";monday.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Sunday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSunday =
                ";&Sunday" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";sunday.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ForTheseTimes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceForTheseTimes =
                ";For these times:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";timesLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WeeklyRecurrence
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWeeklyRecurrence =
                ";Weekly recurrence:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";weeklyLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OnEachCheckedDayOfTheWeek
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDaysOfTheWeek =
                ";On each checked day of the week:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";daysLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DateRange
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDateRange =
                ";Date range:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";dateLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel =
                ";Cancel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";cancelButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = 
                ";OK" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm" +
                ";okButton.Text";

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
            /// Caches the translated resource string for:  TimeZone
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTimeZone;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AllDay24Hours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAllDay24Hours;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  StartTime
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStartTime;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EndTime
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEndTime;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Always
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlways;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  StartDate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStartDate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EndDate
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEndDate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Friday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFriday;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Saturday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSaturday;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Thursday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThursday;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Wednesday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWednesday;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tuesday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTuesday;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Monday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonday;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Sunday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSunday;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ForTheseTimes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedForTheseTimes;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WeeklyRecurrence
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWeeklyRecurrence;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DaysOfTheWeek
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDaysOfTheWeek;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DateRange
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDateRange;
            
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

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDialogTitle);
                    }
                    
                    return cachedDialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TimeZone translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TimeZone
            {
                get
                {
                    if ((cachedTimeZone == null))
                    {
                        cachedTimeZone = CoreManager.MomConsole.GetIntlStr(ResourceTimeZone);
                    }
                    
                    return cachedTimeZone;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AllDay24Hours translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AllDay24Hours
            {
                get
                {
                    if ((cachedAllDay24Hours == null))
                    {
                        cachedAllDay24Hours = CoreManager.MomConsole.GetIntlStr(ResourceAllDay24Hours);
                    }
                    
                    return cachedAllDay24Hours;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the StartTime translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StartTime
            {
                get
                {
                    if ((cachedStartTime == null))
                    {
                        cachedStartTime = CoreManager.MomConsole.GetIntlStr(ResourceStartTime);
                    }
                    
                    return cachedStartTime;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EndTime translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EndTime
            {
                get
                {
                    if ((cachedEndTime == null))
                    {
                        cachedEndTime = CoreManager.MomConsole.GetIntlStr(ResourceEndTime);
                    }
                    
                    return cachedEndTime;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Always translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Always
            {
                get
                {
                    if ((cachedAlways == null))
                    {
                        cachedAlways = CoreManager.MomConsole.GetIntlStr(ResourceAlways);
                    }
                    
                    return cachedAlways;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the StartDate translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StartDate
            {
                get
                {
                    if ((cachedStartDate == null))
                    {
                        cachedStartDate = CoreManager.MomConsole.GetIntlStr(ResourceStartDate);
                    }
                    
                    return cachedStartDate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EndDate translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EndDate
            {
                get
                {
                    if ((cachedEndDate == null))
                    {
                        cachedEndDate = CoreManager.MomConsole.GetIntlStr(ResourceEndDate);
                    }
                    
                    return cachedEndDate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Friday translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Friday
            {
                get
                {
                    if ((cachedFriday == null))
                    {
                        cachedFriday = CoreManager.MomConsole.GetIntlStr(ResourceFriday);
                    }
                    
                    return cachedFriday;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Saturday translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Saturday
            {
                get
                {
                    if ((cachedSaturday == null))
                    {
                        cachedSaturday = CoreManager.MomConsole.GetIntlStr(ResourceSaturday);
                    }
                    
                    return cachedSaturday;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Thursday translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Thursday
            {
                get
                {
                    if ((cachedThursday == null))
                    {
                        cachedThursday = CoreManager.MomConsole.GetIntlStr(ResourceThursday);
                    }
                    
                    return cachedThursday;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Wednesday translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Wednesday
            {
                get
                {
                    if ((cachedWednesday == null))
                    {
                        cachedWednesday = CoreManager.MomConsole.GetIntlStr(ResourceWednesday);
                    }
                    
                    return cachedWednesday;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tuesday translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tuesday
            {
                get
                {
                    if ((cachedTuesday == null))
                    {
                        cachedTuesday = CoreManager.MomConsole.GetIntlStr(ResourceTuesday);
                    }
                    
                    return cachedTuesday;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Monday translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Monday
            {
                get
                {
                    if ((cachedMonday == null))
                    {
                        cachedMonday = CoreManager.MomConsole.GetIntlStr(ResourceMonday);
                    }
                    
                    return cachedMonday;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Sunday translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Sunday
            {
                get
                {
                    if ((cachedSunday == null))
                    {
                        cachedSunday = CoreManager.MomConsole.GetIntlStr(ResourceSunday);
                    }
                    
                    return cachedSunday;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ForTheseTimes translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ForTheseTimes
            {
                get
                {
                    if ((cachedForTheseTimes == null))
                    {
                        cachedForTheseTimes = CoreManager.MomConsole.GetIntlStr(ResourceForTheseTimes);
                    }
                    
                    return cachedForTheseTimes;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WeeklyRecurrence translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WeeklyRecurrence
            {
                get
                {
                    if ((cachedWeeklyRecurrence == null))
                    {
                        cachedWeeklyRecurrence = CoreManager.MomConsole.GetIntlStr(ResourceWeeklyRecurrence);
                    }
                    
                    return cachedWeeklyRecurrence;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DaysOfTheWeek translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DaysOfTheWeek
            {
                get
                {
                    if ((cachedDaysOfTheWeek == null))
                    {
                        cachedDaysOfTheWeek = CoreManager.MomConsole.GetIntlStr(ResourceDaysOfTheWeek);
                    }
                    
                    return cachedDaysOfTheWeek;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DateRange translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DateRange
            {
                get
                {
                    if ((cachedDateRange == null))
                    {
                        cachedDateRange = CoreManager.MomConsole.GetIntlStr(ResourceDateRange);
                    }
                    
                    return cachedDateRange;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 25-AUG-08 Created
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
            /// 	[KellyMor] 25-AUG-08 Created
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

            #endregion
        }

        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 25-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            #region Date Range Controls

            /// <summary>
            /// Control ID for DateRangeStaticControl
            /// </summary>
            public const string DateRangeStaticControl = "dateLabel";

            /// <summary>
            /// Control ID for AlwaysRadioButton
            /// </summary>
            public const string AlwaysRadioButton = "always";
            
            /// <summary>
            /// Control ID for DateRangeRadioButton
            /// </summary>
            public const string DateRangeRadioButton = "dateRange";
            
            /// <summary>
            /// Control ID for StartDateDatePicker
            /// </summary>
            public const string StartDateDatePicker = "startDatePicker";
            
            /// <summary>
            /// Control ID for EndDateStaticControl
            /// </summary>
            public const string EndDateStaticControl = "dateToLabel";

            /// <summary>
            /// Control ID for EndDateDatePicker
            /// </summary>
            public const string EndDateDatePicker = "endDatePicker";

            #endregion Date Range Controls

            #region Weekly Occurrence Controls

            /// <summary>
            /// Control ID for WeeklyRecurrenceStaticControl
            /// </summary>
            public const string WeeklyRecurrenceStaticControl = "weeklyLabel";
            
            /// <summary>
            /// Control ID for ForTheseTimesStaticControl
            /// </summary>
            public const string ForTheseTimesStaticControl = "timesLabel";
            
            /// <summary>
            /// Control ID for AllDay24HoursRadioButton
            /// </summary>
            public const string AllDay24HoursRadioButton = "allDay";
            
            /// <summary>
            /// Control ID for TimeRangeRadioButton
            /// </summary>
            public const string TimeRangeRadioButton = "timeRange";
            
            /// <summary>
            /// Control ID for StartTimeTimePicker
            /// </summary>
            public const string StartTimeTimePicker = "fromTimePicker";
            
            /// <summary>
            /// Control ID for EndTimeStaticControl
            /// </summary>
            public const string EndTimeStaticControl = "timesToLabel";
            
            /// <summary>
            /// Control ID for EndTimeTimePicker
            /// </summary>
            public const string EndTimeTimePicker = "toTimePicker";

            /// <summary>
            /// Control ID for ExcludeTimeRangeRadioButton
            /// </summary>
            public const string ExcludeTimeRangeRadioButton = "excludeTimeRange";

            /// <summary>
            /// Control ID for ExcludeStartTimeComboBox
            /// </summary>
            public const string ExcludeStartTimePicker = "exceptFromTimePicker";

            /// <summary>
            /// Control ID for ExcludeEndTimeStaticControl
            /// </summary>
            public const string ExcludeEndTimeStaticControl = "excludeTimesToLabel";

            /// <summary>
            /// Control ID for ExcludeEndTimeComboBox
            /// </summary>
            public const string ExcludeEndTimePicker = "exceptToTimePicker";

            #endregion Weekly Occurrence Controls

            #region Days of the Week Controls

            /// <summary>
            /// Control ID for DaysOfTheWeekStaticControl
            /// </summary>
            public const string DaysOfTheWeekStaticControl = "daysLabel";

            /// <summary>
            /// Control ID for SundayCheckBox
            /// </summary>
            public const string SundayCheckBox = "sunday";
            
            /// <summary>
            /// Control ID for MondayCheckBox
            /// </summary>
            public const string MondayCheckBox = "monday";
            
            /// <summary>
            /// Control ID for TuesdayCheckBox
            /// </summary>
            public const string TuesdayCheckBox = "tuesday";
            
            /// <summary>
            /// Control ID for WednesdayCheckBox
            /// </summary>
            public const string WednesdayCheckBox = "wednesday";
            
            /// <summary>
            /// Control ID for ThursdayCheckBox
            /// </summary>
            public const string ThursdayCheckBox = "thursday";
            
            /// <summary>
            /// Control ID for FridayCheckBox
            /// </summary>
            public const string FridayCheckBox = "friday";
            
            /// <summary>
            /// Control ID for SaturdayCheckBox
            /// </summary>
            public const string SaturdayCheckBox = "saturday";

            #endregion Days of the Week Controls

            #region Timezone Controls

            /// <summary>
            /// Control ID for TimeZoneStaticControl
            /// </summary>
            public const string TimeZoneStaticControl = "timezoneLabel";

            /// <summary>
            /// Control ID for TimeZoneComboBox
            /// </summary>
            public const string TimeZoneComboBox = "timezoneBox";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";

            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            #endregion
        }

        #endregion
    }
}
