using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.BusinessLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DLC_OCSync
{
    public class Common
    {
        //Below string for DLC by IP Address //public const string DLC_CONNECTION_STRING = "Data Source=CO2MSFTVSQLD51.portal.gbl;Initial Catalog=Downloads2;Integrated Security=True";
        public const string DLC_CONNECTION_STRING = "Data Source=10.244.130.66;Initial Catalog=Downloads2;Integrated Security=True";
        //Below string for OC by IP Address //public const string OC_CONNECTION_STRING = "Data Source=WWWICP04.portal.gbl;Initial Catalog=SystemCenter;Persist Security Info=True;Data Source=WWWICP04.portal.gbl;Initial Catalog=SystemCenter;Persist Security Info=True;User ID=SystemCenter_admin;Password=$ysCenter_@dmin";
        //public const string OC_CONNECTION_STRING = "Data Source=10.244.145.167;Initial Catalog=SystemCenter;Persist Security Info=True;Data Source=WWWICP04.portal.gbl;Initial Catalog=SystemCenter;Persist Security Info=True;User ID=SystemCenter_admin;Password=$ysCenter_@dmin";
        public const string OC_CONNECTION_STRING = "Data Source=WWWICP06;Initial Catalog=SystemCenter;Persist Security Info=True;Data Source=WWWICP06;Initial Catalog=SystemCenter;Persist Security Info=True;User ID=SystemCenter_admin;Password=$ysCenter_@dmin";
        
        //public const string LOCALDB_CONNECTION_STRING = "Data Source=NIKGUPTA-DEV-PC\\LOCALSQLSERVER;Initial Catalog=DLC_OC_Sync;Integrated Security=True";
        public const string LOCALDB_CONNECTION_STRING = "Data Source=RAHSING-NEB-PC\\LOCALSQLSERVER;Initial Catalog=DLC_OC_Sync;Integrated Security=True";
        public const string PRODUCTID_URL_PREFIX = "https://www.microsoft.com/en-us/download/details.aspx?id=";

        public const string SHARED_LOCATION = @"\\sccxe-scratch\scratch\rahsing\DLC-OC_Automation";
        //public const string SHARED_LOCATION = @"C:\Rahul_Project\Temp_DLC-OC_Result";
        public const string INPUT_LOCATION = @"\\sccxe-scratch\scratch\rahsing\DLC-OC_Automation\Metadata";
        //public const string INPUT_LOCATION = @"C:\Rahul_Project\Temp_DLC-OC_Result\Metadata";
        public static string MSI_CATEGORY_MAPPING_FILE_PATH;
        public static string MSI_CATEGORY_MAPPING_EXCEPTION_FILE_PATH;
        public static string OUTPUT_LOCATION;
        public static System.IO.StreamWriter OC_QUERIES_FILE;
        public static string OC_UPDATE_QUERIES_FILE_PATH;
        public static System.IO.StreamWriter OC_UPDATE_QUERIES_FILE;
        public static string OC_CREATE_QUERIES_FILE_PATH;
        public static System.IO.StreamWriter OC_CREATE_QUERIES_FILE;
        public static System.IO.StreamWriter LOG_FILE;
        public static System.IO.StreamWriter EXCEPTION_FILE;
        public static System.IO.StreamWriter CMP_NOT_MAPPED_TO_CATEGORY_FILE;
        public static string MISSING_MSI_IN_DLC_FILE_PATH;
        public static System.IO.StreamWriter MISSING_MSI_IN_DLC_FILE;
        public static string MP_MPB_IN_DLC_FILE_PATH;
        public static System.IO.StreamWriter MP_MPB_IN_DLC_FILE;
        public static string MSI_FILE_DETAILS_FILE_PATH;
        public static System.IO.StreamWriter MSI_FILE_DETAILS_FILE;
        public static string CATALOG_CATEGORY_DETAILS_FILE_PATH;
        public static System.IO.StreamWriter CATALOG_CATEGORY_DETAILS_FILE;
        public static string MAPPING_AND_UNMAPPING_FILE_PATH;
        public static System.IO.StreamWriter MAPPING_AND_UNMAPPING_FILE;

        public static ManagementGroup managementGroup;

        public static int MissingMpFileInDLC = 0;
        public static int RowsUpdatedInOC = 0;
        public static int RowsCreatedInOC = 0;
        public static int MappingAndUnmappingInOC = 0;

        /// <summary>
        /// Adds updates OC query
        /// </summary>
        /// <param name="text">string</param>
        public static void OCQueryLog(string text)
        {
            lock(OC_QUERIES_FILE)
            {
                OC_QUERIES_FILE.WriteLine(text);
            }
        }

        /// <summary>
        /// Adds new entry in OC update query file.
        /// </summary>
        /// <param name="reason"></param>
        /// <param name="catalogItemId"></param>
        /// <param name="url"></param>
        /// <param name="mpOrMpbDetail"></param>
        /// <param name="query"></param>
        public static void OCUpdateQuery(string reason, int catalogItemId, string url, MPorMPBDetails mpOrMpbDetail, string query)
        {
            lock(OC_UPDATE_QUERIES_FILE)
            {
                OC_UPDATE_QUERIES_FILE.WriteLine(string.Format("{0},{1},{2},{3},{4},\"{5}\"", reason, catalogItemId, url, mpOrMpbDetail.VersionIndependentGuid.ToString(), mpOrMpbDetail.Version.ToString(), query));
                OC_UPDATE_QUERIES_FILE.Flush();
                RowsUpdatedInOC++;
            }
        }

        /// <summary>
        /// Adds new entry in OC create query file.
        /// </summary>
        /// <param name="catalogItemId">int</param>
        /// <param name="url">string</param>
        /// <param name="mpOrMpbDetail">MPorMPBDetails</param>
        /// <param name="query">string</param>
        public static void OCCreateQuery(int catalogItemId, string url, MPorMPBDetails mpOrMpbDetail, string query)
        {
            lock(OC_CREATE_QUERIES_FILE)
            {
                OC_CREATE_QUERIES_FILE.WriteLine(string.Format("{0},{1},{2},{3},\"{4}\"", catalogItemId, url, mpOrMpbDetail.VersionIndependentGuid.ToString(), mpOrMpbDetail.Version.ToString(), query));
                OC_CREATE_QUERIES_FILE.Flush();
                RowsCreatedInOC++;
            }
        }

        /// <summary>
        /// Writes log
        /// </summary>
        /// <param name="text">string</param>
        public static void Log(string text)
        {
            lock(LOG_FILE)
            {
                LOG_FILE.WriteLine(text);
            }
        }

        /// <summary>
        /// Writes exception caught
        /// </summary>
        /// <param name="e">Exception</param>
        public static void Exception(Exception e)
        {
            lock(EXCEPTION_FILE)
            {
                EXCEPTION_FILE.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Writes exception caught
        /// </summary>
        /// <param name="text">string</param>
        public static void Exception(string text)
        {
            lock (EXCEPTION_FILE)
            {
                EXCEPTION_FILE.WriteLine(text);
            }
        }

        /// <summary>
        /// Writes catalog items that are not mapped to any category
        /// </summary>
        /// <param name="text"></param>
        public static void CMPNotMappedToCategory(string text)
        {
            lock (CMP_NOT_MAPPED_TO_CATEGORY_FILE)
            {
                CMP_NOT_MAPPED_TO_CATEGORY_FILE.WriteLine(text);
            }
        }

        /// <summary>
        /// MSI files missing in DLC
        /// </summary>
        /// <param name="text">string</param>
        public static void MissingMSIInDLC(string text)
        {
            lock (MISSING_MSI_IN_DLC_FILE)
            {
                MISSING_MSI_IN_DLC_FILE.WriteLine(text);
            }
        }

        /// <summary>
        /// Add details of MSI file that is missing in DLC
        /// </summary>
        /// <param name="msiFile">MSIFile</param>
        public static void AddMissingMSIInDLCDetails(MSIFile msiFile)
        {
            lock(MISSING_MSI_IN_DLC_FILE)
            {
                string missingFiles = string.Empty;
                MISSING_MSI_IN_DLC_FILE.Write(Common.PRODUCTID_URL_PREFIX + msiFile.ProductId + ",");
                MISSING_MSI_IN_DLC_FILE.Write(msiFile.MsiUrl + ",");
                foreach(MPorMPBDetails mpOrMPBDetails in msiFile.GetMPorMPBDetailsNotInDLC())
                {
                    missingFiles += mpOrMPBDetails.FileName + "\n";
                    MissingMpFileInDLC++;
                }
                MISSING_MSI_IN_DLC_FILE.WriteLine("\"" + missingFiles + "\"");
                MISSING_MSI_IN_DLC_FILE.Flush();
            }
        }

        /// <summary>
        /// Add details of MP/MPB file in DLC
        /// </summary>
        /// <param name="url">string</param>
        /// <param name="mpOrMPBDetails">MPorMPBDetails</param>
        public static void AddMPMPBDetailsInDLC(string url, MPorMPBDetails mpOrMPBDetails)
        {
            lock(MP_MPB_IN_DLC_FILE)
            {
                MP_MPB_IN_DLC_FILE.WriteLine(url + "," + mpOrMPBDetails.VersionIndependentGuid.ToString() + "," + mpOrMPBDetails.Version.ToString());
                MP_MPB_IN_DLC_FILE.Flush();
            }
        }

        /// <summary>
        /// Add MSI file details
        /// </summary>
        /// <param name="productId">string</param>
        /// <param name="url">string</param>
        /// <param name="status">DownloadStatus</param>
        /// <param name="msiFile">MSIFile</param>
        public static void AddMSIFileDetails(string productId, string url, DownloadStatus status, MSIFile msiFile)
        {
            lock(MSI_FILE_DETAILS_FILE)
            {
                if(DownloadStatus.Failure == status)
                {
                    MSI_FILE_DETAILS_FILE.WriteLine(productId + "," + url + "," + "Download failed");
                }
                else
                {
                    foreach(MPorMPBDetails mpOrMpbDetail in msiFile.MpOrMpbFiles.Keys.ToList())
                    {
                        if (mpOrMpbDetail.VersionIndependentGuid != null && mpOrMpbDetail.Version != null)
                        {
                            MSI_FILE_DETAILS_FILE.WriteLine(productId + "," + url + "," + "Download success" + "," + mpOrMpbDetail.FileName + "," + mpOrMpbDetail.VersionIndependentGuid.ToString()  + "," + mpOrMpbDetail.Version.ToString());
                        }
                        else
                        {
                            MSI_FILE_DETAILS_FILE.WriteLine(productId + "," + url + "," + "Download success" + "," + mpOrMpbDetail.FileName + "," + " " + "," + " ");
                        }
                    }
                }

                MSI_FILE_DETAILS_FILE.Flush();
            }
        }

        /// <summary>
        /// Add catalog category details
        /// </summary>
        /// <param name="catalogCategoryDetails">CatalogCategoryDetails</param>
        public static void AddCatalogCategoryDetails(CatalogCategoryDetails catalogCategoryDetails)
        {
            lock(CATALOG_CATEGORY_DETAILS_FILE)
            {
                CATALOG_CATEGORY_DETAILS_FILE.WriteLine(catalogCategoryDetails.CatalogItemId + "," +
                    catalogCategoryDetails.Name + "," +
                    catalogCategoryDetails.LanguageCatalogItemId + "," +
                    catalogCategoryDetails.Language.DisplayName + "," +
                    catalogCategoryDetails.MpCatalogItemId + "," +
                    catalogCategoryDetails.VersionIndependentGuid.ToString() + "," +
                    catalogCategoryDetails.Version.ToString());
                CATALOG_CATEGORY_DETAILS_FILE.Flush();
            }
        }

        /// <summary>
        /// Add mapping or unmapping details
        /// </summary>
        /// <param name="action">string</param>
        /// <param name="productId">string</param>
        /// <param name="msiUrl">string</param>
        /// <param name="categoryName">string</param>
        /// <param name="language">string</param>
        /// <param name="query">string</param>
        public static void AddMappingOrUnmappingDetails(string action, string productId, string msiUrl, string categoryName, string language, string query)
        {
            lock(MAPPING_AND_UNMAPPING_FILE)
            {
                MAPPING_AND_UNMAPPING_FILE.WriteLine(action + "," +
                    productId + "," +
                    msiUrl + "," +
                    categoryName + "," +
                    language + "," +
                    "\"" + query + "\"");
                MAPPING_AND_UNMAPPING_FILE.Flush();
                MappingAndUnmappingInOC++;
            }
        }

        public static void AddMappingOrUnmappingDetails(string action, string query)
        {
            lock (MAPPING_AND_UNMAPPING_FILE)
            {
                MAPPING_AND_UNMAPPING_FILE.WriteLine(action + "," + query);
                MAPPING_AND_UNMAPPING_FILE.Flush();
                MappingAndUnmappingInOC++;
            }
        }

        /// <summary>
        /// Connects management group
        /// </summary>
        public static void ConnectManagementGroup()
        {
            Console.WriteLine("Connecting to management group ..");
            //const string ManagementServerName = "10.185.104.209";
            const string ManagementServerName = "10.248.226.188"; //"10.248.238.230";// "10.248.219.184";// "10.247.226.36";// "10.217.112.45";10.248.219.184

            ManagementGroupConnectionSettings mgSettings = new ManagementGroupConnectionSettings(ManagementServerName);
            mgSettings.UserName = "asttest";
            mgSettings.Domain = "smx";
            SecureString password = new SecureString();
            password.AppendChar('C');
            password.AppendChar('a');
            password.AppendChar('e');
            password.AppendChar('l');
            password.AppendChar('u');
            password.AppendChar('m');
            password.AppendChar('#');
            password.AppendChar('0');
            password.AppendChar('1');
            mgSettings.Password = password;

            Common.managementGroup = ManagementGroup.Connect(mgSettings);
        }

        /// <summary>
        /// Send e-mail notification
        /// </summary>
        /// <param name="body">StringBuilder</param>
        /// <param name="attachments">List<string></param>
        public static void SendEmail(StringBuilder body, List<string> attachments)
        {
            Console.WriteLine("Sending Email");

            try
            {
                MailMessage mail = new MailMessage();
                MailAddress from = new MailAddress("asttest@microsoft.com", "asttest");

                mail.From = from;
                mail.To.Add("DLC-OCSyncAutomation" + "@microsoft.com");
                //mail.To.Add("rahsing" + "@microsoft.com");
                mail.Subject = "DLC-OC Sync Automation Run : " + DateTime.Today.ToString("dd-MMM-yyyy");

                mail.Body = body.ToString();
                mail.IsBodyHtml = true;

                foreach(string attachment in attachments)
                {
                    mail.Attachments.Add(new Attachment(attachment));
                }

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "apj.064d.cloudmail.microsoft.com";
                smtp.Credentials = new NetworkCredential("asttest@microsoft.com", "CrimsonOcean#01", "redmond");
                smtp.Send(mail);
            }
            catch(Exception e)
            {

            }
        }
    }
}
