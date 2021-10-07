// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SpecifySchedulePeriodDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[KellyMor] 4/6/2006 Created
//  [KellyMor] 07-Jun-06    Updated resource assembly for new Admin assembly
//  [KellyMor] 08-Jun-06    Updated resource assembly namespace
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Notifications.Recipients
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - ScheduleOption

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group ScheduleOption
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum ScheduleOption
    {
        /// <summary>
        /// AllDay24Hours = 0
        /// </summary>
        AllDay24Hours = 0,
        
        /// <summary>
        /// From = 1
        /// </summary>
        From = 1,
    }
    #endregion
    
    #region Radio Group Enumeration - RadioGroup1

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroup1
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroup1
    {
        /// <summary>
        /// Always = 0
        /// </summary>
        Always = 0,
        
        /// <summary>
        /// From2 = 1
        /// </summary>
        From2 = 1,
    }
    #endregion
    
    #region Interface Definition - ISpecifySchedulePeriodDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISpecifySchedulePeriodDialogControls, for SpecifySchedulePeriodDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISpecifySchedulePeriodDialogControls
    {
        /// <summary>
        /// Read-only property to access ForTheseTimesComboBox
        /// </summary>
        ComboBox ForTheseTimesComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Spinner1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Spinner Spinner1
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
        /// Read-only property to access FromRadioButton
        /// </summary>
        RadioButton FromRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NotificationRecipientDisplayNameComboBox
        /// </summary>
        ComboBox NotificationRecipientDisplayNameComboBox
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
        /// Read-only property to access FromRadioButton2
        /// </summary>
        RadioButton FromRadioButton2
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
        /// Read-only property to access ToStaticControl
        /// </summary>
        StaticControl ToStaticControl
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
        /// Read-only property to access ToStaticControl2
        /// </summary>
        StaticControl ToStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToComboBox
        /// </summary>
        ComboBox ToComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Spinner2
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Spinner Spinner2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OnEachCheckedWeekdayStaticControl
        /// </summary>
        StaticControl OnEachCheckedWeekdayStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToComboBox2
        /// </summary>
        ComboBox ToComboBox2
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
    /// Class to encapsulate the Specify Schedule Period dialog
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/6/2006 Created
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
        /// Cache to hold a reference to ForTheseTimesComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedForTheseTimesComboBox;
        
        /// <summary>
        /// Cache to hold a reference to Spinner1 of type Spinner
        /// </summary>
        private Spinner cachedSpinner1;
        
        /// <summary>
        /// Cache to hold a reference to AllDay24HoursRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAllDay24HoursRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to FromRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedFromRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to NotificationRecipientDisplayNameComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedNotificationRecipientDisplayNameComboBox;
        
        /// <summary>
        /// Cache to hold a reference to AlwaysRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAlwaysRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to FromRadioButton2 of type RadioButton
        /// </summary>
        private RadioButton cachedFromRadioButton2;
        
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
        /// Cache to hold a reference to ToStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ForTheseTimesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedForTheseTimesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WeeklyRecurrenceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWeeklyRecurrenceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedToStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to ToComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedToComboBox;
        
        /// <summary>
        /// Cache to hold a reference to Spinner2 of type Spinner
        /// </summary>
        private Spinner cachedSpinner2;
        
        /// <summary>
        /// Cache to hold a reference to OnEachCheckedWeekdayStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOnEachCheckedWeekdayStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToComboBox2 of type ComboBox
        /// </summary>
        private ComboBox cachedToComboBox2;
        
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
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SpecifySchedulePeriodDialog of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SpecifySchedulePeriodDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group ScheduleOption
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ScheduleOption ScheduleOption
        {
            get
            {
                if ((this.Controls.AllDay24HoursRadioButton.ButtonState == ButtonState.Checked))
                {
                    return ScheduleOption.AllDay24Hours;
                }
                
                if ((this.Controls.FromRadioButton.ButtonState == ButtonState.Checked))
                {
                    return ScheduleOption.From;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == ScheduleOption.AllDay24Hours))
                {
                    this.Controls.AllDay24HoursRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == ScheduleOption.From))
                    {
                        this.Controls.FromRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroup1
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroup1 RadioGroup1
        {
            get
            {
                if ((this.Controls.AlwaysRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup1.Always;
                }
                
                if ((this.Controls.FromRadioButton2.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup1.From2;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroup1.Always))
                {
                    this.Controls.AlwaysRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup1.From2))
                    {
                        this.Controls.FromRadioButton2.ButtonState = ButtonState.Checked;
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        ///  Routine to set/get the text in control ForTheseTimes
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ForTheseTimesText
        {
            get
            {
                return this.Controls.ForTheseTimesComboBox.Text;
            }
            
            set
            {
                this.Controls.ForTheseTimesComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control NotificationRecipientDisplayName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NotificationRecipientDisplayNameText
        {
            get
            {
                return this.Controls.NotificationRecipientDisplayNameComboBox.Text;
            }
            
            set
            {
                this.Controls.NotificationRecipientDisplayNameComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control To
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ToText
        {
            get
            {
                return this.Controls.ToComboBox.Text;
            }
            
            set
            {
                this.Controls.ToComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control To2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string To2Text
        {
            get
            {
                return this.Controls.ToComboBox2.Text;
            }
            
            set
            {
                this.Controls.ToComboBox2.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ForTheseTimesComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISpecifySchedulePeriodDialogControls.ForTheseTimesComboBox
        {
            get
            {
                if ((this.cachedForTheseTimesComboBox == null))
                {
                    this.cachedForTheseTimesComboBox = new ComboBox(this, SpecifySchedulePeriodDialog.ControlIDs.ForTheseTimesComboBox);
                }
                return this.cachedForTheseTimesComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Spinner1 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner ISpecifySchedulePeriodDialogControls.Spinner1
        {
            get
            {
                if ((this.cachedSpinner1 == null))
                {
                    Window wndTemp = this.AccessibleObject.Window;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedSpinner1 = new Spinner(wndTemp);
                }
                return this.cachedSpinner1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllDay24HoursRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
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
        ///  Exposes access to the FromRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ISpecifySchedulePeriodDialogControls.FromRadioButton
        {
            get
            {
                if ((this.cachedFromRadioButton == null))
                {
                    this.cachedFromRadioButton = new RadioButton(this, SpecifySchedulePeriodDialog.ControlIDs.FromRadioButton);
                }
                return this.cachedFromRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NotificationRecipientDisplayNameComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISpecifySchedulePeriodDialogControls.NotificationRecipientDisplayNameComboBox
        {
            get
            {
                if ((this.cachedNotificationRecipientDisplayNameComboBox == null))
                {
                    this.cachedNotificationRecipientDisplayNameComboBox = new ComboBox(this, SpecifySchedulePeriodDialog.ControlIDs.NotificationRecipientDisplayNameComboBox);
                }
                return this.cachedNotificationRecipientDisplayNameComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlwaysRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
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
        ///  Exposes access to the FromRadioButton2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ISpecifySchedulePeriodDialogControls.FromRadioButton2
        {
            get
            {
                if ((this.cachedFromRadioButton2 == null))
                {
                    this.cachedFromRadioButton2 = new RadioButton(this, SpecifySchedulePeriodDialog.ControlIDs.FromRadioButton2);
                }
                return this.cachedFromRadioButton2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FridayCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        ///  Exposes access to the ToStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISpecifySchedulePeriodDialogControls.ToStaticControl
        {
            get
            {
                if ((this.cachedToStaticControl == null))
                {
                    this.cachedToStaticControl = new StaticControl(this, SpecifySchedulePeriodDialog.ControlIDs.ToStaticControl);
                }
                return this.cachedToStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ForTheseTimesStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        ///  Exposes access to the ToStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISpecifySchedulePeriodDialogControls.ToStaticControl2
        {
            get
            {
                if ((this.cachedToStaticControl2 == null))
                {
                    this.cachedToStaticControl2 = new StaticControl(this, SpecifySchedulePeriodDialog.ControlIDs.ToStaticControl2);
                }
                return this.cachedToStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISpecifySchedulePeriodDialogControls.ToComboBox
        {
            get
            {
                if ((this.cachedToComboBox == null))
                {
                    this.cachedToComboBox = new ComboBox(this, SpecifySchedulePeriodDialog.ControlIDs.ToComboBox);
                }
                return this.cachedToComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Spinner2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner ISpecifySchedulePeriodDialogControls.Spinner2
        {
            get
            {
                if ((this.cachedSpinner2 == null))
                {
                    Window wndTemp = this.AccessibleObject.Window;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 14); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedSpinner2 = new Spinner(wndTemp);
                }
                return this.cachedSpinner2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OnEachCheckedWeekdayStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISpecifySchedulePeriodDialogControls.OnEachCheckedWeekdayStaticControl
        {
            get
            {
                if ((this.cachedOnEachCheckedWeekdayStaticControl == null))
                {
                    this.cachedOnEachCheckedWeekdayStaticControl = new StaticControl(this, SpecifySchedulePeriodDialog.ControlIDs.OnEachCheckedWeekdayStaticControl);
                }
                return this.cachedOnEachCheckedWeekdayStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToComboBox2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISpecifySchedulePeriodDialogControls.ToComboBox2
        {
            get
            {
                if ((this.cachedToComboBox2 == null))
                {
                    this.cachedToComboBox2 = new ComboBox(this, SpecifySchedulePeriodDialog.ControlIDs.ToComboBox2);
                }
                return this.cachedToComboBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DateRangeStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                                app.GetIntlStr(Strings.DialogTitle) + "*",
                                StringMatchSyntax.WildCard,
                                WindowClassNames.Dialog,
                                StringMatchSyntax.ExactMatch,
                                app,
                                Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage("Failed to find Schedule dialog!");

                    // throw the existing WindowNotFound exception
                    throw ex;
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
        /// 	[KellyMor] 4/6/2006 Created
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
            private const string ResourceDialogTitle = ";Specify Schedule Period;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.ScheduleEntryForm;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AllDay24Hours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllDay24Hours = ";All day (24 hours);ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.ScheduleEntryForm;allDay.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  From
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFrom = ";From:;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.BusinessHoursFo" +
                "rm;startTimeLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Always
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlways = ";Always;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.NotificationResource;ScheduleAlways";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  From2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFrom2 = ";From:;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.BusinessHoursFo" +
                "rm;startTimeLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Friday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFriday = ";Friday;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.ScheduleEntryForm;friday.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Saturday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSaturday = ";Saturday;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.ScheduleEntryForm;saturday.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Thursday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThursday = ";Thursday;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.ScheduleEntryForm;thursday.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Wednesday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWednesday = ";Wednesday;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.ScheduleEntryForm;wednesday.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tuesday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTuesday = ";Tuesday;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.ScheduleEntryForm;tuesday.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Monday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonday = ";Monday;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.ScheduleEntryForm;monday.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Sunday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSunday = ";Sunday;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.ScheduleEntryForm;sunday.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  To
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTo = ";To:;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.BusinessHoursForm" +
                ";endTimeLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ForTheseTimes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceForTheseTimes = ";For these times:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;r" +
                "Microsoft.EnterpiseManagement.Mom.Internal.UI.Notification.ScheduleEntryForm;timesLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WeeklyRecurrence
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWeeklyRecurrence = ";Weekly recurrence:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.ScheduleEntryForm;weeklyLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  To2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTo2 = ";To:;ManagedString;Microsoft.EnterpriseManagement.UI.Reporting.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Reporting.Parameters.Controls.BusinessHoursForm" +
                ";endTimeLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OnEachCheckedWeekday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOnEachCheckedWeekday = ";On each checked weekday:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.ScheduleEntryForm;daysLabel.T" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DateRange
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDateRange = ";Date range:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.ScheduleEntryForm;dateLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;DC01.bT;buttonOk.Text";
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
            /// Caches the translated resource string for:  AllDay24Hours
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAllDay24Hours;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  From
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFrom;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Always
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlways;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  From2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFrom2;
            
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
            /// Caches the translated resource string for:  To
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTo;
            
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
            /// Caches the translated resource string for:  To2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTo2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OnEachCheckedWeekday
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOnEachCheckedWeekday;
            
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
            /// 	[KellyMor] 4/6/2006 Created
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
            /// Exposes access to the AllDay24Hours translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
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
            /// Exposes access to the From translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string From
            {
                get
                {
                    if ((cachedFrom == null))
                    {
                        cachedFrom = CoreManager.MomConsole.GetIntlStr(ResourceFrom);
                    }
                    return cachedFrom;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Always translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
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
            /// Exposes access to the From2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string From2
            {
                get
                {
                    if ((cachedFrom2 == null))
                    {
                        cachedFrom2 = CoreManager.MomConsole.GetIntlStr(ResourceFrom2);
                    }
                    return cachedFrom2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Friday translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
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
            /// 	[KellyMor] 4/6/2006 Created
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
            /// 	[KellyMor] 4/6/2006 Created
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
            /// 	[KellyMor] 4/6/2006 Created
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
            /// 	[KellyMor] 4/6/2006 Created
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
            /// 	[KellyMor] 4/6/2006 Created
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
            /// 	[KellyMor] 4/6/2006 Created
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
            /// Exposes access to the To translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string To
            {
                get
                {
                    if ((cachedTo == null))
                    {
                        cachedTo = CoreManager.MomConsole.GetIntlStr(ResourceTo);
                    }
                    return cachedTo;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ForTheseTimes translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
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
            /// 	[KellyMor] 4/6/2006 Created
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
            /// Exposes access to the To2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string To2
            {
                get
                {
                    if ((cachedTo2 == null))
                    {
                        cachedTo2 = CoreManager.MomConsole.GetIntlStr(ResourceTo2);
                    }
                    return cachedTo2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OnEachCheckedWeekday translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OnEachCheckedWeekday
            {
                get
                {
                    if ((cachedOnEachCheckedWeekday == null))
                    {
                        cachedOnEachCheckedWeekday = CoreManager.MomConsole.GetIntlStr(ResourceOnEachCheckedWeekday);
                    }
                    return cachedOnEachCheckedWeekday;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DateRange translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/6/2006 Created
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
            /// 	[KellyMor] 4/6/2006 Created
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
            /// 	[KellyMor] 4/6/2006 Created
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
        /// 	[KellyMor] 4/6/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ForTheseTimesComboBox
            /// </summary>
            public const string ForTheseTimesComboBox = "fromTimePicker";
            
            /// <summary>
            /// Control ID for AllDay24HoursRadioButton
            /// </summary>
            public const string AllDay24HoursRadioButton = "allDay";
            
            /// <summary>
            /// Control ID for FromRadioButton
            /// </summary>
            public const string FromRadioButton = "timeRange";
            
            /// <summary>
            /// Control ID for NotificationRecipientDisplayNameComboBox
            /// </summary>
            public const string NotificationRecipientDisplayNameComboBox = "startDatePicker";
            
            /// <summary>
            /// Control ID for AlwaysRadioButton
            /// </summary>
            public const string AlwaysRadioButton = "always";
            
            /// <summary>
            /// Control ID for FromRadioButton2
            /// </summary>
            public const string FromRadioButton2 = "dateRange";
            
            /// <summary>
            /// Control ID for FridayCheckBox
            /// </summary>
            public const string FridayCheckBox = "friday";
            
            /// <summary>
            /// Control ID for SaturdayCheckBox
            /// </summary>
            public const string SaturdayCheckBox = "saturday";
            
            /// <summary>
            /// Control ID for ThursdayCheckBox
            /// </summary>
            public const string ThursdayCheckBox = "thursday";
            
            /// <summary>
            /// Control ID for WednesdayCheckBox
            /// </summary>
            public const string WednesdayCheckBox = "wednesday";
            
            /// <summary>
            /// Control ID for TuesdayCheckBox
            /// </summary>
            public const string TuesdayCheckBox = "tuesday";
            
            /// <summary>
            /// Control ID for MondayCheckBox
            /// </summary>
            public const string MondayCheckBox = "monday";
            
            /// <summary>
            /// Control ID for SundayCheckBox
            /// </summary>
            public const string SundayCheckBox = "sunday";
            
            /// <summary>
            /// Control ID for ToStaticControl
            /// </summary>
            public const string ToStaticControl = "timesToLabel";
            
            /// <summary>
            /// Control ID for ForTheseTimesStaticControl
            /// </summary>
            public const string ForTheseTimesStaticControl = "timesLabel";
            
            /// <summary>
            /// Control ID for WeeklyRecurrenceStaticControl
            /// </summary>
            public const string WeeklyRecurrenceStaticControl = "weeklyLabel";
            
            /// <summary>
            /// Control ID for ToStaticControl2
            /// </summary>
            public const string ToStaticControl2 = "dateToLabel";
            
            /// <summary>
            /// Control ID for ToComboBox
            /// </summary>
            public const string ToComboBox = "toTimePicker";
            
            /// <summary>
            /// Control ID for OnEachCheckedWeekdayStaticControl
            /// </summary>
            public const string OnEachCheckedWeekdayStaticControl = "daysLabel";
            
            /// <summary>
            /// Control ID for ToComboBox2
            /// </summary>
            public const string ToComboBox2 = "endDatePicker";
            
            /// <summary>
            /// Control ID for DateRangeStaticControl
            /// </summary>
            public const string DateRangeStaticControl = "dateLabel";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
        }
        #endregion
    }
}
