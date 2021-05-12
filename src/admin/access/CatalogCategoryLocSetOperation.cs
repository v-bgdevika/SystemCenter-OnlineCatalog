﻿//-----------------------------------------------------------------------
// <copyright file="CatalogCategoryLocSetOperation.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Admin.Access
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Text;
    using Microsoft.ManagementPackCatalog.Access;
    using Microsoft.ManagementPackCatalog.Admin.Classes;

    /// <summary>
    /// This class is used to update/insert CatalogCategory localized information
    /// </summary>
    public class CatalogCategoryLocSetOperation : CatalogOperation
    {
        /// <summary>
        /// The product id of the last category set
        /// </summary>
        private int internalCategoryId;

        /// <summary>
        /// Initializes a new instance of the CatalogCategoryLocSetOperation class.
        /// </summary>
        public CatalogCategoryLocSetOperation()
            : base("CatalogCategoryLocSet")
        {
        }

        /// <summary>
        /// Gets the category id of the last updated category by this object.
        /// </summary>
        public int CategoryId
        {
            get { return this.internalCategoryId; }
        }

        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="category">The category object.</param>
        /// <param name="categoryExtendedInfo">The extended info for the category.</param>
        /// <param name="threeLetterLanguageCode">The language code for the info.</param>
        public void SetParameters(CatalogCategory category, CatalogCategoryExtendedInfo categoryExtendedInfo, string threeLetterLanguageCode)
        {
            System.Diagnostics.Debug.Assert(category != null, "Null catalog category passed");
            System.Diagnostics.Debug.Assert(categoryExtendedInfo != null, "Null catalog category extended info passed");

            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("CatalogItemId", category.CategoryId));
            StoredProcParameters.Add(new SqlParameter("DisplayName", category.DisplayName));
            StoredProcParameters.Add(new SqlParameter("Description", categoryExtendedInfo.Description));
            StoredProcParameters.Add(new SqlParameter("GuideUriText", category.GuideUriText));
            StoredProcParameters.Add(new SqlParameter("GuideUriLink", category.GuideUriLink));
            StoredProcParameters.Add(new SqlParameter("ThreeLetterLanguageCode", threeLetterLanguageCode));
        }

        /// <summary>
        /// This method is used to extract updated category information from the data reader.
        /// </summary>
        /// <param name="reader">Used to pass DB result.</param>
        protected override void ParseResult(SqlDataReader reader)
        {
            reader.Read();
            this.internalCategoryId = reader.GetInt32(0);
        }
    }
}
