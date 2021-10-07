//-------------------------------------------------------------------
// <copyright file="Topology.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains a class for retrieving test topology information.
// </summary>
// 
//  <history>
//  [KellyMor]  20SEP05 Created
//  [KellyMor]  21SEP05 Fixed issue with string-based initializer and
//                      empty strings.
//  [mbickle]   12NOV05 Unified Logging messages.
//  [KellyMor]  15JUN06 Added a property for RootMomSdkServer
//  [faizalk]   05OCT06 Added a property for database
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Common
{
    #region Using directives
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Infra.Frmwrk;
    using Microsoft.EnterpriseManagement.Test.ScCommon;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;

    #endregion

    /// <summary>
    /// Class to encapsulate topology functionality
    /// </summary>
    public sealed class Topology
    {
        #region Private Static Members

        /// <summary>
        /// Reference to the current topology
        /// </summary>
        private static Microsoft.EnterpriseManagement.Test.ScCommon.Topology.MomDiscovery currentTopology = null;

        /// <summary>
        /// Array of available MOM servers
        /// </summary>
        private static string[] momServers = null;

        /// <summary>
        /// Array of available devices, e.g. Windows computers, SNMP devices, etc.
        /// </summary>
        private static string[] momDevices = null;

        /// <summary>
        /// Array of MachineInfo classes that hold topology data
        /// about the MOM servers, e.g. NetBIOS name, FQDN/DNS name, etc.
        /// </summary>
        private static System.Collections.ArrayList momServersInfo = null;

        /// <summary>
        /// Array of MachineInfo classes that hold topology data
        /// about the MOM agents, e.g. NetBIOS name, FQDN/DNS name, etc.
        /// </summary>
        private static System.Collections.ArrayList momDevicesInfo = null;

        /// <summary>
        /// The server that hosts the root SDK service
        /// </summary>
        private static string rootMomSdkServer;

        /// <summary>
        /// The server that hosts the OperationsManager database
        /// </summary>
        private static string database;

        #endregion // Private Static Members

        #region Public Static Properties

        /// <summary>
        /// Property to get/set the list of MOM Server names
        /// </summary>
        public static string[] MomServers
        {
            get
            {
                return Topology.momServers;
            }

            set
            {
                Topology.momServers = value;
            }
        }

        /// <summary>
        /// Property to get/set the list of MOM device names
        /// </summary>
        public static string[] MomDevices
        {
            get
            {
                return Topology.momDevices;
            }

            set
            {
                Topology.momDevices = value;
            }
        }

        /// <summary>
        /// Property to get/set the list of MOM Server MachineInfo objects
        /// </summary>
        public static System.Collections.ArrayList MomServersInfo
        {
            get
            {
                return Topology.momServersInfo;
            }

            set
            {
                Topology.momServersInfo = value;
            }
        }

        /// <summary>
        /// Property to get/set the list of MOM device MachineInfo objects
        /// </summary>
        public static System.Collections.ArrayList MomDevicesInfo
        {
            get
            {
                return Topology.momDevicesInfo;
            }

            set
            {
                Topology.momDevicesInfo = value;
            }
        }

        /// <summary>
        /// Property to get the name of the MOM server that hosts the root SDK service
        /// </summary>
        public static string RootMomSdkServerName
        {
            get
            {
                return Topology.rootMomSdkServer;
            }
        }

        /// <summary>
        /// Property to get the name of the MOM server that hosts the OperationsManager DB
        /// </summary>
        public static string Database
        {
            get
            {
                return Topology.database;
            }
        }

        #endregion // Public Properties

        #region Public Static Methods

        /// <summary>
        /// Class to initialize Topology object
        /// </summary>
        [Obsolete("Use Initialize()")]
        public static void Initialize(IContext ctx)
        {
            Initialize();
        }

        /// <summary>
        /// Method to get the topology information and publish the data
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Throws ArgumentNullException if context is null</exception>
        /// <exception cref="NullReferenceException">
        /// Throws NullReferenceException if it fails to retrieve topology data
        /// </exception>
        public static void Initialize()
        {
                
            Topology.currentTopology = TopologyHelper.TestTopology;
           

            if (Topology.currentTopology != null)
            {
                #region Get Topology from Test Mom Topology

                Utilities.LogMessage("Topology.Initialize:: Getting Mom Test Topology data...");

                // get the list of MOM servers
                Topology.MomServersInfo = Topology.currentTopology.ManagementServers;

                #region Filter MOM Servers From All Machines

                Utilities.LogMessage("Topology.Initialize:: Filtering MOM servers from list of all test machines...");

                // get all the machines in the test topology
                System.Collections.ArrayList momDevicesInfo = Topology.currentTopology.AllTestMachines;

                // create a new, empty array for agent/device candidates
                Topology.MomDevicesInfo = new System.Collections.ArrayList();

                // add machines to MOM devices, except MOM servers
                bool matchFound = false;
                foreach (MachineInfo momDevice in momDevicesInfo)
                {
                    foreach (MachineInfo momServer in Topology.MomServersInfo)
                    {
                        // see if two devices have the same AD name
                        if (momDevice.ADMachineName.CompareTo(momServer.ADMachineName) == 0)
                        {
                            // match found
                            matchFound = true;

                            // stop checking server names
                            break;
                        }
                    }

                    // check for a match
                    if (matchFound == true)
                    {
                        // reset the flag
                        matchFound = false;

                        // move to the next device
                        continue;
                    }
                    else
                    {
                        // no match found, add to list of discoverable devices
                        Topology.MomDevicesInfo.Add(momDevice);
                    }
                }
                #endregion // Filter MOM Servers From All Machines

                // set the root sdk server
                Topology.rootMomSdkServer = Topology.currentTopology.PreferedSDKServer;

                // set the database
                Topology.database = Topology.currentTopology.DB;

                #endregion // Get Topology from Test Mom Topology
            }
            else
            {
                throw new NullReferenceException("Topology.Initialize:: Failed to get MomDiscovery data!  Topology returned a null.");
            }
        }

        /// <summary>
        /// Method to get the topology information from the string passed
        /// as a parameter and publish the data
        /// </summary>
        /// <param name="topology">
        /// string containing a comma separate list of devices
        /// </param>
        public static void Initialize(string topology)
        {
            if (topology != null)
            {
                if (topology.Length > 0)
                {
                    #region Get Topology from Parameter

                    Utilities.LogMessage("Topology.Initialize:: Using Command-line parameters for topology data...");

                    string tempString = null;

                    #region Strip Quotes

                    // strip leading quotes
                    if (topology.IndexOf("\"") > -1)
                    {
                        tempString = topology.Substring(topology.IndexOf("\""));
                    }
                    else
                    {
                        tempString = topology;
                    }

                    // string trailing quotes
                    if (tempString.LastIndexOf("\"") > -1)
                    {
                        tempString = tempString.Substring(0, topology.LastIndexOf("\"") - 1);
                    }

                    #endregion // Strip Quotes

                    #region Parse Devices

                    // parse the computers list
                    string[] values = tempString.Split(',');
                    if (values.Length > 0)
                    {
                        // first item is typically the MOM Server
                        Topology.MomServers =
                            new string[] { values[0].ToUpperInvariant() };

                        // additional items are agent candidates or devices
                        if (values.Length > 1)
                        {
                            // create new array for agents minus the MOM Server
                            Topology.MomDevices = new string[values.Length - 1];

                            // copy agents to the array
                            Array.ConstrainedCopy(values, 1, Topology.MomDevices, 0, Topology.MomDevices.Length);
                        }
                    }

                    #endregion // Parse Devices

                    // log the options found
                    Utilities.LogMessage("Topology.Initialize:: Using MOM server:  '" + Topology.MomServers[0] + "'");
                    Utilities.LogMessage("Topology.Initialize:: Using Agent computer:  '" + Topology.MomDevices[0] + "'");

                    #endregion // Get Topology from Parameters
                }
                else
                {
                    Utilities.LogMessage("Topology.Initialize:: No topology information found in parameter!");
                }
            }
            else
            {
                throw new ArgumentNullException("Topology.Initialize:: Argument must not be null.");
            }
        }

        #endregion // Public Static Methods
    }
}
