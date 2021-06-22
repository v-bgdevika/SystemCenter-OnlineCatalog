//-----------------------------------------------------------------------
// <copyright file="CatalogItemAssociatedProductGetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to get the associated product list for a CatalogItem
    /// </summary>
    public class CatalogItemAssociatedProductGetOperation : CatalogOperation
    {
        /// <summary>
        /// The last retreived product list
        /// </summary>
        private Collection<CatalogProduct> productList;

        /// <summary>
        /// Initializes a new instance of the CatalogItemAssociatedProductGetOperation class.
        /// </summary>
        public CatalogItemAssociatedProductGetOperation()
            : base("CatalogItemAssociatedProductGet")
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
        /// <param name="catalogItemId">The catalog item id whose associated products are to be retrieved.</param>
        public void SetParameters(int catalogItemId)
        {
            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("CatalogItemId", catalogItemId));
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
