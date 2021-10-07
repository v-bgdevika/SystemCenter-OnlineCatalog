// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ScheduleDialog.cs">
// 	Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
// 	Mom.Test.UI.Core.Console.
// </project>
// <summary>
// 	Provides access the Create Rule Wizard scheduler dialog.
// </summary>
// <history>
// 	[barryw] 21-Sep-05 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Performance.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IScheduleDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IScheduleDialogControls, for ScheduleDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[barryw] 21-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IScheduleDialogControls
    {
        /// <summary>
        /// Read-only property to access SelectSpecificDatesToExcludeFromTheScheduleStaticControl
        /// </summary>
        StaticControl SelectSpecificDatesToExcludeFromTheScheduleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectAndConfigureTheScheduleStaticControl
        /// </summary>
        StaticControl SelectAndConfigureTheScheduleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectAndConfigureTheScheduleComboBox
        /// </summary>
        ComboBox SelectAndConfigureTheScheduleComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DataGridView1
        /// </summary>
        PropertyGridView DataGridView1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Toolbar0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Toolbar Toolbar0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExcludeDaysButton
        /// </summary>
        Button ExcludeDaysButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ThereAreNoExcludedDaysStaticControl
        /// </summary>
        StaticControl ThereAreNoExcludedDaysStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FinishButton
        /// </summary>
        Button FinishButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HelpButton
        /// </summary>
        Button HelpButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BackButton
        /// </summary>
        Button BackButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ScheduleStaticControl
        /// </summary>
        StaticControl ScheduleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItemsStaticControl
        /// </summary>
        StaticControl YouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItemsStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[barryw] 21-Sep-05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ScheduleDialog : Dialog, IScheduleDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to SelectSpecificDatesToExcludeFromTheScheduleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectSpecificDatesToExcludeFromTheScheduleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectAndConfigureTheScheduleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectAndConfigureTheScheduleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectAndConfigureTheScheduleComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSelectAndConfigureTheScheduleComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DataGridView1 of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedDataGridView1;
        
        /// <summary>
        /// Cache to hold a reference to Toolbar0 of type Toolbar
        /// </summary>
        private Toolbar cachedToolbar0;
        
        /// <summary>
        /// Cache to hold a reference to ExcludeDaysButton of type Button
        /// </summary>
        private Button cachedExcludeDaysButton;
        
        /// <summary>
        /// Cache to hold a reference to ThereAreNoExcludedDaysStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedThereAreNoExcludedDaysStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to FinishButton of type Button
        /// </summary>
        private Button cachedFinishButton;
        
        /// <summary>
        /// Cache to hold a reference to HelpButton of type Button
        /// </summary>
        private Button cachedHelpButton;
        
        /// <summary>
        /// Cache to hold a reference to BackButton of type Button
        /// </summary>
        private Button cachedBackButton;
        
        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to ScheduleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedScheduleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to YouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItemsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedYouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItemsStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ScheduleDialog of type Mom.Test.UI.Core.Console
        /// </param>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ScheduleDialog(Mom.Test.UI.Core.Console.MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IScheduleDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IScheduleDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SelectAndConfigureTheSchedule
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SelectAndConfigureTheScheduleText
        {
            get
            {
                return this.Controls.SelectAndConfigureTheScheduleComboBox.Text;
            }
            
            set
            {
                this.Controls.SelectAndConfigureTheScheduleComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectSpecificDatesToExcludeFromTheScheduleStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScheduleDialogControls.SelectSpecificDatesToExcludeFromTheScheduleStaticControl
        {
            get
            {
                if ((this.cachedSelectSpecificDatesToExcludeFromTheScheduleStaticControl == null))
                {
                    this.cachedSelectSpecificDatesToExcludeFromTheScheduleStaticControl = new StaticControl(this, ScheduleDialog.ControlIDs.SelectSpecificDatesToExcludeFromTheScheduleStaticControl);
                }
                return this.cachedSelectSpecificDatesToExcludeFromTheScheduleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectAndConfigureTheScheduleStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScheduleDialogControls.SelectAndConfigureTheScheduleStaticControl
        {
            get
            {
                if ((this.cachedSelectAndConfigureTheScheduleStaticControl == null))
                {
                    this.cachedSelectAndConfigureTheScheduleStaticControl = new StaticControl(this, ScheduleDialog.ControlIDs.SelectAndConfigureTheScheduleStaticControl);
                }
                return this.cachedSelectAndConfigureTheScheduleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectAndConfigureTheScheduleComboBox control
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IScheduleDialogControls.SelectAndConfigureTheScheduleComboBox
        {
            get
            {
                if ((this.cachedSelectAndConfigureTheScheduleComboBox == null))
                {
                    this.cachedSelectAndConfigureTheScheduleComboBox = new ComboBox(this, ScheduleDialog.ControlIDs.SelectAndConfigureTheScheduleComboBox);
                }
                return this.cachedSelectAndConfigureTheScheduleComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataGridView1 control
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView IScheduleDialogControls.DataGridView1
        {
            get
            {
                if ((this.cachedDataGridView1 == null))
                {
                    this.cachedDataGridView1 = new PropertyGridView(this, ScheduleDialog.ControlIDs.DataGridView1);
                }
                return this.cachedDataGridView1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Toolbar0 control
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar IScheduleDialogControls.Toolbar0
        {
            get
            {
                if ((this.cachedToolbar0 == null))
                {
                    this.cachedToolbar0 = new Toolbar(this, ScheduleDialog.ControlIDs.Toolbar0);
                }
                return this.cachedToolbar0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludeDaysButton control
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScheduleDialogControls.ExcludeDaysButton
        {
            get
            {
                if ((this.cachedExcludeDaysButton == null))
                {
                    this.cachedExcludeDaysButton = new Button(this, ScheduleDialog.ControlIDs.ExcludeDaysButton);
                }
                return this.cachedExcludeDaysButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThereAreNoExcludedDaysStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScheduleDialogControls.ThereAreNoExcludedDaysStaticControl
        {
            get
            {
                if ((this.cachedThereAreNoExcludedDaysStaticControl == null))
                {
                    this.cachedThereAreNoExcludedDaysStaticControl = new StaticControl(this, ScheduleDialog.ControlIDs.ThereAreNoExcludedDaysStaticControl);
                }
                return this.cachedThereAreNoExcludedDaysStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScheduleDialogControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, ScheduleDialog.ControlIDs.FinishButton);
                }
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpButton control
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScheduleDialogControls.HelpButton
        {
            get
            {
                if ((this.cachedHelpButton == null))
                {
                    this.cachedHelpButton = new Button(this, ScheduleDialog.ControlIDs.HelpButton);
                }
                return this.cachedHelpButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BackButton control
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScheduleDialogControls.BackButton
        {
            get
            {
                if ((this.cachedBackButton == null))
                {
                    this.cachedBackButton = new Button(this, ScheduleDialog.ControlIDs.BackButton);
                }
                return this.cachedBackButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScheduleDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, ScheduleDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IScheduleDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ScheduleDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScheduleStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScheduleDialogControls.ScheduleStaticControl
        {
            get
            {
                if ((this.cachedScheduleStaticControl == null))
                {
                    this.cachedScheduleStaticControl = new StaticControl(this, ScheduleDialog.ControlIDs.ScheduleStaticControl);
                }
                return this.cachedScheduleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItemsStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IScheduleDialogControls.YouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItemsStaticControl
        {
            get
            {
                if ((this.cachedYouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItemsStaticControl == null))
                {
                    this.cachedYouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItemsStaticControl = new StaticControl(this, ScheduleDialog.ControlIDs.YouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItemsStaticControl);
                }
                return this.cachedYouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItemsStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ExcludeDays
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickExcludeDays()
        {
            this.Controls.ExcludeDaysButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Finish
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFinish()
        {
            this.Controls.FinishButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Help
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHelp()
        {
            this.Controls.HelpButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Back
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickBack()
        {
            this.Controls.BackButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">Mom.Test.UI.Core.Console owning the dialog.</param>)
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Mom.Test.UI.Core.Console.MomConsoleApp app)
        {
            Common.Utilities.LogMessage("Init(...)");
            Window tempWindow = app.GetWizardDialog(
                Strings.DialogTitle,
                Timeout);

            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Create Rule Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Wizards.Common.WizardResources;CreateRuleWizard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectSpecificDatesToExcludeFromTheSchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectSpecificDatesToExcludeFromTheSchedule = ";Select s&pecific dates to exclude from the schedule.;ManagedString;Microsoft.MOM" +
                ".UI.Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Schedu" +
                "lerFilterPage;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectAndConfigureTheSchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectAndConfigureTheSchedule = ";&Select and configure the schedule.;ManagedString;Microsoft.MOM.UI.Components.dl" +
                "l;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SchedulerFilterPage;lab" +
                "elSelectSchedule.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DataGridView1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDataGridView1 = ";dataGridView1;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterprise" +
                "Management.Internal.UI.Authoring.Pages.OperationalStatesMappingP" +
                "age;statesGridView.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExcludeDays
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExcludeDays = ";E&xclude days...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.Monitoring.Modules.Scheduler.ExcludedDaysMiniBar;b" +
                "uttonExcludeDays.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ThereAreNoExcludedDays
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThereAreNoExcludedDays = ";There are no excluded days.;ManagedString;Microsoft.MOM.UI.Components.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Monitoring.Modules.Scheduler.SchedulerR" +
                "esources;ExcludeDaysNoDataMsg";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = ";&Finish;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonFinish.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";&Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.M" +
                "om.Internal.UI.PageFrameworks.WizardFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Back
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBack = ";< &Back;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonBack.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bU;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Schedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSchedule = ";Schedule;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManag" +
                "ement.Internal.UI.Authoring.Pages.SchedulerPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  YouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItems
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceYouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItems = ";You can configure the scheduler information to determine when to accept of gener" +
                "ate items.;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMan" +
                "agement.Internal.UI.Authoring.Pages.SchedulerPage;$this.Subtitle";
            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectSpecificDatesToExcludeFromTheSchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectSpecificDatesToExcludeFromTheSchedule;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectAndConfigureTheSchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectAndConfigureTheSchedule;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DataGridView1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDataGridView1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExcludeDays
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExcludeDays;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ThereAreNoExcludedDays
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThereAreNoExcludedDays;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFinish;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Back
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Schedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSchedule;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  YouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItems
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItems;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 21-Sep-05 Created
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
            /// Exposes access to the SelectSpecificDatesToExcludeFromTheSchedule translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 21-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectSpecificDatesToExcludeFromTheSchedule
            {
                get
                {
                    if ((cachedSelectSpecificDatesToExcludeFromTheSchedule == null))
                    {
                        cachedSelectSpecificDatesToExcludeFromTheSchedule = CoreManager.MomConsole.GetIntlStr(ResourceSelectSpecificDatesToExcludeFromTheSchedule);
                    }
                    return cachedSelectSpecificDatesToExcludeFromTheSchedule;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectAndConfigureTheSchedule translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 21-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectAndConfigureTheSchedule
            {
                get
                {
                    if ((cachedSelectAndConfigureTheSchedule == null))
                    {
                        cachedSelectAndConfigureTheSchedule = CoreManager.MomConsole.GetIntlStr(ResourceSelectAndConfigureTheSchedule);
                    }
                    return cachedSelectAndConfigureTheSchedule;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DataGridView1 translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 21-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DataGridView1
            {
                get
                {
                    if ((cachedDataGridView1 == null))
                    {
                        cachedDataGridView1 = CoreManager.MomConsole.GetIntlStr(ResourceDataGridView1);
                    }
                    return cachedDataGridView1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExcludeDays translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 21-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExcludeDays
            {
                get
                {
                    if ((cachedExcludeDays == null))
                    {
                        cachedExcludeDays = CoreManager.MomConsole.GetIntlStr(ResourceExcludeDays);
                    }
                    return cachedExcludeDays;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ThereAreNoExcludedDays translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 21-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThereAreNoExcludedDays
            {
                get
                {
                    if ((cachedThereAreNoExcludedDays == null))
                    {
                        cachedThereAreNoExcludedDays = CoreManager.MomConsole.GetIntlStr(ResourceThereAreNoExcludedDays);
                    }
                    return cachedThereAreNoExcludedDays;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Finish translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 21-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Finish
            {
                get
                {
                    if ((cachedFinish == null))
                    {
                        cachedFinish = CoreManager.MomConsole.GetIntlStr(ResourceFinish);
                    }
                    return cachedFinish;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 21-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Help
            {
                get
                {
                    if ((cachedHelp == null))
                    {
                        cachedHelp = CoreManager.MomConsole.GetIntlStr(ResourceHelp);
                    }
                    return cachedHelp;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Back translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 21-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Back
            {
                get
                {
                    if ((cachedBack == null))
                    {
                        cachedBack = CoreManager.MomConsole.GetIntlStr(ResourceBack);
                    }
                    return cachedBack;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 21-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Next
            {
                get
                {
                    if ((cachedNext == null))
                    {
                        cachedNext = CoreManager.MomConsole.GetIntlStr(ResourceNext);
                    }
                    return cachedNext;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 21-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    if ((cachedCancel == null))
                    {
                        cachedCancel = CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                    }
                    return cachedCancel;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Schedule translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 21-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Schedule
            {
                get
                {
                    if ((cachedSchedule == null))
                    {
                        cachedSchedule = CoreManager.MomConsole.GetIntlStr(ResourceSchedule);
                    }
                    return cachedSchedule;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the YouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItems translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 21-Sep-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string YouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItems
            {
                get
                {
                    if ((cachedYouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItems == null))
                    {
                        cachedYouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItems = CoreManager.MomConsole.GetIntlStr(ResourceYouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItems);
                    }
                    return cachedYouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItems;
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
        /// 	[barryw] 21-Sep-05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for SelectSpecificDatesToExcludeFromTheScheduleStaticControl
            /// </summary>
            public const string SelectSpecificDatesToExcludeFromTheScheduleStaticControl = "label1";
            
            /// <summary>
            /// Control ID for SelectAndConfigureTheScheduleStaticControl
            /// </summary>
            public const string SelectAndConfigureTheScheduleStaticControl = "labelSelectSchedule";
            
            /// <summary>
            /// Control ID for SelectAndConfigureTheScheduleComboBox
            /// </summary>
            public const string SelectAndConfigureTheScheduleComboBox = "comboBoxProcessDataMode";
            
            /// <summary>
            /// Control ID for DataGridView1
            /// </summary>
            public const string DataGridView1 = "dataGridView";
            
            /// <summary>
            /// Control ID for Toolbar0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Toolbar0 = "toolStripBar";
            
            /// <summary>
            /// Control ID for ExcludeDaysButton
            /// </summary>
            public const string ExcludeDaysButton = "buttonExcludeDays";
            
            /// <summary>
            /// Control ID for ThereAreNoExcludedDaysStaticControl
            /// </summary>
            public const string ThereAreNoExcludedDaysStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for FinishButton
            /// </summary>
            public const string FinishButton = "buttonFinish";
            
            /// <summary>
            /// Control ID for HelpButton
            /// </summary>
            public const string HelpButton = "buttonHelp";
            
            /// <summary>
            /// Control ID for BackButton
            /// </summary>
            public const string BackButton = "buttonBack";
            
            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "buttonNext";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for ScheduleStaticControl
            /// </summary>
            public const string ScheduleStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for YouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItemsStaticControl
            /// </summary>
            public const string YouCanConfigureTheSchedulerInformationToDetermineWhenToAcceptOfGenerateItemsStaticControl = "labelSubtitle";
        }
        #endregion
    }
}
