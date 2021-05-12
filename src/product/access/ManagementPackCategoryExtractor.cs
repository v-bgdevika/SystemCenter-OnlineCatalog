//-----------------------------------------------------------------------
// <copyright file="ManagementPackCategoryExtractor.cs" company="Microsoft Corporation">
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
    /// This class extracts ManagementPack to Categoy mapping from the SqlDataReader
    /// </summary>
    internal class ManagementPackCategoryExtractor : CatalogClassExtractor
    {
        /// <summary>
        /// Stores the extracted result
        /// </summary>
        private Dictionary<int, Collection<int>> managementPackCategoryMap;

        /// <summary>
        /// Gets the management pack category map
        /// </summary>
        public Dictionary<int, Collection<int>> ManagementPackCategoryMap
        {
            get { return this.managementPackCategoryMap; }
        }

        /// <summary>
        /// This method is used to extract the mapping between management pack and category from SqlDataReader
        /// </summary>
        /// <param name="reader">Used to pas DB result</param>
        public override void Extract(SqlDataReader reader)
        {
            Dictionary<int, Collection<int>> mps = new Dictionary<int, Collection<int>>();

            while (reader.Read())
            {
                int managementPackCatalogItemId = reader.GetInt32(0);
                int categoryCatalogItemId = reader.GetInt32(1);

                if (!mps.ContainsKey(managementPackCatalogItemId))
                {
                    mps[managementPackCatalogItemId] = new Collection<int>();
                }

                mps[managementPackCatalogItemId].Add(categoryCatalogItemId);
            }

            this.managementPackCategoryMap = mps;
        }
    }
}