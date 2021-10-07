// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="InstantMessageParameters.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[KellyMor] 12-Feb-08    Created
//  [KellyMor] 21-Feb-08    Modified MessageItems property to return null if no message
//                          message items have been set.
// </history>
// -----------------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.GlobalSettings
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Globalization;

    /// <summary>
    /// Class to contain instant message parameters for use by automation
    /// </summary>
    public class InstantMessageParameters
    {
        #region Private Members

        private string serverFqdn;

        private string returnAddress;

        private ProtocolOptions protocolOption;

        private AuthenticationMethods authenticationMethod;

        private int portNumber;

        private IList<string> messageItems;

        private string encoding;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public InstantMessageParameters()
        {
            // assign default values for parameters
            this.protocolOption = ProtocolOptions.TransmissionControl;
            this.portNumber = 5060;
            this.authenticationMethod = AuthenticationMethods.Ntlm;
            this.encoding = "Unicode (UTF-8)";
        }

        #endregion

        #region Enums

        /// <summary>
        /// Contains the options for network protocol communication
        /// </summary>
        public enum ProtocolOptions
        {
            /// <summary>
            /// Transmissioin control protocol, TCP
            /// </summary>
            TransmissionControl = 1,

            /// <summary>
            /// Transport layer security, TLS
            /// </summary>
            TransportLayerSecurity
        }

        /// <summary>
        /// Contains the authentication methods used to communicate with
        /// network security systems
        /// </summary>
        public enum AuthenticationMethods
        {
            /// <summary>
            /// NT/LanManager authentication
            /// </summary>
            Ntlm = 1,

            /// <summary>
            /// Kerberos certificates
            /// </summary>
            Kerberos
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets/sets the fully-qualified domain name of the instant messaging
        /// server.
        /// </summary>
        public string ServerFqdn
        {
            get
            {
                return this.serverFqdn;
            }

            set
            {
                this.serverFqdn = value;
            }
        }

        /// <summary>
        /// Gets/sets the return address of the account used to send a message
        /// to the instant messaging server.
        /// </summary>
        public string ReturnAddress
        {
            get
            {
                return this.returnAddress;
            }

            set
            {
                this.returnAddress = value;
            }
        }

        /// <summary>
        /// Gets/sets the protocol option used to communicate with the instant 
        /// messaging server.
        /// </summary>
        public ProtocolOptions ProtocolOption
        {
            get
            {
                return this.protocolOption;
            }

            set
            {
                this.protocolOption = value;
            }
        }

        /// <summary>
        /// Gets/sets the authentication method used to communicate with
        /// network security systems 
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
        /// Gets/sets the network port number used to communicate with
        /// the instant messaging server.
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
        /// Returns a collection of strings that make up the message elements.
        /// This can be a single string of text, multiple lines of text or
        /// one or more context data elements.
        /// 
        /// This collection is thread-safe, changes made to the collection
        /// returned by this property will not change or affect the original
        /// data contained in this class.
        /// </summary>
        public ICollection<string> MessageItems
        {
            get
            {
                if (null == this.messageItems)
                {
                    return null;
                }
                else
                {
                    return new List<string>(this.messageItems);
                }
            }
        }

        /// <summary>
        /// Gets/sets the encoding scheme used for the message text/elements.
        /// </summary>
        public string Encoding
        {
            get
            {
                return this.encoding;
            }

            set
            {
                this.encoding = value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to add a string to the collection of message items.
        /// </summary>
        /// <param name="messageItem"></param>
        public void AddMessageItem(string messageItem)
        {
            // check for valid message parameter
            if (string.IsNullOrEmpty(messageItem))
            {
                throw new ArgumentException(
                    "Message item cannot be null or emtpy string!");
            }

            // check for existing message item collection
            if (null == this.messageItems)
            {
                // create a new one if necessary
                this.messageItems = new List<string>();
            }

            // add the new item to the collection
            this.messageItems.Add(messageItem);
        }

        /// <summary>
        /// Method to remove the first instance of a string from the collection
        /// of message items.
        /// </summary>
        /// <param name="messageItem">String matching the message item.</param>
        /// <returns>True if successful or if item doesn't exist.</returns>
        public bool RemoveMessageItem(string messageItem)
        {
            // check for valid message parameter
            if (string.IsNullOrEmpty(messageItem))
            {
                throw new ArgumentException(
                    "Message item cannot be null or emtpy string!");
            }

            // check for existing message item collection
            if (null == this.messageItems)
            {
                // nothing to do
                return true;
            }
            else
            {
                // return the result of the remove method
                return this.messageItems.Remove(messageItem);
            }
        }

        /// <summary>
        /// Method to clear the collection of message items.
        /// </summary>
        public void ClearMessageItems()
        {
            // check for existing message item collection
            if (null != this.messageItems)
            {
                // clear the collection
                this.messageItems.Clear();
            }
        }

        #endregion
    }
}
