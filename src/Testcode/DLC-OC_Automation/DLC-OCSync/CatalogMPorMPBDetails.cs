using Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLC_OCSync
{
    public enum OCIntegrityStatus
    {
        None,
        Verified,
        Error
    }

    public class CatalogMPorMPBDetails
    {
        public int catalogItemId { get; set; }
        private MPorMPBDetails mpOrMPBDetails;
        private string url;
        private bool publishedInd;

        /// <summary>
        /// Constructor
        /// </summary>
        private CatalogMPorMPBDetails()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="catalogItemId">int</param>
        /// <param name="versionIndependentGuid">Guid</param>
        /// <param name="version">Version</param>
        /// <param name="systemName">string</param>
        /// <param name="displayName">string</param>
        /// <param name="description">string</param>
        /// <param name="publishedInd">bool</param>
        public CatalogMPorMPBDetails(int catalogItemId, Guid versionIndependentGuid, Version version, string systemName, string publicKeyToken, string displayName, string description, string url, bool publishedInd) : this()
        {
            this.catalogItemId = catalogItemId;
            this.mpOrMPBDetails = new MPorMPBDetails(versionIndependentGuid, version, systemName, publicKeyToken, displayName, description);
            this.url = url;
            this.publishedInd = publishedInd;
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~CatalogMPorMPBDetails()
        {
        }

        /// <summary>
        /// Checks and update online catalog data with urls
        /// </summary>
        /// <returns>OCIntegrityStatus</returns>
        public OCIntegrityStatus CheckOCIntegrity()
        {
            DownloadFile downloadFile = new DownloadFile(this.url);
            if(DownloadStatus.Failure == downloadFile.Status)
            {
                UnPublishCatalogMPs(GetCatalogItemId(url));
                return OCIntegrityStatus.Error;
            }

            MPorMPBDetails urlMPorMPBDetails = new MPorMPBDetails(downloadFile.LocalPath);
            if(!mpOrMPBDetails.EqualsWithoutDependencies(urlMPorMPBDetails))
            {
                UpdateCatalog(urlMPorMPBDetails);
                AddDependencies(urlMPorMPBDetails);
            }
            return OCIntegrityStatus.Verified;
        }

        /// <summary>
        /// Adds all dependencies for this catalog MP/MPB
        /// </summary>
        /// <param name="mpOrMPBDetails">MPorMPBDetails</param>
        private void AddDependencies(MPorMPBDetails mpOrMPBDetails)
        {
            const string UPDATE_QUERY = "EXEC [SystemCenter].[dbo].[CatalogManagementPackDependencySet] '{0}', '{1}', '{2}'";

            using (SqlConnection connection = new SqlConnection(Common.OC_CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command;

                foreach (MPIdentity dependency in mpOrMPBDetails.Dependencies)
                {
                    try
                    {
                        string query = string.Format(UPDATE_QUERY, this.catalogItemId, dependency.VersionIndependentGuid.ToString(), dependency.Version.ToString());
                        Common.OCQueryLog(query);

                        command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                    catch(Exception e)
                    {
                        Common.Exception("Failed to add dependency " + this.catalogItemId + " " + dependency.VersionIndependentGuid.ToString() + " " + dependency.Version.ToString());
                    }
                }
            }

            this.mpOrMPBDetails.Dependencies = mpOrMPBDetails.Dependencies;
        }

        /// <summary>
        /// Update online catalog
        /// </summary>
        /// <param name="urlMPorMPBDetails"></param>
        private void UpdateCatalog(MPorMPBDetails urlMPorMPBDetails)
        {
            const string UPDATE_QUERY = "EXEC [SystemCenter].[dbo].[CatalogManagementPackSet] '{0}', N'{1}', N'{2}', '{3}', '{4}', '{5}', '{6}', '{7}', null, null, '', null, null, null, null, '', ''";

            using (SqlConnection connection = new SqlConnection(Common.OC_CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command;

                try
                {
                    string mpDisplayName = "";
                    if (!string.IsNullOrEmpty(urlMPorMPBDetails.DisplayName))
                    {
                        mpDisplayName = urlMPorMPBDetails.DisplayName.Replace("'", "''");
                    }

                    string mpDescription = "";
                    if (!string.IsNullOrEmpty(urlMPorMPBDetails.Description))
                    {
                        mpDescription = urlMPorMPBDetails.Description.Replace("'", "''");
                    }

                    string publicKeyToken = "";
                    if(!string.IsNullOrEmpty(urlMPorMPBDetails.PublicKeyToken))
                    {
                        publicKeyToken = urlMPorMPBDetails.PublicKeyToken;
                    }

                    string currentDate = DateTime.Now.ToString("g");

                    string query = string.Format(UPDATE_QUERY, this.catalogItemId, mpDisplayName, mpDescription, urlMPorMPBDetails.VersionIndependentGuid.ToString(), urlMPorMPBDetails.Version.ToString(), urlMPorMPBDetails.SystemName, publicKeyToken, currentDate);

                    command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();

                    this.mpOrMPBDetails = new MPorMPBDetails(urlMPorMPBDetails.VersionIndependentGuid, urlMPorMPBDetails.Version, urlMPorMPBDetails.SystemName, publicKeyToken, urlMPorMPBDetails.DisplayName, urlMPorMPBDetails.Description);
                    Common.OCUpdateQuery("OC Integrity violation", this.catalogItemId, string.Empty, this.mpOrMPBDetails, query);
                }
                catch (Exception e)
                {
                    Common.Exception("Failed to update catalog for catalog item " + this.catalogItemId);
                }

                connection.Close();
            }
        }

        /// <summary>
        /// hecks for equality but does not considers dependencies
        /// </summary>
        /// <param name="mpOrMPBDetails">MPorMPBDetails</param>
        /// <returns>bool</returns>
        public bool EqualsWithoutDependencies(MPorMPBDetails mpOrMPBDetails)
        {
            return this.mpOrMPBDetails.EqualsWithoutDependencies(mpOrMPBDetails);
        }

        /// <summary>
        /// Gets catalogitemId from catalog
        /// </summary>
        /// <param name="versionIndependentGuid">Guid</param>
        /// <param name="version">Version</param>
        /// <returns>int</returns>
        public static int GetCatalogItemId(Guid versionIndependentGuid, Version version)
        {
            int catalogItemId = 0;
            const string SELECT_QUERY = "SELECT CatalogItemId "
                + "FROM [SystemCenter].[dbo].[CatalogManagementPack] "
                + "WHERE VersionIndependentGuid = '{0}' "
                + "AND Version = '{1}' ";

            using (SqlConnection connection = new SqlConnection(Common.OC_CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command;
                SqlDataReader reader;

                try
                {
                    string query = string.Format(SELECT_QUERY, versionIndependentGuid, version);
                    command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            catalogItemId = Int32.Parse(reader[0].ToString());
                        }
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Common.Exception("Failed to get catalog item id for " + versionIndependentGuid.ToString() + ", " + version.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }

            return catalogItemId;
        }

        /// <summary>
        /// Gets catalogitemId from catalog
        /// </summary>
        /// <param name="url">string</param>
        /// <returns>List<int></returns>
        public static List<int> GetCatalogItemId(string url)
        {
            List<int> catalogItemIds = new List<int>();

            const string SELECT_QUERY = "SELECT Distinct(CatalogItemId) "
                + "FROM [SystemCenter].[dbo].[CatalogManagementPack] "
                + "WHERE DownloadUri = '{0}' ";

            using (SqlConnection connection = new SqlConnection(Common.OC_CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command;
                SqlDataReader reader;

                try
                {
                    string query = string.Format(SELECT_QUERY, url);
                    command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            catalogItemIds.Add(Int32.Parse(reader[0].ToString()));
                        }
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Common.Exception("Failed to get catalog item ids for url " + url);
                }
                finally
                {
                    connection.Close();
                }
            }

            return catalogItemIds;
        }

        /// <summary>
        /// Publish MPs in online catalog
        /// </summary>
        /// <param name="catalogItemIds">List<int></param>
        private void UnPublishCatalogMPs(List<int> catalogItemIds)
        {
            const string UPDATE_QUERY = "EXEC [SystemCenter].[dbo].[CatalogManagementPackSet] '{0}',null,null,null,null,null,null,null,null,null,null,null,null,null,'0',null,null";

            using (SqlConnection connection = new SqlConnection(Common.OC_CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command;

                foreach (int catalogItemId in catalogItemIds)
                {
                    try
                    {
                        string query = string.Format(UPDATE_QUERY, catalogItemId);

                        command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();

                        Common.OCUpdateQuery("Url download failed", this.catalogItemId, "", null, query);
                    }
                    catch (Exception e)
                    {
                        Common.Exception("Failed to unpublish " + catalogItemId);
                    }
                }

                connection.Close();
            }
        }

        /// <summary>
        /// Compares with Version independent guid and version
        /// </summary>
        /// <param name="versionIndependentGuid">Guid</param>
        /// <param name="version">Version</param>
        /// <returns>bool</returns>
        public bool Equals(Guid versionIndependentGuid, Version version)
        {
            return this.mpOrMPBDetails.VersionIndependentGuid.ToString() == versionIndependentGuid.ToString() && this.mpOrMPBDetails.Version.ToString() == version.ToString();
        }
    }
}
