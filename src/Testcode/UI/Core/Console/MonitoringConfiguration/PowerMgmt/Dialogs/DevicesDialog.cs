// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DevicesDialog.cs">
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
    
    #region Interface Definition - IDevicesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDevicesDialogControls, for DevicesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[dialac] 1/22/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDevicesDialogControls
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
        /// Read-only property to access UnmonitoredPowerComboBox
        /// </summary>
        EditComboBox UnmonitoredPowerComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TotalKWStaticControl
        /// </summary>
        StaticControl TotalKWStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access EnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform
        /// </summary>
        StaticControl EnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DevicesGroupButton
        /// </summary>
        Button DevicesGroupButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SummaryTextBox
        /// </summary>
        TextBox SummaryTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DevicesGroupStaticControl
        /// </summary>
        StaticControl DevicesGroupStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe
        /// </summary>
        StaticControl PowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AdditionalPowerConsumptionStaticControl
        /// </summary>
        StaticControl AdditionalPowerConsumptionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DevicesInPowerDomainStaticControl
        /// </summary>
        StaticControl DevicesInPowerDomainStaticControl
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
        /// Read-only property to access DevicesStaticControl2
        /// </summary>
        StaticControl DevicesStaticControl2
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
    public class DevicesDialog : Dialog, IDevicesDialogControls
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
        /// Cache to hold a reference to UnmonitoredPowerComboBox of type ComboBox
        /// </summary>
        private EditComboBox cachedUnmonitoredPowerComboBox;
        
        /// <summary>
        /// Cache to hold a reference to TotalKWStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTotalKWStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to EnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform of type StaticControl
        /// </summary>
        private StaticControl cachedEnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform;
        
        /// <summary>
        /// Cache to hold a reference to DevicesGroupButton of type Button
        /// </summary>
        private Button cachedDevicesGroupButton;
        
        /// <summary>
        /// Cache to hold a reference to SummaryTextBox of type TextBox
        /// </summary>
        private TextBox cachedSummaryTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DevicesGroupStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDevicesGroupStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe of type StaticControl
        /// </summary>
        private StaticControl cachedPowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe;
        
        /// <summary>
        /// Cache to hold a reference to AdditionalPowerConsumptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAdditionalPowerConsumptionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DevicesInPowerDomainStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDevicesInPowerDomainStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DevicesStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedDevicesStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of DevicesDialog of type CoreManager.MomConsole
        /// </param>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DevicesDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IDevicesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDevicesDialogControls Controls
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
        ///  Routine to set/get the text in control UnmonitoredPower
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string UnmonitoredPowerText
        {
            get
            {
                return this.Controls.UnmonitoredPowerComboBox.Text;
            }
            
            set
            {
                this.Controls.UnmonitoredPowerComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Summary
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SummaryText
        {
            get
            {
                return this.Controls.SummaryTextBox.Text;
            }
            
            set
            {
                this.Controls.SummaryTextBox.Text = value;
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
        Button IDevicesDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, DevicesDialog.ControlIDs.PreviousButton);
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
        Button IDevicesDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, DevicesDialog.ControlIDs.NextButton);
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
        Button IDevicesDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, DevicesDialog.ControlIDs.CreateButton);
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
        Button IDevicesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, DevicesDialog.ControlIDs.CancelButton);
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
        StaticControl IDevicesDialogControls.MonitoringTypeStaticControl
        {
            get
            {
                if ((this.cachedMonitoringTypeStaticControl == null))
                {
                    this.cachedMonitoringTypeStaticControl = new StaticControl(this, DevicesDialog.ControlIDs.MonitoringTypeStaticControl);
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
        StaticControl IDevicesDialogControls.GeneralPropertiesStaticControl
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
        StaticControl IDevicesDialogControls.PowerDomainSettingsStaticControl
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
        StaticControl IDevicesDialogControls.DevicesStaticControl
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
        StaticControl IDevicesDialogControls.SummaryStaticControl
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
        ///  Exposes access to the UnmonitoredPowerComboBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IDevicesDialogControls.UnmonitoredPowerComboBox
        {
            get
            {
                if ((this.cachedUnmonitoredPowerComboBox == null))
                {
                    this.cachedUnmonitoredPowerComboBox = new EditComboBox(this, DevicesDialog.ControlIDs.UnmonitoredPowerComboBox);
                }
                
                return this.cachedUnmonitoredPowerComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TotalKWStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDevicesDialogControls.TotalKWStaticControl
        {
            get
            {
                if ((this.cachedTotalKWStaticControl == null))
                {
                    this.cachedTotalKWStaticControl = new StaticControl(this, DevicesDialog.ControlIDs.TotalKWStaticControl);
                }
                
                return this.cachedTotalKWStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the EnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDevicesDialogControls.EnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform
        {
            get
            {
                if ((this.cachedEnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform == null))
                {
                    this.cachedEnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform = new StaticControl(this, DevicesDialog.ControlIDs.EnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform);
                }
                
                return this.cachedEnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DevicesGroupButton control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDevicesDialogControls.DevicesGroupButton
        {
            get
            {
                if ((this.cachedDevicesGroupButton == null))
                {
                    this.cachedDevicesGroupButton = new Button(this, DevicesDialog.ControlIDs.DevicesGroupButton);
                }
                
                return this.cachedDevicesGroupButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryTextBox control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IDevicesDialogControls.SummaryTextBox
        {
            get
            {
                if ((this.cachedSummaryTextBox == null))
                {
                    this.cachedSummaryTextBox = new TextBox(this, DevicesDialog.ControlIDs.SummaryTextBox);
                }
                
                return this.cachedSummaryTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DevicesGroupStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDevicesDialogControls.DevicesGroupStaticControl
        {
            get
            {
                if ((this.cachedDevicesGroupStaticControl == null))
                {
                    this.cachedDevicesGroupStaticControl = new StaticControl(this, DevicesDialog.ControlIDs.DevicesGroupStaticControl);
                }
                
                return this.cachedDevicesGroupStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDevicesDialogControls.PowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe
        {
            get
            {
                if ((this.cachedPowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe == null))
                {
                    this.cachedPowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe = new StaticControl(this, DevicesDialog.ControlIDs.PowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe);
                }
                
                return this.cachedPowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdditionalPowerConsumptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDevicesDialogControls.AdditionalPowerConsumptionStaticControl
        {
            get
            {
                if ((this.cachedAdditionalPowerConsumptionStaticControl == null))
                {
                    this.cachedAdditionalPowerConsumptionStaticControl = new StaticControl(this, DevicesDialog.ControlIDs.AdditionalPowerConsumptionStaticControl);
                }
                
                return this.cachedAdditionalPowerConsumptionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DevicesInPowerDomainStaticControl control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDevicesDialogControls.DevicesInPowerDomainStaticControl
        {
            get
            {
                if ((this.cachedDevicesInPowerDomainStaticControl == null))
                {
                    this.cachedDevicesInPowerDomainStaticControl = new StaticControl(this, DevicesDialog.ControlIDs.DevicesInPowerDomainStaticControl);
                }
                
                return this.cachedDevicesInPowerDomainStaticControl;
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
        StaticControl IDevicesDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, DevicesDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DevicesStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDevicesDialogControls.DevicesStaticControl2
        {
            get
            {
                if ((this.cachedDevicesStaticControl2 == null))
                {
                    this.cachedDevicesStaticControl2 = new StaticControl(this, DevicesDialog.ControlIDs.DevicesStaticControl2);
                }
                
                return this.cachedDevicesStaticControl2;
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button DevicesGroup
        /// </summary>
        /// <history>
        /// 	[dialac] 1/22/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDevicesGroup()
        {
            this.Controls.DevicesGroupButton.Click();
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
            /// Contains resource string for:  TotalKW
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTotalKW = ";&Total kW:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.PowerDomainDevicesPage;lblTo" +
                "talKW.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  EnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform = @";Enter total power consumption for devices that Operations Manager cannot collect power consumption from. This information will be included in the calculation of the overall power consumption of the power domain.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PowerDomainDevicesPage;lblPowerConsumptionSectionDesc.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DevicesGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDevicesGroupButton = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DevicesGroup
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDevicesGroup = ";Devices &group:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mi" +
                "crosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PowerDomainDevicesPage;" +
                "lblDevicesGroup.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe = @";Power consumption information will be collected by Operations Manager for all devices in the power domain. Specify the group that contains all the devices in the power domain.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PowerDomainDevicesPage;lblDevicesSectionDesc.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdditionalPowerConsumption
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdditionalPowerConsumption = ";Additional power consumption;ManagedString;Microsoft.EnterpriseManagement.UI.Aut" +
                "horing.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PowerDomai" +
                "nDevicesPage;lblPowerConsumptionSection.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DevicesInPowerDomain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDevicesInPowerDomain = ";Devices in power domain;ManagedString;Microsoft.EnterpriseManagement.UI.Authorin" +
                "g.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.PowerDomainDevi" +
                "cesPage;lblDevicesSection.Text";
            
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
            /// Contains resource string for:  Devices2
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDevices2 = "Devices";
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
            /// Caches the translated resource string for:  TotalKW
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTotalKW;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  EnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform;
            
            ///// -----------------------------------------------------------------------------
            ///// <summary>
            ///// Caches the translated resource string for:  DevicesGroup
            ///// </summary>
            ///// -----------------------------------------------------------------------------
            //private static string cachedDevicesGroupButton;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DevicesGroupButton
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDevicesGroup;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdditionalPowerConsumption
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdditionalPowerConsumption;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DevicesInPowerDomain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDevicesInPowerDomain;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Devices2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDevices2;
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
            /// Exposes access to the TotalKW translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TotalKW
            {
                get
                {
                    if ((cachedTotalKW == null))
                    {
                        cachedTotalKW = CoreManager.MomConsole.GetIntlStr(ResourceTotalKW);
                    }
                    
                    return cachedTotalKW;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the EnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform
            {
                get
                {
                    if ((cachedEnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform == null))
                    {
                        cachedEnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform = CoreManager.MomConsole.GetIntlStr(ResourceEnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform);
                    }
                    
                    return cachedEnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DevicesGroup translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DevicesGroup
            {
                get
                {
                    if ((cachedDevicesGroup == null))
                    {
                        cachedDevicesGroup = CoreManager.MomConsole.GetIntlStr(ResourceDevicesGroup);
                    }
                    
                    return cachedDevicesGroup;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DevicesGroup translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DevicesGroupButton
            {
                get
                {
                    if ((cachedDevicesGroup == null))
                    {
                        cachedDevicesGroup = CoreManager.MomConsole.GetIntlStr(ResourceDevicesGroupButton);
                    }
                    
                    return cachedDevicesGroup;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe
            {
                get
                {
                    if ((cachedPowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe == null))
                    {
                        cachedPowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe = CoreManager.MomConsole.GetIntlStr(ResourcePowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe);
                    }
                    
                    return cachedPowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdditionalPowerConsumption translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdditionalPowerConsumption
            {
                get
                {
                    if ((cachedAdditionalPowerConsumption == null))
                    {
                        cachedAdditionalPowerConsumption = CoreManager.MomConsole.GetIntlStr(ResourceAdditionalPowerConsumption);
                    }
                    
                    return cachedAdditionalPowerConsumption;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DevicesInPowerDomain translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DevicesInPowerDomain
            {
                get
                {
                    if ((cachedDevicesInPowerDomain == null))
                    {
                        cachedDevicesInPowerDomain = CoreManager.MomConsole.GetIntlStr(ResourceDevicesInPowerDomain);
                    }
                    
                    return cachedDevicesInPowerDomain;
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
            /// Exposes access to the Devices2 translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 1/22/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Devices2
            {
                get
                {
                    if ((cachedDevices2 == null))
                    {
                        cachedDevices2 = CoreManager.MomConsole.GetIntlStr(ResourceDevices2);
                    }
                    
                    return cachedDevices2;
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
            /// Control ID for UnmonitoredPowerComboBox
            /// </summary>
            public const string UnmonitoredPowerComboBox = "nudUnmonitoredPower";
            
            /// <summary>
            /// Control ID for TotalKWStaticControl
            /// </summary>
            public const string TotalKWStaticControl = "lblTotalKW";
            
            /// <summary>
            /// Control ID for EnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform
            /// </summary>
            public const string EnterTotalPowerConsumptionForDevicesThatOperationsManagerCannotCollectPowerConsumptionFromThisInform = "lblPowerConsumptionSectionDesc";
            
            /// <summary>
            /// Control ID for DevicesGroupButton
            /// </summary>
            public const string DevicesGroupButton = "btnDevicesGroup";
            
            /// <summary>
            /// Control ID for SummaryTextBox
            /// </summary>
            public const string SummaryTextBox = "textBox1";
            
            /// <summary>
            /// Control ID for DevicesGroupStaticControl
            /// </summary>
            public const string DevicesGroupStaticControl = "lblDevicesGroup";
            
            /// <summary>
            /// Control ID for PowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe
            /// </summary>
            public const string PowerConsumptionInformationWillBeCollectedByOperationsManagerForAllDevicesInThePowerDomainSpecifyThe = "lblDevicesSectionDesc";
            
            /// <summary>
            /// Control ID for AdditionalPowerConsumptionStaticControl
            /// </summary>
            public const string AdditionalPowerConsumptionStaticControl = "lblPowerConsumptionSection";
            
            /// <summary>
            /// Control ID for DevicesInPowerDomainStaticControl
            /// </summary>
            public const string DevicesInPowerDomainStaticControl = "lblDevicesSection";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for DevicesStaticControl2
            /// </summary>
            public const string DevicesStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
