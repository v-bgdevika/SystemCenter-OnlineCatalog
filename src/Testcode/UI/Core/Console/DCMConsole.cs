// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="DCMConsole.cs">
//  Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
//  DCMConsole
// </project>
// <summary>
//  DCMConsole Application Class
// </summary>
// <history>
//  [billhodg] 12OCT09: Created
// </history>
// ----------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console
{
    #region Using directives
    
    using System;
    using Mom.Test.UI.Core.Common;
    using UIAF = Microsoft.EnterpriseManagement.DataCenterManager.Test.UIAF;
    using Microsoft.EnterpriseManagement.DataCenterManager.Test.UIAF.Macros;
    using Microsoft.EnterpriseManagement.DataCenterManager.Test.UIAF.Macros.Console;
    #endregion

    /// <summary>
    /// App to launch DCMConsole
    /// </summary>
    public class DCMConsole //: MomConsoleApp, ConsoleApp
    {

        private const string DCMConsoleAppId = "DCMAdmin";

        #region Constructors
        /// ------------------------------------------------------------------
        /// <summary>
        /// Starts DCMConsole UI directly.
        /// </summary>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        /// 	[billhodg] 12OCT09 Created
        /// </history>
        /// ------------------------------------------------------------------
        public DCMConsole() 
            //: base(UpdateParameters(new ConsoleAppParameters()))
        {
            this.Init(new DCMConsoleAppParameters());
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Starts new instance of DCMConsole with Command Line arguments
        /// </summary>
        /// <param name="arguments">Arguments to pass to EXE</param>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        /// 	[billhodg] 12OCT09 Created
        /// </history>
        /// ------------------------------------------------------------------
        public DCMConsole(string arguments)
            //: base(UpdateParameters(new ConsoleAppParameters(arguments)))
        {
            this.Init(new DCMConsoleAppParameters(arguments));
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Starts new instance of DCMConsole with Command Line arguments
        /// </summary>
        /// <param name="parameters">Application start parameters</param>
        /// <remarks>
        /// Base class constructor, Maui.Core.App(), called to start and find the application window.
        /// </remarks>
        /// <history>
        /// 	[billhodg] 12OCT09 Created
        /// </history>
        /// ------------------------------------------------------------------
        public DCMConsole(DCMConsoleAppParameters parameters)
           // : base(UpdateParameters(parameters))
        {
            this.Init(parameters);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Return the default AppID for the DCM console
        /// </summary>
        public static string DefaultDcmConsoleAppId
        {
            get { return DCMConsoleAppId; }
        }
       
        #endregion

        #region Private Methods

        /// ------------------------------------------------------------------
        /// <summary>
        /// Start Console base on Application variables.
        /// </summary>
        /// <history>
        ///     [billhodg] 12OCT09 Created
        /// </history>
        /// ------------------------------------------------------------------
        private void Init(DCMConsoleAppParameters parameters)
        {
            // Create UIAF Factory
            UIAF.UIAFactory factory = UIAF.UIAFactory.Instance;

            // add OM logger to DCM macro logging
            Utilities.LogMessage("Attaching UIAF logger");
            factory.Loggers.Add(new ExternalLogger.MCFLogger(Utilities.Logger));

            factory.AddEntryToDynamicLog("Testing the UIAF Log", true, "Test Successful.");

            // Get Console Macros
            ConsoleMacros consoleMacros = new Macros(factory).Console;         

            // Set login and server (only ServerName is required)               
            ConsoleMacros.LogInData loginData = consoleMacros.CreateLoginData(parameters.DCMConsoleAppId);
            loginData.ServerName = parameters.ServerName;
            //loginData.PortNumber = parameters.Port;
            // Impersonation is not yet supported
            //loginData.UserAccount.SetCredentials(parameters.LoginDomainName, parameters.LoginUserName, parameters.LoginPassword);

            // start the DCMConsole
            Utilities.LogMessage("Calling OpenConsole macro for " + loginData.ServerName);
            UIAF.Console.ConsoleApp app = consoleMacros.OpenConsole(loginData);

            // Set coremanager to point to the DCM console
            //CoreManager.DcmApplication = app;

            // set the older MOMConsole class to point to the Console
            Utilities.LogMessage("Setting to existing MomConsoleApp with ID = " + app.Process.Id.ToString());
            ConsoleAppParameters omParameters = new ConsoleAppParameters(app.Process.Id);
            CoreManager.MomConsole = new MomConsoleApp(omParameters); 
        }

        #endregion

        #region public methods

        /// <summary>
        /// CloseConsole - closes default DCM console
        /// </summary>
        public static void CloseConsole()
        {
            DCMConsole.CloseConsole(DCMConsole.DefaultDcmConsoleAppId);
        }

        /// <summary>
        /// CloseConsole - closes DCM console using macro
        /// Doesn't kill process
        /// </summary>
        /// <param name="appId">the console ID to close</param>
        public static void CloseConsole(string appId)
        {
            // check input
            if (appId == "") appId = DCMConsole.DefaultDcmConsoleAppId;

            //Create UIAF Factory
            UIAF.UIAFactory factory = UIAF.UIAFactory.Instance;

            //add OM logger to DCM macro logging
            factory.Loggers.Add(new ExternalLogger.MCFLogger(Utilities.Logger));
         
            //close console
            factory.DisposeAdminConsoleApp(appId);
        }
        #endregion
    }
}
