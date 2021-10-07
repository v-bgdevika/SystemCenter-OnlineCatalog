//-----------------------------------------------------------------------------
// <copyright file="ScheduleData.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains a class for exposing Notification schedule support functionality.
// </summary>
// 
//  <history>
//  [KellyMor]  04-AUG-08   Created
//  [KellyMor]  30-SEP-08   Added fields for inclusive start/stop time range.
//                          Set days of the week array to all false values to
//                          match default state of the schedule dialog days.
//  </history>
//-----------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscribers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class to contain schedule data for subscribers and subscriber addresses
    /// aka notification devices.
    /// </summary>
    public class ScheduleData
    {
        #region Private Members

        /// <summary>
        /// Flag indicating if the date/time range of this schedule instance is
        /// for all date ranges.
        /// </summary>
        private bool always = true;

        /// <summary>
        /// The start date/time for this schedule instance.
        /// </summary>
        private DateTime startDate;

        /// <summary>
        /// The stop date/time for this schedule instance. 
        /// </summary>
        private DateTime stopDate;

        /// <summary>
        /// Flag indicating if the time range of this schedule instance is
        /// for all time ranges, e.g. all day (24 hours).
        /// </summary>
        private bool allDay = true;

        /// <summary>
        /// The start time for this schedule instance.
        /// </summary>
        private DateTime startTime;

        /// <summary>
        /// The stop time for this schedule instance. 
        /// </summary>
        private DateTime stopTime;

        /// <summary>
        /// Flag indicating if a time range should be excluded.
        /// </summary>
        private bool excludeTimes = false;

        /// <summary>
        /// The exclude start time for this schedule instance.  
        /// If this member is set then the always flag must be set to false.
        /// </summary>
        private DateTime excludeStartTime;

        /// <summary>
        /// The exclude stop time for this schedule instance.  
        /// If this member is set then the always flag must be set to false.
        /// </summary>
        private DateTime excludeStopTime;

        /// <summary>
        /// Array of flags indicating which days of the week are selected.
        /// </summary>
        private bool[] eachDayOfTheWeek = 
            { false, false, false, false, false, false, false };

        /// <summary>
        /// The timezone used for the schedule instance.
        /// </summary>
        private TimeZone timeZone = System.TimeZone.CurrentTimeZone;

        #endregion Private Members

        #region Public Constructors

        /// <summary>
        /// Default constructor.  Creates a schedule data instance whose
        /// date range is all dates (always) and time range is all times
        /// (all day - 24 hours) and timezone is the timezone of the local
        /// computer.
        /// </summary>
        public ScheduleData()
        {
        }

        /// <summary>
        /// Constructor that takes a start and stop date.
        /// </summary>
        /// <param name="always">
        /// Flag indicating if the date/time range of this schedule instance is
        /// for all date ranges.
        /// </param>
        /// <param name="startDate">
        /// Start date for the date range.
        /// </param>
        /// <param name="stopDate">
        /// Stop date for the date range.
        /// </param>
        /// <param name="allDay">
        /// Flag indicating if the time range of this schedule instance is
        /// for all time ranges, e.g. all day (24 hours).
        /// </param>
        /// <param name="startTime">
        /// The inclusive start time for this schedule instance.
        /// </param>
        /// <param name="stopTime">
        /// The inclusive stop time for this schedule instance.  
        /// </param>
        /// <param name="excludeTimes">
        ///  Flag indicating if a time range should be excluded.
        /// </param>
        /// <param name="excludeStartTime">
        /// The exclude start time for this schedule instance.  
        /// If this member is set then the always flag must be set to false.
        /// </param>
        /// <param name="excludeStopTime">
        /// The exclude stop time for this schedule instance.  
        /// If this member is set then the always flag must be set to false.
        /// </param>
        /// <param name="daysOfTheWeek">
        /// Array of flags indicating which days of the week are selected.
        /// </param>
        /// <param name="timeZone">
        /// The timezone used for the schedule instance.
        /// </param>
        public ScheduleData(
            bool always,
            DateTime startDate, 
            DateTime stopDate,
            bool allDay,
            DateTime startTime,
            DateTime stopTime,
            bool excludeTimes,
            DateTime excludeStartTime,
            DateTime excludeStopTime,
            bool[] daysOfTheWeek,
            TimeZone timeZone)
        {
            // if start and stop dates are set
            if (null != startDate && null != stopDate)
            {
                // check that start date is before stop date
                if (startDate > stopDate)
                {
                    throw new System.ArgumentException(
                        "The start date cannot be after the stop date!");
                }
            }

            // if start and stop times are set
            if (null != startTime && null != stopTime)
            {
                // check that start time is before stop time
                if (startTime > stopTime)
                {
                    throw new System.ArgumentException(
                        "The start time cannot be after the stop time!");
                }
            }

            // if the exclude times are set
            if (null != excludeStartTime && null != excludeStopTime) 
            {
                // check that exclude start time is before the exclude stop time
                if (excludeStartTime > excludeStopTime)
                {
                    throw new System.ArgumentException(
                        "The exclude start time cannot be after the exclude stop time!");
                }
            }

            // set the values
            this.always = always;
            this.startDate = startDate;
            this.stopDate = stopDate;
            this.allDay = allDay;
            this.startTime = startTime;
            this.stopTime = stopTime;
            this.excludeTimes = excludeTimes;
            this.excludeStartTime = excludeStartTime;
            this.excludeStopTime = excludeStopTime;

            // if the days of the week array is not null
            if (null != daysOfTheWeek)
            {
                // use it instead of the default values
                this.eachDayOfTheWeek = daysOfTheWeek;
            }

            // if the timezone is not null
            if (null != timeZone)
            {
                // use it instead of the default value
                this.timeZone = timeZone;
            }
        }

        #endregion Public Constructors

        #region Public Enums

        /// <summary>
        /// The days of the week as numeric values.
        /// </summary>
        public enum DaysOfTheWeek
        {
            /// <summary>
            /// Sunday
            /// </summary>
            Sunday = 0,

            /// <summary>
            /// Monday
            /// </summary>
            Monday,
            
            /// <summary>
            /// Tuesday
            /// </summary>
            Tuesday,
            
            /// <summary>
            /// Wednesday
            /// </summary>
            Wednesday,
            
            /// <summary>
            /// Thursday
            /// </summary>
            Thursday,
            
            /// <summary>
            /// Friday
            /// </summary>
            Friday,

            /// <summary>
            /// Saturday
            /// </summary>
            Saturday
        }

        #endregion Public Enums

        #region Public Properties

        /// <summary>
        /// Flag indicating if the date/time range of this schedule instance is
        /// for all date ranges.  The default value is set to true.
        /// </summary>
        public bool Always
        {
            get 
            { 
                return this.always; 
            }

            set 
            { 
                this.always = value; 
            }
        }

        /// <summary>
        /// The start date/time for this schedule instance.
        /// </summary>
        public DateTime StartDate
        {
            get 
            {
                return this.startDate;
            }

            set 
            {
                this.startDate = value;
            }
        }

        /// <summary>
        /// The stop date/time for this schedule instance.
        /// </summary>
        public DateTime StopDate
        {
            get 
            {
                return this.stopDate;
            }

            set 
            {
                this.stopDate = value;
            }
        }

        /// <summary>
        /// Flag indicating if the time range of this schedule instance is
        /// for all time ranges, e.g. all day (24 hours).  The default value
        /// is set to true.
        /// </summary>
        public bool AllDay
        {
            get 
            {
                return this.allDay;
            }

            set 
            {
                this.allDay = value;
            }
        }

        /// <summary>
        /// The start time for this schedule instance.
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                return this.startTime;
            }

            set
            {
                this.startTime = value;
            }
        }

        /// <summary>
        /// The stop time for this schedule instance.
        /// </summary>
        public DateTime StopTime
        {
            get
            {
                return this.stopTime;
            }

            set
            {
                this.stopTime = value;
            }
        }

        /// <summary>
        /// Flag indicating if a time range should be excluded.  The default
        /// value is set to false.
        /// </summary>
        public bool ExcludeTimes
        {
            get 
            {
                return this.excludeTimes;
            }

            set 
            {
                this.excludeTimes = value;
            }
        }

        /// <summary>
        /// The exclude start time for this schedule instance.  
        /// If this member is set then the always flag must be set to false.
        /// </summary>
        public DateTime ExcludeStartTime
        {
            get 
            {
                return this.excludeStartTime;
            }

            set 
            {
                this.excludeStartTime = value;
            }
        }

        /// <summary>
        /// The exclude stop time for this schedule instance.  
        /// If this member is set then the always flag must be set to false.
        /// </summary>
        public DateTime ExcludeStopTime
        {
            get 
            {
                return this.excludeStopTime;
            }

            set 
            {
                this.excludeStopTime = value;
            }
        }

        /// <summary>
        /// Array of flags indicating which days of the week are selected.  The
        /// default value is for Monday-Friday set to true and Saturday and
        /// Sunday set to false.
        /// </summary>
        public bool[] EachDayOfTheWeek
        {
            get 
            {
                return this.eachDayOfTheWeek;
            }

            set 
            {
                this.eachDayOfTheWeek = value;
            }
        }

        /// <summary>
        /// The timezone used for the schedule instance.  The default value is
        /// the timezone on the local computer.
        /// </summary>
        public TimeZone TimeZone
        {
            get 
            {
                return this.timeZone;
            }

            set 
            {
                this.timeZone = value;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Clears all the days of the week.
        /// </summary>
        public void ClearAllDaysOfTheWeek()
        {
            for (int index = 0; index < this.eachDayOfTheWeek.Length; index++)
            {
                this.eachDayOfTheWeek[index] = false;
            }
        }

        /// <summary>
        /// Sets the specified day of the week in the list of valid days.
        /// </summary>
        /// <param name="specifiedDay">
        /// The specified day of the week.
        /// </param>
        public void SetDayOfTheWeek(DaysOfTheWeek specifiedDay)
        {
            // check for valid range
            if (DaysOfTheWeek.Sunday <= specifiedDay &&
                DaysOfTheWeek.Saturday >= specifiedDay)
            {
                this.eachDayOfTheWeek[(int)specifiedDay] = true;
            }
            else
            {
                throw new System.ArgumentOutOfRangeException(
                    "Parameter must be greater than or equal to " +
                    DaysOfTheWeek.Sunday.ToString() +
                    " and less than or equal to " +
                    DaysOfTheWeek.Saturday.ToString());
            }
        }

        /// <summary>
        /// Clears the specified day of the week in the list of valid days.
        /// </summary>
        /// <param name="specifiedDay">
        /// The specified day of the week.
        /// </param>
        public void ClearDayOfTheWeek(DaysOfTheWeek specifiedDay)
        {
            // check for valid range
            if (DaysOfTheWeek.Sunday <= specifiedDay &&
                DaysOfTheWeek.Saturday >= specifiedDay)
            {
                this.eachDayOfTheWeek[(int)specifiedDay] = false;
            }
            else
            {
                throw new System.ArgumentOutOfRangeException(
                    "Parameter must be greater than or equal to " +
                    DaysOfTheWeek.Sunday.ToString() +
                    " and less than or equal to " +
                    DaysOfTheWeek.Saturday.ToString());
            }
        }

        #endregion Public Methods
    }
}
