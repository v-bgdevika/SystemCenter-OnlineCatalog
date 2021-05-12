//-----------------------------------------------------------------------
// <copyright file="ManagementPackCatalogWebService.asmx.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------


namespace Microsoft.ManagementPackCatalog.WebService
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Web.Services;
    using System.Xml;
    using Microsoft.ManagementPackCatalog.Access;
    using Microsoft.ManagementPackCatalog.Classes;

    /// <summary>
    /// This class has implments the management pack catalog webservice.
    /// It contains web methods that would allow SCOM UI to display, filter and import management packs.
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    public class ManagementPackCatalogWebService
    {
        /// <summary>
        /// This field stores the Xml generator class used to convert catalog management pack classes to xml.
        /// </summary>
        private ManagementPackCatalogXmlGenerator xmlGenerator;

        /// <summary>
        /// This field stores the trace provider
        /// </summary>
        private TraceProvider traceProvider;

        /// <summary>
        /// Initializes a new instance of the ManagementPackCatalogWebService class.
        /// </summary>
        public ManagementPackCatalogWebService()
        {
            this.xmlGenerator = new ManagementPackCatalogXmlGenerator();
            this.traceProvider = TraceProvider.CreateInstance();
        }

        /// <summary>
        /// This function returns the CatalogItems that can be used to build the ManagementPack tree on the UI.
        /// </summary>
        /// <param name="criteria">The criteria used to filter Management Packs</param>
        /// <param name="productInfo">The information regarding the client making the webservice call</param>
        /// <param name="threeLetterLanguageCode">Three letter language code of the default language on client machine. Eg: ENU, GER etc. </param>
        /// <returns>A list of CatalogItems (Categories and Management Packs) in the selected language that satisfy the filtering criteria</returns>
        [WebMethod(Description = "This function returns the CatalogItems that can be used to build the ManagementPack tree on the UI.", EnableSession = false)]
        public Collection<CatalogItem> FindManagementPacks(CatalogManagementPackSearchCriteria criteria, ProductInfo productInfo, string threeLetterLanguageCode)
        {
            using (TraceScope scope = TraceProvider.CreateScope("FindManagementPacks"))
            {
                ////Handle Parameters

                if (criteria == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null criteria passed");
                    }

                    throw new ArgumentNullException("criteria");
                }

                if (productInfo == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null product info passed");
                    }

                    throw new ArgumentNullException("productInfo");
                }

                if (threeLetterLanguageCode == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null three letter language code passed");
                    }

                    throw new ArgumentNullException("threeLetterLanguageCode");
                }

                ////Business Logic
                try
                {
                    Collection<CatalogItem> items = new Collection<CatalogItem>();

                    ManagementPackSearchOperation managementPackSearch = new ManagementPackSearchOperation();

                    string managementPackXml = null;

                    if (criteria.InstalledManagementPacks != null && criteria.InstalledManagementPacks.Count > 0)
                    {
                        managementPackXml = this.xmlGenerator.ManagementPackXmlGet(criteria.InstalledManagementPacks);
                    }

                    if (this.traceProvider.TraceInfo)
                    {
                        scope.LogInformation("Parameters : "
                                        + "managementPackNamePattern = " + criteria.ManagementPackNamePattern
                                        + " , vendorNamePattern = " + criteria.VendorNamePattern
                                        + " , releasedOnOrAfter = " + criteria.ReleasedOnOrAfter
                                        + " , managementPackXml = " + managementPackXml
                                        + " , productName = " + productInfo.ProductName
                                        + " , productVersion = " + productInfo.ProductVersion
                                        + " , threeLetterLanguageCode = " + threeLetterLanguageCode);
                    }

                    managementPackSearch.SetParameters(criteria.ManagementPackNamePattern, criteria.VendorNamePattern, criteria.ReleasedOnOrAfter, managementPackXml, productInfo.ProductName, new Version(productInfo.ProductVersion), threeLetterLanguageCode, false);
                    managementPackSearch.Execute();
                    items = managementPackSearch.CatalogItemList;

                    return items;
                }
                catch (Exception e)
                {
                    if (this.traceProvider.TraceError)
                    {
                        scope.LogError(e.Message);
                    }

                    throw;
                }
            }
        }

        /// <summary>
        /// This function is used to fetch the catalog in a recursive manner. Given a catalog id and the depth, it returns the catalog tree structure.
        /// This function does not do any filtering on the catalog.
        /// </summary>
        /// <param name="startCatalogItem">The Catalog Item Id of the root element</param>
        /// <param name="depth">The depth that you want to go to. 0 for all Management Packs.</param>
        /// <param name="productInfo">The information regarding the client making the webservice call</param>
        /// <param name="threeLetterLanguageCode">Three letter language code of the default language on client machine. Eg: ENU, GER etc. </param>
        /// <returns>A list of CategoryItems (Categories and Management Packs) in the selected language to build the tree to the given depth</returns>
        [WebMethod(Description = "This function is used to fetch the catalog in a recursive manner. Given a catalog id and the depth, it returns the catalog tree structure.", EnableSession = false)]
        public Collection<CatalogItem> ListManagementPacks(CatalogItem startCatalogItem, int depth, ProductInfo productInfo, string threeLetterLanguageCode)
        {
            using (TraceScope scope = TraceProvider.CreateScope("ListManagementPacks"))
            {
                ////Handle Parameters

                if (startCatalogItem == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null start catalog item passed");
                    }

                    throw new ArgumentNullException("startCatalogItem");
                }

                if (productInfo == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null product info passed");
                    }

                    throw new ArgumentNullException("productInfo");
                }

                if (threeLetterLanguageCode == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null three letter language code passed");
                    }

                    throw new ArgumentNullException("threeLetterLanguageCode");
                }

                ////Business Logic
                try
                {
                    Collection<CatalogItem> items = new Collection<CatalogItem>();

                    ManagementPackListOperation managementPackList = new ManagementPackListOperation();

                    if (this.traceProvider.TraceInfo)
                    {
                        scope.LogInformation("Parameters : "
                        + "startCatalogItem = " + startCatalogItem.CatalogItemId
                        + " , depth = " + depth
                        + " , productName = " + productInfo.ProductName
                        + " , productVersion = " + productInfo.ProductVersion
                        + " , threeLetterLanguageCode = " + threeLetterLanguageCode);
                    }

                    managementPackList.SetParameters(startCatalogItem.CatalogItemId, depth, productInfo.ProductName, new Version(productInfo.ProductVersion), threeLetterLanguageCode, false);
                    managementPackList.Execute();
                    items = managementPackList.CatalogItemList;

                    return items;
                }
                catch (Exception e)
                {
                    if (this.traceProvider.TraceError)
                    {
                        scope.LogError(e.Message);
                    }

                    throw;
                }
            }
        }

        /// <summary>
        /// This function is used to get Management Pack description for a set of Management Packs given their identities.
        /// </summary>
        /// <param name="managementPackIdentities">The list of management pack identities</param>
        /// <param name="productInfo">The information regarding the client making the webservice call</param>
        /// <param name="threeLetterLanguageCode">Three letter language code of the default language on client machine. Eg: ENU, GER etc. </param>
        /// <returns>A list of catalog management pack for the list of given identities from the catalog</returns>
        [WebMethod(Description = "This function is used to get Management Pack description for a set of Management Packs given their identities.", EnableSession = false)]
        public Collection<CatalogManagementPack> GetManagementPacks(Collection<CatalogManagementPackIdentity> managementPackIdentities, ProductInfo productInfo, string threeLetterLanguageCode)
        {
            using (TraceScope scope = TraceProvider.CreateScope("GetManagementPacks"))
            {
                ////Handle Parameters

                if (managementPackIdentities == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null managementPackIdentities passed");
                    }

                    throw new ArgumentNullException("managementPackIdentities");
                }

                if (productInfo == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null product info passed");
                    }

                    throw new ArgumentNullException("productInfo");
                }

                if (threeLetterLanguageCode == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null three letter language code passed");
                    }

                    throw new ArgumentNullException("threeLetterLanguageCode");
                }

                ////Business Logic
                try
                {
                    Collection<CatalogManagementPack> items = new Collection<CatalogManagementPack>();

                    ManagementPackGetOperation managementPackGet = new ManagementPackGetOperation();

                    string managementPackXml = this.xmlGenerator.ManagementPackXmlGet(managementPackIdentities);

                    if (this.traceProvider.TraceInfo)
                    {
                        scope.LogInformation("Parameters : "
                                        + "managementPackXml = " + managementPackXml
                                        + " , productName = " + productInfo.ProductName
                                        + " , productVersion = " + productInfo.ProductVersion
                                        + " , threeLetterLanguageCode = " + threeLetterLanguageCode);
                    }

                    managementPackGet.SetParameters(managementPackXml, productInfo.ProductName, new Version(productInfo.ProductVersion), threeLetterLanguageCode, false);
                    managementPackGet.Execute();
                    items = managementPackGet.CatalogManagementPackList;

                    return items;
                }
                catch (Exception e)
                {
                    if (this.traceProvider.TraceError)
                    {
                        scope.LogError(e.Message);
                    }

                    throw;
                }
            }
        }

        /// <summary>
        /// This function is used to return the extended information for a given list of catalog item ids.
        /// </summary>
        /// <param name="catalogItemIds">The catalog items for which the extended information is needed</param>
        /// <param name="productInfo">The information regarding the client making the webservice call</param>
        /// <param name="threeLetterLanguageCode">Three letter language code of the default language on client machine. Eg: ENU, GER etc. </param>
        /// <returns>A list of extended info items for the provided ids</returns>
        [WebMethod(Description = "This function is used to return the extended information for a given list of catalog item ids.", EnableSession = false)]
        public Collection<CatalogItemExtendedInfo> GetCatalogItemExtendedInfo(Collection<int> catalogItemIds, ProductInfo productInfo, string threeLetterLanguageCode)
        {
            using (TraceScope scope = TraceProvider.CreateScope("GetCatalogItemExtendedInfo"))
            {
                ////Handle Parameters

                if (catalogItemIds == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null catalogItemIds passed");
                    }

                    throw new ArgumentNullException("catalogItemIds");
                }

                if (productInfo == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null product info passed");
                    }

                    throw new ArgumentNullException("productInfo");
                }

                if (threeLetterLanguageCode == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null three letter language code passed");
                    }

                    throw new ArgumentNullException("threeLetterLanguageCode");
                }

                ////Business Logic
                try
                {
                    Collection<CatalogItemExtendedInfo> items = new Collection<CatalogItemExtendedInfo>();

                    CatalogItemExtendedInfoGetOperation catalogItemExtendedInfoGet = new CatalogItemExtendedInfoGetOperation();

                    string catalogItemXml = this.xmlGenerator.CatalogItemXmlGet(catalogItemIds);

                    if (this.traceProvider.TraceInfo)
                    {
                        scope.LogInformation("Parameters : "
                        + "catalogItemXml = " + catalogItemXml
                        + " , productName = " + productInfo.ProductName
                        + " , productVersion = " + productInfo.ProductVersion
                        + " , threeLetterLanguageCode = " + threeLetterLanguageCode);
                    }

                    catalogItemExtendedInfoGet.SetParameters(catalogItemXml, productInfo.ProductName, new Version(productInfo.ProductVersion), threeLetterLanguageCode, false);
                    catalogItemExtendedInfoGet.Execute();
                    items = catalogItemExtendedInfoGet.CatalogItemExtendedInfoList;

                    return items;
                }
                catch (Exception e)
                {
                    if (this.traceProvider.TraceError)
                    {
                        scope.LogError(e.Message);
                    }

                    throw;
                }
            }
        }

        /// <summary>
        /// This function is used to return the extended information for a given list of Management Packs.
        /// </summary>
        /// <param name="managementPackIdentities">The management packs for which the extended information is needed</param>
        /// <param name="productInfo">The information regarding the client making the webservice call</param>
        /// <param name="threeLetterLanguageCode">Three letter language code of the default language on client machine. Eg: ENU, GER etc. </param>
        /// <returns>A list of management pack extended info items for the provided management packs</returns>
        [WebMethod(Description = "This function is used to return the extended information for a given list of Management Packs.", EnableSession = false)]
        public Collection<CatalogManagementPackExtendedInfo> GetManagementPackExtendedInfo(Collection<CatalogManagementPackIdentity> managementPackIdentities, ProductInfo productInfo, string threeLetterLanguageCode)
        {
            using (TraceScope scope = TraceProvider.CreateScope("GetManagementPackExtendedInfo"))
            {
                ////Handle Parameters

                if (managementPackIdentities == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null managementPackIdentities passed.");
                    }

                    throw new ArgumentNullException("managementPackIdentities");
                }

                if (productInfo == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null product info passed");
                    }

                    throw new ArgumentNullException("productInfo");
                }

                if (threeLetterLanguageCode == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null three letter language code passed");
                    }

                    throw new ArgumentNullException("threeLetterLanguageCode");
                }

                ////Business Logic
                try
                {
                    Collection<CatalogManagementPackExtendedInfo> items = new Collection<CatalogManagementPackExtendedInfo>();

                    ManagementPackExtendedInfoGetOperation managementPackExtendedInfoGet = new ManagementPackExtendedInfoGetOperation();

                    string managementPackXml = this.xmlGenerator.ManagementPackXmlGet(managementPackIdentities);

                    if (this.traceProvider.TraceInfo)
                    {
                        scope.LogInformation("Parameters : "
                        + "managementPackXml = " + managementPackXml
                        + " , productName = " + productInfo.ProductName
                        + " , productVersion = " + productInfo.ProductVersion
                        + " , threeLetterLanguageCode = " + threeLetterLanguageCode);
                    }

                    managementPackExtendedInfoGet.SetParameters(managementPackXml, productInfo.ProductName, new Version(productInfo.ProductVersion), threeLetterLanguageCode, false);
                    managementPackExtendedInfoGet.Execute();
                    items = managementPackExtendedInfoGet.CatalogManagementPackExtendedInfoList;

                    return items;
                }
                catch (Exception e)
                {
                    if (this.traceProvider.TraceError)
                    {
                        scope.LogError(e.Message);
                    }

                    throw;
                }
            }
        }

        /// <summary>
        /// This function returns all the dependencies that are needed to import a given set of Management Packs
        /// </summary>
        /// <param name="managementPacks">The list of selected management packs that need to be imported</param>
        /// <param name="productInfo">The information regarding the client making the webservice call</param>
        /// <param name="threeLetterLanguageCode">Three letter language code of the default language on client machine. Eg: ENU, GER etc. </param>
        /// <returns>A list of Catalog management pack dependencies</returns>
        [WebMethod(Description = "This function returns all the dependencies that are needed to import a given set of Management Packs.", EnableSession = false)]
        public Collection<CatalogManagementPackDependency> GetManagementPackDependencies(Collection<CatalogManagementPackIdentity> managementPacks, ProductInfo productInfo, string threeLetterLanguageCode)
        {
            using (TraceScope scope = TraceProvider.CreateScope("GetManagementPackDependencies"))
            {
                ////Handle Parameters
                if (managementPacks == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null managementPacks passed");
                    }

                    throw new ArgumentNullException("managementPacks");
                }

                if (productInfo == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null product info passed");
                    }

                    throw new ArgumentNullException("productInfo");
                }

                if (threeLetterLanguageCode == null)
                {
                    if (this.traceProvider.TraceWarning)
                    {
                        scope.LogWarning("Null three letter language code passed");
                    }

                    throw new ArgumentNullException("threeLetterLanguageCode");
                }

                ////Business Logic
                try
                {
                    Collection<CatalogManagementPackDependency> deps = new Collection<CatalogManagementPackDependency>();

                    ManagementPackDependenciesGetOperation managementPackDependenciesGet = new ManagementPackDependenciesGetOperation();

                    string managementPackXml = this.xmlGenerator.ManagementPackXmlGet(managementPacks);

                    if (this.traceProvider.TraceInfo)
                    {
                        scope.LogInformation("Parameters : "
                        + "managementPackXml = " + managementPackXml
                        + " , productName = " + productInfo.ProductName
                        + " , productVersion = " + productInfo.ProductVersion);
                    }

                    managementPackDependenciesGet.SetParameters(managementPackXml, productInfo.ProductName, new Version(productInfo.ProductVersion));
                    managementPackDependenciesGet.Execute();
                    deps = managementPackDependenciesGet.CatalogManagementPackDependencyList;

                    return deps;
                }
                catch (Exception e)
                {
                    if (this.traceProvider.TraceError)
                    {
                        scope.LogError(e.Message);
                    }

                    throw;
                }
            }
        }

        /// <summary>
        /// This function is used to test the webservice
        /// </summary>
        /// <returns>This function always returns true</returns>
        [WebMethod(Description = "This function is used to ping the webservice.", EnableSession = false)]
        public bool CheckWebService()
        {
            return true;
        }
   }
}