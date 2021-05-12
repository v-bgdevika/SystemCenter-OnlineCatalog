//-----------------------------------------------------------------------
// <copyright file="TraceProvider.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.WebService
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// This singleton class is used to provide trace functionality to management pack catalog web service.
    /// </summary>
    public class TraceProvider
    {
        /// <summary>
        /// This field stores the trace switch that is read from web config file.
        /// </summary>
        private TraceSwitch traceSwitch;

        /// <summary>
        /// Prevents a default instance of the TraceProvider class from being created.
        /// </summary>
        private TraceProvider()
        {
            this.traceSwitch = new TraceSwitch("CatalogTraceSwitch", "The switch used to control trace data for Management Pack Catalog Web Service");
        }

        /// <summary>
        /// Gets a value indicating whether error traces are enabled or disabled.
        /// </summary>
        public bool TraceError 
        {
            get { return this.traceSwitch.TraceError; }
        }

        /// <summary>
        /// Gets a value indicating whether warning traces are enabled or disabled.
        /// </summary>
        public bool TraceWarning
        {
            get { return this.traceSwitch.TraceWarning; }
        }

        /// <summary>
        /// Gets a value indicating whether information traces are enabled or disabled.
        /// </summary>
        public bool TraceInfo
        {
            get { return this.traceSwitch.TraceInfo; }
        }

        /// <summary>
        /// The method used to retrieve an instance of the singleton TraceProvider class.
        /// </summary>
        /// <returns>An instance of the TraceProvider class.</returns>
        public static TraceProvider CreateInstance()
        {
            TraceProvider instance = null;

            if (instance == null)
            {
                instance = new TraceProvider();
            }

            return instance;
        }

        /// <summary>
        /// This method creates the trace scope
        /// </summary>
        /// <param name="scopeName">The name of the scope to trace.</param>
        /// <returns>The created scope</returns>
        internal static TraceScope CreateScope(string scopeName)
        {
            return new TraceScope(scopeName);
        }
    }
}
