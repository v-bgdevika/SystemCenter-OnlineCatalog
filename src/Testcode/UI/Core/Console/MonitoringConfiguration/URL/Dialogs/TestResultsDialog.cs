// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WhereToMonitorFromDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	SCOM UI Test
// </project>
// <summary>
// 	This class wraps the Test Results dialog
// </summary>
// <history>
// 	[v-bire] 3/16/2011 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs
{
    using System;
    using System.Collections.Generic;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// This class wraps Test Results dialog. This dialog contains 4 tabs: Summary, Detail, HTTP Request, HTTP Response
    /// </summary>
    /// <history>
    /// 	[v-bire] 3/16/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class TestResultsDialog
    {
        #region Private Member Variables

        /// <summary>
        /// Window object to represent this UI element
        /// </summary>
        private Window wnd;

        /// <summary>
        /// Cache to hold a reference of tab control
        /// </summary>
        private TabControl cachedTabControl;

        /// <summary>
        /// key: tab item name, value: tab item index
        /// </summary>
        private Dictionary<string, int> tabIndex = new Dictionary<string, int>();

        #endregion

        #region Properties

        public Window Window
        {
            get
            {
                return this.wnd;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Parent should be Add Monitoring Wizard, and this dialog is a first child of it
        /// </summary>
        /// <param name="parent">Add Monitoring Wizard</param>
        public TestResultsDialog(Window parent)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }

            const int maxTries=30;
            int numberOfRetries=0;
            const int interval=500;

            while (((this.wnd =parent.Extended.FirstChild) == null) && ((numberOfRetries++) <= maxTries))
            {
                Sleeper.Delay(interval);
            }

            if (this.wnd == null)
            {
                throw new Window.Exceptions.WindowNotFoundException("Cannot find first child window under parent: "+parent.ToString());
            }

            // update tab index
            foreach (TabControlTab tabItem in this.TabControl.Tabs)
            {
                tabIndex[tabItem.AccessibleObject.Name] = tabItem.Index;
            }
        }
        #endregion

        #region Control Properties

        /// <summary>
        /// Tab Control
        /// </summary>
        public TabControl TabControl
        {
            get
            {
                if (this.cachedTabControl == null)
                {
                    this.cachedTabControl = new TabControl(this.wnd, ControlIDs.TabControl);
                }

                return this.cachedTabControl;
            }
        }

        /// <summary>
        /// Close Button
        /// </summary>
        public Button CloseButton
        {
            get
            {
                return new Button(this.wnd, ControlIDs.CloseButton);
            }
        }

        #endregion

        #region Control Extended Properties

        /// <summary>
        /// Summary Tab
        /// </summary>
        public TestResultsSummaryTab SummaryTab
        {
            get
            {
                return new TestResultsSummaryTab(this.TabControl.Tabs[tabIndex[ControlIDs.TabSummaryName]]);
            }
        }

        /// <summary>
        /// Details Tab
        /// </summary>
        public TestResultsDetailsTab DetailsTab
        {
            get
            {
                return new TestResultsDetailsTab(this.TabControl.Tabs[tabIndex[ControlIDs.TabDetailsName]]);
            }
        }

        /// <summary>
        /// HTTP Request Tab
        /// </summary>
        public TestResultsHTTPRequestTab HTTPRequestTab
        {
            get
            {
                return new TestResultsHTTPRequestTab(this.TabControl.Tabs [tabIndex[ControlIDs.TabHTTPRequestName]]);
            }
        }

        /// <summary>
        /// HTTP Response Tab
        /// </summary>
        public TestResultsHTTPResponseTab HTTPResponseTab
        {
            get
            {
                return new TestResultsHTTPResponseTab(this.TabControl.Tabs[tabIndex[ControlIDs.TabHTTPResponseName]]);
            }
        }

        #endregion

        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[v-bire] 3/16/2011 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control Name for Summary Tab
            /// </summary>
            public const string TabSummaryName = "Summary";

            /// <summary>
            /// Control Name for Details Tab
            /// </summary>
            public const string TabDetailsName = "Details";

            /// <summary>
            /// Control Name for HTTP Request Tab
            /// </summary>
            public const string TabHTTPRequestName = "HTTP Request";

            /// <summary>
            /// Control Name for HTTP Response Tab
            /// </summary>
            public const string TabHTTPResponseName = "HTTP Response";

            /// <summary>
            /// Control Name for Close Button
            /// </summary>
            public const string CloseButton = "CloseButton";

            /// <summary>
            /// Control Name for Tab Control
            /// </summary>
            public const string TabControl = "tabControl1";
        }
        #endregion
    }
}
