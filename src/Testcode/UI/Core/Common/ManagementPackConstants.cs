//-------------------------------------------------------------------
// <copyright file="ManagementPackConstants.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains constants for Management Pack References
// </summary>
// <history>
//   [ruhim]    08Jun06 Created
//   [faizalk]  10Jul06 Add support for ASP.NET Exception monitoring
//   [lucyra]   15AUG06: Add support for Computers view in UI Test MP
//   [barryli]  26FEB07: Add support for Rule Templates
//   [ruhim]    02April07: Add MonitorTypeStateID constants
//   [barryli]  06June07: Add support for all rules  
//   [kellymor] 28-Apr-08   Add GUID's for System Center Core Library,
//                          Operations Manager 2007, and Operations
//                          Manager Internal Library management packs
//                          Added dotted names for
//                          Microsoft.SystemCenter.OperationsManager.
//                          2007 and
//                          Microsoft.SystemCenter.OperationsManager.
//                          Internal management packs.
//                          Added placeholders for Administration
//                          space folder names
//  [kellymor]  30-Apr-08   Updated view names to use add
//                          .OperationsManager. to the namespace for
//                          OM-specific views, i.e. views not in SCE.
//                          Added view for pending management.
//  [kellymor]  02-May-08   Updated MP GUIDs to use common MP name
//                          scheme.
//  [kellymor]  21-May-08   Added new MP name for new
//                          Microsoft.SystemCenter.OperationsManager.
//                          Library MP.
//  [kellymor]  22-May-08   Added new MP GUID reference for 
//                          Microsoft.SystemCenter.OperationsManager.
//                          Library MP.
//  [kellymor]  07-Aug-08   Added new admin view reference for 
//                          System.Views.Administration.ChannelsView.
//  [a-omkasi]  09-Aug-08   Added new system name for 
//                          Microsoft.SystemCenter.
//                          RootManagementServerComputersGroup.
//  [sunsing]   09-Aug-08   Added new system name for 
//                          system.library
//  [nathd]     21-Aug-08   Added view name for Overrides View. 
//                          Microsoft.SystemCenter.OverridesView
//  [sunsing]  11-Sep-08   Added new system name for 
//                           Microsoft.SystemCenter.DataWarehouse.ServiceLevel.Report.Library
//  [sunsing]  11-Sep-08   Added new system name for 
//                          Additonal time interval and Microsoft.SystemCenter.DataWarehouse.Report.ServiceLevelTrackingSummary
//  [jnwoko]    09 - Oct - 08 Added Constants for Wizard Page sets
//  [a-joelj]   25MAR09     Added MP names for SystemCenter2007 and ServiceDesignerLibrary MPs, Alert names
//                          and Web Application name references 
//  [v-yoz] 1-April-09 Added new Monitor Type Name for Microsoft.SystemCenter.NTService.ServiceStateMonitor, Class Name for Microsoft.SystemCenter.AgentManagedComputerGroup, Microsoft.Windows.Computer, Microsoft.SystemCenter.AllComputersGroup and StringResource Name for Microsoft.SystemCenter.NTService.ServiceStateMonitor.AlertMessage.                                                            
//  [v-waltli] 19JUN09 Added new system name for Microsoft.SystemCenter.CollectAlerts
//  [a-mujtch]  22JUN09     Added Service Designer Messaging and GenericService reference
//  [v-brucec]  11SEP09    Added object Id for Monitor Type State ID.
//  [a-joelj]   25NOV09     Added ConsoleTask IDs for Ping Computer, Ping Computer with Route and Ping Computer Continuously
//  [v-dayow]  19NVO09  Add Windows Performace counters monitor type and forlder names.
//  [rahsing]   01OCT15     Modified the system name for System.Views.Administration.MPsView
//                          Added new Management Packs folder Microsoft.SystemCenter.OperationsManager.Administration.ManagementPacks
//  [rahsing]   10DEC15     Added new Updates and Recommendations folder Microsoft.SystemCenter.Administration.UpdatesAndRecommendationsViewType
//  [satim]     03MAR16     Added Tune Management Packs and Tune Alerts view folders 
// </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Common
{
    #region Using directives
    using System;
    using System.Xml;
    using Microsoft.EnterpriseManagement.Mom.Internal;
    //using Microsoft.EnterpriseManagement.Configuration;
    #endregion

    /// <summary>
    /// Management Pack Constants
    /// </summary>
    public sealed class ManagementPackConstants
    {
        /// <summary>
        /// MomBuildConstants.MomManagementPackPublicKeyToken
        /// </summary>
        public static string MomManagementPackPublicKeyToken
        {
            get
            {
                return MomBuildConstants.MomManagementPackPublicKeyToken;
            }
        }
             
        #region Management Pack Guids

        /// <summary>
        /// Contains GUID for: System.Performance.Library MP
        /// </summary>
        public static readonly string GUIDSystemPerformanceLibraryMP = ManagementPackReferences.SYSTEM_PERFORMANCE_LIBRARY_REFERENCE;
        /// <summary>
        /// Contains GUID for: Microsoft.Windows.Library MP
        /// </summary>            
        public static readonly string GUIDMicrosoftWindowsLibraryMP = ManagementPackReferences.MICROSOFT_WINDOWS_LIBRARY_REFERENCE;

        /// <summary>
        /// Contains GUID for: Microsoft.SystemCenter.NTService.Library MP
        /// </summary>            
        public static readonly string GUIDSystemCenterNTServiceLibraryMP = ManagementPackReferences.MICROSOFT_SYSTEMCENTER_NTSERVICE_LIBRARY_REFERENCE;

        /// <summary>
        /// Contains GUID for: System.Library MP
        /// </summary>            
        public static readonly string GUIDSystemLibraryMP = ManagementPackReferences.SYSTEM_LIBRARY_REFERENCE;

        /// <summary>
        /// Contains GUID for: Microsoft.SystemCenter.NetWorkDevice.Library MP
        /// </summary>            
        public static readonly string GUIDSystemCenterNetworkDeviceLibraryMP = ManagementPackReferences.MICROSOFT_SYSTEMCENTER_NETWORKDEVICE_LIBRARY_REFERENCE;

        /// <summary>
        /// Contains GUID for:  Microsoft.SystemCenter.Library MP
        /// </summary>
        public static readonly string GUIDSystemCenterLibraryMP = ManagementPackReferences.MICROSOFT_SYSTEMCENTER_LIBRARY_REFERENCE;

        /// <summary>
        /// Contains GUID for:  Microsoft.NetworkManagement.Library MP
        /// </summary>        
        public static readonly string GUIDSystemCenterNetworkManagementLibraryMP = ManagementPackReferences.SYSTEM_NETWORKMANAGEMENT_LIBRARY_REFERENCE;

        /// <summary>
        /// Contains GUID for:  Microsoft.SystemCenter.OperationsManager.2007 MP
        /// </summary>
        public static readonly string GUIDOperationsManager2007MP = ManagementPackReferences.MICROSOFT_SYSTEMCENTER_OPERATIONSMANAGER_2007_REFERENCE;

        /// <summary>
        /// Contains GUID for:  Microsoft.SystemCenter.OperationsManager.Internal MP
        /// </summary>
        public static readonly string GUIDOperationsManagerInternalMP = ManagementPackReferences.MICROSOFT_SYSTEMCENTER_OPERATIONSMANAGER_INTERNAL_REFERENCE;

        /// <summary>
        /// Contains GUID for:  Micrsoft.SystemCenter.OperationsManger.Library MP
        /// </summary>
        public static readonly string GUIDOperationsManagerLibraryMP = ManagementPackReferences.MICROSOFT_SYSTEMCENTER_OPERATIONSMANAGER_ADMINISTRATION_ROOT_REFERENCE;

        /// <summary>
        /// Contains GUID for:  SystemCenter.Visualization.Library MP
        /// </summary>
        public static readonly string GUIDSystemCenterVisualizationLibraryMP = ManagementPackReferences.MICROSOFT_SYSTEMCENTER_VISUALIZATION_LIBRARY_REFERENCE;

        /// <summary>
        /// Contains GUID for:  Microsoft.SystemCenter.Apm.Web.IIS7
        /// </summary>        
        public static readonly string GUIDSystemCenterApmWebIIS7MP = ManagementPackReferences.MICROSOFT_SYSTEMCENTER_APM_WEB_IIS7_REFERENCE;

        /// <summary>
        /// Contains GUID for: UI.Test.MP MP
        /// </summary>            
        public static string GUIDUITestMP = XmlConvert.ToString(IdUtil.GetMPIdAsGuid(UITestMPName, null, null));
                      
        /// <summary>
        /// Contains GUID for: Microsoft.SystemCenter.Internal MP
        /// </summary>            
        public static readonly string GUIDSystemCenterInternalMP = ManagementPackReferences.MICROSOFT_SYSTEMCENTER_INTERNAL_REFERENCE;

        /// <summary>
        /// Contains GUID for: Microsoft.SystemCenter.OperationsManager.DefaultUser MP
        /// </summary>            
        public static readonly string GUIDSystemCenterOperationsManagerDefaultUserMP = ManagementPackReferences.MICROSOFT_SYSTEMCENTER_OPERATIONSMANAGER_DEFAULTUSER_REFERENCE;

        /// <summary>
        /// Contains GUID for: Microsoft.SystemCenter.2007.MP MP
        /// </summary>
        public static readonly string GUIDSystemCenter2007MP = ManagementPackReferences.MICROSOFT_SYSTEMCENTER_2007_REFERENCE;

        /// <summary>
        /// Contains GUID for: Microsoft.Windows.Cluster.Library MP
        /// </summary>            
        public static readonly string GUIDWindowsClusterLibraryMP = ManagementPackReferences.MICROSOFT_WINDOWS_CLUSTER_REFERENCE;
        
        /// <summary>
        /// Contains GUID for: Microsoft.SQLServer.2008.Discovery MP
        /// </summary>
        public static readonly string GUIDMicrosoftSQLServer2008DiscoveryMP = XmlConvert.ToString(IdUtil.GetMPIdAsGuid(MicrosoftSQLServer2008DiscoveryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, null));

        /// <summary>
        /// Contains GUID for: Microsoft.SQLServer.2008.Monitoring MP
        /// </summary>
        public static readonly string GUIDMicrosoftSQLServer2008MonitoringMP = XmlConvert.ToString(IdUtil.GetMPIdAsGuid(MicrosoftSQLServer2008MonitoringMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, null));

        /// <summary>
        /// Contains GUID for: Microsoft.SQLServer.2012.Discovery MP
        /// </summary>
        public static readonly string GUIDMicrosoftSQLServer2012DiscoveryMP = XmlConvert.ToString(IdUtil.GetMPIdAsGuid(MicrosoftSQLServer2012DiscoveryMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, null));

        /// <summary>
        /// Contains GUID for: Microsoft.SQLServer.2012.Monitoring MP
        /// </summary>
        public static readonly string GUIDMicrosoftSQLServer2012MonitoringMP = XmlConvert.ToString(IdUtil.GetMPIdAsGuid(MicrosoftSQLServer2012MonitoringMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, null));

        /// <summary>
        /// Contains GUID for: Microsoft.SystemCenter.ProcessMonitoring.Library MP
        /// </summary>
        public static readonly string GUIDSystemCenterProcessMonitoringLibraryMP = ManagementPackReferences.MICROSOFT_SYSTEMCENTER_PROCESSMONITORING_LIBRARY_REFERENCE;

        /// <summary>
        /// Contains GUID for: Microsoft.SystemCenter.Visualization.Network.Dashboard MP
        /// </summary>
        public static readonly string GUIDSystemCenterVisualizationNetworkDashboard = ManagementPackReferences.MICROSOFT_SYSTEMCENTER_VISUALIZATION_NETWORK_DASHBOARD_REFERENCE;

        /// <summary>
        /// Contains GUID for: System.NetworkManagement.Monitoring MP
        /// </summary>
        public static readonly string GUIDSystemNetworkManagementMonitoring = ManagementPackReferences.SYSTEM_NETWORKMANAGEMENT_MONITORING_REFERENCE;

        /// <summary>
        /// Contains GUID for: Microsoft.SystemCenter.Visualization.Configuration.Library MP
        /// </summary>
        public static readonly string GUIDSystemCenterVisualizationConfigurationLibraryMP = ManagementPackReferences.MICROSOFT_SYSTEMCENTER_VISUALIZATION_CONFIGURATION_LIBRARY_REFERENCE;

        /// <summary>
        /// Contains GUID for: System.Views.AlertView MP
        /// </summary>
        public static readonly string GUIDSystemViewsAlertview = ManagementPackReferences.SYSTEM_VIEWS_ALERTVIEW_REFERENCE;

        #endregion 

        #region Management Pack Names

        /// <summary>
        /// Name for Microsoft.SystemCenter.WebApplicationSolutions.Library.mp
        /// </summary>
        public const string WebApplicationSolutionsLibraryMPName = "Microsoft.SystemCenter.WebApplicationSolutions.Library";

        /// <summary>
        /// Name for Microsoft.SystemCenter.WebApplicationSolutions.Base.Library.mp
        /// </summary>
        public const string WebApplicationSolutionsBaseLibraryMPName = "Microsoft.SystemCenter.WebApplicationSolutions.Base.Library";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.Library MP
        /// </summary>            
        public const string MicrosoftWindowsLibraryMPName = "Microsoft.Windows.Library";
        /// <summary>
        /// Contains System Name for: System.Library MP
        /// </summary>            
        public const string SystemLibraryMPName = "System.Library";

        /// <summary>
        /// Contains System Name for: System.Health.Library MP
        /// </summary>            
        public const string SystemHealthLibraryMPName = "System.Health.Library";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.NTService.Library MP
        /// </summary>            
        public const string SystemCenterNTServiceLibraryMPName = "Microsoft.SystemCenter.NTService.Library";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.SyntheticTransactions.Library MP
        /// </summary>            
        public const string SystemCenterSyntheticTransactionsLibraryMPName = "Microsoft.SystemCenter.SyntheticTransactions.Library";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.WebApplication.Library MP
        /// </summary>            
        public const string SystemCenterWebApplicationLibraryMPName = "Microsoft.SystemCenter.WebApplication.Library";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ClientMonitoring.Internal MP
        /// </summary>            
        public const string SystemCenterClientMonitoringInternalMPName = "Microsoft.SystemCenter.ClientMonitoring.Internal";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ClientMonitoring.Views.Internal MP
        /// </summary>            
        public const string SystemCenterClientMonitoringViewsInternalMPName = "Microsoft.SystemCenter.ClientMonitoring.Views.Internal";

        /// <summary>
        /// System.Performance.Library
        /// </summary>
        public const string SystemPerformanceLibraryMPName = "System.Performance.Library";

        /// <summary>
        /// Contains System Name for: UI.Test.MP MP
        /// </summary>            
        public const string UITestMPName = "UI.Test.MP";

        /// <summary>
        /// Contains System Name for: Test.UI.HealthExplorer.Management.Pack MP
        /// </summary>            
        public const string HealthExplorerTestMPName = "Test.UI.HealthExplorer.Management.Pack";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Internal MP
        /// </summary>            
        public const string SystemCenterInternalMPName = "Microsoft.SystemCenter.Internal";
        
        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Library MP
        /// </summary>            
        public const string SystemCenterLibraryMPName = "Microsoft.SystemCenter.Library";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.2007 MP
        /// </summary>            
        public const string SystemCenter2007MPName = "Microsoft.SystemCenter.2007";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.InternetInformationServices.CommonLibrary
        /// </summary>            
        public const string MicrosoftWindowsIISCommonMPName = "Microsoft.Windows.InternetInformationServices.CommonLibrary";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.InternetInformationServices.2003
        /// </summary>            
        public const string MicrosoftWindowsIIS2003MPName = "Microsoft.Windows.InternetInformationServices.2003";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ASPNET20.2007.Library MP
        /// </summary>            
        public const string SystemCenterASPNETMPName = "Microsoft.SystemCenter.ASPNET20.2007";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.TaskTemplates MP
        /// </summary>            
        public const string SystemCenterTaskTemplatesMPName = "Microsoft.SystemCenter.TaskTemplates";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates MP
        /// </summary>            
        public const string SystemCenterRuleTemplatesMPName = "Microsoft.SystemCenter.RuleTemplates";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.OperationsManager.2007 MP
        /// </summary> 
        public const string SystemCenterOperationsManager2007MPName = "Microsoft.SystemCenter.OperationsManager.2007";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.OperationsManager.Internal MP
        /// </summary> 
        public const string SystemCenterOperationsManagerInternalMPName = "Microsoft.SystemCenter.OperationsManager.Internal";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.OperationsManager.Library MP
        /// </summary> 
        public const string SystemCenterOperationsManagerLibraryMPName = "Microsoft.SystemCenter.OperationsManager.Library";

        ///<summary>
        /// Contains System Name for: Microsoft.SystemCenter.DataWarehouse.Report.Library MP
        ///</summary>
        public const string SystemCenterOperationsManagerDataWarehouseLibraryMPName = "Microsoft.SystemCenter.DataWarehouse.Report.Library";

        ///<summary>
        /// Contains System Name for: Microsoft.SystemCenter.ProcessMonitoring.Library MP
        /// </summary>
        public const string SystemCenterProcessMonitoringLibraryMPName = "Microsoft.SystemCenter.ProcessMonitoring.Library";

        ///<summary>
        /// Contains System Name for: Microsoft.SystemCenter.DataWarehouse.ServiceLevel.Report.Library
        ///</summary>
        public const string SystemCenterOperationsManagerDataWarehouseSLAMPName = "Microsoft.SystemCenter.DataWarehouse.ServiceLevel.Report.Library";

        ///<summary>
        /// Contains System Name for: Microsoft.SystemCenter.ProcessMonitoring.Library MP
        /// </summary>
        public const string SystemCenterPowerManagemetnLibraryMPName = "Microsoft.SystemCenter.PowerManagement.Library";

        ///<summary>
        /// Contains System Name for: Microsoft.SystemCenter.ServiceDesigner.Library MP
        /// </summary>
        public const string SystemCenterServiceDesignerLibraryMPName = "Microsoft.SystemCenter.ServiceDesigner.Library";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.Cluster.Library MP
        /// </summary>
        public const string MicrosoftWindowsClusterLibraryMPName = "Microsoft.Windows.Cluster.Library";

        /// <summary>
        /// Contains System Name for: Microsoft.SQLServer.2008.Discovery
        /// </summary>
        public const string MicrosoftSQLServer2008DiscoveryMPName = "Microsoft.SQLServer.2008.Discovery";

        /// <summary>
        /// Contains System Name for: Microsoft.SQLServer.2008.Monitoring
        /// </summary>
        public const string MicrosoftSQLServer2008MonitoringMPName = "Microsoft.SQLServer.2008.Monitoring";

        /// <summary>
        /// Contains System Name for: Microsoft.SQLServer.2012.Discovery
        /// </summary>
        public const string MicrosoftSQLServer2012DiscoveryMPName = "Microsoft.SQLServer.2012.Discovery";

        /// <summary>
        /// Contains System Name for: Microsoft.SQLServer.2012.Monitoring
        /// </summary>
        public const string MicrosoftSQLServer2012MonitoringMPName = "Microsoft.SQLServer.2012.Monitoring";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.OperationsManager.DefaultUser
        /// </summary>
        public const string SystemCenterDefaultUserMPName = "Microsoft.SystemCenter.OperationsManager.DefaultUser";

        /// <summary>
        /// Contains System Name for: System.NetworkManagement.Monitoring
        /// </summary>
        public const string SystemNetworkManagementMonitoringMPName = "System.NetworkManagement.Monitoring";

        /// <summary>
        /// Contains System Name for: System.NetworkManagement.Library
        /// </summary>
        public const string SystemNetworkManagementLibraryMPName = "System.NetworkManagement.Library";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.Client.Library
        /// </summary>
        public const string MicrosoftWindowsClientLibraryMPName = "Microsoft.Windows.Client.Library";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Visualization.Network.Dashboard
        /// </summary>
        public const string MicrosoftSystemCenterVisualizationNetworkDashboard = "Microsoft.SystemCenter.Visualization.Network.Dashboard";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Visualization.Library
        /// </summary>
        public const string MicrosoftSystemCenterVisualizationLibrary = "Microsoft.SystemCenter.Visualization.Library";

        /// <summary>
        /// Contains System Name for: System.NetworkManagement.Monitoring
        /// </summary>
        public const string SystemNetworkManagementMonitoring = "System.NetworkManagement.Monitoring";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ApplicationMonitoring.360.Template.Library
        /// </summary>
        public const string MicrosoftSystemCenterApplicationMonitoring360TemplateLibrary = "Microsoft.SystemCenter.ApplicationMonitoring.360.Template.Library";

        /// <summary>
        /// Contains System Name for: System.AdminItem.Library
        /// </summary>
        public const string SystemAdminItemLibraryMP = "System.AdminItem.Library";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ApplicationMonitoring.Library
        /// </summary>
        public const string ApplicationMonitoringLibraryMP = "Microsoft.SystemCenter.ApplicationMonitoring.Library";

        #endregion 

        #region MonitorType Names
        /// <summary>
        /// Contains System Name for: Microsoft.Windows.SingleEventLogManualReset2StateMonitorType
        /// </summary>            
        public const string WindowsEventsSingleEventManualResetName = "Microsoft.Windows.SingleEventLogManualReset2StateMonitorType";

        /// <summary>
        /// Contains System Name for: System.NetworkManagement.SnmpProbe.2SingleEvent2StateMonitorType
        /// </summary>
        public const string SNMPProbeMonitorName = "System.NetworkManagement.SnmpProbe.2SingleEvent2StateMonitorType";

        /// <summary>
        /// Contains System Name for: System.NetworkManagement.SnmpTrapProvider.2SingleEvent2StateMonitorType
        /// </summary>
        public const string SNMPTrapMonitorName = "System.NetworkManagement.SnmpTrapProvider.2SingleEvent2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.2SingleEventLog2StateMonitorType
        /// </summary>            
        public const string WindowsEventsSingleEventEventResetName = "Microsoft.Windows.2SingleEventLog2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.CheckNTServiceStateMonitorType
        /// </summary>            
        public const string WindowsNTServiceStateName = "Microsoft.Windows.CheckNTServiceStateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.SingleEventLogTimer2StateMonitorType
        /// </summary>
        public const string EventMonitorSingleEventAutoResetName = "Microsoft.Windows.SingleEventLogTimer2StateMonitorType";

        /// <summary>
        /// Contains System Name for: System.Performance.ThreeStateBaseliningMonitorWithoutCompression
        /// </summary>
        public const string PerformanceBaselineMonitor3StateBaseliningName = "System.Performance.ThreeStateBaseliningMonitorWithoutCompression";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.CorrelatedEventLogManualReset2StateMonitorType
        /// </summary>            
        public const string WindowsEventsCorrelatedManualResetName = "Microsoft.Windows.CorrelatedEventLogManualReset2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.CorrelatedEventLogTimer2StateMonitorType
        /// </summary>            
        public const string WindowsEventsCorrelatedTimerResetName = "Microsoft.Windows.CorrelatedEventLogTimer2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.CorrelatedEventLogSingleEventLog2StateMonitorType
        /// </summary>            
        public const string WindowsEventsCorrelatedEventResetName = "Microsoft.Windows.CorrelatedEventLogSingleEventLog2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.MissingCorrelatedEventLogManualReset2StateMonitorType
        /// </summary>            
        public const string WindowsEventsCorrelatedMissingManualResetName = "Microsoft.Windows.MissingCorrelatedEventLogManualReset2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.MissingCorrelatedEventLogTimer2StateMonitorType
        /// </summary>            
        public const string WindowsEventsCorrelatedMissingTimerResetName = "Microsoft.Windows.MissingCorrelatedEventLogTimer2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.MissingCorrelatedEventLogSingleEventLog2StateMonitorType
        /// </summary>            
        public const string WindowsEventsCorrelatedMissingEventResetName = "Microsoft.Windows.MissingCorrelatedEventLogSingleEventLog2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.MissingEventLogManualReset2StateMonitorType
        /// </summary>            
        public const string WindowsEventsMissingManualResetName = "Microsoft.Windows.MissingEventLogManualReset2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.MissingEventLogTimer2StateMonitorType
        /// </summary>            
        public const string WindowsEventsMissingTimerResetName = "Microsoft.Windows.MissingEventLogTimer2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.MissingEventLogSingleEventLog2StateMonitorType
        /// </summary>            
        public const string WindowsEventsMissingEventResetName = "Microsoft.Windows.MissingEventLogSingleEventLog2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.RepeatedEventLogManualReset2StateMonitorType
        /// </summary>            
        public const string WindowsEventsRepeatedManualResetName = "Microsoft.Windows.RepeatedEventLogManualReset2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.RepeatedEventLogTimer2StateMonitorType
        /// </summary>            
        public const string WindowsEventsRepeatedTimerResetName = "Microsoft.Windows.RepeatedEventLogTimer2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.RepeatedEventLogSingleEventLog2StateMonitorType
        /// </summary>            
        public const string WindowsEventsRepeatedEventResetName = "Microsoft.Windows.RepeatedEventLogSingleEventLog2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.WmiEventProvider.SingleEventManualReset2StateMonitorType
        /// </summary>            
        public const string WindowsWMIEventsSingleManualResetName = "Microsoft.Windows.WmiEventProvider.SingleEventManualReset2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.WmiEventProvider.SingleEventTimer2StateMonitorType
        /// </summary>            
        public const string WindowsWMIEventsSingleTimerResetName = "Microsoft.Windows.WmiEventProvider.SingleEventTimer2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.WmiEventProvider.2SingleEvent2StateMonitorType
        /// </summary>            
        public const string WindowsWMIEventsSingleWMIEventResetName = "Microsoft.Windows.WmiEventProvider.2SingleEvent2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.WmiEventProvider.RepeatedEventManualReset2StateMonitorType
        /// </summary>            
        public const string WindowsWMIEventsRepeatedManualResetName = "Microsoft.Windows.WmiEventProvider.RepeatedEventManualReset2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.WmiEventProvider.RepeatedEventTimer2StateMonitorType
        /// </summary>            
        public const string WindowsWMIEventsRepeatedTimerResetName = "Microsoft.Windows.WmiEventProvider.RepeatedEventTimer2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.WmiEventProvider.RepeatedEventSingleEvent2StateMonitorType
        /// </summary>            
        public const string WindowsWMIEventsRepeatedWMIEventResetName = "Microsoft.Windows.WmiEventProvider.RepeatedEventSingleEvent2StateMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.WmiBased.Performance.AverageThreshold
        /// </summary>
        public const string WindowsWMIPerformanceAverageThresholdName = "Microsoft.Windows.WmiBased.Performance.AverageThreshold";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.WmiBased.Performance.ConsecutiveSamplesThreshold
        /// </summary>
        public const string WindowsWMIPerformanceConsecutiveSamplesThresholdName = "Microsoft.Windows.WmiBased.Performance.ConsecutiveSamplesThreshold";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.WmiBased.Performance.DeltaThreshold
        /// </summary>
        public const string WindowsWMIPerformanceDeltaThresholdName = "Microsoft.Windows.WmiBased.Performance.DeltaThreshold";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.WmiBased.Performance.ThresholdMonitorType
        /// </summary>
        public const string WindowsWMIPerformanceSimpleThresholdName = "Microsoft.Windows.WmiBased.Performance.ThresholdMonitorType";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.WmiBased.Performance.DoubleThreshold
        /// </summary>
        public const string WindowsWMIPerformanceDoulbeThresholdName = "Microsoft.Windows.WmiBased.Performance.DoubleThreshold";

        /// <summary>
        /// Contains System Name for: System.Performance.TwoStateAboveBaseliningMonitorWithoutCompression
        /// </summary>
        public const string WindowsPerformance2stateAboveThresholdName = "System.Performance.TwoStateAboveBaseliningMonitorWithoutCompression";

        /// <summary>
        /// Contains System Name for: System.Performance.TwoStateBaseliningMonitorWithoutCompression
        /// </summary>
        public const string WindowsPerformance2stateBaseliningThresholdName = "System.Performance.TwoStateBaseliningMonitorWithoutCompression";

        /// <summary>
        /// Contains System Name for: System.Performance.TwoStateBelowBaseliningMonitorWithoutCompression
        /// </summary>
        public const string WindowsPerformance2stateBelowThresholdName = "System.Performance.TwoStateBelowBaseliningMonitorWithoutCompression";

        /// <summary>
        /// Contains System Name for: System.Performance.ThreeStateBaseliningMonitorWithoutCompression
        /// </summary>
        public const string WindowsPerformance3stateBaseliningThresholdName = "System.Performance.ThreeStateBaseliningMonitorWithoutCompression";

        /// <summary>
        /// Contains System Name for: System.Performance.AverageThreshold
        /// </summary>
        public const string WindowsPerformanceAverageThresholdName = "System.Performance.AverageThreshold";

        /// <summary>
        /// Contains System Name for: System.Performance.ConsecutiveSamplesThreshold
        /// </summary>
        public const string WindowsPerformanceConsecutiveSamplesoverThresholdName = "System.Performance.ConsecutiveSamplesThreshold";

        /// <summary>
        /// Contains System Name for: System.Performance.DeltaThreshold
        /// </summary>
        public const string WindowsPerformanceDeltaThresholdName = "System.Performance.DeltaThreshold";

        /// <summary>
        /// Contains System Name for: System.Performance.ThresholdMonitorType
        /// </summary>
        public const string WindowsPerformanceSimpleThresholdName = "System.Performance.ThresholdMonitorType";

        /// <summary>
        /// Contains System Name for: System.Performance.DoubleThreshold
        /// </summary>
        public const string WindowsPerformanceDoubleThresholdName = "System.Performance.DoubleThreshold"; 
        #endregion 

        #region Alert Names

        ///<summary>
        /// Contains System Name for: Microsoft.SystemCenter.CM.AEM.FileShareError
        ///</summary>
        public const string AEMFileShareError = "Microsoft.SystemCenter.CM.AEM.FileShareError";

        ///<summary>
        /// Contains System Name for: Microsoft.SystemCenter.CM.AEM.FileShareError.Alert
        ///</summary>
        public const string AEMFileShareErrorAlert = "Microsoft.SystemCenter.CM.AEM.FileShareError.Alert";

        ///<summary>
        /// Contains System Name for: Microsoft.SystemCenter.NTService.ServiceStateMonitor.AlertMessage
        ///</summary>
        public const string WindowsServiceStoppedAlert = "Microsoft.SystemCenter.NTService.ServiceStateMonitor.AlertMessage";

        #endregion

        #region Monitor Names
        /// <summary>
        /// Contains System Name for: System.Health.EntityState
        /// </summary>            
        public const string SystemHealthEntityStateMonitorName = "System.Health.EntityState";

        /// <summary>
        /// Contains System Name for: System.Health.AvailabilityState
        /// </summary>            
        public const string SystemHealthAvailabilityStateMonitorName = "System.Health.AvailabilityState";

        /// <summary>
        /// Contains System Name for: System.Health.PerformanceState
        /// </summary>            
        public const string SystemHealthPerformanceStateMonitorName = "System.Health.PerformanceState";

        /// <summary>
        /// Contains System Name for: System.Health.ConfigurationState
        /// </summary>            
        public const string SystemHealthConfigurationStateMonitorName = "System.Health.ConfigurationState";

        /// <summary>
        /// Contains System Name for: System.Health.SecurityState
        /// </summary>            
        public const string SystemHealthSecurityStateMonitorName = "System.Health.SecurityState";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.NTService.OwnProcess.HandleCountMonitor
        /// </summary>            
        public const string NTServiceHandleCountMonitorName = "Microsoft.SystemCenter.NTService.OwnProcess.HandleCountMonitor";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.NTService.OwnProcess.ThreadCountMonitor
        /// </summary>            
        public const string NTServiceThreadCountMonitorName = "Microsoft.SystemCenter.NTService.OwnProcess.ThreadCountMonitor";
        
        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.NTService.OwnProcess.PercentProcessorTimeMonitor
        /// </summary>            
        public const string NTServicePercentProcessorTimeMonitorName = "Microsoft.SystemCenter.NTService.OwnProcess.PercentProcessorTimeMonitor";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.NTService.OwnProcess.WorkingSetMonitor
        /// </summary>            
        public const string NTServiceWorkingSetMonitorName = "Microsoft.SystemCenter.NTService.OwnProcess.WorkingSetMonitor";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.NTService.ServiceStateMonitor
        /// </summary>            
        public const string NTServiceStateMonitorName = "Microsoft.SystemCenter.NTService.ServiceStateMonitor";

        /// <summary>
        /// Contains System Name for: Microsoft.SQLServer.2008.Database.DBStatusMonitor
        /// </summary>
        public const string DatabaseStatusMonitorName = "Microsoft.SQLServer.2008.Database.DBStatusMonitor";

        /// <summary>
        /// Contains System Name for: Microsoft.SQLServer.2008.Database.DBStatusMonitor
        /// </summary>
        public const string Sql2008StatusMonitorName = "Microsoft.SQLServer.2008.Database.DBStatusMonitor";

        /// <summary>
        /// Contains System Name for: Microsoft.SQLServer.2012.Database.DBStatusMonitor
        /// </summary>
        public const string Sql2012StatusMonitorName = "Microsoft.SQLServer.2012.Database.DBStatusMonitor";

        /// <summary> 
        /// Simple trap snmp monitor name 
        /// </summary> 
        public const string SimpleTrapSNMPMonitorName = "Microsoft.SystemCenter.Authoring.MonitorTypeFolder.Snmp.Trap.Simple"; 
 
        /// <summary> 
        /// Simple proble snmp monitor name 
        /// </summary> 
        public const string SimpleProbeSNMPMonitorName = "Microsoft.SystemCenter.Authoring.MonitorTypeFolder.Snmp.Probe.Simple"; 
        
        #endregion

        #region Rules Names
        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.NTService.CollectPercentProcessorTime
        /// </summary>            
        public const string CollectPercentProcessorTimeRuleName = "Microsoft.SystemCenter.NTService.CollectPercentProcessorTime";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.CollectAlerts
        /// </summary>            
        public const string CollectAlertsRuleName = "Microsoft.SystemCenter.CollectAlerts";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.NTService.CollectPrivateBytes
        /// </summary>            
        public const string CollectProcessPrivateBytesRuleName = "Microsoft.SystemCenter.NTService.CollectPrivateBytes";

        #endregion

        #region Console Task Names
        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.HealthService.PingDefault
        /// </summary>            
        public const string PingComputerDefaultHealthServiceConsoleTaskName = "Microsoft.SystemCenter.HealthService.PingDefault";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.HealthService.PingContinuously
        /// </summary>            
        public const string PingComputerContinuouslyHealthServiceConsoleTaskName = "Microsoft.SystemCenter.HealthService.PingContinuously";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.HealthService.PingWithRoute
        /// </summary>            
        public const string PingComputerWithRouteHealthServiceConsoleTaskName = "Microsoft.SystemCenter.HealthService.PingWithRoute";

        #endregion

        #region Template Names
        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.NTService.OwnProcess.Template
        /// </summary>            
        public const string NTServiceOwnProcessTemplateName = "Microsoft.SystemCenter.NTService.OwnProcess.Template";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.SyntheticTransactions.TCPPortCheck.Template
        /// </summary>            
        public const string SyntheticTransactionsTCPPortCheckTemplateName = "Microsoft.SystemCenter.SyntheticTransactions.TCPPortCheck.Template";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.SyntheticTransactions.OleDbCheck.Template
        /// </summary>            
        public const string SyntheticTransactionsOleDbCheckTemplateName = "Microsoft.SystemCenter.SyntheticTransactions.OleDbCheck.Template";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.WebApplication.SingleUrl.Template
        /// </summary>            
        public const string WebApplicationSingleUrlTemplateName = "Microsoft.SystemCenter.WebApplication.SingleUrl.Template";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Lob.AspWebService.Template
        /// </summary>            
        public const string AspWebServiceTemplate = "Microsoft.SystemCenter.ASPNET20.2007.AspWebService.Template";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Lob.AspApplication.Template
        /// </summary>            
        public const string AspApplicationTemplate = "Microsoft.SystemCenter.ASPNET20.2007.AspApplication.Template";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ProcessMonitor.Template
        /// </summary>            
        public const string ProcessMonitorTemplate = "Microsoft.SystemCenter.ProcessMonitor.Template";
        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.PowerManagement.PowerSet.Template
        /// </summary>            
        public const string PowerConsumptionTemplate = "Microsoft.SystemCenter.PowerManagement.PowerSet.Template";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.TaskTemplates.CommandLineTask
        /// </summary>            
        public const string AgentCommandLineTask = "Microsoft.SystemCenter.TaskTemplates.CommandLineTask";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.TaskTemplates.ScriptTask
        /// </summary>            
        public const string ScriptTask = "Microsoft.SystemCenter.TaskTemplates.ScriptTask";

        /// <summary>
        /// Contains System Name for: System.CommandExecuterProbe
        /// </summary>            
        public const string RunCommand = "System.CommandExecuterProbe";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.ScriptProbeAction
        /// </summary>            
        public const string RunScript = "Microsoft.Windows.ScriptProbeAction";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.TaskTemplates.ConsoleCommandLineTask
        /// </summary>            
        public const string ConsoleCommandLineTask = "Microsoft.SystemCenter.TaskTemplates.ConsoleCommandLineTask";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.TaskTemplates.ConsoleAlertCommandLineTask
        /// </summary>            
        public const string ConsoleAlertTask = "Microsoft.SystemCenter.TaskTemplates.ConsoleAlertCommandLineTask";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.TaskTemplates.ConsoleEventCommandLineTask
        /// </summary>            
        public const string ConsoleEventTask = "Microsoft.SystemCenter.TaskTemplates.ConsoleEventCommandLineTask";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.WindowsPerformanceCollection
        /// </summary>            
        public const string WindowsPerformanceRuleName = "Microsoft.SystemCenter.RuleTemplates.WindowsPerformanceCollection";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.WindowsEventCollection
        /// </summary>            
        public const string NTEventRuleName = "Microsoft.SystemCenter.RuleTemplates.WindowsEventCollection";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.WMIPerfCollection
        /// </summary>            
        public const string WMIPerformanceRuleName = "Microsoft.SystemCenter.RuleTemplates.WMIPerfCollection";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.SnmpEventCollection
        /// </summary>            
        public const string SnmpEventRuleName = "Microsoft.SystemCenter.RuleTemplates.SnmpEventCollection";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.SnmpTrapCollection
        /// </summary>            
        public const string SnmpTrapEventRuleName = "Microsoft.SystemCenter.RuleTemplates.SnmpTrapCollection";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.SnmpPerfCollection
        /// </summary>            
        public const string SnmpPerformanceRuleName = "Microsoft.SystemCenter.RuleTemplates.SnmpPerfCollection";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.ScriptPerfCollection
        /// </summary>            
        public const string ScriptPerformanceRuleName = "Microsoft.SystemCenter.RuleTemplates.ScriptPerfCollection";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.ScriptEventCollection
        /// </summary>            
        public const string ScriptEventRuleName = "Microsoft.SystemCenter.RuleTemplates.ScriptEventCollection";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.WindowsEventAlert
        /// </summary>            
        public const string NTEventAlertRuleName = "Microsoft.SystemCenter.RuleTemplates.WindowsEventAlert";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.SnmpTrapAlert
        /// </summary>            
        public const string SnmpTrapAlertRuleName = "Microsoft.SystemCenter.RuleTemplates.SnmpTrapAlert";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.TimedCommand
        /// </summary>            
        public const string TimedCommandRuleName = "Microsoft.SystemCenter.RuleTemplates.TimedCommand";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.TimedScript
        /// </summary>            
        public const string TimedScriptRuleName = "Microsoft.SystemCenter.RuleTemplates.TimedScript";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.WMIEventCollection
        /// </summary>            
        public const string WMIEventRuleName = "Microsoft.SystemCenter.RuleTemplates.WMIEventCollection";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.WMIEventAlert
        /// </summary>            
        public const string WMIEventAlertRuleName = "Microsoft.SystemCenter.RuleTemplates.WMIEventAlert";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.GenericLogCollection
        /// </summary>            
        public const string GenericLogRuleName = "Microsoft.SystemCenter.RuleTemplates.GenericLogCollection";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.GenericLogAlert
        /// </summary>            
        public const string GenericLogAlertRuleName = "Microsoft.SystemCenter.RuleTemplates.GenericLogAlert";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.GenericCSVLogCollection
        /// </summary>            
        public const string GenericCSVLogRuleName = "Microsoft.SystemCenter.RuleTemplates.GenericCSVLogCollection";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.GenericCSVLogAlert
        /// </summary>            
        public const string GenericCSVLogAlertRuleName = "Microsoft.SystemCenter.RuleTemplates.GenericCSVLogAlert";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.SyslogCollection
        /// </summary>            
        public const string SyslogRuleName = "Microsoft.SystemCenter.RuleTemplates.SyslogCollection";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.RuleTemplates.SyslogAlert
        /// </summary>            
        public const string SyslogAlertRuleName = "Microsoft.SystemCenter.RuleTemplates.SyslogAlert";

        /// <summary>
        /// Contains System Name for: Microsoft.Exchange2007.Template.CasTX
        /// </summary>            
        public const string Exchange2007CasTemplate = "Microsoft.Exchange2007.Template.CasTX";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.NTService.OwnProcess.TemplatePageSet
        /// </summary>            
        public const string NTServiceTemplatePageSet = "Microsoft.SystemCenter.NTService.OwnProcess.TemplatePageSet";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.NTService.OwnProcess.TemplatePageSet.NameAndDescription
        /// </summary>            
        public const string NTServiceTemplateTabGeneral = "Microsoft.SystemCenter.NTService.OwnProcess.TemplatePageSet.NameAndDescription";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.NTService.OwnProcess.TemplatePageSet.NameAndDescription
        /// </summary>            
        public const string NTServiceTemplateTabGeneralName = "Microsoft.SystemCenter.NTService.OwnProcess.TemplatePageSet.NameAndDescription.TabName";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.NTService.OwnProcess.TemplatePageSet.ServiceDetails
        /// </summary>            
        public const string NTServiceTemplateTabServiceDetails = "Microsoft.SystemCenter.NTService.OwnProcess.TemplatePageSet.ServiceDetails";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.NTService.OwnProcess.TemplatePageSet.ServiceDetails
        /// </summary>            
        public const string NTServiceTemplateTabServiceDetailsName = "Microsoft.SystemCenter.NTService.OwnProcess.TemplatePageSet.ServiceDetails.TabName";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.NTService.OwnProcess.TemplatePageSet.PerformanceDataCollectionAndDetectionPage
        /// </summary>            
        public const string NTServiceTemplateTabPerformanceData = "Microsoft.SystemCenter.NTService.OwnProcess.TemplatePageSet.PerformanceDataCollectionAndDetectionPage";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.NTService.OwnProcess.TemplatePageSet.PerformanceDataCollectionAndDetectionPage
        /// </summary>            
        public const string NTServiceTemplateTabPerformanceDataName = "Microsoft.SystemCenter.NTService.OwnProcess.TemplatePageSet.PerformanceDataCollectionAndDetectionPage.TabName";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ProcessMonitor.TemplatePageSet
        /// </summary>            
        public const string ProcessMonitorPageSet = "Microsoft.SystemCenter.ProcessMonitor.TemplatePageSet";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ProcessMonitor.TemplatePageSet.Reference.TargetGroupAndProcessPage
        /// </summary>            
        public const string ProcessMonitorTabGroupProcess = "Microsoft.SystemCenter.ProcessMonitor.TemplatePageSet.Reference.TargetGroupAndProcessPage";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ProcessMonitor.TemplatePageSet.Reference.TargetGroupAndProcessPage.TabName
        /// </summary>            
        public const string ProcessMonitorTabGroupProcessName = "Microsoft.SystemCenter.ProcessMonitor.TemplatePageSet.Reference.TargetGroupAndProcessPage.TabName";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ProcessMonitor.TemplatePageSet.Reference.RunningProcessesPage
        /// </summary>            
        public const string ProcessMonitorTabRunningProcess = "Microsoft.SystemCenter.ProcessMonitor.TemplatePageSet.Reference.RunningProcessesPage";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ProcessMonitor.TemplatePageSet.Reference.RunningProcessesPage.TabName
        /// </summary>            
        public const string ProcessMonitorTabRunningProcessName = "Microsoft.SystemCenter.ProcessMonitor.TemplatePageSet.Reference.RunningProcessesPage.TabName";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ProcessMonitor.TemplatePageSet.Reference.PerformanceDataCollectionAndDetectionPage
        /// </summary>            
        public const string ProcessMonitorTabPerformanceData = "Microsoft.SystemCenter.ProcessMonitor.TemplatePageSet.Reference.PerformanceDataCollectionAndDetectionPage";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ProcessMonitor.TemplatePageSet.Reference.PerformanceDataCollectionAndDetectionPage.TabName
        /// </summary>            
        public const string ProcessMonitorTabPerformanceDataName = "Microsoft.SystemCenter.ProcessMonitor.TemplatePageSet.Reference.PerformanceDataCollectionAndDetectionPage.TabName";

        #endregion 

        #region reporting space
        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.DataWarehouse.Report.ServiceLevelTrackingSummary
        /// </summary>            
        public const string ServiceLevelAgreementSummaryReport = "Microsoft.SystemCenter.DataWarehouse.Report.ServiceLevelTrackingSummary";
        /// <summary>
        /// Contains System Name for: RT.Interval.LastMonth
        /// </summary>            
        public const string ReportTimeIntervalLastMonth = "R.Interval.LastMonth";
        /// <summary>
        /// Contains System Name for: R.Interval.ReportDuration
        /// </summary>            
        public const string ReportTimeIntervalReportDuration = "R.Interval.ReportDuration";
        /// <summary>
        /// Contains System Name for: R.Interval.Last24Hours
        /// </summary>            
        public const string ReportTimeIntervalLast24Hours = "R.Interval.Last24Hours";

        /// <summary>
        /// Contains System Name for: R.Interval.Last30Days
        /// </summary>            
        public const string ReportTimeIntervalLast30Days = "R.Interval.Last30Days";

        /// <summary>
        /// Contains System Name for: R.Interval.Last60Days
        /// </summary>            
        public const string ReportTimeIntervalLast60Days = "R.Interval.Last60Days";

        /// <summary>
        /// Contains System Name for: R.Interval.Last7Days
        /// </summary>            
        public const string ReportTimeIntervalLast7Days = "R.Interval.Last7Days";

        /// <summary>
        /// Contains System Name for: R.Interval.LastHourlyAggregation
        /// </summary>            
        public const string ReportTimeIntervalLastHourlyAggregation = "R.Interval.LastHourlyAggregation";


        /// <summary>
        /// Contains System Name for: R.Interval.LastQuarter
        /// </summary>            
        public const string ReportTimeIntervalLastQuarter = "R.Interval.LastQuarter";

        /// <summary>
        /// Contains System Name for: R.Interval.LastWeek
        /// </summary>            
        public const string ReportTimeIntervalLastWeek = "R.Interval.LastWeek";

        /// <summary>
        /// Contains System Name for: R.Interval.LastYear
        /// </summary>            
        public const string ReportTimeIntervalLastYear = "R.Interval.LastYear";
    #endregion

        #region Service Designer Template Names

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ServiceDesigner.Messaging
        /// </summary>    
        public const string ServiceDesignerMessaging = "Microsoft.SystemCenter.ServiceDesigner.Messaging";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ServiceDesigner.GenericService
        /// </summary>    
        public const string ServiceDesignerGenericService = "Microsoft.SystemCenter.ServiceDesigner.GenericService";

        #endregion

        #region Web Application Names

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ServiceDesigner.WebApplication
        /// </summary>    
        public const string ServiceDesignerWebApplicationName = "Microsoft.SystemCenter.ServiceDesigner.WebApplication";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ServiceDesigner.WebApplication.DatabaseGroup
        /// </summary>   
        public const string ServiceDesignerWebApplicationDatabaseGroupName = "Microsoft.SystemCenter.ServiceDesigner.WebApplication.DatabaseGroup";
                
        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ServiceDesigner.WebApplication.DatabaseGroup.WebSiteGroup
        /// </summary>   
        public const string ServiceDesignerWebApplicationWebSiteGroupName = "Microsoft.SystemCenter.ServiceDesigner.WebApplication.WebSiteGroup";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ApplicationMonitoring.360.Template.3TierApplication
        /// </summary>   
        public const string ApplicationMonitoring360Template3TierApplicationName = "Microsoft.SystemCenter.ApplicationMonitoring.360.Template.3TierApplication";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ApplicationMonitoring.360.Template.3TierApplication.ClientPerspective.Component
        /// </summary>   
        public const string ApplicationMonitoring360Template3TierApplicationClientPerspectiveName = "Microsoft.SystemCenter.ApplicationMonitoring.360.Template.3TierApplication.ClientPerspective.Component";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.ApplicationMonitoring.360.Template.3TierApplication.DataTier.Component
        /// </summary>   
        public const string ApplicationMonitoring360Template3TierApplicationDataTierName = "Microsoft.SystemCenter.ApplicationMonitoring.360.Template.3TierApplication.DataTier.Component";

        /// <summary>
        /// Contains System Name for:Administration Item
        /// </summary>   
        public const string SysemAdminItemName = "System.AdminItem";

        /// <summary>
        /// Contains System Name for:Global Settings
        /// </summary>   
        public const string GlobalSettingsName = "System.GlobalSetting";

        /// <summary>
        /// Contains System Name for:System.Entity
        /// </summary>   
        public const string ObjectName = "System.Entity";

        #endregion

        #region View Names

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.CM.AEM.Views.Internal.ApplicationState.View
        /// </summary>            
        public const string AEMApplicationStateViewName = "Microsoft.SystemCenter.CM.AEM.Views.Internal.ApplicationState.View";

        #region UI Test MP Views

        /// <summary>
        /// Contains System Name for: UITest.Views.AlertView
        /// </summary>            
        public const string UITestViewsAlertViewName = "UITest.Views.AlertView";

        /// <summary>
        /// Contains System Name for: UITest.Views.ComputersView
        /// </summary>            
        public const string UITestViewsComputersViewName = "UITest.Views.AllComputers";

        /// <summary>
        /// Contains System Name for: UITest.Views.EventView
        /// </summary>            
        public const string UITestViewsEventViewName = "UITest.Views.EventView";

        /// <summary>
        /// Contains System Name for: UITest.Views.PerformanceView
        /// </summary>            
        public const string UITestViewsPerformanceViewName = "UITest.Views.PerformanceView";

        /// <summary>
        /// Contains System Name for:  UITest.Views.DashboardView
        /// </summary>            
        public const string UITestViewsDashboardViewName = "UITest.Views.DashboardView";

        /// <summary>
        /// Contains System Name for:  UITest.Views.DiagramView
        /// </summary>            
        public const string UITestViewsDiagramViewName = "UITest.Views.DiagramView";

        /// <summary>
        /// Contains System Name for: UITest.Views.StateView
        /// </summary>            
        public const string UITestViewsStateViewName = "UITest.Views.StateView";

        /// <summary>
        /// Contains System Name for: UITest.Views.TaskStatusView
        /// </summary>            
        public const string UITestViewsTaskStatusViewName = "UITest.Views.TaskStatusView";

        /// <summary>
        /// Contains System Name for: UITest.Views.StateViewAgent
        /// </summary>            
        public const string UITestViewsAgentStateViewName = "UITest.Views.StateViewAgent";

        /// <summary>
        /// Contains System Name for: UITest.Views.StateViewHealthService
        /// </summary>            
        public const string UITestViewsHealthServiceStateViewName = "UITest.Views.StateViewHealthService";

        /// <summary>
        /// Contains System Name for: UITest.Views.StateViewHSWatcher
        /// </summary>            
        public const string UITestViewsHSWatcherStateViewName = "UITest.Views.StateViewHSWatcher";
        #endregion UI Test MP Views

        #region HealthExplorer Test MP Views
        /// <summary>
        /// Contains System Name for: Monitoring/HealthExplorer-Test/State
        /// </summary>            
        public const string HealthExplorerTestViewsStateViewName = "View_80662ca50c46460d9bcbbbb37e31b0ae";

        /// <summary>
        /// Contains System Name for: Monitoring/HealthExplorer-Test/Alerts
        /// </summary>            
        public const string HealthExplorerTestViewsAlertsViewName = "View_20a0d08b0cb74981bebc7a1f97686247";

        /// <summary>
        /// Contains System Name for: Monitoring/HealthExplorer-Test/WindowsComputerState
        /// </summary>            
        public const string HealthExplorerTestViewsWindowsComputerStateViewName = "View_b02e89b181d0440e965df13dd5dcfbc5";
        #endregion HealthExplorer Test MP Views

        #region Authoring Space Views

        /// <summary>
        /// Contains System Name for: 
        /// Microsoft.SystemCenter.AttributesView
        /// </summary>            
        public const string MicrosoftSystemCenterAttributesViewName = 
            "Microsoft.SystemCenter.AttributesView";

        /// <summary>
        /// Contains System Name for: 
        /// Microsoft.SystemCenter.HealthView
        /// </summary>            
        public const string MicrosoftSystemCenterHealthViewName = 
            "Microsoft.SystemCenter.HealthView";

        /// <summary>
        /// Contains System Name for: 
        /// Microsoft.SystemCenter.ObjectDiscoveriesView
        /// </summary>            
        public const string MicrosoftSystemCenterObjectDiscoveriesViewName = 
            "Microsoft.SystemCenter.DiscoveriesView";

        /// <summary>
        /// Contains System Name for: 
        /// Microsoft.SystemCenter.RulesView
        /// </summary>            
        public const string MicrosoftSystemCenterRulesViewName = 
            "Microsoft.SystemCenter.RulesView";
        
        /// <summary>
        /// Contains System Name for: 
        /// Microsoft.SystemCenter.TasksView  
        /// </summary>            
        public const string MicrosoftSystemCenterTasksViewName = 
            "Microsoft.SystemCenter.TasksView";

        /// <summary>
        /// Contains System Name for: 
        /// Microsoft.SystemCenter.ViewDefinitionsView
        /// </summary>            
        public const string MicrosoftSystemCenterViewDefinitionsViewName = 
            "Microsoft.SystemCenter.ViewDefinitionsView";

        /// <summary>
        ///  Contains System Name for:
        ///  Microsoft.SystemCenter.OverridesView
        /// </summary>
        public const string MicrosoftSystemCenterOverridesViewName =
            "Microsoft.SystemCenter.OverridesView";

        #endregion Authoring Space Views

        #region Monitoring Space View Types

        /// <summary>
        /// Contains System Name for Microsoft.SystemCenter.EventView
        /// </summary>
        public const string MicrosoftSystemCenterEventViewName = "Microsoft.SystemCenter.EventView";

        /// <summary>
        /// Contains System Name for Microsoft.SystemCenter.AlertView
        /// </summary>
        public const string MicrosoftSystemCenterAlertViewName = "Microsoft.SystemCenter.AlertView";

        /// <summary>
        /// Contains System Name for Microsoft.SystemCenter.PerformanceView
        /// </summary>
        public const string MicrosoftSystemCenterPerformanceViewName = "Microsoft.SystemCenter.PerformanceView";
        
        /// <summary>
        /// Contains System Name for Microsoft.SystemCenter.StateView
        /// </summary>
        public const string MicrosoftSystemCenterStateViewName = "Microsoft.SystemCenter.StateView";

        /// <summary>
        /// Contains System Name for System.Views.TaskStatusView
        /// </summary>
        public const string SystemViewsTaskStatusViewName = "System.Views.TaskStatusView";

        /// <summary>
        /// Contains System Name for System.Views.AlertView
        /// </summary>
        public const string SystemViewsActiveAlertsViewName = "System.Views.AlertView";

        /// <summary>
        /// Contains System Name for Microsoft.SystemCenter.DiagramView
        /// </summary>
        public const string MicrosoftSystemCenterDiagramViewName = "Microsoft.SystemCenter.DiagramView";

        #endregion Monitoring Space View Types

        #region Administration Space Views

        #region Common Views, Operations Manager & Essentials (SCE)

        /// <summary>
        /// Contains System Name for 
        /// System.Views.Administration.AgentManagedView
        /// </summary>
        public const string SystemViewsAdministrationAgentManagedView =
            "System.Views.Administration.AgentsView";

        /// <summary>
        /// Contains System Name for System.Views.Administration.MPsView
        /// </summary>
        public const string SystemViewsAdministrationInstalledManagementPacksView =
            "System.Views.Administration.MPsView";

        /// <summary>
        /// Contains System Name for System.Views.Administration.UpdatesAndRecommendationsView
        /// </summary>
        public const string SystemViewsAdministrationUpdatesAndRecommendationsView =
            "System.Views.Administration.UpdatesAndRecommendationsView";

        /// <summary>
        /// Contains System Name for System.Views.Administration.TuneManagementPackView
        /// </summary>
        public const string SystemViewsAdministrationTuneManagementPackView =
            "System.Views.Administration.TuneManagementPackView";

        /// <summary>
        /// Contains System Name for System.Views.Administration.TuneAlertsView
        /// </summary>
        public const string SystemViewsAdministrationTuneAlertsView =
            "System.Views.Administration.TuneAlertsView";

        /// <summary>
        /// Contains System Name for 
        /// System.Views.Administration.NetworkDevicesView
        /// </summary>
        public const string SystemViewsAdministrationNetworkDevicesView =
            "System.Views.Administration.NetworkDevicesView";

        /// <summary>
        /// Contains System Name for 
        /// System.Views.Administration.NetworkDevicesPendingManagementView
        /// </summary>
        public const string SystemViewsAdministrationNetworkDevicesPendingManagementView =
            "System.Views.Administration.PendingManagementNetworkDevicesView";

        /// <summary>
        /// Contains System Name for 
        /// System.Views.Administration.PendingManagementView
        /// </summary>
        public const string SystemViewsAdministrationPendingManagementView = 
            "System.Views.Administration.PendingManagementView";

        /// <summary>
        /// Contains System Name for System.Views.Administration.RunAsAccountsView
        /// </summary>
        public const string SystemViewsAdministrationRunAsAccountsView =
            "System.Views.Administration.RunAsAccountsView";

        /// <summary>
        /// Contains System Name for System.Views.Administration.RunAsProflesView
        /// </summary>
        public const string SystemViewsAdministrationRunAsProfilesView =
                    "System.Views.Administration.RunAsProfilesView";

        /// <summary>
        /// Contains System Name for System.Views.Administration.RecipientsView
        /// </summary>
        public const string SystemViewsAdministrationRecipientsView =
                    "System.Views.Administration.RecipientsView";

        /// <summary>
        /// Contains System Name for System.Views.Administration.SubscriptionsView
        /// </summary>
        public const string SystemViewsAdministrationSubscriptionsView =
                    "System.Views.Administration.SubscriptionsView";

        #endregion Common Views, Operations Manager & Essentials (SCE)

        #region Operations Manager Only Views

        /// <summary>
        /// Contains System Name for 
        /// System.Views.Administration.OperationsManager.ConnectorsView
        /// </summary>
        public const string SystemViewsAdministrationProductConnectorsView =
            "System.Views.Administration.OperationsManager.ConnectorsView";

        /// <summary>
        /// Contains System Name for 
        /// System.Views.Administration.OperationsManager.ManagementGroupsView
        /// </summary>
        public const string SystemViewsAdministrationConnectedManagementGroupsView =
            "System.Views.Administration.OperationsManager.ManagementGroupsView";

        /// <summary>
        /// Contains System Name for 
        /// System.Views.Administration.OperationsManager.ManagementServersView
        /// </summary>
        public const string SystemViewsAdministrationManagementServersView =
            "System.Views.Administration.OperationsManager.ManagementServersView";

        /// <summary>
        /// Contains System Name for 
        /// System.Views.Administration.OperationsManager.AgentlessManagedView
        /// </summary>
        public const string SystemViewsAdministrationAgentlessManagedView =
            "System.Views.Administration.OperationsManager.RemoteAgentsView";

        /// <summary>
        /// Contains System Name for 
        /// System.Views.Administration.OperationsManager.SettingsView
        /// </summary>
        public const string SystemViewsAdministrationSettingsView =
            "System.Views.Administration.OperationsManager.SettingsView";

        /// <summary>
        /// Contains System Name for 
        /// System.Views.Administration.OperationsManager.UserRolesView
        /// </summary>
        public const string SystemViewsAdministrationUserRolesView =
            "System.Views.Administration.OperationsManager.UserRolesView";

        /// <summary>
        /// Contains System Name for System.Views.Administration.ChannelsView
        /// </summary>
        public const string SystemViewsAdministrationChannelsView =
            "System.Views.Administration.ChannelsView";

        /// <summary>
        /// Contains System Name for System.Views.Administration.ChannelsView
        /// </summary>
        public const string SystemViewsAdministrationResourcePoolsView =
            "System.Views.Administration.PoolsView";

        public const string SystemViewsAdministrationServiceMapNodeView =
            "Microsoft.SystemCenter.ServiceMap.LandingPageView";

        #endregion Operations Manager Only Views

        #endregion Administration Space Views

        #endregion

        #region Folder Names

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.CM.AEM.Views.Internal.ViewFolder.Root
        /// </summary>            
        public const string AEMViewFolder = "Microsoft.SystemCenter.CM.AEM.Views.Internal.ViewFolder.Root";
        
        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsEventLog.Simple from Folder table
        /// </summary>            
        public const string MonitorTypeFolderWindowsEventLogSimpleName = "Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsEventLog.Simple";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsEventLog.Correlated from Folder table
        /// </summary>            
        public const string MonitorTypeFolderWindowsEventLogCorrelatedName = "Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsEventLog.Correlated";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsEventLog.Missing from Folder table
        /// </summary>            
        public const string MonitorTypeFolderWindowsEventLogMissingName = "Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsEventLog.Missing";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsEventLog.Repeated from Folder table
        /// </summary>            
        public const string MonitorTypeFolderWindowsEventLogRepeatedName = "Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsEventLog.Repeated";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsEventLog.MissingCorrelated from Folder table
        /// </summary>            
        public const string MonitorTypeFolderWindowsEventLogMissingCorrelatedName = "Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsEventLog.MissingCorrelated";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WMIEvent.Simple from Folder table
        /// </summary>            
        public const string MonitorTypeFolderWMIEventSimpleName = "Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WMIEvent.Simple";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WMIEvent.Repeated from Folder table
        /// </summary>            
        public const string MonitorTypeFolderWMIEventRepeatedName = "Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WMIEvent.Repeated";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WMIPerformance.Static.SingleThreshold from Folder table
        /// </summary>            
        public const string MonitorTypeFolderWMIPerformanceStaticSingleThresholdName = "Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WMIPerformance.Static.SingleThreshold";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WMIPerformance.Static.DoubleThreshold from Folder table
        /// </summary>  
        public const string MonitorTypeFolderWMIPerformanceStaticDoulbeThresholdName = "Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WMIPerformance.Static.DoubleThreshold";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsPerformance
        /// </summary>            
        public const string MonitorTypeFolderWindowsPerformanceName = "Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsPerformance";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsPerformance.SelfTuning
        /// </summary>            
        public const string MonitorTypeFolderWindowsPerformanceSelfTuningName = "Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsPerformance.SelfTuning";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsPerformance.Static
        /// </summary>            
        public const string MonitorTypeFolderWindowsPerformanceStaticThresholdName = "Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsPerformance.Static";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsPerformance.Static.DoubleThreshold
        /// </summary>            
        public const string MonitorTypeFolderWindowsPerformanceStaticDoubleThresholdName = "Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsPerformance.Static.DoubleThreshold";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsPerformance.Static.SingleThreshold from Folder table
        /// </summary>            
        public const string MonitorTypeFolderWindowsPerformanceStaticSingleThresholdName = "Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsPerformance.Static.SingleThreshold";
        
        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsService
        /// </summary>            
        public const string MonitorTypeFolderWindowsServiceName = "Microsoft.SystemCenter.Authoring.MonitorTypeFolder.WindowsService";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.TaskTemplates.Folder.AgentTasks
        /// </summary>            
        public const string AgentTasksFolder = "Microsoft.SystemCenter.TaskTemplates.Folder.AgentTasks";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.TaskTemplates.Folder.ConsoleTasks
        /// </summary>            
        public const string ConsoleTasksFolder = "Microsoft.SystemCenter.TaskTemplates.Folder.ConsoleTasks";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.OperationsManager.Administration.Root
        /// </summary>
        public const string AdministrationRootFolder = "Microsoft.SystemCenter.OperationsManager.Administration.Root";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.OperationsManager.Administration.ManagementPacks
        /// </summary>
        public const string AdministrationManagementPacksFolder = "Microsoft.SystemCenter.OperationsManager.Administration.ManagementPacks";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.OperationsManager.Administration.DeviceManagement
        /// </summary>
        public const string AdministrationDeviceManagementFolder = "Microsoft.SystemCenter.OperationsManager.Administration.DeviceManagement";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.OperationsManager.Administration.Notifications
        /// </summary>
        public const string AdministrationNotificationsFolder = "Microsoft.SystemCenter.OperationsManager.Administration.Notifications";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.OperationsManager.Administration.Security
        /// </summary>
        public const string AdministrationSecurityFolder = "Microsoft.SystemCenter.OperationsManager.Administration.Security";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.NetworkDiscovery.NetworkManagement
        /// </summary>
        public const string AdministrationNetworkManagementFolder = "Microsoft.SystemCenter.NetworkDiscovery.NetworkManagement";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.OperationsManager.Administration.RunAsConfiguration
        /// </summary>
        public const string AdministrationRunAsConfigurationFolder = "Microsoft.SystemCenter.OperationsManager.Administration.RunAsConfiguration";

        /// <summary>
        /// Contains Name for: Microsoft.SystemCenter.OperationsManager.WizardPageSets.Root
        /// </summary>
        public const string OperationsManagerWizardPageSetsRootFolder = "Microsoft.SystemCenter.OperationsManager.WizardPageSets.Root";

        /// <summary>
        /// Contains Name for: Microsoft.SystemCenter.OperationsManager.WizardPageSets.DiscoveryWizard
        /// </summary>
        public const string DiscoveryWizardPageSetFolder = "Microsoft.SystemCenter.OperationsManager.WizardPageSets.DiscoveryWizard";

        /// <summary>
        /// Name for Folder Item Microsoft.SystemCenter.OperationsManager.DiscoveryWizard.NetworkDevicesPageSet
        /// </summary>
        public const string DiscoveryWizardNetworkDevicesPageSetFolder = "Microsoft.SystemCenter.OperationsManager.DiscoveryWizard.NetworkDevicesPageSet";

        /// <summary>
        /// Name for Folder Item Microsoft.SystemCenter.OperationsManager.DiscoveryWizard.NetworkDevicesPageSet
        /// </summary>
        public const string DiscoveryWizardWindowsComputersPageSetFolder = "Microsoft.SystemCenter.OperationsManager.DiscoveryWizard.WindowsPageSet";
        
        /// <summary>
        /// Contains ApplicationMonitoringUIRootFolder Name for: Microsoft.SystemCenter.ApplicationMonitoring.UI.RootFolder
        /// </summary>
        public const string ApplicationMonitoringUIRootFolder = "Microsoft.SystemCenter.ApplicationMonitoring.UI.RootFolder";

        #endregion 

        #region Overridable Parameter Names
        /// <summary>
        /// Contains Name for: Overridable Parameter: Tolerance in System.Performance.Library MP
        /// </summary>            
        public const string OverridableParameterToleranceName = "Tolerance";

        /// <summary>
        /// Contains Name for: Overridable Parameter: Severity in System.Health.Library MP
        /// </summary>            
        public const string OverridableParameterSeverityName = "Severity";

        /// <summary>
        /// Contains Name for: Overridable Parameter: Priority in System.Health.Library MP
        /// </summary>            
        public const string OverridableParameterPriorityName = "Priority";

        /// <summary>
        /// Contains Name for: Overrideable Parameter: Timeout Seconds in SystemCenter.Library MP
        /// </summary>
        public const string OverrideableParameterTimeoutSecondsName = "TimeoutSeconds";
                
        #endregion 

        #region Module Type Names
        /// <summary>
        /// Contains Name for: Module Type System.Performance.OptimizedDataProvider in ModuleType Table
        /// </summary>            
        public const string ModuleTypeLinkedOptimizedDataProviderName = "System.Performance.OptimizedDataProvider";

        /// <summary>
        /// Contains Name for: Module Type System.Health.GenerateAlert
        /// </summary>
        public const string SystemHealthGenerateAlert = "System.Health.GenerateAlert";

        /// <summary>
        /// Contains Name for: Module Type System.CommandExecuter
        /// </summary>
        public const string SystemCommandExecuter = "System.CommandExecuter";

        /// <summary>
        /// Contains Name for: Module Type System.CommandExecuterProbe
        /// </summary>
        public const string SystemCommandExecuterProbe = "System.CommandExecuterProbe";
                
        #endregion 

        #region Monitor Type State ID
        /// <summary>
        /// Contains ID for: Monitor Type State EventRaised in MonitorTypeState Table
        /// </summary>            
        public const string MonitorTypeStateEventRaised = "EventRaised";

        /// <summary>
        /// Contains ID for: Monitor Type State FirstEventRaised in MonitorTypeState Table
        /// </summary>            
        public const string MonitorTypeStateFirstEventRaised = "FirstEventRaised";

        /// <summary>
        /// Contains ID for: Monitor Type State SecondEventRaised in MonitorTypeState Table
        /// </summary>            
        public const string MonitorTypeStateSecondEventRaised = "SecondEventRaised";

        /// <summary>
        /// Contains ID for: Monitor Type State TimerEventRaised in MonitorTypeState Table
        /// </summary>            
        public const string MonitorTypeStateTimerEventRaised = "TimerEventRaised";

        /// <summary>
        /// Contains ID for: Monitor Type State CorrelatedEventRaised in MonitorTypeState Table
        /// </summary>            
        public const string MonitorTypeStateCorrelatedEventRaised = "CorrelatedEventRaised";

        /// <summary>
        /// Contains ID for: Monitor Type State MissingCorrelatedEventRaised in MonitorTypeState Table
        /// </summary>            
        public const string MonitorTypeStateMissingCorrelatedEventRaised = "MissingCorrelatedEventRaised";

        /// <summary>
        /// Contains ID for: Monitor Type State RepeatedEventRaised in MonitorTypeState Table
        /// </summary>            
        public const string MonitorTypeStateRepeatedEventRaised = "RepeatedEventRaised";

        /// <summary>
        /// Contains ID for: Monitor Type State MissingEventRaised in MonitorTypeState Table
        /// </summary>            
        public const string MonitorTypeStateMissingEventRaised = "MissingEventRaised";

        /// <summary>
        /// Contains ID for: Monitor Type State MissingEventRaised in MonitorTypeState Table
        /// </summary>            
        public const string MonitorTypeStateOverThreshold = "OverThreshold";   

        /// <summary>
        /// Contains ID for: Monitor Type State MissingEventRaised in MonitorTypeState Table
        /// </summary>            
        public const string MonitorTypeStateUnderThreshold = "UnderThreshold";

        /// <summary>
        /// Contains ID for: Monitor Type State MissingEventRaised in MonitorTypeState Table
        /// </summary>            
        public const string MonitorTypeStateConditionFalse = "ConditionFalse";

        /// <summary>
        /// Contains ID for: Monitor Type State MissingEventRaised in MonitorTypeState Table
        /// </summary>            
        public const string MonitorTypeStateConditionTrue = "ConditionTrue";

        /// <summary>
        /// Contains ID for: Monitor Type State BetweenThreshold in MonitorTypeState Table
        /// </summary> 
        public const string MonitorTypeStateBetweenThreshold = "OverThreshold1UnderThreshold2";

        /// <summary>
        /// Contains ID for: Monitor Type State OverUpperThreshold in MonitorTypeState Table
        /// </summary> 
        public const string MonitorTypeStateOverUpperThreshold = "OverThreshold2";

        /// <summary>
        /// Contains ID for: Monitor Type State UnderLowerThreshold in MonitorTypeState Table
        /// </summary> 
        public const string MonitorTypeStateUnderLowerThreshold = "UnderThreshold1";

        /// <summary>
        /// Contains ID for: Monitor Type State Running in MonitorTypeState Table
        /// </summary>
        public const string MonitorTypeStateRunning = "Running";

        /// <summary>
        /// Contains ID for: Monitor Type State Not Running in MonitorTypeState Table
        /// </summary>
        public const string MonitorTypeStateNotRunning = "NotRunning";

        /// <summary>
        /// Contains ID for: Monitor Type State Above in MonitorTypeState Table
        /// </summary>
        public const string MonitorTypeStateAbove = "Above";

        /// <summary>
        /// Contains ID for: Monitor Type State Below in MonitorTypeState Table
        /// </summary>
        public const string MonitorTypeStateBelow = "Below";

        /// <summary>
        /// Contains ID for: Monitor Type State OutsideEnvelope in MonitorTypeState Table
        /// </summary>
        public const string MonitorTypeStateOutsideEnvelope = "OutsideEnvelope";

        /// <summary>
        /// Contains ID for: Monitor Type State WithinEnvelope in MonitorTypeState Table
        /// </summary>
        public const string MonitorTypeStateWithinEnvelope = "WithinEnvelope";

        /// <summary>
        /// Contains ID for: Monitor Type State AboveEnvelope in MonitorTypeState Table
        /// </summary>
        public const string MonitorTypeStateAboveEnvelope = "AboveEnvelope";

        /// <summary>
        /// Contains ID for: Monitor Type State BelowEnvelope in MonitorTypeState Table
        /// </summary>
        public const string MonitorTypeStateBelowEnvelope = "BelowEnvelope";
        #endregion 

        #region Monitor Type Names

        /// <summary>
        /// Contains Service State Monitor Name for: Service Running State
        /// </summary>            
        public const string ServiceStateMonitorName = "Microsoft.SystemCenter.NTService.ServiceStateMonitor";

        #endregion

        #region Class Names
        /// <summary>
        /// Contains System Name for: Entity
        /// </summary>            
        public const string SystemEntityName = "System.Entity";

        /// <summary>
        /// Contains System Name for: Display Name
        /// </summary>
        public const string DisplayName = "DisplayName";
        /// <summary>
        /// Contains System Name for: Computer
        /// </summary>            
        public const string SystemComputerName = "System.Computer";

        /// <summary>
        /// Contains the System Name for: Server Computer
        /// </summary>
        public const string WindowsServerComputer = "Microsoft.Windows.Server.Computer";

        /// <summary>
        /// Contains the System Name for: Client Computer
        /// </summary>
        public const string WindowsClientComputer = "Microsoft.Windows.Client.Computer";

        /// <summary>
        /// Contains the System Name for: Windows Operating System
        /// </summary>
        public const string WindowsOperatingSystem = "Microsoft.Windows.OperatingSystem";

        /// <summary>
        /// Contains the System Name for: Windows Domain Controller
        /// </summary>
        public const string WindowsDomainController = "Microsoft.Windows.Server.DC.Computer";

        /// <summary>
        /// Contains the System Name for: Windows Clustering Discovery
        /// </summary>
        public const string WindowsClusteringDiscovery = "Microsoft.Windows.Cluster.Classes.Discovery";

        /// <summary>
        /// Contains the System Name for: Discover Windows Computer Properties
        /// </summary>
        public const string DiscoverWindowsComputerProperties = "Microsoft.SystemCenter.DiscoverWindowsComputerProperties";

        /// <summary>
        /// Contains System Name for: SNMP Network Device
        /// </summary>            
        public const string SystemSNMPName = "Microsoft.SystemCenter.NetworkDevice";

        /// <summary>
        /// Contains System Name for: Node
        /// </summary>
        public const string SystemNetworkManagementNodeName = "System.NetworkManagement.Node";

        /// <summary>
        /// Contains System Name for: RootManagementServerComputersGroup
        /// </summary>
        public const string SystemRootManagementServerComputersGroupName = "Microsoft.SystemCenter.RootManagementServerComputersGroup";

        /// <summary>
        /// Contains System Name for: AgentManagedComputerGroupName 
        /// </summary>
        public const string SystemAgentManagedComputerGroupName = "Microsoft.SystemCenter.AgentManagedComputerGroup";

        /// <summary>
        /// Contains System Name for: WindowsComputerGroupName 
        /// </summary>
        public const string WindowsComputerGroupName = "Microsoft.Windows.Computer";

        /// <summary>
        /// Contains System Name for: WindowsAllWindowsComputersName 
        /// </summary>
        public const string WindowsAllWindowsComputersName = "Microsoft.SystemCenter.AllComputersGroup";

        /// <summary>
        /// Contains System Name for: AgentName 
        /// </summary>
        public const string AgentName = "Microsoft.SystemCenter.Agent";

        /// <summary>
        /// Contains System Name for: WindowsComputerRoleName 
        /// </summary>
        public const string WindowsComputerRoleName = "Microsoft.Windows.ComputerRole";

        /// <summary>
        /// Contains System Name for: OwnProcessNTServiceName (Target of Rule CollectPercentProcessorTime)
        /// </summary>
        public const string OwnProcessNTServiceName = "Microsoft.SystemCenter.OwnProcessNTService";

        /// <summary>
        /// Contains System Name for: Windows Clustering Discovery
        /// </summary>
        public const string WindowsClusteringDiscoveryName = "Microsoft.Windows.Cluster.Classes.Discovery";

        /// <summary>
        /// Contains System Name for: Discover Windows Computer Properties
        /// </summary>
        public const string DiscoverWindowsComputerPropertiesName = "Microsoft.SystemCenter.DiscoverWindowsComputerProperties";

        /// <summary>
        /// Contains System Name for: SQL 2008 DB
        /// </summary>
        public const string SQL2008DBName = "Microsoft.SQLServer.2008.Database";

        /// <summary>
        /// Contains System Name for: SQL 2012 DB
        /// </summary>
        public const string SQL2012DBName = "Microsoft.SQLServer.2012.Database";
        /// <summary>
        /// Contains System Name for: AllManagementServersPool
        /// </summary>
        public const string AllManagementServersPool = "Microsoft.SystemCenter.AllManagementServersPool";

        /// <summary>
        /// Contains System Name for: Microsoft.Windows.Client.InstanceGroup
        /// </summary>
        public const string WindowClientInstanceGroupName = "Microsoft.Windows.Client.InstanceGroup";
        
        #endregion

        #region UI Pages

        /// <summary>
        /// Constains System Name for: Microsoft.SystemCenter.OperationsManager.DiscoveryWizard.Pages.WindowsComputers
        /// </summary>
        public const string DiscoveryWizardWindowsComputersPage = "Microsoft.SystemCenter.OperationsManager.DiscoveryWizard.Pages.WindowsComputers";

        /// <summary>
        /// Contains System Name for: Microsoft.SystemCenter.OperationsManager.DiscoveryWizard.Pages.NetworkDevices
        /// </summary>
        public const string DiscoveryWizardNetWorkDevicesPage = "Microsoft.SystemCenter.OperationsManager.DiscoveryWizard.Pages.NetworkDevices";

        #endregion

        #region UI PageSets
        
        /// <summary>
        /// Contains name for PageSet Element Microsoft.SystemCenter.OperationsManager.DiscoveryWizard.WindowsPageSet
        /// </summary>
        public const string DiscoveryWizardWindowsComputersPageSet = "Microsoft.SystemCenter.OperationsManager.DiscoveryWizard.WindowsPageSet";

        /// <summary>
        /// Contains name for PageSet Element Microsoft.SystemCenter.OperationsManager.DiscoveryWizard.NetworkDevicesPageSet
        /// </summary>
        public const string DiscoveryWizardNetworkDevicesPageSet = "Microsoft.SystemCenter.OperationsManager.DiscoveryWizard.NetworkDevicesPageSet";

        #endregion 

        #region StringResource Names

        /// <summary>
        /// Contains ServiceStateMonitorAlertMessage Name for: Windows Service Stopped
        /// </summary>            
        public const string ServiceStateMonitorAlertMessageName = "Microsoft.SystemCenter.NTService.ServiceStateMonitor.AlertMessage";

        /// <summary>
        /// Contains ResourceDefaultManagementPack Name for: Default Management Pack
        /// </summary> 
        public const string ResourceDefaultManagementPackName = ";Default Management Pack;ManagedString;Microsoft.MOM.UI.Common.dll;" +
            "Microsoft.EnterpriseManagement.Mom.Internal.UI.Common.MPHelper;DefaultManagementPackFriendlyName";

        #endregion

        #region Constructor
        /// <summary>
        /// Private Constructor to fix FxCop error.
        /// </summary>
        private ManagementPackConstants() { }
        #endregion
    
    }

}
