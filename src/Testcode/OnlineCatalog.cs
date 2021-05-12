using Maui.Core;
using Maui.Core.Utilities;
using Maui.Core.WinControls;
using Mom.Test.UI.Core;
using Mom.Test.UI.Core.Common;  // access to LogMessage function
using Mom.Test.UI.Core.Console.Dialogs;
using Mom.Test.UI.Core.Console.MP.Dialogs;
using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.ConnectorFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Data.SqlClient;
using Infra.Frmwrk;
using System.Net.Mail;
using System.Net;

namespace Mom.Test.UI.Core.Console.MP
{
    /// <summary>
    /// Structure for Management Pack Status.
    /// </summary>
    public struct MPStatus
    {
        public string name;
        public string status;
        public string message;
    };

    /// <summary>
    /// Enumeration for Category Status.
    /// </summary>
    public enum CatalogCategoryStatus
    {
        /// <summary>
        /// Category Installed Successfully
        /// </summary>        
        CategoryInstalled,

        /// <summary>
        /// Category Already Installed Successfully
        /// </summary>
        CategoryAlreadyInstalled,

        /// <summary>
        /// Category not Installed Successfully
        /// </summary>        
        CategoryNotInstalled,

        /// <summary>
        /// Could not find Category
        /// </summary>
        CategoryNotFound,

        /// <summary>
        /// One or More MP of Category is in Error State
        /// </summary>
        MPInErrorState,

        /// <summary>
        /// Exception Occurred while installing the Category
        /// </summary>
        ExceptionOccurred
    }

    public sealed class OnlineCatalog
    {
        private const string OC_CONNECTION_STRING = "Data Source=WWWICP04.portal.gbl;Initial Catalog=SystemCenter;Persist Security Info=True;User ID=SystemCenter_admin;Password=$ysCenter_@dmin";
        private const string SQL_QUERY_GetSystemName = "select cmp.SystemName from CatalogItem ci, CatalogManagementPack cmp where ci.CatalogItemId=cmp.CatalogItemId and ci.PublishedInd=1 and ci.DefaultDisplayName in ({0}) ";
        private const string SQL_GetLanguage = "select LanguageName from Language";
        private const string SQL_GetCatalogCategory = "select DefaultDisplayName from CatalogItem where publishedInd=1 and isCategory=1 and CatalogItemId in (select distinct(CategoryCatalogItemId) from CatalogManagementPackCategory)";
        private const string CategoryStatusFile = "CategoryStatus.txt";
        private const string MPStatusFile = "MPStatus.txt";
        private const string MomConsoleAppFile = "MomConsoleApp.log";
        private const string BVTFolder = @"C:\BVT\UI\MP";
        private const string CatalogCategoryFile = @"\\sccxe-scratch\scratch\rahsing\OCCategoryAutomation\Input\CatalogCategories.txt";
        private const string SystemAndDisplayNameFile = @"\\sccxe-scratch\scratch\rahsing\OCCategoryAutomation\Input\DiplayAndSystemNames.txt";
        private const string PowerShellScript = @"/c powershell -executionpolicy unrestricted C:\BVT\UI\MP\RemoveMP.ps1";

        /// <summary>
        /// Shared Folder Location
        /// </summary>
        private string sharedFolderLocation;

        /// <summary>
        /// Index of Add Button
        /// </summary>
        private const int IndexOfAddButton = 0;

        /// <summary>
        /// Index of Properties Button
        /// </summary>
        private const int IndexPropertiesButton = 1;

        /// <summary>
        /// Import Time out
        /// </summary>
        private const int importTimeoutInSeconds = 600;

        /// <summary>
        /// max retry
        /// </summary>
        private int maxRetry = 6;

        /// <summary>
        /// Creates the Management Pack helper utility object
        /// </summary>
        private ManagementPacks managementPacks;

        /// <summary>
        /// List to hold All Catalog Category.
        /// </summary>
        List<string> catalogCategoryData;

        /// <summary>
        /// List to hold Installed Catalog Category.
        /// </summary>
        List<string> categoryInstalledList;

        /// <summary>
        /// List to hold Already Installed Catalog Category.
        /// </summary>
        List<string> categoryAlreadyInstalledList;

        /// <summary>
        /// List to hold Not Installed Catalog Category.
        /// </summary>
        List<string> categoryNotInstalledList;

        /// <summary>
        /// List to hold Catalog Category which is not present in OC.
        /// </summary>
        List<string> categoryNotFoundList;

        /// <summary>
        /// List to hold Catalog Category having MP/MPs is in Error State.
        /// </summary>
        List<string> categoryWithMPErrorList;

        /// <summary>
        /// List to hold Catalog Category with Exception.
        /// </summary>
        List<string> categoryWithExceptionList;

        /// <summary>
        /// Category Status file writer
        /// </summary>
        private TextWriter categoryStatusFileWriter;

        /// <summary>
        /// MP Status file writer
        /// </summary>
        private TextWriter mpStatusFileWriter;

        /// <summary>
        /// Dictionary to hold mapping of DisplayName with SystemName
        /// </summary>
        Dictionary<string, List<string>> dictionary;

        /// <summary>
        /// Constructor.
        /// </summary>
        public OnlineCatalog()
        {
            managementPacks = new ManagementPacks();
            catalogCategoryData = new List<string>();
            categoryInstalledList = new List<string>();
            categoryAlreadyInstalledList = new List<string>();
            categoryNotInstalledList = new List<string>();
            categoryNotFoundList = new List<string>();
            categoryWithMPErrorList = new List<string>();
            categoryWithExceptionList = new List<string>();

            sharedFolderLocation = @"\\sccxe-scratch\scratch\rahsing\OCCategoryAutomation\";
            sharedFolderLocation += DateTime.Now.ToString("yyyyMMddHHmmss") +"\\";

            File.Delete(CategoryStatusFile);
            File.Delete(MPStatusFile);
            //File.Delete(MomConsoleAppFile);
            //System.IO.File.WriteAllText(MomConsoleAppFile, string.Empty);
            GetCatalogCategoryDataFromFile();
            dictionary = new Dictionary<string, List<string>>();   
            GetSystemAndDispalyNames();
        }

        /// <summary>
        /// Read DisplayName and SystemName from file and store in dictionary.
        /// </summary>
        void GetSystemAndDispalyNames()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            try
            {
                StreamReader fileReader = new StreamReader(File.OpenRead(SystemAndDisplayNameFile));

                while (!fileReader.EndOfStream)
                {
                    string line = fileReader.ReadLine();
                    string dName = line.Substring(0, line.IndexOf("{"));
                    string sName = line.Substring(line.IndexOf("{") + 1, (line.Length - dName.Length) - 2);
                    if (!dictionary.ContainsKey(dName))
                    {
                        dictionary.Add(dName, new List<string> { sName });
                    }
                    else
                    {
                        dictionary[dName].Add(sName);
                    }
                }
                fileReader.Close();
            }
            catch (Exception ex)
            {
                Utilities.LogMessage(currentMethod + ":: Error Message : " + ex.Message);
                Utilities.LogMessage(currentMethod + ":: Error Stack : " + ex.StackTrace);
            }

            Utilities.LogMessage(currentMethod + ":: Read file Successfully.");
            Utilities.LogMessage(currentMethod + ":: Total Mapping - " + dictionary.Count);
        }

        /// <summary>
        /// This method write logs to CategoryStatus.txt file
        /// </summary>
        private void LogCatalogStatus(string message)
        {
            StreamWriter writer = new StreamWriter(CategoryStatusFile, true);
            writer.Write(message + Environment.NewLine);
            writer.Close();
        }

        /// <summary>
        /// This method write logs to MPStatus.txt file
        /// </summary>
        private void LogMPStatus(string message)
        {
            StreamWriter writer = new StreamWriter(MPStatusFile, true);
            writer.Write(message + Environment.NewLine);
            writer.Close();
        }

        /// <summary>
        /// This method read file and fetch all categories present in OC
        /// </summary>
        private void GetCatalogCategoryDataFromFile()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            try
            {
                StreamReader fileReader = new StreamReader(CatalogCategoryFile);

                while (!fileReader.EndOfStream)
                {
                    string catalogName = fileReader.ReadLine().Trim();
                    if (!catalogCategoryData.Contains(catalogName))
                    {
                        catalogCategoryData.Add(catalogName);
                    }

                }
                fileReader.Close();
            }
            catch (Exception ex)
            {
                Utilities.LogMessage(currentMethod + ":: Error Message : " + ex.Message);
                Utilities.LogMessage(currentMethod + ":: Error Stack : " + ex.StackTrace);
            }

            Utilities.LogMessage(currentMethod + " :: Read file "+CatalogCategoryFile+" and created the list Successfully.");
            Utilities.LogMessage(currentMethod + " :: Total Category = " + catalogCategoryData.Count);
        }

        /// <summary>
        /// This method fetch all categories present in OC
        /// </summary>
        private void GetCatalogCategoryData()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            List<string> languages = new List<string>();            
            StreamWriter fileWriter = new StreamWriter(".\\CatalogData.txt");

            SqlConnection connection= null;
            SqlDataReader reader = null;
            try
            {
                connection = new SqlConnection(OC_CONNECTION_STRING);
                connection.Open();
                //Get all Language Name
                SqlCommand command = new SqlCommand(SQL_GetLanguage, connection);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string name = reader[0].ToString().Trim();
                        if (name.Contains(' '))
                        {
                            name = name.Substring(0, name.IndexOf(' '));
                        }
                        if (!languages.Contains(name))
                            languages.Add(name);
                    }
                }
                reader.Close();

                //Get Catalog Category
                command = new SqlCommand(SQL_GetCatalogCategory, connection);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string CategoryName = reader[0].ToString().Trim();

                        //TODO: Need to replace below code with Lamda exp
                        bool toBeAdded = true;
                        foreach (string lang in languages)
                        {
                            if (CategoryName.StartsWith(lang))
                            {
                                toBeAdded = false;
                                break;
                            }
                        }
                        if (toBeAdded)
                        {
                            catalogCategoryData.Add(CategoryName);
                            fileWriter.WriteLine(CategoryName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.LogMessage(currentMethod + ":: Error Message : " + ex.Message);
                Utilities.LogMessage(currentMethod + ":: Error Stack : " + ex.StackTrace);
            }
            finally
            {
                if(fileWriter != null)
                    fileWriter.Close();
                if(connection != null)
                    connection.Close();
                if(reader != null)
                    reader.Close();
            }

        }

        /// <summary>
        /// This method install and then uninstall each and every category present in OC
        /// </summary>
        public void InstallAndUninstallCategoriesFromOC()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            // Navigate to the ManagementPacks node in the Administration tree. 
            Maui.Core.WinControls.TreeNode mpViewNode = managementPacks.NavigateToNodeManagementPacks();            
            try
            {
                //Install and UnIstall each and every Catagory.
                InstallUnistallCategory(catalogCategoryData);

                //For Exception case: Install and UnIstall each and every Catagory.
                if(categoryWithExceptionList.Count >0)
                {
                    Utilities.LogMessage(currentMethod + ":: Total Category in Exception List - " + categoryWithExceptionList.Count);
                    Utilities.LogMessage(currentMethod + ":: Going to test Exception List Category");
                    List<string> exceptionCategoryList = new List<string>(categoryWithExceptionList);
                    categoryWithExceptionList.Clear();
                    InstallUnistallCategory(exceptionCategoryList);
                }
            }
            catch (Exception ex)
            {
                Utilities.LogMessage(currentMethod + ":: Error Message : " + ex.Message);
                Utilities.LogMessage(currentMethod + ":: Error Stack : " + ex.StackTrace);
                Utilities.TakeScreenshot(currentMethod);
            }

            //Create CategoryStatus.txt file
            LogCatalogStatus("Status                   Category Name");
            LogCatalogStatus("======                   =============");
            foreach (string categories in categoryInstalledList)
            {
                LogCatalogStatus("Installed                " + categories);
            }
            foreach (string categories in categoryAlreadyInstalledList)
            {
                LogCatalogStatus("Already Installed        " + categories);
            }
            foreach (string categories in categoryNotInstalledList)
            {
                LogCatalogStatus("Not Installed            " + categories);
            }
            foreach (string categories in categoryNotFoundList)
            {
                LogCatalogStatus("Not find in OC           " + categories);
            }
            foreach (string categories in categoryWithMPErrorList)
            {
                LogCatalogStatus("MP is in Error State     " + categories);
            }
            foreach (string categories in categoryWithExceptionList)
            {
                LogCatalogStatus("Exception Occurred       " + categories);
            }

            //Log the summary into log file
            Utilities.LogMessage(currentMethod + " :: Total Category Tested                      :    " + (categoryInstalledList.Count + categoryAlreadyInstalledList.Count + categoryNotInstalledList.Count + categoryNotFoundList.Count + categoryWithMPErrorList.Count + categoryWithExceptionList.Count));
            Utilities.LogMessage(currentMethod + " :: Total Category Installed Successfully       :    " + categoryInstalledList.Count);
            Utilities.LogMessage(currentMethod + " :: Total Category Already Installed           :    " + categoryAlreadyInstalledList.Count);
            Utilities.LogMessage(currentMethod + " :: Total Category not Installed Successfully   :    " + categoryNotInstalledList.Count);
            Utilities.LogMessage(currentMethod + " :: Total Category with MP/MPs in Error State  :    " + categoryWithMPErrorList.Count);
            Utilities.LogMessage(currentMethod + " :: Total Category not Present in Catelog      :    " + categoryNotFoundList.Count);
            Utilities.LogMessage(currentMethod + " :: Total Category with Exception              :    " + categoryWithExceptionList.Count);

            //send the mail
            SendEmail();

        }

        private void InstallUnistallCategory(List<string> categoryNameList)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            try
            {
                int categoryCounter = 0;
                int totalCategory = categoryNameList.Count;
                foreach (string categoryName in categoryNameList)
                {
                    List<MPStatus> mpList = new List<MPStatus>();
                    bool categoryRetryInstalledStatus = false;
                    //Install Category
                    Utilities.LogMessage(currentMethod + ":: Going to Install Category[" + ++categoryCounter + "/" + totalCategory  + "] : " + categoryName);
                    switch (ImportAndInstallMP(categoryName, mpList))
                    {
                        case CatalogCategoryStatus.CategoryInstalled:
                            categoryInstalledList.Add(categoryName);
                            break;
                        case CatalogCategoryStatus.CategoryAlreadyInstalled:
                            categoryAlreadyInstalledList.Add(categoryName);
                            break;
                        case CatalogCategoryStatus.CategoryNotInstalled:
                            for (int intRetryCount = 0; intRetryCount <= 5; intRetryCount++)
                            {
                                Utilities.LogMessage(currentMethod + ":: Retry Count " + intRetryCount + " :: categoryName - " + categoryName);
                                string strStatus = ImportAndInstallMP(categoryName, mpList).ToString();
                                if (strStatus == CatalogCategoryStatus.CategoryInstalled.ToString())
                                {
                                    categoryRetryInstalledStatus = true;
                                    categoryInstalledList.Add(categoryName);
                                    break;
                                }
                            }
                            if (!categoryRetryInstalledStatus)
                            {
                                categoryNotInstalledList.Add(categoryName);
                            }
                            break;
                        case CatalogCategoryStatus.CategoryNotFound:
                            categoryNotFoundList.Add(categoryName);
                            break;
                        case CatalogCategoryStatus.MPInErrorState:
                                categoryWithMPErrorList.Add(categoryName);
                            break;
                        case CatalogCategoryStatus.ExceptionOccurred:
                            Utilities.LogMessage(currentMethod + ":: Exception occured while testing Category - " + categoryName);
                            categoryWithExceptionList.Add(categoryName);
                            break;
                    }

                    LogMPStatus("Category Name  : " + categoryName);
                    LogMPStatus("=============");
                    StringBuilder MPsToBeDeleted = new StringBuilder();
                    foreach (MPStatus mp in mpList)
                    {
                        Utilities.LogMessage(currentMethod + " ::: " + mp.name + "[ " + mp.status + " ]");
                        LogMPStatus("MP Name        : " + mp.name);
                        LogMPStatus("Status         : " + mp.status);
                        LogMPStatus("Error Message  : " + mp.message);
                        LogMPStatus("");
                        if (mp.status.ToString() == "Imported")
                        {
                            string mpName = mp.name.Trim();
                            if (dictionary.ContainsKey(mpName))
                            {
                                foreach (string sName in dictionary[mpName])
                                {
                                    MPsToBeDeleted.Append(sName + System.Environment.NewLine);
                                }
                            }
                        }
                    }
                    LogMPStatus("");
                    LogMPStatus("");
                    //Delete all Installed MPs  
                    if (!String.IsNullOrEmpty(MPsToBeDeleted.ToString()))
                    {
                        Utilities.LogMessage(currentMethod + "::  Going to Delete MPs for Category - " + categoryName);
                        StreamWriter deleteMPFile = new StreamWriter(@".\SystemNames.txt");
                        deleteMPFile.WriteLine(MPsToBeDeleted.ToString());
                        deleteMPFile.Close();
                        System.Diagnostics.Process.Start("cmd.exe", PowerShellScript).WaitForExit();
                        System.Threading.Thread.Sleep(5000);    //Wait for 5s to make page ready
                        Utilities.LogMessage(currentMethod + "::  Deleted MPs for Category - " + categoryName);
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.LogMessage(currentMethod + ":: Error Message : " + ex.Message);
                Utilities.LogMessage(currentMethod + ":: Error Stack : " + ex.StackTrace);
                Utilities.TakeScreenshot(currentMethod);
            }

        }
        /// <summary>
        /// This method takes Display name of MPs and use powershell script to recursiverly delete these MPs
        /// </summary>
        /// <param name="MPsDisplaNames">string</param>
        private void DeleteMPs(string MPsDisplaNames)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            
            //string displaNames = GetDisplayNames(mpToBeDeleted);
            Utilities.LogMessage(currentMethod + " :: DisplayNames : " + MPsDisplaNames);
            StreamWriter deleteMPFile = null;
            SqlConnection connection = null;
            SqlDataReader reader = null;
            try
            {
                //List<string> tempList = new List<string>();

                deleteMPFile = new StreamWriter(@".\SystemNames.txt");
                connection = new SqlConnection(OC_CONNECTION_STRING);
                connection.Open();
               // string query = string.Format(SQL_QUERY_GetSystemName, categoryItemId);
                string query = string.Format(SQL_QUERY_GetSystemName, MPsDisplaNames);
                Utilities.LogMessage(currentMethod + " :: SQL Query : "+query);
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    Utilities.LogMessage(currentMethod + " :: Creating System.txt file and writing System Name.");
                    while (reader.Read())
                    {
                        deleteMPFile.WriteLine(reader[0].ToString().Trim());
                    }
                }

                deleteMPFile.Close();
                Utilities.LogMessage(currentMethod + " :: Calling Powershell cmlt to Delete MPs. [" + DateTime.Now + "]");

                string psCommand = @"/c powershell -executionpolicy unrestricted C:\BVT\UI\MP\RemoveMPs_1.ps1";
                System.Diagnostics.Process.Start("cmd.exe", psCommand).WaitForExit();

                Utilities.LogMessage(currentMethod + " :: MP Deleted Successfully [" + DateTime.Now + "]");

            }
            catch (Exception ex)
            {
                Utilities.LogMessage(currentMethod + ":: Error Message : " + ex.Message);
                Utilities.LogMessage(currentMethod + ":: Error Stack : " + ex.StackTrace);
            }
            finally
            {
                if (deleteMPFile != null)
                {
                    deleteMPFile.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }

        }

        /// <summary>
        /// This method searchs given category in OC and install all its MP
        /// </summary>
        /// <returns>CatalogCategoryStatus</returns>
        /// <param name="categoryName">string</param>
        /// <param name="mpList">List</param>
        private CatalogCategoryStatus ImportAndInstallMP(string categoryName, List<MPStatus> mpList)
        {
            bool categoryInstalledStatus = true;

            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");
            try
            {
                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

                // launch the Import MP Wizard
                ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
                taskPane.ClickActionsLink(
                     Core.Console.ActionsPane.Strings.ActionsPaneAdminViews,
                     NavigationPane.Strings.ContextMenuInstallManagementPack);
                Utilities.LogMessage(currentMethod + ":: Clikced Import Management Packs...");

                WizardDialogSelectMPs mpWizardDialogSelectMPs = new WizardDialogSelectMPs(CoreManager.MomConsole);

                if (mpWizardDialogSelectMPs != null)
                {
                    Utilities.LogMessage(currentMethod + ":: MP wizard was successfully launched");
                }
                else
                {
                    throw new Dialog.Exceptions.WindowNotFoundException(currentMethod + ":: Unable to get the MP wizard dialog");
                }
                
                //Open Import UI
                mpWizardDialogSelectMPs.Controls.SelectMPsToolbar.ToolbarItems[IndexOfAddButton].ScreenElement.WaitForReady();
                mpWizardDialogSelectMPs.Controls.SelectMPsToolbar.ToolbarItems[IndexOfAddButton].Click();
                Utilities.LogMessage(currentMethod + ":: +Add Clicked");
                mpWizardDialogSelectMPs.SendKeys(KeyboardCodes.DownArrow);
                Utilities.LogMessage(currentMethod + ":: DownArrow Pressed");
                mpWizardDialogSelectMPs.SendKeys(KeyboardCodes.Enter);
                Utilities.LogMessage(currentMethod + ":: Enter Pressed");

                //throw new Exception("Restart Testing.....");

                if (!managementPacks.MakeUIReadyForImport(ManagementPacks.ImportMethod.AddFromCatelog, maxRetry))
                {
                    Utilities.LogMessage(currentMethod + ":: Import UI is not ready for import...");
                    
                    mpWizardDialogSelectMPs.ClickCancel();  //Close select MP wizard
                    System.Threading.Thread.Sleep(120000);  //Wait for 2min

                    // Navigate to Other PAge. 
                    Utilities.LogMessage(currentMethod + " :: Nagivating to other page like Tune-ManagementPacks");
                    Maui.Core.WinControls.TreeNode tuneMPViewNode = managementPacks.NavigateToNodeTuneManagementPacks();
                    CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                    CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

                    // Navigate to the Installed ManagementPacks node in the Administration tree. 
                    Utilities.LogMessage(currentMethod + " :: Nagivating to Installed Management page");
                    Maui.Core.WinControls.TreeNode mpViewNode = managementPacks.NavigateToNodeManagementPacks();
                    CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                    CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

                    ActionsPane taskPane1 = CoreManager.MomConsole.ActionsPane;
                    taskPane1.ClickActionsLink(
                         Core.Console.ActionsPane.Strings.ActionsPaneAdminViews,
                         NavigationPane.Strings.ContextMenuInstallManagementPack);
                    Utilities.LogMessage(currentMethod + ":: Clikced Import Management Packs...");

                    mpWizardDialogSelectMPs = new WizardDialogSelectMPs(CoreManager.MomConsole);

                    //Try to open Import UI
                    Utilities.LogMessage(currentMethod + ":: Trying to open Import UI again...");
                    mpWizardDialogSelectMPs.Controls.SelectMPsToolbar.ToolbarItems[IndexOfAddButton].ScreenElement.WaitForReady();
                    mpWizardDialogSelectMPs.Controls.SelectMPsToolbar.ToolbarItems[IndexOfAddButton].Click();
                    mpWizardDialogSelectMPs.SendKeys(KeyboardCodes.DownArrow);
                    mpWizardDialogSelectMPs.SendKeys(KeyboardCodes.Enter);

                    if (!managementPacks.MakeUIReadyForImport(ManagementPacks.ImportMethod.AddFromCatelog, maxRetry))
                       throw new Exception("Import UI is not ready for import after second chance..");

                }
                    

                SelectMPsFromCatalogDialog selectMPsFromCatalogDialog =
                    new SelectMPsFromCatalogDialog(CoreManager.MomConsole);
                if (selectMPsFromCatalogDialog != null)
                {
                    Utilities.LogMessage(currentMethod + ":: Add From Catalog dialog was successfully launched");

                    selectMPsFromCatalogDialog.Extended.SetFocus();
                    selectMPsFromCatalogDialog.FindText = categoryName;
                    selectMPsFromCatalogDialog.ClickSearch();

                    //System.Threading.Thread.Sleep(5000);    //Wait for 5s to search
                    while(!selectMPsFromCatalogDialog.Controls.SearchButton.IsEnabled)
                    {
                        Utilities.LogMessage(currentMethod + ":: Searching... Wait for 5s");
                        System.Threading.Thread.Sleep(5000);    //Wait for 5s to search
                    }

                    DataGridView viewGrid = new DataGridView(
                        selectMPsFromCatalogDialog,
                        SelectMPsFromCatalogDialog.ControlIDs.ManagementPacksInTheCatalogPropertyGridView);

                    if (viewGrid == null)
                    {
                        Utilities.LogMessage(currentMethod + ":: viewGrid not found.");
                        throw new DataGrid.Exceptions.UnknownWinControlException(currentMethod + ":: viewGrid not found.");
                    }

                    viewGrid.Extended.SetFocus();

                    int rowCount = viewGrid.Rows.Count;

                    if (rowCount == 1)   //First Row is header. So searched string is not found
                    {
                        //Wait for sometime and reload the grid.
                        System.Threading.Thread.Sleep(10000);    //Wait for 10s more
                        viewGrid = new DataGridView(selectMPsFromCatalogDialog, SelectMPsFromCatalogDialog.ControlIDs.ManagementPacksInTheCatalogPropertyGridView);                        
                        viewGrid.Extended.SetFocus();
                        rowCount = viewGrid.Rows.Count;

                        //if row count is still 1 then this category not present in OC
                        if (rowCount == 1)
                        {
                            Utilities.LogMessage(currentMethod + ":: Could not found Category in OC.");
                            Utilities.LogMessage(currentMethod + ":: Closing Select MP From Catalog Wizard.");
                            selectMPsFromCatalogDialog.Extended.SetFocus();
                            selectMPsFromCatalogDialog.ClickCancel();
                            Utilities.LogMessage(currentMethod + ":: Closing MP Wiard Dialog.");
                            mpWizardDialogSelectMPs.Extended.SetFocus();
                            mpWizardDialogSelectMPs.ClickCancel();
                            System.Threading.Thread.Sleep(10000);    //Wait for 10s more
                            return CatalogCategoryStatus.CategoryNotFound;    //Not find in OC 
                        }
                    }
                    int rowPos = 0;
                    viewGrid.Rows[1].AccessibleObject.Click();
                    int rowTarget = 1;
                    Maui.Core.WinControls.DataGridViewRowCollection myRows = viewGrid.Rows;
                    while (rowTarget < rowCount)
                    {
                        myRows[rowTarget].AccessibleObject.DoDefaultAction();

                        string name = viewGrid.Rows[rowTarget].Cells[0].GetValue().Trim();
                        Utilities.LogMessage(currentMethod + "::Current Row Text : " + name);
                        Utilities.LogMessage(currentMethod + "::Looking for Text : " + categoryName);
                        if (string.Equals(name, categoryName, StringComparison.OrdinalIgnoreCase))
                        {
                            Utilities.LogMessage(currentMethod + ":: Text found at Row#: " + rowTarget);
                            break;
                        }

                        myRows[rowTarget].AccessibleObject.Click(); //Need to check
                        viewGrid.SendKeys(KeyboardCodes.DownArrow);

                        rowTarget++;
                        if (rowTarget == rowCount)
                        {
                            if (rowCount != viewGrid.Rows.Count)
                            {
                                rowCount = viewGrid.Rows.Count;
                                myRows = viewGrid.Rows;
                            }
                            Utilities.LogMessage(currentMethod + ":: New row count: " + rowCount.ToString());
                        }
                    }
                    if (rowTarget == rowCount) //Searched Till end and did not find
                    {
                        Utilities.LogMessage(currentMethod + ":: Could not found Category in OC.");
                        Utilities.LogMessage(currentMethod + ":: Closing Select MP From Catalog Wizard.");
                        selectMPsFromCatalogDialog.Extended.SetFocus();
                        selectMPsFromCatalogDialog.ClickCancel();
                        Utilities.LogMessage(currentMethod + ":: Closing MP Wiard Dialog.");
                        mpWizardDialogSelectMPs.Extended.SetFocus();
                        mpWizardDialogSelectMPs.ClickCancel();
                        System.Threading.Thread.Sleep(10000);    //Wait for 10s more
                        return CatalogCategoryStatus.CategoryNotFound;    //Not find in OC 
                    }

                    selectMPsFromCatalogDialog.ClickSelect();   //Need to check
                    System.Threading.Thread.Sleep(2000);    //Need to check

                    //Remove installed MP from Grid
                    Core.Console.MomControls.GridControl selectGrid = RemoveInstalledMPFromGrid(selectMPsFromCatalogDialog);
                    if(selectGrid.Rows.Count <= 1)
                    {
                        //All MP has already been installed
                        Utilities.LogMessage(currentMethod + ":: This Category has already been installed");
                        Utilities.LogMessage(currentMethod + ":: Closing Select MP From Catalog Wizard.");
                        selectMPsFromCatalogDialog.Extended.SetFocus();
                        selectMPsFromCatalogDialog.ClickCancel();
                        Utilities.LogMessage(currentMethod + ":: Closing MP Wiard Dialog.");
                        mpWizardDialogSelectMPs.Extended.SetFocus();
                        mpWizardDialogSelectMPs.ClickCancel();
                        System.Threading.Thread.Sleep(10000);    //Wait for 10s more
                        return CatalogCategoryStatus.CategoryAlreadyInstalled;
                    }
                    //Remove installed MP from Grid

                    selectMPsFromCatalogDialog.ClickAdd();
                    CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout);

                    System.Threading.Thread.Sleep(5000);//CoreManager.MomConsole.Waiters.WaitForButtonEnabled(mpWizardDialogSelectMPs.Controls.InstallButton, Constants.DefaultDialogTimeout);

                    //If Install Button is not enable then check for MP in Error start or resolve MP
                    if (!mpWizardDialogSelectMPs.Controls.InstallButton.IsEnabled)
                    {
                        if (CheckForErrorOrResolveDependencies(mpWizardDialogSelectMPs) == false)
                        {
                            return CatalogCategoryStatus.MPInErrorState;
                        }
                    }

                    // Proceed to click the Install button
                    Utilities.LogMessage(currentMethod + ":: Click install button to finish the wizard.");
                    mpWizardDialogSelectMPs.ClickInstall();
                    try
                    {   //This is the case when one or more MP which are ready to install present at security risk.
                        CoreManager.MomConsole.ConfirmChoiceDialog(true);
                    }
                    catch
                    {
                        Utilities.LogMessage(currentMethod + " :: Don't find confirm choice dialog");
                    }

                    Utilities.LogMessage(currentMethod + ":: Install button clicked.");
                    Utilities.TakeScreenshot(currentMethod + "_AfterClickingInstall");

                    WizardDialogImportMPs mpWizardDialogImportMPs = new WizardDialogImportMPs(CoreManager.MomConsole);
                    // Wait for MPs download
                    CoreManager.MomConsole.Waiters.WaitForWindowAppeared(mpWizardDialogImportMPs, new QID(";[UIA]Name='" + WizardDialogImportMPs.ControlIDs.StopButtonName + "'"), Constants.OneMinute);     //managementPacks.WaitForMPsDownloaded(mpWizardDialogImportMPs);
                    // Wait for MPs install
                    CoreManager.MomConsole.WaitForDisabledButton(mpWizardDialogImportMPs.Controls.StopButton, Constants.DefaultDialogTimeout);

                    WizardDialogSelectMPs getMPWizardDialog = new WizardDialogSelectMPs(CoreManager.MomConsole);
                    Core.Console.MomControls.GridControl dataGrid = new Core.Console.MomControls.GridControl(getMPWizardDialog, WizardDialogSelectMPs.ControlIDs.ManagementPacksStatusPropertyGridView);

                    if (dataGrid != null)
                    {
                        Utilities.LogMessage(currentMethod + ":: Data Grid was successfully found");
                        try
                        {
                            dataGrid.Extended.SetFocus();
                        }
                        catch (Exception exception)
                        {
                            Utilities.LogMessage(currentMethod + ":: Enter Exception handling" + exception.Message);
                            CoreManager.MomConsole.ConfirmChoiceDialog(
                                MomConsoleApp.ButtonCaption.No,
                                Core.Console.Views.Views.Strings.MomDialogTitle,
                                StringMatchSyntax.ExactMatch, MomConsoleApp.ActionIfWindowNotFound.Ignore);

                            dataGrid.Extended.SetFocus();
                        }

                        int nameColIndex = dataGrid.GetColumnTitlePosition("Name");
                        int statusColIndex = dataGrid.GetColumnTitlePosition("Status");

                        int mpCount = dataGrid.Rows.Count - 1;
                        dataGrid.Rows[mpCount].AccessibleObject.Click();
                        for (int rowIndex = mpCount; rowIndex > 0; rowIndex--)
                        {
                            MPStatus mpStatus;
                            mpStatus.name = dataGrid.GetCellText(rowIndex, nameColIndex);
                            mpStatus.status = dataGrid.GetCellText(rowIndex, statusColIndex);
                            mpStatus.message = getMPWizardDialog.StatusText.Replace(Environment.NewLine, " ");

                            if (mpStatus.status != "Imported")
                            {
                                categoryInstalledStatus = false;
                            }
                            mpList.Add(mpStatus);

                            Utilities.LogMessage(currentMethod + ":: MP Name    :  " + mpStatus.name);
                            Utilities.LogMessage(currentMethod + ":: MP Status  :  " + mpStatus.status);
                            Utilities.LogMessage(currentMethod + ":: MP Message  :  " + mpStatus.message);

                            dataGrid.SendKeys(KeyboardCodes.UpArrow);
                        }
                    }

                    mpWizardDialogImportMPs.ClickClose();
                    CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                    Utilities.LogMessage(currentMethod + ":: Import Management Packs wizard is closed.");

                    //Waiting for some time for Mp to Appear In Mp view Once Import Done.
                    CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout);

                }
            }
            catch(Exception ex)
            {
                Utilities.LogMessage(currentMethod + ":: Ex.Msg  :  " + ex.Message);
                Utilities.LogMessage(currentMethod + ":: StackTrace  :  " + ex.StackTrace);

               
                System.Threading.Thread.Sleep(60000);    //Wait for 1 Min
                Utilities.LogMessage(currentMethod + ":: Closing any Exception Dialog...Time [ " + DateTime.Now + " ]");
                try
                {
                    Utilities.TakeScreenshot(currentMethod + ":: ObjectNotFoundException for - " + categoryName);
                    CoreManager.MomConsole.CloseChildDialogWindows();
                }
                catch
                {

                }

                System.Threading.Thread.Sleep(60000);    //Wait for 1 Min                
                Utilities.LogMessage(currentMethod + ":: Restarting MOM Console. Time [ " + DateTime.Now + " ]");
                try
                {
                    Utilities.TakeScreenshot(currentMethod + "Before Restarting MOM console for - " + categoryName);
                    MomConsoleApp.RestartConsole(Mcf.FrameworkContext);
                }
                catch
                {

                }

                Utilities.LogMessage(currentMethod + ":: MOM Console has Restarted. Time [ " + DateTime.Now + " ]");
                System.Threading.Thread.Sleep(60000);    //Wait for 1 Min

                // Navigate to the Installed ManagementPacks node in the Administration tree. 
                Utilities.LogMessage(currentMethod + " :: Nagivating to Installed Management page");
                Maui.Core.WinControls.TreeNode mpViewNode = managementPacks.NavigateToNodeManagementPacks();
                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);
                
                return CatalogCategoryStatus.ExceptionOccurred;

            }

            if (categoryInstalledStatus)
                return CatalogCategoryStatus.CategoryInstalled;   //Installed
            else
                return CatalogCategoryStatus.CategoryNotInstalled;   //Not installed
        }

        /// <summary>
        /// This method checks the MP status. If MP is in Current state the delete this MP before clicking install Button
        /// </summary>
        /// <returns>Core.Console.MomControls.GridControl</returns>
        /// <param name="selectMPsFromCatalogDialog">SelectMPsFromCatalogDialog</param>
        private Core.Console.MomControls.GridControl RemoveInstalledMPFromGrid(SelectMPsFromCatalogDialog selectMPsFromCatalogDialog)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            Core.Console.MomControls.GridControl selectedGrid = new Core.Console.MomControls.GridControl(selectMPsFromCatalogDialog, SelectMPsFromCatalogDialog.ControlIDs.SelectedManagementPacksPropertyGridView);

            if (selectedGrid == null)
            {
                Utilities.LogMessage(currentMethod + ":: selectedGrid not found.");
                throw new DataGrid.Exceptions.UnknownWinControlException(currentMethod + ":: selectedGrid not found.");
            }
            selectedGrid.ScreenElement.WaitForReady();
            Utilities.LogMessage(currentMethod + ":: selectedGrid is ready");
            try
            {
                selectedGrid.Extended.SetFocus();
            }
            catch (Exception exception)
            {
                Utilities.LogMessage(currentMethod + " :: Enter Exception handling" + exception.Message);
                CoreManager.MomConsole.ConfirmChoiceDialog(
                    MomConsoleApp.ButtonCaption.No,
                    Core.Console.Views.Views.Strings.MomDialogTitle,
                    StringMatchSyntax.ExactMatch, MomConsoleApp.ActionIfWindowNotFound.Ignore);

                selectedGrid.Extended.SetFocus();
            }
            int statusColIndex = selectedGrid.GetColumnTitlePosition("Status");
            Utilities.LogMessage(currentMethod + " :: Index of Status Column is - " + statusColIndex);

            selectedGrid.ScreenElement.WaitForReady();
            selectedGrid.WaitForRowsLoaded();

            //Scan each row to resolve or delete.
            int rowIndex = 1; // 0th row is header
            selectedGrid.Rows[rowIndex].AccessibleObject.Click();
            for (; rowIndex < selectedGrid.Rows.Count; rowIndex++)
            {
                if (selectedGrid.GetCellText(rowIndex, statusColIndex) == "Current")
                {
                    Utilities.LogMessage(currentMethod + " :: Found Installed MP at Row# " + rowIndex);
                    CoreManager.MomConsole.SendKeys(KeyboardCodes.Del);
                    Utilities.LogMessage(currentMethod + " :: Deleted Installed MP from selected MPs");
   //                 selectedGrid.ScreenElement.WaitForReady();
 //                   selectedGrid.WaitForRowsLoaded();
                    rowIndex--;
                }
                else
                {
                    selectedGrid.SendKeys(KeyboardCodes.DownArrow);
                }
            }

            return selectedGrid;
        }

        /// <summary>
        /// This method checks the MP status. If any MP is in Error Status the return false. As category will be in MPInErrorState. If MP is in resolve state then resolve its dependencies
        /// </summary>
        /// <returns>True/False</returns>
        /// <param name="mpWizardDialogSelectMPs">WizardDialogSelectMPs</param>
        private bool CheckForErrorOrResolveDependencies(WizardDialogSelectMPs mpWizardDialogSelectMPs)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            MomControls.GridControl dataGrid = new MomControls.GridControl(
               mpWizardDialogSelectMPs, WizardDialogSelectMPs.ControlIDs.ManagementPacksSelectedToInstallPropertyGridView);

            dataGrid.ScreenElement.WaitForReady();

            if (dataGrid != null)
            {
                Utilities.LogMessage(currentMethod + " :: ManagementPacksSelectedToInstallPropertyGridView found");

                try
                {
                    dataGrid.Extended.SetFocus();
                }
                catch (Exception exception)
                {
                    Utilities.LogMessage(currentMethod + " :: Enter Exception handling" + exception.Message);
                    CoreManager.MomConsole.ConfirmChoiceDialog(
                        MomConsoleApp.ButtonCaption.No,
                        Core.Console.Views.Views.Strings.MomDialogTitle,
                        StringMatchSyntax.ExactMatch, MomConsoleApp.ActionIfWindowNotFound.Ignore);

                    dataGrid.Extended.SetFocus();
                }

                int statusColIndex = dataGrid.GetColumnTitlePosition("Status");
                Utilities.LogMessage(currentMethod + " :: Index of Status Column is - " + statusColIndex);

                dataGrid.ScreenElement.WaitForReady();
                dataGrid.WaitForRowsLoaded();

                if(dataGrid.FindData("Error", statusColIndex) != null)
                {
                    Utilities.LogMessage(currentMethod + ":: One or More MP is in Error state");
                    Utilities.LogMessage(currentMethod + ":: Closing Wizard and returning back");
                    mpWizardDialogSelectMPs.ClickCancel();
                    CoreManager.MomConsole.ConfirmChoiceDialog(true);
                    return false;
                }
                Utilities.LogMessage(currentMethod + ":: Does not find MP is in Error state");
                Utilities.LogMessage(currentMethod + ":: Going to Resolve the dependency");

                //Scan each row to resolve or delete.
                int rowIndex = 1; // 0th row is header
                dataGrid.Rows[rowIndex].AccessibleObject.Click();
                while (!(mpWizardDialogSelectMPs.Controls.InstallButton.IsEnabled) && rowIndex < dataGrid.Rows.Count)
                {
                    while(dataGrid.GetCellText(rowIndex, statusColIndex)!="Resolve")
                    {
                        dataGrid.SendKeys(KeyboardCodes.DownArrow);
                        rowIndex++;
                    }

                    //System.Threading.Thread.Sleep(5000);    //Wait for 5s
                    Utilities.LogMessage(currentMethod + " :: Found Resolve status at Row#"+rowIndex);
                    dataGrid.Rows[rowIndex].AccessibleObject.Click(MouseFlags.RightButton);
                    //System.Threading.Thread.Sleep(1000);    //Wait for 1s to appear the menu bar
                    Utilities.LogMessage(currentMethod + " :: Right clicked on row");
                    dataGrid.SendKeys(KeyboardCodes.DownArrow);
                    dataGrid.SendKeys(KeyboardCodes.DownArrow);
                    Utilities.LogMessage(currentMethod + ":: DownArrow+DownArrow Pressed");
                    dataGrid.SendKeys(KeyboardCodes.Enter);
                    Utilities.LogMessage(currentMethod + ":: Enter Pressed");

                    dataGrid.ScreenElement.WaitForReady();
                    dataGrid.WaitForRowsLoaded();

                    dataGrid = new MomControls.GridControl(mpWizardDialogSelectMPs, WizardDialogSelectMPs.ControlIDs.ManagementPacksSelectedToInstallPropertyGridView);
                    dataGrid.ScreenElement.WaitForReady();
                    if (dataGrid != null)
                    {
                        Utilities.LogMessage(currentMethod + " :: Refreshed Grid found");
                        try
                        {
                            dataGrid.Extended.SetFocus();
                        }
                        catch (Exception exception)
                        {
                            Utilities.LogMessage(currentMethod + " :: Enter Exception handling" + exception.Message);
                            CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.No, Core.Console.Views.Views.Strings.MomDialogTitle, StringMatchSyntax.ExactMatch, MomConsoleApp.ActionIfWindowNotFound.Ignore);
                            dataGrid.Extended.SetFocus();
                        }
                    }
                    dataGrid.Rows[rowIndex].AccessibleObject.Click();
                }
            }
            return true;
        }

        /// <summary>
        /// Send e-mail notification
        /// </summary>
        //private void SendEmail(StringBuilder body, List<string> attachments)
        private void SendEmail()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            try
            {
                //Copy all log files to shared locations
                CopyLogsToSharedLocation();

                StringBuilder bodyString = new StringBuilder();
                List<string> attachments = new List<string>(); 
                attachments.Add(sharedFolderLocation +"\\"+ CategoryStatusFile);
                attachments.Add(sharedFolderLocation + "\\" + MPStatusFile);
            
                bodyString.Append("Hi All,");
                bodyString.Append("<br/>");
                bodyString.Append("<br/>");
                bodyString.Append("Online Catalog Category Automation has ran successfully with below result.");
                bodyString.Append("<br/>");
                bodyString.Append("<br/>");
                bodyString.Append("<table border=\"1\" style=\"width:60%\">");
                bodyString.Append("<tr><td><b>Total Category Tested</b></td><td><b>" + (categoryInstalledList.Count + categoryAlreadyInstalledList.Count + categoryNotInstalledList.Count + categoryNotFoundList.Count + categoryWithMPErrorList.Count + categoryWithExceptionList.Count) + "</b></td></tr>");
                bodyString.Append("<tr><td>Total Category Installed Successfully</td><td>" + categoryInstalledList.Count + "</td></tr>");
                bodyString.Append("<tr><td>Total Category Already Installed</td><td>" + categoryAlreadyInstalledList.Count + "</td></tr>");
                bodyString.Append("<tr><td>Total Category not Installed Successfully</td><td>" + categoryNotInstalledList.Count + "</td></tr>");
                bodyString.Append("<tr><td>Total Category with MP/MPs in Error State</td><td>" + categoryWithMPErrorList.Count + "</td></tr>");
                bodyString.Append("<tr><td>Total Category not Present in Catalog</td><td>" + categoryNotFoundList.Count + "</td></tr>");
                bodyString.Append("<tr><td>Total Category with Exception</td><td>" + categoryWithExceptionList.Count + "</td></tr>");
                bodyString.Append("</table>");
                bodyString.Append("<br/><br/>");
                bodyString.Append("Please find attached files for Category level information and MP level information.");
                bodyString.Append("<br/>");
                bodyString.Append("Detail log files present at <a href=\"" + sharedFolderLocation + "\">this</a> location.");
                bodyString.Append("<br/><br/><br/>");
                bodyString.Append("Regards,");
                bodyString.Append("<br/>");
                bodyString.Append("OC Category Automation");


                MailMessage mail = new MailMessage();
                MailAddress from = new MailAddress("asttest@microsoft.com", "asttest");

                mail.From = from;
                mail.To.Add("DLC-OCSyncAutomation" + "@microsoft.com");
                //mail.To.Add("rahsing" + "@microsoft.com");
                mail.Subject = "Online Catalog Category Automation : " + DateTime.Today.ToString("dd-MMM-yyyy");

                mail.Body = bodyString.ToString();
                mail.IsBodyHtml = true;
                Utilities.LogMessage(currentMethod + " :: Completed body of mail");
                
                foreach (string attachment in attachments)
                {
                    mail.Attachments.Add(new Attachment(attachment));
                }
                Utilities.LogMessage(currentMethod + " :: Attached file to mail");

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "apj.064d.cloudmail.microsoft.com";
                smtp.Credentials = new NetworkCredential("asttest@microsoft.com", "CrimsonOcean#01", "redmond");
                smtp.Send(mail);

                Utilities.LogMessage(currentMethod + " :: Successfully sent the Email");
            }
            catch (Exception ex)
            {
                Utilities.LogMessage(currentMethod + ":: Error Message : " + ex.Message);
                Utilities.LogMessage(currentMethod + ":: Error Stack : " + ex.StackTrace);
            }
        }

        /// <summary>
        /// Create shared location on scratch folder and copy all the log files
        /// </summary>
        private void CopyLogsToSharedLocation()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");
            Utilities.LogMessage(sharedFolderLocation + "  - Created Directory");

            //Creating Directory to shared location  
            Directory.CreateDirectory(sharedFolderLocation);
            Utilities.LogMessage(currentMethod + " :: Shared Directory created");
            //Copy the log file to shared location
            string sourceFile = System.IO.Path.Combine(BVTFolder, CategoryStatusFile);
            string destFile = System.IO.Path.Combine(sharedFolderLocation, CategoryStatusFile);
            System.IO.File.Copy(sourceFile, destFile, true);
            Utilities.LogMessage(currentMethod + " :: Copied " + CategoryStatusFile + " to shared location");
            sourceFile = System.IO.Path.Combine(BVTFolder, MPStatusFile);
            destFile = System.IO.Path.Combine(sharedFolderLocation, MPStatusFile);
            System.IO.File.Copy(sourceFile, destFile, true);
            Utilities.LogMessage(currentMethod + " :: Copied "+MPStatusFile+" to shared location");
            sourceFile = System.IO.Path.Combine(BVTFolder, MomConsoleAppFile);
            destFile = System.IO.Path.Combine(sharedFolderLocation, MomConsoleAppFile);
            System.IO.File.Copy(sourceFile, destFile, true);
            Utilities.LogMessage(currentMethod + " :: Copied " + MomConsoleAppFile + " to shared location");

            string[] files = System.IO.Directory.GetFiles(BVTFolder, "*.jpg");
            foreach (string s in files)
            {
                string fileName = System.IO.Path.GetFileName(s);
                destFile = System.IO.Path.Combine(sharedFolderLocation, fileName);
                System.IO.File.Copy(s, destFile, true);
                File.Delete(fileName);
            }

            Utilities.LogMessage(currentMethod + " :: Copied all the log files to shared locations");
        }
    }
}
