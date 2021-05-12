//-----------------------------------------------------------------------
// <copyright file="ManagementPackCatalogEventLogInstaller.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.WebService
{
    using System;
    using System.ComponentModel;
    using System.Configuration.Install;
    using System.Diagnostics;

    /// <summary>
    /// This class is used to install the management pack catalog event log source
    /// </summary>
    [RunInstaller(true)]
    public class ManagementPackCatalogEventLogInstaller : Installer
    {
        /// <summary>
        /// This field stores event log installer
        /// </summary>
        private EventLogInstaller managmentPackCatalogEventLogInstaller;

        /// <summary>
        /// Initializes a new instance of the ManagementPackCatalogEventLogInstaller class.
        /// </summary>
        public ManagementPackCatalogEventLogInstaller()
        {
            //// Create an instance of an EventLogInstaller.
            this.managmentPackCatalogEventLogInstaller = new EventLogInstaller();

            //// Set the source name of the event log.
            this.managmentPackCatalogEventLogInstaller.Source = "ManagementPackCatalogWebService";

            //// Set the event log that the source writes entries to.
            this.managmentPackCatalogEventLogInstaller.Log = "Application";

            //// Add myEventLogInstaller to the Installer collection.
            this.Installers.Add(this.managmentPackCatalogEventLogInstaller);
        }
    }
}
