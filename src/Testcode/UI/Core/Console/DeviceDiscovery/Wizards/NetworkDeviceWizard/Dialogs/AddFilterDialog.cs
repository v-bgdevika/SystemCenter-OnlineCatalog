// ------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="AddFilterDialog.cs">
//   Copyright (c) Microsoft Corporation 2010
// </copyright>
// <project>
//   TODO:  Enter project title here.
// </project>
// <summary>
//   TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
//   [v-dayow] 6/2/2010 Created
// </history>
// ------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.NetworkDeviceWizard.Dialogs
{
    using System.ComponentModel;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;
    
    #region Interface Definition - IAddFilterDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IAddFilterDialogControls, for AddFilterDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-dayow] 6/2/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IAddFilterDialogControls
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
        /// Gets read-only property to access DescriptionTextBox
        /// </summary>
        TextBox DescriptionTextBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ObjectIDOIDTextBox
        /// </summary>
        TextBox ObjectIDOIDTextBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access NameTextBox
        /// </summary>
        TextBox NameTextBox
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access ClearAllButton
        /// </summary>
        Button ClearAllButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SelectAllButton
        /// </summary>
        Button SelectAllButton
        {
            get;
        }
        
        /// <summary>
        /// Gets read-only property to access SpecifyAnIPAddressOrAPatternForARangeOfIPAddressesTextBox
        /// </summary>
        TextBox SpecifyAnIPAddressOrAPatternForARangeOfIPAddressesTextBox
        {
            get;
        }

        ListView NetworkDeviceTypesListview
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
    ///   [v-dayow] 6/2/2010 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class AddFilterDialog : Dialog, IAddFilterDialogControls
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
        /// Cache to hold a reference to DescriptionTextBox of type TextBox
        /// </summary>
        private TextBox cachedDescriptionTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ObjectIDOIDTextBox of type TextBox
        /// </summary>
        private TextBox cachedObjectIDOIDTextBox;
        
        /// <summary>
        /// Cache to hold a reference to NameTextBox of type TextBox
        /// </summary>
        private TextBox cachedNameTextBox;
        
        /// <summary>
        /// Cache to hold a reference to ClearAllButton of type Button
        /// </summary>
        private Button cachedClearAllButton;
        
        /// <summary>
        /// Cache to hold a reference to SelectAllButton of type Button
        /// </summary>
        private Button cachedSelectAllButton;
        
        /// <summary>
        /// Cache to hold a reference to SpecifyAnIPAddressOrAPatternForARangeOfIPAddressesTextBox of type TextBox
        /// </summary>
        private TextBox cachedSpecifyAnIPAddressOrAPatternForARangeOfIPAddressesTextBox;

        private ListView cachedNetworkDeviceTypesListview;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the AddFilterDialog class.
        /// </summary>
        /// <param name='app'>
        /// Owner of AddFilterDialog of type App
        /// </param>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public AddFilterDialog(MomConsoleApp app, int timeout) : 
                base(app, Init(app, timeout))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IAddFilterDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IAddFilterDialogControls Controls
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
        ///  Gets or sets the text in control Description
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string DescriptionText
        {
            get
            {
                return this.Controls.DescriptionTextBox.Text;
            }
            
            set
            {
                this.Controls.DescriptionTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control ObjectIDOID
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string ObjectIDOIDText
        {
            get
            {
                return this.Controls.ObjectIDOIDTextBox.Text;
            }
            
            set
            {
                this.Controls.ObjectIDOIDTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control Name
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string NameText
        {
            get
            {
                return this.Controls.NameTextBox.Text;
            }
            
            set
            {
                this.Controls.NameTextBox.Text = value;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets or sets the text in control SpecifyAnIPAddressOrAPatternForARangeOfIPAddresses
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string SpecifyAnIPAddressOrAPatternForARangeOfIPAddressesText
        {
            get
            {
                return this.Controls.SpecifyAnIPAddressOrAPatternForARangeOfIPAddressesTextBox.Text;
            }
            
            set
            {
                this.Controls.SpecifyAnIPAddressOrAPatternForARangeOfIPAddressesTextBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the CancelButton control
        /// </summary>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddFilterDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, AddFilterDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the OKButton control
        /// </summary>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddFilterDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, AddFilterDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the DescriptionTextBox control
        /// </summary>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddFilterDialogControls.DescriptionTextBox
        {
            get
            {
                if ((this.cachedDescriptionTextBox == null))
                {
                    this.cachedDescriptionTextBox = new TextBox(this, AddFilterDialog.ControlIDs.DescriptionTextBox);
                }
                
                return this.cachedDescriptionTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ObjectIDOIDTextBox control
        /// </summary>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddFilterDialogControls.ObjectIDOIDTextBox
        {
            get
            {
                if ((this.cachedObjectIDOIDTextBox == null))
                {
                    this.cachedObjectIDOIDTextBox = new TextBox(this, AddFilterDialog.ControlIDs.ObjectIDOIDTextBox);
                }
                
                return this.cachedObjectIDOIDTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the NameTextBox control
        /// </summary>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddFilterDialogControls.NameTextBox
        {
            get
            {
                if ((this.cachedNameTextBox == null))
                {
                    this.cachedNameTextBox = new TextBox(this, AddFilterDialog.ControlIDs.NameTextBox);
                }
                
                return this.cachedNameTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the ClearAllButton control
        /// </summary>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddFilterDialogControls.ClearAllButton
        {
            get
            {
                if ((this.cachedClearAllButton == null))
                {
                    this.cachedClearAllButton = new Button(this, AddFilterDialog.ControlIDs.ClearAllButton);
                }
                
                return this.cachedClearAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SelectAllButton control
        /// </summary>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IAddFilterDialogControls.SelectAllButton
        {
            get
            {
                if ((this.cachedSelectAllButton == null))
                {
                    this.cachedSelectAllButton = new Button(this, AddFilterDialog.ControlIDs.SelectAllButton);
                }
                
                return this.cachedSelectAllButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Gets access to the SpecifyAnIPAddressOrAPatternForARangeOfIPAddressesTextBox control
        /// </summary>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IAddFilterDialogControls.SpecifyAnIPAddressOrAPatternForARangeOfIPAddressesTextBox
        {
            get
            {
                if ((this.cachedSpecifyAnIPAddressOrAPatternForARangeOfIPAddressesTextBox == null))
                {
                    this.cachedSpecifyAnIPAddressOrAPatternForARangeOfIPAddressesTextBox = new TextBox(this, AddFilterDialog.ControlIDs.SpecifyAnIPAddressOrAPatternForARangeOfIPAddressesTextBox);
                }
                
                return this.cachedSpecifyAnIPAddressOrAPatternForARangeOfIPAddressesTextBox;
            }
        }

        ListView IAddFilterDialogControls.NetworkDeviceTypesListview
        {
            get
            {
                if ((this.cachedNetworkDeviceTypesListview == null))
                {
                    this.cachedNetworkDeviceTypesListview = new ListView(this);
                }

                return this.cachedNetworkDeviceTypesListview;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
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
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button ClearAll
        /// </summary>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickClearAll()
        {
            this.Controls.ClearAllButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button SelectAll
        /// </summary>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickSelectAll()
        {
            this.Controls.SelectAllButton.Click();
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
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app, int timeout)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(Strings.DialogTitle, StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, timeout);
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
                        UISynchronization.WaitForUIObjectReady(tempWindow, timeout);
                    }
                    catch (Exceptions.WindowNotFoundException)
                    {
                        // log the unsuccessful attempt
                        Mom.Test.UI.Core.Common.Utilities.LogMessage("Attempt " + numberOfTries + " of " + maxTries);


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
        ///   [v-dayow] 6/2/2010 Created
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
            /// Control ID for DescriptionTextBox
            /// </summary>
            public const string DescriptionTextBox = "descriptionTextBox";
            
            /// <summary>
            /// Control ID for ObjectIDOIDTextBox
            /// </summary>
            public const string ObjectIDOIDTextBox = "objectIDTextBox";
            
            /// <summary>
            /// Control ID for NameTextBox
            /// </summary>
            public const string NameTextBox = "nameTextBox";
            
            /// <summary>
            /// Control ID for ClearAllButton
            /// </summary>
            public const string ClearAllButton = "clearAllButton";
            
            /// <summary>
            /// Control ID for SelectAllButton
            /// </summary>
            public const string SelectAllButton = "selectAllButton";
            
            /// <summary>
            /// Control ID for SpecifyAnIPAddressOrAPatternForARangeOfIPAddressesTextBox
            /// </summary>
            public const string SpecifyAnIPAddressOrAPatternForARangeOfIPAddressesTextBox = "ipAddressRangeTextBox";
        }
        #endregion
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        ///   [v-dayow] 6/2/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            /// <summary>
            /// Resource string for Add Filter
            /// </summary>
            private const string ResouceDialogTitle = ";Add Filter;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.NetworkDiscovery.AddFilterDialog;$this.Text";

            private const string ResouceLoadBalancer = ";Load Balancer;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AddFilterDialog_DeviceType_LoadBalancer";
            private const string ResouceBridge = ";Bridge;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AddFilterDialog_DeviceType_Bridge";
            private const string ResouceFirewall = ";Firewall;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AddFilterDialog_DeviceType_Firewall";
            private const string ResouceHost = ";Host;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AddFilterDialog_DeviceType_Host";
            private const string ResouceHub = ";Hub;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AddFilterDialog_DeviceType_Hub";
            private const string ResouceMSFC = ";MSFC;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AddFilterDialog_DeviceType_MSFC";
            private const string ResouceProbe = ";Probe;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AddFilterDialog_DeviceType_Probe";
            private const string ResouceRouter = ";Router;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AddFilterDialog_DeviceType_Router";
            private const string ResouceRSM = ";RSM;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AddFilterDialog_DeviceType_RSM";
            private const string ResouceSwitch = ";Switch;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AddFilterDialog_DeviceType_Switch";
            private const string ResouceTerminalServer = ";Terminal Server;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AddFilterDialog_DeviceType_TerminalServer";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [v-dayow] 6/2/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResouceDialogTitle);
                }
            }

            public static string LoadBalancer
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResouceLoadBalancer);
                }
            }

            public static string Bridge
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResouceBridge);
                }
            }

            public static string Firewall
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResouceFirewall);
                }
            }

            public static string Host
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResouceHost);
                }
            }

            public static string Hub
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResouceHub);
                }
            }

            public static string MSFC
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResouceMSFC);
                }
            }

            public static string Probe
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResouceProbe);
                }
            }

            public static string Router
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResouceRouter);
                }
            }

            public static string RSM
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResouceRSM);
                }
            }

            public static string Switch
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResouceSwitch);
                }
            }

            public static string TerminalServer
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResouceTerminalServer);
                }
            }
        }
        #endregion
    }
}
