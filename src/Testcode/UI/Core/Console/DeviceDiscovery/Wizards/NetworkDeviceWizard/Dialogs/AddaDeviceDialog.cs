// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AddaDeviceDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [dialac] 5/01/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.NetworkDeviceWizard.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - IAddaDeviceDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAddaDeviceDialogControls, for AddaDeviceDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [dialac] 5/01/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddaDeviceDialogControls
    {
        /// <summary>
        /// Gets read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access PortNumberComboBox
        /// </summary>
        ComboBox PortNumberComboBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access AddSNMPV1OrV2RunAsAccountButton
        /// </summary>
        Button AddSNMPV1OrV2RunAsAccountButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SNMPV1OrV2RunAsAccountComboBox
        /// </summary>
        ComboBox SNMPV1OrV2RunAsAccountComboBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SpecifyTheSettingsForTheNetworkDeviceYouWantToDiscoverTextBox
        /// </summary>
        TextBox DnsNameOrIPAddressTextBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SNMPVersionComboBox
        /// </summary>
        ComboBox SNMPVersionComboBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access AccessModeComboBox
        /// </summary>
        ComboBox AccessModeComboBox
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
    ///   [dialac] 5/01/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class AddaDeviceDialog : Dialog, IAddaDeviceDialogControls
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to PortNumberComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedPortNumberComboBox;
        
        /// <summary>
        /// Cache to hold a reference to AddSNMPV1OrV2RunAsAccountButton of type Button
        /// </summary>
        private Button cachedAddSNMPV1OrV2RunAsAccountButton;
        
        /// <summary>
        /// Cache to hold a reference to SNMPV1OrV2RunAsAccountComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSNMPV1OrV2RunAsAccountComboBox;
        
        /// <summary>
        /// Cache to hold a reference to DnsNameOrIPAddressTextBox of type TextBox
        /// </summary>
        private TextBox cachedDnsNameOrIPAddressTextBox;
        
        /// <summary>
        /// Cache to hold a reference to SNMPVersionComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedSNMPVersionComboBox;
        
        /// <summary>
        /// Cache to hold a reference to AccessModeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedAccessModeComboBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the AddaDeviceDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of AddaDeviceDialog of type MomConsoleApp
        /// </param>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AddaDeviceDialog(MomConsoleApp app, int timeout) : 
                base(app, Init(app, timeout))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAddaDeviceDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAddaDeviceDialogControls Controls
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
        ///  Gets or sets the text in control PortNumber
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string PortNumberText
        {
            get
            {
                return this.Controls.PortNumberComboBox.Text;
            }
            
            set
            {
                this.Controls.PortNumberComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control SNMPV1OrV2RunAsAccount
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SNMPV1OrV2RunAsAccountText
        {
            get
            {
                return this.Controls.SNMPV1OrV2RunAsAccountComboBox.Text;
            }
            
            set
            {
                this.Controls.SNMPV1OrV2RunAsAccountComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control SpecifyTheSettingsForTheNetworkDeviceYouWantToDiscover
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DnsNameOrIPAddressTextBox
        {
            get
            {
                return this.Controls.DnsNameOrIPAddressTextBox.Text;
            }
            
            set
            {
                this.Controls.DnsNameOrIPAddressTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control SNMPVersion
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SNMPVersionText
        {
            get
            {
                return this.Controls.SNMPVersionComboBox.Text;
            }
            
            set
            {
                this.Controls.SNMPVersionComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control AccessMode
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string AccessModeText
        {
            get
            {
                return this.Controls.AccessModeComboBox.Text;
            }
            
            set
            {
                this.Controls.AccessModeComboBox.SelectByText(value, true);
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddaDeviceDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AddaDeviceDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the OKButton control
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddaDeviceDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AddaDeviceDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the PortNumberComboBox control
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAddaDeviceDialogControls.PortNumberComboBox
        {
            get
            {
                if ((this.cachedPortNumberComboBox == null))
                {
                    this.cachedPortNumberComboBox = new ComboBox(this, AddaDeviceDialog.ControlIDs.PortNumberComboBox);
                }
                
                return this.cachedPortNumberComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AddSNMPV1OrV2RunAsAccountButton control
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddaDeviceDialogControls.AddSNMPV1OrV2RunAsAccountButton
        {
            get
            {
                if ((this.cachedAddSNMPV1OrV2RunAsAccountButton == null))
                {
                    this.cachedAddSNMPV1OrV2RunAsAccountButton = new Button(this, AddaDeviceDialog.ControlIDs.AddSNMPV1OrV2RunAsAccountButton);
                }
                
                return this.cachedAddSNMPV1OrV2RunAsAccountButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SNMPV1OrV2RunAsAccountComboBox control
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAddaDeviceDialogControls.SNMPV1OrV2RunAsAccountComboBox
        {
            get
            {
                if ((this.cachedSNMPV1OrV2RunAsAccountComboBox == null))
                {
                    this.cachedSNMPV1OrV2RunAsAccountComboBox = new ComboBox(this, AddaDeviceDialog.ControlIDs.SNMPV1OrV2RunAsAccountComboBox);
                }

                #region Add a delay code section for updating completely (fix bug#206777)
                int tryCount = 0;
                while (tryCount++ < 3)
                {
                    if (this.cachedSNMPV1OrV2RunAsAccountComboBox.Count > 0)
                    {
                        break;
                    }
                    Sleeper.Delay(Core.Common.Constants.OneSecond);
                }
                #endregion

                return this.cachedSNMPV1OrV2RunAsAccountComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DnsNameOrIPAddressTextBox control
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddaDeviceDialogControls.DnsNameOrIPAddressTextBox
        {
            get
            {
                if ((this.cachedDnsNameOrIPAddressTextBox == null))
                {
                    this.cachedDnsNameOrIPAddressTextBox = new TextBox(this, AddaDeviceDialog.ControlIDs.DnsNameOrIPAddressTextBox);
                }
                
                return this.cachedDnsNameOrIPAddressTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SNMPVersionComboBox control
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAddaDeviceDialogControls.SNMPVersionComboBox
        {
            get
            {
                if ((this.cachedSNMPVersionComboBox == null))
                {
                    this.cachedSNMPVersionComboBox = new ComboBox(this, AddaDeviceDialog.ControlIDs.SNMPVersionComboBox);
                }
                
                return this.cachedSNMPVersionComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the AccessModeComboBox control
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IAddaDeviceDialogControls.AccessModeComboBox
        {
            get
            {
                if ((this.cachedAccessModeComboBox == null))
                {
                    this.cachedAccessModeComboBox = new ComboBox(this, AddaDeviceDialog.ControlIDs.AccessModeComboBox);
                }
                
                return this.cachedAccessModeComboBox;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
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
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button AddSNMPV1OrV2RunAsAccount
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickAddSNMPV1OrV2RunAsAccount()
        {
            this.Controls.AddSNMPV1OrV2RunAsAccountButton.Click();
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
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app, int timeout)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle_AddDevice, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 10;

                string temp = Strings.DialogTitle_AddDevice;
                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow)
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Init window with title: " + temp);
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(temp, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);

                        if (temp == Strings.DialogTitle_AddDevice)   //deal with different dialog title.
                            temp = Strings.DialogTitle_DevcieSettings;
                        else
                            temp = Strings.DialogTitle_AddDevice;

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(timeout);
                    }
                }

                // check for success
                if ((null == tempWindow))
                {
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
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for PortNumberComboBox
            /// </summary>
            public const string PortNumberComboBox = "portNumberNumericUpDown";
            
            /// <summary>
            /// Control ID for AddSNMPV1OrV2RunAsAccountButton
            /// </summary>
            public const string AddSNMPV1OrV2RunAsAccountButton = "addRunAsAccountButton";
            
            /// <summary>
            /// Control ID for SNMPV1OrV2RunAsAccountComboBox
            /// </summary>
            public const string SNMPV1OrV2RunAsAccountComboBox = "runAsAccountComboBox";
            
            /// <summary>
            /// Control ID for DnsNameOrIPAddressTextBox
            /// </summary>
            public const string DnsNameOrIPAddressTextBox = "dnsNameOrIPAddressTextBox";
            
            /// <summary>
            /// Control ID for SNMPVersionComboBox
            /// </summary>
            public const string SNMPVersionComboBox = "snmpVersionComboBox";
            
            /// <summary>
            /// Control ID for AccessModeComboBox
            /// </summary>
            public const string AccessModeComboBox = "discoveryProtocolComboBox";
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [dialac] 5/01/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the window or dialog title :  Add a device
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDialogTitle_AddDevice = ";Add Device;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AddDeviceDialogText_Add";

            /// <summary>
            ///  Contains resource string for the window or dialog title 2:  Device Settings
            /// </summary>
            private const string ResourceDialogTitle_DeviceSetting = ";Device Settings;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AddDeviceDialogText_Edit";
           
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Cancel
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceCancel = ";Cancel;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.resources." +
                "dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndI" +
                "nstall.MPDownloadInstallResources;Cancel";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  OK
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceOK = ";OK;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInsta" +
                "ll.Dialogs.MPCategoryPropertiesDialog;okButton.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddSNMPV1OrV2RunAsAccount
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddSNMPV1OrV2RunAsAccount = ";&Add SNMP V1 or V2 Run As Account;ManagedString;Microsoft.EnterpriseManagement.U" +
                "I.Administration.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Ad" +
                "ministration.AdminResources;AddDeviceDialog_AddRunAsAccountButton_V1orV2";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  v1 or v2
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceV1orV2 = ";v1 or v2;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;SnmpVersion_V1orV2";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  v3
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceV3 = ";v3;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;SnmpVersion_V3";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ICMP
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceICMP = ";ICMP;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;DiscoveryProtocol_ICMP";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ICMP or SNMP
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceICMPorSNMP = ";ICMP and SNMP;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;DiscoveryProtocol_ICMP_SNMP";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SNMP
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSNMP = ";SNMP;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;DiscoveryProtocol_SNMP";
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/01/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle_AddDevice
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle_AddDevice);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [v-dayow] 6/08/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle_DevcieSettings
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle_DeviceSetting);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Cancel translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/01/2010 Created
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
            /// Gets access to the OK translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/01/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OK
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceOK);
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the AddSNMPV1OrV2RunAsAccount translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/01/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddSNMPV1OrV2RunAsAccount
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceAddSNMPV1OrV2RunAsAccount);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to resource string
            /// </summary>
            /// <history>
            ///   [v-dayow] 6/07/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string V1orV2
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceV1orV2);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to resource string
            /// </summary>
            /// <history>
            ///   [v-dayow] 6/07/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string V3
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceV3);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to resource string
            /// </summary>
            /// <history>
            ///   [v-dayow] 6/07/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ICMP
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceICMP);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to resource string
            /// </summary>
            /// <history>
            ///   [v-dayow] 6/07/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SNMP
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceSNMP);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to resource string
            /// </summary>
            /// <history>
            ///   [v-dayow] 6/07/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ICMPorSNMP
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceICMPorSNMP);
                }
            }
            #endregion
        }
        #endregion
    }
}
