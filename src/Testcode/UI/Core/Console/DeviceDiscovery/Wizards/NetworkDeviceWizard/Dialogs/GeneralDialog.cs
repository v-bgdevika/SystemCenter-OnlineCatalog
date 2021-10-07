// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ComputerandDeviceManagementWizardDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//    Network Device Wizard dialogs
// </project>
// <summary>
//   Network Device Wizard dialogs - General Page
// </summary>
// <history>
//   [dialac] 4/13/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.NetworkDeviceWizard.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - IComputerandDeviceManagementWizardDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IComputerandDeviceManagementWizardDialogControls, for ComputerandDeviceManagementWizardDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [dialac] 4/13/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IComputerandDeviceManagementWizardDialogControls
    {
        /// <summary>
        /// Gets read-only property to access PreviousButton
        /// </summary>
        Button PreviousButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access NextButton
        /// </summary>
        Button NextButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access DiscoverButton
        /// </summary>
        Button DiscoverButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access DiscoveryTypeStaticControl
        /// </summary>
        StaticControl DiscoveryTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access GeneralPropertiesStaticControl
        /// </summary>
        StaticControl GeneralPropertiesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access DiscoveryMethodStaticControl
        /// </summary>
        StaticControl DiscoveryMethodStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access DefaultAccountsStaticControl
        /// </summary>
        StaticControl DefaultAccountsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access DevicesStaticControl
        /// </summary>
        StaticControl DevicesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ScheduleDiscoveryStaticControl
        /// </summary>
        StaticControl ScheduleDiscoveryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SummaryStaticControl
        /// </summary>
        StaticControl SummaryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access CompletionStaticControl
        /// </summary>
        StaticControl CompletionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access AvailableServersStaticControl
        /// </summary>
        StaticControl AvailableServersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access AvailableServersComboBox
        /// </summary>
        ComboBox AvailableServersComboBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access DescriptionOptionalTextBox
        /// </summary>
        TextBox DescriptionOptionalTextBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access NameTextBox
        /// </summary>
        TextBox NameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access HelpStaticControl
        /// </summary>
        StaticControl HelpStaticControl
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
    ///   [dialac] 4/13/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class GeneralDialog : Dialog, IComputerandDeviceManagementWizardDialogControls
    {
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
        /// Cache to hold a reference to DiscoverButton of type Button
        /// </summary>
        private Button cachedDiscoverButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to DiscoveryTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiscoveryTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to GeneralPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DiscoveryMethodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiscoveryMethodStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DefaultAccountsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDefaultAccountsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DevicesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDevicesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ScheduleDiscoveryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedScheduleDiscoveryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CompletionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCompletionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AvailableServersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAvailableServersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AvailableServersComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedAvailableServersComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DescriptionOptionalTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionOptionalTextBox;
        
        /// <summary>
        /// Cache to hold a reference to NameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        #endregion
        
        public static string CurrentWizardTitle=null;
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the ComputerandDeviceManagementWizardDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of ComputerandDeviceManagementWizardDialog of type MomConsoleApp
        /// </param>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public GeneralDialog(MomConsoleApp app, int timeout) : 
                base(app, Init(app, timeout))
        {
            // TODO: Add Constructor logic here. 
        }

        #endregion
        
        #region IComputerandDeviceManagementWizardDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IComputerandDeviceManagementWizardDialogControls Controls
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
        ///  Gets or sets the text in control AvailableServers
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AvailableServersText
        {
            get
            {
                return this.Controls.AvailableServersComboBox.Text;
            }
            
            set
            {
                this.Controls.AvailableServersComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control DescriptionOptional
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DescriptionOptionalText
        {
            get
            {
                return this.Controls.DescriptionOptionalTextBox.Text;
            }
            
            set
            {
                this.Controls.DescriptionOptionalTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [dialac] 4/13/2010 Created
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
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PreviousButton control
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IComputerandDeviceManagementWizardDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, GeneralDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NextButton control
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IComputerandDeviceManagementWizardDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, GeneralDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DiscoverButton control
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IComputerandDeviceManagementWizardDialogControls.DiscoverButton
        {
            get
            {
                if ((this.cachedDiscoverButton == null))
                {
                    this.cachedDiscoverButton = new Button(this, GeneralDialog.ControlIDs.DiscoverButton);
                }
                
                return this.cachedDiscoverButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IComputerandDeviceManagementWizardDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, GeneralDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DiscoveryTypeStaticControl control
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerandDeviceManagementWizardDialogControls.DiscoveryTypeStaticControl
        {
            get
            {
                if ((this.cachedDiscoveryTypeStaticControl == null))
                {
                    this.cachedDiscoveryTypeStaticControl = new StaticControl(this, GeneralDialog.ControlIDs.DiscoveryTypeStaticControl);
                }
                
                return this.cachedDiscoveryTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerandDeviceManagementWizardDialogControls.GeneralPropertiesStaticControl
        {
            get
            {
                // TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
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
        ///  Gets access to the DiscoveryMethodStaticControl control
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerandDeviceManagementWizardDialogControls.DiscoveryMethodStaticControl
        {
            get
            {
                // TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
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
        ///  Gets access to the DefaultAccountsStaticControl control
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerandDeviceManagementWizardDialogControls.DefaultAccountsStaticControl
        {
            get
            {
                // TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedDefaultAccountsStaticControl == null))
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
                    this.cachedDefaultAccountsStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedDefaultAccountsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DevicesStaticControl control
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerandDeviceManagementWizardDialogControls.DevicesStaticControl
        {
            get
            {
                // TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
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
                    for (i = 0; (i <= 3); i = (i + 1))
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
        ///  Gets access to the ScheduleDiscoveryStaticControl control
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerandDeviceManagementWizardDialogControls.ScheduleDiscoveryStaticControl
        {
            get
            {
                // TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedScheduleDiscoveryStaticControl == null))
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
                    this.cachedScheduleDiscoveryStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedScheduleDiscoveryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SummaryStaticControl control
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerandDeviceManagementWizardDialogControls.SummaryStaticControl
        {
            get
            {
                // TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
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
        ///  Gets access to the CompletionStaticControl control
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// <remarks>
        ///  TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
        ///  Investigate why and report a bug if necessary.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerandDeviceManagementWizardDialogControls.CompletionStaticControl
        {
            get
            {
                // TODO: The ID for this control (textLinkLabel) is used multiple times in this dialog.
                // Investigate why and report a bug if necessary.  The generated code follows the window
                // hierarchy path to find the control to work around this problem.
                if ((this.cachedCompletionStaticControl == null))
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
                    for (i = 0; (i <= 6); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedCompletionStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedCompletionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AvailableServersStaticControl control
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerandDeviceManagementWizardDialogControls.AvailableServersStaticControl
        {
            get
            {
                if ((this.cachedAvailableServersStaticControl == null))
                {
                    this.cachedAvailableServersStaticControl = new StaticControl(this, GeneralDialog.ControlIDs.AvailableServersStaticControl);
                }
                
                return this.cachedAvailableServersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AvailableServersComboBox control
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IComputerandDeviceManagementWizardDialogControls.AvailableServersComboBox
        {
            get
            {
                if ((this.cachedAvailableServersComboBox == null))
                {
                    this.cachedAvailableServersComboBox = new ComboBox(this, GeneralDialog.ControlIDs.AvailableServersComboBox);
                }
                
                return this.cachedAvailableServersComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DescriptionOptionalTextBox control
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IComputerandDeviceManagementWizardDialogControls.DescriptionOptionalTextBox
        {
            get
            {
                if ((this.cachedDescriptionOptionalTextBox == null))
                {
                    this.cachedDescriptionOptionalTextBox = new TextBox(this, GeneralDialog.ControlIDs.DescriptionOptionalTextBox);
                }
                
                return this.cachedDescriptionOptionalTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NameTextBox control
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IComputerandDeviceManagementWizardDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, GeneralDialog.ControlIDs.NameTextBox);
                }
                
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the HelpStaticControl control
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IComputerandDeviceManagementWizardDialogControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, GeneralDialog.ControlIDs.HelpStaticControl);
                }
                
                return this.cachedHelpStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
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
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickNext()
        {
            this.Controls.NextButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Discover
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickDiscover()
        {
            this.Controls.DiscoverButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
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
        /// <param name="app">MomConsoleApp owning the dialog.</param>
        /// <param name="timeout">timeout.</param>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app, int timeout)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                CurrentWizardTitle = Strings.DialogTitle;
                tempWindow = new Window(CurrentWizardTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, timeout);

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
                        //Wizard title is different with different entry:
                        //1. Title will be "Comprruter andDevice Management Wizard" if launch wizard from: Administration ->right click->Discovery Wizard
                        //2. Title will be "Network Device Discovery Wizard" if launch wizard from: Administration->Network Management->Discovery Rules ->Discover Netwrok Devices.
                        if (CurrentWizardTitle == Strings.DialogTitle)
                            CurrentWizardTitle = Strings.DialogTitle2;
                        else
                            CurrentWizardTitle = Strings.DialogTitle;
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(CurrentWizardTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);


                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(timeout);
                    }
                }

                // check for success
                if ((null == tempWindow))
                {
                    CurrentWizardTitle = null;
                    // log the failure

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }

            return tempWindow;
        }
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
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
            /// Control ID for DiscoverButton
            /// </summary>
            public const string DiscoverButton = "commitButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for DiscoveryTypeStaticControl
            /// </summary>
            public const string DiscoveryTypeStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DiscoveryMethodStaticControl
            /// </summary>
            public const string DiscoveryMethodStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DefaultAccountsStaticControl
            /// </summary>
            public const string DefaultAccountsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DevicesStaticControl
            /// </summary>
            public const string DevicesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ScheduleDiscoveryStaticControl
            /// </summary>
            public const string ScheduleDiscoveryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for CompletionStaticControl
            /// </summary>
            public const string CompletionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for AvailableServersStaticControl
            /// </summary>
            public const string AvailableServersStaticControl = "label3";
            
            /// <summary>
            /// Control ID for AvailableServersComboBox
            /// </summary>
            public const string AvailableServersComboBox = "serverDropdown";
            
            /// <summary>
            /// Control ID for DescriptionOptionalTextBox
            /// </summary>
            public const string DescriptionOptionalTextBox = "descriptionTextbox";
            
            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "nameTextbox";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Resource Strings for this dialog
        /// </summary>
        /// <history>
        ///   [dialac] 4/13/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title: Computer and Device Management Wizard
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Computer and Device Management Wizard;ManagedString;" +
    "Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;" +
    "DiscoveryWizardCaption";

            /// <summary>
            ///  Contains resource string for the window or dialog title:  Network Devices Discovery Wizard
            /// </summary>
            private const string ResourceDialogTitle2 = ";Network Devices Discovery Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;NDDWTitle";
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.Res" +
                "ources.dll;Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel.en" +
                ";previousButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.Resourc" +
                "es.dll;Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel.en;nex" +
                "tButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Discover
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Discover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;DiscoveryText
            /// ;Discover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;DiscoverActionText
            /// ;Discover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;DiscoveryText
            /// ;Discover;ManagedString;Microsoft.SystemCenter.CrossPlatform.UI.Administration.resources.dll;Microsoft.SystemCenter.CrossPlatform.UI.Administration.AdminResources;DiscoverActionText
            /// ;Discover;ManagedString;Microsoft.SystemCenter.CrossPlatform.UI.Administration.resources.dll;Microsoft.SystemCenter.CrossPlatform.UI.Administration.AdminResources;DiscoveryText
            /// </remark>
            private const string ResourceDiscover = ";&Discover;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resourc" +
                "es.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResour" +
                "ces;DiscoverActionText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources." +
                "dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.OKCancelForm;c" +
                "ancelBtn.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DiscoveryType
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Discovery Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseDiscoveryTypePage;pageSectionLabel.Text
            /// ;Discovery Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.AttributesView.AttributesViewResources;DiscoveryTypeColumn
            /// </remark>
            private const string ResourceDiscoveryType = ";Discovery Type;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.re" +
                "sources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Discov" +
                "eryTypeSelectionPage;$this.NavigationText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  GeneralProperties
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;General Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPInstall.RuleGeneralPage;$this.Title
            /// ;General Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;GeneralPropertyPageTabText
           /// </remark>
            private const string ResourceGeneralProperties = ";General Properties;ManagedString;Microsoft.EnterpriseManagement.UI.Administratio" +
                "n.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Ad" +
                "minResources;GeneralPropertyPageTabText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DiscoveryMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Discovery Method;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;DiscoveryMethodTitle
            /// ;Discovery Method;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;NDDWDiscoveryTypeTitle
            /// ;Discovery Method;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;DiscoveryMethodTitle
            /// ;Discovery Method;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Attribute.AttributeWizardResources;DiscoveryMethodNavigation
            /// ;Discovery Method;ManagedString;Microsoft.SystemCenter.CrossPlatform.UI.Administration.resources.dll;Microsoft.SystemCenter.CrossPlatform.UI.Administration.AdminResources;DiscoveryMethodTitle
            /// </remark>
            private const string ResourceDiscoveryMethod = ";Discovery Method;ManagedString;Microsoft.EnterpriseManagement.UI.Administration." +
                "resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Admi" +
                "nResources;NDDWDiscoveryTypeTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  DefaultAccounts
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Default Accounts;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;NDDWAccountsTitle
            /// </remark>
            private const string ResourceDefaultAccounts = ";Default Accounts;ManagedString;Microsoft.EnterpriseManagement.UI.Administration." +
                "resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Admi" +
                "nResources;NDDWAccountsTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Devices
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Devices;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;NDDWDevicesTitle
            /// ;Devices;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.NetworkDiscovery.Devices;>>$this.Name
            /// </remark>
            private const string ResourceDevices = ";Devices;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources" +
                ".dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResource" +
                "s;NDDWDevicesTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ScheduleDiscovery
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Schedule Discovery;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;NDDWScheduleTitle
            /// </remark>
            private const string ResourceScheduleDiscovery = ";Schedule Discovery;ManagedString;Microsoft.EnterpriseManagement.UI.Administratio" +
                "n.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Ad" +
                "minResources;NDDWScheduleTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;SummaryTitle
            /// ;Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;UserRoleFinishTitle
            /// ;Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.DiscoverySummary;labelSummaryTitle.Text
            /// ;Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;Summary
            /// ;Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;SummaryTitle
            /// ;Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;UserRoleFinishTitle
            /// ;Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.UserRoleFinish;labelTitle.Text
            /// </remark>
            private const string ResourceSummary = ";Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources" +
                ".dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResource" +
                "s;Summary";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Completion
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Completion;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ADRuleCompletionTitle
            /// ;Completion;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsProfileDistributionPage
            /// ;Completion;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsAccountCompletionTitle
            /// ;Completion;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;NDDWComplete
            /// ;Completion;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;ADRuleCompletionTitle
            /// ;Completion;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;RunAsProfileDistributionPage
            /// ;Completion;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;RunAsAccountCompletionTitle
            /// ;Completion;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.
            /// </remark>
            private const string ResourceCompletion = ";Completion;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resour" +
                "ces.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResou" +
                "rces;NDDWComplete";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AvailableServers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAvailableServers = ";Available &servers:;ManagedString;Microsoft.EnterpriseManagement.UI.Administrati" +
                "on.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.N" +
                "etworkDiscovery.General;label3.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            /// <remark>
            /// TODO: UIClassMaker found multiple instances of the resource, ensure you are using the correct one and delete the rest.
            /// ;Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ErrorTransmissionFilterForm;linkLabelHelp.Text
            /// ;Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPInstall.MPInstallDialog;helpButton.Text
            /// ;Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.RunAsProfile.AlternateAccount;linkLabelHelp.Text
            /// ;Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.ModifyAgent;linkLabelHelp.Text
            /// ;Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.ManualAgent;linkLabelHelp.Text
            /// ;Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.ChangeManagementServer;linkLabelHelp.Text
            /// ;Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.ChangeProxyAgent;linkLabelHelp.Text
            /// ;Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.AdminResources;HelpSubFolderName
            /// ;Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.Administration.Tiering.AddManagementGroupForm;linkLabelHelp.Text
            /// ;Help;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.resources.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Common.CommonResources;CommandHelp
            /// </remark>
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources.dl" +
                "l;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;H" +
                "elpSubFolderName";
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    Common.Utilities.LogMessage("String:" + ResourceDialogTitle);
                    string dialac = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    Common.Utilities.LogMessage("**** Resource:" + dialac );
                    return CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                }
            }

            public static string DialogTitle2
            {
                get
                {
                    Common.Utilities.LogMessage("String:" + ResourceDialogTitle2);
                    return CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle2);
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Previous translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Previous
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourcePrevious);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Next translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Next
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceNext);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Discover translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Discover
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceDiscover);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Cancel translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Cancel
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceCancel);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DiscoveryType translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiscoveryType
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceDiscoveryType);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the GeneralProperties translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string GeneralProperties
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceGeneralProperties);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DiscoveryMethod translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiscoveryMethod
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceDiscoveryMethod);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DefaultAccounts translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DefaultAccounts
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceDefaultAccounts);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Devices translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Devices
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceDevices);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the ScheduleDiscovery translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ScheduleDiscovery
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceScheduleDiscovery);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Summary translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Summary
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceSummary);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Completion translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Completion
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceCompletion);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the AvailableServers translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AvailableServers
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceAvailableServers);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Help translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/13/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Help
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceHelp);
                }
            }
            #endregion
        }
        #endregion
    }
}
