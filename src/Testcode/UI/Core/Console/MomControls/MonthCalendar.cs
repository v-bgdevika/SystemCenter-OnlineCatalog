// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="MonthCalendar.cs">
//   Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
//    System Center Console Framework
// </project>
// <summary>
//   Date & Time \ Month Calendar
// </summary>
// <history>
//   [v-madrid] 2/24/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MomControls
{
    using System;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    using System.Text.RegularExpressions;
    
    #region Interface Definition - IWindowsControls 

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IMonthCalendarControls, for MonthCalendar.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-madrid] 2/24/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMonthCalendarControls
    {
        /// <summary>
        /// Read-only property to access Minimum Date TextBox
        /// </summary>
        TextBox MinimumDateTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MinimumDate DropDown Button
        /// </summary>
        Button MinimumDateDropDown
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectedDate TextBox
        /// </summary>
        TextBox SelectedDateTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectedDate DropDown Button
        /// </summary>
        Button SelectedDateDropDown
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MaximumDate TextBox
        /// </summary>
        TextBox MaximumDateTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MaximumDate DropDown Button
        /// </summary>
        Button MaximumDateDropDown
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonthCalendar TextBox
        /// The calendar pane, the month title, previous and next month arrows, week and numbered days
        /// </summary>
        DateTimePicker MonthCalendarTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PreviousMonth Button
        /// </summary>
        Button PreviousMonthButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DisplayMonthTitle text, displays month and year.
        /// Located at the top center of the calendar pane, bellow the Minimum Date, Selected Day and 
        /// Maximum Day controls bar.
        /// </summary>
        TextBox DisplayMonthTitle
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NextMonth Button
        /// </summary>
        Button NextMonthButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access Month bar.
        /// The month bar includes the DisplayMonthTitle and the previous, next month buttons
        /// </summary>
        TextBox MonthTitle
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <history>
    ///   [v-madrid] 2/24/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class MonthCalendar : Control, IMonthCalendarControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
              
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to MinimumDateTextBox of type TextBox
        /// </summary>
        private TextBox cachedMinimumDateTextBox;
        
        /// <summary>
        /// Cache to hold a reference to MinimumDateDropDown of type Button
        /// </summary>
        private Button cachedMinimumDateDropDown;

        /// <summary>
        /// Cache to hold a reference to SelectedDateTextBox of type TextBox
        /// </summary>
        private TextBox cachedSelectedDateTextBox;
        
        /// <summary>
        /// Cache to hold a reference to SelectedDateDropDown of type Button
        /// </summary>
        private Button cachedSelectedDateDropDown;
        
        /// <summary>
        /// Cache to hold a reference to MaximumDateTextBox of type TextBox
        /// </summary>
        private TextBox cachedMaximumDateTextBox;
        
        /// <summary>
        /// Cache to hold a reference to MaximumDateDropDown of type Button
        /// </summary>
        private Button cachedMaximumDateDropDown;
        
        /// <summary>
        /// Cache to hold a reference to MonthCalendarTextBox of type DateTimePicker
        /// </summary>
        private DateTimePicker cachedMonthCalendarTextBox;
        
        /// <summary>
        /// Cache to hold a reference to PreviousMonthButton of type Button
        /// </summary>
        private Button cachedPreviousMonthButton;
        
        /// <summary>
        /// Cache to hold a reference to DisplayMonthTitle of type TextBox
        /// </summary>
        private TextBox cachedDisplayMonthTitle;
        
        /// <summary>
        /// Cache to hold a reference to NextMonthButton of type Button
        /// </summary>
        private Button cachedNextMonthButton;

        /// <summary>
        /// Cache to hold a reference to MonthTitle of type TextBox
        /// </summary>
        private TextBox cachedMonthTitle;
              
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// MonthCalendar
        /// </summary>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public MonthCalendar(Window monthCalendar) :
            base(monthCalendar)
        {
        }

         /// <summary>
        /// MonthCalendar
        /// </summary>
        /// <param name="parent">Parent Window</param>
        /// <param name="queryId">Query ID</param>
        public MonthCalendar(Window parent, QID queryId) :
            base(parent, queryId)
        {
        }

        /// <summary>
        /// MonthCalendar
        /// </summary>
        /// <param name="parent">Parent Window</param>
        /// <param name="queryId">Query ID</param>
        /// <param name="timeout">Timeout in milliseconds</param>
        public MonthCalendar(Window parent, QID queryId, int timeout) :
            base(parent, queryId, timeout)
        {
        }
        #endregion
           
        #region IMonthCalendar Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this app.window
        /// </summary>
        /// <value>An interface that groups all of the app.window's control properties together</value>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IMonthCalendarControls Controls
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
        ///  Routine to set/get the text in control MinimumDate
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MinimumDateText
        {
            get
            {
                return this.Controls.MinimumDateTextBox.Text;
            }
            
            set
            {
                this.Controls.MinimumDateTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SelectedDate
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SelectedDateText
        {
            get
            {
                return this.Controls.SelectedDateTextBox.Text;
            }
            
            set
            {
                this.Controls.SelectedDateTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MaximumDate
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MaximumDateText
        {
            get
            {
                return this.Controls.MaximumDateTextBox.Text;
            }
            
            set
            {
                this.Controls.MaximumDateTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control DisplayMonthTitle
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DisplayMonthTitleText
        {
            get
            {
                return this.Controls.DisplayMonthTitle.Text;
            }
        }
       
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MinimumDateTextBox control
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TextBox MinimumDateTextBox
        {
            get
            {
                if ((this.cachedMinimumDateTextBox == null))
                {
                    this.cachedMinimumDateTextBox = new TextBox(this, MonthCalendar.QueryIds.MinimumDateTextBox);
                }
                
                return this.cachedMinimumDateTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MinimumDateDropDown control
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public Button MinimumDateDropDown
        {
            get
            {
                if ((this.cachedMinimumDateDropDown == null))
                {
                    this.cachedMinimumDateDropDown = new Button(this, MonthCalendar.QueryIds.MinimumDateDropDown);
                }
                
                return this.cachedMinimumDateDropDown;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedDateTextBox control
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TextBox SelectedDateTextBox
        {
            get
            {
                if ((this.cachedSelectedDateTextBox == null))
                {
                    this.cachedSelectedDateTextBox = new TextBox(this, MonthCalendar.QueryIds.SelectedDateTextBox);
                }
                
                return this.cachedSelectedDateTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectedDateDropDown control
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public Button SelectedDateDropDown
        {
            get
            {
                if ((this.cachedSelectedDateDropDown == null))
                {
                   
                    this.cachedSelectedDateDropDown = new Button(this, MonthCalendar.QueryIds.SelectedDateDropDown);
                }
                
                return this.cachedSelectedDateDropDown;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MaximumDateTextBox control
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TextBox MaximumDateTextBox
        {
            get
            {
                if ((this.cachedMaximumDateTextBox == null))
                {
                    this.cachedMaximumDateTextBox = new TextBox(this, MonthCalendar.QueryIds.MaximumDateTextBox);
                }

                return this.cachedMaximumDateTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MaximumDateDropDown control
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public Button MaximumDateDropDown
        {
            get
            {
                if ((this.cachedMaximumDateDropDown == null))
                {
                   this.cachedMaximumDateDropDown = new Button(this, MonthCalendar.QueryIds.MaximumDateDropDown);
                }
                
                return this.cachedMaximumDateDropDown;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonthCalendarTextBoxText control
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DateTimePicker MonthCalendarTextBox
        {
            get
            {
                if ((this.cachedMonthCalendarTextBox == null))
                {
                    this.cachedMonthCalendarTextBox = new DateTimePicker(this, MonthCalendar.QueryIds.MonthCalendarTextBox);
                }
                
                return this.cachedMonthCalendarTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousMonthButton control
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public Button PreviousMonthButton
        {
            get
            {
                if ((this.cachedPreviousMonthButton == null))
                {
                    this.cachedPreviousMonthButton = new Button(this, MonthCalendar.QueryIds.PreviousMonthButton);
                }
                
                return this.cachedPreviousMonthButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DisplayMonthTitle control
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TextBox DisplayMonthTitle
        {
            get
            {
                if ((this.cachedDisplayMonthTitle == null))
                {
                    this.cachedDisplayMonthTitle = new TextBox(this, MonthCalendar.QueryIds.DisplayMonthTitle);
                }
                
                return this.cachedDisplayMonthTitle;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextMonthButton control
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public Button NextMonthButton
        {
            get
            {
                if ((this.cachedNextMonthButton == null))
                {
                    this.cachedNextMonthButton = new Button(this, MonthCalendar.QueryIds.NextMonthButton);
                }
                
                return this.cachedNextMonthButton;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonthTitle control
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TextBox MonthTitle
        {
            get
            {
                if ((this.cachedMonthTitle == null))
                {
                    this.cachedMonthTitle = new TextBox(this, MonthCalendar.QueryIds.MonthTitle);
                }

                return this.cachedMonthTitle;
            }
        }
        
        #endregion

        #region Methods

        /// <summary>
        /// Returns the automation ID for a particular day of the month.
        /// Retrieving automation IDs for days prior to day 0 and after day 31 is allowed.
        /// </summary>
        /// <param name="dayIndex">Zero-based index of the day of the month.
        /// For example, to get day 1 of the month, pass index 0.</param>
        /// <returns>A automation id string.</returns>
        /// <exception cref="ArgumentException">Day must be between -7 and 40.</exception>
        public string GetCalendarDayAutomationID(int dayIndex)
        {
            if (dayIndex < -7 || dayIndex > 40)
            {
                throw new ArgumentException("day parameter must be between -7 and 40");
            }

            return String.Format(";[UIA]AutomationId=\'Day{0}\'", dayIndex);
        }

        /// <summary>
        /// Returns the automation ID for a particular week of the month.
        /// Retrieving automation IDs for weeks must be between 1 and 7.
        /// </summary>
        /// <param name="weekIndex">week index starts on 1 first week of the month.
        /// For example, to get week 1 of the month, pass index 1.</param>
        /// <returns>A automation id string.</returns>
        /// <exception cref="ArgumentException">Week must be between 1 and 7.</exception>
        public string GetCalendarWeekAutomationID(int weekIndex)
        {
            if (weekIndex < 1 || weekIndex > 7)
            {
                throw new ArgumentException("week parameter must be between 1 and 7");
            }

            return String.Format(";[UIA]AutomationId=\'Week{0}\'", weekIndex);
        }

        /// <summary>
        /// Set the Month Calendar title to month\year specified by the user.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool SetDate(DateTime time)
        {
            TextBox dayOfMonth = new TextBox(this);

            TextBox month = this.MonthTitle;

            string title = month.ScreenElement.Value;

            Button rightButton = this.NextMonthButton;
            Button leftButton = this.PreviousMonthButton;

            Regex regex = new Regex(@"[^a-z\d\s]*(\d?\d)(.)(\d\d\d\d)", RegexOptions.IgnoreCase);
            Match match = regex.Match(title);

            if (match.Groups.Count != 4)
            {
                Utilities.LogMessage("MonthCalendar.SetDate::The current title has not the right format");

                return false;
            }

            string substringTitleMonth = match.Groups[1].Value;
            string substringTitleYear = match.Groups[3].Value;

            //Convert the year substring from the calendar title to int
            int titleYear = Int32.Parse(substringTitleYear);

            //The same for the month substring
            int titleMonth = Int32.Parse(substringTitleMonth);

            int numClicks = 0;

            // Set the limit to a million
            int MAX_CLICKS = 1000000;

            while (time.Year != titleYear || time.Month != titleMonth)
            {

                if (time.Year > titleYear)
                {
                    // click the right arrow
                    rightButton.Click();
                }
                else if (time.Year < titleYear)
                {
                    // click the left arrow
                    leftButton.Click();
                }

                else if (time.Month > titleMonth)
                {
                    // click the right arrow
                    rightButton.Click();
                }
                else if (time.Month < titleMonth)
                {
                    // click the left arrow
                    leftButton.Click();
                }

                numClicks++;

                if (numClicks > MAX_CLICKS)
                {
                    throw new System.InvalidOperationException("The number of allowed clicks on this calendar cannot be exceeded");
                }

                title = month.ScreenElement.Value;
                regex = new Regex(@"[^a-z\d\s]*(\d?\d)(.)(\d\d\d\d)", RegexOptions.IgnoreCase);
                match = regex.Match(title);
                substringTitleYear = match.Groups[3].Value;
                titleYear = Int32.Parse(substringTitleYear);
                substringTitleMonth = match.Groups[1].Value;
                titleMonth = Int32.Parse(substringTitleMonth);
            }

            // Validate the selection
            title = month.ScreenElement.Value;
            regex = new Regex(@"[^a-z\d\s]*(\d?\d)(.)(\d\d\d\d)", RegexOptions.IgnoreCase);
            match = regex.Match(title);
            substringTitleYear = match.Groups[3].Value;
            titleYear = Int32.Parse(substringTitleYear);
            substringTitleMonth = match.Groups[1].Value;
            titleMonth = Int32.Parse(substringTitleMonth);

            if ( time.Month != titleMonth || time.Year != titleYear)
            {
                Utilities.LogMessage("MonthCalendar.SetDate::Not able to set the calendar to user's selection");

                return false;
            }

            month.Click();

            return true;
        }

        /// <summary>
        /// Set the MonthCalendar title to current month\year.
        /// The format of the title is: "month, year"
        /// </summary>
        public bool SetCurrentDate()
        {
            TextBox dayOfMonth = new TextBox(this);

            TextBox month = this.MonthTitle;

            string title = month.ScreenElement.Value;

            Button rightButton = this.NextMonthButton;
            Button leftButton = this.PreviousMonthButton;

            Regex regex = new Regex(@"[^a-z\d\s]*(\d?\d)(.)(\d\d\d\d)", RegexOptions.IgnoreCase);
            Match match = regex.Match(title);

            if (match.Groups.Count != 4)
            {
                Utilities.LogMessage("MonthCalendar.SetCurrentDate::The current title has not the right format");

                return false;
            }

            string substringTitleMonth = match.Groups[1].Value;
            string substringTitleYear = match.Groups[3].Value;

            //Convert the year substring from the calendar title to int
            int titleYear = Int32.Parse(substringTitleYear);

            //The same for the month substring
            int titleMonth = Int32.Parse(substringTitleMonth);

            DateTime currentDate = DateTime.Now;

            int numClicks = 0;

            // Set the limit to a million
            int MAX_CLICKS = 1000000;

            while (currentDate.Year != titleYear || currentDate.Month != titleMonth)
            {

                if (currentDate.Year > titleYear)
                {
                    // click the right arrow
                    rightButton.Click();
                }
                else if (currentDate.Year < titleYear)
                {
                    // click the left arrow
                    leftButton.Click();
                }

                else if (currentDate.Month > titleMonth)
                {
                    // click the right arrow
                    rightButton.Click();
                }
                else if (currentDate.Month < titleMonth)
                {
                    // click the left arrow
                    leftButton.Click();
                }

                numClicks++;

                if (numClicks > MAX_CLICKS)
                {
                    throw new System.InvalidOperationException("The number of allowed clicks on this calendar cannot be exceeded");
                }

                title = month.ScreenElement.Value;
                regex = new Regex(@"[^a-z\d\s]*(\d?\d)(.)(\d\d\d\d)", RegexOptions.IgnoreCase);
                match = regex.Match(title);
                substringTitleYear = match.Groups[3].Value;
                titleYear = Int32.Parse(substringTitleYear);
                substringTitleMonth = match.Groups[1].Value;
                titleMonth = Int32.Parse(substringTitleMonth);
                currentDate = DateTime.Now;
            }

            month.Click();

            return true;
        }

        #endregion

        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static class QueryIds
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for MinimumDateTextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string MinimumDateTextBoxQID = ";[UIA]AutomationId=\'TextBox\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for MinimumDateDropDown query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string MinimumDateDropDownQID = ";[UIA]AutomationId=\'DropDownButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SelectedDateTextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string SelectedDateTextBoxQID = ";[UIA]AutomationId=\'TextBox\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for SelectedDateDropDown query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string SelectedDateDropDownQID = ";[UIA]AutomationId=\'DropDownButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for MaximumDateTextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string MaximumDateTextBoxQID = ";[UIA]AutomationId=\'TextBox\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for MaximumDateDropDown query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string MaximumDateDropDownQID = ";[UIA]AutomationId=\'DropDownButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for MonthCalendarTextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string MonthCalendarTextBoxQID = ";[UIA]AutomationId=\'CalendarGrid\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for PreviousMonthButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string PreviousMonthButtonQID = ";[UIA]AutomationId=\'PreviousMonth\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for DisplayMonthTitle query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string DisplayMonthTitleQID = ";[UIA]AutomationId=\'Title\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for NextMonthButton query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string NextMonthButtonQID = ";[UIA]AutomationId=\'NextMonth\'";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for MonthTitle query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string MonthTitleQID = ";[UIA]AutomationId=\'MonthTitle\'";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedMinimumDateTextBox;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedMinimumDateDropDown;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedSelectedDateTextBox;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedSelectedDateDropDown;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedMaximumDateTextBox;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedMaximumDateDropDown;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedMonthCalendarTextBox;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedPreviousMonthButton;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedDisplayMonthTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedNextMonthButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedMonthTitle;
            #endregion
            
            #region Properties
                             
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MinimumDateTextBox translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/24/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID MinimumDateTextBox
            {
                get
                {
                    if ((cachedMinimumDateTextBox == null))
                    {
                        cachedMinimumDateTextBox = new QID(MinimumDateTextBoxQID);
                    }
                    
                    return cachedMinimumDateTextBox;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MinimumDateDropDown translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/24/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID MinimumDateDropDown
            {
                get
                {
                    if ((cachedMinimumDateDropDown == null))
                    {
                        cachedMinimumDateDropDown = new QID(MinimumDateDropDownQID);
                    }
                    
                    return cachedMinimumDateDropDown;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectedDateTextBox translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/24/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SelectedDateTextBox
            {
                get
                {
                    if ((cachedSelectedDateTextBox == null))
                    {
                        cachedSelectedDateTextBox = new QID(SelectedDateTextBoxQID);
                    }
                    
                    return cachedSelectedDateTextBox;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectedDateDropDown translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/24/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID SelectedDateDropDown
            {
                get
                {
                    if ((cachedSelectedDateDropDown == null))
                    {
                        cachedSelectedDateDropDown = new QID(SelectedDateDropDownQID);
                    }
                    
                    return cachedSelectedDateDropDown;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MaximumDateTextBox translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/24/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID MaximumDateTextBox
            {
                get
                {
                    if ((cachedMaximumDateTextBox == null))
                    {
                        cachedMaximumDateTextBox = new QID(MaximumDateTextBoxQID);
                    }
                    
                    return cachedMaximumDateTextBox;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MaximumDateDropDown translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/24/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID MaximumDateDropDown
            {
                get
                {
                    if ((cachedMaximumDateDropDown == null))
                    {
                        cachedMaximumDateDropDown = new QID(MaximumDateDropDownQID);
                    }
                    
                    return cachedMaximumDateDropDown;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MonthCalendarTextBox translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/24/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID MonthCalendarTextBox
            {
                get
                {
                    if ((cachedMonthCalendarTextBox == null))
                    {
                        cachedMonthCalendarTextBox = new QID(MonthCalendarTextBoxQID);
                    }
                    
                    return cachedMonthCalendarTextBox;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PreviousMonthButton translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/24/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID PreviousMonthButton
            {
                get
                {
                    if ((cachedPreviousMonthButton == null))
                    {
                        cachedPreviousMonthButton = new QID(PreviousMonthButtonQID);
                    }
                    
                    return cachedPreviousMonthButton;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DisplayMonthTitle translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/24/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID DisplayMonthTitle
            {
                get
                {
                    if ((cachedDisplayMonthTitle == null))
                    {
                        cachedDisplayMonthTitle = new QID(DisplayMonthTitleQID);
                    }
                    
                    return cachedDisplayMonthTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NextMonthButton translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/24/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID NextMonthButton
            {
                get
                {
                    if ((cachedNextMonthButton == null))
                    {
                        cachedNextMonthButton = new QID(NextMonthButtonQID);
                    }
                    
                    return cachedNextMonthButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MonthTitle translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 2/24/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID MonthTitle
            {
                get
                {
                    if ((cachedMonthTitle == null))
                    {
                        cachedMonthTitle = new QID(MonthTitleQID);
                    }

                    return cachedMonthTitle;
                }
            }
            #endregion
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <history>
        ///   [v-madrid] 2/24/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static class Strings
        {
            /// <summary>
            /// string for Minimum Date
            /// </summary>
            public const string MinimumDateTextBox = "Minimum Date";
            
            /// <summary>
            /// string for Selected Date
            /// </summary>
            public const string SelectedDateTextBox = "Selected Date";

            /// <summary>
            /// string for Maximum date
            /// </summary>
            public const string MaximumDateTextBox = "Maximum Date";


        }
        #endregion
    }
}
