// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WindowsCredentialsWindow.cs">
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
//  [KellyMor] 05-Apr-06    Updated control names for Existing Account combo box
//  [KellyMor] 07-Jun-06    Updated resource assembly for new Admin assembly
//  [KellyMor] 15-Jun-06    Updated textbox control names
//  [KellyMor] 30-Jun-06    Changed WinformsID for ExistingUserAccountRadioButton
//                          Changed WinformsID for OtherUserAccountRadioButton
//  [KellyMor] 03-Aug-06    Added checkbox for 'Use Management Server Action Account...'
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - InstallAccountType

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group InstallAccountType
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum InstallAccountType
    {
        /// <summary>
        /// OtherUserAccount = 0
        /// </summary>
        OtherUserAccount = 0,
        
        /// <summary>
        /// ExistingUserAccount = 1
        /// </summary>
        ExistingUserAccount = 1,
    }
    #endregion
    
    #region Interface Definition - IWindowsCredentialsWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IWindowsCredentialsWindowControls, for WindowsCredentialsWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IWindowsCredentialsWindowControls
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
        /// Read-only property to access DiscoveryMethodStaticControl
        /// </summary>
        StaticControl DiscoveryMethodStaticControl
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
        /// Read-only property to access UserNameStaticControl
        /// </summary>
        StaticControl UserNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UserNameTextBox
        /// </summary>
        TextBox UserNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PasswordStaticControl
        /// </summary>
        StaticControl PasswordStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PasswordTextBox
        /// </summary>
        TextBox PasswordTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DomainStaticControl
        /// </summary>
        StaticControl DomainStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DomainEditComboBox
        /// </summary>
        EditComboBox DomainEditComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DomainTextBox
        /// </summary>
        TextBox DomainTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExistingAccountsComboBox
        /// </summary>
        ComboBox ExistingAccountsComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OtherUserAccountRadioButton
        /// </summary>
        RadioButton OtherUserAccountRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ExistingUserAccountRadioButton
        /// </summary>
        RadioButton ExistingUserAccountRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen
        /// </summary>
        StaticControl SelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AdministratorAccountStaticControl2
        /// </summary>
        StaticControl AdministratorAccountStaticControl2
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
        /// Read-only property to access AdministratorAccountStaticControl3
        /// </summary>
        StaticControl AdministratorAccountStaticControl3
        {
            get;
        }

        /// <summary>
        /// Read-only property to access UseServerActionAccountCheckBox
        /// </summary>
        CheckBox UseServerActionAccountCheckBox
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of "Administration Account" step in 
    /// the Computer and Device Management Wizard.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class WindowsCredentialsWindow : Window, IWindowsCredentialsWindowControls
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
        /// Cache to hold a reference to DiscoveryMethodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDiscoveryMethodStaticControl;
        
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
        /// Cache to hold a reference to UserNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedUserNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UserNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedUserNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to PasswordStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPasswordStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PasswordTextBox of type TextBox
        /// </summary>
        private TextBox cachedPasswordTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DomainStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDomainStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DomainEditComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedDomainEditComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DomainTextBox of type TextBox
        /// </summary>
        private TextBox cachedDomainTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ExistingAccountsComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedExistingAccountsComboBox;
        
        /// <summary>
        /// Cache to hold a reference to OtherUserAccountRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedOtherUserAccountRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to ExistingUserAccountRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedExistingUserAccountRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen of type StaticControl
        /// </summary>
        private StaticControl cachedSelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen;
        
        /// <summary>
        /// Cache to hold a reference to AdministratorAccountStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedAdministratorAccountStaticControl2;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AdministratorAccountStaticControl3 of type StaticControl
        /// </summary>
        private StaticControl cachedAdministratorAccountStaticControl3;

        /// <summary>
        /// Cache to hold a reference to UseServerActionAccountCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedUseServerActionAccountCheckBox;

        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of WindowsCredentialsWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public WindowsCredentialsWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group InstallAccountType
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual InstallAccountType InstallAccountType
        {
            get
            {
                if ((this.Controls.OtherUserAccountRadioButton.ButtonState == ButtonState.Checked))
                {
                    return InstallAccountType.OtherUserAccount;
                }
                
                if ((this.Controls.ExistingUserAccountRadioButton.ButtonState == ButtonState.Checked))
                {
                    return InstallAccountType.ExistingUserAccount;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == InstallAccountType.OtherUserAccount))
                {
                    this.Controls.OtherUserAccountRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == InstallAccountType.ExistingUserAccount))
                    {
                        this.Controls.ExistingUserAccountRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IWindowsCredentialsWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IWindowsCredentialsWindowControls Controls
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
        ///  Routine to set/get the text in control UserNameTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string UserNameTextBoxText
        {
            get
            {
                return this.Controls.UserNameTextBox.Text;
            }
            
            set
            {
                this.Controls.UserNameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control NoteYouCanConfigureHowTheseObjectsWillBeDiscoveredOnTheNextScreens
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PasswordText
        {
            get
            {
                return this.Controls.PasswordTextBox.Text;
            }
            
            set
            {
                this.Controls.PasswordTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Domain
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DomainText
        {
            get
            {
                return this.Controls.DomainEditComboBox.Text;
            }
            
            set
            {
                this.Controls.DomainEditComboBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Domain2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string Domain2Text
        {
            get
            {
                return this.Controls.DomainTextBox.Text;
            }
            
            set
            {
                this.Controls.DomainTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ExistingAccounts
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ExistingAccountsText
        {
            get
            {
                return this.Controls.ExistingAccountsComboBox.Text;
            }
            
            set
            {
                this.Controls.ExistingAccountsComboBox.SelectByText(value, true);
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
        Button IWindowsCredentialsWindowControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, WindowsCredentialsWindow.ControlIDs.PreviousButton);
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
        Button IWindowsCredentialsWindowControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, WindowsCredentialsWindow.ControlIDs.NextButton);
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
        Button IWindowsCredentialsWindowControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, WindowsCredentialsWindow.ControlIDs.FinishButton);
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
        Button IWindowsCredentialsWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, WindowsCredentialsWindow.ControlIDs.CancelButton);
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
        StaticControl IWindowsCredentialsWindowControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, WindowsCredentialsWindow.ControlIDs.IntroductionStaticControl);
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
        StaticControl IWindowsCredentialsWindowControls.AutoOrAdvancedStaticControl
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
        ///  Exposes access to the DiscoveryMethodStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsCredentialsWindowControls.DiscoveryMethodStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this window.
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
        ///  Exposes access to the AdministratorAccountStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsCredentialsWindowControls.AdministratorAccountStaticControl
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
                    for (i = 0; (i <= 2); i = (i + 1))
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
        StaticControl IWindowsCredentialsWindowControls.RunningDiscoveryStaticControl
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
                    for (i = 0; (i <= 3); i = (i + 1))
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
        StaticControl IWindowsCredentialsWindowControls.SelectObjectsToManageStaticControl
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
                    for (i = 0; (i <= 4); i = (i + 1))
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
        StaticControl IWindowsCredentialsWindowControls.SummaryStaticControl
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
        ///  Exposes access to the UserNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsCredentialsWindowControls.UserNameStaticControl
        {
            get
            {
                if ((this.cachedUserNameStaticControl == null))
                {
                    this.cachedUserNameStaticControl = new StaticControl(this, WindowsCredentialsWindow.ControlIDs.UserNameStaticControl);
                }
                return this.cachedUserNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserNameTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWindowsCredentialsWindowControls.UserNameTextBox
        {
            get
            {
                if ((this.cachedUserNameTextBox == null))
                {
                    this.cachedUserNameTextBox = new TextBox(this, WindowsCredentialsWindow.ControlIDs.UserNameTextBox);
                }
                return this.cachedUserNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PasswordStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsCredentialsWindowControls.PasswordStaticControl
        {
            get
            {
                if ((this.cachedPasswordStaticControl == null))
                {
                    this.cachedPasswordStaticControl = new StaticControl(this, WindowsCredentialsWindow.ControlIDs.PasswordStaticControl);
                }
                return this.cachedPasswordStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PasswordTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWindowsCredentialsWindowControls.PasswordTextBox
        {
            get
            {
                if ((this.cachedPasswordTextBox == null))
                {
                    this.cachedPasswordTextBox = new TextBox(this, WindowsCredentialsWindow.ControlIDs.PasswordTextBox);
                }
                return this.cachedPasswordTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsCredentialsWindowControls.DomainStaticControl
        {
            get
            {
                if ((this.cachedDomainStaticControl == null))
                {
                    this.cachedDomainStaticControl = new StaticControl(this, WindowsCredentialsWindow.ControlIDs.DomainStaticControl);
                }
                return this.cachedDomainStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainEditComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IWindowsCredentialsWindowControls.DomainEditComboBox
        {
            get
            {
                if ((this.cachedDomainEditComboBox == null))
                {
                    this.cachedDomainEditComboBox = new EditComboBox(this, WindowsCredentialsWindow.ControlIDs.DomainEditComboBox);
                }
                return this.cachedDomainEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWindowsCredentialsWindowControls.DomainTextBox
        {
            get
            {
                if ((this.cachedDomainTextBox == null))
                {
                    Window wndTemp = this;
                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 4); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedDomainTextBox = new TextBox(wndTemp);
                }
                return this.cachedDomainTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExistingAccountsComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IWindowsCredentialsWindowControls.ExistingAccountsComboBox
        {
            get
            {
                if ((this.cachedExistingAccountsComboBox == null))
                {
                    this.cachedExistingAccountsComboBox = new ComboBox(this, WindowsCredentialsWindow.ControlIDs.ExistingAccountsComboBox);
                }
                return this.cachedExistingAccountsComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OtherUserAccountRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IWindowsCredentialsWindowControls.OtherUserAccountRadioButton
        {
            get
            {
                if ((this.cachedOtherUserAccountRadioButton == null))
                {
                    this.cachedOtherUserAccountRadioButton = new RadioButton(this, WindowsCredentialsWindow.ControlIDs.OtherUserAccountRadioButton);
                }
                return this.cachedOtherUserAccountRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ExistingUserAccountRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IWindowsCredentialsWindowControls.ExistingUserAccountRadioButton
        {
            get
            {
                if ((this.cachedExistingUserAccountRadioButton == null))
                {
                    this.cachedExistingUserAccountRadioButton = new RadioButton(this, WindowsCredentialsWindow.ControlIDs.ExistingUserAccountRadioButton);
                }
                return this.cachedExistingUserAccountRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsCredentialsWindowControls.SelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen
        {
            get
            {
                if ((this.cachedSelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen == null))
                {
                    this.cachedSelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen = new StaticControl(this, WindowsCredentialsWindow.ControlIDs.SelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen);
                }
                return this.cachedSelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdministratorAccountStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsCredentialsWindowControls.AdministratorAccountStaticControl2
        {
            get
            {
                if ((this.cachedAdministratorAccountStaticControl2 == null))
                {
                    this.cachedAdministratorAccountStaticControl2 = new StaticControl(this, WindowsCredentialsWindow.ControlIDs.AdministratorAccountStaticControl2);
                }
                return this.cachedAdministratorAccountStaticControl2;
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
        StaticControl IWindowsCredentialsWindowControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, WindowsCredentialsWindow.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdministratorAccountStaticControl3 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IWindowsCredentialsWindowControls.AdministratorAccountStaticControl3
        {
            get
            {
                if ((this.cachedAdministratorAccountStaticControl3 == null))
                {
                    this.cachedAdministratorAccountStaticControl3 = new StaticControl(this, WindowsCredentialsWindow.ControlIDs.AdministratorAccountStaticControl3);
                }
                return this.cachedAdministratorAccountStaticControl3;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UseServerActionAccountCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 03-Aug-06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IWindowsCredentialsWindowControls.UseServerActionAccountCheckBox
        {
            get
            {
                if ((this.cachedUseServerActionAccountCheckBox == null))
                {
                    this.cachedUseServerActionAccountCheckBox = new CheckBox(this, WindowsCredentialsWindow.ControlIDs.UseServerActionAccountCheckBox);
                }
                return this.cachedUseServerActionAccountCheckBox;
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
        ///  <param name="ownerWindow">App class instance that owns this window.</param>)
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
            /// Contains resource string for:  DiscoveryMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDiscoveryMethod = ";Discovery Method;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microso" +
                "ft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Discove" +
                "ryMethodTitle";
            
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
            /// Contains resource string for:  UserName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUserName = ";&User name:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.En" +
                "terpriseManagement.Mom.Internal.UI.Administration.ConnectionAccount;userAccou" +
                "nt.UserCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Password
            /// </summary>
            /// -----------------------------------------------------------------------------
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Domain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDomain = ";&Domain:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enter" +
                "priseManagement.Mom.Internal.UI.Administration.ConnectionAccount;userAccount." +
                "DomainCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OtherUserAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOtherUserAccount = ";&Other user account (will not be saved);ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Co" +
                "nnectionAccount;radioButtonNew.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExistingUserAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExistingUserAccount = ";&Existing user account;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;M" +
                "icrosoft.EnterpriseManagement.Mom.Internal.UI.Administration.ConnectionAccount.e" +
                "n;radioButtonExisting.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen = @";Select a user account with Administrator rights on the computers you will scan. These credentials will also be used when installing the agents on managed computers.;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.ConnectionAccount;labelDescription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministratorAccount2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdministratorAccount2 = ";Administrator Account;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Co" +
                "nnectionAccountTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministratorAccount3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdministratorAccount3 = ";Administrator Account;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mi" +
                "crosoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;Co" +
                "nnectionAccountTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Action Account
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExistingActionAccount = "Action Account";

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
            /// Caches the translated resource string for:  DiscoveryMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDiscoveryMethod;
            
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
            /// Caches the translated resource string for:  UserName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUserName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Password
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPassword;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Domain
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDomain;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OtherUserAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOtherUserAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ExistingUserAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExistingUserAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministratorAccount2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministratorAccount2;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdministratorAccount3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministratorAccount3;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Action Account
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedExistingActionAccount;

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
            /// Exposes access to the DiscoveryMethod translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
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
            /// Exposes access to the UserName translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UserName
            {
                get
                {
                    if ((cachedUserName == null))
                    {
                        cachedUserName = CoreManager.MomConsole.GetIntlStr(ResourceUserName);
                    }
                    return cachedUserName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Password translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Password
            {
                get
                {
                    if ((cachedPassword == null))
                    {
                        cachedPassword = CoreManager.MomConsole.GetIntlStr(ResourcePassword);
                    }
                    return cachedPassword;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Domain translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Domain
            {
                get
                {
                    if ((cachedDomain == null))
                    {
                        cachedDomain = CoreManager.MomConsole.GetIntlStr(ResourceDomain);
                    }
                    return cachedDomain;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OtherUserAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OtherUserAccount
            {
                get
                {
                    if ((cachedOtherUserAccount == null))
                    {
                        cachedOtherUserAccount = CoreManager.MomConsole.GetIntlStr(ResourceOtherUserAccount);
                    }
                    return cachedOtherUserAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExistingUserAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExistingUserAccount
            {
                get
                {
                    if ((cachedExistingUserAccount == null))
                    {
                        cachedExistingUserAccount = CoreManager.MomConsole.GetIntlStr(ResourceExistingUserAccount);
                    }
                    return cachedExistingUserAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen
            {
                get
                {
                    if ((cachedSelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen == null))
                    {
                        cachedSelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen = CoreManager.MomConsole.GetIntlStr(ResourceSelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen);
                    }
                    return cachedSelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministratorAccount2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministratorAccount2
            {
                get
                {
                    if ((cachedAdministratorAccount2 == null))
                    {
                        cachedAdministratorAccount2 = CoreManager.MomConsole.GetIntlStr(ResourceAdministratorAccount2);
                    }
                    return cachedAdministratorAccount2;
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
            /// Exposes access to the AdministratorAccount3 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministratorAccount3
            {
                get
                {
                    if ((cachedAdministratorAccount3 == null))
                    {
                        cachedAdministratorAccount3 = CoreManager.MomConsole.GetIntlStr(ResourceAdministratorAccount3);
                    }
                    return cachedAdministratorAccount3;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Action Account translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExistingActionAccount
            {
                get
                {
                    if ((cachedExistingActionAccount == null))
                    {
                        cachedExistingActionAccount = CoreManager.MomConsole.GetIntlStr(ResourceExistingActionAccount);
                    }
                    return cachedExistingActionAccount;
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
            /// Control ID for DiscoveryMethodStaticControl
            /// </summary>
            public const string DiscoveryMethodStaticControl = "textLinkLabel";
            
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
            /// Control ID for UserNameStaticControl
            /// </summary>
            public const string UserNameStaticControl = "labelUser";
            
            /// <summary>
            /// Control ID for UserNameTextBox
            /// </summary>
            public const string UserNameTextBox = "textBoxUserName";
            
            /// <summary>
            /// Control ID for PasswordStaticControl
            /// </summary>
            public const string PasswordStaticControl = "labelPassword";
            
            /// <summary>
            /// Control ID for PasswordTextBox
            /// </summary>
            public const string PasswordTextBox = "textBoxPassword";
            
            /// <summary>
            /// Control ID for DomainStaticControl
            /// </summary>
            public const string DomainStaticControl = "labelDomain";
            
            /// <summary>
            /// Control ID for DomainEditComboBox
            /// </summary>
            public const string DomainEditComboBox = "comboBoxDomain";
            
            /// <summary>
            /// Control ID for ExistingAccountsComboBox
            /// </summary>
            public const string ExistingAccountsComboBox = "comboBoxExistingAccounts";
            
            /// <summary>
            /// Control ID for OtherUserAccountRadioButton
            /// </summary>
            public const string OtherUserAccountRadioButton = "radioButtonOtherAccount";
            
            /// <summary>
            /// Control ID for ExistingUserAccountRadioButton
            /// </summary>
            public const string ExistingUserAccountRadioButton = "radioButtonActionAccount";
            
            /// <summary>
            /// Control ID for SelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen
            /// </summary>
            public const string SelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen = "labelDescription";
            
            /// <summary>
            /// Control ID for AdministratorAccountStaticControl2
            /// </summary>
            public const string AdministratorAccountStaticControl2 = "labelTitle";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for AdministratorAccountStaticControl3
            /// </summary>
            public const string AdministratorAccountStaticControl3 = "headerLabel";

            /// <summary>
            /// Control ID for UseServerActionAccountCheckBox
            /// </summary>
            public const string UseServerActionAccountCheckBox = "checkBoxUseActionAccount";
        }
        #endregion
    }
}
