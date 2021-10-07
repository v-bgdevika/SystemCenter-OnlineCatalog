//-------------------------------------------------------------------
// <copyright file="PendingActionsView.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   PendingActionsView support
// </summary>
//  <history>
//   [v-waltli] 01APR09: Created
//                       Added ProcessManualAgentInstallation function
//                       Added IsAgentInView function
//                       Added resource strings for Manual Agent Install Dialog title
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.DeviceDiscovery
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    using Mom.Test.UI.Core.Common;
    using Infra.Frmwrk;
    using Maui.Core.WinControls;
    using System.IO;

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Pending Actions View Helper
    /// </summary>
    /// -----------------------------------------------------------------------------
    public class PendingActionsViewHelper
    {
        #region Constants

        /// <summary>
        /// Refresh view interval in seconds
        /// </summary>
        private const int RefreshInterval = 30;

        /// <summary>
        /// Max retry to search agent row in grid view
        /// </summary>
        private const int MaxRetry = 120;

        /// <summary>
        /// Sleep time to wait for agent appearing in grid view
        /// </summary>
        private const int Timeout = 5;

        #endregion // Constants

        #region Enums

        /// <summary>
        /// Types of processing manually installed agent in pending actions view
        /// </summary>
        public enum ManualAgentInstallationProcessType
        {
            /// <summary>
            /// Approve
            /// </summary>
            APPROVE,
            /// <summary>
            /// Reject
            /// </summary>
            REJECT,
            /// <summary>
            /// First Reject then Cancel
            /// </summary>
            CANCEL_REJECT
        }

        /// <summary>
        /// Types of view that manually installed agent appears in or disappears from
        /// </summary>
        public enum ViewType
        {
            /// <summary>
            /// Pending actions view
            /// </summary>
            PENDING_ACTIONS_VIEW,
            /// <summary>
            /// Agent Managed view
            /// </summary>
            AGENT_MANAGED_VIEW
        }

        #endregion // Enums

        #region Members

        /// <summary>
        /// Current method name
        /// </summary>
        private static string currentMethodName = String.Empty;

        #endregion // Members

        #region Public Methods

        #region ProcessManualAgentInstallation

        /// <summary>
        /// Wait for agent appearing in pending actions view. 
        /// Then select the agent row and pop up agent install dialog.
        /// Then process the manually installed agent according to process type provided.
        /// </summary>
        /// <param name="agentName">Agent's name to be processed</param>
        /// <param name="processType">
        /// Type of processing manually installed agent in pending actions view
        /// </param>
        /// <exception cref="DataGridView.Exceptions.DataGridViewRowNotFoundException">
        /// Throw DataGridView.Exceptions.DataGridViewRowNotFoundException if agent isn't found in pending actions view
        /// </exception>
        /// <exception cref="System.NotImplementedException">
        /// Throws System.NotImplementedException if process type is not supported
        /// </exception>
        /// <history>                
        /// [v-waltli] 03April09  Created  
        /// </history>
        public static void ProcessManualAgentInstallation(
            string agentName,
            ManualAgentInstallationProcessType processType)
        {
            string currentMethodName = MethodBase.GetCurrentMethod().Name;
            Core.Common.Utilities.LogMessage(currentMethodName + "...");
            ProcessManualAgentInstallation(agentName, processType, RefreshInterval, MaxRetry, Timeout);
        }

        /// <summary>
        /// Wait for agent appearing in pending actions view. 
        /// Then select the agent row and pop up agent install dialog.
        /// Then process the manually installed agent according to process type provided.
        /// </summary>
        /// <param name="agentName">Agent's name to be processed</param>
        /// <param name="processType">
        /// Type of processing manually installed agent in pending actions view
        /// </param>
        /// <param name="refreshInterval">
        /// Refresh view interval in seconds
        /// </param>
        /// <param name="maxRetry">
        /// Max retry to search agent row in grid view
        /// </param>
        /// <param name="timeout">
        /// Sleep time to wait for agent appearing in grid view
        /// </param>
        /// <exception cref="DataGridView.Exceptions.DataGridViewRowNotFoundException">
        /// Throw DataGridView.Exceptions.DataGridViewRowNotFoundException if agent isn't found in pending actions view
        /// </exception>
        /// <exception cref="System.NotImplementedException">
        /// Throws System.NotImplementedException if process type is not supported
        /// </exception>
        /// <history>                
        /// [v-waltli] 03April09  Created  
        /// </history>
        public static void ProcessManualAgentInstallation(
            string agentName,
            ManualAgentInstallationProcessType processType,
            int refreshInterval,
            int maxRetry,
            int timeout)
        {
            string currentMethodName = MethodBase.GetCurrentMethod().Name;
            Core.Common.Utilities.LogMessage(currentMethodName + "...");

            // Agent row appeared in grid view
            DataGridViewRow agentGridViewRow = null;

            Core.Common.Utilities.LogMessage(currentMethodName + ":: Waiting for agent appearing in pending actions view");
            if (!IsAgentInView(agentName,
                ViewType.PENDING_ACTIONS_VIEW,
                true,
                ref agentGridViewRow,
                refreshInterval,
                maxRetry,
                timeout))
            {
                throw new DataGridView.Exceptions.DataGridViewRowNotFoundException(currentMethodName + ":: Could not find agent in Pending Actions View!");
            }

            Core.Common.Utilities.LogMessage(currentMethodName + ":: Clicking the agent row to select it");
            agentGridViewRow.Click();

            Core.Common.Utilities.LogMessage(currentMethodName + ":: Launching the context menu for the agent");

            //Context menu
            string contextMenu = String.Empty;

            // Get context menu accoring to process type
            switch (processType)
            {
                case ManualAgentInstallationProcessType.APPROVE:
                    // Approve menu for Approve process
                    contextMenu =
                        ViewPane.Strings.AdministrationContextMenuApprove;
                    break;
                case ManualAgentInstallationProcessType.REJECT:
                case ManualAgentInstallationProcessType.CANCEL_REJECT:
                    // Reject menu for Reject and Cancel Reject process
                    contextMenu =
                        ViewPane.Strings.AdministrationContextMenuReject;
                    break;
                default:
                    throw new NotImplementedException("This process type is not supported: " + processType.ToString());
            }

            // Launch the context menu
            Maui.Core.WinControls.Menu agentContextMenu = null;
            Maui.Core.WinControls.MenuItem item = null;
            int maxRetryNum = 3;
            int retry = 1;
            Core.Common.Utilities.LogMessage(currentMethodName + "::  Try to find MenuItem := " + contextMenu + "...");
            Core.Common.Utilities.LogMessage(currentMethodName + "::  Max retry attempt := " + maxRetryNum + ".");
            while (retry <= maxRetryNum)
            {
                try
                {
                    Core.Common.Utilities.LogMessage(currentMethodName + ":: Attempt " + retry + " of " + maxRetryNum);
                    if (agentContextMenu == null)
                    {
                        agentContextMenu =
                            new Maui.Core.WinControls.Menu(
                                Maui.Core.WinControls.ContextMenuAccessMethod.ShiftF10);
                    }
                    
                    item = new MenuItem(agentContextMenu, contextMenu);
                    break;
                }
                catch 
                {
                    retry++;
                    Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond * 1);
                    agentGridViewRow.Click();
                }
            }
            

            // Check the item is not null
            if (item != null)
            {
                Core.Common.Utilities.LogMessage(currentMethodName + "::  the context menu item: " + item.Text);

                // Check items are enable
                if (item.Enabled)
                {
                    // Execute the context menu item
                    item.Execute();
                }
                else
                {
                    //re-launch the context menu
                    CoreManager.MomConsole.ViewPane.SendKeys(Core.Common.KeyboardCodes.Esc);
                    agentContextMenu = new Maui.Core.WinControls.Menu(Maui.Core.WinControls.ContextMenuAccessMethod.ShiftF10);
                    item = new MenuItem(agentContextMenu, contextMenu);
                    if (item != null && item.Enabled)
                    {
                        // Execute the context menu item
                        item.Execute();
                    }
                    else
                    {
                        throw new Maui.GlobalExceptions.MauiException("The context Menu Item is not enabled.");
                    }
                }
            }
            else
            {
                throw new Maui.Core.WinControls.Menu.Exceptions.ItemNotFoundException("The context menu item not found! ");
            }
            
            Core.Common.Utilities.LogMessage(currentMethodName + ":: Clicking button in Manual Agent Install dialog");
            // Click button in manual agent install dialog according to process type
            switch (processType)
            {
                case ManualAgentInstallationProcessType.APPROVE:
                    // Click Approve button for Approve process
                    CoreManager.MomConsole.ConfirmChoiceDialog(
                        MomConsoleApp.ButtonCaption.Approve,
                        Strings.ManualAgentInstallDialogTitle,
                        Maui.Core.Utilities.StringMatchSyntax.ExactMatch,
                        MomConsoleApp.ActionIfWindowNotFound.Error);
                    break;
                case ManualAgentInstallationProcessType.REJECT:
                    // Click Reject button for Reject process
                    CoreManager.MomConsole.ConfirmChoiceDialog(
                        MomConsoleApp.ButtonCaption.Reject,
                        Strings.ManualAgentInstallDialogTitle,
                        Maui.Core.Utilities.StringMatchSyntax.ExactMatch,
                        MomConsoleApp.ActionIfWindowNotFound.Error);
                    break;
                case ManualAgentInstallationProcessType.CANCEL_REJECT:
                    // Click Cancel button for Cencel Reject process
                    CoreManager.MomConsole.ConfirmChoiceDialog(
                        MomConsoleApp.ButtonCaption.Cancel,
                        Strings.ManualAgentInstallDialogTitle,
                        Maui.Core.Utilities.StringMatchSyntax.ExactMatch,
                        MomConsoleApp.ActionIfWindowNotFound.Error);
                    break;
                default:
                    throw new NotImplementedException("This process type is not supported: " + processType.ToString());
            }

            Core.Common.Utilities.LogMessage(currentMethodName + ":: Waiting for Console status ready");
            // Make sure the Console status is ready
            CoreManager.MomConsole.Waiters.WaitForStatusReady(
                Constants.DefaultDialogTimeout);
        }

        #endregion // ProcessManualAgentInstallation

        #region IsAgentInView

        /// <summary>
        /// Wait for agent appearing in or disappearing from the view as expectation using prefix match.
        /// Then return true if agent appeared in the view.
        /// Once the agent appeared or disappeared as expcetation, the wait loop will break, other wise the loop will continue until max wait time reached ,which is about 10 minutes.
        /// If agent appeared, it will also assign the agent row reference to the agentRow parameter.
        /// </summary>
        /// <param name="agentName">Agent's name to be waited for</param>
        /// <param name="viewType">
        /// View type for agent to appear in or disappear from.
        /// The view must be either Pending Actions View or Agent Managed View.
        /// </param>
        /// <param name="expectedIsAgentInView">
        /// True if agent is expected to appear in view
        /// </param>
        /// <param name="agentRow">
        /// Agent row reference to be assigned to if it appeared in view
        /// </param>
        /// <returns>True if agent appeared in view</returns>
        /// <exception cref="System.NotImplementedException">
        /// Throws System.NotImplementedException if view type is not supported
        /// </exception>
        /// <history>                
        /// [v-waltli] 03April09  Created  
        /// </history>
        public static bool IsAgentInView(
            string agentName,
            ViewType viewType,
            bool expectedIsAgentInView,
            ref DataGridViewRow agentRow)
        {
            string currentMethodName = MethodBase.GetCurrentMethod().Name;
            Core.Common.Utilities.LogMessage(currentMethodName + "...");

            int refreshInterval = RefreshInterval;
            int maxRetry = MaxRetry;
            int timeout = Timeout;

            //[v-frma] 2011.11.07 the rejected agent will appear in Pending Management in 30s, so shorten the refreshInterval and maxRetry
            if (viewType == ViewType.PENDING_ACTIONS_VIEW && !expectedIsAgentInView )
            {
                refreshInterval = 10;
                maxRetry = 2;
                timeout = 5;
            }
            return IsAgentInView(agentName, viewType, expectedIsAgentInView, ref agentRow, refreshInterval, maxRetry, timeout);
        }

        /// <summary>
        /// Wait for agent appearing in or disappearing from the view as expectation using prefix match.
        /// Then return true if agent appeared in the view.
        /// Once the agent appeared or disappeared as expcetation, the wait loop will break, other wise the loop will continue until max wait time reached ,which is about 10 minutes.
        /// If agent appeared, it will also assign the agent row reference to the agentRow parameter.
        /// </summary>
        /// <param name="agentName">Agent's name to be waited for</param>
        /// <param name="viewType">
        /// View type for agent to appear in or disappear from.
        /// The view must be either Pending Actions View or Agent Managed View.
        /// </param>
        /// <param name="expectedIsAgentInView">
        /// True if agent is expected to appear in view
        /// </param>
        /// <param name="agentRow">
        /// Agent row reference to be assigned to if it appeared in view
        /// </param>
        /// <param name="refreshInterval">
        /// Refresh view interval in seconds
        /// </param>
        /// <param name="maxRetry">
        /// Max retry to search agent row in grid view
        /// </param>
        /// <param name="timeout">
        /// Sleep time to wait for agent appearing in grid view
        /// </param>
        /// <returns>True if agent appeared in view</returns>
        /// <exception cref="System.NotImplementedException">
        /// Throws System.NotImplementedException if view type is not supported
        /// </exception>
        /// <history>                
        /// [v-waltli] 03April09  Created  
        /// </history>
        public static bool IsAgentInView(
            string agentName,
            ViewType viewType,
            bool expectedIsAgentInView,
            ref DataGridViewRow agentRow,
            int refreshInterval,
            int maxRetry,
            int timeout)
        {
            string currentMethodName = MethodBase.GetCurrentMethod().Name;
            Core.Common.Utilities.LogMessage(currentMethodName + "...");

            //[v-frma] 2011.11.07 the rejected agent will appear in Pending Management in 30s, so It should not select the node and verify in current view( for it will cost a lot time )
            if (!(viewType == ViewType.PENDING_ACTIONS_VIEW && !expectedIsAgentInView))
            {
                //Resource string of view name to be searched according to view name type
                string viewName = string.Empty;
                switch (viewType)
                {
                    case ViewType.AGENT_MANAGED_VIEW:
                        // Resource string of Agent Managed view
                        viewName = NavigationPane.Strings.AdminTreeViewAgentManagedComputers;
                        break;
                    case ViewType.PENDING_ACTIONS_VIEW:
                        // Resource string of Pending Actions View
                        viewName = NavigationPane.Strings.AdminTreeViewPendingManagement;
                        break;
                    default:
                        throw new NotImplementedException("This view type is not supported: " + viewType.ToString());
                }
                Core.Common.Utilities.LogMessage(currentMethodName + ":: View name := '" + viewName + "'");

                // View node full path
                string viewNodeFullPath =
                    NavigationPane.Strings.AdminTreeViewAdministrationRoot
                    + "\\"
                    + NavigationPane.Strings.AdminTreeViewDeviceManagement
                    + "\\"
                    + viewName;

                Core.Common.Utilities.LogMessage(currentMethodName + ":: Looking for tree view node path := '" + viewNodeFullPath + "'");

                Mom.Test.UI.Core.Common.Utilities.LogMessage(currentMethodName + ":: Navigating to the specified view");
                // Navigate to the specified view
                CoreManager.MomConsole.NavigationPane.SelectNode(
                    viewNodeFullPath,
                    NavigationPane.NavigationTreeView.Administration);

                Core.Common.Utilities.LogMessage(currentMethodName + ":: Waiting for Console status ready");
                // Make sure the Console status is ready
                CoreManager.MomConsole.Waiters.WaitForStatusReady();
            }

            // Column name to be searched according to view type
            string columnNameSearched = string.Empty;

            // Get column name to be searched according to view type
            switch (viewType)
            {
                case ViewType.AGENT_MANAGED_VIEW:
                    // Column name is FQDN for Agent Managed View
                    columnNameSearched = ViewPane.Strings.AdministrationGridViewColumnFqdnName;
                    break;
                case ViewType.PENDING_ACTIONS_VIEW:
                    // Column name is Name for Pending Actions View
                    columnNameSearched = ViewPane.Strings.AdministrationGridViewColumnName;
                    break;
                default:
                    throw new NotImplementedException("This view type is not supported: " + viewType.ToString());
            }

            #region Loop to check for agent appearing in or disappearing from the view

            // Loop to check for agent appearing in or disappearing from the view within 10 minutes
            // If it appeared or disappeared as expectation then break loop
            if (expectedIsAgentInView)
            {
                Core.Common.Utilities.LogMessage(currentMethodName + ":: Looping to check for agent appearing in the view...");
            }
            else
            {
                Core.Common.Utilities.LogMessage(currentMethodName + ":: Looping to check for agent disappearing from the view...");
            }

            Core.Common.Utilities.LogMessage(currentMethodName + ":: Max retry attempt := " + (maxRetry + 1));

            for (int currentAttempt = 0;
                currentAttempt < maxRetry;
                currentAttempt++)
            {
                Core.Common.Utilities.LogMessage(currentMethodName + ":: Current retry attempt := " + (currentAttempt + 1));


                Core.Common.Utilities.LogMessage(currentMethodName + ":: Finding data row using prefix match");
                // Find data row 
                agentRow =
                    CoreManager.MomConsole.ViewPane.Grid.FindData(agentName,
                    columnNameSearched,
                    Mom.Test.UI.Core.Console.MomControls
                    .GridControl.SearchStringMatchType.PrefixMatch);

                // If expecting the agent to disappear and agent row is null, then it's the expected result, so break the loop;
                // If expecting the agent to appear and agent row is not null, then it's the expected result too, so break the loop too
                if ((!expectedIsAgentInView && agentRow == null)
                    || (expectedIsAgentInView && agentRow != null))
                {
                    break;
                }

                // Check if current attempt matches the refresh interval.
                // If haven't gotten expected result for several times, then refesh the view
                if ((timeout * currentAttempt) % refreshInterval == 0)
                {
                    Core.Common.Utilities.LogMessage(currentMethodName + ":: Refreshing the view by sending F5");
                    // Refresh the view
                    CoreManager.MomConsole.ViewPane.SendKeys(
                        Core.Common.KeyboardCodes.F5);

                    Core.Common.Utilities.LogMessage(currentMethodName + ":: Waiting for Console status ready");
                    // Make sure the Console status is ready
                    CoreManager.MomConsole.Waiters.WaitForStatusReady();
                }
                Core.Common.Utilities.LogMessage(currentMethodName + ":: Waiting some seconds := " + timeout);
                // Wait some seconds
                Maui.Core.Utilities.Sleeper.Delay(Constants.OneSecond * timeout);
            }

            #endregion // Loop to check for agent appearing in or disappearing from the view

            //Check if agent appeared in view
            bool agentAppearedInView;
            if (agentRow == null)
            {
                agentAppearedInView = false;
            }
            else
            {
                agentAppearedInView = true;
            }

            return agentAppearedInView;
        }

        #endregion // IsAgentInView

        #endregion // Public Methods

        #region Strings Class
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Method to return translated resource string for Manual Agent Install Dialog title and Confirm Delete Monitoring Agent dialog title
        /// </summary>
        /// <history> 	
        ///   [v-waltli] 09Apr09: Added resource strings for Manual Agent Install Dialog title
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings 
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Manual Agent Install dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceManualAgentInstallDialogTitle = ";Manual Agent Install;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;PendingManualAgent";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for the Confirm Delete Monitoring Agent dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfirmDeleteMonitoringAgentDialogTitle = ";Confirm Delete Monitoring Agent;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.AdminResources;AgentDeleteTitle";
            
            #endregion // Constants

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Manual Agent Install dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedManualAgentInstallDialogTitle;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the Confirm Delete Monitoring Agent dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfirmDeleteMonitoringAgentDialogTitle;

            #endregion // Private Members

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ManualAgentInstallDialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 09Apr09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ManualAgentInstallDialogTitle
            {
                get
                {
                    if ((cachedManualAgentInstallDialogTitle == null))
                    {
                        cachedManualAgentInstallDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceManualAgentInstallDialogTitle);
                    }

                    return cachedManualAgentInstallDialogTitle;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the ConfirmDeleteMonitoringAgentDialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 09Apr09 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfirmDeleteMonitoringAgentDialogTitle
            {
                get
                {
                    if ((cachedConfirmDeleteMonitoringAgentDialogTitle == null))
                    {
                        cachedConfirmDeleteMonitoringAgentDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceConfirmDeleteMonitoringAgentDialogTitle);
                    }

                    return cachedConfirmDeleteMonitoringAgentDialogTitle;
                }
            }

            #endregion // Properties
        }

        #endregion // Strings Class
    }
}