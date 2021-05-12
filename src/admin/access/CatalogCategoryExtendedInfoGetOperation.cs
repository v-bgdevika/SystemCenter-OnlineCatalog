//-----------------------------------------------------------------------
// <copyright file="CatalogCategoryExtendedInfoGetOperation.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Admin.Access
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.SqlClient;
    using System.Text;
    using Microsoft.ManagementPackCatalog.Access;
    using Microsoft.ManagementPackCatalog.Admin.Classes;

    /// <summary>
    /// This class is used to get CatalogCategoryExtendedInfo information
    /// </summary>
    public class CatalogCategoryExtendedInfoGetOperation : CatalogOperation
    {
        /// <summary>
        /// The last retreived extended info list.
        /// </summary>
        private Collection<CatalogCategoryExtendedInfo> categoryExtendedInfoList;

        /// <summary>
        /// Initializes a new instance of the CatalogCategoryExtendedInfoGetOperation class.
        /// </summary>
        public CatalogCategoryExtendedInfoGetOperation()
            : base("CatalogCategoryExtendedInfoGet")
        {
            this.categoryExtendedInfoList = new Collection<CatalogCategoryExtendedInfo>();
        }

        /// <summary>
        /// Gets the last retrieved category list.
        /// </summary>
        public Collection<CatalogCategoryExtendedInfo> CategoryExtendedInfoList
        {
            get { return this.categoryExtendedInfoList; }
        }

        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="categoryId">The catalog category id to retrieve. Pass 0 to retrieve all.</param>
        /// <param name="threeLetterLanguageCode">The language code for info.</param>
        public void SetParameters(int categoryId, string threeLetterLanguageCode)
        {
            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("CatalogItemId", categoryId));
            StoredProcParameters.Add(new SqlParameter("ThreeLetterLanguageCode", threeLetterLanguageCode));
        }

        /// <summary>
        /// This method is used to extract category information from the data reader.
        /// </summary>
        /// <param name="reader">Used to pass DB result.</param>
        protected override void ParseResult(SqlDataReader reader)
        {
            Collection<CatalogCategoryExtendedInfo> categoryExtendedInfoList = new Collection<CatalogCategoryExtendedInfo>();
            while (reader.Read())
            {
                CatalogCategoryExtendedInfo categoryExtendedInfo = new CatalogCategoryExtendedInfo();
                categoryExtendedInfo.CategoryId = reader.GetInt32(0);
                categoryExtendedInfo.Description = reader.GetString(1);

                categoryExtendedInfoList.Add(categoryExtendedInfo);
            }

            this.categoryExtendedInfoList = categoryExtendedInfoList;
        }
    }
}
