//-----------------------------------------------------------------------
// <copyright file="CatalogItemExtendedInfoGetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to fetch CatalogItemExtendedInfo from the database
    /// </summary>
    public class CatalogItemExtendedInfoGetOperation : CatalogOperation
    {
        /// <summary>
        /// This field stores the result of the operation
        /// </summary>
        private Collection<CatalogItemExtendedInfo> catalogItemExtendedInfoList;

        /// <summary>
        /// Initializes a new instance of the CatalogItemExtendedInfoGetOperation class.
        /// </summary>
        public CatalogItemExtendedInfoGetOperation()
            : base("CatalogItemExtendedInfoGet")
        {
        }

        /// <summary>
        /// Gets the catalog item extended info list.
        /// </summary>
        public Collection<CatalogItemExtendedInfo> CatalogItemExtendedInfoList
        {
            get { return this.catalogItemExtendedInfoList; }
        }

        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="catalogItemXml">
        /// The catalog item xml for which the extended info is to be returned.
        /// Eg:
        /// <CatalogItems>
        /// <CatalogItem ID="1"/>
        /// <CatalogItem ID="2"/>
        /// </CatalogItems>
        /// </param>
        /// <param name="productName">The product name of the client</param>
        /// <param name="productVersion">The product version of the client</param>
        /// <param name="threeLetterLanguageCode">The three letter language code for the language in which the data is to be returned</param>
        /// <param name="includeUnpublishedItemsIndicator">Indicator to indicate whether unpublished items should be returned</param>
        public void SetParameters(string catalogItemXml, string productName, Version productVersion, string threeLetterLanguageCode, bool includeUnpublishedItemsIndicator)
        {
            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("CatalogItemXml", catalogItemXml));
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
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["csMain"].ToString()))
            {
                CatalogItemExtendedInfoExtractor catalogItemExtendedInfoExtractor = new CatalogItemExtendedInfoExtractor();
                catalogItemExtendedInfoExtractor.Extract(reader);
                this.catalogItemExtendedInfoList = catalogItemExtendedInfoExtractor.CatalogItemExtendedInfoList;
            }
        }
    }
}
