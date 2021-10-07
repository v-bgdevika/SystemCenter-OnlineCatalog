// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CreateAttributeWizardRegProbeConfig.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[visnara] 7/22/2006 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Attributes.Wizards
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
    /// 	[visnara] 7/22/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum RadioGroup0
    {
        /// <summary>
        /// Value = 0
        /// </summary>
        Value = 0,
        
        /// <summary>
        /// Key = 1
        /// </summary>
        Key = 1,
    }
    #endregion
    
    #region Interface Definition - ICreateAttributeWizardRegProbeConfigControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICreateAttributeWizardRegProbeConfigControls, for CreateAttributeWizardRegProbeConfig.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[visnara] 7/22/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICreateAttributeWizardRegProbeConfigControls
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
        /// Read-only property to access FinishButton
        /// </summary>
        Button FinishButton
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
        /// Read-only property to access DiscoveryMethodStaticControl
        /// </summary>
        StaticControl DiscoveryMethodStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RegistryProbeConfigurationStaticControl
        /// </summary>
        StaticControl RegistryProbeConfigurationStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComputerNameStaticControl
        /// </summary>
        StaticControl ComputerNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PropertiesStaticControl
        /// </summary>
        StaticControl PropertiesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access KeyOrValueTypeStaticControl
        /// </summary>
        StaticControl KeyOrValueTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Ellipsis0Button
        /// </summary>
        Button Ellipsis0Button
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementPackComboBox
        /// </summary>
        ComboBox ManagementPackComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AttributeTypeStaticControl
        /// </summary>
        StaticControl AttributeTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ValueRadioButton
        /// </summary>
        RadioButton ValueRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access KeyRadioButton
        /// </summary>
        RadioButton KeyRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HKEY_LOCAL_MACHINETextBox
        /// </summary>
        TextBox HKEY_LOCAL_MACHINETextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PathStaticControl
        /// </summary>
        StaticControl PathStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access YouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse
        /// </summary>
        StaticControl YouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Button1
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        Button Button1
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd
        /// </summary>
        TextBox TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NameStaticControl
        /// </summary>
        StaticControl NameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access HKEY_LOCAL_MACHINEStaticControl
        /// </summary>
        StaticControl HKEY_LOCAL_MACHINEStaticControl
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
        /// Read-only property to access SpecifyTheRegistryAttributeToBeCollectedStaticControl
        /// </summary>
        StaticControl SpecifyTheRegistryAttributeToBeCollectedStaticControl
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
    /// 	[visnara] 7/22/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class CreateAttributeWizardRegProbeConfig : Dialog, ICreateAttributeWizardRegProbeConfigControls
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
        /// Cache to hold a reference to FinishButton of type Button
        /// </summary>
        private Button cachedFinishButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to GeneralPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DiscoveryMethodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiscoveryMethodStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RegistryProbeConfigurationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRegistryProbeConfigurationStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ComputerNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedComputerNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to KeyOrValueTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedKeyOrValueTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to Ellipsis0Button of type Button
        /// </summary>
        private Button cachedEllipsis0Button;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedManagementPackComboBox;
        
        /// <summary>
        /// Cache to hold a reference to AttributeTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAttributeTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ValueRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedValueRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to KeyRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedKeyRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to HKEY_LOCAL_MACHINETextBox of type TextBox
        /// </summary>
        private TextBox cachedHKEY_LOCAL_MACHINETextBox;
        
        /// <summary>
        /// Cache to hold a reference to PathStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPathStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to YouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse of type StaticControl
        /// </summary>
        private StaticControl cachedYouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse;
        
        /// <summary>
        /// Cache to hold a reference to Button1 of type Button
        /// </summary>
        private Button cachedButton1;
        
        /// <summary>
        /// Cache to hold a reference to TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd of type TextBox
        /// </summary>
        private TextBox cachedTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd;
        
        /// <summary>
        /// Cache to hold a reference to NameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HKEY_LOCAL_MACHINEStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHKEY_LOCAL_MACHINEStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyTheRegistryAttributeToBeCollectedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyTheRegistryAttributeToBeCollectedStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of CreateAttributeWizardRegProbeConfig of type Maui.Core.App
        /// </param>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateAttributeWizardRegProbeConfig(Maui.Core.App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group RadioGroup0
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual RadioGroup0 RadioGroup0
        {
            get
            {
                if ((this.Controls.ValueRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.Value;
                }
                
                if ((this.Controls.KeyRadioButton.ButtonState == ButtonState.Checked))
                {
                    return RadioGroup0.Key;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == RadioGroup0.Value))
                {
                    this.Controls.ValueRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == RadioGroup0.Key))
                    {
                        this.Controls.KeyRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region ICreateAttributeWizardRegProbeConfig Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICreateAttributeWizardRegProbeConfigControls Controls
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
        ///  Routine to set/get the text in control Attribute Type
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AttributeTypeText
        {
            get
            {
                return this.Controls.ManagementPackComboBox.Text;
            }
            
            set
            {
                this.Controls.ManagementPackComboBox.SelectByText(value);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control HKEY_LOCAL_MACHINE
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string HKEY_LOCAL_MACHINEText
        {
            get
            {
                return this.Controls.HKEY_LOCAL_MACHINETextBox.Text;
            }
            
            set
            {
                this.Controls.HKEY_LOCAL_MACHINETextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAdText
        {
            get
            {
                return this.Controls.TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd.Text;
            }
            
            set
            {
                this.Controls.TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateAttributeWizardRegProbeConfigControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, CreateAttributeWizardRegProbeConfig.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateAttributeWizardRegProbeConfigControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, CreateAttributeWizardRegProbeConfig.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateAttributeWizardRegProbeConfigControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, CreateAttributeWizardRegProbeConfig.ControlIDs.FinishButton);
                }
                
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateAttributeWizardRegProbeConfigControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CreateAttributeWizardRegProbeConfig.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardRegProbeConfigControls.GeneralPropertiesStaticControl
        {
            get
            {
                if ((this.cachedGeneralPropertiesStaticControl == null))
                {
                    this.cachedGeneralPropertiesStaticControl = new StaticControl(this, CreateAttributeWizardRegProbeConfig.ControlIDs.GeneralPropertiesStaticControl);
                }
                
                return this.cachedGeneralPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiscoveryMethodStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardRegProbeConfigControls.DiscoveryMethodStaticControl
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
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedDiscoveryMethodStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedDiscoveryMethodStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RegistryProbeConfigurationStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardRegProbeConfigControls.RegistryProbeConfigurationStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedRegistryProbeConfigurationStaticControl == null))
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
                    this.cachedRegistryProbeConfigurationStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedRegistryProbeConfigurationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComputerNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardRegProbeConfigControls.ComputerNameStaticControl
        {
            get
            {
                if ((this.cachedComputerNameStaticControl == null))
                {
                    this.cachedComputerNameStaticControl = new StaticControl(this, CreateAttributeWizardRegProbeConfig.ControlIDs.ComputerNameStaticControl);
                }
                
                return this.cachedComputerNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardRegProbeConfigControls.PropertiesStaticControl
        {
            get
            {
                if ((this.cachedPropertiesStaticControl == null))
                {
                    this.cachedPropertiesStaticControl = new StaticControl(this, CreateAttributeWizardRegProbeConfig.ControlIDs.PropertiesStaticControl);
                }
                
                return this.cachedPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the KeyOrValueTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardRegProbeConfigControls.KeyOrValueTypeStaticControl
        {
            get
            {
                if ((this.cachedKeyOrValueTypeStaticControl == null))
                {
                    this.cachedKeyOrValueTypeStaticControl = new StaticControl(this, CreateAttributeWizardRegProbeConfig.ControlIDs.KeyOrValueTypeStaticControl);
                }
                
                return this.cachedKeyOrValueTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Ellipsis0Button control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateAttributeWizardRegProbeConfigControls.Ellipsis0Button
        {
            get
            {
                if ((this.cachedEllipsis0Button == null))
                {
                    this.cachedEllipsis0Button = new Button(this, CreateAttributeWizardRegProbeConfig.ControlIDs.Ellipsis0Button);
                }
                
                return this.cachedEllipsis0Button;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackComboBox control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ICreateAttributeWizardRegProbeConfigControls.ManagementPackComboBox
        {
            get
            {
                if ((this.cachedManagementPackComboBox == null))
                {
                    this.cachedManagementPackComboBox = new ComboBox(this, CreateAttributeWizardRegProbeConfig.ControlIDs.ManagementPackComboBox);
                }
                
                return this.cachedManagementPackComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AttributeTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardRegProbeConfigControls.AttributeTypeStaticControl
        {
            get
            {
                if ((this.cachedAttributeTypeStaticControl == null))
                {
                    this.cachedAttributeTypeStaticControl = new StaticControl(this, CreateAttributeWizardRegProbeConfig.ControlIDs.AttributeTypeStaticControl);
                }
                
                return this.cachedAttributeTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ValueRadioButton control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateAttributeWizardRegProbeConfigControls.ValueRadioButton
        {
            get
            {
                if ((this.cachedValueRadioButton == null))
                {
                    this.cachedValueRadioButton = new RadioButton(this, CreateAttributeWizardRegProbeConfig.ControlIDs.ValueRadioButton);
                }
                
                return this.cachedValueRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the KeyRadioButton control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton ICreateAttributeWizardRegProbeConfigControls.KeyRadioButton
        {
            get
            {
                if ((this.cachedKeyRadioButton == null))
                {
                    this.cachedKeyRadioButton = new RadioButton(this, CreateAttributeWizardRegProbeConfig.ControlIDs.KeyRadioButton);
                }
                
                return this.cachedKeyRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HKEY_LOCAL_MACHINETextBox control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateAttributeWizardRegProbeConfigControls.HKEY_LOCAL_MACHINETextBox
        {
            get
            {
                if ((this.cachedHKEY_LOCAL_MACHINETextBox == null))
                {
                    this.cachedHKEY_LOCAL_MACHINETextBox = new TextBox(this, CreateAttributeWizardRegProbeConfig.ControlIDs.HKEY_LOCAL_MACHINETextBox);
                }
                
                return this.cachedHKEY_LOCAL_MACHINETextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PathStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardRegProbeConfigControls.PathStaticControl
        {
            get
            {
                if ((this.cachedPathStaticControl == null))
                {
                    this.cachedPathStaticControl = new StaticControl(this, CreateAttributeWizardRegProbeConfig.ControlIDs.PathStaticControl);
                }
                
                return this.cachedPathStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the YouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardRegProbeConfigControls.YouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse
        {
            get
            {
                if ((this.cachedYouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse == null))
                {
                    this.cachedYouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse = new StaticControl(this, CreateAttributeWizardRegProbeConfig.ControlIDs.YouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse);
                }
                
                return this.cachedYouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Button1 control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateAttributeWizardRegProbeConfigControls.Button1
        {
            get
            {
                if ((this.cachedButton1 == null))
                {
                    this.cachedButton1 = new Button(this, CreateAttributeWizardRegProbeConfig.ControlIDs.Button1);
                }
                
                return this.cachedButton1;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateAttributeWizardRegProbeConfigControls.TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd
        {
            get
            {
                if ((this.cachedTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd == null))
                {
                    this.cachedTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd = new TextBox(this, CreateAttributeWizardRegProbeConfig.ControlIDs.TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd);
                }
                
                return this.cachedTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardRegProbeConfigControls.NameStaticControl
        {
            get
            {
                if ((this.cachedNameStaticControl == null))
                {
                    this.cachedNameStaticControl = new StaticControl(this, CreateAttributeWizardRegProbeConfig.ControlIDs.NameStaticControl);
                }
                
                return this.cachedNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HKEY_LOCAL_MACHINEStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardRegProbeConfigControls.HKEY_LOCAL_MACHINEStaticControl
        {
            get
            {
                if ((this.cachedHKEY_LOCAL_MACHINEStaticControl == null))
                {
                    this.cachedHKEY_LOCAL_MACHINEStaticControl = new StaticControl(this, CreateAttributeWizardRegProbeConfig.ControlIDs.HKEY_LOCAL_MACHINEStaticControl);
                }
                
                return this.cachedHKEY_LOCAL_MACHINEStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardRegProbeConfigControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, CreateAttributeWizardRegProbeConfig.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyTheRegistryAttributeToBeCollectedStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardRegProbeConfigControls.SpecifyTheRegistryAttributeToBeCollectedStaticControl
        {
            get
            {
                if ((this.cachedSpecifyTheRegistryAttributeToBeCollectedStaticControl == null))
                {
                    this.cachedSpecifyTheRegistryAttributeToBeCollectedStaticControl = new StaticControl(this, CreateAttributeWizardRegProbeConfig.ControlIDs.SpecifyTheRegistryAttributeToBeCollectedStaticControl);
                }
                
                return this.cachedSpecifyTheRegistryAttributeToBeCollectedStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
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
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Finish
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFinish()
        {
            this.Controls.FinishButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Ellipsis0
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickEllipsis0()
        {
            this.Controls.Ellipsis0Button.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Button1
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickButton1()
        {
            this.Controls.Button1.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">Maui.Core.App owning the dialog.</param>)
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(Maui.Core.App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, 
                    StringMatchSyntax.ExactMatch, 
                    WindowClassNames.WinForms10Window8, 
                    StringMatchSyntax.ExactMatch, 
                    app.MainWindow, Timeout);
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
                        Core.Common.Utilities.LogMessage(
                           "Attempt " + numberOfTries + " of " + MaxTries);
                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                        Strings.DialogTitle + "'");
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
        /// 	[visnara] 7/22/2006 Created
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
            private const string ResourceDialogTitle = ";Create Attribute Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility.UISDKResources;CreateAttributeWizard";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFramework.WizardButtonsPanel" +
                ";previousButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Mic" +
                "rosoft.EnterpriseManagement.Mom.Internal.UI.PageFramework.WizardButtonsPanel;nex" +
                "tButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = ";&Finish;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micro" +
                "soft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;FinishTe" +
                "xt";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";
            
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
            /// Contains resource string for:  RegistryProbeConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRegistryProbeConfiguration = ";Registry Probe Configuration;ManagedString;Microsoft.EnterpriseManagement.UI.Aut" +
                "horing.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RegistryPr" +
                "obe.RegistryProbeStrings;TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ComputerName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComputerName = ";Computer Name;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micr" +
                "osoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RegistryProbeSinglePage;c" +
                "omputerNameLineSeparator.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Properties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProperties = ";Properties;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.SourceCod" +
                "e.Commands.Strings;Properties.Description";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  KeyOrValueType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceKeyOrValueType = ";Key or Value Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RegistryProbeSinglePa" +
                "ge;idSeparatorObjectType.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Ellipsis0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceEllipsis0 = ";...;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.A" +
                "ppearanceProperties;buttonBackColor.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AttributeType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAttributeType = ";Attribute Type :;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RegistryProbeSinglePag" +
                "e;idAttibuteTypeLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Value
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceValue = ";&Value;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.RegistryProbeSinglePage;idRadioV" +
                "alue.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Key
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceKey = ";&Key;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Pages.RegistryProbeSinglePage;idRadioKey" +
                ".Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Path
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePath = ";&Path : ;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.Pages.RegistryProbeSinglePage;label1" +
                ".Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  YouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceYouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse = @";You can refer to a property of the target entity type to be substituted during runtime. Specify blank computer name to use the local computer.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RegistryProbePage;targetPropRefLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceName = ";Na&me:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.E" +
                "nterpriseManagement.Internal.UI.Authoring.Pages.AlertingModulePage;alertNameLabe" +
                "l.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  HKEY_LOCAL_MACHINE
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHKEY_LOCAL_MACHINE = ";HKEY_LOCAL_MACHINE\\;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dl" +
                "l;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RegistryProbeSingle" +
                "Page;hkeyLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Common.CommonResources;CommandHelp";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyTheRegistryAttributeToBeCollected
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyTheRegistryAttributeToBeCollected = ";Specify the registry attribute to be collected.;ManagedString;Microsoft.Enterpri" +
                "seManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authori" +
                "ng.Pages.RegistryProbe.RegistryProbeStrings;SubTitle";
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
            /// Caches the translated resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFinish;
            
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
            /// Caches the translated resource string for:  DiscoveryMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiscoveryMethod;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RegistryProbeConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRegistryProbeConfiguration;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ComputerName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComputerName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Properties
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProperties;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  KeyOrValueType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedKeyOrValueType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Ellipsis0
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEllipsis0;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AttributeType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAttributeType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Value
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedValue;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Key
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedKey;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Path
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPath;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  YouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedYouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  HKEY_LOCAL_MACHINE
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHKEY_LOCAL_MACHINE;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyTheRegistryAttributeToBeCollected
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyTheRegistryAttributeToBeCollected;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
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
            /// 	[visnara] 7/22/2006 Created
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
            /// 	[visnara] 7/22/2006 Created
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
            /// Exposes access to the Finish translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
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
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
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
            /// 	[visnara] 7/22/2006 Created
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
            /// 	[visnara] 7/22/2006 Created
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
            /// Exposes access to the RegistryProbeConfiguration translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RegistryProbeConfiguration
            {
                get
                {
                    if ((cachedRegistryProbeConfiguration == null))
                    {
                        cachedRegistryProbeConfiguration = CoreManager.MomConsole.GetIntlStr(ResourceRegistryProbeConfiguration);
                    }
                    
                    return cachedRegistryProbeConfiguration;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ComputerName translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ComputerName
            {
                get
                {
                    if ((cachedComputerName == null))
                    {
                        cachedComputerName = CoreManager.MomConsole.GetIntlStr(ResourceComputerName);
                    }
                    
                    return cachedComputerName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Properties translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Properties
            {
                get
                {
                    if ((cachedProperties == null))
                    {
                        cachedProperties = CoreManager.MomConsole.GetIntlStr(ResourceProperties);
                    }
                    
                    return cachedProperties;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the KeyOrValueType translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string KeyOrValueType
            {
                get
                {
                    if ((cachedKeyOrValueType == null))
                    {
                        cachedKeyOrValueType = CoreManager.MomConsole.GetIntlStr(ResourceKeyOrValueType);
                    }
                    
                    return cachedKeyOrValueType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ellipsis0 translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ellipsis0
            {
                get
                {
                    if ((cachedEllipsis0 == null))
                    {
                        cachedEllipsis0 = CoreManager.MomConsole.GetIntlStr(ResourceEllipsis0);
                    }
                    
                    return cachedEllipsis0;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AttributeType translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AttributeType
            {
                get
                {
                    if ((cachedAttributeType == null))
                    {
                        cachedAttributeType = CoreManager.MomConsole.GetIntlStr(ResourceAttributeType);
                    }
                    
                    return cachedAttributeType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Value translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Value
            {
                get
                {
                    if ((cachedValue == null))
                    {
                        cachedValue = CoreManager.MomConsole.GetIntlStr(ResourceValue);
                    }
                    
                    return cachedValue;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Key translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Key
            {
                get
                {
                    if ((cachedKey == null))
                    {
                        cachedKey = CoreManager.MomConsole.GetIntlStr(ResourceKey);
                    }
                    
                    return cachedKey;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Path translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Path
            {
                get
                {
                    if ((cachedPath == null))
                    {
                        cachedPath = CoreManager.MomConsole.GetIntlStr(ResourcePath);
                    }
                    
                    return cachedPath;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the YouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string YouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse
            {
                get
                {
                    if ((cachedYouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse == null))
                    {
                        cachedYouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse = CoreManager.MomConsole.GetIntlStr(ResourceYouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse);
                    }
                    
                    return cachedYouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Name
            {
                get
                {
                    if ((cachedName == null))
                    {
                        cachedName = CoreManager.MomConsole.GetIntlStr(ResourceName);
                    }
                    
                    return cachedName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HKEY_LOCAL_MACHINE translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HKEY_LOCAL_MACHINE
            {
                get
                {
                    if ((cachedHKEY_LOCAL_MACHINE == null))
                    {
                        cachedHKEY_LOCAL_MACHINE = CoreManager.MomConsole.GetIntlStr(ResourceHKEY_LOCAL_MACHINE);
                    }
                    
                    return cachedHKEY_LOCAL_MACHINE;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
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
            /// Exposes access to the SpecifyTheRegistryAttributeToBeCollected translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyTheRegistryAttributeToBeCollected
            {
                get
                {
                    if ((cachedSpecifyTheRegistryAttributeToBeCollected == null))
                    {
                        cachedSpecifyTheRegistryAttributeToBeCollected = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyTheRegistryAttributeToBeCollected);
                    }
                    
                    return cachedSpecifyTheRegistryAttributeToBeCollected;
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
        /// 	[visnara] 7/22/2006 Created
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
            /// Control ID for FinishButton
            /// </summary>
            public const string FinishButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DiscoveryMethodStaticControl
            /// </summary>
            public const string DiscoveryMethodStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for RegistryProbeConfigurationStaticControl
            /// </summary>
            public const string RegistryProbeConfigurationStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ComputerNameStaticControl
            /// </summary>
            public const string ComputerNameStaticControl = "computerNameLineSeparator";
            
            /// <summary>
            /// Control ID for PropertiesStaticControl
            /// </summary>
            public const string PropertiesStaticControl = "idSeparatorProperties";
            
            /// <summary>
            /// Control ID for KeyOrValueTypeStaticControl
            /// </summary>
            public const string KeyOrValueTypeStaticControl = "idSeparatorObjectType";
            
            /// <summary>
            /// Control ID for Ellipsis0Button
            /// </summary>
            public const string Ellipsis0Button = "idBtnPathBrowse";
            
            /// <summary>
            /// Control ID for ManagementPackComboBox
            /// </summary>
            public const string ManagementPackComboBox = "idAttributeTypeCombo";
            
            /// <summary>
            /// Control ID for AttributeTypeStaticControl
            /// </summary>
            public const string AttributeTypeStaticControl = "idAttibuteTypeLabel";
            
            /// <summary>
            /// Control ID for ValueRadioButton
            /// </summary>
            public const string ValueRadioButton = "idRadioValue";
            
            /// <summary>
            /// Control ID for KeyRadioButton
            /// </summary>
            public const string KeyRadioButton = "idRadioKey";
            
            /// <summary>
            /// Control ID for HKEY_LOCAL_MACHINETextBox
            /// </summary>
            public const string HKEY_LOCAL_MACHINETextBox = "idPathEdit";
            
            /// <summary>
            /// Control ID for PathStaticControl
            /// </summary>
            public const string PathStaticControl = "label1";
            
            /// <summary>
            /// Control ID for YouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse
            /// </summary>
            public const string YouCanReferToAPropertyOfTheTargetEntityTypeToBeSubstitutedDuringRuntimeSpecifyBlankComputerNameToUse = "targetPropRefLabel";
            
            /// <summary>
            /// Control ID for Button1
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Button1 = "hostTypesButton";
            
            /// <summary>
            /// Control ID for TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd
            /// </summary>
            public const string TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd = "computerNameTextBox";
            
            /// <summary>
            /// Control ID for NameStaticControl
            /// </summary>
            public const string NameStaticControl = "compNameLabel";
            
            /// <summary>
            /// Control ID for HKEY_LOCAL_MACHINEStaticControl
            /// </summary>
            public const string HKEY_LOCAL_MACHINEStaticControl = "hkeyLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for SpecifyTheRegistryAttributeToBeCollectedStaticControl
            /// </summary>
            public const string SpecifyTheRegistryAttributeToBeCollectedStaticControl = "headerLabel";
        }
        #endregion
    }
}
