using Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLC_OCSync
{
    public class MPorMPBDetailsInDLC
    {
        /// <summary>
        /// To cache url and corresponding MP or MPB files
        /// </summary>
        private Dictionary<string, MPorMPBDetails> MPorMPBUrlFiles;

        /// <summary>
        /// Constructor
        /// </summary>
        public MPorMPBDetailsInDLC()
        {
            this.MPorMPBUrlFiles = new Dictionary<string, MPorMPBDetails>();
            List<string> urls = GetMPorMPBUrlsInDLC();

            Parallel.ForEach(urls, new ParallelOptions { MaxDegreeOfParallelism = 10 }, url =>
                {
                    AddMPorMPBUrl(url);
                });
        }

        /// <summary>
        /// Fetches list of all URLs related to MP or MPB in DLC
        /// </summary>
        /// <returns>List<string></returns>
        private List<string> GetMPorMPBUrlsInDLC()
        {
            List<string> urls = new List<string>();
            const string SELECT_QUERY = "SELECT DISTINCT(URL) "
                + "FROM [Downloads2].[dbo].[Files] "
                + "WHERE URL like '%.mp' OR URL like '%.mpb'";

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

                command = new SqlCommand(SELECT_QUERY, connection);
                reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        url = reader[0].ToString();
                        if(!urls.Contains(url))
                        {
                            urls.Add(url);
                        }
                    }
                }

                reader.Close();
                connection.Close();
            }

            return urls;
        }

        /// <summary>
        /// Add Url of MP or MPB file to cache with file
        /// </summary>
        /// <param name="url">string</param>
        private void AddMPorMPBUrl(string url)
        {
            DownloadFile downloadFile = new DownloadFile(url);
            if (DownloadStatus.Failure == downloadFile.Status)
            {
                return;
            }

            MPorMPBDetails newMPorMPBDetails = new MPorMPBDetails(downloadFile.LocalPath);
            if (InstallMPStatus.INVALID_MANAGEMENT_PACK != newMPorMPBDetails.Status)
            {
                try
                {
                    lock (this.MPorMPBUrlFiles)
                    {
                        this.MPorMPBUrlFiles.Add(url, newMPorMPBDetails);
                        Common.AddMPMPBDetailsInDLC(url, newMPorMPBDetails);
                    }
                }
                catch (Exception e)
                {
                    Common.Exception("Failed to add MP/MPB details in DLC cache.");
                }
            }
        }

        /// <summary>
        /// Insert records into local database for verification
        /// </summary>
        /// <param name="url">string</param>
        /// <param name="mpOrMpbDetails">MPorMPBDetails</param>
        private void InsertIntoLocalDB(string url, MPorMPBDetails mpOrMpbDetails)
        {
            using (SqlConnection connection = new SqlConnection(Common.LOCALDB_CONNECTION_STRING))
            {
                connection.Open();
                SqlCommand command;

                try
                {
                    string mpDisplayName = "";
                    if (!string.IsNullOrEmpty(mpOrMpbDetails.DisplayName))
                    {
                        mpDisplayName = mpOrMpbDetails.DisplayName.Replace("'", "''");
                    }

                    string mpDescription = "";
                    if (!string.IsNullOrEmpty(mpOrMpbDetails.Description))
                    {
                        mpDescription = mpOrMpbDetails.Description.Replace("'", "''");
                    }

                    string query = string.Format("INSERT INTO[DLC_OC_Sync].[dbo].[DLC_DB](Url, Name, Guid, Version, DisplayName, Description) values('{0}','{1}','{2}','{3}','{4}','{5}')",
                        url, mpOrMpbDetails.SystemName, mpOrMpbDetails.VersionIndependentGuid.ToString(), mpOrMpbDetails.Version.ToString(), mpDisplayName, mpDescription);


                    command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    Common.Exception("Failed to insert into local DB " + url);
                }

                connection.Close();
            }
        }

        /// <summary>
        /// Check if mp exists in local cache
        /// </summary>
        /// <param name="mpOrMpbDetails">MPorMPBDetails</param>
        /// <returns>bool</returns>
        public bool Contains(MPorMPBDetails mpOrMpbDetails)
        {
            List<MPorMPBDetails> dlcMpOrMpbDetails = new List<MPorMPBDetails>(MPorMPBUrlFiles.Values);
            return dlcMpOrMpbDetails.Exists(x => x.VersionIndependentGuid == mpOrMpbDetails.VersionIndependentGuid && x.Version == mpOrMpbDetails.Version);
        }

        /// <summary>
        /// Checks and add MP file that donot exist in OC
        /// </summary>
        /// <param name="catalogMPorMPBDetailsInOC"></param>
        public void CheckExistenceInOC(CatalogMPorMPBDetailsInOC catalogMPorMPBDetailsInOC)
        {
            Parallel.ForEach(MPorMPBUrlFiles.Keys, url =>
                {
                    catalogMPorMPBDetailsInOC.CheckAndAdd(url, MPorMPBUrlFiles[url]);
                });
        }
    }
}
