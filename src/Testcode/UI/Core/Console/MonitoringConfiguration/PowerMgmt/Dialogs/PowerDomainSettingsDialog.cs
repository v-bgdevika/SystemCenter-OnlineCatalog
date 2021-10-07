// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="PowerDomainSettingsDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[dialac] 1/22/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.PowerMgmt.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - RadioPowerBudget

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group RadioPowerBudget
    /// </summary>
    /// <history>
    /// 	[dialac] 1/22/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioPowerBudget
    {
        /// <summary>
        /// KW = 0
        /// </summary>
        KW = 0,
        
        /// <summary>
        /// PercentOfTotalPowerCapacity = 1
        /// </summary>
        PercentOfTotalPowerCapacity = 1,
    }
    #endregion
    
    #region Interface Definition - IPowerDomainSettingsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IPowerDomainSettingsDialogControls, for PowerDomainSettingsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 1/22/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IPowerDomainSettingsDialogControls
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
        /// Read-only property to access PowerDomainSettingsStaticControl
        /// </summary>
        StaticControl PowerDomainSettingsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DevicesStaticControl
        /// </summary>
        StaticControl DevicesStaticControl
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
        /// Read-only property to access AbsoluteBudgetComboBox
        /// </summary>
        EditComboBox AbsoluteBudgetComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PercentBudgetComboBox
        /// </summary>
        EditComboBox PercentBudgetComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access KWRadioButton
        /// </summary>
        RadioButton KWRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PercentOfTotalPowerCapacityRadioButton
        /// </summary>
        RadioButton PercentOfTotalPowerCapacityRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso
        /// </summary>
        StaticControl SpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PowerBudgetStaticControl
        /// </summary>
        StaticControl PowerBudgetStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access KWStaticControl
        /// </summary>
        StaticControl KWStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PowerDomainNameTextBox
        /// </summary>
        TextBox PowerDomainNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MaximumCapacityComboBox
        /// </summary>
        EditComboBox MaximumCapacityComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PowerDomainNameStaticControl
        /// </summary>
        StaticControl PowerDomainNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access MaximumCapacityStaticControl
        /// </summary>
        StaticControl MaximumCapacityStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyTheMaximumPowerCapacityForThePowerDomainStaticControl
        /// </summary>
        StaticControl SpecifyTheMaximumPowerCapacityForThePowerDomainStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PowerCapacityStaticControl
        /// </summary>
        StaticControl PowerCapacityStaticControl
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
        /// Read-only property to access PowerDomainSettingsHeaderLabelStaticControl
        /// </summary>
        StaticControl PowerDomainSettingsHeaderLabelStaticControl
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
    /// 	[dialac] 1/22/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class PowerDomainSettingsDialog : Dialog, IPowerDomainSettingsDialogControls
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
        /// Cache to hold a reference to PowerDomainSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPowerDomainSettingsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DevicesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDevicesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AbsoluteBudgetComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedAbsoluteBudgetComboBox;
        
        /// <summary>
        /// Cache to hold a reference to PercentBudgetComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedPercentBudgetComboBox;
        
        /// <summary>
        /// Cache to hold a reference to KWRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedKWRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to PercentOfTotalPowerCapacityRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedPercentOfTotalPowerCapacityRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso;
        
        /// <summary>
        /// Cache to hold a reference to PowerBudgetStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPowerBudgetStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to KWStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedKWStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PowerDomainNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedPowerDomainNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to MaximumCapacityComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedMaximumCapacityComboBox;
        
        /// <summary>
        /// Cache to hold a reference to PowerDomainNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPowerDomainNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to MaximumCapacityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedMaximumCapacityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheMaximumPowerCapacityForThePowerDomainStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheMaximumPowerCapacityForThePowerDomainStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PowerCapacityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPowerCapacityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PowerDomainSettingsHeaderLabelStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPowerDomainSettingsHeaderLabelStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of PowerDomainSettingsDialog of type CoreManager.MomConsole
        /// </param>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public PowerDomainSettingsDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioPowerBudget
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioPowerBudget RadioPowerBudget
        {
            get
            {
                if ((this.Controls.KWRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioPowerBudget.KW;
                }
                
                if ((this.Controls.PercentOfTotalPowerCapacityRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioPowerBudget.PercentOfTotalPowerCapacity;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioPowerBudget.KW))
                {
                    this.Controls.KWRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioPowerBudget.PercentOfTotalPowerCapacity))
                    {
                        this.Controls.PercentOfTotalPowerCapacityRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IPowerDomainSettingsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IPowerDomainSettingsDialogControls Controls
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
        ///  Routine to set/get the text in control AbsoluteBudgetComboBox
        /// </summary>
        /// <value>Value used to set the textbox text property</value>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// 	[lucyra] 2/8/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AbsoluteBudgetText
        {
            get
            {
                return this.Controls.AbsoluteBudgetComboBox.Text;
            }
            
            set
            {
                this.Controls.AbsoluteBudgetComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control PercentBudgetText
        /// </summary>
        /// <value>Value used to set the textbox text property</value>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PercentBudgetText
        {
            get
            {
                return this.Controls.PercentBudgetComboBox.Text;
            }
            
            set
            {
                this.Controls.PercentBudgetComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control PowerDomainName
        /// </summary>
        /// <value>Value used to set the textbox text property</value>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PowerDomainNameText
        {
            get
            {
                return this.Controls.PowerDomainNameTextBox.Text;
            }
            
            set
            {
                this.Controls.PowerDomainNameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control MaximumCapacity
        /// </summary>
        /// <value>Value used to set the textbox text property</value>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MaximumCapacityText
        {
            get
            {
                return this.Controls.MaximumCapacityComboBox.Text;
            }
            
            set
            {
                this.Controls.MaximumCapacityComboBox.Text = value; 
            }

        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPowerDomainSettingsDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, PowerDomainSettingsDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPowerDomainSettingsDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, PowerDomainSettingsDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPowerDomainSettingsDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, PowerDomainSettingsDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IPowerDomainSettingsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, PowerDomainSettingsDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MonitoringTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPowerDomainSettingsDialogControls.MonitoringTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitoringTypeStaticControl == null))
                {
                    this.cachedMonitoringTypeStaticControl = new StaticControl(this, PowerDomainSettingsDialog.ControlIDs.MonitoringTypeStaticControl);
                }
                
                return this.cachedMonitoringTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPowerDomainSettingsDialogControls.GeneralPropertiesStaticControl
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
        ///  Exposes access to the PowerDomainSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPowerDomainSettingsDialogControls.PowerDomainSettingsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedPowerDomainSettingsStaticControl == null))
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
                    this.cachedPowerDomainSettingsStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedPowerDomainSettingsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DevicesStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPowerDomainSettingsDialogControls.DevicesStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDevicesStaticControl == null))
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
                    this.cachedDevicesStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedDevicesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPowerDomainSettingsDialogControls.SummaryStaticControl
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
                    for (i = 0; (i <= 3); i = (i + 1))
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
        ///  Exposes access to the AbsoluteBudgetComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IPowerDomainSettingsDialogControls.AbsoluteBudgetComboBox
        {
            get
            {
                if ((this.cachedAbsoluteBudgetComboBox == null))
                {
                    this.cachedAbsoluteBudgetComboBox = new EditComboBox(this, PowerDomainSettingsDialog.ControlIDs.AbsoluteBudgetComboBox);
                }
                
                return this.cachedAbsoluteBudgetComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PercentBudgetComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IPowerDomainSettingsDialogControls.PercentBudgetComboBox
        {
            get
            {
                if ((this.cachedPercentBudgetComboBox == null))
                {
                    this.cachedPercentBudgetComboBox = new EditComboBox(this, PowerDomainSettingsDialog.ControlIDs.PercentBudgetComboBox);
                }
                
                return this.cachedPercentBudgetComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the KWRadioButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IPowerDomainSettingsDialogControls.KWRadioButton
        {
            get
            {
                if ((this.cachedKWRadioButton == null))
                {
                    this.cachedKWRadioButton = new RadioButton(this, PowerDomainSettingsDialog.ControlIDs.KWRadioButton);
                }
                
                return this.cachedKWRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PercentOfTotalPowerCapacityRadioButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IPowerDomainSettingsDialogControls.PercentOfTotalPowerCapacityRadioButton
        {
            get
            {
                if ((this.cachedPercentOfTotalPowerCapacityRadioButton == null))
                {
                    this.cachedPercentOfTotalPowerCapacityRadioButton = new RadioButton(this, PowerDomainSettingsDialog.ControlIDs.PercentOfTotalPowerCapacityRadioButton);
                }
                
                return this.cachedPercentOfTotalPowerCapacityRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPowerDomainSettingsDialogControls.SpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso
        {
            get
            {
                if ((this.cachedSpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso == null))
                {
                    this.cachedSpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso = new StaticControl(this, PowerDomainSettingsDialog.ControlIDs.SpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso);
                }
                
                return this.cachedSpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PowerBudgetStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPowerDomainSettingsDialogControls.PowerBudgetStaticControl
        {
            get
            {
                if ((this.cachedPowerBudgetStaticControl == null))
                {
                    this.cachedPowerBudgetStaticControl = new StaticControl(this, PowerDomainSettingsDialog.ControlIDs.PowerBudgetStaticControl);
                }
                
                return this.cachedPowerBudgetStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the KWStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPowerDomainSettingsDialogControls.KWStaticControl
        {
            get
            {
                if ((this.cachedKWStaticControl == null))
                {
                    this.cachedKWStaticControl = new StaticControl(this, PowerDomainSettingsDialog.ControlIDs.KWStaticControl);
                }
                
                return this.cachedKWStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PowerDomainNameTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IPowerDomainSettingsDialogControls.PowerDomainNameTextBox
        {
            get
            {
                if ((this.cachedPowerDomainNameTextBox == null))
                {
                    this.cachedPowerDomainNameTextBox = new TextBox(this, PowerDomainSettingsDialog.ControlIDs.PowerDomainNameTextBox);
                }
                
                return this.cachedPowerDomainNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MaximumCapacityComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IPowerDomainSettingsDialogControls.MaximumCapacityComboBox
        {
            get
            {
                if ((this.cachedMaximumCapacityComboBox == null))
                {
                    this.cachedMaximumCapacityComboBox = new EditComboBox(this, PowerDomainSettingsDialog.ControlIDs.MaximumCapacityComboBox);
                }
                
                return this.cachedMaximumCapacityComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PowerDomainNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPowerDomainSettingsDialogControls.PowerDomainNameStaticControl
        {
            get
            {
                if ((this.cachedPowerDomainNameStaticControl == null))
                {
                    this.cachedPowerDomainNameStaticControl = new StaticControl(this, PowerDomainSettingsDialog.ControlIDs.PowerDomainNameStaticControl);
                }
                
                return this.cachedPowerDomainNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the MaximumCapacityStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPowerDomainSettingsDialogControls.MaximumCapacityStaticControl
        {
            get
            {
                if ((this.cachedMaximumCapacityStaticControl == null))
                {
                    this.cachedMaximumCapacityStaticControl = new StaticControl(this, PowerDomainSettingsDialog.ControlIDs.MaximumCapacityStaticControl);
                }
                
                return this.cachedMaximumCapacityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheMaximumPowerCapacityForThePowerDomainStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPowerDomainSettingsDialogControls.SpecifyTheMaximumPowerCapacityForThePowerDomainStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheMaximumPowerCapacityForThePowerDomainStaticControl == null))
                {
                    this.cachedSpecifyTheMaximumPowerCapacityForThePowerDomainStaticControl = new StaticControl(this, PowerDomainSettingsDialog.ControlIDs.SpecifyTheMaximumPowerCapacityForThePowerDomainStaticControl);
                }
                
                return this.cachedSpecifyTheMaximumPowerCapacityForThePowerDomainStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PowerCapacityStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPowerDomainSettingsDialogControls.PowerCapacityStaticControl
        {
            get
            {
                if ((this.cachedPowerCapacityStaticControl == null))
                {
                    this.cachedPowerCapacityStaticControl = new StaticControl(this, PowerDomainSettingsDialog.ControlIDs.PowerCapacityStaticControl);
                }
                
                return this.cachedPowerCapacityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPowerDomainSettingsDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, PowerDomainSettingsDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PowerDomainSettingsHeaderLabelStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IPowerDomainSettingsDialogControls.PowerDomainSettingsHeaderLabelStaticControl
        {
            get
            {
                if ((this.cachedPowerDomainSettingsHeaderLabelStaticControl == null))
                {
                    this.cachedPowerDomainSettingsHeaderLabelStaticControl = new StaticControl(this, PowerDomainSettingsDialog.ControlIDs.PowerDomainSettingsHeaderLabelStaticControl);
                }

                return this.cachedPowerDomainSettingsHeaderLabelStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
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
        /// 	[dialac] 1/22/2009 Created
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
        /// 	[dialac] 1/22/2009 Created
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
        /// 	[dialac] 1/22/2009 Created
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
        /// <param name="app">CoreManager.MomConsole owning the dialog.</param>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
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
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);

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
        /// 	[dialac] 1/22/2009 Created
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
                ";Add Monitoring Wizard;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Common.PageCommonResources;" +
                "TemplateWizard";
            
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
            private const string ResourceGeneralProperties = ";General Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Administratio" +
                "n.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPInstall.Ru" +
                "leGeneralPage;$this.Title";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PowerDomainSettings
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourcePowerDomainSettings = "Power Domain Settings";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Devices
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDevices = "Devices";
            
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
            /// Contains resource string for:  KW
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceKW = ";k&W;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ente" +
                "rpriseManagement.Internal.UI.Authoring.Pages.PowerDomainSettingsPage;rbPercentBu" +
                "dget.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PercentOfTotalPowerCapacity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePercentOfTotalPowerCapacity = ";&percent of total power capacity;ManagedString;Microsoft.EnterpriseManagement.UI" +
                ".Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PowerD" +
                "omainSettingsPage;rbAbsoluteBudget.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso = @";Specify the power budget for the power domain. This value can either be a percentage of the total power capacity or an absolute value.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PowerDomainSettingsPage;lblPowerBudgetDesc.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PowerBudget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePowerBudget = ";Power budget;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.Pages.PowerDomainSettingsPage;lb" +
                "lPowerBudgetSection.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  KW2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceKW2 = ";kW;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Enter" +
                "priseManagement.Internal.UI.Authoring.Pages.PowerDomainSettingsPage;lblKW.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PowerDomainName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePowerDomainName = ";Power domain name:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll" +
                ";Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PowerDomainSettingsP" +
                "age;lblPowerDomainName.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  MaximumCapacity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceMaximumCapacity = ";Maximum capacity:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PowerDomainSettingsPa" +
                "ge;lblMaximumCapacity.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheMaximumPowerCapacityForThePowerDomain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheMaximumPowerCapacityForThePowerDomain = ";Specify the maximum power capacity for the power domain.;ManagedString;Microsoft" +
                ".EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.U" +
                "I.Authoring.Pages.PowerDomainSettingsPage;lblPowerCapacityDesc.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PowerCapacity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePowerCapacity = ";Power capacity;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PowerDomainSettingsPage;" +
                "lblPowerCapacitySection.Text";
            
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
            /// Contains resource string for:  PowerDomainSettings2
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourcePowerDomainSettings2 = "Power Domain Settings";
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
            /// Caches the translated resource string for:  PowerDomainSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPowerDomainSettings;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Devices
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDevices;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  KW
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedKW;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PercentOfTotalPowerCapacity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPercentOfTotalPowerCapacity;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PowerBudget
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPowerBudget;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  KW2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedKW2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PowerDomainName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPowerDomainName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  MaximumCapacity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMaximumCapacity;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyTheMaximumPowerCapacityForThePowerDomain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheMaximumPowerCapacityForThePowerDomain;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PowerCapacity
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPowerCapacity;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PowerDomainSettings2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPowerDomainSettings2;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
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
            /// 	[dialac] 1/22/2009 Created
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
            /// 	[dialac] 1/22/2009 Created
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
            /// 	[dialac] 1/22/2009 Created
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
            /// 	[dialac] 1/22/2009 Created
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
            /// 	[dialac] 1/22/2009 Created
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
            /// 	[dialac] 1/22/2009 Created
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
            /// Exposes access to the PowerDomainSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PowerDomainSettings
            {
                get
                {
                    if ((cachedPowerDomainSettings == null))
                    {
                        cachedPowerDomainSettings = CoreManager.MomConsole.GetIntlStr(ResourcePowerDomainSettings);
                    }
                    
                    return cachedPowerDomainSettings;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Devices translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Devices
            {
                get
                {
                    if ((cachedDevices == null))
                    {
                        cachedDevices = CoreManager.MomConsole.GetIntlStr(ResourceDevices);
                    }
                    
                    return cachedDevices;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
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
            /// Exposes access to the KW translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string KW
            {
                get
                {
                    if ((cachedKW == null))
                    {
                        cachedKW = CoreManager.MomConsole.GetIntlStr(ResourceKW);
                    }
                    
                    return cachedKW;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PercentOfTotalPowerCapacity translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PercentOfTotalPowerCapacity
            {
                get
                {
                    if ((cachedPercentOfTotalPowerCapacity == null))
                    {
                        cachedPercentOfTotalPowerCapacity = CoreManager.MomConsole.GetIntlStr(ResourcePercentOfTotalPowerCapacity);
                    }
                    
                    return cachedPercentOfTotalPowerCapacity;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso
            {
                get
                {
                    if ((cachedSpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso == null))
                    {
                        cachedSpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso);
                    }
                    
                    return cachedSpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PowerBudget translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PowerBudget
            {
                get
                {
                    if ((cachedPowerBudget == null))
                    {
                        cachedPowerBudget = CoreManager.MomConsole.GetIntlStr(ResourcePowerBudget);
                    }
                    
                    return cachedPowerBudget;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the KW2 translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string KW2
            {
                get
                {
                    if ((cachedKW2 == null))
                    {
                        cachedKW2 = CoreManager.MomConsole.GetIntlStr(ResourceKW2);
                    }
                    
                    return cachedKW2;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PowerDomainName translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PowerDomainName
            {
                get
                {
                    if ((cachedPowerDomainName == null))
                    {
                        cachedPowerDomainName = CoreManager.MomConsole.GetIntlStr(ResourcePowerDomainName);
                    }
                    
                    return cachedPowerDomainName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MaximumCapacity translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaximumCapacity
            {
                get
                {
                    if ((cachedMaximumCapacity == null))
                    {
                        cachedMaximumCapacity = CoreManager.MomConsole.GetIntlStr(ResourceMaximumCapacity);
                    }
                    
                    return cachedMaximumCapacity;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyTheMaximumPowerCapacityForThePowerDomain translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheMaximumPowerCapacityForThePowerDomain
            {
                get
                {
                    if ((cachedSpecifyTheMaximumPowerCapacityForThePowerDomain == null))
                    {
                        cachedSpecifyTheMaximumPowerCapacityForThePowerDomain = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheMaximumPowerCapacityForThePowerDomain);
                    }
                    
                    return cachedSpecifyTheMaximumPowerCapacityForThePowerDomain;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PowerCapacity translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PowerCapacity
            {
                get
                {
                    if ((cachedPowerCapacity == null))
                    {
                        cachedPowerCapacity = CoreManager.MomConsole.GetIntlStr(ResourcePowerCapacity);
                    }
                    
                    return cachedPowerCapacity;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
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
            /// Exposes access to the PowerDomainSettings2 translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PowerDomainSettings2
            {
                get
                {
                    if ((cachedPowerDomainSettings2 == null))
                    {
                        cachedPowerDomainSettings2 = CoreManager.MomConsole.GetIntlStr(ResourcePowerDomainSettings2);
                    }
                    
                    return cachedPowerDomainSettings2;
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
        /// 	[dialac] 1/22/2009 Created
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
            /// Control ID for PowerDomainSettingsStaticControl
            /// </summary>
            public const string PowerDomainSettingsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DevicesStaticControl
            /// </summary>
            public const string DevicesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for AbsoluteBudgetComboBox
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string AbsoluteBudgetComboBox = "nupAbsoluteBudget";
            
            /// <summary>
            /// Control ID for PercentBudgetComboBox
            /// </summary>
            public const string PercentBudgetComboBox = "nudPercentBudget";
            
            /// <summary>
            /// Control ID for KWRadioButton
            /// </summary>
            public const string KWRadioButton = "rbAbsoluteBudget";
            
            /// <summary>
            /// Control ID for PercentOfTotalPowerCapacityRadioButton
            /// </summary>
            public const string PercentOfTotalPowerCapacityRadioButton = "rbPercentBudget";
            
            /// <summary>
            /// Control ID for SpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso
            /// </summary>
            public const string SpecifyThePowerBudgetForThePowerDomainThisValueCanEitherBeAPercentageOfTheTotalPowerCapacityOrAnAbso = "lblPowerBudgetDesc";
            
            /// <summary>
            /// Control ID for PowerBudgetStaticControl
            /// </summary>
            public const string PowerBudgetStaticControl = "lblPowerBudgetSection";
            
            /// <summary>
            /// Control ID for KWStaticControl
            /// </summary>
            public const string KWStaticControl = "lblKW";
            
            /// <summary>
            /// Control ID for PowerDomainNameTextBox
            /// </summary>
            public const string PowerDomainNameTextBox = "tbPowerDomainName";
            
            /// <summary>
            /// Control ID for MaximumCapacityComboBox
            /// </summary>
            public const string MaximumCapacityComboBox = "nudMaximumCapacity";
            
            /// <summary>
            /// Control ID for PowerDomainNameStaticControl
            /// </summary>
            public const string PowerDomainNameStaticControl = "lblPowerDomainName";
            
            /// <summary>
            /// Control ID for MaximumCapacityStaticControl
            /// </summary>
            public const string MaximumCapacityStaticControl = "lblMaximumCapacity";
            
            /// <summary>
            /// Control ID for SpecifyTheMaximumPowerCapacityForThePowerDomainStaticControl
            /// </summary>
            public const string SpecifyTheMaximumPowerCapacityForThePowerDomainStaticControl = "lblPowerCapacityDesc";
            
            /// <summary>
            /// Control ID for PowerCapacityStaticControl
            /// </summary>
            public const string PowerCapacityStaticControl = "lblPowerCapacitySection";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for PowerDomainSettingsHeaderLabelStaticControl
            /// </summary>
            public const string PowerDomainSettingsHeaderLabelStaticControl = "headerLabel";
        }
        #endregion
    }
}
