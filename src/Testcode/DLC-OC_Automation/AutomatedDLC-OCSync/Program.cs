using Microsoft.EnterpriseManagement;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DLC_OCSync;

namespace AutomatedDLC_OCSync
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateOutputSharedDirectory();
            Common.ConnectManagementGroup();

            Console.WriteLine("Caching MP or MPB data from download center ..");
            MPorMPBDetailsInDLC mpOrMPBDetailsInDLC = new MPorMPBDetailsInDLC();

            Console.WriteLine("Caching MP or MPB data from online catalog ..");
            CatalogMPorMPBDetailsInOC catalogMPorMPBDetailsInOC = new CatalogMPorMPBDetailsInOC();

            Console.WriteLine("Verfying and adding MP/MPBs missing in download center to online catalog ..");
            mpOrMPBDetailsInDLC.CheckExistenceInOC(catalogMPorMPBDetailsInOC);

            Console.WriteLine("Caching catalog category data ..");
            CatalogCategoryDetailsInOC catalogCategoryDetailsInOC = new CatalogCategoryDetailsInOC();

            Console.WriteLine("Caching msi and category data ..");
            MsiToCategoryMapping msiToCategoryMapping = new MsiToCategoryMapping();

            Console.WriteLine("Caching msi and category data for 1-MSI to Many Category case..");
            MsiToCategoriesMapping msiToCategoriesMapping = new MsiToCategoriesMapping();

            Console.WriteLine("Checking download center for all management pack related MSIs and existence of each MP/MPBs in download center ..");
            MPorMPBMSIFilesInDLC mpOrMPBMSIFilesInDLC = new MPorMPBMSIFilesInDLC(mpOrMPBDetailsInDLC, catalogMPorMPBDetailsInOC, catalogCategoryDetailsInOC, msiToCategoryMapping, msiToCategoriesMapping);

            //Temp disabling some category
            //Will remove it later.
            Console.WriteLine("Disableing the selected Catalog Item ..");
            DisableCatalogCategories();

            CloseFiles();
            SendMail();
            
            Console.WriteLine("Complete.");
        }

        /// <summary>
        /// Creates shared directory for output
        /// </summary>
        private static void CreateOutputSharedDirectory()
        {
            Console.WriteLine("Creating shared directory ..");
            DateTime currentDate = DateTime.Now;
            Common.MSI_CATEGORY_MAPPING_FILE_PATH = Common.INPUT_LOCATION + "\\" + "MSI-Category Mapping.csv";
            Common.MSI_CATEGORY_MAPPING_EXCEPTION_FILE_PATH = Common.INPUT_LOCATION + "\\" + "MSI-Category Exception Mapping.csv";            
            Common.OUTPUT_LOCATION = Common.SHARED_LOCATION + "//" + currentDate.Date.ToString("yyyyMMdd");
            Directory.CreateDirectory(Common.OUTPUT_LOCATION);
            Common.OC_QUERIES_FILE = new System.IO.StreamWriter(Common.OUTPUT_LOCATION + "\\" + "Update queries in OC.txt", true);
            Common.OC_UPDATE_QUERIES_FILE_PATH = Common.OUTPUT_LOCATION + "\\" + "Rows updated in OC.csv";
            Common.OC_UPDATE_QUERIES_FILE = new System.IO.StreamWriter(Common.OC_UPDATE_QUERIES_FILE_PATH, true);
            Common.OC_CREATE_QUERIES_FILE_PATH = Common.OUTPUT_LOCATION + "\\" + "Rows created in OC.csv";
            Common.OC_CREATE_QUERIES_FILE = new System.IO.StreamWriter(Common.OC_CREATE_QUERIES_FILE_PATH, true);
            Common.LOG_FILE = new System.IO.StreamWriter(Common.OUTPUT_LOCATION + "\\" + "Log.txt", true);
            Common.EXCEPTION_FILE = new System.IO.StreamWriter(Common.OUTPUT_LOCATION + "\\" + "Excpetions.txt", true);
            Common.CMP_NOT_MAPPED_TO_CATEGORY_FILE = new System.IO.StreamWriter(Common.OUTPUT_LOCATION + "\\" + "Catalog MP not mapped to any category.txt", true);
            Common.MISSING_MSI_IN_DLC_FILE_PATH = Common.OUTPUT_LOCATION + "\\" + "Missing MSI in DLC.csv";
            Common.MISSING_MSI_IN_DLC_FILE = new System.IO.StreamWriter(Common.MISSING_MSI_IN_DLC_FILE_PATH, true);
            Common.MP_MPB_IN_DLC_FILE_PATH = Common.OUTPUT_LOCATION + "\\" + "MP MPB Details in DLC.csv";
            Common.MP_MPB_IN_DLC_FILE = new System.IO.StreamWriter(Common.MP_MPB_IN_DLC_FILE_PATH, true);
            Common.MSI_FILE_DETAILS_FILE_PATH = Common.OUTPUT_LOCATION + "\\" + "MSI Details in DLC.csv";
            Common.MSI_FILE_DETAILS_FILE = new System.IO.StreamWriter(Common.MSI_FILE_DETAILS_FILE_PATH, true);
            Common.CATALOG_CATEGORY_DETAILS_FILE_PATH = Common.OUTPUT_LOCATION + "\\" + "Catalog category Details in OC.csv";
            Common.CATALOG_CATEGORY_DETAILS_FILE = new System.IO.StreamWriter(Common.CATALOG_CATEGORY_DETAILS_FILE_PATH, true);
            Common.MAPPING_AND_UNMAPPING_FILE_PATH = Common.OUTPUT_LOCATION + "\\" + "Items that requires mapping or unmapping.csv";
            Common.MAPPING_AND_UNMAPPING_FILE = new System.IO.StreamWriter(Common.MAPPING_AND_UNMAPPING_FILE_PATH, true);
        }

        /// <summary>
        /// Close all file handle that are opened.
        /// </summary>
        private static void CloseFiles()
        {
            Console.WriteLine("Closing opened file handles.");
            if (null != Common.OC_QUERIES_FILE)
            {
                Common.OC_QUERIES_FILE.Flush();
                Common.OC_QUERIES_FILE.Close();
            }

            if (null != Common.OC_UPDATE_QUERIES_FILE)
            {
                Common.OC_UPDATE_QUERIES_FILE.Flush();
                Common.OC_UPDATE_QUERIES_FILE.Close();
            }

            if (null != Common.OC_CREATE_QUERIES_FILE)
            {
                Common.OC_CREATE_QUERIES_FILE.Flush();
                Common.OC_CREATE_QUERIES_FILE.Close();
            }

            if (null != Common.LOG_FILE)
            {
                Common.LOG_FILE.Flush();
                Common.LOG_FILE.Close();
            }

            if (null != Common.EXCEPTION_FILE)
            {
                Common.EXCEPTION_FILE.Flush();
                Common.EXCEPTION_FILE.Close();
            }

            if (null != Common.CMP_NOT_MAPPED_TO_CATEGORY_FILE)
            {
                Common.CMP_NOT_MAPPED_TO_CATEGORY_FILE.Flush();
                Common.CMP_NOT_MAPPED_TO_CATEGORY_FILE.Close();
            }

            if (null != Common.MISSING_MSI_IN_DLC_FILE)
            {
                Common.MISSING_MSI_IN_DLC_FILE.Flush();
                Common.MISSING_MSI_IN_DLC_FILE.Close();
            }

            if(null != Common.MP_MPB_IN_DLC_FILE)
            {
                Common.MP_MPB_IN_DLC_FILE.Flush();
                Common.MP_MPB_IN_DLC_FILE.Close();
            }

            if(null != Common.MSI_FILE_DETAILS_FILE)
            {
                Common.MSI_FILE_DETAILS_FILE.Flush();
                Common.MSI_FILE_DETAILS_FILE.Close();
            }

            if (null != Common.CATALOG_CATEGORY_DETAILS_FILE)
            {
                Common.CATALOG_CATEGORY_DETAILS_FILE.Flush();
                Common.CATALOG_CATEGORY_DETAILS_FILE.Close();
            }

            if (null != Common.MAPPING_AND_UNMAPPING_FILE)
            {
                Common.MAPPING_AND_UNMAPPING_FILE.Flush();
                Common.MAPPING_AND_UNMAPPING_FILE.Close();
            }
        }

        /// <summary>
        /// Send mail of automation run
        /// </summary>
        private static void SendMail()
        {
            List<string> filePaths = new List<string>();
            if (Common.MissingMpFileInDLC > 0)
            {
                filePaths.Add(Common.MISSING_MSI_IN_DLC_FILE_PATH);
            }
            if(Common.RowsUpdatedInOC > 0)
            {
                filePaths.Add(Common.OC_UPDATE_QUERIES_FILE_PATH);
            }
            if(Common.RowsCreatedInOC > 0)
            {
                filePaths.Add(Common.OC_CREATE_QUERIES_FILE_PATH);
            }
            if(Common.MappingAndUnmappingInOC > 0)
            {
                filePaths.Add(Common.MAPPING_AND_UNMAPPING_FILE_PATH);
            }

            StringBuilder content = new StringBuilder();
            content.AppendLine("Total number of files that needs to be uploaded to DLC : " + Common.MissingMpFileInDLC + "<br/>");
            content.AppendLine("Number of updates done in OC automatically : " + Common.RowsUpdatedInOC + "<br/>");
            content.AppendLine("Number of new entries created in OC automatically : " + Common.RowsCreatedInOC + "<br/>");
            content.AppendLine("Total number of mapping changes required in OC : " + Common.MappingAndUnmappingInOC + "<br/>");

            if (filePaths.Count > 0)
            {
                content.AppendLine("<br/>");
                content.AppendLine("<br/>");
                content.AppendLine("Please refer to attached documents.<br/>");
                content.AppendLine("Metadata file that contains msi url and category mapping is <a href=\"" + Common.MSI_CATEGORY_MAPPING_FILE_PATH + "\">here</a>.");
            }

            content.AppendLine("<br/>");
            content.AppendLine("<br/>");
            content.AppendLine("<br/>");
            content.AppendLine("Regards,<br/>");
            content.AppendLine("DLC-OC Sync Automation<br/>");

            Common.SendEmail(content, filePaths);
        }

        /// <summary>
        /// Disable Catalog Catagories
        /// </summary>
        private static void DisableCatalogCategories()
        {
            string disableCatalogMPFilePath = "C:\\disableCatalogMPFile.txt";
            StreamReader fileReader = new StreamReader(File.OpenRead(disableCatalogMPFilePath));
            while (!fileReader.EndOfStream)
            {
                string id = fileReader.ReadLine();
                string sqlQuery = "exec [dbo].[CatalogManagementPackSet] " + id + ",null,null,null,null,null,null,null,null,null,null,null,null,null,'0',null,null";
                //Console.WriteLine(sqlQuery);
                SqlConnection connection = new SqlConnection(Common.OC_CONNECTION_STRING);
                connection.Open();

                SqlCommand command;
                SqlDataReader reader; ;

                command = new SqlCommand(sqlQuery, connection);
                reader = command.ExecuteReader();

                reader.Close();
                connection.Close();

            }
            fileReader.Close();

        }
    }
}
