//-----------------------------------------------------------------------
// <copyright file="ManagementPackDependenciesGetOperation.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Access
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using Microsoft.ManagementPackCatalog.Classes;

    /// <summary>
    /// This class is used to fetch management pack dependencies given a set of management pack identities.
    /// </summary>
    public class ManagementPackDependenciesGetOperation : CatalogOperation
    {
        /// <summary>
        /// This field stores the result of the operation
        /// </summary>
        private Collection<CatalogManagementPackDependency> catalogManagementPackDependencyList;

        /// <summary>
        /// Initializes a new instance of the ManagementPackDependenciesGetOperation class.
        /// </summary>
        public ManagementPackDependenciesGetOperation()
            : base("ManagementPackDependenciesGet")
        {
        }

        /// <summary>
        /// Gets the catalog management pack depdendency list.
        /// </summary>
        public Collection<CatalogManagementPackDependency> CatalogManagementPackDependencyList
        {
            get { return this.catalogManagementPackDependencyList; }
        }

        /// <summary>
        /// This method sets the operation parameters.
        /// </summary>
        /// <param name="managementPackXml">
        /// This parameter contains the xml representing the management pack identities.
        /// Eg:
        /// <ManagementPacks>
        /// <ManagementPack VersionIndependentGuid = "6F9619FF-8B86-D011-B42D-00C04FC964FA" Version = "6.0.5000.0" />
        /// <ManagementPack VersionIndependentGuid = "6F9619FF-8B86-D011-B42D-00C04FC964FB" Version = "6.0.6278.0" />
        /// </ManagementPacks>
        /// </param>
        /// <param name="productName">Contains client product name</param>
        /// <param name="productVersion">Contains client product version</param>
        public void SetParameters(string managementPackXml, string productName, Version productVersion)
        {
            StoredProcParameters.Clear();
            StoredProcParameters.Add(new SqlParameter("ManagementPackXml", managementPackXml));
            StoredProcParameters.Add(new SqlParameter("ProductName", productName));
            StoredProcParameters.Add(new SqlParameter("ProductVersion", productVersion.ToString()));
        }

        /// <summary>
        /// This method parses the sql result.
        /// </summary>
        /// <param name="reader">Result from the stored proc execution</param>
        protected override void ParseResult(SqlDataReader reader)
        {
            CatalogManagementPackDependencyExtractor catalogManagementPackDependencyExtractor = new CatalogManagementPackDependencyExtractor();
            catalogManagementPackDependencyExtractor.Extract(reader);
            this.catalogManagementPackDependencyList = catalogManagementPackDependencyExtractor.CatalogManagementPackDependencyList;
        }
    }
}