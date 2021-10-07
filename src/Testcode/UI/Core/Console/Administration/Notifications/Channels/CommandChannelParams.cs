//-----------------------------------------------------------------------------
// <copyright file="CommandChannelParams.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains a class for containing command channel parameters.
// </summary>
// 
//  <history>
//  [KellyMor]  31-JUL-08   Created
//  [KellyMor]  15-AUG-08   Renamed Description field to ChannelDescription.
//  [KellyMor]  26-AUG-08   Added constructor that takes a single string as an
//                          argument:  fullPathToFile.
//  </history>
//-----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Administration.Notifications.Channels
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    /// <summary>
    /// Class to contain command channel parameters.
    /// </summary>
    public class CommandChannelParams
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
        /// Full path to the command or executable.
        /// </summary>
        private string fullPathToFile;

        /// <summary>
        /// Parameters passed to the command or executable.
        /// </summary>
        private string parameters;

        /// <summary>
        /// Initial directory path.
        /// </summary>
        private string initialDirectory;

        /// <summary>
        /// Flag indicating if the channel should be enabled.
        /// </summary>
        private bool enabled = true;

        #endregion Private Members
        
        #region Public Constructors

        /// <summary>
        /// Default constructor.  The initial directory path is set based on
        /// the full path to the command or executable.  All other properties
        /// are set to the emtpy string.
        /// </summary>
        /// <param name="fullPathToFile">
        /// The full path to the command or executable.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if fullPathToFile is null or empty string.
        /// </exception>
        public CommandChannelParams(
            string fullPathToFile)
        {
            // validate parameters
            if (String.IsNullOrEmpty(fullPathToFile))
            {
                throw new System.ArgumentNullException(
                    "Full path to file and file name must not be null or emtpy string!");
            }

            // set full path to file
            this.fullPathToFile = fullPathToFile;

            // get the index of the last path delimiter
            int indexOfLastPathDelimiter =
                fullPathToFile.LastIndexOf(
                    Core.Common.Constants.PathDelimiter);

            // if there is at least one path delimiter from the end
            if (0 < indexOfLastPathDelimiter)
            {
                // set initial directory to path part of full path to file
                this.initialDirectory =
                    fullPathToFile.Substring(0, indexOfLastPathDelimiter);
            }
            else
            {
                throw new System.ArgumentException(
                    "Full path to file does not contain a valid path:  '" +
                    fullPathToFile +
                    "'");
            }

            // create a default channel name
            this.channelName =
                "Default Command Channel - " +
                System.DateTime.Now.ToString();

            // set parameters to UI example string as default value
            this.parameters = "-t";

            // set initialDirectory to example string as default value
            this.initialDirectory = "c:\\";

            // set description to UI empty string
            this.channelDescription = string.Empty;
        }

        /// <summary>
        /// Constructor to create a command channel instance using the 
        /// specified parameters.
        /// </summary>
        /// <param name="fullPathToFile">
        /// The full path to the command or executable.
        /// </param>
        /// <param name="parameters">
        /// Parameters passed to the command or executable.
        /// </param>
        /// <param name="initialDirectory">
        /// Initial directory path.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if fullPathToFile, parameters and initialDirectory are null or empty string.
        /// </exception>
        public CommandChannelParams(
            string fullPathToFile,
            string parameters,
            string initialDirectory)
        {
            if (String.IsNullOrEmpty(fullPathToFile))
            {
                throw new System.ArgumentNullException("Full path to file cannot be null or emtpy string!");
            }

            if (String.IsNullOrEmpty(parameters))
            {
                throw new System.ArgumentNullException("Parameters cannot be null or emtpy string!");
            }

            if (String.IsNullOrEmpty(initialDirectory))
            {
                throw new System.ArgumentNullException("Initial directory cannot be null or emtpy string!");
            }

            // create a default channel name
            this.channelName =
                "Default Command Channel - " +
                System.DateTime.Now.ToString();

            // set values            
            this.fullPathToFile = fullPathToFile;
            this.parameters = parameters;
            this.initialDirectory = initialDirectory;

            this.channelDescription = string.Empty;
        }

        /// <summary>
        /// Constructor to create a command channel instance using the 
        /// specified parameters.
        /// </summary>
        /// <param name="channelName">
        /// The name of the channel.
        /// </param>
        /// <param name="fullPathToFile">
        /// The full path to the command or executable.
        /// </param>
        /// <param name="parameters">
        /// Parameters passed to the command or executable.
        /// </param>
        /// <param name="initialDirectory">
        /// Initial directory path.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if channelName, fullPathToFile, parameters and initialDirectory are null or empty string.
        /// </exception> 
        public CommandChannelParams(
            string channelName,
            string fullPathToFile,
            string parameters,
            string initialDirectory)
        {
            // check for valid parameters
            if (String.IsNullOrEmpty(channelName))
            {
                throw new System.ArgumentNullException("Channel name cannot be null or emtpy string!");
            }

            if (String.IsNullOrEmpty(fullPathToFile))
            {
                throw new System.ArgumentNullException("Full path to file cannot be null or emtpy string!");
            }

            if (String.IsNullOrEmpty(parameters))
            {
                throw new System.ArgumentNullException("Parameters cannot be null or emtpy string!");
            }

            if (String.IsNullOrEmpty(initialDirectory))
            {
                throw new System.ArgumentNullException("Initial directory cannot be null or emtpy string!");
            }

            // set values
            this.channelName = channelName;
            this.fullPathToFile = fullPathToFile;
            this.parameters = parameters;
            this.initialDirectory = initialDirectory;

            this.channelDescription = string.Empty;
        }

        #endregion Public Constructors

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
        /// Gets/sets the channel description
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
        /// Gets/sets the full path to the command or executable.
        /// </summary>
        public string FullPathToFile
        {
            get 
            { 
                return this.fullPathToFile; 
            }

            set 
            { 
                this.fullPathToFile = value; 
            }
        }

        /// <summary>
        /// Gets/sets the parameters passed to the command or executable.
        /// </summary>
        public string Parameters
        {
            get 
            { 
                return this.parameters; 
            }

            set 
            { 
                this.parameters = value; 
            }
        }

        /// <summary>
        /// Gets/sets the initial directory path.
        /// </summary>
        public string InitialDirectory
        {
            get 
            { 
                return this.initialDirectory; 
            }

            set 
            { 
                this.initialDirectory = value; 
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
