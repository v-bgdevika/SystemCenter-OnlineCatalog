//-----------------------------------------------------------------------
// <copyright file="CatalogItemExtendedInfoExtractor.cs" company="Microsoft Corporation">
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
    /// This class extracts CatalogItemExtendedInfo from the SqlDataReader
    /// </summary>
    internal class CatalogItemExtendedInfoExtractor : CatalogClassExtractor
    {
        /// <summary>
        /// Stores the extracted result
        /// </summary>
        private Collection<CatalogItemExtendedInfo> catalogItemExtendedInfoList;

        /// <summary>
        /// Gets the catalog item extended info list.
        /// </summary>
        public Collection<CatalogItemExtendedInfo> CatalogItemExtendedInfoList
        {
            get { return this.catalogItemExtendedInfoList; }
        }

        /// <summary>
        /// This method is used to extract a list of CatalogItemExtendedInfo from the SqlDataReader
        /// </summary>
        /// <param name="reader">Used to pass DB result</param>
        public override void Extract(SqlDataReader reader)
        {
            Collection<CatalogItemExtendedInfo> items = new Collection<CatalogItemExtendedInfo>();
            while (reader.Read())
            {
                CatalogItemExtendedInfo item = new CatalogItemExtendedInfo();
                item.CatalogItemId = reader.GetInt32(0);
                item.Description = reader.GetString(1);
                item.PublishedInd = reader.GetBoolean(2);

                items.Add(item);
            }

            this.catalogItemExtendedInfoList = items;
        }
    }
}
