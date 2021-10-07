// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="HealthRollupPolicyProperties.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	MOMv3 Project
// </project>
// <summary>
// 	MOMv3 Project
// </summary>
// <history>
// 	[ruhim] 5/31/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dependency.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;

    #region Radio Group Enumeration - Tab2

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group Tab2
    /// </summary>
    /// <history>
    /// 	[ruhim] 5/31/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum Tab2
    {
        /// <summary>
        /// BestStateOfAnyMember = 0
        /// </summary>
        BestStateOfAnyMember = 0,
        
        /// <summary>
        /// WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthState = 1
        /// </summary>
        WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthState = 1,
        
        /// <summary>
        /// WorstStateOfAnyMember = 2
        /// </summary>
        WorstStateOfAnyMember = 2,
    }
    #endregion
    
    #region Interface Definition - IHealthRollupPolicyPropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IHealthRollupPolicyPropertiesControls, for HealthRollupPolicyProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 5/31/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IHealthRollupPolicyPropertiesControls
    {
        /// <summary>
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
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
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Tab2TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab2TabControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MaintenanceModeStaticControl
        /// </summary>
        StaticControl MaintenanceModeStaticControl
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
        /// Read-only property to access MonitoringUnavailableStaticControl
        /// </summary>
        StaticControl MonitoringUnavailableStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitoringUnavailableComboBox
        /// </summary>
        ComboBox MonitoringUnavailableComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitoringUnavailableAndMaintenanceModeStaticControl
        /// </summary>
        StaticControl MonitoringUnavailableAndMaintenanceModeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExampleRollupComboBox
        /// </summary>
        ComboBox ExampleRollupComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BestStateOfAnyMemberRadioButton
        /// </summary>
        RadioButton BestStateOfAnyMemberRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthStateRadioButton
        /// </summary>
        RadioButton WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthStateRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WorstStateOfAnyMemberRadioButton
        /// </summary>
        RadioButton WorstStateOfAnyMemberRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HealthRollupPolicyStaticControl
        /// </summary>
        StaticControl HealthRollupPolicyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TheHealthStateIsDeterminedByStaticControl
        /// </summary>
        StaticControl TheHealthStateIsDeterminedByStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HealthyStaticControl
        /// </summary>
        StaticControl HealthyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WarningStaticControl
        /// </summary>
        StaticControl WarningStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UnhealthyStaticControl
        /// </summary>
        StaticControl UnhealthyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MembersStaticControl
        /// </summary>
        StaticControl MembersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Computer4StaticControl
        /// </summary>
        StaticControl Computer4StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Computer3StaticControl
        /// </summary>
        StaticControl Computer3StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Computer2StaticControl
        /// </summary>
        StaticControl Computer2StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Computer1StaticControl
        /// </summary>
        StaticControl Computer1StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access GroupStateStaticControl
        /// </summary>
        StaticControl GroupStateStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExampleRollupStaticControl
        /// </summary>
        StaticControl ExampleRollupStaticControl
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
    /// 	[ruhim] 5/31/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class HealthRollupPolicyProperties : Dialog, IHealthRollupPolicyPropertiesControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to Tab2TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab2TabControl;
        
        /// <summary>
        /// Cache to hold a reference to MaintenanceModeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMaintenanceModeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ComboBox0 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox0;
        
        /// <summary>
        /// Cache to hold a reference to MonitoringUnavailableStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitoringUnavailableStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MonitoringUnavailableComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedMonitoringUnavailableComboBox;
        
        /// <summary>
        /// Cache to hold a reference to MonitoringUnavailableAndMaintenanceModeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitoringUnavailableAndMaintenanceModeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExampleRollupComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedExampleRollupComboBox;
        
        /// <summary>
        /// Cache to hold a reference to BestStateOfAnyMemberRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedBestStateOfAnyMemberRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthStateRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedWorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthStateRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to WorstStateOfAnyMemberRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedWorstStateOfAnyMemberRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to HealthRollupPolicyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHealthRollupPolicyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TheHealthStateIsDeterminedByStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTheHealthStateIsDeterminedByStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HealthyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHealthyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to WarningStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWarningStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UnhealthyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedUnhealthyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MembersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMembersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Computer4StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedComputer4StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Computer3StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedComputer3StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Computer2StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedComputer2StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Computer1StaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedComputer1StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GroupStateStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGroupStateStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ExampleRollupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExampleRollupStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of HealthRollupPolicyProperties of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public HealthRollupPolicyProperties(ConsoleApp app)
            :
                base(app, Init(app))
        {
            this.Extended.SetFocus();
            UISynchronization.WaitForUIObjectReady(this, Constants.DefaultDialogTimeout);
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group Tab2
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual Tab2 Tab2
        {
            get
            {
                if ((this.Controls.BestStateOfAnyMemberRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Tab2.BestStateOfAnyMember;
                }
                
                if ((this.Controls.WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthStateRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Tab2.WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthState;
                }
                
                if ((this.Controls.WorstStateOfAnyMemberRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Tab2.WorstStateOfAnyMember;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == Tab2.BestStateOfAnyMember))
                {
                    this.Controls.BestStateOfAnyMemberRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == Tab2.WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthState))
                    {
                        this.Controls.WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthStateRadioButton.ButtonState = ButtonState.Checked;
                    }
                    else
                    {
                        if ((value == Tab2.WorstStateOfAnyMember))
                        {
                            this.Controls.WorstStateOfAnyMemberRadioButton.ButtonState = ButtonState.Checked;
                        }
                    }
                }
            }
        }
        #endregion
        
        #region IHealthRollupPolicyProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IHealthRollupPolicyPropertiesControls Controls
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
        ///  Routine to set/get the text in control ComboBox0
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
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
        ///  Routine to set/get the text in control MonitoringUnavailable
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MonitoringUnavailableText
        {
            get
            {
                return this.Controls.MonitoringUnavailableComboBox.Text;
            }
            
            set
            {
                this.Controls.MonitoringUnavailableComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ExampleRollup
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ExampleRollupText
        {
            get
            {
                return this.Controls.ExampleRollupComboBox.Text;
            }
            
            set
            {
                this.Controls.ExampleRollupComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IHealthRollupPolicyPropertiesControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, HealthRollupPolicyProperties.ControlIDs.ApplyButton);
                }
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IHealthRollupPolicyPropertiesControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, HealthRollupPolicyProperties.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IHealthRollupPolicyPropertiesControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, HealthRollupPolicyProperties.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab2TabControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IHealthRollupPolicyPropertiesControls.Tab2TabControl
        {
            get
            {
                if ((this.cachedTab2TabControl == null))
                {
                    this.cachedTab2TabControl = new TabControl(this, HealthRollupPolicyProperties.ControlIDs.Tab2TabControl);
                }
                return this.cachedTab2TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MaintenanceModeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyPropertiesControls.MaintenanceModeStaticControl
        {
            get
            {
                if ((this.cachedMaintenanceModeStaticControl == null))
                {
                    this.cachedMaintenanceModeStaticControl = new StaticControl(this, HealthRollupPolicyProperties.ControlIDs.MaintenanceModeStaticControl);
                }
                return this.cachedMaintenanceModeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox0 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IHealthRollupPolicyPropertiesControls.ComboBox0
        {
            get
            {
                if ((this.cachedComboBox0 == null))
                {
                    this.cachedComboBox0 = new ComboBox(this, HealthRollupPolicyProperties.ControlIDs.ComboBox0);
                }
                return this.cachedComboBox0;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringUnavailableStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyPropertiesControls.MonitoringUnavailableStaticControl
        {
            get
            {
                if ((this.cachedMonitoringUnavailableStaticControl == null))
                {
                    this.cachedMonitoringUnavailableStaticControl = new StaticControl(this, HealthRollupPolicyProperties.ControlIDs.MonitoringUnavailableStaticControl);
                }
                return this.cachedMonitoringUnavailableStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringUnavailableComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IHealthRollupPolicyPropertiesControls.MonitoringUnavailableComboBox
        {
            get
            {
                if ((this.cachedMonitoringUnavailableComboBox == null))
                {
                    this.cachedMonitoringUnavailableComboBox = new ComboBox(this, HealthRollupPolicyProperties.ControlIDs.MonitoringUnavailableComboBox);
                }
                return this.cachedMonitoringUnavailableComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringUnavailableAndMaintenanceModeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyPropertiesControls.MonitoringUnavailableAndMaintenanceModeStaticControl
        {
            get
            {
                if ((this.cachedMonitoringUnavailableAndMaintenanceModeStaticControl == null))
                {
                    this.cachedMonitoringUnavailableAndMaintenanceModeStaticControl = new StaticControl(this, HealthRollupPolicyProperties.ControlIDs.MonitoringUnavailableAndMaintenanceModeStaticControl);
                }
                return this.cachedMonitoringUnavailableAndMaintenanceModeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExampleRollupComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IHealthRollupPolicyPropertiesControls.ExampleRollupComboBox
        {
            get
            {
                if ((this.cachedExampleRollupComboBox == null))
                {
                    this.cachedExampleRollupComboBox = new ComboBox(this, HealthRollupPolicyProperties.ControlIDs.ExampleRollupComboBox);
                }
                return this.cachedExampleRollupComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BestStateOfAnyMemberRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IHealthRollupPolicyPropertiesControls.BestStateOfAnyMemberRadioButton
        {
            get
            {
                if ((this.cachedBestStateOfAnyMemberRadioButton == null))
                {
                    this.cachedBestStateOfAnyMemberRadioButton = new RadioButton(this, HealthRollupPolicyProperties.ControlIDs.BestStateOfAnyMemberRadioButton);
                }
                return this.cachedBestStateOfAnyMemberRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthStateRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IHealthRollupPolicyPropertiesControls.WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthStateRadioButton
        {
            get
            {
                if ((this.cachedWorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthStateRadioButton == null))
                {
                    this.cachedWorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthStateRadioButton = new RadioButton(this, HealthRollupPolicyProperties.ControlIDs.WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthStateRadioButton);
                }
                return this.cachedWorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthStateRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WorstStateOfAnyMemberRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IHealthRollupPolicyPropertiesControls.WorstStateOfAnyMemberRadioButton
        {
            get
            {
                if ((this.cachedWorstStateOfAnyMemberRadioButton == null))
                {
                    this.cachedWorstStateOfAnyMemberRadioButton = new RadioButton(this, HealthRollupPolicyProperties.ControlIDs.WorstStateOfAnyMemberRadioButton);
                }
                return this.cachedWorstStateOfAnyMemberRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HealthRollupPolicyStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyPropertiesControls.HealthRollupPolicyStaticControl
        {
            get
            {
                if ((this.cachedHealthRollupPolicyStaticControl == null))
                {
                    this.cachedHealthRollupPolicyStaticControl = new StaticControl(this, HealthRollupPolicyProperties.ControlIDs.HealthRollupPolicyStaticControl);
                }
                return this.cachedHealthRollupPolicyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TheHealthStateIsDeterminedByStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyPropertiesControls.TheHealthStateIsDeterminedByStaticControl
        {
            get
            {
                if ((this.cachedTheHealthStateIsDeterminedByStaticControl == null))
                {
                    this.cachedTheHealthStateIsDeterminedByStaticControl = new StaticControl(this, HealthRollupPolicyProperties.ControlIDs.TheHealthStateIsDeterminedByStaticControl);
                }
                return this.cachedTheHealthStateIsDeterminedByStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HealthyStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyPropertiesControls.HealthyStaticControl
        {
            get
            {
                if ((this.cachedHealthyStaticControl == null))
                {
                    this.cachedHealthyStaticControl = new StaticControl(this, HealthRollupPolicyProperties.ControlIDs.HealthyStaticControl);
                }
                return this.cachedHealthyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WarningStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyPropertiesControls.WarningStaticControl
        {
            get
            {
                if ((this.cachedWarningStaticControl == null))
                {
                    this.cachedWarningStaticControl = new StaticControl(this, HealthRollupPolicyProperties.ControlIDs.WarningStaticControl);
                }
                return this.cachedWarningStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UnhealthyStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyPropertiesControls.UnhealthyStaticControl
        {
            get
            {
                if ((this.cachedUnhealthyStaticControl == null))
                {
                    this.cachedUnhealthyStaticControl = new StaticControl(this, HealthRollupPolicyProperties.ControlIDs.UnhealthyStaticControl);
                }
                return this.cachedUnhealthyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MembersStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyPropertiesControls.MembersStaticControl
        {
            get
            {
                if ((this.cachedMembersStaticControl == null))
                {
                    this.cachedMembersStaticControl = new StaticControl(this, HealthRollupPolicyProperties.ControlIDs.MembersStaticControl);
                }
                return this.cachedMembersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Computer4StaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyPropertiesControls.Computer4StaticControl
        {
            get
            {
                if ((this.cachedComputer4StaticControl == null))
                {
                    this.cachedComputer4StaticControl = new StaticControl(this, HealthRollupPolicyProperties.ControlIDs.Computer4StaticControl);
                }
                return this.cachedComputer4StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Computer3StaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyPropertiesControls.Computer3StaticControl
        {
            get
            {
                if ((this.cachedComputer3StaticControl == null))
                {
                    this.cachedComputer3StaticControl = new StaticControl(this, HealthRollupPolicyProperties.ControlIDs.Computer3StaticControl);
                }
                return this.cachedComputer3StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Computer2StaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyPropertiesControls.Computer2StaticControl
        {
            get
            {
                if ((this.cachedComputer2StaticControl == null))
                {
                    this.cachedComputer2StaticControl = new StaticControl(this, HealthRollupPolicyProperties.ControlIDs.Computer2StaticControl);
                }
                return this.cachedComputer2StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Computer1StaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyPropertiesControls.Computer1StaticControl
        {
            get
            {
                if ((this.cachedComputer1StaticControl == null))
                {
                    this.cachedComputer1StaticControl = new StaticControl(this, HealthRollupPolicyProperties.ControlIDs.Computer1StaticControl);
                }
                return this.cachedComputer1StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GroupStateStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyPropertiesControls.GroupStateStaticControl
        {
            get
            {
                if ((this.cachedGroupStateStaticControl == null))
                {
                    this.cachedGroupStateStaticControl = new StaticControl(this, HealthRollupPolicyProperties.ControlIDs.GroupStateStaticControl);
                }
                return this.cachedGroupStateStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExampleRollupStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyPropertiesControls.ExampleRollupStaticControl
        {
            get
            {
                if ((this.cachedExampleRollupStaticControl == null))
                {
                    this.cachedExampleRollupStaticControl = new StaticControl(this, HealthRollupPolicyProperties.ControlIDs.ExampleRollupStaticControl);
                }
                return this.cachedExampleRollupStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(ConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                                Strings.DialogTitle + "*", StringMatchSyntax.WildCard);

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
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" + Strings.DialogTitle + "'");

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
        /// 	[ruhim] 5/31/2007 Created
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
            private const string ResourceDialogTitle =
                ";Properties;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.AuthoringDialog;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.PropertyDialogForm;buttonApply.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab2
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab2 = "Tab2";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MaintenanceMode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMaintenanceMode = ";Maintenance &mode:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DependencyRollupPage" +
                ";label3.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitoringUnavailable
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitoringUnavailable = ";Monitoring &unavailable:;ManagedString;Microsoft.EnterpriseManagement.UI.Authori" +
                "ng.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DependencyRoll" +
                "upPage;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitoringUnavailableAndMaintenanceMode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitoringUnavailableAndMaintenanceMode = ";Monitoring Unavailable and Maintenance Mode;ManagedString;Microsoft.EnterpriseMa" +
                "nagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.P" +
                "ages.DependencyRollupPage;pageSectionLabel2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BestStateOfAnyMember
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBestStateOfAnyMember = ";Best state of any member;ManagedString;Microsoft.EnterpriseManagement.UI.Authori" +
                "ng.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AggregateRollu" +
                "pPage;bestofRbtn.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthState = ";Worst state of the specified percentage of members in good health state:;Managed" +
                "String;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManag" +
                "ement.Internal.UI.Authoring.Pages.DependencyRollupPage;percentageRBtn.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WorstStateOfAnyMember
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWorstStateOfAnyMember = ";Worst state of any member;ManagedString;Microsoft.EnterpriseManagement.UI.Author" +
                "ing.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AggregateRoll" +
                "upPage;worstofRbtn.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HealthRollupPolicy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHealthRollupPolicy = ";Health Rollup Policy;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.d" +
                "ll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AggregateRollupPag" +
                "e;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TheHealthStateIsDeterminedBy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTheHealthStateIsDeterminedBy = ";The &health state is determined by:;ManagedString;Microsoft.EnterpriseManagement" +
                ".UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Agg" +
                "regateRollupPage;selectrollupLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Healthy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHealthy = ";= Healthy;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.HealthStateRollupImage;lblHea" +
                "lthy.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Warning
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWarning = ";= Warning;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.HealthStateRollupImage;lblWar" +
                "ning.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Unhealthy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUnhealthy = ";= Unhealthy;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.Pages.HealthStateRollupImage;lblU" +
                "nhealthy.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Members
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMembers = ";Members;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Pages.HealthStateRollupImage;lblMembe" +
                "rs.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Computer4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComputer4 = ";Computer 4;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.HealthStateRollupImage;lblCo" +
                "mputer4.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Computer3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComputer3 = ";Computer 3;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.HealthStateRollupImage;lblCo" +
                "mputer3.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Computer2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComputer2 = ";Computer 2;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.HealthStateRollupImage;lblCo" +
                "mputer2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Computer1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComputer1 = ";Computer 1;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.HealthStateRollupImage;lblCo" +
                "mputer1.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GroupState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGroupState = ";Group State =;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micr" +
                "osoft.EnterpriseManagement.Internal.UI.Authoring.Pages.HealthStateRollupImage;lb" +
                "lGroupState.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExampleRollup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExampleRollup = ";Example rollup:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mi" +
                "crosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.AggregateRollupPage;exa" +
                "mpleLabel.Text";
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
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MaintenanceMode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMaintenanceMode;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MonitoringUnavailable
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitoringUnavailable;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MonitoringUnavailableAndMaintenanceMode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitoringUnavailableAndMaintenanceMode;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BestStateOfAnyMember
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBestStateOfAnyMember;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthState;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WorstStateOfAnyMember
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWorstStateOfAnyMember;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HealthRollupPolicy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHealthRollupPolicy;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TheHealthStateIsDeterminedBy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTheHealthStateIsDeterminedBy;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Healthy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHealthy;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Warning
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWarning;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Unhealthy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUnhealthy;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Members
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMembers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Computer4
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComputer4;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Computer3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComputer3;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Computer2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComputer2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Computer1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComputer1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  GroupState
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGroupState;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExampleRollup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExampleRollup;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
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
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Apply
            {
                get
                {
                    if ((cachedApply == null))
                    {
                        cachedApply = CoreManager.MomConsole.GetIntlStr(ResourceApply);
                    }
                    return cachedApply;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
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
            /// Exposes access to the Tab2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab2
            {
                get
                {
                    if ((cachedTab2 == null))
                    {
                        cachedTab2 = CoreManager.MomConsole.GetIntlStr(ResourceTab2);
                    }
                    return cachedTab2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MaintenanceMode translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceMode
            {
                get
                {
                    if ((cachedMaintenanceMode == null))
                    {
                        cachedMaintenanceMode = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceMode);
                    }
                    return cachedMaintenanceMode;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MonitoringUnavailable translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitoringUnavailable
            {
                get
                {
                    if ((cachedMonitoringUnavailable == null))
                    {
                        cachedMonitoringUnavailable = CoreManager.MomConsole.GetIntlStr(ResourceMonitoringUnavailable);
                    }
                    return cachedMonitoringUnavailable;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MonitoringUnavailableAndMaintenanceMode translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitoringUnavailableAndMaintenanceMode
            {
                get
                {
                    if ((cachedMonitoringUnavailableAndMaintenanceMode == null))
                    {
                        cachedMonitoringUnavailableAndMaintenanceMode = CoreManager.MomConsole.GetIntlStr(ResourceMonitoringUnavailableAndMaintenanceMode);
                    }
                    return cachedMonitoringUnavailableAndMaintenanceMode;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BestStateOfAnyMember translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string BestStateOfAnyMember
            {
                get
                {
                    if ((cachedBestStateOfAnyMember == null))
                    {
                        cachedBestStateOfAnyMember = CoreManager.MomConsole.GetIntlStr(ResourceBestStateOfAnyMember);
                    }
                    return cachedBestStateOfAnyMember;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthState translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthState
            {
                get
                {
                    if ((cachedWorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthState == null))
                    {
                        cachedWorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthState = CoreManager.MomConsole.GetIntlStr(ResourceWorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthState);
                    }
                    return cachedWorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthState;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WorstStateOfAnyMember translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WorstStateOfAnyMember
            {
                get
                {
                    if ((cachedWorstStateOfAnyMember == null))
                    {
                        cachedWorstStateOfAnyMember = CoreManager.MomConsole.GetIntlStr(ResourceWorstStateOfAnyMember);
                    }
                    return cachedWorstStateOfAnyMember;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HealthRollupPolicy translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HealthRollupPolicy
            {
                get
                {
                    if ((cachedHealthRollupPolicy == null))
                    {
                        cachedHealthRollupPolicy = CoreManager.MomConsole.GetIntlStr(ResourceHealthRollupPolicy);
                    }
                    return cachedHealthRollupPolicy;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TheHealthStateIsDeterminedBy translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TheHealthStateIsDeterminedBy
            {
                get
                {
                    if ((cachedTheHealthStateIsDeterminedBy == null))
                    {
                        cachedTheHealthStateIsDeterminedBy = CoreManager.MomConsole.GetIntlStr(ResourceTheHealthStateIsDeterminedBy);
                    }
                    return cachedTheHealthStateIsDeterminedBy;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Healthy translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Healthy
            {
                get
                {
                    if ((cachedHealthy == null))
                    {
                        cachedHealthy = CoreManager.MomConsole.GetIntlStr(ResourceHealthy);
                    }
                    return cachedHealthy;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Warning translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Warning
            {
                get
                {
                    if ((cachedWarning == null))
                    {
                        cachedWarning = CoreManager.MomConsole.GetIntlStr(ResourceWarning);
                    }
                    return cachedWarning;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Unhealthy translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Unhealthy
            {
                get
                {
                    if ((cachedUnhealthy == null))
                    {
                        cachedUnhealthy = CoreManager.MomConsole.GetIntlStr(ResourceUnhealthy);
                    }
                    return cachedUnhealthy;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Members translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Members
            {
                get
                {
                    if ((cachedMembers == null))
                    {
                        cachedMembers = CoreManager.MomConsole.GetIntlStr(ResourceMembers);
                    }
                    return cachedMembers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Computer4 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Computer4
            {
                get
                {
                    if ((cachedComputer4 == null))
                    {
                        cachedComputer4 = CoreManager.MomConsole.GetIntlStr(ResourceComputer4);
                    }
                    return cachedComputer4;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Computer3 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Computer3
            {
                get
                {
                    if ((cachedComputer3 == null))
                    {
                        cachedComputer3 = CoreManager.MomConsole.GetIntlStr(ResourceComputer3);
                    }
                    return cachedComputer3;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Computer2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Computer2
            {
                get
                {
                    if ((cachedComputer2 == null))
                    {
                        cachedComputer2 = CoreManager.MomConsole.GetIntlStr(ResourceComputer2);
                    }
                    return cachedComputer2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Computer1 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Computer1
            {
                get
                {
                    if ((cachedComputer1 == null))
                    {
                        cachedComputer1 = CoreManager.MomConsole.GetIntlStr(ResourceComputer1);
                    }
                    return cachedComputer1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the GroupState translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GroupState
            {
                get
                {
                    if ((cachedGroupState == null))
                    {
                        cachedGroupState = CoreManager.MomConsole.GetIntlStr(ResourceGroupState);
                    }
                    return cachedGroupState;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExampleRollup translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 5/31/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExampleRollup
            {
                get
                {
                    if ((cachedExampleRollup == null))
                    {
                        cachedExampleRollup = CoreManager.MomConsole.GetIntlStr(ResourceExampleRollup);
                    }
                    return cachedExampleRollup;
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
        /// 	[ruhim] 5/31/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for Tab2TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab2TabControl = "tabPages";
            
            /// <summary>
            /// Control ID for MaintenanceModeStaticControl
            /// </summary>
            public const string MaintenanceModeStaticControl = "label3";
            
            /// <summary>
            /// Control ID for ComboBox0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ComboBox0 = "maintenanceModeCombobox";
            
            /// <summary>
            /// Control ID for MonitoringUnavailableStaticControl
            /// </summary>
            public const string MonitoringUnavailableStaticControl = "label2";
            
            /// <summary>
            /// Control ID for MonitoringUnavailableComboBox
            /// </summary>
            public const string MonitoringUnavailableComboBox = "unavailableComboBox";
            
            /// <summary>
            /// Control ID for MonitoringUnavailableAndMaintenanceModeStaticControl
            /// </summary>
            public const string MonitoringUnavailableAndMaintenanceModeStaticControl = "pageSectionLabel2";
            
            /// <summary>
            /// Control ID for ExampleRollupComboBox
            /// </summary>
            public const string ExampleRollupComboBox = "numericUpDown";
            
            /// <summary>
            /// Control ID for BestStateOfAnyMemberRadioButton
            /// </summary>
            public const string BestStateOfAnyMemberRadioButton = "bestofRbtn";
            
            /// <summary>
            /// Control ID for WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthStateRadioButton
            /// </summary>
            public const string WorstStateOfTheSpecifiedPercentageOfMembersInGoodHealthStateRadioButton = "percentageRBtn";
            
            /// <summary>
            /// Control ID for WorstStateOfAnyMemberRadioButton
            /// </summary>
            public const string WorstStateOfAnyMemberRadioButton = "worstofRbtn";
            
            /// <summary>
            /// Control ID for HealthRollupPolicyStaticControl
            /// </summary>
            public const string HealthRollupPolicyStaticControl = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for TheHealthStateIsDeterminedByStaticControl
            /// </summary>
            public const string TheHealthStateIsDeterminedByStaticControl = "selectrollupLabel";
            
            /// <summary>
            /// Control ID for HealthyStaticControl
            /// </summary>
            public const string HealthyStaticControl = "lblHealthy";
            
            /// <summary>
            /// Control ID for WarningStaticControl
            /// </summary>
            public const string WarningStaticControl = "lblWarning";
            
            /// <summary>
            /// Control ID for UnhealthyStaticControl
            /// </summary>
            public const string UnhealthyStaticControl = "lblUnhealthy";
            
            /// <summary>
            /// Control ID for MembersStaticControl
            /// </summary>
            public const string MembersStaticControl = "lblMembers";
            
            /// <summary>
            /// Control ID for Computer4StaticControl
            /// </summary>
            public const string Computer4StaticControl = "lblComputer4";
            
            /// <summary>
            /// Control ID for Computer3StaticControl
            /// </summary>
            public const string Computer3StaticControl = "lblComputer3";
            
            /// <summary>
            /// Control ID for Computer2StaticControl
            /// </summary>
            public const string Computer2StaticControl = "lblComputer2";
            
            /// <summary>
            /// Control ID for Computer1StaticControl
            /// </summary>
            public const string Computer1StaticControl = "lblComputer1";
            
            /// <summary>
            /// Control ID for GroupStateStaticControl
            /// </summary>
            public const string GroupStateStaticControl = "lblGroupState";
            
            /// <summary>
            /// Control ID for ExampleRollupStaticControl
            /// </summary>
            public const string ExampleRollupStaticControl = "exampleLabel";
        }
        #endregion
    }
}
