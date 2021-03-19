//-----------------------------------------------------------------------
// <copyright file="CatalogCategoryGetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to get CatalogCategory information
    /// </summary>
    public class CatalogCategoryGetOperation : CatalogOperation
    {
        /// <summary>
        /// The last retreived category list
        /// </summary>
        private Collection<CatalogCategory> categoryList;

        /// <summary>
        /// Initializes a new instance of the CatalogCategoryGetOperation class.
        /// </summary>
        public CatalogCategoryGetOperation()
            : base("CatalogCategoryGet")
        {
            this.categoryList = new Collection<CatalogCategory>();
        }

        /// <summary>
        /// Gets the last retrieved category list.
        /// </summary>
        public Collection<CatalogCategory> CategoryList
        {
            get { return this.categoryList; }
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
            Collection<CatalogCategory> categoryList = new Collection<CatalogCategory>();
            while (reader.Read())
            {
                CatalogCategory category = new CatalogCategory();
                category.CategoryId = reader.GetInt32(0);
                category.DisplayName = reader.GetString(1);
                category.GuideUriText = reader.GetString(2);
                category.GuideUriLink = reader.GetString(3);
                category.ParentCategoryId = reader.GetInt32(4);
                category.PublishedInd = reader.GetBoolean(5);

                categoryList.Add(category);
            }

            this.categoryList = categoryList;
        }
    }
}
