// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="OptimizedCollectionDialog.cs">
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

    #region Radio Group Enumeration - OptimizedRadioGroup

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group OptimizedRadioGroup
    /// </summary>
    /// <history>
    /// 	[mbickle] 29APR06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum OptimizedRadioGroup
    {
        /// <summary>
        /// Percentage = 0
        /// </summary>
        Percentage = 0,
        
        /// <summary>
        /// AbsoluteNumber = 1
        /// </summary>
        AbsoluteNumber = 1,
    }
    #endregion
    
    #region Interface Definition - IOptimizedCollectionDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IOptimizedCollectionDialogControls, for OptimizedCollectionDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 29APR06 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IOptimizedCollectionDialogControls
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
        /// Read-only property to access PerformanceCounterStaticControl
        /// </summary>
        StaticControl PerformanceCounterStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OptimizedCollectionStaticControl
        /// </summary>
        StaticControl OptimizedCollectionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Percentage
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        EditComboBox Percentage
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AbsoluteNumber
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox AbsoluteNumber
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PercentageRadioButton
        /// </summary>
        RadioButton PercentageRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AbsoluteNumberRadioButton
        /// </summary>
        RadioButton AbsoluteNumberRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SetToleranceToStaticControl
        /// </summary>
        StaticControl SetToleranceToStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UseOptimizationCheckBox
        /// </summary>
        CheckBox UseOptimizationCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UsesMoreBandwidthStaticControl
        /// </summary>
        StaticControl UsesMoreBandwidthStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MoreAccuracyStaticControl
        /// </summary>
        StaticControl MoreAccuracyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StoresMoreDataInTheDatabaseStaticControl
        /// </summary>
        StaticControl StoresMoreDataInTheDatabaseStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LowOptimizationStaticControl
        /// </summary>
        StaticControl LowOptimizationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HighOptimizationStaticControl
        /// </summary>
        StaticControl HighOptimizationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StoresLessDataInTheDatabaseStaticControl
        /// </summary>
        StaticControl StoresLessDataInTheDatabaseStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LessAccuracyStaticControl
        /// </summary>
        StaticControl LessAccuracyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UsesLessBandwidthStaticControl
        /// </summary>
        StaticControl UsesLessBandwidthStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToleranceStaticControl
        /// </summary>
        StaticControl ToleranceStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToleranceStaticControl2
        /// </summary>
        StaticControl ToleranceStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NotCollectedSampleStaticControl
        /// </summary>
        StaticControl NotCollectedSampleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CollectedSampleStaticControl
        /// </summary>
        StaticControl CollectedSampleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UsesMoreBandwidthStaticControl2
        /// </summary>
        StaticControl UsesMoreBandwidthStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MoreAccuracyStaticControl2
        /// </summary>
        StaticControl MoreAccuracyStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StoresMoreDataInTheDatabaseStaticControl2
        /// </summary>
        StaticControl StoresMoreDataInTheDatabaseStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LowOptimizationStaticControl2
        /// </summary>
        StaticControl LowOptimizationStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HighOptimizationStaticControl2
        /// </summary>
        StaticControl HighOptimizationStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StoresLessDataInTheDatabaseStaticControl2
        /// </summary>
        StaticControl StoresLessDataInTheDatabaseStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LessAccuracyStaticControl2
        /// </summary>
        StaticControl LessAccuracyStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UsesLessBandwidthStaticControl2
        /// </summary>
        StaticControl UsesLessBandwidthStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToleranceStaticControl3
        /// </summary>
        StaticControl ToleranceStaticControl3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToleranceStaticControl4
        /// </summary>
        StaticControl ToleranceStaticControl4
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NotCollectedSampleStaticControl2
        /// </summary>
        StaticControl NotCollectedSampleStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CollectedSampleStaticControl2
        /// </summary>
        StaticControl CollectedSampleStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UsesMoreBandwidthStaticControl3
        /// </summary>
        StaticControl UsesMoreBandwidthStaticControl3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MoreAccuracyStaticControl3
        /// </summary>
        StaticControl MoreAccuracyStaticControl3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StoresMoreDataInTheDatabaseStaticControl3
        /// </summary>
        StaticControl StoresMoreDataInTheDatabaseStaticControl3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LowOptimizationStaticControl3
        /// </summary>
        StaticControl LowOptimizationStaticControl3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HighOptimizationStaticControl3
        /// </summary>
        StaticControl HighOptimizationStaticControl3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StoresLessDataInTheDatabaseStaticControl3
        /// </summary>
        StaticControl StoresLessDataInTheDatabaseStaticControl3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LessAccuracyStaticControl3
        /// </summary>
        StaticControl LessAccuracyStaticControl3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UsesLessBandwidthStaticControl3
        /// </summary>
        StaticControl UsesLessBandwidthStaticControl3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToleranceStaticControl5
        /// </summary>
        StaticControl ToleranceStaticControl5
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ToleranceStaticControl6
        /// </summary>
        StaticControl ToleranceStaticControl6
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NotCollectedSampleStaticControl3
        /// </summary>
        StaticControl NotCollectedSampleStaticControl3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CollectedSampleStaticControl3
        /// </summary>
        StaticControl CollectedSampleStaticControl3
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WhichWillIncreaseTheBandwidthForTheAgentToServerCommunicationStaticControl
        /// </summary>
        StaticControl WhichWillIncreaseTheBandwidthForTheAgentToServerCommunicationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OptimizedCollectionHelpsReduceThePerformanceCounterSampleVolumeStaticControl
        /// </summary>
        StaticControl OptimizedCollectionHelpsReduceThePerformanceCounterSampleVolumeStaticControl
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
        /// Read-only property to access OptimizedPerformanceCollectionSettingsStaticControl
        /// </summary>
        StaticControl OptimizedPerformanceCollectionSettingsStaticControl
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
    public class OptimizedCollectionDialog : Dialog, IOptimizedCollectionDialogControls
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
        /// Cache to hold a reference to PerformanceCounterStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPerformanceCounterStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OptimizedCollectionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOptimizedCollectionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Percentage of type ComboBox
        /// </summary>
        private EditComboBox cachedPercentage;
        
        /// <summary>
        /// Cache to hold a reference to AbsoluteNumber of type ComboBox
        /// </summary>
        private TextBox cachedAbsoluteNumber;
        
        /// <summary>
        /// Cache to hold a reference to PercentageRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedPercentageRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to AbsoluteNumberRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAbsoluteNumberRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to SetToleranceToStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSetToleranceToStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UseOptimizationCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedUseOptimizationCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to UsesMoreBandwidthStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedUsesMoreBandwidthStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MoreAccuracyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMoreAccuracyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StoresMoreDataInTheDatabaseStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedStoresMoreDataInTheDatabaseStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LowOptimizationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLowOptimizationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HighOptimizationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHighOptimizationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StoresLessDataInTheDatabaseStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedStoresLessDataInTheDatabaseStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LessAccuracyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedLessAccuracyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UsesLessBandwidthStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedUsesLessBandwidthStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToleranceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedToleranceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ToleranceStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedToleranceStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to NotCollectedSampleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNotCollectedSampleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CollectedSampleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCollectedSampleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UsesMoreBandwidthStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedUsesMoreBandwidthStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to MoreAccuracyStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedMoreAccuracyStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to StoresMoreDataInTheDatabaseStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedStoresMoreDataInTheDatabaseStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to LowOptimizationStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedLowOptimizationStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to HighOptimizationStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedHighOptimizationStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to StoresLessDataInTheDatabaseStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedStoresLessDataInTheDatabaseStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to LessAccuracyStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedLessAccuracyStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to UsesLessBandwidthStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedUsesLessBandwidthStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to ToleranceStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedToleranceStaticControl3;
        
        /// <summary>
        /// Cache to hold a reference to ToleranceStaticControl4 of type StaticControl
        /// </summary>
        private StaticControl cachedToleranceStaticControl4;
        
        /// <summary>
        /// Cache to hold a reference to NotCollectedSampleStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedNotCollectedSampleStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to CollectedSampleStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedCollectedSampleStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to UsesMoreBandwidthStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedUsesMoreBandwidthStaticControl3;
        
        /// <summary>
        /// Cache to hold a reference to MoreAccuracyStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedMoreAccuracyStaticControl3;
        
        /// <summary>
        /// Cache to hold a reference to StoresMoreDataInTheDatabaseStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedStoresMoreDataInTheDatabaseStaticControl3;
        
        /// <summary>
        /// Cache to hold a reference to LowOptimizationStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedLowOptimizationStaticControl3;
        
        /// <summary>
        /// Cache to hold a reference to HighOptimizationStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedHighOptimizationStaticControl3;
        
        /// <summary>
        /// Cache to hold a reference to StoresLessDataInTheDatabaseStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedStoresLessDataInTheDatabaseStaticControl3;
        
        /// <summary>
        /// Cache to hold a reference to LessAccuracyStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedLessAccuracyStaticControl3;
        
        /// <summary>
        /// Cache to hold a reference to UsesLessBandwidthStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedUsesLessBandwidthStaticControl3;
        
        /// <summary>
        /// Cache to hold a reference to ToleranceStaticControl5 of type StaticControl
        /// </summary>
        private StaticControl cachedToleranceStaticControl5;
        
        /// <summary>
        /// Cache to hold a reference to ToleranceStaticControl6 of type StaticControl
        /// </summary>
        private StaticControl cachedToleranceStaticControl6;
        
        /// <summary>
        /// Cache to hold a reference to NotCollectedSampleStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedNotCollectedSampleStaticControl3;
        
        /// <summary>
        /// Cache to hold a reference to CollectedSampleStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedCollectedSampleStaticControl3;
        
        /// <summary>
        /// Cache to hold a reference to WhichWillIncreaseTheBandwidthForTheAgentToServerCommunicationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWhichWillIncreaseTheBandwidthForTheAgentToServerCommunicationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OptimizedCollectionHelpsReduceThePerformanceCounterSampleVolumeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOptimizedCollectionHelpsReduceThePerformanceCounterSampleVolumeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to OptimizedPerformanceCollectionSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedOptimizedPerformanceCollectionSettingsStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of OptimizedCollectionDialog of type ConsoleApp
        /// </param>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public OptimizedCollectionDialog(ConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group OptimizedRadioGroup
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual OptimizedRadioGroup OptimizedRadioGroup
        {
            get
            {
                if ((this.Controls.PercentageRadioButton.ButtonState == ButtonState.Checked))
                {
                    return OptimizedRadioGroup.Percentage;
                }
                
                if ((this.Controls.AbsoluteNumberRadioButton.ButtonState == ButtonState.Checked))
                {
                    return OptimizedRadioGroup.AbsoluteNumber;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == OptimizedRadioGroup.Percentage))
                {
                    this.Controls.PercentageRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == OptimizedRadioGroup.AbsoluteNumber))
                    {
                        this.Controls.AbsoluteNumberRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IOptimizedCollectionDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IOptimizedCollectionDialogControls Controls
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
        ///  Property to handle checkbox UseOptimization
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool UseOptimization
        {
            get
            {
                return this.Controls.UseOptimizationCheckBox.Checked;
            }
            
            set
            {
                this.Controls.UseOptimizationCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Percentage
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PercentageText
        {
            get
            {
                return this.Controls.Percentage.Text;
            }
            
            set
            {
                this.Controls.Percentage.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AbsoluteNumber
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AbsoluteNumberText
        {
            get
            {
                return this.Controls.AbsoluteNumber.Text;
            }
            
            set
            {
                this.Controls.AbsoluteNumber.Text = value;
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
        Button IOptimizedCollectionDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, OptimizedCollectionDialog.ControlIDs.PreviousButton);
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
        Button IOptimizedCollectionDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, OptimizedCollectionDialog.ControlIDs.NextButton);
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
        Button IOptimizedCollectionDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, OptimizedCollectionDialog.ControlIDs.CreateButton);
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
        Button IOptimizedCollectionDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, OptimizedCollectionDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RuleTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.RuleTypeStaticControl
        {
            get
            {
                if ((this.cachedRuleTypeStaticControl == null))
                {
                    this.cachedRuleTypeStaticControl = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.RuleTypeStaticControl);
                }
                return this.cachedRuleTypeStaticControl;
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
        StaticControl IOptimizedCollectionDialogControls.GeneralStaticControl
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
        ///  Exposes access to the PerformanceCounterStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.PerformanceCounterStaticControl
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
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedPerformanceCounterStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedPerformanceCounterStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OptimizedCollectionStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.OptimizedCollectionStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedOptimizedCollectionStaticControl == null))
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
                    this.cachedOptimizedCollectionStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedOptimizedCollectionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Percentage control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IOptimizedCollectionDialogControls.Percentage
        {
            get
            {
                if ((this.cachedPercentage == null))
                {
                    this.cachedPercentage = new EditComboBox(this, OptimizedCollectionDialog.ControlIDs.Percentage);
                }
                return this.cachedPercentage;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AbsoluteNumber control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IOptimizedCollectionDialogControls.AbsoluteNumber
        {
            get
            {
                if ((this.cachedAbsoluteNumber == null))
                {
                    this.cachedAbsoluteNumber = new TextBox(this, OptimizedCollectionDialog.ControlIDs.AbsoluteNumber);
                }
                return this.cachedAbsoluteNumber;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PercentageRadioButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IOptimizedCollectionDialogControls.PercentageRadioButton
        {
            get
            {
                if ((this.cachedPercentageRadioButton == null))
                {
                    this.cachedPercentageRadioButton = new RadioButton(this, OptimizedCollectionDialog.ControlIDs.PercentageRadioButton);
                }
                return this.cachedPercentageRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AbsoluteNumberRadioButton control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IOptimizedCollectionDialogControls.AbsoluteNumberRadioButton
        {
            get
            {
                if ((this.cachedAbsoluteNumberRadioButton == null))
                {
                    this.cachedAbsoluteNumberRadioButton = new RadioButton(this, OptimizedCollectionDialog.ControlIDs.AbsoluteNumberRadioButton);
                }
                return this.cachedAbsoluteNumberRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SetToleranceToStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.SetToleranceToStaticControl
        {
            get
            {
                if ((this.cachedSetToleranceToStaticControl == null))
                {
                    this.cachedSetToleranceToStaticControl = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.SetToleranceToStaticControl);
                }
                return this.cachedSetToleranceToStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseOptimizationCheckBox control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IOptimizedCollectionDialogControls.UseOptimizationCheckBox
        {
            get
            {
                if ((this.cachedUseOptimizationCheckBox == null))
                {
                    this.cachedUseOptimizationCheckBox = new CheckBox(this, OptimizedCollectionDialog.ControlIDs.UseOptimizationCheckBox);
                }
                return this.cachedUseOptimizationCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UsesMoreBandwidthStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.UsesMoreBandwidthStaticControl
        {
            get
            {
                if ((this.cachedUsesMoreBandwidthStaticControl == null))
                {
                    this.cachedUsesMoreBandwidthStaticControl = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.UsesMoreBandwidthStaticControl);
                }
                return this.cachedUsesMoreBandwidthStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MoreAccuracyStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.MoreAccuracyStaticControl
        {
            get
            {
                if ((this.cachedMoreAccuracyStaticControl == null))
                {
                    this.cachedMoreAccuracyStaticControl = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.MoreAccuracyStaticControl);
                }
                return this.cachedMoreAccuracyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StoresMoreDataInTheDatabaseStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.StoresMoreDataInTheDatabaseStaticControl
        {
            get
            {
                if ((this.cachedStoresMoreDataInTheDatabaseStaticControl == null))
                {
                    this.cachedStoresMoreDataInTheDatabaseStaticControl = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.StoresMoreDataInTheDatabaseStaticControl);
                }
                return this.cachedStoresMoreDataInTheDatabaseStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LowOptimizationStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.LowOptimizationStaticControl
        {
            get
            {
                if ((this.cachedLowOptimizationStaticControl == null))
                {
                    this.cachedLowOptimizationStaticControl = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.LowOptimizationStaticControl);
                }
                return this.cachedLowOptimizationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HighOptimizationStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.HighOptimizationStaticControl
        {
            get
            {
                if ((this.cachedHighOptimizationStaticControl == null))
                {
                    this.cachedHighOptimizationStaticControl = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.HighOptimizationStaticControl);
                }
                return this.cachedHighOptimizationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StoresLessDataInTheDatabaseStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.StoresLessDataInTheDatabaseStaticControl
        {
            get
            {
                if ((this.cachedStoresLessDataInTheDatabaseStaticControl == null))
                {
                    this.cachedStoresLessDataInTheDatabaseStaticControl = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.StoresLessDataInTheDatabaseStaticControl);
                }
                return this.cachedStoresLessDataInTheDatabaseStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LessAccuracyStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.LessAccuracyStaticControl
        {
            get
            {
                if ((this.cachedLessAccuracyStaticControl == null))
                {
                    this.cachedLessAccuracyStaticControl = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.LessAccuracyStaticControl);
                }
                return this.cachedLessAccuracyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UsesLessBandwidthStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.UsesLessBandwidthStaticControl
        {
            get
            {
                if ((this.cachedUsesLessBandwidthStaticControl == null))
                {
                    this.cachedUsesLessBandwidthStaticControl = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.UsesLessBandwidthStaticControl);
                }
                return this.cachedUsesLessBandwidthStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToleranceStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.ToleranceStaticControl
        {
            get
            {
                if ((this.cachedToleranceStaticControl == null))
                {
                    this.cachedToleranceStaticControl = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.ToleranceStaticControl);
                }
                return this.cachedToleranceStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToleranceStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.ToleranceStaticControl2
        {
            get
            {
                if ((this.cachedToleranceStaticControl2 == null))
                {
                    this.cachedToleranceStaticControl2 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.ToleranceStaticControl2);
                }
                return this.cachedToleranceStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NotCollectedSampleStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.NotCollectedSampleStaticControl
        {
            get
            {
                if ((this.cachedNotCollectedSampleStaticControl == null))
                {
                    this.cachedNotCollectedSampleStaticControl = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.NotCollectedSampleStaticControl);
                }
                return this.cachedNotCollectedSampleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CollectedSampleStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.CollectedSampleStaticControl
        {
            get
            {
                if ((this.cachedCollectedSampleStaticControl == null))
                {
                    this.cachedCollectedSampleStaticControl = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.CollectedSampleStaticControl);
                }
                return this.cachedCollectedSampleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UsesMoreBandwidthStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.UsesMoreBandwidthStaticControl2
        {
            get
            {
                if ((this.cachedUsesMoreBandwidthStaticControl2 == null))
                {
                    this.cachedUsesMoreBandwidthStaticControl2 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.UsesMoreBandwidthStaticControl2);
                }
                return this.cachedUsesMoreBandwidthStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MoreAccuracyStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.MoreAccuracyStaticControl2
        {
            get
            {
                if ((this.cachedMoreAccuracyStaticControl2 == null))
                {
                    this.cachedMoreAccuracyStaticControl2 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.MoreAccuracyStaticControl2);
                }
                return this.cachedMoreAccuracyStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StoresMoreDataInTheDatabaseStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.StoresMoreDataInTheDatabaseStaticControl2
        {
            get
            {
                if ((this.cachedStoresMoreDataInTheDatabaseStaticControl2 == null))
                {
                    this.cachedStoresMoreDataInTheDatabaseStaticControl2 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.StoresMoreDataInTheDatabaseStaticControl2);
                }
                return this.cachedStoresMoreDataInTheDatabaseStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LowOptimizationStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.LowOptimizationStaticControl2
        {
            get
            {
                if ((this.cachedLowOptimizationStaticControl2 == null))
                {
                    this.cachedLowOptimizationStaticControl2 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.LowOptimizationStaticControl2);
                }
                return this.cachedLowOptimizationStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HighOptimizationStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.HighOptimizationStaticControl2
        {
            get
            {
                if ((this.cachedHighOptimizationStaticControl2 == null))
                {
                    this.cachedHighOptimizationStaticControl2 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.HighOptimizationStaticControl2);
                }
                return this.cachedHighOptimizationStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StoresLessDataInTheDatabaseStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.StoresLessDataInTheDatabaseStaticControl2
        {
            get
            {
                if ((this.cachedStoresLessDataInTheDatabaseStaticControl2 == null))
                {
                    this.cachedStoresLessDataInTheDatabaseStaticControl2 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.StoresLessDataInTheDatabaseStaticControl2);
                }
                return this.cachedStoresLessDataInTheDatabaseStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LessAccuracyStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.LessAccuracyStaticControl2
        {
            get
            {
                if ((this.cachedLessAccuracyStaticControl2 == null))
                {
                    this.cachedLessAccuracyStaticControl2 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.LessAccuracyStaticControl2);
                }
                return this.cachedLessAccuracyStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UsesLessBandwidthStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.UsesLessBandwidthStaticControl2
        {
            get
            {
                if ((this.cachedUsesLessBandwidthStaticControl2 == null))
                {
                    this.cachedUsesLessBandwidthStaticControl2 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.UsesLessBandwidthStaticControl2);
                }
                return this.cachedUsesLessBandwidthStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToleranceStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.ToleranceStaticControl3
        {
            get
            {
                if ((this.cachedToleranceStaticControl3 == null))
                {
                    this.cachedToleranceStaticControl3 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.ToleranceStaticControl3);
                }
                return this.cachedToleranceStaticControl3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToleranceStaticControl4 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.ToleranceStaticControl4
        {
            get
            {
                if ((this.cachedToleranceStaticControl4 == null))
                {
                    this.cachedToleranceStaticControl4 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.ToleranceStaticControl4);
                }
                return this.cachedToleranceStaticControl4;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NotCollectedSampleStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.NotCollectedSampleStaticControl2
        {
            get
            {
                if ((this.cachedNotCollectedSampleStaticControl2 == null))
                {
                    this.cachedNotCollectedSampleStaticControl2 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.NotCollectedSampleStaticControl2);
                }
                return this.cachedNotCollectedSampleStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CollectedSampleStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.CollectedSampleStaticControl2
        {
            get
            {
                if ((this.cachedCollectedSampleStaticControl2 == null))
                {
                    this.cachedCollectedSampleStaticControl2 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.CollectedSampleStaticControl2);
                }
                return this.cachedCollectedSampleStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UsesMoreBandwidthStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.UsesMoreBandwidthStaticControl3
        {
            get
            {
                if ((this.cachedUsesMoreBandwidthStaticControl3 == null))
                {
                    this.cachedUsesMoreBandwidthStaticControl3 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.UsesMoreBandwidthStaticControl3);
                }
                return this.cachedUsesMoreBandwidthStaticControl3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MoreAccuracyStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.MoreAccuracyStaticControl3
        {
            get
            {
                if ((this.cachedMoreAccuracyStaticControl3 == null))
                {
                    this.cachedMoreAccuracyStaticControl3 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.MoreAccuracyStaticControl3);
                }
                return this.cachedMoreAccuracyStaticControl3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StoresMoreDataInTheDatabaseStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.StoresMoreDataInTheDatabaseStaticControl3
        {
            get
            {
                if ((this.cachedStoresMoreDataInTheDatabaseStaticControl3 == null))
                {
                    this.cachedStoresMoreDataInTheDatabaseStaticControl3 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.StoresMoreDataInTheDatabaseStaticControl3);
                }
                return this.cachedStoresMoreDataInTheDatabaseStaticControl3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LowOptimizationStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.LowOptimizationStaticControl3
        {
            get
            {
                if ((this.cachedLowOptimizationStaticControl3 == null))
                {
                    this.cachedLowOptimizationStaticControl3 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.LowOptimizationStaticControl3);
                }
                return this.cachedLowOptimizationStaticControl3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HighOptimizationStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.HighOptimizationStaticControl3
        {
            get
            {
                if ((this.cachedHighOptimizationStaticControl3 == null))
                {
                    this.cachedHighOptimizationStaticControl3 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.HighOptimizationStaticControl3);
                }
                return this.cachedHighOptimizationStaticControl3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StoresLessDataInTheDatabaseStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.StoresLessDataInTheDatabaseStaticControl3
        {
            get
            {
                if ((this.cachedStoresLessDataInTheDatabaseStaticControl3 == null))
                {
                    this.cachedStoresLessDataInTheDatabaseStaticControl3 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.StoresLessDataInTheDatabaseStaticControl3);
                }
                return this.cachedStoresLessDataInTheDatabaseStaticControl3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LessAccuracyStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.LessAccuracyStaticControl3
        {
            get
            {
                if ((this.cachedLessAccuracyStaticControl3 == null))
                {
                    this.cachedLessAccuracyStaticControl3 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.LessAccuracyStaticControl3);
                }
                return this.cachedLessAccuracyStaticControl3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UsesLessBandwidthStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.UsesLessBandwidthStaticControl3
        {
            get
            {
                if ((this.cachedUsesLessBandwidthStaticControl3 == null))
                {
                    this.cachedUsesLessBandwidthStaticControl3 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.UsesLessBandwidthStaticControl3);
                }
                return this.cachedUsesLessBandwidthStaticControl3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToleranceStaticControl5 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.ToleranceStaticControl5
        {
            get
            {
                if ((this.cachedToleranceStaticControl5 == null))
                {
                    this.cachedToleranceStaticControl5 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.ToleranceStaticControl5);
                }
                return this.cachedToleranceStaticControl5;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ToleranceStaticControl6 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.ToleranceStaticControl6
        {
            get
            {
                if ((this.cachedToleranceStaticControl6 == null))
                {
                    this.cachedToleranceStaticControl6 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.ToleranceStaticControl6);
                }
                return this.cachedToleranceStaticControl6;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NotCollectedSampleStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.NotCollectedSampleStaticControl3
        {
            get
            {
                if ((this.cachedNotCollectedSampleStaticControl3 == null))
                {
                    this.cachedNotCollectedSampleStaticControl3 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.NotCollectedSampleStaticControl3);
                }
                return this.cachedNotCollectedSampleStaticControl3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CollectedSampleStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.CollectedSampleStaticControl3
        {
            get
            {
                if ((this.cachedCollectedSampleStaticControl3 == null))
                {
                    this.cachedCollectedSampleStaticControl3 = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.CollectedSampleStaticControl3);
                }
                return this.cachedCollectedSampleStaticControl3;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WhichWillIncreaseTheBandwidthForTheAgentToServerCommunicationStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.WhichWillIncreaseTheBandwidthForTheAgentToServerCommunicationStaticControl
        {
            get
            {
                if ((this.cachedWhichWillIncreaseTheBandwidthForTheAgentToServerCommunicationStaticControl == null))
                {
                    this.cachedWhichWillIncreaseTheBandwidthForTheAgentToServerCommunicationStaticControl = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.WhichWillIncreaseTheBandwidthForTheAgentToServerCommunicationStaticControl);
                }
                return this.cachedWhichWillIncreaseTheBandwidthForTheAgentToServerCommunicationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OptimizedCollectionHelpsReduceThePerformanceCounterSampleVolumeStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.OptimizedCollectionHelpsReduceThePerformanceCounterSampleVolumeStaticControl
        {
            get
            {
                if ((this.cachedOptimizedCollectionHelpsReduceThePerformanceCounterSampleVolumeStaticControl == null))
                {
                    this.cachedOptimizedCollectionHelpsReduceThePerformanceCounterSampleVolumeStaticControl = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.OptimizedCollectionHelpsReduceThePerformanceCounterSampleVolumeStaticControl);
                }
                return this.cachedOptimizedCollectionHelpsReduceThePerformanceCounterSampleVolumeStaticControl;
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
        StaticControl IOptimizedCollectionDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OptimizedPerformanceCollectionSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IOptimizedCollectionDialogControls.OptimizedPerformanceCollectionSettingsStaticControl
        {
            get
            {
                if ((this.cachedOptimizedPerformanceCollectionSettingsStaticControl == null))
                {
                    this.cachedOptimizedPerformanceCollectionSettingsStaticControl = new StaticControl(this, OptimizedCollectionDialog.ControlIDs.OptimizedPerformanceCollectionSettingsStaticControl);
                }
                return this.cachedOptimizedPerformanceCollectionSettingsStaticControl;
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
        ///  Routine to click on button UseOptimization
        /// </summary>
        /// <history>
        /// 	[mbickle] 29APR06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickUseOptimization()
        {
            this.Controls.UseOptimizationCheckBox.Click();
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
                tempWindow = new Window(Strings.DialogTitle
                    + "*",
                    StringMatchSyntax.WildCard);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // locate the dialog
                tempWindow = null;
                int numberOfTries = 0;
                const int MAXTRIES = 10;
                Core.Common.Utilities.LogMessage("Looking for window with title:  '"
                    + Strings.DialogTitle + "'");

                while (tempWindow == null && numberOfTries < MAXTRIES)
                {
                    // log the attempt
                    numberOfTries++;
                    try
                    {
                        // look for the dialogue again using wildcard matching
                        tempWindow = new Window(
                            Strings.DialogTitle + "*",
                            StringMatchSyntax.WildCard);

                        // If the window is not found then this wait is never called
                        // Hence added the sleep call in catch block
                        // Wait for the window to report that is ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Window.Exceptions.WindowNotFoundException)
                    {
                        //sleep to wait for window search
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // log the outcome of this attempt
                        Core.Common.Utilities.LogMessage("Attempt "
                            + numberOfTries
                            + " of "
                            + MAXTRIES
                            + "...");
                    }
                }
                // check for success
                if (tempWindow == null)
                {
                    throw new Window.Exceptions.WindowNotFoundException(
                        "Init function could not find or bring up the window"
                        + "with a title of '" + Strings.DialogTitle
                        + "'.\n\n" + ex.Message);
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
            private const string ResourceDialogTitle = ";Create Rule Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateRuleWizard";
            
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
            /// Contains resource string for:  RuleType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRuleType = ";Rule Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.ChooseRuleTypePage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;GeneralPropertyPageTabText";
            
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
            /// Contains resource string for:  OptimizedCollection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOptimizedCollection = ";Optimized Collection;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Pages.OptimizedCollection.Localized" +
                "Strings;Title";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Percentage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePercentage = ";Percentage :;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Internal.UI.Authoring.Pages.OptimizedCollection;percentageradioButton.Text" +
                "";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AbsoluteNumber
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAbsoluteNumber = ";Absolute number :;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;absolueteradioButton." +
                "Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SetToleranceTo
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSetToleranceTo = ";Set tolerance to:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label15.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UseOptimization
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUseOptimization = ";Use Optimization (cannot be changed once wizard completes);ManagedString;Microso" +
                "ft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages." +
                "OptimizedCollection;OptimizeCheckbox.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UsesMoreBandwidth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUsesMoreBandwidth = ";- Uses more bandwidth;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label16.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MoreAccuracy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMoreAccuracy = ";- More accuracy;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label17.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  StoresMoreDataInTheDatabase
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStoresMoreDataInTheDatabase = ";- Stores more data in the database;ManagedString;Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;labe" +
                "l10.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LowOptimization
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLowOptimization = ";Low optimization:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label19.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HighOptimization
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHighOptimization = ";High optimization:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label20.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  StoresLessDataInTheDatabase
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStoresLessDataInTheDatabase = ";- Stores less data in the database;ManagedString;Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;labe" +
                "l21.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LessAccuracy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLessAccuracy = ";- Less accuracy;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label22.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UsesLessBandwidth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUsesLessBandwidth = ";- Uses less bandwidth;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label23.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tolerance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTolerance = ";tolerance;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.OptimizedCollection;label12.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tolerance2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTolerance2 = ";tolerance;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.OptimizedCollection;label12.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NotCollectedSample
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotCollectedSample = ";Not collected sample;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label14.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CollectedSample
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCollectedSample = ";Collected sample;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label13.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UsesMoreBandwidth2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUsesMoreBandwidth2 = ";- Uses more bandwidth;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label16.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MoreAccuracy2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMoreAccuracy2 = ";- More accuracy;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label17.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  StoresMoreDataInTheDatabase2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStoresMoreDataInTheDatabase2 = ";- Stores more data in the database;ManagedString;Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;labe" +
                "l10.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LowOptimization2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLowOptimization2 = ";Low optimization:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label19.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HighOptimization2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHighOptimization2 = ";High optimization:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label20.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  StoresLessDataInTheDatabase2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStoresLessDataInTheDatabase2 = ";- Stores less data in the database;ManagedString;Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;labe" +
                "l21.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LessAccuracy2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLessAccuracy2 = ";- Less accuracy;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label22.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UsesLessBandwidth2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUsesLessBandwidth2 = ";- Uses less bandwidth;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label23.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tolerance3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTolerance3 = ";tolerance;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.OptimizedCollection;label12.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tolerance4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTolerance4 = ";tolerance;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.OptimizedCollection;label12.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NotCollectedSample2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotCollectedSample2 = ";Not collected sample;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label14.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CollectedSample2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCollectedSample2 = ";Collected sample;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label13.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UsesMoreBandwidth3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUsesMoreBandwidth3 = ";- Uses more bandwidth;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label16.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MoreAccuracy3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMoreAccuracy3 = ";- More accuracy;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label17.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  StoresMoreDataInTheDatabase3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStoresMoreDataInTheDatabase3 = ";- Stores more data in the database;ManagedString;Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;labe" +
                "l10.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LowOptimization3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLowOptimization3 = ";Low optimization:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterp" +
                "riseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label19.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HighOptimization3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHighOptimization3 = ";High optimization:;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label20.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  StoresLessDataInTheDatabase3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceStoresLessDataInTheDatabase3 = ";- Stores less data in the database;ManagedString;Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;labe" +
                "l21.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LessAccuracy3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLessAccuracy3 = ";- Less accuracy;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpri" +
                "seManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label22.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UsesLessBandwidth3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUsesLessBandwidth3 = ";- Uses less bandwidth;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label23.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tolerance5
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTolerance5 = ";tolerance;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.OptimizedCollection;label12.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tolerance6
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTolerance6 = ";tolerance;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.OptimizedCollection;label12.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NotCollectedSample3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNotCollectedSample3 = ";Not collected sample;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label14.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  CollectedSample3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCollectedSample3 = ";Collected sample;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.OptimizedCollection;label13.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WhichWillIncreaseTheBandwidthForTheAgentToServerCommunication
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWhichWillIncreaseTheBandwidthForTheAgentToServerCommunication = ";which will increase the bandwidth for the agent to server communication.;Managed" +
                "String;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Intern" +
                "al.UI.Authoring.Pages.OptimizedCollection;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OptimizedCollectionHelpsReduceThePerformanceCounterSampleVolume
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOptimizedCollectionHelpsReduceThePerformanceCounterSampleVolume = ";Optimized collection helps reduce the performance counter sample volume,;Managed" +
                "String;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Intern" +
                "al.UI.Authoring.Pages.OptimizedCollection;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OptimizedPerformanceCollectionSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOptimizedPerformanceCollectionSettings = ";Optimized Performance Collection Settings;ManagedString;Microsoft.MOM.UI.Compone" +
                "nts.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.PagesOptimize" +
                "dCollection.LocalizedStrings;SubTitle";
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
            /// Caches the translated resource string for:  PerformanceCounter
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPerformanceCounter;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OptimizedCollection
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOptimizedCollection;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Percentage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPercentage;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AbsoluteNumber
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAbsoluteNumber;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SetToleranceTo
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSetToleranceTo;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UseOptimization
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUseOptimization;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UsesMoreBandwidth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUsesMoreBandwidth;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MoreAccuracy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMoreAccuracy;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  StoresMoreDataInTheDatabase
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStoresMoreDataInTheDatabase;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LowOptimization
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLowOptimization;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HighOptimization
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHighOptimization;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  StoresLessDataInTheDatabase
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStoresLessDataInTheDatabase;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LessAccuracy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLessAccuracy;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UsesLessBandwidth
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUsesLessBandwidth;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tolerance
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTolerance;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tolerance2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTolerance2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NotCollectedSample
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNotCollectedSample;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CollectedSample
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCollectedSample;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UsesMoreBandwidth2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUsesMoreBandwidth2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MoreAccuracy2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMoreAccuracy2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  StoresMoreDataInTheDatabase2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStoresMoreDataInTheDatabase2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LowOptimization2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLowOptimization2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HighOptimization2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHighOptimization2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  StoresLessDataInTheDatabase2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStoresLessDataInTheDatabase2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LessAccuracy2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLessAccuracy2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UsesLessBandwidth2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUsesLessBandwidth2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tolerance3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTolerance3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tolerance4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTolerance4;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NotCollectedSample2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNotCollectedSample2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CollectedSample2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCollectedSample2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UsesMoreBandwidth3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUsesMoreBandwidth3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MoreAccuracy3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMoreAccuracy3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  StoresMoreDataInTheDatabase3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStoresMoreDataInTheDatabase3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LowOptimization3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLowOptimization3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HighOptimization3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHighOptimization3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  StoresLessDataInTheDatabase3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStoresLessDataInTheDatabase3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LessAccuracy3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLessAccuracy3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  UsesLessBandwidth3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUsesLessBandwidth3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tolerance5
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTolerance5;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tolerance6
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTolerance6;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NotCollectedSample3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNotCollectedSample3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  CollectedSample3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCollectedSample3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WhichWillIncreaseTheBandwidthForTheAgentToServerCommunication
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWhichWillIncreaseTheBandwidthForTheAgentToServerCommunication;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OptimizedCollectionHelpsReduceThePerformanceCounterSampleVolume
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOptimizedCollectionHelpsReduceThePerformanceCounterSampleVolume;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OptimizedPerformanceCollectionSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOptimizedPerformanceCollectionSettings;
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
            /// Exposes access to the RuleType translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
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
            /// Exposes access to the OptimizedCollection translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OptimizedCollection
            {
                get
                {
                    if ((cachedOptimizedCollection == null))
                    {
                        cachedOptimizedCollection = CoreManager.MomConsole.GetIntlStr(ResourceOptimizedCollection);
                    }
                    return cachedOptimizedCollection;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Percentage translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Percentage
            {
                get
                {
                    if ((cachedPercentage == null))
                    {
                        cachedPercentage = CoreManager.MomConsole.GetIntlStr(ResourcePercentage);
                    }
                    return cachedPercentage;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AbsoluteNumber translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AbsoluteNumber
            {
                get
                {
                    if ((cachedAbsoluteNumber == null))
                    {
                        cachedAbsoluteNumber = CoreManager.MomConsole.GetIntlStr(ResourceAbsoluteNumber);
                    }
                    return cachedAbsoluteNumber;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SetToleranceTo translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SetToleranceTo
            {
                get
                {
                    if ((cachedSetToleranceTo == null))
                    {
                        cachedSetToleranceTo = CoreManager.MomConsole.GetIntlStr(ResourceSetToleranceTo);
                    }
                    return cachedSetToleranceTo;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UseOptimization translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UseOptimization
            {
                get
                {
                    if ((cachedUseOptimization == null))
                    {
                        cachedUseOptimization = CoreManager.MomConsole.GetIntlStr(ResourceUseOptimization);
                    }
                    return cachedUseOptimization;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UsesMoreBandwidth translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UsesMoreBandwidth
            {
                get
                {
                    if ((cachedUsesMoreBandwidth == null))
                    {
                        cachedUsesMoreBandwidth = CoreManager.MomConsole.GetIntlStr(ResourceUsesMoreBandwidth);
                    }
                    return cachedUsesMoreBandwidth;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MoreAccuracy translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MoreAccuracy
            {
                get
                {
                    if ((cachedMoreAccuracy == null))
                    {
                        cachedMoreAccuracy = CoreManager.MomConsole.GetIntlStr(ResourceMoreAccuracy);
                    }
                    return cachedMoreAccuracy;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the StoresMoreDataInTheDatabase translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StoresMoreDataInTheDatabase
            {
                get
                {
                    if ((cachedStoresMoreDataInTheDatabase == null))
                    {
                        cachedStoresMoreDataInTheDatabase = CoreManager.MomConsole.GetIntlStr(ResourceStoresMoreDataInTheDatabase);
                    }
                    return cachedStoresMoreDataInTheDatabase;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LowOptimization translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LowOptimization
            {
                get
                {
                    if ((cachedLowOptimization == null))
                    {
                        cachedLowOptimization = CoreManager.MomConsole.GetIntlStr(ResourceLowOptimization);
                    }
                    return cachedLowOptimization;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HighOptimization translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HighOptimization
            {
                get
                {
                    if ((cachedHighOptimization == null))
                    {
                        cachedHighOptimization = CoreManager.MomConsole.GetIntlStr(ResourceHighOptimization);
                    }
                    return cachedHighOptimization;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the StoresLessDataInTheDatabase translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StoresLessDataInTheDatabase
            {
                get
                {
                    if ((cachedStoresLessDataInTheDatabase == null))
                    {
                        cachedStoresLessDataInTheDatabase = CoreManager.MomConsole.GetIntlStr(ResourceStoresLessDataInTheDatabase);
                    }
                    return cachedStoresLessDataInTheDatabase;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LessAccuracy translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LessAccuracy
            {
                get
                {
                    if ((cachedLessAccuracy == null))
                    {
                        cachedLessAccuracy = CoreManager.MomConsole.GetIntlStr(ResourceLessAccuracy);
                    }
                    return cachedLessAccuracy;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UsesLessBandwidth translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UsesLessBandwidth
            {
                get
                {
                    if ((cachedUsesLessBandwidth == null))
                    {
                        cachedUsesLessBandwidth = CoreManager.MomConsole.GetIntlStr(ResourceUsesLessBandwidth);
                    }
                    return cachedUsesLessBandwidth;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tolerance translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tolerance
            {
                get
                {
                    if ((cachedTolerance == null))
                    {
                        cachedTolerance = CoreManager.MomConsole.GetIntlStr(ResourceTolerance);
                    }
                    return cachedTolerance;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tolerance2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tolerance2
            {
                get
                {
                    if ((cachedTolerance2 == null))
                    {
                        cachedTolerance2 = CoreManager.MomConsole.GetIntlStr(ResourceTolerance2);
                    }
                    return cachedTolerance2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotCollectedSample translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotCollectedSample
            {
                get
                {
                    if ((cachedNotCollectedSample == null))
                    {
                        cachedNotCollectedSample = CoreManager.MomConsole.GetIntlStr(ResourceNotCollectedSample);
                    }
                    return cachedNotCollectedSample;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CollectedSample translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CollectedSample
            {
                get
                {
                    if ((cachedCollectedSample == null))
                    {
                        cachedCollectedSample = CoreManager.MomConsole.GetIntlStr(ResourceCollectedSample);
                    }
                    return cachedCollectedSample;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UsesMoreBandwidth2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UsesMoreBandwidth2
            {
                get
                {
                    if ((cachedUsesMoreBandwidth2 == null))
                    {
                        cachedUsesMoreBandwidth2 = CoreManager.MomConsole.GetIntlStr(ResourceUsesMoreBandwidth2);
                    }
                    return cachedUsesMoreBandwidth2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MoreAccuracy2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MoreAccuracy2
            {
                get
                {
                    if ((cachedMoreAccuracy2 == null))
                    {
                        cachedMoreAccuracy2 = CoreManager.MomConsole.GetIntlStr(ResourceMoreAccuracy2);
                    }
                    return cachedMoreAccuracy2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the StoresMoreDataInTheDatabase2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StoresMoreDataInTheDatabase2
            {
                get
                {
                    if ((cachedStoresMoreDataInTheDatabase2 == null))
                    {
                        cachedStoresMoreDataInTheDatabase2 = CoreManager.MomConsole.GetIntlStr(ResourceStoresMoreDataInTheDatabase2);
                    }
                    return cachedStoresMoreDataInTheDatabase2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LowOptimization2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LowOptimization2
            {
                get
                {
                    if ((cachedLowOptimization2 == null))
                    {
                        cachedLowOptimization2 = CoreManager.MomConsole.GetIntlStr(ResourceLowOptimization2);
                    }
                    return cachedLowOptimization2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HighOptimization2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HighOptimization2
            {
                get
                {
                    if ((cachedHighOptimization2 == null))
                    {
                        cachedHighOptimization2 = CoreManager.MomConsole.GetIntlStr(ResourceHighOptimization2);
                    }
                    return cachedHighOptimization2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the StoresLessDataInTheDatabase2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StoresLessDataInTheDatabase2
            {
                get
                {
                    if ((cachedStoresLessDataInTheDatabase2 == null))
                    {
                        cachedStoresLessDataInTheDatabase2 = CoreManager.MomConsole.GetIntlStr(ResourceStoresLessDataInTheDatabase2);
                    }
                    return cachedStoresLessDataInTheDatabase2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LessAccuracy2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LessAccuracy2
            {
                get
                {
                    if ((cachedLessAccuracy2 == null))
                    {
                        cachedLessAccuracy2 = CoreManager.MomConsole.GetIntlStr(ResourceLessAccuracy2);
                    }
                    return cachedLessAccuracy2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UsesLessBandwidth2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UsesLessBandwidth2
            {
                get
                {
                    if ((cachedUsesLessBandwidth2 == null))
                    {
                        cachedUsesLessBandwidth2 = CoreManager.MomConsole.GetIntlStr(ResourceUsesLessBandwidth2);
                    }
                    return cachedUsesLessBandwidth2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tolerance3 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tolerance3
            {
                get
                {
                    if ((cachedTolerance3 == null))
                    {
                        cachedTolerance3 = CoreManager.MomConsole.GetIntlStr(ResourceTolerance3);
                    }
                    return cachedTolerance3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tolerance4 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tolerance4
            {
                get
                {
                    if ((cachedTolerance4 == null))
                    {
                        cachedTolerance4 = CoreManager.MomConsole.GetIntlStr(ResourceTolerance4);
                    }
                    return cachedTolerance4;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotCollectedSample2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotCollectedSample2
            {
                get
                {
                    if ((cachedNotCollectedSample2 == null))
                    {
                        cachedNotCollectedSample2 = CoreManager.MomConsole.GetIntlStr(ResourceNotCollectedSample2);
                    }
                    return cachedNotCollectedSample2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CollectedSample2 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CollectedSample2
            {
                get
                {
                    if ((cachedCollectedSample2 == null))
                    {
                        cachedCollectedSample2 = CoreManager.MomConsole.GetIntlStr(ResourceCollectedSample2);
                    }
                    return cachedCollectedSample2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UsesMoreBandwidth3 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UsesMoreBandwidth3
            {
                get
                {
                    if ((cachedUsesMoreBandwidth3 == null))
                    {
                        cachedUsesMoreBandwidth3 = CoreManager.MomConsole.GetIntlStr(ResourceUsesMoreBandwidth3);
                    }
                    return cachedUsesMoreBandwidth3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MoreAccuracy3 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MoreAccuracy3
            {
                get
                {
                    if ((cachedMoreAccuracy3 == null))
                    {
                        cachedMoreAccuracy3 = CoreManager.MomConsole.GetIntlStr(ResourceMoreAccuracy3);
                    }
                    return cachedMoreAccuracy3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the StoresMoreDataInTheDatabase3 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StoresMoreDataInTheDatabase3
            {
                get
                {
                    if ((cachedStoresMoreDataInTheDatabase3 == null))
                    {
                        cachedStoresMoreDataInTheDatabase3 = CoreManager.MomConsole.GetIntlStr(ResourceStoresMoreDataInTheDatabase3);
                    }
                    return cachedStoresMoreDataInTheDatabase3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LowOptimization3 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LowOptimization3
            {
                get
                {
                    if ((cachedLowOptimization3 == null))
                    {
                        cachedLowOptimization3 = CoreManager.MomConsole.GetIntlStr(ResourceLowOptimization3);
                    }
                    return cachedLowOptimization3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HighOptimization3 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HighOptimization3
            {
                get
                {
                    if ((cachedHighOptimization3 == null))
                    {
                        cachedHighOptimization3 = CoreManager.MomConsole.GetIntlStr(ResourceHighOptimization3);
                    }
                    return cachedHighOptimization3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the StoresLessDataInTheDatabase3 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StoresLessDataInTheDatabase3
            {
                get
                {
                    if ((cachedStoresLessDataInTheDatabase3 == null))
                    {
                        cachedStoresLessDataInTheDatabase3 = CoreManager.MomConsole.GetIntlStr(ResourceStoresLessDataInTheDatabase3);
                    }
                    return cachedStoresLessDataInTheDatabase3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LessAccuracy3 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LessAccuracy3
            {
                get
                {
                    if ((cachedLessAccuracy3 == null))
                    {
                        cachedLessAccuracy3 = CoreManager.MomConsole.GetIntlStr(ResourceLessAccuracy3);
                    }
                    return cachedLessAccuracy3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UsesLessBandwidth3 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UsesLessBandwidth3
            {
                get
                {
                    if ((cachedUsesLessBandwidth3 == null))
                    {
                        cachedUsesLessBandwidth3 = CoreManager.MomConsole.GetIntlStr(ResourceUsesLessBandwidth3);
                    }
                    return cachedUsesLessBandwidth3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tolerance5 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tolerance5
            {
                get
                {
                    if ((cachedTolerance5 == null))
                    {
                        cachedTolerance5 = CoreManager.MomConsole.GetIntlStr(ResourceTolerance5);
                    }
                    return cachedTolerance5;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tolerance6 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tolerance6
            {
                get
                {
                    if ((cachedTolerance6 == null))
                    {
                        cachedTolerance6 = CoreManager.MomConsole.GetIntlStr(ResourceTolerance6);
                    }
                    return cachedTolerance6;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotCollectedSample3 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotCollectedSample3
            {
                get
                {
                    if ((cachedNotCollectedSample3 == null))
                    {
                        cachedNotCollectedSample3 = CoreManager.MomConsole.GetIntlStr(ResourceNotCollectedSample3);
                    }
                    return cachedNotCollectedSample3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CollectedSample3 translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CollectedSample3
            {
                get
                {
                    if ((cachedCollectedSample3 == null))
                    {
                        cachedCollectedSample3 = CoreManager.MomConsole.GetIntlStr(ResourceCollectedSample3);
                    }
                    return cachedCollectedSample3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WhichWillIncreaseTheBandwidthForTheAgentToServerCommunication translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WhichWillIncreaseTheBandwidthForTheAgentToServerCommunication
            {
                get
                {
                    if ((cachedWhichWillIncreaseTheBandwidthForTheAgentToServerCommunication == null))
                    {
                        cachedWhichWillIncreaseTheBandwidthForTheAgentToServerCommunication = CoreManager.MomConsole.GetIntlStr(ResourceWhichWillIncreaseTheBandwidthForTheAgentToServerCommunication);
                    }
                    return cachedWhichWillIncreaseTheBandwidthForTheAgentToServerCommunication;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OptimizedCollectionHelpsReduceThePerformanceCounterSampleVolume translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OptimizedCollectionHelpsReduceThePerformanceCounterSampleVolume
            {
                get
                {
                    if ((cachedOptimizedCollectionHelpsReduceThePerformanceCounterSampleVolume == null))
                    {
                        cachedOptimizedCollectionHelpsReduceThePerformanceCounterSampleVolume = CoreManager.MomConsole.GetIntlStr(ResourceOptimizedCollectionHelpsReduceThePerformanceCounterSampleVolume);
                    }
                    return cachedOptimizedCollectionHelpsReduceThePerformanceCounterSampleVolume;
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
            /// Exposes access to the OptimizedPerformanceCollectionSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 29APR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OptimizedPerformanceCollectionSettings
            {
                get
                {
                    if ((cachedOptimizedPerformanceCollectionSettings == null))
                    {
                        cachedOptimizedPerformanceCollectionSettings = CoreManager.MomConsole.GetIntlStr(ResourceOptimizedPerformanceCollectionSettings);
                    }
                    return cachedOptimizedPerformanceCollectionSettings;
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
            /// Control ID for RuleTypeStaticControl
            /// </summary>
            public const string RuleTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralStaticControl
            /// </summary>
            public const string GeneralStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for PerformanceCounterStaticControl
            /// </summary>
            public const string PerformanceCounterStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for OptimizedCollectionStaticControl
            /// </summary>
            public const string OptimizedCollectionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for Percentage
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Percentage = "percentageUpDown";
            
            /// <summary>
            /// Control ID for AbsoluteNumber
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string AbsoluteNumber = "absoluteUpDown";
            
            /// <summary>
            /// Control ID for PercentageRadioButton
            /// </summary>
            public const string PercentageRadioButton = "percentageradioButton";
            
            /// <summary>
            /// Control ID for AbsoluteNumberRadioButton
            /// </summary>
            public const string AbsoluteNumberRadioButton = "absolueteradioButton";
            
            /// <summary>
            /// Control ID for SetToleranceToStaticControl
            /// </summary>
            public const string SetToleranceToStaticControl = "label15";
            
            /// <summary>
            /// Control ID for UseOptimizationCheckBox
            /// </summary>
            public const string UseOptimizationCheckBox = "OptimizeCheckbox";
            
            /// <summary>
            /// Control ID for UsesMoreBandwidthStaticControl
            /// </summary>
            public const string UsesMoreBandwidthStaticControl = "label24";
            
            /// <summary>
            /// Control ID for MoreAccuracyStaticControl
            /// </summary>
            public const string MoreAccuracyStaticControl = "label29";
            
            /// <summary>
            /// Control ID for StoresMoreDataInTheDatabaseStaticControl
            /// </summary>
            public const string StoresMoreDataInTheDatabaseStaticControl = "label30";
            
            /// <summary>
            /// Control ID for LowOptimizationStaticControl
            /// </summary>
            public const string LowOptimizationStaticControl = "label31";
            
            /// <summary>
            /// Control ID for HighOptimizationStaticControl
            /// </summary>
            public const string HighOptimizationStaticControl = "label32";
            
            /// <summary>
            /// Control ID for StoresLessDataInTheDatabaseStaticControl
            /// </summary>
            public const string StoresLessDataInTheDatabaseStaticControl = "label33";
            
            /// <summary>
            /// Control ID for LessAccuracyStaticControl
            /// </summary>
            public const string LessAccuracyStaticControl = "label34";
            
            /// <summary>
            /// Control ID for UsesLessBandwidthStaticControl
            /// </summary>
            public const string UsesLessBandwidthStaticControl = "label35";
            
            /// <summary>
            /// Control ID for ToleranceStaticControl
            /// </summary>
            public const string ToleranceStaticControl = "label36";
            
            /// <summary>
            /// Control ID for ToleranceStaticControl2
            /// </summary>
            public const string ToleranceStaticControl2 = "label37";
            
            /// <summary>
            /// Control ID for NotCollectedSampleStaticControl
            /// </summary>
            public const string NotCollectedSampleStaticControl = "label38";
            
            /// <summary>
            /// Control ID for CollectedSampleStaticControl
            /// </summary>
            public const string CollectedSampleStaticControl = "label39";
            
            /// <summary>
            /// Control ID for UsesMoreBandwidthStaticControl2
            /// </summary>
            public const string UsesMoreBandwidthStaticControl2 = "label16";
            
            /// <summary>
            /// Control ID for MoreAccuracyStaticControl2
            /// </summary>
            public const string MoreAccuracyStaticControl2 = "label17";
            
            /// <summary>
            /// Control ID for StoresMoreDataInTheDatabaseStaticControl2
            /// </summary>
            public const string StoresMoreDataInTheDatabaseStaticControl2 = "label18";
            
            /// <summary>
            /// Control ID for LowOptimizationStaticControl2
            /// </summary>
            public const string LowOptimizationStaticControl2 = "label19";
            
            /// <summary>
            /// Control ID for HighOptimizationStaticControl2
            /// </summary>
            public const string HighOptimizationStaticControl2 = "label20";
            
            /// <summary>
            /// Control ID for StoresLessDataInTheDatabaseStaticControl2
            /// </summary>
            public const string StoresLessDataInTheDatabaseStaticControl2 = "label21";
            
            /// <summary>
            /// Control ID for LessAccuracyStaticControl2
            /// </summary>
            public const string LessAccuracyStaticControl2 = "label22";
            
            /// <summary>
            /// Control ID for UsesLessBandwidthStaticControl2
            /// </summary>
            public const string UsesLessBandwidthStaticControl2 = "label23";
            
            /// <summary>
            /// Control ID for ToleranceStaticControl3
            /// </summary>
            public const string ToleranceStaticControl3 = "label28";
            
            /// <summary>
            /// Control ID for ToleranceStaticControl4
            /// </summary>
            public const string ToleranceStaticControl4 = "label25";
            
            /// <summary>
            /// Control ID for NotCollectedSampleStaticControl2
            /// </summary>
            public const string NotCollectedSampleStaticControl2 = "label26";
            
            /// <summary>
            /// Control ID for CollectedSampleStaticControl2
            /// </summary>
            public const string CollectedSampleStaticControl2 = "label27";
            
            /// <summary>
            /// Control ID for UsesMoreBandwidthStaticControl3
            /// </summary>
            public const string UsesMoreBandwidthStaticControl3 = "label8";
            
            /// <summary>
            /// Control ID for MoreAccuracyStaticControl3
            /// </summary>
            public const string MoreAccuracyStaticControl3 = "label9";
            
            /// <summary>
            /// Control ID for StoresMoreDataInTheDatabaseStaticControl3
            /// </summary>
            public const string StoresMoreDataInTheDatabaseStaticControl3 = "label10";
            
            /// <summary>
            /// Control ID for LowOptimizationStaticControl3
            /// </summary>
            public const string LowOptimizationStaticControl3 = "label4";
            
            /// <summary>
            /// Control ID for HighOptimizationStaticControl3
            /// </summary>
            public const string HighOptimizationStaticControl3 = "label3";
            
            /// <summary>
            /// Control ID for StoresLessDataInTheDatabaseStaticControl3
            /// </summary>
            public const string StoresLessDataInTheDatabaseStaticControl3 = "label5";
            
            /// <summary>
            /// Control ID for LessAccuracyStaticControl3
            /// </summary>
            public const string LessAccuracyStaticControl3 = "label6";
            
            /// <summary>
            /// Control ID for UsesLessBandwidthStaticControl3
            /// </summary>
            public const string UsesLessBandwidthStaticControl3 = "label7";
            
            /// <summary>
            /// Control ID for ToleranceStaticControl5
            /// </summary>
            public const string ToleranceStaticControl5 = "label12";
            
            /// <summary>
            /// Control ID for ToleranceStaticControl6
            /// </summary>
            public const string ToleranceStaticControl6 = "label11";
            
            /// <summary>
            /// Control ID for NotCollectedSampleStaticControl3
            /// </summary>
            public const string NotCollectedSampleStaticControl3 = "label14";
            
            /// <summary>
            /// Control ID for CollectedSampleStaticControl3
            /// </summary>
            public const string CollectedSampleStaticControl3 = "label13";
            
            /// <summary>
            /// Control ID for WhichWillIncreaseTheBandwidthForTheAgentToServerCommunicationStaticControl
            /// </summary>
            public const string WhichWillIncreaseTheBandwidthForTheAgentToServerCommunicationStaticControl = "label2";
            
            /// <summary>
            /// Control ID for OptimizedCollectionHelpsReduceThePerformanceCounterSampleVolumeStaticControl
            /// </summary>
            public const string OptimizedCollectionHelpsReduceThePerformanceCounterSampleVolumeStaticControl = "label1";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for OptimizedPerformanceCollectionSettingsStaticControl
            /// </summary>
            public const string OptimizedPerformanceCollectionSettingsStaticControl = "headerLabel";
        }
        #endregion
    }
}
