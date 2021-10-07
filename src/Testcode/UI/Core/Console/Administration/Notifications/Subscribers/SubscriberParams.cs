//-----------------------------------------------------------------------------
// <copyright file="SubscriberParams.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains a class for exposing Notification support functionality.
// </summary>
// 
//  <history>
//  [KellyMor]  04-AUG-08   Created
//  [KellyMor]  27-AUG-08   Added a Description field.
//                          Added AlwaysNotify boolean property based on the
//                          delivery schedule property, null == true.
//  [KellyMor]  27-SEP-08   Updated constructor to take a channel type.
//  [KellyMor]  29-SEP-08   Modified delivery schedule to use a list of
//                          ScheduleData items instead of a single item.
//  </history>
//-----------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscribers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class to contain subscriber parameters.
    /// </summary>
    public class SubscriberParams
    {
        #region Private Members

        /// <summary>
        /// Subscriber ID, usually the UPN (username@domain.tld) or 
        /// NetBIOS (DOMAIN\username) ID.
        /// </summary>
        private string subscriberId;

        /// <summary>
        /// Description of the subscriber.
        /// </summary>
        private string description;

        /// <summary>
        /// The delivery availability schedule for the subscriber.
        /// </summary>
        private List<ScheduleData> deliverySchedule;

        /// <summary>
        /// List of addresses to which the notification workflow should
        /// deliver notification messages for this subscriber.
        /// </summary>
        private List<SubscriberAddressParams> addresses;

        #endregion

        #region Public Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="subscriber">
        /// The name or ID of the subscriber.  This is usually a UPN 
        /// (username@domain.tld) or NetBIOS (DOMAIN\username) ID.
        /// </param>
        /// <param name="deliveryAddress">
        /// The default delivery address for this subscriber.
        /// </param>
        /// <param name="channelName">
        /// The name of the channel used to delivery notifications.
        /// </param>
        /// <param name="channelType">
        /// The type of the channel used to delivery notifications.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if subscriber, deliveryAddress, channelName are null or empty string.
        /// </exception>
        public SubscriberParams(
            string subscriber,
            string deliveryAddress,
            string channelName,
            string channelType)
        {
            // check for valid parameters
            if (String.IsNullOrEmpty(subscriber))
            {
                throw new System.ArgumentNullException(
                    "The subscriber name/ID must not be null or empty string!");
            }

            if (String.IsNullOrEmpty(deliveryAddress))
            {
                throw new System.ArgumentNullException(
                    "The delivery address must not  be null or empty string!");
            }

            if (String.IsNullOrEmpty(channelName))
            {
                throw new System.ArgumentNullException(
                    "The channel name must not  be null or empty string!");
            }

            // set values
            this.subscriberId = subscriber;

            // create the subscriber address parameters instance
            SubscriberAddressParams defaultDeliveryAddressParams =
                new SubscriberAddressParams(
                    subscriber + " - " + channelName,
                    channelName,
                    channelType,
                    deliveryAddress);

            // create the list of delivery addresses
            this.addresses = new List<SubscriberAddressParams>();

            // add the new delivery address to the list
            this.addresses.Add(defaultDeliveryAddressParams);

            // create the list of delivery Schedule
            this.deliverySchedule = new List<ScheduleData>();
        }

        /// <summary>
        /// Constructor to create a subscriber based on the specified name and
        /// subscriber address parameters.
        /// </summary>
        /// <param name="subscriber">
        /// The name or ID of the subscriber.  This is usually a UPN 
        /// (username@domain.tld) or NetBIOS (DOMAIN\username) ID.
        /// </param>
        /// <param name="deliveryAddress">
        /// The default delivery address for this subscriber.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if subscriber, deliveryAddress are null or empty string.
        /// </exception>
        public SubscriberParams(
            string subscriber,
            SubscriberAddressParams deliveryAddress)
        {
            // check for valid parameters
            if (String.IsNullOrEmpty(subscriber))
            {
                throw new System.ArgumentNullException(
                    "The subscriber name/ID must not  be null or empty string!");
            }

            if (null == deliveryAddress) 
            {
                throw new System.ArgumentNullException(
                    "The delivery address must not  be null!");
            }

            // set values
            this.subscriberId = subscriber;
            this.addresses = new List<SubscriberAddressParams>();
            this.addresses.Add(deliveryAddress);

            // create the list of delivery Schedule
            this.deliverySchedule = new List<ScheduleData>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets/sets the subscriber ID, usually the UPN (username@domain.tld) 
        /// or NetBIOS (DOMAIN\username) ID.
        /// </summary>
        public string SubscriberId
        {
            get 
            { 
                return this.subscriberId; 
            }

            set 
            { 
                this.subscriberId = value; 
            }
        }

        /// <summary>
        /// Gets/sets the subscriber description.
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
        /// Gets a flag indicating if a delivery schedule has been set.
        /// </summary>
        public bool AlwaysNotify
        {
            get
            {
                bool alwaysNotifyFlag = true;

                if (null != this.deliverySchedule &&
                    0 < this.deliverySchedule.Count)
                {
                    alwaysNotifyFlag = false;
                }

                return alwaysNotifyFlag;
            }
        }

        /// <summary>
        /// Gets/sets the notification delivery calendar list.  The list
        /// contains ScheduleData items that represent the options present on
        /// the "Specify Schedule Period" dialog.
        /// </summary>
        public List<ScheduleData> DeliverySchedule
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

        /// <summary>
        /// List of addresses to which the notification workflow should
        /// deliver notification messages for this subscriber.
        /// </summary>
        public List<SubscriberAddressParams> Addresses
        {
            get 
            {
                List<SubscriberAddressParams> tempArray = null;

                // check for a valid array reference
                if (null != this.addresses)
                {
                    // verify there is at least one item in the array
                    if (0 < this.addresses.Count)
                    {
                        // copy the array to the temp array
                        tempArray = new List<SubscriberAddressParams>(this.addresses);
                    }
                }

                // return the temp array reference
                return tempArray;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to add a SubscriberAddressParams to the list of addresses.
        /// </summary>
        /// <param name="address">
        /// The address to add to list of addresses.  An instance of a
        /// SubscriberAddressParams class.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if address is null or empty string.
        /// </exception>
        public void AddSubscriberAddress(SubscriberAddressParams address)
        {
            // check for valid parameter
            if (null != address)
            {
                // does the server already exist in the list
                if (false == this.HasSubscriberAddress(address))
                {
                    // add the server to the list
                    this.addresses.Add(address);
                }
            }
            else
            {
                throw new System.ArgumentNullException(
                   "The parameter cannot be null");
            }
        }

        /// <summary>
        /// Method to remove a SubscriberAddressParams from the list of 
        /// addresses.
        /// </summary>
        /// <param name="address">
        /// The address to remove from list of addresses.  An instance of a
        /// SubscriberAddressParams class.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if address is null or empty string.
        /// </exception>
        public void RemoveSubscriberAddress(SubscriberAddressParams address)
        {
            // check for valid parameter
            if (null != address)
            {
                // does the server exist in the list
                if (true == this.HasSubscriberAddress(address))
                {
                    // remove the matching instance
                    this.addresses.RemoveAt(
                        this.IndexOfSubscriberAddress(address));
                }
            }
            else
            {
                throw new System.ArgumentNullException(
                   "The parameter cannot be null");
            }
        }

        /// <summary>
        /// Method to determine if the specifid subscriber address exists as 
        /// part of the current list of subscriber addresses.
        /// </summary>
        /// <param name="address">
        /// The address to check for in the list of addresses.  An instance 
        /// of a SubscriberAddressParams class.
        /// </param>
        /// <returns>
        /// Flag indicating if the list contains the specified address.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if address is null or empty string.
        /// </exception>
        public bool HasSubscriberAddress(SubscriberAddressParams address)
        {
            bool foundMatchingAddress = false;

            // check for valid parameter
            if (null != address)
            {
                // get the index of the server
                int indexOfAddress = this.IndexOfSubscriberAddress(address);

                // set the flag value
                foundMatchingAddress = indexOfAddress > -1 ? true : false;

                return foundMatchingAddress;
            }
            else
            {
                throw new System.ArgumentNullException(
                    "The parameter cannot be null");
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method to return the index of the specified SubscriberAddressParams
        /// instance.
        /// </summary>
        /// <param name="address">
        /// A SubscriberAddressParams instance
        /// </param>
        /// <returns>
        /// An integer value of zero or greater if the instance exists in the
        /// current list, -1 if the instance does not exist in the list.
        /// </returns>
        private int IndexOfSubscriberAddress(SubscriberAddressParams address)
        {
            int indexOfMatchingAddress = -1;
            SubscriberAddressParams currentAddress = null;

            // yes, find the matching server
            for (int index = 0; index < this.addresses.Count; index++)
            {
                currentAddress = this.addresses[index];

                // check for matching name
                if (currentAddress.Name.ToLowerInvariant().Equals(address.Name.ToLowerInvariant()))
                {
                    // found matching name, check other properties
                    if (currentAddress.ChannelName == address.ChannelName &&
                        currentAddress.DeliveryAddress == address.DeliveryAddress)
                    {
                        // found matching server
                        indexOfMatchingAddress = index;
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
            return indexOfMatchingAddress;
        }

        #endregion Private Methods
    }
}
