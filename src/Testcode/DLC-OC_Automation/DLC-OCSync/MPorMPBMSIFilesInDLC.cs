using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLC_OCSync
{
    public class MPorMPBMSIFilesInDLC
    {
        private Dictionary<string, string> urlAndProductIds;
        private MPorMPBDetailsInDLC mpOrMPBDetailsInDLC;
        private CatalogMPorMPBDetailsInOC catalogMPorMPBDetailsInOC;
        private CatalogCategoryDetailsInOC catalogCategoryDetailsInOC;
        private MsiToCategoryMapping msiToCategoryMapping;
        private MsiToCategoriesMapping msiToCategoriesMapping;

        /// <summary>
        /// Constructor
        /// </summary>
        private MPorMPBMSIFilesInDLC()
        {
            urlAndProductIds = GetMPorMPBMSIUrlsInDLC();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mpOrMPBDetailsInDLC">MPorMPBDetailsInDLC</param>
        /// <param name="catalogMPorMPBDetailsInOC">CatalogMPorMPBDetailsInOC</param>
        /// <param name="catalogCategoryDetailsInOC">CatalogCategoryDetailsInOC</param>
        /// <param name="msiToCategoryMapping">MsiToCategoryMapping</param>
        public MPorMPBMSIFilesInDLC(MPorMPBDetailsInDLC mpOrMPBDetailsInDLC, CatalogMPorMPBDetailsInOC catalogMPorMPBDetailsInOC, CatalogCategoryDetailsInOC catalogCategoryDetailsInOC, MsiToCategoryMapping msiToCategoryMapping, MsiToCategoriesMapping msiToCategoriesMapping) : this()
        {
            this.mpOrMPBDetailsInDLC = mpOrMPBDetailsInDLC;
            this.catalogMPorMPBDetailsInOC = catalogMPorMPBDetailsInOC;
            this.catalogCategoryDetailsInOC = catalogCategoryDetailsInOC;
            this.msiToCategoryMapping = msiToCategoryMapping;
            this.msiToCategoriesMapping = msiToCategoriesMapping;

            Parallel.ForEach(urlAndProductIds.Keys, new ParallelOptions { MaxDegreeOfParallelism = 6 }, url =>
            {
                ProcessMSIUrl(url, urlAndProductIds[url]);
            });
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~MPorMPBMSIFilesInDLC()
        {
        }

        /// <summary>
        /// Get list of all msi urls related to management packs
        /// </summary>
        /// <returns>Dictionary<string, string></returns>
        private Dictionary<string, string> GetMPorMPBMSIUrlsInDLC()
        {
            Dictionary<string, string> urlsAndProductIds = new Dictionary<string, string>();
            const string SELECT_QUERY = "SELECT DISTINCT F.URL, P.ProductID "
                + "FROM[Downloads2].[dbo].[Files] as F, "
                    + "[Downloads2].[dbo].[FamilyRelease] as FR, "
                    + "[Omni].[dbo].[Product] as P, "
                    + "[Omni].[dbo].[ProductDetails] as PD "
                + "WHERE P.ProductID = PD.ProductID "
                    + "AND PD.ProductName like '%management pack%' "
                    + "AND F.ReleaseID = FR.ReleaseID "
                    + "AND F.URL like '%.msi' "
                    + "AND F.Display = '1' "
                    + "AND FR.FamilyID = P.MarketPlaceProductIdentifier";

            using (SqlConnection connection = new SqlConnection(Common.DLC_CONNECTION_STRING))
            {
                //connection.Open();
                int attempt = 5;
                while (attempt-- > 0)
                {
                    try
                    {
                        connection.Open();
                        break;
                    }
                    catch
                    {
                        System.Threading.Thread.Sleep(5000);    //Wait for 5s
                    }
                }

                SqlCommand command;
                SqlDataReader reader;
                string url;
                string productId;

                command = new SqlCommand(SELECT_QUERY, connection);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        url = reader[0].ToString();
                        productId = reader[1].ToString();
                        if(!urlsAndProductIds.ContainsKey(url) && !urlsAndProductIds.ContainsValue(productId))
                        {
                            urlsAndProductIds.Add(url, productId);
                        }
                    }
                }

                reader.Close();
                connection.Close();
            }

            return urlsAndProductIds;
        }

        /// <summary>
        /// Processes Url of MSI file to cache with file
        /// </summary>
        /// <param name="url">string</param>
        /// <param name="productId">string</param>
        private void ProcessMSIUrl(string url, string productId)
        {
            DownloadFile downloadFile = new DownloadFile(url);
            if(DownloadStatus.Failure == downloadFile.Status)
            {
                Common.AddMSIFileDetails(productId, url, downloadFile.Status, null);
                return;
            }

            string file = downloadFile.LocalPath;
            MSIFile msiFile = new MSIFile(this.mpOrMPBDetailsInDLC, url, productId);
            Common.AddMSIFileDetails(productId, url, downloadFile.Status, msiFile);
            if (false == msiFile.ExistsInDLC())
            {
                Common.AddMissingMSIInDLCDetails(msiFile);
            }

            CompareWithOnlineCatalog(productId, msiFile);

            //CompareOneMsiWithManyCategory(productId, msiFile);
        }

        private void CompareOneMsiWithManyCategory(string productId, MSIFile msiFile)
        {
            List<string> categories = this.msiToCategoriesMapping.GetDetails(msiFile.MsiUrl);

            if(categories != null)
            {
                List<CatalogCategoryDetails> catalogCategoryDetailsNotFound = this.catalogCategoryDetailsInOC.Find(categories);

                List<MPorMPBDetails> mpOrMpbDetails = msiFile.GetMPorMPBDetailsInDLC();
                List<MPorMPBDetails> mpOrMpbDetailsNotFound = new List<MPorMPBDetails>(mpOrMpbDetails);
                foreach (MPorMPBDetails mpOrMpbDetail in mpOrMpbDetails)
                {
                    if (catalogCategoryDetailsNotFound.Exists(x => x.VersionIndependentGuid.ToString() == mpOrMpbDetail.VersionIndependentGuid.ToString()
                        && x.Version.ToString() == mpOrMpbDetail.Version.ToString()))
                    {
                        catalogCategoryDetailsNotFound.RemoveAll(x => x.VersionIndependentGuid.ToString() == mpOrMpbDetail.VersionIndependentGuid.ToString()
                        && x.Version.ToString() == mpOrMpbDetail.Version.ToString());
                        mpOrMpbDetailsNotFound.Remove(mpOrMpbDetail);
                    }
                }

                // Items that needs to be mapped is not req for 1-MSI to Many-Category case

                // Items that needs to be unmapped
                const string MP_TO_CATEGORY_UNMAP_QUERY = "exec[dbo].[CatalogManagementPackCategoryUnSet] '{0}', '{1}'";
                foreach (CatalogCategoryDetails catalogCategoryDetail in catalogCategoryDetailsNotFound)
                {
                    int categoryId = (catalogCategoryDetail.LanguageCatalogItemId != -1) ? catalogCategoryDetail.LanguageCatalogItemId : catalogCategoryDetail.CatalogItemId;

                    string query = string.Format(MP_TO_CATEGORY_UNMAP_QUERY, catalogCategoryDetail.MpCatalogItemId, categoryId);
                    //Common.AddMappingOrUnmappingDetails("Unmapping required", productId, msiFile.MsiUrl, catalogCategoryDetail.Name, catalogCategoryDetail.Language.DisplayName, query);
                    Common.AddMappingOrUnmappingDetails("Unmapping required", query);
                }
            }

        }
        /// <summary>
        /// Checks MSI file content with OC
        /// </summary>
        /// <param name="productId">string</param>
        /// <param name="msiFile">MSIFile</param>
        private void CompareWithOnlineCatalog(string productId, MSIFile msiFile)
        {
            MsiToCategory msiToCategory = this.msiToCategoryMapping.GetDetails(productId, msiFile.MsiUrl);

            if(null != msiToCategory)
            {
                if(string.IsNullOrEmpty(msiToCategory.CategoryName) && string.IsNullOrEmpty(msiToCategory.CatalogItemId))
                {
                    Common.Exception("Product Id " + productId  + " and msi url " + msiFile.MsiUrl + "is not mapped to any category.");
                    return;
                }

                int categoryCatalogItemId = Int32.MinValue;
                int languageCategoryCatalogItemId = Int32.MinValue;
                if (!string.IsNullOrEmpty(msiToCategory.CatalogItemId))
                {
                    Int32.TryParse(msiToCategory.CatalogItemId, out categoryCatalogItemId);
                }
                if (!string.IsNullOrEmpty(msiToCategory.LanguageId))
                {
                    Int32.TryParse(msiToCategory.LanguageId, out languageCategoryCatalogItemId);
                }
                if(languageCategoryCatalogItemId < 0)
                {
                    languageCategoryCatalogItemId = Int32.MinValue;
                }

                List<CatalogCategoryDetails> catalogCategoryDetailsNotFound = this.catalogCategoryDetailsInOC.Find(categoryCatalogItemId, msiToCategory.CategoryName, languageCategoryCatalogItemId, msiToCategory.Language);

                List<MPorMPBDetails> mpOrMpbDetails = msiFile.GetMPorMPBDetailsInDLC();
                List<MPorMPBDetails> mpOrMpbDetailsNotFound = new List<MPorMPBDetails>(mpOrMpbDetails);
                foreach (MPorMPBDetails mpOrMpbDetail in mpOrMpbDetails)
                {
                    if(catalogCategoryDetailsNotFound.Exists(x => x.VersionIndependentGuid.ToString() == mpOrMpbDetail.VersionIndependentGuid.ToString()
                        && x.Version.ToString() == mpOrMpbDetail.Version.ToString()))
                    {
                        catalogCategoryDetailsNotFound.RemoveAll(x => x.VersionIndependentGuid.ToString() == mpOrMpbDetail.VersionIndependentGuid.ToString()
                        && x.Version.ToString() == mpOrMpbDetail.Version.ToString());
                        mpOrMpbDetailsNotFound.Remove(mpOrMpbDetail);
                    }
                }

                // Items that needs to be mapped
                const string MP_TO_CATEGORY_MAP_QUERY = "exec[dbo].[CatalogManagementPackCategorySet] '{0}', '{1}'";
                foreach (MPorMPBDetails mpOrMpbDetail in mpOrMpbDetailsNotFound)
                {
                    int cmpCatalogId = Int32.MinValue;
                    CatalogMPorMPBDetails catalogMPorMPBDetail = this.catalogMPorMPBDetailsInOC.Find(mpOrMpbDetail.VersionIndependentGuid, mpOrMpbDetail.Version);
                    if(null == catalogMPorMPBDetail)
                    {
                        Common.Exception("Could not find guid " + mpOrMpbDetail.VersionIndependentGuid + " version " + mpOrMpbDetail.Version + " in catalog cache.");
                        continue;
                    }
                    cmpCatalogId = catalogMPorMPBDetail.catalogItemId;

                    int categoryId = (languageCategoryCatalogItemId != Int32.MinValue) ? languageCategoryCatalogItemId : categoryCatalogItemId;

                    string query = string.Format(MP_TO_CATEGORY_MAP_QUERY, cmpCatalogId, categoryId);
                    //Common.AddMappingOrUnmappingDetails("Mapping required", productId, msiFile.MsiUrl, msiToCategory.CategoryName, msiToCategory.Language, query);
                    Common.AddMappingOrUnmappingDetails("Mapping required", query);
                }

                // Items that needs to be unmapped
                const string MP_TO_CATEGORY_UNMAP_QUERY = "exec[dbo].[CatalogManagementPackCategoryUnSet] '{0}', '{1}'";
                foreach(CatalogCategoryDetails catalogCategoryDetail in catalogCategoryDetailsNotFound)
                {
                    int categoryId = (catalogCategoryDetail.LanguageCatalogItemId != -1) ? catalogCategoryDetail.LanguageCatalogItemId : catalogCategoryDetail.CatalogItemId;

                    string query = string.Format(MP_TO_CATEGORY_UNMAP_QUERY, catalogCategoryDetail.MpCatalogItemId, categoryId);
                    //Common.AddMappingOrUnmappingDetails("Unmapping required", productId, msiFile.MsiUrl, catalogCategoryDetail.Name, catalogCategoryDetail.Language.DisplayName, query);
                    Common.AddMappingOrUnmappingDetails("Unmapping required", query);
                }
            }
            else if (this.msiToCategoriesMapping.GetDetails(msiFile.MsiUrl) != null)
            {
                CompareOneMsiWithManyCategory(productId, msiFile);
            }
            else
            {
                Common.Exception("Could not find mapping in metadata file for product ID " + productId + " and msi " + msiFile.MsiUrl);
                return;
            }
        }
    }
}
