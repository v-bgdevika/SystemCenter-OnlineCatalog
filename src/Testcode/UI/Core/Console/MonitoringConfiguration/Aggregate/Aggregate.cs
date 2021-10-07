// ---------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Aggregate.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	Rollup Monitor Base Class.
// </summary>
// <history>
// 	[ruhim] 21SEP05 Created
// </history>
// ---------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Aggregate
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.MomControls;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Aggregate.Dialogs;
    using Mom.Test.UI.Core.Console.Views.HealthConfiguration;
    #endregion

    /// <summary>
    /// Rollup Monitor Properties
    /// </summary>
    public class Aggregate
    {
        #region Private Members
        /// <summary>
        /// cachedgeneralPropertiesDialog
        /// </summary>
        private RollupMonitorGeneralPropertiesDialog cachedgeneralPropertiesDialog;

        /// <summary>
        /// cachedhealthRollupPolicyDialog
        /// </summary>
        private HealthRollupPolicyDialog cachedhealthRollupPolicyDialog;

        /// <summary>
        /// cachedconfigureAlertsDialog
        /// </summary>
        private ConfigureAlertsDialog cachedconfigureAlertsDialog;

        /// <summary>
        /// cachedknowledgeArticleDialog
        /// </summary>
        private KnowledgeArticleDialog cachedknowledgeArticleDialog;               

        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp;
        
        #endregion

        #region Enumerators section

        /// <summary>
        /// Define Health Rollup Policy for Aggregate Monitors
        /// </summary>
        public enum HealthRollupPolicy
        {
            /// <summary>
            /// Worst State of any member
            /// </summary>
            WorstState,

            /// <summary>
            /// Best State of any member
            /// </summary>
            BestState,
        }

        /// <summary>
        /// Define Alert Priority for Aggregate Monitors
        /// </summary>
        public enum AlertPriority
        {
            /// <summary>
            /// Low
            /// </summary>
            Low,

            /// <summary>
            /// Medium
            /// </summary>
            Medium,

            /// <summary>
            /// High
            /// </summary>
            High,
        }

        #endregion	// Enumerators section

        #region Constructor
        /// <summary>
        /// Aggregate Rollup Monitor Constructor.
        /// </summary>
        public Aggregate()
        {
            this.consoleApp = CoreManager.MomConsole;       
        }        

        #endregion

        #region Properties        

        /// <summary>
        /// General Properties Dialog for Aggregate Monitor wizard
        /// </summary>
        public RollupMonitorGeneralPropertiesDialog generalPropertiesDialog
        {
            get
            {
                if (this.cachedgeneralPropertiesDialog == null)
                {
                    this.cachedgeneralPropertiesDialog = new RollupMonitorGeneralPropertiesDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.AggregateMonitorWizard);
                    Utilities.LogMessage("Setting Focus on the General Properties Dialog was successful");
                }
                return this.cachedgeneralPropertiesDialog;
            }
        }

        /// <summary>
        /// Health Rollup Policy Dialog for Aggregate Monitor wizard
        /// </summary>
        public HealthRollupPolicyDialog healthRollupPolicyDialog
        {
            get
            {
                if (this.cachedhealthRollupPolicyDialog == null)
                {
                    this.cachedhealthRollupPolicyDialog = new HealthRollupPolicyDialog(CoreManager.MomConsole);
                    Utilities.LogMessage("Setting Focus on the Health Rollup Policy Dialog was successful");
                }
                return this.cachedhealthRollupPolicyDialog;
            }
        }

        /// <summary>
        /// Configure Alerts Dialog for Aggregate Monitor wizard
        /// </summary>
        public ConfigureAlertsDialog configureAlertsDialog
        {
            get
            {
                if (this.cachedconfigureAlertsDialog == null)
                {
                    this.cachedconfigureAlertsDialog = new ConfigureAlertsDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.AggregateMonitorWizard);
                    Utilities.LogMessage("Setting Focus on the Configure Alerts Dialog was successful");
                }
                return this.cachedconfigureAlertsDialog;
            }
        }

        /// <summary>
        /// Knowledge Article Dialog for Aggregate Monitor wizard
        /// </summary>
        public KnowledgeArticleDialog knowledgeArticleDialog
        {
            get
            {
                if (this.cachedknowledgeArticleDialog == null)
                {
                    this.cachedknowledgeArticleDialog = new KnowledgeArticleDialog(CoreManager.MomConsole, MonitoringConfiguration.WindowCaptions.AggregateMonitorWizard);
                    Utilities.LogMessage("Setting Focus on the Knowledge Article Dialog was successful");
                }
                return this.cachedknowledgeArticleDialog;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Create a new Aggregate Rollup Monitor
        /// </summary>   
        /// <param name="targetName">Class where the monitor is targetted</param>
        /// <param name="parentMonitorName">Parent Monitor for this aggregate monitor</param>
        /// <param name="aggregateMonitorName">Name of the aggregate monitor</param>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [ruhim] 09APR06 - Created        
        /// </history>
        public void Create(string targetName, string parentMonitorName, string aggregateMonitorName)
        {
            AggregateParameters parameters = new AggregateParameters();
            parameters.Target = targetName;
            parameters.ParentMonitor = parentMonitorName;
            parameters.Name = aggregateMonitorName;            
            this.Create(parameters);
        }

        /// <summary>
        /// Create a new Aggregate Rollup Monitor
        /// </summary>
        /// <param name="parameters">AggregateParameters</param>
        /// <exception cref="InvalidEnumArgumentException">InvalidEnumArgumentException</exception>
        /// <exception cref="ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [ruhim] 09APR06 - Created 
        ///     [v-vijia] 23MAR11 - Edited
        /// </history>
        public void Create(AggregateParameters parameters)
        {
            Utilities.LogMessage("Aggregate.Create::" +
                "Launch Create Aggregate Rollup Monitor Wizard");

            Utilities.LogMessage("Aggregate.Create::" +
                "Monitor Name:" + parameters.ParentMonitor +
                "Target Name:" + parameters.Target);
            #region Navigate to a parent monitor and Launch Aggregate Monitor wizard

            Core.Console.MonitoringConfiguration.Monitors monitor = new Monitors();
            monitor.LaunchCreateAggregateMonitorWizard(parameters.Target, parameters.ParentMonitor);
            Utilities.LogMessage("Aggregate.Create:: Successfully Launched the Create a new aggregate Monitor Wizard");

            #endregion

            #region Navigate through the wizard screens

            #region Set General Properties

            Utilities.LogMessage("Aggregate.Create:::: Name to be set is '" +
                parameters.Name + "'");
            this.generalPropertiesDialog.NameText = parameters.Name;

            int attempt = 0;
            int MaxTry = 3;
            while ((attempt < MaxTry) && (string.Compare(this.generalPropertiesDialog.NameText, parameters.Name) != 0))
            {
                Sleeper.Delay(Constants.OneSecond);                
                Utilities.LogMessage("Aggregate.Create:::: Failed to set Monitor name retry");
                // increase delay as we have problems here when running as Authors.
                Keyboard.SendKeysDelay = 30;

                this.generalPropertiesDialog.NameText = parameters.Name;
                attempt++;

                // Set back to default
                Keyboard.SendKeysDelay = 10;
            }           

            Utilities.LogMessage("Aggregate.Create:::: Finally set display name to '" +
                this.generalPropertiesDialog.NameText + "'");

            //Trying to set the description if its null throws System.ArgumentNullException
            if (parameters.Description != null)
            {
                this.generalPropertiesDialog.DescriptionOptionalText = parameters.Description;
                Utilities.LogMessage("Aggregate.Create:::: Set description '"
                + this.generalPropertiesDialog.DescriptionOptionalText + "'");
            }

            #region Select the target
            if(string.IsNullOrEmpty(generalPropertiesDialog.Controls.MonitorTargetTextBox.Text))
            {
                generalPropertiesDialog.ClickSelect();

                //Create a new instance for Select target dialog
                SelectTargetTypeDialog selectTargetDialog = new SelectTargetTypeDialog(CoreManager.MomConsole);
                selectTargetDialog.ScreenElement.WaitForReady();

                selectTargetDialog.Controls.ViewAllTargetsRadioButton.Click();
                ListViewItemCollection targetList = selectTargetDialog.Controls.ListView0.FindAllByText(parameters.Target);

                //The result of this collection is going to be only ONE Item
                if (targetList.Count > 0)
                {
                    targetList[0].Select();
                }

                selectTargetDialog.ScreenElement.WaitForReady();
                selectTargetDialog.ClickOK();
                CoreManager.MomConsole.WaitForDialogClose(selectTargetDialog, Constants.DefaultDialogTimeout * 4 / Constants.OneSecond);            
            }
            #endregion

            if ((parameters.MonitorEnabled) &&
                    (generalPropertiesDialog.Controls.MonitorIsEnabledCheckBox.ButtonState != ButtonState.Checked))
            {
                generalPropertiesDialog.ClickMonitorIsEnabled();
            }
            else
            {
                if ((!parameters.MonitorEnabled) &&
                (generalPropertiesDialog.Controls.MonitorIsEnabledCheckBox.ButtonState == ButtonState.Checked))
                {
                    generalPropertiesDialog.ClickMonitorIsEnabled();
                }
            }

            if (string.IsNullOrEmpty(parameters.DestinationMP))
            {
                parameters.DestinationMP = Core.Console.ConsoleConstants.DefaultManagementPackName;
            }

            this.generalPropertiesDialog.Controls.SelectDestinationManagementPackComboBox.SelectByText(parameters.DestinationMP);
            Utilities.LogMessage("Aggregate.Create:: Set Destination MP to '"
            + parameters.DestinationMP + "'");
            
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.generalPropertiesDialog.Controls.NextButton, Constants.OneMinute);
            this.generalPropertiesDialog.ClickNext();
            #endregion

            #region Set Health Rollup Policy

            if (parameters.HealthPolicy == HealthRollupPolicy.BestState)
            {
                this.healthRollupPolicyDialog.Controls.BestStateOfAnyMemberRadioButton.Click();
                Utilities.LogMessage("Aggregate.Create:: Health Rollup Policy is "
                + this.healthRollupPolicyDialog.Controls.BestStateOfAnyMemberRadioButton.ToString());
            }
            if (parameters.HealthPolicy == HealthRollupPolicy.WorstState)
            {
                this.healthRollupPolicyDialog.Controls.WorstStateOfAnyMemberRadioButton.Click();
                Utilities.LogMessage("Aggregate.Create:: Health Rollup Policy is "
                + this.healthRollupPolicyDialog.Controls.WorstStateOfAnyMemberRadioButton.ToString());
            }
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.healthRollupPolicyDialog.Controls.NextButton, Constants.OneMinute / 1000);
            this.healthRollupPolicyDialog.ClickNext();
            #endregion

            #region Configure Alert

            if ((parameters.GenerateAlert) &&
                    (this.configureAlertsDialog.Controls.GenerateAlertsCheckBox.ButtonState != ButtonState.Checked))
            {
                this.configureAlertsDialog.ClickGenerateAlerts();
                Utilities.LogMessage("Aggregate.Create:: Generate Alerts Checkbox clicked");                
            }
            else
            {
                if ((!parameters.GenerateAlert) &&
                (this.configureAlertsDialog.Controls.GenerateAlertsCheckBox.ButtonState == ButtonState.Checked))
                {
                    this.configureAlertsDialog.ClickGenerateAlerts();
                    Utilities.LogMessage("Aggregate.Create:: Generate Alerts Checkbox unchecked");
                }
            }

            if (parameters.GenerateAlert)
            {
                if ((parameters.AutoResolveAlert) &&
                        (this.configureAlertsDialog.Controls.AutomaticallyResolveAlertCheckBox.ButtonState != ButtonState.Checked))
                {
                    this.configureAlertsDialog.ClickAutomaticallyResolveAlert();
                    Utilities.LogMessage("Aggregate.Create:: Auto Resolve the alerts checked");
                }
                else
                {
                    if ((!parameters.AutoResolveAlert) &&
                        (this.configureAlertsDialog.Controls.AutomaticallyResolveAlertCheckBox.ButtonState == ButtonState.Checked))
                    {
                        this.configureAlertsDialog.ClickAutomaticallyResolveAlert();
                        Utilities.LogMessage("Aggregate.Create:: Auto Resolve the alerts unchecked");
                    }
                }

                switch(parameters.Priority)
                {
                    case AlertPriority.High:
                        this.configureAlertsDialog.Controls.PriorityComboBox.SelectByText(Monitors.Strings.AlertPriorityHigh);
                        break;
                    case AlertPriority.Medium:
                        this.configureAlertsDialog.Controls.PriorityComboBox.SelectByText(Monitors.Strings.AlertPriorityMedium);
                        break;
                    case AlertPriority.Low:
                        this.configureAlertsDialog.Controls.PriorityComboBox.SelectByText(Monitors.Strings.AlertPriorityLow);
                        break;
                }
                Utilities.LogMessage("Aggregate.Create:: Alert priority set to " + parameters.Priority);
            }
            this.configureAlertsDialog.ClickNext();
            #endregion

            //Complete the wizard by clicking on Create
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.knowledgeArticleDialog.Controls.CreateButton, Constants.OneMinute);
            this.knowledgeArticleDialog.ClickCreate();

            CoreManager.MomConsole.WaitForDialogClose(this.knowledgeArticleDialog, 60);

            int retry = 0;
            int maxcount = 120;
            while (!CoreManager.MomConsole.MainWindow.Extended.IsForeground && retry <= maxcount)
            {
                Utilities.LogMessage("Aggregate.Create:: MainWindow not Foreground, lets wait a moment.");
                Sleeper.Delay(1000);
                retry++;
            }
            UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout * 2);
            consoleApp.Waiters.WaitForStatusReady();
            Utilities.LogMessage("Aggregate.Create:: Successfully completed the wizard");


            #endregion
        }        
                
        #endregion

        #region Private Methods
        /// <summary>
        /// Rollup Monitor parameters structure.
        /// </summary>
        /// <param name="parameters">AggregateParameters</param>
        /// <returns>Parameters</returns>
        /// <history>
        ///		[ruhim] 21SEP05 Created
        /// </history>
        private static AggregateParameters UpdateParameters(AggregateParameters parameters)
        {
            Utilities.LogMessage("Aggregate.UpdateParameters:: ");

            return parameters;
        }

        #endregion

        #region AggregateParameters Class

        /// <summary>
        /// Parameters class for Aggregate constructors.
        /// </summary>
        /// <history>
        /// [ruhim] 21Sep05 Created
        /// </history>
        public class AggregateParameters
        {
            #region Private Members
            private string cachedTarget = null;
            private string cachedParentMonitor = null;
            private string cachedName = null;
            private string cachedDescription = null;            
            private string cachedDestinationMP = null;
            private HealthRollupPolicy cachedHealthPolicy;
            private bool cachedMonitorEnabled = true;
            private bool cachedGenerateAlert = true;
            private bool cachedAutoResolveAlert = false;
            private AlertPriority cachedPriority;
            #endregion

            #region Constructors
            /// <summary>
            /// Default Constructor - no need in ExePath etc. Inherited classes
            /// from Console set all required properties on parameter objects.
            /// </summary>
            public AggregateParameters()
            {
            }
            #endregion

            #region Properties

            /// <summary>
            /// Class where the monitor is targetted
            /// </summary>
            public string Target
            {
                get
                {
                    return this.cachedTarget;
                }

                set
                {
                    this.cachedTarget = value;
                }
            }

            /// <summary>
            /// Parent Monitor for this aggregate monitor
            /// </summary>
            public string ParentMonitor
            {
                get
                {
                    return this.cachedParentMonitor;
                }

                set
                {
                    this.cachedParentMonitor = value;
                }
            }

            /// <summary>
            /// Name of Rollup Monitor
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
            /// Description of Rollup Monitor
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
            /// Destination Management Pack for Rollup Monitor
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
            /// Rollup Mechanism for Aggregate Rollup Monitor
            /// </summary>
            public HealthRollupPolicy HealthPolicy
            {
                get
                {
                    return this.cachedHealthPolicy;
                }

                set
                {
                    this.cachedHealthPolicy = value;
                }
            }

            /// <summary>
            /// Bool indicating the monitor is enabled or not
            /// </summary>
            public bool MonitorEnabled
            {
                get
                {
                    return this.cachedMonitorEnabled;
                }

                set
                {
                    this.cachedMonitorEnabled = value;
                }
            }

            /// <summary>
            /// Bool indicating whether the monitor should generate alert or not
            /// </summary>
            public bool GenerateAlert
            {
                get
                {
                    return this.cachedGenerateAlert;
                }
                set
                {
                    this.cachedGenerateAlert = value;
                }
            }

            /// <summary>
            /// Bool indicating whether the monitor should automatically resolve alert or not
            /// </summary>
            public bool AutoResolveAlert
            {
                get
                {
                    return this.cachedAutoResolveAlert;
                }
                set
                {
                    this.cachedAutoResolveAlert = value;
                }
            }

            /// <summary>
            /// Rollup Mechanism for Aggregate Rollup Monitor
            /// </summary>
            public AlertPriority Priority
            {
                get
                {
                    return this.cachedPriority;
                }

                set
                {
                    this.cachedPriority = value;
                }
            }

            #endregion
        }

        #endregion //AggregateParameters

        #region Strings

        /// <summary>
        /// Strings Class
        /// </summary>
        public class Strings
        {
            #region Constants
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Aggregate Monitor Wizard dialog title
            /// </summary>            
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle =
                ";Create a new aggregate rollup monitor;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorTypes.MonitorTypeResources;CreateAggregateMonitorWizard";            

            /// <summary>
            /// Worst state of any member
            /// </summary>
            private const string ResourceWorstRollup = 
                ";Worst state of any member;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AggregateMonitorSheet;WorstOf";

            /// <summary>
            /// Best state of any member
            /// </summary>
            private const string ResourceBestRollup =
                ";Best state of any member;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AggregateMonitorSheet;BestOf";

            #endregion

            #region Private Members
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;
            

            /// <summary>
            /// Cached Worst state of any member String
            /// </summary>
            private static string cachedWorstRollup;

            /// <summary>
            /// Cached Best state of any member String
            /// </summary>
            private static string cachedBestRollup;

            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }
                    return cachedDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Worst state of any member 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 21SEP05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WorstRollup
            {
                get
                {
                    if ((cachedWorstRollup == null))
                    {
                        cachedWorstRollup = CoreManager.MomConsole.GetIntlStr(ResourceWorstRollup);
                    }
                    return cachedWorstRollup;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Best state of any member 
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 21SEP05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BestRollup
            {
                get
                {
                    if ((cachedBestRollup == null))
                    {
                        cachedBestRollup = CoreManager.MomConsole.GetIntlStr(ResourceBestRollup);
                    }
                    return cachedBestRollup;
                }
            }

            #endregion
        }

        #endregion

    }
}
