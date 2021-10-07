// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="BaseliningConfigurationDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[mbickle] 29APR06 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Performance.Dialogs
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    #endregion

    #region Interface Definition - IBaseliningConfigurationDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IBaseliningConfigurationDialogControls, for BaseliningConfigurationDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 29APR06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IBaseliningConfigurationDialogControls
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
        /// Read-only property to access MonitorTypeStaticControl
        /// </summary>
        StaticControl MonitorTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PerformanceCounterStaticControl
        /// </summary>
        StaticControl PerformanceCounterStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BaseliningConfigurationStaticControl
        /// </summary>
        StaticControl BaseliningConfigurationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureHealthStaticControl
        /// </summary>
        StaticControl ConfigureHealthStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureAlertsStaticControl
        /// </summary>
        StaticControl ConfigureAlertsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access KnowledgeStaticControl
        /// </summary>
        StaticControl KnowledgeStaticControl
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
        /// Read-only property to access BusinessCycleUnitComboBox
        /// </summary>
        EditComboBox BusinessCycleUnitComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AdvancedButton
        /// </summary>
        Button AdvancedButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AlertingStaticControl
        /// </summary>
        StaticControl AlertingStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfigureBusinessCycleStaticControl
        /// </summary>
        StaticControl ConfigureBusinessCycleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HighStaticControl
        /// </summary>
        StaticControl HighStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LowStaticControl
        /// </summary>
        StaticControl LowStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SensitivityStaticControl
        /// </summary>
        StaticControl SensitivityStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LowTrackBar
        /// </summary>
        TrackBar LowTrackBar
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BusinessCylesOfAnalysisStaticControl
        /// </summary>
        StaticControl BusinessCylesOfAnalysisStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BeginGeneratingAlertsAfterTextBox
        /// </summary>
        TextBox BeginGeneratingAlertsAfterTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BusinessCycleLengthInGivenUnitTextBox
        /// </summary>
        TextBox BusinessCycleLengthInGivenUnitTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BeginGeneratingAlertsAfterStaticControl
        /// </summary>
        StaticControl BeginGeneratingAlertsAfterStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BusinessCycleStaticControl
        /// </summary>
        StaticControl BusinessCycleStaticControl
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
        /// Read-only property to access ConfigureTheBaselineValuesUsedToDetermineTheThresholdsStaticControl
        /// </summary>
        StaticControl ConfigureTheBaselineValuesUsedToDetermineTheThresholdsStaticControl
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
    /// 	[mbickle] 29APR06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class BaseliningConfigurationDialog : Dialog, IBaseliningConfigurationDialogControls
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
        /// Cache to hold a reference to MonitorTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitorTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PerformanceCounterStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPerformanceCounterStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BaseliningConfigurationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBaseliningConfigurationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureHealthStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureHealthStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureAlertsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureAlertsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to KnowledgeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedKnowledgeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BusinessCycleUnitComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedBusinessCycleUnitComboBox;
        
        /// <summary>
        /// Cache to hold a reference to AdvancedButton of type Button
        /// </summary>
        private Button cachedAdvancedButton;
        
        /// <summary>
        /// Cache to hold a reference to AlertingStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAlertingStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureBusinessCycleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureBusinessCycleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HighStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHighStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LowStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLowStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SensitivityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSensitivityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LowTrackBar of type TrackBar
        /// </summary>
        private TrackBar cachedLowTrackBar;
        
        /// <summary>
        /// Cache to hold a reference to BusinessCylesOfAnalysisStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBusinessCylesOfAnalysisStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BeginGeneratingAlertsAfterTextBox of type TextBox
        /// </summary>
        private TextBox cachedBeginGeneratingAlertsAfterTextBox;
        
        /// <summary>
        /// Cache to hold a reference to BusinessCycleLengthInGivenUnitTextBox of type TextBox
        /// </summary>
        private TextBox cachedBusinessCycleLengthInGivenUnitTextBox;
        
        /// <summary>
        /// Cache to hold a reference to BeginGeneratingAlertsAfterStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBeginGeneratingAlertsAfterStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BusinessCycleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedBusinessCycleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureTheBaselineValuesUsedToDetermineTheThresholdsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureTheBaselineValuesUsedToDetermineTheThresholdsStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of BaseliningConfigurationDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public BaseliningConfigurationDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IBaseliningConfigurationDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IBaseliningConfigurationDialogControls Controls
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
        ///  Routine to set/get the text in control ConfigureBusinessCycle
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string BusinessCycleUnit
        {
            get
            {
                return this.Controls.BusinessCycleUnitComboBox.Text;
            }
            
            set
            {
                this.Controls.BusinessCycleUnitComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control BeginGeneratingAlertsAfter
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string BeginGeneratingAlertsAfterText
        {
            get
            {
                return this.Controls.BeginGeneratingAlertsAfterTextBox.Text;
            }
            
            set
            {
                this.Controls.BeginGeneratingAlertsAfterTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control BusinessCycle
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string BusinessCycleLengthInGivenUnit
        {
            get
            {
                return this.Controls.BusinessCycleLengthInGivenUnitTextBox.Text;
            }
            
            set
            {
                this.Controls.BusinessCycleLengthInGivenUnitTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBaseliningConfigurationDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, BaseliningConfigurationDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBaseliningConfigurationDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, BaseliningConfigurationDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBaseliningConfigurationDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, BaseliningConfigurationDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBaseliningConfigurationDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, BaseliningConfigurationDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaseliningConfigurationDialogControls.MonitorTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitorTypeStaticControl == null))
                {
                    this.cachedMonitorTypeStaticControl = new StaticControl(this, BaseliningConfigurationDialog.ControlIDs.MonitorTypeStaticControl);
                }
                return this.cachedMonitorTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PerformanceCounterStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaseliningConfigurationDialogControls.PerformanceCounterStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedPerformanceCounterStaticControl == null))
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
                    this.cachedPerformanceCounterStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedPerformanceCounterStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BaseliningConfigurationStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaseliningConfigurationDialogControls.BaseliningConfigurationStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedBaseliningConfigurationStaticControl == null))
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
                    this.cachedBaseliningConfigurationStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedBaseliningConfigurationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureHealthStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaseliningConfigurationDialogControls.ConfigureHealthStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureHealthStaticControl == null))
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
                    this.cachedConfigureHealthStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedConfigureHealthStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAlertsStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaseliningConfigurationDialogControls.ConfigureAlertsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureAlertsStaticControl == null))
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
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedConfigureAlertsStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedConfigureAlertsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the KnowledgeStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaseliningConfigurationDialogControls.KnowledgeStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedKnowledgeStaticControl == null))
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
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedKnowledgeStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedKnowledgeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaseliningConfigurationDialogControls.GeneralStaticControl
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
                    for (i = 0; (i <= 5); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedGeneralStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedGeneralStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BusinessCycleUnitComboBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IBaseliningConfigurationDialogControls.BusinessCycleUnitComboBox
        {
            get
            {
                if ((this.cachedBusinessCycleUnitComboBox == null))
                {
                    this.cachedBusinessCycleUnitComboBox = new EditComboBox(this, BaseliningConfigurationDialog.ControlIDs.BusinessCycleUnitComboBox);
                }
                return this.cachedBusinessCycleUnitComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdvancedButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IBaseliningConfigurationDialogControls.AdvancedButton
        {
            get
            {
                if ((this.cachedAdvancedButton == null))
                {
                    this.cachedAdvancedButton = new Button(this, BaseliningConfigurationDialog.ControlIDs.AdvancedButton);
                }
                return this.cachedAdvancedButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AlertingStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaseliningConfigurationDialogControls.AlertingStaticControl
        {
            get
            {
                if ((this.cachedAlertingStaticControl == null))
                {
                    this.cachedAlertingStaticControl = new StaticControl(this, BaseliningConfigurationDialog.ControlIDs.AlertingStaticControl);
                }
                return this.cachedAlertingStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureBusinessCycleStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaseliningConfigurationDialogControls.ConfigureBusinessCycleStaticControl
        {
            get
            {
                if ((this.cachedConfigureBusinessCycleStaticControl == null))
                {
                    this.cachedConfigureBusinessCycleStaticControl = new StaticControl(this, BaseliningConfigurationDialog.ControlIDs.ConfigureBusinessCycleStaticControl);
                }
                return this.cachedConfigureBusinessCycleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HighStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaseliningConfigurationDialogControls.HighStaticControl
        {
            get
            {
                if ((this.cachedHighStaticControl == null))
                {
                    this.cachedHighStaticControl = new StaticControl(this, BaseliningConfigurationDialog.ControlIDs.HighStaticControl);
                }
                return this.cachedHighStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LowStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaseliningConfigurationDialogControls.LowStaticControl
        {
            get
            {
                if ((this.cachedLowStaticControl == null))
                {
                    this.cachedLowStaticControl = new StaticControl(this, BaseliningConfigurationDialog.ControlIDs.LowStaticControl);
                }
                return this.cachedLowStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SensitivityStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaseliningConfigurationDialogControls.SensitivityStaticControl
        {
            get
            {
                if ((this.cachedSensitivityStaticControl == null))
                {
                    this.cachedSensitivityStaticControl = new StaticControl(this, BaseliningConfigurationDialog.ControlIDs.SensitivityStaticControl);
                }
                return this.cachedSensitivityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LowTrackBar control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TrackBar IBaseliningConfigurationDialogControls.LowTrackBar
        {
            get
            {
                if ((this.cachedLowTrackBar == null))
                {
                    this.cachedLowTrackBar = new TrackBar(this, BaseliningConfigurationDialog.ControlIDs.LowTrackBar);
                }
                return this.cachedLowTrackBar;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BusinessCylesOfAnalysisStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaseliningConfigurationDialogControls.BusinessCylesOfAnalysisStaticControl
        {
            get
            {
                if ((this.cachedBusinessCylesOfAnalysisStaticControl == null))
                {
                    this.cachedBusinessCylesOfAnalysisStaticControl = new StaticControl(this, BaseliningConfigurationDialog.ControlIDs.BusinessCylesOfAnalysisStaticControl);
                }
                return this.cachedBusinessCylesOfAnalysisStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BeginGeneratingAlertsAfterTextBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IBaseliningConfigurationDialogControls.BeginGeneratingAlertsAfterTextBox
        {
            get
            {
                if ((this.cachedBeginGeneratingAlertsAfterTextBox == null))
                {
                    this.cachedBeginGeneratingAlertsAfterTextBox = new TextBox(this, BaseliningConfigurationDialog.ControlIDs.BeginGeneratingAlertsAfterTextBox);
                }
                return this.cachedBeginGeneratingAlertsAfterTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BusinessCycleLengthInGivenUnitTextBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IBaseliningConfigurationDialogControls.BusinessCycleLengthInGivenUnitTextBox
        {
            get
            {
                if ((this.cachedBusinessCycleLengthInGivenUnitTextBox == null))
                {
                    this.cachedBusinessCycleLengthInGivenUnitTextBox = new TextBox(this, BaseliningConfigurationDialog.ControlIDs.BusinessCycleLengthInGivenUnitTextBox);
                }
                return this.cachedBusinessCycleLengthInGivenUnitTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BeginGeneratingAlertsAfterStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaseliningConfigurationDialogControls.BeginGeneratingAlertsAfterStaticControl
        {
            get
            {
                if ((this.cachedBeginGeneratingAlertsAfterStaticControl == null))
                {
                    this.cachedBeginGeneratingAlertsAfterStaticControl = new StaticControl(this, BaseliningConfigurationDialog.ControlIDs.BeginGeneratingAlertsAfterStaticControl);
                }
                return this.cachedBeginGeneratingAlertsAfterStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BusinessCycleStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaseliningConfigurationDialogControls.BusinessCycleStaticControl
        {
            get
            {
                if ((this.cachedBusinessCycleStaticControl == null))
                {
                    this.cachedBusinessCycleStaticControl = new StaticControl(this, BaseliningConfigurationDialog.ControlIDs.BusinessCycleStaticControl);
                }
                return this.cachedBusinessCycleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaseliningConfigurationDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, BaseliningConfigurationDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureTheBaselineValuesUsedToDetermineTheThresholdsStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IBaseliningConfigurationDialogControls.ConfigureTheBaselineValuesUsedToDetermineTheThresholdsStaticControl
        {
            get
            {
                if ((this.cachedConfigureTheBaselineValuesUsedToDetermineTheThresholdsStaticControl == null))
                {
                    this.cachedConfigureTheBaselineValuesUsedToDetermineTheThresholdsStaticControl = new StaticControl(this, BaseliningConfigurationDialog.ControlIDs.ConfigureTheBaselineValuesUsedToDetermineTheThresholdsStaticControl);
                }
                return this.cachedConfigureTheBaselineValuesUsedToDetermineTheThresholdsStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
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
        /// 	[mbickle] 29APR06 Created
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
        /// 	[mbickle] 29APR06 Created
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
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Advanced
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAdvanced()
        {
            this.Controls.AdvancedButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.ExactMatch,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app,
                    Timeout);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // TODO:  Uncomment the following code and apply the appropriate command for invoking the dialog.
                // 
                // app.DTE.ExecuteCmd(Commands.COMMAND_NAME_HERE);
                // 
                // tempWindow = new Window(Strings.DialogTitle, Utilities.StringMatchSyntax.ExactMatch, strDialogClass, Utilities.StringMatchSyntax.ExactMatch, app, timeOut);
                // if (tempWindow != null)
                //     return tempWindow;
                throw new Window.Exceptions.WindowNotFoundException("Init function could not find or bring up the dialog with a title of " + Strings.DialogTitle + "." + ex);

            }

            #region Verify the dialog is loaded completely.  #183828
            for (int loop = 0, maxRetry = 3; loop <= maxRetry; loop++)
            {
                try
                {

                    if (new TextBox(tempWindow,
                        BaseliningConfigurationDialog.ControlIDs.BusinessCycleLengthInGivenUnitTextBox,
                        true,
                        Timeout) != null)
                        break;

                }
                catch (System.Exception ex)
                {
                    if (loop == maxRetry)
                        throw ex;
                }
            } 
            #endregion


            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
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
            private const string ResourceDialogTitle = ";Create Monitor Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateMonitorWizard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.PageFramework.WizardButtonsPanel;previousButton.T" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";Create;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Internal.UI.Authoring.Pages.Common.PageCommonResources;CommitButtonText" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitorType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitorType = ";Monitor Type;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.Pages.ChooseMonitorTypePage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PerformanceCounter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePerformanceCounter = ";Performance Counter;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ente" +
                "rpriseManagement.Internal.UI.Authoring.Pages.HttpUrlPerformanceCounterProviderPage;$" +
                "this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BaseliningConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBaseliningConfiguration = ";Baselining Configuration;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.PagesBaselining.StringResource" +
                "s;Title";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureHealth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureHealth = ";Configure Health;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.OperationalStatesMappi" +
                "ngPage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureAlerts = ";Configure Alerts;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Knowledge
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceKnowledge = ";Knowledge;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.ProductKnowledgePage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;GeneralPropertyPageTabText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Advanced
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdvanced = ";Advanced;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManag" +
                "ement.Internal.UI.Authoring.Pages.BaseLiningPage;button1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Alerting
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAlerting = ";Alerting;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManag" +
                "ement.Internal.UI.Authoring.Pages.AlertConfiguration;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureBusinessCycle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureBusinessCycle = ";Configure business cycle;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.BaseLiningPage;pageSectionLabel1.T" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  High
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHigh = ";High;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.Cache.AlertTranslator;PriorityHigh";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Low
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLow = ";Low;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom" +
                ".Internal.UI.Cache.AlertTranslator;PriorityLow";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Sensitivity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSensitivity = ";Sensitivity:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.Pages.BaseLiningPage;label6.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BusinessCylesOfAnalysis
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBusinessCylesOfAnalysis = ";business cyle(s) of analysis;ManagedString;Microsoft.MOM.UI.Components.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.Pages.BaseLiningPage;label5.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BeginGeneratingAlertsAfter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBeginGeneratingAlertsAfter = ";Begin generating alerts after:;ManagedString;Microsoft.MOM.UI.Components.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.BaseLiningPage;label4.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BusinessCycle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBusinessCycle = ";Business cycle:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Internal.UI.Authoring.Pages.BaseLiningPage;label3.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureTheBaselineValuesUsedToDetermineTheThresholds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureTheBaselineValuesUsedToDetermineTheThresholds = ";Configure the baseline values used to determine the thresholds;ManagedString;Mic" +
                "rosoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Baselining.StringResources;SubTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Week(s)
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWeeksUnit = ";Week(s);ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Baselining.StringResources;WeeksUnit";

              /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Day(s)
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDaysUnit = ";Day(s);ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Baselining.StringResources;DaysUnit";
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
            /// Caches the translated resource string for:  MonitorType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PerformanceCounter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPerformanceCounter;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BaseliningConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBaseliningConfiguration;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureHealth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureHealth;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureAlerts;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Knowledge
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedKnowledge;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Advanced
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdvanced;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Alerting
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlerting;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureBusinessCycle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureBusinessCycle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  High
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHigh;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Low
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLow;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Sensitivity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSensitivity;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BusinessCylesOfAnalysis
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBusinessCylesOfAnalysis;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BeginGeneratingAlertsAfter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBeginGeneratingAlertsAfter;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BusinessCycle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBusinessCycle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureTheBaselineValuesUsedToDetermineTheThresholds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureTheBaselineValuesUsedToDetermineTheThresholds;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Week(s)
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWeeksUnit;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Day(s)
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDaysUnit;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
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
            /// 	[mbickle] 29APR06 Created
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
            /// 	[mbickle] 29APR06 Created
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
            /// 	[mbickle] 29APR06 Created
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
            /// 	[mbickle] 29APR06 Created
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
            /// Exposes access to the MonitorType translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorType
            {
                get
                {
                    if ((cachedMonitorType == null))
                    {
                        cachedMonitorType = CoreManager.MomConsole.GetIntlStr(ResourceMonitorType);
                    }
                    return cachedMonitorType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PerformanceCounter translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PerformanceCounter
            {
                get
                {
                    if ((cachedPerformanceCounter == null))
                    {
                        cachedPerformanceCounter = CoreManager.MomConsole.GetIntlStr(ResourcePerformanceCounter);
                    }
                    return cachedPerformanceCounter;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BaseliningConfiguration translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BaseliningConfiguration
            {
                get
                {
                    if ((cachedBaseliningConfiguration == null))
                    {
                        cachedBaseliningConfiguration = CoreManager.MomConsole.GetIntlStr(ResourceBaseliningConfiguration);
                    }
                    return cachedBaseliningConfiguration;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureHealth translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureHealth
            {
                get
                {
                    if ((cachedConfigureHealth == null))
                    {
                        cachedConfigureHealth = CoreManager.MomConsole.GetIntlStr(ResourceConfigureHealth);
                    }
                    return cachedConfigureHealth;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureAlerts translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureAlerts
            {
                get
                {
                    if ((cachedConfigureAlerts == null))
                    {
                        cachedConfigureAlerts = CoreManager.MomConsole.GetIntlStr(ResourceConfigureAlerts);
                    }
                    return cachedConfigureAlerts;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Knowledge translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Knowledge
            {
                get
                {
                    if ((cachedKnowledge == null))
                    {
                        cachedKnowledge = CoreManager.MomConsole.GetIntlStr(ResourceKnowledge);
                    }
                    return cachedKnowledge;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
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
            /// Exposes access to the Advanced translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Advanced
            {
                get
                {
                    if ((cachedAdvanced == null))
                    {
                        cachedAdvanced = CoreManager.MomConsole.GetIntlStr(ResourceAdvanced);
                    }
                    return cachedAdvanced;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alerting translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Alerting
            {
                get
                {
                    if ((cachedAlerting == null))
                    {
                        cachedAlerting = CoreManager.MomConsole.GetIntlStr(ResourceAlerting);
                    }
                    return cachedAlerting;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfigureBusinessCycle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureBusinessCycle
            {
                get
                {
                    if ((cachedConfigureBusinessCycle == null))
                    {
                        cachedConfigureBusinessCycle = CoreManager.MomConsole.GetIntlStr(ResourceConfigureBusinessCycle);
                    }
                    return cachedConfigureBusinessCycle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the High translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string High
            {
                get
                {
                    if ((cachedHigh == null))
                    {
                        cachedHigh = CoreManager.MomConsole.GetIntlStr(ResourceHigh);
                    }
                    return cachedHigh;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Low translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Low
            {
                get
                {
                    if ((cachedLow == null))
                    {
                        cachedLow = CoreManager.MomConsole.GetIntlStr(ResourceLow);
                    }
                    return cachedLow;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Sensitivity translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Sensitivity
            {
                get
                {
                    if ((cachedSensitivity == null))
                    {
                        cachedSensitivity = CoreManager.MomConsole.GetIntlStr(ResourceSensitivity);
                    }
                    return cachedSensitivity;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BusinessCylesOfAnalysis translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BusinessCylesOfAnalysis
            {
                get
                {
                    if ((cachedBusinessCylesOfAnalysis == null))
                    {
                        cachedBusinessCylesOfAnalysis = CoreManager.MomConsole.GetIntlStr(ResourceBusinessCylesOfAnalysis);
                    }
                    return cachedBusinessCylesOfAnalysis;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BeginGeneratingAlertsAfter translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BeginGeneratingAlertsAfter
            {
                get
                {
                    if ((cachedBeginGeneratingAlertsAfter == null))
                    {
                        cachedBeginGeneratingAlertsAfter = CoreManager.MomConsole.GetIntlStr(ResourceBeginGeneratingAlertsAfter);
                    }
                    return cachedBeginGeneratingAlertsAfter;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BusinessCycle translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BusinessCycle
            {
                get
                {
                    if ((cachedBusinessCycle == null))
                    {
                        cachedBusinessCycle = CoreManager.MomConsole.GetIntlStr(ResourceBusinessCycle);
                    }
                    return cachedBusinessCycle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
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
            /// Exposes access to the ConfigureTheBaselineValuesUsedToDetermineTheThresholds translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureTheBaselineValuesUsedToDetermineTheThresholds
            {
                get
                {
                    if ((cachedConfigureTheBaselineValuesUsedToDetermineTheThresholds == null))
                    {
                        cachedConfigureTheBaselineValuesUsedToDetermineTheThresholds = CoreManager.MomConsole.GetIntlStr(ResourceConfigureTheBaselineValuesUsedToDetermineTheThresholds);
                    }
                    return cachedConfigureTheBaselineValuesUsedToDetermineTheThresholds;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to translated resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 26Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WeeksUnit
            {
                get
                {
                    if ((cachedWeeksUnit == null))
                    {
                        cachedWeeksUnit = CoreManager.MomConsole.GetIntlStr(ResourceWeeksUnit);
                    }
                    return cachedWeeksUnit;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to translated resource string
            /// </summary>
            /// <history>
            /// 	[v-dayow] 26Nov09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DaysUnit
            {
                get
                {
                    if ((cachedDaysUnit == null))
                    {
                        cachedDaysUnit = CoreManager.MomConsole.GetIntlStr(ResourceDaysUnit);
                    }
                    return cachedDaysUnit;
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
        /// 	[mbickle] 29APR06 Created
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
            /// Control ID for MonitorTypeStaticControl
            /// </summary>
            public const string MonitorTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for PerformanceCounterStaticControl
            /// </summary>
            public const string PerformanceCounterStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for BaseliningConfigurationStaticControl
            /// </summary>
            public const string BaseliningConfigurationStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureHealthStaticControl
            /// </summary>
            public const string ConfigureHealthStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureAlertsStaticControl
            /// </summary>
            public const string ConfigureAlertsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for KnowledgeStaticControl
            /// </summary>
            public const string KnowledgeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for BusinessCycleUnitComboBox
            /// </summary>
            public const string BusinessCycleUnitComboBox = "BusinessCycleUnitCombobox";
            
            /// <summary>
            /// Control ID for AdvancedButton
            /// </summary>
            public const string AdvancedButton = "button1";
            
            /// <summary>
            /// Control ID for AlertingStaticControl
            /// </summary>
            public const string AlertingStaticControl = "pageSectionLabel2";
            
            /// <summary>
            /// Control ID for ConfigureBusinessCycleStaticControl
            /// </summary>
            public const string ConfigureBusinessCycleStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for HighStaticControl
            /// </summary>
            public const string HighStaticControl = "label8";
            
            /// <summary>
            /// Control ID for LowStaticControl
            /// </summary>
            public const string LowStaticControl = "label7";
            
            /// <summary>
            /// Control ID for SensitivityStaticControl
            /// </summary>
            public const string SensitivityStaticControl = "label6";
            
            /// <summary>
            /// Control ID for LowTrackBar
            /// </summary>
            public const string LowTrackBar = "Sensitivity_trackbar";
            
            /// <summary>
            /// Control ID for BusinessCylesOfAnalysisStaticControl
            /// </summary>
            public const string BusinessCylesOfAnalysisStaticControl = "label5";
            
            /// <summary>
            /// Control ID for BeginGeneratingAlertsAfterTextBox
            /// </summary>
            public const string BeginGeneratingAlertsAfterTextBox = "StartAlertingAfter";
            
            /// <summary>
            /// Control ID for BusinessCycleLengthInGivenUnitTextBox
            /// </summary>
            public const string BusinessCycleLengthInGivenUnitTextBox = "BusinessCycleLengthInGivenUnitTextBox";
            
            /// <summary>
            /// Control ID for BeginGeneratingAlertsAfterStaticControl
            /// </summary>
            public const string BeginGeneratingAlertsAfterStaticControl = "label4";
            
            /// <summary>
            /// Control ID for BusinessCycleStaticControl
            /// </summary>
            public const string BusinessCycleStaticControl = "label3";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureTheBaselineValuesUsedToDetermineTheThresholdsStaticControl
            /// </summary>
            public const string ConfigureTheBaselineValuesUsedToDetermineTheThresholdsStaticControl = "headerLabel";
        }
        #endregion
    }
}
