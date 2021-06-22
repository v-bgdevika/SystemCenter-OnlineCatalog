//-----------------------------------------------------------------------
// <copyright file="CatalogManagementPack.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Admin.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class represents the management pack.
    /// </summary>
    public class CatalogManagementPack
    {
        /// <summary>
        /// This field stores the management pack id
        /// </summary>
        private int managementPackId;

        /// <summary>
        /// This field stores display name
        /// </summary>
        private string displayName;

        /// <summary>
        /// This field stores version independent guid.
        /// </summary>
        private Guid versionIndependentGuid;

        /// <summary>
        /// This field stores the version.
        /// </summary>
        private Version version;

        /// <summary>
        /// This field stores the system name.
        /// </summary>
        private string systemName;

        /// <summary>
        /// This field stores the public key.
        /// </summary>
        private string publicKey;

        /// <summary>
        /// This field stores the release date.
        /// </summary>
        private DateTime releaseDate;

        /// <summary>
        /// This field stores the vendor id.
        /// </summary>
        private int vendorId;

        /// <summary>
        /// This field stores the download uri.
        /// </summary>
        private string downloadUri;

        /// <summary>
        /// This field indicates the existence of a special EULA.
        /// </summary>
        private bool eulaInd;

        /// <summary>
        /// This field stores the published indicator.
        /// </summary>
        private bool publishedInd;

        /// <summary>
        /// This field stores the security indicator.
        /// </summary>
        private bool securityInd;

        /// <summary>
        /// Gets or sets management pack id
        /// </summary>
        public int ManagementPackId
        {
            get { return this.managementPackId; }
            set { this.managementPackId = value; }
        }

        /// <summary>
        /// Gets or sets the display name
        /// </summary>
        public string DisplayName
        {
            get { return this.displayName; }
            set { this.displayName = value; }
        }

        /// <summary>
        /// Gets or sets the version independent guid.
        /// </summary>
        public Guid VersionIndependentGuid
        {
            get { return this.versionIndependentGuid; }
            set { this.versionIndependentGuid = value; }
        }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public Version Version
        {
            get { return this.version; }
            set { this.version = value; }
        }

        /// <summary>
        /// Gets or sets the system name.
        /// </summary>
        public string SystemName
        {
            get { return this.systemName; }
            set { this.systemName = value; }
        }

        /// <summary>
        /// Gets or sets the public key.
        /// </summary>
        public string PublicKey
        {
            get { return this.publicKey; }
            set { this.publicKey = value; }
        }

        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        public DateTime ReleaseDate
        {
            get { return this.releaseDate; }
            set { this.releaseDate = value; }
        }

        /// <summary>
        /// Gets or sets the VendorId
        /// </summary>
        public int VendorId
        {
            get { return this.vendorId; }
            set { this.vendorId = value; }
        }

        /// <summary>
        /// Gets or sets the download uri
        /// </summary>
        public string DownloadUri
        {
            get { return this.downloadUri; }
            set { this.downloadUri = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a special EULA is needed
        /// </summary>
        public bool EulaInd
        {
            get { return this.eulaInd; }
            set { this.eulaInd = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether MP is published or not
        /// </summary>
        public bool PublishedInd
        {
            get { return this.publishedInd; }
            set { this.publishedInd = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether MP needs a security warning or not
        /// </summary>
        public bool SecurityInd
        {
            get { return this.securityInd; }
            set { this.securityInd = value; }
        }
    }
}
