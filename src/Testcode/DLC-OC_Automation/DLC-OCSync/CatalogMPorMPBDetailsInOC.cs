using Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLC_OCSync
{
    public class CatalogMPorMPBDetailsInOC
    {
        private List<CatalogMPorMPBDetails> CatalogMPorMPBs;

        /// <summary>
        /// Constructor
        /// </summary>
        public CatalogMPorMPBDetailsInOC()
        {
            this.CatalogMPorMPBs = GetCatalogMPorMPBsFromOC();
            CheckingOCIntegrity();
        }

        /// <summary>
        /// Fetch list of published MPs or MPBs from Online Catalog
        /// </summary>
        /// <returns>List<CatalogMPorMPBDetails></returns>
        private List<CatalogMPorMPBDetails> GetCatalogMPorMPBsFromOC()
        {
            List<CatalogMPorMPBDetails> catalogMPorMPBs = new List<CatalogMPorMPBDetails>();
            /*const string SELECT_QUERY = "SELECT CMP.CatalogItemID, CMP.VersionIndependentGuid, CMP.Version, CMP.SystemName, CMP.PublicKey, CI.DefaultDisplayName, CI.DefaultDescription, CMP.DownloadURI, CI.PublishedInd "
                + "FROM [SystemCenter].[dbo].[CatalogManagementPack] as CMP, [SystemCenter].[dbo].[CatalogItem] as CI "
                + "WHERE CMP.CatalogItemId = CI.CatalogItemId "
                + "AND CI.PublishedInd = '1'";
            */
            const string SELECT_QUERY = "SELECT CMP.CatalogItemID, CMP.VersionIndependentGuid, CMP.Version, CMP.SystemName, CMP.PublicKey, CI.DefaultDisplayName, CI.DefaultDescription, CMP.DownloadURI, CI.PublishedInd "
                + "FROM [SystemCenter].[dbo].[CatalogManagementPack] as CMP, [SystemCenter].[dbo].[CatalogItem] as CI "
                + "WHERE CMP.CatalogItemId = CI.CatalogItemId "
                + "AND CI.PublishedInd = '1' AND CMP.DownloadURI like '%microsoft.com%'";

            using (SqlConnection connection = new SqlConnection(Common.OC_CONNECTION_STRING))
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

                command = new SqlCommand(SELECT_QUERY, connection);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int catalogItemId = Int32.Parse(reader[0].ToString());
                        Guid versionIndependentGuid = new Guid(reader[1].ToString());
                        Version version = new Version(reader[2].ToString());
                        string systemName = reader[3].ToString();
                        string publicKeyToken = reader[4].ToString();
                        string displayName = reader[5].ToString();
                        string description = reader[6].ToString();
                        string url = reader[7].ToString();
                        bool publishedInd = true;
                        if("0" == reader[8].ToString())
                        {
                            publishedInd = false;
                        }

                        catalogMPorMPBs.Add(new CatalogMPorMPBDetails(catalogItemId, versionIndependentGuid, version, systemName, publicKeyToken, displayName, description, url, publishedInd));
                    }
                }

                reader.Close();
                connection.Close();
            }

            return catalogMPorMPBs;
        }

        /// <summary>
        /// Checking for data correctness in OC.
        /// </summary>
        private void CheckingOCIntegrity()
        {
            List<CatalogMPorMPBDetails> removeList = new List<CatalogMPorMPBDetails>();

            Parallel.ForEach(CatalogMPorMPBs, catalogMPorMPB =>
                {
                    if(OCIntegrityStatus.Error == catalogMPorMPB.CheckOCIntegrity())
                    {
                        lock(removeList)
                        {
                            removeList.Add(catalogMPorMPB);
                        }
                    }
                });

            foreach(CatalogMPorMPBDetails catalogMPorMPB in removeList)
            {
                this.CatalogMPorMPBs.Remove(catalogMPorMPB);
            }
        }

        /// <summary>
        /// Checks cache contains given MPorMPBDetails
        /// </summary>
        /// <param name="mpOrMPBDetails">MPorMPBDetails</param>
        /// <returns></returns>
        public bool Exists(MPorMPBDetails mpOrMPBDetails)
        {
            return CatalogMPorMPBs.Exists(x => x.EqualsWithoutDependencies(mpOrMPBDetails));
        }

        /// <summary>
        /// Inserts into OC if mpOrMPBDetails does not exists
        /// </summary>
        /// <param name="url">string</param>
        /// <param name="mpOrMPBDetails">MPorMPBDetails</param>
        public void CheckAndAdd(string url, MPorMPBDetails mpOrMPBDetails)
        {
            if(!Exists(mpOrMPBDetails))
            {
                InsertIntoCatalog(url, mpOrMPBDetails);
            }
        }

        /// <summary>
        /// Creates new record in OC
        /// </summary>
        /// <param name="url">string</param>
        /// <param name="mpOrMPBDetails"></param>
        private void InsertIntoCatalog(string url, MPorMPBDetails mpOrMPBDetails)
        {
            const string INSERT_QUERY = "EXEC [SystemCenter].[dbo].[CatalogManagementPackSet] 0, N'{0}', N'{1}', '{2}', '{3}', '{4}', '{5}', '{6}', 2, '{7}', '', '0', '', '0', '1', '', ''";

            const string CatalogProductSet11_Query = "EXEC [SystemCenter].[dbo].[CatalogProductCatalogItemSet] {0}, 11";
            const string CatalogProductSet12_Query = "EXEC [SystemCenter].[dbo].[CatalogProductCatalogItemSet] {0}, 12";
            const string CatalogProductSet13_Query = "EXEC [SystemCenter].[dbo].[CatalogProductCatalogItemSet] {0}, 13";
            const string CatalogProductSet14_Query = "EXEC [SystemCenter].[dbo].[CatalogProductCatalogItemSet] {0}, 14";

            using (SqlConnection connection = new SqlConnection(Common.OC_CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command;
                int catalogItemId;

                try
                {
                    string mpDisplayName = "";
                    if (!string.IsNullOrEmpty(mpOrMPBDetails.DisplayName))
                    {
                        mpDisplayName = mpOrMPBDetails.DisplayName.Replace("'", "''");
                    }

                    string mpDescription = "";
                    if (!string.IsNullOrEmpty(mpOrMPBDetails.Description))
                    {
                        mpDescription = mpOrMPBDetails.Description.Replace("'", "''");
                    }

                    string publicKeyToken = "31bf3856ad364e35";
                    if(!string.IsNullOrEmpty(mpOrMPBDetails.PublicKeyToken))
                    {
                        publicKeyToken = mpOrMPBDetails.PublicKeyToken;
                    }

                    string currentDate = DateTime.Now.ToString("g");

                    string query = string.Format(INSERT_QUERY, mpDisplayName, mpDescription, mpOrMPBDetails.VersionIndependentGuid.ToString(), mpOrMPBDetails.Version.ToString(), mpOrMPBDetails.SystemName, publicKeyToken, currentDate, url);

                    command = new SqlCommand(query, connection);
                    catalogItemId = Convert.ToInt32(command.ExecuteScalar());
                    
                    //Prepare Query to set Product ID 11, 12 and 13 to newly created MP
                    string product11SetQuery = string.Format(CatalogProductSet11_Query, catalogItemId);
                    string product12SetQuery = string.Format(CatalogProductSet12_Query, catalogItemId);
                    string product13SetQuery = string.Format(CatalogProductSet13_Query, catalogItemId);
                    string product14SetQuery = string.Format(CatalogProductSet14_Query, catalogItemId);
                    
                    //Mapped ProductId 11 to newly created MP
                    command = new SqlCommand(product11SetQuery, connection);
                    Convert.ToInt32(command.ExecuteScalar());
                    //Mapped ProductId 12 to newly created MP
                    command = new SqlCommand(product12SetQuery, connection);
                    Convert.ToInt32(command.ExecuteScalar());
                    //Mapped ProductId 13 to newly created MP
                    command = new SqlCommand(product13SetQuery, connection);
                    Convert.ToInt32(command.ExecuteScalar());
                    //Mapped ProductId 14 to newly created MP
                    command = new SqlCommand(product14SetQuery, connection);
                    Convert.ToInt32(command.ExecuteScalar());


                    lock (this.CatalogMPorMPBs)
                    {
                        this.CatalogMPorMPBs.Add(new CatalogMPorMPBDetails(catalogItemId, mpOrMPBDetails.VersionIndependentGuid, mpOrMPBDetails.Version, mpOrMPBDetails.SystemName, publicKeyToken, mpOrMPBDetails.DisplayName, mpOrMPBDetails.Description, url, true));
                    }
                    Common.OCCreateQuery(catalogItemId, url, mpOrMPBDetails, query);
                    AddDependencies(catalogItemId, mpOrMPBDetails);
                }
                catch (SqlException e)
                {
                    UpdateCatalog(url, mpOrMPBDetails);
                }
                catch (Exception e)
                {
                    Common.Exception("Failed to insert MP/MPB details into catalog for url " + url);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Update catalog for existing entry
        /// </summary>
        /// <param name="url">string</param>
        /// <param name="mpOrMPBDetails">MPorMPBDetails</param>
        private void UpdateCatalog(string url, MPorMPBDetails mpOrMPBDetails)
        {
            const string UPDATE_QUERY = "EXEC [SystemCenter].[dbo].[CatalogManagementPackSet] '{0}', N'{1}', N'{2}', '{3}', '{4}', '{5}', '{6}', '{7}', 2, '{8}', '', '0', '', '0', '1', '', ''";

            int catalogItemId = CatalogMPorMPBDetails.GetCatalogItemId(mpOrMPBDetails.VersionIndependentGuid, mpOrMPBDetails.Version);
            if (0 != catalogItemId)
            {
                using (SqlConnection connection = new SqlConnection(Common.OC_CONNECTION_STRING))
                {
                    connection.Open();
                    SqlCommand command;

                    try
                    {
                        string mpDisplayName = "";
                        if (!string.IsNullOrEmpty(mpOrMPBDetails.DisplayName))
                        {
                            mpDisplayName = mpOrMPBDetails.DisplayName.Replace("'", "''");
                        }

                        string mpDescription = "";
                        if (!string.IsNullOrEmpty(mpOrMPBDetails.Description))
                        {
                            mpDescription = mpOrMPBDetails.Description.Replace("'", "''");
                        }

                        string publicKeyToken = "31bf3856ad364e35";
                        if(!string.IsNullOrEmpty(mpOrMPBDetails.PublicKeyToken))
                        {
                            publicKeyToken = mpOrMPBDetails.PublicKeyToken;
                        }
                        string currentDate = DateTime.Now.ToString("g");

                        string query = string.Format(UPDATE_QUERY, catalogItemId, mpDisplayName, mpDescription, mpOrMPBDetails.VersionIndependentGuid.ToString(), mpOrMPBDetails.Version.ToString(), mpOrMPBDetails.SystemName, publicKeyToken, currentDate, url);

                        command = new SqlCommand(query, connection);
                        command.ExecuteScalar();

                        lock (this.CatalogMPorMPBs)
                        {
                            this.CatalogMPorMPBs.Add(new CatalogMPorMPBDetails(catalogItemId, mpOrMPBDetails.VersionIndependentGuid, mpOrMPBDetails.Version, mpOrMPBDetails.SystemName, publicKeyToken, mpOrMPBDetails.DisplayName, mpOrMPBDetails.Description, url, true));
                        }

                        Common.OCUpdateQuery("Duplicate key", catalogItemId, url , mpOrMPBDetails, query);
                    }
                    catch (Exception e)
                    {
                        Common.Exception("Failed to update catalog for catalog item ID " + catalogItemId);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }


        /// <summary>
        /// Adds all dependencies for this catalog MP/MPB
        /// </summary>
        /// <param name="catalogItemId">int</param>
        /// <param name="mpOrMPBDetails">MPorMPBDetails</param>
        private void AddDependencies(int catalogItemId, MPorMPBDetails mpOrMPBDetails)
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
                        string query = string.Format(UPDATE_QUERY, catalogItemId, dependency.VersionIndependentGuid.ToString(), dependency.Version.ToString());
                        Common.OCQueryLog(query);

                        command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Common.Exception("Failed to add dependency " + catalogItemId + " " + dependency.VersionIndependentGuid.ToString() + " " + dependency.Version.ToString());
                    }
                }
            }
        }


        /// <summary>
        /// Gets list of all catalog MPs that are not mapped to any category
        /// </summary>
        public void CMPNotMappedToCategory()
        {
            const string SELECT_QUERY = "SELECT DISTINCT(CMP.CatalogItemId) "
                + "FROM [SystemCenter].[dbo].[CatalogManagementPack] as CMP, "
                + "[SystemCenter].[dbo].[CatalogItem] as CI "
                + "WHERE CMP.CatalogItemId = CI.CatalogItemId "
                + "AND CI.PublishedInd = '1' "
                + "AND CMP.CatalogItemId NOT IN ( SELECT DISTINCT(ManagementPackCatalogItemId) "
                        + "FROM CatalogManagementPackCategory ) ";

            using (SqlConnection connection = new SqlConnection(Common.OC_CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command;
                SqlDataReader reader;

                try
                {
                    string query = string.Format(SELECT_QUERY);
                    command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Common.CMPNotMappedToCategory(reader[0].ToString());
                        }
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Common.Exception("Failed to get list of CMP not mapped to any category.");
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        /// <summary>
        /// Looks for CatalogMPorMPBDetails object.
        /// </summary>
        /// <param name="versionIndependentGuid">Guid</param>
        /// <param name="version">Version</param>
        /// <returns>CatalogMPorMPBDetails</returns>
        public CatalogMPorMPBDetails Find(Guid versionIndependentGuid, Version version)
        {
            return this.CatalogMPorMPBs.Find(x => x.Equals(versionIndependentGuid, version));
        }
    }
}
