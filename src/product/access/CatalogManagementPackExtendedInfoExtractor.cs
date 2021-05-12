//-----------------------------------------------------------------------
// <copyright file="CatalogManagementPackExtendedInfoExtractor.cs" company="Microsoft Corporation">
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
    /// This class extracts ManagementPackExtendedInfo from the SqlDataReader
    /// </summary>
    internal class CatalogManagementPackExtendedInfoExtractor : CatalogClassExtractor
    {
        /// <summary>
        /// Stores the extracted result
        /// </summary>
        private Collection<CatalogManagementPackExtendedInfo> catalogManagementPackExtendedInfoList;

        /// <summary>
        /// Gets the catalog management pack extended info list.
        /// </summary>
        public Collection<CatalogManagementPackExtendedInfo> CatalogManagementPackExtendedInfoList
        {
            get { return this.catalogManagementPackExtendedInfoList; }
        }

        /// <summary>
        /// This method is used to extract a list of CatalogManagementPackExtendedInfo from the SqlDataReader
        /// </summary>
        /// <param name="reader">Used to pass DB result</param>
        public override void Extract(SqlDataReader reader)
        {
            Collection<CatalogManagementPackExtendedInfo> items = new Collection<CatalogManagementPackExtendedInfo>();

            while (reader.Read())
            {
                CatalogManagementPackExtendedInfo item = new CatalogManagementPackExtendedInfo();
                item.CatalogItemId = reader.GetInt32(0);
                item.Description = reader.GetString(1);
                item.KnowledgeArticles = reader.GetString(2);
                if (reader.IsDBNull(3) == false)
                {
                    item.Eula = reader.GetString(3);
                }

                item.PublishedInd = reader.GetBoolean(4);
                item.Identity.VersionIndependentGuid = reader.GetGuid(5);
                item.Identity.Version = reader.GetString(6);
                items.Add(item);
            }

            this.catalogManagementPackExtendedInfoList = items;
        }
    }
}
