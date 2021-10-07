//-------------------------------------------------------------------
// <copyright file="NetworkWizardUtilities.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains a class for exposing Network Discovery Wizard and View functionality.
// </summary>
// 
//  <history>
//  [dialac]  09APR10 Created
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.NetworkDeviceWizard
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.XPath;
    using System.ComponentModel;
    using System.IO;
    using System.Text;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Maui.GlobalExceptions;
    using Microsoft.EnterpriseManagement.Test.BaseCommon.WinSnmpControl;
    using Microsoft.EnterpriseManagement;
    using Microsoft.EnterpriseManagement.Administration;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Network;
    using Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.NetworkDeviceWizard.Dialogs;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.RunAsAccount;

    #region Enums

    /// ------------------------------------------------------------------
    /// <summary>
    /// Network Device Discovery method.
    /// </summary>
    /// ------------------------------------------------------------------
    public enum DiscoveryMethodType : int
    {
        /// <summary>
        /// Manual Discovery: adding manually the device 
        /// </summary>
        Manual,

        /// <summary>
        /// Given a SEED device, all the devices 
        /// </summary>
        Auto

    }

    /// ------------------------------------------------------------------
    /// <summary>
    /// Server where the discovery rule is going to run: Management Server 
    /// or Gateway Server
    /// </summary>
    /// ------------------------------------------------------------------
    public enum ServerType : int
    {
        /// <summary>
        /// Management Server
        /// </summary>
        ManagementServer,

        /// <summary>
        /// Gateway Server
        /// </summary>
        GatewayServer
    }

    /// ------------------------------------------------------------------
    /// <summary>
    /// Page where should we create the account associated to the device. 
    /// </summary>
    /// ------------------------------------------------------------------
    public enum AccountCreationPage : int
    {
        /// <summary>
        /// DefaultAccounts
        /// </summary>
        DefaultAccounts,

        /// <summary>
        /// AddDevice
        /// </summary>
        AddDevice

    }

    /// ------------------------------------------------------------------
    /// <summary>
    /// Access mode for the device. Default: ICMPSNMP
    /// </summary>
    /// ------------------------------------------------------------------
    public enum DeviceAccessMode : int
    {
        /// <summary>
        /// ICMP
        /// </summary>
        ICMP,

        /// <summary>
        /// SNMP
        /// </summary>
        SNMP,

        /// <summary>
        /// ICMPSNMP
        /// </summary>
        ICMPSNMP

    }

    /// ------------------------------------------------------------------
    /// <summary>
    /// SNMP Version of the device. Default: V1 or V2 
    /// </summary>
    /// ------------------------------------------------------------------
    public enum DeviceSNMPVersion : int
    {
        /// <summary>
        /// V1 or V2
        /// </summary>
        V1orV2,

        /// <summary>
        /// V3
        /// </summary>
        V3



    }

    /// ------------------------------------------------------------------
    /// <summary>
    /// Account associated to the device. Default: More secure
    /// </summary>
    /// ------------------------------------------------------------------
    public enum DeviceAcctSecureMode : int
    {
        /// <summary>
        /// MoreSecure
        /// </summary>
        MoreSecure,

        /// <summary>
        /// LessSecure
        /// </summary>
        LessSecure

    }

    /// ------------------------------------------------------------------
    /// <summary>
    /// Valid Actions for the Devices
    /// </summary>
    /// ------------------------------------------------------------------
    public enum ActionType : int
    {
        /// <summary>
        /// Add
        /// </summary>
        add,

        /// <summary>
        /// Edit
        /// </summary>
        edit,

        /// <summary>
        /// Remove
        /// </summary>
        remove,

        create,
        select,
    }

    /// ------------------------------------------------------------------
    /// <summary>
    /// Automatic Network Device Discovery scope.
    /// </summary>
    /// ------------------------------------------------------------------
    public enum DiscoveryScopeType : int
    {
        /// <summary>
        /// Discover all connected network devices
        /// </summary>
        All,

        /// <summary>
        /// Discover only network devices within the specified IP address ranges
        /// </summary>
        Specify,

    }

    public enum DeviceType : int
    {
        Bridge,
        Firewall,
        Host,
        Hub,
        LoadBalancer,
        MSFC,
        Probe,
        Router,
        RSFC,
        RSM,
        Switch,
        TerminalServer,
    }
        
    /// <summary>
    /// Device is seed or nonseed with auto descovery 
    /// </summary>    
    public enum NodeType : int
    {
       seed,
       nonseed
    }

    /// <summary>
    /// Enum Options
    /// Contain options to Delete    
    /// </summary>
    /// <history>
    ///		[v-juli] 10SEP10 Created
    /// </history>
    public enum Options
    {
        /// <summary>
        /// 1. Right-click on item and select context menu
        /// </summary>
        RightClickContextMenuOption,

        /// <summary>
        /// 2. Actions in tasks pane
        /// </summary>
        TasksPaneActionOption
    }

    #endregion // Enums

    
    /// <summary>
    /// Utility class to hold network device discovery methods
    /// </summary>
    public sealed class NetworkDeviceWizardUtilities
    {

        #region Private Constants

        /// <summary>
        ///  one minute in seconds used by initialization methods
        /// </summary>
        private const int OneMinuteInSeconds = 60;

        #endregion

        #region Private Members
        /// <summary>
        /// Device Dictionary
        /// </summary>
        public System.Collections.Generic.Dictionary<string, Device> devicesDictionary = new Dictionary<string, Device>();

        #endregion

        # region cached variables for all wizard pages

        /// <summary>
        /// cachedGeneralDialog
        /// </summary>
        private GeneralDialog cachedGeneralDialog;

        /// <summary>
        /// cachedDiscoveryMethodDialog
        /// </summary>
        private DiscoveryMethodDialog cachedDiscoveryMethodDialog;

        /// <summary>
        /// cachedDefaultAccountsDialog
        /// </summary>
        private DefaultAccountsDialog cachedDefaultAccountsDialog;

        /// <summary>
        /// cachedDevicesDialog
        /// </summary>
        private DevicesDialog cachedDevicesDialog;

        /// <summary>
        /// cachedAddDeviceDialog
        /// </summary>
        private AddaDeviceDialog cachedAddaDeviceDialog;

        /// <summary>
        /// cachedAdvancedDiscoverySettingsDialog
        /// </summary>
        private AdvancedDiscoverySettingsDialog cachedAdvancedDiscoverySettingsDialog;

        /// <summary>
        /// cachedFilterDialog
        /// </summary>
        private FilterDialog cachedFilterDialog;

        /// <summary>
        /// cachedScheduleDialog
        /// </summary>
        private ScheduleDiscoveryDialog cachedScheduleDialog;

        /// <summary>
        /// cachedSummaryDialog
        /// </summary>
        private SummaryDialog cachedSummaryDialog;

        /// <summary>
        /// cachedCompletionDialog
        /// </summary>
        private CompletionDialog cachedCompletionDialog;

        /// <summary>
        /// cachedWarningDialog
        /// </summary>
        private WarningDialog cachedWarningDialog;

        #endregion

        #region Properties

        /// <summary>
        /// General Dialog of the Create Network Discovery wizard. 
        /// </summary>
        public GeneralDialog NetworkDiscoveryGeneralDialog
        {
            get
            {
                if (this.cachedGeneralDialog == null)
                {
                    this.cachedGeneralDialog = new GeneralDialog(CoreManager.MomConsole, Constants.DefaultDialogTimeout);
                    Utilities.LogMessage("Setting Focus on the Network Discovery Wizard General Dialog was successful");
                }

                return this.cachedGeneralDialog;
            }
        }

        /// <summary>
        /// DiscoveryMethodDialog for the Network Discovery Wizard
        /// </summary>
        public DiscoveryMethodDialog DiscoveryMethodDialog
        {
            get
            {
                if (this.cachedDiscoveryMethodDialog == null)
                {
                    this.cachedDiscoveryMethodDialog = new DiscoveryMethodDialog(CoreManager.MomConsole, Constants.DefaultDialogTimeout);
                    Utilities.LogMessage("Setting Focus on the Network Discovery Wizard Discovery Method Dialog was successful");
                }

                return this.cachedDiscoveryMethodDialog;
            }
        }

        /// <summary>
        /// Default Accounts Dialog of the Create Network Discovery wizard. 
        /// </summary>
        public DefaultAccountsDialog DefaultAccountsDialog
        {
            get
            {
                if (this.cachedDefaultAccountsDialog == null)
                {
                    this.cachedDefaultAccountsDialog = new DefaultAccountsDialog(CoreManager.MomConsole, Constants.DefaultDialogTimeout);
                    Utilities.LogMessage("Setting Focus on the Network Discovery Wizard Default Accounts Dialog was successful");
                }

                return this.cachedDefaultAccountsDialog;
            }
        }

        /// <summary>
        /// Dialog that brings the list of Devices 
        /// </summary>
        public DevicesDialog DevicesDialog
        {
            get
            {
                if (this.cachedDevicesDialog == null)
                {
                    this.cachedDevicesDialog = new DevicesDialog(CoreManager.MomConsole, Constants.DefaultDialogTimeout);
                    Utilities.LogMessage("Setting Focus on the Network Discovery Wizard Devices Dialog was successful");
                }

                return this.cachedDevicesDialog;
            }
        }

        /// <summary>
        /// Dialog where you manually add a device
        /// </summary>
        public AddaDeviceDialog AddaDeviceDialog
        {
            get
            {
                if (this.cachedAddaDeviceDialog == null)
                {
                    this.cachedAddaDeviceDialog = new AddaDeviceDialog(CoreManager.MomConsole, Constants.DefaultDialogTimeout);
                    Utilities.LogMessage("Setting Focus on the Network Discovery Wizard Add a Device Dialog was successful");
                }

                return this.cachedAddaDeviceDialog;
            }
        }

        public AddaDeviceDialog AddaDeviceDialogBulkEdit
        {
            get
            {
                this.cachedAddaDeviceDialog = new AddaDeviceDialog(CoreManager.MomConsole, Constants.DefaultDialogTimeout);
                Utilities.LogMessage("Setting Focus on the Network Discovery Wizard Add a Device Dialog was successful");
                return this.cachedAddaDeviceDialog;
            }
        }

        /// <summary>
        /// Dialog where you setting advanced discovery settings.
        /// </summary>
        public AdvancedDiscoverySettingsDialog AdvancedDiscoverySettingsDialog
        {
            get
            {
                if (this.cachedAdvancedDiscoverySettingsDialog == null)
                {
                    this.cachedAdvancedDiscoverySettingsDialog = new AdvancedDiscoverySettingsDialog(CoreManager.MomConsole, Constants.DefaultDialogTimeout);
                    Utilities.LogMessage("Setting Focus on the Network Discovery Wizard Advanced Discovery Settings dialog was successful");
                }

                return this.cachedAdvancedDiscoverySettingsDialog;
            }
        }

        /// <summary>
        /// Dialog for the discovery Schedule 
        /// </summary>
        public ScheduleDiscoveryDialog ScheduleDiscoveryDialog
        {
            get
            {
                if (this.cachedScheduleDialog == null)
                {
                    this.cachedScheduleDialog = new ScheduleDiscoveryDialog(CoreManager.MomConsole, Constants.DefaultDialogTimeout);
                    Utilities.LogMessage("Setting Focus on the Network Discovery Wizard Schedule Dialog was successful");
                }

                return this.cachedScheduleDialog;
            }
        }

        /// <summary>
        /// Dialog for the Filter Dialog
        /// </summary>
        public FilterDialog FilterDialog
        {
            get
            {
                if (this.cachedFilterDialog == null)
                {
                    this.cachedFilterDialog = new FilterDialog(CoreManager.MomConsole, Constants.DefaultDialogTimeout);
                    Utilities.LogMessage("Setting Focus on the Network Discovery Wizard Filter Dialog was successful");
                }

                return this.cachedFilterDialog;
            }
        }

        /// <summary>
        /// Dialog for the Summary Dialog
        /// </summary>
        public SummaryDialog SummaryDialog
        {
            get
            {
                if (this.cachedSummaryDialog == null)
                {
                    this.cachedSummaryDialog = new SummaryDialog(CoreManager.MomConsole, Constants.DefaultDialogTimeout);
                    Utilities.LogMessage("Setting Focus on the Network Discovery Wizard Summary Dialog was successful");
                }

                return this.cachedSummaryDialog;
            }
        }

        /// <summary>
        /// Dialog for the CompletionDialog
        /// </summary>
        public CompletionDialog CompletionDialog
        {
            get
            {
                if (this.cachedCompletionDialog == null)
                {
                    this.cachedCompletionDialog = new CompletionDialog(CoreManager.MomConsole, Constants.DefaultDialogTimeout);
                    Utilities.LogMessage("Setting Focus on the Network Discovery Wizard Completion Dialog was successful");
                }

                return this.cachedCompletionDialog;
            }
        }

        /// <summary>
        /// Dialog for the Distribution Warning Dialog
        /// </summary>
        public WarningDialog WarningDialog
        {
            get
            {
                if (this.cachedWarningDialog == null)
                {
                    this.cachedWarningDialog = new WarningDialog(CoreManager.MomConsole, Constants.DefaultDialogTimeout);
                    Utilities.LogMessage("Setting Focus on the Network Discovery Wizard Dstribution Account Warning Dialog was successful");
                }

                return this.cachedWarningDialog;
            }
        }

        #endregion

        #region Public Methods

        //TODO dialac - change the summary information. 

        /// <summary>
        /// Set fields in the General page: Name and Description. 
        /// </summary>
        /// <param name="ruleName">SLA Name</param>
        /// <param name="slaDescription">SLA Description</param>
        /// <history>
        /// [dialac] 17SEP08 - Created        
        /// </history>
        public void SettingFieldsGeneralPage(string discoveryRuleName, string discoveryRuleDescription)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            //TODO - dialac - move to a member of the discovery wizard class
            //TODO - dialac - change to pass this serverName
            string serverName = Core.Common.Utilities.MomServerName;

            //string deviceIpAddress = null;
            string serverNameFqdn = null;
            serverNameFqdn = Utilities.GetServerNameFqdn(serverName);
            Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::parameters");
            Utilities.LogMessage("serverNameFqdn: " + serverNameFqdn + "");

            // General Page
            if (null != discoveryRuleName)
            {
                Sleeper.Delay(5000);
                this.NetworkDiscoveryGeneralDialog.ScreenElement.SendKeys(discoveryRuleName);
                // maiu4.0: wait for sending keys completed, or it will cause the following operations to fail.  
                int loop = 0;
                while (loop < Constants.DefaultMaxRetry
                       && this.NetworkDiscoveryGeneralDialog.NameText != discoveryRuleName)
                {
                    Utilities.LogMessage(currentMethod + ":: Current Name Text is:" + this.NetworkDiscoveryGeneralDialog.NameText);
                    loop++;
                    Sleeper.Delay(Constants.OneSecond * 10);
                }

                Utilities.LogMessage(currentMethod + ":: Set Discovery Rule display name '" +
                this.NetworkDiscoveryGeneralDialog.NameText + "'");
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: Discovery Rule Name is null.");
                // Nothing to do if Rule Name is Null
            }

            if (null != discoveryRuleDescription)
            {
                this.NetworkDiscoveryGeneralDialog.ScreenElement.SendKeys(discoveryRuleDescription);
                Utilities.LogMessage(currentMethod + ":: Set Discovery Rule description '"
                + this.NetworkDiscoveryGeneralDialog.DescriptionOptionalText + "'");
            }

            int currentItem = 0;
            while (currentItem < this.NetworkDiscoveryGeneralDialog.Controls.AvailableServersComboBox.Count &&
                this.NetworkDiscoveryGeneralDialog.Controls.AvailableServersComboBox.Text != serverNameFqdn)
            {
                //Setting the management server (or gateway server)
                this.NetworkDiscoveryGeneralDialog.Controls.AvailableServersComboBox.ScreenElement.SendKeys(Core.Common.KeyboardCodes.DownArrow);
                currentItem++;
            }

        }


        /// <summary>
        /// Launch navigation discovery wizard.
        /// </summary>
        public void LaunchDiscoveryWizard()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");


            //TODO - dialac - Look to see if we have this constant already. 
            int waitTime = 1000;

            #region Navigate and Start Wizard, Find and verify Wizard Page

            Utilities.LogMessage(currentMethod +
                "::Navigating to Administration view...");

            // navigate to the administration view
            CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(
                NavigationPane.WunderBarButton.Administration);

            Utilities.LogMessage(currentMethod +
                "::Selecting 'Device Management' node...");

            // use core navigation method to find the view
            Maui.Core.WinControls.TreeNode deviceManagement =
                CoreManager.MomConsole.NavigationPane.SelectNode(
                    NavigationPane.Strings.AdminTreeViewAdministrationRoot +
                    "\\" +
                    NavigationPane.Strings.AdminTreeViewDeviceManagement,
                    NavigationPane.NavigationTreeView.Administration);


            Utilities.LogMessage(currentMethod + "::Starting discovery wizard...");

            // start the wizard from the context menu
            int retry = 0;
            Maui.Core.WinControls.Menu contextMenu = null;
            DeviceDiscovery.Wizards.ComputerAndDeviceType discoveryWizard = null;
            while (retry <= 5)
            {
                try
                {
                    deviceManagement.Click(MouseClickType.SingleClick, MouseFlags.RightButton);

                    Core.Common.Utilities.LogMessage(currentMethod + "::Try to get contextMenu");
                    contextMenu = new Maui.Core.WinControls.Menu(Core.Common.Constants.DefaultContextMenuTimeout);

                    // select DiscoveryWizard button to execute
                    contextMenu.ExecuteMenuItem(NavigationPane.Strings.ContextMenuDiscoveryWizard);
                    Core.Common.Utilities.TakeScreenshot(currentMethod + "_GetMenuComplete");

                    // find the discovery wizard welcome window
                    Core.Common.Utilities.LogMessage(currentMethod + "::Try to get wizard page");
                    discoveryWizard = new Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.ComputerAndDeviceType(CoreManager.MomConsole);
                    break;
                }
                catch
                {
                    retry++;
                    if (retry > 5)
                    {
                        Core.Common.Utilities.TakeScreenshot(currentMethod + "_IssueMeetMaxRetry");
                        throw;
                    }
                    Core.Common.Utilities.TakeScreenshot(string.Format("{0}_TryFixIssue{1}", currentMethod, retry));
                    Keyboard.SendKeys("ESC");
                    CoreManager.MomConsole.CloseChildDialogWindows();  //Fix bug #496156 & #531320. When Maui get context menu failed, will close all child windows and try again.
                }
            }

            Utilities.LogMessage(currentMethod +
                "discoveryWizard::Found discovery wizard window...");
            #endregion // Navigate and Start Wizard, Find and verify Wizard Page

            #region Select Device Type to be discovered

            /*Perform action to select network devices here
             *Click Next */
            // select the corresponding device types. 
            Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Selecting Network Device types.");
            //discoveryWizard.Controls.NetworkDevicesStaticControl.SendKeys("%{v}");
            discoveryWizard.Controls.NetworkDevicesStaticControl.Click();

            //waiting 1 second
            Sleeper.Delay(waitTime);
            Utilities.LogMessage(currentMethod + "::Clicking 'Next' button...");
            // move past the "First" screen, i.e. click "Next"
            discoveryWizard.ClickNext();
            #endregion
        }

        /// <summary>
        /// Navigation General page.
        /// </summary>
        /// <param name="ruleName">Update discovery rule name. Do nothing if this parameter is Null.</param>
        /// <param name="ruleDes">Update discovery description. Do nothing if this parameter is Null.</param>
        public void NavigationGeneralPage(string ruleName, string ruleDes)
        {
            //Setting the properties in the General Page: Name and Description only
            this.SettingFieldsGeneralPage(ruleName, ruleDes);

            //Navigating to the next page: Discovery Method
            this.NetworkDiscoveryGeneralDialog.ClickNext();
            this.cachedGeneralDialog = null;
        }

        /// <summary>
        /// Navigation Discovery Method page.
        /// </summary>
        /// <param name="mode">Discovery method type.</param>
        public void NavigationDiscoveryMethodPage(DiscoveryMethodType mode)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");
            
            if (mode == DiscoveryMethodType.Manual)
            {
                CoreManager.MomConsole.Waiters.WaitForWindowAppeared(DiscoveryMethodDialog,new QID(";[UIA]automationId = 'manualOption'"),Constants.OneSecond*3);
                this.DiscoveryMethodDialog.DiscoveryMethodRadioGroup = DiscoveryMethod.ManualDiscovery;
                Utilities.LogMessage(currentMethod + ":: Set Discovery Method is Manual'");
            }
            else if (mode == DiscoveryMethodType.Auto)
            {
                CoreManager.MomConsole.Waiters.WaitForWindowAppeared(DiscoveryMethodDialog,new QID(";[UIA]automationId = 'automaticOption'"),Constants.OneSecond*3);
                this.DiscoveryMethodDialog.DiscoveryMethodRadioGroup = DiscoveryMethod.AutomaticDiscovery;
                Utilities.LogMessage(currentMethod + ":: Set Discovery Method is automation'");
            }
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.DiscoveryMethodDialog.Controls.NextButton, 2);
            this.DiscoveryMethodDialog.ClickNext();
            Utilities.LogMessage(currentMethod + ":: Clicked button Next'");
            this.cachedDiscoveryMethodDialog = null;
        }

        /// <summary>
        /// Navigation DefaultAccount Page.
        /// </summary>
        /// <param name="actions">Account actions.</param>
        public void NavigationDefaultAccountPage(AccountAction[] actions)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            this.DefaultAccountsDialog.WaitForResponse();
            if (actions != null && actions.Length != 0)
            {
                ExecuteAccountActions(actions, AccountCreationPage.DefaultAccounts);
                Utilities.LogMessage(currentMethod + "::Execute Account Actions Successfully.'");
            }
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.DefaultAccountsDialog.Controls.NextButton);
            this.DefaultAccountsDialog.ClickNext();
            Utilities.LogMessage(currentMethod + ":: Clicked button Next'");
            this.cachedDefaultAccountsDialog = null;

        }

        /// <summary>
        /// Navigation Devices page.
        /// </summary>
        /// <param name="importFile">Devices import file path. Import devices file if the value is not Null.</param>
        /// <param name="actions">Device actions. Used for add/edit/remove devices.</param>
        public void NavigationDevicesPage(string importFile,DeviceAction[] actions)
        {
            this.DevicesDialog.WaitForResponse(Constants.DefaultDialogTimeout);
            if (importFile != null)
                ImportDevices(importFile);
            if (actions != null)
                this.ExecuteDeviceActions(actions);
            this.DevicesDialog.WaitForResponse(Constants.DefaultDialogTimeout);
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.DevicesDialog.Controls.NextButton);
            this.DevicesDialog.ClickNext();
            this.cachedDevicesDialog = null;
        }

        /// <summary>
        /// Navigation Filter page.
        /// </summary>
        /// <param name="scope">Select network discvoery scope.</param>
        /// <param name="includeActions">Filter actions.</param>
        public void NavigationFilterPage(DiscoveryScopeType scope, IncludeFilterAction[] includeActions, ExcludeFilterAction[] excludeActions)
        {
            #region #Include Filters page
            this.FilterDialog.WaitForResponse();
            if (scope == DiscoveryScopeType.All)
            {
                this.FilterDialog.Controls.DiscoverAllConnectedNetworkDevicesRadioButton.Click();
            }
            else
            {
                this.FilterDialog.Controls.DiscoverOnlyNetworkDevicesWithinTheSpecifiedIPAddressRangesRadioButton.Click();
                if (includeActions != null)
                    ExecuteIncludeFilterActions(includeActions);
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.FilterDialog.Controls.NextButton);
            }
            this.FilterDialog.ClickNext();
            this.cachedFilterDialog = null; 
            #endregion

            #region Exclude Filters page
            this.FilterDialog.WaitForResponse();
            if (excludeActions != null)
                ExecuteExcludeFilterActions(excludeActions);
            this.FilterDialog.ClickNext();
            this.cachedFilterDialog = null; 
            #endregion
        }

        /// <summary>
        /// Navigation Schedule page.
        /// </summary>
        public void NavigationSchedulePage()
        {
            //For BVT automation, just checking the checkbox to run automatically. 
            //TODO: Add a parameter to be used for fuctional combinations. 

            //RunImmediately Checkbox has been removed in CTP1. See #178233.
            //this.ScheduleDiscoveryDialog.Controls.RunImmediatelyWhenDiscoveryIsCreatedCheckBox.Checked = true;

            this.ScheduleDiscoveryDialog.ClickNext();
            this.SummaryDialog.WaitForResponse(5000);
            this.cachedScheduleDialog = null;
        }

        /// <summary>
        /// Navigation Summary and Competion pages.
        /// </summary>
        public void NavigationSummaryAndCompletionPages()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            //TODO - Functional level - Add verification thourgh the Summary page 

            Utilities.LogMessage(currentMethod + ":: Try to click button Finish.");

            this.SummaryDialog.ClickFinish();
            this.cachedSummaryDialog = null;

            #region Distribution Account pop-up
            Utilities.LogMessage(currentMethod + ":: Check if warning dialog exists.");
            bool warningDialogFound = false;
            WarningDialog warDialog = null;
            try
            {
                warDialog = new WarningDialog(CoreManager.MomConsole, Constants.OneSecond * 15);
            }
            catch (Window.Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage(currentMethod + ":: Warning dialog not found");
            }
            if (warDialog != null)
            {
                warningDialogFound = true;
                warDialog.WaitForResponse();
                Utilities.LogMessage(currentMethod + ":: Warning! Found ");
                Utilities.LogMessage(currentMethod + ":: Try to click button OK.");
                warDialog.ClickYes();
                Utilities.LogMessage(currentMethod + ":: Try to close warning dialog.");
                CoreManager.MomConsole.WaitForDialogClose(warDialog, 2);
            }
            #endregion Distribution Account pop-up

            this.cachedCompletionDialog = null;

            this.CompletionDialog.WaitForResponse(5000);

            CoreManager.MomConsole.Waiters.WaitForObjectPropertyChangedSafe(this.CompletionDialog.Controls.RunNowOptionCheckBox, "@IsVisible", PropertyOperator.Equals, "True");
            this.CompletionDialog.Controls.RunNowOptionCheckBox.ButtonState = ButtonState.UnChecked;
	        CoreManager.MomConsole.Waiters.WaitForWindowForeground(CompletionDialog, Constants.OneSecond * 5);
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.CompletionDialog.Controls.CloseButton, 15000);

            this.CompletionDialog.ClickClose();
            Utilities.LogMessage(currentMethod + ":: Try to close Completion Dialog.");
            CoreManager.MomConsole.Waiters.WaitForWindowClose(CompletionDialog, Constants.DefaultDialogTimeout * 10);            
            this.cachedCompletionDialog = null;
        }

        public delegate void PageActionHandler(Dialog page);
        /// <summary>
        /// Go through the network discovery wizard. 
        /// </summary>
        /// <param name="param">Network Parameter class containing all the wizard input information including the devices</param> 
        public void CreateDiscoveryRule(NetworkWizardParameters param)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            int waitTime = 1000;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (param == null)
            {
                Utilities.LogMessage(String.Format("{0}:: The Network Wizard parameter class with the rule and devices info can not be null", currentMethod));
                throw new System.ArgumentNullException("The network Wizard parameter is null");
            }

            #region Setting General page
            NavigationGeneralPage(param.NetworkDiscoveryRuleName, param.NetworkDiscoveryRuleDescription);
            #endregion

            Sleeper.Delay(waitTime);   // wait 1 second after click "Next"

            #region Setting Discovery Method
            NavigationDiscoveryMethodPage(param.DiscoveryMethodType);
            #endregion

            Sleeper.Delay(waitTime);   // wait 1 second after click "Next"

            #region Selecting the Accounts
            NavigationDefaultAccountPage(param.DefaultAccountPageActions);
            #endregion

            Sleeper.Delay(waitTime);   // wait 1 second after click "Next"

            #region "Adding Devices"
            NavigationDevicesPage(param.ImportDeviceFile, param.DevicesPageActions);
            #endregion

            Sleeper.Delay(waitTime);   // wait 1 second after click "Next"

            #region Filter Page
            if (param.DiscoveryMethodType == DiscoveryMethodType.Auto)
            {
                NavigationFilterPage(param.DiscoveryScopeType, param.IncludeFilterPageActions, param.ExcludeFilterPageActions);
            }
            #endregion

            Sleeper.Delay(waitTime);   // wait 1 second after click "Next"

            #region Schedule Page
            NavigationSchedulePage();
            #endregion

            Sleeper.Delay(waitTime);   // wait 1 second after click "Next"

            #region Summary and Completion pages
            NavigationSummaryAndCompletionPages();
            #endregion
        }       

        /// <summary>
        /// Verify if the the discovery rule was created 
        /// </summary>
        /// <param name="param">Rule Parameter class containing the ruel config</param>
        /// <history>
        /// [dialac] 10MAY10 - Created        
        /// </history>
        public void VerifyDiscoveryRule(NetworkWizardParameters param)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...) Verifying discovery rule");

            //Looking for the rule in the discovery rule View. 
            bool ruleFound = this.FindDiscoveryRuleEntryView(param.NetworkDiscoveryRuleName);

            if (ruleFound == false)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: the Discovery Rule was not found in the view", currentMethod));
                throw new Maui.GlobalExceptions.MauiException("the Discovery Rule was not found in the view");
            }

            //TODO - Add logic to open the properties page and verify at least the name of the Rule is correct. 
            // Selecting Properties option from Action pane once the rule is selected. 
            //CoreManager.MomConsole.ActionsPane.ClickLink(Strings.ActionsSLA, Strings.ActionPropertiesSLA);
            //Utilities.LogMessage(currentMethod + ":: Successfully Launched the Properties page of Discovery Rule");
            //this.SLAGeneralDialog.WaitForResponse();

        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to delete a network device 
        /// </summary>
        /// <param name="deviceName">Network device name that will be deleted</param>
        /// <returns>True if successful, otherwise false</returns>
        /// <history>
        ///     [v-juli]  08Sep10 Created 
        /// </history>
        /// ------------------------------------------------------------------
        public bool VeryDeleteNetworkDevice(NetworkWizardParameters param)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...) Verifying network device is deleted.");

            bool verifyDeleted = false;
            Maui.Core.WinControls.DataGridViewRow deviceDataGridViewRow = null;

            // get the grid row
            deviceDataGridViewRow = this.FindNetworkDevice(param.DeviceName[0], 1);

            if (param.NodeType.Equals(NodeType.seed))
            {
                if (deviceDataGridViewRow != null)
                {
                    Utilities.LogMessage(currentMethod + ":: Seed Device : " + param.DeviceName[0].ToString() + ".");
                    verifyDeleted = true;
                }
                else
                {
                    Utilities.LogMessage(currentMethod + ":: Seed Device : " + param.DeviceName[0].ToString() + " is deleted fromm view!");                    
                }
            }
            else
            {
                if (deviceDataGridViewRow != null)
                {
                    Utilities.LogMessage(currentMethod + ":: Non-Seed Device : " + param.DeviceName[0].ToString() + " is not deleted successfully.");                    
                }
                else
                {
                    Utilities.LogMessage(currentMethod + ":: Non-Seed Device : " + param.DeviceName[0].ToString() + " is deleted successfully!");
                    verifyDeleted = true;
                }
            }
           
            return verifyDeleted;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to delete multipule discovery rule 
        /// </summary>        
        /// <returns>True if successful, otherwise false</returns>
        /// <history>
        ///     [v-juli]  08Sep10 Created 
        /// </history>
        /// ------------------------------------------------------------------
        public bool VerifyDeleteAllNetworkDevices()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...) Verifying delete multipule network device.");

            bool deleted = false;
            int retry = 0;
            int maxRetry = 3;

            // get the grid row
            while (CoreManager.MomConsole.ViewPane.Grid.Rows.Count > 1 && retry < maxRetry)
            {
                Utilities.LogMessage(currentMethod + ":: There still exists device, refresh and retry, retry times: " + retry.ToString());
                CoreManager.MomConsole.ViewPane.Grid.SendKeys(Core.Common.KeyboardCodes.F5);
                Sleeper.Delay(Constants.OneSecond);
                retry++;
            }

            if (CoreManager.MomConsole.ViewPane.Grid.Rows.Count > 1)
            {
                Utilities.LogMessage(currentMethod + ":: Fail to delete all devices.");
            }
            else
            {
                deleted = true;
                Utilities.LogMessage(currentMethod + ":: Successfully delete all devices.");
            }

            return deleted;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to open a discovery rule 
        /// </summary>
        /// <param name="ruleName">Name of the rule</param>
        /// <history>
        ///     [v-dayow]  8JUN10 Created 
        /// </history>
        /// ------------------------------------------------------------------
        public void OpenDiscoveryRuleProperties(string ruleName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...) Opening discovery rule");

            // set the key column name to match
            string displayName = ruleName;
            string searchColumn = ViewPane.Strings.AdministrationGridViewColumnName;
            Maui.Core.WinControls.DataGridViewRow discRuleDataGridViewRow = null;

            //Navigating to the view 
            bool ruleFound = this.FindDiscoveryRuleEntryView(ruleName);

            if (ruleFound == true)
            {
                // get the grid row
                discRuleDataGridViewRow = CoreManager.MomConsole.ViewPane.Grid.FindData(displayName, searchColumn);

                // based on device type and management mode
                if (discRuleDataGridViewRow != null)
                {
                    // left-click row first, or right-click won't get correct menu.
                    discRuleDataGridViewRow.AccessibleObject.Click(
                        MouseClickType.SingleClick,
                        MouseFlags.LeftButton);

                    // right-click and open properties
                    discRuleDataGridViewRow.AccessibleObject.Click(
                        MouseClickType.SingleClick,
                        MouseFlags.RightButton);
                    Maui.Core.WinControls.Menu contextMenu =
                        new Maui.Core.WinControls.Menu(
                            Core.Common.Constants.DefaultContextMenuTimeout);
                    contextMenu.ExecuteMenuItem(
                        ViewPane.Strings.AdministrationContextMenuProperties);
                }
                else
                {
                    throw
                        new Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException(
                        "Failed to find the search term, '" + ruleName + "', in the grid!");
                }
            }
            else
            {
                Utilities.LogMessage(currentMethod + "The discovery rule you want to open, was not found in the view");
            }
            // return true or false
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to delete a discovery rule 
        /// </summary>
        /// <param name="ruleName">Name of the rule</param>
        /// <returns>True if successful, otherwise false</returns>
        /// <history>
        ///     [Dialac]  10May10 Created 
        /// </history>
        /// ------------------------------------------------------------------
        public bool DeleteDiscoveryRule(string ruleName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...) Verifying discovery rule");

            bool success = false;

            // set the key column name to match
            string displayName = ruleName;
            string searchColumn = ViewPane.Strings.AdministrationGridViewColumnName;
            Maui.Core.WinControls.DataGridViewRow discRuleDataGridViewRow = null;

            //Navigating to the view 
            bool ruleFound = this.FindDiscoveryRuleEntryView(ruleName);

            #region Remove the Device

            if (ruleFound == true)
            {

                // get the grid row
                discRuleDataGridViewRow = CoreManager.MomConsole.ViewPane.Grid.FindData(displayName, searchColumn);

                // based on device type and management mode
                if (discRuleDataGridViewRow != null)
                {

                    // left-click row first, or right-click won't get correct menu.
                    discRuleDataGridViewRow.AccessibleObject.Click(
                        MouseClickType.SingleClick,
                        MouseFlags.LeftButton);

                    // right-click and delete
                    discRuleDataGridViewRow.AccessibleObject.Click(
                        MouseClickType.SingleClick,
                        MouseFlags.RightButton);
                    Maui.Core.WinControls.Menu contextMenu =
                        new Maui.Core.WinControls.Menu(
                            Core.Common.Constants.DefaultContextMenuTimeout);
                    contextMenu.ExecuteMenuItem(
                        ViewPane.Strings.AdministrationContextMenuDelete);

                    // Confirm Delete Network Device
                    string confirmationDialogTitle = Strings.AdministrationConfirmDeleteDiscoveryRuleDialogTitle;

                    // confirm the operation
                    CoreManager.MomConsole.ConfirmChoiceDialog(
                            true,
                            confirmationDialogTitle);
                }
                else
                {
                    throw
                        new Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException(
                        "Failed to find the search term, '" + ruleName + "', in the grid!");
                }


            }
            else
            {
                Utilities.LogMessage(currentMethod + "The discovery rule you want to delete, was not found in the view");
                return false;
            }
            #endregion Remove the Device

            #region Verify Deletion

            //TODO - Add resource string for the tree node
            //For now - using the hardcoded string. 

            //string treeNodeName = "Discovery Rules";

            //// refresh the view
            //CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeName).Select();
            //CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeName).Click();
            CoreManager.MomConsole.ViewPane.Extended.Click();
            CoreManager.MomConsole.ViewPane.SendKeys(Core.Common.KeyboardCodes.F5);

            // use the "Name" column
            //searchColumn = ViewPane.Strings.AdministrationGridViewColumnName;

            // check that the device is gone
            discRuleDataGridViewRow = null;
            discRuleDataGridViewRow =
                CoreManager.MomConsole.ViewPane.Grid.FindData(
                    ruleName,
                    searchColumn);
           
            // set return value to confirm device deletion
            if (discRuleDataGridViewRow == null)
            {
                success = true;
            }
            else
            {
                success = false;
            }
            #endregion // Verify Deletion

            // return true or false
            return success;
        }

        /// <summary>
        /// Navigate to Network Devices View.
        /// </summary>
        public void NavigateToDeviceNode()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");


            Utilities.LogMessage(currentMethod +
                "::Navigating to Administration view...");

            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

            // navigate to the administration view
            navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Administration);
            CoreManager.MomConsole.Waiters.WaitForReady(Constants.DefaultDialogTimeout);

            Utilities.LogMessage(currentMethod +
                "::Selecting 'Network Device' node...");

            // use core navigation method to find the view
            StringBuilder pathToView = new StringBuilder();
            pathToView.Append(NavigationPane.Strings.AdminTreeViewAdministrationRoot);
            pathToView.Append("\\");
            pathToView.Append(NavigationPane.Strings.AdminTreeViewNetworkManagement);
            pathToView.Append("\\");
            pathToView.Append(NavigationPane.Strings.AdminTreeViewNetworkDevices);
                       
            navPane.SelectNode(pathToView.ToString(),
                    NavigationPane.NavigationTreeView.Administration);
            CoreManager.MomConsole.Waiters.WaitForReady(Constants.DefaultDialogTimeout);
            CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();

        }

        /// <summary>
        /// Try to find and select a newtwork device in the View. 
        /// Return false if the rule is not found in the view. 
        /// </summary>
        /// <param name="deviceName">Device Name to be found/selected</param> 
        /// <returns>Grid row of found device </returns>
        /// <history>
        /// [v-juli] 10May10 - Created        
        /// </history>
        private DataGridViewRow FindNetworkDevice(string deviceName, int maxRetry)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            bool foundDevice = false;

            //Checking the input parameters
            if (String.IsNullOrEmpty(deviceName))
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: the Device Name user passed is null/Empty.", currentMethod));
                throw new System.ArgumentNullException("Discovery Rule Name user passed to be found is null/Empty");
            }

            CoreManager.MomConsole.BringToForeground();            

            #region Find Network Device Instance

            int loopCount = 0;           

            int searchColumn = 0;
            MomControls.GridControl viewGrid = null;
            Maui.Core.WinControls.DataGridViewRow deviceGridRow = null;

            while (!foundDevice && loopCount < maxRetry)
            {
                viewGrid = CoreManager.MomConsole.ViewPane.Grid;

                if (viewGrid != null)
                {
                    Utilities.LogMessage(currentMethod + ":: Found Device View Grid");

                    CoreManager.MomConsole.ViewPane.Grid.SendKeys(KeyboardCodes.F5);
                    CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();
                    CoreManager.MomConsole.ViewPane.Grid.WaitForResponse();                    

                    CoreManager.MomConsole.ViewPane.Find.ClickClear();

                    CoreManager.MomConsole.ViewPane.Find.WaitForResponse();
                    CoreManager.MomConsole.ViewPane.Find.LookForText = deviceName;
                    CoreManager.MomConsole.ViewPane.Find.ClickFindNow();
                    CoreManager.MomConsole.ViewPane.Grid.ScreenElement.WaitForReady();

                    if (CoreManager.MomConsole.ViewPane.Title.Contains(NavigationPane.Strings.AdminTreeViewNetworkDevicesPendingManagement))
                    {
                        Utilities.LogMessage(currentMethod + ":: Found Device in Pending Network Device View Grid");
                        searchColumn = viewGrid.GetColumnTitlePosition(ViewPane.Strings.AdministrationGridViewColumnName);                       
                    }
                    else
                    {
                        Utilities.LogMessage(currentMethod + ":: Found Device in Network Device View Grid");
                        searchColumn = viewGrid.GetColumnTitlePosition(Strings.IPAddress);
                    }                   

                    deviceGridRow = CoreManager.MomConsole.ViewPane.Grid.FindData(deviceName, searchColumn);
                }

                if (deviceGridRow != null)
                {
                    foundDevice = true;
                }
                else
                {
                    CoreManager.MomConsole.ViewPane.Find.ClickClear();                    
                    Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond * 2);

                    Utilities.LogMessage(currentMethod + ":: Failed to find device in loop: " + loopCount.ToString() + ", try again...");
                    loopCount++;
                }
            }

            #endregion Find Network Device Instance

            // verify device in view
            if (foundDevice == true)
            {
                Core.Common.Utilities.LogMessage(currentMethod + "::Successfully find device:  " + deviceName);
            }
            else
            {
                Core.Common.Utilities.LogMessage(currentMethod + "::Not find device:  " + deviceName);
            }

            return deviceGridRow;

        }

         /// ------------------------------------------------------------------
        /// <summary>
        /// Method to Create fake network device(s)
        /// </summary>
        /// <param name="networkTopology">Network Topology Class contaning create fake device method</param> 
        /// <param name="param">Network Parameter class containing input information</param>        
        /// <history>
        ///     [v-juli]  8Sep10 Created 
        /// </history>
        /// ------------------------------------------------------------------
        public void CreateNetworkDevices(FakeNetworkTopology networkTopology, NetworkWizardParameters param)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...) Create network device(s).");

            switch (param.DeviceType)
            {
                case DeviceType.Router:

                    foreach (string dname in param.DeviceName)
                    {
                        try
                        {
                            Utilities.LogMessage(currentMethod + ":: Create Router");
                            if (param.NodeType == NodeType.seed)
                            {
                                Utilities.LogMessage(currentMethod + ":: Seed Device: " + dname);                                
                                param.DeviceName[0] = networkTopology.CreateRouter(dname, true);
                            }
                            else
                            {
                                Utilities.LogMessage(currentMethod + ":: Non Seed Device: " + dname);
                                param.DeviceName[0] = networkTopology.CreateRouter(dname);                                
                            }
                          
                        }
                        catch (Microsoft.EnterpriseManagement.Common.DiscoveryDataInsertionCollisionException)//networkTopology.DeviceExists(networkParams.DeviceName) not work
                        {
                            Utilities.LogMessage(currentMethod + ":: Router :" + dname + "already exists.");
                        }
                    }
                    break;

                case DeviceType.Switch:

                    foreach (string dname in param.DeviceName)
                    {
                        try
                        {
                            Utilities.LogMessage(currentMethod + ":: Create Switch");
                            if (param.NodeType == NodeType.seed)
                            {
                                Utilities.LogMessage(currentMethod + ":: Seed Device: " + dname);
                                networkTopology.CreateSwitch(dname, true);
                            }
                            else
                            {
                                Utilities.LogMessage(currentMethod + ":: Non Seed Device: " + dname);
                                networkTopology.CreateSwitch(dname);
                            }                            
                        }
                        catch (Microsoft.EnterpriseManagement.Common.DiscoveryDataInsertionCollisionException)
                        {
                            // Utilities.LogMessage(currentMethod + "::  Name" + "IP:" + networkTopology.CreatedDevices[dname].IpAddress);
                            Utilities.LogMessage(currentMethod + ":: Switch :" + dname + "already exists.");
                        }
                    }
                    break;

                default:
                    Utilities.LogMessage(currentMethod + ":: Invalid Device Type.");
                    break;
            }        
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to delete a network device
        /// </summary>
        /// <param name="param">Network Parameter class containing input information</param>        
        /// <history>
        ///     [v-juli]  8Sep10 Created 
        /// </history>
        /// ------------------------------------------------------------------
        public void DeleteNetworkDevice(NetworkWizardParameters param)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...) Delete a network device.");

            Maui.Core.WinControls.DataGridViewRow deviceDataGridViewRow = null;

            // get the grid row
            deviceDataGridViewRow = this.FindNetworkDevice(param.DeviceName[0], 2);

            // based on device type and management mode
            if (deviceDataGridViewRow != null)
            {
                // left-click row first, or right-click won't get correct menu.
                deviceDataGridViewRow.AccessibleObject.Click(
                MouseClickType.SingleClick,
                MouseFlags.LeftButton);
            }
            else
            {
                throw new Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException(
                        "Failed to find the search device, '" + param.DeviceName[0] + "', in the grid!");
            }
                       
            if (param.NodeType.Equals(NodeType.seed))
            {
                // right-click and delete
                deviceDataGridViewRow.AccessibleObject.Click(
                    MouseClickType.SingleClick,
                    MouseFlags.RightButton);

                Maui.Core.WinControls.Menu contextMenu =
                    new Maui.Core.WinControls.Menu(
                        Core.Common.Constants.DefaultContextMenuTimeout);

                contextMenu.ExecuteMenuItem(
                    ViewPane.Strings.AdministrationContextMenuDelete);

                // Confirm Delete Network Device
                Utilities.LogMessage(currentMethod + ":: Click confirm delete dialog.");
                string confirmationDialogTitle = Strings.AdministrationConfirmDeleteNetworkDeviceTitle;
                // confirm the operation
                CoreManager.MomConsole.ConfirmChoiceDialog(
                        true,
                        confirmationDialogTitle);

                #region Delete seed device warning dialog pop-up

                System.Threading.Thread.Sleep(3000);
                WarningDeleteDialog warDeleteDialog = null;
                try
                {
                    warDeleteDialog = new WarningDeleteDialog(CoreManager.MomConsole, 2000);
                }
                catch (Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage(currentMethod + ":: Warning to delete seed device dialog not found");
                    throw;
                }

                if (warDeleteDialog != null)
                {
                    warDeleteDialog.WaitForResponse();
                    Utilities.LogMessage(currentMethod + ":: Warning delete seed device dialog Found ");
                    warDeleteDialog.ClickClose();
                    CoreManager.MomConsole.WaitForDialogClose(warDeleteDialog, 2);
                    Utilities.LogMessage(currentMethod + ":: Warning delete seed device dialog closed.");
                }
                #endregion Delete seed device warning dialog pop-up
            }
            else //delete non seed device
            {
                switch (param.DeleteOption)
                {
                    case Options.RightClickContextMenuOption:

                        // right-click and delete
                        Utilities.LogMessage(currentMethod + ":: Right click and delete.");
                        deviceDataGridViewRow.AccessibleObject.Click(
                            MouseClickType.SingleClick,
                            MouseFlags.RightButton);

                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        contextMenu.ExecuteMenuItem(
                            ViewPane.Strings.AdministrationContextMenuDelete);

                        break;
                    case Options.TasksPaneActionOption:
                        Utilities.LogMessage(currentMethod + ":: Click task pane delelte link.");
                        MomControls.TaskStrip taskStrip = taskStrip = new MomControls.TaskStrip(CoreManager.MomConsole.ActionsPane);
                        taskStrip.Expand();
                        taskStrip.ClickLink(ViewPane.Strings.AdministrationContextMenuDelete, MouseFlags.LeftButton);
                        break;

                    default:
                        Utilities.LogMessage(currentMethod + ":: Invalid option to delete menu");

                        break;
                }

                // Confirm Delete Network Device
                Utilities.LogMessage(currentMethod + ":: Click confirm delete dialog.");
                string confirmationDialogTitle = Strings.AdministrationConfirmDeleteNetworkDeviceTitle;
                // confirm the operation
                CoreManager.MomConsole.ConfirmChoiceDialog(
                        true,
                        confirmationDialogTitle);
            }
            
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to delete a discovery rule 
        /// </summary>     
        /// <history>
        ///     [v-juli]  8Sep10 Created 
        /// </history>
        /// ------------------------------------------------------------------
        public void DeleteAllNetworkDevices()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...) Delete all manual discovered devices.");

            CoreManager.MomConsole.ViewPane.Grid.Click();            

            bool deleted = false;
            int retry = 0;
            int maxRetry = 5;

            // get the grid row, make sure have multopule devices
            while (CoreManager.MomConsole.ViewPane.Grid.Rows.Count < 4 && retry < maxRetry)
            {
                Utilities.LogMessage(currentMethod + ":: There still exists device, refresh and retry, retry times: " + retry.ToString());
                CoreManager.MomConsole.ViewPane.Grid.SendKeys(Core.Common.KeyboardCodes.F5);
                Sleeper.Delay(Constants.OneSecond * 5);
                retry++;
            }

            if (CoreManager.MomConsole.ViewPane.Grid.Rows.Count < 4)
            {
                throw new Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException(
                        "Not find multipule devices in the grid!");
            }            

            CoreManager.MomConsole.ViewPane.Grid.SendKeys(Core.Common.KeyboardCodes.Ctrl + "a");

            MomControls.TaskStrip taskStrip = taskStrip = new MomControls.TaskStrip(CoreManager.MomConsole.ActionsPane);
            taskStrip.Expand();
            taskStrip.ClickLink(ViewPane.Strings.AdministrationContextMenuDelete, MouseFlags.LeftButton);

            // Confirm Delete Network Device
            string confirmationDialogTitle = Strings.AdministrationConfirmDeleteNetworkDeviceTitle;
            // confirm the operation
            CoreManager.MomConsole.ConfirmChoiceDialog(
                    true,
                    confirmationDialogTitle);
        }

        /// <summary>
        /// Create device account through Run as Account wizard
        /// </summary>
        /// <param name="account">device account</param>
        public void CreateDeviceAccount(DeviceAccount account)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...) Create device account.");

            #region Get run as account parameters
            RunAsAccount.RunAsAccountParameters parameters = new RunAsAccount.RunAsAccountParameters();
            parameters.DisplayName = account.Name;
            parameters.Description = account.Description;
            switch (account.SecureMode)
            {
                case DeviceAcctSecureMode.LessSecure: parameters.DistributionSecurityOption = RunAsAccount.DistributionSecurityOption.LessSecure; break;
                case DeviceAcctSecureMode.MoreSecure: parameters.DistributionSecurityOption = RunAsAccount.DistributionSecurityOption.MoreSecure; break;
            }

            switch (account.AccountType)
            {
                case DeviceSNMPVersion.V1orV2:
                    parameters.Type = RunAsAccount.AccountType.Community;
                    parameters.CommunityString = account.CommunityString;
                    break;
                case DeviceSNMPVersion.V3:
                    parameters.Type = RunAsAccount.AccountType.SNMPv3;
                    parameters.Context = account.Context;
                    parameters.UserName = account.UserName;
                    parameters.AuthenticationProtocol = account.AuthenticationProtocal;
                    parameters.PrivacyProtocol = account.PrivacyProtocol;
                    parameters.AuthenticationKey = account.AuthenticationKey;
                    parameters.PrivacyKey = account.PrivacyKey;
                    break;
            }
            #endregion

            #region setting run as account wizard
            SettingRunasAccountWizard(parameters);
            #endregion
        }

        public void ExecuteIncludeFilterActions(IncludeFilterAction[] filterActions)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...) Execute filter actions");
            if (filterActions == null || filterActions.Length == 0)
            {
                Utilities.LogMessage(currentMethod + "::Parameter is null or empty.");
                return;
            }
            this.FilterDialog.WaitForResponse();
            foreach (IncludeFilterAction action in filterActions)
            {
                switch (action.actionType)
                {
                    case ActionType.add:
                        this.FilterDialog.ClickAdd();
                        AddFilterDialog addFilterDialog = new AddFilterDialog(CoreManager.MomConsole, Constants.DefaultDialogTimeout);
                        action.SettingAddFilterDialog(addFilterDialog);
                        break;
                    case ActionType.edit:
                        //TODO: edit filter
                        break;
                    case ActionType.remove:
                        //TODO: remove filter
                        break;
                }
            }
        }

        public void ExecuteExcludeFilterActions(ExcludeFilterAction[] filterActions)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...) Execute exclude filter actions.");
            if (filterActions == null || filterActions.Length == 0)
            {
                Utilities.LogMessage(currentMethod + "::Parameter is null or empty.");
                return;
            }
            this.FilterDialog.WaitForResponse();
            foreach (ExcludeFilterAction action in filterActions)
            {
                switch (action.actionType)
                {
                    case ActionType.add:
                        this.FilterDialog.ClickAdd();
                        AddFilterDialog addFilterDialog = new AddFilterDialog(CoreManager.MomConsole, Constants.DefaultDialogTimeout);
                        action.SettingExcludeIPAddressRange(addFilterDialog);
                        break;
                    case ActionType.edit:
                        //TODO: edit filter
                        break;
                    case ActionType.remove:
                        //TODO: remove filter
                        break;
                }
            }
        }

        public void ExecuteDeviceActions(DeviceAction[] deviceActionsStruct)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            // Trying to make sure there is at least one action. -- if its null (or zero) throws System.ArgumentNullException
            if (deviceActionsStruct == null)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: No actions associated to the Devices. DeviceList can not be Empty", currentMethod));
                throw new System.ArgumentNullException("No actions associated to the Devices.");
            }
            Utilities.LogMessage(currentMethod + "::(...) deviceActionsStruct.Length is" + deviceActionsStruct.Length);
            foreach (DeviceAction action in deviceActionsStruct)
            {
                this.DevicesDialog.WaitForResponse();
                switch (action.actionType)
                {
                    case ActionType.add:
                        foreach (Device device in action.devices)
                        {
                            Utilities.LogMessage(currentMethod + ":: click add." + device.DeviceNameIP + 
                                "is adding,total devices number is " + action.devices.Length);
                            AddDevice(device);  // only one device is allowed in Add/Edit func.
                        }
                        break;



                    case ActionType.edit:
                        Utilities.LogMessage(currentMethod + ":: Select the device.");
                        this.DevicesDialog.Controls.DevicesListView.FindSingleItem(action.devices[0].DeviceNameIP, true, true, true, 1).Select();
                        Utilities.LogMessage(currentMethod + ":: select device to edit.");
                        EditDevice(action.devices[0]);  // only one device is allowed in Add/Edit func.
                        break;
                    case ActionType.remove:
                        foreach (Device device in action.devices)
                        {
                            Utilities.LogMessage("RemoveDevices:: select device: " + device.DeviceNameIP);
                            this.DevicesDialog.Controls.DevicesListView.FindSingleItem(device.DeviceNameIP, true, true, true, 1).Select(KeyboardFlags.ControlFlag);
                        }
                        Utilities.LogMessage(currentMethod + ":: remove devices.");
                        RemoveDevices(action.devices);
                        break;
                }
            }
            this.DevicesDialog.WaitForResponse();
        }

        public void ExecuteAccountActions(AccountAction[] accountActions, AccountCreationPage actionPage)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");
            if (accountActions == null)
            {
                Utilities.LogMessage(currentMethod + ":: Account actions is null. Nothing to do.");
                return;
            }
            foreach (AccountAction action in accountActions)
            {
                switch (actionPage)
                {
                    #region case AccountCreationPage.DefaultAccounts
                    case AccountCreationPage.DefaultAccounts:
                        this.DefaultAccountsDialog.WaitForResponse();
                        switch (action.actionType)
                        {
                            case ActionType.select:
                                Utilities.LogMessage(currentMethod + ":: Select action account: " + action.account.Name);
                               // this.DefaultAccountsDialog.Controls.AccountsListVIew.FindAllByText(action.account.Name)[0].Checked = true;
                                FindDefaultAccountsByTest(action.account.Name)[0].Checked = true;
                                break;
                            case ActionType.create:
                                Utilities.LogMessage(currentMethod + ":: Click create button.");
                                this.DefaultAccountsDialog.ClickCreateAccount();
                                Utilities.LogMessage(currentMethod + ":: Create action account: " + action.account.Name);
                                CreateDeviceAccount(action.account);
                                break;
                        }
                        break;
                    #endregion

                    #region case AccountCreationPage.AddDevice
                    case AccountCreationPage.AddDevice:
                        this.AddaDeviceDialog.WaitForResponse();
                        switch (action.actionType)
                        {
                            case ActionType.select:
                                if (action.account.Name.ToLowerInvariant() == "~default~")
                                    this.AddaDeviceDialog.Controls.SNMPV1OrV2RunAsAccountComboBox.SelectByIndex(0);
                                else
                                    this.AddaDeviceDialog.Controls.SNMPV1OrV2RunAsAccountComboBox.SelectByText(action.account.Name);
                                break;
                            case ActionType.create:
                                this.AddaDeviceDialog.ClickAddSNMPV1OrV2RunAsAccount();
                                CreateDeviceAccount(action.account);
                                break;
                        }
                        break;
                    #endregion
                }
            }
        }

        #endregion

        #region Private Methods
        #region Import/Add/Edit/Remove Devices action methods

        /// <summary>
        /// Add Devices to be discovery during Creation or through Property page. 
        /// The second element in the array passed as param is always null. 
        /// </summary>
        /// <param name="devices">Device object that contains the Device info to be created</param>
        /// <history>
        /// [dialac] 19APR10 - Created        
        /// </history>
        private void AddDevice(Device device)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (null == device)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: The Device to be added is null.", currentMethod));
                throw new System.ArgumentNullException("The Device to be added shouldn't be null");
            }

             
            Utilities.LogMessage(currentMethod + ":: Clicking on ADD button to add a Device");
            this.DevicesDialog.Controls.ToolbarAddButton.Click();

            this.AddaDeviceDialog.WaitForResponse(5000);

            #region setting properties
            this.AddaDeviceDialog.DnsNameOrIPAddressTextBox = device.DeviceNameIP;

            //this is a workaround for setting port number .TODO
            //this.AddaDeviceDialog.PortNumberText= device.DevicePortNumber.ToString();
            this.AddaDeviceDialog.Controls.PortNumberComboBox.Click(MouseClickType.DoubleClick);
            this.AddaDeviceDialog.Controls.PortNumberComboBox.SendKeys(device.DevicePortNumber.ToString());

            switch (device.DeviceSNMPVersion)
            {
                case DeviceSNMPVersion.V1orV2:
                    this.AddaDeviceDialog.Controls.SNMPVersionComboBox.SelectByText(AddaDeviceDialog.Strings.V1orV2);
                    break;
                case DeviceSNMPVersion.V3:
                    this.AddaDeviceDialog.Controls.SNMPVersionComboBox.SelectByText(AddaDeviceDialog.Strings.V3);
                    break;
            }

            switch (device.DeviceAccessMode)
            {
                case DeviceAccessMode.ICMP:
                    this.AddaDeviceDialog.Controls.AccessModeComboBox.SelectByText(AddaDeviceDialog.Strings.ICMP);
                    break;
                case DeviceAccessMode.SNMP:
                    this.AddaDeviceDialog.Controls.AccessModeComboBox.SelectByText(AddaDeviceDialog.Strings.SNMP);
                    break;
                case DeviceAccessMode.ICMPSNMP:
                    this.AddaDeviceDialog.Controls.AccessModeComboBox.SelectByText(AddaDeviceDialog.Strings.ICMPorSNMP);
                    break;
            }

            ExecuteAccountActions(device.AccountAction, AccountCreationPage.AddDevice);
            #endregion

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.AddaDeviceDialog.Controls.OKButton, Constants.OneSecond * 2);
            this.AddaDeviceDialog.ClickOK();
            CoreManager.MomConsole.WaitForDialogClose(this.AddaDeviceDialog, 10);
            this.cachedAddaDeviceDialog = null;
        }

        /// <summary>
        /// edit device with new value.
        /// </summary>
        /// <param name="device">New device value.</param>
        private void EditDevice(Device device)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (null == device)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: The Device to be edit is null.", currentMethod));
                throw new System.ArgumentNullException("The Device to be edit shouldn't be null");
            }

            //this.DevicesDialog.ClickEdit();
            this.DevicesDialog.SendKeys(KeyboardCodes.Alt + "e");

            this.AddaDeviceDialog.WaitForResponse(5000);

            #region edit properties
            if (this.AddaDeviceDialog.PortNumberText != device.DevicePortNumber.ToString())
            {
                //this is a workaround for setting port number .TODO
                //this.AddaDeviceDialog.PortNumberText= device.DevicePortNumber.ToString();
                this.AddaDeviceDialog.Controls.PortNumberComboBox.Click(MouseClickType.DoubleClick);
                this.AddaDeviceDialog.Controls.PortNumberComboBox.SendKeys(device.DevicePortNumber.ToString());
            }

            switch (device.DeviceSNMPVersion)
            {
                case DeviceSNMPVersion.V1orV2:
                    this.AddaDeviceDialog.Controls.SNMPVersionComboBox.SelectByText(AddaDeviceDialog.Strings.V1orV2);
                    break;
                case DeviceSNMPVersion.V3:
                    this.AddaDeviceDialog.Controls.SNMPVersionComboBox.SelectByText(AddaDeviceDialog.Strings.V3);
                    break;
            }

            switch (device.DeviceAccessMode)
            {
                case DeviceAccessMode.ICMP:
                    this.AddaDeviceDialog.Controls.AccessModeComboBox.SelectByText(AddaDeviceDialog.Strings.ICMP);
                    break;
                case DeviceAccessMode.SNMP:
                    this.AddaDeviceDialog.Controls.AccessModeComboBox.SelectByText(AddaDeviceDialog.Strings.SNMP);
                    break;
                case DeviceAccessMode.ICMPSNMP:
                    this.AddaDeviceDialog.Controls.AccessModeComboBox.SelectByText(AddaDeviceDialog.Strings.ICMPorSNMP);
                    break;
            } 

            ExecuteAccountActions(device.AccountAction, AccountCreationPage.AddDevice);
            #endregion

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.AddaDeviceDialog.Controls.OKButton);
            this.AddaDeviceDialog.ClickOK();
            CoreManager.MomConsole.WaitForDialogClose(this.AddaDeviceDialog, 10);
            this.cachedAddaDeviceDialog = null;
        }

        private void RemoveDevices(Device[] devices)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (null == devices)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: The Devices to be removed is null.", currentMethod));
                throw new System.ArgumentNullException("The Devices to be removed shouldn't be null");
            }

            Utilities.LogMessage("RemoveDevices:: click remove.");
            // this.DevicesDialog.ClickRemove();
            this.DevicesDialog.SendKeys(KeyboardCodes.Alt + "r");
        }

        private void ImportDevices(string importFile)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            if (string.IsNullOrEmpty(importFile))
                throw new ArgumentNullException();

            if (!File.Exists(importFile))
            {
                throw new FileNotFoundException("Import File noe exist!");
            }
            Utilities.LogMessage(currentMethod+":: click import.");

            this.DevicesDialog.SendKeys(KeyboardCodes.Alt + "i");

            Utilities.LogMessage(currentMethod + ":: open file.");
            Mom.Test.UI.Core.Console.Dialogs.OpenDialog openDialog = new Mom.Test.UI.Core.Console.Dialogs.OpenDialog(CoreManager.MomConsole, Mom.Test.UI.Core.Console.Dialogs.OpenDialog.Strings.DialogTitle);
            openDialog.FileNameText = importFile;
            openDialog.ClickOpen();
            Utilities.LogMessage(currentMethod + ":: Wait for dialog close.");
            CoreManager.MomConsole.WaitForDialogClose(openDialog, 2);
        }
        #endregion

        /// <summary>
        /// Try to find and select a discovery rule in the View. 
        /// Return false if the rule is not found in the view. 
        /// </summary>
        /// <param name="ruleName">Rule Name to be found/selected</param> 
        /// <history>
        /// [dialac] 10May10 - Created        
        /// </history>
        public bool FindDiscoveryRuleEntryView(string ruleName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...)");

            //Initializing the output parameter
            bool foundRule = false;

            //Checking the input parameters
            if (ruleName == null || ruleName == String.Empty)
            {
                Utilities.LogMessage(String.Format(
                    "{0}:: the Discovery Rule Name user passed is null/Empty.", currentMethod));
                throw new System.ArgumentNullException("Discovery Rule Name user passed to be found is null/Empty");
            }

            CoreManager.MomConsole.BringToForeground();

            #region Navigate to View

            // navigate to corresponding view
            CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(
                NavigationPane.WunderBarButton.Administration);

            
            string AdministrationPath = NavigationPane.Strings.Administration;

            string treeNodeText = NavigationPane.Strings.AdminTreeViewDiscoveryRules;

            CoreManager.MomConsole.NavigationPane.SelectNode(treeNodeText);

            
            #endregion Navigate to View

            #region Wait for Rule

            string displayName = ruleName;
            string searchColumn = ViewPane.Strings.AdministrationGridViewColumnName;

            // set wait loop parameters
            // wait for device to appear, max wait:  one minute
            int timeWaited = 0;
            const int MaxTimeWaited = 900;

            while (foundRule == false && timeWaited < MaxTimeWaited)
            {
                CoreManager.MomConsole.Waiters.WaitForObjectPropertyChangedSafe(CoreManager.MomConsole.ViewPane.Grid, "@IsVisible", PropertyOperator.Equals, true);
                // refresh the view
                CoreManager.MomConsole.ViewPane.Grid.Click();
                CoreManager.MomConsole.SendKeys(Core.Common.KeyboardCodes.F5);

                // look for the device in the grid
                if (CoreManager.MomConsole.ViewPane.Grid.FindData(displayName, searchColumn) != null)
                {
                    foundRule = true;
                }
                else
                {
                    // increment the seconds waited
                    timeWaited = timeWaited + 2;

                    // sleep for two seconds
                    Maui.Core.Utilities.Sleeper.Delay(2000);
                }
            }

            Core.Common.Utilities.LogMessage(currentMethod + "::Waited " + timeWaited + " seconds for rule to appear.");

            #endregion Wait for Rule

            #region Report Success or Failure

            // verify rule in view
            if (foundRule == true)
            {
                Core.Common.Utilities.LogMessage(
                    currentMethod + "::Successfully discovered rule:  " +
                    ruleName);
            }
            else
            {
                Core.Common.Utilities.LogMessage(
                   currentMethod + "::Failed to discover rule:  " +
                   ruleName);
            }
            #endregion Report Success or Failure

            return foundRule;

        }

        private ListViewItem[] FindDefaultAccountsByTest(string account)
        {
            List<ListViewItem> result = new List<ListViewItem>();
            foreach (ListViewItem item in this.DefaultAccountsDialog.Controls.AccountsListVIew.Items)
            {
                if (item.SubItems[0].Text == account)
                    result.Add(item);
            }
            return result.ToArray();
        }

        public void SettingRunasAccountWizard(RunAsAccount.RunAsAccountParameters parameters)
        {
            RunAsAccount runasAccount = new RunAsAccount();
           
            #region Navigate through the RunAs Account Wizard

            #region RunAs Account Wizard - Introduction Page

            runasAccount.introductionDialog.ClickNext();
            #endregion RunAs Account Wizard - Introduction Page

            #region RunAs Account Wizard - General Properties Page

            //Select the Account Type
            switch (parameters.Type)
            {
                case RunAsAccount.AccountType.Community:
                    if (runasAccount.generalDialog.Controls.RunAsAccountTypeComboBox.IsEnabled)
                        runasAccount.generalDialog.Controls.RunAsAccountTypeComboBox.SelectByText(RunAsAccount.Strings.CommunityAccountType);
                    Utilities.LogMessage("RunAsAccount.Create :: Account Type selected is " + RunAsAccount.Strings.CommunityAccountType);
                    break;

                case RunAsAccount.AccountType.SNMPv3:
                    if (runasAccount.generalDialog.Controls.RunAsAccountTypeComboBox.IsEnabled)
                        runasAccount.generalDialog.Controls.RunAsAccountTypeComboBox.SelectByText(RunAsAccount.Strings.SNMPv3Type);
                    Utilities.LogMessage("RunAsAccount.Create :: Account Type selected is " + RunAsAccount.Strings.SNMPv3Type);
                    break;
                default:
                    break;
            }

            runasAccount.generalDialog.DisplayNameText = parameters.DisplayName;
            Utilities.LogMessage("RunAsAccount.Create :: Successfully set display name");
            Utilities.LogMessage("RunAsAccount.Create :: Display Name right after setting is '"
                + runasAccount.generalDialog.DisplayNameText + "'");

            //Trying to set the description if its null throws System.ArgumentNullException
            if (parameters.Description != null)
            {
                runasAccount.generalDialog.DescriptionText = parameters.Description;
                Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond);
                Utilities.LogMessage("RunAsAccount.Create :: Description right after setting is '"
                    + runasAccount.generalDialog.DescriptionText + "'");
            }

            runasAccount.generalDialog.ClickNext();

            #endregion RunAs Account Wizard - General Properties Page

            #region RunAs Account Wizard - Credentials Page

            switch (parameters.Type)
            {
                case RunAsAccount.AccountType.Community:
                    runasAccount.communityAccountDialog.CommunityStringText = parameters.CommunityString;
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully set community string");
                    runasAccount.windowsAccountDialog.ClickCreate();
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully Clicked on Create");
                    break;

                case RunAsAccount.AccountType.SNMPv3:
                    runasAccount.snmpv3AccountDialog.UserNameText = parameters.UserName;
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully set User Name " + parameters.UserName);
                    runasAccount.snmpv3AccountDialog.ContextOptionalText = parameters.Context;
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully set Context " + parameters.Context);

                    Utilities.LogMessage("RunAsAccount.Create :: Check the controls status");
                    if (runasAccount.snmpv3AccountDialog.Controls.ConfirmAuthenticationKeyTextBox.IsEnabled ||
                        runasAccount.snmpv3AccountDialog.Controls.AuthenticationKeyTextBox.IsEnabled ||
                        runasAccount.snmpv3AccountDialog.Controls.PrivacyProtocolComboBox.IsEnabled ||
                        runasAccount.snmpv3AccountDialog.Controls.PrivacyKeyTextBox.IsEnabled ||
                        runasAccount.snmpv3AccountDialog.Controls.ConfirmPrivacyKeyTextBox.IsEnabled
                        )
                    {
                        throw new System.ApplicationException("Invalid feilds are enabled.");
                    }

                    runasAccount.snmpv3AccountDialog.Controls.AuthenticationProtocolComboBox.SelectByIndex((int)parameters.AuthenticationProtocol);
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully set AuthenticationProtocol " + parameters.AuthenticationProtocol);

                    if (parameters.AuthenticationProtocol != RunAsAccount.SNMPv3APType.None)
                    {
                        #region Check that the AuthenticationKey and AuthenticationKeyConfirm controls are enabled
                        int attempt = 1;
                        int maxAttempts = 4;

                        while ((!runasAccount.snmpv3AccountDialog.Controls.AuthenticationKeyTextBox.IsEnabled ||
                               !runasAccount.snmpv3AccountDialog.Controls.ConfirmAuthenticationKeyTextBox.IsEnabled) &&
                               attempt < maxAttempts)
                        {
                            Sleeper.Delay(Constants.OneSecond);
                            string message = "RunAsAccount.Create :: AuthenticationKey controls not enabled... attempt '{0}' of '{1}'";
                            Utilities.LogMessage(String.Format(message, attempt, maxAttempts));
                            ++attempt;
                        }

                        if (attempt == maxAttempts)
                        {
                            throw new Maui.GlobalExceptions.TimedOutException("AuthenticationKey controls not enabled");
                        }
                        #endregion Check that the AuthenticationKey and AuthenticationKeyConfirm controls are enabled

                        runasAccount.snmpv3AccountDialog.AuthenticationKeyText = parameters.AuthenticationKey;
                        Utilities.LogMessage("RunAsAccount.Create :: Successfully set AuthenticationKey " + parameters.AuthenticationKey);
                        runasAccount.snmpv3AccountDialog.ConfirmAuthenticationKeyText = parameters.AuthenticationKey;
                        Utilities.LogMessage("RunAsAccount.Create :: Successfully set ConfirmAuthenticationKey " + parameters.AuthenticationKey);

                        Utilities.LogMessage("RunAsAccount.Create :: Check the controls status");
                        if (runasAccount.snmpv3AccountDialog.Controls.PrivacyKeyTextBox.IsEnabled ||
                            runasAccount.snmpv3AccountDialog.Controls.ConfirmPrivacyKeyTextBox.IsEnabled
                            )
                        {
                            throw new ApplicationException("Invalid fields are enabled.");
                        }

                        runasAccount.snmpv3AccountDialog.Controls.PrivacyProtocolComboBox.SelectByIndex((int)parameters.PrivacyProtocol);
                        Utilities.LogMessage("RunAsAccount.Create :: Successfully set PrivacyProtocol " + parameters.PrivacyProtocol);

                        if (parameters.PrivacyProtocol != RunAsAccount.SNMPv3PPType.None)
                        {
                            #region Check that the PrivacyKey and PrivacyKeyConfirm controls are enabled
                            attempt = 1;

                            while ((!runasAccount.snmpv3AccountDialog.Controls.PrivacyKeyTextBox.IsEnabled ||
                                   !runasAccount.snmpv3AccountDialog.Controls.ConfirmPrivacyKeyTextBox.IsEnabled) &&
                                   attempt < maxAttempts)
                            {
                                Sleeper.Delay(Constants.OneSecond);
                                string message = "RunAsAccount.Create :: PrivacyKey controls not enabled... attempt '{0}' of '{1}'";
                                Utilities.LogMessage(String.Format(message, attempt, maxAttempts));
                                ++attempt;
                            }

                            if (attempt == maxAttempts)
                            {
                                throw new Maui.GlobalExceptions.TimedOutException("PrivacyKey controls not enabled");
                            }
                            #endregion Check that the PrivacyKey and PrivacyKeyConfirm controls are enabled

                            runasAccount.snmpv3AccountDialog.PrivacyKeyText = parameters.PrivacyKey;
                            Utilities.LogMessage("RunAsAccount.Create :: Successfully set PrivacyKey " + parameters.PrivacyKey);
                            runasAccount.snmpv3AccountDialog.ConfirmPrivacyKeyText = parameters.PrivacyKey;
                            Utilities.LogMessage("RunAsAccount.Create :: Successfully set ConfirmPrivacyKey " + parameters.PrivacyKey);
                        }
                    }

                    runasAccount.windowsAccountDialog.ClickCreate();
                    Utilities.LogMessage("RunAsAccount.Create :: Successfully Clicked on Create");
                    break;
            }

            #endregion RunAs Account Wizard - Credentials Page

            CoreManager.MomConsole.Waiters.WaitForWindowClose(runasAccount.windowsAccountDialog, Common.Constants.DefaultDialogTimeout);
  
            Utilities.LogMessage("RunAsAccount.Create:: Successfully completed the wizard");

            #endregion Navigate through the RunAs Account Wizard
        }
        #endregion

        #region String Class

        public class Strings
        {
            #region Constants


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ImportDeviceButtonsToolStrip
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceImportDevicesButtonsToolStrip = ";Import devices;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.NetworkDiscovery.Devices;importButton.ToolTipText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddDevicesButtonsToolStrip
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddDevicesButtonsToolStrip = ";Add devices;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.NetworkDiscovery.Devices;addButton.ToolTipText";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ResourceAdministrationConfirmDeleteDiscoveryRuleDialogTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdministrationConfirmDeleteDiscoveryRuleDialogTitle =
                ";Delete Discovery Rule;" +
                "ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;" +
                "DeleteDiscoveryRuleTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  ResourceAdministrationConfirmDeleteNetworkDeviceTitle
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAdministrationConfirmDeleteNetworkDeviceTitle =
                ";Confirm Delete Network Device;" +
                "ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;" +
                "NetworkDeviceDeleteTitle";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  IP Address
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceIPAddress =
                ";IP Address;ManagedString;" +
                "Microsoft.EnterpriseManagement.UI.Administration.dll;" +
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;" +
                "ViewColumnIPAddress";
            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Cached reference for ADD Devices Toolbar item.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAddToolbarItem;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Cached reference for Delete Discovery Rule Dialog Title.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationConfirmDeleteDiscoveryRuleDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Cached reference for Delete Device Dialog Title.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdministrationConfirmDeleteNetworkDeviceTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Cached reference for Column IP Address.
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedIPAddress;

            #endregion

            #region Properties
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Import Devices translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/18/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ImportDevices
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(ResourceImportDevicesButtonsToolStrip);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Gets access to the Add Devices translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 4/18/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddDevicesToolBarItem
            {
                get
                {
                    if ((cachedAddToolbarItem == null))
                    {
                        cachedAddToolbarItem = CoreManager.MomConsole.GetIntlStr(ResourceAddDevicesButtonsToolStrip);

                        //Remove Ampersand from this string 
                        string removeAmp = String.Copy(cachedAddToolbarItem);
                        cachedAddToolbarItem = removeAmp.Replace("&", "");
                    }

                    return cachedAddToolbarItem;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AdministrationConfirmDeleteDiscoveryRuleDialogTitle translated resource string
            /// </summary>
            /// <history>
            ///   [dialac] 5/10/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationConfirmDeleteDiscoveryRuleDialogTitle
            {
                get
                {
                    if (cachedAdministrationConfirmDeleteDiscoveryRuleDialogTitle == null)
                    {
                        cachedAdministrationConfirmDeleteDiscoveryRuleDialogTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAdministrationConfirmDeleteDiscoveryRuleDialogTitle);
                    }

                    return cachedAdministrationConfirmDeleteDiscoveryRuleDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ResourceAdministrationConfirmDeleteNetworkDeviceTitle translated resource string
            /// </summary>
            /// <history>
            ///   [v-juli] 9/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdministrationConfirmDeleteNetworkDeviceTitle
            {
                get
                {
                    if (cachedAdministrationConfirmDeleteNetworkDeviceTitle == null)
                    {
                        cachedAdministrationConfirmDeleteNetworkDeviceTitle =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceAdministrationConfirmDeleteNetworkDeviceTitle);
                    }

                    return cachedAdministrationConfirmDeleteNetworkDeviceTitle;
                }
            }
                   
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the IPAddress translated resource string
            /// </summary>
            /// <history>
            ///   [v-juli] 9/8/2010 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string IPAddress
            {
                get
                {
                    if (cachedIPAddress == null)
                    {
                        cachedIPAddress =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceIPAddress);
                    }

                    return cachedIPAddress;
                }
            }

            #endregion

        }

        #endregion

        #region "COMMENTED _ TODO"

        //#region Public Static Methods

        ///// ------------------------------------------------------------------
        ///// <summary>
        ///// Method to discover the named device and manage it.
        ///// </summary>
        ///// <param name="deviceName">Name of the Windows computer</param>
        ///// <param name="domainName">Name of the AD domain</param>
        ///// <param name="deviceType">Enumeration indicating the device type</param>
        ///// <param name="managementMode">Enumeration indicating the management mode</param>
        ///// <param name="showTaskProgress">Flag to indicate whether to show task status dialog</param>
        ///// <param name="verifyDeviceAppears">Flag to indicate whether to verify device appears in the UI</param>
        ///// <returns>True if successful, otherwise false</returns>
        ///// <exception cref="System.ArgumentException">
        ///// Throws a System.ArgumentException if unknown values are used for
        ///// deviceType or managementMode.  Or if conflicting values are used,
        ///// e.g. deviceType = DeviceType.NetworkDevice AND 
        ///// managementMode = ManagementMode.AgentManaged.
        ///// </exception>
        ///// <exception cref="Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException">
        ///// Throws ItemNotFoundException if it cannot find a discovered device or cannot 
        ///// add a discovered device to the list of managed devices.
        ///// </exception>
        ///// <exception cref="Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException">
        ///// Throws a NodeNotFoundException if it cannot find a tree view node.
        ///// </exception>
        ///// <exception cref="Maui.Core.Window.Exceptions.WindowNotFoundException">
        ///// Throws a WindowNotFoundException if it cannot find a particular
        ///// wizard window or dialog.
        ///// </exception>
        ///// <history>
        /////     [KellyMor]  21SEP05 Created
        /////     [KellyMor]  16NOV05 Modified DiscoverDevice to support SCE
        /////     [KellyMor]  07DEC05 Modified DiscoverDevice to skip checkbox for
        /////                         'Show task progress' on SCE
        /////     [KellyMor]  07FEB06 Modified to use new discovery wizard UI
        /////     [KellyMor]  09FEB06 Added delay to fix bug ID# 60992
        /////      [jnwoko]  06OCT08  Modified code to work with Xplat Improvement ID#112171
        /////      [a-joelj]  22DEC09 Now using the localized resource string for "Error" dialog 
        /////                         if IP range issue occurs to fix SM bug# 162962 
        ///// </history>
        ///// ------------------------------------------------------------------
        //public static bool DiscoverDevice(
        //    string deviceName,
        //    string domainName,
        //    DeviceDiscovery.DeviceType deviceType,
        //    DeviceDiscovery.ManagementMode managementMode,
        //    bool showTaskProgress,
        //    bool verifyDeviceAppears)
        //{
        //    string deviceIpAddress = null;
        //    string deviceNameFqdn = null;
        //    int waitTime = 1000;
        //    deviceNameFqdn = Core.Common.Utilities.GetServerNameFqdn(deviceName);
        //    Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::parameters");
        //    Core.Common.Utilities.LogMessage("deviceName:  '" + deviceName + "'");
        //    Core.Common.Utilities.LogMessage("deviceNameFqdn: " + deviceNameFqdn + "");
        //    Core.Common.Utilities.LogMessage("domainName:  '" + domainName + "'");
        //    Core.Common.Utilities.LogMessage("deviceType:  '" + deviceType + "'");
        //    Core.Common.Utilities.LogMessage("managementMode:  '" + managementMode + "'");


        //    #region Navigate and Start Wizard

        //    Core.Common.Utilities.LogMessage(
        //        "DeviceDiscovery::DiscoverDevice::Navigating to Administration view...");

        //    // navigate to the administration view
        //    CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(
        //        NavigationPane.WunderBarButton.Administration);

        //    Core.Common.Utilities.LogMessage(
        //        "DeviceDiscovery::DiscoverDevice::Selecting 'Device Management' node...");

        //    // use core navigation method to find the view
        //    Maui.Core.WinControls.TreeNode deviceManagement =
        //        CoreManager.MomConsole.NavigationPane.SelectNode(
        //            NavigationPane.Strings.AdminTreeViewAdministrationRoot +
        //            "\\" +
        //            NavigationPane.Strings.AdminTreeViewDeviceManagement,
        //            NavigationPane.NavigationTreeView.Administration);

        //    // select the device management node
        //    //Maui.Core.WinControls.TreeNode deviceManagement =
        //    //    CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(
        //    //        NavigationPane.Strings.AdminTreeViewDeviceManagement);

        //    // trick to get around Maui issue
        //    // deviceManagement.Select();
        //    // deviceManagement.Click();

        //    Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Starting discovery wizard...");

        //    // start the wizard from the context menu
        //    deviceManagement.Click(
        //        MouseClickType.SingleClick, MouseFlags.RightButton);
        //    Maui.Core.WinControls.Menu contextMenu =
        //        new Maui.Core.WinControls.Menu(
        //            Core.Common.Constants.DefaultContextMenuTimeout);
        //    contextMenu.ExecuteMenuItem(
        //        NavigationPane.Strings.ContextMenuDiscoveryWizard);
        //    #endregion

        //    #region Find and verify Wizard Page
        //    // find the discovery wizard welcome window
        //    DeviceDiscovery.Wizards.ComputerAndDeviceType discoveryWizard =
        //        new Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.ComputerAndDeviceType(
        //            CoreManager.MomConsole);
        //    Core.Common.Utilities.LogMessage(
        //        "discoveryWizard::Found discovery wizard window...");
        //    #endregion // Navigate and Start Wizard

        //    #region Select Device Type to be discovered

        //    /*Perform action to select if network devices or windows computers here
        //     *Click Next */
        //    // select the corresponding device types.  
        //    switch (deviceType)
        //    {
        //        case DeviceType.WindowsComputer:
        //            {
        //                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting Windows computer types.");
        //                //discoveryWizard.Controls.WindowsComputersStaticControl.SendKeys("%{w}");
        //                discoveryWizard.Controls.WindowsComputersStaticControl.Click();
        //            }
        //            break;
        //        case DeviceType.NetworkDevice:
        //            {
        //                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Selecting etwork Device types.");
        //                //discoveryWizard.Controls.NetworkDevicesStaticControl.SendKeys("%{v}");
        //                discoveryWizard.Controls.NetworkDevicesStaticControl.Click();
        //            }
        //            break;
        //        default:
        //            {
        //                throw new ArgumentException("DeviceDiscovery::DiscoverDevice::Unknown device type:  '" + deviceType + "'");
        //            }
        //    }
        //    //waiting 1 second
        //    Sleeper.Delay(waitTime);
        //    Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Clicking 'Next' button...");
        //    // move past the "First" screen, i.e. click "Next"
        //    discoveryWizard.ClickNext();
        //    #endregion

        //    #region Set Discovery Method
        //    /* If selection is Windows Computer: Select Discover Method and Click next 
        //     * Else If- Network Devices Do nothing
        //     * */
        //    Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting discovery method...");
        //    // set the device type options  
        //    if (deviceType == DeviceType.WindowsComputer)
        //    {
        //        // find the discovery method window
        //        DeviceDiscovery.Wizards.DiscoveryMethodWindow discoveryMethod =
        //            new Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.DiscoveryMethodWindow(
        //                CoreManager.MomConsole);

        //        // set the discovery method to "Advanced"
        //        discoveryMethod.Controls.AdvancedDiscoveryRadioButton.Click();


        //        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting Windows computers...");

        //        // Select Servers & Clients by default
        //        discoveryMethod.Controls.ComputerDeviceTypesComboBox.SelectByText(
        //            Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.DiscoveryMethodWindow.Strings.ServersAndClients);

        //        // click "Next"
        //        CoreManager.MomConsole.WaitForEnabledButton(discoveryMethod.Controls.NextButton, OneMinuteInSeconds);
        //        discoveryMethod.ClickNext();
        //    }
        //    else if (deviceType == DeviceType.NetworkDevice)
        //    {
        //        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::This step is not applicable to Network devices...");
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Device type argument is invalid!\n\r" +
        //            "Value does not match any DeviceType enum value:  " + deviceType);
        //    }

        //    #endregion // Set Discovery Method

        //    #region Set Management Server or Proxy Agent

        //    Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting Management Server / Proxy Agent...");

        //    // if there's more than one management server, 
        //    if (deviceType == DeviceType.WindowsComputer)
        //    {
        //        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting Management Server...");

        //        // TODO: Add support for multiple management servers - BETA 2
        //        // set it
        //        // click "Next"
        //    }
        //    else if (deviceType == DeviceType.NetworkDevice)
        //    {
        //        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting Proxy Agent...");

        //        // TODO: Add support for proxy agents - BETA 2
        //        // if network device, set proxy agent
        //        // click "Next"
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Device type argument is invalid!\n\r" +
        //            "Value does not match any DeviceType enum value:  " + deviceType);
        //    }

        //    #endregion // Set Management Server or Proxy Agent

        //    #region Set Query Options

        //    Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting query options...");

        //    // find the query type window
        //    DeviceDiscovery.Wizards.QueryCriteriaWindow queryCriteria =
        //        new Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.QueryCriteriaWindow(
        //        CoreManager.MomConsole);

        //    // allow this step some time to render
        //    UISynchronization.WaitForUIObjectReady(queryCriteria);
        //    Sleeper.Delay(500);

        //    // set the query type according to device type
        //    if (deviceType == DeviceType.WindowsComputer)
        //    {
        //        #region Scan AD Query

        //        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting LDAP query...");

        //        // set query type to Search AD/LDAP
        //        CoreManager.MomConsole.WaitForEnabledButton(queryCriteria.Controls.ScanActiveDirectoryRadioButton, OneMinuteInSeconds);
        //        queryCriteria.Controls.ScanActiveDirectoryRadioButton.Click();

        //        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Starting Query Builder/Find Computers dialog...");

        //        // start the "Find Computers" dialog
        //        CoreManager.MomConsole.WaitForEnabledButton(queryCriteria.Controls.ConfigureButton, OneMinuteInSeconds);
        //        queryCriteria.ClickConfigure();

        //        // find the "Find Computers" dialog
        //        Dialogs.FindComputersDialog findComputers =
        //            new Mom.Test.UI.Core.Console.Dialogs.FindComputersDialog(
        //            CoreManager.MomConsole);
        //        UISynchronization.WaitForUIObjectReady(
        //            findComputers,
        //            UI.Core.Common.Constants.DefaultDialogTimeout);

        //        // wait for the text box to become enabled
        //        int MaxAttempts = 15;
        //        for (int attempts = 1; ((MaxAttempts >= attempts) && (false == findComputers.Controls.ComputerNameTextBox.IsEnabled)); attempts++)
        //        {
        //            Core.Common.Utilities.LogMessage(
        //                "DeviceDiscovery::DiscoverDevice::Waiting for text box ready, attempt " +
        //                attempts +
        //                " of " +
        //                MaxAttempts);
        //            Maui.Core.Utilities.Sleeper.Delay(3000);
        //        }

        //        // check to see if the text box is finally ready.
        //        if (true == findComputers.Controls.ComputerNameTextBox.IsEnabled)
        //        {
        //            // add the device name
        //            findComputers.ComputerNameText = deviceName;
        //            findComputers.ClickOK();
        //        }
        //        else
        //        {
        //            throw new TimedOutException("Find Computers::Computer Name text box failed to become enabled!");
        //        }

        //        // set the domain name
        //        if (queryCriteria.Controls.DomainEditComboBox.EnumerateItems.Contains(
        //            domainName.ToUpperInvariant()))
        //        {
        //            queryCriteria.Controls.DomainEditComboBox.SelectByText(
        //                domainName.ToUpperInvariant());
        //        }
        //        else
        //        {
        //            // enter the domain name as text
        //            queryCriteria.Controls.DomainEditComboBox.Text =
        //                domainName.ToUpperInvariant();
        //        }
        //        CoreManager.MomConsole.WaitForEnabledButton(queryCriteria.Controls.NextButton, OneMinuteInSeconds);
        //        if (queryCriteria.Controls.NextButton.IsEnabled == true)
        //        {
        //            // click "Next"
        //            queryCriteria.ClickNext();
        //        }
        //        else
        //        {
        //            //The Find Computers dialog sometimes takes longer to go away resulting in a timing issue 
        //            //where call to the Next button fails so waiting for 5 secs before clicking next

        //            Core.Common.Utilities.LogMessage(
        //                "DeviceDiscovery::DiscoverDevice::Waiting for Find Computers dialog to close");
        //            Sleeper.Delay(waitTime * 5);
        //            // click "Next"
        //            queryCriteria.ClickNext();
        //        }

        //        #endregion
        //    }
        //    else if (deviceType == DeviceType.NetworkDevice)
        //    {
        //        #region Scan IP Address Range

        //        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting Specific IP address range...");

        //        // configure the agent for SNMP
        //        Utilities.ConfigureAgentSnmp(
        //            deviceName,
        //            Core.Common.Topology.RootMomSdkServerName,
        //            deviceName + "_public");

        //        // set the IP address of the target device
        //        Core.Common.Utilities.LogMessage(
        //            "DeviceDiscovery::DiscoverDevice::Getting MOM device IP address for:  '" +
        //            deviceNameFqdn +
        //            "'");

        //        #region MOM Device IPv4 Address

        //        // get the IP address of the target device
        //        Core.Common.Utilities.LogMessage(
        //            "DeviceDiscovery::DiscoverDevice::Getting MOM device IP addresses...");

        //        // get the list of IP addresses assigned to the device
        //        System.Net.IPAddress[] momDeviceIpAddresses =
        //            System.Net.Dns.GetHostEntry(deviceName).AddressList;

        //        // check for a list of valid, IP addresses
        //        if (null != momDeviceIpAddresses && 0 < momDeviceIpAddresses.Length)
        //        {
        //            // loop through the available addresses for IPv4 addresses only
        //            foreach (System.Net.IPAddress address in momDeviceIpAddresses)
        //            {
        //                // look for an IPv4 address
        //                if (System.Net.Sockets.AddressFamily.InterNetwork == address.AddressFamily)
        //                {
        //                    // save this address
        //                    deviceIpAddress = address.ToString();

        //                    Core.Common.Utilities.LogMessage(
        //                        "DeviceDiscovery::DiscoverDevice::MOM Device IPv4:  " +
        //                        deviceIpAddress);

        //                    // exit the loop
        //                    break;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            throw new System.ArgumentOutOfRangeException(
        //                "No IP addresses available for the current MOM device := '" +
        //                deviceName +
        //                "'");
        //        }

        //        #endregion MOM Device IPv4 Address

        //        #region Set Specified IP Address Range Options

        //        // make sure we have an IP address
        //        if (null != deviceIpAddress &&
        //            deviceIpAddress.Length > 0)
        //        {
        //            // get the IP address range wizard window
        //            DeviceDiscovery.Wizards.IpAddressRangeWindow wizardIpAddressRange =
        //                new DeviceDiscovery.Wizards.IpAddressRangeWindow(CoreManager.MomConsole);

        //            // Split address by "." and create range for scan
        //            string[] octets = deviceIpAddress.Split('.');
        //            if (0 < octets.Length)
        //            {
        //                #region Build Upper and Lower IP Addresses

        //                // get the last octet
        //                int lastOctet = Int16.Parse(octets[(octets.Length - 1)]);

        //                // create a new lower address
        //                StringBuilder addressBuilder = new StringBuilder();

        //                // lower the last octect by one
        //                lastOctet--;

        //                // check for valid octect low boundary
        //                if (lastOctet <= 0)
        //                {
        //                    lastOctet = 0;
        //                }

        //                // create the string version of the new IP
        //                addressBuilder.Append(octets[0]);
        //                addressBuilder.Append(".");
        //                addressBuilder.Append(octets[1]);
        //                addressBuilder.Append(".");
        //                addressBuilder.Append(octets[2]);
        //                addressBuilder.Append(".");
        //                addressBuilder.Append(lastOctet.ToString());
        //                string lowerAddress = addressBuilder.ToString().Trim();

        //                // create an upper address
        //                lastOctet += 2;

        //                // check for valid octect upper boundary
        //                if (lastOctet > 255)
        //                {
        //                    // reset to highest valid value
        //                    lastOctet = 255;
        //                }

        //                // create the string version of the new IP
        //                addressBuilder = new StringBuilder();
        //                addressBuilder.Append(octets[0]);
        //                addressBuilder.Append(".");
        //                addressBuilder.Append(octets[1]);
        //                addressBuilder.Append(".");
        //                addressBuilder.Append(octets[2]);
        //                addressBuilder.Append(".");
        //                addressBuilder.Append(lastOctet.ToString());
        //                string upperAddress = addressBuilder.ToString().Trim();

        //                #endregion

        //                try
        //                {
        //                    //[v-liqluo] Add retry logic to set IP address,
        //                    //because the SendKeys.SendWait() doesn't always work correctly.
        //                    Button discoveryButton = new Button(
        //                        wizardIpAddressRange.Controls.DiscoverButton);
        //                    int maxTries = 5;
        //                    int retryCount = 1;

        //                    while (discoveryButton != null && !discoveryButton.IsEnabled && retryCount <= maxTries)
        //                    {
        //                        //Clear the two IP addresses first
        //                        wizardIpAddressRange.Controls.StartTextBox.Text = string.Empty;
        //                        wizardIpAddressRange.Controls.EndTextBox.Text = string.Empty;

        //                        // set lower address
        //                        Core.Common.Utilities.LogMessage(
        //                            "DeviceDiscovery::DiscoverDevice::Setting lower IP address to:  '" +
        //                            lowerAddress +
        //                            "', attempt " + retryCount + " of " + maxTries);

        //                        // wizardIpAddressRange.Controls.StartTextBox.SendKeys(lowerAddress);
        //                        //
        //                        // [nathd] - Updating because SendKeys no longer worked after upgrading 
        //                        // to Maui 2.0. According to MBickle this change is necessary as the
        //                        // IP Address TextBox doesn't accept Unicode... need to follow-up and 
        //                        // confirm.
        //                        wizardIpAddressRange.Controls.StartTextBox.Click();
        //                        System.Windows.Forms.SendKeys.SendWait(lowerAddress);

        //                        // set upper address
        //                        Core.Common.Utilities.LogMessage(
        //                            "DeviceDiscovery::DiscoverDevice::Setting upper IP address to:  '" +
        //                            upperAddress +
        //                            "', attempt " + retryCount + " of " + maxTries);

        //                        // wizardIpAddressRange.Controls.EndTextBox.SendKeys(upperAddress);
        //                        //
        //                        // [nathd] - Updating because SendKeys no longer worked after upgrading 
        //                        // to Maui 2.0. According to MBickle this change is necessary as the
        //                        // IP Address TextBox doesn't accept Unicode... need to follow-up and 
        //                        // confirm.
        //                        wizardIpAddressRange.Controls.EndTextBox.Click();
        //                        System.Windows.Forms.SendKeys.SendWait(upperAddress);

        //                        //sleep one second to wait Discovery Button become enabled
        //                        Sleeper.Delay(1000);
        //                        retryCount++;
        //                    }

        //                    //Check if IP addresses are set correctly finally
        //                    if (retryCount > maxTries && discoveryButton != null && !discoveryButton.IsEnabled)
        //                    {
        //                        throw new Maui.Core.WinControls.Button.Exceptions.CheckFailedException(
        //                            "Discovery Button is still disable after max retry of Setting IP address" +
        //                            " through SendKeys.SendWait().");
        //                    }
        //                }
        //                catch (Maui.Core.Window.Exceptions.UnknownActiveWinException)
        //                {
        //                    Core.Common.Utilities.LogMessage(
        //                        "DeviceDiscoveryWizard.SetQueryCriteria :: Error setting IP addresses; " +
        //                        "clearing dialog and retrying");

        //                    //dismiss Error dialog
        //                    Core.Common.Utilities.LogMessage("DeviceDiscoveryWizard.SetQueryCriteria :: Clearing Error dialog " +
        //                        "and substituting spaces for periods in IP addresses");
        //                    CoreManager.MomConsole.ConfirmChoiceDialog(
        //                        Core.Console.MomConsoleApp.ButtonCaption.OK,
        //                        Core.Console.DeviceDiscovery.Wizards.IpAddressRangeWindow.Strings.Error,
        //                        Maui.Core.Utilities.StringMatchSyntax.ExactMatch,
        //                        Core.Console.MomConsoleApp.ActionIfWindowNotFound.Ignore);
        //                    wizardIpAddressRange.Extended.SetFocus();
        //                    Core.Common.Utilities.LogMessage("DeviceDiscoveryWizard.SetQueryCriteria :: Error dialog cleared");

        //                    //This solution (3 backspaces) assumes that the 2nd octet had the problem
        //                    //which has always been the case so far (10.194.196.225 becomes 101.941. where
        //                    //941 > 255 so the dialog throws an error and blocks further entry
        //                    //if this were ever not the case, this hard-coded approach would not work
        //                    wizardIpAddressRange.Controls.StartTextBox.SendKeys(UI.Core.Common.KeyboardCodes.Backspace +
        //                        UI.Core.Common.KeyboardCodes.Backspace + UI.Core.Common.KeyboardCodes.Backspace);

        //                    //and retry setting lower address
        //                    lowerAddress = lowerAddress.Replace(".", " ");

        //                    // retry setting lower address
        //                    Core.Common.Utilities.LogMessage(
        //                        "DeviceDiscoveryWizard.SetQueryCriteria :: retrying using format:  '" +
        //                                lowerAddress +
        //                                "'");
        //                    wizardIpAddressRange.Controls.StartTextBox.SendKeys(lowerAddress);

        //                    upperAddress = upperAddress.Replace(".", " ");

        //                    // retry setting upper address
        //                    Core.Common.Utilities.LogMessage(
        //                        "DeviceDiscoveryWizard.SetQueryCriteria :: retrying using format:  '" +
        //                        upperAddress +
        //                        "'");
        //                    wizardIpAddressRange.Controls.EndTextBox.SendKeys(upperAddress);
        //                }

        //                // set community string
        //                Core.Common.Utilities.LogMessage("Setting community string to:  '" +
        //                    deviceName +
        //                    "_public" +
        //                    "'");
        //                wizardIpAddressRange.Controls.CommunityStringTextBox.SendKeys(
        //                    deviceName + "_public");

        //                wizardIpAddressRange.ClickDiscover();
        //            }
        //            else
        //            {
        //                throw new ArgumentOutOfRangeException(
        //                    "Failed to parse the IP address for the agent!  \nOctets:  " +
        //                    octets);
        //            }
        //        }
        //        else
        //        {
        //            throw new ArgumentOutOfRangeException(
        //                "Unable to get IP address for target device:  '" +
        //                deviceName + "'");
        //        }

        //        #endregion // Set Specified IP Address Range Options

        //        #endregion
        //        #region SetNetworkDevice ManagementServer
        //        //TODO:  Put code here to select Management server.  Currently not supported by this method
        //        #endregion  //set networkdevice management server
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Device type argument is invalid!\n\r" +
        //            "Value does not match any DeviceType enum value:  " + deviceType);
        //    }

        //    #endregion // Set Query Options

        //    #region Set Discovery Account Options

        //    Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting discovery account...");

        //    // flag to indicate if the discovery task was already run once in this wizard instance
        //    bool taskAlreadyCompleted = false;

        //    if (deviceType == DeviceType.WindowsComputer)
        //    {
        //        // find windows credentials window
        //        DeviceDiscovery.Wizards.WindowsCredentialsWindow windowsCredentials =
        //            new Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.WindowsCredentialsWindow(
        //                CoreManager.MomConsole);

        //        // check if we can use the server action account or not
        //        if (false == Utilities.UseOtherActionAccountType(null, null))
        //        {
        //            Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Using Management Server account...");

        //            // if windows computers, use management server account
        //            CoreManager.MomConsole.WaitForEnabledButton(windowsCredentials.Controls.ExistingUserAccountRadioButton, OneMinuteInSeconds);
        //            windowsCredentials.Controls.ExistingUserAccountRadioButton.Click();
        //        }
        //        else
        //        {
        //            Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Using domain admin account...");

        //            // use an admin account
        //            CoreManager.MomConsole.WaitForEnabledButton(windowsCredentials.Controls.OtherUserAccountRadioButton, OneMinuteInSeconds);
        //            windowsCredentials.Controls.OtherUserAccountRadioButton.Click();

        //            // get username/password from credential store
        //            string userAccount = Mom.Test.Infrastructure.PasswordManager.GetDomainAdminAccount();
        //            string password = Mom.Test.Infrastructure.PasswordManager.GetPassword(userAccount);

        //            Core.Common.Utilities.LogMessage(
        //                "DeviceDiscovery::DiscoverDevice::user account:  '" +
        //                userAccount +
        //                "', password:  '" +
        //                password +
        //                "'");

        //            // set account credentials
        //            windowsCredentials.Controls.UserNameTextBox.Text = userAccount;
        //            windowsCredentials.Controls.PasswordTextBox.Text = password;
        //        }

        //        // if the "Next button is enabled
        //        if (windowsCredentials.Controls.NextButton.IsEnabled == true)
        //        {
        //            // click "Next"
        //            windowsCredentials.ClickNext();

        //            // we've already run this task once, don't run it again
        //            taskAlreadyCompleted = true;
        //        }
        //        else
        //        {
        //            // click the "Discover" button
        //            if (windowsCredentials.Controls.FinishButton.IsEnabled == true)
        //            {
        //                // "Discover" button same as "Finish" button with different text
        //                windowsCredentials.ClickFinish();
        //            }
        //            else
        //            {
        //                throw new MauiException("Both 'Next' and 'Discover' buttons are disabled!");
        //            }
        //        }
        //    }
        //    else if (deviceType == DeviceType.NetworkDevice)
        //    {
        //        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Using SNMP community strings...");
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Device type argument is invalid!\n\r" +
        //            "Value does not match any DeviceType enum value:  " + deviceType);
        //    }

        //    #endregion // Set Discovery Account Options

        //    #region Wait for Discovery Task Completion

        //    Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Waiting for discovery task to complete...");

        //    // set wait loop parameters
        //    int timeWaited = 0;
        //    const int MaxTimeWaited = 900;

        //    // check to see if the task was already run once
        //    if (taskAlreadyCompleted != true)
        //    {
        //        // get the discovery task progess window
        //        DeviceDiscovery.Wizards.DiscoveryTaskProgressWindow taskProgress =
        //            new Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.DiscoveryTaskProgressWindow(
        //                CoreManager.MomConsole);

        //        // Wait for the discovery task to finish
        //        while (taskProgress.Controls.ProgressStaticControl.IsEnabled == true
        //            && taskProgress.Controls.ProgressStaticControl.Extended.IsVisible == true
        //            && timeWaited < MaxTimeWaited)
        //        {
        //            // wait two seconds and try again
        //            timeWaited = timeWaited + 2;
        //            Maui.Core.Utilities.Sleeper.Delay(2000);
        //        }

        //        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Waited " + timeWaited + " seconds for task to complete.");

        //        // click "Next"
        //        // taskProgress.ClickNext();
        //    }

        //    #endregion // Wait for Discovery Task Completion

        //    #region Select Device for Management

        //    Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Selecting device for management...");

        //    // find the discovery results window
        //    DeviceDiscovery.Wizards.DiscoveryResultsWindow discoveryResults =
        //        new Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.DiscoveryResultsWindow(
        //            CoreManager.MomConsole);
        //    UISynchronization.WaitForProcessReady(discoveryResults);

        //    // select the device in the discovered objects list view
        //    string selectedItemText = null;
        //    string matchItemText = null;
        //    bool foundRequestedDevice = false;

        //    // set the match text
        //    if (deviceType == DeviceType.WindowsComputer)
        //    {
        //        //Considering Topology of Disjoint Namespace, we used FQDN name of the
        //        //device for matchItem.
        //        matchItemText = deviceNameFqdn;
        //    }
        //    else if (deviceType == DeviceType.NetworkDevice)
        //    {
        //        matchItemText = deviceIpAddress;
        //    }

        //    // find the list view item that matches the device name
        //    foreach (Maui.Core.WinControls.ListViewItem deviceEntry
        //        in discoveryResults.Controls.SelectObjectsToManageListView.Items)
        //    {
        //        // get the text
        //        selectedItemText = deviceEntry.Text;

        //        Core.Common.Utilities.LogMessage(
        //            "DeviceDiscovery::DiscoverDevice::Current entry:  '" +
        //            selectedItemText +
        //            "', entry to match:  '" +
        //            matchItemText +
        //            "'");

        //        // exact match the text
        //        if (selectedItemText.Trim().Equals(matchItemText, StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Selecting entry, exact match...");

        //            // select the entry
        //            deviceEntry.Select();
        //            deviceEntry.Click();

        //            Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting check box...");

        //            // set the checkbox
        //            deviceEntry.Checked = true;

        //            foundRequestedDevice = true;
        //            break; //only match one selection
        //        }
        //    }

        //    // did we find the requested device?
        //    if (foundRequestedDevice == true)
        //    {
        //        Core.Common.Utilities.LogMessage(
        //            "DeviceDiscovery::DiscoverDevice::Found requested device:  '" +
        //            deviceName +
        //            "'");
        //    }
        //    else //if not, try using StartsWith rather than Equals
        //    {
        //        foreach (Maui.Core.WinControls.ListViewItem deviceEntry
        //            in discoveryResults.Controls.SelectObjectsToManageListView.Items)
        //        {
        //            // prefix match the text
        //            if (selectedItemText.Trim().StartsWith(matchItemText, StringComparison.InvariantCultureIgnoreCase))
        //            {
        //                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Selecting entry, prefix...");

        //                // select the entry
        //                deviceEntry.Select();
        //                deviceEntry.Click();

        //                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting check box...");

        //                // set the checkbox
        //                deviceEntry.Checked = true;

        //                foundRequestedDevice = true;
        //                break; //only match one selection
        //            }
        //        }
        //    }

        //    if (!foundRequestedDevice)
        //    {
        //        // take a screen shot
        //        Core.Common.Utilities.TakeScreenshot(
        //            "Failed to find device, '" +
        //            deviceName +
        //            "', in Discovered Objects list view!");

        //        // cancel the wizard
        //        discoveryResults.ClickCancel();

        //        throw new Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException(
        //            "Failed to find device, '" +
        //            deviceName +
        //            "', in Discovered Objects list view!");
        //    }

        //    #endregion // Select Device for Management

        //    #region Set Management Mode

        //    // check product sku for SCE
        //    if (ProductSku.Sku == ProductSkuLevel.Sce)
        //    {
        //        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Management mode not supported in SCE.");
        //    }
        //    else
        //    {
        //        // if windows computers, set the management mode
        //        if (deviceType == DeviceType.WindowsComputer)
        //        {
        //            // agent managed
        //            if (managementMode == ManagementMode.AgentManaged)
        //            {
        //                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting agent-managed mode...");

        //                discoveryResults.Controls.ManagementModeComboBox.SelectByText(
        //                    DeviceDiscovery.Wizards.DiscoveryResultsWindow.Strings.ComboBoxAgentManaged);
        //            }
        //            else if (managementMode == ManagementMode.ProxyManaged)
        //            {
        //                // agentless/proxy managed
        //                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting agentless-managed mode...");

        //                discoveryResults.Controls.ManagementModeComboBox.SelectByText(
        //                    DeviceDiscovery.Wizards.DiscoveryResultsWindow.Strings.ComboBoxAgentlessManaged);
        //            }
        //            else
        //            {
        //                throw new ArgumentException("Management mode is invalid!\n\r" +
        //                    "Management mode value:  " + managementMode);
        //            }
        //        }
        //        else if (deviceType == DeviceType.NetworkDevice)
        //        {
        //            // management mode is proxy-managed for network devices
        //        }
        //        else
        //        {
        //            throw new ArgumentException("Management mode is invalid for this device type!\n\r" +
        //                "Management mode:  " + managementMode + "\n\rDeviceType:  " + deviceType);
        //        }
        //    }

        //    // click "Next"
        //    CoreManager.MomConsole.WaitForEnabledButton(discoveryResults.Controls.NextButton, OneMinuteInSeconds);
        //    discoveryResults.ClickNext();

        //    #endregion // Set Management Mode

        //    #region Set Agent Installation Options

        //    DeviceDiscovery.Wizards.AgentInstallSummaryWindow installSummary =
        //        new Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.AgentInstallSummaryWindow(
        //            CoreManager.MomConsole);

        //    // if windows computers and management mode is agent-managed
        //    if (deviceType == DeviceType.WindowsComputer
        //        && managementMode == ManagementMode.AgentManaged)
        //    {
        //        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting agent install directory...");

        //        // Use default directory
        //        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Using default directory:  '");

        //        // check for SCE
        //        if (ProductSku.Sku == ProductSkuLevel.Sce)
        //        {
        //            // skip it
        //            Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Set agent action account not supported in SCE.");
        //        }
        //        else
        //        {
        //            Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting agent action account...");

        //            // Use default action account
        //            installSummary.Controls.LocalSystemRadioButton.Click();
        //        }
        //    }

        //    #endregion // Set Agent Installation Options

        //    #region Finish Discovery Wizard

        //    Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Finishing the wizard...");

        //    installSummary.ClickFinish();

        //    if (showTaskProgress == true)
        //    {
        //        // monitor agent install task progress
        //        if (deviceType == DeviceType.WindowsComputer &&
        //            managementMode == ManagementMode.AgentManaged)
        //        {
        //            // monitor task progress
        //            if (Utilities.MonitorTaskProgress(true) == false)
        //            {
        //                throw new Exception("Agent install failed!");
        //            }
        //        }
        //    }

        //    #endregion // Finish Discovery Wizard

        //    #region Verify Successful Discovery

        //    // flag used for verification
        //    bool foundRule = false;

        //    if (verifyDeviceAppears == true)
        //    {

        //        Core.Common.Utilities.LogMessage(
        //            "DeviceDiscovery::DiscoverDevice::Verifying discovery...");

        //        #region Navigate to View

        //        // navigate to corresponding view
        //        CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(
        //            NavigationPane.WunderBarButton.Administration);
        //        string treeNodeText = null;

        //        // if windows computer
        //        if (deviceType == DeviceType.WindowsComputer)
        //        {
        //            // check management mode
        //            if (managementMode == ManagementMode.AgentManaged)
        //            {
        //                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Looking for agent-managed computer...");

        //                treeNodeText = NavigationPane.Strings.AdminTreeViewAgentManagedComputers;
        //            }
        //            else
        //            {
        //                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Looking for agentless-managed computer...");

        //                treeNodeText = NavigationPane.Strings.AdminTreeViewAgentlessManagedComputers;
        //            }
        //        }
        //        else
        //        {
        //            // network devices
        //            Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Looking for network devices...");

        //            treeNodeText = NavigationPane.Strings.AdminTreeViewNetworkDevices;
        //        }

        //        CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeText).Select();
        //        CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeText).Click();

        //        #endregion Navigate to View

        //        #region Wait for Device

        //        string displayName = null;
        //        string searchColumn = null;

        //        if (deviceType == DeviceType.WindowsComputer)
        //        {
        //            displayName = deviceName;
        //            searchColumn = ViewPane.Strings.AdministrationGridViewColumnName;
        //        }
        //        else if (deviceType == DeviceType.NetworkDevice)
        //        {
        //            displayName = deviceIpAddress;
        //            searchColumn = ViewPane.Strings.AdministrationGridViewColumnIpAddress;
        //        }

        //        // wait for device to appear, max wait:  one minute
        //        timeWaited = 0;
        //        foundRule = false;

        //        while (foundRule == false && timeWaited < MaxTimeWaited)
        //        {
        //            // refresh the view
        //            CoreManager.MomConsole.ViewPane.Grid.Click();
        //            CoreManager.MomConsole.SendKeys(Core.Common.KeyboardCodes.F5);

        //            // look for the device in the grid
        //            if (CoreManager.MomConsole.ViewPane.Grid.FindData(displayName, searchColumn) != null)
        //            {
        //                foundRule = true;
        //            }
        //            else
        //            {
        //                // increment the seconds waited
        //                timeWaited = timeWaited + 2;

        //                // sleep for two seconds
        //                Maui.Core.Utilities.Sleeper.Delay(2000);
        //            }
        //        }

        //        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Waited " + timeWaited + " seconds for device to appear.");

        //        #endregion Wait for Device

        //        #region Report Success or Failure

        //        // verify device in view
        //        if (foundRule == true)
        //        {
        //            Core.Common.Utilities.LogMessage(
        //                "DeviceDiscovery::DiscoverDevice::Successfully discovered device:  " +
        //                deviceName);
        //        }
        //        else
        //        {
        //            throw new Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException(
        //                "Failed to find device, '" + deviceName + "', in view, '" +
        //                managementMode +
        //                "'\nWaited " +
        //                timeWaited +
        //                " seconds for device to appear.");
        //        }
        //        #endregion Report Success or Failure
        //    }
        //    else
        //    {
        //        Core.Common.Utilities.LogMessage(
        //            "DeviceDiscovery::DiscoverDevice::Skipping verification...");

        //        // assume device will appear eventually
        //        foundRule = true;
        //    }

        //    #endregion // Verify Successful Discovery

        //    return foundDevice;
        //}

        //#endregion // Private Static Methods


        #endregion

    }

    /// <summary>
    /// Network wizard parameters
    /// </summary>
    public class NetworkWizardParameters
    {
        #region Private Members

        private string cachedDiscoveryRuleName = null;
        private string cachedDiscoveryRuleDescription = null;
        private string cachedServerName = null;        
        private DeviceType cachedDeviceType = DeviceType.Router;
        private NodeType cachedNodeType = NodeType.nonseed;
        private String[] cachedDeviceName = null;
        private Options cachedDeleteOptions = Options.RightClickContextMenuOption;
        private DiscoveryMethodType cachedDiscoveryMethodType = DiscoveryMethodType.Manual;
        private DeviceAction[] cachedDeviceActionsStruct = null;
        private DiscoveryScopeType cachedDiscoveryScopeType = DiscoveryScopeType.All;
        private IncludeFilterAction[] cachedFilterActions = null;
        private ExcludeFilterAction[] cachedExcludeFilterActions = null;
        private AccountAction[] cachedDefaultAccountPageActions = null;
        private string cachedImportDeviceFile = null;
        #endregion

        #region Properties

        /// <summary>
        /// Display Name of Network Discovery Rule
        /// </summary>
        public string NetworkDiscoveryRuleName
        {
            get
            {
                return this.cachedDiscoveryRuleName;
            }

            set
            {
                this.cachedDiscoveryRuleName = value;
            }
        }

        /// <summary>
        /// Description for Network Discovery Rule
        /// </summary>
        public string NetworkDiscoveryRuleDescription
        {
            get
            {
                return this.cachedDiscoveryRuleDescription;
            }

            set
            {
                this.cachedDiscoveryRuleDescription = value;
            }
        }

        /// <summary>
        /// Management Server or Gateway server where the rule 
        /// is going to run. 
        /// </summary>
        public string RuleServerName
        {
            get
            {
                return this.cachedServerName;
            }

            set
            {
                this.cachedServerName = value;
            }
        }

        /// <summary>
        /// Discovery Method Type: manual or automatic.  
        /// </summary>
        public DiscoveryMethodType DiscoveryMethodType
        {
            get
            {
                return this.cachedDiscoveryMethodType;
            }

            set
            {
                this.cachedDiscoveryMethodType = value;
            }
        }

        /// <summary>
        /// Device actions in Devices page.
        /// </summary>
        public DeviceAction[] DevicesPageActions
        {
            get
            {
                return this.cachedDeviceActionsStruct;
            }

            set
            {
                this.cachedDeviceActionsStruct = value;
            }
        }

        /// <summary>
        /// specify disovery scope.
        /// </summary>
        public DiscoveryScopeType DiscoveryScopeType
        {
            get
            {
                return this.cachedDiscoveryScopeType;
            }

            set
            {
                this.cachedDiscoveryScopeType = value;
            }
        }

        /// <summary>
        /// FilterActions in Filter page.
        /// </summary>
        public IncludeFilterAction[] IncludeFilterPageActions
        {
            get
            {
                return this.cachedFilterActions;
            }

            set
            {
                this.cachedFilterActions = value;
            }
        }

        /// <summary>
        /// ExcludeFilterActions in Filter page.
        /// </summary>
        public ExcludeFilterAction[] ExcludeFilterPageActions
        {
            get
            {
                return this.cachedExcludeFilterActions;
            }

            set
            {
                this.cachedExcludeFilterActions = value;
            }
        }

        /// <summary>
        /// Actions in Default Account page.
        /// </summary>
        public AccountAction[] DefaultAccountPageActions
        {
            get
            {
                return this.cachedDefaultAccountPageActions;
            }

            set
            {
                this.cachedDefaultAccountPageActions = value;
            }
        }

        public string ImportDeviceFile
        {
            get { return cachedImportDeviceFile; }
            set { cachedImportDeviceFile = value; }
        }

        /// <summary>
        /// Device Name       
        /// </summary>
        public String[] DeviceName
        {
            get
            {
                return this.cachedDeviceName;
            }

            set
            {
                this.cachedDeviceName = value;
            }
        }

        /// <summary>
        /// Device Type       
        /// </summary>
        public DeviceType DeviceType
        {
            get
            {
                return this.cachedDeviceType;
            }

            set
            {
                this.cachedDeviceType = value;
            }
        }

        /// <summary>
        /// Node Type       
        /// </summary>
        public NodeType NodeType
        {
            get
            {
                return this.cachedNodeType;
            }

            set
            {
                this.cachedNodeType = value;
            }
        }

        /// <summary>
        /// Delete Option       
        /// </summary>
        public Options DeleteOption
        {
            get
            {
                return this.cachedDeleteOptions;
            }

            set
            {
                this.cachedDeleteOptions = value;
            }
        }
        #endregion
    }

    /// <summary>
    /// Class that represents a Device (and its accounts)
    /// </summary>
    /// <history>
    /// [dialac] 19APR10 Created
    /// </history>
    public class Device
    {
        #region Private Members
        private string cachedDeviceNameIP = null;
        private DeviceAccessMode cachedDeviceAccessMode = DeviceAccessMode.ICMPSNMP;
        private DeviceSNMPVersion cachedDeviceSNMPVersion = DeviceSNMPVersion.V1orV2;
        private int cachedDevicePortNumber = 161; //default value;
        private DeviceAcctSecureMode cachedDeviceAcctSecureMode = DeviceAcctSecureMode.MoreSecure;
        private AccountAction[] cachedAccountAction = null;
        #endregion

        #region Properties
        /// <summary>
        ///  Name or IP of Device
        /// </summary>
        public string DeviceNameIP
        {
            get
            {
                return this.cachedDeviceNameIP;
            }

            set
            {
                this.cachedDeviceNameIP = value;
            }
        }

        /// <summary>
        /// Device Access Mode: ICMP or SNMP
        /// </summary>
        public DeviceAccessMode DeviceAccessMode
        {
            get
            {
                return this.cachedDeviceAccessMode;
            }

            set
            {
                this.cachedDeviceAccessMode = value;
            }
        }

        /// <summary>
        /// SNMP Version of the Device: v1, v2 or V1 or V2
        /// </summary>
        public DeviceSNMPVersion DeviceSNMPVersion
        {
            get
            {
                return this.cachedDeviceSNMPVersion;
            }

            set
            {
                this.cachedDeviceSNMPVersion = value;
            }
        }

        /// <summary>
        /// Device Port Number. Default Value: 161
        /// </summary>
        public int DevicePortNumber
        {
            get
            {
                return this.cachedDevicePortNumber;
            }

            set
            {
                this.cachedDevicePortNumber = value;
            }
        }

        /// <summary>
        /// Community String for the account used by the Device
        /// </summary>
        public AccountAction[] AccountAction
        {
            get
            {
                return this.cachedAccountAction;
            }

            set
            {
                this.cachedAccountAction = value;
            }
        }

        /// <summary>
        /// DeviceAcctSecureMode: More secure, less secure
        /// </summary>
        public DeviceAcctSecureMode DeviceAccountSecureMode
        {
            get
            {
                return this.cachedDeviceAcctSecureMode;
            }

            set
            {
                this.cachedDeviceAcctSecureMode = value;
            }
        }

        #endregion
    }

    /// <summary>
    /// Defining my Struct to hold Action and Devices ID associated with the action
    /// </summary>
    public class DeviceAction : ActionBase
    {
        /// <summary>
        /// represents the devices associated with the action. 
        /// </summary>
        public Device[] devices = null;
    }

    /// <summary>
    /// Class that represents a Filter
    /// </summary>
    /// <history>
    /// [v-dayow] 3JUN10 Created
    /// </history>
    public class Filter
    {
        #region private members
        private string cachedIPAddressRange = "*";
        private DeviceType[] cachedFilterDeviceTypes = null;
        private string cachedName = "*";
        private string cachedOID = "*";
        private string cachedDescription = "*";
        private string cachedExcludeIPAddressRange = "";
        #endregion

        #region Properties
        public string IncludeIPAddressRange
        {
            get { return cachedIPAddressRange; }
            set { cachedIPAddressRange = value; }
        }

        public string ExcludeIPAddressRange
        {
            get { return cachedExcludeIPAddressRange; }
            set { cachedExcludeIPAddressRange = value; }
        }

        public DeviceType[] FilterDeviceTypes
        {
            get { return cachedFilterDeviceTypes; }
            set { cachedFilterDeviceTypes = value; }
        }

        public string Name
        {
            get { return cachedName; }
            set { cachedName = value; }
        }

        public string OID
        {
            get { return cachedOID; }
            set { cachedOID = value; }
        }

        public string Description
        {
            get { return cachedDescription; }
            set { cachedDescription = value; }
        }
        #endregion
    }

    public class FilterAction : ActionBase
    {
        private Filter cachedFilter = new Filter();
        public Filter Filter
        {
            get { return cachedFilter; }
            set { cachedFilter = value; }
        }
    }

    /// <summary>
    /// Class that represents a Filter action
    /// </summary>
    /// <history>
    /// [v-dayow] 3JUN10 Created
    /// </history>
    public class IncludeFilterAction : FilterAction
    {

        public void SettingAddFilterDialog(AddFilterDialog addFilterDialog)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...) select filter devices types");
            addFilterDialog.WaitForResponse();
            addFilterDialog.SpecifyAnIPAddressOrAPatternForARangeOfIPAddressesText = this.Filter.IncludeIPAddressRange;
            addFilterDialog.NameText = this.Filter.Name;
            addFilterDialog.ObjectIDOIDText = this.Filter.OID;
            addFilterDialog.DescriptionText = this.Filter.Description;
            if (this.Filter.FilterDeviceTypes != null)
            {
                addFilterDialog.ClickClearAll();
                addFilterDialog.Controls.NetworkDeviceTypesListview.WaitForResponse();
                foreach (DeviceType dev in this.Filter.FilterDeviceTypes)
                {
                    Utilities.LogMessage(currentMethod + ":: select devices type:" + Enum.GetName(typeof(DeviceType), dev));
                    string localDeviceTypeStr = typeof(AddFilterDialog.Strings).GetProperty(Enum.GetName(typeof(DeviceType), dev)).GetValue(null, null).ToString();
                    Utilities.LogMessage(currentMethod + ":: Got localized devices type name: " + localDeviceTypeStr);
                    //ListViewItem item = addFilterDialog.Controls.NetworkDeviceTypesListview.FindSingleItem(localDeviceTypeStr, true, true, false, 1);
                    ListViewItem item = null;
                    foreach (ListViewItem lvi in addFilterDialog.Controls.NetworkDeviceTypesListview.Items)
                    {
                        if (lvi.SubItems[0].Text == localDeviceTypeStr)
                        {
                            item = lvi;
                            break;
                        }
                    }

                    if (item == null)
                    {
                        throw new ListView.Exceptions.ItemNotFoundException("Failed to find item with string:" + localDeviceTypeStr);
                    }
                    else
                    {
                        Utilities.LogMessage(currentMethod + ":: Set listviewItem state as checked.");
                        item.Checked = true;
                    }
                }
            }
            Utilities.LogMessage(currentMethod + ":: Click OK.");
            addFilterDialog.ClickOK();
            Utilities.LogMessage(currentMethod + ":: Wait for dialog to go away.");
            CoreManager.MomConsole.WaitForDialogClose(addFilterDialog, 2);
        }

    }

    public class ExcludeFilterAction : FilterAction
    {

        public void SettingExcludeIPAddressRange(AddFilterDialog addFilterDialog)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "::(...) setting exclude Ip range.");
            addFilterDialog.WaitForResponse();
            Utilities.LogMessage(currentMethod + "::(...) setting exclude Ip range=" + this.Filter.ExcludeIPAddressRange);
            addFilterDialog.SpecifyAnIPAddressOrAPatternForARangeOfIPAddressesText = this.Filter.ExcludeIPAddressRange;
            Utilities.LogMessage(currentMethod + ":: wait for OK button enabled.");
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(addFilterDialog.Controls.OKButton, 2000);
            Utilities.LogMessage(currentMethod + ":: Click OK.");
            addFilterDialog.ClickOK();
        }
    }

    /// <summary>
    /// Class that represents a device account
    /// </summary>
    /// <history>
    /// [v-dayow] 3JUN10 Created
    /// </history>
    public class DeviceAccount
    {
        public DeviceSNMPVersion AccountType = DeviceSNMPVersion.V1orV2;
        public string Name = null;
        public string Description = null;
        public string CommunityString = null;
        public DeviceAcctSecureMode SecureMode = DeviceAcctSecureMode.MoreSecure;
        public string UserName = null;
        public string Context = null;
        public RunAsAccount.SNMPv3APType AuthenticationProtocal = RunAsAccount.SNMPv3APType.None;
        public RunAsAccount.SNMPv3PPType PrivacyProtocol = RunAsAccount.SNMPv3PPType.None;
        public string AuthenticationKey = null;
        public string PrivacyKey = null;
    }

    /// <summary>
    /// Class that represents a device account action
    /// </summary>
    /// <history>
    /// [v-dayow] 3JUN10 Created
    /// </history>
    public class AccountAction : ActionBase
    {
        private DeviceAccount cachedDeviceAccount = new DeviceAccount();
        public DeviceAccount account
        {
            get { return cachedDeviceAccount; }
            set { cachedDeviceAccount = value; }
        }
    }

    /// <summary>
    /// Base class for Actions
    /// </summary>
    public abstract class ActionBase
    {
        public ActionType actionType = ActionType.add;
    }
}