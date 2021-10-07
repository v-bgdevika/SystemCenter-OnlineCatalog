//-------------------------------------------------------------------
// <copyright file="Constants.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <project>
//  System Center Console Framework
// </project>
// <summary>
//   General Constants.
// </summary>
// <history>
//   [mbickle] 13OCT07 Created
// </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console
{
    #region Using directives
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using Mom.Test.UI.Core.Common;
    #endregion

    /// <summary>
    /// Constant Variables.
    /// </summary>
    public sealed class ConsoleConstants
    {
        /// <summary>
        /// Timeout of 1 second.
        /// </summary>
        //public const int OneSecond = 1000; // 1 second

        /// <summary>
        /// Dr. Watson 2.0 Exe
        /// </summary>
        //public const string DW20Exe = "DW20.exe";

        /// <summary>
        /// Ampersand
        /// </summary>
        //public const string AmpersandValue = "&";

        /// <summary>
        /// The NT Event Source name for the .Net Runtime. 
        /// </summary>
        //public const string NTEventSourceDotNetRuntime = ".NET Runtime 2.0 Error Reporting";

        /// <summary>
        /// The NT Event log name for the Application log.
        /// </summary>
        //public const string NTEventLogNameApplication = "Application";

        /// <summary>
        /// Path Delimiter - \\
        /// </summary>
        //public const string PathDelimiter = "\\";

        /// <summary>
        /// Gets the logged on users Application folder.
        /// </summary>
        public static readonly string UsersAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        /// Multiple record values are expected. 
        /// </summary>
        //public const bool MultipleValues = true;

        /// <summary>
        /// A single record value is expected. 
        /// </summary>
        //public const bool SingleValue = false;

        /// <summary>
        /// Cache to hold a reference to a XDocument with a loaded Xml file
        /// </summary>
        private static XDocument cachedXmlDocument;

        /// <summary>
        /// Cache to hold reference to the XmlPath.
        /// </summary>
        private static string cachedXmlPath;

        /// <summary>
        /// Default WaitForReady timeout.
        /// </summary>
        private static int defaultWaitForReadyTimeout;

        /// <summary>
        /// Default Dialog search timeout.
        /// </summary>
        private static int defaultDialogTimeout;

        /// <summary>
        /// Default ContextMenu search timeout.
        /// </summary>
        private static int defaultContextMenuTimeout;

        /// <summary>
        /// Default Control search timeout.
        /// </summary>
        private static int defaultControlTimeout;

        /// <summary>
        /// Default App Startup timeout.
        /// </summary>
        private static int defaultAppStartupTimeout;

        /// <summary>
        /// Default WaitForReady Robustness Level
        /// </summary>
        private static RobustnessLevel defaultRobustnessLevel;

        private static string defaultManagementPackName;
        
        #region Constructor
        /// <summary>
        /// Private Constructor to fix FxCop error.
        /// </summary>
        private ConsoleConstants()
        {
        }
        #endregion

        /// -----------------------------------------------------------
        /// <summary>
        /// Gets or Sets the path to the Xml on this system.  Default
        /// looks in the same directory as the Assembly for file name
        /// of "ConsoleFramework.xml".
        /// </summary>
        /// <returns>Path to the Xml file.</returns>
        /// <history>
        ///   [mbickle] 2/3/2010 Created
        /// </history>
        /// -----------------------------------------------------------
        public static string XmlPath
        {
            get
            {
                if (null == cachedXmlPath)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    cachedXmlPath = fi.DirectoryName + "\\ConsoleFramework.xml";
                }

                return cachedXmlPath;
            }

            set
            {
                cachedXmlPath = value;
            }
        }

        /// <summary>
        /// Gets or Sets the DefaultWaitForTimeout value, default @ 60 seconds.
        /// </summary>
        public static int DefaultWaitForReadyTimeout
        {
            get
            {
                if (0 == defaultWaitForReadyTimeout)
                {
                    if (XmlDocument != null)
                    {
                        defaultWaitForReadyTimeout = GetConstantValue("DefaultWaitForReadyTimeout");
                    }

                    if (0 == defaultWaitForReadyTimeout)
                    {
                        defaultWaitForReadyTimeout = 60000;
                    }
                }

                Utilities.LogMessage(String.Format("DefaultWaitForReadyTimeout: {0}", defaultWaitForReadyTimeout));
                return defaultWaitForReadyTimeout;
            }

            set
            {
                defaultWaitForReadyTimeout = value;
            }
        }

        /// <summary>
        /// Gets or Sets the DefaultRobustnessLevel value, default 1.
        /// </summary>
        public static RobustnessLevel DefaultRobustnessLevel
        {
            get
            {
                if (0 == defaultRobustnessLevel)
                {
                    if (XmlDocument != null)
                    {
                        defaultRobustnessLevel = (RobustnessLevel)GetConstantValue("DefaultRobustnessLevel");
                    }

                    if (0 == defaultRobustnessLevel)
                    {
                        defaultRobustnessLevel = RobustnessLevel.Default;
                    }
                }

                Utilities.LogMessage(String.Format("DefaultRobustnessLevel: {0}", defaultRobustnessLevel));
                return defaultRobustnessLevel;
            }

            set
            {
                defaultRobustnessLevel = value;
            }
        }

        /// <summary>
        /// Gets or Sets the Default Dialog Search Timeout @ 30 seconds.
        /// </summary>
        public static int DefaultDialogTimeout
        {
            get
            {
                if (0 == defaultDialogTimeout)
                {
                    if (XmlDocument != null)
                    {
                        defaultDialogTimeout = GetConstantValue("DefaultDialogTimeout");
                    }

                    if (0 == defaultDialogTimeout)
                    {
                        defaultDialogTimeout = 30000;
                    }
                }

                Utilities.LogMessage(String.Format("DefaultDialogTimeout: {0}", defaultDialogTimeout));
                return defaultDialogTimeout;
            }

            set
            {
                defaultDialogTimeout = value;
            }
        }

        /// <summary>
        /// Gets or Sets the Default ContextMenu search timeout @ 15 seconds.
        /// </summary>
        public static int DefaultContextMenuTimeout
        {
            get
            {
                if (0 == defaultContextMenuTimeout)
                {
                    if (XmlDocument != null)
                    {
                        defaultContextMenuTimeout = GetConstantValue("DefaultContextMenuTimeout");
                    }

                    if (0 == defaultContextMenuTimeout)
                    {
                        defaultContextMenuTimeout = 30000;
                    }
                }

                Utilities.LogMessage(String.Format("DefaultContextMenuTimeout: {0}", defaultContextMenuTimeout));
                return defaultContextMenuTimeout;
            }

            set
            {
                defaultContextMenuTimeout = value;
            }
        }

        /// <summary>
        /// Gets or Sets the default Control search timeout @ 30 seconds.
        /// </summary>
        public static int DefaultControlTimeout
        {
            get
            {
                if (0 == defaultControlTimeout)
                {
                    if (XmlDocument != null)
                    {
                        defaultControlTimeout = GetConstantValue("DefaultControlTimeout");
                    }                                       

                    if (0 == defaultControlTimeout)
                    {
                        defaultControlTimeout = 30000;
                    }
                }

                Utilities.LogMessage(String.Format("DefaultControlTimeout: {0}", defaultControlTimeout));
                return defaultControlTimeout;
            }

            set
            {
                defaultControlTimeout = value;
            }
        }

        /// <summary>
        /// Gets or Sets the Default App Startup Timeout @ 600 seconds.
        /// </summary>
        public static int DefaultAppStartupTimeout
        {
            get
            {
                if (0 == defaultAppStartupTimeout)
                {
                    if (XmlDocument != null)
                    {
                        defaultAppStartupTimeout = GetConstantValue("DefaultAppStartupTimeout");
                    }

                    if (0 == defaultAppStartupTimeout)
                    {
                        defaultAppStartupTimeout = 600000;
                    }
                }

                Utilities.LogMessage(String.Format("DefaultAppStartupTimeout: {0}", defaultAppStartupTimeout));
                return defaultAppStartupTimeout;
            }

            set
            {
                defaultAppStartupTimeout = value;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to DefaultManagementPackName
        /// </summary>
        /// <history>
        /// </history>
        /// -----------------------------------------------------------------------------
        public static string DefaultManagementPackName
        {
            get
            {
                if (defaultManagementPackName == null)
                {
                    defaultManagementPackName = CoreManager.MomConsole.GetIntlStr(ManagementPackConstants.ResourceDefaultManagementPackName);
                }
                return defaultManagementPackName;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Gets access to the loaded XDocument
        /// </summary>
        /// <history>
        ///   [mbickle] 2/3/2010 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static XDocument XmlDocument
        {
            get
            {
                if (cachedXmlDocument == null)
                {
                    string xmlFile = XmlPath;

                    try
                    {
                        cachedXmlDocument = XDocument.Load(xmlFile);
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        // File doesn't exist, we'll ignore and move on to use internal defaults.
                    }
                }

                return cachedXmlDocument;
            }
        }

        /// <summary>
        /// Get the Constant Value from Xml Document
        /// </summary>
        /// <param name="value">Xml Name attribute.</param>
        /// <returns>Value</returns>
        private static int GetConstantValue(string value)
        {
            int timeout = 0;

            try
            {
                var obj = from c in XmlDocument.Descendants("Constant") where c.Attribute("Name").Value.Equals(value) select (int)c.Attribute("Value");
                timeout = obj.First();
            }
            catch (Exception ex)
            {
                Utilities.LogMessage(String.Format("GetConstantValue: Exception {0}", ex));
                Utilities.LogMessage(String.Format("GetConstantValue: Could not retreive expected value: {0}", value));
            }

            return timeout;
        }
    }
}
