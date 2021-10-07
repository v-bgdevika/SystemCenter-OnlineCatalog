// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="Wunderbar.cs">
//  Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
//  DCMConsole
// </project>
// <summary>
//  DCMConsole Wunderbar Class
// </summary>
// <history>
//  [billhodg] 30OCT09: Created
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
    using Microsoft.EnterpriseManagement.DataCenterManager.Test.UIAF.Common;
    #endregion

    /// <summary>
    /// Class to click on Wunderbar buttons using UIAF macros
    /// </summary>
    public class DcmWunderbar 
    {

        /// <summary>
        /// internal console macros, set in constructor
        /// </summary>
        private ConsoleMacros consoleMacros; 

        /// <summary>
        /// Used to identify buttons, hides UIAF implementation
        /// </summary>
        public enum Section 
        {
            /// <summary>
            /// Administration Wunderbar button
            /// </summary>
            Administration, 

            /// <summary>
            /// Library Wunderbar button
            /// </summary>
            /// 
            Library, 
            /// <summary>
            /// Operations Wunderbar button
            /// </summary>
            /// 
            Operations, 
            /// <summary>
            /// Reports Wunderbar button
            /// </summary>
            /// 
            Reports, 

            /// <summary>
            /// SettingsWunderbar button
            /// </summary>
            Settings
        }

        /// <summary>
        /// Constructor, creates consolemacro
        /// </summary>
        public DcmWunderbar()
        {
            // Create UIAF Factory
            UIAF.UIAFactory factory = UIAF.UIAFactory.Instance;
            
            // add OM logger to DCM macro logging            
            factory.Loggers.Add(new ExternalLogger.MCFLogger(Utilities.Logger));

            // Get Console Macros
            this.consoleMacros = new Macros(factory).Console;            
        }

        /// <summary>
        /// Click on the indicated wonder bar section
        /// </summary>
        /// <param name="section">section button to click (use section enum)</param>
        public void ClickWonderBarButton(Section section)
        {
            UIAF.Console.ConsoleApp.ConsoleMode button; 

            switch  (section)
            {
               case Section.Administration:
                    button = UIAF.Console.ConsoleApp.ConsoleMode.Administration;
                    break;
               case Section.Library:
                    button = UIAF.Console.ConsoleApp.ConsoleMode.Library;
                    break;
               case Section.Operations:
                    button = UIAF.Console.ConsoleApp.ConsoleMode.Operations;
                    break;
               case Section.Reports:
                    button = UIAF.Console.ConsoleApp.ConsoleMode.Reports;
                    break;
               case Section.Settings:
                    button = UIAF.Console.ConsoleApp.ConsoleMode.Settings;
                    break;
                default :
                   throw new ArgumentOutOfRangeException("Wonderbar button out of range: " +section.ToString());
            }

            consoleMacros.WunderBarMacros.ClickOnWunderBarButton(button);
        }
	}
}
