// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PerformanceCriteriaDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 9/27/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.DotNETMonitor.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IPerformanceCriteriaDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPerformanceCriteriaDialogControls, for PerformanceCriteriaDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 9/27/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPerformanceCriteriaDialogControls
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
        /// Read-only property to access MonitoringTypeStaticControl
        /// </summary>
        StaticControl MonitoringTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GeneralPropertiesStaticControl
        /// </summary>
        StaticControl GeneralPropertiesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DiscoveryMethodStaticControl
        /// </summary>
        StaticControl DiscoveryMethodStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ASPNETApplicationStaticControl
        /// </summary>
        StaticControl ASPNETApplicationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExceptionsStaticControl
        /// </summary>
        StaticControl ExceptionsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PerformanceStaticControl
        /// </summary>
        StaticControl PerformanceStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SummaryStaticControl
        /// </summary>
        StaticControl SummaryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PerformanceEventCountMonitoringStaticControl
        /// </summary>
        StaticControl PerformanceEventCountMonitoringStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp
        /// </summary>
        StaticControl IfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnablePerformanceEventMonitoringCheckBox
        /// </summary>
        CheckBox EnablePerformanceEventMonitoringCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SampleTimeIntervalComboBox
        /// </summary>
        ComboBox SampleTimeIntervalComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IntervalComboBox
        /// </summary>
        EditComboBox IntervalComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MillisecondsStaticControl
        /// </summary>
        StaticControl MillisecondsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SampleTimeIntervalComboBox2
        /// </summary>
        EditComboBox SampleTimeIntervalComboBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IntervalStaticControl
        /// </summary>
        StaticControl IntervalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ResponseTimeStaticControl
        /// </summary>
        StaticControl ResponseTimeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NoteThisValueMustBeGreaterThanFirstThresholdStaticControl
        /// </summary>
        StaticControl NoteThisValueMustBeGreaterThanFirstThresholdStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OccurrencesStaticControl
        /// </summary>
        StaticControl OccurrencesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WarningThresholdComboBox
        /// </summary>
        EditComboBox WarningThresholdComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ErrorThresholdStaticControl
        /// </summary>
        StaticControl ErrorThresholdStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OccurrencesStaticControl2
        /// </summary>
        StaticControl OccurrencesStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WarningThresholdComboBox2
        /// </summary>
        EditComboBox WarningThresholdComboBox2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WarningThresholdStaticControl
        /// </summary>
        StaticControl WarningThresholdStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SampleTimeIntervalStaticControl
        /// </summary>
        StaticControl SampleTimeIntervalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ResponseTimeStaticControl2
        /// </summary>
        StaticControl ResponseTimeStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ThresholdValuesStaticControl
        /// </summary>
        StaticControl ThresholdValuesStaticControl
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
        /// Read-only property to access SpecifyPerformanceCountMonitoringCriteriaStaticControl
        /// </summary>
        StaticControl SpecifyPerformanceCountMonitoringCriteriaStaticControl
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
    /// 	[faizalk] 9/27/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class PerformanceCriteriaDialog : Dialog, IPerformanceCriteriaDialogControls
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
        /// Cache to hold a reference to MonitoringTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitoringTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DiscoveryMethodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiscoveryMethodStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ASPNETApplicationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedASPNETApplicationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExceptionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExceptionsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PerformanceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPerformanceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PerformanceEventCountMonitoringStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPerformanceEventCountMonitoringStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp of type StaticControl
        /// </summary>
        private StaticControl cachedIfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp;
        
        /// <summary>
        /// Cache to hold a reference to EnablePerformanceEventMonitoringCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedEnablePerformanceEventMonitoringCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to SampleTimeIntervalComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSampleTimeIntervalComboBox;
        
        /// <summary>
        /// Cache to hold a reference to IntervalComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedIntervalComboBox;
        
        /// <summary>
        /// Cache to hold a reference to MillisecondsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMillisecondsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SampleTimeIntervalComboBox2 of type ComboBox
        /// </summary>
        private EditComboBox cachedSampleTimeIntervalComboBox2;
        
        /// <summary>
        /// Cache to hold a reference to IntervalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIntervalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ResponseTimeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedResponseTimeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NoteThisValueMustBeGreaterThanFirstThresholdStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNoteThisValueMustBeGreaterThanFirstThresholdStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OccurrencesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOccurrencesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WarningThresholdComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedWarningThresholdComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ErrorThresholdStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedErrorThresholdStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OccurrencesStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedOccurrencesStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to WarningThresholdComboBox2 of type ComboBox
        /// </summary>
        private EditComboBox cachedWarningThresholdComboBox2;
        
        /// <summary>
        /// Cache to hold a reference to WarningThresholdStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWarningThresholdStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SampleTimeIntervalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSampleTimeIntervalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ResponseTimeStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedResponseTimeStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to ThresholdValuesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedThresholdValuesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyPerformanceCountMonitoringCriteriaStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyPerformanceCountMonitoringCriteriaStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of PerformanceCriteriaDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PerformanceCriteriaDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IPerformanceCriteriaDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPerformanceCriteriaDialogControls Controls
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
        ///  Property to handle checkbox EnablePerformanceEventMonitoring
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool EnablePerformanceEventMonitoring
        {
            get
            {
                return this.Controls.EnablePerformanceEventMonitoringCheckBox.Checked;
            }
            
            set
            {
                this.Controls.EnablePerformanceEventMonitoringCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SampleTimeInterval
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SampleTimeIntervalText
        {
            get
            {
                return this.Controls.SampleTimeIntervalComboBox.Text;
            }
            
            set
            {
                this.Controls.SampleTimeIntervalComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Interval
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string IntervalText
        {
            get
            {
                return this.Controls.IntervalComboBox.Text;
            }
            
            set
            {
                //this.Controls.IntervalComboBox.SelectByText(value, true);
                this.Controls.IntervalComboBox.Text = value;
                
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SampleTimeInterval2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SampleTimeInterval2Text
        {
            get
            {
                return this.Controls.SampleTimeIntervalComboBox2.Text;
            }
            
            set
            {
                //this.Controls.SampleTimeIntervalComboBox2.SelectByText(value, true);
                this.Controls.SampleTimeIntervalComboBox2.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control WarningThreshold
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string WarningThresholdText
        {
            get
            {
                return this.Controls.WarningThresholdComboBox.Text;
            }
            
            set
            {
                //this.Controls.WarningThresholdComboBox.SelectByText(value, true);
                this.Controls.WarningThresholdComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control WarningThreshold2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string WarningThreshold2Text
        {
            get
            {
                return this.Controls.WarningThresholdComboBox2.Text;
            }
            
            set
            {
                //this.Controls.WarningThresholdComboBox2.SelectByText(value, true);
                this.Controls.WarningThresholdComboBox2.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceCriteriaDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, PerformanceCriteriaDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceCriteriaDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, PerformanceCriteriaDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceCriteriaDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, PerformanceCriteriaDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPerformanceCriteriaDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, PerformanceCriteriaDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.MonitoringTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitoringTypeStaticControl == null))
                {
                    this.cachedMonitoringTypeStaticControl = new StaticControl(this, PerformanceCriteriaDialog.ControlIDs.MonitoringTypeStaticControl);
                }
                
                return this.cachedMonitoringTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.GeneralPropertiesStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedGeneralPropertiesStaticControl == null))
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
                    this.cachedGeneralPropertiesStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedGeneralPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiscoveryMethodStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.DiscoveryMethodStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDiscoveryMethodStaticControl == null))
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
                    this.cachedDiscoveryMethodStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedDiscoveryMethodStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ASPNETApplicationStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.ASPNETApplicationStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedASPNETApplicationStaticControl == null))
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
                    this.cachedASPNETApplicationStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedASPNETApplicationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExceptionsStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.ExceptionsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedExceptionsStaticControl == null))
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
                    this.cachedExceptionsStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedExceptionsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PerformanceStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.PerformanceStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedPerformanceStaticControl == null))
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
                    this.cachedPerformanceStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedPerformanceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.SummaryStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSummaryStaticControl == null))
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
                    this.cachedSummaryStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedSummaryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PerformanceEventCountMonitoringStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.PerformanceEventCountMonitoringStaticControl
        {
            get
            {
                if ((this.cachedPerformanceEventCountMonitoringStaticControl == null))
                {
                    this.cachedPerformanceEventCountMonitoringStaticControl = new StaticControl(this, PerformanceCriteriaDialog.ControlIDs.PerformanceEventCountMonitoringStaticControl);
                }
                
                return this.cachedPerformanceEventCountMonitoringStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.IfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp
        {
            get
            {
                if ((this.cachedIfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp == null))
                {
                    this.cachedIfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp = new StaticControl(this, PerformanceCriteriaDialog.ControlIDs.IfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp);
                }
                
                return this.cachedIfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnablePerformanceEventMonitoringCheckBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IPerformanceCriteriaDialogControls.EnablePerformanceEventMonitoringCheckBox
        {
            get
            {
                if ((this.cachedEnablePerformanceEventMonitoringCheckBox == null))
                {
                    this.cachedEnablePerformanceEventMonitoringCheckBox = new CheckBox(this, PerformanceCriteriaDialog.ControlIDs.EnablePerformanceEventMonitoringCheckBox);
                }
                
                return this.cachedEnablePerformanceEventMonitoringCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SampleTimeIntervalComboBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IPerformanceCriteriaDialogControls.SampleTimeIntervalComboBox
        {
            get
            {
                if ((this.cachedSampleTimeIntervalComboBox == null))
                {
                    this.cachedSampleTimeIntervalComboBox = new ComboBox(this, PerformanceCriteriaDialog.ControlIDs.SampleTimeIntervalComboBox);
                }
                
                return this.cachedSampleTimeIntervalComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntervalComboBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IPerformanceCriteriaDialogControls.IntervalComboBox
        {
            get
            {
                if ((this.cachedIntervalComboBox == null))
                {
                    this.cachedIntervalComboBox = new EditComboBox(this, PerformanceCriteriaDialog.ControlIDs.IntervalComboBox);
                }
                
                return this.cachedIntervalComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MillisecondsStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.MillisecondsStaticControl
        {
            get
            {
                if ((this.cachedMillisecondsStaticControl == null))
                {
                    this.cachedMillisecondsStaticControl = new StaticControl(this, PerformanceCriteriaDialog.ControlIDs.MillisecondsStaticControl);
                }
                
                return this.cachedMillisecondsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SampleTimeIntervalComboBox2 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IPerformanceCriteriaDialogControls.SampleTimeIntervalComboBox2
        {
            get
            {
                if ((this.cachedSampleTimeIntervalComboBox2 == null))
                {
                    this.cachedSampleTimeIntervalComboBox2 = new EditComboBox(this, PerformanceCriteriaDialog.ControlIDs.SampleTimeIntervalComboBox2);
                }
                
                return this.cachedSampleTimeIntervalComboBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntervalStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.IntervalStaticControl
        {
            get
            {
                if ((this.cachedIntervalStaticControl == null))
                {
                    this.cachedIntervalStaticControl = new StaticControl(this, PerformanceCriteriaDialog.ControlIDs.IntervalStaticControl);
                }
                
                return this.cachedIntervalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResponseTimeStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.ResponseTimeStaticControl
        {
            get
            {
                if ((this.cachedResponseTimeStaticControl == null))
                {
                    this.cachedResponseTimeStaticControl = new StaticControl(this, PerformanceCriteriaDialog.ControlIDs.ResponseTimeStaticControl);
                }
                
                return this.cachedResponseTimeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoteThisValueMustBeGreaterThanFirstThresholdStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.NoteThisValueMustBeGreaterThanFirstThresholdStaticControl
        {
            get
            {
                if ((this.cachedNoteThisValueMustBeGreaterThanFirstThresholdStaticControl == null))
                {
                    this.cachedNoteThisValueMustBeGreaterThanFirstThresholdStaticControl = new StaticControl(this, PerformanceCriteriaDialog.ControlIDs.NoteThisValueMustBeGreaterThanFirstThresholdStaticControl);
                }
                
                return this.cachedNoteThisValueMustBeGreaterThanFirstThresholdStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OccurrencesStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.OccurrencesStaticControl
        {
            get
            {
                if ((this.cachedOccurrencesStaticControl == null))
                {
                    this.cachedOccurrencesStaticControl = new StaticControl(this, PerformanceCriteriaDialog.ControlIDs.OccurrencesStaticControl);
                }
                
                return this.cachedOccurrencesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WarningThresholdComboBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IPerformanceCriteriaDialogControls.WarningThresholdComboBox
        {
            get
            {
                if ((this.cachedWarningThresholdComboBox == null))
                {
                    this.cachedWarningThresholdComboBox = new EditComboBox(this, PerformanceCriteriaDialog.ControlIDs.WarningThresholdComboBox);
                }
                
                return this.cachedWarningThresholdComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ErrorThresholdStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.ErrorThresholdStaticControl
        {
            get
            {
                if ((this.cachedErrorThresholdStaticControl == null))
                {
                    this.cachedErrorThresholdStaticControl = new StaticControl(this, PerformanceCriteriaDialog.ControlIDs.ErrorThresholdStaticControl);
                }
                
                return this.cachedErrorThresholdStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OccurrencesStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.OccurrencesStaticControl2
        {
            get
            {
                if ((this.cachedOccurrencesStaticControl2 == null))
                {
                    this.cachedOccurrencesStaticControl2 = new StaticControl(this, PerformanceCriteriaDialog.ControlIDs.OccurrencesStaticControl2);
                }
                
                return this.cachedOccurrencesStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WarningThresholdComboBox2 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IPerformanceCriteriaDialogControls.WarningThresholdComboBox2
        {
            get
            {
                if ((this.cachedWarningThresholdComboBox2 == null))
                {
                    this.cachedWarningThresholdComboBox2 = new EditComboBox(this, PerformanceCriteriaDialog.ControlIDs.WarningThresholdComboBox2);
                }
                
                return this.cachedWarningThresholdComboBox2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WarningThresholdStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.WarningThresholdStaticControl
        {
            get
            {
                if ((this.cachedWarningThresholdStaticControl == null))
                {
                    this.cachedWarningThresholdStaticControl = new StaticControl(this, PerformanceCriteriaDialog.ControlIDs.WarningThresholdStaticControl);
                }
                
                return this.cachedWarningThresholdStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SampleTimeIntervalStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.SampleTimeIntervalStaticControl
        {
            get
            {
                if ((this.cachedSampleTimeIntervalStaticControl == null))
                {
                    this.cachedSampleTimeIntervalStaticControl = new StaticControl(this, PerformanceCriteriaDialog.ControlIDs.SampleTimeIntervalStaticControl);
                }
                
                return this.cachedSampleTimeIntervalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ResponseTimeStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.ResponseTimeStaticControl2
        {
            get
            {
                if ((this.cachedResponseTimeStaticControl2 == null))
                {
                    this.cachedResponseTimeStaticControl2 = new StaticControl(this, PerformanceCriteriaDialog.ControlIDs.ResponseTimeStaticControl2);
                }
                
                return this.cachedResponseTimeStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ThresholdValuesStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.ThresholdValuesStaticControl
        {
            get
            {
                if ((this.cachedThresholdValuesStaticControl == null))
                {
                    this.cachedThresholdValuesStaticControl = new StaticControl(this, PerformanceCriteriaDialog.ControlIDs.ThresholdValuesStaticControl);
                }
                
                return this.cachedThresholdValuesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, PerformanceCriteriaDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyPerformanceCountMonitoringCriteriaStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPerformanceCriteriaDialogControls.SpecifyPerformanceCountMonitoringCriteriaStaticControl
        {
            get
            {
                if ((this.cachedSpecifyPerformanceCountMonitoringCriteriaStaticControl == null))
                {
                    this.cachedSpecifyPerformanceCountMonitoringCriteriaStaticControl = new StaticControl(this, PerformanceCriteriaDialog.ControlIDs.SpecifyPerformanceCountMonitoringCriteriaStaticControl);
                }
                
                return this.cachedSpecifyPerformanceCountMonitoringCriteriaStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
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
        /// 	[faizalk] 9/27/2006 Created
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
        /// 	[faizalk] 9/27/2006 Created
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
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button EnablePerformanceEventMonitoring
        /// </summary>
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEnablePerformanceEventMonitoring()
        {
            this.Controls.EnablePerformanceEventMonitoringCheckBox.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">ConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 9/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                                 Strings.DialogTitle + "*",
                                 StringMatchSyntax.WildCard,
                                 WindowClassNames.WinForms10Window8,
                                 StringMatchSyntax.WildCard,
                                 app,
                                 Timeout);
                 
                         // wait for the window to report ready
                         UISynchronization.WaitForUIObjectReady(
                             tempWindow,
                             Timeout);
                     }
                     catch (Exceptions.WindowNotFoundException)
                     {
                         // log the unsuccessful attempt
                         Core.Common.Utilities.LogMessage("Attempt "
                            + numberOfTries
                            + " of "
                            + MaxTries
                            + "...");                         
                         // wait for a moment before trying again
                         Maui.Core.Utilities.Sleeper.Delay(Timeout);
                     }
                 }
                 
                 // check for success
                 if (tempWindow == null)
                 {
                     // log the failure
                 
                     // throw the existing WindowNotFound exception
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
        /// 	[faizalk] 9/27/2006 Created
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
            private const string ResourceDialogTitle = ";Add Monitoring Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;TemplateWizard";
            
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
            /// Contains resource string for:  MonitoringType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitoringType = ";Monitoring Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mi" +
                "crosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.TemplateListPage;$this." +
                "NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties = ";General Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPa" +
                "ge;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DiscoveryMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiscoveryMethod = ";Discovery Method;ManagedString;Microsoft.EnterpriseManagement.UI.Administration." +
                "dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";DiscoveryMethodTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ASPNETApplication
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceASPNETApplication = "ASP.NET Application";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Exceptions
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceExceptions = "Exceptions";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Performance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePerformance = ";Performance;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMa" +
                "nagement.Mom.Internal.UI.Views.EventResources;ViewPerformanceCommand";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary = ";Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;SummaryT" +
                "itle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PerformanceEventCountMonitoring
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourcePerformanceEventCountMonitoring = "Performance Event Count Monitoring";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceIfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp = "If the rate of Performance events, during a sampling interval, exceeds the Warnin" +
                "g or Error thresholds, the state of the application changes";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnablePerformanceEventMonitoring
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnablePerformanceEventMonitoring = "Ena&ble performance event monitoring";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Milliseconds
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceMilliseconds = "milliseconds";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Interval
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceInterval = "&Interval";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ResponseTime
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceResponseTime = "&Response Time";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NoteThisValueMustBeGreaterThanFirstThreshold
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceNoteThisValueMustBeGreaterThanFirstThreshold = "Note: This value must be greater than first threshold";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Occurrences
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceOccurrences = "occurrences";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ErrorThreshold
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceErrorThreshold = "&Error Threshold";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Occurrences2
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceOccurrences2 = "occurrences";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WarningThreshold
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceWarningThreshold = "&Warning Threshold";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SampleTimeInterval
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSampleTimeInterval = "Sample Time Interval";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ResponseTime2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceResponseTime2 = ";Response Time;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micr" +
                "osoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Lob.LobTemplateResource;R" +
                "esponseTime";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ThresholdValues
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceThresholdValues = "Threshold values";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Common.CommonResources;CommandHelp";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyPerformanceCountMonitoringCriteria
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyPerformanceCountMonitoringCriteria = "Specify performance count monitoring criteria";
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
            /// Caches the translated resource string for:  MonitoringType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitoringType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralProperties;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DiscoveryMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiscoveryMethod;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ASPNETApplication
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedASPNETApplication;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Exceptions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExceptions;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Performance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPerformance;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PerformanceEventCountMonitoring
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPerformanceEventCountMonitoring;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnablePerformanceEventMonitoring
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnablePerformanceEventMonitoring;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Milliseconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMilliseconds;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Interval
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInterval;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ResponseTime
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResponseTime;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NoteThisValueMustBeGreaterThanFirstThreshold
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNoteThisValueMustBeGreaterThanFirstThreshold;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Occurrences
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOccurrences;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ErrorThreshold
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedErrorThreshold;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Occurrences2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOccurrences2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WarningThreshold
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWarningThreshold;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SampleTimeInterval
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSampleTimeInterval;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ResponseTime2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResponseTime2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ThresholdValues
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedThresholdValues;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyPerformanceCountMonitoringCriteria
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyPerformanceCountMonitoringCriteria;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
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
            /// 	[faizalk] 9/27/2006 Created
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
            /// 	[faizalk] 9/27/2006 Created
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
            /// 	[faizalk] 9/27/2006 Created
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
            /// 	[faizalk] 9/27/2006 Created
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
            /// Exposes access to the MonitoringType translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitoringType
            {
                get
                {
                    if ((cachedMonitoringType == null))
                    {
                        cachedMonitoringType = CoreManager.MomConsole.GetIntlStr(ResourceMonitoringType);
                    }
                    
                    return cachedMonitoringType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GeneralProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GeneralProperties
            {
                get
                {
                    if ((cachedGeneralProperties == null))
                    {
                        cachedGeneralProperties = CoreManager.MomConsole.GetIntlStr(ResourceGeneralProperties);
                    }
                    
                    return cachedGeneralProperties;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DiscoveryMethod translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiscoveryMethod
            {
                get
                {
                    if ((cachedDiscoveryMethod == null))
                    {
                        cachedDiscoveryMethod = CoreManager.MomConsole.GetIntlStr(ResourceDiscoveryMethod);
                    }
                    
                    return cachedDiscoveryMethod;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ASPNETApplication translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ASPNETApplication
            {
                get
                {
                    if ((cachedASPNETApplication == null))
                    {
                        cachedASPNETApplication = CoreManager.MomConsole.GetIntlStr(ResourceASPNETApplication);
                    }
                    
                    return cachedASPNETApplication;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Exceptions translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Exceptions
            {
                get
                {
                    if ((cachedExceptions == null))
                    {
                        cachedExceptions = CoreManager.MomConsole.GetIntlStr(ResourceExceptions);
                    }
                    
                    return cachedExceptions;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Performance translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Performance
            {
                get
                {
                    if ((cachedPerformance == null))
                    {
                        cachedPerformance = CoreManager.MomConsole.GetIntlStr(ResourcePerformance);
                    }
                    
                    return cachedPerformance;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Summary
            {
                get
                {
                    if ((cachedSummary == null))
                    {
                        cachedSummary = CoreManager.MomConsole.GetIntlStr(ResourceSummary);
                    }
                    
                    return cachedSummary;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PerformanceEventCountMonitoring translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PerformanceEventCountMonitoring
            {
                get
                {
                    if ((cachedPerformanceEventCountMonitoring == null))
                    {
                        cachedPerformanceEventCountMonitoring = CoreManager.MomConsole.GetIntlStr(ResourcePerformanceEventCountMonitoring);
                    }
                    
                    return cachedPerformanceEventCountMonitoring;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the IfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp
            {
                get
                {
                    if ((cachedIfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp == null))
                    {
                        cachedIfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp = CoreManager.MomConsole.GetIntlStr(ResourceIfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp);
                    }
                    
                    return cachedIfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnablePerformanceEventMonitoring translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnablePerformanceEventMonitoring
            {
                get
                {
                    if ((cachedEnablePerformanceEventMonitoring == null))
                    {
                        cachedEnablePerformanceEventMonitoring = CoreManager.MomConsole.GetIntlStr(ResourceEnablePerformanceEventMonitoring);
                    }
                    
                    return cachedEnablePerformanceEventMonitoring;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Milliseconds translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Milliseconds
            {
                get
                {
                    if ((cachedMilliseconds == null))
                    {
                        cachedMilliseconds = CoreManager.MomConsole.GetIntlStr(ResourceMilliseconds);
                    }
                    
                    return cachedMilliseconds;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Interval translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Interval
            {
                get
                {
                    if ((cachedInterval == null))
                    {
                        cachedInterval = CoreManager.MomConsole.GetIntlStr(ResourceInterval);
                    }
                    
                    return cachedInterval;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ResponseTime translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ResponseTime
            {
                get
                {
                    if ((cachedResponseTime == null))
                    {
                        cachedResponseTime = CoreManager.MomConsole.GetIntlStr(ResourceResponseTime);
                    }
                    
                    return cachedResponseTime;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NoteThisValueMustBeGreaterThanFirstThreshold translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NoteThisValueMustBeGreaterThanFirstThreshold
            {
                get
                {
                    if ((cachedNoteThisValueMustBeGreaterThanFirstThreshold == null))
                    {
                        cachedNoteThisValueMustBeGreaterThanFirstThreshold = CoreManager.MomConsole.GetIntlStr(ResourceNoteThisValueMustBeGreaterThanFirstThreshold);
                    }
                    
                    return cachedNoteThisValueMustBeGreaterThanFirstThreshold;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Occurrences translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Occurrences
            {
                get
                {
                    if ((cachedOccurrences == null))
                    {
                        cachedOccurrences = CoreManager.MomConsole.GetIntlStr(ResourceOccurrences);
                    }
                    
                    return cachedOccurrences;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ErrorThreshold translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ErrorThreshold
            {
                get
                {
                    if ((cachedErrorThreshold == null))
                    {
                        cachedErrorThreshold = CoreManager.MomConsole.GetIntlStr(ResourceErrorThreshold);
                    }
                    
                    return cachedErrorThreshold;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Occurrences2 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Occurrences2
            {
                get
                {
                    if ((cachedOccurrences2 == null))
                    {
                        cachedOccurrences2 = CoreManager.MomConsole.GetIntlStr(ResourceOccurrences2);
                    }
                    
                    return cachedOccurrences2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WarningThreshold translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WarningThreshold
            {
                get
                {
                    if ((cachedWarningThreshold == null))
                    {
                        cachedWarningThreshold = CoreManager.MomConsole.GetIntlStr(ResourceWarningThreshold);
                    }
                    
                    return cachedWarningThreshold;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SampleTimeInterval translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SampleTimeInterval
            {
                get
                {
                    if ((cachedSampleTimeInterval == null))
                    {
                        cachedSampleTimeInterval = CoreManager.MomConsole.GetIntlStr(ResourceSampleTimeInterval);
                    }
                    
                    return cachedSampleTimeInterval;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ResponseTime2 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ResponseTime2
            {
                get
                {
                    if ((cachedResponseTime2 == null))
                    {
                        cachedResponseTime2 = CoreManager.MomConsole.GetIntlStr(ResourceResponseTime2);
                    }
                    
                    return cachedResponseTime2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ThresholdValues translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ThresholdValues
            {
                get
                {
                    if ((cachedThresholdValues == null))
                    {
                        cachedThresholdValues = CoreManager.MomConsole.GetIntlStr(ResourceThresholdValues);
                    }
                    
                    return cachedThresholdValues;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
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
            /// Exposes access to the SpecifyPerformanceCountMonitoringCriteria translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 9/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyPerformanceCountMonitoringCriteria
            {
                get
                {
                    if ((cachedSpecifyPerformanceCountMonitoringCriteria == null))
                    {
                        cachedSpecifyPerformanceCountMonitoringCriteria = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyPerformanceCountMonitoringCriteria);
                    }
                    
                    return cachedSpecifyPerformanceCountMonitoringCriteria;
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
        /// 	[faizalk] 9/27/2006 Created
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
            /// Control ID for MonitoringTypeStaticControl
            /// </summary>
            public const string MonitoringTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DiscoveryMethodStaticControl
            /// </summary>
            public const string DiscoveryMethodStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ASPNETApplicationStaticControl
            /// </summary>
            public const string ASPNETApplicationStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ExceptionsStaticControl
            /// </summary>
            public const string ExceptionsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for PerformanceStaticControl
            /// </summary>
            public const string PerformanceStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for PerformanceEventCountMonitoringStaticControl
            /// </summary>
            public const string PerformanceEventCountMonitoringStaticControl = "pageSectionLabel3";
            
            /// <summary>
            /// Control ID for IfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp
            /// </summary>
            public const string IfTheRateOfPerformanceEventsDuringASamplingIntervalExceedsTheWarningOrErrorThresholdsTheStateOfTheAp = "label9";
            
            /// <summary>
            /// Control ID for EnablePerformanceEventMonitoringCheckBox
            /// </summary>
            public const string EnablePerformanceEventMonitoringCheckBox = "idCheckExceptions";
            
            /// <summary>
            /// Control ID for SampleTimeIntervalComboBox
            /// </summary>
            public const string SampleTimeIntervalComboBox = "comboBoxUnit";
            
            /// <summary>
            /// Control ID for IntervalComboBox
            /// </summary>
            public const string IntervalComboBox = "numericDropDown";
            
            /// <summary>
            /// Control ID for MillisecondsStaticControl
            /// </summary>
            public const string MillisecondsStaticControl = "label8";
            
            /// <summary>
            /// Control ID for SampleTimeIntervalComboBox2
            /// </summary>
            public const string SampleTimeIntervalComboBox2 = "idResponseTime";
            
            /// <summary>
            /// Control ID for IntervalStaticControl
            /// </summary>
            public const string IntervalStaticControl = "label7";
            
            /// <summary>
            /// Control ID for ResponseTimeStaticControl
            /// </summary>
            public const string ResponseTimeStaticControl = "label6";
            
            /// <summary>
            /// Control ID for NoteThisValueMustBeGreaterThanFirstThresholdStaticControl
            /// </summary>
            public const string NoteThisValueMustBeGreaterThanFirstThresholdStaticControl = "label5";
            
            /// <summary>
            /// Control ID for OccurrencesStaticControl
            /// </summary>
            public const string OccurrencesStaticControl = "label3";
            
            /// <summary>
            /// Control ID for WarningThresholdComboBox
            /// </summary>
            public const string WarningThresholdComboBox = "idErrorThreshold";
            
            /// <summary>
            /// Control ID for ErrorThresholdStaticControl
            /// </summary>
            public const string ErrorThresholdStaticControl = "label4";
            
            /// <summary>
            /// Control ID for OccurrencesStaticControl2
            /// </summary>
            public const string OccurrencesStaticControl2 = "label2";
            
            /// <summary>
            /// Control ID for WarningThresholdComboBox2
            /// </summary>
            public const string WarningThresholdComboBox2 = "idWarningThreshold";
            
            /// <summary>
            /// Control ID for WarningThresholdStaticControl
            /// </summary>
            public const string WarningThresholdStaticControl = "label1";
            
            /// <summary>
            /// Control ID for SampleTimeIntervalStaticControl
            /// </summary>
            public const string SampleTimeIntervalStaticControl = "pageSectionLabel2";
            
            /// <summary>
            /// Control ID for ResponseTimeStaticControl2
            /// </summary>
            public const string ResponseTimeStaticControl2 = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for ThresholdValuesStaticControl
            /// </summary>
            public const string ThresholdValuesStaticControl = "pageSectionLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for SpecifyPerformanceCountMonitoringCriteriaStaticControl
            /// </summary>
            public const string SpecifyPerformanceCountMonitoringCriteriaStaticControl = "headerLabel";
        }
        #endregion
    }
}
