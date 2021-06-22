//-----------------------------------------------------------------------
// <copyright file="CatalogVendor.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Admin.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class represents the vendor.
    /// </summary>
    public class CatalogVendor
    {
        /// <summary>
        /// This field stores the vendor id
        /// </summary>
        private int vendorId;

        /// <summary>
        /// This field stores vendor name
        /// </summary>
        private string vendorName;

        /// <summary>
        /// This field stores vendor link
        /// </summary>
        private string vendorLink;

        /// <summary>
        /// Gets or sets VendorId
        /// </summary>
        public int VendorId
        {
            get { return this.vendorId; }
            set { this.vendorId = value; }
        }

        /// <summary>
        /// Gets or sets vendor name
        /// </summary>
        public string VendorName
        {
            get { return this.vendorName; }
            set { this.vendorName = value; }
        }

        /// <summary>
        /// Gets or sets vendor link
        /// </summary>
        public string VendorLink
        {
            get { return this.vendorLink; }
            set { this.vendorLink = value; }
        }
    }
}
