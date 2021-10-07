//-------------------------------------------------------------------
// <copyright file="Constants.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains utility classes for the MOMX UI automated tests
// </summary>
// <history>
//   [mbickle] 26MAR03 Created
//   [ruhim]   16NOV05 Adding TargetManagedEntityType Guids 
//   [faizalk] 30NOV05 More TargetManagedEntityType Guids
//   [ruhim]   08MAR06 Adding constants for UI Test MP 
//   [faizalk] 190606  Adding constants requested during SynTx code review.
//   [a-omkasi] 17JUL08 Adding constants for Reporting.
//   [sunsingh] 17Sep08 Adding constants for SLA Report.
//   [sunsingh] 19Sep08 Adding constants for SLA Mp.
//   [zhihaoq]  23Oct08 Adding constants for MOM test key
//   [zhihaoq]  23Oct08 Adding constants for Regkey for MP catalog WS URL. 
// </history>
// <remarks>
//  [mbickle] 13OCT04 TODO: Consider making an XML file and loading the 
//                    values at runtime for these constants to avoid 
//                    having to recompile if these values need to change.
//  [barryw] 01DEC05 - Added region: 'Mcf GetVarmapRecords' with
//                     MultipleValues, SingleValue constants, which apply
//                     to the Mcf class.
//  [barryw] 01DEC05 - Todo: Consider encapsulating non-global constants
//                     to the class where they apply by creating 
//                     Constants subclasses, or perhaps put other 
//                     datatypes in Strings class. 
// </remarks>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Common
{
    #region Using directives
    using System;
    #endregion

    /// <summary>
    /// Constants
    /// </summary>
    public sealed class Constants
    {
        /// <summary>
        /// Default Dialog Timeout @ 15 seconds.
        /// </summary>
        public const int DefaultDialogTimeout = 100000; // Modify timeout to 100000 for Win8 test    100 seconds

        /// <summary>
        /// Default ContextMenu Timeout @ 3 seconds.
        /// </summary>
        public const int DefaultContextMenuTimeout = 5000; // 5 seconds

        /// <summary>
        /// Default App Startup Timeout @ 600 seconds.
        /// -- Increased because SCE is SLOW
        /// </summary>
        public const int DefaultAppStartupTimeout = 600000;

        /// <summary>
        /// The time it takes for the grid to appear in a view
        /// </summary>
        public const int DefaultViewLoadTimeout = 60000;

        /// <summary>
        /// timeout of 1 second.
        /// </summary>
        public const int OneSecond = 1000; // 1 second
        
        /// <summary>
        /// timeout of 10 second (used to wait for button enablement)
        /// </summary>
        public const int TenSeconds = 10000; // 10 seconds
       
        /// <summary>
        /// timeout of 1 minute.
        /// </summary>
        public const int OneMinute = 60000; // 1 minute

        /// <summary>
        /// Default Web Console SignIn Timeout (seconds).
        /// </summary>
        public const int DefaultSignInTimeout = 90;

        /// <summary>
        /// Default Web Console SignOut Timeout (seconds).
        /// </summary>
        public const int DefaultSignOutTimeout = 45;

        /// <summary>
        /// Default Load Detail Pane Timeout (5 seconds).
        /// </summary>
        public const int DefaultDetailPaneLoadTimeout = 5000;

        /// <summary>
        /// Default max retry (5 times)
        /// </summary>
        public const int DefaultMaxRetry = 5;

        /// <summary>
        /// MOM HKCU Registry Path
        /// </summary>
        public const string MomHKCURegistryPath = @"Software\Microsoft\Microsoft Operations Manager";

        /// <summary>
        /// MOM Version UI- 3.0
        /// </summary>
        public const string MomVersion = "3.0";

        /// <summary>
        /// Registry Location to Setup Path.
        /// </summary>
        public const string SetupRegistryPath =
            @"Software\Microsoft\Microsoft Operations Manager\3.0\Setup";

        /// <summary>
        /// Registry Location to Console Path.
        /// </summary>
        public const string SetupRegistryPathConsole =
            @"SOFTWARE\Microsoft\System Center Operations Manager\12\Setup\Console";

        /// <summary>
        /// Registry Location to Console Path.
        /// </summary>
        public const string SetupRegistryPathWebConsole =
            @"SOFTWARE\Microsoft\System Center Operations Manager\12\Setup\WebConsole";

        /// <summary>
        /// Registry Location to Authoring Console Setup Path.
        /// </summary>
        public const string SetupRegistryACPath =
            @"Software\Microsoft\Microsoft Operations Manager\3.0\Authoring Console";

        /// <summary>
        /// Registry Location to MachineSettings Registry Path.
        /// </summary>
        public const string MachineSettingsRegistryPath =
            @"Software\Microsoft\Microsoft Operations Manager\3.0\Machine Settings";

        /// <summary>
        /// Registry Key for DefaultSDKServiceMachine
        /// </summary>
        public const string DefaultSDKServiceMachineRegistryKey = "DefaultSDKServiceMachine";

        /// <summary>
        /// RegKey that has Install Directory value.
        /// </summary>
        public const string InstallDirectoryRegistryKey = "InstallDirectory";

        /// <summary>
        /// AdminConsole .msc file location relative to InstallDir.
        /// </summary>
        public const string AdminConsoleExe = @"\Console\MOMAdministratorConsole2005.msc";

        /// <summary>
        /// Full MomConsole EXE name relative to InstallDir.
        /// </summary>
        public const string MomConsoleExe = "Microsoft.EnterpriseManagement.Monitoring.Console.exe";

        /// <summary>
        /// Internet Explorer EXE name.
        /// </summary>
        public const string InternetExplorerExe = "iexplore.exe";

        /// <summary>
        /// Firefox EXE name.
        /// </summary>
        public const string FirefoxExe = "firefox.exe";

        /// <summary>
        /// Health Service EXE name
        /// </summary>
        public const string HealthServiceExe = "HealthService.exe";

        /// <summary>
        /// OM SDK Service Host EXE name
        /// </summary>
        public const string SdkSerivceHostExe = "Microsoft.Mom.Sdk.Service.exe";

        /// <summary>
        /// IIS Worker Process EXE name
        /// </summary>
        public const string W3WpExe = "w3wp.exe";
        
        /// <summary>
        /// Monitoring Host EXE name
        /// </summary>
        public const string MonitoringHostExe = "MonitoringHost.exe";

        /// <summary>
        /// OM SDK Service Host EXE name
        /// </summary>
        public const string SqlServerExe = "sqlservr.exe";

        /// <summary>
        /// Dr. Watson 2.0 Exe
        /// </summary>
        public const string DW20Exe = "DW20.exe";

        /// <summary> 
        /// Friendly name of prcess WinWord.exe 
        /// </summary> 
        public const string WinWordProcessFriendlyName = "WinWord";


        /// <summary>
        /// Select Sku
        /// </summary>
        public const string SelectSku = "Select";

        /// <summary>
        /// Express Sku
        /// </summary>
        public const string ExpressSku = "Express";

        /// <summary>
        /// Installed Server SKU Regkey
        /// </summary>
        public const string InstalledServerSkuRegistryKey = "InstalledServerSKU";

        /// <summary>
        /// DatabaseName RegKey - located under Setup Regkey Path.
        /// </summary>
        public const string DatabaseNameRegistryKey = "DatabaseName";

        /// <summary>
        ///  DatabaseServerNam e- located under Setup Regkey Path.
        /// </summary>
        public const string DatabaseServerNameRegistryKey = "DatabaseServerName";

        /// <summary>
        /// Ampersand
        /// </summary>
        public const string AmpersandValue = "&";

        /// <summary>
        /// The NT Event Source name for the .Net Runtime. 
        /// </summary>
        public const string NTEventSourceDotNetRuntime = ".NET Runtime 2.0 Error Reporting";

        /// <summary>
        /// The NT Event Source name for the EventCreate
        /// </summary>
        public const string NTEventSourceEventCreate = "EventCreate";

        /// <summary>
        /// The NT Event log name for the Application log.
        /// </summary>
        public const string NTEventLogNameApplication = "Application";

        /// <summary>
        /// Path Delimiter - \\
        /// </summary>
        public const string PathDelimiter = "\\";

        /// <summary>
        /// Display Name for UI.Test.MP
        /// </summary>
        public const string UITestMPDisplayName = "UI Test Management Pack";

        /// <summary>
        /// Display Name for UI.Test.SLASLO.MP
        /// </summary>
        public const string UITestSLASLOMPDisplayName = "UI Test SLASLO MP";

        /// <summary>
        /// Nmae for UI.Test.MP
        /// </summary>
        public const string UITestMPName = "UI.Test.MP";

        /// <summary>
        /// Nmae for AlertComponent MP
        /// </summary>
        public const string TestMPWithAlertComponent = "Microsoft.SystemCenter.AlertComponent";

        /// <summary>
        /// Name for UI.Test.SLASLO.MP
        /// </summary>
        public const string UITestSLASLOMPName = "UI.Test.SLASLO.MP";

        /// <summary>
        /// MP Name for UIDashboardAuthoringTest.xml
        /// </summary>
        public const string UIDashboardAuthoringTestMPName = "UIDashboardAuthoringTest";

        /// <summary>
        /// File name for UIDashboardAuthoringTest.xml
        /// </summary>
        public const string UIDashboardAuthoringTestMPFileName = "UIDashboardAuthoringTest.xml";

        /// <summary>
        /// MP name for Tuneup.Test.mp
        /// </summary>
        public const string TuneupTestMPName = "Tuneup.Test";

        /// <summary>
        /// File name for Tuneup.Test.mp
        /// </summary>
        public const string TuneupTestMPFileName = "Tuneup.Test.mp";

        /// <summary>
        /// File name for Tuneup.Test.xml
        /// </summary>
        public const string UnsealedTuneupTestMPFileName = "Tuneup.Test.xml";

        /// <summary>
        /// Name for Microsoft.Windows.Client.Library.mp
        /// </summary>
        public const string ClientOperatingSystemsMPName = "Microsoft.Windows.Client.Library";

        /// <summary>
        /// Name for Microsoft.SystemCenter.Visualization.Configuration.Library.mp
        /// </summary>
        public const string VisualizationConfigurationLibrarySystemMPName = "Microsoft.SystemCenter.Visualization.Configuration.Library";

        /// <summary> 
        /// UITest view folder added under Monitoring
        /// </summary>
        public const string UITestViewFolder = "UITest";

        /// <summary>
        /// UITest MP Guid
        /// </summary>
        public const string UITestMPGuid = "e89a0934-f1fe-ca83-bfa7-438df623800d";

        /// <summary>
        /// UITest MP Computer Group display name
        /// </summary>
        public const string UITestComputerGroup = "UI Test Computer Group";

        /// <summary>
        /// MOM assembly test public key token
        /// </summary>
        public const string TestPublicKeyToken = "9396306c2be7fcc4";

        /// <summary>
        /// RegKey Path that has MP Catalog Web Service URL value.
        /// </summary>
        public const string MPCatalogWebServiceURLRegistryKeyPath = @"Console\Catalog";

        /// <summary>
        /// RegKey that has MP Catalog Web Service URL value.
        /// </summary>
        public const string MPCatalogWebServiceURLRegistryKey = "ServiceUrl";

        /// <summary>
        /// Direction: left
        /// </summary>
        public const string Left = "left";

        /// <summary>
        /// Direction: right
        /// </summary>
        public const string Right = "right";

        /// <summary>
        /// Template ID of grid layout dashboard in Microsoft.SystemCenter.Visualization.Library.xml MP
        /// </summary>
        public const string GridLayoutDashboardTemplateName = "Microsoft.SystemCenter.Visualization.GridLayout";

        /// <summary>
        /// Template ID of flow layout dashboard in Microsoft.SystemCenter.Visualization.Library.xml MP
        /// </summary>
        public const string FlowLayoutDashboardTemplateName = "Microsoft.SystemCenter.Visualization.ColumnLayout";

        /// <summary>
        /// Template ID of flow layout dashboard in Microsoft.SystemCenter.Visualization.Library.xml MP
        /// </summary>
        public const string TestMPForTopNWidgets = "Microsoft.SystemCenter.TestMPForTopNWidgets";

        /// <summary>
        /// Name for Network Monitoring folder name
        /// </summary>
        public const string NetworkMonitoring = "System.NetworkManagement.ViewFolder.Root";
        /// <summary>
        /// Name for NetWork Summary Dashboard
        /// </summary>
        public const string NetWorkSummaryDashboardName = "MsScVsNtDb.NetworkSummaryDashboard";

        /// <summary>
        /// Name for NetWork Node Dashboard
        /// </summary>
        public const string NetWorkNodeDashboardName = "MsScVsNtDb.NetworkNodeDashboard";

        /// <summary>
        /// Name for Network Interface Dashboard
        /// </summary>
        public const string NetWorkInterfaceDashboardName = "MsScVsNtDb.NetworkInterfaceDashboard";

        /// <summary>
        /// Name for Computer Vicinity Dashboard Name
        /// </summary>
        public const string ComputerVicinityDashboardName = "MsScVsNtDb.NNDVicinityFromComputerDVWithDetailsPaneInViewHost";

        /// <summary>
        /// Name for node Vicinity Dashboard name
        /// </summary>
        public const string NodeVicinityDashboardName = "MsScVsNtDb.NNDVicinityDVWithDetailsPane";

        /// <summary>
        /// Name for Service Level Tracking folder name
        /// </summary>
        public const string ServiceLevelTrackingName = "ServiceLevel.Root";

        /// <summary>
        /// Name for Service Level Dashboard (Last 7 Days)
        /// </summary>
        public const string ServiceLevelDashboardLast7DaysName = "Visualization.SlaDashboardViewInstanceHourly";

        /// <summary>
        /// Name for Service Level Dashboard (Last 30 Days)
        /// </summary>
        public const string ServiceLevelDashboardLast30DaysName = "Visualization.SlaDashboardViewInstanceDaily";
        
        /// <summary>
        /// RegKey Value that defines MP Catalog Web Service URL.
        /// </summary>
        public const string MPCatalogWebServiceURLRegistryKeyValue = "https://sunsingh-test1-vm1/ManagementPackCatalogWebService.asmx";

        /// <summary>
        /// Error state cell value in State view
        /// </summary>
        public const string ErrorState = "ErrorAvailable";

        /// <summary>
        /// Success state cell value in State view
        /// </summary>
        public const string SuccessState = "SuccessAvailable";

        /// <summary>
        /// Warning state cell value in State view
        /// </summary>
        public const string WarningState = "WaringAvailable";

        /// <summary>
        /// Uninitialized state cell value in State view
        /// </summary>
        public const string UninitializedState = "UninitializedAvailable";

        #region Reporting Constants
        /// <summary>
        /// MicrosoftGenericReportLibraryName 
        /// </summary>
        public const string MicrosoftGenericReportLibraryName = "microsoftgenericreportlibrary";

        /// <summary>
        /// AlertLoggingLatencyReportName
        /// </summary>
        public const string AlertLoggingLatencyReportName = "AlertLoggingLatency";
        /// <summary>
        /// SLASummary
        /// </summary>
        public const string SlaSummary = "SLASummary";
        /// <summary>
        /// SlaDashboard
        /// </summary>
        public const string SlaDashboard = "SlaDashboard";
        /// <summary>
        /// SlaConfiguration
        /// </summary>
        public const string SlaConfiguration = "SlaConfiguration";
        /// <summary>
        /// AlertsReportName 
        /// </summary>
        public const string AlertsReportName = "Alert";

        /// <summary>
        /// AlertsReportName 
        /// </summary>
        public const string AvailabilityReportName = "Availability";

        /// <summary>
        /// ConfigurationChangesReportName
        /// </summary>
        public const string ConfigurationChangesReportName = "ConfigurationChange";

        /// <summary>
        /// CustomConfigurationReportName
        /// </summary>
        public const string CustomConfigurationReportName = "CustomConfiguration";

        /// <summary>
        /// CustomEventReportName
        /// </summary>
        public const string CustomEventReportName = "CustomEvent";

        /// <summary>
        /// EventAnalysisReportName
        /// </summary>
        public const string EventAnalysisReportName = "EventAnalysis";

        /// <summary>
        /// HealthReportName
        /// </summary>
        public const string HealthReportName = "Health";

        /// <summary>
        /// LicensesReportName
        /// </summary>
        public const string LicensesReportName = "License";

        /// <summary>
        /// MostCommonAlertsReportName
        /// </summary>
        public const string MostCommonAlertsReportName = "MostCommonAlerts";

        /// <summary>
        /// MostCommonEventsReportName
        /// </summary>
        public const string MostCommonEventsReportName = "MostCommonEvents";

        /// <summary>
        /// OverridesReportName
        /// </summary>
        public const string OverridesReportName = "Override";

        /// <summary>
        /// PerformanceReportName
        /// </summary>
        public const string PerformanceReportName = "Performance";

        /// <summary>
        /// PerformanceDetailReportName
        /// </summary>
        public const string PerformanceDetailReportName = "PerformanceDetail";

        /// <summary>
        /// PerformanceTopInstancesReportName
        /// </summary>
        public const string PerformanceTopInstancesReportName = "PerformanceTopInstance";

        /// <summary>
        /// PerformanceTopObjectsReportName
        /// </summary>
        public const string PerformanceTopObjectsReportName = "PerformanceTop";

        /// <summary>
        /// Reporting UI Test MP Name
        /// </summary>
        public const string ReportingUITestMPFileName = "ReportingUI.Test.Library.xml";

        /// <summary>
        /// Reporting UI Test MP Name
        /// </summary>
        public const string ReportingSlaTestMPName = "SlaTestMP.xml";

        /// <summary>
        /// Reporting UI Test Library Display Name
        /// </summary>
        public const string ReportingUITestLibraryDisplayName = "reportingui.test.library";

        /// <summary>
        /// Service Level ReportLibrary MP
        /// </summary>
        public const string ServiceLevelReportLibrary = "servicelevelreportlibrary";

        /// <summary>
        /// Reporting UI Test Display Name
        /// </summary>
        public const string ReportingUITestDisplayName = "ReportingUITestLinkedAlerts";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string PASS = "PASS";
        /// <summary>
        /// Reporting UI Test MP Name
        /// </summary>
        public const string ReportingUITestMPName = "ReportingUI.Test.Library";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string FAIL = "FAIL";

        /// <summary>
        /// For comparison
        /// </summary>
        public const int ILLOGICAL_INTEGER = -99999;

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string PERFORMANCE_SP = "sdk.Microsoft_SystemCenter_DataWarehouse_Report_Library_PerformaceReportDataGet";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string AVAILABILITY_SP = "sdk.Microsoft_SystemCenter_DataWarehouse_Report_Library_AvailabilityReportDataGet";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SERVICELEVEL_SP1 = "sdk.GetServiceLevelInformationData";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SERVICELEVEL_SP2 = "sdk.GetServiceLevelMetaData";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SERVICELEVEL_SP3 = "sdk.ServiceLevelObjectiveDetailReportDataGet";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SERVICELEVEL_REPORT_SP1 = "sdk.Microsoft_SystemCenter_DataWarehouse_ServiceLevel_Report_Library_ServiceLevelAgreementSummaryReportMetaDataGet";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SERVICELEVEL_REPORT_SP2 = "sdk.Microsoft_SystemCenter_DataWarehouse_ServiceLevel_Report_Library_ServiceLevelAgreementSummaryReportDataGet";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SERVICELEVEL_REPORT_SP3 = "sdk.Microsoft_SystemCenter_DataWarehouse_ServiceLevel_Report_Library_ServiceLeveObjectiveDetailReportDataGet";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string INVALID_SP = "dbo.Microsoft_SystemCenter_DataWarehouse_Report_Library_PerformaceReportDataGet";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string MADE_UP_SP = "sql.Some_Made_Up_SP_Name";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SQLADMIN_SP = "sys.sp_addlogin";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string PERFORMANCE = "PERFORMANCE";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string AVAILABILITY = "AVAILABILITY";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SERVICELEVEL = "SERVICELEVEL";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SERVICELEVEL1 = "SERVICELEVEL1";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SERVICELEVEL2 = "SERVICELEVEL2";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string NOTPRESENT = "NOTPRESENT";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SQLADMIN = "SQLADMIN";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string VALID = "VALID";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string INVALID = "INVALID";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string STARTDATE = "StartDate";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string ENDDATE = "EndDate";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string OPTIONLIST = "OptionList";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string OBJECTLIST = "ObjectList";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SLAXML = "ServiceLevelAgreementXml";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string DATAAGGREGATION = "DataAggregation";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string LANGUAGECODE = "LanguageCode";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string LANG = "ENU";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string MONITORNAME = "MonitorName";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string MONNAME = "System.Health.AvailabilityState";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string AGGREGATIONTYPEID = "AggregationTypeId";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string MANAGEMENTGROUPID = "ManagementGroupId";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string OMITTED = "OMITTED";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string ADDITIONAL = "ADDITIONAL";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string NONE = "NONE";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string INVALIDTYPES = "INVALIDTYPES";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string PERF_XMLINPUT1 = "<Data><Values><Value><Object Use=\"Containment\">";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string PERF_XMLINPUT2 = "</Object><Rule>";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string PERF_XMLINPUT3 = "</Rule><Color>63,63,255</Color><Type>Line</Type><Scale>1</Scale></Value></Values></Data>";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string AVAIL_XMLINPUT1 = "<Data><Objects><Object Use=\"Containment\">";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string AVAIL_XMLINPUT2 = "</Object></Objects></Data>";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SL_XMLINPUT1 = "\'<Data><ServiceLevelAgreements><ServiceLevelAgreement ManagementGroupGuid=";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SL_XMLINPUT2 = " ServiceLevelAgreementGuid=";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SL_XMLINPUT3 = " /><ServiceLevelAgreement ManagementGroupGuid=";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SL_XMLINPUT4 = " /></ServiceLevelAgreements></Data>\'";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string COMPUTER_GROUP_SCRIPT = "computergroupinfoget.sql";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string WINDOWS_SERVER_INSTANCES_GROUP = "Windows Server Instances Group";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string PERCENT_PROCESSOR_COUNTER_NAME = "Processor % Processor Time 2003";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string ALL_WINDOWS_COMPUTERS = "All Windows Computers";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string HEALTH_SERVICE_MODULE_COUNTER_NAME = "Collect Health Service\\Module Count";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string DAILY = "DAILY";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string HOURLY = "HOURLY";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string TWODAYS = "TWODAYS";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string WEEK = "WEEK";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string MONTH = "MONTH";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string QUARTER = "QUARTER";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string YEAR = "YEAR";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string TEST = "TEST";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string NEGATIVE = "NEGATIVE";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string ZERO = "ZERO";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SHORT = "SHORT";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string PERF_SELECTED_COLUMNS = "PERF_SELECTED_COLUMNS";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string AVAIL_SELECTED_COLUMNS = "AVAIL_SELECTED_COLUMNS";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SLA_SELECTED_COLUMNS = "SLA_SELECTED_COLUMNS";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string THREE = "3";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string TWO = "2";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SLAMEROWID = "ServiceLevelAgreementManagedEntityRowId";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SLOGUID = "ServiceLevelObjectiveGuid";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string SingleSpace = " ";

        /// <summary>
        /// Rather than using string literal
        /// </summary>
        public const string DoubleSpaces = "  ";

        /// <summary>
        /// Default management pack Name
        /// </summary>
        public const string DefaultManagementPackName = "Microsoft.SystemCenter.OperationsManager.DefaultUser";
        #endregion

        #region DataGen Constants

        /// <summary>
        /// Strings used with DataGenerationMapUtilities class
        /// </summary>
        
        public const string Random = "random";
        public const string Specific = "specific";
        public const string Linear = "linear";
        public const string Smile = "smile";
        public const string Green = "green";
        public const string Yellow = "yellow";
        public const string Red = "red";
        public const string AccountName = "asttest";
        public const string DomainName = "SMX";
        public const string ConfigFilesLocation = @"\..\..\MOMCommon\ConfigFiles";
        public const string MapWidgetConfigContainerName = "MapWidgetTestMP";
        public const string EntityLocationRelationshipTypeName = "System.ConfigItemReferencesLocation";
        public const string LocationEntityTypeName = "System.GeoLocation";
        public const string DisplayNameProperty = "DisplayName";
        public const string Location = "Location";
        public const string Agent = "Agent";
        public const string IsAgentProperty = "IsAgent";
        public const string SystemConfigContainerName = @"System.Library"; 
        public const string SystemCenterLibraryConfigContainerName = @"Microsoft.SystemCenter.Library";
        public const string SystemHealthLibraryConfigContainerName = @"System.Health.Library";
        public const string SystemHealthEntityStateMonitorName = "System.Health.EntityState";
        public const string WindowsLibraryConfigContainerName = @"Microsoft.Windows.Library";
        public const string WindowsComputerEntityTypeName = @"Microsoft.Windows.Computer";
        public const string HealthServiceEntityTypeName = @"Microsoft.SystemCenter.HealthService";
        public const string HealthServiceManagesEntityRelationshipTypeName = @"Microsoft.SystemCenter.HealthServiceManagesEntity";

        #endregion

        #region Mcf GetVarmapRecords

        /// <summary>
        /// Multiple record values are expected. 
        /// </summary>
        public const bool MultipleValues = true;

        /// <summary>
        /// A single record value is expected. 
        /// </summary>
        public const bool SingleValue = false;

        #endregion

        /// <summary>
        /// Gets the logged on users Application folder.
        /// </summary>
        public static readonly string UsersAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        /// Path to the MOM Application Data directory where default.OMC file resides.
        /// </summary>
        public static readonly string UsersMomAppDataDir = Constants.UsersAppDataDir + "\\" + "Microsoft Operations Manager 2005";

        /// <summary>
        /// ServiceLevel Data Provider primary method name
        /// </summary>
        public static string ServiceLevelDataProvider = "Microsoft.EnterpriseManagement.Monitoring.DataProviders!ServiceLevelAgreementProvider/GetServiceLevels";

        /// <summary>
        /// ServiceLevelObjective Data Provider primary method name
        /// </summary>
        public static string ServiceLevelObjectiveDataProvider = "Microsoft.EnterpriseManagement.Monitoring.DataProviders!ServiceLevelAgreementProvider/GetServiceLevelObjectives";

        #region TargetManagedEntityType Guids
        /// <summary>
        /// Contains GUID for: System Entity Managed Type
        /// </summary>            
        public const string GUIDEntityManagedType = "8E394B6F-B618-7D0F-5034-7017D2237FD9";

        /// <summary>
        /// Contains GUID for: System.Windows.NTService Managed Type
        /// </summary>            
        public const string GUIDNTServiceManagedType = "94854CAE-000D-768A-FBFC-9765611C876E";

        /// <summary>
        /// Contains GUID for: System.Windows.OwnProcessNTService Managed Type
        /// </summary>            
        public const string GUIDOwnProcessNTServiceManagedType = "3522A80B-4A0F-E0E1-2437-6D34BF97946B";

        /// <summary>
        /// Contains GUID for: Microsoft.SystemCenter.Process.BaseMonitoredProcess Managed Type
        /// </summary>            
        public const string GUIDProcessMonitorManagedType = "761CCEC9-CE3D-3047-990E-E5A454C25547";

        /// <summary>
        /// Contains GUID for: System.Windows.Computer Managed Type
        /// </summary>            
        public const string GUIDWindowsComputerManagedType = "DB4E9CBC-5E25-182C-E2EE-26759090A2B9";

        /// <summary>
        /// Contains GUID for: System.Mom.HealthService Managed Type
        /// </summary>            
        public const string GUIDHealthServiceManagedType = "17E06AB0-6F7C-D016-52D3-E338D9951846";

        /// <summary>
        /// Contains GUID for: System.Web.WebPage.Perspective Managed Type
        /// </summary>            
        public const string GUIDWebPagePerspectiveManagedType = "3CDBED9D-5702-FD46-1FD1-539F8C4A4714";

        /// <summary>
        /// Contains GUID for: System.Web.HttpUrl.Perspective Managed Type
        /// </summary>            
        public const string GUIDHttpUrlPerspectiveManagedType = "57106A2C-5A2F-3CB1-F2AD-B0F708F582F4";

        /// <summary>
        /// Contains GUID for: Microsoft.DistributedApplication.WebFarm Managed Type
        /// </summary>            
        public const string GUIDDAWebFarmManagedType = "D9DCA9D5-9E3A-6A7F-F600-BA46F29E659C";

        /// <summary>
        /// Contains GUID for: Microsoft.DistributedApplication.WebSiteServiceComponent Managed Type
        /// </summary>            
        public const string GUIDDAWebSiteServiceManagedType = "16802202-376B-C364-E269-C5194B95609D";

        /// <summary>
        /// Contains GUID for: Microsoft.DistributedApplication.DatabaseServiceComponent Managed Type
        /// </summary>            
        public const string GUIDDADatabaseServiceManagedType = "1C01ADAF-A5AA-EBBB-15B8-5C63A98FFDAC";

        /// <summary>
        /// Contains GUID for: System.SoftwareInstallation Managed Type
        /// </summary>            
        public const string GUIDSoftwareInstallationManagedType = "77FFFC42-A77A-053C-18AD-59C0BA49CF5B";

        /// <summary>
        /// Contains GUID for: System.AEM.FileShare Managed Type
        /// </summary>            
        public const string GUIDAEMFileShareManagedType = "36923BC4-CD90-6AD9-D237-4DC8368B9783";

        /// <summary>
        /// Contains GUID for: System.Hardware.GenericSnmpDevice Managed Type
        /// </summary>            
        public const string GUIDGenericSnmpDeviceManagedType = "E0577873-8FD6-544A-C4FB-5D04DE335FFD";

        /// <summary>
        /// Contains GUID for: System.Hardware.GenericSnmpDeviceGroup Managed Type
        /// </summary>            
        public const string GUIDGenericSnmpDeviceGroupManagedType = "2193521B-2F07-0A26-CF42-1F5AF1B827D5";

        #endregion //TargetManagedEntityType Guids

        #region Constructor
        /// <summary>
        /// Private Constructor to fix FxCop error.
        /// </summary>
        private Constants() { }
        #endregion
    }
}
