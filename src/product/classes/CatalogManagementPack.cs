//-----------------------------------------------------------------------
// <copyright file="CatalogManagementPack.cs" company="Microsoft Corporation">
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
    /// This class represents a ManagementPack.
    /// In addition to all fields it contains a list of categories that the management pack belongs to.
    /// </summary>
    public class CatalogManagementPack : CatalogItem
    {
        /// <summary>
        /// This field stores the identity of the management pack
        /// </summary>
        private CatalogManagementPackIdentity identity;

        /// <summary>
        /// This field stores the display name of the management pack
        /// </summary>
        private string displayName;

        /// <summary>
        /// This field stores the system name of the management pack
        /// </summary>
        private string systemName;

        /// <summary>
        /// This field stores the public key of the management pack
        /// </summary>
        private string publicKey;

        /// <summary>
        /// This field stores the vendor uri of the management pack (ie: Vendor name and link to vendor's website)
        /// </summary>
        private CatalogLink vendorUri;

        /// <summary>
        /// This field stores the link to the download url
        /// </summary>
        private string downloadLink;

        /// <summary>
        /// This field stores the release date of the management pack
        /// </summary>
        private DateTime releaseDate;

        /// <summary>
        /// This field stores the list of categories that the management pack belongs to
        /// </summary>
        private Collection<int> categories;

        /// <summary>
        /// This field stores the indicator to indicate whether the management pack requires a special EULA
        /// </summary>
        private bool eulaInd;

        /// <summary>
        /// This field stores the indicator to indicate whether the management pack requires a security warning before import.
        /// </summary>
        private bool securityInd;

        /// <summary>
        /// Initializes a new instance of the CatalogManagementPack class.
        /// </summary>
        public CatalogManagementPack()
        {
            this.categories = new Collection<int>();
        }

        /// <summary>
        /// Gets or sets the identity of the management pack
        /// </summary>
        public CatalogManagementPackIdentity Identity
        {
            get { return this.identity; }
            set { this.identity = value; }
        }

        /// <summary>
        /// Gets or sets the display name for the management pack
        /// </summary>
        public string DisplayName
        {
            get { return this.displayName; }
            set { this.displayName = value; }
        }

        /// <summary>
        /// Gets or sets the system name of the management pack
        /// </summary>
        public string SystemName
        {
            get { return this.systemName; }
            set { this.systemName = value; }
        }

        /// <summary>
        /// Gets or sets the public key of the management pack
        /// </summary>
        public string PublicKey
        {
            get { return this.publicKey; }
            set { this.publicKey = value; }
        }

        /// <summary>
        /// Gets or sets the vendor uri of the management pack
        /// </summary>
        public CatalogLink VendorUri
        {
            get { return this.vendorUri; }
            set { this.vendorUri = value; }
        }

        /// <summary>
        /// Gets or sets the download link of the management pack
        /// </summary>
        public string DownloadLink
        {
            get { return this.downloadLink; }
            set { this.downloadLink = value; }
        }

        /// <summary>
        /// Gets or sets the release date of the management pack
        /// </summary>
        public DateTime ReleaseDate
        {
            get { return this.releaseDate; }
            set { this.releaseDate = value; }
        }

        /// <summary>
        /// Gets the list of categories a management pack belongs to
        /// </summary>
        public Collection<int> Categories
        {
            get { return this.categories; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this management pack needs a special EULA for import or not
        /// </summary>
        public bool EulaInd
        {
            get { return this.eulaInd; }
            set { this.eulaInd = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this management pack needs a special security warning for import or not
        /// </summary>
        public bool SecurityInd
        {
            get { return this.securityInd; }
            set { this.securityInd = value; }
        }

    }
}
