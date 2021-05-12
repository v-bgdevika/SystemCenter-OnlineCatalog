//-----------------------------------------------------------------------
// <copyright file="ManagementPackCatalogEventLog.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.WebService
{
    using System;
    using System.Configuration.Install;
    using System.Diagnostics;

    /// <summary>
    /// This class is used to write management pack catalog related events to the event log
    /// </summary>
    internal class ManagementPackCatalogEventLog : IDisposable
    {
        /// <summary>
        /// Event Log to write events to
        /// </summary>
        private EventLog log;

        /// <summary>
        /// Initializes a new instance of the ManagementPackCatalogEventLog class.
        /// </summary>
        public ManagementPackCatalogEventLog()
        {
            this.log = new EventLog();
            this.log.Source = "ManagementPackCatalogWebService";
            this.log.Log = "Application";
        }

        /// <summary>
        /// Implements IDisposable.Dispose()
        /// </summary>
        public void Dispose()
        {
            this.log.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// This method is used to write event logs
        /// </summary>
        /// <param name="eventMsg">The event message string</param>
        public void LogEvent(string eventMsg)
        {
            this.log.WriteEntry(eventMsg, EventLogEntryType.Error);
        }
    }
}
