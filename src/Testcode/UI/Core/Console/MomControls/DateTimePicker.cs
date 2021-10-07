// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft" file="DateTimePicker.cs">
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <project>
//    System Center Console Framework
// </project>
// <summary>
//   Date Time Picker
// </summary>
// <history>
//   [v-madrid] 2/13/2009 Created
// </history>
// -----------------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MomControls
{
    using System;
    using System.ComponentModel;
    using System.Text.RegularExpressions;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;

    #region Interface Definition - IWindowsControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDateTimePickerControls, for DateTimePicker.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-madrid] 2/13/2009 Created
    ///   [mbickle] 7/1/2009 - Fixed SetDate method.  
    ///                        Reuse MonthCalendar code for setting Month/Year.
    ///                        Fixed to properly set the Time.
    ///                        Actually compares Target with what is set.
    ///                        Fixed StyleCop issues.
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDateTimePickerControls
    {
        /// <summary>
        /// Read-only property to access DateTimePickerTextBox
        /// </summary>
        EditComboBox DateTimePickerTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access DateTextBox
        /// </summary>
        TextBox Date
        {
            get;
        }

        /// <summary>
        /// Read-only property to access TimeZoneComboBox
        /// </summary>
        EditComboBox TimeZone
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Time TextBox in DateTimepicker or
        /// TimeEditor in TimeEdit Box
        /// </summary>
        TextBox Time
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Hour textbox in Time
        /// </summary>
        TextBox Hour
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Minute textbox in Time
        /// </summary>
        TextBox Minute
        {
            get;
        }

        /// <summary>
        /// Read-only prperty to access AmPm textbox in Time
        /// </summary>
        TextBox AmPm
        {
            get;
        }

        /// <summary>
        /// Read-only property to access down button in DateTimePicker Time or 
        /// Time Editor in Time Edit Box
        /// </summary>
        Button DownButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access up button in DateTimePicker Time or 
        /// Time Editor in Time Edit Box
        /// </summary>
        Button UpButton
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// DateTimePicker Control Class.
    /// </summary>
    /// <history>
    ///   [v-madrid] 2/13/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class DateTimePicker : Control, IDateTimePickerControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion

        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to DateTimePickerTextBox of type ComboBox
        /// </summary>
        private EditComboBox cachedDateTimePickerTextBox;

        /// <summary>
        /// Cache to hold a reference to Date of type TextBox
        /// </summary>
        private TextBox cachedDate;

        /// <summary>
        /// Cache to hold a reference to TimeZone of type ComboBox
        /// </summary>
        private EditComboBox cachedTimeZone;

        /// <summary>
        /// Cache to hold a reference to Time of type TextBox
        /// </summary>
        private TextBox cachedTime;

        /// <summary>
        /// Cache to hold a reference to Hours of type TextBox
        /// </summary>
        private TextBox cachedHour;

        /// <summary>
        /// Cache to hold a reference to Minutes of type TextBox
        /// </summary>
        private TextBox cachedMinute;

        /// <summary>
        /// Cache to hold a reference to meridian ampm of type TextBox
        /// </summary>
        private TextBox cachedAmPm;

        /// <summary>
        /// Cache to hold a reference to down button in Time box 
        /// </summary>
        private Button cachedDownButton;

        /// <summary>
        /// Cache to hold a reference to up button in Time box
        /// </summary>
        private Button cachedUpButton;
        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// DateTimePicker
        /// </summary>
        /// <param name="dateTimePicker">DateTimePicker Window</param>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        ///   [v-madrid] 2/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DateTimePicker(Window dateTimePicker) :
            base(dateTimePicker)
        {
        }

        /// <summary>
        /// DateTimePicker
        /// </summary>
        /// <param name="parent">Parent Window</param>
        /// <param name="queryId">Query ID</param>
        public DateTimePicker(Window parent, QID queryId) :
            base(parent, queryId)
        {
        }

        /// <summary>
        /// DateTimePicker
        /// </summary>
        /// <param name="parent">Parent Window</param>
        /// <param name="queryId">Query ID</param>
        /// <param name="timeout">Timeout in milliseconds</param>
        public DateTimePicker(Window parent, QID queryId, int timeout) :
            base(parent, queryId, timeout)
        {
        }
        #endregion

        #region IDateTimePicker Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this app.window
        /// </summary>
        /// <value>An interface that groups all of the app.window's control properties together</value>
        /// <history>
        ///   [v-madrid] 2/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDateTimePickerControls Controls
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
        ///  Routine to set/get the text in control DateTimePicker
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DateTimePickerText
        {
            get
            {
                return this.Controls.DateTimePickerTextBox.Text;
            }

            set
            {
                this.Controls.DateTimePickerTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Time
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TimeText
        {
            get
            {
                return this.Controls.Time.Text;
            }

            set
            {
                this.Controls.Time.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TimeZone
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TimeZoneText
        {
            get
            {
                return this.Controls.TimeZone.Text;
            }

            set
            {
                this.Controls.TimeZone.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Date
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DateText
        {
            get
            {
                return this.Controls.Date.Text;
            }

            set
            {
                this.Controls.Date.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Hour
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string HourText
        {
            get
            {
                return this.Controls.Hour.Text;
            }

            set
            {
                this.Controls.Hour.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Minute
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MinuteText
        {
            get
            {
                return this.Controls.Minute.Text;
            }

            set
            {
                this.Controls.Minute.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AMPM (meridian)
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AmPmText
        {
            get
            {
                return this.Controls.AmPm.Text;
            }

            set
            {
                this.Controls.AmPm.Text = value;
            }
        }

        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DateTimePickerTextBox control
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public EditComboBox DateTimePickerTextBox
        {
            get
            {
                if ((this.cachedDateTimePickerTextBox == null))
                {
                    this.cachedDateTimePickerTextBox = new EditComboBox(new Desktop(), DateTimePicker.QueryIds.DateTimePickerTextBox);
                }

                return this.cachedDateTimePickerTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeZoneComboBox control
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public EditComboBox TimeZone
        {
            get
            {
                if ((this.cachedTimeZone == null))
                {
                    this.cachedTimeZone = new EditComboBox(this, DateTimePicker.QueryIds.TimeZone);
                }

                return this.cachedTimeZone;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Time TextBox control
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TextBox Time
        {
            get
            {
                if ((this.cachedTime == null))
                {
                    this.cachedTime = new TextBox(this, DateTimePicker.QueryIds.Time);
                }

                return this.cachedTime;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Date TextBox control
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TextBox Date
        {
            get
            {
                if ((this.cachedDate == null))
                {
                    this.cachedDate = new TextBox(this, DateTimePicker.QueryIds.Date);
                }

                return this.cachedDate;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Hour TextBox control in Time
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TextBox Hour
        {
            get
            {
                if ((this.cachedHour == null))
                {
                    this.cachedHour = new TextBox(this, DateTimePicker.QueryIds.Hour);
                }

                return this.cachedHour;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Minute TextBox control in Time
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TextBox Minute
        {
            get
            {
                if ((this.cachedMinute == null))
                {
                    this.cachedMinute = new TextBox(this, DateTimePicker.QueryIds.Minute);
                }

                return this.cachedMinute;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AmPm TextBox control in Time
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TextBox AmPm
        {
            get
            {
                if ((this.cachedAmPm == null))
                {
                    this.cachedAmPm = new TextBox(this, DateTimePicker.QueryIds.AmPm);
                }

                return this.cachedAmPm;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DownButton button control in Time box
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public Button DownButton
        {
            get
            {
                if ((this.cachedDownButton == null))
                {
                    this.cachedDownButton = new Button(this, DateTimePicker.QueryIds.DownButton);
                }

                return this.cachedDownButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UpButton button control in Time box
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/25/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public Button UpButton
        {
            get
            {
                if ((this.cachedUpButton == null))
                {
                    this.cachedUpButton = new Button(this, DateTimePicker.QueryIds.UpButton);
                }

                return this.cachedUpButton;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Click on the date time picker text box. 
        /// Verify that a valid date appears in the DateTimePickerTextBox  text box.
        /// Note : Date format used: d MMMM yyyy hh:mm tt
        /// Example : 20 February 2009 07:28 AM
        /// </summary>
        /// <returns>True/False</returns>
        public bool ClickOnDateTimePickerTextBox()
        {
            EditComboBox dayPicker = this.DateTimePickerTextBox;

            dayPicker.Click();

            string datePickerText = dayPicker.ScreenElement.Value;

            Regex regex = new Regex(@"[^a-z\d\s]*([0-9]*)\s(.\w*)\s(\d\d\d\d)\s(\d\d:\d\d)\s([ap]m)", RegexOptions.IgnoreCase);

            if (!regex.IsMatch(datePickerText))
            {
                Utilities.LogMessage("Date Time Picker:: did not match the date the user picked");

                return false;
            }

            dayPicker.ClickDropDown();

            return true;
        }

        /// <summary>
        /// Click the drop down button in Date Time Picker.  Validate that the today day is chosen.
        /// Note : The date format is : d MMMM yyyy hh:mm tt
        /// </summary>
        /// <returns>True/False</returns>
        public bool ChooseTodayDayFromDate()
        {
            EditComboBox dayTimePicker = this.DateTimePickerTextBox;

            string dateTimePickerText = dayTimePicker.ScreenElement.Value;

            dayTimePicker.ClickDropDown(10000, false);

            Regex regex = new Regex(@"[^a-z\d\s]*([0-9]*)\s(.\w*)\s(\d\d\d\d)\s(\d\d:\d\d)\s([ap]m)", RegexOptions.IgnoreCase);
            Match match = regex.Match(dateTimePickerText);

            if (match.Groups.Count != 6)
            {
                Utilities.LogMessage("Date Time Picker::did not find a match for the user's pick");

                return false;
            }

            string substring1 = match.Groups[1].Value;

            string currentDay = DateTime.Today.Day.ToString();

            if (substring1 != currentDay)
            {
                Utilities.LogMessage("Date Time Picker::Wrong day was selected");

                return false;
            }

            dayTimePicker.ClickDropDown();

            return true;
        }

        /// <summary>
        /// Use the right arrow key once, to pick the next day on the Date textbox.
        /// Validate the correct selection.
        /// Date format: d MMMM yyyy hh:mm tt
        /// </summary>
        /// <returns>True/False</returns>
        public bool ChooseDifferentDayFromDate()
        {
            TextBox dayOfMonth = new TextBox(this);

            dayOfMonth.ScreenElement.SendKeys(KeyboardCodes.RightArrow);

            EditComboBox dayTimePicker = this.DateTimePickerTextBox;

            dayTimePicker.Click();

            string dateTimePickerText = dayTimePicker.ScreenElement.Value;
            Utilities.LogMessage("DateTimePickerChooseAnotherDate::Date in DateTimePicker text box {0}" + dateTimePickerText);

            Regex regex = new Regex(@"[^a-z\d\s]*([0-9]*)\s(.\w*)\s(\d\d\d\d)\s(\d\d:\d\d)\s([ap]m)", RegexOptions.IgnoreCase);
            Match match = regex.Match(dateTimePickerText);

            if (match.Groups.Count != 6)
            {
                Utilities.LogMessage("Date Time Picker::did not find a match for the user's pick");

                return false;
            }

            // Convert the string to a DateTime object
            IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);

            DateTime tomorrow = DateTime.ParseExact(dateTimePickerText, "d MMMM yyyy hh:mm tt", culture);

            DateTime today = DateTime.Now;

            Utilities.LogMessage("DateTimePickerChooseAnotherDate::Wrong Day Expected Day {0}, Actual Date {1}, DateTime.Now {2}" +
            dateTimePickerText + tomorrow.ToString() + DateTime.Now.ToString());         
            dayTimePicker.Click();

            return true;
        }

        /// <summary>
        /// Set the calendar to the desired date
        /// </summary>
        /// <param name="targetDate">Target Date to set.</param>
        /// <returns>True if Date Set, False otherwise.</returns>
        public bool SetDate(DateTime targetDate)
        {
            MonthCalendar dayOfMonth = new MonthCalendar(this);
            EditComboBox dayTimePicker = this.DateTimePickerTextBox;
            bool dateSet = false;

            Utilities.LogMessage("SetDate:: targetDate: " + targetDate.ToString());

            // Get the current date from the Date Time Picker box
            string dateTimePickerString = dayTimePicker.ScreenElement.Value;

            // Convert the string to a DateTime object
            IFormatProvider culture = new System.Globalization.CultureInfo(System.Globalization.CultureInfo.CurrentCulture.Name, true);

            // Set the Month/Year
            DateTime currentDate = DateTime.ParseExact(dateTimePickerString, "d MMMM yyyy hh:mm tt", culture);
            dayOfMonth.SetDate(targetDate);
            
            // Select Day of Month
            string calendarday = dayOfMonth.GetCalendarDayAutomationID(targetDate.Day - 1);
            dayOfMonth.ScreenElement.FindByPartialQueryId(calendarday, null).LeftButtonClick(-1, -1);
            
            // Set the Time
            this.Hour.SendKeys(string.Format(targetDate.TimeOfDay.ToString(), "hh"));
            this.Minute.SendKeys(string.Format(targetDate.TimeOfDay.ToString(), "mm"));
            this.AmPm.SendKeys(targetDate.ToString("tt"));

            // TODO: Set TimeZone.
            dateTimePickerString = dayTimePicker.ScreenElement.Value;
            currentDate = DateTime.ParseExact(dateTimePickerString, "d MMMM yyyy hh:mm tt", culture);
            dayTimePicker.Click();

            if (DateTime.Compare(currentDate, targetDate) != 0)
            {
                Utilities.LogMessage("SetDate:: currentDate: '" + currentDate.ToString() + "' != targetDate: '" + targetDate.ToString() + "'");
                dateSet = false;
            }
            else
            {
                dateSet = true;
            }
            
            return dateSet;
        }
        #endregion

        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for DateTimePickerTextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string DateTimePickerTextBoxQID = ";[UIA]AutomationId=\'TextBox\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for TimeZone query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string TimeZoneQID = ";[UIA]AutomationId=\'TimeZoneComboBox\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Date TexeBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string DateQID = ";[UIA]AutomationId=\'MonthCalendar\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Time TextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string TimeQID = ";[UIA]AutomationId=\'TimeEditBox\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Hour TextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string HourQID = ";[UIA]AutomationId=\'Hour\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Minute TextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string MinuteQID = ";[UIA]AutomationId=\'Minute\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for AmPm TextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string AmPmQID = ";[UIA]AutomationId=\'Ampm\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for DownButton button in Time box query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string DownButtonQID = ";[UIA]AutomationId=\'DownButton\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for UpButton button in Time box query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string UpButtonQID = ";[UIA]AutomationId=\'UpButton\'";

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedDateTimePickerTextBox;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedTimeZone;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedDate;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedTime;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedHour;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedMinute;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedAmPm;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedDownButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedUpButton;
            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DateTimePickerTextBox translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/13/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID DateTimePickerTextBox
            {
                get
                {
                    if ((cachedDateTimePickerTextBox == null))
                    {
                        cachedDateTimePickerTextBox = new QID(DateTimePickerTextBoxQID);
                    }

                    return cachedDateTimePickerTextBox;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TimeZone ComboBox translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/13/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID TimeZone
            {
                get
                {
                    if ((cachedTimeZone == null))
                    {
                        cachedTimeZone = new QID(TimeZoneQID);
                    }

                    return cachedTimeZone;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Time TextBox translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/13/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID Time
            {
                get
                {
                    if ((cachedTime == null))
                    {
                        cachedTime = new QID(TimeQID);
                    }

                    return cachedTime;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Date TextBox translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/13/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID Date
            {
                get
                {
                    if ((cachedDate == null))
                    {
                        cachedDate = new QID(DateQID);
                    }

                    return cachedDate;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Hour in Time box translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/25/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID Hour
            {
                get
                {
                    if ((cachedHour == null))
                    {
                        cachedHour = new QID(HourQID);
                    }

                    return cachedHour;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Minute in Time box translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/25/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID Minute
            {
                get
                {
                    if ((cachedMinute == null))
                    {
                        cachedMinute = new QID(MinuteQID);
                    }

                    return cachedMinute;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Meridian ampm TextBox in Time box translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/25/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID AmPm
            {
                get
                {
                    if ((cachedAmPm == null))
                    {
                        cachedAmPm = new QID(AmPmQID);
                    }

                    return cachedAmPm;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to DownButton button in Time box translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/25/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID DownButton
            {
                get
                {
                    if ((cachedDownButton == null))
                    {
                        cachedDownButton = new QID(DownButtonQID);
                    }

                    return cachedDownButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to UpButton button in Time box translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/25/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID UpButton
            {
                get
                {
                    if ((cachedUpButton == null))
                    {
                        cachedUpButton = new QID(UpButtonQID);
                    }

                    return cachedUpButton;
                }
            }
            #endregion
        }
        #endregion

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Strings Class
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/13/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static class Strings
        {
            /// <summary>
            /// Resource string for Date Time Picker
            /// </summary>
            public const string DateTimePicker = "Date Time Picker";

            /// <summary>
            /// Resource string for Show Time Zone
            /// </summary>
            public const string TimeZone = "Time Zone";

            /// <summary>
            /// Resource string for Show Date
            /// </summary>
            public const string Date = "Date";

            /// <summary>
            /// Resource string for Show Time 
            /// </summary>
            public const string Time = "Time";
        }
        #endregion
    }
}

