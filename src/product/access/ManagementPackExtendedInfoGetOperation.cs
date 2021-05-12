//-----------------------------------------------------------------------
// <copyright file="ManagementPackExtendedInfoGetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to fetch CatalogManagementPackExtendedInfo from the DB for a given list of management pack identities.
    /// </summary>
    public class ManagementPackExtendedInfoGetOperation : CatalogOperation
    {
        /// <summary>
        /// This field stores the result of the operation
        /// </summary>
        private Collection<CatalogManagementPackExtendedInfo> catalogManagementPackExtendedInfoList;

        /// <summary>
        /// Initializes a new instance of the ManagementPackExtendedInfoGetOperation class.
        /// </summary>
        public ManagementPackExtendedInfoGetOperation()
            : base("ManagementPackExtendedInfoGet")
        {
        }

        /// <summary>
        /// Gets the catalog management pack extended info list.
        /// </summary>
        public Collection<CatalogManagementPackExtendedInfo> CatalogManagementPackExtendedInfoList
        {
            get { return this.catalogManagementPackExtendedInfoList; }
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
            ////Retrieve Extended Info
            CatalogManagementPackExtendedInfoExtractor managementPackExtendedInfoExtractor = new CatalogManagementPackExtendedInfoExtractor();
            managementPackExtendedInfoExtractor.Extract(reader);
            Collection<CatalogManagementPackExtendedInfo> items = managementPackExtendedInfoExtractor.CatalogManagementPackExtendedInfoList;

            reader.NextResult();

            ////Retrieve immidiate dependent MP identities
            CatalogManagementPackDependencyWithIdExtractor catalogManagementPackWithIdExtractor = new CatalogManagementPackDependencyWithIdExtractor();
            catalogManagementPackWithIdExtractor.Extract(reader);
            Collection<KeyValuePair<int, CatalogManagementPackIdentity>> deps = catalogManagementPackWithIdExtractor.CatalogManagementPackDependencyList;

            reader.NextResult();

            ////Get information regarding dependent MPs
            CatalogManagementPackExtractor catalogManagementPackExtractor = new CatalogManagementPackExtractor();
            catalogManagementPackExtractor.Extract(reader);
            Collection<CatalogManagementPack> mps = catalogManagementPackExtractor.CatalogManagementPackList;

            ////Associate MPs to extended info
            for (int i = 0; i < deps.Count; i++)
            {
                for (int j = 0; j < items.Count; j++)
                {
                    if (items[j].CatalogItemId == deps[i].Key)
                    {
                        for (int k = 0; k < mps.Count; k++)
                        {
                            if (deps[i].Value.VersionIndependentGuid == mps[k].Identity.VersionIndependentGuid)
                            {
                                items[j].DependsOn.Add(mps[k]);
                                break;
                            }
                        }

                        break;
                    }
                }
            }

            this.catalogManagementPackExtendedInfoList = items;
        }
    }
}
