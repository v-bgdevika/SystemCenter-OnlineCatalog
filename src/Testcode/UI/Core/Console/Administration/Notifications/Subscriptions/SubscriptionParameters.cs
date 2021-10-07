//-----------------------------------------------------------------------------
// <copyright file="SubscriptionParameters.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains a class for exposing Notification support functionality.
// </summary>
// 
//  <history>
//  [KellyMor]  01-OCT-08   Created
//  [KellyMor]  11-OCT-08   Added Enabled property.
//                          StyleCop fixes.
//  </history>
//-----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Subscriptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class to contain subscription parameters.
    /// </summary>
    public class SubscriptionParameters
    {
        #region Private Members
        
        /// <summary>
        /// The name of the subscription.
        /// </summary>
        private string name;

        /// <summary>
        /// Description of the subscription.
        /// </summary>
        private string description;

        /// <summary>
        /// The list of subscribers.
        /// </summary>
        private List<Subscribers.SubscriberParams> subscribers;

        /// <summary>
        /// Contains a collection of name/value pairs for alert criteria.
        /// </summary>
        private Dictionary<string, string> alertCriteria;

        /// <summary>
        /// List of channel names for this subscription.
        /// </summary>
        private List<string> channelNames;

        /// <summary>
        /// Flag indicating if alert aging is used by the subscription.
        /// </summary>
        private bool useAlertAging;

        /// <summary>
        /// The alert age threshold.
        /// </summary>
        private int alertAgeThreshold = 10;

        /// <summary>
        /// Flag indicating if the subscription is enabled.
        /// </summary>
        private bool enabled = true;

        /// <summary>
        /// Alert source indicating which type alert will be generated
        /// </summary>
        private string alertSource;

        /// <summary>
        /// Alert source name indicating which source generated a alert
        /// </summary>
        private string alertSourceName;

        /// <summary>
        /// The start point in the UI for the test
        /// </summary>
        private string startPoint;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="name">
        /// The name of the subscription.
        /// </param>
        /// <param name="subscribers">
        /// The list of subscriber for this subscription that will receive
        /// notifications.
        /// </param>
        /// <param name="channelNames">
        /// The list of channel names used by this subscription to send
        /// notifications.
        /// </param>
        public SubscriptionParameters(
            string name,
            List<Subscribers.SubscriberParams> subscribers,
            List<string> channelNames)
        {
            // check for valid parameters
            if (string.IsNullOrEmpty(name))
            {
                throw new System.ArgumentNullException(
                    "Name parameter must not be null or emtpy string!");
            }

            if (null == subscribers || 0 == subscribers.Count)
            {
                throw new System.ArgumentNullException(
                    "List of subscribers must not be null or empty collection!");
            }

            if (null == channelNames || 0 == channelNames.Count)
            {
                throw new System.ArgumentNullException(
                    "List of channel names cannot be null or empty string!");
            }

            this.name = name;
            this.subscribers = subscribers;
            this.channelNames = channelNames;
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// Gets/sets the subscription name.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets/sets the subscription description.
        /// </summary>
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        /// <summary>
        /// Gets/sets the list of subscribers for this subscription
        /// </summary>
        public List<Subscribers.SubscriberParams> Subscribers
        {
            get { return this.subscribers; }
            set { this.subscribers = value; }
        }

        /// <summary>
        /// Gets/sets the collection of alert criteria name/value pairs.
        /// </summary>
        public Dictionary<string, string> AlertCriteria
        {
            get { return this.alertCriteria; }
            set { this.alertCriteria = value; }
        }

        /// <summary>
        /// Gets/sets the list of channels used by the subscription
        /// </summary>
        public List<string> ChannelNames
        {
            get { return this.channelNames; }
            set { this.channelNames = value; }
        }

        /// <summary>
        /// Gets/sets flag indicating if alert aging is used by the 
        /// subscription.
        /// </summary>
        public bool UseAlertAging
        {
            get { return this.useAlertAging; }
            set { this.useAlertAging = value; }
        }

        /// <summary>
        /// Gets/sets the alert age threshold.
        /// </summary>
        public int AlertAgeThreshold
        {
            get { return this.alertAgeThreshold; }
            set { this.alertAgeThreshold = value; }
        }

        /// <summary>
        /// Gets/sets flag indicating if the subscription enabled.
        /// </summary>
        public bool Enabled
        {
            get { return this.enabled; }
            set { this.enabled = value; }
        }

        /// <summary>
        /// Gets/sets the alert source.
        /// </summary>
        public string AlertSource
        {
            get { return this.alertSource; }
            set { this.alertSource = value; }
        }

        /// <summary>
        /// Gets/sets the alert source name.
        /// </summary>
        public string AlertSourceName
        {
            get { return this.alertSourceName; }
            set { this.alertSourceName = value; }
        }

        /// <summary>
        /// Gets/sets start point
        /// </summary>
        public string StartPoint
        {
            get { return this.startPoint; }
            set { this.startPoint = value; }
        }

        #endregion Public Properties
    }
}
