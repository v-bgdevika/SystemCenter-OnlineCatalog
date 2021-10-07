//  -----------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ManagementPacksInstallUIGroup.cs">
//     Copyright © Microsoft 2008
// </copyright>
// <project>
//     MP
// </project>
// <summary>
//     Test group automation. 
// </summary>
// <history>
//      [barryw] 01JAN2005 Created
//      [zhihaoq] 19-Aug-2008 Update for Improvement 114932
//      [sunsingh] 25-jan-2009 Added code to import default windowsClientOperatingSystemsMP
//      [sunsingh] 27-jan-2009 Added code to point to new web service URL
//      [v-eachu]  26-Nov-2009 Added BuildType property to mark the build type is signed or nonsigned
// </history>
//  -----------------------------------------------------------------------

namespace Mom.Test.UI.Tests.MP
{
    #region Using directives

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    using Infra.Frmwrk;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Console.Dialogs;
    using Mom.Test.UI.Core.Common;
    using Microsoft.EnterpriseManagement.Test.FrmwrkCommon;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls;

    #endregion

    /// <summary>
    /// Management Packs UI test group automation.
    /// </summary>
    [System.Runtime.InteropServices.ComVisible(false)]
    public sealed class ManagementPacksInstallUIGroup : IManagementPacksInstallUIGroup, ISetup, ICleanup
    {
        #region Private variable
        /// <summary>
        /// isSigned variable used for marking build type is signed or nonsigned, default is true
        /// </summary>
        private static bool isSigned = true;

        #endregion

        #region Properties
        /// <summary>
        /// BuildTypeIsSigned property used for marking build type is signed or nonsigned
        /// </summary>
        public static bool BuildTypeIsSigned
        {
            get
            {
                return isSigned;
            }

            set
            {
                isSigned = value;
            }
        }

        #endregion

        #region Methods section
        /// <summary>
        /// Sets up the group of tests.
        /// </summary>
        /// <param name="context">Framework</param>
        public void Setup(IContext context)
        {
            context.Framework.Trc("Group:Setup(...)");
            try
            {
                Initializer.Initialize(context);
                #region Start MOM Console

                // Start MOM console
                context.Framework.Trc("Group Setup :: Starting MOM Console...");
                if (CoreManager.MomConsole == null)
                {
                   
                    // Reset console settings
                    context.Framework.Trc("Group Setup :: Ready to reset Console setting");
                    ConsoleApp.ResetConsoleSettings();
                    context.Framework.Trc("Group Setup :: Reset Console Setting successful");

                    // Create a new instance of the console
                    CoreManager.MomConsole = new MomConsoleApp(context);

                    // Wait for the console to appear and fully render
                    Maui.Core.UISynchronization.WaitForUIObjectReady(
                        CoreManager.MomConsole.MainWindow,
                        Constants.DefaultAppStartupTimeout);


                    // Reset MP Catalog Web Service URL registry key on non-signed MOM build.
                    string consolePath = null;
                    consolePath = ConsoleApp.ConsolePath;

                    string publicKeyToken = Utilities.GetPublicKeyToken(consolePath);

                    Utilities.LogMessage("The console assembly's public key token is " + publicKeyToken);
                    //changing the URL to point to new webservice URL

                    // Set MP Web Service URL Registry Key if MOM build is a non signed build. 
                    if (publicKeyToken == Constants.TestPublicKeyToken)
                    {
                        BuildTypeIsSigned = false;

                        string regKeyPath = Constants.MomHKCURegistryPath +
                                    "\\" + Constants.MomVersion +
                                    "\\" + Constants.MPCatalogWebServiceURLRegistryKeyPath;
                               
                        Utilities.LogMessage("Group Setup :: Setting Catalog Registry Key " + regKeyPath);

                        Microsoft.Win32.RegistryKey regKey = null;

                        regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(regKeyPath, true);
                        if (regKey == null)
                        {
                            Utilities.LogMessage("Group Setup :: Creating regKeyPath: " + regKeyPath);
                            regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(regKeyPath);
                        }

                        // get parameter from varmap
                        Utilities.LogMessage("Start to get parameter from varmap");
                        string mpCatalogWebServiceURLRegistryKeyValue = context.Records.GetValue("MPCatalogWebService");
                        Utilities.LogMessage("Get mpCatalogWebServiceURLRegistryKey from varmap successfully");

                        if (mpCatalogWebServiceURLRegistryKeyValue == null)
                        {
                            throw new GroupAbort("Failed to get variation parameters from varmap records!" + mpCatalogWebServiceURLRegistryKeyValue);
                        }

                        if (regKey != null)
                        {
                            Utilities.LogMessage("Group Setup :: Setting Key value");
                            regKey.SetValue(
                                Constants.MPCatalogWebServiceURLRegistryKey,
                                mpCatalogWebServiceURLRegistryKeyValue,
                                Microsoft.Win32.RegistryValueKind.String);
                        }
                    }
                    #region Import Microsoft.Windows.Client.Library.mp
                    if (!Core.Common.Utilities.ManagementPackExists(Constants.ClientOperatingSystemsMPName))
                    {
                        context.Trc("GroupSetup:: Importing MP: " + Constants.ClientOperatingSystemsMPName);

                        // Import the UI Test MP
                        Core.Common.Utilities.ImportManagementPack("..\\Common\\Microsoft.Windows.Client.Library.mp");
                        Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond * 60); // A little sleeper to give system time to discover.
                    }
                    else
                    {
                        context.Trc("Did not Import: "
                            + Constants.ClientOperatingSystemsMPName + " already exits");
                    }
                    #endregion

                }
                //// send message to windows for changes For internet explorer proxy reg settings 
                //Utilities.LogMessage("GroupSetup:: Notify windows for changes in registry settings.");
                //Utilities.Notify_RegistrySettingChange();     

                #endregion
            }
            catch (GroupAbort)
            {
                Utilities.TakeScreenshot("ImportMPFromDiskGroupSetup_GroupAbort");
                throw;
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.TakeScreenshot("ImportMPFromDiskGroupSetup_MauiException");
                throw new GroupAbort("MAUI exception starting the MOM Console!", mauiException);
            }
            catch (Exception exception)
            {
                Utilities.TakeScreenshot("ImportMPFromDiskGroupSetup_Exception");
                throw new GroupAbort("An exception occurred starting MOM Console!", exception);
            }
            finally
            {
                #region Check for Unhandled Exceptions

                /* Only check if the console reference is still valid
                 * and the console is still running
                 */
                if (CoreManager.MomConsole != null && CoreManager.MomConsole.IsRunning)
                {
                    context.Framework.Trc("Group Setup :: Checking for unhandled exceptions...");

                    // check for unhandled exceptions, quit if one is found
                    bool unhandledExceptionOccured =
                        CoreManager.MomConsole.CheckForUnhandledException(false);

                    // handle exceptions dialog
                    if (unhandledExceptionOccured == true)
                    {
                        context.Framework.Trc("Group Setup :: Found an unhandled exception!");

                        Utilities.TakeScreenshot("ImportMPFromDiskGroupSetup_UnhandledException");

                        // raise group exception
                        throw new GroupAbort("An unhandled exception occurred during the start of the application!");
                    }
                }
                #endregion
            }
        }

        /// <summary>
        /// Cleanup for this group of tests.
        /// </summary>
        /// <param name="context">Framework</param>
        public void Cleanup(IContext context)
        {
            context.Framework.Trc("Group:Cleanup(...)");
            try
            {
                //Close Console
                Utilities.LogMessage("GroupCleanup :: Closing MOM console...");
                CoreManager.MomConsole.Quit();
            }
            catch (Maui.GlobalExceptions.MauiException mauiException)
            {
                Utilities.TakeScreenshot("GroupCleanup_MauiException");

                throw new GroupAbort("MAUI exception closing the MOM console!", mauiException);
            }
            catch (Exception exception)
            {
                Utilities.TakeScreenshot("GroupCleanup_Exception");

                throw new GroupAbort("An exception occurred closing. the MOM console!", exception);
            }
            finally
            {
                #region Check for Unhandled Exceptions

                /* only check if the console reference is still valid 
                 * and the console is still running
                 */
                if (CoreManager.MomConsole != null && CoreManager.MomConsole.IsRunning)
                {
                    context.Framework.Trc("Group Cleanup :: Checking for unhandled exceptions...");

                    // check for unhandled exceptions, quit if one is found
                    bool unhandledExceptionOccured =
                        CoreManager.MomConsole.CheckForUnhandledException(false);

                    // handle exceptions dialog
                    if (unhandledExceptionOccured == true)
                    {
                        context.Framework.Trc("Group Cleanup :: Found an unhandled exception!");

                        Utilities.TakeScreenshot("GroupCleanup_UnhandledException");

                        // raise group exception
                        throw new GroupAbort("An unhandled exception occurred closing the application!");
                    }
                    else
                    {
                        // close console
                        CoreManager.MomConsole.Quit();
                        Maui.Core.Utilities.Sleeper.Delay(5000);

                        context.Framework.Trc("Group Cleanup :: Checking to see if console is still running...");

                        // if still running...
                        if (CoreManager.MomConsole.IsRunning)
                        {
                            context.Framework.Trc("Group Cleanup :: Killing the MOM console process...");

                            // kill process
                            CoreManager.MomConsole.Kill();
                        }
                    }
                }

                #endregion

                // reset console settings
                //ConsoleApp.ResetConsoleSettings();
            }
        }

        #endregion
    }
}

