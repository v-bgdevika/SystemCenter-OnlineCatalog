// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SNMPv3AccountDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[v-linch] 2009/6/17 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.RunAsAccount.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ISNMPv3AccountDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISNMPv3AccountDialogControls, for SNMPv3AccountDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-linch] 2009/6/17 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISNMPv3AccountDialogControls
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
        /// Read-only property to access GeneralPropertiesStaticControl
        /// </summary>
        StaticControl GeneralPropertiesStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CredentialsStaticControl
        /// </summary>
        StaticControl CredentialsStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DistributionSecurityStaticControl
        /// </summary>
        StaticControl DistributionSecurityStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CompletionStaticControl
        /// </summary>
        StaticControl CompletionStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProvideCredentialsForThisSNMPv3AccountTypeStaticControl
        /// </summary>
        StaticControl ProvideCredentialsForThisSNMPv3AccountTypeStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProvideAccountCredentialsStaticControl
        /// </summary>
        StaticControl ProvideAccountCredentialsStaticControl
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
        /// Read-only property to access AuthenticationKeyStaticControl
        /// </summary>
        StaticControl AuthenticationKeyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AuthenticationKeyTextBox
        /// </summary>
        TextBox AuthenticationKeyTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfirmAuthenticationKeyStaticControl
        /// </summary>
        StaticControl ConfirmAuthenticationKeyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfirmAuthenticationKeyTextBox
        /// </summary>
        TextBox ConfirmAuthenticationKeyTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AuthenticationProtocolStaticControl
        /// </summary>
        StaticControl AuthenticationProtocolStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AuthenticationProtocolComboBox
        /// </summary>
        ComboBox AuthenticationProtocolComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ContextOptionalStaticControl
        /// </summary>
        StaticControl ContextOptionalStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ContextOptionalTextBox
        /// </summary>
        TextBox ContextOptionalTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PrivacyProtocolComboBox
        /// </summary>
        ComboBox PrivacyProtocolComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PrivacyKeyStaticControl
        /// </summary>
        StaticControl PrivacyKeyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PrivacyProtocolStaticControl
        /// </summary>
        StaticControl PrivacyProtocolStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access PrivacyKeyTextBox
        /// </summary>
        TextBox PrivacyKeyTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfirmPrivacyKeyTextBox
        /// </summary>
        TextBox ConfirmPrivacyKeyTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConfirmPrivacyKeyStaticControl
        /// </summary>
        StaticControl ConfirmPrivacyKeyStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CredentialsStaticControl2
        /// </summary>
        StaticControl CredentialsStaticControl2
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
    /// 	[v-linch] 2009/6/17 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class SNMPv3AccountDialog : Dialog, ISNMPv3AccountDialogControls
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
        /// Cache to hold a reference to GeneralPropertiesStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedGeneralPropertiesStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CredentialsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCredentialsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DistributionSecurityStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDistributionSecurityStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CompletionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedCompletionStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ProvideCredentialsForThisSNMPv3AccountTypeStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedProvideCredentialsForThisSNMPv3AccountTypeStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ProvideAccountCredentialsStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedProvideAccountCredentialsStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UserNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedUserNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to UserNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedUserNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to AuthenticationKeyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAuthenticationKeyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AuthenticationKeyTextBox of type TextBox
        /// </summary>
        private TextBox cachedAuthenticationKeyTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ConfirmAuthenticationKeyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfirmAuthenticationKeyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ConfirmAuthenticationKeyTextBox of type TextBox
        /// </summary>
        private TextBox cachedConfirmAuthenticationKeyTextBox;
        
        /// <summary>
        /// Cache to hold a reference to AuthenticationProtocolStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAuthenticationProtocolStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AuthenticationProtocolComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedAuthenticationProtocolComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ContextOptionalStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedContextOptionalStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ContextOptionalTextBox of type TextBox
        /// </summary>
        private TextBox cachedContextOptionalTextBox;
        
        /// <summary>
        /// Cache to hold a reference to PrivacyProtocolComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedPrivacyProtocolComboBox;
        
        /// <summary>
        /// Cache to hold a reference to PrivacyKeyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPrivacyKeyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PrivacyProtocolStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPrivacyProtocolStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PrivacyKeyTextBox of type TextBox
        /// </summary>
        private TextBox cachedPrivacyKeyTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ConfirmPrivacyKeyTextBox of type TextBox
        /// </summary>
        private TextBox cachedConfirmPrivacyKeyTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ConfirmPrivacyKeyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConfirmPrivacyKeyStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to CredentialsStaticControl2 of type StaticControl
        /// </summary>
        private StaticControl cachedCredentialsStaticControl2;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SNMPv3AccountDialog of type App
        /// </param>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SNMPv3AccountDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISNMPv3AccountDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISNMPv3AccountDialogControls Controls
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
        ///  Routine to set/get the text in control UserName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string UserNameText
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
        ///  Routine to set/get the text in control AuthenticationKey
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AuthenticationKeyText
        {
            get
            {
                return this.Controls.AuthenticationKeyTextBox.Text;
            }
            
            set
            {
                this.Controls.AuthenticationKeyTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ConfirmAuthenticationKey
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ConfirmAuthenticationKeyText
        {
            get
            {
                return this.Controls.ConfirmAuthenticationKeyTextBox.Text;
            }
            
            set
            {
                this.Controls.ConfirmAuthenticationKeyTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AuthenticationProtocol
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AuthenticationProtocolText
        {
            get
            {
                return this.Controls.AuthenticationProtocolComboBox.Text;
            }
            
            set
            {
                this.Controls.AuthenticationProtocolComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ContextOptional
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ContextOptionalText
        {
            get
            {
                return this.Controls.ContextOptionalTextBox.Text;
            }
            
            set
            {
                this.Controls.ContextOptionalTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control PrivacyProtocol
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PrivacyProtocolText
        {
            get
            {
                return this.Controls.PrivacyProtocolComboBox.Text;
            }
            
            set
            {
                this.Controls.PrivacyProtocolComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control PrivacyKey
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PrivacyKeyText
        {
            get
            {
                return this.Controls.PrivacyKeyTextBox.Text;
            }
            
            set
            {
                this.Controls.PrivacyKeyTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ConfirmPrivacyKey
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ConfirmPrivacyKeyText
        {
            get
            {
                return this.Controls.ConfirmPrivacyKeyTextBox.Text;
            }
            
            set
            {
                this.Controls.ConfirmPrivacyKeyTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PreviousButton control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISNMPv3AccountDialogControls.PreviousButton
        {
            get
            {
                if ((this.cachedPreviousButton == null))
                {
                    this.cachedPreviousButton = new Button(this, SNMPv3AccountDialog.ControlIDs.PreviousButton);
                }
                
                return this.cachedPreviousButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the NextButton control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISNMPv3AccountDialogControls.NextButton
        {
            get
            {
                if ((this.cachedNextButton == null))
                {
                    this.cachedNextButton = new Button(this, SNMPv3AccountDialog.ControlIDs.NextButton);
                }
                
                return this.cachedNextButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CreateButton control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISNMPv3AccountDialogControls.CreateButton
        {
            get
            {
                if ((this.cachedCreateButton == null))
                {
                    this.cachedCreateButton = new Button(this, SNMPv3AccountDialog.ControlIDs.CreateButton);
                }
                
                return this.cachedCreateButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISNMPv3AccountDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SNMPv3AccountDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the GeneralPropertiesStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPv3AccountDialogControls.GeneralPropertiesStaticControl
        {
            get
            {
                if ((this.cachedGeneralPropertiesStaticControl == null))
                {
                    this.cachedGeneralPropertiesStaticControl = new StaticControl(this, SNMPv3AccountDialog.ControlIDs.GeneralPropertiesStaticControl);
                }
                
                return this.cachedGeneralPropertiesStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CredentialsStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPv3AccountDialogControls.CredentialsStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedCredentialsStaticControl == null))
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
                    this.cachedCredentialsStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedCredentialsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DistributionSecurityStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPv3AccountDialogControls.DistributionSecurityStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
                if ((this.cachedDistributionSecurityStaticControl == null))
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
                    this.cachedDistributionSecurityStaticControl = new StaticControl(wndTemp);
                }
                
                return this.cachedDistributionSecurityStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CompletionStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPv3AccountDialogControls.CompletionStaticControl
        {
            get
            {
                // The ID for this control (textLinkLabel) is used multiple times in this dialog.
                //  Investigate why and report a bug if necessary.  The generated code follows the window
                //  hierarchy path to find the control to work around this problem.
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
                    for (i = 0; (i <= 2); i = (i + 1))
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
        ///  Exposes access to the ProvideCredentialsForThisSNMPv3AccountTypeStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPv3AccountDialogControls.ProvideCredentialsForThisSNMPv3AccountTypeStaticControl
        {
            get
            {
                if ((this.cachedProvideCredentialsForThisSNMPv3AccountTypeStaticControl == null))
                {
                    this.cachedProvideCredentialsForThisSNMPv3AccountTypeStaticControl = new StaticControl(this, SNMPv3AccountDialog.ControlIDs.ProvideCredentialsForThisSNMPv3AccountTypeStaticControl);
                }
                
                return this.cachedProvideCredentialsForThisSNMPv3AccountTypeStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProvideAccountCredentialsStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPv3AccountDialogControls.ProvideAccountCredentialsStaticControl
        {
            get
            {
                if ((this.cachedProvideAccountCredentialsStaticControl == null))
                {
                    this.cachedProvideAccountCredentialsStaticControl = new StaticControl(this, SNMPv3AccountDialog.ControlIDs.ProvideAccountCredentialsStaticControl);
                }
                
                return this.cachedProvideAccountCredentialsStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPv3AccountDialogControls.UserNameStaticControl
        {
            get
            {
                if ((this.cachedUserNameStaticControl == null))
                {
                    this.cachedUserNameStaticControl = new StaticControl(this, SNMPv3AccountDialog.ControlIDs.UserNameStaticControl);
                }
                
                return this.cachedUserNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UserNameTextBox control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISNMPv3AccountDialogControls.UserNameTextBox
        {
            get
            {
                if ((this.cachedUserNameTextBox == null))
                {
                    this.cachedUserNameTextBox = new TextBox(this, SNMPv3AccountDialog.ControlIDs.UserNameTextBox);
                }
                
                return this.cachedUserNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AuthenticationKeyStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPv3AccountDialogControls.AuthenticationKeyStaticControl
        {
            get
            {
                if ((this.cachedAuthenticationKeyStaticControl == null))
                {
                    this.cachedAuthenticationKeyStaticControl = new StaticControl(this, SNMPv3AccountDialog.ControlIDs.AuthenticationKeyStaticControl);
                }
                
                return this.cachedAuthenticationKeyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AuthenticationKeyTextBox control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISNMPv3AccountDialogControls.AuthenticationKeyTextBox
        {
            get
            {
                if ((this.cachedAuthenticationKeyTextBox == null))
                {
                    this.cachedAuthenticationKeyTextBox = new TextBox(this, SNMPv3AccountDialog.ControlIDs.AuthenticationKeyTextBox);
                }
                
                return this.cachedAuthenticationKeyTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfirmAuthenticationKeyStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPv3AccountDialogControls.ConfirmAuthenticationKeyStaticControl
        {
            get
            {
                if ((this.cachedConfirmAuthenticationKeyStaticControl == null))
                {
                    this.cachedConfirmAuthenticationKeyStaticControl = new StaticControl(this, SNMPv3AccountDialog.ControlIDs.ConfirmAuthenticationKeyStaticControl);
                }
                
                return this.cachedConfirmAuthenticationKeyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfirmAuthenticationKeyTextBox control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISNMPv3AccountDialogControls.ConfirmAuthenticationKeyTextBox
        {
            get
            {
                if ((this.cachedConfirmAuthenticationKeyTextBox == null))
                {
                    this.cachedConfirmAuthenticationKeyTextBox = new TextBox(this, SNMPv3AccountDialog.ControlIDs.ConfirmAuthenticationKeyTextBox);
                }
                
                return this.cachedConfirmAuthenticationKeyTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AuthenticationProtocolStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPv3AccountDialogControls.AuthenticationProtocolStaticControl
        {
            get
            {
                if ((this.cachedAuthenticationProtocolStaticControl == null))
                {
                    this.cachedAuthenticationProtocolStaticControl = new StaticControl(this, SNMPv3AccountDialog.ControlIDs.AuthenticationProtocolStaticControl);
                }
                
                return this.cachedAuthenticationProtocolStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AuthenticationProtocolComboBox control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISNMPv3AccountDialogControls.AuthenticationProtocolComboBox
        {
            get
            {
                if ((this.cachedAuthenticationProtocolComboBox == null))
                {
                    this.cachedAuthenticationProtocolComboBox = new ComboBox(this, SNMPv3AccountDialog.ControlIDs.AuthenticationProtocolComboBox);
                }
                
                return this.cachedAuthenticationProtocolComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ContextOptionalStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPv3AccountDialogControls.ContextOptionalStaticControl
        {
            get
            {
                if ((this.cachedContextOptionalStaticControl == null))
                {
                    this.cachedContextOptionalStaticControl = new StaticControl(this, SNMPv3AccountDialog.ControlIDs.ContextOptionalStaticControl);
                }
                
                return this.cachedContextOptionalStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ContextOptionalTextBox control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISNMPv3AccountDialogControls.ContextOptionalTextBox
        {
            get
            {
                if ((this.cachedContextOptionalTextBox == null))
                {
                    this.cachedContextOptionalTextBox = new TextBox(this, SNMPv3AccountDialog.ControlIDs.ContextOptionalTextBox);
                }
                
                return this.cachedContextOptionalTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PrivacyProtocolComboBox control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox ISNMPv3AccountDialogControls.PrivacyProtocolComboBox
        {
            get
            {
                if ((this.cachedPrivacyProtocolComboBox == null))
                {
                    this.cachedPrivacyProtocolComboBox = new ComboBox(this, SNMPv3AccountDialog.ControlIDs.PrivacyProtocolComboBox);
                }
                
                return this.cachedPrivacyProtocolComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PrivacyKeyStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPv3AccountDialogControls.PrivacyKeyStaticControl
        {
            get
            {
                if ((this.cachedPrivacyKeyStaticControl == null))
                {
                    this.cachedPrivacyKeyStaticControl = new StaticControl(this, SNMPv3AccountDialog.ControlIDs.PrivacyKeyStaticControl);
                }
                
                return this.cachedPrivacyKeyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PrivacyProtocolStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPv3AccountDialogControls.PrivacyProtocolStaticControl
        {
            get
            {
                if ((this.cachedPrivacyProtocolStaticControl == null))
                {
                    this.cachedPrivacyProtocolStaticControl = new StaticControl(this, SNMPv3AccountDialog.ControlIDs.PrivacyProtocolStaticControl);
                }
                
                return this.cachedPrivacyProtocolStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PrivacyKeyTextBox control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISNMPv3AccountDialogControls.PrivacyKeyTextBox
        {
            get
            {
                if ((this.cachedPrivacyKeyTextBox == null))
                {
                    this.cachedPrivacyKeyTextBox = new TextBox(this, SNMPv3AccountDialog.ControlIDs.PrivacyKeyTextBox);
                }
                
                return this.cachedPrivacyKeyTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfirmPrivacyKeyTextBox control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox ISNMPv3AccountDialogControls.ConfirmPrivacyKeyTextBox
        {
            get
            {
                if ((this.cachedConfirmPrivacyKeyTextBox == null))
                {
                    this.cachedConfirmPrivacyKeyTextBox = new TextBox(this, SNMPv3AccountDialog.ControlIDs.ConfirmPrivacyKeyTextBox);
                }
                
                return this.cachedConfirmPrivacyKeyTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConfirmPrivacyKeyStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPv3AccountDialogControls.ConfirmPrivacyKeyStaticControl
        {
            get
            {
                if ((this.cachedConfirmPrivacyKeyStaticControl == null))
                {
                    this.cachedConfirmPrivacyKeyStaticControl = new StaticControl(this, SNMPv3AccountDialog.ControlIDs.ConfirmPrivacyKeyStaticControl);
                }
                
                return this.cachedConfirmPrivacyKeyStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CredentialsStaticControl2 control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl ISNMPv3AccountDialogControls.CredentialsStaticControl2
        {
            get
            {
                if ((this.cachedCredentialsStaticControl2 == null))
                {
                    this.cachedCredentialsStaticControl2 = new StaticControl(this, SNMPv3AccountDialog.ControlIDs.CredentialsStaticControl2);
                }
                
                return this.cachedCredentialsStaticControl2;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Previous
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
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
        /// 	[v-linch] 2009/6/17 Created
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
        /// 	[v-linch] 2009/6/17 Created
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
        /// 	[v-linch] 2009/6/17 Created
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
        /// <param name="app">App owning the dialog.</param>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.Dialog, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
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
                                Strings.DialogTitle + "*", StringMatchSyntax.WildCard);

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
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Core.Common.Utilities.LogMessage(
                        "Failed to find window with title:  '" + Strings.DialogTitle + "'");

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
        /// 	[v-linch] 2009/6/17 Created
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
                ";Create Run As Account Wizard;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsAccountWizardCaption";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Previous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePrevious = ";< &Previous;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.PageFramework.WizardButtonsPanel;previousButton.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Next
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNext = ";&Next >;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement" +
                ".Mom.Internal.UI.PageFrameworks.WizardFramework;buttonNext.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Create
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCreate = ";&Create;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;CreateText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;DC01.bT;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Introduction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIntroduction = ";Introduction;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseM" +
                "anagement.Mom.Internal.UI.Administration.AdminResources;WelcomeTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceGeneral = ";General;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManage" +
                "ment.Mom.Internal.UI.Administration.AdminResources;GeneralPropertyPageTabText";

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
            /// Caches the translated resource string for:  Introduction
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIntroduction;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  General
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedGeneral;

           #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-linch] 2009/6/17 Created
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
            /// 	[v-linch] 2009/6/17 Created
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
            /// 	[v-linch] 2009/6/17 Created
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
            /// 	[v-linch] 2009/6/17 Created
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
            /// 	[v-linch] 2009/6/17 Created
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
            /// 	[v-linch] 2009/6/17 Created
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
            /// Exposes access to the General translated resource string
            /// </summary>
            /// <history>
            /// 	[v-linch] 2009/6/17 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string General
            {
                get
                {
                    if ((cachedGeneral == null))
                    {
                        cachedGeneral = CoreManager.MomConsole.GetIntlStr(ResourceGeneral);
                    }
                    return cachedGeneral;
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
        /// 	[v-linch] 2009/6/17 Created
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
            /// Control ID for GeneralPropertiesStaticControl
            /// </summary>
            public const string GeneralPropertiesStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for CredentialsStaticControl
            /// </summary>
            public const string CredentialsStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for DistributionSecurityStaticControl
            /// </summary>
            public const string DistributionSecurityStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for CompletionStaticControl
            /// </summary>
            public const string CompletionStaticControl = "textLinkLabel";
            
            /// <summary>
            /// Control ID for ProvideCredentialsForThisSNMPv3AccountTypeStaticControl
            /// </summary>
            public const string ProvideCredentialsForThisSNMPv3AccountTypeStaticControl = "label10";
            
            /// <summary>
            /// Control ID for ProvideAccountCredentialsStaticControl
            /// </summary>
            public const string ProvideAccountCredentialsStaticControl = "label11";
            
            /// <summary>
            /// Control ID for UserNameStaticControl
            /// </summary>
            public const string UserNameStaticControl = "label9";
            
            /// <summary>
            /// Control ID for UserNameTextBox
            /// </summary>
            public const string UserNameTextBox = "usernameEntry";
            
            /// <summary>
            /// Control ID for AuthenticationKeyStaticControl
            /// </summary>
            public const string AuthenticationKeyStaticControl = "label12";
            
            /// <summary>
            /// Control ID for AuthenticationKeyTextBox
            /// </summary>
            public const string AuthenticationKeyTextBox = "authKeyEntry";
            
            /// <summary>
            /// Control ID for ConfirmAuthenticationKeyStaticControl
            /// </summary>
            public const string ConfirmAuthenticationKeyStaticControl = "label13";
            
            /// <summary>
            /// Control ID for ConfirmAuthenticationKeyTextBox
            /// </summary>
            public const string ConfirmAuthenticationKeyTextBox = "confirmAuthKeyEntry";
            
            /// <summary>
            /// Control ID for AuthenticationProtocolStaticControl
            /// </summary>
            public const string AuthenticationProtocolStaticControl = "label17";
            
            /// <summary>
            /// Control ID for AuthenticationProtocolComboBox
            /// </summary>
            public const string AuthenticationProtocolComboBox = "authProtocolDropdown";
            
            /// <summary>
            /// Control ID for ContextOptionalStaticControl
            /// </summary>
            public const string ContextOptionalStaticControl = "label15";
            
            /// <summary>
            /// Control ID for ContextOptionalTextBox
            /// </summary>
            public const string ContextOptionalTextBox = "contextEntry";
            
            /// <summary>
            /// Control ID for PrivacyProtocolComboBox
            /// </summary>
            public const string PrivacyProtocolComboBox = "privacyProtocolDropdown";
            
            /// <summary>
            /// Control ID for PrivacyKeyStaticControl
            /// </summary>
            public const string PrivacyKeyStaticControl = "label18";
            
            /// <summary>
            /// Control ID for PrivacyProtocolStaticControl
            /// </summary>
            public const string PrivacyProtocolStaticControl = "label14";
            
            /// <summary>
            /// Control ID for PrivacyKeyTextBox
            /// </summary>
            public const string PrivacyKeyTextBox = "privacyKeyEntry";
            
            /// <summary>
            /// Control ID for ConfirmPrivacyKeyTextBox
            /// </summary>
            public const string ConfirmPrivacyKeyTextBox = "privacyKeyConfirmEntry";
            
            /// <summary>
            /// Control ID for ConfirmPrivacyKeyStaticControl
            /// </summary>
            public const string ConfirmPrivacyKeyStaticControl = "label16";
            
            /// <summary>
            /// Control ID for CredentialsStaticControl2
            /// </summary>
            public const string CredentialsStaticControl2 = "headerLabel";
        }
        #endregion
    }
}
