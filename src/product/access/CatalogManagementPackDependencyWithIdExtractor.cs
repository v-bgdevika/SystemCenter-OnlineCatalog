//-----------------------------------------------------------------------
// <copyright file="CatalogManagementPackDependencyWithIdExtractor.cs" company="Microsoft Corporation">
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
    /// This class extracts CatalogManagementPackDependency with item id from the SqlDataReader
    /// </summary>
    internal class CatalogManagementPackDependencyWithIdExtractor : CatalogClassExtractor
    {
        /// <summary>
        /// Stores the extracted result
        /// </summary>
        private Collection<KeyValuePair<int, CatalogManagementPackIdentity>> catalogManagementPackDependencyList;

        /// <summary>
        /// Gets the catalog management pack dependency list.
        /// </summary>
        public Collection<KeyValuePair<int, CatalogManagementPackIdentity>> CatalogManagementPackDependencyList
        {
            get { return this.catalogManagementPackDependencyList; }
        }

        /// <summary>
        /// This method is used to extract a list of management pack id and it's immeidiate dependency.
        /// This method is especially used by ManagementPackExtendedInfoGet class
        /// </summary>
        /// <param name="reader">Used to pass DB result</param>
        public override void Extract(SqlDataReader reader)
        {
            Collection<KeyValuePair<int, CatalogManagementPackIdentity>> items = new Collection<KeyValuePair<int, CatalogManagementPackIdentity>>();
            while (reader.Read())
            {
                CatalogManagementPackIdentity iden = new CatalogManagementPackIdentity();
                iden.VersionIndependentGuid = reader.GetGuid(1);
                iden.Version = reader.GetString(2);

                KeyValuePair<int, CatalogManagementPackIdentity> item = new KeyValuePair<int, CatalogManagementPackIdentity>(reader.GetInt32(0), iden);

                items.Add(item);
            }

            this.catalogManagementPackDependencyList = items;
        }
    }
}