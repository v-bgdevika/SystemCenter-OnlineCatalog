//-----------------------------------------------------------------------
// <copyright file="CatalogItemExtendedInfo.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class stores the extended info for Management Packs and Categories.
    /// </summary>
    public class CatalogItemExtendedInfo
    {
        /// <summary>
        /// This field stores the catalog item id
        /// </summary>
        private int catalogItemId;

        /// <summary>
        /// This field stores the description of the catalog item
        /// </summary>
        private string description;

        /// <summary>
        /// This field indicates whether the catalog item is published or not
        /// </summary>
        private bool publishedInd;

        /// <summary>
        /// Gets or sets the catalog item id
        /// </summary>
        public int CatalogItemId
        {
            get { return this.catalogItemId; }
            set { this.catalogItemId = value; }
        }

        /// <summary>
        /// Gets or sets the catalog item's description
        /// </summary>
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the catalog item is published or not
        /// </summary>
        public bool PublishedInd
        {
            get { return this.publishedInd; }
            set { this.publishedInd = value; }
        }
    }
}
