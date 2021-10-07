//-------------------------------------------------------------------
// <copyright file="Utilities.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains a class for exposing Device Discovery functionality.
// </summary>
// 
//  <history>
//  [KellyMor]  21SEP05 Created
//  [KellyMor]  21OCT05 Added overload to MonitorTaskProgress to 
//                      close the dialog when the task is complete.
//  [KellyMor]  16NOV05 Modified DiscoverDevice to support SCE
//  [KellyMor]  07DEC05 Modified DiscoverDevice to skip checkbox for
//                      'Show task progress' on SCE
//  [KellyMor]  07FEB06 Modified all methods for new discovery wizard
//  [KellyMor]  08FEB06 Added simpler overloads to DeleteDevice()
//  [KellyMor]  09FEB06 Fixed bug ID# 60992
//  [KellyMor]  10FEB06 Modified DiscoverDevice to skip welcome step
//  [KellyMor]  21FEB06 Increased max wait time on SCE to 15 minutes
//  [KellyMor]  22FEB06 Modified DiscoverDevice to use "Discover"
//                      button instead of "Next"
//                      Modified DiscoverDevice to skip "Running"
//                      step if current task has already run once
//  [KellyMor]  23FEB06 Added default context menu timeout to all
//                      context menu constructors
//  [KellyMor]  14MAR06 Modified DiscoverDevice methods to check for
//                      SCE and set showTaskProgress to false
//                      Increase MaxWaitTime to 15 minutes for SCE
//  [KellyMor]  15MAR06 Added an overload to DiscoverDevice that uses
//                      a flag to check if the device appears in UI
//  [KellyMor]  12APR06 Updated delete to handle network devices
//  [KellyMor]  26APR06 Modified delete to use FQDN column in grid
//  [KellyMor]  27APR06 Modified MonitorTaskProgess to add process
//                      synchronization to wait for task window ready
//                      Modified MonitorTaskProgress to wait for one
//                      minute and poll the task list for items until
//                      there are items to parse
//  [KellyMor]  22JUN06 Added private methods for configuring an
//                      agent to act as an SNMP device and determining
//                      if a MOM Server action account is set to
//                      'LocalSystem'
//  [KellyMor]  26JUN06 Modified DiscoverDevice to support network
//                      devices
//  [KellyMor]  30JUN06 Intial fixes for admin credential issues
//                      DiscoverDevice and UninstallAgent now use
//                      code to check for MOM Server as LocalSystem
//                      and use PasswordManager for account
//  [KellyMor]  03JUL06 Modified UseOtherActionAccountType to use the
//                      only MOM Server as the Root SDK Server in SCE
//                      Make sure topology is initialized
//  [KellyMor]  05JUL06 Modified UseOtherActionAccountType to use the
//                      correct topology property for MOM Servers
//  [KellyMor]  10JUL06 Modified UseOtherActionAccountType to use the
//                      new SDK properties on MonitorSecureData and
//                      not recast it as a
//                      MonitorWindowsCredentialSecureData object
//  [KellyMor]  26JUL06 Added method TurnOffViewGrouping to revert
//                      the grid view to a flat list
//                      Modified DeleteDevice to use 
//                      TurnOffViewGrouping
//  [KellyMor]  30AUG06 Added retry logic to context menu 'Uninstall'
//  [kellymor]  25SEP06 Remove check for SCE in DiscoverDevice, all
//                      SKU's use "Agent Management Task Status" for
//                      agent push installs now.
//  [KellyMor]  23OCT06 Added retry logic to the DeleteDevice method 
//                      for finding the device in the grid view.
//  [KellyMor]  27OCT06 Added logging in DiscoverDevice and Configure
//                      SnmpAgent to display device name used for
//                      for IP address resolution in DNS
//  [KellyMor]  06NOV06 Added synchronization around AD/LDAP dialog
//  [KellyMor]  12FEB07 Update DiscoverDevice to use core navigation
//                      methods for Administration treeview control
//  [kellymor]  16MAY07 Modified SetQueryCriteria to correctly set lower
//                      and upper bounds for IP addresses
//  [KellyMor]  07APR08 Modfied uninstall routines to use new 
//                      constructor for AgentUninstallWizardWindow
//  [KellyMor]  12MAY08 Modified TurnOffGrouping to use ViewPane
//                      context menu instead of tree view.
//  [KellyMor]  30MAY08 Modified ConfigureAgentSnmp to get IPv4
//                      addresses for device and server.
//  [KellyMor]  26JUN08 Modified DiscoverDevice to get IPv4
//                      addresses for network devices.
//  [KellyMor]  13OCT08 Modified DiscoverDevice to first try exact
//                      text matching for discovered devices in the
//                      list of results, BEFORE using prefix matching
//                      as a fall-back option.
//  [BillHodg]  06OCT09 Changed logging to use Common Logger. MCF Class 
//                      Now calls into Utilities to set the logger.
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.DeviceDiscovery
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Maui.GlobalExceptions;
    using Microsoft.EnterpriseManagement.Test.ScCommon.AgentMgmt;
    using Microsoft.EnterpriseManagement.Test.BaseCommon.WinSnmpControl;
    using Microsoft.EnterpriseManagement;
    using Microsoft.EnterpriseManagement.Administration;
    using Mom.Test.UI.Core.Common;
    
 


    #region Enums

    /// ------------------------------------------------------------------
    /// <summary>
    /// Device types used by DiscoverDevice method.
    /// </summary>
    /// ------------------------------------------------------------------
    public enum DeviceType : int
    {
        /// <summary>
        /// A Windows computer
        /// </summary>
        WindowsComputer,

        /// <summary>
        /// A network device, e.g. SNMP or IPMI
        /// </summary>
        NetworkDevice,
        /// <summary>
        /// A non Windows Computer 
        /// </summary>
        XplatComputer
    }

    /// ------------------------------------------------------------------
    /// <summary>
    /// Management mode for discovered devices 
    /// </summary>
    /// ------------------------------------------------------------------
    public enum ManagementMode : int
    {
        /// <summary>
        /// Agent-managed
        /// </summary>
        AgentManaged,

        /// <summary>
        /// Proxy-managed
        /// </summary>
        ProxyManaged
    }

    #endregion // Enums

    /// <summary>
    /// Utility class to hold device discovery methods
    /// </summary>
    public sealed class Utilities
    {
        #region Private Constants

        /// <summary>
        ///  one minute in seconds used by initialization methods
        /// </summary>
        private const int OneMinuteInSeconds = 60;

        #endregion

        #region Public Static Methods

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to discover a Windows computer and install an agent.
        /// </summary>
        /// <param name="deviceName">Name of the Windows computer</param>
        /// <returns>True if successful, otherwise false</returns>
        /// /// <exception cref="Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException">
        /// Throws ItemNotFoundException if it cannot find a discovered device or cannot 
        /// add a discovered device to the list of managed devices.
        /// </exception>
        /// <exception cref="Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException">
        /// Throws a NodeNotFoundException if it cannot find a tree view node.
        /// </exception>
        /// <exception cref="Maui.Core.Window.Exceptions.WindowNotFoundException">
        /// Throws a WindowNotFoundException if it cannot find a particular
        /// wizard window or dialog.
        /// </exception>
        /// <history>
        ///     [KellyMor]  21SEP05 Created  
        /// </history>
        /// ------------------------------------------------------------------
        public static bool DiscoverDevice(string deviceName)
        {
            return Utilities.DiscoverDevice(
                deviceName,
                System.Environment.UserDomainName,
                DeviceDiscovery.DeviceType.WindowsComputer,
                DeviceDiscovery.ManagementMode.AgentManaged);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to discover a Windows computer in the specified domain
        /// and install an agent.
        /// </summary>
        /// <param name="deviceName">Name of the Windows computer</param>
        /// <param name="domainName">Name of the AD domain</param>
        /// <returns>True if successful, otherwise false</returns>
        /// /// <exception cref="Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException">
        /// Throws ItemNotFoundException if it cannot find a discovered device or cannot 
        /// add a discovered device to the list of managed devices.
        /// </exception>
        /// <exception cref="Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException">
        /// Throws a NodeNotFoundException if it cannot find a tree view node.
        /// </exception>
        /// <exception cref="Maui.Core.Window.Exceptions.WindowNotFoundException">
        /// Throws a WindowNotFoundException if it cannot find a particular
        /// wizard window or dialog.
        /// </exception>
        /// <history>
        ///     [KellyMor]  21SEP05 Created  
        /// </history>
        /// ------------------------------------------------------------------
        public static bool DiscoverDevice(string deviceName, string domainName)
        {
            return Utilities.DiscoverDevice(
                deviceName,
                domainName,
                DeviceType.WindowsComputer,
                ManagementMode.AgentManaged);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to discover the named device and manage it.
        /// </summary>
        /// <param name="deviceName">Name of the Windows computer</param>
        /// <param name="domainName">Name of the AD domain</param>
        /// <param name="deviceType">Enumeration indicating the device type</param>
        /// <param name="managementMode">Enumeration indicating the management mode</param>
        /// <returns>True if successful, otherwise false</returns>
        /// <exception cref="System.ArgumentException">
        /// Throws a System.ArgumentException if unknown values are used for
        /// deviceType or managementMode.  Or if conflicting values are used,
        /// e.g. deviceType = DeviceType.NetworkDevice AND 
        /// managementMode = ManagementMode.AgentManaged.
        /// </exception>
        /// <exception cref="Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException">
        /// Throws ItemNotFoundException if it cannot find a discovered device or cannot 
        /// add a discovered device to the list of managed devices.
        /// </exception>
        /// <exception cref="Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException">
        /// Throws a NodeNotFoundException if it cannot find a tree view node.
        /// </exception>
        /// <exception cref="Maui.Core.Window.Exceptions.WindowNotFoundException">
        /// Throws a WindowNotFoundException if it cannot find a particular
        /// wizard window or dialog.
        /// </exception>
        /// <history>
        ///     [KellyMor]  21SEP05 Created  
        /// </history>
        /// ------------------------------------------------------------------
        public static bool DiscoverDevice(
            string deviceName,
            string domainName,
            DeviceDiscovery.DeviceType deviceType,
            DeviceDiscovery.ManagementMode managementMode)
        {
            
            return Utilities.DiscoverDevice(
                deviceName,
                domainName,
                deviceType,
                managementMode,
                true);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to discover the named device and manage it.
        /// </summary>
        /// <param name="deviceName">Name of the Windows computer</param>
        /// <param name="domainName">Name of the AD domain</param>
        /// <param name="deviceType">Enumeration indicating the device type</param>
        /// <param name="managementMode">Enumeration indicating the management mode</param>
        /// <param name="showTaskProgress">Flag to indicate whether to show task status dialog</param>
        /// <returns>True if successful, otherwise false</returns>
        /// <exception cref="System.ArgumentException">
        /// Throws a System.ArgumentException if unknown values are used for
        /// deviceType or managementMode.  Or if conflicting values are used,
        /// e.g. deviceType = DeviceType.NetworkDevice AND 
        /// managementMode = ManagementMode.AgentManaged.
        /// </exception>
        /// <exception cref="Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException">
        /// Throws ItemNotFoundException if it cannot find a discovered device or cannot 
        /// add a discovered device to the list of managed devices.
        /// </exception>
        /// <exception cref="Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException">
        /// Throws a NodeNotFoundException if it cannot find a tree view node.
        /// </exception>
        /// <exception cref="Maui.Core.Window.Exceptions.WindowNotFoundException">
        /// Throws a WindowNotFoundException if it cannot find a particular
        /// wizard window or dialog.
        /// </exception>
        /// <history>
        ///     [KellyMor]  21SEP05 Created
        ///     [KellyMor]  16NOV05 Modified DiscoverDevice to support SCE
        ///     [KellyMor]  07DEC05 Modified DiscoverDevice to skip checkbox for
        ///                         'Show task progress' on SCE
        ///     [KellyMor]  07FEB06 Modified to use new discovery wizard UI
        ///     [KellyMor]  09FEB06 Added delay to fix bug ID# 60992
        /// </history>
        /// ------------------------------------------------------------------
        public static bool DiscoverDevice(
            string deviceName,
            string domainName,
            DeviceDiscovery.DeviceType deviceType,
            DeviceDiscovery.ManagementMode managementMode,
            bool showTaskProgress)
        {
            bool verifyDeviceAppears = false;
            if (ProductSku.Sku == ProductSkuLevel.Mom)
            {
                verifyDeviceAppears = true;
            }

            return Utilities.DiscoverDevice(
                deviceName,
                domainName,
                deviceType,
                managementMode,
                showTaskProgress,
                verifyDeviceAppears);
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to discover the named device and manage it.
        /// </summary>
        /// <param name="deviceName">Name of the Windows computer</param>
        /// <param name="domainName">Name of the AD domain</param>
        /// <param name="deviceType">Enumeration indicating the device type</param>
        /// <param name="managementMode">Enumeration indicating the management mode</param>
        /// <param name="showTaskProgress">Flag to indicate whether to show task status dialog</param>
        /// <param name="verifyDeviceAppears">Flag to indicate whether to verify device appears in the UI</param>
        /// <returns>True if successful, otherwise false</returns>
        /// <exception cref="System.ArgumentException">
        /// Throws a System.ArgumentException if unknown values are used for
        /// deviceType or managementMode.  Or if conflicting values are used,
        /// e.g. deviceType = DeviceType.NetworkDevice AND 
        /// managementMode = ManagementMode.AgentManaged.
        /// </exception>
        /// <exception cref="Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException">
        /// Throws ItemNotFoundException if it cannot find a discovered device or cannot 
        /// add a discovered device to the list of managed devices.
        /// </exception>
        /// <exception cref="Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException">
        /// Throws a NodeNotFoundException if it cannot find a tree view node.
        /// </exception>
        /// <exception cref="Maui.Core.Window.Exceptions.WindowNotFoundException">
        /// Throws a WindowNotFoundException if it cannot find a particular
        /// wizard window or dialog.
        /// </exception>
        /// <history>
        ///     [KellyMor]  21SEP05 Created
        ///     [KellyMor]  16NOV05 Modified DiscoverDevice to support SCE
        ///     [KellyMor]  07DEC05 Modified DiscoverDevice to skip checkbox for
        ///                         'Show task progress' on SCE
        ///     [KellyMor]  07FEB06 Modified to use new discovery wizard UI
        ///     [KellyMor]  09FEB06 Added delay to fix bug ID# 60992
        ///      [jnwoko]  06OCT08  Modified code to work with Xplat Improvement ID#112171
        ///      [a-joelj]  22DEC09 Now using the localized resource string for "Error" dialog 
        ///                         if IP range issue occurs to fix SM bug# 162962 
        /// </history>
        /// ------------------------------------------------------------------
        public static bool DiscoverDevice(
            string deviceName,
            string domainName,
            DeviceDiscovery.DeviceType deviceType,
            DeviceDiscovery.ManagementMode managementMode,
            bool showTaskProgress,
            bool verifyDeviceAppears)
        {
            string deviceIpAddress = null;
            string deviceNameFqdn = null;
            int waitTime = 1000;
            deviceNameFqdn = Core.Common.Utilities.GetServerNameFqdn(deviceName);
            Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::parameters");
            Core.Common.Utilities.LogMessage("deviceName:  '" + deviceName + "'");
            Core.Common.Utilities.LogMessage("deviceNameFqdn: " + deviceNameFqdn + "");
            Core.Common.Utilities.LogMessage("domainName:  '" + domainName + "'");
            Core.Common.Utilities.LogMessage("deviceType:  '" + deviceType + "'");
            Core.Common.Utilities.LogMessage("managementMode:  '" + managementMode + "'");


            #region Navigate and Start Wizard

            Core.Common.Utilities.LogMessage(
                "DeviceDiscovery::DiscoverDevice::Navigating to Administration view...");

            // navigate to the administration view
            CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(
                NavigationPane.WunderBarButton.Administration);

            Core.Common.Utilities.LogMessage(
                "DeviceDiscovery::DiscoverDevice::Selecting 'Device Management' node...");

            // use core navigation method to find the view
            Maui.Core.WinControls.TreeNode deviceManagement =
                CoreManager.MomConsole.NavigationPane.SelectNode(
                    NavigationPane.Strings.AdminTreeViewAdministrationRoot +
                    "\\" +
                    NavigationPane.Strings.AdminTreeViewDeviceManagement,
                    NavigationPane.NavigationTreeView.Administration);

            Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Starting discovery wizard...");

            // start the wizard from the context menu
            CoreManager.MomConsole.ExecuteContextMenu(NavigationPane.Strings.ContextMenuDiscoveryWizard, true);
            #endregion

            #region Find and verify Wizard Page
            // find the discovery wizard welcome window
            DeviceDiscovery.Wizards.ComputerAndDeviceType discoveryWizard =
                new Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.ComputerAndDeviceType(
                    CoreManager.MomConsole);
            Core.Common.Utilities.LogMessage(
                "discoveryWizard::Found discovery wizard window...");
            #endregion // Navigate and Start Wizard

            #region Select Device Type to be discovered
             
            /*Perform action to select if network devices or windows computers here
             *Click Next */
            // select the corresponding device types.  
            switch (deviceType)
            {
                case DeviceType.WindowsComputer:
                    {
                        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting Windows computer types.");
                        //discoveryWizard.Controls.WindowsComputersStaticControl.SendKeys("%{w}");
                        discoveryWizard.Controls.WindowsComputersStaticControl.Click();
                    }
                    break;
                case DeviceType.NetworkDevice:
                    {
                        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Selecting etwork Device types.");
                        //discoveryWizard.Controls.NetworkDevicesStaticControl.SendKeys("%{v}");
                        discoveryWizard.Controls.NetworkDevicesStaticControl.Click();
                    }
                    break;
                default:
                    {
                        throw new ArgumentException("DeviceDiscovery::DiscoverDevice::Unknown device type:  '" + deviceType + "'");
                    }
            }
            //waiting 1 second
            Sleeper.Delay(waitTime);
            Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Clicking 'Next' button...");
            // move past the "First" screen, i.e. click "Next"
            discoveryWizard.ClickNext();
            #endregion

            #region Set Discovery Method
            /* If selection is Windows Computer: Select Discover Method and Click next 
             * Else If- Network Devices Do nothing
             * */
            Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting discovery method...");
            // set the device type options  
            if (deviceType == DeviceType.WindowsComputer)
            {
                // find the discovery method window
                DeviceDiscovery.Wizards.DiscoveryMethodWindow discoveryMethod =
                    new Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.DiscoveryMethodWindow(
                        CoreManager.MomConsole);

                // set the discovery method to "Advanced"
                discoveryMethod.Controls.AdvancedDiscoveryRadioButton.Click();


                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting Windows computers...");

                // Select Servers & Clients by default
                discoveryMethod.Controls.ComputerDeviceTypesComboBox.SelectByText(
                    Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.DiscoveryMethodWindow.Strings.ServersAndClients);

                // click "Next"
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(discoveryMethod.Controls.NextButton, Constants.OneMinute);
                Sleeper.Delay(waitTime);    //UI need wait one second to respond 
                discoveryMethod.ClickNext();
            }
            else if (deviceType == DeviceType.NetworkDevice)
            {
                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::This step is not applicable to Network devices...");
            }
            else
            {
                throw new ArgumentException("Device type argument is invalid!\n\r" +
                    "Value does not match any DeviceType enum value:  " + deviceType);
            }

            #endregion // Set Discovery Method

            #region Set Management Server or Proxy Agent

            Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting Management Server / Proxy Agent...");

            // if there's more than one management server, 
            if (deviceType == DeviceType.WindowsComputer)
            {
                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting Management Server...");

                // TODO: Add support for multiple management servers - BETA 2
                // set it
                // click "Next"
            }
            else if (deviceType == DeviceType.NetworkDevice)
            {
                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting Proxy Agent...");

                // TODO: Add support for proxy agents - BETA 2
                // if network device, set proxy agent
                // click "Next"
            }
            else
            {
                throw new ArgumentException("Device type argument is invalid!\n\r" +
                    "Value does not match any DeviceType enum value:  " + deviceType);
            }

            #endregion // Set Management Server or Proxy Agent

            #region Set Query Options

            Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting query options...");

            // find the query type window
            DeviceDiscovery.Wizards.QueryCriteriaWindow queryCriteria =
                new Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.QueryCriteriaWindow(
                CoreManager.MomConsole);

            // allow this step some time to render
            UISynchronization.WaitForUIObjectReady(queryCriteria);
            Sleeper.Delay(500);

            // set the query type according to device type
            if (deviceType == DeviceType.WindowsComputer)
            {
                #region Scan AD Query

                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting LDAP query...");

                // set query type to Search AD/LDAP
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(queryCriteria.Controls.ScanActiveDirectoryRadioButton, Constants.OneMinute);
                queryCriteria.Controls.ScanActiveDirectoryRadioButton.Click();

                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Starting Query Builder/Find Computers dialog...");

                // start the "Find Computers" dialog
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(queryCriteria.Controls.ConfigureButton, Constants.OneMinute);                
                queryCriteria.ClickConfigure();

                // find the "Find Computers" dialog
                Dialogs.FindComputersDialog findComputers =
                    new Mom.Test.UI.Core.Console.Dialogs.FindComputersDialog(
                    CoreManager.MomConsole);
                UISynchronization.WaitForUIObjectReady(
                    findComputers,
                    UI.Core.Common.Constants.DefaultDialogTimeout);

                // wait for the text box to become enabled
                int MaxAttempts = 15;
                for (int attempts = 1; ((MaxAttempts >= attempts) && (false == findComputers.Controls.ComputerNameTextBox.IsEnabled)); attempts++)
                {
                    Core.Common.Utilities.LogMessage(
                        "DeviceDiscovery::DiscoverDevice::Waiting for text box ready, attempt " +
                        attempts +
                        " of " +
                        MaxAttempts);
                    Maui.Core.Utilities.Sleeper.Delay(3000);
                }

                // check to see if the text box is finally ready.
                if (true == findComputers.Controls.ComputerNameTextBox.IsEnabled)
                {
                    // add the device name
                    findComputers.ComputerNameText = deviceName;
                    findComputers.ClickOK();
                }
                else
                {
                    throw new TimedOutException("Find Computers::Computer Name text box failed to become enabled!");
                }

                // set the domain name
                if (queryCriteria.Controls.DomainEditComboBox.EnumerateItems.Contains(
                    domainName.ToUpperInvariant()))
                {
                    queryCriteria.Controls.DomainEditComboBox.SelectByText(
                        domainName.ToUpperInvariant());
                }
                else
                {
                    // enter the domain name as text
                    queryCriteria.Controls.DomainEditComboBox.Text =
                        domainName.ToUpperInvariant();
                }
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(queryCriteria.Controls.NextButton, Constants.OneMinute);
                if (queryCriteria.Controls.NextButton.IsEnabled == true)
                {
                    // click "Next"
                    queryCriteria.ClickNext();
                }
                else
                {
                    //The Find Computers dialog sometimes takes longer to go away resulting in a timing issue 
                    //where call to the Next button fails so waiting for 5 secs before clicking next

                    Core.Common.Utilities.LogMessage(
                        "DeviceDiscovery::DiscoverDevice::Waiting for Find Computers dialog to close");
                    Sleeper.Delay(waitTime * 5);
                    // click "Next"
                    queryCriteria.ClickNext();
                }

                #endregion
            }
            else if (deviceType == DeviceType.NetworkDevice)
            {
                #region Scan IP Address Range

                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting Specific IP address range...");

                // configure the agent for SNMP
                Utilities.ConfigureAgentSnmp(
                    deviceName,
                    Core.Common.Topology.RootMomSdkServerName,
                    deviceName + "_public");

                // set the IP address of the target device
                Core.Common.Utilities.LogMessage(
                    "DeviceDiscovery::DiscoverDevice::Getting MOM device IP address for:  '" +
                    deviceNameFqdn +
                    "'");

                #region MOM Device IPv4 Address

                // get the IP address of the target device
                Core.Common.Utilities.LogMessage(
                    "DeviceDiscovery::DiscoverDevice::Getting MOM device IP addresses...");

                // get the list of IP addresses assigned to the device
                System.Net.IPAddress[] momDeviceIpAddresses =
                    System.Net.Dns.GetHostEntry(deviceName).AddressList;

                // check for a list of valid, IP addresses
                if (null != momDeviceIpAddresses && 0 < momDeviceIpAddresses.Length)
                {
                    // loop through the available addresses for IPv4 addresses only
                    foreach (System.Net.IPAddress address in momDeviceIpAddresses)
                    {
                        // look for an IPv4 address
                        if (System.Net.Sockets.AddressFamily.InterNetwork == address.AddressFamily)
                        {
                            // save this address
                            deviceIpAddress = address.ToString();

                            Core.Common.Utilities.LogMessage(
                                "DeviceDiscovery::DiscoverDevice::MOM Device IPv4:  " +
                                deviceIpAddress);

                            // exit the loop
                            break;
                        }
                    }
                }
                else
                {
                    throw new System.ArgumentOutOfRangeException(
                        "No IP addresses available for the current MOM device := '" +
                        deviceName +
                        "'");
                }

                #endregion MOM Device IPv4 Address

                #region Set Specified IP Address Range Options

                // make sure we have an IP address
                if (null != deviceIpAddress &&
                    deviceIpAddress.Length > 0)
                {
                    // get the IP address range wizard window
                    DeviceDiscovery.Wizards.IpAddressRangeWindow wizardIpAddressRange =
                        new DeviceDiscovery.Wizards.IpAddressRangeWindow(CoreManager.MomConsole);

                    // Split address by "." and create range for scan
                    string[] octets = deviceIpAddress.Split('.');
                    if (0 < octets.Length)
                    {
                        #region Build Upper and Lower IP Addresses

                        // get the last octet
                        int lastOctet = Int16.Parse(octets[(octets.Length - 1)]);

                        // create a new lower address
                        StringBuilder addressBuilder = new StringBuilder();

                        // lower the last octect by one
                        lastOctet--;

                        // check for valid octect low boundary
                        if (lastOctet <= 0)
                        {
                            lastOctet = 0;
                        }

                        // create the string version of the new IP
                        addressBuilder.Append(octets[0]);
                        addressBuilder.Append(".");
                        addressBuilder.Append(octets[1]);
                        addressBuilder.Append(".");
                        addressBuilder.Append(octets[2]);
                        addressBuilder.Append(".");
                        addressBuilder.Append(lastOctet.ToString());
                        string lowerAddress = addressBuilder.ToString().Trim();

                        // create an upper address
                        lastOctet += 2;

                        // check for valid octect upper boundary
                        if (lastOctet > 255)
                        {
                            // reset to highest valid value
                            lastOctet = 255;
                        }

                        // create the string version of the new IP
                        addressBuilder = new StringBuilder();
                        addressBuilder.Append(octets[0]);
                        addressBuilder.Append(".");
                        addressBuilder.Append(octets[1]);
                        addressBuilder.Append(".");
                        addressBuilder.Append(octets[2]);
                        addressBuilder.Append(".");
                        addressBuilder.Append(lastOctet.ToString());
                        string upperAddress = addressBuilder.ToString().Trim();

                        #endregion

                        try
                        {
                            //[v-liqluo] Add retry logic to set IP address,
                            //because the SendKeys.SendWait() doesn't always work correctly.
                            Button discoveryButton = new Button(
                                wizardIpAddressRange.Controls.DiscoverButton);
                            int maxTries = 5;
                            int retryCount = 1;
                            
                            while (discoveryButton != null && !discoveryButton.IsEnabled && retryCount <= maxTries)
                            {
                                //Clear the two IP addresses first
                                wizardIpAddressRange.Controls.StartTextBox.Text = string.Empty;
                                wizardIpAddressRange.Controls.EndTextBox.Text = string.Empty;

                                // set lower address
                                Core.Common.Utilities.LogMessage(
                                    "DeviceDiscovery::DiscoverDevice::Setting lower IP address to:  '" +
                                    lowerAddress +
                                    "', attempt " + retryCount + " of " + maxTries);

                                // wizardIpAddressRange.Controls.StartTextBox.SendKeys(lowerAddress);
                                //
                                // [nathd] - Updating because SendKeys no longer worked after upgrading 
                                // to Maui 2.0. According to MBickle this change is necessary as the
                                // IP Address TextBox doesn't accept Unicode... need to follow-up and 
                                // confirm.
                                wizardIpAddressRange.Controls.StartTextBox.Click();
                                System.Windows.Forms.SendKeys.SendWait(lowerAddress);

                                // set upper address
                                Core.Common.Utilities.LogMessage(
                                    "DeviceDiscovery::DiscoverDevice::Setting upper IP address to:  '" +
                                    upperAddress +
                                    "', attempt " + retryCount + " of " + maxTries);

                                // wizardIpAddressRange.Controls.EndTextBox.SendKeys(upperAddress);
                                //
                                // [nathd] - Updating because SendKeys no longer worked after upgrading 
                                // to Maui 2.0. According to MBickle this change is necessary as the
                                // IP Address TextBox doesn't accept Unicode... need to follow-up and 
                                // confirm.
                                wizardIpAddressRange.Controls.EndTextBox.Click();
                                System.Windows.Forms.SendKeys.SendWait(upperAddress);

                                //sleep one second to wait Discovery Button become enabled
                                Sleeper.Delay(1000);
                                retryCount++;
                            }

                            //Check if IP addresses are set correctly finally
                            if (retryCount > maxTries && discoveryButton!=null && !discoveryButton.IsEnabled)
                            {
                                throw new Maui.Core.WinControls.Button.Exceptions.CheckFailedException(
                                    "Discovery Button is still disable after max retry of Setting IP address" +
                                    " through SendKeys.SendWait().");
                            }
                        }
                        catch (Maui.Core.Window.Exceptions.UnknownActiveWinException)
                        {
                            Core.Common.Utilities.LogMessage(
                                "DeviceDiscoveryWizard.SetQueryCriteria :: Error setting IP addresses; " +
                                "clearing dialog and retrying");

                            //dismiss Error dialog
                            Core.Common.Utilities.LogMessage("DeviceDiscoveryWizard.SetQueryCriteria :: Clearing Error dialog " +
                                "and substituting spaces for periods in IP addresses");
                            CoreManager.MomConsole.ConfirmChoiceDialog(
                                Core.Console.MomConsoleApp.ButtonCaption.OK,
                                Core.Console.DeviceDiscovery.Wizards.IpAddressRangeWindow.Strings.Error,
                                Maui.Core.Utilities.StringMatchSyntax.ExactMatch,
                                Core.Console.MomConsoleApp.ActionIfWindowNotFound.Ignore);
                            wizardIpAddressRange.Extended.SetFocus();
                            Core.Common.Utilities.LogMessage("DeviceDiscoveryWizard.SetQueryCriteria :: Error dialog cleared");

                            //This solution (3 backspaces) assumes that the 2nd octet had the problem
                            //which has always been the case so far (10.194.196.225 becomes 101.941. where
                            //941 > 255 so the dialog throws an error and blocks further entry
                            //if this were ever not the case, this hard-coded approach would not work
                            wizardIpAddressRange.Controls.StartTextBox.SendKeys(UI.Core.Common.KeyboardCodes.Backspace +
                                UI.Core.Common.KeyboardCodes.Backspace + UI.Core.Common.KeyboardCodes.Backspace);

                            //and retry setting lower address
                            lowerAddress = lowerAddress.Replace(".", " ");

                            // retry setting lower address
                            Core.Common.Utilities.LogMessage(
                                "DeviceDiscoveryWizard.SetQueryCriteria :: retrying using format:  '" +
                                        lowerAddress +
                                        "'");
                            wizardIpAddressRange.Controls.StartTextBox.SendKeys(lowerAddress);

                            upperAddress = upperAddress.Replace(".", " ");

                            // retry setting upper address
                            Core.Common.Utilities.LogMessage(
                                "DeviceDiscoveryWizard.SetQueryCriteria :: retrying using format:  '" +
                                upperAddress +
                                "'");
                            wizardIpAddressRange.Controls.EndTextBox.SendKeys(upperAddress);
                        }

                        // set community string
                        Core.Common.Utilities.LogMessage("Setting community string to:  '" +
                            deviceName +
                            "_public" +
                            "'");
                        wizardIpAddressRange.Controls.CommunityStringTextBox.SendKeys(
                            deviceName + "_public");

                        wizardIpAddressRange.ClickDiscover();
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(
                            "Failed to parse the IP address for the agent!  \nOctets:  " +
                            octets);
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        "Unable to get IP address for target device:  '" +
                        deviceName + "'");
                }

                #endregion // Set Specified IP Address Range Options

                #endregion
                #region SetNetworkDevice ManagementServer
                //TODO:  Put code here to select Management server.  Currently not supported by this method
                #endregion  //set networkdevice management server
            }
            else
            {
                throw new ArgumentException("Device type argument is invalid!\n\r" +
                    "Value does not match any DeviceType enum value:  " + deviceType);
            }

            #endregion // Set Query Options

            #region Set Discovery Account Options

            Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting discovery account...");

            // flag to indicate if the discovery task was already run once in this wizard instance
            bool taskAlreadyCompleted = false;

            if (deviceType == DeviceType.WindowsComputer)
            {
                // find windows credentials window
                DeviceDiscovery.Wizards.WindowsCredentialsWindow windowsCredentials =
                    new Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.WindowsCredentialsWindow(
                        CoreManager.MomConsole);

                // check if we can use the server action account or not
                if (false == Utilities.UseOtherActionAccountType(null, null))
                {
                    Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Using Management Server account...");

                    // if windows computers, use management server account
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(windowsCredentials.Controls.ExistingUserAccountRadioButton, Constants.OneMinute);
                    windowsCredentials.Controls.ExistingUserAccountRadioButton.Click();
                }
                else
                {
                    Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Using domain admin account...");

                    // use an admin account
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(windowsCredentials.Controls.OtherUserAccountRadioButton, Constants.OneMinute);
                    windowsCredentials.Controls.OtherUserAccountRadioButton.Click();

                    // get username/password from credential store
                    string userAccount = Mom.Test.Infrastructure.PasswordManager.GetDomainAdminAccount();
                    string password = Mom.Test.Infrastructure.PasswordManager.GetPassword(userAccount);

                    Core.Common.Utilities.LogMessage(
                        "DeviceDiscovery::DiscoverDevice::user account:  '" +
                        userAccount +
                        "', password:  '" +
                        password +
                        "'");

                    // set account credentials
                    windowsCredentials.Controls.UserNameTextBox.Text = userAccount;
                    windowsCredentials.Controls.PasswordTextBox.Text = password;
                }

                // if the "Next button is enabled
                if (windowsCredentials.Controls.NextButton.IsEnabled == true)
                {
                    // click "Next"
                    windowsCredentials.ClickNext();

                    // we've already run this task once, don't run it again
                    taskAlreadyCompleted = true;
                }
                else
                {
                    // click the "Discover" button
                    if (windowsCredentials.Controls.FinishButton.IsEnabled == true)
                    {
                        // "Discover" button same as "Finish" button with different text
                        windowsCredentials.ClickFinish();
                    }
                    else
                    {
                        throw new MauiException("Both 'Next' and 'Discover' buttons are disabled!");
                    }
                }
            }
            else if (deviceType == DeviceType.NetworkDevice)
            {
                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Using SNMP community strings...");
            }
            else
            {
                throw new ArgumentException("Device type argument is invalid!\n\r" +
                    "Value does not match any DeviceType enum value:  " + deviceType);
            }

            #endregion // Set Discovery Account Options

            #region Wait for Discovery Task Completion

            Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Waiting for discovery task to complete...");

            // set wait loop parameters
            int timeWaited = 0;
            const int MaxTimeWaited = 900;

            // check to see if the task was already run once
            if (taskAlreadyCompleted != true)
            {
                // get the discovery task progess window
                DeviceDiscovery.Wizards.DiscoveryTaskProgressWindow taskProgress =
                    new Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.DiscoveryTaskProgressWindow(
                        CoreManager.MomConsole);

                // Wait for the discovery task to finish
                while (taskProgress.Controls.ProgressStaticControl.IsEnabled == true
                    && taskProgress.Controls.ProgressStaticControl.Extended.IsVisible == true
                    && timeWaited < MaxTimeWaited)
                {
                    // wait two seconds and try again
                    timeWaited = timeWaited + 2;
                    Maui.Core.Utilities.Sleeper.Delay(2000);
                }

                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Waited " + timeWaited + " seconds for task to complete.");

                // click "Next"
                // taskProgress.ClickNext();
            }

            #endregion // Wait for Discovery Task Completion

            #region Select Device for Management

            Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Selecting device for management...");

            // find the discovery results window
            DeviceDiscovery.Wizards.DiscoveryResultsWindow discoveryResults =
                new Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.DiscoveryResultsWindow(
                    CoreManager.MomConsole);
            UISynchronization.WaitForProcessReady(discoveryResults);

            // workaround for a timing issue that the automation fails to read items before listview is fully loaded
            int loop = 0;
            int max = 5;
            while (discoveryResults.Controls.SelectObjectsToManageListView.Items.Count <= 0 && loop < max)
            {
                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice:: Items in listview are not fully loaded yet, wait 1 second... ");
                Sleeper.Delay(Core.Common.Constants.OneSecond);
                loop++;
            }

            // select the device in the discovered objects list view
            string selectedItemText = null;
            string matchItemText = null;
            bool foundRequestedDevice = false;

            // set the match text
            if (deviceType == DeviceType.WindowsComputer)
            {
                //Considering Topology of Disjoint Namespace, we used FQDN name of the
                //device for matchItem.
                matchItemText = deviceNameFqdn;
            }
            else if (deviceType == DeviceType.NetworkDevice)
            {
                matchItemText = deviceIpAddress;
            }

            // find the list view item that matches the device name
            foreach (Maui.Core.WinControls.ListViewItem deviceEntry
                in discoveryResults.Controls.SelectObjectsToManageListView.Items)
            {
                // get the text
                selectedItemText = deviceEntry.Text;

                Core.Common.Utilities.LogMessage(
                    "DeviceDiscovery::DiscoverDevice::Current entry:  '" +
                    selectedItemText +
                    "', entry to match:  '" +
                    matchItemText +
                    "'");

                // exact match the text
                if (selectedItemText.Trim().Equals(matchItemText, StringComparison.InvariantCultureIgnoreCase))
                {
                    Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Selecting entry, exact match...");

                    // select the entry
                    deviceEntry.Select();
                    deviceEntry.Click();

                    Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting check box...");

                    // set the checkbox
                    deviceEntry.Checked = true;

                    foundRequestedDevice = true;
                    break; //only match one selection
                }
            }

            // did we find the requested device?
            if (foundRequestedDevice == true)
            {
                Core.Common.Utilities.LogMessage(
                    "DeviceDiscovery::DiscoverDevice::Found requested device:  '" +
                    deviceName +
                    "'");
            }
            else //if not, try using StartsWith rather than Equals
            {
                foreach (Maui.Core.WinControls.ListViewItem deviceEntry
                    in discoveryResults.Controls.SelectObjectsToManageListView.Items)
                {
                    // prefix match the text
                    if (selectedItemText.Trim().StartsWith(matchItemText, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Selecting entry, prefix...");

                        // select the entry
                        deviceEntry.Select();
                        deviceEntry.Click();

                        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting check box...");

                        // set the checkbox
                        deviceEntry.Checked = true;

                        foundRequestedDevice = true;
                        break; //only match one selection
                    }
                }
            }
            
            if (!foundRequestedDevice)
            {
                // take a screen shot
                Core.Common.Utilities.TakeScreenshot(
                    "Failed to find device, '" +
                    deviceName +
                    "', in Discovered Objects list view!");

                // cancel the wizard
                discoveryResults.ClickCancel();

                throw new Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException(
                    "Failed to find device, '" +
                    deviceName +
                    "', in Discovered Objects list view!");
            }

            #endregion // Select Device for Management

            #region Set Management Mode

            // check product sku for SCE
            if (ProductSku.Sku == ProductSkuLevel.Mom)
            {
                // if windows computers, set the management mode
                if (deviceType == DeviceType.WindowsComputer)
                {
                    // agent managed
                    if (managementMode == ManagementMode.AgentManaged)
                    {
                        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting agent-managed mode...");

                        discoveryResults.Controls.ManagementModeComboBox.SelectByText(
                            DeviceDiscovery.Wizards.DiscoveryResultsWindow.Strings.ComboBoxAgentManaged);
                    }
                    else if (managementMode == ManagementMode.ProxyManaged)
                    {
                        // agentless/proxy managed
                        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting agentless-managed mode...");

                        discoveryResults.Controls.ManagementModeComboBox.SelectByText(
                            DeviceDiscovery.Wizards.DiscoveryResultsWindow.Strings.ComboBoxAgentlessManaged);
                    }
                    else
                    {
                        throw new ArgumentException("Management mode is invalid!\n\r" +
                            "Management mode value:  " + managementMode);
                    }
                }
                else if (deviceType == DeviceType.NetworkDevice)
                {
                    // management mode is proxy-managed for network devices
                }
                else
                {
                    throw new ArgumentException("Management mode is invalid for this device type!\n\r" +
                        "Management mode:  " + managementMode + "\n\rDeviceType:  " + deviceType);
                }
            }

            // click "Next"
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(discoveryResults.Controls.NextButton, Constants.OneMinute);
            discoveryResults.ClickNext();

            #endregion // Set Management Mode

            #region Set Agent Installation Options

            DeviceDiscovery.Wizards.AgentInstallSummaryWindow installSummary =
                new Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.AgentInstallSummaryWindow(
                    CoreManager.MomConsole);

            // if windows computers and management mode is agent-managed
            if (deviceType == DeviceType.WindowsComputer
                && managementMode == ManagementMode.AgentManaged)
            {
                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting agent install directory...");

                // Use default directory
                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Using default directory:  '");

                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Setting agent action account...");

                // Use default action account
                installSummary.Controls.LocalSystemRadioButton.Click();
            }

            #endregion // Set Agent Installation Options

            #region Finish Discovery Wizard

            Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Finishing the wizard...");

            installSummary.ClickFinish();

            //Wait for the AgentInstallWizard go away
            CoreManager.MomConsole.WaitForDialogClose(installSummary, 100);

            if (showTaskProgress == true)
            {
                // monitor agent install task progress
                if (deviceType == DeviceType.WindowsComputer &&
                    managementMode == ManagementMode.AgentManaged)
                {
                    // monitor task progress
                    if (Utilities.MonitorTaskProgress(true) == false)
                    {
                        throw new Exception("Agent install failed!");
                    }
                }
            }

            #endregion // Finish Discovery Wizard

            #region Verify Successful Discovery

            // flag used for verification
            bool foundDevice = false;

            if (verifyDeviceAppears == true)
            {

                Core.Common.Utilities.LogMessage(
                    "DeviceDiscovery::DiscoverDevice::Verifying discovery...");

                #region Navigate to View

                // navigate to corresponding view
                CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(
                    NavigationPane.WunderBarButton.Administration);
                string treeNodeText = null;

                // if windows computer
                if (deviceType == DeviceType.WindowsComputer)
                {
                    // check management mode
                    if (managementMode == ManagementMode.AgentManaged)
                    {
                        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Looking for agent-managed computer...");

                        treeNodeText = NavigationPane.Strings.AdminTreeViewAgentManagedComputers;
                    }
                    else
                    {
                        Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Looking for agentless-managed computer...");

                        treeNodeText = NavigationPane.Strings.AdminTreeViewAgentlessManagedComputers;
                    }
                }
                else
                {
                    // network devices
                    Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Looking for network devices...");

                    treeNodeText = NavigationPane.Strings.AdminTreeViewNetworkDevices;
                }

                CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeText).Select();
                CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeText).Click();

                #endregion Navigate to View

                #region Wait for Device

                string displayName = null;
                string searchColumn = null;

                if (deviceType == DeviceType.WindowsComputer)
                {
                    displayName = deviceName;
                    searchColumn = ViewPane.Strings.AdministrationGridViewColumnName;
                }
                else if (deviceType == DeviceType.NetworkDevice)
                {
                    displayName = deviceIpAddress;
                    searchColumn = ViewPane.Strings.AdministrationGridViewColumnIpAddress;
                }

                // wait for device to appear, max wait:  one minute
                timeWaited = 0;
                foundDevice = false;
                int gridRowsCount;

                while (foundDevice == false && timeWaited < MaxTimeWaited)
                {
                    // refresh the view
                    CoreManager.MomConsole.ViewPane.Grid.Click();
                    CoreManager.MomConsole.SendKeys(Core.Common.KeyboardCodes.F5);
                    gridRowsCount = CoreManager.MomConsole.ViewPane.Grid.Rows.Count;

                    // look for the device in the grid
                    if (gridRowsCount > 1 && CoreManager.MomConsole.ViewPane.Grid.FindData(displayName, searchColumn) != null)
                    {
                        foundDevice = true;
                    }
                    else
                    {
                        // increment the seconds waited
                        timeWaited = timeWaited + 2;

                        // sleep for two seconds
                        Maui.Core.Utilities.Sleeper.Delay(2000);
                    }
                }

                Core.Common.Utilities.LogMessage("DeviceDiscovery::DiscoverDevice::Waited " + timeWaited + " seconds for device to appear.");

                #endregion Wait for Device

                #region Report Success or Failure

                // verify device in view
                if (foundDevice == true)
                {
                    Core.Common.Utilities.LogMessage(
                        "DeviceDiscovery::DiscoverDevice::Successfully discovered device:  " +
                        deviceName);
                }
                else
                {
                    throw new Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException(
                        "Failed to find device, '" + deviceName + "', in view, '" +
                        managementMode +
                        "'\nWaited " +
                        timeWaited +
                        " seconds for device to appear.");
                }
                #endregion Report Success or Failure
            }
            else
            {
                Core.Common.Utilities.LogMessage(
                    "DeviceDiscovery::DiscoverDevice::Skipping verification...");

                // assume device will appear eventually
                foundDevice = true;
            }

            #endregion // Verify Successful Discovery

            return foundDevice;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to delete a device that was discovered and is now managed
        /// by Mom.  This method assumes that the device is a Windows device
        /// that is located in the same domain as the root health service 
        /// management server and has an agent installed.
        /// </summary>
        /// <param name="deviceName">Name of the Windows computer</param>
        /// <returns>True if successful, otherwise false</returns>
        /// ------------------------------------------------------------------
        public static bool DeleteDevice(string deviceName)
        {
            return Utilities.DeleteDevice(
                deviceName,
                System.Environment.UserDomainName,
                DeviceType.WindowsComputer, 
                ManagementMode.AgentManaged);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to delete a device that was discovered and is now managed
        /// by Mom.  This method assumes that the device is a Windows device
        /// and has an agent installed.
        /// </summary>
        /// <param name="deviceName">Name of the Windows computer</param>
        /// <param name="domainName">Name of the domain containing the Windows computer</param>
        /// <returns>True if successful, otherwise false</returns>
        /// ------------------------------------------------------------------
        public static bool DeleteDevice(string deviceName, string domainName)
        {
            return Utilities.DeleteDevice(
                deviceName,
                domainName,
                DeviceType.WindowsComputer,
                ManagementMode.AgentManaged);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to delete a device that was discovered and is now managed
        /// by Mom.
        /// </summary>
        /// <param name="deviceName">Name of the device</param>
        /// <param name="deviceType">Enumeration indicating the device type</param>
        /// <param name="managementMode">Enumeration indicating the management mode</param>
        /// <returns>True if successful, otherwise false</returns>
        /// <history>
        ///     [KellyMor]  O8FEB06 Created  
        /// </history>
        /// ------------------------------------------------------------------
        public static bool DeleteDevice(
            string deviceName, 
            DeviceDiscovery.DeviceType deviceType, 
            DeviceDiscovery.ManagementMode managementMode) 
        {
            return Utilities.DeleteDevice(
                deviceName,
                System.Environment.UserDomainName,
                deviceType,
                managementMode);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to delete a device that was discovered and is now managed
        /// by Mom.
        /// </summary>
        /// <param name="deviceName">Name of the device</param>
        /// <param name="domainName">Name of the domain containing the device</param>
        /// <param name="deviceType">Enumeration indicating the device type</param>
        /// <param name="managementMode">Enumeration indicating the management mode</param>
        /// <returns>True if successful, otherwise false</returns>
        /// <history>
        ///     [KellyMor]  21SEP05 Created 
        ///     [KellyMor]  26JUL06 Added a call to TurnOffViewGrouping
        ///     [v-liqluo]  04FEB10 comment the call to Utilities.TurnOffViewGrouping(treeNodeName)
        /// </history>
        /// ------------------------------------------------------------------
        public static bool DeleteDevice(
            string deviceName,
            string domainName,
            DeviceDiscovery.DeviceType deviceType,
            DeviceDiscovery.ManagementMode managementMode)
        {
            bool success = false;

            #region Navigate to View

            // navigate to the appropriate view
            CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Administration);

            // select the view corresponding to device type and management mode
            string treeNodeName = null;
            if (deviceType == DeviceType.WindowsComputer)
            {
                // check management mode
                if (managementMode == ManagementMode.AgentManaged)
                {
                    treeNodeName = NavigationPane.Strings.AdminTreeViewAgentManagedComputers;
                }
                else
                {
                    treeNodeName = NavigationPane.Strings.AdminTreeViewAgentlessManagedComputers;
                }
            }
            else
            {
                treeNodeName = NavigationPane.Strings.AdminTreeViewNetworkDevices;
            }

            CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeName).Select();
            CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeName).Click();

            //[v-liqluo] 04FEB10 comment this, no need to turn off grouping
            // turn off grouping
            //Utilities.TurnOffViewGrouping(treeNodeName);

            // reselect the view
            CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeName).Select();
            CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeName).Click();

            #endregion // Navigate to View

            #region Remove the Device

            // set the key column name to match
            string keyColumnName = null;
            if (deviceType == DeviceType.WindowsComputer)
            {
                // use the "FQDN" column
                keyColumnName = ViewPane.Strings.AdministrationGridViewColumnFqdnName;

                //Get the deviceName, we need to consider Disjoint Namespace
                deviceName = Core.Common.Utilities.GetServerNameFqdn(deviceName);
            }
            else
            {
                // use the "IP Address" column
                keyColumnName = ViewPane.Strings.AdministrationGridViewColumnIpAddress;
            }

            #region Find the Device

            // retry loop            
            const int MaxAttempts = 5;

            // get the grid row
            Maui.Core.WinControls.DataGridViewRow deviceDataGridViewRow = 
                CoreManager.MomConsole.ViewPane.Grid.FindData(
                    deviceName,
                    keyColumnName); 
                
            for (int currentAttempt = 1; 
                ((null == deviceDataGridViewRow) && (currentAttempt <= MaxAttempts)); 
                currentAttempt++)
            {
                // log the attempt
                Core.Common.Utilities.LogMessage(
                    "Attempt " +
                    currentAttempt +
                    " of " +
                    MaxAttempts);

                #region Refresh the grid view

                Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.DefaultContextMenuTimeout);

                // refresh the view just in case
                MomControls.GridControl viewPaneGrid = CoreManager.MomConsole.ViewPane.Grid;

                // left-click in the grid
                viewPaneGrid.Click();

                // right-click in the grid
                viewPaneGrid.Click(
                    MouseClickType.SingleClick,
                    MouseFlags.RightButton);

                // get the context menu
                Maui.Core.WinControls.Menu gridContextMenu =
                    new Menu(Core.Common.Constants.DefaultContextMenuTimeout);

                // execute the "Refresh" context menu item
                gridContextMenu.ExecuteMenuItem(
                    ViewPane.Strings.AdministrationContextMenuRefresh);

                #endregion

                // try to get the row again
                deviceDataGridViewRow = 
                    CoreManager.MomConsole.ViewPane.Grid.FindData(
                        deviceName,
                        keyColumnName);
            }

            #endregion

            // based on device type and management mode
            if (deviceDataGridViewRow != null)
            {
                // Windows computer, agent-managed
                if (deviceType == DeviceType.WindowsComputer
                    && managementMode == ManagementMode.AgentManaged)
                {
                    try
                    {
                        // call the agent uninstall wizard
                        Utilities.UninstallAgent(deviceName, deviceDataGridViewRow);
                    }
                    catch (Maui.GlobalExceptions.MauiException)
                    {
                        // if Uninstall context menu item disabled, will hit Maui exception
                        // agent may be manually installed - try Delete instead
                        Utilities.DeleteAgent(deviceName, deviceDataGridViewRow);
                    }
                    success = true;
                }
                else
                {
                    // left-click row first, or right-click won't get correct menu.
                    deviceDataGridViewRow.AccessibleObject.Click(
                        MouseClickType.SingleClick,
                        MouseFlags.LeftButton);

                    // right-click and delete
                    deviceDataGridViewRow.AccessibleObject.Click(
                        MouseClickType.SingleClick,
                        MouseFlags.RightButton);
                    Maui.Core.WinControls.Menu contextMenu =
                        new Maui.Core.WinControls.Menu(
                            Core.Common.Constants.DefaultContextMenuTimeout);
                    contextMenu.ExecuteMenuItem(
                        ViewPane.Strings.AdministrationContextMenuDelete);

                    // set the confirmation dialog title
                    string confirmationDialogTitle = null;
                    if (deviceType == DeviceType.WindowsComputer)
                    {
                        // Confirm Stop Agentless Monitoring
                        confirmationDialogTitle = ViewPane.Strings.AdministrationConfirmStopAgentlessManagementDialogTitle;
                    }
                    else
                    {
                        // Confirm Delete Network Device
                        confirmationDialogTitle = ViewPane.Strings.AdministrationConfirmDeleteNetworkDeviceDialogTitle;
                    }

                    // confirm the operation
                    CoreManager.MomConsole.ConfirmChoiceDialog(
                            true,
                            confirmationDialogTitle);
                }
            }
            else
            {
                throw
                    new Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException(
                    "Failed to find the search term, '" + deviceName + "', in the grid!");
            }

            #endregion // Remove the Device

            #region Verify Deletion

            // refresh the view
            CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeName).Select();
            CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeName).Click();
            CoreManager.MomConsole.ViewPane.Extended.Click();
            CoreManager.MomConsole.ViewPane.SendKeys(Core.Common.KeyboardCodes.F5);

            // set the key column name to match
            if (deviceType == DeviceType.WindowsComputer)
            {
                // use the "Name" column
                keyColumnName = ViewPane.Strings.AdministrationGridViewColumnName;
            }
            else
            {
                // use the "IP Address" column
                keyColumnName = ViewPane.Strings.AdministrationGridViewColumnIpAddress;
            }

            // check that the device is gone
            deviceDataGridViewRow = null;
            deviceDataGridViewRow = 
                CoreManager.MomConsole.ViewPane.Grid.FindData(
                    deviceName,
                    keyColumnName);

            // set return value to confirm device deletion
            if (deviceDataGridViewRow == null)
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

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to monitor the agent install task status/progress.
        /// </summary>
        /// <returns>True if the agent install succeeds.</returns>
        /// <exception cref="Maui.Core.Window.Exceptions.WindowNotFoundException">
        /// Throws WindowNotFoundException if it cannot find the task status dialog.
        /// </exception>
        /// <history>
        ///     [KellyMor]  21SEP05 Created  
        /// </history>
        /// -----------------------------------------------------------------------------
        public static bool MonitorTaskProgress()
        {
            // monitor task progress and leave the window open
            return Utilities.MonitorTaskProgress(false);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to monitor the agent install task status/progress.
        /// </summary>
        /// <param name="closeWindowOnTaskFinish">
        /// Flag indicating if the method should close the window when the task finishes.
        /// </param>
        /// <returns>True if the agent install succeeds.</returns>
        /// <exception cref="Maui.Core.Window.Exceptions.WindowNotFoundException">
        /// Throws WindowNotFoundException if it cannot find the task status dialog.
        /// </exception>
        /// <history>
        ///     [KellyMor]  21SEP05 Created  
        /// </history>
        /// -----------------------------------------------------------------------------
        public static bool MonitorTaskProgress(bool closeWindowOnTaskFinish)
        {
            Core.Common.Utilities.LogMessage("DeviceDiscovery::MonitorTaskProgress::Monitoring task progress...");

            bool returnValue = false;

            // look for the Agent Management Task Status dialog
            DeviceDiscovery.Wizards.AgentManagementTaskStatusWindow statusWindow =
                new Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.AgentManagementTaskStatusWindow(
                CoreManager.MomConsole);
            UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow);
            UISynchronization.WaitForUIObjectReady(statusWindow);

            Core.Common.Utilities.LogMessage("DeviceDiscovery::MonitorTaskProgress::Getting the status of the agent install task...");

            // set a timer limit
            int waitTime = 0;

            // default wait time:  one minute
            int maxWaitTime = 60;

            // check for task targets in the list view
            while (statusWindow.Controls.TargetsListView.Items.Count <= 0 &&
                waitTime <= maxWaitTime)
            {
                // wait three seconds
                Maui.Core.Utilities.Sleeper.Delay(3000);

                // increment the wait time
                waitTime += 3;
            }

            // check to see if there are task targets yet
            if (statusWindow.Controls.TargetsListView.Items.Count <= 0)
            {
                throw new Exception("DeviceDiscovery::MonitorTaskProgress::No task targets appeared in the list!");
            }

            // get the agent task status
            string statusText = null;
            foreach (Maui.Core.WinControls.ListViewSubItem column in statusWindow.Controls.TargetsListView.Items[0].SubItems)
            {
                statusText = statusText + column.Text.Trim();
            }

            Core.Common.Utilities.LogMessage("DeviceDiscovery::MonitorTaskProgress::Status of the agent install task:  " + statusText);

            // set a timer limit
            waitTime = 0;
            
            // default wait time:  eight minutes
            maxWaitTime = 480;

            // the task is done when it no longer ends with "Scheduled"
            bool taskDone = !(statusText.EndsWith(DeviceDiscovery.Wizards.AgentManagementTaskStatusWindow.Strings.TaskScheduled));

            // while the task status is "Scheduled"
            while (taskDone == false && waitTime < maxWaitTime)
            {
                // sleep 2 seconds
                waitTime += 2;
                Maui.Core.Utilities.Sleeper.Delay(2000);

                // get the agent task status
                statusText = null;
                foreach (Maui.Core.WinControls.ListViewSubItem column in statusWindow.Controls.TargetsListView.Items[0].SubItems)
                {
                    statusText = statusText + column.Text.Trim();
                }

                // is the task done?
                taskDone = !(statusText.EndsWith(DeviceDiscovery.Wizards.AgentManagementTaskStatusWindow.Strings.TaskScheduled));
            }

            Core.Common.Utilities.LogMessage("DeviceDiscovery::MonitorTaskProgress::Status of the agent install task:  " + statusText);
            Core.Common.Utilities.LogMessage("DeviceDiscovery::MonitorTaskProgress::Agent install task done:  " + taskDone.ToString());
            Core.Common.Utilities.LogMessage("DeviceDiscovery::MonitorTaskProgress::Waited for " + waitTime + " seconds.");

            // if task status "Succeeded" return true
            if (statusText.EndsWith(DeviceDiscovery.Wizards.AgentManagementTaskStatusWindow.Strings.TaskSucceeded))
            {
                // task succeeded
                Core.Common.Utilities.LogMessage("DeviceDiscovery::MonitorTaskProgress::Task succeeded:  " + statusText);
                returnValue = true;
            }
            else
            {
                // select each item
                statusWindow.Controls.TargetsListView.Items[0].Click();

                // log the failure text
                Core.Common.Utilities.LogMessage("DeviceDiscovery::MonitorTaskProgress::Task failed or failed to complete");
                Core.Common.Utilities.LogMessage("DeviceDiscovery::MonitorTaskProgress::Task status text:  " + statusText);
            }

            // should the window be closed?
            if (closeWindowOnTaskFinish == true)
            {
                // close the status window
                statusWindow.ClickClose();
            }

            return returnValue;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method IsAgentPendingInstalled to check if the device is pending installed.
        /// </summary>
        /// <param name="momDeviceFqdn">FQDN of device</param>
        /// <returns>True if installed, otherwise false</returns>
        /// <history>
        ///     [v-liqluo]  O6DEC09 Created  
        /// </history>
        public static bool IsAgentPendingInstalled(string momDeviceFqdn)
        {
            Core.Common.Utilities.LogMessage("DeviceDiscovery::IsAgentPendingInstalled...");
            bool installed = false;

            #region Navigate to View

            CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Administration);

            // select the Peding Management view
            string treeNodeName = NavigationPane.Strings.AdminTreeViewPendingManagement;
            
            CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeName).Select();
            CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeName).Click();

            #endregion // Navigate to View

            #region Check if the agent is pending installed

            #region Find the pending device

            // retry loop            
            const int MaxAttempts = 5;

            // get the grid row
            Maui.Core.WinControls.DataGridViewRow deviceDataGridViewRow =
                    CoreManager.MomConsole.ViewPane.Grid.FindData(
                        momDeviceFqdn,
                        Core.Console.ViewPane.Strings.AdministrationGridViewColumnName);

            for (int currentAttempt = 1;
                ((null == deviceDataGridViewRow) && (currentAttempt <= MaxAttempts));
                currentAttempt++)
            {
                // log the attempt
                Core.Common.Utilities.LogMessage(
                    "DeviceDiscovery::IsAgentPendingInstalled:: Attempt " +
                    currentAttempt +
                    " of " +
                    MaxAttempts);

                #region Refresh the grid view

                Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.DefaultContextMenuTimeout);

                // refresh the view just in case
                MomControls.GridControl viewPaneGrid = CoreManager.MomConsole.ViewPane.Grid;

                // left-click in the grid
                viewPaneGrid.Click();

                // right-click in the grid
                viewPaneGrid.Click(
                    MouseClickType.SingleClick,
                    MouseFlags.RightButton);

                // get the context menu
                Maui.Core.WinControls.Menu gridContextMenu =
                    new Menu(Core.Common.Constants.DefaultContextMenuTimeout);

                // execute the "Refresh" context menu item
                gridContextMenu.ExecuteMenuItem(
                    ViewPane.Strings.AdministrationContextMenuRefresh);

                #endregion //Refresh the grid view

                // try to get the row again
                deviceDataGridViewRow =
                    CoreManager.MomConsole.ViewPane.Grid.FindData(
                        momDeviceFqdn,
                        Core.Console.ViewPane.Strings.AdministrationGridViewColumnName);
            }

            #endregion //Find the pending device

            //Check and return
            if (deviceDataGridViewRow != null)
            {
                Core.Common.Utilities.LogMessage("DeviceDiscovery::IsAgentPendingInstalled:: The agent is pending installed := " + momDeviceFqdn);
                installed = true;
            }
            else
            {
                Core.Common.Utilities.LogMessage("DeviceDiscovery::IsAgentPendingInstalled:: There is no pending installed agent.");
                installed = false;
            }

            #endregion //Check if the device is pending installed

            return installed;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to check and uninstall or delete(if cannot uninstall) computers
        /// Use AgentMgmtTest.MP to uninstall pending agent computers and use sdk to delete them
        /// Use sdk to delete agentless computers
        /// Use sdk to delete network devices
        /// Use momconsole to uninstall agent computers
        /// </summary>
        /// <history>
        ///     [v-frma]  06Dec11 Created  
        /// </history>
        /// ------------------------------------------------------------------
        public static void CheckAndUninstallComputersAndDevices()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Core.Common.Utilities.LogMessage(currentMethod + ":: Started...");

            try
            {
                string agentMgmtTestMP = "AgentMgmtTest.MP";
                if (!Core.Common.Utilities.ManagementPackExists(agentMgmtTestMP))
                {
                    Core.Common.Utilities.LogMessage(currentMethod + ":: this method needs MP:" + agentMgmtTestMP);
                    return;
                }
                
                ManagementGroup managementGroup = ManagementGroup.Connect(Core.Common.Utilities.MomServerName);

                #region Check and uninstall pending agent computers
                IList<AgentPendingAction> pendingComputers = managementGroup.Administration.GetAgentPendingActions();
                if (pendingComputers.Count > 0)
                {
                    AgentMgmtUtil agentMgmtUtil = new Microsoft.EnterpriseManagement.Test.ScCommon.AgentMgmt.AgentMgmtUtil();
                    ManualAgentInstall manualAgentInstall = new ManualAgentInstall(agentMgmtUtil);
                    AgentConfig agentConfig = new AgentConfig();
                    string userAccount = Mom.Test.Infrastructure.PasswordManager.GetDomainAdminAccount();
                    Core.Common.Utilities.LogMessage(currentMethod + ":: Get domain admin user Account: " + userAccount);
                    string password = Mom.Test.Infrastructure.PasswordManager.GetPassword(userAccount);
                    Core.Common.Utilities.LogMessage(currentMethod + ":: Get domain admin user password: " + password);
                    string domainName = Core.Common.Utilities.UserDnsDomainName;
                    Core.Common.Utilities.LogMessage(currentMethod + ":: Get domain admin user dns domain name: " + domainName);
                    agentConfig.InstallUser = new User(userAccount, domainName);
                    agentConfig.InstallUser.Password = password;
                    agentConfig.ActionAccount = new User(userAccount, domainName);
                    agentConfig.ActionAccount.Password = password;

                    //uninstall all the pending agents
                    foreach (AgentPendingAction computer in pendingComputers)
                    {
                        Core.Common.Utilities.LogMessage(currentMethod + ":: uninstall agent:" + computer.AgentName);
                        manualAgentInstall.UninstallManualAgent(computer.AgentName, agentConfig);
                        Core.Common.Utilities.LogMessage(currentMethod + ":: Waiting one minute to allow possibly manually installed agent to uninstall");
                        Sleeper.Delay(Constants.OneMinute);
                    }

                    //delete all the pending agents
                    Core.Common.Utilities.LogMessage(currentMethod + ":: delete all the agent pending computers:");
                    managementGroup.Administration.RejectAgentPendingActions(pendingComputers);
                    Core.Common.Utilities.LogMessage(currentMethod + ":: delete succeed.");
                } 
                #endregion

                #region Check and delete agentless computers
                IList<RemotelyManagedComputer> agentlessComputers = managementGroup.Administration.GetAllRemotelyManagedComputers();
                if (agentlessComputers.Count > 0)
                {
                    //log all the agentless computers
                    foreach (RemotelyManagedComputer computer in agentlessComputers)
                    {
                        Core.Common.Utilities.LogMessage(currentMethod + ":: agentless computer name:" + computer.ComputerName);
                    }

                    //delete all the agentless computers
                    Core.Common.Utilities.LogMessage(currentMethod + ":: delete all the agentless managed computer");
                    managementGroup.Administration.DeleteRemotelyManagedComputers(agentlessComputers);
                    Core.Common.Utilities.LogMessage(currentMethod + ":: delete succeed.");
                }
                #endregion

                #region check and delete network devices
                IList<RemotelyManagedDevice> networkDevices = managementGroup.Administration.GetAllRemotelyManagedDevices();

                if (networkDevices.Count > 0)
                {
                    //log all the network devices
                    foreach (RemotelyManagedDevice device in networkDevices)
                    {
                        Core.Common.Utilities.LogMessage(currentMethod + ":: device display name:" + device.DisplayName);
                    }

                    //delete all the network devices
                    Core.Common.Utilities.LogMessage(currentMethod + ":: delete all the network devices:");
                    managementGroup.Administration.DeleteRemotelyManagedDevices(networkDevices);
                    Core.Common.Utilities.LogMessage(currentMethod + ":: delete succeed.");
                } 
                #endregion

                #region check and uninstall agentl computers
                IList<AgentManagedComputer> agentComputers = managementGroup.Administration.GetAllAgentManagedComputers();
                if (agentComputers.Count > 0)
                {
                    //uninstall the all agent computers 
                    foreach (AgentManagedComputer computer in agentComputers)
                    {
                        Core.Common.Utilities.LogMessage(currentMethod + ":: uninstall agent:" + computer.ComputerName);
                        Utilities.DeleteDevice(computer.ComputerName, DeviceType.WindowsComputer, ManagementMode.AgentManaged);
                        Core.Common.Utilities.LogMessage(currentMethod + ":: uninstall succeed.");
                    }
                } 
                #endregion

            }
            catch (Microsoft.EnterpriseManagement.Common.EnterpriseManagementException sdkException)
            {
                throw new Microsoft.EnterpriseManagement.Common.EnterpriseManagementException(String.Format("Failed to connect to MOM management group : {0}", Core.Common.Utilities.MomServerName), sdkException);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(String.Format("Failed to connect to MOM management group : {0}", Core.Common.Utilities.MomServerName), e);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to check and delete computers and devices 
        /// if there are agent, agentless, pending agent 
        /// or network devices installed
        /// </summary>
        /// <history>
        ///     [v-liqluo]  11JAN10 Created  
        /// </history>
        /// ------------------------------------------------------------------
        public static void CheckAndDeleteComputersAndDevices()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Core.Common.Utilities.LogMessage(currentMethod + ":: Started...");

            try
            {
                ManagementGroup managementGroup = ManagementGroup.Connect(Core.Common.Utilities.MomServerName);

                //check and delete agent computers.
                IList<AgentManagedComputer> agentComputers = managementGroup.Administration.GetAllAgentManagedComputers();

                if (agentComputers.Count > 0)
                {
                    //log all the agent computers
                    foreach (AgentManagedComputer computer in agentComputers)
                    {
                        Core.Common.Utilities.LogMessage(currentMethod + ":: agent computer name:" + computer.ComputerName);
                    }

                    //delete all the agent computers
                    Core.Common.Utilities.LogMessage(currentMethod + ":: delete all the agent managed computers");
                    managementGroup.Administration.DeleteAgentManagedComputers(agentComputers);
                    Core.Common.Utilities.LogMessage(currentMethod + ":: delete succeed.");
                }

                //check and delete agentless computers
                IList<RemotelyManagedComputer> agentlessComputers = managementGroup.Administration.GetAllRemotelyManagedComputers();

                if (agentlessComputers.Count > 0)
                {
                    //log all the agentless computers
                    foreach (RemotelyManagedComputer computer in agentlessComputers)
                    {
                        Core.Common.Utilities.LogMessage(currentMethod + ":: agentless computer name:" + computer.ComputerName);
                    }

                    //delete all the agentless computers
                    Core.Common.Utilities.LogMessage(currentMethod + ":: delete all the agentless managed computer");
                    managementGroup.Administration.DeleteRemotelyManagedComputers(agentlessComputers);
                    Core.Common.Utilities.LogMessage(currentMethod + ":: delete succeed.");
                }

                //check and delete pending agent computers
                IList<AgentPendingAction> pendingComputers = managementGroup.Administration.GetAgentPendingActions();
                if (pendingComputers.Count > 0)
                {
                    //log all the pending agents
                    foreach (AgentPendingAction computer in pendingComputers)
                    {
                        Core.Common.Utilities.LogMessage(currentMethod + ":: agent name:" + computer.AgentName);
                    }

                    //delete all the pending agents
                    Core.Common.Utilities.LogMessage(currentMethod + ":: delete all the agent pending computers:");
                    managementGroup.Administration.RejectAgentPendingActions(pendingComputers);
                    Core.Common.Utilities.LogMessage(currentMethod + ":: delete succeed.");
                }

                ///check and delete network devices
                IList<RemotelyManagedDevice> networkDevices = managementGroup.Administration.GetAllRemotelyManagedDevices();

                if (networkDevices.Count > 0)
                {
                    //log all the network devices
                    foreach (RemotelyManagedDevice device in networkDevices)
                    {
                        Core.Common.Utilities.LogMessage(currentMethod + ":: device display name:" + device.DisplayName);
                    }

                    //delete all the network devices
                    Core.Common.Utilities.LogMessage(currentMethod + ":: delete all the network devices:");
                    managementGroup.Administration.DeleteRemotelyManagedDevices(networkDevices);
                    Core.Common.Utilities.LogMessage(currentMethod + ":: delete succeed.");
                }
            }
            catch (Microsoft.EnterpriseManagement.Common.EnterpriseManagementException sdkException)
            {
                throw new Microsoft.EnterpriseManagement.Common.EnterpriseManagementException(String.Format("Failed to connect to MOM management group : {0}", Core.Common.Utilities.MomServerName), sdkException);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(String.Format("Failed to connect to MOM management group : {0}", Core.Common.Utilities.MomServerName), e);
            }
        }

        #endregion // Public Static Methods

        #region Private Static Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to run the uninstall agent wizard
        /// </summary>
        /// <param name="agentComputer">computer to uninstall agent</param>
        /// <param name="agentComputerRow">
        /// Row in the grid view containing the agent
        /// </param>
        /// <history>
        ///     [KellyMor]  21SEP05 Created  
        ///     [KellyMor]  30AUG06 Added retry logic to context menu 'Uninstall'
        /// </history>
        /// -----------------------------------------------------------------------------
        private static void UninstallAgent(
            string agentComputer,
            Maui.Core.WinControls.DataGridViewRow agentComputerRow)
        {
            Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::UninstallAgent parameters...");
            Core.Common.Utilities.LogMessage("agentComputer:  '" + agentComputer + "'");
            Core.Common.Utilities.LogMessage("agentComputerRow:  '" + agentComputerRow.Value.ToString() + "'");

            // check for a valid grid row
            if (agentComputerRow == null)
            {
                throw new System.ArgumentNullException("agentComputerRow cannot be null!");
            }
            
            // check for a valid computer name
            if (agentComputer != null && agentComputer.Length > 0)
            {
                Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::Starting Agent Uninstall Wizard...");

                // click agent row first, or Right Click won't get right menu.
                agentComputerRow.AccessibleObject.Click(
                    MouseClickType.SingleClick,
                    MouseFlags.LeftButton);

                // right-click and select uninstall agent
                agentComputerRow.AccessibleObject.Click(
                    MouseClickType.SingleClick,
                    MouseFlags.RightButton);

                Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::Getting the context menu...");

                // get the context menu for the grid
                Maui.Core.WinControls.Menu contextMenu =
                    new Maui.Core.WinControls.Menu(
                        Core.Common.Constants.DefaultContextMenuTimeout);

                Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::Getting the 'Uninstall' context menu item...");

                // get the "Uninstall" menu item
                Maui.Core.WinControls.MenuItem uninstallMenuItem =
                    new MenuItem(
                        contextMenu, 
                        Core.Console.ViewPane.Strings.AdministrationContextMenuUninstall);

                // check for a null menu item
                if (null != uninstallMenuItem)
                {
                    Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::'Uninstall' context menu item was valid.");

                    // check that the menu item is enabled
                    if (uninstallMenuItem.Enabled)
                    {
                        Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::Executing 'Uninstall' context menu item...");

                        // execute the menu item
                        contextMenu.ExecuteMenuItem(
                            Core.Console.ViewPane.Strings.AdministrationContextMenuUninstall);
                    }
                    else
                    {
                        // the menu item was not enabled, try again
                        Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::'Uninstall context menu was NOT valid!");

                        // refresh the grid view
                        CoreManager.MomConsole.ViewPane.Grid.Click();
                        CoreManager.MomConsole.Refresh();

                        Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::Searching for the agent row again...");

                        // get the agent row agin
                        agentComputerRow =
                            CoreManager.MomConsole.ViewPane.Grid.FindData(
                                agentComputer,
                                Core.Console.ViewPane.Strings.AdministrationGridViewColumnFqdnName);

                        Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::Checking for a valid agent row...");

                        if (null != agentComputerRow)
                        {
                            Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::Agent row exists.");

                            // click agent row first, or Right Click won't get right menu.
                            agentComputerRow.AccessibleObject.Click(
                                MouseClickType.SingleClick,
                                MouseFlags.LeftButton);

                            //if not ready, wait 1 more minute - row can exist but not be ready
                            if (!agentComputerRow.AccessibleObject.State.Equals("Healthy"))
                            {
                                Core.Common.Utilities.LogMessage("Agent state: " + agentComputerRow.AccessibleObject.State.ToString());
                                Core.Common.Utilities.TakeScreenshot("Agent_still_not_showing_Healthy");
                                Sleeper.Delay(OneMinuteInSeconds * 1000);
                            }
                            else
                            {
                                Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::Agent row is valid/ready");
                            }

                            // right-click and select uninstall agent
                            agentComputerRow.AccessibleObject.Click(
                                MouseClickType.SingleClick,
                                MouseFlags.RightButton);

                            Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::Retrying the context menu...");

                            // get the context menu
                            contextMenu =
                                new Maui.Core.WinControls.Menu(
                                    Core.Common.Constants.DefaultContextMenuTimeout);

                            Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::Retrying 'Uninstall' context menu item...");

                            // get the "Uninstall" menu item
                            uninstallMenuItem =
                                new MenuItem(
                                    contextMenu,
                                    Core.Console.ViewPane.Strings.AdministrationContextMenuUninstall);

                            // check that the menu item is enabled
                            if (uninstallMenuItem.Enabled)
                            {
                                Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::'Uninstall' conexte menu was valid on retry.");

                                // execute the menu item
                                contextMenu.ExecuteMenuItem(
                                    Core.Console.ViewPane.Strings.AdministrationContextMenuUninstall);
                            }
                            else
                            {
                                // the context menu was still not active
                                throw new MauiException(
                                    "Unable to get active context menu item on retry:  '" +
                                    Core.Console.ViewPane.Strings.AdministrationContextMenuUninstall +
                                    "'");
                            }
                        }
                        else
                        {
                            // the grid row returned was null
                            throw new NullReferenceException(
                                "Failed to find agent in the grid view on retry!  " +
                                agentComputer);
                        }
                    }
                }
                else
                {
                    // failed to find the "Uninstall" context menu item
                    throw new NullReferenceException(
                        "Unable to find context menu item:  '" +
                        Core.Console.ViewPane.Strings.AdministrationContextMenuUninstall +
                        "'");
                }

                // find wizard window
                Core.Console.DeviceDiscovery.Wizards.AgentUninstallWizardWindow agentUninstallWizard =
                    new Mom.Test.UI.Core.Console.DeviceDiscovery.Wizards.AgentUninstallWizardWindow(
                        CoreManager.MomConsole,
                        Core.Console.DeviceDiscovery.Wizards.AgentActionType.Uninstall);

                Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::Setting uninstall account options...");

                // check if we can use the server action account or not
                if (false == Utilities.UseOtherActionAccountType(null, null))
                {
                    Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::Using Management Server account...");

                    // if windows computers, use management server account
                    agentUninstallWizard.CommonControls.ExistingUserAccountRadioButton.Click();
                }
                else
                {
                    Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::Using domain admin account...");

                    // use an admin account
                    agentUninstallWizard.CommonControls.OtherUserAccountRadioButton.Click();

                    // get username/password from credential store
                    string userAccount = Mom.Test.Infrastructure.PasswordManager.GetDomainAdminAccount();
                    string password = Mom.Test.Infrastructure.PasswordManager.GetPassword(userAccount);

                    Core.Common.Utilities.LogMessage(
                        "DeviceDiscovery::UninstallAgent::user account:  '" +
                        userAccount +
                        "', password:  '" +
                        password +
                        "'");

                    // set account credentials
                    agentUninstallWizard.CommonControls.UserNameTextBox.Text = userAccount;
                    agentUninstallWizard.CommonControls.PasswordTextBox.Text = password;
                }

                // click "Uninstall"
                agentUninstallWizard.ClickUninstall();

                //Wait for the AgentUninstallWizard go away
                CoreManager.MomConsole.WaitForDialogClose(agentUninstallWizard, 10);

                // monitor task progress
                if (Utilities.MonitorTaskProgress(true) == false)
                {
                    throw new Exception("Agent uninstall failed!");
                }

                //Verify the Registry key
                string regAgentMGPath = @"SOFTWARE\Microsoft\Microsoft  Operations Manager\3.0\Agent Management Groups";
                bool regKeyExist = Core.Common.Utilities.RegistryKeyExist(RegistryHive.Win32LocalMachine,regAgentMGPath);
                if (regKeyExist)
	            {

                   Core.Common.Utilities.LogMessage("DeviceDiscovery::Error:Verify for Registry key: The Agent Management Group key still exists in Registry!");
                   throw new InvalidOperationException("Uninstall agent failed to delete Regkeys in Registry!");
		 
	            }
                else
	            {
                   Core.Common.Utilities.LogMessage("DeviceDiscovery::Verify for Registry key: The Agent Management Group key has been deleted in Registry!");
	            }
            }
            else
            {
                throw new System.ArgumentException(
                    "The value for agentComputer cannot be null or empty-string, value:  '" +
                    agentComputer + "'");
            }
        }

        private static void DeleteAgent(
            string agentComputer,
            Maui.Core.WinControls.DataGridViewRow agentComputerRow)
        {
            Core.Common.Utilities.LogMessage("DeviceDiscovery::UninstallAgent::DeleteAgent parameters...");
            Core.Common.Utilities.LogMessage("agentComputer:  '" + agentComputer + "'");
            Core.Common.Utilities.LogMessage("agentComputerRow:  '" + agentComputerRow.Value.ToString() + "'");

            // check for a valid grid row
            if (agentComputerRow == null)
            {
                throw new System.ArgumentNullException("agentComputerRow cannot be null!");
            }

            // check for a valid computer name
            if (agentComputer != null && agentComputer.Length > 0)
            {
                Core.Common.Utilities.LogMessage("DeviceDiscovery::DeleteAgent::Clicking Delete...");

                // click agent row first, or Right Click won't get right menu.
                agentComputerRow.AccessibleObject.Click(
                    MouseClickType.SingleClick,
                    MouseFlags.LeftButton);

                // right-click and select uninstall agent
                agentComputerRow.AccessibleObject.Click(
                    MouseClickType.SingleClick,
                    MouseFlags.RightButton);

                Core.Common.Utilities.LogMessage("DeviceDiscovery::DeleteAgent::Getting the context menu...");

                // get the context menu for the grid
                Maui.Core.WinControls.Menu contextMenu =
                    new Maui.Core.WinControls.Menu(
                        Core.Common.Constants.DefaultContextMenuTimeout);

                Core.Common.Utilities.LogMessage("DeviceDiscovery::DeleteAgent::Getting the 'Delete' context menu item...");

                // get the "Uninstall" menu item
                Maui.Core.WinControls.MenuItem deleteMenuItem =
                    new MenuItem(
                        contextMenu,
                        Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                // check for a null menu item
                if (null != deleteMenuItem)
                {
                    Core.Common.Utilities.LogMessage("DeviceDiscovery::DeleteAgent::'Delete' context menu item was valid.");

                    // check that the menu item is enabled
                    if (deleteMenuItem.Enabled)
                    {
                        Core.Common.Utilities.LogMessage("DeviceDiscovery::DeleteAgent::Executing 'Delete' context menu item...");

                        // execute the menu item
                        contextMenu.ExecuteMenuItem(
                            Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);
                    }
                    else
                    {
                        // the menu item was not enabled, try again
                        Core.Common.Utilities.LogMessage("DeviceDiscovery::DeleteAgent::'Delete context menu was NOT valid!");

                        // refresh the grid view
                        CoreManager.MomConsole.ViewPane.Grid.Click();
                        CoreManager.MomConsole.Refresh();

                        Core.Common.Utilities.LogMessage("DeviceDiscovery::DeleteAgent::Searching for the agent row again...");

                        // get the agent row agin
                        agentComputerRow =
                            CoreManager.MomConsole.ViewPane.Grid.FindData(
                                agentComputer,
                                Core.Console.ViewPane.Strings.AdministrationGridViewColumnFqdnName);

                        Core.Common.Utilities.LogMessage("DeviceDiscovery::DeleteAgent::Checking for a valid agent row...");

                        if (null != agentComputerRow)
                        {
                            Core.Common.Utilities.LogMessage("DeviceDiscovery::DeleteAgent::Agent row exists.");

                            // click agent row first, or Right Click won't get right menu.
                            agentComputerRow.AccessibleObject.Click(
                                MouseClickType.SingleClick,
                                MouseFlags.LeftButton);

                            //if not ready, wait 1 more minute - row can exist but not be ready
                            if (!agentComputerRow.AccessibleObject.State.Equals("Healthy"))
                            {
                                Core.Common.Utilities.LogMessage("Agent state: " + agentComputerRow.AccessibleObject.State.ToString());
                                Core.Common.Utilities.TakeScreenshot("Agent_still_not_showing_Healthy");
                                Sleeper.Delay(OneMinuteInSeconds * 1000);
                            }
                            else
                            {
                                Core.Common.Utilities.LogMessage("DeviceDiscovery::DeleteAgent::Agent row is valid/ready");
                            }

                            // right-click and select uninstall agent
                            agentComputerRow.AccessibleObject.Click(
                                MouseClickType.SingleClick,
                                MouseFlags.RightButton);

                            Core.Common.Utilities.LogMessage("DeviceDiscovery::DeleteAgent::Retrying the context menu...");

                            // get the context menu
                            contextMenu =
                                new Maui.Core.WinControls.Menu(
                                    Core.Common.Constants.DefaultContextMenuTimeout);

                            Core.Common.Utilities.LogMessage("DeviceDiscovery::DeleteAgent::Retrying 'Delete' context menu item...");

                            // get the "Uninstall" menu item
                            deleteMenuItem =
                                new MenuItem(
                                    contextMenu,
                                    Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);

                            // check that the menu item is enabled
                            if (deleteMenuItem.Enabled)
                            {
                                Core.Common.Utilities.LogMessage("DeviceDiscovery::DeleteAgent::'Delete' context menu was valid on retry.");

                                // execute the menu item
                                contextMenu.ExecuteMenuItem(
                                    Core.Console.ViewPane.Strings.AdministrationContextMenuDelete);
                            }
                            else
                            {
                                // the context menu was still not active
                                throw new MauiException(
                                    "Unable to get active context menu item on retry:  '" +
                                    Core.Console.ViewPane.Strings.AdministrationContextMenuDelete +
                                    "'");
                            }
                        }
                        else
                        {
                            // the grid row returned was null
                            throw new NullReferenceException(
                                "Failed to find agent in the grid view on retry!  " +
                                agentComputer);
                        }
                    }
                }
                else
                {
                    // failed to find the "Delete" context menu item
                    throw new NullReferenceException(
                        "Unable to find context menu item:  '" +
                        Core.Console.ViewPane.Strings.AdministrationContextMenuDelete +
                        "'");
                }

                // find wizard window
                CoreManager.MomConsole.ConfirmChoiceDialog(
                        MomConsoleApp.ButtonCaption.Yes,
                        Core.Console.DeviceDiscovery.PendingActionsViewHelper.Strings.ConfirmDeleteMonitoringAgentDialogTitle,
                        Maui.Core.Utilities.StringMatchSyntax.ExactMatch,
                        MomConsoleApp.ActionIfWindowNotFound.Error);
            }
            else
            {
                throw new System.ArgumentException(
                    "The value for agentComputer cannot be null or empty-string, value:  '" +
                    agentComputer + "'");
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to determine if the action account of the MOM server is running 
        /// as 'LocalSystem' the discovery query.
        /// </summary>
        /// <param name="rootMomSdkServer">
        /// The MOM Server that is hosting the root SDK service for the group</param>
        /// <param name="momServer">The MOM Server running the discovery query</param>
        /// -----------------------------------------------------------------------------
        private static bool UseOtherActionAccountType(string rootMomSdkServer, string momServer)
        {
            bool returnValue = false;

            #region Get Root SDK Server

            Core.Common.Utilities.LogMessage(
                "DeviceDiscovery::UseOtherActionAccountType::Checking for root SDK Server...");

            // validate the root MOM SDK Server parameter
            if (null == rootMomSdkServer || 0 == rootMomSdkServer.Length)
            {
                //if (ProductSku.Sku == ProductSkuLevel.Mom)
                Core.Common.Utilities.LogMessage(
                    "DeviceDiscovery::UseOtherActionAccountType::" +
                    "Getting root SDK server from Topology...");

                // get the root MOM SDK Server from the current topology
                rootMomSdkServer = Core.Common.Topology.RootMomSdkServerName;

                // check the result
                if (null == rootMomSdkServer || 0 == rootMomSdkServer.Length)
                {
                    throw new ArgumentNullException("Failed to get the root MOM SDK Server from Topology!");
                }
            }

            #endregion

            #region Get MOM Server for Discovery Task

            // validate the MOM Server name
            if (null == momServer || 0 == momServer.Length)
            {
                Core.Common.Utilities.LogMessage(
                        "DeviceDiscovery::UseOtherActionAccountType::" +
                        "Using root SDK server as discovery server...");

                // use the root server as the discovery server as well
                momServer = rootMomSdkServer;
            }

            #endregion

            #region Get 'Run As Accounts' From Management Group SDK

            // connect to the root SDK server
            Microsoft.EnterpriseManagement.ManagementGroup currentMomGroup =
                Core.Common.Utilities.ConnectToManagementServer(rootMomSdkServer);

            Core.Common.Utilities.LogMessage(
                "DeviceDiscovery::UseOtherActionAccountType::" + 
                "Getting the collection of 'Run As Accounts'...");

            // get the secure monitoring data
            System.Collections.Generic.IList<Microsoft.EnterpriseManagement.Security.SecureData> secureDataCollection =
                currentMomGroup.Security.GetSecureData();

            // get localized string for 'Action Account'
            string localizedActionAccount =
                Mom.Test.UI.Core.Console.ViewPane.Strings.AdministrationGridViewColumnActionAccount;

            Core.Common.Utilities.LogMessage(
                "DeviceDiscovery::UseOtherActionAccountType::" + 
                "Looking for the '" +
                localizedActionAccount +
                " - " +
                momServer + "'...");

            #endregion

            // iterate the collection for the action account on the current mom server
            foreach (Microsoft.EnterpriseManagement.Security.SecureData secureDataItem in secureDataCollection)
            {
                #region Process 'Run As Account' objects

                Core.Common.Utilities.LogMessage(
                    "DeviceDiscovery::UseOtherActionAccountType::" + 
                    "Checking Run As Account:  '" +
                    secureDataItem.Name +
                    "'");

                // check the description for 'Action Account' and MOM Server name
                if (secureDataItem.Name.ToLowerInvariant().Contains(localizedActionAccount.ToLowerInvariant()) &&
                    secureDataItem.Name.ToLowerInvariant().Contains(momServer.ToLowerInvariant()))
                {
                    #region Check for 'LocalSystem' Windows Credentials

                    Core.Common.Utilities.LogMessage(
                        "DeviceDiscovery::UseOtherActionAccountType::" + 
                        "Found the action account for the MOM server");

                    Core.Common.Utilities.LogMessage(
                        "DeviceDiscovery::UseOtherActionAccountType::" + 
                        "Checking for 'LocalSystem'...");

                    // if account is a system account, e.g. 'LocalSystem'
                    if (secureDataItem.IsSystem)
                    {
                        Core.Common.Utilities.LogMessage(
                        "DeviceDiscovery::UseOtherActionAccountType::" + 
                        "MOM Server Action Account set to 'LocalSystem'!");

                        // set return value to true
                        returnValue = true;
                    }

                    // stop searching
                    break;

                    #endregion
                }

                #endregion
            }

            // return flag
            return returnValue;
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to configure the SNMP Trap Service for the specified device,
        /// and proxy.
        /// </summary>
        /// <param name="snmpAgent">name of the agent computer</param>
        /// <param name="proxyServer">name of the MOM Server/Agent that will proxy for the agent</param>
        /// -----------------------------------------------------------------------------
        private static void ConfigureAgentSnmp(string snmpAgent, string proxyServer)
        {
            Utilities.ConfigureAgentSnmp(snmpAgent, proxyServer, "public");
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to configure the SNMP Trap Service for the specified device,
        /// proxy and SNMP community.
        /// </summary>
        /// <param name="snmpAgent">name of the agent computer</param>
        /// <param name="proxyServer">name of the MOM Server/Agent that will proxy for the agent</param>
        /// <param name="communityString">name of the SNMP community</param>
        /// -----------------------------------------------------------------------------
        private static void ConfigureAgentSnmp(string snmpAgent, string proxyServer, string communityString)
        {
            #region Get MOM Server & Agent IP Addresses

            string snmpAgentIpAddress = null;
            string serverIpAddress = null;

            #region MOM Agent IPv4 Address

            // get the IP address of the target device
            Core.Common.Utilities.LogMessage(
                "ConfigureAgentSnmp::Getting MOM device IP addresses...");

            // get the list of IP addresses assigned to the device
            System.Net.IPAddress[] momDeviceIpAddresses =
                System.Net.Dns.GetHostEntry(snmpAgent).AddressList;

            // check for a list of valid, IP addresses
            if (null != momDeviceIpAddresses && 0 < momDeviceIpAddresses.Length)
            {
                // loop through the available addresses for IPv4 addresses only
                foreach (System.Net.IPAddress address in momDeviceIpAddresses)
                {
                    // look for an IPv4 address
                    if (System.Net.Sockets.AddressFamily.InterNetwork == address.AddressFamily)
                    {
                        // save this address
                        snmpAgentIpAddress = address.ToString();

                        Core.Common.Utilities.LogMessage(
                            "ConfigureAgentSnmp::MOM Device IPv4:  " +
                            snmpAgentIpAddress);

                        // exit the loop
                        break;
                    }
                }
            }
            else
            {
                throw new System.ArgumentOutOfRangeException(
                    "No IP addresses available for the current MOM device := '" +
                    snmpAgent +
                    "'");
            }

            #endregion
            
            #region MOM Server IPv4 Address

            // get current MOM server IP address
            Core.Common.Utilities.LogMessage(
                "ConfigureAgentSnmp::Getting MOM Server IP addresses...");

            // get the list of IP addresses assigned to the server
            System.Net.IPAddress[] momServerIpAddresses =
                System.Net.Dns.GetHostEntry(proxyServer).AddressList;

            // check for a list of valid, IP addresses
            if (null != momServerIpAddresses && 0 < momServerIpAddresses.Length)
            {
                // loop through the available addresses for IPv4 addresses only
                foreach (System.Net.IPAddress address in momServerIpAddresses)
                {
                    // look for an IPv4 address
                    if (System.Net.Sockets.AddressFamily.InterNetwork == address.AddressFamily)
                    {
                        // save this address
                        serverIpAddress = address.ToString();

                        Core.Common.Utilities.LogMessage(
                            "ConfigureAgentSnmp::MOM Server IPv4:  " +
                            serverIpAddress);
                        break;
                    }
                }
            }
            else
            {
                throw new System.ArgumentOutOfRangeException(
                    "No IP addresses available for the current MOM server := '" +
                    proxyServer +
                    "'");
            }

            #endregion

            #endregion

            #region Set SNMP Community Strings

            // check for null or emtpy community string
            if (null == communityString || 0 == communityString.Length)
            {
                communityString = "public";
            }

            // set default community string
            Core.Common.Utilities.LogMessage(
                "ConfigureAgentSnmp::Setting community string:  '" +
                communityString +
                "'");
            Microsoft.EnterpriseManagement.Test.BaseCommon.WinSnmpControl.SnmpCommunity defaultCommunity =
                new Microsoft.EnterpriseManagement.Test.BaseCommon.WinSnmpControl.SnmpCommunity(communityString);

            // set variation community string based on query account
            Core.Common.Utilities.LogMessage(
                "ConfigureAgentSnmp::Setting community string:  '" +
                communityString +
                "'");
            Microsoft.EnterpriseManagement.Test.BaseCommon.WinSnmpControl.SnmpCommunity testCommunity =
                new Microsoft.EnterpriseManagement.Test.BaseCommon.WinSnmpControl.SnmpCommunity(communityString);

            #endregion

            #region Configure Agent SNMP Trap Service

            // set up the target device
            Core.Common.Utilities.LogMessage(
                "ConfigureAgentSnmp::Getting SNMP config for '" +
                snmpAgent +
                "'");
            WinSnmpCtl agentSnmp =
                new WinSnmpCtl(snmpAgent);
            SnmpAgentCfg agentSnmpConfig = agentSnmp.GetConfig();

            // create a new trap configuration
            SnmpTrapConfig agentSnmpTrap =
                new SnmpTrapConfig(communityString);

            // add the MOM server as a trap destination
            agentSnmpTrap.AddDestination(serverIpAddress);

            // add the agent SNMP community strings
            agentSnmpConfig.AddSnmpCommunity(defaultCommunity);
            agentSnmpConfig.AddSnmpCommunity(testCommunity);

            // add the agent SNMP trap destination, i.e. MOM server
            agentSnmpConfig.AddTrapDestination(agentSnmpTrap);

            // add permitted managers:  MOM server, local host
            agentSnmpConfig.AddPermittedManager(serverIpAddress);
            agentSnmpConfig.AddPermittedManager("127.0.0.1");

            // add contact and location information
            agentSnmpConfig.SysContact = proxyServer;
            agentSnmpConfig.SysLocation = snmpAgent;

            #endregion

            // set the new SNMP configuration and restart SNMP service
            agentSnmp.SetConfig(agentSnmpConfig);
            agentSnmp.RestartSnmp();
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to turn off all grouping in the specified view
        /// </summary>
        /// <param name="viewName">
        /// The name of the view in the navigation pane
        /// </param>
        /// <history>
        ///     [KellyMor]  26JUL06 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static void TurnOffViewGrouping(string viewName)
        {
            // select the view
            CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(viewName).Select();
            Maui.Core.WinControls.TreeNode view = 
                CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(viewName);
            view.Click();

            // right-click in the view pane
            CoreManager.MomConsole.ViewPane.Extended.Click(
                MouseClickType.SingleClick,
                MouseFlags.RightButton);

            // get the context menu for personalizing the view
            Maui.Core.WinControls.Menu contextMenu =
                new Maui.Core.WinControls.Menu(
                    Core.Common.Constants.DefaultContextMenuTimeout);
            contextMenu.ExecuteMenuItem(
                Core.Console.Views.Dialogs.PersonalizeViewDialog.Strings.ContextMenuPersonalizeView);

            // find the personalization dialog, "Select Columns" window
            Core.Console.Views.Dialogs.PersonalizeViewDialog selectColumnsDialog =
                new Mom.Test.UI.Core.Console.Views.Dialogs.PersonalizeViewDialog(
                    CoreManager.MomConsole);

            if (true == selectColumnsDialog.Controls.GroupBy1ComboBox.IsEnabled)
            {
                // turn off all grouping by selecting "(None)"
                selectColumnsDialog.Controls.GroupBy1ComboBox.SelectByIndex(0);

                // commit the change
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(selectColumnsDialog.Controls.OKButton, Constants.OneMinute);
                selectColumnsDialog.ClickOK();
            }
            else
            {
                selectColumnsDialog.ClickCancel();
            }
        }

        #region
        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to get agent installed machine               
        /// </summary>
        /// <param name=""></param>
        /// <exception cref="System.ArgumentException">
        /// Throw System.ArgumentException if can not connect to Management Group 
        /// with specific MomServerName.
        /// </exception> 
        /// <returns>Return all agent installed machines</returns>
        /// <history>
        ///     [v-juli] 03FEB10 Created  
        /// </history>
        /// ------------------------------------------------------------------
        public static IList<AgentManagedComputer> GetAgentInstalledMachine()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Core.Common.Utilities.LogMessage(currentMethod + ":: Started...");

            try
            {
                ManagementGroup managementGroup = ManagementGroup.Connect(Core.Common.Utilities.MomServerName);
                ManagementGroupAdministration admin = managementGroup.GetAdministration();

                //Get all machines with agent installed.
                IList<AgentManagedComputer> agentComputers = admin.GetAllAgentManagedComputers();               

                if (agentComputers.Count > 0)
                {
                    Core.Common.Utilities.LogMessage(currentMethod + ":: Successfully get agent machine.");
                    return agentComputers;               
                }
                else
                {
                    Core.Common.Utilities.LogMessage(currentMethod + ":: There is no agent installed in this MOM management group.");
                    return null;                    
                }   
            }            
            catch (ArgumentException e)
            {
                throw new ArgumentException(currentMethod + "::" + String.Format("Failed to connect to MOM management group : {0}", Core.Common.Utilities.MomServerName), e);
            }           
        }

        #endregion // Public Static Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method IsAgentInstalled to check if the agent have been installed.
        /// </summary>
        /// <param name="deviceName">name of the agent computer</param>   
        /// <returns>True if successful, otherwise false</returns>
        /// <history>
        ///     [v-yoz]  O6AUG09 Created  
        /// </history>
        /// -----------------------------------------------------------------------------
        public static bool IsAgentInstalled(string deviceName)
        {
            return Utilities.IsAgentInstalled(
                deviceName,
                System.Environment.UserDomainName,
                DeviceType.WindowsComputer,
                ManagementMode.AgentManaged);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method IsAgentInstalled to check if the agent have been installed.
        /// </summary>
        /// <param name="deviceName">Name of the Windows computer</param>
        /// <param name="domainName">Name of the domain containing the Windows computer</param>
        /// <returns>True if successful, otherwise false</returns>
        /// <history>
        ///     [v-yoz]  O6AUG09 Created  
        /// </history>
        /// ------------------------------------------------------------------
        public static bool IsAgentInstalled(string deviceName, string domainName)
        {
            return Utilities.IsAgentInstalled(
                deviceName,
                domainName,
                DeviceType.WindowsComputer,
                ManagementMode.AgentManaged);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method IsAgentInstalled to check if the agent have been installed.
        /// </summary>
        /// <param name="deviceName">Name of the device</param>
        /// <param name="deviceType">Enumeration indicating the device type</param>
        /// <param name="managementMode">Enumeration indicating the management mode</param>
        /// <returns>True if successful, otherwise false</returns>
        /// <history>
        ///     [v-yoz]  O6AUG09 Created  
        /// </history>
        /// ------------------------------------------------------------------
        public static bool IsAgentInstalled(
            string deviceName,
            DeviceDiscovery.DeviceType deviceType,
            DeviceDiscovery.ManagementMode managementMode)
        {
            return Utilities.IsAgentInstalled(
                deviceName,
                System.Environment.UserDomainName,
                deviceType,
                managementMode);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method IsAgentInstalled to check if the agent have been installed.
        /// </summary>
        /// <param name="deviceName">Name of the device</param>
        /// <param name="domainName">Name of the domain containing the device</param>
        /// <param name="deviceType">Enumeration indicating the device type</param>
        /// <param name="managementMode">Enumeration indicating the management mode</param>
        /// <returns>True if successful, otherwise false</returns>
        /// <history>
        ///     [v-yoz]  O6AUG09 Created  
        /// </history>
        /// ------------------------------------------------------------------
        public static bool IsAgentInstalled(
            string deviceName,
            string domainName,
            DeviceDiscovery.DeviceType deviceType,
            DeviceDiscovery.ManagementMode managementMode)
        {
            Core.Common.Utilities.LogMessage("DeviceDiscovery::IsAgentInstalled...");

            #region Navigate to View

            // navigate to the appropriate view
            CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Administration);

            // select the view corresponding to device type and management mode
            string treeNodeName = null;
            if (deviceType == DeviceType.WindowsComputer)
            {
                // check management mode
                if (managementMode == ManagementMode.AgentManaged)
                {
                    treeNodeName = NavigationPane.Strings.AdminTreeViewAgentManagedComputers;
                }
                else
                {
                    treeNodeName = NavigationPane.Strings.AdminTreeViewAgentlessManagedComputers;
                }
            }
            else
            {
                treeNodeName = NavigationPane.Strings.AdminTreeViewNetworkDevices;
            }

            CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeName).Select();
            CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeName).Click();

            // turn off grouping
            Utilities.TurnOffViewGrouping(treeNodeName);

            // reselect the view
            CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeName).Select();
            CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.Find(treeNodeName).Click();

            #endregion // Navigate to View

            #region Check if the agent installed

            // set the key column name to match
            string keyColumnName = null;
            if (deviceType == DeviceType.WindowsComputer)
            {
                // use the "FQDN" column
                keyColumnName = ViewPane.Strings.AdministrationGridViewColumnFqdnName;
            }
            else
            {
                // use the "IP Address" column
                keyColumnName = ViewPane.Strings.AdministrationGridViewColumnIpAddress;
            }
            
            #region Find the Device

            // retry loop            
            const int MaxAttempts = 5;

            // get the grid row
            Maui.Core.WinControls.DataGridViewRow deviceDataGridViewRow = 
                CoreManager.MomConsole.ViewPane.Grid.FindData(
                    deviceName,
                    keyColumnName); 
                
            for (int currentAttempt = 1; 
                ((null == deviceDataGridViewRow) && (currentAttempt <= MaxAttempts)); 
                currentAttempt++)
            {
                // log the attempt
                Core.Common.Utilities.LogMessage(
                    "Attempt " +
                    currentAttempt +
                    " of " +
                    MaxAttempts);

                #region Refresh the grid view

                Maui.Core.Utilities.Sleeper.Delay(
                    Core.Common.Constants.DefaultContextMenuTimeout);

                // refresh the view just in case
                MomControls.GridControl viewPaneGrid = CoreManager.MomConsole.ViewPane.Grid;

                // left-click in the grid
                viewPaneGrid.Click();

                // right-click in the grid
                viewPaneGrid.Click(
                    MouseClickType.SingleClick,
                    MouseFlags.RightButton);

                // get the context menu
                Maui.Core.WinControls.Menu gridContextMenu =
                    new Menu(Core.Common.Constants.DefaultContextMenuTimeout);

                // execute the "Refresh" context menu item
                gridContextMenu.ExecuteMenuItem(
                    ViewPane.Strings.AdministrationContextMenuRefresh);

                #endregion

                // try to get the row again
                deviceDataGridViewRow = 
                    CoreManager.MomConsole.ViewPane.Grid.FindData(
                        deviceName,
                        keyColumnName);
            }

            #endregion

            // based on device type and management mode
            if (deviceDataGridViewRow != null)
            {
                Core.Common.Utilities.LogMessage("DeviceDiscovery::IsAgentInstalled:: The agent has been installed := " + deviceName);
                return true;
            }
            else
            {
                Core.Common.Utilities.LogMessage("DeviceDiscovery::IsAgentInstalled:: The agent has not been installed := " + deviceName);
                return false;
            }

            #endregion
        }        

        #endregion // Private Static Methods
    }
}