//-----------------------------------------------------------------------
// <copyright file="CatalogProduct.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Admin.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class represents the product.
    /// </summary>
    public class CatalogProduct
    {
        /// <summary>
        /// This field stores the product id
        /// </summary>
        private int productId;

        /// <summary>
        /// This field stores product name
        /// </summary>
        private string productName;

        /// <summary>
        /// This field stores product version
        /// </summary>
        private string productVersion;

        /// <summary>
        /// Gets or sets product id
        /// </summary>
        public int ProductId
        {
            get { return this.productId; }
            set { this.productId = value; }
        }

        /// <summary>
        /// Gets or sets product name
        /// </summary>
        public string ProductName
        {
            get { return this.productName; }
            set { this.productName = value; }
        }

        /// <summary>
        /// Gets or sets product version
        /// </summary>
        public string ProductVersion
        {
            get { return this.productVersion; }
            set { this.productVersion = value; }
        }
    }
}
