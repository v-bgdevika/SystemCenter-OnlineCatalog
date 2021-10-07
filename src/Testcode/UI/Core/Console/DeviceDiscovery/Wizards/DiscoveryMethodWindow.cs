// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DiscoveryMethodWindow.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[KellyMor] 03-Feb-06    Created
//  [KellyMor] 27-Feb-06    Updated resource strings
//  [KellyMor] 07-Jun-06    Updated resource assembly for new Admin assembly
//  [KellyMor] 04-Aug-06    Added controls for management servers/proxies combobox and
//                          'verify computers...' checkbox
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - DiscoveryMethod

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group DiscoveryMethod
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum DiscoveryMethod
    {
        /// <summary>
        /// AdvancedDiscovery = 0
        /// </summary>
        AdvancedDiscovery = 0,
        
        /// <summary>
        /// AutomatcDiscovery = 1
        /// </summary>
        AutomatcDiscovery = 1,
    }
    #endregion
    
    #region Interface Definition - IDiscoveryMethodWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IDiscoveryMethodWindowControls, for DiscoveryMethodWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDiscoveryMethodWindowControls
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
        /// Read-only property to access IntroductionStaticControl
        /// </summary>
        StaticControl IntroductionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AutoOrAdvancedStaticControl
        /// </summary>
        StaticControl AutoOrAdvancedStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AdministratorAccountStaticControl
        /// </summary>
        StaticControl AdministratorAccountStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RunningDiscoveryStaticControl
        /// </summary>
        StaticControl RunningDiscoveryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectObjectsToManageStaticControl
        /// </summary>
        StaticControl SelectObjectsToManageStaticControl
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
        /// Read-only property to access ChooseAutomaticOrAdvancedDiscoveryStaticControl
        /// </summary>
        StaticControl ChooseAutomaticOrAdvancedDiscoveryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComputerDeviceTypesStaticControl
        /// </summary>
        StaticControl ComputerDeviceTypesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access NoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreensStaticControl
        /// </summary>
        StaticControl NoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreensStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ComputerDeviceTypesComboBox
        /// </summary>
        ComboBox ComputerDeviceTypesComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettingsStaticControl
        /// </summary>
        StaticControl AllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettingsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ScansTheSMXDomainForAllWindowsBasedComputersStaticControl
        /// </summary>
        StaticControl ScansTheSMXDomainForAllWindowsBasedComputersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AdvancedDiscoveryRadioButton
        /// </summary>
        RadioButton AdvancedDiscoveryRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AutomatcDiscoveryRadioButton
        /// </summary>
        RadioButton AutomatcDiscoveryRadioButton
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
        /// Read-only property to access AutoOrAdvancedStaticControl2
        /// </summary>
        StaticControl AutoOrAdvancedStaticControl2
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ManagementServerComboBox
        /// </summary>
        ComboBox ManagementServerComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access VerifyComputersCheckBox
        /// </summary>
        CheckBox VerifyComputersCheckBox
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the Select Discovery Method step
    /// in the Computer and Device Management wizard.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class DiscoveryMethodWindow : Window, IDiscoveryMethodWindowControls
    {
        #region Protected Internal Variables

        /// <summary>
        /// Cache to hold a reference to the active window of type Maui.Core.Window
        /// </summary>
        protected internal static Window activeWindow;
        #endregion
        
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
        /// Cache to hold a reference to IntroductionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIntroductionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AutoOrAdvancedStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAutoOrAdvancedStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AdministratorAccountStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAdministratorAccountStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RunningDiscoveryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRunningDiscoveryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SelectObjectsToManageStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSelectObjectsToManageStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ChooseAutomaticOrAdvancedDiscoveryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedChooseAutomaticOrAdvancedDiscoveryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ComputerDeviceTypesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedComputerDeviceTypesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to NoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreensStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedNoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreensStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ComputerDeviceTypesComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedComputerDeviceTypesComboBox;
        
        /// <summary>
        /// Cache to hold a reference to AllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettingsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettingsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ScansTheSMXDomainForAllWindowsBasedComputersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedScansTheSMXDomainForAllWindowsBasedComputersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AdvancedDiscoveryRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAdvancedDiscoveryRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to AutomatcDiscoveryRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAutomatcDiscoveryRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AutoOrAdvancedStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedAutoOrAdvancedStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to ManagementServerComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedManagementServerComboBox;

        /// <summary>
        /// Cache to hold a reference to ManagementServerComboBox of type ComboBox
        /// </summary>
        private CheckBox cachedVerifyComputersCheckBox;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of DiscoveryMethodWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public DiscoveryMethodWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group DiscoveryMethod
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual DiscoveryMethod DiscoveryMethod
        {
            get
            {
                if ((this.Controls.AdvancedDiscoveryRadioButton.ButtonState == ButtonState.Checked))
                {
                    return DiscoveryMethod.AdvancedDiscovery;
                }
                
                if ((this.Controls.AutomatcDiscoveryRadioButton.ButtonState == ButtonState.Checked))
                {
                    return DiscoveryMethod.AutomatcDiscovery;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == DiscoveryMethod.AdvancedDiscovery))
                {
                    this.Controls.AdvancedDiscoveryRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == DiscoveryMethod.AutomatcDiscovery))
                    {
                        this.Controls.AutomatcDiscoveryRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IDiscoveryMethodWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IDiscoveryMethodWindowControls Controls
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
        ///  Routine to set/get the text in control ComputerDeviceTypes
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComputerDeviceTypesText
        {
            get
            {
                return this.Controls.ComputerDeviceTypesComboBox.Text;
            }
            
            set
            {
                this.Controls.ComputerDeviceTypesComboBox.SelectByText(value, true);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ManagementServer
        /// </summary>
        /// <value>Name of the management server (FQDN)</value>
        /// <history>
        /// 	[KellyMor] 04-Aug-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ManagementServerText
        {
            get
            {
                return this.Controls.ManagementServerComboBox.Text;
            }

            set
            {
                this.Controls.ManagementServerComboBox.SelectByText(value, true);
            }
        }

        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiscoveryMethodWindowControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, DiscoveryMethodWindow.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiscoveryMethodWindowControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, DiscoveryMethodWindow.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiscoveryMethodWindowControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, DiscoveryMethodWindow.ControlIDs.FinishButton);
                }
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IDiscoveryMethodWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, DiscoveryMethodWindow.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryMethodWindowControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, DiscoveryMethodWindow.ControlIDs.IntroductionStaticControl);
                }
                return this.cachedIntroductionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutoOrAdvancedStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryMethodWindowControls.AutoOrAdvancedStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAutoOrAdvancedStaticControl == null))
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
                    this.cachedAutoOrAdvancedStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedAutoOrAdvancedStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdministratorAccountStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryMethodWindowControls.AdministratorAccountStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedAdministratorAccountStaticControl == null))
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
                    this.cachedAdministratorAccountStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedAdministratorAccountStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RunningDiscoveryStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryMethodWindowControls.RunningDiscoveryStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedRunningDiscoveryStaticControl == null))
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
                    this.cachedRunningDiscoveryStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedRunningDiscoveryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectObjectsToManageStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryMethodWindowControls.SelectObjectsToManageStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedSelectObjectsToManageStaticControl == null))
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
                    this.cachedSelectObjectsToManageStaticControl = new StaticControl(wndTemp);
                }
                return this.cachedSelectObjectsToManageStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryMethodWindowControls.SummaryStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
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
                    for (i = 0; (i <= 4); i = (i + 1))
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
        ///  Exposes access to the ChooseAutomaticOrAdvancedDiscoveryStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryMethodWindowControls.ChooseAutomaticOrAdvancedDiscoveryStaticControl
        {
            get
            {
                if ((this.cachedChooseAutomaticOrAdvancedDiscoveryStaticControl == null))
                {
                    this.cachedChooseAutomaticOrAdvancedDiscoveryStaticControl = new StaticControl(this, DiscoveryMethodWindow.ControlIDs.ChooseAutomaticOrAdvancedDiscoveryStaticControl);
                }
                return this.cachedChooseAutomaticOrAdvancedDiscoveryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComputerDeviceTypesStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryMethodWindowControls.ComputerDeviceTypesStaticControl
        {
            get
            {
                if ((this.cachedComputerDeviceTypesStaticControl == null))
                {
                    this.cachedComputerDeviceTypesStaticControl = new StaticControl(this, DiscoveryMethodWindow.ControlIDs.ComputerDeviceTypesStaticControl);
                }
                return this.cachedComputerDeviceTypesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreensStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryMethodWindowControls.NoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreensStaticControl
        {
            get
            {
                if ((this.cachedNoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreensStaticControl == null))
                {
                    this.cachedNoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreensStaticControl = new StaticControl(this, DiscoveryMethodWindow.ControlIDs.NoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreensStaticControl);
                }
                return this.cachedNoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreensStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComputerDeviceTypesComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IDiscoveryMethodWindowControls.ComputerDeviceTypesComboBox
        {
            get
            {
                if ((this.cachedComputerDeviceTypesComboBox == null))
                {
                    this.cachedComputerDeviceTypesComboBox = new ComboBox(this, DiscoveryMethodWindow.ControlIDs.ComputerDeviceTypesComboBox);
                }
                return this.cachedComputerDeviceTypesComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettingsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryMethodWindowControls.AllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettingsStaticControl
        {
            get
            {
                if ((this.cachedAllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettingsStaticControl == null))
                {
                    this.cachedAllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettingsStaticControl = new StaticControl(this, DiscoveryMethodWindow.ControlIDs.AllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettingsStaticControl);
                }
                return this.cachedAllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettingsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ScansTheSMXDomainForAllWindowsBasedComputersStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryMethodWindowControls.ScansTheSMXDomainForAllWindowsBasedComputersStaticControl
        {
            get
            {
                if ((this.cachedScansTheSMXDomainForAllWindowsBasedComputersStaticControl == null))
                {
                    this.cachedScansTheSMXDomainForAllWindowsBasedComputersStaticControl = new StaticControl(this, DiscoveryMethodWindow.ControlIDs.ScansTheSMXDomainForAllWindowsBasedComputersStaticControl);
                }
                return this.cachedScansTheSMXDomainForAllWindowsBasedComputersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdvancedDiscoveryRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IDiscoveryMethodWindowControls.AdvancedDiscoveryRadioButton
        {
            get
            {
                if ((this.cachedAdvancedDiscoveryRadioButton == null))
                {
                    this.cachedAdvancedDiscoveryRadioButton = new RadioButton(this, DiscoveryMethodWindow.ControlIDs.AdvancedDiscoveryRadioButton);
                }
                return this.cachedAdvancedDiscoveryRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutomatcDiscoveryRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IDiscoveryMethodWindowControls.AutomatcDiscoveryRadioButton
        {
            get
            {
                if ((this.cachedAutomatcDiscoveryRadioButton == null))
                {
                    this.cachedAutomatcDiscoveryRadioButton = new RadioButton(this, DiscoveryMethodWindow.ControlIDs.AutomatcDiscoveryRadioButton);
                }
                return this.cachedAutomatcDiscoveryRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryMethodWindowControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, DiscoveryMethodWindow.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutoOrAdvancedStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IDiscoveryMethodWindowControls.AutoOrAdvancedStaticControl2
        {
            get
            {
                if ((this.cachedAutoOrAdvancedStaticControl2 == null))
                {
                    this.cachedAutoOrAdvancedStaticControl2 = new StaticControl(this, DiscoveryMethodWindow.ControlIDs.AutoOrAdvancedStaticControl2);
                }
                return this.cachedAutoOrAdvancedStaticControl2;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ManagementServerComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-Aug-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IDiscoveryMethodWindowControls.ManagementServerComboBox
        {
            get
            {
                if ((this.cachedManagementServerComboBox == null))
                {
                    this.cachedManagementServerComboBox =
                        new ComboBox(
                            this,
                            DiscoveryMethodWindow.ControlIDs.ManagementServerComboBox,
                            true,
                            DiscoveryMethodWindow.Timeout);
                }
                return this.cachedManagementServerComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the VerifyComputersCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 04-Aug-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IDiscoveryMethodWindowControls.VerifyComputersCheckBox
        {
            get
            {
                if ((this.cachedVerifyComputersCheckBox == null))
                {
                    this.cachedVerifyComputersCheckBox =
                        new CheckBox(
                            this,
                            DiscoveryMethodWindow.ControlIDs.VerifyComputersCheckBox,
                            true,
                            DiscoveryMethodWindow.Timeout);
                }
                return this.cachedVerifyComputersCheckBox;
            }
        }

        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
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
        /// 	[KellyMor] 2/3/2006 Created
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
        /// 	[KellyMor] 2/3/2006 Created
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
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>A System.IntPtr representing a handle to the window.</returns>
        /// <param name="ownerWindow">App class instance that owns this window.</param>)
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static System.IntPtr Init(App ownerWindow)
        {
            // First check if the window is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a window
                tempWindow = new Window(
                    Strings.WindowTitle + "*",
                    StringMatchSyntax.WildCard);
            }
            catch (Exceptions.WindowNotFoundException ex)
            {
                // try again with wildcards in the title
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
                                Strings.WindowTitle + "*",
                                StringMatchSyntax.WildCard);

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

                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                        Strings.WindowTitle + "'");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow.Extended.HWnd;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Contains resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
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
            private const string ResourceWindowTitle = ";Computer and Device Management Wizard;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;" +
                "DiscoveryWizardCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.PageFramework.WizardButtonsPanel;previousButto" +
                "n.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Finish
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceFinish = ";&Finish;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.Enterprise" +
                "Management.Mom.Internal.UI.PageFrameworks.WizardFramework;buttonFinish.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.PageFrameworks.WizardFramework;buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction = ";Introduction;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.E" +
                "nterpriseManagement.Mom.Internal.UI.Administration.AdminResources;WelcomeTitl" +
                "e";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutoOrAdvanced
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutoOrAdvanced = ";Auto or Advanced?;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Micros" +
                "oft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Discov" +
                "eryModeTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministratorAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdministratorAccount = ";Administrator Account;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Co" +
                "nnectionAccountTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RunningDiscovery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRunningDiscovery = ";Running Discovery...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mic" +
                "rosoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Dis" +
                "coveryProgressTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectObjectsToManage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectObjectsToManage = ";Select Objects to Manage;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources.en" +
                ";DiscoveryResultsTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary = ";Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.Administration.AdminResources;SummaryTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ChooseAutomaticOrAdvancedDiscovery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceChooseAutomaticOrAdvancedDiscovery = ";Choose automatic or advanced discovery;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Dis" +
                "coveryMode;labelTitle.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ComputerDeviceTypes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceComputerDeviceTypes = ";Computer && Device Types:;ManagedString;Microsoft.MOM.UI.Components.resources.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.DiscoveryMode.en" +
                ";labelTypes.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreens
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreens = ";Note: You can configure how these objects will be discovered, on the next screen" +
                "(s).;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpris" +
                "eManagement.Mom.Internal.UI.Administration.DiscoveryMode;labelNote.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettings = ";Allows you to specify advanced discovery options and settings.;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Intern" +
                "al.UI.Administration.DiscoveryMode;labelAdvanced.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ScansTheSMXDomainForAllWindowsBasedComputers
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceScansTheSMXDomainForAllWindowsBasedComputers = "Scans the \"SMX\" domain for all Windows-based computers.";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdvancedDiscovery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdvancedDiscovery = ";&Advanced discovery;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.DiscoveryMode;radio" +
                "ButtonAdvanced.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutomatcDiscovery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutomatcDiscovery = ";A&utomatc discovery;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.DiscoveryMode;radio" +
                "ButtonAutomatic.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AutoOrAdvanced2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAutoOrAdvanced2 = ";Auto or Advanced?;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Discov" +
                "eryModeTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Servers and Clients
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServersAndClients = ";Servers & Clients;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AdvancedDiscoveryType1";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Servers Only
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServersOnly = ";Servers Only;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AdvancedDiscoveryType2";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Clients Only
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceClientsOnly = ";Clients Only;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AdvancedDiscoveryType3";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Network Devices
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNetworkDevices = ";Network Devices;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AdvancedDiscoveryType4";

            #endregion
            
            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowTitle;
            
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
            /// Caches the translated resource string for:  Introduction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIntroduction;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AutoOrAdvanced
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutoOrAdvanced;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministratorAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministratorAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RunningDiscovery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunningDiscovery;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectObjectsToManage
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectObjectsToManage;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ChooseAutomaticOrAdvancedDiscovery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedChooseAutomaticOrAdvancedDiscovery;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ComputerDeviceTypes
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedComputerDeviceTypes;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreens
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreens;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettings
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettings;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ScansTheSMXDomainForAllWindowsBasedComputers
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedScansTheSMXDomainForAllWindowsBasedComputers;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdvancedDiscovery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdvancedDiscovery;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AutomatcDiscovery
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutomatcDiscovery;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AutoOrAdvanced2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAutoOrAdvanced2;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Servers and Clients
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServersAndClients;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Servers Only
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServersOnly;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Clients Only
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedClientsOnly;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Network Devices
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNetworkDevices;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowTitle
            {
                get
                {
                    if ((cachedWindowTitle == null))
                    {
                        cachedWindowTitle = CoreManager.MomConsole.GetIntlStr(ResourceWindowTitle);
                    }
                    return cachedWindowTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Previous translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
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
            /// 	[KellyMor] 2/3/2006 Created
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
            /// 	[KellyMor] 2/3/2006 Created
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
            /// 	[KellyMor] 2/3/2006 Created
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
            /// Exposes access to the Introduction translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Introduction
            {
                get
                {
                    if ((cachedIntroduction == null))
                    {
                        cachedIntroduction = CoreManager.MomConsole.GetIntlStr(ResourceIntroduction);
                    }
                    return cachedIntroduction;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AutoOrAdvanced translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutoOrAdvanced
            {
                get
                {
                    if ((cachedAutoOrAdvanced == null))
                    {
                        cachedAutoOrAdvanced = CoreManager.MomConsole.GetIntlStr(ResourceAutoOrAdvanced);
                    }
                    return cachedAutoOrAdvanced;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministratorAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministratorAccount
            {
                get
                {
                    if ((cachedAdministratorAccount == null))
                    {
                        cachedAdministratorAccount = CoreManager.MomConsole.GetIntlStr(ResourceAdministratorAccount);
                    }
                    return cachedAdministratorAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RunningDiscovery translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunningDiscovery
            {
                get
                {
                    if ((cachedRunningDiscovery == null))
                    {
                        cachedRunningDiscovery = CoreManager.MomConsole.GetIntlStr(ResourceRunningDiscovery);
                    }
                    return cachedRunningDiscovery;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectObjectsToManage translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectObjectsToManage
            {
                get
                {
                    if ((cachedSelectObjectsToManage == null))
                    {
                        cachedSelectObjectsToManage = CoreManager.MomConsole.GetIntlStr(ResourceSelectObjectsToManage);
                    }
                    return cachedSelectObjectsToManage;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Summary translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
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
            /// Exposes access to the ChooseAutomaticOrAdvancedDiscovery translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChooseAutomaticOrAdvancedDiscovery
            {
                get
                {
                    if ((cachedChooseAutomaticOrAdvancedDiscovery == null))
                    {
                        cachedChooseAutomaticOrAdvancedDiscovery = CoreManager.MomConsole.GetIntlStr(ResourceChooseAutomaticOrAdvancedDiscovery);
                    }
                    return cachedChooseAutomaticOrAdvancedDiscovery;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ComputerDeviceTypes translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ComputerDeviceTypes
            {
                get
                {
                    if ((cachedComputerDeviceTypes == null))
                    {
                        cachedComputerDeviceTypes = CoreManager.MomConsole.GetIntlStr(ResourceComputerDeviceTypes);
                    }
                    return cachedComputerDeviceTypes;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreens translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreens
            {
                get
                {
                    if ((cachedNoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreens == null))
                    {
                        cachedNoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreens = CoreManager.MomConsole.GetIntlStr(ResourceNoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreens);
                    }
                    return cachedNoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreens;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettings translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettings
            {
                get
                {
                    if ((cachedAllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettings == null))
                    {
                        cachedAllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettings = CoreManager.MomConsole.GetIntlStr(ResourceAllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettings);
                    }
                    return cachedAllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettings;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ScansTheSMXDomainForAllWindowsBasedComputers translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ScansTheSMXDomainForAllWindowsBasedComputers
            {
                get
                {
                    if ((cachedScansTheSMXDomainForAllWindowsBasedComputers == null))
                    {
                        cachedScansTheSMXDomainForAllWindowsBasedComputers = CoreManager.MomConsole.GetIntlStr(ResourceScansTheSMXDomainForAllWindowsBasedComputers);
                    }
                    return cachedScansTheSMXDomainForAllWindowsBasedComputers;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdvancedDiscovery translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdvancedDiscovery
            {
                get
                {
                    if ((cachedAdvancedDiscovery == null))
                    {
                        cachedAdvancedDiscovery = CoreManager.MomConsole.GetIntlStr(ResourceAdvancedDiscovery);
                    }
                    return cachedAdvancedDiscovery;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AutomatcDiscovery translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutomatcDiscovery
            {
                get
                {
                    if ((cachedAutomatcDiscovery == null))
                    {
                        cachedAutomatcDiscovery = CoreManager.MomConsole.GetIntlStr(ResourceAutomatcDiscovery);
                    }
                    return cachedAutomatcDiscovery;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
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
            /// Exposes access to the AutoOrAdvanced2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AutoOrAdvanced2
            {
                get
                {
                    if ((cachedAutoOrAdvanced2 == null))
                    {
                        cachedAutoOrAdvanced2 = CoreManager.MomConsole.GetIntlStr(ResourceAutoOrAdvanced2);
                    }
                    return cachedAutoOrAdvanced2;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Servers and Clients translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServersAndClients
            {
                get
                {
                    if ((cachedServersAndClients == null))
                    {
                        cachedServersAndClients = CoreManager.MomConsole.GetIntlStr(ResourceServersAndClients);
                    }
                    return cachedServersAndClients;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Servers Only translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ServersOnly
            {
                get
                {
                    if ((cachedServersOnly == null))
                    {
                        cachedServersOnly = CoreManager.MomConsole.GetIntlStr(ResourceServersOnly);
                    }
                    return cachedServersOnly;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Clients Only translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ClientsOnly
            {
                get
                {
                    if ((cachedClientsOnly == null))
                    {
                        cachedClientsOnly = CoreManager.MomConsole.GetIntlStr(ResourceClientsOnly);
                    }
                    return cachedClientsOnly;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Network Devices translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NetworkDevices
            {
                get
                {
                    if ((cachedNetworkDevices == null))
                    {
                        cachedNetworkDevices = CoreManager.MomConsole.GetIntlStr(ResourceNetworkDevices);
                    }
                    return cachedNetworkDevices;
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
        /// 	[KellyMor] 2/3/2006 Created
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
            /// Control ID for IntroductionStaticControl
            /// </summary>
            public const string IntroductionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for AutoOrAdvancedStaticControl
            /// </summary>
            public const string AutoOrAdvancedStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for AdministratorAccountStaticControl
            /// </summary>
            public const string AdministratorAccountStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for RunningDiscoveryStaticControl
            /// </summary>
            public const string RunningDiscoveryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SelectObjectsToManageStaticControl
            /// </summary>
            public const string SelectObjectsToManageStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl
            /// </summary>
            public const string SummaryStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ChooseAutomaticOrAdvancedDiscoveryStaticControl
            /// </summary>
            public const string ChooseAutomaticOrAdvancedDiscoveryStaticControl = "labelTitle";
            
            /// <summary>
            /// Control ID for ComputerDeviceTypesStaticControl
            /// </summary>
            public const string ComputerDeviceTypesStaticControl = "labelTypes";
            
            /// <summary>
            /// Control ID for NoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreensStaticControl
            /// </summary>
            public const string NoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreensStaticControl = "labelNote";
            
            /// <summary>
            /// Control ID for ComputerDeviceTypesComboBox
            /// </summary>
            public const string ComputerDeviceTypesComboBox = "comboBoxComputerType";
            
            /// <summary>
            /// Control ID for AllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettingsStaticControl
            /// </summary>
            public const string AllowsYouToSpecifyAdvancedDiscoveryOptionsAndSettingsStaticControl = "labelAdvanced";
            
            /// <summary>
            /// Control ID for ScansTheSMXDomainForAllWindowsBasedComputersStaticControl
            /// </summary>
            public const string ScansTheSMXDomainForAllWindowsBasedComputersStaticControl = "labelAutomatic";
            
            /// <summary>
            /// Control ID for AdvancedDiscoveryRadioButton
            /// </summary>
            public const string AdvancedDiscoveryRadioButton = "radioButtonAdvanced";
            
            /// <summary>
            /// Control ID for AutomatcDiscoveryRadioButton
            /// </summary>
            public const string AutomatcDiscoveryRadioButton = "radioButtonAutomatic";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for AutoOrAdvancedStaticControl2
            /// </summary>
            public const string AutoOrAdvancedStaticControl2 = "headerLabel";

            /// <summary>
            /// Control ID for ManagementServerComboBox
            /// </summary>
            public const string ManagementServerComboBox = "comboBoxProxy";

            /// <summary>
            /// Control ID for VerifyComputersCheckBox
            /// </summary>
            public const string VerifyComputersCheckBox = "checkBoxVerify";
        }
        #endregion
    }
}
