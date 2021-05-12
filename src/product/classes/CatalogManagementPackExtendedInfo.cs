//-----------------------------------------------------------------------
// <copyright file="CatalogManagementPackExtendedInfo.cs" company="Microsoft Corporation">
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
    /// This class extends CatalogItemExtendedInfo to store extended information for management packs.
    /// It also includes the list of management packs that a managementpack depends on.
    /// </summary>
    public class CatalogManagementPackExtendedInfo : CatalogItemExtendedInfo
    {
        /// <summary>
        /// This field stores a list of management packs that this management pack depends on
        /// </summary>
        private Collection<CatalogManagementPack> dependsOn;

        /// <summary>
        /// This field stores the knowledge articles of the management pack
        /// </summary>
        private string knowledgeArticles;

        /// <summary>
        /// This field stores the special eula of the management pack
        /// </summary>
        private string eula;

        /// <summary>
        /// This field stores the management pack identity
        /// </summary>
        private CatalogManagementPackIdentity identity;

        /// <summary>
        /// Initializes a new instance of the CatalogManagementPackExtendedInfo class.
        /// </summary>
        public CatalogManagementPackExtendedInfo()
        {
            this.dependsOn = new Collection<CatalogManagementPack>();
            this.identity = new CatalogManagementPackIdentity();
        }

        /// <summary>
        /// Gets the list of dependent MPs
        /// </summary>
        public Collection<CatalogManagementPack> DependsOn
        {
            get { return this.dependsOn; }
        }

        /// <summary>
        /// Gets or sets the CatalogManagementPackIdentity of the management pack
        /// </summary>
        public CatalogManagementPackIdentity Identity
        {
            get { return this.identity; }
            set { this.identity = value; }
        }

        /// <summary>
        /// Gets or sets the knowlesge articles
        /// </summary>
        public string KnowledgeArticles
        {
            get { return this.knowledgeArticles; }
            set { this.knowledgeArticles = value; }
        }

        /// <summary>
        /// Gets or sets the special EULA
        /// </summary>
        public string Eula
        {
            get { return this.eula; }
            set { this.eula = value; }
        }
    }
}
