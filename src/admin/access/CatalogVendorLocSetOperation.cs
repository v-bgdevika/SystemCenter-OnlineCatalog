//-----------------------------------------------------------------------
// <copyright file="CatalogVendorLocSetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to update/insert CatalogVendor localization information
    /// </summary>
    public class CatalogVendorLocSetOperation : CatalogOperation
    {
        /// <summary>
        /// The product id of the last vendor set
        /// </summary>
        private int internalVendorId;

        /// <summary>
        /// Initializes a new instance of the CatalogVendorLocSetOperation class.
        /// </summary>
        public CatalogVendorLocSetOperation()
            : base("CatalogVendorLocSet")
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
        /// <param name="threeLetterLanguageCode">The language code of the info.</param>
        public void SetParameters(CatalogVendor vendor, string threeLetterLanguageCode)
        {
            System.Diagnostics.Debug.Assert(vendor != null, "Null catalog vendor passed");

            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("VendorId", vendor.VendorId));
            StoredProcParameters.Add(new SqlParameter("VendorName", vendor.VendorName));
            StoredProcParameters.Add(new SqlParameter("VendorLink", vendor.VendorLink));
            StoredProcParameters.Add(new SqlParameter("ThreeLetterLanguageCode", threeLetterLanguageCode));
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
