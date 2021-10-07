// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AgentInstallSummaryWindow.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[KellyMor] 07-Feb-06    Created
//  [KellyMor] 27-Feb-06    Updated resource strings
//  [KellyMor] 07-Jun-06    Updated resource assembly for new Admin assembly
//  [KellyMor] 04-Aug-06    Updated control name for Username text box
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - AgentActionAccount

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group AgentActionAccount
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/7/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum AgentActionAccount
    {
        /// <summary>
        /// LocalSystem = 0
        /// </summary>
        LocalSystem = 0,
        
        /// <summary>
        /// Other = 1
        /// </summary>
        Other = 1,
    }
    #endregion
    
    #region Interface Definition - IAgentInstallSummaryWindowControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAgentInstallSummaryWindowControls, for AgentInstallSummaryWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/7/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAgentInstallSummaryWindowControls
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
        /// Read-only property to access _1StaticControl
        /// </summary>
        StaticControl _1StaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AgentsToBeInstalledStaticControl
        /// </summary>
        StaticControl AgentsToBeInstalledStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AgentsSummaryStaticControl
        /// </summary>
        StaticControl AgentsSummaryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access LocalSystemRadioButton
        /// </summary>
        RadioButton LocalSystemRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OtherRadioButton
        /// </summary>
        RadioButton OtherRadioButton
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
        /// Read-only property to access SelectObjectsToManageTextBox
        /// </summary>
        TextBox SelectObjectsToManageTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AgentInstallationDirectoryStaticControl
        /// </summary>
        StaticControl AgentInstallationDirectoryStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AgentActionAccountStaticControl
        /// </summary>
        StaticControl AgentActionAccountStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SpecifyCredentialsForTheAgentToUseWhenPerformingActionsStaticControl
        /// </summary>
        StaticControl SpecifyCredentialsForTheAgentToUseWhenPerformingActionsStaticControl
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
        /// Read-only property to access SummaryStaticControl2
        /// </summary>
        StaticControl SummaryStaticControl2
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the agent install summary step 
    /// in the Computer and Device Management Wizard.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 2/7/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AgentInstallSummaryWindow : Window, IAgentInstallSummaryWindowControls
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
        /// Cache to hold a reference to _1StaticControl of type StaticControl
        /// </summary>
        private StaticControl cached_1StaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AgentsToBeInstalledStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAgentsToBeInstalledStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AgentsSummaryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAgentsSummaryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to LocalSystemRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedLocalSystemRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to OtherRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedOtherRadioButton;
        
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
        /// Cache to hold a reference to SelectObjectsToManageTextBox of type TextBox
        /// </summary>
        private TextBox cachedSelectObjectsToManageTextBox;
        
        /// <summary>
        /// Cache to hold a reference to AgentInstallationDirectoryStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAgentInstallationDirectoryStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AgentActionAccountStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAgentActionAccountStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyCredentialsForTheAgentToUseWhenPerformingActionsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSpecifyCredentialsForTheAgentToUseWhenPerformingActionsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to HelpStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedHelpStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SummaryStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedSummaryStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='ownerWindow'>
        /// Owner of AgentInstallSummaryWindow of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AgentInstallSummaryWindow(App ownerWindow) : 
                base(Init(ownerWindow))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group AgentActionAccount
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual AgentActionAccount AgentActionAccount
        {
            get
            {
                if ((this.Controls.LocalSystemRadioButton.ButtonState == ButtonState.Checked))
                {
                    return AgentActionAccount.LocalSystem;
                }
                
                if ((this.Controls.OtherRadioButton.ButtonState == ButtonState.Checked))
                {
                    return AgentActionAccount.Other;
                }
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == AgentActionAccount.LocalSystem))
                {
                    this.Controls.LocalSystemRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == AgentActionAccount.Other))
                    {
                        this.Controls.OtherRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IAgentInstallSummaryWindow Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this window
        /// </summary>
        /// <value>An interface that groups all of the window's control properties together</value>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAgentInstallSummaryWindowControls Controls
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
        /// 	[KellyMor] 2/7/2006 Created
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
        ///  Routine to set/get the text in control Password
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
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
        /// 	[KellyMor] 2/7/2006 Created
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
        /// 	[KellyMor] 2/7/2006 Created
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
        ///  Routine to set/get the text in control SelectObjectsToManage
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SelectObjectsToManageText
        {
            get
            {
                return this.Controls.SelectObjectsToManageTextBox.Text;
            }
            
            set
            {
                this.Controls.SelectObjectsToManageTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAgentInstallSummaryWindowControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, AgentInstallSummaryWindow.ControlIDs.PreviousButton);
                }
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAgentInstallSummaryWindowControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, AgentInstallSummaryWindow.ControlIDs.NextButton);
                }
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the FinishButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAgentInstallSummaryWindowControls.FinishButton
        {
            get
            {
                if ((this.cachedFinishButton == null))
                {
                    this.cachedFinishButton = new Button(this, AgentInstallSummaryWindow.ControlIDs.FinishButton);
                }
                return this.cachedFinishButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAgentInstallSummaryWindowControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AgentInstallSummaryWindow.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IntroductionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls.IntroductionStaticControl
        {
            get
            {
                if ((this.cachedIntroductionStaticControl == null))
                {
                    this.cachedIntroductionStaticControl = new StaticControl(this, AgentInstallSummaryWindow.ControlIDs.IntroductionStaticControl);
                }
                return this.cachedIntroductionStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AutoOrAdvancedStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls.AutoOrAdvancedStaticControl
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
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls.DiscoveryMethodStaticControl
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
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls.AdministratorAccountStaticControl
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
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls.RunningDiscoveryStaticControl
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
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls.SelectObjectsToManageStaticControl
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
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls.SummaryStaticControl
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
        ///  Exposes access to the _1StaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls._1StaticControl
        {
            get
            {
                if ((this.cached_1StaticControl == null))
                {
                    this.cached_1StaticControl = new StaticControl(this, AgentInstallSummaryWindow.ControlIDs._1StaticControl);
                }
                return this.cached_1StaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AgentsToBeInstalledStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls.AgentsToBeInstalledStaticControl
        {
            get
            {
                if ((this.cachedAgentsToBeInstalledStaticControl == null))
                {
                    this.cachedAgentsToBeInstalledStaticControl = new StaticControl(this, AgentInstallSummaryWindow.ControlIDs.AgentsToBeInstalledStaticControl);
                }
                return this.cachedAgentsToBeInstalledStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AgentsSummaryStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls.AgentsSummaryStaticControl
        {
            get
            {
                if ((this.cachedAgentsSummaryStaticControl == null))
                {
                    this.cachedAgentsSummaryStaticControl = new StaticControl(this, AgentInstallSummaryWindow.ControlIDs.AgentsSummaryStaticControl);
                }
                return this.cachedAgentsSummaryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LocalSystemRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAgentInstallSummaryWindowControls.LocalSystemRadioButton
        {
            get
            {
                if ((this.cachedLocalSystemRadioButton == null))
                {
                    this.cachedLocalSystemRadioButton = new RadioButton(this, AgentInstallSummaryWindow.ControlIDs.LocalSystemRadioButton);
                }
                return this.cachedLocalSystemRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OtherRadioButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IAgentInstallSummaryWindowControls.OtherRadioButton
        {
            get
            {
                if ((this.cachedOtherRadioButton == null))
                {
                    this.cachedOtherRadioButton = new RadioButton(this, AgentInstallSummaryWindow.ControlIDs.OtherRadioButton);
                }
                return this.cachedOtherRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls.UserNameStaticControl
        {
            get
            {
                if ((this.cachedUserNameStaticControl == null))
                {
                    this.cachedUserNameStaticControl = new StaticControl(this, AgentInstallSummaryWindow.ControlIDs.UserNameStaticControl);
                }
                return this.cachedUserNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserNameTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAgentInstallSummaryWindowControls.UserNameTextBox
        {
            get
            {
                if ((this.cachedUserNameTextBox == null))
                {
                    this.cachedUserNameTextBox = new TextBox(this, AgentInstallSummaryWindow.ControlIDs.UserNameTextBox);
                }
                return this.cachedUserNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PasswordStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls.PasswordStaticControl
        {
            get
            {
                if ((this.cachedPasswordStaticControl == null))
                {
                    this.cachedPasswordStaticControl = new StaticControl(this, AgentInstallSummaryWindow.ControlIDs.PasswordStaticControl);
                }
                return this.cachedPasswordStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PasswordTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAgentInstallSummaryWindowControls.PasswordTextBox
        {
            get
            {
                if ((this.cachedPasswordTextBox == null))
                {
                    this.cachedPasswordTextBox = new TextBox(this, AgentInstallSummaryWindow.ControlIDs.PasswordTextBox);
                }
                return this.cachedPasswordTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls.DomainStaticControl
        {
            get
            {
                if ((this.cachedDomainStaticControl == null))
                {
                    this.cachedDomainStaticControl = new StaticControl(this, AgentInstallSummaryWindow.ControlIDs.DomainStaticControl);
                }
                return this.cachedDomainStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainEditComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IAgentInstallSummaryWindowControls.DomainEditComboBox
        {
            get
            {
                if ((this.cachedDomainEditComboBox == null))
                {
                    this.cachedDomainEditComboBox = new EditComboBox(this, AgentInstallSummaryWindow.ControlIDs.DomainEditComboBox);
                }
                return this.cachedDomainEditComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DomainTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAgentInstallSummaryWindowControls.DomainTextBox
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
                    for (i = 0; (i <= 3); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
                    wndTemp = wndTemp.Extended.FirstChild;
                    for (i = 0; (i <= 1); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }
                    
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
        ///  Exposes access to the SelectObjectsToManageTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAgentInstallSummaryWindowControls.SelectObjectsToManageTextBox
        {
            get
            {
                if ((this.cachedSelectObjectsToManageTextBox == null))
                {
                    this.cachedSelectObjectsToManageTextBox = new TextBox(this, AgentInstallSummaryWindow.ControlIDs.SelectObjectsToManageTextBox);
                }
                return this.cachedSelectObjectsToManageTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AgentInstallationDirectoryStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls.AgentInstallationDirectoryStaticControl
        {
            get
            {
                if ((this.cachedAgentInstallationDirectoryStaticControl == null))
                {
                    this.cachedAgentInstallationDirectoryStaticControl = new StaticControl(this, AgentInstallSummaryWindow.ControlIDs.AgentInstallationDirectoryStaticControl);
                }
                return this.cachedAgentInstallationDirectoryStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AgentActionAccountStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls.AgentActionAccountStaticControl
        {
            get
            {
                if ((this.cachedAgentActionAccountStaticControl == null))
                {
                    this.cachedAgentActionAccountStaticControl = new StaticControl(this, AgentInstallSummaryWindow.ControlIDs.AgentActionAccountStaticControl);
                }
                return this.cachedAgentActionAccountStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SpecifyCredentialsForTheAgentToUseWhenPerformingActionsStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls.SpecifyCredentialsForTheAgentToUseWhenPerformingActionsStaticControl
        {
            get
            {
                if ((this.cachedSpecifyCredentialsForTheAgentToUseWhenPerformingActionsStaticControl == null))
                {
                    this.cachedSpecifyCredentialsForTheAgentToUseWhenPerformingActionsStaticControl = new StaticControl(this, AgentInstallSummaryWindow.ControlIDs.SpecifyCredentialsForTheAgentToUseWhenPerformingActionsStaticControl);
                }
                return this.cachedSpecifyCredentialsForTheAgentToUseWhenPerformingActionsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the HelpStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls.HelpStaticControl
        {
            get
            {
                if ((this.cachedHelpStaticControl == null))
                {
                    this.cachedHelpStaticControl = new StaticControl(this, AgentInstallSummaryWindow.ControlIDs.HelpStaticControl);
                }
                return this.cachedHelpStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SummaryStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAgentInstallSummaryWindowControls.SummaryStaticControl2
        {
            get
            {
                if ((this.cachedSummaryStaticControl2 == null))
                {
                    this.cachedSummaryStaticControl2 = new StaticControl(this, AgentInstallSummaryWindow.ControlIDs.SummaryStaticControl2);
                }
                return this.cachedSummaryStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
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
        /// 	[KellyMor] 2/7/2006 Created
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
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickFinish()
        {
            if (this.Controls.FinishButton.Caption.Equals(Strings.Finish))
            {
                this.Controls.FinishButton.Click();
            }
            else
            {
                Core.Common.Utilities.LogMessage("ClickFinish:: Finish button's caption is: " + this.Controls.FinishButton.Caption);
                //Set this.cachedFinishButton to null to let it instantiate a new Finish button later
                this.cachedFinishButton = null;
                //Log the new Finish button's caption again
                Core.Common.Utilities.LogMessage("ClickFinish:: New finish button's caption is: " + this.Controls.FinishButton.Caption);
                this.Controls.FinishButton.Click();
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 2/7/2006 Created
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
        /// 	[KellyMor] 2/7/2006 Created
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
        /// 	[KellyMor] 2/7/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
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
            private const string ResourceFinish = ";&Finish;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.WizardButtonsPanel;commitButton.Text";
            
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
            /// Contains resource string for:  _1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string Resource_1 = ";1;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.PageFrameworks.WizardFramework;>>panelBottomSeperator.ZO" +
                "rder";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AgentsToBeInstalled
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAgentsToBeInstalled = ";Agents to be installed:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;" +
                "AgentSummaryTitle";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AgentsSummary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAgentsSummary = ";Agents Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft" +
                ".EnterpriseManagement.Mom.Internal.UI.Administration.DiscoverySummary;labelSu" +
                "mmaryTitle.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LocalSystem
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLocalSystem = ";&Local System;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft." +
                "EnterpriseManagement.Mom.Internal.UI.Administration.DiscoverySummary;radioBut" +
                "tonLocal.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Other
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOther = ";&Other;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterpr" +
                "iseManagement.Mom.Internal.UI.Administration.DiscoverySummary;radioButtonOthe" +
                "r.Text";
            
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
            /// Contains resource string for:  AgentInstallationDirectory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAgentInstallationDirectory = ";Agent &installation directory:;ManagedString;Microsoft.MOM.UI.Components.resources.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.DiscoverySu" +
                "mmary;labelDirectory.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AgentActionAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAgentActionAccount = ";Agent Action Account;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Mic" +
                "rosoft.EnterpriseManagement.Mom.Internal.UI.Administration.DiscoverySummary;l" +
                "abelActionAccount.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SpecifyCredentialsForTheAgentToUseWhenPerformingActions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSpecifyCredentialsForTheAgentToUseWhenPerformingActions = ";Specify credentials for the agent to use when performing actions.;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Int" +
                "ernal.UI.Administration.DiscoverySummary;labelAccount.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceHelp = ";Help;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseMan" +
                "agement.Mom.Internal.UI.PageFrameworks.SheetFramework;buttonHelp.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Summary2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSummary2 = ";Summary;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.Enterp" +
                "riseManagement.Mom.Internal.UI.Administration.AdminResources;SummaryTitle";
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
            /// Caches the translated resource string for:  _1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cached_1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AgentsToBeInstalled
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAgentsToBeInstalled;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AgentsSummary
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAgentsSummary;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LocalSystem
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLocalSystem;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Other
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOther;
            
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
            /// Caches the translated resource string for:  AgentInstallationDirectory
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAgentInstallationDirectory;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AgentActionAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAgentActionAccount;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SpecifyCredentialsForTheAgentToUseWhenPerformingActions
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSpecifyCredentialsForTheAgentToUseWhenPerformingActions;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Help
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHelp;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Summary2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSummary2;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Finish
            {
                get
                {
                    if ((cachedFinish == null))
                    {
                        cachedFinish = CoreManager.MomConsole.GetIntlStr(ResourceFinish);

                        if (!string.IsNullOrEmpty(cachedFinish))
                        {
                            Core.Common.Utilities.LogMessage("Strings.Finish :: Remove &");

                            //remove the shortcut flag "&"
                            cachedFinish = cachedFinish.Replace("&", "");
                        }
                    }
                    return cachedFinish;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// Exposes access to the _1 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string _1
            {
                get
                {
                    if ((cached_1 == null))
                    {
                        cached_1 = CoreManager.MomConsole.GetIntlStr(Resource_1);
                    }
                    return cached_1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AgentsToBeInstalled translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AgentsToBeInstalled
            {
                get
                {
                    if ((cachedAgentsToBeInstalled == null))
                    {
                        cachedAgentsToBeInstalled = CoreManager.MomConsole.GetIntlStr(ResourceAgentsToBeInstalled);
                    }
                    return cachedAgentsToBeInstalled;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AgentsSummary translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AgentsSummary
            {
                get
                {
                    if ((cachedAgentsSummary == null))
                    {
                        cachedAgentsSummary = CoreManager.MomConsole.GetIntlStr(ResourceAgentsSummary);
                    }
                    return cachedAgentsSummary;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LocalSystem translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LocalSystem
            {
                get
                {
                    if ((cachedLocalSystem == null))
                    {
                        cachedLocalSystem = CoreManager.MomConsole.GetIntlStr(ResourceLocalSystem);
                    }
                    return cachedLocalSystem;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Other translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Other
            {
                get
                {
                    if ((cachedOther == null))
                    {
                        cachedOther = CoreManager.MomConsole.GetIntlStr(ResourceOther);
                    }
                    return cachedOther;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the UserName translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// 	[KellyMor] 2/7/2006 Created
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
            /// Exposes access to the AgentInstallationDirectory translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AgentInstallationDirectory
            {
                get
                {
                    if ((cachedAgentInstallationDirectory == null))
                    {
                        cachedAgentInstallationDirectory = CoreManager.MomConsole.GetIntlStr(ResourceAgentInstallationDirectory);
                    }
                    return cachedAgentInstallationDirectory;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AgentActionAccount translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AgentActionAccount
            {
                get
                {
                    if ((cachedAgentActionAccount == null))
                    {
                        cachedAgentActionAccount = CoreManager.MomConsole.GetIntlStr(ResourceAgentActionAccount);
                    }
                    return cachedAgentActionAccount;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SpecifyCredentialsForTheAgentToUseWhenPerformingActions translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecifyCredentialsForTheAgentToUseWhenPerformingActions
            {
                get
                {
                    if ((cachedSpecifyCredentialsForTheAgentToUseWhenPerformingActions == null))
                    {
                        cachedSpecifyCredentialsForTheAgentToUseWhenPerformingActions = CoreManager.MomConsole.GetIntlStr(ResourceSpecifyCredentialsForTheAgentToUseWhenPerformingActions);
                    }
                    return cachedSpecifyCredentialsForTheAgentToUseWhenPerformingActions;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
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
            /// Exposes access to the Summary2 translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 2/7/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Summary2
            {
                get
                {
                    if ((cachedSummary2 == null))
                    {
                        cachedSummary2 = CoreManager.MomConsole.GetIntlStr(ResourceSummary2);
                    }
                    return cachedSummary2;
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
        /// 	[KellyMor] 2/7/2006 Created
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
            /// Control ID for _1StaticControl
            /// </summary>
            public const string _1StaticControl = "labelAgentsCount";
            
            /// <summary>
            /// Control ID for AgentsToBeInstalledStaticControl
            /// </summary>
            public const string AgentsToBeInstalledStaticControl = "labelSummary";
            
            /// <summary>
            /// Control ID for AgentsSummaryStaticControl
            /// </summary>
            public const string AgentsSummaryStaticControl = "labelSummaryTitle";
            
            /// <summary>
            /// Control ID for LocalSystemRadioButton
            /// </summary>
            public const string LocalSystemRadioButton = "radioButtonLocal";
            
            /// <summary>
            /// Control ID for OtherRadioButton
            /// </summary>
            public const string OtherRadioButton = "radioButtonOther";
            
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
            /// Control ID for SelectObjectsToManageTextBox
            /// </summary>
            public const string SelectObjectsToManageTextBox = "textBoxDirectory";
            
            /// <summary>
            /// Control ID for AgentInstallationDirectoryStaticControl
            /// </summary>
            public const string AgentInstallationDirectoryStaticControl = "labelDirectory";
            
            /// <summary>
            /// Control ID for AgentActionAccountStaticControl
            /// </summary>
            public const string AgentActionAccountStaticControl = "labelActionAccount";
            
            /// <summary>
            /// Control ID for SpecifyCredentialsForTheAgentToUseWhenPerformingActionsStaticControl
            /// </summary>
            public const string SpecifyCredentialsForTheAgentToUseWhenPerformingActionsStaticControl = "labelAccount";
            
            /// <summary>
            /// Control ID for HelpStaticControl
            /// </summary>
            public const string HelpStaticControl = "helpLinkLabel";
            
            /// <summary>
            /// Control ID for SummaryStaticControl2
            /// </summary>
            public const string SummaryStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
