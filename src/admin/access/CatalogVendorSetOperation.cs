//-----------------------------------------------------------------------
// <copyright file="CatalogVendorSetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to update/insert CatalogVendor information
    /// </summary>
    public class CatalogVendorSetOperation : CatalogOperation
    {
        /// <summary>
        /// The vendor id of the last vendor set
        /// </summary>
        private int internalVendorId;

        /// <summary>
        /// Initializes a new instance of the CatalogVendorSetOperation class.
        /// </summary>
        public CatalogVendorSetOperation()
            : base("CatalogVendorSet")
        {
        }

        /// <summary>
        /// Gets the vendor id of the last updated vendor by this object.
        /// </summary>
        public int VendorId
        {
            get { return this.internalVendorId; }
        }

        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="vendor">The catalog vendor object. Pass 0 vendor id to insert new product.</param>
        public void SetParameters(CatalogVendor vendor)
        {
            System.Diagnostics.Debug.Assert(vendor != null, "Null catalog vendor passed");

            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("VendorId", vendor.VendorId));
            StoredProcParameters.Add(new SqlParameter("VendorName", vendor.VendorName));
            StoredProcParameters.Add(new SqlParameter("VendorLink", vendor.VendorLink));
        }

        /// <summary>
        /// This method is used to extract updated vendor information from the data reader.
        /// </summary>
        /// <param name="reader">Used to pass DB result.</param>
        protected override void ParseResult(SqlDataReader reader)
        {
            reader.Read();
            this.internalVendorId = reader.GetInt32(0);
        }
    }
}
