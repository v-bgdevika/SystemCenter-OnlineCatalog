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
    /// This interface lists the controls that are in a view that has a chart and legend as the content
    /// </summary>
    public interface IChartWithLegendViewHostControls
    {
        /// <summary>
        /// The chart control
        /// </summary>
        Window Chart
        {
            get;
        }

        /// <summary>
        /// The Legend control
        /// </summary>
        DataGridControl Legend
        {
            get;
        }
    }

    /// <summary>
    /// This class represents a view that has a chart and a legend as the content
    /// </summary>
    public class ChartWithLegendViewHost : ChartHostControlViewHost, IChartWithLegendViewHostControls
    {
        #region QIDs
        /// <summary>
        /// This is a list of default QIDs for the controls on the view
        /// </summary>
        new public class ControlQIDs
        {
            /// <summary>
            /// QID for the content
            /// </summary>
            public static QID ContentQID = new QID(";[UIA]ClassName = 'ComponentContainer'");

            /// <summary>
            /// QID for the chart
            /// </summary>
            public static QID ChartQID = new QID(";[UIA]ClassName = 'ComponentContainer';[UIA]ClassName = 'ChartHostControl';[UIA]ClassName = 'Chart'");

            /// <summary>
            /// QID for the Units control
            /// </summary>
            public static QID UnitsQID = new QID(";[UIA]ClassName = 'ComponentContainer';[UIA]ClassName = 'ChartHostControl';[UIA]ClassName = 'TextBlock' && Instance = '1'");

            /// <summary>
            /// QID for the Duration control
            /// </summary>
            public static QID DurationQID = new QID(";[UIA]ClassName = 'ComponentContainer';[UIA]ClassName = 'ChartHostControl';[UIA]ClassName = 'TextBlock' && Instance = '2'");

            /// <summary>
            /// QID for the Legend data grid
            /// </summary>
            public static QID LegendQID = new QID(";[UIA]ClassName = 'ComponentContainer';[UIA]AutomationId = 'SCOMDataGrid';[UIA]AutomationId = 'InnerDataGrid'");
        }

        /// <summary>
        /// Gets the QID for the content
        /// </summary>
        /// <returns>QID for the content</returns>
        protected override QID GetContentQID()
        {
            return ControlQIDs.ContentQID;
        }

        /// <summary>
        /// Gets the QID for the chart
        /// </summary>
        /// <returns>QID for the chart</returns>
        protected virtual QID GetChartQID()
        {
            return ControlQIDs.ChartQID;
        }

        /// <summary>
        /// Gets the QID for the duration
        /// </summary>
        /// <returns>QID for the duration</returns>
        protected override QID GetDurationQID()
        {
            return ControlQIDs.DurationQID;
        }

        /// <summary>
        /// Gets the QID for the units
        /// </summary>
        /// <returns>QID for the units</returns>
        protected override QID GetUnitsQID()
        {
            return ControlQIDs.UnitsQID;
        }

        /// <summary>
        /// Gets the QID for the legend
        /// </summary>
        /// <returns>QID for the legend</returns>
        protected virtual QID GetLegendQID()
        {
            return ControlQIDs.LegendQID;
        }

        #endregion

        #region protected variables

        /// <summary>
        /// The chart control
        /// </summary>
        protected Window chart;

        /// <summary>
        /// The legend data grid
        /// </summary>
        protected DataGridControl legend;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ChartWithLegendViewHost class
        /// </summary>
        /// <param name="knownWindow">Window that is the ChartWithLegendViewHost</param>
        public ChartWithLegendViewHost(Window knownWindow)
            : base(knownWindow)
        {
        }

        #endregion

        #region IChartWithLegendViewHostControls Members

        /// <summary>
        /// The chart on the view
        /// </summary>
        public Window Chart
        {
            get
            {
                if (this.chart == null)
                {
                    this.chart = new Window(this.Content,
                        this.GetChartQID(),
                        MomCommon.Constants.OneMinute);
                }

                return this.chart;
            }
        }

        /// <summary>
        /// The legend for the chart
        /// </summary>
        public DataGridControl Legend
        {
            get
            {
                if (this.legend == null)
                {
                    this.legend = new DataGridControl(this.Content, this.GetLegendQID());
                }

                return this.legend;
            }
        }

        #endregion
    }
}