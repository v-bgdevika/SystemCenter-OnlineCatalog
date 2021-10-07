// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AgentUninstallWizardWindow.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[KellyMor] 2/3/2006 Created
//  [KellyMor] 07-Jun-06    Updated resource assembly for new Admin assembly
//  [KellyMor] 30-Jun-06    Changed WinformsID for 
//                          ExistingUserAccountRadioButton
//                          Changed WinformsID for OtherUserAccountRadioButton
//  [KellyMor]  07-Apr-08   Modified constructor, Init, and strings to allow
//                          reuse of dialog controls for "Repair Agents".
//                          Added new enumeration and interfaces to allow reuse
//                          of dialog.
//  [KellyMor]  18-SEP-08   Updated control ID's for commit and cancel buttons.
//                          Added checkbox control for using local computer
//                          accounts for agent actions.
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Enumerations

    #region Radio Group Enumeration - ActionAccountType

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group ActionAccountType
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum ActionAccountType
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

    #region Enumeration - AgentActionType

    /// <summary>
    /// Enum for window title resource string
    /// </summary>
    public enum AgentActionType
    {
        /// <summary>
        /// Uninstall Agents
        /// </summary>
        Uninstall = 0,

        /// <summary>
        /// RepairAgents
        /// </summary>
        Repair = 1,
    }

    #endregion

    #endregion

    #region Interface Definitions

    #region Interface Definition - IAgentActionWizardCommonWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAgentActionWizardCommonWindowControls, for AgentUninstallWizardWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAgentActionWizardCommonWindowControls
    {
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }

        /// <summary>
        /// Read-only property to access HelpButton
        /// </summary>
        Button HelpButton
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
        /// Read-only property to access AdministratorAccountStaticControl
        /// </summary>
        StaticControl AdministratorAccountStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access LocalComputerAccountCheckBox
        /// </summary>
        CheckBox LocalComputerAccountCheckBox
        {
            get;
        }
    }

    #endregion

    #region Interface Definition - IUninstallAgentsWizardWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition for IUninstallAgentsWizardWindowControls.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 07-Apr-08 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IUninstallAgentsWizardWindowControls
    {
        /// <summary>
        /// Read-only property to access UninstallButton
        /// </summary>
        Button UninstallButton
        {
            get;
        }
    }

    #endregion

    #region Interface Definition - IRepairAgentsWizardWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition for IRepairAgentsWizardWindowControls.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 07-Apr-08 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IRepairAgentsWizardWindowControls
    {
        /// <summary>
        /// Read-only property to access UninstallButton
        /// </summary>
        Button RepairButton
        {
            get;
        }
    }

    #endregion

    #endregion

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the agent uninstall wizard.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/3/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class AgentUninstallWizardWindow : 
        Window, 
        IAgentActionWizardCommonWindowControls, 
        IUninstallAgentsWizardWindowControls, 
        IRepairAgentsWizardWindowControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion
        
        #region Private Static Variables

        /// <summary>
        /// Cache to hold a reference to the active window of type Maui.Core.Window
        /// </summary>
        private static Window activeWindow;

        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to UninstallButton of type Button
        /// </summary>
        private Button cachedUninstallButton;
        
        /// <summary>
        /// Cache to hold a reference to RepairButton of type Button
        /// </summary>
        private Button cachedRepairButton;

        /// <summary>
        /// Cache to hold a reference to HelpButton of type Button
        /// </summary>
        private Button cachedHelpButton;
        
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
        /// Cache to hold a reference to ComboBox0 of type ComboBox
        /// </summary>
        private ComboBox cachedComboBox0;
        
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
        /// Cache to hold a reference to AdministratorAccountStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAdministratorAccountStaticControl;

        /// <summary>
        /// Cache to hold a reference to LocalComputerAccountCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedLocalComputerAccountCheckBox;

        #endregion
        
        #region Constructors

        /// -------------------------------------------------------------------
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of AgentUninstallWizardWindow of type App
        /// </param>
        /// <param name="agentAction">
        /// Agent action type:  uninstall or repair
        /// </param>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -------------------------------------------------------------------
        public AgentUninstallWizardWindow(App ownerWindow, AgentActionType agentAction)
            :
                base(Init(ownerWindow, agentAction))
        {
            AgentUninstallWizardWindow.activeWindow = this.Extended.AccessibleObject.Window;
        }

        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group ActionAccountType
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ActionAccountType ActionAccountType
        {
            get
            {
                if ((this.CommonControls.OtherUserAccountRadioButton.ButtonState == ButtonState.Checked))
                {
                    return ActionAccountType.OtherUserAccount;
                }

                if ((this.CommonControls.ExistingUserAccountRadioButton.ButtonState == ButtonState.Checked))
                {
                    return ActionAccountType.ExistingUserAccount;
                }

                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == ActionAccountType.OtherUserAccount))
                {
                    this.CommonControls.OtherUserAccountRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == ActionAccountType.ExistingUserAccount))
                    {
                        this.CommonControls.ExistingUserAccountRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }

        #endregion

        #region Interface Controls Properties

        #region IAgentActionWizardCommonWindowControls CommonControls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the common controls for this window
        /// </summary>
        /// <value>
        /// An interface that groups all of the window's common control properties 
        /// together
        /// </value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAgentActionWizardCommonWindowControls CommonControls
        {
            get
            {
                return this;
            }
        }

        #endregion

        #region IAgentUninstallWizardWindow UninstallControls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the uninstall controls for this window
        /// </summary>
        /// <value>
        /// An interface that groups all of the window's "Uninstall" control properties 
        /// together
        /// </value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IUninstallAgentsWizardWindowControls UninstallControls
        {
            get
            {
                return this;
            }
        }

        #endregion

        #region IRepairAgentsWizardWindowControls

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the repair controls for this window
        /// </summary>
        /// <value>
        /// An interface that groups all of the window's "Uninstall" control properties 
        /// together
        /// </value>
        /// <history>
        /// 	[KellyMor] 07-Apr-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IRepairAgentsWizardWindowControls RepairControls
        {
            get
            {
                return this;
            }
        }

        #endregion

        #endregion

        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control UserName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string UserNameText
        {
            get
            {
                return this.CommonControls.UserNameTextBox.Text;
            }
            
            set
            {
                this.CommonControls.UserNameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Password
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
                return this.CommonControls.PasswordTextBox.Text;
            }
            
            set
            {
                this.CommonControls.PasswordTextBox.Text = value;
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
                return this.CommonControls.DomainEditComboBox.Text;
            }
            
            set
            {
                this.CommonControls.DomainEditComboBox.Text = value;
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
                return this.CommonControls.DomainTextBox.Text;
            }
            
            set
            {
                this.CommonControls.DomainTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ComboBox0
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ComboBox0Text
        {
            get
            {
                return this.CommonControls.ComboBox0.Text;
            }
            
            set
            {
                this.CommonControls.ComboBox0.SelectByText(value, true);
            }
        }

        #endregion
        
        #region Control Properties

        #region IAgentActionWizardCommonWindowControls Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAgentActionWizardCommonWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AgentUninstallWizardWindow.ControlIDs.CancelButton);
                }

                return this.cachedCancelButton;
            }
        }
       
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAgentActionWizardCommonWindowControls.HelpButton
        {
            get
            {
                if ((this.cachedHelpButton == null))
                {
                    this.cachedHelpButton = new Button(this, AgentUninstallWizardWindow.ControlIDs.HelpButton);
                }

                return this.cachedHelpButton;
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
        StaticControl IAgentActionWizardCommonWindowControls.UserNameStaticControl
        {
            get
            {
                if ((this.cachedUserNameStaticControl == null))
                {
                    this.cachedUserNameStaticControl = new StaticControl(this, AgentUninstallWizardWindow.ControlIDs.UserNameStaticControl);
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
        TextBox IAgentActionWizardCommonWindowControls.UserNameTextBox
        {
            get
            {
                if ((this.cachedUserNameTextBox == null))
                {
                    this.cachedUserNameTextBox = new TextBox(this, AgentUninstallWizardWindow.ControlIDs.UserNameTextBox);
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
        StaticControl IAgentActionWizardCommonWindowControls.PasswordStaticControl
        {
            get
            {
                if ((this.cachedPasswordStaticControl == null))
                {
                    this.cachedPasswordStaticControl = new StaticControl(this, AgentUninstallWizardWindow.ControlIDs.PasswordStaticControl);
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
        TextBox IAgentActionWizardCommonWindowControls.PasswordTextBox
        {
            get
            {
                if ((this.cachedPasswordTextBox == null))
                {
                    this.cachedPasswordTextBox = new TextBox(this, AgentUninstallWizardWindow.ControlIDs.PasswordTextBox);
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
        StaticControl IAgentActionWizardCommonWindowControls.DomainStaticControl
        {
            get
            {
                if ((this.cachedDomainStaticControl == null))
                {
                    this.cachedDomainStaticControl = new StaticControl(this, AgentUninstallWizardWindow.ControlIDs.DomainStaticControl);
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
        EditComboBox IAgentActionWizardCommonWindowControls.DomainEditComboBox
        {
            get
            {
                if ((this.cachedDomainEditComboBox == null))
                {
                    this.cachedDomainEditComboBox = new EditComboBox(this, AgentUninstallWizardWindow.ControlIDs.DomainEditComboBox);
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
        TextBox IAgentActionWizardCommonWindowControls.DomainTextBox
        {
            get
            {
                if ((this.cachedDomainTextBox == null))
                {
                    Window wndTemp = this;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 3); i = (i + 1))
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
                    this.cachedDomainTextBox = new TextBox(wndTemp);
                }

                return this.cachedDomainTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ComboBox0 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAgentActionWizardCommonWindowControls.ComboBox0
        {
            get
            {
                if ((this.cachedComboBox0 == null))
                {
                    this.cachedComboBox0 = new ComboBox(this, AgentUninstallWizardWindow.ControlIDs.ComboBox0);
                }

                return this.cachedComboBox0;
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
        RadioButton IAgentActionWizardCommonWindowControls.OtherUserAccountRadioButton
        {
            get
            {
                if ((this.cachedOtherUserAccountRadioButton == null))
                {
                    this.cachedOtherUserAccountRadioButton = new RadioButton(this, AgentUninstallWizardWindow.ControlIDs.OtherUserAccountRadioButton);
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
        RadioButton IAgentActionWizardCommonWindowControls.ExistingUserAccountRadioButton
        {
            get
            {
                if ((this.cachedExistingUserAccountRadioButton == null))
                {
                    this.cachedExistingUserAccountRadioButton = new RadioButton(this, AgentUninstallWizardWindow.ControlIDs.ExistingUserAccountRadioButton);
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
        StaticControl IAgentActionWizardCommonWindowControls.SelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen
        {
            get
            {
                if ((this.cachedSelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen == null))
                {
                    this.cachedSelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen = new StaticControl(this, AgentUninstallWizardWindow.ControlIDs.SelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen);
                }

                return this.cachedSelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen;
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
        StaticControl IAgentActionWizardCommonWindowControls.AdministratorAccountStaticControl
        {
            get
            {
                if ((this.cachedAdministratorAccountStaticControl == null))
                {
                    this.cachedAdministratorAccountStaticControl = new StaticControl(this, AgentUninstallWizardWindow.ControlIDs.AdministratorAccountStaticControl);
                }

                return this.cachedAdministratorAccountStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LocalComputerAccountCheckBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 18-SEP-08 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IAgentActionWizardCommonWindowControls.LocalComputerAccountCheckBox
        {
            get
            {
                if (null == this.cachedLocalComputerAccountCheckBox)
                {
                    this.cachedLocalComputerAccountCheckBox =
                        new CheckBox(
                            this,
                            ControlIDs.LocalComputerAccountCheckBox);
                }

                return this.cachedLocalComputerAccountCheckBox;
            }
        }

        #endregion

        #region IUninstallAgentsWizardWindowControls Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UninstallButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IUninstallAgentsWizardWindowControls.UninstallButton
        {
            get
            {
                if ((this.cachedUninstallButton == null))
                {
                    this.cachedUninstallButton = new Button(this, AgentUninstallWizardWindow.ControlIDs.UninstallButton);
                }

                return this.cachedUninstallButton;
            }
        }

        #endregion

        #region IRepairAgentsWizardWindowControls Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RepairButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IRepairAgentsWizardWindowControls.RepairButton
        {
            get
            {
                if ((this.cachedRepairButton == null))
                {
                    this.cachedRepairButton = 
                        new Button(
                            this, 
                            AgentUninstallWizardWindow.ControlIDs.RepairButton);
                }

                return this.cachedRepairButton;
            }
        }        

        #endregion

        #endregion

        #region Click Methods

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
            this.CommonControls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Uninstall
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickUninstall()
        {
            this.UninstallControls.UninstallButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Help
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickHelp()
        {
            this.CommonControls.HelpButton.Click();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Uninstall
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickRepair()
        {
            this.UninstallControls.UninstallButton.Click();
        }

        #endregion
        
        /// -------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find the window.
        /// </summary>
        /// <returns>
        /// A System.IntPtr representing a handle to the window.
        /// </returns>
        /// <param name="ownerWindow">
        /// App class instance that owns this window.
        /// </param>
        /// <param name="agentAction">
        /// Agent action type:  uninstall or repair
        /// </param>
        /// <history>
        /// 	[KellyMor] 2/3/2006 Created
        /// </history>
        /// -------------------------------------------------------------------
        private static System.IntPtr Init(
            App ownerWindow, 
            AgentActionType agentAction)
        {
            // First check if the window is already up.
            Window tempWindow = null;
            string windowTitle = null;

            #region Determine Window Title String

            Core.Common.Utilities.LogMessage(
                "Agent Action Type value := '" +
                agentAction +
                "'");

            Core.Common.Utilities.LogMessage(
                "Agent Action Type text := '" +
                ((agentAction == AgentActionType.Uninstall) ? "Uninstall" : (agentAction == AgentActionType.Repair) ? "Repair" : "Unknown") +
                "'");

            // determine which window title string to use.
            switch (agentAction)
            {
                case AgentActionType.Uninstall:
                    {
                        windowTitle = Strings.UninstallAgentsWindowTitle;
                    }

                    break;

                case AgentActionType.Repair:
                    {
                        windowTitle = Strings.RepairAgentsWindowTitle;
                    }

                    break;
                default:
                    {
                        throw new System.ArgumentException(
                            "Unrecognized AgentActionType:  " +
                            agentAction);
                    }
            }

            Core.Common.Utilities.LogMessage(
                "Using window title := '" +
                windowTitle +
                "'");

            #endregion

            try
            {
                // Try to locate an existing instance of a window
                tempWindow = new Window(
                    windowTitle + "*",
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
                                windowTitle + "*",
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
                            "Attempt " + 
                            numberOfTries + 
                            " of " + 
                            MaxTries);

                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" +
                        windowTitle +
                        "'");

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
        ///     [KellyMor]  07-Apr-08   Modified how window title is created 
        ///                             and returned
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title for Uninstall Agents
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUninstallAgentsWindowTitle =
                ";Uninstall Agents" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.ModifyAgent" +
                ";$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title for Repair Agents
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRepairAgentsWindowTitle =
                ";Repair Agents" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";RepariAgentsTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel =
                ";Cancel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.WizardFramework" +
                ";buttonCancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Uninstall
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUninstall =
                ";&Uninstall" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.UninstallAgent" +
                ";buttonOK.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Repair
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRepair = 
                ";&Repair" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";RepairActionText";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp =
                ";&Help" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.PageFrameworks.WizardFramework" +
                ";buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  UserName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceUserName =
                ";&User name:" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.ConnectionAccount" +
                ";userAccount.UserCaption";
            
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
            private const string ResourceDomain =
                ";&Domain:" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.ConnectionAccount" +
                ";userAccount.DomainCaption";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OtherUserAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOtherUserAccount =
                ";&Other user account (will not be saved)" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.ConnectionAccount" +
                ";radioButtonNew.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ExistingUserAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceExistingUserAccount =
                ";&Existing user account" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.ConnectionAccount" +
                ";radioButtonExisting.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSelectAUserAccountWithAdministratorRightsOnTheComputersYouWillScanTheseCredentialsWillAlsoBeUsedWhen =
                @";Select a user account with Administrator rights on the computers you will scan. These credentials will also be used when installing the agents on managed computers." +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.ConnectionAccount" +
                ";labelDescription.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdministratorAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdministratorAccount =
                ";Administrator Account" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.Administration.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";ConnectionAccountTitle";

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
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUninstallAgentsWindowTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRepairAgentsWindowTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Uninstall
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedUninstall;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Repair
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRepair;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
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
            /// Caches the translated resource string for:  AdministratorAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministratorAccount;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 07-Apr-08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowTitle
            {
                get
                {
                    return cachedWindowTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string UninstallAgentsWindowTitle
            {
                get
                {
                    cachedWindowTitle = 
                        CoreManager.MomConsole.GetIntlStr(
                            ResourceUninstallAgentsWindowTitle);
                    cachedUninstallAgentsWindowTitle = cachedWindowTitle;

                    return cachedWindowTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RepairAgentsWindowTitle
            {
                get
                {
                    cachedWindowTitle = 
                        CoreManager.MomConsole.GetIntlStr(
                            ResourceRepairAgentsWindowTitle);
                    cachedRepairAgentsWindowTitle = cachedWindowTitle;
             
                    return cachedWindowTitle;
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
            /// Exposes access to the Uninstall translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Uninstall
            {
                get
                {
                    if ((cachedUninstall == null))
                    {
                        cachedUninstall = CoreManager.MomConsole.GetIntlStr(ResourceUninstall);
                    }

                    return cachedUninstall;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Uninstall translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/3/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Repair
            {
                get
                {
                    if ((cachedRepair == null))
                    {
                        cachedRepair = CoreManager.MomConsole.GetIntlStr(ResourceRepair);
                    }

                    return cachedRepair;
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
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelBtn";
            
            /// <summary>
            /// Control ID for UninstallButton
            /// </summary>
            public const string UninstallButton = "okButton";

            /// <summary>
            /// Control ID for RepairButton
            /// </summary>
            public const string RepairButton = "buttonOK";
            
            /// <summary>
            /// Control ID for HelpButton
            /// </summary>
            public const string HelpButton = "buttonHelp";
            
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
            /// Control ID for ComboBox0
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string ComboBox0 = "comboBoxExistingAccounts";
            
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
            /// Control ID for AdministratorAccountStaticControl
            /// </summary>
            public const string AdministratorAccountStaticControl = "labelTitle";

            /// <summary>
            /// Control ID for LocalComputerAccountCheckBox
            /// </summary>
            public const string LocalComputerAccountCheckBox = "checkBoxUseActionAccount";
        }

        #endregion
    }
}
