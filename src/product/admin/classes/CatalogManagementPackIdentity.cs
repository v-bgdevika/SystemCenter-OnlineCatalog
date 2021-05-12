//-----------------------------------------------------------------------
// <copyright file="CatalogManagementPackIdentity.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Admin.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class stores information to uniquely identify an MP.
    /// </summary>
    public class CatalogManagementPackIdentity
    {
        /// <summary>
        /// This field stores the version independent Guid of the management pack
        /// </summary>
        private Guid versionIndependentGuid;

        /// <summary>
        /// This field stores the version of the management pack
        /// </summary>
        private string version;

        /// <summary>
        /// Gets or sets the version independent guid of the management pack
        /// </summary>
        public Guid VersionIndependentGuid
        {
            get { return this.versionIndependentGuid; }
            set { this.versionIndependentGuid = value; }
        }

        /// <summary>
        /// Gets or sets the version of the management pack
        /// </summary>
        public string Version
        {
            get { return this.version; }
            set { this.version = value; }
        }
    }
}
