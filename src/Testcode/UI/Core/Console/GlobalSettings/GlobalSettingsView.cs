// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="GlobalSettingsView.cs">
// 	Copyright (c) Microsoft Corporation 2006
// </copyright>
// <project>
// 	MOMv3
// </project>
// <summary>
// 	MOMv3 UI Test Automation
// </summary>
// <history>
// 	[KellyMor]  17-Apr-06   Created
//  [KellyMor]  24-Apr-06   Added methods to set manual agent install policy
//                          Added methods to enable/disable email notifications
//  [KellyMor] 07-Jun-06    Updated resource assembly for new Admin assembly
// </history>
// -----------------------------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console.GlobalSettings
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;

    /// ---------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the Global Settings view and provide utility functions
    /// </summary>
    /// ---------------------------------------------------------------------------
    public class GlobalSettingsView
    {
        #region Public Static Methods

        #region Notifications
        /// <summary>
        /// Method to set managements server global setting to accept or
        /// reject manual agent installations.
        /// </summary>
        /// <param name="rejectManualAgents">
        /// Flag indicating whether or not to reject new manual agents.
        /// </param>
        /// <exception cref="Maui.GlobalExceptions.MauiException">
        /// Can throw any Maui exception that derives from MauiException,
        /// e.g. WindowNotFoundException.
        /// </exception>
        public static void SetManualAgentSecurity(bool rejectManualAgents)
        {
            GlobalSettingsView.SetManualAgentSecurity(rejectManualAgents, false);
        }

        /// <summary>
        /// Method to set managements server global setting to accept or
        /// reject manual agent installations.
        /// </summary>
        /// <param name="rejectManualAgents">
        /// Flag indicating whether or not to reject new manual agents.
        /// </param>
        /// <param name="autoApprove">
        /// Flag indicating if new manual agents should be automatically approved and
        /// accepted as valid agents in the management group.
        /// </param>
        /// <exception cref="Maui.GlobalExceptions.MauiException">
        /// Can throw any Maui exception that derives from MauiException,
        /// e.g. WindowNotFoundException.
        /// </exception>
        public static void SetManualAgentSecurity(bool rejectManualAgents, bool autoApprove)
        {
            // select the "Administration" wunderbar button
            Core.Common.Utilities.LogMessage("GlobalSettingsView::SetManualAgentPolicy::Navigating to Administration view...");

            // navigate to the administration view
            CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(
                NavigationPane.WunderBarButton.Administration);

            // navigate to the global settings view
            CoreManager.MomConsole.NavigationPane.SelectNode(
                NavigationPane.Strings.Administration +
                Mom.Test.UI.Core.Common.Constants.PathDelimiter +
                NavigationPane.Strings.AdminTreeViewSettings);

            // get a reference to the view
            Core.Console.MomControls.GridControl settingsGrid =
                    CoreManager.MomConsole.ViewPane.Grid;
            settingsGrid.ScreenElement.WaitForReady();

            Core.Common.Utilities.LogMessage("GlobalSettingsView::SetManualAgentPolicy::Looking for 'Notifications' item in the grid...");

            // find the Notifications item in the grid view
            Maui.Core.WinControls.DataGridViewRow serverSecurityRow =
                settingsGrid.FindData(
                    Core.Console.GlobalSettings.GlobalSettingsView.Strings.ServerSecurity);

            Mom.Test.UI.Core.Console.GlobalSettings.ServerSecurityDialog serverSecuritySettingsDialog = null;

            // select the Notifications item in the grid view
            if (null != serverSecurityRow)
            {
                Core.Common.Utilities.LogMessage("GlobalSettingsView::SetManualAgentPolicy::Starting 'Security' dialog...");

                settingsGrid.ScrollToRow(serverSecurityRow.AccessibleObject.Index);
                // start the dialog
                serverSecurityRow.AccessibleObject.Click(MouseClickType.DoubleClick);

                // find the Notifications dialog
                serverSecuritySettingsDialog =
                    new Mom.Test.UI.Core.Console.GlobalSettings.ServerSecurityDialog(
                        CoreManager.MomConsole);
                UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow);
                UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow);

                // set the manual agent reject/accept option
                if (true == rejectManualAgents)
                {
                    Core.Common.Utilities.LogMessage("GlobalSettingsView::SetManualAgentPolicy::Reject new manual agents...");

                    // reject manual agents
                    serverSecuritySettingsDialog.Controls.RejectNewManualAgentInstallationsRadioButton.Click();
                }
                else
                {
                    Core.Common.Utilities.LogMessage("GlobalSettingsView::SetManualAgentPolicy::Accept new manual agents...");

                    // accept new manual agents
                    serverSecuritySettingsDialog.Controls.AcceptNewManualAgentInstallationsRadioButton.Click();

                    // if necessary set the auto-approve option
                    if (true == autoApprove)
                    {
                        Core.Common.Utilities.LogMessage("GlobalSettingsView::SetManualAgentPolicy::Auto-approve new manual agents...");

                        // set the check box to auto approve new agents
                        serverSecuritySettingsDialog.ClickAutoApproveNewManuallyInstalledAgents();
                        serverSecuritySettingsDialog.Controls.AutoApproveNewManuallyInstalledAgentsCheckBox.ButtonState = ButtonState.Checked;
                        serverSecuritySettingsDialog.Controls.AutoApproveNewManuallyInstalledAgentsCheckBox.Checked = true;
                    }
                    else
                    {
                        Core.Common.Utilities.LogMessage("GlobalSettingsView::SetManualAgentPolicy::Do not auto-approve new manual agents...");

                        // uncheck the box to auto approve new agents
                        serverSecuritySettingsDialog.ClickAutoApproveNewManuallyInstalledAgents();
                        serverSecuritySettingsDialog.Controls.AutoApproveNewManuallyInstalledAgentsCheckBox.ButtonState = ButtonState.UnChecked;
                        serverSecuritySettingsDialog.Controls.AutoApproveNewManuallyInstalledAgentsCheckBox.Checked = false;
                    }
                }

                Core.Common.Utilities.LogMessage("GlobalSettingsView::SetManualAgentPolicy::Commit the change in policy...");

                // click OK
                serverSecuritySettingsDialog.ClickOK();
            }
            else
            {
                throw new Maui.GlobalExceptions.MauiException(
                    "Failed to find the 'Security' item in the view!");
            }

        }

        /// <summary>
        /// Method to disable email notifiations
        /// </summary>
        public static void DisableEmailNotifications()
        {
            EmailNotificationDialog emailSettingsDialog = null;

            #region Navigate to Settings view

            Core.Common.Utilities.LogMessage(
                "GlobalSettingsView::DisableEmailNotifications::" +
                "Clicking 'Administration' wunderbar button...");

            // Navigate to Settings view
            CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(
                NavigationPane.WunderBarButton.Administration);

            // add the path prefix to the view name
            StringBuilder pathToView = new StringBuilder();
            pathToView.Append(
                NavigationPane.Strings.AdminTreeViewAdministrationRoot);
            pathToView.Append("\\");
            pathToView.Append(
                NavigationPane.Strings.AdminTreeViewSettings);

            Core.Common.Utilities.LogMessage(
                "GlobalSettingsView::DisableEmailNotifications::" + 
                "Navigating tree view to 'Settings' view...");

            // get the treeview node
            Maui.Core.WinControls.TreeNode settingsNode =
                CoreManager.MomConsole.NavigationPane.SelectNode(
                    pathToView.ToString(),
                    NavigationPane.NavigationTreeView.Administration);

            // select the node
            settingsNode.Select();
            settingsNode.Click();

            // get a reference to the view
            Core.Console.MomControls.GridControl settingsGrid =
                    CoreManager.MomConsole.ViewPane.Grid;

            Core.Common.Utilities.LogMessage(
                "GlobalSettingsView::DisableEmailNotifications::" + 
                "Looking for 'Notifications' item in the grid...");

            // find the Notifications item in the grid view
            Maui.Core.WinControls.DataGridViewRow serverSecurityRow =
                settingsGrid.FindData(
                    GlobalSettingsView.Strings.Notifications);

            // select the Notifications item in the grid view
            if (null != serverSecurityRow)
            {
                Core.Common.Utilities.LogMessage(
                    "GlobalSettingsView::DisableEmailNotifications::" + 
                    "Starting 'Notifications' dialog...");
                
                // start the dialog
                serverSecurityRow.AccessibleObject.Click(
                    MouseClickType.DoubleClick);

                // find the Notifications dialog
                emailSettingsDialog = 
                    new EmailNotificationDialog(CoreManager.MomConsole);
            }
            else
            {
                throw new Maui.GlobalExceptions.MauiException(
                    "Failed to find the 'Notifications' item in the view!");
            }

            #endregion

            #region Disable Email Notifications

            // check the "Enable..." checkbox
            emailSettingsDialog.Controls.EnableEmailNotificationCheckBox.Click();
            emailSettingsDialog.Controls.EnableEmailNotificationCheckBox.Checked = false;
            emailSettingsDialog.Controls.EnableEmailNotificationCheckBox.ButtonState = ButtonState.UnChecked;

            // Click OK
            emailSettingsDialog.ClickOK();
            UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow);
            UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow);

            // drop the reference to the dialog
            emailSettingsDialog = null;

            #endregion
        }

        /// <summary>
        /// Method to enable email notifications.
        /// </summary>
        /// <param name="emailServer">
        /// The fully-qualified domain name of the email server
        /// </param>
        /// <param name="returnAddress">
        /// The return email address for notification emails
        /// </param>
        public static void EnableEmailNotifications(string emailServer, string returnAddress)
        {
            GlobalSettingsView.EnableEmailNotifications(
                emailServer,
                0,
                String.Empty,
                returnAddress,
                String.Empty,
                String.Empty,
                String.Empty);
        }

        /// <summary>
        /// Method to enable email notifications.
        /// </summary>
        /// <param name="emailServer">
        /// The fully-qualified domain name of the email server
        /// </param>
        /// <param name="emailPortNumber">
        /// The TCP port for SMTP communication
        /// </param>
        /// <param name="emailAuthenticationMethod">
        /// The authentication method for SMTP communication
        /// </param>
        /// <param name="returnAddress">
        /// The return email address for notification emails
        /// </param>
        /// <param name="emailSubjectText">
        /// The email subject text
        /// </param>
        /// <param name="emailMessageText">
        /// The email message text
        /// </param>
        /// <param name="emailEncoding">
        /// The encoding scheme for the email messages
        /// </param>
        public static void EnableEmailNotifications(
            string emailServer, 
            int emailPortNumber,
            string emailAuthenticationMethod,
            string returnAddress,
            string emailSubjectText,
            string emailMessageText,
            string emailEncoding)
        {
            #region Check Arguments

            // check the email server name parameter
            if (null == emailServer)
            {
                throw new ArgumentNullException("Email server name cannot be null!");
            }
            else if (emailServer.Equals(string.Empty))
            {
                throw new ArgumentException("Email server name cannot be emtpy!");
            }

            // check the port number for a valid TCP port number
            if ((emailPortNumber < 0) || (emailPortNumber > 65535))
            {
                throw new ArgumentOutOfRangeException("SMTP port number is not in the valid TCP port range!");
            }

            // check the return address parameter
            if (null == returnAddress)
            {
                throw new ArgumentNullException("Return email address cannot be null!");
            }
            else if (returnAddress.Equals(string.Empty))
            {
                throw new ArgumentException("Return email address cannot be emtpy!");
            }

            // check the email authentication method parameter
            if (null == emailAuthenticationMethod)
            {
                throw new ArgumentNullException("Email authentication method cannot be null!");
            }

            // check the email subject text parameter
            if (null == emailSubjectText)
            {
                throw new ArgumentNullException("Email subject text cannot be null!");
            }

            // check the email message text parameter
            if (null == emailMessageText)
            {
                throw new ArgumentNullException("Email message text cannot be null!");
            }

            // check the email encoding parameter
            if (null == emailEncoding)
            {
                throw new ArgumentNullException("Email encoding cannot be null!");
            }

            #endregion

            EmailNotificationDialog emailSettingsDialog = null;

            #region Navigate to Settings view

            Core.Common.Utilities.LogMessage(
                "GlobalSettingsView::EnableEmailNotifications::" + 
                "Clicking 'Administration' wunderbar button...");

            // Navigate to Settings view
            CoreManager.MomConsole.NavigationPane.ClickWunderBarButton(
                NavigationPane.WunderBarButton.Administration);

            // add the path prefix to the view name
            StringBuilder pathToView = new StringBuilder();
            pathToView.Append(NavigationPane.Strings.AdminTreeViewAdministrationRoot);
            pathToView.Append("\\");
            pathToView.Append(NavigationPane.Strings.AdminTreeViewSettings);

            Core.Common.Utilities.LogMessage(
                "GlobalSettingsView::EnableEmailNotifications::" + 
                "Navigating tree view to 'Settings' view...");

            // get the treeview node
            Maui.Core.WinControls.TreeNode settingsNode =
                CoreManager.MomConsole.NavigationPane.SelectNode(
                    pathToView.ToString(),
                    NavigationPane.NavigationTreeView.Administration);

            // get a reference to the view
            Core.Console.MomControls.GridControl settingsGrid =
                    CoreManager.MomConsole.ViewPane.Grid;

            Core.Common.Utilities.LogMessage(
                "GlobalSettingsView::EnableEmailNotifications::" + 
                "Looking for 'Notifications' item in the grid...");

            // find the Notifications item in the grid view
            Maui.Core.WinControls.DataGridViewRow notificationsRow =
                settingsGrid.FindData(
                    Core.Console.GlobalSettings.GlobalSettingsView.Strings.Notifications);

            // select the Notifications item in the grid view
            if (null != notificationsRow)
            {
                Core.Common.Utilities.LogMessage(
                    "GlobalSettingsView::EnableEmailNotifications::" + 
                    "Starting 'Notifications' dialog...");

                // start the dialog
                notificationsRow.AccessibleObject.Click(
                    MouseClickType.DoubleClick);
                
                // find the Notifications dialog
                emailSettingsDialog =
                    new EmailNotificationDialog(CoreManager.MomConsole);
            }
            else
            {
                throw new Maui.GlobalExceptions.MauiException(
                    "Failed to find the 'Notifications' item in the view!");
            }

            #endregion

            #region Enable Email Notifications

            Core.Common.Utilities.LogMessage(
                "GlobalSettingsView::EnableEmailNotifications::" +
                "Checking the 'Enable' checkbox...");

            // check the "Enable..." checkbox
            emailSettingsDialog.Controls.EnableEmailNotificationCheckBox.Click();
            emailSettingsDialog.Controls.EnableEmailNotificationCheckBox.Checked = true;
            emailSettingsDialog.Controls.EnableEmailNotificationCheckBox.ButtonState = ButtonState.Checked;

            #endregion

            #region Add SMTP Server

            Core.Common.Utilities.LogMessage(
                "GlobalSettingsView::EnableEmailNotifications::" +
                "Adding an SMTP server...");

            // set SMTP server
            emailSettingsDialog.ClickAdd();

            // look for the "Add SMTP Server dialog
            AddSmtpServerDialog addSmtpServer = 
                new AddSmtpServerDialog(CoreManager.MomConsole);

            Core.Common.Utilities.LogMessage(
                "GlobalSettingsView::EnableEmailNotifications::" +
                "Setting server name...");

            // Set the server name
            addSmtpServer.SMTPServerFQDNText = emailServer;

            // if the email port number is within the valid range
            if ((emailPortNumber > 0) && (emailPortNumber < 65536))
            {
                Core.Common.Utilities.LogMessage(
                "GlobalSettingsView::EnableEmailNotifications::" +
                "Setting SMTP port number...");

                // set the port number
                addSmtpServer.PortNumberText = 
                    emailPortNumber.ToString(
                        System.Globalization.CultureInfo.InvariantCulture);
            }

            // if an authentication method is specified
            if (false == emailAuthenticationMethod.Equals(String.Empty))
            {
                Core.Common.Utilities.LogMessage(
                "GlobalSettingsView::EnableEmailNotifications::" +
                "Setting SMTP authentication method...");

                // ...then set the authentication method
                addSmtpServer.Controls.AuthenticationMethodComboBox.SelectByText(
                    emailAuthenticationMethod);
            }

            // Click OK
            addSmtpServer.ClickOK();

            // verify server is listed in the dialog

            #endregion

            #region Set Email Options

            Core.Common.Utilities.LogMessage(
                "GlobalSettingsView::EnableEmailNotifications::" +
                "Setting return address...");

            // set return email address
            emailSettingsDialog.ReturnAddressText = returnAddress;

            // if an email subject was specified
            if (false == emailSubjectText.Equals(String.Empty))
            {
                Core.Common.Utilities.LogMessage(
                "GlobalSettingsView::EnableEmailNotifications::" +
                "Setting subject text...");

                // ...then set the email subject
                emailSettingsDialog.EmailSubjectText = emailSubjectText;
            }

            // if an email message body was specified
            if (false == emailMessageText.Equals(String.Empty))
            {
                Core.Common.Utilities.LogMessage(
                "GlobalSettingsView::EnableEmailNotifications::" +
                "Setting email message...");

                // ...then set the email message
                emailSettingsDialog.EmailMessageText = emailMessageText;
            }
            
            #region Set Email Encoding

            // if an encoding was specified
            if (false == emailEncoding.Equals(String.Empty))
            {
                Core.Common.Utilities.LogMessage(
                "GlobalSettingsView::EnableEmailNotifications::" +
                "Setting encoding...");

                // set the encoding format
                emailSettingsDialog.Controls.EncodingComboBox.SelectByText(
                    emailEncoding);
            }
            
            #endregion

            #endregion

            #region Commit the Change

            Core.Common.Utilities.LogMessage(
                "GlobalSettingsView::EnableEmailNotifications::" +
                "Committing change...");

            // Click OK
            emailSettingsDialog.ClickOK();
            UISynchronization.WaitForProcessReady(CoreManager.MomConsole.MainWindow);
            UISynchronization.WaitForUIObjectReady(CoreManager.MomConsole.MainWindow);

            #endregion

            // drop the reference to the dialog
            emailSettingsDialog = null;
        }
        #endregion

        #region Alert Global Settings

        #region Navigate
        /// <summary>
        /// Navigate and launch Global Management Group Settings - Alerts dialog
        /// </summary>
        /// <exception cref="Maui.GlobalExceptions.MauiException">Failed to find the 'Alerts' item in the view</exception>
        /// <history>
        ///     [lucyra] 04OCT06 - Created        
        /// </history>
        public static void NavigateToAlertGlobalSettingsDialog()
        {

            //Navigate to Administration -> Settings -> Alerts
            CoreManager.MomConsole.BringToForeground();

            Core.Common.Utilities.LogMessage("GlobalSettingsView.NavigateToAlertGlobalSettingsDialog:: " +
                "BringToForeground returned");

            NavigationPane navPane = CoreManager.MomConsole.NavigationPane;

            navPane.ClickWunderBarButton(NavigationPane.WunderBarButton.Administration);

            Core.Common.Utilities.LogMessage("GlobalSettingsView.NavigateToAlertGlobalSettingsDialog:: " + 
                "Successfully clicked on Administration Wunderbar");

            Maui.Core.WinControls.TreeNode globalSettingsNode = navPane.SelectNode(
                NavigationPane.Strings.AdminTreeViewAdministrationRoot +
                "\\" + NavigationPane.Strings.AdminTreeViewSettings, 
                NavigationPane.NavigationTreeView.Administration);

            globalSettingsNode.Click();

            Core.Common.Utilities.LogMessage("GlobalSettingsView.NavigateToAlertGlobalSettingsDialog:: " +
                "Successfully clicked on Settings under Administration Treeview");

            // get a reference to the view
            Core.Console.MomControls.GridControl settingsGrid =
                    CoreManager.MomConsole.ViewPane.Grid;

            Core.Common.Utilities.LogMessage(
                "GlobalSettingsView.NavigateToAlertGlobalSettingsDialog:: " +
                "Looking for 'Alerts' item in the grid...");

            // find the Alerts item in the grid view
            Maui.Core.WinControls.DataGridViewRow alertsRow =
                settingsGrid.FindData(Core.Console.GlobalSettings.GlobalSettingsView.Strings.Alerts);

            // select the Alert item under General Type in the grid view
            if (null != alertsRow)
            {
                Core.Common.Utilities.LogMessage(
                    "GlobalSettingsView.NavigateToAlertGlobalSettingsDialog:: " +
                    "Starting 'Alerts' dialog...");

                // start the dialog
                alertsRow.AccessibleObject.Click(
                    MouseClickType.DoubleClick);

                int retry = 0;
                int maxretry = 5;

                AlertsGlobalSettingsAlertResolutionDialog tryAlertsGlobalSettingsAlertResolutionDialog = null;

                while (tryAlertsGlobalSettingsAlertResolutionDialog == null && retry <= maxretry)
                {
                    try
                    {
                        Core.Common.Utilities.LogMessage("GlobalSettingsView.NavigateToAlertGlobalSettingsDialog:: " +
                            "Check if AlertsGlobalSettingsAlertResolutionDialog show up.");

                        tryAlertsGlobalSettingsAlertResolutionDialog = new AlertsGlobalSettingsAlertResolutionDialog(
                CoreManager.MomConsole);

                        if (tryAlertsGlobalSettingsAlertResolutionDialog != null)
                        {
                            Core.Common.Utilities.LogMessage("GlobalSettingsView.NavigateToAlertGlobalSettingsDialog:: " +
                                "AlertsGlobalSettingsAlertResolutionDialog successfully show up.");

                            //Explicitly set tryAlertsGlobalSettingsAlertResolutionDialog to null, avoid Hwnd mess in following method.
                            tryAlertsGlobalSettingsAlertResolutionDialog = null;
                            break;
                        }

                    }
                    catch (Maui.Core.Window.Exceptions.WindowNotFoundException ex)
                    {
                        if (retry == maxretry)
                            throw new Maui.Core.Window.Exceptions.WindowNotFoundException("GlobalSettingsView.NavigateToAlertGlobalSettingsDialog:: " +
                                "Cannot find AlertGlobalSettingsDialog", ex);

                        Core.Common.Utilities.LogMessage("GlobalSettingsView.NavigateToAlertGlobalSettingsDialog:: " +
                            "AlertsGlobalSettingsAlertResolutionDialog not show up, try again, retry times: " + retry.ToString());

                        alertsRow.AccessibleObject.Click(MouseClickType.SingleClick, MouseFlags.LeftButton);
                        CoreManager.MomConsole.ExecuteContextMenu(Views.Alerts.AlertsView.Strings.AlertPropertiesContextMenu, true);

                        Sleeper.Delay(Core.Common.Constants.OneSecond);
                    }

                    retry++;
                }         

            }
            else
            {
                throw new Maui.GlobalExceptions.MauiException(
                    "Failed to find the 'Alerts' item in the view!");
            }

        }

        #endregion

        #region Add Custom Alert Resolution State
        /// <summary>
        /// Add New Resolution State method - sets custom resolution state provided 
        /// Under Global Management Group Settings - Alerts dialog
        /// Note: you need to launch the dialog
        /// CHECK FOR RETURN VALUE: IF -1 THERE WERE PROBLEMS CREATING NEW RESOLUTION STATE
        /// </summary>
        /// <param name="resolutionState">Resolution State</param>
        /// <history>
        ///     [lucyra] 04OCT06 - Created        
        /// </history>
        public static int AddNewAlertResolutionState(string resolutionState)
        {
            int uniqueID = -1;
            string stUniqueID = null;

            AlertsGlobalSettingsAlertResolutionDialog alertsGlobalSettingsAlertResolutionDialog = null;
            AlertsGlobalSettingsNewResolutionDialog addAlertResolutionStateDialog = null;
            
            //Click New button under Alert Resolution States in the Global Management Group Settings - Alerts 
            //under Alert Resolution States tab
            alertsGlobalSettingsAlertResolutionDialog = new AlertsGlobalSettingsAlertResolutionDialog(
                CoreManager.MomConsole);

            alertsGlobalSettingsAlertResolutionDialog.Extended.SetFocus();

            Core.Common.Utilities.LogMessage("GlobalSettingsView.AddNewAlertResolutionState:: " +
                "Setting Focus on the Global Management Group Settings - Alert Dialog, " + 
                "Alert Resolution States tab  was successful");         
          
            int MaxRetries = 5;
            int retry = 0;
            while ((retry < MaxRetries) && (addAlertResolutionStateDialog == null))
            {
                //Click New button on the toolbar
                // [a-joelj] Maui 2.0: Need to use ScreenElement.WaitForReady because AccessibleObject.Click is returning
                // NullReferenceException.  This will wait until the Toolstrip is ready before clicking.
                alertsGlobalSettingsAlertResolutionDialog.Controls.ToolstripNewEditDelete.ScreenElement.WaitForReady();
                alertsGlobalSettingsAlertResolutionDialog.Controls.ToolstripNewEditDelete.ToolbarItems[0].Click();

                try
                {
                    //in the Add alert resolution state dialog input custom resolution state string and set unique ID
                    addAlertResolutionStateDialog = new AlertsGlobalSettingsNewResolutionDialog(CoreManager.MomConsole);
                    Core.Common.Utilities.LogMessage("GlobalSettingsView.AddNewAlertResolutionState:: " +
                        "Setting Focus on the Add Alert Resolution State dialog was successful");

                    addAlertResolutionStateDialog.Extended.SetFocus();

                    addAlertResolutionStateDialog.ResolutionStateText = resolutionState;

                    Core.Common.Utilities.LogMessage("GlobalSettingsView.AddNewAlertResolutionState:: " +
                        "New resolution state is: " + 
                        addAlertResolutionStateDialog.ResolutionStateText.ToString());

                    //addAlertResolutionStateDialog.ResolutionStateIDText = uniqueId.ToString();
                    stUniqueID = addAlertResolutionStateDialog.ResolutionStateIDText.ToString();

                    Core.Common.Utilities.LogMessage("GlobalSettingsView.AddNewAlertResolutionState:: " +
                        "New resolution state id is: " +
                        stUniqueID);

                    Core.Common.Utilities.TakeScreenshot("AddAlertResolutionStateDialog");

                    //Save the dialog
                    addAlertResolutionStateDialog.ClickOK();

                    break;

                }
                catch (Maui.Core.Window.Exceptions.WindowNotFoundException)
                {
                    retry++;
                    Core.Common.Utilities.LogMessage("GlobalSettingsView.AddNewAlertResolutionState:: " +
                        "Failed to find Add Alert Resolution State window in attempt: " + 
                        retry);

                    Core.Common.Utilities.TakeScreenshot("WindowNotFound_AddNewAlertResolutionState");

                }

            }
            //Check if the new item is added
            alertsGlobalSettingsAlertResolutionDialog.Extended.SetFocus();

            //if newResolutionState item is found then we added successfully
            if (alertsGlobalSettingsAlertResolutionDialog.Controls.ResolutionStatesList.Exists(resolutionState))
            {
                Core.Common.Utilities.LogMessage("GlobalSettingsView.AddNewAlertResolutionState:: " +
                    "New resolution state exists!");

                uniqueID = Convert.ToInt32(stUniqueID); 

            }
            else
            {
                Core.Common.Utilities.LogMessage("GlobalSettingsView.AddNewAlertResolutionState:: " +
                    "Was not able to find new resolution state with Exists method!");

                Core.Common.Utilities.TakeScreenshot("ItemNotFound_AddNewAlertResolutionState");
            }

            //Save global settings dialog
            alertsGlobalSettingsAlertResolutionDialog.ClickOK();
            CoreManager.MomConsole.Waiters.WaitForWindowIdle(CoreManager.MomConsole.MainWindow, 60000);

            return uniqueID;
        }

        #endregion

        #region Delete Custom Alert Resolution State
        /// <summary>
        /// Method to remove a custom Alert Resolution State
        /// Under Global Management Group Settings - Alerts dialog
        /// Note: you need to launch the dialog
        /// If there are more than one custom resolution states with the same name but different IDs,
        /// the first one in the list will be removed
        /// </summary>
        /// <param name="customAlertResolution">Custom Alert Resolution</param>
        /// <exception cref="Maui.Core.WinControls.ListView.Exceptions.ItemNotFoundException">ItemNotFoundException</exception>
        /// <history>
        ///     [lucyra] 04OCT06 - Created        
        /// </history>
        public static void DeleteCustomAlertResolutionState(string customAlertResolution)
        {
            AlertsGlobalSettingsAlertResolutionDialog alertsGlobalSettingsAlertResolutionDialog = null;

            alertsGlobalSettingsAlertResolutionDialog = new AlertsGlobalSettingsAlertResolutionDialog(
                CoreManager.MomConsole);

            alertsGlobalSettingsAlertResolutionDialog.Extended.SetFocus();

            //Select the Member from ListView and Remove it
            if (alertsGlobalSettingsAlertResolutionDialog.Controls.ResolutionStatesList.Exists(customAlertResolution))
            {
                ListViewItemCollection myCollection = 
                    alertsGlobalSettingsAlertResolutionDialog.Controls.ResolutionStatesList.Items;

                Core.Common.Utilities.LogMessage("GlobalSettingsView.DeleteCustomAlertResolutionState:: " +
                    "Successfully got the collection of all resolution states");

                int attempt;
                int MaxTry = 3;
                bool MemberSelected = false;

                foreach (ListViewItem member in myCollection)
                {
                    Core.Common.Utilities.LogMessage("GlobalSettingsView.DeleteCustomAlertResolutionState:: " +
                        "Selected resolution state");

                    if (member.Text.ToString() == customAlertResolution)
                    {
                        attempt = 0;
                        while (attempt < MaxTry)
                        {
                            try
                            {
                                member.Select();
                                Core.Common.Utilities.LogMessage("GlobalSettingsView.DeleteCustomAlertResolutionState:: " +
                                    "found resolution state : " + customAlertResolution);

                                //Click Delete button on the toolbar
                                //alertsGlobalSettingsAlertResolutionDialog.Controls.ToolstripNewEditDelete.AccessibleObject.Click();
                                alertsGlobalSettingsAlertResolutionDialog.Controls.ToolstripNewEditDelete[Core.Console.GlobalSettings.GlobalSettingsView.Strings.DeleteCustomAlertResolution].Click();

                                CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.OK, "*", StringMatchSyntax.WildCard, MomConsoleApp.ActionIfWindowNotFound.Ignore);

                                Core.Common.Utilities.LogMessage("GlobalSettingsView.DeleteCustomAlertResolutionState:: " +
                                    "Successfully removed resolution state");

                                Core.Common.Utilities.LogMessage("GlobalSettingsView.DeleteCustomAlertResolutionState:: " +
                                    "Apply and Close Alert Global Settings dialog after removing Custom Resolution State");

                                alertsGlobalSettingsAlertResolutionDialog.Extended.SetFocus();

                                alertsGlobalSettingsAlertResolutionDialog.ClickApply();

                                UISynchronization.WaitForUIObjectReady(
                                    alertsGlobalSettingsAlertResolutionDialog, 
                                    Core.Common.Constants.DefaultDialogTimeout * 2);

                                Core.Common.Utilities.LogMessage("GlobalSettingsView.DeleteCustomAlertResolutionState:: " +
                                    "Alert Global Settings dialog Saved");

                                alertsGlobalSettingsAlertResolutionDialog.ClickOK();

                                Core.Common.Utilities.LogMessage("GlobalSettingsView.DeleteCustomAlertResolutionState:: " +
                                    "Alert Global Settings dialog dismissed");

                                //After clicking OK wait for the property page to go away
                                CoreManager.MomConsole.WaitForDialogClose(
                                    alertsGlobalSettingsAlertResolutionDialog, 
                                    60);

                                int retry = 0;
                                int maxcount = 120;

                                while (!CoreManager.MomConsole.MainWindow.Extended.IsForeground && retry <= maxcount)
                                {
                                    Core.Common.Utilities.LogMessage("GlobalSettingsView.DeleteCustomAlertResolutionState:: " +
                                        "MainWindow not Foreground, lets wait a moment.");

                                    Sleeper.Delay(1000);
                                    retry++;
                                }
                                UISynchronization.WaitForUIObjectReady(
                                    CoreManager.MomConsole.MainWindow, 
                                    Core.Common.Constants.DefaultDialogTimeout * 2);

                                CoreManager.MomConsole.Waiters.WaitForStatusReady();

                                Core.Common.Utilities.LogMessage("GlobalSettingsView.DeleteCustomAlertResolutionState:: " +
                                    "Successfully closed dialog after removing :"
                                    + customAlertResolution);

                                MemberSelected = true;
                                break;
                            }
                            catch (System.NullReferenceException)
                            {
                                Core.Common.Utilities.LogMessage("GlobalSettingsView.DeleteCustomAlertResolutionState:: " +
                                    "NullReferenceException caught in Selecting a member - retry");

                                attempt++;
                            }
                        }
                    }//end of while

                    if (MemberSelected)
                    {
                        break;
                    }
                }
            }
            else
            {
                Core.Common.Utilities.LogMessage("GlobalSettingsView.DeleteCustomAlertResolutionState:: " +
                    "Failed to find Custom Resolution State :" +
                    customAlertResolution + " in ListView");

                alertsGlobalSettingsAlertResolutionDialog.Extended.SetFocus();

                alertsGlobalSettingsAlertResolutionDialog.ClickOK();

                throw new ListView.Exceptions.ItemNotFoundException(
                    "Failed to find Custom Resolution State in ListView");
            }

        }
        #endregion

        #endregion

        #endregion

      
        #region Constructor
        /// <summary>
        /// Global Settings View
        /// </summary>
        /// <history>
        ///     [lucyra] )04OCT06 - Created        
        /// </history>
        private GlobalSettingsView()
        {
            //Do nothing
        }
        #endregion              

        /// ------------------------------------------------------------------
        /// <summary>
        /// Class to hold resource strings
        /// </summary>
        /// ------------------------------------------------------------------
        public class Strings
        {
            #region Private Constants

            /// ------------------------------------------------------------------
            /// <summary>
            /// Resource string for DeleteCustomAlertResolution button
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceDeleteCustomAlertResolution = ";Delete;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.GroupSettings.ResolutionStates;toolStripButtonDelete.Text";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Resource string for Alerts
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceAlerts = ";Alerts;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.SettingsResources;GroupAlerts";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Resource string for Notifications
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceNotifications = ";Notification;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.SettingsResources;GroupNotification";            
                //";Notification;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" + 
                //"Microsoft.EnterpriseManagement.Mom.Internal.UI.Views.SharedResources;NotificationCategory";

            /// ------------------------------------------------------------------
            /// <summary>
            /// Resource string for ServerSecurity
            /// </summary>
            /// ------------------------------------------------------------------
            private const string ResourceServerSecurity = ";Security;ManagedString;Microsoft.EnterpriseManagement.UI.Administration.dll;" + 
                "Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.SettingsResources;ServerSecurity";

            #endregion

            #region Private Members

            /// ------------------------------------------------------------------
            /// <summary>
            /// Private variable to hold translated resource string for DeleteCustomAlertResolution
            /// </summary>
            /// ------------------------------------------------------------------
            private static string cachedDeleteCustomAlertResolution;

            /// ------------------------------------------------------------------
            /// <summary>
            /// Private variable to hold translated resource string for Alerts
            /// </summary>
            /// ------------------------------------------------------------------
            private static string cachedAlerts;

            /// ------------------------------------------------------------------
            /// <summary>
            /// Private variable to hold translated resource string for Notifications
            /// </summary>
            /// ------------------------------------------------------------------
            private static string cachedNotifications;

            /// ------------------------------------------------------------------
            /// <summary>
            /// Private variable to hold translated resource string for ServerSecurity
            /// </summary>
            /// ------------------------------------------------------------------
            private static string cachedServerSecurity;

            #endregion

            #region Public Properties

            /// ------------------------------------------------------------------
            /// <summary>
            /// Returns the translated resource string for DeleteCustomAlertResolution
            /// </summary>
            /// <history>
            ///     [lucyra] 30OCT06 - Created        
            /// </history>
            /// ------------------------------------------------------------------
            public static string DeleteCustomAlertResolution
            {
                get
                {
                    if (null == cachedDeleteCustomAlertResolution)
                    {
                        cachedDeleteCustomAlertResolution =
                            CoreManager.MomConsole.GetIntlStr(ResourceDeleteCustomAlertResolution);
                    }
                    return cachedDeleteCustomAlertResolution;
                }
            }

            /// ------------------------------------------------------------------
            /// <summary>
            /// Returns the translated resource string for Alerts
            /// </summary>
            /// <history>
            ///     [lucyra] 04OCT06 - Created        
            /// </history>
            /// ------------------------------------------------------------------
            public static string Alerts
            {
                get
                {
                    if (null == cachedAlerts)
                    {
                        cachedAlerts =
                            CoreManager.MomConsole.GetIntlStr(ResourceAlerts);
                    }
                    return cachedAlerts;
                }
            }

            /// ------------------------------------------------------------------
            /// <summary>
            /// Returns the translated resource string for Notifications
            /// </summary>
            /// ------------------------------------------------------------------
            public static string Notifications
            {
                get
                {
                    if (null == cachedNotifications)
                    {
                        cachedNotifications =
                            CoreManager.MomConsole.GetIntlStr(ResourceNotifications);
                    }
                    return cachedNotifications;
                }
            }
            
            /// ------------------------------------------------------------------
            /// <summary>
            /// Returns the translated resource string for ServerSecurity
            /// </summary>
            /// ------------------------------------------------------------------
            public static string ServerSecurity
            {
                get
                {
                    if (null == cachedServerSecurity)
                    {
                        cachedServerSecurity =
                            CoreManager.MomConsole.GetIntlStr(ResourceServerSecurity);
                    }
                    return cachedServerSecurity;
                }
            }

            #endregion
        }
    }
}
