//-----------------------------------------------------------------------
// <copyright file="CatalogManagementPackCategorySetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to add management pack to a category information
    /// </summary>
    public class CatalogManagementPackCategorySetOperation : CatalogOperation
    {
        /// <summary>
        /// The category id of the last associated category.
        /// </summary>
        private int internalCategoryId;

        /// <summary>
        /// The management pack id of the last associated MP.
        /// </summary>
        private int internalManagementPackId;


        /// <summary>
        /// Initializes a new instance of the CatalogManagementPackCategorySetOperation class.
        /// </summary>
        public CatalogManagementPackCategorySetOperation()
            : base("CatalogManagementPackCategorySet")
        {
        }

        /// <summary>
        /// Gets the category id of last associated category.
        /// </summary>
        public int CategoryId
        {
            get { return this.internalCategoryId; }
        }

        /// <summary>
        /// Gets the management pack id of last associated category.
        /// </summary>
        public int ManagementPackId
        {
            get { return this.internalManagementPackId; }
        }


        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="categoryId">The category to by associated.</param>
        /// <param name="managementPackId">The management pack id to be associated</param>
        public void SetParameters(int categoryId, int managementPackId)
        {
            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("ManagementPackCatalogItemId", managementPackId));
            StoredProcParameters.Add(new SqlParameter("CategoryCatalogItemId", categoryId));
        }

        /// <summary>
        /// This method is used to extract updated category information from the data reader.
        /// </summary>
        /// <param name="reader">Used to pass DB result.</param>
        protected override void ParseResult(SqlDataReader reader)
        {
            reader.Read();
            this.internalManagementPackId = reader.GetInt32(0);
            this.internalCategoryId = reader.GetInt32(1);
        }
    }
}
