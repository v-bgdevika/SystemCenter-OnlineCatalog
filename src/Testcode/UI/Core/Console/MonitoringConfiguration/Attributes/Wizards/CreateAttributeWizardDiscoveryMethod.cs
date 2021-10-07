// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="CreateAttributeWizardDiscoveryMethod.cs">
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
    
    #region Interface Definition - ICreateAttributeWizardDiscoveryMethodControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ICreateAttributeWizardDiscoveryMethodControls, for CreateAttributeWizardDiscoveryMethod.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[visnara] 7/22/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ICreateAttributeWizardDiscoveryMethodControls
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
        /// Read-only property to access TargetStaticControl
        /// </summary>
        StaticControl TargetStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementPackStaticControl
        /// </summary>
        StaticControl ManagementPackStaticControl
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
        /// Read-only property to access TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd
        /// </summary>
        StaticControl TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NewButton
        /// </summary>
        Button NewButton
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
        /// Read-only property to access DiscoveryTypeStaticControl
        /// </summary>
        StaticControl DiscoveryTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access BrowseButton
        /// </summary>
        Button BrowseButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DiscoveryTypeComboBox
        /// </summary>
        ComboBox DiscoveryTypeComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChooseATargetAndDestinationManagementPackStaticControl
        /// </summary>
        StaticControl ChooseATargetAndDestinationManagementPackStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ChooseADiscoveryTypeStaticControl
        /// </summary>
        StaticControl ChooseADiscoveryTypeStaticControl
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
        /// Read-only property to access ChooseADiscoveryMethodStaticControl
        /// </summary>
        StaticControl ChooseADiscoveryMethodStaticControl
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
    public class CreateAttributeWizardDiscoveryMethod : Dialog, ICreateAttributeWizardDiscoveryMethodControls
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
        /// Cache to hold a reference to TargetStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTargetStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ManagementPackComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedManagementPackComboBox;
        
        /// <summary>
        /// Cache to hold a reference to TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd of type StaticControl
        /// </summary>
        private StaticControl cachedTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd;
        
        /// <summary>
        /// Cache to hold a reference to NewButton of type Button
        /// </summary>
        private Button cachedNewButton;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DiscoveryTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiscoveryTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to BrowseButton of type Button
        /// </summary>
        private Button cachedBrowseButton;
        
        /// <summary>
        /// Cache to hold a reference to DiscoveryTypeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedDiscoveryTypeComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ChooseATargetAndDestinationManagementPackStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChooseATargetAndDestinationManagementPackStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ChooseADiscoveryTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChooseADiscoveryTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ChooseADiscoveryMethodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChooseADiscoveryMethodStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of CreateAttributeWizardDiscoveryMethod of type Maui.Core.App
        /// </param>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public CreateAttributeWizardDiscoveryMethod(Maui.Core.App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ICreateAttributeWizardDiscoveryMethod Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ICreateAttributeWizardDiscoveryMethodControls Controls
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
        ///  Routine to set/get the text in control ManagementPack
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ManagementPackText
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
        ///  Routine to set/get the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DescriptionText
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
        ///  Routine to set/get the text in control DiscoveryType
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DiscoveryTypeText
        {
            get
            {
                return this.Controls.DiscoveryTypeComboBox.Text;
            }
            
            set
            {
                this.Controls.DiscoveryTypeComboBox.SelectByText(value);
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
        Button ICreateAttributeWizardDiscoveryMethodControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.PreviousButton);
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
        Button ICreateAttributeWizardDiscoveryMethodControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.NextButton);
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
        Button ICreateAttributeWizardDiscoveryMethodControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.FinishButton);
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
        Button ICreateAttributeWizardDiscoveryMethodControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.CancelButton);
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
        StaticControl ICreateAttributeWizardDiscoveryMethodControls.GeneralPropertiesStaticControl
        {
            get
            {
                if ((this.cachedGeneralPropertiesStaticControl == null))
                {
                    this.cachedGeneralPropertiesStaticControl = new StaticControl(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.GeneralPropertiesStaticControl);
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
        StaticControl ICreateAttributeWizardDiscoveryMethodControls.DiscoveryMethodStaticControl
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
        StaticControl ICreateAttributeWizardDiscoveryMethodControls.RegistryProbeConfigurationStaticControl
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
        ///  Exposes access to the TargetStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardDiscoveryMethodControls.TargetStaticControl
        {
            get
            {
                if ((this.cachedTargetStaticControl == null))
                {
                    this.cachedTargetStaticControl = new StaticControl(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.TargetStaticControl);
                }
                
                return this.cachedTargetStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardDiscoveryMethodControls.ManagementPackStaticControl
        {
            get
            {
                if ((this.cachedManagementPackStaticControl == null))
                {
                    this.cachedManagementPackStaticControl = new StaticControl(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.ManagementPackStaticControl);
                }
                
                return this.cachedManagementPackStaticControl;
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
        ComboBox ICreateAttributeWizardDiscoveryMethodControls.ManagementPackComboBox
        {
            get
            {
                if ((this.cachedManagementPackComboBox == null))
                {
                    this.cachedManagementPackComboBox = new ComboBox(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.ManagementPackComboBox);
                }
                
                return this.cachedManagementPackComboBox;
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
        StaticControl ICreateAttributeWizardDiscoveryMethodControls.TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd
        {
            get
            {
                if ((this.cachedTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd == null))
                {
                    this.cachedTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd = new StaticControl(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd);
                }
                
                return this.cachedTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NewButton control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateAttributeWizardDiscoveryMethodControls.NewButton
        {
            get
            {
                if ((this.cachedNewButton == null))
                {
                    this.cachedNewButton = new Button(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.NewButton);
                }
                
                return this.cachedNewButton;
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
        TextBox ICreateAttributeWizardDiscoveryMethodControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.DescriptionTextBox);
                }
                
                return this.cachedDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiscoveryTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardDiscoveryMethodControls.DiscoveryTypeStaticControl
        {
            get
            {
                if ((this.cachedDiscoveryTypeStaticControl == null))
                {
                    this.cachedDiscoveryTypeStaticControl = new StaticControl(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.DiscoveryTypeStaticControl);
                }
                
                return this.cachedDiscoveryTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the BrowseButton control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ICreateAttributeWizardDiscoveryMethodControls.BrowseButton
        {
            get
            {
                if ((this.cachedBrowseButton == null))
                {
                    this.cachedBrowseButton = new Button(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.BrowseButton);
                }
                
                return this.cachedBrowseButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DiscoveryTypeComboBox control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ICreateAttributeWizardDiscoveryMethodControls.DiscoveryTypeComboBox
        {
            get
            {
                if ((this.cachedDiscoveryTypeComboBox == null))
                {
                    this.cachedDiscoveryTypeComboBox = new ComboBox(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.DiscoveryTypeComboBox);
                }
                
                return this.cachedDiscoveryTypeComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChooseATargetAndDestinationManagementPackStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardDiscoveryMethodControls.ChooseATargetAndDestinationManagementPackStaticControl
        {
            get
            {
                if ((this.cachedChooseATargetAndDestinationManagementPackStaticControl == null))
                {
                    this.cachedChooseATargetAndDestinationManagementPackStaticControl = new StaticControl(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.ChooseATargetAndDestinationManagementPackStaticControl);
                }
                
                return this.cachedChooseATargetAndDestinationManagementPackStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChooseADiscoveryTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardDiscoveryMethodControls.ChooseADiscoveryTypeStaticControl
        {
            get
            {
                if ((this.cachedChooseADiscoveryTypeStaticControl == null))
                {
                    this.cachedChooseADiscoveryTypeStaticControl = new StaticControl(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.ChooseADiscoveryTypeStaticControl);
                }
                
                return this.cachedChooseADiscoveryTypeStaticControl;
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
        StaticControl ICreateAttributeWizardDiscoveryMethodControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ChooseADiscoveryMethodStaticControl control
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ICreateAttributeWizardDiscoveryMethodControls.ChooseADiscoveryMethodStaticControl
        {
            get
            {
                if ((this.cachedChooseADiscoveryMethodStaticControl == null))
                {
                    this.cachedChooseADiscoveryMethodStaticControl = new StaticControl(this, CreateAttributeWizardDiscoveryMethod.ControlIDs.ChooseADiscoveryMethodStaticControl);
                }
                
                return this.cachedChooseADiscoveryMethodStaticControl;
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
        ///  Routine to click on button New
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNew()
        {
            this.Controls.NewButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Browse
        /// </summary>
        /// <history>
        /// 	[visnara] 7/22/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickBrowse()
        {
            this.Controls.BrowseButton.Click();
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
            /// Contains resource string for:  RegistryProbeConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRegistryProbeConfiguration = ";Registry Probe Configuration;ManagedString;Microsoft.EnterpriseManagement.UI.Aut" +
                "horing.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.RegistryPr" +
                "obe.RegistryProbeStrings;TabName";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Target
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTarget = "Target : ";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ManagementPack
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceManagementPack = "Management Pack : ";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd = "The attribute cannot be directly added to the selected type because it belongs to" +
                " a Sealed Management Pack.\r\n\r\nIn order to add the attribute successfully, we wil" +
                "l create an extended version of the type which will be located in an unsealed Ma" +
                "nagement Pack.";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNew = ";New...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagem" +
                "ent.Mom.UI.AemDataCollectionDialog;collectFileNewButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DiscoveryType
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiscoveryType = "Discovery Type : ";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Browse
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceBrowse = "B&rowse...";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChooseATargetAndDestinationManagementPack
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceChooseATargetAndDestinationManagementPack = "Choose a target and destination Management Pack";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChooseADiscoveryType
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceChooseADiscoveryType = "Choose a discovery type";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.Ent" +
                "erpriseManagement.Internal.UI.Authoring.Common.CommonResources;CommandHelp";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChooseADiscoveryMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChooseADiscoveryMethod = ";Choose a Discovery method;ManagedString;Microsoft.EnterpriseManagement.UI.Author" +
                "ing.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Attribute.Att" +
                "ributeWizardResources;DiscoveryMethodTitle";
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
            /// Caches the translated resource string for:  Target
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTarget;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManagementPack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  New
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNew;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  DiscoveryType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiscoveryType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Browse
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedBrowse;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChooseATargetAndDestinationManagementPack
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChooseATargetAndDestinationManagementPack;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChooseADiscoveryType
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChooseADiscoveryType;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChooseADiscoveryMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChooseADiscoveryMethod;
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
            /// Exposes access to the Target translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Target
            {
                get
                {
                    if ((cachedTarget == null))
                    {
                        cachedTarget = CoreManager.MomConsole.GetIntlStr(ResourceTarget);
                    }
                    
                    return cachedTarget;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManagementPack
            {
                get
                {
                    if ((cachedManagementPack == null))
                    {
                        cachedManagementPack = CoreManager.MomConsole.GetIntlStr(ResourceManagementPack);
                    }
                    
                    return cachedManagementPack;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd
            {
                get
                {
                    if ((cachedTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd == null))
                    {
                        cachedTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd = CoreManager.MomConsole.GetIntlStr(ResourceTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd);
                    }
                    
                    return cachedTheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the New translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string New
            {
                get
                {
                    if ((cachedNew == null))
                    {
                        cachedNew = CoreManager.MomConsole.GetIntlStr(ResourceNew);
                    }
                    
                    return cachedNew;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DiscoveryType translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiscoveryType
            {
                get
                {
                    if ((cachedDiscoveryType == null))
                    {
                        cachedDiscoveryType = CoreManager.MomConsole.GetIntlStr(ResourceDiscoveryType);
                    }
                    
                    return cachedDiscoveryType;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Browse translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Browse
            {
                get
                {
                    if ((cachedBrowse == null))
                    {
                        cachedBrowse = CoreManager.MomConsole.GetIntlStr(ResourceBrowse);
                    }
                    
                    return cachedBrowse;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChooseATargetAndDestinationManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChooseATargetAndDestinationManagementPack
            {
                get
                {
                    if ((cachedChooseATargetAndDestinationManagementPack == null))
                    {
                        cachedChooseATargetAndDestinationManagementPack = CoreManager.MomConsole.GetIntlStr(ResourceChooseATargetAndDestinationManagementPack);
                    }
                    
                    return cachedChooseATargetAndDestinationManagementPack;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ChooseADiscoveryType translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChooseADiscoveryType
            {
                get
                {
                    if ((cachedChooseADiscoveryType == null))
                    {
                        cachedChooseADiscoveryType = CoreManager.MomConsole.GetIntlStr(ResourceChooseADiscoveryType);
                    }
                    
                    return cachedChooseADiscoveryType;
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
            /// Exposes access to the ChooseADiscoveryMethod translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 7/22/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChooseADiscoveryMethod
            {
                get
                {
                    if ((cachedChooseADiscoveryMethod == null))
                    {
                        cachedChooseADiscoveryMethod = CoreManager.MomConsole.GetIntlStr(ResourceChooseADiscoveryMethod);
                    }
                    
                    return cachedChooseADiscoveryMethod;
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
            /// Control ID for TargetStaticControl
            /// </summary>
            public const string TargetStaticControl = "targetLabel";
            
            /// <summary>
            /// Control ID for ManagementPackStaticControl
            /// </summary>
            public const string ManagementPackStaticControl = "mpLabel";
            
            /// <summary>
            /// Control ID for ManagementPackComboBox
            /// </summary>
            public const string ManagementPackComboBox = "mpCombobox";
            
            /// <summary>
            /// Control ID for TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd
            /// </summary>
            public const string TheAttributeCannotBeDirectlyAddedToTheSelectedTypeBecauseItBelongsToASealedManagementPackInOrderToAd = "infoLabel";
            
            /// <summary>
            /// Control ID for NewButton
            /// </summary>
            public const string NewButton = "newButton";
            
            /// <summary>
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "targetTextBox";
            
            /// <summary>
            /// Control ID for DiscoveryTypeStaticControl
            /// </summary>
            public const string DiscoveryTypeStaticControl = "label1";
            
            /// <summary>
            /// Control ID for BrowseButton
            /// </summary>
            public const string BrowseButton = "browseButton";
            
            /// <summary>
            /// Control ID for DiscoveryTypeComboBox
            /// </summary>
            public const string DiscoveryTypeComboBox = "discoveryMethodCombo";
            
            /// <summary>
            /// Control ID for ChooseATargetAndDestinationManagementPackStaticControl
            /// </summary>
            public const string ChooseATargetAndDestinationManagementPackStaticControl = "chooseTargetLabel";
            
            /// <summary>
            /// Control ID for ChooseADiscoveryTypeStaticControl
            /// </summary>
            public const string ChooseADiscoveryTypeStaticControl = "methodTypeLabel";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for ChooseADiscoveryMethodStaticControl
            /// </summary>
            public const string ChooseADiscoveryMethodStaticControl = "headerLabel";
        }
        #endregion
    }
}
