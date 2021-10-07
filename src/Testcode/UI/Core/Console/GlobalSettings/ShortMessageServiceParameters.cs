// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ShortMessageServiceParameters.cs">
// 	Copyright (c) Microsoft Corporation 2008
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[KellyMor] 19-Feb-08    Created
//  [KellyMor] 21-Feb-08    Modified MessageItems property to return null if no message
//                          message items have been set.
// </history>
// -----------------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.GlobalSettings
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class to contain short message service parameters used to drive
    /// test automation.
    /// </summary>
    public class ShortMessageServiceParameters
    {
        #region Private Members
        
        /// <summary>
        /// A list of message items used in the short message
        /// </summary>
        private IList<string> messageItems;

        /// <summary>
        /// String representing the encoding scheme used for short messages
        /// </summary>
        private string encoding;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ShortMessageServiceParameters()
        {
            // default constructor
            this.encoding = "Unicode (UTF-8)";
        }

        #endregion

        #region Public Properties

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

        #region Public Members

        /// <summary>
        /// Method to add a string to the collection of message items.
        /// </summary>
        /// <param name="messageItem">String matching the message item.</param>
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
