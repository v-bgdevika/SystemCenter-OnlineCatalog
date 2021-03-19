//-----------------------------------------------------------------------
// <copyright file="ManagementPackListOperation.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Access
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using Microsoft.ManagementPackCatalog.Classes;

    /// <summary>
    /// This class is used to fetch the catalog items up to a given depth from the DB given a starting catalog category item id.
    /// </summary>
    public class ManagementPackListOperation : CatalogOperation
    {
        /// <summary>
        /// This field stores the result of the operation
        /// </summary>
        private Collection<CatalogItem> catalogItemList;

        /// <summary>
        /// Initializes a new instance of the ManagementPackListOperation class.
        /// </summary>
        public ManagementPackListOperation()
            : base("ManagementPackList")
        {
        }

        /// <summary>
        /// Gets the catalog item list
        /// </summary>
        public Collection<CatalogItem> CatalogItemList
        {
            get { return this.catalogItemList; }
        }

        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="catalogItemId">The starting catalog category id, 0 for root</param>
        /// <param name="depth">The number of levels you want to retrieve, 0 for all</param>
        /// <param name="productName">Contains client product name</param>
        /// <param name="productVersion">Contains client product version</param>
        /// <param name="threeLetterLanguageCode">The three letter language code for the language in which the data is to be returned</param>
        /// <param name="includeUnpublishedItemsIndicator">Indicator to indicate whether unpublished items should be returned</param>
        public void SetParameters(int catalogItemId, int depth, string productName, Version productVersion, string threeLetterLanguageCode, bool includeUnpublishedItemsIndicator)
        {
            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("CatalogItemId", catalogItemId));
            StoredProcParameters.Add(new SqlParameter("Depth", depth));
            StoredProcParameters.Add(new SqlParameter("ProductName", productName));
            StoredProcParameters.Add(new SqlParameter("ProductVersion", productVersion.ToString()));
            StoredProcParameters.Add(new SqlParameter("ThreeLetterLanguageCode", threeLetterLanguageCode));
            StoredProcParameters.Add(new SqlParameter("IncludeUnpublishedItemsInd", includeUnpublishedItemsIndicator));
        }

        /// <summary>
        /// This method parses the sql result.
        /// </summary>
        /// <param name="reader">Result from the stored proc execution</param>
        protected override void ParseResult(SqlDataReader reader)
        {
            CatalogCategoryExtractor catalogCategoryExtractor = new CatalogCategoryExtractor();
            catalogCategoryExtractor.Extract(reader);
            Collection<CatalogCategory> categories = catalogCategoryExtractor.CatalogCategoryList;

            reader.NextResult();

            ManagementPackCategoryExtractor managementPackCategoryExtractor = new ManagementPackCategoryExtractor();
            managementPackCategoryExtractor.Extract(reader);
            Dictionary<int, Collection<int>> managementPackCategoryMapping = managementPackCategoryExtractor.ManagementPackCategoryMap;

            reader.NextResult();

            CatalogManagementPackExtractor catalogManagementPackExtractor = new CatalogManagementPackExtractor();
            catalogManagementPackExtractor.Extract(reader);
            Collection<CatalogManagementPack> mps = catalogManagementPackExtractor.CatalogManagementPackList;

            ////Associate categories to mps
            foreach (KeyValuePair<int, Collection<int>> kvp in managementPackCategoryMapping)
            {
                int managementPackCatalogItemId = kvp.Key;

                for (int j = 0; j < mps.Count; j++)
                {
                    if (mps[j].CatalogItemId == managementPackCatalogItemId)
                    {
                        mps[j].Categories.Clear();
                        foreach (int categoryId in kvp.Value)
                        {
                            mps[j].Categories.Add(categoryId);
                        }
                    }
                }
            }

            Collection<CatalogItem> items = new Collection<CatalogItem>();

            for (int i = 0; i < mps.Count; i++)
            {
                items.Add(mps[i]);
            }

            for (int i = 0; i < categories.Count; i++)
            {
                items.Add(categories[i]);
            }

            this.catalogItemList = items;
        }
    }
}