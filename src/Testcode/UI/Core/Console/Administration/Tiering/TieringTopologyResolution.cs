// ----------------------------------------------------------------------------
// <copyright file="CommonChannel.cs" company="Microsoft">
//  Copyright (c) Microsoft Corporation 2008
// </copyright>
// 
// <summary>
// Class to implement common test methods for the channel tests.
// </summary>
// 
// <note>
// See the end of this source file for a detailed history
// </note>
// 
// <history>
// [v-johnx] 14-JU-2011 Created.
// </history>

namespace Mom.Test.UI.Core.Console.Administration.Tiering
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Mom.Test.UI.Core.Common;
    using Microsoft.EnterpriseManagement;
    using Microsoft.EnterpriseManagement.Configuration;
    using Microsoft.EnterpriseManagement.Test.FrmwrkCommon;
    using Maui.Core.Utilities;
    using Maui.Core;

    #endregion

    public class TieringTopologyResolution
    {
        /// <summary>
        /// resolute the topology information and cache
        /// provide Import MP by SDK
        /// provide connected Momconsole translation to current operation Momconsole
        /// </summary>

        #region private properties
        private static MomServerConnectionGroupInfo momServerConnectionGroupInfo;

        private Dialogs.ConnectToServerDialog connectToServerDialog;

        private static int retryTimes = 0;
        #endregion

        #region public static properties

        /// <summary>
        /// the connectToServerDialog with title connect to server
        /// </summary>
        public Dialogs.ConnectToServerDialog ConnectToServerDialog
        {
            get
            {
                if (null == connectToServerDialog)
                {
                    CoreManager.MomConsole.Waiters.WaitForWindowAppeared(CoreManager.MomConsole.MainWindow, new QID(Dialogs.ConnectToServerDialog.Strings.DialogTitle),Constants.OneSecond*10);
                    connectToServerDialog = new Dialogs.ConnectToServerDialog(CoreManager.MomConsole);
                }
                return connectToServerDialog;
            }
        }

        /// <summary>
        /// this properties cache the MomServers and managementGroup Info
        /// </summary>
        public static MomServerConnectionGroupInfo MomServerConnectionGroupInfo
        {
            get
            {
                while (retryTimes < Constants.DefaultMaxRetry)
                {
                    try
                    {
                        retryTimes++;
                        if (null == momServerConnectionGroupInfo)
                        {
                            //initialize the momServerConnectionGroupInfo
                            TieringTopology();
                            break;
                        }
                        else
                        {
                            return momServerConnectionGroupInfo;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (retryTimes < Constants.DefaultMaxRetry)
                        {
                            Utilities.LogMessage("retry to get MomServer Connection Group info:" + retryTimes);
                        }
                        else
                        {
                            ex.Data.Add("TieringTopology", "failed to resolute core.common.Topology");
                            throw ex;
                        }                       
                    }
                }
                return momServerConnectionGroupInfo;
            }
        }

        #endregion

        #region public Methods

        /// <summary>
        /// excute menu Tools|Connect... , fill group name and click connect
        /// throw windowNotFoundException if catch this type exception
        /// </summary>
        /// <param name="ManageGroupName">the manageServer name which connect to</param>
        public void ConnectToManagemntGroup(string ManagementServerName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            
            try
            {
                Utilities.LogMessage(currentMethod + ":: Excute Tools|connect...");
                Commands.ToolsConnect.Execute(CoreManager.MomConsole, Maui.Core.CommandMethod.Default);
                Utilities.LogMessage(currentMethod + ":: cache the ConnectToServerDalog window successfully");
                CoreManager.MomConsole.Waiters.WaitForWindowReady(ConnectToServerDialog, Constants.OneSecond * 5);
                //enter server name
                Utilities.LogMessage(currentMethod + ":: fill manage group name: " + ManagementServerName);
                ConnectToServerDialog.ServerNameText = ManagementServerName;
                //click connect button
                Utilities.LogMessage(currentMethod + ":: click connect button");
                ConnectToServerDialog.ClickConnect();
                CoreManager.MomConsole.Waiters.WaitForWindowClose(connectToServerDialog, Constants.OneSecond * 10);
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// handle the second Momconsole with caption by ExactMatch
        /// and Translate the connected MomConole to current operation Momconsole mainWindow
        /// </summary>
        /// <param name="momConsoleFullCaption">the caption of MomConsole which connect to, 
        /// if its value is null or empty, connnect to topology device by default 
        /// </param>
        public void TranslateToConnectedMomConsole(string momConsoleFullCaption)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            if (null == TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedManagementGroup)
                throw new Exception("there is no 2nd MG exist in topology, failed to translate MomConsole");

            if (string.IsNullOrEmpty(momConsoleFullCaption))
            {
                momConsoleFullCaption = TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedManagementGroupName + " - " +
                    Views.Views.Strings.MomDialogTitle;
            }
            Utilities.LogMessage(currentMethod + ":: executing connect to ManagementGroup");
            if (momConsoleFullCaption.Contains(TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedManagementGroupName))
                ConnectToManagemntGroup(TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedMomDevice);
            else
                ConnectToManagemntGroup(TieringTopologyResolution.MomServerConnectionGroupInfo.CurrentMomServer);
            //Minimize the first one MomConsole
            Utilities.LogMessage(currentMethod + ":: Minimize the first MomConsole");
            CoreManager.MomConsole.MainWindow.Extended.State = WindowState.Minimize;
            Utilities.LogMessage(currentMethod + ":: wait for the 2nd MomConsole loading");
            Window connectedConsole = new Window(momConsoleFullCaption, StringMatchSyntax.ExactMatch,"*",StringMatchSyntax.WildCard,CoreManager.MomConsole,Constants.OneMinute);
            UISynchronization.WaitForUIObjectReady(connectedConsole, Core.Common.Constants.DefaultDialogTimeout);
            Utilities.LogMessage(currentMethod + ":: bring the 2nd MomConsole to foreground");
            if (!connectedConsole.Extended.IsForeground)
                connectedConsole.Extended.ClickTitle();
            Utilities.LogMessage(currentMethod + ":: connected MomConsole caption is " + connectedConsole.Caption);
            Utilities.LogMessage(currentMethod + ":: translate the connected console to curernt MomConsole mainWindow");
            CoreManager.MomConsole.SetMainWindow(connectedConsole);
            Utilities.LogMessage(currentMethod + ":: complete");
        }

        /// <summary>
        /// analyzing the info of server and managementgroup in topoloy
        /// </summary>
        public static void TieringTopology()
        {
            TieringTopologyResolution.momServerConnectionGroupInfo = new Tiering.MomServerConnectionGroupInfo();
            SetCurrentMomServer();
            SetConnectedMomServer();
            SetManagementGroup(TieringTopologyResolution.MomServerConnectionGroupInfo.CurrentMomServer,
                TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedMomDevice);
            SetUserInfo();
        }

        /// <summary>
        /// import MP to ManagementGroup
        /// </summary>
        /// <param name="fullPathAndNameForTestMp">full path and name for importing MP</param>
        /// <param name="currentManagementgroup">current ManagementGroup,optinal parameter</param>
        /// <param name="connectedManagementgroup">connectedManagementGroup,optinal parameter</param>
        public void ImportMPToManagementGroup(string fullPathAndNameForTestMp,ManagementGroup currentManagementGroup=null,ManagementGroup connectedManagementGroup=null)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            if (null != currentManagementGroup)
            {             
                Utilities.LogMessage(string.Format(currentMethod + ":: Import {0} to Current Managementgroup {1}",
                    System.IO.Path.GetFileName(fullPathAndNameForTestMp), currentManagementGroup.Name));
                ImportTestMP(currentManagementGroup, fullPathAndNameForTestMp);
            }
            if (null != connectedManagementGroup)
            {
                Utilities.LogMessage(string.Format(currentMethod + ":: Import {0} to connected Managementgroup {1}",
                    System.IO.Path.GetFileName(fullPathAndNameForTestMp),connectedManagementGroup.Name));
                ImportTestMP(connectedManagementGroup, fullPathAndNameForTestMp);
            }          
        }

        /// <summary>
        /// Switch two console on a machine
        /// </summary>
        /// <param name="switchToManagementGroupName">the console Managementgroup Name</param>
        public void SwitchMomConsole(string switchToManagementGroupName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");
            bool switchToConnectedGroupConsole = false;
            if (!string.IsNullOrEmpty(switchToManagementGroupName))
            {
                if (string.Equals(switchToManagementGroupName, TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedManagementGroupName))
                {
                    switchToConnectedGroupConsole = true;
                }
                else if (string.Equals(switchToManagementGroupName, TieringTopologyResolution.MomServerConnectionGroupInfo.CurrentManagementGroupName))
                {
                    //Nothing to do.
                }
                else
                {
                    Utilities.LogMessage(currentMethod + ":: cannot find this console : " + switchToManagementGroupName);
                    return;
                }
            }
            else
            {
                Utilities.LogMessage(currentMethod+ ":: the parameter managementgroup name is null or empty");
                return;
            }
                       
            Window localConsole = new Window(TieringTopologyResolution.MomServerConnectionGroupInfo.CurrentManagementGroupName +
                " - " + Views.Views.Strings.MomDialogTitle, StringMatchSyntax.ExactMatch, "*", StringMatchSyntax.WildCard, 
                CoreManager.MomConsole, Constants.OneMinute);
            Window connectedConsole = new Window(TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedManagementGroupName +
                " - " + Views.Views.Strings.MomDialogTitle, StringMatchSyntax.ExactMatch, "*", StringMatchSyntax.WildCard,
                CoreManager.MomConsole, Constants.OneMinute);
            if (switchToConnectedGroupConsole)
            {
                Utilities.LogMessage(currentMethod + ":: Current MainWindow is " + localConsole.Caption);
                localConsole.Extended.State = WindowState.Minimize;
                if (connectedConsole.Extended.State != WindowState.Maximize)
                    connectedConsole.Extended.State = WindowState.Maximize;
                connectedConsole.Extended.ClickTitle();
                Utilities.LogMessage(currentMethod + ":: Switch to " + connectedConsole.Caption);
                CoreManager.MomConsole.SetMainWindow(connectedConsole);
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: Current MainWindow is " + localConsole.Caption);
                connectedConsole.Extended.State = WindowState.Minimize;
                if (localConsole.Extended.State != WindowState.Maximize)
                    localConsole.Extended.State = WindowState.Maximize;
                localConsole.Extended.ClickTitle();
                Utilities.LogMessage(currentMethod + ":: Switch to " + localConsole.Caption);
                CoreManager.MomConsole.SetMainWindow(localConsole);
            }
        }
        #endregion

        #region private method

        /// <summary>
        /// set current MomServer info
        /// </summary>
        private static void SetCurrentMomServer()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            // set current MOM server and device
            if (null != Core.Common.Topology.MomServersInfo)
            {
                Core.Common.Utilities.LogMessage(currentMethod +
                    "::Using MOM Test Topology data for MOM Servers...");

                if (1 == Core.Common.Topology.MomServersInfo.Count)
                {
                    // use the only MOM server
                    Microsoft.EnterpriseManagement.Test.ScCommon.Topology.MachineInfo momServer =
                        null;
                    momServer =
                        (Microsoft.EnterpriseManagement.Test.ScCommon.Topology.MachineInfo)Core.Common.Topology.MomServersInfo[0];
                    MomServerConnectionGroupInfo.CurrentMomServer = momServer.DNSMachineName;                    
                    Core.Common.Utilities.LogMessage(currentMethod +
                        "::Using MOM Server:  '" +
                        TieringTopologyResolution.MomServerConnectionGroupInfo.CurrentMomServer +
                        "'");
                    MomServerConnectionGroupInfo.RootMomSdkServer = momServer.DNSMachineName;
                    Core.Common.Utilities.LogMessage(currentMethod +
                        "::Root MOM SDK Server:  '" +
                        TieringTopologyResolution.MomServerConnectionGroupInfo.RootMomSdkServer +
                        "'");
                }
                else if (1 < Core.Common.Topology.MomServersInfo.Count)
                {
                    // use the current seed to randomly choose one
                    System.Random randomizer = new Random();
                    int randomMaxIndex =
                        Core.Common.Topology.MomServersInfo.Count - 1;
                    int randomIndex = randomizer.Next(0, randomMaxIndex);
                    // set the Mom Server
                    Microsoft.EnterpriseManagement.Test.ScCommon.Topology.MachineInfo momServer =
                        null;
                    momServer =
                        (Microsoft.EnterpriseManagement.Test.ScCommon.Topology.MachineInfo)Core.Common.Topology.MomServersInfo[randomIndex];
                    MomServerConnectionGroupInfo.CurrentMomServer = momServer.MachineName;
                    Core.Common.Utilities.LogMessage(currentMethod +
                        "::Using MOM Server:  '" +
                        MomServerConnectionGroupInfo.CurrentMomServer + "'");
                    // set the root MOM SDK server
                    TieringTopologyResolution.MomServerConnectionGroupInfo.RootMomSdkServer = Core.Common.Topology.RootMomSdkServerName;

                    Core.Common.Utilities.LogMessage( currentMethod +
                        "::Root MOM SDK Server:  '" +
                        TieringTopologyResolution.MomServerConnectionGroupInfo.RootMomSdkServer +
                        "'");
                }
                else
                {
                    throw new Exception(
                        "There must be at least one MOM server in the test topology!");
                }
            }
            else if (null != Core.Common.Topology.MomServers
                && 0 < Core.Common.Topology.MomServers.Length)
            {
                Core.Common.Utilities.LogMessage(currentMethod +
                    "::Using Command-line topology data for MOM Servers...");

                // if there is only one, use it
                if (1 == Core.Common.Topology.MomServers.Length)
                {
                    TieringTopologyResolution.MomServerConnectionGroupInfo.CurrentMomServer =
                        Core.Common.Topology.MomServers[0];

                    Core.Common.Utilities.LogMessage(currentMethod +
                        "::Using MOM Server:  '" +
                        TieringTopologyResolution.MomServerConnectionGroupInfo.CurrentMomServer +
                        "'");
                }
                else if (1 < Core.Common.Topology.MomServers.Length)
                {
                    // use the current seed to randomly choose one
                    System.Random randomizer = new Random();
                    int randomMaxIndex =
                        Core.Common.Topology.MomServers.Length - 1;
                    int randomIndex =
                        randomizer.Next(0, randomMaxIndex);

                    // set Mom Servers
                    TieringTopologyResolution.MomServerConnectionGroupInfo.CurrentMomServer =
                        Core.Common.Topology.MomServers[randomIndex];

                    Core.Common.Utilities.LogMessage(currentMethod +
                        "::Using MOM Server:  '" +
                        TieringTopologyResolution.MomServerConnectionGroupInfo.CurrentMomServer +
                        "'");
                }
                else
                {
                    throw new Exception("There must be at least one MOM server in the test topology!");
                }
            }
            else
            {
                throw new Exception("Failed to get a MOM server from the topology!");
            }
        }

        /// <summary>
        /// set connect MomServer info
        /// </summary>
        private static void SetConnectedMomServer()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            // set current MOM device and device
            if (null != Core.Common.Topology.MomDevicesInfo)
            {
                Core.Common.Utilities.LogMessage(currentMethod +
                    "::Using MOM Test Topology data for MOM Devices...");

                if (1 == Core.Common.Topology.MomDevicesInfo.Count)
                {
                    // use the only MOM Server
                    Microsoft.EnterpriseManagement.Test.ScCommon.Topology.MachineInfo momDevice =
                        null;
                    momDevice =
                        (Microsoft.EnterpriseManagement.Test.ScCommon.Topology.MachineInfo)Core.Common.Topology.MomDevicesInfo[0];
                    TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedMomDevice =
                        momDevice.NetBiosMachineName;

                    Core.Common.Utilities.LogMessage(currentMethod +
                        "::Using MOM Device:  '" +
                        TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedMomDevice +
                        "'");
                }
                else if (1 < Core.Common.Topology.MomDevicesInfo.Count)
                {
                    // random this connect MOM Server
                    System.Random randomizer =
                        new Random();
                    int randomMaxIndex =
                        Core.Common.Topology.MomDevicesInfo.Count - 1;
                    int randomIndex =
                        randomizer.Next(0, randomMaxIndex);

                    // just use the first one for now
                    Microsoft.EnterpriseManagement.Test.ScCommon.Topology.MachineInfo momDevice =
                        null;
                    momDevice =
                        (Microsoft.EnterpriseManagement.Test.ScCommon.Topology.MachineInfo)Core.Common.Topology.MomDevicesInfo[randomIndex];
                    TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedMomDevice =
                        momDevice.NetBiosMachineName;

                    Core.Common.Utilities.LogMessage(currentMethod +
                        "::Using MOM Device:  '" +
                        TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedMomDevice +
                        "'");
                }
                else
                {
                    throw new Exception(
                        "There must be at least one MOM agent in the test topology!");
                }
            }
            else if (null != Core.Common.Topology.MomDevices
                && 0 < Core.Common.Topology.MomDevices.Length)
            {
                Core.Common.Utilities.LogMessage(currentMethod +
                    "::Using Command-line topology data for MOM Devices...");

                // if there is only one, use it
                if (1 == Core.Common.Topology.MomDevices.Length)
                {
                    TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedMomDevice =
                        Core.Common.Topology.MomDevices[0];

                    Core.Common.Utilities.LogMessage(currentMethod +
                        "::Using MOM Device:  '" +
                        TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedMomDevice +
                        "'");
                }
                else if (1 < Core.Common.Topology.MomDevices.Length)
                {
                    // use the current seed to randomly choose one
                    System.Random randomizer = new Random();
                    int randomMaxIndex =
                        Core.Common.Topology.MomDevices.Length - 1;
                    int randomIndex =
                        randomizer.Next(0, randomMaxIndex);

                    // random the connect server
                    TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedMomDevice =
                        Core.Common.Topology.MomDevices[randomIndex];

                    Core.Common.Utilities.LogMessage(currentMethod +
                        "::Using MOM Device:  '" +
                        TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedMomDevice +
                        "'");
                }
                else
                {
                    throw new Exception(
                        "There must be at least one MOM agent in the test topology!");
                }
            }
            else
            {
                throw new Exception(
                    "Failed to get a MOM device from the topology!");
            }           
        }

        /// <summary>
        /// set managementgroup info
        /// </summary>
        /// <param name="currentMomServerName">current MomServer Name</param>
        /// <param name="connectMomServerName">connect</param>
        private static void SetManagementGroup(string currentMomServerName,string connectedMomServerName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Core.Common.Utilities.LogMessage(currentMethod +
                        "::Getting management group name...");
            Utilities.LogMessage("currentMomServerName: " + currentMomServerName);
            Utilities.LogMessage("connectedMomServerName: " + connectedMomServerName);
            // get current management group name 
            ManagementGroup currentManagementGroup = new ManagementGroup(currentMomServerName);
            if (currentManagementGroup != null)
            {
                TieringTopologyResolution.MomServerConnectionGroupInfo.CurrentManagementGroupName = currentManagementGroup.Name;
                TieringTopologyResolution.MomServerConnectionGroupInfo.CurrentManagementGroup = currentManagementGroup;
                Core.Common.Utilities.LogMessage(currentMethod +
                    "::Getting current management group name :=" +
                    TieringTopologyResolution.MomServerConnectionGroupInfo.CurrentManagementGroupName);
            }
            else
            {
                throw new Exception("Can not get current management group name, this test request 2 management group topology.");
            }

            // get connected management group name
            ManagementGroup connectedManagementGroup = null;
            try
            {
                Utilities.LogMessage("connectedMomServerName is : " + connectedMomServerName);
                connectedManagementGroup = new ManagementGroup(connectedMomServerName);
            }
            catch (Exception ex)
            {
                Utilities.LogMessage("cannot find the 2 MG in topology");
            }
            if (connectedManagementGroup != null)
            {
                TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedManagementGroupName = connectedManagementGroup.Name;
                TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedManagementGroup = connectedManagementGroup;
                Core.Common.Utilities.LogMessage(currentMethod +
                    "::Getting connected management group name :=" +
                    TieringTopologyResolution.MomServerConnectionGroupInfo.ConnectedManagementGroupName);
            }
            else
            {
                //Maybe this machine is agent but not server, it is required 2 management group topology
                Utilities.LogMessage("Can not get connected management group name, this test request 2 management group topology.");
            }
        }

        /// <summary>
        /// import TestMP
        /// </summary>
        /// <param name="managementGroup">ManagementGroup which UITestMP Import to</param>
        /// <param name="fullPathAndNameForTestMp">full path and name for TestMP</param>
        private void ImportTestMP(ManagementGroup managementGroup,string fullPathAndNameForTestMp)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string fileName = System.IO.Path.GetFileName(fullPathAndNameForTestMp);
            if (null != managementGroup)
            {
                //import UITestMP on connectManagementGroup
                if (managementGroup.Name != TieringTopologyResolution.MomServerConnectionGroupInfo.CurrentManagementGroupName)
                {
                    Core.Common.Utilities.LogMessage(currentMethod +
                        "::Importing "+ fileName +" to connected Management Group " + managementGroup.Name);
                    Utilities.LogMessage("MP path : " + fullPathAndNameForTestMp);
                    managementGroup.ManagementPacks.ImportManagementPack(new ManagementPack(fullPathAndNameForTestMp));
                    Utilities.LogMessage("Import complete");
                }
                else
                {                    
                    //import UITestMP on currentManagementGroup
                    if (false == Core.Common.Utilities.ManagementPackExists(fileName.Substring(0,fileName.LastIndexOf("."))))
                    {
                        Core.Common.Utilities.LogMessage(currentMethod +
                            "::Importing management pack:  '" +
                            fileName + "'" + "to Management Group" + managementGroup.Name);

                        // Import the UI Test MP
                        Core.Common.Utilities.ImportManagementPack(
                            fullPathAndNameForTestMp);
                        Utilities.LogMessage(currentMethod + ":: Import complete");
                        // Delay to allow system to settle
                        Maui.Core.Utilities.Sleeper.Delay(
                            Core.Common.Constants.DefaultDialogTimeout);
                    }
                    else
                    {
                        Core.Common.Utilities.LogMessage(currentMethod +
                            "::Skipping import...Management pack:  '" +
                            fileName +
                            "' " +
                            "already exists.");
                    }
                }
            }
        }

        /// <summary>
        /// set the connected managementgroup mechine user info
        /// </summary>
        private static void SetUserInfo()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: set User info");
            TieringTopologyResolution.MomServerConnectionGroupInfo.DomainUser =
                Core.Common.Utilities.UserDomainName +
                    Core.Common.Constants.PathDelimiter +
                    Core.Common.Utilities.UserName;
            TieringTopologyResolution.MomServerConnectionGroupInfo.Password =
                Core.Common.Utilities.GetDomainUserPassword(
                    Core.Common.Utilities.UserDomainName,
                    Core.Common.Utilities.UserName);
        }

        #endregion
    }


    public class MomServerConnectionGroupInfo
    {
        #region Private Static Members

        /// <summary>
        /// Root MOM server used by the current variation.
        /// </summary>
        private string rootMomSdkServer;

        /// <summary>
        /// MOM server used by the current variation.
        /// </summary>
        private string currentMomServer;

        /// <summary>
        /// Connected MOM server used by the current variation.
        /// </summary>
        private static string connectedMomDevice;

        /// <summary>
        /// The Domain user used by the current variation.
        /// </summary>
        private string domainUser;

        /// <summary>
        /// The Passowrd used by the current variation.
        /// </summary>
        private string password;

        /// <summary>
        /// the current management group name
        /// </summary>
        private string currentManagementGroupName;

        /// <summary>
        /// The name of management group which connect to
        /// </summary>
        private string connectedManagementGroupName;

        /// <summary>
        /// current Managementgroup
        /// </summary>
        private ManagementGroup currentManagementGroup;

        /// <summary>
        /// the connected ManagementGroup
        /// </summary>
        private ManagementGroup connectedManagementGroup;

        #endregion Private Static Members

        #region Public Static Properties

        /// <summary>
        /// Gets/Sets the Root MOM server used by the current variation.
        /// </summary>
        public string RootMomSdkServer
        {
            get
            {
                return rootMomSdkServer;
            }

            set
            {
                rootMomSdkServer = value;
            }
        }

        /// <summary>
        /// Gets/Sets the MOM server used by the current variation
        /// </summary>
        public string CurrentMomServer
        {
            get
            {
                return currentMomServer;
            }

            set
            {
                currentMomServer = value;
            }
        }

        /// <summary>
        /// Gets/Sets the MOM device used by the current variation.
        /// </summary>
        public string ConnectedMomDevice
        {
            get
            {
                return connectedMomDevice;
            }

            set
            {
               connectedMomDevice = value;
            }
        }

        /// <summary>
        /// Gets/Sets the domain user name used by the current variation
        /// </summary>
        public string DomainUser
        {
            get
            {
                return domainUser;
            }

            set
            {
                domainUser = value;
            }
        }

        /// <summary>
        /// Gets/Sets the password used by the current variation
        /// </summary>
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        /// <summary>
        /// Gets/Sets this current managementGroup Name value
        /// </summary>
        public string CurrentManagementGroupName
        {
            get
            {
                return currentManagementGroupName;
            }
            set
            {
                currentManagementGroupName = value;
            }
        }

        /// <summary>
        /// Gets/Sets this connected managementGroup Name value
        /// </summary>
        public string ConnectedManagementGroupName
        {
            get
            {
                return connectedManagementGroupName;
            }
            set
            {
                connectedManagementGroupName = value;
            }
        }

        /// <summary>
        /// Gets/Sets this connected managementGroup value
        /// </summary>
        public ManagementGroup ConnectedManagementGroup
        {
            get
            {
                return connectedManagementGroup;
            }
            set
            {
                connectedManagementGroup = value;
            }

        }

        /// <summary>
        /// Gets/Sets this currentManagementGroup
        /// </summary>
        public ManagementGroup CurrentManagementGroup
        {
            get
            {
                return currentManagementGroup;
            }
            set
            {
                currentManagementGroup = value;
            }
        }


        #endregion
    }
}
