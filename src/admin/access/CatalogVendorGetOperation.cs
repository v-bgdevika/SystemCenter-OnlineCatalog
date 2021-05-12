//-----------------------------------------------------------------------
// <copyright file="CatalogVendorGetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to get CatalogVendor information
    /// </summary>
    public class CatalogVendorGetOperation : CatalogOperation
    {
        /// <summary>
        /// The last retreived vendor list
        /// </summary>
        private Collection<CatalogVendor> vendorList;

        /// <summary>
        /// Initializes a new instance of the CatalogVendorGetOperation class.
        /// </summary>
        public CatalogVendorGetOperation()
            : base("CatalogVendorGet")
        {
            this.vendorList = new Collection<CatalogVendor>();
        }

        /// <summary>
        /// Gets the last retrieved vendor list.
        /// </summary>
        public Collection<CatalogVendor> VendorList
        {
            get { return this.vendorList; }
        }

        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="vendorId">The catalog vendor id to retrieve. Pass 0 to retrieve all.</param>
        /// <param name="threeLetterLanguageCode">The language code for info.</param>
        public void SetParameters(int vendorId, string threeLetterLanguageCode)
        {
            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("VendorId", vendorId));
            StoredProcParameters.Add(new SqlParameter("ThreeLetterLanguageCode", threeLetterLanguageCode));
        }

        /// <summary>
        /// This method is used to extract vendor information from the data reader.
        /// </summary>
        /// <param name="reader">Used to pass DB result.</param>
        protected override void ParseResult(SqlDataReader reader)
        {
            Collection<CatalogVendor> vendorList = new Collection<CatalogVendor>();
            while (reader.Read())
            {
                CatalogVendor vendor = new CatalogVendor();
                vendor.VendorId = reader.GetInt32(0);
                vendor.VendorName = reader.GetString(1);
                vendor.VendorLink = reader.GetString(2);

                vendorList.Add(vendor);
            }

            this.vendorList = vendorList;
        }
    }
}
