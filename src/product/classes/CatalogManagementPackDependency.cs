//-----------------------------------------------------------------------
// <copyright file="CatalogManagementPackDependency.cs" company="Microsoft Corporation">
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
    /// This class is used to represent the dependencies a management pack has
    /// </summary>
    public class CatalogManagementPackDependency
    {
        /// <summary>
        /// This field stores the base management pack's identities
        /// </summary>
        private CatalogManagementPackIdentity baseManagementPack;

        /// <summary>
        /// This field stores the immidiate dependencies of the base management pack
        /// </summary>
        private Collection<CatalogManagementPackIdentity> dependsOnManagementPacks;

        /// <summary>
        /// Initializes a new instance of the CatalogManagementPackDependency class.
        /// </summary>
        public CatalogManagementPackDependency()
        {
            this.dependsOnManagementPacks = new Collection<CatalogManagementPackIdentity>();
        }

        /// <summary>
        /// Gets or sets the base management pack identity
        /// </summary>
        public CatalogManagementPackIdentity BaseManagementPack
        {
            get { return this.baseManagementPack; }
            set { this.baseManagementPack = value; }
        }

        /// <summary>
        /// Gets the list of management pack dependency identities
        /// </summary>
        public Collection<CatalogManagementPackIdentity> DependsOnManagementPacks
        {
            get { return this.dependsOnManagementPacks; }
        }
    }
}
