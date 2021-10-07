// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AdvancedDiscoverySettingsDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-dayow] 10/25/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.NetworkDeviceWizard.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - IAdvancedDiscoverySettingsDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAdvancedDiscoverySettingsDialogControls, for AdvancedDiscoverySettingsDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-dayow] 10/25/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAdvancedDiscoverySettingsDialogControls
    {
        /// <summary>
        /// Gets read-only property to access MaximumNumberOfDevicesToDiscoverComboBox
        /// </summary>
       

        TextBox MaximumNumberOfDevicesToDiscoverTextBox
        {
            get;
        }
        /// <summary>
        /// Gets read-only property to access ARPTableCheckBox
        /// </summary>
        CheckBox ARPTableCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access IPAddressTableCheckBox
        /// </summary>
        CheckBox IPAddressTableCheckBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access TopologyMIBsCheckBox
        /// </summary>
        CheckBox TopologyMIBsCheckBox
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
        /// Gets read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access NumberOfRetryAttemptsComboBox
        /// </summary>
       
        TextBox NumberOfRetryAttemptsTextBox
        {
            get;
        }
        /// <summary>
        /// Gets read-only property to access SNMPTimeOutInMillisecondsComboBox
        /// </summary>
       

        TextBox SNMPTimeOutInMillisecondsTextBox
        {
            get;
        }
        /// <summary>
        /// Gets read-only property to access ICMPTimeOutInMillisecondsComboBox
        /// </summary>
       
        TextBox ICMPTimeOutInMillisecondsTextBox
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
    ///   [v-dayow] 10/25/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class AdvancedDiscoverySettingsDialog : Dialog, IAdvancedDiscoverySettingsDialogControls
    {
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to MaximumNumberOfDevicesToDiscoverComboBox of type ComboBox
        /// </summary>
  
        private TextBox cachedMaximumNumberOfDevicesToDiscoverTextBox;
        /// <summary>
        /// Cache to hold a reference to ARPTableCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedARPTableCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to IPAddressTableCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedIPAddressTableCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to TopologyMIBsCheckBox of type CheckBox
        /// </summary>
        private CheckBox cachedTopologyMIBsCheckBox;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to NumberOfRetryAttemptsComboBox of type ComboBox
        /// </summary>
     
        private TextBox cachedNumberOfRetryAttemptsTextBox;
        /// <summary>
        /// Cache to hold a reference to SNMPTimeOutInMillisecondsComboBox of type ComboBox
        /// </summary>
 
        private TextBox cachedSNMPTimeOutInMillisecondsTextBox;
        /// <summary>
        /// Cache to hold a reference to ICMPTimeOutInMillisecondsComboBox of type ComboBox
        /// </summary>

        private TextBox cachedICMPTimeOutInMillisecondsTextBox;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the AdvancedDiscoverySettingsDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of AdvancedDiscoverySettingsDialog of type App
        /// </param>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AdvancedDiscoverySettingsDialog(MomConsoleApp app, int timeout) : 
                base(app, Init(app, timeout))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAdvancedDiscoverySettingsDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAdvancedDiscoverySettingsDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Checkbox Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox ARPTable
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool ARPTable
        {
            get
            {
                return this.Controls.ARPTableCheckBox.Checked;
            }
            
            set
            {
                this.Controls.ARPTableCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox IPAddressTable
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool IPAddressTable
        {
            get
            {
                return this.Controls.IPAddressTableCheckBox.Checked;
            }
            
            set
            {
                this.Controls.IPAddressTableCheckBox.Checked = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Property to handle checkbox TopologyMIBs
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual bool TopologyMIBs
        {
            get
            {
                return this.Controls.TopologyMIBsCheckBox.Checked;
            }
            
            set
            {
                this.Controls.TopologyMIBsCheckBox.Checked = value;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control MaximumNumberOfDevicesToDiscover
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string MaximumNumberOfDevicesToDiscoverText
        {
            get
            {
                return this.Controls.MaximumNumberOfDevicesToDiscoverTextBox.Text;
            }
            
            set
            {
                this.Controls.MaximumNumberOfDevicesToDiscoverTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control NumberOfRetryAttempts
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NumberOfRetryAttemptsText
        {
            get
            {
                return this.Controls.NumberOfRetryAttemptsTextBox.Text;
            }
            
            set
            {
                this.Controls.NumberOfRetryAttemptsTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control SNMPTimeOutInMilliseconds
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SNMPTimeOutInMillisecondsText
        {
            get
            {
                return this.Controls.SNMPTimeOutInMillisecondsTextBox.Text;
            }
            
            set
            {
                this.Controls.SNMPTimeOutInMillisecondsTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control ICMPTimeOutInMilliseconds
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ICMPTimeOutInMillisecondsText
        {
            get
            {
                return this.Controls.ICMPTimeOutInMillisecondsTextBox.Text;
            }
            
            set
            {
                this.Controls.ICMPTimeOutInMillisecondsTextBox.Text = value;
            }
        }
       
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the MaximumNumberOfDevicesToDiscoverComboBox control
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAdvancedDiscoverySettingsDialogControls.MaximumNumberOfDevicesToDiscoverTextBox
        {
            get
            {
                if ((this.cachedMaximumNumberOfDevicesToDiscoverTextBox == null))
                {
                    this.cachedMaximumNumberOfDevicesToDiscoverTextBox = new TextBox(this, AdvancedDiscoverySettingsDialog.ControlIDs.MaximumNumberOfDevicesToDiscoverComboBox);
                }

                return this.cachedMaximumNumberOfDevicesToDiscoverTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ARPTableCheckBox control
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IAdvancedDiscoverySettingsDialogControls.ARPTableCheckBox
        {
            get
            {
                if ((this.cachedARPTableCheckBox == null))
                {
                    this.cachedARPTableCheckBox = new CheckBox(this, AdvancedDiscoverySettingsDialog.ControlIDs.ARPTableCheckBox);
                }
                
                return this.cachedARPTableCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the IPAddressTableCheckBox control
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IAdvancedDiscoverySettingsDialogControls.IPAddressTableCheckBox
        {
            get
            {
                if ((this.cachedIPAddressTableCheckBox == null))
                {
                    this.cachedIPAddressTableCheckBox = new CheckBox(this, AdvancedDiscoverySettingsDialog.ControlIDs.IPAddressTableCheckBox);
                }
                
                return this.cachedIPAddressTableCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the TopologyMIBsCheckBox control
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        CheckBox IAdvancedDiscoverySettingsDialogControls.TopologyMIBsCheckBox
        {
            get
            {
                if ((this.cachedTopologyMIBsCheckBox == null))
                {
                    this.cachedTopologyMIBsCheckBox = new CheckBox(this, AdvancedDiscoverySettingsDialog.ControlIDs.TopologyMIBsCheckBox);
                }
                
                return this.cachedTopologyMIBsCheckBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAdvancedDiscoverySettingsDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AdvancedDiscoverySettingsDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the OKButton control
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAdvancedDiscoverySettingsDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AdvancedDiscoverySettingsDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NumberOfRetryAttemptsComboBox control
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAdvancedDiscoverySettingsDialogControls.NumberOfRetryAttemptsTextBox
        {
            get
            {
                if ((this.cachedNumberOfRetryAttemptsTextBox == null))
                {
                    this.cachedNumberOfRetryAttemptsTextBox = new TextBox(this, AdvancedDiscoverySettingsDialog.ControlIDs.NumberOfRetryAttemptsComboBox);
                }

                return this.cachedNumberOfRetryAttemptsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SNMPTimeOutInMillisecondsComboBox control
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAdvancedDiscoverySettingsDialogControls.SNMPTimeOutInMillisecondsTextBox
        {
            get
            {
                if ((this.cachedSNMPTimeOutInMillisecondsTextBox == null))
                {
                    this.cachedSNMPTimeOutInMillisecondsTextBox = new TextBox(this, AdvancedDiscoverySettingsDialog.ControlIDs.SNMPTimeOutInMillisecondsComboBox);
                }

                return this.cachedSNMPTimeOutInMillisecondsTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ICMPTimeOutInMillisecondsComboBox control
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAdvancedDiscoverySettingsDialogControls.ICMPTimeOutInMillisecondsTextBox
        {
            get
            {
                if ((this.cachedICMPTimeOutInMillisecondsTextBox == null))
                {
                    this.cachedICMPTimeOutInMillisecondsTextBox = new TextBox(this, AdvancedDiscoverySettingsDialog.ControlIDs.ICMPTimeOutInMillisecondsComboBox);
                }

                return this.cachedICMPTimeOutInMillisecondsTextBox;
            }
        }
        
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ARPTable
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickARPTable()
        {
            this.Controls.ARPTableCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button IPAddressTable
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickIPAddressTable()
        {
            this.Controls.IPAddressTableCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button TopologyMIBs
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickTopologyMIBs()
        {
            this.Controls.TopologyMIBsCheckBox.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
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
        ///   [v-dayow] 10/25/2010 Created
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
        /// <param name="timeout">timeout.</param>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(App app, int timeout)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                //tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.WildCard);
                tempWindow = new Window(new QID(";[UIA]AutomationId='AdvancedDiscoverySettingsDialog'"), Common.Constants.DefaultDialogTimeout);
            }
            catch (Exceptions.WindowNotFoundException )
            {
                // TODO:  Add any specific logic here to handle the case when the
                // dialog is not found in the specified timeout.
                // otherwise rethrow the exception.
                throw;
            }
            
            return tempWindow;
        }
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for MaximumNumberOfDevicesToDiscoverComboBox
            /// </summary>
            public const string MaximumNumberOfDevicesToDiscoverComboBox = "discoveryLimitNumericUpDown";
            
            /// <summary>
            /// Control ID for ARPTableCheckBox
            /// </summary>
            public const string ARPTableCheckBox = "arpTableCheckBox";
            
            /// <summary>
            /// Control ID for IPAddressTableCheckBox
            /// </summary>
            public const string IPAddressTableCheckBox = "ipAddressTableCheckBox";
            
            /// <summary>
            /// Control ID for TopologyMIBsCheckBox
            /// </summary>
            public const string TopologyMIBsCheckBox = "topologyMibsCheckBox";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "cancelButton";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "okButton";
            
            /// <summary>
            /// Control ID for NumberOfRetryAttemptsComboBox
            /// </summary>
            public const string NumberOfRetryAttemptsComboBox = "numberOfRetriesNumericUpDown";
            
            /// <summary>
            /// Control ID for SNMPTimeOutInMillisecondsComboBox
            /// </summary>
            public const string SNMPTimeOutInMillisecondsComboBox = "snmpTimeoutNumericUpDown";
            
            /// <summary>
            /// Control ID for ICMPTimeOutInMillisecondsComboBox
            /// </summary>
            public const string ICMPTimeOutInMillisecondsComboBox = "icmpTimeoutNumericUpDown";
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [v-dayow] 10/25/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            /// <summary>
            /// Resource string for Advanced Discovery Settings
            /// </summary>
            private const string ResouceDialogTitle = ";Advanced Discovery Settings;ManagedString;Microsoft.EnterpriseManagement.UI.Admi" +
                "nistration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.Net" +
                "workDiscovery.AdvancedDiscoverySettingsDialog;$this.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [v-dayow] 10/25/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResouceDialogTitle);
                }
            }
        }
        #endregion
    }
}
