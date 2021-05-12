//-----------------------------------------------------------------------
// <copyright file="TraceScope.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Microsoft.ManagementPackCatalog.WebService
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// This class is used to define scope for trace logs
    /// </summary>  
    internal class TraceScope : IDisposable
    {
        /// <summary>
        /// This field stores the name of the scope
        /// </summary>
        private string scopeName;

        /// <summary>
        /// This field stores the event log 
        /// </summary>
        private ManagementPackCatalogEventLog eventLog;

        /// <summary>
        /// Initializes a new instance of the TraceScope class.
        /// </summary>
        /// <param name="name">The name of the scope</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")]
        public TraceScope(string name)
        {
            this.scopeName = name;
            this.LogInformation("Entering Scope");
            this.eventLog = new ManagementPackCatalogEventLog();            
        }

        /// <summary>
        /// Implements the IDisposable.Dispose method
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")]
        public void Dispose()
        {
            this.LogInformation("Leaving Scope");
            this.eventLog.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// This method is used to log error messages
        /// </summary>
        /// <param name="message">The error message to log</param>
        public void LogError(string message)
        {
            string detailedMessage = String.Format(System.Globalization.CultureInfo.InvariantCulture, "Scope : {0} Time : {1} , Thread Id : {2}, Message : {3} ", this.scopeName, System.Threading.Thread.CurrentThread.ManagedThreadId, DateTime.UtcNow, message);
            this.eventLog.LogEvent(detailedMessage);
            Trace.TraceError(detailedMessage);
        }

        /// <summary>
        /// This method is used to log warning messages
        /// </summary>
        /// <param name="message">The warning message to log</param>
        public void LogWarning(string message)
        {
            Trace.TraceWarning("Scope : {0} Time : {1} , Thread Id : {2}, Message : {3} ", this.scopeName, System.Threading.Thread.CurrentThread.ManagedThreadId, DateTime.UtcNow, message);
        }

        /// <summary>
        /// This method is used to log informational messages
        /// </summary>
        /// <param name="message">The informational message to log</param>
        public void LogInformation(string message)
        {
            Trace.TraceInformation("Scope : {0} Time : {1} , Thread Id : {2}, Message : {3} ", this.scopeName, System.Threading.Thread.CurrentThread.ManagedThreadId, DateTime.UtcNow, message);
        } 
    }
}
