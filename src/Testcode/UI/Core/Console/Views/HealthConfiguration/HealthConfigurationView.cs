#region Using directives
using Maui.Core;
using Maui.Core.WinControls;
using Maui.Core.Utilities;
using Mom.Test.UI.Core.Console;
using Mom.Test.UI.Core.Common;
using System.ComponentModel;
using System;
#endregion

namespace Mom.Test.UI.Core.Console.Views.HealthConfiguration
{
    /// <summary>
    /// Class to add general methods for Windows Service Monitor
    /// </summary>
    public class HealthConfigurationView
    {
        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for windows service monitor dialogs
        /// </summary>
        /// <history> 	
        ///   [ruhim]  07Sep05: Added resource strings for windows service 
        ///                     monitor dialogs
        ///   [ruhim]  08Sep06: Updating Delete context menu resource sring   
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Contains resource string for:  Unit Monitor... Context Menu
            /// </summary>
            private const string ResourceContextMenuUnitMonitor =            
            ";Unit &Monitor...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.HealthView.HealthViewResources;AddUnitMonitorContextMenuText";

            /// <summary>
            /// Contains resource string for:  Create a Monitor Context Menu
            /// </summary>
            private const string ResourceContextMenuCreateMonitor =            
            ";Create a monitor;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.HealthView.HealthViewResources;CreateMonitorDropDownText";
            
            /// <summary>
            /// Contains resource string for:  Add a Unit Monitor Context Menu
            /// </summary>
            private const string ResourceAddUnitmonitor =
                ";Add Unit &Monitor...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.HealthViewCommands;AddUnitMonitorCommand";

            /// <summary>
            /// Contains resource string for:  Add Rollup Monitor Context Menu
            /// </summary>
            private const string ResourceContextMenuAggregateRollupMonitor =
            ";Aggregate R&ollup Monitor...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.HealthView.HealthViewResources;AddRollupMonitorContextMenuText";

            /// <summary>
            /// Contains resource string for:  Add Dependency Monitor Context Menu
            /// </summary>
            private const string ResourceContextMenuDependencyRollupMonitor =
            ";De&pendency Rollup Monitor...;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.HealthView.HealthViewResources;AddDependencyMonitorContextMenuText";

            /// <summary>
            /// Contains resource string for:  System.EntityHealth aggregate monitor
            /// </summary>            
            private const string ResourceSystemEntityHealth = "Entity Health";

            /// <summary>
            /// Contains resource string for:  Health State Header column in Create Monitor Wizard
            /// </summary>
            private const string ResourceHealthStateHeader =                
                ";Health State;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.OperationalStatesMappingPage;healthStateColumn.HeaderText";

            /// <summary>
            /// Contains resource string for:  Name Header column in Health Configuration View
            /// </summary>
            private const string ResourceNameHeaderHealthView =
                ";Name;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.HealthView.HealthViewResources;NameColumn";
                
            /// <summary>
            /// Contains resource string for:  Expand all Context Menu
            /// </summary>
            private const string ResourceContextMenuExpandAll =
            ";E&xpand All;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.HealthViewCommands;ExpandAllCommand";

            /// <summary>
            /// Contains resource string for:  Properties Context Menu
            /// </summary>
            private const string ResourceContextMenuProperties = 
                ";Propert&ies;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.ViewCommands;PropertiesMenuText";

            /// <summary>
            /// Contains resource string for:  Delete Context Menu
            /// </summary>
            private const string ResourceContextMenuDelete =
                ";&Delete;ManagedString;Microsoft.EnterpriseManagement.UI.ConsoleFramework.dll;Microsoft.EnterpriseManagement.ConsoleFramework.Commands.ShellCommandResources;DeleteMenuText";

            /// <summary>
            /// Contains resource string for:  Enable Context Menu
            /// </summary>
            private const string ResourceContextMenuEnable =
                ";E&nable;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.HealthView.HealthViewResources;EnableContextMenuText";

            /// <summary>
            /// Contains resource string for:  Disable Context Menu
            /// </summary>
            private const string ResourceContextMenuDisable =
                ";Disa&ble;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.HealthView.HealthViewResources;DisableContextMenuText"; 
            
            /// <summary>
            /// Contains resource string for:  Enable Actions Pane Text
            /// </summary>
            private const string ResourceActionsPaneEnable =
                ";Enable;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.HealthView.HealthViewResources;EnableActionText";

            /// <summary>
            /// Contains resource string for:  Disable Actions Pane Text
            /// </summary>
            private const string ResourceActionsPaneDisable =
                ";Disable;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.HealthView.HealthViewResources;DisableActionText";

            /// <summary>
            /// Contains resource string for: Targeted Type Column header under Health Configuration View
            /// </summary>
            private const string ResourceTargetedTypeHeader =
            ";Targeted Type;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.HealthView;TargetEntityTypeColumn";

            /// <summary>
            /// Contains resource string for: Actions Pane Header - Monitor
            /// </summary>
            private const string ResourceMonitorActionsPaneHeader =
            ";Monitor;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.Views.HealthView.HealthViewResources;Monitor";
        
            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Unit Monitor... Context Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuUnitMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Create a Monitor Context Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuCreateMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add a Unit Monitor Context Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAddUnitmonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add Rollup Monitor Context Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuAggregateRollupMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Add Dependency Monitor Context Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuDependencyRollupMonitor;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  System.EntityHealth aggregate monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedSystemEntityHealth;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Health State Header column in Create Monitor Wizard
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedHealthStateHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Name Header column in Health Configuration View
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedNameHeaderHealthView;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Expand all Context Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuExpandAll;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Properties Context Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuProperties;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Delete Context Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuDelete;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Enable Context Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuEnable;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Disable Context Menu
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedContextMenuDisable;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Enable Actions Pane
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedActionsPaneEnable;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Disable Actions Pane
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedActionsPaneDisable;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Targeted Type Column header
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedTargetedTypeHeader;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Actions Pane Header - Monitor
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedMonitorActionsPaneHeader;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Unit Monitor... Context Menu translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 22MAR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuUnitMonitor
            {
                get
                {
                    if ((cachedContextMenuUnitMonitor == null))
                    {
                        cachedContextMenuUnitMonitor = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuUnitMonitor);
                    }

                    return cachedContextMenuUnitMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Create a Monitor Context Menu translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 21MAR06 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuCreateMonitor
            {
                get
                {
                    if ((cachedContextMenuCreateMonitor == null))
                    {
                        cachedContextMenuCreateMonitor = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuCreateMonitor);
                    }

                    return cachedContextMenuCreateMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add a Unit Monitor Context Menu translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 19Aug05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            [Obsolete("Use HealthConfigurationView.Strings.ContextMenuCreateMonitor")]
            public static string AddUnitmonitor
            {
                get
                {
                    if ((cachedAddUnitmonitor == null))
                    {
                        cachedAddUnitmonitor = CoreManager.MomConsole.GetIntlStr(ResourceAddUnitmonitor);
                    }

                    return cachedAddUnitmonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add Rollup Monitor Context Menu translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 15Sep05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuAggregateRollupMonitor
            {
                get
                {
                    if ((cachedContextMenuAggregateRollupMonitor == null))
                    {
                        cachedContextMenuAggregateRollupMonitor = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuAggregateRollupMonitor);
                    }

                    return cachedContextMenuAggregateRollupMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Add Dependency Monitor Context Menu translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 15Sep05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuDependencyRollupMonitor
            {
                get
                {
                    if ((cachedContextMenuDependencyRollupMonitor == null))
                    {
                        cachedContextMenuDependencyRollupMonitor = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuDependencyRollupMonitor);
                    }

                    return cachedContextMenuDependencyRollupMonitor;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the System.EntityHealth aggregate monitor translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 19Aug05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            [Obsolete("This is obsolete now. Use Core.Console.Monitors.Monitor.Strings.EntityHealthMonitor")]
            public static string SystemEntityHealth
            {
                get
                {
                    if ((cachedSystemEntityHealth == null))
                    {
                        cachedSystemEntityHealth = CoreManager.MomConsole.GetIntlStr(ResourceSystemEntityHealth);
                    }

                    return cachedSystemEntityHealth;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Health State Header column in Create Monitor Wizard translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 25Aug05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HealthStateHeader
            {
                get
                {
                    if ((cachedHealthStateHeader == null))
                    {
                        cachedHealthStateHeader = CoreManager.MomConsole.GetIntlStr(ResourceHealthStateHeader);
                    }

                    return cachedHealthStateHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Name Header column in Health Configuration View
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 01Sep05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NameHeaderHealthView
            {
                get
                {
                    if ((cachedNameHeaderHealthView == null))
                    {
                        cachedNameHeaderHealthView = CoreManager.MomConsole.GetIntlStr(ResourceNameHeaderHealthView);
                    }

                    return cachedNameHeaderHealthView;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Expand All context menu item in Health Configuration View
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 01Sep05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuExpandAll
            {
                get
                {
                    if ((cachedContextMenuExpandAll == null))
                    {
                        cachedContextMenuExpandAll = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuExpandAll);
                    }

                    return cachedContextMenuExpandAll;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Properties context menu item in Health Configuration View
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 07Sep05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuProperties
            {
                get
                {
                    if ((cachedContextMenuProperties == null))
                    {
                        cachedContextMenuProperties = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuProperties);
                    }
                    return cachedContextMenuProperties;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Delete context menu item in Health Configuration View
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 07Sep05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuDelete
            {
                get
                {
                    if ((cachedContextMenuDelete == null))
                    {
                        cachedContextMenuDelete = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuDelete);
                    }
                    return cachedContextMenuDelete;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Enable context menu item in Health Configuration View
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 25May07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuEnable
            {
                get
                {
                    if ((cachedContextMenuEnable == null))
                    {
                        cachedContextMenuEnable = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuEnable);
                    }
                    return cachedContextMenuEnable;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Disable context menu item in Health Configuration View
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 25May07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenuDisable
            {
                get
                {
                    if ((cachedContextMenuDisable == null))
                    {
                        cachedContextMenuDisable = CoreManager.MomConsole.GetIntlStr(ResourceContextMenuDisable);
                    }
                    return cachedContextMenuDisable;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Actions Pane Disable item in Health Configuration View
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 25May07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ActionsPaneDisable
            {
                get
                {
                    if ((cachedActionsPaneDisable == null))
                    {
                        cachedActionsPaneDisable = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneDisable);
                    }
                    return cachedActionsPaneDisable;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Actions Pane Enable item in Health Configuration View
            /// translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 25May07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ActionsPaneEnable
            {
                get
                {
                    if ((cachedActionsPaneEnable == null))
                    {
                        cachedActionsPaneEnable = CoreManager.MomConsole.GetIntlStr(ResourceActionsPaneEnable);
                    }
                    return cachedActionsPaneEnable;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Targeted Type Column header translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 29Aug05 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string TargetedTypeHeader
            {
                get
                {
                    if ((cachedTargetedTypeHeader == null))
                    {
                        cachedTargetedTypeHeader = CoreManager.MomConsole.GetIntlStr(ResourceTargetedTypeHeader);
                    }

                    return cachedTargetedTypeHeader;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Actions Pane Header - Monitor translated resource string
            /// </summary>
            /// <history>
            /// 	[ruhim] 29May07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MonitorActionsPaneHeader
            {
                get
                {
                    if ((cachedMonitorActionsPaneHeader == null))
                    {
                        cachedMonitorActionsPaneHeader = CoreManager.MomConsole.GetIntlStr(ResourceMonitorActionsPaneHeader);
                    }

                    return cachedMonitorActionsPaneHeader;
                }
            }
            #endregion
            
        }
        #endregion

    } //end of class HealthConfigurationView

}//end of namespace