// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConsoleAppParameters.cs">
//  Copyright (c) Microsoft Corporation 2005
// </copyright>
// <project>
//  Base Console Application Class.  Should only inhert from.
// </project>
// <summary>
//  Base ConsoleApp Class.
// </summary>
// <history>
//  [mbickle] 03AUG05: Created
//  [mbickle] 09SEP05: Added new property to MaximizeConsole.
//  [billhodg] 16May10: Reverted SCUI changes and added WebConsole
// </history>
// -----------------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console
{
    #region Using directives
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Common;
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Threading;
    #endregion

    #region ConsoleAppParameters Class
    /// <summary>
    /// Parameters class for ConsoleApp constructors.
    /// </summary>
    /// <history>
    /// [mbickle] 03AUG05 Created
    /// </history>
    ///  public class ConsoleAppParameters : AppParameters
    public class ConsoleAppParameters : AppParameters
    {
        #region Private Members
        /// <summary>
        /// Maximize Console: Default = true;
        /// </summary>
        private bool cachedMaximizeConsole = true;

        /// <summary>
        /// Find Existing Console Running: Default = false;
        /// </summary>
        private bool cachedFindExistingConsoleRunning = false;

        /// <summary>
        /// Product Sku Level: Default = Unknown;
        /// This is now used to distinguish between Desktop, Web and SharePoint UI's
        /// </summary>        
        private ProductSkuLevel cachedSkuLevel = ProductSkuLevel.Unknown;

        /// <summary>
        /// Used to determine if the current Browser is IE or FireFox, defaults to IE
        /// </summary>
        private BrowserType cachedBrowserType =  BrowserType.InternetExplorer;

        /// <summary>
        /// Reset Console Settings: Default = false;
        /// </summary>
        private bool cachedResetConsoleSettings = false;

        /// <summary>
        /// WebConsole AutoSignIn: True/False
        /// </summary>
        private bool cachedAutoSignIn = false;
        #endregion

        #region Constructors
        /// ------------------------------------------------------------------
        /// <summary>
        /// Default Constructor - no need in ExePath etc. Inherited classes
        /// from Console set all required properties on parameter objects.
        /// </summary>
        /// ------------------------------------------------------------------
        public ConsoleAppParameters()
        {
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Constructor for process ID of existing Console Process
        /// </summary>
        /// <param name="processId">Process Id</param>
        /// ------------------------------------------------------------------
        public ConsoleAppParameters(int processId)
        {
            this.ProcId = processId;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Constructor to pass in command-line arguments
        /// </summary>
        /// <param name="arguments">String of Arguments</param>
        /// ------------------------------------------------------------------
        public ConsoleAppParameters(string arguments)
        {
            this.Arguments = arguments;
        }
        #endregion

        #region Properties
        /// ------------------------------------------------------------------
        /// <summary>
        /// Maximize the Console (True/False)
        /// </summary>
        /// ------------------------------------------------------------------
        public bool MaximizeConsole
        {
            get
            {
                return this.cachedMaximizeConsole;
            }

            set
            {
                this.cachedMaximizeConsole = value;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// This option will delete the HKCU Microsoft Operations Manager RegKey.
        /// (ie: Personalization settings) so the console will start up the same
        /// as it does on very first start on a clean install.
        /// </summary>
        /// ------------------------------------------------------------------
          public bool ResetConsoleSettings
          {
              get
              {
                  return this.cachedResetConsoleSettings;
              }

              set
              {
                  this.cachedResetConsoleSettings = value;
              }
          }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Product Sku Level
        /// </summary>
        /// ------------------------------------------------------------------
        public ProductSkuLevel SkuLevel
        {
            get
            {
                return this.cachedSkuLevel;
            }

            set
            {
                this.cachedSkuLevel = value;
            }
        }

        /// <summary>
        /// Web Browser type (IE, Firefox)
        /// </summary>
        public BrowserType BrowserType
        {
            get { return cachedBrowserType; }
            set { cachedBrowserType = value; }
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Find Existing Console Running and use it (true/false)
        /// </summary>
        /// ------------------------------------------------------------------
        public bool FindExistingConsoleRunning
        {
            get
            {
                return this.cachedFindExistingConsoleRunning;
            }

            set
            {
                this.cachedFindExistingConsoleRunning = value;
            }
        }
                
        /// ------------------------------------------------------------------
        /// <summary>
        /// Find Existing Console Running and use it (true/false)
        /// </summary>
        /// ------------------------------------------------------------------
        public bool AutoSignIn
        {
            get
            {
                return this.cachedAutoSignIn;
            }

            set
            {
                this.cachedAutoSignIn = value;
            }
        }
        #endregion
    }
    #endregion
}
