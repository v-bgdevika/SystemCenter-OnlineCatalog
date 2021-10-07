namespace Mom.Test.UI.Core.Console.MomControls.DashboardControls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Automation;
    //using Dump;
    using Maui.Core;
    using Maui.Core.WinControls;
    using MomCommon = Mom.Test.UI.Core.Common;
    /// <summary>
    /// This interface lists the controls that are in the view that can contain a chart
    /// </summary>
    public interface IChartHostControlViewHostControls
    {
        /// <summary>
        /// The units used in a chart
        /// </summary>
        StaticControl Units
        {
            get;
        }

        /// <summary>
        /// The duration for the chart
        /// </summary>
        StaticControl Duration
        {
            get;
        }
    }

    /// <summary>
    /// This class represents the view that has a chart as the content
    /// </summary>
    public class ChartHostControlViewHost : ViewHost, IChartHostControlViewHostControls
    {
        #region QIDs

        /// <summary>
        /// The default QIDs for the controls in the view
        /// </summary>
        new class ControlQIDs
        {
            /// <summary>
            /// QID for the content
            /// </summary>
            public static QID ContentQID = new QID(";[UIA]ClassName = 'ChartHostControl'");

            /// <summary>
            /// QID for the Units
            /// </summary>
            public static QID UnitsQID = new QID(";[UIA]ClassName = 'TextBlock' && Instance = '1'");

            /// <summary>
            /// QID for the Duration
            /// </summary>
            public static QID DurationQID = new QID(";[UIA]ClassName = 'TextBlock' && Instance = '2'");
        }

        /// <summary>
        /// Gets the default QID for the Units control in the view
        /// </summary>
        /// <returns>QID for the units</returns>
        protected virtual QID GetUnitsQID()
        {
            return ControlQIDs.UnitsQID;
        }

        /// <summary>
        /// Gets the default QID for the Duration control in the view
        /// </summary>
        /// <returns>QID for the duration</returns>
        protected virtual QID GetDurationQID()
        {
            return ControlQIDs.DurationQID;
        }

        /// <summary>
        /// Gets the default QID for the Content in the view
        /// </summary>
        /// <returns>QID for the content</returns>
        protected override QID GetContentQID()
        {
            return ControlQIDs.ContentQID;
        }

        #endregion

        #region protected variables

        /// <summary>
        /// The Units control
        /// </summary>
        protected StaticControl units;

        /// <summary>
        /// The duration control
        /// </summary>
        protected StaticControl duration;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ChartHostControlViewHost class
        /// </summary>
        /// <param name="knownWindow">Window that is the ChartHostControlViewHost</param>
        public ChartHostControlViewHost(Window knownWindow)
            : base(knownWindow)
        {
        }

        #endregion

        #region IChartHostControlViewHostControls Members

        /// <summary>
        /// The Units control
        /// </summary>
        public StaticControl Units
        {
            get
            {
                if (this.units == null)
                {
                    this.units = new StaticControl(this.Content, this.GetUnitsQID());
                }

                return this.units;
            }
        }

        /// <summary>
        /// The Duration Control
        /// </summary>
        public StaticControl Duration
        {
            get
            {
                if (this.duration == null)
                {
                    this.duration = new StaticControl(this.Content, this.GetDurationQID());
                }

                return this.duration;
            }
        }

        #endregion
    }
}