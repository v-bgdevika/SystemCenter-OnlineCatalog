//-----------------------------------------------------------------------
// <copyright file="CatalogManagementPackExtendedInfoGetOperation.cs" company="Microsoft Corporation">
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
    /// This class is used to get CatalogManagementPackExtendedInfo information
    /// </summary>
    public class CatalogManagementPackExtendedInfoGetOperation : CatalogOperation
    {
        /// <summary>
        /// The last retreived extended info list.
        /// </summary>
        private Collection<CatalogManagementPackExtendedInfo> managementPackExtendedInfoList;

        /// <summary>
        /// Initializes a new instance of the CatalogManagementPackExtendedInfoGetOperation class.
        /// </summary>
        public CatalogManagementPackExtendedInfoGetOperation()
            : base("CatalogManagementPackExtendedInfoGet")
        {
            this.managementPackExtendedInfoList = new Collection<CatalogManagementPackExtendedInfo>();
        }

        /// <summary>
        /// Gets the last retrieved mp list.
        /// </summary>
        public Collection<CatalogManagementPackExtendedInfo> ManagementPackExtendedInfoList
        {
            get { return this.managementPackExtendedInfoList; }
        }

        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="categoryId">The catalog mp id to retrieve. Pass 0 to retrieve all.</param>
        /// <param name="threeLetterLanguageCode">The language code for info.</param>
        public void SetParameters(int mpId, string threeLetterLanguageCode)
        {
            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("CatalogItemId", mpId));
            StoredProcParameters.Add(new SqlParameter("ThreeLetterLanguageCode", threeLetterLanguageCode));
        }

        /// <summary>
        /// This method is used to extract category information from the data reader.
        /// </summary>
        /// <param name="reader">Used to pass DB result.</param>
        protected override void ParseResult(SqlDataReader reader)
        {
            Collection<CatalogManagementPackExtendedInfo> managementPackExtendedInfoList = new Collection<CatalogManagementPackExtendedInfo>();
            while (reader.Read())
            {
                CatalogManagementPackExtendedInfo managementPackExtendedInfo = new CatalogManagementPackExtendedInfo();
                managementPackExtendedInfo.ManagmentPackId = reader.GetInt32(0);
                managementPackExtendedInfo.Description = reader.GetString(1);
                managementPackExtendedInfo.Knowledge = reader.GetString(2);
                managementPackExtendedInfo.Eula = reader.GetString(3);

                managementPackExtendedInfoList.Add(managementPackExtendedInfo);
            }

            this.managementPackExtendedInfoList = managementPackExtendedInfoList;
        }
    }
}
