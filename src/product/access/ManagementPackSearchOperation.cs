//-----------------------------------------------------------------------
// <copyright file="ManagementPackSearchOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to fetch the list of Management Packs and associated categories from the database, based on the given criteria.
    /// </summary>
    public class ManagementPackSearchOperation : CatalogOperation
    {
        /// <summary>
        /// This field stores the result of the operation.
        /// </summary>
        private Collection<CatalogItem> catalogItemList;

        /// <summary>
        /// Initializes a new instance of the ManagementPackSearchOperation class.
        /// </summary>
        public ManagementPackSearchOperation()
            : base("ManagementPackSearch")
        {
        }

        /// <summary>
        /// Gets tje catalog item list.
        /// </summary>
        public Collection<CatalogItem> CatalogItemList
        {
            get { return this.catalogItemList; }
        }

        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="managementPackNamePattern">The management pack name search pattern</param>
        /// <param name="vendorNamePattern">The vendor name search pattern</param>
        /// <param name="releasedOnOrAfter">The releasedOnOrAfter date to filter management packs</param>
        /// <param name="installedManagementPackXml">
        /// A list of installed management packs, which need to be checked for updates.
        /// Eg:
        /// <ManagementPacks>
        /// <ManagementPack VersionIndependentGuid = "6F9619FF-8B86-D011-B42D-00C04FC964FA" Version = "6.0.5000.0" />
        /// <ManagementPack VersionIndependentGuid = "6F9619FF-8B86-D011-B42D-00C04FC964FB" Version = "6.0.6278.0" />
        /// </ManagementPacks>
        /// </param>
        /// <param name="productName">Contains client product name</param>
        /// <param name="productVersion">Contains client product version</param>
        /// <param name="threeLetterLanguageCode">The three letter language code for the language in which the data is to be returned</param>
        /// <param name="includeUnpublishedItemsIndicator">Indicator to indicate whether unpublished items should be returned</param>
        public void SetParameters(string managementPackNamePattern, string vendorNamePattern, DateTime releasedOnOrAfter, string installedManagementPackXml, string productName, Version productVersion, string threeLetterLanguageCode, bool includeUnpublishedItemsIndicator)
        {
            StoredProcParameters.Add(new SqlParameter("ManagementPackNamePattern", managementPackNamePattern));
            StoredProcParameters.Add(new SqlParameter("VendorNamePattern", vendorNamePattern));
            StoredProcParameters.Add(new SqlParameter("ReleasedOnOrAfter", releasedOnOrAfter));
            StoredProcParameters.Add(new SqlParameter("InstalledManagementPackXml", installedManagementPackXml));
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
            ////Retrieve management packs
            CatalogManagementPackExtractor catalogManagementPackExtractor = new CatalogManagementPackExtractor();
            catalogManagementPackExtractor.Extract(reader);
            Collection<CatalogManagementPack> mps = catalogManagementPackExtractor.CatalogManagementPackList;

            reader.NextResult();

            //// retrieve mp and category mapping
            ManagementPackCategoryExtractor managementPackCategoryExtractor = new ManagementPackCategoryExtractor();
            managementPackCategoryExtractor.Extract(reader);
            Dictionary<int, Collection<int>> managementPackCategoryMapping = managementPackCategoryExtractor.ManagementPackCategoryMap;

            //// Associate categories to mps
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

            reader.NextResult();

            ////retrieve categories
            CatalogCategoryExtractor catalogCategoryExtractor = new CatalogCategoryExtractor();
            catalogCategoryExtractor.Extract(reader);
            Collection<CatalogCategory> categories = catalogCategoryExtractor.CatalogCategoryList;

            ////Return list
            Collection<CatalogItem> items = new Collection<CatalogItem>();

            ////Add mps and categories to return list
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

 