// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WhereToMonitorFromDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	SCOM UI Test
// </project>
// <summary>
// 	This class wraps Details tab.
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
    /// This class wraps Details tab.This tab contains the detail info, such as URL, Result, DNS Resolution time, and total response time, etc...
    /// </summary>
    /// <history>
    /// 	[v-bire] 3/15/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class TestResultsDetailsTab
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

        public TestResultsDetailsTab(TabControlTab tab)
        {
            if (tab == null)
            {
                throw new ArgumentNullException("tab");
            }

            this.tab = tab;
            if (this.tab.Selected)
            {
                Utilities.LogMessage(MethodBase.GetCurrentMethod().Name+" Select tab: " + this.tab.Text);
                this.tab.Select();
            }
        }
        #endregion

        #region Control Extended Properties

        /// <summary>
        /// URL
        /// </summary>
        public string URL
        {
            get
            {
                return new TextBox(this.tab.AccessibleObject.Window, ControlIDs.DetailUrlTextBox).Text;
            }
        }

        /// <summary>
        /// Result
        /// </summary>
        public string Result
        {
            get
            {
                return new TextBox(this.tab.AccessibleObject.Window, ControlIDs.DetailResultTextBox).Text;
            }
        }

        /// <summary>
        /// DNS Resolution Time (milliseconds)
        /// </summary>
        public string DNSResolutionTime
        {
            get
            {
                return new TextBox(this.tab.AccessibleObject.Window, ControlIDs.DetailDnsTimeTextBox).Text;
            }
        }

        /// <summary>
        /// Total Response Time (milliseconds)
        /// </summary>
        public string TotalResponseTime
        {
            get
            {
                return new TextBox(this.tab.AccessibleObject.Window, ControlIDs.DetailTotalTimeTextBox).Text;
            }
        }

        /// <summary>
        /// HTTP Status code
        /// </summary>
        public string HTTPStatusCode
        {
            get
            {
                return new TextBox(this.tab.AccessibleObject.Window, ControlIDs.DetailHttpCodeTextBox).Text;
            }
        }

        /// <summary>
        /// Response Body size (bytes)
        /// </summary>
        public string ResponseBodySize
        {
            get
            {
                return new TextBox(this.tab.AccessibleObject.Window, ControlIDs.DetailBodySizeTextBox).Text;
            }
        }

        /// <summary>
        /// Server Certificate Expiration (days)
        /// </summary>
        public string ServerCertificateExpiration
        {
            get
            {
                return new TextBox(this.tab.AccessibleObject.Window, ControlIDs.DetailCertTextBox).Text;
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
            /// Control ID for DetailUrlTextBox
            /// </summary>
            public const string DetailUrlTextBox = "detailUrlTextBox";

            /// <summary>
            /// Control ID for DetailResultTextBox
            /// </summary>
            public const string DetailResultTextBox = "detailResultTextBox";

            /// <summary>
            /// Control ID for DetailDnsTimeTextBox
            /// </summary>
            public const string DetailDnsTimeTextBox = "detailDnsTimeTextBox";

            /// <summary>
            /// Control ID for DetailTotalTimeTextBox
            /// </summary>
            public const string DetailTotalTimeTextBox = "detailTotalTimeTextBox";

            /// <summary>
            /// Control ID for DetailHttpCodeTextBox
            /// </summary>
            public const string DetailHttpCodeTextBox = "detailHttpCodeTextBox";

            /// <summary>
            /// Control ID for DetailBodySizeTextBox
            /// </summary>
            public const string DetailBodySizeTextBox = "detailBodySizeTextBox";

            /// <summary>
            /// Control ID for DetailCertTextBox
            /// </summary>
            public const string DetailCertTextBox = "detailCertTextBox";
        }
        #endregion
    }
}
