//-----------------------------------------------------------------------
// <copyright file="CatalogProductSetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to update/insert CatalogProduct information
    /// </summary>
    public class CatalogProductSetOperation : CatalogOperation
    {
        /// <summary>
        /// The product id of the last product set
        /// </summary>
        private int internalProductId;

        /// <summary>
        /// Initializes a new instance of the CatalogProductSetOperation class.
        /// </summary>
        public CatalogProductSetOperation()
            : base("CatalogProductSet")
        {
        }

        /// <summary>
        /// Gets the product id of the last updated product by this object.
        /// </summary>
        public int ProductId
        {
            get { return this.internalProductId; }
        }

        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="product">The catalog product object. Pass 0 product id to insert new product.</param>
        public void SetParameters(CatalogProduct product)
        {
            System.Diagnostics.Debug.Assert(product != null, "Null catalog product passed");

            Version version = new Version(product.ProductVersion);

            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("ProductId", product.ProductId));
            StoredProcParameters.Add(new SqlParameter("ProductName", product.ProductName));
            StoredProcParameters.Add(new SqlParameter("ProductVersion", version.ToString()));
        }

        /// <summary>
        /// This method is used to extract updated product information from the data reader.
        /// </summary>
        /// <param name="reader">Used to pass DB result.</param>
        protected override void ParseResult(SqlDataReader reader)
        {
            reader.Read();
            this.internalProductId = reader.GetInt32(0);
        }
    }
}
