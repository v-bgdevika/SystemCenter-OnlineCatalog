﻿//-----------------------------------------------------------------------
// <copyright file="CatalogCategoryAssignedManagementPackGetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to get CatalogManagementPack assigned to a category 
    /// </summary>
    public class CatalogCategoryAssignedManagementPackGetOperation : CatalogOperation
    {
        /// <summary>
        /// The last retreived management pack list
        /// </summary>
        private Collection<CatalogManagementPack> managementPackList;

        /// <summary>
        /// Initializes a new instance of the CatalogCategoryAssignedManagementPackGetOperation class.
        /// </summary>
        public CatalogCategoryAssignedManagementPackGetOperation()
            : base("CatalogCategoryAssignedManagementPackGet")
        {
            this.managementPackList = new Collection<CatalogManagementPack>();
        }

        /// <summary>
        /// Gets the last retrieved management pack list.
        /// </summary>
        public Collection<CatalogManagementPack> ManagementPackList
        {
            get { return this.managementPackList; }
        }

        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="categoryId">The category id whose MPs are to be retrieved.</param>
        public void SetParameters(int categoryId)
        {
            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("CategoryId", categoryId));
        }

        /// <summary>
        /// This method is used to extract management pack information from the data reader.
        /// </summary>
        /// <param name="reader">Used to pass DB result.</param>
        protected override void ParseResult(SqlDataReader reader)
        {
            Collection<CatalogManagementPack> managementPackList = new Collection<CatalogManagementPack>();
            while (reader.Read())
            {
                CatalogManagementPack managementPack = new CatalogManagementPack();
                managementPack.ManagementPackId = reader.GetInt32(0);
                managementPack.DisplayName = reader.GetString(1);
                managementPack.VersionIndependentGuid = reader.GetGuid(2);
                managementPack.Version = new Version(reader.GetString(3));
                managementPack.SystemName = reader.GetString(4);
                managementPack.PublicKey = reader.GetString(5);
                managementPack.ReleaseDate = reader.GetDateTime(6);
                managementPack.VendorId = reader.GetInt32(7);
                managementPack.DownloadUri = reader.GetString(8);
                managementPack.EulaInd = reader.GetBoolean(9);
                managementPack.PublishedInd = reader.GetBoolean(10);

                managementPackList.Add(managementPack);
            }

            this.managementPackList = managementPackList;
        }
    }
}
