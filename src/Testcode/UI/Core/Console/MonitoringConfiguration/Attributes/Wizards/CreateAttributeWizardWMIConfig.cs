// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CreateAttributeWizardWMIConfig.cs">
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
    
    #region Interface Definition - ICreateAttributeWizardWMIConfigControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICreateAttributeWizardWMIConfigControls, for CreateAttributeWizardWMIConfig.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[visnara] 7/22/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICreateAttributeWizardWMIConfigControls
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
        /// Read-only property to access WMIConfigurationStaticControl
        /// </summary>
        StaticControl WMIConfigurationStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PropertyNameTextBox
        /// </summary>
        TextBox PropertyNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyWMINamespaceAndHowOftenToRunTheQueryStaticControl
        /// </summary>
        StaticControl SpecifyWMINamespaceAndHowOftenToRunTheQueryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access QueryIntervalStaticControl
        /// </summary>
        StaticControl QueryIntervalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SecondsStaticControl
        /// </summary>
        StaticControl SecondsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd
        /// </summary>
        ComboBox TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access FrequencyStaticControl
        /// </summary>
        StaticControl FrequencyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DescriptionTextBox
        /// </summary>
        TextBox DescriptionTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access QueryStaticControl
        /// </summary>
        StaticControl QueryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NameTextBox
        /// </summary>
        TextBox NameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access WMINamespaceStaticControl
        /// </summary>
        StaticControl WMINamespaceStaticControl
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
        /// Read-only property to access ConfigureWMISettingsStaticControl
        /// </summary>
        StaticControl ConfigureWMISettingsStaticControl
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
    public class CreateAttributeWizardWMIConfig : Dialog, ICreateAttributeWizardWMIConfigControls
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
        /// Cache to hold a reference to WMIConfigurationStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWMIConfigurationStaticControl;

        /// <summary>
        /// Cache to hold a reference to PropertyNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedPropertyNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyWMINamespaceAndHowOftenToRunTheQueryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyWMINamespaceAndHowOftenToRunTheQueryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to QueryIntervalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedQueryIntervalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SecondsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSecondsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd of type ComboBox
        /// </summary>
        private ComboBox cachedTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd;
        
        /// <summary>
        /// Cache to hold a reference to FrequencyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedFrequencyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to QueryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedQueryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to WMINamespaceStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedWMINamespaceStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfigureWMISettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfigureWMISettingsStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of CreateAttributeWizardWMIConfig of type Maui.Core.App
        /// </param>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateAttributeWizardWMIConfig(Maui.Core.App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ICreateAttributeWizardWMIConfig Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICreateAttributeWizardWMIConfigControls Controls
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
                this.Controls.TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string WMIQueryText
        {
            get
            {
                return this.Controls.DescriptionTextBox.Text;
            }
            
            set
            {
                this.Controls.DescriptionTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NameText
        {
            get
            {
                return this.Controls.NameTextBox.Text;
            }
            
            set
            {
                this.Controls.NameTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control PropertyName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[visnara] 10/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PropertyNameText
        {
            get
            {
                return this.Controls.PropertyNameTextBox.Text;
            }

            set
            {
                this.Controls.PropertyNameTextBox.Text = value;
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
        Button ICreateAttributeWizardWMIConfigControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, CreateAttributeWizardWMIConfig.ControlIDs.PreviousButton);
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
        Button ICreateAttributeWizardWMIConfigControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, CreateAttributeWizardWMIConfig.ControlIDs.NextButton);
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
        Button ICreateAttributeWizardWMIConfigControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, CreateAttributeWizardWMIConfig.ControlIDs.FinishButton);
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
        Button ICreateAttributeWizardWMIConfigControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CreateAttributeWizardWMIConfig.ControlIDs.CancelButton);
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
        StaticControl ICreateAttributeWizardWMIConfigControls.GeneralPropertiesStaticControl
        {
            get
            {
                if ((this.cachedGeneralPropertiesStaticControl == null))
                {
                    this.cachedGeneralPropertiesStaticControl = new StaticControl(this, CreateAttributeWizardWMIConfig.ControlIDs.GeneralPropertiesStaticControl);
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
        StaticControl ICreateAttributeWizardWMIConfigControls.DiscoveryMethodStaticControl
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
        ///  Exposes access to the WMIConfigurationStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardWMIConfigControls.WMIConfigurationStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedWMIConfigurationStaticControl == null))
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
                    this.cachedWMIConfigurationStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedWMIConfigurationStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyWMINamespaceAndHowOftenToRunTheQueryStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardWMIConfigControls.SpecifyWMINamespaceAndHowOftenToRunTheQueryStaticControl
        {
            get
            {
                if ((this.cachedSpecifyWMINamespaceAndHowOftenToRunTheQueryStaticControl == null))
                {
                    this.cachedSpecifyWMINamespaceAndHowOftenToRunTheQueryStaticControl = new StaticControl(this, CreateAttributeWizardWMIConfig.ControlIDs.SpecifyWMINamespaceAndHowOftenToRunTheQueryStaticControl);
                }
                
                return this.cachedSpecifyWMINamespaceAndHowOftenToRunTheQueryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the QueryIntervalStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardWMIConfigControls.QueryIntervalStaticControl
        {
            get
            {
                if ((this.cachedQueryIntervalStaticControl == null))
                {
                    this.cachedQueryIntervalStaticControl = new StaticControl(this, CreateAttributeWizardWMIConfig.ControlIDs.QueryIntervalStaticControl);
                }
                
                return this.cachedQueryIntervalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SecondsStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardWMIConfigControls.SecondsStaticControl
        {
            get
            {
                if ((this.cachedSecondsStaticControl == null))
                {
                    this.cachedSecondsStaticControl = new StaticControl(this, CreateAttributeWizardWMIConfig.ControlIDs.SecondsStaticControl);
                }
                
                return this.cachedSecondsStaticControl;
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
        ComboBox ICreateAttributeWizardWMIConfigControls.TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd
        {
            get
            {
                if ((this.cachedTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd == null))
                {
                    this.cachedTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd = new ComboBox(this, CreateAttributeWizardWMIConfig.ControlIDs.TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd);
                }
                
                return this.cachedTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FrequencyStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardWMIConfigControls.FrequencyStaticControl
        {
            get
            {
                if ((this.cachedFrequencyStaticControl == null))
                {
                    this.cachedFrequencyStaticControl = new StaticControl(this, CreateAttributeWizardWMIConfig.ControlIDs.FrequencyStaticControl);
                }
                
                return this.cachedFrequencyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateAttributeWizardWMIConfigControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, CreateAttributeWizardWMIConfig.ControlIDs.DescriptionTextBox);
                }
                
                return this.cachedDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the QueryStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardWMIConfigControls.QueryStaticControl
        {
            get
            {
                if ((this.cachedQueryStaticControl == null))
                {
                    this.cachedQueryStaticControl = new StaticControl(this, CreateAttributeWizardWMIConfig.ControlIDs.QueryStaticControl);
                }
                
                return this.cachedQueryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NameTextBox control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateAttributeWizardWMIConfigControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, CreateAttributeWizardWMIConfig.ControlIDs.NameTextBox);
                }
                
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the WMINamespaceStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardWMIConfigControls.WMINamespaceStaticControl
        {
            get
            {
                if ((this.cachedWMINamespaceStaticControl == null))
                {
                    this.cachedWMINamespaceStaticControl = new StaticControl(this, CreateAttributeWizardWMIConfig.ControlIDs.WMINamespaceStaticControl);
                }
                
                return this.cachedWMINamespaceStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PropertyNameTextBox control
        /// </summary>
        /// <history>
        /// 	[visnara] 10/27/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ICreateAttributeWizardWMIConfigControls.PropertyNameTextBox
        {
            get
            {
                if ((this.cachedPropertyNameTextBox == null))
                {
                    this.cachedPropertyNameTextBox = new TextBox(this, CreateAttributeWizardWMIConfig.ControlIDs.PropertyNameTextBox);
                }

                return this.cachedPropertyNameTextBox;
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
        StaticControl ICreateAttributeWizardWMIConfigControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, CreateAttributeWizardWMIConfig.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfigureWMISettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardWMIConfigControls.ConfigureWMISettingsStaticControl
        {
            get
            {
                if ((this.cachedConfigureWMISettingsStaticControl == null))
                {
                    this.cachedConfigureWMISettingsStaticControl = new StaticControl(this, CreateAttributeWizardWMIConfig.ControlIDs.ConfigureWMISettingsStaticControl);
                }
                
                return this.cachedConfigureWMISettingsStaticControl;
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
                    app.MainWindow, 
                    Timeout);
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
            /// Contains resource string for:  WMIConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWMIConfiguration = ";WMI Configuration;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;" +
                "Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WMIDataSource;$this.T" +
                "abName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PropertyName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePropertyName = ";&Property Name:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mi" +
                "crosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WMIAttributeDataSource;" +
                "propertyNameLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyWMINamespaceAndHowOftenToRunTheQuery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyWMINamespaceAndHowOftenToRunTheQuery = ";Specify WMI namespace and how often to run the query;ManagedString;Microsoft.Ent" +
                "erpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Au" +
                "thoring.Pages.WMIDataSource;pageSectionLabel2.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  QueryInterval
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceQueryInterval = ";Query Interval;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mic" +
                "rosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WMIDataSource;frequencyS" +
                "eparator.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Seconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSeconds = ";seconds;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Pages.DiscoveryIntervalPage;secondsLa" +
                "bel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Frequency
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFrequency = ";&Frequency:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.Pages.WMIDataSource;frequencyLabe" +
                "l.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Query
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceQuery = ";&Query:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.Pages.WMIDataSource;queryLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WMINamespace
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWMINamespace = ";WMI Na&mespace:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Mi" +
                "crosoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WMIDataSource;NameSpace" +
                "Label.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Common.CommonResources;CommandHelp";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConfigureWMISettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfigureWMISettings = ";Configure WMI Settings;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring" +
                ".dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.WMIDataSource;$t" +
                "his.HeaderText";
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
            /// Caches the translated resource string for:  WMIConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWMIConfiguration;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PropertyName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPropertyName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyWMINamespaceAndHowOftenToRunTheQuery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyWMINamespaceAndHowOftenToRunTheQuery;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  QueryInterval
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedQueryInterval;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Seconds
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSeconds;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Frequency
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedFrequency;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Query
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedQuery;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WMINamespace
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWMINamespace;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConfigureWMISettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfigureWMISettings;
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
            /// Exposes access to the WMIConfiguration translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WMIConfiguration
            {
                get
                {
                    if ((cachedWMIConfiguration == null))
                    {
                        cachedWMIConfiguration = CoreManager.MomConsole.GetIntlStr(ResourceWMIConfiguration);
                    }
                    
                    return cachedWMIConfiguration;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PropertyName translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 10/27/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PropertyName
            {
                get
                {
                    if ((cachedPropertyName == null))
                    {
                        cachedPropertyName = CoreManager.MomConsole.GetIntlStr(ResourcePropertyName);
                    }

                    return cachedPropertyName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyWMINamespaceAndHowOftenToRunTheQuery translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyWMINamespaceAndHowOftenToRunTheQuery
            {
                get
                {
                    if ((cachedSpecifyWMINamespaceAndHowOftenToRunTheQuery == null))
                    {
                        cachedSpecifyWMINamespaceAndHowOftenToRunTheQuery = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyWMINamespaceAndHowOftenToRunTheQuery);
                    }
                    
                    return cachedSpecifyWMINamespaceAndHowOftenToRunTheQuery;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the QueryInterval translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string QueryInterval
            {
                get
                {
                    if ((cachedQueryInterval == null))
                    {
                        cachedQueryInterval = CoreManager.MomConsole.GetIntlStr(ResourceQueryInterval);
                    }
                    
                    return cachedQueryInterval;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Seconds translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Seconds
            {
                get
                {
                    if ((cachedSeconds == null))
                    {
                        cachedSeconds = CoreManager.MomConsole.GetIntlStr(ResourceSeconds);
                    }
                    
                    return cachedSeconds;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Frequency translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Frequency
            {
                get
                {
                    if ((cachedFrequency == null))
                    {
                        cachedFrequency = CoreManager.MomConsole.GetIntlStr(ResourceFrequency);
                    }
                    
                    return cachedFrequency;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Query translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Query
            {
                get
                {
                    if ((cachedQuery == null))
                    {
                        cachedQuery = CoreManager.MomConsole.GetIntlStr(ResourceQuery);
                    }
                    
                    return cachedQuery;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WMINamespace translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WMINamespace
            {
                get
                {
                    if ((cachedWMINamespace == null))
                    {
                        cachedWMINamespace = CoreManager.MomConsole.GetIntlStr(ResourceWMINamespace);
                    }
                    
                    return cachedWMINamespace;
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
            /// Exposes access to the ConfigureWMISettings translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfigureWMISettings
            {
                get
                {
                    if ((cachedConfigureWMISettings == null))
                    {
                        cachedConfigureWMISettings = CoreManager.MomConsole.GetIntlStr(ResourceConfigureWMISettings);
                    }
                    
                    return cachedConfigureWMISettings;
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
            /// Control ID for WMIConfigurationStaticControl
            /// </summary>
            public const string WMIConfigurationStaticControl = "textLinkLabel";

            /// <summary>
            /// Control ID for PropertyNameTextBox
            /// </summary>
            public const string PropertyNameTextBox = "propertyNameTextBox";
            
            /// <summary>
            /// Control ID for SpecifyWMINamespaceAndHowOftenToRunTheQueryStaticControl
            /// </summary>
            public const string SpecifyWMINamespaceAndHowOftenToRunTheQueryStaticControl = "pageSectionLabel2";
            
            /// <summary>
            /// Control ID for QueryIntervalStaticControl
            /// </summary>
            public const string QueryIntervalStaticControl = "frequencySeparator";
            
            /// <summary>
            /// Control ID for SecondsStaticControl
            /// </summary>
            public const string SecondsStaticControl = "secondsLabel";
            
            /// <summary>
            /// Control ID for TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd
            /// </summary>
            public const string TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd = "frequencyUpDown";
            
            /// <summary>
            /// Control ID for FrequencyStaticControl
            /// </summary>
            public const string FrequencyStaticControl = "frequencyLabel";
            
            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "queryTextBox";
            
            /// <summary>
            /// Control ID for QueryStaticControl
            /// </summary>
            public const string QueryStaticControl = "queryLabel";
            
            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "nameSpaceTextBox";
            
            /// <summary>
            /// Control ID for WMINamespaceStaticControl
            /// </summary>
            public const string WMINamespaceStaticControl = "NameSpaceLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ConfigureWMISettingsStaticControl
            /// </summary>
            public const string ConfigureWMISettingsStaticControl = "headerLabel";
        }
        #endregion
    }
}
