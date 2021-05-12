//-----------------------------------------------------------------------
// <copyright file="CatalogManagementPackDependencySetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to update/insert CatalogManagementPackDependency information
    /// </summary>
    public class CatalogManagementPackDependencySetOperation : CatalogOperation
    {
        /// <summary>
        /// The catalog item id of the last MP who dependency was updated
        /// </summary>
        private int internalCatalogItemId;

        /// <summary>
        /// The dependent mp identity
        /// </summary>
        private CatalogManagementPackIdentity internalDependentMP;

        /// <summary>
        /// Initializes a new instance of the CatalogManagementPackDependencySetOperation class.
        /// </summary>
        public CatalogManagementPackDependencySetOperation()
            : base("CatalogManagementPackDependencySet")
        {
            this.internalDependentMP = new CatalogManagementPackIdentity();
        }

        /// <summary>
        /// Gets the catalog item id of the last updated management pack by this object.
        /// </summary>
        public int CatalogItemId
        {
            get { return this.internalCatalogItemId; }
        }

        /// <summary>
        /// Gets the last dependent catalog mp identity.
        /// </summary>
        public CatalogManagementPackIdentity DependentMP
        {
            get { return this.internalDependentMP; }
        }

        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="catalogItemId">The catalogItemId whose dependency is to be updated.</param>
        /// <param name="dependentMP">The management pack identity of the dependent mp</param>
        public void SetParameters(int catalogItemId, CatalogManagementPackIdentity dependentMP)
        {
            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("CatalogItemId", catalogItemId));
            StoredProcParameters.Add(new SqlParameter("VersionIndependentGuid", dependentMP.VersionIndependentGuid));
            StoredProcParameters.Add(new SqlParameter("Version", dependentMP.Version));
        }

        /// <summary>
        /// This method is used to extract updated category information from the data reader.
        /// </summary>
        /// <param name="reader">Used to pass DB result.</param>
        protected override void ParseResult(SqlDataReader reader)
        {
            reader.Read();
            this.internalCatalogItemId = reader.GetInt32(0);
            this.internalDependentMP.VersionIndependentGuid = reader.GetGuid(1);
            this.internalDependentMP.Version = reader.GetString(2);
        }
    }
}
