//-----------------------------------------------------------------------------
// <copyright file="EmailChannelParams.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains a class for containing email channel parameters.
// </summary>
// 
//  <history>
//  [KellyMor]  31-JUL-08   Created
//  [KellyMor]  07-AUG-08   Changed MessageImportance enum to 
//                          MessageImportanceLevels to fix a name conflict.
//  [KellyMor]  15-AUG-08   Added channel description field.
//  [KellyMor]  26-AUG-08   Added constructor that takes two strings as
//                          arguments:  primaryServer, returnAddress.
//  </history>
//-----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Channels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class to contain email channel parameters.
    /// </summary>
    public class EmailChannelParams
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
        /// An array of notification servers used by this email channel.
        /// </summary>
        private List<NotificationServer> notificationServers;

        /// <summary>
        /// The return email address used for email notifications.
        /// </summary>
        private string returnAddress;

        /// <summary>
        /// The retry inteval, in minutes, used in failover scenarios with more
        /// than one notification server.
        /// </summary>
        private int retryInterval = 5;

        /// <summary>
        /// Subject text for default email notification message.
        /// </summary>
        private string subjectText;

        /// <summary>
        /// Message body text for default email notification message.
        /// </summary>
        private string messageText;

        /// <summary>
        /// Email encoding used for default email notification message.  This
        /// encoding is used for both the subject and message body.
        /// </summary>
        private EmailEncodings encoding = EmailEncodings.UTF8;

        /// <summary>
        /// Flag indicating if subject encoding should be removed and sent
        /// without any encoding markers.
        /// </summary>
        private bool overrideSubjectEncoding = false;

        /// <summary>
        /// Message importance level.
        /// </summary>
        private MessageImportanceLevels messageImportance = 
            MessageImportanceLevels.Normal;

        /// <summary>
        /// Flag indicating if the channel should be enabled.
        /// </summary>
        private bool enabled = true;

        /// <summary>
        /// Flag indicating if the isBodyHtml is checked.
        /// </summary>
        private bool isBodyHtml;

        #endregion Private Members

        #region Public Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="primaryServer">
        /// A string containing the network name of the primary notification
        /// or e-mail server.
        /// </param>
        /// <param name="returnAddress">
        /// A string representing the return address for email notifications.
        /// </param>
        /// <param name="isBodyHtml">
        /// A boolean representing the Html body.
        /// </param>
        public EmailChannelParams(
            string primaryServer,
            string returnAddress,
            bool isBodyHtml = true)
        {
            // check for valid parameters
            if (String.IsNullOrEmpty(primaryServer))
            {
                throw new System.ArgumentNullException(
                    "Primary server parameter must not be null!");
            }

            if (String.IsNullOrEmpty(returnAddress))
            {
                throw new System.ArgumentNullException(
                    "Return address parameter must not be null or emtpy string!");
            }

            // create a default channel name
            this.channelName =
                "Default Email Message Channel - " +
                System.DateTime.Now.ToString();

            // create a new notification server instance
            NotificationServer mailServer =
                new NotificationServer(
                    primaryServer,
                    (int)NotificationServer.NetworkPorts.Smtp);

            // set the primary notification server
            this.notificationServers = new List<NotificationServer>();
            this.notificationServers.Add(mailServer);

            // set the return address
            this.returnAddress = returnAddress;

            // set description to empty string
            this.channelDescription = string.Empty;

            //set is body html 
            this.IsBodyHtml = isBodyHtml;
        }

        /// <summary>
        /// Constructor to create an e-mail channel using the specified primary
        /// e-mail server and return address.
        /// </summary>
        /// <param name="primaryServer">
        /// A NotificationServer instance that will act as the primary 
        /// notification server.
        /// </param>
        /// <param name="returnAddress">
        /// A string representing the return address for email notifications.
        /// </param>
        public EmailChannelParams(
            NotificationServer primaryServer, 
            string returnAddress)
        {
            // check for valid parameters
            if (null == primaryServer)
            {
                throw new System.ArgumentNullException(
                    "Primary server parameter must not be null!");
            }

            if (String.IsNullOrEmpty(returnAddress))
            {
                throw new System.ArgumentNullException(
                    "Return address parameter must not be null or emtpy string!");
            }

            // create a default channel name
            this.channelName = 
                "Default Email Message Channel - " + 
                System.DateTime.Now.ToString();

            // set the primary notification server
            this.notificationServers = new List<NotificationServer>();
            this.notificationServers.Add(primaryServer);

            // set the return address
            this.returnAddress = returnAddress;

            // set description to empty string
            this.channelDescription = string.Empty;
        }

        /// <summary>
        /// Constructor to create a named email message channel.
        /// </summary>
        /// <param name="primaryServer">
        /// A NotificationServer instance that will act as the primary 
        /// notification server.
        /// </param>
        /// <param name="returnAddress">
        /// A string representing the return address for email notifications.
        /// </param>
        /// <param name="channelName">
        /// A string containing the name of the channel.
        /// </param>
        /// <param name="isBodyHtml">
        /// A boolean representing the Html body.
        /// </param>
        public EmailChannelParams(
            NotificationServer primaryServer,
            string returnAddress,
            string channelName,
            bool isBodyHtml = true)
        {
            // check for valid parameters
            if (null == primaryServer)
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

            // set the primary notification server
            this.notificationServers = new List<NotificationServer>();
            this.notificationServers.Add(primaryServer);

            // set the return address
            this.returnAddress = returnAddress;

            // set description to empty string
            this.channelDescription = string.Empty;

            //set is body html 
            this.IsBodyHtml = isBodyHtml;
        }

        #endregion Public Constructors

        #region Public Enums

        /// <summary>
        /// Encoding schemes used to format email subject and message body
        /// text.
        /// </summary>
        public enum EmailEncodings
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

        /// <summary>
        /// Message importance levels
        /// </summary>
        public enum MessageImportanceLevels
        {
            /// <summary>
            /// Low importance
            /// </summary>
            Low = 0,

            /// <summary>
            /// Medium importance, same as normal, the default
            /// </summary>
            Medium,

            /// <summary>
            /// Normal importance, same as medium, the default
            /// </summary>
            Normal = Medium,

            /// <summary>
            /// High importance
            /// </summary>
            High
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
        /// email channel.  Note that, modifying this copy will NOT change
        /// the servers used by this email channel.  Use the public Add/Remove
        /// methods for this purpose.
        /// </summary>
        public List<NotificationServer> NotificationServers
        {
            get
            {
                List<NotificationServer> tempArray = null;

                // check for a valid array reference
                if (null != this.notificationServers)
                {
                    // verify there is at least one item in the array
                    if (0 < this.notificationServers.Count)
                    {
                        // copy the array to the temp array
                        tempArray = new List<NotificationServer>(this.notificationServers);
                    }
                }

                // return the temp array reference
                return tempArray;
            }
        }

        /// <summary>
        /// Gets/sets the return email address used for notification emails.
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
        /// Gets/sets the retry interval, in minutes, used in failover 
        /// scenarios where the primary email server is unavailable.
        /// The default value is 5 minutes.
        /// </summary>
        public int RetryInterval
        {
            get 
            { 
                return this.retryInterval; 
            }

            set 
            { 
                this.retryInterval = value; 
            }
        }

        /// <summary>
        /// Gets/sets subject text for default email notification message.
        /// The default subject text is composed of a set of System Center
        /// Operations Manager alert variables.  These can be retrieved via
        /// the SCOM SDK API.
        /// </summary>
        public string SubjectText
        {
            get 
            { 
                return this.subjectText; 
            }

            set 
            { 
                this.subjectText = value; 
            }
        }

        /// <summary>
        /// Gets/sets message body text for default email notification message.
        /// The default subject text is composed of a set of System Center
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
        /// Gets/sets email encoding used for default email notification 
        /// message.  This encoding is used for both the subject and message 
        /// body.
        /// The default value is UTF8.
        /// </summary>
        public EmailEncodings Encoding
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
        /// Gets/sets flag indicating if subject encoding should be removed 
        /// and sent without any encoding markers.
        /// </summary>
        public bool OverrideSubjectEncoding
        {
            get 
            { 
                return this.overrideSubjectEncoding; 
            }

            set 
            { 
                this.overrideSubjectEncoding = value; 
            }
        }

        /// <summary>
        /// Gets/sets message importance level.
        /// The default value is Medium/Normal.
        /// </summary>
        public MessageImportanceLevels MessageImportance
        {
            get 
            { 
                return this.messageImportance; 
            }

            set 
            { 
                this.messageImportance = value; 
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

        /// <summary>
        /// Gets/sets flag indicating if IsBodyHtml is checked.
        /// The default value is true.
        /// </summary>
        public bool IsBodyHtml
        {
            get
            {
                return this.isBodyHtml;
            }
            set
            {
                this.isBodyHtml = value;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Method to add a NotificationServer to the list of servers
        /// </summary>
        /// <param name="server">
        /// A NotificationServer instance
        /// </param>
        public void AddNotificationServer(NotificationServer server)
        {
            // check for valid parameter
            if (null != server)
            {
                // does the server already exist in the list
                if (false == this.HasNotificationServer(server))
                {
                    // add the server to the list
                    this.notificationServers.Add(server);
                }
            }
            else
            {
                throw new System.ArgumentNullException(
                   "The parameter cannot be null");
            }
        }  

        /// <summary>
        /// Method to remove the specified server from the list of 
        /// NotificationServers.
        /// </summary>
        /// <param name="server">
        /// A NotificationServer instance
        /// </param>
        public void RemoveNotificationServer(NotificationServer server)
        {
            // check for valid parameter
            if (null != server)
            {
                // does the server exist in the list
                if (true == this.HasNotificationServer(server))
                {
                    // remove the matching instance
                    this.notificationServers.RemoveAt(
                        this.IndexOfNotificationServer(server));
                }
            }
            else
            {
                throw new System.ArgumentNullException(
                   "The parameter cannot be null");
            }
        }

        /// <summary>
        /// Method to determine if the specifid server exists as part of the
        /// current list of notification servers.
        /// </summary>
        /// <param name="server">
        /// A NotificationServer instance
        /// </param>
        /// <returns>
        /// True if an instance of type NotificationServer exists in 
        /// the list of notification servers with the same properties.
        /// </returns>
        public bool HasNotificationServer(NotificationServer server)
        {
            bool foundMatchingServer = false;

            // check for valid parameter
            if (null != server)
            {
                // get the index of the server
                int indexOfServer = this.IndexOfNotificationServer(server);

                // set the flag value
                foundMatchingServer = indexOfServer > -1 ? true : false;

                return foundMatchingServer;
            }
            else
            {
                throw new System.ArgumentNullException(
                    "The parameter cannot be null");
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Method to return the index of the specified NotificationServer
        /// instance.
        /// </summary>
        /// <param name="server">
        /// A NotificationServer instance
        /// </param>
        /// <returns>
        /// An integer value of zero or greater if the instance exists in the
        /// current list, -1 if the instance does not exist in the list.
        /// </returns>
        private int IndexOfNotificationServer(NotificationServer server)
        {
            int indexOfMatchingServer = -1;
            NotificationServer currentServer = null;

            // yes, find the matching server
            for (int index = 0; index < this.notificationServers.Count; index++)
            {
                currentServer = this.notificationServers[index];

                // check for matching name
                if (currentServer.FullyQualifiedName.ToLowerInvariant().Equals(server.FullyQualifiedName.ToLowerInvariant()))
                {
                    // found matching name, check other properties
                    if (currentServer.PortNumber == server.PortNumber &&
                        currentServer.AuthenticationMethod == server.AuthenticationMethod &&
                        currentServer.TransportOption == server.TransportOption)
                    {
                        // found matching server
                        indexOfMatchingServer = index;
                        break;
                    }
                    else
                    {
                        // no matching name, skip to the next one
                        continue;
                    }
                }
            }

            // return the index
            return indexOfMatchingServer;
        }

        #endregion Private Methods
    }
}
