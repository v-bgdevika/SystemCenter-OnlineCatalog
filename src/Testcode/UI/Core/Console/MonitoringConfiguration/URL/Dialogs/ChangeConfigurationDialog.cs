// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WhereToMonitorFromDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	SCOM UI Test
// </project>
// <summary>
// 	This class wraps the Change Configuration UI. It's a dialog with lots of controls.
//  Controls grouped by panes, and each pane is a sub class, also has a diret property
//  in this class. Client code could call this property to access each pane.
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
    using Mom.Test.UI.Core.Common;

    /// -----------------------------------------------------------------------------
    /// <summary>
    ///  This class wraps the Change Configuration dialog. This dialog has lots of controls, and these controls grouped by pane
    /// each pane is a sub class and also a direct property of this class. 
    /// </summary>
    /// <history>
    /// 	[v-bire] 3/16/2011 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ChangeConfigurationDialog
    {
        #region Private Member Variables

        /// <summary>
        /// window object to represent Change Configuration dialog
        /// </summary>
        private Window wnd;

        /// <summary>
        /// key: automation id of pane, value: Control object which represents the pane
        /// </summary>
        private Dictionary<string, Control> panes = new Dictionary<string, Control>();

        /// <summary>
        /// Cache to hold a reference to TestFrequencyCollectionInterval
        /// </summary>
        private TestFrequencyCollectionInterval cachedTestFrequencyCollectionInterval;

        /// <summary>
        /// Cache to hold a reference to Alerts
        /// </summary>
        private Alerts cachedAlerts;

        /// <summary>
        /// Cache to hold a reference to PerformanceCollection
        /// </summary>
        private PerformanceCollection cachedPerformanceCollection;

        /// <summary>
        /// Cache to hold a reference to GeneralConfiguration
        /// </summary>
        private GeneralConfiguration cachedGeneralConfiguration;

        /// <summary>
        /// Cache to hold a reference to HttpHeaders
        /// </summary>
        private HttpHeaders cachedHttpHeaders;

        /// <summary>
        /// Cache to hold a reference to ProxyServer
        /// </summary>
        private ProxyServer cachedProxyServer;

        #endregion

        #region Properties



        #endregion

        #region Constructor

        /// <summary>
        /// Initialize dialog by parent dialog
        /// </summary>
        /// <param name="parent">Add Monitoring Wizard...</param>
        public ChangeConfigurationDialog(Window parent)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }

            const int maxTries = 30;
            int numberOfRetries = 0;

            while (((this.wnd = parent.Extended.FirstChild) == null) && ((numberOfRetries++) < maxTries))
            {
                Sleeper.Delay(Constants.OneSecond / 2);
            }

            if (this.wnd == null)
            {
                throw new Window.Exceptions.WindowNotFoundException("Cannot find first child window under parent: " + parent.ToString());
            }

            // update the panes
            string accTech = ((this.wnd.ScreenElement.AttachMethod == AccessibilityTechnology.MSAA) ? "MSAA" : "UIA");
            string queryId = string.Format(";[FindAll, {0}] Role = 'pane'", accTech);

            MauiCollection<IScreenElement> mauis = this.wnd.ScreenElement.FindAllDescendants(-1, queryId, null);

            if (mauis == null || mauis.Count == 0)
            {
                throw new Control.Exceptions.Msaa.ChildCountException("Cannot find pane with qid: " + queryId+" against the window "+this.wnd.Caption);
            }

            foreach (IScreenElement element in mauis)
            {
                Control ctrl = new Control(new Window(element));
                this.panes[ctrl.Extended.WinFormsID] = ctrl;
            }
        }
        #endregion

        #region Control Extended Properties

        /// <summary>
        /// Test Frequency / Collection Interval
        /// </summary>
        public TestFrequencyCollectionInterval TestFrequencyCollectionIntervalSection
        {
            get
            {
                if (null == this.cachedTestFrequencyCollectionInterval)
                {
                    this.cachedTestFrequencyCollectionInterval = new TestFrequencyCollectionInterval(this.panes);
                }
                return this.cachedTestFrequencyCollectionInterval;
            }
        }

        /// <summary>
        /// Alerts 
        /// </summary>
        public Alerts AlertsSection
        {
            get
            {
                if (null == this.cachedAlerts)
                {
                    this.cachedAlerts = new Alerts(this.panes);
                }
                return this.cachedAlerts;
            }
        }

        /// <summary>
        /// Performance Collection
        /// </summary>
        public PerformanceCollection PerformanceCollectionSection
        {
            get
            {
                if (null == this.cachedPerformanceCollection)
                { 
                    this.cachedPerformanceCollection = new PerformanceCollection(this.panes);
                }
                return this.cachedPerformanceCollection;
            }
        }

        /// <summary>
        /// General Configuration
        /// </summary>
        public GeneralConfiguration GeneralConfigurationSection
        {
            get
            {
                if (null == this.cachedGeneralConfiguration)
                { 
                    this.cachedGeneralConfiguration = new GeneralConfiguration(this.panes); 
                }
                return this.cachedGeneralConfiguration;
            }
        }

        /// <summary>
        /// Http Header 
        /// </summary>
        public HttpHeaders HttpHeadersSection
        {
            get
            {
                if (null == this.cachedHttpHeaders)
                { 
                    this.cachedHttpHeaders = new HttpHeaders(this.panes);
                }
                return this.cachedHttpHeaders;
            }
        }

        /// <summary>
        /// Proxy Server
        /// </summary>
        public ProxyServer ProxyServerSection
        {
            get
            {
                if (null == this.cachedProxyServer)
                { 
                    this.cachedProxyServer = new ProxyServer(this.panes);
                }
                return this.cachedProxyServer;
            }
        }

        #endregion

        #region Sections

        /// <summary>
        /// Test Frequency / Collection Interval
        /// </summary>
        public class TestFrequencyCollectionInterval
        {
            #region Private Members

            /// <summary>
            /// key: automation id of controls, value: pane
            /// </summary>
            private Dictionary<string, Control> containers;

            #endregion

            #region Properties
            #endregion

            #region Constructor

            /// <summary>
            /// Initialize TestFrequencyCollectionInterval by containers
            /// </summary>
            /// <param name="containers">a dictonary stores automation id of the pane and the pane itself</param>
            public TestFrequencyCollectionInterval(Dictionary<string, Control> containers)
            {
                if (containers == null || containers.Count == 0)
                {
                    throw new ArgumentNullException("containers");
                }

                this.containers = containers;
            }

            #endregion

            #region Control Properties

            /// <summary>
            /// Get Test Frequency Spinner from TestFrequencyPane
            /// </summary>
            public Spinner TestFrequency
            {
                get
                {
                    return new Spinner(containers[ControlIDs.TestFrequencyCollectionInterval.TestFrequencyPane], ControlIDs.TestFrequencyCollectionInterval.NumericDropDown);
                }
            }

            /// <summary>
            /// Get Test Frequency Unit ComboBox from TestFrequencyPane
            /// </summary>
            public ComboBox TestFrequencyUnit
            {
                get
                {
                    return new ComboBox(containers[ControlIDs.TestFrequencyCollectionInterval.TestFrequencyPane], ControlIDs.TestFrequencyCollectionInterval.ComboBoxUnit);
                }
            }

            /// <summary>
            /// Get Data Collection Interval Spinner from TestFrequencyPane
            /// </summary>
            public Spinner DataCollectionInterval
            {
                get
                {
                    return new Spinner(containers[ControlIDs.TestFrequencyCollectionInterval.DataCollectionIntervalPane], ControlIDs.TestFrequencyCollectionInterval.NumericDropDown);
                }
            }

            /// <summary>
            /// Get Data Collection Interval Unit ComboBox from TestFrequencyPane
            /// </summary>
            public ComboBox DataCollectionIntervalUnit
            {
                get
                {
                    return new ComboBox(containers[ControlIDs.TestFrequencyCollectionInterval.DataCollectionIntervalPane], ControlIDs.TestFrequencyCollectionInterval.ComboBoxUnit);
                }
            }

            #endregion
        }

        /// <summary>
        /// This class wraps the Alerts section of Change Configuration dialog
        /// </summary>
        public class Alerts
        {
            #region Private Members

            /// <summary>
            /// key: automation id of controls, value: pane
            /// </summary>
            private Dictionary<string, Control> containers;

            #endregion

            #region Properties
            #endregion

            #region Constructor

            /// <summary>
            /// Initialize Alerts by containers
            /// </summary>
            /// <param name="containers">a dictonary stores automation id of the pane and the pane itself</param>
            public Alerts(Dictionary<string, Control> containers)
            {
                if (containers == null || containers.Count == 0)
                {
                    throw new ArgumentNullException("containers");
                }

                this.containers = containers;
            }

            #endregion

            #region Control Properties

            /// <summary>
            /// Get Error Reponse Time CheckBox from ErrorCriteriaTableLayoutPanel
            /// </summary>
            public CheckBox ErrorResponseTimeCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.Alerts.ErrorCriteriaTableLayoutPanel], ControlIDs.Alerts.ErrorResponseTimeCheckBox);
                }
            }

            /// <summary>
            /// Get Error Response Time ComboBox from ErrorCriteriaTableLayoutPanel
            /// </summary>
            public ComboBox ErrorResponseTimeComboBox
            {
                get
                {
                    return new ComboBox(containers[ControlIDs.Alerts.ErrorCriteriaTableLayoutPanel], ControlIDs.Alerts.ErrorResponseTimeComboBox);
                }
            }

            /// <summary>
            /// Get Error Reponse Time TextBox from ErrorCriteriaTableLayoutPanel
            /// </summary>
            public TextBox ErrorResponseTimeTextBox
            {
                get
                {
                    return new TextBox(containers[ControlIDs.Alerts.ErrorCriteriaTableLayoutPanel], ControlIDs.Alerts.ErrorResponseTimeTextBox);
                }
            }

            /// <summary>
            /// Get Error Http Code CheckBox from ErrorCriteriaTableLayoutPanel
            /// </summary>
            public CheckBox ErrorHttpCodeCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.Alerts.ErrorCriteriaTableLayoutPanel], ControlIDs.Alerts.ErrorHttpCodeCheckBox);
                }
            }

            /// <summary>
            /// Get Error Http Code ComboBox from ErrorCriteriaTableLayoutPanel
            /// </summary>
            public ComboBox ErrorHttpCodeComboBox
            {
                get
                {
                    return new ComboBox(containers[ControlIDs.Alerts.ErrorCriteriaTableLayoutPanel], ControlIDs.Alerts.ErrorHttpCodeComboBox);
                }
            }

            /// <summary>
            /// Get Error Http Code TextBox from ErrorCriteriaTableLayoutPanel
            /// </summary>
            public TextBox ErrorHttpCodeTextBox
            {
                get
                {
                    return new TextBox(containers[ControlIDs.Alerts.ErrorCriteriaTableLayoutPanel], ControlIDs.Alerts.ErrorHttpCodeTextBox);
                }
            }

            /// <summary>
            /// Get Error Http Code Button from ErrorCriteriaTableLayoutPanel
            /// </summary>
            public Button ErrorHttpCodeButton
            {
                get
                {
                    return new Button(containers[ControlIDs.Alerts.ErrorCriteriaTableLayoutPanel], ControlIDs.Alerts.ErrorHttpCodeButton);
                }
            }

            /// <summary>
            /// Get Error Content Match CheckBox from ErrorCriteriaTableLayoutPanel
            /// </summary>
            public CheckBox ErrorContentMatchCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.Alerts.ErrorCriteriaTableLayoutPanel], ControlIDs.Alerts.ErrorContentMatchCheckBox);
                }
            }

            /// <summary>
            /// Get Error Content Match ComboBox from ErrorCriteriaTableLayoutPanel
            /// </summary>
            public ComboBox ErrorContentMatchComboBox
            {
                get
                {
                    return new ComboBox(containers[ControlIDs.Alerts.ErrorCriteriaTableLayoutPanel], ControlIDs.Alerts.ErrorContentMatchComboBox);
                }
            }

            /// <summary>
            /// Get Error Content Match TextBox from ErrorCriteriaTableLayoutPanel
            /// </summary>
            public TextBox ErrorContentMatchTextBox
            {
                get
                {
                    return new TextBox(containers[ControlIDs.Alerts.ErrorCriteriaTableLayoutPanel], ControlIDs.Alerts.ErrorContentMatchTextBox);
                }
            }

            /// <summary>
            /// Get Warning Response Time CheckBox WarningCriteriaTableLayoutPanel
            /// </summary>
            public CheckBox WarningResponseTimeCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.Alerts.WarningCriteriaTableLayoutPanel], ControlIDs.Alerts.WarningResponseTimeCheckBox);
                }
            }

            /// <summary>
            /// Get Warning Response Time ComboBox from WarningCriteriaTableLayoutPanel
            /// </summary>
            public ComboBox WarningResponseTimeComboBox
            {
                get
                {
                    return new ComboBox(containers[ControlIDs.Alerts.WarningCriteriaTableLayoutPanel], ControlIDs.Alerts.WarningResponseTimeComboBox);
                }
            }

            /// <summary>
            /// Get Warning Response Time TextBox from WarningCriteriaTableLayoutPanel
            /// </summary>
            public TextBox WarningResponseTimeTextBox
            {
                get
                {
                    return new TextBox(containers[ControlIDs.Alerts.WarningCriteriaTableLayoutPanel], ControlIDs.Alerts.WarningResponseTimeTextBox);
                }
            }

            /// <summary>
            /// Get Warning Http Code CheckBox from WarningCriteriaTableLayoutPanel
            /// </summary>
            public CheckBox WarningHttpCodeCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.Alerts.WarningCriteriaTableLayoutPanel], ControlIDs.Alerts.WarningHttpCodeCheckBox);
                }
            }

            /// <summary>
            /// Get Warning Http Code ComboBox from WarningCriteriaTableLayoutPanel
            /// </summary>
            public ComboBox WarningHttpCodeComboBox
            {
                get
                {
                    return new ComboBox(containers[ControlIDs.Alerts.WarningCriteriaTableLayoutPanel], ControlIDs.Alerts.WarningHttpCodeComboBox);
                }
            }

            /// <summary>
            /// Get Warning Http Code TextBox from WarningCriteriaTableLayoutPanel
            /// </summary>
            public TextBox WarningHttpCodeTextBox
            {
                get
                {
                    return new TextBox(containers[ControlIDs.Alerts.WarningCriteriaTableLayoutPanel], ControlIDs.Alerts.WarningHttpCodeTextBox);
                }
            }

            /// <summary>
            /// Get Warning Http Code Button from WarningCriteriaTableLayoutPanel
            /// </summary>
            public Button WarningHttpCodeButton
            {
                get
                {
                    return new Button(containers[ControlIDs.Alerts.WarningCriteriaTableLayoutPanel], ControlIDs.Alerts.WarningHttpCodeButton);
                }
            }

            /// <summary>
            /// Get Warning Content Match CheckBox from WarningCriteriaTableLayoutPanel
            /// </summary>
            public CheckBox WarningContentMatchCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.Alerts.WarningCriteriaTableLayoutPanel], ControlIDs.Alerts.WarningContentMatchCheckBox);
                }
            }

            /// <summary>
            /// Get Warning Content Match ComboBox from WarningCriteriaTableLayoutPanel
            /// </summary>
            public ComboBox WarningContentMatchComboBox
            {
                get
                {
                    return new ComboBox(containers[ControlIDs.Alerts.WarningCriteriaTableLayoutPanel], ControlIDs.Alerts.WarningContentMatchComboBox);
                }
            }

            /// <summary>
            /// Get Warning Content Match TextBox from WarningCriteriaTableLayoutPanel
            /// </summary>
            public TextBox WarningContentMatchTextBox
            {
                get
                {
                    return new TextBox(containers[ControlIDs.Alerts.WarningCriteriaTableLayoutPanel], ControlIDs.Alerts.WarningContentMatchTextBox);
                }
            }

            /// <summary>
            /// Get General Alert From Test CheckBox from AlertsPanel
            /// </summary>
            public CheckBox GenerateAlertFromTestCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.Alerts.AlertsPanel], ControlIDs.Alerts.GenerateAlertFromTestCheckBox);
                }
            }

            /// <summary>
            /// Get Generate Alert From Template CheckBox from AlertsPanel
            /// </summary>
            public CheckBox GenerateAlertFromTemplateCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.Alerts.AlertsPanel], ControlIDs.Alerts.GenerateAlertFromTemplateCheckBox);
                }
            }
            #endregion
        }

        /// <summary>
        /// This class wraps the Performance Collection section of Change Configuration dialog
        /// </summary>
        public class PerformanceCollection
        {
            #region Private Members

            /// <summary>
            /// key: automation id of controls, value: pane
            /// </summary>
            private Dictionary<string, Control> containers;

            #endregion

            #region Properties
            #endregion

            #region Constructor

            /// <summary>
            /// Initialize PerformanceCollection by containers
            /// </summary>
            /// <param name="containers">a dictonary stores automation id of the pane and the pane itself</param>
            public PerformanceCollection(Dictionary<string, Control> containers)
            {
                if (containers == null || containers.Count == 0)
                {
                    throw new ArgumentNullException("containers");
                }

                this.containers = containers;
            }

            #endregion

            #region Control Properties

            /// <summary>
            /// Get Total Reponse Time CheckBox from PerformanceCollectionPanel
            /// </summary>
            public CheckBox TotalResponseTimeCeckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.PerformanceCollection.PerformanceCollectionPanel], ControlIDs.PerformanceCollection.TotalResponseTimeCeckBox);
                }
            }

            /// <summary>
            /// Get Response Time CheckBox from PerformanceCollectionPanel
            /// </summary>
            public CheckBox ResponseTimeCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.PerformanceCollection.PerformanceCollectionPanel], ControlIDs.PerformanceCollection.ResponseTimeCheckBox);
                }
            }

            /// <summary>
            /// Get Tcp Connect Time CheckBox from PerformanceCollectionPanel
            /// </summary>
            public CheckBox TcpConnectTimeCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.PerformanceCollection.PerformanceCollectionPanel], ControlIDs.PerformanceCollection.TcpConnectTimeCheckBox);
                }
            }

            /// <summary>
            /// Get Time To First Byte CheckBox from PerformanceCollectionPanel
            /// </summary>
            public CheckBox TimeToFirstByteCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.PerformanceCollection.PerformanceCollectionPanel], ControlIDs.PerformanceCollection.TimeToFirstByteCheckBox);
                }
            }

            /// <summary>
            /// Get Time To Last Byte CheckBox from PerformanceCollectionPanel
            /// </summary>
            public CheckBox TimeToLastByteCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.PerformanceCollection.PerformanceCollectionPanel], ControlIDs.PerformanceCollection.TimeToLastByteCheckBox);
                }
            }

            /// <summary>
            /// Get Dns Resolution Time CheckBox from PerformanceCollectionPanel
            /// </summary>
            public CheckBox DnsResolutionTimeCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.PerformanceCollection.PerformanceCollectionPanel], ControlIDs.PerformanceCollection.DnsResolutionTimeCheckBox);
                }
            }

            /// <summary>
            /// Get Content Size CheckBox from PerformanceCollectionPanel
            /// </summary>
            public CheckBox ContentSizeCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.PerformanceCollection.PerformanceCollectionPanel], ControlIDs.PerformanceCollection.ContentSizeCheckBox);
                }
            }

            /// <summary>
            /// Get Content Time CheckBox from PerformanceCollectionPanel
            /// </summary>
            public CheckBox ContentTimeCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.PerformanceCollection.PerformanceCollectionPanel], ControlIDs.PerformanceCollection.ContentTimeCheckBox);
                }
            }

            /// <summary>
            /// Get Download Time CheckBox from PerformanceCollectionPanel
            /// </summary>
            public CheckBox DownloadTimeCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.PerformanceCollection.PerformanceCollectionPanel], ControlIDs.PerformanceCollection.DownloadTimeCheckBox);
                }
            }
            #endregion
        }

        /// <summary>
        /// This class wraps the General Configuration of Change Configuration dialog
        /// </summary>
        public class GeneralConfiguration
        {
            #region Private Members

            /// <summary>
            /// key: automation id of controls, value: pane
            /// </summary>
            private Dictionary<string, Control> containers;

            #endregion

            #region Properties
            #endregion

            #region Constructor

            /// <summary>
            /// Initialize GeneralConfiguration by containers
            /// </summary>
            /// <param name="containers">a dictonary stores automation id of the pane and the pane itself</param>
            public GeneralConfiguration(Dictionary<string, Control> containers)
            {
                if (containers == null || containers.Count == 0)
                {
                    throw new ArgumentNullException("containers");
                }

                this.containers = containers;
            }

            #endregion

            #region Control Properties

            /// <summary>
            /// Get Allow Redirects CheckBox from GeneralPanel
            /// </summary>
            public CheckBox AllowRedirectsCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.GeneralConfiguration.GeneralPanel], ControlIDs.GeneralConfiguration.AllowRedirectsCheckBox);
                }
            }

            /// <summary>
            /// Get Http Version ComboBox from GeneralPanel
            /// </summary>
            public ComboBox HttpVersionComboBox
            {
                get
                {
                    return new ComboBox(containers[ControlIDs.GeneralConfiguration.GeneralPanel], ControlIDs.GeneralConfiguration.HttpVersionComboBox);
                }
            }

            /// <summary>
            /// Get Http Method ComboBox from GeneralPanel
            /// </summary>
            public ComboBox HttpMethodComboBox
            {
                get
                {
                    return new ComboBox(containers[ControlIDs.GeneralConfiguration.GeneralPanel], ControlIDs.GeneralConfiguration.HttpMethodComboBox);
                }
            }

            /// <summary>
            /// Get Post TextBox from GeneralPanel
            /// </summary>
            public TextBox PostTextBox
            {
                get
                {
                    return new TextBox(containers[ControlIDs.GeneralConfiguration.GeneralPanel], ControlIDs.GeneralConfiguration.PostTextBox);
                }
            }
            #endregion
        }

        /// <summary>
        /// This class wraps the Http Headers of Change Configuration dialog
        /// </summary>
        public class HttpHeaders
        {
            #region Private Members

            /// <summary>
            /// key: automation id of controls, value: pane
            /// </summary>
            private Dictionary<string, Control> containers;

            #endregion

            #region Properties
            #endregion

            #region Constructor

            /// <summary>
            /// Initialize HttpHeaders by containers
            /// </summary>
            /// <param name="containers">a dictonary stores automation id of the pane and the pane itself</param>
            public HttpHeaders(Dictionary<string, Control> containers)
            {
                if (containers == null || containers.Count == 0)
                {
                    throw new ArgumentNullException("containers");
                }

                this.containers = containers;
            }

            #endregion

            #region Control Properties

            /// <summary>
            /// Get Http Header GridView from HttpHeadersPanel
            /// </summary>
            public DataGrid HttpHeaderGridView
            {
                get
                {
                    return new DataGrid(containers[ControlIDs.HttpHeaders.HttpHeadersPanel], ControlIDs.HttpHeaders.HttpHeaderGridView);
                }
            }

            /// <summary>
            /// Get Http Header Add Button from HttpHeadersPanel
            /// </summary>
            public Button HttpHeaderAddButton
            {
                get
                {
                    return new Button(containers[ControlIDs.HttpHeaders.HttpHeadersPanel], ControlIDs.HttpHeaders.HttpHeaderAddButton);
                }
            }

            /// <summary>
            /// Get Http Header Delete Button from HttpHeadersPanel
            /// </summary>
            public Button HttpHeaderDeleteButton
            {
                get
                {
                    return new Button(containers[ControlIDs.HttpHeaders.HttpHeadersPanel], ControlIDs.HttpHeaders.HttpHeaderDeleteButton);
                }
            }

            /// <summary>
            /// Get Http Header Edit Button from HttpHeadersPanel
            /// </summary>
            public Button HttpHeaderEditButton
            {
                get
                {
                    return new Button(containers[ControlIDs.HttpHeaders.HttpHeadersPanel], ControlIDs.HttpHeaders.HttpHeaderEditButton);
                }
            }
            #endregion
        }

        /// <summary>
        /// This class wraps the Proxy Server of Change Configuration dialog
        /// </summary>
        public class ProxyServer
        {
            #region Private Members

            /// <summary>
            /// key: automation id of controls, value: pane
            /// </summary>
            private Dictionary<string, Control> containers;

            #endregion

            #region Properties
            #endregion

            #region Constructor

            /// <summary>
            /// Initialize ProxyServer by containers
            /// </summary>
            /// <param name="containers"></param>
            public ProxyServer(Dictionary<string, Control> containers)
            {
                if (containers == null || containers.Count == 0)
                {
                    throw new ArgumentNullException("containers");
                }

                this.containers = containers;
            }

            #endregion

            #region Control Properties

            /// <summary>
            /// Get Proxy Server CheckBox from ProxyPanel
            /// </summary>
            public CheckBox ProxyServerCheckBox
            {
                get
                {
                    return new CheckBox(containers[ControlIDs.ProxyServer.ProxyPanel], ControlIDs.ProxyServer.ProxyServerCheckBox);
                }
            }

            /// <summary>
            /// Get Proxy Address TextBox from ProxyPanel
            /// </summary>
            public TextBox ProxyAddressTextBox
            {
                get
                {
                    return new TextBox(containers[ControlIDs.ProxyServer.ProxyPanel], ControlIDs.ProxyServer.ProxyAddressTextBox);
                }
            }

            /// <summary>
            /// Get Proxy Port TextBox from ProxyPanel
            /// </summary>
            public TextBox ProxyPortTextBox
            {
                get
                {
                    return new TextBox(containers[ControlIDs.ProxyServer.ProxyPanel], ControlIDs.ProxyServer.ProxyPortTextBox);
                }
            }
            #endregion
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
            /// Control ID for Test OkButton
            /// </summary>
            public const string OkButton = "okButton";

            /// <summary>
            /// Control ID for Test CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";

            /// <summary>
            /// Control ID for Test ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";

            public class TestFrequencyCollectionInterval
            {
                /// <summary>
                /// Control ID for Test Frequency Pane
                /// </summary>
                public const string TestFrequencyPane = "testIntervalUnitControl";

                /// <summary>
                /// Control ID for Data Collection Interval Pane
                /// </summary>
                public const string DataCollectionIntervalPane = "dataCollectionIntervalUnitContro";

                /// <summary>
                /// Control ID for Numberic Drop Down
                /// </summary>
                public const string NumericDropDown = "numericDropDown";

                /// <summary>
                /// Control ID for Combo Box Unit
                /// </summary>
                public const string ComboBoxUnit = "comboBoxUnit";
            }

            public class Alerts
            {
                /// <summary>
                /// Control ID for AlertsPanel
                /// </summary>
                public const string AlertsPanel = "alertsPanel";

                /// <summary>
                /// Control ID for ErrorCriteriaTableLayoutPanel
                /// </summary>
                public const string ErrorCriteriaTableLayoutPanel = "errorCriteriaTableLayoutPanel";

                /// <summary>
                /// Control ID for WarningCriteriaTableLayoutPanel
                /// </summary>
                public const string WarningCriteriaTableLayoutPanel = "warningCriteriaTableLayoutPanel";

                /// <summary>
                /// Control ID for ErrorResponseTimeCheckBox
                /// </summary>
                public const string ErrorResponseTimeCheckBox = "errorResponseTimeCheckBox";

                /// <summary>
                /// Control ID for ErrorResponseTimeComboBox
                /// </summary>
                public const string ErrorResponseTimeComboBox = "errorResponseTimeComboBox";

                /// <summary>
                /// Control ID for ErrorResponseTimeTextBox
                /// </summary>
                public const string ErrorResponseTimeTextBox = "errorResponseTimeTextBox";

                /// <summary>
                /// Control ID for ErrorHttpCodeCheckBox
                /// </summary>
                public const string ErrorHttpCodeCheckBox = "errorHttpCodeCheckBox";

                /// <summary>
                /// Control ID for ErrorHttpCodeComboBox
                /// </summary>
                public const string ErrorHttpCodeComboBox = "errorHttpCodeComboBox";

                /// <summary>
                /// Control ID for ErrorHttpCodeTextBox
                /// </summary>
                public const string ErrorHttpCodeTextBox = "errorHttpCodeTextBox";

                /// <summary>
                /// Control ID for ErrorHttpCodeButton
                /// </summary>
                public const string ErrorHttpCodeButton = "errorHttpCodeButton";

                /// <summary>
                /// Control ID for ErrorContentMatchCheckBox
                /// </summary>
                public const string ErrorContentMatchCheckBox = "errorContentMatchCheckBox";

                /// <summary>
                /// Control ID for ErrorContentMatchComboBox
                /// </summary>
                public const string ErrorContentMatchComboBox = "errorContentMatchComboBox";

                /// <summary>
                /// Control ID for ErrorContentMatchTextBox
                /// </summary>
                public const string ErrorContentMatchTextBox = "errorContentMatchTextBox";

                /// <summary>
                /// Control ID for WarningResponseTimeCheckBox
                /// </summary>
                public const string WarningResponseTimeCheckBox = "warningResponseTimeCheckBox";

                /// <summary>
                /// Control ID for WarningResponseTimeComboBox
                /// </summary>
                public const string WarningResponseTimeComboBox = "warningResponseTimeComboBox";

                /// <summary>
                /// Control ID for WarningResponseTimeTextBox
                /// </summary>
                public const string WarningResponseTimeTextBox = "warningResponseTimeTextBox";

                /// <summary>
                /// Control ID for WarningHttpCodeCheckBox
                /// </summary>
                public const string WarningHttpCodeCheckBox = "warningHttpCodeCheckBox";

                /// <summary>
                /// Control ID for WarningHttpCodeComboBox
                /// </summary>
                public const string WarningHttpCodeComboBox = "warningHttpCodeComboBox";

                /// <summary>
                /// Control ID for WarningHttpCodeTextBox
                /// </summary>
                public const string WarningHttpCodeTextBox = "warningHttpCodeTextBox";

                /// <summary>
                /// Control ID for WarningHttpCodeButton
                /// </summary>
                public const string WarningHttpCodeButton = "warningHttpCodeButton";

                /// <summary>
                /// Control ID for WarningContentMatchCheckBox
                /// </summary>
                public const string WarningContentMatchCheckBox = "warningContentMatchCheckBox";

                /// <summary>
                /// Control ID for WarningContentMatchComboBox
                /// </summary>
                public const string WarningContentMatchComboBox = "warningContentMatchComboBox";

                /// <summary>
                /// Control ID for WarningContentMatchTextBox
                /// </summary>
                public const string WarningContentMatchTextBox = "warningContentMatchTextBox";

                /// <summary>
                /// Control ID for GenerateAlertFromTestCheckBox
                /// </summary>
                public const string GenerateAlertFromTestCheckBox = "generateAlertFromTestCheckBox";

                /// <summary>
                /// Control ID for GenerateAlertFromTemplateCheckBox
                /// </summary>
                public const string GenerateAlertFromTemplateCheckBox = "generateAlertFromTemplateCheckBox";
            }

            public class PerformanceCollection
            {
                /// <summary>
                /// Control ID for PerformanceCollectionPanel
                /// </summary>
                public const string PerformanceCollectionPanel = "performanceCollectionPanel";

                /// <summary>
                /// Control ID for TotalResponseTimeCeckBox
                /// </summary>
                public const string TotalResponseTimeCeckBox = "totalResponseTimeCeckBox";

                /// <summary>
                /// Control ID for ResponseTimeCheckBox
                /// </summary>
                public const string ResponseTimeCheckBox = "responseTimeCheckBox";

                /// <summary>
                /// Control ID for TcpConnectTimeCheckBox
                /// </summary>
                public const string TcpConnectTimeCheckBox = "tcpConnectTimeCheckBox";

                /// <summary>
                /// Control ID for TimeToFirstByteCheckBox
                /// </summary>
                public const string TimeToFirstByteCheckBox = "timeToFirstByteCheckBox";

                /// <summary>
                /// Control ID for TimeToLastByteCheckBox
                /// </summary>
                public const string TimeToLastByteCheckBox = "timeToLastByteCheckBox";

                /// <summary>
                /// Control ID for DnsResolutionTimeCheckBox
                /// </summary>
                public const string DnsResolutionTimeCheckBox = "dnsResolutionTimeCheckBox";

                /// <summary>
                /// Control ID for ContentSizeCheckBox
                /// </summary>
                public const string ContentSizeCheckBox = "contentSizeCheckBox";

                /// <summary>
                /// Control ID for ContentTimeCheckBox
                /// </summary>
                public const string ContentTimeCheckBox = "contentTimeCheckBox";

                /// <summary>
                /// Control ID for DownloadTimeCheckBox
                /// </summary>
                public const string DownloadTimeCheckBox = "downloadTimeCheckBox";
            }

            public class GeneralConfiguration
            {
                /// <summary>
                /// Control ID for GeneralPanel
                /// </summary>
                public const string GeneralPanel = "generalPanel";

                /// <summary>
                /// Control ID for AllowRedirectsCheckBox
                /// </summary>
                public const string AllowRedirectsCheckBox = "allowRedirectsCheckBox";

                /// <summary>
                /// Control ID for HttpVersionComboBox
                /// </summary>
                public const string HttpVersionComboBox = "httpVersionComboBox";

                /// <summary>
                /// Control ID for HttpMethodComboBox
                /// </summary>
                public const string HttpMethodComboBox = "httpMethodComboBox";

                /// <summary>
                /// Control ID for PostTextBox
                /// </summary>
                public const string PostTextBox = "postTextBox";
            }

            public class HttpHeaders
            {
                /// <summary>
                /// Control ID for HttpHeadersPanel
                /// </summary>
                public const string HttpHeadersPanel = "httpHeadersPanel";

                /// <summary>
                /// Control ID for HttpHeaderGridView
                /// </summary>
                public const string HttpHeaderGridView = "httpHeaderGridView";

                /// <summary>
                /// Control ID for HttpHeaderAddButton
                /// </summary>
                public const string HttpHeaderAddButton = "httpHeaderAddButton";

                /// <summary>
                /// Control ID for HttpHeaderEditButton
                /// </summary>
                public const string HttpHeaderEditButton = "httpHeaderEditButton";

                /// <summary>
                /// Control ID for HttpHeaderDeleteButton
                /// </summary>
                public const string HttpHeaderDeleteButton = "httpHeaderDeleteButton";
            }

            public class ProxyServer
            {
                /// <summary>
                /// Control ID for ProxyPanel
                /// </summary>
                public const string ProxyPanel = "proxyPanel";

                /// <summary>
                /// Control ID for ProxyServerCheckBox
                /// </summary>
                public const string ProxyServerCheckBox = "proxyServerCheckBox";

                /// <summary>
                /// Control ID for ProxyAddressTextBox
                /// </summary>
                public const string ProxyAddressTextBox = "proxyAddressTextBox";

                /// <summary>
                /// Control ID for ProxyPortTextBox
                /// </summary>
                public const string ProxyPortTextBox = "proxyPortTextBox";
            }
        }
        #endregion
    }
}
