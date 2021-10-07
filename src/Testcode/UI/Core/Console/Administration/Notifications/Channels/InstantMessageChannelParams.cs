//-----------------------------------------------------------------------------
// <copyright file="InstantMessageChannelParams.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains a class for containing instant message channel parameters.
// </summary>
// 
//  <history>
//  [KellyMor]  31-JUL-08   Created
//  [KellyMor]  15-AUG-08   Added channel description field.
//  [KellyMor]  26-AUG-08   Added constructor that takes two strings as
//                          arguments:  instantMessageServerNetworkName, and
//                          returnAddress.
//  </history>
//-----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Channels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class to contain instant message channel parameters.
    /// </summary>
    public class InstantMessageChannelParams
    {        
        #region Private Members
        
        /// <summary>
        /// The name of the channel.  Used for identification in the UI.
        /// </summary>
        private string channelName;

        /// <summary>
        /// The description of the channel.  Used for identification in the UI.
        /// </summary>
        private string channelDescription;

        /// <summary>
        /// An array of notification servers used by this instant message 
        /// channel.
        /// </summary>
        private NotificationServer notificationServer;

        /// <summary>
        /// The return instant message address used for email notifications.
        /// </summary>
        private string returnAddress;

        /// <summary>
        /// Message body text for default instant message notification message.
        /// </summary>
        private string messageText;

        /// <summary>
        /// Email encoding used for default instant message notification message.  
        /// This encoding is used for the message body.
        /// </summary>
        private InstantMessageEncodings encoding = InstantMessageEncodings.UTF8;

        /// <summary>
        /// Flag indicating if the channel should be enabled.
        /// </summary>
        private bool enabled = true;

        #endregion Private Members

        #region Public Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="instantMessageServerNetworkName">
        /// A string representing the network name of the instant messaging
        /// notification server.
        /// </param>
        /// <param name="returnAddress">
        /// A string representing the return address for instant message
        /// notifications.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if instantMessageServerNetworkName or returnAddress are null or empty string.
        /// </exception>
        public InstantMessageChannelParams(
            string instantMessageServerNetworkName,
            string returnAddress)
        {
            // check for valid parameters
            if (String.IsNullOrEmpty(instantMessageServerNetworkName))
            {
                throw new System.ArgumentNullException(
                    "Instant message server parameter cannot be null!");
            }

            if (String.IsNullOrEmpty(returnAddress))
            {
                throw new System.ArgumentNullException(
                    "Return address parameter cannot be null or emtpy string!");
            }

            // create a default channel name
            this.channelName = 
                "Default Instant Message Channel - " + 
                System.DateTime.Now.ToString();

            this.channelDescription = string.Empty;

            // set the primary notification server
            this.notificationServer = 
                new NotificationServer(
                instantMessageServerNetworkName,
                (int)NotificationServer.NetworkPorts.TcpSip);

            // set the return address
            this.returnAddress = returnAddress;            
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="instantMessageServer">
        /// A NotificationServer instance that will act as the only 
        /// notification server.
        /// </param>
        /// <param name="returnAddress">
        /// A string representing the return address for instant message
        /// notifications.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if instantMessageServer or returnAddress are null or empty string.
        /// </exception>
        public InstantMessageChannelParams(
            NotificationServer instantMessageServer, 
            string returnAddress)
        {
            // check for valid parameters
            if (null == instantMessageServer)
            {
                throw new System.ArgumentNullException(
                    "Primary server parameter cannot be null!");
            }

            if (String.IsNullOrEmpty(returnAddress))
            {
                throw new System.ArgumentNullException(
                    "Return address parameter cannot be null or emtpy string!");
            }

            // create a default channel name
            this.channelName = 
                "Default Instant Message Channel - " + 
                System.DateTime.Now.ToString();

            this.channelDescription = string.Empty;

            // set the primary notification server
            this.notificationServer = instantMessageServer;

            // set the return address
            this.returnAddress = returnAddress;
        }

        /// <summary>
        /// Constructor to create a named instant message channel.
        /// </summary>
        /// <param name="instantMessageServer">
        /// A NotificationServer instance that will act as the only 
        /// notification server.
        /// </param>
        /// <param name="returnAddress">
        /// A string representing the return address for instant message
        /// notifications.
        /// </param>
        /// <param name="channelName">
        /// A string containing the name of the channel.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if instantMessageServer or returnAddress or channelName are null or empty string.
        /// </exception>
        public InstantMessageChannelParams(
            NotificationServer instantMessageServer,
            string returnAddress,
            string channelName)
        {
            // check for valid parameters
            if (null == instantMessageServer)
            {
                throw new System.ArgumentNullException("Primary server parameter cannot be null!");
            }

            if (String.IsNullOrEmpty(returnAddress))
            {
                throw new System.ArgumentNullException("Return address parameter cannot be null or emtpy string!");
            }

            if (String.IsNullOrEmpty(channelName))
            {
                throw new System.ArgumentNullException("Channel name parameter cannot be null or emtpy string!");
            }

            // create a default channel name
            this.channelName = channelName;

            this.channelDescription = string.Empty;

            // set the primary notification server
            this.notificationServer = instantMessageServer;

            // set the return address
            this.returnAddress = returnAddress;
        }

        #endregion Public Constructors

        #region Public Enums

        /// <summary>
        /// Encoding schemes used to format instant message body
        /// text.
        /// </summary>
        public enum InstantMessageEncodings
        {
            /// <summary>
            /// UTF-8 encoding
            /// </summary>
            UTF8 = 0,

            /// <summary>
            /// US-ASCII encoding
            /// </summary>
            US_ASCII,

            /// <summary>
            /// UTF-16 encoding
            /// </summary>
            UTF16,

            /// <summary>
            /// UTF-7 encoding
            /// </summary>
            UTF7
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets/sets the channel name.
        /// </summary>
        public string ChannelName
        {
            get 
            { 
                return this.channelName; 
            }

            set 
            { 
                this.channelName = value; 
            }
        }

        /// <summary>
        /// Gets/sets the channel description.
        /// </summary>
        public string ChannelDescription
        {
            get
            {
                return this.channelDescription;
            }

            set
            {
                this.channelDescription = value;
            }
        }

        /// <summary>
        /// Returns a copy of the array of NotificationServers used by this
        /// instant message channel.
        /// </summary>
        public NotificationServer NotificationServer
        {
            get
            {
                return this.notificationServer;
            }

            set
            {
                this.notificationServer = value;
            }
        }

        /// <summary>
        /// Gets/sets the return instant message address used for 
        /// instant messages.
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
        /// Gets/sets message body text for default instant message 
        /// notification message.
        /// The default message text is composed of a set of System Center
        /// Operations Manager alert variables.  These can be retrieved via
        /// the SCOM SDK API.
        /// </summary>
        public string MessageText
        {
            get 
            { 
                return this.messageText; 
            }

            set 
            { 
                this.messageText = value; 
            }
        }

        /// <summary>
        /// Gets/sets instant message encoding used for default instant 
        /// message notification message.  This encoding is used for the 
        /// message body.
        /// The default value is UTF8.
        /// </summary>
        public InstantMessageEncodings Encoding
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

        /// <summary>
        /// Gets/sets flag indicating if the channel should be enabled.
        /// The default value is true.
        /// </summary>
        public bool Enabled
        {
            get 
            { 
                return this.enabled; 
            }

            set 
            { 
                this.enabled = value; 
            }
        }

        #endregion Public Properties
    }
}
