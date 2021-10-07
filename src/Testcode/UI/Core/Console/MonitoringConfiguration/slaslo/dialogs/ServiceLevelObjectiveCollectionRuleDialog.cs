// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ServiceLevelObjectiveCollectionRuleDialog.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	Proxy class that represent the Collection Rule Type of SLO
// </project>
// <summary>
// 	Proxy class that represent the Collection Rule Type of SLO
// </summary>
// <history>
// 	[dialac] 9/25/2008 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.SLASLO.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - RadioGroup0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroup0
    /// </summary>
    /// <history>
    /// 	[dialac] 9/25/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum AggregationMethodRadioGroup
    {
        /// <summary>
        /// Max = 0
        /// </summary>
        Max = 0,
        
        /// <summary>
        /// Min = 1
        /// </summary>
        Min = 1,
        
        /// <summary>
        /// Average = 2
        /// </summary>
        Average = 2,
    }
    #endregion
    
    #region Interface Definition - IServiceLevelObjectiveCollectionRuleDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IServiceLevelObjectiveCollectionRuleDialogControls, for ServiceLevelObjectiveCollectionRuleDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 9/25/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IServiceLevelObjectiveCollectionRuleDialogControls
    {
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
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
        /// Read-only property to access GoalTextBox
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TextBox GoalTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceLevelObjectiveGoalComboBox
        /// </summary>
        EditComboBox ServiceLevelObjectiveGoalComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceLevelObjectiveGoalStaticControl
        /// </summary>
        StaticControl ServiceLevelObjectiveGoalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MaxRadioButton
        /// </summary>
        RadioButton MaxRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MinRadioButton
        /// </summary>
        RadioButton MinRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AverageRadioButton
        /// </summary>
        RadioButton AverageRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AggregationMethodStaticControl
        /// </summary>
        StaticControl AggregationMethodStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectRuleButton
        /// </summary>
        Button SelectRuleButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PerformanceCollectionRuleTextBox
        /// </summary>
        TextBox PerformanceCollectionRuleTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PerformanceCollectionRuleStaticControl
        /// </summary>
        StaticControl PerformanceCollectionRuleStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectClassButton
        /// </summary>
        Button SelectClassButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TargetedClassTextBox
        /// </summary>
        TextBox TargetedClassTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TargetedClassStaticControl
        /// </summary>
        StaticControl TargetedClassStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceLevelObjectiveNameTextBox
        /// </summary>
        TextBox ServiceLevelObjectiveNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ServiceLevelObjectiveNameStaticControl
        /// </summary>
        StaticControl ServiceLevelObjectiveNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholdsStaticControl
        /// </summary>
        StaticControl EnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholdsStaticControl
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
    /// 	[dialac] 9/25/2008 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ServiceLevelObjectiveCollectionRuleDialog : Dialog, IServiceLevelObjectiveCollectionRuleDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to GoalTextBox of type TextBox
        /// </summary>
        private TextBox cachedGoalTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ServiceLevelObjectiveGoalComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedServiceLevelObjectiveGoalComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ServiceLevelObjectiveGoalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedServiceLevelObjectiveGoalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MaxRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedMaxRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to MinRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedMinRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to AverageRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAverageRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to AggregationMethodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAggregationMethodStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectRuleButton of type Button
        /// </summary>
        private Button cachedSelectRuleButton;
        
        /// <summary>
        /// Cache to hold a reference to PerformanceCollectionRuleTextBox of type TextBox
        /// </summary>
        private TextBox cachedPerformanceCollectionRuleTextBox;
        
        /// <summary>
        /// Cache to hold a reference to PerformanceCollectionRuleStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPerformanceCollectionRuleStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectClassButton of type Button
        /// </summary>
        private Button cachedSelectClassButton;
        
        /// <summary>
        /// Cache to hold a reference to TargetedClassTextBox of type TextBox
        /// </summary>
        private TextBox cachedTargetedClassTextBox;
        
        /// <summary>
        /// Cache to hold a reference to TargetedClassStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTargetedClassStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ServiceLevelObjectiveNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedServiceLevelObjectiveNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ServiceLevelObjectiveNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedServiceLevelObjectiveNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholdsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedEnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholdsStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ServiceLevelObjectiveCollectionRuleDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ServiceLevelObjectiveCollectionRuleDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroup
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual AggregationMethodRadioGroup RadioGroup
        {
            get
            {
                if ((this.Controls.MaxRadioButton.ButtonState == ButtonState.Checked))
                {
                    return AggregationMethodRadioGroup.Max;
                }
                
                if ((this.Controls.MinRadioButton.ButtonState == ButtonState.Checked))
                {
                    return AggregationMethodRadioGroup.Min;
                }
                
                if ((this.Controls.AverageRadioButton.ButtonState == ButtonState.Checked))
                {
                    return AggregationMethodRadioGroup.Average;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == AggregationMethodRadioGroup.Max))
                {
                    this.Controls.MaxRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == AggregationMethodRadioGroup.Min))
                    {
                        this.Controls.MinRadioButton.ButtonState = ButtonState.Checked;
                    }
                    else
                    {
                        if ((value == AggregationMethodRadioGroup.Average))
                        {
                            this.Controls.AverageRadioButton.ButtonState = ButtonState.Checked;
                        }
                    }
                }
            }
        }
        #endregion
        
        #region IServiceLevelObjectiveCollectionRuleDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IServiceLevelObjectiveCollectionRuleDialogControls Controls
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
        ///  Routine to set/get the text in control GoalTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string GoalTextBoxText
        {
            get
            {
                return this.Controls.GoalTextBox.Text;
            }
            
            set
            {
                // Bug#219061: System.ComponentModel.Win32Exception: Unknown error (0xf006) is found when setting this textbox,
                // change to use SetControlValue method
                UIUtilities.SetControlValue(this.Controls.GoalTextBox, value);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ServiceLevelObjectiveGoal
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ServiceLevelObjectiveGoalText
        {
            get
            {
                return this.Controls.ServiceLevelObjectiveGoalComboBox.Text;
            }
            
            set
            {
                //this.Controls.ServiceLevelObjectiveGoalComboBox.SelectByText(value, true);
                this.Controls.ServiceLevelObjectiveGoalComboBox.Text = value; 
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control PerformanceCollectionRule
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PerformanceCollectionRuleText
        {
            get
            {
                return this.Controls.PerformanceCollectionRuleTextBox.Text;
            }
            
            set
            {
                this.Controls.PerformanceCollectionRuleTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TargetedClass
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TargetedClassText
        {
            get
            {
                return this.Controls.TargetedClassTextBox.Text;
            }
            
            set
            {
                this.Controls.TargetedClassTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ServiceLevelObjectiveName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ServiceLevelObjectiveNameText
        {
            get
            {
                return this.Controls.ServiceLevelObjectiveNameTextBox.Text;
            }
            
            set
            {
                this.Controls.ServiceLevelObjectiveNameTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelObjectiveCollectionRuleDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelObjectiveCollectionRuleDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GoalTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IServiceLevelObjectiveCollectionRuleDialogControls.GoalTextBox
        {
            get
            {
                if ((this.cachedGoalTextBox == null))
                {
                    this.cachedGoalTextBox = new TextBox(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.GoalTextBox);
                }
                
                return this.cachedGoalTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceLevelObjectiveGoalComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IServiceLevelObjectiveCollectionRuleDialogControls.ServiceLevelObjectiveGoalComboBox
        {
            get
            {
                if ((this.cachedServiceLevelObjectiveGoalComboBox == null))
                {
                    this.cachedServiceLevelObjectiveGoalComboBox = new EditComboBox(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.ServiceLevelObjectiveGoalComboBox);
                }
                
                return this.cachedServiceLevelObjectiveGoalComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceLevelObjectiveGoalStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelObjectiveCollectionRuleDialogControls.ServiceLevelObjectiveGoalStaticControl
        {
            get
            {
                if ((this.cachedServiceLevelObjectiveGoalStaticControl == null))
                {
                    this.cachedServiceLevelObjectiveGoalStaticControl = new StaticControl(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.ServiceLevelObjectiveGoalStaticControl);
                }
                
                return this.cachedServiceLevelObjectiveGoalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MaxRadioButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IServiceLevelObjectiveCollectionRuleDialogControls.MaxRadioButton
        {
            get
            {
                if ((this.cachedMaxRadioButton == null))
                {
                    this.cachedMaxRadioButton = new RadioButton(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.MaxRadioButton);
                }
                
                return this.cachedMaxRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MinRadioButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IServiceLevelObjectiveCollectionRuleDialogControls.MinRadioButton
        {
            get
            {
                if ((this.cachedMinRadioButton == null))
                {
                    this.cachedMinRadioButton = new RadioButton(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.MinRadioButton);
                }
                
                return this.cachedMinRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AverageRadioButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IServiceLevelObjectiveCollectionRuleDialogControls.AverageRadioButton
        {
            get
            {
                if ((this.cachedAverageRadioButton == null))
                {
                    this.cachedAverageRadioButton = new RadioButton(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.AverageRadioButton);
                }
                
                return this.cachedAverageRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AggregationMethodStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelObjectiveCollectionRuleDialogControls.AggregationMethodStaticControl
        {
            get
            {
                if ((this.cachedAggregationMethodStaticControl == null))
                {
                    this.cachedAggregationMethodStaticControl = new StaticControl(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.AggregationMethodStaticControl);
                }
                
                return this.cachedAggregationMethodStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectRuleButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelObjectiveCollectionRuleDialogControls.SelectRuleButton
        {
            get
            {
                if ((this.cachedSelectRuleButton == null))
                {
                    this.cachedSelectRuleButton = new Button(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.SelectRuleButton);
                }
                
                return this.cachedSelectRuleButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PerformanceCollectionRuleTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IServiceLevelObjectiveCollectionRuleDialogControls.PerformanceCollectionRuleTextBox
        {
            get
            {
                if ((this.cachedPerformanceCollectionRuleTextBox == null))
                {
                    this.cachedPerformanceCollectionRuleTextBox = new TextBox(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.PerformanceCollectionRuleTextBox);
                }
                
                return this.cachedPerformanceCollectionRuleTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PerformanceCollectionRuleStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelObjectiveCollectionRuleDialogControls.PerformanceCollectionRuleStaticControl
        {
            get
            {
                if ((this.cachedPerformanceCollectionRuleStaticControl == null))
                {
                    this.cachedPerformanceCollectionRuleStaticControl = new StaticControl(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.PerformanceCollectionRuleStaticControl);
                }
                
                return this.cachedPerformanceCollectionRuleStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectClassButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IServiceLevelObjectiveCollectionRuleDialogControls.SelectClassButton
        {
            get
            {
                if ((this.cachedSelectClassButton == null))
                {
                    this.cachedSelectClassButton = new Button(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.SelectClassButton);
                }
                
                return this.cachedSelectClassButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TargetedClassTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IServiceLevelObjectiveCollectionRuleDialogControls.TargetedClassTextBox
        {
            get
            {
                if ((this.cachedTargetedClassTextBox == null))
                {
                    this.cachedTargetedClassTextBox = new TextBox(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.TargetedClassTextBox);
                }
                
                return this.cachedTargetedClassTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TargetedClassStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelObjectiveCollectionRuleDialogControls.TargetedClassStaticControl
        {
            get
            {
                if ((this.cachedTargetedClassStaticControl == null))
                {
                    this.cachedTargetedClassStaticControl = new StaticControl(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.TargetedClassStaticControl);
                }
                
                return this.cachedTargetedClassStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceLevelObjectiveNameTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IServiceLevelObjectiveCollectionRuleDialogControls.ServiceLevelObjectiveNameTextBox
        {
            get
            {
                if ((this.cachedServiceLevelObjectiveNameTextBox == null))
                {
                    this.cachedServiceLevelObjectiveNameTextBox = new TextBox(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.ServiceLevelObjectiveNameTextBox);
                }
                
                return this.cachedServiceLevelObjectiveNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServiceLevelObjectiveNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelObjectiveCollectionRuleDialogControls.ServiceLevelObjectiveNameStaticControl
        {
            get
            {
                if ((this.cachedServiceLevelObjectiveNameStaticControl == null))
                {
                    this.cachedServiceLevelObjectiveNameStaticControl = new StaticControl(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.ServiceLevelObjectiveNameStaticControl);
                }
                
                return this.cachedServiceLevelObjectiveNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholdsStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IServiceLevelObjectiveCollectionRuleDialogControls.EnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholdsStaticControl
        {
            get
            {
                if ((this.cachedEnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholdsStaticControl == null))
                {
                    this.cachedEnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholdsStaticControl = new StaticControl(this, ServiceLevelObjectiveCollectionRuleDialog.ControlIDs.EnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholdsStaticControl);
                }
                
                return this.cachedEnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholdsStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Select Rule
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelectRule()
        {
            this.Controls.SelectRuleButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Select Class
        /// </summary>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelectClass()
        {
            this.Controls.SelectClassButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <history>
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow) 
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure

                    // rethrow the original exception
                    throw windowNotFound;
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
        /// 	[dialac] 9/25/2008 Created
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
            private const string ResourceDialogTitle = @";Service Level Objective (Collection Rule);ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.PerformanceSloDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";&OK;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.DiagramTem" +
                "plateProperties;okButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";&Cancel;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.Diagra" +
                "mTemplateProperties;cancelButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceLevelObjectiveGoal
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceLevelObjectiveGoal = ";Service level objective &goal:;ManagedString;Microsoft.EnterpriseManagement.UI.A" +
                "uthoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.Perf" +
                "ormanceSloDialog;label1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Max
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMax = ";&Max;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Pages.Sla.PerformanceSloDialog;maxOption" +
                ".Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Min
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMin = ";M&in;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Pages.Sla.PerformanceSloDialog;minOption" +
                ".Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Average
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAverage = ";&Average;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.PerformanceSloDialog;avera" +
                "geOption.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AggregationMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAggregationMethod = ";Aggregation method:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dl" +
                "l;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.PerformanceSloD" +
                "ialog;aggregationLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Select (Rule button)
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectRule = ";Se&lect...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.RecoveryGeneralPage;browseBu" +
                "tton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PerformanceCollectionRule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePerformanceCollectionRule = ";Performance collection rule:;ManagedString;Microsoft.EnterpriseManagement.UI.Aut" +
                "horing.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.Perfor" +
                "manceSloDialog;ruleLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Select (Target Class button)
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectClass = ";&Select...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorGeneralPage;browseBut" +
                "ton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TargetedClass
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTargetedClass = ";&Targeted class;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mi" +
                "crosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.MonitorSloDialog;ta" +
                "rgetLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ServiceLevelObjectiveName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServiceLevelObjectiveName = ";S&ervice level objective name:;ManagedString;Microsoft.EnterpriseManagement.UI.A" +
                "uthoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.Perf" +
                "ormanceSloDialog;sloNameLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholds = @";Enter a name for the SLO,  select the required collection rule and set the desired thresholds;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Sla.PerformanceSloDialog;nameSectionTitle.Text";
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
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceLevelObjectiveGoal
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceLevelObjectiveGoal;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Max
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMax;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Min
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMin;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Average
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAverage;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AggregationMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAggregationMethod;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Select
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectRule;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PerformanceCollectionRule
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPerformanceCollectionRule;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Select Target Class button
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectClass;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TargetedClass
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTargetedClass;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ServiceLevelObjectiveName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServiceLevelObjectiveName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholds;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    
                    return cachedOK;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
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
            /// Exposes access to the ServiceLevelObjectiveGoal translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceLevelObjectiveGoal
            {
                get
                {
                    if ((cachedServiceLevelObjectiveGoal == null))
                    {
                        cachedServiceLevelObjectiveGoal = CoreManager.MomConsole.GetIntlStr(ResourceServiceLevelObjectiveGoal);
                    }
                    
                    return cachedServiceLevelObjectiveGoal;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Max translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Max
            {
                get
                {
                    if ((cachedMax == null))
                    {
                        cachedMax = CoreManager.MomConsole.GetIntlStr(ResourceMax);
                    }
                    
                    return cachedMax;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Min translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Min
            {
                get
                {
                    if ((cachedMin == null))
                    {
                        cachedMin = CoreManager.MomConsole.GetIntlStr(ResourceMin);
                    }
                    
                    return cachedMin;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Average translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Average
            {
                get
                {
                    if ((cachedAverage == null))
                    {
                        cachedAverage = CoreManager.MomConsole.GetIntlStr(ResourceAverage);
                    }
                    
                    return cachedAverage;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AggregationMethod translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AggregationMethod
            {
                get
                {
                    if ((cachedAggregationMethod == null))
                    {
                        cachedAggregationMethod = CoreManager.MomConsole.GetIntlStr(ResourceAggregationMethod);
                    }
                    
                    return cachedAggregationMethod;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Select translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectRule
            {
                get
                {
                    if ((cachedSelectRule == null))
                    {
                        cachedSelectRule = CoreManager.MomConsole.GetIntlStr(ResourceSelectRule);
                    }

                    return cachedSelectRule;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PerformanceCollectionRule translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PerformanceCollectionRule
            {
                get
                {
                    if ((cachedPerformanceCollectionRule == null))
                    {
                        cachedPerformanceCollectionRule = CoreManager.MomConsole.GetIntlStr(ResourcePerformanceCollectionRule);
                    }
                    
                    return cachedPerformanceCollectionRule;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Select Class button translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectClass
            {
                get
                {
                    if ((cachedSelectClass == null))
                    {
                        cachedSelectClass = CoreManager.MomConsole.GetIntlStr(ResourceSelectClass);
                    }
                    
                    return cachedSelectClass;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TargetedClass translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TargetedClass
            {
                get
                {
                    if ((cachedTargetedClass == null))
                    {
                        cachedTargetedClass = CoreManager.MomConsole.GetIntlStr(ResourceTargetedClass);
                    }
                    
                    return cachedTargetedClass;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ServiceLevelObjectiveName translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServiceLevelObjectiveName
            {
                get
                {
                    if ((cachedServiceLevelObjectiveName == null))
                    {
                        cachedServiceLevelObjectiveName = CoreManager.MomConsole.GetIntlStr(ResourceServiceLevelObjectiveName);
                    }
                    
                    return cachedServiceLevelObjectiveName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholds translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 9/25/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholds
            {
                get
                {
                    if ((cachedEnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholds == null))
                    {
                        cachedEnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholds = CoreManager.MomConsole.GetIntlStr(ResourceEnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholds);
                    }
                    
                    return cachedEnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholds;
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
        /// 	[dialac] 9/25/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for GoalTextBox
            /// </summary>
            public const string GoalTextBox = "goalTextBox";
            
            /// <summary>
            /// Control ID for ServiceLevelObjectiveGoalComboBox
            /// </summary>
            public const string ServiceLevelObjectiveGoalComboBox = "goalDropDown";
            
            /// <summary>
            /// Control ID for ServiceLevelObjectiveGoalStaticControl
            /// </summary>
            public const string ServiceLevelObjectiveGoalStaticControl = "label1";
            
            /// <summary>
            /// Control ID for MaxRadioButton
            /// </summary>
            public const string MaxRadioButton = "maxOption";
            
            /// <summary>
            /// Control ID for MinRadioButton
            /// </summary>
            public const string MinRadioButton = "minOption";
            
            /// <summary>
            /// Control ID for AverageRadioButton
            /// </summary>
            public const string AverageRadioButton = "averageOption";
            
            /// <summary>
            /// Control ID for AggregationMethodStaticControl
            /// </summary>
            public const string AggregationMethodStaticControl = "aggregationLabel";
            
            /// <summary>
            /// Control ID for SelectRuleButton
            /// </summary>
            public const string SelectRuleButton = "chooseRuleButton";
            
            /// <summary>
            /// Control ID for PerformanceCollectionRuleTextBox
            /// </summary>
            public const string PerformanceCollectionRuleTextBox = "ruleBox";
            
            /// <summary>
            /// Control ID for PerformanceCollectionRuleStaticControl
            /// </summary>
            public const string PerformanceCollectionRuleStaticControl = "ruleLabel";
            
            /// <summary>
            /// Control ID for SelectClassButton
            /// </summary>
            public const string SelectClassButton = "browseButton";
            
            /// <summary>
            /// Control ID for TargetedClassTextBox
            /// </summary>
            public const string TargetedClassTextBox = "targetBox";
            
            /// <summary>
            /// Control ID for TargetedClassStaticControl
            /// </summary>
            public const string TargetedClassStaticControl = "targetLabel";
            
            /// <summary>
            /// Control ID for ServiceLevelObjectiveNameTextBox
            /// </summary>
            public const string ServiceLevelObjectiveNameTextBox = "sloName";
            
            /// <summary>
            /// Control ID for ServiceLevelObjectiveNameStaticControl
            /// </summary>
            public const string ServiceLevelObjectiveNameStaticControl = "sloNameLabel";
            
            /// <summary>
            /// Control ID for EnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholdsStaticControl
            /// </summary>
            public const string EnterANameForTheSLOSelectTheRequiredCollectionRuleAndSetTheDesiredThresholdsStaticControl = "nameSectionTitle";
        }
        #endregion
    }
}
