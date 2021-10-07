// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConnectionStringPropertiesDialog.cs">
// 	Copyright (c) Microsoft Corporation 2007
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[faizalk] 5/4/2007 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.OleDb.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Radio Group Enumeration - Tab1

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Enum for radio group Tab1
    /// </summary>
    /// <history>
    /// 	[faizalk] 5/4/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public enum Tab1
    {
        /// <summary>
        /// SimpleConfiguration = 0
        /// </summary>
        SimpleConfiguration = 0,
        
        /// <summary>
        /// AdvancedConfiguration = 1
        /// </summary>
        AdvancedConfiguration = 1,
    }
    #endregion
    
    #region Interface Definition - IConnectionStringPropertiesDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IConnectionStringPropertiesDialogControls, for ConnectionStringPropertiesDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[faizalk] 5/4/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IConnectionStringPropertiesDialogControls
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
        /// Read-only property to access SimpleConfigurationRadioButton
        /// </summary>
        RadioButton SimpleConfigurationRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProviderComboBox
        /// </summary>
        ComboBox ProviderComboBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ProviderStaticControl
        /// </summary>
        StaticControl ProviderStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IPAddressOrDeviceNameTextBox
        /// </summary>
        TextBox IPAddressOrDeviceNameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access IPAddressOrDeviceNameStaticControl
        /// </summary>
        StaticControl IPAddressOrDeviceNameStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DatabaseTextBox
        /// </summary>
        TextBox DatabaseTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access DatabaseStaticControl
        /// </summary>
        StaticControl DatabaseStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access AdvancedConfigurationRadioButton
        /// </summary>
        RadioButton AdvancedConfigurationRadioButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConnectionStringTextBox
        /// </summary>
        TextBox ConnectionStringTextBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ConnectionStringStaticControl
        /// </summary>
        StaticControl ConnectionStringStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TestButton
        /// </summary>
        Button TestButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access TestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl
        /// </summary>
        StaticControl TestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RequestProcessedSuccessfullyStaticControl
        /// </summary>
        StaticControl RequestProcessedSuccessfullyStaticControl
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
    /// 	[faizalk] 5/4/2007 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class ConnectionStringPropertiesDialog : Dialog, IConnectionStringPropertiesDialogControls
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
        /// Cache to hold a reference to SimpleConfigurationRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedSimpleConfigurationRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to ProviderComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedProviderComboBox;
        
        /// <summary>
        /// Cache to hold a reference to ProviderStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedProviderStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to IPAddressOrDeviceNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedIPAddressOrDeviceNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to IPAddressOrDeviceNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedIPAddressOrDeviceNameStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to DatabaseTextBox of type TextBox
        /// </summary>
        private TextBox cachedDatabaseTextBox;
        
        /// <summary>
        /// Cache to hold a reference to DatabaseStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedDatabaseStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to AdvancedConfigurationRadioButton of type RadioButton
        /// </summary>
        private RadioButton cachedAdvancedConfigurationRadioButton;
        
        /// <summary>
        /// Cache to hold a reference to ConnectionStringTextBox of type TextBox
        /// </summary>
        private TextBox cachedConnectionStringTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ConnectionStringStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedConnectionStringStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to TestButton of type Button
        /// </summary>
        private Button cachedTestButton;
        
        /// <summary>
        /// Cache to hold a reference to TestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedTestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to RequestProcessedSuccessfullyStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRequestProcessedSuccessfullyStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of ConnectionStringPropertiesDialog of type MomConsoleApp
        /// </param>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public ConnectionStringPropertiesDialog(MomConsoleApp app) : 
                base(app, Init(app))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region Radio Group Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Functionality for radio group Tab1
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual Tab1 Tab1
        {
            get
            {
                if ((this.Controls.SimpleConfigurationRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Tab1.SimpleConfiguration;
                }
                
                if ((this.Controls.AdvancedConfigurationRadioButton.ButtonState == ButtonState.Checked))
                {
                    return Tab1.AdvancedConfiguration;
                }
                
                throw new RadioButton.Exceptions.CheckFailedException("No radio button selected.");
            }
            
            set
            {
                if ((value == Tab1.SimpleConfiguration))
                {
                    this.Controls.SimpleConfigurationRadioButton.ButtonState = ButtonState.Checked;
                }
                else
                {
                    if ((value == Tab1.AdvancedConfiguration))
                    {
                        this.Controls.AdvancedConfigurationRadioButton.ButtonState = ButtonState.Checked;
                    }
                }
            }
        }
        #endregion
        
        #region IConnectionStringPropertiesDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IConnectionStringPropertiesDialogControls Controls
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
        ///  Routine to set/get the text in control Provider
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ProviderText
        {
            get
            {
                return this.Controls.ProviderComboBox.Text;
            }
            
            set
            {
                this.Controls.ProviderComboBox.SelectByText(value, true);
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control IPAddressOrDeviceName
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string IPAddressOrDeviceNameText
        {
            get
            {
                return this.Controls.IPAddressOrDeviceNameTextBox.Text;
            }
            
            set
            {
                this.Controls.IPAddressOrDeviceNameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control Database
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DatabaseText
        {
            get
            {
                return this.Controls.DatabaseTextBox.Text;
            }
            
            set
            {
                this.Controls.DatabaseTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control ConnectionString
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ConnectionStringText
        {
            get
            {
                return this.Controls.ConnectionStringTextBox.Text;
            }
            
            set
            {
                this.Controls.ConnectionStringTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ApplyButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConnectionStringPropertiesDialogControls.ApplyButton
        {
            get
            {
                if ((this.cachedApplyButton == null))
                {
                    this.cachedApplyButton = new Button(this, ConnectionStringPropertiesDialog.ControlIDs.ApplyButton);
                }
                
                return this.cachedApplyButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConnectionStringPropertiesDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, ConnectionStringPropertiesDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConnectionStringPropertiesDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, ConnectionStringPropertiesDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the Tab1TabControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TabControl IConnectionStringPropertiesDialogControls.Tab1TabControl
        {
            get
            {
                if ((this.cachedTab1TabControl == null))
                {
                    this.cachedTab1TabControl = new TabControl(this, ConnectionStringPropertiesDialog.ControlIDs.Tab1TabControl);
                }
                
                return this.cachedTab1TabControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the SimpleConfigurationRadioButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IConnectionStringPropertiesDialogControls.SimpleConfigurationRadioButton
        {
            get
            {
                if ((this.cachedSimpleConfigurationRadioButton == null))
                {
                    this.cachedSimpleConfigurationRadioButton = new RadioButton(this, ConnectionStringPropertiesDialog.ControlIDs.SimpleConfigurationRadioButton);
                }
                
                return this.cachedSimpleConfigurationRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProviderComboBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IConnectionStringPropertiesDialogControls.ProviderComboBox
        {
            get
            {
                if ((this.cachedProviderComboBox == null))
                {
                    this.cachedProviderComboBox = new ComboBox(this, ConnectionStringPropertiesDialog.ControlIDs.ProviderComboBox);
                }
                
                return this.cachedProviderComboBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ProviderStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConnectionStringPropertiesDialogControls.ProviderStaticControl
        {
            get
            {
                if ((this.cachedProviderStaticControl == null))
                {
                    this.cachedProviderStaticControl = new StaticControl(this, ConnectionStringPropertiesDialog.ControlIDs.ProviderStaticControl);
                }
                
                return this.cachedProviderStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IPAddressOrDeviceNameTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IConnectionStringPropertiesDialogControls.IPAddressOrDeviceNameTextBox
        {
            get
            {
                if ((this.cachedIPAddressOrDeviceNameTextBox == null))
                {
                    this.cachedIPAddressOrDeviceNameTextBox = new TextBox(this, ConnectionStringPropertiesDialog.ControlIDs.IPAddressOrDeviceNameTextBox);
                }
                
                return this.cachedIPAddressOrDeviceNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the IPAddressOrDeviceNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConnectionStringPropertiesDialogControls.IPAddressOrDeviceNameStaticControl
        {
            get
            {
                if ((this.cachedIPAddressOrDeviceNameStaticControl == null))
                {
                    this.cachedIPAddressOrDeviceNameStaticControl = new StaticControl(this, ConnectionStringPropertiesDialog.ControlIDs.IPAddressOrDeviceNameStaticControl);
                }
                
                return this.cachedIPAddressOrDeviceNameStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DatabaseTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IConnectionStringPropertiesDialogControls.DatabaseTextBox
        {
            get
            {
                if ((this.cachedDatabaseTextBox == null))
                {
                    this.cachedDatabaseTextBox = new TextBox(this, ConnectionStringPropertiesDialog.ControlIDs.DatabaseTextBox);
                }
                
                return this.cachedDatabaseTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the DatabaseStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConnectionStringPropertiesDialogControls.DatabaseStaticControl
        {
            get
            {
                if ((this.cachedDatabaseStaticControl == null))
                {
                    this.cachedDatabaseStaticControl = new StaticControl(this, ConnectionStringPropertiesDialog.ControlIDs.DatabaseStaticControl);
                }
                
                return this.cachedDatabaseStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AdvancedConfigurationRadioButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        RadioButton IConnectionStringPropertiesDialogControls.AdvancedConfigurationRadioButton
        {
            get
            {
                if ((this.cachedAdvancedConfigurationRadioButton == null))
                {
                    this.cachedAdvancedConfigurationRadioButton = new RadioButton(this, ConnectionStringPropertiesDialog.ControlIDs.AdvancedConfigurationRadioButton);
                }
                
                return this.cachedAdvancedConfigurationRadioButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConnectionStringTextBox control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IConnectionStringPropertiesDialogControls.ConnectionStringTextBox
        {
            get
            {
                if ((this.cachedConnectionStringTextBox == null))
                {
                    this.cachedConnectionStringTextBox = new TextBox(this, ConnectionStringPropertiesDialog.ControlIDs.ConnectionStringTextBox);
                }
                
                return this.cachedConnectionStringTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ConnectionStringStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConnectionStringPropertiesDialogControls.ConnectionStringStaticControl
        {
            get
            {
                if ((this.cachedConnectionStringStaticControl == null))
                {
                    this.cachedConnectionStringStaticControl = new StaticControl(this, ConnectionStringPropertiesDialog.ControlIDs.ConnectionStringStaticControl);
                }
                
                return this.cachedConnectionStringStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TestButton control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IConnectionStringPropertiesDialogControls.TestButton
        {
            get
            {
                if ((this.cachedTestButton == null))
                {
                    this.cachedTestButton = new Button(this, ConnectionStringPropertiesDialog.ControlIDs.TestButton);
                }
                
                return this.cachedTestButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the TestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConnectionStringPropertiesDialogControls.TestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl
        {
            get
            {
                if ((this.cachedTestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl == null))
                {
                    this.cachedTestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl = new StaticControl(this, ConnectionStringPropertiesDialog.ControlIDs.TestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl);
                }
                
                return this.cachedTestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RequestProcessedSuccessfullyStaticControl control
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IConnectionStringPropertiesDialogControls.RequestProcessedSuccessfullyStaticControl
        {
            get
            {
                if ((this.cachedRequestProcessedSuccessfullyStaticControl == null))
                {
                    this.cachedRequestProcessedSuccessfullyStaticControl = new StaticControl(this, ConnectionStringPropertiesDialog.ControlIDs.RequestProcessedSuccessfullyStaticControl);
                }
                
                return this.cachedRequestProcessedSuccessfullyStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Apply
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
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
        /// 	[faizalk] 5/4/2007 Created
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
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Test
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickTest()
        {
            this.Controls.TestButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        ///  <param name="app">MomConsoleApp owning the dialog.</param>)
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow) 
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
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
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[faizalk] 5/4/2007 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants
            
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Tab1
            /// </summary>
            /// <remark>
            /// TODO: DialogMaker could not find the resource for this string.  Find it and replace literal created by tool.
            /// </remark>
            /// -----------------------------------------------------------------------------
            private const string ResourceTab1 = "Tab1";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  SimpleConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceSimpleConfiguration = ";&Simple Configuration;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring." +
                "dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseOleDbConfig" +
                "Page;radioButtonSimpleConfig.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Provider
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceProvider = ";P&rovider:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseOleDbConfigPage;lblPro" +
                "vider.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IPAddressOrDeviceName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIPAddressOrDeviceName = ";&IP address or device name:;ManagedString;Microsoft.EnterpriseManagement.UI.Auth" +
                "oring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ServerNameA" +
                "ndPortPage;labelIPAddress.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Database
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDatabase = ";&Database:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microso" +
                "ft.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseOleDbConfigPage;lblDat" +
                "abase.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AdvancedConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdvancedConfiguration = ";&Advanced Configuration;ManagedString;Microsoft.EnterpriseManagement.UI.Authorin" +
                "g.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseOleDbConf" +
                "igPage;radioButtonAdvancedConfig.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ConnectionString
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConnectionString = ";&Connection String:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dl" +
                "l;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.ChooseOleDbConfigPa" +
                "ge;lblConnectionString.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Test
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTest = ";&Test;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.En" +
                "terpriseManagement.Internal.UI.Authoring.Pages.ChooseURLPage;buttonTest.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  TestConnectivityUsingOLEDBProviderToDatabasesEtc
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceTestConnectivityUsingOLEDBProviderToDatabasesEtc = ";Test Connectivity using OLE-DB Provider to databases, etc.;ManagedString;Microso" +
                "ft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal" +
                ".UI.Authoring.Pages.ChooseOleDbConfigPage;lblPageSection.Text";
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  RequestProcessedSuccessfully
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceRequestProcessedSuccessfully = ";Request processed successfully;ManagedString;Microsoft.EnterpriseManagement.UI.A" +
                "uthoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.TCPPortC" +
                "heckTemplate.TCPPortCheckTemplateResource;StatusSuccess";
            #endregion
            
            #region Private Members
            
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
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tab1
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTab1;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  SimpleConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSimpleConfiguration;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Provider
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedProvider;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  IPAddressOrDeviceName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIPAddressOrDeviceName;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Database
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDatabase;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AdvancedConfiguration
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdvancedConfiguration;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  ConnectionString
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConnectionString;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Test
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTest;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  TestConnectivityUsingOLEDBProviderToDatabasesEtc
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTestConnectivityUsingOLEDBProviderToDatabasesEtc;
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  RequestProcessedSuccessfully
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRequestProcessedSuccessfully;
            #endregion
            
            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/4/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {                   
                    return Templates.Strings.DialogTitle;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Apply translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/4/2007 Created
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
            /// 	[faizalk] 5/4/2007 Created
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
            /// 	[faizalk] 5/4/2007 Created
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
            /// Exposes access to the Tab1 translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/4/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Tab1
            {
                get
                {
                    if ((cachedTab1 == null))
                    {
                        cachedTab1 = CoreManager.MomConsole.GetIntlStr(ResourceTab1);
                    }
                    
                    return cachedTab1;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SimpleConfiguration translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/4/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SimpleConfiguration
            {
                get
                {
                    if ((cachedSimpleConfiguration == null))
                    {
                        cachedSimpleConfiguration = CoreManager.MomConsole.GetIntlStr(ResourceSimpleConfiguration);
                    }
                    
                    return cachedSimpleConfiguration;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Provider translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/4/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Provider
            {
                get
                {
                    if ((cachedProvider == null))
                    {
                        cachedProvider = CoreManager.MomConsole.GetIntlStr(ResourceProvider);
                    }
                    
                    return cachedProvider;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the IPAddressOrDeviceName translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/4/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IPAddressOrDeviceName
            {
                get
                {
                    if ((cachedIPAddressOrDeviceName == null))
                    {
                        cachedIPAddressOrDeviceName = CoreManager.MomConsole.GetIntlStr(ResourceIPAddressOrDeviceName);
                    }
                    
                    return cachedIPAddressOrDeviceName;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Database translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/4/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Database
            {
                get
                {
                    if ((cachedDatabase == null))
                    {
                        cachedDatabase = CoreManager.MomConsole.GetIntlStr(ResourceDatabase);
                    }
                    
                    return cachedDatabase;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdvancedConfiguration translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/4/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdvancedConfiguration
            {
                get
                {
                    if ((cachedAdvancedConfiguration == null))
                    {
                        cachedAdvancedConfiguration = CoreManager.MomConsole.GetIntlStr(ResourceAdvancedConfiguration);
                    }
                    
                    return cachedAdvancedConfiguration;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConnectionString translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/4/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConnectionString
            {
                get
                {
                    if ((cachedConnectionString == null))
                    {
                        cachedConnectionString = CoreManager.MomConsole.GetIntlStr(ResourceConnectionString);
                    }
                    
                    return cachedConnectionString;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Test translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/4/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string Test
            {
                get
                {
                    if ((cachedTest == null))
                    {
                        cachedTest = CoreManager.MomConsole.GetIntlStr(ResourceTest);
                    }
                    
                    return cachedTest;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TestConnectivityUsingOLEDBProviderToDatabasesEtc translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/4/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TestConnectivityUsingOLEDBProviderToDatabasesEtc
            {
                get
                {
                    if ((cachedTestConnectivityUsingOLEDBProviderToDatabasesEtc == null))
                    {
                        cachedTestConnectivityUsingOLEDBProviderToDatabasesEtc = CoreManager.MomConsole.GetIntlStr(ResourceTestConnectivityUsingOLEDBProviderToDatabasesEtc);
                    }
                    
                    return cachedTestConnectivityUsingOLEDBProviderToDatabasesEtc;
                }
            }
            
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RequestProcessedSuccessfully translated resource string
            /// </summary>
            /// <history>
            /// 	[faizalk] 5/4/2007 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RequestProcessedSuccessfully
            {
                get
                {
                    if ((cachedRequestProcessedSuccessfully == null))
                    {
                        cachedRequestProcessedSuccessfully = CoreManager.MomConsole.GetIntlStr(ResourceRequestProcessedSuccessfully);
                    }
                    
                    return cachedRequestProcessedSuccessfully;
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
        /// 	[faizalk] 5/4/2007 Created
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
            /// Control ID for SimpleConfigurationRadioButton
            /// </summary>
            public const string SimpleConfigurationRadioButton = "radioButtonSimpleConfig";
            
            /// <summary>
            /// Control ID for ProviderComboBox
            /// </summary>
            public const string ProviderComboBox = "comboBoxProvider";
            
            /// <summary>
            /// Control ID for ProviderStaticControl
            /// </summary>
            public const string ProviderStaticControl = "lblProvider";
            
            /// <summary>
            /// Control ID for IPAddressOrDeviceNameTextBox
            /// </summary>
            public const string IPAddressOrDeviceNameTextBox = "textBoxServerName";
            
            /// <summary>
            /// Control ID for IPAddressOrDeviceNameStaticControl
            /// </summary>
            public const string IPAddressOrDeviceNameStaticControl = "lblIPAddress";
            
            /// <summary>
            /// Control ID for DatabaseTextBox
            /// </summary>
            public const string DatabaseTextBox = "textBoxDatabase";
            
            /// <summary>
            /// Control ID for DatabaseStaticControl
            /// </summary>
            public const string DatabaseStaticControl = "lblDatabase";
            
            /// <summary>
            /// Control ID for AdvancedConfigurationRadioButton
            /// </summary>
            public const string AdvancedConfigurationRadioButton = "radioButtonAdvancedConfig";
            
            /// <summary>
            /// Control ID for ConnectionStringTextBox
            /// </summary>
            public const string ConnectionStringTextBox = "textBoxConnectionString";
            
            /// <summary>
            /// Control ID for ConnectionStringStaticControl
            /// </summary>
            public const string ConnectionStringStaticControl = "lblConnectionString";
            
            /// <summary>
            /// Control ID for TestButton
            /// </summary>
            public const string TestButton = "buttonTest";
            
            /// <summary>
            /// Control ID for TestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl
            /// </summary>
            public const string TestConnectivityUsingOLEDBProviderToDatabasesEtcStaticControl = "lblPageSection";
            
            /// <summary>
            /// Control ID for RequestProcessedSuccessfullyStaticControl
            /// </summary>
            public const string RequestProcessedSuccessfullyStaticControl = "labelStatus";
        }
        #endregion
    }
}
