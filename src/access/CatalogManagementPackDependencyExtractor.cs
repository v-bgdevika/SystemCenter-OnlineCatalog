//-----------------------------------------------------------------------
// <copyright file="CatalogManagementPackDependencyExtractor.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Access
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using Microsoft.ManagementPackCatalog.Classes;

    /// <summary>
    /// This class extracts CatalogManagementPackDependency from the SqlDataReader
    /// </summary>
    internal class CatalogManagementPackDependencyExtractor : CatalogClassExtractor
    {
        /// <summary>
        /// Stores the extracted result
        /// </summary>
        private Collection<CatalogManagementPackDependency> catalogManagementPackDependencyList;

        /// <summary>
        /// Gets the catalog management pack dependency list
        /// </summary>
        public Collection<CatalogManagementPackDependency> CatalogManagementPackDependencyList
        {
            get { return this.catalogManagementPackDependencyList; }
        }

        /// <summary>
        /// This method is used to extract a list of ManagementPackDependency object from SqlDataReader
        /// </summary>
        /// <param name="reader">Used to pass DB result</param>
        public override void Extract(SqlDataReader reader)
        {
            Dictionary<Guid, CatalogManagementPackDependency> deps = new Dictionary<Guid, CatalogManagementPackDependency>();

            while (reader.Read())
            {
                CatalogManagementPackIdentity baseMpIdentity = new CatalogManagementPackIdentity();
                CatalogManagementPackIdentity depMpIdentity = new CatalogManagementPackIdentity();

                baseMpIdentity.VersionIndependentGuid = reader.GetGuid(0);
                baseMpIdentity.Version = reader.GetString(1);
                depMpIdentity.VersionIndependentGuid = reader.GetGuid(2);
                depMpIdentity.Version = reader.GetString(3);

                if (!deps.ContainsKey(baseMpIdentity.VersionIndependentGuid))
                {
                    deps[baseMpIdentity.VersionIndependentGuid] = new CatalogManagementPackDependency();
                    deps[baseMpIdentity.VersionIndependentGuid].BaseManagementPack = baseMpIdentity;
                }

                deps[baseMpIdentity.VersionIndependentGuid].DependsOnManagementPacks.Add(depMpIdentity);
            }

            reader.NextResult();
            while (reader.Read())
            {
                CatalogManagementPackIdentity baseMpIdentity = new CatalogManagementPackIdentity();
                baseMpIdentity.VersionIndependentGuid = reader.GetGuid(0);
                baseMpIdentity.Version = reader.GetString(1);
                if (!deps.ContainsKey(baseMpIdentity.VersionIndependentGuid))
                {
                    deps[baseMpIdentity.VersionIndependentGuid] = new CatalogManagementPackDependency();
                    deps[baseMpIdentity.VersionIndependentGuid].BaseManagementPack = baseMpIdentity;
                }

            }

            Collection<CatalogManagementPackDependency> dependencies = new Collection<CatalogManagementPackDependency>();

            foreach (CatalogManagementPackDependency tempDep in deps.Values)
            {
                dependencies.Add(tempDep);
            }

            this.catalogManagementPackDependencyList = dependencies;
        }
    }
}