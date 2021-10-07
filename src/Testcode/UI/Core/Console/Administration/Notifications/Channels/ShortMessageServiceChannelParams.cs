//-----------------------------------------------------------------------------
// <copyright file="ShortMessageServiceChannelParams.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains a class for containing short message service channel parameters.
// </summary>
// 
//  <history>
//  [KellyMor]  31-JUL-08   Created
//  [KellyMor]  15-AUG-08   Added channel description field.
//  </history>
//-----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Channels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class to contain short message service channel parameters.
    /// </summary>
    public class ShortMessageServiceChannelParams
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
        /// Message body text for default short message notification message.
        /// </summary>
        private string messageText;

        /// <summary>
        /// Encoding used for default short message notification message.  This
        /// encoding is used for the message body.
        /// </summary>
        private ShortMessageEncodings encoding = ShortMessageEncodings.US_ASCII;

        /// <summary>
        /// Flag indicating if the channel should be enabled.
        /// </summary>
        private bool enabled = true;

        #endregion Private Members

        #region Public Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ShortMessageServiceChannelParams()
        {
            this.channelName = "Default SMS Channel - " + System.DateTime.Now.ToString();

            this.channelDescription = string.Empty;
        }

        /// <summary>
        /// Channel name constructor.
        /// </summary>
        /// <param name="channelName">
        /// String containing the name of the channel.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if channel name is null or empty string.
        /// </exception>
        public ShortMessageServiceChannelParams(string channelName)
        {
            if (String.IsNullOrEmpty(channelName))
            {
                throw new System.ArgumentNullException("Channel name cannot be null or emtpy string!");
            }

            this.channelName = channelName;

            this.channelDescription = string.Empty;
        }

        #endregion Public Constructors

        #region Public Enums

        /// <summary>
        /// Encoding schemes used to format short message body
        /// text.
        /// </summary>
        public enum ShortMessageEncodings
        {
            /// <summary>
            /// US-ASCII encoding
            /// </summary>
            US_ASCII = 0,

            /// <summary>
            /// Unicode or UTF-16 encoding
            /// </summary>
            Unicode
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
        /// Gets/sets message body text for default short message service
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
        /// Gets/sets instant message encoding used for default short 
        /// message notification message.  This encoding is used for the 
        /// message body.
        /// The default value is UTF8.
        /// </summary>
        public ShortMessageEncodings Encoding
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
