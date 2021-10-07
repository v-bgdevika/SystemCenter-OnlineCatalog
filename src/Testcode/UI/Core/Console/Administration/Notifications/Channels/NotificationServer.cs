//-----------------------------------------------------------------------------
// <copyright file="NotificationServer.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains a class for containing notification server properties.
// </summary>
// 
//  <history>
//  [KellyMor]  31-JUL-08   Created
//  [KellyMor]  26-AUG-08   Added NetworkPorts enum for the default network
//                          ports for SMTP and SIP notification servers.
//  [KellyMor]  23-SEP-08   Added support for NetBIOS and DNS Domain names.
//  </history>
//-----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Channels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class to contain notification server properties.
    /// </summary>
    public class NotificationServer
    {
        #region Private Members

        /// <summary>
        /// The Fully Qualified Name of the server.  Note that, this may be an
        /// IP address as well as a Fully-Qualified Domain Name or FQDN.
        /// </summary>
        private string fullyQualifiedName;

        /// <summary>
        /// The NetBIOS name of the server.  This name is set using the first
        /// section of the Fully Qualified Name of the server.
        /// </summary>
        private string cachedNetBiosName;

        /// <summary>
        /// The DNS domain name of the server.  This name is set using the last
        /// sections of the Fully Qualified Name of the server.
        /// </summary>
        private string cachedDnsDomainName;

        /// <summary>
        /// The IP port number used by the server for network communication.
        /// </summary>
        private int portNumber;

        /// <summary>
        /// The authentication method used by the server for security.
        /// </summary>
        private AuthenticationMethods authenticationMethod;

        /// <summary>
        /// The network protocol transport used by the server.
        /// </summary>
        private TransportOptions transportOption;

        #endregion Private Members

        #region Public Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="fullyQualifiedName">
        /// The fully qualified name of the server.  Note that, this may be an
        /// IP address as well as a Fully-Qualified Domain Name or FQDN.
        /// </param>
        /// <param name="portNumber">
        /// The IP port number used by the server for network communication.
        /// </param>
        public NotificationServer(
            string fullyQualifiedName, 
            int portNumber)
        {
            // check for valid fully qualified name
            if (String.IsNullOrEmpty(fullyQualifiedName))
            {
                throw
                    new System.ArgumentNullException(
                        "The fully qualified name cannot be null or empty string!");
            }
            else
            {
                // check for presence of period character to ensure FQDN or IP
                if (false == fullyQualifiedName.Contains("."))
                {
                    throw
                        new System.ArgumentException(
                            "The parameter is not a Fully-Qualified Domain Name (FQDN) or IPv4 address!");
                }
            }

            // check for valid port number
            if (0 > portNumber || 65535 < portNumber)
            {
                throw 
                    new System.ArgumentOutOfRangeException(
                    "The port number must be in the range 0 to 65535!");
            }

            // set values
            this.fullyQualifiedName = fullyQualifiedName;
            this.portNumber = portNumber;

            // set default values
            this.authenticationMethod = AuthenticationMethods.Anonymous;
            this.transportOption = TransportOptions.Tcp;
        }

        /// <summary>
        /// NetBIOS and DNS Domain name constructor.
        /// </summary>
        /// <param name="netBiosName">
        /// The NetBIOS name of the notification server.
        /// </param>
        /// <param name="dnsDomainName">
        /// The DNS Domain name of the notification server.
        /// </param>
        /// <param name="portNumber">
        /// The network protocol transport used by the server.
        /// </param>
        public NotificationServer(
            string netBiosName,
            string dnsDomainName,
            int portNumber)
        {
            // check for valid NetBIOS name
            if (String.IsNullOrEmpty(netBiosName))
            {
                throw
                    new System.ArgumentNullException(
                        "The NetBIOS name cannot be null or empty string!");
            }

            // check for valid DNS domain name
            if (String.IsNullOrEmpty(dnsDomainName))
            {
                throw
                    new System.ArgumentNullException(
                        "The DNS domain name cannot be null or emtpy string!");
            }
            else
            {
                // check for presence of period character to ensure DNS domain name
                if (false == dnsDomainName.Contains("."))
                {
                    throw
                        new System.ArgumentException(
                            "The parameter is not a valid DNS Domain Name!");
                }
            }

            // check for valid port number
            if (0 > portNumber || 65535 < portNumber)
            {
                throw
                    new System.ArgumentOutOfRangeException(
                    "The port number must be in the range 0 to 65535!");
            }

            // cache the values
            this.cachedNetBiosName = netBiosName;
            this.cachedDnsDomainName = dnsDomainName;

            // set the fully qualified domain name
            this.fullyQualifiedName =
                this.cachedNetBiosName +
                "." +
                this.cachedDnsDomainName;

            // set the port number
            this.portNumber = portNumber;
        }

        /// <summary>
        /// Complete constructor.
        /// </summary>
        /// <param name="fullyQualifiedName">
        /// The fully qualified name of the server.  Note that, this may be an
        /// IP address as well as a Fully-Qualified Domain Name or FQDN.
        /// </param>
        /// <param name="portNumber">
        /// The IP port number used by the server for network communication.
        /// </param>
        /// <param name="authentication">
        /// The authentication method used by the server for security.
        /// </param>
        /// <param name="transport">
        /// The network protocol transport used by the server.
        /// </param>
        public NotificationServer(
            string fullyQualifiedName,
            int portNumber,
            AuthenticationMethods authentication,
            TransportOptions transport)
        {
            // check for valid fully qualified name
            if (String.IsNullOrEmpty(fullyQualifiedName))
            {
                throw
                    new System.ArgumentNullException(
                        "The fully qualified name cannot be null or empty string!");
            }
            else
            {
                // check for presence of period character to ensure FQDN or IP
                if (false == fullyQualifiedName.Contains("."))
                {
                    throw
                        new System.ArgumentException(
                            "The parameter is not a Fully-Qualified Domain Name (FQDN) or IPv4 address!");
                }
            }

            // check for valid port number
            if (0 > portNumber || 65535 < portNumber)
            {
                throw
                    new System.ArgumentOutOfRangeException(
                    "The port number must be in the range 0 to 65535!");
            }

            // set values
            this.fullyQualifiedName = fullyQualifiedName;
            this.portNumber = portNumber;
            this.authenticationMethod = authentication;
            this.transportOption = transport;
        }

        #endregion

        #region Public Enums

        /// <summary>
        /// Authentication method used by NotificationServers.  Note that,
        /// only one authentication method can be a supported by this type at
        /// one time.
        /// </summary>
        public enum AuthenticationMethods
        {
            /// <summary>
            /// Anonymous authentication.  This is the default value.
            /// </summary>
            Anonymous = 0,

            /// <summary>
            /// NT Lan Manager authentication.
            /// </summary>
            Ntlm,

            /// <summary>
            /// Windows integrated authentication.
            /// </summary>
            WindowsIntegrated,

            /// <summary>
            /// Kerberos authentication.
            /// </summary>
            Kerberos
        }

        /// <summary>
        /// Transport options used by NotificationServers.  Note that, only one
        /// transport option can be supported by this type at one time.
        /// </summary>
        public enum TransportOptions
        {
            /// <summary>
            /// Transmission Control Protocol, i.e. TCP
            /// </summary>
            Tcp = 0,

            /// <summary>
            /// Transport Layer Security, i.e. TLS
            /// </summary>
            Tls
        }

        /// <summary>
        /// Default port numbers used by various notification servers.
        /// </summary>
        public enum NetworkPorts
        {
            /// <summary>
            /// Default SMTP port number
            /// </summary>
            Smtp = 25,

            /// <summary>
            /// Default SIP over TCP port number
            /// </summary>
            TcpSip = 5060,

            /// <summary>
            /// Default SIP over TLS port number
            /// </summary>
            TlsSip = 5061
        }

        #endregion Public Enums

        #region Public Properties

        /// <summary>
        /// Gets/sets the Fully Qualified Name of the server.  Note that, this 
        /// may be an IP address as well as a Fully-Qualified Domain Name or 
        /// FQDN.
        /// </summary>
        public string FullyQualifiedName
        {
            get 
            { 
                return this.fullyQualifiedName; 
            }

            set 
            { 
                this.fullyQualifiedName = value; 
            }
        }

        /// <summary>
        /// Gets/sets the NetBIOS name of the server.
        /// </summary>
        public string NetBiosName
        {
            get
            {
                // check for a cached value
                if (null == this.cachedNetBiosName)
                {
                    // set the cached value to the FQDN prefix
                    this.cachedNetBiosName =
                        this.fullyQualifiedName.Substring(
                            0,
                            this.fullyQualifiedName.IndexOf('.'));
                }

                return this.cachedNetBiosName;
            }

            set
            {
                this.cachedNetBiosName = value;
            }
        }

        /// <summary>
        /// Gets/sets the DNS Domain name.
        /// </summary>
        public string DnsDomainName
        {
            get
            {
                if (null == this.cachedDnsDomainName)
                {
                    // get the index of the first character after the first dot
                    int startOfDnsDomainName =
                        this.fullyQualifiedName.IndexOf('.') + 1;

                    // compute the DNS domain name
                    this.cachedDnsDomainName =
                        this.fullyQualifiedName.Substring(
                            startOfDnsDomainName,
                            (this.fullyQualifiedName.Length - startOfDnsDomainName));
                }

                return this.cachedDnsDomainName;
            }

            set
            {
                this.cachedDnsDomainName = value;
            }
        }

        /// <summary>
        /// Gets/sets the IP port number used by the server for network 
        /// communication.
        /// </summary>
        public int PortNumber
        {
            get 
            { 
                return this.portNumber; 
            }

            set 
            { 
                this.portNumber = value; 
            }
        }

        /// <summary>
        /// Gets/sets the authentication method used by the server for 
        /// security.
        /// </summary>
        public AuthenticationMethods AuthenticationMethod
        {
            get 
            { 
                return this.authenticationMethod; 
            }

            set 
            { 
                this.authenticationMethod = value; 
            }
        }

        /// <summary>
        /// Gets/sets the network protocol transport used by the server.
        /// </summary>
        public TransportOptions TransportOption
        {
            get 
            { 
                return this.transportOption; 
            }

            set 
            { 
                this.transportOption = value; 
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Compares the specified object with this NotificationServer
        /// instance and compares all properties to determine if the objects
        /// are equivalent.
        /// </summary>
        /// <param name="obj">
        /// Object for comparison.
        /// </param>
        /// <returns>
        /// True if the objects are both of type NotificationServer and contain
        /// the exact same attributes.
        /// </returns>
        public override bool Equals(object obj)
        {
            bool returnValue = false;

            // check for matching class type
            if (true == (obj is NotificationServer))
            {
                NotificationServer otherServer = (NotificationServer)obj;
                string otherServerHashCode = 
                    ";" + 
                    otherServer.fullyQualifiedName + 
                    ";" + 
                    otherServer.portNumber +
                    ";" + 
                    otherServer.authenticationMethod + 
                    ";" + 
                    otherServer.transportOption;

                // create a hash based on all current attributes
                string thisServerHashCode = 
                    ";" + 
                    this.fullyQualifiedName + 
                    ";" + 
                    this.portNumber +
                    ";" + 
                    this.authenticationMethod + 
                    ";" + 
                    this.transportOption;

                // compare the hash codes
                returnValue = otherServerHashCode.Equals(thisServerHashCode);
            }

            return returnValue;
        }

        /// <summary>
        /// Default override of base method.
        /// </summary>
        /// <returns>
        /// An integer representing the hash code of the object.
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion Public Methods
    }
}
