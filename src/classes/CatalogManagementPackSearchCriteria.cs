//-----------------------------------------------------------------------
// <copyright file="CatalogManagementPackSearchCriteria.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    
    /// <summary>
    /// This class is used to represent the criterias that can be used to filter ManagementPacks.
    /// </summary>
    public class CatalogManagementPackSearchCriteria
    {
        /// <summary>
        /// This field stores the management pack name search pattern
        /// </summary>
        private string managementPackNamePattern;

        /// <summary>
        /// This field stores the management pack vendor name search pattern
        /// </summary>
        private string vendorNamePattern;

        /// <summary>
        /// This field is used to filter management packs based on release date.
        /// Only management packs released after this date are displayed to the customers.
        /// </summary>
        private DateTime releasedOnOrAfter;

        /// <summary>
        /// This field stores the list of installed management packs.
        /// Used only to check the updates available for a list of management packs installed on customer's machine.
        /// </summary>
        private Collection<CatalogManagementPackIdentity> installedManagementPacks;

        /// <summary>
        /// Initializes a new instance of the CatalogManagementPackSearchCriteria class.
        /// </summary>
        public CatalogManagementPackSearchCriteria()
        {
            this.installedManagementPacks = new Collection<CatalogManagementPackIdentity>();
        }

        /// <summary>
        /// Gets or sets the management pack name pattern
        /// </summary>
        public string ManagementPackNamePattern
        {
            get { return this.managementPackNamePattern; }
            set { this.managementPackNamePattern = value; }
        }

        /// <summary>
        /// Gets or sets the vendor name pattern
        /// </summary>
        public string VendorNamePattern
        {
            get { return this.vendorNamePattern; }
            set { this.vendorNamePattern = value; }
        }

        /// <summary>
        /// Gets or sets the released on or after date
        /// </summary>
        public DateTime ReleasedOnOrAfter
        {
            get { return this.releasedOnOrAfter; }
            set { this.releasedOnOrAfter = value; }
        }

        /// <summary>
        /// Gets the list of installed management packs
        /// </summary>
        public Collection<CatalogManagementPackIdentity> InstalledManagementPacks 
        {
            get { return this.installedManagementPacks; }
        }
    }
}
