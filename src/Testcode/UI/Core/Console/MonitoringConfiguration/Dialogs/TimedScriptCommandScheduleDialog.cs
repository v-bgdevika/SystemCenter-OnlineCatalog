// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="TimedTimedScriptCommandScheduleDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	MOMv3 UI Console
// </project>
// <summary>
// 	Expose access to the schedule dialog when creating timed script/command rule
// </summary>
// <history>
// 	[barryli] 09July07 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    #endregion
    
    #region Radio Group Enumeration - TimedScheduleRadioGroup0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group TimedScheduleRadioGroup0
    /// </summary>
    /// <history>
    /// 	[barryli] 09July07 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum TimedScheduleRadioGroup0
    {
        /// <summary>
        /// BasedOnFixedSimpleRecurringSchedule = 0
        /// </summary>
        BasedOnFixedSimpleRecurringSchedule = 0,
        
        /// <summary>
        /// BaseOnFixedWeeklySchedule = 1
        /// </summary>
        BaseOnFixedWeeklySchedule = 1,
    }
    #endregion
    
    #region Interface Definition - ITimedTimedScriptCommandScheduleDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ITimedTimedScriptCommandScheduleDialogControls, for TimedScriptCommandScheduleDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[barryli] 09July07 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ITimedScriptCommandScheduleDialogControls
    {
        /// <summary>
        /// Read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
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
        /// Read-only property to access CreateButton
        /// </summary>
        Button CreateButton
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
        /// Read-only property to access RuleTypeStaticControl
        /// </summary>
        StaticControl RuleTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GeneralStaticControl
        /// </summary>
        StaticControl GeneralStaticControl
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
        /// Read-only property to access ScriptStaticControl
        /// </summary>
        StaticControl ScriptStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExcludeSpecificDatesStaticControl
        /// </summary>
        StaticControl ExcludeSpecificDatesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureYourScheduleStaticControl
        /// </summary>
        StaticControl ConfigureYourScheduleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PeriodStaticControl
        /// </summary>
        StaticControl PeriodStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComboBox0
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox ComboBox0
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Spinner1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Spinner Spinner1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SynchronizeAtCheckBox
        /// </summary>
        CheckBox SynchronizeAtCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComboBox2
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox ComboBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PeriodComboBox
        /// </summary>
        ComboBox PeriodComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BasedOnFixedSimpleRecurringScheduleRadioButton
        /// </summary>
        RadioButton BasedOnFixedSimpleRecurringScheduleRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BaseOnFixedWeeklyScheduleRadioButton
        /// </summary>
        RadioButton BaseOnFixedWeeklyScheduleRadioButton
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
        /// Read-only property to access Toolbar3
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Toolbar Toolbar3
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
        /// Read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyYourScheduleSettingsStaticControl
        /// </summary>
        StaticControl SpecifyYourScheduleSettingsStaticControl
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
    /// 	[barryli] 09July07 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class TimedScriptCommandScheduleDialog : Dialog, ITimedScriptCommandScheduleDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to PreviousButton of type Button
        /// </summary>
        private Button cachedPreviousButton;
        
        /// <summary>
        /// Cache to hold a reference to NextButton of type Button
        /// </summary>
        private Button cachedNextButton;
        
        /// <summary>
        /// Cache to hold a reference to CreateButton of type Button
        /// </summary>
        private Button cachedCreateButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to RuleTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRuleTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ScheduleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedScheduleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ScriptStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedScriptStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExcludeSpecificDatesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExcludeSpecificDatesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureYourScheduleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureYourScheduleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PeriodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPeriodStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ComboBox0 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox0;
        
        /// <summary>
        /// Cache to hold a reference to Spinner1 of type Spinner
        /// </summary>
        private Spinner cachedSpinner1;
        
        /// <summary>
        /// Cache to hold a reference to SynchronizeAtCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedSynchronizeAtCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to ComboBox2 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox2;
        
        /// <summary>
        /// Cache to hold a reference to PeriodComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedPeriodComboBox;
        
        /// <summary>
        /// Cache to hold a reference to BasedOnFixedSimpleRecurringScheduleRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedBasedOnFixedSimpleRecurringScheduleRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to BaseOnFixedWeeklyScheduleRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedBaseOnFixedWeeklyScheduleRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to DataGridView1 of type PropertyGridView
        /// </summary>
        private PropertyGridView cachedDataGridView1;
        
        /// <summary>
        /// Cache to hold a reference to Toolbar3 of type Toolbar
        /// </summary>
        private Toolbar cachedToolbar3;
        
        /// <summary>
        /// Cache to hold a reference to ExcludeDaysButton of type Button
        /// </summary>
        private Button cachedExcludeDaysButton;
        
        /// <summary>
        /// Cache to hold a reference to ThereAreNoExcludedDaysStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedThereAreNoExcludedDaysStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyYourScheduleSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyYourScheduleSettingsStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ScriptSCheduleDialog of type ScriptSCheduleDialog
        /// </param>
        /// <param name='windowCaption'>windows caption</param>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public TimedScriptCommandScheduleDialog(MomConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
            :
                base(app, Init(app, windowCaption))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group TimedScheduleRadioGroup0
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual TimedScheduleRadioGroup0 TimedScheduleRadioGroup0
        {
            get
            {
                if ((this.Controls.BasedOnFixedSimpleRecurringScheduleRadioButton.ButtonState == ButtonState.Checked))
                {
                    return TimedScheduleRadioGroup0.BasedOnFixedSimpleRecurringSchedule;
                }
                
                if ((this.Controls.BaseOnFixedWeeklyScheduleRadioButton.ButtonState == ButtonState.Checked))
                {
                    return TimedScheduleRadioGroup0.BaseOnFixedWeeklySchedule;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == TimedScheduleRadioGroup0.BasedOnFixedSimpleRecurringSchedule))
                {
                    this.Controls.BasedOnFixedSimpleRecurringScheduleRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == TimedScheduleRadioGroup0.BaseOnFixedWeeklySchedule))
                    {
                        this.Controls.BaseOnFixedWeeklyScheduleRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region ITimedScriptCommandScheduleDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ITimedScriptCommandScheduleDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox SynchronizeAt
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool SynchronizeAt
        {
            get
            {
                return this.Controls.SynchronizeAtCheckBox.Checked;
            }
            
            set
            {
                this.Controls.SynchronizeAtCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ComboBox0
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComboBox0Text
        {
            get
            {
                return this.Controls.ComboBox0.Text;
            }
            
            set
            {
                this.Controls.ComboBox0.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ComboBox2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComboBox2Text
        {
            get
            {
                return this.Controls.ComboBox2.Text;
            }
            
            set
            {
                this.Controls.ComboBox2.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Period
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PeriodText
        {
            get
            {
                return this.Controls.PeriodComboBox.Text;
            }
            
            set
            {
                this.Controls.PeriodComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITimedScriptCommandScheduleDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, TimedScriptCommandScheduleDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITimedScriptCommandScheduleDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, TimedScriptCommandScheduleDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITimedScriptCommandScheduleDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, TimedScriptCommandScheduleDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITimedScriptCommandScheduleDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, TimedScriptCommandScheduleDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITimedScriptCommandScheduleDialogControls.RuleTypeStaticControl
        {
            get
            {
                if ((this.cachedRuleTypeStaticControl == null))
                {
                    this.cachedRuleTypeStaticControl = new StaticControl(this, TimedScriptCommandScheduleDialog.ControlIDs.RuleTypeStaticControl);
                }
                
                return this.cachedRuleTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITimedScriptCommandScheduleDialogControls.GeneralStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGeneralStaticControl == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedGeneralStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedGeneralStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScheduleStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITimedScriptCommandScheduleDialogControls.ScheduleStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedScheduleStaticControl == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedScheduleStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedScheduleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScriptStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITimedScriptCommandScheduleDialogControls.ScriptStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedScriptStaticControl == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedScriptStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedScriptStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludeSpecificDatesStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITimedScriptCommandScheduleDialogControls.ExcludeSpecificDatesStaticControl
        {
            get
            {
                if ((this.cachedExcludeSpecificDatesStaticControl == null))
                {
                    this.cachedExcludeSpecificDatesStaticControl = new StaticControl(this, TimedScriptCommandScheduleDialog.ControlIDs.ExcludeSpecificDatesStaticControl);
                }
                
                return this.cachedExcludeSpecificDatesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureYourScheduleStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITimedScriptCommandScheduleDialogControls.ConfigureYourScheduleStaticControl
        {
            get
            {
                if ((this.cachedConfigureYourScheduleStaticControl == null))
                {
                    this.cachedConfigureYourScheduleStaticControl = new StaticControl(this, TimedScriptCommandScheduleDialog.ControlIDs.ConfigureYourScheduleStaticControl);
                }
                
                return this.cachedConfigureYourScheduleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PeriodStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITimedScriptCommandScheduleDialogControls.PeriodStaticControl
        {
            get
            {
                if ((this.cachedPeriodStaticControl == null))
                {
                    this.cachedPeriodStaticControl = new StaticControl(this, TimedScriptCommandScheduleDialog.ControlIDs.PeriodStaticControl);
                }
                
                return this.cachedPeriodStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox0 control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ITimedScriptCommandScheduleDialogControls.ComboBox0
        {
            get
            {
                if ((this.cachedComboBox0 == null))
                {
                    this.cachedComboBox0 = new ComboBox(this, TimedScriptCommandScheduleDialog.ControlIDs.ComboBox0);
                }
                
                return this.cachedComboBox0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Spinner1 control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Spinner ITimedScriptCommandScheduleDialogControls.Spinner1
        {
            get
            {
                if ((this.cachedSpinner1 == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedSpinner1 = new Spinner(wndTemp);
                }
                
                return this.cachedSpinner1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SynchronizeAtCheckBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox ITimedScriptCommandScheduleDialogControls.SynchronizeAtCheckBox
        {
            get
            {
                if ((this.cachedSynchronizeAtCheckBox == null))
                {
                    this.cachedSynchronizeAtCheckBox = new CheckBox(this, TimedScriptCommandScheduleDialog.ControlIDs.SynchronizeAtCheckBox);
                }
                
                return this.cachedSynchronizeAtCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox2 control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ITimedScriptCommandScheduleDialogControls.ComboBox2
        {
            get
            {
                if ((this.cachedComboBox2 == null))
                {
                    this.cachedComboBox2 = new ComboBox(this, TimedScriptCommandScheduleDialog.ControlIDs.ComboBox2);
                }
                
                return this.cachedComboBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PeriodComboBox control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ITimedScriptCommandScheduleDialogControls.PeriodComboBox
        {
            get
            {
                if ((this.cachedPeriodComboBox == null))
                {
                    this.cachedPeriodComboBox = new ComboBox(this, TimedScriptCommandScheduleDialog.ControlIDs.PeriodComboBox);
                }
                
                return this.cachedPeriodComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BasedOnFixedSimpleRecurringScheduleRadioButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ITimedScriptCommandScheduleDialogControls.BasedOnFixedSimpleRecurringScheduleRadioButton
        {
            get
            {
                if ((this.cachedBasedOnFixedSimpleRecurringScheduleRadioButton == null))
                {
                    this.cachedBasedOnFixedSimpleRecurringScheduleRadioButton = new RadioButton(this, TimedScriptCommandScheduleDialog.ControlIDs.BasedOnFixedSimpleRecurringScheduleRadioButton);
                }
                
                return this.cachedBasedOnFixedSimpleRecurringScheduleRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BaseOnFixedWeeklyScheduleRadioButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ITimedScriptCommandScheduleDialogControls.BaseOnFixedWeeklyScheduleRadioButton
        {
            get
            {
                if ((this.cachedBaseOnFixedWeeklyScheduleRadioButton == null))
                {
                    this.cachedBaseOnFixedWeeklyScheduleRadioButton = new RadioButton(this, TimedScriptCommandScheduleDialog.ControlIDs.BaseOnFixedWeeklyScheduleRadioButton);
                }
                
                return this.cachedBaseOnFixedWeeklyScheduleRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DataGridView1 control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        PropertyGridView ITimedScriptCommandScheduleDialogControls.DataGridView1
        {
            get
            {
                if ((this.cachedDataGridView1 == null))
                {
                    this.cachedDataGridView1 = new PropertyGridView(this, TimedScriptCommandScheduleDialog.ControlIDs.DataGridView1);
                }
                
                return this.cachedDataGridView1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Toolbar3 control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Toolbar ITimedScriptCommandScheduleDialogControls.Toolbar3
        {
            get
            {
                if ((this.cachedToolbar3 == null))
                {
                    this.cachedToolbar3 = new Toolbar(this, TimedScriptCommandScheduleDialog.ControlIDs.Toolbar3);
                }
                
                return this.cachedToolbar3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExcludeDaysButton control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ITimedScriptCommandScheduleDialogControls.ExcludeDaysButton
        {
            get
            {
                if ((this.cachedExcludeDaysButton == null))
                {
                    this.cachedExcludeDaysButton = new Button(this, TimedScriptCommandScheduleDialog.ControlIDs.ExcludeDaysButton);
                }
                
                return this.cachedExcludeDaysButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThereAreNoExcludedDaysStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITimedScriptCommandScheduleDialogControls.ThereAreNoExcludedDaysStaticControl
        {
            get
            {
                if ((this.cachedThereAreNoExcludedDaysStaticControl == null))
                {
                    this.cachedThereAreNoExcludedDaysStaticControl = new StaticControl(this, TimedScriptCommandScheduleDialog.ControlIDs.ThereAreNoExcludedDaysStaticControl);
                }
                
                return this.cachedThereAreNoExcludedDaysStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITimedScriptCommandScheduleDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, TimedScriptCommandScheduleDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyYourScheduleSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ITimedScriptCommandScheduleDialogControls.SpecifyYourScheduleSettingsStaticControl
        {
            get
            {
                if ((this.cachedSpecifyYourScheduleSettingsStaticControl == null))
                {
                    this.cachedSpecifyYourScheduleSettingsStaticControl = new StaticControl(this, TimedScriptCommandScheduleDialog.ControlIDs.SpecifyYourScheduleSettingsStaticControl);
                }
                
                return this.cachedSpecifyYourScheduleSettingsStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickPrevious()
        {
            this.Controls.PreviousButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Next
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Create
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCreate()
        {
            this.Controls.CreateButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SynchronizeAt
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSynchronizeAt()
        {
            this.Controls.SynchronizeAtCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ExcludeDays
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickExcludeDays()
        {
            this.Controls.ExcludeDaysButton.Click();
        }
        #endregion

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">owning the dialog.</param>)
        ///  <param name="windowCaption">window caption</param>)
        /// <history>
        /// 	[barryli] 09JULY07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app, MonitoringConfiguration.WindowCaptions windowCaption)
        {

            string DialogTitle = MonitoringConfiguration.GetWindowCaption(windowCaption);
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                tempWindow = null;
                int numberOfTries = 0;
                const int MaxTries = 5;
                while (tempWindow == null && numberOfTries < MaxTries)
                {
                    numberOfTries++;
                    try
                    {
                        // look for the window again using wildcards
                        tempWindow =
                            new Window(
                                DialogTitle + "*", StringMatchSyntax.WildCard);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Core.Common.Utilities.LogMessage(
                            "Attempt " + numberOfTries + " of " + MaxTries);
                    }
                }


                // check for success
                if ((null == tempWindow))
                {
                    // log the failure
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" + DialogTitle + "'");
                    // rethrow the original exception
                    throw ex;
                }
            }

            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = "Create Rule Wizard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;previousButt" +
                "on.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Mic" +
                "rosoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;nextButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";C&reate;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CreateMP" +
                "Action";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RuleType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRuleType = ";Rule Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseRuleTypePage;$this.Navi" +
                "gationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;GeneralP" +
                "ropertyPageTabText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Schedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSchedule = ";Schedule;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micr" +
                "osoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.DeviceSch" +
                "edulePage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Script
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceScript = ";Script;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.Propert" +
                "ies.Resources;ScriptName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExcludeSpecificDates
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExcludeSpecificDates = ";Exclude specific dates:;ManagedString;Microsoft.EnterpriseManagement.UI.Authorin" +
                "g.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SchedulerPage;p" +
                "ageSectionLabelExcludeDays.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureYourSchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureYourSchedule = ";Configure your schedule:;ManagedString;Microsoft.EnterpriseManagement.UI.Authori" +
                "ng.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SchedulerPage;" +
                "pageSectionLabelSchedule.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Period
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePeriod = ";&Period:;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDia" +
                "log.SeriesFormulasProperties;labelPeriod.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SynchronizeAt
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSynchronizeAt = ";S&ynchronize at:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.SimpleRecurringControl" +
                ";checkBoxSync.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BasedOnFixedSimpleRecurringSchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBasedOnFixedSimpleRecurringSchedule = ";Based on fixed &simple recurring schedule;ManagedString;Microsoft.EnterpriseMana" +
                "gement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pag" +
                "es.SchedulerPage;radioButtonSimpleRecurring.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BaseOnFixedWeeklySchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBaseOnFixedWeeklySchedule = ";Base on fixed &weekly schedule;ManagedString;Microsoft.EnterpriseManagement.UI.A" +
                "uthoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Schedule" +
                "rPage;radioButtonWeekly.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DataGridView1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDataGridView1 = ";dataGridView1;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micr" +
                "osoft.EnterpriseManagement.Internal.UI.Authoring.Pages.OperationalStatesMappingP" +
                "age;statesGridView.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExcludeDays
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExcludeDays = ";E&xclude days...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ExcludedDaysMiniBar;bu" +
                "ttonExcludeDays.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ThereAreNoExcludedDays
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceThereAreNoExcludedDays = ";There are no excluded days.;ManagedString;Microsoft.EnterpriseManagement.UI.Auth" +
                "oring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Scheduler.S" +
                "chedulerResources;ExcludeDaysNoDataMsg";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsof" +
                "t.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;HelpSubFold" +
                "erName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyYourScheduleSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyYourScheduleSettings = ";Specify your schedule settings.;ManagedString;Microsoft.EnterpriseManagement.UI." +
                "Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Schedul" +
                "erPage;$this.HeaderText";
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
            /// Caches the translated resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPrevious;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNext;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreate;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RuleType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRuleType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Schedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSchedule;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Script
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedScript;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExcludeSpecificDates
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExcludeSpecificDates;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureYourSchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureYourSchedule;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Period
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPeriod;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SynchronizeAt
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSynchronizeAt;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BasedOnFixedSimpleRecurringSchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBasedOnFixedSimpleRecurringSchedule;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BaseOnFixedWeeklySchedule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBaseOnFixedWeeklySchedule;
            
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
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyYourScheduleSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyYourScheduleSettings;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
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
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Previous
            {
                get
                {
                    if ((cachedPrevious == null))
                    {
                        cachedPrevious = CoreManager.MomConsole.GetIntlStr(ResourcePrevious);
                    }
                    
                    return cachedPrevious;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Next translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
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
            /// Exposes access to the Create translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Create
            {
                get
                {
                    if ((cachedCreate == null))
                    {
                        cachedCreate = CoreManager.MomConsole.GetIntlStr(ResourceCreate);
                    }
                    
                    return cachedCreate;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
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
            /// Exposes access to the RuleType translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RuleType
            {
                get
                {
                    if ((cachedRuleType == null))
                    {
                        cachedRuleType = CoreManager.MomConsole.GetIntlStr(ResourceRuleType);
                    }
                    
                    return cachedRuleType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string General
            {
                get
                {
                    if ((cachedGeneral == null))
                    {
                        cachedGeneral = CoreManager.MomConsole.GetIntlStr(ResourceGeneral);
                    }
                    
                    return cachedGeneral;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Schedule translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
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
            /// Exposes access to the Script translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Script
            {
                get
                {
                    if ((cachedScript == null))
                    {
                        cachedScript = CoreManager.MomConsole.GetIntlStr(ResourceScript);
                    }
                    
                    return cachedScript;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExcludeSpecificDates translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExcludeSpecificDates
            {
                get
                {
                    if ((cachedExcludeSpecificDates == null))
                    {
                        cachedExcludeSpecificDates = CoreManager.MomConsole.GetIntlStr(ResourceExcludeSpecificDates);
                    }
                    
                    return cachedExcludeSpecificDates;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureYourSchedule translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureYourSchedule
            {
                get
                {
                    if ((cachedConfigureYourSchedule == null))
                    {
                        cachedConfigureYourSchedule = CoreManager.MomConsole.GetIntlStr(ResourceConfigureYourSchedule);
                    }
                    
                    return cachedConfigureYourSchedule;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Period translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Period
            {
                get
                {
                    if ((cachedPeriod == null))
                    {
                        cachedPeriod = CoreManager.MomConsole.GetIntlStr(ResourcePeriod);
                    }
                    
                    return cachedPeriod;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SynchronizeAt translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SynchronizeAt
            {
                get
                {
                    if ((cachedSynchronizeAt == null))
                    {
                        cachedSynchronizeAt = CoreManager.MomConsole.GetIntlStr(ResourceSynchronizeAt);
                    }
                    
                    return cachedSynchronizeAt;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BasedOnFixedSimpleRecurringSchedule translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BasedOnFixedSimpleRecurringSchedule
            {
                get
                {
                    if ((cachedBasedOnFixedSimpleRecurringSchedule == null))
                    {
                        cachedBasedOnFixedSimpleRecurringSchedule = CoreManager.MomConsole.GetIntlStr(ResourceBasedOnFixedSimpleRecurringSchedule);
                    }
                    
                    return cachedBasedOnFixedSimpleRecurringSchedule;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BaseOnFixedWeeklySchedule translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BaseOnFixedWeeklySchedule
            {
                get
                {
                    if ((cachedBaseOnFixedWeeklySchedule == null))
                    {
                        cachedBaseOnFixedWeeklySchedule = CoreManager.MomConsole.GetIntlStr(ResourceBaseOnFixedWeeklySchedule);
                    }
                    
                    return cachedBaseOnFixedWeeklySchedule;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DataGridView1 translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
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
            /// 	[barryli] 09July07 Created
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
            /// 	[barryli] 09July07 Created
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
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
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
            /// Exposes access to the SpecifyYourScheduleSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[barryli] 09July07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyYourScheduleSettings
            {
                get
                {
                    if ((cachedSpecifyYourScheduleSettings == null))
                    {
                        cachedSpecifyYourScheduleSettings = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyYourScheduleSettings);
                    }
                    
                    return cachedSpecifyYourScheduleSettings;
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
        /// 	[barryli] 09July07 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for PreviousButton
            /// </summary>
            public const string PreviousButton = "previousButton";
            
            /// <summary>
            /// Control ID for NextButton
            /// </summary>
            public const string NextButton = "nextButton";
            
            /// <summary>
            /// Control ID for CreateButton
            /// </summary>
            public const string CreateButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for RuleTypeStaticControl
            /// </summary>
            public const string RuleTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ScheduleStaticControl
            /// </summary>
            public const string ScheduleStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ScriptStaticControl
            /// </summary>
            public const string ScriptStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ExcludeSpecificDatesStaticControl
            /// </summary>
            public const string ExcludeSpecificDatesStaticControl = "pageSectionLabelExcludeDays";
            
            /// <summary>
            /// Control ID for ConfigureYourScheduleStaticControl
            /// </summary>
            public const string ConfigureYourScheduleStaticControl = "pageSectionLabelSchedule";
            
            /// <summary>
            /// Control ID for PeriodStaticControl
            /// </summary>
            public const string PeriodStaticControl = "labelPeriod";
            
            /// <summary>
            /// Control ID for ComboBox0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ComboBox0 = "dateTimePickerHour";
            
            /// <summary>
            /// Control ID for SynchronizeAtCheckBox
            /// </summary>
            public const string SynchronizeAtCheckBox = "checkBoxSync";
            
            /// <summary>
            /// Control ID for ComboBox2
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ComboBox2 = "comboBoxUnit";
            
            /// <summary>
            /// Control ID for PeriodComboBox
            /// </summary>
            public const string PeriodComboBox = "numericUpDownInterval";
            
            /// <summary>
            /// Control ID for BasedOnFixedSimpleRecurringScheduleRadioButton
            /// </summary>
            public const string BasedOnFixedSimpleRecurringScheduleRadioButton = "radioButtonSimpleRecurring";
            
            /// <summary>
            /// Control ID for BaseOnFixedWeeklyScheduleRadioButton
            /// </summary>
            public const string BaseOnFixedWeeklyScheduleRadioButton = "radioButtonWeekly";
            
            /// <summary>
            /// Control ID for DataGridView1
            /// </summary>
            public const string DataGridView1 = "dataGridView";
            
            /// <summary>
            /// Control ID for Toolbar3
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Toolbar3 = "toolStripBar";
            
            /// <summary>
            /// Control ID for ExcludeDaysButton
            /// </summary>
            public const string ExcludeDaysButton = "buttonExcludeDays";
            
            /// <summary>
            /// Control ID for ThereAreNoExcludedDaysStaticControl
            /// </summary>
            public const string ThereAreNoExcludedDaysStaticControl = "labelDescription";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for SpecifyYourScheduleSettingsStaticControl
            /// </summary>
            public const string SpecifyYourScheduleSettingsStaticControl = "headerLabel";
        }
        #endregion
    }
}
