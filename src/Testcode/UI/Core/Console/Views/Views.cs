//-------------------------------------------------------------------
// <copyright file="Views.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Views related code (Storing Constants for Monitoring View Guids)
// </summary>
//  <history>
//   [ravipr] 27SEP05: Created
//   [ruhim]  03OCT05: Added the string subclass and properties for all MOM views 
//   [lucyra] 18JAN06: Added view creation support under Monitoring
//   [ruhim]  19MAR06: Updated Monitors view GUID
//   [lucyra] 24MAR06: Updated view deletion support
//   [lucyra] 25APR06: Fix: BVT failure sending esc
//   [faizalk] 08MAY06: Update GUIDs
//   [ruhim]  09Jun06:  Replacing Hard coded GUIDs with method calls 
//   [lucyra] 23JUN06: Updated view creation methods, added support for more views
//   [lucyra] 15AUG06: Create GUID for added Computers view in UI Test MP
//   [lucyra] 21MAR07: Added Alerts view criteria
//   [visnara] 14MAY07: Added support for creating views in multiple spaces (Monitoring/ My Workspace)
//   [kellymor]01MAY08: Added support for Administration root and
//                      folder nodes
//   [kellymor]09MAY08: Added support for Administration views
//                      Moved Administration folders to MOM internal
//                      MP from Operations Manager 2007 MP.
//   [kellymor]15MAY08: Moved Administration root node to MOM internal MP
//                      from System Center Core library.
//   [kellymor]19MAY08: Added region tags for other GUID sections.
//   [kellymor]29MAY08: Added resource for Help context menu and
//                      Show Combined Task Output Actions pane item.
//   [kellymor]07AUG08: Added resource for notification channels view.
//                      Added control ID's for Admin overview page
//                      links for discovery and notification channels
//                      Added resources for channels view context
//                      menus.
//   [KellyMor]06SEP08: Updated resource strings for move from Administration
//                      library to components library.
//   [rahsing] 01OCT15: Added support for Management Packs folder and Installed Management Packs view
//   [rahsing] 01DEC15: Added support for Updates and Recommendations view
//   [satim]   03MAR16  Added support for Tune Management packs and Tune Alerts view
//  </history>
//-------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.Views
{
    #region Using directives

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections;
    using Microsoft.EnterpriseManagement.Mom.Internal;
    using System.Data; // Used for tempoary storage of Tables for Personalize View

    using Maui.Core;
    using Maui.Core.Utilities;
    using Maui.Core.WinControls; // Maui WinControls
    using Maui.GlobalExceptions;

    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.Views.Dialogs;
    using Mom.Test.UI.Core.Console.Views.Performance.Dialogs;
    using Mom.Test.UI.Core.Console.Views.Alerts;
    using Mom.Test.UI.Core.Console.Views.Events;

    using Mom.Test.UI.Core.Console.Views.TaskStatus.Dialogs;

    using Mom.Test.UI.Core.Console.MonitoringConfiguration.Dialogs;
    #endregion

    #region Enumerators section View Type
    /// <summary>
    /// Enum View Type
    /// Does not contain Diagram or Inventory views since those cannot be created
    /// Contains Folder that is not view type
    /// </summary>
    /// <history>
    ///		[lucyra] 18JAN06 Created
    /// </history>
    public enum ViewType
    {
        /// <summary>
        /// Alert View
        /// </summary>
        AlertView,

        /// <summary>
        /// State View
        /// </summary>
        StateView,

        /// <summary>
        /// Event View
        /// </summary>
        EventView,

        /// <summary>
        /// Performance View
        /// </summary>
        PerformanceView,

        /// <summary>
        /// Task Status View
        /// </summary>
        TaskStatusView,

        /// <summary>
        /// Web Page View
        /// </summary>
        WebPageView,

        /// <summary>
        /// Dashboard View
        /// </summary>
        DashboardView,

        /// <summary>
        /// Folder
        /// </summary>
        Folder,

        /// <summary>
        /// Overrides Summary View 
        /// </summary>
        OverridesSummaryView,

        /// <summary>
        /// Diagram View
        /// </summary>
        DiagramView
    }
    #endregion // Enumerators section

    /// ------------------------------------------------------------------
    /// <summary>
    ///    Views Class
    /// </summary>
    /// <history>
    ///     [ravipr] 27SEP05: Created
    ///     [a-joelj] 21OCT09 Added ControlID for Import Management Packs link label
    /// </history>
    /// ------------------------------------------------------------------
    public class Views
    {
        #region Enumerators section Window Captions

        /// <summary>
        /// Types of window captions.
        /// </summary>
        public enum WindowCaptions
        {

            #region Alerts view window captions
            /// <summary>
            /// Text input 'Alert Name' (Alert) view crtieria dialog's window caption.
            /// </summary>
            AlertName,

            /// <summary>
            /// Text input 'Description' (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertDescription,

            /// <summary>
            /// Text input 'Owner' (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertOwner,

            /// <summary>
            /// Text input 'Instance Name' (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertInstanceName,

            /// <summary>
            /// Text input 'Last Modified By' (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertLastModifiedBy,

            /// <summary>
            /// Text input 'Resolved By' (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertResolvedBy,

            /// <summary>
            /// Text input 'Ticket ID' (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertTicketId,

            /// <summary>
            /// Text input 'Site' (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertSite,

            /// <summary>
            /// Text input 'Custom Field 1' (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertCustomField1,

            /// <summary>
            /// Text input 'Custom Field 2' (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertCustomField2,

            /// <summary>
            /// Text input 'Custom Field 3' (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertCustomField3,

            /// <summary>
            /// Text input 'Custom Field 4' (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertCustomField4,

            /// <summary>
            /// Text input 'Custom Field 5' (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertCustomField5,

            /// <summary>
            /// Text input 'Custom Field 6' (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertCustomField6,

            /// <summary>
            /// Text input 'Custom Field 7' (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertCustomField7,

            /// <summary>
            /// Text input 'Custom Field 8' (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertCustomField8,

            /// <summary>
            /// Text input 'Custom Field 9' (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertCustomField9,

            /// <summary>
            /// Text input 'Custom Field 10' (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertCustomField10,

            /// <summary>
            /// Date and Time radio buttons selection 'Date And Time Generated' 
            /// (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertDateAndTimeGenerated,

            /// <summary>
            /// Date and Time radio buttons selection 'Last Modified Time' 
            /// (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertLastModifiedTime,

            /// <summary>
            /// Date and Time radio buttons selection 'Resolution State Last Modified' 
            /// (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertResolutionStateLastModified,

            /// <summary>
            /// Date and Time radio buttons selection 'Time Resolved' 
            /// (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertTimeResolved,

            /// <summary>
            /// Date and Time radio buttons selection 'Time Added' 
            /// (Alert) view criteria dialog's window caption.
            /// </summary>
            AlertTimeAdded,

            #endregion

            #region Events view window captions

            /// <summary>
            /// Text input 'Event Number' (Event) view crtieria dialog's window caption.
            /// </summary>
            EventNumber,

            /// <summary>
            /// Text input 'Source Name' (Event) view crtieria dialog's window caption.
            /// </summary>
            SourceName,

            /// <summary>
            /// Text input 'Object Name' (Event) view crtieria dialog's window caption.
            /// </summary>
            ObjectName,

            /// <summary>
            /// Text input 'User' (Event) view crtieria dialog's window caption.
            /// </summary>
            User,

            /// <summary>
            /// Text input 'Logging Computer' (Event) view crtieria dialog's window caption.
            /// </summary>
            LoggingComputer,

            #endregion

        }

        #endregion	// Enumerators section

        #region Strings

        /// <summary>
        /// Strings Class
        /// </summary>
        public class Strings
        {
            #region Constants

            #region GUIDs for MP Views and Folders

            #region AEM Views and Folders

            /// <summary>
            /// AemApplicationStateViewGuid (Stored in Views Table)
            /// </summary>            
            private static Guid ResourceAemApplicationStateViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.SystemCenterClientMonitoringViewsInternalMPName,
                ManagementPackConstants.MomManagementPackPublicKeyToken,
                ManagementPackConstants.AEMApplicationStateViewName);

            /// <summary>
            /// AemApplicationViewFolderGuid (Stored in Views Table)
            /// </summary>            
            private static Guid ResourceAemViewFolderGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.SystemCenterClientMonitoringViewsInternalMPName,
                ManagementPackConstants.MomManagementPackPublicKeyToken,
                ManagementPackConstants.AEMViewFolder);

            #endregion AEM Views and Folders

            #region UI Test MP Views

            /// <summary>
            /// AlertViewGuid (Stored in Views Table)
            /// </summary>            
            public static Guid ResourceAlertViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.UITestMPName,
                null,
                ManagementPackConstants.UITestViewsAlertViewName);

            /// <summary>
            /// ComputersViewGuid
            /// </summary>            
            public static Guid ResourceComputersViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.UITestMPName,
                null,
                ManagementPackConstants.UITestViewsComputersViewName);

            /// <summary>
            /// EventViewGuid (Stored in the Views Table)
            /// </summary>
            public static Guid ResourceEventViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.UITestMPName,
                null,
                ManagementPackConstants.UITestViewsEventViewName);

            /// <summary>
            /// PerformanceViewGuid (Stored in Views Table)
            /// </summary>
            public static Guid ResourcePerformanceViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.UITestMPName,
                null,
                ManagementPackConstants.UITestViewsPerformanceViewName);

            /// <summary>
            /// DashboardViewGuid (Stored in Views Table)
            /// </summary>
            public static Guid ResourceDashboardViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.UITestMPName,
                null,
                ManagementPackConstants.UITestViewsDashboardViewName);

            /// <summary>
            /// DiagramViewGuid (Stored in Views Table)
            /// </summary>
            public static Guid ResourceDiagramViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.UITestMPName,
                null,
                ManagementPackConstants.UITestViewsDiagramViewName);

            /// <summary>
            /// StateViewGuid (Stored in Views Table)
            /// </summary>
            public static Guid ResourceStateViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.UITestMPName,
                null,
                ManagementPackConstants.UITestViewsStateViewName);

            /// <summary>
            /// TaskStatusViewGuid (Stored in Views Table)
            /// </summary>
            public static Guid ResourceTaskStatusViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.UITestMPName,
                null,
                ManagementPackConstants.UITestViewsTaskStatusViewName);

            /// <summary>
            /// AgentStateViewGuid (Stored in Views Table)
            /// </summary>
            public static Guid ResourceAgentStateViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.UITestMPName,
                null,
                ManagementPackConstants.UITestViewsAgentStateViewName);


            /// <summary>
            /// HealthServiceStateViewGuid (Stored in Views Table)
            /// </summary>
            public static Guid ResourceHealthServiceStateViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.UITestMPName,
                null,
                ManagementPackConstants.UITestViewsHealthServiceStateViewName);


            /// <summary>
            /// HSWatcherStateViewGuid (Stored in Views Table)
            /// </summary>
            public static Guid ResourceHSWatcherStateViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.UITestMPName,
                null,
                ManagementPackConstants.UITestViewsHSWatcherStateViewName);


            #endregion UI Test MP Views

            #region HealthExplorer Test MP Views
            /// <summary>
            /// HealthExplorerAlertsViewGuid (Stored in Views Table)
            /// </summary>            
            public static Guid ResourceHealthExplorerAlertViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.HealthExplorerTestMPName,
                null,
                ManagementPackConstants.HealthExplorerTestViewsAlertsViewName);

            /// <summary>
            /// HealthExplorerStateViewGuid (Stored in Views Table)
            /// </summary>            
            public static Guid ResourceHealthExplorerStateViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.HealthExplorerTestMPName,
                null,
                ManagementPackConstants.HealthExplorerTestViewsStateViewName);

            /// <summary>
            /// HealthExplorerWindowsComputerStateViewGuid (Stored in Views Table)
            /// </summary>            
            public static Guid ResourceHealthExplorerWindowsComputerStateViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.HealthExplorerTestMPName,
                null,
                ManagementPackConstants.HealthExplorerTestViewsWindowsComputerStateViewName);
            #endregion HealthExplorer Test MP Views

            #region Authoring Space

            /// <summary>
            /// HealthMonitorsViewGuid (Stored in Views Table)
            /// </summary>
            public static Guid ResourceHealthViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.SystemCenterInternalMPName,
                ManagementPackConstants.MomManagementPackPublicKeyToken,
                ManagementPackConstants.MicrosoftSystemCenterHealthViewName);

            /// <summary>
            /// RulesViewGuid (Stored in Views Table)
            /// </summary>
            public static Guid ResourceRulesViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.SystemCenterInternalMPName,
                ManagementPackConstants.MomManagementPackPublicKeyToken,
                ManagementPackConstants.MicrosoftSystemCenterRulesViewName);

            /// <summary>
            /// TasksViewGuid (Stored in Views Table)
            /// </summary>
            public static Guid ResourceTasksViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.SystemCenterInternalMPName,
                ManagementPackConstants.MomManagementPackPublicKeyToken,
                ManagementPackConstants.MicrosoftSystemCenterTasksViewName);

            /// <summary>
            /// ApplicationStructureViewGuid (Stored in Views Table)
            /// TODO: Fix hard coded GUID
            /// </summary>
            public const string ResourceApplicationStructureViewGuid =
                "9B4C2EAA-B0C6-4192-FF96-0BCA64FE73E3";

            /// <summary>
            /// AttributesViewGuid (Stored in Views Table)
            /// </summary>
            public static Guid ResourceAttributesViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.SystemCenterInternalMPName,
                ManagementPackConstants.MomManagementPackPublicKeyToken,
                ManagementPackConstants.MicrosoftSystemCenterAttributesViewName);

            /// <summary>
            /// ObjectDiscoveriesViewGuid (Stored in Views Table)
            /// </summary>
            public static Guid ResourceObjectDiscoveriesViewGuid = Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(ManagementPackConstants.SystemCenterInternalMPName, ManagementPackConstants.MomManagementPackPublicKeyToken, ManagementPackConstants.MicrosoftSystemCenterObjectDiscoveriesViewName);

            /// <summary>
            ///  Overrides Summary View Guid (Stored in Views Table)
            /// </summary>
            public static Guid ResourceOverridesViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.SystemCenterInternalMPName,
                ManagementPackConstants.MomManagementPackPublicKeyToken,
                ManagementPackConstants.MicrosoftSystemCenterOverridesViewName);

            /// <summary>
            /// ViewDefinitionsViewGuid (Stored in Views Table)
            /// </summary>
            public static Guid ResourceViewDefinitionsViewGuid =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.SystemCenterInternalMPName,
                ManagementPackConstants.MomManagementPackPublicKeyToken,
                ManagementPackConstants.MicrosoftSystemCenterViewDefinitionsViewName);

            /// <summary>
            /// Contains resource string for: Events Window Title.
            /// </summary>
            public static Guid ResourceEventsWindowTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.SystemCenterInternalMPName,
                ManagementPackConstants.MomManagementPackPublicKeyToken,
                ManagementPackConstants.MicrosoftSystemCenterEventViewName);

            /// <summary>
            /// Contains resource string for: Alerts Window Title.
            /// </summary>
            public static Guid ResourceAlertsWindowTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.SystemCenterInternalMPName,
                ManagementPackConstants.MomManagementPackPublicKeyToken,
                ManagementPackConstants.MicrosoftSystemCenterAlertViewName);

            /// <summary>
            /// Contains resource string for: Performance Window Title.
            /// </summary>
            public static Guid ResourcePerformanceWindowTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.SystemCenterInternalMPName,
                ManagementPackConstants.MomManagementPackPublicKeyToken,
                ManagementPackConstants.MicrosoftSystemCenterPerformanceViewName);

            /// <summary>
            /// Contains resource string for: State Window Title.
            /// </summary>
            public static Guid ResourceStateWindowTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.SystemCenterInternalMPName,
                ManagementPackConstants.MomManagementPackPublicKeyToken,
                ManagementPackConstants.MicrosoftSystemCenterStateViewName);

            /// <summary>
            /// Contains resource string for: Diagram Window Title.
            /// </summary>
            public static Guid ResourceDiagramWindowTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                ManagementPackConstants.SystemCenterInternalMPName,
                ManagementPackConstants.MomManagementPackPublicKeyToken,
                ManagementPackConstants.MicrosoftSystemCenterDiagramViewName);

            #endregion Authoring Space

            #region Administration Space

            #region Folders

            /// <summary>
            /// Contains resource string for: Administration Root Folder Title.
            /// </summary>
            public static Guid ResourceAdministrationRootFolderTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerLibraryMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.AdministrationRootFolder);

            /// <summary>
            /// Contains resource string for: Device Management Folder Title.
            /// </summary>
            public static Guid ResourceDeviceManagementFolderTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerLibraryMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.AdministrationDeviceManagementFolder);

            /// <summary>
            /// Contains resource string for: Notifications Folder Title.
            /// </summary>
            public static Guid ResourceNotificationsFolderTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerLibraryMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.AdministrationNotificationsFolder);

            /// <summary>
            /// Contains resource string for: Security Folder Title.
            /// </summary>
            public static Guid ResourceSecurityFolderTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerLibraryMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.AdministrationSecurityFolder);

            /// <summary>
            /// Contains resource string for: Network Management Folder Title.
            /// </summary>
            public static Guid ResourceNetworkManagementFolderTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerLibraryMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.AdministrationNetworkManagementFolder);

            /// <summary>
            /// Contains resource string for: Run As Configuration Title.
            /// </summary>
            public static Guid ResourceRunAsConfigurationFolderTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerLibraryMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.AdministrationRunAsConfigurationFolder);

            /// <summary>
            /// Contains resource string for: Management Packs View Title.
            /// </summary>
            public static Guid ResourceManagementPacksViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerLibraryMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.AdministrationManagementPacksFolder);

            #endregion Folders

            #region Views

            #region Device Management Folder Views

            /// <summary>
            /// Contains resource string for: Management Servers View Title.
            /// </summary>
            public static Guid ResourceManagementServersViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationManagementServersView);

            /// <summary>
            /// Contains resource string for: Agent Managed View Title.
            /// </summary>
            public static Guid ResourceAgentManagedViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationAgentManagedView);

            /// <summary>
            /// Contains resource string for: Agentless Managed View Title.
            /// </summary>
            public static Guid ResourceAgentlessManagedViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationAgentlessManagedView);

            /// <summary>
            /// Contains resource string for: Network Device View Title.
            /// </summary>
            public static Guid ResourceNetworkDeviceViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationNetworkDevicesView);

            /// <summary>
            /// Contains resource string for: Network Devices Pending Management View Title.
            /// </summary>
            public static Guid ResourceNetworkDevicesPendingManagementViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationNetworkDevicesPendingManagementView);

            /// <summary>
            /// Contains resource string for: Pending Management View Title.
            /// </summary>
            public static Guid ResourcePendingManagementViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationPendingManagementView);

            #endregion Device Management Folder Views

            /// <summary>
            /// Contains resource string for: Installed Management Packs View Title.
            /// </summary>
            public static Guid ResourceInstalledManagementPacksViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationInstalledManagementPacksView);

            /// <summary>
            /// Contains resource string for: Updates and Recommendations View Title.
            /// </summary>
            public static Guid ResourceUpdatesAndRecommendationsViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationUpdatesAndRecommendationsView);
            /// <summary>
            /// Contains resource string for: Tune Management Packs View Title.
            /// </summary>
            public static Guid ResourceTuneManagementPackViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationTuneManagementPackView);

            /// <summary>
            /// Contains resource string for: Tune Alerts View Title.
            /// </summary>
            public static Guid ResourceTuneAlertsViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationTuneAlertsView);

            /// <summary>
            /// Contains resource string for: Service Map Node  Title.
            /// </summary>
            public static Guid ResourceServiceMapNodeTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationServiceMapNodeView);


            #region Notification Folder Views

            /// <summary>
            /// Contains resource string for: Channels View Title.
            /// </summary>
            public static Guid ResourceChannelsViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationChannelsView);

            /// <summary>
            /// Contains resource string for: Recipients View Title.
            /// </summary>
            public static Guid ResourceRecipientsViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationRecipientsView);

            /// <summary>
            /// Contains resource string for: Subscriptions View Title.
            /// </summary>
            public static Guid ResourceSubscriptionsViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationSubscriptionsView);

            #endregion Notification Folder Views

            /// <summary>
            /// Contains resource string for: Settings View Title.
            /// </summary>
            public static Guid ResourceSettingsViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationSettingsView);

            /// <summary>
            /// Contains resource string for: ResourcePool View Title.
            /// </summary>
            public static Guid ResourceResourcePoolsViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationResourcePoolsView);

            #region RunAsConfiguration Folder Views

            /// <summary>
            /// Contains resource string for: Runs As Accounts View Title.
            /// </summary>
            public static Guid ResourceRunAsAccountsViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationRunAsAccountsView);

            /// <summary>
            /// Contains resource string for: Runs As Profiles View Title.
            /// </summary>
            public static Guid ResourceRunAsProfilesViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationRunAsProfilesView);

            #endregion RunAsConfiguration Folder Views

            #region Security Folder Views

            /// <summary>
            /// Contains resource string for: User Roles View Title.
            /// </summary>
            public static Guid ResourceUserRolesViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationUserRolesView);

            #endregion Security Folder Views

            /// <summary>
            /// Contains resource string for: Connected Management Groups View Title.
            /// </summary>
            public static Guid ResourceConnectedManagementGroupsViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationConnectedManagementGroupsView);

            /// <summary>
            /// Contains resource string for: Product Connecters View Title.
            /// </summary>
            public static Guid ResourceProductConnectersViewTitle =
                Mom.Test.UI.Core.Common.IdUtil.GetMPObjectIdAsGuid(
                    ManagementPackConstants.SystemCenterOperationsManagerInternalMPName,
                    ManagementPackConstants.MomManagementPackPublicKeyToken,
                    ManagementPackConstants.SystemViewsAdministrationProductConnectorsView);

            #endregion Views

            #endregion

            #endregion GUIDs for MP Views and Folders

            #region Control ID's for Administration Overview Page

            /// <summary>
            /// Control ID for link label 
            /// 'Required:  Configure Computers and Devices to Manage'.
            /// </summary>
            public const string RequiredConfigureComputersAndDevicesLinkLabel =
                "linkLabelRequiredConfigItem1";

            /// <summary>
            /// Control ID for link label 
            /// 'Required : Import management packs'.
            /// </summary>
            public const string RequiredImportManagementPacksLinkLabel =
                "linkLabelRequiredConfigItem2";

            /// <summary>
            /// Control ID for the link label 
            /// 'Required:  Enable Notification Channels'.
            /// </summary>
            public const string RequiredEnableNotificationLinkLabel =
                "linkLabelRequiredConfigItem3";

            /// <summary>
            /// Control ID for link label 
            /// 'Configure Computers and Devices to Manage'.
            /// </summary>
            public const string ConfigureComputersAndDevicesLinkLabel =
                "linkLabelDiscovery";

            #endregion

            #region Context Menus

            /// <summary>
            /// Contains resource string for:  New context menu item 
            /// </summary>
            private const string ResourceNewContextMenu =
                ";&New" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources" +
                ";NewMenuText";

            /// <summary>
            /// Contains resource string for:  new Alert View context menu item
            /// </summary>
            private const string ResourceNewAlertViewContextMenu = ";&Alert View;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;CommandJumpToAlertView";

            /// <summary>
            /// Contains resource string for:  new Event View context menu item
            /// </summary>
            private const string ResourceNewEventViewContextMenu = ";&Event View;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;CommandJumpToEventView";

            /// <summary>
            /// Contains resource string for:  new State View context menu item
            /// </summary>
            private const string ResourceNewStateViewContextMenu = ";&State View;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;CommandJumpToStateView";

            /// <summary>
            /// Contains resource string for:  new Performance View context menu item
            /// </summary>
            private const string ResourceNewPerformanceViewContextMenu =";&Performance View;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;CommandJumpToPerformanceView";

            /// <summary>
            /// Contains resource string for:  new Task Status View context menu item
            /// </summary>
            private const string ResourceNewTaskStatusViewContextMenu = ";&Task Status View;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;CommandJumpToTaskStatusViewText";

            /// <summary>
            /// Contains resource string for:  new Web Page View context menu item
            /// </summary>
            private const string ResourceNewWebPageViewContextMenu =
                ";Web Page View" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.ViewBaseClasses.ViewResource" +
                ";UrlViewMenuText";

            /// <summary>
            /// Contains resource string for:  new Add to my workspace context menu item
            /// </summary>
            private const string ResourceAddToMyWorkSpaceContextMenu =
                ";Add to My Workspace...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Monitoring.MonitoringPageResources;AddToFavorites";
            //";Add to My Workspace...;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Monitoring.MonitoringPageResources.en;AddToFavorites";

            /// <summary>
            /// Contains resource string for:  new Dashboard View context menu item
            /// </summary>
            private const string ResourceNewDashboardViewContextMenu =
                ";Dash&board View" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.ViewBaseClasses.ViewResource" +
                ";CreateDashboardInstanceMenuText";

            //";Dash&board View;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.ViewBaseClasses.ViewResource;CreateDashboardInstanceMenuText";

            /// <summary>
            ///  Contains resource string for: new Overrides Summary View context menu item
            /// </summary>
            public static string ResourceOverridesSummaryViewContextMenu =
                ";&Overrides Summary View;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.ViewBaseClasses.ViewResource;OverridesViewMenuText";
            
            /// <summary>
            /// Contains resource string for: new Diagram View context menu item
            /// </summary>
            private const string ResourceDiagramViewContextMenu =
                ";&Diagram View;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.ViewBaseClasses.ViewResource;DiagramViewMenuText";

            /// <summary>
            /// Contains resource string for:  new Folder context menu item
            /// </summary>
            private const string ResourceNewFolderContextMenu =
                ";Folder..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Monitoring.MonitoringPageResources" +
                ";NewFolder";

            /// <summary>
            /// Contains resource string for:  Delete Context Menu
            /// </summary>
            private const string ResourceDeleteContextMenu =
                ";&Delete" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources" +
                ";DeleteMenuText";

            /// <summary>
            /// Contains resource string for:  Personalize View context menu item 
            /// </summary>   
            private const string ResourcePersonalizeContextMenu =
                ";Person&alize" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.ViewCommands" +
                ";PersonalizeMenuText";

            //";Person&alize;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ViewCommands;PersonalizeMenuText";

            /// <summary>
            /// Contains resource string for:  Properties View context menu item
            /// </summary>   
            private const string ResourcePropertiesContextMenu =
                ";P&roperties" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.ViewCommands" +
                ";ViewProperties.Text";

            //";P&roperties;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ViewCommands;PropertiesMenuText";

            /// <summary>
            /// Contains resource string for: Open
            /// </summary>
            private const string ResourceOpenContextMenu =
                ";Open" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";ViewMenuItemText";

            /// <summary>
            /// Contains resource string for:  Open->Alert View context menu item
            /// </summary>
            private const string ResourceOpenAlertViewContextMenu = ";Alert View;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;CommandJumpToAlertView";

            /// <summary>
            /// Contains resource string for:  Open->Event View context menu item
            /// </summary>
            private const string ResourceOpenEventViewContextMenu = ";Event View;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;CommandJumpToEventView";

            /// <summary>
            /// Contains resource string for:  Open->Performance View context menu item
            /// </summary>
            private const string ResourceOpenPerformanceViewContextMenu = ";Performance View;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;CommandJumpToPerformanceView";

            /// <summary>
            /// Contains resource string for:  Open->Diagram View context menu item
            /// </summary>
            private const string ResourceOpenDiagramViewContextMenu = ";Diagram View;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;CommandJumpToDiagramView";

            /// <summary>
            /// Contains resource string for:  Open->State View context menu item
            /// </summary>
            private const string ResourceOpenStateViewContextMenu = ";State View;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;CommandJumpToStateView";

            /// <summary>
            /// Contains resource string for:  Help context menu item
            /// </summary>
            private const string ResourceHelpContextMenu =
                ";&Help" +
                ";ManagedString" +
                ";Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll" +
                ";Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources" +
                ";HelpMenuText";

            /// <summary>
            /// Contains resource string for: Create new channel
            /// </summary>
            private const string ResourceCreateNewChannelContextMenu =
                ";Create new channel" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";NewChannels";

            /// <summary>
            /// Contains resource string for: Email...
            /// </summary>
            private const string ResourceEmailChannelContextMenu =
                ";Email..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";NewEmailChannel";

            /// <summary>
            /// Contains resource string for: Instant Message (IM)...
            /// </summary>
            private const string ResourceInstantMessageChannelContextMenu =
                ";Instant Message (IM)..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";NewIMChannel";

            /// <summary>
            /// Contains resource string for: Text Message (SMS)...
            /// </summary>
            private const string ResourceSmsChannelContextMenu =
                ";Text Message (SMS)..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";NewSMSChannel";

            /// <summary>
            /// Contains resource string for: Command...
            /// </summary>
            private const string ResourceCommandChannelContextMenu =
                ";Command..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources" +
                ";NewCommandChannel";

            /// <summary>
            /// Contains rescoure string for: Open in New Window for favorite
            /// </summary>
            private const string ResourceFavoritesOpenInNewWindowContextMenu = ";Open in New Window;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.FavoritesResources;OpenViewInNewWindow";
            #endregion

            /// <summary>
            /// Contains resource string for: System Center Operations Manager 2007
            /// This is going to be used when deleting a View. The confirmation Dialog Title
            /// </summary>
            private const string ResourceMomDialogTitle =
                @";System Center Operations Manager 2012;ManagedString;Microsoft.EnterpriseManagement.Monitoring.Console.exe;Microsoft.EnterpriseManagement.Monitoring.Console.ConsoleResources;ProductTitle";

            /// <summary>
            /// Time Added Column Resource        
            /// </summary>
            private const string timeAddedColumn =
                ";Time Added;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiscoveriesViewCriteriaResources;TimeAddedTitle";


            /// <summary>
            /// Contains resource string for: Specific link
            /// Used when selecting/setting view criteria in the view Properties dialog
            /// </summary>
            private const string ResourceSpecificLink =
                ";specific" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.CriteriaControl.CriteriaControlResource" +
                ";SpecificLink";

            /// <summary>
            /// Contains resource string for: Change Target Type...
            /// </summary>
            private const string ResourceChangeTargetTypeContextMenu =
                ";&Change Target Type...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.StateResources;InventoryViewChangeClassCommand";

            #region Task Status View Column Header

            /// <summary>
            /// Contains resource string for: Status Column header under Task Status View        
            /// </summary>
            private const string ResourceStatusColumnHeader =
            ";Status;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnStatus";

            /// <summary>
            /// Contains resource string for: Task Name Column header under Task Status View        
            /// </summary>
            private const string ResourceTaskNameColumnHeader =
            ";Task Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnTaskName";

            /// <summary>
            /// Contains resource string for: Schedule Time Column header under Task Status View        
            /// </summary>
            private const string ResourceScheduleTimeColumnHeader =
            ";Schedule Time;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnScheduleTime";

            /// <summary>
            /// Contains resource string for: Start Time Column header under Task Status View        
            /// </summary>
            private const string ResourceStartTimeColumnHeader =
            ";Start Time;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnStartTime";

            /// <summary>
            /// Contains resource string for: Submitted By Column header under Task Status View        
            /// </summary>
            private const string ResourceSubmittedByColumnHeader =
            ";Submitted By;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnSubmittedBy";

            /// <summary>
            /// Contains resource string for: Run As Column header under Task Status View        
            /// </summary>
            private const string ResourceRunAsColumnHeader =
            ";Run As;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnRunAs";

            /// <summary>
            /// Contains resource string for: Run Location Column header under Task Status View        
            /// </summary>
            private const string ResourceRunLocationColumnHeader =
            ";Run Location;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnRunLocation";

            /// <summary>
            /// Contains resource string for: Task Target Column header under Task Status View        
            /// </summary>
            private const string ResourceTaskTargetColumnHeader =
            ";Task Target;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnTargetID";

            /// <summary>
            /// Contains resource string for: Task Target Class Column header under Task Status View        
            /// </summary>
            private const string ResourceTaskTargetClassColumnHeader =
            ";Task Target Class;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnTargetedType";

            /// <summary>
            /// Contains resource string for: Category Column header under Task Status View        
            /// </summary>
            private const string ResourceCategoryColumnHeader =
            ";Category;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnCategory";

            /// <summary>
            /// Contains resource string for: Task Description Column header under Task Status View        
            /// </summary>
            private const string ResourceTaskDescriptionColumnHeader =
            ";Task Description;ManagedString;Microsoft.MOM.UI.Components.resources.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources.en;ColumnTaskDescription";

            /// <summary>
            /// Contains resource string for: Completed Time Column header under Task Status View        
            /// </summary>
            private const string ResourceCompletedTimeColumnHeader =
            ";Completed Time;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnTimeFinished";

            /// <summary>
            /// Contains resource string for: Last Modified Time Column header under Task Status View        
            /// </summary>
            private const string ResourceLastModifiedTimeColumnHeader =
            ";Last Modified Time;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources;ColumnLastModified";

            /// <summary>
            /// Resource string for Show Combined Task Output Actions pane item
            /// </summary>
            private const string ResourceShowCombinedTaskOutputActionItem =
                ";Show Combined Task Output" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.TaskStatusResources" +
                ";GroupedResultsText";

            #endregion

            /// <summary>
            /// Contains resource string for: Tool menu item      
            /// </summary>
            private const string ResourceToolMenu =
                ";&Tools;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;ToolsMenuText";

            /// <summary>
            /// Contains resource string for: Advanced search context menu      
            /// </summary>
            private const string ResourceAdvancedSearchContextMenu =
                ";&Advanced Search...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SearchCommands;AdvancedSearch";

            /// <summary>
            /// Contains resource string for: Display Name Column header for Select Ojbect under Diagram view       
            /// </summary>
            private const string ResourceDisplayNameColumnHeader =
                ";Display Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.UI.MonitoringObjectChooser;nameColumn.Text";

            /// <summary>
            /// Contains resource string for: Name Column header for Alert view       
            /// </summary>
            private const string ResourceAlertNameColumnHeader =
                ";Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;AlertName";

            /// <summary>
            /// Contains resource string for: Name Column header for State view       
            /// </summary>
            private const string ResourceStateNameColumnHeader =
                ";Name;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.StateResources;Name";

            /// <summary>
            /// Contains resource string for: Event number header for Event view       
            /// </summary>
            private const string ResourceEventNumberColumnHeader =
                ";Event Number;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.EventResources;ColumnEventNumber";

            /// <summary>
            /// Contains resource string for: Resolution State for Alert view       
            /// </summary>
            private const string ResourceResolutionStateColumnHeader =
                ";Resolution State;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;ResolutionState";

            /// <summary>
            /// Contains resource string for: Health State for Managed Ojbects view       
            /// </summary>
            private const string ResourceHealthStateColumnHeader =
                ";Health State;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.ManagedObjectView.ManagedObjectViewResource;HealthStateColumn";

            /// <summary>
            /// Contains resource string for: Type for Monitors
            /// </summary>
            private const string ResourceTypeColumnHeader =
                ";Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.HealthView.HealthViewResources;TypeColumn";

            /// <summary>
            /// Contains resource string for: Inherited from for Tasks   
            /// </summary>
            private const string ResourceInheritedFromColumnHeader =
               ";Inherited From;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.HealthView.HealthViewResources;InheritedFromColumn";

            /// <summary>
            /// Contains resource string for: View Type for Views
            /// </summary>
            private const string ResourceViewTypeColumnHeader =
                ";View Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.ViewDefinitionsView.ViewDefinitionsViewResources;ViewTypeText";

            /// <summary>
            /// Contains resource string for: Created Date for Object Discoveries       
            /// </summary>
            private const string ResourceCreatedDateColumnHeader =
                ";Created Date;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.DiscoveriesView.DiscoveriesViewResources;CreatedDateColumn";

            /// <summary>
            /// Contains resource string for: Created from Rule      
            /// </summary>
            private const string ResourceRuleCreatedColumnHeader =
                ";Created;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.RulesView.RulesViewResources;CreatedDateColumn";

            /// <summary>
            /// Contains resource string for: Forwarding Status for Alert view       
            /// </summary>
            private const string ResourceForwardingStatusColumnHeader =
                ";Forwarding Status;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;ConnectorStatus";

            /// <summary>
            /// Contains resource string for: Connector for Alert view       
            /// </summary>
            private const string ResourceConnectorColumnHeader =
                ";Connector;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.AlertResources;ConnectorId";

            /// <summary>
            /// Contains resource string for: Forwarding pending for Alert view       
            /// </summary>
            private const string ResourceForwardingPendingStatus =
                ";Forwarding pending;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Cache.AlertTranslator;ForwardingPending";

            /// <summary>
            /// Contains resource string for: Successfully forwarded for Alert view       
            /// </summary>
            private const string ResourceSuccessfullyForwardedStatus =
                ";Successfully forwarded;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Cache.AlertTranslator;ForwardingSuccess";

            #endregion

            #region Private Members

            /// <summary>
            /// AemApplicationStateViewGuid (Stored in Views Table)
            /// </summary>            
            private static string cachedAemApplicationStateViewGuid;

            /// <summary>
            /// AemViewFolderGuid (Stored in Views Table)
            /// </summary>            
            private static string cachedAemViewFolderGuid;

            /// <summary>
            /// AlertViewGuid (Stored in Views Table)
            /// </summary>
            private static string cachedAlertViewGuid;

            /// <summary>
            /// ComputersViewGuid 
            /// </summary>
            private static string cachedComputersViewGuid;

            /// <summary>
            /// EventViewGuid (Stored in the Views Table)
            /// </summary>
            private static string cachedEventViewGuid;

            /// <summary>
            /// PerformanceViewGuid (Stored in Views Table)
            /// </summary>
            private static string cachedPerformanceViewGuid;

            /// <summary>
            /// DiagramViewGuid (Stored in Views Table)
            /// </summary>
            private static string cachedDiagramViewGuid;

            /// <summary>
            /// StateViewGuid (Stored in Views Table)
            /// </summary>
            private static string cachedStateViewGuid;

            /// <summary>
            /// TaskStatusViewGuid (Stored in Views Table)
            /// </summary>
            private static string cachedTaskStatusViewGuid;

            /// <summary>
            /// AgentStateViewGuid (Stored in Views Table)
            /// </summary>
            private static string cachedAgentStateViewGuid;

            /// <summary>
            /// HealthServiceStateViewGuid (Stored in Views Table)
            /// </summary>
            private static string cachedHealthServiceStateViewGuid;

            /// <summary>
            /// HSWatcherStateViewGuid (Stored in Views Table)
            /// </summary>
            private static string cachedHSWatcherStateViewGuid;

            /// <summary>
            /// HealthMonitorsViewGuid (Stored in Views Table)
            /// </summary>
            private static string cachedHealthViewGuid;

            /// <summary>
            /// RulesViewGuid (Stored in Views Table)
            /// </summary>
            private static string cachedRulesViewGuid;

            /// <summary>
            /// TasksViewGuid (Stored in Views Table)
            /// </summary>
            private static string cachedTasksViewGuid;

            /// <summary>
            /// ApplicationStructureViewGuid (Stored in Views Table)
            /// </summary>
            private static string cachedApplicationStructureViewGuid;

            /// <summary>
            /// AttributesViewGuid (Stored in Views Table)
            /// </summary>
            private static string cachedAttributesViewGuid;

            /// <summary>
            /// ObjectDiscoveriesViewGuid (Stored in Views Table)
            /// </summary>
            private static string cachedObjectDiscoveriesViewGuid;

            /// <summary>
            ///  Caches the translated resource string for: Overrides Summary View
            /// </summary>
            private static string cachedOverridesSummaryViewContextMenu;

            /// <summary>
            ///  OverridesViewGuid (Stored in Views Table)
            /// </summary>
            private static string cachedOverridesViewGuid;

            /// <summary>
            /// ViewDefinitionsViewGuid (Stored in Views Table)
            /// </summary>
            private static string cachedViewDefinitionsViewGuid;

            /// <summary>
            /// Caches the translated resource string for:  Delete Context Menu
            /// </summary>
            private static string cachedDeleteContextMenu;

            /// <summary>
            /// Caches the translated resource string for:  Context Menu "Personalize"
            /// </summary>
            private static string cachedPersonalizeContextMenu;

            /// <summary>
            /// Caches the translated resource string for:  Context Menu "Properties"
            /// </summary>
            private static string cachedPropertiesContextMenu;

            /// <summary>
            /// Caches the translated resource string for:  Context Menu "New"
            /// </summary>
            private static string cachedNewContextMenu;

            /// <summary>
            /// Caches the translated resource string for:  Context Menu new "Alert View"
            /// </summary>
            private static string cachedNewAlertViewContextMenu;

            /// <summary>
            /// Caches the translated resource string for:  Context Menu new "Event View"
            /// </summary>
            private static string cachedNewEventViewContextMenu;

            /// <summary>
            /// Caches the translated resource string for:  Context Menu new "State View"
            /// </summary>
            private static string cachedNewStateViewContextMenu;

            /// <summary>
            /// Caches the translated resource string for:  Context Menu new "Performance View" 
            /// </summary>
            private static string cachedNewPerformanceViewContextMenu;

            /// <summary>
            /// Caches the translated resource string for:  Context Menu new "Task Status View"
            /// </summary>
            private static string cachedNewTaskStatusViewContextMenu;

            /// <summary>
            /// Caches the translated resource string for:  Context Menu new "Web Page View"
            /// </summary>
            private static string cachedNewWebPageViewContextMenu;

            /// <summary>
            /// Caches the translated resource string for:  Context Menu new "AddToMyWorkSpace"
            /// </summary>
            private static string cachedAddToMyWorkSpaceContextMenu;

            /// <summary>
            /// Caches the translated resource string for:  Context Menu new "Dashboard View"
            /// </summary>
            private static string cachedNewDashboardViewContextMenu;

            /// <summary>
            /// Caches the translated resource string for: Context Menu new "Diargam View"
            /// </summary>
            private static string cachedNewDiagramViewContextMenu;

            /// <summary>
            /// Caches the translated resource string for:  Context Menu new "Folder"
            /// </summary>
            private static string cachedNewFolderContextMenu;

            /// <summary>
            /// Contains resource string for: Events Window Title.
            /// </summary>
            private static string cachedEventsWindowTitle;

            /// <summary>
            /// Contains resource string for: Alerts Window Title.
            /// </summary>
            private static string cachedAlertsWindowTitle;

            /// <summary>
            /// Contains resource string for: Performance Window Title.
            /// </summary>
            private static string cachedPerformanceWindowTitle;

            /// <summary>
            /// Contains resource string for: State Window Title.
            /// </summary>
            private static string cachedStateWindowTitle;

            /// <summary>
            /// Contains resource string for: State Window Title.
            /// </summary>
            private static string cachedDiagramWindowTitle;

            /// <summary>
            ///  Contains resource string for: Open
            /// </summary>
            private static string cachedOpenContextMenu;

            /// <summary>
            ///  Contains resource string for: Open->Alert View
            /// </summary>
            private static string cachedOpenAlertViewContextMenu;

            /// <summary>
            ///  Contains resource string for: Open->Event View
            /// </summary>
            private static string cachedOpenEventViewContextMenu;

            /// <summary>
            ///  Contains resource string for: Open->Performance View
            /// </summary>
            private static string cachedOpenPerformanceViewContextMenu;

            /// <summary>
            ///  Contains resource string for: Open->Diagram View
            /// </summary>
            private static string cachedOpenDiagramViewContextMenu;

            /// <summary>
            ///  Contains resource string for: Open->State View
            /// </summary>
            private static string cachedOpenStateViewContextMenu;

            /// <summary>
            /// Contains resource string for: Delete View Confirmation Dialog Title.
            /// </summary>
            private static string cachedMomDialogTitle;

            /// <summary>
            /// Contains resource string for: Specific link in the view criteria selection
            /// </summary>
            private static string cachedSpecificLink;

            /// <summary>
            /// Contains resource string for: Create New Channel context menu
            /// </summary>
            private static string cachedCreateNewChannelContextMenu;

            /// <summary>
            /// Contains resource string for: Email Channel context menu
            /// </summary>
            private static string cachedEmailChannelContextMenu;

            /// <summary>
            /// Contains resource string for: Instant Message Channel context menu
            /// </summary>
            private static string cachedInstantMessageChannelContextMenu;

            /// <summary>
            /// Contains resource string for: Text (SMS) Channel context menu
            /// </summary>
            private static string cachedSmsChannelContextMenu;

            /// <summary>
            /// Contains resource string for: Command Channel context menu
            /// </summary>
            private static string cachedCommandChannelContextMenu;

            /// <summary>
            /// Contains resource string for: Favorites Open In New Window
            /// </summary>
            private static string cashedFavoritesOpenInNewWindowContextMenu;

            /// <summary>
            /// Contains resource string for: Change Target Type context menu
            /// </summary>
            private static string cachedChangeTargetTypeContextMenu;


            #region task status view column header
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Status Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStatusColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Task Name Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskNameColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Schedule Time Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedScheduleTimeColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Start Time Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStartTimeColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Submitted By Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSubmittedByColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Run As Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunAsColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Run Location Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedRunLocationColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Task Target Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskTargetColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Task Target Class Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskTargetClassColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Category Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCategoryColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Task Description Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTaskDescriptionColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Completed Time Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCompletedTimeColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Last Modified Time Column header under Task Status View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLastModifiedTimeColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Tool menu item
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedToolsMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Advanced Search context menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAdvancedSearchContextMenu;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Display Name Column header for select object under Diagram View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDisplayNameColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name Column header for Alert View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAlertNameColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name Column header for State View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedStateNameColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Event number Column header for Event View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedEventNumberColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Resolution State for Alert view
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedResolutionStateColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Health State for Managed Objects view
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHealthStateColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Type for Monitors
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTypeColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Created Date for Object Discoveries
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreatedDateColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Inherited From for Tasks
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedInheritedFromColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Created for Rules
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedCreatedColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  View Type for Views
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedViewTypeColumnHeader;

            /// <summary>
            /// Contains resource string for: Help
            /// </summary>
            private static string cachedHelpContextMenu;

            /// <summary>
            /// Contains resource string for: Show Combined Task Output
            /// </summary>
            private static string cachedShowCombinedTaskOutputActionItem;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Forwarding Status for Alert view
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedForwardingStatusColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Connector for Alert view
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConnectorColumnHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Forwarding pending status for Alert view
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedForwardingPendingStatus;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Successfully Forwarded status for Alert view
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSuccessfullyForwardedStatus;

            #endregion

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Aem Application state view translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 01MAY06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AemApplicationStateView
            {
                get
                {
                    if ((cachedAemApplicationStateViewGuid == null))
                    {
                        cachedAemApplicationStateViewGuid =
                            Core.Common.Utilities.GetViewName(
                            ResourceAemApplicationStateViewGuid);
                    }

                    return cachedAemApplicationStateViewGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Aem View Folder translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 03DEC06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AemViewFolder
            {
                get
                {
                    if ((cachedAemViewFolderGuid == null))
                    {
                        cachedAemViewFolderGuid =
                            Core.Common.Utilities.GetMonitorFolderHierarchy(
                            ResourceAemViewFolderGuid);
                    }

                    return cachedAemViewFolderGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Alert View translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 03OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertView
            {
                get
                {
                    if ((cachedAlertViewGuid == null))
                    {
                        cachedAlertViewGuid =
                            Core.Common.Utilities.GetViewName(ResourceAlertViewGuid);
                    }

                    return cachedAlertViewGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Computers View translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 15AUG06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ComputersView
            {
                get
                {
                    if ((cachedComputersViewGuid == null))
                    {
                        cachedComputersViewGuid =
                            Core.Common.Utilities.GetViewName(ResourceComputersViewGuid);
                    }

                    return cachedComputersViewGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to EventView translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 03OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventView
            {
                get
                {
                    if ((cachedEventViewGuid == null))
                    {
                        cachedEventViewGuid =
                            Core.Common.Utilities.GetViewName(ResourceEventViewGuid);
                    }

                    return cachedEventViewGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to PerformanceView translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 03OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PerformanceView
            {
                get
                {
                    if ((cachedPerformanceViewGuid == null))
                    {
                        cachedPerformanceViewGuid =
                            Core.Common.Utilities.GetViewName(ResourcePerformanceViewGuid);
                    }

                    return cachedPerformanceViewGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to DiagramView translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 03OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiagramView
            {
                get
                {
                    if ((cachedDiagramViewGuid == null))
                    {
                        cachedDiagramViewGuid =
                            Core.Common.Utilities.GetViewName(ResourceDiagramViewGuid);
                    }

                    return cachedDiagramViewGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to StateView translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 03OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StateView
            {
                get
                {
                    if ((cachedStateViewGuid == null))
                    {
                        cachedStateViewGuid =
                            Core.Common.Utilities.GetViewName(ResourceStateViewGuid);
                    }

                    return cachedStateViewGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to TaskStatusView translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 03OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskStatusView
            {
                get
                {
                    if ((cachedTaskStatusViewGuid == null))
                    {
                        cachedTaskStatusViewGuid =
                            Core.Common.Utilities.GetViewName(ResourceTaskStatusViewGuid);
                    }

                    return cachedTaskStatusViewGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Computer State View translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 08JUL08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AgentStateView
            {
                get
                {
                    if ((cachedAgentStateViewGuid == null))
                    {
                        cachedAgentStateViewGuid =
                            Core.Common.Utilities.GetViewName(ResourceAgentStateViewGuid);
                    }

                    return cachedAgentStateViewGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Health Service State View translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 08JUL08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HealthServiceStateView
            {
                get
                {
                    if ((cachedHealthServiceStateViewGuid == null))
                    {
                        cachedHealthServiceStateViewGuid =
                            Core.Common.Utilities.GetViewName(ResourceHealthServiceStateViewGuid);
                    }

                    return cachedHealthServiceStateViewGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to Health Service Watcher State View translated resource string
            /// </summary>
            /// <history>
            /// 	[dialac] 08JUL08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HSWatcherStateView
            {
                get
                {
                    if ((cachedHSWatcherStateViewGuid == null))
                    {
                        cachedHSWatcherStateViewGuid =
                            Core.Common.Utilities.GetViewName(ResourceHSWatcherStateViewGuid);
                    }

                    return cachedHSWatcherStateViewGuid;
                }
            }


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to HealthView translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 03OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HealthView
            {
                get
                {
                    if ((cachedHealthViewGuid == null))
                    {
                        cachedHealthViewGuid =
                            Core.Common.Utilities.GetViewName(ResourceHealthViewGuid);
                    }

                    return cachedHealthViewGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to RulesView translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 03OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RulesView
            {
                get
                {
                    if ((cachedRulesViewGuid == null))
                    {
                        cachedRulesViewGuid =
                            Core.Common.Utilities.GetViewName(ResourceRulesViewGuid);
                    }

                    return cachedRulesViewGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to TasksView translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 03OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TasksView
            {
                get
                {
                    if ((cachedTasksViewGuid == null))
                    {
                        cachedTasksViewGuid =
                            Core.Common.Utilities.GetViewName(ResourceTasksViewGuid);
                    }

                    return cachedTasksViewGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to ApplicationStructureView translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 03OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ApplicationStructureView
            {
                get
                {
                    if ((cachedApplicationStructureViewGuid == null))
                    {
                        cachedApplicationStructureViewGuid =
                            Core.Common.Utilities.GetViewName(ResourceApplicationStructureViewGuid);
                    }

                    return cachedApplicationStructureViewGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to AttributesView translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 03OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AttributesView
            {
                get
                {
                    if ((cachedAttributesViewGuid == null))
                    {
                        cachedAttributesViewGuid =
                            Core.Common.Utilities.GetViewName(ResourceAttributesViewGuid);
                    }

                    return cachedAttributesViewGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to ObjectDiscoveriesView translated resource string
            /// </summary>
            /// <history>
            /// 	[visnara] 26APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ObjectDiscoveriesView
            {
                get
                {
                    if ((cachedObjectDiscoveriesViewGuid == null))
                    {
                        cachedObjectDiscoveriesViewGuid = Core.Common.Utilities.GetViewName(ResourceObjectDiscoveriesViewGuid);
                    }

                    return cachedObjectDiscoveriesViewGuid;
                }
            }

            /// <summary>
            ///  Exposes access to OverridesSummaryView translated resource string
            /// </summary>
            public static string OverridesView
            {
                get
                {
                    if (cachedOverridesViewGuid == null)
                    {
                        cachedOverridesViewGuid = Core.Common.Utilities.GetViewName(ResourceOverridesViewGuid);
                    }

                    return cachedOverridesViewGuid;
                }
            }

            /// <summary>
            ///  Exposes access to OverridesSummaryView translated resource string
            /// </summary>
            public static string OverridesSummaryView
            {
                get
                {
                    if (cachedOverridesSummaryViewContextMenu == null)
                    {
                        cachedOverridesSummaryViewContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceOverridesSummaryViewContextMenu);
                    }

                    return cachedOverridesSummaryViewContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to ViewDefinitionsView translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 03OCT05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewDefinitionsView
            {
                get
                {
                    if ((cachedViewDefinitionsViewGuid == null))
                    {
                        cachedViewDefinitionsViewGuid =
                            Core.Common.Utilities.GetViewName(ResourceViewDefinitionsViewGuid);
                    }

                    return cachedViewDefinitionsViewGuid;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Delete Context Menu translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 23FEB06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DeleteContextMenu
            {
                get
                {
                    if ((cachedDeleteContextMenu == null))
                    {
                        cachedDeleteContextMenu =
                            CoreManager.MomConsole.GetIntlStr(ResourceDeleteContextMenu);
                    }

                    return cachedDeleteContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the New menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 23FEB06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NewContextMenu
            {
                get
                {
                    if ((cachedNewContextMenu == null))
                    {
                        cachedNewContextMenu =
                            CoreManager.MomConsole.GetIntlStr(ResourceNewContextMenu);
                    }

                    return cachedNewContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NewAlertView menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 23FEB06 Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertViewContextMenu
            {
                get
                {
                    if ((cachedNewAlertViewContextMenu == null))
                    {
                        cachedNewAlertViewContextMenu =
                            CoreManager.MomConsole.GetIntlStr(ResourceNewAlertViewContextMenu);
                    }

                    return cachedNewAlertViewContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NewEventView menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 23FEB06 Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventViewContextMenu
            {
                get
                {
                    if ((cachedNewEventViewContextMenu == null))
                    {
                        cachedNewEventViewContextMenu =
                            CoreManager.MomConsole.GetIntlStr(ResourceNewEventViewContextMenu);
                    }

                    return cachedNewEventViewContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NewStateView menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 23FEB06 Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StateViewContextMenu
            {
                get
                {
                    if ((cachedNewStateViewContextMenu == null))
                    {
                        cachedNewStateViewContextMenu =
                            CoreManager.MomConsole.GetIntlStr(ResourceNewStateViewContextMenu);
                    }

                    return cachedNewStateViewContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NewPerformanceView menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 23JUN06 Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PerformanceViewContextMenu
            {
                get
                {
                    if ((cachedNewPerformanceViewContextMenu == null))
                    {
                        cachedNewPerformanceViewContextMenu =
                            CoreManager.MomConsole.GetIntlStr(ResourceNewPerformanceViewContextMenu);
                    }

                    return cachedNewPerformanceViewContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the TaskStatusView menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 23JUN06 Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskStatusViewContextMenu
            {
                get
                {
                    if ((cachedNewTaskStatusViewContextMenu == null))
                    {
                        cachedNewTaskStatusViewContextMenu =
                            CoreManager.MomConsole.GetIntlStr(ResourceNewTaskStatusViewContextMenu);
                    }

                    return cachedNewTaskStatusViewContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WebPageView menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 23JUN06 Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WebPageViewContextMenu
            {
                get
                {
                    if ((cachedNewWebPageViewContextMenu == null))
                    {
                        cachedNewWebPageViewContextMenu =
                            CoreManager.MomConsole.GetIntlStr(ResourceNewWebPageViewContextMenu);
                    }

                    return cachedNewWebPageViewContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddToMyWorkSpace menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[sunsingh] 18Feb09 Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddToMyWorkSpaceContextMenu
            {
                get
                {
                    if ((cachedAddToMyWorkSpaceContextMenu == null))
                    {
                        cachedAddToMyWorkSpaceContextMenu =
                            CoreManager.MomConsole.GetIntlStr(ResourceAddToMyWorkSpaceContextMenu);
                    }

                    return cachedAddToMyWorkSpaceContextMenu;
                }
            }
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DashboardView menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 23JUN06 Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DashboardViewContextMenu
            {
                get
                {
                    if ((cachedNewDashboardViewContextMenu == null))
                    {
                        cachedNewDashboardViewContextMenu =
                            Utilities.RemoveAcceleratorKeys(CoreManager.MomConsole.GetIntlStr(ResourceNewDashboardViewContextMenu));
                    }

                    return cachedNewDashboardViewContextMenu;
                }
            }


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DiagramView menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 24NOV08 Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiagramViewContextMenu
            {
                get
                {
                    if ((cachedNewDiagramViewContextMenu == null))
                    {
                        cachedNewDiagramViewContextMenu =
                            CoreManager.MomConsole.GetIntlStr(ResourceDiagramViewContextMenu);
                    }

                    return cachedNewDiagramViewContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Folder menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 23JUN06 Created 
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FolderContextMenu
            {
                get
                {
                    if ((cachedNewFolderContextMenu == null))
                    {
                        cachedNewFolderContextMenu =
                            CoreManager.MomConsole.GetIntlStr(ResourceNewFolderContextMenu);
                    }

                    return cachedNewFolderContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Personalize view menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 23FEB06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PersonalizeContextMenu
            {
                get
                {
                    if ((cachedPersonalizeContextMenu == null))
                    {
                        cachedPersonalizeContextMenu =
                            CoreManager.MomConsole.GetIntlStr(ResourcePersonalizeContextMenu);
                    }

                    return cachedPersonalizeContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Properties context menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 23FEB06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PropertiesContextMenu
            {
                get
                {
                    if ((cachedPropertiesContextMenu == null))
                    {
                        cachedPropertiesContextMenu =
                            CoreManager.MomConsole.GetIntlStr(ResourcePropertiesContextMenu);
                    }

                    return cachedPropertiesContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Events Window Title
            /// </summary>
            /// <history>
            /// 	[mbickle] 24ARP06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventsWindowTitle
            {
                get
                {
                    if ((cachedEventsWindowTitle == null))
                    {
                        cachedEventsWindowTitle =
                            Utilities.GetViewName(ResourceEventsWindowTitle);
                    }

                    return cachedEventsWindowTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Alerts Window Title
            /// </summary>
            /// <history>
            /// 	[mbickle] 24ARP06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertsWindowTitle
            {
                get
                {
                    if ((cachedAlertsWindowTitle == null))
                    {
                        cachedAlertsWindowTitle =
                            Utilities.GetViewName(ResourceAlertsWindowTitle);
                    }

                    return cachedAlertsWindowTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Performance Window Title
            /// </summary>
            /// <history>
            /// 	[mbickle] 24ARP06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string PerformanceWindowTitle
            {
                get
                {
                    if ((cachedPerformanceWindowTitle == null))
                    {
                        cachedPerformanceWindowTitle =
                            Utilities.GetViewName(ResourcePerformanceWindowTitle);
                    }

                    return cachedPerformanceWindowTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the State Window Title
            /// </summary>
            /// <history>
            /// 	[mbickle] 24ARP06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StateWindowTitle
            {
                get
                {
                    if ((cachedStateWindowTitle == null))
                    {
                        cachedStateWindowTitle =
                            Utilities.GetViewName(ResourceStateWindowTitle);
                    }

                    return cachedStateWindowTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Diagram Window Title
            /// </summary>
            /// <history>
            /// 	[mbickle] 24ARP06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DiagramWindowTitle
            {
                get
                {
                    if ((cachedDiagramWindowTitle == null))
                    {
                        cachedDiagramWindowTitle =
                            Utilities.GetViewName(ResourceDiagramWindowTitle);
                    }

                    return cachedDiagramWindowTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Open Context Menu translated resource string
            /// </summary>
            /// <history>
            /// 	[mbickle] 15SEP06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OpenContextMenu
            {
                get
                {
                    if ((cachedOpenContextMenu == null))
                    {
                        cachedOpenContextMenu =
                            CoreManager.MomConsole.GetIntlStr(ResourceOpenContextMenu);
                    }

                    return cachedOpenContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Open->Alert View Context Menu translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 14AUG08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OpenAlertViewContextMenu
            {
                get
                {
                    if ((cachedOpenAlertViewContextMenu == null))
                    {
                        cachedOpenAlertViewContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceOpenAlertViewContextMenu);
                    }

                    return cachedOpenAlertViewContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Open->Event View Context Menu translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 14AUG08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OpenEventViewContextMenu
            {
                get
                {
                    if ((cachedOpenEventViewContextMenu == null))
                    {
                        cachedOpenEventViewContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceOpenEventViewContextMenu);
                    }

                    return cachedOpenEventViewContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Open->Performance View Context Menu translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 14AUG08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OpenPerformanceViewContextMenu
            {
                get
                {
                    if ((cachedOpenPerformanceViewContextMenu == null))
                    {
                        cachedOpenPerformanceViewContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceOpenPerformanceViewContextMenu);
                    }

                    return cachedOpenPerformanceViewContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Open->Diagram View Context Menu translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 14AUG08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OpenDiagramViewContextMenu
            {
                get
                {
                    if ((cachedOpenDiagramViewContextMenu == null))
                    {
                        cachedOpenDiagramViewContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceOpenDiagramViewContextMenu);
                    }

                    return cachedOpenDiagramViewContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Open->State View Context Menu translated resource 
            /// string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 14AUG08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OpenStateViewContextMenu
            {
                get
                {
                    if ((cachedOpenStateViewContextMenu == null))
                    {
                        cachedOpenStateViewContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceOpenStateViewContextMenu);
                    }

                    return cachedOpenStateViewContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Open in new window menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 21Nov08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string FavoriteOpenInNewWindowContextMenu
            {
                get
                {
                    if ((cashedFavoritesOpenInNewWindowContextMenu == null))
                    {
                        cashedFavoritesOpenInNewWindowContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceFavoritesOpenInNewWindowContextMenu);
                    }

                    return cashedFavoritesOpenInNewWindowContextMenu;
                }
            }


            /// <summary>
            /// View's Delete dialog title
            /// </summary>
            public static string MomDialogTitle
            {
                get
                {
                    if ((Strings.cachedMomDialogTitle == null))
                    {
                        cachedMomDialogTitle = CoreManager.MomConsole.GetIntlStr(
                            ResourceMomDialogTitle);
                    }
                    return Strings.cachedMomDialogTitle;
                }
            }

            /// <summary>
            /// View's Delete dialog title
            /// </summary>
            public static string TimeAddedColumn
            {
                get
                {
                    return CoreManager.MomConsole.GetIntlStr(timeAddedColumn);
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Specific Link translated resource string
            /// </summary>
            /// <history>
            /// 	[lucyra] 5APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SpecificLink
            {
                get
                {
                    if ((cachedSpecificLink == null))
                    {
                        cachedSpecificLink =
                            CoreManager.MomConsole.GetIntlStr(ResourceSpecificLink);
                    }

                    return cachedSpecificLink;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Create New Channel translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 07AUG08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreateNewChannelContextMenu
            {
                get
                {
                    if ((cachedCreateNewChannelContextMenu == null))
                    {
                        cachedCreateNewChannelContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCreateNewChannelContextMenu);
                    }

                    return cachedCreateNewChannelContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Email channel translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 07AUG08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EmailChannelContextMenu
            {
                get
                {
                    if ((cachedEmailChannelContextMenu == null))
                    {
                        cachedEmailChannelContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceEmailChannelContextMenu);
                    }

                    return cachedEmailChannelContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Instant Message channel translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 07AUG08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InstantMessageChannelContextMenu
            {
                get
                {
                    if ((cachedInstantMessageChannelContextMenu == null))
                    {
                        cachedInstantMessageChannelContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceInstantMessageChannelContextMenu);
                    }

                    return cachedInstantMessageChannelContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Text (SMS) channel translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 07AUG08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SmsChannelContextMenu
            {
                get
                {
                    if ((cachedSmsChannelContextMenu == null))
                    {
                        cachedSmsChannelContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceSmsChannelContextMenu);
                    }

                    return cachedSmsChannelContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Command channel translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 07AUG08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CommandChannelContextMenu
            {
                get
                {
                    if ((cachedCommandChannelContextMenu == null))
                    {
                        cachedCommandChannelContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCommandChannelContextMenu);
                    }

                    return cachedCommandChannelContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Change Target Type... resource string
            /// </summary>
            /// <history>
            /// 	[v-yoz] 24DEC08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ChangeTargetTypeContextMenu
            {
                get
                {
                    if ((cachedChangeTargetTypeContextMenu == null))
                    {
                        cachedChangeTargetTypeContextMenu =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceChangeTargetTypeContextMenu);
                    }

                    return cachedChangeTargetTypeContextMenu;
                }
            }


            #region Task Status View column header

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Status Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StatusColumnHeader
            {
                get
                {
                    if ((cachedStatusColumnHeader == null))
                    {
                        cachedStatusColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceStatusColumnHeader);
                    }

                    return cachedStatusColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Task Name Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskNameColumnHeader
            {
                get
                {
                    if ((cachedTaskNameColumnHeader == null))
                    {
                        cachedTaskNameColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceTaskNameColumnHeader);
                    }

                    return cachedTaskNameColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Schedule Time Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ScheduleTimeColumnHeader
            {
                get
                {
                    if ((cachedScheduleTimeColumnHeader == null))
                    {
                        cachedScheduleTimeColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceScheduleTimeColumnHeader);
                    }

                    return cachedScheduleTimeColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Start Time Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StartTimeColumnHeader
            {
                get
                {
                    if ((cachedStartTimeColumnHeader == null))
                    {
                        cachedStartTimeColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceStartTimeColumnHeader);
                    }

                    return cachedStartTimeColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Submitted By Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SubmittedByColumnHeader
            {
                get
                {
                    if ((cachedSubmittedByColumnHeader == null))
                    {
                        cachedSubmittedByColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceSubmittedByColumnHeader);
                    }

                    return cachedSubmittedByColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Run As Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunAsColumnHeader
            {
                get
                {
                    if ((cachedRunAsColumnHeader == null))
                    {
                        cachedRunAsColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceRunAsColumnHeader);
                    }

                    return cachedRunAsColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Run Location Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RunLocationColumnHeader
            {
                get
                {
                    if ((cachedRunLocationColumnHeader == null))
                    {
                        cachedRunLocationColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceRunLocationColumnHeader);
                    }

                    return cachedRunLocationColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Task Target Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskTargetColumnHeader
            {
                get
                {
                    if ((cachedTaskTargetColumnHeader == null))
                    {
                        cachedTaskTargetColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceTaskTargetColumnHeader);
                    }

                    return cachedTaskTargetColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Task Target Class Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskTargetClassColumnHeader
            {
                get
                {
                    if ((cachedTaskTargetClassColumnHeader == null))
                    {
                        cachedTaskTargetClassColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceTaskTargetClassColumnHeader);
                    }

                    return cachedTaskTargetClassColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Category Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CategoryColumnHeader
            {
                get
                {
                    if ((cachedCategoryColumnHeader == null))
                    {
                        cachedCategoryColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceCategoryColumnHeader);
                    }

                    return cachedCategoryColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Task Description Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TaskDescriptionColumnHeader
            {
                get
                {
                    if ((cachedTaskDescriptionColumnHeader == null))
                    {
                        cachedTaskDescriptionColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceTaskDescriptionColumnHeader);
                    }

                    return cachedTaskDescriptionColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Completed Time Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CompletedTimeColumnHeader
            {
                get
                {
                    if ((cachedCompletedTimeColumnHeader == null))
                    {
                        cachedCompletedTimeColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceCompletedTimeColumnHeader);
                    }

                    return cachedCompletedTimeColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Last Modified Time Column header under Task Status View translated resource string
            /// </summary>
            /// <history>
            /// 	[zhihaoq] 04/01/2008 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LastModifiedTimeColumnHeader
            {
                get
                {
                    if ((cachedLastModifiedTimeColumnHeader == null))
                    {
                        cachedLastModifiedTimeColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceLastModifiedTimeColumnHeader);
                    }

                    return cachedLastModifiedTimeColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Tools menu item translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 02/24/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ToolsMenu
            {
                get
                {
                    if ((cachedToolsMenu == null))
                    {
                        cachedToolsMenu = CoreManager.MomConsole.GetIntlStr(ResourceToolMenu);
                    }

                    return cachedToolsMenu;
                }

            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Advanced search context menu translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 02/24/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AdvancedSearchContextMenu
            {
                get
                {
                    if ((cachedAdvancedSearchContextMenu == null))
                    {
                        cachedAdvancedSearchContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceAdvancedSearchContextMenu);
                    }

                    return cachedAdvancedSearchContextMenu;
                }

            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Display name Column header for select object under Diagram View translated resource string
            /// </summary>
            /// <history>
            /// 	[v-cheli] 02/24/2009 Created
            /// 	[v-lileo] 07/14/2011 Edited
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DisplayNameColumnHeader
            {
                get
                {
                    if ((cachedDisplayNameColumnHeader == null))
                    {
                        //Get Display Column header name from System.Library.MP,bug#211865
                        cachedDisplayNameColumnHeader = Utilities.GetManagementPackClassDisplayName(ManagementPackConstants.GUIDSystemLibraryMP, ManagementPackConstants.SystemEntityName, ManagementPackConstants.DisplayName);
                        Utilities.LogMessage("ColumnHeader name is " + cachedDisplayNameColumnHeader);
                    }

                    return cachedDisplayNameColumnHeader;
                }

            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name Column header for Alert view
            /// </summary>
            /// <history>
            /// 	[v-cheli] 02/25/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AlertNameColumnHeader
            {
                get
                {
                    if ((cachedAlertNameColumnHeader == null))
                    {
                        cachedAlertNameColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceAlertNameColumnHeader);
                    }

                    return cachedAlertNameColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name Column header for State view
            /// </summary>
            /// <history>
            /// 	[v-cheli] 02/25/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string StateNameColumnHeader
            {
                get
                {
                    if ((cachedStateNameColumnHeader == null))
                    {
                        cachedStateNameColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceStateNameColumnHeader);
                    }

                    return cachedStateNameColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Event number Column header for Event view
            /// </summary>
            /// <history>
            /// 	[v-cheli] 02/25/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string EventNumberColumnHeader
            {
                get
                {
                    if ((cachedEventNumberColumnHeader == null))
                    {
                        cachedEventNumberColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceEventNumberColumnHeader);
                    }

                    return cachedEventNumberColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Resolution State column header for Alert view
            /// </summary>
            /// <history>
            /// 	[v-cheli] 02/25/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ResolutionStateColumnHeader
            {
                get
                {
                    if ((cachedResolutionStateColumnHeader == null))
                    {
                        cachedResolutionStateColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceResolutionStateColumnHeader);
                    }

                    return cachedResolutionStateColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Health State column header for Managed Objects view
            /// </summary>
            /// <history>
            /// 	[v-cheli] 02/25/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HealthStateColumnHeader
            {
                get
                {
                    if ((cachedHealthStateColumnHeader == null))
                    {
                        cachedHealthStateColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceHealthStateColumnHeader);
                    }

                    return cachedHealthStateColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Type column header for Monitors
            /// </summary>
            /// <history>
            /// 	[v-cheli] 02/25/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TypeColumnHeader
            {
                get
                {
                    if ((cachedTypeColumnHeader == null))
                    {
                        cachedTypeColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceTypeColumnHeader);
                    }

                    return cachedTypeColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Created Date column header for Object Discoveries
            /// </summary>
            /// <history>
            /// 	[v-cheli] 02/25/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CreatedDateColumnHeader
            {
                get
                {
                    if ((cachedCreatedDateColumnHeader == null))
                    {
                        cachedCreatedDateColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceCreatedDateColumnHeader);
                    }

                    return cachedCreatedDateColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Inherited From column header for Tasks
            /// </summary>
            /// <history>
            /// 	[v-cheli] 02/25/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InheritedFromColumnHeader
            {
                get
                {
                    if ((cachedInheritedFromColumnHeader == null))
                    {
                        cachedInheritedFromColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceInheritedFromColumnHeader);
                    }

                    return cachedInheritedFromColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Created Column header for Rules
            /// </summary>
            /// <history>
            /// 	[v-cheli] 02/25/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RuleCreatedColumnHeader
            {
                get
                {
                    if ((cachedCreatedColumnHeader == null))
                    {
                        cachedCreatedColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceRuleCreatedColumnHeader);
                    }

                    return cachedCreatedColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the View Type column header for Views
            /// </summary>
            /// <history>
            /// 	[v-cheli] 02/25/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ViewTypeColumnHeader
            {
                get
                {
                    if ((cachedViewTypeColumnHeader == null))
                    {
                        cachedViewTypeColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceViewTypeColumnHeader);
                    }

                    return cachedViewTypeColumnHeader;
                }
            }


            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Help Context Menu translated resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 29MAY08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HelpContextMenu
            {
                get
                {
                    if ((cachedHelpContextMenu == null))
                    {
                        cachedHelpContextMenu =
                            CoreManager.MomConsole.GetIntlStr(ResourceHelpContextMenu);
                    }

                    return cachedHelpContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Show Combined Task Output Action Item translated 
            /// resource string
            /// </summary>
            /// <history>
            /// 	[KellyMor] 29MAY08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ShowCombinedTaskOutputActionItem
            {
                get
                {
                    if ((cachedShowCombinedTaskOutputActionItem == null))
                    {
                        cachedShowCombinedTaskOutputActionItem =
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceShowCombinedTaskOutputActionItem);
                    }

                    return cachedShowCombinedTaskOutputActionItem;
                }
            }

            #endregion

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Forwarding Status column header for Alert view
            /// </summary>
            /// <history>
            /// 	[v-yoz] 06/01/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ForwardingStatusColumnHeader
            {
                get
                {
                    if ((cachedForwardingStatusColumnHeader == null))
                    {
                        cachedForwardingStatusColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceForwardingStatusColumnHeader);
                    }

                    return cachedForwardingStatusColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Connector column header for Alert view
            /// </summary>
            /// <history>
            /// 	[v-yoz] 06/01/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConnectorColumnHeader
            {
                get
                {
                    if ((cachedConnectorColumnHeader == null))
                    {
                        cachedConnectorColumnHeader = CoreManager.MomConsole.GetIntlStr(ResourceConnectorColumnHeader);
                    }

                    return cachedConnectorColumnHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Forwarding pending status for Alert view
            /// </summary>
            /// <history>
            /// 	[v-yoz] 06/01/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ForwardingPendingStatus
            {
                get
                {
                    if ((cachedForwardingPendingStatus == null))
                    {
                        cachedForwardingPendingStatus = CoreManager.MomConsole.GetIntlStr(ResourceForwardingPendingStatus);
                    }

                    return cachedForwardingPendingStatus;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Successfully Forwarded status for Alert view
            /// </summary>
            /// <history>
            /// 	[v-yoz] 06/01/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string SuccessfullyForwardedStatus
            {
                get
                {
                    if ((cachedSuccessfullyForwardedStatus == null))
                    {
                        cachedSuccessfullyForwardedStatus = CoreManager.MomConsole.GetIntlStr(ResourceSuccessfullyForwardedStatus);
                    }

                    return cachedSuccessfullyForwardedStatus;
                }
            }

            #endregion
        }

        #endregion

        #region Private Members
        /// <summary>
        /// Timeout - 5000
        /// </summary>
        private const int timeout = 5000;

        /// <summary>
        /// cachedAlertViewPropertiesDialog
        /// </summary>
        private AlertViewPropertiesDialog cachedAlertViewPropertiesDialog;

        /// <summary>
        /// cachedEventViewPropertiesDialog
        /// </summary>
        private EventViewPropertiesDialog cachedEventViewPropertiesDialog;

        /// <summary>
        /// cachedTaskStatusViewPropertiesDialog
        /// </summary>
        private Mom.Test.UI.Core.Console.Views.TaskStatus.Dialogs.TaskStatusViewPropertiesDialog cachedTaskStatusViewPropertiesDialog;

        /// <summary>
        /// cachedWebPageViewPropertiesDialog
        /// </summary>
        private WebPagePropertiesDialog cachedWebPageViewPropertiesDialog;

        /// <summary>
        /// cachedStateViewPropertiesDialog
        /// </summary>
        private StateViewPropertiesDialog cachedStateViewPropertiesDialog;

        /// <summary>
        /// cachedPerformanceViewPropertiesDialog
        /// </summary>
        private PerfViewPropertiesDialog cachedPerfViewPropertiesDialog;

        /// <summary>
        ///  cachedOverridesSummaryViewPropertiesDialog
        /// </summary>
        private OverridesSummaryViewPropertiesDialog cachedOverridesSummaryViewPropertiesDialog;

        /// <summary>
        /// cachedDiagramViewPropertiesDialog
        /// </summary>
        private Diagram.CreateDiagramViewDialog cachedDiagramViewPropertiesDialog;

        #region Alert view criteria dialogs
        /// <summary>
        /// cachedAlertSeverityTypeViewCriteriaDialog
        /// </summary>
        private AlertTypeViewCriteria cachedAlertTypeViewCriteria;

        /// <summary>
        /// cachedAlertPriorityViewCriteriaDialog
        /// </summary>
        private AlertPriorityViewCriteria cachedAlertPriorityViewCriteria;

        /// <summary>
        /// cachedAlertResolutionStateViewCriteria
        /// </summary>
        private AlertResolutionStateViewCriteria cachedAlertResolutionStateViewCriteria;

        /// <summary>
        /// cachedAlertSourceViewCriteria
        /// </summary>
        private AlertSourceViewCriteria cachedAlertSourceViewCriteria;

        /// <summary>
        /// cachedWithSpecificNameViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedWithSpecificNameViewCriteria;

        /// <summary>
        /// cachedWithSpecificDescriptionViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedWithSpecificDescriptionViewCriteria;

        /// <summary>
        /// cachedDateAndTimeInputViewCriteria
        /// </summary>
        private AlertDateAndTimeInputViewCriteria cachedCreatedInSpecificTimePeriodViewCriteria;

        /// <summary>
        /// cachedAssignedToOwnerViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedAssignedToOwnerViewCriteria;

        /// <summary>
        /// cachedRasedByInstanceViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedRasedByInstanceViewCriteria;

        /// <summary>
        /// cachedLastModifiedByUserViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedLastModifiedByUserViewCriteria;

        /// <summary>
        /// cachedLastModifiedInSpecificTimePeriodViewCriteria
        /// </summary>
        private AlertDateAndTimeInputViewCriteria cachedLastModifiedInSpecificTimePeriodViewCriteria;

        /// <summary>
        /// cachedResolutionStateLastModifiedInSpecificTimePeriodViewCriteria
        /// </summary>
        private AlertDateAndTimeInputViewCriteria cachedResolutionStateLastModifiedInSpecificTimePeriodViewCriteria;

        /// <summary>
        /// cachedResolvedInSpecificTimePeriodViewCriteria
        /// </summary>
        private AlertDateAndTimeInputViewCriteria cachedResolvedInSpecificTimePeriodViewCriteria;

        /// <summary>
        /// cachedResolvedByUserViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedResolvedByUserViewCriteria;

        /// <summary>
        /// cachedWithTicketIDViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedWithTicketIDViewCriteria;

        /// <summary>
        /// cachedAddedToDatabaseInSpecificTimePeriodViewCriteria
        /// </summary>
        private AlertDateAndTimeInputViewCriteria cachedAddedToDatabaseInSpecificTimePeriodViewCriteria;

        /// <summary>
        /// cachedWithSiteViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedWithSiteViewCriteria;

        /// <summary>
        /// cachedWithCustomField1ViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedWithCustomField1ViewCriteria;

        /// <summary>
        /// cachedWithCustomField2ViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedWithCustomField2ViewCriteria;

        /// <summary>
        /// cachedWithCustomField3ViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedWithCustomField3ViewCriteria;

        /// <summary>
        /// cachedWithCustomField4ViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedWithCustomField4ViewCriteria;

        /// <summary>
        /// cachedWithCustomField5ViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedWithCustomField5ViewCriteria;

        /// <summary>
        /// cachedWithCustomField6ViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedWithCustomField6ViewCriteria;

        /// <summary>
        /// cachedWithCustomField7ViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedWithCustomField7ViewCriteria;

        /// <summary>
        /// cachedWithCustomField8ViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedWithCustomField8ViewCriteria;

        /// <summary>
        /// cachedWithCustomField9ViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedWithCustomField9ViewCriteria;

        /// <summary>
        /// cachedWithCustomField10ViewCriteria
        /// </summary>
        private AlertTextInputViewCriteria cachedWithCustomField10ViewCriteria;

        #endregion //end of Alert view criteria dialogs

        #region Event view criteria dialogs

        /// <summary>
        /// cachedGeneratedInSpecificTimePeriodViewCriteriaDialog
        /// </summary>
        private EventDateTimeViewCriteriaDialog cachedGeneratedInSpecificTimePeriodViewCriteriaDialog;

        /// <summary>
        /// cachedEventSelectRulesViewCriteriaDialog
        /// </summary>
        private EventSelectRulesViewCriteriaDialog cachedEventSelectRulesViewCriteriaDialog;

        /// <summary>
        /// cachedEventSeverityLevelViewCriteriaDialog
        /// </summary>
        private EventSeverityLevelViewCriteriaDialog cachedEventSeverityLevelViewCriteriaDialog;

        /// <summary>
        /// cachedWithSpecificEventNumberViewCriteriaDialog
        /// </summary>
        private EventTextInputViewCriteriaDialog cachedWithSpecificEventNumberViewCriteriaDialog;

        /// <summary>
        /// cachedFromSpecificSourceViewCriteriaDialog
        /// </summary>
        private EventTextInputViewCriteriaDialog cachedFromSpecificSourceViewCriteriaDialog;

        /// <summary>
        /// cachedRasedByInstanceWithSpecificNameViewCriteriaDialog
        /// </summary>
        private EventTextInputViewCriteriaDialog cachedRasedByInstanceWithSpecificNameViewCriteriaDialog;

        /// <summary>
        /// cachedFromSpecificUserViewCriteriaDialog
        /// </summary>
        private EventTextInputViewCriteriaDialog cachedFromSpecificUserViewCriteriaDialog;

        /// <summary>
        /// cachedWithSpecificLoggingComputerViewCriteriaDialog
        /// </summary>
        private EventTextInputViewCriteriaDialog cachedWithSpecificLoggingComputerViewCriteriaDialog;

        #endregion

        #region Task Status view criteria dialogs

        /// <summary>
        /// cachedTaskStatusViewCriteriaDialog
        /// </summary>
        private Mom.Test.UI.Core.Console.Views.TaskStatus.Dialogs.TaskSelectionWithSpecificStatusDialog cachedTaskStatusCriteriaDialog;

        #endregion

        /// <summary>
        /// Private Console App Reference
        /// </summary>
        private ConsoleApp consoleApp;

        #endregion

        #region Constructor

        /// <summary>
        /// Views Constructor.
        /// </summary>
        public Views()
        {
            this.consoleApp = CoreManager.MomConsole;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Select AlertViewPropertiesDialog
        /// </summary>
        /// <history>
        ///		[lucyra] 18JAN06 Created
        /// </history>
        public AlertViewPropertiesDialog AlertViewProperties
        {
            get
            {
                if (this.cachedAlertViewPropertiesDialog == null)
                {
                    this.cachedAlertViewPropertiesDialog = new AlertViewPropertiesDialog(CoreManager.MomConsole);

                    UISynchronization.WaitForUIObjectReady(this.cachedAlertViewPropertiesDialog, timeout);

                    Utilities.LogMessage("Views :: Success getting the Alert View Properties dialog");

                    this.cachedAlertViewPropertiesDialog.Extended.SetFocus();

                }

                return this.cachedAlertViewPropertiesDialog;

            }
        }

        /// <summary>
        /// Select EventViewPropertiesDialog
        /// </summary>
        /// <history>
        ///		[lucyra] 18JAN06 Created
        /// </history>
        public EventViewPropertiesDialog EventViewProperties
        {
            get
            {
                if (this.cachedEventViewPropertiesDialog == null)
                {
                    this.cachedEventViewPropertiesDialog = new EventViewPropertiesDialog(CoreManager.MomConsole);

                    UISynchronization.WaitForUIObjectReady(this.cachedEventViewPropertiesDialog, timeout);

                    Utilities.LogMessage("Views :: Success getting the Event View Properties dialog");

                    this.cachedEventViewPropertiesDialog.Extended.SetFocus();

                }

                return this.cachedEventViewPropertiesDialog;

            }
        }

        /// <summary>
        /// Select TaskStatusViewPropertiesDialog
        /// </summary>
        /// <history>
        ///		[v-eachu] 27SEP09 Created
        /// </history>
        public Mom.Test.UI.Core.Console.Views.TaskStatus.Dialogs.TaskStatusViewPropertiesDialog TaskStatusViewProperties
        {
            get
            {
                if (this.cachedTaskStatusViewPropertiesDialog == null)
                {
                    this.cachedTaskStatusViewPropertiesDialog = new Mom.Test.UI.Core.Console.Views.TaskStatus.Dialogs.TaskStatusViewPropertiesDialog(CoreManager.MomConsole);

                    UISynchronization.WaitForUIObjectReady(this.cachedTaskStatusViewPropertiesDialog, timeout);

                    Utilities.LogMessage("Views :: Success getting the Task Status View Properties dialog");

                    this.cachedTaskStatusViewPropertiesDialog.Extended.SetFocus();

                }

                return this.cachedTaskStatusViewPropertiesDialog;

            }
        }

        /// <summary>
        /// Select WebPageViewPropertiesDialog
        /// </summary>
        /// <history>
        ///		[sunsingh] 08Apl09 Created
        /// </history>
        public WebPagePropertiesDialog WebPageViewProperties
        {
            get
            {
                if (this.cachedWebPageViewPropertiesDialog == null)
                {
                    this.cachedWebPageViewPropertiesDialog = new WebPagePropertiesDialog(CoreManager.MomConsole);

                    UISynchronization.WaitForUIObjectReady(this.cachedWebPageViewPropertiesDialog, timeout);

                    Utilities.LogMessage("Views :: Success getting the Event View Properties dialog");

                    this.cachedWebPageViewPropertiesDialog.Extended.SetFocus();

                }

                return this.cachedWebPageViewPropertiesDialog;

            }
        }
        /// <summary>
        /// Select StateViewPropertiesDialog
        /// </summary>
        /// <history>
        ///		[lucyra] 18JAN06 Created
        /// </history>
        public StateViewPropertiesDialog StateViewProperties
        {
            get
            {
                if (this.cachedStateViewPropertiesDialog == null)
                {
                    this.cachedStateViewPropertiesDialog = new StateViewPropertiesDialog(CoreManager.MomConsole);

                    UISynchronization.WaitForUIObjectReady(this.cachedStateViewPropertiesDialog, timeout);

                    Utilities.LogMessage("Views :: Success getting the State View Properties dialog");

                    this.cachedStateViewPropertiesDialog.Extended.SetFocus();

                }

                return this.cachedStateViewPropertiesDialog;

            }
        }

        /// <summary>
        /// Select PerfViewPropertiesDialog
        /// </summary>
        /// <history>
        ///		[dialac] 20JUL06 Created
        /// </history>
        public PerfViewPropertiesDialog PerfViewProperties
        {
            get
            {
                if (this.cachedPerfViewPropertiesDialog == null)
                {
                    this.cachedPerfViewPropertiesDialog = new PerfViewPropertiesDialog(CoreManager.MomConsole);

                    UISynchronization.WaitForUIObjectReady(this.cachedPerfViewPropertiesDialog, timeout);

                    Utilities.LogMessage("Views :: Success getting the Properties view dialog");

                    this.cachedPerfViewPropertiesDialog.Extended.SetFocus();

                }

                return this.cachedPerfViewPropertiesDialog;

            }
        }

        /// <summary>
        /// Select PerfViewPropertiesDialog
        /// </summary>
        /// <history>
        ///		[nathd] 20AUG08 Created
        /// </history>
        public OverridesSummaryViewPropertiesDialog OverridesSummaryViewProperties
        {
            get
            {
                if (this.cachedOverridesSummaryViewPropertiesDialog == null)
                {
                    this.cachedOverridesSummaryViewPropertiesDialog = new OverridesSummaryViewPropertiesDialog(CoreManager.MomConsole);

                    UISynchronization.WaitForUIObjectReady(this.cachedOverridesSummaryViewPropertiesDialog, timeout);

                    Utilities.LogMessage("Views :: Success getting the Properties view dialog");

                    this.cachedOverridesSummaryViewPropertiesDialog.Extended.SetFocus();
                }

                return this.cachedOverridesSummaryViewPropertiesDialog;

            }
        }

        /// <summary>
        /// Select DiagramViewProperties
        /// </summary>
        /// <history>
        ///	[v-cheli] 24Nov08 Created
        /// </history>
        public Diagram.CreateDiagramViewDialog DiagramViewProperties
        {
            get
            {
                if (this.cachedDiagramViewPropertiesDialog == null)
                {
                    this.cachedDiagramViewPropertiesDialog = new Diagram.CreateDiagramViewDialog(CoreManager.MomConsole);

                    UISynchronization.WaitForUIObjectReady(this.cachedDiagramViewPropertiesDialog, timeout);

                    Utilities.LogMessage("View :: Success getting Properties view dialog");

                    this.cachedDiagramViewPropertiesDialog.Extended.SetFocus();
                }

                return this.cachedDiagramViewPropertiesDialog;
            }
        }
        #region Alert view criteria dialogs

        /// <summary>
        /// Select AlertTypeViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 04APR07 Created
        /// </history>
        public AlertTypeViewCriteria AlertTypeViewCriteria
        {
            get
            {
                if (this.cachedAlertTypeViewCriteria == null)
                {
                    this.cachedAlertTypeViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTypeViewCriteria(CoreManager.MomConsole);

                    UISynchronization.WaitForUIObjectReady(this.cachedAlertTypeViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting the Alert Severity Type View Criteria Dialog");

                    this.cachedAlertTypeViewCriteria.Extended.SetFocus();

                }

                return this.cachedAlertTypeViewCriteria;

            }
        }

        /// <summary>
        /// Select AlertPriorityViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 17APR07 Created
        /// </history>
        public AlertPriorityViewCriteria AlertPriorityViewCriteria
        {
            get
            {
                if (this.cachedAlertPriorityViewCriteria == null)
                {
                    this.cachedAlertPriorityViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertPriorityViewCriteria(CoreManager.MomConsole);

                    UISynchronization.WaitForUIObjectReady(this.cachedAlertPriorityViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting the Alert Priority View Criteria Dialog");

                    this.cachedAlertPriorityViewCriteria.Extended.SetFocus();

                }

                return this.cachedAlertPriorityViewCriteria;

            }
        }

        /// <summary>
        /// Select AlertSourceViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertSourceViewCriteria AlertSourceViewCriteria
        {
            get
            {
                if (this.cachedAlertSourceViewCriteria == null)
                {
                    this.cachedAlertSourceViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertSourceViewCriteria(CoreManager.MomConsole);

                    UISynchronization.WaitForUIObjectReady(this.cachedAlertSourceViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting the Alert Source View Criteria Dialog");

                    this.cachedAlertSourceViewCriteria.Extended.SetFocus();

                }

                return this.cachedAlertSourceViewCriteria;

            }
        }

        /// <summary>
        /// Select AlertResolutionStateViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertResolutionStateViewCriteria AlertResolutionStateViewCriteria
        {
            get
            {
                if (this.cachedAlertResolutionStateViewCriteria == null)
                {
                    this.cachedAlertResolutionStateViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertResolutionStateViewCriteria(CoreManager.MomConsole);

                    UISynchronization.WaitForUIObjectReady(this.cachedAlertResolutionStateViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting the Alert Resolution State View Criteria Dialog");

                    this.cachedAlertResolutionStateViewCriteria.Extended.SetFocus();

                }

                return this.cachedAlertResolutionStateViewCriteria;

            }
        }

        /// <summary>
        /// Select WithSpecificNameViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria WithSpecificNameViewCriteria
        {
            get
            {
                if (this.cachedWithSpecificNameViewCriteria == null)
                {
                    this.cachedWithSpecificNameViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertName);

                    UISynchronization.WaitForUIObjectReady(this.cachedWithSpecificNameViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting With Specific Name View Criteria Dialog");

                    this.cachedWithSpecificNameViewCriteria.Extended.SetFocus();

                }

                return this.cachedWithSpecificNameViewCriteria;

            }
        }

        /// <summary>
        /// Select WithSpecificDescriptionViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria WithSpecificDescriptionViewCriteria
        {
            get
            {
                if (this.cachedWithSpecificDescriptionViewCriteria == null)
                {
                    this.cachedWithSpecificDescriptionViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertDescription);

                    UISynchronization.WaitForUIObjectReady(this.cachedWithSpecificDescriptionViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting With Specific Description View Criteria Dialog");

                    this.cachedWithSpecificDescriptionViewCriteria.Extended.SetFocus();

                }

                return this.cachedWithSpecificDescriptionViewCriteria;

            }
        }

        /// <summary>
        /// Select CreatedInSpecificTimePeriodViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertDateAndTimeInputViewCriteria CreatedInSpecificTimePeriodViewCriteria
        {
            get
            {
                if (this.cachedCreatedInSpecificTimePeriodViewCriteria == null)
                {
                    this.cachedCreatedInSpecificTimePeriodViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertDateAndTimeInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertDateAndTimeGenerated);

                    UISynchronization.WaitForUIObjectReady(this.cachedCreatedInSpecificTimePeriodViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting the Created In Specific Time Period View Criteria Dialog");

                    this.cachedCreatedInSpecificTimePeriodViewCriteria.Extended.SetFocus();

                }

                return this.cachedCreatedInSpecificTimePeriodViewCriteria;

            }
        }

        /// <summary>
        /// Select AssignedToOwnerViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria AssignedToOwnerViewCriteria
        {
            get
            {
                if (this.cachedAssignedToOwnerViewCriteria == null)
                {
                    this.cachedAssignedToOwnerViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertOwner);

                    UISynchronization.WaitForUIObjectReady(this.cachedAssignedToOwnerViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting Assigned To Owner View Criteria Dialog");

                    this.cachedAssignedToOwnerViewCriteria.Extended.SetFocus();

                }

                return this.cachedAssignedToOwnerViewCriteria;

            }
        }

        /// <summary>
        /// Select RasedByInstanceViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria RasedByInstanceViewCriteria
        {
            get
            {
                if (this.cachedRasedByInstanceViewCriteria == null)
                {
                    this.cachedRasedByInstanceViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertInstanceName);

                    UISynchronization.WaitForUIObjectReady(this.cachedRasedByInstanceViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting Rased By Instance View Criteria Dialog");

                    this.cachedRasedByInstanceViewCriteria.Extended.SetFocus();

                }

                return this.cachedRasedByInstanceViewCriteria;

            }
        }

        /// <summary>
        /// Select LastModifiedByUserViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria LastModifiedByUserViewCriteria
        {
            get
            {
                if (this.cachedLastModifiedByUserViewCriteria == null)
                {
                    this.cachedLastModifiedByUserViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertLastModifiedBy);

                    UISynchronization.WaitForUIObjectReady(this.cachedLastModifiedByUserViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting Last Modified By User View Criteria Dialog");

                    this.cachedLastModifiedByUserViewCriteria.Extended.SetFocus();

                }

                return this.cachedLastModifiedByUserViewCriteria;

            }
        }

        /// <summary>
        /// Select LastModifiedInSpecificTimePeriodViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertDateAndTimeInputViewCriteria LastModifiedInSpecificTimePeriodViewCriteria
        {
            get
            {
                if (this.cachedLastModifiedInSpecificTimePeriodViewCriteria == null)
                {
                    this.cachedLastModifiedInSpecificTimePeriodViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertDateAndTimeInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertLastModifiedTime);

                    UISynchronization.WaitForUIObjectReady(this.cachedLastModifiedInSpecificTimePeriodViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting Last Modified In Specific Time Period View Criteria Dialog");

                    this.cachedLastModifiedInSpecificTimePeriodViewCriteria.Extended.SetFocus();

                }

                return this.cachedLastModifiedInSpecificTimePeriodViewCriteria;

            }
        }

        /// <summary>
        /// Select ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertDateAndTimeInputViewCriteria ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria
        {
            get
            {
                if (this.cachedResolutionStateLastModifiedInSpecificTimePeriodViewCriteria == null)
                {
                    this.cachedResolutionStateLastModifiedInSpecificTimePeriodViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertDateAndTimeInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertResolutionStateLastModified);

                    UISynchronization.WaitForUIObjectReady(
                        this.cachedResolutionStateLastModifiedInSpecificTimePeriodViewCriteria,
                        timeout);

                    Utilities.LogMessage("Views :: Success getting Resolution State Last Modified " +
                        " In Specific Time Period View Criteria Dialog");

                    this.cachedResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.Extended.SetFocus();

                }

                return this.cachedResolutionStateLastModifiedInSpecificTimePeriodViewCriteria;

            }
        }

        /// <summary>
        /// Select ResolvedInSpecificTimePeriodViewCriteria (Closed)
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertDateAndTimeInputViewCriteria ResolvedInSpecificTimePeriodViewCriteria
        {
            get
            {
                if (this.cachedResolvedInSpecificTimePeriodViewCriteria == null)
                {
                    this.cachedResolvedInSpecificTimePeriodViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertDateAndTimeInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertTimeResolved);

                    UISynchronization.WaitForUIObjectReady(
                        this.cachedResolvedInSpecificTimePeriodViewCriteria,
                        timeout);

                    Utilities.LogMessage("Views :: Success getting Resolution State Resolved " +
                        " In Specific Time Period View Criteria Dialog");

                    this.cachedResolvedInSpecificTimePeriodViewCriteria.Extended.SetFocus();

                }

                return this.cachedResolvedInSpecificTimePeriodViewCriteria;

            }
        }

        /// <summary>
        /// Select ResolvedByUserViewCriteria (Closed By)
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria ResolvedByUserViewCriteria
        {
            get
            {
                if (this.cachedResolvedByUserViewCriteria == null)
                {
                    this.cachedResolvedByUserViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertResolvedBy);

                    UISynchronization.WaitForUIObjectReady(this.cachedResolvedByUserViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting Resolved (Closed) By User View Criteria Dialog");

                    this.cachedResolvedByUserViewCriteria.Extended.SetFocus();

                }

                return this.cachedResolvedByUserViewCriteria;

            }
        }

        /// <summary>
        /// Select WithTicketIDViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria WithTicketIDViewCriteria
        {
            get
            {
                if (this.cachedWithTicketIDViewCriteria == null)
                {
                    this.cachedWithTicketIDViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertTicketId);

                    UISynchronization.WaitForUIObjectReady(this.cachedWithTicketIDViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting With Ticket ID View Criteria Dialog");

                    this.cachedWithTicketIDViewCriteria.Extended.SetFocus();

                }

                return this.cachedWithTicketIDViewCriteria;

            }
        }

        /// <summary>
        /// Select AddedToDatabaseInSpecificTimePeriodViewCriteria 
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertDateAndTimeInputViewCriteria AddedToDatabaseInSpecificTimePeriodViewCriteria
        {
            get
            {
                if (this.cachedAddedToDatabaseInSpecificTimePeriodViewCriteria == null)
                {
                    this.cachedAddedToDatabaseInSpecificTimePeriodViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertDateAndTimeInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertTimeAdded);

                    UISynchronization.WaitForUIObjectReady(
                        this.cachedAddedToDatabaseInSpecificTimePeriodViewCriteria,
                        timeout);

                    Utilities.LogMessage("Views :: Success getting Added To Database " +
                        " In Specific Time Period View Criteria Dialog");

                    this.cachedAddedToDatabaseInSpecificTimePeriodViewCriteria.Extended.SetFocus();

                }

                return this.cachedAddedToDatabaseInSpecificTimePeriodViewCriteria;

            }
        }

        /// <summary>
        /// Select WithSiteViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria WithSiteViewCriteria
        {
            get
            {
                if (this.cachedWithSiteViewCriteria == null)
                {
                    this.cachedWithSiteViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertSite);

                    UISynchronization.WaitForUIObjectReady(this.cachedWithSiteViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting With Site View Criteria Dialog");

                    this.cachedWithSiteViewCriteria.Extended.SetFocus();

                }

                return this.cachedWithSiteViewCriteria;

            }
        }

        /// <summary>
        /// Select WithCustomField1ViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria WithCustomField1ViewCriteria
        {
            get
            {
                if (this.cachedWithCustomField1ViewCriteria == null)
                {
                    this.cachedWithCustomField1ViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertCustomField1);

                    UISynchronization.WaitForUIObjectReady(this.cachedWithCustomField1ViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting With Custom Field 1 View Criteria Dialog");

                    this.cachedWithCustomField1ViewCriteria.Extended.SetFocus();

                }

                return this.cachedWithCustomField1ViewCriteria;

            }
        }

        /// <summary>
        /// Select WithCustomField2ViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria WithCustomField2ViewCriteria
        {
            get
            {
                if (this.cachedWithCustomField2ViewCriteria == null)
                {
                    this.cachedWithCustomField2ViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertCustomField2);

                    UISynchronization.WaitForUIObjectReady(this.cachedWithCustomField2ViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting With Custom Field 2 View Criteria Dialog");

                    this.cachedWithCustomField2ViewCriteria.Extended.SetFocus();

                }

                return this.cachedWithCustomField2ViewCriteria;

            }
        }

        /// <summary>
        /// Select WithCustomField3ViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria WithCustomField3ViewCriteria
        {
            get
            {
                if (this.cachedWithCustomField3ViewCriteria == null)
                {
                    this.cachedWithCustomField3ViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertCustomField3);

                    UISynchronization.WaitForUIObjectReady(this.cachedWithCustomField3ViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting With Custom Field 3 View Criteria Dialog");

                    this.cachedWithCustomField3ViewCriteria.Extended.SetFocus();

                }

                return this.cachedWithCustomField3ViewCriteria;

            }
        }

        /// <summary>
        /// Select WithCustomField4ViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria WithCustomField4ViewCriteria
        {
            get
            {
                if (this.cachedWithCustomField4ViewCriteria == null)
                {
                    this.cachedWithCustomField4ViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertCustomField4);

                    UISynchronization.WaitForUIObjectReady(this.cachedWithCustomField4ViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting With Custom Field 4 View Criteria Dialog");

                    this.cachedWithCustomField4ViewCriteria.Extended.SetFocus();

                }

                return this.cachedWithCustomField4ViewCriteria;

            }
        }

        /// <summary>
        /// Select WithCustomField5ViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria WithCustomField5ViewCriteria
        {
            get
            {
                if (this.cachedWithCustomField5ViewCriteria == null)
                {
                    this.cachedWithCustomField5ViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertCustomField5);

                    UISynchronization.WaitForUIObjectReady(this.cachedWithCustomField5ViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting With Custom Field 5 View Criteria Dialog");

                    this.cachedWithCustomField5ViewCriteria.Extended.SetFocus();

                }

                return this.cachedWithCustomField5ViewCriteria;

            }
        }

        /// <summary>
        /// Select WithCustomField6ViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria WithCustomField6ViewCriteria
        {
            get
            {
                if (this.cachedWithCustomField6ViewCriteria == null)
                {
                    this.cachedWithCustomField6ViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertCustomField6);

                    UISynchronization.WaitForUIObjectReady(this.cachedWithCustomField6ViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting With Custom Field 6 View Criteria Dialog");

                    this.cachedWithCustomField6ViewCriteria.Extended.SetFocus();

                }

                return this.cachedWithCustomField6ViewCriteria;

            }
        }

        /// <summary>
        /// Select WithCustomField7ViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria WithCustomField7ViewCriteria
        {
            get
            {
                if (this.cachedWithCustomField7ViewCriteria == null)
                {
                    this.cachedWithCustomField7ViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertCustomField7);

                    UISynchronization.WaitForUIObjectReady(this.cachedWithCustomField7ViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting With Custom Field 7 View Criteria Dialog");

                    this.cachedWithCustomField7ViewCriteria.Extended.SetFocus();

                }

                return this.cachedWithCustomField7ViewCriteria;

            }
        }

        /// <summary>
        /// Select WithCustomField8ViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria WithCustomField8ViewCriteria
        {
            get
            {
                if (this.cachedWithCustomField8ViewCriteria == null)
                {
                    this.cachedWithCustomField8ViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertCustomField8);

                    UISynchronization.WaitForUIObjectReady(this.cachedWithCustomField8ViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting With Custom Field 8 View Criteria Dialog");

                    this.cachedWithCustomField8ViewCriteria.Extended.SetFocus();

                }

                return this.cachedWithCustomField8ViewCriteria;

            }
        }

        /// <summary>
        /// Select WithCustomField9ViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria WithCustomField9ViewCriteria
        {
            get
            {
                if (this.cachedWithCustomField9ViewCriteria == null)
                {
                    this.cachedWithCustomField9ViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertCustomField9);

                    UISynchronization.WaitForUIObjectReady(this.cachedWithCustomField9ViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting With Custom Field 9 View Criteria Dialog");

                    this.cachedWithCustomField9ViewCriteria.Extended.SetFocus();

                }

                return this.cachedWithCustomField9ViewCriteria;

            }
        }

        /// <summary>
        /// Select WithCustomField10ViewCriteria
        /// </summary>
        /// <history>
        ///		[lucyra] 19APR07 Created
        /// </history>
        public AlertTextInputViewCriteria WithCustomField10ViewCriteria
        {
            get
            {
                if (this.cachedWithCustomField10ViewCriteria == null)
                {
                    this.cachedWithCustomField10ViewCriteria =
                        new Mom.Test.UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria(
                        CoreManager.MomConsole,
                        WindowCaptions.AlertCustomField10);

                    UISynchronization.WaitForUIObjectReady(this.cachedWithCustomField10ViewCriteria, timeout);

                    Utilities.LogMessage("Views :: Success getting With Custom Field 10 View Criteria Dialog");

                    this.cachedWithCustomField10ViewCriteria.Extended.SetFocus();

                }

                return this.cachedWithCustomField10ViewCriteria;

            }
        }

        #endregion //End of Alert view criteria dialogs

        #region Event view criteria dialogs
        /// <summary>
        /// Select GeneratedInSpecificTimePeriodViewCriteriaDialog
        /// </summary>
        /// <history>
        ///		[lucyra] 06NOV07 Created
        /// </history>
        public EventDateTimeViewCriteriaDialog GeneratedInSpecificTimePeriodViewCriteriaDialog
        {
            get
            {
                if (this.cachedGeneratedInSpecificTimePeriodViewCriteriaDialog == null)
                {
                    this.cachedGeneratedInSpecificTimePeriodViewCriteriaDialog =
                        new Mom.Test.UI.Core.Console.Views.Events.EventDateTimeViewCriteriaDialog(
                        CoreManager.MomConsole);

                    UISynchronization.WaitForUIObjectReady(
                        this.cachedGeneratedInSpecificTimePeriodViewCriteriaDialog, timeout);

                    Utilities.LogMessage("Views :: Success getting the Event Date Time View Criteria Dialog");

                    this.cachedGeneratedInSpecificTimePeriodViewCriteriaDialog.Extended.SetFocus();

                }

                return this.cachedGeneratedInSpecificTimePeriodViewCriteriaDialog;

            }
        }

        /// <summary>
        /// Select EventSelectRulesViewCriteriaDialog
        /// </summary>
        /// <history>
        ///		[lucyra] 06NOV07 Created
        /// </history>
        public EventSelectRulesViewCriteriaDialog EventSelectRulesViewCriteriaDialog
        {
            get
            {
                if (this.cachedEventSelectRulesViewCriteriaDialog == null)
                {
                    this.cachedEventSelectRulesViewCriteriaDialog =
                        new Mom.Test.UI.Core.Console.Views.Events.EventSelectRulesViewCriteriaDialog(
                        CoreManager.MomConsole);

                    UISynchronization.WaitForUIObjectReady(this.cachedEventSelectRulesViewCriteriaDialog, timeout);

                    Utilities.LogMessage("Views :: Success getting the Event Select Rules View Criteria Dialog");

                    this.cachedEventSelectRulesViewCriteriaDialog.Extended.SetFocus();

                }

                return this.cachedEventSelectRulesViewCriteriaDialog;

            }
        }

        /// <summary>
        /// Select WithSpecificEventNumberViewCriteriaDialog
        /// </summary>
        /// <history>
        ///		[lucyra] 06NOV07 Created
        /// </history>
        public EventTextInputViewCriteriaDialog WithSpecificEventNumberViewCriteriaDialog
        {
            get
            {
                if (this.cachedWithSpecificEventNumberViewCriteriaDialog == null)
                {
                    this.cachedWithSpecificEventNumberViewCriteriaDialog =
                        new Mom.Test.UI.Core.Console.Views.Events.EventTextInputViewCriteriaDialog(
                        CoreManager.MomConsole,
                        WindowCaptions.EventNumber);

                    UISynchronization.WaitForUIObjectReady(
                        this.cachedWithSpecificEventNumberViewCriteriaDialog, timeout);

                    Utilities.LogMessage("Views :: Success getting With Specific Event Number View Criteria Dialog");

                    this.cachedWithSpecificEventNumberViewCriteriaDialog.Extended.SetFocus();

                }

                return this.cachedWithSpecificEventNumberViewCriteriaDialog;

            }
        }

        /// <summary>
        /// Select FromSpecificSourceViewCriteriaDialog
        /// </summary>
        /// <history>
        ///		[lucyra] 06NOV07 Created
        /// </history>
        public EventTextInputViewCriteriaDialog FromSpecificSourceViewCriteriaDialog
        {
            get
            {
                if (this.cachedFromSpecificSourceViewCriteriaDialog == null)
                {
                    this.cachedFromSpecificSourceViewCriteriaDialog =
                        new Mom.Test.UI.Core.Console.Views.Events.EventTextInputViewCriteriaDialog(
                        CoreManager.MomConsole,
                        WindowCaptions.SourceName);

                    UISynchronization.WaitForUIObjectReady(this.cachedFromSpecificSourceViewCriteriaDialog, timeout);

                    Utilities.LogMessage("Views :: Success getting From Specific Source View Criteria Dialog");

                    this.cachedFromSpecificSourceViewCriteriaDialog.Extended.SetFocus();

                }

                return this.cachedFromSpecificSourceViewCriteriaDialog;

            }
        }

        /// <summary>
        /// Select RasedByInstanceWithSpecificNameViewCriteriaDialog
        /// </summary>
        /// <history>
        ///		[lucyra] 06NOV07 Created
        /// </history>
        public EventTextInputViewCriteriaDialog RasedByInstanceWithSpecificNameViewCriteriaDialog
        {
            get
            {
                if (this.cachedRasedByInstanceWithSpecificNameViewCriteriaDialog == null)
                {
                    this.cachedRasedByInstanceWithSpecificNameViewCriteriaDialog =
                        new Mom.Test.UI.Core.Console.Views.Events.EventTextInputViewCriteriaDialog(
                        CoreManager.MomConsole,
                        WindowCaptions.ObjectName);

                    UISynchronization.WaitForUIObjectReady(
                        this.cachedRasedByInstanceWithSpecificNameViewCriteriaDialog, timeout);

                    Utilities.LogMessage("Views :: Success getting Rased By Instance With Specific Name View Criteria Dialog");

                    this.cachedRasedByInstanceWithSpecificNameViewCriteriaDialog.Extended.SetFocus();

                }

                return this.cachedRasedByInstanceWithSpecificNameViewCriteriaDialog;

            }
        }

        /// <summary>
        /// Select EventSeverityLevelViewCriteriaDialog
        /// </summary>
        /// <history>
        ///		[lucyra] 06NOV07 Created
        /// </history>
        public EventSeverityLevelViewCriteriaDialog EventSeverityLevelViewCriteriaDialog
        {
            get
            {
                if (this.cachedEventSeverityLevelViewCriteriaDialog == null)
                {
                    this.cachedEventSeverityLevelViewCriteriaDialog =
                        new Mom.Test.UI.Core.Console.Views.Events.EventSeverityLevelViewCriteriaDialog(
                        CoreManager.MomConsole);

                    UISynchronization.WaitForUIObjectReady(
                        this.cachedEventSeverityLevelViewCriteriaDialog, timeout);

                    Utilities.LogMessage("Views :: Success getting the Event Date Time View Criteria Dialog");

                    this.cachedEventSeverityLevelViewCriteriaDialog.Extended.SetFocus();

                }

                return this.cachedEventSeverityLevelViewCriteriaDialog;

            }
        }

        /// <summary>
        /// Select FromSpecificUserViewCriteriaDialog
        /// </summary>
        /// <history>
        ///		[lucyra] 06NOV07 Created
        /// </history>
        public EventTextInputViewCriteriaDialog FromSpecificUserViewCriteriaDialog
        {
            get
            {
                if (this.cachedFromSpecificUserViewCriteriaDialog == null)
                {
                    this.cachedFromSpecificUserViewCriteriaDialog =
                        new Mom.Test.UI.Core.Console.Views.Events.EventTextInputViewCriteriaDialog(
                        CoreManager.MomConsole,
                        WindowCaptions.User);

                    UISynchronization.WaitForUIObjectReady(
                        this.cachedFromSpecificUserViewCriteriaDialog, timeout);

                    Utilities.LogMessage("Views :: Success getting From Specific User View Criteria Dialog");

                    this.cachedFromSpecificUserViewCriteriaDialog.Extended.SetFocus();

                }

                return this.cachedFromSpecificUserViewCriteriaDialog;

            }
        }

        /// <summary>
        /// Select WithSpecificLoggingComputerViewCriteriaDialog
        /// </summary>
        /// <history>
        ///		[lucyra] 06NOV07 Created
        /// </history>
        public EventTextInputViewCriteriaDialog WithSpecificLoggingComputerViewCriteriaDialog
        {
            get
            {
                if (this.cachedWithSpecificLoggingComputerViewCriteriaDialog == null)
                {
                    this.cachedWithSpecificLoggingComputerViewCriteriaDialog =
                        new Mom.Test.UI.Core.Console.Views.Events.EventTextInputViewCriteriaDialog(
                        CoreManager.MomConsole,
                        WindowCaptions.LoggingComputer);

                    UISynchronization.WaitForUIObjectReady(
                        this.cachedWithSpecificLoggingComputerViewCriteriaDialog, timeout);

                    Utilities.LogMessage("Views :: Success getting With Specific Logging Computer View Criteria Dialog");

                    this.cachedWithSpecificLoggingComputerViewCriteriaDialog.Extended.SetFocus();

                }

                return this.cachedWithSpecificLoggingComputerViewCriteriaDialog;

            }
        }
        #endregion

        #region Task Status view criteria dialogs
        /// <summary>
        /// Select TastStatusViewCriteriaDialog
        /// </summary>
        /// <history>
        ///		[v-eachu] 29SEP09 Created
        /// </history>
        public Mom.Test.UI.Core.Console.Views.TaskStatus.Dialogs.TaskSelectionWithSpecificStatusDialog TaskStatusCriteriaDialog
        {
            get
            {
                if (this.cachedTaskStatusCriteriaDialog == null)
                {
                    this.cachedTaskStatusCriteriaDialog =
                        new Mom.Test.UI.Core.Console.Views.TaskStatus.Dialogs.TaskSelectionWithSpecificStatusDialog(
                        CoreManager.MomConsole);

                    UISynchronization.WaitForUIObjectReady(
                        this.cachedTaskStatusCriteriaDialog, timeout);

                    Utilities.LogMessage("Views :: Success getting With Specific Status Task View Criteria Dialog");

                    this.cachedTaskStatusCriteriaDialog.Extended.SetFocus();

                }

                return this.cachedTaskStatusCriteriaDialog;

            }
        }

        #endregion

        #endregion

        #region Public static methods section

        /// <summary>
        /// This function is designed to return the localized dialog caption for a Wizard
        /// or properties dialog.
        /// </summary>
        /// <history>
        ///		[lucyra] 04APR07 Created
        /// </history>
        /// <param name="caption">Dialog captions</param>
        /// <returns>localized window caption text</returns>
        public static string GetWindowCaption(Views.WindowCaptions caption)
        {
            Utilities.LogMessage("Views.GetWindowCaption(..)");
            string dialogTitle = null;
            switch (caption)
            {
                case Views.WindowCaptions.AlertName:
                    dialogTitle = AlertsView.Strings.AlertNameDialogTitle;
                    break;

                case Views.WindowCaptions.AlertDescription:
                    dialogTitle = AlertsView.Strings.AlertDescriptionDialogTitle;
                    break;

                case Views.WindowCaptions.AlertOwner:
                    dialogTitle = AlertsView.Strings.AlertOwnerDialogTitle;
                    break;

                case Views.WindowCaptions.AlertInstanceName:
                    dialogTitle = AlertsView.Strings.AlertInstanceNameDialogTitle;
                    break;

                case Views.WindowCaptions.AlertLastModifiedBy:
                    dialogTitle = AlertsView.Strings.AlertLastModifiedByDialogTitle;
                    break;

                case Views.WindowCaptions.AlertResolvedBy:
                    dialogTitle = AlertsView.Strings.AlertResolvedByDialogTitle;
                    break;

                case Views.WindowCaptions.AlertTicketId:
                    dialogTitle = AlertsView.Strings.AlertTicketIdDialogTitle;
                    break;

                case Views.WindowCaptions.AlertSite:
                    dialogTitle = AlertsView.Strings.AlertSiteDialogTitle;
                    break;

                case Views.WindowCaptions.AlertCustomField1:
                    dialogTitle = AlertsView.Strings.AlertCustomField1DialogTitle;
                    break;

                case Views.WindowCaptions.AlertCustomField2:
                    dialogTitle = AlertsView.Strings.AlertCustomField2DialogTitle;
                    break;

                case Views.WindowCaptions.AlertCustomField3:
                    dialogTitle = AlertsView.Strings.AlertCustomField3DialogTitle;
                    break;

                case Views.WindowCaptions.AlertCustomField4:
                    dialogTitle = AlertsView.Strings.AlertCustomField4DialogTitle;
                    break;

                case Views.WindowCaptions.AlertCustomField5:
                    dialogTitle = AlertsView.Strings.AlertCustomField5DialogTitle;
                    break;

                case Views.WindowCaptions.AlertCustomField6:
                    dialogTitle = AlertsView.Strings.AlertCustomField6DialogTitle;
                    break;

                case Views.WindowCaptions.AlertCustomField7:
                    dialogTitle = AlertsView.Strings.AlertCustomField7DialogTitle;
                    break;

                case Views.WindowCaptions.AlertCustomField8:
                    dialogTitle = AlertsView.Strings.AlertCustomField8DialogTitle;
                    break;

                case Views.WindowCaptions.AlertCustomField9:
                    dialogTitle = AlertsView.Strings.AlertCustomField9DialogTitle;
                    break;

                case Views.WindowCaptions.AlertCustomField10:
                    dialogTitle = AlertsView.Strings.AlertCustomField10DialogTitle;
                    break;

                case Views.WindowCaptions.AlertDateAndTimeGenerated:
                    dialogTitle = AlertsView.Strings.AlertDateAndTimeGeneratedDialogTitle;
                    break;

                case Views.WindowCaptions.AlertLastModifiedTime:
                    dialogTitle = AlertsView.Strings.AlertLastModifiedTimeDialogTitle;
                    break;

                case Views.WindowCaptions.AlertResolutionStateLastModified:
                    dialogTitle = AlertsView.Strings.AlertResolutionStateLastModifiedDialogTitle;
                    break;

                case Views.WindowCaptions.AlertTimeResolved:
                    dialogTitle = AlertsView.Strings.AlertTimeResolvedDialogTitle;
                    break;

                case Views.WindowCaptions.AlertTimeAdded:
                    dialogTitle = AlertsView.Strings.AlertTimeAddedDialogTitle;
                    break;

                case Views.WindowCaptions.EventNumber:
                    dialogTitle = EventsView.Strings.EventNumberDialogTitle;
                    break;

                case Views.WindowCaptions.LoggingComputer:
                    dialogTitle = EventsView.Strings.LoggingComputerDialogTitle;
                    break;

                case Views.WindowCaptions.ObjectName:
                    dialogTitle = EventsView.Strings.ObjectNameDialogTitle;
                    break;

                case Views.WindowCaptions.SourceName:
                    dialogTitle = EventsView.Strings.SourceNameDialogTitle;
                    break;

                case Views.WindowCaptions.User:
                    dialogTitle = EventsView.Strings.UserDialogTitle;
                    break;

                default:
                    throw new NotSupportedException(
                        "Views.GetWindowCaption:: " +
                        "This window caption type is not supported: " + caption);
            }

            return dialogTitle;
        }

        #endregion	// Public static methods section

        #region Public Methods

        #region Create
        /// <summary>
        /// Create a new View with a specific view Name (hardcoded to UITest folder)
        /// </summary>
        /// <param name="viewType">View type to create</param>
        /// <param name="name">View Name</param>
        /// <history>
        ///		[lucyra] 18JAN06 Created
        /// </history>
        public void Create(ViewType viewType, string name)
        {
            string folderName = Mom.Test.UI.Core.Common.Constants.UITestViewFolder;
            this.Create(viewType, name, null, folderName);
        }

        /// <summary>
        /// Create a new View with a specific view Name, Description (hardcoded to UITest folder)
        /// </summary>
        /// <param name="viewType">View type to create</param>
        /// <param name="name">View Name</param>
        /// <param name="description">View Description</param>
        /// <history>
        ///		[lucyra] 18JAN06 Created
        /// </history>
        public void Create(ViewType viewType, string name, string description)
        {
            string folderName = Mom.Test.UI.Core.Common.Constants.UITestViewFolder;
            this.Create(viewType, name, description, folderName);
        }

        /// <summary>
        /// Create a new View with a specific view Name, Description
        /// </summary>
        /// <param name="viewType">View type to create</param>
        /// <param name="name">View Name</param>
        /// <param name="description">View Description</param>
        /// <param name="folderName">Folder Name</param>
        /// <history>
        ///		[lucyra] 18JAN06 Created
        /// </history>
        public void Create(ViewType viewType, string name, string description, string folderName)
        {
            CreateViewParameters parameters = new CreateViewParameters();
            parameters.Name = name;
            parameters.Description = description;
            parameters.FolderName = folderName;
            this.Create(viewType, parameters);
        }

        /// <summary>
        /// Creating view with parameters
        /// Note: You need to set at least view Name 
        /// and provide Folder name for navigating
        /// </summary>
        /// <param name="viewType">View type</param>
        /// <param name="parameters">Parameters</param>
        /// <history>
        ///		[lucyra] 18JAN06 Created
        /// </history>
        public void Create(ViewType viewType, CreateViewParameters parameters)
        {
            // declare vars
            string viewTypeMenuItem = null;

            // Switch right click context menu to load proper view type dialog
            switch (viewType)
            {
                case ViewType.AlertView:
                    viewTypeMenuItem = Views.Strings.AlertViewContextMenu; // Alert View
                    this.AlertViewPropertiesSupport(viewTypeMenuItem, parameters);
                    break;

                case ViewType.StateView:
                    viewTypeMenuItem = Views.Strings.StateViewContextMenu; // State View 
                    this.StateViewPropertiesSupport(viewTypeMenuItem, parameters);
                    break;

                case ViewType.EventView:
                    viewTypeMenuItem = Views.Strings.EventViewContextMenu; // Event View
                    this.EventViewPropertiesSupport(viewTypeMenuItem, parameters);
                    break;

                case ViewType.PerformanceView:
                    viewTypeMenuItem = Views.Strings.PerformanceViewContextMenu; // Performance View
                    this.PerformanceViewPropertiesSupport(viewTypeMenuItem, parameters);
                    break;

                case ViewType.TaskStatusView:
                    viewTypeMenuItem = Views.Strings.TaskStatusViewContextMenu; // Task Status View
                    this.TaskStatusViewPropertiesSupport(viewTypeMenuItem, parameters);
                    break;

                case ViewType.WebPageView:
                    viewTypeMenuItem = Views.Strings.WebPageViewContextMenu; // Web Page View
                    this.WebPageViewPropertiesSupport(viewTypeMenuItem, parameters);
                    break;

                case ViewType.DashboardView:
                    viewTypeMenuItem = Views.Strings.DashboardViewContextMenu; // Dashboard View
                    this.DashboardViewPropertiesSupport(viewTypeMenuItem, parameters);
                    break;

                case ViewType.Folder:
                    viewTypeMenuItem = Views.Strings.FolderContextMenu; // Folder
                    this.FolderPropertiesSupport(viewTypeMenuItem, parameters);
                    break;

                case ViewType.OverridesSummaryView:
                    viewTypeMenuItem = Views.Strings.OverridesSummaryView; // Overrides Summary View
                    this.OverridesSummaryViewPropertiesSupport(viewTypeMenuItem, parameters);
                    break;
                case ViewType.DiagramView:
                    viewTypeMenuItem = Views.Strings.DiagramViewContextMenu; //Diagram View
                    this.DiagramViewPropertiesSupport(viewTypeMenuItem, parameters);
                    break;

                default:
                    Utilities.LogMessage("Views.Create:: Invalid view type was passed, cannot find proper context menu item");
                    break;
            }
            consoleApp.Waiters.WaitForWindowReady(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
        }


        #region Close properties dialog method
        ///// <summary>
        ///// Method to Close properties dialog without saving changes if any
        ///// </summary>
        ///// <history>
        ///// [lucyra] 4APR07 Created
        ///// </history>
        //public void CloseProperties(Dialog PropertiesDialog)
        //{
        //    bool saveChanges = false;
        //    Utilities.LogMessage("Views.CloseProperties :: " +
        //        "by default no changes to properties are saved!");

        //    CloseProperties(PropertiesDialog, saveChanges);
        //}

        ///// <summary>
        ///// Method to Close properties dialog
        ///// </summary>
        //public void CloseProperties(Dialog PropertiesDialog, bool SaveChanges)
        //{

        //    //set focus on the first screen
        //    this.PropertiesDialog.Extended.SetFocus();


        //    if (SaveChanges == false)
        //    {
        //        //click Cancel button
        //        this.PropertiesDialog.ClickCancel();

        //        //TODO figure out how to check if this dialog is even up
        //        //CoreManager.MomConsole.ConfirmChoiceDialog(true);

        //        Maui.Core.Utilities.Sleeper.Delay(1000);
        //        CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, 60000);
        //    }

        //    else
        //    {
        //        //click OK button
        //        this.PropertiesDialog.ClickOK();

        //        Maui.Core.Utilities.Sleeper.Delay(1000);
        //        CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, 60000);

        //    }

        //}
        #endregion

        #endregion

        #region Delete View under Monitoring
        /// <summary>
        /// Method to Delete a view under Monitoring, retries if needed
        /// </summary>
        /// <param name="viewName">View Name</param>
        /// <param name="folderName">Folder Name or Folder Path</param>
        /// <returns>true if the view is deleted and false in any other case</returns>
        public bool Delete(string viewName, string folderName)
        {
            int retry = 0;
            int maxRetry = 20;
            bool isViewDeleted = false;

            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            Utilities.LogMessage("Views.Delete :: Navigate To Monitoring(...)");
            CoreManager.MomConsole.BringToForeground();
            Maui.Core.WinControls.TreeNode selectedNode = navPane.SelectNode(
                NavigationPane.Strings.Monitoring + Constants.PathDelimiter + folderName + Constants.PathDelimiter + viewName,
                NavigationPane.NavigationTreeView.Monitoring);
            Utilities.LogMessage("Views.Delete :: Successfully found and clicked on View " + viewName + " under " + folderName);

            // Selecting Delete from the context menu
            CoreManager.MomConsole.ExecuteContextMenu(Core.Console.Views.Views.Strings.DeleteContextMenu, true);

            consoleApp.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, 10000);

            CoreManager.MomConsole.ConfirmChoiceDialog(true);

            CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

            // Attempting to select the view till view is deleted or till hit max retry
            while (isViewDeleted == false && retry < maxRetry)
            {
                try
                {
                    Utilities.LogMessage("Views.Delete :: Trying to select a view that was supposed to be deleted");
                    navPane.SelectNode(
                        NavigationPane.Strings.Monitoring + Constants.PathDelimiter + folderName + Constants.PathDelimiter + viewName,
                        NavigationPane.NavigationTreeView.Monitoring);

                    CoreManager.MomConsole.MainWindow.ScreenElement.WaitForReady();

                }
                catch (Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException)
                {
                    // We got this exception, the view got deleted
                    isViewDeleted = true;
                    Sleeper.Delay(1000);
                }

                retry++;
            } // end while

            return isViewDeleted;
        }

        /// <summary>
        /// Does the view exist
        /// </summary>
        /// <param name="viewName">name of the view</param>
        /// <param name="folderName">name of the folder</param>
        /// <param name="space">NavigationTreeView object</param>
        /// <returns>boolean</returns>
        public bool isViewExist(string viewName, string folderName, NavigationPane.NavigationTreeView space)
        {
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            String notePath = "";
            CoreManager.MomConsole.BringToForeground();
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;

            try
            {
                if (String.IsNullOrEmpty(folderName))
                    notePath = Constants.PathDelimiter + viewName;
                else
                    notePath = Constants.PathDelimiter + folderName + Constants.PathDelimiter + viewName;

                Utilities.LogMessage("Trying to select a view that was supposed to be deleted" + currentMethod);
                switch (space)
                {
                    case NavigationPane.NavigationTreeView.Monitoring:
                        navPane.SelectNode(
                            NavigationPane.Strings.Monitoring + notePath,
                            NavigationPane.NavigationTreeView.Monitoring, 0);
                        break;
                    case NavigationPane.NavigationTreeView.MyWorkspace:
                        navPane.SelectNode(
                            NavigationPane.Strings.MyWorkspace + notePath,
                            NavigationPane.NavigationTreeView.MyWorkspace, 0);
                        break;
                }
                consoleApp.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, 60000);
                return true;
            }
            catch (Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException)
            {
                // We got this exception, the view got deleted
                return false;
            }
        }


        /// <summary>
        /// This function is designed to return the reference of the Target View Window
        /// </summary>
        /// <history>
        ///	[v-wihu] 06Sep10 Created
        /// </history>        
        /// <param name="ViewName">name of the target view</param>
        /// <returns>Window</returns>
        public static Window GetTargetViewWindow(string ViewName)
        {
            Utilities.LogMessage("GetTargetViewWindow::");
            Utilities.LogMessage("GetTargetViewWindow:: Looking for Target View");

             int retry = 0;
             bool isTargetView = false;
             Window targetView = null;
             ViewPane viewPaneTemp = null;

             while (!isTargetView && retry < Constants.DefaultViewLoadTimeout/Constants.OneSecond)
             {
                 targetView = new Window
                 (Core.Console.ConsoleApp.Strings.DialogTitle,
                 StringMatchSyntax.WildCard,
                 "Microsoft.EnterpriseManagement.Monitoring.Console.exe",
                 StringMatchSyntax.WildCard,
                 CoreManager.MomConsole,
                 Constants.DefaultDialogTimeout);

                 targetView.ScreenElement.WaitForReady();

                 Utilities.LogMessage("GetTargetViewWindow:: Failed to caputer the Event View Window in the " + retry + " time");
                 viewPaneTemp = new ViewPane(targetView, new QID(";[UIA, VisibleOnly]AutomationId = 'viewPanePanel'"), Core.Common.Constants.DefaultDialogTimeout);
                
                 isTargetView = viewPaneTemp.Title.Contains(ViewName);

                 if (isTargetView)
                 {
                     break;
                 }

                 //sleep one second to wait for the Event View Window finish loading
                 Sleeper.Delay(Constants.OneSecond);
                 retry++;
             }

             if (!isTargetView)
             {

                 throw new Infra.Frmwrk.VarFail("GetTargetViewWindow :: '" + viewPaneTemp.Title + "' does not match requested: '" + Core.Console.Views.Views.Strings.EventView + "'");
             }

             Utilities.LogMessage("GetTargetViewWindow: Success caputer the Target View Window!");
             return targetView;    
        }

        /// <summary>
        /// Method to Delete a view under Monitoring/My Workspace, retries if needed
        /// </summary>
        /// <param name="viewName">View Name</param>
        /// <param name="folderName">Folder Name or Folder Path</param>
        /// <param name="space">Monitoring/My Workspace</param>
        /// <returns>true if the view is deleted and false in any other case</returns>
        public bool Delete(string viewName, string folderName, NavigationPane.NavigationTreeView space)
        {
            int retry = 0;
            int maxRetry = 20;
            bool isViewDeleted = false;
            String notePath = "";
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

            CoreManager.MomConsole.BringToForeground();
            if (String.IsNullOrEmpty(folderName))
                notePath = Constants.PathDelimiter + viewName;
            else
                notePath = Constants.PathDelimiter + folderName + Constants.PathDelimiter + viewName;

            switch (space)
            {
                case NavigationPane.NavigationTreeView.Monitoring:
                    Utilities.LogMessage("Views.Delete :: Navigate To Monitoring(...)");
                    navPane.SelectNode(NavigationPane.Strings.Monitoring + notePath,
                        NavigationPane.NavigationTreeView.Monitoring);
                    break;
                case NavigationPane.NavigationTreeView.MyWorkspace:
                    Utilities.LogMessage("Views.Delete :: Navigate To My Workspace(...)");
                    navPane.SelectNode(NavigationPane.Strings.MyWorkspace + notePath,
                        NavigationPane.NavigationTreeView.MyWorkspace);
                    break;
            }
            Utilities.LogMessage("Views.Delete :: Successfully found and clicked on View " + viewName + " under " + folderName);

            // Selecting Delete from the context menu
            CoreManager.MomConsole.ExecuteContextMenu(Core.Console.Views.Views.Strings.DeleteContextMenu, true);
            consoleApp.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, 10000);
            //bug#219557
            CoreManager.MomConsole.Waiters.WaitForStatusText(Mom.Test.UI.Core.Console.MomControls.ConsoleStatusBar.Strings.Ready);

            //workarount for product bug#211399 not fixed for DeleteConfirmDialog from "System Center Operations Manager 2012" to "Operations Manager", use [StringMatchSyntax.WildCard] here
            CoreManager.MomConsole.ConfirmChoiceDialog(
                           MomConsoleApp.ButtonCaption.Yes,
                           MomConsoleApp.Strings.DialogTitle,
                           StringMatchSyntax.WildCard,
                           MomConsoleApp.ActionIfWindowNotFound.Error);

            CoreManager.MomConsole.Waiters.WaitForStatusText(Mom.Test.UI.Core.Console.MomControls.ConsoleStatusBar.Strings.Ready);
            consoleApp.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, 60000);

            // Attempting to select the view till view is deleted or till hit max retry
            while (isViewDeleted == false && retry < maxRetry)
            {
                try
                {
                    Utilities.LogMessage("Views.Delete :: Trying to select a view that was supposed to be deleted");
                    switch (space)
                    {
                        case NavigationPane.NavigationTreeView.Monitoring:
                            navPane.SelectNode(
                                NavigationPane.Strings.Monitoring + notePath,
                                NavigationPane.NavigationTreeView.Monitoring);
                            break;
                        case NavigationPane.NavigationTreeView.MyWorkspace:
                            navPane.SelectNode(
                                NavigationPane.Strings.MyWorkspace + notePath,
                                NavigationPane.NavigationTreeView.MyWorkspace);
                            break;
                    }
                    consoleApp.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, 60000);
                }
                catch (Maui.Core.WinControls.TreeNode.Exceptions.NodeNotFoundException)
                {
                    // We got this exception, the view got deleted
                    isViewDeleted = true;
                    Sleeper.Delay(1000);
                }

                retry++;
            } // end while

            return isViewDeleted;
        }

        #endregion

        #endregion

        #region Private Methods

        #region Launch
        /// <summary>
        /// Launch View to create
        /// </summary>
        /// <param name="viewTypeMenuItem">View type menu item</param>
        /// <param name="parameters">Parameters</param>
        /// <history>
        ///		[lucyra] 18JAN06 Created
        ///     [visnara] 14MAY07 Added support for multiple spaces (Monitoring/My Workspace)
        /// </history>
        private void Launch(string viewTypeMenuItem, CreateViewParameters parameters)
        {
            // Navigation Pane
            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
            String notePath;
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            CoreManager.MomConsole.BringToForeground();
            TreeNode currentFolder = null;
            if (String.IsNullOrEmpty(parameters.FolderName))
                notePath = "";
            else
                notePath = Constants.PathDelimiter + parameters.FolderName;

            switch (parameters.Space)
            {
                case NavigationPane.NavigationTreeView.Monitoring:
                    Utilities.LogMessage("Views.Launch:: Navigate To Monitoring\\" + parameters.FolderName);
                    currentFolder = navPane.SelectNode(NavigationPane.Strings.Monitoring + notePath,
                        NavigationPane.NavigationTreeView.Monitoring);
                    break;
                case NavigationPane.NavigationTreeView.MyWorkspace:
                    Utilities.LogMessage("Views.Launch:: Navigate To My Workspace\\" + parameters.FolderName);
                    currentFolder = navPane.SelectNode(NavigationPane.Strings.MyWorkspace + notePath,
                        NavigationPane.NavigationTreeView.MyWorkspace);
                    break;

            }
            Utilities.LogMessage("Views.Launch:: Successfully found and clicked on folder " + parameters.FolderName);

            //if (parameters.StartPoint == null)
            //{
            //    Utilities.LogMessage("Views.Launch:: Launching flyout context menus");
            //    CoreManager.MomConsole.ExecuteContextMenu(
            //        Views.Strings.NewContextMenu +
            //        Constants.PathDelimiter +
            //        viewTypeMenuItem,
            //        true);
            //}
            //else
            //{
            // select the start point
            switch (parameters.StartPoint)
            {
                case CreateViewParameters.StartPointEnum.NavPaneLink:
                    {
                        #region Use Navigation Pane Link Label "New view"

                        Core.Common.Utilities.LogMessage(
                            "Clicking nav pane link... : " + currentMethod);

                        // click the "New view" link in the navigation pane
                        CoreManager.MomConsole.NavigationPane.ClickNewViewsLink(parameters.Space);

                        Core.Common.Utilities.LogMessage(
                            "Looking for webpageview menu... : " + currentMethod);

                        // look for the context menu
                        Maui.Core.WinControls.Menu contextMenu =
                            new Maui.Core.WinControls.Menu(
                                Core.Common.Constants.DefaultContextMenuTimeout);

                        Core.Common.Utilities.LogMessage(
                            "Selecting context menu item '" +
                            viewTypeMenuItem +
                            "' : " + currentMethod);

                        // get the WebPage  view context menu item
                        contextMenu.ExecuteMenuItem(
                            viewTypeMenuItem);

                        #endregion
                    }
                    break;

                default:
                    {
                        #region Use Navigation Pane Context Menu "New->WebpageView"

                        /* // right-click on the node
                            currentFolder.Click(
                                MouseClickType.SingleClick,
                                MouseFlags.RightButton);

                            Core.Common.Utilities.LogMessage(
                                "Looking for context menu... : " + currentMethod);

                            // Select the "New" menu
                            Maui.Core.WinControls.Menu contextMenu =
                                new Maui.Core.WinControls.Menu(
                                    Core.Common.Constants.DefaultContextMenuTimeout);

                            Core.Common.Utilities.LogMessage(
                                "Selecting context menu item '" +
                                Views.Strings.NewContextMenu +
                                "' : " + currentMethod);

                            // select  New menu item
                            contextMenu.ExecuteMenuItem(
                                Core.Console.Views.Views.Strings.NewContextMenu);

                            Core.Common.Utilities.LogMessage(
                                "Looking for flyout menu... : " + currentMethod);

                            Maui.Core.WinControls.Menu flyoutMenu =
                                new Maui.Core.WinControls.Menu(
                                    Core.Common.Constants.DefaultContextMenuTimeout);

                            Core.Common.Utilities.LogMessage(
                                "Selecting context menu item '" +
                                viewTypeMenuItem +
                                "' : " + currentMethod);

                            // select menu item
                            flyoutMenu.ExecuteMenuItem(
                                viewTypeMenuItem);*/

                        CoreManager.MomConsole.ExecuteContextMenu(
                        Views.Strings.NewContextMenu +
                        Constants.PathDelimiter +
                        viewTypeMenuItem,
                        true);

                        #endregion
                    }
                    break;
            }
            //}

            consoleApp.Waiters.WaitForWindowIdle(
                CoreManager.MomConsole.MainWindow,
                Core.Common.Constants.DefaultContextMenuTimeout);

            Utilities.LogMessage("Views.Launch:: Trying to launch View Properties dialog...");

        }

        #endregion

        #region Launch view criteria dialog via "specific" link

        /// <summary>
        /// Method to launch view criteria dialog
        /// Takes the string of the view criteria to launch that contains 
        /// link to click "SPECIFIC"
        /// You have to launch the view and view Properties
        /// </summary>
        /// <param name="ViewCriteriaText">View Criteria Text</param>
        private void LaunchSpecificViewCriteriaDialog(string ViewCriteriaText)
        {
            string link = Strings.SpecificLink;
            LaunchSpecificViewCriteriaDialog(ViewType.AlertView, ViewCriteriaText, link);

        }

        /// <summary>
        /// Defaults to Alerts view complex view criteria link dialog
        /// </summary>
        /// <param name="ViewCriteriaText">View Criteria Text</param>
        /// <param name="ComplexSpecificLink">Complex Specific Link</param>
        private void LaunchSpecificViewCriteriaDialog(string ViewCriteriaText, string ComplexSpecificLink)
        {

            LaunchSpecificViewCriteriaDialog(ViewType.AlertView, ViewCriteriaText, ComplexSpecificLink);

        }

        /// <summary>
        /// Method to launch supported view criteria dialog
        /// Takes the string of the view criteria to launch that contains 
        /// link to click "SPECIFIC" and a View Type
        /// You have to launch view and view Properties
        /// </summary>
        /// <param name="viewType">View Type</param>
        /// <param name="ViewCriteriaText">View Criteria Text</param>
        private void LaunchSpecificViewCriteriaDialog(ViewType viewType, string ViewCriteriaText)
        {
            string link = Strings.SpecificLink;
            LaunchSpecificViewCriteriaDialog(viewType, ViewCriteriaText, link);

        }


        /// <summary>
        /// Method to launch view criteria dialog
        /// Takes the string of the view criteria to launch that contains 
        /// combination link to click other than "SPECIFIC"
        /// You have to launch the view and view Properties
        /// </summary>
        /// <param name="viewType">View Type</param>
        /// <param name="ViewCriteriaText">View Criteria Text</param>
        /// <param name="ComplexSpecificLink">Complex Specific Link</param>
        private void LaunchSpecificViewCriteriaDialog(ViewType viewType, string ViewCriteriaText, string ComplexSpecificLink)
        {
            string viewCriteriaText = ViewCriteriaText;

            //ComplexSpecificLink is null if the view criteria contains simple SPECIFIC link to click

            string link = ComplexSpecificLink;

            String formattedLink =
                String.Format(viewCriteriaText, null, link).Trim();

            //click(check) on Of a specific view criteria item of a specific view
            switch (viewType)
            {
                case ViewType.AlertView:
                    this.AlertViewProperties.Controls.ShowDataContainedInASpecificGroupListBox.SelectItem(
                        formattedLink,
                        false);
                    break;

                case ViewType.StateView:
                    this.StateViewProperties.Controls.CriteriaDescriptionClickTheUnderlinedValueToEditListBox.SelectItem(
                        formattedLink,
                        false);
                    break;

                case ViewType.EventView:
                    this.EventViewProperties.Controls.NoneListBox.SelectItem(
                        formattedLink,
                        false);
                    break;

                case ViewType.PerformanceView:
                    this.PerfViewProperties.Controls.NoneListBox.SelectItem(
                        formattedLink,
                        false);
                    break;

                case ViewType.TaskStatusView:
                    this.TaskStatusViewProperties.Controls.ShowDataContainedInASpecificGroupListBox.SelectItem(
                        formattedLink,
                        false);
                    break;

                case ViewType.WebPageView:
                    Utilities.LogMessage("WebPageView is not supported");
                    break;

                case ViewType.DashboardView:
                    Utilities.LogMessage("DashboardView is not supported");
                    break;

                case ViewType.Folder:
                    Utilities.LogMessage("Folder is not supported");
                    break;

                default:
                    Utilities.LogMessage("Not supported:  Incorrect view type is provided");
                    break;

            }

            Sleeper.Delay(2000);
            StaticControl criteriaItem = null;

            Utilities.LogMessage("Views.LaunchSpecificViewCriteriaDialog :: " +
                formattedLink);

            //click(check) on Of a specific view criteria item of a specific view
            switch (viewType)
            {
                case ViewType.AlertView:
                    criteriaItem = new StaticControl(
                        this.AlertViewProperties,
                        formattedLink,
                        StringMatchSyntax.WildCard, //StringMatchSyntax.ExactMatch,
                        WindowClassNames.WinFormsStatic,
                        StringMatchSyntax.WildCard);
                    break;

                case ViewType.StateView:
                    criteriaItem = new StaticControl(
                        this.StateViewProperties,
                        formattedLink,
                        StringMatchSyntax.WildCard,
                        WindowClassNames.WinFormsStatic,
                        StringMatchSyntax.WildCard);
                    break;

                case ViewType.EventView:
                    criteriaItem = new StaticControl(
                        this.EventViewProperties,
                        formattedLink,
                        StringMatchSyntax.WildCard,
                        WindowClassNames.WinFormsStatic,
                        StringMatchSyntax.WildCard);
                    break;

                case ViewType.PerformanceView:
                    criteriaItem = new StaticControl(
                        this.PerfViewProperties,
                        formattedLink,
                        StringMatchSyntax.WildCard,
                        WindowClassNames.WinFormsStatic,
                        StringMatchSyntax.WildCard);
                    break;

                case ViewType.TaskStatusView:
                    criteriaItem = new StaticControl(
                        this.TaskStatusViewProperties,
                        formattedLink,
                        StringMatchSyntax.WildCard,
                        WindowClassNames.WinFormsStatic,
                        StringMatchSyntax.WildCard);
                    break;

                case ViewType.WebPageView:
                    Utilities.LogMessage("WebPageView is not supported");
                    break;

                case ViewType.DashboardView:
                    Utilities.LogMessage("DashboardView is not supported");
                    break;

                case ViewType.Folder:
                    Utilities.LogMessage("Folder is not supported");
                    break;

                default:
                    Utilities.LogMessage("Not supported:  Incorrect view type is provided");
                    break;

            }

            if (null != criteriaItem)
            {

                Utilities.LogMessage("Views.LaunchSpecificViewCriteriaDialog :: " +
                    "Launching Specific dialog");

                // criteriaItem.Click();
                criteriaItem.Extended.AccessibleObject.FindChild((int)MsaaRole.Link).Click();

                Sleeper.Delay(5000);

                Utilities.LogMessage("Views.LaunchSpecificViewCriteriaDialog :: " +
                    "Looking for view criteria Window");

            }

        }

        #endregion

        #region Select Target name

        /// <summary>
        /// Select target for view properties
        /// </summary>
        /// <param name="targetName">Target Name</param>
        /// <history>
        ///		[v-cheli] 26NOV08 Created
        /// </history>    

        private void SelectTargetName(string targetName)
        {
            SelectTargetTypeDialog selectTargetDialog = new SelectTargetTypeDialog(CoreManager.MomConsole);
            UISynchronization.WaitForUIObjectReady(selectTargetDialog, timeout);
            selectTargetDialog.Controls.ListView0.MultiSelect(targetName);
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(selectTargetDialog.Controls.OKButton, Constants.OneMinute);
            selectTargetDialog.ClickOK();
            CoreManager.MomConsole.ConfirmChoiceDialog(ConsoleApp.ButtonCaption.Yes, DeviceDiscovery.Wizards.NetworkDeviceWizard.Dialogs.WarningDialog.Strings.DialogTitle, StringMatchSyntax.ExactMatch, ConsoleApp.ActionIfWindowNotFound.Ignore);               
            Utilities.LogMessage("Views.SelectTargetName: '" + targetName + "'");
        }

        #endregion
        #region Alert View Properties Support

        /// <summary>
        /// Work on Launching new Alert view Properties dialog and setting view criteria
        /// </summary>
        /// <param name="viewTypeMenuItem">Alert view menu item</param>
        /// <param name="parameters">Parameters to set</param>
        /// <history>
        ///		[lucyra] 18JAN06 Created
        /// </history>
        private void AlertViewPropertiesSupport(string viewTypeMenuItem, CreateViewParameters parameters)
        {
            this.Launch(viewTypeMenuItem, parameters);

            this.AlertViewProperties.NameText = parameters.Name;
            this.AlertViewProperties.DescriptionText = parameters.Description;

            #region Set Alert Severity view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter AlertSeverityFlag is set to " +
                parameters.AlertSeverityFlag.ToString());

            if (parameters.AlertSeverityFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(Core.Console.Views.Alerts.AlertsView.Strings.OfASeverity);

                Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                    "Looking for Alert Type Window");

                //Launch Alert Severity Type view criteria dialog
                Utilities.LogMessage("Active dialog title is: " +
                    UI.Core.Console.Views.Alerts.AlertTypeViewCriteria.Strings.DialogTitle);

                //Set Alert Severity provided in parameters
                this.AlertTypeViewCriteria.Controls.AlertSeverityTypeListBox[parameters.AlertSeverityValues[0].ToString(), false].Click();

                this.AlertTypeViewCriteria.ClickOK();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.AlertTypeViewCriteria, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Alert Severity view criteria

            #region Set Alert Priority view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter AlertPriorityFlag is set to " +
                parameters.AlertPriorityFlag.ToString());

            if (parameters.AlertPriorityFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(Core.Console.Views.Alerts.AlertsView.Strings.OfAPriority);

                Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                    "Looking for Alert Priority Window");

                //Launch Alert Severity Type view criteria dialog
                Utilities.LogMessage("Active dialog title is: " +
                    UI.Core.Console.Views.Alerts.AlertPriorityViewCriteria.Strings.DialogTitle);

                //Set Alert Severity provided in parameters
                this.AlertPriorityViewCriteria.Controls.AlertPriorityListBox[parameters.AlertPriorityValues[0].ToString(), false].Click();

                this.AlertPriorityViewCriteria.ClickOK();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.AlertPriorityViewCriteria, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Alert Priority view criteria

            #region Set Alert Sources view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter AlertSourcesFlag is set to " +
                parameters.AlertSourcesFlag.ToString());

            if (parameters.AlertSourcesFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(Core.Console.Views.Alerts.AlertsView.Strings.CreatedBySources);

                Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                    "Looking for Alert Sources Window");

                //Launch Alert Severity Type view criteria dialog
                Utilities.LogMessage("Active dialog title is: " +
                    UI.Core.Console.Views.Alerts.AlertSourceViewCriteria.Strings.DialogTitle);

                if (parameters.SelectAllFlag == true)
                {
                    //Click Select All (sources) button
                    this.AlertSourceViewCriteria.ClickSelectAll();
                    Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                        "Clicked Select All (sources) button");

                    Sleeper.Delay(2000);

                }
                else
                {
                    //Set Alert Sources provided in parameters
                    this.AlertSourceViewCriteria.Controls.AlertSourceListBox[parameters.AlertSourcesValues[0].ToString(), false].Click();

                }

                //Close the view criteria dialog
                this.AlertSourceViewCriteria.ClickOK();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.AlertSourceViewCriteria, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Alert Sources view criteria

            #region Set Alert Resolution State view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter AlertResolutionStateFlag is set to " +
                parameters.AlertResolutionStateFlag.ToString());

            if (parameters.AlertResolutionStateFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(Core.Console.Views.Alerts.AlertsView.Strings.WithResolutionState);

                Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                    "Looking for Alert Resolution State Window");

                //Launch Alert Severity Type view criteria dialog
                Utilities.LogMessage("Active dialog title is: " +
                    UI.Core.Console.Views.Alerts.AlertResolutionStateViewCriteria.Strings.DialogTitle);

                if (parameters.SelectAllFlag == true)
                {
                    //Click Select All (Available Resolution States) button
                    this.AlertResolutionStateViewCriteria.ClickSelectAll();
                    Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                        "Clicked Select All (Resolution States) button");

                    Sleeper.Delay(2000);

                }
                else
                {
                    //Set only specific resolution state if this flag is selected
                    if (parameters.OnlyAlertResolutionStateFlag == true)
                    {
                        //Select 2nd radio button
                        this.AlertResolutionStateViewCriteria.Controls.DisplayOnlyAlertsWithResolutionStateRadioButton.Click();

                        //Set specific operator and resolution state from the proper combos
                        Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                            "Select Resolution State that is " +
                            parameters.OnlyAlertResolutionStateValues[0].ToString() +
                            " " +
                            parameters.OnlyAlertResolutionStateValues[1].ToString());

                        this.AlertResolutionStateViewCriteria.Controls.OperatorCombo.SelectByText(parameters.OnlyAlertResolutionStateValues[0].ToString());

                        // [a-joelj] Maui 2.0 Required Change: Changed ResolutionStateComboBox to a ResolutionStateNumericUpDown control
                        // because it is not a ComboBox and Maui 2.0 was having trouble using SelectByText method.  Also updated
                        // the way we set this Text Property.
                        this.AlertResolutionStateViewCriteria.Controls.ResolutionStateNumericUpDown.TextBox.Text = parameters.OnlyAlertResolutionStateValues[1].ToString();
                    }
                    //Set New, Closed or Custom Alert Resolution State view criteria to search for                        
                    else
                    {
                        //Set Alert Resolution state provided in parameters: New, Closed and/or Custom
                        Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                            "Select " + parameters.AlertResolutionStateValues[0].ToString());

                        //a-joelj:  This needed a double click action due to SM regression bug ID 133436
                        //          if this bug is fixed, just delete one of the following click lines and this will be
                        //          corrected.
                        this.AlertResolutionStateViewCriteria.Controls.ResolutionStatesToSearchForListBox[parameters.AlertResolutionStateValues[0].ToString(), false].Click();
                        this.AlertResolutionStateViewCriteria.Controls.ResolutionStatesToSearchForListBox[parameters.AlertResolutionStateValues[0].ToString(), false].Click();
                    }

                }

                //Close the view criteria dialog
                this.AlertResolutionStateViewCriteria.ClickOK();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.AlertResolutionStateViewCriteria, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Alert Resolution State view criteria

            #region Set Alert With Specific Name view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter AlertWithName is set to " +
                parameters.AlertWithNameFlag.ToString());

            if (parameters.AlertWithNameFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(Core.Console.Views.Alerts.AlertsView.Strings.WithName);

                Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                    "Looking for 'Alert Name' Window");

                //Launch Alert Severity Type view criteria dialog
                Utilities.LogMessage("Active dialog title is: " +
                    UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria.Strings.DialogTitle);

                //Set Alert Severity provided in parameters
                this.WithSpecificNameViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                    parameters.AlertWithNameValues[0].ToString();

                this.WithSpecificNameViewCriteria.ClickOK();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.WithSpecificNameViewCriteria, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Alert With Specific Name view criteria

            #region Set Alert With Specific Description view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter AlertWithDescription is set to " +
                parameters.AlertWithDescriptionFlag.ToString());

            if (parameters.AlertWithDescriptionFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(Core.Console.Views.Alerts.AlertsView.Strings.WithDescription);

                Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                    "Looking for 'Description' Window");

                //Launch Alert Severity Type view criteria dialog
                Utilities.LogMessage("Active dialog title is: " +
                    UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria.Strings.DialogTitle);

                //Set Alert Severity provided in parameters
                this.WithSpecificDescriptionViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                    parameters.AlertWithDescriptionValues[0].ToString();

                this.WithSpecificDescriptionViewCriteria.ClickOK();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.WithSpecificDescriptionViewCriteria, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Alert With Specific Description view criteria

            #region Set Alert Created In A Specific Time Period view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter DateAndTimeCreatedFlag is set to " +
                parameters.DateAndTimeCreatedFlag.ToString());

            if (parameters.DateAndTimeCreatedFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(Core.Console.Views.Alerts.AlertsView.Strings.Created,
                    Core.Console.Views.Alerts.AlertsView.Strings.InSpecificTimePeriod);

                Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                    "Looking for 'Date And Time Created' Window");

                //Launch DateAndTimeCreated view criteria dialog
                Utilities.LogMessage("Active dialog title is: " +
                    UI.Core.Console.Views.Alerts.AlertDateAndTimeInputViewCriteria.Strings.DialogTitle);

                //Set view criteria provided in parameters
                switch (parameters.DateAndTimeCreatedValues[0].ToString())
                {
                    case "WhithinTimeRange":
                        //Select radio button
                        this.CreatedInSpecificTimePeriodViewCriteria.Controls.WithinTheTimeRangeRadioButton.Click();

                        Utilities.LogMessage("Radio button state: " +
                            this.CreatedInSpecificTimePeriodViewCriteria.Controls.WithinTheTimeRangeRadioButton.ButtonState.ToString());

                        string afterCheckbox = parameters.DateAndTimeCreatedValues[1].ToString();

                        Utilities.LogMessage("After Checkbox is: " + afterCheckbox);

                        string beforeCheckbox = parameters.DateAndTimeCreatedValues[2].ToString();

                        Utilities.LogMessage("Before Checkbox is: " + beforeCheckbox);

                        switch (afterCheckbox)
                        {
                            case "true":
                                //check After checkbox and keep the value default for now
                                if (this.CreatedInSpecificTimePeriodViewCriteria.After == false)
                                {
                                    this.CreatedInSpecificTimePeriodViewCriteria.ClickAfter();
                                }
                                //if the value is passed, set the value
                                //if ((parameters.DateAndTimeCreatedValues[3].ToString()) != null)
                                //{
                                //    string afterValue = parameters.DateAndTimeCreatedValues[3].ToString();
                                //    this.CreatedInSpecificTimePeriodViewCriteria.Controls.
                                //}

                                break;

                            case "false":
                                //If After checkbox is checked, but the parameter passed is false, need to uncheck it
                                if (this.CreatedInSpecificTimePeriodViewCriteria.After == true)
                                {
                                    this.CreatedInSpecificTimePeriodViewCriteria.ClickAfter();
                                }

                                break;

                            default:
                                Utilities.LogMessage("Selected parameter is invalid: '" +
                                    parameters.DateAndTimeCreatedValues[1].ToString() + "'");
                                Utilities.LogMessage("Invalid After value is selected. " +
                                    "Expected values: 'True' OR 'False'");

                                break;

                        }

                        switch (beforeCheckbox)
                        {
                            case "true":
                                //check Before checkbox and keep the value default for now
                                if (this.CreatedInSpecificTimePeriodViewCriteria.Before == false)
                                {
                                    this.CreatedInSpecificTimePeriodViewCriteria.ClickBefore();
                                }
                                //if the value is passed, set the value
                                //if ((parameters.DateAndTimeCreatedValues[4].ToString()) != null)
                                //{
                                //    string beforeValue = parameters.DateAndTimeCreatedValues[4].ToString();
                                //    this.CreatedInSpecificTimePeriodViewCriteria.Controls.
                                //}

                                break;

                            case "false":
                                //If Before checkbox is checked, but the parameter passed is false, need to uncheck it
                                if (this.CreatedInSpecificTimePeriodViewCriteria.Before == true)
                                {
                                    this.CreatedInSpecificTimePeriodViewCriteria.ClickBefore();
                                }

                                break;

                            default:

                                Utilities.LogMessage("Selected parameter is invalid: '" +
                                        parameters.DateAndTimeCreatedValues[2].ToString() + "'");

                                Utilities.LogMessage("Invalid Before value is selected. " +
                                        "Expected values: 'True' OR 'False'");

                                break;

                        }

                        break;

                    case "WithinLast":
                        //Select radio button
                        this.CreatedInSpecificTimePeriodViewCriteria.Controls.WithinTheLastRadioButton.Click();

                        string number = parameters.DateAndTimeCreatedValues[1].ToString();
                        string time = parameters.DateAndTimeCreatedValues[2].ToString();

                        //Set the date and time accordingly
                        this.CreatedInSpecificTimePeriodViewCriteria.NumberTextBoxText = number;
                        this.CreatedInSpecificTimePeriodViewCriteria.Controls.ComboBoxTimeUnit.SelectByText(time, false);

                        Utilities.LogMessage("Within the last " +
                            this.CreatedInSpecificTimePeriodViewCriteria.NumberTextBoxText +
                            " " +
                            this.CreatedInSpecificTimePeriodViewCriteria.ComboBoxTimeUnitText +
                            " is the data set");

                        break;

                    default:
                        Utilities.LogMessage("Selected parameter is invalid: '" +
                            parameters.DateAndTimeCreatedValues[0].ToString() + "'");
                        Utilities.LogMessage("Invalid DateAndTime selected. " +
                            "Expected values: 'WhithinTimeRange' OR 'WithinLast'");

                        break;

                }

                this.CreatedInSpecificTimePeriodViewCriteria.ClickOK(); //.Controls.OKButton.Click();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.CreatedInSpecificTimePeriodViewCriteria, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Alert Created In A Specific Time Period view criteria

            #region Set Alert With Specific Owner view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter AlertWithOwner is set to " +
                parameters.AlertWithOwnerFlag.ToString());

            if (parameters.AlertWithOwnerFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(Core.Console.Views.Alerts.AlertsView.Strings.WithOwner);

                Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                    "Looking for 'Owner' Window");

                //Launch Alert Severity Type view criteria dialog
                Utilities.LogMessage("Active dialog title is: " +
                    UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria.Strings.DialogTitle);

                //Set Alert Severity provided in parameters
                this.AssignedToOwnerViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                    parameters.AlertWithOwnerValues[0].ToString();

                this.AssignedToOwnerViewCriteria.ClickOK();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.AssignedToOwnerViewCriteria, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Alert With Specific Owner view criteria

            #region Set Alert Raised By Specific Instance Name view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter AlertWithInstanceName is set to " +
                parameters.AlertWithInstanceNameFlag.ToString());

            if (parameters.AlertWithInstanceNameFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(Core.Console.Views.Alerts.AlertsView.Strings.RasedByInstanceWithName);

                Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                    "Looking for 'Instance Name' Window");

                //Launch Alert Severity Type view criteria dialog
                Utilities.LogMessage("Active dialog title is: " +
                    UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria.Strings.DialogTitle);

                //Set Alert Severity provided in parameters
                this.RasedByInstanceViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                    parameters.AlertWithInstanceNameValues[0].ToString();

                this.RasedByInstanceViewCriteria.ClickOK();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.RasedByInstanceViewCriteria, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Alert Raised By Specific Instance Name view criteria

            #region Set Alert Last Modified By Specific User view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter AlertModifiedBy is set to " +
                parameters.AlertModifiedByFlag.ToString());

            if (parameters.AlertModifiedByFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(Core.Console.Views.Alerts.AlertsView.Strings.LastModifiedByUser);

                Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                    "Looking for 'Last Modified By' Window");

                //Launch Alert Severity Type view criteria dialog
                Utilities.LogMessage("Active dialog title is: " +
                    UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria.Strings.DialogTitle);

                //Set Alert Severity provided in parameters
                this.LastModifiedByUserViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                    parameters.AlertModifiedByValues[0].ToString();

                this.LastModifiedByUserViewCriteria.ClickOK();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.LastModifiedByUserViewCriteria, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Alert Last Modified By Specific User view criteria

            #region Set Alert Modified In A Specific Time Period view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter DateAndTimeModified is set to " +
                parameters.DateAndTimeModifiedFlag.ToString());

            if (parameters.DateAndTimeModifiedFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(Core.Console.Views.Alerts.AlertsView.Strings.ThatWasModified,
                    Core.Console.Views.Alerts.AlertsView.Strings.InASpecificTimePeriod);

                Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                    "Looking for 'Last Modified Time' Window");

                Utilities.LogMessage("Active dialog title is: " +
                    UI.Core.Console.Views.Alerts.AlertDateAndTimeInputViewCriteria.Strings.DialogTitle);

                //Set view criteria provided in parameters
                switch (parameters.DateAndTimeModifiedValues[0].ToString())
                {
                    case "WhithinTimeRange":
                        //Select radio button
                        this.LastModifiedInSpecificTimePeriodViewCriteria.Controls.WithinTheTimeRangeRadioButton.Click();

                        Utilities.LogMessage("Radio button state: " +
                            this.LastModifiedInSpecificTimePeriodViewCriteria.Controls.WithinTheTimeRangeRadioButton.ButtonState.ToString());

                        string afterCheckbox = parameters.DateAndTimeModifiedValues[1].ToString();

                        Utilities.LogMessage("After Checkbox is: " + afterCheckbox);

                        string beforeCheckbox = parameters.DateAndTimeModifiedValues[2].ToString();

                        Utilities.LogMessage("Before Checkbox is: " + beforeCheckbox);

                        switch (afterCheckbox)
                        {
                            case "true":
                                //check After checkbox and keep the value default for now
                                if (this.LastModifiedInSpecificTimePeriodViewCriteria.After == false)
                                {
                                    this.LastModifiedInSpecificTimePeriodViewCriteria.ClickAfter();
                                }
                                //if the value is passed, set the value
                                //if ((parameters.DateAndTimeModifiedValues[3].ToString()) != null)
                                //{
                                //    string afterValue = parameters.DateAndTimeModifiedValues[3].ToString();
                                //    this.LastModifiedInSpecificTimePeriodViewCriteria.Controls.
                                //}

                                break;

                            case "false":
                                //If After checkbox is checked, but the parameter passed is false, need to uncheck it
                                if (this.LastModifiedInSpecificTimePeriodViewCriteria.After == true)
                                {
                                    this.LastModifiedInSpecificTimePeriodViewCriteria.ClickAfter();
                                }

                                break;

                            default:
                                Utilities.LogMessage("Selected parameter is invalid: '" +
                                    parameters.DateAndTimeModifiedValues[1].ToString() + "'");
                                Utilities.LogMessage("Invalid After value is selected. " +
                                    "Expected values: 'True' OR 'False'");

                                break;

                        }

                        switch (beforeCheckbox)
                        {
                            case "true":
                                //check Before checkbox and keep the value default for now
                                if (this.LastModifiedInSpecificTimePeriodViewCriteria.Before == false)
                                {
                                    this.LastModifiedInSpecificTimePeriodViewCriteria.ClickBefore();
                                }
                                //if the value is passed, set the value
                                //if ((parameters.DateAndTimeModifiedValues[4].ToString()) != null)
                                //{
                                //    string beforeValue = parameters.DateAndTimeModifiedValues[4].ToString();
                                //    this.LastModifiedInSpecificTimePeriodViewCriteria.Controls.
                                //}

                                break;

                            case "false":
                                //If Before checkbox is checked, but the parameter passed is false, need to uncheck it
                                if (this.LastModifiedInSpecificTimePeriodViewCriteria.Before == true)
                                {
                                    this.LastModifiedInSpecificTimePeriodViewCriteria.ClickBefore();
                                }

                                break;

                            default:

                                Utilities.LogMessage("Selected parameter is invalid: '" +
                                        parameters.DateAndTimeModifiedValues[2].ToString() + "'");

                                Utilities.LogMessage("Invalid Before value is selected. " +
                                        "Expected values: 'True' OR 'False'");

                                break;

                        }

                        break;

                    case "WithinLast":
                        //Select radio button
                        this.LastModifiedInSpecificTimePeriodViewCriteria.Controls.WithinTheLastRadioButton.Click();

                        string number = parameters.DateAndTimeModifiedValues[1].ToString();
                        string time = parameters.DateAndTimeModifiedValues[2].ToString();

                        //Set the date and time accordingly
                        this.LastModifiedInSpecificTimePeriodViewCriteria.NumberTextBoxText = number;
                        this.LastModifiedInSpecificTimePeriodViewCriteria.Controls.ComboBoxTimeUnit.SelectByText(time, false);

                        Utilities.LogMessage("Within the last " +
                            this.LastModifiedInSpecificTimePeriodViewCriteria.NumberTextBoxText +
                            " " +
                            this.LastModifiedInSpecificTimePeriodViewCriteria.ComboBoxTimeUnitText +
                            " is the data set");

                        break;

                    default:
                        Utilities.LogMessage("Selected parameter is invalid: '" +
                            parameters.DateAndTimeModifiedValues[0].ToString() + "'");
                        Utilities.LogMessage("Invalid DateAndTime selected. " +
                            "Expected values: 'WhithinTimeRange' OR 'WithinLast'");

                        break;

                }

                this.LastModifiedInSpecificTimePeriodViewCriteria.ClickOK();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.LastModifiedInSpecificTimePeriodViewCriteria, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Alert Modified In A Specific Time Period view criteria

            #region Set Alert Resolution State Modified In A Specific Time Period view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter DateAndTimeResolutionChanged is set to " +
                parameters.DateAndTimeResolutionChangedFlag.ToString());

            if (parameters.DateAndTimeResolutionChangedFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(Core.Console.Views.Alerts.AlertsView.Strings.HadItsResolutionStateChanged,
                    Core.Console.Views.Alerts.AlertsView.Strings.InASpecificTimePeriodA);

                Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                    "Looking for 'Resolution State Last Modified' Window");

                Utilities.LogMessage("Active dialog title is: " +
                    UI.Core.Console.Views.Alerts.AlertDateAndTimeInputViewCriteria.Strings.DialogTitle);

                //Set view criteria provided in parameters
                switch (parameters.DateAndTimeResolutionChangedValues[0].ToString())
                {
                    case "WhithinTimeRange":
                        //Select radio button
                        this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.Controls.WithinTheTimeRangeRadioButton.Click();

                        Utilities.LogMessage("Radio button state: " +
                            this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.Controls.WithinTheTimeRangeRadioButton.ButtonState.ToString());

                        string afterCheckbox = parameters.DateAndTimeResolutionChangedValues[1].ToString();

                        Utilities.LogMessage("After Checkbox is: " + afterCheckbox);

                        string beforeCheckbox = parameters.DateAndTimeResolutionChangedValues[2].ToString();

                        Utilities.LogMessage("Before Checkbox is: " + beforeCheckbox);

                        switch (afterCheckbox)
                        {
                            case "true":
                                //check After checkbox and keep the value default for now
                                if (this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.After == false)
                                {
                                    this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.ClickAfter();
                                }
                                //if the value is passed, set the value
                                //if ((parameters.DateAndTimeResolutionChangedValues[3].ToString()) != null)
                                //{
                                //    string afterValue = parameters.DateAndTimeResolutionChangedValues[3].ToString();
                                //    this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.Controls.
                                //}

                                break;

                            case "false":
                                //If After checkbox is checked, but the parameter passed is false, need to uncheck it
                                if (this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.After == true)
                                {
                                    this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.ClickAfter();
                                }

                                break;

                            default:
                                Utilities.LogMessage("Selected parameter is invalid: '" +
                                    parameters.DateAndTimeResolutionChangedValues[1].ToString() + "'");
                                Utilities.LogMessage("Invalid After value is selected. " +
                                    "Expected values: 'True' OR 'False'");

                                break;

                        }

                        switch (beforeCheckbox)
                        {
                            case "true":
                                //check Before checkbox and keep the value default for now
                                if (this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.Before == false)
                                {
                                    this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.ClickBefore();
                                }
                                //if the value is passed, set the value
                                //if ((parameters.DateAndTimeResolutionChangedValues[4].ToString()) != null)
                                //{
                                //    string beforeValue = parameters.DateAndTimeResolutionChangedValues[4].ToString();
                                //    this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.Controls.
                                //}

                                break;

                            case "false":
                                //If Before checkbox is checked, but the parameter passed is false, need to uncheck it
                                if (this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.Before == true)
                                {
                                    this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.ClickBefore();
                                }

                                break;

                            default:

                                Utilities.LogMessage("Selected parameter is invalid: '" +
                                        parameters.DateAndTimeResolutionChangedValues[2].ToString() + "'");

                                Utilities.LogMessage("Invalid Before value is selected. " +
                                        "Expected values: 'True' OR 'False'");

                                break;

                        }

                        break;

                    case "WithinLast":
                        //Select radio button
                        this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.Controls.WithinTheLastRadioButton.Click();

                        string number = parameters.DateAndTimeResolutionChangedValues[1].ToString();
                        string time = parameters.DateAndTimeResolutionChangedValues[2].ToString();

                        //Set the date and time accordingly
                        this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.NumberTextBoxText = number;
                        this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.Controls.ComboBoxTimeUnit.SelectByText(time, false);

                        Utilities.LogMessage("Within the last " +
                            this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.NumberTextBoxText +
                            " " +
                            this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.ComboBoxTimeUnitText +
                            " is the data set");

                        break;

                    default:
                        Utilities.LogMessage("Selected parameter is invalid: '" +
                            parameters.DateAndTimeResolutionChangedValues[0].ToString() + "'");
                        Utilities.LogMessage("Invalid DateAndTime selected. " +
                            "Expected values: 'WhithinTimeRange' OR 'WithinLast'");

                        break;

                }

                this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria.ClickOK();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.ResolutionStateLastModifiedInSpecificTimePeriodViewCriteria, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Alert Modified In A Specific Time Period view criteria

            #region Set Alert Closed In A Specific Time Period view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter DateAndTimeClosed is set to " +
                parameters.DateAndTimeClosedFlag.ToString());

            if (parameters.DateAndTimeClosedFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(Core.Console.Views.Alerts.AlertsView.Strings.ThatWasResolved,
                    Core.Console.Views.Alerts.AlertsView.Strings.InASpecificTimePeriodB);

                Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                    "Looking for 'Time Resolved' Window");

                Utilities.LogMessage("Active dialog title is: " +
                    UI.Core.Console.Views.Alerts.AlertDateAndTimeInputViewCriteria.Strings.DialogTitle);

                //Set view criteria provided in parameters
                switch (parameters.DateAndTimeClosedValues[0].ToString())
                {
                    case "WhithinTimeRange":
                        //Select radio button
                        this.ResolvedInSpecificTimePeriodViewCriteria.Controls.WithinTheTimeRangeRadioButton.Click();

                        Utilities.LogMessage("Radio button state: " +
                            this.ResolvedInSpecificTimePeriodViewCriteria.Controls.WithinTheTimeRangeRadioButton.ButtonState.ToString());

                        string afterCheckbox = parameters.DateAndTimeClosedValues[1].ToString();

                        Utilities.LogMessage("After Checkbox is: " + afterCheckbox);

                        string beforeCheckbox = parameters.DateAndTimeClosedValues[2].ToString();

                        Utilities.LogMessage("Before Checkbox is: " + beforeCheckbox);

                        switch (afterCheckbox)
                        {
                            case "true":
                                //check After checkbox and keep the value default for now
                                if (this.ResolvedInSpecificTimePeriodViewCriteria.After == false)
                                {
                                    this.ResolvedInSpecificTimePeriodViewCriteria.ClickAfter();
                                }
                                //if the value is passed, set the value
                                //if ((parameters.DateAndTimeClosedValues[3].ToString()) != null)
                                //{
                                //    string afterValue = parameters.DateAndTimeClosedValues[3].ToString();
                                //    this.LastModifiedInSpecificTimePeriodViewCriteria.Controls.
                                //}

                                break;

                            case "false":
                                //If After checkbox is checked, but the parameter passed is false, need to uncheck it
                                if (this.ResolvedInSpecificTimePeriodViewCriteria.After == true)
                                {
                                    this.ResolvedInSpecificTimePeriodViewCriteria.ClickAfter();
                                }

                                break;

                            default:
                                Utilities.LogMessage("Selected parameter is invalid: '" +
                                    parameters.DateAndTimeClosedValues[1].ToString() + "'");
                                Utilities.LogMessage("Invalid After value is selected. " +
                                    "Expected values: 'True' OR 'False'");

                                break;

                        }

                        switch (beforeCheckbox)
                        {
                            case "true":
                                //check Before checkbox and keep the value default for now
                                if (this.ResolvedInSpecificTimePeriodViewCriteria.Before == false)
                                {
                                    this.ResolvedInSpecificTimePeriodViewCriteria.ClickBefore();
                                }
                                //if the value is passed, set the value
                                //if ((parameters.DateAndTimeClosedValues[4].ToString()) != null)
                                //{
                                //    string beforeValue = parameters.DateAndTimeClosedValues[4].ToString();
                                //    this.ResolvedInSpecificTimePeriodViewCriteria.Controls.
                                //}

                                break;

                            case "false":
                                //If Before checkbox is checked, but the parameter passed is false, need to uncheck it
                                if (this.ResolvedInSpecificTimePeriodViewCriteria.Before == true)
                                {
                                    this.ResolvedInSpecificTimePeriodViewCriteria.ClickBefore();
                                }

                                break;

                            default:

                                Utilities.LogMessage("Selected parameter is invalid: '" +
                                        parameters.DateAndTimeClosedValues[2].ToString() + "'");

                                Utilities.LogMessage("Invalid Before value is selected. " +
                                        "Expected values: 'True' OR 'False'");

                                break;

                        }

                        break;

                    case "WithinLast":
                        //Select radio button
                        this.ResolvedInSpecificTimePeriodViewCriteria.Controls.WithinTheLastRadioButton.Click();

                        string number = parameters.DateAndTimeClosedValues[1].ToString();
                        string time = parameters.DateAndTimeClosedValues[2].ToString();

                        //Set the date and time accordingly
                        this.ResolvedInSpecificTimePeriodViewCriteria.NumberTextBoxText = number;
                        this.ResolvedInSpecificTimePeriodViewCriteria.Controls.ComboBoxTimeUnit.SelectByText(time, false);

                        Utilities.LogMessage("Within the last " +
                            this.ResolvedInSpecificTimePeriodViewCriteria.NumberTextBoxText +
                            " " +
                            this.ResolvedInSpecificTimePeriodViewCriteria.ComboBoxTimeUnitText +
                            " is the data set");

                        break;

                    default:
                        Utilities.LogMessage("Selected parameter is invalid: '" +
                            parameters.DateAndTimeClosedValues[0].ToString() + "'");
                        Utilities.LogMessage("Invalid DateAndTime selected. " +
                            "Expected values: 'WhithinTimeRange' OR 'WithinLast'");

                        break;

                }

                this.ResolvedInSpecificTimePeriodViewCriteria.ClickOK();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.ResolvedInSpecificTimePeriodViewCriteria, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Alert Closed In A Specific Time Period view criteria

            #region Set Alert Resolved By Specific User view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter AlertClosedBy is set to " +
                parameters.AlertClosedByFlag.ToString());

            if (parameters.AlertClosedByFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(Core.Console.Views.Alerts.AlertsView.Strings.ResolvedByUser);

                Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                    "Looking for 'Resolved By' Window");

                //Launch Alert Severity Type view criteria dialog
                Utilities.LogMessage("Active dialog title is: " +
                    UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria.Strings.DialogTitle);

                //Set Alert Severity provided in parameters
                this.ResolvedByUserViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                    parameters.AlertClosedByValues[0].ToString();

                this.ResolvedByUserViewCriteria.ClickOK();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.ResolvedByUserViewCriteria, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Alert Resolved By Specific User view criteria

            #region Set Alert With Specific Ticket ID view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter AlertWithTicketId is set to " +
                parameters.AlertWithTicketIdFlag.ToString());

            if (parameters.AlertWithTicketIdFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(Core.Console.Views.Alerts.AlertsView.Strings.WithTicketID);

                Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                    "Looking for 'Ticket ID' Window");

                //Launch Alert Severity Type view criteria dialog
                Utilities.LogMessage("Active dialog title is: " +
                    UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria.Strings.DialogTitle);

                //Set Alert Severity provided in parameters
                this.WithTicketIDViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                    parameters.AlertWithTicketIdValues[0].ToString();

                this.WithTicketIDViewCriteria.ClickOK();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.WithTicketIDViewCriteria, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Alert With Specific Ticket ID view criteria

            #region Set Alert Added To Database A Specific Time Period view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter DateAndTimeAddedToDatabase is set to " +
                parameters.DateAndTimeAddedToDatabaseFlag.ToString());

            if (parameters.DateAndTimeAddedToDatabaseFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(Core.Console.Views.Alerts.AlertsView.Strings.WasAddedToTheDatabase,
                    Core.Console.Views.Alerts.AlertsView.Strings.InASpecificTimePeriodC);

                Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                    "Looking for 'Time Added' Window");

                //Set view criteria provided in parameters
                switch (parameters.DateAndTimeAddedToDatabaseValues[0].ToString())
                {
                    case "WhithinTimeRange":
                        //Select radio button
                        this.AddedToDatabaseInSpecificTimePeriodViewCriteria.Controls.WithinTheTimeRangeRadioButton.Click();

                        Utilities.LogMessage("Radio button state: " +
                            this.AddedToDatabaseInSpecificTimePeriodViewCriteria.Controls.WithinTheTimeRangeRadioButton.ButtonState.ToString());

                        string afterCheckbox = parameters.DateAndTimeAddedToDatabaseValues[1].ToString();

                        Utilities.LogMessage("After Checkbox is: " + afterCheckbox);

                        string beforeCheckbox = parameters.DateAndTimeAddedToDatabaseValues[2].ToString();

                        Utilities.LogMessage("Before Checkbox is: " + beforeCheckbox);

                        switch (afterCheckbox)
                        {
                            case "true":
                                //check After checkbox and keep the value default for now
                                if (this.AddedToDatabaseInSpecificTimePeriodViewCriteria.After == false)
                                {
                                    this.AddedToDatabaseInSpecificTimePeriodViewCriteria.ClickAfter();
                                }
                                //if the value is passed, set the value
                                //if ((parameters.DateAndTimeAddedToDatabaseValues[3].ToString()) != null)
                                //{
                                //    string afterValue = parameters.DateAndTimeAddedToDatabaseValues[3].ToString();
                                //    this.AddedToDatabaseInSpecificTimePeriodViewCriteria.Controls.
                                //}

                                break;

                            case "false":
                                //If After checkbox is checked, but the parameter passed is false, need to uncheck it
                                if (this.AddedToDatabaseInSpecificTimePeriodViewCriteria.After == true)
                                {
                                    this.AddedToDatabaseInSpecificTimePeriodViewCriteria.ClickAfter();
                                }

                                break;

                            default:
                                Utilities.LogMessage("Selected parameter is invalid: '" +
                                    parameters.DateAndTimeAddedToDatabaseValues[1].ToString() + "'");
                                Utilities.LogMessage("Invalid After value is selected. " +
                                    "Expected values: 'True' OR 'False'");

                                break;

                        }

                        switch (beforeCheckbox)
                        {
                            case "true":
                                //check Before checkbox and keep the value default for now
                                if (this.AddedToDatabaseInSpecificTimePeriodViewCriteria.Before == false)
                                {
                                    this.AddedToDatabaseInSpecificTimePeriodViewCriteria.ClickBefore();
                                }
                                //if the value is passed, set the value
                                //if ((parameters.DateAndTimeAddedToDatabaseValues[4].ToString()) != null)
                                //{
                                //    string beforeValue = parameters.DateAndTimeAddedToDatabaseValues[4].ToString();
                                //    this.AddedToDatabaseInSpecificTimePeriodViewCriteria.Controls.
                                //}

                                break;

                            case "false":
                                //If Before checkbox is checked, but the parameter passed is false, need to uncheck it
                                if (this.AddedToDatabaseInSpecificTimePeriodViewCriteria.Before == true)
                                {
                                    this.AddedToDatabaseInSpecificTimePeriodViewCriteria.ClickBefore();
                                }

                                break;

                            default:

                                Utilities.LogMessage("Selected parameter is invalid: '" +
                                        parameters.DateAndTimeAddedToDatabaseValues[2].ToString() + "'");

                                Utilities.LogMessage("Invalid Before value is selected. " +
                                        "Expected values: 'True' OR 'False'");

                                break;

                        }

                        break;

                    case "WithinLast":
                        //Select radio button
                        this.AddedToDatabaseInSpecificTimePeriodViewCriteria.Controls.WithinTheLastRadioButton.Click();

                        string number = parameters.DateAndTimeAddedToDatabaseValues[1].ToString();
                        string time = parameters.DateAndTimeAddedToDatabaseValues[2].ToString();

                        //Set the date and time accordingly
                        this.AddedToDatabaseInSpecificTimePeriodViewCriteria.NumberTextBoxText = number;
                        this.AddedToDatabaseInSpecificTimePeriodViewCriteria.Controls.ComboBoxTimeUnit.SelectByText(time, false);

                        Utilities.LogMessage("Within the last " +
                            this.AddedToDatabaseInSpecificTimePeriodViewCriteria.NumberTextBoxText +
                            " " +
                            this.AddedToDatabaseInSpecificTimePeriodViewCriteria.ComboBoxTimeUnitText +
                            " is the data set");

                        break;

                    default:
                        Utilities.LogMessage("Selected parameter is invalid: '" +
                            parameters.DateAndTimeAddedToDatabaseValues[0].ToString() + "'");
                        Utilities.LogMessage("Invalid DateAndTime selected. " +
                            "Expected values: 'WhithinTimeRange' OR 'WithinLast'");

                        break;

                }

                this.AddedToDatabaseInSpecificTimePeriodViewCriteria.ClickOK();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.AddedToDatabaseInSpecificTimePeriodViewCriteria, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Alert Added To Database A Specific Time Period view criteria

            #region Set Alert From Specific Site view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter AlertWithSite is set to " +
                parameters.AlertWithSiteFlag.ToString());

            if (parameters.AlertWithSiteFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(Core.Console.Views.Alerts.AlertsView.Strings.FromSite);

                Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                    "Looking for 'Site' Window");

                //Set Alert Severity provided in parameters
                this.WithSiteViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                    parameters.AlertWithSiteValues[0].ToString();

                this.WithSiteViewCriteria.ClickOK();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.WithSiteViewCriteria, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Alert From Specific Site view criteria

            #region Set Alert With Specific Custom Fields (1-10) view criteria

            Utilities.LogMessage("Views.AlertViewPropertiesSupport :: Parameter AlertWithCustomField is set to " +
                parameters.AlertWithCustomFieldFlag.ToString());

            if (parameters.AlertWithCustomFieldFlag == true)
            {
                switch (parameters.AlertWithCustomFieldValues[0].ToString())
                {
                    case "CustomField1":

                        //Format the string to create Custom Field1
                        string CustomField1 = Core.Console.Views.Alerts.AlertsView.Strings.WithTextIn.Replace(
                        "{2}",
                        Core.Console.Views.Alerts.AlertsView.Strings.CustomField + "1");

                        //Launch the view criteria dialog
                        LaunchSpecificViewCriteriaDialog(CustomField1);

                        Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                            "Looking for '" +
                            parameters.AlertWithCustomFieldValues[0].ToString() +
                            "' Window");

                        Utilities.LogMessage("Active dialog title is: " +
                            UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria.Strings.DialogTitle);

                        //Set Alert Custom Field provided in parameters
                        this.WithCustomField1ViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                            parameters.AlertWithCustomFieldValues[1].ToString();

                        this.WithCustomField1ViewCriteria.ClickOK();

                        if (!CoreManager.MomConsole.WaitForDialogClose(this.WithCustomField1ViewCriteria, 120))
                        {
                            Utilities.TakeScreenshot("HitIssuesSavingAlertPropertiesDialog!");
                        }

                        break;

                    case "CustomField2":

                        //Format the string to create Custom Field2
                        string CustomField2 = Core.Console.Views.Alerts.AlertsView.Strings.WithTextIn.Replace(
                        "{2}",
                        Core.Console.Views.Alerts.AlertsView.Strings.CustomField + "2");

                        //Launch the view criteria dialog
                        LaunchSpecificViewCriteriaDialog(CustomField2);

                        Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                            "Looking for '" +
                            parameters.AlertWithCustomFieldValues[0].ToString() +
                            "' Window");

                        Utilities.LogMessage("Active dialog title is: " +
                            UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria.Strings.DialogTitle);

                        //Set Alert Custom Field provided in parameters
                        this.WithCustomField2ViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                            parameters.AlertWithCustomFieldValues[1].ToString();

                        this.WithCustomField2ViewCriteria.ClickOK();

                        if (!CoreManager.MomConsole.WaitForDialogClose(this.WithCustomField2ViewCriteria, 120))
                        {
                            Utilities.TakeScreenshot("HitIssuesSavingAlertPropertiesDialog!");
                        }

                        break;

                    case "CustomField3":

                        //Format the string to create Custom Field3
                        string CustomField3 = Core.Console.Views.Alerts.AlertsView.Strings.WithTextIn.Replace(
                        "{2}",
                        Core.Console.Views.Alerts.AlertsView.Strings.CustomField + "3");

                        //Launch the view criteria dialog
                        LaunchSpecificViewCriteriaDialog(CustomField3);

                        Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                            "Looking for '" +
                            parameters.AlertWithCustomFieldValues[0].ToString() +
                            "' Window");

                        Utilities.LogMessage("Active dialog title is: " +
                            UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria.Strings.DialogTitle);

                        //Set Alert Custom Field provided in parameters
                        this.WithCustomField3ViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                            parameters.AlertWithCustomFieldValues[1].ToString();

                        this.WithCustomField3ViewCriteria.ClickOK();

                        if (!CoreManager.MomConsole.WaitForDialogClose(this.WithCustomField3ViewCriteria, 120))
                        {
                            Utilities.TakeScreenshot("HitIssuesSavingAlertPropertiesDialog!");
                        }

                        break;

                    case "CustomField4":

                        //Format the string to create Custom Field4
                        string CustomField4 = Core.Console.Views.Alerts.AlertsView.Strings.WithTextIn.Replace(
                        "{2}",
                        Core.Console.Views.Alerts.AlertsView.Strings.CustomField + "4");

                        //Launch the view criteria dialog
                        LaunchSpecificViewCriteriaDialog(CustomField4);

                        Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                            "Looking for '" +
                            parameters.AlertWithCustomFieldValues[0].ToString() +
                            "' Window");

                        Utilities.LogMessage("Active dialog title is: " +
                            UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria.Strings.DialogTitle);

                        //Set Alert Custom Field provided in parameters
                        this.WithCustomField4ViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                            parameters.AlertWithCustomFieldValues[1].ToString();

                        this.WithCustomField4ViewCriteria.ClickOK();

                        if (!CoreManager.MomConsole.WaitForDialogClose(this.WithCustomField4ViewCriteria, 120))
                        {
                            Utilities.TakeScreenshot("HitIssuesSavingAlertPropertiesDialog!");
                        }

                        break;

                    case "CustomField5":

                        //Format the string to create Custom Field5
                        string CustomField5 = Core.Console.Views.Alerts.AlertsView.Strings.WithTextIn.Replace(
                        "{2}",
                        Core.Console.Views.Alerts.AlertsView.Strings.CustomField + "5");

                        //Launch the view criteria dialog
                        LaunchSpecificViewCriteriaDialog(CustomField5);

                        Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                            "Looking for '" +
                            parameters.AlertWithCustomFieldValues[0].ToString() +
                            "' Window");

                        Utilities.LogMessage("Active dialog title is: " +
                            UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria.Strings.DialogTitle);

                        //Set Alert Custom Field provided in parameters
                        this.WithCustomField5ViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                            parameters.AlertWithCustomFieldValues[1].ToString();

                        this.WithCustomField5ViewCriteria.ClickOK();

                        if (!CoreManager.MomConsole.WaitForDialogClose(this.WithCustomField5ViewCriteria, 120))
                        {
                            Utilities.TakeScreenshot("HitIssuesSavingAlertPropertiesDialog!");
                        }

                        break;

                    case "CustomField6":

                        //Format the string to create Custom Field6
                        string CustomField6 = Core.Console.Views.Alerts.AlertsView.Strings.WithTextIn.Replace(
                        "{2}",
                        Core.Console.Views.Alerts.AlertsView.Strings.CustomField + "6");

                        //Launch the view criteria dialog
                        LaunchSpecificViewCriteriaDialog(CustomField6);

                        Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                            "Looking for '" +
                            parameters.AlertWithCustomFieldValues[0].ToString() +
                            "' Window");

                        Utilities.LogMessage("Active dialog title is: " +
                            UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria.Strings.DialogTitle);

                        //Set Alert Custom Field provided in parameters
                        this.WithCustomField6ViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                            parameters.AlertWithCustomFieldValues[1].ToString();

                        this.WithCustomField6ViewCriteria.ClickOK();

                        if (!CoreManager.MomConsole.WaitForDialogClose(this.WithCustomField6ViewCriteria, 120))
                        {
                            Utilities.TakeScreenshot("HitIssuesSavingAlertPropertiesDialog!");
                        }

                        break;

                    case "CustomField7":

                        //Format the string to create Custom Field7
                        string CustomField7 = Core.Console.Views.Alerts.AlertsView.Strings.WithTextIn.Replace(
                        "{2}",
                        Core.Console.Views.Alerts.AlertsView.Strings.CustomField + "7");

                        //Launch the view criteria dialog
                        LaunchSpecificViewCriteriaDialog(CustomField7);

                        Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                            "Looking for '" +
                            parameters.AlertWithCustomFieldValues[0].ToString() +
                            "' Window");

                        Utilities.LogMessage("Active dialog title is: " +
                            UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria.Strings.DialogTitle);

                        //Set Alert Custom Field provided in parameters
                        this.WithCustomField7ViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                            parameters.AlertWithCustomFieldValues[1].ToString();

                        this.WithCustomField7ViewCriteria.ClickOK();

                        if (!CoreManager.MomConsole.WaitForDialogClose(this.WithCustomField7ViewCriteria, 120))
                        {
                            Utilities.TakeScreenshot("HitIssuesSavingAlertPropertiesDialog!");
                        }

                        break;

                    case "CustomField8":

                        //Format the string to create Custom Field8
                        string CustomField8 = Core.Console.Views.Alerts.AlertsView.Strings.WithTextIn.Replace(
                        "{2}",
                        Core.Console.Views.Alerts.AlertsView.Strings.CustomField + "8");

                        //Launch the view criteria dialog
                        LaunchSpecificViewCriteriaDialog(CustomField8);

                        Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                            "Looking for '" +
                            parameters.AlertWithCustomFieldValues[0].ToString() +
                            "' Window");

                        Utilities.LogMessage("Active dialog title is: " +
                            UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria.Strings.DialogTitle);

                        //Set Alert Custom Field provided in parameters
                        this.WithCustomField8ViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                            parameters.AlertWithCustomFieldValues[1].ToString();

                        this.WithCustomField8ViewCriteria.ClickOK();

                        if (!CoreManager.MomConsole.WaitForDialogClose(this.WithCustomField8ViewCriteria, 120))
                        {
                            Utilities.TakeScreenshot("HitIssuesSavingAlertPropertiesDialog!");
                        }

                        break;

                    case "CustomField9":

                        //Format the string to create Custom Field9
                        string CustomField9 = Core.Console.Views.Alerts.AlertsView.Strings.WithTextIn.Replace(
                        "{2}",
                        Core.Console.Views.Alerts.AlertsView.Strings.CustomField + "9");

                        //Launch the view criteria dialog
                        LaunchSpecificViewCriteriaDialog(CustomField9);

                        Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                            "Looking for '" +
                            parameters.AlertWithCustomFieldValues[0].ToString() +
                            "' Window");

                        Utilities.LogMessage("Active dialog title is: " +
                            UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria.Strings.DialogTitle);

                        //Set Alert Custom Field provided in parameters
                        this.WithCustomField9ViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                            parameters.AlertWithCustomFieldValues[1].ToString();

                        this.WithCustomField9ViewCriteria.ClickOK();

                        if (!CoreManager.MomConsole.WaitForDialogClose(this.WithCustomField9ViewCriteria, 120))
                        {
                            Utilities.TakeScreenshot("HitIssuesSavingAlertPropertiesDialog!");
                        }

                        break;

                    case "CustomField10":

                        //Format the string to create Custom Field10
                        string CustomField10 = Core.Console.Views.Alerts.AlertsView.Strings.WithTextIn.Replace(
                        "{2}",
                        Core.Console.Views.Alerts.AlertsView.Strings.CustomField + "10");

                        //Launch the view criteria dialog
                        LaunchSpecificViewCriteriaDialog(CustomField10);

                        Utilities.LogMessage("Views.AlertViewPropertiesSupport :: " +
                            "Looking for '" +
                            parameters.AlertWithCustomFieldValues[0].ToString() +
                            "' Window");

                        Utilities.LogMessage("Active dialog title is: " +
                            UI.Core.Console.Views.Alerts.AlertTextInputViewCriteria.Strings.DialogTitle);

                        //Set Alert Custom Field provided in parameters
                        this.WithCustomField10ViewCriteria.SpecifyTheTextStringToSearchForSQLStyleWildcards_AreAcceptedText =
                            parameters.AlertWithCustomFieldValues[1].ToString();

                        this.WithCustomField10ViewCriteria.ClickOK();

                        if (!CoreManager.MomConsole.WaitForDialogClose(this.WithCustomField10ViewCriteria, 120))
                        {
                            Utilities.TakeScreenshot("HitIssuesSavingAlertPropertiesDialog!");
                        }

                        break;

                    default:

                        Utilities.LogMessage("Selected item is: '" +
                            parameters.AlertWithCustomFieldValues[0].ToString() + "'");

                        Utilities.LogMessage("It is invalid. Expected Custom Fields 1-10");

                        break;

                }


            }

            #endregion //End of Set Alert From Specific Site view criteria

            Utilities.TakeScreenshot("AlertViewCriteriaSet");

            //If no target set, do not change it, leave it as default
            if (parameters.Target != null)
            {
                AlertViewProperties.ClickEllipsis28();
                SelectTargetName(parameters.Target);
            }
            Utilities.LogMessage("Views.AlertViewPropertiesSupport:: Trying to save and close dialog...");

            this.AlertViewProperties.ClickOK();

            if (!CoreManager.MomConsole.WaitForDialogClose(this.AlertViewProperties, 180))
            {
                Utilities.TakeScreenshot("HitIssuesSavingAlertPropertiesDialog!");
            }

            Utilities.LogMessage("Views.AlertViewPropertiesSupport:: " +
                "Success in saving and closing new view authring Properties dialog");

        }
        #endregion

        #region State View Properties Support
        /// <summary>
        /// Work on Launching new State view Properties dialog and setting view criteria
        /// </summary>
        /// <param name="viewTypeMenuItem">State view menu item</param>
        /// <param name="parameters">Parameters to set</param>
        /// <history>
        ///		[lucyra] 18JAN06 Created
        /// </history>
        private void StateViewPropertiesSupport(string viewTypeMenuItem, CreateViewParameters parameters)
        {
            this.Launch(viewTypeMenuItem, parameters);

            this.StateViewProperties.NameText = parameters.Name;
            this.StateViewProperties.DescriptionText = parameters.Description;

            Utilities.LogMessage("Views.StateViewPropertiesSupport:: Trying to save and close dialog...");

            //If no target set, do not change it, leave it as default
            if (parameters.Target != null)
            {
                StateViewProperties.ClickEllipsis3();
                SelectTargetName(parameters.Target);
            }
            this.StateViewProperties.ClickOK();

            CoreManager.MomConsole.WaitForDialogClose(this.StateViewProperties, Constants.DefaultDialogTimeout / 1000);

            Utilities.LogMessage("Views.StateViewPropertiesSupport:: " +
                "Success in saving and closing new view authring Properties dialog");

        }
        #endregion

        #region Event View Properties Support
        /// <summary>
        /// Work on Launching new Event view Properties dialog and setting view criteria
        /// </summary>
        /// <param name="viewTypeMenuItem">Event view menu item</param>
        /// <param name="parameters">Parameters to set</param>
        /// <history>
        ///		[lucyra] 18JAN06 Created
        /// </history>
        private void EventViewPropertiesSupport(string viewTypeMenuItem, CreateViewParameters parameters)
        {
            this.Launch(viewTypeMenuItem, parameters);

            this.EventViewProperties.NameText = parameters.Name;
            this.EventViewProperties.DescriptionText = parameters.Description;

            Utilities.LogMessage("Views.EventViewPropertiesSupport:: Trying to save and close dialog...");

            //If no target set, do not change it, leave it as default
            if (parameters.Target != null)
            {
                EventViewProperties.ClickEllipsis1();
                SelectTargetName(parameters.Target);
            }

            this.EventViewProperties.ClickOK();

            //Increase the timeout here because sometimes 15 second is not enough for closing this dialog since it needs to save modifications
            CoreManager.MomConsole.WaitForDialogClose(this.EventViewProperties, (Constants.DefaultDialogTimeout / 1000) * 2);

            Utilities.LogMessage("Views.EventViewPropertiesSupport::" +
                "Success in saving and closing new view authring Properties dialog");

        }
        #endregion

        #region Performance View Properties Support
        /// <summary>
        /// Work on Launching new Performance View Properties dialog
        /// </summary>
        /// <param name="viewTypeMenuItem">Performance view menu item</param>
        /// <param name="parameters">Parameters to set</param>
        /// <history>
        ///		[lucyra] 23JUN06 Created
        ///     [dialac] 17JUL06 adding logic to set the name and description and clickOK.
        /// </history>
        private void PerformanceViewPropertiesSupport(string viewTypeMenuItem, CreateViewParameters parameters)
        {
            this.Launch(viewTypeMenuItem, parameters);
            Utilities.LogMessage("Views.PerformanceViewPropertiesSupport:: The Properties dialog was lauched sucessfully");
            this.PerfViewProperties.NameText = parameters.Name;
            this.PerfViewProperties.DescriptionText = parameters.Description;
            Utilities.LogMessage("Views.PerformanceViewPropertiesSupport:: Trying to save and close dialog...");
            this.PerfViewProperties.ClickOK();
            CoreManager.MomConsole.WaitForDialogClose(this.PerfViewProperties, Constants.DefaultDialogTimeout / 1000);
            Utilities.LogMessage("Views.PerformanceViewPropertiesSupport:: Success in saving and closing new view Properties dialog");
        }
        #endregion

        #region Task Status View Properties Support

        /// <summary>
        /// Work on Launching new Task Status View Properties dialog
        /// </summary>
        /// <param name="viewTypeMenuItem">Task Status view menu item</param>
        /// <param name="parameters">Parameters to set</param>
        /// <history>
        ///		[lucyra] 23JUN06 Created
        ///     [visnara] 30MAY07 Used Event View Dialog to create task status view (since the UI Page framework is the same)
        ///                       Will have to add support for various properties/view filters specific to this view
        ///     [v-eachu] 27SEP09 Used Task View Dialog to create task status view
        ///                       Create Task View with specific criteria
        /// </history>
        private void TaskStatusViewPropertiesSupport(string viewTypeMenuItem, CreateViewParameters parameters)
        {
            Utilities.LogMessage("TaskStatusViewPropertiesSupport :: Launching Task Status create wizard");
            this.Launch(viewTypeMenuItem, parameters);

            // start from here
            this.TaskStatusViewProperties.NameText = parameters.Name;
            this.TaskStatusViewProperties.DescriptionText = parameters.Description;

            Utilities.LogMessage("Views.TaskStatusViewPropertiesSupport:: Trying to save and close dialog...");

            #region Set Specific Status view criteria

            Utilities.LogMessage("Views.TaskStatusViewPropertiesSupport :: Parameter Specific Status is set to " +
                parameters.TaskSpecificStatusFlag.ToString());

            if (parameters.TaskSpecificStatusFlag == true)
            {
                //Launch the view criteria dialog
                LaunchSpecificViewCriteriaDialog(ViewType.TaskStatusView, Core.Console.Views.TaskStatus.TaskStatusView.Strings.WithStatus);

                Utilities.LogMessage("Views.TaskStatusViewPropertiesSupport :: " +
                    "Looking for Task Status Type Window");

                //Launch Specfic Status view criteria dialog
                Utilities.LogMessage("Active dialog title is: " +
                    UI.Core.Console.Views.TaskStatus.Dialogs.TaskSelectionWithSpecificStatusDialog.Strings.DialogTitle);

                //Set Alert Severity provided in parameters
                this.TaskStatusCriteriaDialog.Controls.ListBox0[parameters.TaskSpecificStatusValues[0].ToString(), false].Click();

                this.TaskStatusCriteriaDialog.ClickOK();

                if (!CoreManager.MomConsole.WaitForDialogClose(this.TaskStatusCriteriaDialog, 120))
                {
                    Utilities.TakeScreenshot("HitIssuesSavingFromSpecificSiteDialog!");
                }

            }

            #endregion //End of Set Task Specific Status view criteria

            //If no target set, do not change it, leave it as default
            if (parameters.Target != null)
            {
                TaskStatusViewProperties.ClickEllipsis3();
                SelectTargetName(parameters.Target);
            }
            this.TaskStatusViewProperties.ClickOK();

            CoreManager.MomConsole.WaitForDialogClose(this.TaskStatusViewProperties, Constants.DefaultDialogTimeout / 1000 * 10);

            Utilities.LogMessage("Views.TaskStatusViewPropertiesSupport::" +
                "Success in saving and closing new view authoring Properties dialog");

        }

        #endregion

        #region Web Page View Properties Support

        /// <summary>
        /// Work on Launching new Web Page View Properties dialog
        /// </summary>
        /// <param name="viewTypeMenuItem">Web Page view menu item</param>
        /// <param name="parameters">Parameters to set</param>
        /// <history>
        ///		[lucyra] 23JUN06 Created
        /// </history>
        private void WebPageViewPropertiesSupport(string viewTypeMenuItem, CreateViewParameters parameters)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            this.Launch(viewTypeMenuItem, parameters);

            //Name
            Utilities.LogMessage(currentMethod + " :: Entering view name : " + parameters.Name);
            this.WebPageViewProperties.NameText = parameters.Name;

            //Description
            Utilities.LogMessage(currentMethod + " :: Entering view desc : " + parameters.Description);
            this.WebPageViewProperties.DescriptionText = parameters.Description;

            //url
            Utilities.LogMessage(currentMethod + " :: Entering TargetWebsiteText : " + parameters.Target);
            this.WebPageViewProperties.TargetWebsiteText = parameters.Target;

            //Click OK
            Utilities.LogMessage(currentMethod + " :: Clicking OK Button ");
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(this.WebPageViewProperties.Controls.OKButton, timeout * Constants.OneSecond);
            this.WebPageViewProperties.ClickOK();

            CoreManager.MomConsole.WaitForDialogClose(this.WebPageViewProperties, Constants.DefaultDialogTimeout / 1000 * 10);
            consoleApp.Waiters.WaitForStatusReady(timeout*3);
        }

        #endregion

        #region Dashboard View Properites Support

        /// <summary>
        /// Work on Launching new Dashboard View Properties dialog
        /// </summary>
        /// <param name="viewTypeMenuItem">Dashboard view menu item</param>
        /// <param name="parameters">Parameters to set</param>
        /// <history>
        ///		[lucyra] 23JUN06 Created
        /// </history>
        private void DashboardViewPropertiesSupport(string viewTypeMenuItem, CreateViewParameters parameters)
        {
            //this.Launch(viewTypeMenuItem, parameters);
            DashView.DashViewParameters dashViewParameters = new Mom.Test.UI.Core.Console.Views.DashView.DashViewParameters();
            dashViewParameters.DashViewName = parameters.Name;
            dashViewParameters.DashViewDesc = parameters.Description;

            switch (parameters.Space)
            {
                case NavigationPane.NavigationTreeView.Monitoring:
                    dashViewParameters.Space = NavigationPane.WunderBarButton.Monitoring;
                    dashViewParameters.Path = NavigationPane.Strings.Monitoring + Constants.PathDelimiter +
                        parameters.FolderName;
                    break;
                case NavigationPane.NavigationTreeView.MyWorkspace:
                    dashViewParameters.Space = NavigationPane.WunderBarButton.MyWorkspace;
                    dashViewParameters.Path = NavigationPane.Strings.MyWorkspace + Constants.PathDelimiter +
                        parameters.FolderName;
                    break;

            }

            DashView.DashView dashViewProperties = new Mom.Test.UI.Core.Console.Views.DashView.DashView();
            dashViewProperties.Create(dashViewParameters);
        }

        #endregion

        #region DiagramView Properties Support

        /// <summary>
        /// Work on Launching new Diagram View Properties dialog
        /// </summary>
        /// <param name="viewTypeMenuItem">Diagram view menu item</param>
        /// <param name="parameters">Parameters to set</param>
        /// <history>
        ///		[v-cheli] 25NOV08 Created
        /// </history>
        private void DiagramViewPropertiesSupport(string viewTypeMenuItem, CreateViewParameters parameters)
        {
            this.Launch(viewTypeMenuItem, parameters);
            Utilities.LogMessage("Views.DiagramViewPropertiesSupport(...) :: Launching Diagram View create wizard");

            this.DiagramViewProperties.NameText = parameters.Name;
            this.DiagramViewProperties.DescriptionText = parameters.Description;

            //Select a target object
            this.DiagramViewProperties.ClickBrowse();

            Core.Console.Dialogs.SingleObjectSearchDialog objectSearchDialog = new Core.Console.Dialogs.SingleObjectSearchDialog(CoreManager.MomConsole);
            objectSearchDialog.ScreenElement.WaitForReady();
            objectSearchDialog.Extended.SetFocus();

            objectSearchDialog.Controls.FilterByTextBox.Text = Constants.UITestComputerGroup;
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(objectSearchDialog.Controls.SearchButton, timeout);
            objectSearchDialog.ClickSearch();
            Utilities.LogMessage("Search button clicked.");

            int itemCount = objectSearchDialog.Controls.AvailableItemsListView.Items.Count;
            //Make sure the search finishes
            int retry = 0;
            while (itemCount <= 0 && retry < Constants.DefaultMaxRetry)
            {
                Utilities.LogMessage("Available items are not fully loaded yet, wait and retry " + retry);
                Sleeper.Delay(Constants.OneSecond * 2);
                itemCount = objectSearchDialog.Controls.AvailableItemsListView.Items.Count;
            }
            Utilities.LogMessage("Item count:" + itemCount.ToString());

            //Use "UI Test Computer Group" for default Diagram view creat
            consoleApp.SelectListViewItems(Constants.UITestComputerGroup, 0, objectSearchDialog.Controls.AvailableItemsListView, false);

            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(objectSearchDialog.Controls.AddButton, timeout);
            objectSearchDialog.ClickAdd();
            CoreManager.MomConsole.Waiters.WaitForButtonEnabled(objectSearchDialog.Controls.OKButton, timeout);
            objectSearchDialog.ClickOK();
            Utilities.LogMessage("Views.DiagramViewPropertiesSupport(...) :: Select a target object...");

            //Check create your own template, use this one for default Diagram view creat
            UISynchronization.WaitForUIObjectReady(this.DiagramViewProperties, timeout);
            this.DiagramViewProperties.WaitForResponse(timeout);
            this.DiagramViewProperties.Controls.CreateYourOwnTemplateRadioButton.Click();
            Utilities.LogMessage("Views.DiagramViewPropertiesSupport(...) :: Trying to save and close dialog...");

            this.DiagramViewProperties.ClickCreate();
            CoreManager.MomConsole.WaitForDialogClose(this.DiagramViewProperties, Constants.DefaultDialogTimeout / 1000);
            Utilities.LogMessage("Views.DiagramViewPropertiesSupport(...) :: " +
                "Sucess in saving and closing new view authring Properties dialog");

        }

        #endregion

        #region Folder Properties Support

        /// <summary>
        /// Work on Launching new Folder Properties dialog
        /// </summary>
        /// <param name="viewTypeMenuItem">Folder menu item</param>
        /// <param name="parameters">Parameters to set</param>
        /// <history>
        ///		[lucyra] 23JUN06 Created
        /// </history>
        private void FolderPropertiesSupport(string viewTypeMenuItem, CreateViewParameters parameters)
        {
            this.Launch(viewTypeMenuItem, parameters);
        }

        /// <summary>
        ///  Launch new Overrides Summary View Properties dialog
        /// </summary>
        /// <param name="viewTypeMenuItem"></param>
        /// <param name="parameters"></param>
        /// <history>
        ///     [nathd] 30AUG08 Created
        /// </history>
        private void OverridesSummaryViewPropertiesSupport(string viewTypeMenuItem, CreateViewParameters parameters)
        {
            parameters.Space = NavigationPane.NavigationTreeView.MyWorkspace;
            this.Launch(viewTypeMenuItem, parameters);
            Utilities.LogMessage("Views.OverridesSummaryViewPropertiesSupport:: The Properties dialog was lauched sucessfully");
            this.OverridesSummaryViewProperties.NameText = parameters.Name;
            this.OverridesSummaryViewProperties.DescriptionText = parameters.Description;
            Utilities.LogMessage("Views.OverridesSummaryViewPropertiesSupport:: Trying to save and close dialog...");
            this.OverridesSummaryViewProperties.ClickOK();
            CoreManager.MomConsole.WaitForDialogClose(this.OverridesSummaryViewProperties, Constants.DefaultDialogTimeout);
            Utilities.LogMessage("Views.OverridesSummaryViewPropertiesSupport:: Success in saving and closing new view Properties dialog");
        }
        #endregion

        /// <summary>
        /// CreateView parameters structure.
        /// </summary>
        /// <param name="parameters">CreateViewParameters</param>
        /// <returns>Parameters</returns>
        /// <history>
        ///		[lucyra] 18JAN06 Created
        /// </history>
        private static CreateViewParameters UpdateParameters(CreateViewParameters parameters)
        {
            Utilities.LogMessage("CreateView.UpdateParameters:: ");

            return parameters;
        }
        #endregion

        #region CreateViewParameters Class
        /// <summary>
        /// Parameters class for CreateView constructors.
        /// </summary>
        /// <history>
        /// [lucyra] 18JAN06 Created
        /// [visnara] 14MAY07 Added support for multiple spaces (Monitoring/My Workspace)
        /// </history>
        public class CreateViewParameters
        {
            /// ------------------------------------------------------------------
            /// <summary>
            ///  enum related to various StartPoint for creating webpage view 
            /// </summary>
            /// <remarks>
            /// Context menu is assumed unless otherwise explicitly set
            /// </remarks>
            /// ------------------------------------------------------------------
            public enum StartPointEnum
            {
                /// <summary>
                /// NavPaneContextMenu
                /// </summary>
                NavPaneContextMenu,

                /// <summary>
                /// NavPaneLink
                /// </summary>
                NavPaneLink,
            }
            #region Private Members

            /// <summary>
            /// Space (Monitoring/My Workspace. Default is Monitoring)
            /// </summary>
            private NavigationPane.NavigationTreeView cachedSpace = NavigationPane.NavigationTreeView.Monitoring;
            /// <summary>
            /// StartPoint
            /// </summary>
            private StartPointEnum cachedStartPoint;
            /// <summary>
            /// Cached Folder Name
            /// </summary>
            private string cachedFolderName = null;

            /// <summary>
            /// Cached Name
            /// </summary>
            private string cachedName = null;

            /// <summary>
            /// Cached Description
            /// </summary>
            private string cachedDescription = null;
            private string cachedTarget = null;

            #region Alert View Criteria Private Members

            /// <summary>
            /// Cached Alert Severity Flag
            /// </summary>
            private bool cachedAlertSeverityFlag = false;

            /// <summary>
            /// Cached Alert Severity items
            /// </summary>
            private ArrayList cachedAlertSeverityValues = new ArrayList();

            /// <summary>
            /// Cached Alert Priority Flag
            /// </summary>
            private bool cachedAlertPriorityFlag = false;

            /// <summary>
            /// Cached Alert Priority
            /// </summary>
            private ArrayList cachedAlertPriorityValues = new ArrayList();

            /// <summary>
            /// Cached Alert Sources Flag
            /// </summary>
            private bool cachedAlertSourcesFlag = false;

            /// <summary>
            /// Cached Select All Flag
            /// </summary>
            private bool cachedSelectAllFlag = false;

            /// <summary>
            /// Cached Alert Sources 
            /// </summary>
            private ArrayList cachedAlertSourcesValues = new ArrayList();

            /// <summary>
            /// Cached Alert Resolution State Flag
            /// </summary>
            private bool cachedAlertResolutionStateFlag = false;

            /// <summary>
            /// Cached Custom Alert Resolution State Flag
            /// </summary>
            private bool cachedOnlyAlertResolutionStateFlag = false;

            /// <summary>
            /// Cached Custom Alert Resolution State Values
            /// </summary>
            private ArrayList cachedOnlyAlertResolutionStateValues = new ArrayList();

            /// <summary>
            /// Cached Alert Resolution State Values
            /// </summary>
            private ArrayList cachedAlertResolutionStateValues = new ArrayList();

            /// <summary>
            /// Cached Select Alert With Name Flag
            /// </summary>
            private bool cachedAlertWithNameFlag = false;

            /// <summary>
            /// Cached Alert With Name Values
            /// </summary>
            private ArrayList cachedAlertWithNameValues = new ArrayList();

            /// <summary>
            /// Cached Select Alert With Description Flag
            /// </summary>
            private bool cachedAlertWithDescriptionFlag = false;

            /// <summary>
            /// Cached Alert With Description Values
            /// </summary>
            private ArrayList cachedAlertWithDescriptionValues = new ArrayList();

            /// <summary>
            /// Cached Custom Alert Date and Time Control: Created in a specific time period Flag
            /// </summary>
            private bool cachedDateAndTimeCreatedFlag = false;

            /// <summary>
            /// Cached Date and Time Created Values
            /// </summary>
            private ArrayList cachedDateAndTimeCreatedValues = new ArrayList();

            /// <summary>
            /// Cached Select Alert Assigned To Flag
            /// </summary>
            private bool cachedAlertWithOwnerFlag = false;

            /// <summary>
            /// Cached Alert With Owner Values
            /// </summary>
            private ArrayList cachedAlertWithOwnerValues = new ArrayList();

            /// <summary>
            /// Cached Select Alert Raised by instance with specific name Flag
            /// </summary>
            private bool cachedAlertWithInstanceNameFlag = false;

            /// <summary>
            /// Cached Alert Raised by Instance Name Values
            /// </summary>
            private ArrayList cachedAlertWithInstanceNameValues = new ArrayList();

            /// <summary>
            /// Cached Select Alert Last modified by specific user Flag
            /// </summary>
            private bool cachedAlertModifiedByFlag = false;

            /// <summary>
            /// Cached Alert Raised by Instance Name Values
            /// </summary>
            private ArrayList cachedAlertModifiedByValues = new ArrayList();

            /// <summary>
            /// Cached Custom Alert Date and Time Control: Modified in a specific time period Flag
            /// </summary>
            private bool cachedDateAndTimeModifiedFlag = false;

            /// <summary>
            /// Cached Date and Time Created Values
            /// </summary>
            private ArrayList cachedDateAndTimeModifiedValues = new ArrayList();

            /// <summary>
            /// Cached Custom Alert Date and Time Control: Resolution Changed in a specific time period Flag
            /// </summary>
            private bool cachedDateAndTimeResolutionChangedFlag = false;

            /// <summary>
            /// Cached Date and Time Resolution Changed Values
            /// </summary>
            private ArrayList cachedDateAndTimeResolutionChangedValues = new ArrayList();

            /// <summary>
            /// Cached Custom Alert Date and Time Control: Closed in a specific time period Flag
            /// </summary>
            private bool cachedDateAndTimeClosedFlag = false;

            /// <summary>
            /// Cached Date and Time Closed Values
            /// </summary>
            private ArrayList cachedDateAndTimeClosedValues = new ArrayList();

            /// <summary>
            /// Cached Alert Control: Closed by Flag
            /// </summary>
            private bool cachedAlertClosedByFlag = false;

            /// <summary>
            /// Cached Alert Closed By Values
            /// </summary>
            private ArrayList cachedAlertClosedByValues = new ArrayList();

            /// <summary>
            /// Cached Alert Control: With Ticket Id Flag
            /// </summary>
            private bool cachedAlertWithTicketIdFlag = false;

            /// <summary>
            /// Cached Alert With Ticket Id Values
            /// </summary>
            private ArrayList cachedAlertWithTicketIdValues = new ArrayList();

            /// <summary>
            /// Cached Custom Alert Date and Time Control: Added To Database in a specific time period Flag
            /// </summary>
            private bool cachedDateAndTimeAddedToDatabaseFlag = false;

            /// <summary>
            /// Cached Date and Time Added To Database Values
            /// </summary>
            private ArrayList cachedDateAndTimeAddedToDatabaseValues = new ArrayList();

            /// <summary>
            /// Cached Alert Control: With Site Flag
            /// </summary>
            private bool cachedAlertWithSiteFlag = false;

            /// <summary>
            /// Cached Alert With Site Values
            /// </summary>
            private ArrayList cachedAlertWithSiteValues = new ArrayList();

            /// <summary>
            /// Cached Alert Control: With Custom Field Flag
            /// </summary>
            private bool cachedAlertWithCustomFieldFlag = false;

            /// <summary>
            /// Cached Alert With Custom Field Values
            /// </summary>
            private ArrayList cachedAlertWithCustomFieldValues = new ArrayList();


            #endregion

            #region Events View Criteria Private Members

            /// <summary>
            /// Cached Event Severity Flag
            /// </summary>
            private bool cachedEventRuleFlag = false;

            /// <summary>
            /// Cached Alert Severity items
            /// </summary>
            private ArrayList cachedEventRuleValues = new ArrayList();



            #endregion

            #region Task Status View Criteria Private Members

            /// <summary>
            /// Cached Status Specific Status Flag
            /// </summary>
            private bool cachedTaskSpecificStatusFlag = false;

            /// <summary>
            /// Cached Status Specific Status items
            /// </summary>
            private ArrayList cachedTaskSpecificStatusValues = new ArrayList();

            #endregion

            /// <summary>
            /// Cached Select Instances
            /// </summary>
            private ArrayList cachedSelectInstances = new ArrayList();

            #endregion

            #region Constructors
            /// <summary>
            /// Default Constructor - no need in ExePath etc. Inherited classes
            /// from Console set all required properties on parameter objects.
            /// </summary>
            public CreateViewParameters()
            {
            }
            #endregion

            #region Properties

            /// <summary>
            /// Space (Monitoring/My Workspace. Default is Monitoring)
            /// </summary>
            public NavigationPane.NavigationTreeView Space
            {
                get
                {
                    return this.cachedSpace;
                }

                set
                {
                    this.cachedSpace = value;
                }
            }
            /// <summary>
            /// StartPoint
            /// </summary>
            public StartPointEnum StartPoint
            {
                get
                {
                    return this.cachedStartPoint;
                }

                set
                {
                    this.cachedStartPoint = value;
                }
            }
            /// <summary>
            /// Name of the View to create
            /// </summary>
            public string Name
            {
                get
                {
                    return this.cachedName;
                }

                set
                {
                    this.cachedName = value;
                }
            }

            /// <summary>
            /// Description of View to create
            /// </summary>
            public string Description
            {
                get
                {
                    return this.cachedDescription;
                }

                set
                {
                    this.cachedDescription = value;
                }
            }

            /// <summary>
            /// Target of View to create
            /// </summary>
            public string Target
            {
                get
                {
                    return this.cachedTarget;
                }

                set
                {
                    this.cachedTarget = value;
                }
            }

            /// <summary>
            /// Folder Name 
            /// </summary>
            public string FolderName
            {
                get
                {
                    return this.cachedFolderName;
                }

                set
                {
                    this.cachedFolderName = value;
                }
            }

            #region Alert View Criteria Properties

            /// <summary>
            /// Alert Severity view criteria bit
            /// </summary>
            public bool AlertSeverityFlag
            {
                get
                {
                    return this.cachedAlertSeverityFlag;
                }

                set
                {
                    this.cachedAlertSeverityFlag = value;
                }
            }

            /// <summary>
            /// Alert Severity Type criteria of the View to create
            /// </summary>
            public ArrayList AlertSeverityValues
            {
                get
                {
                    return this.cachedAlertSeverityValues;
                }

                set
                {
                    this.AlertSeverityValues.Add(value);
                }
            }

            /// <summary>
            /// Alert Priority view criteria bit
            /// </summary>
            public bool AlertPriorityFlag
            {
                get
                {
                    return this.cachedAlertPriorityFlag;
                }

                set
                {
                    this.cachedAlertPriorityFlag = value;
                }
            }

            /// <summary>
            /// Alert Priority criteria of the View to create
            /// </summary>
            public ArrayList AlertPriorityValues
            {
                get
                {
                    return this.cachedAlertPriorityValues;
                }

                set
                {
                    this.cachedAlertPriorityValues.Add(value);
                }
            }

            /// <summary>
            /// Alert Sources view criteria bit
            /// </summary>
            public bool AlertSourcesFlag
            {
                get
                {
                    return this.cachedAlertSourcesFlag;
                }

                set
                {
                    this.cachedAlertSourcesFlag = value;
                }
            }

            /// <summary>
            /// Select All view criteria bit
            /// </summary>
            public bool SelectAllFlag
            {
                get
                {
                    return this.cachedSelectAllFlag;
                }

                set
                {
                    this.cachedSelectAllFlag = value;
                }
            }

            /// <summary>
            /// Alert Sources criteria of the View to create
            /// </summary>
            public ArrayList AlertSourcesValues
            {
                get
                {
                    return this.cachedAlertSourcesValues;
                }

                set
                {
                    this.cachedAlertSourcesValues.Add(value);
                }
            }

            /// <summary>
            /// Alert Resolution State view criteria bit
            /// </summary>
            public bool AlertResolutionStateFlag
            {
                get
                {
                    return this.cachedAlertResolutionStateFlag;
                }

                set
                {
                    this.cachedAlertResolutionStateFlag = value;
                }
            }

            /// <summary>
            /// Alert Resolution State criteria of the View to create
            /// </summary>
            public ArrayList AlertResolutionStateValues
            {
                get
                {
                    return this.cachedAlertResolutionStateValues;
                }

                set
                {
                    this.cachedAlertResolutionStateValues.Add(value);
                }
            }

            /// <summary>
            /// Only specified Alert Resolution State view criteria bit
            /// </summary>
            public bool OnlyAlertResolutionStateFlag
            {
                get
                {
                    return this.cachedOnlyAlertResolutionStateFlag;
                }

                set
                {
                    this.cachedOnlyAlertResolutionStateFlag = value;
                }
            }

            /// <summary>
            /// Alert Only specified Resolution State criteria of the View to create
            /// </summary>
            public ArrayList OnlyAlertResolutionStateValues
            {
                get
                {
                    return this.cachedOnlyAlertResolutionStateValues;
                }

                set
                {
                    this.cachedOnlyAlertResolutionStateValues.Add(value);
                }
            }

            /// <summary>
            /// Alert With Name view criteria bit
            /// </summary>
            public bool AlertWithNameFlag
            {
                get
                {
                    return this.cachedAlertWithNameFlag;
                }

                set
                {
                    this.cachedAlertWithNameFlag = value;
                }
            }

            /// <summary>
            /// Alert With Name criteria of the View to create
            /// </summary>
            public ArrayList AlertWithNameValues
            {
                get
                {
                    return this.cachedAlertWithNameValues;
                }

                set
                {
                    this.cachedAlertWithNameValues.Add(value);
                }
            }

            /// <summary>
            /// Alert With Description view criteria bit
            /// </summary>
            public bool AlertWithDescriptionFlag
            {
                get
                {
                    return this.cachedAlertWithDescriptionFlag;
                }

                set
                {
                    this.cachedAlertWithDescriptionFlag = value;
                }
            }

            /// <summary>
            /// Alert With Description criteria of the View to create
            /// </summary>
            public ArrayList AlertWithDescriptionValues
            {
                get
                {
                    return this.cachedAlertWithDescriptionValues;
                }

                set
                {
                    this.cachedAlertWithDescriptionValues.Add(value);
                }
            }

            /// <summary>
            /// Date and Time Control: Created in a specific time period Flag view criteria bit
            /// </summary>
            public bool DateAndTimeCreatedFlag
            {
                get
                {
                    return this.cachedDateAndTimeCreatedFlag;
                }

                set
                {
                    this.cachedDateAndTimeCreatedFlag = value;
                }
            }

            /// <summary>
            /// Date and Time Created Values of the View to create
            /// </summary>
            public ArrayList DateAndTimeCreatedValues
            {
                get
                {
                    return this.cachedDateAndTimeCreatedValues;
                }

                set
                {
                    this.cachedDateAndTimeCreatedValues.Add(value);
                }
            }

            /// <summary>
            /// Select Alert Assigned To view criteria bit
            /// </summary>
            public bool AlertWithOwnerFlag
            {
                get
                {
                    return this.cachedAlertWithOwnerFlag;
                }

                set
                {
                    this.cachedAlertWithOwnerFlag = value;
                }
            }

            /// <summary>
            /// Alert Alert With Owner criteria of the View to create
            /// </summary>
            public ArrayList AlertWithOwnerValues
            {
                get
                {
                    return this.cachedAlertWithOwnerValues;
                }

                set
                {
                    this.cachedAlertWithOwnerValues.Add(value);
                }
            }

            /// <summary>
            /// Select Alert Raised by instance with specific name view criteria bit
            /// </summary>
            public bool AlertWithInstanceNameFlag
            {
                get
                {
                    return this.cachedAlertWithInstanceNameFlag;
                }

                set
                {
                    this.cachedAlertWithInstanceNameFlag = value;
                }
            }

            /// <summary>
            /// Alert Raised by Instance Name criteria of the View to create
            /// </summary>
            public ArrayList AlertWithInstanceNameValues
            {
                get
                {
                    return this.cachedAlertWithInstanceNameValues;
                }

                set
                {
                    this.cachedAlertWithInstanceNameValues.Add(value);
                }
            }

            /// <summary>
            /// Select Alert Last modified by specific user view criteria bit
            /// </summary>
            public bool AlertModifiedByFlag
            {
                get
                {
                    return this.cachedAlertModifiedByFlag;
                }

                set
                {
                    this.cachedAlertModifiedByFlag = value;
                }
            }

            /// <summary>
            /// Alert Last modified by specific user criteria of the View to create
            /// </summary>
            public ArrayList AlertModifiedByValues
            {
                get
                {
                    return this.cachedAlertModifiedByValues;
                }

                set
                {
                    this.cachedAlertModifiedByValues.Add(value);
                }
            }

            /// <summary>
            /// Date and Time Control: Modified in a specific time period view criteria bit
            /// </summary>
            public bool DateAndTimeModifiedFlag
            {
                get
                {
                    return this.cachedDateAndTimeModifiedFlag;
                }

                set
                {
                    this.cachedDateAndTimeModifiedFlag = value;
                }
            }

            /// <summary>
            /// Date and Time Modified in a specific time period Values of the View to create
            /// </summary>
            public ArrayList DateAndTimeModifiedValues
            {
                get
                {
                    return this.cachedDateAndTimeModifiedValues;
                }

                set
                {
                    this.cachedDateAndTimeModifiedValues.Add(value);
                }
            }

            /// <summary>
            /// Date and Time Control: Resolution Changed in a specific time period view criteria bit
            /// </summary>
            public bool DateAndTimeResolutionChangedFlag
            {
                get
                {
                    return this.cachedDateAndTimeResolutionChangedFlag;
                }

                set
                {
                    this.cachedDateAndTimeResolutionChangedFlag = value;
                }
            }

            /// <summary>
            /// Date and Time: Resolution Changed in a specific time period Values of the View to create
            /// </summary>
            public ArrayList DateAndTimeResolutionChangedValues
            {
                get
                {
                    return this.cachedDateAndTimeResolutionChangedValues;
                }

                set
                {
                    this.cachedDateAndTimeResolutionChangedValues.Add(value);
                }
            }

            /// <summary>
            /// Date and Time Control: Closed in a specific time period view criteria bit
            /// </summary>
            public bool DateAndTimeClosedFlag
            {
                get
                {
                    return this.cachedDateAndTimeClosedFlag;
                }

                set
                {
                    this.cachedDateAndTimeClosedFlag = value;
                }
            }

            /// <summary>
            /// Date and Time: Closed in a specific time period Values of the View to create
            /// </summary>
            public ArrayList DateAndTimeClosedValues
            {
                get
                {
                    return this.cachedDateAndTimeClosedValues;
                }

                set
                {
                    this.cachedDateAndTimeClosedValues.Add(value);
                }
            }

            /// <summary>
            /// Select Alert Closed by specific user view criteria bit
            /// </summary>
            public bool AlertClosedByFlag
            {
                get
                {
                    return this.cachedAlertClosedByFlag;
                }

                set
                {
                    this.cachedAlertClosedByFlag = value;
                }
            }

            /// <summary>
            /// Alert Closed by specific user criteria of the View to create
            /// </summary>
            public ArrayList AlertClosedByValues
            {
                get
                {
                    return this.cachedAlertClosedByValues;
                }

                set
                {
                    this.cachedAlertClosedByValues.Add(value);
                }
            }

            /// <summary>
            /// Select Alert With Ticket Id view criteria bit
            /// </summary>
            public bool AlertWithTicketIdFlag
            {
                get
                {
                    return this.cachedAlertWithTicketIdFlag;
                }

                set
                {
                    this.cachedAlertWithTicketIdFlag = value;
                }
            }

            /// <summary>
            /// Alert With Ticket Id criteria of the View to create
            /// </summary>
            public ArrayList AlertWithTicketIdValues
            {
                get
                {
                    return this.cachedAlertWithTicketIdValues;
                }

                set
                {
                    this.cachedAlertWithTicketIdValues.Add(value);
                }
            }

            /// <summary>
            /// Date and Time Control: Added To Database in a specific time period view criteria bit
            /// </summary>
            public bool DateAndTimeAddedToDatabaseFlag
            {
                get
                {
                    return this.cachedDateAndTimeAddedToDatabaseFlag;
                }

                set
                {
                    this.cachedDateAndTimeAddedToDatabaseFlag = value;
                }
            }

            /// <summary>
            /// Date and Time: Added To Database in a specific time period Values of the View to create
            /// </summary>
            public ArrayList DateAndTimeAddedToDatabaseValues
            {
                get
                {
                    return this.cachedDateAndTimeAddedToDatabaseValues;
                }

                set
                {
                    this.cachedDateAndTimeAddedToDatabaseValues.Add(value);
                }
            }

            /// <summary>
            /// Select Alert With Site view criteria bit
            /// </summary>
            public bool AlertWithSiteFlag
            {
                get
                {
                    return this.cachedAlertWithSiteFlag;
                }

                set
                {
                    this.cachedAlertWithSiteFlag = value;
                }
            }

            /// <summary>
            /// Alert With Site criteria of the View to create
            /// </summary>
            public ArrayList AlertWithSiteValues
            {
                get
                {
                    return this.cachedAlertWithSiteValues;
                }

                set
                {
                    this.cachedAlertWithSiteValues.Add(value);
                }
            }

            /// <summary>
            /// Select Alert With Custom Field view criteria bit
            /// </summary>
            public bool AlertWithCustomFieldFlag
            {
                get
                {
                    return this.cachedAlertWithCustomFieldFlag;
                }

                set
                {
                    this.cachedAlertWithCustomFieldFlag = value;
                }
            }

            /// <summary>
            /// Alert With Custom Field criteria of the View to create
            /// </summary>
            public ArrayList AlertWithCustomFieldValues
            {
                get
                {
                    return this.cachedAlertWithCustomFieldValues;
                }

                set
                {
                    this.cachedAlertWithCustomFieldValues.Add(value);
                }
            }

            #endregion

            #region Event View Criteria Properties

            /// <summary>
            /// Event Rule flag view criteria bit
            /// </summary>
            public bool EventRuleFlag
            {
                get
                {
                    return this.cachedEventRuleFlag;
                }

                set
                {
                    this.cachedEventRuleFlag = value;
                }
            }

            /// <summary>
            /// Event Rule criteria of the View to create
            /// </summary>
            public ArrayList EventRuleValues
            {
                get
                {
                    return this.cachedEventRuleValues;
                }

                set
                {
                    this.EventRuleValues.Add(value);
                }
            }

            #endregion

            #region Task Status View Criteria Properties

            /// <summary>
            /// Specific Status flag view criteria bit
            /// </summary>
            public bool TaskSpecificStatusFlag
            {
                get
                {
                    return this.cachedTaskSpecificStatusFlag;
                }

                set
                {
                    this.cachedTaskSpecificStatusFlag = value;
                }
            }

            /// <summary>
            /// Event Rule criteria of the View to create
            /// </summary>
            public ArrayList TaskSpecificStatusValues
            {
                get
                {
                    return this.cachedTaskSpecificStatusValues;
                }

                set
                {
                    this.cachedTaskSpecificStatusValues.Add(value);
                }
            }

            #endregion

            /// <summary>
            /// SelectInstances
            /// </summary>
            public ArrayList SelectInstances
            {
                get
                {
                    return this.cachedSelectInstances;
                }

                set
                {
                    this.cachedSelectInstances.Add(value);
                }
            }

            #endregion
        }
        #endregion

        #region PersonalizeView Classes

        /// <summary>
        /// Class that stores the PersonalizeViewDialogSettings, used to set the PersonalizeDialog
        /// </summary>
        public class PersonalizeViewDialogSettings
        {

            #region memberVariables

            /// <summary>
            /// Columns that are displayed in the view by default
            /// </summary>
            private List<string> displayColumns = new List<string>();

            /// <summary>
            /// Stores the sorted list of sortable columns
            /// </summary>
            private List<string> cachedSortedDisplayColumns = new List<string>();

            /// <summary>
            /// The column that the view will be sorted by
            /// </summary>
            private string sortColumnsBy;

            /// <summary>
            /// The state of the ascending sort button
            /// </summary>
            private ButtonState sortColumnsByOrderAsc;

            /// <summary>
            /// The state of the descending sort button
            /// </summary>
            private ButtonState sortColumnsByOrderDesc;

            /// <summary>
            /// The first item the view is grouped by
            /// </summary>
            private string firstGroupItem;

            /// <summary>
            /// The button state of the first group order ascending button
            /// </summary>
            private ButtonState firstGroupOrderAsc;

            /// <summary>
            /// The button state of the first group order descending button
            /// </summary>
            private ButtonState firstGroupOrderDesc;

            /// <summary>
            /// The second item the view is grouped by
            /// </summary>
            private string secondGroupItem;

            /// <summary>
            /// The button state of the second group order ascending button
            /// </summary>
            private ButtonState secondGroupOrderAsc;

            /// <summary>
            /// The button state of the second group order descending button
            /// </summary>
            private ButtonState secondGroupOrderDesc;

            /// <summary>
            /// The third item the view is grouped by
            /// </summary>
            private string thirdGroupItem;

            /// <summary>
            /// The button state of the third group order ascending button
            /// </summary>
            private ButtonState thirdGroupOrderAsc;

            /// <summary>
            /// The button state of the third group order descending button
            /// </summary>
            private ButtonState thirdGroupOrderDesc;

            /// <summary>
            /// This stores the columns that are "sortable" this will be the columns contained inside the "Sort columns by" listbox
            /// </summary>
            private List<string> sortableColumns = new List<string>();

            #endregion

            /// <summary>
            /// Constructor, initializes all values
            /// </summary>
            public PersonalizeViewDialogSettings()
            {
                // this.columnsToDisplay = new ArrayList();
                // this.sortedColumnsToDisplay = null;
                this.cachedSortedDisplayColumns = null;

                this.sortColumnsBy = null;
                this.sortColumnsByOrderAsc = ButtonState.UnChecked;
                this.sortColumnsByOrderDesc = ButtonState.Checked;

                this.firstGroupItem = null;
                this.firstGroupOrderAsc = ButtonState.UnChecked;
                this.firstGroupOrderDesc = ButtonState.Checked;

                this.secondGroupItem = null;
                this.secondGroupOrderAsc = ButtonState.UnChecked;
                this.secondGroupOrderDesc = ButtonState.Checked;

                this.thirdGroupItem = null;
                this.thirdGroupOrderAsc = ButtonState.UnChecked;
                this.thirdGroupOrderDesc = ButtonState.Checked;
            }

            /// <summary>
            /// Represents the sort type Ascending, Descending used in Personalization
            /// </summary>
            public enum SortType
            {
                /// <summary>
                /// Ascending Sort
                /// </summary>
                Ascending = 1,
                /// <summary>
                /// Descending Sort
                /// </summary>
                Descending = 2
            }

            /// <summary>
            /// Sets the default columns to display
            /// </summary>
            /// <param name="columnsToDisplay">ArrayList of strings, of the columns to display</param>
            public void SetColumnsToDisplay(List<string> columnsToDisplay)
            {
                this.displayColumns = new List<string>(columnsToDisplay);
                if (this.displayColumns.Count < 1)
                {
                    throw new ApplicationException("Cannot have less then 1 column set");
                }
            }

            /// <summary>
            /// Adds to a column to the default columns to display
            /// </summary>
            /// <param name="columnName">Display Column to add</param>
            public void AddDisplayColumn(string columnName)
            {
                this.displayColumns.Add(columnName);
            }

            /// <summary>
            /// Clears the list that stores the default display columns
            /// </summary>
            public void ClearDefaultDisplayColumn()
            {
                this.displayColumns.Clear();
            }

            /// <summary>
            /// Set the column to sort, and sort type ascending / descending
            /// </summary>
            /// <param name="item">Column Name</param>
            /// <param name="ascending">Ascending ButtonState</param>
            /// <param name="descending">Descending ButtonState</param>
            public void SetSortColumnsBy(string item, ButtonState ascending, ButtonState descending)
            {
                this.sortColumnsBy = item;
                this.sortColumnsByOrderAsc = ascending;
                this.sortColumnsByOrderDesc = descending;
            }

            /// <summary>
            /// Sets the column to sort, and the sort type ascending / descending
            /// </summary>
            /// <param name="item">Column to sort</param>
            /// <param name="sortType">Sort type ascending / descending</param>
            public void SetSortColumnsBy(string item, SortType sortType)
            {
                this.sortColumnsBy = item;
                if (sortType == SortType.Ascending)
                {
                    this.sortColumnsByOrderAsc = ButtonState.Checked;
                    this.sortColumnsByOrderDesc = ButtonState.UnChecked;
                }
                else
                {
                    this.sortColumnsByOrderAsc = ButtonState.UnChecked;
                    this.sortColumnsByOrderDesc = ButtonState.Checked;
                }
            }

            /// <summary>
            /// Set the column for the first group, and sort type ascending / descending
            /// </summary>
            /// <param name="item">Column Name</param>
            /// <param name="ascending">Ascending ButtonState</param>
            /// <param name="descending">Descending ButtonState</param>
            public void SetFirstGroupBy(string item, ButtonState ascending, ButtonState descending)
            {
                this.firstGroupItem = item;
                this.firstGroupOrderAsc = ascending;
                this.firstGroupOrderDesc = descending;
            }

            /// <summary>
            /// Sets the first group by, and the sort type ascending / descending
            /// </summary>
            /// <param name="item">Column Name of the First Group By Combo Box</param>
            /// <param name="sortType">SortType of the Column</param>
            public void SetFirstGroupBy(string item, SortType sortType)
            {
                this.firstGroupItem = item;
                if (sortType == SortType.Ascending)
                {
                    this.firstGroupOrderAsc = ButtonState.Checked;
                    this.firstGroupOrderDesc = ButtonState.UnChecked;
                }
                else
                {
                    this.firstGroupOrderAsc = ButtonState.UnChecked;
                    this.firstGroupOrderDesc = ButtonState.Checked;
                }
            }

            /// <summary>
            /// Set the column for the second group, and sort type ascending / descending
            /// </summary>
            /// <param name="item">Column Name</param>
            /// <param name="ascending">Ascending ButtonState</param>
            /// <param name="descending">Descending ButtonState</param>
            public void SetSecondGroupBy(string item, ButtonState ascending, ButtonState descending)
            {
                this.secondGroupItem = item;
                this.secondGroupOrderAsc = ascending;
                this.secondGroupOrderDesc = descending;
            }

            /// <summary>
            /// Sets the second group by, and the sort type ascending / descending
            /// </summary>
            /// <param name="item">Column Name of the Second Group By ComboBox</param>
            /// <param name="sortType">SortType of the Column</param>
            public void SetSecondGroupBy(string item, SortType sortType)
            {
                this.secondGroupItem = item;
                if (sortType == SortType.Ascending)
                {
                    this.secondGroupOrderAsc = ButtonState.Checked;
                    this.secondGroupOrderDesc = ButtonState.UnChecked;
                }
                else
                {
                    this.secondGroupOrderAsc = ButtonState.UnChecked;
                    this.secondGroupOrderDesc = ButtonState.Checked;
                }
            }

            /// <summary>
            /// Set the column for the third group, and sort type ascending / descending
            /// </summary>
            /// <param name="item">Column Name</param>
            /// <param name="ascending">Ascending ButtonState</param>
            /// <param name="descending">Descending ButtonState</param>
            public void SetThirdGroupBy(string item, ButtonState ascending, ButtonState descending)
            {
                this.thirdGroupItem = item;
                this.thirdGroupOrderAsc = ascending;
                this.thirdGroupOrderDesc = descending;
            }

            /// <summary>
            /// Sets the second group by, and the sort type ascending / descending
            /// </summary>
            /// <param name="item">Column Name to set Third Group</param>
            /// <param name="sortType">SortType of the Column</param>
            public void SetThirdGroupBy(string item, SortType sortType)
            {
                this.thirdGroupItem = item;
                if (sortType == SortType.Ascending)
                {
                    this.thirdGroupOrderAsc = ButtonState.Checked;
                    this.thirdGroupOrderDesc = ButtonState.UnChecked;
                }
                else
                {
                    this.thirdGroupOrderAsc = ButtonState.UnChecked;
                    this.thirdGroupOrderDesc = ButtonState.Checked;
                }
            }

            /// <summary>
            /// Returns an array list of the columns to display
            /// </summary>
            /// <returns>ArrayList of columns to display</returns>
            public List<string> GetColumnsToDisplay()
            {
                // return this.columnsToDisplay;
                return this.displayColumns;
            }

            /// <summary>
            /// Gets the sorted ArrayList of columns that are "sortable"
            /// </summary>
            /// <returns>Returns an sorted ArrayList of the "sortable" columns</returns>
            public List<string> GetSortedDisplayColumns()
            {
                // If null, the list has not yet been sorted so sort it
                if (this.cachedSortedDisplayColumns == null)
                {
                    this.cachedSortedDisplayColumns = new List<string>(this.displayColumns);
                    this.cachedSortedDisplayColumns.Sort();
                }

                return this.cachedSortedDisplayColumns;
            }

            /// <summary>
            /// Gets the current column the view is sorted by
            /// </summary>
            /// <returns>Current column the view is sorted by</returns>
            public string GetSortColumnsBy()
            {
                return this.sortColumnsBy;
            }

            /// <summary>
            /// Gets the button state of the sorted column ascending button
            /// </summary>
            /// <returns>ButtonState of the sorted column ascending button</returns>
            public ButtonState GetSortColumnsByAsc()
            {
                return this.sortColumnsByOrderAsc;
            }

            /// <summary>
            /// Gets the views first group column
            /// </summary>
            /// <returns>String of views first group column</returns>
            public string GetFirstGroupBy()
            {
                return this.firstGroupItem;
            }

            /// <summary>
            /// Gets the button state first group by column ascending button
            /// </summary>
            /// <returns>ButtonState of the first group by column ascending button</returns>
            public ButtonState GetFirstGroupByAsc()
            {
                return this.firstGroupOrderAsc;
            }

            /// <summary>
            /// Gets the views second group column
            /// </summary>
            /// <returns>String of views second group column</returns>
            public string GetSecondGroupBy()
            {
                return this.secondGroupItem;
            }

            /// <summary>
            /// Gets the button state second group by column ascending button
            /// </summary>
            /// <returns>ButtonState of the second group by column ascending button</returns>
            public ButtonState GetSecondGroupByAsc()
            {
                return this.secondGroupOrderAsc;
            }

            /// <summary>
            /// Gets the views third group column
            /// </summary>
            /// <returns>String of views third group column</returns>
            public string GetThirdGroupBy()
            {
                return this.thirdGroupItem;
            }

            /// <summary>
            /// Gets the button state third group by column ascending button
            /// </summary>
            /// <returns>ButtonState of the third group by column ascending button</returns>
            public ButtonState GetThirdGroupByAsc()
            {
                return this.thirdGroupOrderAsc;
            }

            /// <summary>
            /// Checks if the column is a sortable column, if sortable returns true, else false
            /// </summary>
            /// <param name="columnName">Column Name to check sortable property</param>
            /// <returns>True if sortable, false if not</returns>
            public bool IsSortableColumn(string columnName)
            {
                int indexOfColumn = this.sortableColumns.IndexOf(columnName);
                if (indexOfColumn < 0)
                {
                    return false;
                }

                return true;
            }

            /// <summary>
            /// Adds a column that is sortable to the sortable column collection
            /// </summary>
            /// <param name="columnName">column name to add to the collection of sortable columns</param>
            public void AddSortableColumn(string columnName)
            {
                this.sortableColumns.Add(columnName);
            }
        }

        /// <summary>
        /// PersonalizeView class contains the test methods to test personal view against the personal view settings
        /// </summary>
        public class PersonalizeView
        {
            /// <summary>
            /// This is used to store strings that are equivalent to one another there is only one I found Success == Succeeded
            /// </summary>
            private static Dictionary<string, List<string>> equivalentStrings =
               new Dictionary<string, List<string>>();

            /// <summary>
            /// Personalize view dialog settings
            /// </summary>
            private Mom.Test.UI.Core.Console.Views.Views.PersonalizeViewDialogSettings personalizeViewDialogSettings;
            
            /// <summary>
            /// View path
            /// </summary>
            private string viewPath;

            /// <summary>
            /// PersonalizeView Constructor
            /// </summary>
            /// <param name="personalizeViewDialogSettings">Personalize view dialog settings</param>
            /// <param name="viewPath">Path to the Grid View of the personalized grid view eg: Core.Console.Views.Views.Strings.TasksStatusView for Task Status View</param>
            public PersonalizeView(Mom.Test.UI.Core.Console.Views.Views.PersonalizeViewDialogSettings personalizeViewDialogSettings, string viewPath) // TODO: make this viewPath an enum
            {
                // TODO: remove this, it's so I know the dll is the correct version
                Utilities.LogMessage("PersonalizeView:: Version 17");

                this.personalizeViewDialogSettings = personalizeViewDialogSettings;
                this.viewPath = viewPath;

                // Used to store strings that are equivalent
                equivalentStrings.Add("succeeded", new List<string>(new string[] { "success", "succeeded" }));
                equivalentStrings.Add("success", new List<string>(new string[] { "success", "succeeded" }));
            }

            /// <summary>
            /// Checks that the Column Headers are all being displayed
            /// </summary>
            public void CheckColumnHeaders()
            {
                try
                {
                    List<string> displayColumns = this.personalizeViewDialogSettings.GetColumnsToDisplay();

                    Utilities.LogMessage("CheckColumnHeaders:: Checking that column headers match what is selected in personal view");
                    Utilities.TakeScreenshot("CheckColumnHeaders - checking column headers match");
                    DataGridViewHeaderCollection headerRow = CoreManager.MomConsole.ViewPane.Grid.ColumnHeaders;
                    foreach (DataGridViewHeader header in headerRow)
                    {
                        if (displayColumns.Contains((string)header.Name))
                        {
                            Utilities.LogMessage("CheckColumnHeaders:: Column: '" + header.Name + "' Exists");
                            displayColumns.Remove((string)header.Name);
                        }
                    }

                    // The columsn left over are the columns that are not appearing in the grid view
                    if (displayColumns.Count != 0)
                    {
                        Utilities.LogMessage("CheckColumnHeaders:: Some of the columns are not appearing in the display");
                        foreach (string missingColumn in displayColumns)
                        {
                            Utilities.LogMessage("CheckColumnHeaders:: Column '" + missingColumn + "' is missing from the display");
                        }

                        Utilities.TakeScreenshot("CheckColumnHeaders - Columns are missing from the display");
                        throw new Exception("Column headers that are selected are missing from the display");
                    }
                }
                catch (ApplicationException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            /// <summary>
            /// Checks the sorting of each column, a simple check is done that simply verifies if the begining element becomes the last element
            /// and vice versa when the column header is clicked of a sortable field.
            /// </summary>
            public void CheckColumnSorting()
            {
                // List<DataGridCell> listColumnHeaders = new List<DataGridCell>();
                string firstRowValueBeforeSort = String.Empty;
                string lastRowValueBeforeSort = String.Empty;
                string firstRowValueAfterSort = String.Empty;
                string lastRowValueAfterSort = String.Empty;

                try
                {
                    Utilities.LogMessage("CheckColumnSorting:: Checking columns sort correctly");
                    DataGridViewHeaderCollection collectionColumnHeaderCells = CoreManager.MomConsole.ViewPane.Grid.ColumnHeaders;
                    int columnNumber = 0;

                    // Loop through each Column changing the sort
                    foreach (DataGridViewHeader header in collectionColumnHeaderCells)
                    {
                        // Only test sortable columns on columns that are sortable
                        if (this.personalizeViewDialogSettings.IsSortableColumn(header.Name))
                        {
                            // Initialize the sort on the header
                            header.AccessibleObject.Click();
                            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);

                            Utilities.LogMessage("CheckColumnSorting:: Checking column '" + header.Name + "'");
                            int lastRowNumber = CoreManager.MomConsole.ViewPane.Grid.Rows.Count;
                            firstRowValueBeforeSort = CoreManager.MomConsole.ViewPane.Grid.Rows[1].Cells[columnNumber].GetValue();
                            lastRowValueBeforeSort = CoreManager.MomConsole.ViewPane.Grid.Rows[lastRowNumber - 1].Cells[columnNumber].GetValue();

                            // Click the Header Cell to Sort the Column to invert the ascending / descending sorting
                            Utilities.TakeScreenshot("CheckColumnSorting - Before clicking header " + header.Name);
                            header.AccessibleObject.Click();
                            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);

                            Utilities.TakeScreenshot("CheckColumnSorting - After clicking header " + header.Name);
                            firstRowValueAfterSort = CoreManager.MomConsole.ViewPane.Grid.Rows[1].Cells[columnNumber].GetValue();
                            lastRowValueAfterSort = CoreManager.MomConsole.ViewPane.Grid.Rows[lastRowNumber - 1].Cells[columnNumber].GetValue();
                            Utilities.LogMessage("CheckColumnSorting:: First Row Before Sorting " + firstRowValueBeforeSort + " : After Sorting " + firstRowValueAfterSort);
                            Utilities.LogMessage("CheckColumnSorting:: First Row Before Sorting " + lastRowValueBeforeSort + " : After Sorting " + lastRowValueAfterSort);

                            if ((firstRowValueBeforeSort != lastRowValueAfterSort) || (lastRowValueBeforeSort != firstRowValueAfterSort))
                            {
                                Utilities.TakeScreenshot("CheckColumnSorting - sort failed on column");
                                throw new Exception("Sort failed on column: " + header.Name);
                            }

                            // Now try sorting the opposite way
                            Utilities.LogMessage("CheckColumnSorting:: Checking column " + header.Name);

                            firstRowValueBeforeSort = CoreManager.MomConsole.ViewPane.Grid.Rows[1].Cells[columnNumber].GetValue();
                            lastRowValueBeforeSort = CoreManager.MomConsole.ViewPane.Grid.Rows[lastRowNumber - 1].Cells[columnNumber].GetValue();

                            // Click the Header Cell to Sort the Column to invert the ascending / descending sorting
                            Utilities.TakeScreenshot("CheckColumnSorting - Before clicking header " + header.Name);
                            header.AccessibleObject.Click();
                            CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);
                            Utilities.TakeScreenshot("CheckColumnSorting - After clicking header " + header.Name);
                            firstRowValueAfterSort = CoreManager.MomConsole.ViewPane.Grid.Rows[1].Cells[columnNumber].GetValue();
                            lastRowValueAfterSort = CoreManager.MomConsole.ViewPane.Grid.Rows[lastRowNumber - 1].Cells[columnNumber].GetValue();
                            Utilities.LogMessage("CheckColumnSorting:: First Row Before Sorting " + firstRowValueBeforeSort + " : After Sorting " + firstRowValueAfterSort);
                            Utilities.LogMessage("CheckColumnSorting:: First Row Before Sorting " + lastRowValueBeforeSort + " : After Sorting " + lastRowValueAfterSort);

                            if ((firstRowValueBeforeSort != lastRowValueAfterSort) || (lastRowValueBeforeSort != firstRowValueAfterSort))
                            {
                                Utilities.TakeScreenshot("CheckColumnSorting - sort failed on column");
                                throw new Exception("Sort failed on column: " + header.Name);
                            }
                        }
                        else
                        {
                            Utilities.LogMessage("CheckColumnSorting:: Column " + header.Name + " is not sortable");
                        }

                        ++columnNumber;
                    }
                }
                catch (ApplicationException)
                {
                    throw;
                }
                catch (Exception exception)
                {
                    throw new Exception("Check column sorting failed Exception : " + exception);
                }
            }

            /// <summary>
            /// Removes All the grouping / sorting. Also sets the columns to display back to original settings
            /// </summary>
            public void RemoveAllGroupingSorting()
            {
                Utilities.LogMessage("RemoveAllGroupingSorting:: Removing all grouping and sorting");
                try
                {
                    Utilities.LogMessage("RemoveAllGroupingSorting:: Removing all the grouping and sorting criteria");

                    // Create new personal view dialog class (used to interface with the settings and apply options to personalize view dialog)
                    Mom.Test.UI.Core.Console.Views.Views.PersonalizeViewDialogHelper personalViewDialog
                        = new Mom.Test.UI.Core.Console.Views.Views.PersonalizeViewDialogHelper(Core.Console.Views.Views.Strings.TaskStatusView);

                    #region Personalize View No Grouping Settings

                    // Create the settings object, that will contain the settings to remove all the groupings
                    Mom.Test.UI.Core.Console.Views.Views.PersonalizeViewDialogSettings personalViewNoGroupingSettings
                        = new Mom.Test.UI.Core.Console.Views.Views.PersonalizeViewDialogSettings();

                    // Log the columns we are setting to display
                    foreach (string columnName in this.personalizeViewDialogSettings.GetColumnsToDisplay())
                    {
                        Utilities.LogMessage("RemoveAllGroupingSorting:: Column to display: " + columnName);
                    }

                    // Set the columns to display
                    personalViewNoGroupingSettings.SetColumnsToDisplay(this.personalizeViewDialogSettings.GetColumnsToDisplay());

                    // Log what the (None) option is encoded as 
                    Utilities.LogMessage("RemoveAllGroupingSorting:: (None) option is encoded as " + Strings.ColumnComboNone);

                    // Set the sort columns by
                    personalViewNoGroupingSettings.SetSortColumnsBy(Strings.ColumnComboNone, ButtonState.UnChecked, ButtonState.Checked);

                    // Set the First Group by
                    personalViewNoGroupingSettings.SetFirstGroupBy(Strings.ColumnComboNone, ButtonState.UnChecked, ButtonState.Checked);

                    #endregion

                    // Apply the above settings to the personalization dialog box
                    personalViewDialog.SetPersonalizeViewDialogOptions(personalViewNoGroupingSettings);
                    Utilities.TakeScreenshot("RemoveAllGroupingSorting - View after removing all grouping and sorting");
                }
                catch (Exception exception)
                {
                    Utilities.TakeScreenshot("RemoveAllGroupingSorting - Failed");
                    throw new ApplicationException("RemoveAllGroupingSorting - Abort exception thrown " + exception);
                }
            }

            /// <summary>
            /// Checks that the Grouping is functioning correctly (doesn't check sorting just grouping) make sure the all the data 
            /// that is present in the ungrouped view, is showing up in the grouped view under the correct grouping headers.
            /// </summary>
            public void CheckGrouping()
            {
                // Stores the ungrouped DataTable
                DataTable ungrpDataTable;

                // Stores Grouped DataTable 
                DataTable grpDataTable;
                try
                {
                    int retry = 0;
                    int maxcount = 3;
                    bool equalTable = false;
                    while (!equalTable && retry <= maxcount)
                    {
                        DataRow dataRow;
                        grpDataTable = new DataTable("groupedTable");
                        ungrpDataTable = new DataTable("ungroupedTable");
                        Utilities.LogMessage("CheckGrouping:: Enter CheckGrouping");

                        // Set the personalize settings of the Personalize view dialog
                        Mom.Test.UI.Core.Console.Views.Views.PersonalizeViewDialogHelper personalViewDialog = new Mom.Test.UI.Core.Console.Views.Views.PersonalizeViewDialogHelper(Core.Console.Views.Views.Strings.TaskStatusView);

                        // Personalize the view remove ALL Grouping settings (used as basis for test of grouping)
                        this.RemoveAllGroupingSorting();

                        #region Construct Ungrouped table

                        Utilities.LogMessage("CheckGrouping:: Constructing UnGrouped Table");

                        int rowNum = -1;
                        int col = -1;

                        // Construct the ungrouped data table that will be used as a basis for camparision with the grouped table
                        Core.Console.MomControls.GridControl ungroupedGrid =
                            CoreManager.MomConsole.ViewPane.Grid;

                        // foreach (DataGridViewRow dgvr in CoreManager.MomConsole.ViewPane.Grid.Rows)
                        foreach (DataGridViewRow dgvr in ungroupedGrid.Rows)
                        {
                            ++rowNum;
                            if (rowNum != 0) // Ignore the first row (field headers)
                            {
                                col = -1; // Initialize the column 
                                //Comment out the below line, because it slows the performance
                                //Utilities.LogMessage("CheckGrouping:: State of row = " + dgvr.AccessibleObject.StateText);

                                // None of the rows should be groups, if so throw an exception 
                                if ((!dgvr.AccessibleObject.StateText.Contains(MsaaResources.Strings.Collapsed)) && (!dgvr.AccessibleObject.StateText.Contains(MsaaResources.Strings.Expanded)))
                                {
                                    // We need to add a new tableRow
                                    dataRow = ungrpDataTable.NewRow();
                                    string rowText = null;
                                    foreach (DataGridViewCell dgvc in dgvr.Cells)
                                    {
                                        ++col; // Increment the current column we are on

                                        // Ignore the last blank row
                                        //if (CoreManager.MomConsole.ViewPane.Grid.ColumnHeaders[col].Name.Trim() != "")
                                        if (ungroupedGrid.ColumnHeaders[col].Name.Trim() != "")
                                        {
                                            string colName = ungroupedGrid.ColumnHeaders[col].Name;
                                            string colValue = dgvc.GetValue();

                                            // If the column name does not exist, add it
                                            if (!ungrpDataTable.Columns.Contains(colName))
                                            {
                                                ungrpDataTable.Columns.Add(new DataColumn(colName));
                                            }

                                            rowText = rowText + colName + ":" + colValue + ";";
                                            //Utilities.LogMessage("CheckGrouping:: Ungrouped Table - Adding Column : '" + colName + "' value '" + colValue + "'");
                                            dataRow[colName] = colValue;
                                        }
                                    }
                                    Utilities.LogMessage("CheckGrouping:: Ungrouped Table - " + rowText);
                                    ungrpDataTable.Rows.Add(dataRow);
                                }
                                else
                                {
                                    throw new ApplicationException("CheckGrouping - the GridView contained groups, which it should not");
                                }
                            } // if(row != 0)
                        } // foreach (DataGridViewRow dgvr in CoreManager.MomConsole.ViewPane.Grid.Rows)

                        #endregion

                        Utilities.TakeScreenshot("CheckGrouping - Ungrouped Table");

                        // ************************************************************************************************
                        //
                        //                   Personalize view the sorting / grouping requested
                        //
                        // ************************************************************************************************

                        // Put the grouping back to the Personalize view settings we are testing ( we removed all grouping above for our basis for this test )
                        personalViewDialog.SetPersonalizeViewDialogOptions(this.personalizeViewDialogSettings);
                        ArrayList lstGroupByFields = new ArrayList();   // Used to store all the groupByFields
                        ArrayList lstGroupByValues = new ArrayList();   // Used to store all the groupByValues
                        ArrayList groupedTables = new ArrayList();      // Used to store the Grouped Tables

                        // Initialize the row/col now we are going to traverse the grid row by row
                        rowNum = -1;
                        col = -1;

                        #region Construct the grouped table

                        Utilities.LogMessage("CheckGrouping:: Constructing Grouped table");

                        // Construct the grouped table basicaly this code reassembles the grouped data it is viewing back into ungrouped data to
                        // compare to the ungrouped table created in the code above
                        Core.Console.MomControls.GridControl groupedGrid =
                            CoreManager.MomConsole.ViewPane.Grid;

                        //foreach (DataGridViewRow dgvr in CoreManager.MomConsole.ViewPane.Grid.Rows)
                        //foreach (DataGridViewRow dgvr in groupedGrid.Rows)// BUg# when group is offscreen it it not treated as group.
                        DataGridViewRow dgvrg;
                        while (rowNum < groupedGrid.Rows.Count - 1)
                        {
                            ++rowNum;
                            if (rowNum != 0) // Ignore the first row (field headers)
                            {
                                if (groupedGrid.Rows[rowNum].AccessibleObject.StateText.Contains(MsaaResources.Strings.Offscreen))
                                {
                                    groupedGrid.ScrollToRow(rowNum); // if row is offscreen make it on screen.
                                }
                                dgvrg = groupedGrid.Rows[rowNum];
                                col = -1; // Initialize the column 
                                //Due to performance reason, comment out below line. 
                                Utilities.LogMessage("CheckGrouping:: State of row = " + dgvrg.AccessibleObject.StateText);

                                // Because only groups expand/collapse, the body of the below if is executed, if it is a data rows
                                if ((!dgvrg.AccessibleObject.StateText.Contains(MsaaResources.Strings.Expanded)) && (!dgvrg.AccessibleObject.StateText.Contains(MsaaResources.Strings.Collapsed)))
                                {
                                    // We need to add a new tableRow
                                    dataRow = grpDataTable.NewRow();

                                    // Loop through each Cell of this Row
                                    Utilities.LogMessage("CheckGrouping: Row = " + rowNum);
                                    string groupedRowText = null;
                                    foreach (DataGridViewCell dgvc in dgvrg.Cells)
                                    {
                                        ++col; // Increment the current column we are on

                                        //Utilities.LogMessage("CheckGrouping [row,col] = [ " + rowNum + "," + col + "]");

                                        // Ignore the last blank row
                                        if (groupedGrid.ColumnHeaders[col].Name.Trim() != "")
                                        {
                                            string colName = groupedGrid.ColumnHeaders[col].Name;
                                            string colValue = dgvc.GetValue();

                                            // If the column name does not exist, add it
                                            if (!grpDataTable.Columns.Contains(colName))
                                            {
                                                grpDataTable.Columns.Add(new DataColumn(colName));
                                            }

                                            //Utilities.LogMessage("CheckGrouping:: Grouped Table - Adding Column : " + colName + " value " + colValue);
                                            groupedRowText = groupedRowText + colName + ":" + colValue + ";";
                                            dataRow[colName] = colValue;
                                        }
                                    }
                                    Utilities.LogMessage("CheckGrouping:: Grouped Table - " + groupedRowText);

                                    // For each Row we also have to add all the groupBy fields/values that have accumulated inside the
                                    // else must be group statement below, as well as adding the new column / field to the table which 
                                    // will be missing because it is grouped.
                                    int indexValue = 0;
                                    foreach (string field in lstGroupByFields)
                                    {
                                        // If the column name does not exist, add it
                                        if (!grpDataTable.Columns.Contains(field))
                                        {
                                            Utilities.LogMessage("CheckGrouping:: Grouped Table - Adding field " + field);
                                            grpDataTable.Columns.Add(new DataColumn(field));
                                        }

                                        dataRow[field] = lstGroupByValues[indexValue];
                                        ++indexValue;
                                    }

                                    grpDataTable.Rows.Add(dataRow);
                                }
                                else // Must be a Group
                                // TODO: Make sure you expand the node - Expanded by default... could result in error here if this changes.. 
                                {
                                    Utilities.LogMessage("CheckGrouping:: Grouped Table - Must be a group... dgvr.Value = " + dgvrg.Value);
                                    int indexColon = dgvrg.Value.IndexOf(':');
                                    string groupBy = dgvrg.Value.Substring(0, indexColon).Trim();
                                    int indexParenthesis = dgvrg.Value.IndexOf('(');
                                    string value = dgvrg.Value.Substring(indexColon + 1, indexParenthesis - groupBy.Length - 1).Trim();
                                    Utilities.LogMessage("CheckGrouping:: Grouped Table - Must be a group... Group Field = " + groupBy + " Value = " + value);

                                    // If the groupBy "field" we are adding already exists, we replace the "value" of the pre-existing "field", else add the new grouping
                                    if (lstGroupByValues.Contains(groupBy))
                                    {
                                        int indexValue = lstGroupByValues.IndexOf(groupBy);
                                        Utilities.LogMessage("CheckGrouping:: Replacing GroupByValue : " + indexValue + " with : " + value);
                                        lstGroupByValues[indexValue] = value;                  // Replace the new value :)
                                    }
                                    else
                                    {
                                        lstGroupByFields.Add(groupBy);
                                        lstGroupByValues.Add(value);
                                    }

                                    Utilities.LogMessage("CheckGrouping:: GROUP BY " + groupBy);
                                }
                            }
                        }

                        #endregion

                        #region Write both Ungrouped, Grouped tables to the log

                        // Write both the Ungrouped, and Grouped tables to the log...
                        // Dump UnGrouped table
                        Utilities.LogMessage("CheckGrouping:: Non Grouped Table");
                        foreach (DataRow dr in ungrpDataTable.Rows)
                        {
                            // Loop through all the columns
                            foreach (DataColumn dc in ungrpDataTable.Columns)
                            {
                                Utilities.LogMessage("CheckGrouping:: Column : " + dc.ColumnName + " Value : " + dr[dc.ColumnName]);
                            }

                            Utilities.LogMessage("CheckGrouping:: ------new-row-ungrouped--------------------new-row-ungrouped-------");
                        }

                        // Dump Grouped table
                        Utilities.LogMessage("CheckGrouping:: Grouped Table");
                        foreach (DataRow dr in grpDataTable.Rows)
                        {
                            // Loop through all the columns
                            foreach (DataColumn dc in grpDataTable.Columns)
                            {
                                Utilities.LogMessage("CheckGrouping:: Column : " + dc.ColumnName + " Value : " + dr[dc.ColumnName]);
                            }

                            Utilities.LogMessage("CheckGrouping:: ------new-row-grouped----------------------new-row-grouped---------");
                        }

                        #endregion

                        equalTable = this.CompareTables(grpDataTable, ungrpDataTable);
                        retry++;
                    }

                    // Check if the 2 tables are equal
                    //if (this.CompareTables(grpDataTable, ungrpDataTable))
                    if (equalTable)
                    {
                        Utilities.LogMessage("CheckGrouping:: Tables are equal");
                    }
                    else
                    {
                        Utilities.LogMessage("CheckGrouping:: Tables are not equal");
                        Utilities.TakeScreenshot("CheckGrouping - Grouping is not working as expected");
                        throw new Exception("Grouping is not working as expected, the data in grouping is not the same as the non grouped, look in logs for the differences table");
                    }

                    // Remove grouping and sorting and restore the personalizations back
                    Utilities.LogMessage("CheckGrouping:: Removing grouping and sorting");
                    this.RemoveAllGroupingSorting();
                    Utilities.TakeScreenshot("CheckGrouping - All grouping and sorting should be removed");

                    Utilities.LogMessage("CheckGrouping:: Exit CheckGrouping");
                } // try
                catch (ApplicationException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }

            } // Method CheckGroupSorting()

            /// <summary>
            /// Helper internal method to diff two tables, does an exhaustive search with no special ordering I am sure there is a way to make
            /// this more efficient but shouldn't take more then a few ms on tables with tables with around ~20 rows ~10 columns.
            /// It is slightly efficient, removing rows that were already found and removing them so they were not searched against a second time
            /// </summary>
            /// <param name="first">first table comparing</param>
            /// <param name="second">second table comparing</param>
            /// <returns>True if the tables are equal, false if they differ</returns>
            private bool CompareTables(DataTable first, DataTable second)
            {
                if (first.Rows.Count != second.Rows.Count)
                {
                    Utilities.LogMessage("Tables are not equal first table has " + first.Rows.Count.ToString() + " rows Second table has " + second.Rows.Count.ToString() + " rows row counts do not match");
                    return false;
                }

                // Check to see if the columns match up if not table are not equal
                #region Columns Match Check

                List<string> firstTableColumnNames = new List<string>();
                List<string> secondTableColumnNames = new List<string>();

                foreach (DataColumn col in first.Columns)
                {
                    firstTableColumnNames.Add(col.ColumnName);
                }

                foreach (DataColumn col in second.Columns)
                {
                    secondTableColumnNames.Add(col.ColumnName);
                }

                if (firstTableColumnNames.Count != secondTableColumnNames.Count)
                {
                    Utilities.LogMessage("CompareTables:: The number of table columns in each table are not equal");
                    return false;
                }

                foreach (string colNameFirst in firstTableColumnNames)
                {
                    if (!secondTableColumnNames.Contains(colNameFirst))
                    {
                        Utilities.LogMessage("CompareTables:: The column name : " + colNameFirst + " Was not found in the second table");
                        return false;
                    }
                }
                #endregion

                DataColumnCollection dataColumns = first.Columns;
                foreach (DataRow rowFirst in first.Rows)
                {
                    foreach (DataRow rowSecond in second.Rows)
                    {
                        // If we found the rows are equal remove this row from the second table so we don't search it again
                        if (this.CompareRows(dataColumns, rowFirst, rowSecond))
                        {
                            second.Rows.Remove(rowSecond);
                            break;
                        }
                    }
                }

                if (second.Rows.Count != 0)
                {
                    Utilities.LogMessage("Tables are not equal the following rows from table 2 were not found in both tables");

                    // TODO: add code to show the rows that were in the grouped table, but not found in the first table
                    return false;
                }

                // If the second table contains no more rows we are equal :D
                return true;
            }

            /// <summary>
            /// Helper internal method to diff two table rows, does an exhaustive search wit no speical order I am sure there is a way to make
            /// this more efficient
            /// 
            /// The Columns have to be equal and checked they are equal before this method is called
            /// </summary>
            /// <param name="dataColumns">Collection of columns that belong to the table</param>
            /// <param name="first">data row from first table eto compare</param>
            /// <param name="second">data row from second table to compare</param>
            /// <returns>True if the rows are equal, false otherwise</returns>
            private bool CompareRows(DataColumnCollection dataColumns, DataRow first, DataRow second)
            {
                // Get the data columns 

                foreach (DataColumn dataColumn in dataColumns)
                {
                    string strfirst = (string)first[dataColumn.ColumnName];
                    string strsecond = (string)second[dataColumn.ColumnName];
                    if (first != second)
                    {
                        // Some of the fields have to be checked for equivalency
                        if (equivalentStrings.ContainsKey(strfirst.ToLower())) // Make sure the key exists, or exception is thrown
                        {
                            if (equivalentStrings[strfirst.ToLower()].Contains(strsecond.ToLower()))
                            {
                                return true;
                            }
                            else
                            {
                                Utilities.LogMessage("CompareRows:: first column :" + strfirst + " not equal to second column: " + strsecond);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        Utilities.LogMessage("CompareRows:: first column :" + strfirst + " not equal to second column: " + strsecond);
                        return false;
                    }
                }

                return true; // Rows are equal
            }

            /// <summary>
            /// Contains strings localized strings used in personal view settings
            /// </summary>
            public class Strings
            {
                /// <summary>
                /// ResourceID for the the combo option "(None)"
                /// </summary>
                private const string ResourceIDComboNone = ";(None);ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;ComboNone";

                /// <summary>
                /// Cached resource string for the combo option "(None)"
                /// </summary>
                private static string cachedResourceStringComboNone = null;

                /// <summary>
                /// Property to return the localized string for the combo option "(None)"
                /// </summary>
                public static string ColumnComboNone
                {
                    get
                    {
                        if (cachedResourceStringComboNone == null)
                        {
                            cachedResourceStringComboNone = CoreManager.MomConsole.GetIntlStr(ResourceIDComboNone);
                        }

                        return cachedResourceStringComboNone;
                    }
                }
            }
        } // Class PersonalizeView

        /// <summary>
        /// PersonalViewDialog helper Class used to apply PersonalizeViewDialogSettings to the PersonalizeViewDialog
        /// </summary>
        public class PersonalizeViewDialogHelper
        {
            /// <summary>
            /// Stores the node path that is used to load up the dialog box for personalize settings eg: Task Status View
            /// </summary>
            private string dialogPath;

            /// <summary>
            /// Constructor for PersonslizeViewDialog
            /// </summary>
            /// <param name="monitoringView">monotiringView path eg: for Task view Core.Console.Views.Views.Strings.TaskStatusView</param>
            public PersonalizeViewDialogHelper(String monitoringView)
            {
                this.dialogPath = NavigationPane.Strings.Monitoring
                    + Constants.PathDelimiter
                    + Constants.UITestViewFolder
                    + Constants.PathDelimiter
                    + monitoringView;
            }

            /// <summary>
            /// Apply PersonalizeViewDialogSettings to the PersonalizeViewDialog box
            /// </summary>
            /// <param name="settings">PersonalizeViewDialogSettings</param>
            /// <returns>Returns the current PersonalizeViewDialogSettings before the new settings were applied</returns>
            public PersonalizeViewDialogSettings SetPersonalizeViewDialogOptions(PersonalizeViewDialogSettings settings)
            {
                try
                {
                    #region Bring up Personalize View Dialog box

                    // Create navigation pane object
                    NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

                    // Make sure we are navigated to Monitoring
                    navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Monitoring);

                    // Personsalize view dialog settings used to store the original settings
                    PersonalizeViewDialogSettings originalPersonalizeViewDialogSettings = new PersonalizeViewDialogSettings();

                    // Select the node that is being personalized view and RIGHT click bringing up the context menu
                    navPane.SelectNode(this.dialogPath, NavigationPane.NavigationTreeView.Monitoring, MouseFlags.RightButton);

                    // Get handle to the context menu
                    Maui.Core.WinControls.Menu contextMenu = new Maui.Core.WinControls.Menu();

                    // Prevent DEBI timing issue
                    contextMenu.ScreenElement.WaitForReady();
                    Utilities.LogMessage("SetPersonalizeViewDialogOptions:: Selecting context menu item:  '" + Core.Console.Views.Dialogs.PersonalizeViewDialog.Strings.ContextMenuPersonalizeView + "'");

                    // Click the "Personalize View..." menu item
                    contextMenu.ExecuteMenuItem(Core.Console.Views.Dialogs.PersonalizeViewDialog.Strings.ContextMenuPersonalizeView);

                    // Get reference to the Personalize task dialog box
                    Mom.Test.UI.Core.Console.Views.Dialogs.PersonalizeViewDialog personalizeViewDialog = new Mom.Test.UI.Core.Console.Views.Dialogs.PersonalizeViewDialog(CoreManager.MomConsole);

                    // Take a screeshot of the original personalization settings
                    Utilities.TakeScreenshot("SetPersonalizeViewDialogOptions - Settings before new settings are applied");

                    #endregion

                    #region Get Original Settings

                    // -----------------------------------------------------------------------------------------------------------------------
                    //
                    // Get original settings to return them, so this method can be called again to restore the personalize view to its original settings
                    //
                    // ------------------------------------------------------------------------------------------------------------------------

                    // Get original columns to display
                    // TODO: Check the order is the correct way when we restore the personalize view... if not it has to be fixed...
                    ArrayList originalCheckedItems = new ArrayList();

                    // Wipe out the columns to display (this list is going to be rebuilt to what is selected in the UI)
                    originalPersonalizeViewDialogSettings.ClearDefaultDisplayColumn();

                    foreach (Maui.Core.WinControls.CheckedListBoxItem cb in personalizeViewDialog.Controls.ColumnsToDisplayCheckBox.Items)
                    {
                        if (cb.Checked)
                        {
                            Utilities.LogMessage("SetPersonalizeViewDialogOptions:: adding to original display columns column: " + cb.Text);
                            originalPersonalizeViewDialogSettings.AddDisplayColumn(cb.Text);
                        }
                    }

                    // Get Sort columns by Item, and Radio buttons state
                    originalPersonalizeViewDialogSettings.SetSortColumnsBy(
                        personalizeViewDialog.ComboBox4Text,
                        personalizeViewDialog.Controls.AscendingRadioButton4.ButtonState,
                        personalizeViewDialog.Controls.DescendingRadioButton4.ButtonState);

                    // Get Group 1 Item, and Radio buttons state
                    originalPersonalizeViewDialogSettings.SetFirstGroupBy(
                        personalizeViewDialog.GroupBy1ComboBoxText,
                        personalizeViewDialog.Controls.AscendingRadioButton3.ButtonState,
                        personalizeViewDialog.Controls.DescendingRadioButton3.ButtonState);

                    // Get Group 2 Item, and Radio buttons state
                    originalPersonalizeViewDialogSettings.SetSecondGroupBy(
                        personalizeViewDialog.ThenByText,
                        personalizeViewDialog.Controls.AscendingRadioButton2.ButtonState,
                        personalizeViewDialog.Controls.DescendingRadioButton2.ButtonState);

                    // Get Group 3 Item, and Rdio buttons state
                    originalPersonalizeViewDialogSettings.SetThirdGroupBy(
                        personalizeViewDialog.ThenBy2Text,
                        personalizeViewDialog.Controls.AscendingRadioButton.ButtonState,
                        personalizeViewDialog.Controls.DescendingRadioButton.ButtonState);

                    #endregion

                    #region Set the Personalize view dialog box to "settings"

                    // Set the Personalize view to the settings passed in
                    foreach (Maui.Core.WinControls.CheckedListBoxItem checkBoxItem in personalizeViewDialog.Controls.ColumnsToDisplayCheckBox.Items)
                    {
                        if (settings.GetSortedDisplayColumns().BinarySearch(checkBoxItem.Text) >= 0)
                        {
                            checkBoxItem.Checked = true;
                        }
                        else
                        {
                            checkBoxItem.Checked = false;
                        }
                    }

                    // Set the Sort By Column fields
                    personalizeViewDialog.ComboBox4Text = settings.GetSortColumnsBy();

                    // Can only set the Ascending / Descending radios if the sort by columns is not set to "None" otherwise they are greyed out and an exception will get thrown tryign to set
                    if (settings.GetSortColumnsBy() != PersonalizeView.Strings.ColumnComboNone)
                    {
                        if (settings.GetSortColumnsByAsc() == ButtonState.Checked)
                        {
                            personalizeViewDialog.Controls.AscendingRadioButton4.ButtonState = ButtonState.Checked;
                        }
                        else
                        {
                            personalizeViewDialog.Controls.DescendingRadioButton4.ButtonState = ButtonState.UnChecked;
                        }
                    }

                    // Set the First Group By fields
                    personalizeViewDialog.GroupBy1ComboBoxText = settings.GetFirstGroupBy();

                    if (settings.GetFirstGroupBy() != PersonalizeView.Strings.ColumnComboNone)
                    {
                        if (settings.GetFirstGroupByAsc() == ButtonState.Checked)
                        {
                            personalizeViewDialog.Controls.AscendingRadioButton3.ButtonState = ButtonState.Checked;
                        }
                        else
                        {
                            personalizeViewDialog.Controls.DescendingRadioButton3.ButtonState = ButtonState.Checked;
                        }
                    }

                    // We can only set GroupBySecond or GroupByThird if GroupByFirst is NOT set to (None)...
                    if (settings.GetFirstGroupBy() != PersonalizeView.Strings.ColumnComboNone)
                    {
                        // Set the Second Group By fields
                        personalizeViewDialog.ThenBy2Text = settings.GetSecondGroupBy();

                        if (settings.GetSecondGroupBy() != PersonalizeView.Strings.ColumnComboNone)
                        {
                            if (settings.GetSecondGroupByAsc() == ButtonState.Checked)
                            {
                                personalizeViewDialog.Controls.AscendingRadioButton2.ButtonState = ButtonState.Checked;
                            }
                            else
                            {
                                personalizeViewDialog.Controls.DescendingRadioButton2.ButtonState = ButtonState.Checked;
                            }
                        }

                        // We can only set GroupByThird if GroupBySecond is NOT set to None
                        if (settings.GetSecondGroupBy() != PersonalizeView.Strings.ColumnComboNone)
                        {
                            // Set the Third Group By fields
                            personalizeViewDialog.ThenByText = settings.GetThirdGroupBy();

                            if (settings.GetThirdGroupBy() != PersonalizeView.Strings.ColumnComboNone)
                            {
                                if (settings.GetThirdGroupByAsc() == ButtonState.Checked)
                                {
                                    personalizeViewDialog.Controls.AscendingRadioButton.ButtonState = ButtonState.Checked;
                                }
                                else
                                {
                                    personalizeViewDialog.Controls.DescendingRadioButton.ButtonState = ButtonState.Checked;
                                }
                            }
                        }
                        else
                        {
                            settings.SetThirdGroupBy(PersonalizeView.Strings.ColumnComboNone, ButtonState.UnChecked, ButtonState.Checked);
                        }
                    }

                    // Make sure to set the settings for GroupBySecond, GroupByThird to (None)
                    else
                    {
                        settings.SetSecondGroupBy(PersonalizeView.Strings.ColumnComboNone, ButtonState.UnChecked, ButtonState.Checked);
                        settings.SetThirdGroupBy(PersonalizeView.Strings.ColumnComboNone, ButtonState.UnChecked, ButtonState.Checked);
                    }

                    #endregion

                    // Take screenshot before closing the dialogbox
                    Utilities.TakeScreenshot("SetPersonalizeViewDialogOptions - settings that will be applied to view");

                    // Close the Personalize View dialog 
                    personalizeViewDialog.ClickOK();

                    // Return the original settings (this can be passed back into this method to restore the settings)
                    return originalPersonalizeViewDialogSettings;
                }
                catch (Exception exception)
                {
                    throw new ApplicationException("SetPersonalizeViewDialogOptions:: exception thrown : " + exception);
                }
            } // SetPersonalizeViewDialogOptions
        } // Class PersonalizeViewDialog

        /// <summary>
        /// Class that stores the settings specified in Personalize View Dialog
        /// </summary>
        public class PersonalizeViewSettings
        {
            #region memberVariables
            /// <summary>
            /// This stores the columns that are selected to be displayed in view pane. 
            /// </summary>
            private List<string> displayColumns = new List<string>();

            /// <summary>
            /// This stores the columns that are "sortable" and contained inside the "Sort columns by" listbox 
            /// </summary>
            private List<string> sortableColumns = new List<string>();

            private string sortColumnsBy;
            private ButtonState sortColumnsByOrderAsc;
            private ButtonState sortColumnsByOrderDesc;

            private string firstGroupItem;
            private ButtonState firstGroupOrderAsc;
            private ButtonState firstGroupOrderDesc;

            private string secondGroupItem;
            private ButtonState secondGroupOrderAsc;
            private ButtonState secondGroupOrderDesc;

            private string thirdGroupItem;
            private ButtonState thirdGroupOrderAsc;
            private ButtonState thirdGroupOrderDesc;
            #endregion

            /// <summary>
            /// Constructor, initializes all values
            /// </summary>
            public PersonalizeViewSettings()
            {
                this.sortColumnsBy = PersonalizeView.Strings.ColumnComboNone;
                this.sortColumnsByOrderAsc = ButtonState.UnChecked;
                this.sortColumnsByOrderDesc = ButtonState.Checked;

                this.firstGroupItem = PersonalizeView.Strings.ColumnComboNone;
                this.firstGroupOrderAsc = ButtonState.UnChecked;
                this.firstGroupOrderDesc = ButtonState.Checked;

                this.secondGroupItem = PersonalizeView.Strings.ColumnComboNone;
                this.secondGroupOrderAsc = ButtonState.UnChecked;
                this.secondGroupOrderDesc = ButtonState.Checked;

                this.thirdGroupItem = PersonalizeView.Strings.ColumnComboNone;
                this.thirdGroupOrderAsc = ButtonState.UnChecked;
                this.thirdGroupOrderDesc = ButtonState.Checked;
            }

            /// <summary>
            /// Represents the sort type Ascending, Descending used in Personalization
            /// </summary>
            public enum SortType
            {
                /// <summary>
                /// Ascending Sort
                /// </summary>
                Ascending = 1,
                /// <summary>
                /// Descending Sort
                /// </summary>
                Descending = 2
            }

            /// <summary>
            /// Represents the GroupBy of FirstGroupBy, SecondGroupBy, and ThirdGroupBy
            /// </summary>
            public enum GroupID
            {
                /// <summary>
                /// FirstGroupBy
                /// </summary>
                FirstGroup = 1,
                /// <summary>
                /// SecondGroupBy
                /// </summary>
                SecondGroup = 2,
                /// <summary>
                /// ThirdGroupBy
                /// </summary>
                ThirdGroup = 3
            }

            /// <summary>
            /// Adds a column to the "Columns to display" to show up in a view.
            /// </summary>
            /// <param name="columnName">Display Column to add</param>
            public void AddDisplayColumn(string columnName)
            {
                this.displayColumns.Add(columnName);
            }

            /// <summary>
            /// Clears the list that stores the default display columns
            /// </summary>
            public void ClearDisplayColumn()
            {
                this.displayColumns.Clear();
            }

            /// <summary>
            /// Adds a column that is sortable to the sortable column collection
            /// </summary>
            /// <param name="columnName">column name to add to the collection of sortable columns</param>
            public void AddSortableColumn(string columnName)
            {
                this.sortableColumns.Add(columnName);
            }

            /// <summary>
            /// Set the column to sort, and sort type ascending / descending
            /// </summary>
            /// <param name="item">Column Name</param>
            /// <param name="ascending">Ascending ButtonState</param>
            /// <param name="descending">Descending ButtonState</param>
            public void SetSortColumnsBy(string item, ButtonState ascending, ButtonState descending)
            {
                this.sortColumnsBy = item;
                this.sortColumnsByOrderAsc = ascending;
                this.sortColumnsByOrderDesc = descending;
            }

            /// <summary>
            /// Sets the column to sort, and the sort type ascending / descending
            /// </summary>
            /// <param name="item">Column to sort</param>
            /// <param name="sortType">Sort type ascending / descending</param>
            public void SetSortColumnsBy(string item, SortType sortType)
            {
                this.sortColumnsBy = item;
                if (sortType == SortType.Ascending)
                {
                    this.sortColumnsByOrderAsc = ButtonState.Checked;
                    this.sortColumnsByOrderDesc = ButtonState.UnChecked;
                }
                else
                {
                    this.sortColumnsByOrderAsc = ButtonState.UnChecked;
                    this.sortColumnsByOrderDesc = ButtonState.Checked;
                }
            }

            /// <summary>
            /// Set the column for the group, and sort type ascending / descending
            /// </summary>
            /// <param name="item">Column Name</param>
            /// <param name="ascending">Ascending ButtonState</param>
            /// <param name="descending">Descending ButtonState</param>
            /// <param name="groupNumber">Which group to set</param>
            public void SetGroupBy(string item, ButtonState ascending, ButtonState descending, GroupID groupNumber)
            {
                switch (groupNumber)
                {
                    case GroupID.FirstGroup:
                        this.firstGroupItem = item;
                        this.firstGroupOrderAsc = ascending;
                        this.firstGroupOrderDesc = descending;
                        break;

                    case GroupID.SecondGroup:
                        this.secondGroupItem = item;
                        this.secondGroupOrderAsc = ascending;
                        this.secondGroupOrderDesc = descending;
                        break;

                    case GroupID.ThirdGroup:
                        this.thirdGroupItem = item;
                        this.thirdGroupOrderAsc = ascending;
                        this.thirdGroupOrderDesc = descending;
                        break;

                    default:
                        Utilities.LogMessage("PersonalViewSettings:: Invalid GroupNumber was assigned");
                        break;
                }
            }

            /// <summary>
            /// Sets the first group by, and the sort type ascending / descending
            /// </summary>
            /// <param name="item">Column Name of the First Group By Combo Box</param>
            /// <param name="sortType">SortType of the Column</param>
            /// <param name="groupNumber">Which Group to group</param>
            public void SetGroupBy(string item, SortType sortType, GroupID groupNumber)
            {
                switch (groupNumber)
                {
                    case GroupID.FirstGroup:
                        this.firstGroupItem = item;
                        if (sortType == SortType.Ascending)
                        {
                            this.firstGroupOrderAsc = ButtonState.Checked;
                            this.firstGroupOrderDesc = ButtonState.UnChecked;
                        }
                        else
                        {
                            this.firstGroupOrderAsc = ButtonState.UnChecked;
                            this.firstGroupOrderDesc = ButtonState.Checked;
                        }
                        break;

                    case GroupID.SecondGroup:
                        this.secondGroupItem = item;
                        if (sortType == SortType.Ascending)
                        {
                            this.secondGroupOrderAsc = ButtonState.Checked;
                            this.secondGroupOrderDesc = ButtonState.UnChecked;
                        }
                        else
                        {
                            this.secondGroupOrderAsc = ButtonState.UnChecked;
                            this.secondGroupOrderDesc = ButtonState.Checked;
                        }
                        break;

                    case GroupID.ThirdGroup:
                        this.thirdGroupItem = item;
                        if (sortType == SortType.Ascending)
                        {
                            this.thirdGroupOrderAsc = ButtonState.Checked;
                            this.thirdGroupOrderDesc = ButtonState.UnChecked;
                        }
                        else
                        {
                            this.thirdGroupOrderAsc = ButtonState.UnChecked;
                            this.thirdGroupOrderDesc = ButtonState.Checked;
                        }
                        break;

                    default:
                        Utilities.LogMessage("PersonalViewSettings:: Invalid GroupNumber was assigned");
                        break;
                }
            }

            /// <summary>
            /// Returns an array list of the columns to display
            /// </summary>
            /// <returns>ArrayList of columns to display</returns>
            public List<string> GetColumnsToDisplay()
            {
                // return this.columnsToDisplay;
                return this.displayColumns;
            }

            /// <summary>
            /// Gets the current column the view is sorted by
            /// </summary>
            /// <returns>Current column the view is sorted by</returns>
            public string GetSortColumnsBy()
            {
                return this.sortColumnsBy;
            }

            /// <summary>
            /// Gets the button state of the sorted column ascending button
            /// </summary>
            /// <returns>ButtonState of the sorted column ascending button</returns>
            public ButtonState GetSortColumnsByAsc()
            {
                return this.sortColumnsByOrderAsc;
            }

            /// <summary>
            /// Gets the views first group column
            /// </summary>
            /// <returns>String of views first group column</returns>
            public string GetFirstGroupBy()
            {
                return this.firstGroupItem;
            }

            /// <summary>
            /// Gets the button state first group by column ascending button
            /// </summary>
            /// <returns>ButtonState of the first group by column ascending button</returns>
            public ButtonState GetFirstGroupByAsc()
            {
                return this.firstGroupOrderAsc;
            }

            /// <summary>
            /// Gets the views second group column
            /// </summary>
            /// <returns>String of views second group column</returns>
            public string GetSecondGroupBy()
            {
                return this.secondGroupItem;
            }

            /// <summary>
            /// Gets the button state second group by column ascending button
            /// </summary>
            /// <returns>ButtonState of the second group by column ascending button</returns>
            public ButtonState GetSecondGroupByAsc()
            {
                return this.secondGroupOrderAsc;
            }

            /// <summary>
            /// Gets the views third group column
            /// </summary>
            /// <returns>String of views third group column</returns>
            public string GetThirdGroupBy()
            {
                return this.thirdGroupItem;
            }

            /// <summary>
            /// Gets the button state third group by column ascending button
            /// </summary>
            /// <returns>ButtonState of the third group by column ascending button</returns>
            public ButtonState GetThirdGroupByAsc()
            {
                return this.thirdGroupOrderAsc;
            }
        }

        /// <summary>
        /// Class that contains the methods called by the test code to test personal view
        /// </summary>
        public class PersonalizeViewUI
        {
            /// <summary>
            /// return type for method checkPersonalizeView
            /// </summary>
            public enum ReturnValue
            {
                /// <summary>
                /// Success on checking
                /// </summary>
                Success = 0,
                /// <summary>
                /// Failed on checking Column Header
                /// </summary>
                FailedOnCheckingColumnHeader = 1
            }

            /// <summary>
            /// Constructor
            /// </summary>
            public PersonalizeViewUI()
            {
            }

            /// <summary>
            /// Public Method to launch the Personalize View dialog given the view name and the view folder name. 
            /// </summary>
            /// <param name="name">view name</param>
            /// <param name="folderName">view folder name</param>
            /// <returns></returns>
            public PersonalizeViewDialog LaunchPersonalizeViewDialog(string name, string folderName)
            {
                //Navigate to the view to personalize
                Utilities.LogMessage("PersonalizeViewUI.launchPersonalizeViewDialog :: Bring Console to foreground (...)");
                CoreManager.MomConsole.BringToForeground();

                Utilities.LogMessage("PersonalizeViewUI.launchPersonalizeViewDialog :: Navigate to the View...");
                //Select the view 
                NavigationPane navPane = CoreManager.MomConsole.NavigationPane;
                Maui.Core.WinControls.TreeNode selectedNode = navPane.SelectNode(NavigationPane.Strings.Monitoring +
                    Constants.PathDelimiter + folderName +
                    Constants.PathDelimiter + name, NavigationPane.NavigationTreeView.Monitoring);
                Utilities.LogMessage("PersonalizeViewUI.launchPersonalizeViewDialog :: Successfully found and clicked on view " +
                    name + " under " + folderName);

                //Select Personalize menu item and Launch the Personalize Dialog
                CoreManager.MomConsole.ExecuteContextMenu(Core.Console.Views.Views.Strings.PersonalizeContextMenu, true);
                Utilities.LogMessage("PersonalizeViewUI.launchPersonalizeViewDialog :: Launch Personalize View dialog");
                Utilities.TakeScreenshot("PersonalizeViewUI.launchPersonalizeViewDialog - Launched TaskStatusView property dialog to personalize");
                Dialogs.PersonalizeViewDialog personalizeViewDialog = new Dialogs.PersonalizeViewDialog(CoreManager.MomConsole);
                UISynchronization.WaitForUIObjectReady(personalizeViewDialog, Constants.DefaultDialogTimeout);
                return personalizeViewDialog;
            }

            /// <summary>
            /// Public method to obtain the PersonalizeViewSetting from Personalize View Dialog launched in UI
            /// </summary>
            /// <param name="name">view name</param>
            /// <param name="folderName">view folder name</param>
            /// <returns></returns>
            public PersonalizeViewSettings GetPersonalizeViewSettingFromUI(string name, string folderName)
            {
                Dialogs.PersonalizeViewDialog personalizeViewDialog = this.LaunchPersonalizeViewDialog(name, folderName);
                //Utilities.LogMessage("PersonalizeViewUI.getOriginalPersonalizeViewDialogSetting :: Successfully get to the Personalize View dialog");
                //personalizeViewDialog.Extended.SetFocus();

                PersonalizeViewSettings originalPersonalizeViewSettings = new PersonalizeViewSettings();

                //get columns to be displayed in view pane
                foreach (Maui.Core.WinControls.CheckedListBoxItem cb in personalizeViewDialog.Controls.ColumnsToDisplayCheckBox.Items)
                {
                    if (cb.Checked)
                    {
                        Utilities.LogMessage("getOriginalPersonalizeViewDialogSetting :: adding to original display columns column: " + cb.Text);
                        originalPersonalizeViewSettings.AddDisplayColumn(cb.Text);
                    }
                }

                //get sortable columns from UI. 
                for (int i = 0; i < personalizeViewDialog.Controls.ComboBox4.Count; i++)
                {
                    originalPersonalizeViewSettings.AddSortableColumn(personalizeViewDialog.Controls.ComboBox4.get_Text(i));
                }

                //get sort columns by Item, and Radio button state
                originalPersonalizeViewSettings.SetSortColumnsBy(
                    personalizeViewDialog.ComboBox4Text,
                    personalizeViewDialog.Controls.AscendingRadioButton4.ButtonState,
                    personalizeViewDialog.Controls.DescendingRadioButton4.ButtonState);

                //get group 1 Item, and Radio buttons state
                originalPersonalizeViewSettings.SetGroupBy(
                    personalizeViewDialog.GroupBy1ComboBoxText,
                    personalizeViewDialog.Controls.AscendingRadioButton3.ButtonState,
                    personalizeViewDialog.Controls.DescendingRadioButton3.ButtonState,
                    PersonalizeViewSettings.GroupID.FirstGroup);

                //get group 2 Item, and Radio buttons state
                originalPersonalizeViewSettings.SetGroupBy(
                    personalizeViewDialog.ThenByText,
                    personalizeViewDialog.Controls.AscendingRadioButton2.ButtonState,
                    personalizeViewDialog.Controls.DescendingRadioButton2.ButtonState,
                    PersonalizeViewSettings.GroupID.SecondGroup);

                //get group 3 Item, and Radio buttons state
                originalPersonalizeViewSettings.SetGroupBy(
                    personalizeViewDialog.ThenBy2Text,
                    personalizeViewDialog.Controls.AscendingRadioButton.ButtonState,
                    personalizeViewDialog.Controls.DescendingRadioButton.ButtonState,
                    PersonalizeViewSettings.GroupID.ThirdGroup);

                personalizeViewDialog.ClickCancel();

                return originalPersonalizeViewSettings;
            }

            /// <summary>
            /// public method to apply the setting defined to the UI
            /// </summary>
            /// <param name="name">view name</param>
            /// <param name="folderName">view folder</param>
            /// <param name="personalizeViewSettings">the settings that needs to apply to UI</param>
            /// <returns></returns>
            public PersonalizeViewSettings ApplyPersonalizeViewSettingToUI(string name, string folderName, PersonalizeViewSettings personalizeViewSettings)
            {
                Dialogs.PersonalizeViewDialog personalizeViewDialog = this.LaunchPersonalizeViewDialog(name, folderName);
                //UISynchronization.WaitForUIObjectReady(personalizeViewDialog, Constants.DefaultDialogTimeout);
                //Utilities.LogMessage("PersonalizeViewUI.ApplyPersonalizeViewSetting :: Successfully get to the Personalize View dialog");
                //personalizeViewDialog.Extended.SetFocus();
                
                //foreach (Maui.Core.WinControls.CheckedListBoxItem checkBoxItem in personalizeViewDialog.Controls.ColumnsToDisplayCheckBox.Items)
                for (int i = 0; i < personalizeViewDialog.Controls.ColumnsToDisplayCheckBox.Items.Count;i++)
                {
                    Maui.Core.WinControls.CheckedListBoxItem checkBoxItem = personalizeViewDialog.Controls.ColumnsToDisplayCheckBox.Items[i];                   
                    if (personalizeViewSettings.GetColumnsToDisplay().Contains(checkBoxItem.Text))
                    {                       
                        checkBoxItem.Checked = true;
                    }
                    else
                    {
                        checkBoxItem.Checked = false;
                    }
                }

                //set the sort by column fields according to UI
                //also update the SortableColumn according to UI
                for (int i = 0; i < personalizeViewDialog.Controls.ComboBox4.Count; i++)
                {
                    string comboBoxItem = personalizeViewDialog.Controls.ComboBox4.get_Text(i);
                    personalizeViewSettings.AddSortableColumn(comboBoxItem);
                    if (comboBoxItem == personalizeViewSettings.GetSortColumnsBy())
                    {
                        personalizeViewDialog.ComboBox4Text = comboBoxItem;
                    }
                }
                // Can only set the Ascending/Descending radios if the sort by columns is not set to "None", otherwise they are greyed out and an exception will get thown
                if (personalizeViewDialog.ComboBox4Text != PersonalizeView.Strings.ColumnComboNone)
                {
                    
                    if (personalizeViewSettings.GetSortColumnsByAsc() == ButtonState.Checked)
                    {
                        personalizeViewDialog.Controls.AscendingRadioButton4.ButtonState = ButtonState.Checked;
                    }
                    else
                    {
                        personalizeViewDialog.Controls.DescendingRadioButton4.ButtonState = ButtonState.UnChecked;
                    }
                }

                // Set the First Group By fields
                personalizeViewDialog.GroupBy1ComboBoxText = personalizeViewSettings.GetFirstGroupBy();

                if (personalizeViewDialog.GroupBy1ComboBoxText != PersonalizeView.Strings.ColumnComboNone)
                {
                    if (personalizeViewSettings.GetFirstGroupByAsc() == ButtonState.Checked)
                    {
                        personalizeViewDialog.Controls.AscendingRadioButton3.ButtonState = ButtonState.Checked;
                    }
                    else
                    {
                        personalizeViewDialog.Controls.DescendingRadioButton3.ButtonState = ButtonState.Checked;
                    }
                }

                // Can only set GroupBySecond or GroupByThird if GroupByFirst is NOT set to (None)...
                if (personalizeViewDialog.GroupBy1ComboBoxText != PersonalizeView.Strings.ColumnComboNone)
                {
                    // Set the Second Group By fields
                    personalizeViewDialog.ThenBy2Text = personalizeViewSettings.GetSecondGroupBy();

                    if (personalizeViewDialog.ThenBy2Text != PersonalizeView.Strings.ColumnComboNone)
                    {
                        if (personalizeViewSettings.GetSecondGroupByAsc() == ButtonState.Checked)
                        {
                            personalizeViewDialog.Controls.AscendingRadioButton2.ButtonState = ButtonState.Checked;
                        }
                        else
                        {
                            personalizeViewDialog.Controls.DescendingRadioButton2.ButtonState = ButtonState.Checked;
                        }
                    }

                    // We can only set GroupByThird if GroupBySecond is NOT set to None
                    if (personalizeViewDialog.ThenBy2Text != PersonalizeView.Strings.ColumnComboNone)
                    {
                        // Set the Third Group By fields
                        personalizeViewDialog.ThenByText = personalizeViewSettings.GetThirdGroupBy();

                        if (personalizeViewDialog.ThenByText != PersonalizeView.Strings.ColumnComboNone)
                        {
                            if (personalizeViewSettings.GetThirdGroupByAsc() == ButtonState.Checked)
                            {
                                personalizeViewDialog.Controls.AscendingRadioButton.ButtonState = ButtonState.Checked;
                            }
                            else
                            {
                                personalizeViewDialog.Controls.DescendingRadioButton.ButtonState = ButtonState.Checked;
                            }
                        }
                    }
                    else
                    {
                        personalizeViewSettings.SetGroupBy(
                            PersonalizeView.Strings.ColumnComboNone,
                            ButtonState.Checked,
                            ButtonState.UnChecked,
                            PersonalizeViewSettings.GroupID.ThirdGroup);
                    }
                }

                // Make sure to set the settings for GroupBySecond, GroupByThird to (None)
                else
                {
                    //settings.SetSecondGroupBy(PersonalizeView.Strings.ColumnComboNone, ButtonState.UnChecked, ButtonState.Checked);
                    //settings.SetThirdGroupBy(PersonalizeView.Strings.ColumnComboNone, ButtonState.UnChecked, ButtonState.Checked);

                    personalizeViewSettings.SetGroupBy(PersonalizeView.Strings.ColumnComboNone, ButtonState.Checked, ButtonState.UnChecked, PersonalizeViewSettings.GroupID.SecondGroup);
                    personalizeViewSettings.SetGroupBy(PersonalizeView.Strings.ColumnComboNone, ButtonState.Checked, ButtonState.UnChecked, PersonalizeViewSettings.GroupID.ThirdGroup);
                }

                //get the displaycolumns again from UI. 
                personalizeViewSettings.ClearDisplayColumn();
                foreach (Maui.Core.WinControls.CheckedListBoxItem cb in personalizeViewDialog.Controls.ColumnsToDisplayCheckBox.Items)
                {
                    if (cb.Checked)
                    {
                        Utilities.LogMessage("ApplyPersonalizeViewSettingToUI :: Obtain display column from UI: " + cb.Text);
                        personalizeViewSettings.AddDisplayColumn(cb.Text);
                    }
                }

                //get sort columns by Item, and Radio button state again, because if the group by column is same as the sort by column, the sort by column got reset. 
                personalizeViewSettings.SetSortColumnsBy(
                    personalizeViewDialog.ComboBox4Text,
                    personalizeViewDialog.Controls.AscendingRadioButton4.ButtonState,
                    personalizeViewDialog.Controls.DescendingRadioButton4.ButtonState);

                // Take screenshot before closing the dialogbox
                Utilities.TakeScreenshot("ApplyPersonalizeViewSetting - settings that will be applied to view");

                // Close the Personalize View dialog 
                personalizeViewDialog.ClickOK();

                // Return the original settings (this can be passed back into this method to restore the settings)
                return personalizeViewSettings;
            }

            /// <summary>
            /// public method called by test code to check the function
            /// </summary>
            /// <param name="name">view name</param>
            /// <param name="folderName">view folder</param>
            /// <param name="personalizeViewSettings">settings to test</param>
            /// <returns></returns>
            public ReturnValue checkPersonalizeView(string name, string folderName, PersonalizeViewSettings personalizeViewSettings)
            {
                PersonalizeViewSettings originalPersonalViewSettings = this.GetPersonalizeViewSettingFromUI(name, folderName);
                PersonalizeViewSettings newPersonalViewSettings = this.ApplyPersonalizeViewSettingToUI(name, folderName, personalizeViewSettings);

                bool successOnChecking = CheckColumnHeaders(newPersonalViewSettings);

                //apply the original settings back before return value. 
                this.ApplyPersonalizeViewSettingToUI(name, folderName, originalPersonalViewSettings);

                if (successOnChecking)
                {
                    return ReturnValue.Success;
                }
                else
                {
                    return ReturnValue.FailedOnCheckingColumnHeader;
                }

                // ToDo: CheckGrouping();
                // ToDo: CheckColumnSorting(); 
                // TODo: Reminder: CheckColumnSorting has two situations: WithGroup and WithoutGroup. 
            }

            /// <summary>
            /// check the column headers appeared in the view grid pane are same as the ones defined display columns in the personalize view dialog 
            /// </summary>
            /// <param name="personalViewSettings">personalize view settings</param>
            /// <returns>true on success</returns>
            private bool CheckColumnHeaders(PersonalizeViewSettings personalViewSettings)
            {
                //the display columns expected to be shown in the view pane. 
                List<string> displayColumnsInViewPane = new List<string>();

                foreach (string displayColumnText in personalViewSettings.GetColumnsToDisplay())
                {
                    displayColumnsInViewPane.Add(displayColumnText);
                }
                displayColumnsInViewPane.Remove(personalViewSettings.GetFirstGroupBy());
                displayColumnsInViewPane.Remove(personalViewSettings.GetSecondGroupBy());
                displayColumnsInViewPane.Remove(personalViewSettings.GetThirdGroupBy());

                DataGridViewHeaderCollection headerRow = CoreManager.MomConsole.ViewPane.Grid.ColumnHeaders;

                // There is a black column in the end of the Grid View Pane. So the actual colunm count must minus 1. 
                int realHeaderCount = headerRow.Count - 1;

                if (realHeaderCount != displayColumnsInViewPane.Count)
                {
                    Utilities.LogMessage("PersonalizeViewUI.CheckColumnHeaders :: Column Count in the view pane doesn't match the column count selected in the personalize view dialog");
                    return false;
                }

                int i = 0;
                foreach (DataGridViewHeader header in headerRow)
                {
                    if ((i != displayColumnsInViewPane.IndexOf(header.Name)) & (header.Name != ""))
                    {
                        Utilities.LogMessage("PersonalizeViewUI.CheckColumnHeaders :: Column order in the view pane doesn't match the column order selected in the personalize view dialog");
                        return false;
                    }
                    i++;
                }
                return true;
            }
        }

        #endregion

    }
}
