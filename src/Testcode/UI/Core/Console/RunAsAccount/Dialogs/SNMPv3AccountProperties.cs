// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="SNMPv3AccountProperties.cs">
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

namespace Mom.Test.UI.Core.Console.RunAsAccount
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - ISNMPv3AccountPropertiesControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, ISNMPv3AccountPropertiesControls, for SNMPv3AccountProperties.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-linch] 2009/6/17 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISNMPv3AccountPropertiesControls
    {
        /// <summary>
        /// Read-only property to access ApplyButton
        /// </summary>
        Button ApplyButton
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
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access Tab1TabControl
        /// </summary>
        /// <remark>
        /// TODO: Rename this interface method.  Intuitive name not found by Class Maker Tool.
        /// </remark>
        TabControl Tab1TabControl
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
    public class SNMPv3AccountProperties : Dialog, ISNMPv3AccountPropertiesControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ApplyButton of type Button
        /// </summary>
        private Button cachedApplyButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to Tab1TabControl of type TabControl
        /// </summary>
        private TabControl cachedTab1TabControl;
        
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
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of SNMPv3AccountProperties of type App
        /// </param>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public SNMPv3AccountProperties(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region ISNMPv3AccountProperties Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual ISNMPv3AccountPropertiesControls Controls
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
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISNMPv3AccountPropertiesControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, SNMPv3AccountProperties.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
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
        Button ISNMPv3AccountPropertiesControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, SNMPv3AccountProperties.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button ISNMPv3AccountPropertiesControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, SNMPv3AccountProperties.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab1TabControl control
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl ISNMPv3AccountPropertiesControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, SNMPv3AccountProperties.ControlIDs.Tab1TabControl);
                }
                
                return this.cachedTab1TabControl;
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
        StaticControl ISNMPv3AccountPropertiesControls.ProvideCredentialsForThisSNMPv3AccountTypeStaticControl
        {
            get
            {
                if ((this.cachedProvideCredentialsForThisSNMPv3AccountTypeStaticControl == null))
                {
                    this.cachedProvideCredentialsForThisSNMPv3AccountTypeStaticControl = new StaticControl(this, SNMPv3AccountProperties.ControlIDs.ProvideCredentialsForThisSNMPv3AccountTypeStaticControl);
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
        StaticControl ISNMPv3AccountPropertiesControls.ProvideAccountCredentialsStaticControl
        {
            get
            {
                if ((this.cachedProvideAccountCredentialsStaticControl == null))
                {
                    this.cachedProvideAccountCredentialsStaticControl = new StaticControl(this, SNMPv3AccountProperties.ControlIDs.ProvideAccountCredentialsStaticControl);
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
        StaticControl ISNMPv3AccountPropertiesControls.UserNameStaticControl
        {
            get
            {
                if ((this.cachedUserNameStaticControl == null))
                {
                    this.cachedUserNameStaticControl = new StaticControl(this, SNMPv3AccountProperties.ControlIDs.UserNameStaticControl);
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
        TextBox ISNMPv3AccountPropertiesControls.UserNameTextBox
        {
            get
            {
                if ((this.cachedUserNameTextBox == null))
                {
                    this.cachedUserNameTextBox = new TextBox(this, SNMPv3AccountProperties.ControlIDs.UserNameTextBox);
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
        StaticControl ISNMPv3AccountPropertiesControls.AuthenticationKeyStaticControl
        {
            get
            {
                if ((this.cachedAuthenticationKeyStaticControl == null))
                {
                    this.cachedAuthenticationKeyStaticControl = new StaticControl(this, SNMPv3AccountProperties.ControlIDs.AuthenticationKeyStaticControl);
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
        TextBox ISNMPv3AccountPropertiesControls.AuthenticationKeyTextBox
        {
            get
            {
                if ((this.cachedAuthenticationKeyTextBox == null))
                {
                    this.cachedAuthenticationKeyTextBox = new TextBox(this, SNMPv3AccountProperties.ControlIDs.AuthenticationKeyTextBox);
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
        StaticControl ISNMPv3AccountPropertiesControls.ConfirmAuthenticationKeyStaticControl
        {
            get
            {
                if ((this.cachedConfirmAuthenticationKeyStaticControl == null))
                {
                    this.cachedConfirmAuthenticationKeyStaticControl = new StaticControl(this, SNMPv3AccountProperties.ControlIDs.ConfirmAuthenticationKeyStaticControl);
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
        TextBox ISNMPv3AccountPropertiesControls.ConfirmAuthenticationKeyTextBox
        {
            get
            {
                if ((this.cachedConfirmAuthenticationKeyTextBox == null))
                {
                    this.cachedConfirmAuthenticationKeyTextBox = new TextBox(this, SNMPv3AccountProperties.ControlIDs.ConfirmAuthenticationKeyTextBox);
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
        StaticControl ISNMPv3AccountPropertiesControls.AuthenticationProtocolStaticControl
        {
            get
            {
                if ((this.cachedAuthenticationProtocolStaticControl == null))
                {
                    this.cachedAuthenticationProtocolStaticControl = new StaticControl(this, SNMPv3AccountProperties.ControlIDs.AuthenticationProtocolStaticControl);
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
        ComboBox ISNMPv3AccountPropertiesControls.AuthenticationProtocolComboBox
        {
            get
            {
                if ((this.cachedAuthenticationProtocolComboBox == null))
                {
                    this.cachedAuthenticationProtocolComboBox = new ComboBox(this, SNMPv3AccountProperties.ControlIDs.AuthenticationProtocolComboBox);
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
        StaticControl ISNMPv3AccountPropertiesControls.ContextOptionalStaticControl
        {
            get
            {
                if ((this.cachedContextOptionalStaticControl == null))
                {
                    this.cachedContextOptionalStaticControl = new StaticControl(this, SNMPv3AccountProperties.ControlIDs.ContextOptionalStaticControl);
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
        TextBox ISNMPv3AccountPropertiesControls.ContextOptionalTextBox
        {
            get
            {
                if ((this.cachedContextOptionalTextBox == null))
                {
                    this.cachedContextOptionalTextBox = new TextBox(this, SNMPv3AccountProperties.ControlIDs.ContextOptionalTextBox);
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
        ComboBox ISNMPv3AccountPropertiesControls.PrivacyProtocolComboBox
        {
            get
            {
                if ((this.cachedPrivacyProtocolComboBox == null))
                {
                    this.cachedPrivacyProtocolComboBox = new ComboBox(this, SNMPv3AccountProperties.ControlIDs.PrivacyProtocolComboBox);
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
        StaticControl ISNMPv3AccountPropertiesControls.PrivacyKeyStaticControl
        {
            get
            {
                if ((this.cachedPrivacyKeyStaticControl == null))
                {
                    this.cachedPrivacyKeyStaticControl = new StaticControl(this, SNMPv3AccountProperties.ControlIDs.PrivacyKeyStaticControl);
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
        StaticControl ISNMPv3AccountPropertiesControls.PrivacyProtocolStaticControl
        {
            get
            {
                if ((this.cachedPrivacyProtocolStaticControl == null))
                {
                    this.cachedPrivacyProtocolStaticControl = new StaticControl(this, SNMPv3AccountProperties.ControlIDs.PrivacyProtocolStaticControl);
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
        TextBox ISNMPv3AccountPropertiesControls.PrivacyKeyTextBox
        {
            get
            {
                if ((this.cachedPrivacyKeyTextBox == null))
                {
                    this.cachedPrivacyKeyTextBox = new TextBox(this, SNMPv3AccountProperties.ControlIDs.PrivacyKeyTextBox);
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
        TextBox ISNMPv3AccountPropertiesControls.ConfirmPrivacyKeyTextBox
        {
            get
            {
                if ((this.cachedConfirmPrivacyKeyTextBox == null))
                {
                    this.cachedConfirmPrivacyKeyTextBox = new TextBox(this, SNMPv3AccountProperties.ControlIDs.ConfirmPrivacyKeyTextBox);
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
        StaticControl ISNMPv3AccountPropertiesControls.ConfirmPrivacyKeyStaticControl
        {
            get
            {
                if ((this.cachedConfirmPrivacyKeyStaticControl == null))
                {
                    this.cachedConfirmPrivacyKeyStaticControl = new StaticControl(this, SNMPv3AccountProperties.ControlIDs.ConfirmPrivacyKeyStaticControl);
                }
                
                return this.cachedConfirmPrivacyKeyStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickApply()
        {
            this.Controls.ApplyButton.Click();
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[v-linch] 2009/6/17 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
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
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle = ";Run As Account Properties -;ManagedString;Microsoft.EnterpriseManagement.UI." +
                "Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;RunAsAccountPropertiesCaption";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceApply = ";&Apply;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.PropertyDialogForm;buttonApply.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialo" +
                "g.TranslucentColorPicker;buttonCancel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;DundasWinChart.dll;Dundas.Charting.WinControl.PropertyDialog.Tr" +
                "anslucentColorPicker;buttonOk.Text";

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
            /// Caches the translated resource string for:  Apply
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedApply;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-linch] 2009/6/17  Created
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
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[v-linch] 2009/6/17  Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Apply
            {
                get
                {
                    if ((cachedApply == null))
                    {
                        cachedApply = CoreManager.MomConsole.GetIntlStr(ResourceApply);
                    }
                    return cachedApply;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[v-linch] 2009/6/17  Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[v-linch] 2009/6/17  Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    if ((cachedOK == null))
                    {
                        cachedOK = CoreManager.MomConsole.GetIntlStr(ResourceOK);
                    }
                    return cachedOK;
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
            /// Control ID for ApplyButton
            /// </summary>
            public const string ApplyButton = "applyButton";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for Tab1TabControl
            /// </summary>
            /// <remark>
            ///  TODO: You may wish to rename this ID.  Intuitive name not found by Dialog Class Maker
            /// </remark>
            public const string Tab1TabControl = "tabPages";
            
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
        }
        #endregion
    }
}
