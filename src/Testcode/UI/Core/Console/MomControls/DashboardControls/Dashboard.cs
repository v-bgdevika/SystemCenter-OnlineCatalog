// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Dashboard.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <summary>
//   Base Class for Dashboard Hosting window
// </summary>
// <history>
//   [v-vijia] 1/31/2011 Created
//   [BillHodg] 2/16/2011 Refactored to move config and personalization here
// </history>
// ------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MomControls.DashboardControls
{
    using System;
    using Maui.Core;
    using Maui.Core.WinControls;
    using MomCommon = Mom.Test.UI.Core.Common;

    /// <summary>
    /// This interface lists the controls on a dashboard
    /// </summary>
    public interface IDashboardControl
    {
        /// <summary>
        /// The title of the dashboard
        /// </summary>
        StaticControl TitleText
        {
            get;
        }
    }

    /// <summary>
    /// This class represents the generic dashboard.
    /// </summary>
    public class Dashboard : Control, IDashboardControl
    {
        #region Private Variables
        /// <summary>
        /// The dashboard task host control
        /// </summary>
        private Window taskHost;

        /// <summary>
        /// The Configuration button in dashboard task host
        /// </summary>
        private Button configurationTaskButton;

        /// <summary>
        /// The Personalization button in dashboard task host
        /// </summary>
        private Button personalizationTaskButton;

        #endregion 

        #region QIDs
        /// <summary>
        /// This is a list of default QIDs for the controls on the view
        /// </summary>
        new public class ControlQIDs
        {
            /// <summary>
            /// QID of the title
            /// </summary>
            public static QID titleQID = new QID(";[UIA]AutomationId = 'viewPaneHeader';[UIA]AutomationId = 'ViewTitle'");

            /// <summary>
            /// QID of the Dashboard
            /// </summary>
            //public static QID dashboardQID = new QID(";[UIA]AutomationId = 'viewPanePanel'");
            public static string ResourceDashboard = ";[UIA]AutomationId = 'viewPanePanel'";
            //public static string ResourceDashboardWeb = ";[UIA]ClassName = 'ScrollViewer'";
            public static string ResourceDashboardWeb = ";[UIA]ClassName = 'MicrosoftSilverlight'";

            /// <summary>
            /// QID of the Dashboard task host
            /// </summary>
            public static QID taskHostQID = new QID(";[UIA]AutomationId='TaskHostButton'");

            /// <summary>
            /// QID of the vertical scroll bar
            /// </summary>
            public static QID verticalScrollBarQID = new QID(";[UIA]AutomationID='VerticalScrollBar' && ClassName='ScrollBar'");

            /// <summary>
            /// QID for the Configuration task button
            /// </summary>
            public static QID configurationTaskQID = new QID(";[UIA]Name='Configure'");

            /// <summary>
            /// QID for the Personalization task button
            /// </summary>
            public static QID personalizationTaskQID = new QID(";[UIA]Name='Personalize'");

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the dashboard resource qid string
            /// </summary>            
            public static QID DashboardQID
            {
                get
                {
                    QID dashboardQID = null;
                    switch (ProductSku.Sku)
                    {
                        case ProductSkuLevel.Mom:
                            dashboardQID = new QID(ResourceDashboard);
                            break;
                        case ProductSkuLevel.Web:
                        case ProductSkuLevel.SharePoint:
                            dashboardQID = new QID(ResourceDashboardWeb);
                            break;
                        default:
                            break;
                    }

                    return dashboardQID;
                }
            }
            #endregion
        }

        #endregion

        #region protected variables

        /// <summary>
        /// Used to latch on the the controls of the dashboard
        /// </summary>
        protected const int TIME_OUT = MomCommon.Constants.OneMinute;

        /// <summary>
        /// Title of the dashbaord
        /// </summary>
        protected StaticControl title;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the Dashboard class
        /// </summary>
        /// <param name="knownWindow">Window the is parent of the dashboard</param>
        public Dashboard(Window knownWindow)            
            : base(knownWindow, ControlQIDs.DashboardQID)
        {                      
            //force the GetType to use the console for it's type lookups
            Type templateType = Type.GetType("Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.TemplateA, Mom.Test.UI.Core.Console, Version=7.0.5000.0, Culture=neutral, PublicKeyToken=null");
            Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.ITemplate templateFromType = (Mom.Test.UI.Core.Console.Views.Dashboard.Wizard.ITemplate)Activator.CreateInstance(templateType);
        }

        #endregion

        #region public properties

        /// <summary>
        /// The time in milliseconds of the auto refresh interval
        /// </summary>
        public virtual int AutoRefreshInterval
        {
            get;
            protected set;
        }

        /// <summary>
        /// The dashboard task host control
        /// </summary>
        public Window TaskHost
        {
            get
            {
                if (this.taskHost == null)
                {
                    this.taskHost = new Window(
                        this,
                        Dashboard.ControlQIDs.taskHostQID,
                        TIME_OUT);
                }

                return this.taskHost;
            }
        }

        /// <summary>
        /// The Configuration button in dashboard task host
        /// </summary>
        public Button ConfigurationTaskButton
        {
            get
            {
                if (this.configurationTaskButton == null)
                {
                    this.configurationTaskButton = new Button(
                        new Window(
                            this.TaskHost,
                            Dashboard.ControlQIDs.configurationTaskQID,
                            TIME_OUT));
                }

                return this.configurationTaskButton;
            }
        }

        /// <summary>
        /// The Personalization button in dashboard task host
        /// </summary>
        public Button PersonalizationTaskButton
        {
            get
            {
                if (this.personalizationTaskButton == null)
                {
                    this.personalizationTaskButton = new Button(
                        new Window(
                            this.TaskHost,
                            Dashboard.ControlQIDs.personalizationTaskQID,
                            TIME_OUT));
                }

                return this.personalizationTaskButton;
            }
        }

        #endregion

        #region public methods

        /// <summary>
        /// This refreshes the dashboard with the sent in keys
        /// </summary>
        /// <param name="refreshKey">the refresh dashboard key sequence</param>
        public void RefreshViaKeyboard(string refreshKey)
        {
            this.SendKeys(refreshKey);
            this.WaitForResponse();
        }

        /// <summary>
        /// This waits for the dashboard to refresh automatically
        /// </summary>
        public void RefreshDashboardByAutoRefresh()
        {
            // Wait for 1.5 times the autorefresh interval.
            System.Threading.Thread.Sleep((int)(this.AutoRefreshInterval * 1.5));
        }

        #endregion

        #region IDashboardControl Members

        /// <summary>
        /// The title of the dashboard
        /// </summary>
        public StaticControl TitleText
        {
            get
            {
                if (this.title == null)
                {
                    this.title = new StaticControl(this, ControlQIDs.titleQID, TIME_OUT);
                }

                return this.title;
            }
        }

        #endregion
    }
}