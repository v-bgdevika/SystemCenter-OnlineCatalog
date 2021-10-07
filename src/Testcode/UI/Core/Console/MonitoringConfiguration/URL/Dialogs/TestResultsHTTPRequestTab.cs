// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WhereToMonitorFromDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	SCOM UI Test
// </project>
// <summary>
//  This class wraps HTTP Request tab.
// </summary>
// <history>
// 	[v-bire] 3/15/2011 Created
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
    /// This class wraps HTTP Request tab. This tab contains the info of a http request.
    /// </summary>
    /// <history>
    /// 	[v-bire] 3/15/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class TestResultsHTTPRequestTab
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

        public TestResultsHTTPRequestTab(TabControlTab tab)
        {
            if (tab == null)
            {
                throw new ArgumentNullException("tab");
            }

            this.tab = tab;
            if (this.tab.Selected)
            {
                Utilities.LogMessage(MethodBase.GetCurrentMethod().Name + "Select tab: " + this.tab.Text);
                this.tab.Select();
            }
        }
        #endregion

        #region Control Extended Properties

        /// <summary>
        /// HTTP Request
        /// </summary>
        public string HTTPRequest
        {
            get
            {
                return new TextBox(this.tab.AccessibleObject.Window, ControlIDs.RequestTextBox).Text;
            }
        }

        #endregion

        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/15/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for RequestTextBox
            /// </summary>
            public const string RequestTextBox = "requestTextBox";
        }
        #endregion
    }
}
