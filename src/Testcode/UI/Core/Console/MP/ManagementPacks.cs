//  -----------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ManagementPacks.cs">
//     Copyright ?Microsoft 2005
// </copyright>
// <project>
//     Mom.Test.UI.Core.Console.MP
// </project>
// <summary>
//     A class containing Management Pack test code utility functions.
// </summary>
// <history>
//      [barryw]    23JUL05 Created
//      [ravipr]    27SEP05 Added ManagementPackGuid constants
//      [ruhim]     10FEB06 Updating AEM MP guid
//      [ruhim]     01MAR06 Deleting obsolete constants, Updating Notification MP guid
//      [faizalk]   22MAR06 Update for redesigned MP Import
//      [faizalk]   6JUNE06 Added retry logic for right-click context menu
//      [visnara]   26JUN06 Changed # retries from 3 to 6 while finding ctx menu for deletion also doubled ctxmenu timeout
//      [visnara]   18SEP06 Added support for MP Create, MP Export
//      [visnara]   31JAN07 Increased the timeout for MP Export path dialog
//      [a-joelj]   12JAN09 Added 2-second delays in the DeleteManagementPack() click methods and commented
//                          out an unnecessary section of code for RemoveResolveMPs() that caused an extra click
//      [sunsingh ] 05FEB09 Added Scenario to search MP From catalog Wizard
//      [nathd]     26SEP09 Remove accelerator char '&' from CloseButton resource string before comparing
//                          to the CloseButton caption. 
//      [rahsing]   01OCT15 Modified the path of Installed Management Packs
//      [rahsing]   01DEC15 Added the path of Updates adn Recommendations
//      [rahsing]   10DEC15 Added MoreInformationUI method for More Information UI automation
//      [rahsing]   10JAN16 Modified the hardcoded string with resource string
//      [chandrab]   11Jan16 Modified RefreshUpdatesAndRecommendationsViewAfterCacheExpiry method for OC cache expiry
//      [satim]     27FEB16 Added TuneAlertParameters class.
//      [satim]     27FEB16 Added methods for verifying override sources in ALM.   
//      [rahsing]   25May16 Added the method to verify View Guide  and View DLC Page link
//      [rahsing]   01JUN16 Added methods to show workloads of all different status on Updates and recommendations page  
//      [rahsing]   06JUL17 Added methods to verify the Get MP for Third party Updates and recommendations
//      [rahsing]   06JUL17 Added methods to verify the Get All MPs for Third party Updates and recommendations
//      [rahsing]   06JUL17 Added methods to verify the View Guide and View DLC like for Third party Updates and recommendations
// </history>
//  -----------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MP
{
    #region Using directives

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    using Mom.Test.UI.Core;
    using Mom.Test.UI.Core.Common;  // access to LogMessage function
    using Mom.Test.UI.Core.Console.Dialogs;
    using Mom.Test.UI.Core.Console.MP.Dialogs;
    using Maui.Core;
    using Maui.Core.Utilities; // access to Sleeper function
    using Maui.Core.WinControls;
    using System.Text.RegularExpressions;
    using Microsoft.Win32;
    #endregion

    #region MPParameters Class

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// MP parameters class
    /// </summary>
    /// <history>
    /// 	[visnara] 9/18/2006 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class MPParameters
    {
        #region private members

        /// <summary>
        /// MP Name 
        /// </summary>
        private string mpName = null;

        /// <summary>
        /// MP Version 
        /// </summary>
        private string mpVersion = null;

        /// <summary>
        /// MP Description 
        /// </summary>
        private string mpDescription = null;

        /// <summary>
        /// Edit MP Knowledge 
        /// </summary>
        private bool knowledge = false;

        /// <summary>
        /// MP Knowledge Content
        /// </summary>
        private string mpKnowledgeContent = null;

        #endregion private members

        #region constructor

        /// <summary>
        /// Default Constructor 
        /// </summary>
        public MPParameters()
        {
        }

        #endregion

        #region properties

        /// <summary>
        /// MP Name
        /// </summary>
        public string MPName
        {
            get
            {
                return this.mpName;
            }

            set
            {
                this.mpName = value;
            }
        }

        /// <summary>
        /// MP Version
        /// </summary>
        public string MPVersion
        {
            get
            {
                return this.mpVersion;
            }

            set
            {
                this.mpVersion = value;
            }
        }

        /// <summary>
        /// MP Description 
        /// </summary>
        public string MPDescription
        {
            get
            {
                return this.mpDescription;
            }

            set
            {
                this.mpDescription = value;
            }
        }

        /// <summary>
        /// Edit Knowledge ?
        /// </summary>
        public bool Knowledge
        {
            get
            {
                return this.knowledge;
            }

            set
            {
                this.knowledge = value;
            }
        }

        /// <summary>
        /// MP Knowledge Content 
        /// </summary>
        public string MPKnowledgeContent
        {
            get
            {
                return this.mpKnowledgeContent;
            }

            set
            {
                this.mpKnowledgeContent = value;
            }
        }

        #endregion
    }

    #endregion

    #region WorkloadParameters Class

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Workload parameters class
    /// </summary>
    /// <history>
    /// 	[rahsing] 10/12/2015 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class WorkloadParameters
    {

        public string workloadName { get; set; }
        public string workloadStatus { get; set; }

        /// <summary>
        /// Default Constructor 
        /// </summary>
        public WorkloadParameters()
        {
        }
    }

    #endregion

    #region TuneAlertsParameters Class
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Tune Alerts Parameter class
    /// </summary>
    /// <history>
    /// 	[satim] 27/02/2016 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class TuneAlertsParameters
    {

        public string OverrideOrDisable { get; set; }
        public string OverrideParameter { get; set; }
        public string OverrideParameterValue { get; set; }
        public string ComboMPName { get; set; }

        public TuneAlertsParameters()
        {
        }
    }
    #endregion

    /// <summary>
    /// Helper methods for ManagementPacks.
    /// </summary>
    public sealed class ManagementPacks
    {
        #region Constants section
        private const int timeout = 5000;

        private const int IndexOfAddButton = 0;

        private const int IndexOfPropertiesButton = 1;

        private const int IndexOfRemoveButton = 2;

        private const Char MPNameSeparator = '|';

        /// <summary>
        /// max retry
        /// </summary>
        private int maxRetry = 6;

        // public string MPViewPath = NavigationPane.Strings.AdminTreeViewAdministrationRoot +
        //     Constants.PathDelimiter +
        //     NavigationPane.Strings.ManagementPacks; 

        #endregion

        #region  Constructors section

        /// <summary>
        /// Constructor.
        /// </summary>
        public ManagementPacks()
        {
            // This prevents the creation of a default constructor
        }

        #endregion

        #region Enumerators section
        /// <summary>
        /// Enumeration for ImportMethod.
        /// </summary>
        public enum ImportMethod
        {
            /// <summary>
            /// Import from disk
            /// </summary>
            AddFromDisk,
            /// <summary>
            /// Import from catelog
            /// </summary>
            AddFromCatelog

        }
        /// <summary>
        /// Enumeration for actions specified in MP Wizard.
        /// </summary>
        public enum MPWizardAction
        {
            /// <summary>
            /// Remove MPs Via ToolStrip Remove Button
            /// </summary>
            RemoveMPsViaToolStripRemoveButton,

            /// <summary>
            /// Remove MPs via MP Error Dialog
            /// </summary>
            RemoveMPsViaMPErrorDialog,

            /// <summary>
            /// Remove MPs via Context Menu
            /// </summary>
            RemoveMPsViaContextMenu,

            /// <summary>
            /// Resolve MPs via Context Menu
            /// </summary>
            ResolveMPsViaContextMenu,

            /// <summary>
            /// Resolve MPs via MP Warning Dialog
            /// </summary>
            ResolveMPsViaMPWarningDialog
        }
        #endregion

        private bool isAllStatusEnabled = false;

        #region Public Methods section

        /// <summary>
        /// Import and install MPs from Catalog and install lower version MPs from disk to make workload Partially Installed and Update Available
        /// </summary>
        public void EnableALLStatus()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            Dictionary<string, string> mpPathAndDisplayName = new Dictionary<string, string>();
            mpPathAndDisplayName.Add(@"C:\BVT\UI\MP\Microsoft.Windows.CertificateServices.Library.mp", "Certificate Services Common Library");
            mpPathAndDisplayName.Add(@"C:\BVT\UI\MP\Microsoft.Windows.Server.Reports.mp", "Windows Server Operating System Reports");
            List<string> mpToInstallFromOC = new List<string>();
            mpToInstallFromOC.Add("Windows Server Internet Information Services Library");

            try
            {
                //Delete all MPs first if they are present
                foreach (KeyValuePair<string, string> mpDetails in mpPathAndDisplayName)
                {
                    try
                    {
                        DeleteManagementPack(mpDetails.Value);
                        Utilities.LogMessage(currentMethod + ":: Deleted MP " + mpDetails.Value);
                    }
                    catch
                    {
                        Utilities.LogMessage(currentMethod + ":: MP is not installed");
                    }
                }
                foreach (string mpName in mpToInstallFromOC)
                {
                    try
                    {
                        DeleteManagementPack(mpName);
                        Utilities.LogMessage(currentMethod + ":: Delted MP " + mpName);
                    }
                    catch
                    {
                        Utilities.LogMessage(currentMethod + ":: MP is not installed");
                    }
                }

                // Navigate to the ManagementPacks node in the Administration tree. 
                Maui.Core.WinControls.TreeNode mpViewNode = this.NavigateToNodeManagementPacks();

                // launch the Import MP Wizard
                CoreManager.MomConsole.ExecuteContextMenu(NavigationPane.Strings.ContextMenuInstallManagementPack, true);

                WizardDialogSelectMPs mpWizardDialogSelectMPs = new WizardDialogSelectMPs(CoreManager.MomConsole);

                if (mpWizardDialogSelectMPs != null)
                {
                    Utilities.LogMessage(currentMethod + ":: MP wizard was successfully launched");
                }
                else
                {
                    throw new Dialog.Exceptions.WindowNotFoundException(currentMethod + ":: Unable to get the MP wizard dialog");
                }

                //Install lower version MP from Disk to enable Workload of status Update Availabe
                foreach (KeyValuePair<string, string> mpDetails in mpPathAndDisplayName)
                {
                    AddMPsFromDisk(mpDetails.Key);
                }
                //Install lower version MP from OC to enable Workload of status Partially Install
                foreach (string mpName in mpToInstallFromOC)
                {
                    AddMPsFromCatalog(mpName);
                }

                // Proceed the Install button
                Utilities.LogMessage(currentMethod + ":: Click install button to finish the wizard.");
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(mpWizardDialogSelectMPs.Controls.InstallButton, Constants.DefaultDialogTimeout);
                mpWizardDialogSelectMPs.ClickInstall();
                Utilities.LogMessage(currentMethod + ":: Install button clicked.");
                Utilities.TakeScreenshot(currentMethod + "_AfterClickingInstall");
                try
                {
                    CoreManager.MomConsole.ConfirmChoiceDialog(true);
                    //MomConsoleApp.ButtonCaption.Yes,
                    //Core.Console.Views.Views.Strings.MomDialogTitle,
                    //StringMatchSyntax.ExactMatch, MomConsoleApp.ActionIfWindowNotFound.Ignore);
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage(currentMethod + ":: Don't find confirm choice dialog");
                }

                // CloseMPImportWizard
                this.CloseMPImportWizard(Constants.DefaultDialogTimeout);
                //Waiting for some time for Mp to Appear In Mp view Once Import Done.
                CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout);
            }
            catch (Exception e)
            {
                Utilities.LogMessage(currentMethod + ":: Exception: " + e.Message);
                Utilities.TakeScreenshot(currentMethod + "_Exception");
                throw;
            }

            Utilities.LogMessage(currentMethod + " Different Workload with different Status has been Enabled");
            isAllStatusEnabled = true;
        }

        /// <summary>
        /// This method Install given MP from Catalog
        /// </summary>
        /// <param name="mpName">string</param>
        private void AddMPsFromCatalog(string mpName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");
            try
            {
                WizardDialogSelectMPs mpWizardDialogSelectMPs = new WizardDialogSelectMPs(CoreManager.MomConsole);

                if (mpWizardDialogSelectMPs != null)
                {
                    Utilities.LogMessage(currentMethod + ":: MP wizard was successfully launched");
                }
                else
                {
                    throw new Dialog.Exceptions.WindowNotFoundException(currentMethod + ":: Unable to get the MP wizard dialog");
                }

                // Launch the Add From Catalog Dialog
                mpWizardDialogSelectMPs.Controls.SelectMPsToolbar.ToolbarItems[IndexOfAddButton].ScreenElement.WaitForReady();
                mpWizardDialogSelectMPs.Controls.SelectMPsToolbar.ToolbarItems[IndexOfAddButton].Click();
                CoreManager.MomConsole.ExecuteContextMenu(WizardDialogSelectMPs.Strings.SelectMPsToolbarAddFromCatalog, false);

                if (!MakeUIReadyForImport(ManagementPacks.ImportMethod.AddFromCatelog, maxRetry))
                    throw new Exception("Import UI is not ready for import");   //TODO : Think to handle it and continue with others

                SelectMPsFromCatalogDialog selectMPsFromCatalogDialog =
                    new SelectMPsFromCatalogDialog(CoreManager.MomConsole);
                if (selectMPsFromCatalogDialog != null)
                {
                    Utilities.LogMessage(currentMethod + ":: Add From Catalog dialog was successfully launched");
                    selectMPsFromCatalogDialog.Extended.SetFocus();
                    selectMPsFromCatalogDialog.FindText = mpName;
                    selectMPsFromCatalogDialog.ClickSearch();

                    System.Threading.Thread.Sleep(5000);    //Wait for 5s to search

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
                    if(rowCount==1) //Did not find this MP
                    {
                        Utilities.LogMessage(currentMethod + " :: Could not found MP in OC.");
                        Utilities.LogMessage(currentMethod + " :: Closing Select MP From Catalog Wizard.");
                        selectMPsFromCatalogDialog.Extended.SetFocus();
                        selectMPsFromCatalogDialog.ClickCancel();
                        return;
                    }

                    int rowPos = 0;
                    viewGrid.Rows[1].AccessibleObject.Click();
                    int rowTarget = 1;
                    Maui.Core.WinControls.DataGridViewRowCollection myRows = viewGrid.Rows;
                    while (rowTarget < rowCount)
                    {
                        myRows[rowTarget].AccessibleObject.DoDefaultAction();

                        string name = viewGrid.Rows[rowTarget].Cells[0].GetValue().Trim();
                        Utilities.LogMessage(currentMethod + " ::Current Row Text : " + name);
                        Utilities.LogMessage(currentMethod + " ::Looking for Text : " + mpName);
                        if (string.Equals(name, mpName, StringComparison.OrdinalIgnoreCase))
                        {
                            Utilities.LogMessage(currentMethod + " :: Text found at Row#: " + rowTarget);
                            break;
                        }
                        myRows[rowTarget].AccessibleObject.Click();
                        viewGrid.SendKeys(KeyboardCodes.DownArrow);

                        rowTarget++;
                        if (rowTarget == rowCount)
                        {
                            if (rowCount != viewGrid.Rows.Count)
                            {
                                rowCount = viewGrid.Rows.Count;
                                myRows = viewGrid.Rows;
                            }
                            Utilities.LogMessage(currentMethod + " :: New row count: " + rowCount.ToString());
                        }
                    }
                    if (rowTarget == rowCount) //Searched Till end and did not find
                    {
                        Utilities.LogMessage(currentMethod + " :: Could not found MP in OC.");
                        Utilities.LogMessage(currentMethod + " :: Closing Select MP From Catalog Wizard.");
                        selectMPsFromCatalogDialog.Extended.SetFocus();
                        selectMPsFromCatalogDialog.ClickCancel();
                        return;
                    }

                    selectMPsFromCatalogDialog.ClickSelect();
                    System.Threading.Thread.Sleep(2000);    //Need to check
                    selectMPsFromCatalogDialog.ClickAdd();
                }
            }
            catch (Exception ex)
            {
                Utilities.TakeScreenshot(currentMethod + "_" + mpName);
                Utilities.LogMessage(currentMethod + " :: Ex.Msg  :  " + ex.Message);
                Utilities.LogMessage(currentMethod + " :: StackTrace  :  " + ex.StackTrace);
            }
        }

        /// <summary>
        /// Selects the Administration view and navigates to the Management 
        /// Packs node.
        /// </summary>
        /// <returns>A reference to the Management Pack node</returns>
        /// <exception cref="System.NullReferenceException">NullReferenceException</exception>
        public Maui.Core.WinControls.TreeNode NavigateToNodeManagementPacks()
        {
            Utilities.LogMessage("NavigateToNodeManagementPacks(...) ");
            Maui.Core.WinControls.TreeNode node;
            //Utilities.TakeScreenshot("Before NavigateToNodeManagementPacks");
            if (CoreManager.MomConsole.NavigationPane.Title != Mom.Test.UI.Core.Console.NavigationPane.Strings.Administration)
            {
                // Select the Administration view
                CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(
                    NavigationPane.WunderBarButton.Administration);

                // Wait for the navigation pane to be ready.
                CoreManager.MomConsole.NavigationPane.ScreenElement.WaitForReady();
            }
            // check for current node
            try
            {

                Utilities.LogMessage("NavigateToNodeManagementPacks:: Check for current node " +
                    CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.SelectedItem.ToString());
                if (!CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.SelectedItem.ToString().Contains(NavigationPane.Strings.InstalledManagementPacks))
                {
                    Utilities.LogMessage("NavigateToNodeManagementPacks:: " +
                        "Current node selected is not managementpack, selecting management pack");
                    // Select the Installed Management Packs node in the administration tree
                    StringBuilder pathToView = new StringBuilder();
                    pathToView.Append(NavigationPane.Strings.AdminTreeViewAdministrationRoot);
                    pathToView.Append(Constants.PathDelimiter);
                    pathToView.Append(NavigationPane.Strings.ManagementPacks);
                    pathToView.Append(Constants.PathDelimiter);
                    pathToView.Append(NavigationPane.Strings.InstalledManagementPacks);

                    node = CoreManager.MomConsole.NavigationPane.SelectNode(
                        pathToView.ToString(), 
                        NavigationPane.NavigationTreeView.Administration);

                    Utilities.LogMessage("NavigateToNodeManagementPacks:: " +
                        "Management Packs node clicked");

                }
                else
                {
                    // get current node
                    Utilities.LogMessage("NavigateToNodeManagementPacks:: Returning current node " +
                      CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.SelectedItem.ToString());
                    node = CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.SelectedItem;
                }
            }
            catch (Exception)
            {
                Utilities.LogMessage("NavigateToNodeManagementPacks:: Try to get the node with old way : ");
                // Select the Management Packs node in the administration tree
                StringBuilder pathToView = new StringBuilder();
                pathToView.Append(NavigationPane.Strings.AdminTreeViewAdministrationRoot);
                pathToView.Append(Constants.PathDelimiter);
                pathToView.Append(NavigationPane.Strings.ManagementPacks);
                pathToView.Append(Constants.PathDelimiter);
                pathToView.Append(NavigationPane.Strings.InstalledManagementPacks);
                node = CoreManager.MomConsole.NavigationPane.SelectNode(
                        pathToView.ToString(),
                        NavigationPane.NavigationTreeView.Administration);
            }
            Utilities.TakeScreenshot("After clicked MP node");
            if (null == node)
            {
                throw new NullReferenceException("Unable to navigate the Administration tree's Management Pack node.");
            }
            return node;
        }

        /// <summary>
        /// Selects the Administration view and navigates to the Update and Recommendations node.
        /// </summary>
        /// <returns>A reference to the Update and Recommendations node</returns>
        /// <exception cref="System.NullReferenceException">NullReferenceException</exception>
        public Maui.Core.WinControls.TreeNode NavigateToNodeUpdatesAndRecommendations()
        {
            Utilities.LogMessage("NavigateToNodeUpdatesAndRecommendations(...) ");
            Maui.Core.WinControls.TreeNode node;
            
            if (CoreManager.MomConsole.NavigationPane.Title != Mom.Test.UI.Core.Console.NavigationPane.Strings.Administration)
            {
                // Select the Administration view
                CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(
                    NavigationPane.WunderBarButton.Administration);

                // Wait for the navigation pane to be ready.
                CoreManager.MomConsole.NavigationPane.ScreenElement.WaitForReady();
            }
            // check for current node
            try
            {
                Utilities.LogMessage("NavigateToNodeUpdatesAndRecommendations:: Check for current node " +
                    CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.SelectedItem.ToString());
                if (!CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.SelectedItem.ToString().Contains(NavigationPane.Strings.UpdatesAndRecommendations))
                {
                    Utilities.LogMessage("NavigateToNodeUpdatesAndRecommendations:: " +
                        "Current node selected is not Updates And Recommendations, selecting Updates and Recommendations");
                    // Select the Updates and Recommendations node in the administration tree
                    StringBuilder pathToView = new StringBuilder();
                    pathToView.Append(NavigationPane.Strings.AdminTreeViewAdministrationRoot);
                    pathToView.Append(Constants.PathDelimiter);
                    pathToView.Append(NavigationPane.Strings.ManagementPacks);
                    pathToView.Append(Constants.PathDelimiter);
                    pathToView.Append(NavigationPane.Strings.UpdatesAndRecommendations);

                    node = CoreManager.MomConsole.NavigationPane.SelectNode(
                        pathToView.ToString(),
                        NavigationPane.NavigationTreeView.Administration);

                    Utilities.LogMessage("NavigateToNodeUpdatesAndRecommendations:: " +
                        "Updates And Recommendations node clicked");

                }
                else
                {
                    // get current node
                    Utilities.LogMessage("NavigateToNodeUpdatesAndRecommendations:: Returning current node " +
                      CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.SelectedItem.ToString());
                    node = CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.SelectedItem;
                }
            }
            catch (Exception)
            {
                Utilities.LogMessage("NavigateToNodeUpdatesAndRecommendations:: Try to get the node with old way : ");
                // Select the Updates And Recommendations node in the administration tree
                StringBuilder pathToView = new StringBuilder();
                pathToView.Append(NavigationPane.Strings.AdminTreeViewAdministrationRoot);
                pathToView.Append(Constants.PathDelimiter);
                pathToView.Append(NavigationPane.Strings.ManagementPacks);
                pathToView.Append(Constants.PathDelimiter);
                pathToView.Append(NavigationPane.Strings.UpdatesAndRecommendations);
                node = CoreManager.MomConsole.NavigationPane.SelectNode(
                        pathToView.ToString(),
                        NavigationPane.NavigationTreeView.Administration);
            }
            Utilities.TakeScreenshot("After clicked Updates And Recommendations");
            if (null == node)
            {
                throw new NullReferenceException("Unable to navigate the Administration tree's Updates And Recommendations node.");
            }
            return node;
        }

        /// <summary>
        /// Selects the Administration view and navigates to the Tune Management Packs node.
        /// </summary>
        /// <returns>A reference to the Tune Management Packs node</returns>
        /// <exception cref="System.NullReferenceException">NullReferenceException</exception>
        public Maui.Core.WinControls.TreeNode NavigateToNodeTuneManagementPacks()
        {
            Utilities.LogMessage("NavigateToNodeTuneManagementPacks(...) ");
            Maui.Core.WinControls.TreeNode node;

            if (CoreManager.MomConsole.NavigationPane.Title != Mom.Test.UI.Core.Console.NavigationPane.Strings.Administration)
            {
                // Select the Administration view
                CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(
                    NavigationPane.WunderBarButton.Administration);

                // Wait for the navigation pane to be ready.
                CoreManager.MomConsole.NavigationPane.ScreenElement.WaitForReady();
            }
            // check for current node
            try
            {
                Utilities.LogMessage("NavigateToNodeTuneManagementPacks:: Check for current node " +
                    CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.SelectedItem.ToString());
                if (!CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.SelectedItem.ToString().Contains(NavigationPane.Strings.TuneManagementPack))
                {
                    Utilities.LogMessage("NavigateToNodeTuneManagementPacks:: " +
                        "Current node selected is not Tune Management Packs, selecting Tune Management Packs");
                    // Select the Tune Management Packs node in the administration tree
                    StringBuilder pathToView = new StringBuilder();
                    pathToView.Append(NavigationPane.Strings.AdminTreeViewAdministrationRoot);
                    pathToView.Append(Constants.PathDelimiter);
                    pathToView.Append(NavigationPane.Strings.ManagementPacks);
                    pathToView.Append(Constants.PathDelimiter);
                    pathToView.Append(NavigationPane.Strings.TuneManagementPack);

                    node = CoreManager.MomConsole.NavigationPane.SelectNode(
                        pathToView.ToString(),
                        NavigationPane.NavigationTreeView.Administration);

                    Utilities.LogMessage("NavigateToNodeTuneManagementPacks:: " +
                        "Tune Management Packs node clicked");
                }
                else
                {
                    // get current node
                    Utilities.LogMessage("NavigateToNodeTuneManagementPacks:: Returning current node " +
                      CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.SelectedItem.ToString());
                    node = CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView.SelectedItem;
                }
            }
            catch (Exception)
            {
                Utilities.LogMessage("NavigateToNodeTuneManagementPacks:: Try to get the node with old way : ");
                // Select the Tune Management Packs node in the administration tree
                StringBuilder pathToView = new StringBuilder();
                pathToView.Append(NavigationPane.Strings.AdminTreeViewAdministrationRoot);
                pathToView.Append(Constants.PathDelimiter);
                pathToView.Append(NavigationPane.Strings.ManagementPacks);
                pathToView.Append(Constants.PathDelimiter);
                pathToView.Append(NavigationPane.Strings.TuneManagementPack);
                node = CoreManager.MomConsole.NavigationPane.SelectNode(
                        pathToView.ToString(),
                        NavigationPane.NavigationTreeView.Administration);
            }
            Utilities.TakeScreenshot("After clicked Tune Management Packs");
            if (null == node)
            {
                throw new NullReferenceException("Unable to navigate the Administration tree's Tune Management Packs node.");
            }
            return node;
        }

        /// <summary>
        /// This function sets the minimum alert count to 1 from Identify management packs to tune window.
        /// </summary>
        private void SetIdentifyManagementPackToTune()
        {
            ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
            taskPane.ClickActionsLink(
                 Core.Console.ActionsPane.Strings.ActionsPaneAdminViews,
                 NavigationPane.Strings.ContextFilterData);
            MP.Dialogs.TuneManagementPackFilterDataDialog TuneMPDialog = new TuneManagementPackFilterDataDialog(CoreManager.MomConsole);
            if (TuneMPDialog != null)
            {
                Utilities.LogMessage("SetIdentifyManagementPackToTune:: TuneManagementPackFilterDataDialog wizard dialog was successfully found");
            }
            else
            {
                throw new Dialog.Exceptions.WindowNotFoundException("SetIdentifyManagementPackToTune:: Unable to get the TuneManagementPackFilterDataDialog wizard dialog");
            }
            TuneMPDialog.ScreenElement.WaitForReady();
            TuneMPDialog.Extended.SetFocus();
            Utilities.TakeScreenshot("IdentifyManagementPacksToTuneDialogWindow");
            //TODO: Add entry to TuneAlertParameter to pass min alert count as parameter.
            TuneMPDialog.takeMinimumAlertCountValue = 1;
            Utilities.TakeScreenshot("MinimumAlertValueChanged");
            TuneMPDialog.ClickOk();
            Utilities.LogMessage("SetIdentifyManagementPackToTune:: Closed TuneManagementPackFilterDataDialog");
            return;


        }

        /// <summary>
        /// This method selects a management pack after setting min alert count to 1.
        /// Then clicks on the Tune Alerts action and calls the overridesouces function.
        /// </summary>
        /// <returns>True/False</returns>
        /// <param name="TunealertsParams">Tunelertsparam Object</param>
        public bool ClickTuneAlertsAction(TuneAlertsParameters TunealertsParams)
        {
            Utilities.LogMessage("ClickTuneAlertsAction:: start");
            bool status = false;
            MP.Dialogs.TuneAlertsView alertview = null;
            
            Maui.Core.WinControls.TreeNode node = this.NavigateToNodeTuneManagementPacks();
            Utilities.LogMessage("ClickTuneAlertsAction:: Navigated to the Tune Management Packs node.");

            //Change minimum alert count to 1 to display all contents.
            SetIdentifyManagementPackToTune();

            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

            Core.Console.MomControls.GridControl mpGridView =
                CoreManager.MomConsole.ViewPane.Grid;
            if(mpGridView == null)
            {
                Utilities.LogMessage("ClickTuneAlertsAction:: Could not get control of Grid view.");
                return status;
            }
            
            int mpCount = mpGridView.Rows.Count;
            if(mpCount == 0)
            {
                Utilities.LogMessage("ClickTuneAlertsAction:: Could not find any Management Pack.");
                return status;
            }
            Utilities.TakeScreenshot("MPdiplayAfterFilterData");
            //choose the first management pack by default.
            // TODO: need to use params to input management pack and select it.
            mpGridView.Rows[1].AccessibleObject.Click();

            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

            ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
            if (taskPane == null)
            {
                Utilities.LogMessage("ClickTuneAlertsAction:: Could not get control of Actions pane.");
                return status;
            }
            taskPane.ClickActionsLink(
                 Core.Console.ActionsPane.Strings.ActionsPaneAdminViews,
                 NavigationPane.Strings.ContextTuneAlerts);
            Utilities.LogMessage("ClickTuneAlertsAction:: Clicked Tune Alerts Action");
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);
            Utilities.TakeScreenshot("TuneAlertsWindowOpened");
            
            Maui.Core.Window tempWindow = null;
            tempWindow = new Window(WindowType.Foreground);
            if (tempWindow == null)
            {
                Utilities.LogMessage("ClickTuneAlertsAction:: Could not get control of Tune Alerts Window.");
                return status;
            }
            alertview = new MP.Dialogs.TuneAlertsView(tempWindow.Extended.App);
            if (alertview == null)
            {
                Utilities.LogMessage("ClickTuneAlertsAction:: Could not create TuneAlertsView class.");
                return status;
            }

            status = alertview.clickOverrideSources(tempWindow, TunealertsParams);
            return status;
        }

        /// <summary>
        /// This method checks the Get MP link for third party UR
        /// </summary>
        /// <returns>True/False</returns>
        /// <param name="workloadParams">Workload Object</param>
        public bool VerifyGetMPForThirdPartyUR(WorkloadParameters workloadParams)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            bool status = false;

            string workloadName = workloadParams.workloadName;
            Utilities.LogMessage(currentMethod + ":: Workload Name : " + workloadName);

            Maui.Core.WinControls.TreeNode node = this.NavigateToNodeUpdatesAndRecommendations();
            Utilities.LogMessage(currentMethod + ":: Navigated to the Updates And Recommendations node.");

            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

            Maui.Core.WinControls.ListView workloads = CoreManager.MomConsole.ViewPane.ListViewWorkloads;

            if (workloads.Count == 0)
            {
                Utilities.LogMessage(currentMethod + ":: Could not find any workload on page.");
                return status;
            }
            Utilities.LogMessage(currentMethod + ":: Total worklaod on the view : " + workloads.Count);
            Utilities.LogMessage(currentMethod + ":: Going to select Third party Workload '" + workloadName + "' for Updates and Recommendations");
            if (!CoreManager.MomConsole.SelectListViewItems(workloadName, 0, workloads, false))
            {
                EnableThirdPartyWorkload();
                System.Threading.Thread.Sleep(300000);    //Wait for some time
                this.NavigateToNodeUpdatesAndRecommendations();
                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);
                Maui.Core.WinControls.ListView newWorkloads = CoreManager.MomConsole.ViewPane.ListViewWorkloads;
                if(!CoreManager.MomConsole.SelectListViewItems(workloadName, 0, newWorkloads, false))
                {
                    Utilities.LogMessage(currentMethod + ":: Did not find the '" + workloadName + "' workload after importing the test Recommendation MP");
                    return false;   //return false if did not find the 3rd party workload after installing test Recommendations MP.
                }
            }

            Utilities.LogMessage(currentMethod + ":: Selected Third party Workload '" + workloadName + "' for Updates and Recommendations");

            ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
            taskPane.ClickActionsLink(
                 Core.Console.ActionsPane.Strings.ActionsPaneAdminViews,
                 NavigationPane.Strings.ContextMenuGetMP);
            Utilities.LogMessage(currentMethod + ":: Clicked Get MP link for Third party Updates and Recommendations");
            Utilities.TakeScreenshot(currentMethod + "_After_GetMP_Clicked");
            System.Threading.Thread.Sleep(2000);    //Wait for some time to open the dialog

            //Click 'Ok' on Get MP dialog
            try
            {
                CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);
                Utilities.LogMessage(currentMethod + ":: Clicked OK from Get MP Dialog for Third party Updates and Recommendations");
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
            {
                Utilities.LogMessage(currentMethod + " :: Don't find Get MP dialog for Third party Updates and Recommendations");
                return status;
            }

            System.Threading.Thread.Sleep(2000);    //Wait for some time to open the IE
            //Kill the opened IE Process
            System.Diagnostics.Process[] runningIEProcess = System.Diagnostics.Process.GetProcessesByName("iexplore");
            for (int i = 0; i < runningIEProcess.Length; i++)
            {
                Utilities.LogMessage(currentMethod + " :: ProcessID : " + runningIEProcess[i].Id);
                runningIEProcess[i].Kill();
            }
            CoreManager.MomConsole.BringToForeground();
            CoreManager.MomConsole.WaitForStatusReady();
            status = true;

            return status;
        }

        /// <summary>
        /// This method veirfies that 'Get All MPs', 'View Guide' and 'View DLC Page' action for third party workloads
        /// </summary>
        /// <returns>True/False</returns>
        /// <param name="workloadParams">Workload Object</param>
        public bool VerifyDisabledActionsForThirdPartyUR(WorkloadParameters workloadParams)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            string workloadName = workloadParams.workloadName;
            Utilities.LogMessage(currentMethod + ":: Workload Name : " + workloadName);

            Maui.Core.WinControls.TreeNode node = this.NavigateToNodeUpdatesAndRecommendations();
            Utilities.LogMessage(currentMethod + ":: Navigated to the Updates And Recommendations node.");

            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

            Maui.Core.WinControls.ListView workloads = CoreManager.MomConsole.ViewPane.ListViewWorkloads;

            Utilities.LogMessage(currentMethod + ":: Going to select Third party Workload '" + workloadName + "' for Updates and Recommendations");
            if (!CoreManager.MomConsole.SelectListViewItems(workloadName, 0, workloads, false))
            {
                EnableThirdPartyWorkload();
                System.Threading.Thread.Sleep(300000);    //Wait for some time
                this.NavigateToNodeUpdatesAndRecommendations();
                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);
                Maui.Core.WinControls.ListView newWorkloads = CoreManager.MomConsole.ViewPane.ListViewWorkloads;
                if (!CoreManager.MomConsole.SelectListViewItems(workloadName, 0, newWorkloads, false))
                {
                    Utilities.LogMessage(currentMethod + ":: Did not find the '" + workloadName + "' workload after importing the test Recommendation MP");
                    return false;   //return false if did not find the 3rd party workload after installing test Recommendations MP.
                }
            }
            Utilities.LogMessage(currentMethod + ":: Selected Third party Workload '" + workloadName + "' for Updates and Recommendations");

            ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
            //Verify 'Get All MPs' Action
            try
            {
                Utilities.LogMessage(currentMethod + ":: Clicking 'Get All MPs' Action for Third Party workload");
                taskPane.ClickActionsLink(
                         Core.Console.ActionsPane.Strings.ActionsPaneAdminViews,
                         NavigationPane.Strings.ContextMenuGetAllMPs);
                return false;   //Get All MPs should not be clicked for Third party workload.
            }
            catch
            {
                // Click on Get All MPs should throw exception as action is disable for Third party workload.
                Utilities.LogMessage(currentMethod + ":: 'Get All MPs' action is disabled for Third party workload");
            }
            //Verify 'View Guide' link
            try
            {
                Utilities.LogMessage(currentMethod + ":: Clicking 'View Guide' Action for Third Party workload");
                taskPane.ClickActionsLink(
                         Core.Console.ActionsPane.Strings.ActionsPaneAdminViews,
                         NavigationPane.Strings.ContextMenuViewGuide);
                return false;   //View Guide Link should not be clicked for Third party workload.
            }
            catch
            {
                // Click on View Guide Link should throw exception as link is disable for Third party workload.
                Utilities.LogMessage(currentMethod + ":: View Guide link is disabled for Third party workload");
            }
            //Verify 'View DLC Page' link
            try
            {
                Utilities.LogMessage(currentMethod + ":: Clicking 'View DLC Page' Action for Third Party workload");
                taskPane.ClickActionsLink(
                         Core.Console.ActionsPane.Strings.ActionsPaneAdminViews,
                         NavigationPane.Strings.ContextMenuViewDLCPage);
                return false;   //View DLC Page Link should not be clicked for Third party workload.
            }
            catch
            {
                // Click on View DLC Page Link should throw exception as link is disable for Third party workload.
                Utilities.LogMessage(currentMethod + ":: View DLC Page link is disabled for Third party workload");
            }

            return true;
        }

        /// <summary>
        /// This method checks the Machine Details
        /// </summary>
        /// <returns>True/False</returns>
        /// <param name="workloadParams">Workload Object</param>
        public bool VerifyMoreInformationUI(WorkloadParameters workloadParams)
        {
            bool status = false;

            if(!isAllStatusEnabled)
            {
                EnableALLStatus();
            }

            string workloadStatus = workloadParams.workloadStatus;

            Utilities.LogMessage("VerifyMoreInformationUI:: Verifying More Information for Workload status : " + workloadStatus);

            Maui.Core.WinControls.TreeNode node = this.NavigateToNodeUpdatesAndRecommendations();
            Utilities.LogMessage("VerifyMoreInformationUI:: Navigated to the Updates And Recommendations node.");

            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

            Maui.Core.WinControls.ListView workloads = CoreManager.MomConsole.ViewPane.ListViewWorkloads;

            if(workloads.Count == 0)
            {
                Utilities.LogMessage("VerifyMoreInformationUI:: Could not find any workload on page.");
                return status;
            }

            CoreManager.MomConsole.SelectListViewItems(workloadStatus, 2, workloads, false);
                    ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
                    taskPane.ClickActionsLink(
                         Core.Console.ActionsPane.Strings.ActionsPaneAdminViews,
                         NavigationPane.Strings.ContextMenuMoreInformation);
                    Utilities.LogMessage("VerifyMoreInformationUI:: Opened More Information UI");

                    MP.Dialogs.MoreInformationDialog moreInfoDialog = new MoreInformationDialog(CoreManager.MomConsole);
                    if (moreInfoDialog != null)
                    {
                        Utilities.LogMessage("VerifyMoreInformationUI:: MoreInformationDialog wizard dialog was successfully found");
                    }
                    else
                    {
                        throw new Dialog.Exceptions.WindowNotFoundException("VerifyMoreInformationUI:: Unable to get the MoreInformationDialog wizard dialog");
                    }
                    moreInfoDialog.ScreenElement.WaitForReady();
                    moreInfoDialog.Extended.SetFocus();
                    Utilities.TakeScreenshot("VerifyMoreInformationUI");
                    moreInfoDialog.ClickClose();
                    Utilities.LogMessage("VerifyMoreInformationUI:: Closed More Information UI");

                    status = true;

            return status;
        }

        /// <summary>
        /// This method verifies that Updates and Recommendations view  should take less time than first load and more time after cache expired
        /// </summary>
        /// <returns>True/False</returns>
        /// <param name="isRefreshWithoutOCConnection">Refresh is with or without OC connection</param>
        public bool VerifyUpdatesAndRecommedationsViewRefreshTime(long expectedTimeToRefreshInMilliseconds, bool isRefreshWithoutOCConnection)
        {
            bool status = false;
            long refreshTimeTakenInMilliseconds = 0;

            Utilities.LogMessage("VerifyUpdatesAndRecommedationsViewRefreshTime(...)");

            this.NavigateToNodeUpdatesAndRecommendations();
            Utilities.LogMessage("VerifyUpdatesAndRecommedationsViewRefreshTime:: Navigated to the Updates And Recommendations node.");

            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

            //Select any workload to click on "Get MP" Link.
            //Here I am selecting first workload.
            Maui.Core.WinControls.ListView workloads = CoreManager.MomConsole.ViewPane.ListViewWorkloads;
            workloads.Items[0].Click();
            
            Maui.Core.WinControls.Menu contextMenu = new Maui.Core.WinControls.Menu(Maui.Core.WinControls.ContextMenuAccessMethod.ShiftF10);
            Utilities.LogMessage("VerifyUpdatesAndRecommedationsViewRefreshTime:: " + "After ShiftF10....");

            
            contextMenu.ScreenElement.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);
            Utilities.LogMessage("VerifyUpdatesAndRecommedationsViewRefreshTime:: " + "Clicking on Refresh");
            contextMenu.ExecuteMenuItem("Refresh");

            long currentTimeInMilliseconds = System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

            refreshTimeTakenInMilliseconds = (System.DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - currentTimeInMilliseconds;
            Utilities.LogMessage("VerifyUpdatesAndRecommedationsViewRefreshTime:: Time Taken to Update and Recommendations View Refresh : " + refreshTimeTakenInMilliseconds + " Milliseconds");

            if (isRefreshWithoutOCConnection && (refreshTimeTakenInMilliseconds < expectedTimeToRefreshInMilliseconds)) //Refresh by not re-establishing Catalog Connection so it should take less time
            { 
                status = true;
            }
            else if (refreshTimeTakenInMilliseconds > expectedTimeToRefreshInMilliseconds)//Refresh by re-establishing Catalog Connection so it should take more time
            {
                status = true;
            }

            return status;
        }

        /// <summary>
        /// This method verifies the Get MP link
        /// </summary>
        /// <returns>True/False</returns>
        public bool VerifyGetMP()
        {
            bool status = false;
            int importTimeoutInSeconds = 3600;
            int retry = 0;
            int maxRetry = 2;       //Used for the case when one or more MP is of security risk.
            int selectedWorkload = 0;
            int workloadCount = 0;

            Utilities.LogMessage("VerifyGetMP(...)");

            try
            {
                this.NavigateToNodeUpdatesAndRecommendations();
                Utilities.LogMessage("VerifyGetMP:: Navigated to the Updates And Recommendations node.");

                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

                while(retry++ < maxRetry)
                {
                    Maui.Core.WinControls.ListView workloads = CoreManager.MomConsole.ViewPane.ListViewWorkloads;                    
                    workloadCount = workloads.Count;
                    Utilities.LogMessage("VerifyGetMP:: Total workoad count before Get MP : " + workloadCount);

                    if (workloadCount == 0)
                    {
                        Utilities.LogMessage("VerifyGetMP:: Could not find any workload on page.");
                        return status;
                    }

                    //Select any workload to click on "Get MP" Link.
                    //Here I am selecting first workload.
                    workloads.Items[selectedWorkload].Select();
                    Utilities.LogMessage("VerifyGetMP:: Execute Get MP for workload " + workloads.Items[selectedWorkload].Text);

                    ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
                    taskPane.ClickActionsLink(
                         Core.Console.ActionsPane.Strings.ActionsPaneAdminViews,
                         NavigationPane.Strings.ContextMenuGetMP);
                    CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);
                    Sleeper.Delay(Constants.OneSecond * 20); //Waiting for 20s. Will be removed afer caching implementation of Updates and Recommendations page

                    MP.Dialogs.WizardDialogSelectMPs getMPWizardDialog = new WizardDialogSelectMPs(CoreManager.MomConsole);
                    if (getMPWizardDialog != null)
                    {   
                        Utilities.LogMessage("VerifyGetMP:: MP wizard dialog was successfully found");
                    }
                    else
                    {
                        throw new Dialog.Exceptions.WindowNotFoundException("VerifyGetMP:: Unable to get the MP wizard dialog");
                    }
                    getMPWizardDialog.ScreenElement.WaitForReady();
                    getMPWizardDialog.Extended.SetFocus();
                    System.Threading.Thread.Sleep(5000);

                    //If Install Button is not enable then check for MP in Error start or resolve MP
                    if (!getMPWizardDialog.Controls.InstallButton.IsEnabled)
                    {
                        if (CheckForErrorOrResolveDependencies(getMPWizardDialog) == false)
                        {
                            Utilities.LogMessage("VerifyGetMP:: One or More MP is in Error State.");
                            return status;
                        }
                    }

                    Utilities.LogMessage("VerifyGetMP:: Click install button to finish the wizard.");
                    getMPWizardDialog.ClickInstall();
                    Utilities.TakeScreenshot("VerifyGetMP_AfterClickingInstall");

                    try
                    {   //This is the case when one or more MP which are ready to install present at security risk.
                        //Conformation Message : "One or more management packs which are ready to install present a security risk. Are you sure you want to continue?"
                        CoreManager.MomConsole.ConfirmChoiceDialog(true);
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        Utilities.LogMessage("VerifyGetMP:: Don't find confirm choice dialog");
                    }

                    // CloseMPImportWizard
                    this.CloseMPImportWizard(importTimeoutInSeconds);
                    CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                    CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

                    workloads = CoreManager.MomConsole.ViewPane.ListViewWorkloads;
                    if (workloadCount == workloads.Count + 1)
                    {
                        Utilities.LogMessage("VerifyGetMP:: Selected Workload has been Installed Successfully");
                        status = true;
                        break;
                    }
                }

                if(status == false)
                {
                    Utilities.LogMessage("VerifyGetMP:: Selected Workload has not been Installed Successfully");
                }

            }
            catch (Exception e)
            {
                Utilities.LogMessage("VerifyGetMP:: Exception: " + e.Message);
                Utilities.TakeScreenshot("VerifyGetMP_Exception");
                throw;
            }

            return status;
        }

        /// <summary>
        /// This method verifies the Get All MPs link
        /// </summary>
        /// <returns>True/False</returns>
        public bool VerifyGetAllMPs()
        {
            bool status = false;
            int importTimeoutInSeconds = 3600;
            int retry = 0;
            int maxRetry = 2;
            int selectedWorkload = 0;
            int workloadCount = 0;

            Utilities.LogMessage("VerifyGetAllMPs(...)");

            try
            {
                this.NavigateToNodeUpdatesAndRecommendations();
                Utilities.LogMessage("VerifyGetAllMPs:: Navigated to the Updates And Recommendations node.");

                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

                Maui.Core.WinControls.ListView workloads = CoreManager.MomConsole.ViewPane.ListViewWorkloads;
                workloadCount = workloads.Count;
                Utilities.LogMessage("VerifyGetAllMPs:: Total workoad count before Get All MPs : " + workloadCount);

                if (workloadCount == 0)
                {
                    Utilities.LogMessage("VerifyGetMP:: Could not find any workload on page.");
                    return status;
                }

                //Select any workload to click on "Get All MPs" Link.
                //Here I am selecting first workload.
                workloads.Items[selectedWorkload].Select();
                Utilities.LogMessage("VerifyGetAllMPs:: Execute Get All MPs for workload " + workloads.Items[selectedWorkload].Text);

                ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
                taskPane.ClickActionsLink(
                     Core.Console.ActionsPane.Strings.ActionsPaneAdminViews,
                     NavigationPane.Strings.ContextMenuGetAllMPs);
                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);
                Sleeper.Delay(Constants.OneSecond * 20); //Waiting for 20s. Will be removed afer caching implementation of Updates and Recommendations page

                MP.Dialogs.WizardDialogSelectMPs getAllMPsWizardDialog = new WizardDialogSelectMPs(CoreManager.MomConsole);
                if (getAllMPsWizardDialog != null)
                {
                    Utilities.LogMessage("VerifyGetAllMPs:: MP wizard dialog was successfully found");
                }
                else
                {
                    throw new Dialog.Exceptions.WindowNotFoundException("VerifyGetAllMPs:: Unable to get the MP wizard dialog");
                }
                getAllMPsWizardDialog.ScreenElement.WaitForReady();
                getAllMPsWizardDialog.Extended.SetFocus();
                System.Threading.Thread.Sleep(5000);

                //If Install Button is not enable then check for MP in Error start or resolve MP
                if (!getAllMPsWizardDialog.Controls.InstallButton.IsEnabled)
                {
                    if (CheckForErrorOrResolveDependencies(getAllMPsWizardDialog) == false)
                    {
                        Utilities.LogMessage("VerifyGetAllMPs:: One or More MP is in Error State.");
                        return status;
                    }
                }
                Utilities.LogMessage("VerifyGetAllMPs:: Click install button to finish the wizard.");
                getAllMPsWizardDialog.ClickInstall();
                Utilities.TakeScreenshot("VerifyGetAllMPs_AfterClickingInstall");

                try
                {
                    CoreManager.MomConsole.ConfirmChoiceDialog(true);
                    //MomConsoleApp.ButtonCaption.Yes,
                    //Core.Console.Views.Views.Strings.MomDialogTitle,
                    //StringMatchSyntax.ExactMatch, MomConsoleApp.ActionIfWindowNotFound.Ignore);
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage("VerifyGetAllMPs:: Don't find confirm choice dialog");
                }

                // CloseMPImportWizard
                this.CloseMPImportWizard(importTimeoutInSeconds);
                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

                // Verify one workload Sucessfully Installed
                this.NavigateToNodeUpdatesAndRecommendations();
                Utilities.LogMessage("VerifyGetAllMPs:: Navigated to the Updates And Recommendations node to verify Get All MPs.");
                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);
                Utilities.LogMessage("VerifyGetAllMPs:: Total workoad count after Get All MPs : " + CoreManager.MomConsole.ViewPane.ListViewWorkloads.Count);

                if (CoreManager.MomConsole.ViewPane.ListViewWorkloads.Count == 0)
                {
                    Utilities.LogMessage("VerifyGetAllMPs:: All Workloads has been Installed Successfully");
                    status = true;
                }
                else
                {
                    Utilities.LogMessage("VerifyGetAllMPs:: Some Workloads has not been Installed Successfully");
                }
            }
            catch (Exception e)
            {
                Utilities.LogMessage("VerifyGetAllMPs:: Exception: " + e.Message);
                Utilities.TakeScreenshot("VerifyGetAllMPs_Exception");
                throw;
            }

            return status;
        }

        /// <summary>
        /// This method verify View Guide link
        /// </summary>
        /// <returns>True/False</returns>
        public bool VerifyViewGuide()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            bool status = false;

            //Navigate to Update and Recommendations view
            this.NavigateToNodeUpdatesAndRecommendations();
            Utilities.LogMessage(currentMethod + " :: Navigated to the Updates And Recommendations node.");

            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

            Maui.Core.WinControls.ListView workloads = CoreManager.MomConsole.ViewPane.ListViewWorkloads;

            if (workloads.Count == 0)
            {
                Utilities.LogMessage(currentMethod + " :: Could not find any workload on page.");
                return status;
            }

            try
            {
                //Select any workload to click on "View Guide" Link.
                //Here I am selecting first workload.
                workloads.Items[0].Select();
                Utilities.LogMessage(currentMethod + " :: Clicking View Guide for workload " + workloads.Items[0].Text);

                ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
                taskPane.ClickActionsLink(
                     Core.Console.ActionsPane.Strings.ActionsPaneAdminViews,
                     NavigationPane.Strings.ContextMenuViewGuide);
                Utilities.LogMessage(currentMethod + " :: After Clicking ViewGuide ");
                //Sleep 1s to take screenshot of UI
                Sleeper.Delay(Constants.OneSecond);
                Utilities.TakeScreenshot(currentMethod + "_After_ViewGuide_Click");
                try
                {
                    //Close any open dialog
                    CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage(currentMethod + " :: Don't find dialog");
                }

                //Kill the opened IE Process
                System.Diagnostics.Process[] runningIEProcess = System.Diagnostics.Process.GetProcessesByName("iexplore");
                for (int i = 0; i < runningIEProcess.Length; i++)
                {
                    Utilities.LogMessage(currentMethod + " :: ProcessID : " + runningIEProcess[i].Id);
                    runningIEProcess[i].Kill();
                }

                status = true;
            }
            catch(Exception ex)
            {
                Utilities.LogMessage(currentMethod + " :: Exception : " + ex.Message);
                Utilities.TakeScreenshot(currentMethod + "_Exception");
            }            

            return status;
        }

        /// <summary>
        /// This method verify View DLC page
        /// </summary>
        /// <returns>True/False</returns>
        public bool VerifyViewDLCPage()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            bool status = false;

            //Navigate to Update and Recommendations view
            this.NavigateToNodeUpdatesAndRecommendations();
            Utilities.LogMessage(currentMethod + " :: Navigated to the Updates And Recommendations node.");

            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

            Maui.Core.WinControls.ListView workloads = CoreManager.MomConsole.ViewPane.ListViewWorkloads;

            if (workloads.Count == 0)
            {
                Utilities.LogMessage(currentMethod + " :: Could not find any workload on page.");
                return status;
            }

            try
            {
                //Select any workload to click on "View DLC Page" Link.
                //Here I am selecting first workload.
                workloads.Items[0].Select();
                Utilities.LogMessage(currentMethod + " :: Clicking View DLC Page for workload " + workloads.Items[0].Text);

                ActionsPane taskPane = CoreManager.MomConsole.ActionsPane;
                taskPane.ClickActionsLink(
                     Core.Console.ActionsPane.Strings.ActionsPaneAdminViews,
                     NavigationPane.Strings.ContextMenuViewDLCPage);
                Utilities.LogMessage(currentMethod + " :: After Clicking View DLC Page ");
                //Sleep 1s to take screenshot of UI
                Sleeper.Delay(Constants.OneSecond);
                Utilities.TakeScreenshot(currentMethod + "_After_ViewDLCPage_Click");
                try
                {
                    //Close any open dialog
                    CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage(currentMethod + " :: Don't find dialog");
                }

                //Kill the opened IE Process
                System.Diagnostics.Process[] runningIEProcess = System.Diagnostics.Process.GetProcessesByName("iexplore");
                for (int i = 0; i < runningIEProcess.Length; i++)
                {
                    Utilities.LogMessage(currentMethod + " :: ProcessID : " + runningIEProcess[i].Id);
                    runningIEProcess[i].Kill();
                }

                status = true;
            }
            catch (Exception ex)
            {
                Utilities.LogMessage(currentMethod + " :: Exception : " + ex.Message);
                Utilities.TakeScreenshot(currentMethod + "_Exception");
            }

            return status;
        }

        /// <summary>
        /// This method checks the MP status. If any MP is in Error Status the return false. If MP is in resolve state then resolve its dependencies
        /// </summary>
        /// <returns>True/False</returns>
        /// <param name="mpWizardDialogSelectMPs">WizardDialogSelectMPs</param>
        public bool CheckForErrorOrResolveDependencies(WizardDialogSelectMPs mpWizardDialogSelectMPs)
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

                //Scan each row to resolve or delete.
                int rowIndex = 1; // 0th row is header
                dataGrid.Rows[rowIndex].AccessibleObject.Click();
                for (; rowIndex < dataGrid.Rows.Count; rowIndex++)
                {
                    string rowStatus = dataGrid.GetCellText(rowIndex, statusColIndex);
                    if (rowStatus == "(null)")//if (string.IsNullOrEmpty(rowStatus))
                    {
                        dataGrid.Rows[rowIndex].AccessibleObject.Click();
                        dataGrid.SendKeys(KeyboardCodes.DownArrow);
                        continue;
                    }
                    if (rowStatus.Trim() == "Error")
                    {
                        Utilities.LogMessage(currentMethod + ":: One or More MP is in Error state");
                        Utilities.LogMessage(currentMethod + ":: Closing Wizard and returning back");
                        mpWizardDialogSelectMPs.ClickCancel();
                        CoreManager.MomConsole.ConfirmChoiceDialog(true);
                        return false;
                    }
                    if (rowStatus.Trim() == "Resolve")
                    {
                        dataGrid.Rows[rowIndex].AccessibleObject.Click(MouseFlags.RightButton);
                        Utilities.LogMessage(currentMethod + " :: Right clicked on row");
                        Menu mpImportWizardContextMenu = new Menu(Constants.DefaultContextMenuTimeout);
                        mpImportWizardContextMenu.ExecuteMenuItem(
                            WizardDialogSelectMPs.Strings.SelectMPsContextMenuResolve);


                        dataGrid.ScreenElement.WaitForReady();
                        dataGrid.WaitForRowsLoaded();

                        //Refresh the Grid to resolve other MP and start search from first row
                        // rowIndex = 1;
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

                    //If this resolve enable the Install Button then stop search
                    if (mpWizardDialogSelectMPs.Controls.InstallButton.IsEnabled)
                        break;
                }
            }
            return true;
        }

        /// <summary>
        /// Add MPs from Disk in the Select MP from Disk Dialog
        /// Assume the Wizard Dialog "Select MPs" is already open
        /// </summary>
        /// <param name="mpsAddFromDisk">mpsAddFromDisk</param>
        public void AddMPsFromDisk(string mpsAddFromDisk)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            // Utilities.TakeScreenshot("Before adding MPs from Disk");

            WizardDialogSelectMPs mpWizardDialogSelectMPs =
                new WizardDialogSelectMPs(CoreManager.MomConsole);

            if (mpWizardDialogSelectMPs != null)
            {
                Utilities.LogMessage(currentMethod + ":: MP wizard dialog was successfully found");
            }
            else
            {
                throw new Maui.Core.Window.Exceptions.WindowNotFoundException(currentMethod +
                    ":: Unable to get the MP wizard dialog");
            }
            
            // Launch the Add From Disk dialog.
            mpWizardDialogSelectMPs.Controls.SelectMPsToolbar.ToolbarItems[IndexOfAddButton].ScreenElement.WaitForReady();

            // Sometimes WaitForReady is not reliable, so adding retry logic to execute menu item
            int loop = 0;
            while (loop < 5)
            {
                try
                {
                    mpWizardDialogSelectMPs.Controls.SelectMPsToolbar.ToolbarItems[IndexOfAddButton].Click();                    
                    CoreManager.MomConsole.ExecuteContextMenu(WizardDialogSelectMPs.Strings.SelectMPsToolbarAddFromDisk, false);
                    break;
                }
                catch (Maui.Core.WinControls.Menu.Exceptions.ItemNotFoundException)
                {
                    Utilities.LogMessage(currentMethod + ":: Add from disk menu item not found, wait 1 second and retry");
                    Sleeper.Delay(Constants.OneSecond);
                    loop++;
                }
                catch (Exception)
                {
                    Utilities.LogMessage(currentMethod + ":: Add from disk menu item execute failed, try to use keyboard");                   
                    Keyboard.SendKeys(Core.Common.KeyboardCodes.DownArrow);
                    Keyboard.SendKeys(Core.Common.KeyboardCodes.DownArrow);
                    Utilities.TakeScreenshot("Try to use keyboard pop up add from disk window");
                    Keyboard.SendKeys(Core.Common.KeyboardCodes.Enter);
                    loop++;
                }
            }

            if (!MakeUIReadyForImport(ImportMethod.AddFromDisk, maxRetry))
                throw new Exception("Import UI is not ready for import");

            OpenDialog openDialog = new OpenDialog(
                CoreManager.MomConsole,
                OpenDialog.OpenDialogTitle.ManagementPacksSelect);

            if (openDialog != null)
            {
                // Utilities.TakeScreenshot("After displaying disk MP dialog");

                Utilities.LogMessage(currentMethod + ":: Add From Disk dialog was successfully launched");
                openDialog.Extended.SetFocus();
                Utilities.LogMessage(currentMethod + ":: Focus set to OpenDialog");

                if (mpsAddFromDisk != null)
                {
                    // Clear the text if it didn't got clear form the previous state
                    openDialog.FileNameText = "";
                    // Enter the to-be-imported MP files. 
                    openDialog.FileNameText = mpsAddFromDisk;
                    Utilities.LogMessage(currentMethod + ":: filename(s) entered: " + mpsAddFromDisk);

                    // wait for 2 seconds For finding the MPs from disk
                    Utilities.LogMessage(currentMethod + ":: Wait 2 seconds for finding the MPs from disk.");
                    Sleeper.Delay(Constants.OneSecond * 2);
                    openDialog.ClickOpen();
                    Utilities.LogMessage(currentMethod + ":: clicked open button");
                    Utilities.LogMessage(currentMethod + ":: Successfully added MP from disk");
                }
                else
                {
                    Utilities.LogMessage(currentMethod + ":: Click the Cancel button");
                    openDialog.ClickCancel();
                    Utilities.LogMessage(currentMethod + ":: Clicked the Cancel button");
                }

                CoreManager.MomConsole.WaitForDialogClose(openDialog,10);
                mpWizardDialogSelectMPs.ScreenElement.WaitForReady();
                CoreManager.MomConsole.Waiters.WaitForWindowIdle(
                    CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout);
            }
            else
            {
                Utilities.TakeScreenshot("Failed to display disk MP dialog");
                throw new Maui.Core.Window.Exceptions.WindowNotFoundException(currentMethod +
                    ":: Unable to launch Add From Disk dialog");
            }
        }
        /// <summary>
        /// MakeUIReadyForImport : make UI ready for import to happen
        /// </summary>
        /// <param name="callingMethod"></param>
        /// <param name="maxRetry"></param>
        /// <returns>bool</returns>
        public bool MakeUIReadyForImport(ImportMethod callingMethod, int maxRetry)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");
            int tries = 0;
            try
            {
                while (tries < maxRetry)
                {
                    Utilities.LogMessage(currentMethod + ":: Attempt " + tries);
                    try
                    {
                        if (callingMethod == ImportMethod.AddFromDisk) // it is called from addFromDisk method
                        {
                            Utilities.LogMessage(currentMethod + ":: Check for ConfirmChoiceDialog and click no");

                            CoreManager.MomConsole.ConfirmChoiceDialog(Mom.Test.UI.Core.Console.MomConsoleApp.ButtonCaption.No,
                                WizardDialogSelectMPs.Strings.CheckCatalogTitle,
                                Maui.Core.Utilities.StringMatchSyntax.WildCard,
                                Mom.Test.UI.Core.Console.MomConsoleApp.ActionIfWindowNotFound.Ignore);

                            OpenDialog openDialog = new OpenDialog(
                                CoreManager.MomConsole,
                                OpenDialog.OpenDialogTitle.ManagementPacksSelect);

                            Utilities.LogMessage(currentMethod + ":: Check for dialog to be visible");
                            return openDialog.IsVisible; // if the dialog is not avilable it will throw exception.
                            // we will retry it again in few seconds
                        }
                        if (callingMethod == ImportMethod.AddFromCatelog) // it is called from addFromCatelog method
                        {
                            SelectMPsFromCatalogDialog selectMPsFromCatalogDialog =
                                new SelectMPsFromCatalogDialog(CoreManager.MomConsole);


                            Utilities.LogMessage(currentMethod + ":: Check for dialog to be visible");
                            return selectMPsFromCatalogDialog.IsVisible; // if the dialog is not avilable it will throw exception.
                            // we will retry it again in few seconds
                        }

                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        try
                        {                                                        
                            try
                            {
                                //Workaround method,connection timing issue for web service, import MP from catalog will throw a exception dialog. Bug#185836
                                Utilities.LogMessage(currentMethod + ":: First to check for SecurityCertificateProblemDialog and click ContinueNotRecommended");
                                SecurityCertificateProblemDialog mpSecurityCertDialog =
                                    new SecurityCertificateProblemDialog(CoreManager.MomConsole);

                                //Click Search Button with the Enpty Find Text To refresh The Grid With New Data
                                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(mpSecurityCertDialog.Controls.ContinueNotRecommendedButton, Constants.DefaultDialogTimeout);
                                mpSecurityCertDialog.ClickContinueNotRecommended();
                                CoreManager.MomConsole.WaitForDialogClose(mpSecurityCertDialog, Constants.OneMinute / 1000);
                                return true;
                            }
                            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                            {
                                Utilities.LogMessage(currentMethod + ":: Didn't find mpSecurityCertDialog, IgnoreWindowNotFoundException");
                            }
                            // Add to deal with CannotConnectMPWebServiceDialog in case network issue happens
                            Utilities.LogMessage(currentMethod + ":: Check for cannot connect dialog");
                            try
                            {
                                CannotConnectMPWebServiceDialog cannotConnectMPWebServiceDialog = new CannotConnectMPWebServiceDialog(CoreManager.MomConsole);
                                if (cannotConnectMPWebServiceDialog != null)
                                {
                                    Utilities.LogMessage(currentMethod + ":: CannotConnectDialog found, Import MPs interrupt! Close it in order not to affect following case.");
                                    cannotConnectMPWebServiceDialog.ClickClose();
                                    CoreManager.MomConsole.WaitForDialogClose(cannotConnectMPWebServiceDialog, Constants.OneMinute / 1000);
                                    return false;
                                }
                            }
                            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                            {
                                Utilities.LogMessage(currentMethod + ":: Didn't find CannotConnect Dialog, IgnoreWindowNotFoundException");
                            }

                            Utilities.LogMessage(currentMethod + ":: Check for SecurityCertificateProblemDialog and click ContinueNotRecommended");
                            SecurityCertificateProblemDialog _mpSecurityCertDialog =
                                new SecurityCertificateProblemDialog(CoreManager.MomConsole);

                            //Click Search Button with the Enpty Find Text To refresh The Grid With New Data
                            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(_mpSecurityCertDialog.Controls.ContinueNotRecommendedButton, Constants.DefaultDialogTimeout);
                            _mpSecurityCertDialog.ClickContinueNotRecommended();
                            CoreManager.MomConsole.WaitForDialogClose(_mpSecurityCertDialog, Constants.OneMinute / 1000);
                            return true;
                            
                        }
                        catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                        {
                            Utilities.LogMessage(currentMethod + ":: Ignore WindowNotFoundException");
                        }
                        catch (Maui.Core.Window.Exceptions.UnknownActiveWinException)
                        {
                            Utilities.LogMessage(currentMethod + ":: Ignore UnknownActiveWinException");
                        }                        
                    }
                    tries++; 
                    Sleeper.Delay(Constants.OneSecond); // wait for 1 second if the Connect to Web Service dialog still exists                                  
                }
            }
            catch (Exception e)
            {
                Utilities.LogMessage(currentMethod + ":: Exception: " + e);
                Utilities.TakeScreenshot(currentMethod + "_Exception");
                throw; // rethrow the same exception
            }
            return false;
        }
        /// <summary>
        /// Add MPs from Catalog in the Select MP from Catalog Dialog
        /// Assume the Wizard Dialog "Select MPs" is already open
        /// </summary>
        // <exception cref="Core.Window.Exceptions.WindowsNotFoundException">WindowNotFoundException</exception>
        public void AddMPsFromCatalog(
            string predefinedViewSelectedInCatalog,
            string keywordToFindMPsInCatalog,
            string[] mpGroupsNeedToSelectInCatalog,
            string[] mpsNeedToSelectInCatalog)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");
            try
            {
                WizardDialogSelectMPs mpWizardDialogSelectMPs =
                    new WizardDialogSelectMPs(CoreManager.MomConsole);

                if (mpWizardDialogSelectMPs != null)
                {
                    Utilities.LogMessage(currentMethod +
                        ":: MP wizard dialog was successfully found");
                }
                else
                {
                    throw new Maui.Core.Window.Exceptions.WindowNotFoundException(
                        currentMethod + ":: Unable to get the MP wizard dialog");
                }

                // Launch the Add From Catalog Dialog
                mpWizardDialogSelectMPs.Controls.SelectMPsToolbar.ToolbarItems[IndexOfAddButton].ScreenElement.WaitForReady();
                mpWizardDialogSelectMPs.Controls.SelectMPsToolbar.ToolbarItems[IndexOfAddButton].Click();

                CoreManager.MomConsole.ExecuteContextMenu(WizardDialogSelectMPs.Strings.SelectMPsToolbarAddFromCatalog, false);
                if (!MakeUIReadyForImport(ImportMethod.AddFromCatelog, maxRetry))
                    throw new Exception("Import UI is not ready for import");

                SelectMPsFromCatalogDialog selectMPsFromCatalogDialog =
                    new SelectMPsFromCatalogDialog(CoreManager.MomConsole);


                if (selectMPsFromCatalogDialog != null)
                {
                    Utilities.LogMessage(currentMethod + ":: Add From Catalog dialog was successfully launched");
                    selectMPsFromCatalogDialog.Extended.SetFocus();
                    Utilities.LogMessage(currentMethod + ":: Focus set to Select MPs From Catalog dialog");

                    // selectMPsFromCatalogDialog.Controls.ComboBox1.SelectByText(predefinedViewSelectedInCatalog, true);
                    Utilities.LogMessage(currentMethod +
                        ":: The predefined view item is " +
                        predefinedViewSelectedInCatalog);
                    // clear the Find Text selection first as the old value is still cached 
                    if (selectMPsFromCatalogDialog.FindText.Trim() != "")
                    {
                        selectMPsFromCatalogDialog.FindText = "";

                    }
                    //Click Search Button with the Enpty Find Text To refresh The Grid With New Data
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(selectMPsFromCatalogDialog.Controls.SearchButton, Constants.DefaultDialogTimeout);
                    
                    if (keywordToFindMPsInCatalog != "" && keywordToFindMPsInCatalog != null)
                    {   //this is to remove any numbers from string.  
                        Regex rx = new Regex(@"\d+"); // Work arround as currently search dosen't return anything IF Find Text has  numeric value ,                   
                        selectMPsFromCatalogDialog.FindText = rx.Replace(keywordToFindMPsInCatalog, String.Empty);
                    }

                    selectMPsFromCatalogDialog.ClickSearch();

                    //wait for Select Button enable For ManagementPack Grid View To refresh With new Data
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(selectMPsFromCatalogDialog.Controls.SelectButton, Constants.DefaultDialogTimeout);
                    
                    DataGridView viewGrid = new DataGridView(
                        selectMPsFromCatalogDialog,
                        SelectMPsFromCatalogDialog.ControlIDs.ManagementPacksInTheCatalogPropertyGridView);

                    if (viewGrid == null)
                    {
                        Utilities.LogMessage(currentMethod + ":: viewGrid not found.");
                        throw new DataGrid.Exceptions.UnknownWinControlException(currentMethod + ":: viewGrid not found.");
                    }

                    // dataGrid.Extended.SetFocus();
                    viewGrid.Extended.SetFocus();

                    // Expand all rows in the ManagementPacksInTheCatalogPropertyGridView.
                    // Otherwise the collapsed row won't be found. 

                    // Utilities.TakeScreenshot("BeforeExpandingAllTheGroupRows");
                    int rowCount = viewGrid.Rows.Count;
                    Utilities.LogMessage(currentMethod + ":: Total rowCount found in Grid. " + rowCount.ToString());
                    if (rowCount <= 1)
                    {
                        Utilities.LogMessage(currentMethod + ":: viewGrid contains no rows");
                        throw new DataGrid.Exceptions.DataGridRowNotFoundException(currentMethod + ":: viewGrid is empty.");
                    }

                    int rowPos = 0;
                    viewGrid.Rows[1].AccessibleObject.Click();

                    int rowTarget = 1;
                    Maui.Core.WinControls.DataGridViewRowCollection myRows = viewGrid.Rows;
                    while (rowTarget < rowCount)
                    {
                        //work around global run myRows[rowTarget].AccessibleObject.StateText value not always can be read bug#234030.
                        Utilities.LogMessage(currentMethod + ":: Expanding row. " + rowPos.ToString());
                        myRows[rowTarget].AccessibleObject.DoDefaultAction();
                        //if (!myRows[rowTarget].AccessibleObject.StateText.Contains(MsaaResources.Strings.Collapsed.ToLowerInvariant()))

                        Utilities.LogMessage(currentMethod + ":: Moving the highlight to the next row.");
                        myRows[rowTarget].AccessibleObject.Click();
                        viewGrid.SendKeys(KeyboardCodes.DownArrow);

                        rowTarget++;
                        if (rowTarget == rowCount)
                        {
                            Utilities.LogMessage(currentMethod + ":: Hit the last row count - Lets get the row count once more");
                            Utilities.LogMessage(currentMethod + ":: Original row count: " + rowCount.ToString());
                            if (rowCount != viewGrid.Rows.Count)
                            {
                                rowCount = viewGrid.Rows.Count;
                                myRows = viewGrid.Rows;
                            }
                            Utilities.LogMessage(currentMethod + ":: New row count: " + rowCount.ToString());
                        }
                    }

                    viewGrid.SendKeys(KeyboardCodes.Ctrl + "(" + KeyboardCodes.Home + ")");
                    viewGrid.Rows[1].Cells[1].AccessibleObject.Click(KeyboardFlags.ControlFlag);

                    MomControls.GridControl dataGrid = new MomControls.GridControl(
                       selectMPsFromCatalogDialog,
                       SelectMPsFromCatalogDialog.ControlIDs.ManagementPacksInTheCatalogPropertyGridView);

                    if (mpGroupsNeedToSelectInCatalog != null)
                    {
                        if (mpGroupsNeedToSelectInCatalog.Length > 0)
                        {
                            for (int i = 0; i < mpGroupsNeedToSelectInCatalog.Length; i++)
                            {
                                Utilities.LogMessage(mpGroupsNeedToSelectInCatalog[i]);

                                // Find rows that meet the following:
                                //    Cell[0] matches mpGroupsNeedToSelectInCatalog[i]
                                //    Row state text contains either "+", or "-"
                                // Click these rows with Control Key pressed. 
                                DataGridViewRow dataGridViewRow = dataGrid.FindData(mpGroupsNeedToSelectInCatalog[i], 0);
                                if (dataGridViewRow == null)
                                {
                                    Utilities.LogMessage(currentMethod + ":: Could not find MP Group name for '" +
                                        mpGroupsNeedToSelectInCatalog[i] + "'");
                                    throw new DataGrid.Exceptions.DataGridRowNotFoundException(currentMethod +
                                        ":: Could not find the specified MP Group name");
                                }
                                else
                                {
                                    Utilities.LogMessage(currentMethod + ":: Find MP Group name for '" +
                                        mpGroupsNeedToSelectInCatalog[i] + "'");

                                    rowPos = dataGridViewRow.AccessibleObject.Index;
                                    Utilities.LogMessage(currentMethod + ":: row Position is '" + rowPos + "'");
                                    // ScrollToRow(dataGrid, rowPos, 6);
                                    dataGrid.ScrollToRow(rowPos);
                                    dataGridViewRow.Cells[1].AccessibleObject.Click(KeyboardFlags.ControlFlag);
                                    Utilities.LogMessage(currentMethod + ":: Pressed Control key");
                                    Utilities.LogMessage(currentMethod + ":: Validate the status of selected object : " + dataGridViewRow.Cells[1].AccessibleObject.Selected.ToString());
                                    if (!dataGridViewRow.Cells[1].AccessibleObject.Selected)
                                    {
                                        // dataGrid.SendKeys(KeyboardCodes.DownArrow); // this is to make it centered
                                        for (int j = 0; j < dataGrid.VerticalScrollbar.PageSize; j++)
                                        {
                                            dataGrid.VerticalScrollbar.LineDown();
                                            dataGridViewRow.Cells[1].AccessibleObject.Click(KeyboardFlags.ControlFlag);
                                            Utilities.LogMessage(currentMethod + ":: Pressed Control key again");
                                            if (dataGridViewRow.Cells[1].AccessibleObject.Selected)
                                                break;
                                        }
                                    }
                                    //Utilities.LogMessage(currentMethod + ":: Pressed Control key");
                                }
                            }
                        }
                    }

                    if (mpsNeedToSelectInCatalog != null)
                    {
                        if (mpsNeedToSelectInCatalog.Length > 0)
                        {
                            for (int i = 0; i < mpsNeedToSelectInCatalog.Length; i++)
                            {
                                // Find rows that meet the following: 
                                //    Cell[0] matches mpsNeedToSelectInCatalog[i]
                                //    Row state text doesn't contain "+", "-"
                                // Click these rows with Control Key pressed. 
                                if (mpsNeedToSelectInCatalog[i].Trim() == "") continue;
                                DataGridViewRow dataGridViewRow = dataGrid.FindData(mpsNeedToSelectInCatalog[i], 0);
                                if (dataGridViewRow == null)
                                {
                                    Utilities.LogMessage(currentMethod + ":: Could not find MP name for '" +
                                        mpGroupsNeedToSelectInCatalog[i] + "'");
                                    throw new DataGrid.Exceptions.DataGridRowNotFoundException(currentMethod +
                                        ":: Could not find the specified MP name");
                                }
                                else
                                {
                                    Utilities.LogMessage(currentMethod + ":: Find MP name for '" +
                                        mpsNeedToSelectInCatalog[i] + "'");
                                    rowPos = dataGridViewRow.AccessibleObject.Index;
                                    Utilities.LogMessage(currentMethod + ":: row Position is '" + rowPos + "'");

                                    //ScrollToRow(dataGrid, rowPos, 6);
                                    dataGrid.ScrollToRow(rowPos);
                                    dataGridViewRow.Cells[1].AccessibleObject.Click(KeyboardFlags.ControlFlag);
                                    Utilities.LogMessage(currentMethod + ":: Pressed Control key");
                                    Utilities.LogMessage(currentMethod + ":: Validate the status of selected object : " + dataGridViewRow.Cells[1].AccessibleObject.Selected.ToString());
                                    if (!dataGridViewRow.Cells[1].AccessibleObject.Selected)
                                    {
                                        // dataGrid.SendKeys(KeyboardCodes.DownArrow); // this is to make it centered
                                        for (int j = 0; j < dataGrid.VerticalScrollbar.PageSize; j++)
                                        {
                                            dataGrid.VerticalScrollbar.LineDown();
                                            dataGridViewRow.Cells[1].AccessibleObject.Click(KeyboardFlags.ControlFlag);
                                            Utilities.LogMessage(currentMethod + ":: Pressed Control key again");
                                            if (dataGridViewRow.Cells[1].AccessibleObject.Selected)
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    // After selecting MPs, click select button
                    selectMPsFromCatalogDialog.ClickSelect();
                    Utilities.LogMessage(currentMethod + ":: Clicked Select button");

                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(selectMPsFromCatalogDialog.Controls.AddButton, Constants.DefaultDialogTimeout);
                    selectMPsFromCatalogDialog.ClickAdd();
                    Utilities.LogMessage(currentMethod + ":: Clicked Add button");

                    // CoreManager.MomConsole.WaitForDialogClose(selectMPsFromCatalogDialog, 5);
                    CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout);
                }
                else
                {
                    throw new Maui.Core.Window.Exceptions.WindowNotFoundException(currentMethod + ":: Unable to launch Add From Catalog dialog");
                }
            }
            catch (Exception)
            {
                Utilities.TakeScreenshot(currentMethod + "_Exception");
                throw; // rethrow the same exception
            }
        }

        /// <summary>
        /// Remove or Resolve MPs from MP Wizard
        /// </summary>
        /// <param name="mpName">mp Name</param>
        /// <param name="mpWizardAction">mpWizardAction</param>
        // <exception cref="Dialog.Exceptions.WindowNotFoundException">WindowNotFoundException</exception>
        // <exception cref="DataGrid.Exceptions.DataGridRowNotFoundException">DataGridRowNotFoundException</exception>
        public void RemoveResolveMPs(string[] mpName, MPWizardAction mpWizardAction)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            for (int arrayIndex = 0; arrayIndex < mpName.Length; arrayIndex++)
            {
                Utilities.LogMessage(mpName[arrayIndex]);
            }

            WizardDialogSelectMPs mpWizardDialogSelectMPs =
                new WizardDialogSelectMPs(CoreManager.MomConsole);

            if (mpWizardDialogSelectMPs != null)
            {
                Utilities.LogMessage(currentMethod + ":: MP wizard dialog was successfully found");
            }
            else
            {
                throw new Dialog.Exceptions.WindowNotFoundException(currentMethod + ":: Unable to get the MP wizard dialog");
            }

            MomControls.GridControl dataGrid = new MomControls.GridControl(
                mpWizardDialogSelectMPs, WizardDialogSelectMPs.ControlIDs.ManagementPacksSelectedToInstallPropertyGridView);

            dataGrid.ScreenElement.WaitForReady();

            if (dataGrid != null)
            {

                // dataGrid.Extended.AccessibleObject.Click();
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

                Maui.Core.WinControls.DataGridViewRow dataGridViewRow = null;
                
                for (int i = 0; i < mpName.Length; i++)
                {
                    //dataGridViewRow = dataGrid.FindData(mpName[i], 1);

                    int retry = 0;
                    int retryFind = 10;
                    while (retry < retryFind)
                    {
                        dataGridViewRow = dataGrid.FindData(mpName[i], 1);

                        if (dataGridViewRow == null)
                        {
                            Utilities.LogMessage(currentMethod + ":: Could not find MP name for '" +
                                mpName[i] + "'");
                            Utilities.LogMessage(currentMethod + ":: Retry to find again, retry times: " +  retry.ToString());
                            Sleeper.Delay(Core.Common.Constants.OneSecond);
                            //throw new DataGrid.Exceptions.DataGridRowNotFoundException(currentMethod + ":: Could not find the specified MP name");
                            if(++retry == retryFind)
                                throw new DataGrid.Exceptions.DataGridRowNotFoundException(currentMethod + ":: Could not find the specified MP name");
                        }
                        else
                        {
                            Utilities.LogMessage(currentMethod + ":: Find MP name for '" +
                                mpName[i] + "'");
                            int rowPos = dataGridViewRow.AccessibleObject.Index;
                            Utilities.LogMessage(currentMethod + ":: row Position is '" + rowPos + "'");
                            if (!dataGridViewRow.Cells[1].AccessibleObject.Selected)
                            {
                                Utilities.LogMessage(currentMethod + ":: Control is not selected Selecting control : '" + rowPos + "'");
                                if (i == 0)
                                    dataGridViewRow.Cells[1].AccessibleObject.Click(MouseClickType.SingleClick);
                                else
                                    dataGridViewRow.Cells[1].AccessibleObject.Click(KeyboardFlags.ControlFlag);
                                //dataGridViewRow.Cells[1].AccessibleObject.Click(MouseClickType.SingleClick);
                            }
                            Utilities.LogMessage(currentMethod + ":: Pressed Control key");
                            break;
                        }
                    }

                }

                switch (mpWizardAction)
                {
                    case MPWizardAction.RemoveMPsViaToolStripRemoveButton:
                        {
                            mpWizardDialogSelectMPs.Controls.SelectMPsToolbar.ToolbarItems[IndexOfRemoveButton].Click();
                            break;
                        }
                    case MPWizardAction.RemoveMPsViaMPErrorDialog:
                        {
                            dataGridViewRow.Cells[4].AccessibleObject.Click(MouseClickType.SingleClick);

                            MPErrorDialog mpErrorDialog = new MPErrorDialog(CoreManager.MomConsole);

                            if (mpErrorDialog != null)
                            {
                                Utilities.LogMessage(currentMethod + ":: MP error dialog was successfully opened");
                                mpErrorDialog.ClickRemove();
                                Utilities.LogMessage(currentMethod + ":: Error MP was removed");
                            }
                            else
                            {
                                throw new Dialog.Exceptions.WindowNotFoundException(currentMethod + ":: Unable to open the MP Error dialog");
                            }
                            break;
                        }
                    case MPWizardAction.RemoveMPsViaContextMenu:
                        {
                            Utilities.LogMessage(currentMethod + ":: Remove MP from Context Menu");

                            dataGridViewRow.Cells[1].AccessibleObject.Click(MouseFlags.RightButton);

                            Menu mpImportWizardContextMenu = new Menu(Constants.DefaultContextMenuTimeout);
                            mpImportWizardContextMenu.ExecuteMenuItem(
                                WizardDialogSelectMPs.Strings.SelectMPsContextMenuRemove);

                            // dataGridViewRow.Cells[1].AccessibleObject.Click(MouseFlags.RightButton);
                            break;
                        }
                    case MPWizardAction.ResolveMPsViaContextMenu:
                        {
                            dataGridViewRow.Cells[1].AccessibleObject.Click(MouseFlags.RightButton);

                            Menu mpImportWizardContextMenu = new Menu(Constants.DefaultContextMenuTimeout);
                            mpImportWizardContextMenu.ExecuteMenuItem(
                                WizardDialogSelectMPs.Strings.SelectMPsContextMenuResolve);
                            break;
                        }
                    case MPWizardAction.ResolveMPsViaMPWarningDialog:
                        {
                            dataGridViewRow.Cells[4].AccessibleObject.Click(MouseClickType.SingleClick);

                            MPWarningDialog mpWarningDialog = new MPWarningDialog(CoreManager.MomConsole);

                            if (mpWarningDialog != null)
                            {
                                Utilities.LogMessage(currentMethod + ":: MP warning dialog was successfully opened");
                                mpWarningDialog.ClickResolve();
                                Utilities.LogMessage(currentMethod + ":: warning MP was resolved");
                            }
                            else
                            {
                                throw new Dialog.Exceptions.WindowNotFoundException(currentMethod + ":: Unable to open the MP warning dialog");
                            }
                            break;
                        }
                }
                mpWizardDialogSelectMPs.ScreenElement.WaitForReady();
                Utilities.LogMessage(currentMethod + ":: Clicked remove button");
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: dataGrid not found.");
                throw new DataGrid.Exceptions.UnknownWinControlException(currentMethod + ":: dataGrid not found.");
            }
        }

        /// <summary>
        /// Allow MP Import to completed in seconds defined by the parameter. 
        /// </summary>
        /// <param name="importTimeoutInSeconds">Seconds defined to timeout</param>
        // <exception cref="Dialog.Exceptions.WindowNotFoundException">WindowNotFoundException</exception>
        // <exception cref="System.TimeoutException">TimeoutException</exception>
        public void CloseMPImportWizard(int importTimeoutInSeconds)
        {
            string currentMethod = Utilities.GetCallingMethodNameAndLogIt();
            // Utilities.TakeScreenshot("Enter CloseMPImportWizard");

            WizardDialogImportMPs mpWizardDialogImportMPs = new WizardDialogImportMPs(CoreManager.MomConsole);

            try
            {
                // Wait for MPs download
                this.WaitForMPsDownloaded(mpWizardDialogImportMPs);

                // Wait for MPs install
                CoreManager.MomConsole.WaitForDisabledButton(mpWizardDialogImportMPs.Controls.StopButton, importTimeoutInSeconds);

                mpWizardDialogImportMPs.ClickClose();
                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                Utilities.LogMessage(currentMethod + ":: Import Management Packs wizard is closed."); 
            }
            catch (System.TimeoutException)
            {
                Utilities.TakeScreenshot("MPImporttimedout");
                StopImportingMPsAndCloseImportMPsWizard(mpWizardDialogImportMPs);

                throw;
            }
        }

        /// <summary>
        /// Import MPs from disk with predefined 300 seconds timeout setting.
        /// </summary>
        /// <param name="mpName">mpName</param>
        public void ImportMPFromDisk(string[] mpName)
        {
            int importTimeoutInSeconds = 300;

            ImportMPFromDisk(mpName, importTimeoutInSeconds);
        }

        /// <summary>
        /// Import MPs from disk. 
        /// </summary>
        /// <param name="mpName">mpName</param>
        /// <param name="importTimeoutInSeconds">importTimeoutInSeconds</param>
        public void ImportMPFromDisk(string[] mpName, int importTimeoutInSeconds)
        {
            List<MPImportParameters> mpImportCollection = new List<MPImportParameters>();

            for (int i = 0; i < mpName.Length; i++)
            {
                MPImportParameters mpImportParam = new ManagementPacks.MPImportParameters();
                mpImportParam.MPsAddFromDisk = mpName[i];
                mpImportCollection.Add(mpImportParam);
            }

            ImportManagementPacks(mpImportCollection, importTimeoutInSeconds);
        }

        /// <summary>
        /// Import MPs with predefined 300 seconds timeout setting. 
        /// </summary>
        /// <param name="mpImportParamCollection">mpImportParamCollection</param>
        public void ImportManagementPacks(List<MPImportParameters> mpImportParamCollection)
        {
            int importTimeoutInSeconds = 300;
            ImportManagementPacks(mpImportParamCollection, importTimeoutInSeconds);
        }

        /// <summary>
        /// Import Management Packs
        /// </summary>
        /// <param name="mpImportParamCollection">mpImportParamCollection</param>
        /// <param name="importTimeoutInSeconds">importTimeoutInSeconds</param>
        // <exception cref="NullReferenceException">NullReferenceException</exception>
        // <exception cref="Dialog.Exceptions.WindowNotFoundException">Dialog.Exceptions.WindowNotFoundException</exception>
        public void ImportManagementPacks(List<MPImportParameters> mpImportParamCollection, int importTimeoutInSeconds)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");
            try
            {

                // The item count in the parameter collection cannot be less than 1.  
                if (mpImportParamCollection.Count < 1)
                {
                    //throw null reference error
                    throw new NullReferenceException(currentMethod + ":: the parameter cannot be null");
                }

                // Navigate to the ManagementPacks node in the Administration tree. 
                Maui.Core.WinControls.TreeNode mpViewNode = this.NavigateToNodeManagementPacks();

                // launch the Import MP Wizard
                CoreManager.MomConsole.ExecuteContextMenu(NavigationPane.Strings.ContextMenuInstallManagementPack,true);

                WizardDialogSelectMPs mpWizardDialogSelectMPs = new WizardDialogSelectMPs(CoreManager.MomConsole);

                if (mpWizardDialogSelectMPs != null)
                {
                    Utilities.LogMessage(currentMethod + ":: MP wizard was successfully launched");
                }
                else
                {
                    throw new Dialog.Exceptions.WindowNotFoundException(currentMethod + ":: Unable to get the MP wizard dialog");
                }

                // Utilities.TakeScreenshot("Launched MP Import Wizard");

                Utilities.LogMessage(currentMethod + ":: ParamCollection Count is " + mpImportParamCollection.Count);

                // Loop through each parameter in the parameter list to perform the actions
                for (int i = 0; i < mpImportParamCollection.Count; i++)
                {
                    string[] mpName = null;
                    string[] mpGroupName = null;

                    // This is the case when Wizard is launched and then closed immediately
                    if (mpImportParamCollection[i].MPsAddFromDisk == null &&
                        mpImportParamCollection[i].MPGroupsNeedToSelectInCatalog == "" &&
                        mpImportParamCollection[i].MPsNeedToSelectInCatalog == "" &&
                        mpImportParamCollection[i].MPsRemoveFromErrorMPDialog == null &&
                        mpImportParamCollection[i].MPsRemoveFromToolStripRemoveButton == null &&
                        mpImportParamCollection[i].MPsRemoveFromContextMenu == null &&
                        mpImportParamCollection[i].MPsResolveFromWarningMPDialog == null &&
                        mpImportParamCollection[i].KeywordToFindMPsInCatalog == null &&
                        mpImportParamCollection[i].MPsResolveFromContextMenu == null)
                    {
                        mpWizardDialogSelectMPs.ClickCancel();
                        mpWizardDialogSelectMPs = null;
                    }

                    // Add Mp from Disk
                    if (mpImportParamCollection[i].MPsAddFromDisk != null)
                    {
                        Utilities.LogMessage(currentMethod + ":: Start to add MP from disk.");
                        AddMPsFromDisk(mpImportParamCollection[i].MPsAddFromDisk);
                        Sleeper.Delay(Constants.OneSecond);
                    }
                    // Add Mp from Catalog
                    if ((mpImportParamCollection[i].MPGroupsNeedToSelectInCatalog != "") ||
                        (mpImportParamCollection[i].MPsNeedToSelectInCatalog != "") ||
                        (mpImportParamCollection[i].KeywordToFindMPsInCatalog != "")
                        )
                    {
                        Utilities.LogMessage(currentMethod + ":: Start to add MP from catalog.");

                        Utilities.LogMessage(currentMethod + ":: Print MP Groups name");
                        Utilities.LogMessage(mpImportParamCollection[i].MPGroupsNeedToSelectInCatalog);
                        Utilities.LogMessage(mpImportParamCollection[i].MPsNeedToSelectInCatalog);

                        if (mpImportParamCollection[i].MPGroupsNeedToSelectInCatalog != "")
                        {
                            mpGroupName = GetDelimitedString(
                                mpImportParamCollection[i].MPGroupsNeedToSelectInCatalog,
                                MPNameSeparator);

                            for (int j = 0; j < mpGroupName.Length; j++)
                            {
                                Utilities.LogMessage(currentMethod + ":: Print MP Groups name");
                                Utilities.LogMessage(mpGroupName[j]);
                            }
                        }

                        if (mpImportParamCollection[i].MPsNeedToSelectInCatalog != "")
                        {
                            mpName = GetDelimitedString(
                                mpImportParamCollection[i].MPsNeedToSelectInCatalog,
                                MPNameSeparator);
                        }

                        AddMPsFromCatalog(
                            mpImportParamCollection[i].PredefinedViewSelectedInCatalog,
                            mpImportParamCollection[i].KeywordToFindMPsInCatalog,
                            mpGroupName,
                            mpName);
                    }
                    // Remove Mp from Tool Strip
                    if (mpImportParamCollection[i].MPsRemoveFromToolStripRemoveButton != null)
                    {
                        Utilities.LogMessage(currentMethod + ":: Start to remove MP through tool strip.");
                        // Get the MP names
                        mpName = GetDelimitedString(
                            mpImportParamCollection[i].MPsRemoveFromToolStripRemoveButton,
                            MPNameSeparator);

                        // Remove the MPs from selected-to-install list
                        RemoveResolveMPs(mpName, MPWizardAction.RemoveMPsViaToolStripRemoveButton);
                        //RemoveMPsViaToolStripRemoveButton(mpName);
                    }
                    // Remove the MP from Error Mp dialog
                    if (mpImportParamCollection[i].MPsRemoveFromErrorMPDialog != null)
                    {
                        Utilities.LogMessage(currentMethod + ":: Start to remove MP through Error Dialog.");

                        // Get the MP names
                        mpName = GetDelimitedString(
                            mpImportParamCollection[i].MPsRemoveFromErrorMPDialog,
                            MPNameSeparator);

                        // Remove the MPs from selected-to-install list via Error Dialog
                        RemoveResolveMPs(mpName, MPWizardAction.RemoveMPsViaMPErrorDialog);
                    }
                    // remove the mp from context menu
                    if (mpImportParamCollection[i].MPsRemoveFromContextMenu != null)
                    {
                        Utilities.LogMessage(currentMethod + ":: Start to remove MP through Context Menu.");
                        Utilities.LogMessage(currentMethod + mpImportParamCollection[i].MPsRemoveFromContextMenu);
                        mpName = GetDelimitedString(
                            mpImportParamCollection[i].MPsRemoveFromContextMenu,
                            MPNameSeparator);

                        // Remove the MPs from selected-to-install list via Context Menu
                        RemoveResolveMPs(mpName, MPWizardAction.RemoveMPsViaContextMenu);
                    }
                    // Resolve the MP from Context Menu
                    if (mpImportParamCollection[i].MPsResolveFromContextMenu != null)
                    {
                        Utilities.LogMessage(currentMethod + ":: Start to resolve MP through Context Menu.");
                        mpName = GetDelimitedString(
                            mpImportParamCollection[i].MPsResolveFromContextMenu,
                            MPNameSeparator);

                        // Remove the MPs from selected-to-install list via Context Menu
                        RemoveResolveMPs(mpName, MPWizardAction.ResolveMPsViaContextMenu);
                    }

                    if (mpImportParamCollection[i].MPsResolveFromWarningMPDialog != null)
                    {

                        Utilities.LogMessage(currentMethod + ":: Start to resolve MP through MP Warning Dialog.");
                        mpName = GetDelimitedString(
                            mpImportParamCollection[i].MPsResolveFromContextMenu,
                            MPNameSeparator);

                        // Resolve the MPs from selected-to-install list via Context Menu
                        RemoveResolveMPs(mpName, MPWizardAction.ResolveMPsViaMPWarningDialog);
                    }
                }

                // Proceed the Install button
                Utilities.LogMessage(currentMethod + ":: Click install button to finish the wizard.");
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(mpWizardDialogSelectMPs.Controls.InstallButton, Constants.DefaultDialogTimeout);
                mpWizardDialogSelectMPs.ClickInstall();
                Utilities.LogMessage(currentMethod + ":: Install button clicked.");
                Utilities.TakeScreenshot(currentMethod + "_AfterClickingInstall");
                try
                {
                    CoreManager.MomConsole.ConfirmChoiceDialog(true);
                    //MomConsoleApp.ButtonCaption.Yes,
                    //Core.Console.Views.Views.Strings.MomDialogTitle,
                    //StringMatchSyntax.ExactMatch, MomConsoleApp.ActionIfWindowNotFound.Ignore);
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage(currentMethod + ":: Don't find confirm choice dialog");
                }

                // CloseMPImportWizard
                this.CloseMPImportWizard(importTimeoutInSeconds);
                //Waiting for some time for Mp to Appear In Mp view Once Import Done.
                CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout);

            }
            catch (Exception e)
            {
                Utilities.LogMessage(currentMethod + ":: Exception: " + e);
                Utilities.TakeScreenshot(currentMethod + "_Exception");
                throw;
            }

        }

        /// <summary>
        /// This function allows the Management Pack files to be selected. 
        /// </summary>
        /// <param name="managementPackFilenames">Management Pack file name(s) to open</param>
        /// <remarks>Needs the full path to select the MP file unless in the MOM folder</remarks>
        public void SelectManagementPackForPreInstallationList(
            string managementPackFilenames)
        {
            Utilities.LogMessage("SelectManagementPackForPreInstallationList(...)");

            // Display the Management Pack File Open dialog
            OpenDialog openDialog = this.GetManagementPacksOpenDialog();

            // Set the filenames to Open
            openDialog.FileNameText = managementPackFilenames;
            Utilities.LogMessage("SelectManagementPackForPreInstallationList:: filename(s) entered: " +
                managementPackFilenames);

            // Tab to 'Files of type' control
            openDialog.SendKeys(KeyboardCodes.Tab);
            Utilities.LogMessage("SelectManagementPackForPreInstallationList:: Tab key pressed");

            // Tab to 'Open' button
            openDialog.SendKeys(KeyboardCodes.Tab);
            Utilities.LogMessage("SelectManagementPackForPreInstallationList:: Tab key pressed");
            /*
                            TODO: Why is Click Open button not working?
             *              // Click the Open button
                            openDialog.ClickOpen();
                            context.Trc("DisplayDialog:: Open button clicked");
            */

            // Invoke the Open button with the Enter key
            openDialog.SendKeys(KeyboardCodes.Enter);
            Utilities.LogMessage("SelectManagementPackForPreInstallationList:: Enter key pressed");
        }

        /// <summary>
        /// This method allows a Management Pack to be deleted by
        /// its display name.
        /// </summary>
        /// <param name="managementPackName">Name of the Management Pack
        /// as displayed in the View Pane</param>
        /// <history>
        /// [a-joelj]   12JAN09 Added two separate 2-second delays between Click methods because they are executed 
        ///                     close enough together (less than 1 second apart) to sometimes represent a DoubleClick
        /// </history>
        public void DeleteManagementPack(string managementPackName)
        {
            Utilities.LogMessage("DeleteManagementPack:: " + managementPackName);

            // Navigate to the ManagementPacks node in
            // the Administration tree.
            this.NavigateToNodeManagementPacks();
            Utilities.LogMessage("DeleteManagementPack :: " +
                "Navigated to the management packs node.");
            
            // Refresh the list of MPs.
            CoreManager.MomConsole.WaitForStatusReady();
            CoreManager.MomConsole.ViewPane.Grid.SendKeys(KeyboardCodes.F5);

            //// Wait for MP view to load MPs.
            CoreManager.MomConsole.WaitForStatusReady();
            CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout);

            Core.Console.MomControls.GridControl mpGridView =
                CoreManager.MomConsole.ViewPane.Grid;
            int mpCount = mpGridView.Rows.Count;
            
            int columnIndex =
                mpGridView.GetColumnTitlePosition(ViewPane.Strings.AdministrationGridViewColumnName);

            // get the grid row
            Maui.Core.WinControls.DataGridViewRow mpGridViewRow =
                mpGridView.FindData(
                    managementPackName,
                    columnIndex);

            // based on device type and management mode
            if (mpGridViewRow != null)
            {
                Utilities.LogMessage("DeleteManagementPack:: left-clicking cell");

                ////scroll down to row below current to make sure it's fully visible
                //if ((mpGridViewRow.AccessibleObject.Index + 1) < mpGridView.Rows.Count)
                //{
                //    mpGridView.ClickCell(mpGridViewRow.AccessibleObject.Index + 1,
                //        columnIndex);
                //}                              
                
                // click cell first normally.
                //mpGridView.ClickCell(
                //    mpGridViewRow.AccessibleObject.Index,
                //    columnIndex);
                //CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

                Maui.Core.WinControls.Menu contextMenu = null;

                Utilities.LogMessage("DeleteManagementPack:: right-clicking cell");
                // right-click and delete
                try
                {
                    mpGridView.ClickCell(
                        mpGridViewRow.AccessibleObject.Index,
                        columnIndex,
                        MouseFlags.LeftButton);
                }
                catch (Maui.Core.ActiveAccessibility.Exceptions.CantSelectElementException)
                {
                    //Bug#178519
                    Utilities.LogMessage("DeleteManagementPack:: Click cell failed, use mpGridViewRow.Cells[0].Click() method to retry click");
                    mpGridViewRow.Cells[0].Click();
                }

                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                CoreManager.MomConsole.WaitForStatusReady();
                CoreManager.MomConsole.BringToForeground();
                contextMenu = new Maui.Core.WinControls.Menu(Maui.Core.WinControls.ContextMenuAccessMethod.ShiftF10);

                //contextMenu.WaitContextMenuWithTimeOut(Core.Common.Constants.DefaultContextMenuTimeout);
                contextMenu.ScreenElement.WaitForReady();

                try
                {
                    Utilities.LogMessage("DeleteManagementPack:: executing context menu item");
                    contextMenu.ExecuteMenuItem(
                            ViewPane.Strings.AdministrationContextMenuDelete);
                }
                catch (Maui.Core.WinControls.MenuItem.Exceptions.MenuItemNotFoundException)
                {
                    Utilities.LogMessage("DeleteManagementPack:: cannot find context menu item '" +
                        ViewPane.Strings.AdministrationContextMenuDelete +
                        "'");

                    Utilities.LogMessage("DeleteManagementPack:: send Del key to delete item");

                    //send Esc key to cancel context menu in case it shows up after catching this exception
                    Utilities.LogMessage("DeleteManagementPack:: send key: '" + KeyboardCodes.Esc.ToString() + "'");
                    CoreManager.MomConsole.SendKeys(KeyboardCodes.Esc);

                    //send Del key to delete item
                    Utilities.LogMessage("DeleteManagementPack:: send key: '" + KeyboardCodes.Del.ToString() + "'");
                    CoreManager.MomConsole.SendKeys(KeyboardCodes.Del);
                }

                // confirm the deletion
                Utilities.LogMessage("DeleteManagementPack:: confirming delete");
                int retry = 0;
                while (retry < Core.Common.Constants.DefaultMaxRetry)
                {
                    try
                    {
                        CoreManager.MomConsole.ConfirmChoiceDialog(
                            MomConsoleApp.ButtonCaption.Yes,
                            Core.Console.Views.Views.Strings.MomDialogTitle,
                            StringMatchSyntax.ExactMatch, MomConsoleApp.ActionIfWindowNotFound.Error);
                        break;
                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        retry++;
                        Utilities.LogMessage("DeleteManagementPack:: cannot find delete confirm dialog, retry again : " + retry);
                    }
                }
                //Wait for console Status ready, Bug#205668
                CoreManager.MomConsole.WaitForStatusReady();
                CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout);

                //Wait for MP disappeared from grid view
                CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccess(
                    delegate()
                    {
                        int currentMPCount = CoreManager.MomConsole.ViewPane.Grid.Rows.Count;
                        Utilities.LogMessage("DeleteManagementPack:: currentMPCount : " + currentMPCount);
                        return currentMPCount == mpCount - 1;
                    },
                    Constants.OneMinute * 3
                    );
                
                Utilities.TakeScreenshot("After_Delete");
            }
            else
            {
                throw
                    new Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException(
                    "Failed to find the search term, '" + managementPackName + "', in the grid!");
            }
        }

        /// <summary>
        /// Method to select a particular MP row and bring up its context menu
        /// in the MP view based on the MP name and the context menu item
        /// passed as parameters.
        /// </summary>
        /// <param name="mpName">The name of MP</param>
        /// <param name="contextMenuText">Context Menu Item Text</param>
        /// <exception cref="Maui.Core.WinControls.DataGrid.Exceptions.DataGridRowNotFoundException">DataGridViewRowNotFoundException</exception>
        public void ExecuteContextMenuForRow(string mpName, string contextMenuText)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

            //Create instance of mp Grid Control
            MomControls.GridControl mpGridView =
                new MomControls.GridControl(CoreManager.MomConsole,
                MomControls.GridControl.ControlIDs.ViewPaneGrid);

            if (mpGridView != null)
            {
                Utilities.LogMessage(currentMethod + ":: mpGridView found, select MP");

                // Get the Index position of the ColumnName of "Name"                    
                int columnIndex = mpGridView.GetColumnTitlePosition(ViewPane.Strings.AdministrationGridViewColumnName);
                Utilities.LogMessage(currentMethod + ":: success getcolumntitleposition");


                // Get the row in Grid.
                Maui.Core.WinControls.DataGridViewRow mpGridViewRow =
                    mpGridView.FindData(mpName, columnIndex);

                if (mpGridViewRow != null)
                {
                    Utilities.LogMessage(currentMethod + ":: left-clicking cell");

                    //scroll down to row below current to make sure it's fully visible
                    if ((mpGridViewRow.AccessibleObject.Index + 1) < mpGridView.Rows.Count)
                    {
                        mpGridView.ClickCell(mpGridViewRow.AccessibleObject.Index + 1,
                            columnIndex);
                    }

                    // click cell first normally.
                    mpGridView.ClickCell(
                        mpGridViewRow.AccessibleObject.Index,
                        columnIndex);

                    string managementpackName = mpGridViewRow.Cells[columnIndex].Name;
                    Utilities.LogMessage(currentMethod + ":: ready to check property of MP '" + managementpackName + "'");

                    Maui.Core.WinControls.Menu contextMenu = null;

                    Utilities.LogMessage(currentMethod + ":: right-clicking cell");
                    // right-click and select Property
                    mpGridView.ClickCell(
                        mpGridViewRow.AccessibleObject.Index,
                        columnIndex,
                        MouseFlags.RightButton);

                    contextMenu = new Maui.Core.WinControls.Menu(Constants.DefaultContextMenuTimeout);
                    //contextMenu.WaitContextMenuWithTimeOut(Core.Common.Constants.DefaultContextMenuTimeout);
                    contextMenu.ScreenElement.WaitForReady();

                    Utilities.LogMessage(currentMethod + ":: executing context menu item");
                    contextMenu.ExecuteMenuItem(contextMenuText);
                    Utilities.LogMessage(currentMethod + ":: Successfully clicked on the context menu: " + contextMenuText);
                }
                else
                {
                    throw
                        new Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException(
                        "Failed to find the search term, '" + mpName + "', in the grid!");
                }
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: mpGridView not found.");
            }
        }


        /// <summary>
        /// Invokes the Management Packs' file open dialog, 
        /// from the Management Packs node in the Administration tree.
        /// </summary>
        /// <returns>Reference to the Management Packs File Open Dialog</returns>
        public OpenDialog GetManagementPacksOpenDialog()
        {
            OpenDialog openDialog = null;
            try
            {
                // Select the Install Management Pack context menu item.
                CoreManager.MomConsole.NavigationPane.Controls.AdministrationTreeView
                    .Find(NavigationPane.Strings.ManagementPacks + Constants.PathDelimiter + NavigationPane.Strings.InstalledManagementPacks).ContextMenu
                    .ExecuteMenuItem(NavigationPane.Strings
                    .ContextMenuInstallManagementPack);
                Utilities.LogMessage("GetManagementPacksOpenDialog:: Install Management Pack " +
                    "context menu executed");

                // Display the Open File dialog.
                openDialog = this.ManagementPacksOpenDialog();
                return openDialog;
            }
            catch
            {
                if (openDialog != null)
                {
                    // On a failure try to close the dialog.
                    openDialog.SendKeys(KeyboardCodes.Esc);
                }
                throw;
            }
        }

        /// <summary>
        /// Invokes the Management Packs' file open dialog, 
        /// from the Management Packs node in the Administration tree.
        /// </summary>
        /// <returns>MP OpenDialog object</returns>
        public OpenDialog ManagementPacksOpenDialog()
        {
            // Display the Open File dialog.
            OpenDialog openDialog = null;
            try
            {
                openDialog = new OpenDialog(
                    CoreManager.MomConsole,
                    OpenDialog.OpenDialogTitle.ManagementPacksSelect);
                Utilities.LogMessage("ManagementPacksOpenDialog:: OpenDialog Opened");

                // Make sure Dialog is in Foreground.
                openDialog.Extended.SetFocus();
                Utilities.LogMessage("ManagementPacksOpenDialog:: Focus set to OpenDialog");

                return openDialog;
            }
            catch
            {
                // On a failure try to close the pre-install dialog.
                ImportManagementPacksDialog importDialog = this.GetImportManagementPacksDialog();
                if (this.GetImportManagementPacksDialog() != null)
                {
                    importDialog.ClickCancel();
                }

                // Rethrow exception
                throw;
            }
        }

        /// <summary>
        /// Provides access to an open instance of the pre-installation 
        /// Management Packs dialog.
        /// </summary>
        /// <returns>Pre-installation Management Packs dialog.</returns>
        public ImportManagementPacksDialog GetImportManagementPacksDialog()
        {
            // Access the Pre-Install Management Packs dialog.
            ImportManagementPacksDialog importDialog = null;

            // Open the Open Dialog
            try
            {
                importDialog = new ImportManagementPacksDialog(
                CoreManager.MomConsole);
                Utilities.LogMessage("GetImportManagementPacksDialog:: ImportManagementPacksDialog Opened");

                // Make sure Dialog is in Foreground.
                importDialog.Extended.SetFocus();
                Utilities.LogMessage("GetImportManagementPacksDialog:: Focus set to " +
                    "ImportManagementPacksDialog");

                return importDialog;
            }
            catch
            {
                if (importDialog != null)
                {
                    // On a failure try to close the dialog.
                    importDialog.SendKeys(KeyboardCodes.Esc);
                }
                throw;
            }
        }

        /// <summary>
        /// Provides access to an open instance of the post-installation 
        /// Management Packs dialog.
        /// </summary>
        /// <returns>Post-installation Management Packs dialog.</returns>
        public ImportManagementPacksCloseDialog GetImportManagementPacksCloseDialog()
        {
            // Access the Pre-Install Management Packs dialog.
            ImportManagementPacksCloseDialog importCloseDialog = null;

            // Open the Dialog
            try
            {
                importCloseDialog = new ImportManagementPacksCloseDialog(
                CoreManager.MomConsole);
                Utilities.LogMessage("GetImportManagementPacksCloseDialog:: ImportManagementPacksCloseDialog Opened");

                // Make sure Dialog is in Foreground.
                importCloseDialog.Extended.SetFocus();
                Utilities.LogMessage("GetImportManagementPacksCloseDialog:: Focus set to " +
                    "ImportManagementPacksCloseDialog");

                return importCloseDialog;
            }
            catch
            {
                if (importCloseDialog != null)
                {
                    // On a failure try to close the dialog.
                    importCloseDialog.SendKeys(KeyboardCodes.Esc);
                }
                throw;
            }
        }

        /// <summary>
        /// Checks to see if MP appears in configuration tree.
        /// </summary>
        /// <param name="name">Name of MP.</param>
        /// <returns>True/False</returns>
        /// <remarks>This code was adapted from a method in DistributedApps.
        /// Todo: Consider combining this wait loop code into NavigationPane.SelectNode,
        /// in meanwhile call this before select node.</remarks>
        public bool ExistsInConfigurationTree(string name)
        {
            TreeNode treeNode;
            TreeView treeView = CoreManager.MomConsole.NavigationPane.Controls.MonitoringConfigurationTreeView;
            bool nodeExists = false;
            int loopIteration = 0;
            int searchRetries = 5;

            // Look for the node until it arrives or until it 
            // exceeds the number of retries.
            while (loopIteration < searchRetries && nodeExists == false)
            {
                try
                {
                    loopIteration += 1;
                    Utilities.LogMessage("ExistsInConfigurationTree :: " +
                        "try number: " + loopIteration.ToString());
                    treeNode = treeView.Find(name);
                    treeNode.Click();
                    nodeExists = true;
                }
                catch (TreeNode.Exceptions.NodeNotFoundException)
                {
                    //Refresh the TreeView since we didn't find Node.
                    treeView.Click();
                    CoreManager.MomConsole.Refresh(CommandMethod.ContextMenuHotKey);
                }
            }
            Utilities.LogMessage("ExistsInConfigurationTree :: " +
                "Found node: " + name);
            return nodeExists;
        }

        /// <summary>
        /// Whether a MP exists in MP view
        /// </summary>
        /// <param name="mpName">mpName</param>
        public bool MPExistsInMPView(string mpName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

            // Navigate to the ManagementPacks node in
            // the Administration tree.
            this.NavigateToNodeManagementPacks();
            Utilities.LogMessage(currentMethod + ":: Select MP '" +
                mpName + "' in MP view");
            Maui.Core.WinControls.DataGridViewRow mpGridViewRow =null;
            int tries =0;
            int maxTries =5;
            do
            {
                tries++;
                // Refresh the list of MPs.
                CoreManager.MomConsole.Waiters.WaitForReady();
                CoreManager.MomConsole.ViewPane.Grid.SendKeys(KeyboardCodes.F5);

                //// Wait for MP view to load MPs.
                CoreManager.MomConsole.Waiters.WaitForReady();
                CoreManager.MomConsole.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout);

                // Apply a filter
                CoreManager.MomConsole.ViewPane.Find.LookForItem(mpName);

                Core.Console.MomControls.GridControl mpGridView =
                    CoreManager.MomConsole.ViewPane.Grid;

                int columnIndex = mpGridView.GetColumnTitlePosition(
                    ViewPane.Strings.AdministrationGridViewColumnName);

                // Get the row in Grid.
                mpGridViewRow = mpGridView.FindData(mpName, columnIndex);
                if (mpGridViewRow == null)
                    Sleeper.Delay(Core.Common.Constants.OneSecond * 5);
            } while (mpGridViewRow == null && tries < maxTries);

            if (mpGridViewRow != null)
            {
                Utilities.LogMessage(currentMethod + ":: Found MP :" + mpName);
                return true;
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: Failed to find '" + mpName + "', in the mp grid!");
            }
            return false;
        }

        /// <summary>
        /// Create an MP using the wizard
        /// </summary>
        /// <param name="mpParams">MPParameters</param>
        public void CreateNewMP(MPParameters mpParams)
        {
            Utilities.LogMessage("CreateNewMP:: " + mpParams.MPName);

            // Navigate to the ManagementPacks node in
            // the Administration tree.
            Maui.Core.WinControls.TreeNode node = this.NavigateToNodeManagementPacks();
            Utilities.LogMessage("CreateNewMP:: " +
                "Navigated to the management packs node.");

            //wait for MP view to load
            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

            if (node != null)
            {
                Maui.Core.WinControls.Menu contextMenu = null;

                Utilities.LogMessage("CreateNewMP:: right-clicking MP Node");

                // right-click and create
                Menu nodeMenu = new Menu(ContextMenuAccessMethod.ShiftF10);

                contextMenu = new Maui.Core.WinControls.Menu(Constants.DefaultContextMenuTimeout);
                //contextMenu.WaitContextMenuWithTimeOut(Core.Common.Constants.DefaultContextMenuTimeout);
                contextMenu.ScreenElement.WaitForReady();

                Utilities.LogMessage("CreateNewMP:: executing context menu item to create a new MP ");
                contextMenu.ExecuteMenuItem(NavigationPane.Strings.ContextMenuCreateManagementPack);

                // navigate thru the wizard
                //// Step-1 General properties
                Utilities.LogMessage("CreateNewMP:: NavigateThruCreateWizard - General Properties'");
                MP.Dialogs.CreateManagementPackGenPropDialog genPropDialog = new CreateManagementPackGenPropDialog(CoreManager.MomConsole);
                genPropDialog.ScreenElement.WaitForReady();
                genPropDialog.Extended.SetFocus();                

                ////Name
                Utilities.LogMessage("CreateNewMP:: NavigateThruCreateWizard - step:1 typing MP name '" + mpParams.MPName + "'");
                genPropDialog.TextBox1Text = mpParams.MPName;                

                ////Version
                Utilities.LogMessage("CreateNewMP:: NavigateThruCreateWizard - step:1 typing MP Version '" + mpParams.MPVersion + "'");
                genPropDialog.VersionText = mpParams.MPVersion;                

                ////Description
                Utilities.LogMessage("CreateNewMP:: NavigateThruCreateWizard - step:1 typing MP description '" + mpParams.MPDescription + "'");
                genPropDialog.DescriptionText = mpParams.MPDescription;                

                ////click next
                genPropDialog.ClickNext();
                genPropDialog.ScreenElement.WaitForReady();
                genPropDialog.Extended.SetFocus();                

                ////click create
                genPropDialog.ClickCreate();
                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

                // Utilities.TakeScreenshot("After_CreateMP");
            }
            else
            {
                throw
                    new Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException(
                    "CreateNewMP:: Failed to find the MP Node in admin nav tree");
            }
        }

        /// <summary>
        /// This method checks for the existence of an MP in the MP view
        /// </summary>
        /// <returns>True/False</returns>
        /// <param name="managementPackName">Name of the Management Pack
        /// as displayed in the View Pane</param>
        public bool VerifyNewMP(string managementPackName)
        {
            Utilities.LogMessage("VerifyNewMP:: " + managementPackName);

            // Navigate to the ManagementPacks node in
            // the Administration tree.
            Maui.Core.WinControls.TreeNode node = this.NavigateToNodeManagementPacks();
            Utilities.LogMessage("VerifyNewMP:: " +
                "Navigated to the management packs node.");

            // Refresh the list of MPs.
            //node.Click();
            CoreManager.MomConsole.Refresh();

            //wait for MP view to load
            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

            // If MP not exists in MP View, return false. 
            if (!MPExistsInMPView(managementPackName))
            {
                Utilities.LogMessage("VerifyNewMP:: Failed to find '" + managementPackName + "', in the mp grid!");
                Utilities.TakeScreenshot("CannotFindMP");

                return false;
            }

            return true;
        }

        /// <summary>
        /// Verify MP Property
        /// </summary>
        /// <param name="mpName">management pack name</param>
        /// <returns>True/False</returns>
        public bool VerifyMPProperty(string mpName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: Verify property of MP '" +
                mpName + "'");

            Core.Console.MomControls.GridControl mpGridView =
                CoreManager.MomConsole.ViewPane.Grid;

            mpGridView.SendKeys(KeyboardCodes.F5);

            int columnIndex = mpGridView.GetColumnTitlePosition(
                ViewPane.Strings.AdministrationGridViewColumnName);

            // Get the row in Grid.
            Maui.Core.WinControls.DataGridViewRow mpGridViewRow =
                mpGridView.FindData(mpName, columnIndex);

            // based on device type and management mode
            if (mpGridViewRow != null)
            {
                Utilities.LogMessage(currentMethod + ":: left-clicking cell");

                //scroll down to row below current to make sure it's fully visible
                if ((mpGridViewRow.AccessibleObject.Index + 1) < mpGridView.Rows.Count)
                {
                    mpGridView.ClickCell(mpGridViewRow.AccessibleObject.Index + 1,
                        columnIndex);
                }

                // click cell first normally.
                mpGridView.ClickCell(
                    mpGridViewRow.AccessibleObject.Index,
                    columnIndex);

                string managementpackName = mpGridViewRow.Cells[columnIndex].Name;
                Utilities.LogMessage(currentMethod + ":: ready to check property of MP '" + managementpackName + "'");

                Maui.Core.WinControls.Menu contextMenu = null;

                Utilities.LogMessage(currentMethod + ":: right-clicking cell");
                // right-click and select Property
                mpGridView.ClickCell(
                    mpGridViewRow.AccessibleObject.Index,
                    columnIndex,
                    MouseFlags.RightButton);

                contextMenu = new Maui.Core.WinControls.Menu(Constants.DefaultContextMenuTimeout);
                //contextMenu.WaitContextMenuWithTimeOut(Core.Common.Constants.DefaultContextMenuTimeout);
                contextMenu.ScreenElement.WaitForReady();

                Utilities.LogMessage(currentMethod + ":: executing context menu item");
                contextMenu.ExecuteMenuItem(
                    ViewPane.Strings.AdministrationContextMenuProperties);

                MPGeneralPropertyDialog mpGeneralPropertyDialog =
                    new MPGeneralPropertyDialog(CoreManager.MomConsole, managementpackName);

                if (mpGeneralPropertyDialog.NameText != managementpackName)
                {
                    mpGeneralPropertyDialog.ClickCancel();
                    Utilities.LogMessage(currentMethod + ":: failed to verify MP name in property");
                    Utilities.TakeScreenshot("Failed to Verify MP name");
                    CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                    return false;
                }
                else
                {
                    mpGeneralPropertyDialog.ClickCancel();
                    CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                    return true;
                }
            }
            else
            {
                throw
                    new Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException(
                    "Failed to find the search term, '" + mpName + "', in the grid!");
            }
        }

        /// <summary>
        /// This method checks for the existence of the MP folder in the Monitoring nav tree
        /// </summary>
        /// <returns>True/False</returns>
        /// <param name="managementPackName">Name of the Management Pack
        /// as displayed in the View Pane</param>
        public bool VerifyMonitoringFolder(string managementPackName)
        {
            bool found = false;
            string pathToFolder = NavigationPane.Strings.Monitoring + Constants.PathDelimiter + managementPackName;
            Utilities.LogMessage("VerifyMonitoringFolder:: " + managementPackName);

            // Navigate to MP Folder Node 
            NavigationPane navpane = CoreManager.MomConsole.NavigationPane;
            navpane.ClickWunderBarButton(NavigationPane.WunderBarButton.Monitoring);

            //wait for monitoring overview page to load
            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

            TreeNode viewNode = null;

            if (pathToFolder != null)
            {
                Utilities.LogMessage("VerifyMonitoringFolder:: Selecting Folder: " + managementPackName);
                viewNode = navpane.SelectNode(pathToFolder, NavigationPane.NavigationTreeView.Monitoring);
                found = true;
                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);
            }

            return found;
        }

        /// <summary>
        /// This method exports an unsealed MP to the desktop and checks for the existence of the xported file
        /// </summary>
        /// <returns>True/False</returns>
        /// <param name="managementPackName">Name of the Management Pack displayed in the View Pane</param>
        /// <param name="fileName">Name of the exported file to search for in the desktop for the logged in user</param>
        public bool Export(string managementPackName, string fileName)
        {
            bool success = false;
            Utilities.LogMessage("Export:: '" + managementPackName + "'");

            string exportedfilename = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + fileName;

            //if .xml file exists already delete the file first
            if (System.IO.File.Exists(exportedfilename))
            {

                System.IO.File.Delete(exportedfilename);
                Utilities.LogMessage("Export:: Deleted already existing file : " + exportedfilename);
            }

            // Navigate to the ManagementPacks node in
            // the Administration tree.
            this.NavigateToNodeManagementPacks();
            Utilities.LogMessage("Export:: " +
                "Navigated to the management packs node.");
            Core.Console.MomControls.GridControl mpGridView = null;
            Maui.Core.WinControls.DataGridViewRow mpGridViewRow =null;
            int tries = 0;
            int maxTries =3;
            int columnIndex;
            do
            {
                tries++;
                // Refresh the list of MPs.
                CoreManager.MomConsole.Waiters.WaitForStatusReady();
                CoreManager.MomConsole.ViewPane.Grid.SendKeys(KeyboardCodes.F5);

                //wait for MP view to load
                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();
                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.DefaultDialogTimeout);

                mpGridView = CoreManager.MomConsole.ViewPane.Grid;

                columnIndex =
                    mpGridView.GetColumnTitlePosition(ViewPane.Strings.AdministrationGridViewColumnName);

                // get the grid row
                mpGridViewRow = mpGridView.FindData(managementPackName,columnIndex);

            }while(mpGridViewRow == null && tries<maxTries);

            // based on device type and management mode
            if (mpGridViewRow != null)
            {
                Utilities.LogMessage("Export:: left-clicking cell");

                //scroll down to row below current to make sure it's fully visible
                if ((mpGridViewRow.AccessibleObject.Index + 1) < mpGridView.Rows.Count)
                {
                    mpGridView.ClickCell(mpGridViewRow.AccessibleObject.Index + 1,
                        columnIndex);
                }

                // click cell first normally.
                mpGridView.ClickCell(
                    mpGridViewRow.AccessibleObject.Index,
                    columnIndex);

                Maui.Core.WinControls.Menu contextMenu = null;

                Utilities.LogMessage("Export:: right-clicking cell");
                // right-click and export
                mpGridView.ClickCell(
                    mpGridViewRow.AccessibleObject.Index,
                    columnIndex,
                    MouseFlags.RightButton);

                contextMenu = new Maui.Core.WinControls.Menu(Constants.DefaultContextMenuTimeout);
                //contextMenu.WaitContextMenuWithTimeOut(Core.Common.Constants.DefaultContextMenuTimeout);
                contextMenu.ScreenElement.WaitForReady();

                Utilities.LogMessage("Export:: executing context menu item");
                contextMenu.ExecuteMenuItem(Strings.ExportManagementPack);

                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

                //Give timeout for browse dialog to show up and render fully - in x64 dialog shows up but it takes quite a while for the drives to get populated!!                
                // use try logic instead of Sleep.Delay(Constants.OneSecond * 18)
                int countTries = 0;
                int maxCountTries = 20;

                // Destination folder dialog
                BrowseForFolderDialog destinationFolderDlg = null;

                while (destinationFolderDlg == null && countTries <= maxCountTries)
                {
                    try
                    {
                        maxCountTries++;
                        destinationFolderDlg = new BrowseForFolderDialog(CoreManager.MomConsole);
                        Utilities.LogMessage("Export:: Successfully find BrowseForFolderDialog");
                        break;
                    }
                    catch(Maui.Core.Window.Exceptions.WindowNotFoundException)
                    {
                        if (countTries > maxCountTries)
                        {
                            throw new Maui.Core.Window.Exceptions.WindowNotFoundException("Export:: Destination Fold Dialog cannot been found");
                        }
                        Utilities.LogMessage("Export:: Hasn't found DestinationFolderDialog, need retry");
                        Sleeper.Delay(Constants.OneSecond);                        
                    }
                }

                destinationFolderDlg.ScreenElement.WaitForReady();

                //select path - x64 issue - sporadically, clicking on OK button after clicking on path doesn't do anything. so accept default path
                /*destinationFolderDlg.Controls.TreeView.Root.Click();
                UISynchronization.WaitForUIObjectReady(destinationFolderDlg, timeout*2);
                UISynchronization.WaitForProcessReady(destinationFolderDlg, timeout*2);
                Utilities.TakeScreenshot("Export_PathDialogClickedPath");
                Sleeper.Delay(timeout * 2);
                //click OK
                destinationFolderDlg.ClickOK();*/
                CoreManager.MomConsole.SendKeys(KeyboardCodes.Enter);

                CoreManager.MomConsole.WaitForDialogClose(destinationFolderDlg, 90);

                //look for export confirmation dialog
                CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.OK, "*", StringMatchSyntax.WildCard, MomConsoleApp.ActionIfWindowNotFound.Ignore); 

                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

                //check for the file
                bool fileFound = false;
                int current = 0;
                int max = 100;
                while (!fileFound && current < max)
                {
                    if (System.IO.File.Exists(exportedfilename))
                    {
                        Utilities.LogMessage("Export:: Found exported file: '" + exportedfilename + "'");
                        fileFound = true;
                        success = true;
                    }
                    else
                    {
                        Utilities.LogMessage("Export:: Not found exported file: Retry " + current.ToString());
                        Sleeper.Delay(Constants.OneSecond);
                        current++;
                    }
                }
            }
            else
            {
                throw
                    new Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException(
                    "Export:: Failed to find MP, '" + managementPackName + "', in the grid!");
            }
            return success;
        }

        /// <summary>
        /// This method updates available for installed mps
        /// </summary>
        /// <param name="searchItem">Search Item</param>
        /// <history>
        ///     [v-eachu] 26Nov09 - Created
        /// </history>
        public void UpdateAvailableForInstalledManagementPacks(string searchItem)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            try
            {
                // Navigate to the ManagementPacks node in the Administration tree. 
                Maui.Core.WinControls.TreeNode mpViewNode = this.NavigateToNodeManagementPacks();

                // launch the Import MP Wizard
                mpViewNode.ContextMenu.ExecuteMenuItem(
                    NavigationPane.Strings.ContextMenuInstallManagementPack);

                WizardDialogSelectMPs mpWizardDialogSelectMPs = new WizardDialogSelectMPs(CoreManager.MomConsole);

                if (mpWizardDialogSelectMPs != null)
                {
                    Utilities.LogMessage(currentMethod + ":: MP wizard was successfully launched");
                }
                else
                {
                    throw new Dialog.Exceptions.WindowNotFoundException(currentMethod + ":: Unable to get the MP wizard dialog");
                }

                // Launch the Add From Catalog Dialog
                mpWizardDialogSelectMPs.Controls.SelectMPsToolbar.ToolbarItems[IndexOfAddButton].Click();
                CoreManager.MomConsole.ExecuteContextMenu(WizardDialogSelectMPs.Strings.SelectMPsToolbarAddFromCatalog, false);
                if (!MakeUIReadyForImport(ImportMethod.AddFromCatelog, maxRetry))
                    throw new Exception(currentMethod + ":: Import UI is not ready for import");

                SelectMPsFromCatalogDialog selectMPsFromCatalogDialog =
                    new SelectMPsFromCatalogDialog(CoreManager.MomConsole);

                if (selectMPsFromCatalogDialog != null)
                {
                    Utilities.LogMessage(currentMethod + ":: Add From Catalog dialog was successfully launched");

                    selectMPsFromCatalogDialog.Extended.SetFocus();
                    Utilities.LogMessage(currentMethod + ":: Focus set to Select MPs From Catalog dialog");

                    // clear the Find Text selection first as the old value is still cached 
                    if (selectMPsFromCatalogDialog.FindText.Trim() != "")
                    {
                        selectMPsFromCatalogDialog.FindText = "";
                    }

                    if (searchItem != "" && searchItem != null)
                    {
                        selectMPsFromCatalogDialog.FindText = searchItem;
                    }

                    selectMPsFromCatalogDialog.ComboBox1Text = SelectMPsFromCatalogDialog.Strings.FilterViewMPUPdatesAvailable;

                    //Click Search Button with the Enpty Find Text To refresh The Grid With New Data
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(selectMPsFromCatalogDialog.Controls.SearchButton, Constants.DefaultDialogTimeout);
                    selectMPsFromCatalogDialog.ClickSearch();
                    
                    // wait for Select button enable For ManagementPack Grid View To refresh With new Data
                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(selectMPsFromCatalogDialog.Controls.SelectButton, Constants.DefaultDialogTimeout);
                    
                    DataGridView viewGrid = new DataGridView(
                        selectMPsFromCatalogDialog,
                        SelectMPsFromCatalogDialog.ControlIDs.ManagementPacksInTheCatalogPropertyGridView);

                    if (viewGrid == null)
                    {
                        Utilities.LogMessage(currentMethod + ":: viewGrid not found.");
                        throw new DataGrid.Exceptions.UnknownWinControlException(currentMethod + ":: viewGrid not found.");
                    }

                    // dataGrid.Extended.SetFocus();
                    viewGrid.Extended.SetFocus();

                    int rowCount = viewGrid.Rows.Count;
                    Utilities.LogMessage(currentMethod + ":: Total rowCount found in Grid. " + rowCount.ToString());
                    if (rowCount <= 1)
                    {
                        Utilities.LogMessage(currentMethod + ":: viewGrid contains no rows");
                        throw new DataGrid.Exceptions.DataGridRowNotFoundException(currentMethod + ":: viewGrid is empty.");
                    }

                    viewGrid.Rows[1].AccessibleObject.Click();
                    
                    selectMPsFromCatalogDialog.ClickSelect();
                    Utilities.LogMessage(currentMethod + ":: Clicked Select button");

                    CoreManager.MomConsole.Waiters.WaitForButtonEnabled(selectMPsFromCatalogDialog.Controls.AddButton, Constants.DefaultDialogTimeout);
                    selectMPsFromCatalogDialog.ClickAdd();
                    Utilities.LogMessage(currentMethod + ":: Clicked Add button");

                    CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout);
                }
                else
                {
                    throw new Maui.Core.Window.Exceptions.WindowNotFoundException(currentMethod + ":: Unable to launch Add From Catalog dialog");
                }

                // Proceed the Install button
                Utilities.LogMessage(currentMethod + ":: Click install button to finish the wizard.");

                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(mpWizardDialogSelectMPs.Controls.InstallButton, Constants.DefaultDialogTimeout); // it will wait for 15 seconds
                mpWizardDialogSelectMPs.ClickInstall();

                Utilities.LogMessage(currentMethod + ":: Install button clicked.");

                CoreManager.MomConsole.ConfirmChoiceDialog(
                    MomConsoleApp.ButtonCaption.Yes,
                    Core.Console.Views.Views.Strings.MomDialogTitle,
                    StringMatchSyntax.ExactMatch, MomConsoleApp.ActionIfWindowNotFound.Ignore);

                // CloseMPImportWizard
                this.CloseMPImportWizard(Constants.OneSecond * 300);
                //Waiting for some time for Mp to Appear In Mp view Once Import Done.
                CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout);
            }
            catch (Exception e)
            {
                Utilities.LogMessage(currentMethod + ":: Exception: " + e);
                Utilities.TakeScreenshot(currentMethod + "_Exception");
                throw;
            }
        }

        /// <summary>
        /// This method obtain mp's version
        /// </summary>
        /// <returns>mp's version</returns>
        /// <param name="mpName">mp's name</param>
        /// <history>
        ///     [v-eachu] 26Nov09 - Created
        /// </history>
        public string GetMPVersion(string mpName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: get version of MP '" + mpName + "'");

            Core.Console.MomControls.GridControl mpGridView = CoreManager.MomConsole.ViewPane.Grid;

            mpGridView.SendKeys(KeyboardCodes.F5);

            int columnIndex = mpGridView.GetColumnTitlePosition(ViewPane.Strings.AdministrationGridViewColumnName);

            // Get the row in Grid.
            Maui.Core.WinControls.DataGridViewRow mpGridViewRow = mpGridView.FindData(mpName, columnIndex);

            // based on device type and management mode
            if (mpGridViewRow != null)
            {
                Utilities.LogMessage(currentMethod + ":: left-clicking cell");

                //scroll down to row below current to make sure it's fully visible
                if ((mpGridViewRow.AccessibleObject.Index + 1) < mpGridView.Rows.Count)
                {
                    mpGridView.ClickCell(mpGridViewRow.AccessibleObject.Index + 1, columnIndex);
                }

                // click cell first normally.
                mpGridView.ClickCell(mpGridViewRow.AccessibleObject.Index, columnIndex);

                Maui.Core.WinControls.Menu contextMenu = null;

                Utilities.LogMessage(currentMethod + ":: right-clicking cell");
                // right-click and select Property
                mpGridView.ClickCell(
                    mpGridViewRow.AccessibleObject.Index,
                    columnIndex,
                    MouseFlags.RightButton);

                contextMenu = new Maui.Core.WinControls.Menu(Constants.DefaultContextMenuTimeout);
                //contextMenu.WaitContextMenuWithTimeOut(Core.Common.Constants.DefaultContextMenuTimeout);
                contextMenu.ScreenElement.WaitForReady();

                Utilities.LogMessage(currentMethod + ":: executing context menu item");
                contextMenu.ExecuteMenuItem(ViewPane.Strings.AdministrationContextMenuProperties);

                MPGeneralPropertyDialog mpGeneralPropertyDialog = new MPGeneralPropertyDialog(CoreManager.MomConsole, mpName);

                string mpVersion = mpGeneralPropertyDialog.VersionText;

                mpGeneralPropertyDialog.ClickCancel();
                CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

                return mpVersion;
            }
            else
            {
                throw new Maui.Core.WinControls.DataGridView.Exceptions.DataGridViewRowNotFoundException("Failed to find the search term, '" + mpName + "', in the grid!");
            }
        }
        #endregion

        #region Private Methods section

        private void EnableThirdPartyWorkload()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            string mpLocation = @"C:\BVT\UI\MP\Microsoft.SystemCenter.ManagementPack.Recommendations.xml";
            string mpName = "Management Pack Recommendations";

            try
            {
                //Delete the management pack if it is present already
                DeleteManagementPack(mpName);
                // Navigate to the ManagementPacks node in the Administration tree. 
                Maui.Core.WinControls.TreeNode mpViewNode = this.NavigateToNodeManagementPacks();

                // launch the Import MP Wizard
                CoreManager.MomConsole.ExecuteContextMenu(NavigationPane.Strings.ContextMenuInstallManagementPack, true);

                WizardDialogSelectMPs mpWizardDialogSelectMPs = new WizardDialogSelectMPs(CoreManager.MomConsole);

                if (mpWizardDialogSelectMPs != null)
                {
                    Utilities.LogMessage(currentMethod + ":: MP wizard was successfully launched");
                }
                else
                {
                    throw new Dialog.Exceptions.WindowNotFoundException(currentMethod + ":: Unable to get the MP wizard dialog");
                }

                //Install MP from Disk
                AddMPsFromDisk(mpLocation);

                // Proceed the Install button
                Utilities.LogMessage(currentMethod + ":: Click install button to finish the wizard.");
                CoreManager.MomConsole.Waiters.WaitForButtonEnabled(mpWizardDialogSelectMPs.Controls.InstallButton, Constants.DefaultDialogTimeout);
                mpWizardDialogSelectMPs.ClickInstall();
                Utilities.LogMessage(currentMethod + ":: Install button clicked.");
                Utilities.TakeScreenshot(currentMethod + "_AfterClickingInstall");
                try
                {
                    CoreManager.MomConsole.ConfirmChoiceDialog(true);
                    //MomConsoleApp.ButtonCaption.Yes,
                    //Core.Console.Views.Views.Strings.MomDialogTitle,
                    //StringMatchSyntax.ExactMatch, MomConsoleApp.ActionIfWindowNotFound.Ignore);
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage(currentMethod + ":: Don't find confirm choice dialog");
                }

                // CloseMPImportWizard
                this.CloseMPImportWizard(Constants.DefaultDialogTimeout);
                //Waiting for some time for Mp to Appear In Mp view Once Import Done.
                CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.DefaultDialogTimeout);
            }
            catch (Exception e)
            {
                Utilities.LogMessage(currentMethod + ":: Exception: " + e.Message);
                Utilities.TakeScreenshot(currentMethod + "_Exception");
                throw;
            }
            Utilities.LogMessage(currentMethod + " Different Workload with different Status has been Enabled");
        }

       private string[] GetDelimitedString(string delimitedString, Char separator)
        {
            string[] extractedString = delimitedString.Split(new char[] { separator });
            return extractedString;
        }

        /// <summary>
        /// Method to stop importing MPs and close Import Management Packs wizard
        /// </summary>
        /// <param name="wizard">Import Management Packs wizard</param>
        /// <remarks>
        /// in case the MPWizardDialog didn't close cause block the following vars bug#180060
        /// </remarks>
        private void StopImportingMPsAndCloseImportMPsWizard(WizardDialogImportMPs wizard)
        {
            //Bug#206729
            wizard.ScreenElement.BringUp();
            wizard.ClickStop();
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(wizard.Controls.CloseButton, Constants.DefaultDialogTimeout);

            wizard.ClickClose();

            // If there are MPs not imported when Close button is enabled, 
            // a confimation dialog will pop up when close button is clicked. 
            CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.Yes, 
                                                       "*", StringMatchSyntax.WildCard, 
                                                       MomConsoleApp.ActionIfWindowNotFound.Ignore);
            CoreManager.MomConsole.WaitForDialogClose(wizard, Constants.OneMinute / Constants.OneSecond);            
        }

        /// <summary>
        /// Method to wait for MPs downloaded
        /// </summary>
        private void WaitForMPsDownloaded(WizardDialogImportMPs wizard)
        {
            Utilities.LogMessage("WaitForMPsDownloaded:: (...)");
            try
            {
                CoreManager.MomConsole.Waiters.WaitForWindowAppeared(wizard, new QID(";[UIA]Name='" + WizardDialogImportMPs.ControlIDs.StopButtonName + "'"), Constants.OneMinute);
            }
            catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
            {
                //Ignore
            }
            catch (Maui.Core.Window.Exceptions.InvalidHWndException)
            {
                //Ignore
            }
            finally
            {
                Utilities.TakeScreenshot("WaitForMPsDownloaded");
            }
        }

        #endregion

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Strings.
        /// </summary>
        /// <history>
        /// 	[barryw] 01OCT05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            #region Resource constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Default Management Pack Friendly Name
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceDefaultManagementPackFriendlyName =
                ";My Default Management Pack;ManagedString;" +
                "Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement." +
                "Mom.Internal.UI.Common.MPHelper;DefaultManagementPackFriendlyName";

            /// <summary>
            /// Contains resource string for the Export Management Pack... Menu item.
            /// </summary>
            private const string ResourceExportManagementPack = ";&Export Management Pack...;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;ExportMPMenuItem";

            #endregion

            #region ManagementPacks Guids

            /// <summary>
            /// MOMNotificationManagementPackGuid (Stored in ManagementPack table)
            /// </summary>
            private const string ResourceMOMNotificationManagementPackGuid = "4F61B37D-374E-7DB7-1EB3-A8131E52D8EA";

            /// <summary>
            /// SystemManagementPackGuid (Stored in ManagementPack table)
            /// </summary>
            private const string ResourceSystemManagementPackGuid = "F32EA5B2-1132-F6F1-BC52-155732A5A7D0";

            /// <summary>
            /// MOMManagementPackGuid (Stored in ManagementPack table)
            /// </summary>
            private const string ResourceMOMManagementPackGuid = "44776DAE-10F4-0850-AB6D-18DDDD5614B1";

            /// <summary>
            /// MOMAEMManagementPackGuid (Stored in ManagementPack table)
            /// </summary>
            private const string ResourceMOMAEMManagementPackGuid = "88051EE4-E3A3-16F1-9A91-F860B090F39B";

            /// <summary>
            /// WindowsSystemManagementPackGuid (Stored in ManagementPack table)
            /// </summary>
            private const string ResourceWindowsSystemManagementPackGuid = "6457B5CD-C352-E69F-6029-3FBE8076C5FC";

            /// <summary>
            /// MyDefaultManagementPackGuid (Stored in ManagementPack table)
            /// </summary>
            [Obsolete("Don't use MyDefaultManagementPackGuid; use Strings.DefaultManagementPackFriendlyName instead", true)]
            private const string ResourceMyDefaultManagementPackGuid = "898E6414-7C3E-2EAD-4787-711206F186F6";

            /// <summary>
            /// MOMBackwardCompatibilityManagementPackGuid (Stored in ManagementPack table)
            /// </summary>
            private const string ResourceMOMBackwardCompatibilityManagementPackGuid = "CB306BB3-EC97-ABBB-6F1D-878CCD995D44";

            /// <summary>
            /// MicrosoftImagesManagementPackGuid (Stored in ManagementPack table)
            /// </summary>
            private const string ResourceMicrosoftImagesManagementPackGuid = "1BFF8F4D-355B-4D65-E7C3-8E0EB63A60EB";

            /// <summary>
            /// HardwareManagementPackGuid (Stored in ManagementPack table)
            /// </summary>
            private const string ResourceHardwareManagementPackGuid = "5AAF4691-0CE3-4F1B-B7C2-9DBF9D2F28EA";

            /// <summary>
            /// SystemWebMonitoringManagementPack
            /// </summary>
            private const string ResourceSystemWebMonitoringManagementPack = "A3456E11-15AE-2BF2-4C0C-EE58F95620F1";

            /// <summary>
            /// MicrosoftWindowsIISManagementPack
            /// </summary>
            private const string ResourceMicrosoftWindowsIISManagementPack = "06D8310D-D137-45C3-2261-f4C83AED6D37";

            /// <summary>
            /// MicrosoftSystemServiceTypeLibrary
            /// </summary>
            private const string ResourceMicrosoftSystemServiceTypeLibrary = "23C74B1C-6A09-65B1-4CCA-BD8D38AF5583";

            /// <summary>
            /// MicrosoftWindowsServerADManagementPack
            /// </summary>
            private const string ResourceMicrosoftWindowsServerADManagementPack = "F99A5C43-350E-6EFB-28D4-7F96A02DC279";

            /// <summary>
            /// MicrosoftBaseOSManagementPack
            /// </summary>
            private const string ResourceMicrosoftBaseOSManagementPack = "DD714D86-DBBC-CDD7-0F64-6B3AA83FC14A";

            /// <summary>
            /// MicrosoftSQLServer2005ManagementPack
            /// </summary>
            private const string ResourceMicrosoftSQLServer2005ManagementPack = "380D9BA4-9B3F-16E2-2AF8-2A4539C5E161";
            #endregion

            #endregion  // Constants

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource for the DefaultManagementPackFriendlyName
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDefaultManagementPackFriendlyName;

            /// <summary>
            /// Caches the translated resource for the ExportManagementPack Menu item.
            /// </summary>
            private static string cachedExportManagementPack;

            #region ManagementPacksGuids Members

            /// <summary>
            /// MOMNotificationManagementPackGuid (Stored in ManagementPack table)
            /// </summary>
            private static string cachedMOMNotificationManagementPackGuid;

            /// <summary>
            /// SystemManagementPackGuid (Stored in ManagementPack table)
            /// </summary>
            private static string cachedSystemManagementPackGuid;

            /// <summary>
            /// MOMManagementPackGuid (Stored in ManagementPack table)
            /// </summary>
            private static string cachedMOMManagementPackGuid;

            /// <summary>
            /// MOMAEMManagementPackGuid (Stored in ManagementPack table)
            /// </summary>
            private static string cachedMOMAEMManagementPackGuid;

            /// <summary>
            /// WindowsSystemManagementPackGuid (Stored in ManagementPack table)
            /// </summary>
            private static string cachedWindowsSystemManagementPackGuid;

            /// <summary>
            /// MOMBackwardCompatibilityManagementPackGuid (Stored in ManagementPack table)
            /// </summary>
            private static string cachedMOMBackwardCompatibilityManagementPackGuid;

            /// <summary>
            /// MicrosoftImagesManagementPackGuid (Stored in ManagementPack table)
            /// </summary>
            private static string cachedMicrosoftImagesManagementPackGuid;

            /// <summary>
            /// HardwareManagementPackGuid (Stored in ManagementPack table)
            /// </summary>
            private static string cachedHardwareManagementPackGuid;

            /// <summary>
            /// SystemWebMonitoringManagementPack
            /// </summary>
            private static string cachedSystemWebMonitoringManagementPack;

            /// <summary>
            /// MicrosoftWindowsIISManagementPack
            /// </summary>
            private static string cachedMicrosoftWindowsIISManagementPack;

            /// <summary>
            /// MicrosoftSystemServiceTypeLibrary
            /// </summary>
            private static string cachedMicrosoftSystemServiceTypeLibrary;

            /// <summary>
            /// MicrosoftWindowsServerADManagementPack
            /// </summary>
            private static string cachedMicrosoftWindowsServerADManagementPack;

            /// <summary>
            /// MicrosoftBaseOSManagementPack
            /// </summary>
            private static string cachedMicrosoftBaseOSManagementPack;

            /// <summary>
            /// MicrosoftSQLServer2005ManagementPack
            /// </summary>
            private static string cachedMicrosoftSQLServer2005ManagementPack;
            #endregion

            #endregion  // Private Members

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DefaultManagementPackFriendlyName translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 25-Jul-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DefaultManagementPackFriendlyName
            {
                get
                {
                    if ((cachedDefaultManagementPackFriendlyName == null))
                    {
                        cachedDefaultManagementPackFriendlyName = CoreManager.MomConsole.GetIntlStr(ResourceDefaultManagementPackFriendlyName);
                    }
                    return cachedDefaultManagementPackFriendlyName;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Export Management Pack... resource string
            /// </summary>
            /// -----------------------------------------------------------------------------
            public static string ExportManagementPack
            {
                get
                {
                    if ((cachedExportManagementPack == null))
                    {
                        cachedExportManagementPack = CoreManager.MomConsole.GetIntlStr(ResourceExportManagementPack);
                    }
                    return cachedExportManagementPack;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MOMNotificationManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 03-Oct-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MOMNotificationManagementPack
            {
                get
                {
                    if ((cachedMOMNotificationManagementPackGuid == null))
                    {
                        cachedMOMNotificationManagementPackGuid = Utilities.GetManagementPackName(ResourceMOMNotificationManagementPackGuid);
                    }
                    return cachedMOMNotificationManagementPackGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the SystemManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 03-Oct-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SystemManagementPack
            {
                get
                {
                    if ((cachedSystemManagementPackGuid == null))
                    {
                        cachedSystemManagementPackGuid = Utilities.GetManagementPackName(ResourceSystemManagementPackGuid);
                    }
                    return cachedSystemManagementPackGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MOMManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 03-Oct-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MOMManagementPack
            {
                get
                {
                    if ((cachedMOMManagementPackGuid == null))
                    {
                        cachedMOMManagementPackGuid = Utilities.GetManagementPackName(ResourceMOMManagementPackGuid);
                    }
                    return cachedMOMManagementPackGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MOMAEMManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 03-Oct-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MOMAEMManagementPack
            {
                get
                {
                    if ((cachedMOMAEMManagementPackGuid == null))
                    {
                        cachedMOMAEMManagementPackGuid = Utilities.GetManagementPackName(ResourceMOMAEMManagementPackGuid);
                    }
                    return cachedMOMAEMManagementPackGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WindowsSystemManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 03-Oct-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WindowsSystemManagementPack
            {
                get
                {
                    if ((cachedWindowsSystemManagementPackGuid == null))
                    {
                        cachedWindowsSystemManagementPackGuid = Utilities.GetManagementPackName(ResourceWindowsSystemManagementPackGuid);
                    }
                    return cachedWindowsSystemManagementPackGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MOMBackwardCompatibilityManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 03-Oct-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MOMBackwardCompatibilityManagementPack
            {
                get
                {
                    if ((cachedMOMBackwardCompatibilityManagementPackGuid == null))
                    {
                        cachedMOMBackwardCompatibilityManagementPackGuid = Utilities.GetManagementPackName(ResourceMOMBackwardCompatibilityManagementPackGuid);
                    }
                    return cachedMOMBackwardCompatibilityManagementPackGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MicrosoftImagesManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 03-Oct-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MicrosoftImagesManagementPack
            {
                get
                {
                    if ((cachedMicrosoftImagesManagementPackGuid == null))
                    {
                        cachedMicrosoftImagesManagementPackGuid = Utilities.GetManagementPackName(ResourceMicrosoftImagesManagementPackGuid);
                    }
                    return cachedMicrosoftImagesManagementPackGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HardwareManagementPack translated resource string
            /// </summary>
            /// <history>
            /// 	[barryw] 03-Oct-05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HardwareManagementPack
            {
                get
                {
                    if ((cachedHardwareManagementPackGuid == null))
                    {
                        cachedHardwareManagementPackGuid = Utilities.GetManagementPackName(ResourceHardwareManagementPackGuid);
                    }
                    return cachedHardwareManagementPackGuid;
                }
            }

            /// <summary>
            /// SystemWebMonitoringManagementPack
            /// </summary>
            public static string SystemWebMonitoringManagementPack
            {
                get
                {
                    if ((cachedSystemWebMonitoringManagementPack == null))
                    {
                        cachedSystemWebMonitoringManagementPack = Utilities.GetManagementPackName(ResourceSystemWebMonitoringManagementPack);
                    }
                    return cachedSystemWebMonitoringManagementPack;
                }
            }

            /// <summary>
            /// MicrosoftWindowsIISManagementPack
            /// </summary>
            public static string MicrosoftWindowsIISManagementPack
            {
                get
                {
                    if ((cachedMicrosoftWindowsIISManagementPack == null))
                    {
                        cachedMicrosoftWindowsIISManagementPack = Utilities.GetManagementPackName(ResourceMicrosoftWindowsIISManagementPack);
                    }
                    return cachedMicrosoftWindowsIISManagementPack;
                }
            }

            /// <summary>
            /// MicrosoftSystemServiceTypeLibrary
            /// </summary>
            public static string MicrosoftSystemServiceTypeLibrary
            {
                get
                {
                    if ((cachedMicrosoftSystemServiceTypeLibrary == null))
                    {
                        cachedMicrosoftSystemServiceTypeLibrary = Utilities.GetManagementPackName(ResourceMicrosoftSystemServiceTypeLibrary);
                    }
                    return cachedMicrosoftSystemServiceTypeLibrary;
                }
            }

            /// <summary>
            /// MicrosoftWindowsServerADManagementPack
            /// </summary>
            public static string MicrosoftWindowsServerADManagementPack
            {
                get
                {
                    if ((cachedMicrosoftWindowsServerADManagementPack == null))
                    {
                        cachedMicrosoftWindowsServerADManagementPack = Utilities.GetManagementPackName(ResourceMicrosoftWindowsServerADManagementPack);
                    }
                    return cachedMicrosoftWindowsServerADManagementPack;
                }
            }

            /// <summary>
            /// MicrosoftBaseOSManagementPack
            /// </summary>
            public static string MicrosoftBaseOSManagementPack
            {
                get
                {
                    if ((cachedMicrosoftBaseOSManagementPack == null))
                    {
                        cachedMicrosoftBaseOSManagementPack = Utilities.GetManagementPackName(ResourceMicrosoftBaseOSManagementPack);
                    }
                    return cachedMicrosoftBaseOSManagementPack;
                }
            }

            /// <summary>
            /// MicrosoftSQLServer2005ManagementPack
            /// </summary>
            public static string MicrosoftSQLServer2005ManagementPack
            {
                get
                {
                    if ((cachedMicrosoftSQLServer2005ManagementPack == null))
                    {
                        cachedMicrosoftSQLServer2005ManagementPack = Utilities.GetManagementPackName(ResourceMicrosoftSQLServer2005ManagementPack);
                    }
                    return cachedMicrosoftSQLServer2005ManagementPack;
                }
            }
            #endregion // Properties
        }
        #endregion  // Strings Class

        #region Mcf Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Mcf functions that required functions in the console namespace.
        /// </summary>
        /// <history>
        /// 	[barryw] 07DEC05 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public sealed class Mcf
        {
            #region Methods section

            /// <summary>
            /// Gets the path to the monitoring configuration node from which to start.
            /// </summary>
            /// <returns>The path to the monitoring configuration node</returns>
            public static string GetStartingNode()
            {
                Utilities.LogMessage("ManagementPacks.Mcf.GetStartingNode(...)");
                string startingLocation = null;
                try
                {
                    // ------------------------------------------------------ 
                    // Select the starting configuration node.
                    // ------------------------------------------------------

                    // ------------------------------------------------------
                    // Todo: We may need some meta data here so we
                    //       can tell when the starting node is Entity or
                    //       Management Pack, when the object is a group, service,
                    //       etc. to translate to its actual name in db.
                    // ------------------------------------------------------

                    string startingManagementPackName = Common.Mcf.GetVarmapRecordValue(
                        Common.Mcf.Keys.StartingManagementPackName,
                        "Starting configuration Management Pack node");

                    // Get the actual name of the Management Pack, e.g., from the MOM database.
                    startingManagementPackName = Mcf.GetManagementPackName(startingManagementPackName);

                    // Get the entity node name(s).
                    string startingEntityPath = Common.Mcf.GetVarmapRecordValue(
                        Common.Mcf.Keys.StartingEntityPath,
                        "Starting configuration path below the MP node");

                    ////Todo: For walking the inherientance tree split the startingEntityPath
                    ////      and get the display name for each node.
                    // Get display name
                    startingEntityPath = Common.Mcf.Values.GetManagedEntityTypeName(startingEntityPath);

                    // Process any replaceable expressions
                    startingEntityPath = Common.Mcf.Values.ReplaceExpressions(startingEntityPath);

                    startingLocation = startingManagementPackName + "\\" +
                        startingEntityPath;
                    return startingLocation;
                }
                catch
                {
                    Utilities.LogMessage(
                        "ManagementPacks.Mcf.GetStartingNode:: " +
                        "Exception caught here, add specific exception to this function.");

                    // rethrow.
                    throw;
                }
            }

            /// <summary>
            /// Gets the real name for a varmap MP name xreference value,
            /// or if not recognised returns the orginal value.
            /// </summary>
            /// <param name="testDataManangementPackName">The varmap value reference term for the management pack</param>
            /// <returns>actual MP name</returns>
            public static string GetManagementPackName(string testDataManangementPackName)
            {
                Utilities.LogMessage("GetManagementPackName(...)");

                Utilities.LogMessage("GetManagementPackName :: " +
                    "testDataManangementPackName: = " + testDataManangementPackName);

                // Retrieve the localized Management Pack name from the database.
                string managementPackName = null;
                switch (testDataManangementPackName)
                {
                    case Common.Mcf.Values.HardwareManagementPack:
                        {
                            managementPackName = Mom.Test.UI.Core.Console.MP.ManagementPacks.Strings.HardwareManagementPack;
                            break;
                        }
                    case Common.Mcf.Values.MicrosoftImagesManagementPack:
                        {
                            managementPackName = Mom.Test.UI.Core.Console.MP.ManagementPacks.Strings.MicrosoftImagesManagementPack;
                            break;
                        }
                    case Common.Mcf.Values.MOMAEMManagementPack:
                        {
                            managementPackName = Mom.Test.UI.Core.Console.MP.ManagementPacks.Strings.MOMAEMManagementPack;
                            break;
                        }
                    case Common.Mcf.Values.MOMBackwardCompatibilityManagementPack:
                        {
                            managementPackName = Mom.Test.UI.Core.Console.MP.ManagementPacks.Strings.MOMBackwardCompatibilityManagementPack;
                            break;
                        }
                    case Common.Mcf.Values.MOMManagementPack:
                        {
                            managementPackName = Mom.Test.UI.Core.Console.MP.ManagementPacks.Strings.MOMManagementPack;
                            break;
                        }
                    case Common.Mcf.Values.MOMNotificationManagementPack:
                        {
                            managementPackName = Mom.Test.UI.Core.Console.MP.ManagementPacks.Strings.MOMNotificationManagementPack;
                            break;
                        }
                    case Common.Mcf.Values.MyDefaultManagementPack:
                        {
                            // The default management pack name is handled differently it is 
                            // retrieved from the resource file.
                            managementPackName =
                                Mom.Test.UI.Core.Console.MP.ManagementPacks.Strings.DefaultManagementPackFriendlyName;
                            break;
                        }
                    case Common.Mcf.Values.SystemManagementPack:
                        {
                            managementPackName = Mom.Test.UI.Core.Console.MP.ManagementPacks.Strings.SystemManagementPack;
                            break;
                        }
                    case Common.Mcf.Values.WindowsSystemManagementPack:
                        {
                            managementPackName = Mom.Test.UI.Core.Console.MP.ManagementPacks.Strings.WindowsSystemManagementPack;
                            break;
                        }
                    case Common.Mcf.Values.SystemWebMonitoringManagementPack:
                        {
                            managementPackName = Mom.Test.UI.Core.Console.MP.ManagementPacks.Strings.SystemWebMonitoringManagementPack;
                            break;
                        }
                    case Common.Mcf.Values.MicrosoftWindowsIISManagementPack:
                        {
                            managementPackName = Mom.Test.UI.Core.Console.MP.ManagementPacks.Strings.MicrosoftWindowsIISManagementPack;
                            break;
                        }
                    case Common.Mcf.Values.MicrosoftSystemServiceTypeLibrary:
                        {
                            managementPackName = Mom.Test.UI.Core.Console.MP.ManagementPacks.Strings.MicrosoftSystemServiceTypeLibrary;
                            break;
                        }
                    case Common.Mcf.Values.MicrosoftWindowsServerADManagementPack:
                        {
                            managementPackName = Mom.Test.UI.Core.Console.MP.ManagementPacks.Strings.MicrosoftWindowsServerADManagementPack;
                            break;
                        }
                    case Common.Mcf.Values.MicrosoftBaseOSManagementPack:
                        {
                            managementPackName = Mom.Test.UI.Core.Console.MP.ManagementPacks.Strings.MicrosoftBaseOSManagementPack;
                            break;
                        }
                    case Common.Mcf.Values.MicrosoftSQLServer2005ManagementPack:
                        {
                            managementPackName = Mom.Test.UI.Core.Console.MP.ManagementPacks.Strings.MicrosoftSQLServer2005ManagementPack;
                            break;
                        }
                    default:
                        {
                            Utilities.LogMessage("Unknown Management Pack test data name, this may be by design, returning name unchanged.");
                            managementPackName = testDataManangementPackName;
                            break;
                        }
                }
                Utilities.LogMessage("GetManagementPackName :: " +
                    "Returning actual management pack name: = " + managementPackName);
                return managementPackName;
            }

            #endregion
        }

        #endregion  // Mcf Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// MP Import parameters class
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 8/19/2008 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class MPImportParameters
        {
            #region Private Members

            private string mpsAddFromDisk = null;
            private string mpGroupsNeedToSelectInCatalog = "";
            private string mpsNeedToSelectInCatalog = "";
            private string mpsNeedToRemoveInCatalog = "";
            private string keywordToFindMPsInCatalog = "";
            private string predefinedViewSelectedInCatalog =
                SelectMPsFromCatalogDialog.Strings.FilterViewAllMPsInCatalog;
            private string mpsRemoveFromToolStripRemoveButton = null;
            private string mpsRemoveFromErrorMPDialog = null;
            private string mpsRemoveFromContextMenu = null;
            private string mpsResolveFromWarningMPDialog = null;
            private string mpsResolveFromContextMenu = null;

            // private string mpsNeedToCheckPropertyInWizard = null;
            // private string mpsNeedToCheckPropertyInCatalog = null;
            #endregion

            #region constructor

            /// <summary>
            /// Default Constructor
            /// </summary>
            public MPImportParameters()
            {
            }

            #endregion

            #region Properties
            /// <summary>
            /// MPs added from disk
            /// </summary>
            public string MPsAddFromDisk
            {
                get
                {
                    return this.mpsAddFromDisk;
                }
                set
                {
                    this.mpsAddFromDisk = value;
                }
            }

            /// <summary>
            /// MP Groups need to select in Catalog
            /// </summary>
            public string MPGroupsNeedToSelectInCatalog
            {
                get
                {
                    return this.mpGroupsNeedToSelectInCatalog;
                }
                set
                {
                    this.mpGroupsNeedToSelectInCatalog = value;
                }
            }

            /// <summary>
            /// MPS need to select in catalog
            /// </summary>
            public string MPsNeedToSelectInCatalog
            {
                get
                {
                    return this.mpsNeedToSelectInCatalog;
                }
                set
                {
                    this.mpsNeedToSelectInCatalog = value;
                }
            }

            /// <summary>
            /// MPs need to remove in catalog
            /// </summary>
            public string MPsNeedToRemoveInCatalog
            {
                get
                {
                    return this.mpsNeedToRemoveInCatalog;
                }
                set
                {
                    this.mpsNeedToRemoveInCatalog = value;
                }
            }

            /// <summary>
            /// Keyword to find MPs in catalog
            /// </summary>
            public string KeywordToFindMPsInCatalog
            {
                get
                {
                    return this.keywordToFindMPsInCatalog;
                }

                set
                {
                    this.keywordToFindMPsInCatalog = value;
                }
            }

            /// <summary>
            /// predefined view selected in catalog
            /// </summary>
            public string PredefinedViewSelectedInCatalog
            {
                get
                {
                    return this.predefinedViewSelectedInCatalog;
                }

                set
                {
                    this.predefinedViewSelectedInCatalog = value;
                }
            }

            /// <summary>
            /// MPs remove from toolstrip remove button
            /// </summary>
            public string MPsRemoveFromToolStripRemoveButton
            {
                get
                {
                    return this.mpsRemoveFromToolStripRemoveButton;
                }

                set
                {
                    this.mpsRemoveFromToolStripRemoveButton = value;
                }
            }

            /// <summary>
            /// MPs remove from error mp dialog
            /// </summary>
            public string MPsRemoveFromErrorMPDialog
            {
                get
                {
                    return this.mpsRemoveFromErrorMPDialog;
                }

                set
                {
                    this.mpsRemoveFromErrorMPDialog = value;
                }
            }

            /// <summary>
            /// MPs remove from context menu
            /// </summary>
            public string MPsRemoveFromContextMenu
            {
                get
                {
                    return this.mpsRemoveFromContextMenu;
                }

                set
                {
                    this.mpsRemoveFromContextMenu = value;
                }
            }

            /// <summary>
            /// MPs resolve from warning MP dialog
            /// </summary>
            public string MPsResolveFromWarningMPDialog
            {
                get
                {
                    return this.mpsResolveFromWarningMPDialog;
                }

                set
                {
                    this.mpsResolveFromWarningMPDialog = value;
                }
            }

            /// <summary>
            /// MPs resolve from context menu
            /// </summary>
            public string MPsResolveFromContextMenu
            {
                get
                {
                    return this.mpsResolveFromContextMenu;
                }

                set
                {
                    this.mpsResolveFromContextMenu = value;
                }
            }
            #endregion
        }
    }
}