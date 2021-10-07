//  -----------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ManagementPacksInstallUI.cs">
//     Copyright ?Microsoft 2005
// </copyright>
// <project>
//     MP
// </project>
// <summary>
//     Tests of the administration of Management Packs.
// </summary>
// <history>
//      [barryw] 14Jul2005 Created
//      [barryw] 30Aug2005 Adjusted reference to rename control 
//                         (FilesoftypeEditComboBox).
//      [faizalk] 25MAR2006 Modify for MP Import redesign
//      [faizalk] 02MAY2006 Fix BVT break
//      [sunsingh] 01 2009  Fix Timeout Issue (getting timeout value from varmap while calling import managementpack function)
//      [v-eachu] 26Nov2009 Add Update for installed MPs from catalog and verify
//      [rahsing] 01DEC2015 Add method to verify More Information UI.
//      [rahsing] 10DEC2015 Add method to verify Get MP and Get All Mps.
//      [rahsing] 14DEC2015 Add method to verify Refresh.
//      [satim]   03MAR2016 Added method to verify overrides from View sources dialog through Tune management pack view and 
//                          Tune Alerts window. 
//      [rahsing] 25MAY2016 Add method to verify View Guide and View DLC Page
//      [rahsing] 06JUL2017 Add methods to do the third party UR Testing.
// </history>
//  -----------------------------------------------------------------------

namespace Mom.Test.UI.Tests.MP
{
    #region Using directives

    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using Infra.Frmwrk;
    using Mom.Test.UI.Core;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Console.Dialogs;
    using Mom.Test.UI.Core.Console.MP;
    using Mom.Test.UI.Core.Console.MP.Dialogs;
    using Mom.Test.UI.Core.Common;
    using Maui;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;

    #endregion

    /// <summary>
    /// Contains tests of the administration of Management Packs.
    /// </summary>
    [System.Runtime.InteropServices.ComVisible(false)]
    public sealed class ManagmentPacksInstallUI : IManagmentPacksInstallUI, ISetup, ICleanup
    {
        #region Constants section
        ////Todo: Move varmap constants to Mcf class.

        /// <summary>
        /// Identity Id of the root Management Pack. 
        /// </summary>
        private const string TestDataRecordIdentityRoot = "IdentityRoot";

        /// <summary>
        /// Start Date tiem used for the clean up code 
        /// </summary>
        // private DateTime startTime;

        /// <summary>
        /// Type of the root Management Pack (Xml, Dll, Akm). 
        /// </summary>
        private const string TestDataRecordFilesOfTypeRoot = "FilesOfTypeRoot";

        /// <summary>
        /// Maximum expected time (in seconds) for the install to complete.
        /// </summary>
        private const string RootInstallTimeout = "RootInstallTimeoutSeconds";

        /// <summary>
        /// Management Pack display name.
        /// </summary>
        /// <remarks>
        /// Todo: Use varmap expected values to test each of the column values,
        ///      replace column number with finding column number using column name.
        /// </remarks>
        //// private const string ManagementPackDisplayName
        //    = "Test Data Parent 1 Management Pack"; // This value is not localized.

        // Work around for UI Bug#60913
        private const string ManagementPackDisplayName
            = "Test Data Parent 1 Management Pack"; // This value is not localized.
        #endregion

        #region Member variables section

        /// <summary>
        /// Creates the Management Pack helper utility object
        /// </summary>
        private ManagementPacks helperUtilities = new ManagementPacks();

        /// <summary>
        /// Creates the Online Catalog helper utility object
        /// </summary>
        private OnlineCatalog ocHelperUtilities = new OnlineCatalog();

        /// <summary>
        /// StartTime variable.
        /// </summary>
        private DateTime startTime;

        /// <summary>
        /// Bool Variable to check if DeleteMnagementPack() Method is called from clean up
        /// </summary>
        private static bool fromCleanup = false;

        private static ImportManagementPacksDialog importDialog;

        /// <summary>
        /// oldMPVersion list used for storing version of old mps when verifying if the new mps get imported
        /// </summary>
        private static List<string> oldMPVersion = new List<string>();

        private string[] expectedImportedMPs = null;

        #region Member variables test failures section

        /// <summary>
        /// Test failure occurred
        /// </summary>
        private bool testFailure = false;

        /// <summary>
        /// Description of Test failure.
        /// </summary>
        private string testFailureMessage = "";

        /// <summary>
        /// MP Parameters (used for MP Creation)
        /// </summary>
        private Mom.Test.UI.Core.Console.MP.MPParameters mpParams = null;

        /// <summary>
        /// Workload Parameters (used for Updates and Recommendations)
        /// </summary>
        private Mom.Test.UI.Core.Console.MP.WorkloadParameters workloadParams = null;

        /// <summary>
        /// Tune Alerts Parameters (used for Overriding Alerts in Tune Alert Sources window)
        /// </summary>
        private Mom.Test.UI.Core.Console.MP.TuneAlertsParameters TuneAlertsParams = null;

        /// <summary>
        /// MP Description Min Length (used for MP Creation)
        /// </summary>
        private int mpDescMinLength = 25;

        /// <summary>
        /// MP Description Max Length (used for MP Creation)
        /// </summary>
        private int mpDescMaxLength = 75;

        /// <summary>
        /// Flag to indicate whether we are dealing with Import or create (to support legacy code)
        /// </summary>
        private bool isCreate = false;

        /// <summary>
        /// Flag to indicate whether we are dealing with ALM code
        /// </summary>
        public bool ALMcode = false;

        #endregion

        #endregion

        #region Methods section

        /// <summary>
        /// Sets up the test variation.
        /// </summary>
        /// <param name="context">Framework</param>
        public void Setup(IContext context)
        {
            Utilities.LogMessage("ManagementPacksInstallUI.Setup(...)");

            try
            {
                // Set fromCleanup equal false
                fromCleanup = false;

                // Re-Start MOM console as needed.

                // Create console object
                if (CoreManager.MomConsole == null)
                {
                    // Command line option to flush cache
                    const string arguments = "/c";

                    // create a new instance of the console
                    // and pass a reference to the common logging mechanism
                    CoreManager.MomConsole = new MomConsoleApp(context, arguments);
                    Utilities.LogMessage("ManagementPacksInstallUI.Setup: created a new instance of the MOM console.");
                }
                else
                {
                    /* It is necessary to set the framework 
                     * for the variation even though it has
                     * been set for the group. */
                    Mcf.FrameworkContext = context;
                }

                // Get the Mom console ready for testing.
                CoreManager.MomConsole.MakeReady();
            }
            catch (Maui.GlobalExceptions.MauiException mex)
            {
                throw new VarAbort("ManagementPacksInstallUI.Setup: Maui failure in making the MOM Console ready for testing!", mex);
            }
            catch (Exception ex)
            {
                throw new VarAbort("ManagementPacksInstallUI.Setup: Failed to make the MOM console ready for testing!", ex);
            }
            finally
            {
                // Save an image of the screen for diagnostic information.
                Utilities.TakeScreenshot("ManagementPacksInstallUI_Setup");
            }
        }

        /// <summary>
        /// Clean up for the test variation
        /// </summary>
        /// <param name="context">Framework</param>
        public void Cleanup(IContext context)
        {
            this.startTime = DateTime.Now;
            Utilities.LogMessage("Variation Cleanup...");
            Utilities.TakeScreenshot("Cleanup_ScreenShot");
            Maui.Core.Window dialogWindow = null;
            int maxRetry = 10;
            int retry = 0;
            try
            {
                context.Trc("Cleaning up after the variation...");
                try
                {
                    //Utilities.LogMessage("Cleaning up after the variation...");
                    Utilities.LogMessage("VarCleanup:: Check for ExceptionErrorDialog");
                    CoreManager.MomConsole.CheckForExceptionErrorDialog();

                    dialogWindow = new Window(WindowType.Foreground);
                    while (dialogWindow != null && retry <= maxRetry)
                    {
                        Utilities.LogMessage("Window found open during cleanup : " + dialogWindow.Caption);
                        if (CoreManager.MomConsole.MainWindow.Extended.IsForeground)
                            break;
                        try
                        {
                            retry++;
                            dialogWindow.Extended.SetFocus();
                            dialogWindow.ClickTitleBarClose();

                            Utilities.LogMessage("VarCleanup : Looking for confirm dialog");
                            CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.Yes,
                                "",
                            StringMatchSyntax.WildCard,
                            MomConsoleApp.ActionIfWindowNotFound.Ignore);
                            Utilities.LogMessage("VarCleanup : Looking for confirm dialog with ok button");
                            CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.OK,
                                "",
                            StringMatchSyntax.WildCard,
                            MomConsoleApp.ActionIfWindowNotFound.Ignore);
                        }
                        catch (Maui.Core.Window.Exceptions.UnknownActiveWinException a)
                        {
                            Utilities.LogMessage("VarCleanup::Igonring following exception : " + a.ToString());
                        }

                        // wait for the UI to become available again
                        CoreManager.MomConsole.Waiters.WaitForStatusReady(
                            Core.Common.Constants.DefaultDialogTimeout);
                        dialogWindow = new Window(WindowType.Foreground);
                    }
                    fromCleanup = true;
                    if (!this.ALMcode)
                    {
                        DeleteInstallManagementPack(context);
                    }
                    else
                    {
                        this.ALMcode = false;
                    }
                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage("Wizard window not found open during cleanup");
                }
            }
            catch (Maui.GlobalExceptions.MauiException mex)
            {
                throw new VarAbort("Maui failure cleaning up after the variation!", mex);
            }
            catch (Exception ex)
            {
                throw new VarAbort("Failed to clean up after the variation!", ex);
            }
            finally
            {
                #region Take Screenshot

                Utilities.TakeScreenshot("VarCleanup");

                #endregion //Take Screenshot
            }
        }



        /*
                        System.IO.File.Copy(
                        fileNames, 
                        Utilities.MomPath + fileNames, 
                        overwrite);
         */
        /// <summary>
        /// Make sure 3.1.3 test case running on debug build, bug#176499
        /// </summary>
        /// <param name="context">Framework</param>
        public void RunCaseOnDebugBuild(IContext context)
        {
            //Verify product build type, if is signed build throw unspported
            if (ManagementPacksInstallUIGroup.BuildTypeIsSigned)
            {
                throw new VarUnsupported("VerifyProductType:: This test case can not running on signed build");
            }

        }

        /// <summary>
        /// Verify the Managment Pack was added to the pre-installation
        /// list with the expected status.
        /// </summary>
        /// <param name="context">Framework</param>
        public void VerifyAddManagementPack(IContext context)
        {
            try
            {
                Utilities.LogMessage("VerifyAddManagementPack(...)");

                ////Todo: verification
            }
            catch (Maui.GlobalExceptions.MauiException mex)
            {
                throw new VarAbort(
                    "Maui failure in " +
                    "verifying ManagementPack(s) were added to the list!",
                    mex);
            }
            catch (Exception ex)
            {
                throw new VarAbort(
                    "Failed to " +
                    "verify ManagementPack(s) were added to the list!",
                    ex);
            }
            finally
            {
                // Save an image of the screen for diagnostic information.
                Utilities.TakeScreenshot("VerifyAddManagementPack");

                #region Check for Unhandled Exceptions
                ////Todo Remove this redundant check for Unhandled Exceptions

                if (CoreManager.MomConsole != null && CoreManager.MomConsole.IsRunning == true)
                {
                    Utilities.LogMessage("VerifyAddManagementPack :: Checking for unhandled exceptions...");

                    // check for unhandled exceptions, quit if one is found
                    bool unhandledExceptionOccured =
                        CoreManager.MomConsole.CheckForUnhandledException(false);

                    // handle exceptions dialog
                    if (unhandledExceptionOccured == true)
                    {
                        Utilities.LogMessage("VerifyAddManagementPack :: Found an unhandled exception!");

                        // raise var exception
                        throw new VarAbort("An unhandled exception occurred during " +
                            "the process of verifying the management pack pre-installation list!");
                    }
                }

                #endregion
            }
        }

        public void ImportManagementPacks(IContext context)
        {
            // Get parameter from varmap. 
            string[] testData = context.Records.GetValues("TestData");
            string testflag = context.Records.GetValue("caseflag");
            if (testflag == "SignedOnly" && ManagementPacksInstallUIGroup.BuildTypeIsSigned == false)
            {
                throw new VarUnsupported("Debug mom server could not line to catalog, unsupported!");
            }
            else
            {
                //work around bug#217219 SQLserver 2000 MP signed download from tacalog don't support
                if (testData != null && testData.Length > 0)
                {
                    foreach (string path in testData)
                    {
                        if (ManagementPacksInstallUIGroup.BuildTypeIsSigned && path.Contains("SQLServer.2000"))
                            throw new VarUnsupported("test case don't support the SQL Server 2000 signed running");
                    }
                }
                try
                {
                    Utilities.LogMessage("ImportManagementPacks starts ....");

                    // List to store all the test import parameter
                    List<ManagementPacks.MPImportParameters> mpImportCollection = new List<ManagementPacks.MPImportParameters>();
                    Utilities.LogMessage("After getting data from varmap");

                    for (int i = 0; i < testData.Length; i++)
                    {
                        Utilities.LogMessage(testData[i]);
                        ManagementPacks.MPImportParameters mpImportParameters = new ManagementPacks.MPImportParameters();

                        string[] parametersInPair = testData[i].Split(new char[] { ';' });

                        for (int j = 0; j < parametersInPair.Length; j++)
                        {

                            string[] keyAndValue = parametersInPair[j].Split(new char[] { '=' });

                            switch (keyAndValue[0])
                            {
                                case "MPsAddFromDisk":
                                    {
                                        keyAndValue[1] = keyAndValue[1].Replace(
                                            "$CurrentDirectory$",
                                            Environment.CurrentDirectory);
                                        mpImportParameters.MPsAddFromDisk = keyAndValue[1];

                                        break;
                                    }
                                case "MPsAddFromDiskForResolve":
                                    {
                                        if (ManagementPacksInstallUIGroup.BuildTypeIsSigned)
                                        {
                                            if (keyAndValue[1].Contains("signed"))
                                            {
                                                keyAndValue[1] = keyAndValue[1].Replace(
                                                    "$CurrentDirectory$",
                                                    Environment.CurrentDirectory);
                                                mpImportParameters.MPsAddFromDisk = keyAndValue[1];
                                            }
                                        }
                                        else
                                        {
                                            if (!keyAndValue[1].Contains("signed"))
                                            {
                                                keyAndValue[1] = keyAndValue[1].Replace(
                                                    "$CurrentDirectory$",
                                                    Environment.CurrentDirectory);
                                                mpImportParameters.MPsAddFromDisk = keyAndValue[1];
                                            }
                                        }
                                        break;
                                    }
                                case "OldMPsAddFromDisk":
                                    {
                                        if (ManagementPacksInstallUIGroup.BuildTypeIsSigned)
                                        {
                                            if (keyAndValue[1].Contains("signed"))
                                            {
                                                keyAndValue[1] = keyAndValue[1].Replace(
                                                    "$CurrentDirectory$",
                                                    Environment.CurrentDirectory);
                                                mpImportParameters.MPsAddFromDisk = keyAndValue[1];
                                            }
                                        }
                                        else
                                        {
                                            if (!keyAndValue[1].Contains("signed"))
                                            {
                                                keyAndValue[1] = keyAndValue[1].Replace(
                                                    "$CurrentDirectory$",
                                                    Environment.CurrentDirectory);
                                                mpImportParameters.MPsAddFromDisk = keyAndValue[1];
                                            }
                                        }

                                        break;
                                    }
                                case "MPGroupsNeedToSelectInCatalog":
                                    {
                                        Utilities.LogMessage("Print Key and Value 1 " + keyAndValue[1]);
                                        mpImportParameters.MPGroupsNeedToSelectInCatalog = keyAndValue[1];
                                        break;
                                    }
                                case "MPsNeedToSelectInCatalog":
                                    {
                                        mpImportParameters.MPsNeedToSelectInCatalog = keyAndValue[1];
                                        break;
                                    }
                                case "MPsNeedToRemoveInCatalog":
                                    {
                                        mpImportParameters.MPsNeedToRemoveInCatalog = keyAndValue[1];
                                        break;
                                    }
                                case "KeywordToFindMPsInCatalog":
                                    {
                                        mpImportParameters.KeywordToFindMPsInCatalog = keyAndValue[1];
                                        break;
                                    }
                                case "PredefinedViewSelectedInCatalog":
                                    {
                                        mpImportParameters.PredefinedViewSelectedInCatalog = keyAndValue[1];
                                        break;
                                    }
                                case "MPsRemoveFromToolStripRemoveButton":
                                    {
                                        mpImportParameters.MPsRemoveFromToolStripRemoveButton = keyAndValue[1];
                                        break;
                                    }
                                case "MPsRemoveFromErrorMPDialog":
                                    {
                                        mpImportParameters.MPsRemoveFromErrorMPDialog = keyAndValue[1];
                                        break;
                                    }
                                case "MPsRemoveFromContextMenu":
                                    {
                                        mpImportParameters.MPsRemoveFromContextMenu = keyAndValue[1];
                                        break;
                                    }
                                case "MPsResolveFromWarningMPDialog":
                                    {
                                        mpImportParameters.MPsResolveFromWarningMPDialog = keyAndValue[1];
                                        break;
                                    }
                                case "MPsResolveFromContextMenu":
                                    {
                                        mpImportParameters.MPsResolveFromContextMenu = keyAndValue[1];
                                        break;
                                    }
                                case "MPsResolveFromContextMenuForResolve":
                                    {
                                        if (ManagementPacksInstallUIGroup.BuildTypeIsSigned)
                                        {
                                            if (keyAndValue[1].StartsWith("$signed$"))
                                            {
                                                keyAndValue[1] = keyAndValue[1].Remove(0, 8);
                                                mpImportParameters.MPsResolveFromContextMenu = keyAndValue[1];
                                            }
                                        }
                                        else
                                        {
                                            if (!keyAndValue[1].StartsWith("$signed$"))
                                            {
                                                keyAndValue[1] = keyAndValue[1];
                                                mpImportParameters.MPsResolveFromContextMenu = keyAndValue[1];
                                            }
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                        }
                        mpImportCollection.Add(mpImportParameters);
                    }

                    /* Comment out because the subrecord is not implemented. 
                    IRecords subrecords = context.Records.GetSubRecord("TestData");   
            
                    foreach (string key in subrecords.GetKeys())
                    {
                        foreach (string val in subrecords.GetValues(key))
                        {
                            Utilities.LogMessage("ImprotManagementPacks:: Get data as Key: "+key+" value: " + val);
                        }
                    }
                    */

                    foreach (ManagementPacks.MPImportParameters mpImportParam in mpImportCollection)
                    {
                        if (mpImportParam.MPsAddFromDisk != null)
                        {
                            Utilities.LogMessage("recond 1");
                            Utilities.LogMessage(mpImportParam.MPsAddFromDisk);
                        }

                        if (mpImportParam.MPGroupsNeedToSelectInCatalog != "")
                        {
                            Utilities.LogMessage("recond 2");
                            Utilities.LogMessage(mpImportParam.MPGroupsNeedToSelectInCatalog);
                        }

                        if (mpImportParam.MPsNeedToSelectInCatalog != "")
                        {
                            Utilities.LogMessage("recond 3");
                            Utilities.LogMessage(mpImportParam.MPsNeedToSelectInCatalog);
                        }

                        if (mpImportParam.MPsNeedToRemoveInCatalog != "")
                        {
                            Utilities.LogMessage("recond 4");
                            Utilities.LogMessage(mpImportParam.MPsNeedToRemoveInCatalog);
                        }

                        if (mpImportParam.KeywordToFindMPsInCatalog != "")
                        {
                            Utilities.LogMessage("recond 5");
                            Utilities.LogMessage(mpImportParam.KeywordToFindMPsInCatalog);
                        }

                        if (mpImportParam.PredefinedViewSelectedInCatalog != null)
                        {
                            Utilities.LogMessage("recond 6");
                            Utilities.LogMessage(mpImportParam.PredefinedViewSelectedInCatalog);
                        }

                        if (mpImportParam.MPsRemoveFromToolStripRemoveButton != null)
                        {
                            Utilities.LogMessage("recond 7");
                            Utilities.LogMessage(mpImportParam.MPsRemoveFromToolStripRemoveButton);
                        }

                        if (mpImportParam.MPsRemoveFromErrorMPDialog != null)
                        {
                            Utilities.LogMessage("recond 8");
                            Utilities.LogMessage(mpImportParam.MPsRemoveFromErrorMPDialog);
                        }

                        if (mpImportParam.MPsRemoveFromContextMenu != null)
                        {
                            Utilities.LogMessage("recond 9");
                            Utilities.LogMessage(mpImportParam.MPsRemoveFromContextMenu);
                        }

                        if (mpImportParam.MPsResolveFromWarningMPDialog != null)
                        {
                            Utilities.LogMessage("recond 10");
                            Utilities.LogMessage(mpImportParam.MPsResolveFromWarningMPDialog);
                        }

                        if (mpImportParam.MPsResolveFromContextMenu != null)
                        {
                            Utilities.LogMessage("recond 11");
                            Utilities.LogMessage(mpImportParam.MPsResolveFromContextMenu);
                        }
                    }

                    int mpimportTimeout = System.Convert.ToInt16(Mcf.FrameworkContext.FncRecords.GetValue("TimeoutInSeconds"));

                    this.helperUtilities.ImportManagementPacks(mpImportCollection, mpimportTimeout);
                }
                catch (Maui.GlobalExceptions.MauiException mex)
                {
                    throw new VarFail(
                        "Maui failure in " +
                        "installing ManagementPack(s)!",
                        mex);
                }
                catch (Exception ex)
                {
                    throw new VarAbort(
                        "Failed to " +
                        "install ManagementPack(s)!",
                        ex);
                }
                finally
                {
                    // Save an image of the screen for diagnostic information.
                    Utilities.TakeScreenshot("ImportManagementPacks");

                    #region Check for Unhandled Exceptions
                    ////Todo Remove this redundant check for Unhandled Exceptions

                    if (CoreManager.MomConsole != null && CoreManager.MomConsole.IsRunning == true)
                    {
                        Utilities.LogMessage("ImportManagementPacks :: Checking for unhandled exceptions...");

                        // check for unhandled exceptions, quit if one is found
                        bool unhandledExceptionOccured =
                            CoreManager.MomConsole.CheckForUnhandledException(false);

                        // handle exceptions dialog
                        if (unhandledExceptionOccured == true)
                        {
                            Utilities.LogMessage("ImportManagementPacks :: Found an unhandled exception!");

                            // raise var exception
                            throw new VarAbort("An unhandled exception occurred during " +
                                "the process of installing management pack(s)!");
                        }
                    }

                    #endregion
                }
            }
        }

        /// <summary>
        /// Update Available for Installed Management Packs
        /// </summary>
        /// <param name="context">Framework</param>
        public void UpdateAvailableForInatalledManagementPacks(IContext context)
        {
            if (ManagementPacksInstallUIGroup.BuildTypeIsSigned == false)
            {
                throw new VarUnsupported("Debug server could not line to catalog!");
            }
            else
            {
                Utilities.LogMessage("UpdateAvailableForInatalledManagementPacks:: Start ...");
                try
                {
                    string searchItem = null;
                    if (ManagementPacksInstallUIGroup.BuildTypeIsSigned)
                    {
                        searchItem = Mcf.FrameworkContext.FncRecords.GetValue("SearchItemSigned");
                    }
                    else
                    {
                        searchItem = Mcf.FrameworkContext.FncRecords.GetValue("SearchItemNonsigned");
                    }

                    if (searchItem == null || searchItem.Equals(""))
                    {
                        Utilities.LogMessage("UpdateAvailableForInatalledManagementPacks:: cannot get searchItem from Varmap");
                        throw new VarAbort("UpdateAvailableForInatalledManagementPacks:: cannot get searchItem from Varmap");
                    }

                    Utilities.LogMessage("UpdateAvailableForInatalledManagementPacks:: Key Word to Find MP in Catalog: " + searchItem);

                    this.helperUtilities.UpdateAvailableForInstalledManagementPacks(searchItem);

                    Utilities.LogMessage("UpdateAvailableForInatalledManagementPacks:: Update Available for Installed ManagementPacks finished");
                }
                catch (VarFail)
                {
                    throw new VarFail("UpdateAvailableForInatalledManagementPacks:: VarFail");
                }
                catch (VarAbort)
                {
                    throw new VarAbort("UpdateAvailableForInatalledManagementPacks:: VarAbort");
                }
                catch (Maui.GlobalExceptions.MauiException mauiException)
                {
                    Utilities.LogMessage("UpdateAvailableForInatalledManagementPacks :: MauiException");
                    throw new VarFail(
                        "UpdateAvailableForInatalledManagementPacks :: MauiException ", mauiException);
                }
                catch (Exception exception)
                {
                    Utilities.LogMessage("UpdateAvailableForInatalledManagementPacks :: Exception");
                    throw new VarFail(
                        "UpdateAvailableForInatalledManagementPacks ::Exception ", exception);
                }
                finally
                {
                    Utilities.TakeScreenshot("UpdateAvailableForInstalledManagementPacks");
                }
            }
            Utilities.TakeScreenshot("UpdateAvailableForInstalledManagementPacks");
        }

        /// <summary>
        /// Get Old MPs' Version for Verifying
        /// </summary>
        /// <param name="context">Framework</param>
        public void GetOldManagmentPackVersion(IContext context)
        {
            try
            {
                #region Get Values from VarMap

                if (ManagementPacksInstallUIGroup.BuildTypeIsSigned)
                {
                    this.expectedImportedMPs = context.Records.GetValues("ExpectedInstalledMPSigned");
                }
                else
                {
                    this.expectedImportedMPs = context.Records.GetValues("ExpectedInstalledMP");
                }

                if (this.expectedImportedMPs == null || this.expectedImportedMPs.Equals(""))
                {
                    throw new VarAbort("Setup:: Cannot Get Expected Installed MPs from Varmap");
                }

                Utilities.LogMessage("Setup:: Get Expected MPs successfully");

                #endregion

                Utilities.LogMessage("GetOldManagmentPackVersion:: Start ...");

                for (int j = 0; j < this.expectedImportedMPs.Length; j++)
                {
                    if (!this.helperUtilities.MPExistsInMPView(this.expectedImportedMPs[j]))
                    {
                        throw new VarFail("GetOldManagmentPackVersion:: Failed to find expected MPs: " + this.expectedImportedMPs[j]);
                    }
                    else
                    {
                        oldMPVersion.Add(this.helperUtilities.GetMPVersion(this.expectedImportedMPs[j]));
                        Utilities.LogMessage("GetOldManagmentPackVersion:: Expected Old MP " + this.expectedImportedMPs[j] + "'s Version: " + oldMPVersion[j]);
                    }
                }
            }
            catch (VarFail)
            {
                throw new VarFail("GetOldManagmentPackVersion:: VarFail");
            }
            catch (VarAbort)
            {
                throw new VarAbort("UpdateAvailableForInatalledManagementPacks:: VarAbort");
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("GetOldManagmentPackVersion :: MauiException");
                throw new VarFail(
                    "GetOldManagmentPackVersion :: MauiException ", mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("GetOldManagmentPackVersion :: Exception");
                throw new VarFail(
                    "GetOldManagmentPackVersion ::Exception ", exception);
            }
            finally
            {
                Utilities.TakeScreenshot("GetOldManagmentPackVersion");
            }
        }

        /// <summary>
        /// Verify if New Management Pack Imported and then delete them
        /// </summary>
        /// <param name="context">Framework</param>
        public void VerifyAndDeleteNewManagementPackImported()
        {
            try
            {
                Utilities.LogMessage("VerifyAndDeleteNewManagementPackImported:: Start ...");

                for (int j = 0; j < this.expectedImportedMPs.Length; j++)
                {
                    if (!this.helperUtilities.MPExistsInMPView(this.expectedImportedMPs[j]))
                    {
                        throw new VarFail("VerifyAndDeleteNewManagementPackImported:: Failed When Verifying : " + this.expectedImportedMPs[j]);
                    }
                    else
                    {
                        if (oldMPVersion[j].Equals(this.helperUtilities.GetMPVersion(this.expectedImportedMPs[j])))
                        {
                            Utilities.LogMessage("VerifyAndDeleteNewManagementPackImported:: Not Updated " + this.expectedImportedMPs[j]);
                            throw new VarFail("VerifyAndDeleteNewManagementPackImported:: Not Updated " + this.expectedImportedMPs[j]);
                        }
                        else
                        {
                            Utilities.LogMessage("VerifyAndDeleteNewManagementPackImported:: Updated " + this.expectedImportedMPs[j]);
                            this.helperUtilities.DeleteManagementPack(this.expectedImportedMPs[j]);
                        }
                    }
                }
            }
            catch (VarFail)
            {
                throw new VarFail("VerifyAndDeleteNewManagementPackImported:: VarFail");
            }
            catch (VarAbort)
            {
                throw new VarAbort("UpdateAvailableForInatalledManagementPacks:: VarAbort");
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("VerifyAndDeleteNewManagementPackImported :: MauiException");
                throw new VarFail(
                    "VerifyAndDeleteNewManagementPackImported :: MauiException ", mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("VerifyAndDeleteNewManagementPackImported :: Exception");
                throw new VarFail(
                    "VerifyAndDeleteNewManagementPackImported ::Exception ", exception);
            }
            finally
            {
                Utilities.TakeScreenshot("VerifyAndDeleteNewManagementPackImported");
            }
        }

        /// <summary>
        /// Invokes the installation of the Management Packs which
        /// are listed as ready to install.
        /// </summary>
        /// <param name="context">Framework</param>
        public void InstallManagementPacks(IContext context)
        {
            try
            {
                Utilities.LogMessage("ImportManagementPacks(...)");

                // Access the Pre-Install Management Packs dialog.
                importDialog = this.helperUtilities.GetImportManagementPacksDialog();

                // Count how many MPs are visible
                Maui.Core.WinControls.ListView managementPackList = importDialog.Controls.ManagementPackListListView;

                // Todo: get expected number from count of MPs coming from varmap data.
                int expectedNumberOfManagementPacks = 1;
                this.VerifyNumberOfManagementPacksDisplayed(managementPackList, expectedNumberOfManagementPacks);

                this.VerifyManagementPackDisplayNameExists(managementPackList, ManagementPackDisplayName);

                /* Old keyboard work around for Click button not working.
                // Tab to 'Install' button
                int loop = 0;
                int maxLoop = 6;
                while (loop <= maxLoop)
                {
                    importDialog.SendKeys(KeyboardCodes.Tab);
                    Utilities.LogMessage("ImportManagementPacks:: Tab key pressed");
                    loop++;
                }

                // Invoke the Install button with the Enter key
                importDialog.SendKeys(KeyboardCodes.Enter);
                Utilities.LogMessage("ImportManagementPacks:: 'Enter' key pressed");
                */

                //\Debug.Assert(importDialog.Controls.InstallButton.Extended.HasFocus);
                Utilities.LogMessage("ImportManagementPacks :: " + "Clicking 'Install' button.");
                importDialog.ClickImport();
                Utilities.LogMessage("ImportManagementPacks :: " + "'Install' button clicked.");

                this.WaitForManagementPackInstallToComplete(context);
            }
            catch (Maui.GlobalExceptions.MauiException mex)
            {
                throw new VarFail(
                    "Maui failure in " +
                    "installing ManagementPack(s)!",
                    mex);
            }
            catch (Exception ex)
            {
                throw new VarAbort(
                    "Failed to " +
                    "install ManagementPack(s)!",
                    ex);
            }
            finally
            {
                // Save an image of the screen for diagnostic information.
                Utilities.TakeScreenshot("ImportManagementPacks");

                #region Check for Unhandled Exceptions
                ////Todo Remove this redundant check for Unhandled Exceptions

                if (CoreManager.MomConsole != null && CoreManager.MomConsole.IsRunning == true)
                {
                    Utilities.LogMessage("ImportManagementPacks :: Checking for unhandled exceptions...");

                    // check for unhandled exceptions, quit if one is found
                    bool unhandledExceptionOccured =
                        CoreManager.MomConsole.CheckForUnhandledException(false);

                    // handle exceptions dialog
                    if (unhandledExceptionOccured == true)
                    {
                        Utilities.LogMessage("ImportManagementPacks :: Found an unhandled exception!");

                        // raise var exception
                        throw new VarAbort("An unhandled exception occurred during " +
                            "the process of installing management pack(s)!");
                    }
                }

                #endregion
            }
        }

        /// <summary>
        /// Verify the status of the installs via the wizard dialog
        /// </summary>
        /// <param name="context">Framework</param>
        public void DeleteInstallManagementPack(IContext context)
        {
            try
            {
                Utilities.LogMessage("DeleteInstallManagementPack:: start");

                // Navigate to the MP node in administration tree. 
                Maui.Core.WinControls.TreeNode node =
                    this.helperUtilities.NavigateToNodeManagementPacks();

                Utilities.LogMessage("Navigated to the Management Pack node.");

                // Refresh the list of MPs.
                node.Click();
                //CoreManager.MomConsole.Refresh();
                Core.Console.MomControls.GridControl mpGridView = null;
                CoreManager.MomConsole.Waiters.WaitForConditionCheckSuccessSafe(delegate()
                {
                    mpGridView = CoreManager.MomConsole.ViewPane.Grid;
                    return null != mpGridView;
                });

                mpGridView.SendKeys(KeyboardCodes.F5);

                // Wait for MP view to load MPs.
                CoreManager.MomConsole.Waiters.WaitForReady();

                string[] expectedMPs = null;

                if (ManagementPacksInstallUIGroup.BuildTypeIsSigned && context.Records.HasKey("ExpectedInstalledMPSigned"))
                {
                    expectedMPs = context.Records.GetValues("ExpectedInstalledMPSigned");
                }
                else
                {
                    expectedMPs = context.Records.GetValues("ExpectedInstalledMP");
                }
                bool mpExistsInMPView = false;

                for (int j = 0; j < expectedMPs.Length; j++)
                {
                    Utilities.LogMessage("DeleteInstallManagementPack:: MP will be deleted: " + expectedMPs[j]);

                    mpExistsInMPView = this.helperUtilities.MPExistsInMPView(expectedMPs[j]);
                    if (!mpExistsInMPView && fromCleanup == false) // if delete is not called from cleanup code.
                    {
                        throw new VarFail("DeleteInstallManagementPack:: Failed to install expected MPs: " + expectedMPs[j]);
                    }
                    if (mpExistsInMPView) // delete only if MP exists
                        this.helperUtilities.DeleteManagementPack(expectedMPs[j]);
                }

                //// Delete MP

                //for (int j = 0; j < expectedMPs.Length; j++)
                //{
                //    if (this.helperUtilities.MPExistsInMPView(expectedMPs[j])) // delete only if MP exists
                //        this.helperUtilities.DeleteManagementPack(expectedMPs[j]);
                //}
            }
            catch (VarFail)
            {
                throw new VarFail("DeleteInstallManagementPack:: VarFail, Failed to install expected MPs");
            }
            catch (Maui.GlobalExceptions.MauiException mex)
            {
                throw new VarAbort(
                    "DeleteInstallManagementPack:: Maui failure in " +
                    "verifying ManagementPack(s) installation status!",
                    mex);
            }
            catch (Exception ex)
            {
                throw new VarAbort(
                    "DeleteInstallManagementPack:: Failed to " +
                    "verify ManagementPack(s) installation status!",
                    ex);
            }
            finally
            {
                // Save an image of the screen for diagnostic information.
                Utilities.TakeScreenshot("DeleteInstallManagementPack");

                #region Check for Unhandled Exceptions
                ////Todo Remove this redundant check for Unhandled Exceptions

                if (CoreManager.MomConsole != null && CoreManager.MomConsole.IsRunning == true)
                {
                    Utilities.LogMessage("DeleteInstallManagementPack:: Checking for unhandled exceptions...");

                    // check for unhandled exceptions, quit if one is found
                    bool unhandledExceptionOccured =
                        CoreManager.MomConsole.CheckForUnhandledException(false);

                    // handle exceptions dialog
                    if (unhandledExceptionOccured == true)
                    {
                        Utilities.LogMessage("DeleteInstallManagementPack:: Found an unhandled exception!");

                        // raise var exception
                        throw new VarAbort("DeleteInstallManagementPack:: An unhandled exception occurred during " +
                            "the process of verifying the management pack installation list!");
                    }
                }

                #endregion            }
            }
        }

        /// <summary>
        /// Determines whether the Management Pack installation is completed.
        /// </summary>
        /// <param name="context">Framework</param>
        private void WaitForManagementPackInstallToComplete(IContext context)
        {
            try
            {
                Utilities.LogMessage("WaitForManagementPackInstallToComplete(...)");

                // Set the timeout for the installation
                int installTimeout;
                if (context.Records.HasKey(RootInstallTimeout))
                {
                    installTimeout = Convert.ToInt16(
                        context.Records.GetValue(RootInstallTimeout));
                }
                else
                {
                    throw new VarmapValidationException(
                        "Required record is missing: " +
                        RootInstallTimeout);
                }

                Utilities.LogMessage("WaitForManagementPackInstallToComplete:: timeout = " + installTimeout);

                // Wait for installation process to complete
                ImportManagementPacksCloseDialog importCloseDialog = null;
                bool windowFound = true;
                int loop = 0;
                while (loop <= installTimeout)
                {
                    try
                    {
                        // Access the Management Packs Import Close dialog.
                        importCloseDialog = this.helperUtilities.GetImportManagementPacksCloseDialog();

                        // the following line throws an exception unless the Close button has appeared
                        importCloseDialog.ClickClose();
                        Utilities.LogMessage("WaitForManagementPackInstallToComplete:: clicked close...");
                    }
                    catch (Maui.Core.Dialog.Exceptions.WindowNotFoundException)
                    {
                        // failed to get dialog on this attempt
                        windowFound = false;
                    }
                    catch (Maui.GlobalExceptions.MauiException)
                    {
                        // failed to get dialog on this attempt
                        windowFound = false;
                    }

                    if (importCloseDialog == null || windowFound == false)
                    {
                        // TODO: replace this with code to capture Close dialog and push Close button
                        // importDialog.SendKeys("%s");

                        windowFound = true;
                        Maui.Core.Utilities.Sleeper.Delay(1000);
                    }
                    else
                    {
                        break;
                    }

                    loop++;
                    Utilities.LogMessage("WaitForManagementPackInstallToComplete:: " + loop + " tries");
                } // end while loop

                // If the dialog is not available after the maximum
                //  number of tries, throw an exception.
                if (importCloseDialog == null || windowFound == false)
                {
                    throw new System.TimeoutException("Timed out before MP Complete finished after " +
                        loop.ToString() + " seconds.");
                }

                // this call throws an exception for some reason 
                // importCloseDialog.ClickClose();
                Maui.Core.Utilities.Sleeper.Delay(1000);

                // importCloseDialog.SendKeys("%s");   
            }
            catch (Maui.GlobalExceptions.MauiException)
            {
                Utilities.LogMessage(
                    "Maui failure in " +
                    "waiting for the Management Pack(s) import to complete!");
                throw;
            }
            catch (TimeoutException)
            {
                Utilities.LogMessage(
                    "Process timed out trying to " +
                    "waiting for the Management Pack(s) import to complete!");
                throw;
            }
            catch (VarmapValidationException)
            {
                Utilities.LogMessage(
                    "Problem with the varmap, please " +
                    "verify the test data is correct.");
                throw;
            }
        }

        /// <summary>
        /// This function is designed to verify the total number of Management Packs
        /// displayed in the list matches the expected number.
        /// </summary>
        /// <param name="managementPackList">The grid that displays the management packs.</param>
        /// <param name="expectedNumberOfManagementPacks">Expected number of Management Packs</param>
        private void VerifyNumberOfManagementPacksDisplayed(
            Maui.Core.WinControls.ListView managementPackList,
            int expectedNumberOfManagementPacks)
        {
            Debug.Assert(0 <= expectedNumberOfManagementPacks, "Negative number not valid");
            Utilities.LogMessage("VerifyNumberOfManagementPacksDisplayed(...)");
            if (managementPackList != null)
            {
                Utilities.LogMessage("VerifyNumberOfManagementPacksDisplayed " +
                    "ManagementPackListView found.");
            }
            else
            {
                throw new NullReferenceException("VerifyNumberOfManagementPacksDisplayed:: " +
                    "Unable to find ManagementPackListView.");
            }

            int numberOfManagementPacks = managementPackList.Items.Count;
            Utilities.LogMessage(
                "VerifyNumberOfManagementPacksDisplayed :: " +
                "Count of MPs listed in list: " +
                numberOfManagementPacks.ToString());

            if (expectedNumberOfManagementPacks == numberOfManagementPacks)
            {
                Utilities.LogMessage(
                    "VerifyNumberOfManagementPacksDisplayed :: " +
                    "Expected number of Management Packs found in the list; " +
                    "Expected = " + expectedNumberOfManagementPacks.ToString() +
                    " Actual = " + numberOfManagementPacks.ToString());
            }
            else
            {
                this.testFailure = true;
                this.testFailureMessage =
                    "VerifyNumberOfManagementPacksDisplayed :: " +
                    "Unexpected number of Management Packs in the list; " +
                    "Expected = " + expectedNumberOfManagementPacks.ToString() +
                    " Actual = " + numberOfManagementPacks.ToString();
                Utilities.LogMessage(this.testFailureMessage);
            }
        }

        /// <summary>
        /// This function is designed to verify the existance of the 
        /// correct MP display name.
        /// </summary>
        /// <param name="managementPackList">The list that displays the management packs.</param>
        /// <param name="managementPackDisplayName">The expected MP display name</param>
        private void VerifyManagementPackDisplayNameExists(
            Maui.Core.WinControls.ListView managementPackList,
            string managementPackDisplayName)
        {
            Utilities.LogMessage("VerifyManagementPackDisplayNameExists(...)");
            Debug.Assert(null != managementPackList, "ListView object is required");
            Debug.Assert(null != managementPackDisplayName, "Expected management pack display name is required");

            // Locate the row with the MP display name in it.
            // bool found = managementPackList.Items.Contains(new Maui.Core.WinControls.ListViewItem(managementPackList, ManagementPackDisplayName));
            bool found = true; // TODO, verify item in list!

            if (found)
            {
                Utilities.LogMessage(
                    "VerifyManagementPackDisplayNameExists :: " +
                    "Found the MP");

                Utilities.LogMessage(
                    "VerifyManagementPackDisplayNameExists :: " +
                    "clicking on the row.");

                // click on the row
                managementPackList.SelectAll();
            }
            else
            {
                this.testFailure = true;
                this.testFailureMessage =
                    "VerifyManagementPackDisplayNameExists :: " +
                    "Management Pack not found by name in the list; " +
                    "Looked for Management Pack Display Name = " + ManagementPackDisplayName;
                Utilities.LogMessage(this.testFailureMessage);
            }
        }

        /// <summary>
        /// Create MP
        /// </summary>
        public void CreateMP(IContext context)
        {
            try
            {
                Core.Common.Utilities.LogMessage("CreateMP");

                this.isCreate = true;

                Core.Common.Utilities.LogMessage("Iscreate : " + this.isCreate.ToString());
                this.mpParams = new Mom.Test.UI.Core.Console.MP.MPParameters();

                #region read varmap records

                this.mpParams.MPName = context.Records.GetValue("MPName");
                this.mpParams.MPVersion = context.Records.GetValue("MPVersion");

                #region random strings

                switch (context.Records.GetValue("MPDescription").ToLowerInvariant())
                {
                    case "$random$":
                        RandomStrings randomStringGenerator = new RandomStrings();
                        this.mpParams.MPDescription = randomStringGenerator.CreateRandomString(
                            this.mpDescMinLength, this.mpDescMaxLength);
                        break;
                    default:
                        this.mpParams.MPDescription = context.Records.GetValue("MPDescription");
                        break;
                }

                #endregion

                switch (context.Records.GetValue("Knowledge").ToLowerInvariant())
                {
                    case "true":
                        this.mpParams.Knowledge = true;
                        break;
                    default:
                        this.mpParams.Knowledge = false;
                        break;
                }

                this.mpParams.MPKnowledgeContent = context.Records.GetValue("KnowledgeContent");

                #endregion

                #region log variation values

                Utilities.LogMessage("------------------Varmap Values--------------------");
                Utilities.LogMessage("MPName:	            '" + this.mpParams.MPName + "'");
                Utilities.LogMessage("MPName Length:	     " + this.mpParams.MPName.Length);
                Utilities.LogMessage("MPVersion:	            '" + this.mpParams.MPVersion + "'");
                Utilities.LogMessage("MP Version Length:	     " + this.mpParams.MPVersion.Length);
                Utilities.LogMessage("MPDescription:	            '" + this.mpParams.MPDescription + "'");
                Utilities.LogMessage("MPDescription Length:	     " + this.mpParams.MPDescription.Length);
                Utilities.LogMessage("Edit Knowledge:	            '" + this.mpParams.Knowledge.ToString() + "'");
                Utilities.LogMessage("KnowledgeContent:                   '" + this.mpParams.MPKnowledgeContent + "'");
                Utilities.LogMessage("KnowledgeContent Length: " + this.mpParams.MPKnowledgeContent.Length);
                Utilities.LogMessage("---------------------------------------------------");

                #endregion

                // go and create!
                this.helperUtilities.CreateNewMP(this.mpParams);
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("CreateMP :: MauiException ");
                throw new VarAbort(
                    "CreateMP :: MauiException ", mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("CreateMP :: Exception ");
                throw new VarAbort(
                    "CreateMP ::Exception ", exception);
            }
            finally
            {
                Utilities.TakeScreenshot("CreateMP");
            }
        }

        /// <summary>
        /// Edit Overrides From Sources window
        /// </summary>
        public void EditOverrideFromSources(IContext context)
        {
            try
            {
                this.ALMcode = true;
                Core.Common.Utilities.LogMessage("EditOverrideFromSources");

                this.TuneAlertsParams = new Mom.Test.UI.Core.Console.MP.TuneAlertsParameters();

                #region MP import
                //UI Test MP
                if (!Utilities.ManagementPackExists("UI.Test.MP"))
                {
                    Utilities.LogMessage("EditOverrideFromSources:: Importing MP: UI.Test.MP.xml");

                    // Import the UI Test MP
                    Utilities.ImportManagementPack("..\\Common\\UI.Test.MP.xml");
                    Maui.Core.Utilities.Sleeper.Delay(60000); // A sleeper to give system time to get alert.
                }
                else
                {
                    Utilities.LogMessage("EditOverrideFromSources::Did not Import the UI Test MP; already exits");
                }
                #endregion

                #region read varmap records

                this.TuneAlertsParams.OverrideOrDisable = context.Records.GetValue("OverrideOrDisable");
                this.TuneAlertsParams.OverrideParameter = context.Records.GetValue("OverrideParameter");
                this.TuneAlertsParams.OverrideParameterValue = context.Records.GetValue("OverrideParameterValue");
                this.TuneAlertsParams.ComboMPName = context.Records.GetValue("ComboMPName");

                #endregion

                #region log variation values

                Utilities.LogMessage("------------------Varmap Values--------------------");
                Utilities.LogMessage("OverrideOrDisable:	     '" + this.TuneAlertsParams.OverrideOrDisable + "'");
                Utilities.LogMessage("OverrideParameter:	     " + this.TuneAlertsParams.OverrideParameter);
                Utilities.LogMessage("OverrideParameterValue:	 '" + this.TuneAlertsParams.OverrideParameterValue + "'");
                Utilities.LogMessage("ComboMPName:	     " + this.TuneAlertsParams.ComboMPName);
                Utilities.LogMessage("---------------------------------------------------");

                #endregion
                //Stop spooler service to generate alerts.
                Utilities.StopService("SPOOLER", Utilities.MomServerName);
                Utilities.LogMessage("EditOverrideFromSources::Sleeping for 5 Minutes for Alerts");
                Maui.Core.Utilities.Sleeper.Delay(300000);
                Utilities.LogMessage("EditOverrideFromSources::Spooler service stopped successfully");

                if (!this.helperUtilities.ClickTuneAlertsAction(this.TuneAlertsParams))
                {
                    Utilities.LogMessage("ClickTuneAlertsAction returned FALSE :: VarFail " + this.TuneAlertsParams.OverrideOrDisable +
                                        ": " + this.TuneAlertsParams.OverrideParameter);
                    throw new VarFail("ClickTuneAlertsAction :: VarFail ");
                }
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("EditOverrideFromSources :: MauiException ");
                throw new VarFail(
                    "EditOverrideFromSources :: MauiException ", mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("EditOverrideFromSources :: Exception ");
                throw new VarFail(
                    "EditOverrideFromSources ::Exception ", exception);
            }
            finally
            {
                Utilities.TakeScreenshot("EditOverrideFromSources");
                //Utilities.StartService("SPOOLER", Utilities.MomServerName);
                Utilities.LogMessage("EditOverrideFromSources::Spooler service started successfully");
                #region MP uninstall
                //UI Test MP
                if (Utilities.ManagementPackExists("UI.Test.MP"))
                {
                    context.Trc("EditOverrideFromSources:: Uninstalling MP: UI.Test.MP.xml");

                    // Import the UI Test MP
                    Utilities.UninstallManagementPack("UI.Test.MP");
                    Sleeper.Delay(60000); // A little sleeper to give system time to uninstall.
                }
                else
                {
                    context.Trc("EditOverrideFromSources:: Did not Uninstall the UI Test MP; it was not installed");
                }
                #endregion
            }
        }

        /// <summary>
        /// More Information UI
        /// </summary>
        public void OnlineCatalogCategoryAutomation(IContext context)
        {
            try
            {
                Core.Common.Utilities.LogMessage("OnlineCatalogCategoryAutomation");

                // go and Verify!
                this.ocHelperUtilities.InstallAndUninstallCategoriesFromOC();
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("OnlineCatalogCategoryAutomation :: MauiException ");
                throw new VarAbort(
                    "OnlineCatalogCategoryAutomation :: MauiException ", mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("OnlineCatalogCategoryAutomation :: Exception ");
                throw new VarAbort(
                    "OnlineCatalogCategoryAutomation ::Exception ", exception);
            }
            finally
            {
                Utilities.TakeScreenshot("OnlineCatalogCategoryAutomation");
            }
        }

        /// <summary>
        /// Get MP for Third party Updates and Recommendations
        /// </summary>
        public void GetMPForThirdPartyUR(IContext context)
        {
            try
            {
                Core.Common.Utilities.LogMessage("GetMPForThirdPartyUR");

                this.workloadParams = new Mom.Test.UI.Core.Console.MP.WorkloadParameters();

                #region read varmap records

                this.workloadParams.workloadName = context.Records.GetValue("workloadName");

                #endregion

                #region log variation values

                Utilities.LogMessage("------------------Varmap Values--------------------");
                Utilities.LogMessage("workloadName:	     " + this.workloadParams.workloadName);
                Utilities.LogMessage("---------------------------------------------------");

                #endregion

                // go and Verify!
                if (!this.helperUtilities.VerifyGetMPForThirdPartyUR(this.workloadParams))
                {
                    Utilities.LogMessage("GetMPForThirdPartyUR returned FALSE :: VarFail " + this.workloadParams.workloadName);
                    throw new VarFail("GetMPForThirdPartyUR :: VarFail " + this.workloadParams.workloadName);
                }
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("GetMPForThirdPartyUR :: MauiException ");
                throw new VarAbort(
                    "GetMPForThirdPartyUR :: MauiException ", mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("GetMPForThirdPartyUR :: Exception ");
                throw new VarAbort(
                    "GetMPForThirdPartyUR ::Exception ", exception);
            }
            finally
            {
                Utilities.TakeScreenshot("GetMPForThirdPartyUR");
            }
        }

        /// <summary>
        /// Get All MPs, View Guide and View DLC Page for Third party Updates and Recommendations
        /// </summary>
        public void DisabledActionsForThirdPartyUR(IContext context)
        {
            try
            {
                Core.Common.Utilities.LogMessage("DisabledActionsForThirdPartyUR");

                this.workloadParams = new Mom.Test.UI.Core.Console.MP.WorkloadParameters();

                #region read varmap records

                this.workloadParams.workloadName = context.Records.GetValue("workloadName");

                #endregion

                #region log variation values

                Utilities.LogMessage("------------------Varmap Values--------------------");
                Utilities.LogMessage("workloadName:	     " + this.workloadParams.workloadName);
                Utilities.LogMessage("---------------------------------------------------");

                #endregion

                // go and Verify!
                if (!this.helperUtilities.VerifyDisabledActionsForThirdPartyUR(this.workloadParams))
                {
                    Utilities.LogMessage("DisabledActionsForThirdPartyUR returned FALSE :: VarFail " + this.workloadParams.workloadName);
                    throw new VarFail("DisabledActionsForThirdPartyUR :: VarFail " + this.workloadParams.workloadName);
                }
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("DisabledActionsForThirdPartyUR :: MauiException ");
                throw new VarAbort(
                    "DisabledActionsForThirdPartyUR :: MauiException ", mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("DisabledActionsForThirdPartyUR :: Exception ");
                throw new VarAbort(
                    "DisabledActionsForThirdPartyUR ::Exception ", exception);
            }
            finally
            {
                Utilities.TakeScreenshot("DisabledActionsForThirdPartyUR");
            }
        }

        /// <summary>
        /// More Information UI
        /// </summary>
        public void MoreInformationUI(IContext context)
        {
            try
            {
                Core.Common.Utilities.LogMessage("MoreInformationUI");

                this.workloadParams = new Mom.Test.UI.Core.Console.MP.WorkloadParameters();

                #region read varmap records

                this.workloadParams.workloadStatus = context.Records.GetValue("WorkloadStatus");

                #endregion

                #region log variation values

                Utilities.LogMessage("------------------Varmap Values--------------------");
                Utilities.LogMessage("WorkloadStatus:	     " + this.workloadParams.workloadStatus);
                Utilities.LogMessage("---------------------------------------------------");

                #endregion

                // go and Verify!
                if(!this.helperUtilities.VerifyMoreInformationUI(this.workloadParams))
                {
                    Utilities.LogMessage("VerifyMoreInformationUI returned FALSE :: VarFail " + this.workloadParams.workloadName);
                    throw new VarFail("MoreInformationUI :: VarFail " + this.workloadParams.workloadName);
                }
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("MoreInformationUI :: MauiException ");
                throw new VarAbort(
                    "MoreInformationUI :: MauiException ", mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("MoreInformationUI :: Exception ");
                throw new VarAbort(
                    "MoreInformationUI ::Exception ", exception);
            }
            finally
            {
                Utilities.TakeScreenshot("MoreInformationUI");
            }
        }

        /// <summary>
        /// Refresh for Updates And Recommendations View
        /// </summary>
        public void RefreshUpdatesAndRecommendationsView(IContext context)
        {
            long expectedTimeToRefreshInMilliseconds = 3000;
            try
            {
                Core.Common.Utilities.LogMessage("RefreshUpdatesAndRecommendationsView");
                
                // go and Verify!
                if (!this.helperUtilities.VerifyUpdatesAndRecommedationsViewRefreshTime(expectedTimeToRefreshInMilliseconds, true))
                {
                    Utilities.LogMessage("RefreshUpdatesAndRecommendationsView returned FALSE :: VarFail ");
                    throw new VarFail("RefreshUpdatesAndRecommendationsView :: VarFail ");
                }
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("RefreshUpdatesAndRecommendationsView :: MauiException ");
                throw new VarAbort(
                    "RefreshUpdatesAndRecommendationsView :: MauiException ", mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("RefreshUpdatesAndRecommendationsView :: Exception ");
                throw new VarAbort(
                    "RefreshUpdatesAndRecommendationsView ::Exception ", exception);
            }
            finally
            {
                Utilities.TakeScreenshot("RefreshUpdatesAndRecommendationsView");
            }
        }

        /// <summary>
        /// Refresh for Updates And Recommendations View after OC Cache expired
        /// </summary>
        public void RefreshUpdatesAndRecommendationsViewAfterCacheExpiry(IContext context)
        {
            long expectedTimeToRefreshInMilliseconds = 3000;
            bool dateChanged = false;
            DateTime tomorrowDate = DateTime.Today.AddDays(1);
            string dateChangeCmd = "/C Date " + tomorrowDate.ToShortDateString();
            try
            {
               
                // go and Verify!
                if (!this.helperUtilities.VerifyUpdatesAndRecommedationsViewRefreshTime(expectedTimeToRefreshInMilliseconds, true))
                {
                    Utilities.LogMessage("RefreshUpdatesAndRecommendationsViewAfterCacheExpiry fn returned FALSE when tried to refresh without OC Connection:: VarFail");
                    throw new VarFail("RefreshUpdatesAndRecommendationsViewAfterCacheExpiry fn returned FALSE when tried to refresh without OC Connection:: VarFail ");
                }

                // Changing the system date to next date to simulate a 1 day OC cache expiry time period.
                System.Diagnostics.Process.Start("CMD", dateChangeCmd);
                dateChanged = true;
                Core.Common.Utilities.LogMessage("RefreshUpdatesAndRecommendationsViewAfterCacheExpiry :: Changed the system date to +24 hrs ");

                // go and Verify!
                if (!this.helperUtilities.VerifyUpdatesAndRecommedationsViewRefreshTime(expectedTimeToRefreshInMilliseconds, false))
                {
                    Utilities.LogMessage("RefreshUpdatesAndRecommendationsViewAfterCacheExpiry fn returned FALSE when tried to refresh with OC Connection :: VarFail ");
                    throw new VarFail("RefreshUpdatesAndRecommendationsViewAfterCacheExpiry fn returned FALSE when tried to refresh with OC Connection :: VarFail ");
                }
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("RefreshUpdatesAndRecommendationsViewAfterCacheExpiry :: MauiException ");
                throw new VarAbort(
                    "RefreshUpdatesAndRecommendationsViewAfterCacheExpiry :: MauiException ", mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("RefreshUpdatesAndRecommendationsViewAfterCacheExpiry :: Exception ");
                throw new VarAbort(
                    "RefreshUpdatesAndRecommendationsViewAfterCacheExpiry ::Exception ", exception);
            }
            finally
            {
                // Changing the system date to original date after cache expiry test.
                if (dateChanged) // we want to change the date to previous date only if the previous date change operation passed without issues.
                { 
                    DateTime currentDate = DateTime.Today.AddDays(-1); //Revert to the previous day.
                    dateChangeCmd = "/C Date " + currentDate.ToShortDateString();
                    System.Diagnostics.Process.Start("CMD", dateChangeCmd);
                }
            }
        }
        /// <summary>
        /// Get MP for Updates And Recommendations View
        /// </summary>
        public void GetMP(IContext context)
        {
            try
            {
                Core.Common.Utilities.LogMessage("GetMP");

                // go and Verify!
                if(!this.helperUtilities.VerifyGetMP())
                {
                    Utilities.LogMessage("GetMP returned FALSE :: VarFail ");
                    throw new VarFail("GetMP :: VarFail ");
                }
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("GetMP :: MauiException ");
                throw new VarAbort(
                    "GetMP :: MauiException ", mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("GetMP :: Exception ");
                throw new VarAbort(
                    "GetMP ::Exception ", exception);
            }
            finally
            {
                Utilities.TakeScreenshot("GetMP");
            }
        }

        /// <summary>
        /// Get All MPs for Updates And Recommendations View
        /// </summary>
        public void GetAllMPs(IContext context)
        {
            try
            {
                Core.Common.Utilities.LogMessage("GetAllMPs");

                this.workloadParams = new Mom.Test.UI.Core.Console.MP.WorkloadParameters();

                // go and Verify!
                if(!this.helperUtilities.VerifyGetAllMPs())
                {
                    Utilities.LogMessage("GetAllMPs returned FALSE :: VarFail ");
                    throw new VarFail("GetAllMPs :: VarFail ");
                }

            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("GetAllMPs :: MauiException ");
                throw new VarAbort(
                    "GetAllMPs :: MauiException ", mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("GetAllMPs :: Exception ");
                throw new VarAbort(
                    "GetAllMPs ::Exception ", exception);
            }
            finally
            {
                Utilities.TakeScreenshot("GetAllMPs");
            }
        }

        /// <summary>
        /// View Guide Link for Updates And Recommendations View
        /// </summary>
        public void ViewGuide(IContext context)
        {
            try
            {
                Core.Common.Utilities.LogMessage("ViewGuide");

                // go and Verify!
                if (!this.helperUtilities.VerifyViewGuide())
                {
                    Utilities.LogMessage("ViewGuide returned FALSE :: VarFail ");
                    throw new VarFail("ViewGuide :: VarFail ");
                }

            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("ViewGuide :: MauiException ");
                throw new VarAbort(
                    "ViewGuide :: MauiException ", mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("ViewGuide :: Exception ");
                throw new VarAbort(
                    "ViewGuide ::Exception ", exception);
            }
            finally
            {
                Utilities.TakeScreenshot("ViewGuide");
            }
        }

        /// <summary>
        /// View DLC Page Link for Updates And Recommendations View
        /// </summary>
        public void ViewDLCPage(IContext context)
        {
            try
            {
                Core.Common.Utilities.LogMessage("ViewDLCPage");

                // go and Verify!
                if (!this.helperUtilities.VerifyViewDLCPage())
                {
                    Utilities.LogMessage("ViewDLCPage returned FALSE :: VarFail ");
                    throw new VarFail("ViewDLCPage :: VarFail ");
                }

            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("ViewDLCPage :: MauiException ");
                throw new VarAbort(
                    "ViewDLCPage :: MauiException ", mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("ViewDLCPage :: Exception ");
                throw new VarAbort(
                    "ViewDLCPage ::Exception ", exception);
            }
            finally
            {
                Utilities.TakeScreenshot("ViewDLCPage");
            }
        }

        /// <summary>
        /// Verify Created MP
        /// </summary>
        public void VerifyCreatedMP()
        {
            try
            {
                if (!this.helperUtilities.VerifyNewMP(this.mpParams.MPName))
                {
                    Utilities.LogMessage("VerifyNewMP returned FALSE :: VarFail " + this.mpParams.MPName);
                    throw new VarFail("VerifyCreatedMP :: VarFail " + this.mpParams.MPName);
                }
            }
            catch (VarFail)
            {
                throw;
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("VerifyCreatedMP :: MauiException " + this.mpParams.MPName);
                throw new VarFail(
                    "VerifyCreatedMP :: MauiException " + this.mpParams.MPName, mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("VerifyCreatedMP :: Exception " + this.mpParams.MPName);
                throw new VarFail(
                    "VerifyCreatedMP ::Exception " + this.mpParams.MPName, exception);
            }
            finally
            {
                Utilities.TakeScreenshot("VerifyCreatedMP");
            }
        }

        /// <summary>
        /// Verify MP Property
        /// </summary>
        public void VerifyMPProperty()
        {
            try
            {
                Utilities.LogMessage("VerifyMPProperty(...)");
                Utilities.LogMessage("Verify that MP in the MP view pane");

                // First navigate to the MP property dialog. 
                this.helperUtilities.NavigateToNodeManagementPacks();

                this.helperUtilities.ExecuteContextMenuForRow(this.mpParams.MPName,
                    ViewPane.Strings.AdministrationContextMenuProperties);

                Utilities.LogMessage("VerifyMPProperty:: selected context menu '" +
                    ViewPane.Strings.AdministrationContextMenuProperties + "'");

                MPGeneralPropertyDialog mpGeneralPropertyDialog = new
                    MPGeneralPropertyDialog(CoreManager.MomConsole, this.mpParams.MPName);

                // set focus on the dialog. Add retry logic in case of failure. 
                try
                {
                    mpGeneralPropertyDialog.Extended.SetFocus();
                    UISynchronization.WaitForUIObjectReady(mpGeneralPropertyDialog, Constants.DefaultDialogTimeout);
                }
                catch (Maui.Core.Window.Exceptions.CannotSetActiveException)
                {
                    int retries = 0;
                    while (retries < 5)
                    {
                        try
                        {
                            Utilities.LogMessage("Caught CannotSetActiveException");
                            mpGeneralPropertyDialog.App.BringToForeground();
                            mpGeneralPropertyDialog.Extended.SetFocus();
                            Utilities.LogMessage("Succeeded setting focus");
                            break;
                        }
                        catch (System.Exception e)
                        {
                            Utilities.LogMessage("Exception caught" + e.Message);
                        }
                        retries++;
                    }
                }

                // verify the name on the general tab
                if (mpGeneralPropertyDialog.NameText.Equals(this.mpParams.MPName))
                {
                    Utilities.LogMessage("Verified MP name");
                }
                else
                {
                    Utilities.LogMessage("Failed to verify MP name");
                    Utilities.LogMessage("Looking for " + this.mpParams.MPName);
                    Utilities.LogMessage("Properties page contains name: " + mpGeneralPropertyDialog.NameText);
                    mpGeneralPropertyDialog.ClickTitleBarClose();
                    throw new VarFail("Failed to verify MP name");
                }

                Utilities.LogMessage("Closing the properties dialog after verification");
                mpGeneralPropertyDialog.ClickTitleBarClose();

            }
            catch (VarFail)
            {
                throw;
            }
            catch (VarAbort)
            {
                throw;
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("VerifyMPProperty :: MauiException " + this.mpParams.MPName);
                throw new VarAbort(
                    "VerifyMPProperty :: MauiException " + this.mpParams.MPName, mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("VerifyMPProperty :: Exception " + this.mpParams.MPName);
                throw new VarAbort(
                    "VerifyMPProperty ::Exception " + this.mpParams.MPName, exception);
            }
            finally
            {
                Utilities.TakeScreenshot("VerifyMPProperty");
            }
        }

        /// <summary>
        /// Verify MP Folder
        /// </summary>
        public void VerifyMPFolder()
        {
            try
            {
                if (!this.helperUtilities.VerifyMonitoringFolder(this.mpParams.MPName))
                {
                    Utilities.LogMessage("VerifyMonitoringFolder returned FALSE :: VarFail " + this.mpParams.MPName);
                    throw new VarFail("VerifyMPFolder :: VarFail " + this.mpParams.MPName);
                }
            }
            catch (VarFail)
            {
                throw;
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("VerifyMPFolder :: MauiException " + this.mpParams.MPName);
                throw new VarFail(
                    "VerifyMPFolder :: MauiException " + this.mpParams.MPName, mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("VerifyMPFolder :: Exception " + this.mpParams.MPName);
                throw new VarFail(
                    "VerifyMPFolder ::Exception " + this.mpParams.MPName, exception);
            }
            finally
            {
                Utilities.TakeScreenshot("VerifyMPFolder");
            }
        }

        /// <summary>
        /// Export MP
        /// </summary>
        public void ExportMP()
        {
            try
            {
                if (System.IntPtr.Size == 8)
                {
                    Utilities.LogMessage("This is x64. #91619 (whidbey bug fixed 4 orcas!!). Bypassing xport");
                    return;
                }
                if (!this.helperUtilities.Export(this.mpParams.MPName, this.mpParams.MPName + ".xml"))
                {
                    Utilities.LogMessage("Export returned FALSE :: VarFail " + this.mpParams.MPName);
                    throw new VarFail("ExportMP :: VarFail " + this.mpParams.MPName);
                }
            }
            catch (VarFail)
            {
                throw;
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("ExportMP :: MauiException " + this.mpParams.MPName);
                throw new VarFail(
                    "ExportMP :: MauiException " + this.mpParams.MPName, mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("ExportMP :: Exception " + this.mpParams.MPName);
                throw new VarFail(
                    "ExportMP ::Exception " + this.mpParams.MPName, exception);
            }
            finally
            {
                Utilities.TakeScreenshot("ExportMP");
            }
        }


        /// <summary>
        /// Delete MP
        /// </summary>
        public void DeleteMP()
        {
            try
            {
                this.helperUtilities.DeleteManagementPack(this.mpParams.MPName);
                if (this.helperUtilities.VerifyNewMP(this.mpParams.MPName))
                {
                    Utilities.LogMessage("VerifyNewMP returned TRUE after delete :: VarFail " + this.mpParams.MPName);
                    throw new VarFail("DeleteMP :: VarFail " + this.mpParams.MPName);
                }
            }
            catch (VarFail)
            {
                throw;
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.LogMessage("DeleteMP :: MauiException " + this.mpParams.MPName);
                throw new VarFail(
                    "DeleteMP :: MauiException " + this.mpParams.MPName, mauiException);
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("DeleteMP :: Exception " + this.mpParams.MPName);
                throw new VarFail(
                    "DeleteMP ::Exception " + this.mpParams.MPName, exception);
            }
            finally
            {
                Utilities.TakeScreenshot("DeleteMP");
            }
        }

        public void DeleteManagementPacks(string[] MPNames)
        {

        }


        #endregion
    }
}

