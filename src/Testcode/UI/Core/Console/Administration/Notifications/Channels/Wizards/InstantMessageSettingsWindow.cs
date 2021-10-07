// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="InstantMessageSettingsWindow.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3 R2 test automation.
// </project>
// <summary>
// 	MOMv3 R2 test automation.
// </summary>
// <history>
// 	[KellyMor]  11-AUG-08   Created
//  [KellyMor]  18-AUG-08   Updated resource strings
//  [KellyMor]  04-SEP-08   Updated channel wizard title string
//  [KellyMor]  06-SEP-08   Updated resource strings for move from Administration
//                          library to components library.
//  [KellyMor]  08-SEP-08   StyleCop fixes.
//  [KellyMor]  10-SEP-08   More updates for resource string move to components
// </history>
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Channels.Wizards
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    #region Interface Definition - IInstantMessageSettingsWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IInstantMessageSettingsWindow, for 
    /// InstantMessageSettingsWindow.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 11-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IInstantMessageSettingsWindow
    {
        /// <summary>
        /// Read-only property to access ServerStaticControl
        /// </summary>
        StaticControl ServerStaticControl
        {
            get;
        }
 
        /// <summary>
        /// Read-only property to access ServerTextBox
        /// </summary>
        TextBox ServerTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ReturnAdressStaticControl
        /// </summary>
        StaticControl ReturnAdressStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ReturnAddressTextBox
        /// </summary>
        TextBox ReturnAddressTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ProtocolOptionStaticControl
        /// </summary>
        StaticControl ProtocolOptionStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access ProtocolOptionsComboBox
        /// </summary>
        EditComboBox ProtocolOptionsComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AuthenticationMethodStaticControl
        /// </summary>
        StaticControl AuthenticationMethodStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AuthenticationMethodEditComboBox
        /// </summary>
        EditComboBox AuthenticationMethodEditComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AuthenticationMethodTextBox
        /// </summary>
        TextBox AuthenticationMethodTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PortNumberStaticControl
        /// </summary>
        StaticControl PortNumberStaticControl
        {
            get;
        }

        /// <summary>
        /// Read-only property to access PortNumberTextBox
        /// </summary>
        TextBox PortNumberTextBox
        {
            get;
        }
    }

    #endregion Interface Definition - IInstantMessageSettingsWindow

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Instant Message Settings page of the Instant
    /// Message Channel Wizard.
    /// </summary>
    /// <history>
    ///     [KellyMor] 11-AUG-08 Created
    /// </history>
    /// -----------------------------------------------------------------------
    public class InstantMessageSettingsWindow : Mom.Test.UI.Core.Console.Administration.ConsoleWizardBase, IInstantMessageSettingsWindow
    {       
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        #endregion

        #region Private Members

        /// <summary>
        /// Cache to hold a reference to ServerStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedServerStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ServerTextBox of type TextBox
        /// </summary>
        private TextBox cachedServerTextBox;

        /// <summary>
        /// Cache to hold a reference to ReturnAdressStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedReturnAdressStaticControl;

        /// <summary>
        /// Cache to hold a reference to ReturnAddressTextBox of type TextBox
        /// </summary>
        private TextBox cachedReturnAddressTextBox;

        /// <summary>
        /// Cache to hold a reference to ProtocolOptionStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedProtocolOptionStaticControl;

        /// <summary>
        /// Cache to hold a reference to ProtocolOptionsComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedProtocolOptionsComboBox;

        /// <summary>
        /// Cache to hold a reference to AuthenticationMethodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAuthenticationMethodStaticControl;

        /// <summary>
        /// Cache to hold a reference to AuthenticationMethodEditComboBox of type EditComboBox
        /// </summary>
        private EditComboBox cachedAuthenticationMethodEditComboBox;

        /// <summary>
        /// Cache to hold a reference to AuthenticationMethodTextBox of type TextBox
        /// </summary>
        private TextBox cachedAuthenticationMethodTextBox;

        /// <summary>
        /// Cache to hold a reference to PortNumberStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPortNumberStaticControl;

        /// <summary>
        /// Cache to hold a reference to PortNumberTextBox of type TextBox
        /// </summary>
        private TextBox cachedPortNumberTextBox;

        #endregion Private Members

        #region Constructors
        
        /// -----------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="app">
        /// Owner of ConsoleWizardBase of type ConsoleApp
        /// </param>
        /// <history>
        ///     [KellyMor] 11-AUG-08 Created
        /// </history>
        /// -----------------------------------------------------------------------
        public InstantMessageSettingsWindow(ConsoleApp app)
            : base(app, Strings.DialogTitle)
        {
            // Add constructor logic
        }

        #endregion Constructors

        #region Interface Control Properties

        #region IInstantMessageSettingsWindow Controls Property

        /// -------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>
        /// An interface that groups all of the dialog's control properties 
        /// together
        /// </value>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public new IInstantMessageSettingsWindow Controls
        {
            get
            {
                return this;
            }
        }

        #endregion

        #region IConsoleWizardBase Controls Property

        /// -------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for the base class of the 
        /// dialog.
        /// </summary>
        /// <value>
        /// An interface that groups all of the base class dialog's control 
        /// properties together.
        /// </value>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public Mom.Test.UI.Core.Console.Administration.IConsoleWizardBase BaseControls
        {
            get
            {
                return base.Controls;
            }
        }

        #endregion

        #endregion

        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ServerText
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ServerText
        {
            get
            {
                return this.Controls.ServerTextBox.Text;
            }

            set
            {
                this.Controls.ServerTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ReturnAdress
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ReturnAddressText
        {
            get
            {
                return this.Controls.ReturnAddressTextBox.Text;
            }

            set
            {
                this.Controls.ReturnAddressTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ReturnAddress
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ProtocolOptionsText
        {
            get
            {
                return this.Controls.ProtocolOptionsComboBox.Text;
            }

            set
            {
                this.Controls.ProtocolOptionsComboBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AuthenticationMethod
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AuthenticationMethodText
        {
            get
            {
                return this.Controls.AuthenticationMethodEditComboBox.Text;
            }

            set
            {
                this.Controls.AuthenticationMethodEditComboBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control AuthenticationMethod2
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AuthenticationMethodTextBoxText
        {
            get
            {
                return this.Controls.AuthenticationMethodTextBox.Text;
            }

            set
            {
                this.Controls.AuthenticationMethodTextBox.Text = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control PortNumberTextBox
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PortNumberText
        {
            get
            {
                return this.Controls.PortNumberTextBox.Text;
            }

            set
            {
                this.Controls.PortNumberTextBox.Text = value;
            }
        }

        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServerStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IInstantMessageSettingsWindow.ServerStaticControl
        {
            get
            {
                if ((this.cachedServerStaticControl == null))
                {
                    this.cachedServerStaticControl = 
                        new StaticControl(
                            this,
                            InstantMessageSettingsWindow.ControlIDs.ServerStaticControl);
                }

                return this.cachedServerStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ServerTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IInstantMessageSettingsWindow.ServerTextBox
        {
            get
            {
                if ((this.cachedServerTextBox == null))
                {
                    this.cachedServerTextBox = 
                        new TextBox(
                            this,
                            InstantMessageSettingsWindow.ControlIDs.ServerTextBox);
                }

                return this.cachedServerTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ReturnAdressStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IInstantMessageSettingsWindow.ReturnAdressStaticControl
        {
            get
            {
                if ((this.cachedReturnAdressStaticControl == null))
                {
                    this.cachedReturnAdressStaticControl = 
                        new StaticControl(
                            this,
                            InstantMessageSettingsWindow.ControlIDs.ReturnAdressStaticControl);
                }

                return this.cachedReturnAdressStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ReturnAddressTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IInstantMessageSettingsWindow.ReturnAddressTextBox
        {
            get
            {
                if ((this.cachedReturnAddressTextBox == null))
                {
                    this.cachedReturnAddressTextBox = 
                        new TextBox(
                            this,
                            InstantMessageSettingsWindow.ControlIDs.ReturnAddressTextBox);
                }

                return this.cachedReturnAddressTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProtocolOptionStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IInstantMessageSettingsWindow.ProtocolOptionStaticControl
        {
            get
            {
                if ((this.cachedProtocolOptionStaticControl == null))
                {
                    this.cachedProtocolOptionStaticControl = 
                        new StaticControl(
                            this,
                            InstantMessageSettingsWindow.ControlIDs.ProtocolOptionStaticControl);
                }

                return this.cachedProtocolOptionStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProtocolOptionsComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IInstantMessageSettingsWindow.ProtocolOptionsComboBox
        {
            get
            {
                if ((this.cachedProtocolOptionsComboBox == null))
                {
                    this.cachedProtocolOptionsComboBox = 
                        new EditComboBox(
                            this,
                            InstantMessageSettingsWindow.ControlIDs.ProtocolOptionsComboBox);
                }

                return this.cachedProtocolOptionsComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AuthenticationMethodStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IInstantMessageSettingsWindow.AuthenticationMethodStaticControl
        {
            get
            {
                if ((this.cachedAuthenticationMethodStaticControl == null))
                {
                    this.cachedAuthenticationMethodStaticControl = 
                            new StaticControl(
                                this,
                                InstantMessageSettingsWindow.ControlIDs.AuthenticationMethodStaticControl);
                }

                return this.cachedAuthenticationMethodStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AuthenticationMethodEditComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        EditComboBox IInstantMessageSettingsWindow.AuthenticationMethodEditComboBox
        {
            get
            {
                if ((this.cachedAuthenticationMethodEditComboBox == null))
                {
                    this.cachedAuthenticationMethodEditComboBox = 
                        new EditComboBox(
                            this,
                            InstantMessageSettingsWindow.ControlIDs.AuthenticationMethodEditComboBox);
                }

                return this.cachedAuthenticationMethodEditComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AuthenticationMethodTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IInstantMessageSettingsWindow.AuthenticationMethodTextBox
        {
            get
            {
                if ((this.cachedAuthenticationMethodTextBox == null))
                {
                    Window wndTemp = this.AccessibleObject.Window;

                    // Required to navigate to control
                    wndTemp = wndTemp.Extended.FirstChild;
                    int i;
                    for (i = 0; (i <= 2); i = (i + 1))
                    {
                        wndTemp = wndTemp.Extended.NextSibling;
                    }

                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.NextSibling;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    wndTemp = wndTemp.Extended.FirstChild;
                    this.cachedAuthenticationMethodTextBox = new TextBox(wndTemp);
                }

                return this.cachedAuthenticationMethodTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PortNumberStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IInstantMessageSettingsWindow.PortNumberStaticControl
        {
            get
            {
                if ((this.cachedPortNumberStaticControl == null))
                {
                    this.cachedPortNumberStaticControl = 
                        new StaticControl(
                            this,
                            InstantMessageSettingsWindow.ControlIDs.PortNumberStaticControl);
                }

                return this.cachedPortNumberStaticControl;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the PortNumberTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IInstantMessageSettingsWindow.PortNumberTextBox
        {
            get
            {
                if ((this.cachedPortNumberTextBox == null))
                {
                    this.cachedPortNumberTextBox = 
                        new TextBox(
                            this, 
                            InstantMessageSettingsWindow.ControlIDs.PortNumberTextBox);
                }

                return this.cachedPortNumberTextBox;
            }
        }

        #endregion

        #region Strings

        /// -------------------------------------------------------------------
        /// <summary>
        /// String resource definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public new class Strings
        {
            #region Constants

            /// ---------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private const string ResourceDialogTitle =
                ";IM Notification Channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";IMChannelWizardTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Server
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceServer =
                ";IM &server:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.IMChannelSettingsPage" +
                ";serverLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ReturnAdress
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceReturnAdress =
                ";&Return adress:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.IMChannelSettingsPage" +
                ";returnAddressLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ProtocolOption
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProtocolOption =
                ";Pr&otocol option:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.IMChannelSettingsPage" +
                ";protocolLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ProtocolTcp
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProtocolTcp =
                ";TCP" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";TcpProtocol";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ProtocolTls
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProtocolTls =
                ";TLS" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";TlsProtocol";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AuthenticationMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAuthenticationMethod =
                ";A&uthentication method:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.IMChannelSettingsPage" +
                ";authenticationLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AuthenticationNtlm
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAuthenticationNtlm =
                ";NTLM" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";NtlmProtocol";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AuthenticationKerberos
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAuthenticationKerberos =
                ";Kerberos" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.NotificationResource" +
                ";KerberosProtocol";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PortNumber
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePortNumber =
                ";&IM port:" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Notification.IMChannelSettingsPage" +
                ";portLabel.Text";

            #endregion

            #region Private Members

            /// ---------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// ---------------------------------------------------------------
            private static string cachedDialogTitle;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Server
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedServer;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ReturnAdress
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedReturnAdress;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ProtocolOption
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProtocolOption;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ProtocolTcp
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProtocolTcp;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ProtocolTls
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProtocolTls;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AuthenticationMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAuthenticationMethod;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AuthenticationNtlm
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAuthenticationNtlm;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AuthenticationKerberos
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAuthenticationKerberos;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PortNumber
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPortNumber;

            #endregion Private Members

            #region Properties

            /// ---------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11-AUG-08 Created
            /// </history>
            /// ---------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceDialogTitle);
                    }

                    return cachedDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Server translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Server
            {
                get
                {
                    if ((cachedServer == null))
                    {
                        cachedServer = 
                            CoreManager.MomConsole.GetIntlStr(
                            ResourceServer);
                    }

                    return cachedServer;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ReturnAdress translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ReturnAdress
            {
                get
                {
                    if ((cachedReturnAdress == null))
                    {
                        cachedReturnAdress = CoreManager.MomConsole.GetIntlStr(ResourceReturnAdress);
                    }

                    return cachedReturnAdress;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ProtocolOption translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProtocolOption
            {
                get
                {
                    if ((cachedProtocolOption == null))
                    {
                        cachedProtocolOption = CoreManager.MomConsole.GetIntlStr(ResourceProtocolOption);
                    }

                    return cachedProtocolOption;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ProtocolTcp translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProtocolTcp
            {
                get
                {
                    if ((cachedProtocolTcp == null))
                    {
                        cachedProtocolTcp = CoreManager.MomConsole.GetIntlStr(ResourceProtocolTcp);
                    }

                    return cachedProtocolTcp;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ProtocolTls translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ProtocolTls
            {
                get
                {
                    if ((cachedProtocolTls == null))
                    {
                        cachedProtocolTls = CoreManager.MomConsole.GetIntlStr(ResourceProtocolTls);
                    }

                    return cachedProtocolTls;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AuthenticationMethod translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AuthenticationMethod
            {
                get
                {
                    if ((cachedAuthenticationMethod == null))
                    {
                        cachedAuthenticationMethod = CoreManager.MomConsole.GetIntlStr(ResourceAuthenticationMethod);
                    }

                    return cachedAuthenticationMethod;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AuthenticationNtlm translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AuthenticationNtlm
            {
                get
                {
                    if ((cachedAuthenticationNtlm == null))
                    {
                        cachedAuthenticationNtlm = CoreManager.MomConsole.GetIntlStr(ResourceAuthenticationNtlm);
                    }

                    return cachedAuthenticationNtlm;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AuthenticationKerberos translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AuthenticationKerberos
            {
                get
                {
                    if ((cachedAuthenticationKerberos == null))
                    {
                        cachedAuthenticationKerberos = CoreManager.MomConsole.GetIntlStr(ResourceAuthenticationKerberos);
                    }

                    return cachedAuthenticationKerberos;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the PortNumber translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PortNumber
            {
                get
                {
                    if ((cachedPortNumber == null))
                    {
                        cachedPortNumber = 
                            CoreManager.MomConsole.GetIntlStr(
                            ResourcePortNumber);
                    }

                    return cachedPortNumber;
                }
            }

            #endregion Properties
        }

        #endregion

        #region ControlIDs

        /// -------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 11-AUG-08 Created
        /// </history>
        /// -------------------------------------------------------------------
        public new class ControlIDs
        {
            /// <summary>
            /// Control ID for ServerStaticControl
            /// </summary>
            public const string ServerStaticControl = "serverLabel";
            
            /// <summary>
            /// Control ID for ServerTextBox
            /// </summary>
            public const string ServerTextBox = "serverBox";

            /// <summary>
            /// Control ID for ReturnAdressStaticControl
            /// </summary>
            public const string ReturnAdressStaticControl = "returnAddressLabel";

            /// <summary>
            /// Control ID for ReturnAddressTextBox
            /// </summary>
            public const string ReturnAddressTextBox = "returnAddressBox";

            /// <summary>
            /// Control ID for ProtocolOptionStaticControl
            /// </summary>
            public const string ProtocolOptionStaticControl = "protocolLabel";

            /// <summary>
            /// Control ID for ProtocolOptionsComboBox
            /// </summary>
            public const string ProtocolOptionsComboBox = "protocolList";

            /// <summary>
            /// Control ID for AuthenticationMethodStaticControl
            /// </summary>
            public const string AuthenticationMethodStaticControl = "authenticationLabel";

            /// <summary>
            /// Control ID for AuthenticationMethodEditComboBox
            /// </summary>
            public const string AuthenticationMethodEditComboBox = "authenticationBox";

            /// <summary>
            /// Control ID for PortNumberStaticControl
            /// </summary>
            public const string PortNumberStaticControl = "portLabel";

            /// <summary>
            /// Control ID for PortNumberTextBox
            /// </summary>
            public const string PortNumberTextBox = "portBox";
        }

        #endregion
    }
}
