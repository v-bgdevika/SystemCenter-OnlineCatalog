// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AddSmtpServerDialog.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[KellyMor]  05-Apr-06   Created
//  [KellyMor]  17-Apr-06   Updated control names
//                          Updated resource strings
//  [KellyMor] 07-Jun-06    Updated resource assembly for new Admin assembly
//  [KellyMor] 08-Jun-06    Updated resource assembly namespace
//  [KellyMor] 09-Nov-06    Added resource string for "Windows Integrated" authentication
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.GlobalSettings
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IAddSmtpServerDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAddSmtpServerDialogControls, for AddSmtpServerDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/5/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddSmtpServerDialogControls
    {
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
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
        /// Read-only property to access AuthenticationMethodComboBox
        /// </summary>
        ComboBox AuthenticationMethodComboBox
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
        
        /// <summary>
        /// Read-only property to access AuthenticationMethodStaticControl
        /// </summary>
        StaticControl AuthenticationMethodStaticControl
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
        /// Read-only property to access SMTPServerFQDNTextBox
        /// </summary>
        TextBox SMTPServerFQDNTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access SMTPServerFQDNStaticControl
        /// </summary>
        StaticControl SMTPServerFQDNStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Add SMTP server dialog
    /// </summary>
    /// <history>
    /// 	[KellyMor] 4/5/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class AddSmtpServerDialog : Dialog, IAddSmtpServerDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;

        private const int DefaultPort = 25;

        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to AuthenticationMethodComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedAuthenticationMethodComboBox;
        
        /// <summary>
        /// Cache to hold a reference to PortNumberTextBox of type TextBox
        /// </summary>
        private TextBox cachedPortNumberTextBox;
        
        /// <summary>
        /// Cache to hold a reference to AuthenticationMethodStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedAuthenticationMethodStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to PortNumberStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedPortNumberStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to SMTPServerFQDNTextBox of type TextBox
        /// </summary>
        private TextBox cachedSMTPServerFQDNTextBox;
        
        /// <summary>
        /// Cache to hold a reference to SMTPServerFQDNStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedSMTPServerFQDNStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of AddSmtpServerDialog of type App
        /// </param>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AddSmtpServerDialog(App app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAddSmtpServerDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAddSmtpServerDialogControls Controls
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
                return this.Controls.AuthenticationMethodComboBox.Text;
            }
            
            set
            {
                this.Controls.AuthenticationMethodComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control PortNumber
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
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control SMTPServerFQDN
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SMTPServerFQDNText
        {
            get
            {
                return this.Controls.SMTPServerFQDNTextBox.Text;
            }
            
            set
            {
                this.Controls.SMTPServerFQDNTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddSmtpServerDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AddSmtpServerDialog.ControlIDs.OKButton);
                }
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddSmtpServerDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AddSmtpServerDialog.ControlIDs.CancelButton);
                }
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AuthenticationMethodComboBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAddSmtpServerDialogControls.AuthenticationMethodComboBox
        {
            get
            {
                if ((this.cachedAuthenticationMethodComboBox == null))
                {
                    this.cachedAuthenticationMethodComboBox = new ComboBox(this, AddSmtpServerDialog.ControlIDs.AuthenticationMethodComboBox);
                }
                return this.cachedAuthenticationMethodComboBox;
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
        TextBox IAddSmtpServerDialogControls.PortNumberTextBox
        {
            get
            {
                if ((this.cachedPortNumberTextBox == null))
                {
                    this.cachedPortNumberTextBox = new TextBox(this, AddSmtpServerDialog.ControlIDs.PortNumberTextBox);
                }
                return this.cachedPortNumberTextBox;
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
        StaticControl IAddSmtpServerDialogControls.AuthenticationMethodStaticControl
        {
            get
            {
                if ((this.cachedAuthenticationMethodStaticControl == null))
                {
                    this.cachedAuthenticationMethodStaticControl = new StaticControl(this, AddSmtpServerDialog.ControlIDs.AuthenticationMethodStaticControl);
                }
                return this.cachedAuthenticationMethodStaticControl;
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
        StaticControl IAddSmtpServerDialogControls.PortNumberStaticControl
        {
            get
            {
                if ((this.cachedPortNumberStaticControl == null))
                {
                    this.cachedPortNumberStaticControl = new StaticControl(this, AddSmtpServerDialog.ControlIDs.PortNumberStaticControl);
                }
                return this.cachedPortNumberStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SMTPServerFQDNTextBox control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddSmtpServerDialogControls.SMTPServerFQDNTextBox
        {
            get
            {
                if ((this.cachedSMTPServerFQDNTextBox == null))
                {
                    this.cachedSMTPServerFQDNTextBox = new TextBox(this, AddSmtpServerDialog.ControlIDs.SMTPServerFQDNTextBox);
                }
                return this.cachedSMTPServerFQDNTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SMTPServerFQDNStaticControl control
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IAddSmtpServerDialogControls.SMTPServerFQDNStaticControl
        {
            get
            {
                if ((this.cachedSMTPServerFQDNStaticControl == null))
                {
                    this.cachedSMTPServerFQDNStaticControl = new StaticControl(this, AddSmtpServerDialog.ControlIDs.SMTPServerFQDNStaticControl);
                }
                return this.cachedSMTPServerFQDNStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
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
        ///  <param name="app">App owning the dialog.</param>)
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(
                    Strings.DialogTitle, 
                    StringMatchSyntax.ExactMatch, 
                    WindowClassNames.WinForms10Window8, 
                    StringMatchSyntax.ExactMatch, 
                    app.MainWindow, 
                    Timeout);
            }            
            catch (Exceptions.WindowNotFoundException ex)
            {
                Common.Utilities.LogMessage(
                    "Looking for window with title:  '" +
                    Strings.DialogTitle +
                    "'");

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
                                StringMatchSyntax.WildCard);
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);

                        // wait for the window to report ready
                        UISynchronization.WaitForUIObjectReady(
                            tempWindow,
                            Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + MaxTries);
                        Sleeper.Delay(Timeout);
                    }
                }

                // check for success
                if (tempWindow == null)
                {
                    // log the failure
                    Common.Utilities.LogMessage("Failed to find the Add SMTP Server dialog window!");

                    // throw the existing WindowNotFound exception
                    throw ex;
                }
            }
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Resource string definitions.
        /// </summary>
        /// <history>
        /// 	[KellyMor] 4/5/2006 Created
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
            private const string ResourceDialogTitle = ";Add SMTP Server;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.SMTPServerForm;$this.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.SMTPServerForm;ok.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.SMTPServerForm;cancel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AuthenticationMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAuthenticationMethod = ";&Authentication method:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.SMTPServerForm" +
                ";authenticationLabel.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  PortNumber
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourcePortNumber = ";&Port number:;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.SMTPServerForm;portLabel" +
                ".Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SMTPServerFQDN
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSMTPServerFQDN = ";&SMTP server (FQDN):;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.SMTPServerForm;na" +
                "meLabel.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  NTLM
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceNtlm = ";NTLM;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.NotificationResource;SmtpAuthenticationNTLM";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Anonymous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAnonymous = ";Anonymous;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.NotificationResource;SmtpAuthenticationAnonymous";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  WindowsIntegrated
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceWindowsIntegrated = ";Windows Integrated;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Notification.NotificationResource.en;SmtpAuthenticationNTLM";

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
            /// Caches the translated resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedOK;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCancel;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AuthenticationMethod
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAuthenticationMethod;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  PortNumber
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedPortNumber;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SMTPServerFQDN
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSMTPServerFQDN;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  NTLM
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNtlm;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Anonymous
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAnonymous;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  WindowsIntegrated
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedWindowsIntegrated;

            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
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
            /// Exposes access to the OK translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Cancel translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
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
                        cachedPortNumber = CoreManager.MomConsole.GetIntlStr(ResourcePortNumber);
                    }
                    return cachedPortNumber;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SMTPServerFQDN translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SMTPServerFQDN
            {
                get
                {
                    if ((cachedSMTPServerFQDN == null))
                    {
                        cachedSMTPServerFQDN = CoreManager.MomConsole.GetIntlStr(ResourceSMTPServerFQDN);
                    }
                    return cachedSMTPServerFQDN;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NTLM translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Ntlm
            {
                get
                {
                    if ((cachedNtlm == null))
                    {
                        cachedNtlm = CoreManager.MomConsole.GetIntlStr(ResourceNtlm);
                    }
                    return cachedNtlm;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Anonymous translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 4/5/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Anonymous
            {
                get
                {
                    if ((cachedAnonymous == null))
                    {
                        cachedAnonymous = CoreManager.MomConsole.GetIntlStr(ResourceAnonymous);
                    }
                    return cachedAnonymous;
                }
            }

            /// <summary>
            /// Returns a string containing the default SMTP port number
            /// </summary>
            public static string DefaultPortNumber
            {
                get
                {
                    return AddSmtpServerDialog.DefaultPort.ToString(
                        System.Globalization.CultureInfo.InvariantCulture);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowsIntegrated translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 11/9/2006 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsIntegrated
            {
                get
                {
                    if ((cachedWindowsIntegrated == null))
                    {
                        cachedWindowsIntegrated = CoreManager.MomConsole.GetIntlStr(ResourceWindowsIntegrated);
                    }
                    return cachedWindowsIntegrated;
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
        /// 	[KellyMor] 4/5/2006 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "ok";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancel";
            
            /// <summary>
            /// Control ID for AuthenticationMethodComboBox
            /// </summary>
            public const string AuthenticationMethodComboBox = "authentication";
            
            /// <summary>
            /// Control ID for PortNumberTextBox
            /// </summary>
            public const string PortNumberTextBox = "portNumber";
            
            /// <summary>
            /// Control ID for AuthenticationMethodStaticControl
            /// </summary>
            public const string AuthenticationMethodStaticControl = "authenticationLabel";
            
            /// <summary>
            /// Control ID for PortNumberStaticControl
            /// </summary>
            public const string PortNumberStaticControl = "portLabel";
            
            /// <summary>
            /// Control ID for SMTPServerFQDNTextBox
            /// </summary>
            public const string SMTPServerFQDNTextBox = "serverAddress";
            
            /// <summary>
            /// Control ID for SMTPServerFQDNStaticControl
            /// </summary>
            public const string SMTPServerFQDNStaticControl = "nameLabel";
        }
        #endregion
    }
}
