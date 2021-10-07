// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WhereToMonitorFromDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	SCOM UI Test
// </project>
// <summary>
// 	This class wraps Summary Tab.
// </summary>
// <history>
// 	[v-bire] 3/14/2011 Created
// </history>
// -----------------------------------------------------------------------------------------



namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs
{
    using System;
    using System.Reflection;
    using Maui.Core.WinControls;
    using Mom.Test.UI.Core.Common;

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// This class wraps Summary tab. This tab contains the summary info of the test results. Such as URL Tested, location, Status Code and so on...
    /// </summary>
    /// <history>
    /// 	[v-bire] 3/14/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class TestResultsSummaryTab
    {
        #region Private Member Variables

        private TabControlTab tab;

        #endregion

        #region Properties

        public TabControlTab Tab
        {
            get
            {
                return this.tab;
            }
        }
        #endregion

        #region Constructor

        public TestResultsSummaryTab(TabControlTab tab)
        {
            if (tab == null)
            {
                throw new ArgumentNullException("tab");
            }

            this.tab = tab;
            if (this.tab.Selected)
            {
                Utilities.LogMessage(MethodBase.GetCurrentMethod().Name + " Select tab: " + this.tab.Text);
                this.tab.Select();
            }
        }
        #endregion

        #region Control Extended Properties

        /// <summary>
        /// Task status
        /// </summary>
        public string TaskStatus
        {
            get
            {
                return new StaticControl(this.tab.AccessibleObject.Window, ControlIDs.TaskStatusLabel).Text;
            }
        }

        /// <summary>
        /// Url being tested
        /// </summary>
        public string UrlTested
        {
            get
            {
                return new StaticControl(this.tab.AccessibleObject.Window, ControlIDs.UrlLabel).Text;
            }
        }

        /// <summary>
        /// On which machine this test is executed
        /// </summary>
        public string Location
        {
            get
            {
                return new StaticControl(this.tab.AccessibleObject.Window, ControlIDs.LocationLabel).Text;
            }
        }
        #endregion

        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/14/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for TaskStatusLabel
            /// </summary>
            public const string TaskStatusLabel = "taskStatusLabel";

            /// <summary>
            /// Control ID for UrlLabel
            /// </summary>
            public const string UrlLabel = "urlLabel";

            /// <summary>
            /// Control ID for LocationLabel
            /// </summary>
            public const string LocationLabel = "locationLabel";
        }
        #endregion
    }
}
