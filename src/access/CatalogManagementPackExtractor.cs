//-----------------------------------------------------------------------
// <copyright file="CatalogManagementPackExtractor.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Access
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using Microsoft.ManagementPackCatalog.Classes;

    /// <summary>
    /// This class extracts CatalogManagementPack from the SqlDataReader
    /// </summary>
    internal class CatalogManagementPackExtractor : CatalogClassExtractor
    {
        /// <summary>
        /// Stores the extracted result.
        /// </summary>
        private Collection<CatalogManagementPack> catalogManagementPackList;

        /// <summary>
        /// Gets the catalog management pack list
        /// </summary>
        public Collection<CatalogManagementPack> CatalogManagementPackList
        {
            get { return this.catalogManagementPackList; }
        }

        /// <summary>
        /// This method is used to extract management pack information form SqlDataReader data set.
        /// </summary>
        /// <param name="reader">Used to pas DB result</param>
        public override void Extract(SqlDataReader reader)
        {
            Collection<CatalogManagementPack> items = new Collection<CatalogManagementPack>();
            while (reader.Read())
            {
                CatalogManagementPack item = new CatalogManagementPack();
                item.Identity = new CatalogManagementPackIdentity();
                item.VendorUri = new CatalogLink();

                item.IsCategory = false;
                item.IsManagementPack = true;

                item.CatalogItemId = reader.GetInt32(0);
                item.DisplayName = reader.GetString(1);
                item.Identity.VersionIndependentGuid = reader.GetGuid(2);
                item.Identity.Version = reader.GetString(3);
                item.SystemName = reader.GetString(4);
                item.PublicKey = reader.GetString(5);
                item.ReleaseDate = reader.GetDateTime(6);
                item.VendorUri.DisplayText = reader.GetString(7);
                item.VendorUri.DisplayLink = reader.GetString(8);
                item.DownloadLink = reader.GetString(9);
                item.EulaInd = reader.GetBoolean(10);
                item.SecurityInd = reader.GetBoolean(11);
                item.PublishedInd = reader.GetBoolean(12);

                items.Add(item);
            }

            this.catalogManagementPackList = items;
        }
    }
}