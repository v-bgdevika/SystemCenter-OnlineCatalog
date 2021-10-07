// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DotNETMonitor.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 UI Test Automation
// </project>
// <summary>
// 	.NET Monitor Base Class.
// </summary>
// <history>
// 	[faizalk]   10JUL06     Created
// </history>
// ---------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.DotNETMonitor
{

    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.DotNETMonitor.Dialogs;
    #endregion

    /// <summary>
    /// Class to add general methods for .NET Monitor/Template
    /// </summary>
    /// <history> 	
    ///   [faizalk]  Created
    /// </history>
    public class DotNETMonitor
    {
        #region Private Constants               

        //Column position for the URL in Select Discovered Item dialog
        private const int actualServiceNameColPos = 3;

        #endregion

        #region Private Members

        /// <summary>
        /// cachedComponentTypeDialog
        /// </summary>
        private SelectComponentTypeDialog cachedComponentTypeDialog;

        /// <summary>
        /// cachedgeneralPropertiesTemplateDialog
        /// </summary>
        private GeneralPropertiesDialog cachedgeneralPropertiesTemplateDialog;

        /// <summary>
        /// cachedAddNewDialog
        /// </summary>
        private AddNewDialog cachedAddNewDialog;

        /// <summary>
        /// cachedDiscoveryMethodDialog
        /// </summary>
        private DiscoveryMethodDialog cachedDiscoveryMethodDialog;

        /// <summary>
        /// cachedExceptionsCriteriaDialog
        /// </summary>
        private ExceptionsCriteriaDialog cachedExceptionsCriteriaDialog;

        /// <summary>
        /// cachedPerformanceCriteriaDialog
        /// </summary>
        private PerformanceCriteriaDialog cachedPerformanceCriteriaDialog;

        /// <summary>
        /// cachedSelectDiscoveredDialog
        /// </summary>
        private SelectDiscoveredDialog cachedSelectDiscoveredDialog;

        /// <summary>
        /// cachedSettingsSummaryDialog
        /// </summary>
        private Core.Console.MonitoringConfiguration.DotNETMonitor.Dialogs.SettingsSummaryDialog cachedSettingsSummaryDialog;

        #region Enumerators section

        /// <summary>
        /// Valid ASP.NET types
        /// </summary>
        public enum ASPNET
        {
            /// <summary>
            /// WebApplication
            /// </summary>
            WebApplication,

            /// <summary>
            /// WebService
            /// </summary>
            WebService,
        }

        /// <summary>
        /// Valid Sample Interval Units
        /// </summary>
        public enum SampleIntervalUnit
        {
            /// <summary>
            /// Seconds
            /// </summary>
            Seconds,

            /// <summary>
            /// Minutes
            /// </summary>
            Minutes,

            /// <summary>
            /// Hours
            /// </summary>
            Hours,

            /// <summary>
            /// Days
            /// </summary>
            Days,
        }

        /// <summary>
        /// Valid Discovery Types
        /// </summary>
        public enum DiscoveryType
        {
            /// <summary>
            /// SelectDiscovered
            /// </summary>
            SelectDiscovered,

            /// <summary>
            /// AddNew
            /// </summary>
            AddNew
        }

        #endregion	// Enumerators section

        #endregion

        #region Properties

        /// <summary>
        /// Select Component Type Dialog
        /// The first screen of the Create Component wizard.
        /// </summary>
        public SelectComponentTypeDialog componentTypeDialog
        {
            get
            {
                if (this.cachedComponentTypeDialog == null)
                {
                    this.cachedComponentTypeDialog = new SelectComponentTypeDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Select Component Type Dialog was successful");
                }

                return this.cachedComponentTypeDialog;
            }
        }

        /// <summary>
        /// General Properties Dialog
        /// The Second screen of the Create Component wizard.
        /// </summary>
        public GeneralPropertiesDialog generalPropertiesTemplateDialog
        {
            get
            {
                if (this.cachedgeneralPropertiesTemplateDialog == null)
                {
                    this.cachedgeneralPropertiesTemplateDialog = new GeneralPropertiesDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.MonitoringTemplateWizard);
                    Utilities.LogMessage("Setting Focus on the General Properties Dialog was successful");
                }

                return this.cachedgeneralPropertiesTemplateDialog;
            }
        }

        /// <summary>
        /// AddNewDialog
        /// The third screen of the Create Component wizard.
        /// </summary>
        public AddNewDialog addNewDialog
        {
            get
            {
                if (this.cachedAddNewDialog == null)
                {
                    this.cachedAddNewDialog = new AddNewDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the AddNewDialog was successful");
                }

                return this.cachedAddNewDialog;
            }
        }

        /// <summary>
        /// DiscoveryMethodDialog
        /// </summary>
        public DiscoveryMethodDialog discoveryMethodDialog
        {
            get
            {
                if (this.cachedDiscoveryMethodDialog == null)
                {
                    this.cachedDiscoveryMethodDialog = new DiscoveryMethodDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the DiscoveryMethodDialog was successful");
                }

                return this.cachedDiscoveryMethodDialog;
            }
        }

        /// <summary>
        /// ExceptionsCriteriaDialog
        /// </summary>
        public ExceptionsCriteriaDialog exceptionsCriteriaDialog
        {
            get
            {
                if (this.cachedExceptionsCriteriaDialog == null)
                {
                    this.cachedExceptionsCriteriaDialog = new ExceptionsCriteriaDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the ExceptionsCriteriaDialog was successful");
                }

                return this.cachedExceptionsCriteriaDialog;
            }
        }

        /// <summary>
        /// PerformanceCriteriaDialog
        /// </summary>
        public PerformanceCriteriaDialog performanceCriteriaDialog
        {
            get
            {
                if (this.cachedPerformanceCriteriaDialog == null)
                {
                    this.cachedPerformanceCriteriaDialog = new PerformanceCriteriaDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the PerformanceCriteriaDialog was successful");
                }

                return this.cachedPerformanceCriteriaDialog;
            }
        }

        /// <summary>
        /// SelectDiscoveredDialog
        /// </summary>
        public SelectDiscoveredDialog selectDiscoveredDialog
        {
            get
            {
                if (this.cachedSelectDiscoveredDialog == null)
                {
                    this.cachedSelectDiscoveredDialog = new SelectDiscoveredDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the SelectDiscoveredDialog was successful");
                }

                return this.cachedSelectDiscoveredDialog;
            }
        }

        /// <summary>
        /// Settings Summary Dialog
        /// </summary>
        public Core.Console.MonitoringConfiguration.DotNETMonitor.Dialogs.SettingsSummaryDialog settingsSummaryDialog
        {
            get
            {
                if (this.cachedSettingsSummaryDialog == null)
                {
                    this.cachedSettingsSummaryDialog = new Core.Console.MonitoringConfiguration.DotNETMonitor.Dialogs.SettingsSummaryDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Settings Summary Dialog was successful");
                }

                return this.cachedSettingsSummaryDialog;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Create a new ASP.NET Monitored component
        /// </summary>
        /// <param name="parameters">DotNETParameters</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [faizalk] 07JUL06 - Created   
        /// </history>
        public void CreateComponent(DotNETParameters parameters)
        {
            Utilities.LogMessage("DotNETParameters.CreateComponent::" +
                "Launch Create Component Wizard");

            #region Launch Template Wizard

            // Get Reference to Actions Pane. And select the wizard from the actions pane.
            ActionsPane actionsPane = CoreManager.MomConsole.ActionsPane;
            string monitoredComponentsPath = NavigationPane.Strings.MonitoringConfiguration
                + Constants.PathDelimiter + NavigationPane.Strings.MonConfigTreeViewMonitoredComponents;
            actionsPane.ClickLink(
                NavigationPane.WunderBarButton.MonitoringConfiguration,
                monitoredComponentsPath,
                ActionsPane.Strings.ActionsPaneMonitoredComponents,
                Templates.Strings.LaunchComponentWizardTask);

            Utilities.LogMessage("DotNETParameters.CreateComponent:: Selected "
                + Templates.Strings.LaunchComponentWizardTask);

            // Based on the Type parameter; Select the component Type 
            string typeSelected;

            switch(parameters.ASPNETtemplate)
            {
                case DotNETMonitor.ASPNET.WebApplication:
                    typeSelected = SelectComponentTypeDialog.Strings.ASPNETApplicationTemplate;
                    break;

                case DotNETMonitor.ASPNET.WebService:
                    typeSelected = SelectComponentTypeDialog.Strings.ASPNETWebServiceTemplate;
                    break;

                default:
                    throw new InvalidEnumArgumentException(parameters.ASPNETtemplate + " is an invalid ASPNETtemplate enum!");
            }

            #endregion Launch Template Wizard

            #region Navigate through all the screens of the Wizard

            #region Select Monitoring Type

            this.componentTypeDialog.App.BringToForeground();
            Maui.Core.WinControls.TreeNode myNode = null;
            myNode = this.componentTypeDialog.Controls.SelectComponentTypeTreeView.Find(typeSelected);
            Utilities.LogMessage("DotNETMonitor.CreateComponent:: Found component type '" + typeSelected + "'");

            myNode.Select();
            Utilities.LogMessage("DotNETMonitor.CreateComponent:: Successfully selected component type '" +
                typeSelected + "'");
            myNode.Click();
            UISynchronization.WaitForProcessReady(this.componentTypeDialog);
            this.componentTypeDialog.WaitForResponse();
            UISynchronization.WaitForProcessReady(this.componentTypeDialog, 60000);
            UISynchronization.WaitForUIObjectReady(this.componentTypeDialog, 60000);
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.componentTypeDialog.Controls.NextButton, Constants.OneMinute);

            Utilities.LogMessage("DotNETMonitor.CreateComponent:: Successfully clicked on component type");

            this.componentTypeDialog.WaitForResponse();
            this.componentTypeDialog.ClickNext();

            #endregion Select Monitoring Type

            #region General Properties

            this.generalPropertiesTemplateDialog.WaitForResponse();

            // Enter the General Properties
            // Trying to set the name -- if its null throws System.ArgumentNullException
            if (null != parameters.Name)
            {
                this.generalPropertiesTemplateDialog.NameText = parameters.Name;
                Utilities.LogMessage("DotNETMonitor.CreateComponent:: Set display name '" +
                    this.generalPropertiesTemplateDialog.NameText + "'");
            }
            else
            {
                throw new System.ArgumentNullException("DotNETMonitorParameters.Name cannot be null!");
            }

            if (null != parameters.Description)
            {
                this.generalPropertiesTemplateDialog.DescriptionText = parameters.Description;
                Utilities.LogMessage("DotNETMonitor.CreateComponent:: Set description '"
                + this.generalPropertiesTemplateDialog.DescriptionText + "'");
            }

            if (null != parameters.DestinationMP)
            {
                this.generalPropertiesTemplateDialog.Controls.SelectDestinationManagementPackComboBox.SelectByText(parameters.DestinationMP);
            }
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.generalPropertiesTemplateDialog.Controls.NextButton, Constants.OneMinute);
            this.generalPropertiesTemplateDialog.ClickNext();

            #endregion General Properties

            #region Discovery Method

            this.discoveryMethodDialog.WaitForResponse();

            if (parameters.DiscoveryType == DiscoveryType.AddNew)
            {
                this.discoveryMethodDialog.Controls.AddNewASPNETApplicationRadioButton.Click();
            }
            else if (parameters.DiscoveryType == DiscoveryType.SelectDiscovered)
            {
                this.discoveryMethodDialog.Controls.SelectADiscoveredASPNETApplicationRadioButton.Click();
            }

            if (parameters.RestartIIS)
            {
                if (!this.discoveryMethodDialog.Controls.RestartIISCheckBox.Checked)
                {
                    this.discoveryMethodDialog.Controls.RestartIISCheckBox.Click();
                }
            }
            else
            {
                if (this.discoveryMethodDialog.Controls.RestartIISCheckBox.Checked)
                {
                    this.discoveryMethodDialog.Controls.RestartIISCheckBox.Click();
                }
            }

            this.discoveryMethodDialog.ClickNext();

            #endregion Discovery Method

            #region ASP.NET Application
            if (parameters.DiscoveryType == DiscoveryType.AddNew)
            {
                // add new app
                this.addNewDialog.WaitForResponse();
                this.addNewDialog.Controls.HelpTextBox.Text = parameters.ApplicationVRoot;
                this.addNewDialog.Controls.DiscoveryTypeTextBox2.Text = parameters.IISApplicationName;
                this.addNewDialog.Controls.DiscoveryTypeTextBox.Text = parameters.AppName;
                this.addNewDialog.ClickNext();
            }
            else if (parameters.DiscoveryType == DiscoveryType.SelectDiscovered)
            {
                // select discovered entity
                this.selectDiscoveredDialog.WaitForResponse();

                int maxRetries = 10;
                int count = 0;
                ListView listView = null;
                while (listView == null && count < maxRetries)
                {
                    try
                    {
                        // this is the most ridiculously long variable name i've ever seen
                        listView = this.selectDiscoveredDialog.Controls.NoteYourChangesWillNotTakeEffectUntilYouRestartIISYouCanDoItOnCompletetionOfTheTemplateProcessOrRest;
                    } catch (Maui.Core.Window.Exceptions.WindowNotFoundException wnfe)
                    {
                        Utilities.LogMessage(wnfe.Message);
                    } finally
                    {
                        Utilities.LogMessage("Attempt + " + count + " of " + maxRetries + " to locate listView");
                        count++;
                    }
                }
                                
                bool found = CoreManager.MomConsole.SelectListViewItems(parameters.URL, actualServiceNameColPos, listView, false);

                if (!found == true)
                {
                    throw new ListView.Exceptions.ItemNotFoundException("Could not find \"" + parameters.IISApplicationName + "\" in ListView");
                }
                
                this.selectDiscoveredDialog.ClickNext();
            }
            else
            {
                // discoveryType invalid
                throw new InvalidEnumArgumentException(parameters.DiscoveryType + " is an invalid DiscoveryType enum!");
            }

            #endregion ASP.NET Application

            #region Exceptions Criteria

            this.exceptionsCriteriaDialog.WaitForResponse();

            if (parameters.ExceptionEnabled)
            {
                this.exceptionsCriteriaDialog.ClickEnableErrorExceptionCountMonitoring();
                this.exceptionsCriteriaDialog.ThresholdValuesText = parameters.ExceptionWarningThreshold;
                this.exceptionsCriteriaDialog.ComboBox0Text = parameters.ExceptionErrorThreshold;
                this.exceptionsCriteriaDialog.IntervalText = parameters.ExceptionSampleTimeInterval;
                /*this.exceptionsCriteriaDialog.Controls.ThresholdValuesComboBox.Text.Remove(0);
                this.exceptionsCriteriaDialog.Controls.ThresholdValuesComboBox.SendKeys(parameters.ExceptionWarningThreshold);
                this.exceptionsCriteriaDialog.Controls.ComboBox0.Text.Remove(0);
                this.exceptionsCriteriaDialog.Controls.ComboBox0.SendKeys(parameters.ExceptionErrorThreshold);
                this.exceptionsCriteriaDialog.Controls.IntervalComboBox.Text.Remove(0);
                this.exceptionsCriteriaDialog.Controls.IntervalComboBox.SendKeys(parameters.ExceptionSampleTimeInterval);

                // Based on the sample inteveral unit parameter; Select the time units 
                string sampleUnits = null;
                switch (parameters.ExceptionSampleTimeIntervalUnit)
                {
                    case SampleIntervalUnit.Seconds:
                        sampleUnits = MonitoringConfiguration.Strings.RunThisQueryEverySeconds;
                        break;

                    case SampleIntervalUnit.Minutes:
                        sampleUnits = MonitoringConfiguration.Strings.RunThisQueryEveryMinutes;
                        break;

                    case SampleIntervalUnit.Hours:
                        sampleUnits = MonitoringConfiguration.Strings.RunThisQueryEveryHours;
                        break;

                    case SampleIntervalUnit.Days:
                        sampleUnits = MonitoringConfiguration.Strings.RunThisQueryEveryDays;
                        break;

                    default:
                        Utilities.LogMessage("DotNETMonitor.CreateComponent:: SampleIntervalUnit parameter: '" +
                            parameters.ExceptionSampleTimeIntervalUnit + "' is invalid");
                        throw new InvalidEnumArgumentException(parameters.ExceptionSampleTimeIntervalUnit + "is an invalid SampleIntervalUnit!");
                }

                this.exceptionsCriteriaDialog.Controls.SampleTimeIntervalComboBox.SelectByText(sampleUnits);
                 * */
            }
            this.exceptionsCriteriaDialog.ClickNext();

            #endregion Exceptions Criteria

            #region Performance Criteria

            this.performanceCriteriaDialog.WaitForResponse();

            if (parameters.PerformanceEnabled)
            {
                this.performanceCriteriaDialog.ClickEnablePerformanceEventMonitoring();
                this.performanceCriteriaDialog.WarningThreshold2Text = parameters.PerformanceWarningThreshold;
                this.performanceCriteriaDialog.WarningThresholdText = parameters.PerformanceExceptionThreshold;
                this.performanceCriteriaDialog.SampleTimeInterval2Text = parameters.PerformanceResponseTime;
                this.performanceCriteriaDialog.IntervalText = parameters.PerformanceSampleTimeInterval;
                /*
                this.performanceCriteriaDialog.Controls.WarningThresholdComboBox2.Text.Remove(0);
                this.performanceCriteriaDialog.Controls.WarningThresholdComboBox2.SendKeys(parameters.PerformanceWarningThreshold);
                this.performanceCriteriaDialog.Controls.WarningThresholdComboBox.Text.Remove(0);
                this.performanceCriteriaDialog.Controls.WarningThresholdComboBox.SendKeys(parameters.PerformanceExceptionThreshold);
                this.performanceCriteriaDialog.Controls.SampleTimeIntervalComboBox2.Text.Remove(0);
                this.performanceCriteriaDialog.Controls.SampleTimeIntervalComboBox2.SendKeys(parameters.PerformanceResponseTime);
                this.performanceCriteriaDialog.Controls.IntervalComboBox.Text.Remove(0);
                this.performanceCriteriaDialog.Controls.IntervalComboBox.SendKeys(parameters.PerformanceSampleTimeInterval);

                // Based on the sample inteveral unit parameter; Select the time units 
                string sampleUnits = null;
                switch (parameters.PerformanceSampleTimeIntervalUnit)
                {
                    case SampleIntervalUnit.Seconds:
                        sampleUnits = MonitoringConfiguration.Strings.RunThisQueryEverySeconds;
                        break;

                    case SampleIntervalUnit.Minutes:
                        sampleUnits = MonitoringConfiguration.Strings.RunThisQueryEveryMinutes;
                        break;

                    case SampleIntervalUnit.Hours:
                        sampleUnits = MonitoringConfiguration.Strings.RunThisQueryEveryHours;
                        break;

                    case SampleIntervalUnit.Days:
                        sampleUnits = MonitoringConfiguration.Strings.RunThisQueryEveryDays;
                        break;

                    default:
                        Utilities.LogMessage("DotNETMonitor.CreateComponent:: SampleIntervalUnit parameter: '" +
                            parameters.PerformanceSampleTimeIntervalUnit + "' is invalid");
                        throw new InvalidEnumArgumentException(parameters.ExceptionSampleTimeIntervalUnit + "is an invalid SampleIntervalUnit!");
                }

                this.performanceCriteriaDialog.Controls.SampleTimeIntervalComboBox.SelectByText(sampleUnits);
            */}
            this.performanceCriteriaDialog.ClickNext();

            #endregion Performance Criteria

            #region Settings Summary

            this.settingsSummaryDialog.WaitForResponse();
            this.settingsSummaryDialog.ClickCreate();
            CoreManager.MomConsole.WaitForDialogClose(this.settingsSummaryDialog, 180);

            #endregion Settings Summary

            #endregion Navigate through all the screens of the Wizard

            #region Verify Component Created

            Templates templates = new Templates();
            Templates.ComponentType templateType;

            if(parameters.ASPNETtemplate == ASPNET.WebApplication)
            {
                templateType = Templates.ComponentType.ASPNETApplication;
            } else if(parameters.ASPNETtemplate == ASPNET.WebService)
            {
                templateType = Templates.ComponentType.ASPNETWebService;
            } else
            {
                throw new InvalidEnumArgumentException(parameters.ASPNETtemplate + " is not a valid ASPNETtemplate enum!");
            }

            if (templates.ComponentExists(templateType, parameters.Name))
            {
                Utilities.LogMessage("DotNETMonitor.CreateComponent:: Found " + parameters.Name + " in Monitored Components view");
            }
            else
            {
                throw new Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException("Failed to find " + parameters.Name + " in Monitored Components view");
            }

            #endregion          
        }

        #endregion

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Strings class
        /// </summary>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// TimeoutDialogTitle
            /// </summary>
            public static string ResourceTimeoutDialogTitle = ";Task Results;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.PagesURLTemplatePage.UrlTemplateResource;TaskTimeOutCaption";

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  "Task Results"
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTimeoutDialogTitle;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the "Task Results"
            /// </summary>
            /// <history>
            /// 	[faizalk] 28APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TimeoutDialogTitle
            {
                get
                {
                    if ((cachedTimeoutDialogTitle == null))
                    {
                        cachedTimeoutDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceTimeoutDialogTitle);
                    }

                    return cachedTimeoutDialogTitle;
                }
            }
            #endregion
        }
        #endregion

        #region DotNETParameters Class
        /// <summary>
        /// Parameters class for DotNETMonitor constructors.
        /// </summary>
        /// <history>
        /// [faizalk] 27MAR06 Created
        /// </history>
        public class DotNETParameters
        {
            #region Private Members
            // screen 1
            private DotNETMonitor.ASPNET cachedASPNETtemplate;

            // screen 2
            private string cachedName;
            private string cachedDescription;
            private string cachedDestinationMP;
            private DotNETMonitor.DiscoveryType cachedDiscoveryType;
            private bool cachedRestartIIS;

            // screen 3
            private string cachedApplicationVRoot;
            private string cachedIISApplicationName;
            private string cachedAppName;
            private string cachedURL;

            // screen 4
            private bool cachedExceptionEnabled;
            private string cachedExceptionWarningThreshold;
            private string cachedExceptionErrorThreshold;
            private string cachedExceptionSampleTimeInterval;
            private DotNETMonitor.SampleIntervalUnit cachedExceptionSampleTimeIntervalUnit;

            // screen 5
            private bool cachedPerformanceEnabled;
            private string cachedPerformanceWarningThreshold;
            private string cachedPerformanceExceptionThreshold;
            private string cachedPerformanceResponseTime;
            private string cachedPerformanceSampleTimeInterval;
            private DotNETMonitor.SampleIntervalUnit cachedPerformanceSampleTimeIntervalUnit;

            #endregion

            #region Properties

            /// <summary>
            /// ASPNETtemplate type
            /// </summary>
            public DotNETMonitor.ASPNET ASPNETtemplate
            {
                get
                {
                    return this.cachedASPNETtemplate;
                }

                set
                {
                    this.cachedASPNETtemplate = value;
                }
            }

            /// <summary>
            /// Display Name
            /// </summary>
            public string Name
            {
                get
                {
                    return this.cachedName;
                }

                set
                {
                    this.cachedName = value;
                }
            }

            /// <summary>
            /// Description 
            /// </summary>
            public string Description
            {
                get
                {
                    return this.cachedDescription;
                }

                set
                {
                    this.cachedDescription = value;
                }
            }

            /// <summary>
            /// Destination MP 
            /// </summary>
            public string DestinationMP
            {
                get
                {
                    return this.cachedDestinationMP;
                }

                set
                {
                    this.cachedDestinationMP = value;
                }
            }

            /// <summary>
            /// whether to select discovered or enter new
            /// </summary>
            public DotNETMonitor.DiscoveryType DiscoveryType
            {
                get
                {
                    return this.cachedDiscoveryType;
                }

                set
                {
                    this.cachedDiscoveryType = value;
                }
            }

            /// <summary>
            /// whether to restart IIS
            /// </summary>
            public bool RestartIIS
            {
                get
                {
                    return this.cachedRestartIIS;
                }

                set
                {
                    this.cachedRestartIIS = value;
                }
            }

            /// <summary>
            /// ApplicationVRoot
            /// </summary>
            public string ApplicationVRoot
            {
                get
                {
                    return this.cachedApplicationVRoot;
                }

                set
                {
                    this.cachedApplicationVRoot = value;
                }
            }

            /// <summary>
            /// IISApplicationName
            /// </summary>
            public string IISApplicationName
            {
                get
                {
                    return this.cachedIISApplicationName;
                }

                set
                {
                    this.cachedIISApplicationName = value;
                }
            }

            /// <summary>
            /// AppName
            /// </summary>
            public string AppName
            {
                get
                {
                    return this.cachedAppName;
                }

                set
                {
                    this.cachedAppName = value;
                }
            }

            /// <summary>
            /// URL
            /// </summary>
            public string URL
            {
                get
                {
                    return this.cachedURL;
                }

                set
                {
                    this.cachedURL = value;
                }
            }

            /// <summary>
            /// ExceptionEnabled
            /// </summary>
            public bool ExceptionEnabled
            {
                get
                {
                    return this.cachedExceptionEnabled;
                }

                set
                {
                    this.cachedExceptionEnabled = value;
                }
            }

            /// <summary>
            /// ExceptionWarningThreshold
            /// </summary>
            public string ExceptionWarningThreshold
            {
                get
                {
                    return this.cachedExceptionWarningThreshold;
                }

                set
                {
                    this.cachedExceptionWarningThreshold = value;
                }
            }

            /// <summary>
            /// ExceptionErrorThreshold
            /// </summary>
            public string ExceptionErrorThreshold
            {
                get
                {
                    return this.cachedExceptionErrorThreshold;
                }

                set
                {
                    this.cachedExceptionErrorThreshold = value;
                }
            }

            /// <summary>
            /// ExceptionSampleTimeInterval
            /// </summary>
            public string ExceptionSampleTimeInterval
            {
                get
                {
                    return this.cachedExceptionSampleTimeInterval;
                }

                set
                {
                    this.cachedExceptionSampleTimeInterval = value;
                }
            }

            /// <summary>
            /// ExceptionSampleTimeIntervalUnit
            /// </summary>
            public DotNETMonitor.SampleIntervalUnit ExceptionSampleTimeIntervalUnit
            {
                get
                {
                    return this.cachedExceptionSampleTimeIntervalUnit;
                }

                set
                {
                    this.cachedExceptionSampleTimeIntervalUnit = value;
                }
            }

            /// <summary>
            /// PerformanceEnabled
            /// </summary>
            public bool PerformanceEnabled
            {
                get
                {
                    return this.cachedPerformanceEnabled;
                }

                set
                {
                    this.cachedPerformanceEnabled = value;
                }
            }
            
            /// <summary>
            /// PerformanceWarningThreshold
            /// </summary>
            public string PerformanceWarningThreshold
            {
                get
                {
                    return this.cachedPerformanceWarningThreshold;
                }

                set
                {
                    this.cachedPerformanceWarningThreshold = value;
                }
            }

            /// <summary>
            /// PerformanceExceptionThreshold
            /// </summary>
            public string PerformanceExceptionThreshold
            {
                get
                {
                    return this.cachedPerformanceExceptionThreshold;
                }

                set
                {
                    this.cachedPerformanceExceptionThreshold = value;
                }
            }
            
            /// <summary>
            /// PerformanceResponseTime
            /// </summary>
            public string PerformanceResponseTime
            {
                get
                {
                    return this.cachedPerformanceResponseTime;
                }

                set
                {
                    this.cachedPerformanceResponseTime = value;
                }
            }

            /// <summary>
            /// PerformanceSampleTimeInterval
            /// </summary>
            public string PerformanceSampleTimeInterval
            {
                get
                {
                    return this.cachedPerformanceSampleTimeInterval;
                }

                set
                {
                    this.cachedPerformanceSampleTimeInterval = value;
                }
            }

            /// <summary>
            /// PerformanceSampleTimeIntervalUnit
            /// </summary>
            public DotNETMonitor.SampleIntervalUnit PerformanceSampleTimeIntervalUnit
            {
                get
                {
                    return this.cachedPerformanceSampleTimeIntervalUnit;
                }

                set
                {
                    this.cachedPerformanceSampleTimeIntervalUnit = value;
                }
            }

            #endregion
        }
        #endregion
    } // end of class DotNETParameters
} // end of namespace