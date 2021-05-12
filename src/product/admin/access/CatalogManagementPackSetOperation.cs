//-----------------------------------------------------------------------
// <copyright file="CatalogManagementPackSetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to update/insert CatalogManagementPack information
    /// </summary>
    public class CatalogManagementPackSetOperation : CatalogOperation
    {
        /// <summary>
        /// The product id of the last category set
        /// </summary>
        private int internalManagementPackId;

        /// <summary>
        /// Initializes a new instance of the CatalogCategorySetOperation class.
        /// </summary>
        public CatalogManagementPackSetOperation()
            : base("CatalogManagementPackSet")
        {
        }

        /// <summary>
        /// Gets the category id of the last updated category by this object.
        /// </summary>
        public int ManagementPackId
        {
            get { return this.internalManagementPackId; }
        }

        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="managementPack">The management pack object. Pass 0 management pack id to insert new management pack.</param>
        /// <param name="managementPackExtendedInfo">The extended info for the category.</param>
        public void SetParameters(CatalogManagementPack managementPack, CatalogManagementPackExtendedInfo managementPackExtendedInfo)
        {
            System.Diagnostics.Debug.Assert(managementPack != null, "Null catalog management pack passed");
            System.Diagnostics.Debug.Assert(managementPackExtendedInfo != null, "Null catalog management pack extended info passed");

            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("CatalogItemId", managementPack.ManagementPackId));
            StoredProcParameters.Add(new SqlParameter("DisplayName", managementPack.DisplayName));
            StoredProcParameters.Add(new SqlParameter("Description", managementPackExtendedInfo.Description));
            StoredProcParameters.Add(new SqlParameter("VersionIndependentGuid", managementPack.VersionIndependentGuid));
            StoredProcParameters.Add(new SqlParameter("Version", managementPack.Version.ToString()));
            StoredProcParameters.Add(new SqlParameter("SystemName", managementPack.SystemName));
            StoredProcParameters.Add(new SqlParameter("PublicKey", managementPack.PublicKey));
            StoredProcParameters.Add(new SqlParameter("ReleaseDate", managementPack.ReleaseDate));
            StoredProcParameters.Add(new SqlParameter("VendorId", managementPack.VendorId));
            StoredProcParameters.Add(new SqlParameter("DownloadUri", managementPack.DownloadUri));
            StoredProcParameters.Add(new SqlParameter("DefaultKnowledge", managementPackExtendedInfo.Knowledge));
            StoredProcParameters.Add(new SqlParameter("EulaInd", managementPack.EulaInd));
            StoredProcParameters.Add(new SqlParameter("DefaultEula", managementPackExtendedInfo.Eula));
            StoredProcParameters.Add(new SqlParameter("SecurityInd", managementPack.SecurityInd));
            StoredProcParameters.Add(new SqlParameter("PublishedInd", managementPack.PublishedInd));
        }

        /// <summary>
        /// This method is used to extract updated management pack information from the data reader.
        /// </summary>
        /// <param name="reader">Used to pass DB result.</param>
        protected override void ParseResult(SqlDataReader reader)
        {
            reader.Read();
            this.internalManagementPackId = reader.GetInt32(0);
        }
    }
}
