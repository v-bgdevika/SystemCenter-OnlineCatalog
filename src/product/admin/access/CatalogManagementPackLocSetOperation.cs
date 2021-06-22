//-----------------------------------------------------------------------
// <copyright file="CatalogManagementPackLocSetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to update/insert CatalogManagementPack localized information
    /// </summary>
    public class CatalogManagementPackLocSetOperation : CatalogOperation
    {
        /// <summary>
        /// The product id of the last category set
        /// </summary>
        private int internalManagementPackId;

        /// <summary>
        /// Initializes a new instance of the CatalogCategorySetOperation class.
        /// </summary>
        public CatalogManagementPackLocSetOperation()
            : base("CatalogManagementPackLocSet")
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
        /// <param name="managementPack">The management pack object.</param>
        /// <param name="managementPackExtendedInfo">The extended info for the category.</param>
        /// <param name="threeLetterLanguageCode">The language code for the info.</param>
        public void SetParameters(CatalogManagementPack managementPack, CatalogManagementPackExtendedInfo managementPackExtendedInfo, string threeLetterLanguageCode)
        {
            System.Diagnostics.Debug.Assert(managementPack != null, "Null catalog management pack passed");
            System.Diagnostics.Debug.Assert(managementPackExtendedInfo != null, "Null catalog management pack extended info passed");

            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("CatalogItemId", managementPack.ManagementPackId));
            StoredProcParameters.Add(new SqlParameter("DisplayName", managementPack.DisplayName));
            StoredProcParameters.Add(new SqlParameter("Description", managementPackExtendedInfo.Description));
            StoredProcParameters.Add(new SqlParameter("LocalizedKnowledge", managementPackExtendedInfo.Knowledge));
            StoredProcParameters.Add(new SqlParameter("LocalizedEula", managementPackExtendedInfo.Eula));
            StoredProcParameters.Add(new SqlParameter("ThreeLetterLanguageCode", threeLetterLanguageCode));
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
