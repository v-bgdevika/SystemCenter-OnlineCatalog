//-----------------------------------------------------------------------------
// <copyright file="DiagramView.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Diagram View
// </summary>
//  <history>
//   [mbickle]   02DEC04:   Created
//   [kellymor]  05APR07:   Added Strings class and context menu
//   [kellymor]  24APR07:   Added health state text for virtual folders and
//                          context menus
//   [kellymor]  17OCT07:   Changed context menu resource string for Open->
//                          &Diagram View
//   [kellymor]  29MAY08:   Added context menu for Command Shell
//   [a-mujtch]  22MAY09:   Added methods to monitor Distributed Application
//  </history>
//-----------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Views.Diagram
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Mom.Test.UI.Core.Common;
    using Mom.Test.UI.Core.Console.Views.Diagram.Dialogs;
    using Mom.Test.UI.Core.Console.ServiceDesigner;
    #endregion

    /// <summary>
    /// Diagram View
    /// </summary>
    public class DiagramView
    {
        #region Member variables
        /// <summary>
        /// Diagram View Dialog
        /// </summary>
        private DiagramViewDialog cachedDiagramViewDialog;

        #endregion

        #region Cached properties
        /// <summary>
        /// Diagram View
        /// </summary>
        public DiagramView()
        {
            
        }

        /// <summary>
        /// Cached DiagramViewDialog
        /// </summary>
        private DiagramViewDialog DiagramViewDialogWindow
        {
            get
            {
                if (this.cachedDiagramViewDialog == null)
                {
                    this.cachedDiagramViewDialog = new DiagramViewDialog(CoreManager.MomConsole);
                    CoreManager.MomConsole.Waiters.WaitForWindowIdle(this.cachedDiagramViewDialog, Constants.OneMinute);
                }

                return this.cachedDiagramViewDialog;
            }
        }
        #endregion

        #region Strings

        /// <summary>
        /// Class to contain string resources
        /// </summary>
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Resource string used in context menus
            /// </summary>
            private const string ResourceContextMenu =
                ";&Diagram View" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.ViewBaseClasses.ViewResource" +
                ";DiagramViewMenuText";

            /// <summary>
            /// Resource string used in context menus
            /// </summary>
            private const string ResourceOpenDiagramViewContextMenu = 
                ";&Diagram View" +
                ";ManagedString" + 
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramViewResources" +
                ";DiagramViewContextMenu";

            /// <summary>
            /// Resource string for the command text used to navigate to a diagram view
            /// </summary>
            private const string ResourceCommandText =
                ";&Diagram View" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";CommandJumpToDiagramView";

            #region Health States

            /// <summary>
            /// Resource string for health state text:  critical
            /// </summary>
            private const string ResourceCriticalStateText = ";Critical;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramViewResources;ErrorText";

            /// <summary>
            /// Resource string for health state text:  warning
            /// </summary>
            private const string ResourceWarningStateText = ";Warning;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramViewResources;WarningText";

            /// <summary>
            /// Resource string for health state text:  healthy
            /// </summary>
            private const string ResourceHealthyStateText = ";Healthy;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramViewResources;SuccessText";

            /// <summary>
            /// Resource string for health state text:  not monitored
            /// </summary>
            private const string ResourceNotMonitoredStateText = ";Not monitored;ManagedString;Microsoft.MOM.UI.Components.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramViewResources;NotMonitoredText";

            #endregion

            #region Context Menus

            /// <summary>
            /// Resource string for context menu:  expand
            /// </summary>
            private const string ResourceExpandContextMenu =
                ";Expand" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramViewResources" +
                ";Expand";

            /// <summary>
            /// Resource string for context menu:  collapse
            /// </summary>
            private const string ResourceCollapseContextMenu =
                ";Collapse" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramViewResources" +
                ";Collapse";

            /// <summary>
            /// Resource string for context menu:  display as box
            /// </summary>
            private const string ResourceDisplayAsBoxContextMenu =
                ";Display as box" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramViewResources" +
                ";AsBox";

            /// <summary>
            /// Resource string for context menu:  display as icon
            /// </summary>
            private const string ResourceDisplayAsIconContextMenu =
                ";Display as icon" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramViewResources" +
                ";AsNonBox";

            /// <summary>
            /// Resource string for context menu:  relayout
            /// </summary>
            private const string ResourceRelayoutContextMenu =
                ";Relayout" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.DiagramView.DiagramViewCommandResources" +
                ";RelayoutText";

            /// <summary>
            /// Resource string for context menu:  instance properties
            /// </summary>
            private const string ResourceInstancePropertiesContextMenu =
                ";Instance Properties" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.StateResources" +
                ";ShowInstanceProperties";

            /// <summary>
            /// Resource string for context menu:  health explorer
            /// </summary>
            private const string ResourceHealthExplorerContextMenu =
                ";Health Explorer" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.StateResources" +
                ";ShowStateTree";

            /// <summary>
            /// Resource string for context menu:  maintenance mode
            /// </summary>
            private const string ResourceMaintenanceModeContextMenu =
                ";Maintenance Mode" +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Components.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources" +
                ";MaintenanceModeText";

            /// <summary>
            /// Resource string for context menu:  Command Shell...
            /// </summary>
            private const string ResourceCommandShellContextMenu =
                ";Command Shell..." +
                ";ManagedString" +
                ";Microsoft.MOM.UI.Common.dll" +
                ";Microsoft.EnterpriseManagement.Mom.Internal.UI.ViewBaseClasses.ViewResource" +
                ";MomViewCommands_OpenCommandWindow";

            #endregion

            #endregion

            #region Private Members

            /// <summary>
            /// Contains the translated resource string for ContextMenu
            /// </summary>
            private static string cachedContextMenu;

            /// <summary>
            /// Cached resource for the Open-Diagram context menu string
            /// </summary>
            private static string cachedOpenDiagramViewContextMenu;

            /// <summary>
            /// Contains the translated resource string for CommandText
            /// </summary>
            private static string cachedCommandText;

            #region Health States

            /// <summary>
            /// Contains the translated resource string for health state:  critical
            /// </summary>
            private static string cachedCriticalStateText;

            /// <summary>
            /// Contains the translated resource string for health state:  warning
            /// </summary>
            private static string cachedWarningStateText;

            /// <summary>
            /// Contains the translated resource string for health state:  healthy
            /// </summary>
            private static string cachedHealthyStateText;

            /// <summary>
            /// Contains the translated resource string for health state:  not monitored
            /// </summary>
            private static string cachedNotMonitoredStateText;

            #endregion

            #region Context Menus

            /// <summary>
            /// Contains the translated resource string for context menu:  expand
            /// </summary>
            private static string cachedExpandContextMenu;

            /// <summary>
            /// Contains the translated resource string for context menu:  collapse
            /// </summary>
            private static string cachedCollapseContextMenu;

            /// <summary>
            /// Contains the translated resource string for context menu:  display as box
            /// </summary>
            private static string cachedDisplayAsBoxContextMenu;
            
            /// <summary>
            /// Contains the translated resource string for context menu:  display as icon
            /// </summary>
            private static string cachedDisplayAsIconContextMenu;

            /// <summary>
            /// Contains the translated resource string for context menu:  relayout
            /// </summary>
            private static string cachedRelayoutContextMenu;
            
            /// <summary>
            /// Contains the translated resource string for context menu:  instance properties
            /// </summary>
            private static string cachedInstancePropertiesContextMenu;
            
            /// <summary>
            /// Contains the translated resource string for context menu:  health explorer
            /// </summary>
            private static string cachedHealthExplorerContextMenu;

            /// <summary>
            /// Contains the translated resource string for context menu:  maintenance mode
            /// </summary>
            private static string cachedMaintenanceModeContextMenu;

            /// <summary>
            /// Contains the translated resource string for context menu:  command shell...
            /// </summary>
            private static string cachedCommandShellContextMenu;

            #endregion

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ContextMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 05APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ContextMenu
            {
                get
                {
                    if ((cachedContextMenu == null))
                    {
                        cachedContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceContextMenu);
                    }

                    return cachedContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CommandText translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 05APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CommandText
            {
                get
                {
                    if ((cachedCommandText == null))
                    {
                        cachedCommandText = CoreManager.MomConsole.GetIntlStr(ResourceCommandText);
                    }

                    return cachedCommandText;
                }
            }

            #region Health States

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CriticalStateText translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 24APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CriticalStateText
            {
                get
                {
                    if ((cachedCriticalStateText == null))
                    {
                        cachedCriticalStateText = CoreManager.MomConsole.GetIntlStr(ResourceCriticalStateText);
                    }

                    return cachedCriticalStateText;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the WarningStateText translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 24APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string WarningStateText
            {
                get
                {
                    if ((cachedWarningStateText == null))
                    {
                        cachedWarningStateText = CoreManager.MomConsole.GetIntlStr(ResourceWarningStateText);
                    }

                    return cachedWarningStateText;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HealthyStateText translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 24APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HealthyStateText
            {
                get
                {
                    if ((cachedHealthyStateText == null))
                    {
                        cachedHealthyStateText = CoreManager.MomConsole.GetIntlStr(ResourceHealthyStateText);
                    }

                    return cachedHealthyStateText;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the NotMonitoredStateText translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 24APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string NotMonitoredStateText
            {
                get
                {
                    if ((cachedNotMonitoredStateText == null))
                    {
                        cachedNotMonitoredStateText = CoreManager.MomConsole.GetIntlStr(ResourceNotMonitoredStateText);
                    }

                    return cachedNotMonitoredStateText;
                }
            }

            #endregion

            #region Context Menus

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the OpenDiagramViewContextMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 05APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string OpenDiagramViewContextMenu
            {
                get
                {
                    if ((cachedOpenDiagramViewContextMenu == null))
                    {
                        cachedOpenDiagramViewContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceOpenDiagramViewContextMenu);
                    }

                    return cachedOpenDiagramViewContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ExpandContextMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 24APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ExpandContextMenu
            {
                get
                {
                    if ((cachedExpandContextMenu == null))
                    {
                        cachedExpandContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceExpandContextMenu);
                    }

                    return cachedExpandContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the CollapseContextMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 24APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CollapseContextMenu
            {
                get
                {
                    if ((cachedCollapseContextMenu == null))
                    {
                        cachedCollapseContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceCollapseContextMenu);
                    }

                    return cachedCollapseContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DisplayAsBoxContextMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 24APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DisplayAsBoxContextMenu
            {
                get
                {
                    if ((cachedDisplayAsBoxContextMenu == null))
                    {
                        cachedDisplayAsBoxContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceDisplayAsBoxContextMenu);
                    }

                    return cachedDisplayAsBoxContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DisplayAsIconContextMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 24APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DisplayAsIconContextMenu
            {
                get
                {
                    if ((cachedDisplayAsIconContextMenu == null))
                    {
                        cachedDisplayAsIconContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceDisplayAsIconContextMenu);
                    }

                    return cachedDisplayAsIconContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the RelayoutContextMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 24APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string RelayoutContextMenu
            {
                get
                {
                    if ((cachedRelayoutContextMenu == null))
                    {
                        cachedRelayoutContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceRelayoutContextMenu);
                    }

                    return cachedRelayoutContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the InstancePropertiesContextMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 24APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string InstancePropertiesContextMenu
            {
                get
                {
                    if ((cachedInstancePropertiesContextMenu == null))
                    {
                        cachedInstancePropertiesContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceInstancePropertiesContextMenu);
                    }

                    return cachedInstancePropertiesContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the HealthExplorerContextMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 24APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string HealthExplorerContextMenu
            {
                get
                {
                    if ((cachedHealthExplorerContextMenu == null))
                    {
                        cachedHealthExplorerContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceHealthExplorerContextMenu);
                    }

                    return cachedHealthExplorerContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the MaintenanceModeContextMenu translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 24APR07 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string MaintenanceModeContextMenu
            {
                get
                {
                    if ((cachedMaintenanceModeContextMenu == null))
                    {
                        cachedMaintenanceModeContextMenu = CoreManager.MomConsole.GetIntlStr(ResourceMaintenanceModeContextMenu);
                    }

                    return cachedMaintenanceModeContextMenu;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the Command Shell Context Menu translated resource string
            /// </summary>
            /// <history>
            /// 	[kellymor] 29MAY08 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string CommandShellContextMenu
            {
                get
                {
                    if ((cachedCommandShellContextMenu == null))
                    {
                        cachedCommandShellContextMenu = 
                            CoreManager.MomConsole.GetIntlStr(
                                ResourceCommandShellContextMenu);
                    }

                    return cachedCommandShellContextMenu;
                }
            }

            #endregion

            #endregion
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Open and Monitor Distributed Application using Diagram View
        /// </summary>
        /// <param name="name">Distributed Application name</param>
        /// <param name="component">Group component name</param>
        /// <param name="focus">Test focus</param>
        /// <returns>True if success</returns>
        public bool MonitorDistributedApplication(
            string name, 
            string component, 
            TestFocus focus)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: (...)");

            if (null == name)
            {
                throw new ArgumentNullException("Distributed Application name cannot be null");
            }

            if (null == component)
            {
                throw new ArgumentNullException("Component name cannot be null");
            }

            Utilities.LogMessage(currentMethod + ":: DA name: " + name);
            Utilities.LogMessage(currentMethod + ":: component: " + component);
            Utilities.LogMessage(currentMethod + ":: focus: " + focus.ToString());

            bool returnValue = false;
            OpenView(name, Core.Console.Views.Views.Strings.OpenDiagramViewContextMenu);
            returnValue = FindStatusInDiagramView(component, focus);
            CloseDiagramViewDialog();
            return returnValue;
        }
        #endregion
        
        #region Private Helper Methods

        /// <summary>
        /// Verify Distributed Application using Diagram View
        /// </summary>
        /// <param name="component">Group component name</param>
        /// <param name="focus">Test focus</param>
        /// <returns>True if success</returns>
        private bool FindStatusInDiagramView(string component, TestFocus focus)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");
            Utilities.LogMessage(currentMethod + ":: component: " + component);
            Utilities.LogMessage(currentMethod + ":: focus: " + focus.ToString());
            Utilities.LogMessage(currentMethod + ":: Finding Diagram Dialog");
            DiagramViewDialogWindow.WaitForResponse();

            //find component using the find dialog
            Utilities.LogMessage(currentMethod + ":: Finding component: " + component);
            DiagramViewDialogWindow.Controls.ViewToolbar.ToolbarItems[DiagramViewDialog.INDEX_BUTTON_FIND].Click();
            Core.Console.ServiceDiagram.FindNodeDialog findInstance = new Mom.Test.UI.Core.Console.ServiceDiagram.FindNodeDialog(CoreManager.MomConsole);
            findInstance.FindWhatText = component;
            findInstance.WaitForResponse(Constants.OneMinute);
            findInstance.ClickFind();

            CoreManager.MomConsole.Waiters.WaitForWindowIdle(DiagramViewDialogWindow, Constants.OneMinute);

            bool expectedValue;

            //set expected value of toolbar button
            if (focus == TestFocus.Positive)
            {
                expectedValue = false;
            }
            else
            {
                expectedValue = true;
            }

            //check state of Problem Path menu item which remains disabled when distributed application is in valid state
            const int maxRetry = 10;
            bool value = DiagramViewDialogWindow.Controls.ViewToolbar.ToolbarItems[DiagramViewDialog.INDEX_BUTTON_PROBLEMPATH].Enabled;
            Utilities.LogMessage(currentMethod + ":: Found value for component \"" + component + "\" to be: " + value + " expecting: " + expectedValue);

            for (int i = 1; i < maxRetry && value != expectedValue; i++)
            {
                Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond * 20);

                // Refresh Diagram View.
                DiagramViewDialogWindow.SendKeys(Core.Common.KeyboardCodes.F5);
                //DiagramViewDialogWindow.SendKeys(Core.Common.KeyboardCodes.RightArrow);
                //DiagramViewDialogWindow.SendKeys(Core.Common.KeyboardCodes.LeftArrow);
                CoreManager.MomConsole.Waiters.WaitForWindowIdle(DiagramViewDialogWindow, Constants.OneMinute);

                // Find component after refresh.
                DiagramViewDialogWindow.Controls.ViewToolbar.ToolbarItems[DiagramViewDialog.INDEX_BUTTON_FIND].Click();
                findInstance = new Mom.Test.UI.Core.Console.ServiceDiagram.FindNodeDialog(CoreManager.MomConsole);
                findInstance.FindWhatText = component;
                findInstance.WaitForResponse(Constants.OneMinute);
                findInstance.ClickFind();
                CoreManager.MomConsole.Waiters.WaitForWindowIdle(DiagramViewDialogWindow, Constants.OneMinute);

                // Get Problem Path UI Element State.
                value = DiagramViewDialogWindow.Controls.ViewToolbar.ToolbarItems[DiagramViewDialog.INDEX_BUTTON_PROBLEMPATH].Enabled;
                Utilities.LogMessage(currentMethod + ":: Found value for component \"" + component + "\" to be: " + value + " in retry # " + i + " expecting: " + expectedValue);

                // Breaking the rules here... taking a screenshot in core code. This is absolutely necessary as 
                // we've had quite a few issues with this diagram view code and it is difficult to debug.
                Utilities.TakeScreenshot(currentMethod + "_DiagramView_Retry_" + i);
            }

            //if expected value matches actual value then return true
            if (value == expectedValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Open Distributed Application view in Monitoring Space
        /// </summary>
        /// <param name="distributedApplicationName">Distributed Application name</param>
        /// <param name="viewName">View name</param>
        private void OpenView(string distributedApplicationName, string viewName)
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");

            //navigate to DA on monitoring space
            Utilities.LogMessage(currentMethod + ":: Navigating to DA in Monitoring Space");
            CoreManager.MomConsole.NavigationPane.SelectNode(
                NavigationPane.Strings.Monitoring
                + Constants.PathDelimiter
                + NavigationPane.Strings.MonConfigTreeViewServices,
                NavigationPane.NavigationTreeView.Monitoring);

            //right click on it and open diagram view
            Utilities.LogMessage(currentMethod + ":: Opening View: " + viewName);
            CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
            Core.Console.MomControls.GridControl viewGrid = CoreManager.MomConsole.ViewPane.Grid;
            Maui.Core.WinControls.DataGridViewRow distributedApplicationRow = viewGrid.FindData(distributedApplicationName, Core.Console.ViewPane.Strings.AdministrationGridViewColumnName);

            //retry incase grid is not populated in first attempt
            if (null == distributedApplicationRow)
            {
                Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond * 10);
                CoreManager.MomConsole.Refresh();
                distributedApplicationRow = viewGrid.FindData(distributedApplicationName, Core.Console.ViewPane.Strings.AdministrationGridViewColumnName);
            }

            //Right clicking first column in grid and opening view
            Utilities.LogMessage(currentMethod + ":: Clicking View");
            distributedApplicationRow.Cells[0].AccessibleObject.Click();
            CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, Constants.OneMinute);
            CoreManager.MomConsole.ExecuteContextMenu(Mom.Test.UI.Core.Console.Views.Views.Strings.OpenContextMenu +
                                                      Constants.PathDelimiter + viewName.Replace("&", ""),
                                                      true);

            Utilities.LogMessage(currentMethod + ":: end");
        }

        /// <summary>
        /// Close Diagram View
        /// </summary>
        private void CloseDiagramViewDialog()
        {
            string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.LogMessage(currentMethod + ":: start");

            if (this.cachedDiagramViewDialog != null)
            {
                CoreManager.MomConsole.Waiters.WaitForWindowIdle(DiagramViewDialogWindow, Constants.OneMinute);
                //  [v-yoz] 15OCT09   Maui 2.0 Required change: ClickTitleBarClose() method does not 
                //                      work to close the pivoted window. Need to investigate further could be
                //                      an RPF bug - using it fails with:
                //                      "Internal failure: GetUIElementFromPoint didn't return S_OK The handle is invalid."
                //                      Changed this to close the open window with Extended.CloseWindow() method.

                DiagramViewDialogWindow.Extended.CloseWindow(); //DiagramViewDialogWindow.ClickTitleBarClose();                

                this.cachedDiagramViewDialog = null;
            }

            Utilities.LogMessage(currentMethod + ":: end");
        }

        #endregion
    }
}
