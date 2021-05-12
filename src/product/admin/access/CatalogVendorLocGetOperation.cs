//-----------------------------------------------------------------------
// <copyright file="CatalogVendorLocGetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to get the language list for a CatalogVendor
    /// </summary>
    public class CatalogVendorLocGetOperation : CatalogOperation
    {
        /// <summary>
        /// The last retreived language list
        /// </summary>
        private Collection<string> languageList;

        /// <summary>
        /// Initializes a new instance of the CatalogVendorLocGetOperation class.
        /// </summary>
        public CatalogVendorLocGetOperation()
            : base("CatalogVendorLocGet")
        {
            this.languageList = new Collection<string>();
        }

        /// <summary>
        /// Gets the last retrieved language list.
        /// </summary>
        public Collection<string> LanguageList
        {
            get { return this.languageList; }
        }

        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="vendorId">The catalog vendor id whose languages are to be retrieved.</param>
        public void SetParameters(int vendorId)
        {
            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("VendorId", vendorId));
        }

        /// <summary>
        /// This method is used to extract vendor information from the data reader.
        /// </summary>
        /// <param name="reader">Used to pass DB result.</param>
        protected override void ParseResult(SqlDataReader reader)
        {
            Collection<string> languageList = new Collection<string>();
            languageList.Add("ENU");
            while (reader.Read())
            {
                languageList.Add(reader.GetString(0));
            }

            this.languageList = languageList;
        }
    }
}
