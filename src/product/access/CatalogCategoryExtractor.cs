//-----------------------------------------------------------------------
// <copyright file="CatalogCategoryExtractor.cs" company="Microsoft Corporation">
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
    /// This class extracts CatalogCategory from the SqlDataReader
    /// </summary>
    internal class CatalogCategoryExtractor : CatalogClassExtractor
    {
        /// <summary>
        /// Stores the extracted result.
        /// </summary>
        private Collection<CatalogCategory> catalogCategoryList;

        /// <summary>
        /// Gets the catlog category list
        /// </summary>
        public Collection<CatalogCategory> CatalogCategoryList
        {
            get { return this.catalogCategoryList; }
        }

        /// <summary>
        /// This method is used to extract category information from SqlDataReader
        /// </summary>
        /// <param name="reader">Used to pass DB result</param>
        public override void Extract(SqlDataReader reader)
        {
            Collection<CatalogCategory> items = new Collection<CatalogCategory>();

            while (reader.Read())
            {
                CatalogCategory item = new CatalogCategory();
                item.GuideUri = new CatalogLink();

                item.IsCategory = true;
                item.IsManagementPack = false;

                item.CatalogItemId = reader.GetInt32(0);
                item.DisplayName = reader.GetString(1);
                item.GuideUri.DisplayText = reader.GetString(2);
                item.GuideUri.DisplayLink = reader.GetString(3);
                item.ParentCategoryId = reader.GetInt32(4);
                item.PublishedInd = reader.GetBoolean(5);

                items.Add(item);
            }

            this.catalogCategoryList = items;
        }
    }
}