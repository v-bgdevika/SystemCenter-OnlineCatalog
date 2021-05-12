//-----------------------------------------------------------------------
// <copyright file="CatalogProductGetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to get CatalogProduct information
    /// </summary>
    public class CatalogProductGetOperation : CatalogOperation
    {
        /// <summary>
        /// The last retreived product list
        /// </summary>
        private Collection<CatalogProduct> productList;

        /// <summary>
        /// Initializes a new instance of the CatalogProductGetOperation class.
        /// </summary>
        public CatalogProductGetOperation()
            : base("CatalogProductGet")
        {
            this.productList = new Collection<CatalogProduct>();
        }

        /// <summary>
        /// Gets the last retrieved product list.
        /// </summary>
        public Collection<CatalogProduct> ProductList
        {
            get { return this.productList; }
        }

        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="productId">The catalog product id to retrieve. Pass 0 to retrieve all.</param>
        public void SetParameters(int productId)
        {
            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("ProductId", productId));
        }

        /// <summary>
        /// This method is used to extract product information from the data reader.
        /// </summary>
        /// <param name="reader">Used to pass DB result.</param>
        protected override void ParseResult(SqlDataReader reader)
        {
            Collection<CatalogProduct> productList = new Collection<CatalogProduct>();
            while (reader.Read())
            {
                CatalogProduct product = new CatalogProduct();
                product.ProductId = reader.GetInt32(0);
                product.ProductName = reader.GetString(1);
                product.ProductVersion = reader.GetString(2);

                productList.Add(product);
            }

            this.productList = productList;
        }
    }
}
