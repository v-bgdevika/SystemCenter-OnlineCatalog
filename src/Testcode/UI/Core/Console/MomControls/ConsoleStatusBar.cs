//-------------------------------------------------------------------
// <copyright file="ConsoleStatusBar.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Status Bar.
// </summary>
//  <history>
//   [mbickle] 13JUL05 Created
//   [mbickle] 08AUG05 Added WaitForText method.
//   [mbickle] 02SEP05 Cleaned up some FxCop issues.
//   [mbickle] 18SEP05 Added logging and extra checks for getting MessagePanel
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.MomControls
{
    #region Using directives
    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.Text;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using Maui.GlobalExceptions;
    using Mom.Test.UI.Core.Common;
    #endregion

    #region Interfaces
    /// <summary>
    /// Console Status Bar Interface
    /// </summary>
    public interface IConsoleStatusBar
    {
        /// <summary>
        /// StatusBar MessagePanel
        /// </summary>
        String MessagePanel 
        { 
            get; 
        }
    }
    #endregion

    /// ----------------------------------------------------------------------
    /// <summary>
    /// Console Status Bar Control
    /// </summary>
    /// <history>
    /// [mbickle] 13JUL05 Created
    /// [sunsingh] 24Feb10 Marking this Class and all it's member as obselete So the We Use SCUI SControl ConsoleStatusBar Class
    /// </history>
    /// ----------------------------------------------------------------------    
    public sealed class ConsoleStatusBar : StatusBar, IConsoleStatusBar
    {
        #region Member Variables
        /// <summary>
        /// ConsoleApp
        /// </summary>
        private ConsoleApp consoleApp;
        
        /// <summary>
        /// Default Timeout value 30000
        /// </summary>
        private int defaultTimeout = 30000;
        #endregion

        #region "constructors"
        /// ------------------------------------------------------------------
        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="app">Console app</param>
        /// <remarks></remarks>
        /// <history>
        /// [mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public ConsoleStatusBar(ConsoleApp app)
            : base(app.MainWindow, StatusBarQueryId(app.MainWindow), 15000)
        {
            this.consoleApp = app;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="window">Window</param>
        /// <remarks></remarks>
        /// <history>
        ///	[mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public ConsoleStatusBar(Window window)
            : base(window, StatusBarQueryId(window), 15000)
        {
        }
        #endregion

        #region "Properties"
        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Console app
        /// </summary>
        /// <history>
        /// [mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public new ConsoleApp App
        {
            get
            {
                return this.consoleApp;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// StatusBar Panels.
        /// </summary>
        /// ------------------------------------------------------------------
 
        public new StringCollection Panels
        {
            get
            {
                StringCollection result = new StringCollection();
                MauiCollection<IScreenElement> screenElements = base.ScreenElement.FindAllDescendants(-1, ";[FindAll, UIA, VisibleOnly]Name => ''", null);
                int childCount = screenElements.Count;
                for (int index = 1; index < childCount; index++)
                {
                    result.Add(screenElements[index].Name);
                }
                return result;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Exposes the controls
        /// </summary>
        /// <history>
        /// [mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
 
        public IConsoleStatusBar Controls
        {
            get
            {
                return this;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns the the Status message displayed in the status panel
        /// </summary>
        /// <returns>Status message displayed</returns>
        /// <history>
        /// [mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
 
        public string StatusMessage
        {
            get
            {
                return this.Controls.MessagePanel;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns if the StatusBar is visible or not.
        /// </summary>
        /// ------------------------------------------------------------------
 
        public new bool IsVisible
        {
            get
            {
                return this.Extended.IsVisible;
            }
        }
        #endregion

        #region "IConsoleStatusBar Implementation"
        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Status message panel
        /// Returns the text in Status Panel[0] if it can, otherwise returns nothing.
        /// </summary>
        /// <history>
        /// [mbickle] 13JUL05 Created
        /// [mbickle] 09NOV05 Removed accessing StatusBar with ToolStrip control.  
        ///                   Cleaned up some code and removed some retry logic due to 
        ///                   logic already existing in calling methods.
        /// </history>
        /// ------------------------------------------------------------------
        String IConsoleStatusBar.MessagePanel
        {
            get
            {
                string frameworkId = base.ScreenElement.FrameworkId;

                try
                {
                    StringCollection panels = this.Panels;
                    switch (frameworkId)
                    {
                        case "WPF":
                            return panels[1];

                        case "WinForm":
                            return panels[0];
                    }
                    return panels[0];
                }
                catch (ArgumentOutOfRangeException)
                {
                    return string.Empty;
                }
            }
        }
        #endregion

        #region Public Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// WaitForText to appear in StatusBar
        /// Default Timeout: 30seconds
        /// </summary>
        /// <param name="statusMessage">Message to find in StatusBar</param>
        /// <returns>True/False : Found StatusBar Text</returns>
        /// ------------------------------------------------------------------
 
        public new bool WaitForText(String statusMessage)
        {
            return this.WaitForText(statusMessage, this.defaultTimeout);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// WaitForText to appear in StatusBar
        /// </summary>
        /// <param name="statusMessage">Message to find in StatusBar</param>
        /// <param name="timeout">Timout in milliseconds</param>
        /// <returns>True/False: Found StatusBar Text</returns>
        /// ------------------------------------------------------------------

        public new bool WaitForText(String statusMessage, int timeout)
        {
            bool matchFound = false;
            int loop = 0;
            int maxLoop;
            
            // If timeout value is less than 1 second (1000 mill) set to 1000.
            if (timeout < 1000)
            {
                timeout = 1000;
            }
            
            // Set maxLoop based on timeout value.            
            maxLoop = timeout / 1000;

            Utilities.LogMessage("ConsoleStatusBar.WaitForText:: Waiting for text '" + statusMessage + 
                "' to appear in StatusBar");

            while (!matchFound && loop <= maxLoop)
            {
                if (StringHelper.Match(this.StatusMessage, statusMessage))
                {
                    Utilities.LogMessage("ConsoleStatusBar.WaitForText:: '" + this.StatusMessage + "'");
                    Utilities.LogMessage("ConsoleStatusBar.WaitForText:: '" + statusMessage + "' matched.");
                    matchFound = true;
                    break;
                }

                Sleeper.Delay(1000);
                loop++;
            }

            if (!matchFound)
            {
                // One last check before returning.
                matchFound = StringHelper.Match(this.StatusMessage, statusMessage);

                if (!matchFound)
                {
                    Utilities.LogMessage("ConsoleStatusBar.WaitForText:: Match not found, current StatusMessage: '" + this.StatusMessage + "'");
                }
            }

            return matchFound;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Show StatusBar if not Visible
        /// </summary>
        /// ------------------------------------------------------------------
        public void Show()
        {
            if (!this.IsVisible)
            {
                this.Show(CommandMethod.Default);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Show StatusBar if not Visible
        /// </summary>
        /// <param name="method">CommandMehtod</param>
        /// ------------------------------------------------------------------
        public void Show(CommandMethod method)
        {
            if (!this.IsVisible)
            {
                Commands.ViewStatusBar.Execute(CoreManager.MomConsole, method);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Hide StatusBar if Visible
        /// </summary>
        /// ------------------------------------------------------------------

        public void Hide()
        {
            if (this.IsVisible)
            {
                this.Hide(CommandMethod.Default);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Hide StatusBar if Visible
        /// </summary>
        /// <param name="method">CommandMethod</param>
        /// ------------------------------------------------------------------
 
        public void Hide(CommandMethod method)
        {
            if (this.IsVisible)
            {
                Commands.ViewStatusBar.Execute(CoreManager.MomConsole, method);
            }
        }
        #endregion

        #region Private Methods

        private static QID StatusBarQueryId(Window window)
        {
            string frameworkId = window.ScreenElement.FrameworkId;
            switch (frameworkId)
            {
                case "WinForm":
                    return new QID(";[UIA, VisibleOnly]ClassName => 'WindowsForms10.Window.8.app' && Role = 'status bar' && AutomationId = 'consoleStatusBar'");

                case "WPF":
                    return new QID(";[UIA, VisibleOnly]ClassName => 'StatusBar' && Role = 'status bar' && AutomationId = 'PART_StatusBar'");

                default:
                    throw new InvalidOperationException("ConsoleStatusBar.StatusBarQueryId:: Unexpected FrameworkId: " + frameworkId);
            }
        }

        #endregion

        #region Strings Class

        /// ------------------------------------------------------------------
        /// <summary>
        /// Strings Definitions
        /// </summary>
        /// <history>
        /// [mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------

        public class Strings
        {
            #region Constants

            /// --------------------------------------------------------------
            /// <summary>
            /// Contains resource string for string: Ready
            /// </summary>
            /// <remark>
            /// </remark>
            /// --------------------------------------------------------------
            private const string ResourceReady = ";Ready;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.StatusBarResources;ConsoleReady";

            #endregion

            #region Private Members

            /// --------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for: Ready
            /// </summary>
            /// --------------------------------------------------------------
            private static string cachedReady;
            #endregion

            #region Properties

            /// --------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Ready resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 08AUG05 Created
            /// </history>
            /// --------------------------------------------------------------
     
            public static string Ready
            {
                get
                {
                    if ((cachedReady == null))
                    {
                        cachedReady = CoreManager.MomConsole.GetIntlStr(ResourceReady);
                    }

                    return cachedReady;
                }
            }
            #endregion
        }
        #endregion

        #region Control ID's
        /// ------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// [mbickle] 26JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------

        public class ControlIDs
        {
            /// <summary>
            /// StatusBar Control ID
            /// </summary>
     
            public const string StatusBar = "consoleStatusBar";
        }
        #endregion
    }
}
