//-----------------------------------------------------------------------------
// <copyright file="SubscriberAddressParams.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains a class for exposing Subscriber Address support functionality.
// </summary>
// 
//  <history>
//  [KellyMor]  04-AUG-08   Created.
//  [KellyMor]  27-SEP-08   Added property for channel type.
//  </history>
//-----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscribers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    /// <summary>
    /// Class to contain Subscriber Address properties
    /// </summary>
    public class SubscriberAddressParams
    {
        #region Private Members

        /// <summary>
        /// The Name of the subscriber address, formerly known as a 
        /// notification device.
        /// </summary>
        private string name;

        /// <summary>
        /// The Description of the subscriber address, formerly known as a 
        /// notification device.
        /// </summary>
        private string description;

        /// <summary>
        /// The name of the channel used for this subsriber address.  This 
        /// connects the notification device to the channel or end-point
        /// for delivery.
        /// </summary>
        private string channelName;

        /// <summary>
        /// The type of the channel used for this subsriber address.
        /// </summary>
        private string channelType;

        /// <summary>
        /// The delivery address to which notification messages will be sent,
        /// this is usually an email address but can be a phone number for
        /// Short Message Services (SMS).
        /// </summary>
        private string deliveryAddress;

        /// <summary>
        /// The delivery availability schedule for the subscriber address or
        /// notification device.
        /// </summary>
        private ScheduleData deliverySchedule;

        #endregion Private Members

        #region Public Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="name">The name used to identify the channel.</param>
        /// <param name="channelName">
        /// The name of the channel that connects this subscriber address 
        /// instance to an instance of a channel or end-point for delivery of
        /// notification messages.
        /// </param>
        /// <param name="channelType">
        /// The type of the channel use by this subscriber address.
        /// </param>
        /// <param name="deliveryAddress">
        /// The delivery address to which notification messages will be sent,
        /// this is usually an email address but can be a phone number for
        /// Short Message Services (SMS).
        /// </param>
        public SubscriberAddressParams(
            string name,
            string channelName,
            string channelType,
            string deliveryAddress)
        {
            // check for valid parameters
            if (String.IsNullOrEmpty(name))
            {
                throw new System.ArgumentNullException("The name cannot be null or emtpy string!");
            }

            if (String.IsNullOrEmpty(channelName))
            {
                throw new System.ArgumentNullException("The channel name cannot be null or emtpy string!");
            }

            if (String.IsNullOrEmpty(channelType))
            {
                throw new System.ArgumentNullException("The channel type cannot be null or emtpy string!");
            }

            if (String.IsNullOrEmpty(deliveryAddress))
            {
                throw new System.ArgumentNullException("The delivery address cannot be null or emtpy string!");
            }

            // set values
            this.name = name;
            this.channelName = channelName;
            this.channelType = channelType;
            this.deliveryAddress = deliveryAddress;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// The Name of the subscriber address, formerly known as a 
        /// notification device.
        /// </summary>
        public string Name
        {
            get 
            { 
                return this.name; 
            }

            set 
            {
                this.name = value;
            }
        }

        /// <summary>
        /// The Description of the subscriber address, formerly known as a 
        /// notification device.
        /// </summary>
        public string Description
        {
            get 
            {
                return this.description;
            }

            set 
            {
                this.description = value;
            }
        }

        /// <summary>
        /// The name of the channel use for this subsriber address.  This 
        /// connects the notification device to the channel or end-point
        /// for delivery.
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
        /// The type of the channel use for this subsriber address.
        /// </summary>
        public string ChannelType
        {
            get
            {
                return this.channelType;
            }

            set
            {
                this.channelType = value;
            }
        }

        /// <summary>
        /// The delivery address to which notification messages will be sent,
        /// this is usually an email address but can be a phone number for
        /// Short Message Services (SMS).
        /// </summary>
        public string DeliveryAddress
        {
            get 
            {
                return this.deliveryAddress;
            }

            set 
            {
                this.deliveryAddress = value;
            }
        }

        /// <summary>
        /// The delivery availability schedule for the subscriber address or
        /// notification device.
        /// </summary>
        public ScheduleData DeliverySchedule
        {
            get 
            {
                return this.deliverySchedule;
            }

            set 
            {
                this.deliverySchedule = value;
            }
        }

        #endregion Public Properties
    }
}
