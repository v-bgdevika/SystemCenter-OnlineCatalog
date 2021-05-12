//-----------------------------------------------------------------------
// <copyright file="CatalogProductCatalogItemSetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to add catalog item to a product
    /// </summary>
    public class CatalogProductCatalogItemSetOperation : CatalogOperation
    {
        /// <summary>
        /// The item id of the last associated item.
        /// </summary>
        private int internalCatalogItemId;

        /// <summary>
        /// The management pack id of the last associated product.
        /// </summary>
        private int internalProductId;


        /// <summary>
        /// Initializes a new instance of the CatalogManagementPackCategorySetOperation class.
        /// </summary>
        public CatalogProductCatalogItemSetOperation()
            : base("CatalogProductCatalogItemSet")
        {
        }

        /// <summary>
        /// Gets the item id of last associated catalog item.
        /// </summary>
        public int CatalogItemId
        {
            get { return this.internalCatalogItemId; }
        }

        /// <summary>
        /// Gets the management pack id of last product id.
        /// </summary>
        public int ProductId
        {
            get { return this.internalProductId; }
        }


        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="catalogItemId">The catalog item id to be associated.</param>
        /// <param name="productId">The product id to be associated with.</param>
        public void SetParameters(int catalogItemId, int productId)
        {
            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("CatalogItemId", catalogItemId));
            StoredProcParameters.Add(new SqlParameter("ProductId", productId));
        }

        /// <summary>
        /// This method is used to extract updated category information from the data reader.
        /// </summary>
        /// <param name="reader">Used to pass DB result.</param>
        protected override void ParseResult(SqlDataReader reader)
        {
            reader.Read();
            this.internalProductId = reader.GetInt32(0);
            this.internalCatalogItemId = reader.GetInt32(1);
        }
    }
}
