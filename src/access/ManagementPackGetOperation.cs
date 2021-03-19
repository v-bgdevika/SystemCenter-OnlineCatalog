//-----------------------------------------------------------------------
// <copyright file="ManagementPackGetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to fetch management pack information given a set of management pack identities.
    /// </summary>
    public class ManagementPackGetOperation : CatalogOperation
    {
        /// <summary>
        /// This field stores the result of the operation
        /// </summary>
        private Collection<CatalogManagementPack> catalogManagementPackList;

        /// <summary>
        /// Initializes a new instance of the ManagementPackGetOperation class.
        /// </summary>
        public ManagementPackGetOperation()
            : base("ManagementPackGet")
        {
        }

        /// <summary>
        /// Gets the catalog management pack list.
        /// </summary>
        public Collection<CatalogManagementPack> CatalogManagementPackList
        {
            get { return this.catalogManagementPackList; }
        }

        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="managementPackXml">
        /// This parameter contains the xml representing the management pack identities.
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
        public void SetParameters(string managementPackXml, string productName, Version productVersion, string threeLetterLanguageCode, bool includeUnpublishedItemsIndicator)
        {
            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("ManagementPackXml", managementPackXml));
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
            CatalogManagementPackExtractor catalogManagementPackExtractor = new CatalogManagementPackExtractor();
            catalogManagementPackExtractor.Extract(reader);
            Collection<CatalogManagementPack> mps = catalogManagementPackExtractor.CatalogManagementPackList;

            reader.NextResult();

            ManagementPackCategoryExtractor managementPackCategoryExtractor = new ManagementPackCategoryExtractor();
            managementPackCategoryExtractor.Extract(reader);
            Dictionary<int, Collection<int>> managementPackCategoryMapping = managementPackCategoryExtractor.ManagementPackCategoryMap;

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

            this.catalogManagementPackList = mps;
        }
    }
}