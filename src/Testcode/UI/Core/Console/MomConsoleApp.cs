// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="MomConsoleApp.cs">
//  Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
//  MomConsoleApp
// </project>
// <summary>
//  MomConsole Application Class
// </summary>
// <history>
//  [mbickle] 11JUL05: Created
//  [kellymor]22AUG05: Added methods to discover and manage devices
//                     Added helper method to find text in a grid
//                     Added methods to delete  device and uninstall agent
//                     Added helper method to confirm deletion
//  [kellymor] 28AUG05 Modified DiscoverDevice to improve verify in view step
//                     Added class for Agent Management Task Status
//                     Added view properties classes
//  [kellymor] 29AUG05 Added overloads for the FindDataInRowInGrid method to
//                     take either a column name or index to speed up search
//                     Marked updated FindDataInRowInGrid methods as obsolete,
//                     use ViewPane.Grid.FindData.
//  [kellymor] 31AUG05 Modified DiscoverDevice to check for the domain name
//                     in the list of combobox items for query domain and
//                     select by text if found, else just enter the text.
//  [faizalk]  31AUG05 Added methods to create and launch tasks.
//  [kellymor] 06SEP05 Modified DiscoverDevice to match a UI change for the
//                     discovery task progress step of the wizard
//  [kellymor] 13SEP05 Added method to monitor agent install task progress
//                     Added an overload for DiscoverDevice to take a flag
//                     indicating if it should monitor task progress
//  [kellymor] 15SEP05 Adding sleeps to DiscoverDevice method
//  [kellymor] 19SEP05 Added call to Init method to create a Maui trace log
//  [kellymor] 17NOV05 Removed redundant enums for device discovery 
//                     Removed finaly block in ConfirmChoiceDialog per code 
//                     review
//                     Updated logging in ConfirmChoiceDialog to conform to 
//                     standard
//  [ruhim]   08MAR06  Updating DiscoveredInventoryItem as per redesign
//  [faizalk] 22MAR06  Log the process ID of existing console
//  [kellymor]07MAY08  Removed call to SetUITestMPVisible from method
//                     UpdateParameters as it is no longer required.
//  [kellymor]29OCT08  Fixed bug in ConfirmChoiceDialog to actually delay for
//                     three seconds between retry attempts to find the dialog.
//                     StyleCop fixes.
//  [v-waltli]09APR09  Added Manual Agent Install dialog button captions
//                     Added support for Manual Agent Install dialog buttons
//  [billhodg]21May10  Added Browser support
// </history>
// ----------------------------------------------------------------------------

using Microsoft.EnterpriseManagement.Common;

namespace Mom.Test.UI.Core.Console
{
    #region Using directives
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Maui.GlobalExceptions;
    using Mom.Test.UI.Core.Common;
    using Infra.Frmwrk;
    using Mom.Test.UI.Core.Console.Views;
    using Mom.Test.UI.Core.Console.Views.State;

    #endregion

    #region Interface Definition - IMomConsoleAppControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IMomConsoleAppControls, for MomConsoleApp.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[mbickle] 09MAR05 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMomConsoleAppControls
    {
        // Add something here sometime.
    }
    #endregion

    /// ------------------------------------------------------------------
    /// <summary>
    /// MomConsole Application Class.  Core functionality for the MomConsole.
    /// </summary>
    /// <history>
    /// 	[mbickle]  09MAR05 Created
    ///		[kellymor] 22AUG05 Added methods to discover and manage devices
    ///						   Added helper method to find text in a grid
    ///						   Added methods to delete  device and uninstall agent
    ///						   Added helper method to confirm deletion
    ///     [kellymor] 28AUG05 Modified DiscoverDevice to improve verify in view step
    ///     [kellymor] 29AUG05 Added overloads for the FindDataInRowInGrid method to
    ///                        take either a column name or index to speed up search
    ///     [kellymor] 31AUG05 Modified DiscoverDevice to check for the domain name
    ///                        in the list of combobox items for query domain and
    ///                        select by text if found, else just enter the text.
    ///     [faizalk]  31AUG05 Added methods to create and launch tasks.
    ///     [kellymor] 06SEP05 Modified DiscoverDevice to match a UI change for the
    ///                        discovery task progress step of the wizard
    ///     [kellymor] 13SEP05 Added method to monitor agent install task progress
    ///                        Added an overload for DiscoverDevice to take a flag
    ///                        indicating if it should monitor task progress
    ///     [kellymor] 15SEP05 Adding sleeps to DiscoverDevice method
    ///     [kellymor] 19SEP05 Added call to Init method to create a Maui trace log
    ///     [mcorning] 25MAR06 Implemented IServiceProdiver's GetService()
    /// </history>
    /// ------------------------------------------------------------------
    public class MomConsoleApp : ConsoleApp, IMomConsoleAppControls, IServiceProvider
    {
        #region Member variables section

        /// <summary>
        /// Holds the start datetime of the test. 
        /// </summary>
        private DateTime testStartTime;


        #endregion

        #region Constructors

        /// ------------------------------------------------------------------
        /// <summary>
        /// Starts MomConsole UI directly.
        /// </summary>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        /// 	[mbickle] 09MAR05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public MomConsoleApp()
            : base(UpdateParameters(new ConsoleAppParameters()))
        {
            this.Init();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Starts MomConsole UI directly.
        /// </summary>
        /// <param name="context">Framework Context</param>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        /// 	[mbickle] 09MAR05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public MomConsoleApp(IContext context)
            : base(UpdateParameters(new ConsoleAppParameters(), context))
        {
            this.Init(context);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Starts new instance of Console with Command Line arguments
        /// </summary>
        /// <param name="arguments">Arguments to pass to EXE</param>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        /// 	[mbickle] 03AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public MomConsoleApp(string arguments)
            : base(UpdateParameters(new ConsoleAppParameters(arguments)))
        {
            this.Init();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Starts new instance of Console with Command Line arguments
        /// </summary>
        /// <param name="context">Framework Context</param>
        /// <param name="arguments">Arguments to pass to EXE</param>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        /// 	[mbickle] 03AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public MomConsoleApp(IContext context, string arguments)
            : base(UpdateParameters(new ConsoleAppParameters(arguments), context))
        {
            this.Init(context);

            //comment this since already bring UI into desktop in job setup.
            //#region Switch to desktop on Win8 OS
            //// Check if it is win8 OS
            //Microsoft.Win32.RegistryKey Rk;
            //Rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SoftWare\\Microsoft\\Windows NT\\CurrentVersion");
            //string osName = Rk.GetValue("ProductName").ToString();
            //if (Rk != null && osName.Contains("Windows 8"))
            //{
            //    Sleeper.Delay(Constants.OneMinute);
            //    Utilities.TakeScreenshot("BeforeSwitchToDesktopOnWin8");
            //    Mom.Test.UI.Core.Common.Utilities.SwitchToDesktopOnWin8();
            //}
            //#endregion
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Attaches to existing UI running via passing in ProcessId.
        /// </summary>
        /// <param name="processId">ProcessId</param>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        /// 	[mbickle] 09MAR05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public MomConsoleApp(int processId)
            : base(UpdateParameters(new ConsoleAppParameters(processId)))
        {
            this.Init();
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Attaches to existing UI running via passing in ProcessId.
        /// </summary>
        /// <param name="context">Framework Context</param>
        /// <param name="processId">ProcessId</param>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        /// 	[mbickle] 09MAR05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public MomConsoleApp(IContext context, int processId)
            : base(UpdateParameters(new ConsoleAppParameters(processId), context))
        {
            this.Init(context);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Starts new instance of Console with Command Line arguments
        /// </summary>
        /// <param name="parameters">Application start parameters</param>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        /// 	[mbickle] 03AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public MomConsoleApp(ConsoleAppParameters parameters)
            : base(UpdateParameters(parameters))
        {
            this.Init(null, parameters);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Starts new instance of Console with Command Line arguments
        /// </summary>
        /// <param name="context">Framework Context</param>
        /// <param name="parameters">Application start parameters</param>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        /// 	[mbickle] 03AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public MomConsoleApp(IContext context, ConsoleAppParameters parameters)
            : base(UpdateParameters(parameters, context))
        {
            this.Init(context, parameters);
        }

        #endregion

        #region Properties section

        /// <summary>
        /// Sets the start datetime or returns the start
        /// datetime of the test. 
        /// </summary>
        public DateTime TestStartTime
        {
            get
            {
                return this.testStartTime;
            }

            set
            {
                this.testStartTime = value;
            }
        }

        #endregion

        #region Methods section
        #region public methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// Put the console in a ready for UI testing state
        /// by bringing to the foreground, maximizing and 
        /// setting the focus to the MOM console. 
        /// </summary>
        /// ------------------------------------------------------------------
        public void MakeReady()
        {
            Common.Utilities.LogMessage("MakeReady:: " +
                "Getting the MOM console ready...");

            try
            {
                // bring application to the foreground
                if (CoreManager.MomConsole.MainWindow.Extended.IsForeground == false)
                {
                    CoreManager.MomConsole.BringToForeground();
                }

                // wait until application is ready
                UISynchronization.WaitForUIObjectReady(
                    CoreManager.MomConsole.MainWindow,
                    Constants.DefaultDialogTimeout);
            }
            catch (Exception)
            {
                Common.Utilities.LogMessage("MakeReady:: " +
                    "Unable to set MOM console to foreground.");
                throw;
            }

            try
            {
                // set the focus to the application
                CoreManager.MomConsole.MainWindow.Extended.SetFocus();

                // maximize the main window
                CoreManager.MomConsole.MainWindow.Extended.State = WindowState.Maximize;

                // wait until application is ready
                UISynchronization.WaitForUIObjectReady(
                    CoreManager.MomConsole.MainWindow,
                    Constants.DefaultDialogTimeout);
            }
            catch (Exception)
            {
                Common.Utilities.LogMessage("MakeReady:: " +
                    "Unable to set focus/maximize the MOM console.");
                throw;
            }

            Common.Utilities.LogMessage("MakeReady:: " +
                "MOM console ready.");
        }

        /// <summary>
        /// Signs the currently logged in user into the console [Windows Authentication]. 
        /// Only supports the web console.
        /// </summary>
        public virtual void SignIn()
        {
            if (ProductSku.Sku == ProductSkuLevel.Web)
            {
                Core.Console.Dialogs.LoginDialog loginDialog = new Core.Console.Dialogs.LoginDialog(
                    CoreManager.MomConsole.MainWindow,
                    Constants.DefaultDialogTimeout);

                if (loginDialog.IsVisible == true)
                {
                    Utilities.LogMessage("MomConsoleApp.SignIn :: Signing the current user into the console...");
                    loginDialog.Controls.WindowsAuthRadioButton.Click();
                    loginDialog.Controls.SignInButton.Click();
                    loginDialog.WaitForSignInToComplete(Constants.DefaultSignInTimeout);
                }
                else
                {
                    throw new InvalidOperationException("LoginDialog is not visible");
                }
            }
            else
            {
                throw new NotImplementedException("MomConsoleApp.SignIn is only supported on the web console");
            }
        }

        /// <summary>
        /// Signs the currently logged in user into the console [Network Authentication]. 
        /// Only supports the web console.
        /// </summary>
        /// <param name="username">domain\username</param>
        /// <param name="password">password</param>
        public virtual void SignIn(string username, string password)
        {
            if (ProductSku.Sku == ProductSkuLevel.Web)
            {
                Core.Console.Dialogs.LoginDialog loginDialog = new Core.Console.Dialogs.LoginDialog(
                    CoreManager.MomConsole.MainWindow,
                    Constants.DefaultDialogTimeout);

                if (loginDialog.IsVisible == true)
                {
                    Utilities.LogMessage("MomConsoleApp.SignIn :: Signing '" + username + "' into the console...");
                    loginDialog.Controls.NetworkAuthRadioButton.Click();
                    loginDialog.Controls.UsernameTextBox.Text = username;
                    loginDialog.Controls.PasswordTextBox.Text = password;
                    loginDialog.Controls.SignInButton.Click();
                    loginDialog.WaitForSignInToComplete(Constants.DefaultSignInTimeout);
                }
                else
                {
                    throw new InvalidOperationException("LoginDialog is not visible");
                }
            }
            else
            {
                throw new NotImplementedException("MomConsoleApp.SignIn is only supported on the web console");
            }
        }

        /// <summary>
        /// Sign the current user out of the console.
        /// Only supported on the Web Console.
        /// </summary>
        public virtual void SignOut()
        {
            if (ProductSku.Sku == ProductSkuLevel.Web)
            {
                Core.Console.Dialogs.LoginDialog loginDialog = new Core.Console.Dialogs.LoginDialog(
                    CoreManager.MomConsole.MainWindow,
                    Constants.DefaultDialogTimeout);

                if (loginDialog.Controls.SignOutButton.IsVisible == true)
                {
                    Utilities.LogMessage("MomConsoleApp.SignOut :: Signing out of the console...");
                    loginDialog.Controls.SignOutButton.Click();
                    loginDialog.WaitForSignOutToComplete(Constants.DefaultSignOutTimeout);
                }
                else
                {
                    throw new InvalidOperationException("Signout button is not visible");
                }
            }
            else
            {
                throw new NotImplementedException("MomConsoleApp.SignOut is only supported on the web console");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Checks if the Console Exists
        /// </summary>
        /// <param name="app">MomConsoleApp</param>
        /// <returns>true or false</returns>
        /// <history>
        /// [mbickle] 02AUG05: Created
        /// </history>
        /// ------------------------------------------------------------------
        public virtual bool Exists(MomConsoleApp app)
        {
            try
            {
                Window tempWindow = new Window(
                    Strings.DialogTitle,
                    StringMatchSyntax.WildCard,
                    WindowClassNames.WinForms10Window8,
                    StringMatchSyntax.WildCard,
                    app.MainWindow,
                    3000);
                return true;
            }
            catch (Window.Exceptions.WindowNotFoundException)
            {
                return false;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Checks to see if the Item has been discovered in Monitoring space under UITest State view.
        /// </summary>        
        /// <param name="instanceName">Discovered Instance Name</param>
        /// <param name="instancePath">Computer where the Instance should exists</param>
        /// <param name="numberOfRetries">Number of times to search the View grid</param>
        /// <returns>True/False</returns>
        /// <history>                
        /// [ruhim]   08MAR06 Created  
        /// </history>
        /// ------------------------------------------------------------------
        public virtual bool VerifyDiscoveredInventoryItem(
            string instanceName,
            string instancePath,
            int numberOfRetries)
        {
            string monitoringPath = null;
            if (Utilities.ManagementPackExists(Constants.UITestMPName))
            {
                monitoringPath = NavigationPane.Strings.Monitoring
                    + Constants.PathDelimiter + Constants.UITestViewFolder + Constants.PathDelimiter
                    + "State";
            }
            else
            {
                throw new VarAbort("MomConsoleApp.VerifyDiscoveredInventoryItem:: Need to install UI Test MP first");
            }

            return (this.VerifyDiscoveredInventoryItem(monitoringPath, instanceName, instancePath, numberOfRetries));
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Checks to see if the Item has been discovered in Monitoring space.
        /// </summary>
        /// <param name="monitoringPath">Path to State View</param>
        /// <param name="instanceName">Discovered Instance Name</param>
        /// <param name="instancePath">Computer where the Instance should exists</param>
        /// <param name="numberOfRetries">Number of times to search the View grid</param>
        /// <returns>True/False</returns>
        /// <history>
        /// [mbickle] 24OCT05 Created
        /// [mbickle] 26JAN06 Commented out code and returning True until UI 
        ///                   Changes are working and we can re-implement.
        /// [ruhim]   08MAR06 Updating as per redesign - Verify the Discovered
        ///                   Inventory Item in the results pane of State View  
        /// </history>
        /// ------------------------------------------------------------------
        public virtual bool VerifyDiscoveredInventoryItem(
            string monitoringPath,
            string instanceName,
            string instancePath,
            int numberOfRetries)
        {
            Utilities.LogMessage("MomConsoleApp.VerifyDiscoveredInventoryItem:: (...)");

            bool foundInstance = false;
            int loopCount = 0;
            MomControls.GridControl viewGrid = null;
            StateView stateView = new StateView();

            //Get the view
            viewGrid = stateView.GetStateView(monitoringPath);
            Utilities.LogMessage("MomConsoleApp.VerifyDiscoveredInventoryItem:: Found State view.");

            //Check if the item can be found
            while (loopCount < numberOfRetries)
            {
                DataGridViewRow row = viewGrid.FindInstanceRow(
                            Mom.Test.UI.Core.Console.Views.Views.Strings.StateNameColumnHeader,
                            StateView.Strings.PathColumn,
                            instanceName,
                            instancePath,
                            numberOfRetries,
                            MomControls.GridControl.SearchStringMatchType.ExactMatch);

                if (row != null)
                {
                    Utilities.LogMessage("MomConsoleApp.VerifyDiscoveredInventoryItem:: Successfully verified discovered inventory item.");
                    foundInstance = true;
                    break;
                }

                // refresh the view
                viewGrid.Click();
                CoreManager.MomConsole.Refresh();
                UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow, Constants.DefaultViewLoadTimeout);
                UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow, Constants.DefaultViewLoadTimeout);

                // sleep for five seconds
                Maui.Core.Utilities.Sleeper.Delay(Core.Common.Constants.OneSecond * 5);
                Utilities.LogMessage("MomConsoleApp.VerifyDiscoveredInventoryItem:: Loop Count: " + loopCount.ToString());
                loopCount++;
                Utilities.LogMessage("MomConsoleApp.VerifyDiscoveredInventoryItem:: Matching Instance not found, try again.");
            }

            return foundInstance;
        }

        #endregion

        #region public static methods
        /// <summary>
        /// It reads in the console type from either command line or var records
        /// and if it exists, it sets the console type in the appParams
        /// 
        /// If the SKU type entered on the command line or in the varmap is misspelled
        /// this method can throw an parse exception
        /// </summary>
        /// <param name="context">MCF context, cannot be null</param>
        /// <returns>Return Unknown if no overrided found</returns>
        public static ProductSkuLevel ReadSkuFromVarmap(IContext context)
        {
            //setup logging, if it's not already done
            //if (Mcf.FrameworkContext == null) 
            //    Mcf.FrameworkContext = context;

            // If context is null log a message and then return ProductSkuLevel.Mom
            if (context == null)
            {
                // Legacy areas do not always set the context, therefore we cannot throw here.
                //throw new ArgumentException("ReadSkuFromVarmap: context cannot be null", "context");

                Utilities.LogMessage("ReadSkuFromVarmap: WARNING - mcf context is null");
                return ProductSkuLevel.Mom;
            }

            //get any input console type. Command line trumps var rec
            string consoleType = Mcf.GetValueFromParameterList(context, "ConsoleType", null);
            if (consoleType == null)
            {
                consoleType = Mcf.GetValueFromRecords(context, "ConsoleType", null);
            }

            //set default sku to Unknown
            ProductSkuLevel sku = ProductSkuLevel.Unknown; //ProductSku.Sku;

            //however, if the framework has passed in the console type, use that
            if (consoleType != null)
            {
                Utilities.LogMessage("ReadSkuFromVarmap: setting product sku level to " + consoleType);
                sku = (ProductSkuLevel)Enum.Parse(typeof(ProductSkuLevel), consoleType, true);
            }

            return sku;
        }

        /// <summary>
        /// It reads in the console type from either command line or var records
        /// and if it exists, it sets the console type in the appParams
        /// 
        /// If the SKU type entered on the command line or in the varmap is misspelled
        /// this method can throw an parse exception
        /// </summary>
        /// <param name="context">MCF context, cannot be null</param>
        /// <returns>Return Unknown if no overrided found</returns>
        public static bool ReadAutoSignInFromVarmap(IContext context)
        {

            if (context == null)
            {
                throw new System.ArgumentNullException("context");
            }

            //get any input console type. Command line trumps var rec
            string autoSignIn = Mcf.GetValueFromParameterList(context, "AutoSignIn", null);
            bool signIn = true;

            if (autoSignIn == null)
            {
                //if neither the varmap or command line specify the autosignin, then it should be true
                string recAutoSignin = Mcf.GetValueFromRecords(context, "AutoSignIn", null);
                autoSignIn = String.IsNullOrEmpty(recAutoSignin) ? "true" : recAutoSignin;
            }

            if (autoSignIn != null)
            {
                Utilities.LogMessage("ReadAutoSignInFromVarmap: setting autoSignIn to " + autoSignIn);
                signIn = Boolean.Parse(autoSignIn);
            }

            return signIn;
        }

        /// <summary>
        /// It  reads in the browser type from either command line or var records
        /// and if it exists, it sets the console type in the appParams
        /// If the BrowserType entered on the command line or in the varmap is misspelled
        /// this method can throw an parse exception

        /// </summary>
        /// <param name="context">MCF context, cannot be null</param>
        public static BrowserType ReadBrowserTypeFromVarmap(IContext context)
        {
            //setup logging, if it's not already done
            //if (Mcf.FrameworkContext == null)
            //    Mcf.FrameworkContext = context;


            // If context is null log a message and then return BrowserType.InternetExplorer
            if (context == null)
            {
                // Legacy areas do not always set the context, therefore we cannot throw here.
                //throw new ArgumentException("ReadBrowserTypeFromVarmap: context cannot be null", "context");

                Utilities.LogMessage("ReadSkuFromVarmap: WARNING - mcf context is null");
                return BrowserType.InternetExplorer;
            }

            //get any input console type. Command line trumps var rec
            string browserType = Mcf.GetValueFromParameterList(context, "BrowserType", null);
            if (browserType == null)
            {
                browserType = Mcf.GetValueFromRecords(context, "BrowserType", null);
            }

            //set default sku to Mom
            BrowserType type = BrowserType.InternetExplorer;

            //however, if the framework has passed in the console type, use that
            if (browserType != null)
            {
                Utilities.LogMessage("ReadBrowserTypeFromVarmap: setting browser type to " + browserType);
                type = (BrowserType)Enum.Parse(typeof(BrowserType), browserType, true);
            }

            return type;
        }

        /// <summary>
        /// Close the current console and restart it
        /// </summary>
        /// <param name="context">MCF Context</param>
        public static void RestartConsole(IContext context)
        {
            try
            {
                try
                {
                    CoreManager.MomConsole.Quit();
                }
                catch (Exceptions.CantQuitAppException)
                {
                    Utilities.LogMessage("Maui issue occurred, console already was killed.");
                }

                CoreManager.RemoveConsole(0);

                //bug#217441
                Sleeper.Delay(Mom.Test.UI.Core.Common.Constants.OneSecond * 2);

                // Command line option to flush cache
                string arguments = "/c";

                // create a new instance of the console
                CoreManager.MomConsole = new MomConsoleApp(context, arguments);

                // wait for the console to appear and fully render
                Maui.Core.UISynchronization.WaitForUIObjectReady(
                    CoreManager.MomConsole.MainWindow,
                    Core.Common.Constants.DefaultAppStartupTimeout);
            }
            catch (Exception exception)
            {
                //we need to throw a group abort here, subsequent tests will fail without the console
                throw new ApplicationException("An exception occurred restarting the MOM console!", exception);
            }
            finally
            {
                Utilities.TakeScreenshot("RestartConsole");
            }

        }
        #endregion

        #region IServiceProvider Members

        /// <summary>
        /// Returns a type known to either MomConsole App or its superclases.
        /// </summary>
        /// <example>
        /// Client code gets the DistributedAppCollection from MomConsoleApp using:
        ///     using Mom.Test.UI.Core.Console.ServiceDesigner;
        ///     MomConsoleApp app = CoreManager.MomConsole;
        ///     DistributedAppCollection distAppCollection = null;
        ///     ...
        ///     distAppCollection=(DistributedAppCollection)app.GetService(typeof(DistributedAppCollection));
        /// </example>
        /// <param name="serviceType">Known type of type Type.</param>
        /// <returns>object (which must be cast by client)</returns>
        public virtual object GetService(Type serviceType)
        {
            if (serviceType == typeof(ServiceDesigner.DistributedAppCollection))
            {
                return new ServiceDesigner.DistributedAppCollection();
            }

            return null;
        }

        #endregion

        #endregion

        #region Private Static Methods

        /// ------------------------------------------------------------------
        /// <summary>
        /// Discover the path to the app on this system
        /// </summary>
        /// <returns>the path to the Apps exe file.</returns>
        /// <history>
        /// 	[mbickle] 11JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        private static string GetExePath()
        {
            return ConsoleApp.ConsolePath;
        }

        /// <summary>
        /// This overload handles when their is no context. 
        /// Note that the context must already have been set in the test code
        /// </summary>
        /// <param name="parameters">ConsoleApp Parameters</param>
        /// <returns>ConsoleApp Parameters</returns>
        private static ConsoleAppParameters UpdateParameters(ConsoleAppParameters parameters)
        {
            return UpdateParameters(parameters, Mcf.FrameworkContext);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Corrects application parameters structure for base App constructor.
        /// </summary>
        /// <param name="parameters">ConsoleApp Parameters</param>
        /// <returns>
        /// ConsoleApp Parameters
        /// </returns>
        /// <exception cref="App.Exceptions.AppNotInstalledException">ProductSkuLevel.Unknown</exception>
        /// <history>
        ///		[mbickle] 03AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        private static ConsoleAppParameters UpdateParameters(ConsoleAppParameters parameters, IContext context)
        {
            Utilities.LogMessage("MomConsoleApp.UpdateParameters:: ");

            Utilities.LogMessage("MomConsoleApp.Init:: Setting Mcf.FrameworkContext");
            Mcf.FrameworkContext = context;

            // Get Console Type (SkuLevel).
            //
            // If the code sets the sku level and it's not overwritten by the varmap or command line it remains.
            // The sku is specified in varmap, so we also set ProductSku.Sku here. If we don't do this, the ProductSku.Sku will
            // always be MOM as long as there is MOM installation files on the execution machine
            ProductSkuLevel skuRead = ReadSkuFromVarmap(context);

            if (skuRead != ProductSkuLevel.Unknown)
            {
                parameters.SkuLevel = skuRead;
                ProductSku.Sku = skuRead;
            }
            else if (parameters.SkuLevel == ProductSkuLevel.Unknown)
            {
                parameters.SkuLevel = ProductSku.Sku;
            }

            Utilities.LogMessage("MomConsoleApp.UpdateParameters:: SkuLevel: " + parameters.SkuLevel.ToString());

            parameters.AutoSignIn = ReadAutoSignInFromVarmap(context);
            Utilities.LogMessage("MomConsoleApp.UpdateParameters:: AutoSignIn: " + parameters.AutoSignIn.ToString());

            parameters.BrowserType = ReadBrowserTypeFromVarmap(context);
            Utilities.LogMessage("MomConsoleApp.UpdateParameters:: BrowserType: " + parameters.BrowserType.ToString());

            if (parameters.SkuLevel == ProductSkuLevel.Unknown)
            {
                // If we don't know what product we have installed, throw exception
                throw new App.Exceptions.AppNotInstalledException("MomConsoleApp.UpdateParameters:: ProductSkuLevel.Unknown, no known product installed.");
            }

            // create the Maui trace log files
            Utilities.CreateMauiLog("MomConsoleApp.log", "Trace Output");

            // Startup Timeout.
            parameters.Timeout = Constants.DefaultAppStartupTimeout;

            if (parameters.SkuLevel == ProductSkuLevel.Unknown)
            {
                // If we don't know what product we have installed, throw exception
                throw new App.Exceptions.AppNotInstalledException("MomConsoleApp.UpdateParameters:: ProductSkuLevel.Unknown, no known product installed.");
            }

            // Check to see if we should reset console settings. 
            if (parameters.ResetConsoleSettings)
            {
                ConsoleApp.ResetConsoleSettings();
            }

            // Always attempt to find existing console
            parameters.FindExistingConsoleRunning = true;

            // Attempt to get console ProcId
            if (ProductSku.SkuExe != null)
            {
                parameters.ProcId = Utilities.GetProcessId(ProductSku.SkuExe);
            }
            Utilities.LogMessage("MomConsoleApp.UpdateParameters:: parameters.ProcId = " + parameters.ProcId);

            // If ProcId = 0 then we must start a new UI Instance.
            if (parameters.ProcId <= 0)
            {
                // Check to see if ExePath is anything and if not try and get it from ConsolePath.
                if (parameters.ExePath == null)
                {
                    Utilities.LogMessage("MomConsoleApp.UpdateParameters:: Getting ConsolePath");
                    parameters.ExePath = ConsoleApp.ConsolePath;
                }
            }
            else
            {
                // if ProcId > 0, assign ExePath to use running process exe name
                parameters.ExePath = ProductSku.SkuExe;
            }

            // Added to get handle to splash screen
            // Only when launching the Operations Console there needs splash screen handling
            if (parameters.SkuLevel == ProductSkuLevel.Mom)
            {
                if (parameters.PreMainWindowDialogHandler == null)
                {
                    parameters.PreMainWindowDialogHandler = new AppDialogHandler(ConsoleApp.SplashScreenHandler);
                }
            }

            return parameters;
        }




        /// ------------------------------------------------------------------
        /// <summary>
        /// Initialization of Global Application Variables.
        /// </summary>
        /// <history>
        ///     [mbickle] 02AUG05: Created
        /// </history>
        /// ------------------------------------------------------------------
        private void Init()
        {
            this.Init(null, UpdateParameters(new ConsoleAppParameters()));
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Initialization of Global Application Variables.
        /// </summary>
        /// <param name="context">Framework Context</param>
        /// <history>
        ///     [mbickle] 02AUG05: Created
        /// </history>
        /// ------------------------------------------------------------------
        private void Init(IContext context)
        {
            this.Init(context, UpdateParameters(new ConsoleAppParameters()));
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Initialization of Global Application Variables.
        /// </summary>
        /// <param name="context">Framework Context</param>
        /// <param name="parameters">ConsoleApp Parameters</param>
        /// <history>
        /// [mbickle] 02AUG05: Created
        /// [mbickle] 08AUG05: Added WaitForStatusReady call.
        /// [mbickle] 09SEP05: Added in setting to Maximize Window.   
        /// [kellymor]19SEP05: Added call to method to create a Maui TextLog trace log
        /// [kellymor]19JAN06: Log console process ID to trace log
        /// </history>
        /// ------------------------------------------------------------------
        private void Init(IContext context, ConsoleAppParameters parameters)
        {
            if (Mcf.FrameworkContext == null)
            {
                Mcf.FrameworkContext = context;
            }

            if (context == null)
            {
                // Legacy test code requires that we allow a null context here... we no longer throw new ArgumentException("MomConsoleApp:Init: context cannot be null", "context");
                Utilities.LogMessage("ReadSkuFromVarmap: WARNING - mcf context is null");
            }
        }

        #endregion

        #region Private Methods

        #endregion // Private Methods
    }
}
