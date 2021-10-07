// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="HealthRollupPolicyDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3 Project
// </project>
// <summary>
// 	MOMv3 Project
// </summary>
// <history>
// 	[ruhim] 4/7/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Dependency.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Mom.Test.UI.Core.Common;
    
    #region Radio Group Enumeration - RadioGroup0

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioGroup0
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/7/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroup0
    {
        /// <summary>
        /// BestStateOfAnyMember = 0
        /// </summary>
        BestStateOfAnyMember = 0,
        
        /// <summary>
        /// WorstStateOfSpecifiedPercentage = 1
        /// </summary>
        WorstStateOfSpecifiedPercentage = 1,
        
        /// <summary>
        /// WorstStateOfAnyMember = 2
        /// </summary>
        WorstStateOfAnyMember = 2,
    }
    #endregion
    
    #region Interface Definition - IHealthRollupPolicyDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IHealthRollupPolicyDialogControls, for HealthRollupPolicyDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/7/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IHealthRollupPolicyDialogControls
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
        /// Read-only property to access GeneralPropertiesStaticControl
        /// </summary>
        StaticControl GeneralPropertiesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MonitorDependencyStaticControl
        /// </summary>
        StaticControl MonitorDependencyStaticControl
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
        /// Read-only property to access MaintenanceModeStaticControl
        /// </summary>
        StaticControl MaintenanceModeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MaintenanceModeCombobox
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox MaintenanceModeCombobox
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
        /// Read-only property to access MonitoringUnavailableAndMaintenceModeStaticControl
        /// </summary>
        StaticControl MonitoringUnavailableAndMaintenceModeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PercentageComboBox
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        ComboBox PercentageComboBox
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
        /// Read-only property to access WorstStateOfSpecifiedPercentageRadioButton
        /// </summary>
        RadioButton WorstStateOfSpecifiedPercentageRadioButton
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
        /// Read-only property to access HealthRollupPolicyStaticControl2
        /// </summary>
        StaticControl HealthRollupPolicyStaticControl2
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
        
        /// <summary>
        /// Read-only property to access SelectARollupMechanismStaticControl
        /// </summary>
        StaticControl SelectARollupMechanismStaticControl
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
        /// Read-only property to access ConfigureHealthRollupPolicyStaticControl
        /// </summary>
        StaticControl ConfigureHealthRollupPolicyStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the "Health Rollup Policy Dialog" of the 
    /// Create a new dependency rollup monitor wizard
    /// </summary>
    /// <history>
    /// 	[ruhim] 4/7/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class HealthRollupPolicyDialog : Dialog, IHealthRollupPolicyDialogControls
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
        /// Cache to hold a reference to GeneralPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MonitorDependencyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitorDependencyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HealthRollupPolicyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHealthRollupPolicyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureAlertsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureAlertsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to KnowledgeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedKnowledgeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MaintenanceModeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMaintenanceModeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MaintenanceModeCombobox of type ComboBox
        /// </summary>
        private ComboBox cachedMaintenanceModeCombobox;
        
        /// <summary>
        /// Cache to hold a reference to MonitoringUnavailableStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitoringUnavailableStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MonitoringUnavailableComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedMonitoringUnavailableComboBox;
        
        /// <summary>
        /// Cache to hold a reference to MonitoringUnavailableAndMaintenceModeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMonitoringUnavailableAndMaintenceModeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PercentageComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedPercentageComboBox;
        
        /// <summary>
        /// Cache to hold a reference to BestStateOfAnyMemberRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedBestStateOfAnyMemberRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to WorstStateOfSpecifiedPercentageRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedWorstStateOfSpecifiedPercentageRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to WorstStateOfAnyMemberRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedWorstStateOfAnyMemberRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to HealthRollupPolicyStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedHealthRollupPolicyStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to ExampleRollupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedExampleRollupStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectARollupMechanismStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectARollupMechanismStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureHealthRollupPolicyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureHealthRollupPolicyStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of HealthRollupPolicyDialog of type App
        /// </param>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public HealthRollupPolicyDialog(ConsoleApp app)
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
        /// Functionality for radio group RadioGroup0
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroup0 RadioGroup0
        {
            get
            {
                if ((this.Controls.BestStateOfAnyMemberRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.BestStateOfAnyMember;
                }
                
                if ((this.Controls.WorstStateOfSpecifiedPercentageRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.WorstStateOfSpecifiedPercentage;
                }
                
                if ((this.Controls.WorstStateOfAnyMemberRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.WorstStateOfAnyMember;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroup0.BestStateOfAnyMember))
                {
                    this.Controls.BestStateOfAnyMemberRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup0.WorstStateOfSpecifiedPercentage))
                    {
                        this.Controls.WorstStateOfSpecifiedPercentageRadioButton.ButtonState = ButtonState.Checked;
                    }
                    else
                    {
                        if ((value == RadioGroup0.WorstStateOfAnyMember))
                        {
                            this.Controls.WorstStateOfAnyMemberRadioButton.ButtonState = ButtonState.Checked;
                        }
                    }
                }
            }
        }
        #endregion
        
        #region IHealthRollupPolicyDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IHealthRollupPolicyDialogControls Controls
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
        ///  Routine to set/get the text in control MaintenanceModeCombobox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MaintenanceModeComboboxText
        {
            get
            {
                return this.Controls.MaintenanceModeCombobox.Text;
            }
            
            set
            {
                this.Controls.MaintenanceModeCombobox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MonitoringUnavailable
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
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
        ///  Routine to set/get the text in control PercentageComboBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PercentageComboBoxText
        {
            get
            {
                return this.Controls.PercentageComboBox.Text;
            }
            
            set
            {
                this.Controls.PercentageComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IHealthRollupPolicyDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, HealthRollupPolicyDialog.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IHealthRollupPolicyDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, HealthRollupPolicyDialog.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IHealthRollupPolicyDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, HealthRollupPolicyDialog.ControlIDs.CreateButton);
                }
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IHealthRollupPolicyDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, HealthRollupPolicyDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyDialogControls.GeneralPropertiesStaticControl
        {
            get
            {
                if ((this.cachedGeneralPropertiesStaticControl == null))
                {
                    this.cachedGeneralPropertiesStaticControl = new StaticControl(this, HealthRollupPolicyDialog.ControlIDs.GeneralPropertiesStaticControl);
                }
                return this.cachedGeneralPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitorDependencyStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyDialogControls.MonitorDependencyStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedMonitorDependencyStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
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
                    this.cachedMonitorDependencyStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedMonitorDependencyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HealthRollupPolicyStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyDialogControls.HealthRollupPolicyStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedHealthRollupPolicyStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
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
                    this.cachedHealthRollupPolicyStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedHealthRollupPolicyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureAlertsStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyDialogControls.ConfigureAlertsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedConfigureAlertsStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
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
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyDialogControls.KnowledgeStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedKnowledgeStaticControl == null))
                {
                    Window wndTemp = this.App.MainWindow;
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
                    this.cachedKnowledgeStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedKnowledgeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MaintenanceModeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyDialogControls.MaintenanceModeStaticControl
        {
            get
            {
                if ((this.cachedMaintenanceModeStaticControl == null))
                {
                    this.cachedMaintenanceModeStaticControl = new StaticControl(this, HealthRollupPolicyDialog.ControlIDs.MaintenanceModeStaticControl);
                }
                return this.cachedMaintenanceModeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MaintenanceModeCombobox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IHealthRollupPolicyDialogControls.MaintenanceModeCombobox
        {
            get
            {
                if ((this.cachedMaintenanceModeCombobox == null))
                {
                    this.cachedMaintenanceModeCombobox = new ComboBox(this, HealthRollupPolicyDialog.ControlIDs.MaintenanceModeCombobox);
                }
                return this.cachedMaintenanceModeCombobox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringUnavailableStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyDialogControls.MonitoringUnavailableStaticControl
        {
            get
            {
                if ((this.cachedMonitoringUnavailableStaticControl == null))
                {
                    this.cachedMonitoringUnavailableStaticControl = new StaticControl(this, HealthRollupPolicyDialog.ControlIDs.MonitoringUnavailableStaticControl);
                }
                return this.cachedMonitoringUnavailableStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringUnavailableComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IHealthRollupPolicyDialogControls.MonitoringUnavailableComboBox
        {
            get
            {
                if ((this.cachedMonitoringUnavailableComboBox == null))
                {
                    this.cachedMonitoringUnavailableComboBox = new ComboBox(this, HealthRollupPolicyDialog.ControlIDs.MonitoringUnavailableComboBox);
                }
                return this.cachedMonitoringUnavailableComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringUnavailableAndMaintenceModeStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyDialogControls.MonitoringUnavailableAndMaintenceModeStaticControl
        {
            get
            {
                if ((this.cachedMonitoringUnavailableAndMaintenceModeStaticControl == null))
                {
                    this.cachedMonitoringUnavailableAndMaintenceModeStaticControl = new StaticControl(this, HealthRollupPolicyDialog.ControlIDs.MonitoringUnavailableAndMaintenceModeStaticControl);
                }
                return this.cachedMonitoringUnavailableAndMaintenceModeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PercentageComboBox control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IHealthRollupPolicyDialogControls.PercentageComboBox
        {
            get
            {
                if ((this.cachedPercentageComboBox == null))
                {
                    this.cachedPercentageComboBox = new ComboBox(this, HealthRollupPolicyDialog.ControlIDs.PercentageComboBox);
                }
                return this.cachedPercentageComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BestStateOfAnyMemberRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IHealthRollupPolicyDialogControls.BestStateOfAnyMemberRadioButton
        {
            get
            {
                if ((this.cachedBestStateOfAnyMemberRadioButton == null))
                {
                    this.cachedBestStateOfAnyMemberRadioButton = new RadioButton(this, HealthRollupPolicyDialog.ControlIDs.BestStateOfAnyMemberRadioButton);
                }
                return this.cachedBestStateOfAnyMemberRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WorstStateOfSpecifiedPercentageRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IHealthRollupPolicyDialogControls.WorstStateOfSpecifiedPercentageRadioButton
        {
            get
            {
                if ((this.cachedWorstStateOfSpecifiedPercentageRadioButton == null))
                {
                    this.cachedWorstStateOfSpecifiedPercentageRadioButton = new RadioButton(this, HealthRollupPolicyDialog.ControlIDs.WorstStateOfSpecifiedPercentageRadioButton);
                }
                return this.cachedWorstStateOfSpecifiedPercentageRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WorstStateOfAnyMemberRadioButton control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IHealthRollupPolicyDialogControls.WorstStateOfAnyMemberRadioButton
        {
            get
            {
                if ((this.cachedWorstStateOfAnyMemberRadioButton == null))
                {
                    this.cachedWorstStateOfAnyMemberRadioButton = new RadioButton(this, HealthRollupPolicyDialog.ControlIDs.WorstStateOfAnyMemberRadioButton);
                }
                return this.cachedWorstStateOfAnyMemberRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HealthRollupPolicyStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyDialogControls.HealthRollupPolicyStaticControl2
        {
            get
            {
                if ((this.cachedHealthRollupPolicyStaticControl2 == null))
                {
                    this.cachedHealthRollupPolicyStaticControl2 = new StaticControl(this, HealthRollupPolicyDialog.ControlIDs.HealthRollupPolicyStaticControl2);
                }
                return this.cachedHealthRollupPolicyStaticControl2;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExampleRollupStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyDialogControls.ExampleRollupStaticControl
        {
            get
            {
                if ((this.cachedExampleRollupStaticControl == null))
                {
                    this.cachedExampleRollupStaticControl = new StaticControl(this, HealthRollupPolicyDialog.ControlIDs.ExampleRollupStaticControl);
                }
                return this.cachedExampleRollupStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectARollupMechanismStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyDialogControls.SelectARollupMechanismStaticControl
        {
            get
            {
                if ((this.cachedSelectARollupMechanismStaticControl == null))
                {
                    this.cachedSelectARollupMechanismStaticControl = new StaticControl(this, HealthRollupPolicyDialog.ControlIDs.SelectARollupMechanismStaticControl);
                }
                return this.cachedSelectARollupMechanismStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, HealthRollupPolicyDialog.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureHealthRollupPolicyStaticControl control
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IHealthRollupPolicyDialogControls.ConfigureHealthRollupPolicyStaticControl
        {
            get
            {
                if ((this.cachedConfigureHealthRollupPolicyStaticControl == null))
                {
                    this.cachedConfigureHealthRollupPolicyStaticControl = new StaticControl(this, HealthRollupPolicyDialog.ControlIDs.ConfigureHealthRollupPolicyStaticControl);
                }
                return this.cachedConfigureHealthRollupPolicyStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
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
        /// 	[ruhim] 4/7/2006 Created
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
        /// 	[ruhim] 4/7/2006 Created
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
        /// 	[ruhim] 4/7/2006 Created
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
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[ruhim] 4/7/2006 Created
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
        /// 	[ruhim] 4/7/2006 Created
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
            private const string ResourceDialogTitle =
                ";Create a new dependency monitor;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.MonitorTypes.MonitorTypeResources;CreateDependencyMonitorWizard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.PageFramework.WizardButtonsPanel;previousButton.Text";
            
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
            private const string ResourceCreate = ";Create;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagem" +
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
            /// Contains resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneralProperties = ";General Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.NameAndDescriptionPage;$this.NavigationT" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitorDependency
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitorDependency = ";Monitor Dependency;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.EditDependencyPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HealthRollupPolicy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHealthRollupPolicy = ";Health Rollup Policy;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Pages.AggregateRollupPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureAlerts
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureAlerts = ";Configure Alerts;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Enterpr" +
                "iseManagement.Internal.UI.Authoring.Pages.AlertConfiguration;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Knowledge
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceKnowledge = ";Knowledge;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseMana" +
                "gement.Internal.UI.Authoring.Pages.ProductKnowledgePage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MaintenanceMode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMaintenanceMode = ";Maintenance &mode:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.DependencyRollupPage;label3.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitoringUnavailable
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitoringUnavailable = ";Monitoring &unavailable:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.DependencyRollupPage;label2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MonitoringUnavailableAndMaintenceMode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMonitoringUnavailableAndMaintenceMode = ";Monitoring Unavailable and Maintence Mode;ManagedString;Microsoft.MOM.UI.Compone" +
                "nts.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DependencyRollupP" +
                "age;pageSectionLabel2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  BestStateOfAnyMember
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceBestStateOfAnyMember = ";Best state of any member;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.AggregateRollupPage;bestofRbtn.Tex" +
                "t";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WorstStateOfSpecifiedPercentage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWorstStateOfSpecifiedPercentage = ";Worst state of the specified percentage of members in good health state:;Managed" +
                "String;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Intern" +
                "al.UI.Authoring.Pages.DependencyRollupPage;percentageRBtn.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WorstStateOfAnyMember
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWorstStateOfAnyMember = ";Worst state of any member;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsof" +
                "t.EnterpriseManagement.Internal.UI.Authoring.Pages.AggregateRollupPage;worstofRbtn.T" +
                "ext";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HealthRollupPolicy2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHealthRollupPolicy2 = ";Health Rollup Policy;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Pages.AggregateRollupPage;$this.TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExampleRollup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExampleRollup = ";Example rollup:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Enterpri" +
                "seManagement.Internal.UI.Authoring.Pages.AggregateRollupPage;exampleLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectARollupMechanism
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectARollupMechanism = ";Select a roll&up mechanism:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.Pages.AggregateRollupPage;selectrollu" +
                "pLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mo" +
                "m.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureHealthRollupPolicy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureHealthRollupPolicy = ";Configure Health Rollup Policy;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.DependencyRollupPage;$this.H" +
                "eaderText";
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
            /// Caches the translated resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneralProperties;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MonitorDependency
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorDependency;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HealthRollupPolicy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHealthRollupPolicy;
            
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
            /// Caches the translated resource string for:  MonitoringUnavailableAndMaintenceMode
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitoringUnavailableAndMaintenceMode;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  BestStateOfAnyMember
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBestStateOfAnyMember;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WorstStateOfSpecifiedPercentage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWorstStateOfSpecifiedPercentage;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WorstStateOfAnyMember
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWorstStateOfAnyMember;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HealthRollupPolicy2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHealthRollupPolicy2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExampleRollup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExampleRollup;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectARollupMechanism
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectARollupMechanism;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureHealthRollupPolicy
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureHealthRollupPolicy;
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
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
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
            /// 	[ruhim] 4/7/2006 Created
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
            /// 	[ruhim] 4/7/2006 Created
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
            /// 	[ruhim] 4/7/2006 Created
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
            /// Exposes access to the GeneralProperties translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
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
            /// Exposes access to the MonitorDependency translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorDependency
            {
                get
                {
                    if ((cachedMonitorDependency == null))
                    {
                        cachedMonitorDependency = CoreManager.MomConsole.GetIntlStr(ResourceMonitorDependency);
                    }
                    return cachedMonitorDependency;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HealthRollupPolicy translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
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
            /// Exposes access to the ConfigureAlerts translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
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
            /// 	[ruhim] 4/7/2006 Created
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
            /// Exposes access to the MaintenanceMode translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
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
            /// 	[ruhim] 4/7/2006 Created
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
            /// Exposes access to the MonitoringUnavailableAndMaintenceMode translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitoringUnavailableAndMaintenceMode
            {
                get
                {
                    if ((cachedMonitoringUnavailableAndMaintenceMode == null))
                    {
                        cachedMonitoringUnavailableAndMaintenceMode = CoreManager.MomConsole.GetIntlStr(ResourceMonitoringUnavailableAndMaintenceMode);
                    }
                    return cachedMonitoringUnavailableAndMaintenceMode;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the BestStateOfAnyMember translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
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
            /// Exposes access to the WorstStateOfSpecifiedPercentage translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WorstStateOfSpecifiedPercentage
            {
                get
                {
                    if ((cachedWorstStateOfSpecifiedPercentage == null))
                    {
                        cachedWorstStateOfSpecifiedPercentage = CoreManager.MomConsole.GetIntlStr(ResourceWorstStateOfSpecifiedPercentage);
                    }
                    return cachedWorstStateOfSpecifiedPercentage;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WorstStateOfAnyMember translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
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
            /// Exposes access to the HealthRollupPolicy2 translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HealthRollupPolicy2
            {
                get
                {
                    if ((cachedHealthRollupPolicy2 == null))
                    {
                        cachedHealthRollupPolicy2 = CoreManager.MomConsole.GetIntlStr(ResourceHealthRollupPolicy2);
                    }
                    return cachedHealthRollupPolicy2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExampleRollup translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectARollupMechanism translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectARollupMechanism
            {
                get
                {
                    if ((cachedSelectARollupMechanism == null))
                    {
                        cachedSelectARollupMechanism = CoreManager.MomConsole.GetIntlStr(ResourceSelectARollupMechanism);
                    }
                    return cachedSelectARollupMechanism;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
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
            /// Exposes access to the ConfigureHealthRollupPolicy translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 4/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureHealthRollupPolicy
            {
                get
                {
                    if ((cachedConfigureHealthRollupPolicy == null))
                    {
                        cachedConfigureHealthRollupPolicy = CoreManager.MomConsole.GetIntlStr(ResourceConfigureHealthRollupPolicy);
                    }
                    return cachedConfigureHealthRollupPolicy;
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
        /// 	[ruhim] 4/7/2006 Created
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
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for MonitorDependencyStaticControl
            /// </summary>
            public const string MonitorDependencyStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for HealthRollupPolicyStaticControl
            /// </summary>
            public const string HealthRollupPolicyStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureAlertsStaticControl
            /// </summary>
            public const string ConfigureAlertsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for KnowledgeStaticControl
            /// </summary>
            public const string KnowledgeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for MaintenanceModeStaticControl
            /// </summary>
            public const string MaintenanceModeStaticControl = "label3";
            
            /// <summary>
            /// Control ID for MaintenanceModeCombobox
            /// </summary>            
            public const string MaintenanceModeCombobox = "maintenanceModeCombobox";
            
            /// <summary>
            /// Control ID for MonitoringUnavailableStaticControl
            /// </summary>
            public const string MonitoringUnavailableStaticControl = "label2";
            
            /// <summary>
            /// Control ID for MonitoringUnavailableComboBox
            /// </summary>
            public const string MonitoringUnavailableComboBox = "unavailableComboBox";
            
            /// <summary>
            /// Control ID for MonitoringUnavailableAndMaintenceModeStaticControl
            /// </summary>
            public const string MonitoringUnavailableAndMaintenceModeStaticControl = "pageSectionLabel2";
            
            /// <summary>
            /// Control ID for PercentageComboBox
            /// </summary>            
            public const string PercentageComboBox = "numericUpDown";
            
            /// <summary>
            /// Control ID for BestStateOfAnyMemberRadioButton
            /// </summary>
            public const string BestStateOfAnyMemberRadioButton = "bestofRbtn";
            
            /// <summary>
            /// Control ID for WorstStateOfSpecifiedPercentageRadioButton
            /// </summary>
            public const string WorstStateOfSpecifiedPercentageRadioButton = "percentageRBtn";
            
            /// <summary>
            /// Control ID for WorstStateOfAnyMemberRadioButton
            /// </summary>
            public const string WorstStateOfAnyMemberRadioButton = "worstofRbtn";
            
            /// <summary>
            /// Control ID for HealthRollupPolicyStaticControl2
            /// </summary>
            public const string HealthRollupPolicyStaticControl2 = "pageSectionLabel1";
            
            /// <summary>
            /// Control ID for ExampleRollupStaticControl
            /// </summary>
            public const string ExampleRollupStaticControl = "exampleLabel";
            
            /// <summary>
            /// Control ID for SelectARollupMechanismStaticControl
            /// </summary>
            public const string SelectARollupMechanismStaticControl = "selectrollupLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureHealthRollupPolicyStaticControl
            /// </summary>
            public const string ConfigureHealthRollupPolicyStaticControl = "headerLabel";
        }
        #endregion
    }
}
