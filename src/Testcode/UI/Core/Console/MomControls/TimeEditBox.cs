// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TimeEditBox.cs">
//   Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
//   System Center Console Framework
// </project>
// <summary>
//   Date & Time \ Time Edit Box
// </summary>
// <history>
//   [v-madrid] 3/3/2009 Created
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
    /// Interface definition, ITimeEditBoxControls, for TimeEditBox.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-madrid] 3/3/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITimeEditBoxControls
    {
        /// <summary>
        /// Read-only property to access TimeEditorSpinner
        /// </summary>
        TextBox TimeEditorSpinner
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Hour 
        /// </summary>
        TextBox Hour
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Minute
        /// </summary>
        TextBox Minute
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Meridian
        /// </summary>
        TextBox Ampm
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Up button
        /// </summary>
        Button Up
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Down button
        /// </summary>
        Button Down
        {
            get;
        }

    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add app.window functionality description here.
    /// </summary>
    /// <history>
    ///   [v-madrid] 3/3/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class TimeEditBox : Control, ITimeEditBoxControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
      
        #region Private Member Variables
        
        /// <summary>
        /// Cache to hold a reference to TimeEditorSpinner of type Spinner
        /// </summary>
        private TextBox cachedTimeEditorSpinner;
        
        /// <summary>
        /// Cache to hold a reference to Hour of type TextBox
        /// </summary>
        private TextBox cachedHour;
        
        /// <summary>
        /// Cache to hold a reference to Minute of type TextBox
        /// </summary>
        private TextBox cachedMinute;
        
        /// <summary>
        /// Cache to hold a reference to Meridian Ampm of type TextBox
        /// </summary>
        private TextBox cachedAmpm;
        
        /// <summary>
        /// Cache to hold a reference to Up of type Button
        /// </summary>
        private Button cachedUp;
        
        /// <summary>
        /// Cache to hold a reference to Down of type Button
        /// </summary>
        private Button cachedDown;
       
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TimeEditBox
        /// </summary>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        ///   [v-madrid] 3/3/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TimeEditBox(Window timeEditBox) :
            base(timeEditBox)
        {
        }

        /// <summary>
        /// TimeEditBox
        /// </summary>
        /// <param name="parent">Parent Window</param>
        /// <param name="queryId">Query ID</param>
        public TimeEditBox(Window parent, QID queryId) :
            base(parent, queryId)
        {
        }

        /// <summary>
        /// TimeEditBox
        /// </summary>
        /// <param name="parent">Parent Window</param>
        /// <param name="queryId">Query ID</param>
        /// <param name="timeout">Timeout in milliseconds</param>
        public TimeEditBox(Window parent, QID queryId, int timeout) :
            base(parent, queryId, timeout)
        {
        }

        #endregion
      
        #region ITimeEditBox Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this app.window
        /// </summary>
        /// <value>An interface that groups all of the app.window's control properties together</value>
        /// <history>
        ///   [v-madrid] 3/3/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITimeEditBoxControls Controls
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
        ///  Routine to set/get the text in control Hour
        /// </summary>
        /// <history>
        ///   [v-madrid] 3/3/2009 Created
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
        ///   [v-madrid] 3/3/2009 Created
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
        ///   [v-madrid] 3/3/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AmPmText
        {
            get
            {
                return this.Controls.Ampm.Text;
            }
            set
            {
                this.Controls.Ampm.Text = value;
            }

        }
       
        #endregion
        
        #region Control Properties
      
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TimeEditorSpinner control
        /// </summary>
        /// <history>
        ///   [v-madrid] 3/3/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TextBox TimeEditorSpinner
        {
            get
            {
                if ((this.cachedTimeEditorSpinner == null))
                {
                    this.cachedTimeEditorSpinner = new TextBox(this, TimeEditBox.QueryIds.TimeEditorSpinner);
                }
                
                return this.cachedTimeEditorSpinner;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Hour control
        /// </summary>
        /// <history>
        ///   [v-madrid] 3/3/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TextBox Hour
        {
            get
            {
                if ((this.cachedHour == null))
                {
                    this.cachedHour = new TextBox(this, TimeEditBox.QueryIds.Hour);
                }

                return this.cachedHour;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Minute control
        /// </summary>
        /// <history>
        ///   [v-madrid] 3/3/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TextBox Minute
        {
            get
            {
                if ((this.cachedMinute == null))
                {
                    this.cachedMinute = new TextBox(this, TimeEditBox.QueryIds.Minute);
                }
                
                return this.cachedMinute;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Meridian Ampm control
        /// </summary>
        /// <history>
        ///   [v-madrid] 3/3/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TextBox Ampm
        {
            get
            {
                if ((this.cachedAmpm == null))
                {
                    this.cachedAmpm = new TextBox(this, TimeEditBox.QueryIds.Ampm);
                }
                
                return this.cachedAmpm;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Up button control
        /// </summary>
        /// <history>
        ///   [v-madrid] 3/3/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public Button Up
        {
            get
            {
                if ((this.cachedUp == null))
                {
                    this.cachedUp = new Button(this, TimeEditBox.QueryIds.Up);
                }

                return this.cachedUp;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Down button control
        /// </summary>
        /// <history>
        ///   [v-madrid] 3/3/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public Button Down
        {
            get
            {
                if ((this.cachedDown == null))
                {
                    this.cachedDown = new Button(this, TimeEditBox.QueryIds.Down);
                }

                return this.cachedDown;
            }
        }
       
        #endregion

        #region Methods

        /// <summary>
        /// Set the hour 
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public bool SetHour(int hour)
        {
            TextBox setHour = new TextBox(this);

            // Validate the parameter
            if (hour < 0 || hour > 23)
            {
                throw new System.InvalidOperationException("TimeEditBox::The hour input is not valid");
            }
                        
            Button up = this.Up;
            Button down = this.Down;

            up.Click();

            // Set the hour 
            TextBox hourEditor = this.Hour;
            
            string hourSelected = hourEditor.ScreenElement.Value;

            int convertedHourSelected = Int32.Parse(hourSelected);

            if (hour == 0)
            {
                hour = 12;
            }
            else if (hour > 12)
            {
                hour = hour % 12;
            }

            int numClicks = 0;

            // Set the limit to a million
            int MAX_CLICKS = 1000000;

            while (hour != convertedHourSelected)
            {
                if (hour > convertedHourSelected)
                {
                    up.Click();
                }
                else
                {
                    down.Click();
                }

                numClicks++;

                if (numClicks > MAX_CLICKS)
                {
                    throw new System.InvalidOperationException("The number of allowed clicks on the time box cannot be exceeded");
                }

                hourSelected = hourEditor.ScreenElement.Value;
                convertedHourSelected = Int32.Parse(hourSelected);
            }

            // Validate the time conversion to selected hour
            hourSelected = hourEditor.ScreenElement.Value;
            convertedHourSelected = Int32.Parse(hourSelected);

            if (convertedHourSelected != hour)
            {
                Utilities.LogMessage("SetHour::Not able to convert the hour to user's selection");

                return false;
            }

            return true;
        }

        /// <summary>
        /// Set the minutes
        /// </summary>
        /// <param name="minute"></param>
        /// <returns></returns>
        public bool SetMinute(int minute)
        {
            TextBox setTime = new TextBox(this);

            // Validate the parameter
            if (minute < 0 || minute > 59)
            {
                throw new System.InvalidOperationException("TimeEditBox::The minute input is not valid");
            }

            Button up = this.Up;
            Button down = this.Down;

            up.Click();

            TextBox minuteEditor = this.Minute;

            minuteEditor.Click();

            string minuteSelected = minuteEditor.ScreenElement.Value;

            int convertedMinSelected = Int32.Parse(minuteSelected);

            int numClicks = 0;

            // Set the limit to a million
            int MAX_CLICKS = 1000000;

            while (minute != convertedMinSelected)
            {
                if (minute > convertedMinSelected)
                {
                    up.Click();
                }
                else
                {
                    down.Click();
                }

                numClicks++;

                if (numClicks > MAX_CLICKS)
                {
                    throw new System.InvalidOperationException("The number of allowed clicks on the time box cannot be exceeded");
                }

                minuteSelected = minuteEditor.ScreenElement.Value;
                convertedMinSelected = Int32.Parse(minuteSelected);
            }

            // Validate the time conversion to selected minute
            minuteSelected = minuteEditor.ScreenElement.Value;
            convertedMinSelected = Int32.Parse(minuteSelected);

            if (convertedMinSelected != minute)
            {
                Utilities.LogMessage("SetMinute::Not able to convert the minutes to user's selection");

                return false;
            }

            return true;
        }

        /// <summary>
        /// Set the meridian
        /// </summary>
        /// <param name="meridian"></param>
        /// <returns></returns>
        public bool SetMeridian(string meridian)
        {
            TextBox setTime = new TextBox(this);

            // Validate the parameter
            if ((String.Compare(meridian, "AM", true) != 0) || (String.Compare(meridian, "PM", true) != 0))
            {
                throw new System.InvalidOperationException("TimeEditBox::The meridian input is not valid");
            }

            Button up = this.Up;
            Button down = this.Down;

            up.Click();

            TextBox meridianEditor = this.Ampm;

            meridianEditor.Click();

            string meridianString = meridianEditor.ScreenElement.Value;

            meridianEditor.ScreenElement.SendKeys(meridian);

            // Validate the meridian is converted to the user's input

            meridianString = meridianEditor.ScreenElement.Value;

            if (String.Compare(meridianString, meridian, true) != 0)
            {
                Utilities.LogMessage("SetMeridian::Not able to convert the meridian according to user's selection");

                return false;
            }

            return true;
        }

        /// <summary>
        /// Call the SetHour, SetMinute and SetMeridian to set the time
        /// </summary>
        /// <param name="time"></param>
        public bool SetTime(DateTime time)
        {
            TextBox setTime = new TextBox(this);

            bool isHourSet = false;
            isHourSet = SetHour(time.Hour);

            bool isMinuteSet = false;
            isMinuteSet = SetMinute(time.Minute);

            bool isMeridianSet = false;
            
            TimeSpan timeSpan = time.TimeOfDay;
            TimeSpan twelveHourSpan = new TimeSpan(12, 0, 0);

            if (timeSpan.Hours > twelveHourSpan.Hours)
            {
                isMeridianSet = SetMeridian("PM");
            }
            else
            {
                isMeridianSet = SetMeridian("AM");
            }

            if (isHourSet == false || isMinuteSet == false || isMeridianSet == false)
            {
                Utilities.LogMessage("TimeEditBox.SetTime::Unable to set the requested time");

                return false;
            }

            return true;
        }
      
        #endregion

        
        #region Query ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all query ID's.
        /// </summary>
        /// <history>
        ///   [v-madrid] 3/3/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static class QueryIds
        {
            #region Constants
           
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for TimeEditorSpinner query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTimeEditorSpinner = ";[UIA]AutomationId=\'timeEditBox\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ThisIsAViewFromAnotherWunderbarSpaceTextBox query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHour = ";[UIA]AutomationId=\'Hour\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ThisIsAViewFromAnotherWunderbarSpaceTextBox2 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMinute = ";[UIA]AutomationId=\'Minute\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for ThisIsAViewFromAnotherWunderbarSpaceTextBox3 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAmpm = ";[UIA]AutomationId=\'Ampm\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Button24 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUp = ";[UIA]AutomationId=\'UpButton\'";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for Button25 query id
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDown = ";[UIA]AutomationId=\'DownButton\'";
                       
            #endregion
            
            #region Private Members
           
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedTimeEditorSpinner;
            
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
            private static QID cachedAmpm;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedUp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the QID for the control
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static QID cachedDown;
                    
            #endregion
            
            #region Properties
         
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TimeEditorSpinner translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 3/3/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID TimeEditorSpinner
            {
                get
                {
                    if ((cachedTimeEditorSpinner == null))
                    {
                        cachedTimeEditorSpinner = new QID(ResourceTimeEditorSpinner);
                    }
                    
                    return cachedTimeEditorSpinner;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HourTextBox translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 3/3/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID Hour
            {
                get
                {
                    if ((cachedHour == null))
                    {
                        cachedHour = new QID(ResourceHour);
                    }
                    
                    return cachedHour;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MinuteTextBox translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 3/3/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID Minute
            {
                get
                {
                    if ((cachedMinute == null))
                    {
                        cachedMinute = new QID(ResourceMinute);
                    }
                    
                    return cachedMinute;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AmpmTextBox translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 3/3/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID Ampm
            {
                get
                {
                    if ((cachedAmpm == null))
                    {
                        cachedAmpm = new QID(ResourceAmpm);
                    }
                    
                    return cachedAmpm;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UpButton translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 3/3/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID Up
            {
                get
                {
                    if ((cachedUp == null))
                    {
                        cachedUp = new QID(ResourceUp);
                    }
                    
                    return cachedUp;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DownButton translated resource qid string
            /// </summary>
            /// <history>
            ///   [v-madrid] 3/3/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static QID Down
            {
                get
                {
                    if ((cachedDown == null))
                    {
                        cachedDown = new QID(ResourceDown);
                    }
                    
                    return cachedDown;
                }
            }
            
            #endregion
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <history>
        ///   [v-madrid] 3/3/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public static class Strings
        {
            /// <summary>
            /// Resource string for Time Edit Box
            /// </summary>
            public const string TimeEditBox = "Time Edit Box";
            
            /// <summary>
            /// Resource string for Read Only
            /// </summary>
            public const string ReadOnly2 = "Read Only";
            
            /// <summary>
            /// Resource string for Selected Time Changed
            /// </summary>
            public const string SelectedTimeChanged = "Selected Time Changed";
            
            /// <summary>
            /// Resource string for Add Selected Time Changed Event Handler
            /// </summary>
            public const string AddSelectedTimeChangedEventHandler = "Add Selected Time Changed Event Handler";
        }
        #endregion
    }
}
