//-----------------------------------------------------------------------
// <copyright file="CatalogItem.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is the base class for Categories and Management Packs.
    /// If the catalog is the tree structure of Categories and ManagementPacks,
    /// then this class is the TreeNode
    /// The CatalogItemId is mutually exclusive between Categories and ManagementPacks.
    /// </summary>
    [System.Xml.Serialization.XmlInclude(typeof(CatalogCategory))]
    public class CatalogItem
    {
        /// <summary>
        /// This field stores the catalog id of the item
        /// </summary>
        private int catalogItemId;

        /// <summary>
        /// This field indicates whether the item is a category or not
        /// </summary>
        private bool isCategory;

        /// <summary>
        /// This field indicates whether the item is a management pack or not
        /// </summary>
        private bool isManagementPack;

        /// <summary>
        /// This field indicates whether the item is published or not
        /// </summary>
        private bool publishedInd;

        /// <summary>
        /// Gets or sets CatalogItemId
        /// </summary>
        public int CatalogItemId
        {
            get { return this.catalogItemId; }
            set { this.catalogItemId = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the item is a category or not
        /// </summary>
        public bool IsCategory
        {
            get { return this.isCategory; }
            set { this.isCategory = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the item is a management pack or not
        /// </summary>
        public bool IsManagementPack
        {
            get { return this.isManagementPack; }
            set { this.isManagementPack = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the item is published or not
        /// </summary>
        public bool PublishedInd
        {
            get { return this.publishedInd; }
            set { this.publishedInd = value; }
        }
    }
}
