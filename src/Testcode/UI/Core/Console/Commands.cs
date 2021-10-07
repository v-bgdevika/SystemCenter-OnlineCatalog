//-------------------------------------------------------------------
// <copyright file="Commands.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Menu/Toolbar Commands.
// </summary>
//  <history>
//   [mbickle] 02DEC04: Created
//   [mbickle] 20MAR06: Updated for new new Menu Items.
//   [faizalk] 07JUN06: Updated resource string for Administration space
//  </history>
//-------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console
{
#region Using directives
    using System;
    using Maui.Core;
    using Mom.Test.UI.Core.Common;
#endregion

    /// ----------------------------------------------------
    /// <summary>
    /// Command definitions used to access Menus and Toolbar functions.
    /// </summary>
    /// <history>
    /// [mbickle] 10JAN04: Created
    /// [faizalk] 27MAR06: Rename TaskPane to ActionsPane
    /// </history>
    /// ----------------------------------------------------
    public class Commands
    {
        /// <summary>
        /// Commands
        /// </summary>
        public static Command
            
            // File menu items
            FileOpen = new Command(Strings.FileOpen, null, KeyboardCodes.Ctrl + "O", null),
            FileSave = new Command(Strings.FileSave, null, KeyboardCodes.Ctrl + "S", null),
            FileSaveAs = new Command(Strings.FileSaveAs, null, null, null),
            FileExit = new Command(Strings.FileExit, null, KeyboardCodes.CloseWindow, null),
            FilePrint = new Command(Strings.FilePrint, null, KeyboardCodes.Ctrl + "P", null),
            FileCloseAllItems = new Command(Strings.FileCloseAllItems, null, null, null),
            
            // View menu items
            ViewNavigationPane = new Command(Strings.ViewNavigation, null, KeyboardCodes.Alt + KeyboardCodes.F1, null),
            ViewDetailPane = new Command(Strings.ViewDetails, null, KeyboardCodes.Alt + KeyboardCodes.F2, null),
            ViewActionsPane = new Command(Strings.ViewActions, null, KeyboardCodes.Alt + KeyboardCodes.F4, Strings.ToolbarActions),
            //ViewTasksPane = new Command(Strings.ViewActions, null, KeyboardCodes.Alt + KeyboardCodes.F4, Strings.ToolbarActions),
            ViewFind = new Command(Strings.ViewFind, null, KeyboardCodes.Alt + KeyboardCodes.F3, Strings.ToolbarFind),
            ViewRefresh = new Command(Strings.ViewRefresh, Strings.NavPaneRefresh, KeyboardCodes.F5, null),
            ViewConsoleRefresh = new Command(Strings.ViewConsoleRefresh, null, KeyboardCodes.Ctrl + KeyboardCodes.F5, null),
            ViewScope = new Command(Strings.ViewScope, null, KeyboardCodes.Ctrl + "M", Strings.ToolbarScope),
            ViewToolbarsStandard = new Command(Strings.ViewToolbarsStandard, null, null, null),
            ViewStatusBar = new Command(Strings.ViewStatusBar, null, null, null),
            ViewProperties = new Command(Strings.ViewProperties,null,KeyboardCodes.Shift + KeyboardCodes.F10,null),
            
            // Edit menu items
            EditCut = new Command(Strings.EditCut, null, KeyboardCodes.Ctrl + "X", null),
            EditCopy = new Command(Strings.EditCopy, null, KeyboardCodes.Ctrl + "C", null),
            EditPaste = new Command(Strings.EditPaste, null, KeyboardCodes.Ctrl + "V", null),
            EditDelete = new Command(Strings.EditDelete, null, KeyboardCodes.Del, null),
            
            // Go menu items
            GoMonitoring = new Command(Strings.GoMonitoring, null, KeyboardCodes.Ctrl + "1", null),
            GoMonitoringConfiguration = new Command(Strings.GoMonitoringConfiguration, null, KeyboardCodes.Ctrl + "2", null),
            GoAdministration = new Command(Strings.GoAdministration, null, KeyboardCodes.Ctrl + "3", null),
            GoMyWorkspace = new Command(Strings.GoMyWorkspace, null, KeyboardCodes.Ctrl + "4", null),
            
            // Actions menu items
            Actions = new Command(Strings.Actions, null, null, null),

            // Tools menu items
            ToolsSearch = new Command(Strings.ToolsSearch, null, null, null),
            ToolsAdvancedSearch = new Command(Strings.ToolsAdvancedSearch, null, null, null),
            ToolsAdvancedSearchManagedObjects = new Command(Strings.ToolsAdvancedSearchManagedObjects, null, null, null),
            ToolsAdvancedSearchAlerts = new Command(Strings.ToolsAdvancedSearchAlerts, null, null, null),
            ToolsAdvancedSearchEvents = new Command(Strings.ToolsAdvancedSearchEvents, null, null, null),
            ToolsAdvancedSearchRules = new Command(Strings.ToolsAdvancedSearchRules, null, null, null),
            ToolsAdvancedSearchMonitors = new Command(Strings.ToolsAdvancedSearchMonitors, null, null, null),
            ToolsAdvancedSearchTasks = new Command(Strings.ToolsAdvancedSearchTasks, null, null, null),
            ToolsMyNotifications = new Command(Strings.ToolsMyNotifications, null, null, null),
            ToolsMyRecipientInformation = new Command(Strings.ToolsMyRecipientInformation, null, null, null),
            ToolsConnect = new Command(Strings.ToolsConnect, null, null, null),

            // Help menu items
            HelpMomHelp = new Command(Strings.HelpMomHelp, null, KeyboardCodes.F1, null),
            HelpMomOnline = new Command(Strings.HelpMomOnline, null, null, null),
            HelpMomAbout = new Command(Strings.HelpAbout, null, null, null);

        #region Command Strings
        /// <summary>
        ///	Command strings.
        /// </summary>
        internal class Strings
        {
            #region File Menu
            /// <summary>
            /// File Menu
            /// </summary>
            public const string File = ";&File;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;FileMenuText";
            
            /// <summary>
            /// File\Close All Items
            /// </summary>
            public const string FileCloseAllItems = File + "|;Clos&e All Items;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.MomCommandsResources;CloseAllItemsText";
            
            /// <summary>
            /// File\Exit
            /// </summary>
            public const string FileExit = File + "|;E&xit;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;ExitMenuText";
            
            /// <summary>
            /// File\Open
            /// </summary>
            public const string FileOpen = File + "|;&Open;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;OpenMenuText";
            
            /// <summary>
            /// File\Save
            /// </summary>
            public const string FileSave = File + "|;&Save;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;SaveMenuText";
            
            /// <summary>
            /// File\Save As
            /// </summary>
            public const string FileSaveAs = File + "|;Save &As;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;SaveAsMenuText";
            
            /// <summary>
            /// File\Print
            /// </summary>
            public const string FilePrint = File + "|;&Print...;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;PrintCommandText";
            #endregion

            #region View Menu
            /// <summary>
            /// View Menu
            /// </summary>
            public const string View = ";&View;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;ViewMenuText";
            
            /// <summary>
            /// View\Navigation Pane
            /// </summary>
            public const string ViewNavigation = View + "|;&Navigation Pane;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;ViewNavigationPaneMenuText";
            
            /// <summary>
            /// View\Details Pane
            /// </summary>
            public const string ViewDetails = View + "|;&Detail Pane;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;ViewDetailViewPaneMenuText";
            
            /// <summary>
            /// View\Actions Pane
            /// </summary>
            public const string ViewActions = View + "|;&Actions;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;ShowHideActionsPaneText";
            
            /// <summary>
            /// View\Personalize view...
            /// </summary>
            public const string ViewPersonalize = View + "|;Person&alize view...;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ViewCommands;PersonalizeMenuText";
            
            /// <summary>
            /// View\Properties
            /// </summary>
            public const string ViewProperties = View + "|;P&roperties;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ViewCommands;PropertiesMenuText";
            
            /// <summary>
            /// View\Find
            /// </summary>
            public const string ViewFind = View + "|;&Find;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;ViewFindMenuText";
            
            /// <summary>
            /// View\Scope
            /// </summary>
            public const string ViewScope = View + "|;Scope;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.ViewBaseClasses.ViewResource;ShowHideMonitoringScopeCommand_Text";
            
            /// <summary>
            /// View\Refresh
            /// </summary>
            public const string ViewRefresh = View + "|;R&efresh;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ViewCommands;ViewRefreshViewMenuText";
            
            /// <summary>
            /// View\Console Refresh
            /// </summary>
            public const string ViewConsoleRefresh = View + "|;&Console Refresh;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;ViewRefreshConsoleMenuText";
            
            /// <summary>
            /// View\Toolbars
            /// </summary>
            public const string ViewToolbars = View + "|;T&oolbars;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;ViewToolbarMenuText";
            
            /// <summary>
            /// View\Toolbars\Standard
            /// </summary>
            public const string ViewToolbarsStandard = ViewToolbars + "|;&Standard;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;ViewToolbarStandardMenuText";
            
            /// <summary>
            /// View\Status Bar
            /// </summary>
            public const string ViewStatusBar = View + "|;&Status Bar;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;ViewStatusBarMenuText";
            #endregion

            #region Edit Menu
            /// <summary>
            /// Edit Menu
            /// </summary>
            public const string Edit = ";&Edit;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;EditMenuText";
            
            /// <summary>
            /// Edit\Cut
            /// </summary>
            public const string EditCut = Edit + "|;Cu&t;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;CutMenuText";
            
            /// <summary>
            /// Edit\Copy
            /// </summary>
            public const string EditCopy = Edit + "|;&Copy;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;CopyMenuText";
            
            /// <summary>
            /// Edit\Paste
            /// </summary>
            public const string EditPaste = Edit + "|;;&Paste;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;PasteMenuText";
            
            /// <summary>
            /// Edit\Delete
            /// </summary>
            public const string EditDelete = Edit + "|;&Delete;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;DeleteMenuText";
            #endregion

            #region Go Menu
            /// <summary>
            /// Go Menu
            /// </summary>
            public const string Go = ";&Go;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;GoMenuText";
            
            /// <summary>
            /// Go\Monitoring
            /// </summary>
            public const string GoMonitoring = Go + "|;Monitoring;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Monitoring.MonitoringPageResources;MonitoringPageText";
            
            /// <summary>
            /// Go\Monitoring Configuration
            /// </summary>
            public const string GoMonitoringConfiguration = Go + "|;Authoring;ManagedString;Microsoft.EnterpriseManagement.UI.Console.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.MonitoringConfiguration.MonitoringConfigurationPageResources;MonitoringConfigRootNode";
            
            /// <summary>
            /// Go\Administration
            /// </summary>
            public const string GoAdministration = Go + "|;Administration;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AdminTreeViewAdministrationRoot";
            
            /// <summary>
            /// Go\MyWorkspace
            /// </summary>
            public const string GoMyWorkspace = Go + "|;MyWorkspace;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.WunderBarPages.Favorites.FavoritesResources;PageName";
            #endregion

            #region Actions Menu
            /// <summary>
            /// Actions Menu
            /// </summary>
            public const string Actions = ";&Actions;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;ActionsText";
            #endregion

            #region Tools Menu
            /// <summary>
            /// Tools Menu
            /// </summary>
            public const string Tools = ";&Tools;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;ToolsMenuText";
            
            /// <summary>
            /// Tools\Search
            /// </summary>
            public const string ToolsSearch = Tools + "|;&Search;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SearchCommands;Search";
            
            /// <summary>
            /// Tools\Advanced Search
            /// </summary>
            public const string ToolsAdvancedSearch = Tools + "|;Advanced Search...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SearchCommands;AdvancedSearch";
            
            /// <summary>
            /// Tools\Advanced Search\Managed Objects
            /// </summary>
            public const string ToolsAdvancedSearchManagedObjects = ToolsSearch + "|;Managed Objects;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SearchResource;SearchManagedObjects";
            
            /// <summary>
            /// Tools\Advanced Search\Alerts
            /// </summary>
            public const string ToolsAdvancedSearchAlerts = ToolsSearch + "|;Alerts;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SearchResource;SearchAlerts";
            
            /// <summary>
            /// Tools\Advanced Search\Events
            /// </summary>
            public const string ToolsAdvancedSearchEvents = ToolsSearch + "|;Events;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SearchResource;SearchEvents";
            
            /// <summary>
            /// Tools\Advanced Search\Rules
            /// </summary>
            public const string ToolsAdvancedSearchRules = ToolsSearch + "|;Rules;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SearchResource;SearchRules";
            
            /// <summary>
            /// Tools\Advanced Search\Monitors
            /// </summary>
            public const string ToolsAdvancedSearchMonitors = ToolsSearch + "|;Monitors;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SearchResource;SearchMonitors";
            
            /// <summary>
            /// Tools\Advanced Search\Tasks
            /// </summary>
            public const string ToolsAdvancedSearchTasks = ToolsSearch + "|;Tasks;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Search.SearchResource;SearchTasks";
            
            /// <summary>
            /// Tools\My Notifications...
            /// </summary>
            public const string ToolsMyNotifications = Tools + "|;My Notifications...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.MomCommandsResources;ToolsMyNotificationsMenuText";
            
            /// <summary>
            /// Tools\My Recipient Information...
            /// </summary>
            public const string ToolsMyRecipientInformation = Tools + "|;My Recipient Information...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.MomCommandsResources;ToolsMyRecipientMenuText";
            
            /// <summary>
            /// Tools\Connect...
            /// </summary>
            public const string ToolsConnect = Tools + "|;&Connect...;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.MomCommandsResources;OpenNewConnectionText";
            #endregion

            #region Help Menu
            /// <summary>
            /// Help Menu
            /// </summary>
            public const string Help = ";&Help;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;HelpMenuText";
            
            /// <summary>
            /// Help\Microsoft Operations Manager Help
            /// </summary>
            public const string HelpMomHelp = Help + "|;Microsoft &Operations Manager Help;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.MomCommandsResources;HelpMenuText";
            
            /// <summary>
            /// Help\Microsoft Operations Manager Online
            /// </summary>
            public const string HelpMomOnline = Help + "|;&Microsoft Operations Manager Online;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Console.MomCommandsResources;ProductOnlineMenuText";
            
            /// <summary>
            /// Help\About
            /// </summary>
            public const string HelpAbout = Help + "|;&About;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;HelpAbout";
            #endregion

            #region Toolbar
            /// <summary>
            /// Toolbar Actions
            /// </summary>
            public const string ToolbarActions = ";Actions;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.TaskPane;titleLabel.Text";
            
            /// <summary>
            /// Toolbar Scope
            /// </summary>
            public const string ToolbarScope = ";Scope;ManagedString;Microsoft.MOM.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.ViewBaseClasses.ViewResource;ShowHideMonitoringScopeCommand_Text";
            
            /// <summary>
            /// Toolbar Find
            /// </summary>
            public const string ToolbarFind = ";&Find;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;ViewFindMenuText";
            #endregion

            #region NavPane Menu
            /// <summary>
            /// Navigation Pane Refresh
            /// </summary>
            public const string NavPaneRefresh = ";R&efresh;ManagedString;Microsoft.Mom.UI.Common.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.ViewFramework.ViewCommands;ViewRefreshViewMenuText";
            #endregion
        }
        #endregion
    }
}
