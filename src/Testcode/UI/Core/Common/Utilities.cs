//-------------------------------------------------------------------
// <copyright file="Utilities.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains utility classes for the MOMX UI automated tests
// </summary>
// 
//  <history>
//  [mbickle] 01JAN05:  Created
//  [ravipr]  26AUG05:  Added ImporManagementPack method
//  [barryw]  16SEP05:  Fix to GetCountOfRecentNTEvent.
//  [kellymor]19SEP05:  Added methods to create and close a Maui 
//                      TextLog
//  [ravipr]  24SEP05:  Added GetViewName method
//  [ravipr]  27SEP05:  Added GetManagementPack method
//  [ruhim]   29SEP05:  Added GetUnitMonitorType method
//  [faizalk] 27OCT05:  Added GetEntityName and GetEntityPath methods
//  [ruhim]   01NOV05:  Added GetMonitorName method  
//  [ruhim]   14NOV05:  Added GetOperationalStateName method  
//  [ruhim]   16NOV05:  Added GetMonitoringRuleName method  
//  [faizalk] 16NOV05:  Added more overloads for GetEntityName method
//  [ruhim]   17NOV05:  Added GetMonitoringTemplateName method
//  [ruhim]   21NOV05:  Updating GetUnitMonitorTypeName,GetManagementPackName
//                      GetMonitorName,GetOperationalState 
//                      to have a single return as per code review 
//  [ruhim]   22NOV05:  Added GetUserRoleProfileName method   
//  [faizalk] 23NOV05:  Added ConnectToManagementServer methods and refactored code
//  [faizalk] 01DEC05:  Added UserDnsDomainName and UserDomainName properties
//  [ruhim]   25Jan06:  Updated GetMonitorName and GetOperationalState methods for SDK changes  
//  [ruhim]   25Jan06:  Updated GetManagementPack and GetDisplayNameFromClass method for SDK changes  
//  [ruhim]   25Jan06:  Updated ImportManagementPack method for SDK changes
//  [ruhim]   06FEB06:  Added GetManagementPackViews, GetManagementPackTasks, 
//                      GetManagementPackClasses methods 
//  [faizalk] 02MAY06:  Make ExcludedCharacters static  
//  [faizalk] 18MAY06:  Added checks for CPU usage and MEM usage
//  [ruhim]   21Jun06:  Added GetMonitorFolderHierarchy method   
//  [barryli] 26FEB07:  Added GetManagementPackClassDisplayName method
//  [barryli] 10AUG07:  Modified DataBaseServerName to use MOM topology  
//  [kellymor]07MAY08:  Modified MomServerName property to use a new
//                      method that should return a name regardless
//                      if the current framework context is valid, as
//                      long as the Topology object has been initialized
//                      with data.  The code will still try the registry
//                      key if Topology returns no data for Root SDK
//  [a-omkasi]12MAY08:  Added FixForCoverBuild method   
//  [kellymor]14AUG08:  Added RemoveAcceleratorKeys to remove hot-key
//                      characters from resource strings, just the 
//                      ampersand character.
//  [sunsingh] 4SEPT08:  Added GetManagementPackModuleTypeName to get 
//                      MOduleType Display Name corresponding to a supplied ModuleTypeGuid. 
//  [sunsingh] 4SEPT08: Added method GetReportDisplayName
//                      Used to return MOduleType Display Name corresponding to a supplied reportGuid Guid. 
//  [sunsingh] 4SEPT08: Added method GetMonitoringReportStringFromGuid(Guid reportGuid, Guid reportStringGuid)
//                     Used to return report string Display Name corresponding to a supplied reportGuid and reportStringGuid. 
//  [sunsingh] 4SEPT08: Added method GetManagementPackName(Guid guid)
//                      Used to return MP Display Name corresponding to a supplied MP Guid. 
//  [a-joelj]   25MAR09 Added GetMonitoringRuleAlertName() method to get alert name for rule
//  [v-yoz]     1April09 Added GetManagementPackMonitorDisplayName() and GetManagementPackStringResourceDisplayName().
//  [a-joelj]   14APR09 Added GetEventLogDisplayName() method to fetch localized EventLog DisplayNames
//  [v-chunya]  11MAY09 Added UserName property.
//  [v-waltli]  19JUN09 Added method GetManagementPackMonitorDisplayName
//                      Used to return the displayName for a given monitor in the given MP
//  [nathd]     14AUG09 Adding characters '\t', '\uD840', '\uDD5C', '\uDD5B' and '\uDD7B' to the excludedCharacters array.
//  [v-jinlil]  04DEC09 Added StartService(), StopService(),RemoteConnectValidate(),GetAdministratorUserAndPassword()
//  [v-brucec] 22DEC09 Update StartService and StopService, retry if fail.
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Common
{
    #region Using directives
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using System.Diagnostics;
    using System.ServiceProcess;
    using System.Xml;
    using System.Security.Permissions;
    using System.Reflection;
    using System.Threading;
    using System.Management;
    //using System.Windows;
    //using System.Windows.Forms;
    using System.Linq;
    using Infra.Frmwrk;
    using System.Globalization;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.TestLog;
    using Maui.Core.WinControls;
    using Microsoft.EnterpriseManagement;
    using SDK = Microsoft.EnterpriseManagement;
    using Microsoft.EnterpriseManagement.Common;
    using Microsoft.EnterpriseManagement.Configuration;
    using Microsoft.EnterpriseManagement.Configuration.IO;
    using Microsoft.EnterpriseManagement.Administration;
    using Microsoft.EnterpriseManagement.Mom.Internal;
    using Microsoft.EnterpriseManagement.Security;
    using Microsoft.EnterpriseManagement.Packaging;
    using Microsoft.EnterpriseManagement.Presentation.DataAccess;
    using Microsoft.EnterpriseManagement.Monitoring;
    using Microsoft.EnterpriseManagement.Monitoring.DataProviders;
    using Microsoft.EnterpriseManagement.Warehouse;
    using Mom.Test.Infrastructure;
    using Microsoft.EnterpriseManagement.Test.BaseCommon;

    using Microsoft.EnterpriseManagement.Test.ScCommon;
    using Microsoft.EnterpriseManagement.Test.ScCommon.Topology;
    
    #endregion



    #region Common Utilities Class  
    /// ------------------------------------------------------------------
    /// <summary>
    /// Misc common Utility methods. 
    /// </summary>
    /// <history>
    ///     [mbickle] 26MAR03   Created
    ///     [kellymor]19SEP05   Added methods to create and close a Maui 
    ///                         TextLog
    ///     [a-joelj] 5DEC08    Added Japanese letter '\xFF71' into the ExcludedCharacters array 
    ///     [a-joelj] 10DEC08   Added Japanese dash '\x30FC' into the ExcludedCharacters array that was causing invalid path
    ///                         delimiter detection
    ///     [a-joelj] 12DEC08   Added 5 more chars to excludedCharacters that were being changed to other chars
    ///     [a-joelj] 15DEC08   Added '\'' and '-' to excludedCharacters array that were used in User Roles
    ///     [joelj]   02MAR11   Updated GetGuidFromDB to return Guid.Empty if the query result is null, rather than hitting
    ///                         a NullReferenceException trying to do ToString on a null query result object
    /// </history>
    /// ------------------------------------------------------------------
    public sealed class Utilities
    {
        #region "Constants"

        /// <summary>
        /// Command Timeout Value for SQL Methods.
        /// </summary>
        private const int SqlCommandTimeout = 240; // Timeout for command object

        /// <summary>
        /// Connection Timeout Value for SQL Connections
        /// </summary>
        private const int SqlConnectionTimeout = 120; // Timeout for connection object

        /// <summary>
        /// An array of characters to exclude from Random String generation.
        /// </summary>
        private static readonly char[] excludedCharacters = { '\'', '-', '/', ',', '\\', '#', '(', ')', '"', '^', '%', '&', '<', '>', '\xFF71', '\x30FC', '\xFF8A', '\xFF78', '\xFF76', '\xFF80', '\xFF85', '\xFF9D', '\t', '\uD840', '\uDD5C', '\uDD5B', '\uDD7B' };

        //static IntPtr HWND_BROADCAST = new IntPtr(0xffff);
        //static IntPtr WM_SETTINGCHANGE = new IntPtr(0x001A);
        
        /// <summary>
        /// Waiting time for every iteration to log message automatically
        /// </summary>
        private const int WaitingTimeForAutoLogMessageThread = 15; //15 minutes
        #endregion // "Constants"

        #region "Members"

        /// <summary>
        /// SQL Connection handle.
        /// </summary>
        private static SqlConnection sqlConnection;

        /// <summary>
        /// Cached OS info
        /// </summary>
        private static System.OperatingSystem cachedCurrentOSInfo; // Cached OS Info.

        /// <summary>
        /// Cached Database Server Name
        /// </summary>
        private static string cachedDatabaseServerName;

        /// <summary>
        /// Cached Database Name
        /// </summary>
        private static string cachedDatabaseName;

        /// <summary>
        /// Cached Mom Path
        /// </summary>
        private static string cachedMomPath;

        /// <summary>
        /// Cached MomConsole Path
        /// </summary>
        private static string cachedMomPathConsole;

        /// <summary>
        /// Cached AuthoringConsole Path
        /// </summary>
        private static string cachedAuthoringConsolePath;

        /// <summary>
        /// Cached MCF Context reference
        /// </summary>
        [Obsolete("Use Mcf.frameworkContext")]
        private static IContext frameworkContext; // MCF Context reference.

        /// <summary>
        /// Maui TextLog that contains trace information
        /// </summary>
        private static Maui.TestLog.Logs.TextLog traceLog;

        /// <summary>
        /// Cached MOMServer Name
        /// </summary>
        private static string cachedMomServerName;

        /// <summary>
        /// Cached UserDNSDomainName
        /// </summary>
        private static string cachedUserDnsDomainName;

        /// <summary>
        /// Cached UserDomainName
        /// </summary>
        private static string cachedUserDomainName;

        /// <summary>
        /// Cached UserName
        /// </summary>
        private static string cachedUserName;

        /// <summary>
        /// Cached CurrentCpuUsage
        /// </summary>
        private static PerformanceCounter cachedCurrentCpuUsage;

        /// <summary>
        /// Cached AvailbaleRAM
        /// </summary>
        private static PerformanceCounter cachedAvailableRAM;
        
        /// <summary>
        /// Cached CurrentCpuUsage Sql Server
        /// </summary>
        private static PerformanceCounter cachedCurrentCpuUsageSqlServer;

        /// <summary>
        /// Cached MemoryUsage Sql Server
        /// </summary>
        private static PerformanceCounter cachedCurrentMemoryUsageSqlServer;

        /// <summary>
        /// Cached CurrentCpuUsage Sdk Service
        /// </summary>
        private static PerformanceCounter cachedCurrentCpuUsageSdkService;

        /// <summary>
        /// Cached MemoryUsage Sdk Service
        /// </summary>
        private static PerformanceCounter cachedCurrentMemoryUsageSdkService;

        /// <summary>
        /// Cached CurrentCpuUsage Health Service
        /// </summary>
        private static PerformanceCounter cachedCurrentCpuUsageHealthService;
        
        /// <summary>
        /// Cached MemoryUsage Health Service
        /// </summary>    
        private static PerformanceCounter cachedCurrentMemoryUsageHealthService;

        /// <summary>
        /// Cached CurrentCpuUsage IIS
        /// </summary>
        private static PerformanceCounter cachedCurrentCpuUsageIIS;

        /// <summary>
        /// Cached MemoryUsage IIS
        /// </summary>
        private static PerformanceCounter   cachedCurrentMemoryUsageIIS;

        /// <summary>
        /// Cached CurrentCpuUsage Monitoring Host
        /// </summary>
        private static PerformanceCounter cachedCurrentCpuUsageMonitoringHost;

        /// <summary>
        /// Cached MemoryUsage Monitoring Host
        /// </summary>
        private static PerformanceCounter cachedCurrentMemoryUsageMonitoringHost;

        /// <summary>
        /// Cached CurrentCpuUsage DesktopConsole
        /// </summary>
        private static PerformanceCounter cachedCurrentCpuUsageDesktopConsole;

        /// <summary>
        /// Cached MemoryUsage Desktop Console
        /// </summary>
        private static PerformanceCounter cachedCurrentMemoryUsageDesktopConsole;

        /// <summary>
        /// Cached CurrentCpuUsage Web Console
        /// </summary>
        private static PerformanceCounter cachedCurrentCpuUsageWebConsole;

        /// <summary>
        /// Cached MemoryUsage Web Console
        /// </summary>
        private static PerformanceCounter cachedCurrentMemoryUsageWebConsole;

        /// <summary>
        /// Initial seed, used for random strings        
        /// </summary>
        private static int seed;

        /// <summary>
        /// timeout for SQL connection attempt
        /// </summary>
        private static string m_SQLConnectionTimeout = "120";

        /// <summary>
        /// SQL connection
        /// </summary>
        private static SqlConnection m_SQLDWConnection = null;

        /// <summary>
        /// SQL connection
        /// </summary>
        public static string m_ManagementServerName = string.Empty;


        /// <summary>
        /// private static string to hold Stored Proc
        /// </summary>
        private static string m_SP = String.Empty;

        /// <summary>
        /// private static string to hold Column Filter
        /// </summary>
        private static List<string> m_ColumnFilter =
            new List<string>();

        /// <summary>
        /// private static int to hold timeout number
        /// </summary>
        private static int m_TimeOut;

        /// <summary>
        /// private static int to hold aggregation means
        /// </summary>
        private static int m_AggregationMeans;

        /// <summary>
        /// private static bool to hold if perf data insertion
        /// </summary>
        private static bool m_PerfDataInsertion;

        /// <summary>
        /// private static DateTime to hold start time
        /// </summary>
        private static DateTime m_StartTime;

        /// <summary>
        /// private static datetime to hold end time
        /// </summary>
        private static DateTime m_EndTime;

        /// <summary>
        /// Root XML name
        /// </summary>
        private static string RootXName = "Data";

        /// <summary>
        /// Object list XML name
        /// </summary>
        private static string SLAListXName = "ServiceLevelAgreements";

        /// <summary>
        /// Object XML name
        /// </summary>
        private static string SLAXName = "ServiceLevelAgreement";

        /// <summary>
        /// Management Group Guid 
        /// </summary>
        private static string ManagementGroupGuidXName = "ManagementGroupGuid";

        /// <summary>
        /// SLA Guid
        /// </summary>
        private static string SlaGuidXName = "ServiceLevelAgreementGuid";

        /// <summary>
        /// THis string is returning when data has no any items
        /// </summary>
        private static string EmptyXml = " ";

        /// <summary>
        /// DB instance name
        /// </summary>
        private static string timeInterval =
            "<Interval>" +
            " <Title>TemporaryTitle</Title>" +
            " <Start>" +
            " <Base>Present</Base>" +
            " <Offset Type='Day'>-7</Offset>" +
            " </Start>" +
            " <End>" +
            " <Base>Present</Base>" +
            " <Offset Type='None'>0</Offset>" +
            " </End>" +
            "</Interval>";

        /// <summary>
        /// DB instance name
        /// </summary>
        public static string m_DBInstanceName = null;

        /// <summary>
        /// DB name
        /// </summary>
        public static string m_DBName = null;

        /// <summary>
        /// windows Secure Data
        /// </summary>
        private static WindowsCredentialSecureData windowsSecureData;

        /// <summary>
        /// This Guid is used for task display name
        /// </summary>
        public static string GuidUITaskWebConsoleMP;

        /// <summary>
        /// Cached Web Console Web Server Name
        /// </summary>
        private static string cachedWebConsoleWebServerName;

        /// <summary>
        /// Memory consumption (private bytes) performance counter - Desktop Console
        /// </summary>
        private static PerformanceCounter desktopConsolePrivateBytesCounter = null;

        /// <summary>
        /// Percent processor time performance counter - Desktop Console
        /// </summary>
        private static PerformanceCounter desktopConsolePercentProcessorTimeCounter = null;

        /// <summary>
        /// Memory consumption (working set) performance counter - Total
        /// </summary>
        private static PerformanceCounter totalWorkingSetCounter = null;

        /// <summary>
        /// Percent processor time performance counter - Total
        /// </summary>
        private static PerformanceCounter totalPercentProcessorTimeCounter = null;

        /// <summary>
        /// Thread will write log message in main log file every iteration.
        /// </summary>
        internal static Thread autoLogMessageThread = null;
        #endregion // "Members"

        #region Enums
        /// ------------------------------------------------------------------
        /// <summary>
        /// Data Aggregation Type
        /// </summary>
        /// ------------------------------------------------------------------
        public enum dataAggregationType { hourly = 0, daily = 1 };

        /// ------------------------------------------------------------------
        /// <summary>
        /// SLA Data Aggregation Type
        /// </summary>
        /// ------------------------------------------------------------------
        public enum slaDataAggregationType { hourly = 20, daily = 30 };

        /// ------------------------------------------------------------------
        /// <summary>
        /// Scale Out Multiple
        /// </summary>
        /// ------------------------------------------------------------------
        public enum scaleOutMultiple { two = 2, three = 3 };

        /// ------------------------------------------------------------------
        /// <summary>
        /// Param Set Type
        /// </summary>
        /// ------------------------------------------------------------------
        public enum paramSetType { valid, invalid, omitted, additional, invalidtype, none };

        /// ------------------------------------------------------------------
        /// <summary>
        /// Data Shape
        /// </summary>
        /// ------------------------------------------------------------------
        public enum dataShape { flat, spiked, bellcurve };
           
        /// <summary>
        /// Enum to get AccountType
        /// </summary>
        public enum AccountType
        {
            /// <summary>
            /// Windows
            /// </summary>
            Windows,
            /// <summary>
            /// Community String
            /// </summary>
            CommunityString,
            /// <summary>
            /// Basic Authentication
            /// </summary>
            BasicAuthentication,
            /// <summary>
            /// Simple Authentication
            /// </summary>
            SimpleAuthentication,
            /// <summary>
            /// Digest Authentication
            /// </summary>
            DigestAuthentication,
            /// <summary>
            /// Binary Authentication
            /// </summary>
            BinaryAuthentication,                       
            /// <summary>
            /// Action Account
            /// </summary>
            ActionAccount,
            /// <summary>
            /// SNMPv3 Account
            /// </summary>
            SNMPv3Account
        };

        /// <summary>
        /// Enum to get AccountType
        /// </summary>
        public enum DistributionType 
        {
            /// <summary>
            /// Default distribution option for RunAs Account
            /// </summary>
            Default,

            /// <summary>
            /// Less-secure distribution option for RunAs Account
            /// </summary>
            LessSecure,

            /// <summary>
            /// More-secure distribution option for RunAs Account
            /// </summary>
            MoreSecure,

            /// <summary>
            /// Distribution option for RunAs Account not specified
            /// </summary>
            NotSpecified,       
        };        

        /// ------------------------------------------------------------------
        /// <summary>
        /// Database
        /// </summary>
        /// ------------------------------------------------------------------
        public enum database { OpsDB, DW };

        #endregion // "Enums"

        #region Constructor
        /// <summary>
        /// Private Utilities Constructor
        /// </summary>
        private Utilities()
        {
            // do nothing
        }
        #endregion

        #region "Properties"
        /// ------------------------------------------------------------------
        /// <summary>
        /// Property to return a System.OperatingSystem object with the current OS information
        /// </summary>
        /// <history>
        ///     [mbickle] 01APR04 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static System.OperatingSystem CurrentOSInfo
        {
            get
            {
                if (cachedCurrentOSInfo == null)
                {
                    cachedCurrentOSInfo = System.Environment.OSVersion;
                }

                return cachedCurrentOSInfo;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// gets CPU PerformanceCounter percentage
        /// </summary>
        /// <returns>cpu usage percentage</returns>
        /// <history>
        ///     [faizalk] 18MAY2006: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static float CurrentCpuUsage
        {
            get
            {
                if (cachedCurrentCpuUsage == null)
                {
                    cachedCurrentCpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);

                    // the very first call returns zero so let's wait and actually return something meaningful
                    cachedCurrentCpuUsage.NextValue();
                    Sleeper.Delay(500);
                }

                return cachedCurrentCpuUsage.NextValue();
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// gets Memory PerformanceCounter MBs
        /// </summary>
        /// <returns>mem usage mbytes</returns>
        /// <history>
        ///     [faizalk] 18MAY2006: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static float AvailableRAM
        {
            get
            {
                if (cachedAvailableRAM == null)
                {
                    cachedAvailableRAM = new PerformanceCounter("Memory", "Available MBytes", true);
                }

                return cachedAvailableRAM.NextValue();
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets CPU PerformanceCounter percentage for the sqlservr.exe processes.
        /// </summary>
        /// <returns>cpu usage percentage</returns>
        /// <history>
        ///     [nathd] 27OCT2011: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static float CurrentCpuUsageSqlServer
        {
            get
            {
                try
                {
                    if (cachedCurrentCpuUsageSqlServer == null)
                    {
                        cachedCurrentCpuUsageSqlServer = new PerformanceCounter("Process", "% Processor Time", Constants.SqlServerExe.Replace(".exe" , String.Empty), true);

                        // the very first call returns zero so let's wait and actually return something meaningful
                        cachedCurrentCpuUsageSqlServer.NextValue();
                        Sleeper.Delay(500);
                    }

                    return cachedCurrentCpuUsageSqlServer.NextValue();
                }
                catch (System.InvalidOperationException ex)
                {
                    LogMessage(String.Format("Utilities.CurrentCpuUsageSqlServer :: {0}", ex.Message.ToString()));
                    return 0;
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets Memory Usage (Working Set - Private) for the sqlservr.exe processes.
        /// </summary>
        /// <returns>memory usage</returns>
        /// <history>
        ///     [nathd] 27OCT2011: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static float CurrentMemoryUsageSqlServer
        {
            get
            {
                try
                {
                    if (cachedCurrentMemoryUsageSqlServer == null)
                    {
                        cachedCurrentMemoryUsageSqlServer = new PerformanceCounter("Process", "Working Set - Private", Constants.SqlServerExe.Replace(".exe", String.Empty), true);

                        // the very first call returns zero so let's wait and actually return something meaningful
                        cachedCurrentMemoryUsageSqlServer.NextValue();
                        Sleeper.Delay(500);
                    }

                    return cachedCurrentMemoryUsageSqlServer.NextValue();
                }
                catch (System.InvalidOperationException ex)
                {
                    LogMessage(String.Format("Utilities.CurrentMemoryUsageSqlServer :: {0}", ex.Message.ToString()));
                    return 0;
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets CPU PerformanceCounter percentage for the Microsoft.Mom.Sdk.Service.exe process.
        /// </summary>
        /// <returns>cpu usage percentage</returns>
        /// <history>
        ///     [nathd] 27OCT2011: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static float CurrentCpuUsageSdkService
        {
            get
            {
                try
                {
                    if (cachedCurrentCpuUsageSdkService == null)
                    {
                        cachedCurrentCpuUsageSdkService = new PerformanceCounter("Process", "% Processor Time", Constants.SdkSerivceHostExe.Replace(".exe", String.Empty), true);

                        // the very first call returns zero so let's wait and actually return something meaningful
                        cachedCurrentCpuUsageSdkService.NextValue();
                        Sleeper.Delay(500);
                    }

                    return cachedCurrentCpuUsageSdkService.NextValue();
                }
                catch (System.InvalidOperationException ex)
                {
                    LogMessage(String.Format("Utilities.CurrentCpuUsageSdkService :: {0}", ex.Message.ToString()));
                    return 0;
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets Memory Usage (Working Set - Private) for the Microsoft.Mom.Sdk.Service.exe processes.
        /// </summary>
        /// <returns>memory usage</returns>
        /// <history>
        ///     [nathd] 27OCT2011: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static float CurrentMemoryUsageSdkService
        {
            get
            {
                try
                {
                    if (cachedCurrentMemoryUsageSdkService == null)
                    {
                        cachedCurrentMemoryUsageSdkService = new PerformanceCounter("Process", "Working Set - Private", Constants.SdkSerivceHostExe.Replace(".exe", String.Empty), true);

                        // the very first call returns zero so let's wait and actually return something meaningful
                        cachedCurrentMemoryUsageSdkService.NextValue();
                        Sleeper.Delay(500);
                    }

                    return cachedCurrentMemoryUsageSdkService.NextValue();
                }
                catch (System.InvalidOperationException ex)
                {
                    LogMessage(String.Format("Utilities.CurrentMemoryUsageSdkService :: {0}", ex.Message.ToString()));
                    return 0;
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets CPU PerformanceCounter percentage for the HealthService.exe processes.
        /// </summary>
        /// <returns>cpu usage percentage</returns>
        /// <history>
        ///     [nathd] 27OCT2011: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static float CurrentCpuUsageHealthService
        {
            get
            {
                try
                {
                    if (cachedCurrentCpuUsageHealthService == null)
                    {
                        cachedCurrentCpuUsageHealthService = new PerformanceCounter("Process", "% Processor Time", Constants.HealthServiceExe.Replace(".exe", String.Empty), true);

                        // the very first call returns zero so let's wait and actually return something meaningful
                        cachedCurrentCpuUsageHealthService.NextValue();
                        Sleeper.Delay(500);
                    }

                    return cachedCurrentCpuUsageHealthService.NextValue();
                }
                catch (System.InvalidOperationException ex)
                {
                    LogMessage(String.Format("Utilities.CurrentCpuUsageHealthService :: {0}", ex.Message.ToString()));
                    return 0;
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets Memory Usage (Working Set - Private) for the HealthService.exe processes.
        /// </summary>
        /// <returns>memory usage</returns>
        /// <history>
        ///     [nathd] 27OCT2011: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static float CurrentMemoryUsageHealthService
        {
            get
            {
                try
                {
                    if (cachedCurrentMemoryUsageHealthService == null)
                    {
                        cachedCurrentMemoryUsageHealthService = new PerformanceCounter("Process", "Working Set - Private", Constants.HealthServiceExe.Replace(".exe", String.Empty), true);

                        // the very first call returns zero so let's wait and actually return something meaningful
                        cachedCurrentMemoryUsageHealthService.NextValue();
                        Sleeper.Delay(500);
                    }

                    return cachedCurrentMemoryUsageHealthService.NextValue();
                }
                catch (System.InvalidOperationException ex)
                {
                    LogMessage(String.Format("Utilities.CurrentMemoryUsageHealthService :: {0}", ex.Message.ToString()));
                    return 0;
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets CPU PerformanceCounter percentage for the w3wp.exe processes.
        /// </summary>
        /// <returns>cpu usage percentage</returns>
        /// <history>
        ///     [nathd] 27OCT2011: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static float CurrentCpuUsageIIS
        {
            get
            {
                try
                {
                    if (cachedCurrentCpuUsageIIS == null)
                    {
                        cachedCurrentCpuUsageIIS = new PerformanceCounter("Process", "% Processor Time", Constants.W3WpExe.Replace(".exe", String.Empty), Utilities.WebConsoleWebServerName);

                        // the very first call returns zero so let's wait and actually return something meaningful
                        cachedCurrentCpuUsageIIS.NextValue();
                        Sleeper.Delay(500);
                    }

                    return cachedCurrentCpuUsageIIS.NextValue();
                }
                catch (System.InvalidOperationException ex)
                {
                    LogMessage(String.Format("Utilities.CurrentCpuUsageIIS :: {0}", ex.Message.ToString()));
                    return 0;
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets Memory Usage (Working Set - Private) for the w3wp.exe processes.
        /// </summary>
        /// <returns>memory usage</returns>
        /// <history>
        ///     [nathd] 27OCT2011: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static float CurrentMemoryUsageIIS
        {
            get
            {
                try
                {
                    if (cachedCurrentMemoryUsageIIS == null)
                    {
                        cachedCurrentMemoryUsageIIS = new PerformanceCounter("Process", "Working Set - Private", Constants.W3WpExe.Replace(".exe", String.Empty), Utilities.WebConsoleWebServerName);

                        // the very first call returns zero so let's wait and actually return something meaningful
                        cachedCurrentMemoryUsageIIS.NextValue();
                        Sleeper.Delay(500);
                    }

                    return cachedCurrentMemoryUsageIIS.NextValue();
                }
                catch (System.InvalidOperationException ex)
                {
                    LogMessage(String.Format("Utilities.CurrentMemoryUsageIIS :: {0}", ex.Message.ToString()));
                    return 0;
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets CPU PerformanceCounter percentage for the MonitoringHost.exe processes.
        /// </summary>
        /// <returns>cpu usage percentage</returns>
        /// <history>
        ///     [nathd] 27OCT2011: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static float CurrentCpuUsageMonitoringHost
        {
            get
            {
                try
                {
                    if (cachedCurrentCpuUsageMonitoringHost == null)
                    {
                        cachedCurrentCpuUsageMonitoringHost = new PerformanceCounter("Process", "% Processor Time", Constants.MonitoringHostExe.Replace(".exe", String.Empty), true);

                        // the very first call returns zero so let's wait and actually return something meaningful
                        cachedCurrentCpuUsageMonitoringHost.NextValue();
                        Sleeper.Delay(500);
                    }

                    return cachedCurrentCpuUsageMonitoringHost.NextValue();
                }
                catch (System.InvalidOperationException ex)
                {
                    LogMessage(String.Format("Utilities.CurrentCpuUsageMonitoringHost :: {0}", ex.Message.ToString()));
                    return 0;
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets Memory Usage (Working Set - Private) for the MonitoringHost.exe processes.
        /// </summary>
        /// <returns>memory usage</returns>
        /// <history>
        ///     [nathd] 27OCT2011: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static float CurrentMemoryUsageMonitoringHost
        {
            get
            {
                try
                {
                    if (cachedCurrentMemoryUsageMonitoringHost == null)
                    {
                        cachedCurrentMemoryUsageMonitoringHost = new PerformanceCounter("Process", "Working Set - Private", Constants.MonitoringHostExe.Replace(".exe", String.Empty), true);

                        // the very first call returns zero so let's wait and actually return something meaningful
                        cachedCurrentMemoryUsageMonitoringHost.NextValue();
                        Sleeper.Delay(500);
                    }

                    return cachedCurrentMemoryUsageMonitoringHost.NextValue();
                }
                catch (System.InvalidOperationException ex)
                {
                    LogMessage(String.Format("Utilities.CurrentMemoryUsageMonitoringHost :: {0}", ex.Message.ToString()));
                    return 0;
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets CPU PerformanceCounter percentage for the DesktopConsole processes.
        /// </summary>
        /// <returns>cpu usage percentage</returns>
        /// <history>
        ///     [nathd] 27OCT2011: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static float CurrentCpuUsageDesktopConsole
        {
            get
            {
                try
                {
                    if (cachedCurrentCpuUsageDesktopConsole == null)
                    {
                        cachedCurrentCpuUsageDesktopConsole = new PerformanceCounter("Process", "% Processor Time", Constants.MomConsoleExe.Replace(".exe", String.Empty), true);

                        // the very first call returns zero so let's wait and actually return something meaningful
                        cachedCurrentCpuUsageDesktopConsole.NextValue();
                        Sleeper.Delay(500);
                    }

                    return cachedCurrentCpuUsageDesktopConsole.NextValue();
                }
                catch (System.InvalidOperationException ex)
                {
                    LogMessage(String.Format("Utilities.CurrentCpuUsageDesktopConsole :: {0}", ex.Message.ToString()));
                    return 0;
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets Memory Usage (Working Set - Private) for the Desktop Console processes.
        /// </summary>
        /// <returns>memory usage</returns>
        /// <history>
        ///     [nathd] 27OCT2011: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static float CurrentMemoryUsageDesktopConsole
        {
            get
            {
                try
                {
                    if (cachedCurrentMemoryUsageDesktopConsole == null)
                    {
                        cachedCurrentMemoryUsageDesktopConsole = new PerformanceCounter("Process", "Working Set - Private", Constants.MomConsoleExe.Replace(".exe", String.Empty), true);

                        // the very first call returns zero so let's wait and actually return something meaningful
                        cachedCurrentMemoryUsageDesktopConsole.NextValue();
                        Sleeper.Delay(500);
                    }

                    return cachedCurrentMemoryUsageDesktopConsole.NextValue();
                }
                catch (System.InvalidOperationException ex)
                {
                    LogMessage(String.Format("Utilities.CurrentMemoryUsageDesktopConsole :: {0}", ex.Message.ToString()));
                    return 0;
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets CPU PerformanceCounter percentage for the Web Console processes.
        /// </summary>
        /// <returns>cpu usage percentage</returns>
        /// <history>
        ///     [nathd] 27OCT2011: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static float CurrentCpuUsageWebConsole
        {
            get
            {
                try
                {
                    if (cachedCurrentCpuUsageWebConsole == null)
                    {
                        cachedCurrentCpuUsageWebConsole = new PerformanceCounter("Process", "% Processor Time", Constants.InternetExplorerExe.Replace(".exe", String.Empty), true);

                        // the very first call returns zero so let's wait and actually return something meaningful
                        cachedCurrentCpuUsageWebConsole.NextValue();
                        Sleeper.Delay(500);
                    }

                    return cachedCurrentCpuUsageWebConsole.NextValue();
                }
                catch (System.InvalidOperationException ex)
                {
                    LogMessage(String.Format("Utilities.CurrentCpuUsageWebConsole :: {0}", ex.Message.ToString()));
                    return 0;
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets Memory Usage (Working Set - Private) for the Web Console processes.
        /// </summary>
        /// <returns>memory usage</returns>
        /// <history>
        ///     [nathd] 27OCT2011: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static float CurrentMemoryUsageWebConsole
        {
            get
            {
                try
                {
                    if (cachedCurrentMemoryUsageWebConsole == null)
                    {
                        cachedCurrentMemoryUsageWebConsole = new PerformanceCounter("Process", "Working Set - Private", Constants.InternetExplorerExe.Replace(".exe", String.Empty), true);

                        // the very first call returns zero so let's wait and actually return something meaningful
                        cachedCurrentMemoryUsageWebConsole.NextValue();
                        Sleeper.Delay(500);
                    }

                    return cachedCurrentMemoryUsageWebConsole.NextValue();
                }
                catch (System.InvalidOperationException ex)
                {
                    LogMessage(String.Format("Utilities.CurrentMemoryUsageWebConsole :: {0}", ex.Message.ToString()));
                    return 0;
                }
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Property for MCF Context
        /// </summary>
        /// <history>
        ///     [mbickle] 18NOV03 Created
        /// </history>
        /// ------------------------------------------------------------------
        [Obsolete("Use Mcf.FrameworkContext")]
        public static IContext FrameworkContext
        {
            get
            {
                return frameworkContext;
            }

            set
            {
                frameworkContext = value;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Property for getting Mom Installed directory
        /// </summary>
        /// <history>
        ///     [ravipr] 28AUG05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string MomPath
        {
            get
            {
                if (cachedMomPath == null)
                {
                    cachedMomPath = Registry.GetValue(
                        RegistryHive.Win32LocalMachine,
                        Constants.SetupRegistryPath,
                        Constants.InstallDirectoryRegistryKey);
                }

                return cachedMomPath;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Property for getting Mom Console Installed directory
        /// </summary>
        /// <history>
        ///     
        /// </history>
        /// ------------------------------------------------------------------
        public static string MomPathConsole
        {
            get
            {
                if (cachedMomPathConsole == null)
                {
                    cachedMomPathConsole = Registry.GetValue(
                        RegistryHive.Win32LocalMachine,
                        Constants.SetupRegistryPathConsole,
                        Constants.InstallDirectoryRegistryKey);
                }

                return cachedMomPathConsole;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Property for getting Mom Installed directory
        /// </summary>
        /// <history>
        ///     [lucyra] 15APR08 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string AuthoringConsolePath
        {
            get
            {
                if (cachedAuthoringConsolePath == null)
                {
                    cachedAuthoringConsolePath = Registry.GetValue(
                        RegistryHive.Win32LocalMachine,
                        Constants.SetupRegistryACPath,
                        Constants.InstallDirectoryRegistryKey);
                }

                return cachedAuthoringConsolePath;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Property for MOM DB Server Name
        /// </summary>
        /// <history>
        ///     [mbickle] 13JUL05 Created
        ///     [barryli] 10AUG07 Update to use MOM Test Topology 
        /// </history>
        /// ------------------------------------------------------------------
        public static string DatabaseServerName
        {
            get
            {
                if (cachedDatabaseServerName == null)
                {

                    try
                    {
                        if (Mcf.FrameworkContext != null)
                        {
                            MomDiscovery myMomDiscovery =
                                TopologyHelper.TestTopology;

                            if (myMomDiscovery == null)
                            {
                                throw new NullReferenceException("Utilities.DatabaseServerName:: MomDiscovery returned null!");
                            }

                            cachedDatabaseServerName = myMomDiscovery.DB;
                        }
                        else
                        {
                            throw new NullReferenceException("Utilities.DatabaseServerName:: Mcf.FrameworkContext == null");
                        }
                    }
                    catch (NullReferenceException nre)
                    {
                        Utilities.LogMessage("Utilities.DatabaseServerName:: NullReferenceException thrown:\n" + nre.ToString());
                    }
                    finally
                    {
                        if (cachedDatabaseServerName == null)
                        {
                            cachedDatabaseServerName = Registry.GetValue(
                                RegistryHive.Win32LocalMachine,
                                Constants.SetupRegistryPath,
                                Constants.DatabaseServerNameRegistryKey);
                        }
                    }

                    Utilities.LogMessage("Utilities.DatabaseServerName:: DataBase Server = " + cachedDatabaseServerName);
                }

                return cachedDatabaseServerName;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Property for MOM Database Name
        /// </summary>
        /// <history>
        ///     [mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string DatabaseName
        {
            get
            {
                if (cachedDatabaseName == null)
                {
                    cachedDatabaseName = Registry.GetValue(
                        RegistryHive.Win32LocalMachine,
                        Constants.SetupRegistryPath,
                        Constants.DatabaseNameRegistryKey);
                }

                return cachedDatabaseName;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Property for MOM Server Name 
        /// </summary>
        /// <history>
        /// [mbickle] 11NOV05 Pull info from Registry - Uses DefaultSDKServiceMachine
        /// [faizalk] 14MAR06 Update to use MOM Test Topology
        /// </history>
        /// ------------------------------------------------------------------
        public static string MomServerName
        {
            get
            {
                if (null == Utilities.cachedMomServerName)
                {
                    Utilities.LogMessage(
                        "Utilities.MomServerName::Getting Root SDK server name...");

                    // get value from framework context and topology
                    Utilities.cachedMomServerName =
                        Utilities.GetMomRootSdkServerName();

                    // check for null or empty string
                    if (string.IsNullOrEmpty(Utilities.cachedMomServerName))
                    {
                        // try to get the value from the registry
                        Utilities.LogMessage(
                            "Utilities.MomServerName:: Reading MOM Server from registry...");
                        Utilities.cachedMomServerName = Registry.GetValue(
                            RegistryHive.Win32LocalMachine,
                            Constants.MachineSettingsRegistryPath,
                            Constants.DefaultSDKServiceMachineRegistryKey);
                    }

                    Utilities.LogMessage(
                        "Utilities.MomServerName:: Management Server := '" +
                        Utilities.cachedMomServerName +
                        "'");
                }

                return Utilities.cachedMomServerName;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Property for UserDnsDomainName 
        /// </summary>
        /// <history>
        /// [faizalk] 02DEC05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string UserDnsDomainName
        {
            get
            {
                if (cachedUserDnsDomainName == null)
                {
                    cachedUserDnsDomainName = Environment.GetEnvironmentVariable("USERDNSDOMAIN");
                    Utilities.LogMessage("Utilities.UserDnsDomainName:: DNS name:=" + cachedUserDnsDomainName);
                }

                return cachedUserDnsDomainName;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Property for UserDomainName 
        /// </summary>
        /// <history>
        /// [faizalk] 02DEC05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string UserDomainName
        {
            get
            {
                if (cachedUserDomainName == null)
                {
                    cachedUserDomainName = Environment.GetEnvironmentVariable("USERDOMAIN");
                    Utilities.LogMessage("Utilities.UserDomainName:: Domain name:=" + cachedUserDomainName);
                }

                return cachedUserDomainName;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Get current logged on username, without DOMAIN.
        /// </summary>
        /// <history>
        /// [v-chunya] 11MAY09 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string UserName
        {
            get
            {
                if (cachedUserName == null)
                {
                    cachedUserName = Environment.GetEnvironmentVariable("USERNAME");
                    Utilities.LogMessage("Utilities.UserName:: User name:=" + cachedUserName);
                }
                return cachedUserName;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets Management Group Name from the DB.
        /// </summary>
        /// <returns>Namagement Group Name string.</returns>
        /// <history>
        ///     [lucyra] 04OCT05: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static string ManagementGroupName
        {
            get
            {
                ManagementGroup managementGroup = ConnectToManagementServer();
                return managementGroup.Name;
            }
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Property to return an int seed to be used by random string generation
        /// Initialized to random integer value, seed can not be zero
        /// </summary>
        /// <history>
        ///     [billhodg] 21SEP09 Created
        /// </history>
        /// ----------
        public static int Seed
        {
            get
            {
                if (seed == 0)
                {
                    seed = new Random().Next();
                }
                return seed;
            }

            set { seed = value; }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Web Console Web Server name from the Web Console URL in 
        /// the database. Sets (overrides) the Web Console Web Server name 
        /// locally, but doesn't modify the value in the database. To clear
        /// the overidden value and use the value coming from the database set
        /// this property to null or String.Empty.
        /// 
        /// This property is used by other Utilities methods like 
        ///    GetWebHostWebConfig
        ///    GetWebConsoleURL
        /// </summary>
        /// <returns>Web Console Web Server name</returns>
        /// <history>
        ///     [nathd] 11SEP14: Created.
        /// </history>
        /// ------------------------------------------------------------------
        public static string WebConsoleWebServerName
        {
            get
            {
                if (String.IsNullOrEmpty(cachedWebConsoleWebServerName))
                {
                    // Get the Web Console URL from the DB.
                    string webConsoleURL = GetWebConsoleURL();

                    // Throw is the URL is null or empty.
                    if (String.IsNullOrEmpty(webConsoleURL))
                    {
                        throw new ObjectNotFoundException("web console URL is null or empty");
                    }

                    LogMessage(String.Format("Utilities.GetWebConsoleServerName :: Web Console URL = {0}", webConsoleURL));

                    // Strip the Web Console hostname from the Web Console URL.
                    // Somewhat dirty as I'm just making two passes and stripping everything that isn't the hostname.
                    cachedWebConsoleWebServerName = webConsoleURL;

                    // Strip http(s):// from the URL
                    cachedWebConsoleWebServerName = Regex.Replace(cachedWebConsoleWebServerName, @"http.*:\/\/", String.Empty);

                    // Strip everything else (e.g. /OperationsManager) from the URL
                    cachedWebConsoleWebServerName = Regex.Replace(cachedWebConsoleWebServerName, @"\/.*$", String.Empty);

                    // Adds smx.net to the end of the hostname if it is not already there. This will cause the entire 
                    // web console app to load under IE's Internet Security Zone settings. 
                    //if (!cachedWebConsoleWebServerName.Contains("smx.net"))
                    //{
                    //    cachedWebConsoleWebServerName += ".smx.net";
                    //}

                    LogMessage(String.Format("Utilities.GetWebConsoleServerName :: Web Console Hostname = {0}", cachedWebConsoleWebServerName));
                }

                return cachedWebConsoleWebServerName;
            }

            set
            {
                LogMessage(String.Format("Utilities.WebConsoleWebServerName :: Overriding the Web Console Web Server name to '{0}", value));
                LogMessage("Utilities.WebConsoleWebServerName :: To revert back to the value in the database assign a null or empty string to this property");
                cachedWebConsoleWebServerName = value;
            }
        }

        public static bool EnableAutoLogMessageThread
        {
            set
            {
                if (value)
                {
                    if (Mcf.FrameworkContext == null)
                    {
                        throw new InvalidOperationException("Mcf.FrameworkContext not initialized.");
                    }
                    if(autoLogMessageThread==null)
                    {
                        autoLogMessageThread=new Thread(new ThreadStart(
                            ()=>{
                                while(true)
                                {
                                    Mcf.FrameworkContext.Alw(string.Format("Log message automatically every {0} minutes.",WaitingTimeForAutoLogMessageThread));
                                    Thread.Sleep(TimeSpan.FromMinutes(WaitingTimeForAutoLogMessageThread));
                                }
                            }
                            ));
                       autoLogMessageThread.Start();
                       Mcf.FrameworkContext.Alw("Auto log message thread enabled");
                    }
                }
                else
                {
                    if (autoLogMessageThread != null && autoLogMessageThread.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
                    {
                        autoLogMessageThread.Abort();
                        autoLogMessageThread = null;
                        Mcf.FrameworkContext.Alw("Auto log message thread disabled.");
                    }
                }
            }
            get
            {
                
                return autoLogMessageThread!=null && (autoLogMessageThread.ThreadState==System.Threading.ThreadState.WaitSleepJoin);
            }
        }
        #endregion // "Properties"

        #region "Public Methods"

        #region SDK methods

        /// ------------------------------------------------------------------
        /// <summary>
        /// Connects to SDK of MomServer
        /// </summary>
        /// <returns>managementGroup</returns>
        /// <history>
        ///     [faizalk] 23NOV05 - Created
        /// </history>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// ------------------------------------------------------------------
        public static ManagementGroup ConnectToManagementServer()
        {
            return ConnectToManagementServer(MomServerName);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Connects to SDK using particular server name
        /// </summary>
        /// <param name="serverName">string name of server</param>
        /// <returns>managementGroup</returns>
        /// <history>
        ///     [faizalk] 23NOV05 - Created
        /// </history>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// ------------------------------------------------------------------
        public static ManagementGroup ConnectToManagementServer(string serverName)
        {
            ManagementGroup managementGroup = null;

            Utilities.LogMessage("Utilities.ConnectToManagementServer:: Connecting to Management Server: " + serverName);
            if (serverName != null && serverName != string.Empty)
            {
                managementGroup = ManagementGroup.Connect(serverName);
            }
            else
            {
                throw new ArgumentNullException("serverName", "Mom Server name \"" + serverName + "\" is invalid!");
            }

            Utilities.LogMessage("Utilities.ConnectToManagementServer:: Connected to Management Server: " + serverName);

            return managementGroup;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Connects to MOM SQL Server
        /// </summary>
        /// <history>
        ///     [mbickle] 25MAR04 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static void MomConnectToSql()
        {
            string sqlConnectionString = null;

            if (sqlConnection == null)
            {
                LogMessage("Utilities.MomConnectToSql:: Connecting to SQL server: " + DatabaseServerName);

                // connect to the SQL Server
                sqlConnectionString = "Initial Catalog=" + DatabaseName + "; Data Source=" + DatabaseServerName + ";Integrated Security=SSPI; Connect Timeout=" + SqlConnectionTimeout; // wait up to two minutes before giving up
                LogMessage("Utilities.MomConnectToSql:: Connection String: " + sqlConnection);

                sqlConnection = new SqlConnection(sqlConnectionString);
            }
            else
            {
                LogMessage("Utilities.MomConnectToSql:: SQL Connection already exists.");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Disconnects from MOM SQL Server
        /// </summary>
        /// <history>
        ///     [mbickle] 18OCT04 - Created
        /// </history>
        /// <remarks>
        /// Common method for disconnecting from SQL, must have used MomConnectToSql()
        /// </remarks>
        /// ------------------------------------------------------------------
        public static void MomCloseConnectionFromSql()
        {
            if (sqlConnection != null)
            {
                sqlConnection.Close();
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Execute the SQL Query, must have a SQL Connection already.
        /// </summary>
        /// <param name="sqlQuery">the query string to be executed</param>
        /// <returns>Query Results</returns>
        /// <history>
        ///     [mbickle] 25MAR04 - Created
        /// </history>
        /// <remarks>
        /// Should this even need to be Public?
        /// </remarks>
        /// ------------------------------------------------------------------
        public static SqlDataReader ExecQuery(string sqlQuery)
        {
            LogMessage("Utilities.ExecQuery:: Calling ExecQuery with: \n" + sqlQuery);

            // If there isn't already a Connection then lets try and create one.
            if (sqlConnection == null)
            {
                MomConnectToSql();
            }

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

            if(sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Close();
                sqlConnection.Open();
            }
            

            // wait up to four minutes before giving up
            sqlCommand.CommandTimeout = SqlCommandTimeout;

            // run the query
            SqlDataReader sqlReader =
                sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

            // Disposing local 'sqlCommand' of type 'SqlCommand' for all code paths
            sqlCommand.Dispose();

            return sqlReader;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the View Name corresponding to a supplied Guid.
        /// Uses the SDK to get the view names
        /// Obsolete Method - Use GetViewName(Guid) instead
        /// </summary>
        /// <param name="viewNameGuid">a GUID corresponding to ViewId in
        ///  Views table</param>
        /// <returns>the View Name</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        /// [ravipr] 25SEP05 - Created
        /// [mbickle] 04NOV05 - Changed to use new SDK name.
        /// [faizalk] 23NOV05 - Updated to use ConnectToManagementServer()
        /// </history>
        /// ------------------------------------------------------------------

        // TODO: Remove this method its obsolete
        public static string GetViewName(string viewNameGuid)
        {
            try
            {
                Guid viewGuid = XmlConvert.ToGuid(viewNameGuid);
                ManagementGroup managementGroup = ConnectToManagementServer();

                Microsoft.EnterpriseManagement.Configuration.ManagementPackView momView = managementGroup.Presentation.GetView(viewGuid);
                return momView.DisplayName;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetViewName:: View Name Guid: " + viewNameGuid + " Not Found !");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the View Name corresponding to a supplied Guid.
        /// Uses the SDK to get the view names
        /// </summary>
        /// <param name="viewNameGuid">a GUID corresponding to ViewId in
        ///  Views table</param>
        /// <returns>the View Name</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        /// [ruhim] 09Jun06 - Created overloade method to use Guid instead of String      
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetViewName(Guid viewNameGuid)
        {
            try
            {
                ManagementGroup managementGroup = ConnectToManagementServer();

                Microsoft.EnterpriseManagement.Configuration.ManagementPackView momView = managementGroup.Presentation.GetView(viewNameGuid);
                return momView.DisplayName;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetViewName:: View Name Guid: " + viewNameGuid + " Not Found !");
                throw;
            }
        }
        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the Page Name corresponding to a supplied Guid.
        /// Uses the SDK to get the page names
        /// </summary>
        /// <param name="pageNameGuid">
        /// A GUID corresponding to ViewId in page ID in the management pack
        /// </param>
        /// <returns>
        /// A string containing the page display name.
        /// </returns>
        /// <history>
        ///     [KellyMor]  09-OCT-08   Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetPageName(string pageNameGuid)
        {
            try
            {
                // convert the string to a GUID
                Guid viewGuid = XmlConvert.ToGuid(pageNameGuid);

                // connect to the SDK service
                ManagementGroup managementGroup = ConnectToManagementServer();

                // get the page based on the specified GUID
                Microsoft.EnterpriseManagement.Configuration.ManagementPackUIPage discoveryPage =
                    managementGroup.Presentation.GetPage(viewGuid);

                // return the page display name
                return discoveryPage.DisplayName;
            }
            catch (ObjectNotFoundException)
            {
                // log the exception
                Utilities.LogMessage(
                    "Utilities.GetPageName:: Page Name Guid: " +
                    pageNameGuid +
                    " Not Found !");

                // rethrow exception to the caller
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the Page Name corresponding to a supplied Guid.
        /// Uses the SDK to get the page names
        /// </summary>
        /// <param name="pageNameGuid">
        /// A GUID corresponding to ViewId in page ID in the management pack
        /// </param>
        /// <returns>
        /// A string containing the page display name.
        /// </returns>
        /// <history>
        ///     [KellyMor]  09-OCT-08   Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetPageName(Guid pageNameGuid)
        {
            try
            {
                // connect to the SDK service
                ManagementGroup managementGroup = ConnectToManagementServer();

                // get the page based on the specified GUID
                Microsoft.EnterpriseManagement.Configuration.ManagementPackUIPage discoveryPage =
                    managementGroup.Presentation.GetPage(pageNameGuid);

                // return the page display name
                return discoveryPage.DisplayName;
            }
            catch (ObjectNotFoundException)
            {
                // log the exception
                Utilities.LogMessage(
                    "Utilities.GetPageName:: Page Name Guid: " +
                    pageNameGuid +
                    " Not Found !");

                // rethrow exception to the caller
                throw;
            }
        }
        /// <summary>
        /// Get PageSet for windows computer to match to Maui Control
        /// </summary>
        /// <returns></returns>
        public static string GetWindowsComputersPageSet()
        {
            Utilities.LogMessage("Utilities.GetWindowsComputersPageSet:: Method Start");

            string resourceWindowsComputer = "";

            #region get Windows Computer PageSet ID as guid

            //get Windows Computer PageSet ID as guid
            System.Guid windowsComputersPageSetGuid = IdUtil.GetMPObjectIdAsGuid(
                           Core.Common.ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                           Core.Common.ManagementPackConstants.MomManagementPackPublicKeyToken,
                           Core.Common.ManagementPackConstants.DiscoveryWizardWindowsComputersPageSet);
            Utilities.LogMessage("Utilities.GetWindowsComputersPageSet:: Windows Computer PageSet ID as guid:" + windowsComputersPageSetGuid.ToString());

            #endregion

            #region get mg information

            //get mg information
            Utilities.LogMessage("Utilities.GetWindowsComputersPageSet::Connecting to Management Group");
            ManagementGroup managementGroup = Utilities.ConnectToManagementServer();
            if (managementGroup == null)
            {
                Utilities.LogMessage("Utilities.GetWindowsComputersPageSet::Null returned for MG");
                throw new ObjectNotFoundException("Utilities.GetWindowsComputersPageSet::Could not get MG");
            }
            else
            {
                Utilities.LogMessage("Utilities.GetWindowsComputersPageSet::MG Name: " + managementGroup.Name);
            }

            #endregion

            #region get root folder id as guid

            //get root folder id as guid             
            System.Guid discoveryWizardPageSetGuid = IdUtil.GetMPObjectIdAsGuid(
                            Core.Common.ManagementPackConstants.SystemCenterOperationsManagerLibraryMPName,
                            Core.Common.ManagementPackConstants.MomManagementPackPublicKeyToken,
                            Core.Common.ManagementPackConstants.DiscoveryWizardPageSetFolder);
            Utilities.LogMessage("Utilities.GetWindowsComputersPageSet:: RootFolderGUID:" + discoveryWizardPageSetGuid.ToString());

            //get root folder
            Utilities.LogMessage("Utilities.GetWindowsComputersPageSet::Obtaining Root Discovery Folder");
            ManagementPackFolder rootFolder = managementGroup.Presentation.GetFolder(discoveryWizardPageSetGuid);
            if (rootFolder == null)
            {
                Utilities.LogMessage("Utilities.GetWindowsComputersPageSet::Null returned for Root folder");
                throw new ObjectNotFoundException("Utilities.GetWindowsComputersPageSet::Could not get Root folder");
            }
            else
            {
                Utilities.LogMessage("Utilities.GetWindowsComputersPageSet::Rootfolder Name:" + rootFolder.Name);
                Utilities.LogMessage("Utilities.GetWindowsComputersPageSet::Rootfolder DisplayName:" + rootFolder.DisplayName);
                Utilities.LogMessage("Utilities.GetWindowsComputersPageSet::Rootfolder Description:" + rootFolder.Description);
            }

            #endregion

            #region get all page sets

            //get all page sets
            Utilities.LogMessage("Utilities.GetWindowsComputersPageSet::Getting All page sets");
            ManagementPackElementCollection<ManagementPackUIPageSet> pageSets = rootFolder.GetItems<ManagementPackUIPageSet>();
            Utilities.LogMessage("Utilities.GetWindowsComputersPageSet::Page Set Count: " + pageSets.Count.ToString());
            foreach (ManagementPackUIPageSet pageSet in pageSets)
            {
                Utilities.LogMessage("Utilities.GetWindowsComputersPageSet::pageSet id:" + pageSet.Id.ToString());
                Utilities.LogMessage("Utilities.GetWindowsComputersPageSet::pageSet Name:" + pageSet.Name);
                Utilities.LogMessage("Utilities.GetWindowsComputersPageSet::pageSet DisplayName:" + pageSet.DisplayName);
                Utilities.LogMessage("Utilities.GetWindowsComputersPageSet::pageSet Description:" + pageSet.Description);
                //Check if the Guids Match then return
                if (windowsComputersPageSetGuid == pageSet.Id)
                {
                    Utilities.LogMessage("Utilities.GetWindowsComputersPageSet::Found Windows Computer Page set");
                    resourceWindowsComputer = pageSet.DisplayName;
                    break;
                }
            }
            if (String.IsNullOrEmpty(resourceWindowsComputer))
            {
                Utilities.LogMessage("Utilities.GetWindowsComputersPageSet::Could not get Windows COmputer Pageset in collection");
                throw new ObjectNotFoundException("Utilities.GetWindowsComputersPageSet::Could not get Windows COmputer Pageset in collection");
            }

            #endregion

            return resourceWindowsComputer;
        }
        /// <summary>
        /// Get PageSet for network devices to match to Maui Control
        /// </summary>
        /// <returns></returns>
        public static string GetNetworkDevicesPageSet()
        {
            Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet:: Method Start");

            string resourceNetworkDevices = "";
            #region get network device PageSet ID as guid
            //get Network Devices PageSet ID as guid
            System.Guid networkDevicesPageSetGuid = IdUtil.GetMPObjectIdAsGuid(
                           Core.Common.ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                           Core.Common.ManagementPackConstants.MomManagementPackPublicKeyToken,
                           Core.Common.ManagementPackConstants.DiscoveryWizardNetworkDevicesPageSet);
            Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet:: Network Devices PageSet ID as guid:" + networkDevicesPageSetGuid.ToString());
            #endregion

            #region get mg information
            //get mg information
            Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet::Connecting to Management Group");
            ManagementGroup managementGroup = Utilities.ConnectToManagementServer();
            if (managementGroup == null)
            {
                Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet::Null returned for MG");
                throw new ObjectNotFoundException("Utilities.GetNetworkDevicesPageSet::Could not connect to ManagementGroup, null returned");
            }
            else
            {
                Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet::ManagementGroup Name: " + managementGroup.Name);
            }
            #endregion

            #region get root folder
            //get root folder id as guid             
            System.Guid discoveryWizardPageSetGuid = IdUtil.GetMPObjectIdAsGuid(
                            Core.Common.ManagementPackConstants.SystemCenterOperationsManagerLibraryMPName,
                            Core.Common.ManagementPackConstants.MomManagementPackPublicKeyToken,
                            Core.Common.ManagementPackConstants.DiscoveryWizardPageSetFolder);
            Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet:: RootFolderGUID:" + discoveryWizardPageSetGuid.ToString());

            //get root folder
            Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet::Obtaining Root Discovery Folder");
            ManagementPackFolder rootFolder = managementGroup.Presentation.GetFolder(discoveryWizardPageSetGuid);
            if (rootFolder == null)
            {
                Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet::Null returned for Root folder");
                throw new ObjectNotFoundException("Utilities.GetNetworkDevicesPageSet::Could not get Root folder");
            }
            else
            {
                Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet::Rootfolder Name:" + rootFolder.Name);
                Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet::Rootfolder DisplayName:" + rootFolder.DisplayName);
                Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet::Rootfolder Description:" + rootFolder.Description);
            }
            #endregion

            #region get all page sets
            //get all page sets
            Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet::Getting All page sets");
            ManagementPackElementCollection<ManagementPackUIPageSet> pageSets = rootFolder.GetItems<ManagementPackUIPageSet>();
            Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet::Page Set Count: " + pageSets.Count.ToString());
            foreach (ManagementPackUIPageSet pageSet in pageSets)
            {
                Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet::pageSet id:" + pageSet.Id.ToString());
                Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet::pageSet Name:" + pageSet.Name);
                Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet::pageSet DisplayName:" + pageSet.DisplayName);
                Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet::pageSet Description:" + pageSet.Description);
                //Check if the Guids Match then return
                if (networkDevicesPageSetGuid == pageSet.Id)
                {
                    Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet::Found Network Devices Page set");
                    resourceNetworkDevices = pageSet.DisplayName;
                    break;
                }
            }
            if (String.IsNullOrEmpty(resourceNetworkDevices))
            {
                Utilities.LogMessage("Utilities.GetNetworkDevicesPageSet::Could not get Network Devices Pageset in collection");
                throw new ObjectNotFoundException("Utilities.GetNetworkDevicesPageSet::Could not get Network Devices Pageset in collection");
            }
            #endregion

            return resourceNetworkDevices;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the ManagementPack Name corresponding to a supplied Guid.
        /// Uses the SDK to get the Management Packs
        /// </summary>
        /// <param name="managementPackNameGuid">a GUID corresponding to ManagementPackId in
        ///  ManagementPacks table</param>
        /// <returns>the Management Pack Name</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [ravipr] 27SEP05 - Created
        ///     [faizalk] 23NOV05 - Updated to use ConnectToManagementServer()
        ///     [mbickle] 07APR06 - Changed to get DisplayName instead of FriendlyName
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetManagementPackName(string managementPackNameGuid)
        {
            try
            {
                string returnString = null;
                Utilities.LogMessage("Utilities.GetManagementPackName(...)");

                Guid managementPackGuid = XmlConvert.ToGuid(managementPackNameGuid);

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPack momManagementPack = managementGroup.ManagementPacks.GetManagementPack(managementPackGuid);

                if (momManagementPack.DisplayName != null)
                {
                    returnString = momManagementPack.DisplayName;
                }
                else
                {
                    returnString = momManagementPack.Name;
                }

                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetManagementPackName:: ManagementPack Guid: " + managementPackNameGuid + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackName:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the Entity Name corresponding to a supplied GUID.
        /// Uses the SDK to get the display name
        /// </summary>
        /// <param name="guid">string</param>
        /// <returns>the entity name</returns>
        /// <history>
        ///     [faizalk] 14NOV05 - Created
        ///     [faizalk] 23NOV05 - Updated to use ConnectToManagementServer()
        ///     [faizalk] 01DEC05 - Updated to take string parameter instead of Guid
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetEntityName(string guid)
        {
            // connect to SDK
            ManagementGroup sdkManagementGroup = ConnectToManagementServer();

            // get managed entity type object corresponding to enumeration passed in MonitoringObjectType
            Microsoft.EnterpriseManagement.Configuration.ManagementPackClass managedEntityType = sdkManagementGroup.EntityTypes.GetClass(new Guid(guid));

            return GetDisplayNameFromClass(managedEntityType, false);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the Entity Name corresponding to a supplied enum.
        /// Uses the SDK to get the display name
        /// </summary>
        /// <param name="entityType">SystemMonitoringClass</param>
        /// <returns>the entity name</returns>
        /// <history>
        ///     [faizalk] 27OCT05 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetEntityName(Microsoft.EnterpriseManagement.Configuration.SystemClass entityType)
        {
            return GetEntityName(entityType, false);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the Entity Name corresponding to a supplied enum.
        /// Uses the SDK to get the display names
        /// </summary>
        /// <param name="entityType">SystemMonitoringClass</param>
        /// <param name="returnFullTreePath">bool</param>
        /// <returns>the entity name if returnFullTreePath == false
        ///         else the full path for use as parameter to SelectNode</returns>
        /// <history>
        ///     [faizalk] 27OCT05 - Created
        ///     [faizalk] 04NOV05 - edited to reflect SDK changes
        ///     [faizalk] 23NOV05 - Updated to use ConnectToManagementServer()
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetEntityName(Microsoft.EnterpriseManagement.Configuration.SystemClass entityType, bool returnFullTreePath)
        {
            // connect to SDK
            ManagementGroup sdkManagementGroup = ConnectToManagementServer();

            // get managed entity type object corresponding to enumeration passed in MonitoringObjectType
            Microsoft.EnterpriseManagement.Configuration.ManagementPackClass managedEntityType = sdkManagementGroup.EntityTypes.GetClass(entityType);

            return GetDisplayNameFromClass(managedEntityType, returnFullTreePath);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the UnitMonitorType Name corresponding to a supplied Guid.
        /// Uses the SDK to get the Management Packs
        /// </summary>
        /// <param name="unitMonitorTypeNameGuid">a GUID corresponding to MonitorTypeId in
        ///  MonitorType table</param>
        /// <returns>the Unit Monitor Type Name; returns NULL if monitor not found</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [ruhim] 29SEP05 - Created
        ///     [faizalk] - 23NOV05 - Updated to use ConnectToManagementServer()
        /// </history>
        /// ------------------------------------------------------------------
        [Obsolete("Use GetUnitMonitorTypeName(Guid )")]
        public static string GetUnitMonitorTypeName(string unitMonitorTypeNameGuid)
        {
            try
            {
                string returnString = null;
                Guid unitMonitorTypeGuid = XmlConvert.ToGuid(unitMonitorTypeNameGuid);
                ManagementGroup managementGroup = ConnectToManagementServer();

                Microsoft.EnterpriseManagement.Configuration.UnitMonitorType momUnitMonitorType = managementGroup.GetUnitMonitorType(unitMonitorTypeGuid);
                if (momUnitMonitorType.DisplayName != null)
                {
                    Utilities.LogMessage("Utilities.GetUnitMonitorTypeName:: Unit Monitor Display Name: "
                        + momUnitMonitorType.DisplayName);
                    returnString = momUnitMonitorType.DisplayName;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetUnitMonitorTypeName:: Unit Monitor Name: "
                        + momUnitMonitorType.Name);
                    returnString = momUnitMonitorType.Name;
                }

                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetUnitMonitorTypeName:: UnitMonitorType Guid: " + unitMonitorTypeNameGuid + " Not Found !");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the UnitMonitorType Name corresponding to a supplied Guid.
        /// Uses the SDK to get the Management Packs
        /// </summary>
        /// <param name="unitMonitorTypeGuid">a GUID corresponding to MonitorTypeId in
        ///  MonitorType table</param>
        /// <returns>the Unit Monitor Type Name; returns NULL if monitor not found</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [ruhim] 08Jun06 - Created     
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetUnitMonitorTypeName(Guid unitMonitorTypeGuid)
        {
            try
            {
                string returnString = null;
                ManagementGroup managementGroup = ConnectToManagementServer();

                Microsoft.EnterpriseManagement.Configuration.ManagementPackUnitMonitorType momUnitMonitorType = managementGroup.Monitoring.GetUnitMonitorType(unitMonitorTypeGuid);
                if (momUnitMonitorType.DisplayName != null)
                {
                    Utilities.LogMessage("Utilities.GetUnitMonitorTypeName:: Unit Monitor Display Name: "
                        + momUnitMonitorType.DisplayName);
                    returnString = momUnitMonitorType.DisplayName;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetUnitMonitorTypeName:: Unit Monitor Name: "
                        + momUnitMonitorType.Name);
                    returnString = momUnitMonitorType.Name;
                }

                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetUnitMonitorTypeName:: UnitMonitorType Guid: " + unitMonitorTypeGuid.ToString() + " Not Found !");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the OperationalState/Monitor Condition Display Name corresponding to a supplied MonitorTypeStateId Guid
        /// for a specific Unit Monitor Type.
        /// </summary>
        /// <param name="unitMonitorTypeGuid">a GUID corresponding to MonitorTypeId in
        ///  MonitorType table</param>
        /// <param name="monitorTypeStateGuid">a GUID corresponding to MonitorTypeStateId in MonitorTypeState table</param>
        /// <returns>the Unit Monitor Operational State Name; returns NULL if monitor not found</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [ruhim] 02April07 - Created     
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetUnitMonitorOperationalStateName(Guid unitMonitorTypeGuid, Guid monitorTypeStateGuid)
        {
            try
            {
                string returnString = null;
                ManagementGroup managementGroup = ConnectToManagementServer();

                Microsoft.EnterpriseManagement.Configuration.ManagementPackUnitMonitorType momUnitMonitorType = managementGroup.Monitoring.GetUnitMonitorType(unitMonitorTypeGuid);

                foreach (ManagementPackSubElement state in momUnitMonitorType.MonitorTypeStateCollection)
                {
                    if (state.Id == monitorTypeStateGuid)
                    {
                        if (state.DisplayName != null)
                        {
                            Utilities.LogMessage("Utilities.GetUnitMonitorOperationalStateName:: Operational State Display Name: "
                                + state.DisplayName);
                            returnString = state.DisplayName;
                        }
                        else
                        {
                            Utilities.LogMessage("Utilities.GetUnitMonitorOperationalStateName:: Operational State Name: "
                                + state.Name);
                            returnString = state.Name;
                        }
                        break;
                    }
                }
                if (returnString == null)
                {
                    Utilities.LogMessage("Utilities.GetUnitMonitorOperationalStateName:: Monitor Type State not found - "
                        + monitorTypeStateGuid.ToString());
                }

                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetUnitMonitorOperationalStateName:: UnitMonitorType Guid: " + unitMonitorTypeGuid.ToString() + " Not Found !");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the Monitor Name(like Entity Health)corresponding to a supplied Guid.
        /// Uses the SDK to get the Monitor Name
        /// This Method is Obsolete Use GetMonitorName(string, Guid) instead
        /// </summary>
        /// <param name="targetManagedEntityTypeGuid">a GUID corresponding to TargetManagedEntityType in
        ///  Monitor table</param>
        /// <param name="monitorNameGuid">a GUID corresponding to MonitorId in
        ///  Monitor table</param>
        /// <returns>Monitor Name</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [ruhim] 31OCT05 - Created
        ///     [faizalk] 23NOV05 - Updated to use ConnectToManagementServer()
        /// </history>
        /// ------------------------------------------------------------------        

        // TODO: Remove This method call - its obsolete
        // [Obsolete("Use GetMonitorName(string, Guid)")]
        public static string GetMonitorName(string targetManagedEntityTypeGuid, string monitorNameGuid)
        {
            try
            {
                string returnString = null;
                Guid managedEntityGuid = XmlConvert.ToGuid(targetManagedEntityTypeGuid);
                Guid monitorGuid = XmlConvert.ToGuid(monitorNameGuid);
                ManagementGroup managementGroup = ConnectToManagementServer();

                Microsoft.EnterpriseManagement.Configuration.ManagementPackMonitor momMonitor = managementGroup.Monitoring.GetMonitor(monitorGuid);

                if (momMonitor.DisplayName == null)
                {
                    Utilities.LogMessage("Utilities.GetMonitorName:: Name for the Monitor is: " + momMonitor.Name);
                    returnString = momMonitor.Name;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetMonitorName:: DisplayName for the Monitor is: " + momMonitor.DisplayName);
                    returnString = momMonitor.DisplayName;
                }

                // if no match is found then return null
                if (returnString == null)
                {
                    Utilities.LogMessage("Utilities.GetMonitorName:: No Matching Monitor Found!!");
                }

                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetMonitorName:: MonitorName Guid: " + monitorNameGuid + " Not Found !");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the Monitor Name(like Entity Health)corresponding to a supplied Guid.
        /// Uses the SDK to get the Monitor Name
        /// </summary>
        /// <param name="targetManagedEntityTypeGuid">a GUID corresponding to TargetManagedEntityType in
        ///  Monitor table</param>
        /// <param name="monitorGuid">a GUID corresponding to MonitorId in
        ///  Monitor table</param>
        /// <returns>Monitor Name</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [ruhim] 08Jun06 - Created overloaded method to use Guids     
        /// </history>
        /// ------------------------------------------------------------------                
        public static string GetMonitorName(string targetManagedEntityTypeGuid, Guid monitorGuid)
        {
            try
            {
                string returnString = null;
                Guid managedEntityGuid = XmlConvert.ToGuid(targetManagedEntityTypeGuid);
                ManagementGroup managementGroup = ConnectToManagementServer();

                Microsoft.EnterpriseManagement.Configuration.ManagementPackMonitor momMonitor = managementGroup.Monitoring.GetMonitor(monitorGuid);

                if (momMonitor.DisplayName == null)
                {
                    Utilities.LogMessage("Utilities.GetMonitorName:: Name for the Monitor is: " + momMonitor.Name);
                    returnString = momMonitor.Name;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetMonitorName:: DisplayName for the Monitor is: " + momMonitor.DisplayName);
                    returnString = momMonitor.DisplayName;
                }

                // if no match is found then return null
                if (returnString == null)
                {
                    Utilities.LogMessage("Utilities.GetMonitorName:: No Matching Monitor Found!!");
                }

                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetMonitorName:: MonitorName Guid: " + monitorGuid + " Not Found !");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Log Performance counter data
        /// </summary>
        /// <history>
        ///     [nathd] 27Oct11 - Created
        /// </history>
        /// ------------------------------------------------------------------                
        public static void LogPerfData()
        {
            Utilities.LogMessage(String.Format("Performance Data - Available RAM '{0}'", Utilities.AvailableRAM.ToString()));
            Utilities.LogMessage(String.Format("Performance Data - Current CPU Usage - TOTAL '{0}'", Utilities.CurrentCpuUsage.ToString()));

            Utilities.LogMessage(String.Format("Performance Data - Current Memory Usage - {0} '{1}'", Constants.MomConsoleExe, Utilities.CurrentMemoryUsageDesktopConsole.ToString()));
            Utilities.LogMessage(String.Format("Performance Data - Current CPU Usage - {0} '{1}'", Constants.MomConsoleExe, Utilities.CurrentCpuUsageDesktopConsole.ToString()));

            Utilities.LogMessage(String.Format("Performance Data - Current Memory Usage - {0} '{1}'", Constants.HealthServiceExe, Utilities.CurrentMemoryUsageHealthService.ToString()));
            Utilities.LogMessage(String.Format("Performance Data - Current CPU Usage - {0} '{1}'", Constants.HealthServiceExe, Utilities.CurrentCpuUsageHealthService.ToString()));

            Utilities.LogMessage(String.Format("Performance Data - Current Memory Usage - {0} '{1}'", Constants.W3WpExe, Utilities.CurrentMemoryUsageIIS.ToString()));
            Utilities.LogMessage(String.Format("Performance Data - Current CPU Usage - {0} '{1}'", Constants.W3WpExe, Utilities.CurrentCpuUsageIIS.ToString()));

            Utilities.LogMessage(String.Format("Performance Data - Current Memory Usage - {0} '{1}'", Constants.MonitoringHostExe, Utilities.CurrentMemoryUsageMonitoringHost.ToString()));
            Utilities.LogMessage(String.Format("Performance Data - Current CPU Usage - {0} '{1}'", Constants.MonitoringHostExe, Utilities.CurrentCpuUsageMonitoringHost.ToString()));

            Utilities.LogMessage(String.Format("Performance Data - Current Memory Usage - {0} '{1}'", Constants.SdkSerivceHostExe, Utilities.CurrentMemoryUsageSdkService.ToString()));
            Utilities.LogMessage(String.Format("Performance Data - Current CPU Usage - {0} '{1}'", Constants.SdkSerivceHostExe, Utilities.CurrentCpuUsageSdkService.ToString()));
            
            Utilities.LogMessage(String.Format("Performance Data - Current Memory Usage - {0} '{1}'", Constants.SqlServerExe, Utilities.CurrentMemoryUsageSqlServer.ToString()));
            Utilities.LogMessage(String.Format("Performance Data - Current CPU Usage - {0} '{1}'", Constants.SqlServerExe, Utilities.CurrentCpuUsageSqlServer.ToString()));

            Utilities.LogMessage(String.Format("Performance Data - Current Memory Usage - {0} '{1}'", Constants.InternetExplorerExe, Utilities.CurrentMemoryUsageWebConsole.ToString()));
            Utilities.LogMessage(String.Format("Performance Data - Current CPU Usage - {0} '{1}'", Constants.InternetExplorerExe, Utilities.CurrentCpuUsageWebConsole.ToString()));
        }

        /// <summary>
        /// Gets the URL for the Web Console.
        /// </summary>
        /// <returns></returns>
        public static string GetWebConsoleURL()
        {
            // Connect to the MS and get the Settings object.
            ManagementGroup mg = ConnectToManagementServer();
            Microsoft.EnterpriseManagement.Administration.Settings globalSettings = mg.Administration.Settings;

            // Throw if the Settings object is null.
            if (null == globalSettings)
            {
                throw new ObjectNotFoundException("globalSettings is null");
            }

            globalSettings.Refresh();

            string webConsoleURL = globalSettings.GetDefaultValue(Microsoft.EnterpriseManagement.Administration.Settings.NotificationServer.WebAddresses.WebConsole);

            // Special Case: if the cachedWebConsoleWebServerName member variable is set
            // then someone may have overridden the default web console web server name 
            // coming from the OM SDK and we need to use this value in the URL.
            if (!String.IsNullOrEmpty(cachedWebConsoleWebServerName))
            {
                // Replace from the ':' to the first '/' character in the URL with the overidden web console web server name.
                webConsoleURL = Regex.Replace(webConsoleURL, @":\/\/.*?\/", String.Format(@"://{0}/", Utilities.WebConsoleWebServerName));
            }

            return webConsoleURL;
        }

        /// <summary>
        /// Gets the Web Console installation path from the web server registy.
        /// </summary>
        /// <param name="webConsoleWebServerName">Web Console web server name</param>
        /// <returns>The</returns>
        public static string GetWebConsoleInstallPath(string webConsoleWebServerName)
        {
            if(string.IsNullOrEmpty(webConsoleWebServerName))
            {   
                throw new ArgumentException("webConsoleWebServerName is null or empty");
            }

            // Read the Web Console InstallPath from the Web Server registry. We make a couple of assumptions here
            //   1. The caller has the appropriate permissions to read the registry on the web server.
            //   2. The Web Console server name is not virtual (i.e., not behind a load balancer).
            
            // Get HKLM (use OpenRemoteBaseKey to support distributed topologies).
            Microsoft.Win32.RegistryKey regKeyHklmWebServer =
                Microsoft.Win32.RegistryKey.OpenRemoteBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, webConsoleWebServerName, Microsoft.Win32.RegistryView.Registry64);

            // Check for failure to open HKLM on the remote machine
            if (null == regKeyHklmWebServer)
            {
                throw new ObjectNotFoundException(String.Format("Cannot open HKLM on machine {0}", webConsoleWebServerName));
            }

            // Get the WebConsole registry key.
            Microsoft.Win32.RegistryKey regKeyWebConsole =
                regKeyHklmWebServer.OpenSubKey(Mom.Test.UI.Core.Common.Constants.SetupRegistryPathWebConsole, false);

            // Check for failure to open Web Console registry key
            if (null == regKeyHklmWebServer)
            {
                throw new ObjectNotFoundException(String.Format("Cannot open registry key {0}", Mom.Test.UI.Core.Common.Constants.SetupRegistryPathWebConsole));
            }

            // Get the InstallPath registry key.
            Object obj = regKeyWebConsole.GetValue(Constants.InstallDirectoryRegistryKey);

            if (null != obj)
            {
                LogMessage(String.Format("Utilities.GetWebConsoleInstallPath :: Install Path = '{0}'", obj.ToString()));
                return obj.ToString();
            }
            else
            {
                throw new ObjectNotFoundException(String.Format("Key '{0}' does not exist", Constants.InstallDirectoryRegistryKey));
            }
        }

        /// <summary>
        /// Gets the full path to the Web Console WebHost Web.Config file.
        /// </summary>
        /// <returns>Full path to the Web Console WebHost Web.Config file</returns>
        public static string GetWebConsoleWebConfig()
        {
            return GetWebHostWebConfig();
        }

        /// <summary>
        /// Gets the full path to the Web Console WebHost Web.Config file.
        /// </summary>
        /// <returns>Full path to the Web Console WebHost Web.Config file</returns>
        public static string GetWebConsoleWebConfig(string webConsoleWebServerName)
        {
            return GetWebHostWebConfig(webConsoleWebServerName);
        }

        /// <summary>
        /// Gets the full path to the Web Console WebHost Web.Config file.
        /// </summary>
        /// <returns>Full path to the Web Console WebHost Web.Config file</returns>
        public static string GetWebHostWebConfig()
        {
            return String.Format(@"{0}WebHost\Web.Config", GetWebConsoleInstallPath(Utilities.WebConsoleWebServerName));
        }

        /// <summary>
        /// Gets the full path to the Web Console WebHost Web.Config file.
        /// </summary>
        /// <returns>Full path to the Web Console WebHost Web.Config file</returns>
        public static string GetWebHostWebConfig(string webConsoleWebServerName)
        {
            return String.Format(@"{0}WebHost\Web.Config", GetWebConsoleInstallPath(webConsoleWebServerName));
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to Import a management pack. 
        /// </summary>
        /// <param name="managementPackFileName"> MP File name to import </param>
        /// <remarks> 
        /// The file name can be given with the path. For example
        /// e:\temp\SampleMP.xml
        /// </remarks>
        /// /// <history>
        ///     [ravipr] 26AUG05 - Created
        ///     [faizalk] 23NOV05 - Updated to use ConnectToManagementServer()
        /// </history>
        /// ------------------------------------------------------------------
        public static void ImportManagementPack(string managementPackFileName)
        {
            Utilities.LogMessage("Utilities.ImportManagementPack:: Management Server Name:" + MomServerName);

            // Connect to the server
            ManagementGroup managementGroup = ConnectToManagementServer();

            // Import the MP
            Utilities.LogMessage("Utilities.ImportManagementPack:: Importing the MP: " + managementPackFileName);

            // managementGroup.ImportManagementPack((managementPackFileName));

            Microsoft.EnterpriseManagement.Configuration.ManagementPack mpname =
                new Microsoft.EnterpriseManagement.Configuration.ManagementPack(managementPackFileName);

            managementGroup.ManagementPacks.ImportManagementPack(mpname);

            Utilities.LogMessage("Utilities.ImportManagementPack:: MOM MP: " +
                managementPackFileName +
                " imported successfully!");
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to Import an MPB or Management Pack Bundle file 
        /// </summary>
        /// <param name="managementPackBundleFileName"> MPB File name to import </param>
        /// <remarks> 
        /// The file name can be given with the path. For example
        /// e:\temp\SampleMP.MPB
        /// </remarks>
        /// <history>
        ///     [joelj] 08JAN10 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static void ImportManagementPackBundle(string managementPackBundleFileName)
        {
            Utilities.LogMessage("Utilities.ImportManagementPackBundle:: Management Server Name:" + MomServerName);

            // Connect to the server
            ManagementGroup managementGroup = ConnectToManagementServer();

            // Create a bundle reader
            ManagementPackBundleReader mpbReader = ManagementPackBundleFactory.CreateBundleReader();

            // Import the MP
            Utilities.LogMessage("Utilities.ImportManagementPackBundle:: Reading the MPB file: " + managementPackBundleFileName);

            // Create the bundle
            ManagementPackBundle mpb = mpbReader.Read(managementPackBundleFileName, managementGroup);

            // Import the bundle
            Utilities.LogMessage("Utilities.ImportManagementPackBundle:: Importing the MPB: " + managementPackBundleFileName);
            managementGroup.ManagementPacks.ImportBundle(mpb);

            Utilities.LogMessage("Utilities.ImportManagementPackBundle:: MPB File: " +
                managementPackBundleFileName +
                " imported successfully!");
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to Uninstall a management pack. 
        /// </summary>
        /// <param name="managementPackID"> MP ID to uninstall </param>
        /// /// <history>
        ///     [lucyra] 05AUG07 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static void UninstallManagementPack(string managementPackID)
        {
            Utilities.LogMessage("Utilities.UninstallManagementPack:: Management Server Name:" + MomServerName);

            // Connect to the server
            ManagementGroup managementGroup = ConnectToManagementServer();

            // Import the MP
            Utilities.LogMessage("Utilities.UninstallManagementPack:: Uninstalling the MP: " + managementPackID);

            try
            {
                //Get management pack object
                Microsoft.EnterpriseManagement.Configuration.ManagementPack mpObject =
                    getManagementPackObject(managementPackID, managementGroup);

                if (null != mpObject)
                {
                    managementGroup.ManagementPacks.UninstallManagementPack(mpObject);

                    Utilities.LogMessage("Utilities.UninstallManagementPack:: MOM MP: " +
                        managementPackID +
                        " uninstalled successfully!");

                }
                else
                {
                    Utilities.LogMessage("Utilities.UninstallManagementPack:: MOM MP: " +
                        managementPackID +
                        " was not uninstalled since it was not found in this management group");

                }
            }
            catch (InvalidOperationException ex)
            {
                Utilities.LogMessage("Utilities.UninstallManagementPack:: " + ex.ToString());

                Utilities.LogMessage("Utilities.UninstallManagementPack:: Did not Uninstall the MP!");

            }

        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to Export a management pack. 
        /// </summary>
        /// <param name="managementPackID"> MP ID to export </param>
        /// <param name="path"> Path to export MP</param>
        /// /// <history>
        ///     [lucyra] 05AUG07 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static void ExportManagementPack(string managementPackID, string path)
        {
            Utilities.LogMessage("Utilities.ExportManagementPack:: Management Server Name:" + MomServerName);

            // Connect to the server
            ManagementGroup managementGroup = ConnectToManagementServer();

            // Export the MP to the location specified
            Utilities.LogMessage("Utilities.ExportManagementPack:: Exporting the MP: " + managementPackID);
            Utilities.LogMessage("Utilities.ExportManagementPack:: To the location: " + path);

            try
            {

                //Get management pack object
                Microsoft.EnterpriseManagement.Configuration.ManagementPack mpObject =
                    getManagementPackObject(managementPackID, managementGroup);

                if (null != mpObject)
                {
                    // Provide the directory you want the file created in and format your MP title
                    string outputFileName = @path + FormatDateTime() + managementPackID + ".xml";

                    using (Stream mpStream = new FileStream(outputFileName, FileMode.Create))
                    {

                        //Create new xml writer and mp writer objects
                        XmlWriter xmlwriter = XmlWriter.Create(mpStream);

                        //Microsoft.EnterpriseManagement.Configuration.IO.ManagementPackXmlWriter xmlWriter =
                        //new ManagementPackXmlWriter(@path);
                        ManagementPackXmlWriter mpwriter = new ManagementPackXmlWriter(xmlwriter);

                        //Write out the content of the MP
                        mpwriter.WriteManagementPack(mpObject);

                        //Close the stream
                        mpStream.Close();

                        Utilities.LogMessage("Utilities.ExportedManagementPack:: MOM MP: " +
                            managementPackID + " to the next location: " + path +
                            " successfully!");
                    }

                }
                else
                {
                    Utilities.LogMessage("Utilities.ExportManagementPack:: MOM MP: " +
                        managementPackID +
                        " was not uninstalled since it was not found in this management group");

                }
            }
            catch (InvalidOperationException ex)
            {
                Utilities.LogMessage("Utilities.ExportManagementPack:: " + ex.ToString());

                Utilities.LogMessage("Utilities.ExportManagementPack:: Did not Export the MP!");


            }

        }

        /// <summary>
        /// Export ManagementPack
        /// </summary>
        /// <param name="fileFullPath">export file, full path and file name</param>
        /// <param name="managementPackName">ManagementPack.Name</param>
        ///  <history>
        ///     [v-johnx] 04AUG11 - Created
        /// </history>
        public static void ExportManagementPackByName(string managementPackName,string fileFullPath)
        {            
            Utilities.LogMessage("Utilities.ExportManagementPack:: Management Server Name:" + MomServerName);
            if (string.IsNullOrEmpty(fileFullPath) || string.IsNullOrEmpty(managementPackName))
            {
                Utilities.LogMessage("Utilities.ExportManagementPack:: fileFullPath value : " + fileFullPath);
                Utilities.LogMessage("Utilities.ExportManagementPack:: managementPackName : " + managementPackName);
                Utilities.LogMessage("Utilities.ExportManagementPack:: parameters value is invalid");
            }
            // Connect to the server
            ManagementGroup managementGroup = ConnectToManagementServer();
            // Export the MP to the location specified
            Utilities.LogMessage("Utilities.ExportManagementPack:: Exporting the MP: " + managementPackName);
            Utilities.LogMessage("Utilities.ExportManagementPack:: To the location: " + fileFullPath);

            try
            {
                //Get management pack object
                Microsoft.EnterpriseManagement.Configuration.ManagementPack mpObject =
                    getManagementPackObject(managementPackName, managementGroup);

                if (null != mpObject)
                {
                    using (Stream mpStream = new FileStream(fileFullPath, FileMode.Create))
                    {
                        //Create new xml writer and mp writer objects
                        XmlWriter xmlwriter = XmlWriter.Create(mpStream);
                        ManagementPackXmlWriter mpwriter = new ManagementPackXmlWriter(xmlwriter);

                        //Write out the content of the MP
                        mpwriter.WriteManagementPack(mpObject);

                        //Close the stream
                        mpStream.Close();

                        Utilities.LogMessage("Utilities.ExportedManagementPack:: MOM MP: " +
                            managementPackName + " to the next location: " + fileFullPath +
                            " successfully!");
                    }
                }
                else
                {
                    Utilities.LogMessage("Utilities.ExportManagementPack:: MOM MP: " +
                        managementPackName +
                        " was not uninstalled since it was not found in this management group");
                }
            }
            catch (InvalidOperationException ex)
            {
                Utilities.LogMessage("Utilities.ExportManagementPack:: " + ex.ToString());

                Utilities.LogMessage("Utilities.ExportManagementPack:: Did not Export the MP!");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Checks whether Management Pack Exist 
        /// </summary>
        /// <param name="managementPackName"> Management Pack to check </param>
        /// <returns>True/False</returns>
        /// <history>
        ///     [ravipr] 30AUG05 - Created
        ///     [mbickle] 01SEP05 Removed generic catch, not necessary and breaks FxCop.
        ///     [faizalk] 23NOV05 - Updated to use ConnectToManagementServer()
        /// </history>
        /// ------------------------------------------------------------------
        public static bool ManagementPackExists(string managementPackName)
        {
            bool managementPackExists = false;

            Utilities.LogMessage("Utilities.ManagementPackExists:: Management Server Name:" + MomServerName);

            // Connect to the server
            ManagementGroup managementGroup = ConnectToManagementServer();

            // Import the MP
            Utilities.LogMessage("Utilities.ManagementPackExists:: Checking if the  MP: " + managementPackName + " exists");
            try
            {
                System.Collections.Generic.IList<ManagementPack> managementPackCollection = managementGroup.ManagementPacks.GetManagementPacks();
                foreach (ManagementPack mp in managementPackCollection)
                {
                    if (managementPackName.ToLower() == mp.Name.ToLower())
                    {
                        managementPackExists = true;
                    }
                }
            }
            catch (ObjectNotFoundException)
            {
                managementPackExists = false;
            }

            Utilities.LogMessage("Utilities.ManagementPackExists:: MP: " + managementPackName + " Exists = " + managementPackExists.ToString());
            return managementPackExists;
        }

        /// <summary>
        /// If you need to know if the MP has been delivered to the health service don't use this 
        /// use MPHelper.VerifyImport instead
        /// This method only verifies that the MP is known by the SDK
        /// </summary>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <param name="managementPackName"></param>
        public static void WaitUntilManagementPackExists(string managementPackName, int timeout)
        {
            Utilities.LogMessage("WaitUntilManagementPackExists: waiting for '" + managementPackName + "' for up to " + timeout + " seconds");
            bool mpExists = false;
            while (timeout >= 0)
            {
                //Check if MP exists
                mpExists = ManagementPackExists(managementPackName);

                //If MP not exists, then break while loop and return true
                if (mpExists == true)
                {
                    return;
                }
                else
                {
                    Sleeper.Delay(Constants.OneSecond);
                    timeout--;
                }
            }

            throw new ObjectNotFoundException("Managementpack " + managementPackName + " not found.");
        }

        /// <summary>
        /// Wait Management Pack to be deleted
        /// </summary>
        /// <param name="managementPackName">Management Pack to wait for deletion</param>
        /// <returns>true if deleted, otherwise false</returns>
        public static bool VerifyManagementPackDeleted(string managementPackName)
        {
            return VerifyManagementPackDeleted(managementPackName, Constants.OneMinute / Constants.OneSecond);
        }

        /// <summary>
        /// Wait Management Pack to be deleted
        /// </summary>
        /// <param name="managementPackName">Management Pack to wait for deletion</param>
        /// <param name="timeout">Seconds to wait</param>
        /// <returns>true if deleted, otherwise false</returns>
        public static bool VerifyManagementPackDeleted(string managementPackName, int timeout)
        {
            bool mpDeleted = false;
            bool mpExists = false;
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            DateTime startTime = DateTime.Now;

            Utilities.LogMessage(currentMethodName + ":: Wait MP: '" + managementPackName + "' to be deleted in " + timeout + " seconds");
            while (timeout >= 0)
            {
                //Check if MP exists
                mpExists = ManagementPackExists(managementPackName);

                //If MP not exists, then break while loop and return true
                if (mpExists == false)
                {
                    mpDeleted = true;
                    break;
                }
                else
                {
                    Sleeper.Delay(Constants.OneSecond);
                    timeout--;
                }
            }

            if (mpDeleted)
            {
                Utilities.LogMessage(currentMethodName + ":: MP:'" + managementPackName + "' deleted in " + ElapsedTime(startTime).TotalSeconds + " seconds");
            }
            else
            {
                Utilities.LogMessage(currentMethodName + ":: Failed to delete MP:'" + managementPackName + "' in " + ElapsedTime(startTime).TotalSeconds + " seconds");
            }

            return mpDeleted;
        }
        /// ------------------------------------------------------------------
        /// <summary>
        /// This method returns the Display Name for the operation state corresponding 
        /// to a supplied Guid and associated with a particular unit monitor.
        /// Uses the SDK to get the Monitor Type States
        /// </summary>
        /// <param name="unitMonitorTypeNameGuid">a GUID corresponding to MonitorTypeId in
        ///  MonitorTypeState table</param>
        /// <param name="monitorTypeStateIdGuid">a GUID corresponding to MonitorTypeStateId in
        ///  MonitorTypeState table</param>
        /// <returns>the Unit Monitor Type State Name; returns NULL if Type State GUID not found</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [ruhim] 14NOV05 - Created
        ///     [faizalk] 23NOV05 - Updated to use ConnectToManagementServer()
        /// </history>
        /// ------------------------------------------------------------------
        [Obsolete("Use GetOperationalStateName(Guid, String)")]
        public static string GetOperationalStateName(string unitMonitorTypeNameGuid, string monitorTypeStateIdGuid)
        {
            try
            {
                string returnString = null;
                Guid unitMonitorTypeGuid = XmlConvert.ToGuid(unitMonitorTypeNameGuid);
                Guid monitorTypeStateGuid = XmlConvert.ToGuid(monitorTypeStateIdGuid);
                ManagementGroup managementGroup = ConnectToManagementServer();

                Microsoft.EnterpriseManagement.Configuration.UnitMonitorType momUnitMonitorType = managementGroup.GetUnitMonitorType(unitMonitorTypeGuid);

                // foreach (Microsoft.EnterpriseManagement.Configuration.UnitMonitorTypeState typeState in momUnitMonitorType.UnitMonitorTypeStates)
                foreach (Microsoft.EnterpriseManagement.Configuration.ManagementPackMonitorTypeState typeState in momUnitMonitorType.MonitorTypeStateCollection)
                {
                    if (typeState.Id == monitorTypeStateGuid)
                    {
                        if (typeState.DisplayName != null)
                        {
                            Utilities.LogMessage("Utilities.GetOperationalStateName:: Operational State Display Name: "
                                + typeState.DisplayName);
                            returnString = typeState.DisplayName;
                            break;
                        }
                        else
                        {
                            Utilities.LogMessage("Utilities.GetOperationalStateName:: Operational State Name: "
                                + typeState.Name);
                            returnString = typeState.Name;
                            break;
                        }
                    }
                }

                // If the operational state id is not found then return null
                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetOperationalStateName:: UnitMonitorType Guid: " + unitMonitorTypeNameGuid + " Not Found !");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// This method returns the Display Name for the operation state corresponding 
        /// to a supplied Guid and associated with a particular unit monitor.
        /// Uses the SDK to get the Monitor Type States
        /// </summary>
        /// <param name="unitMonitorTypeGuid">a GUID corresponding to MonitorTypeId in
        ///  MonitorTypeState table</param>
        /// <param name="monitorTypeStateIdGuid">a GUID corresponding to MonitorTypeStateId in
        ///  MonitorTypeState table</param>
        /// <returns>the Unit Monitor Type State Name; returns NULL if Type State GUID not found</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [ruhim] 08Jun06 - Created overloaded method to use GUIDs     
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetOperationalStateName(Guid unitMonitorTypeGuid, string monitorTypeStateIdGuid)
        {
            try
            {
                string returnString = null;
                Guid monitorTypeStateGuid = XmlConvert.ToGuid(monitorTypeStateIdGuid);
                ManagementGroup managementGroup = ConnectToManagementServer();

                Microsoft.EnterpriseManagement.Configuration.ManagementPackUnitMonitorType momUnitMonitorType = managementGroup.Monitoring.GetUnitMonitorType(unitMonitorTypeGuid);

                // foreach (Microsoft.EnterpriseManagement.Configuration.UnitMonitorTypeState typeState in momUnitMonitorType.UnitMonitorTypeStates)
                foreach (Microsoft.EnterpriseManagement.Configuration.ManagementPackMonitorTypeState typeState in momUnitMonitorType.MonitorTypeStateCollection)
                {
                    if (typeState.Id == monitorTypeStateGuid)
                    {
                        if (typeState.DisplayName != null)
                        {
                            Utilities.LogMessage("Utilities.GetOperationalStateName:: Operational State Display Name: "
                                + typeState.DisplayName);
                            returnString = typeState.DisplayName;
                            break;
                        }
                        else
                        {
                            Utilities.LogMessage("Utilities.GetOperationalStateName:: Operational State Name: "
                                + typeState.Name);
                            returnString = typeState.Name;
                            break;
                        }
                    }
                }

                // If the operational state id is not found then return null
                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetOperationalStateName:: UnitMonitorType Guid: " + unitMonitorTypeGuid + " Not Found !");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the Monitoring Rule Name corresponding to a supplied RuleId Guid.
        /// Uses the SDK to get the Rules targeted to a particular ManagedEntityType
        /// </summary>
        /// <param name="targetManagedEntityTypeGuid">a GUID corresponding to TargetManagedEntityType in
        ///  Rules table</param>
        /// <param name="ruleIdGuid">a GUID corresponding to RuleId in Rules table</param>
        /// <returns>Rule Name</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [ruhim] 31OCT05 - Created
        ///     [faizalk] 23NOV05 - Updated to use ConnectToManagementServer()
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetMonitoringRuleName(string targetManagedEntityTypeGuid, string ruleIdGuid)
        {
            try
            {
                Guid managedEntityGuid = XmlConvert.ToGuid(targetManagedEntityTypeGuid);
                Guid ruleGuid = XmlConvert.ToGuid(ruleIdGuid);
                ManagementGroup managementGroup = ConnectToManagementServer();

                Microsoft.EnterpriseManagement.Configuration.ManagementPackClass targetEntity = managementGroup.EntityTypes.GetClass(managedEntityGuid);
                string returnString = null;
                foreach (Microsoft.EnterpriseManagement.Configuration.ManagementPackRule rule in targetEntity.ManagementGroup.Monitoring.GetRules())
                {
                    if (rule.Id == ruleGuid)
                    {
                        if (rule.DisplayName != null)
                        {
                            Utilities.LogMessage("Utilities.GetMonitoringRuleName:: Rule Display Name: "
                                + rule.DisplayName);
                            returnString = rule.DisplayName;
                        }
                        else
                        {
                            Utilities.LogMessage("Utilities.GetMonitoringRuleName:: Rule Name: "
                                + rule.Name);
                            returnString = rule.Name;
                        }
                    }
                }

                // If the operational state id is not found then return null
                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetMonitoringRuleName:: TargetManagedEntity Guid: " + targetManagedEntityTypeGuid + " Not Found !");
                throw;
            }
        }
        /// ------------------------------------------------------------------
        /// <summary>
        ///Used to return MOduleType Display Name corresponding to a supplied ModuleTypeGuid Guid. 
        /// </summary>
        /// <param name="moduleTypeIdGuid">a GUID corresponding to ElemnetId in DisplayStringView table</param>        
        /// <returns>DisplayName</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [sunsingh] 3sept08 - Created
        /// </history>
        /// ---------------------------------------------------------------Guid---
        public static string GetManagementPackModuleTypeName(Guid moduleTypeIdGuid)
        {
            try
            {
                string returnString = null;

                ManagementGroup managementGroup = ConnectToManagementServer();
                //ManagementPackModuleType
                Microsoft.EnterpriseManagement.Configuration.ManagementPackModuleType managementModuleType = managementGroup.Monitoring.GetModuleType(moduleTypeIdGuid);

                if (managementModuleType.DisplayName != null)
                {
                    Utilities.LogMessage("Utilities.GetManagementPackModuleTypeName:: Display Name: "
                        + managementModuleType.DisplayName);
                    returnString = managementModuleType.DisplayName;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetManagementPackModuleTypeName:: Name: "
                        + managementModuleType.Name);
                    returnString = managementModuleType.Name;
                }

                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetManagementPackModuleTypeName:: Guid: " + moduleTypeIdGuid + " Not Found !");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///Used to return MOduleType Display Name corresponding to a supplied reportGuid Guid. 
        /// </summary>
        /// <param name="reportGuid">a GUID corresponding  to reportid in reportdisplaystring table</param>        
        /// <returns>DisplayName</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [sunsingh] 11sept08 - Created
        /// </history>
        /// ---------------------------------------------------------------Guid---
        public static string GetReportDisplayName(Guid reportGuid)
        {
            try
            {
                string returnString = null;

                ManagementGroup managementGroup = ConnectToManagementServer();
                //ManagementPackModuleType
                Microsoft.EnterpriseManagement.Configuration.ManagementPackReport managementReport = managementGroup.Reporting.GetReport(reportGuid);

                if (managementReport.DisplayName != null)
                {
                    Utilities.LogMessage("Utilities.GetReportDisplayName:: Display Name: "
                        + managementReport.DisplayName);
                    returnString = managementReport.DisplayName;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetReportDisplayName:: Name: "
                        + managementReport.Name);
                    returnString = managementReport.Name;
                }

                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetManagementPackModuleTypeName:: Guid: " + reportGuid + " Not Found !");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///Used to return report string Display Name corresponding to a supplied reportGuid and reportStringGuid. 
        /// </summary>
        /// <param name="reportGuid">a GUID corresponding to reportid in reportdisplaystring table</param>        
        /// <param name="reportStringGuid">a GUID corresponding to ElemnetId in reportdisplaystring table</param>        
        /// <returns>DisplayName</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [sunsingh] 11sept08 - Created
        /// </history>
        /// ---------------------------------------------------------------Guid---
        public static string GetMonitoringReportStringFromGuid(Guid reportGuid, Guid reportStringGuid)
        {
            try
            {
                string returnString = null;
                //Guid monitorTypeStateGuid = XmlConvert.ToGuid(monitorTypeStateIdGuid);
                ManagementGroup managementGroup = ConnectToManagementServer();

                Microsoft.EnterpriseManagement.Configuration.ManagementPackReport momMonitoringReport = managementGroup.Reporting.GetReport(reportGuid);

                // foreach (Microsoft.EnterpriseManagement.Configuration.UnitMonitorTypeState typeState in momUnitMonitorType.UnitMonitorTypeStates)
                foreach (ManagementPackSubElement reportString in momMonitoringReport.ReportStringCollection)
                {
                    if (reportString.Id == reportStringGuid)
                    {
                        if (reportString.DisplayName != null)
                        {
                            Utilities.LogMessage("Utilities.GetMonitoringReportStringFromGuid:: report String Display Name: "
                                + reportString.DisplayName);
                            returnString = reportString.DisplayName;
                            break;
                        }
                        else
                        {
                            Utilities.LogMessage("Utilities.GetMonitoringReportStringFromGuid:: report String Name: "
                                + reportString.Name);
                            returnString = reportString.Name;
                            break;
                        }
                    }
                }

                // If the operational state id is not found then return null
                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetMonitoringReportStringFromGuid:: reportString Guid: " + reportStringGuid + " Not Found !");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        ///Used to return MP Display Name corresponding to a supplied MP Guid. 
        /// </summary>
        /// <param name="guid">a GUID corresponding to managementpack</param>        
        /// <returns>DisplayName</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [sunsingh] 11sept08 - Created
        /// </history>
        /// ---------------------------------------------------------------Guid---
        public static string GetManagementPackName(Guid guid)
        {
            try
            {
                string returnString = null;

                ManagementGroup managementGroup = ConnectToManagementServer();
                //ManagementPackModuleType
                Microsoft.EnterpriseManagement.Configuration.ManagementPack mangementpack = managementGroup.ManagementPacks.GetManagementPack(guid);

                if (mangementpack.DisplayName != null)
                {
                    Utilities.LogMessage("Utilities.GetManagementPackName:: Display Name: "
                        + mangementpack.DisplayName);
                    returnString = mangementpack.DisplayName;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetManagementPackName:: Name: "
                        + mangementpack.Name);
                    returnString = mangementpack.Name;
                }

                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetMonitoringReportResource:: Guid: " + guid + " Not Found !");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the Monitoring Template Name corresponding to a supplied TemplateId Guid.
        /// This method is obsolete use GetMonitoringTemplateName(Guid) instead
        /// </summary>
        /// <param name="templateIdGuid">a GUID corresponding to TemplateId in Template table</param>        
        /// <returns>Template Name</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [ruhim] 17NOV05 - Created
        ///     [faizalk] 23NOV05 - Updated to use ConnectToManagementServer()
        /// </history>
        /// ------------------------------------------------------------------

        // TODO: Remove this method its obsolete
        public static string GetMonitoringTemplateName(string templateIdGuid)
        {
            try
            {
                string returnString = null;
                Guid templateGuid = XmlConvert.ToGuid(templateIdGuid);
                ManagementGroup managementGroup = ConnectToManagementServer();

                Microsoft.EnterpriseManagement.Configuration.ManagementPackTemplate monitoringTemplate = managementGroup.Templates.GetTemplate(templateGuid);

                if (monitoringTemplate.DisplayName != null)
                {
                    Utilities.LogMessage("Utilities.GetMonitoringTemplateName:: Template Display Name: "
                        + monitoringTemplate.DisplayName);
                    returnString = monitoringTemplate.DisplayName;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetMonitoringTemplateName:: Template Name: "
                        + monitoringTemplate.Name);
                    returnString = monitoringTemplate.Name;
                }

                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetMonitoringTemplateName:: TemplateId Guid: " + templateIdGuid + " Not Found !");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the Monitoring Template Name corresponding to a supplied TemplateId Guid.
        /// </summary>
        /// <param name="templateIdGuid">a GUID corresponding to TemplateId in Template table</param>        
        /// <returns>Template Name</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [ruhim] 17NOV05 - Created overloaded method to use Guid instead of string     
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetMonitoringTemplateName(Guid templateIdGuid)
        {
            try
            {
                string returnString = null;
                ManagementGroup managementGroup = ConnectToManagementServer();

                Microsoft.EnterpriseManagement.Configuration.ManagementPackTemplate monitoringTemplate = managementGroup.Templates.GetTemplate(templateIdGuid);

                if (monitoringTemplate.DisplayName != null)
                {
                    Utilities.LogMessage("Utilities.GetMonitoringTemplateName:: Template Display Name: "
                        + monitoringTemplate.DisplayName);
                    returnString = monitoringTemplate.DisplayName;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetMonitoringTemplateName:: Template Name: "
                        + monitoringTemplate.Name);
                    returnString = monitoringTemplate.Name;
                }

                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetMonitoringTemplateName:: TemplateId Guid: " + templateIdGuid.ToString() + " Not Found !");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the Monitoring Folder Name corresponding to a supplied FolderId Guid.
        /// </summary>
        /// <param name="folderIdGuid">a GUID corresponding to FolderId in Folder table</param>        
        /// <returns>Folder Name</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [faizalk] 12APR07 - Created     
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetMonitoringFolderName(Guid folderIdGuid)
        {
            try
            {
                string returnString = null;
                ManagementGroup managementGroup = ConnectToManagementServer();

                Microsoft.EnterpriseManagement.Configuration.ManagementPackFolder monitoringFolder = managementGroup.Presentation.GetFolder(folderIdGuid);

                if (monitoringFolder.DisplayName != null)
                {
                    Utilities.LogMessage("Utilities.GetMonitoringFolderName:: Folder Display Name: "
                        + monitoringFolder.DisplayName);
                    returnString = monitoringFolder.DisplayName;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetMonitoringFolderName:: Folder Name: "
                        + monitoringFolder.Name);
                    returnString = monitoringFolder.Name;
                }

                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetMonitoringFolderName:: FolderId Guid: " + folderIdGuid.ToString() + " Not Found !");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the Display Name for a Profile corresponding to a supplied UserRoleId Guid.
        /// </summary>
        /// <param name="profileIdGuid">a GUID corresponding to ProfileId in Profile table</param>        
        /// <returns>User Role Profile Display Name</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [ruhim] 22NOV05 - Created
        ///     [faizalk] 23NOV05 - Updated to use ConnectToManagementServer()
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetUserRoleProfileName(string profileIdGuid)
        {
            try
            {
                string returnString = null;
                Guid profileGuid = XmlConvert.ToGuid(profileIdGuid);
                ManagementGroup managementGroup = ConnectToManagementServer();

                foreach (Microsoft.EnterpriseManagement.Security.Profile monitoringProfile in managementGroup.Security.GetProfiles())
                {
                    if (monitoringProfile.Id == profileGuid)
                    {
                        if (monitoringProfile.DisplayName != null)
                        {
                            Utilities.LogMessage("Utilities.GetUserRoleProfileName:: Profile Display Name: "
                                + monitoringProfile.DisplayName);
                            returnString = monitoringProfile.DisplayName;
                            break;
                        }
                        else
                        {
                            Utilities.LogMessage("Utilities.GetUserRoleProfileName:: Profile Name: "
                                + monitoringProfile.Name);
                            returnString = monitoringProfile.Name;
                            break;
                        }
                    }
                }

                // Returns null if no match found
                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetUserRoleProfileName:: ProfileId Guid: " + profileIdGuid + " Not Found !");
                throw;
            }
        }


        /// <summary>
        /// Sdk API to return all teh userrole in the MG
        /// </summary>
        /// <returns></returns>
        public static IList<UserRole> GetAllUserRole()
        {
            var currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var logMessageBase = currentMethod + " :: ";
            var mg = ConnectToManagementServer();
            return mg.Security.GetUserRoles();
        }

        /// <summary>
        /// Gets The Display String For the Folder in the Tree views for a given MG
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="mpName"></param>
        /// <param name="mg"></param>
        /// <returns>string</returns>
        public static string GetFolderDisplayName(string mpName, string folderName,ManagementGroup mg)
        {
            if (mpName == null) throw new ArgumentNullException("mpName");
            if (folderName == null) throw new ArgumentNullException("folderName");
            if (mg == null) throw new ArgumentNullException("mg");
            try
            {
                var managementPack = mg.ManagementPacks.GetManagementPacks().Where(mp => mp.Name.Equals(mpName)).FirstOrDefault();
                if (managementPack.GetFolder(folderName).DisplayName != null)
                {
                    LogMessage(string.Format("Utilities.GetFolderDisplayName:: Display Name: {0}", managementPack.GetFolder(folderName).DisplayName));

                    return managementPack.GetFolder(folderName).DisplayName;
                }
                LogMessage(string.Format("Utilities.GetFolderDisplayName:: Display Name: {0}", managementPack.GetFolder(folderName).Name));

                return managementPack.GetFolder(folderName).Name;
            }
            catch (Exception e)
            {
                throw new Exception("There was an error loading resource", e);
            }
        }

        /// <summary>
        /// Gets The Display String For the Folder in the Tree views
        /// </summary>
        /// <param name="mpName"></param>
        /// <param name="folderName"></param>
        /// <returns>string</returns>
        public static string GetFolderDisplayName(String mpName, String folderName)
        {
            if (mpName == null) throw new ArgumentNullException("mpName");
            if (folderName == null) throw new ArgumentNullException("folderName");
            try
            {
                var mg = ConnectToManagementServer();
                return GetFolderDisplayName(mpName, folderName, mg);
            }
            catch (Exception e)
            {

                throw new Exception("There was an error loading FolderName resource", e);
            }
            
        }

        /// <summary>
        /// get's The display String for ComponentType and ComponentRefrence
        /// </summary>
        /// <param name="componentTypeName"></param>
        /// <param name="mg"></param>
        /// <returns>Display String for the Component</returns>
        /// <history>
        ///     [sunsingh] 26April10 - Created
        /// </history>
        public static string GetDisplayStringForComponent(String componentTypeName, ManagementGroup mg)
        {
            if (componentTypeName == null) throw new ArgumentNullException("componentTypeName");
            if (mg == null) throw new ArgumentNullException("mg");
            var currentMethod = MethodBase.GetCurrentMethod().Name;
            string logMessageBase = currentMethod + " :: ";

            var retry = 10;
            try
            {
                var mPc = new ManagementPackComponentTypeCriteria("[Name] like '" + componentTypeName + "'");
                var mpView = mg.Dashboard.GetComponentTypes(mPc);
                while ((mpView.Count <= 0) && (retry > 0))
                {
                    mpView = mg.Dashboard.GetComponentTypes(mPc);
                    Sleeper.Delay(Constants.OneSecond);
                    retry--;
                }
                if ((mpView.Count > 0) && (mpView[0].DisplayName != null))
                {
                    LogMessage(string.Format("Utilities.GetDisplayStringForComponent:: Display Name: {0}", mpView[0].DisplayName));
                    return mpView[0].DisplayName;
                }
                LogMessage("There was an error loading ComponentType resource:: Display Name");
                return string.Empty;
            }
            catch (Exception e)
            {

                throw new Exception("There was an error loading ComponentType resource", e);
            }
        }

        /// <summary>
        /// Over load method for getting display String For component ,where it connect to default Mom Server
        /// </summary>
        /// <param name="componentTypeName"></param>
        /// <returns>display String</returns>
        /// <history>
        ///     [sunsingh] 26April10 - Created
        /// </history>
        public static  string GetDisplayStringForComponent(String componentTypeName)
        {
            try
            {
                var mg = ConnectToManagementServer();
                return Utilities.GetDisplayStringForComponent(componentTypeName, mg);
            }
            catch (Exception e)
            {

                throw new Exception("There was an error loading ComponentType resource", e);
            }
            
        }

        /// <summary>
        /// Get the Guid For the Componenet Type
        /// </summary>
        /// <returns>Guid For the Componenet Type</returns>
        ///  <history>
        ///     [sunsingh] 26April10 - Created
        /// </history>
        public static Guid GetGuidStringForComponent(String componentName)
        {
            if (componentName == null) throw new ArgumentNullException("componentName");
            string currentMethod = MethodBase.GetCurrentMethod().Name;
            string logMessageBase = currentMethod + " :: ";
            try
            {
                ManagementGroup mg = ConnectToManagementServer();
                var mPc = new ManagementPackComponentTypeCriteria("[Name] like '" + componentName + "'");
                IList<ManagementPackComponentType> mpView = mg.Dashboard.GetComponentTypes(mPc);

                if ((mpView.Count > 0))
                {
                    LogMessage("utiltites.GetGuidStringForComponent found for component : " + componentName);
                    return mpView[0].Id;
                }
                LogMessage("Failed utiltites.GetGuidStringForComponent to find Guid  for component : " + componentName);
                return Guid.Empty;
            }
            catch (Exception e)
            {

                throw new Exception("There was an error getting Guid For the component", e);
            }
            

        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the Display Name for User roles corresponding to a supplied UserRoleId Guid.
        /// </summary>
        /// <param name="userRoleId">a GUID corresponding to UserRoleId in UserRole table</param>        
        /// <returns>User Role's Display Name</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [ruhim] 12Mar07 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetUserRoleName(string userRoleId)
        {
            try
            {
                string returnString = null;
                Guid userRoleGuid = XmlConvert.ToGuid(userRoleId);
                ManagementGroup managementGroup = ConnectToManagementServer();

                foreach (Microsoft.EnterpriseManagement.Security.UserRole monitoringUserRole in managementGroup.Security.GetUserRoles())
                {
                    if (monitoringUserRole.Id == userRoleGuid)
                    {
                        if (monitoringUserRole.DisplayName != null)
                        {
                            Utilities.LogMessage("Utilities.GetUserRoleName:: User Role Display Name: "
                                + monitoringUserRole.DisplayName);
                            returnString = monitoringUserRole.DisplayName;
                            break;
                        }
                        else
                        {
                            Utilities.LogMessage("Utilities.GetUserRoleName:: User Role Name: "
                                + monitoringUserRole.Name);
                            returnString = monitoringUserRole.Name;
                            break;
                        }
                    }
                }

                // Returns null if no match found
                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetUserRoleName:: UserRoleId Guid: " + userRoleId + " Not Found !");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return a list of all non abstract Class's Display Names/Names specified in the Management Pack 
        /// corresponding to the supplied Guid.Uses SDK to get the ManagementPack Classes.
        /// </summary>
        /// <param name="managementPackNameGuid">a GUID corresponding to ManagementPackId in
        ///  ManagementPacks table</param>
        /// <returns>List ManagementPackClasses Names</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [ruhim] 06FEB06 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        public static List<string> GetManagementPackClasses(string managementPackNameGuid)
        {
            try
            {
                List<string> returnClasses = new List<string>();
                Utilities.LogMessage("Utilities.GetManagementPackName(...)");
                Guid managementPackGuid = XmlConvert.ToGuid(managementPackNameGuid);

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPack momManagementPack = managementGroup.ManagementPacks.GetManagementPack(managementPackGuid);
                Utilities.LogMessage("Utilities.GetManagementPackClasses:: Found the MP");

                foreach (ManagementPackClass MPClass in momManagementPack.GetClasses())
                {
                    // Get the display name of a class only if its not an Abstract class
                    // because UI won't show classes for scoping that are abstract
                    if (!MPClass.Abstract)
                    {
                        if (MPClass.DisplayName != null)
                        {
                            Utilities.LogMessage("Utilities.GetManagementPackClasses:: Class Display name: " + MPClass.DisplayName);
                            returnClasses.Add(MPClass.DisplayName);
                        }
                        else
                        {
                            Utilities.LogMessage("Utilities.GetManagementPackClasses:: Class Name: " + MPClass.Name);
                            returnClasses.Add(MPClass.Name);
                        }
                    }
                }

                return returnClasses;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetManagementPackClasses:: ManagementPack Guid: " + managementPackNameGuid + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackClasses:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// <summary>
        /// Returns the first Username in the ConnectionUserNames list. Assumes we have only one current 
        /// connection to the ManagementGroup.
        /// </summary>
        /// <returns></returns>
        public static string GetConnectedUsername()
        {
            ManagementGroup mg = ConnectToManagementServer();
            return mg.GetConnectedUserNames()[0];
        }

        /// <summary>
        /// Returns the ConnectedUserNames list for users connected to the ManagementGroup.
        /// </summary>
        /// <returns></returns>
        public IList<string> GetConnectedUsernames()
        {
            ManagementGroup mg = ConnectToManagementServer();
            return mg.GetConnectedUserNames();
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the displayName for a given class in the given MP 
        /// </summary>
        /// <param name="managementPackGuid">a GUID (as string) corresponding to ManagementPackId </param>
        /// <param name="className">Class Name </param>
        /// <returns>MP Class displayName</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [barryli] 26FEB07 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetManagementPackClassDisplayName(string managementPackGuid, string className)
        {
            try
            {
                string returnValue = "";

                Utilities.LogMessage("Utilities.GetManagementPackClassDisplayName(...)");

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPack momManagementPack = managementGroup.ManagementPacks.GetManagementPack(XmlConvert.ToGuid(managementPackGuid));
                Utilities.LogMessage("Utilities.GetManagementPackClassDisplayName:: Found the MP");

                ManagementPackClass MPClass = momManagementPack.GetClass(className);
                // Get the display name of a class only if its not an Abstract class
                // because UI won't show classes for scoping that are abstract
                /*if (!MPClass.Abstract)
                {*/
                if (MPClass.DisplayName != null)
                {
                    Utilities.LogMessage("Utilities.GetManagementPackClassDisplayName:: Class Display name: " + MPClass.DisplayName);
                    returnValue = MPClass.DisplayName;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetManagementPackClassDisplayName:: Class Name: " + MPClass.Name);
                    returnValue = MPClass.Name;
                }
                /*}*/

                return returnValue;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetManagementPackClassDisplayName:: ManagementPack Guid: " + managementPackGuid + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackClassDisplayName:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the displayName for a given class in the given MP
        /// </summary>
        /// <param name="managementPackGuid">a GUID (as string) corresponding to ManagementPackId</param>
        /// <param name="className">Class Name</param>
        /// <param name="subClassName">ClassName's SubElement name</param>
        /// <returns>MP Class displayName<</returns>
        /// <history>
        ///     [v-lileo] 2011/7/14 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetManagementPackClassDisplayName(string managementPackGuid, string className, string subClassName)
        {
            try
            {
                string returnValue = "";

                Utilities.LogMessage("Utilities.GetManagementPackClassDisplayName(...)");

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPack momManagementPack = managementGroup.ManagementPacks.GetManagementPack(XmlConvert.ToGuid(managementPackGuid));
                Utilities.LogMessage("Utilities.GetManagementPackClassDisplayName:: Found the MP");

                ManagementPackClass MPClass = momManagementPack.GetClass(className);

                if (MPClass[subClassName].DisplayName != null)
                {
                    Utilities.LogMessage("Utilities.GetManagementPackClassDisplayName:: Class Display name: " + MPClass[subClassName].DisplayName);
                    returnValue = MPClass[subClassName].DisplayName;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetManagementPackClassDisplayName:: Class Name: " + MPClass[subClassName].Name);
                    returnValue = MPClass[subClassName].Name;
                }

                return returnValue;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetManagementPackClassDisplayName:: ManagementPack Guid: " + managementPackGuid + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackClassDisplayName:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }
        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the displayName for a given monitor in the given MP 
        /// </summary>
        /// <param name="managementPackGuid">a GUID (as string) corresponding to ManagementPackId </param>
        /// <param name="monitorName">Monitor Name </param>
        /// <returns>MP Monitor displayName</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [v-yoz] 26MARCH09 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetManagementPackMonitorDisplayName(string managementPackGuid, string monitorName)
        {
            try
            {
                string returnValue = "";

                Utilities.LogMessage("Utilities.GetManagementPackMonitorDisplayName(...)");

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPack momManagementPack = managementGroup.ManagementPacks.GetManagementPack(XmlConvert.ToGuid(managementPackGuid));
                Utilities.LogMessage("Utilities.GetManagementPackMonitorDisplayName:: Found the MP");

                ManagementPackMonitor MPMonitor = momManagementPack.GetMonitor(monitorName);

                if (MPMonitor.DisplayName != null)
                {
                    Utilities.LogMessage("Utilities.GetManagementPackMonitorDisplayName:: Monitor Display name: " + MPMonitor.DisplayName);
                    returnValue = MPMonitor.DisplayName;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetManagementPackMonitorDisplayName:: Monitor Name: " + MPMonitor.Name);
                    returnValue = MPMonitor.Name;
                }

                return returnValue;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetManagementPackMonitorDisplayName:: ManagementPack Guid: " + managementPackGuid + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackMonitorDisplayName:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the displayName for a given rule in the given MP 
        /// </summary>
        /// <param name="managementPackGuid">a GUID (as string) corresponding to ManagementPackId </param>
        /// <param name="ruleName">Rule Name </param>
        /// <returns>MP Rule displayName</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [v-waltli] 05JUNE09 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetManagementPackRuleDisplayName(string managementPackGuid, string ruleName)
        {
            try
            {
                string returnValue = "";

                Utilities.LogMessage("Utilities.GetManagementPackRuleDisplayName(...)");

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPack momManagementPack = managementGroup.ManagementPacks.GetManagementPack(XmlConvert.ToGuid(managementPackGuid));
                Utilities.LogMessage("Utilities.GetManagementPackRuleDisplayName:: Found the MP");

                ManagementPackRule MPRule = momManagementPack.GetRule(ruleName);

                if (MPRule.DisplayName != null)
                {
                    Utilities.LogMessage("Utilities.GetManagementPackRuleDisplayName:: Rule Display name: " + MPRule.DisplayName);
                    returnValue = MPRule.DisplayName;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetManagementPackRuleDisplayName:: Rule Name: " + MPRule.Name);
                    returnValue = MPRule.Name;
                }

                return returnValue;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetManagementPackRuleDisplayName:: ManagementPack Guid: " + managementPackGuid + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackRuleDisplayName:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the displayName for a given string Resource in the given MP 
        /// </summary>
        /// <param name="managementPackGuid">a GUID (as string) corresponding to ManagementPackId </param>
        /// <param name="stringResourceName">StringResource Name </param>
        /// <returns>MP StringResource displayName</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [v-yoz] 26MARCH09 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetManagementPackStringResourceDisplayName(string managementPackGuid, string stringResourceName)
        {
            try
            {
                string returnValue = "";

                Utilities.LogMessage("Utilities.GetManagementPackStringResourceDisplayName(...)");

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPack momManagementPack = managementGroup.ManagementPacks.GetManagementPack(XmlConvert.ToGuid(managementPackGuid));
                Utilities.LogMessage("Utilities.GetManagementPackStringResourceDisplayName:: Found the MP");

                ManagementPackStringResource MPStringResource = momManagementPack.GetStringResource(stringResourceName);

                if (MPStringResource.DisplayName != null)
                {
                    Utilities.LogMessage("Utilities.GetManagementPackStringResourceDisplayName:: StringResource Display name: " + MPStringResource.DisplayName);
                    returnValue = MPStringResource.DisplayName;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetManagementPackStringResourceDisplayName:: StringResource Name: " + MPStringResource.Name);
                    returnValue = MPStringResource.Name;
                }

                return returnValue;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetManagementPackStringResourceDisplayName:: ManagementPack Guid: " + managementPackGuid + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackStringResourceDisplayName:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// <summary>
        /// Used to return the displayName for a given tab in the given MP 
        /// </summary>
        /// <param name="managementPackGuid">a GUID (as string) corresponding to ManagementPackId</param>
        /// <param name="pageSetId">page set Id</param>
        /// <param name="pageReferenceId">page reference Id</param>
        /// <param name="tabNameId">tab name Id</param>
        /// <returns>Display string of tab</returns>
        /// <history>
        ///     [v-brucec] 29JAN10 - Created        
        /// </history>
        public static string GetUIPageReferenceTabName(string managementPackGuid, string pageSetId, string pageReferenceId, string tabNameId)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");

            try
            {
                string returnString = null;
                ManagementGroup managementGroup = ConnectToManagementServer();

                Microsoft.EnterpriseManagement.Configuration.ManagementPack momManagementPack = 
                    managementGroup.GetManagementPack(XmlConvert.ToGuid(managementPackGuid));
                Utilities.LogMessage(currentMethod + ":: Found the MP:" + momManagementPack.Name);

                ManagementPackUIPageSet pageSet = momManagementPack.GetUIPageSet(pageSetId);
                if (pageSet != null)
                {
                    foreach (ManagementPackUIPageReference pageReference in pageSet.UIPageReferenceCollection)
                    {
                        if ((string.Compare(pageReference.Name, pageReferenceId, true) == 0) && (string.Compare(pageReference.TabName.Name, tabNameId) == 0))
                        {
                            ManagementPackDisplayString mpDisplayString = pageReference.TabName.GetDisplayString(CultureInfo.CurrentCulture);
                            Utilities.LogMessage(currentMethod + ":: Found the tab name:" + mpDisplayString.Name + " with sub element name:" + mpDisplayString.SubElementName);
                            returnString = mpDisplayString.Name;
                            break;
                        }
                    }

                    if (string.IsNullOrEmpty(returnString))
                    {
                        throw new ObjectNotFoundException(currentMethod + "::Could not get tab name.");
                    }
                }
                else
                {
                    throw new ObjectNotFoundException(currentMethod + "::Could not find page set.");
                }
                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage(currentMethod + ":: ManagementPack Guid: " + managementPackGuid + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage(currentMethod + ":: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
            finally
            {
                Utilities.LogMessage(currentMethod + ":: end");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return a list of all Tasks's Display Names/Names specified in the Management Pack 
        /// corresponding to the supplied Guid.Uses SDK to get the ManagementPack Tasks.
        /// </summary>
        /// <param name="managementPackNameGuid">a GUID corresponding to ManagementPackId in
        ///  ManagementPacks table</param>
        /// <returns>List ManagementPackTasks Names</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [ruhim] 06FEB06 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        public static List<string> GetManagementPackTasks(string managementPackNameGuid)
        {
            try
            {
                List<string> returnTasks = new List<string>();
                Utilities.LogMessage("Utilities.GetManagementPackName(...)");
                Guid managementPackGuid = XmlConvert.ToGuid(managementPackNameGuid);

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPack momManagementPack = managementGroup.ManagementPacks.GetManagementPack(managementPackGuid);
                Utilities.LogMessage("Utilities.GetManagementPackTasks:: Found the MP");

                foreach (ManagementPackTask MPTask in momManagementPack.GetTasks())
                {
                    if (MPTask.DisplayName != null)
                    {
                        Utilities.LogMessage("Utilities.GetManagementPackTasks:: Task Display name: "
                            + MPTask.DisplayName);
                        returnTasks.Add(MPTask.DisplayName);
                    }
                    else
                    {
                        Utilities.LogMessage("Utilities.GetManagementPackTasks:: Task Name: "
                            + MPTask.Name);
                        returnTasks.Add(MPTask.Name);
                    }
                }

                return returnTasks;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetManagementPackTasks:: ManagementPack Guid: " + managementPackNameGuid + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackTasks:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns the DisplayName of a ManagementPackTask given its name.
        /// </summary>
        /// <param name="managementPackNameGuid">a GUID corresponding to ManagementPackId in
        ///  ManagementPacks table</param>
        ///  <param name="taskName">Task name.</param>
        /// <returns>ManagementPackTask.DisplayName property.</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [v-chunya] 27MAY09 - Created      
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetManagementPackTaskDisplayName(string managementPackNameGuid, string taskName)
        {
            try
            {
                Utilities.LogMessage("Utilities.GetManagementPackTaskDisplayName(...)");
                Guid managementPackGuid = XmlConvert.ToGuid(managementPackNameGuid);

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPack momManagementPack = managementGroup.ManagementPacks.GetManagementPack(managementPackGuid);
                Utilities.LogMessage("Utilities.GetManagementPackTaskDisplayName:: Found the MP" + managementPackGuid.ToString());

                return momManagementPack.GetTask(taskName).DisplayName;
            }
            catch (ObjectNotFoundException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackTaskDisplayName:: got ObjectNotFoundException: " + e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackTaskDisplayName:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns the DisplayName of a ManagementPackView given its name.
        /// </summary>
        /// <param name="managementPackNameGuid">a GUID corresponding to ManagementPackId in
        ///  ManagementPacks table</param>
        ///  <param name="viewName">View name.</param>
        /// <returns>ManagementPackView.DisplayName property.</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [shreedp] MAY10 - Created      
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetManagementPackViewDisplayName(string managementPackNameGuid, string viewName)
        {
            try
            {
                Utilities.LogMessage("Utilities.GetManagementPackViewDisplayName(...)");
                Guid managementPackGuid = XmlConvert.ToGuid(managementPackNameGuid);

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPack managementPack = managementGroup.ManagementPacks.GetManagementPack(managementPackGuid);
                Utilities.LogMessage("Utilities.GetManagementPackViewDisplayName:: Found the MP");

                return managementPack.GetView(viewName).DisplayName;
            }
            catch (ObjectNotFoundException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackViewDisplayName:: got ObjectNotFoundException: " + e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackViewDisplayName:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns the DisplayName of a ManagementPackConsoleTask given its name.
        /// </summary>
        /// <param name="managementPackNameGuid">a GUID corresponding to ManagementPackId in
        ///  ManagementPacks table</param>
        ///  <param name="consoleTaskName">Console Task name.</param>
        /// <returns>ManagementPackConsoleTask.DisplayName property.</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [a-joelj] 20NOV09 - Created      
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetManagementPackConsoleTaskDisplayName(string managementPackNameGuid, string consoleTaskName)
        {
            try
            {
                Utilities.LogMessage("Utilities.GetManagementPackConsoleTaskDisplayName(...)");
                Guid managementPackGuid = XmlConvert.ToGuid(managementPackNameGuid);

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPack momManagementPack = managementGroup.ManagementPacks.GetManagementPack(managementPackGuid);
                Utilities.LogMessage("Utilities.GetManagementPackConsoleTaskDisplayName:: Found the MP");

                return momManagementPack.GetConsoleTask(consoleTaskName).DisplayName;
            }
            catch (ObjectNotFoundException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackTaskDisplayName:: got ObjectNotFoundException: " + e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackTaskDisplayName:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return a list of all Views's Display Names/Names specified in the Management Pack 
        /// corresponding to the supplied Guid.Uses SDK to get the ManagementPack Views.
        /// </summary>
        /// <param name="managementPackNameGuid">a GUID corresponding to ManagementPackId in
        ///  ManagementPacks table</param>
        /// <returns>List ManagementPackViews Names</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [ruhim] 06FEB06 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        public static List<string> GetManagementPackViews(string managementPackNameGuid)
        {
            try
            {
                List<string> returnViews = new List<string>();
                Utilities.LogMessage("Utilities.GetManagementPackName(...)");
                Guid managementPackGuid = XmlConvert.ToGuid(managementPackNameGuid);

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPack momManagementPack = managementGroup.ManagementPacks.GetManagementPack(managementPackGuid);
                Utilities.LogMessage("Utilities.GetManagementPackViews:: Found the MP");

                foreach (ManagementPackView MPView in momManagementPack.GetViews())
                {
                    if (MPView.DisplayName != null)
                    {
                        Utilities.LogMessage("Utilities.GetManagementPackViews:: View Display name: "
                            + MPView.DisplayName);
                        returnViews.Add(MPView.DisplayName);
                    }
                    else
                    {
                        Utilities.LogMessage("Utilities.GetManagementPackViews:: View Name: "
                            + MPView.Name);
                        returnViews.Add(MPView.Name);
                    }
                }

                return returnViews;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetManagementPackViews:: ManagementPack Guid: " + managementPackNameGuid + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackViews:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// <summary>
        /// Gets Discovery Object from the specified ManagementPack.
        /// </summary>
        /// <param name="managementPackGuid">GUID corresponding to ManagementPackId in the ManagementPacks table</param>
        /// <param name="discoveryName">Discovery ID/Name</param>
        /// <returns>ManagementPackDiscovery object</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [nathd] 09JUN22 Created 
        /// </history>
        public static ManagementPackDiscovery GetManagementPackDiscovery(string managementPackGuid, string discoveryName)
        {
            try
            {
                Utilities.LogMessage("Utilities.GetManagementPackDiscovery ::");

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPack mp = managementGroup.ManagementPacks.GetManagementPack(XmlConvert.ToGuid(managementPackGuid));
                Utilities.LogMessage("Utilities.GetManagementPackDiscovery:: Found the MP");

                return mp.GetDiscovery(discoveryName);
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetManagementPackDiscovery :: Management Pack Guid: " + managementPackGuid + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackDiscovery :: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// <summary>
        /// Gets Diagnostic Object from the specified ManagementPack.
        /// </summary>
        /// <param name="managementPackGuid">GUID corresponding to ManagementPackId in the ManagementPacks table</param>
        /// <param name="diagnosticName">Diagnostic ID/Name</param>
        /// <returns>ManagementPackDiagnostic object</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [nathd] 09JUN22 Created 
        /// </history>
        public static ManagementPackDiagnostic GetManagementPackDiagnostic(string managementPackGuid, string diagnosticName)
        {
            try
            {
                Utilities.LogMessage("Utilities.GetManagementPackDiagnostic ::");

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPack mp = managementGroup.ManagementPacks.GetManagementPack(XmlConvert.ToGuid(managementPackGuid));
                Utilities.LogMessage("Utilities.GetManagementPackDiagnostic:: Found the MP");

                return mp.GetDiagnostic(diagnosticName);

            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetManagementPackDiagnostic :: Management Pack Guid: " + managementPackGuid + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackDiagnostic :: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// <summary>
        /// Gets Recovery Object from the specified ManagementPack.
        /// </summary>
        /// <param name="managementPackGuid">GUID corresponding to ManagementPackId in the ManagementPacks table</param>
        /// <param name="recoveryName">Recovery ID/Name</param>
        /// <returns>ManagementPackRecovery object</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [nathd] 09JUN22 Created 
        /// </history>
        public static ManagementPackRecovery GetManagementPackRecovery(string managementPackGuid, string recoveryName)
        {
            try
            {
                Utilities.LogMessage("Utilities.GetManagementPackRecovery ::");

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPack mp = managementGroup.ManagementPacks.GetManagementPack(XmlConvert.ToGuid(managementPackGuid));
                Utilities.LogMessage("Utilities.GetManagementPackRecovery:: Found the MP");

                return mp.GetRecovery(recoveryName);
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetManagementPackRecovery :: Management Pack Guid: " + managementPackGuid + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPackRecovery :: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// <summary>
        /// Returns a ReadOnlyCollection of ManagementPacks based on the criteria specified.
        /// </summary>
        /// <param name="criteria">Criteria used to fetch ManagementPack Collection</param>
        /// <returns>ReadOnlyCollection of ManagementPacks</returns>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [nathd] 09JUN22 Created 
        /// </history>
        public static System.Collections.Generic.IList<ManagementPack> GetManagementPacks(string criteria)
        {
            try
            {
                Utilities.LogMessage("Utilities.GetManagementPacks ::");

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPackCriteria mpCriteria =
                    new ManagementPackCriteria(criteria);

                Utilities.LogMessage("Utilities.GetManagementPacks :: ManagementPackCriteria: '" + criteria + "'");

                return managementGroup.ManagementPacks.GetManagementPacks(mpCriteria);
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetManagementPacks :: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// <summary>
        /// Gets the overrideable parameter name for the specified parameter on the diagnostic.
        /// </summary>
        /// <param name="monitoringDiagnosticNameGuid">MonitoringDiagnostic Guid</param>
        /// <param name="OverrideParameterGuid">OverrideableParameter Guid</param>
        /// <returns>DisplayName for the specified OverrideableParameter</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [nathd] 09JUN23 Created
        /// </history>
        public static string GetDiagnosticOverrideableParameterName(Guid monitoringDiagnosticNameGuid, Guid OverrideParameterGuid)
        {
            try
            {
                string parameterName = null;
                Utilities.LogMessage("Utilities.GetDiagnosticOverrideableParameterName ::");

                ManagementGroup managementGroup = ConnectToManagementServer();
                ManagementPackDiagnostic diagnostic = managementGroup.Monitoring.GetDiagnostic(monitoringDiagnosticNameGuid);
                Utilities.LogMessage("Utilities.GetDiagnosticOverrideableParameterName :: Found the Monitoring Diagnostic: " + diagnostic.DisplayName);
                Utilities.LogMessage("Utilities.GetDiagnosticOverrideableParameterName :: Override Parameter ID : " + OverrideParameterGuid);

                foreach (ManagementPackOverrideableParameter diagOverride in diagnostic.GetOverrideableParameters())
                {
                    if (diagOverride.Id == OverrideParameterGuid)
                    {
                        if (diagOverride.DisplayName != null)
                        {
                            Utilities.LogMessage("Utilities.GetDiagnosticOverrideableParameterName :: Overridable Parameter Display name: " + diagOverride.DisplayName);
                            parameterName = diagOverride.DisplayName;
                        }
                        else
                        {
                            Utilities.LogMessage("Utilities.GetDiagnosticOverrideableParameterName :: Overridable Parameter Name: " + diagOverride.Name);
                            parameterName = diagOverride.Name;
                        }
                        break; //break once match found
                    }
                }

                return parameterName;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetDiagnosticOverrideableParameterName :: Monitoring Diagnostic Guid: " + monitoringDiagnosticNameGuid + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetDiagnosticOverrideableParameterName :: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// <summary>
        /// Gets the overrideable parameter name for the specified parameter on the recovery.
        /// </summary>
        /// <param name="monitoringRecoveryNameGuid">MonitoringRecovery Guid</param>
        /// <param name="OverrideParameterGuid">OverrideableParameter Gsuid</param>
        /// <returns>DisplayName for the specified OverrideableParameter</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [nathd] 09JUN23 Created
        /// </history>
        public static string GetRecoveryOverrideableParameterName(Guid monitoringRecoveryNameGuid, Guid OverrideParameterGuid)
        {
            try
            {
                string parameterName = null;
                Utilities.LogMessage("Utilities.GetRecoveryOverrideableParameterName ::");

                ManagementGroup managementGroup = ConnectToManagementServer();
                ManagementPackRecovery recovery = managementGroup.Monitoring.GetRecovery(monitoringRecoveryNameGuid);
                Utilities.LogMessage("Utilities.GetRecoveryOverrideableParameterName :: Found the Monitoring Recovery: " + recovery.DisplayName);
                Utilities.LogMessage("Utilities.GetRecoveryOverrideableParameterName :: Override Parameter ID : " + OverrideParameterGuid);

                foreach (ManagementPackOverrideableParameter recoveryOverride in recovery.GetOverrideableParameters())
                {
                    if (recoveryOverride.Id == OverrideParameterGuid)
                    {
                        if (recoveryOverride.DisplayName != null)
                        {
                            Utilities.LogMessage("Utilities.GetRecoveryOverrideableParameterName :: Overridable Parameter Display name: " + recoveryOverride.DisplayName);
                            parameterName = recoveryOverride.DisplayName;
                        }
                        else
                        {
                            Utilities.LogMessage("Utilities.GetRecoveryOverrideableParameterName :: Overridable Parameter Name: " + recoveryOverride.Name);
                            parameterName = recoveryOverride.Name;
                        }
                        break; //break once match found
                    }
                }

                return parameterName;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetRecoveryOverrideableParameterName :: Monitoring Recovery Guid: " + monitoringRecoveryNameGuid + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetRecoveryOverrideableParameterName :: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns alert name/null for a monitor
        /// </summary>
        /// <param name="monitorGUID">a GUID corresponding to MonitorID in Monitor table</param>
        /// <returns>Alert Name</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [visnara] 30APR07 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetMonitorAlertName(Guid monitorGUID)
        {
            string alertName = null;
            try
            {
                Utilities.LogMessage("Utilities.GetMonitorAlertName(...)");

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPackMonitor momMonitor = managementGroup.Monitoring.GetMonitor(monitorGUID);
                Utilities.LogMessage("Utilities.GetMonitorAlertName:: Found Monitor: " + momMonitor.Name);
                if (momMonitor.AlertSettings.AlertMessage.GetElement() != null)
                {
                    Utilities.LogMessage("Utilities.GetMonitorAlertName:: AlertName ='" + momMonitor.AlertSettings.AlertMessage.GetElement().DisplayName + "'");
                    alertName = momMonitor.AlertSettings.AlertMessage.GetElement().DisplayName;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetMonitorAlertName:: Monitor isn't an alert generating one!! ");
                }
                return alertName;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetMonitorAlertName:: Monitor Guid: " + monitorGUID + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetMonitorAlertName:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns alert name/null for a rule
        /// </summary>
        /// <param name="ruleGUID">a GUID corresponding to RuleID in Rules table</param>
        /// <returns>Alert Name</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [a-joelj] 25MAR09 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetMonitoringRuleAlertName(Guid ruleGUID)
        {
            string alertName = null;
            try
            {
                Utilities.LogMessage("Utilities.GetMonitoringRuleAlertName(...)");

                ManagementGroup managementGroup = ConnectToManagementServer();

                Microsoft.EnterpriseManagement.Configuration.ManagementPackRule momRuleAlert = managementGroup.Monitoring.GetRule(ruleGUID);

                Utilities.LogMessage("Utilities.GetMonitoringRuleAlertName:: Found Rule: " + momRuleAlert.Name);
                if (momRuleAlert.DisplayName != null)
                {
                    Utilities.LogMessage("Utilities.GetMonitoringRuleAlertName:: AlertName ='" + momRuleAlert.DisplayName + "'");
                    alertName = momRuleAlert.DisplayName;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetMonitoringRuleAlertName:: Rule Alert DisplayName is null!! ");
                    Utilities.LogMessage("Utilities.GetMonitoringRuleAlertName:: Returning Rule Alert Name instead ");
                    alertName = momRuleAlert.Name;
                }
                return alertName;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetMonitoringRuleAlertName:: Rule Guid: " + ruleGUID + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetMonitoringRuleAlertName:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns alert description/null for a monitor
        /// </summary>
        /// <param name="monitorGUID">a GUID corresponding to MonitorID in Monitor table</param>
        /// <returns>Alert Description</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [Ruhim] 12May08 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetMonitorAlertDescription(Guid monitorGUID)
        {
            string alertDescription = null;
            try
            {
                Utilities.LogMessage("Utilities.GetMonitorAlertDescription(...)");

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPackMonitor momMonitor = managementGroup.Monitoring.GetMonitor(monitorGUID);
                Utilities.LogMessage("Utilities.GetMonitorAlertDescription:: Found Monitor: " + momMonitor.Name);
                if (momMonitor.AlertSettings.AlertMessage.GetElement() != null)
                {
                    Utilities.LogMessage("Utilities.GetMonitorAlertDescription:: Initial Alert Description ='" + momMonitor.AlertSettings.AlertMessage.GetElement().Description + "'");
                    alertDescription = momMonitor.AlertSettings.AlertMessage.GetElement().Description;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetMonitorAlertDescription:: Monitor isn't an alert generating one!! ");
                }
                //replacing variables with alert parameters
                string param;
                string alertParam;

                for (int i = 0; i <= 9; i++)
                {
                    param = "{" + i.ToString() + "}";

                    if (alertDescription.Contains(param))
                    {
                        alertParam = GetAlertParameterValue(momMonitor.AlertSettings, i + 1);
                        Utilities.LogMessage("Utilities.GetMonitorAlertDescription:: Alert Parameter value is " + alertParam);
                        alertDescription = alertDescription.Replace(param, alertParam);
                        Utilities.LogMessage("Utilities.GetMonitorAlertDescription:: Alert Description is " + alertDescription);
                    }
                    else
                    {
                        Utilities.LogMessage("Utilities.GetMonitorAlertDescription:: No more alert parameters to replace");
                        break;
                    }
                }

                Utilities.LogMessage("Utilities.GetMonitorAlertDescription:: Transformed Alert Description is '" + alertDescription + "'");
                return alertDescription;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetMonitorAlertDescription:: Monitor Guid: " + monitorGUID + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetMonitorAlertDescription:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns alert description/null for a rule
        /// </summary>
        /// <param name="ruleGUID">a GUID corresponding to RuleID in Rules table</param>
        /// <returns>Alert Description</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [Ruhim] 18May08 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetRuleAlertDescription(Guid ruleGUID)
        {
            string alertDescription = null;
            string tmpAlertMsgDescription = "";

            try
            {
                Utilities.LogMessage("Utilities.GetRuleAlertDescription(...)");

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Configuration.ManagementPackRule momRule = managementGroup.Monitoring.GetRule(ruleGUID);
                Utilities.LogMessage("Utilities.GetRuleAlertDescription:: Found Rule: " + momRule.Name);

                //alertDescription = GetAlertMsgDescription(momRule);  
                // First get the AlertMessageId from the MonitoringRule
                XmlDocument configurationXmlDoc = null;
                string alertMsgID = GetAlertMsgID(momRule, out configurationXmlDoc);
                string alertMsgIDElement = "[ManagementPackElement=" + alertMsgID + "]";

                // Now get the language pack from the Monitoring Rule
                ManagementPackLanguagePack langPack = momRule.GetManagementPack().GetLanguagePack(CultureInfo.CurrentCulture);

                for (int i = 0; i < langPack.DisplayStringCollection.Count; i++)
                {
                    if (langPack.DisplayStringCollection[i].ToString() == alertMsgIDElement)
                    {
                        tmpAlertMsgDescription = langPack.DisplayStringCollection[i].Description;
                        Utilities.LogMessage("Utilities.GetRuleAlertDescription:: Found: " + alertMsgIDElement + " Description: " + tmpAlertMsgDescription);
                    }
                }

                // Now we have alertMsgDescription in the following form
                // Event Description: {0}
                // Replace the {0} with values of AlertParameter*
                alertDescription = SubstituteAlertParams(tmpAlertMsgDescription, configurationXmlDoc);
                Utilities.LogMessage("Utilities.GetRuleAlertDescription:: Final value for Rule Alert Description: " + alertDescription);

                return alertDescription;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetRuleAlertDescription:: Monitor Guid: " + ruleGUID + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetRuleAlertDescription:: " + e.Message + " Property= " + e.ParamName + "!");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return the Monitoring Folder Hierarchy corresponding to the
        /// supplied Folder Guid using SDK calls
        /// </summary>
        /// <param name="folderGuid">a GUID corresponding to FolderId in Fo
        ///  MonitorType table</param>
        /// <returns>Folder Hierarchy</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <history>
        ///     [ruhim] 21Jun06 - Created   
        ///     [manishg/nathd] - Updated to use new SM SDK. MonitoringFolder to ManagementPackFolder
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetMonitorFolderHierarchy(Guid folderGuid)
        {
            try
            {
                string returnString = null;
                ManagementGroup managementGroup = ConnectToManagementServer();

                ManagementPackFolder monitorFolder = managementGroup.Presentation.GetFolder(folderGuid);
                if (monitorFolder.DisplayName != null)
                {
                    Utilities.LogMessage("Utilities.GetMonitorFolderHierarchy:: Folder Display Name: "
                        + monitorFolder.DisplayName);
                    returnString = returnString + monitorFolder.DisplayName;
                }
                else
                {
                    Utilities.LogMessage("Utilities.GetMonitorFolderHierarchy:: Folder name: "
                        + monitorFolder.Name);
                    returnString = returnString + monitorFolder.Name;
                }

                Microsoft.EnterpriseManagement.Common.HierarchyNode<ManagementPackFolder> monitorFolderHierarchy = managementGroup.Presentation.GetFolderHierarchy(monitorFolder.Id);

                //New root folder added to Monitoring and Administration Navigation space which is not visible hence needs to be excluded from the path hierarchy
                Guid viewRootGuid = new Guid(ManagementPackReferences.MICROSOFT_SYSTEMCENTER_VIEWFOLDER_ROOT_REFERENCE);
                while (monitorFolderHierarchy.ParentNode != null &&
                     monitorFolderHierarchy.ParentNode.Item.Id != viewRootGuid)
                {
                    ManagementPackFolder currentMonitorFolder = monitorFolderHierarchy.ParentNode.Item;
                    if (monitorFolderHierarchy.ParentNode.Item.DisplayName != null)
                    {
                        Utilities.LogMessage("Utilities.GetMonitorFolderHierarchy:: Parent Folder Display Name: "
                            + monitorFolderHierarchy.ParentNode.Item.DisplayName);
                        returnString = monitorFolderHierarchy.ParentNode.Item.DisplayName
                                        + Constants.PathDelimiter
                                        + returnString;
                    }
                    else
                    {
                        Utilities.LogMessage("Utilities.GetMonitorFolderHierarchy:: Parent Folder Name: "
                            + monitorFolderHierarchy.ParentNode.Item.Name);
                        returnString = monitorFolderHierarchy.ParentNode.Item.Name
                                        + Constants.PathDelimiter
                                        + returnString;
                    }
                    monitorFolderHierarchy = managementGroup.Presentation.GetFolderHierarchy(currentMonitorFolder.Id);
                }
                Utilities.LogMessage("Utilities.GetMonitorFolderHierarchy:: Folder Path is: "
                                    + returnString);
                return returnString;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetMonitorFolderHierarchy:: Folder Guid: " + folderGuid.ToString() + " Not Found !");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return Display Name of a specific overridable Parameter for a specific Monitoring Rule
        /// </summary>
        /// <param name="monitoringRuleNameGuid">a GUID corresponding to the Monitoring Rule 
        /// for which the Override Parameters Name is required</param>
        /// <param name="OverrideParameterGuid">a GUID corresponding to the Override Parameter Name is required</param>
        /// <returns>Overrideable Parameter Name</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [ruhim] 27Sep06 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetRuleOverrideableParameterName(Guid monitoringRuleNameGuid, Guid OverrideParameterGuid)
        {
            try
            {
                string parameterName = null;
                Utilities.LogMessage("Utilities.GetRuleOverrideableParameterName(...)");

                ManagementGroup managementGroup = ConnectToManagementServer();
                ManagementPackRule rule = managementGroup.Monitoring.GetRule(monitoringRuleNameGuid);
                Utilities.LogMessage("Utilities.GetRuleOverrideableParameterName:: Found the Monitoring Rule: " + rule.DisplayName);
                Utilities.LogMessage("Utilities.GetRuleOverrideableParameterName:: Override Parameter ID : " + OverrideParameterGuid);

                foreach (ManagementPackOverrideableParameter ruleOverride in rule.GetOverrideableParameters())
                {
                    if (ruleOverride.Id == OverrideParameterGuid)
                    {
                        if (ruleOverride.DisplayName != null)
                        {
                            Utilities.LogMessage("Utilities.GetRuleOverrideableParameterName:: Overridable Parameter Display name: " + ruleOverride.DisplayName);
                            parameterName = ruleOverride.DisplayName;
                        }
                        else
                        {
                            Utilities.LogMessage("Utilities.GetRuleOverrideableParameterName:: Overridable Parameter Name: " + ruleOverride.Name);
                            parameterName = ruleOverride.Name;
                        }
                        break; //break once match found
                    }
                }

                return parameterName;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetRuleOverrideableParameterName:: Monitoring Rule Guid: " + monitoringRuleNameGuid + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetRuleOverrideableParameterName:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return Display Name of a specific overridable Parameter for a specific Monitor
        /// </summary>
        /// <param name="monitorNameGuid">a GUID corresponding to the Monitor for which the Override Parameters Name is required</param>
        /// <param name="OverrideParameterGuid">a GUID corresponding to the Override Parameter Name is required</param>
        /// <returns>Overrideable Parameter Name</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [v-brucec] 13Oct09 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetMonitorOverrideableParameterName(Guid monitorNameGuid, Guid OverrideParameterGuid)
        {
            try
            {
                string parameterName = null;
                Utilities.LogMessage("Utilities.GetMonitorOverrideableParameterName(...)");
                ManagementGroup managementGroup = ConnectToManagementServer();
                ManagementPackUnitMonitorType momUnitMonitorType = managementGroup.Monitoring.GetUnitMonitorType(monitorNameGuid);

                Utilities.LogMessage("Utilities.GetMonitorOverrideableParameterName:: Found the Monitor: " + momUnitMonitorType.DisplayName);
                Utilities.LogMessage("Utilities.GetMonitorOverrideableParameterName:: Override Parameter ID : " + OverrideParameterGuid);

                foreach (ManagementPackOverrideableParameter monitorOverride in momUnitMonitorType.OverrideableParameterCollection)
                {
                    if (monitorOverride.Id == OverrideParameterGuid)
                    {
                        if (monitorOverride.DisplayName != null)
                        {
                            Utilities.LogMessage("Utilities.GetMonitorOverrideableParameterName:: Overridable Parameter Display name: " + monitorOverride.DisplayName);
                            parameterName = monitorOverride.DisplayName;
                        }
                        else
                        {
                            Utilities.LogMessage("Utilities.GetMonitorOverrideableParameterName:: Overridable Parameter Name: " + monitorOverride.Name);
                            parameterName = monitorOverride.Name;
                        }
                        break; //break once match found
                    }
                }

                return parameterName;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetMonitorOverrideableParameterName:: Monitor Guid: " + monitorNameGuid + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetMonitorOverrideableParameterName:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return Display Name of a specific overridable Parameter for a specific ManagementPack DataSourceModuleType
        /// </summary>
        /// <param name="ManagementPackNameGuid">a GUID corresponding to ManagementPack Name </param>
        /// <param name="ManagementPackDataSourceModuleTypeName">>Name of ManagementPack DataSourceModuleType </param>
        /// <param name="OverrideParameterGuid">a GUID corresponding to the Override Parameter Name is required</param>
        /// <returns>>Overrideable Parameter Name</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [v-lileo] 02Feb10 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetMonitorDataSourceModuleTypeOverrideParameterName(string ManagementPackNameGuid, string ManagementPackDataSourceModuleTypeName, Guid OverrideParameterGuid)
        {
            try
            {
                string parameterName = null;
                Utilities.LogMessage("Utilities.GetMonitorDataSourceModuletypeParameterName(...)");
                ManagementGroup managementGroup = ConnectToManagementServer();
                ManagementPack momManagementPack = managementGroup.ManagementPacks.GetManagementPack(XmlConvert.ToGuid(ManagementPackNameGuid));
                ManagementPackDataSourceModuleType momDataSourceModuleType = (ManagementPackDataSourceModuleType)momManagementPack.GetModuleType(ManagementPackDataSourceModuleTypeName);
                Utilities.LogMessage("Utilities.GetMonitorDataSourceModuletypeParameterName:: Found the ManagementPackDataSourceModuleType: " + momDataSourceModuleType.DisplayName);
                Utilities.LogMessage("Utilities.GetMonitorDataSourceModuletypeParameterName:: Override Parameter ID : " + OverrideParameterGuid);

                foreach (ManagementPackOverrideableParameter dataSourceOverride in momDataSourceModuleType.OverrideableParameterCollection)
                {
                    if (dataSourceOverride.Id == OverrideParameterGuid)
                    {
                        if (dataSourceOverride.DisplayName != null)
                        {
                            Utilities.LogMessage("Utilities.GetMonitorOverrideableParameterName:: Overridable Parameter Display name: " + dataSourceOverride.DisplayName);
                            parameterName = dataSourceOverride.DisplayName;
                        }
                        else
                        {
                            Utilities.LogMessage("Utilities.GetMonitorOverrideableParameterName:: Overridable Parameter Name: " + dataSourceOverride.Name);
                            parameterName = dataSourceOverride.Name;
                        }
                        break; //break once match found
                    }
                }

                return parameterName;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage("Utilities.GetMonitorOverrideableParameterName:: ManagementPackDataSourceModuleType Name: " + ManagementPackDataSourceModuleTypeName + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage("Utilities.GetMonitorOverrideableParameterName:: " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns alert description/null for a given Alert
        /// </summary>
        /// <param name="alertGUID">a GUID corresponding to an alert in DB</param>
        /// <returns>Alert Description</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [Ruhim] 26May08 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetAlertDescription(Guid alertGUID)
        {
            string alertDescription = null;
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                Utilities.LogMessage(currentMethod + "(...)");

                ManagementGroup managementGroup = ConnectToManagementServer();
                Microsoft.EnterpriseManagement.Monitoring.MonitoringAlert momAlert = managementGroup.OperationalData.GetMonitoringAlert(alertGUID);
                Utilities.LogMessage(currentMethod + "::" + " Found alert: " + momAlert.Name);
                if (momAlert.Description != null)
                {
                    Utilities.LogMessage(currentMethod + "::" + " Alert Description for the given alert ='" + momAlert.Description + "'");
                    alertDescription = momAlert.Description;
                }
                else
                {
                    Utilities.LogMessage(currentMethod + "::" + " Alert Description for the given alert is null!! ");
                }

                return alertDescription;
            }
            catch (ObjectNotFoundException)
            {
                Utilities.LogMessage(currentMethod + "::" + " Alert Guid: " + alertGUID + " Not Found !");
                throw;
            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage(currentMethod + "::" + " " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns the LogDisplayName for a given EventLog
        /// </summary>
        /// <param name="eventLogName">Name of an Event Log</param>
        /// <param name="machineName">Name of the machine to get EventLogs from</param>
        /// <returns>EventLog.LogDisplayName</returns>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">ArgumentOutOfRangeException</exception>
        /// <history>
        ///     [a-joelj] 14APR09 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetEventLogDisplayName(string machineName, string eventLogName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                Utilities.LogMessage(currentMethod + "(...)");
                Utilities.LogMessage(currentMethod + "::" + " Connecting to " + machineName + " to get the LogDisplayName for the " + eventLogName + " log");

                // Get EventLog collection from a particular machine
                EventLog[] eLog = EventLog.GetEventLogs(machineName);

                bool foundMatch = false;

                // Iterate through the logs until we find a match
                foreach (EventLog e in eLog)
                {
                    if (e.Log == eventLogName)
                    {
                        // Found a match for Log name
                        foundMatch = true;

                        Utilities.LogMessage(currentMethod + "::" + " found the LogDisplayName for: " + e.Log + " log");
                        Utilities.LogMessage(currentMethod + "::" + " LogDisplayName is: " + e.LogDisplayName);

                        // Return LogDisplayName
                        return e.LogDisplayName;
                    }
                }

                // EventLog name not found, using original string eventLogName (must be a custom EventLog)
                if (!foundMatch)
                {
                    Utilities.LogMessage(currentMethod + "::" + " LogDisplayName for " + eventLogName + " log not found");
                    Utilities.LogMessage(currentMethod + "::" + " using original Log Name: " + eventLogName);
                }

                // No match found so we return the original EventLog name
                return eventLogName;

            }
            catch (ArgumentNullException e)
            {
                Utilities.LogMessage(currentMethod + "::" + " " + e.Message + " Property=" + e.ParamName + "!");
                throw;
            }
            catch (ArgumentOutOfRangeException argEx)
            {
                Utilities.LogMessage(currentMethod + "::" + " " + argEx.Message + " Property=" + argEx.ParamName + "!");
                throw;
            }
        }


        #endregion
        ///// <summary>
        ///// Send changes to windows for registry settings changes.
        ///// </summary>       
        ///// <returns>UIntPtr</returns>
        //public static UIntPtr Notify_RegistrySettingChange()
        //{
        //    UIntPtr result;
        //    string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

        //    NativeMethods.SendMessageTimeout(HWND_BROADCAST, (uint)WM_SETTINGCHANGE,
        //                       UIntPtr.Zero, "Internet Settings",
        //                        Core.Common.NativeMethods.SendMessageTimeoutFlags.SMTO_BLOCK, 10000, out result);// wait for method to return

        //    return result;
        //}

        /// <summary>
        /// Runs the specified SQL query against MOM Server
        /// </summary>
        /// <param name="serverName">MOM Server Name</param>
        /// <param name="sqlQuery">SQL query to be executed against MOM Server</param>
        /// <param name="ctx">Icontext</param>
        /// <returns>Query Result</returns>
        /// <history>
        ///     [Ruhim] 26May08 - Created        
        /// </history>
        public static object GetMOMDBQueryResult(string serverName, string sqlQuery, IContext ctx)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + "(...)");

            DBUtil.ConnectToMOMDB(serverName);
            DataView dataView = DBUtil.ExecuteQueryWithResults(sqlQuery);

            DBUtil.CloseMOMDBConnection();

            if (dataView != null && dataView.Count > 0)
            {
                Utilities.LogMessage(currentMethod + ":: dataView != null && dataView.Count > 0");
                return dataView[0].Row[0];
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: dataView is Null");
                return null;
            }
        }

        /// <summary>
        /// Runs the SQL query provided against the SQL DB specified in the SQL connection string.
        /// </summary>
        /// <param name="connectionStr">SQL Connection String</param>
        /// <param name="query">SQL Query</param>
        /// <param name="ctx">Icontext</param>
        /// <returns>Query Result</returns>
        /// <history>
        ///     [v-brucec] 25Jan10 - Created        
        /// </history>
        public static object GetDBQueryResultGeneric(string connectionStr, string query, IContext ctx)
        {
            SqlConnection sqlConnection = null;
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string logMessageHeader = currentMethod + " :: ";

            try
            {
                Utilities.LogMessage(logMessageHeader + "SQL Connection String '" + connectionStr + "'");

                // Create the SQL Connection
                sqlConnection = new SqlConnection(connectionStr.ToString());

                // Open the SQL Connection
                Utilities.LogMessage(logMessageHeader + "Opening SqlConnection...");
                sqlConnection.Open();

                // Execute Query
                Utilities.LogMessage(logMessageHeader + "Executing Query '" + query + "'");
                DataView resultData = DBUtil.ExecuteQueryWithResultsOnSqlConnection(query, sqlConnection);

                if (resultData != null && resultData.Count > 0)
                {
                    Utilities.LogMessage(currentMethod + ":: Got at lease one data row(s)");
                    return resultData[0].Row[0];
                }
                else
                {
                    Utilities.LogMessage(currentMethod + ":: Got no data row.");
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Utilities.LogMessage(currentMethod + ":: got sql exception while executing query. Stack track:" + ex.StackTrace);
                throw;
            }
            catch (System.Exception ex)
            {
                Utilities.LogMessage(currentMethod + ":: got exception while executing query. Stack track:" + ex.StackTrace);
                throw;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// Runs the SQL query provided against the SQL DB specified in the SQL connection string.
        /// </summary>
        /// <param name="connectionStr">SQL Connection String</param>
        /// <param name="query">SQL Query</param>
        /// <returns>Number of affected rows</returns>
        public static int ExecuteNonQueryGeneric(string connectionStr, string query)
        {
            SqlConnection sqlConnection = null;
            SqlCommand command = null;
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string logMessageHeader = currentMethod + " :: ";

            Utilities.LogMessage(logMessageHeader + "SQL Connection String '" + connectionStr + "'");

            // Create the SQL Connection
            sqlConnection = new SqlConnection(connectionStr.ToString());

            // Open the SQL Connection
            Utilities.LogMessage(logMessageHeader + "Opening SqlConnection...");
            sqlConnection.Open();

            // Create SQL Command
            Utilities.LogMessage(logMessageHeader + "Executing SqlCommand...");
            command = new SqlCommand(query, sqlConnection);

            // Execute Query
            Utilities.LogMessage(logMessageHeader + "Executing Query '" + query + "'");
            int output = command.ExecuteNonQuery();

            // Close the SQL Connection
            sqlConnection.Close();

            return output;
        }

        /// <summary>
        /// Get Id/Guid from DB given the Display Name
        /// </summary>
        /// <param name="serverName">MOM Server Name</param>
        /// <param name="sqlQuery">SQl Query</param>
        /// <param name="displayName">Display Name of the element for which the Guid is needed</param>
        /// <param name="context">Icontext</param>
        /// <returns>Alert Guid if found otherwise Guid.Empty if null</returns>
        /// <history>
        ///     [Ruhim] 26May08 - Created        
        /// </history>
        public static Guid GetGuidFromDB(string serverName, string sqlQuery, string displayName, IContext context)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string originalDisplayName = displayName;
            Utilities.LogMessage(currentMethod + ":: Display name is " + displayName);

            //replace all occurances of ' in displayName with % otherwise the SQL query below will fail
            displayName = displayName.Replace("'", "%");

            //replace all occurances of [ in displayName with % otherwise the SQL query below will fail
            displayName = displayName.Replace("[", "%");

            if (string.Compare(originalDisplayName, displayName) != 0)
            {
                Utilities.LogMessage(currentMethod + ":: Display name contained character ' that was replaced by % ");
                Utilities.LogMessage(currentMethod + ":: New Display name for SQL query is: " + displayName);
            }

            sqlQuery = string.Format(sqlQuery, displayName);

            Utilities.LogMessage(currentMethod + ":: Executing SQL Query: " + sqlQuery);

            object queryResult = Utilities.GetMOMDBQueryResult(serverName, sqlQuery, context);

            // Check if Query result is null
            if (queryResult == null)
            {
                Utilities.LogMessage(currentMethod + ":: queryResult is null - returned Guid.Empty: " + Guid.Empty.ToString());
                return Guid.Empty; 
            }
            else
            {
                string elementId = queryResult.ToString();
                Utilities.LogMessage(currentMethod + ":: ID: " + elementId);
                Guid elementGuid = new Guid(elementId);
                Utilities.LogMessage(currentMethod + ":: GUID: " + elementGuid.ToString());

                return elementGuid;
            }
        }


        /// <summary>
        /// Get monitor Id/Guid from DB given the monitor Display Name
        /// </summary>
        /// <param name="serverName">MOM Server Name</param>
        /// <param name="monitorDisplayName">Monitor Display Name</param>
        /// <param name="context">Icontext</param>
        /// <returns>Monitor Guid</returns>
        /// <history>
        ///     [Ruhim] 26May08 - Created        
        /// </history>
        public static Guid GetMonitorGuidFromDB(string serverName, string monitorDisplayName, IContext context)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string sqlQuery = @"SELECT Id 
                                                  FROM dbo.MonitorView 
                                                  with(nolock)
                                                  WHERE DisplayName like N'{0}'";

            Guid monitorGuid = GetGuidFromDB(serverName, sqlQuery, monitorDisplayName, context);
            return monitorGuid;
        }

        /// <summary>
        /// Get Rule Id/Guid from DB given the rule Display Name
        /// </summary>
        /// <param name="serverName">MOM Server Name</param>
        /// <param name="ruleDisplayName">Rule Display Name</param>
        /// <param name="context">Icontext</param>
        /// <returns>Monitor Guid</returns>
        /// <history>
        ///     [Ruhim] 30May08 - Created        
        /// </history>
        public static Guid GetRuleGuidFromDB(string serverName, string ruleDisplayName, IContext context)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string sqlQuery = @"SELECT Id 
                                FROM dbo.RuleView 
                                with(nolock)
                                WHERE DisplayName like N'{0}'";

            Guid ruleGuid = GetGuidFromDB(serverName, sqlQuery, ruleDisplayName, context);
            return ruleGuid;
        }

        /// <summary>
        /// Get Alert Id/Guid from MOM DB given the alert Display Name for active alert
        /// </summary>
        /// <param name="serverName">MOM Server Name</param>
        /// <param name="alertDisplayName">Alert Display Name</param>
        /// <param name="context">Icontext</param>
        /// <returns>Alert Guid</returns>
        /// <history>
        ///     [Ruhim] 26May08 - Created        
        /// </history>
        public static Guid GetAlertGuidFromDB(string serverName, string alertDisplayName, IContext context)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string sqlQuery = @"SELECT Id
                                FROM dbo.AlertView
                                WITH(NOLOCK)
                                WHERE AlertStringName = N'{0}' and ResolutionState = 0";

            Guid alertGuid = GetGuidFromDB(serverName, sqlQuery, alertDisplayName, context);
            return alertGuid;
        }

        /// <summary>
        /// Get Alert Id/Guid from MOM DB given the alert Display Name for active alert
        /// </summary>
        /// <param name="serverName">MOM Server Name</param>
        /// <param name="alertDisplayName">Alert Display Name</param>
        /// <param name="monitorName">triggered monitor</param>
        /// <param name="context">Icontext</param>
        /// <returns>Alert Guid</returns>
        /// <history>
        ///     [v-vijia] 07July11 - Created        
        /// </history>
        public static Guid GetMonitorAlertGuidFromDB(string serverName, string alertDisplayName, string monitorName, IContext context)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string sqlQuery = @"select av.Id
                                from dbo.AlertView (NOLOCK) av
                                join dbo.MonitorView (NOLOCK) mv
                                on av.MonitoringRuleId = mv.Id
                                where av.AlertStringName = '{0}' 
                                and av.ResolutionState = 0
                                and mv.DisplayName = '" + monitorName + "'";

            Guid alertGuid = GetGuidFromDB(serverName, sqlQuery, alertDisplayName, context);
            return alertGuid;
        }

        /// <summary>
        /// Get Alert Id/Guid from MOM DB given the alert Display Name for active alert
        /// </summary>
        /// <param name="serverName">MOM Server Name</param>
        /// <param name="alertDisplayName">Alert Display Name</param>
        /// <param name="ruleName">triggered rule</param>
        /// <param name="context">Icontext</param>
        /// <returns>Alert Guid</returns>
        /// <history>
        ///     [v-vijia] 07July11 - Created        
        /// </history>
        public static Guid GetRuleAlertGuidFromDB(string serverName, string alertDisplayName, string ruleName, IContext context)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string sqlQuery = @"select av.Id
                                from dbo.AlertView (NOLOCK) av
                                join dbo.RuleView (NOLOCK) rv
                                on av.MonitoringRuleId = rv.Id
                                where av.AlertStringName = '{0}' 
                                and av.ResolutionState = 0
                                and rv.DisplayName = '" + ruleName + "'";

            Guid alertGuid = GetGuidFromDB(serverName, sqlQuery, alertDisplayName, context);
            return alertGuid;
        }

        /// <summary>
        /// Get target Id/GUID from DB given the target Display Name
        /// </summary>
        /// <param name="serverName">MOM Server Name</param>
        /// <param name="targetDisplayName">Target Display Name</param>
        /// <param name="context">Icontext</param>
        /// <returns>Target Guid</returns>
        /// <history>
        ///     [dialac] 30JUL08 - Created        
        /// </history>
        public static Guid GetTargetGuidFromDB(string serverName, string targetDisplayName, IContext context)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string sqlQuery = @"SELECT BaseManagedTypeId 
                              FROM dbo.BaseManagedEntity 
                              with(nolock)
                              WHERE DisplayName like N'{0}'";

            Guid targetGuid = GetGuidFromDB(serverName, sqlQuery, targetDisplayName, context);
            return targetGuid;
        }

        /// <summary>
        /// Get Rule Display Name from DB given the Rule GUID
        /// </summary>
        /// <param name="serverName">MOM Server Name</param>
        /// <param name="RuleGuid">Rule Guid</param>
        /// <param name="context">Icontext</param>
        /// <returns>Rule Display Name</returns>
        /// <history>
        ///     [dialac] 31JUL08 - Created        
        /// </history>
        public static string GetRuleDisplayNameFromDB(string serverName, Guid RuleGuid, IContext context)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string sqlQuery = @"SELECT DisplayName
                              FROM dbo.RuleView 
                              with(nolock)
                              WHERE Id like N'{0}'";

            sqlQuery = string.Format(sqlQuery, RuleGuid);

            Utilities.LogMessage(currentMethod + ":: Executing SQL Query: " + sqlQuery);
            //Utilities.LogMessage(currentMethod + ":: SQL Query is:" + sqlQuery);
            string ruleName = GetMOMDBQueryResult(serverName, sqlQuery, context).ToString();
            Utilities.LogMessage(currentMethod + "RuleName returned from DB is:" + ruleName);
            return ruleName;
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Creates a Dump File of Process.
        /// </summary>
        /// <param name="processName">process name</param>
        /// <param name="noninvasive">True/False - True won't kill process when done dumping</param>
        /// <history>
        /// [mbickle] 11SEP06 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static void CreateProcessDump(string processName, bool noninvasive)
        {
            //string debugApp = "D:\\Program Files\\Debugging Tools for Windows\\cdb.exe";
            string debugApp = "cdb.exe";
            string debuAppCommands = ".dump /u /ma " + processName + ".dmp;q";
            string debugParams = " -pn " + processName + " -c \"" + debuAppCommands + "\"";
            //string username = Environment.GetEnvironmentVariable("USERNAME");
            //string domain = UserDomainName;
            //string password = GetDomainUserPassword(domain, username);

            if (noninvasive)
            {
                debugParams = " -pv" + debugParams;
            }

            Utilities.LogMessage("Utilities.CreateProcessDump: " + processName);
            Utilities.LogMessage("Utilities.CreateProcessDump: debugParams: " + debugParams);

            //Maui.Core.Utilities.Process.LaunchExecutableAsUser(debugApp, debugParams, Environment.CurrentDirectory, username, password, domain);
            System.Diagnostics.Process.Start(debugApp, debugParams);

            Utilities.LogMessage("Utilities.CreateProcessDump: Created: " + processName + ".dmp");
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Waiting for DrWatson Process to end if running.
        /// </summary>
        /// <history>
        /// [mbickle] 27FEB06 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static void WaitForDrWatson()
        {
            if (Utilities.GetProcessId(Constants.DW20Exe) != 0)
            {
                Utilities.LogMessage("Utilities.WaitForDrWatson: DW20.exe is running, so waiting...", true);

                while (Utilities.GetProcessId(Constants.DW20Exe) != 0)
                {
                    Sleeper.Delay(10000);
                }

                Utilities.LogMessage("Utilities.WaitForDrWatson: DW20.exe done running.", true);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns the ElapsedTime from StartTime to now.
        /// Logs out "ElapsedTime:: "
        /// </summary>
        /// <param name="startTime">DateTime</param>
        /// <returns>TimeSpan between startTime and DateTime.Now</returns>
        /// ------------------------------------------------------------------
        public static TimeSpan ElapsedTime(DateTime startTime)
        {
            return ElapsedTime(startTime, DateTime.Now);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns the ElapsedTime between Start and End Times.
        /// Logs out "ElapsedTime:: "
        /// </summary>
        /// <param name="startTime">DateTime</param>
        /// <param name="endTime">DateTime</param>
        /// <returns>TimeSpan between startTime and endTime</returns>
        /// ------------------------------------------------------------------
        public static TimeSpan ElapsedTime(DateTime startTime, DateTime endTime)
        {
            TimeSpan elapsedTime;
            elapsedTime = endTime.Subtract(startTime);

            Utilities.LogMessage("Utilities.ElapsedTime:: " + elapsedTime.ToString());

            return elapsedTime;
        }

        /// ------------------------------------------------------------------
        ///  <summary>
        ///  Returns the hotkey character for a given resource string.
        ///  </summary>
        /// <param name="controlIdText">Control ID Text</param>
        /// <returns>Hotkey Character</returns>
        ///  <remarks>
        ///  This function parses an input string for the AmpersandValue specified in
        ///  Constants.cs.  Note that this will return null if the input string does not
        ///  have an associated hotkey qualifier or if that qualifier is the last char.
        ///  </remarks>
        ///  <history>
        ///     [glennado] 10/16/2003 Created
        ///  </history>
        /// ------------------------------------------------------------------
        public static string GetHotkeyFromString(string controlIdText)
        {
            if (controlIdText == null)
            {
                throw new ArgumentNullException("controlIdText", "Common.GetHotkeyFromString:: controlIdText is null");
            }

            string hotkey = controlIdText.Substring(controlIdText.IndexOf(Constants.AmpersandValue) + 1, 1);

            return hotkey;
        }

        /// <summary>
        /// Return index by tab text
        /// </summary>
        /// <param name="tabs">Tab collection</param>
        /// <param name="targetText">tab text to find</param>
        /// <returns>tab index</returns>
        /// <history>
        ///     [v-brucec] 28APR10 - Created        
        /// </history>
        public static int GetTabIndexByText(TabControlTabCollection tabs, string targetText)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + " :: start");

            int tabIndex = -1;

            if (tabs == null || tabs.Count == 0)
            {
                throw new System.ArgumentNullException(currentMethod + " :: Tab collection cannot be empty.");
            }

            if (string.IsNullOrEmpty(targetText))
            {
                throw new System.ArgumentNullException(currentMethod + " :: Tab text cannot be null or empty.");
            }

            targetText = targetText.ToLowerInvariant();

            for (int i = 0; i < tabs.Count; i++)
            {
                string tabText = tabs[i].Text.Trim().ToLowerInvariant();
                Utilities.LogMessage(currentMethod + " :: Found tab text '" + tabText + "' at index #" + i + ", expecting '" + targetText + "'");

                if(targetText.Equals(tabText))
                {
                    tabIndex = i;
                    break;
                }
            }

            if (tabIndex == tabs.Count)
            {
                throw new Maui.Core.WinControls.TabControl.Exceptions.TabNotFoundException("Tab page not found:" + targetText);
            }

            Utilities.LogMessage(currentMethod + " :: Tab index is:" + tabIndex);
            Utilities.LogMessage(currentMethod + " :: end");
            return tabIndex;
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Generate specified number of agents
        /// </summary>
        /// <param name="numAgents">number of agents to create</param>
        /// <returns>ReadOnlyCollection of GUIDs of the agents added</returns>
        /// <history>
        ///     [faizalk] 11AUG06 - Created
        /// </history>
        /// <remarks>
        /// Creates bogus agents and confirms pending actions.  Creates 
        /// remote health service and everything for each agent.
        /// </remarks>
        /// ------------------------------------------------------------------
        public static ReadOnlyCollection<Guid> GenerateAgents(int numAgents)
        {
            List<string> agentNames = new List<string>();

            Utilities.LogMessage("Utilities.GenerateAgents:: Generating " + agentNames.Count + " randomly-named agents...");
            RandomStrings randomStrings = new RandomStrings();

            for (int x = 0; x < numAgents; x++)
            {
                agentNames.Add(randomStrings.CreateRandomString(1, 20, Utilities.ExcludedCharacters()));
            }

            return GenerateAgents(agentNames);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Generate agents with the specified names.
        /// </summary>
        /// <param name="agentNames">agent names to create</param>
        /// <returns>ReadOnlyCollection of GUIDs of agents added</returns>
        /// <history>
        ///     [faizalk] 11AUG06 - Created
        /// </history>
        /// <remarks>
        /// Creates bogus agents and confirms pending actions.  Creates 
        /// remote health service and everything for each agent.
        /// </remarks>
        /// ------------------------------------------------------------------
        public static ReadOnlyCollection<Guid> GenerateAgents(
            IList<string> agentNames)
        {
            // insert agents as pending actions
            Utilities.LogMessage("Utilities.GenerateAgents:: Inserting " + agentNames.Count + " agents...");
            ReadOnlyCollection<Guid> returnCollection = Microsoft.EnterpriseManagement.Test.ScCommon.AgentMgmt.AgentPendingActionHelper.InsertManualAgentPendingActions(MomServerName, agentNames);

            // get pending actions
            ManagementGroup managementGroup = ConnectToManagementServer();
            //Microsoft.EnterpriseManagement.Administration.ManagementGroupAdministration admin = managementGroup.GetAdministration();
            IList<AgentPendingAction> pendingActions = managementGroup.Administration.GetAgentPendingActions();

            // approve pending actions
            Utilities.LogMessage("Utilities.GenerateAgents:: Approving pending actions...");
            managementGroup.Administration.ApproveAgentPendingActions(pendingActions);

            Utilities.LogMessage("Utilities.GenerateAgents:: Inserted " + returnCollection.Count + " agents");

            return returnCollection;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Delete agents with the specified GUIDs.
        /// </summary>
        /// <param name="agentNames">agent names to delete</param>
        /// <history>
        ///     [faizalk] 11AUG06 - Created
        /// </history>
        /// <remarks>
        /// Deletes agents
        /// </remarks>
        /// ------------------------------------------------------------------
        public static void DeleteAgents(
            ReadOnlyCollection<Guid> agentNames)
        {
            Utilities.LogMessage("Utilities.GenerateAgents:: Deleting " + agentNames.Count + " agents...");

            // connect to SDK, initialize variables
            ManagementGroup managementGroup = ConnectToManagementServer();
            // Microsoft.EnterpriseManagement.Administration.ManagementGroupAdministration admin = managementGroup.GetAdministration();
            List<AgentManagedComputer> agentManagedComputers = new List<AgentManagedComputer>();

            // build list of agents from GUIDs
            foreach (Guid guid in agentNames)
            {
                agentManagedComputers.Add(managementGroup.Administration.GetAgentManagedComputer(guid));
            }

            // delete agents
            managementGroup.Administration.DeleteAgentManagedComputers(new ReadOnlyCollection<AgentManagedComputer>(agentManagedComputers));

            Utilities.LogMessage("Utilities.GenerateAgents:: Deleted " + agentManagedComputers.Count + " agents");
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Generate an Event on specified Machine.
        /// Method used in here uses the EventLogHelper library that allows allows
        /// generation of Events.  Set to use 'Application' Log.
        /// </summary>
        /// <param name="machineName">Machine Name to Log Event on.</param>
        /// <param name="eventId">Event ID</param>
        /// <param name="eventType">System.Diagnostics.EventLogEntryType</param>
        /// <param name="sourceName">Source of Event</param>
        /// <history>
        ///     [mbickle] 19AUG05 - Created
        /// </history>
        /// <remarks>
        /// EventLogHelper currently doesn't support the generation of an event
        /// on the remote machine that appears it came from that machine.
        /// </remarks>
        /// ------------------------------------------------------------------
        public static void GenerateEvent(
            string machineName,
            int eventId,
            EventLogEntryType eventType,
            string sourceName)
        {
            string logName = "Application";

            GenerateEvent(machineName, eventId, eventType, sourceName, logName, null);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Generate an Event on specified Machine.
        /// Method used in here uses the EventLogHelper library that allows allows
        /// generation of Events. 
        /// </summary>
        /// <param name="machineName">Machine Name to Log Event on.</param>
        /// <param name="eventId">Event ID</param>
        /// <param name="eventType">System.Diagnostics.EventLogEntryType</param>
        /// <param name="sourceName">Source of Event</param>
        /// <param name="logName">Event LogName to use.</param>
        /// <history>
        ///     [mbickle] 19AUG05 - Created
        /// </history>
        /// <remarks>
        /// EventLogHelper currently doesn't support the generation of an event
        /// on the remote machine that appears it came from that machine.
        /// </remarks>
        /// ------------------------------------------------------------------
        public static void GenerateEvent(
            string machineName,
            int eventId,
            EventLogEntryType eventType,
            string sourceName,
            string logName)
        {
            GenerateEvent(machineName, eventId, eventType, sourceName, logName, null);
        }

        /// <summary>
        /// Generate an Event on specified Machine.
        /// Method used in here uses the EventLogHelper library that allows allows
        /// generation of Events. 
        /// </summary>
        /// <param name="machineName">Machine Name to Log Event on.</param>
        /// <param name="eventId">Event ID</param>
        /// <param name="eventType">System.Diagnostics.EventLogEntryType</param>
        /// <param name="sourceName">Source of Event</param>
        /// <param name="logName">Event LogName to use.</param>
        /// <param name="parameters">Any parameters</param>
        /// <history>
        ///     [lucyra] 19JAN06 - Created
        /// [mbickle] 02MAY06 Added a check for parameters being null and ingoring if it is.
        ///                   Was getting null exceptions when it was null.
        /// </history>
        /// <remarks>
        /// EventLogHelper currently doesn't support the generation of an event
        /// on the remote machine that appears it came from that machine.
        /// </remarks>
        /// ------------------------------------------------------------------
        public static void GenerateEvent(
            string machineName,
            int eventId,
            EventLogEntryType eventType,
            string sourceName,
            string logName,
            string[] parameters)
        {
            LogMessage("Utilities.GenerateEvent:: machine   : " + machineName);
            LogMessage("Utilities.GenerateEvent:: eventId   : " + eventId.ToString());
            LogMessage("Utilities.GenerateEvent:: eventType : " + eventType.ToString());
            LogMessage("Utilities.GenerateEvent:: sourceName: " + sourceName);
            LogMessage("Utilities.GenerateEvent:: logName   : " + logName);

            try
            {
                // Create NTEvent Reference
                LogMessage("Utilities.GenerateEvent:: Create NTEvent Reference");
                Microsoft.EnterpriseManagement.Test.ScCommon.Event.NTEvent ntevent =
                    new Microsoft.EnterpriseManagement.Test.ScCommon.Event.NTEvent(machineName, logName, sourceName, eventId);

                LogMessage("Utilities.GenerateEvent:: Set NTEvent Parameters");

                // Set the different NTEvent Parameters
                ntevent.MachineName = machineName;
                ntevent.EventID = eventId;
                ntevent.EventType = eventType;
                ntevent.SourceName = sourceName;
                ntevent.LogName = logName;

                if (parameters != null)
                {
                    ntevent.ParamData = parameters;
                }

                LogMessage("Utilities.GenerateEvent:: Fire Event");

                // Create the Event
                ntevent.Fire();
            }
            catch (Microsoft.EnterpriseManagement.Test.ScCommon.Event.EventHelperException)
            {
                throw;
            }
        }

        /// <summary>
        /// Provides a count of the number of times an
        /// event has occurred since the starting
        /// date and time.
        /// </summary>
        /// <param name="machineName">Machine Name to get Log information from.</param>
        /// <param name="eventId">Event ID</param>
        /// <param name="eventType">System.Diagnostics.EventLogEntryType</param>
        /// <param name="sourceName">Source of Event</param>
        /// <param name="logName">Event LogName to use.</param>
        /// <param name="startDateTime">Date/time to begin the search in the log</param>
        /// <returns>An integer</returns>
        /// <example>
        /// int NumberOfRecentCrashes = Utilities.GetCountOfRecentNTEvent(
        /// </example>
        public static int GetCountOfRecentNTEvent(
            string machineName,
            int eventId,
            EventLogEntryType eventType,
            string sourceName,
            string logName,
            DateTime startDateTime)
        {
            Utilities.LogMessage("Utilities.GetCountOfRecentNTEvent :: " +
                "machineName: " + machineName);
            Utilities.LogMessage("Utilities.GetCountOfRecentNTEvent :: " +
                "eventId: " + eventId.ToString());
            Utilities.LogMessage("Utilities.GetCountOfRecentNTEvent :: " +
                "eventType: " + eventType.ToString());
            Utilities.LogMessage("Utilities.GetCountOfRecentNTEvent :: " +
                "sourceName: " + sourceName);
            Utilities.LogMessage("Utilities.GetCountOfRecentNTEvent :: " +
                "logName: " + logName);
            Utilities.LogMessage("Utilities.GetCountOfRecentNTEvent :: " +
                "startDateTime: " +
                startDateTime.ToLongDateString() + " " +
                startDateTime.ToLongTimeString());

            Microsoft.EnterpriseManagement.Test.ScCommon.Event.NTEventSearchCriteria searchForEvent =
                new Microsoft.EnterpriseManagement.Test.ScCommon.Event.NTEventSearchCriteria();
            searchForEvent.LogName = logName;
            searchForEvent.EventType = eventType;
            searchForEvent.EventID = eventId;
            searchForEvent.SourceName = sourceName;

            // Override the default time.
            searchForEvent.BookMarkOverRide = startDateTime;

            // Configure the search to find events that occurred
            // after the start date/time.
            searchForEvent.DTSearchMode =
                Microsoft.EnterpriseManagement.Test.ScCommon.Event.DateSearchMode.After;

            // Return the count of events found.
            return Microsoft.EnterpriseManagement.Test.ScCommon.Event.EventLogHelper.Search(searchForEvent).Count;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// LogMessage - If FrameworkContext isn't set it just logs to console
        /// otherwise logs to Framework file.
        /// </summary>
        /// <param name="message">Message To Log</param>
        /// <history>
        ///     [mbickle] 20NOV03 - Created
        ///     [mbickle] 16MAR04 - Made method Public
        ///     [kellymor]19SEP05 - Added Maui TextLog trace logging
        ///     [mbickle] 20OCT05 - Refactored to call main LogMessage with verbose = false.
        /// </history>
        /// ------------------------------------------------------------------
        public static void LogMessage(string message)
        {
            LogMessage(message, false);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// LogMessage - If FrameworkContext isn't set it just logs to console
        /// otherwise logs to Framework file.
        /// </summary>
        /// <param name="message">Message To Log</param>
        /// <param name="always">If true, always logs. (ie: context.Alw)</param>
        /// <history>
        ///     [mbickle] 20NOV03 - Created
        ///     [mbickle] 16MAR04 - Made method Public
        ///     [kellymor]19SEP05 - Added Maui TextLog trace logging
        ///     [mbickle] 20OCT05 - Added verbose option
        /// </history>
        /// ------------------------------------------------------------------
        public static void LogMessage(string message, bool always)
        {
            string logEntry = null;

            // if a Maui TextLog has been defined for logging...
            if (Utilities.traceLog != null)
            {
                try
                {
                    // prefix a timestamp to the message
                    logEntry = "[" + System.DateTime.Today.TimeOfDay + "] - " + message;

                    // write the message to the Maui TextLog
                    Utilities.traceLog.WriteEntry(EntryType.Standard, logEntry, EntryEncoding.PlainText);
                }
                catch (System.IO.IOException)
                {
                    // Sometimes we fail to write to this file.  Just going to catch this and move on.
                }
            }


            // write to logger
            if (always)
            {
                Trace.TraceInformation(message);
            }
            else
            {
                Trace.WriteLine(message);
            }

        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Takes a Screen Shot.  Will format with DateTime + name .jpg.
        /// </summary>
        /// <param name="name">Name to append to file</param>
        /// <history>
        ///     [mbickle] 02APR04 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static void TakeScreenshot(string name)
        {
            LogMessage("Utilities.TakeScreenShot:: " + name);
            Maui.TestLog.LogManager.TakeScreenshot(FormatDateTime() + name + ".jpg");
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Get ProcessId - Returns the first ProcessId of a running application.
        /// </summary>
        /// <param name="processExeName">Application Exe Name</param>
        /// <returns>ProcessId</returns>
        /// <history>
        /// [mbickle] 17NOV05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static int GetProcessId(string processExeName)
        {
            LogMessage("Utilities.GetProcessId:: ProcessName: " + processExeName);
            int[] processIds = null;
            processIds = Maui.Core.Utilities.Process.GetProcessesIdsByName(processExeName);
            int processId = 0;
            
            // Check if null or length == 0 
            if (processIds == null || processIds.Length == 0)
            {
                LogMessage("Utilities.GetProcessId:: Process not found.");
            }
            else
            {
                processId = processIds[0];
            }

            return processId;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets the Password for Domain\Username from CDSCom
        /// </summary>
        /// <param name="domain">User Domain</param>
        /// <param name="user">User Name</param>
        /// <returns>Password</returns>
        /// ------------------------------------------------------------------
        public static string GetDomainUserPassword(string domain, string user)
        {
            string passwd = null;
            string domainuser = domain + "\\" + user;

            Utilities.LogMessage("Utilities.GetDomainUserPassword:: Getting Password for : " + domainuser);

            // connect using PasswordManager
            passwd = PasswordManager.GetPassword(domain, user);

            ////// get the password for the specified user
            ////if ((null != domainuser) && (0 < domainuser.Length))
            ////{
            ////    // get password for this user, passed by reference
            ////    passwd = usersClass.GetPasswordS(ref domainuser);
            ////}

            Utilities.LogMessage("Utilities.GetDomainUserPassword:  Password for " + domainuser + " : " + passwd);

            // return the password for this user
            return passwd;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Show the DrWatson UI or not.
        /// Set: HKLM\Software\Policies\Microsoft\PCHealth\ErrorReporting:ShowUI:0
        /// Set: HKLM\Software\Policies\Microsoft\Windows\Windows Error Reporting:DontShowUI:1
        /// </summary>
        /// <param name="value">True/False</param>
        /// <remarks>
        /// We turn it off in ConsoleApp.UpdateParameters to prevent UI automation 
        /// from pausing.
        /// </remarks>
        /// <history>
        ///     [mbickle] 13SEP05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static void ShowDrWatsonUI(bool value)
        {
            // Server 2003
            string regKeyPathSrv2003 = @"Software\Policies\Microsoft\PCHealth\ErrorReporting";
            string regKeySrv2003 = "ShowUI";

            // Server 2008 (Longhorn)
            string regKeyPathSrv2008 = @"Software\Policies\Microsoft\Windows\Windows Error Reporting";
            string regKeySrv2008 = "DontShowUI";

            Microsoft.Win32.RegistryKey registryKeySrv2003;
            Microsoft.Win32.RegistryKey registryKeySrv2008;

            Utilities.LogMessage("Utilities.SetDrWatsonShowUI:: Setting DrWatson ShowUI value to: " + value.ToString());

            // If Regkey InstalledOn exists, delete it's value to reset console back to default.
            try
            {
                registryKeySrv2003 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(regKeyPathSrv2003, true);
                registryKeySrv2008 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(regKeyPathSrv2008, true);

                // Server 2008 will have both keys and ShowUI overrides DontShowUI
                // therefore we will set both values
                if (registryKeySrv2003 != null && registryKeySrv2008 != null)
                {
                    if (value)
                    {
                        // Turns on ShowUI
                        // Server 2003
                        registryKeySrv2003.SetValue(regKeySrv2003, 1, Microsoft.Win32.RegistryValueKind.DWord);

                        // Server 2008
                        registryKeySrv2008.SetValue(regKeySrv2008, 0, Microsoft.Win32.RegistryValueKind.DWord);
                    }
                    else
                    {
                        // Turns off ShowUI
                        // Server 2003
                        registryKeySrv2003.SetValue(regKeySrv2003, 0, Microsoft.Win32.RegistryValueKind.DWord);

                        // Server 2008
                        registryKeySrv2008.SetValue(regKeySrv2008, 1, Microsoft.Win32.RegistryValueKind.DWord);
                    }
                }
                // Server 2003 will only have the single key therefore we will set only ShowUI
                else if (registryKeySrv2003 != null)
                {
                    if (value)
                    {
                        // Turns on ShowUI
                        // Server 2003
                        registryKeySrv2003.SetValue(regKeySrv2003, 1, Microsoft.Win32.RegistryValueKind.DWord);
                    }
                    else
                    {
                        // Turns off ShowUI
                        // Server 2003
                        registryKeySrv2003.SetValue(regKeySrv2003, 0, Microsoft.Win32.RegistryValueKind.DWord);
                    }
                }
                else
                {
                    Utilities.LogMessage("Utilities.SetDrWatsonShowUI:: Couldn't open RegKeyPath: " + regKeyPathSrv2003);
                    Utilities.LogMessage("Utilities.SetDrWatsonShowUI:: Couldn't open RegKeyPath: " + regKeyPathSrv2008);
                }
            }
            catch (System.Security.SecurityException)
            {
                Utilities.LogMessage("Utilities.SetDrWatsonShowUI:: Couldn't access RegKeyPath: " + regKeyPathSrv2003);
                Utilities.LogMessage("Utilities.SetDrWatsonShowUI:: Couldn't access RegKeyPath: " + regKeyPathSrv2008);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Stops a Service on Local Machine  
        /// </summary>
        /// <param name="serviceName">Service Name</param>
        /// <history>
        /// [mbickle] 18OCT05 Refactored code to call new method with machinename.
        /// </history>
        /// ------------------------------------------------------------------
        public static void StopService(string serviceName)
        {
            string localmachine = Environment.GetEnvironmentVariable("COMPUTERNAME");
            StopService(serviceName, localmachine);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Stops a Service on Specified Machine  
        /// </summary>
        /// <param name="serviceName">Service Name</param>
        /// <param name="machineName">Machine Name</param>
        /// <history>
        ///     [mbickle] 18OCT05 Created
        ///     [v-brucec] 02DEC09 Retry to stop service if it failed first time.
        /// </history>
        /// ------------------------------------------------------------------
        public static void StopService(string serviceName, string machineName)
        {
            Utilities.LogMessage("Utilities.StopService:: serviceName: " + serviceName + " machineName: " + machineName);

            int retry = 0;
            int maxRetry = 10;
            bool actionSuccess = false;
            while (!actionSuccess && retry < maxRetry)
            {
                using (System.ServiceProcess.ServiceController serviceController =
                    new System.ServiceProcess.ServiceController(serviceName, machineName))
                {

                    if (serviceController != null)
                    {
                        if (serviceController.Status != ServiceControllerStatus.Stopped)
                        {
                            if (serviceController.CanStop)
                            {
                                serviceController.Stop();
                                serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                                Utilities.LogMessage("Utilities.StopService:: Found status for service \"" + serviceName + "\" to be: " + serviceController.Status + " in retry # " + retry + " expecting: " + ServiceControllerStatus.Stopped);
                            }
                            else
                                Utilities.LogMessage("Utilities.StopService:: WARNING, this service, \"" + serviceName + "\" is unstoppable.");
                        }
                    }
                    else
                    {
                        LogMessage("Utilities.StopService:: Failed to init a ServiceController instance." + " in retry # " + retry);
                        Sleeper.Delay(Constants.OneSecond * 10);
                    }

                    actionSuccess = (serviceController.Status == ServiceControllerStatus.Stopped);
                    serviceController.Close();
                    serviceController.Dispose();
                }
                retry++;
            }

            if (!actionSuccess)
            {
                throw new Maui.GlobalExceptions.MauiException("Utilities.StopService:: Failed to stop service '" + serviceName + "' on machine '" + machineName + "' after " + retry + " times retry.");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Stop a Service on Specified Machine with an adminsitrator user  
        /// </summary>
        /// <param name="serviceName">Service Name</param>
        /// <param name="machineName">Machine Name</param>
        /// <param name="userName">User Name</param>
        /// <param name="password">User Password</param>
        /// <history>
        ///     [v-jinlil] 04DEC09 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static void StopService(string serviceName, string machineName, string userName, string password)
        {
            //get service path
            string strPath = "\\\\" + machineName + "\\root\\cimv2:Win32_Service";
            Utilities.LogMessage("Untilities.StopService::Service Path is " + strPath);

            ManagementClass managementClass = new ManagementClass(strPath);

            try
            {
                //connect to machine
                RemoteConnectValidate(machineName, userName, password, managementClass);
                Utilities.LogMessage("Untilities.StopService::Connect to machine successfully.");

                ManagementObject managementObject = managementClass.CreateInstance();
                managementObject.Path = new ManagementPath(strPath + ".Name=\"" + serviceName + "\"");

                //stop service
                if ((string)managementObject["State"] == "Running")
                {
                    if ((bool)managementObject["AcceptStop"])
                    {
                        managementObject.InvokeMethod("StopService", null);
                    }
                    else
                    {
                        //service cann't be stopped
                        throw new Exception("Untilities.StopService::Failed to stop service since security does not allow to stop service");
                    }
                }
            }
            catch (ManagementException managementException)
            {
                //log failed information for stopping service
                Utilities.LogMessage("Untilities.StopService::Failed to stop service" + serviceName + ": " + managementException.Message);
                throw;
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("Utilities.StopService:: " + exception.Message);
                throw;
            }
            finally
            {
                //dispose connection to machine
                managementClass.Dispose();
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// start a Service on Specified Machine with an adminsitrator user   
        /// </summary>
        /// <param name="serviceName">Service Name</param>
        /// <param name="machineName">Machine Name</param>
        /// <param name="userName">User Name</param>
        /// <param name="password">User Password</param>
        /// <history>
        ///     [v-jinlil] 04DEC09 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static void StartService(string serviceName, string machineName, string userName, string password)
        {
            //get service path
            string strPath = "\\\\" + machineName + "\\root\\cimv2:Win32_Service";
            Utilities.LogMessage("Untilities.StartService::Service Path is " + strPath);

            ManagementClass managementClass = new ManagementClass(strPath);

            try
            {
                //connect to machine
                RemoteConnectValidate(machineName, userName, password, managementClass);
                Utilities.LogMessage("Untilities.StartService::Connect to machine successfully.");

                ManagementObject managementObject = managementClass.CreateInstance();
                managementObject.Path = new ManagementPath(strPath + ".Name=\"" + serviceName + "\"");

                //start service
                if ((string)managementObject["State"] == "Stopped")
                {
                    if ("Disabled".Equals((string)managementObject["StartMode"]))
                    {
                        throw new Exception("Untilities.StartService::" + serviceName + " cannot be started because its StartMode is disabled.");
                    }
                    else
                    {
                        managementObject.InvokeMethod("StartService", null);
                        Utilities.LogMessage("Untilities.StartService::" + serviceName + " successfully.");
                    }
                }
            }
            catch (ManagementException managementException)
            {
                //log failed information for starting service
                Utilities.LogMessage("Untilities.StartService::Failed to start service" + serviceName + " : " + managementException.Message);
                throw;
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("Utilities.StartService:: " + exception.Message);
                throw;
            }
            finally
            {
                //dispose connection to machine
                managementClass.Dispose();
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Start a connections on remote Machine  
        /// </summary>
        /// <param name="machineName">Machine Name</param>
        /// <param name="userName">User Name</param>
        /// <param name="password">User Password</param>
        /// <param name="managementClass">Management Class</param>
        /// <history>
        /// [v-jinlil] 04DEC09 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static void RemoteConnectValidate(string machineName, string userName, string password, ManagementClass managementClass)
        {
            try
            {
                ConnectionOptions connectionOptions = new ConnectionOptions();

                connectionOptions.Username = userName;
                connectionOptions.Password = password;
                Utilities.LogMessage("Untilities.RemoteConnectValidate::Machine:" + machineName + " User:" + userName + " Password:" + password);

                ManagementScope managementScope = new ManagementScope("\\\\" + machineName + "\\root\\cimv2", connectionOptions);
                managementClass.Scope = managementScope;

                managementScope.Connect();
            }
            catch (ManagementException managementException)
            {
                //log failed information for connceting to machine
                Utilities.LogMessage("Untilities.RemoteConnectValidate::Failed to connect to machine" + machineName + ": " + managementException.Message);
                throw;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Get administrator user name and password 
        /// </summary>
        /// <returns>administrator user and password</returns>
        /// <history>
        /// [v-jinlil] 08DEC09 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string[] GetAdministratorUserAndPassword()
        {
            string[] userAndPassword = { string.Empty, string.Empty };

            //get domain information
            string[] domain = Mom.Test.Infrastructure.PasswordManager.GetAllDomains();
            Utilities.LogMessage("Untilities.GetAdministratorUserandPassword::domain is " + domain[0]);

            //get administrator user
            userAndPassword[0] = Mom.Test.Infrastructure.PasswordManager.GetDomainAdminAccount();
            Utilities.LogMessage("Untilities.GetAdministratorUserandPassword::administrator user is " + userAndPassword[0]);

            //get password for administrator user
            userAndPassword[1] = Mom.Test.Infrastructure.PasswordManager.GetPassword(userAndPassword[0]);
            Utilities.LogMessage("Untilities.GetAdministratorUserandPassword::administrator user's password is " + userAndPassword[1]);

            //get administrator user with domain
            userAndPassword[0] = domain[0] + @"\" + userAndPassword[0];

            //return administrator user name and password info
            return userAndPassword;
        }

        /// <summary>
        /// This is a method to create different type of account.
        /// </summary>
        /// <param name="type">Account Type</param>
        /// <param name="name">Account name</param>
        /// <param name="description">Account Description</param>
        /// <param name="userName">Account UserName</param>
        /// <param name="password">Account Pass Word</param>
        /// <param name="domain">Domain</param>
        /// <param name="distribution">Distribution Type</param>
        /// <returns>Return Created RunAsAccount</returns>
        public static SecureData CreateRunAsAccount(AccountType type, string name, string description, string userName, string password, string domain, DistributionType distribution)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string logMessageHeader = currentMethod + " :: ";

            ManagementGroup managementGroup = null;
            System.Security.SecureString secureString = null;

            try
            {
                managementGroup = ConnectToManagementServer();
                secureString = new System.Security.SecureString();
                SecureDataCriteria runAsAccountCriteria;
                IList<SecureData> runAsAccounts;

                switch (type.ToString().ToLower())
                {
                    case "windows":
                        windowsSecureData = new WindowsCredentialSecureData();
                        windowsSecureData.Name = name;
                        windowsSecureData.Description = description;
                        windowsSecureData.UserName = userName;
                        windowsSecureData.Domain = domain;

                        secureString = new System.Security.SecureString();
                        for (int i = 0; i < password.Length; i++)
                        {
                            secureString.AppendChar(password[i]);
                        }

                        windowsSecureData.Data = secureString;

                        runAsAccountCriteria = new SecureDataCriteria(string.Format("Name LIKE '{0}'", name));
                        //This is the SDK method to get specified account.
                        runAsAccounts = managementGroup.Security.GetSecureData(runAsAccountCriteria);

                        if (runAsAccounts == null || runAsAccounts.Count == 0)
                        {
                            Utilities.LogMessage(currentMethod + ":: No existed account, create it.");
                            //This is the SDK method to create a new account.
                            managementGroup.Security.InsertSecureData(windowsSecureData);
                        }
                        else
                        {
                            Utilities.LogMessage(currentMethod + ":: Account : " + name + " already existed.");
                            windowsSecureData = (WindowsCredentialSecureData)managementGroup.Security.GetSecureData(runAsAccounts[0].Id.Value);
                        }

                        if ((windowsSecureData.Id == null) || (windowsSecureData.SecureStorageId == null))
                        {
                            throw new NullReferenceException("Windows Secure data not inserted successfully");
                        }

                        break;
                    case "CommunityString":
                        //Can add CommunityString Accont type here.
                        throw new System.NotImplementedException("Not implement for the type: " + type.ToString());
                        break;

                    default:
                        Utilities.LogMessage(currentMethod + ":: There is no this kind of AccountType!");
                        throw new Maui.GlobalExceptions.InvalidEnumValueException("Invalid account type: " + type.ToString());
                        break;

                }
                return windowsSecureData;

            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch(Maui.GlobalExceptions.InvalidEnumValueException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        
        /// <summary>
        /// This is a method to get RunAsProfile from test mp
        /// </summary>
        /// <param name="TaskMPName">Test MP Name</param>
        /// <param name="referenceName">RunAsProfile Name</param>
        /// <returns>Return RunAsProfile</returns>  
        public static ManagementPackSecureReference GetSecureReferenceFromMP(string TaskMPName, string referenceName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string logMessageHeader = currentMethod + " :: ";

            ManagementGroup managementGroup = null;
            managementGroup = ConnectToManagementServer();
                        
            ManagementPack mgmtPack = managementGroup.ManagementPacks.GetManagementPacks(new ManagementPackCriteria("Name='" + TaskMPName + "'"))[0];            
            GuidUITaskWebConsoleMP = mgmtPack.Id.ToString();
            Utilities.LogMessage(currentMethod + ":: GuidUITaskWebConsoleMP: " + GuidUITaskWebConsoleMP);

            ManagementPackSecureReferenceCriteria criteria = new ManagementPackSecureReferenceCriteria(string.Format("Name = '{0}' and ManagementPackId='{1}'", referenceName, GuidUITaskWebConsoleMP));
            IList<ManagementPackSecureReference> references = managementGroup.Security.GetSecureReferences(criteria);

            //Sometimes the reference is null when you get them 1st time, second time it's ok. 
            int maxRetrytimes = Constants.DefaultMaxRetry * 2;
            for (int i = 0; i < maxRetrytimes; i++)
            {
                if (references.Count > 0) 
                { 
                    break; 
                }
                else
                {
                    Utilities.LogMessage(String.Format(currentMethod + ":: Reference not available, retry: " + i + ", Criteria: " + criteria.ToString()));
                    Sleeper.Delay(Constants.OneSecond * 10);
                    
                    //This is the SDK method to get specified profile from MP.
                    references = managementGroup.Security.GetSecureReferences(criteria);
                }
            }
            if (references.Count <= 0) 
            {
                Utilities.LogMessage(currentMethod + ":: Reference not available, Criteria: " + criteria.ToString()); 
            }
            Utilities.LogMessage(currentMethod + ":: references[0].Id=" + references[0].Id);
            Utilities.LogMessage(currentMethod + ":: references name: " + references[0].Name);
            //since will have only one ref with that name in my test MP, assigning currentref to ref[0]
            ManagementPackSecureReference currentReference = references[0];

            return currentReference;
        }

        /// <summary>
        /// This is a method to associate RunAsAccount to RunAsProfile.
        /// </summary>
        /// <param name="account">RunAsAccont</param>
        /// <param name="profile">RunAsProfile</param>       
        public static void AssociateRunAsAccountToProfile(SecureData account, ManagementPackSecureReference profile)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string logMessageHeader = currentMethod + " :: ";

            ManagementGroup managementGroup = null;         
            SecureDataHealthServiceReference secureReferenceData = null;        
            ReadOnlyCollection<MonitoringObject> healthServiceInstances;
            MonitoringClass healthServiceClass;  
            Guid secureDataId;
            
            try
            {
                managementGroup = ConnectToManagementServer();
               
                healthServiceClass = managementGroup.GetMonitoringClass(SystemMonitoringClass.HealthService);
                healthServiceInstances = managementGroup.GetMonitoringObjects(healthServiceClass);
                secureDataId = new Guid(account.Id.ToString());

                foreach (MonitoringObject healthService in healthServiceInstances)
                {                   
                    secureReferenceData = new SecureDataHealthServiceReference(secureDataId, profile.Id, healthService.Id);

                    if (!IsSecureDataReferenceByHealthServiceInSpecifiedProfile(account, profile))
                    {
                        //This is the SDK method to associate specified account to the profile.
                        managementGroup.Security.InsertSecureDataHealthServiceReference(secureReferenceData);
                        Utilities.LogMessage(string.Format(@"Inserted ref between 
                        secureReferenceData.MonitoringSecureReferenceId= " +
                            secureReferenceData.SecureReferenceId + " and HS= " + healthService.DisplayName));
                    }
                    else
                    {
                        Utilities.LogMessage(currentMethod + ":: RunAsAccount: " + account.Name + " already associate to Profile: " + profile.DisplayName);
                    }
                    
                }               
            }
            catch (SqlException)
            {
                Utilities.LogMessage(currentMethod + ":: Duplicate RunAsProfile is inserted. ");
               throw;
            }
            catch(Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// This is a method to verify if the account is associated to RunAsProfile.
        /// </summary>
        /// <param name="secureData">RunAsAccount</param>
        /// <param name="profile">RunAsProfile</param>
        /// <returns>Return true if associated successfully, otherwise, return false.</returns>
        public static bool IsSecureDataReferenceByHealthServiceInSpecifiedProfile(SecureData secureData, ManagementPackSecureReference profile)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string logMessageHeader = currentMethod + " :: ";

            ManagementGroup managementGroup = null;

            managementGroup = ConnectToManagementServer();
            //This is the SDK method to get specified profile by Id.
            IList<SecureDataHealthServiceReference> list = managementGroup.Security.GetSecureDataHealthServiceReferenceBySecureReferenceId(profile.Id);
            
            if (list.Count > 0 && list[0].SecureDataId == secureData.Id.Value)
            {
                Utilities.LogMessage(currentMethod + ":: Successfully associate RunAsAccount: " + secureData.Name + " to Profile " + profile.DisplayName);
                return true;
            }
            else
            {
                Utilities.LogMessage(currentMethod + ":: Failed to associate RunAsAccount: " + secureData.Name + " to Profile " + profile.DisplayName);
                return false;
            }       
        }
        
        /// ------------------------------------------------------------------
        /// <summary>
        /// Starts a Service on Local Machine  
        /// </summary>
        /// <param name="serviceName">Service Name</param>
        /// <history>
        /// [mbickle] 18OCT05 refactored code to call main method with machine name
        /// </history>
        /// ------------------------------------------------------------------
        public static void StartService(string serviceName)
        {
            string localmachine = Environment.GetEnvironmentVariable("COMPUTERNAME");
            StartService(serviceName, localmachine);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Starts a Service on Specified Machine  
        /// </summary>
        /// <param name="serviceName">Service Name</param>
        /// <param name="machineName">Machine Name</param>
        /// <history>
        ///     [mbickle] 18OCT05 Created
        ///     [v-brucec] 02DEC09 Retry to start service if it failed first time.
        /// </history>
        /// ------------------------------------------------------------------
        public static void StartService(string serviceName, string machineName)
        {
            Utilities.LogMessage("Utilities.StartService:: serviceName: " + serviceName + " machineName: " + machineName);
            int retry = 0;
            int maxRetry = 10;
            bool actionSuccess = false;

            while (!actionSuccess && retry < maxRetry)
            {
                using (System.ServiceProcess.ServiceController serviceController =
                    new System.ServiceProcess.ServiceController(serviceName, machineName))
                {
                    if (serviceController != null)
                    {
                        if (serviceController.Status != ServiceControllerStatus.Running)
                        {
                            serviceController.Start();
                            serviceController.WaitForStatus(ServiceControllerStatus.Running);
                            Utilities.LogMessage("Utilities.StartService:: Found status for service \"" + serviceName + "\" to be: " + serviceController.Status + " in retry # " + retry + " expecting: " + ServiceControllerStatus.Running);
                        }
                    }
                    else
                    {
                        LogMessage("Utilities.StartService:: Failed to init a ServiceController instance." + " in retry # " + retry);
                        Sleeper.Delay(Constants.OneSecond * 10);
                    }

                    actionSuccess = (serviceController.Status == ServiceControllerStatus.Running);
                    serviceController.Close();
                    serviceController.Dispose();
                }
                retry++;
            }

            if (!actionSuccess)
            {
                throw new Maui.GlobalExceptions.MauiException("Utilities.StartService:: Failed to start service '" + serviceName + "' on machine '" + machineName + "' after " + retry + " times retry.");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to create a Maui TextLog for trace information.  If one or
        /// more of the parameters are null or blank, the method will use MAUI
        /// default values for the log file and test name.
        /// </summary>
        /// <param name="logFileName">Name of thelog file to create</param>
        /// <param name="testName">Name of the test or component</param>
        /// /// <history>
        /// [KellyMor] 19SEP05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static void CreateMauiLog(string logFileName, string testName)
        {
            // create the log file
            Utilities.traceLog = new Maui.TestLog.Logs.TextLog(
                System.Environment.CurrentDirectory);

            System.Console.WriteLine();

            // if the log file name is not null or empty string
            if (null != logFileName && 0 != logFileName.Length)
            {
                // set the log file names
                Utilities.traceLog.LogFileName = logFileName;
                Utilities.traceLog.TextLogFileName = logFileName;
                Utilities.traceLog.VerboseLogFileName = "Verbose_" + logFileName;
            }
            else
            {
                // use the default name
                Utilities.traceLog.LogFileName = "MomConsoleApp.log";
                Utilities.traceLog.TextLogFileName = "MomConsoleApp.log";
                Utilities.traceLog.VerboseLogFileName = "Verbose_MomConsoleApp.log";
            }

            if (null != testName && 0 != testName.Length)
            {
                // initialize the test log with the test name
                Utilities.traceLog.InitTest(testName);
            }
            else
            {
                // initialize the test log with the default name
                Utilities.traceLog.InitTest("Test Trace Log");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to close a Maui TextLog file
        /// </summary>
        /// ------------------------------------------------------------------
        public static void CloseMauiLog()
        {
            // if a trace log was created
            if (Utilities.traceLog != null)
            {
                // end the tests and close the log file
                Utilities.traceLog.EndTest();
            }
        }

        #region Accessibility Methods section

        /// <summary>
        /// This method is designed to search the Accessible objects
        /// tree to locate a control with matching accessibility 
        /// properties.
        /// </summary>
        /// <param name="accessibleControl">An accessible window.</param>
        /// <param name="name">Accessible Name</param>
        /// <param name="roleText">Accessible Role</param>
        /// <returns>ActiveAccessibility object or null if not found</returns>
        public static ActiveAccessibility GetActiveAccessibility(
            ActiveAccessibility accessibleControl,
            string name,
            string roleText)
        {
            LogMessage("GetActiveAccessibility(...)");
            LogMessage("GetActiveAccessibility :: " +
                "Searching for name: " + name + " " +
                "and role: " + roleText);

            ActiveAccessibility accessibleChildControl = null;
            foreach (ActiveAccessibility childObject in accessibleControl.Children)
            {
                LogMessage("GetActiveAccessibility :: " +
                    "Name: " + childObject.Name);
                LogMessage("GetActiveAccessibility :: " +
                    "Role: " + childObject.RoleText);

                // Find the object by its name and role.
                if ((childObject.Name == name) &&
                    (childObject.RoleText == roleText))
                {
                    LogMessage("GetActiveAccessibility :: " +
                    "Found " + childObject.Name);
                    accessibleChildControl = childObject;
                    break;
                }
            }

            if (null == accessibleChildControl)
            {
                LogMessage("GetActiveAccessibility :: " +
                    "Unable to find " + name + " with a role of " + roleText);
            }

            return accessibleChildControl;
        }

        #endregion // Accessibility Methods

        /// ------------------------------------------------------------------
        /// <summary>
        /// An array of characters to exclude.
        /// Commonly used with RandomStrings class.
        /// </summary>
        /// <returns>Char Array of Characters to Exclude</returns>
        /// <history>
        /// [mbickle] 18JAN05 Created
        /// [faizalk] 02MAY06 Made static
        /// </history>
        /// ------------------------------------------------------------------
        public static char[] ExcludedCharacters()
        {
            return excludedCharacters;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// checks to see if SQL2008 is installed.
        /// </summary>
        /// <returns>bool</returns>
        /// <history>
        /// [starrpar] 09APR09 Created
        /// </history>
        /// ------------------------------------------------------------------
        private static bool sql2008()
        {
            //navigate to SQL regkey
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.LocalMachine;
            regKey = regKey.OpenSubKey("SOFTWARE\\Microsoft\\Microsoft SQL Server");

            //ascertain whether SQL2005 or SQL2008
            Microsoft.Win32.RegistryKey tmpRegKey = regKey.OpenSubKey("Instance Names\\RS");

            //BUGBUG: this approach assumes Instance1 will always exist in our test environment
            string rsInstanceName = (string)tmpRegKey.GetValue("INSTANCE1");
            //result will either be MSSQL.2 (SQL2005) or MSRS10.INSTANCE1 (SQL2008)

            //using SQL version-specific key, get SQL version
            regKey = regKey.OpenSubKey(rsInstanceName + "\\Setup");
            string sqlVersion = (string)regKey.GetValue("Version");

            //simple check for version 10.xx - could make this portion of test more robust in future, if desired
            if (sqlVersion.StartsWith("10.")) //check for sql2008
            {
                LogMessage("Utilities.sql2008 :: is SQL2008");
                return true;
            }
            else
            {
                LogMessage("Utilities.sql2008 :: is SQL2005");
                return false;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Bug Server Management 114261 Fix.
        /// Change the permission set of node "Report_Expressions_Default_Permissions" 
        /// from Execute to FullTrust in rssrvpolicy.config only on cover builds
        /// so that, Reporting Test suite does not throw an error of type "System.Security.Permissions.SecurityPermission".
        /// </summary>
        /// <history>
        /// 	[a-omkasi] 05/12/2008 Created
        /// </history>
        /// <remarks>
        /// Cover builds have a *_cover.cab file. Check if this file exists to confirm that it is a cover build.
        /// </remarks>
        /// -----------------------------------------------------------------------------
        public static void FixForCoverBuild()
        {
            try
            {
                //check if it is a cover build
                bool coverBuild = false;
                string SystemDrive = Environment.ExpandEnvironmentVariables("%SystemDrive%");


                string installPath = String.Empty;
                string coverBuildCabFileDir = String.Empty;

                try
                {
                    installPath = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\System Center Operations Manager\12\Setup", "InstallDirectory", null);
                    coverBuildCabFileDir = installPath + @"\Console\Tools\TMF\";
                }
                catch (Exception exception)
                {
                    Utilities.LogMessage("Utilities.FixForCoverBuild:: " + exception.Message);
                    throw;
                }

                foreach (string file in Directory.GetFiles(coverBuildCabFileDir))
                {
                    if (Regex.IsMatch(file, "cover.cab$"))
                    {
                        coverBuild = true;
                        break; //break once match found.
                    }
                }

                if (coverBuild)
                {
                    //Open the file rssrvpolicy.config
                    string rssrvPolicyConfigPath = "";
                    string rssrvPolicy2005ConfigPath = SystemDrive + @"\Program Files\Microsoft SQL Server\MSSQL.2\Reporting Services\ReportServer\rssrvpolicy.config";
                    string rssrvPolicy2008ConfigPath = SystemDrive + @"\Program Files\Microsoft SQL Server\MSRS10.INSTANCE1\Reporting Services\ReportServer\rssrvpolicy.config";

                    if (sql2008())
                    {
                        rssrvPolicyConfigPath = rssrvPolicy2008ConfigPath;
                    }
                    else //assume SQL2005
                    {
                        rssrvPolicyConfigPath = rssrvPolicy2005ConfigPath;
                    }
                    //check if we have write permissions for the file.
                    FileIOPermission fip = new FileIOPermission(FileIOPermissionAccess.Write, rssrvPolicyConfigPath);
                    fip.Assert();

                    //Change permission in rssrvpolicy.config
                    using (XmlTextReader xmlReader = new XmlTextReader(rssrvPolicyConfigPath))
                    {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(xmlReader);
                        xmlReader.Close();

                        //Select the node with attribute Name = "Report_Expressions_Default_Permissions"
                        XmlNode Report_Expressions_Default_Permissions = null;
                        XmlElement rssrvpolicyRoot = xmlDocument.DocumentElement;
                        Report_Expressions_Default_Permissions
                            = rssrvpolicyRoot.SelectSingleNode("//configuration/mscorlib/security/policy/PolicyLevel/CodeGroup/CodeGroup[@Name='Report_Expressions_Default_Permissions']");

                        //change the PermissionSetName from Execution to FullTrust [Server Management 114261 Bug]
                        if (Report_Expressions_Default_Permissions != null)
                            Report_Expressions_Default_Permissions.Attributes["PermissionSetName"].Value = "FullTrust";
                        else
                            throw new Exception("XML node \"CodeGroup\" with attribute \"Name= Report_Expressions_Default_Permissions\" not found in" + rssrvPolicyConfigPath);

                        //Save the output to the file
                        xmlDocument.Save(rssrvPolicyConfigPath);
                    }
                }
            }
            catch (FileNotFoundException fileNotFound)
            {
                Utilities.LogMessage("Utilities.FixForCoverBuild:: " + fileNotFound.Message);
                throw;
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                Utilities.LogMessage("Utilities.FixForCoverBuild:: " + dirNotFound.Message);
                throw;
            }
            catch (FileLoadException fileLoadException)
            {
                Utilities.LogMessage("Utilities.FixForCoverBuild:: " + fileLoadException.Message);
                throw;
            }
            catch (Exception exception)
            {
                Utilities.LogMessage("Utilities.FixForCoverBuild:: " + exception.Message);
                throw;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Get the public key token of a given assembly
        /// </summary>
        /// <history>
        /// 	[zhihaoq] 10/16/2008 Created
        /// </history>
        /// <remarks>
        /// Return the public key token of a given assembly as a string
        /// </remarks>
        /// -----------------------------------------------------------------------------
        public static string GetPublicKeyToken(string assemblyFileName)
        {
            Assembly loadedAssembly = Assembly.LoadFile(assemblyFileName);
            AssemblyName loadedAssemblyName = new AssemblyName(loadedAssembly.FullName);
            System.Text.StringBuilder pkBuilder = new System.Text.StringBuilder(8);
            byte[] pkArray = loadedAssemblyName.GetPublicKeyToken();
            for (int i = pkArray.GetLowerBound(0); i <= pkArray.GetUpperBound(0); i++)
            {
                pkBuilder.Append(string.Format("{0:x}", pkArray[i]));
            }
            return pkBuilder.ToString();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to remove the accelerator keys from a resource string.  The
        /// method locates all instances of the ampersand character and removes
        /// them, returning a new string without ampersands
        /// </summary>
        /// <param name="resourceString">
        /// The resource string to process for ampersand characters.
        /// </param>
        /// <returns>
        /// A new string without ampersands.
        /// </returns>
        /// -------------------------------------------------------------------
        public static string RemoveAcceleratorKeys(string resourceString)
        {
            if (String.IsNullOrEmpty(resourceString))
            {
                throw new System.NullReferenceException(
                    "Parameter cannot be null or empty string!");
            }

            Core.Common.Utilities.LogMessage(
                "RemoveAcceleratorKeys::Checking resource string := '" +
                resourceString +
                "'");

            // loop through the string removing all occurrences of ampersand
            StringBuilder tempString = new StringBuilder();
            tempString.Append(resourceString);

            for (int indexOfAmpersand = tempString.ToString().IndexOf('&');
                indexOfAmpersand > -1;
                indexOfAmpersand = tempString.ToString().IndexOf('&'))
            {
                Core.Common.Utilities.LogMessage(
                    "RemoveAcceleratorKeys::Removing ampersand at index := '" +
                    indexOfAmpersand.ToString() +
                    "'");

                // remove the ampersand character
                tempString.Remove(indexOfAmpersand, 1);
            }

            return tempString.ToString();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to determine if an ArrayList contains a sorted list
        /// </summary>
        /// <param name="aIn">
        /// ArrayList passed in for examination
        /// </param>
        /// <returns>
        /// Bool as to whether the ArrayList is determined to be sorted or not
        /// </returns>
        /// -------------------------------------------------------------------
        public static bool IsSorted(System.Collections.ArrayList aIn)
        {
            System.Collections.ArrayList aOut = new System.Collections.ArrayList();

            //copy contents for comparison later
            for (int i = 0; i < aIn.Count; i++)
            {
                if (aIn[i] != null)
                {
                    aOut.Add(aIn[i]);
                }
            }

            //sort newly copied contents
            aOut.Sort();

            bool sorted = true;

            //compare sent ArrayList to newly sorted ArrayList, object by object to determine if 
            //sent ArrayList was already sorted
            for (int i = 0; i < aIn.Count; i++)
            {
                if (aIn[i] == aOut[i])
                {
                    Utilities.LogMessage("DEBUG: List contents: " + aIn[i]);
                    continue;
                }
                else
                {
                    Utilities.LogMessage("DEBUG: In: " + aIn[i]);
                    Utilities.LogMessage("DEBUG: Out: " + aOut[i]);
                    sorted = false;
                    break;
                }
            }
            return sorted;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method to determine if an ArrayList contains a distinct list
        /// </summary>
        /// <param name="aIn">
        /// ArrayList passed in for examination
        /// </param>
        /// <returns>
        /// Bool as to whether the ArrayList is determined to be distinct or not
        /// </returns>
        /// -------------------------------------------------------------------
        public static bool IsDistinct(System.Collections.ArrayList aIn)
        {
            System.Collections.ArrayList aOut = new System.Collections.ArrayList();

            //copy contents for comparison later
            for (int i = 0; i < aIn.Count; i++)
            {
                if (aIn[i] != null)
                {
                    aOut.Add(aIn[i]);
                }
            }

            bool distinct = true;
            bool found = false;
            bool foundtwice = false;

            //compare sent ArrayList to copied ArrayList, object by object to determine if 
            //any listed items occur more than once
            for (int i = 0; i < aOut.Count; i++)
            {
                Utilities.LogMessage("DEBUG: List contents: " + aOut[i]);

                //reset found param for pass of next item
                found = false;
                int j = 0;
                while (!foundtwice && j < aIn.Count)
                {
                    if (aOut[i] == aIn[j])
                    {
                        if (found == true) //previously marked true - therefore, must be second occurrence
                        {
                            foundtwice = true;
                        }
                        else //hasn't yet been marked true - first occurrence
                        {
                            found = true;
                        }
                    }
                    //increment j and continue
                    j++;
                }
                //if found twice, indicate non-distinct and exit
                if (foundtwice)
                {
                    distinct = false;
                    break;
                }
            }
            return distinct;
        }

        /// <summary>
        /// Bring specified dialog to foreground
        /// </summary>
        /// <param name="targetDialog">Target windos/dialog to bring to foreground</param>
        /// <history>
        /// [v-brucec] 10DEC09 Created.
        /// </history>
        public static void BringDialogForeground(Window targetDialog)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");

            if (targetDialog == null) return;

            int retry = 0;
            int maxRetry = 2;

            while (!targetDialog.Extended.IsForeground && retry < maxRetry)
            {
                Utilities.LogMessage(currentMethod + ":: Bringing window to foreground in retry #" + retry + ".");
                targetDialog.Extended.App.BringToForeground();
                Sleeper.Delay(Constants.OneSecond * 10);
                retry++;
            }

            Utilities.LogMessage(currentMethod + ":: end");
        }

        #region Insert Discovery Data into DW

        ///-------------------------------------------------------------------------------
        /// <summary>
        /// Inserts Discovery (instance) data into OpsDB
        /// </summary>
        /// <param name="numberAgents">number of agents to insert data for</param>
        /// /// <param name="ctx">IContext object</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        /// <history>
        ///      [starrpar]   27-APR-10 Created
        /// </history>
        ///-------------------------------------------------------------------------------

        public static void InsertDiscoveryData(
            int numberAgents,
            string MomServerName,
            IContext ctx)
        {
            if (!CheckIfInsertedDataExistsInDW(numberAgents, ctx))
            {
                string runAsName = MOMCOMMON_PATH + RUNASPROCESS_FILENAME;
                string wamlgtFileName = MOMCOMMON_PATH + WAMLGT_FILENAME;
                string discoveryLogFileLocation = Environment.GetEnvironmentVariable("WinDir") + DISCOVERY_LOGFILE;
                string asttestPassword = "";

                //TODO: make work and remove workaround string literals
                //NOTE: think it works now without explicit passwords
                if (PasswordManager.AccountExists(ASTTEST_ACCOUNT))
                    asttestPassword = PasswordManager.GetPassword(ASTTEST_ACCOUNT);
              
                #region set DB and DW for auto-growth

                //see DataModelGroup example of call to DBUtil.ExecuteQueryFromFile()

                string filePath = LOCAL_PATH;
                string dbFileName = DB_GROWTH_SCRIPT;
                string dwFileName = DW_GROWTH_SCRIPT;

                DBUtil.ConnectToMOMDB(MomServerName);

                DBUtil.ExecuteQueryFromFile(filePath + dbFileName);

                DBUtil.CloseMOMDBConnection();

                //set DW name and SQL instance for use beyond this point
                if (m_DBInstanceName == null)
                    SetServerName();
                if (m_DBName == null)
                    SetUrlDBName();

                DBUtil.ConnectToMOMDW(m_DBInstanceName, m_DBName);
                ctx.Trc("SQL Connection: " + DBUtil.SqlConnection.ConnectionString);

                DBUtil.ExecuteQueryFromFile(filePath + dwFileName);

                DBUtil.CloseMOMDWConnection();

                #endregion

                #region Call WAMLGT for insertion of discovery/instance data (into OpsDB)

                string localDir = System.Environment.CurrentDirectory;
                string cmdLine = SMX_DOMAIN + ASTTEST_ACCOUNT + " " + asttestPassword + " " +
                    localDir + " " + wamlgtFileName + " \"" + LOAD_DISCOVERY_FILENAME + " " +
                    discoveryLogFileLocation + " ComputerCount:" + numberAgents + "\"";

                System.Diagnostics.Process instanceDataProcess = new System.Diagnostics.Process();
                instanceDataProcess.StartInfo.FileName = runAsName;
                instanceDataProcess.StartInfo.Arguments = cmdLine;
                instanceDataProcess.StartInfo.RedirectStandardOutput = false;
                instanceDataProcess.StartInfo.WorkingDirectory = localDir;

                //TODO: place query to verify if MPs are transferred to DW yet with retry logic, rather than sleeping

                ctx.Alw("Sleeping 5 minutes to allow imported MP data to be seen by DW");
                Thread.Sleep(300000);

                ctx.Trc("Calling WAMLGT...discovery data insertion");
                ctx.Trc(instanceDataProcess.StartInfo.FileName + " " +
                    instanceDataProcess.StartInfo.Arguments);
                instanceDataProcess.Start();

                #region reset defaults in DW to allow for insertion/aggregation of 30 days of data

                //Reset number of days of data in allowed into PerfRaw table from Staging table (from 10 [default] to 30)
                string localFilePath = ".\\";
                string resetAggregationFileName = "ResetPerfRawAggregation.sql";

                DBUtil.ConnectToMOMDW(m_DBInstanceName, m_DBName);
                ctx.Trc("SQL Connection: " + DBUtil.SqlConnection.ConnectionString);

                DBUtil.ExecuteQueryFromFile(localFilePath + resetAggregationFileName);
                
                //Not doing this for now
                //string resetAggregationIntervalFileName = "ResetAggregationDefaultInterval.sql";
                //DBUtil.ExecuteQueryFromFile(localFilePath + resetAggregationIntervalFileName);
                
                DBUtil.CloseMOMDWConnection();
                #endregion

                //TODO: place query here to check if inserted data exists in DW table with retry logic, rather than sleeping

                LogMessage("Sleeping 10 minutes to allow inserted discovery data to get over to DW");
                Thread.Sleep(600000);
                #endregion
            }            
        }
         
        #endregion

        #region Insert Performance Data into DW

        /// <summary>
        /// Provides convenience in calling Utilities InsertPerformanceData() method simply specifying
        /// a value to create an average about, and a number of segments to break the specified
        /// duration time into (equally)
        /// </summary>
        /// <param name="numberAgents">number of agents to insert data for</param>
        /// <param name="numberCPUs">number of CPUs for which counters will be simulated for each agent</param>
        /// <param name="startTimeInMinutesBack">number of minutes back to begin insertion of data</param>
        /// <param name="durationInMinutes">number of minutes worth of data to insert,
        /// back from startTimeInMinutesBack</param>
        /// <param name="averageValue">value about which to average multiple calls,
        /// depending on value of numberSegments</param>
        /// <param name="numberSegments">number of segments to break the durationInMinutes
        /// value up into, to create varied input values averaging specified averageValue</param>
        /// <param name="shape">dataShape enum representation {flat, bellcurve, spiked}</param>
        /// <param name="ctx">IContext</param>
        /// <param name="managedEntityBaseString">string specifying base of inserted managed entities 
        /// (eg. "Microsoft.Windows.Server.2003.Processor:WKSTNN")</param>
        /// <param name="healthServiceBaseString">string specifying base of health services 
        /// (eg. "WKSTNN")</param>
        /// <param name="ruleType">string specifying rule type  
        /// (eg. "Microsoft.Windows.Server.2003.Processor")</param>
        /// <param name="ruleName">string specifying rule name 
        /// (eg. "Microsoft.Windows.Server.2003.Processor.PercentProcessorTime.Collection")</param>
        public static void InsertPerformanceData(
            int numberAgents,
            int numberCPUs,
            int startTimeInMinutesBack,
            int durationInMinutes,
            int averageValue,
            int numberSegments,
            string shape,
            string managedEntityBaseString,
            string healthServiceBaseString,
            string ruleType,
            string ruleName, 
            IContext ctx)
        {
            int[] insertionDataArray = null;

            dataShape datashape = (dataShape)Enum.Parse(typeof(dataShape), shape, true);

            LogMessage("Datashape: " + datashape.ToString());

            switch (datashape)
            {
                case dataShape.flat:
                    insertionDataArray = GetValuesForInsertion_Average(averageValue, numberSegments, ctx);
                    break;
                case dataShape.bellcurve:
                    insertionDataArray = GetValuesForInsertion_BellCurveApproximation(averageValue, numberSegments, ctx);
                    break;
                case dataShape.spiked:
                    insertionDataArray = GetValuesForInsertion_Spiked(averageValue, numberSegments, ctx);
                    break;
                default:
                    throw new VarAbort("Invalid data shape specified: " + shape.ToString());
            }

            LogDataShape(insertionDataArray);

            int durationSegment = durationInMinutes / insertionDataArray.Length;
            int segmentStartTime = startTimeInMinutesBack;
            bool aggregationMeansNotSet = false;

            //TODO: make these data driven, or add better logic
            int numTries = 0;
            int maxTries = 30;
            while (!CheckIfInsertedDataExistsInDW(numberAgents, ctx) && numTries < maxTries)
            {
                //check again in 15 seconds
                LogMessage("Checking if inserted data exists in DW - will recheck in 15 seconds");
                Thread.Sleep(15000);
                numTries++;
            }

            if (!CheckIfInsertedDataExistsInDW(numberAgents, ctx))
            {
                throw new VarAbort("Inserted fake agent data not present in DW");
            }
            else
            {
                for (int i = 0; i < insertionDataArray.Length; i++)
                {
                    InsertPerformanceData(numberAgents, numberCPUs, segmentStartTime, durationSegment,
                        insertionDataArray[i], managedEntityBaseString, healthServiceBaseString,
                        ruleType, ruleName, ctx);

                    //increment SegmentEndTime back by DurationSegment value before next insertion
                    segmentStartTime -= durationSegment;
                }

                #region force-aggregate data

                //set aggregation means to Hourly if not set
                if (!(m_AggregationMeans > 0))
                {
                    aggregationMeansNotSet = true;
                    m_AggregationMeans = 20;
                }

                //stop health service to allow aggregation to happen most efficiently
                //System.Diagnostics.Process stopHSProcess = new System.Diagnostics.Process();
                //stopHSProcess.StartInfo = new ProcessStartInfo("net", "stop healthservice");
                //ctx.Trc("cmdline: " + stopHSProcess.StartInfo.FileName + " " +
                //    stopHSProcess.StartInfo.Arguments);
                //stopHSProcess.Start();

                LogMessage("Waiting 1 minute before starting to check for successful aggregation");
                Thread.Sleep(60000);

                if (m_DBInstanceName == null)
                    SetServerName();
                if (m_DBName == null)
                    SetUrlDBName();

                DBUtil.ConnectToMOMDW(m_DBInstanceName, m_DBName);
                DBUtil.ExecuteQueryFromFile("StandardDatasetMaintenanceloop.sql", 0);
                DBUtil.ExecuteQueryFromFile("ExecuteStandardDatasetAggregation.sql", 0);
                DBUtil.CloseMOMDWConnection();

                while (!CheckIfDataAggregated(averageValue, insertionDataArray.Length, m_AggregationMeans, ctx))
                {
                    DBUtil.ConnectToMOMDW(m_DBInstanceName, m_DBName);
                    DBUtil.ExecuteQueryFromFile("ExecuteStandardDatasetAggregation.sql", 0);
                    DBUtil.CloseMOMDWConnection();

                    LogMessage("Perf data not yet fully aggregated to Hourly table - rerunning " +
                        "StandardDatasetAggregation, and will check again in 1 minute");
                    Thread.Sleep(60000);
                }

                //restart health service that was stopped above
                //TODO: should make this a smarter service restart - check if running already before trying to restart again
                //System.Diagnostics.Process startHSProcess = new System.Diagnostics.Process();
                //startHSProcess.StartInfo = new ProcessStartInfo("net", "start healthservice");
                //ctx.Trc("cmdline: " + startHSProcess.StartInfo.FileName + " " +
                //    startHSProcess.StartInfo.Arguments);
                //startHSProcess.Start();

                if (aggregationMeansNotSet)
                {
                //    //if aggregation means was not already set, check aggregation for both types
                //    //i.e. now check for daily as well
                //    m_AggregationMeans = 30;
                //    while (!CheckIfDataAggregated(averageValue, numberInsertions, m_AggregationMeans, ctx))
                //    {
                //        //check again in 1 minute
                //        DBUtil.ConnectToMOMDW(m_DBInstanceName, m_DBName);
                //        DBUtil.ExecuteQueryFromFile("ExecuteStandardDatasetAggregation.sql", 0);
                //        DBUtil.CloseMOMDWConnection();

                //        LogMessage("Perf data not yet fully aggregated to Daily table - rerunning " +
                //            "StandardDatasetAggregation, and will check again in 1 minute");
                //        Thread.Sleep(60000);
                //    }
                }

                #endregion

            }

            #region validate average of inserted data

            //problem with comparison against aggregated data is going to be this:
            //there will be considerable complexity combining all of the various hourly
            //aggregated values to compile a total that would have the correct average
            //in this example, 280 samples have an average of 10.142857..., whereas 20 samples
            //have an average of 8, so combining these, 10.142857...* 280 = 2840, added to
            //8 * 20 = 160, comes to a total of 3000 / 300 = 10.0, which is correct/expected
            //but likely a challenge to handle for a month's worth of data insertion (can 
            //definitely be done, but might not be worth the time presently for this improvement)

            //2010-05-01 20:00:00.000	185	82	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	185	115	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	184	116	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	185	117	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	184	118	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	185	119	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	184	120	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	185	121	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	184	122	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	185	123	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	184	124	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	185	125	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	185	126	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	184	127	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	185	128	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	184	129	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	185	130	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	184	131	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	184	164	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 20:00:00.000	184	165	14	10.1428571428571	8	12	1.40642169281549
            //2010-05-01 19:00:00.000	185	82	1	8	8	8	0
            //2010-05-01 19:00:00.000	185	115	1	8	8	8	0
            //2010-05-01 19:00:00.000	184	116	1	8	8	8	0
            //2010-05-01 19:00:00.000	185	117	1	8	8	8	0
            //2010-05-01 19:00:00.000	184	118	1	8	8	8	0
            //2010-05-01 19:00:00.000	185	119	1	8	8	8	0
            //2010-05-01 19:00:00.000	184	120	1	8	8	8	0
            //2010-05-01 19:00:00.000	185	121	1	8	8	8	0
            //2010-05-01 19:00:00.000	184	122	1	8	8	8	0
            //2010-05-01 19:00:00.000	185	123	1	8	8	8	0
            //2010-05-01 19:00:00.000	184	124	1	8	8	8	0
            //2010-05-01 19:00:00.000	185	125	1	8	8	8	0
            //2010-05-01 19:00:00.000	185	126	1	8	8	8	0
            //2010-05-01 19:00:00.000	184	127	1	8	8	8	0
            //2010-05-01 19:00:00.000	185	128	1	8	8	8	0
            //2010-05-01 19:00:00.000	184	129	1	8	8	8	0
            //2010-05-01 19:00:00.000	185	130	1	8	8	8	0
            //2010-05-01 19:00:00.000	184	131	1	8	8	8	0
            //2010-05-01 19:00:00.000	184	164	1	8	8	8	0
            //2010-05-01 19:00:00.000	184	165	1	8	8	8	0

            //another example for planning an algorithm that will work
            //2010-05-03 00:07:42.960	185	130	30
            //2010-05-03 00:07:42.960	184	131	30
            //2010-05-03 00:06:42.960	185	130	30
            //2010-05-03 00:06:42.960	184	131	30
            //2010-05-03 00:05:42.960	184	131	30
            //2010-05-03 00:05:42.960	185	130	30
            //2010-05-03 00:04:42.960	185	130	30
            //2010-05-03 00:04:42.960	184	131	30
            //2010-05-03 00:03:42.960	184	131	30
            //2010-05-03 00:03:42.960	185	130	30
            //2010-05-03 00:02:07.787	185	130	31
            //2010-05-03 00:02:07.787	184	131	31
            //2010-05-03 00:01:07.787	184	131	31
            //2010-05-03 00:01:07.787	185	130	31
            //2010-05-03 00:00:07.787	185	130	31
            //2010-05-03 00:00:07.787	184	131	31
            //2010-05-02 23:59:07.787	184	131	31
            //2010-05-02 23:59:07.787	185	130	31
            //2010-05-02 23:58:07.787	184	131	31
            //2010-05-02 23:58:07.787	185	130	31
            //2010-05-02 23:56:32.473	185	130	29
            //2010-05-02 23:56:32.473	184	131	29
            //2010-05-02 23:55:32.473	184	131	29
            //2010-05-02 23:55:32.473	185	130	29
            //2010-05-02 23:54:32.473	184	131	29
            //2010-05-02 23:54:32.473	185	130	29
            //2010-05-02 23:53:32.473	185	130	29
            //2010-05-02 23:53:32.473	184	131	29
            //2010-05-02 23:52:32.473	184	131	29
            //2010-05-02 23:52:32.473	185	130	29

            //queries for checking contents of Raw and Hourly tables
            //select * from Perf.vPerfRaw
            //where PerformanceRuleInstanceRowId in (184, 185)
            //and SampleValue in (29, 30, 31)
            //order by DateTime desc

            //SELECT * FROM Perf.vPerfHourly
            //where PerformanceRuleInstanceRowId in (184, 185)
            //and MinValue in (29, 30, 31)
            //order by DateTime desc

            if (m_DBInstanceName == null)
                SetServerName();
            if (m_DBName == null)
                SetUrlDBName();

            DBUtil.ConnectToMOMDW(m_DBInstanceName, m_DBName);

            List<int> perfRuleInstIds = GetPerfRuleInstanceRowIdForInsertedData(ctx);

            ////DBUtil.ExecuteScalarQuery() - single result value
            //string ruleRowIdQuery = "SELECT RuleRowId FROM vRule where RuleDefaultName = 'Processor % Processor Time 2003'";
            //string ruleRowId = DBUtil.ExecuteScalarQuery(ruleRowIdQuery).ToString();
            //LogMessage("RuleRowId is: " + ruleRowId);

            ////DBUtil.ExecuteQueryWithResults() - multiple result values
            //string perfRuleInstanceQuery = "SELECT * FROM PerformanceRuleInstance where RuleRowId = '" + ruleRowId + "'";
            //System.Data.DataView perfRuleQueryResults = null;
            //perfRuleQueryResults = DBUtil.ExecuteQueryWithResults(perfRuleInstanceQuery);
            //ArrayList perfRuleResultValues = new ArrayList();
            //for (int i = 0; i < perfRuleQueryResults.Count; i++)
            //{
            //    perfRuleResultValues.Add((perfRuleQueryResults[i].Row[0]).ToString());
            //}

            ////where perfRuleInstanceQuery[i] is dictated by numberCPUs, so (0,1) when value is 2, obviously...
            //string perfRuleInstancesString = string.Empty;
            //for (int i = 0; i < numberCPUs; i++)
            //{
            //    perfRuleInstancesString += perfRuleResultValues[i] + ", ";
            //}
            ////remove last comma
            //perfRuleInstancesString = perfRuleInstancesString.Substring(0, perfRuleInstancesString.LastIndexOf(","));
            //LogMessage("PerfRuleInstances are: " + perfRuleInstancesString);

            //DBUtil.ExecuteQueryWithResults() - multiple result values
            string perfRuleInstancesString = string.Empty;
            for (int i = 0; i < perfRuleInstIds.Count; i++)
            {
                perfRuleInstancesString += perfRuleInstIds[i] + ", ";
            }
            //remove last comma
            perfRuleInstancesString = perfRuleInstancesString.Substring(0, perfRuleInstancesString.LastIndexOf(","));

            int minVal = averageValue - (numberSegments / 2);
            int maxVal = averageValue + (numberSegments / 2);

            string hourlyTableQuery = "SELECT AverageValue, SampleCount FROM Perf.vPerfHourly " +
                "WHERE PerformanceRuleInstanceRowId in (" + perfRuleInstancesString + ") " +
                "AND MinValue BETWEEN " + minVal + " AND " + maxVal;
            System.Data.DataView hourlyTableQueryResults = null;
            hourlyTableQueryResults = DBUtil.ExecuteQueryWithResults(hourlyTableQuery);
            ArrayList hourlyTableAverageValues = new ArrayList();
            ArrayList hourlyTableSampleCounts = new ArrayList();
            for (int i = 0; i < hourlyTableQueryResults.Count; i++)
            {
                hourlyTableAverageValues.Add(hourlyTableQueryResults[i].Row[0]);
                hourlyTableSampleCounts.Add(hourlyTableQueryResults[i].Row[1]);
            }

            if ((hourlyTableAverageValues == null) || hourlyTableAverageValues.Count == 0)
            {
                LogMessage("No values aggregated to Hourly table yet - investigate further");

                //throw new VarFail("No aggregated values found - values were expected");
            }
            else
            {
                ArrayList sumOfAverageValues = new ArrayList();
                ArrayList sumOfSampleValues = new ArrayList();
                for (int i = 0; i < hourlyTableAverageValues.Count; i++)
                {
                    int sampleCount = (int)hourlyTableSampleCounts[i];
                    double totalValuePerRow = (double)hourlyTableAverageValues[i] * sampleCount;
                    sumOfAverageValues.Add(totalValuePerRow);
                    sumOfSampleValues.Add(sampleCount);
                }

                double overallSum = 0.0;
                foreach (double avgValue in sumOfAverageValues)
                {
                    overallSum += avgValue;
                }

                int totalSampleCounts = 0;
                foreach (int sampleCount in sumOfSampleValues)
                {
                    totalSampleCounts += sampleCount;
                }

                //use integer division to convert floating point sum to an integer average value (rounding)
                int overallAverage = 0;
                overallAverage = (int)(overallSum / totalSampleCounts);

                if (overallAverage != averageValue)
                {
                    LogMessage("Average not as expected! - actual value: " + overallAverage +
                        ", expected value: " + averageValue);
                }
            }

            #endregion
        }
        
        /// <summary>
        /// Provides convenience in calling Utilities InsertPerformanceData() method simply specifying
        /// a value to create an average about, and a number of segments to break the specified
        /// duration time into (equally)
        /// </summary>
        /// <param name="averageValue">value about which to average multiple calls,
        /// depending on value of numberSegments</param>
        /// <param name="numberSegments">number of segments to break the durationInMinutes
        /// value up into, to create varied input values averaging specified averageValue</param>
        /// <param name="ctx">IContext</param>
        /// <returns>int[]</returns>
        public static int[] GetValuesForInsertion_Average(
            int averageValue,
            int numberSegments,
            IContext ctx)
        {
            int numberAwayFromAverage = numberSegments / 2;
            int includeAverage = numberSegments % 2;
            int[] valuesToInsert = null;

            if (numberSegments > 1)
            {
                valuesToInsert = new int[numberSegments];

                //insert values that average to AverageValue specified and
                //surround AverageValue equally to represent numberSegments
                //specified, continually equal distances away from AverageValue
                //in steps of 1
                for (int i = 0; i < numberAwayFromAverage * 2; i++)
                {
                    if (i < numberAwayFromAverage)
                        valuesToInsert[i] = averageValue - (numberAwayFromAverage - i);
                    else
                        valuesToInsert[i] = averageValue + (i - numberAwayFromAverage) + 1;
                }
            }
            else
            {
                valuesToInsert = new int[1];
            }

            //if numberSegments was an odd number, include average value as last value in valuesToInsert array
            if (includeAverage != 0)
                valuesToInsert[numberSegments - 1] = averageValue;

            return valuesToInsert;
        }
        
        /// <summary>
        /// Provides convenience in calling Utilities InsertPerformanceData() method simply specifying
        /// a value to create an average about, and a number of segments to break the specified
        /// duration time into (equally)
        /// </summary>
        /// <param name="averageValue">value about which to average multiple calls,
        /// depending on value of numberSegments</param>
        /// <param name="numberSegments">number of segments to break the durationInMinutes
        /// value up into, to create varied input values averaging specified averageValue</param>
        /// <param name="ctx">IContext</param>
        /// <returns>int[]</returns>
        public static int[] GetValuesForInsertion_Spiked(
            int averageValue,
            int numberSegments,
            IContext ctx)
        {
            int numberAwayFromAverage = numberSegments / 2;
            int includeAverage = numberSegments % 2;
            int[] valuesToInsert = null;

            if (numberSegments > 1)
            {
                //dimension array depending on if average value will be included (if numberSegments was odd)
                valuesToInsert = new int[numberSegments * numberAwayFromAverage];

                //insert values that average to AverageValue specified and
                //surround AverageValue equally to represent numberSegments
                //specified, continually equal distances away from AverageValue
                //in steps of 1
                for (int i = 0; i < numberAwayFromAverage * 2; i++)
                {
                    if (i < numberAwayFromAverage)
                    {
                        for (int k = 0; k < numberAwayFromAverage; k++)
                        {
                            valuesToInsert[(2 * i) + k] = averageValue - ((numberAwayFromAverage - i) * numberAwayFromAverage);
                        }
                    }
                    else
                    {
                        for (int k = 0; k < numberAwayFromAverage; k++)
                        {
                            valuesToInsert[(2 * i) + k] = averageValue + (((i - numberAwayFromAverage) + 1) * numberAwayFromAverage);
                        }
                    }
                }
            }
            else
            {
                valuesToInsert = new int[1];
            }

            //if numberSegments was an odd number, include average value as last value in valuesToInsert array
            if (includeAverage != 0)
            {
                for (int k = 0; k < numberAwayFromAverage; k++)
                {
                    valuesToInsert[(numberSegments * numberAwayFromAverage) - (k + 1)] = averageValue;
                }
            }

            return valuesToInsert;
        }

        /// <summary>
        /// Provides convenience in calling Utilities InsertPerformanceData() method simply specifying
        /// a value to create an average about, and a number of segments to break the specified
        /// duration time into (equally)
        /// </summary>
        /// <param name="averageValue">value about which to average multiple calls,
        /// depending on value of numberSegments</param>
        /// <param name="numberSegments">number of segments to break the durationInMinutes
        /// value up into, to create varied input values averaging specified averageValue</param>
        /// <param name="ctx">IContext</param>
        /// <returns>int[]</returns>
        public static int[] GetValuesForInsertion_BellCurveApproximation(
            int averageValue,
            int numberSegments,
            IContext ctx)
        {
            int numberAwayFromAverage = numberSegments / 2;
            int includeAverage = numberSegments % 2;
            int[] valuesToInsert = null;

            //use m to capture max number of insertions so as to insert average value
            //one more time than all others, if average value is included
            //(depends on whether numberSegments is an odd number)
            int m = numberAwayFromAverage + 1;

            int numAwayFactorial = 0;
            for (int i = 0; i < numberAwayFromAverage; i++)
            {
                numAwayFactorial += (numberAwayFromAverage - i);
            }
            //dimension array depending on if average value will be included (if numberSegments was odd)
            if (includeAverage == 0)
            {
                valuesToInsert = new int[numAwayFactorial * 2];
            }
            else
            {
                valuesToInsert = new int[(numAwayFactorial * 2) + (m)];
            }

            //insert values that average to AverageValue specified and
            //surround AverageValue equally to represent numberSegments
            //specified, continually equal distances away from AverageValue
            //in steps of 1

            //use n to navigate place in valuesToInsert array
            int n = 0;
            bool averageValueInserted = false;
            for (int i = 0; i < numberSegments; i++)
            {
                if (i < numberAwayFromAverage)
                {
                    for (int k = 0; k < i + 1; k++)
                    {
                        valuesToInsert[n] = averageValue - (numberAwayFromAverage - i);
                        n++;
                    }
                }
                else
                {
                    if (includeAverage != 0 && !averageValueInserted)
                    {
                        for (int k = 0; k < m; k++)
                        {
                            valuesToInsert[n] = averageValue;
                            n++;
                        }
                        averageValueInserted = true;
                    }
                    else
                    {
                        for (int k = 0; k < numberSegments - i; k++)
                        {
                            valuesToInsert[n] = averageValue + (i - numberAwayFromAverage);
                            n++;
                        }
                    }
                }
            }

            return valuesToInsert;
        }

        ///-------------------------------------------------------------------------------
        /// <summary>
        /// Logs shape of data inserted for quick reference
        /// </summary>
        /// <param name="dataArray">int[]</param>
        /// <history>
        ///      starrpar   12-MAY-10   Created
        /// </history>
        ///-------------------------------------------------------------------------------
        private static void LogDataShape(int[] dataArray)
        {
            int min = 100000;
            int max = 0;
            int numVals = 0;

            foreach (int x in dataArray)
            {
                if (x < min)
                    min = x;

                if (x > max)
                    max = x;

                numVals++;
            }

            LogMessage("Sparseness/density of data - span: " + (max - min) + ", numVals: " + numVals);

            Dictionary<int, int> dataDistribution = new Dictionary<int, int>();
            int numOccurences = 0;
            for (int i = min; i <= max; i++)
            {
                foreach (int x in dataArray)
                {
                    if (i.Equals(x))
                    {
                        numOccurences++;
                    }
                }
                dataDistribution.Add(i, numOccurences);
                numOccurences = 0;
            }

            LogMessage("Data distribution:");
            foreach(KeyValuePair<int, int> kvp in dataDistribution)
            {
                if (kvp.Value != 0)
                {
                    string tmpStr = kvp.Key.ToString() + ":";
                    for (int j = 0; j < kvp.Value; j++)
                    {
                        tmpStr += "x";
                    }
                    LogMessage(tmpStr);
                }
                else
                {
                    LogMessage(kvp.Key.ToString() + ":");
                }
            }
        }

        ///-------------------------------------------------------------------------------
        /// <summary>
        /// Inserts Performance data into DW
        /// This method takes the number of agents for which data is to be inserted into DW,
        /// the length of time over which to insert data, in minutes, up to 1 month [43,200],
        /// (limited by the product), and the number of CPU 'entities' to create for each agent.
        /// It will then create the instance data for those agents in the DW, get the
        /// ManagedEntityID and HealthServiceIDs (for the CPUx objects) for those agents
        /// and call WAMLGT.exe to insert that data for the length of time specified in the
        /// past, up to present, one minute at a time, for each CPU entity.
        /// </summary>
        /// <param name="numberAgents">number of agents to insert data for</param>
        /// <param name="numberCPUs">number of CPUs for which counters will be simulated for each agent</param>
        /// <param name="startTimeInMinutesBack">number of minutes back to insertion start time</param>
        /// <param name="durationInMinutes">number of minutes worth of data to insert, from startTimeInMinutesBack</param>
        /// <param name="valueToInsert">value to insert</param>
        /// <param name="managedEntityBaseString">string specifying base of inserted managed entities 
        /// (eg. "Microsoft.Windows.Server.2003.Processor:WKSTNN")</param>
        /// <param name="healthServiceBaseString">string specifying base of health services 
        /// (eg. "WKSTNN")</param>
        /// <param name="ruleType">string specifying rule type  
        /// (eg. "Microsoft.Windows.Server.2003.Processor")</param>
        /// <param name="ruleName">string specifying rule name 
        /// (eg. "Microsoft.Windows.Server.2003.Processor.PercentProcessorTime.Collection")</param>
        /// <param name="ctx">IContext object</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        /// <history>
        ///      [StarrPar]   30Oct09 Created
        /// </history>
        ///-------------------------------------------------------------------------------

        public static void InsertPerformanceData(
            int numberAgents,
            int numberCPUs,
            int startTimeInMinutesBack,
            int durationInMinutes,
            int valueToInsert,
            string managedEntityBaseString,
            string healthServiceBaseString,
            string ruleType,
            string ruleName,
            IContext ctx)
        {
            string runAsName = MOMCOMMON_PATH + RUNASPROCESS_FILENAME;
            string wamlgtFileName = MOMCOMMON_PATH + WAMLGT_FILENAME;
            string momdwPassword = "";

            //TODO: make work and remove workaround string literals
            //NOTE: think this works now without explicit password
            if (PasswordManager.AccountExists(MOMDW_ACCOUNT))
                momdwPassword = PasswordManager.GetPassword(MOMDW_ACCOUNT);

            //set DW name and SQL instance for use beyond this point
            if (m_DBInstanceName == null)
                SetServerName();
            if (m_DBName == null)
                SetUrlDBName();

            #region Get WAMLGT parameters for insertion of Performance counter data

            //get managedEntityIDs and healthServiceIDs for those agents, and ruleID for appropriate perf counter
            ArrayList healthServiceIDs = null;
            ArrayList managedEntityIDs = null;
            string ruleID = null;
            string objectName = PROCESSOR;
            string counter = PERCENT_PROCESSOR;

            // Get all the parameters to be passed to WAMLGT for data generation
            GetWAMLGTPerfParametersEx(ctx,
                out healthServiceIDs,
                out managedEntityIDs,
                out ruleID,
                numberAgents,
                numberCPUs,
                managedEntityBaseString,
                healthServiceBaseString,
                ruleType,
                ruleName
                );

            // Verify that parameter values are non-null
            if (healthServiceIDs == null
                || managedEntityIDs == null
                || ruleID == null
                || objectName == null
                // || instances == null
                || counter == null)
            {
                throw new Exception("ReportUtil.RunPerformanceDataInsertionCommand :: Could not get some or all parameter values before calling WAMLGT");
            }

            #endregion

            #region find Perf load file

            //call WAMLGT.exe to insert data for all CPUs for every agent once/minute starting from the number of minutes specified into the past
            string loadPerfDataFileName = LOAD_PERF_FILENAME;
            string payloadPerfDataFileName = PAYLOAD_PERF_FILENAME;
            string payloadPerfDataBackupFileName = PAYLOAD_PERF_BACKUP_FILENAME;

            // Check whether the WAMLGT files exists
            System.IO.FileInfo fi = new FileInfo(wamlgtFileName);
            System.IO.FileInfo fi_loadFile = new FileInfo(loadPerfDataFileName);
            if (!fi.Exists || !fi_loadFile.Exists)
            {
                if (!fi.Exists)
                {
                    ctx.Alw("Cannot find the exec file: " + wamlgtFileName);
                }
                else
                {
                    ctx.Alw("Cannot find file: " + loadPerfDataFileName);
                    throw new VarAbort("Cannot find file: " + loadPerfDataFileName);
                }
            }

            Thread.Sleep(5000);

            #endregion

            #region Check if inserted discovery data transferred to DW

            //TODO: make these data driven, or add better logic
            int numTries = 0;
            int maxTries = 30;
            while (!CheckIfInsertedDataExistsInDW(numberAgents, ctx) && numTries < maxTries)
            {
                //check again in 15 seconds
                LogMessage("Checking if inserted data exists in DW - will recheck in 15 seconds");
                Thread.Sleep(15000);
                numTries++;
            }

            if (!CheckIfInsertedDataExistsInDW(numberAgents, ctx))
            {
                throw new VarAbort("Inserted fake agent data not present in DW");
            }

            #endregion

            #region Calculate time range and insert into payload file

            DateTime startTime = DateTime.Now.ToUniversalTime().AddMinutes(-startTimeInMinutesBack);
            DateTime endTime = startTime.AddMinutes(durationInMinutes);

            //loop through aggregation stored procedure from start of insertion (plus 1 to be safe)
            int numAggregationLoops = (startTimeInMinutesBack / 60) + 1;

            // Get the dateTime in the format expected by WAMLGT
            //Format:2009-10-22T01:12:43.594Z
            string startTimeStamp = FormatDateTime(startTime);
            string endTimeStamp = FormatDateTime(endTime);
            ctx.Trc("startTimeStamp: " + startTimeStamp);
            ctx.Trc("endTimeStamp: " + endTimeStamp);

            //use these datetime values to replace the start and end datetimes in payload perfdata file
            StreamReader reader = new StreamReader(File.OpenRead(payloadPerfDataFileName));
            string fileContents = reader.ReadToEnd();
            reader.Close();

            if (fileContents.Contains(STARTTIME))
            {
                StreamWriter tmpWriter = new StreamWriter(File.OpenWrite(payloadPerfDataBackupFileName));
                tmpWriter.Write(fileContents);
                tmpWriter.Close();
            }
            else
            {
                StreamReader tmpReader = new StreamReader(File.OpenRead(payloadPerfDataBackupFileName));
                fileContents = tmpReader.ReadToEnd();
                tmpReader.Close();
            }

            fileContents = fileContents.Replace(STARTTIME, startTimeStamp);
            fileContents = fileContents.Replace(ENDTIME, endTimeStamp);

            StreamWriter writer = new StreamWriter(File.OpenWrite(payloadPerfDataFileName));
            writer.Write(fileContents);
            writer.Close();

            #endregion

            #region Call WAMLGT for Perf data insertion

            //Design note: because we install reporting for deployment testing purposes using the 
            //account momDW as the Data Warehouse Writer account, we need to use RunProcessAs
            //to initiate the wamlgt.exe process in order to have permission to insert
            //data into the DW - this also requires dropping a log file from WAMLGT
            //this is accomodated by calling the following from within Reports_run.cmd
            //%SYSTEMDRIVE%\%TEST%\UI\Common\AddUserToAdminGroup_run.cmd SMX\momDW Reports FUNC

            string perfLogFileLocation = Environment.GetEnvironmentVariable("WinDir") + PERF_LOGFILE_PREFACE;

            //Design approach: Iterate through each agent machine, and run WAMLGT for number of CPUs specified
            //per agent machine, incrementing the health service and managed entity indexes as follows:
            //health service corresponds to agent, so increment by agent index, managed entity corresponds
            //to CPU on each agent, so increment by "(2 * agent_index) + CPU_index[0,1]", which will take
            //twice the agent index plus the next entry - the effect will be that agent 0 will correspond
            //with entities 0 and 1, agent 1 will correspond with entities 2 and 3, and agent 99 will correspond
            //to entities 198 and 199, which is the intended association.

            DateTime beginInsertion = new DateTime();
            DateTime endInsertion = new DateTime();
            string localDir = System.Environment.CurrentDirectory;
            
            beginInsertion = DateTime.Now;

            for (int i = 0; i < numberAgents; i++)
            {
                for (int j = 0; j < numberCPUs; j++)
                {
                    string cmdLine1 = " " + SMX_DOMAIN + MOMDW_ACCOUNT + " " + momdwPassword + " " + localDir + " " + wamlgtFileName + " \"" + loadPerfDataFileName + " " + perfLogFileLocation;
                    string cmdLine2 = ".out PerfDataCount:" + durationInMinutes + " HealthServiceId:" + healthServiceIDs[i] + " ObjectName:" + objectName + " CounterName:" + counter + " InstanceName:" + (j % 2).ToString() + " Value:" + valueToInsert.ToString() + " ManagedEntityId:" + managedEntityIDs[(2 * i) + j] + " RuleId:" + ruleID + " PerfDataitemTarget:ModuleHost.DW.PerfData\"";
                    //string cmdLine2 = ".out PerfDataCount:" + durationInMinutes + " HealthServiceId:" + healthServiceIDs[i] + " ObjectName:" + objectName + " CounterName:" + counter + " InstanceName:" + (j % 2).ToString() + " Value:" + ((j % 2) + 1).ToString() + " ManagedEntityId:" + managedEntityIDs[(2 * i) + j] + " RuleId:" + ruleID + " PerfDataitemTarget:ModuleHost.DW.PerfData\"";

                    System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                    myProcess.StartInfo.FileName = runAsName;
                    myProcess.StartInfo.Arguments = cmdLine1 + System.Guid.NewGuid() + cmdLine2;
                    myProcess.StartInfo.RedirectStandardOutput = false;
                    myProcess.StartInfo.WorkingDirectory = localDir;
#if DEBUGG
                    ctx.Trc("cmdline: " + myProcess.StartInfo.FileName + "" +
                        myProcess.StartInfo.Arguments);
#endif
                    ctx.Trc("Calling WAMLGT... perf data insertion, agent: " + (i + 1) + ", CPU: " + (j + 1));
                    ctx.Trc(myProcess.StartInfo.FileName + myProcess.StartInfo.Arguments);
                    myProcess.Start();

                    //let run for 5 minutes, checking every 15 seconds for completion, before giving up
                    for (int k = 0; k <= 20; k++)
                    {
                        if (myProcess.HasExited)
                        {
                            ctx.Trc("Performance Data generation complete");
                            break;
                        }
                        Thread.Sleep(1000);
                    }
                }

            }

            #endregion

            #region report overall timing

            endInsertion = DateTime.Now;

            TimeSpan ts = new TimeSpan();

            ts = endInsertion - beginInsertion;

            ctx.Trc("Time required for perf data insertion: " + ts.Hours + " hours, " + ts.Minutes + " minutes, " +
                ts.Seconds + " seconds, " + ts.Milliseconds + " milliseconds");

            #endregion
        }

        #endregion
        

        ///-------------------------------------------------------------------------------
        /// <summary>
        /// verifies data inserted to Ops DB using WAMLGT exists in DW ManagedEntity table
        /// </summary>
        /// <param name="ctx">IContext</param>
        /// <returns>int</returns>
        /// <exception cref="System.Exception"></exception>
        /// <history>
        ///      starrpar   30-JUN-10    Created
        /// </history>
        ///-------------------------------------------------------------------------------
        public static int NumComputersTransferredToDW(IContext ctx)
        {
            int numComputersPresent;

            if (m_DBInstanceName == null)
                SetServerName();
            if (m_DBName == null)
                SetUrlDBName();

            DBUtil.ConnectToMOMDW(m_DBInstanceName, m_DBName);

            //DBUtil.ExecuteScalarQuery() - single result value
            string instanceDataQuery = "SELECT Count(*) FROM vManagedEntity where Name like '%WKSTN%'";
            numComputersPresent = Convert.ToInt32(DBUtil.ExecuteScalarQuery(instanceDataQuery).ToString());
            LogMessage("numComputers transferred to DW is: " + numComputersPresent.ToString());

            return numComputersPresent;
        }

        ///-------------------------------------------------------------------------------
        /// <summary>
        /// verifies data of type inserted to Ops DB using WAMLGT exists in DW ManagedEntity table
        /// </summary>
        /// <param name="ctx">IContext</param>
        /// <returns>List(int)</returns>
        /// <exception cref="System.Exception"></exception>
        /// <history>
        ///      starrpar   05-MAY-10    Created
        /// </history>
        ///-------------------------------------------------------------------------------
        public static List<int> GetPerfRuleInstanceRowIdForInsertedData(IContext ctx)
        {
            if (m_DBInstanceName == null)
                SetServerName();
            if (m_DBName == null)
                SetUrlDBName();

            DBUtil.ConnectToMOMDW(m_DBInstanceName, m_DBName);

            //DBUtil.ExecuteScalarQuery() - single result value
            string ruleRowIdQuery = "SELECT RuleRowId FROM vRule where RuleDefaultName = 'Processor % Processor Time 2003'";
            string ruleRowId = DBUtil.ExecuteScalarQuery(ruleRowIdQuery).ToString();
            LogMessage("RuleRowId is: " + ruleRowId);

            //DBUtil.ExecuteQueryWithResults() - multiple result values
            string perfRuleInstanceQuery = "SELECT * FROM PerformanceRuleInstance where RuleRowId = '" + ruleRowId + "'";
            System.Data.DataView perfRuleQueryResults = null;
            perfRuleQueryResults = DBUtil.ExecuteQueryWithResults(perfRuleInstanceQuery);
            List<int> perfRuleInstanceRowIds = new List<int>();
            for (int i = 0; i < perfRuleQueryResults.Count; i++)
            {
                string tmpStr = perfRuleQueryResults[i].Row[0].ToString();
                perfRuleInstanceRowIds.Add(Convert.ToInt32(tmpStr));
                LogMessage("PerformanceRuleInstanceRowId is: " + (perfRuleQueryResults[i].Row[0]).ToString());
            }

            return perfRuleInstanceRowIds;
        }

        ///-------------------------------------------------------------------------------
        /// <summary>
        /// verifies data of type inserted to Ops DB using WAMLGT exists in DW ManagedEntity table
        /// </summary>
        /// <param name="numberAgents">int</param>
        /// <param name="requirement">bool</param>
        /// <param name="ctx">IContext</param>
        /// <returns>bool</returns>
        /// <exception cref="System.Exception"></exception>
        /// <history>
        ///      starrpar   05-MAY-10    Created
        /// </history>
        ///-------------------------------------------------------------------------------
        public static bool CheckIfInsertedDataExistsInDW(
            int numberAgents, 
            IContext ctx)
        {
            bool dataPresent = false;

            //set DW name and SQL instance for use beyond this point
            if (m_DBInstanceName == null)
                SetServerName();
            if (m_DBName == null)
                SetUrlDBName();

            DBUtil.ConnectToMOMDW(m_DBInstanceName, m_DBName);
            string sqlQuery = "SELECT Count(*) FROM ManagedEntity WHERE Name like '%WKSTN%'";
            string strNumNames = DBUtil.ExecuteScalarQuery(sqlQuery).ToString();
            int numNames = Convert.ToInt32(strNumNames);
            DBUtil.CloseMOMDWConnection();

            if (numNames >= numberAgents)
            {
                LogMessage("# of fake agents present in DW: " + numNames);
                LogMessage("# of agents to insert perf data for: " + numberAgents);
                dataPresent = true;
            }
            else
            {
                if (numNames > 0)
                {
                    LogMessage("Some agents are transferred over to DW: " + numNames + "; but not as " +
                        "many as the number of agents indicated for this run: " + numberAgents);
                }
            }
            return dataPresent;
        }

        public static int ExecuteQueryReturnCount(
            string query,
            database db,
            int maxWaitInMinutes
            )
        {
            int waitTime = 0;
            int result = 0;
            if (db.Equals(database.OpsDB))
            {
                DBUtil.ConnectToMOMDB(MomServerName);
                while (waitTime < maxWaitInMinutes)
                {
                    result = (int) DBUtil.ExecuteScalarQuery(query);
                    waitTime++;
                    if(result <= 0)
                    {
                        Sleeper.Delay(Constants.OneMinute);
                    }
                }
                DBUtil.CloseMOMDBConnection();
            }
            else
            {
                if (m_DBInstanceName == null)
                    SetServerName();
                if (m_DBName == null)
                    SetUrlDBName();

                DBUtil.ConnectToMOMDW(m_DBInstanceName, m_DBName);
                while (waitTime < maxWaitInMinutes)
                {
                    result = (int) DBUtil.ExecuteScalarQuery(query);
                    waitTime++;
                    if (result <= 0)
                    {
                        Sleeper.Delay(Constants.OneMinute);
                    }
                }
                DBUtil.CloseMOMDWConnection();
            }

            return result;
        }
        
        public static DataView ExecuteQueryWithResultsAgainstDatabase(
            string query,
            database db,
            int maxWaitInMinutes
            )
        {
            //TODO: Add support for various types of queries 
            //ExecuteScalarQuery (returns object), 
            //ExecuteQueryWithResults (returns DataView),
            //and possibly ExecuteQuery (returns int))

            int waitTime = 0;
            DataView result = null;
            if (db.Equals(database.OpsDB))
            {
                DBUtil.ConnectToMOMDB(MomServerName);
                while (result == null && waitTime < maxWaitInMinutes)
                {
                    result = DBUtil.ExecuteQueryWithResults(query);
                    Sleeper.Delay(Constants.OneMinute);
                    waitTime++;
                }
                DBUtil.CloseMOMDBConnection();
            }
            else
            {
                if (m_DBInstanceName == null)
                    SetServerName();
                if (m_DBName == null)
                    SetUrlDBName();

                DBUtil.ConnectToMOMDW(m_DBInstanceName, m_DBName);
                while (result == null && waitTime < maxWaitInMinutes)
                {
                    result = DBUtil.ExecuteQueryWithResults(query);
                    Sleeper.Delay(Constants.OneMinute);
                    waitTime++;
                }
                DBUtil.CloseMOMDWConnection();
            }

            return result;
        }

        public static object ExecuteScalarQueryAgainstDatabase(
            string query,
            database db,
            int maxWaitInMinutes
            )
        {
            //TODO: Add support for various types of queries 
            //ExecuteScalarQuery (returns object), 
            //ExecuteQueryWithResults (returns DataView),
            //and possibly ExecuteQuery (returns int))

            int waitTime = 0;
            object result = null;
            if (db.Equals(database.OpsDB))
            {
                DBUtil.ConnectToMOMDB(MomServerName);
                while (result == null && waitTime < maxWaitInMinutes)
                {
                    result = DBUtil.ExecuteScalarQuery(query);
                    Sleeper.Delay(Constants.OneMinute);
                    waitTime++;
                }
                DBUtil.CloseMOMDBConnection();
            }
            else
            {
                if (m_DBInstanceName == null)
                    SetServerName();
                if (m_DBName == null)
                    SetUrlDBName();

                DBUtil.ConnectToMOMDW(m_DBInstanceName, m_DBName);
                while (result == null && waitTime < maxWaitInMinutes)
                {
                    result = DBUtil.ExecuteScalarQuery(query);
                    Sleeper.Delay(Constants.OneMinute);
                    waitTime++;
                }
                DBUtil.CloseMOMDWConnection();
            }

            return result;
        }

        public static bool ExecuteQueryAgainstDatabase(
            string query,
            database db,
            int maxWaitInMinutes
            )
        {
            //TODO: Add support for various types of queries 
            //ExecuteScalarQuery (returns object), 
            //ExecuteQueryWithResults (returns DataView),
            //and possibly ExecuteQuery (returns int))

            int waitTime = 0;
            bool result = false;
            if (db.Equals(database.OpsDB))
            {
                DBUtil.ConnectToMOMDB(MomServerName);
                while (!result && waitTime < maxWaitInMinutes)
                {
                    result = DBUtil.IsDataExists(query);
                    Sleeper.Delay(Constants.OneMinute);
                    waitTime++;
                }                
                DBUtil.CloseMOMDBConnection();
            }
            else
            {
                if (m_DBInstanceName == null)
                    SetServerName();
                if (m_DBName == null)
                    SetUrlDBName();

                DBUtil.ConnectToMOMDW(m_DBInstanceName, m_DBName);
                while (!result && waitTime < maxWaitInMinutes)
                {
                    result = DBUtil.IsDataExists(query);
                    Sleeper.Delay(Constants.OneMinute);
                    waitTime++;
                }
                DBUtil.CloseMOMDWConnection();
            }

            return result;
        }

        ///-------------------------------------------------------------------------------
        /// <summary>
        /// verifies data of type inserted to Ops DB using WAMLGT exists in DW ManagedEntity table
        /// </summary>
        /// <param name="average">int</param>
        /// <param name="numSegments">int</param>
        /// <param name="aggregationMeans">int</param>
        /// <param name="ctx">IContext</param>
        /// <returns>bool</returns>
        /// <exception cref="System.Exception"></exception>
        /// <history>
        ///      starrpar   05-MAY-10    Created
        /// </history>
        ///-------------------------------------------------------------------------------
        public static bool CheckIfDataAggregated(int average,
            int numSegments, int aggregationMeans, IContext ctx)
        {
            bool dataAggregated = false;

            //set DW name and SQL instance for use beyond this point
            if (m_DBInstanceName == null)
                SetServerName();
            if (m_DBName == null)
                SetUrlDBName();

            DBUtil.ConnectToMOMDW(m_DBInstanceName, m_DBName);

            List<int> perfRuleInstIds = GetPerfRuleInstanceRowIdForInsertedData(ctx);
            
            //if not yet present, retry for a short while
            int numTries = 0;
            int maxTries = 5;
            while (perfRuleInstIds.Count <= 0 && numTries < maxTries)
            {
                Thread.Sleep(Constants.OneMinute);
                perfRuleInstIds = GetPerfRuleInstanceRowIdForInsertedData(ctx);
                numTries++;
            }

            if (perfRuleInstIds.Count <= 0 && numTries == maxTries)
            {
                //LogMessage("The following SQL query failed to return any values: " + 
                //    "SELECT * FROM PerformanceRuleInstance where RuleRowId = '(RuleRowId shown above)'");
                throw new VarAbort("The following SQL query failed to return any values: " +
                    "SELECT * FROM PerformanceRuleInstance where RuleRowId = '(RuleRowId shown above)'");
            }

            string perfRuleInstancesString = string.Empty;
            for (int i = 0; i < perfRuleInstIds.Count; i++)
            {
                perfRuleInstancesString += perfRuleInstIds[i] + ", ";
            }

            perfRuleInstancesString = perfRuleInstancesString.Trim();

            //remove last comma
            if (perfRuleInstancesString.Trim().EndsWith(","))
            {
                perfRuleInstancesString = perfRuleInstancesString.Substring(0, perfRuleInstancesString.LastIndexOf(","));
            }

            int minVal = average - (numSegments/2);
            int maxVal = average + (numSegments/2);

            string rawSqlQuery = "SELECT Count(*) FROM Perf.vPerfRaw WHERE PerformanceRuleInstanceRowId in (" +
                perfRuleInstancesString + ") AND SampleValue between " + minVal + " AND " + maxVal;

            string strNumRows = DBUtil.ExecuteScalarQuery(rawSqlQuery).ToString();
            int numRows = Convert.ToInt32(strNumRows);
            LogMessage("number of rows found in Raw table: " + numRows);

            string aggregationTypeString = string.Empty;
            if (aggregationMeans.ToString().Equals("20"))
            {
                aggregationTypeString = "Hourly";
            }
            else if (aggregationMeans.ToString().Equals("30"))
            {
                aggregationTypeString = "Daily";
            }
            else
            {
                throw new VarAbort("Invalid aggregation means: " + aggregationMeans.ToString());
            }

            string aggregatedTableQuery = "SELECT SampleCount FROM Perf.vPerf" + aggregationTypeString +
                " WHERE PerformanceRuleInstanceRowId in (" + perfRuleInstancesString +
                ") AND MinValue between " + minVal + " AND " + maxVal;

            System.Data.DataView aggregatedDataQuery = null;
            aggregatedDataQuery = DBUtil.ExecuteQueryWithResults(aggregatedTableQuery);

            LogMessage("number of rows found in " + aggregationTypeString + " table: " + aggregatedDataQuery.Count);

            int sumSampleCount = 0;
            for (int i = 0; i < aggregatedDataQuery.Count; i++)
            {
                sumSampleCount += Convert.ToInt32(aggregatedDataQuery[i].Row[0]);
            }
            DBUtil.CloseMOMDWConnection();

            LogMessage("sum of sample counts aggregated in " + aggregationTypeString + " table: " + sumSampleCount.ToString());

            //check to see if number of rows inserted in Raw table are fully aggregated to specified table (Hourly/Daily)
            if (numRows != 0 && numRows.Equals(sumSampleCount))
            {
                dataAggregated = true;
            }
            return dataAggregated;
        }

        #region Insert State Change Data into DW

        ///-------------------------------------------------------------------------------
        /// <summary>
        /// Inserts State Change data into DW
        /// This method takes the number of agents for which data is to be inserted into DW,
        /// the length of time over which to insert data, in minutes, up to 1 month [43,200],
        /// (limited by the product), and the number of DB 'entities' to create for each agent
        /// (only 2 is supported presently - 'master' and 'model') - need to extend this.
        /// It will then create the instance data for those agents in the DW, get the
        /// ManagedEntityID and HealthServiceIDs (for the DBx objects) for those agents
        /// and call WAMLGT.exe to insert that data for the length of time specified in the
        /// past, up to present, one minute at a time, for each DB entity.
        /// </summary>
        /// <param name="numberAgents">number of agents to insert data for</param>
        /// <param name="numberDBs">number of DBs for which state data will be simulated for each agent</param>
        /// <param name="startTimeInMinutesBack">number of minutes back to insertion start time</param>
        /// <param name="durationInMinutes">number of minutes worth of data to insert, back from startTimeInMinutesBack</param>
        /// <param name="valueToInsert">value to insert</param>
        /// <param name="managedEntityBaseString">string specifying base of inserted managed entities 
        /// (eg. "Microsoft.Windows.Server.2003.Processor:WKSTNN")</param>
        /// <param name="healthServiceBaseString">string specifying base of health services 
        /// (eg. "WKSTNN")</param>
        /// <param name="monitorName">string specifying monitor name 
        /// (eg. "System.Health.AvailabilityState")</param>
        /// <param name="ctx">IContext object</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        /// <history>
        ///      [StarrPar]   19Nov09 Created
        /// </history>
        ///-------------------------------------------------------------------------------

        public static void InsertStateChangeData(
            int numberAgents,
            int numberDBs,
            int startTimeInMinutesBack,
            int durationInMinutes,
            int valueToInsert,
            string managedEntityBaseString,
            string healthServiceBaseString,
            string monitorName,
            IContext ctx)
        {
            string runAsName = MOMCOMMON_PATH + RUNASPROCESS_FILENAME;
            string wamlgtFileName = MOMCOMMON_PATH + WAMLGT_FILENAME;
            string momdwPassword = "";

            //TODO: make work and remove workaround string literals
            //NOTE: think this works now without explicit password
            if (PasswordManager.AccountExists(MOMDW_ACCOUNT))
                momdwPassword = PasswordManager.GetPassword(MOMDW_ACCOUNT);

            //set DW name and SQL instance for use beyond this point
            if (m_DBInstanceName == null)
                SetServerName();
            if (m_DBName == null)
                SetUrlDBName();


            #region Get WAMLGT parameters for insertion of Performance counter data

            //get managedEntityIDs and healthServiceIDs for those agents, and ruleID for appropriate perf counter
            ArrayList healthServiceIDs = null;
            ArrayList managedEntityIDs = null;
            ArrayList eventOriginIDs = null;
            string monitorID = null;

            //Select ManagedEntityGuid from ManagedEntity
            //Where FullName like '%Computer:WKSTNN1'
            //Select ManagedEntityGuid from ManagedEntity
            //Where FullName like '%Processor:WKSTNN1;CPU%'
            //Select RuleGuid FROM [OperationsManagerDW].[dbo].[Rule]
            //Where RuleDefaultName like 'Processor % Processor Time 2003'

            // Get all the parameters to be passed to WAMLGT for data generation
            GetWAMLGTStateChangeParameters(ctx,
                out healthServiceIDs,
                out managedEntityIDs,
                out eventOriginIDs,
                out monitorID,
                numberAgents,
                numberDBs,
                managedEntityBaseString,
                healthServiceBaseString,
                monitorName
                );

            if (healthServiceIDs == null
                || managedEntityIDs == null
                || eventOriginIDs == null
                || monitorID == null)
            {
                throw new Exception("ReportUtil.GenerateStateChantgeDataUsingWAMLGT :: Could not get some or all parameter values before calling WAMLGT");
            }

            #endregion

            #region preparation steps

            //call WAMLGT.exe to insert data for all DBs for every agent once/minute starting from the number of minutes specified into the past

            // Check whether the WAMLGT files exists
            System.IO.FileInfo fi = new FileInfo(wamlgtFileName);
            System.IO.FileInfo fi_loadFile = new FileInfo(LOAD_STATECHANGE_FILENAME);
            if (!fi.Exists || !fi_loadFile.Exists)
            {
                if (!fi.Exists)
                {
                    ctx.Alw("Cannot find the exec file: " + wamlgtFileName);
                }
                else
                {
                    ctx.Alw("Cannot find file: " + LOAD_STATECHANGE_FILENAME);
                    throw new VarAbort("Cannot find file: " + LOAD_STATECHANGE_FILENAME);
                }

            }

            #endregion

            #region Calculate time range and insert into payload file

            DateTime startTime = DateTime.Now.ToUniversalTime().AddMinutes(-startTimeInMinutesBack);
            DateTime endTime = startTime.AddMinutes(durationInMinutes);

            // Get the dateTime in the format expected by WAMLGT
            //Format:2009-10-22T01:12:43.594Z
            string startTimeStamp = FormatDateTime(startTime);
            string currentTimeStamp = FormatDateTime(endTime);

            ctx.Trc("currentTime: " + currentTimeStamp);
            ctx.Trc("startTime: " + startTimeStamp);

            //use these datetime values to replace the start and end datetimes in payload perfdata file
            StreamReader reader = new StreamReader(File.OpenRead(PAYLOAD_STATECHANGE_FILENAME));
            string fileContents = reader.ReadToEnd();
            reader.Close();
            fileContents = fileContents.Replace("$STARTTIME$", startTimeStamp);
            fileContents = fileContents.Replace("$ENDTIME$", currentTimeStamp);
            StreamWriter writer = new StreamWriter(File.OpenWrite(PAYLOAD_STATECHANGE_FILENAME));
            writer.Write(fileContents);
            writer.Close();

            #endregion

            #region Call WAMLGT for State Change data insertion

            //Design note: because we install reporting for deployment testing purposes using the 
            //account momDW as the Data Warehouse Writer account, we need to use RunProcessAs
            //to initiate the wamlgt.exe process in order to have permission to insert
            //data into the DW - this also requires dropping a log file from WAMLGT
            //this is accomodated by calling the following from within Reports_run.cmd
            //%SYSTEMDRIVE%\%TEST%\UI\Common\AddUserToAdminGroup_run.cmd SMX\momDW Reports FUNC

            string stateChgLogFileLocation = Environment.GetEnvironmentVariable("WinDir") + STATECHANGE_LOGFILE_PREFACE;

            //Design approach: Iterate through each agent machine, and run WAMLGT for number of CPUs specified
            //per agent machine, incrementing the health service and managed entity indexes as follows:
            //health service corresponds to agent, so increment by agent index, managed entity corresponds
            //to CPU on each agent, so increment by "(2 * agent_index) + CPU_index[0,1]", which will take
            //twice the agent index plus the next entry - the effect will be that agent 0 will correspond
            //with entities 0 and 1, agent 1 will correspond with entities 2 and 3, and agent 99 will correspond
            //to entities 198 and 199, which is the intended association.

            DateTime beginInsertion = new DateTime();
            DateTime endInsertion = new DateTime();
            string localDir = System.Environment.CurrentDirectory;

            beginInsertion = DateTime.Now;

            for (int i = 0; i < numberAgents; i++)
            {
                for (int j = 0; j < numberDBs; j++)
                {
                    //temp workaround
                    string cmdLine1 = " " + SMX_DOMAIN + MOMDW_ACCOUNT + " " + momdwPassword + " " + localDir + " " + wamlgtFileName + " \"" + LOAD_STATECHANGE_FILENAME + " " + stateChgLogFileLocation;
                    string cmdLine2 = ".out StateDataCount:" + durationInMinutes / 10 + " StateChangeCount:1 HealthServiceId:" + healthServiceIDs[i] + " ManagedEntityId:" + managedEntityIDs[(2 * i) + j] + " EventOriginId:" + eventOriginIDs[i] + " MonitorId:" + monitorID + " StateChangeDataitemTarget:ModuleHost.DW.StateChange\"";
                    //string cmdLine2 = ".out StateDataCount:" + durationInMinutes / 10 + " StateChangeCount:1 HealthServiceId:" + healthServiceIDs[i] + " ManagedEntityId:" + managedEntityIDs[(2 * i) + j] + " EventOriginId:" + eventOriginIDs[i] + " MonitorId:" + monitorID + " StateChangeDataitemTarget:ModuleHost.DW.StateChange\"";

                    System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                    myProcess.StartInfo.FileName = runAsName;
                    myProcess.StartInfo.Arguments = cmdLine1 + System.Guid.NewGuid() + cmdLine2;
                    myProcess.StartInfo.RedirectStandardOutput = false;
                    myProcess.StartInfo.WorkingDirectory = localDir;
#if DEBUGG
                    ctx.Trc("cmdline: " + myProcess.StartInfo.FileName + "" +
                        myProcess.StartInfo.Arguments);
#endif
                    ctx.Trc("Calling WAMLGT... state change data insertion, agent: " + (i + 1) + ", DB: " + (j + 1));
                    ctx.Trc(myProcess.StartInfo.FileName + myProcess.StartInfo.Arguments);
                    myProcess.Start();

                    //let run for 5 minutes, checking every 15 seconds for completion, before giving up
                    for (int k = 0; k <= 20; k++)
                    {
                        if (myProcess.HasExited)
                        {
                            ctx.Trc("State Change Data generation complete");
                            break;
                        }
                        ctx.Alw("State Change Data generation has not completed yet. Will check again in 15 seconds...");
                        Thread.Sleep(15000);
                    }
                }
            }

            #endregion

            #region report overall timing

            endInsertion = DateTime.Now;

            TimeSpan ts = new TimeSpan();

            ts = endInsertion - beginInsertion;

            ctx.Trc("Time required for state change data insertion: " + ts.Hours + " hours, " + ts.Minutes + " minutes, " +
                ts.Seconds + " seconds, " + ts.Milliseconds + " milliseconds");

            #endregion
        }

        #endregion

        #region Data Insertion support methods
        
        /// <summary>
        /// Method to get the Arguments to be passed to WAMLGT for (Perf) data generation
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="healthServiceIDs"></param>
        /// <param name="managedEntityIDs"></param>
        /// <param name="ruleID"></param>
        /// <param name="nAgents"></param>
        /// <param name="nCPUs"></param>
        /// <param name="managedEntityBaseString">string specifying base of inserted managed entities 
        /// (eg. "Microsoft.Windows.Server.2003.Processor:WKSTNN")</param>
        /// <param name="healthServiceBaseString">string specifying base of health services 
        /// (eg. "WKSTNN")</param>
        /// <param name="ruleType">string specifying rule type  
        /// (eg. "Microsoft.Windows.Server.2003.Processor")</param>
        /// <param name="ruleName">string specifying rule name 
        /// (eg. "Microsoft.Windows.Server.2003.Processor.PercentProcessorTime.Collection")</param>
        /// <History>
        ///     [a-omkasi] 06-OCT-08    Created
        ///</History>
        static void GetWAMLGTPerfParametersEx(
            IContext ctx,
            out ArrayList healthServiceIDs,
            out ArrayList managedEntityIDs,
            out string ruleID,
            int nAgents,
            int nCPUs,
            string managedEntityBaseString,
            string healthServiceBaseString,
            string ruleType,
            string ruleName
            )
        {
            //ctx.Alw("GetWAMLGTPerfParametersEx() called...");

            healthServiceIDs = null;
            managedEntityIDs = null;
            ruleID = null;

            try
            {

                //Get Manged Entity IDs
                managedEntityIDs = GetManagedEntities(ctx, nAgents, nCPUs, managedEntityBaseString);

                //Get the health service IDs
                healthServiceIDs = GetHealthServices(ctx, nAgents, nCPUs, healthServiceBaseString);

                // Get rule ID
                ruleID = GetRuleID(ruleType, ruleName, ctx);

#if DEBUGG
                ctx.Trc("====================================");
                foreach (string managedEntityID in managedEntityIDs)
                    ctx.Trc("DEBUG: ManagedEntityID: " + managedEntityID);

                ctx.Trc("DEBUG: ME_Count: " + managedEntityIDs.Count);

                foreach (string healthServiceID in healthServiceIDs)
                    ctx.Trc("DEBUG: healthServiceID: " + healthServiceID);

                ctx.Trc("DEBUG: HS_Count: " + healthServiceIDs.Count);

                ctx.Trc("DEBUG: ruleID: " + ruleID);
                ctx.Trc("====================================");
#endif

            }
            catch (SqlException sqle)
            {
                throw new VarAbort("GetWAMLGTPerfParametersEx :: SQL Exception:" + sqle.Message);
            }
            catch (Exception e)
            {
                throw new VarAbort("GetWAMLGTPerfParametersEx :: " + e.Message);
            }
            finally
            {
                // Close MOM DW Connection
                DBUtil.CloseMOMDWConnection();
            }

        }

        /// <summary>
        /// Method to get the Arguments to be passed to WAMLGT for (State Change) data generation
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="healthServiceIDs"></param>
        /// <param name="managedEntityIDs"></param>
        /// <param name="eventOriginIDs"></param>
        /// <param name="monitorID"></param>
        /// <param name="nAgents"></param>
        /// <param name="nDBs"></param>
        /// <param name="managedEntityBaseString">string specifying base of inserted managed entities 
        /// (eg. "Microsoft.Windows.Server.2003.Processor:WKSTNN")</param>
        /// <param name="healthServiceBaseString">string specifying base of health services 
        /// (eg. "WKSTNN")</param>
        /// <param name="monitorName">string specifying monitor name 
        /// (eg. "System.Health.AvailabilityState")</param>        /// <History>
        ///     [a-omkasi] 06-OCT-08    Created
        ///</History>
        static void GetWAMLGTStateChangeParameters(
            IContext ctx,
            out ArrayList healthServiceIDs,
            out ArrayList managedEntityIDs,
            out ArrayList eventOriginIDs,
            out string monitorID,
            int nAgents,
            int nDBs,
            string managedEntityBaseString,
            string healthServiceBaseString,
            string monitorName
            )
        {
            //ctx.Alw("GetWAMLGTStateChangeParameters() called...");

            healthServiceIDs = null;
            managedEntityIDs = null;
            eventOriginIDs = null;
            monitorID = null;

            try
            {
                //Get Manged Entity IDs
                managedEntityIDs = GetBaseManagedEntities(ctx, nAgents, nDBs, managedEntityBaseString);

                //Get the health service IDs
                healthServiceIDs = GetHealthServices(ctx, nAgents, nDBs, healthServiceBaseString);

                // Get Event Origin ID
                // same as managed entity ID
                eventOriginIDs = managedEntityIDs;

                // Get Monitor ID
                monitorID = GetMonitorID(monitorName, ctx);

            }
            catch (Exception e)
            {
                throw new VarAbort("ReportUtil.GetWAMLGTStateChangeParameters :: " + e.Message);
            }
        }

        /// <summary>
        /// Method to get the Managed Entity IDs
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="nAgents"></param>
        /// <param name="nCPUs"></param>
        /// <param name="baseString">string specifying base of inserted managed entities 
        /// (eg. "Microsoft.Windows.Server.2003.Processor:WKSTNN")</param>
        /// <returns>string array of Managed Entity Ids</returns>
        ///<exception cref="SqlException"></exception>
        ///<History>
        ///     [a-omkasi] 26-SEP-08    Created
        ///</History>
        ///
        static ArrayList GetManagedEntities(
            IContext ctx,
            int nAgents,
            int nCPUs,
            string baseString
            )
        {
            //ctx.Alw("GetManagedEntities() called...");

            try
            {
                //string[] ManagedEntityIDs = new string[4];
                // Note: If number of ManagedEntity ID increase beyond four, 
                //the string array length should also be increased.
                ArrayList ManagedEntityIDs = new ArrayList();

                string[] sqlQueries = new string[nAgents * nCPUs];
                // Note: If number of Managed Entity ID increase beyond four, 
                //the string array length should also be increased.

                int qCount = 0;

                ArrayList managedEntityFullNames = new ArrayList();
                if(String.IsNullOrEmpty(baseString))
                    baseString = "Microsoft.Windows.Server.2003.Processor:WKSTNN";

                StringBuilder processorString = new StringBuilder(baseString);
                for (int i = 1; i <= nAgents; i++)
                {
                    for (int j = 0; j < nCPUs; j++)
                    {
                        //processorString.Replace(processorString.ToString(), baseString);
                        if (processorString.ToString() != "")
                            processorString.Replace(processorString.ToString(), "");
                        processorString.Append(baseString);
                        processorString.Append(i.ToString() + ";CPU" + j.ToString());
#if DEBUGG
                        ctx.Trc("DEBUG: processorString: " + processorString);
#endif
                        ctx.Trc("DEBUG: processorString: " + processorString);

                        managedEntityFullNames.Add(processorString.ToString());
                    }
                }

                // Form the queries
                foreach (string managedEntityFullName in managedEntityFullNames)
                {
#if DEBUGG
                    ctx.Trc("qCount: " + qCount + " :: managedEntityFullName: " + managedEntityFullName);
#endif
                    sqlQueries[qCount++] = "select ManagedEntityGuid from dbo.ManagedEntity where fullname like "
                        + "'" + managedEntityFullName + "'";
                }

                // Try to connect to DW and avoid sql Transport layer exceptions - more details with sunsingh
                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        DBUtil.ConnectToMOMDW(GetManagementServerName());
                        break;
                    }
                    catch (SqlException)
                    {
                        continue;
                    }
                }

                //execute the query and get the record count
                foreach (string sqlQuery in sqlQueries)
                {
#if DEBUGG
                    ctx.Trc("sqlQuery: " + sqlQuery);
#endif
                    ctx.Trc("sqlQuery: " + sqlQuery);

                    string tmpStr = DBUtil.ExecuteScalarQuery(sqlQuery).ToString();
                    if (tmpStr != null)
                    {
                        ManagedEntityIDs.Add(tmpStr);
#if DEBUGG
                        ctx.Trc("ManagedEntityID: " + tmpStr);
#endif
                    }
                    else
                    {
                        //ctx.Trc("Null value returned from query: " + sqlQuery);
                    }
                }
                //ctx.Alw("After executing queries............!");
                // Check if you have any ManagedEntity IDs
                if (ManagedEntityIDs.Count == 0)
                {
                    throw new VarAbort("ReportUtil.GetManagedEntities :: No ManagedEntity IDs in ArrayList");
                }
                else
                {
                    //ctx.Trc("Number of ManagedEntity IDs: " + ManagedEntityIDs.Count);
                }
                return ManagedEntityIDs;
            }
            catch (SqlException sqle)
            {
                throw new VarAbort("ReportUtil.GetManagedEntities :: SQL Exception" + sqle.Message);
            }
            catch (Exception e)
            {
                throw new VarAbort("ReportUtil.GetManagedEntities :: " + e.Message);
            }
            finally
            {
                // Close MOM DW Connection
                DBUtil.CloseMOMDWConnection();
            }

        }

        /// <summary>
        /// Method to get the Base Managed Enitity IDs
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="nAgents"></param>
        /// <param name="nDBs"></param>
        /// <param name="baseString">string specifying base of inserted managed entities 
        /// (eg. "Microsoft.Windows.Server.2003.Processor:WKSTNN")</param>
        /// <returns>string array of Base Managed Enitity IDs</returns>
        /// <History>
        ///     [a-omkasi] 06-OCT-08    Created
        ///</History>
        static ArrayList GetBaseManagedEntities(
            IContext ctx,
            int nAgents,
            int nDBs,
            string baseString
            )
        {
            ctx.Alw("GetBaseManagedEntityIDs() called.....");

            try
            {
                //string[] ManagedEntityIDs = new string[4];
                // Note: If number of ManagedEntity ID increase beyond four, 
                //the string array length should also be increased.
                ArrayList ManagedEntityIDs = new ArrayList();


                string[] sqlQueries = new string[nAgents * nDBs];
                // Note: If number of Managed Entity ID increase beyond four, 
                //the string array length should also be increased.

                int qCount = 0;

                ArrayList managedEntityFullNames = new ArrayList();
                if(String.IsNullOrEmpty(baseString))
                    baseString = "Microsoft.SQLServer.Database:WKSTNN";
                
                StringBuilder processorString = new StringBuilder(baseString);
                for (int i = 1; i <= nAgents; i++)
                {
                    for (int j = 0; j < nDBs; j++)
                    {
                        //processorString.Replace(processorString.ToString(), baseString);
                        if (processorString.ToString() != "")
                            processorString.Replace(processorString.ToString(), "");
                        processorString.Append(baseString);
                        processorString.Append(i.ToString() + ";INSTANCE1;");
                        //for every other managed entity, append "master" and "model" (databases), alternately
                        if (j % 2 == 0)
                        {
                            processorString.Append("master");
                        }
                        else
                        {
                            processorString.Append("model");
                        }
#if DEBUGG
                        ctx.Trc("DEBUG: processorString: " + processorString);
#endif
                        managedEntityFullNames.Add(processorString.ToString());
                    }
                }

                // Form the queries
                foreach (string managedEntityFullName in managedEntityFullNames)
                {
#if DEBUGG
                    ctx.Trc("qCount: " + qCount + " :: managedEntityFullName: " + managedEntityFullName);
#endif
                    sqlQueries[qCount++] = "Select baseManagedEntityID from BaseManagedEntity Where Fullname like "
                        + "'" + managedEntityFullName + "'";
                }

                // Try to connect to DW and avoid sql Transport layer exceptions - more details with sunsingh
                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        DBUtil.ConnectToMOMDB(GetManagementServerName());
                        break;
                    }
                    catch (SqlException)
                    {
                        continue;
                    }
                }

                //execute the query and get the record count
                foreach (string sqlQuery in sqlQueries)
                {
#if DEBUGG
                    ctx.Trc("sqlQuery: " + sqlQuery);
#endif
                    string tmpStr = DBUtil.ExecuteScalarQuery(sqlQuery).ToString();
                    if (tmpStr != null)
                    {
                        ManagedEntityIDs.Add(tmpStr);
#if DEBUGG
                        ctx.Trc("ManagedEntityID: " + tmpStr);
#endif
                    }
                    else
                    {
                        //ctx.Trc("Null value returned from query: " + sqlQuery);
                    }
                }
                //ctx.Alw("After executing queries............!");
                // Check if you have any ManagedEntity IDs
                if (ManagedEntityIDs.Count == 0)
                {
                    throw new VarAbort("ReportUtil.GetManagedEntities :: No ManagedEntity IDs in ArrayList");
                }
                else
                {
                    //ctx.Trc("Number of ManagedEntity IDs: " + ManagedEntityIDs.Count);
                }
                return ManagedEntityIDs;
            }
            catch (SqlException sqle)
            {
                throw new VarAbort("ReportUtil.GetBaseManagedEntityIDs :: SQL Exception:" + sqle.Message);
            }
            catch (Exception e)
            {
                throw new VarAbort("ReportUtil.GetBaseManagedEntityIDs :: " + e.Message);
            }
            finally
            {
                // Close MOM DB Connection
                DBUtil.CloseMOMDBConnection();
            }
        }

        /// <summary>
        /// Method to get the Health service IDs
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="nAgents"></param>
        /// <param name="nCPUs"></param>
        /// <param name="baseString">string specifying base of health services 
        /// (eg. "WKSTNN")</param>
        /// <returns>string array of health serive Ids</returns>
        ///<exception cref="SqlException"></exception>
        ///<History>
        ///     [a-omkasi] 25-SEP-08    Created
        ///</History>
        static ArrayList GetHealthServices(
            IContext ctx,
            int nAgents,
            int nCPUs,
            string baseString
            )
        {
            //ctx.Alw("GetHealthServiceIDsEx() called.....");

            try
            {
                ArrayList HealthServiceIDs = new ArrayList();
                //HealthServiceIDs.Initialize();
                // Note: If number of HealthService ID increase beyond two, 
                //the string array length should also be increased.

                string[] sqlQueries = new string[nAgents];
                // Note: If number of HealthService ID increase beyond two, 
                //the string array length should also be increased.

                int qCount = 0;

                //ctx.Trc("nAgents: " + nAgents);
                //ctx.Trc("nCPUs: " + nCPUs);

                ArrayList baseManagementEntityNames = new ArrayList();
                if(String.IsNullOrEmpty(baseString))
                    baseString = "WKSTNN";

                StringBuilder hsString = new StringBuilder();
                for (int i = 1; i <= nAgents; i++)
                {
                    //hsString.Replace(hsString.ToString(), baseString);
                    if (hsString.ToString() != "")
                        hsString.Replace(hsString.ToString(), "");
                    hsString.Append(baseString);
                    hsString.Append(i.ToString());
#if DEBUGG
                    ctx.Trc("DEBUG: hsString: " + hsString);
#endif
                    baseManagementEntityNames.Add(hsString.ToString());
                }

                // Connect to MOM DB
                DBUtil.ConnectToMOMDB(GetManagementServerName());

                // Form the queries
                foreach (string baseManagementEntityName in baseManagementEntityNames)
                {
#if DEBUGG
                    ctx.Trc("qCount: " + qCount + " :: baseManagementEntityName: " + baseManagementEntityName);
#endif
                    sqlQueries[qCount++] = "select BaseManagedEntityID from BaseManagedEntity " +
                               " where TopLevelHostEntityID = " +
                               " (select BaseManagedEntityID from BaseManagedEntity where name = '" + baseManagementEntityName + "' )" +
                               " and Fullname like 'Microsoft.SystemCenter.HealthService:" + baseManagementEntityName + "'";
                }

                //execute the query and get the record count
                foreach (string sqlQuery in sqlQueries)
                {
#if DEBUGG
                    ctx.Trc("sqlQuery: " + sqlQuery);
#endif
                    string tmpStr = DBUtil.ExecuteScalarQuery(sqlQuery).ToString();
                    if (tmpStr != null)
                    {
                        HealthServiceIDs.Add(tmpStr);
#if DEBUGG
                        ctx.Trc("HealthServiceID: " + tmpStr);
#endif
                    }
                    else
                    {
                        //ctx.Trc("Null value returned from query: " + sqlQuery);
                    }
                }

                // Check if you have any Health Seriver IDs
                if (HealthServiceIDs.Count == 0)
                {
                    throw new VarAbort("ReportUtil.GetHealthServiceIDs :: No Health Service IDs in ArrayList");
                }
                else
                {
                    //ctx.Trc("Number of HealthService IDs: " + HealthServiceIDs.Count);
                }
                return HealthServiceIDs;
            }
            catch (SqlException sqle)
            {
                throw new VarAbort("ReportUtil.GetHealthServiceIDs :: SQL Exception:" + sqle.Message);
            }
            catch (Exception e)
            {
                throw new VarAbort("ReportUtil.GetHealthServiceIDs :: " + e.Message);
            }
            finally
            {
                // Close MOM DB Connection
                DBUtil.CloseMOMDBConnection();
            }
        }

        /// <summary>
        /// Method to get m_DBName value
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns>name of DW database as string</returns>
        ///<History>
        ///     [starrpar] 28-APR-10       Created
        ///</History>
        public static string GetDWName(IContext ctx)
        {
            SetUrlDBName();
            return m_DBName;
        }

        /// <summary>
        /// Method to set m_DBName value
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns>name of DW database as string</returns>
        ///<exception cref="SqlException"></exception>
        ///<History>
        ///     [a-omkasi] 25-SEP-08    Created
        ///     [starrpar] 11-DEC-09    Added into Utilities
        ///</History>
        public static void SetUrlDBName()
        {

            string sqlQuery = string.Empty;
            string baseManagedTypeId = null;

            try
            {
                /*MomDiscovery testTopology = new MomDiscovery(ctx);
                MachineInfo Machine = (MachineInfo)testTopology.ManagementServers[0];
                managementServerName = Machine.MachineName.ToString();
                */

                //Connect to MOM DB
                DBUtil.ConnectToMOMDB(GetManagementServerName());

                //change required for DB schema changes in improvement 141214
                //sqlQuery = "select BaseManagedTypeId from OperationsManager.dbo.BaseManagedEntity where FullName like 'Microsoft.SystemCenter.DataWarehouse'";
                sqlQuery = "select MTP.ColumnName from dbo.ManagedTypeProperty MTP,";
                sqlQuery = sqlQuery + "\n ManagedType MT where MT.ManagedTypeId = MTP.ManagedTypeId";
                sqlQuery = sqlQuery + "\n AND MTP.ManagedTypePropertyName = 'MainDatabaseName'";
                sqlQuery = sqlQuery + "\n AND MT.ManagedTypeTableName = 'MT_Microsoft$SystemCenter$Datawarehouse'";

                //execute the query and get the record count
                baseManagedTypeId = DBUtil.ExecuteScalarQuery(sqlQuery).ToString();

                //replace all '-'s with '_'s
                baseManagedTypeId = baseManagedTypeId.Replace('-', '_');

                //change required for DB schema changes in improvement 141214
                //sqlQuery = "select MainDatabaseName_" + baseManagedTypeId.ToString() + " from OperationsManager.dbo.MT_DataWarehouse"; 
                sqlQuery = "select " + baseManagedTypeId.ToString() + " from " + DBUtil.MOMDBName + ".dbo.MT_Microsoft$SystemCenter$DataWarehouse";

                m_DBName = DBUtil.ExecuteScalarQuery(sqlQuery).ToString();
            }
            catch (Exception e)
            {
                throw new VarAbort("Getting URL DB Name failed. Query  : "
                            + sqlQuery, e);
            }
            finally
            {
                //close the DB connection
                DBUtil.CloseMOMDBConnection();
            }
        }

        /// <summary>
        /// Method to get m_DBInstanceName value
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns>name of DW server\instance as string</returns>
        ///<History>
        ///     [starrpar] 28-APR-10       Created
        ///</History>
        public static string GetDWInstanceName(IContext ctx)
        {
            SetServerName();
            return m_DBInstanceName;
        }

        /// <summary>
        /// Method to set m_DBInstanceName value
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns>name of DW server\instance as string</returns>
        ///<exception cref="SqlException"></exception>
        ///<History>
        ///     [a-omkasi] 25-SEP-08    Created
        ///     [starrpar] 11-DEC-09    Added into Utilities
        ///</History>
        public static void SetServerName()
        {
            string sqlQuery = string.Empty;
            string baseManagedTypeId = null;

            try
            {
                /*MomDiscovery testTopology = new MomDiscovery(ctx);
                MachineInfo Machine = (MachineInfo)testTopology.ManagementServers[0];
                managementServerName = Machine.MachineName.ToString();
                */
                //Connect to MOM DB
                DBUtil.ConnectToMOMDB(GetManagementServerName());

                //change required for DB schema changes in improvement 141214
                //sqlQuery = "select BaseManagedTypeId from OperationsManager.dbo.BaseManagedEntity where FullName like 'Microsoft.SystemCenter.DataWarehouse'";
                sqlQuery = "select MTP.ColumnName from dbo.ManagedTypeProperty MTP,";
                sqlQuery = sqlQuery + "\n ManagedType MT where MT.ManagedTypeId = MTP.ManagedTypeId";
                sqlQuery = sqlQuery + "\n AND MTP.ManagedTypePropertyName = 'MainDatabaseServerName'";
                sqlQuery = sqlQuery + "\n AND MT.ManagedTypeTableName = 'MT_Microsoft$SystemCenter$Datawarehouse'";

                //execute the query and get the record count
                baseManagedTypeId = DBUtil.ExecuteScalarQuery(sqlQuery).ToString();

                //replace all '-'s with '_'s
                baseManagedTypeId = baseManagedTypeId.Replace('-', '_');

                //change required for DB schema changes in improvement 141214
                //sqlQuery = "select MainDatabaseServerName_" + baseManagedTypeId.ToString() + " from OperationsManager.dbo.MT_DataWarehouse";
                sqlQuery = "select " + baseManagedTypeId.ToString() + " from " + DBUtil.MOMDBName + ".dbo.MT_Microsoft$SystemCenter$DataWarehouse";

                m_DBInstanceName = DBUtil.ExecuteScalarQuery(sqlQuery).ToString();
                //m_MOMDBInstanceName = momTstUtil.GetDataBaseServer(machineName);
            }
            catch (Exception e)
            {
                throw new VarAbort("Getting server Name failed. Query  : "
                            + sqlQuery, e);
            }
            finally
            {
                //close the DB connection
                DBUtil.CloseMOMDBConnection();
            }
        }

        /// <summary>
        /// Method to return Management Server Name from the Topology
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        ///<exception cref="SqlException"></exception>
        ///<History>
        ///     [a-omkasi] 25-SEP-08    Created
        ///     [starrpar] 11-DEC-09    Added into Utilities
        ///</History>
        public static string GetManagementServerName()
        {
            try
            {
                if (m_ManagementServerName == String.Empty)
                {
                    MomDiscovery testTopology =
                        TopologyHelper.TestTopology;
                    MachineInfo Machine =
                        (MachineInfo)testTopology.ManagementServers[0];
                    m_ManagementServerName = Machine.MachineName.ToString();
                }
                return m_ManagementServerName;
            }
            catch (Exception e)
            {
                throw new Exception("Utilities.GetManagementServerName :: " + e.Message);
            }
        }

        /// <summary>
        /// Method to check if an object passed is a valid Datetime.
        /// </summary>
        /// <param name="Expression">An object containing the dateTime</param>
        /// <returns>bool indicating if the object passed is a valid datatime</returns>
        /// <History>
        ///     [a-omkasi] 06-OCT-08    Created
        ///</History>
        public static bool IsDateTime(object Expression)
        {
            DateTime dt = new DateTime(1, 1, 1);
            try
            {
                dt = DateTime.Parse(Expression.ToString());
                return true;
            }

            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// Given a datatime value, it return the same datetime in string format acceptable by WAMLGT
        /// </summary>
        /// <param name="time"></param>
        /// <returns>string formatted datatime value acceptable by WAMLGT</returns>
        /// <History>
        ///     [a-omkasi] 28-SEP-08    Created
        ///</History>
        public static string FormatDateTime(DateTime time)
        {
            if (!IsDateTime((object)time))
                throw new Exception("Null passed in place of a datetime value");

            return time.ToString("yyyy-MM-dd" + " " + "HH:mm:ss.fff");
        }

        /// <summary>
        /// Method to get the Arguments to be passed to WAMLGT for (Perf) data generation
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="wamlgtFileName"></param>
        /// <param name="loadStateChangeFileName"></param>
        /// <param name="dataItemTimeStamp"></param>
        /// <param name="sourceHealthServiceID"></param>
        /// <param name="managedEntityID"></param>
        /// <param name="eventOriginID"></param>
        /// <param name="monitorID"></param>
        /// <param name="newHealthState"></param>
        /// <param name="oldHealthState"></param>
        /// <param name="timeChanged"></param>
        /// <History>
        ///     [starrpar] 11-DEC-09    Added to Utilities
        ///</History>
        public static bool CallWAMLGTForStateChangeData(
            IContext ctx,
            string wamlgtFileName,
            string loadStateChangeFileName,
            DateTime dataItemTimeStamp,
            string sourceHealthServiceID,
            string managedEntityID,
            string eventOriginID,
            string monitorID,
            string newHealthState,
            string oldHealthState,
            DateTime timeChanged
            )
        {
            if (wamlgtFileName == null
                || loadStateChangeFileName == null
                || !IsDateTime((object)dataItemTimeStamp)
                || sourceHealthServiceID == null
                || managedEntityID == null
                || eventOriginID == null
                || monitorID == null
                || newHealthState == null
                || oldHealthState == null
                || !IsDateTime((object)timeChanged))
            {
                return false;
            }

            string timeStamp = FormatDateTime(dataItemTimeStamp);
            string timeChnged = FormatDateTime(timeChanged);

            Thread.Sleep(5000);
            ctx.Alw("Started to generate State change Data");
            ctx.Alw(wamlgtFileName + "  " + loadStateChangeFileName + " stateChange.out DataitemTimestamp:" + timeStamp + " HealthServiceId:" + sourceHealthServiceID + " ManagedEntityId:" + managedEntityID + " EventOriginId:" + eventOriginID + " MonitorId:" + monitorID + " NewHealthState:" + newHealthState + " OldHealthState:" + oldHealthState + " TimeChanged:" + timeChnged + " StateDataCount:1 StateChangeDataitemTarget:ModuleHost.DW.StateChange");
            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            myProcess.StartInfo.FileName = wamlgtFileName;
            myProcess.StartInfo.Arguments = loadStateChangeFileName + " stateChange.out DataitemTimestamp:" + timeStamp + " HealthServiceId:" + sourceHealthServiceID + " ManagedEntityId:" + managedEntityID + " EventOriginId:" + eventOriginID + " MonitorId:" + monitorID + " NewHealthState:" + newHealthState + " OldHealthState:" + oldHealthState + " TimeChanged:" + timeChnged + " StateDataCount:1 StateChangeDataitemTarget:ModuleHost.DW.StateChange";
            ctx.Alw("Calling wamlgt.........................................");
            myProcess.Start();
            for (int i = 0; i <= 30; i++)
            {
                if (myProcess.HasExited)
                {
                    ctx.Trc("State Change Data generation complete");
                    break;
                }
                ctx.Alw("Data generation has not completed yet. Will check again in 10 seconds...");
                Thread.Sleep(10000);

            }
            //return true if wamlgt has exited. Else return false.
            return (myProcess.HasExited) ? true : false;
        }

        /// <summary>
        /// Method to get the rule ID
        /// </summary>
        /// <param name="typeString">string specifying rule type  
        /// (eg. "Microsoft.Windows.Server.2003.Processor")</param>
        /// <param name="entityString">string specifying rule name 
        /// (eg. "Microsoft.Windows.Server.2003.Processor.PercentProcessorTime.Collection")</param>
        /// <param name="ctx"></param>
        /// <returns>string with ruleID in it</returns>
        ///<exception cref="SqlException"></exception>
        ///<History>
        ///     [a-omkasi] 25-SEP-08    Created
        ///</History>
        static string GetRuleID(string typeString, string entityString, IContext ctx)
        {
            ctx.Alw("GetRuleID() called...");

            try
            {
                string sqlQuery = null;
                string ruleID = null;
                // Connect to MOM DB

                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        DBUtil.ConnectToMOMDB(GetManagementServerName());
                        break;
                    }
                    catch (SqlException)
                    {
                        continue;
                    }
                }

                if (String.IsNullOrEmpty(typeString))
                    typeString = "Microsoft.Windows.Server.2003.Processor";
                if (String.IsNullOrEmpty(entityString))
                    entityString = "Microsoft.Windows.Server.2003.Processor.PercentProcessorTime.Collection";

                // Get RuleID
                sqlQuery = "SELECT id from ruleview WHERE TargetMonitoringClassId = "
                + " (SELECT ManagedTypeID from ManagedType WHERE TypeName ='" + typeString + "')"
                + " and Name = '" + entityString + "'";

                // Execute query and get the ruleID
                ruleID = DBUtil.ExecuteScalarQuery(sqlQuery).ToString();
                return ruleID;
            }
            catch (SqlException sqle)
            {
                throw new VarAbort("ReportUtil.GetRuleID :: SQL Exception:" + sqle.Message);
            }
            catch (Exception e)
            {
                throw new VarAbort("ReportUtil.GetRuleID :: " + e.Message);
            }
            finally
            {
                // Close MOM DB Connection
                DBUtil.CloseMOMDBConnection();
            }

        }

        /// <summary>
        /// Method to get the monitor ID
        /// </summary>
        /// <param name="monitorName">string specifying monitor name 
        /// (eg. "System.Health.AvailabilityState")</param>        /// <History>
        /// <param name="ctx"></param>
        /// <returns>A string of monitor ID</returns>
        /// <History>
        ///     [a-omkasi] 06-OCT-08    Created
        ///</History>
        static string GetMonitorID(string monitorName, IContext ctx)
        {
            ctx.Alw("GetMonitorID() called...");

            try
            {
                string sqlQuery = null;
                string monitorID = null;
                // Connect to MOM DW
                /* if (DBUtil.SqlConnection.State != ConnectionState.Open)
                 {
                     DBUtil.ConnectToMOMDW(ReportUtil.MOMDBInstanceName, MOMDBName);
                 }
                 */
                DBUtil.ConnectToMOMDW(GetManagementServerName());

                if (String.IsNullOrEmpty(monitorName))
                    monitorName = "System.Health.AvailabilityState";
                // Get MonitorID
                sqlQuery = "select MonitorGuid from monitor where MonitorSystemName = '" + monitorName + "'";

                // Execute query and get the ruleID
                monitorID = DBUtil.ExecuteScalarQuery(sqlQuery).ToString();
                return monitorID;
            }
            catch (SqlException sqle)
            {
                throw new VarAbort("ReportUtil.GetRuleID :: SQL Exception:" + sqle.Message);
            }
            catch (Exception e)
            {
                throw new VarAbort("ReportUtil.GetRuleID :: " + e.Message);
            }
            finally
            {
                // Close MOM DW Connection
                DBUtil.CloseMOMDWConnection();
            }
        }

        /// <summary>
        /// Method to get the Base Managed Enitity IDs
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns>string array of Base Managed Enitity IDs</returns>
        /// <History>
        ///     [a-omkasi] 06-OCT-08    Created
        ///</History>
        static string[] GetBaseManagedEntities(IContext ctx)
        {
            ctx.Alw("GetBaseManagedEntityIDs() called.....");

            try
            {
                string[] BaseManagedEntityIDs = new string[4];
                BaseManagedEntityIDs.Initialize();
                // Note: If number of HealthService ID increase beyond two, 
                //the string array length should also be increased.

                int bmeCount = 0;

                string[] sqlQueries = new string[4];
                // Note: If number of HealthService ID increase beyond two, 
                //the string array length should also be increased.

                int qCount = 0;

                string[] baseManagedEntities = new string[4];
                baseManagedEntities[0] = "Microsoft.SQLServer.Database:WKSTNN1;INSTANCE1;master";
                baseManagedEntities[1] = "Microsoft.SQLServer.Database:WKSTNN1;INSTANCE1;model";
                baseManagedEntities[2] = "Microsoft.SQLServer.Database:WKSTNN2;INSTANCE1;master";
                baseManagedEntities[3] = "Microsoft.SQLServer.Database:WKSTNN2;INSTANCE1;model";

                // Connect to MOM DB
                DBUtil.ConnectToMOMDB(GetManagementServerName());

                // Form the queries
                foreach (string baseManagedEntity in baseManagedEntities)
                {
                    sqlQueries[qCount++] = "Select baseManagedEntityID from BaseManagedEntity Where Fullname like "
                    + "'" + baseManagedEntity + "'";
                }

                //execute the query and get the record count
                foreach (string sqlQuery in sqlQueries)
                {
                    BaseManagedEntityIDs[bmeCount++] = DBUtil.ExecuteScalarQuery(sqlQuery).ToString();
                }

                // Check if you have any Health Seriver IDs
                if (BaseManagedEntityIDs.Length == 0)
                {
                    throw new VarAbort("ReportUtil.GetBaseManagedEntityIDs :: Cannot get the Health Service IDs");
                }
                return BaseManagedEntityIDs;
            }
            catch (SqlException sqle)
            {
                throw new VarAbort("ReportUtil.GetBaseManagedEntityIDs :: SQL Exception:" + sqle.Message);
            }
            catch (Exception e)
            {
                throw new VarAbort("ReportUtil.GetBaseManagedEntityIDs :: " + e.Message);
            }
            finally
            {
                // Close MOM DB Connection
                DBUtil.CloseMOMDBConnection();
            }
        }

        /// <summary>
        /// Method to execute a Stored Procedure in DW
        /// </summary>
        /// <param name="filePath">string</param>
        /// <param name="ctx">IContext</param>
        /// <History>
        ///     [starrpar] 04-APR-10    Created
        ///</History>
        public static void InstallStoredProcedure(
            string filePath,
            IContext ctx)
        {
            //set DW name and SQL instance for use beyond this point
            if (m_DBInstanceName == null)
                SetServerName();
            if (m_DBName == null)
                SetUrlDBName();

            StreamReader queryObjectReader = new StreamReader(filePath);
            string sqlQuery = queryObjectReader.ReadToEnd();

            StringBuilder strConnection = new StringBuilder("Initial Catalog=");
            strConnection.Append(m_DBName);
            strConnection.Append("; Data Source=");
            strConnection.Append(m_DBInstanceName);
            strConnection.Append(";Integrated Security=SSPI; Connect Timeout=");
            strConnection.Append(m_SQLConnectionTimeout);

            m_SQLDWConnection = new SqlConnection(strConnection.ToString());
            m_SQLDWConnection.Open();

            SqlCommand sqlCmd = new SqlCommand(sqlQuery, m_SQLDWConnection);
            sqlCmd.CommandType = CommandType.Text;

            try
            {
                sqlCmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                //log exception, as expected to simply indicate that stored proc is already present)
                LogMessage("Stored Proc already present? " + e.Message);
            }
        }

        /// <summary>
        /// Method to execute a Stored Procedure in DW
        /// </summary>
        /// <param name="fileName">string</param>
        /// <param name="sqlCmd">SqlCommand</param>
        /// <param name="ctx">IContext</param>
        /// <History>
        ///     [starrpar] 04-APR-10    Created
        ///</History>
        public static void ExecuteStoredProcedureWithParametersAlreadySet(
            string fileName,
            SqlCommand sqlCmd,
            IContext ctx)
        {
            //set DW name and SQL instance for use beyond this point
            if (m_DBInstanceName == null)
                SetServerName();
            if (m_DBName == null)
                SetUrlDBName();

            StringBuilder strConnection = new StringBuilder("Initial Catalog=");
            strConnection.Append(m_DBName);
            strConnection.Append("; Data Source=");
            strConnection.Append(m_DBInstanceName);
            strConnection.Append(";Integrated Security=SSPI; Connect Timeout=");
            strConnection.Append(m_SQLConnectionTimeout);

            m_SQLDWConnection = new SqlConnection(strConnection.ToString());
            m_SQLDWConnection.Open();

            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = fileName;
            sqlCmd.Connection = m_SQLDWConnection;

            sqlCmd.ExecuteNonQuery();
        }

        #endregion

        #region IDataObject utilities

        /// <summary>
        /// Receive a collection of heirarchical IDataObjects
        /// Calls UnwindDataObject for each IDataObject
        /// Hands back a flat dictionary containing and indexed list of name, type and object (of that type, for casting)
        /// </summary>
        public static SortedDictionary<string, KeyValuePair<Type, object>> UnwindIDataObjectCollection(
            IEnumerable<IDataObject> dataObjCollection, List<String> titles)
        {
            SortedDictionary<string, KeyValuePair<Type, object>> returnCollection =
                new SortedDictionary<string, KeyValuePair<Type, object>>();
            SortedDictionary<string, KeyValuePair<Type, object>> tmpObjColl =
                new SortedDictionary<string, KeyValuePair<Type, object>>();

            int i = 0;
            foreach (IDataObject ido in dataObjCollection)
            {
                //collect the contents for the current IDataObject
                tmpObjColl = UnwindIDataObject(ido, titles);

                //add that IDataObject contents to the overall collection dictionary
                if (tmpObjColl.Count > 0)
                {
                    foreach (KeyValuePair<string, KeyValuePair<Type, object>> entry in tmpObjColl)
                    {
                        returnCollection.Add(i + "." + entry.Key, entry.Value);
                    }
                }
                i++;
            }
            return returnCollection;
        }

        /// <summary>
        /// Receive a collection of heirarchical IDataObjects
        /// Calls UnwindDataObject for each IDataObject
        /// Hands back a flat dictionary containing and indexed list of name, type and object (of that type, for casting)
        /// </summary>
        public static SortedDictionary<string, KeyValuePair<Type, object>> UnwindIDataObjectCollection(
            ICollection<IDataObject> dataObjCollection, List<String> titles)
        {
            SortedDictionary<string, KeyValuePair<Type, object>> returnCollection =
                new SortedDictionary<string, KeyValuePair<Type, object>>();
            SortedDictionary<string, KeyValuePair<Type, object>> tmpObjColl =
                new SortedDictionary<string, KeyValuePair<Type, object>>();

            int i = 0;
            foreach (IDataObject ido in dataObjCollection)
            {
                //collect the contents for the current IDataObject
                tmpObjColl = UnwindIDataObject(ido, titles);

                //add that IDataObject contents to the overall collection dictionary
                if (tmpObjColl.Count > 0)
                {
                    foreach (KeyValuePair<string, KeyValuePair<Type, object>> entry in tmpObjColl)
                    {
                        returnCollection.Add(i + "." + entry.Key, entry.Value);
                    }
                }
                i++;
            }
            return returnCollection;
        }

        /// <summary>
        /// Receive a heirarchical IDataObject
        /// Hand back a flat dictionary containing name, type and object (of that type, for casting)
        /// </summary>
        public static SortedDictionary<string, KeyValuePair<Type, object>> UnwindIDataObject(
            IDataObject dataObj, List<String> titles)
        {
            List<string> tmpTitles = new List<string>();
            SortedDictionary<string, KeyValuePair<Type, object>> retVals =
                new SortedDictionary<string, KeyValuePair<Type, object>>();
            SortedDictionary<string, KeyValuePair<Type, object>> tmpVals =
                new SortedDictionary<string, KeyValuePair<Type, object>>();

            if (dataObj != null)
            {
                //pack titles into a temporary collection so they can be deleted
                //as the IDataObject is gone through (so the original titles list
                //can be retained for use with the next IDataObject to parse)
                foreach (string title in titles)
                {
                    tmpTitles.Add(title);
                }

                while (tmpTitles.Count > 0 && dataObj[tmpTitles[0]] != null)
                {
                    string tmpTitle = tmpTitles[0];
                    //use recursion for any embedded IDataObjectCollections
                    if (dataObj[tmpTitle].GetType().ToString().Contains("DataObjectCollection"))
                    {
                        tmpTitles.Remove(tmpTitle);

                        int i = 0;
                        foreach (IDataObject ido in (ICollection<IDataObject>)dataObj[tmpTitle])
                        {
                            tmpVals = UnwindIDataObject(ido, tmpTitles);

                            if (tmpVals.Count > 0)
                            {
                                foreach (KeyValuePair<string, KeyValuePair<Type, object>> entry in tmpVals)
                                {
                                    retVals.Add(i + "." + entry.Key, entry.Value);
                                }
                            }
                            i++;
                        }
                    }
                    else
                    {
                        KeyValuePair<Type, object> objWithType = new 
                            KeyValuePair<Type, object>(dataObj[tmpTitle].GetType(),
                            (object)dataObj[tmpTitle]);

                        retVals.Add(tmpTitle, objWithType);
                        tmpTitles.Remove(tmpTitle);
                    }
                }
            }
            return retVals;
        }

        /// <summary>
        /// Receive a heirarchical IDataObjectCollection
        /// Hand back a flat dictionary containing name/title, type and object (of that type)
        /// <param name="dataObjListing">SortedDictionary<string, KeyValuePair<Type, object>></param>
        /// </summary>
        public static void OutputDataObjectContents(SortedDictionary<string, KeyValuePair<Type, object>> dataObjListing)
        {
            string currentMethodName = string.Empty;

            try
            {
                currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                Utilities.LogMessage(currentMethodName + "_Started...");

                int numRecords = dataObjListing.Count;

                SortedDictionary<string, KeyValuePair<Type, object>>.KeyCollection keyColl = dataObjListing.Keys;

                foreach (string key in keyColl)
                {
                    KeyValuePair<Type, object> tmpDict = dataObjListing[key];

                    Utilities.LogMessage(currentMethodName + "_" + key + " : " +
                        dataObjListing[key].Key.ToString() + ": " + dataObjListing[key].Value.ToString());
                    //Console.WriteLine(key + " : " + dataObjListing[key].Key.ToString() + ": " +
                    //    dataObjListing[key].Value.ToString());

                    //Dictionary<Type, object>.KeyCollection tmpKeyColl = tmpDict.Keys;

                    //foreach (Type t in tmpKeyColl)
                    //{
                    //    Utilities.LogMessage(currentMethodName + "_" + key + " : " +
                    //        t.ToString() + ": " + tmpDict[t].ToString());
                    //    //Console.WriteLine(key + " : " + t.ToString() + ": " + tmpDict[t].ToString());
                    //}
                }
            }
            #region Catch/Finally
            catch (VarFail)
            {
                throw;
            }
            catch (VarAbort)
            {
                throw;
            }
            catch (Exception e)
            {
                Utilities.TakeScreenshot(currentMethodName + "_Exception");
                throw new VarAbort(currentMethodName + "_Failed to get StatusBar StatusMessage", e);
            }
            finally
            {
            }
            #endregion
        }

        /// <summary>
        /// Compares SortedDictionary(string KeyValuePair(Type, object)) lists from
        /// product data providers and test queries to generate the same results
        /// (either by directly calling the Stored Procs or calling through the
        /// Data Warehouse SDK, as the providers do)
        /// </summary>
        /// <param name="productDataObjectsList">SortedDictionary(string, KeyValuePair(Type, object))</param>
        /// <param name="compareDataObjectsList">SortedDictionary(string, KeyValuePair(Type, object))</param>
        /// <returns>bool</returns>
        public static bool CompareDataObjectResults(SortedDictionary<string, KeyValuePair<Type, object>> productDataObjectsList,
            SortedDictionary<string, KeyValuePair<Type, object>> compareDataObjectsList)
        {
            bool retVal = true;

            if (productDataObjectsList.Keys.Count != compareDataObjectsList.Keys.Count)
            {
                throw new VarAbort("Collections passed for comparison are of different dimensions, " +
                    "first dataset count: " + productDataObjectsList.Keys.Count +
                    " :: second dataset count: " + compareDataObjectsList.Keys.Count);
            }

            //verify keys in each Dictionary object are contained in the other
            foreach (string key in productDataObjectsList.Keys)
            {
                if (!compareDataObjectsList.ContainsKey(key))
                {
                    throw new VarAbort("key contained in productDataObjectsList: " + key +
                        " not contained in compareDataObjectsList");
                }
            }

            foreach (string key in compareDataObjectsList.Keys)
            {
                if (!productDataObjectsList.ContainsKey(key))
                {
                    throw new VarAbort("key contained in compareDataObjectsList: " + key +
                        " not contained in productDataObjectsList");
                }
            }
            
            int i = 0;
            foreach (string key in productDataObjectsList.Keys)
            {
                KeyValuePair<Type, object> tmpProdDict = productDataObjectsList[key];
                KeyValuePair<Type, object> tmpCompDict = compareDataObjectsList[key];

                if (!tmpProdDict.Value.Equals(tmpCompDict.Value))
                {
                    LogMessage(" *********************************");
                    LogMessage(i + " NON-MATCH: " + tmpProdDict.Value.ToString() +
                        " != " + tmpCompDict.Value.ToString());
                    LogMessage(" *********************************");

                    retVal = false;
                    break;
                }
                else
                {
                    LogMessage(i + " match: " + tmpProdDict.Value.ToString() +
                        " == " + tmpCompDict.Value.ToString());
                }
                i++;

                if (retVal != true)
                {
                    break;
                }
            }
            if (retVal)
            {
                LogMessage("Comparison passed: 100% match");
            }
            return retVal;
        }

                /// <summary>
        /// Compares SortedDictionary(string KeyValuePair(Type, object)) lists from
        /// product data providers and test queries to generate the same results
        /// (either by directly calling the Stored Procs or calling through the
        /// Data Warehouse SDK, as the providers do)
        /// </summary>
        /// <param name="setA">ResultSet</param>
        /// <param name="setB">ResultSet</param>
        /// <param name="setAColumns">List(string)</param>
        /// <param name="setBColumns">List(string)</param>
        /// <returns>bool</returns>
        public static bool CompareResultSetResults(ResultSet setA, ResultSet setB,
            List<string> setAColumns, List<string> setBColumns)
        {            
            SortedDictionary<string, List<object>> setA_Results = 
                new SortedDictionary<string, List<object>>();
            SortedDictionary<string, List<object>> setB_Results = 
                new SortedDictionary<string, List<object>>();

            ReadOnlyCollection<Result> setA_ROCollection = setA.Results;
            ReadOnlyCollection<Result> setB_ROCollection = setB.Results;

            //go through every result row and if title matches, capture value
            foreach (Result result in setA_ROCollection)
            {
                Dictionary<string, object> setA_Contents = new Dictionary<string, object>();

                foreach (string title in setAColumns)
                {
                    setA_Contents.Add(title, setA.GetColumnValue(title, result));
                }
                foreach (KeyValuePair<string, object> entry in setA_Contents)
                {
                    if (setA_Results.ContainsKey(entry.Key))
                    {
                        setA_Results[entry.Key].Add(entry.Value);
                    }
                    else
                    {
                        List<object> tmpList = new List<object>();
                        tmpList.Add(entry.Value);
                        setA_Results.Add(entry.Key, tmpList);
                    }
                }
            }
            foreach (Result result in setB_ROCollection)
            {
                Dictionary<string, object> setB_Contents = new Dictionary<string, object>();

                foreach (string title in setBColumns)
                {
                    setB_Contents.Add(title, setB.GetColumnValue(title, result));
                }
                foreach (KeyValuePair<string, object> entry in setB_Contents)
                {
                    if (setB_Results.ContainsKey(entry.Key))
                    {
                        setB_Results[entry.Key].Add(entry.Value);
                    }
                    else
                    {
                        List<object> tmpList = new List<object>();
                        tmpList.Add(entry.Value);
                        setB_Results.Add(entry.Key, tmpList);
                    }
                }
            }

            //compare Dictionary objects
            bool mismatch = false;
            string mismatchValueA = String.Empty;
            string mismatchValueB = String.Empty;
            string mismatchTitle = String.Empty;
            int mismatchIndex = 0;
            foreach (string title in setAColumns)
            {
                List<object> setA_Values = new List<object>();
                List<object> setB_Values = new List<object>();

                setA_Results[title].Sort();
                setB_Results[title].Sort();

                setA_Values = setA_Results[title];
                setB_Values = setB_Results[title];

                int j = 0;
                for (int i = 0; i < setA_Values.Count; i++)
                {
                    if (!setA_Values[i].Equals(setB_Values[i]))
                    {
                        mismatch = true;
                        mismatchValueA = setA_Values[i].ToString();
                        mismatchValueB = setB_Values[i].ToString();
                        mismatchTitle = title;
                        mismatchIndex = i;
                        LogMessage(j + " mismatch: " + setA_Values[i] + " = " + setB_Values[i]);
                    }
                    else
                    {
                        //LogMessage(j + " match: " + setA_Values[i] + " = " + setB_Values[i]);
                    }
                    j++;
                }
                if (j > 0)
                {
                    LogMessage("Title: " + title + ", SLO results matched for " + j + " values");
                }
                else
                {
                    throw new VarFail("Title: " + title + " had no SLO results; please investigate");
                }
            }
            if (mismatch)
            {
                throw new VarAbort("Error - ResultSet values for \'" + mismatchTitle + "[" + mismatchIndex + "]\' don't match.  setA value: " +
                    mismatchValueA + ", setB value: " + mismatchValueB);
            }
            return true;
        }

        #endregion

        #region DW SDK access methods

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method for calling Reporting (DW) SDK client API using parameters provided in variation in varmap
        /// </summary>
        /// <param name="StoredProc">string</param>
        /// <param name="Params">string</param>
        /// <param name="FilterCriteria">string</param>
        /// <param name="TimeOut">string</param>
        /// <param name="AggregationMeans">string</param>
        /// <param name="TimeRange">string</param>
        /// <param name="PerfDataInsertion">string</param>
        /// <param name="ExpectedOutcome">string</param>
        /// <param name="Resource">string</param>
        /// <param name="ResourceAccess">string</param>
        /// <param name="ScaleOut">string</param>
        /// <param name="CurrentTime">DateTime</param>
        /// <param name="context">IContext</param>
        /// <returns>Microsoft.EnterpriseManagement.Common.ResultSet</returns>
        /// <History>
        ///     [starrpar] 23-OCT-09    Created
        ///</History>
        /// ------------------------------------------------------------------
        public static Microsoft.EnterpriseManagement.Common.ResultSet CallGetDataWarehouseDataMethod(
            string StoredProc,
            string Params,
            string FilterCriteria,
            string TimeOut,
            string AggregationMeans,
            string TimeRange,
            string PerfDataInsertion,
            string ExpectedOutcome,
            string Resource,
            string ResourceAccess,
            string ScaleOut,
            DateTime CurrentTime,
            IContext context
            )
        {
            string currentMethodName = String.Empty;

            ResultSet resultSet = null;
            try
            {
                currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                #region Design approach
                //Design approach: Fully data driven - get all information from variation (varmap)
                //get calling role; call API method as that role  -- not yet implemented -- (will by trying a different approach) 
                //use specified stored procedure (1 of 3 listed)
                //along with a corresponding set of parameters

                //...as an alternative, could create an extensive listing of valid SPs from which to choose at random

                //make API call with specified params
                //run same stored procedure directly using specified params
                //compare results of direct stored proc call against data returned by API call
                #endregion

                #region Set API input and SP parameter set values

                SetParams(StoredProc, FilterCriteria, AggregationMeans,
                    TimeRange, PerfDataInsertion);

                SetTimeOut(TimeOut);

                string xmlInput = SetXmlInputValue(context);

                StoredProcedureParameterCollection paramSet = SetParameterValues(Params, xmlInput, context);
                Utilities.LogMessage(currentMethodName + " :: Stored Proc input params; number of params: " +
                    paramSet.Count);

                string sloGuid = String.Empty;
                foreach (StoredProcedureParameter str in paramSet)
                {
                    Utilities.LogMessage(currentMethodName + " :: \"" + str.ParamName + "\", \"" +
                        str.ParamValue.ToString() + "\"");
                    if (str.ParamName.Equals("ServiceLevelObjectiveGuid"))
                        sloGuid = (str.ParamValue).ToString();

                }

                #endregion

                #region Call GetDataWarehouseData method

                //this approach has been obsoleted in lieu of using Reporting.GetDataWarehouse()
                //but I still need to find where that method is created and how to get a Reporting object first
                ManagementGroup mg = Utilities.ConnectToManagementServer();
                DataWarehouse dw = mg.Reporting.GetDataWarehouse();

                //Stopwatch watch = new Stopwatch();
                Dictionary<string, long> elapsedTimes = new Dictionary<string, long>();
                resultSet = CallGetDWData(dw, ScaleOut, paramSet, ref elapsedTimes);

                int numTimes = elapsedTimes.Count;
                Dictionary<string, long>.KeyCollection keyColl = elapsedTimes.Keys;

                foreach (string key in keyColl)
                {
                    Utilities.LogMessage(currentMethodName + " :: Via GetDataWarehouseData(), " +
                        "the stored procedure: " + key);
                    Utilities.LogMessage(currentMethodName + " :: ... took " + elapsedTimes[key].ToString() + " milliseconds to execute");
                }
                Utilities.LogMessage("*********************************************************************************************************************");

                #endregion

                #region Review results

                if (resultSet != null)
                {
                    System.Collections.ObjectModel.ReadOnlyCollection<Microsoft.EnterpriseManagement.
                        Common.ColumnDefinition> columnDefinitionReadOnlyCollection = resultSet.ColumnDefinitions;
                    int colDefCount = columnDefinitionReadOnlyCollection.Count;

                    Hashtable columnNameType = new Hashtable();
                    ArrayList colNames = new ArrayList();
#if DEBUGG
                    Utilities.LogMessage("Columns returned in ColumnDefinition object");
#endif
                    foreach (Microsoft.EnterpriseManagement.Common.ColumnDefinition colDef in
                        columnDefinitionReadOnlyCollection)
                    {
#if DEBUGG
                        Utilities.LogMessage("column name / type: " + colDef.ColumnName + " / " + colDef.ColumnType.Name);
#endif
                        colNames.Add(colDef.ColumnName);
                        columnNameType.Add(colDef.ColumnName, colDef.ColumnType.Name);
                    }

#if DEBUGG
                    Utilities.LogMessage("Columns specified in columnFilter parameter");
                    foreach (string str in m_columnFilter)
                    {
                        Utilities.LogMessage("column name: " + str);
                    }
#endif
                    System.Collections.ObjectModel.ReadOnlyCollection<Microsoft.EnterpriseManagement.Common.Result>
                        resultReadOnlyCollection = resultSet.Results;

                    int resultCount = resultReadOnlyCollection.Count;
                    Utilities.LogMessage(currentMethodName + " :: Number of results from API call: " +
                        resultCount);
                    if (resultCount > 0)
                    {
#if DEBUGG
                        /*
                        foreach (Microsoft.EnterpriseManagement.Common.Result result in resultReadOnlyCollection)
                        {
                            int numResults = result.Values.Count;
                            Utilities.LogMessage("num objs: " + numResults);
                            for (int i = 0; i < numResults; i++)
                            {
                                System.Collections.ObjectModel.ReadOnlyCollection<object> results = result.Values;
                                for (int j = 0; j < results.Count; j++)
                                {
                                    Utilities.LogMessage("Result: " + results[j]);
                                }                            
                            }
                            Utilities.LogMessage("**************************");
                        }
                        */
                        foreach (Microsoft.EnterpriseManagement.Common.Result result in resultReadOnlyCollection)
                        {
                            foreach (object obj in result)
                            {
                                Utilities.LogMessage("Result: " + obj.ToString());
                            }
                            Utilities.LogMessage("**************************");
                        }
#endif

                        if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL))
                        //catch VARs that were expected to FAIL that got false positives (got results, but shouldn't have)
                        {
                            throw new VarFail("Expected to FAIL, but succeeded (got results), therefore FAIL");
                        }
                    }
                    else
                    {
                        if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL))
                        {
                            Utilities.LogMessage(currentMethodName + " :: Expected to FAIL, therefore PASS");
                        }
                        else
                        {
                            Utilities.LogMessage(currentMethodName + " :: Expected to PASS, but result count == 0, therefore logging for further investigation...");
                            if (!String.IsNullOrEmpty(sloGuid))
                                Utilities.LogMessage("Please investigate: SLO Guid: " + sloGuid);
                        }
                    }
                }
                else
                {
                    throw new VarAbort("resultSet was null");
                }

                return resultSet;

                #endregion
            }
            #region CatchFinally

            //exceptions seen
            /*
             * misaligned SP name with columnFilter set (SERVICELEVEL1 with VALID (valid set doesn't work for SERVICELEVELx SPS):
             * <<<EXCEPTION>>>The Column Name DisplayName specified was invalid. 
             * <<<EXCEPTION>>>The Column Name ManagementEntityDefaultName specified was invalid.
             * 
             * SQLADMIN, INVALID, NOTPRESENT, explicit 'dbo.Microsoft_...' spName
             * <<<EXCEPTION>>>Microsoft.EnterpriseManagement.Warehouse.IncorrectStoredProcedureParameterException: The Stored Procedure does not start with the correct Prefix
             * 
             * INVALID spParameters - expected FAIL, therefore PASS
             * 
             * OMITTED spParameters
             * <<<EXCEPTION>>>Procedure or function 'Microsoft_SystemCenter_DataWarehouse_Report_Library_PerformaceReportDataGet' expects parameter '@OptionList', which was not supplied.
             * 
             * ADDITIONAL spParameters
             * <<<EXCEPTION>>>Procedure or function Microsoft_SystemCenter_DataWarehouse_Report_Library_PerformaceReportDataGet has too many arguments specified.
             * 
             * NONE spParameters
             * <<<EXCEPTION>>>Procedure or function 'Microsoft_SystemCenter_DataWarehouse_Report_Library_PerformaceReportDataGet' expects parameter '@StartDate', which was not supplied.
             * 
             * INVALIDTYPES spParameters
             * <<<EXCEPTION>>>Operand type clash: int is incompatible with xml
             * 
             * SERVICELEVEL1 SP - expected PASS, therefore FAIL
             * <<<EXCEPTION>>>System.Data.SqlClient.SqlException: XML parsing: line 1, character 190, unexpected end of input
             */

                //7-10, 12- do not see setting to FAIL

            catch (VarFail)
            {
                throw;
            }
            catch (VarAbort)
            {
                throw;
            }
            catch (IncorrectStoredProcedureParameterException isppe)
            {
                if (isppe != null)
                {
                    //INVALID or SQLADMIN or NOTPRESENT Stored Proc negative test case
                    if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL) &&
                        isppe.ToString().Contains("Stored Procedure does not start with the correct Prefix"))
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicates the \'Stored Procedure does not start with the correct Prefix\', SP: " +
                            m_SP);
                        Utilities.LogMessage(currentMethodName + " :: Expected to FAIL, therefore PASS");
                        return resultSet;
                    }
                    else if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL))
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicated stored procedure WAS expected to FAIL; SP: " +
                            m_SP);
                        Utilities.LogMessage(currentMethodName + " :: but exception was of unexpected form: " + isppe);
                        throw new VarAbort("Exception indicated stored procedure was incorrect, but VAR WAS expected to FAIL");
                    }
                    else
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicated stored procedure was incorrect, but VAR was not expected to FAIL; SP: " +
                            m_SP);
                        Utilities.LogMessage(currentMethodName + " :: Expected to PASS, therefore FAIL");
                        throw new VarFail("Exception indicated stored procedure was incorrect, but VAR was not expected to FAIL");
                    }
                }
                else
                {
                    Utilities.LogMessage(currentMethodName + " :: Exception is null");
                    throw new VarAbort("Exception is null");
                }
            }
            catch (UnknownDatabaseException ude)
            {
                if (ude != null)
                {
                    //INVALID or SQLADMIN or NOTPRESENT Stored Proc negative test case
                    if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL) &&
                        ude.ToString().Contains("expects parameter"))
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicated that an expected parameter was missing: " + ude);
                        Utilities.LogMessage(currentMethodName + " :: Expected to FAIL, therefore PASS");
                        return resultSet;
                    }
                    else if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL) &&
                        ude.ToString().Contains("has too many arguments specified"))
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicated that an additional parameter was found : " + ude);
                        Utilities.LogMessage(currentMethodName + " :: Expected to FAIL, therefore PASS");
                        return resultSet;
                    }
                    else if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL) &&
                        ude.ToString().Contains("Operand type clash"))
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicated that there was a parameter type mismatch : " + ude);
                        Utilities.LogMessage(currentMethodName + " :: Expected to FAIL, therefore PASS");
                        return resultSet;
                    }
                    else if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL))
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicated stored procedure WAS expected to FAIL; SP: " +
                            m_SP);
                        Utilities.LogMessage(currentMethodName + " :: but exception was of unexpected form: " + ude);
                        throw new VarAbort("Exception indicated stored procedure was incorrect, but VAR WAS expected to FAIL");
                    }
                    else
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicated stored procedure was incorrect, but VAR was not expected to FAIL; SP: " +
                            m_SP);
                        Utilities.LogMessage(currentMethodName + " :: Expected to PASS, therefore FAIL");
                        throw new VarFail("Exception indicated stored procedure was incorrect, but VAR was not expected to FAIL");
                    }
                }
                else
                {
                    Utilities.LogMessage(currentMethodName + " :: Exception is null");
                    throw new VarAbort("Exception is null");
                }
            }
            //receive following exception when SP name is invalid (so for SQLADMIN (sys.), INVALID (dbo.), NOTPRESENT (made up), and explicitly wrong (dbo.)
            //currently perms 10-13
            catch (System.Resources.MissingManifestResourceException mmre)
            {
                if (mmre != null)
                {
                    //INVALID or SQLADMIN or NOTPRESENT Stored Proc negative test case
                    if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL) &&
                        mmre.ToString().Contains("This message cannot support the operation because it has been read"))
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicates it is likely the stored procedure was specified incorrectly, SP: " +
                            m_SP);
                        Utilities.LogMessage(currentMethodName + " :: Expected to FAIL, therefore PASS");
                        return resultSet;
                    }
                    else if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL))
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicated stored procedure WAS expected to FAIL; SP: " +
                            m_SP);
                        Utilities.LogMessage(currentMethodName + " :: but exception was of unexpected form: " + mmre);
                        throw new VarAbort("Exception indicated stored procedure was incorrect, but VAR WAS expected to FAIL");
                    }
                    else
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicated stored procedure was incorrect, but VAR was not expected to FAIL; SP: " +
                            m_SP);
                        Utilities.LogMessage(currentMethodName + " :: Expected to PASS, therefore FAIL");
                        throw new VarFail("Exception indicated stored procedure was incorrect, but VAR was not expected to FAIL");
                    }
                }
                else
                {
                    Utilities.LogMessage(currentMethodName + " :: Exception is null");
                    throw new VarAbort("Exception is null");
                }
            }
            catch (Microsoft.EnterpriseManagement.Common.ServiceNotRunningException snre)
            {
                if (snre != null)
                {
                    //SDK Service stopped negative test case
                    if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL) &&
                        snre.ToString().Contains("The sdk service is either not running or not yet initialized"))
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicates it is likely the SDK service is not running");
                        Utilities.LogMessage(currentMethodName + " :: Expected to FAIL, therefore PASS");
                        return resultSet;
                    }
                    else if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL))
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicates it is likely the SDK service is not running and" +
                            "stored procedure WAS expected to FAIL; SP: " + m_SP);
                        Utilities.LogMessage(currentMethodName + " :: but exception was of unexpected form: " + snre);
                        throw new VarAbort("Exception indicated stored procedure was incorrect, but VAR was not expected to FAIL");
                    }
                    else
                    {
                        Utilities.LogMessage(currentMethodName + " :: Expected to PASS, therefore FAIL");
                        throw new VarFail("Exception indicated the SDK service is not running, but VAR was not expected to FAIL");
                    }
                }
                else
                {
                    Utilities.LogMessage(currentMethodName + " :: Exception is null");
                    throw new VarAbort("Exception is null");
                }
            }
            catch (Exception e)
            {
                if (e != null)
                {
                    //OMITTED or NONE SPParameters negative test case
                    if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL) &&
                        e.ToString().Contains("expects parameter"))
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicated that an expected parameter was missing : " + e);
                        Utilities.LogMessage(currentMethodName + " :: Expected to FAIL, therefore PASS");
                        return resultSet;
                    }
                    //ADDITIONAL SPParameters negative test case
                    else if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL) &&
                        e.ToString().Contains("has too many arguments specified"))
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicated that an additional parameter was found : " + e);
                        Utilities.LogMessage(currentMethodName + " :: Expected to FAIL, therefore PASS");
                        return resultSet;
                    }
                    //SQL Service stopped negative test case
                    else if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL) &&
                        ((e.ToString().Contains("A network-related or instance-specific error occurred"))
                        || (e.InnerException != null && e.InnerException.ToString().Contains("A network-related or instance-specific error occurred"))))
                    {
                        Utilities.LogMessage(currentMethodName + " :: A SQLException indicated that there was no connection to SQL found : " + e);
                        Utilities.LogMessage(currentMethodName + " :: Expected to FAIL, therefore PASS");
                        return resultSet;
                    }
                    //INVALIDTYPE SPParameters negative test case
                    else if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL) &&
                        (e.ToString().Contains("Operand type clash")))
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicated that there was a parameter type mismatch : " + e);
                        Utilities.LogMessage(currentMethodName + " :: Expected to FAIL, therefore PASS");
                        return resultSet;
                    }
                    else if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL) &&
                        (e.ToString().Contains("specified was invalid")))
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicated that a column name specified was invalid : " + e);
                        Utilities.LogMessage(currentMethodName + " :: ...most likely this is due to a mismatch between the SP and the column filters");
                        throw e;
                    }
                    else if (ExpectedOutcome != null && ExpectedOutcome.ToUpper().Equals(Constants.FAIL))
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception indicated stored procedure WAS expected to FAIL; SP: " +
                            m_SP);
                        Utilities.LogMessage(currentMethodName + " :: but exception was of unexpected form: " + e);
                        throw e;
                    }
                    else
                    {
                        Utilities.LogMessage(currentMethodName + " :: Exception was not of expected form - rethrowing");
                        throw e;
                    }
                }
                else
                {
                    Utilities.LogMessage(currentMethodName + " :: Exception is null");
                    throw new VarAbort("Exception is null");
                }
            }
            finally
            {
            }
            #endregion
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to get DW Data
        /// </summary>
        /// <param name="dw">DataWarehouse</param>
        /// <param name="scaleOut">scaleOut</param>
        /// <param name="paramSet">paramSet</param>
        /// <param name="elapsedTimes">elapsedTimes</param>
        /// <returns>ResultSet</returns>
        /// ------------------------------------------------------------------
        private static ResultSet CallGetDWData(DataWarehouse dw, string scaleOut,
            StoredProcedureParameterCollection paramSet, ref Dictionary<string, long> elapsedTimes)
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Microsoft.EnterpriseManagement.Common.ResultSet resultSet = null;
            Microsoft.EnterpriseManagement.Common.ResultSet resultSet2 = null;
            Microsoft.EnterpriseManagement.Common.ResultSet resultSet3 = null;

            Stopwatch watch = new Stopwatch();

            if (scaleOut != null)
            {
                if (m_ColumnFilter.Count > 0)
                {
                    if (m_TimeOut != Constants.ILLOGICAL_INTEGER)
                    {
                        switch (scaleOut)
                        {
                            case Constants.TWO:
                                Utilities.LogMessage(currentMethodName + " :: Scaleout testing - " +
                                    "calling GetDataWarehouseData with params: stored proc - " +
                                    m_SP + ", paramSet, columnFilter and timeOut");

                                resultSet2 = dw.GetDataWarehouseData(m_SP, paramSet, m_ColumnFilter, m_TimeOut);
                                watch.Start();
                                resultSet = dw.GetDataWarehouseData(m_SP, paramSet, m_ColumnFilter, m_TimeOut);
                                watch.Stop();
                                break;
                            case Constants.THREE:
                                Utilities.LogMessage(currentMethodName + " :: Scaleout testing - " +
                                    "calling GetDataWarehouseData with params: stored proc - " +
                                    m_SP + ", paramSet, columnFilter and timeOut");
                                resultSet2 = dw.GetDataWarehouseData(m_SP, paramSet, m_ColumnFilter, m_TimeOut);
                                resultSet3 = dw.GetDataWarehouseData(m_SP, paramSet, m_ColumnFilter, m_TimeOut);
                                watch.Start();
                                resultSet = dw.GetDataWarehouseData(m_SP, paramSet, m_ColumnFilter, m_TimeOut);
                                watch.Stop();
                                break;
                            default:
                                throw new ArgumentException(currentMethodName + ": Invalid value for ScaleOut: " +
                                    scaleOut);
                        }
                    }
                    else
                    {
                        switch (scaleOut)
                        {
                            case Constants.TWO:
                                Utilities.LogMessage(currentMethodName + " :: Scaleout testing - " +
                                    "calling GetDataWarehouseData with params: stored proc - " +
                                    m_SP + ", paramSet and columnFilter");

                                resultSet2 = dw.GetDataWarehouseData(m_SP, paramSet, m_ColumnFilter);
                                watch.Start();
                                resultSet = dw.GetDataWarehouseData(m_SP, paramSet, m_ColumnFilter);
                                watch.Stop();
                                break;
                            case Constants.THREE:
                                Utilities.LogMessage(currentMethodName + " :: Scaleout testing - " +
                                    "calling GetDataWarehouseData with params: stored proc - " +
                                    m_SP + ", paramSet and columnFilter");
                                resultSet2 = dw.GetDataWarehouseData(m_SP, paramSet, m_ColumnFilter);
                                resultSet3 = dw.GetDataWarehouseData(m_SP, paramSet, m_ColumnFilter);
                                watch.Start();
                                resultSet = dw.GetDataWarehouseData(m_SP, paramSet, m_ColumnFilter);
                                watch.Stop();
                                break;
                            default:
                                throw new ArgumentException(currentMethodName + ": Invalid value for ScaleOut: " +
                                    scaleOut);
                        }
                    }
                }
                else
                {
                    if (m_TimeOut != Constants.ILLOGICAL_INTEGER)
                    {
                        switch (scaleOut)
                        {
                            case Constants.TWO:
                                Utilities.LogMessage(currentMethodName + " :: Scaleout testing - " +
                                    "calling GetDataWarehouseData with params: stored proc - " +
                                    m_SP + ", paramSet and timeOut");

                                resultSet2 = dw.GetDataWarehouseData(m_SP, paramSet, m_TimeOut);
                                watch.Start();
                                resultSet = dw.GetDataWarehouseData(m_SP, paramSet, m_TimeOut);
                                watch.Stop();
                                break;
                            case Constants.THREE:
                                Utilities.LogMessage(currentMethodName + " :: Scaleout testing - " +
                                    "calling GetDataWarehouseData with params: stored proc - " +
                                    m_SP + ", paramSet and timeOut");
                                resultSet2 = dw.GetDataWarehouseData(m_SP, paramSet, m_TimeOut);
                                resultSet3 = dw.GetDataWarehouseData(m_SP, paramSet, m_TimeOut);
                                watch.Start();
                                resultSet = dw.GetDataWarehouseData(m_SP, paramSet, m_TimeOut);
                                watch.Stop();
                                break;
                            default:
                                throw new ArgumentException(currentMethodName + ": Invalid value for ScaleOut: " +
                                    scaleOut);
                        }
                    }
                    else
                    {
                        switch (scaleOut)
                        {
                            case Constants.TWO:
                                Utilities.LogMessage(currentMethodName + " :: Scaleout testing - " +
                                    "calling GetDataWarehouseData with params: stored proc - " +
                                    m_SP + " and paramSet");

                                resultSet2 = dw.GetDataWarehouseData(m_SP, paramSet);
                                watch.Start();
                                resultSet = dw.GetDataWarehouseData(m_SP, paramSet);
                                watch.Stop();
                                break;
                            case Constants.THREE:
                                Utilities.LogMessage(currentMethodName + " :: Scaleout testing - " +
                                    "calling GetDataWarehouseData with params: stored proc - " +
                                    m_SP + " and paramSet");
                                resultSet2 = dw.GetDataWarehouseData(m_SP, paramSet);
                                resultSet3 = dw.GetDataWarehouseData(m_SP, paramSet);
                                watch.Start();
                                resultSet = dw.GetDataWarehouseData(m_SP, paramSet);
                                watch.Stop();
                                break;
                            default:
                                throw new ArgumentException(currentMethodName + ": Invalid value for ScaleOut: " +
                                    scaleOut);
                        }
                    }
                }
            }
            else
            {
                if (m_ColumnFilter.Count > 0)
                {
                    if (m_TimeOut != Constants.ILLOGICAL_INTEGER)
                    {
                        watch.Start();
                        resultSet = dw.GetDataWarehouseData(m_SP, paramSet, m_ColumnFilter, m_TimeOut);
                        watch.Stop();
                    }
                    else
                    {
                        watch.Start();
                        resultSet = dw.GetDataWarehouseData(m_SP, paramSet, m_ColumnFilter);
                        watch.Stop();
                    }
                }
                else
                {
                    if (m_TimeOut != Constants.ILLOGICAL_INTEGER)
                    {
                        watch.Start();
                        resultSet = dw.GetDataWarehouseData(m_SP, paramSet, m_TimeOut);
                        watch.Stop();
                    }
                    else
                    {
                        watch.Start();
                        resultSet = dw.GetDataWarehouseData(m_SP, paramSet);
                        watch.Stop();
                    }
                }
            }
            elapsedTimes.Add(m_SP, watch.ElapsedMilliseconds);
            watch.Reset();
            return resultSet;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method for calling Reporting (DW) SDK client API using parameters provided in variation in varmap
        /// and comparing against results from API call (resultset passed in)
        /// </summary>
        /// <param name="StoredProc">string</param>
        /// <param name="Params">string</param>
        /// <param name="FilterCriteria">string</param>
        /// <param name="AggregationMeans">string</param>
        /// <param name="TimeRange">string</param>
        /// <param name="PerfDataInsertion">string</param>
        /// <param name="ExpectedOutcome">string</param>
        /// <param name="resultsFromAPICall">Microsoft.EnterpriseManagement.Common.ResultSet</param>
        /// <param name="CurrentTime">DateTime</param>
        /// <param name="context">IContext</param>
        /// <returns>bool</returns>
        /// <History>
        ///     [starrpar] 23-OCT-09    Created
        ///</History>
        /// ------------------------------------------------------------------
        public static bool CallSPDirectlyAndCompareResults(
            string StoredProc,
            string Params,
            string FilterCriteria,
            string AggregationMeans,
            string TimeRange,
            string PerfDataInsertion,
            string ExpectedOutcome,
            Microsoft.EnterpriseManagement.Common.ResultSet resultsFromAPICall,
            DateTime CurrentTime,
            IContext context
            )
        {
            string currentMethodName = String.Empty;

            try
            {
                currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

                if (ExpectedOutcome != Constants.FAIL)
                {
                    #region Set input and parameter set values

                    SetParams(StoredProc, FilterCriteria, AggregationMeans,
                        TimeRange, PerfDataInsertion);

                    string xmlInput = SetXmlInputValue(context);

                    #endregion

                    #region prepare SQL for direct SP call

                    //this approach has been obsoleted in lieu of using Reporting.GetDataWarehouse()
                    //but I still need to find where that method is created and how to get a Reporting object first
                    //ManagementGroup mg = Utilities.ConnectToManagementServer();
                    //DataWarehouse dw = mg.GetDataWarehouse();

                    DateTime SPCallStartTime = new DateTime();
                    DateTime SPCallEndTime = new DateTime();

                    SPCallStartTime = DateTime.Now;

                    Utilities.LogMessage(currentMethodName + " :: Calling SP: " + m_SP +
                        " with provided input params");

                    StringBuilder strConnection = new StringBuilder("Initial Catalog=");
                    strConnection.Append(m_DBName);
                    strConnection.Append("; Data Source=");
                    strConnection.Append(m_DBInstanceName);
                    strConnection.Append(";Integrated Security=SSPI; Connect Timeout=");
                    strConnection.Append(m_SQLConnectionTimeout);

                    m_SQLDWConnection = new SqlConnection(strConnection.ToString());
                    m_SQLDWConnection.Open();

                    SqlCommand spCmd = new SqlCommand(m_SP, m_SQLDWConnection);
                    spCmd.CommandType = CommandType.StoredProcedure;

                    #endregion

                    #region Set Parameters for direct SP call

                    SetDirectSPCallParameters(Params, xmlInput, ref spCmd);

                    #endregion

                    #region Get SP Results and Compare with API Results

                    //Design approach:
                    //have resultset from API call, containing column name/type collection and in whatever
                    //column order was specified in columnFilter input parameter
                    //verify column count from SP call matches API call column count
                    //parse through column collections, verifying column names match
                    //and that column names and order match that specified in columnFilter
                    //parse through row-by-row of API resultset collection
                    //verify row-by-row that each object in SP results match

                    Stopwatch watch = new Stopwatch();
                    Dictionary<string, long> elapsedTimes = new Dictionary<string, long>();

                    watch.Start();
                    SqlDataReader reader = spCmd.ExecuteReader();
                    watch.Stop();
                    elapsedTimes.Add(m_SP, watch.ElapsedMilliseconds);
                    watch.Reset();

                    int numTimes = elapsedTimes.Count;
                    Dictionary<string, long>.KeyCollection keyColl = elapsedTimes.Keys;

                    //Utilities.LogMessage(currentMethodName + " :: #keys: " + keyColl.Count);

                    foreach (string key in keyColl)
                    {
                        Utilities.LogMessage(currentMethodName + " :: Directly called, the stored procedure: " +
                            key);
                        Utilities.LogMessage(currentMethodName + " :: ... took " + elapsedTimes[key].ToString() +
                            " milliseconds to execute");
                    }
                    Utilities.LogMessage("**********************************************************************" +
                        "***********************************************");

                    int numRowsSP = 0;
                    int numRowsAPI = 0;

                    int numColumnsSP = reader.FieldCount;
                    int numColumnsAPI = resultsFromAPICall.ColumnDefinitions.Count;
                    //verify column count from SP call matches API call column count
                    if (numColumnsAPI != numColumnsSP)
                        Utilities.LogMessage(currentMethodName + " :: Columnfiltering in use - number of columns " +
                            "in result set from API call (" + numColumnsAPI + ") does not match number of columns" +
                            " from SP call (" + numColumnsSP + ")");

                    //populate direct SP call results into a collection for easy retrieval by columnFilter order
                    ArrayList spResults = new ArrayList();
                    ArrayList columnNames = new ArrayList();
                    ArrayList rowContents = null;
                    while (reader.Read())
                    {
                        rowContents = new ArrayList();

                        //only get column names once
                        if (numRowsSP < 1)
                        {
                            for (int k = 0; k < numColumnsSP; k++)
                            {
                                columnNames.Add(reader.GetName(k));
                            }
                        }
                        for (int m = 0; m < numColumnsSP; m++)
                        {
                            rowContents.Add(reader.GetValue(m));
                        }
                        numRowsSP++;
                        spResults.Add(rowContents);
                    }
                    Utilities.LogMessage(currentMethodName + " :: Number of results from SP call: " + numRowsSP);

#if DEBUGG                    
                    //quick visual verification
                    foreach (string cName in m_columnFilter)
                    {
                        Utilities.LogMessage("column: " + cName + " :: values:");
                        foreach (ArrayList arl in spResults)
                        {
                            foreach (object ob in arl)
                            {
                                Utilities.LogMessage("             - " + ob.ToString());
                            }
                        }
                    }
#endif
                    if (resultsFromAPICall != null)
                    {
                        System.Collections.ObjectModel.ReadOnlyCollection<Microsoft.EnterpriseManagement.Common.Result>
                            resultReadOnlyCollection = resultsFromAPICall.Results;

                        numRowsAPI = resultReadOnlyCollection.Count;

                        if (numRowsAPI > 0)
                        {
                            //parse through row-by-row of API resultset collection
                            int n = 0;
                            foreach (Microsoft.EnterpriseManagement.Common.Result result in resultReadOnlyCollection)
                            {
                                //only compare up to number of rows returned to API call 
                                //(in case call to SP directly returned more rows)
                                if (n < numRowsAPI)
                                {
#if DEBUGG
                                Utilities.LogMessage("API result value: " + obj.ToString());
#endif
                                    int j = 0;
                                    ArrayList tmpArray = (ArrayList)spResults[n];
                                    foreach (string cName in m_ColumnFilter)
                                    {
                                        int index = columnNames.IndexOf(cName);
                                        if (index > 0)
                                        {
                                            //verify row-by-row that each object in SP results match
                                            if (tmpArray[index].ToString().ToUpper().Equals(result.Values[j].ToString().ToUpper()))
                                            {
#if DEBUGG
                                            Utilities.LogMessage("Match: " + tmpArray[index].ToString() + " :: " + result.Values[index].ToString());
#endif
                                            }
                                            else
                                            {
                                                Utilities.LogMessage("***********************************************************" +
                                                    "**********************");
                                                Utilities.LogMessage(" :: No match!!!!!  API result: " + result.Values[j].ToString() +
                                                    " ::  SP result: " + tmpArray[index].ToString());
                                                Utilities.LogMessage("***************************************************************" +
                                                    "******************");
                                            }
                                        }
                                        j++;
                                    }
                                    n++;
                                }
                            }
                        }
                        else
                        {
                            throw new VarAbort("Failed to read from SqlDataReader object");
                        }
                    }
                    else
                    {
                        Utilities.LogMessage(currentMethodName + " :: results from API call were null");
                    }

                    SPCallEndTime = DateTime.Now;

#if DEBUGG
                    Utilities.LogMessage("Number of rows from API call: " + numRowsAPI);
                    Utilities.LogMessage("Number of rows from SP call: " + numRowsSP);
#endif
                    if (numRowsAPI != numRowsSP)
                        throw new VarFail("Number of rows returned by API do not match that returned directly by SP");

                    reader.Close();
                    m_SQLDWConnection.Close();

                    #endregion

                    #region output timing results

                    TimeSpan ts = new TimeSpan();
                    ts = SPCallEndTime - SPCallStartTime;
                    Utilities.LogMessage(currentMethodName + " :: Time elapsed: " + ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds + "." + ts.Milliseconds);

                    #endregion
                }
                return true;
            }
            #region CatchFinally

            catch (VarFail)
            {
                throw;
            }
            catch (VarAbort)
            {
                throw;
            }
            finally
            {
            }
            #endregion
        }

        #region Set Methods
        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to set params
        /// </summary>
        /// <param name="sp">sp name</param>
        /// <param name="cf">cf</param>
        /// <param name="am">am</param>
        /// <param name="tr">tr</param>
        /// <param name="pdi">pdi</param>
        /// ------------------------------------------------------------------
        private static void SetParams(string sp, string cf, string am, string tr, string pdi)
        {
            string currentMethodName = String.Empty;

            try
            {
                currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                SetStoredProc(sp);
                SetColumnFilter(cf);
                SetTimeRange(tr);
                SetAggregationMeans(am);
                SetPerfDataInsertion(pdi);
            }
            finally
            {
                Utilities.LogMessage(currentMethodName + ": exiting SetParams");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to set Stored procedule
        /// </summary>
        /// <param name="sp">Stored procedule name</param>
        /// ------------------------------------------------------------------
        private static void SetStoredProc(string sp)
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            if (sp != null)
            {
                switch (sp.ToUpper())
                {
                    case Constants.PERFORMANCE:
                        m_SP = Constants.PERFORMANCE_SP;
                        break;
                    case Constants.AVAILABILITY:
                        m_SP = Constants.AVAILABILITY_SP;
                        break;
                    case Constants.SERVICELEVEL1:
                        m_SP = Constants.SERVICELEVEL_SP1;
                        break;
                    case Constants.SERVICELEVEL2:
                        m_SP = Constants.SERVICELEVEL_SP2;
                        break;
                    case Constants.VALID:
                        //implement some random selection method between the 3 valid SPs
                        //eventually possibly support a series of other SPs that are not only limited to the 3 listed above
                        //this would take some means of designating how many and of what type the SP input parameters are
                        //(a bit more involved than needed for the present application)
                        m_SP = Constants.PERFORMANCE_SP;
                        break;
                    case Constants.INVALID:
                        //assign a valid SP that is not valid for this improvement (via using this API)
                        //potentially, select randomly from a list of valid SPs that are not valid for this application
                        m_SP = Constants.INVALID_SP;
                        break;
                    case Constants.NOTPRESENT:
                        m_SP = Constants.MADE_UP_SP;
                        break;
                    case Constants.SQLADMIN:
                        m_SP = Constants.SQLADMIN_SP;
                        break;
                    default:
                        //if not expected values above, assume SP is specified explicitly in varmap value - log so known
                        m_SP = sp;
                        Utilities.LogMessage(currentMethodName + " :: SP was explicitly provided in varmap: " + m_SP);
                        break;
                }
            }
            else
            {
                throw new NullReferenceException("Stored Proc provided as input was null");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to set column filter
        /// </summary>
        /// <param name="cf">cf</param>
        /// ------------------------------------------------------------------
        private static void SetColumnFilter(string cf)
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            if (cf != null)
            {
                m_ColumnFilter.Clear();
                switch (cf.ToUpper())
                {
                    case Constants.PERFORMANCE:
                        m_ColumnFilter.Add("DateTime");
                        m_ColumnFilter.Add("SampleCount");
                        m_ColumnFilter.Add("AverageValue");
                        m_ColumnFilter.Add("MinValue");
                        m_ColumnFilter.Add("MaxValue");
                        m_ColumnFilter.Add("StandardDeviation");
                        m_ColumnFilter.Add("RuleRowId");
                        m_ColumnFilter.Add("InstanceName");
                        m_ColumnFilter.Add("ManagedEntityRowId");
                        m_ColumnFilter.Add("ManagedEntityGuid");
                        m_ColumnFilter.Add("ManagedEntityDefaultName");
                        m_ColumnFilter.Add("Path");
                        m_ColumnFilter.Add("DisplayName");
                        m_ColumnFilter.Add("ManagementGroupGuid");
                        m_ColumnFilter.Add("ManagementGroupDefaultName");
                        m_ColumnFilter.Add("RuleGuid");
                        m_ColumnFilter.Add("RuleDisplayName");
                        m_ColumnFilter.Add("MultiInstanceInd");
                        m_ColumnFilter.Add("Group");
                        m_ColumnFilter.Add("GroupTitle");
                        m_ColumnFilter.Add("Position");
                        m_ColumnFilter.Add("ChartScale");
                        m_ColumnFilter.Add("ChartType");
                        m_ColumnFilter.Add("ChartColor");
                        m_ColumnFilter.Add("OptionXml");
                        break;
                    case Constants.PERF_SELECTED_COLUMNS:
                        m_ColumnFilter.Add("DisplayName");
                        m_ColumnFilter.Add("ManagedEntityDefaultName");
                        m_ColumnFilter.Add("ManagementGroupDefaultName");
                        m_ColumnFilter.Add("RuleDisplayName");
                        m_ColumnFilter.Add("InstanceName");
                        m_ColumnFilter.Add("Group");
                        m_ColumnFilter.Add("GroupTitle");
                        m_ColumnFilter.Add("SampleCount");
                        m_ColumnFilter.Add("AverageValue");
                        m_ColumnFilter.Add("MinValue");
                        m_ColumnFilter.Add("MaxValue");
                        m_ColumnFilter.Add("StandardDeviation");
                        break;
                    case Constants.AVAILABILITY:
                        m_ColumnFilter.Add("DateTime");
                        m_ColumnFilter.Add("InRedStateMilliseconds");
                        m_ColumnFilter.Add("InYellowStateMilliseconds");
                        m_ColumnFilter.Add("InGreenStateMilliseconds");
                        m_ColumnFilter.Add("InWhiteStateMilliseconds");
                        m_ColumnFilter.Add("InDisabledStateMilliseconds");
                        m_ColumnFilter.Add("InPlannedMaintenanceMilliseconds");
                        m_ColumnFilter.Add("InUnplannedMaintenanceMilliseconds");
                        m_ColumnFilter.Add("HealthServiceUnavailableMilliseconds");
                        m_ColumnFilter.Add("IntervalDurationMilliseconds");
                        m_ColumnFilter.Add("ManagedEntityRowId");
                        m_ColumnFilter.Add("ManagedEntityGuid");
                        m_ColumnFilter.Add("ManagedEntityMonitorRowId");
                        m_ColumnFilter.Add("ManagedEntityDefaultName");
                        m_ColumnFilter.Add("ManagedEntityTypeGuid");
                        m_ColumnFilter.Add("Path");
                        m_ColumnFilter.Add("ManagementGroupGuid");
                        m_ColumnFilter.Add("ManagementGroupDefaultName");
                        m_ColumnFilter.Add("DisplayName");
                        break;
                    case Constants.AVAIL_SELECTED_COLUMNS:
                        m_ColumnFilter.Add("DisplayName");
                        m_ColumnFilter.Add("ManagedEntityDefaultName");
                        m_ColumnFilter.Add("ManagementGroupDefaultName");
                        m_ColumnFilter.Add("InRedStateMilliseconds");
                        m_ColumnFilter.Add("InYellowStateMilliseconds");
                        m_ColumnFilter.Add("InGreenStateMilliseconds");
                        break;
                    case Constants.SERVICELEVEL1:
                    case Constants.SERVICELEVEL2:
                        m_ColumnFilter.Add("ServiceLevelAgreementRowId");
                        m_ColumnFilter.Add("ServiceLevelAgreementManagedEntityRowId");
                        m_ColumnFilter.Add("ManagementGroupRowId");
                        break;
                    case Constants.VALID: //columns common to all SP result sets
                        m_ColumnFilter.Add("DisplayName");
                        m_ColumnFilter.Add("DateTime");
                        m_ColumnFilter.Add("ManagementGroupDefaultName");
                        m_ColumnFilter.Add("ManagementGroupGuid");
                        m_ColumnFilter.Add("ManagedEntityRowId");
                        m_ColumnFilter.Add("ManagedEntityDefaultName");
                        m_ColumnFilter.Add("ManagedEntityGuid");
                        m_ColumnFilter.Add("Path");
                        break;
                    case Constants.INVALID:
                        m_ColumnFilter.Add("A_column_that_will_not_be_there");
                        break;
                    case Constants.NONE:
                        //do nothing (don't add anything to m_columnFilter - Count being 0 will exclude from method call)
                        break;
                    default:
                        //if none of the above, assume a comma-delimited string of column names is specified
                        Utilities.LogMessage(currentMethodName + " :: comma-delimited string passed for columnFilters");
                        string[] columnFilterStrings = cf.Split(',');
                        for (int i = 0; i < columnFilterStrings.Length; i++)
                        {
                            string tmpStr = columnFilterStrings[i];
                            Utilities.LogMessage(currentMethodName + " :: column: " + tmpStr);
                            m_ColumnFilter.Add(tmpStr);
                        }
                        break;
                }
            }
            else
            {
                Utilities.LogMessage(currentMethodName + ": Information: Column filter value is null");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to set time range
        /// </summary>
        /// <param name="tr">Time range</param>
        /// ------------------------------------------------------------------
        private static void SetTimeRange(string tr)
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            m_EndTime = DateTime.UtcNow;
            if (tr != null)
            {
                switch (tr)
                {
                    case Constants.TWODAYS:
                        m_StartTime = m_EndTime.AddDays(-2);
                        break;
                    case Constants.WEEK:
                        m_StartTime = m_EndTime.AddDays(-7);
                        break;
                    case Constants.MONTH:
                        m_StartTime = m_EndTime.AddDays(-30);
                        break;
                    case Constants.QUARTER:
                        m_StartTime = m_EndTime.AddDays(-91);
                        break;
                    case Constants.YEAR:
                        m_StartTime = m_EndTime.AddDays(-365);
                        break;
                    default:
                        m_StartTime = m_EndTime.AddMinutes(-(Convert.ToInt32(tr)));
                        break;
                }
            }
            else //if no timerange provided, simply assume 2 days
            {
                Utilities.LogMessage(currentMethodName + " :: TimeRange value was not set (was null)," +
                    " 2 days back being assumed");
                m_StartTime = m_EndTime.AddDays(-2);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to set aggregation means
        /// </summary>
        /// <param name="am">aggregation</param>
        /// ------------------------------------------------------------------
        private static void SetAggregationMeans(string am)
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            if (am != null)
            {
                switch (am)
                {
                    case Constants.DAILY:
                        if (m_SP.ToUpper().Contains(Constants.SERVICELEVEL))
                            m_AggregationMeans = (int)slaDataAggregationType.daily;
                        else
                            m_AggregationMeans = (int)dataAggregationType.daily;
                        break;
                    case Constants.HOURLY:
                        if (m_SP.ToUpper().Contains(Constants.SERVICELEVEL))
                            m_AggregationMeans = (int)slaDataAggregationType.hourly;
                        else
                            m_AggregationMeans = (int)dataAggregationType.hourly;
                        break;
                    default:
                        Utilities.LogMessage(currentMethodName + " :: Aggregation was set to something " +
                            "other than Hourly or Daily, Hourly being assumed");
                        if (m_SP.ToUpper().Contains(Constants.SERVICELEVEL))
                            m_AggregationMeans = (int)slaDataAggregationType.hourly;
                        else
                            m_AggregationMeans = (int)dataAggregationType.hourly;
                        break;
                }
            }
            else
            {
                Utilities.LogMessage(currentMethodName + " :: Aggregation was not set (value was null); " +
                    "Hourly being assumed");
                if (m_SP.ToUpper().Contains(Constants.SERVICELEVEL))
                    m_AggregationMeans = (int)slaDataAggregationType.hourly;
                else
                    m_AggregationMeans = (int)dataAggregationType.hourly;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to set performance data insertion
        /// </summary>
        /// <param name="pdi">pdi</param>
        /// ------------------------------------------------------------------
        private static void SetPerfDataInsertion(string pdi)
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            m_PerfDataInsertion = Convert.ToBoolean(pdi);

            Utilities.LogMessage(currentMethodName + " :: use data insertion data set to: " +
                m_AggregationMeans.ToString());
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to set time out
        /// </summary>
        /// <param name="to">time out</param>
        /// ------------------------------------------------------------------
        private static void SetTimeOut(string to)
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            if (to != null)
            {
                switch (to.ToUpper())
                {
                    case Constants.NONE:
                        //since can't set int to null and want to be able to test timeout "+
                        //"set to '0' and low negative numbers, as well as higher positive numbers
                        m_TimeOut = Constants.ILLOGICAL_INTEGER;
                        break;
                    case Constants.VALID:
                        m_TimeOut = 120;
                        break;
                    case Constants.NEGATIVE:
                        m_TimeOut = -5;
                        break;
                    case Constants.ZERO:
                        //m_TimeOut = 0; //default
                        break;
                    case Constants.SHORT:
                        m_TimeOut = 1;
                        break;
                    default:
                        //if not one of the expected values, assume value provide was intended as an integer
                        //if the value will not convert, it will throw an exception that will indicate the 
                        //provided string did not support integer conversion.
                        m_TimeOut = Convert.ToInt32(to);
                        break;
                }
            }
            else
            {
                Utilities.LogMessage(currentMethodName + " :: TimeOut not set to a value (was null); " +
                    "not setting, which will use default");
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to get MG Guid
        /// </summary>
        /// <param name="ctx">IContext object</param>
        /// <returns>MG Guid as string</returns>
        /// ------------------------------------------------------------------
        public static Guid GetManagementGroupGuid(IContext ctx)
        {
            Guid mgGuid;
            string mgQuery = "select ManagementGroupGuid from vManagementGroup";

            if (m_DBInstanceName == null)
                SetServerName();
            if (m_DBName == null)
                SetUrlDBName();

            //get connection to DW
            DBUtil.ConnectToMOMDW(m_DBInstanceName, m_DBName);

            mgGuid = (Guid) DBUtil.ExecuteScalarQuery(mgQuery);

            DBUtil.CloseMOMDWConnection();
            return mgGuid;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to set XML input value
        /// </summary>
        /// <param name="ctx">IContext</param>
        /// <returns>xmlInput string</returns>
        /// ------------------------------------------------------------------
        public static string SetXmlInputValue(IContext ctx)
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //setting managedEntityGroup and ruleName based on whether using data inserted into DW " +
            //"manually or naturally occuring data
            string managedEntityGroup = "";
            string ruleName = "";
            if (m_PerfDataInsertion)
            {
                managedEntityGroup = Constants.WINDOWS_SERVER_INSTANCES_GROUP;
                ruleName = Constants.PERCENT_PROCESSOR_COUNTER_NAME;
            }
            else
            {
                managedEntityGroup = Constants.ALL_WINDOWS_COMPUTERS;
                ruleName = Constants.HEALTH_SERVICE_MODULE_COUNTER_NAME;
            }

            string meQuery = "";
            string meRowId = "";
            string ruleQuery = "";
            string ruleGuid = "";
            Guid mgmtGroupGUID;
            string slaQuery = "";
            DataView slaQueryResults = null;
            string xmlInput = "";

            if (m_DBInstanceName == null)
                SetServerName();
            if (m_DBName == null)
                SetUrlDBName();

            //get connection to DW
            DBUtil.ConnectToMOMDW(m_DBInstanceName, m_DBName);
            Utilities.LogMessage(currentMethodName + " :: SQL Connection: " +
                DBUtil.SqlConnection.ConnectionString);

            //performance stored proc
            if (m_SP == Constants.PERFORMANCE_SP)
            {
                meQuery = @"select ManagedEntityRowId from vManagedEntity where DisplayName = '" +
                    managedEntityGroup + "'";
                meRowId = (DBUtil.ExecuteScalarQuery(meQuery)).ToString();
                ruleQuery = @"select RuleGuid from vRule where RuleDefaultName = '" + ruleName + "'";
                ruleGuid = (DBUtil.ExecuteScalarQuery(ruleQuery)).ToString();
                xmlInput = Constants.PERF_XMLINPUT1 +
                    meRowId +
                    Constants.PERF_XMLINPUT2 +
                    ruleGuid +
                    Constants.PERF_XMLINPUT3;
            }
            //availability stored proc
            else if (m_SP == Constants.AVAILABILITY_SP)
            {
                meQuery = @"select ManagedEntityRowId from vManagedEntity where DisplayName = '" +
                    managedEntityGroup + "'";
                meRowId = (DBUtil.ExecuteScalarQuery(meQuery)).ToString();
                xmlInput = Constants.AVAIL_XMLINPUT1 + meRowId + Constants.AVAIL_XMLINPUT2;
            }
            //servicelevel stored proc
            //this will only work if SLA test MP is imported
            else if (m_SP == Constants.SERVICELEVEL_SP1 || m_SP == Constants.SERVICELEVEL_SP2 ||
                m_SP == Constants.SERVICELEVEL_REPORT_SP1 || m_SP == Constants.SERVICELEVEL_REPORT_SP2)
            {
                //for reference
                //mgGuid = "1d1da12e-c680-25bb-262d-2f2525f95e4f";
                //slaGuid = "4756c305-1e4e-0b47-5daf-a56408faf2b5";
                //slaGuid = "e995819e-a6d9-63ff-9a05-aced394a627c";
                
                DBUtil.CloseMOMDWConnection();
                mgmtGroupGUID = GetManagementGroupGuid(ctx);
                DBUtil.ConnectToMOMDW(m_DBInstanceName, m_DBName);

                slaQuery = "select ServiceLevelAgreementGuid from vServiceLevelAgreement";
                slaQueryResults = DBUtil.ExecuteQueryWithResults(slaQuery);

                List<Guid> slaGuids = new List<Guid>();

                if (slaQueryResults != null && slaQueryResults.Count > 0)
                {
                    Utilities.LogMessage(currentMethodName + " :: SLA GUIDs count = " + slaQueryResults.Count);
                    for (int i = 0; i < slaQueryResults.Count; i++)
                    {
                        Guid tmpGuid = new Guid((slaQueryResults[i].Row[0]).ToString());
                        slaGuids.Add(tmpGuid);
                    }
                }
                else
                {
                    throw new VarAbort("slaQueryResults is either null or SLA GUIDs count = 0");
                }

                xmlInput = CreateXml(slaGuids, mgmtGroupGUID);
            }
            else if (m_SP == Constants.COMPUTER_GROUP_SCRIPT)
            {
                string meGroup = Constants.WINDOWS_SERVER_INSTANCES_GROUP;
                meQuery = @"select ManagedEntityRowId from vManagedEntity where DisplayName = '" +
                    meGroup + "'";
                meRowId = (DBUtil.ExecuteScalarQuery(meQuery)).ToString();
                xmlInput = Constants.AVAIL_XMLINPUT1 + meRowId + Constants.AVAIL_XMLINPUT2;
            }

            DBUtil.CloseMOMDWConnection();

            return xmlInput;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to create SLA stored procedure xml input
        /// </summary>
        /// <param name="ServiceLevelId">List(Guid)</param>
        /// <param name="ManagementGroupId">Guid</param>
        /// <returns>StoredProcedureParameterCollection</returns>
        /// ------------------------------------------------------------------
        public static string CreateXml(List<Guid> ServiceLevelId, Guid ManagementGroupId)
        {
            string result = null;

            if (ServiceLevelId.Count > 0)
            {
                using (StringWriter valueWriter = new StringWriter(CultureInfo.InvariantCulture))
                {
                    XmlTextWriter xml = new XmlTextWriter(valueWriter);
                    try
                    {
                        xml.WriteStartElement(RootXName);
                        WriteObjects(xml, ServiceLevelId, ManagementGroupId);
                        xml.WriteEndElement();
                    }
                    finally
                    {
                        xml.Flush();
                        xml.Close();
                    }

                    result = valueWriter.ToString();
                }
            }

            return (result != null) ? result : EmptyXml;
        }

        /// <summary>
        /// Write objects
        /// </summary>
        /// <param name="xml">XmlWriter</param>
        /// <param name="ServiceLevelId">List(Guid)</param>
        /// <param name="ManagementGroupId">Guid</param>
        private static void WriteObjects(XmlWriter xml, List<Guid> ServiceLevelId, Guid ManagementGroupId)
        {
            xml.WriteStartElement(SLAListXName);
            foreach (Guid item in ServiceLevelId)
            {
                if (item != null)
                {
                    WriteItem(xml, item, ManagementGroupId);
                }
            }
            xml.WriteEndElement();
        }

        /// <summary>
        /// Write data item
        /// </summary>
        /// <param name="xml">XmlWriter</param>
        /// <param name="item">Guid - item to write</param>
        /// <param name="ManagementGroupId">Guid</param>
        private static void WriteItem(XmlWriter xml, Guid item, Guid ManagementGroupId)
        {
            if (item != null)
            {
                xml.WriteStartElement(SLAXName);
                xml.WriteAttributeString(ManagementGroupGuidXName, ManagementGroupId.ToString());
                xml.WriteAttributeString(SlaGuidXName, item.ToString());
                xml.WriteEndElement();
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to set parameter values
        /// </summary>
        /// <param name="Params">Params</param>
        /// <param name="xmlInput">xmlInput</param>
        /// <returns>StoredProcedureParameterCollection</returns>
        /// ------------------------------------------------------------------
        private static StoredProcedureParameterCollection SetParameterValues(string Params,
            string xmlInput, IContext ctx)
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            StoredProcedureParameterCollection paramSet = new StoredProcedureParameterCollection();
            StoredProcedureParameter objectList = null;
            StoredProcedureParameter dataAggregation = null;
            StoredProcedureParameter monitorName = null;
            StoredProcedureParameter managementGroupId = null;
            StoredProcedureParameter LangName = null;
            StoredProcedureParameter SLAMERowId = null;
            StoredProcedureParameter SLOGuid = null;

            ParameterTimeInterval interval = new ParameterTimeInterval(DateTime.UtcNow, timeInterval, System.Globalization.CultureInfo.InvariantCulture);

            //Design approach: set values for all cases except NONE
            //then parse individual value to tweak special cases, in order to make param set INVALID,
            //or to skip one param or add an additional one

            //yes, I know this is ugly...
            int slaMERowId = 0;
            Guid sloGuid = new Guid();

            if (m_SP == Constants.SERVICELEVEL_SP3 || m_SP == Constants.SERVICELEVEL_REPORT_SP3)
            {
                //Special case - had to use Params string to pass in 2 additional params
                //parse Params string
                string[] tmpStr = Params.Split('.');
                slaMERowId = Convert.ToInt32(tmpStr[0]);
                sloGuid = new Guid(tmpStr[1]);
                //reset Params string prior to switch statement
                Params = Constants.VALID;
            }

            switch (Params)
            {
                case Constants.NONE:
                    break;
                case Constants.VALID:
                case Constants.ADDITIONAL:

                    //param 1:
                    paramSet.Add("StartDate", interval.StartDate);

                    //param 2:
                    paramSet.Add("EndDate", interval.EndDate);

                    //param 3:
                    //performanceSP
                    if (m_SP == Constants.PERFORMANCE_SP)
                    {
                        objectList = new StoredProcedureParameter(Constants.OPTIONLIST, xmlInput);
                        paramSet.Add(objectList);
                    }
                    //availabilitySP
                    else if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        objectList = new StoredProcedureParameter(Constants.OBJECTLIST, xmlInput);
                        paramSet.Add(objectList);
                    }
                    //servicelevelSP
                    else if (m_SP == Constants.SERVICELEVEL_SP1 || m_SP == Constants.SERVICELEVEL_SP2 ||
                        m_SP == Constants.SERVICELEVEL_REPORT_SP1 || m_SP == Constants.SERVICELEVEL_REPORT_SP2)
                    {
                        objectList = new StoredProcedureParameter(Constants.SLAXML, xmlInput);
                        paramSet.Add(objectList);
                    }
                    else if (m_SP == Constants.SERVICELEVEL_SP3 || m_SP == Constants.SERVICELEVEL_REPORT_SP3)
                    {
                        SLAMERowId = new StoredProcedureParameter(Constants.SLAMEROWID, slaMERowId);
                        paramSet.Add(SLAMERowId);
                    }

                    //param 4:
                    //performanceSP - optional input
                    if (m_SP == Constants.PERFORMANCE_SP)
                    {
                        dataAggregation = new StoredProcedureParameter(Constants.DATAAGGREGATION, m_AggregationMeans);
                        paramSet.Add(dataAggregation);
                    }
                    //availabilitySP
                    else if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        monitorName = new StoredProcedureParameter(Constants.MONITORNAME, Constants.MONNAME);
                        paramSet.Add(monitorName);
                    }
                    //servicelevelSP
                    else if (m_SP == Constants.SERVICELEVEL_SP1 || m_SP == Constants.SERVICELEVEL_REPORT_SP2)
                    {
                        dataAggregation = new StoredProcedureParameter(Constants.AGGREGATIONTYPEID, m_AggregationMeans);
                        paramSet.Add(dataAggregation);
                    }
                    else if (m_SP == Constants.SERVICELEVEL_SP2)
                    {
                        managementGroupId = new StoredProcedureParameter(Constants.MANAGEMENTGROUPID, GetManagementGroupGuid(ctx));
                        paramSet.Add(managementGroupId);
                    }
                    else if (m_SP == Constants.SERVICELEVEL_REPORT_SP1)
                    {
                        LangName = new StoredProcedureParameter(Constants.LANGUAGECODE, Constants.LANG);
                        paramSet.Add(LangName);
                    }
                    else if (m_SP == Constants.SERVICELEVEL_SP3 || m_SP == Constants.SERVICELEVEL_REPORT_SP3)
                    {
                        SLOGuid = new StoredProcedureParameter(Constants.SLOGUID, sloGuid);
                        paramSet.Add(SLOGuid);
                    }

                    //param 5:
                    //performanceSP - optional input
                    if (m_SP == Constants.PERFORMANCE_SP)
                    {
                        LangName = new StoredProcedureParameter(Constants.LANGUAGECODE, Constants.LANG);
                        paramSet.Add(LangName);
                    }
                    //availabilitySP - optional input
                    else if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        dataAggregation = new StoredProcedureParameter(Constants.DATAAGGREGATION, m_AggregationMeans);
                        paramSet.Add(dataAggregation);
                    }
                    else if (m_SP == Constants.SERVICELEVEL_SP3 || m_SP == Constants.SERVICELEVEL_REPORT_SP3)
                    {
                        dataAggregation = new StoredProcedureParameter(Constants.AGGREGATIONTYPEID, m_AggregationMeans);
                        paramSet.Add(dataAggregation);
                    }

                    //param 6:
                    //availabilitySP - optional input
                    if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        LangName = new StoredProcedureParameter(Constants.LANGUAGECODE, Constants.LANG);
                        paramSet.Add(LangName);
                    }
                    else if (m_SP == Constants.SERVICELEVEL_REPORT_SP3)
                    {
                        LangName = new StoredProcedureParameter(Constants.LANGUAGECODE, Constants.LANG);
                        paramSet.Add(LangName);
                    }
                    break;
                //TODO: problem here is we don't know how many/what params were already added...
                //for now, just need to accept doing it the long way
                case Constants.INVALID:

                    //can vary setting these values incorrectly to represent invalid param input

                    //these are the valid values
                    //xmlInput = "<Data><Objects><Object Use=" + "\"" + "Containment" + "\">13</Object></Objects></Data>";
                    //monName = "System.Health.AvailabilityState";
                    //lang = "ENU";
                    //aggregationType = 0;

                    //invalid entries
                    string invalidXmlInput = "<Data><Objects><Object Use=" +
                        "\"" + "Concentration" +
                        "\">13</Object></Objects></Data>";
                    string monName = "System.Health.Performance";
                    string lang = "JAP";
                    int aggregationType = 4;

                    //param 1:
                    paramSet.Add("StartDate", interval.StartDate);

                    //param 2:
                    paramSet.Add("EndDate", interval.EndDate);

                    //param 3:
                    //performanceSP
                    if (m_SP == Constants.PERFORMANCE_SP)
                    {
                        objectList = new StoredProcedureParameter(Constants.OPTIONLIST, invalidXmlInput);
                        paramSet.Add(objectList);
                    }
                    //availabilitySP
                    else if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        objectList = new StoredProcedureParameter(Constants.OBJECTLIST, invalidXmlInput);
                        paramSet.Add(objectList);
                    }
                    //servicelevelSP
                    else if (m_SP == Constants.SERVICELEVEL_SP1 || m_SP == Constants.SERVICELEVEL_SP2)
                    {
                        objectList = new StoredProcedureParameter(Constants.SLAXML, invalidXmlInput);
                        paramSet.Add(objectList);
                    }

                    //param 4:
                    //performanceSP - optional input
                    if (m_SP == Constants.PERFORMANCE_SP)
                    {
                        dataAggregation = new StoredProcedureParameter(Constants.DATAAGGREGATION,
                            aggregationType);
                        paramSet.Add(dataAggregation);
                    }
                    //availabilitySP
                    else if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        monitorName = new StoredProcedureParameter(Constants.MONITORNAME, monName);
                        paramSet.Add(monitorName);
                    }
                    //servicelevelSP
                    else if (m_SP == Constants.SERVICELEVEL_SP1)
                    {
                        dataAggregation = new StoredProcedureParameter(Constants.AGGREGATIONTYPEID,
                            m_AggregationMeans);
                        paramSet.Add(dataAggregation);
                    }
                    else if (m_SP == Constants.SERVICELEVEL_SP2)
                    {
                        LangName = new StoredProcedureParameter(Constants.LANGUAGECODE, Constants.LANG);
                        paramSet.Add(LangName);
                    }

                    //param 5:
                    //performanceSP - optional input
                    if (m_SP == Constants.PERFORMANCE_SP)
                    {
                        LangName = new StoredProcedureParameter(Constants.LANGUAGECODE, lang);
                        paramSet.Add(LangName);
                    }
                    //availabilitySP - optional input
                    else if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        dataAggregation = new StoredProcedureParameter(Constants.DATAAGGREGATION,
                            aggregationType);
                        paramSet.Add(dataAggregation);
                    }

                    //param 6:
                    //availabilitySP - optional input
                    if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        LangName = new StoredProcedureParameter(Constants.LANGUAGECODE, lang);
                        paramSet.Add(LangName);
                    }
                    break;
                case Constants.OMITTED:

                    //skip adding 3rd param (xmlInput) to represent an omitted param - could choose others
                    //although it must be a required param

                    //param 1:
                    paramSet.Add("StartDate", interval.StartDate);

                    //param 2:
                    paramSet.Add("EndDate", interval.EndDate);

                    //param 3:
                    //performanceSP
                    if (m_SP == Constants.PERFORMANCE_SP)
                    {
                        objectList = new StoredProcedureParameter(Constants.OPTIONLIST, xmlInput);
                        //paramSet.Add(objectList);
                    }
                    //availabilitySP
                    else if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        objectList = new StoredProcedureParameter(Constants.OBJECTLIST, xmlInput);
                        //paramSet.Add(objectList);
                    }
                    //servicelevelSP
                    else if (m_SP == Constants.SERVICELEVEL_SP1 || m_SP == Constants.SERVICELEVEL_SP2)
                    {
                        objectList = new StoredProcedureParameter(Constants.SLAXML, xmlInput);
                        //paramSet.Add(objectList);
                    }

                    //param 4:
                    //performanceSP - optional input
                    if (m_SP == Constants.PERFORMANCE_SP)
                    {
                        dataAggregation = new StoredProcedureParameter(Constants.DATAAGGREGATION,
                            m_AggregationMeans);
                        paramSet.Add(dataAggregation);
                    }
                    //availabilitySP
                    else if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        monitorName = new StoredProcedureParameter(Constants.MONITORNAME, Constants.MONNAME);
                        paramSet.Add(monitorName);
                    }
                    //servicelevelSP
                    else if (m_SP == Constants.SERVICELEVEL_SP1)
                    {
                        dataAggregation = new StoredProcedureParameter(Constants.AGGREGATIONTYPEID,
                            m_AggregationMeans);
                        paramSet.Add(dataAggregation);
                    }
                    else if (m_SP == Constants.SERVICELEVEL_SP2)
                    {
                        LangName = new StoredProcedureParameter(Constants.LANGUAGECODE, Constants.LANG);
                        paramSet.Add(LangName);
                    }

                    //param 5:
                    //performanceSP - optional input
                    if (m_SP == Constants.PERFORMANCE_SP)
                    {
                        LangName = new StoredProcedureParameter(Constants.LANGUAGECODE, Constants.LANG);
                        paramSet.Add(LangName);
                    }
                    //availabilitySP - optional input
                    else if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        dataAggregation = new StoredProcedureParameter(Constants.DATAAGGREGATION,
                            m_AggregationMeans);
                        paramSet.Add(dataAggregation);
                    }

                    //param 6:
                    //availabilitySP - optional input
                    if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        LangName = new StoredProcedureParameter(Constants.LANGUAGECODE, Constants.LANG);
                        paramSet.Add(LangName);
                    }
                    break;
                case Constants.INVALIDTYPES:

                    //param 1:
                    paramSet.Add("StartDate", interval.StartDate);

                    //param 2:
                    paramSet.Add("EndDate", interval.EndDate);

                    //param 3:
                    //performanceSP
                    if (m_SP == Constants.PERFORMANCE_SP)
                    {
                        objectList = new StoredProcedureParameter(Constants.OPTIONLIST, m_AggregationMeans);
                        paramSet.Add(objectList);
                    }
                    //availabilitySP
                    else if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        objectList = new StoredProcedureParameter(Constants.OBJECTLIST, m_AggregationMeans);
                        paramSet.Add(objectList);
                    }
                    //servicelevelSP
                    else if (m_SP == Constants.SERVICELEVEL_SP1 || m_SP == Constants.SERVICELEVEL_SP2)
                    {
                        objectList = new StoredProcedureParameter(Constants.SLAXML, m_AggregationMeans);
                        paramSet.Add(objectList);
                    }

                    //param 4:
                    //performanceSP - optional input
                    if (m_SP == Constants.PERFORMANCE_SP)
                    {
                        dataAggregation = new StoredProcedureParameter(Constants.DATAAGGREGATION,
                            m_AggregationMeans.ToString());
                        paramSet.Add(dataAggregation);
                    }
                    //availabilitySP
                    else if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        monitorName = new StoredProcedureParameter(Constants.MONITORNAME, m_AggregationMeans);
                        paramSet.Add(monitorName);
                    }
                    //servicelevelSP
                    else if (m_SP == Constants.SERVICELEVEL_SP1)
                    {
                        dataAggregation = new StoredProcedureParameter(Constants.AGGREGATIONTYPEID,
                            m_AggregationMeans);
                        paramSet.Add(dataAggregation);
                    }
                    else if (m_SP == Constants.SERVICELEVEL_SP2)
                    {
                        LangName = new StoredProcedureParameter(Constants.LANGUAGECODE, Constants.LANG);
                        paramSet.Add(LangName);
                    }

                    //param 5:
                    //performanceSP - optional input
                    if (m_SP == Constants.PERFORMANCE_SP)
                    {
                        LangName = new StoredProcedureParameter(Constants.LANGUAGECODE, Constants.LANG);
                        paramSet.Add(LangName);
                    }
                    //availabilitySP - optional input
                    else if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        dataAggregation = new StoredProcedureParameter(Constants.DATAAGGREGATION,
                            m_AggregationMeans.ToString());
                        paramSet.Add(dataAggregation);
                    }

                    //param 6:
                    //availabilitySP - optional input
                    if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        LangName = new StoredProcedureParameter(Constants.LANGUAGECODE, Constants.LANG);
                        paramSet.Add(LangName);
                    }
                    break;
                default:
                    throw new ArgumentException(currentMethodName + ": value for SPParameters was of unknown type: " +
                        Params);
            }
            switch (Params)
            {
                case Constants.ADDITIONAL:
                    //extra param: (for now, using repeat of valid param type already specified

                    //TODO: could also specify a completely different param - may see different behavior

                    //performanceSP
                    if (m_SP == Constants.PERFORMANCE_SP)
                    {
                        StoredProcedureParameter extraParam =
                            new StoredProcedureParameter(Constants.DATAAGGREGATION, m_AggregationMeans);
                        paramSet.Add(extraParam);
                    }
                    //availabilitySP
                    else if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        StoredProcedureParameter extraParam =
                            new StoredProcedureParameter(Constants.MONITORNAME, Constants.MONNAME);
                        paramSet.Add(extraParam);
                    }
                    //servicelevelSP
                    else if (m_SP == Constants.SERVICELEVEL_SP1 || m_SP == Constants.SERVICELEVEL_SP2)
                    {
                        StoredProcedureParameter extraParam =
                            new StoredProcedureParameter(Constants.AGGREGATIONTYPEID, m_AggregationMeans);
                        paramSet.Add(extraParam);
                    }
                    break;
                case Constants.VALID:
                case Constants.INVALID:
                case Constants.OMITTED:
                case Constants.INVALIDTYPES:
                case Constants.NONE:
                    break;
                default:
                    throw new ArgumentException(currentMethodName + ": illogical - " +
                        "shouldn't be able to get here (exception should've been thrown in previous switch)");
            }

            return paramSet;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to set Direct SP call parameters
        /// </summary>
        /// <param name="Params">Params</param>
        /// <param name="xmlInput">xmlInput</param>
        /// <param name="spCmd">spCmd</param>
        /// ------------------------------------------------------------------
        private static void SetDirectSPCallParameters(string Params, string xmlInput, ref SqlCommand spCmd)
        {
            string currentMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            switch (Params)
            {
                case Constants.VALID:

                    //param 1:
                    spCmd.Parameters.Add("@" + Constants.STARTDATE, SqlDbType.DateTime).Value = m_StartTime.ToString("F");

                    //param 2:
                    spCmd.Parameters.Add("@" + Constants.ENDDATE, SqlDbType.DateTime).Value = m_EndTime.ToString("F");

                    //param 3:
                    //performanceSP
                    if (m_SP == Constants.PERFORMANCE_SP)
                    {
                        spCmd.Parameters.Add("@" + Constants.OPTIONLIST, SqlDbType.NVarChar, 190).Value = xmlInput;
                    }
                    //availabilitySP
                    else if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        spCmd.Parameters.Add("@" + Constants.OBJECTLIST, SqlDbType.NVarChar, 190).Value = xmlInput;
                    }
                    //servicelevelSP
                    else if (m_SP == Constants.SERVICELEVEL_SP1 || m_SP == Constants.SERVICELEVEL_SP2)
                    {
                        spCmd.Parameters.Add("@" + Constants.SLAXML, SqlDbType.NVarChar, 190).Value = xmlInput;
                    }

                    //param 4:
                    //performanceSP - optional input
                    if (m_SP == Constants.PERFORMANCE_SP)
                    {
                        spCmd.Parameters.Add("@" + Constants.DATAAGGREGATION, SqlDbType.Int).Value = m_AggregationMeans;
                    }
                    //availabilitySP
                    else if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        spCmd.Parameters.Add("@" + Constants.MONITORNAME, SqlDbType.NVarChar, 31).Value = Constants.MONNAME;
                    }
                    //servicelevelSP
                    else if (m_SP == Constants.SERVICELEVEL_SP1)
                    {
                        spCmd.Parameters.Add("@" + Constants.AGGREGATIONTYPEID, SqlDbType.Int).Value = m_AggregationMeans;
                    }
                    else if (m_SP == Constants.SERVICELEVEL_SP2)
                    {
                        spCmd.Parameters.Add("@" + Constants.LANGUAGECODE, SqlDbType.NVarChar, 3).Value = Constants.LANG;
                    }

                    //param 5:
                    //performanceSP - optional input
                    if (m_SP == Constants.PERFORMANCE_SP)
                    {
                        spCmd.Parameters.Add("@" + Constants.LANGUAGECODE, SqlDbType.NVarChar, 3).Value = Constants.LANG;
                    }
                    //availabilitySP - optional input
                    else if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        spCmd.Parameters.Add("@" + Constants.DATAAGGREGATION, SqlDbType.Int).Value = m_AggregationMeans;
                    }

                    //param 6:
                    //availabilitySP - optional input
                    if (m_SP == Constants.AVAILABILITY_SP)
                    {
                        spCmd.Parameters.Add("@" + Constants.LANGUAGECODE, SqlDbType.NVarChar, 3).Value = Constants.LANG;
                    }
                    break;
                default:
                    throw new VarAbort(currentMethodName + ": Invalid value for spParameters varmap entry: " +
                        Params);
            }
        }

        #endregion

        #endregion

        #region FQDN support methods

        /// ------------------------------------------------------------------
        /// <summary>
        /// Verify if the Registry key passed by regKeyPath exists under the root
        /// registry path passed by RegistryHive parameters
        /// </summary>
        /// <param name="hive">The root node of Registry where we found</param>
        /// <param name="regKeyPath">The Registry Key path need to be verified</param>
        /// <returns>If the Registry key exist</returns>
        /// <history> [v-kayu] 06JAN10 Created</history>
        ///  -----------------------------------------------------------------
        public static bool RegistryKeyExist(RegistryHive hive, string regKeyPath)
        {
            Common.Utilities.LogMessage("Common.Utilities.RegistryKeyExist...");
            bool exist = false;

            try
            {
                Microsoft.Win32.RegistryKey root = null;
                switch (hive)
                {
                    case RegistryHive.Win32ClassesRoot:
                        root = Microsoft.Win32.Registry.ClassesRoot;
                        break;

                    case RegistryHive.Win32CurrentConfig:
                        root = Microsoft.Win32.Registry.CurrentConfig;
                        break;

                    case RegistryHive.Win32CurrentUser:
                        root = Microsoft.Win32.Registry.CurrentUser;
                        break;

                    case RegistryHive.Win32LocalMachine:
                        root = Microsoft.Win32.Registry.LocalMachine;
                        break;

                    case RegistryHive.Win32PerformanceData:
                        root = Microsoft.Win32.Registry.PerformanceData;
                        break;

                    case RegistryHive.Win32Users:
                        root = Microsoft.Win32.Registry.Users;
                        break;
                }
                if (null != root.OpenSubKey(regKeyPath, true))
                {
                    Utilities.LogMessage("Common.Utilities.RegistryKeyExist:: Find RegKeyPath: " + regKeyPath);
                    exist = true;
                }
                else
                {
                    Utilities.LogMessage("Common.Utilities.RegistryKeyExist:: Couldn't find RegKeyPath: " + regKeyPath);
                }
            }
            catch (System.Security.SecurityException)
            {
                Utilities.LogMessage("Common.Utilities.RegistryKeyExist:: Couldn't access RegKeyPath: " + regKeyPath);
            }

            return exist;
        }

        /// <summary>
        /// Get the FQDN of server name where Dns suffix got from local Registry in Disjoint Namespace
        /// or local domain Name in normal environment.
        /// </summary>
        /// <param name="serverName">Server Name</param>
        /// <returns>FQDN of specified server name</returns>
        public static string GetServerNameFqdn(string serverName)
        {
            Core.Common.Utilities.LogMessage("Common.Utilities.GetFqdn...");

            if (string.IsNullOrEmpty(serverName))
            {
                Core.Common.Utilities.LogMessage("Commom.Utilities.GetFqdn:: Invalid Parameter.");
                throw new ArgumentNullException("Common.Utilities.GetFqdn::The parameter is Null or Empty.");
            }

            string serverNameFqdn = null;
            string dnsSuffix = null;

            //Check for FQDN
            if (Common.Utilities.RegistryKeyExist(RegistryHive.Win32LocalMachine, @"SOFTWARE\Policies\Microsoft\System\DNSClient"))
            {
                Core.Common.Utilities.LogMessage("Common.Utilities.GetFqdn:: Get DNS suffix from Registry in Disjoint Namespace.");
                dnsSuffix = Registry.GetValue(RegistryHive.Win32LocalMachine, @"SOFTWARE\Policies\Microsoft\System\DNSClient", "PrimaryDnsSuffix");

                //If there is no registry value "PrimaryDnsSuffix", then use DNSDomain instead
                if (String.IsNullOrEmpty(dnsSuffix))
                {
                    Core.Common.Utilities.LogMessage("Common.Utilities.GetFqdn:: NO Registry value PrimaryDnsSuffix, will get DNS suffixe from Domain name.");
                    dnsSuffix = System.Environment.ExpandEnvironmentVariables("%userdnsdomain%");
                }
            }
            else
            {
                Core.Common.Utilities.LogMessage("Common.Utilities.GetFqdn:: Get DNS suffixe from Domain name.");
                dnsSuffix = System.Environment.ExpandEnvironmentVariables("%userdnsdomain%");
            }

            if (false == serverName.Contains("."))
            {
                serverNameFqdn =
                    serverName +
                    "." +
                    dnsSuffix;
            }
            else
            {
                string[] splitedName = serverName.Split('.');
                serverNameFqdn =
                    splitedName[0] +
                    "." +
                    dnsSuffix;
            }


            return serverNameFqdn;
        }

        #endregion

        /// <summary>
        /// Creates a Favorite View of any existing View instance in Monitoring.
        /// </summary>
        /// <param name="favoriteViewName">Favorite View Name</param>
        /// <param name="destinationViewId">Actual View (Destination) Id</param>
        public static void CreateFavoriteView(string favoriteViewName, Guid destinationViewId)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string logMessageBase = currentMethod + " :: ";
            Utilities.LogMessage(logMessageBase);

            ManagementGroup mg = ConnectToManagementServer();
            ManagementPackView view = mg.Presentation.GetView(destinationViewId);
            ManagementPack mp = mg.ManagementPacks.GetManagementPack(ManagementPackConstants.MicrosoftWindowsClientLibraryMPName, MomBuildConstants.MomManagementPackPublicKeyToken, new Version());
            ManagementPackClass targetTypeClass = mg.EntityTypes.GetClass(ManagementPackConstants.WindowClientInstanceGroupName, mp);

            // Create a UserView instance.
            // 
            // The monitoringObjectId (objectId param in UserView constructor) is hard-coded to 
            // Microsoft.Windows.Client.InstanceGroup.Id as all favorite views that get created
            // through the UI use this monitoringObjectId. I'm not exactly sure why this is, but
            // we can always modify this method to take the monitoringObjectId and monitoringObjectMP
            // as additional parameters if needed.
            Microsoft.EnterpriseManagement.UserInfo.UserView favoriteView = new Microsoft.EnterpriseManagement.UserInfo.UserView(favoriteViewName, view, targetTypeClass.Id);
            mg.UserSettings.InsertUserView(favoriteView);

            LogMessage(String.Format("{0} Created FavoriteView '{1}'", logMessageBase, favoriteView.Name));
        }

        /// <summary>
        /// Creates a Favorite View of any existing View instance in Monitoring.
        /// </summary>
        /// <param name="favoriteViewName">Favorite View Name</param>
        public static void DeleteFavoriteView(string favoriteViewName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string logMessageBase = currentMethod + " :: ";
            ManagementGroup mg = ConnectToManagementServer();

            Utilities.LogMessage(logMessageBase);

            if (mg.UserSettings.GetUserView(favoriteViewName) != null)
            {
                mg.UserSettings.DeleteUserView(favoriteViewName);
                LogMessage(String.Format("{0} Deleted FavoriteView '{1}'", logMessageBase, favoriteViewName));
            }
            else
            {
                LogMessage(String.Format("{0} FavoriteView '{1}' doesn't exist, therefore no delete was performed.", logMessageBase, favoriteViewName));
            }
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return a list of all class Guids given the Class name
        /// 
        /// </summary>
        /// <param name="targetClassName">a class name corresponding in MG
        ///  </param>
        /// <returns>List ManagementPackClass Names</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [Sunsingh]  - Created        
        /// </history>
        /// ------------------------------------------------------------------
        public static Guid GetManagementClassGuid(string targetClassName)
        {

            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string logMessageBase = currentMethod + " :: ";
            try
            {
                IList<ManagementPackClass> mpClass;
                using (ManagementGroup mg = ConnectToManagementServer())
                {
                    if (mg == null)
                    {
                        LogMessage("failed to get  Management Group Connection");
                        return Guid.Empty;
                    }
                    var mPc = new ManagementPackClassCriteria("[Name] like '" + targetClassName + "'");
                    mpClass = mg.EntityTypes.GetClasses(mPc);
                    int retry = 5;
                    while ((mpClass.Count <= 0)&&(retry>0))
                    {
                        mpClass = mg.EntityTypes.GetClasses(mPc);
                        Sleeper.Delay(Constants.OneSecond);
                        retry--;
                    }
                }

                if (mpClass.Count > 0)
                {
                LogMessage(string.Format(logMessageBase + "returned Guid for the TypeClass: {0}", targetClassName));
                return (mpClass[0].Id);
                }
                LogMessage(string.Format(logMessageBase + "failed to get  Guid for the TypeClass: {0}", targetClassName));
                return Guid.Empty;
            }
            catch (Exception e)
            {
                
                throw new Exception("Failed to return guid for type Class",e);
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Used to return a list of all view Guids given the view name
        /// 
        /// </summary>
        /// <param name="viewName">a view name corresponding in MG
        ///  </param>
        /// <returns>List ManagementPackClass Names</returns>
        /// <exception cref="Microsoft.EnterpriseManagement.Common.ObjectNotFoundException">ObjectNotFoundException</exception>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        /// <history>
        ///     [Sunsingh]  - Created        
        /// </history>
        /// ------------------------------------------------------------------
        /// 

        public static Guid GetManagementViewGuid(string viewName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string logMessageBase = currentMethod + " :: ";
            try
            {
                IList<ManagementPackView> mpView;
                using (ManagementGroup mg = ConnectToManagementServer())
                {
                    var mPc = new ManagementPackViewCriteria("[Name] like '" + viewName + "'");
                    if (mg == null)
                    {
                        LogMessage("failed to get  Management Group Connection");
                        return Guid.Empty;
                    }
                    mpView = mg.Presentation.GetViews(mPc);
                }
                if (mpView.Count > 0)
            {
                LogMessage(string.Format(logMessageBase + "returned Guid for the view: {0}", viewName));
                return (mpView[0].Id);
            }
                LogMessage(string.Format(logMessageBase + "failed to get  Guid for the view: {0}", viewName));
                return Guid.Empty;
            }
            catch (Exception e)
            {
                
                throw new Exception("Failed to return guid for view Class",e);
            }


        }

        /// <summary>
        /// Returns the Task ID for The given Task NAme
        /// </summary>
        /// <param name="taskName"></param>
        /// <returns>guid</returns>
        public static Guid GetManagementTaskguid(string taskName)
        {

            string currentMethod = MethodBase.GetCurrentMethod().Name;
            string logMessageBase = currentMethod + " :: ";
           try
           {
               IList<ManagementPackTask> mpTask;
               using (ManagementGroup mg = ConnectToManagementServer())
               {
                   var mPc = new ManagementPackTaskCriteria("[Name] like '" + taskName + "'");
                   if (mg == null)
                   {
                       LogMessage("failed to get  Management Group Connection");
                       return Guid.Empty;
                   }
                   mpTask = mg.TaskConfiguration.GetTasks(mPc);
               }
               if (mpTask.Count > 0)
                {
                LogMessage(string.Format(logMessageBase + "returned Guid for the Task: {0}", taskName));
                return mpTask[0].Id;
                }

            LogMessage(string.Format(logMessageBase + "failed to get  Guid for the Dashboard: {0}", taskName));
                return Guid.Empty;
            }
            catch (Exception e)
            {
                
                throw new Exception("Failed to return guid for Task Class",e);
            }

        }

        /// <summary>
        /// Returns the Group id for the given Group Name
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns>Group Guid</returns>
        public static Guid GetManagementGroupObjectGuid(string groupName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string logMessageBase = currentMethod + " :: ";
            try
            {
            
            ManagementGroup mg = ConnectToManagementServer();
            Guid managementPackClassguid = GetManagementClassGuid(groupName);

            if (managementPackClassguid != Guid.Empty)
            {
                var groupType = mg.EntityTypes.GetClass(managementPackClassguid);
                if (groupType != null)
                {
                    var mPc = new Microsoft.EnterpriseManagement.Monitoring.MonitoringObjectCriteria(
                        "[FullName] like '" + groupName + "'", groupType);
                    // var mpGroup = mg.EntityObjects.GetObject<Microsoft.EnterpriseManagement.Monitoring.MonitoringObject>(mPc, ObjectQueryOptions.Default);
                    var mpGroup = mg.EntityObjects.GetObjects(mPc, ObjectQueryOptions.Default);
                    if (mpGroup.Count > 0)
                    {
                        LogMessage(string.Format(logMessageBase + "returned Group object id for group name: {0}",
                                                 groupName));
                        return mpGroup[0].Id;
                    }
                }
              }
                LogMessage(string.Format(logMessageBase + "failed to get  Guid for the group: {0}", groupName));
                return Guid.Empty;
            }
            catch (Exception e)
            {
                
                throw new Exception("Failed to return guid for Group Class",e);
            }
        }

        /// <summary>
        /// Returns the Dashbard Guid For a dashboard Name
        /// </summary>
        /// <param name="dashboardName"></param>
        /// <returns>Dashboard Refrence Guid</returns>
        public static Guid GetManagementDashboards(string dashboardName)
        {
            if (dashboardName == null) throw new ArgumentNullException("dashboardName");

            string currentMethod = MethodBase.GetCurrentMethod().Name;
            string logMessageBase = currentMethod + " :: ";
            try
            {
                using (ManagementGroup mg = ConnectToManagementServer())
                {
                    var mPc = new ManagementPackComponentReferenceCriteria("[Name] like '" + dashboardName + "'");
                    if (mg == null)
                    {
                        LogMessage("failed to get  Management Group Connection");
                        return Guid.Empty;
                    }
                    var mpView = mg.Dashboard.GetScopedDashboardComponentReferences(mPc);
                    if (mpView.Count > 0)
                    {
                        LogMessage(string.Format(logMessageBase + "returned Guid for the Dashboard: {0}",
                                                 dashboardName));
                        return mpView[0].Id;
                    }
                }
                LogMessage(string.Format( logMessageBase + "failed to get  Guid for the Dashboard: {0}",dashboardName ));
                return Guid.Empty;
            }
            catch (Exception e)
            {
                
                throw new Exception("failed to get  Guid for the Dashboard",e);
            }
           
        }
        
        /// <summary>
        /// Creates a new custom User Role with scope.
        /// </summary>
        /// <param name="name">User Role Name</param>
        /// <param name="description">User Role Description</param>
        /// <param name="profilename">Profile Id used to clone profile</param>
        /// <param name="userroleParams"></param>
        /// <returns>Microsoft.EnterpriseManagement.Security.UserRole</returns>
        public static  UserRole CreateUserRoleWithScope(string name, string description, string profilename, UserroleScopeParameters userroleParams)
        {
            var newUserRole = new UserRole();
            try
            {
                Guid profileid;
                switch (profilename)
            {
                case "ReadOnlyOperator":
                    profileid = SDK.Monitoring.Security.MonitoringProfile.ReadOnlyOperatorMonitoringProfileId;
                    newUserRole = CreateUserRole(name, description, profileid);
                    if (newUserRole != null)
                    {
                        LogMessage(string.Format("created new userrole {0}", newUserRole.Name));
                        //Scope the groups
                        if (userroleParams.ScopedGroups == null)
                        {
                            newUserRole.Scope.Objects.Add(
                                Microsoft.EnterpriseManagement.Monitoring.Security.MonitoringUserRoleScope.
                                    RootMonitoringObjectId);
                            LogMessage(string.Format("Added all groups scope for userrole {0}", newUserRole.Name));
                        }
                        else
                            foreach (var group in userroleParams.ScopedGroups)
                            {
                                newUserRole.Scope.Objects.Add(GetManagementGroupObjectGuid(group));
                                LogMessage(string.Format("Added scoped group {0}", group));
                            }
                        // scope the views
                        if ((userroleParams.ScopedViews == null) && (userroleParams.ScopedDashboards == null))
                        {
                            newUserRole.Scope.Views.Add((new Pair<Guid, bool>(Microsoft.EnterpriseManagement.Monitoring.Security.MonitoringUserRoleScope.RootMonitoringViewId, false)));
                            newUserRole.Scope.DashboardReferences.Add(UserRoleScope.RootDashboardReferenceId);
                            LogMessage(string.Format("Added all View and dashboard scope for user role {0}", newUserRole.Name));
                        }
                        else if (userroleParams.ScopedViews != null)
                            foreach (var userroleview in userroleParams.ScopedViews)
                            {
                                newUserRole.Scope.Views.Add(new SDK.Common.Pair<Guid, bool>(GetManagementViewGuid(userroleview), false));
                                LogMessage(string.Format("Added given scoped view {0} ", userroleview));
                            }

                        if (userroleParams.ScopedDashboards != null)
                            foreach (var userroledashboard in userroleParams.ScopedDashboards)
                            {
                                newUserRole.Scope.DashboardReferences.Add(GetManagementDashboards(userroledashboard));
                                LogMessage(string.Format("Added given scoped dashboard  {0}", userroledashboard));
                            }

                        if (userroleParams.AuxNavDashbaords != null)
                            foreach (var auxuserroledashboard in userroleParams.AuxNavDashbaords)
                            {
                                newUserRole.Scope.DashboardReferences.Add(GetManagementDashboards(auxuserroledashboard));
                                LogMessage(string.Format("Added given scoped auxuserroledashboard  {0}", auxuserroledashboard));
                            }
                    }
                        break;
                    
                case "Operator":
                    profileid = SDK.Monitoring.Security.MonitoringProfile.OperatorMonitoringProfileId;
                    newUserRole = CreateUserRole(name, description, profileid);
                    if (newUserRole != null)
                    {
                        LogMessage(string.Format("created new userrole {0}", newUserRole.Name));
                        //Scope the groups
                        if (userroleParams.ScopedGroups == null)
                        {
                            newUserRole.Scope.Objects.Add(
                                Microsoft.EnterpriseManagement.Monitoring.Security.MonitoringUserRoleScope.
                                    RootMonitoringObjectId);
                            LogMessage(string.Format("Added all groups scope for userrole {0}", newUserRole.Name));
                        }
                        else
                            foreach (var group in userroleParams.ScopedGroups)
                            {
                                newUserRole.Scope.Objects.Add(GetManagementGroupObjectGuid(group));
                                LogMessage(string.Format("Added scoped group {0}", group));
                            }
                        //ScopeTask
                        if (userroleParams.UserRoleScopedTask == null)
                        {
                        newUserRole.Scope.NonCredentialTasks.Add(new SDK.Common.Pair<Guid, bool>(Microsoft.EnterpriseManagement.Monitoring.Security.MonitoringUserRoleScope.RootNonCredentialMonitoringTaskId, false));
                        LogMessage(string.Format("Added all task scope for userrole {0}", newUserRole.Name));
                        }
                        else
                            foreach (var task in userroleParams.UserRoleScopedTask)
                            {
                                newUserRole.Scope.Views.Add(new SDK.Common.Pair<Guid, bool>(GetManagementTaskguid(task), false));
                                LogMessage(string.Format("Added scoped Task {0}", task));
                            }
                        
                        // scope the views
                        if ((userroleParams.ScopedViews == null) && (userroleParams.ScopedDashboards == null))
                        {
                            newUserRole.Scope.Views.Add((new Pair<Guid, bool>(Microsoft.EnterpriseManagement.Monitoring.Security.MonitoringUserRoleScope.RootMonitoringViewId, false)));
                            newUserRole.Scope.DashboardReferences.Add(UserRoleScope.RootDashboardReferenceId);
                            LogMessage(string.Format("Added all View and dashboard scope for user role {0}", newUserRole.Name));
                        }
                        else if (userroleParams.ScopedViews != null)
                            foreach (var userroleview in userroleParams.ScopedViews)
                            {
                                newUserRole.Scope.Views.Add(new SDK.Common.Pair<Guid, bool>(GetManagementViewGuid(userroleview), false));
                                LogMessage(string.Format("Added given scoped view {0} ", userroleview));
                            }

                        if (userroleParams.ScopedDashboards != null)
                            foreach (var userroledashboard in userroleParams.ScopedDashboards)
                            {
                                newUserRole.Scope.DashboardReferences.Add(GetManagementDashboards(userroledashboard));
                                LogMessage(string.Format("Added given scoped dashboard  {0}", userroledashboard));
                            }

                        if (userroleParams.AuxNavDashbaords != null)
                            foreach (var auxuserroledashboard in userroleParams.AuxNavDashbaords)
                            {
                                newUserRole.Scope.DashboardReferences.Add(GetManagementDashboards(auxuserroledashboard));
                                LogMessage(string.Format("Added given scoped auxuserroledashboard  {0}", auxuserroledashboard));
                            }
                    }
                    break;

                case "Author": // to do more logic for author Make sure All target is not selected and there is some target for specific view selection
                    profileid = SDK.Monitoring.Security.MonitoringProfile.AuthorMonitoringProfileId;
                    newUserRole = CreateUserRole(name, description, profileid);
                    if (newUserRole != null)
                    {
                        LogMessage(string.Format("created new userrole {0}", newUserRole.Name));
                        //Scope the Targets
                        if (userroleParams.ScopedTargets == null)//behaves like out of the box
                        {
                            newUserRole.Scope.Classes.Add((Microsoft.EnterpriseManagement.Monitoring.Security.MonitoringUserRoleScope.RootMonitoringClassId));
                            LogMessage(string.Format("Author User Role implicitly gets scoped to all object with empty Scoped Target Parameter  {0}", newUserRole.Name));
                        }
                        else
                        {
                            // scope the classes this will automatically scope all groups and views no need to do anything
                            // newUserRole.Scope.Classes.Add(GetManagementClassGuid(userroleParams.ScopedTargets,mg); // and rest will be scoped by it self

                            foreach (var userroleclass in userroleParams.ScopedTargets)
                            {
                                newUserRole.Scope.Classes.Add(GetManagementClassGuid(userroleclass));
                                 LogMessage(string.Format("Added scoped group {0}", userroleclass));
                            }

                            //Scope the groups
                            if (userroleParams.ScopedGroups == null)
                            {
                                newUserRole.Scope.Objects.Add(
                                    Microsoft.EnterpriseManagement.Monitoring.Security.MonitoringUserRoleScope.
                                        RootMonitoringObjectId);
                                LogMessage(string.Format("Added all groups scope for userrole {0}", newUserRole.Name));
                            }
                            else
                                foreach (var group in userroleParams.ScopedGroups)
                                {
                                    newUserRole.Scope.Objects.Add(GetManagementGroupObjectGuid(group));
                                    LogMessage(string.Format("Added scoped group {0}", group));
                                }
                            //ScopeTask
                        if (userroleParams.UserRoleScopedTask == null)
                        {
                        newUserRole.Scope.NonCredentialTasks.Add(new SDK.Common.Pair<Guid, bool>(Microsoft.EnterpriseManagement.Monitoring.Security.MonitoringUserRoleScope.RootNonCredentialMonitoringTaskId, false));
                        LogMessage(string.Format("Added all task scope for userrole {0}", newUserRole.Name));
                        }
                        else
                            foreach (var task in userroleParams.UserRoleScopedTask)
                            {
                                newUserRole.Scope.Views.Add(new SDK.Common.Pair<Guid, bool>(GetManagementTaskguid(task), false));
                                LogMessage(string.Format("Added scoped Task {0}", task));
                            }
                        
                        // scope the views
                        if ((userroleParams.ScopedViews == null) && (userroleParams.ScopedDashboards == null))
                        {
                            newUserRole.Scope.Views.Add((new Pair<Guid, bool>(Microsoft.EnterpriseManagement.Monitoring.Security.MonitoringUserRoleScope.RootMonitoringViewId, false)));
                            newUserRole.Scope.DashboardReferences.Add(UserRoleScope.RootDashboardReferenceId);
                            LogMessage(string.Format("Added all View and dashboard scope for user role {0}", newUserRole.Name));
                        }
                        else if (userroleParams.ScopedViews != null)
                       
                            foreach (var userroleview in userroleParams.ScopedViews)
                            {
                                newUserRole.Scope.Views.Add(new SDK.Common.Pair<Guid, bool>(GetManagementViewGuid(userroleview), false));
                                LogMessage(string.Format("Added given scoped view {0} ", userroleview));
                            }

                        if (userroleParams.ScopedDashboards != null)
                            foreach (var userroledashboard in userroleParams.ScopedDashboards)
                            {
                                newUserRole.Scope.DashboardReferences.Add(GetManagementDashboards(userroledashboard));
                                LogMessage(string.Format("Added given scoped dashboard  {0}", userroledashboard));
                            }

                        if (userroleParams.AuxNavDashbaords != null)
                            foreach (var auxuserroledashboard in userroleParams.AuxNavDashbaords)
                            {
                                newUserRole.Scope.DashboardReferences.Add(GetManagementDashboards(auxuserroledashboard));
                                LogMessage(string.Format("Added given scoped auxuserroledashboard  {0}", auxuserroledashboard));
                            }
                            

                        }
                    }
                    break;

            }

            if (newUserRole != null)
                {
                    newUserRole.Update();
                    LogMessage(string.Format("updated scope parameter for user role {0}", newUserRole.Name));
                    return newUserRole;
                }
            return null;
            }
            catch (Exception e)
            {

                throw new Exception("Failed To execute Method Utitlites.CreateUSerRoleWithScope()",e);
            }
        }
      
        
        /// <summary>
        /// Creates a new custom User Role.
        /// </summary>
        /// <param name="name">User Role Name</param>
        /// <param name="description">User Role Description</param>
        /// <param name="profileId">Profile Id used to clone profile</param>
        /// <returns>Microsoft.EnterpriseManagement.Security.UserRole</returns>
        public static UserRole CreateUserRole(string name, string description, Guid profileId)
        {
            return CreateUserRole(name, description, profileId, null);
        }

        /// <summary>
        /// Creates a new custom User Role.
        /// </summary>
        /// <param name="name">User Role Name</param>
        /// <param name="description">User Role Description</param>
        /// <param name="profileId">Profile Id used to clone profile</param>
        /// <param name="serverName">Server Name</param>
        /// <returns>Microsoft.EnterpriseManagement.Security.UserRole</returns>
        public static UserRole CreateUserRole(string name, string description, Guid profileId, string serverName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string logMessageBase = currentMethod + " :: ";
            Utilities.LogMessage(logMessageBase);

            ManagementGroup mg = (String.IsNullOrEmpty(serverName)) ? ConnectToManagementServer() : ConnectToManagementServer(serverName);
            IList<UserRole> userRoles = mg.Security.GetUserRoles();
            Profile profile = mg.Security.GetProfile(profileId);

            // Create User Role
            UserRole userRole = new UserRole();
            userRole.Name = name;
            userRole.DisplayName = name;
            userRole.Profile = new Profile(profile);
            Utilities.LogMessage(logMessageBase + "Created User Role '" + userRole.DisplayName + "'");

            // Insert User Role to MG
            mg.Security.InsertUserRole(userRole);
            Utilities.LogMessage(logMessageBase + "Added User Role '" + userRole.DisplayName + "' to ManagementGroup");

            return userRole;
        }

        /// <summary>
        /// Deletes a User Role.
        /// </summary>
        /// <param name="userRoleId">User Role Id</param>
        public static void DeleteUserRole(Guid userRoleId)
        {
            DeleteUserRole(userRoleId, null);
        }

        /// <summary>
        /// Deletes a User Role.
        /// </summary>
        /// <param name="userRoleId">User Role Id</param>
        /// <param name="serverName">Server Name</param>
        public static void DeleteUserRole(Guid userRoleId, string serverName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            string logMessageBase = currentMethod + " :: ";
            Utilities.LogMessage(logMessageBase);

            ManagementGroup mg = (String.IsNullOrEmpty(serverName)) ? ConnectToManagementServer() : ConnectToManagementServer(serverName);
            UserRole userRole = mg.Security.GetUserRole(userRoleId);
            Utilities.LogMessage(logMessageBase + "Deleting User Role '" + userRole.DisplayName + "' [Id = " + userRole.Id + "]");
            mg.Security.DeleteUserRole(userRole);
        }

        /// <summary>
        /// Add a user to a User Role.
        /// </summary>
        /// <param name="username">name of the user to add</param>
        /// <param name="domain">domain of the user to add</param>
        /// <param name="userRoleId">User Role Id</param>
        public static void AddUserToRole(string username, string domain, Guid userRoleId)
        {
            AddUserToRole(username, domain, userRoleId, null);
        }

        /// <summary>
        /// Add a user to a User Role.
        /// </summary>
        /// <param name="username">name of the user to add</param>
        /// <param name="domain">domain of the user to add</param>
        /// <param name="userRoleId">User Role Id</param>
        /// <param name="serverName">Management Server Name</param>
        public static void AddUserToRole(string username, string domain, Guid userRoleId, string serverName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + " :: ");

            #region Check for invalid arguments
            if (String.IsNullOrEmpty(username))
            {
                throw new ArgumentException("username is null or empty.");
            }

            if (String.IsNullOrEmpty(domain))
            {
                throw new ArgumentException("domain is null or empty.");
            }

            if (String.IsNullOrEmpty(userRoleId.ToString()))
            {
                throw new ArgumentException("userRoleId is null.");
            }
            #endregion Check for invalid arguments

            string user = domain + "\\" + username;
            ManagementGroup mg = (String.IsNullOrEmpty(serverName)) ? ConnectToManagementServer() : ConnectToManagementServer(serverName);
            UserRole userRole = mg.Security.GetUserRole(userRoleId);

            if (userRole != null)
            {
                bool userExistsInRole = false;

                // Determine if the user exists in the specified role.
                foreach (string roleUser in userRole.Users)
                {
                    if (roleUser.Equals(user, StringComparison.InvariantCultureIgnoreCase))
                        userExistsInRole = true;
                }

                if (userExistsInRole)
                {
                    Utilities.LogMessage(currentMethod + " :: User Role '" + userRole.DisplayName + "' already contains member '" + user + "'.");
                }
                else
                {
                    Utilities.LogMessage(currentMethod + " :: User Role '" + userRole.DisplayName + "' found.");
                    userRole.Users.Add(user);
                    userRole.Update();
                    Utilities.LogMessage(currentMethod + " :: Added user '" + user + "' to User Role '" + userRole.DisplayName + "'");
                }
            }
        }

        /// <summary>
        /// Deletes a user to a User Role.
        /// </summary>
        /// <param name="username">name of the user/group to delete</param>
        /// <param name="domain">domain of the user/group to delete</param>
        /// <param name="userRoleId">User Role Id</param>
        public static void DeleteUserFromRole(string username, string domain, Guid userRoleId)
        {
            DeleteUserFromRole(username, domain, userRoleId, null);
        }

        /// <summary>
        /// Deletes a user to a User Role.
        /// </summary>
        /// <param name="username">name of the user/group to delete</param>
        /// <param name="domain">domain of the user/group to delete</param>
        /// <param name="userRoleId">User Role Id</param>
        /// <param name="serverName">Management Server Name</param>
        public static void DeleteUserFromRole(string username, string domain, Guid userRoleId, string serverName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + " :: ");

            #region Check for invalid arguments
            if (String.IsNullOrEmpty(username))
            {
                throw new ArgumentException("username is null or empty.");
            }

            if (String.IsNullOrEmpty(domain))
            {
                throw new ArgumentException("domain is null or empty.");
            }

            if (String.IsNullOrEmpty(userRoleId.ToString()))
            {
                throw new ArgumentException("userRoleId is null.");
            }
            #endregion Check for invalid arguments

            string user = domain + "\\" + username;
            ManagementGroup mg = (String.IsNullOrEmpty(serverName)) ? ConnectToManagementServer() : ConnectToManagementServer(serverName);
            UserRole userRole = mg.Security.GetUserRole(userRoleId);

            if (userRole != null)
            {
                bool userExistsInRole = false;

                // Determine if the user exists in the specified role.
                foreach (string roleUser in userRole.Users)
                {
                    if (roleUser.Equals(user, StringComparison.InvariantCultureIgnoreCase))
                    {
                        // user found in role
                        userExistsInRole = true;

                        // this is necessary because when we remove the user the domain
                        // and username must match exactly or the user will not be removed
                        user = roleUser.ToString();
                    }
                }

                if (userExistsInRole)
                {
                    Utilities.LogMessage(currentMethod + " :: User Role '" + userRole.DisplayName + "' found.");
                    userRole.Users.Remove(user);
                    userRole.Update();
                    Utilities.LogMessage(currentMethod + " :: Removed user '" + user + "' from User Role '" + userRole.DisplayName + "'");
                }
                else
                {
                    Utilities.LogMessage(currentMethod + " :: User Role '" + userRole.DisplayName + "' does not contain member '" + user + "'.");
                }
            }
        }

        /// <summary>
        /// Gets the member of the specified User Role.
        /// </summary>
        /// <param name="userRoleId">User Role Id</param>
        public static ICollection<string> GetUserRoleMembers(Guid userRoleId)
        {
            return GetUserRoleMembers(userRoleId, null);
        }

        /// <summary>
        /// Gets the member of the specified User Role.
        /// </summary>
        /// <param name="userRoleId">User Role Id</param>
        /// <param name="serverName">Management Server Name</param>
        public static ICollection<string> GetUserRoleMembers(Guid userRoleId, string serverName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + " :: ");

            if (String.IsNullOrEmpty(userRoleId.ToString()))
            {
                throw new ArgumentException("userRoleId is null.");
            }
        #endregion Check for invalid arguments

            ManagementGroup mg = (String.IsNullOrEmpty(serverName)) ? ConnectToManagementServer() : ConnectToManagementServer(serverName);
            UserRole userRole = mg.Security.GetUserRole(userRoleId);

            if (userRole != null)
            {
                return userRole.Users;
            }

            return null;
        }

        /// <summary>
        /// Method to get the calling method's Name and log it
        /// </summary>
        /// <returns>Calling method name </returns>
        public static string GetCallingMethodNameAndLogIt()
        {
            // get call stack
            StackTrace stackTrace = new StackTrace();

            // get calling method name
            MethodBase method = stackTrace.GetFrame(1).GetMethod();
            LogMessage(method.Name + ":: (...)");

            return method.Name;
        }

        public static void SwitchToDesktopOnWin8()
        {
            LogMessage("Start SwitchToDesktopOnWin8 ...");
            int retries = 0;
            while (retries <= Constants.DefaultMaxRetry * 2)
            {
                try
                {                  
                    Keyboard.SendKeys(KeyboardCodes.WinD);
                    Sleeper.Delay(Constants.OneSecond*10);
                    Window toolBar = new Window(new QID(";[UIA]ClassName = 'MSTaskListWClass' && Name = 'Running applications'"), Constants.OneSecond * 3);
                    //Window momButton = new Window(toolBar, new QID(";[UIA]Name=>'Operations Manager'"), Constants.OneSecond * 3);
                    Utilities.TakeScreenshot("SwitchToDesktopOnWin8After");
                    break;
                }
                catch (Window.Exceptions.WindowNotFoundException)
                {
                    
                    Sleeper.Delay(Constants.OneSecond * 5);
                    Utilities.TakeScreenshot("SwitchToDesktopOnWin8");

                    if (retries == Constants.DefaultMaxRetry * 2)
                    {
                        throw new Window.Exceptions.WindowNotFoundException("Failed to switch to desktop on Win8 OS ");
                    }
                }

                retries++;
            }
            
        }

    #endregion // "Methods"



        #region "Private Methods"

        /// <summary>
        /// This is a helper (SDK) method to return Management Pack object (or null if there's no such MP)
        /// based on MP ID (like UI.Test.MP) and management group specified or an exception
        /// </summary>
        /// <param name="managementPackId">managementPackId</param>
        /// <param name="managementGroup">managementGroup</param>
        /// <returns>managementPackObject</returns>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <history>
        ///     [lucyra] 11SEP07 - Created
        /// </history>
        private static ManagementPack getManagementPackObject(string managementPackId, ManagementGroup managementGroup)
        {
            ManagementPack managementPackObject = null;
            System.Collections.Generic.IList<ManagementPack> managementPackCollection = managementGroup.ManagementPacks.GetManagementPacks();
            foreach (ManagementPack managementPack in managementPackCollection)
            {
                if (managementPackId == managementPack.Name)
                {
                    managementPackObject = managementPack;
                }
            }
            if (managementPackObject == null)
            {
                throw new InvalidOperationException(
                    "Error! Expected one Management Pack with: " + managementPackId);
            }

            return managementPackObject;

        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets current Date/Time and formats it file format.
        /// </summary>
        /// <returns>formated time</returns>
        /// <history>
        ///     [mbickle] 02APR04 - Created
        /// </history>
        /// ------------------------------------------------------------------
        private static string FormatDateTime()
        {
            string dateTime = null;
            dateTime = DateTime.Now.ToLongTimeString();
            dateTime = dateTime.Replace(":", "_");
            dateTime = dateTime.Replace(" ", "_");
            dateTime = dateTime + "_";
            return dateTime;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// SqlReader Method.
        /// </summary>
        /// <param name="sqlQuery">SQL Query that's executed</param>
        /// <returns>Returns GetString(0).</returns>
        /// <history>
        /// [mbickle] 18JAN05 Created
        /// </history>
        /// ------------------------------------------------------------------
        private static string SqlReader(string sqlQuery)
        {
            return SqlReader(sqlQuery);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// SqlReader Method.
        /// </summary>
        /// <param name="sqlQuery">SQL Query that's executed</param>
        /// <param name="getStringIndex">Index of String to return</param>
        /// <returns>Returns GetString(getStringIndex).</returns>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        /// <history>
        /// [mbickle] 18JAN05 Created
        /// </history>
        /// ------------------------------------------------------------------
        private static string cSqlReader(string sqlQuery, int getStringIndex)
        {
            string sqlResult = null;
            try
            {
                LogMessage("Utilities.SqlReader:: Reading Sql Data from Query: " + sqlQuery);
                MomConnectToSql();

                SqlDataReader sqlReader = ExecQuery(sqlQuery);
                try
                {
                    if (sqlReader.Read())
                    {
                        sqlResult = sqlReader.GetString(getStringIndex);
                    }
                    else
                    {
                        throw new InvalidOperationException("Utilities.SqlReader:: No data returned.");
                    }
                }
                finally
                {
                    sqlReader.Close();
                }
            }
            catch (SqlException)
            {
                LogMessage("Utilities.SqlReader:: A SQL Exception occurred.");
                throw;
            }
            finally
            {
                MomCloseConnectionFromSql();
            }

            return sqlResult;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// GetDisplayNameFromClass Method.
        /// </summary>
        /// <param name="managedEntityType">MonitoringClass</param>
        /// <param name="returnFullTreePath">bool</param>
        /// <returns>Returns string</returns>
        /// <history>
        /// [faizalk] 15NOV05 Created
        /// </history>
        /// ------------------------------------------------------------------
        private static string GetDisplayNameFromClass(Microsoft.EnterpriseManagement.Configuration.ManagementPackClass managedEntityType, bool returnFullTreePath)
        {
            // log data for future debugging 
            Utilities.LogMessage("Utilities.GetDisplayNameFromClass:: managedEntityType.ManagementPack.DisplayName=" + managedEntityType.GetManagementPack().FriendlyName);
            Utilities.LogMessage("Utilities.GetDisplayNameFromClass:: managedEntityType.ManagementPack.Name=" + managedEntityType.GetManagementPack().Name);
            Utilities.LogMessage("Utilities.GetDisplayNameFromClass:: managedEntityType.DisplayName=" + managedEntityType.DisplayName);
            Utilities.LogMessage("Utilities.GetDisplayNameFromClass:: managedEntityType.Name=" + managedEntityType.Name);

            string returnString; // we'll use this to return

            // use display name if not null (this is how UI does it)
            if (managedEntityType.DisplayName == null)
            {
                returnString = managedEntityType.Name;
            }
            else
            {
                returnString = managedEntityType.DisplayName;
            }

            if (returnFullTreePath) // return management pack with managed entity name
            {
                // use display name if not null (this is how UI does it)
                if (managedEntityType.GetManagementPack().FriendlyName == null)
                {
                    returnString = managedEntityType.GetManagementPack().Name + "\\" + returnString;
                }
                else
                {
                    returnString = managedEntityType.GetManagementPack().FriendlyName + "\\" + returnString;
                }
            }

            return returnString;
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to initialize test topology and retrieve the Root SDK server
        /// name as a string from the topology information.
        /// </summary>
        /// <returns>
        /// A string representing the name of the Root SDK Server, 
        /// could FQDN or NetBIOS name.
        /// </returns>
        /// ------------------------------------------------------------------
        private static string GetMomRootSdkServerName()
        {
            string returnValue = null;

            try
            {
                Utilities.LogMessage(
                    "Utilities.GetMomRootSdkServerName::Initializing Topology...");

                // initialize Topology using current framework context
                Topology.Initialize();

                Utilities.LogMessage(
                    "Utilities.GetMomRootSdkServerName::Checking for Root SDK server name...");

                // check for root management server name
                if (false == string.IsNullOrEmpty(Topology.RootMomSdkServerName))
                {
                    Utilities.LogMessage(
                        "Utilities.GetMomRootSdkServerName::Using Root SDK server := '" +
                        Topology.RootMomSdkServerName +
                        "'");

                    // return the mom server name
                    returnValue = Topology.RootMomSdkServerName;
                }
                else
                {
                    // get the first MOM server and assume it is Root SDK
                    returnValue = Utilities.GetFirstMomServerFromTopology();
                }
            }
            catch (System.UnauthorizedAccessException)
            {
                // add this try catch to ensure low priv user can get Mom Server machine name.
                Utilities.LogMessage(
                        "Utilities.GetMomRootSdkServerName::current user has not enough permission to run Topology.Initialize(), get the first MOM server and assume it is Root SDK.");

                // get the first MOM server and assume it is Root SDK
                returnValue = Utilities.GetFirstMomServerFromTopology();
            }

            return returnValue;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to retrieve the first MOM server listed in the topology.
        /// </summary>
        /// <returns>
        /// A string representing the name of the Root SDK Server, 
        /// could FQDN or NetBIOS name.
        /// </returns>
        /// ------------------------------------------------------------------
        private static string GetFirstMomServerFromTopology()
        {
            string returnValue = null;

            Utilities.LogMessage(
                        "Utilities.GetMomRootSdkServerName::Checking for list of MOM servers...");

            // check for mom servers in the list of mom servers
            if (null != Topology.MomServers &&
                0 < Topology.MomServers.Length)
            {
                Utilities.LogMessage(
                    "Utilities.GetMomRootSdkServerName::Using first MOM server as Root SDK server := '" +
                    Topology.MomServers[0] +
                    "'");

                // get the first one in the list, it should be the root.
                returnValue = Topology.MomServers[0];
            }
            else
            {
                // we have valid context but no topology data
                Utilities.LogMessage(
                    "Utilities.GetMomRootSdkServerName::Context valid but, no MOM servers listed.  Check config.xml!");

                returnValue = null;
            }

            return returnValue;
        }


        /// ------------------------------------------------------------------
        /// <summary>
        /// Gets Monitor AlertParameter variable value given an index
        /// </summary>
        /// <returns>AlertParameter value</returns>
        /// <history>
        ///     [ruhim] 05/14/08 - Created
        /// </history>
        /// ------------------------------------------------------------------
        private static string GetAlertParameterValue(ManagementPackMonitorAlertSettings alertSettings, int index)
        {
            switch (index)
            {
                case 1: return alertSettings.AlertParameter1;
                case 2: return alertSettings.AlertParameter2;
                case 3: return alertSettings.AlertParameter3;
                case 4: return alertSettings.AlertParameter4;
                case 5: return alertSettings.AlertParameter5;
                case 6: return alertSettings.AlertParameter6;
                case 7: return alertSettings.AlertParameter7;
                case 8: return alertSettings.AlertParameter8;
                case 9: return alertSettings.AlertParameter9;
                case 10: return alertSettings.AlertParameter10;
                default:
                    Utilities.LogMessage("GetAlertParametername:: Invalid Alert Parameter index " + index.ToString());
                    return null;
            }
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Returns AlertMessageID for a rule
        /// </summary>
        /// <param name="monitorRule">MonitoringRule</param>
        /// <param name="confXmlDoc">XML containing Alert configuration</param>
        /// <returns>AlertMessageID</returns>
        /// <history>
        ///     [Ruhim] 12May08 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        private static string GetAlertMsgID(ManagementPackRule monitorRule, out XmlDocument confXmlDoc)
        {
            string alertMsgID = "";
            string tmpAlertMsgID = "";

            string WAModuleConfiguration = "";

            if ((monitorRule.WriteActionCollection.Count > 0) && (null != monitorRule.WriteActionCollection.GetItem("Alert")))
            {
                WAModuleConfiguration = monitorRule.WriteActionCollection[0].Configuration;
                Utilities.LogMessage("Utilities.GetAlertMsgID:: WAModuleConfiguration: " + WAModuleConfiguration);

                // To form a valid XML with only one root element, wrap this XML with <conf></conf>
                WAModuleConfiguration = "<conf>" + WAModuleConfiguration + "</conf>";
            }
            else
            {
                Utilities.LogMessage("Utilities.GetAlertMsgID:: Rule isn't an alert generating one!! ");
                confXmlDoc = null;
                return alertMsgID;
            }

            confXmlDoc = new XmlDocument();

            MemoryStream mstream = new MemoryStream(ASCIIEncoding.ASCII.GetBytes(WAModuleConfiguration));
            confXmlDoc.Load(mstream);

            XmlNodeList alertMessageIDs = confXmlDoc.GetElementsByTagName("AlertMessageId");

            if (alertMessageIDs.Count > 0)
            {
                tmpAlertMsgID = alertMessageIDs[0].InnerText;

                // tmpAlertMsgID will be of this form MPElement[Name="MomUIGeneratedRulefcb3e0e0b71a41c88a07df8c6e274053.AlertMessage"]
                // so split the string at "s, and take the second element in the split
                string[] splits = tmpAlertMsgID.Split(new char[] { '"' });
                alertMsgID = splits[1];
                Utilities.LogMessage("Utilities.GetAlertMsgID:: AlertMsgID: " + alertMsgID);
            }

            return alertMsgID;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Method to substitute the AlertParameter variables with values in Alert Description for a Rule
        /// </summary>
        /// <param name="tmpAlertMsgDesc">Rule alert description containing variables like {0}</param>
        /// <param name="confXmlDoc">XML containing Alert configuration</param>
        /// <returns>RuleAlertDescription</returns>
        /// <history>
        ///     [Ruhim] 12May08 - Created        
        /// </history>
        /// ------------------------------------------------------------------
        private static string SubstituteAlertParams(string tmpAlertMsgDesc, XmlDocument confXmlDoc)
        {
            if (confXmlDoc == null)
            {
                Utilities.LogMessage("Utilities.SubstituteAlertParams:: WriteActionModule Configuration is NULL");
                return null;
            }

            XmlNodeList alertParameters = confXmlDoc.GetElementsByTagName("AlertParameters");
            string pattern = "";
            string replacementString = "";

            for (int i = 0; i < alertParameters.Count; i++)
            {
                pattern = "{" + i.ToString() + "}";
                replacementString = alertParameters[i].InnerText;
                tmpAlertMsgDesc = tmpAlertMsgDesc.Replace(pattern, replacementString);
            }

            Utilities.LogMessage("Utilities.SubstituteAlertParams:: Transformed value for Rule Alert description is " + tmpAlertMsgDesc);
            return tmpAlertMsgDesc;
        }

        #endregion

        #region CONSTANTS

        private const string MOMCOMMON_PATH = @"..\..\momcommon\";
        private const string MOMCOMMON_TO_REPORTS = @"..\Reporting\Reports";
        private const string TESTLEVEL_TO_REPORTS = @"\Reporting\Reports";
        private const string WAMLGT_FILENAME = "wamlgt.exe";
        private const string RUNASPROCESS_FILENAME = "RunProcessAs.exe";
        private const string LOAD_DISCOVERY_FILENAME = "Load.Discovery.xml";
        private const string SMX_DOMAIN = @"SMX\";
        private const string MOMDW_ACCOUNT = "momDW";
        private const string ASTTEST_ACCOUNT = "asttest";
        private const string DISCOVERY_LOGFILE = @"\temp\disclog.out";
        private const string PERF_LOGFILE_PREFACE = @"\temp\perflog_";
        private const string LOAD_PERF_FILENAME = "Load.PerfData.Custom.xml";
        private const string PAYLOAD_PERF_FILENAME = "Payload.PerfData.Custom.xml";
        private const string PAYLOAD_PERF_BACKUP_FILENAME = "Payload.PerfData.Custom.BU.xml";
        private const string STARTTIME = "$STARTTIME$";
        private const string ENDTIME = "$ENDTIME$";
        private const string STATECHANGE_LOGFILE_PREFACE = @"\temp\statelog_";
        private const string LOAD_STATECHANGE_FILENAME = "Load.StateChange.Custom.xml";
        private const string PAYLOAD_STATECHANGE_FILENAME = "Payload.StateChange.Custom.xml";
        private const string DB_GROWTH_SCRIPT = "SetupDBFileGrowth.sql";
        private const string DW_GROWTH_SCRIPT = "SetupDWFileGrowth.sql";
        private const string COMPUTER_GROUP_SCRIPT = "computergroupinfoget.sql";
        private const string LOCAL_PATH = ".\\";
        private const string BVT = "BVT";
        private const string REGRESSION = "Regression";
        private const string FUNC = "FUNC";
        private const string DATEVALUE = "$DATEVALUE$";
        private const string LOOPVALUE = "$LOOPVALUE$";
        private const string SLAGUIDLIST = "$SLAGUIDLIST$";

        private const string SC = "sc";
        private const string KILL = "kill";
        private const string START = "start";
        private const string SQLSVC = "MSSQL$INSTANCE1";
        private const string SDKSVC = "omsdk";
        private const string MOMUI_FOLDER = "\\System Center Operations Manager 2007\\";
        private const string SYS32_FOLDER = "\\System32";
        private const string MOMUI_FILENAME = "Microsoft.MOM.UI.Console.exe";
        private const string PERF_DATASET = "Performance data set";
        private const string AGGREGATION_TYPE_RAW = "Raw data";
        private const string DATASETID = "DatasetId";
        private const string AGGREGATION_START_DATATIME = "AggregationTargetStartDateTime";
        private const string INTERVALS_TO_AGGREGATE = "IntervalsToAggregate";
        private const string PROCESSOR = "Processor";
        private const string PERCENT_PROCESSOR = "%Processor";

        #endregion

    }       // end of class

    /// <summary>
    /// 
    /// </summary>
    public class UserroleScopeParameters
    {
        #region privatemembers
        private List<string> _scopedDashboards = new List<string>();
        private List<string> _scopedTargets = new List<string>();
        private List<string> _scopedGroups = new List<string>();
        private List<string> _auxNavDashbaords = new List<string>();
        private List<string> _userRoleScopedTask = new List<string>();
        private List<string> _scopedViews = new List<string>();
        private List<string> _membersdomain = new List<string>();
        private List<string> _members = new List<string>();


        #endregion
        /// <summary>
        /// 
        /// </summary>
        public UserroleScopeParameters()
        {
            ScopedGroups = null;
            ScopedTargets = null;
            ScopedViews = null;
            AuxNavDashbaords = null;
            ScopedDashboards = null;
            UserRoleScopedTask = null;

        }

        /// <summary>
        /// Property to set and get the ScopeDashbards for user role
        /// </summary>
        public List<string> ScopedDashboards
        {
            get { return this._scopedDashboards; } //get list of ids
            set { this._scopedDashboards = value; }


        }
        /// <summary>
        ///Property to set and get the ScopeTarget for user role
        /// </summary>
        public List<string> ScopedTargets
        {
            get { return this._scopedTargets; }
            set { this._scopedTargets = value; }
        }


        /// <summary>
        /// Property to set and get the ScopeGroup for user role
        /// </summary>
        public List<string> ScopedGroups
        {
            get { return this._scopedGroups; }
            set { this._scopedGroups = value; }

        }
        /// <summary>
        /// Property to set and get the AuxDashbard for user role
        /// </summary>
        public List<string> AuxNavDashbaords
        {
            get { return this._auxNavDashbaords; }
            set { this._auxNavDashbaords = value; }

        }

        /// <summary>
        /// Property to set and get the ScopeTask for user role
        /// </summary>
        public List<string> UserRoleScopedTask
        {
            get { return this._userRoleScopedTask; }
            set { this._userRoleScopedTask = value; }

        }

        /// <summary>
        /// Property to set and get the ScopeViews for user role
        /// </summary>
        public List<string> ScopedViews
        {
            get { return this._scopedViews; }
            set { this._scopedViews = value; }

        }

    }



} // end of namespace
