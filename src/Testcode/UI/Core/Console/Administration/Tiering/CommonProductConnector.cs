//-------------------------------------------------------------------
// <copyright file="CommonConnectedFramework.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//   Common method to Product Connector framework
// </summary>
//  <history>
//  [v-yoz] 2JULY09:  Created
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.Administration.Tiering
{
    #region Using directives

    using System;
    using Infra.Frmwrk;
    using Maui.GlobalExceptions;
    using Maui.Core;
    using Mom.Test.UI.Core;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;
    using Microsoft.EnterpriseManagement;
    using Microsoft.EnterpriseManagement.ConnectorFramework;

    #endregion

    /// <summary>
    /// Class for CommonProductConnector
    /// </summary>
    public class CommonProductConnector
    {
        #region Member Variables

        #endregion

        #region Private Method

        #endregion

        #region Public Method

        /// <summary>
        /// InsertProductConnector : Insert a product connector to MG
        /// </summary>
        /// <param name="connectorName">
        /// The name of product connector that need be added.
        /// </param>
        /// <param name="connectorDescription">
        /// The description of product connector that need be added.
        /// </param>
        /// <param name="connectorID">
        /// The ID of product connector that need be added.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if both name
        /// is null or empty string.
        /// </exception>
        public static void InsertProductConnector(string connectorName, string connectorDescription, Guid connectorID)
        {
            Core.Common.Utilities.LogMessage("InsertProductConnector:: ");

            // check for valid parameters
            if (String.IsNullOrEmpty(connectorName))
            {
                throw new System.ArgumentNullException(
                    "Product connector Name parameter must not be null or empty string!");
            }

            ManagementGroup mg = new ManagementGroup(Core.Common.Utilities.MomServerName);
            
            ConnectorInfo conn = new ConnectorInfo();

            conn.Description = connectorDescription;
            conn.DisplayName = connectorName;
            conn.Name = connectorName;

            RemoveProductConnector(connectorID);

            mg.ConnectorFramework.Setup(conn, connectorID);
        }

        /// <summary>
        /// RemoveProductConnector : Remove a product connector from MG
        /// </summary>        
        /// <param name="connectorID">
        /// The ID of product connector that need be deleted.
        /// </param>
        public static void RemoveProductConnector(Guid connectorID)
        {
            Core.Common.Utilities.LogMessage("RemoveProductConnector:: ");

            ManagementGroup mg = new ManagementGroup(Core.Common.Utilities.MomServerName);

            ConnectorInfo conn = new ConnectorInfo();

            try
            {
                Microsoft.EnterpriseManagement.ConnectorFramework.MonitoringConnector monitorConnector = mg.ConnectorFramework.GetConnector(connectorID);
                mg.ConnectorFramework.Cleanup(monitorConnector);
            }
            catch (Microsoft.EnterpriseManagement.Common.ObjectNotFoundException)
            {
                Core.Common.Utilities.LogMessage("RemoveProductConnector::Not found the product connector = " +
                    connectorID.ToString());
            }
        }

        /// <summary>
        /// IsProductConnectorExist - verify if a product connector is exist
        /// </summary>
        /// <param name="connectorName">
        /// The name of product connector that need be verified.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws System.ArgumentNullException if both name
        /// is null or empty string.
        /// </exception>
        public static bool IsProductConnectorExist(string connectorName)
        {
            Core.Common.Utilities.LogMessage("VerifyProductConnectorCreated:: ");

            // check for valid parameters
            if (String.IsNullOrEmpty(connectorName))
            {
                throw new System.ArgumentNullException(
                    "Product connector Name parameter must not be null or empty string!");
            }

            MomConsoleApp app = CoreManager.MomConsole;

            Core.Common.Utilities.LogMessage("VerifyProductConnectorCreated::Navigator to Internal Connectors view in the Administration space.");

            // Navigator to Internal Connectors view in the Administration space
            app.NavigationPane.SelectNode(NavigationPane.Strings.AdminTreeViewProductConnectors, NavigationPane.NavigationTreeView.Administration);

            // Try to find the connector that is created previously with name
            int maxTries = 5;
            Maui.Core.WinControls.DataGridViewRow connectorRow = null;
            int attempt = 0;
            while (null == connectorRow && attempt++ < maxTries)
            {
                // refresh the view
                app.ViewPane.Grid.Click();
                app.ViewPane.Grid.SendKeys(
                    Core.Common.KeyboardCodes.F5);

                Core.Common.Utilities.LogMessage(
                    "VerifyProductConnectorCreated::Finding product connect row with name := '" +
                    connectorName +
                    "'" +
                    " Retry times := " +
                    attempt);

                CoreManager.MomConsole.Waiters.WaitForStatusReady(Constants.OneMinute);

                // select the connector in the grid view
                connectorRow =
                    app.ViewPane.Grid.FindData(
                        connectorName);

                Maui.Core.Utilities.Sleeper.Delay(
                        Core.Common.Constants.OneSecond);
            }
            // check for valid row
            if (null == connectorRow)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        #endregion
    }
}
