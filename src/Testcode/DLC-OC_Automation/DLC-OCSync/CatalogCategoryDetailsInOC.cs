using Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.BusinessLogic;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Dialogs;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.ManagementPackCatalogWebServiceProxy;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.Wizards.Install;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLC_OCSync
{
    public class CatalogCategoryDetailsInOC
    {
        private List<CatalogCategoryDetails> CatalogCategories = new List<CatalogCategoryDetails>();
        private Container container;
        private CatalogEngine catalogEngine;
        private CatalogServiceProxy catalogServiceProxy;
        private CatalogCache catalogCache;

        /// <summary>
        /// Constructor
        /// </summary>
        public CatalogCategoryDetailsInOC()
        {
            //this.container = new Container();
            //InitializeEngines();

            //SetCatalogCategories();
        }

        /// <summary>
        /// Initializes engines to access catalog
        /// </summary>
        private void InitializeEngines()
        {
            MPInstallWizard mpInstallWizard = new MPInstallWizard(this.container);
            this.catalogEngine = mpInstallWizard.CatalogEngine;
            this.catalogServiceProxy = mpInstallWizard.CatalogServiceProxy;
            this.catalogCache = mpInstallWizard.CatalogCache;
        }

        /// <summary>
        /// Set data in catalog engine and populates CatalogCategories
        /// </summary>
        private void SetCatalogCategories()
        {
            using (CatalogConnectionDialog catalogDialog = new CatalogConnectionDialog(this.catalogServiceProxy))
            {
                if (catalogDialog.ShowDialog() != DialogResult.OK)
                {
                    Common.Exception("Failed to connect to catalog service.");
                    return;
                }
            }

            this.catalogEngine.BackingStore.RefreshCatalogData(GetSearchCriteria());

            ReadOnlyCollection<ICatalogItem> rootNodes = this.catalogEngine.BackingStore.GetRoots();
            foreach(ICatalogItem rootNode in rootNodes)
            {
                ProcessCatalogNode(rootNode);
            }
        }


        /// <summary>
        /// Returns criteria to be searched in catalog
        /// </summary>
        /// <returns>CatalogManagementPackSearchCriteria</returns>
        private CatalogManagementPackSearchCriteria GetSearchCriteria()
        {
            CatalogManagementPackSearchCriteria criteria = new CatalogManagementPackSearchCriteria();

            criteria.ManagementPackNamePattern = "%%";
            criteria.VendorNamePattern = "%";
            criteria.InstalledManagementPacks = null;
            criteria.ReleasedOnOrAfter = new DateTime(2000, 1, 1);

            return criteria;
        }


        /// <summary>
        /// Processes a catalog node
        /// </summary>
        /// <param name="catalogNode">ICatalogItem</param>
        private void ProcessCatalogNode(ICatalogItem catalogNode)
        {
            if(this.catalogEngine.BackingStore.HasChildren(catalogNode.Id))
            {
                CategoryWrapper catalogNodeCategory = catalogNode as CategoryWrapper;

                if(HasMpFilesDirectly(catalogNode))
                {
                    foreach (ICatalogItem childItem in this.catalogEngine.BackingStore.GetChildren(catalogNode.Id))
                    {
                        if(!childItem.IsCategory)
                        {
                            CatalogMP catalogMp = childItem as CatalogMP;
                            CatalogCategoryDetails catalogCategoryDetails = new CatalogCategoryDetails(
                                catalogNode.Id,
                                catalogNodeCategory.DisplayName.Trim(),
                                -1,
                                new MPLanguage("English"),
                                childItem.Id,
                                catalogMp.VersionIndependentGuid,
                                catalogMp.Version);

                            this.CatalogCategories.Add(catalogCategoryDetails);
                            Common.AddCatalogCategoryDetails(catalogCategoryDetails);
                        }
                        else
                        {
                            ProcessLanguageCatalogNode(catalogNode, childItem);
                        }
                    }
                }
                else
                {
                    foreach (ICatalogItem childItem in this.catalogEngine.BackingStore.GetChildren(catalogNode.Id))
                    {
                        ProcessCatalogNode(childItem);
                    }
                }
            }
        }


        /// <summary>
        /// Processes language category
        /// </summary>
        /// <param name="parentNode">ICatalogItem</param>
        /// <param name="languageNode">ICatalogItem</param>
        private void ProcessLanguageCatalogNode(ICatalogItem parentNode, ICatalogItem languageNode)
        {
            CategoryWrapper parentNodeCategory = parentNode as CategoryWrapper;
            CategoryWrapper languageNodeCategory = languageNode as CategoryWrapper;
            string languageNodeName = languageNodeCategory.DisplayName.Trim();

            if (!MPLanguages.IsValid(languageNodeName))
            {
                return;
            }

            MPLanguage mpLanguage = new MPLanguage(languageNodeName);
            foreach (ICatalogItem childItem in this.catalogEngine.BackingStore.GetChildren(languageNode.Id))
            {
                if (!childItem.IsCategory)
                {
                    CatalogMP catalogMp = childItem as CatalogMP;
                    CatalogCategoryDetails catalogCategoryDetails = new CatalogCategoryDetails(
                        parentNode.Id,
                        parentNodeCategory.DisplayName.Trim(),
                        languageNode.Id,
                        mpLanguage,
                        childItem.Id,
                        catalogMp.VersionIndependentGuid,
                        catalogMp.Version);

                    this.CatalogCategories.Add(catalogCategoryDetails);
                    Common.AddCatalogCategoryDetails(catalogCategoryDetails);
                }
                else
                {
                    Common.Exception("Node (" + languageNode.Id + ", " + mpLanguage.DisplayName + ") is a language category. It should not have sub categories inside it." );
                }
            }
        }


        /// <summary>
        /// Checks if catalog node has MP/MPB files directly in it
        /// </summary>
        /// <param name="catalogNode">ICatalogItem</param>
        /// <returns>bool</returns>
        private bool HasMpFilesDirectly(ICatalogItem catalogNode)
        {
            List<ICatalogItem> catalogNodeChildren = new List<ICatalogItem>(this.catalogEngine.BackingStore.GetChildren(catalogNode.Id));
            return catalogNodeChildren.Exists(x => x.IsCategory == false);
        }


        /// <summary>
        /// Find all matching CatalogCategoryDetails
        /// </summary>
        /// <param name="catalogItemId">int</param>
        /// <param name="name">string</param>
        /// <param name="languageCatalogItemId">int</param>
        /// <param name="language">string</param>
        /// <returns>List<CatalogCategoryDetails></returns>
        public List<CatalogCategoryDetails> Find(int catalogItemId, string name, int languageCatalogItemId, string language)
        {
            List<CatalogCategoryDetails> catalogCategoryDetails = new List<CatalogCategoryDetails>();
            /*
            if (catalogItemId != Int32.MinValue)
            {
                catalogCategoryDetails.AddRange(this.CatalogCategories.FindAll(x => x.CatalogItemId == catalogItemId));
            }
            else if(string.IsNullOrEmpty(name))
            {
                catalogCategoryDetails.AddRange(this.CatalogCategories.FindAll(x => x.Name == name));
            }

            if(languageCatalogItemId != Int32.MinValue)
            {
                catalogCategoryDetails.RemoveAll(x => x.LanguageCatalogItemId != languageCatalogItemId);
            }
            else if(string.IsNullOrEmpty(language))
            {
                catalogCategoryDetails.RemoveAll(x => x.Language.DisplayName != language);
            }

            if(catalogCategoryDetails.Count == 0)
            {
                catalogCategoryDetails.AddRange(Fetch(catalogItemId, languageCatalogItemId));
            }*/

            catalogCategoryDetails.AddRange(GetImmediateMPsFromOC(languageCatalogItemId));

            return catalogCategoryDetails;
        }

        public List<CatalogCategoryDetails> Find(List<string> catalogItemIds)
        {
            StringBuilder categories = new StringBuilder();
            bool isFirst = true;
            foreach(string id in catalogItemIds)
            {
                if(isFirst)
                {
                    isFirst = false;
                    categories.Append(id);
                }
                else
                {
                    categories.Append(", ");
                    categories.Append(id);
                }
            }

            return GetImmediateMPsCategories(categories.ToString());

        }


        /// <summary>
        /// Queries online catalog to get data.
        /// </summary>
        /// <param name="catalogItemId">int</param>
        /// <param name="languageCatalogItemId">int</param>
        /// <returns>List<CatalogCategoryDetails></returns>
        private List<CatalogCategoryDetails> Fetch(int catalogItemId, int languageCatalogItemId)
        {
            List<CatalogCategoryDetails> catalogCategoryDetails = new List<CatalogCategoryDetails>();

            if(languageCatalogItemId != Int32.MinValue)
            {
                catalogCategoryDetails.AddRange(GetImmediateMPsFromOC(languageCatalogItemId));
            }
            else if(catalogItemId != Int32.MinValue)
            {
                catalogCategoryDetails.AddRange(GetAllMPsFromOC(catalogItemId));
            }

            return catalogCategoryDetails;
        }

        /// <summary>
        /// Get immediate MP/MPBs present in a category
        /// </summary>
        /// <param name="catalogItemId">int</param>
        /// <returns>List<CatalogCategoryDetails></returns>
        private List<CatalogCategoryDetails> GetImmediateMPsFromOC(int catalogItemId)
        {
            List<CatalogCategoryDetails> catalogCategoryDetails = new List<CatalogCategoryDetails>();
            const string SELECT_QUERY = "SELECT CMPC.CategoryCatalogItemId, CMP.CatalogItemId, CMP.VersionIndependentGuid, CMP.Version "
                + "FROM [SystemCenter].[dbo].[CatalogManagementPackCategory] as CMPC, [SystemCenter].[dbo].[CatalogManagementPack] as CMP, [SystemCenter].[dbo].[CatalogItem] as CI "
                + "WHERE CMPC.CategoryCatalogItemId = '{0}' "
                + "AND CMPC.ManagementPackCatalogItemId = CMP.CatalogItemId "
                + "AND CMP.CatalogItemId = CI.CatalogItemId "
                + "AND CI.PublishedInd = '1'";

            using (SqlConnection connection = new SqlConnection(Common.OC_CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand command;
                SqlDataReader reader;

                string query = string.Format(SELECT_QUERY, catalogItemId);

                command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int categoryCatalogItemId = Int32.Parse(reader[0].ToString());
                        int mpCatalogItemId = Int32.Parse(reader[1].ToString());
                        Guid versionIndependentGuid = new Guid(reader[2].ToString());
                        Version version = new Version(reader[3].ToString());

                        catalogCategoryDetails.Add(new CatalogCategoryDetails(Int32.MinValue, string.Empty, categoryCatalogItemId, null, mpCatalogItemId, versionIndependentGuid, version));
                    }
                }

                reader.Close();
                connection.Close();
            }

            return catalogCategoryDetails;
        }

        /// <summary>
        /// Get immediate MP/MPBs present in categories
        /// </summary>
        /// <param name="catalogItemId">int</param>
        /// <returns>List<CatalogCategoryDetails></returns>
        private List<CatalogCategoryDetails> GetImmediateMPsCategories(string categories)
        {
            List<CatalogCategoryDetails> catalogCategoryDetails = new List<CatalogCategoryDetails>();
            const string SELECT_QUERY = "SELECT CMPC.CategoryCatalogItemId, CMP.CatalogItemId, CMP.VersionIndependentGuid, CMP.Version "
                + "FROM [SystemCenter].[dbo].[CatalogManagementPackCategory] as CMPC, [SystemCenter].[dbo].[CatalogManagementPack] as CMP, [SystemCenter].[dbo].[CatalogItem] as CI "
                + "WHERE CMPC.CategoryCatalogItemId in ({0}) "
                + "AND CMPC.ManagementPackCatalogItemId = CMP.CatalogItemId "
                + "AND CMP.CatalogItemId = CI.CatalogItemId "
                + "AND CI.PublishedInd = '1'";

            using (SqlConnection connection = new SqlConnection(Common.OC_CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand command;
                SqlDataReader reader;

                string query = string.Format(SELECT_QUERY, categories);

                command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int categoryCatalogItemId = Int32.Parse(reader[0].ToString());
                        int mpCatalogItemId = Int32.Parse(reader[1].ToString());
                        Guid versionIndependentGuid = new Guid(reader[2].ToString());
                        Version version = new Version(reader[3].ToString());

                        catalogCategoryDetails.Add(new CatalogCategoryDetails(Int32.MinValue, string.Empty, categoryCatalogItemId, null, mpCatalogItemId, versionIndependentGuid, version));
                    }
                }

                reader.Close();
                connection.Close();
            }

            return catalogCategoryDetails;
        }

        /// <summary>
        /// Get all MP/MPBs present in a category
        /// </summary>
        /// <param name="catalogItemId">int</param>
        /// <returns>List<CatalogCategoryDetails></returns>
        private List<CatalogCategoryDetails> GetAllMPsFromOC(int catalogItemId)
        {
            List<CatalogCategoryDetails> catalogCategoryDetails = new List<CatalogCategoryDetails>();
            const string SELECT_QUERY = "SELECT CMPC.CategoryCatalogItemId, CMP.CatalogItemId, CMP.VersionIndependentGuid, CMP.Version "
                + "FROM [SystemCenter].[dbo].[CatalogManagementPackCategory] as CMPC, [SystemCenter].[dbo].[CatalogManagementPack] as CMP, [SystemCenter].[dbo].[CatalogItem] as CI "
                + "WHERE CMPC.CategoryCatalogItemId in (SELECT CatalogItemId FROM CatalogCategory WHERE ParentCategoryId = '{0}' AND CatalogItemId = '{0}') "
                + "AND CMPC.ManagementPackCatalogItemId = CMP.CatalogItemId "
                + "AND CMP.CatalogItemId = CI.CatalogItemId "
                + "AND CI.PublishedInd = '1'";

            using (SqlConnection connection = new SqlConnection(Common.OC_CONNECTION_STRING))
            {
                connection.Open();

                SqlCommand command;
                SqlDataReader reader;

                string query = string.Format(SELECT_QUERY, catalogItemId);

                command = new SqlCommand(SELECT_QUERY, connection);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int categoryCatalogItemId = Int32.Parse(reader[0].ToString());
                        int mpCatalogItemId = Int32.Parse(reader[1].ToString());
                        Guid versionIndependentGuid = new Guid(reader[2].ToString());
                        Version version = new Version(reader[3].ToString());

                        catalogCategoryDetails.Add(new CatalogCategoryDetails(catalogItemId, string.Empty, categoryCatalogItemId, null, mpCatalogItemId, versionIndependentGuid, version));
                    }
                }

                reader.Close();
                connection.Close();
            }

            return catalogCategoryDetails;
        }
    }
}
